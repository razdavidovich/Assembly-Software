using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Magma.WCF.Services.Bartender
{
    [ServiceContract(Namespace = "http://Magma.WCF.Services.Bartender")]
    public interface IBartenderService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobname"></param>
        /// <param name="waitForCompletionTimeoutInSeconds"></param>
        /// <param name="formatName"></param>
        /// <param name="printerName"></param>
        /// <param name="parameters"></param>
        /// <param name="identicalCopiesOfLabel"></param>
        /// <param name="numberSerializedLabels"></param>
        /// <param name="failIfParamMissing"></param>
        /// <returns></returns>
        [OperationContract]
        BTPrintResponse PrintLabel(string jobname, int? waitForCompletionTimeoutInSeconds, string formatName, string printerName, Dictionary<string, string> parameters, int identicalCopiesOfLabel, int numberSerializedLabels, MissingParamBehaviour missingParamBehaviour);
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract(Name = "BTPrintResponse", Namespace = "http://Magma.WCF.Services.Bartender")]
    public class BTPrintResponse
    {
        [DataMember]
        public Seagull.BarTender.Print.Result Result { get; private set; }
        
        [DataMember]
        public List<string> Messages { get; private set; }

        private const string MESSAGE_TEMPLATE = "Category={0}, ID={1}, Severity={2}, Source={3}, Text={4}, VerificationProblem={5}, VerificationResult={6}, VerificationAutofix={7}";

        public BTPrintResponse(Seagull.BarTender.Print.Result result, Seagull.BarTender.Print.Messages messages)
        {
            Result = result;

            Messages = new List<string>();

            try
            {
                if (messages != null)
                {
                    foreach (Seagull.BarTender.Print.Message message in messages)
                    {
                        string strMessage = String.Format(MESSAGE_TEMPLATE, message.Category, message.ID.ToString(), message.Severity.ToString(), message.Source.ToString(), message.Text, message.Verification.Problem, message.Verification.Result, message.Verification.AutoFix);
                        Messages.Add(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                
                Messages.Add("Failed to add BT message: " + ex);
            }
        }

    }

    [DataContract(Name = "MissingParamBehaviour", Namespace = "http://Magma.WCF.Services.Bartender")]
    public enum MissingParamBehaviour
    {
        [EnumMember]
        Ignore,
        [EnumMember]
        Fail,
        [EnumMember]
        SetEmptyString
    }

}
