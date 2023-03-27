
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
    /// TPG nin istediği detaylı ayaktan-yatan hasta muayene formudur.
    /// </summary>
    public partial class BaseDoctorExaminationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnManipulationNewRequest.Click += new TTControlEventDelegate(btnManipulationNewRequest_Click);
            btnNewHealthCommitee.Click += new TTControlEventDelegate(btnNewHealthCommitee_Click);
            btnNewParticipatnFreeDrugReport.Click += new TTControlEventDelegate(btnNewParticipatnFreeDrugReport_Click);
            btnNewHealthCommiteewithThreeSpecialist.Click += new TTControlEventDelegate(btnNewHealthCommiteewithThreeSpecialist_Click);
            btnNewHCExaminationFromOtherDepartments.Click += new TTControlEventDelegate(btnNewHCExaminationFromOtherDepartments_Click);
            btnNewProfHealthCommitee.Click += new TTControlEventDelegate(btnNewProfHealthCommitee_Click);
            TestMenuDefinition.SelectedObjectChanged += new TTControlEventDelegate(TestMenuDefinition_SelectedObjectChanged);
            btnLabNewRequest.Click += new TTControlEventDelegate(btnLabNewRequest_Click);
            btnLabList.Click += new TTControlEventDelegate(btnLabList_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            LaboratoryResultsGrid.CellContentClick += new TTGridCellEventDelegate(LaboratoryResultsGrid_CellContentClick);
            btnConsultationNewRequest.Click += new TTControlEventDelegate(btnConsultationNewRequest_Click);
            btnNewConsultationFromOtherHospRequest.Click += new TTControlEventDelegate(btnNewConsultationFromOtherHospRequest_Click);
            btnAnesthesiaConsultationNewRequest.Click += new TTControlEventDelegate(btnAnesthesiaConsultationNewRequest_Click);
            btnCreateNewEpicrisis.Click += new TTControlEventDelegate(btnCreateNewEpicrisis_Click);
            btnNewForensicMedicalReport.Click += new TTControlEventDelegate(btnNewForensicMedicalReport_Click);
            btnNewInpatientAdmission.Click += new TTControlEventDelegate(btnNewInpatientAdmission_Click);
            btnNewTreatmentDischarge.Click += new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            btnNewUnavailableToWorkReport.Click += new TTControlEventDelegate(btnNewUnavailableToWorkReport_Click);
            btnNewOutPatientPrescription.Click += new TTControlEventDelegate(btnNewOutPatientPrescription_Click);
            HealthCommiteeActions.CellDoubleClick += new TTGridCellEventDelegate(HealthCommiteeActions_CellDoubleClick);
            btnImportantMedicalInfo.Click += new TTControlEventDelegate(btnImportantMedicalInfo_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnManipulationNewRequest.Click -= new TTControlEventDelegate(btnManipulationNewRequest_Click);
            btnNewHealthCommitee.Click -= new TTControlEventDelegate(btnNewHealthCommitee_Click);
            btnNewParticipatnFreeDrugReport.Click -= new TTControlEventDelegate(btnNewParticipatnFreeDrugReport_Click);
            btnNewHealthCommiteewithThreeSpecialist.Click -= new TTControlEventDelegate(btnNewHealthCommiteewithThreeSpecialist_Click);
            btnNewHCExaminationFromOtherDepartments.Click -= new TTControlEventDelegate(btnNewHCExaminationFromOtherDepartments_Click);
            btnNewProfHealthCommitee.Click -= new TTControlEventDelegate(btnNewProfHealthCommitee_Click);
            TestMenuDefinition.SelectedObjectChanged -= new TTControlEventDelegate(TestMenuDefinition_SelectedObjectChanged);
            btnLabNewRequest.Click -= new TTControlEventDelegate(btnLabNewRequest_Click);
            btnLabList.Click -= new TTControlEventDelegate(btnLabList_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            LaboratoryResultsGrid.CellContentClick -= new TTGridCellEventDelegate(LaboratoryResultsGrid_CellContentClick);
            btnConsultationNewRequest.Click -= new TTControlEventDelegate(btnConsultationNewRequest_Click);
            btnNewConsultationFromOtherHospRequest.Click -= new TTControlEventDelegate(btnNewConsultationFromOtherHospRequest_Click);
            btnAnesthesiaConsultationNewRequest.Click -= new TTControlEventDelegate(btnAnesthesiaConsultationNewRequest_Click);
            btnCreateNewEpicrisis.Click -= new TTControlEventDelegate(btnCreateNewEpicrisis_Click);
            btnNewForensicMedicalReport.Click -= new TTControlEventDelegate(btnNewForensicMedicalReport_Click);
            btnNewInpatientAdmission.Click -= new TTControlEventDelegate(btnNewInpatientAdmission_Click);
            btnNewTreatmentDischarge.Click -= new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            btnNewUnavailableToWorkReport.Click -= new TTControlEventDelegate(btnNewUnavailableToWorkReport_Click);
            btnNewOutPatientPrescription.Click -= new TTControlEventDelegate(btnNewOutPatientPrescription_Click);
            HealthCommiteeActions.CellDoubleClick -= new TTGridCellEventDelegate(HealthCommiteeActions_CellDoubleClick);
            btnImportantMedicalInfo.Click -= new TTControlEventDelegate(btnImportantMedicalInfo_Click);
            base.UnBindControlEvents();
        }

        private void btnManipulationNewRequest_Click()
        {
#region BaseDoctorExaminationForm_btnManipulationNewRequest_Click
   CreateNewManipulationRequest();
#endregion BaseDoctorExaminationForm_btnManipulationNewRequest_Click
        }

        private void btnNewHealthCommitee_Click()
        {
#region BaseDoctorExaminationForm_btnNewHealthCommitee_Click
   CreateNewHealthCommittee();
#endregion BaseDoctorExaminationForm_btnNewHealthCommitee_Click
        }

        private void btnNewParticipatnFreeDrugReport_Click()
        {
#region BaseDoctorExaminationForm_btnNewParticipatnFreeDrugReport_Click
   CreateNewParticipatnFreeDrugReport();
#endregion BaseDoctorExaminationForm_btnNewParticipatnFreeDrugReport_Click
        }

        private void btnNewHealthCommiteewithThreeSpecialist_Click()
        {
#region BaseDoctorExaminationForm_btnNewHealthCommiteewithThreeSpecialist_Click
   CreateNewHealthCommitteeWithThreeSpecialist();
#endregion BaseDoctorExaminationForm_btnNewHealthCommiteewithThreeSpecialist_Click
        }

        private void btnNewHCExaminationFromOtherDepartments_Click()
        {
#region BaseDoctorExaminationForm_btnNewHCExaminationFromOtherDepartments_Click
   CreateNewHCExaminationFromOtherDepartments();
#endregion BaseDoctorExaminationForm_btnNewHCExaminationFromOtherDepartments_Click
        }

        private void btnNewProfHealthCommitee_Click()
        {
#region BaseDoctorExaminationForm_btnNewProfHealthCommitee_Click
   CreateNewHealthCommitteeOfProfessors();
#endregion BaseDoctorExaminationForm_btnNewProfHealthCommitee_Click
        }

        private void TestMenuDefinition_SelectedObjectChanged()
        {
#region BaseDoctorExaminationForm_TestMenuDefinition_SelectedObjectChanged
   this.LaboratoryResultsGrid.Rows.Clear();
            this.TestProcedure.ControlValue = null;
            SetProcedureDefinitionFilter();
#endregion BaseDoctorExaminationForm_TestMenuDefinition_SelectedObjectChanged
        }

        private void btnLabNewRequest_Click()
        {
#region BaseDoctorExaminationForm_btnLabNewRequest_Click
   CreateNewLaboratoryRequest();
#endregion BaseDoctorExaminationForm_btnLabNewRequest_Click
        }

        private void btnLabList_Click()
        {
#region BaseDoctorExaminationForm_btnLabList_Click
   FillLaboratoryResultsGrid();
#endregion BaseDoctorExaminationForm_btnLabList_Click
        }

        private void ttbutton1_Click()
        {
#region BaseDoctorExaminationForm_ttbutton1_Click
   if (filteredTestList.Count > 0)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> testobjects = new TTReportTool.PropertyCache<object>();
                TTReportTool.PropertyCache<object> ttObject = new TTReportTool.PropertyCache<object>();
                // List<string> filteredTestList = new List<string>();

                testobjects.Add("VALUE", filteredTestList);
                parameters.Add("TESTOBJECTIDS", testobjects);
                ttObject.Add("VALUE", this._EpisodeAction.ObjectID.ToString());
                parameters.Add("TTOBJECTID", ttObject);
                TTReportTool.TTReport.PrintReport(this, typeof(TTReportClasses.I_ExaminationTestListReport), true, 1, parameters);
            }
            else
            {
                InfoBox.Show("Listelenecek Tetkik Bulunamadı");
            }
#endregion BaseDoctorExaminationForm_ttbutton1_Click
        }

        private void LaboratoryResultsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseDoctorExaminationForm_LaboratoryResultsGrid_CellContentClick
   if (LaboratoryResultsGrid.CurrentCell != null)
            {
                switch (LaboratoryResultsGrid.CurrentCell.OwningColumn.Name)
                {
                    case "Detail":
                        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
                        //ITTGridRow row = LaboratoryResultsGrid.CurrentCell.OwningRow;
                        //if (row.Cells["ObjectID"].Value != null)
                        //{
                        //    Guid saID = new Guid(row.Cells["ObjectID"].Value.ToString());
                        //    SubActionProcedure sa = (SubActionProcedure)this._EpisodeAction.ObjectContext.GetObject(saID, typeof(SubActionProcedure));
                        //    LaboratoryProcedure labProcedure = sa as LaboratoryProcedure;
                        //    if (labProcedure != null)
                        //    {
                        //        LaboratoryProcedureDetailForm detailForm = new LaboratoryProcedureDetailForm();
                        //        detailForm.ShowEdit(this.FindForm(), labProcedure, true);
                        //    }
                        //}
                        break;
                    default:
                        break;
                }
            }
#endregion BaseDoctorExaminationForm_LaboratoryResultsGrid_CellContentClick
        }

        private void btnConsultationNewRequest_Click()
        {
#region BaseDoctorExaminationForm_btnConsultationNewRequest_Click
        this.CreateNewConsultationRequest();
#endregion BaseDoctorExaminationForm_btnConsultationNewRequest_Click
        }

        private void btnNewConsultationFromOtherHospRequest_Click()
        {
#region BaseDoctorExaminationForm_btnNewConsultationFromOtherHospRequest_Click
   this.CreateNewConsultationFromOtherHospRequest();
#endregion BaseDoctorExaminationForm_btnNewConsultationFromOtherHospRequest_Click
        }

        private void btnAnesthesiaConsultationNewRequest_Click()
        {
#region BaseDoctorExaminationForm_btnAnesthesiaConsultationNewRequest_Click
   this.CreateNewAnesthesiaConsultation();
#endregion BaseDoctorExaminationForm_btnAnesthesiaConsultationNewRequest_Click
        }

        private void btnCreateNewEpicrisis_Click()
        {
#region BaseDoctorExaminationForm_btnCreateNewEpicrisis_Click
   this.CreateNewEpicrisisReport();
#endregion BaseDoctorExaminationForm_btnCreateNewEpicrisis_Click
        }

        private void btnNewForensicMedicalReport_Click()
        {
#region BaseDoctorExaminationForm_btnNewForensicMedicalReport_Click
   this.CreateNewForensicMedicalReport();
#endregion BaseDoctorExaminationForm_btnNewForensicMedicalReport_Click
        }

        private void btnNewInpatientAdmission_Click()
        {
#region BaseDoctorExaminationForm_btnNewInpatientAdmission_Click
   this.CreateNewInpatientAdmission();
#endregion BaseDoctorExaminationForm_btnNewInpatientAdmission_Click
        }

        private void btnNewTreatmentDischarge_Click()
        {
#region BaseDoctorExaminationForm_btnNewTreatmentDischarge_Click
   this.CreateNewTreatmentDischarge();
#endregion BaseDoctorExaminationForm_btnNewTreatmentDischarge_Click
        }

        private void btnNewUnavailableToWorkReport_Click()
        {
#region BaseDoctorExaminationForm_btnNewUnavailableToWorkReport_Click
   this.CreateNewUnavailableToWorkReport();
#endregion BaseDoctorExaminationForm_btnNewUnavailableToWorkReport_Click
        }

        private void btnNewOutPatientPrescription_Click()
        {
#region BaseDoctorExaminationForm_btnNewOutPatientPrescription_Click
   this.CreateNewOutPatientPrescription();
#endregion BaseDoctorExaminationForm_btnNewOutPatientPrescription_Click
        }

        private void HealthCommiteeActions_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseDoctorExaminationForm_HealthCommiteeActions_CellDoubleClick
            //TODO: ShowReadOnly yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //string hcObjectID = "";
            //         if (rowIndex < this.HealthCommiteeActions.Rows.Count && rowIndex > -1)
            //         {
            //             if (((ITTGridRow)this.HealthCommiteeActions.Rows[rowIndex]).Cells["HCObjectID"].Value != null)
            //                 hcObjectID = ((ITTGridRow)this.HealthCommiteeActions.Rows[rowIndex]).Cells["HCObjectID"].Value.ToString();
            //             if (String.IsNullOrEmpty(hcObjectID) == false)
            //             {
            //                 Guid hcObjectIDGuid = new Guid(hcObjectID);
            //                 HealthCommittee healthCommittee = (HealthCommittee)this._EpisodeAction.ObjectContext.GetObject(hcObjectIDGuid, "HealthCommittee");
            //                 if (healthCommittee != null)
            //                 {
            //                     HCExaminationForm hcExaminationForm = new HCExaminationForm();
            //                     hcExaminationForm.ShowReadOnly(this.FindForm(), healthCommittee);
            //                 }
            //             }
            //         }
            var a = 1;
            #endregion BaseDoctorExaminationForm_HealthCommiteeActions_CellDoubleClick
        }

        private void btnImportantMedicalInfo_Click()
        {
            #region BaseDoctorExaminationForm_btnImportantMedicalInfo_Click
            //TTObject ttObject = this._EpisodeAction.Episode.Patient.ImportantMedicalInformation;
            //         if (ttObject != null)
            //         {
            //             TTForm frm = TTForm.GetEditForm(ttObject);
            //             if (frm != null)
            //             {
            //                 DialogResult dialog = frm.ShowReadOnly(this.FindForm(), ttObject);
            //             }
            //         }
            var a = 1;
            #endregion BaseDoctorExaminationForm_btnImportantMedicalInfo_Click
        }

        protected override void PreScript()
        {
#region BaseDoctorExaminationForm_PreScript
    base.PreScript();
            SetLabStartEndDate();
            if (MenuDefinition.IsHealthCommitteeOfProfessorsActive())
                btnNewProfHealthCommitee.Visible = true;
            else
                btnNewProfHealthCommitee.Visible = false;

            FillHealthCommiteeActionsGrid();
            FillOldPhysicianExaminationsGrid();
            FillLastThreeLaboratoryProcedures();
            FillOldConsultationsGrid();
            FillOldManipulationsGrid();
            if (this._EpisodeAction.Episode.PatientStatus != PatientStatusEnum.Outpatient)
            {
                this.btnNewInpatientAdmission.Visible = false;
                this.btnNewOutPatientPrescription.Visible = false;
                //TODO : Şimdilik kapatıldı
                //this.btnNewTreatmentDischarge.Dock = DockStyle.Bottom;
                //int btnNewTreatmentDischargeSizeHeight = GroupBox3.Size.Height - 86 - btnCreateNewEpicrisis.Size.Height - btnNewForensicMedicalReport.Size.Height;
                //btnNewTreatmentDischarge.Size = new Size(btnNewTreatmentDischarge.Size.Width, btnNewTreatmentDischargeSizeHeight);
            }
            //            else
            //            {
            //                btnNewTreatmentDischarge.Location = btnCreateNewEpicrisis.Location;
            //                this.btnCreateNewEpicrisis.Visible = false;
            //                int btnNewTreatmentDischargeSizeHeight = GroupBox3.Size.Height - 86 - btnNewForensicMedicalReport.Size.Height - btnCreateNewEpicrisis.Size.Height;
            //                btnNewTreatmentDischarge.Size = new Size(btnNewTreatmentDischarge.Size.Width, btnNewTreatmentDischargeSizeHeight);
            //            }
            //TODO : Şimdilik kapatıldı
            //((TabPage)(this.ContinuousInfoTab.TabPages["ImportantDiagnosisTab"])).Resize += new EventHandler(ArrangeTabs);
            //((TabPage)(this.AnalysisPatientTab.TabPages["TreatmentDischargeTab"])).Resize += new EventHandler(ArrangeTabs);
            //((TabPage)(this.AnalysisPatientTab.TabPages["PreDiagnosisTab"])).Resize += new EventHandler(ArrangeTabs);
            var a = 1;
            #endregion BaseDoctorExaminationForm_PreScript

        }
            
