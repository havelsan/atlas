
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
    /// Onarım [Stok Numaralı]
    /// </summary>
    public  partial class MaterialRepair : Repair
    {
        public partial class GetMaterialRepairQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            try
            {
              if(TransDef !=null)
               {
                if (TransDef.FromStateDefID == MaterialRepair.States.FirmRepair || TransDef.FromStateDefID == MaterialRepair.States.GuarantyRepair || TransDef.FromStateDefID == MaterialRepair.States.HEK || TransDef.FromStateDefID == MaterialRepair.States.Repair)
                {
                    StateIDBeforeLastControl = TransDef.FromStateDefID.ToString();
                }
              }
            }
            catch
            { }
#endregion PreUpdate
        }

        protected void PreTransition_LastControl2Delivery()
        {
            // From State : LastControl   To State : Delivery
#region PreTransition_LastControl2Delivery
            
            if(EndDate != null)
            {
               // int diffResult = ((this.EndDate) - (this.StartDate)).value.TotalDays;
                TimeSpan diffResult = ((DateTime)StartDate) - (DateTime)(EndDate);

                if ( diffResult.Days > 0  )
                {
                  throw new TTException(TTUtils.CultureService.GetText("M25287", "Bitiş tarihi başlangıç tarihinden sonra olmalıdır!"));
                }
            }
#endregion PreTransition_LastControl2Delivery
        }

        protected void PreTransition_Repair2LastControl()
        {
            // From State : Repair   To State : LastControl
#region PreTransition_Repair2LastControl
            
            
            foreach (UsedConsumedMaterail usedConsumedMaterail in UsedConsumedMaterails)
            {
                if (usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.New)
                {
                    if (usedConsumedMaterail.SuppliedAmount == usedConsumedMaterail.Amount || usedConsumedMaterail.SuppliedAmount > usedConsumedMaterail.Amount)
                    {
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                    }
                    else
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(965, new string[] { usedConsumedMaterail.Material.Name.ToString()}));
                    }
                }
            }

#endregion PreTransition_Repair2LastControl
        }

        protected void PreTransition_Repair2HEK()
        {
            // From State : Repair   To State : HEK
#region PreTransition_Repair2HEK
            
            foreach (UsedConsumedMaterail usedConsumedMaterail in UsedConsumedMaterails)
            {
                if (usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.New)
                {
                    if (usedConsumedMaterail.SuppliedAmount == usedConsumedMaterail.Amount || usedConsumedMaterail.SuppliedAmount > usedConsumedMaterail.Amount)
                    {
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                        
                        NeededMaterials neededMaterials = new NeededMaterials(ObjectContext);
                        neededMaterials.MaterialName = usedConsumedMaterail.Material.Name;
                        neededMaterials.MaterialAmount = usedConsumedMaterail.Amount;
                        neededMaterials.PartNumber = "-";
                        neededMaterials.MaterialUnitPrice = usedConsumedMaterail.UnitPrice;
                        if(usedConsumedMaterail.UnitPrice != null)
                            neededMaterials.MaterialTotalPrice = (double)((Currency)usedConsumedMaterail.UnitPrice * usedConsumedMaterail.Amount);
                        else
                            neededMaterials.MaterialTotalPrice = 0 ;
                        neededMaterials.UsedConsumedMaterail = usedConsumedMaterail;
                        neededMaterials.Repair = this;
                    }
                    else
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
                    }
                }
            }

#endregion PreTransition_Repair2HEK
        }

        protected void PostTransition_Delivery2Comleted()
        {
            // From State : Delivery   To State : Comleted
#region PostTransition_Delivery2Comleted
            
            if(RequestCMRAction.CurrentStateDefID != CMRActionRequest.States.Cancelled)
                RequestCMRAction.CurrentStateDefID = CMRActionRequest.States.Comleted;

#endregion PostTransition_Delivery2Comleted
        }

        protected void PreTransition_HEK2LastControl()
        {
            // From State : HEK   To State : LastControl
#region PreTransition_HEK2LastControl
            
            
            if(HEKMaterialAmount > FixedAssetMaterialAmount)
                throw new TTException ("HEK Malzeme Sayısı , Malzeme sayısından fazla olamaz");

#endregion PreTransition_HEK2LastControl
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaterialRepair).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaterialRepair.States.LastControl && toState == MaterialRepair.States.Delivery)
                PreTransition_LastControl2Delivery();
            else if (fromState == MaterialRepair.States.Repair && toState == MaterialRepair.States.LastControl)
                PreTransition_Repair2LastControl();
            else if (fromState == MaterialRepair.States.Repair && toState == MaterialRepair.States.HEK)
                PreTransition_Repair2HEK();
            else if (fromState == MaterialRepair.States.HEK && toState == MaterialRepair.States.LastControl)
                PreTransition_HEK2LastControl();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaterialRepair).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaterialRepair.States.Delivery && toState == MaterialRepair.States.Comleted)
                PostTransition_Delivery2Comleted();
        }

    }
}