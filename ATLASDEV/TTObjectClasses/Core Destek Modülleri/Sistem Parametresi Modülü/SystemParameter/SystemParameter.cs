using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;



namespace TTObjectClasses
{
    public partial class SystemParameter : TerminologyManagerDef
    {
        public partial class GetSystemParameterDefinition_Class : TTReportNqlObject
        {
        }

        public partial class AllSysParams_Class : TTReportNqlObject
        {
        }

        public partial class GetApplicationParameterDefinition_Class : TTReportNqlObject
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
            IsActive = true;
            SystemParameter.RefreshCache();
#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            CheckImportantParameters();
            SystemParameter.RefreshCache();
#endregion PostUpdate
        }

#region Methods
        public static bool IsPatientExaminationParticipationControl
        {
            get
            {
                //                string participationControl = GetParameterValue("PATIENTEXAMINATIONPARTICIPATIONCONTROL", "TRUE");
                //                bool result;
                //                bool.TryParse(participationControl, out result);
                //                return result;
                return true;
            }
        }

        public static bool IsDigitalSignatureIntegration
        {
            get
            {
                string digitalSignatureIntegration = GetParameterValue("EIMZAENTEGRASYON", "FALSE");
                bool result;
                bool.TryParse(digitalSignatureIntegration, out result);
                return result;
            }
        }

        public static bool IsUniversityHospital
        {
            get
            {
                string universityHospital = GetParameterValue("UNIVERSITEXXXXXX", "FALSE");
                bool result;
                bool.TryParse(universityHospital, out result);
                return result;
            }
        }

        public static bool IsMedulaTest
        {
            get
            {
                string medulaTest = GetParameterValue("MEDULATEST", "FALSE");
                bool result;
                bool.TryParse(medulaTest, out result);
                return result;
            }
        }

        public static bool IsMedula
        {
            get
            {
                string medula = GetParameterValue("MEDULA", "FALSE");
                bool result;
                bool.TryParse(medula, out result);
                return result;
            }
        }

        public static bool IsMedulaIntegration
        {
            get
            {
                string medulaEntegrasyon = GetParameterValue("MEDULAENTEGRASYON", "FALSE");
                bool result;
                bool.TryParse(medulaEntegrasyon, out result);
                return result;
            }
        }

        public static bool IsWorkWithOutStock
        {
            get
            {
                string workWithOutStock = GetParameterValue("WORKWITHOUTSTOCK", "FALSE");
                bool result;
                bool.TryParse(workWithOutStock, out result);
                return result;
            }
        }

        public static int GetSaglikTesisKodu()
        {
            string saglikTesisKodu = GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
            if (Globals.IsNumeric(saglikTesisKodu))
                return Convert.ToInt32(saglikTesisKodu);
            return 0;
        }

        public static string GetKtsHbysKodu()
        {
            return GetParameterValue("KTSHBYSKODU", string.Empty);
        }

        public static Sites GetSite()
        {
            string siteID = GetParameterValue("SITEID", Guid.Empty.ToString());
            if (Globals.IsGuid(siteID))
            {
                Guid objectID = new Guid(siteID);
                return Sites.AllSites[objectID];
            }

            return null;
        }

        public static ResHospital GetHospital()
        {
            string hospital = GetParameterValue("HOSPITAL", Guid.Empty.ToString());
            if (Globals.IsGuid(hospital))
            {
                Guid objectID = new Guid(hospital);
                TTObjectContext objectContext = new TTObjectContext(true);
                TTObject ttObject = objectContext.GetObject(objectID, typeof (ResHospital));
                if (ttObject != null)
                    return (ResHospital)ttObject;
            }

            return null;
        }

        private static object parameterLock = new object();
        private static Dictionary<string, SystemParameter> _allParameters;
        private static List<string> _importantParameters;
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Hasta_Yatis_On_Yatis)]
        public static string GetParameterValue(string name, string defaultValue)
        {
            SystemParameter systemParameter;
            bool found = false;
            lock(parameterLock)
            {
                found = _allParameters.TryGetValue(name, out systemParameter);
            }
            if (found)
            {
                if (systemParameter.IsCacheExpired())
                {
                    ITTObject ttobject = (ITTObject)systemParameter;
                    ttobject.Refresh();
                }

                if (systemParameter.Value != null)
                {
                    if (systemParameter.IsEncrypted.HasValue && systemParameter.IsEncrypted.Value == true)
                        return TTUtils.EncryptionBase.Decrypt(systemParameter.Value);
                    else
                        return systemParameter.Value;
                }
            }

            return defaultValue;
        }

        public static void RefreshCache()
        {
            TTObjectContext context = new TTObjectContext(true);
            var lst = context.QueryObjects<SystemParameter>();
            lock (parameterLock)
            {
                _allParameters = new Dictionary<string, SystemParameter>();
                foreach (SystemParameter parameter in lst)
                {
                    _allParameters.Add(parameter.Name, parameter);
                }

                if (_importantParameters == null)
                {
                    _importantParameters = new List<string>();
                    _importantParameters.Add("SITEID");
                    _importantParameters.Add("HOSPITAL");
                    _importantParameters.Add("MEDULA");
                    _importantParameters.Add("MEDULAENTEGRASYON");
                    _importantParameters.Add("MEDULASAGLIKTESISKODU");
                    _importantParameters.Add("SPTSHOSPITALID");
                    _importantParameters.Add("WORKWITHOUTSTOCK");
                    _importantParameters.Add("ACCOUNTENTEGRATION");
                    _importantParameters.Add("WORKWITHPERSONNELINFOSYSTEM");
                }
            }
        }

        static SystemParameter()
        {
            RefreshCache();
        }

        private DateTime _lastRefreshTime = DateTime.Now;
        public bool IsCacheExpired()
        {
            if ((CacheDurationInMinutes ?? 0) == 0)
                return false;
            TimeSpan diff = DateTime.Now - _lastRefreshTime;
            if (diff.TotalMinutes >= CacheDurationInMinutes.Value)
            {
                _lastRefreshTime = DateTime.Now;
                return true;
            }

            return false;
        }

        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if (localPropertyNamesList == null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("Value");
            localPropertyNamesList.Add("IsEncrypted");
            return localPropertyNamesList;
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.SystemParameterInfo;
        }

        public void CheckImportantParameters()
        {
            if (_importantParameters.Contains(Name))
                throw new Exception(SystemMessage.GetMessage(586));
        }
#endregion Methods
    }
}