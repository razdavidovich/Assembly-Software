using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace Loftware.Cloud.Integration
{
    #region clsLoftwareCloudPrint
    public class clsLoftwareCloudPrint
    {
        public enum LLMStatusCodes
        {
            None = 0,
            CriticalFailure = 2,
            Success = 4,
            PartialSuccess = 6,
            DeviceError = 8
        }

        public enum LPSXmlFileFormat
        {
            Loftware = 1,
            NiceLabel = 2
        }

        public string strFullEndpoint { get; }
        public string strIpAddress { get; }
        public int intPort { get; }

        protected string m_strLabelDtd = "label.dtd";

        public clsLoftwareCloudPrint(string strIpAddress, int intPort)
        {
            this.strIpAddress = strIpAddress;
            this.intPort = intPort;
            strFullEndpoint = $"{strIpAddress}:{intPort}";
            new clsLoftwareCloudPrint(strFullEndpoint);
        }

        public clsLoftwareCloudPrint(string strFullEndpoint)
        {
            this.strFullEndpoint = strFullEndpoint;
            string[] strSplitValues = this.strFullEndpoint.Split(':');
            this.strIpAddress = strSplitValues[0];
            this.intPort = Convert.ToInt32(strSplitValues[1]);
        }

        #region PrintBatchLabelDictionary
        public int PrintBatchLabelDictionary(string strPrinterName, string strLabelName, int intSerializedLabels, int intNumberOfCopies, Dictionary<string, string> dictParams, LPSXmlFileFormat lPSXmlFileFormat = LPSXmlFileFormat.Loftware)
        {
            try
            {
                string strXMLString = GenerateXmlString(strPrinterName, strLabelName, intSerializedLabels, intNumberOfCopies, dictParams, lPSXmlFileFormat);
                string strTcpResponse = SendMessageTcp(strXMLString);
                bool success = int.TryParse(strTcpResponse, out int result);
                if (!success)
                {
                    return (int)LLMStatusCodes.CriticalFailure;
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region GenerateXmlString
        private string GenerateXmlString(string strPrinterName, string strLabelName, int intSerializedLabels, int intNumberOfCopies, Dictionary<string, string> dictParams, LPSXmlFileFormat lPSXmlFileFormat = LPSXmlFileFormat.Loftware)
        {
            try
            {
                using (StringWriter stringWriter = new Utf8StringWriter())
                {
                    using (XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter))
                    {
                        xmlWriter.Formatting = Formatting.Indented;

                        if (LPSXmlFileFormat.Loftware == lPSXmlFileFormat)
                        {
                            // Write the XML declaration
                            xmlWriter.WriteStartDocument(false);

                            xmlWriter.WriteDocType("labels", null, m_strLabelDtd, null);

                            // Write the root element
                            xmlWriter.WriteStartElement("labels");

                            // Write a book element
                            xmlWriter.WriteStartElement("label");

                            if (!string.IsNullOrEmpty(strLabelName))
                                xmlWriter.WriteAttributeString("_FORMAT", strLabelName);

                            if (!string.IsNullOrEmpty(strPrinterName))
                                xmlWriter.WriteAttributeString("_PRINTERNAME", strPrinterName);

                            if (intNumberOfCopies > 0)
                                xmlWriter.WriteAttributeString("_QUANTITY", Convert.ToString(intNumberOfCopies, 10));

                            if (intSerializedLabels > 0)
                                xmlWriter.WriteAttributeString("_DUPLICATES", Convert.ToString(intSerializedLabels, 10));

                            foreach (var item in dictParams)
                            {
                                xmlWriter.WriteStartElement("variable");
                                xmlWriter.WriteAttributeString("name", item.Key);
                                WriteSafeXmlString(item.Value, xmlWriter);
                                xmlWriter.WriteEndElement();
                            }

                            // Close the book element
                            xmlWriter.WriteEndElement();

                            // Close the root element
                            xmlWriter.WriteEndElement();

                            // End the document
                            xmlWriter.WriteEndDocument();
                        }
                        else
                        {
                            // Write the root element
                            xmlWriter.WriteStartElement("nice_commands");

                            // Write a label element
                            xmlWriter.WriteStartElement("label");

                            if (!string.IsNullOrEmpty(strLabelName))
                                xmlWriter.WriteAttributeString("name", strLabelName);

                            // Write a print_job element
                            xmlWriter.WriteStartElement("print_job");

                            if (!string.IsNullOrEmpty(strPrinterName))
                                xmlWriter.WriteAttributeString("printer", strPrinterName);

                            if (intNumberOfCopies > 0)
                                xmlWriter.WriteAttributeString("quantity", Convert.ToString(intNumberOfCopies, 10));

                            if (intSerializedLabels > 0)
                                xmlWriter.WriteAttributeString("identical_copies", Convert.ToString(intSerializedLabels, 10));

                            foreach (var item in dictParams)
                            {
                                xmlWriter.WriteStartElement("variable");
                                xmlWriter.WriteAttributeString("name", item.Key);
                                WriteSafeXmlString(item.Value, xmlWriter);
                                xmlWriter.WriteEndElement();
                            }

                            // Close the print_job element
                            xmlWriter.WriteEndElement();

                            // Close the root element
                            xmlWriter.WriteEndElement();
                        }
                    }

                    // Return the generated XML as a string
                    return stringWriter.ToString();
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region WriteSafeXmlString
        private void WriteSafeXmlString(string strData, XmlWriter xtwOutput)
        {
            if (strData == null || strData.Length <= 0)
                return;

            if (strData.IndexOf('€', 0, strData.Length) == -1)
            {
                xtwOutput.WriteString(strData);
            }
            else
            {
                for (int startIndex = 0; startIndex < strData.Length; ++startIndex)
                {
                    if (strData[startIndex] == 8364)
                        xtwOutput.WriteCharEntity('€');
                    else
                        xtwOutput.WriteChars(strData.ToCharArray(startIndex, 1), 0, 1);
                }
            }
        }
        #endregion

        #region SendMessageTcp
        private string SendMessageTcp(string message)
        {
            try
            {
                using (TcpClient client = new TcpClient(strIpAddress, intPort))
                {
                    // Set the send and receive timeouts (in milliseconds)
                    client.SendTimeout = 5000; // 5 seconds send timeout
                    client.ReceiveTimeout = 30000; // 30 seconds receive timeout

                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        stream.Write(data, 0, data.Length);

                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
    #endregion

    #region Utf8StringWriter
    /*Override for support the XML to UTF-8 format enocde process*/
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
    #endregion

}
