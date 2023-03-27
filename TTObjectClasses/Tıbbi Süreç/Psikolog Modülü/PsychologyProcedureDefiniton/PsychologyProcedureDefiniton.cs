
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
    public  partial class PsychologyProcedureDefiniton : ProcedureDefinition, IProcedureRequestDefinition
    {
        public partial class GetAllPsychologyProcedureDefinitonList_Class : TTReportNqlObject 
        {
        }

        public Guid MyStartedStateDefID
        {
            get
            {
                return (Guid)PsychologicExamination.States.Therapy;
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
                return "PsychologicExamination";
            }
        }

        public bool IsProcedureFlowStarts
        {
            get
            {
                return true;
            }
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

        public EpisodeAction CreateMyEpisodeAction(EpisodeAction starterEA, ResSection masterRes, ResSection fromRes, bool setMasterAction, bool emergency, DateTime requestDate, Guid procedureUser, bool fromPatientAdmission)
        {
            PsychologicExamination psychologicAction = (PsychologicExamination)ObjectContext.CreateObject("PsychologicExamination");
            psychologicAction.CurrentStateDefID = PsychologicExamination.States.Request;
            psychologicAction.ActionDate = requestDate;
            psychologicAction.RequestDate = requestDate;
            psychologicAction.WorkListDate = requestDate;
            //if (procedureUser != null && procedureUser != Guid.Empty)             Eski Kod : Mert
              //  psychologicAction.ProcedureDoctor = (ResUser)this.ObjectContext.GetObject(procedureUser, "ResUser");

            if(procedureUser != null && procedureUser != Guid.Empty)
            {
                psychologicAction.ProcedureByUser = (ResUser)ObjectContext.GetObject(procedureUser, "ResUser");
            }
            psychologicAction.MasterAction = (BaseAction)starterEA;
            if (emergency == true)
                psychologicAction.Emergency = emergency;

            psychologicAction.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            psychologicAction.SetMyActionMandatoryProperties();
            if (!fromPatientAdmission)
                psychologicAction.Update();

            //PsychologyBasedObject
            PsychologyBasedObject psychologyBasedObject = (PsychologyBasedObject)ObjectContext.CreateObject("PsychologyBasedObject");
            psychologyBasedObject.VisibleForProcedureDoctor = true;
            psychologyBasedObject.PsychologicExamination = psychologicAction;
            if (Common.CurrentDoctor == null)
            {
                psychologyBasedObject.RequestDoctor = starterEA.ProcedureDoctor;
                psychologicAction.ProcedureDoctor = starterEA.ProcedureDoctor;
            }
            else
            {
                psychologyBasedObject.RequestDoctor = Common.CurrentDoctor;
                psychologicAction.ProcedureDoctor = Common.CurrentDoctor;
            }

            return (EpisodeAction)psychologicAction;
            //return null;


        }

        public SubActionProcedure CreateMySubactionProcedure(EpisodeAction ea, ResSection masterRes, ResSection fromRes)
        {

            PsychologicExamination psychologicAction = (PsychologicExamination)ea;
            PsychologyTest psychologyTest = (PsychologyTest)ObjectContext.CreateObject("PsychologyTest");
            PsychologyProcedureDefiniton psychologyTestDef = (PsychologyProcedureDefiniton)this;
            psychologyTest.ProcedureObject = psychologyTestDef;
            psychologyTest.Amount = 1;
            psychologyTest.EpisodeAction = psychologicAction;
            psychologyTest.ProcedureDoctor = psychologicAction.ProcedureDoctor;
            psychologyTest.ProcedureByUser = psychologicAction.ProcedureByUser;
            psychologyTest.CreationDate = psychologicAction.RequestDate;
            psychologyTest.ActionDate = psychologicAction.RequestDate;
          
            if (ea.Emergency == true)
                psychologyTest.Emergency = true;

            psychologicAction.SubactionProcedures.Add((SubActionProcedure)psychologyTest);
            return (SubActionProcedure)psychologyTest;
        }
        public ActionTypeEnum? GetActionTypeEnum()
        {
            return ActionTypeEnum.PsychologicExamination;
        }

        public string GetMyAlertMessage(Guid eaObjectId)
        {
            return null;
        }


    }
}