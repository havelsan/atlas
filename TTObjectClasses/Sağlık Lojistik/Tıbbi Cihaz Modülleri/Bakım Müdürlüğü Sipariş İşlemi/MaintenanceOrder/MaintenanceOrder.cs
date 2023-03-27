
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
    /// Şipariş İşlemi
    /// </summary>
    public  partial class MaintenanceOrder : CMRAction
    {
        public partial class MaintenanceOrderReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetMaintenanceOrderObjectIDQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetProcessingDeviceAndHardwareReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetOrderChaseAndRegistryReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMaintenanceAndRepairRegistryReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetDirectMaterialCostsQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetDirectMaterialCostsForWorkStepQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetConsumedMaterialsQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMaintenanceOrderCostByObjectIDQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMaintenanceOrderByObjectIDQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetBrokenDownMaterialChaseReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMonthlyRepairReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetCompletedGraphicReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetHEKGraphicReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetWorkshopNameQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetOrderCommandReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMonthlyMaintenanceReportFromMaintenanceQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMaintenanceAndRepairRegistryByMSReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetHekReportMaintanenceOrder_Class : TTReportNqlObject 
        {
        }

        public partial class MaintenanceReportQuery_Class : TTReportNqlObject 
        {
        }

        
                    
        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected void PostTransition_OrderClose2Completed()
        {
            // From State : OrderClose   To State : Completed
#region PostTransition_OrderClose2Completed
            
            
            
            EndDate = Common.RecTime();
            if(RelatedReferToUpperLevel != null)
            {
                RelatedReferToUpperLevel.OrderStatus = OrderStatus;
                RelatedReferToUpperLevel.WorkListDate = Common.RecTime();
                RelatedReferToUpperLevel.CurrentStateDefID = ReferToUpperLevel.States.UpperLevelCompleted;
                RelatedReferToUpperLevel.EndDate = Common.RecTime();
            }


#endregion PostTransition_OrderClose2Completed
        }

        protected void PreTransition_Fieldwork2LastControl()
        {
            // From State : Fieldwork   To State : LastControl
#region PreTransition_Fieldwork2LastControl
            



            if (Supplier == null)
            {
                string message = SystemMessage.GetMessage(6);
                throw new TTUtils.TTException(message);
            }


#endregion PreTransition_Fieldwork2LastControl
        }

        protected void PreTransition_Calibration2Repair()
        {
            // From State : Calibration   To State : Repair
#region PreTransition_Calibration2Repair
            
            
            IList cal = Calibration.GetCalibrationStateByMaintenanceOrderObjectID(ObjectContext, ObjectID.ToString());
            if (cal.Count > 0)
            {
                Calibration clb = (Calibration)cal[0];
                if (clb.CurrentStateDefID != Calibration.States.Completed)
                {
                    string message = SystemMessage.GetMessage(5);
                    throw new TTUtils.TTException(message);
                }
            }
            else
            {
                throw new TTUtils.TTCallAdminException();
            }

#endregion PreTransition_Calibration2Repair
        }

        protected void PreTransition_Calibration2LastControl()
        {
            // From State : Calibration   To State : LastControl
#region PreTransition_Calibration2LastControl
            
            


            IList cal = Calibration.GetCalibrationStateByMaintenanceOrderObjectID(ObjectContext, ObjectID.ToString());
            if (cal.Count > 0)
            {
                Calibration clb = (Calibration)cal[0];
                if (clb.CurrentStateDefID != Calibration.States.Completed)
                {
                    string message = SystemMessage.GetMessage(5);
                    throw new TTUtils.TTException(message);
                }
            }
            else
            {
                throw new TTUtils.TTCallAdminException();
            }



#endregion PreTransition_Calibration2LastControl
        }

        protected void PostTransition_SupplyOfMaterial2Repair()
        {
            // From State : SupplyOfMaterial   To State : Repair
#region PostTransition_SupplyOfMaterial2Repair
            
            
            foreach(Maintenance_ConsumedMaterial material in Maintenance_ConsumedMaterials)
            {
                if(material.RequestAmount > material.SuppliedAmount)
                {
                    string message = SystemMessage.GetMessage(7);
                    throw new TTUtils.TTException(message);
                }
            }
#endregion PostTransition_SupplyOfMaterial2Repair
        }

        protected void PostTransition_SupplyOfMaterial2SpecialWork()
        {
            // From State : SupplyOfMaterial   To State : SpecialWork
#region PostTransition_SupplyOfMaterial2SpecialWork
            
            
            foreach(Maintenance_ConsumedMaterial material in Maintenance_ConsumedMaterials)
            {
                if(material.RequestAmount > material.SuppliedAmount)
                {
                    string message = SystemMessage.GetMessage(7);
                    throw new TTUtils.TTException(message);
                }
            }

#endregion PostTransition_SupplyOfMaterial2SpecialWork
        }

        protected void PostTransition_SupplyOfMaterial2Manufacturing()
        {
            // From State : SupplyOfMaterial   To State : Manufacturing
#region PostTransition_SupplyOfMaterial2Manufacturing
            
            
            foreach(Maintenance_ConsumedMaterial material in Maintenance_ConsumedMaterials)
            {
                if(material.RequestAmount > material.SuppliedAmount)
                {
                    string message = SystemMessage.GetMessage(7);
                    throw new TTUtils.TTException(message);
                }
            }

#endregion PostTransition_SupplyOfMaterial2Manufacturing
        }

        protected void PreTransition_Repair2HEK()
        {
            // From State : Repair   To State : HEK
#region PreTransition_Repair2HEK
            
            
            if(OrderStatus != OrderStatusEnum.HEKFromFromRepair && OrderStatus != OrderStatusEnum.HEKFromFromExamination)
            {
                throw new Exception(SystemMessage.GetMessage(1219));
            }
#endregion PreTransition_Repair2HEK
        }

        protected void PostTransition_Repair2HEK()
        {
            // From State : Repair   To State : HEK
#region PostTransition_Repair2HEK
            
            
            

            foreach (UsedConsumedMaterail usedConsumedMaterail in UsedConsumedMaterails)
            {
                if (usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.New)
                {
                    if(usedConsumedMaterail.SuppliedAmount == usedConsumedMaterail.Amount)
                    {
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                    }
                    else
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(965, new string[] {usedConsumedMaterail.Material.Name.ToString()}));
                    }
                }
            }



