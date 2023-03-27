
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
    /// Sağlık Kurulu Heyet Teşkili Tanımları
    /// </summary>
    public  partial class MemberOfHealthCommitteeDefinition : TTDefinitionSet
    {
        public partial class GetMemberOfHealthCommitteeDefinition_Class : TTReportNqlObject 
        {
        }

    /// <summary>
    /// SK Başkanı
    /// </summary>
        public string MasterOfHC
        {
            get
            {
                try
                {
#region MasterOfHC_GetScript                    
                    string sTitle = "";
                sTitle += MasterOfHealthCommittee.MilitaryClass != null ? MasterOfHealthCommittee.MilitaryClass.Name : "";
                sTitle += " " + MasterOfHealthCommittee.Rank != null ? MasterOfHealthCommittee.Rank.Name : "";
                sTitle += " " + MasterOfHealthCommittee.Name;
                return sTitle;
#endregion MasterOfHC_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MasterOfHC") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            
          
            base.PreUpdate();

#endregion PreUpdate
        }

        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();
           

#endregion PreDelete
        }

#region Methods
        //public override string ToString()
        //{
        //    return this.Date + " " + this.GroupNo;
        //}
        
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
            if(theObj.IsNew)
            {
                GroupNo.GetNextValue();
            }
        }
        
#endregion Methods

    }
}