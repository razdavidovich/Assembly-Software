using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Magma.WCF.Services.Logging
{
    public class Logger
    {
        public enum SeverityTypes
        {
            Debug = 0,
            Information = 1,
            Warning =2,
            Error = 3,
            Off = 4
        }

        public static SeverityTypes Severity { get; private set; }

        public static string Source { get; private set; }

        public static void InitLog(string sourceName, string logName, SeverityTypes severity)
        {
            try
            {
                Severity = severity;
                Source = sourceName;
                
                if (!EventLog.SourceExists(sourceName, "."))
                {
                    EventLog.CreateEventSource(new EventSourceCreationData(sourceName, logName));

                }
            }
            catch //never fail
            {

            }
        }

        
        public static void Write(string message,EventLogEntryType eventLogEntryType, SeverityTypes currentSeverity)
        {
            try
            {
                if (currentSeverity >= Severity)
                {
                    EventLog.WriteEntry(Source, message, eventLogEntryType);
                }
            }
            catch // never fail
            {
            }
        }

        public static void Write(Exception ex)
        {
            string message = string.Empty;

            try
            {
                message = ex.ToString();

                if (ex.InnerException != null)
                {
                    message = "Inner exception: " + ex.InnerException.ToString() + ". " + message;
                }

                Write(message, EventLogEntryType.Error, SeverityTypes.Error);
            }
            catch (Exception)
            {
            }

        }

        public static void Debug(string methodName, string param1, string param2 = "", string param3 = "", string param4 = "", string param5 = "", string param6 = "", string param7 = "", EventLogEntryType eventLogEntryType = EventLogEntryType.Information)
        {
            string loggingString = "Method: {0}. Param1: {1}. Param2: {2}. Param3: {3}. Param4: {4}. Param5: {5}. Param6: {6}. Param7; {7}";
            try
            {
                loggingString = String.Format(loggingString, methodName, param1, param2,param3, param4, param5, param6, param7);
                Write(loggingString, eventLogEntryType, Logger.SeverityTypes.Debug);
            }
            catch (Exception)
            { }
        }
    }
}
