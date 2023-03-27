
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class BaseNewDoctorExaminationForm : EpisodeActionForm
    {
        protected override void PreScript()
        {
#region BaseNewDoctorExaminationForm_PreScript
    base.PreScript();
#endregion BaseNewDoctorExaminationForm_PreScript

            }
            
#region BaseNewDoctorExaminationForm_Methods
        /// <summary>
        /// Sağlık Kurulu İşlemleri tabını doldurur.
        /// </summary>
        public void FillHealthCommiteeActionsGrid(ITTGrid HealthCommiteeActions)
        {
            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)this._EpisodeAction.ObjectContext.GetObject(hospID, typeof(ResHospital));
            BindingList<HealthCommittee> healthCommiteeList;
            //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            //    healthCommiteeList = HealthCommittee.GetAllHealthCommiteesOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            //else
                healthCommiteeList = HealthCommittee.GetHealthCommiteesOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.ToString());

            foreach (HealthCommittee healthCommittee in healthCommiteeList)
            {
                ITTGridRow gridRow = HealthCommiteeActions.Rows.Add();
                gridRow.Cells["Hospital"].Value = hospital.Name; //şimdilik şu anki XXXXXXnin ismini getiriyor.
                gridRow.Cells["HealthCommiteeActionID"].Value = (healthCommittee.ID != null ? healthCommittee.ID.ToString() : "");
                gridRow.Cells["HealthCommiteeActionDate"].Value = healthCommittee.ActionDate;
                gridRow.Cells["HCObjectID"].Value = healthCommittee.ObjectID.ToString();
            }
        }

        /// <summary>
        /// Tıbbi Cerrahi Uygulamalar gridini doldurur.
        /// </summary>
        public void FillOldManipulationsGrid(ITTGrid ManipulationGrid)
        {
            BindingList<ManipulationProcedure> manipulationProcedureList;

            //            if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            //                manipulationProcedureList = ManipulationProcedure.GetAllManipulationProceduresOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            //            else
            manipulationProcedureList = ManipulationProcedure.GetManipulationProceduresOfEpisode(this._EpisodeAction.ObjectContext, _EpisodeAction.Episode.ObjectID.ToString());
            
            foreach (ManipulationProcedure mp in manipulationProcedureList)
            {
                ITTGridRow gridRow = ManipulationGrid.Rows.Add();
                gridRow.Cells["ManipulationActionDate"].Value = mp.ActionDate;
                if (mp.ProcedureObject != null)
                    gridRow.Cells["ProcedureObject"].Value = mp.ProcedureObject.ObjectID;
                gridRow.Cells["Emergency"].Value = mp.Emergency;
                if (mp.ProcedureDepartment != null)
                    gridRow.Cells["Department"].Value = mp.ProcedureDepartment.ObjectID;//emin değilim
                if (mp.ProcedureDoctor != null)
                    gridRow.Cells["ManipulationDoctor"].Value = mp.ProcedureDoctor.ObjectID;
                gridRow.Cells["Description"].Value = mp.Description;
            }
        }

        /// <summary>
        /// Tetkik Sonuç doldurur.
        /// </summary>
        public void FillLaboratoryResultsGrid(ITTGrid LaboratoryResultsGrid)
        {
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MaxValue;
            LaboratoryResultsGrid.Rows.Clear();

            BindingList<SubActionProcedure> testProcedureList;
            // akıllı kart devreye girdiğinde commentler açılacaktır
            // if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            testProcedureList = SubActionProcedure.GetTestsByPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString(), Common.RecTime().AddMonths(-3));
            //            else
            //            {
            //                InfoBox.Show("Hastanın Akıllı Kartı Takılı olmadığı için yalnızca bu vakaya ait Tetkikler Listelenecektir");
            //                testProcedureList = SubActionProcedure.GetTestsByEpisode(this._EpisodeAction.ObjectContext, subactionObjectDefName, testProcedureObjectID, this._EpisodeAction.Episode.ObjectID.ToString());
            //            }
            foreach (SubActionProcedure testProcedure in testProcedureList)
            {
                // rapor için parametre
                if (testProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    ITTGridRow gridRow = LaboratoryResultsGrid.Rows.Add();
                    gridRow.Cells["ProcedureDate"].Value = testProcedure.WorkListDate;
                    gridRow.Cells["Procedure"].Value = (testProcedure.ProcedureObject != null ? testProcedure.ProcedureObject.Name : "");
                    if (testProcedure is GeneticTest)
                        gridRow.Cells["ProcedureResult"].Value = ((GeneticTest)testProcedure).Genetic.Report;
                    else if (testProcedure is NuclearMedicineTest)
                        gridRow.Cells["ProcedureResult"].Value = ((NuclearMedicineTest)testProcedure).NuclearMedicine.Report;
                    else if (testProcedure is LaboratoryProcedure)
                        gridRow.Cells["ProcedureResult"].Value = Common.GetRTFOfTextString(((LaboratoryProcedure)testProcedure).Result);
                    //TODO ASLI pathologymaterial
                    //else if (testProcedure is PathologyTestProcedure) 
                    //{
                    //    string patReports = "Makroskopi Raporu\r\n" + Common.GetTextOfRTFString(((PathologyTestProcedure)testProcedure).Pathology.ReportMacroscopi.ToString()) + "\r\n";
                    //    patReports += "Mikroskopi Raporu\r\n" + Common.GetTextOfRTFString(((PathologyTestProcedure)testProcedure).Pathology.ReportMicroscopi.ToString()) + "\r\n";
                    //    patReports += "Doku İşlemi\r\n" + Common.GetTextOfRTFString(((PathologyTestProcedure)testProcedure).Pathology.ReportTissueProcedure.ToString()) + "\r\n";
                    
                    //    gridRow.Cells["ProcedureResult"].Value = Common.GetRTFOfTextString(patReports);
                    //}
                    else if (testProcedure is RadiologyTest)
                        gridRow.Cells["ProcedureResult"].Value = ((RadiologyTest)testProcedure).Report;
                    gridRow.Cells["ObjectID"].Value = testProcedure.ObjectID;
                }
            }
        }

        /// <summary>
        /// Konsültasyon gridini doldurur.
        /// </summary>
        public void FillOldConsultationsGrid(ITTGrid ConsultationGrid)
        {
            BindingList<EpisodeAction> consFromOtherHospList;

            //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            //    consFromOtherHospList = EpisodeAction.GetAllConsFromOtherHospOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            //else
                consFromOtherHospList = EpisodeAction.GetConsFromOtherHospOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.ToString());
            foreach (EpisodeAction ea in consFromOtherHospList)
            {
                ITTGridRow gridRow = ConsultationGrid.Rows.Add();
                gridRow.Cells["ConsultationDate"].Value = ea.ActionDate;
                if (ea is ConsultationFromOtherHospital)
                {
                    ConsultationFromOtherHospital consFromOtherHosp = (ConsultationFromOtherHospital)ea;
                    if (consFromOtherHosp.RequesterHospital != null)
                        gridRow.Cells["RequesterHospital"].Value = consFromOtherHosp.RequesterHospital.Name;
                    gridRow.Cells["RequesterDepartment"].Value = consFromOtherHosp.RequesterResourceName;
                    if (consFromOtherHosp.RequestedReferableHospital != null && consFromOtherHosp.RequestedReferableHospital.ResOtherHospital != null)
                        gridRow.Cells["RequestedHospital"].Value = consFromOtherHosp.RequestedReferableHospital.ResOtherHospital.Name;
                    else if (consFromOtherHosp.RequestedExternalHospital != null)
                        gridRow.Cells["RequestedHospital"].Value = consFromOtherHosp.RequestedExternalHospital.Name;
                    if (consFromOtherHosp.RequestedReferableResource != null)
                        gridRow.Cells["RequestedDepartment"].Value = consFromOtherHosp.RequestedReferableResource.ResourceName;
                    else if (consFromOtherHosp.RequestedExternalDepartment != null)
                        gridRow.Cells["RequestedDepartment"].Value = consFromOtherHosp.RequestedExternalDepartment.Name;
                    gridRow.Cells["RequestReason"].Value = Common.GetRTFOfTextString(consFromOtherHosp.RequestDescription);
                    if (consFromOtherHosp.ConsultationResultAndOffers != null)
                        gridRow.Cells["ConsultationResultAndOffer"].Value = Common.GetRTFOfTextString(consFromOtherHosp.ConsultationResultAndOffers.ToString());
                }
            }

            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)this._EpisodeAction.ObjectContext.GetObject(hospID, typeof(ResHospital));
            BindingList<Consultation> consList = Consultation.GetAllConsultationsOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            foreach (Consultation cons in consList)
            {
                ITTGridRow gridRow = ConsultationGrid.Rows.Add();
                gridRow.Cells["ConsultationDate"].Value = cons.ActionDate;
                    if (hospital != null)
                    {
                        gridRow.Cells["RequesterHospital"].Value = hospital.Name;
                        gridRow.Cells["RequestedHospital"].Value = hospital.Name;
                    }
           
                    gridRow.Cells["RequesterDepartment"].Value = (cons.RequesterResource != null ? cons.RequesterResource.Name : "");
                    gridRow.Cells["RequestedDepartment"].Value = (cons.MasterResource != null ? cons.MasterResource.Name : "");
                    gridRow.Cells["RequestReason"].Value = cons.RequestDescription;
                    gridRow.Cells["ConsultationResultAndOffer"].Value = cons.ConsultationResultAndOffers;
                
            }

            //BindingList<EpisodeAction> anesthesiaConsList = EpisodeAction.GetAllAnesthesiaConsultationOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            //foreach (EpisodeAction ea in anesthesiaConsList)
            //{
            //    ITTGridRow gridRow = ConsultationGrid.Rows.Add();
            //    gridRow.Cells["ConsultationDate"].Value = ea.ActionDate;
            //    if (ea is AnesthesiaConsultation)
            //    {
            //        AnesthesiaConsultation anesthesiaConsultation = (AnesthesiaConsultation)ea;
            //        if (hospital != null)
            //        {
            //            gridRow.Cells["RequesterHospital"].Value = hospital.Name;
            //            gridRow.Cells["RequestedHospital"].Value = hospital.Name;
            //        }
            //        gridRow.Cells["RequesterDepartment"].Value = (anesthesiaConsultation.FromResource != null ? anesthesiaConsultation.FromResource.Name : "");
            //        gridRow.Cells["RequestedDepartment"].Value = (anesthesiaConsultation.MasterResource != null ? anesthesiaConsultation.MasterResource.Name : "");
            //        gridRow.Cells["RequestReason"].Value = anesthesiaConsultation.ConsultationRequestNote;
            //        gridRow.Cells["ConsultationResultAndOffer"].Value = anesthesiaConsultation.ConsultationResult;
            //    }
            //}
            var a = 1;
        }


        
        /// <summary>
        /// Muayene Bulguları gridini doldurur.
        /// </summary>
        public void FillOldPhysicianExaminationsGrid(ITTGrid PhysicianExaminationsGrid)
        {
            BindingList<EpisodeAction> examList = EpisodeAction.GetAllExaminationsOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());

            object examinationIndication = null;
            foreach (EpisodeAction ea in examList)
            {
                if (ea is PatientExamination)
                {
                    PatientExamination pa = (PatientExamination)ea;
                    examinationIndication = pa.PhysicalExamination;
                }
                else if (ea is FollowUpExamination)
                {
                    FollowUpExamination fe = (FollowUpExamination)ea;
                    examinationIndication = fe.PhysicalExamination;
                }
                else if (ea is InPatientPhysicianApplication)
                {
                    InPatientPhysicianApplication ippa = (InPatientPhysicianApplication)ea;
                    examinationIndication = ippa.PhysicalExamination;
                }

                if (examinationIndication != null)
                {
                    ITTGridRow gridRow = PhysicianExaminationsGrid.Rows.Add();
                    gridRow.Cells["ExaminationDateTime"].Value = ea.ActionDate.Value;
                    gridRow.Cells["ExaminationIndication"].Value = examinationIndication;
                }
            }
        }
        