#endregion PostTransition_Repair2HEK
        }

        protected void PostTransition_Repair2Calibration()
        {
            // From State : Repair   To State : Calibration
#region PostTransition_Repair2Calibration
            
            
            

            Calibration ca = new Calibration(ObjectContext);
            ca.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
            ca.CurrentStateDefID = Calibration.States.ForkNew;
            ca.MaintenanceOrderObjectID = ObjectID.ToString();
            ca.RequestDate = Common.RecTime();
            ca.RequestNo = RequestNo ;
            ca.StartDate = Common.RecTime();
            ca.SenderSection = SenderSection ;
            ca.SenderAccountancy = SenderAccountancy;
            ca.Section = Section ;
            ca.WorkShop = WorkShop;
            //ca.ResponsibleUser = this.ResponsibleUser;
            //ca.Update();
            //ca.CurrentStateDefID = Calibration.States.Calibration;

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
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(965, new string[] { usedConsumedMaterail.Material.Name.ToString() }));
                    }
                }
            }



#endregion PostTransition_Repair2Calibration
        }

        protected void PostTransition_Repair2LastControl()
        {
            // From State : Repair   To State : LastControl
#region PostTransition_Repair2LastControl
            
            
            

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
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(965, new string[] {usedConsumedMaterail.Material.Name.ToString()}));
                    }
                }
            }



#endregion PostTransition_Repair2LastControl
        }

        protected void PreTransition_Repair2SupplyOfMaterial()
        {
            // From State : Repair   To State : SupplyOfMaterial
#region PreTransition_Repair2SupplyOfMaterial
            
            
            if(_Maintenance_ConsumedMaterials.Count == 0)
            {
                string message = SystemMessage.GetMessage(8);
                throw new TTUtils.TTException(message);
            }

#endregion PreTransition_Repair2SupplyOfMaterial
        }

        protected void PostTransition_Repair2SupplyApproval()
        {
            // From State : Repair   To State : SupplyApproval
#region PostTransition_Repair2SupplyApproval
            
            
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
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(965, new string[] {usedConsumedMaterail.Material.Name.ToString()}));
                    }
                }
            }

#endregion PostTransition_Repair2SupplyApproval
        }

        protected void PreTransition_SpecialWork2SupplyApproval()
        {
            // From State : SpecialWork   To State : SupplyApproval
#region PreTransition_SpecialWork2SupplyApproval
            
            
            if(RepairWorkLoad == null)
            {
                string message = SystemMessage.GetMessage(9);
                throw new TTUtils.TTException(message);
            }

#endregion PreTransition_SpecialWork2SupplyApproval
        }

        protected void PostTransition_SpecialWork2SupplyApproval()
        {
            // From State : SpecialWork   To State : SupplyApproval
#region PostTransition_SpecialWork2SupplyApproval
            
            
            
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
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(965, new string[] {usedConsumedMaterail.Material.Name.ToString()}));
                    }
                }
            }

