
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
    /// Onarım
    /// </summary>
    public  partial class Repair : CMRAction
    {
        public partial class RepairReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class RepairDetailReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetRepairForUsedMaterial_Class : TTReportNqlObject 
        {
        }

        public partial class GetUnitMaintenanceReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetHEKListFromRepairQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetRepairItemEquipmentsQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class : TTReportNqlObject 
        {
        }

        public partial class GetMonthlyRepairReportFromRepairQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMaintenanceAndRepairRegistryCardReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetActualDeliveryDate_Class : TTReportNqlObject 
        {
        }

        public partial class GetRepairForUsedMaterialCount_Class : TTReportNqlObject 
        {
        }

        public partial class RepairHEKReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetHEKReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetHEKCountRQ_Class : TTReportNqlObject 
        {
        }

        public partial class ConsumableReversePartReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class ConsumableReversePartReportQueryNew_Class : TTReportNqlObject 
        {
        }

        public partial class GetNormalListFromRepairQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetWorkshopNameFromRepairQuery_Class : TTReportNqlObject 
        {
        }

        public partial class HekRepairQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            

            if (this is MaterialRepair == false)
            {
                if(FixedAssetMaterialDefinition != null){
                    if (FixedAssetMaterialDefinition.CMRStatus != FixedAssetCMRStatusEnum.InRepairProgress)
                        FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InRepairProgress;
                    
                }
                
            }


#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            


            try
            {
                if (TransDef != null)
                {
                    if (TransDef.FromStateDefID == Repair.States.FirmRepair || TransDef.FromStateDefID == Repair.States.GuarantyRepair || TransDef.FromStateDefID == Repair.States.HEK || TransDef.FromStateDefID == Repair.States.Repair)
                    {
                        StateIDBeforeLastControl = TransDef.FromStateDefID.ToString();
                    }
                }
            }
            catch
            { }



#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            


            if (this is MaterialRepair == false)
            {
                if (CurrentStateDefID == Repair.States.Comleted)
                {
                    if(FixedAssetMaterialDefinition != null)
                    {
                        FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InUse;
                    }
                }
            }


#endregion PostUpdate
        }

        protected void PostTransition_Delivery2Comleted()
        {
            // From State : Delivery   To State : Comleted
#region PostTransition_Delivery2Comleted
            

            if (ActualDeliveryDate != null)
            {
                if (RequestCMRAction != null && RequestCMRAction is CMRActionRequest)
                    ((CMRActionRequest)RequestCMRAction).ActualDeliveryDate = ActualDeliveryDate;
            }

            if (RequestCMRAction is Calibration)
            {
                RequestCMRAction.RequestCMRAction.CurrentStateDefID = CMRActionRequest.States.Comleted;
                
            }
            else
            {
                if (RequestCMRAction.CurrentStateDefID != CMRActionRequest.States.Cancelled)
                    RequestCMRAction.CurrentStateDefID = CMRActionRequest.States.Comleted;
            }



#endregion PostTransition_Delivery2Comleted
        }

        protected void PreTransition_Repair2FirmRepair()
        {
            // From State : Repair   To State : FirmRepair
#region PreTransition_Repair2FirmRepair
            
            

            foreach (UsedConsumedMaterail usedConsumedMaterail in UsedConsumedMaterails)
            {
                if (usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.New)
                {
                    if (usedConsumedMaterail.SuppliedAmount == usedConsumedMaterail.Amount || usedConsumedMaterail.SuppliedAmount > usedConsumedMaterail.Amount)
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                    else
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
                }
            }


#endregion PreTransition_Repair2FirmRepair
        }

        protected void PreTransition_Repair2UpperStage()
        {
            // From State : Repair   To State : UpperStage
#region PreTransition_Repair2UpperStage
            
            

            foreach (UsedConsumedMaterail usedConsumedMaterail in UsedConsumedMaterails)
            {
                if (usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.New)
                {
                    if (usedConsumedMaterail.SuppliedAmount == usedConsumedMaterail.Amount || usedConsumedMaterail.SuppliedAmount > usedConsumedMaterail.Amount)
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                    else
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
                }
            }


#endregion PreTransition_Repair2UpperStage
        }

        protected void PostTransition_Repair2UpperStage()
        {
            // From State : Repair   To State : UpperStage
#region PostTransition_Repair2UpperStage
            





            ReferToUpperLevel rul = new ReferToUpperLevel(ObjectContext);
            rul.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
            rul.RequestNo = Common.RecTime().Year.ToString() + "-" + "####";
            rul.RequestDate = Common.RecTime();
            rul.CurrentStateDefID = ReferToUpperLevel.States.Registry;
            rul.Amount = 1;
            rul.BreakDown = FaultDescription;
            rul.SenderAccountancy = SenderAccountancy;
            rul.OwnerMilitaryUnit = OwnerMilitaryUnit;
            rul.ToMilitaryUnit = OwnerMilitaryUnit.CMRRelationsDefinition[0].MaintenanceRepairStage.MilitaryUnit;
            rul.Stage = OwnerMilitaryUnit.CMRRelationsDefinition[0].MaintenanceRepairStage;
            rul.RepairObjectID = ObjectID.ToString();
            rul.ReferType = ReferTypeEnum.Repair;
            RULObjectID = rul.ObjectID.ToString();
            FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InReferToUpperLevelProgress;

            foreach (UserMaintenance parameter in UserMaintenances)
            {
                UserMaintenance userMaintenance = rul.UserMaintenances.AddNew();
                userMaintenance.Parameter = parameter.Parameter;
                userMaintenance.Description = parameter.Description;
                userMaintenance.Checked = parameter.Checked;

            }
            foreach (UnitMaintenance parameter in UnitMaintenances)
            {
                UnitMaintenance unitMaintenance = rul.UnitMaintenances.AddNew();
                unitMaintenance.Parameter = parameter.Parameter;
                unitMaintenance.Description = parameter.Description;
                unitMaintenance.Checked = parameter.Checked;
            }

            foreach (Repair_ItemEquipment rie in Repair_ItemEquipments)
            {
                RUL_ItemEquipment rule = new RUL_ItemEquipment(ObjectContext);
                rule.Amount = rie.Amount;
                rule.ItemName = rie.ItemName;
                rule.DistributionType = rie.DistributionType;
                rule.CurrentStateDefID = rie.CurrentStateDefID;
                rule.ReferToUpperLevel = rul;
            }



#endregion PostTransition_Repair2UpperStage
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
                        usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                    else
                        throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
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
                            neededMaterials.MaterialTotalPrice = 0;
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

        protected void PostTransition_Repair2MobileTeam()
        {
            // From State : Repair   To State : MobileTeam
#region PostTransition_Repair2MobileTeam
            

            ReferToUpperLevel rul = new ReferToUpperLevel(ObjectContext);
            rul.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
            rul.RequestNo = Common.RecTime().Year.ToString() + "-" + "####";
            rul.RequestDate = Common.RecTime();
            rul.CurrentStateDefID = ReferToUpperLevel.States.Registry;
            rul.Amount = 1;
            rul.BreakDown = FaultDescription;
            rul.SenderAccountancy = SenderAccountancy;
            rul.OwnerMilitaryUnit = OwnerMilitaryUnit;
            rul.ToMilitaryUnit = OwnerMilitaryUnit.CMRRelationsDefinition[0].MaintenanceRepairStage.MilitaryUnit;
            rul.Stage = OwnerMilitaryUnit.CMRRelationsDefinition[0].MaintenanceRepairStage;
            rul.RepairObjectID = ObjectID.ToString();
            rul.ReferType = ReferTypeEnum.TeamRequest;
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

            foreach (Repair_ItemEquipment rie in Repair_ItemEquipments)
            {
                RUL_ItemEquipment rule = new RUL_ItemEquipment(ObjectContext);
                rule.Amount = rie.Amount;
                rule.ItemName = rie.ItemName;
                rule.DistributionType = rie.DistributionType;
                rule.CurrentStateDefID = rie.CurrentStateDefID;
                rule.ReferToUpperLevel = rul;
            }


#endregion PostTransition_Repair2MobileTeam
        }

        protected void PreTransition_HEK2LastControl()
        {
            // From State : HEK   To State : LastControl
#region PreTransition_HEK2LastControl
            
            CreateReturnDocument();

#endregion PreTransition_HEK2LastControl
        }

        protected void PreTransition_PreControl2Cancelled()
        {
            // From State : PreControl   To State : Cancelled
#region PreTransition_PreControl2Cancelled
            


            CMRActionRequest cMRActionRequest = (CMRActionRequest)RequestCMRAction;
            cMRActionRequest.CurrentStateDefID = CMRActionRequest.States.StageApproval;
            cMRActionRequest.ForkCMRAction.Remove(this);


#endregion PreTransition_PreControl2Cancelled
        }

        protected void PreTransition_MobileTeam2LastControl()
        {
            // From State : MobileTeam   To State : LastControl
#region PreTransition_MobileTeam2LastControl
            
            


            Guid rulid = new Guid(RULObjectID.ToString());
            ReferToUpperLevel rul = (ReferToUpperLevel)ObjectContext.GetObject(rulid, "REFERTOUPPERLEVEL");
            Guid rulsid = new Guid(rul.CurrentStateDefID.ToString());
            if ((rulsid != ReferToUpperLevel.States.Completed) && (rulsid != ReferToUpperLevel.States.Cancelled))
            {
                string message = SystemMessage.GetMessage(49);
                throw new TTUtils.TTException(message);
            }
            else
            {
                foreach (UsedConsumedMaterail usedConsumedMaterail in UsedConsumedMaterails)
                {
                    if (usedConsumedMaterail.CurrentStateDefID == UsedConsumedMaterail.States.New)
                    {
                        if (usedConsumedMaterail.SuppliedAmount == usedConsumedMaterail.Amount || usedConsumedMaterail.SuppliedAmount > usedConsumedMaterail.Amount)
                            usedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                        else
                            throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedConsumedMaterail.Material.Name.ToString()));
                    }
                }

            }



