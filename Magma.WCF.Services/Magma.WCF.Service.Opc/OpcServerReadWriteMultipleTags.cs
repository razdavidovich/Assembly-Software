using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPC;
using OPCDA;
using OPCDA.NET;
using Lighthouse.Opc.ClientLibrary;

namespace Magma.WCF.Service.Opc
{
    public class OpcServerReadWriteMultipleTags : OpcServerReadWrite
    {
        private OpcServer opcSrv = new OpcServer();

        public OpcServerReadWriteMultipleTags(string serverNode, string serverProgID)
        {
            ConnectOPC(serverNode, serverProgID);
        }

        private string GetQualityAsString(short quality)
        {
            string str = "BAD";
            try
            {
                return ((OPC_QUALITY_STATUS)quality).ToString();
            }
            catch (Exception)
            {
                return str;
            }
        }

        public void ConnectOPC(string serverNode, string serverProgID)
        {
            this.opcSrv = new OpcServer();
            this.opcSrv.ErrorsAsExecptions = true;
            if (string.IsNullOrEmpty(serverNode))
                this.opcSrv.Connect(serverProgID);
            else
                this.opcSrv.Connect(serverNode, serverProgID);
        }

        public void DisconnectOPC()
        {
            if (this.opcSrv != null)
                this.opcSrv.Disconnect();
            this.opcSrv = (OpcServer)null;
        }

        public OpcServerReadWriteMultipleValues[] ReadMultipleTags(string groupName, List<string> tagAddressList, bool readDevice)
        {
            if (this.opcSrv == null)
            {
                throw new Exception("Invalid Server");
            }

            OpcGroup groupObject = (OpcGroup)null;
            ArrayList arrayList = new ArrayList();
            OpcServerReadWriteMultipleValues[] OpcServerReadWriteMultipleValues = new OpcServerReadWriteMultipleValues[tagAddressList.Count];

            try
            {
                groupObject = this.opcSrv.AddGroup(groupName, true, 100, 2);
                //OPCItemDef[] arrDef = new OPCItemDef[1] { new OPCItemDef(tagAddress, true, 0, typeof(void)) };
                OPCItemDef[] arrDef = new OPCItemDef[tagAddressList.Count];
                int iDef = 0;
                foreach (string tagAddress in tagAddressList)
                {
                    arrDef[iDef] = new OPCItemDef(tagAddress, true, 0, typeof(void));
                    iDef++;
                }
                OPCItemResult[] aRslt;
                groupObject.AddItems(arrDef, out aRslt);
                for (int index = 0; index < aRslt.Length; ++index)
                {
                    if (HRESULTS.Failed(aRslt[index].Error))
                        throw new Exception("Error: " + aRslt[index].Error.ToString());
                    arrayList.Add((object)aRslt[index].HandleServer);
                }
                OPCDATASOURCE src = OPCDATASOURCE.OPC_DS_CACHE;
                if (readDevice)
                    src = OPCDATASOURCE.OPC_DS_DEVICE;
                int[] array = (int[])arrayList.ToArray(typeof(int));
                OPCItemState[] aResult;
                int hresultcode = groupObject.Read(src, array, out aResult);
                if (!HRESULTS.Succeeded(hresultcode))
                    throw new Exception("Error: " + hresultcode.ToString());
                if (aResult != null)
                {
                    for (int rindex = 0; rindex < aResult.Length; ++rindex)
                    {
                        OpcServerReadWriteMultipleValues OpcServerReadWriteMultipleValuesTemp = new OpcServerReadWriteMultipleValues();

                        if (!HRESULTS.Succeeded(aResult[rindex].Error))
                            throw new Exception("Error: " + aResult[rindex].Error.ToString());
                        OpcServerReadWriteMultipleValuesTemp.TagAddress = arrDef[rindex].ItemID;
                        OpcServerReadWriteMultipleValuesTemp.Value = aResult[rindex].DataValue;
                        OpcServerReadWriteMultipleValuesTemp.Timrstanp = aResult[rindex].TimeStampNet;
                        OpcServerReadWriteMultipleValuesTemp.Quality = this.GetQualityAsString(aResult[rindex].Quality);
                        OpcServerReadWriteMultipleValues[rindex] = OpcServerReadWriteMultipleValuesTemp;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.opcSrv != null && groupObject != null)
                    this.opcSrv.RemoveGroup(groupObject, true);
            }
            return OpcServerReadWriteMultipleValues;
            
        }

    }

    public class OpcServerReadWriteMultipleValues
    {
        public string TagAddress;
        public DateTime Timrstanp;
        public string Quality;
        public object Value;
       
    }
  
}
