
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
    /// Diyet İşlemleri Tanımlama
    /// </summary>
    public  partial class DietDefinition : ProcedureDefinition
    {
        public partial class GetDietDefinition_Class : TTReportNqlObject 
        {
        }

#region Methods
        [LooselyTypeAttribute]
        [Serializable]
        public class NIRegimeGroup
        {
            public string ObjectId;
            public string Name;
            public string Code;
        }

        public void SendDietDefinitionToDietRationSystem()
        {
            IList<DietDefinition.NIRegimeGroup> regimeGroupList = new List<DietDefinition.NIRegimeGroup>();
            DietDefinition.NIRegimeGroup dietDef = new DietDefinition.NIRegimeGroup();
            dietDef.ObjectId = ObjectID.ToString();
            dietDef.Name = Name.ToString();
            dietDef.Code = Code;
            regimeGroupList.Add(dietDef);
            //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.LowPriority, "Nebula.Integration", "NebulaIntegrationUtils", "SaveRegimeGroup", null, regimeGroupList);
        }
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.DietDefinitionInfo;
        }
        
#endregion Methods

    }
}