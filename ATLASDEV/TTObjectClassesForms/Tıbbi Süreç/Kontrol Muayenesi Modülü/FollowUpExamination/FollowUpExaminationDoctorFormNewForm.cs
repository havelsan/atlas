
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
    /// Doktor Kontrol Muayenesi - Ayaktan Hasta
    /// </summary>
    public partial class FollowUpExaminationDoctorFormNew : BaseNewDoctorExaminationForm
    {
        override protected void BindControlEvents()
        {
            LabManTabControl.SelectedTabChanged += new TTControlEventDelegate(LabManTabControl_SelectedTabChanged);
            btnBioChemical.Click += new TTControlEventDelegate(btnBioChemical_Click);
            btnSpecialLabRequest.Click += new TTControlEventDelegate(btnSpecialLabRequest_Click);
            btnGeneticRequest.Click += new TTControlEventDelegate(btnGeneticRequest_Click);
            btnPathologyRequest.Click += new TTControlEventDelegate(btnPathologyRequest_Click);
            btnNucleerMedicineRequest.Click += new TTControlEventDelegate(btnNucleerMedicineRequest_Click);
            btnRadiologyRequest.Click += new TTControlEventDelegate(btnRadiologyRequest_Click);
            btnMicroBiology.Click += new TTControlEventDelegate(btnMicroBiology_Click);
            btnAnesthesiaConsultationNewRequest.Click += new TTControlEventDelegate(btnAnesthesiaConsultationNewRequest_Click);
            btnNewConsultationFromOtherHospRequest.Click += new TTControlEventDelegate(btnNewConsultationFromOtherHospRequest_Click);
            ttbutton11.Click += new TTControlEventDelegate(ttbutton11_Click);
            btnReports.Click += new TTControlEventDelegate(btnReports_Click);
            btnNurseryProcedures.Click += new TTControlEventDelegate(btnNurseryProcedures_Click);
            btnInpatientAdmission.Click += new TTControlEventDelegate(btnInpatientAdmission_Click);
            btnPrescription.Click += new TTControlEventDelegate(btnPrescription_Click);
            btnEpicrisis.Click += new TTControlEventDelegate(btnEpicrisis_Click);
            btnTreatmentMaterial.Click += new TTControlEventDelegate(btnTreatmentMaterial_Click);
            btnForensicReport.Click += new TTControlEventDelegate(btnForensicReport_Click);
            btnManiplation.Click += new TTControlEventDelegate(btnManiplation_Click);
            btnImportantMedicalInfo.Click += new TTControlEventDelegate(btnImportantMedicalInfo_Click);
            btnGroupBox4.Click += new TTControlEventDelegate(btnGroupBox4_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            LabManTabControl.SelectedTabChanged -= new TTControlEventDelegate(LabManTabControl_SelectedTabChanged);
            btnBioChemical.Click -= new TTControlEventDelegate(btnBioChemical_Click);
            btnSpecialLabRequest.Click -= new TTControlEventDelegate(btnSpecialLabRequest_Click);
            btnGeneticRequest.Click -= new TTControlEventDelegate(btnGeneticRequest_Click);
            btnPathologyRequest.Click -= new TTControlEventDelegate(btnPathologyRequest_Click);
            btnNucleerMedicineRequest.Click -= new TTControlEventDelegate(btnNucleerMedicineRequest_Click);
            btnRadiologyRequest.Click -= new TTControlEventDelegate(btnRadiologyRequest_Click);
            btnMicroBiology.Click -= new TTControlEventDelegate(btnMicroBiology_Click);
            btnAnesthesiaConsultationNewRequest.Click -= new TTControlEventDelegate(btnAnesthesiaConsultationNewRequest_Click);
            btnNewConsultationFromOtherHospRequest.Click -= new TTControlEventDelegate(btnNewConsultationFromOtherHospRequest_Click);
            ttbutton11.Click -= new TTControlEventDelegate(ttbutton11_Click);
            btnReports.Click -= new TTControlEventDelegate(btnReports_Click);
            btnNurseryProcedures.Click -= new TTControlEventDelegate(btnNurseryProcedures_Click);
            btnInpatientAdmission.Click -= new TTControlEventDelegate(btnInpatientAdmission_Click);
            btnPrescription.Click -= new TTControlEventDelegate(btnPrescription_Click);
            btnEpicrisis.Click -= new TTControlEventDelegate(btnEpicrisis_Click);
            btnTreatmentMaterial.Click -= new TTControlEventDelegate(btnTreatmentMaterial_Click);
            btnForensicReport.Click -= new TTControlEventDelegate(btnForensicReport_Click);
            btnManiplation.Click -= new TTControlEventDelegate(btnManiplation_Click);
            btnImportantMedicalInfo.Click -= new TTControlEventDelegate(btnImportantMedicalInfo_Click);
            btnGroupBox4.Click -= new TTControlEventDelegate(btnGroupBox4_Click);
            base.UnBindControlEvents();
        }

        private void LabManTabControl_SelectedTabChanged()
        {
#region FollowUpExaminationDoctorFormNew_LabManTabControl_SelectedTabChanged
   switch (LabManTabControl.SelectedTab.Name)
            {
                case "LabResultTab":
                    //FillLaboratoryResultsGrid(LaboratoryResultsGrid);
                    LabManTabControl.SelectedIndex = 0;
                    PatientLabTestResults labResults = new PatientLabTestResults();
                    labResults.CurrentPatient = _FollowUpExamination.Episode.Patient;
                    InfoBox.Show("labResults.ShowDialog();");
                    break;
                case "ConsultationTab":
                    FillOldConsultationsGrid(ConsultationGrid);
                    break;
                case "ResultGraphics":
                    //SessionExtension.AddToSession("OldActionFormDefaultTab", 1);
                    OnOpenOldActionsForm(this, _FollowUpExamination);
                    LabManTabControl.SelectedIndex = 0;
                    break;
                case "PatientHistory":
                    //SessionExtension.AddToSession("OldActionFormDefaultTab", 0);
                    OnOpenOldActionsForm(this, _FollowUpExamination);
                    LabManTabControl.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
#endregion FollowUpExaminationDoctorFormNew_LabManTabControl_SelectedTabChanged
        }

        private void btnBioChemical_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnBioChemical_Click
   Guid microBiologyGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("BIYOKIMYAMAINRESGUID", Guid.Empty.ToString()));

            ResLaboratoryDepartment labDep = (ResLaboratoryDepartment)_FollowUpExamination.ObjectContext.GetObject(microBiologyGuid, TTObjectDefManager.Instance.ObjectDefs[typeof(ResLaboratoryDepartment).Name], false);
            if (labDep == null)
                CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), null);
            else
                CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), labDep.ObjectID);
