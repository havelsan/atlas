
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
    /// Ãœst Kademeye Sevk
    /// </summary>
    public  partial class ReferToUpperLevel : CMRAction
    {
        public partial class RULReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class RULDetailReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetRULDetailsByObjectIDQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetReferToUpperLevelByObjectIDQuery_Class : TTReportNqlObject 
        {
        }

        public partial class RUL_HEKReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class HEKReportToItemEquipmentsReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetRULDetailsByRequestNoQuery_Class : TTReportNqlObject 
        {
        }

        
                    
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            if(FixedAssetMaterialDefinition !=null)
            {
            if( FixedAssetMaterialDefinition.CMRStatus != FixedAssetCMRStatusEnum.InReferToUpperLevelProgress)
                FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InReferToUpperLevelProgress;
            }
#endregion PreInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            if (CurrentStateDefID == ReferToUpperLevel.States.Completed)
            {
                FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InMaintenanceOrderProgress;
                EndDate = Common.RecTime();
            }

#endregion PostUpdate
        }

        protected void PostTransition_InOrderProgress2UpperLevelCompleted()
        {
            // From State : InOrderProgress   To State : UpperLevelCompleted
#region PostTransition_InOrderProgress2UpperLevelCompleted
            
            
            
            
            if (OwnerMilitaryUnit.Site != null)
            {
                Sites site = OwnerMilitaryUnit.Site;
              //  TTMessage message = ReferToUpperLevel.RemoteMethods.UpdateReferToUpperLevel(site.ObjectID, this, this.FixedAssetMaterialDefinition);
            }

#endregion PostTransition_InOrderProgress2UpperLevelCompleted
        }

        protected void PostTransition_ConsultantApproval2UpperLevelCommander()
        {
            // From State : ConsultantApproval   To State : UpperLevelCommander
#region PostTransition_ConsultantApproval2UpperLevelCommander
            
            StartDate = Common.RecTime();

#endregion PostTransition_ConsultantApproval2UpperLevelCommander
        }

        protected void PostTransition_Registry2AccountantApproval()
        {
            // From State : Registry   To State : AccountantApproval
#region PostTransition_Registry2AccountantApproval
            
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
            RequestNo = Common.RecTime().Year.ToString() +"-"+ txtSeq.ToString();

#endregion PostTransition_Registry2AccountantApproval
        }

        protected void PostTransition_FirstExamination2FirstExaminationRegistry()
        {
            // From State : FirstExamination   To State : FirstExaminationRegistry
#region PostTransition_FirstExamination2FirstExaminationRegistry
            
            CheckDate = Common.RecTime();

#endregion PostTransition_FirstExamination2FirstExaminationRegistry
        }

        protected void PostTransition_FirstExamination2InOrderProgress()
        {
            // From State : FirstExamination   To State : InOrderProgress
#region PostTransition_FirstExamination2InOrderProgress
            
            
            
            
            
            
            MaintenanceOrder mo = new MaintenanceOrder(ObjectContext);
            mo.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition ;
            mo.OwnerMilitaryUnit = OwnerMilitaryUnit ;
            mo.RelatedReferToUpperLevel = this;
            mo.SenderAccountancy = SenderAccountancy ;
            mo.CurrentStateDefID = MaintenanceOrder.States.NewOrder;
            mo.PlannedTime = "1";
            mo.RequestDate = Common.RecTime();
            mo.OrderDate = Common.RecTime();
            string curdate = Common.RecTime().ToString();
            mo.RequestNo = curdate.Substring(8, 2) + "-  -    ";
            mo.OrderName = FixedAssetMaterialDefinition.Description ;
            mo.OrderNO = RequestNo;
            mo.Description = Description;
            mo.ReferType = ReferType ;
            mo.CheckDate = CheckDate;
            foreach (UnitMaintenance unitParameter in UnitMaintenances)
            {
                UnitMaintenance unitMaintenance = mo.UnitMaintenances.AddNew();
                unitMaintenance.Parameter = unitParameter.Parameter;
                unitMaintenance.Description = unitParameter.Description;
                unitMaintenance.Checked = unitParameter.Checked;
            }
            foreach (UserMaintenance userParameter in UserMaintenances)
            {
                UserMaintenance userMaintenance = mo.UserMaintenances.AddNew();
                userMaintenance.Parameter = userParameter.Parameter;
                userMaintenance.Description = userParameter.Description;
                userMaintenance.Checked = userParameter.Checked;
            }
            if (OrderStatus != null)
            {
                mo.OrderStatus = OrderStatus;
            }
            if (FirstExamStatus == FirstExamResultEnum.HEK)
            {
                mo.OrderStatus = OrderStatusEnum.HEKFromFromExamination;
            }
            //mo.Stage.MilitaryUnit = this.Stage.MilitaryUnit ;

#endregion PostTransition_FirstExamination2InOrderProgress
        }

        protected void PreTransition_UpperLevelCompleted2Completed()
        {
            // From State : UpperLevelCompleted   To State : Completed
#region PreTransition_UpperLevelCompleted2Completed
            
            if(OrderStatus == OrderStatusEnum.HEKFromFromRepair || OrderStatus == OrderStatusEnum.HEKFromFromExamination )
            {
                UserMessage message = new UserMessage(ObjectContext);
                message.IsSystemMessage = true;
                message.MessageDate = TTObjectDefManager.ServerTime;
                message.Subject = TTUtils.CultureService.GetText("M27166", "Ãœst Kademeye Sevk Bilgilendirmesi");
             //   message.Status = MessageStatusEnum.Sent;
                message.ToUser = (ResUser)FixedAssetMaterialDefinition.ResUser ;
                message.Sender = (ResUser)Common.CurrentUser.UserObject;
                message.SetRTFBody(FixedAssetMaterialDefinition.FixedAssetNO.ToString() + " demirbaş numaralı " + FixedAssetMaterialDefinition.Description.ToString() + " demirbaşı üst kademeye sevk işlemi ile HEK işlemi başlatılmıştır.\r\nİlgili cihazı saymanlığınıza iade etmeniz gerekmektedir.");
            }

#endregion PreTransition_UpperLevelCompleted2Completed
        }

        protected void PostTransition_UpperLevelCommander2TemporaryAdmissionRegistry()
        {
            // From State : UpperLevelCommander   To State : TemporaryAdmissionRegistry
#region PostTransition_UpperLevelCommander2TemporaryAdmissionRegistry
            
            if(RepairObjectID == null)
            {
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
                RequestNo = Common.RecTime().Year.ToString() +"-"+ txtSeq.ToString();
            }

#endregion PostTransition_UpperLevelCommander2TemporaryAdmissionRegistry
        }

        protected void PostTransition_UpperLevelCommander2TechnicalDirectorApproval()
        {
            // From State : UpperLevelCommander   To State : TechnicalDirectorApproval
#region PostTransition_UpperLevelCommander2TechnicalDirectorApproval
            
            if(RepairObjectID == null)
            {
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
                RequestNo = Common.RecTime().Year.ToString() +"-"+ txtSeq.ToString();
            }
#endregion PostTransition_UpperLevelCommander2TechnicalDirectorApproval
        }

        protected void PostTransition_UpperLevelRegistry2UpperLevelCommander()
        {
            // From State : UpperLevelRegistry   To State : UpperLevelCommander
#region PostTransition_UpperLevelRegistry2UpperLevelCommander
            
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
            RequestNo = Common.RecTime().Year.ToString() +"-"+ txtSeq.ToString();

#endregion PostTransition_UpperLevelRegistry2UpperLevelCommander
        }

        protected void PostTransition_TechnicalDirectorApproval2InOrderProgress()
        {
            // From State : TechnicalDirectorApproval   To State : InOrderProgress
#region PostTransition_TechnicalDirectorApproval2InOrderProgress
            
            MaintenanceOrder mo = new MaintenanceOrder(ObjectContext);
            mo.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition ;
            mo.OwnerMilitaryUnit = OwnerMilitaryUnit ;
            mo.RelatedReferToUpperLevel = this;
            mo.SenderAccountancy = SenderAccountancy ;
            mo.CurrentStateDefID = MaintenanceOrder.States.NewOrder;
            mo.PlannedTime = "1";
            mo.RequestDate = Common.RecTime();
            mo.OrderDate = Common.RecTime();
            string curdate = Common.RecTime().ToString();
            mo.RequestNo = curdate.Substring(8, 2) + "-  -    ";
            mo.OrderName = TTUtils.CultureService.GetText("M26865", "Seyyar Ekip Talebi");
            mo.OrderNO = RequestNo;
            mo.Description = Description;
            mo.ReferType = ReferTypeEnum.TeamRequest ;
            foreach (UnitMaintenance unitParameter in UnitMaintenances)
            {
                UnitMaintenance unitMaintenance = mo.UnitMaintenances.AddNew();
                unitMaintenance.Parameter = unitParameter.Parameter;
                unitMaintenance.Description = unitParameter.Description;
            }
            foreach (UserMaintenance userParameter in UserMaintenances)
            {
                UserMaintenance userMaintenance = mo.UserMaintenances.AddNew();
                userMaintenance.Parameter = userParameter.Parameter;
                userMaintenance.Description = userParameter.Description;
            }
            if (OrderStatus != null)
            {
                mo.OrderStatus = OrderStatus;
            }
            //mo.Stage.MilitaryUnit = this.Stage.MilitaryUnit ;

#endregion PostTransition_TechnicalDirectorApproval2InOrderProgress
        }

        protected void PostTransition_CalibrationExamination2InOrderProgress()
        {
            // From State : CalibrationExamination   To State : InOrderProgress
#region PostTransition_CalibrationExamination2InOrderProgress
            
            
            MaintenanceOrder mo = new MaintenanceOrder(ObjectContext);
            if (FixedAssetMaterialDefinition != null)
                 mo.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition ;
            mo.OwnerMilitaryUnit = OwnerMilitaryUnit ;
            mo.RelatedReferToUpperLevel = this;
            mo.SenderAccountancy = SenderAccountancy ;
            mo.CurrentStateDefID = MaintenanceOrder.States.NewOrder;
            mo.PlannedTime = "1";
            mo.RequestDate = Common.RecTime();
            mo.OrderDate = Common.RecTime();
            string curdate = Common.RecTime().ToString();
            mo.RequestNo = curdate.Substring(8, 2) + "-  -    ";
            if(FixedAssetMaterialDefinition !=null)
              mo.OrderName = FixedAssetMaterialDefinition.Description ;
            mo.OrderNO = RequestNo;
            mo.Description = Description;
            mo.ReferType = ReferType ;
            mo.CheckDate = CheckDate;
            foreach (UnitMaintenance unitParameter in UnitMaintenances)
            {
                UnitMaintenance unitMaintenance = mo.UnitMaintenances.AddNew();
                unitMaintenance.Parameter = unitParameter.Parameter;
                unitMaintenance.Description = unitParameter.Description;
            }
            foreach (UserMaintenance userParameter in UserMaintenances)
            {
                UserMaintenance userMaintenance = mo.UserMaintenances.AddNew();
                userMaintenance.Parameter = userParameter.Parameter;
                userMaintenance.Description = userParameter.Description;
            }
            if (OrderStatus != null)
            {
                mo.OrderStatus = OrderStatus;
            }
            if (FirstExamStatus == FirstExamResultEnum.HEK)
            {
                mo.OrderStatus = OrderStatusEnum.HEKFromFromExamination;
            }

#endregion PostTransition_CalibrationExamination2InOrderProgress
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
        
        public override string ToString()
        {
            if (FixedAssetMaterialDefinition != null)
            {
                return TTUtils.CultureService.GetText("M26147", "İstek No:")+ RequestNo + "Marka: " + FixedAssetMaterialDefinition.Mark + "   ----   İsim:" + FixedAssetMaterialDefinition.Description + "   ----   Step: " + CurrentStateDef.ToString() + "   ----   İstek Tarih: " + RequestDate.ToString();
            }
            else 
            {
                return TTUtils.CultureService.GetText("M26147", "İstek No:")+ RequestNo;
            }
        }
        
        public void FillEquipments()
        {
            //            if (this.FixedAssetMaterialDefinition != null)
            //            {
            //                this.RUL_ItemEquipments.Clear();
            //                foreach(FixedAssetMaterialContent fc in this.FixedAssetMaterialDefinition.Contents)
            //                {
            //                    RUL_ItemEquipment rie = new RUL_ItemEquipment(this.ObjectContext);
            //                    rie.ReferToUpperLevel = this;
            //                    rie.ItemName = fc.Name;
            //                    rie.Amount = 1;
            //                }
            //            }
        }
        
        protected override void OnBeforeImportFromObject(DataRow dataRow)
        {
            base.OnBeforeImportFromObject(dataRow);

            dataRow["SENDERSECTION"] = null;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReferToUpperLevel).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReferToUpperLevel.States.UpperLevelCompleted && toState == ReferToUpperLevel.States.Completed)
                PreTransition_UpperLevelCompleted2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReferToUpperLevel).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReferToUpperLevel.States.InOrderProgress && toState == ReferToUpperLevel.States.UpperLevelCompleted)
                PostTransition_InOrderProgress2UpperLevelCompleted();
            else if (fromState == ReferToUpperLevel.States.ConsultantApproval && toState == ReferToUpperLevel.States.UpperLevelCommander)
                PostTransition_ConsultantApproval2UpperLevelCommander();
            else if (fromState == ReferToUpperLevel.States.Registry && toState == ReferToUpperLevel.States.AccountantApproval)
                PostTransition_Registry2AccountantApproval();
            else if (fromState == ReferToUpperLevel.States.FirstExamination && toState == ReferToUpperLevel.States.FirstExaminationRegistry)
                PostTransition_FirstExamination2FirstExaminationRegistry();
            else if (fromState == ReferToUpperLevel.States.FirstExamination && toState == ReferToUpperLevel.States.InOrderProgress)
                PostTransition_FirstExamination2InOrderProgress();
            else if (fromState == ReferToUpperLevel.States.UpperLevelCommander && toState == ReferToUpperLevel.States.TemporaryAdmissionRegistry)
                PostTransition_UpperLevelCommander2TemporaryAdmissionRegistry();
            else if (fromState == ReferToUpperLevel.States.UpperLevelCommander && toState == ReferToUpperLevel.States.TechnicalDirectorApproval)
                PostTransition_UpperLevelCommander2TechnicalDirectorApproval();
            else if (fromState == ReferToUpperLevel.States.UpperLevelRegistry && toState == ReferToUpperLevel.States.UpperLevelCommander)
                PostTransition_UpperLevelRegistry2UpperLevelCommander();
            else if (fromState == ReferToUpperLevel.States.TechnicalDirectorApproval && toState == ReferToUpperLevel.States.InOrderProgress)
                PostTransition_TechnicalDirectorApproval2InOrderProgress();
            else if (fromState == ReferToUpperLevel.States.CalibrationExamination && toState == ReferToUpperLevel.States.InOrderProgress)
                PostTransition_CalibrationExamination2InOrderProgress();
        }

    }
}