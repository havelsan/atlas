
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
    /// Doktor Muayene - Yatan Hasta
    /// </summary>
    public partial class InPatientPhysicianAppDoctorFormNew : BaseNewDoctorExaminationForm
    {
        override protected void BindControlEvents()
        {
            ContinuousInfoTab.SelectedTabChanged += new TTControlEventDelegate(ContinuousInfoTab_SelectedTabChanged);
            btnGroupBox4.Click += new TTControlEventDelegate(btnGroupBox4_Click);
            cmdOutPatientComplaint.Click += new TTControlEventDelegate(cmdOutPatientComplaint_Click);
            cmdDailyProgress.Click += new TTControlEventDelegate(cmdDailyProgress_Click);
            btnFireNewDrugOrderIntroduction.Click += new TTControlEventDelegate(btnFireNewDrugOrderIntroduction_Click);
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
            patientApprovalForm.Click += new TTControlEventDelegate(patientApprovalForm_Click);
            btnNewTreatmentDischarge.Click += new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ContinuousInfoTab.SelectedTabChanged -= new TTControlEventDelegate(ContinuousInfoTab_SelectedTabChanged);
            btnGroupBox4.Click -= new TTControlEventDelegate(btnGroupBox4_Click);
            cmdOutPatientComplaint.Click -= new TTControlEventDelegate(cmdOutPatientComplaint_Click);
            cmdDailyProgress.Click -= new TTControlEventDelegate(cmdDailyProgress_Click);
            btnFireNewDrugOrderIntroduction.Click -= new TTControlEventDelegate(btnFireNewDrugOrderIntroduction_Click);
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
            patientApprovalForm.Click -= new TTControlEventDelegate(patientApprovalForm_Click);
            btnNewTreatmentDischarge.Click -= new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            base.UnBindControlEvents();
        }

        private void ContinuousInfoTab_SelectedTabChanged()
        {
            #region InPatientPhysicianAppDoctorFormNew_ContinuousInfoTab_SelectedTabChanged
            // NIDA! ORTAK COMPONENT YAP
            //if(ContinuousInfoTab.SelectedTab != null)
            //         {
            //             switch (ContinuousInfoTab.SelectedTab.Name)
            //             {
            //                 
            //                 case "ManipulationTab":
            //                     if (!ManipulationGridFilled)
            //                     {
            //                         FillOldManipulationsGrid(this.ManipulationGrid);
            //                         ManipulationGridFilled = true;
            //                     }
            //                     break;
            //             }
            //         }
            #endregion InPatientPhysicianAppDoctorFormNew_ContinuousInfoTab_SelectedTabChanged
        }

        private void btnGroupBox4_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnGroupBox4_Click
   if (_groupTabMaximized)
                MinimizeGroupTab();
            else
                MaximizeGroupTab();
#endregion InPatientPhysicianAppDoctorFormNew_btnGroupBox4_Click
        }

        private void cmdOutPatientComplaint_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_cmdOutPatientComplaint_Click
   PatientExamination patientExamination = null;
            foreach(PatientExamination pe in _InPatientPhysicianApplication.Episode.PatientExaminations)
            {
                if(pe.CurrentStateDefID == PatientExamination.States.Examination || pe.CurrentStateDefID == PatientExamination.States.Completed)
                {
                    patientExamination = pe;
                    break;
                }
            }
            
            if(patientExamination != null)
            {
                _InPatientPhysicianApplication.PatientStory = patientExamination.PatientStory;
                _InPatientPhysicianApplication.Complaint = patientExamination.Complaint;
                _InPatientPhysicianApplication.PhysicalExamination = patientExamination.PhysicalExamination;
            }
#endregion InPatientPhysicianAppDoctorFormNew_cmdOutPatientComplaint_Click
        }

        private void cmdDailyProgress_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_cmdDailyProgress_Click
   MaximizeGroupTab();
            ContinuousInfoTab.ShowTabPage(Progress);
            ContinuousInfoTab.SelectedTab = ContinuousInfoTab.TabPages["Progress"];
#endregion InPatientPhysicianAppDoctorFormNew_cmdDailyProgress_Click
        }

        private void btnFireNewDrugOrderIntroduction_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnFireNewDrugOrderIntroduction_Click
        this.FireNewDrugOrderIntroduction();
#endregion InPatientPhysicianAppDoctorFormNew_btnFireNewDrugOrderIntroduction_Click
        }

        private void LabManTabControl_SelectedTabChanged()
        {
            #region InPatientPhysicianAppDoctorFormNew_LabManTabControl_SelectedTabChanged
            switch (LabManTabControl.SelectedTab.Name)
            {
                case "LabResultTab":
                    //FillLaboratoryResultsGrid(LaboratoryResultsGrid);
                    LabManTabControl.SelectedIndex = 0;
                    PatientLabTestResults labResults = new PatientLabTestResults();
                    labResults.CurrentPatient = _InPatientPhysicianApplication.Episode.Patient;
                    InfoBox.Show("labResults.ShowDialog();");
                    break;
                case "ResultGraphics":
                    //SessionExtension.AddToSession("OldActionFormDefaultTab", 1);
                    OnOpenOldActionsForm(this, _InPatientPhysicianApplication);
                    LabManTabControl.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
            #endregion InPatientPhysicianAppDoctorFormNew_LabManTabControl_SelectedTabChanged
        }

        private void btnBioChemical_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnBioChemical_Click
   Guid microBiologyGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("BIYOKIMYAMAINRESGUID", Guid.Empty.ToString()));

            ResLaboratoryDepartment labDep = (ResLaboratoryDepartment)_InPatientPhysicianApplication.ObjectContext.GetObject(microBiologyGuid, TTObjectDefManager.Instance.ObjectDefs[typeof(ResLaboratoryDepartment).Name], false);
            if (labDep == null)
                this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), null);
            else
                this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), labDep.ObjectID);
#endregion InPatientPhysicianAppDoctorFormNew_btnBioChemical_Click
        }

        private void btnSpecialLabRequest_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnSpecialLabRequest_Click
          this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), null);
#endregion InPatientPhysicianAppDoctorFormNew_btnSpecialLabRequest_Click
        }

        private void btnGeneticRequest_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnGeneticRequest_Click
   this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(Genetic)), null);
#endregion InPatientPhysicianAppDoctorFormNew_btnGeneticRequest_Click
        }

        private void btnPathologyRequest_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnPathologyRequest_Click
   this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyRequest)), null);
#endregion InPatientPhysicianAppDoctorFormNew_btnPathologyRequest_Click
        }

        private void btnNucleerMedicineRequest_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnNucleerMedicineRequest_Click
   this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(NuclearMedicine)), null);
#endregion InPatientPhysicianAppDoctorFormNew_btnNucleerMedicineRequest_Click
        }

        private void btnRadiologyRequest_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnRadiologyRequest_Click
   this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(Radiology)), null);
#endregion InPatientPhysicianAppDoctorFormNew_btnRadiologyRequest_Click
        }

        private void btnMicroBiology_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnMicroBiology_Click
   Guid microBiologyGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("MIKROBIYOLOJIMAINRESGUID", Guid.Empty.ToString()));

   ResLaboratoryDepartment labDep = (ResLaboratoryDepartment)_InPatientPhysicianApplication.ObjectContext.GetObject(microBiologyGuid, TTObjectDefManager.Instance.ObjectDefs[typeof(ResLaboratoryDepartment).Name], false);
            if (labDep == null)
                this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), null);
            else
                this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), labDep.ObjectID);
#endregion InPatientPhysicianAppDoctorFormNew_btnMicroBiology_Click
        }

        private void btnAnesthesiaConsultationNewRequest_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnAnesthesiaConsultationNewRequest_Click
   this.CreateNewAnesthesiaConsultation();
#endregion InPatientPhysicianAppDoctorFormNew_btnAnesthesiaConsultationNewRequest_Click
        }

        private void btnNewConsultationFromOtherHospRequest_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnNewConsultationFromOtherHospRequest_Click
   this.CreateNewConsultationFromOtherHospRequest();
#endregion InPatientPhysicianAppDoctorFormNew_btnNewConsultationFromOtherHospRequest_Click
        }

        private void ttbutton11_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_ttbutton11_Click
   this.CreateNewConsultationRequest();
#endregion InPatientPhysicianAppDoctorFormNew_ttbutton11_Click
        }

        private void btnReports_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnReports_Click
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
                        this.CreateNewHealthCommittee();
                        break;
                    case "2":
                        this.CreateNewHCExaminationFromOtherDepartments();
                        break;
                    case "3":
                        this.CreateNewHealthCommitteeWithThreeSpecialist();
                        break;
                    case "4":
                        this.CreateNewParticipatnFreeDrugReport();
                        break;
                    case "5":
                        this.CreateNewHealthCommitteeOfProfessors();
                        break;
                    case "6":
                        this.CreateNewUnavailableToWorkReport();
                        break;
                    default:
                        break;
                }
            }
