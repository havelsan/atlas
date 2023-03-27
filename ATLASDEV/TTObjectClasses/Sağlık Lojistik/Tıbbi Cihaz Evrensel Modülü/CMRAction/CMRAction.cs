
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
    /// Tıbbi Cihaz İşlemleri Ana Sınıfı
    /// </summary>
    public  partial class CMRAction : BaseAction, ICMRActionWorkList
    {
        public partial class GetCMRRegistrationReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetCMRActionQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetRequestCMRActionQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetCMRActionsCount_Class : TTReportNqlObject 
        {
        }

        public partial class GetFailureRateRQ_Class : TTReportNqlObject 
        {
        }

        public partial class GetStockInheld_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "FIXEDASSETMATERIALDEFINITION":
                    {
                        FixedAssetMaterialDefinition value = (FixedAssetMaterialDefinition)newValue;
#region FIXEDASSETMATERIALDEFINITION_SetParentScript
                        //if (value.SerialNumber == null & value.Model == null)
            //    throw new TTUtils.TTException ("Seçmiş olduğunuz Demirbaş'ın Malzeme Tanımlarını Güncellemeniz Gerekmektedir!");
#endregion FIXEDASSETMATERIALDEFINITION_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
#endregion PreInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            WorkListDate = DateTime.Now.Date ;
#endregion PostUpdate
        }

        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PreTransition_New2Cancelled
            
            if(FixedAssetMaterialDefinition != null)
                FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InUse;


#endregion PreTransition_New2Cancelled
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
        }
        
        public void FillEquipments()
        {
//            if (this.FixedAssetMaterialDefinition != null)
//            {
//                this.CMR_ItemEquipments.Clear();
//                foreach(FixedAssetMaterialContent content in this.FixedAssetMaterialDefinition.Contents)
//                {
//                    CMR_ItemEquipment cmrItemEquipment = new CMR_ItemEquipment(this.ObjectContext);
//                    cmrItemEquipment.CMRActionRequest = this;
//                    cmrItemEquipment.ItemName = content.Name;
//                    cmrItemEquipment.Amount = 1;
//                }
//            }
        }
        
        public bool IsUnderGuaranty()
        {
            DateTime GuarantyEndDate = new DateTime();
            GuarantyEndDate = FixedAssetMaterialDefinition.GuarantyEndDate.Value;
            if (DateTime.Compare(GuarantyEndDate, DateTime.Now) > 0)
                return true;
            else
                return false;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CMRAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CMRAction.States.New && toState == CMRAction.States.Cancelled)
                PreTransition_New2Cancelled();
        }

    }
}