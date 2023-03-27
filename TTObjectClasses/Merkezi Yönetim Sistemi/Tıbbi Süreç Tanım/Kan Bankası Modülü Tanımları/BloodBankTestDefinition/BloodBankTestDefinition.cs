
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
    /// Kan Bankası Hizmet Tanımı
    /// </summary>
    public  partial class BloodBankTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public partial class GetBloodBankTestDefinitions_Class : TTReportNqlObject 
        {
        }

        #region Methods

        public override void SetProcedureType()
        {
            ProcedureType = ProcedureDefGroupEnum.kanBilgileri;
        }

        #region IProcedureRequestDefinition Members
        public String GetMyCategoryName()
        {
            return MyCategoryName;
        }

        public String GetMyFiredActionDefName()
        {
            return MyFiredActionDefName;
        }

        public bool GetIsProcedureFlowStarts()
        {
            return IsProcedureFlowStarts;
        }

        public Guid GetMyStartedStateDefID()
        {
            return MyStartedStateDefID;
        }
        #endregion
        public Guid MyStartedStateDefID
        {
            get
            {
                return (Guid)BloodProductRequest.States.BloodProductPreparation;
            }
        }


        public string MyCategoryName
        {
            get
            {
                return (string)ProcedureTree.Description.ToString();
            }
        }


        public string MyFiredActionDefName
        {
            get
            {
                return "BloodProductRequest";
            }
        }
        
               public bool IsProcedureFlowStarts
            {
                get{
                    return true;
                }
            }

        public EpisodeAction CreateMyEpisodeAction(EpisodeAction starterEA, ResSection masterRes, ResSection fromRes, bool setMasterAction, bool emergency, DateTime requestDate, Guid procedureUser, bool fromPatientAdmission)
        {

            BloodProductRequest bloodRequestAction = (BloodProductRequest)ObjectContext.CreateObject("BloodProductRequest");
            bloodRequestAction.ActionDate = requestDate;
            bloodRequestAction.RequestDate = requestDate;
            if (procedureUser != null && procedureUser != Guid.Empty)
                bloodRequestAction.ProcedureDoctor = (ResUser)ObjectContext.GetObject(procedureUser, "ResUser");
            bloodRequestAction.WorkListDate = requestDate;
            bloodRequestAction.CurrentStateDefID = BloodProductRequest.States.BloodProductRequest;
            bloodRequestAction.MasterAction = (BaseAction)starterEA;
            if (emergency == true)
                bloodRequestAction.Emergency = emergency;

            bloodRequestAction.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            bloodRequestAction.SetMyActionMandatoryProperties();
            if (!fromPatientAdmission)
                bloodRequestAction.Update();

            return (EpisodeAction)bloodRequestAction;

        }

        public SubActionProcedure CreateMySubactionProcedure(EpisodeAction ea, ResSection masterRes, ResSection fromRes)
        {
            BloodProductRequest bloodRequest = (BloodProductRequest)ea;
            BloodBankBloodProducts bloodProd = (BloodBankBloodProducts)ObjectContext.CreateObject("BloodBankBloodProducts");
            BloodBankTestDefinition bloodTestDef = (BloodBankTestDefinition)this;

            SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(bloodRequest, masterRes, fromRes, bloodProd);
            bloodProd.CreationDate = ea.RequestDate;
            bloodProd.ActionDate = ea.RequestDate;
            bloodProd.ProcedureObject = bloodTestDef;
            bloodProd.EpisodeAction = bloodRequest;
            if (ea.Emergency == true)
                bloodProd.Emergency = true;

            bloodRequest.SubactionProcedures.Add((SubActionProcedure)bloodProd);
            return (SubActionProcedure)bloodProd;

        }

        public ActionTypeEnum? GetActionTypeEnum()
        {
            return ActionTypeEnum.BloodProductRequest;
        }

        public string GetMyAlertMessage(Guid eaObjectId)
        {
            return null;
        }

        #endregion Methods

    }
}