#endregion InPatientPhysicianAppDoctorFormNew_btnReports_Click
        }

        private void btnNurseryProcedures_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnNurseryProcedures_Click
   MaximizeGroupTab();
            ContinuousInfoTab.ShowTabPage(NursingOrdersTab);
            ContinuousInfoTab.SelectedTab = ContinuousInfoTab.TabPages["NursingOrdersTab"];
#endregion InPatientPhysicianAppDoctorFormNew_btnNurseryProcedures_Click
        }

        private void btnInpatientAdmission_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnInpatientAdmission_Click
   this.CreateNewInpatientAdmission();
#endregion InPatientPhysicianAppDoctorFormNew_btnInpatientAdmission_Click
        }

        private void btnPrescription_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnPrescription_Click
   this.CreateNewOutPatientPrescription();
#endregion InPatientPhysicianAppDoctorFormNew_btnPrescription_Click
        }

        private void btnEpicrisis_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnEpicrisis_Click
   this.CreateNewEpicrisisReport();
#endregion InPatientPhysicianAppDoctorFormNew_btnEpicrisis_Click
        }

        private void btnTreatmentMaterial_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnTreatmentMaterial_Click
   MaximizeGroupTab();
            ContinuousInfoTab.ShowTabPage(TreatmentMaterialTab);
            ContinuousInfoTab.SelectedTab = ContinuousInfoTab.TabPages["TreatmentMaterialTab"];
#endregion InPatientPhysicianAppDoctorFormNew_btnTreatmentMaterial_Click
        }

        private void btnForensicReport_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnForensicReport_Click
   this.CreateNewForensicMedicalReport();
#endregion InPatientPhysicianAppDoctorFormNew_btnForensicReport_Click
        }

        private void btnManiplation_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnManiplation_Click
   this.CreateNewManipulationRequest();
#endregion InPatientPhysicianAppDoctorFormNew_btnManiplation_Click
        }

        private void btnImportantMedicalInfo_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnImportantMedicalInfo_Click
   this.FireNewImportantMedicalInfo();
#endregion InPatientPhysicianAppDoctorFormNew_btnImportantMedicalInfo_Click
        }

        private void patientApprovalForm_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_patientApprovalForm_Click
            //TO DO NİDA!
         //GetPatientApprovalForm(true);
#endregion InPatientPhysicianAppDoctorFormNew_patientApprovalForm_Click
        }

        private void btnNewTreatmentDischarge_Click()
        {
#region InPatientPhysicianAppDoctorFormNew_btnNewTreatmentDischarge_Click
   this.CreateNewTreatmentDischarge();
#endregion InPatientPhysicianAppDoctorFormNew_btnNewTreatmentDischarge_Click
        }

        protected override void PreScript()
        {
#region InPatientPhysicianAppDoctorFormNew_PreScript
    base.PreScript();
            
            //Button b = (Button)this.btnBioChemical;
            //b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.TextAlign = ContentAlignment.MiddleRight;
            //b.Image = (Image)TTUtils.Deserialize.StringToObject(BiyokimyaIMG);

            //b = (Button)this.btnGeneticRequest;
            //b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.TextAlign = ContentAlignment.MiddleRight;
            //b.Image = (Image)TTUtils.Deserialize.StringToObject(GenetikLabIMG);

            //b = (Button)this.btnMicroBiology;
            //b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.TextAlign = ContentAlignment.MiddleRight;
            //b.Image = (Image)TTUtils.Deserialize.StringToObject(MikrobiyolojiIMG);

            //b = (Button)this.btnNucleerMedicineRequest;
            //b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.TextAlign = ContentAlignment.MiddleRight;
            //b.Image = (Image)TTUtils.Deserialize.StringToObject(NukleerTipIMG);

            //b = (Button)this.btnSpecialLabRequest;
            //b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.TextAlign = ContentAlignment.MiddleRight;
            //b.Image = (Image)TTUtils.Deserialize.StringToObject(OzelLaboratuvarIMG);

            //b = (Button)this.btnPathologyRequest;
            //b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.TextAlign = ContentAlignment.MiddleRight;
            //b.Image = (Image)TTUtils.Deserialize.StringToObject(PatolojiIMG);

            //b = (Button)this.btnRadiologyRequest;
            //b.ImageAlign = ContentAlignment.MiddleLeft;
            //b.TextAlign = ContentAlignment.MiddleRight;
            //b.Image = (Image)TTUtils.Deserialize.StringToObject(RadyolojiIMG);

            rtfImportantMedicalInfo.Rtf = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162 Tahoma;}}{\colortbl ;\red255\green0\blue0;}\viewkind4\uc1\pard\cf1\b\f0\fs20" + rtfImportantMedicalInfo.Text + @"\cf0\b0\par";

            ContinuousInfoTab.HideTabPage(TreatmentMaterialTab);
            ContinuousInfoTab.HideTabPage(Progress);
            ContinuousInfoTab.HideTabPage(NursingOrdersTab);
            //ContinuousInfoTab.HideTabPage(ManipulationTab);
            
            foreach (AccountTransaction accTrx in Episode.GetTransactionsForReceipt(_InPatientPhysicianApplication.Episode))
            {
                if (accTrx.SubEpisodeProtocol.CheckPaid == true)
                {
                    if(accTrx.SubActionProcedure != null || accTrx.SubActionMaterial != null)
                    {
                        if (this._InPatientPhysicianApplication.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                            throw new TTUtils.TTException(SystemMessage.GetMessage(141));
                        else
                            InfoBox.Alert(SystemMessage.GetMessage(141), MessageIconEnum.WarningMessage);
                        break;
                    }
                }
            }
            
            if(SubEpisode.IsSGKSubEpisode(_InPatientPhysicianApplication.SubEpisode))
            {
                labelMedulaOzelDurum.Visible = true;
                MedulaOzelDurum.Visible = true;
            }
            
            base.PreScript();
            
            if(this._InPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Discharged)
            {
                this.labelClinicDischargeDate.Visible=true;
                this.ClinicDischargeDate.Visible=true;
            }
            else
            {
                this.labelClinicDischargeDate.Visible=false;
                this.ClinicDischargeDate.Visible=false;
            }
            
            
            this.Age.Text=this._InPatientPhysicianApplication.Episode.Patient.Age.ToString();
            
            //Daha önceden girilen Orderları ReadOnly Yapar

            // TODO NİDA! daha önce girilen orderlar readonly olmalı
            //int i=1;
            //foreach (ITTGridRow row in this.NursingOrderGrid.Rows)
            //{
            //    if (this.NursingOrderGrid.Rows.Count!=i)
            //    {
            //        foreach (ITTGridCell cell in row.Cells)
            //        {
            //            if(cell.ColumnIndex!=0)
            //                cell.ReadOnly=true;
            //        }
            //    }
            //    i++;
            //}
            
            //int d=1;
            //foreach (ITTGridRow row in this.DrugOrdersGrid.Rows)
            //{
            //    if (this.NursingOrderGrid.Rows.Count!=d)
            //    {
            //        foreach (ITTGridCell cell in row.Cells)
            //        {
            //            if(cell.ColumnIndex!=0)
            //                cell.ReadOnly=true;
            //        }
            //    }
            //    d++;
            //}
            
            bool treatmentMaterialHasDrug = false;
            if(_InPatientPhysicianApplication.InPatientTreatmentClinicApp != null && _InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission is IntensiveCareAfterSurgery) // derlenme için sarf tabına ilaçlar da gelir
                treatmentMaterialHasDrug = true;
            
            if(this._InPatientPhysicianApplication.EmergencyIntervention == null)
            {
                this.EmergencyProtocolNo.Visible = false;
                btnInpatientAdmission.Enabled = false;
                btnPrescription.Enabled = false;
                this.ContinuousInfoTab.TabPages.Remove(this.EmergencyPatientInfo);
                this.ContinuousInfoTab.TabPages.Remove(this.EmergencyDoctor);
                this.ContinuousInfoTab.TabPages.Remove(this.EmergencyPatientInfo);
            }
            else// Acil işlemleri için Sarf tabına ilaçlar da gelir
            {
                treatmentMaterialHasDrug = true;
                this.ContinuousInfoTab.TabPages.Remove(this.Doctor);
            }
            
            //SetStaticValuesOfLocationAndSize();
            
            if(treatmentMaterialHasDrug)
            {
                this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["InPatientPhysicianMaterial"],(ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);
                this.TreatmentMaterialTab.Text="Malzeme/İlaç Sarf";
            }
            else
                this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);
            
            this.SetWarning();
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("DRUGORDERSGRIDREADONLY", "TRUE") == "FALSE")
                this.DrugOrdersGrid.ReadOnly = false;
            
            if(this._InPatientPhysicianApplication.EmergencyIntervention != null)
                this.ResponsibleDoctor.SelectedObject = this._InPatientPhysicianApplication.EmergencyIntervention.ResponsibleDoctor;
            else
                this.ResponsibleDoctor.SelectedObject = this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ProcedureDoctor;
