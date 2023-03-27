
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
    /// Bakım
    /// </summary>
    public  partial class Maintenance : CMRAction
    {
        public partial class GetMaintenanceCheckListQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetDeviceCheckListQuery_Class : TTReportNqlObject 
        {
        }

        public partial class MaintenanceReportQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            if(this is MaterialMaintenance == false)
            {
                if( FixedAssetMaterialDefinition.CMRStatus != FixedAssetCMRStatusEnum.InMaintenanceProgress)
                    FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InMaintenanceProgress;
            }

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();
            if(RequestCMRAction == null)
            {
                string txtSeq = RequestNoSeq.Value.ToString();
                string reTxt = RequestNo.ToString();
                if(txtSeq.Length == 1)
                {
                    txtSeq = "000"+txtSeq.ToString();
                }
                if(txtSeq.Length == 2)
                {
                    txtSeq = "00"+txtSeq.ToString();
                }
                if(txtSeq.Length == 3)
                {
                    txtSeq = "0"+txtSeq.ToString();
                }
                RequestNo = reTxt.Substring(0, 4).ToString() + "-" + txtSeq.ToString();
            }

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            if (CurrentStateDefID == Maintenance.States.ForkNew)
            {
                WorkListDate = RequestDate;
            }

#endregion PostUpdate
        }

        protected void PostTransition_Maintenance2Completed()
        {
            // From State : Maintenance   To State : Completed
#region PostTransition_Maintenance2Completed
            
            EndDate = Common.RecTime();
            FixedAssetMaterialDefinition.LastMaintenanceDate = Common.RecTime();
            if(RequestCMRAction.CurrentStateDefID != CMRActionRequest.States.Cancelled)
                RequestCMRAction.CurrentStateDefID = CMRActionRequest.States.Comleted;
            
           

#endregion PostTransition_Maintenance2Completed
        }

        protected void PreTransition_Maintenance2Calibration()
        {
            // From State : Maintenance   To State : Calibration
#region PreTransition_Maintenance2Calibration
            

            EndDate = Common.RecTime();
            FixedAssetMaterialDefinition.LastMaintenanceDate = Common.RecTime();
            FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InUse ;
            RequestCMRAction.CurrentStateDefID = CMRActionRequest.States.Comleted;


#endregion PreTransition_Maintenance2Calibration
        }

        protected void PostTransition_Maintenance2Calibration()
        {
            // From State : Maintenance   To State : Calibration
#region PostTransition_Maintenance2Calibration
            
            CMRActionRequest cMRActionRequest = new CMRActionRequest(ObjectContext);
            cMRActionRequest.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
            cMRActionRequest.SenderSection = (ResSection)FixedAssetMaterialDefinition.Resource;
            cMRActionRequest.RequestType = RequestTypeEnum.Calibration;
            cMRActionRequest.FaultDescription = Description;
            if (RequestCMRAction is CMRActionRequest)
            {
                cMRActionRequest.UserTel = ((CMRActionRequest)RequestCMRAction).UserTel;
            }
            else
            {
                cMRActionRequest.UserTel = "0-000-0000";
            }
            cMRActionRequest.CurrentStateDefID = CMRActionRequest.States.Request;
            cMRActionRequest.FillEquipments();
            cMRActionRequest.FiilUserParameter();

#endregion PostTransition_Maintenance2Calibration
        }

        protected void PreTransition_Maintenance2Repair()
        {
            // From State : Maintenance   To State : Repair
#region PreTransition_Maintenance2Repair
            
            EndDate = Common.RecTime();
            FixedAssetMaterialDefinition.LastMaintenanceDate = Common.RecTime();
            FixedAssetMaterialDefinition.CMRStatus = FixedAssetCMRStatusEnum.InUse ;
            RequestCMRAction.CurrentStateDefID = CMRActionRequest.States.Comleted;


#endregion PreTransition_Maintenance2Repair
        }

        protected void PostTransition_Maintenance2Repair()
        {
            // From State : Maintenance   To State : Repair
#region PostTransition_Maintenance2Repair
            
            CMRActionRequest cMRActionRequest = new CMRActionRequest(ObjectContext);
            cMRActionRequest.FixedAssetMaterialDefinition = FixedAssetMaterialDefinition;
            cMRActionRequest.SenderSection = (ResSection)FixedAssetMaterialDefinition.Resource;
            cMRActionRequest.RequestType = RequestTypeEnum.Repair;
            cMRActionRequest.FaultDescription = Description;
            if (RequestCMRAction is CMRActionRequest)
            {
                cMRActionRequest.UserTel = ((CMRActionRequest)RequestCMRAction).UserTel;
            }
            else
            {
                cMRActionRequest.UserTel = "0-000-0000";
            }
            cMRActionRequest.CurrentStateDefID = CMRActionRequest.States.Request;
            cMRActionRequest.FillEquipments();
            cMRActionRequest.FiilUserParameter();

#endregion PostTransition_Maintenance2Repair
        }

