using System.Collections.Specialized;
using System.Configuration;
using Assembly.Software.Utilities;

namespace Loftware.Cloud.Integration
{
    public class clsCommon
    {
        #region ReadSingleConfigValue
        public string ReadSingleConfigValue(string strConfigGroup, string strConfigSection, string strItemName, bool blnWinConfig = true)
        {
            try
            {
                return Config.get_ReadConfigValue(strItemName, strConfigSection, strConfigGroup);
            }
            catch { throw; }
        }
        #endregion

        #region ReadConfigGetSectionGroup
        public NameValueCollection ReadConfigGetSectionGroup(string strSectionName)
        {
            try
            {
                return ConfigurationManager.GetSection(strSectionName) as NameValueCollection;
            }
            catch { throw; }
        }
        #endregion

        #region SaveConfigSettingsValue
        public void SaveConfigSettingsValue(string strConfigGroup, string strConfigSection, string strItemName, string strValue)
        {
            try
            {
                Config.SaveConfigValue(strItemName, strConfigSection, strConfigGroup, strValue);
            }
            catch { throw; }
        }
        #endregion
    }
}