#endregion FollowUpExaminationDoctorFormNew_btnBioChemical_Click
        }

        private void btnSpecialLabRequest_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnSpecialLabRequest_Click
   CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), null);
#endregion FollowUpExaminationDoctorFormNew_btnSpecialLabRequest_Click
        }

        private void btnGeneticRequest_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnGeneticRequest_Click
   CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(Genetic)), null);
#endregion FollowUpExaminationDoctorFormNew_btnGeneticRequest_Click
        }

        private void btnPathologyRequest_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnPathologyRequest_Click
   CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyRequest)), null);
#endregion FollowUpExaminationDoctorFormNew_btnPathologyRequest_Click
        }

        private void btnNucleerMedicineRequest_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnNucleerMedicineRequest_Click
   CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(NuclearMedicine)), null);
#endregion FollowUpExaminationDoctorFormNew_btnNucleerMedicineRequest_Click
        }

        private void btnRadiologyRequest_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnRadiologyRequest_Click
   CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(Radiology)), null);
#endregion FollowUpExaminationDoctorFormNew_btnRadiologyRequest_Click
        }

        private void btnMicroBiology_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnMicroBiology_Click
   Guid microBiologyGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("MIKROBIYOLOJIMAINRESGUID", Guid.Empty.ToString()));

            ResLaboratoryDepartment labDep = (ResLaboratoryDepartment)_FollowUpExamination.ObjectContext.GetObject(microBiologyGuid, TTObjectDefManager.Instance.ObjectDefs[typeof(ResLaboratoryDepartment).Name], false);
            if (labDep == null)
                CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), null);
            else
                CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), labDep.ObjectID);
#endregion FollowUpExaminationDoctorFormNew_btnMicroBiology_Click
        }

        private void btnAnesthesiaConsultationNewRequest_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnAnesthesiaConsultationNewRequest_Click
   CreateNewAnesthesiaConsultation();
#endregion FollowUpExaminationDoctorFormNew_btnAnesthesiaConsultationNewRequest_Click
        }

        private void btnNewConsultationFromOtherHospRequest_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnNewConsultationFromOtherHospRequest_Click
   CreateNewConsultationFromOtherHospRequest();
