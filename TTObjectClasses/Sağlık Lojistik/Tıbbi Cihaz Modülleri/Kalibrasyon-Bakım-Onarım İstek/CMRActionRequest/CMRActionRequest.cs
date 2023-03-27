
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
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
    public  partial class CMRActionRequest : CMRAction
    {
        public partial class GetWorkOrdersStateReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class CMRActionHospitalReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetUserMaintenanceReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetNotCompletedFaultReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFaultCountsAndDetailsReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetStatusOfChiefMaterial_Class : TTReportNqlObject 
        {
        }

        public partial class GetUnitMaintenanceReportQueryNew_Class : TTReportNqlObject 
        {
        }

        public partial class CMRActionHospitalReportQueryByRepair_Class : TTReportNqlObject 
        {
        }

        public partial class CMRActionHospitalReportQueryByCalibration_Class : TTReportNqlObject 
        {
        }

        public partial class GetPerformanceOfPersonnelReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetOnarimiDevamEdenCihazlar_Class : TTReportNqlObject 
        {
        }

        public partial class GetPersonnelPerformanceCompareReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetPersonnelPerformanceCompareRQ2_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            
            
            
            
            base.PreInsert();
            if(CMRActionRequestUpdate != true)
            {
                 if (FixedAssetType == FixedAssetTypeEnum.SerialNO)
                 {
                     if(FixedAssetMaterialDefinition.CMRStatus !=null)
                     {
                        if (FixedAssetMaterialDefinition.CMRStatus != FixedAssetCMRStatusEnum.InUse)
                        {
                            String message = SystemMessage.GetMessage(2);
                                throw new TTUtils.TTException(message);
                        }
                     }
                 }
            }

#endregion PreInsert
        }

        protected void PreTransition_Request2ClinicApproval()
        {
            // From State : Request   To State : ClinicApproval
#region PreTransition_Request2ClinicApproval
            
            
            

            if (FixedAssetType == FixedAssetTypeEnum.StockNO)
            {
                FixedAssetMaterialDesc = FaultDescription;
                double inheld = FixedAssetDefinition.StockInheld(SenderSection.Store);
                if (FixedAssetMaterialAmount > inheld)
                {
                    throw new TTException(SystemMessage.GetMessageV2(939,inheld.ToString()));
                }
            }

#endregion PreTransition_Request2ClinicApproval
        }

        protected void PostTransition_Request2ClinicApproval()
        {
            // From State : Request   To State : ClinicApproval
#region PostTransition_Request2ClinicApproval
            
            
            
            
            OwnerMilitaryUnit = Common.GetCurrentMilitaryUnit(ObjectContext);
            if(OwnerMilitaryUnit.CMRRelationsDefinition.Count>0)
            {
                CMRRelationsDefinition crd = (CMRRelationsDefinition)OwnerMilitaryUnit.CMRRelationsDefinition[0];
                UpperStage = crd.MaintenanceRepairStage;
                Stage = crd.CalibrationStage;
            }

            if (FixedAssetMaterialDefinition != null)
            {
                bool inGuaranty = false ;
                DateTime GuarantyEndDate = new DateTime();
                if(FixedAssetMaterialDefinition.GuarantyEndDate.HasValue)
                {
                    GuarantyEndDate =  FixedAssetMaterialDefinition.GuarantyEndDate.Value;
                    if (DateTime.Compare(GuarantyEndDate, DateTime.Now) > 0)
                    {
                        inGuaranty = true;
                    }
                }
                else
                {
                    inGuaranty = false;
                }
                if (inGuaranty)
                {
                    if (RequestType == RequestTypeEnum.Maintenance)
                    {
                        string message = SystemMessage.GetMessage(3);
                        throw new TTException(message);
                    }
                }
            }
            
            string txtSeq = RequestNoSeq.Value.ToString();
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
            RequestNo = Common.RecTime().Year.ToString()+"-"+ txtSeq.ToString();

#endregion PostTransition_Request2ClinicApproval
        }

        protected void PostTransition_Status2Comleted()
        {
            // From State : Status   To State : Comleted
#region PostTransition_Status2Comleted
            
            
            if(FixedAssetMaterialDefinition != null)
            {
                FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InUse;
            }

#endregion PostTransition_Status2Comleted
        }

        protected void PreTransition_Status2Cancelled()
        {
            // From State : Status   To State : Cancelled
#region PreTransition_Status2Cancelled
            
            
            if(ForkCMRAction.Count > 0)
            {
                CMRAction forkCMRAction = ForkCMRAction[0];
                if (forkCMRAction is Repair)
                {
                    if (forkCMRAction.CurrentStateDefID == Repair.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(944));
                }
                if (forkCMRAction is MaterialRepair)
                {
                    if (forkCMRAction.CurrentStateDefID == MaterialRepair.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(944));
                }
                if (forkCMRAction is Calibration)
                {
                    if (forkCMRAction.CurrentStateDefID == Calibration.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(945));
                }
                if (forkCMRAction is Maintenance)
                {
                    if (forkCMRAction.CurrentStateDefID == Maintenance.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(946));
                }
                if (forkCMRAction is MaterialMaintenance)
                {
                    if (forkCMRAction.CurrentStateDefID == MaterialMaintenance.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(946));
                }
            }

#endregion PreTransition_Status2Cancelled
        }

        protected void PreTransition_StageApproval2Cancelled()
        {
            // From State : StageApproval   To State : Cancelled
#region PreTransition_StageApproval2Cancelled
            
            
            if(ForkCMRAction.Count > 0)
            {
                CMRAction forkCMRAction = ForkCMRAction[0];
                if (forkCMRAction is Repair)
                {
                    if (forkCMRAction.CurrentStateDefID == Repair.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(944));
                }
                if (forkCMRAction is MaterialRepair)
                {
                    if (forkCMRAction.CurrentStateDefID == MaterialRepair.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(944));
                }
                if (forkCMRAction is Calibration)
                {
                    if (forkCMRAction.CurrentStateDefID == Calibration.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(945));
                }
                if (forkCMRAction is Maintenance)
                {
                    if (forkCMRAction.CurrentStateDefID == Maintenance.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(946));
                }
                if (forkCMRAction is MaterialMaintenance)
                {
                    if (forkCMRAction.CurrentStateDefID == MaterialMaintenance.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(946));
                }
            }

#endregion PreTransition_StageApproval2Cancelled
        }

        protected void PostTransition_PreControl2Status()
        {
            // From State : PreControl   To State : Status
#region PostTransition_PreControl2Status
            


            if (FixedAssetType == FixedAssetTypeEnum.SerialNO)
            {
                CreateCMRAction(true);
            }
            else
            {
                CreateCMRAction(false);
            }

#endregion PostTransition_PreControl2Status
        }

        protected void UndoTransition_PreControl2Status(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PreControl   To State : Status
#region UndoTransition_PreControl2Status
            
            throw new TTException(SystemMessage.GetMessage(947));
#endregion UndoTransition_PreControl2Status
        }

        protected void PreTransition_GuarantyRepairApproval2Cancelled()
        {
            // From State : GuarantyRepairApproval   To State : Cancelled
#region PreTransition_GuarantyRepairApproval2Cancelled
            
            
            if(ForkCMRAction.Count > 0)
            {
                CMRAction forkCMRAction = ForkCMRAction[0];
                if (forkCMRAction is Repair)
                {
                    if (forkCMRAction.CurrentStateDefID == Repair.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(944));
                }
                if (forkCMRAction is MaterialRepair)
                {
                    if (forkCMRAction.CurrentStateDefID == MaterialRepair.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(944));
                }
                if (forkCMRAction is Calibration)
                {
                    if (forkCMRAction.CurrentStateDefID == Calibration.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(945));
                }
                if (forkCMRAction is Maintenance)
                {
                    if (forkCMRAction.CurrentStateDefID == Maintenance.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(946));
                }
                if (forkCMRAction is MaterialMaintenance)
                {
                    if (forkCMRAction.CurrentStateDefID == MaterialMaintenance.States.Cancelled)
                        throw new TTException(SystemMessage.GetMessage(946));
                }
            }

#endregion PreTransition_GuarantyRepairApproval2Cancelled
        }

        protected void PostTransition_GuarantyRepairApproval2Comleted()
        {
            // From State : GuarantyRepairApproval   To State : Comleted
#region PostTransition_GuarantyRepairApproval2Comleted
            
            if(GuarantyPenalTime != null)
            {
                DateTime newGuarantyEndDate = ((DateTime)(FixedAssetMaterialDefinition.GuarantyEndDate)).AddDays((double)GuarantyPenalTime);
                FixedAssetMaterialDefinition.GuarantyEndDate = newGuarantyEndDate ;
            }

#endregion PostTransition_GuarantyRepairApproval2Comleted
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                if (RequestNoSeq.Value == null)
                {
                    RequestNoSeq.GetNextValue(ObjectDef.ID.ToString(),Common.RecTime().Year) ;
                    if (RequestNo == null)
                        RequestNo = Common.RecTime().Year.ToString()+ "-" + "####";
                }
            }
        }
        
        /// <summary>
        /// Cihazla beraber gidecek malzemeleri doldurur.
        /// </summary>
        public void FillEquipments()
        {
            if (FixedAssetMaterialDefinition != null)
            {
                CMR_ItemEquipments.Clear();
                foreach(FixedAssetMaterialContent content in FixedAssetMaterialDefinition.Contents)
                {
                    CMR_ItemEquipment cmrItemEquipment = new CMR_ItemEquipment(ObjectContext);
                    cmrItemEquipment.CMRActionRequest = this;
                    cmrItemEquipment.ItemName = content.Name;
                    cmrItemEquipment.Amount = content.ContentAmount;
                    cmrItemEquipment.DistributionType = content.DistributionType;
                }
            }
        }

        /// <summary>
        /// Kullanıcı Bakım Parametrelerini doldurur.
        /// </summary>
        public void FiilUserParameter()
        {
            if (FixedAssetMaterialDefinition.FixedAssetDefinition != null )
            {
                if (FixedAssetMaterialDefinition.FixedAssetDefinition.UserLevelMaintParameters.Count > 0)
                {
                    UserMaintenances.Clear();
                    if (FixedAssetMaterialDefinition.FixedAssetDefinition !=null)
                    {
                        foreach (UserLevelMaintParameter userLevelMaintParameter in FixedAssetMaterialDefinition.FixedAssetDefinition.UserLevelMaintParameters)
                        {
                            UserMaintenance userMaintenance = UserMaintenances.AddNew();
                            userMaintenance.Parameter = userLevelMaintParameter.UserParameter;
                        }
                    }
                }
                else
                {
                    // Parametre Yapılacak şimdilik kapatıldı. SS
                    //string message = SystemMessage.GetMessage(4);
                    //throw new TTUtils.TTException(message);
                }
            }
        }
        
        /// <summary>
        /// Garanti kapsamında olup olmadığını dönderir.
        /// </summary>
        /// <returns></returns>
        public bool IsUnderGuaranty()
        {
            if(FixedAssetMaterialDefinition.GuarantyEndDate.HasValue)
            {
                DateTime GuarantyEndDate = new DateTime();
                GuarantyEndDate = FixedAssetMaterialDefinition.GuarantyEndDate.Value;
                if (DateTime.Compare(GuarantyEndDate, DateTime.Now) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Seçilen tipe göre Bakım / Onarım / Kalibrasyon işlemi yaratır.
        /// </summary>

      
        public void CreateCMRAction(bool SerialNumber)
        {
            TTObjectContext context = ObjectContext;
            if (CMRActionRequestUpdate != true)
            {
                if (SerialNumber)
                {

                    switch (RequestType.Value)
                    {
                        case RequestTypeEnum.Calibration:
                            Calibration calibration = new Calibration(context);
                            calibration.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
                            calibration.DelivererUser = DelivererUser;
                            calibration.Description = Description;
                            calibration.DeviceUser = DeviceUser;
                            calibration.EndDate = EndDate;
                            calibration.OwnerMilitaryUnit = OwnerMilitaryUnit;
                            calibration.RequestDate = RequestDate;
                            calibration.RequestNo = RequestNo;
                            calibration.ResponsibleUser = ResponsibleUser;
                            calibration.ResponsibleWorkShopUser = ResponsibleWorkShopUser;
                            calibration.Section = Section;
                            calibration.SenderAccountancy = SenderAccountancy;
                            calibration.SenderSection = SenderSection;
                            calibration.Stage = Stage;
                            calibration.StartDate = StartDate;
                            calibration.WorkShop = WorkShop;
                            calibration.CurrentStateDefID = Calibration.States.Calibration;
                            calibration.RequestCMRAction = this;
                            calibration.WorkListDate = DateTime.Now.Date;
                            foreach (UserMaintenance parameter in UserMaintenances)
                            {
                                UserMaintenance userMaintenance = calibration.UserMaintenances.AddNew();
                                userMaintenance.Parameter = parameter.Parameter;
                                userMaintenance.Description = parameter.Description;
                                userMaintenance.Checked = parameter.Checked;
                            }
                            foreach (UnitLevelMaintParameter unitLevelMaintParameter in FixedAssetMaterialDefinition.FixedAssetDefinition.UnitLevelMaintParameters)
                            {
                                UnitMaintenance unitMaintenance = calibration.UnitMaintenances.AddNew();
                                unitMaintenance.Parameter = unitLevelMaintParameter.UnitParameter;
                            }

                            foreach (CMR_ItemEquipment itemEquipment in CMR_ItemEquipments)
                            {
                                Calibration_ItemEquipment cItemEquipment = new Calibration_ItemEquipment(context);
                                cItemEquipment.Amount = itemEquipment.Amount;
                                cItemEquipment.ItemName = itemEquipment.ItemName;
                                cItemEquipment.Calibration = calibration;
                                cItemEquipment.DistributionType = itemEquipment.DistributionType;
                            }
                            FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InCalibrationProgress;
                            ForkCMRAction.Add(calibration);
                            break;
                        case RequestTypeEnum.Maintenance:
                            Maintenance maintenance = new Maintenance(context);
                            maintenance.DelivererUser = DelivererUser;
                            maintenance.Description = Description;
                            maintenance.DeviceUser = DeviceUser;
                            maintenance.EndDate = EndDate;
                            maintenance.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
                            maintenance.OwnerMilitaryUnit = OwnerMilitaryUnit;
                            maintenance.RequestDate = RequestDate;
                            maintenance.RequestNo = RequestNo;
                            maintenance.ResponsibleUser = ResponsibleUser;
                            maintenance.ResponsibleWorkShopUser = ResponsibleWorkShopUser;
                            maintenance.Result = Result;
                            maintenance.Section = Section;
                            maintenance.SenderAccountancy = SenderAccountancy;
                            maintenance.SenderSection = SenderSection;
                            maintenance.Stage = Stage;
                            maintenance.StartDate = StartDate;
                            maintenance.WorkShop = WorkShop;
                            maintenance.CurrentStateDefID = Maintenance.States.Maintenance;
                            maintenance.RequestCMRAction = this;
                            maintenance.WorkListDate = DateTime.Now.Date;
                            foreach (UserMaintenance parameter in UserMaintenances)
                            {
                                UserMaintenance userMaintenance = maintenance.UserMaintenances.AddNew();
                                userMaintenance.Parameter = parameter.Parameter;
                                userMaintenance.Description = parameter.Description;
                                userMaintenance.Checked = parameter.Checked;
                            }
                            foreach (UnitLevelMaintParameter unitLevelMaintParameter in FixedAssetMaterialDefinition.FixedAssetDefinition.UnitLevelMaintParameters)
                            {
                                UnitMaintenance unitMaintenance = maintenance.UnitMaintenances.AddNew();
                                unitMaintenance.Parameter = unitLevelMaintParameter.UnitParameter;
                            }
                            ForkCMRAction.Add(maintenance);
                            FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InMaintenanceOrderProgress;
                            break;
                        case RequestTypeEnum.Repair:
                            Repair repair = new Repair(context);
                            repair.DelivererUser = DelivererUser;
                            repair.Description = Description;
                            repair.DeviceUser = DeviceUser;
                            repair.EndDate = EndDate;
                            repair.FaultDescription = FaultDescription;
                            repair.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
                            repair.OwnerMilitaryUnit = OwnerMilitaryUnit;
                            repair.RepairPlace = RepairPlace;
                            repair.RequestDate = RequestDate;
                            repair.RequestNo = RequestNo;
                            repair.ResponsibleUser = ResponsibleUser;
                            repair.ResponsibleWorkShopUser = ResponsibleWorkShopUser;
                            repair.Result = Result;
                            repair.PreControlNotes = PreControlNotes;
                            repair.Section = Section;
                            repair.SenderAccountancy = SenderAccountancy;
                            repair.SenderSection = SenderSection;
                            repair.Stage = Stage;
                            repair.StartDate = StartDate;
                            repair.UserTel = UserTel;
                            repair.WorkShop = WorkShop;
                            repair.UpperStage = UpperStage;
                            repair.CurrentStateDefID = Repair.States.Repair;
                            repair.RequestCMRAction = this;
                            repair.WorkListDate = DateTime.Now.Date;
                            foreach (UserMaintenance parameter in UserMaintenances)
                            {
                                UserMaintenance userMaintenance = repair.UserMaintenances.AddNew();
                                userMaintenance.Parameter = parameter.Parameter;
                                userMaintenance.Description = parameter.Description;
                                userMaintenance.Checked = parameter.Checked;
                            }
                            foreach (UnitLevelMaintParameter unitLevelMaintParameter in FixedAssetMaterialDefinition.FixedAssetDefinition.UnitLevelMaintParameters)
                            {
                                UnitMaintenance unitMaintenance = repair.UnitMaintenances.AddNew();
                                unitMaintenance.Parameter = unitLevelMaintParameter.UnitParameter;
                            }
                            foreach (CMR_ItemEquipment itemEquipment in CMR_ItemEquipments)
                            {
                                Repair_ItemEquipment rItemEquipment = new Repair_ItemEquipment(context);
                                rItemEquipment.Amount = itemEquipment.Amount;
                                rItemEquipment.ItemName = itemEquipment.ItemName;
                                rItemEquipment.DistributionType = itemEquipment.DistributionType;
                                rItemEquipment.Comments = itemEquipment.Comments;
                                rItemEquipment.IsChanged = itemEquipment.IsChanged;
                                rItemEquipment.IsDamaged = itemEquipment.IsDamaged;
                                rItemEquipment.IsMissing = itemEquipment.IsMissing;
                                rItemEquipment.IsNormal = itemEquipment.IsNormal;
                                rItemEquipment.Repair = repair;
                            }
                            ForkCMRAction.Add(repair);
                            FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InRepairProgress;
                            break;
                        default:
                            throw new TTUtils.TTException(SystemMessage.GetMessage(940));
                            //break;
                    }
                }
                else
                {
                    switch (RequestType.Value)
                    {
                        case RequestTypeEnum.Calibration:
                            MaterialCalibration mCalibration = new MaterialCalibration(context);
                            mCalibration.DelivererUser = DelivererUser;
                            mCalibration.Description = Description;
                            mCalibration.DeviceUser = DeviceUser;
                            mCalibration.EndDate = EndDate;
                            mCalibration.FixedAssetDefinition = FixedAssetDefinition;
                            mCalibration.FixedAssetMaterialAmount = FixedAssetMaterialAmount;
                            mCalibration.FixedAssetMaterialDesc = FixedAssetMaterialDesc;
                            mCalibration.OwnerMilitaryUnit = OwnerMilitaryUnit;
                            mCalibration.RequestDate = RequestDate;
                            mCalibration.RequestNo = RequestNo;
                            mCalibration.ResponsibleUser = ResponsibleUser;
                            mCalibration.ResponsibleWorkShopUser = ResponsibleWorkShopUser;
                            mCalibration.Result = Result;
                            mCalibration.Section = Section;
                            mCalibration.SenderAccountancy = SenderAccountancy;
                            mCalibration.SenderSection = SenderSection;
                            mCalibration.Stage = Stage;
                            mCalibration.StartDate = StartDate;
                            mCalibration.WorkShop = WorkShop;
                            mCalibration.CurrentStateDefID = MaterialCalibration.States.Calibration;
                            mCalibration.RequestCMRAction = this;
                            mCalibration.WorkListDate = DateTime.Now.Date;

                            foreach (UserMaintenance parameter in UserMaintenances)
                            {
                                UserMaintenance userMaintenance =  mCalibration.UserMaintenances.AddNew();
                                userMaintenance.Parameter = parameter.Parameter;
                                userMaintenance.Description = parameter.Description;
                                userMaintenance.Checked = parameter.Checked;
                            }
                            foreach (UnitLevelMaintParameter unitLevelMaintParameter in FixedAssetDefinition.UnitLevelMaintParameters)
                            {
                                UnitMaintenance unitMaintenance = mCalibration.UnitMaintenances.AddNew();
                                unitMaintenance.Parameter = unitLevelMaintParameter.UnitParameter;
                            }

                            foreach (CMR_ItemEquipment itemEquipment in CMR_ItemEquipments)
                            {
                                Calibration_ItemEquipment cItemEquipment = new Calibration_ItemEquipment(context);
                                cItemEquipment.Amount = itemEquipment.Amount;
                                cItemEquipment.ItemName = itemEquipment.ItemName;
                                cItemEquipment.Calibration = mCalibration;
                                cItemEquipment.DistributionType = itemEquipment.DistributionType;
                            }
                            ForkCMRAction.Add(mCalibration);
                            // throw new TTUtils.TTException(SystemMessage.GetMessage(941));
                            break;
                        case RequestTypeEnum.Maintenance:
                            MaterialMaintenance mMaintenance = new MaterialMaintenance(context);
                            mMaintenance.DelivererUser = DelivererUser;
                            mMaintenance.Description = Description;
                            mMaintenance.DeviceUser = DeviceUser;
                            mMaintenance.EndDate = EndDate;
                            mMaintenance.FixedAssetDefinition = FixedAssetDefinition;
                            mMaintenance.FixedAssetMaterialAmount = FixedAssetMaterialAmount;
                            mMaintenance.FixedAssetMaterialDesc = FixedAssetMaterialDesc;
                            mMaintenance.OwnerMilitaryUnit = OwnerMilitaryUnit;
                            mMaintenance.RequestDate = RequestDate;
                            mMaintenance.RequestNo = RequestNo;
                            mMaintenance.ResponsibleUser = ResponsibleUser;
                            mMaintenance.ResponsibleWorkShopUser = ResponsibleWorkShopUser;
                            mMaintenance.Result = Result;
                            mMaintenance.Section = Section;
                            mMaintenance.SenderAccountancy = SenderAccountancy;
                            mMaintenance.SenderSection = SenderSection;
                            mMaintenance.Stage = Stage;
                            mMaintenance.StartDate = StartDate;
                            mMaintenance.WorkShop = WorkShop;
                            mMaintenance.CurrentStateDefID = MaterialMaintenance.States.Maintenance;
                            mMaintenance.RequestCMRAction = this;
                            mMaintenance.WorkListDate = DateTime.Now.Date;
                            foreach (UserMaintenance parameter in UserMaintenances)
                            {
                                UserMaintenance userMaintenance = mMaintenance.UserMaintenances.AddNew();
                                userMaintenance.Parameter = parameter.Parameter;
                                userMaintenance.Description = parameter.Description;
                                userMaintenance.Checked = parameter.Checked;
                            }
                            foreach (UnitLevelMaintParameter unitLevelMaintParameter in FixedAssetDefinition.UnitLevelMaintParameters)
                            {
                                UnitMaintenance unitMaintenance = mMaintenance.UnitMaintenances.AddNew();
                                unitMaintenance.Parameter = unitLevelMaintParameter.UnitParameter;
                            }
                            ForkCMRAction.Add(mMaintenance);
                            break;
                        case RequestTypeEnum.Repair:
                            MaterialRepair mRepair = new MaterialRepair(context);
                            mRepair.DelivererUser = DelivererUser;
                            mRepair.Description = Description;
                            mRepair.DeviceUser = DeviceUser;
                            mRepair.EndDate = EndDate;
                            mRepair.FaultDescription = FaultDescription;
                            mRepair.FixedAssetDefinition = FixedAssetDefinition;
                            mRepair.FixedAssetMaterialAmount = FixedAssetMaterialAmount;
                            mRepair.FixedAssetMaterialDesc = FixedAssetMaterialDesc;
                            mRepair.OwnerMilitaryUnit = OwnerMilitaryUnit;
                            mRepair.RepairPlace = RepairPlace;
                            mRepair.RequestDate = RequestDate;
                            mRepair.RequestNo = RequestNo;
                            mRepair.ResponsibleUser = ResponsibleUser;
                            mRepair.ResponsibleWorkShopUser = ResponsibleWorkShopUser;
                            mRepair.Result = Result;
                            mRepair.PreControlNotes = PreControlNotes;
                            mRepair.Section = Section;
                            mRepair.SenderAccountancy = SenderAccountancy;
                            mRepair.SenderSection = SenderSection;
                            mRepair.Stage = Stage;
                            mRepair.StartDate = StartDate;
                            mRepair.UserTel = UserTel;
                            mRepair.WorkShop = WorkShop;
                            mRepair.UpperStage = UpperStage;
                            mRepair.CurrentStateDefID = MaterialRepair.States.Repair;
                            mRepair.RequestCMRAction = this;
                            mRepair.WorkListDate = DateTime.Now.Date;
                            foreach (UserMaintenance parameter in UserMaintenances)
                            {
                                UserMaintenance userMaintenance = mRepair.UserMaintenances.AddNew();
                                userMaintenance.Parameter = parameter.Parameter;
                                userMaintenance.Description = parameter.Description;
                                userMaintenance.Checked = parameter.Checked;
                            }
                            foreach (UnitLevelMaintParameter unitLevelMaintParameter in FixedAssetDefinition.UnitLevelMaintParameters)
                            {
                                UnitMaintenance unitMaintenance = mRepair.UnitMaintenances.AddNew();
                                unitMaintenance.Parameter = unitLevelMaintParameter.UnitParameter;
                            }
                            foreach (CMR_ItemEquipment itemEquipment in CMR_ItemEquipments)
                            {
                                Repair_ItemEquipment rItemEquipment = new Repair_ItemEquipment(context);
                                rItemEquipment.Amount = itemEquipment.Amount;
                                rItemEquipment.ItemName = itemEquipment.ItemName;
                                rItemEquipment.DistributionType = itemEquipment.DistributionType;
                                rItemEquipment.Comments = itemEquipment.Comments;
                                rItemEquipment.IsChanged = itemEquipment.IsChanged;
                                rItemEquipment.IsDamaged = itemEquipment.IsDamaged;
                                rItemEquipment.IsMissing = itemEquipment.IsMissing;
                                rItemEquipment.IsNormal = itemEquipment.IsNormal;
                                rItemEquipment.Repair = mRepair;
                            }
                            ForkCMRAction.Add(mRepair);
                            break;
                        default:
                            throw new TTUtils.TTException(SystemMessage.GetMessage(940));
                            //break;
                    }
                }
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CMRActionRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CMRActionRequest.States.Request && toState == CMRActionRequest.States.ClinicApproval)
                PreTransition_Request2ClinicApproval();
            else if (fromState == CMRActionRequest.States.Status && toState == CMRActionRequest.States.Cancelled)
                PreTransition_Status2Cancelled();
            else if (fromState == CMRActionRequest.States.StageApproval && toState == CMRActionRequest.States.Cancelled)
                PreTransition_StageApproval2Cancelled();
            else if (fromState == CMRActionRequest.States.GuarantyRepairApproval && toState == CMRActionRequest.States.Cancelled)
                PreTransition_GuarantyRepairApproval2Cancelled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CMRActionRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CMRActionRequest.States.Request && toState == CMRActionRequest.States.ClinicApproval)
                PostTransition_Request2ClinicApproval();
            else if (fromState == CMRActionRequest.States.Status && toState == CMRActionRequest.States.Comleted)
                PostTransition_Status2Comleted();
            else if (fromState == CMRActionRequest.States.PreControl && toState == CMRActionRequest.States.Status)
                PostTransition_PreControl2Status();
            else if (fromState == CMRActionRequest.States.GuarantyRepairApproval && toState == CMRActionRequest.States.Comleted)
                PostTransition_GuarantyRepairApproval2Comleted();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CMRActionRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CMRActionRequest.States.PreControl && toState == CMRActionRequest.States.Status)
                UndoTransition_PreControl2Status(transDef);
        }

    }
}