#endregion InPatientPhysicianAppDoctorFormNew_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InPatientPhysicianAppDoctorFormNew_PostScript
    base.PostScript(transDef);
            if(transDef!=null)
            {
                if (this.ProcedureDoctor == null)
                    throw new Exception("'Sorumlu Doktor' seçilmesi zorunludur.");
            }
            FireNutritionDietAction();
            if (transDef == null || ((transDef != null) && (transDef.ToStateDefID == PatientExamination.States.Completed)))
            {
                this.CreateProcedureOrderDetailsAndCompleteOrder();
            }
#endregion InPatientPhysicianAppDoctorFormNew_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region InPatientPhysicianAppDoctorFormNew_ClientSidePostScript
    base.ClientSidePostScript(transDef);  
            this.CheckDiagnosisOzelDurums();
            PrepareInpatientPrescription();
            if(transDef!=null)// Client_Side
            {
                if(transDef.FromStateDef.StateDefID==InPatientPhysicianApplication.States.Application)
                {
                    if(this._InPatientPhysicianApplication.IsForensicMedicalExam==true && this._InPatientPhysicianApplication.Episode.ForensicMedicalReports.Count==0)
                        throw new Exception(SystemMessage.GetMessage(722));
                    this.GiveInformationAboutDischargeProblems();
                    this.CheckTreatmentDischarge();
   
                    GetOrCreateCompanionApplication();
                }
            }