#endregion FollowUpExaminationDoctorFormNew_btnNewConsultationFromOtherHospRequest_Click
        }

        private void ttbutton11_Click()
        {
#region FollowUpExaminationDoctorFormNew_ttbutton11_Click
   CreateNewConsultationRequest();
#endregion FollowUpExaminationDoctorFormNew_ttbutton11_Click
        }

        private void btnReports_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnReports_Click
   MultiSelectForm msitem = new MultiSelectForm();
            msitem.AddMSItem("Sağlık Kurulu", "1");
            msitem.AddMSItem("Diğer Birim(ler)den SKM ", "2");
            msitem.AddMSItem("Üç Uzman Tabip İmzalı Rapor", "3");
            msitem.AddMSItem("Hasta Katılım Payından Muaf İlaç Raporu", "4");
            msitem.AddMSItem("Profesörler Sağlık Kurulu", "5");
            msitem.AddMSItem("İş Göremezlik Raporu", "6");

            string mKey = msitem.GetMSItem(this, "İşlem yapmak istediğiniz raporu seçiniz");
            if (mKey == null)
            {
                InfoBox.Show("İşlemden vazgeçildi", MessageIconEnum.InformationMessage);
                return;
            }
            else
            {
                switch (mKey)
                {
                    case "1":
                        CreateNewHealthCommittee();
                        break;
                    case "2":
                        CreateNewHCExaminationFromOtherDepartments();
                        break;
                    case "3":
                        CreateNewHealthCommitteeWithThreeSpecialist();
                        break;
                    case "4":
                        CreateNewParticipatnFreeDrugReport();
                        break;
                    case "5":
                        CreateNewHealthCommitteeOfProfessors();
                        break;
                    case "6":
                        CreateNewUnavailableToWorkReport();
                        break;
                    default:
                        break;
                }
            }
#endregion FollowUpExaminationDoctorFormNew_btnReports_Click
        }

        private void btnNurseryProcedures_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnNurseryProcedures_Click
   MaximizeGroupTab();
            ContinuousInfoTab.SelectedTab = ContinuousInfoTab.TabPages["NursingOrdersTab"];
#endregion FollowUpExaminationDoctorFormNew_btnNurseryProcedures_Click
        }

        private void btnInpatientAdmission_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnInpatientAdmission_Click
   CreateNewInpatientAdmission();
#endregion FollowUpExaminationDoctorFormNew_btnInpatientAdmission_Click
        }

        private void btnPrescription_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnPrescription_Click
   CreateNewOutPatientPrescription();
#endregion FollowUpExaminationDoctorFormNew_btnPrescription_Click
        }

        private void btnEpicrisis_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnEpicrisis_Click
   CreateNewEpicrisisReport();
#endregion FollowUpExaminationDoctorFormNew_btnEpicrisis_Click
        }

        private void btnTreatmentMaterial_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnTreatmentMaterial_Click
   MaximizeGroupTab();
            ContinuousInfoTab.SelectedTab = ContinuousInfoTab.TabPages["TreatmentMaterialsTab"];
#endregion FollowUpExaminationDoctorFormNew_btnTreatmentMaterial_Click
        }

        private void btnForensicReport_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnForensicReport_Click
   CreateNewForensicMedicalReport();
#endregion FollowUpExaminationDoctorFormNew_btnForensicReport_Click
        }

        private void btnManiplation_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnManiplation_Click
   CreateNewManipulationRequest();
#endregion FollowUpExaminationDoctorFormNew_btnManiplation_Click
        }

        private void btnImportantMedicalInfo_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnImportantMedicalInfo_Click
   FireNewImportantMedicalInfo();
