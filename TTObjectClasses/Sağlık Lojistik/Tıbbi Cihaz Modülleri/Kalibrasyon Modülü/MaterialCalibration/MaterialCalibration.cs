
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
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
    public  partial class MaterialCalibration : Calibration
    {
        protected override void PostInsert()
        {
#region PostInsert
            
            
            base.PostInsert();
            if (RequestCMRAction == null)
            {
                string txtSeq = RequestNoSeq.Value.ToString();
                string reTxt = RequestNo.ToString();
                if (txtSeq.Length == 1)
                {
                    txtSeq = "000" + txtSeq.ToString();
                }
                if (txtSeq.Length == 2)
                {
                    txtSeq = "00" + txtSeq.ToString();
                }
                if (txtSeq.Length == 3)
                {
                    txtSeq = "0" + txtSeq.ToString();
                }
                RequestNo = reTxt.Substring(0, 4).ToString() + "-" + txtSeq.ToString();
            }

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
             base.PostUpdate();
            if (CurrentStateDefID == MaterialCalibration.States.ForkNew)
            {
                WorkListDate = RequestDate;
            }
#endregion PostUpdate
        }

        protected void PreTransition_Calibration2ToRepair()
        {
            // From State : Calibration   To State : ToRepair
#region PreTransition_Calibration2ToRepair
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
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
                    }
                }
            }
#endregion PreTransition_Calibration2ToRepair
        }

        protected void PostTransition_Calibration2ToRepair()
        {
            // From State : Calibration   To State : ToRepair
#region PostTransition_Calibration2ToRepair
            
            MaterialRepair repair = new MaterialRepair(ObjectContext);
            repair.FixedAssetDefinition = FixedAssetDefinition;
            repair.DelivererUser = DelivererUser;
            repair.Description = Description;
            repair.DeviceUser = DeviceUser;
            repair.EndDate = EndDate;
            repair.FaultDescription = Description;
            repair.OwnerMilitaryUnit = OwnerMilitaryUnit;
            repair.RepairPlace = RepairPlaceEnum.StageRepair;
            repair.RequestDate = RequestDate;
            repair.RequestNo = ((CMRActionRequest)RequestCMRAction).RequestNo;
            repair.ResponsibleUser = ResponsibleUser;
            repair.ResponsibleWorkShopUser = ResponsibleWorkShopUser;
            repair.Result = Result;
            repair.Section = Section;
            repair.SenderAccountancy = SenderAccountancy;
            repair.SenderSection = SenderSection;
            repair.Stage = Stage;
            repair.StartDate = StartDate;
            repair.UserTel = ((CMRActionRequest)RequestCMRAction).UserTel;
            repair.WorkShop = WorkShop;
            //repair.UpperStage = this.UpperStage ;
            repair.CurrentStateDefID = Repair.States.PreControl;
            repair.WorkListDate = DateTime.Now.Date;
            repair.RequestCMRAction = this;
            if( repair.FixedAssetMaterialDefinition != null)
                repair.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;



            foreach (Calibration_ItemEquipment itemEquipment in Calibration_ItemEquipments)
            {
                Repair_ItemEquipment rItemEquipment = new Repair_ItemEquipment(ObjectContext);
                rItemEquipment.Amount = itemEquipment.Amount;
                rItemEquipment.ItemName = itemEquipment.ItemName;
                rItemEquipment.Repair = repair;
            }
#endregion PostTransition_Calibration2ToRepair
        }

        protected void PreTransition_Calibration2Completed()
        {
            // From State : Calibration   To State : Completed
#region PreTransition_Calibration2Completed
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
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
                    }
                }
            }
#endregion PreTransition_Calibration2Completed
        }

        protected void PostTransition_Calibration2Completed()
        {
            // From State : Calibration   To State : Completed
#region PostTransition_Calibration2Completed
            
            
            ReferToUpperLevel rul = new ReferToUpperLevel(ObjectContext);
            if(rul.FixedAssetMaterialDefinition != null)
                rul.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;

            rul.RequestNo = Common.RecTime().Year.ToString() + "-" + "####";
            rul.RequestDate = Common.RecTime();
            rul.CurrentStateDefID = ReferToUpperLevel.States.Registry;
            rul.Amount = 1;
            rul.BreakDown = Description ;
            ResHospital hospital = SystemParameter.GetHospital();
            rul.SenderAccountancy = hospital.Accountancies[0].Accountancy ;
            rul.OwnerMilitaryUnit = OwnerMilitaryUnit;
            rul.ToMilitaryUnit = OwnerMilitaryUnit.CMRRelationsDefinition[0].CalibrationStage.MilitaryUnit;
            rul.Stage = OwnerMilitaryUnit.CMRRelationsDefinition[0].CalibrationStage;
            rul.RepairObjectID = ObjectID.ToString();
            rul.ReferType = ReferTypeEnum.Calibration ;
            RULObjectID = rul.ObjectID.ToString();

            foreach (UserMaintenance parameter in UserMaintenances)
            {
                UserMaintenance userMaintenance = rul.UserMaintenances.AddNew();
                userMaintenance.Parameter = parameter.Parameter;
                userMaintenance.Description = parameter.Description;
            }
            foreach (UnitMaintenance parameter in UnitMaintenances)
            {
                UnitMaintenance unitMaintenance = rul.UnitMaintenances.AddNew();
                unitMaintenance.Parameter = parameter.Parameter;
                unitMaintenance.Description = parameter.Description;
            }
            
            foreach(Calibration_ItemEquipment cie in Calibration_ItemEquipments )
            {
                RUL_ItemEquipment rule = new RUL_ItemEquipment(ObjectContext);
                rule.Amount = cie.Amount;
                rule.ItemName = cie.ItemName;
                rule.DistributionType = cie.DistributionType;
                rule.CurrentStateDefID = cie.CurrentStateDefID;
                rule.ReferToUpperLevel = rul;
            }
#endregion PostTransition_Calibration2Completed
        }

        protected void PreTransition_Calibration2ChiefApproval()
        {
            // From State : Calibration   To State : ChiefApproval
#region PreTransition_Calibration2ChiefApproval
            if (CalibrationTests.Count == 0)
            {
                if(NotCalibration == false)
                {
                    string message = SystemMessage.GetMessage(75);
                    throw new TTUtils.TTException(message);
                }
            }
            if(FullCalibration == false && LimitedCalibration == false && NotCalibration == false)
            {
                string message = SystemMessage.GetMessage(76);
                throw new TTUtils.TTException (message);
            }
            if(NotCalibration == true)
            {
                
                if(NotCalibreReason1 == false && NotCalibreReason2 == false && NotCalibreReason3 == false && NotCalibreReason4 == false && NotCalibreReason5 == false)
                {
                    string message = SystemMessage.GetMessage(77);
                    throw new TTUtils.TTException (message);
                }
            }
            
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
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
                    }
                }
            }