#endregion PostTransition_SpecialWork2SupplyApproval
        }

        protected void PostTransition_NewOrder2Approval()
        {
            // From State : NewOrder   To State : Approval
#region PostTransition_NewOrder2Approval
            
            SenderSection = null ;
            if(RequestNoSeq.Value == null)
                RequestNoSeq.GetNextValue(MaintenanceOrderType.ObjectID.ToString(),DateTime.Now.Year);

#endregion PostTransition_NewOrder2Approval
        }

        protected void PostTransition_OrderApproval2DivisionChiefApproval()
        {
            // From State : OrderApproval   To State : DivisionChiefApproval
#region PostTransition_OrderApproval2DivisionChiefApproval
            
            //this.RequestNoSeq.GetNextValue(this.MaintenanceOrderType.ObjectID.ToString(),DateTime.Now.Year);

#endregion PostTransition_OrderApproval2DivisionChiefApproval
        }

        protected void PostTransition_TechnicalDirectorApproval2DivisionChiefApproval()
        {
            // From State : TechnicalDirectorApproval   To State : DivisionChiefApproval
#region PostTransition_TechnicalDirectorApproval2DivisionChiefApproval
            
            //this.RequestNoSeq.GetNextValue(this.MaintenanceOrderType.ObjectID.ToString(),DateTime.Now.Year);
#endregion PostTransition_TechnicalDirectorApproval2DivisionChiefApproval
        }

        protected void PreTransition_Manufacturing2LastControl()
        {
            // From State : Manufacturing   To State : LastControl
#region PreTransition_Manufacturing2LastControl
            
            
            if(RepairWorkLoad == null)
            {
                string message = SystemMessage.GetMessage(10);
                throw new TTUtils.TTException(message);
            }

#endregion PreTransition_Manufacturing2LastControl
        }

        protected void PostTransition_Manufacturing2LastControl()
        {
            // From State : Manufacturing   To State : LastControl
#region PostTransition_Manufacturing2LastControl
            
            
            
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

            

#endregion PostTransition_Manufacturing2LastControl
        }

        protected void PostTransition_DivisionSectionApproval2Calibration()
        {
            // From State : DivisionSectionApproval   To State : Calibration
#region PostTransition_DivisionSectionApproval2Calibration
            
            
            Calibration ca = new Calibration(ObjectContext);
            ca.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
            ca.CurrentStateDefID = Calibration.States.ForkNew;
            ca.MaintenanceOrderObjectID = ObjectID.ToString();
            ca.RequestDate = Common.RecTime();
            ca.RequestNo = RequestNo ;
            ca.StartDate = Common.RecTime();
            ca.SenderSection = SenderSection ;
            ca.SenderAccountancy = SenderAccountancy;
            ca.Section = Section ;
            ca.WorkShop = WorkShop;
            ca.ResponsibleUser = ResponsibleUser;
            ca.Update();
            ca.CurrentStateDefID = Calibration.States.Calibration;
            foreach(RUL_ItemEquipment itemEquipment in RelatedReferToUpperLevel.RUL_ItemEquipments)
            {
                Calibration_ItemEquipment calibrationItem = new Calibration_ItemEquipment(ObjectContext);
                calibrationItem.ItemName = itemEquipment.ItemName;
                calibrationItem.DistributionType = itemEquipment.DistributionType;
                calibrationItem.Amount = itemEquipment.Amount;
                calibrationItem.Calibration = ca;
            }

#endregion PostTransition_DivisionSectionApproval2Calibration
        }

        protected void PostTransition_DivisionSectionApproval2Repair()
        {
            // From State : DivisionSectionApproval   To State : Repair
#region PostTransition_DivisionSectionApproval2Repair
            
            StartDate =Common.RecTime(); //TODO:Düzelt h.Rectime

#endregion PostTransition_DivisionSectionApproval2Repair
        }

        protected void PostTransition_DivisionSectionApproval2Manufacturing()
        {
            // From State : DivisionSectionApproval   To State : Manufacturing
#region PostTransition_DivisionSectionApproval2Manufacturing
            StartDate =Common.RecTime();
#endregion PostTransition_DivisionSectionApproval2Manufacturing
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
        }

