
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
    /// Patoloji Test Tanımı
    /// </summary>
    public  partial class PathologyTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public partial class PathologyTestDefFormNQL_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetPathologyTestDef_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetpathologyTestDef_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetpathologyTestDef_WithDate2_Class : TTReportNqlObject 
        {
        }

        #region Methods

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
            get{
                return (Guid)PathologyRequest.States.Procedure;
            }
        }

        public override void SetProcedureType()
        {
            ProcedureType = ProcedureDefGroupEnum.patolojiBilgileri;
        }

        public string MyCategoryName
        {
            get{
                return (string)ProcedureTree.Description.ToString();
            }
        }
        
        public string MyFiredActionDefName
        {
            get{
                return "Pathology";
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
            //Pathology pathology = (Pathology) this.ObjectContext.CreateObject("Pathology");
            //pathology.ActionDate = requestDate;
            //pathology.RequestDate = requestDate;
            //pathology.WorkListDate = requestDate;
            //if (procedureUser != null && procedureUser != Guid.Empty)
            //    pathology.ProcedureDoctor = (ResUser)this.ObjectContext.GetObject(procedureUser, "ResUser");
            //pathology.CurrentStateDefID = Pathology.States.Procedure;
            //pathology.MasterAction = (BaseAction)starterEA;
            //if (emergency == true)
            //    pathology.Emergency = emergency;

            //pathology.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            //pathology.SetMyActionMandatoryProperties();
            //pathology.Update();
            //return (EpisodeAction)pathology;

            PathologyRequest pathologyRequest = (PathologyRequest)ObjectContext.CreateObject("PathologyRequest");
            pathologyRequest.ActionDate = requestDate;
            pathologyRequest.RequestDate = requestDate;
            pathologyRequest.WorkListDate = requestDate;
            if (procedureUser != null && procedureUser != Guid.Empty)
                pathologyRequest.ProcedureDoctor = (ResUser)ObjectContext.GetObject(procedureUser, "ResUser");
            pathologyRequest.CurrentStateDefID = PathologyRequest.States.Request;
            pathologyRequest.MasterAction = (BaseAction)starterEA;
            if (emergency == true)
                pathologyRequest.Emergency = emergency;

            pathologyRequest.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            pathologyRequest.SetMyActionMandatoryProperties();
            if (!fromPatientAdmission)
                pathologyRequest.Update();
            return (EpisodeAction)pathologyRequest;
        }

        public SubActionProcedure  CreateMySubactionProcedure(EpisodeAction ea, ResSection masterRes, ResSection fromRes)
        {
            //Pathology pathology = (Pathology)ea;
            //PathologyTestProcedure  pTest = (PathologyTestProcedure) this.ObjectContext.CreateObject("PathologyTestProcedure");


            //pTest.ProcedureObject = this;
            //pTest.CreationDate = pathology.RequestDate;
            //pTest.ActionDate = pathology.RequestDate;

            //pTest.EpisodeAction = ea;
            //pathology.SubactionProcedures.Add(pTest);

            //if (ea.Emergency== true)
            //    pTest.Emergency = true;

            //return (SubActionProcedure)pTest;

            PathologyRequest pathologyRequest = (PathologyRequest)ea;
            PathologyTestProcedure pTest = (PathologyTestProcedure)ObjectContext.CreateObject("PathologyTestProcedure");


            pTest.ProcedureObject = this;
            pTest.CreationDate = pathologyRequest.RequestDate;
            pTest.ActionDate = pathologyRequest.RequestDate;

            pTest.EpisodeAction = ea;
            pathologyRequest.SubactionProcedures.Add(pTest);

            if (ea.Emergency == true)
                pTest.Emergency = true;

            return (SubActionProcedure)pTest;
        }

        public ActionTypeEnum? GetActionTypeEnum()
        {
            return ActionTypeEnum.Pathology;
        }
        public string GetMyAlertMessage(Guid eaObjectId)
        {
            return null;
        }


        #endregion Methods

    }
}