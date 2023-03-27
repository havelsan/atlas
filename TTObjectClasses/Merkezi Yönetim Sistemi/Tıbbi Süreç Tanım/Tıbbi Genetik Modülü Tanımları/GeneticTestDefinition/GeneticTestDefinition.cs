
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
    public  partial class GeneticTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public partial class GeneticTestDefFormNQL_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetGeneticTestDef_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetGeneticTestDef_WithDate_Class : TTReportNqlObject 
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

        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("Department");
            return localPropertyNamesList;
        }
        
        
           public Guid MyStartedStateDefID
        {
            get
            {
                return (Guid)Genetic.States.RequestAcception;
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
                return "Genetic";
            }
        }

        public bool IsProcedureFlowStarts
        {
            get
            {
                return true;
            }
        }

        public EpisodeAction CreateMyEpisodeAction(EpisodeAction starterEA, ResSection masterRes, ResSection fromRes, bool setMasterAction, bool emergency, DateTime requestDate, Guid procedureUser, bool fromPatientAdmission)
        {

            Genetic geneticAct = (Genetic)ObjectContext.CreateObject("Genetic");
            geneticAct.CurrentStateDefID = Genetic.States.Request;
            geneticAct.ActionDate = requestDate;
            geneticAct.RequestDate = requestDate;
            geneticAct.WorkListDate = requestDate;
            if (procedureUser != null && procedureUser != Guid.Empty)
                geneticAct.ProcedureDoctor = (ResUser)ObjectContext.GetObject(procedureUser, "ResUser");
            geneticAct.MasterAction = (BaseAction)starterEA;
            if (emergency == true)
                geneticAct.Emergency = emergency;

            geneticAct.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            geneticAct.SetMyActionMandatoryProperties();
            if (!fromPatientAdmission)
                geneticAct.Update();

            return (EpisodeAction)geneticAct;

        }

        public SubActionProcedure CreateMySubactionProcedure(EpisodeAction ea, ResSection masterRes, ResSection fromRes)
        {

            Genetic geneticAct = (Genetic)ea;
            GeneticTest genTest = (GeneticTest)ObjectContext.CreateObject("GeneticTest");
            GeneticTestDefinition genTestDef = (GeneticTestDefinition)this;

            genTest.ProcedureObject = this;
            genTest.EpisodeAction = geneticAct;
            genTest.CreationDate = geneticAct.RequestDate;
            genTest.ActionDate = geneticAct.RequestDate;

            foreach (GeneticGridMaterialDefinition geneticMaterial in genTestDef.GeneticGridMaterialDefinitions)
                    {
                        BaseTreatmentMaterial newMaterial = new BaseTreatmentMaterial(geneticAct.ObjectContext);
                        newMaterial.Material = geneticMaterial.Material;
                        newMaterial.EpisodeAction = geneticAct;
                    }
                    foreach (GeneticGridEquipmentDefinition equipmentDef in genTestDef.Equipment)
                    {
                        GeneticEquipment myEquipment = new GeneticEquipment(geneticAct.ObjectContext);
                        myEquipment.Equipment = (ResGeneticEqiupmentDef)equipmentDef.MyEquipment;
                        geneticAct.UsedEquipments.Add(myEquipment);
                    }

            if (ea.Emergency == true)
                genTest.Emergency = true;

            geneticAct.SubactionProcedures.Add(genTest);
            return (SubActionProcedure)genTest;

        }
        public ActionTypeEnum? GetActionTypeEnum()
        {
            return ActionTypeEnum.Genetic;
        }

        public string GetMyAlertMessage(Guid eaObjectId)
        {
            return null;
        }

        #endregion Methods

    }
}