//        public override string ToString()
//        {
//            if (this.FixedAssetMaterialDefinition != null)
//            {
//                return "İstek No:" + this.RequestNo + " - Marka: " + this.FixedAssetMaterialDefinition.Mark.ToString() + " - İsim:" + this.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString() + " - Step: " + this.CurrentStateDef.ToString() + " - İstek Tarih: " + this.RequestDate.ToString();
//            }
//            else
//            {
//                return "İstek No:" + this.RequestNo;
//            }
//        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaintenanceOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaintenanceOrder.States.Fieldwork && toState == MaintenanceOrder.States.LastControl)
                PreTransition_Fieldwork2LastControl();
            else if (fromState == MaintenanceOrder.States.Calibration && toState == MaintenanceOrder.States.Repair)
                PreTransition_Calibration2Repair();
            else if (fromState == MaintenanceOrder.States.Calibration && toState == MaintenanceOrder.States.LastControl)
                PreTransition_Calibration2LastControl();
            else if (fromState == MaintenanceOrder.States.Repair && toState == MaintenanceOrder.States.HEK)
                PreTransition_Repair2HEK();
            else if (fromState == MaintenanceOrder.States.Repair && toState == MaintenanceOrder.States.SupplyOfMaterial)
                PreTransition_Repair2SupplyOfMaterial();
            else if (fromState == MaintenanceOrder.States.SpecialWork && toState == MaintenanceOrder.States.SupplyApproval)
                PreTransition_SpecialWork2SupplyApproval();
            else if (fromState == MaintenanceOrder.States.Manufacturing && toState == MaintenanceOrder.States.LastControl)
                PreTransition_Manufacturing2LastControl();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaintenanceOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaintenanceOrder.States.OrderClose && toState == MaintenanceOrder.States.Completed)
                PostTransition_OrderClose2Completed();
            else if (fromState == MaintenanceOrder.States.SupplyOfMaterial && toState == MaintenanceOrder.States.Repair)
                PostTransition_SupplyOfMaterial2Repair();
            else if (fromState == MaintenanceOrder.States.SupplyOfMaterial && toState == MaintenanceOrder.States.SpecialWork)
                PostTransition_SupplyOfMaterial2SpecialWork();
            else if (fromState == MaintenanceOrder.States.SupplyOfMaterial && toState == MaintenanceOrder.States.Manufacturing)
                PostTransition_SupplyOfMaterial2Manufacturing();
            else if (fromState == MaintenanceOrder.States.Repair && toState == MaintenanceOrder.States.HEK)
                PostTransition_Repair2HEK();
            else if (fromState == MaintenanceOrder.States.Repair && toState == MaintenanceOrder.States.Calibration)
                PostTransition_Repair2Calibration();
            else if (fromState == MaintenanceOrder.States.Repair && toState == MaintenanceOrder.States.LastControl)
                PostTransition_Repair2LastControl();
            else if (fromState == MaintenanceOrder.States.Repair && toState == MaintenanceOrder.States.SupplyApproval)
                PostTransition_Repair2SupplyApproval();
            else if (fromState == MaintenanceOrder.States.SpecialWork && toState == MaintenanceOrder.States.SupplyApproval)
                PostTransition_SpecialWork2SupplyApproval();
            else if (fromState == MaintenanceOrder.States.NewOrder && toState == MaintenanceOrder.States.Approval)
                PostTransition_NewOrder2Approval();
            else if (fromState == MaintenanceOrder.States.OrderApproval && toState == MaintenanceOrder.States.DivisionChiefApproval)
                PostTransition_OrderApproval2DivisionChiefApproval();
            else if (fromState == MaintenanceOrder.States.TechnicalDirectorApproval && toState == MaintenanceOrder.States.DivisionChiefApproval)
                PostTransition_TechnicalDirectorApproval2DivisionChiefApproval();
            else if (fromState == MaintenanceOrder.States.Manufacturing && toState == MaintenanceOrder.States.LastControl)
                PostTransition_Manufacturing2LastControl();
            else if (fromState == MaintenanceOrder.States.DivisionSectionApproval && toState == MaintenanceOrder.States.Calibration)
                PostTransition_DivisionSectionApproval2Calibration();
            else if (fromState == MaintenanceOrder.States.DivisionSectionApproval && toState == MaintenanceOrder.States.Repair)
                PostTransition_DivisionSectionApproval2Repair();
            else if (fromState == MaintenanceOrder.States.DivisionSectionApproval && toState == MaintenanceOrder.States.Manufacturing)
                PostTransition_DivisionSectionApproval2Manufacturing();
        }

    }
}