#endregion InPatientPhysicianAppDoctorFormNew_ClientSidePostScript

        }


       


        #region InPatientPhysicianAppDoctorFormNew_Methods
        private const string BiyokimyaIMG = "AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAkAsAAAL/2P/gABBKRklGAAEBAQBgAGAAAP/hAGhFeGlmAABNTQAqAAAACAAEARoABQAAAAEAAAA+ARsABQAAAAEAAABGASgAAwAAAAEAAgAAATEAAgAAABIAAABOAAAAAAAAAGAAAAABAAAAYAAAAAFQYWludC5ORVQgdjMuNS4xMAD/2wBDAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/2wBDAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/wAARCAAtADwDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD+/iiiigAorH1jxFoHh2BrrxBrmj6FarF5zXOsanZaZAsP2yx0/wA1pr2eCMRfb9U0yx8wts+2ajY22fOu7dJM7R/HPgnxDPFbaB4w8La5czrvht9H8QaTqc8yeU8++KKyu5pJF8mKSbcikeVG8mdiMQAdTWRo2u6dr0NzNpzXmLO6+xXcOoaXqmjXltdG1tb4RT2GsWVhfRFrS9tLhGe3CPFOjIzc4tT6lp1rb6hd3V/ZW1rpCSy6rcz3UENvpkcFol/PJqE0kix2SQ2MsV7K9y0ax2kiXDkQurnC8K6tZanb3C23i/SPF8tv9gM1zpUulsLUNptrbt50el3Fwif2jf2eo6pF5hXYLuSzg3QWaNQB1VFFFABXiCfCzSfFHiC58Z6j8QPFPiG4t9f1+PSv7F8QLpum+HYYbt9C1bw1pj6QzXGlXNi2nT+HtfuNHvtI1K5uLKcaoF1qO8upPZL6yh1C1ls7h7uOKXy972N/faZdDy5UlXyr7Tbm0vYctGokENxH5sReGXfDJJG35K/tqf8ABN7Xv2htX8B/HHR/2ivjp8OPiD8H/h9bR6j8NvhH4h1bT/ht8YdR8K6XeX8fhLUvCLah5Om+GvFGo40u60DRbaCyureZZp7C41SSa6lTck04pt3S3Ssm7OT5mlote/Y0pwpzclUqqklCUlJwnNSlFXjTtBNrnfu8z91X96yue9fH74wL4xtfiD4R0r4feLLnwP4M0b4W+Kv+F0HQF1D4f+L59R+Lvw2vbjQ/h34q0y8vYNcOg2Njez+LrdIY5YtRsIIoUcaVPJL+cH7L/wAadK+GHxu+Hdl4/wBKh8OeIviPrXg3RvDM19pM0dhaNqGjPpHiuC71SU2a2M9udela2E07ysVS4uYZrKyuET+aPVfiT8d/2dPjd4jtPCPjX4l/CzxAkfhe9uF0TxF4g8LzXUSeEf2lNQsk1W2sby2i1C0kudT0y9+zX8VxbTNbWcrwsYIyv6k/sHftgfFT9oCx8ax/Gyz8F/EXxN8NdC+FPiv4f+N9R8A+DbHxTpt34l8E+EpfFC32q6PoenSanf63qetT64dZ1BLvWLe40zYl8Y7giCsZh8RKWYPCexowyrD5JXxEqym1VWZzoU/cs5NTc6tndxhFvmSVlBdNTIM2jwZQ4vpY3Cyw+JzmrgPZVoS5qMaObfUnTvSglJ1KfuUpNqUZcrqOb5pP9N/jL+2r8G/FHxz+IFh8ZfHl540+GPgHUtE8H6D4Q+BlqfGXhrw94q0DxH4qtfGtz49fWfGGlaRqfi2J10SPRPFun+G57bT9NlbRotM0vVoNYj1/1n4Yf8FDP2D/AABItt4Rl+LWg2UyW+mywTaPp9rpN81vrCahaavcWmi69Hte3aUW2PItozpEl7Bd6bJ9s1Rrn4rbU9GsLPxBYaZ4A8BaRZ+K7+71bxNZ6Z4W0Oxg17Vr/cLzVdYitdPjXUdSuid09/dCW7kc7zMXFfnYn7OP7Tfi/wCJ32HTPh9a+DvgdDqSOPGFzczeLfGPiTQ3lEv/ABTOgeG7i40LRYb63KpZazr+v3l9aLJ5934Sllg+xS/qPAGR8C55gsbDiTH5rl2Z4WCqR+q18KqGKhJytGjCth3KE4WipXqOLbuuXZfC8SY3PsBicPPKcNh8Xg6zUHKtRqueHqqMXL2tSE1Fqd5ciUU7Jr3tz+1XwB468N/E3wX4a8f+ELx9Q8M+LNJttZ0a7kgltpZbO6UlfNgmVXiljcPFIvzJvRjFJLEUkbr6/KD4bftIfFvwP4J8HeBPCfwb0K28OeEtC0rwvo1iNP8AE0d3babolnDp9o95JPeWkFxdXEMCXNzcgo9zcSzTTqk7uK+gNM/aA+NF/aJcTeCfC9hIzEG2ubPVfNXABydniNlwc8YJ6c4OQPzrMML9UxdelFSVJVajoc9SlVn7DnfsvaTotwdT2fLz8qS5r2SWh9Nharr0Kc3rNwj7TlhOMfacsXPljP3lHmbte7tu2z7foooriNz86/2uP+Ce3wn/AGpNN1u78b+HtO8T+Kb6XVriz8aW2n+HfCPxW0K1u9G1DSLPRtC8Y6DpGlaT4q0nw/p9ybLwl4d+KGla35F1eXVzqfjVbN5baT8Qrv8AZA8G/wDBMi++IXjH4g/tDfD3TPhn8QtLtRpGkfETU9K8JfE3SpfC9zoHhfw14fk0m7vreXxVEmm+F/E0914r8MaHZeF9Vl06yuNCa9g1eGdv60a898c/CT4U/E+OOL4l/DH4e/EOKGIQRReOfBfhvxbHFAsjyrDGmv6bqCpEJZZJBGoCCSR3A3OxNRnKNLF0ovlhjlhI4rROVWOCr08RhotyTcVTq04NctnZcvwtp91TMsdVyl5HPE1HlbxNPF/VG06UcRSrQrxqQTT5Je1gpScbczcr7s/i7j/4KF/BHx/4sPg34TX9941v5GkjXVrfS9SsvDqSK6x7Tq17ZwRSsSxZRbpOXWNtgOUB+7v2TvHvxC+GPg2+8M6v4vi8T2954p8Q6xo8Wp6YZ/7J8Pa/dpqK6C/m29pLePa6i97dC4kla3LXrxw2kEcaZ/ePT/2D/wBj3SJTNpP7Pnw60py27/iWaXNYIDyflitLqGJBz0VAPbgV6fof7PHwS8NzQz6P8NvDNq8AYRpJayXtvhkaM77S/mubWXCuSnmwv5bhZY9siI6886KnVp1VOUJ0lJR5G0mptcykr2knZbptNIrD5hUw+DxeB9lRqUca6MqrnBSnGdBydOdKT1pyXPJPla5otxbs2fnT4P8AiDaa9FKL/Qp7K5cx/Z76wF1bW6k4XMtssUluIycnZBbx9M715r7dsfgJd3NlaXUfj2JlubaC5DWmkDULRvPiWXdaX39r232u1bdm3ufIh8+HZL5Ue/YPf9P8J+FtJniutK8NeH9MuYd4hudP0bTrOeLzI2ifypra2jkj3xO8b7WG6NmQ5ViD0FbLRJXcvN7s88//2Qs=";
        private const string GenetikLabIMG = "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";
        private const string MikrobiyolojiIMG = "AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAArgwAAAL/2P/gABBKRklGAAEBAQBNAE0AAP/hAGhFeGlmAABNTQAqAAAACAAEARoABQAAAAEAAAA+ARsABQAAAAEAAABGASgAAwAAAAEAAgAAATEAAgAAABIAAABOAAAAAAAAAE0AAAABAAAATQAAAAFQYWludC5ORVQgdjMuNS4xMAD/2wBDAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/2wBDAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/wAARCAAtADcDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD+8jxv4mTwxoV5dxsP7Rlgkj0yNlYqbhnhgNw58qSLy7L7Qt3JHLt86OJolOWyPCPhNomjalrOotfWHnahdG81fUbwKkM9/dXM6ma+vpwUuZBNPOXAWZ5nleJ5AYfNx618VdKk1Dw/b3EELST6fqMEhZDkx29wr275iJxMrXLWm5QrMu3fxGshqP4e+CH0EPq+pc6ldRMkUDKpazt5Crt5jld32l8YO3YYomaOTLO0cWEoc9aDlFS9n70W/sNqzavfV7adPvOqlWnRoVY06k4e2ShUUZOPOoyUoxdrXjF2lrs9exp2Pw48OW97Hqd5bLqOoR7tss6KsCsXVlZLYFsYVAjLLLMj7pCy4faveIiRokcaLHHGqoiIoVERQFVEVQFVVUAKoAAAAAxTqydP13RtVmnt9O1OyvJ7YsJ4IJ0eZFUqpl8vO97cs6qtyga3djtSRiCBtotNFf73bT5nO3Od2+aVtW9Wlf8ABXNaqt7fWemWV3qOo3drp+n6fa3F7f397PFa2VlZWsTz3V3d3U7xwW1rbQRvNcXEzpFDEjySOqKSPGv2kP2gfh/+y18EviD8evihdXNt4L+HWinV9VSwjjm1G+kluYLGw03ToJpYI5b3UL+6traLzJY4oVke5uJI7aCaRPyz/Y88efF//gq5Fof7UXxTt9O+Ff7HHh7xxe3fwa/ZzsLz+2fGPxQ1nwpci1t/GXx81GfTrbT18J+eP7R8N+AbKG4h1+3uYdT1eZdCltItfiVRKapr3pvXlXSN7OUuy+9vt1KjTbi5u6pp2crOzenuqy+LW+tla+p+iv2zxr+0W3neG9e8W/C34GhPMsPFehM/hz4k/Fi4DLNY6v4VvrqCS98F/DWJ1hu7HWXs4vEPxBTDWcOmeCZYrzxeV9TUVdu+r+flt22X/Dt3nmfTRaaadt3pq3u/w0sgr4y+MH7dPwL+AL6rf/GDxDZeDfCmlm5h/wCEjubqS6kvNQijM1tpFlodvZf2ld6rqEIFxb2dotw0ds8U921uk0W/7Nr+Ln/gpj4g8Qah+1/+0/4X+IkfiDS9K+Hw8M6j8P8ASy1r5Os+GPGV/c+KZ5tGtLqK4nvLzxLrum2DnVbWMra2nh+00n7RbC2kEPlZtjK+Ep0Fh+RVcRVdGEqkb0oP2cqnNUd42jaDVlJNt2uj7TgXhzB8R5liqOPqVIYTA4RY3EU8PUjDF16f1mhhvZYXmjNOq54iDu4TUIKUnCTsjtPjb/wcA+IrTxnrU/wN8N6WmlGDVYF8R/E4392uuWjpJBti8OaHe2cFnIFEBsrITXAIiVwguLeK2n+L/Af/AAWe/bF8J+I7jxrYeM/BtzBHHND/AGXcaBpUvh7ypMm606a4ikeaSOWZ7Y2vmXl1dQz23mT24vY7aFPjH4iWnwB0jRtTtfHI1G51RE0Ww0e307yrXxa1vo2mWemwR2UFtp8drZ6XfWif2xLLrC3FvY313MTbXU6WNrd/D+va3Hdfa7fT01hbeTULmaHUdav7fUNSuNNaCO1tbe/kFuipcRRwq6tZtDFGXdDHO+24P5picRmWGrc+MzWrXre9Ol9WryhTg+aDd6dJxUWul3LTdt3P6ywGR8JVsFGhk3BeWUMI6UKOJnmeCWPr1kktXisU5uXMptysoRUm4qMVdH7k/Hv/AILufFr49/Dq4+GvxH+HHg2fT7vW9MurvV/DF1qOn3LaCLS4W/0iXRrubUNH1b7b9rVL1pFgguhbPaGLyyhh/dz/AIIKeO9U8UfBb4vWd3dpNoup+L/D/wARvCUcl35ly+l+J9N1HwnfyC0WKOG2htr/AOHq2EixYkF1BKJ4Iomsprv+CqK3luZoba0iknnlcRxRRK0kskjHAVUALbj149Sc4zX9aP8AwRO+LnhT9nJvBnhv4heIptNmv9A8c+EfFcLh5dJ0M+JPEHhvx54Ou5JIInaaSwkl1XTrsLLI1hLrepFrVdrOPS4ezWu8zp/XMXUqqopR5q0k5XlaEVKWmkW03ftfoz898VeEMow3DlTE5Lk+Gy+pSxFFyo5fTn7KSUeapJU3KSheyjamlG72XMf130VlaHruj+JtI0/XvD+p2Ws6Lqlul3p2p6dcR3Vnd27kgSQzRFlbaytHIpIeKVHilVJEdQV+np31Wqeqa6n8su60as1o0+hj+PPENz4U8G+I/EdpZz38+j6Vc3yW9vFJNKFiUeZciGOKeSVLKIvezRJExkht5EG3O4fkT8dPB/wi/aY0sar8WNC0XxFqU8c9voninR400rxZpCSxJJE2jeKbJrbUrKO1JE8cUk32K1uLaJ3s2aFEH7R1+Y37fHwS0Lw/8JvE/wAWPAt9L4K1fRJ49U1nS9KtgdH8RmecmYtapcWy6TezTFZZ7uzDwXBVnuLCW4ke5PFjqXtaTbUZwineEldO+nMr6XSb810fQ9XKcdWwOJhUw9Wrh8Q5JQr0ZOM0m17l078ra9H9rRJr+czxR/wQp0DxP4h1DVfB/wC09qdpptxcNLO3jzwininWraCLbDDHeeI4PEmgnU5LS2jS2SSTTbUlYY1WJI9qjpPBn/BB74TWl55nxH/aU8WeI9GjKM9l4P8ABOjeELy4kViGji1DWNW8XsIWDKM/2fCxHzFt3lge9+Cvjh4yFxrJeZZYvDtjpz/Z3llEV/qOrSaci3MqoUEVpYJqIFrp6h9zwtNPdSzzebH1Xjb9oXxhpslrZ2scayXMIkkuzcyecAqBpBGEjRY3kJ2iRceUuQihiGHx0cky11XUlQlJ817SqTeujTtzW0/Jn6lDxF40lh1hKecezpezVO8MLhYS5VZO8o0FJvzvd6vcteH/APgmB+wJ8OXji07wn411XUYIWSfUdX8dXtxel2Xb5k7WcFpbxTMMuIEijijLB0gUqhHpGhfBL9lb4U/ZW8G/CmwNzZu00V/rmua74mvJLp5GllvJf7f1PUrd7yWd2mlujbiV5naUt5pD18vXnx58WiK2uGjgcTmcCLzZAsflFQSDg7mdpCdxAKqNi9WY7mifETVvEJhS8iRfMmCkpK5GESW4bAZer7Ej64VQSBkjHZDDYKjLmp4WlGa2kqcbrRa37u3k797ni4vOM/x9F0sZm2NxNJuMnSniKns7/wCC/K7NvS1rbdEfZlt8RdejuN3hu+vPDceGSNrK/uLMbVyfLjlt5LB5DsJ3RxROqp95goG4r84/jp8TviLpmofBfwH4A8SJ4J8WfHiTxZIfiIunRa1d+BdB8B6PN4kk0Xw9oNzNa2k1x4jurSK01XV7q9WVbDMEVoW/eUVrTxGIqR5qEV7NScfelZ3XLey5lZdtPPoeN7GjHSo1zbv3W+3Xlfn/AJdH/9kL";
        private const string NukleerTipIMG = "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";
        private const string OzelLaboratuvarIMG = "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";
        private const string PatolojiIMG = "AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAiAsAAAL/2P/gABBKRklGAAEBAQBgAGAAAP/hAGhFeGlmAABNTQAqAAAACAAEARoABQAAAAEAAAA+ARsABQAAAAEAAABGASgAAwAAAAEAAgAAATEAAgAAABIAAABOAAAAAAAAAGAAAAABAAAAYAAAAAFQYWludC5ORVQgdjMuNS4xMAD/2wBDAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/2wBDAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/wAARCAAtAC0DASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD+jr/gtv8AE3/gpv8AA/4Q+A/jZ/wT3l0eXQfhbeeI/FPx00g+DbHx1rN9otvaWSaNf6t4euLW81u++HOgQtrOqeM4/BNvL4khtEXUZX0/T9OfWtL/AJ5fCn/B1B+2LZz6B8QvFHwt/Z98aaJd2Fra+Pfgr4b0jxh4Nv8Awze6ctrb3s/grxprni7WL3UdZ1y5nvtTEWqxeIvC1ho+kfYrXU5NcvLm30v+9Z0WRGjkVXR1ZHR1DI6MCrKysCGVgSGUgggkEYr+ez9vL/g3w/Y0/aP1Wz+Ifwx8Ja78FfEz6jB/wmPhD4RS6Tofw+8ZaWZZ7557nwZNarBoOo2mpxaZPZP4HutBtIpLdbqTRrq6Et1WNdzhCc48z5YtuMVeWln7i1u9NrPrbUqNm7ProvJ3Xc9l/wCCfH/Bc/8AZc/4KAx+J9K8NeHvF/wv+IHgXULC38a+AfGJhn1XR9I1V7iHTPGFpLFbWD6p4Uurq3MEt6llbalpxuLIappFlNc+Qn7XI6SokkbrJHIqvHIjB0dHAZXRlJVlZSGVlJBBBBINfyn/ALFX/BPXRP2E/CPxHttE8Z2vjHV/FmswXnjH4p+PlmtNZsfCfgu31ptCstS0qx0LQ7e5Hh6HUdSiujLr+n26vcXmrSTRuGsJvvX4UftBxeKltD4H+NHifxJANMFnbSWGpa5DoFxHbzeRLHo/9pzXl7p6WEls9oNHh1SO1sGimiW086KTy/IpZum5uUZTgn7srKMlaykpJqOqfTf8EayotKNrcz3infpo/wA+/TzP29or5O/Zy+Pei+N9S8QfB3W7vW4vip4C06HxDqEXiGM/8Vb4Q13Urn+zvFfhbUWllGuaRpdzNF4a1pv3d3o2qw2kN9BHbappF1f/AFjXvyhUgqbqU503UpUq0IzVm6daEalOS6NShJNNXTOOlWpV4ylRqRqRhUqUpOLvy1aU3TqU5dYzhOLjKLs012sFfzu/8FFP+DgX4H/smeKZvhr+z4fCX7Rvxf8ABXxQu/A3xm+Hd6PG3guP4fxeDLzxDY+OdM/4TC50CTRtV8S32tabYeFNMbSbfVbDwpdjUNf1OHxTbeRoaf0RV4V8QP2c/gh4707xOdc+BHwK8Zav4meS81U/ED4X+EfEOneINTkCo134n+16HeXOrO8a7ZJ7nz7hwqqX2jjOXM17rUX3av17XXQ2Vr6pteTsfwuT/wDBUP4MftC+IfjX8Tvi9p37X/w8+H/xh+Mms/8ACG2vhLw1q/jnw38Ltbfw14Q8Tp4au9F1PxX4E+Gnjfw/qOoDxI2uWEw0jVvEdjqGpXllLpt9Hb6zon6D/sXfHr9hTUPGmh/BX9k/4q+LvF+vwafe+K7rRfGvh/xkPGepLbrpo1vWtb1S+h1rSrQWsr21laabe+LtR1Ky0iHT7N7zUWt3vZfyk/4Kr/sIz/s9wWHwfT4t/sLeFfib8XfilbO3wz+BnxL+NtprugeKvGf2C503TNW+Amp2vjvwz8LPBGn6jrqab4Q8RW8HgzQLqwtdKsobHw3p+pweHrD1v/gjL8Rb34ERfta6J8fdR+HWgaf8FPAfw3v/ABf8QNNstD0BbbRPh/od14MN3qMWgSXVprD32k+HrXWtd1Wwlur7VfFNzc3uppdeIvEB87wsdRj7OdNy9+/PaEUm5ScVdte673Wlk3prY3hK7jZtKL3ey206v1s0vzP6cvFOtN4J8WfBr40aNc2sGpfDj4leGtK8R3JazX7Z8MPiB4g034ffE3S7q5uQv+hWGi65b+NVs0nja58QeBPD2zdPbQIf2fr+O34AeMP2ZfG/wl/a38a/s2/tPfEb46Q/Fe0+JfxX1fwV8QPF91dal8JPEer2vibxDp+meF/h54j8P+GPFfw58N3+sx3U+i2/iDSWfVLfT4JINTv4NOWcf2C6ZqFtq2m6fqtmxez1OytNQtXYAM1tewR3MDEKzKC0UikgMwyeGI5r38HOVXJcDKo5ynQxePwcZTjblw0I4PEUaffSricVJJt25tDxqTUM4zOlBKEKtDL8Y4r7WIq/WsPiKlttaeFwsflrcu1yfjXxR/wiGgz6wtg2pzrNDb21l9pWySaebcVE120NybeMIjnzFtrht+xfLCs0idZXM+L/AAxbeMNAvtCubu7077Uoa31GwFsbzT7qPJhu7dL23u7OV4ySDFdWs8MiM6smSrLFTncJ+zaVTlfI3spdL6P8j0o25lzX5bq9t7dT+Lb9q/8A4Is/svae3xv/AGgv2hP2lfiD8PPhn4i8deLvjL8RdY1Ow8Aw/wBi/wDCTeIG1W9sLTxpcQ6pM/k6jqEOmeGmfwhfa3cXEmnadaQXt9crBce565+xV+zL8fP2OfiL4R/YO074faH4j+Pfw88F6l4V+JGkaDfWH/CXQ6d4j8P/ABC8Lp4jv9P0Ia7Z2fiK70SFtXjt9EbULE6g+rT+H7i9VLeb+hj4yfsGfCT9pLwx4z+FP7REFt8TvgP4rfwjOfhmLbXfCl9dT+FvEWl+LfL8WeM9A8WQXuu6fP4h0DQ721svD+leCmt4LS5sNTudctb6RI/pf4T/AAY+FHwJ8F+H/h38Hfh94V+HPgrwrpFnoOgeHvCukWumWWnaRYRrFZ2SNEn2ieOFFUK11NPKxG55GbmvIp5fipck69dqcJXa+NWVuXltyq91e8rvbQ3lVhtCLtayb0fS/fpf7+1z+Kz9gP8A4IgftE/sYfHPVPij8edf0yax+KPhK5+D+h+G/B1xr0tvqlz40l07VLnTb/WvEOk+Gri+19f7DudN0XSI9BYyWEc2ptJEbX7JD/b74O0uTQ/CPhXRJYpIJdH8OaHpckE00dxLDJp+mWto8UtxEzxTyRtCUeaJ3jlYF0ZlYE9HRXr0ozpwdN1ZzpuXOoStyxlyqLkkl8UlFXe7SSeyOX2dP2jqqnFVXBU5VEvecItyjFveyk5NLpdn/9kL";
        private const string RadyolojiIMG = "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";
        public bool _groupTabMaximized = false;
        public bool ManipulationGridFilled = false;
        
        
        
        public void SetWarning()
        {
            if(this._InPatientPhysicianApplication.InPatientTreatmentClinicApp!=null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission!=null)
            {
                if(!this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.MasterResource.ObjectID.Equals(this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic.ObjectID))//Farklı bir yatakta kalıyorsa
                {
                    BindingList<BaseBedProcedure> bedProcedureList = BaseBedProcedure.GetByEpisodeOrderByLastBed(this._InPatientPhysicianApplication.ObjectContext,this._InPatientPhysicianApplication.Episode.ObjectID);
                    {
                        BaseBedProcedure lastBedProcedure=null;
                        long? count=0;
                        foreach (BaseBedProcedure bedProcedure in bedProcedureList)
                        {
                            if(lastBedProcedure!=null)
                            {
                                if(!lastBedProcedure.Bed.Room.RoomGroup.Ward.ObjectID.Equals(bedProcedure.Bed.Room.RoomGroup.Ward.ObjectID))
                                    break;
                            }
                            if(bedProcedure.BedDischargeDate==null)
                            {
                                count += Common.DateDiff(Common.DateIntervalEnum.Day,Convert.ToDateTime(Common.RecTime()),Convert.ToDateTime(bedProcedure.BedInPatientDate));
                            }
                            else
                            {
                                count += bedProcedure.Amount;
                            }
                            lastBedProcedure=bedProcedure;
                        }
                        if(lastBedProcedure!=null)
                        {
                            Warning.Visible = true;
                            if(count==0)
                                this.Warning.Text="Hasta bu gün " + lastBedProcedure.Bed.Room.RoomGroup.Ward.Name + " bölümünde yatmıştır";
                            else
                                this.Warning.Text="Hasta " + count + " gündür " + lastBedProcedure.Bed.Room.RoomGroup.Ward.Name + " bölümünde yatmaktadır";
                        }
                    }
                }
            }
        }
        
        public void FireNutritionDietAction()
        {
            NutritionDietAction nutritionDietAction = null;
            foreach(NutritionDietOrder nutritionDietProcedure in this._InPatientPhysicianApplication.NutritionDiets)
            {
                if (nutritionDietProcedure.NutritionDietAction == null)
                {
                    if(nutritionDietAction == null)
                    {
                        nutritionDietAction = new NutritionDietAction();
                        nutritionDietAction.ActionDate = Common.RecTime();
                        this._EpisodeAction.LinkedActions.Add(nutritionDietAction);
                        nutritionDietAction.FromResource = this._InPatientPhysicianApplication.MasterResource;
                        nutritionDietAction.Episode = this._InPatientPhysicianApplication.Episode;
                        nutritionDietAction.CurrentStateDefID = NutritionDietAction.States.New;
                        if (nutritionDietAction.MasterResource == null)
                            nutritionDietAction.MasterResource = this._InPatientPhysicianApplication.MasterResource;
                    }
                    nutritionDietProcedure.NutritionDietAction = nutritionDietAction;
                }
            }
        }



        public bool IsAdressInfoMissing()
        {
            var patientAdmission = _InPatientPhysicianApplication.SubEpisode.PatientAdmission;

            if (patientAdmission.PA_Address.HomeAddress == null)
                return true;
            if (patientAdmission.PA_Address.HomeCountry == null)
                return true;
            else
            {
                string turkey = TTObjectClasses.SystemParameter.GetParameterValue("TURKEYCOUNTRYOBJECTID", "27ff15c1-c50d-4b9a-bff8-b010939c39d6");
                Guid turkeyID = new Guid(turkey);
                if (patientAdmission.PA_Address.HomeCountry.ObjectID.Equals(turkeyID))
                {
                    if (patientAdmission.PA_Address.HomeCity == null)
                        return true;
                    if (patientAdmission.PA_Address.HomeTown == null)
                        return true;
                }
            }

            return false;
        }

        public string GetDischargeProblems()
        {
            string message = "";
            int count = 1;
            BindingList<AccountTransaction.GetToBeNewTrxsByEpisode_Class> getToBeNewTrxsByEpisode_ClassList = AccountTransaction.GetToBeNewTrxsByEpisode(this._InPatientPhysicianApplication.ObjectContext,this._InPatientPhysicianApplication.Episode.ObjectID);
            foreach(AccountTransaction.GetToBeNewTrxsByEpisode_Class  tahakkuk in getToBeNewTrxsByEpisode_ClassList)
            {
                message += count + ")'" + tahakkuk.TransactionDate + "'-" +  tahakkuk.Description + " \r\n";
                count++;
            }
            if(message != "")
            {
                message += "işlemleri uygulandıysa tamamlanmalı, uygulanmadı ise iptal edilmelidir.\r\n";
            }
            foreach(Surgery surgery in this._InPatientPhysicianApplication.Episode.Surgeries)
            {
                if(surgery.CurrentStateDefID != Surgery.States.Completed && surgery.CurrentStateDefID != Surgery.States.Cancelled )
                {
                    message += count + ")'" + surgery.ID.ToString() + "' işlem no'lu ameliyat işlemi '"+ surgery.CurrentStateDef.DisplayText + "' adımında kalmıştır.\r\n";
                    count++;
                }
            }
            foreach(IntensiveCareAfterSurgery intensiveCareAfterSurgery in this._InPatientPhysicianApplication.Episode.IntensiveCareAfterSurgeries)
            {
                if(intensiveCareAfterSurgery.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    message += count + ")'" + intensiveCareAfterSurgery.ID.ToString() + "' işlem no'lu derleme işlemi tamamlanmamıştır.\r\n";
                    count++;
                }
            }
            
            bool foundCreatingEpicrisis = false;
            foreach(CreatingEpicrisis creatingEpicrisis in this._InPatientPhysicianApplication.Episode.CreatingEpicrisis)
            {
                if(creatingEpicrisis.ProcedureSpeciality == null || this._InPatientPhysicianApplication.ProcedureSpeciality == null)// epikrizin yada doktor işlemlerinin specialitysi set edilmemişse uyarı versin ki sorun oldğu görülsün
                    foundCreatingEpicrisis= true;
                else if(this._InPatientPhysicianApplication.ProcedureSpeciality.ObjectID.ToString() == creatingEpicrisis.ProcedureSpeciality.ObjectID.ToString())
                    foundCreatingEpicrisis = true;
            }
            if(!foundCreatingEpicrisis)
            {
                message += count + ")" + (this._InPatientPhysicianApplication.ProcedureSpeciality == null ? "":this._InPatientPhysicianApplication.ProcedureSpeciality.Name) + " uzmanlık dalı için epikriz yazılmamıştır.\r\n";
                count++;
            }
            if(this.IsAdressInfoMissing())
            {
                message += count + ")" + "Hastanın adres bilgileri eksiktir.\r\n";
                count++;
            }
            
            return message;
        }
        
        private void CreateProcedureOrderDetailsAndCompleteOrder()
        {
            foreach (ProcedureOrder procedureOrder in this._InPatientPhysicianApplication.ProcedureOrders)
            {
                if (procedureOrder.CurrentStateDefID == ProcedureOrder.States.New)
                {
                    procedureOrder.Update();
                    procedureOrder.CurrentStateDefID = ProcedureOrder.States.Planned;
                }
            }
        }
        
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == InPatientPhysicianApplication.States.Discharged)
            {
                TTObjectContext context = new TTObjectContext(true);
                string objectID = this._InPatientPhysicianApplication.ObjectID.ToString();
                Guid EPISODE = this._InPatientPhysicianApplication.Episode.ObjectID;
                
                IBindingList companionApp = CompanionApplication.GetCompanionApplicationByEpisode(context, EPISODE.ToString());
                
                if(companionApp.Count > 0)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new  Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> propertyObjectID = new TTReportTool.PropertyCache<object>();
                    propertyObjectID.Add("VALUE", objectID);
                    parameter.Add("TTOBJECTID", propertyObjectID);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CompanionInformationReport),true,1,parameter);

                }
            }
        }
        
        
        
        public void MaximizeGroupTab()
        {
        //    GroupTab.Location = new Point(12, 12);
        //    Size sizeGroupTab = new Size(945, 650);
        //    GroupTab.Size = sizeGroupTab;
        //    Size sizertfHistory = new Size(900, 450);
        //    rtfHistory.Size = sizertfHistory;
        //    _groupTabMaximized = true;

        //    pnlLeft.Visible = false;
        //    pnlRightBottom.Visible = false;
        //    GroupIdentification.Visible = false;
            
        //    TabControl t;
        //    t = (TabControl)ContinuousInfoTab;
        //    t.Visible = false;
        //    ContinuousInfoTab.ShowTabPage(TreatmentMaterialTab);
        //    ContinuousInfoTab.ShowTabPage(Progress);
        //    ContinuousInfoTab.ShowTabPage(NursingOrdersTab);
        //    t.Visible = true;
        }
        
        public void MinimizeGroupTab()
        {
            //GroupTab.Location = new Point(495, 343);
            //Size sizeGroupTab = new Size(482, 277);
            //GroupTab.Size = sizeGroupTab;
            //Size sizertfHistory = new Size(468, 64);
            //rtfHistory.Size = sizertfHistory;
            //rtfHistory.Dock = DockStyle.Bottom;
            //_groupTabMaximized = false;

            //pnlLeft.Visible = true;
            //pnlRightBottom.Visible = true;
            //GroupIdentification.Visible = true;
            
            //TabControl t;
            //t = (TabControl)ContinuousInfoTab;
            //ContinuousInfoTab.HideTabPage(NursingOrdersTab);
            //ContinuousInfoTab.HideTabPage(Progress);
            //ContinuousInfoTab.HideTabPage(TreatmentMaterialTab);
        }
        
