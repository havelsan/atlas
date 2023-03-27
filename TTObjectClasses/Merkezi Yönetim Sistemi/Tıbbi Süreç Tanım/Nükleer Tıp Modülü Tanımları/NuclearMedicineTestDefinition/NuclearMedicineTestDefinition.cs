
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
    /// Nükleer Tıp Tetkik Tanımları
    /// </summary>
    public partial class NuclearMedicineTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public partial class NuclearMedicineTestDefFormNQL_Class : TTReportNqlObject
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

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.NuclearMedicineTestDefinitionInfo;
        }

        public override void SetProcedureType()
        {
            ProcedureType = ProcedureDefGroupEnum.nukleerTipbilgileri;
        }

        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if (localPropertyNamesList == null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("NuclearMedicineDepartment");
            localPropertyNamesList.Add("TestGroup");
            return localPropertyNamesList;
        }




        public Guid MyStartedStateDefID
        {
            get
            {
                return (Guid)NuclearMedicine.States.RequestAcception;
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
                return "NuclearMedicine";
            }
        }

        public bool IsProcedureFlowStarts
        {
            get
            {
                return true;
            }
        }

        private static string StripHTML(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", String.Empty);
        }

        public EpisodeAction CreateMyEpisodeAction(EpisodeAction starterEA, ResSection masterRes, ResSection fromRes, bool setMasterAction, bool emergency, DateTime requestDate, Guid procedureUser, bool fromPatientAdmission)
        {
            NuclearMedicine nuclearMedicineAct = (NuclearMedicine)ObjectContext.CreateObject("NuclearMedicine");
            nuclearMedicineAct.CurrentStateDefID = NuclearMedicine.States.Request;
            nuclearMedicineAct.ActionDate = requestDate;
            nuclearMedicineAct.RequestDate = requestDate;
            nuclearMedicineAct.WorkListDate = requestDate;

            nuclearMedicineAct.MasterAction = (BaseAction)starterEA;
            nuclearMedicineAct.RequestDoctor = Common.CurrentResource;
            if (emergency == true)
                nuclearMedicineAct.Emergency = emergency;

            string clinicAnemnesisStr = string.Empty;

            if (((TTObjectClasses.PhysicianApplication)starterEA).Complaint != null)
            {
                string complaintStr = StripHTML(((TTObjectClasses.PhysicianApplication)starterEA).Complaint.ToString());
                clinicAnemnesisStr += "Şikayeti: " + complaintStr + "\n";
            }

            if (((TTObjectClasses.PhysicianApplication)starterEA).PatientHistory != null)
            {
                string patientHistoryStr = StripHTML(((TTObjectClasses.PhysicianApplication)starterEA).PatientHistory.ToString());
                clinicAnemnesisStr += "Özgeçmişi: " + patientHistoryStr + "\n";
            }

            if (((TTObjectClasses.PhysicianApplication)starterEA).PhysicalExamination != null)
            {
                string physicalExaminationStr = StripHTML(((TTObjectClasses.PhysicianApplication)starterEA).PhysicalExamination.ToString());
                clinicAnemnesisStr += "Fiziki Muayene: " + physicalExaminationStr + "\n";
            }

            if (((TTObjectClasses.PhysicianApplication)starterEA).MTSConclusion != null)
            {
                string mtsConclusionStr = StripHTML(((TTObjectClasses.PhysicianApplication)starterEA).MTSConclusion.ToString());
                clinicAnemnesisStr += "Tedavi Kararı: " + mtsConclusionStr + "\n";
            }


            if (!String.IsNullOrEmpty(clinicAnemnesisStr))
            {
                nuclearMedicineAct.PreDiagnosis = clinicAnemnesisStr;
            }

            nuclearMedicineAct.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            if(!fromPatientAdmission)
            nuclearMedicineAct.Update();
            return (EpisodeAction)nuclearMedicineAct;
        }

        public SubActionProcedure CreateMySubactionProcedure(EpisodeAction ea, ResSection masterRes, ResSection fromRes)
        {

            NuclearMedicine nuclearMedicine = (NuclearMedicine)ea;
            NuclearMedicineTest nTest = (NuclearMedicineTest)ObjectContext.CreateObject("NuclearMedicineTest");
            NuclearMedicineTestDefinition nTestDef = (NuclearMedicineTestDefinition)this;

            nTest.ProcedureObject = this;
            nTest.EpisodeAction = nuclearMedicine;
            nTest.CreationDate = nuclearMedicine.RequestDate;
            nTest.ActionDate = nuclearMedicine.RequestDate;
            nTest.RequestedByUser = nuclearMedicine.RequestDoctor;



            foreach (NuclearMedicineGridMaterialDefinition defMaterialGrid in nTestDef.Materials)
            {
                NucMedTreatmentMat nucMaterial = new NucMedTreatmentMat(ObjectContext);
                nucMaterial.Amount = 1;
                nucMaterial.Material = defMaterialGrid.Material;
                nucMaterial.EpisodeAction = nuclearMedicine;
                nTest.NuclearMedicine.NucMedTreatmentMats.Add(nucMaterial);
            }

            if (ea.Emergency == true)
                nTest.Emergency = true;

            nuclearMedicine.SubactionProcedures.Add(nTest);
            return (SubActionProcedure)nTest;

        }
        public ActionTypeEnum? GetActionTypeEnum()
        {
            return ActionTypeEnum.NuclearMedicine;
        }

        public string GetMyAlertMessage(Guid eaObjectId)
        {
            return null;
        }

        #endregion Methods

    }
}