
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
    /// Sarf Edilebilen Malzeme Tanımları
    /// </summary>
    public  partial class ConsumableMaterialDefinition : Material
    {
        public partial class GetConsumableMaterialDefinition_Class : TTReportNqlObject 
        {
        }

        
                    
#region Methods
        public override List<string> GetMyLocalPropertyNamesList()
        {
            
            List<string> localPropertyNamesList = base. GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("PURCHASEDATE");
            localPropertyNamesList.Add("AUCTIONDATE");
            localPropertyNamesList.Add("REGISTRATIONAUCTIONNO");
            
            return localPropertyNamesList;
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ConsumableMaterialDefinitionInfo;
        }
        
        protected override void OnBeforeImportFromObject(DataRow dataRow)
        {
            base.OnBeforeImportFromObject(dataRow);

            if(dataRow["ALLOWTOGIVEPATIENT"] == null || dataRow["ALLOWTOGIVEPATIENT"] == DBNull.Value)
            {
                dataRow["ALLOWTOGIVEPATIENT"] = 0;
            }
        }
        
#endregion Methods

    }
}