#region Methods
        // public override string ToString()
        //{
        // return   "İstek No:" + this.RequestNo.ToString() + " - Marka: " + this.FixedAssetMaterialDefinition.Mark.ToString()+ "   ----   İsim:" + this.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString() + "   ----   Step: " + this.CurrentStateDef.ToString() + "   ----   İstek Tarih: " + this.RequestDate.ToString();
        //}
        
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                if (RequestNoSeq.Value == null)
                {
                    RequestNoSeq.GetNextValue(ObjectDef.ID.ToString(),Common.RecTime().Year) ;
                    if(RequestNo == null)
                        RequestNo = Common.RecTime().Year.ToString()+ "-" + "####";
                }
            }
        }

        public void FillMaintenanceParameters()
        {
            IList checkLists = ObjectContext.QueryObjects("MAINTENANCEPARAMETERDEFINITION","ALLMAINTENANCEACTION = 1");
            
            foreach (MaintenanceParameterDefinition  maintenanceParameterDefinition in checkLists)
            {
                if(maintenanceParameterDefinition.AboutWithDevice.HasValue && (bool)maintenanceParameterDefinition.AboutWithDevice)
                {
                    DeviceCheckList deviceCheckList = new DeviceCheckList(ObjectContext);
                    deviceCheckList.MaintenanceParameterDef = maintenanceParameterDefinition;
                    deviceCheckList.Check = false;
                    deviceCheckList.Maintenance = this;
                }
                else
                {
                    MaintenanceCheckList maintenanceCheckList = new MaintenanceCheckList(ObjectContext);
                    maintenanceCheckList.MaintenanceParameterDef = maintenanceParameterDefinition;
                    maintenanceCheckList.Check = false;
                    maintenanceCheckList.Maintenance = this; 
                }
            }
            
        }
        
        public bool AreAllMaintenanceParametersChecked()
        {
            bool allChecked = true;
            if (TransDef != null)
            {
                if (TransDef.ToStateDefID == Maintenance.States.Completed)
                {
                    foreach(MaintenanceParameter mp in MaintenanceParameters)
                    {
                        if (mp.Check == false)
                            allChecked = false;
                    }
                }
            }
            return allChecked;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Maintenance).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Maintenance.States.Maintenance && toState == Maintenance.States.Calibration)
                PreTransition_Maintenance2Calibration();
            else if (fromState == Maintenance.States.Maintenance && toState == Maintenance.States.Repair)
                PreTransition_Maintenance2Repair();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Maintenance).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Maintenance.States.Maintenance && toState == Maintenance.States.Completed)
                PostTransition_Maintenance2Completed();
            else if (fromState == Maintenance.States.Maintenance && toState == Maintenance.States.Calibration)
                PostTransition_Maintenance2Calibration();
            else if (fromState == Maintenance.States.Maintenance && toState == Maintenance.States.Repair)
                PostTransition_Maintenance2Repair();
        }

    }
}