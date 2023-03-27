
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
    /// <summary>
    /// Demirbaş Malzeme Bilgileri
    /// </summary>
    public  partial class FixedAssetDefinition : Material
    {
        public partial class FixedAssetDefinitionFormNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetDefinitionListQuery_Class : TTReportNqlObject 
        {
        }

        public partial class FixedAssetQuerybyUpdateAction_Class : TTReportNqlObject 
        {
        }

        public partial class FixedAssetDefinitionForCMRAction_Class : TTReportNqlObject 
        {
        }

        
                    
#region Methods
        public override List<string> GetMyLocalPropertyNamesList()
        {
            
            List<string> localPropertyNamesList = base. GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("CODE");
            return localPropertyNamesList;
        }
        
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.FixedAssetDefinitionInfo;
        }
        
        protected override void OnBeforeImportFromObject(DataRow dataRow)
        {
            base.OnBeforeImportFromObject(dataRow);

            if(dataRow["CALIBRATIONPERIOD"] == null || dataRow["CALIBRATIONPERIOD"] == DBNull.Value)
            {
                dataRow["CALIBRATIONPERIOD"] = 0;
            }
            if(dataRow["CALIBRATIONTIME"] == null || dataRow["CALIBRATIONTIME"] == DBNull.Value)
            {
                dataRow["CALIBRATIONTIME"] = 0;
            }
            if(dataRow["MAINTENANCEPERIOD"] == null || dataRow["MAINTENANCEPERIOD"] == DBNull.Value)
            {
                dataRow["MAINTENANCEPERIOD"] = 0;
            }
            if(dataRow["MAINTENANCETIME"] == null || dataRow["MAINTENANCETIME"] == DBNull.Value)
            {
                dataRow["MAINTENANCETIME"] = 0;
            }
            if(dataRow["NEEDCALIBRATION"] == null || dataRow["NEEDCALIBRATION"] == DBNull.Value)
            {
                dataRow["NEEDCALIBRATION"] = 0;
            }
            if(dataRow["ISCALIBRATOR"] == null || dataRow["ISCALIBRATOR"] == DBNull.Value)
            {
                dataRow["ISCALIBRATOR"] = 0;
            }        }
        
#endregion Methods

    }
}