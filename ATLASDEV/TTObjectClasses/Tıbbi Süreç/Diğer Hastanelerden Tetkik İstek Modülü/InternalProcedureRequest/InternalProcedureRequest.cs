
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
    /// Diğer XXXXXXlerden Tetkik İstek
    /// </summary>
    public  partial class InternalProcedureRequest : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public partial class GetInternalProcedureRequestInfo_Class : TTReportNqlObject 
        {
        }

        
                    
#region Methods
        public InternalProcedureRequest(TTObjectContext objectContext, EpisodeAction episodeAction): this(objectContext)
        {
            ActionDate = DateTime.Now;
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = InternalProcedureRequest.States.Request;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }
        
        public void SendInternalProcedureRequest(Guid remoteSiteID, EpisodeActionWithDiagnosis episodeActionWithDiagnosis, Sites requesterSite, List<SubActionProcedure> subActionProcedures, Guid sourceOrjinalActionObjectID, Guid remoteLabDepartmentID)
        {
            //TODO: Remote metodlar destekleneceği zaman açılabilir.
//            TTObjectContext objectContext = new TTObjectContext(false);
//            Guid savePoint = this.ObjectContext.BeginSavePoint();
//            string messageString = "";
//            try
//            {
//                List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
//                foreach (DiagnosisGrid dg in this.Episode.Diagnosis)
//                {
//                    DiagnosisGrid diagnosisForRemote = dg.PrepareDiagnosisGridForRemoteMethod(true);
//                    diagnosisList.Add(diagnosisForRemote);
//                }
//
//                Patient patient = this.Episode.Patient;
//                EpisodeAction episodeActionForRemote = episodeActionWithDiagnosis.PrepareEpisodeActionForRemoteMethod(true);
//                Episode episodeForRemote = this.Episode.PrepareEpisodeForRemoteMethod(true);
//                PatientAdmission admissionForRemote = this.SubEpisode.PatientAdmission.PreparePatientAdmissionForRemoteMethod(true);
//                
//                ProcedureDefinition procDef;
//                Type type = null;
//                
//                //
//                Type tempType = null;
//                //
//                
//                TTMessage message = null;
//                
//
//                List<SubActionProcedure> proceduresForRemoteList = new List<SubActionProcedure>();
//                foreach(SubActionProcedure subActionProcedure in subActionProcedures)
//                {
//                    SubActionProcedure subActionForRemote = subActionProcedure.PrepareSubActionProcedureForRemoteMethod(true);
//                    subActionForRemote.Eligible = false;
//                    procDef = subActionForRemote.ProcedureObject;
//                    
//                    //Belirtilen type'lar dışındaki hizmetlerin karşı XXXXXXye gitmesi engelleniyor...
//                    tempType = procDef.GetType();
//                    if(tempType.Name == "LaboratoryTestDefinition" || tempType.Name == "RadiologyTestDefinition" || tempType.Name == "PathologyTestDefinition" || tempType.Name == "NuclearMedicineTestDefinition" || tempType.Name == "GeneticTestDefinition")
//                    {
//                        type = procDef.GetType();
//                        proceduresForRemoteList.Add(subActionForRemote);
//                    }
//                    //
//                    
//                    
//                }
//
//                //Type type = procDef.GetType();
//                switch (type.Name)
//                {
//                    case "LaboratoryTestDefinition":
//                        List<LaboratoryProcedure> labProcList = new List<LaboratoryProcedure>();
//                        List<Guid> testDefList = new List<Guid>();
//                        foreach(SubActionProcedure subProc in proceduresForRemoteList)
//                        {
//                            LaboratoryProcedure labProc = (LaboratoryProcedure)subProc;
//                            labProc.TestDefID = subProc.ProcedureObject.ObjectID;
//                            labProcList.Add(labProc);
//                            testDefList.Add(subProc.ProcedureObject.ObjectID);
//                        }
//                        message = LaboratoryRequest.Remo teMethods.SendLaboratoryToSourceHospital(remoteSiteID, patient, episodeForRemote, admissionForRemote, episodeActionForRemote, diagnosisList, requesterSite, labProcList, testDefList, sourceOrjinalActionObjectID, this.Episode.GetMyEpisodeProtocolForRemoteMethod(),remoteLabDepartmentID);
//                        break;
//                    case "RadiologyTestDefinition":
//                        //message = Radiology.Remo teMethods.SendRadiologyToSourceHospital(remoteSiteID, patient, episodeForRemote, admissionForRemote, episodeActionForRemote, diagnosisList, requesterSite, proceduresForRemoteList[0], proceduresForRemoteList[0].ProcedureObject.ObjectID, sourceOrjinalActionObjectID, this.Episode.GetMyEpisodeProtocolForRemoteMethod());
//                        List<RadiologyTest> radiologyTestList = new List<RadiologyTest>();
//                        List<Guid> procedureDefIDList = new List<Guid>();
//                        foreach(SubActionProcedure subProc in proceduresForRemoteList)
//                        {
//                            RadiologyTest radiologyTest = (RadiologyTest)subProc;
//                            radiologyTestList.Add(radiologyTest);
//                            procedureDefIDList.Add(subProc.ProcedureObject.ObjectID);
//                        }
//                        message = Radiology.Remo teMethods.SendRadiologyTestsToTarget(remoteSiteID, patient, episodeForRemote, admissionForRemote, episodeActionForRemote, diagnosisList, requesterSite, radiologyTestList, procedureDefIDList, sourceOrjinalActionObjectID, this.Episode.GetMyEpisodeProtocolForRemoteMethod(), remoteLabDepartmentID);
//                        break;
//                    case "PathologyTestDefinition":
//                        message = Pathology.Remo teMethods.SendPathologyToSourceHospital(remoteSiteID, patient, episodeForRemote, admissionForRemote, episodeActionForRemote, diagnosisList, requesterSite, proceduresForRemoteList[0], proceduresForRemoteList[0].ProcedureObject.ObjectID, sourceOrjinalActionObjectID, this.Episode.GetMyEpisodeProtocolForRemoteMethod());
//                        break;
//                    case "NuclearMedicineTestDefinition":
//                        message = NuclearMedicine.Remo teMethods.SendNuclearMedicineToSourceHospital(remoteSiteID, patient, episodeForRemote, admissionForRemote, episodeActionForRemote, diagnosisList, requesterSite, proceduresForRemoteList[0], proceduresForRemoteList[0].ProcedureObject.ObjectID, sourceOrjinalActionObjectID, this.Episode.GetMyEpisodeProtocolForRemoteMethod());
//                        break;
//                    case "GeneticTestDefinition":
//                        message = null;
//                        break;
//                    default:
//                        message = null;
//                        break;
//                }
//                
//                messageString = message.MessageID.ToString();
//                objectContext.Save();
//            }
//            catch(Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                objectContext.Dispose();
//                this.ObjectContext.RollbackSavePoint(savePoint);
//                this.MessageID = messageString;
//                this.ObjectContext.Save();
//            }
        }
        
        public EpisodeActionWithDiagnosis CreateRequestOfRelatedProcedureDefinition(List<ProcedureDefinition> procedureDefinitions, ResOtherHospital otherHospital)
        {
            Type type = procedureDefinitions[0].GetType();
            switch (type.Name)
            {
                case "LaboratoryTestDefinition":
                    {
                        List<LaboratoryTestDefinition> labReqTestList = new List<LaboratoryTestDefinition>();
                        foreach(ProcedureDefinition procDef in procedureDefinitions)
                        {
                            labReqTestList.Add((LaboratoryTestDefinition)procDef);
                        }
                        return CreateLaboratoryRequest(labReqTestList,otherHospital);
                    }

                case "RadiologyTestDefinition":
                    {
                        //return CreateRadiologyRequest((RadiologyTestDefinition)(procedureDefinitions[0]),otherHospital);
                        List<RadiologyTestDefinition> radiologyTestList = new List<RadiologyTestDefinition>();
                        foreach(ProcedureDefinition procDef in procedureDefinitions)
                        {
                            radiologyTestList.Add((RadiologyTestDefinition)procDef);
                        }
                        return CreateRadilogyRequestWithTestList(radiologyTestList, otherHospital);
                    }
                    

                case "PathologyTestDefinition":
                    return CreatePathologyRequest((PathologyTestDefinition)(procedureDefinitions[0]),otherHospital);
                case "NuclearMedicineTestDefinition":
                    return CreateNuclearRequest((NuclearMedicineTestDefinition)(procedureDefinitions[0]),otherHospital);
                case "GeneticTestDefinition":
                    return CreateGeneticRequest((GeneticTestDefinition)(procedureDefinitions[0]),otherHospital);
                default:
                    return null;
            }
        }

        private EpisodeActionWithDiagnosis CreateRadilogyRequestWithTestList(List<RadiologyTestDefinition> radiologyTestList, ResOtherHospital otherHospital)
        {
            TTObjectContext newContext = new TTObjectContext(false);
            Radiology radiology = new Radiology(newContext, this);

            if (PreDiagnosisString != null && PreDiagnosisString != string.Empty)
                radiology.PreDiagnosis = PreDiagnosisString;

            if (NotesString != null && NotesString != string.Empty)
                radiology.Description = NotesString;

            radiology.CurrentStateDefID = Radiology.States.Request;

            foreach (RadiologyTestDefinition testDef in radiologyTestList)
            {
                RadiologyTest radiologyTest = new RadiologyTest(newContext);
                radiologyTest.MasterResource = otherHospital;
                //bu sitedaki tanımın gönderilmesi hataya yol açdığı için kapatıldı ...
                //radiologyTest.Equipment = testDef.Equipments[0].Equipment;
                //radiologyTest.Department = testDef.Departments[0].Department; //tanımdaki ilk bölümü alır
                radiologyTest.FromResource = MasterResource; //lab'tan istenmiş
                radiologyTest.ProcedureObject = testDef;
                radiologyTest.EpisodeAction = radiology;
                radiologyTest.Amount = 1;
                radiologyTest.CurrentStateDefID = RadiologyTest.States.New;
                radiologyTest.ActionDate = Common.RecTime();
                radiologyTest.Eligible = true;
                radiologyTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
                radiology.RadiologyTests.Add(radiologyTest);
            }
            
            if(RequestDoctor != null)
                radiology.RequestDoctor = RequestDoctor;
            
            newContext.Save();
            radiology.CurrentStateDefID = Radiology.States.Procedure;
            newContext.Save();
            return radiology;
        }
        
        private EpisodeActionWithDiagnosis CreateLaboratoryRequest(List<LaboratoryTestDefinition> labReqTestList, ResOtherHospital otherHospital)
        {
            
            TTObjectContext newContext = new TTObjectContext(false);
            LaboratoryRequest labRequest = new LaboratoryRequest(newContext, this);
            
            if(PreDiagnosisString != null && PreDiagnosisString != string.Empty)
                labRequest.Prediagnosis = PreDiagnosisString;
            
            if(NotesString != null && NotesString != string.Empty)
                labRequest.Notes = NotesString;
            
            labRequest.CurrentStateDefID = LaboratoryRequest.States.New;
            
            if(RequestDoctor != null)
                labRequest.RequestDoctor = RequestDoctor;
            
            foreach(LaboratoryTestDefinition labReqTestDef in labReqTestList)
            {
                LaboratoryProcedure addLabProcedure = new LaboratoryProcedure(newContext);
                addLabProcedure.MasterResource = otherHospital; //tanımdaki ilk bölümü alır
                addLabProcedure.FromResource = addLabProcedure.MasterResource; //lab'tan istenmiş
                addLabProcedure.ProcedureObject = labReqTestDef;
                //LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(labResult.ActionID, "LABORATORYREQUEST");
                addLabProcedure.EpisodeAction = labRequest;
                addLabProcedure.Amount = labReqTestDef.PriceCoefficient == null ? 1 : labReqTestDef.PriceCoefficient;
                addLabProcedure.CurrentStateDefID = LaboratoryProcedure.States.New;
                addLabProcedure.ActionDate = Common.RecTime();
                addLabProcedure.Eligible = true;
                addLabProcedure.RequestedTab = null;
                labRequest.LaboratoryProcedures.Add(addLabProcedure);
            }
            
            newContext.Save();
            labRequest.CurrentStateDefID = LaboratoryRequest.States.Procedure;
            newContext.Save();
            return labRequest;
            //State ilerletme ile ilgili kısım yazılacak
            //if (labResult.IsLastTest && addLabProcedure.Laboratory.CurrentStateDefID == LaboratoryRequest.States.Procedure)
            //    addLabProcedure.Laboratory.CurrentStateDefID = LaboratoryRequest.States.Completed;
        }
        
        private EpisodeActionWithDiagnosis CreateRadiologyRequest(RadiologyTestDefinition testDef,ResOtherHospital otherHospital)
        {
            TTObjectContext newContext = new TTObjectContext(false);
            Radiology radiology = new Radiology(newContext, this);
            
            if(PreDiagnosisString != null && PreDiagnosisString != string.Empty)
                radiology.PreDiagnosis = PreDiagnosisString;
            
            if(NotesString != null && NotesString != string.Empty)
                radiology.Description = NotesString;
            
            radiology.CurrentStateDefID = Radiology.States.Request;
            
            RadiologyTest radiologyTest = new RadiologyTest(newContext);
            radiologyTest.MasterResource = otherHospital;
            //bu sitedaki tanımın gönderilmesi hataya yol açdığı için kapatıldı ...
            //radiologyTest.Equipment = testDef.Equipments[0].Equipment;
            //radiologyTest.Department = testDef.Departments[0].Department; //tanımdaki ilk bölümü alır
            radiologyTest.FromResource = MasterResource; //lab'tan istenmiş
            radiologyTest.ProcedureObject = testDef;
            radiologyTest.EpisodeAction = radiology;
            radiologyTest.Amount = 1;
            radiologyTest.CurrentStateDefID = RadiologyTest.States.New;
            radiologyTest.ActionDate = Common.RecTime();
            radiologyTest.Eligible = true;
            radiology.RadiologyTests.Add(radiologyTest);
            newContext.Save();
            radiologyTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
            radiology.CurrentStateDefID = Radiology.States.Procedure;
            
            if(RequestDoctor != null)
                radiology.RequestDoctor = RequestDoctor;
            
            newContext.Save();
            return radiology;
        }
        
        private EpisodeActionWithDiagnosis CreateNuclearRequest(NuclearMedicineTestDefinition testDef,ResOtherHospital otherHospital)
        {
            TTObjectContext newContext = new TTObjectContext(false);
            NuclearMedicine nuclearMedicine = new NuclearMedicine(newContext, this);
            NuclearMedicineTest nuclearMedicineTest = new NuclearMedicineTest(newContext);
            
            if(PreDiagnosisString != null && PreDiagnosisString != string.Empty)
                nuclearMedicine.PreDiagnosis = PreDiagnosisString;
            
            
            nuclearMedicine.MasterResource = otherHospital; //tanımdaki ilk bölümü alır
            nuclearMedicine.FromResource = MasterResource; //lab'tan istenmiş
            nuclearMedicine.CurrentStateDefID = NuclearMedicine.States.Request;
            //nuclearMedicineTest.ActionDate = Common.RecTime();
            nuclearMedicine.ActionDate = Common.RecTime();
            
            if(RequestDoctor != null)
                nuclearMedicine.RequestDoctor = RequestDoctor;
            
            nuclearMedicineTest.ProcedureObject = testDef;
            nuclearMedicineTest.EpisodeAction = nuclearMedicine;
            nuclearMedicineTest.Amount = 1;
            nuclearMedicineTest.Eligible = true;
            nuclearMedicine.NuclearMedicineTests.Add(nuclearMedicineTest);
            newContext.Save();
            nuclearMedicine.CurrentStateDefID = NuclearMedicine.States.RequestAcception;
            newContext.Save();
            return nuclearMedicine;
            //State ilerletme ile ilgili kısım yazılacak
            //if (labResult.IsLastTest && radiologyTest.Laboratory.CurrentStateDefID == LaboratoryRequest.States.Procedure)
            //    addLabProcedure.Laboratory.CurrentStateDefID = LaboratoryRequest.States.Completed;
        }
        
        private EpisodeActionWithDiagnosis CreatePathologyRequest(PathologyTestDefinition testDef,ResOtherHospital otherHospital)
        {
            TTObjectContext newContext = new TTObjectContext(false);
            PathologyRequest pathologyRequest = new PathologyRequest(newContext, this);
            pathologyRequest.CurrentStateDefID = PathologyRequest.States.Accept;
            pathologyRequest.ActionDate = Common.RecTime();
            pathologyRequest.MasterResource = otherHospital;
            if(RequestDoctor != null)
                pathologyRequest.RequestDoctor = RequestDoctor;
            newContext.Save();

            return pathologyRequest;
            
        }
        
        private EpisodeActionWithDiagnosis CreateGeneticRequest(GeneticTestDefinition testDef,ResOtherHospital otherHospital)
        {
            return null;
        }
        
#endregion Methods

    }
}