
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
    /// <summary>
    /// Doktor Muayene Formu
    /// </summary>
    public partial class BaseDoctorExaminationFormForSP : SubactionProcedureFlowableForm
    {
        override protected void BindControlEvents()
        {
            btnImportantMedicalInfo.Click += new TTControlEventDelegate(btnImportantMedicalInfo_Click);
            AnalysisPatientTab.SelectedTabChanged += new TTControlEventDelegate(AnalysisPatientTab_SelectedTabChanged);
            TestMenuDefinition.SelectedObjectChanged += new TTControlEventDelegate(TestMenuDefinition_SelectedObjectChanged);
            btnLabNewRequest.Click += new TTControlEventDelegate(btnLabNewRequest_Click);
            LaboratoryResultsGrid.CellContentClick += new TTGridCellEventDelegate(LaboratoryResultsGrid_CellContentClick);
            btnLabList.Click += new TTControlEventDelegate(btnLabList_Click);
            btnNewConsultationFromOtherHospRequest.Click += new TTControlEventDelegate(btnNewConsultationFromOtherHospRequest_Click);
            btnConsultationNewRequest.Click += new TTControlEventDelegate(btnConsultationNewRequest_Click);
            btnAnesthesiaConsultationNewRequest.Click += new TTControlEventDelegate(btnAnesthesiaConsultationNewRequest_Click);
            btnNewTreatmentDischarge.Click += new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ContinuousInfoTab.SelectedTabChanged += new TTControlEventDelegate(ContinuousInfoTab_SelectedTabChanged);
            HealthCommiteeActions.CellDoubleClick += new TTGridCellEventDelegate(HealthCommiteeActions_CellDoubleClick);
            btnManipulationNewRequest.Click += new TTControlEventDelegate(btnManipulationNewRequest_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnImportantMedicalInfo.Click -= new TTControlEventDelegate(btnImportantMedicalInfo_Click);
            AnalysisPatientTab.SelectedTabChanged -= new TTControlEventDelegate(AnalysisPatientTab_SelectedTabChanged);
            TestMenuDefinition.SelectedObjectChanged -= new TTControlEventDelegate(TestMenuDefinition_SelectedObjectChanged);
            btnLabNewRequest.Click -= new TTControlEventDelegate(btnLabNewRequest_Click);
            LaboratoryResultsGrid.CellContentClick -= new TTGridCellEventDelegate(LaboratoryResultsGrid_CellContentClick);
            btnLabList.Click -= new TTControlEventDelegate(btnLabList_Click);
            btnNewConsultationFromOtherHospRequest.Click -= new TTControlEventDelegate(btnNewConsultationFromOtherHospRequest_Click);
            btnConsultationNewRequest.Click -= new TTControlEventDelegate(btnConsultationNewRequest_Click);
            btnAnesthesiaConsultationNewRequest.Click -= new TTControlEventDelegate(btnAnesthesiaConsultationNewRequest_Click);
            btnNewTreatmentDischarge.Click -= new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ContinuousInfoTab.SelectedTabChanged -= new TTControlEventDelegate(ContinuousInfoTab_SelectedTabChanged);
            HealthCommiteeActions.CellDoubleClick -= new TTGridCellEventDelegate(HealthCommiteeActions_CellDoubleClick);
            btnManipulationNewRequest.Click -= new TTControlEventDelegate(btnManipulationNewRequest_Click);
            base.UnBindControlEvents();
        }

        private void btnImportantMedicalInfo_Click()
        {
#region BaseDoctorExaminationFormForSP_btnImportantMedicalInfo_Click
   TTObject ttObject = this._SubactionProcedureFlowable.Episode.Patient.ImportantMedicalInformation;
            if (ttObject != null)
            {
                TTForm frm = TTForm.GetEditForm(ttObject);
                if (frm != null)
                {
                    DialogResult dialog = frm.ShowReadOnly(this.FindForm(), ttObject);
                }
            }
#endregion BaseDoctorExaminationFormForSP_btnImportantMedicalInfo_Click
        }

        private void AnalysisPatientTab_SelectedTabChanged()
        {
#region BaseDoctorExaminationFormForSP_AnalysisPatientTab_SelectedTabChanged
   if(this.AnalysisPatientTab.SelectedTab.Name.ToUpperInvariant()==("TreatmentDischargeTab").ToUpperInvariant())
            {
                ArrangeTreatmentDischargeTab();
            }
            else if(this.AnalysisPatientTab.SelectedTab.Name.ToUpperInvariant()==("PreDiagnosisTab").ToUpperInvariant())
            {
                ArrangePreDiagnosisTab();
            }
#endregion BaseDoctorExaminationFormForSP_AnalysisPatientTab_SelectedTabChanged
        }

        private void TestMenuDefinition_SelectedObjectChanged()
        {
#region BaseDoctorExaminationFormForSP_TestMenuDefinition_SelectedObjectChanged
   this.LaboratoryResultsGrid.Rows.Clear();
            this.TestProcedure.ControlValue = null;
            SetProcedureDefinitionFilter();
#endregion BaseDoctorExaminationFormForSP_TestMenuDefinition_SelectedObjectChanged
        }

        private void btnLabNewRequest_Click()
        {
#region BaseDoctorExaminationFormForSP_btnLabNewRequest_Click
   CreateNewLaboratoryRequest();
#endregion BaseDoctorExaminationFormForSP_btnLabNewRequest_Click
        }

        private void LaboratoryResultsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseDoctorExaminationFormForSP_LaboratoryResultsGrid_CellContentClick
   if(LaboratoryResultsGrid.CurrentCell != null)
            {
                switch (LaboratoryResultsGrid.CurrentCell.OwningColumn.Name)
                {
                    case "Detail":
                        ITTGridRow row = LaboratoryResultsGrid.CurrentCell.OwningRow;
                        if(row.Cells["ObjectID"].Value != null)
                        {
                            Guid saID = new Guid(row.Cells["ObjectID"].Value.ToString());
                            SubActionProcedure sa = (SubActionProcedure)this._SubactionProcedureFlowable.ObjectContext.GetObject(saID, typeof(SubActionProcedure));
                            LaboratoryProcedure labProcedure = sa as LaboratoryProcedure;
                            if(labProcedure != null)
                            {
                                LaboratoryProcedureDetailForm detailForm = new LaboratoryProcedureDetailForm();
                                detailForm.ShowEdit(this.FindForm(),labProcedure,true);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
#endregion BaseDoctorExaminationFormForSP_LaboratoryResultsGrid_CellContentClick
        }

        private void btnLabList_Click()
        {
#region BaseDoctorExaminationFormForSP_btnLabList_Click
   if (this.TestMenuDefinition.SelectedObject == null)
            {
                InfoBox.Show("Tetkik İşlem Türü boş olamaz.");
                return;
            }
            
            DateTime startDate = Convert.ToDateTime(this.LabStartDate.ControlValue);
            DateTime endDate = Convert.ToDateTime(this.LabEndDate.ControlValue);
            this.LaboratoryResultsGrid.Rows.Clear();
           // string testActionTypeName = ((TestActionTypesEnum)Enum.Parse(typeof(TestActionTypesEnum),this.TestActionType.ControlValue.ToString())).ToString().ToUpperInvariant();
            string testActionTypeName = ((MenuDefinition)this.TestMenuDefinition.SelectedObject).ObjectDefinitionName.ToUpperInvariant();
            string subactionObjectDefName = null;
            
            if(testActionTypeName == "GENETIC")
                subactionObjectDefName = "GENETICTEST";
            else if(testActionTypeName == "LABORATORYREQUEST")
                subactionObjectDefName = "LABORATORYPROCEDURE";
            else if(testActionTypeName == "NUCLEARMEDICINE")
                subactionObjectDefName = "NUCLEARMEDICINETEST";
            else if(testActionTypeName == "PATHOLOGY")
                subactionObjectDefName = "PATHOLOGYTEST";
            else if(testActionTypeName == "RADIOLOGY")
                subactionObjectDefName = "RADIOLOGYTEST";
            
            string testProcedureObjectID = null;
            if(this.TestProcedure.SelectedObjectID != null)
                testProcedureObjectID = this.TestProcedure.SelectedObjectID.ToString();
            BindingList<SubActionProcedure> testProcedureList = SubActionProcedure.GetTestsByPatientByTestByDate(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString(), startDate, endDate, testProcedureObjectID, subactionObjectDefName);
                        
            foreach (SubActionProcedure testProcedure in testProcedureList)
            {
                ITTGridRow gridRow = this.LaboratoryResultsGrid.Rows.Add();
                gridRow.Cells["ProcedureDate"].Value = testProcedure.WorkListDate;
                gridRow.Cells["Procedure"].Value = (testProcedure.ProcedureObject !=null ? testProcedure.ProcedureObject.Name : "");
                if(testProcedure is GeneticTest)
                    gridRow.Cells["ProcedureResult"].Value = ((GeneticTest)testProcedure).Genetic.Report;
                else if (testProcedure is NuclearMedicineTest)
                    gridRow.Cells["ProcedureResult"].Value = ((NuclearMedicineTest)testProcedure).NuclearMedicine.Report;
                else if (testProcedure is LaboratoryProcedure)
                    gridRow.Cells["ProcedureResult"].Value = Common.GetRTFOfTextString(((LaboratoryProcedure)testProcedure).Result);
                //TODO ASLI makroskopiler pathologymaterial objectinde
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
#endregion BaseDoctorExaminationFormForSP_btnLabList_Click
        }

        private void btnNewConsultationFromOtherHospRequest_Click()
        {
#region BaseDoctorExaminationFormForSP_btnNewConsultationFromOtherHospRequest_Click
   CreateNewConsultationFromOtherHospRequest();
#endregion BaseDoctorExaminationFormForSP_btnNewConsultationFromOtherHospRequest_Click
        }

        private void btnConsultationNewRequest_Click()
        {
#region BaseDoctorExaminationFormForSP_btnConsultationNewRequest_Click
   CreateNewConsultationRequest();
#endregion BaseDoctorExaminationFormForSP_btnConsultationNewRequest_Click
        }

        private void btnAnesthesiaConsultationNewRequest_Click()
        {
#region BaseDoctorExaminationFormForSP_btnAnesthesiaConsultationNewRequest_Click
   CreateNewAnesthesiaConsultation();
#endregion BaseDoctorExaminationFormForSP_btnAnesthesiaConsultationNewRequest_Click
        }

        private void btnNewTreatmentDischarge_Click()
        {
#region BaseDoctorExaminationFormForSP_btnNewTreatmentDischarge_Click
   CreateNewTreatmentDischarge();
#endregion BaseDoctorExaminationFormForSP_btnNewTreatmentDischarge_Click
        }

        private void ContinuousInfoTab_SelectedTabChanged()
        {
#region BaseDoctorExaminationFormForSP_ContinuousInfoTab_SelectedTabChanged
   if(this.ContinuousInfoTab.SelectedTab.Name.ToUpperInvariant()==("ImportantDiagnosisTab").ToUpperInvariant())
            {
                ArrangeImportantDiagnosisTab();
            }
#endregion BaseDoctorExaminationFormForSP_ContinuousInfoTab_SelectedTabChanged
        }

        private void HealthCommiteeActions_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseDoctorExaminationFormForSP_HealthCommiteeActions_CellDoubleClick
   string hcObjectID = "";
            if (rowIndex < this.HealthCommiteeActions.Rows.Count && rowIndex > -1)
            {
                if (((ITTGridRow)this.HealthCommiteeActions.Rows[rowIndex]).Cells["HCObjectID"].Value != null)
                    hcObjectID = ((ITTGridRow)this.HealthCommiteeActions.Rows[rowIndex]).Cells["HCObjectID"].Value.ToString();
                if (String.IsNullOrEmpty(hcObjectID) == false)
                {
                    Guid hcObjectIDGuid = new Guid(hcObjectID);
                    HealthCommittee healthCommittee = (HealthCommittee)this._SubactionProcedureFlowable.ObjectContext.GetObject(hcObjectIDGuid, "HealthCommittee");
                    if (healthCommittee != null)
                    {
                        HCExaminationForm hcExaminationForm = new HCExaminationForm();
                        hcExaminationForm.ShowReadOnly(this.FindForm(), healthCommittee);
                    }
                }
            }
#endregion BaseDoctorExaminationFormForSP_HealthCommiteeActions_CellDoubleClick
        }

        private void btnManipulationNewRequest_Click()
        {
#region BaseDoctorExaminationFormForSP_btnManipulationNewRequest_Click
   CreateNewManipulationRequest();
#endregion BaseDoctorExaminationFormForSP_btnManipulationNewRequest_Click
        }

        protected override void PreScript()
        {
#region BaseDoctorExaminationFormForSP_PreScript
    base.PreScript();
            SetLabStartEndDate();
            FillHealthCommiteeActionsGrid();
            FillOldPhysicianExaminationsGrid();
            FillLastThreeLaboratoryProcedures();
            FillOldConsultationsGrid();
            FillOldManipulationsGrid();
            
            ((TabPage)(this.ContinuousInfoTab.TabPages["ImportantDiagnosisTab"])).Resize += new EventHandler(ArrangeTabs);
            ((TabPage)(this.AnalysisPatientTab.TabPages["TreatmentDischargeTab"])).Resize += new EventHandler(ArrangeTabs);
            ((TabPage)(this.AnalysisPatientTab.TabPages["PreDiagnosisTab"])).Resize += new EventHandler(ArrangeTabs);
#endregion BaseDoctorExaminationFormForSP_PreScript

            }
            
#region BaseDoctorExaminationFormForSP_Methods
        /// <summary>
        /// Laboratuvar tabındaki başlangıç ve bitiş tarihlerini set eder.
        /// </summary>
        public void SetLabStartEndDate()
        {
            this.LabStartDate.ControlValue = Common.RecTime();
            this.LabEndDate.ControlValue = Common.RecTime();
        }
        
        /// <summary>
        /// Sağlık Kurulu İşlemleri tabını doldurur.
        /// </summary>
        public void FillHealthCommiteeActionsGrid()
        {
            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)this._SubactionProcedureFlowable.ObjectContext.GetObject(hospID, typeof(ResHospital));
            BindingList<HealthCommittee> healthCommiteeList = HealthCommittee.GetAllHealthCommiteesOfPatient(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString());
            foreach (HealthCommittee healthCommittee in healthCommiteeList)
            {
                ITTGridRow gridRow = this.HealthCommiteeActions.Rows.Add();
                gridRow.Cells["Hospital"].Value = hospital.Name; //şimdilik şu anki XXXXXXnin ismini getiriyor.
                gridRow.Cells["HealthCommiteeActionID"].Value = (healthCommittee.ID != null ? healthCommittee.ID.ToString() : "");
                gridRow.Cells["HealthCommiteeActionDate"].Value = healthCommittee.ActionDate;
                gridRow.Cells["HCObjectID"].Value = healthCommittee.ObjectID.ToString();
            }
        }

        /// <summary>
        /// Muayene Bulguları gridini doldurur.
        /// </summary>
        public void FillOldPhysicianExaminationsGrid()
        {
            BindingList<EpisodeAction> examList = EpisodeAction.GetAllExaminationsOfPatient(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString());

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
                    ITTGridRow gridRow = this.OldPhysicialExaminationsGrid.Rows.Add();
                    gridRow.Cells["ExaminationDateTime"].Value = ea.ActionDate.Value;
                    gridRow.Cells["ExaminationIndication"].Value = examinationIndication;
                }
            }
        }

        /// <summary>
        /// Son üç laboratuvar testini doldurur.
        /// </summary>
        public void FillLastThreeLaboratoryProcedures()
        {
            BindingList<SubActionProcedure> procedureList = SubActionProcedure.GetTestsByPatient(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString(), Common.RecTime().AddMonths(-3));
            //BindingList<LaboratoryProcedure> labProcedureList = LaboratoryProcedure.GetLabTestByPatient(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString());
            int i = 0;
            foreach (SubActionProcedure testProcedure in procedureList)
                //foreach (LaboratoryProcedure labProcedure in labProcedureList)
            {
                if(testProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (i == 3)
                        break;
                    ITTGridRow gridRow = this.LaboratoryResultsGrid.Rows.Add();
                    if(testProcedure.WorkListDate.HasValue)
                        gridRow.Cells["ProcedureDate"].Value = testProcedure.WorkListDate.Value;
                    gridRow.Cells["Procedure"].Value = (testProcedure.ProcedureObject != null ? testProcedure.ProcedureObject.Name : "");
                    if(testProcedure is GeneticTest)
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
                    i++;
                }
            }
        }

        /// <summary>
        /// Konsültasyon gridini doldurur.
        /// </summary>
        public void FillOldConsultationsGrid()
        {
            BindingList<EpisodeAction> consFromOtherHospList = EpisodeAction.GetAllConsFromOtherHospOfPatient(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString());
            foreach (EpisodeAction ea in consFromOtherHospList)
            {
                ITTGridRow gridRow = this.ConsultationGrid.Rows.Add();
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
                    if(consFromOtherHosp.ConsultationResultAndOffers != null)
                        gridRow.Cells["ConsultationResultAndOffer"].Value = Common.GetRTFOfTextString(consFromOtherHosp.ConsultationResultAndOffers.ToString());
                }
            }

            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)this._SubactionProcedureFlowable.ObjectContext.GetObject(hospID, typeof(ResHospital));
            BindingList<Consultation> consList = Consultation.GetAllConsultationsOfPatient(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString());
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
            
            BindingList<EpisodeAction> anesthesiaConsList = EpisodeAction.GetAllAnesthesiaConsultationOfPatient(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString());
            foreach (EpisodeAction ea in anesthesiaConsList)
            {
                ITTGridRow gridRow = this.ConsultationGrid.Rows.Add();
                gridRow.Cells["ConsultationDate"].Value = ea.ActionDate;
                if (ea is AnesthesiaConsultation)
                {
                    AnesthesiaConsultation anesthesiaConsultation = (AnesthesiaConsultation)ea;
                    if (hospital != null)
                    {
                        gridRow.Cells["RequesterHospital"].Value = hospital.Name;
                        gridRow.Cells["RequestedHospital"].Value = hospital.Name;
                    }
                    gridRow.Cells["RequesterDepartment"].Value = (anesthesiaConsultation.FromResource != null ? anesthesiaConsultation.FromResource.Name : "");
                    gridRow.Cells["RequestedDepartment"].Value = (anesthesiaConsultation.MasterResource != null ? anesthesiaConsultation.MasterResource.Name : "");
                    gridRow.Cells["RequestReason"].Value = anesthesiaConsultation.ConsultationRequestNote;
                    gridRow.Cells["ConsultationResultAndOffer"].Value = anesthesiaConsultation.ConsultationResult;
                }
            }
        }
        

        
        
        /// <summary>
        /// Tıbbi Cerrahi Uygulamalar gridini doldurur.
        /// </summary>
        public void FillOldManipulationsGrid()
        {
            BindingList<ManipulationProcedure> manipulationProcedureList = ManipulationProcedure.GetAllManipulationProceduresOfPatient(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.Episode.Patient.ObjectID.ToString());
            foreach (ManipulationProcedure mp in manipulationProcedureList)
            {
                ITTGridRow gridRow = this.ManipulationGrid.Rows.Add();
                gridRow.Cells["ManipulationActionDate"].Value = mp.ActionDate;
                
                gridRow.Cells["Emergency"].Value = mp.Emergency;
                if(mp.ProcedureObject!=null)
                    gridRow.Cells["ProcedureObject"].Value =  mp.ProcedureObject.ObjectID ;
                if(mp.ProcedureDepartment!=null)
                    gridRow.Cells["Department"].Value = mp.ProcedureDepartment.ObjectID ;//emin değilim
                if(mp.ProcedureDoctor!=null)
                    gridRow.Cells["ManipulationDoctor"].Value =  mp.ProcedureDoctor.ObjectID ;
                
                gridRow.Cells["Description"].Value = mp.Description;
            }
        }

        
        
        
        
        /// <summary>
        /// ActionTypedan Seçilen Enum değerine karşılık gelen EpisodeAction Kullandığı SubactionProcedureleri bulup Adlarını String olarak döndürür
        /// <summary>
        public string GetProcedureDefinitionNames()
        {
            string procedureDefNames="";
            //string objectDefName = ((TestActionTypesEnum)Enum.Parse(typeof(TestActionTypesEnum),this.TestActionType.ControlValue.ToString())).ToString().ToUpperInvariant();
            string objectDefName = ((MenuDefinition)this.TestMenuDefinition.SelectedObject).ObjectDefinitionName.ToUpperInvariant();
            TTObjectDef objDef=null;
            TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefName,out objDef) ;
            if (objDef!=null){
                if (objDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant())){
                    foreach(TTObjectRelationSubtypeDef rSubType in objDef.AllChildRelationsSubtypeDefs){
                        if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                        {
                            if(rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant()!="PROCEDUREDEFINITION"){
                                if(procedureDefNames!="")
                                    procedureDefNames=procedureDefNames + "," ;
                                procedureDefNames = procedureDefNames + "'" + rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() + "'";
                            }
                        }
                    }
                }
            }
            return procedureDefNames;
        }
        
        public void SetProcedureDefinitionFilter()
        {
            string procuderDefNames=this.GetProcedureDefinitionNames();
            string filter="1=2";
            if(procuderDefNames!="")
                filter=" THIS.OBJECTDEFNAME IN("+ procuderDefNames +")";
            ((ITTListBox)this.TestProcedure).ListFilterExpression =  filter;
        }
        
        public void ArrangeTreatmentDischargeTab()
        {
            ////İşlem Sonlandırma Tabında butonların boyutunu düzenler
            //int YLocation = 10;
            //int araBosluk=1;
            //int otherControlsHeight=0;
            //int treatmentDischargeTabButtonCount=0;
            //foreach(ITTComponentBase control in TreatmentDischargeTab.Children)
            //{
            //    if( control is ITTControlBase )
            //    {
            //        if(((ITTControlBase)control).Visible==true)
            //        {
            //            if(control is TTButton)
            //                treatmentDischargeTabButtonCount++;
            //            else
            //                otherControlsHeight += ((ITTControlBase)control).Size.Height + araBosluk ;
            //        }
            //    }
            //}
            
            //if(treatmentDischargeTabButtonCount>0)
            //{
            //    int buttonHight= (TreatmentDischargeTab.Size.Height - 20 - otherControlsHeight - (araBosluk*treatmentDischargeTabButtonCount)) / treatmentDischargeTabButtonCount;
                
            //    foreach(ITTComponentBase control in TreatmentDischargeTab.Children)
            //    {
            //        if( control is ITTControlBase )
            //        {
            //            if(((ITTControlBase)control).Visible==true)
            //            {
            //                ((ITTControlBase)control).Location=new Point(((ITTControlBase)control).Location.X,YLocation);
            //                if(control is TTButton)
            //                    ((ITTControlBase)control).Size=new Size(((ITTControlBase)control).Size.Width,buttonHight);
            //                YLocation+= ((ITTControlBase)control).Size.Height + araBosluk;
            //            }
            //        }
            //    }
            //}
        }
        
        public void ArrangePreDiagnosisTab()
        {
            ////İşlem Sonlandırma Tabında butonların boyutunu düzenler
            //int YLocation = 10;
            //int araBosluk=1;
            //int controlCount=0;
            //foreach(ITTComponentBase control in PreDiagnosisTab.Children)
            //{
            //    if( control is ITTControlBase )
            //    {
            //        if(((ITTControlBase)control).Visible==true)
            //        {
            //            controlCount++;
            //        }
            //    }
            //}
            
            //if(controlCount>0)
            //{
            //    int controlHight= (PreDiagnosisTab.Size.Height - 20  - (araBosluk*controlCount)) / controlCount;
                
            //    foreach(ITTComponentBase control in PreDiagnosisTab.Children)
            //    {
            //        if( control is ITTControlBase )
            //        {
            //            if(((ITTControlBase)control).Visible==true)
            //            {
            //                ((ITTControlBase)control).Location=new Point(((ITTControlBase)control).Location.X,YLocation);
            //                ((ITTControlBase)control).Size=new Size(((ITTControlBase)control).Size.Width,controlHight);
            //                YLocation+= ((ITTControlBase)control).Size.Height + araBosluk;
            //            }
            //        }
            //    }
            //}
        }
        
        public void ArrangeImportantDiagnosisTab()
        {
            ////İşlem Sonlandırma Tabında butonların boyutunu düzenler
            //int YLocation = 10;
            //int araBosluk=1;
            //int controlCount=0;
            //foreach(ITTComponentBase control in ImportantDiagnosisTab.Children)
            //{
            //    if( control is ITTControlBase )
            //    {
            //        if(((ITTControlBase)control).Visible==true)
            //        {
            //            controlCount++;
            //        }
            //    }
            //}
            
            //if(controlCount>0)
            //{
            //    int controlHight= (ImportantDiagnosisTab.Size.Height - 10  - (araBosluk*controlCount)) / controlCount;
                
            //    foreach(ITTComponentBase control in ImportantDiagnosisTab.Children)
            //    {
            //        if( control is ITTControlBase )
            //        {
            //            if(((ITTControlBase)control).Visible==true)
            //            {
            //                ((ITTControlBase)control).Location=new Point(((ITTControlBase)control).Location.X,YLocation);
            //                ((ITTControlBase)control).Size=new Size(((ITTControlBase)control).Size.Width,controlHight);
            //                YLocation+= ((ITTControlBase)control).Size.Height + araBosluk;
            //            }
            //        }
            //    }
            //}
        }
        
        public void ArrangeTabs(object sender, EventArgs e)
        {
            TabPage tabPage = sender as TabPage;
            if(tabPage != null)
            {
                if(tabPage.Name == "TreatmentDischargeTab")
                    ArrangeTreatmentDischargeTab();
                if(tabPage.Name == "PreDiagnosisTab")
                    ArrangePreDiagnosisTab();
                if(tabPage.Name == "ImportantDiagnosisTab")
                    ArrangeImportantDiagnosisTab();
            }
        }
        
        protected virtual void ShowAction_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
            contextSaved = true;
        }

        protected void PrapareFormToShow(TTForm frm)
        {
            frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            frm.GetTemplates = this.GetTemplates;
            frm.SaveTemplate = this.SaveTemplate;
            frm.TemplateSelected = this.TemplateSelected;
        }
        