#endregion FollowUpExaminationDoctorFormNew_btnImportantMedicalInfo_Click
        }

        private void btnGroupBox4_Click()
        {
#region FollowUpExaminationDoctorFormNew_btnGroupBox4_Click
   if (_groupTabMaximized)
                MinimizeGroupTab();
            else
                MaximizeGroupTab();
#endregion FollowUpExaminationDoctorFormNew_btnGroupBox4_Click
        }

        protected override void PreScript()
        {
#region FollowUpExaminationDoctorFormNew_PreScript
    base.PreScript();
            this.DropStateButton(FollowUpExamination.States.NursingorderDetails);
            if(this._FollowUpExamination.CurrentStateDefID == FollowUpExamination.States.Examination)
            {
                //DP için kapatıldı
                /*if (this._FollowUpExamination.ProcedureDoctor == null)
                {
                    foreach (AuthorizedUser authorizedUser in this._FollowUpExamination.AuthorizedUsers)
                    {
                        this._FollowUpExamination.ProcedureDoctor = (ResUser)authorizedUser.User;
                        break;
                    }
                }*/
                if(this._FollowUpExamination.ProcedureDoctor == null)
                    this.SetProcedureDoctorAsCurrentResource();
                if (this._FollowUpExamination.ProcessDate == null)
                    this._FollowUpExamination.ProcessDate = Common.RecTime();
            }
            
            if (Common.CurrentUser.IsPowerUser || Common.CurrentUser.IsSuperUser)// admin kullanıcının sorumlu doktorunu değiştirebilir.
                Doktor.Enabled = true;
            else
                Doktor.Enabled = false;
            
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);
         


            if (_FollowUpExamination.Episode.MainSpeciality != null)
            {
                DateTime startDate = Common.RecTime().Date.AddDays(-10);
                BindingList<ExaminationInfoByBrans> examinations = ExaminationInfoByBrans.GetExaminationsBypatientAndBrans(_FollowUpExamination.ObjectContext, _FollowUpExamination.Episode.Patient.ObjectID, _FollowUpExamination.Episode.MainSpeciality.ObjectID, startDate, Common.RecTime().Date.AddDays(1));
                if (examinations != null && examinations.Count > 0)
                {
                    ExaminationInfoByBrans examinationInfoByBrans = (ExaminationInfoByBrans)examinations[0];
                    if (examinationInfoByBrans.Complaint != null && _FollowUpExamination.Complaint == null && examinationInfoByBrans.PatientExamination.ActionDate != null)
                        _FollowUpExamination.Complaint = "(" + Convert.ToDateTime(examinationInfoByBrans.PatientExamination.ActionDate).ToShortDateString() + ")" + " - " + Common.GetTextOfRTFString(examinationInfoByBrans.Complaint.ToString());
                    if (examinationInfoByBrans.PhysicalExamination != null && _FollowUpExamination.PhysicalExamination == null && examinationInfoByBrans.PatientExamination.ActionDate != null)
                        _FollowUpExamination.PhysicalExamination = "(" + Convert.ToDateTime(examinationInfoByBrans.PatientExamination.ActionDate).ToShortDateString() + ")" + " - " + Common.GetTextOfRTFString(examinationInfoByBrans.PhysicalExamination.ToString());
                    if (examinationInfoByBrans.PatientStory != null && _FollowUpExamination.PatientStory == null && examinationInfoByBrans.PatientExamination.ActionDate != null)
                        _FollowUpExamination.PatientStory += "(" + Convert.ToDateTime(examinationInfoByBrans.PatientExamination.ActionDate).ToShortDateString() + ")" + " - " + Common.GetTextOfRTFString(examinationInfoByBrans.PatientStory.ToString());

                    foreach (DiagnosisGrid diagnose in examinationInfoByBrans.DiagnosisGrid)
                    {
                        
                         DiagnosisGrid d = new DiagnosisGrid(_FollowUpExamination.ObjectContext);
                        d.Diagnose =diagnose.Diagnose;
                        d.AddToHistory = false;
                        d.IsMainDiagnose = false;
                        d.EpisodeAction = _FollowUpExamination;
                        d.Episode = _FollowUpExamination.Episode;
                        _FollowUpExamination.Diagnosis.Add(d);
                     
                    }
                }
            }
#endregion FollowUpExaminationDoctorFormNew_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FollowUpExaminationDoctorFormNew_PostScript
    base.PostScript(transDef);
#endregion FollowUpExaminationDoctorFormNew_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region FollowUpExaminationDoctorFormNew_ClientSidePostScript
    base.ClientSidePostScript(transDef);
               if(this._FollowUpExamination.OriginalStateDef.StateDefID == FollowUpExamination.States.Examination)
            {
                if(transDef == null || ((transDef != null) && (transDef.ToStateDefID == FollowUpExamination.States.Completed)))
                {
                    foreach(FollowUpExaminationProcedure followUpExaminationProcedure in this._FollowUpExamination.FollowUpExaminationProcedures)
                    {
                        followUpExaminationProcedure.SetPerformedDate();
                    }
                    this.CreateNursingOrderDetailsAndCompleteOrder();
                    this.CreateProcedureOrderDetailsAndCompleteOrder();
                }
                
                if(transDef!=null)
                {
                    bool diagnosisAtLeastOne= false;
                    //                    if (this.ProcedureDoctor.SelectedObject == null)
                    //                        throw new Exception("Muayeneyi yapan doktoru seçiniz.");
                    
                    if(transDef.ToStateDefID == FollowUpExamination.States.Completed)
                    {
                        this.SetPreDiagnosisAsSecDiagnosis((EpisodeActionWithDiagnosis)_FollowUpExamination);
                    }
                    
                }
            }
               
               // Artık ayaktan Hastada MTS yok
            //string mtsConclusion = Common.GetTextOfRTFString(rtfMTS.Rtf);
            //if(!string.IsNullOrEmpty(mtsConclusion))
            //{
            //     Guid stateDef = TreatmentDischarge.States.Completed;
                
            //    Dictionary<string, object> parameters = new Dictionary<string, object>();
            //    if(DischargeType.SelectedItem.Value != null)
            //        parameters.Add("DischargeType", DischargeType.SelectedItem.Value);
            //    //                        if(DischargeToPlace.SelectedItem.Value != null)
            //    //                            parameters.Add("DischargeToPlace", DischargeToPlace.SelectedItem.Value);
            //    if(HospitalSendingTo.SelectedObject != null)
            //        parameters.Add("HospitalSendingTo", HospitalSendingTo.SelectedObject);
            //    if(string.IsNullOrEmpty(Common.GetTextOfRTFString(rtfMTS.Rtf)) == false)
            //        parameters.Add("Conclusion", rtfMTS.Rtf);
            //    if(DispatchedSpeciality.SelectedObject != null)
            //        parameters.Add("DispatchedSpeciality", DispatchedSpeciality.SelectedObject);
                
            //    CreateCompletedTreatmentDischarge(stateDef, parameters);
                
            //}
