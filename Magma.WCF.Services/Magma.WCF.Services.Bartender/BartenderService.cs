using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Magma.WCF.Services.Logging;
using Seagull.BarTender.Print;

namespace Magma.WCF.Services.Bartender
{
    public class BartenderService : IBartenderService
    {
        #region Class properties

        /// <summary>
        /// single static bartender engine object. There should only be one per process. a running engine is a Bartender.exe process.
        /// </summary>
        protected static Engine _engine = null;

        
        /// <summary>
        /// returns the running engine object. if it is the first time in the process, it creates and starts the engine.
        /// </summary>
        public static Engine BTEngine
        {
            get
            {
                // check if engine was created
                if (_engine == null)
                {
                   _engine = new Engine(true);
                    Logger.Write("BT Engine created", EventLogEntryType.Information, Logger.SeverityTypes.Information);
                }

                // check if engine is alive
                if (!_engine.IsAlive)
                {
                    _engine.Start();
                    Logger.Write("BT Engine started", EventLogEntryType.Information, Logger.SeverityTypes.Information);
                }

                return _engine;
            }
        }

        #endregion

        #region Class construction

        /// <summary>
        /// 
        /// </summary>
        static BartenderService()
        {
            _engine = null;
        }

        #endregion

        #region Operations Contracts

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="waitForCompletionTimeoutInSeconds"></param>
        /// <param name="formatName"></param>
        /// <param name="printerName"></param>
        /// <param name="parameters"></param>
        /// <param name="identicalCopiesOfLabel"></param>
        /// <param name="numberSerializedLabels"></param>
        /// <param name="missingParamBehaviour"></param>
        /// <returns></returns>
        public BTPrintResponse PrintLabel(string jobName, int? waitForCompletionTimeoutInSeconds, string formatName, string printerName, Dictionary<string, string> parameters, int identicalCopiesOfLabel, int numberSerializedLabels, MissingParamBehaviour missingParamBehaviour)
        {
            Messages messages = null;
            LabelFormatDocument document = null;
            Seagull.BarTender.Print.Result btResult;

            try 
	        {
                Logger.Debug("PrintLabel", jobName, formatName, printerName, identicalCopiesOfLabel.ToString(), numberSerializedLabels.ToString(), Enum.GetName(typeof(MissingParamBehaviour), missingParamBehaviour));

		        // get the label document format from the engine, using the format name and printer name
                document = BTEngine.Documents.FirstOrDefault(d => d.FileName == formatName);

                // check if the document is null - meaning that this is the first time that this label was printed since starting the engine process
                if (document == null)
                {
                    Logger.Debug("PrintLabel", "Document wasn't loaded before. Loading now", formatName);
                    // so open it. This should only happen once in each life cycle of the process.
                    document = BTEngine.Documents.Open(formatName);
                }

                // set the printer name.
                document.PrintSetup.PrinterName = printerName;

                // do this check in case the client had sent a null dictionary. This doens't mean that everything should neccessarly fail. 
                if (parameters == null)
                {
                    Logger.Debug("PrintLabel", "No parameters were sent!", eventLogEntryType:EventLogEntryType.Warning);
                    // so we create an instance so the following loop won't throw object ref exception
                    parameters = new Dictionary<string, string>();
                }

                // go over all substrings in the label format
                for (int index = 0; index < document.SubStrings.Count; index++)
                {
                    // check if the parameters dictionary 
                    if (parameters.Keys.Contains(document.SubStrings[index].Name))
                    {
                        string value = parameters[document.SubStrings[index].Name];

                        if (!String.IsNullOrEmpty(value))
                        {
                            document.SubStrings[index].Value = value;
                        }
                        else
                        {
                            document.SubStrings[index].Value = " ";
                        }
                    }
                    else // there is no value in the parameters dictionary for this substring. So figure out what to do according to the behaviour
                    {
                        switch (missingParamBehaviour)
                        {
                            case MissingParamBehaviour.Ignore:
                                Logger.Debug("PrintLabel", "Missing param", document.SubStrings[index].Name, "Ignoring");
                                break;
                            case MissingParamBehaviour.Fail:
                                throw new Exception(String.Format("There is no value in the parameters dictionary for the {0} substring of the label: {1}.", document.SubStrings[index].Name, formatName));
                            case MissingParamBehaviour.SetEmptyString:
                                document.SubStrings[index].Value = " ";
                                Logger.Debug("PrintLabel", "Missing param", document.SubStrings[index].Name, "Set empty string");
                                break;
                           
                        }
                    }
                }

                // set copies and serialized copies
                document.PrintSetup.IdenticalCopiesOfLabel = identicalCopiesOfLabel;

                if (document.PrintSetup.SupportsSerializedLabels)
                {
                    document.PrintSetup.NumberOfSerializedLabels = numberSerializedLabels;
                }
                else
                {
                    Logger.Debug("PrintLabel", "No Support for serialized labels", document.PrintSetup.SupportsSerializedLabels.ToString(), eventLogEntryType: EventLogEntryType.Warning); 
                }
               
               
                // now, we determine which BT print method to use accourding to the waitForCompletionTimeoutInSeconds. 
                if (waitForCompletionTimeoutInSeconds == null)
                {
                    // this one if it's null
                    btResult = document.Print(jobName, out messages);
                }
                else // this one if it is not
                {
                    btResult = document.Print(jobName, (int)waitForCompletionTimeoutInSeconds, out messages);

                }

                Logger.Debug("PrintLabel", "After Print", Enum.GetName( btResult.GetType(), btResult));

                // create a respone object and return it
                return new BTPrintResponse(btResult, messages);
	        }
	        catch (Exception ex)
	        {
                Logger.Write(ex);
                return new BTPrintResponse(Result.Failure, null);
	        }
        }

        #endregion

        #region Class methods

        /// <summary>
        /// 
        /// </summary>
        public static void StopBTEngine()
        {
            if (_engine != null)
            {
                Logger.Write("Stopping BT engine", EventLogEntryType.Information, Logger.SeverityTypes.Information);

                _engine.Stop();
                _engine.Dispose();
                _engine = null;
            }
        }

        #endregion
    }
}