#endregion BaseDoctorExaminationFormForSP_Methods

#region BaseDoctorExaminationFormForSP_ClientSideMethods
        /// <summary>
        /// Yeni Laboratuvar isteği başlatır.
        /// </summary>
        public void CreateNewLaboratoryRequest()
        {
            if(this.TestMenuDefinition.SelectedObject  == null)
            {
                InfoBox.Show("Tetkik İşlem Türü boş olamaz.");
                return;
            }
            
            //string testActionTypeName = ((TestActionTypesEnum)Enum.Parse(typeof(TestActionTypesEnum),this.TestActionType.ControlValue.ToString())).ToString().ToUpperInvariant();
            string testActionTypeName = ((MenuDefinition)this.TestMenuDefinition.SelectedObject).ObjectDefinitionName.ToUpperInvariant();
            
            TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = objectContext.BeginSavePoint();
            
            EpisodeAction testRequest = null;
            if(testActionTypeName == "GENETIC")
                testRequest =new Genetic(objectContext,this._SubactionProcedureFlowable);
            else if(testActionTypeName == "LABORATORYREQUEST")
                testRequest =new LaboratoryRequest(objectContext,this._SubactionProcedureFlowable);
            else if(testActionTypeName == "NUCLEARMEDICINE")
                testRequest =new NuclearMedicine(objectContext,this._SubactionProcedureFlowable);
            else if(testActionTypeName == "PATHOLOGY")
                testRequest =new PathologyRequest(objectContext,this._SubactionProcedureFlowable);
            else if(testActionTypeName == "RADIOLOGY")
                testRequest =new Radiology(objectContext,this._SubactionProcedureFlowable);
            
            testRequest.MenuDefinition=(MenuDefinition)this.TestMenuDefinition.SelectedObject;
            try
            {
                TTForm frm = TTForm.GetEditForm(testRequest);
                frm.ObjectUpdated += delegate(TTObject ttObject, ref bool contextSaved) { ttObject.ObjectContext.Save(); contextSaved = true; };
                frm.ShowEdit(this.FindForm(), testRequest);
            }
            catch (Exception ex)
            {
                objectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                objectContext.Dispose();
            }
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
        }

        /// <summary>
        /// Yeni Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewNormalConsultationRequest()
        {
            //SaveContextForNewDiagnose();
            Consultation consultationRequest;
            //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = this._SubactionProcedureFlowable.ObjectContext.BeginSavePoint();
            try
            {
                consultationRequest = new Consultation(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable);
                TTForm frm = TTForm.GetEditForm(consultationRequest);
                this.PrapareFormToShow(frm);
                if (frm.ShowEdit(this.FindForm(), consultationRequest) == DialogResult.OK)
                    this._SubactionProcedureFlowable.ObjectContext.Save();
                else
                    this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
            }
            catch (Exception ex)
            {
                this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                //objectContext.Dispose();
            }
        }
        
        /// <summary>
        /// Yeni Diş Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewDentalConsultationRequest()
        {
            ////SaveContextForNewDiagnose();
            //DentalConsultationRequest dentalConsultationRequest;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._SubactionProcedureFlowable.ObjectContext.BeginSavePoint();
            //try
            //{
            //    dentalConsultationRequest = new DentalConsultationRequest(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable);
            //    TTForm frm = TTForm.GetEditForm(dentalConsultationRequest);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), dentalConsultationRequest) == DialogResult.OK)
            //        this._SubactionProcedureFlowable.ObjectContext.Save();
            //    else
            //        this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
        }

        /// <summary>
        /// Yeni Dış XXXXXX Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewConsultationFromOtherHospRequest()
        {
            ConsultationFromOtherHospital consultationFromOtherHospital;
            TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = objectContext.BeginSavePoint();
            
            try
            {
                consultationFromOtherHospital = new ConsultationFromOtherHospital(objectContext,this._SubactionProcedureFlowable);
                TTForm frm = TTForm.GetEditForm(consultationFromOtherHospital);
                if(frm.ShowEdit(this.FindForm(), consultationFromOtherHospital) == DialogResult.OK)
                    objectContext.Save();
            }
            catch (Exception ex)
            {
                objectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                objectContext.Dispose();
            }
        }

        /// <summary>
        /// Yeni Anestezi Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewAnesthesiaConsultation()
        {
            AnesthesiaConsultation consultation;
            TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = objectContext.BeginSavePoint();
            try
            {
                consultation = new AnesthesiaConsultation(objectContext, this._SubactionProcedureFlowable);
                TTForm frm = TTForm.GetEditForm(consultation);
                this.PrapareFormToShow(frm);
                if (frm.ShowEdit(this.FindForm(), consultation) == DialogResult.OK)
                    objectContext.Save();
            }
            catch (Exception ex)
            {
                objectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                objectContext.Dispose();
            }
        }
        
        /// <summary>
        /// Yeni Manipulasyon isteği başlatır.
        /// </summary>
        public void CreateNewManipulationRequest()
        {
            //SaveContextForNewDiagnose();
            ManipulationRequest manipulationRequest;
            //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = this._SubactionProcedureFlowable.ObjectContext.BeginSavePoint();
            try
            {
                manipulationRequest = new ManipulationRequest(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable);
                TTForm frm = TTForm.GetEditForm(manipulationRequest);
                this.PrapareFormToShow(frm);
                if(frm.ShowEdit(this.FindForm(), manipulationRequest) == DialogResult.OK)
                    this._SubactionProcedureFlowable.ObjectContext.Save();
                else
                    this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
            }
            catch (Exception ex)
            {
                this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                //objectContext.Dispose();
            }
        }

        /// <summary>
        /// Yeni Ayaktan Hasta Reçetesi isteği başlatır.
        /// </summary>
        public void CreateNewOutPatientPrescription()
        {
            if(this._SubactionProcedureFlowable.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            {
                OutPatientPrescription outPatientPrescription;
                //TTObjectContext objectContext = new TTObjectContext(false);
                Guid savePointGuid = this._SubactionProcedureFlowable.ObjectContext.BeginSavePoint();
                try
                {
                    outPatientPrescription = new OutPatientPrescription(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable);
                    TTForm frm = TTForm.GetEditForm(outPatientPrescription);
                       this.PrapareFormToShow(frm);
                    if(frm.ShowEdit(this.FindForm(), outPatientPrescription) == DialogResult.OK)
                        this._SubactionProcedureFlowable.ObjectContext.Save();
                }
                catch (Exception ex)
                {
                    this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
                    InfoBox.Show(ex);
                }
                finally
                {
                    this._SubactionProcedureFlowable.ObjectContext.Dispose();
                }
            }
            else
            {
                InfoBox.Show("Ayaktan Hasta Reçetesi sadece ayaktan hastaya başlatılır.");
                return;
            }
        }
        
        //        /// <summary>
        //        /// Yeni Yatan Hasta Reçetesi isteği başlatır.
        //        /// </summary>
        //        public void CreateNewInPatientPrescription()
        //        {
        //            InPatientPrescription inPatientPrescription;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                inPatientPrescription = new InPatientPrescription(objectContext, this._SubactionProcedureFlowable);
        //                TTForm frm = TTForm.GetEditForm(inPatientPrescription);
        //                if(frm.ShowEdit(this.FindForm(), inPatientPrescription) == DialogResult.OK)
        //                    objectContext.Save();
        //            }
        //            catch (Exception ex)
        //            {
        //                objectContext.RollbackSavePoint(savePointGuid);
        //                InfoBox.Show(ex);
        //            }
        //            finally
        //            {
        //                objectContext.Dispose();
        //            }
        //        }
        
#endregion BaseDoctorExaminationFormForSP_ClientSideMethods
    }
}