#endregion FollowUpExaminationDoctorFormNew_ClientSidePostScript

        }

#region FollowUpExaminationDoctorFormNew_Methods


        public bool _groupTabMaximized = false;
        
        private void CreateNursingOrderDetailsAndCompleteOrder()
        {
            foreach(SingleNursingOrder singleNursingOrder in this._FollowUpExamination.SingleNursingOrders)
            {
                if (singleNursingOrder.CurrentStateDefID == SingleNursingOrder.States.New)
                {
                    List<PeriodicOrderDetail> periodicOrderDetailList = PeriodicOrder.CreateOrderDetails(singleNursingOrder);
                    foreach (PeriodicOrderDetail periodicOrderDetail in periodicOrderDetailList)
                    {
                        singleNursingOrder.OrderDetails.Add(periodicOrderDetail);
                    }
                    singleNursingOrder.Update();
                    singleNursingOrder.CurrentStateDefID = SingleNursingOrder.States.Planned;
                }
            }
        }
        
        private void CreateProcedureOrderDetailsAndCompleteOrder()
        {
            foreach(ProcedureOrder procedureOrder in this._FollowUpExamination.ProcedureOrders)
            {
                if (procedureOrder.CurrentStateDefID == ProcedureOrder.States.New)
                {
                    //procedureOrder.CreateOrderDetails();
                    procedureOrder.Update();
                    procedureOrder.CurrentStateDefID = ProcedureOrder.States.Planned;
                }
            }
        }
        
        public override void SetProcedureDoctorAsCurrentResource()
        {
            this.SetProcedureDoctorAsCurrentResource();
            //DP için kapatıldı
            /*
            if(Common.CurrentUser.IsSuperUser != true)
            {
                if(Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist)
                {
                    if(this._FollowUpExamination.ProcedureDoctor == null)
                    {
                        this._FollowUpExamination.ProcedureDoctor = Common.CurrentResource;
                    }
                    else
                    {
                        if(this._FollowUpExamination.ProcedureDoctor.ObjectID != Common.CurrentResource.ObjectID)
                        {
                             string msg = "İşlemin sorumlu doktoru :  " + this._FollowUpExamination.ProcedureDoctor.Name + " . \r\n \r\nİşlemi kaydettiğinizde sorumlu doktor olarak kaydedileceksiniz.";
                            InfoBox.Alert(msg,MessageIconEnum.InformationMessage);
                            this._FollowUpExamination.ProcedureDoctor = Common.CurrentResource;

                        }
                    }
                }
            }
            
            if(((ITTObject)this._FollowUpExamination).HasErrors == true)
                throw new Exception(((ITTObject)this._FollowUpExamination).GetErrors());
                */
        }
        
        public void MaximizeGroupTab()
        {
            //GroupTab.Location = new Point(12, 12);
            //Size sizeGroupTab = new Size(945, 670);
            //GroupTab.Size = sizeGroupTab;
            _groupTabMaximized = true;
            pnlLeft.Visible = false;
            GroupIdentification.Visible = false;

        }
        
        public void MinimizeGroupTab()
        {
            //GroupTab.Location = new Point(491, 273);
            //Size sizeGroupTab = new Size(482, 236);
            //GroupTab.Size = sizeGroupTab;
            _groupTabMaximized = false;
            pnlLeft.Visible = true;
            //GroupTab.Dock = DockStyle.Bottom;
            GroupIdentification.Visible = true;
        }
        
#endregion FollowUpExaminationDoctorFormNew_Methods
    }
}