#region BaseDoctorExaminationForm_Methods
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
            ResHospital hospital = (ResHospital)this._EpisodeAction.ObjectContext.GetObject(hospID, typeof(ResHospital));
            BindingList<HealthCommittee> healthCommiteeList;
            //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            //    healthCommiteeList = HealthCommittee.GetAllHealthCommiteesOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            //else
                healthCommiteeList = HealthCommittee.GetHealthCommiteesOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.ToString());

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
            BindingList<EpisodeAction> examList;
            //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            //    examList = EpisodeAction.GetAllExaminationsOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            //else
                examList = EpisodeAction.GetExaminationsOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.ToString());

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
            BindingList<SubActionProcedure> procedureList;
            //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            //    procedureList = SubActionProcedure.GetTestsByPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString(), Common.RecTime().AddMonths(-3));
            //else
                procedureList = SubActionProcedure.GetAllTestsByEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.ToString());

            //BindingList<LaboratoryProcedure> labProcedureList = LaboratoryProcedure.GetLabTestByPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            int i = 0;
            filteredTestList.Clear();
            foreach (SubActionProcedure testProcedure in procedureList)
            //foreach (LaboratoryProcedure labProcedure in labProcedureList)
            {
                if (testProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (i == 3)
                        break;
                    filteredTestList.Add(testProcedure.ObjectID.ToString());
                    ITTGridRow gridRow = this.LaboratoryResultsGrid.Rows.Add();
                    if (testProcedure.WorkListDate.HasValue)
                        gridRow.Cells["ProcedureDate"].Value = testProcedure.WorkListDate.Value;
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
                    i++;
                }
            }
        }

        /// <summary>
        /// Yeni Laboratuvar isteği başlatır.
        /// </summary>
        public void CreateNewLaboratoryRequest()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //if (this.TestMenuDefinition.SelectedObject == null)
            //{
            //    InfoBox.Show("Tetkik İşlem Türü boş olamaz.");
            //    return;
            //}

            ////string testActionTypeName = ((TestActionTypesEnum)Enum.Parse(typeof(TestActionTypesEnum), this.TestActionType.ControlValue.ToString())).ToString().ToUpperInvariant();
            //string testActionTypeName = ((MenuDefinition)this.TestMenuDefinition.SelectedObject).ObjectDefinitionName.ToUpperInvariant();
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    EpisodeAction testRequest = null;
            //    if (testActionTypeName == "GENETIC")
            //        testRequest = new Genetic(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    else if (testActionTypeName == "LABORATORYREQUEST")
            //        testRequest = new LaboratoryRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    else if (testActionTypeName == "NUCLEARMEDICINE")
            //        testRequest = new NuclearMedicine(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    else if (testActionTypeName == "PATHOLOGY")
            //        testRequest = new PathologyRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    else if (testActionTypeName == "RADIOLOGY")
            //        testRequest = new Radiology(this._EpisodeAction.ObjectContext, this._EpisodeAction);

            //    testRequest.MenuDefinition = (MenuDefinition)this.TestMenuDefinition.SelectedObject;

            //    TTForm frm = TTForm.GetEditForm(testRequest);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), testRequest) == DialogResult.OK)
            //        this._EpisodeAction.ObjectContext.Save();
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

        private List<string> filteredTestList = new List<string>();
        public void FillLaboratoryResultsGrid()
        {
            if (this.TestMenuDefinition.SelectedObject == null)
            {
                //TODO : Şimdilik kapatıldı
                //MessageBox.Show("Tetkik İşlem Türü boş olamaz.", "Uyarı");
                return;
            }

            DateTime startDate = Convert.ToDateTime(this.LabStartDate.ControlValue);
            DateTime endDate = Convert.ToDateTime(this.LabEndDate.ControlValue);
            this.LaboratoryResultsGrid.Rows.Clear();
            //string testActionTypeName = ((TestActionTypesEnum)Enum.Parse(typeof(TestActionTypesEnum), this.TestActionType.ControlValue.ToString())).ToString().ToUpperInvariant();
            string testActionTypeName = ((MenuDefinition)this.TestMenuDefinition.SelectedObject).ObjectDefinitionName.ToUpperInvariant();
            string subactionObjectDefName = null;

            if (testActionTypeName == "GENETIC")
                subactionObjectDefName = "GENETICTEST";
            else if (testActionTypeName == "LABORATORYREQUEST")
                subactionObjectDefName = "LABORATORYPROCEDURE";
            else if (testActionTypeName == "NUCLEARMEDICINE")
                subactionObjectDefName = "NUCLEARMEDICINETEST";
            else if (testActionTypeName == "PATHOLOGY")
                subactionObjectDefName = "PATHOLOGYTEST";
            else if (testActionTypeName == "RADIOLOGY")
                subactionObjectDefName = "RADIOLOGYTEST";

            string testProcedureObjectID = null;
            if (this.TestProcedure.SelectedObjectID != null)
                testProcedureObjectID = this.TestProcedure.SelectedObjectID.ToString();
            BindingList<SubActionProcedure> testProcedureList;
            // akıllı kart devreye girdiğinde commentler açılacaktır
            // if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            testProcedureList = SubActionProcedure.GetTestsByPatientByTestByDate(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString(), startDate, endDate, testProcedureObjectID, subactionObjectDefName);
            filteredTestList.Clear();
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
                    filteredTestList.Add(testProcedure.ObjectID.ToString());

                    ITTGridRow gridRow = this.LaboratoryResultsGrid.Rows.Add();
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
        public void FillOldConsultationsGrid()
        {
            BindingList<EpisodeAction> consFromOtherHospList;

            //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            //    consFromOtherHospList = EpisodeAction.GetAllConsFromOtherHospOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            //else
                consFromOtherHospList = EpisodeAction.GetConsFromOtherHospOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.ToString());
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
                    if (consFromOtherHosp.ConsultationResultAndOffers != null)
                        gridRow.Cells["ConsultationResultAndOffer"].Value = Common.GetRTFOfTextString(consFromOtherHosp.ConsultationResultAndOffers.ToString());
                }
            }

            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)this._EpisodeAction.ObjectContext.GetObject(hospID, typeof(ResHospital));
            BindingList<SubActionProcedure> consProcedureList = SubActionProcedure.GetAllConsultationProcOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            foreach (SubActionProcedure spf in consProcedureList)
            {
                ITTGridRow gridRow = this.ConsultationGrid.Rows.Add();
                gridRow.Cells["ConsultationDate"].Value = spf.ActionDate;
                if (spf is ConsultationProcedure)
                {
                    ConsultationProcedure consProcedure = (ConsultationProcedure)spf;
                    if (hospital != null)
                    {
                        gridRow.Cells["RequesterHospital"].Value = hospital.Name;
                        gridRow.Cells["RequestedHospital"].Value = hospital.Name;
                    }
                    gridRow.Cells["RequesterDepartment"].Value = (consProcedure.Consultation.RequesterResource != null ? consProcedure.Consultation.RequesterResource.Name : "");
                    gridRow.Cells["RequestedDepartment"].Value = (consProcedure.Consultation.MasterResource != null ? consProcedure.Consultation.MasterResource.Name : "");
                    gridRow.Cells["RequestReason"].Value = consProcedure.Consultation.RequestDescription;
                    gridRow.Cells["ConsultationResultAndOffer"].Value = consProcedure.Consultation.ConsultationResultAndOffers;
                }
            }

            BindingList<EpisodeAction> anesthesiaConsList = EpisodeAction.GetAllAnesthesiaConsultationOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
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
        /// Yeni Dış XXXXXX Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewConsultationFromOtherHospRequest()
        {
            //TODO : 
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
        /// Tıbbi Cerrahi Uygulamalar gridini doldurur.
        /// </summary>
        public void FillOldManipulationsGrid()
        {
            BindingList<ManipulationProcedure> manipulationProcedureList;

            //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
            //    manipulationProcedureList = ManipulationProcedure.GetAllManipulationProceduresOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            //else
                manipulationProcedureList = ManipulationProcedure.GetManipulationProceduresOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
            foreach (ManipulationProcedure mp in manipulationProcedureList)
            {
                ITTGridRow gridRow = this.ManipulationGrid.Rows.Add();
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
            //TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    unavailableToWorkReport = new UnavailableToWorkReport(objectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(unavailableToWorkReport);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), unavailableToWorkReport) == DialogResult.OK)
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
        ///HAsta katılım payından muaf Rapor isteği başlatır.
        /// </summary>
        public void CreateNewParticipatnFreeDrugReport()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //            ParticipatnFreeDrugReport participatnFreeDrugReport;
            ////            TTObjectContext objectContext = new TTObjectContext(false);
            ////            Guid savePointGuid = objectContext.BeginSavePoint();

            //            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //            try
            //            {
            //                participatnFreeDrugReport = new ParticipatnFreeDrugReport(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //                TTForm frm = TTForm.GetEditForm(participatnFreeDrugReport);
            //                this.PrapareFormToShow(frm);
            //                if (frm.ShowEdit(this.FindForm(), participatnFreeDrugReport) == DialogResult.OK)
            //                    this._EpisodeAction.ObjectContext.Save();
            //                else
            //                     this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //            }
            //            catch (Exception ex)
            //            {
            //                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);;
            //                InfoBox.Show(ex);
            //            }
            //            finally
            //            {
            //               // objectContext.Dispose();
            //            }
            var a = 1;
        }

        /// <summary>
        ///Üç imza isteği başlatır.
        /// </summary>
        public void CreateNewHealthCommitteeWithThreeSpecialist()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //HealthCommitteeWithThreeSpecialist hcw3s;
            //TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    hcw3s = new HealthCommitteeWithThreeSpecialist(objectContext, this._EpisodeAction);
            //    TTForm frm = TTForm.GetEditForm(hcw3s);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), hcw3s) == DialogResult.OK)
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
            //    if (this._EpisodeAction is InPatientPhysicianApplication)
            //    {
            //        InPatientPhysicianApplication inPatientPhysicianApplication = (InPatientPhysicianApplication)this._EpisodeAction;
            //        if (inPatientPhysicianApplication.MyEpicrisisReport() == null)
            //        {
            //            epicrisisReport = new CreatingEpicrisis(objectContext, this._EpisodeAction);
            //        }
            //        else
            //        {
            //            tempEpicrisisReport = inPatientPhysicianApplication.MyEpicrisisReport();
            //            epicrisisReport = (CreatingEpicrisis)objectContext.GetObject(tempEpicrisisReport.ObjectID, "CreatingEpicrisis");
            //        }
            //    }
            //    else
            //        return;

            //    TTForm frm = TTForm.GetEditForm(epicrisisReport);
            //    this.PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), epicrisisReport) == DialogResult.OK)
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
        /// Yeni Ayaktan Hasta Reçetesi isteği başlatır.
        /// </summary>
        public void CreateNewOutPatientPrescription()
        {
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            ////SaveContextForNewDiagnose();
            //if (this._EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            //{
            //    OutPatientPrescription outPatientPrescription;
            //    //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //    //TTObjectContext objectContext = new TTObjectContext(false);
            //    Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //    try
            //    {
            //        outPatientPrescription = new OutPatientPrescription(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //        TTForm frm = TTForm.GetEditForm(outPatientPrescription);
            //        this.PrapareFormToShow(frm);
            //        if (frm.ShowEdit(this.FindForm(), outPatientPrescription) == DialogResult.OK)
            //            this._EpisodeAction.ObjectContext.Save();
            //    }
            //    catch (Exception ex)
            //    {
            //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //        InfoBox.Show(ex);
            //    }
            //    finally
            //    {
            //        //objectContext.Dispose();
            //    }
            //}
            //else
            //{
            //    InfoBox.Show("Ayaktan Hasta Reçetesi sadece ayaktan hastaya başlatılır.");
            //    return;
            //}
            var a = 1;
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
        //                inPatientPrescription = new InPatientPrescription(objectContext, this._EpisodeAction);
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


        /// <summary>
        /// ActionTypedan Seçilen Enum değerine karşılık gelen EpisodeAction Kullandığı SubactionProcedureleri bulup Adlarını String olarak döndürür
        /// <summary>
        public string GetProcedureDefinitionNames()
        {
            string procedureDefNames = "";
            if (this.TestMenuDefinition.SelectedObject == null)
                InfoBox.Show("Tetkik İşlem Türü boş olamaz.");
            else
            {
                string objectDefName = ((MenuDefinition)this.TestMenuDefinition.SelectedObject).ObjectDefinitionName.ToUpperInvariant();
                procedureDefNames = EpisodeAction.GetProcedureDefinitionNames(objectDefName);
                
            }
            return procedureDefNames;
        }

        public void SetProcedureDefinitionFilter()
        {
            string procuderDefNames = this.GetProcedureDefinitionNames();
            string filter = "1=2";
            if (procuderDefNames != "")
                filter = " THIS.OBJECTDEFNAME IN(" + procuderDefNames + ")";
            ((ITTListBox)this.TestProcedure).ListFilterExpression = filter;
        }

        protected int treatmentDischargeTabButtonCount = 0;
        public void ArrangeTreatmentDischargeTab()
        {
            ////İşlem Sonlandırma Tabında butonların boyutunu düzenler
            //int YLocation = 10;
            //int araBosluk = 1;
            //int otherControlsHeight = 0;
            //treatmentDischargeTabButtonCount = 0;
            //foreach (ITTComponentBase control in TreatmentDischargeTab.Children)
            //{
            //    if (control is TTVisual.ITTControlBase)
            //    {
            //        if (((ITTControlBase)control).Visible == true)
            //        {
            //            if (control is TTVisual.TTButton)
            //                treatmentDischargeTabButtonCount++;
            //            //else
            //               // otherControlsHeight += ((ITTControlBase)control).Size.Height + araBosluk;
            //        }
            //    }
            //}

            //if (treatmentDischargeTabButtonCount > 0)
            //{
            //    //int buttonHight = (TreatmentDischargeTab.Size.Height - 20 - otherControlsHeight - (araBosluk * treatmentDischargeTabButtonCount)) / treatmentDischargeTabButtonCount;

            //    //foreach (ITTComponentBase control in TreatmentDischargeTab.Children)
            //    //{
            //    //    if (control is ITTControlBase)
            //    //    {
            //    //        if (((ITTControlBase)control).Visible == true)
            //    //        {
            //    //            ((ITTControlBase)control).Location = new Point(((ITTControlBase)control).Location.X, YLocation);
            //    //            if (control is TTButton)
            //    //                ((ITTControlBase)control).Size = new Size(((ITTControlBase)control).Size.Width, buttonHight);
            //    //            YLocation += ((ITTControlBase)control).Size.Height + araBosluk;
            //    //        }
            //    //    }
            //    //}
            //}
            var a = 1;
        }

        public void ArrangePreDiagnosisTab()
        {
            ////İşlem Sonlandırma Tabında butonların boyutunu düzenler
            ////int YLocation = 10;
            //int araBosluk = 1;
            //int controlCount = 0;
            //foreach (ITTComponentBase control in PreDiagnosisTab.Children)
            //{
            //    if (control is ITTControlBase)
            //    {
            //        if (((ITTControlBase)control).Visible == true)
            //        {
            //            controlCount++;
            //        }
            //    }
            //}

            //if (controlCount > 0)
            //{
            //    //int controlHight = (PreDiagnosisTab.Size.Height - 5 - (araBosluk * controlCount)) / controlCount;

            //    //foreach (ITTComponentBase control in PreDiagnosisTab.Children)
            //    //{
            //    //    if (control is ITTControlBase)
            //    //    {
            //    //        if (((ITTControlBase)control).Visible == true)
            //    //        {
            //    //            //((ITTControlBase)control).Location=new Point(((ITTControlBase)control).Location.X,YLocation);
            //    //            ((ITTControlBase)control).Size = new Size(((ITTControlBase)control).Size.Width, controlHight);
            //    //            //YLocation+= ((ITTControlBase)control).Size.Height + araBosluk;
            //    //        }
            //    //    }
            //    //}
            //}
            var a = 1;
        }
        public void ArrangeImportantDiagnosisTab()
        {
            ////İşlem Sonlandırma Tabında butonların boyutunu düzenler
            //int YLocation = 10;
            //int araBosluk = 1;
            //int controlCount = 0;
            //foreach (ITTComponentBase control in ImportantDiagnosisTab.Children)
            //{
            //    if (control is ITTControlBase)
            //    {
            //        if (((ITTControlBase)control).Visible == true)
            //        {
            //            controlCount++;
            //        }
            //    }
            //}

            //if (controlCount > 0)
            //{
            //    //int controlHight = (ImportantDiagnosisTab.Size.Height - 5 - (araBosluk * controlCount)) / controlCount;

            //    //foreach (ITTComponentBase control in ImportantDiagnosisTab.Children)
            //    //{
            //    //    if (control is ITTControlBase)
            //    //    {
            //    //        if (((ITTControlBase)control).Visible == true)
            //    //        {
            //    //            ((ITTControlBase)control).Location = new Point(((ITTControlBase)control).Location.X, YLocation);
            //    //            ((ITTControlBase)control).Size = new Size(((ITTControlBase)control).Size.Width, controlHight);
            //    //            YLocation += ((ITTControlBase)control).Size.Height + araBosluk;
            //    //        }
            //    //    }
            //    //}
            //}
            var a = 1;
        }
        protected virtual void ShowAction_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
            contextSaved = true;
        }

        public void ArrangeTabs(object sender, EventArgs e)
        {
            //TabPage tabPage = sender as TabPage;
            //if (tabPage != null)
            //{
            //    if (tabPage.Name == "TreatmentDischargeTab")
            //        ArrangeTreatmentDischargeTab();
            //    if (tabPage.Name == "PreDiagnosisTab")
            //        ArrangePreDiagnosisTab();
            //    if (tabPage.Name == "ImportantDiagnosisTab")
            //        ArrangeImportantDiagnosisTab();
            //}
            var a = 1;
        }
        
#endregion BaseDoctorExaminationForm_Methods
    }
}