#endregion InPatientPhysicianAppDoctorFormNew_Methods

#region InPatientPhysicianAppDoctorFormNew_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            string barcode = Common.PrepareBarcode(value);
            Material material = null;
            IList materials = _InPatientPhysicianApplication.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
            List<Material> findMaterials = new List<Material>();
            if (materials.Count == 0)
            {
                IList productDefinitions = _InPatientPhysicianApplication.ObjectContext.QueryObjects("PRODUCTDEFINITION", "PRODUCTNUMBER ='" + barcode + "'");
                if (productDefinitions.Count > 0)
                {
                    foreach (ProductDefinition product in productDefinitions)
                    {
                        IList mpl = _InPatientPhysicianApplication.ObjectContext.QueryObjects("MATERIALPRODUCTLEVEL", "PRODUCT=" + ConnectionManager.GuidToString(product.ObjectID));
                        foreach (MaterialProductLevel level in mpl)
                        {
                            Store store = this.GetStore(this._EpisodeAction.ObjectDef);
                            double inheld = level.Material.StockInheld(store);
                            if (inheld > 0)
                                findMaterials.Add(level.Material);
                        }
                    }
                    if (findMaterials.Count == 1)
                        material = findMaterials[0];
                    else if (findMaterials.Count > 1)
                    {
                        MultiSelectForm multiSelectForm = new MultiSelectForm();
                        foreach (Material m in findMaterials)
                        {
                            multiSelectForm.AddMSItem(m.Name, m.Name, m);
                        }
                        string key = multiSelectForm.GetMSItem(this.ParentForm, "Malzeme seçin");

                        if (string.IsNullOrEmpty(key))
                            InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                        else
                            material = multiSelectForm.MSSelectedItemObject as Material;
                    }
                    else
                        InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
                }
                else
                {
                    InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
                }
            }
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (Material m in materials)
                {
                    multiSelectForm.AddMSItem(m.Name, m.Name, m);
                }
                string key = multiSelectForm.GetMSItem(this.ParentForm, "Malzeme seçin");

                if (string.IsNullOrEmpty(key))
                    InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                //Sarf edilecek miktar girişi
                string retAmount = InputForm.GetText("Sarf Edilecek Miktarı Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }

                BaseTreatmentMaterial returningDocument = _InPatientPhysicianApplication.TreatmentMaterials.AddNew();
                
                returningDocument.Material = material;
                returningDocument.Amount = amount;
            }
        }
        
        
      
        protected void GiveInformationAboutDischargeProblems()
        {
            var message =  GetDischargeProblems();
            if(message != "")
            {
                string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Taburcu Et,&Vazgeç", "T,V", "Uyarı", "Taburcu İşlemi", "Hasta aşağıdaki sebeplerden kliniğinize iade edilebilir. \r\n" + message + "\r\n" + "Yinede hastayı taburcu etmek istiyor musunuz?");
                if (result == "V")
                {
                    throw new Exception(SystemMessage.GetMessage(724));
                }
            }
        }
        
         protected void GetOrCreateCompanionApplication()
         {
         int count = 0;
                    CompanionApplication companionApp = new CompanionApplication();
                    foreach (CompanionApplication companionApplication in this._InPatientPhysicianApplication.Episode.CompanionApplications)
                    {
                        companionApp = companionApplication;
                        count = 1;
                    }
                    if(count == 1)
                    {
                        //TODO ShowEdit!
                        //CompanionApplicationForm compAppForm = new CompanionApplicationForm();
                        //if (compAppForm != null)
                        //    compAppForm.ShowEdit(this.FindForm(), companionApp);
                    }
         }
        
        
        protected void PrepareInpatientPrescription()
        {
            // Yatan Hasta için Yatan Hasta Reçetesi Hazırlama. SS

            bool isMedulaEpisode = SubEpisode.IsSGKSubEpisode(_InPatientPhysicianApplication.SubEpisode);
            if(this._InPatientPhysicianApplication.Episode.PatientStatus == PatientStatusEnum.Inpatient)
            {
                Dictionary<Guid, DrugOrder> drugOrders = new Dictionary<Guid, DrugOrder>();
                Dictionary<object, double> normalPrescriptions = new Dictionary<object, double>();
                Dictionary<object, double> greenPrescriptions = new Dictionary<object, double>();
                Dictionary<object, double> orangePrescriptions = new Dictionary<object, double>();
                Dictionary<object, double> redPrescriptions = new Dictionary<object, double>();
                Dictionary<object, double> purplePrescriptions = new Dictionary<object, double>();
                string message = string.Empty;
                ResUser currentUser = Common.CurrentResource ;
                ((ITTObject)currentUser).Refresh();
                string eRecetePassword = currentUser.ErecetePassword;
                foreach (ITTGridRow row in this.DrugOrdersGrid.Rows)
                {
                    if (((ITTObject)row.TTObject).IsNew)
                    {
                        DrugOrder drugOrder = ((DrugOrder)row.TTObject);
                        if (drugOrders.ContainsKey(drugOrder.Material.ObjectID) == false)
                        {
                            drugOrders.Add(drugOrder.Material.ObjectID, drugOrder);
                        }
                        else
                        {
                            throw new TTException(SystemMessage.GetMessageV2(723, drugOrder.Material.Name.ToString()));
                        }
                    }
                }
                
                foreach(KeyValuePair<Guid , DrugOrder> order in drugOrders)
                {
                    if (order.Value.Type == "Yatan Hasta Reçetesi")
                    {
                        DrugOrder drugOrder = order.Value;
                        InpatientDrugOrder inpatientDrugOrder = new InpatientDrugOrder(drugOrder.ObjectContext);//inpatientPrescription.InpatientDrugOrders.AddNew();
                        inpatientDrugOrder.ActionDate = drugOrder.ActionDate;
                        inpatientDrugOrder.Amount = drugOrder.Amount;
                        inpatientDrugOrder.Day = drugOrder.Day;
                        inpatientDrugOrder.DoseAmount = drugOrder.DoseAmount;
                        inpatientDrugOrder.Frequency = drugOrder.Frequency;
                        inpatientDrugOrder.FromResource = drugOrder.FromResource;
                        inpatientDrugOrder.MasterResource = drugOrder.MasterResource;
                        inpatientDrugOrder.Episode = drugOrder.Episode;
                        inpatientDrugOrder.Material = drugOrder.Material;
                        inpatientDrugOrder.UsageNote = drugOrder.UsageNote;
                        inpatientDrugOrder.DrugOrderID = drugOrder.ObjectID;
                        if (drugOrder.MagistralChemicalDetails.Count > 0)
                        {
                            foreach (MagistralChemicalDetail magistralChemicalDetail in drugOrder.MagistralChemicalDetails)
                            {
                                MagistralChemicalDetail inMagistralChemicalDetail = new MagistralChemicalDetail(drugOrder.ObjectContext);

                                inMagistralChemicalDetail.MagistralChemicalDefinition = magistralChemicalDetail.MagistralChemicalDefinition;
                                inMagistralChemicalDetail.ChemicalAmount = magistralChemicalDetail.ChemicalAmount;
                                inpatientDrugOrder.MagistralChemicalDetails.Add(inMagistralChemicalDetail);
                            }
                        }
                        if (drugOrder.MagistralDrugDetails.Count > 0)
                        {
                            foreach (MagistralDrugDetail magistralDrugDetail in drugOrder.MagistralDrugDetails)
                            {
                                MagistralDrugDetail inMagistralDrugDetail = new MagistralDrugDetail(drugOrder.ObjectContext);
                                inMagistralDrugDetail.Material = magistralDrugDetail.Material;
                                inMagistralDrugDetail.PreparatAmount = magistralDrugDetail.PreparatAmount;
                                inpatientDrugOrder.MagistralDrugDetails.Add(inMagistralDrugDetail);
                            }
                        }
                        inpatientDrugOrder.CurrentStateDefID = InpatientDrugOrder.States.New;
                        inpatientDrugOrder.NursingApplication = _InPatientPhysicianApplication.InPatientTreatmentClinicApp.NursingApplications[0];

                        switch (((DrugDefinition)drugOrder.Material).PrescriptionType)
                        {
                            case PrescriptionTypeEnum.NormalPrescription:
                                {
                                    normalPrescriptions.Add(inpatientDrugOrder, (double)inpatientDrugOrder.Amount);
                                    break;
                                }
                            case PrescriptionTypeEnum.GreenPrescription:
                                {
                                    greenPrescriptions.Add(inpatientDrugOrder, (double)inpatientDrugOrder.Amount);
                                    break;
                                }
                            case PrescriptionTypeEnum.OrangePrescription:
                                {
                                    orangePrescriptions.Add(inpatientDrugOrder, (double)inpatientDrugOrder.Amount);
                                    break;
                                }
                            case PrescriptionTypeEnum.RedPrescription:
                                {
                                    redPrescriptions.Add(inpatientDrugOrder, (double)inpatientDrugOrder.Amount);
                                    break;
                                }
                            case PrescriptionTypeEnum.PurplePrescription:
                                {
                                    purplePrescriptions.Add(inpatientDrugOrder, (double)inpatientDrugOrder.Amount);
                                    break;
                                }
                        }
                    }
                }
                if (normalPrescriptions.Count > 0)
                {
                    InpatientPrescription inpatientPrescription = new InpatientPrescription(_InPatientPhysicianApplication.ObjectContext);

                    if (isMedulaEpisode)
                    {
                        if(string.IsNullOrEmpty(eRecetePassword))
                        {   
                            //ToDO ShowEdit!
                            //TTVisual.TTForm passwordForm = new TTFormClasses.PasswordForm();
                            //TTFormClasses.InPatientPhysicianAppDoctorFormNew prescriptionForm = new TTFormClasses.InPatientPhysicianAppDoctorFormNew();
                            //passwordForm.ShowEdit(prescriptionForm.FindForm(), inpatientPrescription);
                            //eRecetePassword = inpatientPrescription.ERecetePassword;
                        }
                        else
                            inpatientPrescription.ERecetePassword = eRecetePassword;
                    }

                    inpatientPrescription.ActionDate = Common.RecTime();
                    inpatientPrescription.FillingDate = Common.RecTime();
                    inpatientPrescription.FromResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.MasterResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.Episode = _InPatientPhysicianApplication.Episode;
                    inpatientPrescription.PrescriptionNO = "0";
                    inpatientPrescription.PrescriptionType = PrescriptionTypeEnum.NormalPrescription;
                    inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    message = message + "Normal Reçeteye Çıkacak İlaçlar: \r\n";
                    foreach (KeyValuePair<object, double> normal in normalPrescriptions)
                    {
                        inpatientPrescription.InpatientDrugOrders.Add((InpatientDrugOrder)normal.Key);
                        message = message + ((InpatientDrugOrder)normal.Key).Material.Name.ToString() + "\r\n";
                    }
                }
                if (greenPrescriptions.Count > 0)
                {
                    InpatientPrescription inpatientPrescription = new InpatientPrescription(_InPatientPhysicianApplication.ObjectContext);
                    
                    if (isMedulaEpisode)
                    {
                        if(string.IsNullOrEmpty(eRecetePassword))
                        {
                            //ToDO ShowEdit!
                            //TTVisual.TTForm passwordForm = new TTFormClasses.PasswordForm();
                            //TTFormClasses.InPatientPhysicianAppDoctorFormNew prescriptionForm = new TTFormClasses.InPatientPhysicianAppDoctorFormNew();
                            //passwordForm.ShowEdit(prescriptionForm.FindForm(), inpatientPrescription);
                            //eRecetePassword = inpatientPrescription.ERecetePassword;
                        }
                        else
                            inpatientPrescription.ERecetePassword = eRecetePassword;
                    }
                    
                    inpatientPrescription.ActionDate = Common.RecTime();
                    inpatientPrescription.FillingDate = Common.RecTime();
                    inpatientPrescription.FromResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.MasterResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.Episode = _InPatientPhysicianApplication.Episode;
                    inpatientPrescription.PrescriptionNO = "0";
                    inpatientPrescription.PrescriptionType = PrescriptionTypeEnum.GreenPrescription;
                    inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    message = message + "Yeşil Reçeteye Çıkacak İlaçlar: \r\n";
                    foreach (KeyValuePair<object, double> green in greenPrescriptions)
                    {
                        inpatientPrescription.InpatientDrugOrders.Add((InpatientDrugOrder)green.Key);
                        message = message + ((InpatientDrugOrder)green.Key).Material.Name.ToString() + "\r\n";
                    }
                }
                if (orangePrescriptions.Count > 0)
                {
                    InpatientPrescription inpatientPrescription = new InpatientPrescription(_InPatientPhysicianApplication.ObjectContext);
                    
                    if (isMedulaEpisode)
                    {
                        if(string.IsNullOrEmpty(eRecetePassword))
                        {
                            //TODO ShowEdit!
                            //TTVisual.TTForm passwordForm = new TTFormClasses.PasswordForm();
                            //TTFormClasses.InPatientPhysicianAppDoctorFormNew prescriptionForm = new TTFormClasses.InPatientPhysicianAppDoctorFormNew();
                            //passwordForm.ShowEdit(prescriptionForm.FindForm(), inpatientPrescription);
                            //eRecetePassword = inpatientPrescription.ERecetePassword;
                        }
                        else
                            inpatientPrescription.ERecetePassword = eRecetePassword;
                    }
                    
                    inpatientPrescription.ActionDate = Common.RecTime();
                    inpatientPrescription.FillingDate = Common.RecTime();
                    inpatientPrescription.FromResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.MasterResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.Episode = _InPatientPhysicianApplication.Episode;
                    inpatientPrescription.PrescriptionNO = "0";
                    inpatientPrescription.PrescriptionType = PrescriptionTypeEnum.OrangePrescription;
                    inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    message = message + "Turuncu Reçeteye Çıkacak İlaçlar: \r\n";
                    foreach (KeyValuePair<object, double> orange in orangePrescriptions)
                    {
                        inpatientPrescription.InpatientDrugOrders.Add((InpatientDrugOrder)orange.Key);
                        message = message + ((InpatientDrugOrder)orange.Key).Material.Name.ToString() + "\r\n";
                    }
                }
                if (redPrescriptions.Count > 0)
                {
                    InpatientPrescription inpatientPrescription = new InpatientPrescription(_InPatientPhysicianApplication.ObjectContext);
                    
                    if (isMedulaEpisode)
                    {
                        if(string.IsNullOrEmpty(eRecetePassword))
                        {
                            //TODO ShowEdit!
                            //TTVisual.TTForm passwordForm = new TTFormClasses.PasswordForm();
                            //TTFormClasses.InPatientPhysicianAppDoctorFormNew prescriptionForm = new TTFormClasses.InPatientPhysicianAppDoctorFormNew();
                            //passwordForm.ShowEdit(prescriptionForm.FindForm(), inpatientPrescription);
                            //eRecetePassword = inpatientPrescription.ERecetePassword;
                        }
                        else
                            inpatientPrescription.ERecetePassword = eRecetePassword;
                    }
                    
                    inpatientPrescription.ActionDate = Common.RecTime();
                    inpatientPrescription.FillingDate = Common.RecTime();
                    inpatientPrescription.FromResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.MasterResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.Episode = _InPatientPhysicianApplication.Episode;
                    inpatientPrescription.PrescriptionNO = "0";
                    inpatientPrescription.PrescriptionType = PrescriptionTypeEnum.RedPrescription;
                    inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    message = message + "Kırmızı Reçeteye Çıkacak İlaçlar: \r\n";
                    foreach (KeyValuePair<object, double> red in redPrescriptions)
                    {
                        inpatientPrescription.InpatientDrugOrders.Add((InpatientDrugOrder)red.Key);
                        message = message + ((InpatientDrugOrder)red.Key).Material.Name.ToString() + "\r\n";
                    }
                }
                if (purplePrescriptions.Count > 0)
                {
                    InpatientPrescription inpatientPrescription = new InpatientPrescription(_InPatientPhysicianApplication.ObjectContext);
                    if (isMedulaEpisode)
                    {
                        if(string.IsNullOrEmpty(eRecetePassword))
                        {
                            //TODO ShowEdit!
                            //TTVisual.TTForm passwordForm = new TTFormClasses.PasswordForm();
                            //TTFormClasses.InPatientPhysicianAppDoctorFormNew prescriptionForm = new TTFormClasses.InPatientPhysicianAppDoctorFormNew();
                            //passwordForm.ShowEdit(prescriptionForm.FindForm(), inpatientPrescription);
                            //eRecetePassword = inpatientPrescription.ERecetePassword;
                        }
                        else
                            inpatientPrescription.ERecetePassword = eRecetePassword;
                    }
                    
                    inpatientPrescription.ActionDate = Common.RecTime();
                    inpatientPrescription.FillingDate = Common.RecTime();
                    inpatientPrescription.FromResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.MasterResource = _InPatientPhysicianApplication.MasterResource;
                    inpatientPrescription.Episode = _InPatientPhysicianApplication.Episode;
                    inpatientPrescription.PrescriptionNO = "0";
                    inpatientPrescription.PrescriptionType = PrescriptionTypeEnum.PurplePrescription;
                    inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.Request;
                    message = message + "Mor Reçeteye Çıkacak İlaçlar: \r\n";
                    foreach (KeyValuePair<object, double> purple in purplePrescriptions)
                    {
                        inpatientPrescription.InpatientDrugOrders.Add((InpatientDrugOrder)purple.Key);
                        message = message + ((InpatientDrugOrder)purple.Key).Material.Name.ToString() + "\r\n";
                    }
                }
                if(message != "")
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Reçete Türü", "Yatan Hasta Reçetesine Çıkacak ilaçların Reçete Türü : \r\n" + message + "\r\n" + "Devam Etmek İstiyor Musunuz?");
                    if (result == "V")
                    {
                        throw new Exception(SystemMessage.GetMessage(719));
                    }
                }
            }
        }

        public void CheckTreatmentDischarge()
        {
            if (this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
            {
                TreatmentDischarge td = this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.TreatmentDischarge;
                if (td == null)
                {
                    throw new Exception(SystemMessage.GetMessage(715));
                }
                else
                {
                    if (td.CurrentStateDef.Status != StateStatusEnum.CompletedSuccessfully)
                    {
                        TreatmentDischarge tdGet = (TreatmentDischarge)(new TTObjectContext(true)).GetObject(td.ObjectID, typeof(TreatmentDischarge).Name);
                        if (tdGet.CurrentStateDef.Status != StateStatusEnum.CompletedSuccessfully)
                            throw new Exception(SystemMessage.GetMessage(716));
                    }
                }
            }

        }

        #endregion InPatientPhysicianAppDoctorFormNew_ClientSideMethods
    }
}