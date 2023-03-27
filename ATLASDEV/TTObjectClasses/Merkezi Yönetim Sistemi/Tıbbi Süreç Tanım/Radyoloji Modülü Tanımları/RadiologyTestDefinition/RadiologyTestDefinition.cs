
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
    /// Radyoloji Tetkik Tanımları
    /// </summary>
    public  partial class RadiologyTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public partial class GetRadiologyTestDefinitionNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetRadiologyTestDescriptionReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetRadiologyTestDef_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetradiologyTestDef_WithDate_Class : TTReportNqlObject 
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
        public void LocationArrange()
        {
            //eğer tab seçilmemişse radilogylocation a ekeleme.. (formpostta çağırılıyor)
            
            if((bool) IsActive)
            {
                if (TestTab != null)
                {
                    IList RadiologyLocations = RadiologyLocation.GetByTest(ObjectContext,ObjectID.ToString()  );
                    //ObjectContext.QueryObjects("RadiologyLocation","TEST = " + ConnectionManager.GuidToString(this.ObjectID));
                    
                    if (RadiologyLocations.Count > 0)
                    {
                        RadiologyLocation loc = (RadiologyLocation)  RadiologyLocations[0];
                        loc.Tab = TestTab;
                        loc.OrderNo = TabRow;
                    }
                    else
                    {
                        RadiologyLocation loc = new RadiologyLocation(ObjectContext);
                        loc.Test = this;
                        loc.Tab = TestTab;
                        loc.OrderNo = TabRow;
                    }
                }
                
                else
                {
                    IList RadiologyLocations = RadiologyLocation.GetByTest(ObjectContext,ObjectID.ToString()  );
                    //ObjectContext.QueryObjects("RadiologyLocation","TEST = " + ConnectionManager.GuidToString(this.ObjectID));
                    if (RadiologyLocations.Count > 0)
                    {
                        RadiologyLocation loc = (RadiologyLocation)  RadiologyLocations[0];
                        loc.Tab = TestTab;
                        loc.OrderNo = 0;
                    }
                }
            }
            else
            {
                IList RadiologyLocations = RadiologyLocation.GetByTest(ObjectContext,ObjectID.ToString()  );
                //ObjectContext.QueryObjects("RadiologyLocation","TEST = " + ConnectionManager.GuidToString(this.ObjectID));
                
                if (RadiologyLocations.Count > 0)
                {
                    RadiologyLocation loc = (RadiologyLocation)  RadiologyLocations[0];
                    loc.Tab = null;
                    loc.OrderNo = 0;
                }
            }
        }
        
        public void DeparmentControl(){
            if (Departments.Count < 1) {throw new TTException(SystemMessage.GetMessage(554));}
        }
        
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base. GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("TestSubType");
            localPropertyNamesList.Add("TestTab");
            localPropertyNamesList.Add("TestType");
            localPropertyNamesList.Add("BodyPart");
            localPropertyNamesList.Add("IsHeader");
            localPropertyNamesList.Add("IsPassiveNow");
            localPropertyNamesList.Add("IsRestrictedTest");
            localPropertyNamesList.Add("OnFriday");
            localPropertyNamesList.Add("OnMonday");
            localPropertyNamesList.Add("OnSaturday");
            localPropertyNamesList.Add("OnSunday");
            localPropertyNamesList.Add("OnThursday");
            localPropertyNamesList.Add("OnTuesday");
            localPropertyNamesList.Add("OnWednesday");
            localPropertyNamesList.Add("ProcedureTime");
            localPropertyNamesList.Add("ReasonForPassive");
            localPropertyNamesList.Add("SexControl");
            localPropertyNamesList.Add("TabDescription");
            localPropertyNamesList.Add("TabName");
            localPropertyNamesList.Add("TabRow");
            return localPropertyNamesList;
        }

        public Guid MyStartedStateDefID
        {
            get{
                return (Guid)Radiology.States.Procedure;
            }
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
                return "Radiology";
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
            Radiology radiology = (Radiology)ObjectContext.CreateObject("Radiology");
            radiology.CurrentStateDefID = Radiology.States.Request;
            radiology.ActionDate = requestDate;
            radiology.RequestDate = requestDate;
            if (procedureUser != null && procedureUser != Guid.Empty)
                radiology.ProcedureDoctor = (ResUser)ObjectContext.GetObject(procedureUser, "ResUser");
            radiology.WorkListDate = requestDate;
            radiology.MasterAction = (BaseAction)starterEA;

            int[] doctorType = new int[3] { 0, 2, 17 };

            if (Common.CurrentResource.TakesPerformanceScore == true && doctorType.Contains((int)Common.CurrentResource.UserType))
            {

                radiology.RequestDoctor = Common.CurrentResource;
            }
            else
            {
                if (starterEA.ProcedureDoctor != null)
                {
                    radiology.RequestDoctor = starterEA.ProcedureDoctor;
                }
                else
                    radiology.RequestDoctor = Common.CurrentResource;

            }

            if (emergency == true)
                radiology.Emergency = emergency;

            radiology.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            if (!fromPatientAdmission)
                radiology.Update();


            return (EpisodeAction)radiology;
        }

        public SubActionProcedure  CreateMySubactionProcedure(EpisodeAction ea, ResSection masterRes, ResSection fromRes)
        {
           
            Radiology radiology = (Radiology)ea;
            RadiologyTest rTest = (RadiologyTest)ObjectContext.CreateObject("RadiologyTest");
            RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)this;

            rTest.ProcedureObject = this;
            rTest.EpisodeAction = radiology;
            SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(radiology, masterRes, fromRes, rTest);
            if (radTestDef.Equipments.Count > 0)
                rTest.Equipment = radTestDef.Equipments[0].Equipment; //ilk tanımlı cihazı alır
            if (radTestDef.Departments.Count > 0)
                rTest.Department = (ResRadiologyDepartment)radiology.MasterResource;

            rTest.RequestDate = radiology.RequestDate;
            rTest.CreationDate = radiology.RequestDate;
            rTest.ActionDate = radiology.RequestDate;
            rTest.RequestedByUser = Common.CurrentResource;
            rTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;

            if (radiology.ToothNumber != null)
                rTest.ToothNumber = ((int)radiology.ToothNumber).ToString();
            rTest.RadiologyRequestNo.GetNextValue();

            //PACS icin AccesionNumber alması gerekiyor
            //PACS entegre calismayan testler icin numara alinmayacak
            if (radTestDef.IsRISEntegratedTest == true)
            {
                //rTest.AccessionNo.GetNextValue();
                Guid AccessionNumber = new Guid("a40495b0-9265-432c-9467-f2b14f3b020c");
                rTest.AccessionNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[AccessionNumber], null, null).ToString();
            }

            foreach (RadiologyGridMaterialDefinition defMaterialGrid in radTestDef.Materials)
            {
                RadiologyMaterial radMaterial = new RadiologyMaterial(ObjectContext);
                radMaterial.Amount = defMaterialGrid.Amount;
                radMaterial.Material = defMaterialGrid.Material;
                radMaterial.EpisodeAction = ea;
                rTest.RadiologyTestTreatmentMaterial.Add(radMaterial);
            }

            if (ea.Emergency == true)
                rTest.Emergency = true;

            #region ÇUBUK MR Entegrasyon
            Episode e = rTest.ObjectContext.GetObject(rTest.Episode.ObjectID, typeof(Episode)) as Episode;

            if (e.Patient != null && e.Patient.UniqueRefNo != null && rTest.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)//alınan kabul tipi hizmet protokol ise dış XXXXXX ile ilişkilendir
            {
                List<ExternalProviderServiceRequest> serviceRequestsList = ExternalProviderServiceRequest.GetExtProviderByUniqueRefNo(rTest.ObjectContext, e.Patient.UniqueRefNo.Value).ToList<ExternalProviderServiceRequest>();
                foreach (ExternalProviderServiceRequest serviceRequest in serviceRequestsList)
                {
                    if (rTest.ProcedureObject.SUTCode == serviceRequest.ProcedureCode)
                    {
                        rTest.GeneralDescription = serviceRequest.ClinicalInformation;

                        if (serviceRequest.AdmitDate.HasValue)
                        {
                            rTest.RequestDate = serviceRequest.AdmitDate.Value;
                            rTest.AccessionNo = serviceRequest.PlacerOrderNumber.Split('^').FirstOrDefault(); //Entegrasyondan gelen accessionna alınacak.
                        }
                        serviceRequest.RadiologyTest = rTest; //radıologytest
                    }

                }
            }
            #endregion

            radiology.SubactionProcedures.Add(rTest);

            //Radyoloji istem yapildigi anda RadiologyTest icin queue ya satir atilmayacak. asagidaki blok kapatildi.
            //if (ea.SubEpisode.PatientAdmission != null)
            //{
            //    IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(this.ObjectContext, masterRes.ObjectID.ToString());
            //    if (myQueue.Count > 0)
            //        rTest.CreateExaminationQueueItem(ea.SubEpisode.PatientAdmission, myQueue[0], (Boolean)ea.Emergency);
            //}

            return (SubActionProcedure)rTest;
            
        }

        public ActionTypeEnum? GetActionTypeEnum()
        {
            return ActionTypeEnum.Radiology;
        }

        public override void SetProcedureType()
        {
            ProcedureType = ProcedureDefGroupEnum.tetkikveRadyolojiBilgileri;
        }

        public string GetMyAlertMessage(Guid eaObjectId)
        {
            if (TestType != null)
            {
                if (TestType.Name == "MR" || TestType.Name == "CT" || TestType.Name == "CR")
                {
                    EpisodeAction ea = (EpisodeAction)ObjectContext.GetObject(eaObjectId, "EpisodeAction");
                    if (ea != null)
                    {
                        if (ea.Episode.Patient != null)
                        {
                            Patient p = ea.Episode.Patient;
                            if (p.MedicalInformation != null)
                            {
                                string msg = null;
                                string allergyMsg = null;
                                string medInfo = null;

                                if (p.MedicalInformation.Pregnancy == true)
                                    medInfo = medInfo + "Gebelik durumu, ";
                                if (p.MedicalInformation.MetalImplant == true)
                                    medInfo = medInfo + "Metal İmplantı, ";
                                if (p.MedicalInformation.CardiacPacemaker == true)
                                    medInfo = medInfo + "Kalp Pili ";

                                if (medInfo != null)
                                    msg = "Hastanın " + medInfo + TTUtils.CultureService.GetText("M25350", "bulunmaktadır!<br/>");

                                if (TestType.Name == "CT")
                                {
                                    if (p.MedicalInformation.MedicalInfoAllergies != null)
                                    {
                                        if (p.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies != null)
                                        {
                                            string contrastMaterial = SystemParameter.GetParameterValue("RADIOLOGYREQUESTCONTRASTMATERIAL", "2628");
                                            string[] constrastMaterialList = contrastMaterial.Split(',');

                                            if (constrastMaterialList != null)
                                            {
                                                string allergyInfo = null;
                                                for (int i = 0; i < constrastMaterialList.Length; i++)
                                                {
                                                    foreach (MedicalInfoDrugAllergies drugInfo in p.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies)
                                                    {
                                                        if (drugInfo.ActiveIngredient.Code == constrastMaterialList[i])
                                                        {
                                                            allergyInfo = allergyInfo + drugInfo.ActiveIngredient.Name + ",";
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (allergyInfo != null)
                                                    allergyMsg = "Hastanın Kontrast Madde alerjisi (" + allergyInfo + ") bulunmaktadır!<br/>";
                                            }
                                        }
                                    }
                                }
                                return msg + allergyMsg;
                            }
                        }
                    }
                }
            }
         
            return null;
        }
        #endregion Methods

    }
}