#endregion BaseNewDoctorExaminationForm_Methods

#region BaseNewDoctorExaminationForm_ClientSideMethods
        /// <summary>
        /// Yeni Ayaktan Hasta Reçetesi isteği başlatır.
        /// </summary>
        public void CreateNewOutPatientPrescription()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //if (this._EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            //{
            //    string presccriptionType;
            //    //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //    //TTObjectContext objectContext = new TTObjectContext(false);

            //    string bransKodu = _EpisodeAction.ProcedureDoctor.GetSpeciality() != null ?  _EpisodeAction.ProcedureDoctor.GetSpeciality().Code : "0" ;

            //    if(bransKodu == "2900")
            //    {
            //        MultiSelectForm pForm = new MultiSelectForm();
            //        pForm.AddMSItem("Ayaktan Hasta Reçetesi", "Ayaktan Hasta Reçetesi");
            //        pForm.AddMSItem("Gözlük Reçetesi", "Gözlük Reçetesi");
            //        presccriptionType = pForm.GetMSItem(this, "Reçete Seçiniz");
            //        pForm.ClearMSItems();
            //        if(presccriptionType == "Ayaktan Hasta Reçetesi")
            //        {
            //            this.CreateOutPatientPrescription(this._EpisodeAction.ObjectContext);
            //        }
            //        else if(presccriptionType == "Gözlük Reçetesi")
            //        {
            //            GlassesReport glassesReport;
            //            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //            try
            //            {
            //                glassesReport = new GlassesReport(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //                TTForm frm = TTForm.GetEditForm(glassesReport);
            //                this.PrapareFormToShow(frm);
            //                if (frm.ShowEdit(this.FindForm(), glassesReport) != DialogResult.OK)
            //                    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //                else
            //                    this._EpisodeAction.ObjectContext.Save();
            //            }
            //            catch (Exception ex)
            //            {
            //                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //                InfoBox.Show(ex);
            //            }
            //            finally
            //            {
            //                // objectContext.Dispose();
            //            }
            //        }
            //        else
            //        {
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        CreateOutPatientPrescription(this._EpisodeAction.ObjectContext);
            //    }
            //}
            //else
            //{
            //    InfoBox.Show("Ayaktan Hasta Reçetesi sadece ayaktan hastaya başlatılır.");
            //    return;
            //}
            var a = 1;

        }
        

        public void CreateOutPatientPrescription(TTObjectContext objectContext)
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //OutPatientPrescription outPatientPrescription;
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    outPatientPrescription = new OutPatientPrescription(objectContext, this._EpisodeAction);
            //    //glassesReport = new GlassesReport(objectContext);
            //    TTForm frm = TTForm.GetEditForm(outPatientPrescription);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), outPatientPrescription) == DialogResult.OK)
            //        objectContext.Save();
            //    else
            //        objectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    objectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //episodeAction ın context i gönderildiği zaman dispose etmek doğru değil.
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        /// Yeni Laboratuvar isteği başlatır.
        /// </summary>
        public void CreateNewLaboratoryRequest(TTObjectDef objDef, Guid? resSectionGuid)
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    EpisodeAction testRequest = null;
            //    if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(Genetic)).ID)
            //        testRequest = new Genetic(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)).ID)
            //    {
            //        if (resSectionGuid != null)
            //        {
            //            ResSection resSection = (ResSection)_EpisodeAction.ObjectContext.GetObject((Guid)resSectionGuid, typeof(ResSection).Name);
            //            testRequest = new LaboratoryRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction, resSection);
            //        }
            //        else
            //            testRequest = new LaboratoryRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    }
            //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(NuclearMedicine)).ID)
            //        testRequest = new NuclearMedicine(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyRequest)).ID)
            //        testRequest = new PathologyRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(Radiology)).ID)
            //        testRequest = new Radiology(this._EpisodeAction.ObjectContext, this._EpisodeAction);

            //    TTForm frm = TTForm.GetEditForm(testRequest);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), testRequest) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        /// Yeni Manipulasyon isteği başlatır.
        /// </summary>
        public void CreateNewManipulationRequest()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //ManipulationRequest manipulationRequest;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    manipulationRequest = new ManipulationRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(manipulationRequest);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), manipulationRequest) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        /// Yeni Adli Rapor isteği başlatır.
        /// </summary>
        public void CreateNewForensicMedicalReport()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //ForensicMedicalReport forensicMedicalReport;
            //TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    forensicMedicalReport = new ForensicMedicalReport(objectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(forensicMedicalReport);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), forensicMedicalReport) == DialogResult.OK)
            //        objectContext.Save();
            //    else
            //        objectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    objectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        /// Yeni Epikriz Raporu isteği başlatır.
        /// </summary>
        public void CreateNewEpicrisisReport()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //CreatingEpicrisis epicrisisReport;
            //CreatingEpicrisis tempEpicrisisReport;
            //TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    InPatientPhysicianApplication inPatientPhysicianApplication = null;
            //    if (this._EpisodeAction is InPatientPhysicianApplication)
            //        inPatientPhysicianApplication = (InPatientPhysicianApplication)this._EpisodeAction;
            //    else
            //    {
            //        foreach (EpisodeAction ea in _EpisodeAction.Episode.EpisodeActions)
            //        {
            //            if (ea is InPatientPhysicianApplication && ea.CurrentStateDefID == CreatingEpicrisis.States.Completed)
            //                inPatientPhysicianApplication = (InPatientPhysicianApplication)ea;
            //        }
            //    }

            //    // if (this._EpisodeAction.Episode.MainSpeciality.Code == "4400")

            //    if (inPatientPhysicianApplication != null || this._EpisodeAction.Episode.MainSpeciality.Code == "4400")
            //    {
            //        if (this._EpisodeAction.Episode.MainSpeciality.Code != null && this._EpisodeAction.Episode.MainSpeciality.Code == "4400")
            //        {
            //            if (inPatientPhysicianApplication == null)
            //            {
            //                epicrisisReport = new CreatingEpicrisis(objectContext, this._EpisodeAction);
            //                TTForm frm = TTForm.GetEditForm(epicrisisReport);
            //                this.PrapareFormToShow(frm);

            //                if (frm.ShowEdit(this.FindForm(), epicrisisReport) == DialogResult.OK)
            //                {
            //                    objectContext.Save();
            //                }

            //            }
            //        }
            //        else
            //        {
            //            if (inPatientPhysicianApplication.MyEpicrisisReport() == null)
            //            {
            //                epicrisisReport = new CreatingEpicrisis(objectContext, this._EpisodeAction);
            //            }
            //            else
            //            {
            //                tempEpicrisisReport = inPatientPhysicianApplication.MyEpicrisisReport();
            //                epicrisisReport = (CreatingEpicrisis)objectContext.GetObject(tempEpicrisisReport.ObjectID, "CreatingEpicrisis");
            //            }


            //            TTForm frm = TTForm.GetEditForm(epicrisisReport);
            //            this.PrapareFormToShow(frm);
            //            if (frm.ShowEdit(this.FindForm(), epicrisisReport) == DialogResult.OK)
            //                objectContext.Save();
            //        }
            //    }
            //    else
            //    {
            //        InfoBox.Show("Hastanın Klinik Doktor İşlemlerine Bulunmamakta.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        ///Sağlık Kurulu Rapor isteği başlatır.
        /// </summary>
        public void CreateNewHealthCommittee()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //HealthCommittee healthCommittee;
            //TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    healthCommittee = new HealthCommittee(objectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(healthCommittee);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), healthCommittee) == DialogResult.OK)
            //        objectContext.Save();
            //}
            //catch (Exception ex)
            //{
            //    objectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        ///Diğer birimlerde SKM isteği başlatır.
        /// </summary>
        public void CreateNewHCExaminationFromOtherDepartments()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //HealthCommitteeExaminationFromOtherDepartments hcefod;
            //TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    hcefod = new HealthCommitteeExaminationFromOtherDepartments(objectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(hcefod);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), hcefod) == DialogResult.OK)
            //        objectContext.Save();
            //}
            //catch (Exception ex)
            //{
            //    objectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        ///İş Göremezlik Raporu başlatır.
        /// </summary>
        public void CreateNewUnavailableToWorkReport()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //UnavailableToWorkReport unavailableToWorkReport;
            ////            TTObjectContext objectContext = new TTObjectContext(false);
            ////            Guid savePointGuid = objectContext.BeginSavePoint();
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    unavailableToWorkReport = new UnavailableToWorkReport(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(unavailableToWorkReport);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), unavailableToWorkReport) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        ///HAsta katılım payından muaf Rapor isteği başlatır.
        /// </summary>
        public void CreateNewParticipatnFreeDrugReport()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //ParticipatnFreeDrugReport participatnFreeDrugReport;
            ////            TTObjectContext objectContext = new TTObjectContext(false);
            ////            Guid savePointGuid = objectContext.BeginSavePoint();
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    participatnFreeDrugReport = new ParticipatnFreeDrugReport(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(participatnFreeDrugReport);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), participatnFreeDrugReport) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    // objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        ///Üç imza isteği başlatır.
        /// </summary>
        public void CreateNewHealthCommitteeWithThreeSpecialist()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //HealthCommitteeWithThreeSpecialist hcw3s;
            ////            TTObjectContext objectContext = new TTObjectContext(false);
            ////            Guid savePointGuid = objectContext.BeginSavePoint();
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    hcw3s = new HealthCommitteeWithThreeSpecialist(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(hcw3s);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), hcw3s) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }

        /// <summary>
        ///Prof Sağlık Kurulu  isteği başlatır.
        /// </summary>
        public void CreateNewHealthCommitteeOfProfessors()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //HealthCommitteeOfProfessors profHC;
            //TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    profHC = new HealthCommitteeOfProfessors(objectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(profHC);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), profHC) == DialogResult.OK)
            //        objectContext.Save();
            //}
            //catch (Exception ex)
            //{
            //    objectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    objectContext.Dispose();
            //}
            var a = 1;
        }
        
        /// <summary>
        /// Yeni Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewConsultationRequest()
        {
//            MultiSelectForm pForm = new MultiSelectForm();
//            pForm.AddMSItem("Normal Konsültasyon", "ConsultationRequest");
//            pForm.AddMSItem("Diş Konsültasyonu", "DentalConsultationRequest");
//            string consultationType = pForm.GetMSItem(this, "Konsültasyon Tipini Seçiniz");
//            pForm.ClearMSItems();
//            if(consultationType == "ConsultationRequest")
                CreateNewNormalConsultationRequest();
            //            else if (consultationType == "DentalConsultationRequest")
            //                CreateNewDentalConsultationRequest();
            //            else
            //            {
            //                InfoBox.Show("Konsültasyon isteğinden vazgeçildi.");
            //                return;
            //            }
            var a = 1;
        }

        /// <summary>
        /// Yeni Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewNormalConsultationRequest()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //Consultation consultationRequest;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    consultationRequest = new Consultation(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(consultationRequest);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), consultationRequest) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }
        
        /// <summary>
        /// Yeni Diş Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewDentalConsultationRequest()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //DentalConsultationRequest dentalConsultationRequest;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    dentalConsultationRequest = new DentalConsultationRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(dentalConsultationRequest);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), dentalConsultationRequest) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            var a = 1;
        }

        /// <summary>
        /// Yeni Anestezi Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewAnesthesiaConsultation()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //TTObjectClasses.AnesthesiaConsultation consultation;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    consultation = new TTObjectClasses.AnesthesiaConsultation(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(consultation);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), consultation) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }


        /// <summary>
        /// Yeni Dış XXXXXX Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewConsultationFromOtherHospRequest()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //ConsultationFromOtherHospital consultationFromOtherHospital;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();

            //try
            //{
            //    consultationFromOtherHospital = new ConsultationFromOtherHospital(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(consultationFromOtherHospital);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), consultationFromOtherHospital) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }

        public void FireNewImportantMedicalInfo()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////            TTObject ttObject = this._EpisodeAction.Episode.Patient.ImportantMedicalInformation;
            ////            if (ttObject != null)
            ////            {
            ////                TTForm frm = TTForm.GetEditForm(ttObject);
            ////                if (frm != null)
            ////                {
            ////                    DialogResult dialog = frm.ShowReadOnly(this.FindForm(), ttObject);
            ////                }
            ////            }
            ////            else
            ////                InfoBox.Show("Hastaya ait Önemli Tıbbi Bilgi işlemi kaydedilmemiştir.", MessageIconEnum.InformationMessage);

            ////SaveContextForNewDiagnose();
            //ImportantMedicalInformation importantMedicalInformation;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    importantMedicalInformation = new ImportantMedicalInformation(this._EpisodeAction.ObjectContext);
            //    importantMedicalInformation.CurrentStateDefID = ImportantMedicalInformation.States.New;
            //    importantMedicalInformation.Episode = _EpisodeAction.Episode;
            //    TTForm frm = TTForm.GetEditForm(importantMedicalInformation);
            //    this.PrapareFormToShow(frm);
            //    if(frm.ShowEdit(this.FindForm(), importantMedicalInformation) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }

        public void FireNewDrugOrderIntroduction()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //DrugOrderIntroduction drugOrderIntroduction;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    drugOrderIntroduction = new DrugOrderIntroduction(this._EpisodeAction.ObjectContext);
            //    drugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.States.New;
            //    drugOrderIntroduction.Episode = _EpisodeAction.Episode;
            //    TTForm frm = TTForm.GetEditForm(drugOrderIntroduction);
            //    this.PrapareFormToShow(frm);
            //    if(frm.ShowEdit(this.FindForm(), drugOrderIntroduction) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
            //    else
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
            var a = 1;
        }
        
#endregion BaseNewDoctorExaminationForm_ClientSideMethods
    }
}