#endregion PreTransition_MobileTeam2LastControl
        }

        protected void PreTransition_UpperStage2LastControl()
        {
            // From State : UpperStage   To State : LastControl
#region PreTransition_UpperStage2LastControl
            



            Guid rulid = new Guid(RULObjectID.ToString());
            ReferToUpperLevel rul = (ReferToUpperLevel)ObjectContext.GetObject(rulid, "REFERTOUPPERLEVEL");
            Guid rulsid = new Guid(rul.CurrentStateDefID.ToString());
            if ((rulsid != ReferToUpperLevel.States.Completed) && (rulsid != ReferToUpperLevel.States.Cancelled))
            {
                string message = SystemMessage.GetMessage(50);
                throw new TTUtils.TTException(message);
            }



#endregion PreTransition_UpperStage2LastControl
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

#region Methods
        //public override string ToString()
        //{
        //    //return "İstek No:" + this.RequestNo + "Marka: " + this.FixedAssetMaterialDefinition.Mark.ToString() + "   ----   İsim:" + this.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString() + "   ----   Step: " + this.CurrentStateDef.ToString() + "   ----   İstek Tarih: " + this.RequestDate.ToString();
        //}


        override protected void OnConstruct()
        {
            base.OnConstruct();
        }

        public void FillEquipments()
        {
            if (FixedAssetMaterialDefinition != null)
            {
                Repair_ItemEquipments.Clear();
                foreach (FixedAssetMaterialContent fc in FixedAssetMaterialDefinition.Contents)
                {
                    Repair_ItemEquipment rie = new Repair_ItemEquipment(ObjectContext);
                    rie.Repair = this;
                    rie.ItemName = fc.Name;
                    rie.Amount = 1;
                }
            }
        }

        public Hashtable StateValidate()
        {
            Hashtable errorColl = new Hashtable();
            int ErrorCount = 0;
            if (TransDef != null)
            {
                switch (TransDef.FromStateDefID.ToString())
                {
                        ///İSTEK ONAY///
                    case "a73d09ad-5877-4406-b227-fd08b0fb078b":
                        //Onarım kademede yapılacak ise teslim tarihi zorunlu.
                        if (RepairPlace == RepairPlaceEnum.StageRepair)
                        {
                            if (DeliveryDate == null)
                            {
                                ErrorCount++;
                                errorColl.Add(ErrorCount, TTUtils.CultureService.GetText("M26253", "Kademede onarım işlemlerinde teslim tarihi girilmesi zorunludur."));
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return errorColl;
        }

        public void CreateReturnDocument()
        {
            MainStoreDefinition mainStoreDefinition = null;
            IList mainstores = MainStoreDefinition.GetAllMainStores(ObjectContext);
            if (mainstores.Count == 1)
            {
                if (this is MaterialRepair)
                {
                    MaterialRepair materialRepair = (MaterialRepair)this;
                    if (materialRepair.SenderSection.Store != null)
                    {
                        if (materialRepair.SenderSection.Store is DependentStoreDefinition ||
                            materialRepair.SenderSection.Store is PharmacyStoreDefinition ||
                            materialRepair.SenderSection.Store is SubStoreDefinition)
                        {
                            mainStoreDefinition = (MainStoreDefinition)mainstores[0];
                            ReturningDocument returningDocument = new ReturningDocument(ObjectContext);
                            returningDocument.DestinationStore = mainStoreDefinition;
                            returningDocument.Store = materialRepair.SenderSection.Store;
                            returningDocument.CurrentStateDefID = ReturningDocument.States.New;
                            returningDocument.Description = RequestNo + " nolu Onarım işlemi ile HEK raporu düzenlenmiştir.";
                            returningDocument.MaterialRepairObjectID = materialRepair.ObjectID;
                            ReturningDocumentMaterial returningDocumentMaterial = new ReturningDocumentMaterial(ObjectContext);
                            returningDocumentMaterial.StockAction = returningDocument;
                            returningDocumentMaterial.Material = materialRepair.FixedAssetDefinition;
                            returningDocumentMaterial.Amount = materialRepair.FixedAssetMaterialAmount;
                            returningDocumentMaterial.RequireAmount = materialRepair.FixedAssetMaterialAmount;
                            returningDocumentMaterial.StockLevelType = StockLevelType.UsedStockLevel;
                            TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25326", "Bu malzeme için iade işlemi oluşturulmuştur."));

                        }

                    }
                }
                else
                {
                    if(FixedAssetMaterialDefinition != null)
                    {
                        if (FixedAssetMaterialDefinition.Stock != null)
                        {
                            if (FixedAssetMaterialDefinition.Stock.Store is DependentStoreDefinition ||
                                FixedAssetMaterialDefinition.Stock.Store is PharmacyStoreDefinition ||
                                FixedAssetMaterialDefinition.Stock.Store is SubStoreDefinition)
                            {
                                mainStoreDefinition = (MainStoreDefinition)mainstores[0];
                                ReturningDocument returningDocument = new ReturningDocument(ObjectContext);
                                returningDocument.DestinationStore = mainStoreDefinition;
                                returningDocument.Store = FixedAssetMaterialDefinition.Stock.Store;
                                returningDocument.CurrentStateDefID = ReturningDocument.States.New;
                                returningDocument.Description = RequestNo + " nolu Onarım işlemi ile HEK raporu düzenlenmiştir.";
                                returningDocument.RepairObjectID = ObjectID;
                                ReturningDocumentMaterial returningDocumentMaterial = new ReturningDocumentMaterial(ObjectContext);
                                returningDocumentMaterial.StockAction = returningDocument;
                                returningDocumentMaterial.Material = FixedAssetMaterialDefinition.FixedAssetDefinition;
                                returningDocumentMaterial.Amount = 1;
                                returningDocumentMaterial.RequireAmount = 1;
                                returningDocumentMaterial.StockLevelType = StockLevelType.UsedStockLevel;
                                if (FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                                {
                                    FixedAssetOutDetail fixedAssetOutDetail = new FixedAssetOutDetail(ObjectContext);
                                    fixedAssetOutDetail.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
                                    fixedAssetOutDetail.StockActionDetail = returningDocumentMaterial;
                                }
                                TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25326", "Bu malzeme için iade işlemi oluşturulmuştur."));
                            }
                        }
                    }
                }
            }
        }
        
        public bool IsUnderGuaranty()
        {
            if (FixedAssetMaterialDefinition != null)
            {
                if (FixedAssetMaterialDefinition.GuarantyEndDate.HasValue)
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
            else
            {
                return false;// bir return etmesi gerekiyor ?
            }
        }
        
        public Currency FindPurchasePrice ()
        {
            Currency purchasePrice = 0 ;
            if (FixedAssetMaterialDefinition != null)
            {
                StockTransaction stockTransaction = null;
                foreach (FixedAssetTransaction trx in FixedAssetMaterialDefinition.FixedAssetTransactions.Select(string.Empty))
                {
                    if (trx.CurrentStateDefID == FixedAssetTransaction.States.Completed)
                    {
                        if (trx.StockTransaction.StockTransactionDefinition.TransactionType == TransactionTypeEnum.In)
                            stockTransaction = trx.StockTransaction;
                    }
                }
                if (stockTransaction != null)
                    purchasePrice = (Currency) stockTransaction.UnitPrice;
            }
            return purchasePrice;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Repair).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Repair.States.Repair && toState == Repair.States.FirmRepair)
                PreTransition_Repair2FirmRepair();
            else if (fromState == Repair.States.Repair && toState == Repair.States.UpperStage)
                PreTransition_Repair2UpperStage();
            else if (fromState == Repair.States.Repair && toState == Repair.States.LastControl)
                PreTransition_Repair2LastControl();
            else if (fromState == Repair.States.Repair && toState == Repair.States.HEK)
                PreTransition_Repair2HEK();
            else if (fromState == Repair.States.HEK && toState == Repair.States.LastControl)
                PreTransition_HEK2LastControl();
            else if (fromState == Repair.States.PreControl && toState == Repair.States.Cancelled)
                PreTransition_PreControl2Cancelled();
            else if (fromState == Repair.States.MobileTeam && toState == Repair.States.LastControl)
                PreTransition_MobileTeam2LastControl();
            else if (fromState == Repair.States.UpperStage && toState == Repair.States.LastControl)
                PreTransition_UpperStage2LastControl();
            else if (fromState == Repair.States.LastControl && toState == Repair.States.Delivery)
                PreTransition_LastControl2Delivery();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Repair).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Repair.States.Delivery && toState == Repair.States.Comleted)
                PostTransition_Delivery2Comleted();
            else if (fromState == Repair.States.Repair && toState == Repair.States.UpperStage)
                PostTransition_Repair2UpperStage();
            else if (fromState == Repair.States.Repair && toState == Repair.States.MobileTeam)
                PostTransition_Repair2MobileTeam();
        }

    }
}