#endregion PreTransition_Calibration2ChiefApproval
        }

        protected void PostTransition_Calibration2ChiefApproval()
        {
            // From State : Calibration   To State : ChiefApproval
#region PostTransition_Calibration2ChiefApproval
            EndDate = Common.RecTime();
#endregion PostTransition_Calibration2ChiefApproval
        }

        protected void PreTransition_Calibration2FirmCalibration()
        {
            // From State : Calibration   To State : FirmCalibration
#region PreTransition_Calibration2FirmCalibration
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
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
                    }
                }
            }
#endregion PreTransition_Calibration2FirmCalibration
        }

        protected void PostTransition_ChiefApproval2Cancelled()
        {
            // From State : ChiefApproval   To State : Cancelled
#region PostTransition_ChiefApproval2Cancelled
            if (MaintenanceOrderObjectID != null)
            {
                Guid moGuid = new Guid(MaintenanceOrderObjectID.ToString());
                MaintenanceOrder maintenanceOrder = ((MaintenanceOrder)ObjectContext.GetObject(moGuid, "MAINTENANCEORDER"));
                maintenanceOrder.CurrentStateDefID = MaintenanceOrder.States.Cancelled;
            }
#endregion PostTransition_ChiefApproval2Cancelled
        }

        protected void PostTransition_ChiefApproval2Completed()
        {
            // From State : ChiefApproval   To State : Completed
#region PostTransition_ChiefApproval2Completed
            
            
            if(FixedAssetMaterialDefinition != null)
                FixedAssetMaterialDefinition.LastCalibrationDate = Common.RecTime();
            //Eğer bu CMRRequestAction ise böle yapılmalı.Diğer işlemler için kontrol konulmalı. SS.
            if(MaintenanceOrderObjectID == null )
            {
                if(RequestCMRAction != null)
                {
                    if (RequestCMRAction.ObjectID  != null)
                    {
                        if(RequestCMRAction.CurrentStateDefID != CMRActionRequest.States.Cancelled)
                            RequestCMRAction.CurrentStateDefID = CMRActionRequest.States.Comleted;

                    }
                }
            }
#endregion PostTransition_ChiefApproval2Completed
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
//             ITTObject ttObject = (ITTObject)this;
//            if(ttObject.IsNew)
//            {
//                if (this.RequestNoSeq.Value == null)
//                {
//                    this.RequestNoSeq.GetNextValue(this.ObjectDef.ID.ToString(),Common.RecTime().Year) ;
//                    this.RequestNo = Common.RecTime().Year.ToString()+ "-" + "####";
//                }
//            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaterialCalibration).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaterialCalibration.States.Calibration && toState == MaterialCalibration.States.ToRepair)
                PreTransition_Calibration2ToRepair();
            else if (fromState == MaterialCalibration.States.Calibration && toState == MaterialCalibration.States.Completed)
                PreTransition_Calibration2Completed();
            else if (fromState == MaterialCalibration.States.Calibration && toState == MaterialCalibration.States.ChiefApproval)
                PreTransition_Calibration2ChiefApproval();
            else if (fromState == MaterialCalibration.States.Calibration && toState == MaterialCalibration.States.FirmCalibration)
                PreTransition_Calibration2FirmCalibration();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaterialCalibration).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaterialCalibration.States.Calibration && toState == MaterialCalibration.States.ToRepair)
                PostTransition_Calibration2ToRepair();
            else if (fromState == MaterialCalibration.States.Calibration && toState == MaterialCalibration.States.Completed)
                PostTransition_Calibration2Completed();
            else if (fromState == MaterialCalibration.States.Calibration && toState == MaterialCalibration.States.ChiefApproval)
                PostTransition_Calibration2ChiefApproval();
            else if (fromState == MaterialCalibration.States.ChiefApproval && toState == MaterialCalibration.States.Cancelled)
                PostTransition_ChiefApproval2Cancelled();
            else if (fromState == MaterialCalibration.States.ChiefApproval && toState == MaterialCalibration.States.Completed)
                PostTransition_ChiefApproval2Completed();
        }

    }
}