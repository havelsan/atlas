
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
    /// Hasta Katılım Payından Muaf İlaç Rapor İşlemleri
    /// </summary>
    public partial class ParticipationFreeDrugReportNewForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
           
            CommitteeReport.CheckedChanged += new TTControlEventDelegate(CommitteeReport_CheckedChanged);
            btnLoadFromSection.Click += new TTControlEventDelegate(btnLoadFromSection_Click);
            btn2Years.Click += new TTControlEventDelegate(btn2Years_Click);
            btn1Year.Click += new TTControlEventDelegate(btn1Year_Click);
            btn6Months.Click += new TTControlEventDelegate(btn6Months_Click);
            btn3Months.Click += new TTControlEventDelegate(btn3Months_Click);
            btnDeleteTemplate.Click += new TTControlEventDelegate(btnDeleteTemplate_Click);
            btnSaveAsTemplate.Click += new TTControlEventDelegate(btnSaveAsTemplate_Click);
            btnLoadFromUser.Click += new TTControlEventDelegate(btnLoadFromUser_Click);
            btnMedulaBashekimOnay.Click += new TTControlEventDelegate(btnMedulaBashekimOnay_Click);
            btnUcuncuTabipOnay.Click += new TTControlEventDelegate(btnUcuncuTabipOnay_Click);
           btnIkinciTabipOnay.Click += new TTControlEventDelegate(btnIkinciTabipOnay_Click);
            btnHastaIlacRaporuListesi.Click += new TTControlEventDelegate(btnHastaIlacRaporuListesi_Click);
            MedulaReportResults.CellContentClick += new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            btnAciklamaEkle.Click += new TTControlEventDelegate(btnAciklamaEkle_Click);
            btnTaniEkle.Click += new TTControlEventDelegate(btnTaniEkle_Click);
            lstDiagnosisAddedToEpisode.SelectedObjectChanged += new TTControlEventDelegate(lstDiagnosisAddedToEpisode_SelectedObjectChanged);
            btnTeshisEkle.Click += new TTControlEventDelegate(btnTeshisEkle_Click);
            btnEtkinMaddeEkle.Click += new TTControlEventDelegate(btnEtkinMaddeEkle_Click);
            ParticipationFreeDrugs.CellValueChanged += new TTGridCellEventDelegate(ParticipationFreeDrugs_CellValueChanged);
            ParticipationFreeDrugs.CellContentClick += new TTGridCellEventDelegate(ParticipationFreeDrugs_CellContentClick);
            GridDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridDiagnosis_CellContentClick);
            GridDiagnosis.CurrentCellChanged += new TTControlEventDelegate(GridDiagnosis_CurrentCellChanged);
            GridDiagnosis.CellValueChanged += new TTGridCellEventDelegate(GridDiagnosis_CellValueChanged);
            ProcedureDoctor.SelectedObjectChanged += new TTControlEventDelegate(ProcedureDoctor_SelectedObjectChanged);          
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
           
            CommitteeReport.CheckedChanged -= new TTControlEventDelegate(CommitteeReport_CheckedChanged);
            btnLoadFromSection.Click -= new TTControlEventDelegate(btnLoadFromSection_Click);
            btn2Years.Click -= new TTControlEventDelegate(btn2Years_Click);
            btn1Year.Click -= new TTControlEventDelegate(btn1Year_Click);
            btn6Months.Click -= new TTControlEventDelegate(btn6Months_Click);
            btn3Months.Click -= new TTControlEventDelegate(btn3Months_Click);
            btnDeleteTemplate.Click -= new TTControlEventDelegate(btnDeleteTemplate_Click);
            btnSaveAsTemplate.Click -= new TTControlEventDelegate(btnSaveAsTemplate_Click);
            btnLoadFromUser.Click -= new TTControlEventDelegate(btnLoadFromUser_Click);
            btnMedulaBashekimOnay.Click -= new TTControlEventDelegate(btnMedulaBashekimOnay_Click);
            btnUcuncuTabipOnay.Click -= new TTControlEventDelegate(btnUcuncuTabipOnay_Click);
            btnIkinciTabipOnay.Click -= new TTControlEventDelegate(btnIkinciTabipOnay_Click);
            btnHastaIlacRaporuListesi.Click -= new TTControlEventDelegate(btnHastaIlacRaporuListesi_Click);
            MedulaReportResults.CellContentClick -= new TTGridCellEventDelegate(MedulaReportResults_CellContentClick);
            btnAciklamaEkle.Click -= new TTControlEventDelegate(btnAciklamaEkle_Click);
            btnTaniEkle.Click -= new TTControlEventDelegate(btnTaniEkle_Click);
            lstDiagnosisAddedToEpisode.SelectedObjectChanged -= new TTControlEventDelegate(lstDiagnosisAddedToEpisode_SelectedObjectChanged);
            btnTeshisEkle.Click -= new TTControlEventDelegate(btnTeshisEkle_Click);
            btnEtkinMaddeEkle.Click -= new TTControlEventDelegate(btnEtkinMaddeEkle_Click);
            ParticipationFreeDrugs.CellValueChanged -= new TTGridCellEventDelegate(ParticipationFreeDrugs_CellValueChanged);
            ParticipationFreeDrugs.CellContentClick -= new TTGridCellEventDelegate(ParticipationFreeDrugs_CellContentClick);
            GridDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridDiagnosis_CellContentClick);
            GridDiagnosis.CurrentCellChanged -= new TTControlEventDelegate(GridDiagnosis_CurrentCellChanged);
            GridDiagnosis.CellValueChanged -= new TTGridCellEventDelegate(GridDiagnosis_CellValueChanged);
            ProcedureDoctor.SelectedObjectChanged -= new TTControlEventDelegate(ProcedureDoctor_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

     

        private void CommitteeReport_CheckedChanged()
        {
#region ParticipationFreeDrugReportNewForm_CommitteeReport_CheckedChanged
   if (((TTVisual.TTCheckBox)(CommitteeReport)).Checked)
            {
                //((ITTObjectListBox)this.SecondDoctor).Visible = true;

                this.listSecondDoctor.Visible = true;
                this.listSecondDoctor.Required = true;
                this.labelSecondDoctor.Visible = true;
                this.ThirdDoctor.Visible = true;
                this.ThirdDoctor.Required = true;
                this.labelThirdDoctor.Visible = true;
                //                this.btnIkinciTabipOnay.Visible = true;
                //                this.btnUcuncuTabipOnay.Visible = true;
                if (_ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.New)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
                    {
                        this.DropStateButton(ParticipatnFreeDrugReport.States.Approval);
                        this.AddStateButton(ParticipatnFreeDrugReport.States.SecondDoctorApproval);
                        this.DropStateButton(ParticipatnFreeDrugReport.States.ThirdDoctorApproval);
                    }
                }
            }
            else
            {
                this.listSecondDoctor.Visible = false;
                this.listSecondDoctor.Required = false;
                this.labelSecondDoctor.Visible = false;
                this.listSecondDoctor.ControlValue = null;
                //this.SecondDoctor = null;
                this.ThirdDoctor.Visible = false;
                this.ThirdDoctor.Required = false;
                this.labelThirdDoctor.Visible = false;
                this.ThirdDoctor.ControlValue = null;
                //                this.btnIkinciTabipOnay.Visible = false;
                //                this.btnUcuncuTabipOnay.Visible = false;
                if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
                {
                    this.AddStateButton(ParticipatnFreeDrugReport.States.Approval);
                    this.DropStateButton(ParticipatnFreeDrugReport.States.SecondDoctorApproval);
                    this.DropStateButton(ParticipatnFreeDrugReport.States.ThirdDoctorApproval);
                }
            }
#endregion ParticipationFreeDrugReportNewForm_CommitteeReport_CheckedChanged
        }

        private void btnLoadFromSection_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnLoadFromSection_Click
   MultiSelectForm msItem = new MultiSelectForm();
            foreach (ResourceSpecialityGrid resourceSpeciality in Common.CurrentResource.ResourceSpecialities)
            {
                msItem.AddMSItem(resourceSpeciality.Speciality.Name, resourceSpeciality.Speciality.ObjectID.ToString(), resourceSpeciality.Speciality);
            }
            string key = msItem.GetMSItem(null, "Şablonlarına erişmek istediğiniz bölümü seçiniz.", true, false, false, false, true, false);
            if (!string.IsNullOrEmpty(key))
            {
                SpecialityDefinition specDef = (SpecialityDefinition)msItem.MSSelectedItemObject;
                IBindingList sectionTemplates = _ParticipatnFreeDrugReport.ObjectContext.QueryObjects(typeof(ParticipantFreeDrugReportTemplate).Name, "SPECIALITYDEFINITION = '" + specDef.ObjectID.ToString() + "'");

                if (sectionTemplates.Count == 0)
                    InfoBox.Show("Daha önce bölüme kaydedilen bir şablon bulunmamaktadır.", MessageIconEnum.InformationMessage);
                else
                {
                    MultiSelectForm mSelectForm = new MultiSelectForm();
                    foreach (ParticipantFreeDrugReportTemplate pdrt in sectionTemplates)
                        mSelectForm.AddMSItem(pdrt.TemplateName, pdrt.ObjectID.ToString(), pdrt);

                    string mkey = mSelectForm.GetMSItem(this, "Şablon seçiniz", true);
                    if (string.IsNullOrEmpty(mkey))
                        return;
                    else
                    {
                        IBindingList participatnFreeDrugReports = _ParticipatnFreeDrugReport.ObjectContext.QueryObjects(typeof(ParticipatnFreeDrugReport).Name, "PARTICIPNTFREEDRUGREPORTTMPLT = '" + ((ParticipantFreeDrugReportTemplate)mSelectForm.MSSelectedItemObject).ObjectID.ToString() + "'");
                        if (participatnFreeDrugReports.Count == 0)
                        {
                            InfoBox.Show("Seçtiğiniz şablonla kaydedilmiş herhangi bir hasta katılım payından muaf ilaç raporuna ulaşılamadı!", MessageIconEnum.ErrorMessage);
                            return;
                        }
                        else
                        {
                            ParticipatnFreeDrugReport targetParticipatnFreeDrugReport = (ParticipatnFreeDrugReport)participatnFreeDrugReports[0];

                            if (targetParticipatnFreeDrugReport.ParticipationFreeDrugs != null)
                            {
                                for (int i = 0; i < targetParticipatnFreeDrugReport.ParticipationFreeDrugs.Count; i++)
                                {
                                    _ParticipatnFreeDrugReport.ParticipationFreeDrugs.Add((ParticipationFreeDrgGrid)targetParticipatnFreeDrugReport.ParticipationFreeDrugs[i].Clone());
                                }
                            }


                            if (targetParticipatnFreeDrugReport.Diagnosis != null)
                            {
                                for (int i = 0; i < targetParticipatnFreeDrugReport.Diagnosis.Count; i++)
                                {
                                    _ParticipatnFreeDrugReport.Diagnosis.Add((DiagnosisGrid)targetParticipatnFreeDrugReport.Diagnosis[i].Clone());
                                }
                            }

                            _ParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt = targetParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt;

                            if (targetParticipatnFreeDrugReport.CommitteeReport == null)
                                _ParticipatnFreeDrugReport.CommitteeReport = false;

                            if (_ParticipatnFreeDrugReport.CommitteeReport != null && _ParticipatnFreeDrugReport.CommitteeReport == true)
                            {
                                this.listSecondDoctor.Visible = true;
                                this.listSecondDoctor.Required = true;
                                this.labelSecondDoctor.Visible = true;
                                this.ThirdDoctor.Visible = true;
                                this.ThirdDoctor.Required = true;
                                this.labelThirdDoctor.Visible = true;
                                _ParticipatnFreeDrugReport.CommitteeReport = true;
                                _ParticipatnFreeDrugReport.SecondDoctor = targetParticipatnFreeDrugReport.SecondDoctor;
                                _ParticipatnFreeDrugReport.ThirdDoctor = targetParticipatnFreeDrugReport.ThirdDoctor;
                            }
                            else
                            {
                                this.listSecondDoctor.Visible = false;
                                this.listSecondDoctor.Required = false;
                                this.labelSecondDoctor.Visible = false;
                                this.ThirdDoctor.Visible = false;
                                this.ThirdDoctor.Required = false;
                                this.labelThirdDoctor.Visible = false;
                                _ParticipatnFreeDrugReport.CommitteeReport = false;

                            }

                            _ParticipatnFreeDrugReport.Description = targetParticipatnFreeDrugReport.Description;
                            _ParticipatnFreeDrugReport.Disease = (targetParticipatnFreeDrugReport.Disease != null ? targetParticipatnFreeDrugReport.Disease : null);
                            _ParticipatnFreeDrugReport.Duration1 = (targetParticipatnFreeDrugReport.Duration1 != null ? targetParticipatnFreeDrugReport.Duration1 : null);
                            _ParticipatnFreeDrugReport.HeadDoctorApproval = targetParticipatnFreeDrugReport.HeadDoctorApproval;
                            _ParticipatnFreeDrugReport.PatientEnterprise = (targetParticipatnFreeDrugReport.PatientEnterprise != null ? targetParticipatnFreeDrugReport.PatientEnterprise : null);
                            _ParticipatnFreeDrugReport.ReportApprovalType = (targetParticipatnFreeDrugReport.ReportApprovalType != null ? targetParticipatnFreeDrugReport.ReportApprovalType : null);
                            _ParticipatnFreeDrugReport.SocialInsurance = (targetParticipatnFreeDrugReport.SocialInsurance != null ? targetParticipatnFreeDrugReport.SocialInsurance : null);
                            _ParticipatnFreeDrugReport.TestsAndSigns = (targetParticipatnFreeDrugReport.TestsAndSigns != null ? targetParticipatnFreeDrugReport.TestsAndSigns : null);


                        }
                    }
                }
            }
            else
                throw new TTUtils.TTException("İşlemden vazgeçildi!");
#endregion ParticipationFreeDrugReportNewForm_btnLoadFromSection_Click
        }

        private void btn2Years_Click()
        {
#region ParticipationFreeDrugReportNewForm_btn2Years_Click
   if (((TTVisual.TTDateTimePicker)this.ReportStartDate).Checked)
            {
                DateTime startDate = Convert.ToDateTime(this.ReportStartDate.Text);
                this.ReportEndDate.Text = (startDate.AddYears(2)).ToString();
            }
            else
            {
                TTVisual.InfoBox.Show("Lütfen Rapor Başlangıç Tarihini Giriniz!", MessageIconEnum.WarningMessage);
            }
#endregion ParticipationFreeDrugReportNewForm_btn2Years_Click
        }

        private void btn1Year_Click()
        {
#region ParticipationFreeDrugReportNewForm_btn1Year_Click
   if (((TTVisual.TTDateTimePicker)this.ReportStartDate).Checked)
            {
                DateTime startDate = Convert.ToDateTime(this.ReportStartDate.Text);
                this.ReportEndDate.Text = (startDate.AddYears(1)).ToString();
            }
            else
            {
                TTVisual.InfoBox.Show("Lütfen Rapor Başlangıç Tarihini Giriniz!", MessageIconEnum.WarningMessage);
            }
#endregion ParticipationFreeDrugReportNewForm_btn1Year_Click
        }

        private void btn6Months_Click()
        {
#region ParticipationFreeDrugReportNewForm_btn6Months_Click
   if (((TTVisual.TTDateTimePicker)this.ReportStartDate).Checked)
            {
                DateTime startDate = Convert.ToDateTime(this.ReportStartDate.Text);
                this.ReportEndDate.Text = (startDate.AddMonths(6)).ToString();
            }
            else
            {
                TTVisual.InfoBox.Show("Lütfen Rapor Başlangıç Tarihini Giriniz!", MessageIconEnum.WarningMessage);
            }
#endregion ParticipationFreeDrugReportNewForm_btn6Months_Click
        }

        private void btn3Months_Click()
        {
#region ParticipationFreeDrugReportNewForm_btn3Months_Click
   if (((TTVisual.TTDateTimePicker)this.ReportStartDate).Checked)
            {
                DateTime startDate = Convert.ToDateTime(this.ReportStartDate.Text);
                this.ReportEndDate.Text = (startDate.AddMonths(3)).ToString();
            }
            else
            {
                TTVisual.InfoBox.Show("Lütfen Rapor Başlangıç Tarihini Giriniz!", MessageIconEnum.WarningMessage);
            }
#endregion ParticipationFreeDrugReportNewForm_btn3Months_Click
        }

        private void btnDeleteTemplate_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnDeleteTemplate_Click
   if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Mevcut şablon silinecek.\nDevam etmek istediğinize emin misiniz?") == "E")
            {
                if (_ParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt != null)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    Guid objectID = _ParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt.ObjectID;
                    IBindingList objects = context.QueryObjects(typeof(ParticipatnFreeDrugReport).Name, "PARTICIPNTFREEDRUGREPORTTMPLT = '" + _ParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt.ObjectID.ToString() + "'");
                    foreach (ParticipatnFreeDrugReport pfdr in objects)
                    {
                        pfdr.ParticipntFreeDrugReportTmplt = null;
                    }

                    ParticipantFreeDrugReportTemplate tempToDel = (ParticipantFreeDrugReportTemplate)context.GetObject(objectID, typeof(ParticipantFreeDrugReportTemplate).Name);
                    ((ITTObject)tempToDel).Delete();
                    context.Save();
                    context.Dispose();
                    InfoBox.Show("Şablon silindi.", MessageIconEnum.InformationMessage);
                }
            }
#endregion ParticipationFreeDrugReportNewForm_btnDeleteTemplate_Click
        }

        private void btnSaveAsTemplate_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnSaveAsTemplate_Click
   string templateName = InputForm.GetText("Şablon adını giriniz.");
            if (templateName == null || templateName == "")
            {
                InfoBox.Show("Kaydetme işlemi gerçekleştirilmedi.", MessageIconEnum.InformationMessage);
            }
            else
            {
                string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Bölümdeki diğer kullanıcılar şablona erişebilsin mi?");
                if (result == "E")
                {
                    ParticipantFreeDrugReportTemplate pfdrTemp;
                    MultiSelectForm msItem = new MultiSelectForm();
                    foreach (ResourceSpecialityGrid resourceSpeciality in Common.CurrentResource.ResourceSpecialities)
                    {
                        msItem.AddMSItem(resourceSpeciality.Speciality.Name, resourceSpeciality.Speciality.ObjectID.ToString(), resourceSpeciality.Speciality);
                    }
                    string key = msItem.GetMSItem(null, "Şablonun görünmesini istediğiniz bölümü seçiniz.", true, false, false, false, true, false);
                    if (!string.IsNullOrEmpty(key))
                    {
                        pfdrTemp = new ParticipantFreeDrugReportTemplate(_ParticipatnFreeDrugReport.ObjectContext);
                        pfdrTemp.ResUser = Common.CurrentResource;
                        pfdrTemp.TemplateName = templateName;
                        pfdrTemp.SpecialityDefinition = (SpecialityDefinition)msItem.MSSelectedItemObject;
                        _ParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt = pfdrTemp;
                        InfoBox.Show("Şablon kaydedildi.", MessageIconEnum.InformationMessage);
                    }
                    else
                        throw new TTUtils.TTException("İşlemden vazgeçildi!");
                }
                else
                {
                    ParticipantFreeDrugReportTemplate pfdrTemp = new ParticipantFreeDrugReportTemplate(_ParticipatnFreeDrugReport.ObjectContext);
                    pfdrTemp.ResUser = Common.CurrentResource;
                    pfdrTemp.TemplateName = templateName;
                    pfdrTemp.SpecialityDefinition = null;
                    _ParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt = pfdrTemp;
                    InfoBox.Show("Şablon kaydedildi.", MessageIconEnum.InformationMessage);
                }
            }
#endregion ParticipationFreeDrugReportNewForm_btnSaveAsTemplate_Click
        }

        private void btnLoadFromUser_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnLoadFromUser_Click
   IBindingList userTemplates = _ParticipatnFreeDrugReport.ObjectContext.QueryObjects(typeof(ParticipantFreeDrugReportTemplate).Name, "RESUSER = '" + Common.CurrentResource.ObjectID.ToString() + "'");
            if (userTemplates.Count == 0)
                InfoBox.Show("Daha önce kaydettiğiniz bir şablon bulunmamaktadır.", MessageIconEnum.InformationMessage);
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (ParticipantFreeDrugReportTemplate pdrt in userTemplates)
                    mSelectForm.AddMSItem(pdrt.TemplateName, pdrt.ObjectID.ToString(), pdrt);

                string mkey = mSelectForm.GetMSItem(this, "Şablon seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                    return;
                else
                {
                    IBindingList participatnFreeDrugReports = _ParticipatnFreeDrugReport.ObjectContext.QueryObjects(typeof(ParticipatnFreeDrugReport).Name, "PARTICIPNTFREEDRUGREPORTTMPLT = '" + ((ParticipantFreeDrugReportTemplate)mSelectForm.MSSelectedItemObject).ObjectID.ToString() + "'");
                    if (participatnFreeDrugReports.Count == 0)
                    {
                        InfoBox.Show("Seçtiğiniz şablonla kaydedilmiş herhangi bir hasta katılım payından muaf ilaç raporuna ulaşılamadı!", MessageIconEnum.ErrorMessage);
                        return;
                    }
                    else
                    {
                        ParticipatnFreeDrugReport targetParticipatnFreeDrugReport = (ParticipatnFreeDrugReport)participatnFreeDrugReports[0];

                        if (targetParticipatnFreeDrugReport.ParticipationFreeDrugs != null)
                        {
                            for (int i = 0; i < targetParticipatnFreeDrugReport.ParticipationFreeDrugs.Count; i++)
                            {
                                _ParticipatnFreeDrugReport.ParticipationFreeDrugs.Add((ParticipationFreeDrgGrid)targetParticipatnFreeDrugReport.ParticipationFreeDrugs[i].Clone());
                            }
                        }

                     
                        if (targetParticipatnFreeDrugReport.Diagnosis != null)
                        {
                            for (int i = 0; i < targetParticipatnFreeDrugReport.Diagnosis.Count; i++)
                            {
                                _ParticipatnFreeDrugReport.Diagnosis.Add((DiagnosisGrid)targetParticipatnFreeDrugReport.Diagnosis[i].Clone());
                            }
                        }

                        _ParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt = targetParticipatnFreeDrugReport.ParticipntFreeDrugReportTmplt;

                        if (targetParticipatnFreeDrugReport.CommitteeReport == null)
                            _ParticipatnFreeDrugReport.CommitteeReport = false;

                        if (_ParticipatnFreeDrugReport.CommitteeReport != null && _ParticipatnFreeDrugReport.CommitteeReport == true)
                        {
                            this.listSecondDoctor.Visible = true;
                            this.listSecondDoctor.Required = true;
                            this.labelSecondDoctor.Visible = true;
                            this.ThirdDoctor.Visible = true;
                            this.ThirdDoctor.Required = true;
                            this.labelThirdDoctor.Visible = true;
                            _ParticipatnFreeDrugReport.CommitteeReport = true;
                            _ParticipatnFreeDrugReport.SecondDoctor = targetParticipatnFreeDrugReport.SecondDoctor;
                            _ParticipatnFreeDrugReport.ThirdDoctor = targetParticipatnFreeDrugReport.ThirdDoctor;
                        }
                        else
                        {
                            this.listSecondDoctor.Visible = false;
                            this.listSecondDoctor.Required = false;
                            this.labelSecondDoctor.Visible = false;
                            this.ThirdDoctor.Visible = false;
                            this.ThirdDoctor.Required = false;
                            this.labelThirdDoctor.Visible = false;
                            _ParticipatnFreeDrugReport.CommitteeReport = false;

                        }

                        _ParticipatnFreeDrugReport.Description = targetParticipatnFreeDrugReport.Description;
                        _ParticipatnFreeDrugReport.Disease = (targetParticipatnFreeDrugReport.Disease != null ? targetParticipatnFreeDrugReport.Disease : null);
                        _ParticipatnFreeDrugReport.Duration1 = (targetParticipatnFreeDrugReport.Duration1 != null ? targetParticipatnFreeDrugReport.Duration1 : null);
                        _ParticipatnFreeDrugReport.HeadDoctorApproval = targetParticipatnFreeDrugReport.HeadDoctorApproval;
                        _ParticipatnFreeDrugReport.PatientEnterprise = (targetParticipatnFreeDrugReport.PatientEnterprise != null ? targetParticipatnFreeDrugReport.PatientEnterprise : null);
                        _ParticipatnFreeDrugReport.ReportApprovalType = (targetParticipatnFreeDrugReport.ReportApprovalType != null ? targetParticipatnFreeDrugReport.ReportApprovalType : null);
                        _ParticipatnFreeDrugReport.SocialInsurance = (targetParticipatnFreeDrugReport.SocialInsurance != null ? targetParticipatnFreeDrugReport.SocialInsurance : null);
                        _ParticipatnFreeDrugReport.TestsAndSigns = (targetParticipatnFreeDrugReport.TestsAndSigns != null ? targetParticipatnFreeDrugReport.TestsAndSigns : null);


                    }
                }
            }
#endregion ParticipationFreeDrugReportNewForm_btnLoadFromUser_Click
        }

        private void btnMedulaBashekimOnay_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnMedulaBashekimOnay_Click
   if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
            {
                try
                {
                    if (MedulaReportResults != null)
                    {
                        if (MedulaReportResults.Rows != null)
                        {
                            if (MedulaReportResults.Rows.Count > 0)// && MedulaReportResults.CurrentCell != null)
                            {
                                if (!string.IsNullOrEmpty(_ParticipatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo))
                                {
                                    DialogResult dialogResult = MessageBox.Show("Seçili Raporu Meduladan Onaylanacaktır!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                    if (dialogResult == DialogResult.OK)
                                    {
                                        IlacRaporuServis.eraporBashekimOnayIstekDVO eraporBashekimOnayIstekDVO = new IlacRaporuServis.eraporBashekimOnayIstekDVO();

                                        eraporBashekimOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                        eraporBashekimOnayIstekDVO.raporTakipNo = _ParticipatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo;

                                        string password = "";
                                        string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("KURUMSALYONETICI_OBJECTID", "XXXXXX");
                                        BindingList<ResUser.GetUserByID_Class> basTabipList = ResUser.GetUserByID(basHekimObjectID);
                                        if (basTabipList == null || basTabipList.Count == 0)
                                        {
                                            InfoBox.Show("Baş Tabip Boş Olamaz !!!");
                                            return;
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(basTabipList[0].ErecetePassword))
                                            {
                                                TTVisual.TTForm medulaPasswordFormForHeadDoctor = new TTFormClasses.MedulaPasswordFormForHeadDoctor();
                                                medulaPasswordFormForHeadDoctor.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                                                if (string.IsNullOrEmpty(basTabipList[0].ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                                {
                                                    InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                                    return;
                                                }
                                            }
                                            BindingList<ResUser.GetUserByID_Class> basTabipList2 = ResUser.GetUserByID(basHekimObjectID);
                                            if (!string.IsNullOrEmpty(basTabipList2[0].ErecetePassword))
                                                password = basTabipList2[0].ErecetePassword;
                                            else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                                password = this._ParticipatnFreeDrugReport.MedulaPassword;
                                        }
                                        if (basTabipList[0].Tcno != null)
                                            eraporBashekimOnayIstekDVO.doktorTcKimlikNo = basTabipList[0].Tcno.ToString();
                                        else
                                        {
                                            InfoBox.Show("Başhekim TC Kimlik Numarası Boş Olamaz");
                                            return;
                                        }

                                        IlacRaporuServis.eraporBashekimOnayCevapDVO response = IlacRaporuServis.WebMethods.eraporBashekimOnay(Sites.SiteLocalHost, basTabipList[0].Tcno.ToString(), password, eraporBashekimOnayIstekDVO);
                                        //lacRaporuServis.EraporOnayCevapDVO response = IlacRaporuServis.WebMethods.eraporOnay(Sites.SiteLocalHost,this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), user.ErecetePassword, eraporOnayIstekDVO);
                                        if (response != null)
                                        {
                                            if (response.sonucKodu != null)
                                            {
                                                if (response.sonucKodu == "0000")
                                                {
                                                    InfoBox.Show("Rapor Onaylandı");

                                                    TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                                    ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));
                                                    _participationFreeDrugReport.HeadDoctorApproval = 1;
                                                    _context.Save();
                                                }
                                                else if (response.sonucKodu == "RAP_0047")
                                                {
                                                    InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.uyariMesaji + "" + response.sonucMesaji);
                                                }
                                                else
                                                {
                                                    if (!string.IsNullOrEmpty(response.uyariMesaji) || !string.IsNullOrEmpty(response.sonucMesaji))
                                                    {

                                                        InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.uyariMesaji + "" + response.sonucMesaji + " Rapor Onaylanamamıştır.  !!!");
                                                        TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                                        ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));
                                                        _participationFreeDrugReport.HeadDoctorApproval = 0;
                                                        _context.Save();

                                                    }
                                                }
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
                                }
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    string mesaj = ((System.Net.WebException)e.InnerException.InnerException).Message;
                    throw new Exception(mesaj);
                }
            }
#endregion ParticipationFreeDrugReportNewForm_btnMedulaBashekimOnay_Click
        }

        private void btnUcuncuTabipOnay_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnUcuncuTabipOnay_Click
   try
            {
                if (MedulaReportResults.Rows.Count > 0)// && MedulaReportResults.CurrentCell != null)
                {
                    //                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                    //                    if (currentCell != null)
                    //                    {
                    //                        ITTGridRow currentRow = currentCell.OwningRow;
                    //                        if (currentRow != null)
                    //                        {
                    //                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
                    //
                    //                            if (currentMedulaReportResult != null)
                    //                            {
                    //                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                    //                                {
                    if (!string.IsNullOrEmpty(_ParticipatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo))
                    {
                        IlacRaporuServis.eraporOnayIstekDVO eraporOnayIstekDVO = new IlacRaporuServis.eraporOnayIstekDVO();

                        eraporOnayIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.ThirdDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        eraporOnayIstekDVO.raporTakipNo = _ParticipatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo;

                        _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ThirdDoktorApprove;
                        ResUser user = (ResUser)this._ParticipatnFreeDrugReport.ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));
                        if (string.IsNullOrEmpty(user.ErecetePassword))
                        {
                            TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                            medulaPasswordForm.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                            if (string.IsNullOrEmpty(user.ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                            {
                                InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                return;
                            }
                        }
                        string password = "";
                        if (!string.IsNullOrEmpty(user.ErecetePassword))
                            password = user.ErecetePassword;
                        else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                            password = this._ParticipatnFreeDrugReport.MedulaPassword;

                        IlacRaporuServis.eraporOnayCevapDVO response = IlacRaporuServis.WebMethods.eraporOnay(Sites.SiteLocalHost, this._ParticipatnFreeDrugReport.ThirdDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporOnayIstekDVO);
                        if (response != null)
                        {
                            if (response.sonucKodu != null)
                            {
                                if (response.sonucKodu == "0000")
                                {
                                    InfoBox.Show("Rapor Onaylandı.");
                                    TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                    ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));
                                    _participationFreeDrugReport.ThirdDoctorApproval = 1;
                                    _context.Save();
                                }
                                else if (response.sonucKodu == "RAP_0052")
                                {
                                    InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.uyariMesaji + "" + response.sonucMesaji);
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(response.sonucMesaji))
                                    {
                                        InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.uyariMesaji + "" + response.sonucMesaji + " Rapor Onaylanamamıştır.  !!!");
                                        TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                        ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));
                                        _participationFreeDrugReport.ThirdDoctorApproval = 0;
                                        _context.Save();

                                    }
                                }

                            }
                        }
                    }
                    // }
                    //  }
                    // }
                }
            }

            catch (Exception e)
            {
                string mesaj = ((System.Net.WebException)e.InnerException.InnerException).Message;
                if (mesaj == "The request failed with HTTP status 401: Unauthorized.")
                    throw new Exception(_ParticipatnFreeDrugReport.ThirdDoctor.Person.FullName + " TC ve E-Reçete Şifresi Uyuşmazlığı");
                else
                    throw new Exception(mesaj);
            }
#endregion ParticipationFreeDrugReportNewForm_btnUcuncuTabipOnay_Click
        }

    
        private void btnIkinciTabipOnay_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnIkinciTabipOnay_Click
   try
            {
                if (MedulaReportResults.Rows.Count > 0)// && MedulaReportResults.CurrentCell != null)
                {
                    //
                    //                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                    //                    if (currentCell != null)
                    //                    {
                    //                        ITTGridRow currentRow = currentCell.OwningRow;
                    //                        if (currentRow != null)
                    //                        {
                    //                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
                    //
                    //                            if (currentMedulaReportResult != null)
                    //                            {
                    //                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                    //                                {
                    if (!string.IsNullOrEmpty(_ParticipatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo))
                    {
                        IlacRaporuServis.eraporOnayIstekDVO eraporOnayIstekDVO = new IlacRaporuServis.eraporOnayIstekDVO();

                        eraporOnayIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.SecondDoctor.Person.UniqueRefNo.Value.ToString();
                        eraporOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                        eraporOnayIstekDVO.raporTakipNo = _ParticipatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo;

                        _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.SecondDoktorApprove;
                        ResUser user = (ResUser)this._ParticipatnFreeDrugReport.ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));
                        if (string.IsNullOrEmpty(user.ErecetePassword))
                        {
                            TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                            medulaPasswordForm.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                            if (string.IsNullOrEmpty(user.ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                            {
                                InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                return;
                            }
                        }
                        string password = "";
                        if (!string.IsNullOrEmpty(user.ErecetePassword))
                            password = user.ErecetePassword;
                        else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                            password = this._ParticipatnFreeDrugReport.MedulaPassword;

                        IlacRaporuServis.eraporOnayCevapDVO response = IlacRaporuServis.WebMethods.eraporOnay(Sites.SiteLocalHost, this._ParticipatnFreeDrugReport.SecondDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporOnayIstekDVO);
                        if (response != null)
                        {
                            if (response.sonucKodu != null)
                            {
                                if (response.sonucKodu == "0000")
                                {
                                    InfoBox.Show("Rapor Onaylandı.");

                                    TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                    ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));
                                    _participationFreeDrugReport.SecondDoctorApproval = 1;
                                    _context.Save();

                                }
                                else if (response.sonucKodu == "RAP_0052")
                                {
                                    InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.uyariMesaji + "" + response.sonucMesaji);
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(response.sonucMesaji) || !string.IsNullOrEmpty(response.uyariMesaji))
                                    {
                                        InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.uyariMesaji + "" + response.sonucMesaji + " Rapor Onaylanamamıştır.  !!!");
                                        TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                        ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));
                                        _participationFreeDrugReport.SecondDoctorApproval = 0;
                                        _context.Save();
                                    }
                                }
                                // }
                                //  }
                                // }
                            }
                        }
                    }
                }
            }

            catch (Exception e)
            {
                string mesaj = ((System.Net.WebException)e.InnerException.InnerException).Message;
                if (mesaj == "The request failed with HTTP status 401: Unauthorized.")
                    throw new Exception(_ParticipatnFreeDrugReport.SecondDoctor.Person.FullName + " TC ve E-Reçete Şifresi Uyuşmazlığı");
                else
                    throw new Exception(mesaj);
            }
#endregion ParticipationFreeDrugReportNewForm_btnIkinciTabipOnay_Click
        }

        private void btnHastaIlacRaporuListesi_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnHastaIlacRaporuListesi_Click
   try
            {
                string tesis = "";
                string duzenlemeTuru = "";
                if (_ParticipatnFreeDrugReport.Episode.Patient.UniqueRefNo == null)
                {
                    InfoBox.Show("Hasta T.C. Kimlik Numarası Boş Olamaz");
                    return;
                }

                RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();

                _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _raporOkuTCKimlikNodanDVO.raporTuru = "10";
                _raporOkuTCKimlikNodanDVO.tckimlikNo = _ParticipatnFreeDrugReport.Episode.Patient.UniqueRefNo.ToString();
                RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
                if (response != null)
                {
                    if (response != null)
                    {
                        if (response.raporlar != null)
                        {
                            if (response.sonucKodu.Equals(0))
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach (RaporIslemleri.raporCevapDVO item in response.raporlar)
                                {
                                    if (item.ilacRapor != null && item.ilacRapor.raporDVO != null)
                                    {
                                        sb.AppendLine("------------------------------İLAÇ RAPOR BİLGİSİ--------------------------------");
                                        sb.AppendLine("Rapor Takip No :" + item.raporTakipNo.ToString());
                                        sb.AppendLine("Rapor No :" + item.ilacRapor.raporDVO.raporBilgisi.no);
                                        sb.AppendLine("Rapor Tarihi :" + item.ilacRapor.raporDVO.raporBilgisi.tarih);
                                        if (item.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString() != "0")
                                        {
                                            tesis = Common.GetSaglikTesisleri(item.ilacRapor.raporDVO.raporBilgisi.raporTesisKodu.ToString());
                                        }
                                        sb.AppendLine("Alındığı Tesis :" + tesis);

                                        if (item.ilacRapor.raporDVO.duzenlemeTuru == "2")
                                            duzenlemeTuru = "Tek Hekim";
                                        else
                                            duzenlemeTuru = "Heyet";
                                        sb.AppendLine("Düzenleme Türü :" + duzenlemeTuru);
                                        sb.AppendLine("-------------------------------------------------------------------------------");

                                        if( item.ilacRapor.raporEtkinMaddeler != null)
                                        {
                                            foreach (RaporIslemleri.raporEtkinMaddeDVO etkinMadde in item.ilacRapor.raporEtkinMaddeler)
                                            {
                                                sb.AppendLine("------------------------------Etkin Madde Bilgisi--------------------------------");
                                                sb.AppendLine("Etkin Madde Kodu :" + etkinMadde.etkinMaddeKodu);
                                                sb.AppendLine("Doz Aralığı :" + etkinMadde.kullanimDoz1);
                                                sb.AppendLine("Doz :" + etkinMadde.kullanimDoz2);

                                                string kullanimDozBirim = "";
                                                switch (etkinMadde.kullanimDozBirim)
                                                {
                                                    case "1":
                                                        kullanimDozBirim = "Adet";
                                                        break;
                                                    case "2":
                                                        kullanimDozBirim = "Mililitre";
                                                        break;
                                                    case "3":
                                                        kullanimDozBirim = "Miligram";
                                                        break;
                                                    case "4":
                                                        kullanimDozBirim = "Gram";
                                                        break;
                                                    case "5":
                                                        kullanimDozBirim = "Damla";
                                                        break;
                                                    case "6":
                                                        kullanimDozBirim = "Ünite";
                                                        break;
                                                    case "7":
                                                        kullanimDozBirim = "Kutu";
                                                        break;
                                                    case "8":
                                                        kullanimDozBirim = "Mikrogram";
                                                        break;
                                                    case "9":
                                                        kullanimDozBirim = "Mikrolitre";
                                                        break;
                                                    default:
                                                        break;
                                                }

                                                string kullanimPeriyotBirim = "";
                                                switch (etkinMadde.kullanimPeriyotBirim)
                                                {
                                                    case "3":
                                                        kullanimPeriyotBirim = "Gün";
                                                        break;
                                                    case "4":
                                                        kullanimPeriyotBirim = "Hafta";
                                                        break;
                                                    case "5":
                                                        kullanimPeriyotBirim = "Ay";
                                                        break;
                                                    case "6":
                                                        kullanimPeriyotBirim = "Yıl";
                                                        break;
                                                    default:
                                                        break;
                                                }

                                                sb.AppendLine("Kullanım Doz Birimi :" + kullanimDozBirim);
                                                sb.AppendLine("Kullanım Doz Periyodu :" + etkinMadde.kullanimPeriyot);
                                                sb.AppendLine("Kullanım Doz Periyod Birimi :" + kullanimPeriyotBirim);
                                                sb.AppendLine("-------------------------------------------------------------------------------");
                                            }
                                        }
                                        if (item.ilacRapor.raporDVO.teshisler != null)
                                        {
                                            foreach (RaporIslemleri.teshisBilgisiDVO teshis in item.ilacRapor.raporDVO.teshisler)
                                            {
                                                sb.AppendLine("------------------------------Teşhis Bilgisi--------------------------------");
                                                sb.AppendLine("Teşhis Kodu :" + teshis.teshisKodu);
                                                sb.AppendLine("Başlangıç Tarihi :" + teshis.baslangicTarihi);
                                                sb.AppendLine("Bitiş Tarihi :" + teshis.bitisTarihi);
                                                sb.AppendLine("-------------------------------------------------------------------------------");
                                            }
                                        }
                                        if (item.ilacRapor.raporDVO.tanilar != null)
                                        {
                                            foreach (RaporIslemleri.taniBilgisiDVO tani in item.ilacRapor.raporDVO.tanilar)
                                            {
                                                sb.AppendLine("------------------------------Tanı Bilgisi--------------------------------");
                                                sb.AppendLine("Tanı Kodu :" + tani.taniKodu);
                                            }
                                        }

                                        sb.AppendLine("------------------------------Açıklama Bilgisi--------------------------------");
                                        sb.AppendLine("Açıklama :" + item.ilacRapor.raporDVO.aciklama);
                                        sb.AppendLine("-------------------------------------------------------------------------------");

                                        ttrtbTumRaporlar.Text = sb.ToString();

                                    }
                                }
                                this.tttabIslemler.ShowTabPage(tabIlacRaporlari);
                                InfoBox.Show("Hastanın Raporlarını 'İlaç Raporları' Tabında Görebilirsiniz.");
                                return;
                            }
                            else
                            {

                                InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
                                return;
                            }
                        }
                    }
                }
            }

            catch (Exception)
            {

                throw;
            }
#endregion ParticipationFreeDrugReportNewForm_btnHastaIlacRaporuListesi_Click
        }

        private void MedulaReportResults_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ParticipationFreeDrugReportNewForm_MedulaReportResults_CellContentClick
   if ((ITTGridCell)MedulaReportResults.CurrentCell != null)
            {
                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnOnay"))
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
                    {
                        try
                        {
                            if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                            {
                                ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                                if (currentCell != null)
                                {
                                    ITTGridRow currentRow = currentCell.OwningRow;
                                    if (currentRow != null)
                                    {
                                        MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;


                                        if (currentMedulaReportResult != null)
                                        {
                                            if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                            {
                                                DialogResult dialogResult = MessageBox.Show("Seçili Raporu Meduladan Onaylanacaktır!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                                if (dialogResult == DialogResult.OK)
                                                {
                                                    IlacRaporuServis.eraporBashekimOnayIstekDVO eraporBashekimOnayIstekDVO = new IlacRaporuServis.eraporBashekimOnayIstekDVO();

                                                    eraporBashekimOnayIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                                    eraporBashekimOnayIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                                    eraporBashekimOnayIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;


                                                    string password = "";
                                                    string basHekimObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "XXXXXX");
                                                    BindingList<ResUser.GetUserByID_Class> basTabipList = ResUser.GetUserByID(basHekimObjectID);
                                                    if (basTabipList == null || basTabipList.Count == 0)
                                                    {
                                                        InfoBox.Show("Baş Tabip Boş Olamaz !!!");
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        if (string.IsNullOrEmpty(basTabipList[0].ErecetePassword))
                                                        {
                                                            TTVisual.TTForm medulaPasswordFormForHeadDoctor = new TTFormClasses.MedulaPasswordFormForHeadDoctor();
                                                            medulaPasswordFormForHeadDoctor.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                                                            if (string.IsNullOrEmpty(basTabipList[0].ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                                            {
                                                                InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                                                return;
                                                            }
                                                        }
                                                        BindingList<ResUser.GetUserByID_Class> basTabipList2 = ResUser.GetUserByID(basHekimObjectID);
                                                        if (!string.IsNullOrEmpty(basTabipList2[0].ErecetePassword))
                                                            password = basTabipList2[0].ErecetePassword;
                                                        else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                                            password = this._ParticipatnFreeDrugReport.MedulaPassword;
                                                    }
                                                    if (basTabipList[0].Tcno != null)
                                                        eraporBashekimOnayIstekDVO.doktorTcKimlikNo = basTabipList[0].Tcno.ToString();
                                                    else
                                                    {
                                                        InfoBox.Show("Başhekim TC Kimlik Numarası Boş Olamaz");
                                                        return;
                                                    }

                                                    IlacRaporuServis.eraporBashekimOnayCevapDVO response = IlacRaporuServis.WebMethods.eraporBashekimOnay(Sites.SiteLocalHost, basTabipList[0].Tcno.ToString(), password, eraporBashekimOnayIstekDVO);
                                                    //lacRaporuServis.EraporOnayCevapDVO response = IlacRaporuServis.WebMethods.eraporOnay(Sites.SiteLocalHost,this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), user.ErecetePassword, eraporOnayIstekDVO);
                                                    if (response != null)
                                                    {
                                                        if (response.sonucKodu != null)
                                                        {
                                                            if (response.sonucKodu == "0000")
                                                            {
                                                                MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                                                                medulaReportResult.ResultCode = response.sonucKodu;
                                                                medulaReportResult.ResultExplanation = response.sonucMesaji;
                                                                InfoBox.Show("Rapor Onaylandı");
                                                            }
                                                            else
                                                            {
                                                                if (!string.IsNullOrEmpty(response.uyariMesaji) || !string.IsNullOrEmpty(response.sonucMesaji))
                                                                {
                                                                    MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Canceled;
                                                                    medulaReportResult.ResultCode = response.sonucKodu;
                                                                    medulaReportResult.ResultExplanation = response.uyariMesaji + response.sonucMesaji;
                                                                    string mesaj = response.uyariMesaji + " " + response.sonucMesaji;
                                                                    InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + mesaj);
                                                                }

                                                            }
                                                        }

                                                    }
                                                }
                                            }
                                            else
                                            {
                                                InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir İlaç Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                }
                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnOnayIptal"))
                {
                    try
                    {
                        if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                        {
                            ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                            if (currentCell != null)
                            {
                                ITTGridRow currentRow = currentCell.OwningRow;
                                if (currentRow != null)
                                {
                                    MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;


                                    if (currentMedulaReportResult != null)
                                    {
                                        if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                        {
                                            DialogResult dialogResult = MessageBox.Show("Seçili Raporu Meduladan Onay İptali Yapılacaktır!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                            if (dialogResult == DialogResult.OK)
                                            {
                                                IlacRaporuServis.eraporOnayRedIstekDVO eraporOnayRedIstekDVO = new IlacRaporuServis.eraporOnayRedIstekDVO();

                                                eraporOnayRedIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                                eraporOnayRedIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                                eraporOnayRedIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;

                                                _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                                                if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                                {
                                                    TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                                                    medulaPasswordForm.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                                                    if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                                    {
                                                        InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                                        return;
                                                    }
                                                }
                                                string password = "";
                                                if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                                    password = this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword;
                                                else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                                    password = this._ParticipatnFreeDrugReport.MedulaPassword;

                                                IlacRaporuServis.eraporOnayRedCevapDVO response = IlacRaporuServis.WebMethods.eraporOnayRed(Sites.SiteLocalHost, this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporOnayRedIstekDVO);
                                                if (response != null)
                                                {
                                                    if (response.sonucKodu != null)
                                                    {
                                                        if (response.sonucKodu == "0000")
                                                        {
                                                            MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                            medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                                                            medulaReportResult.ResultCode = response.sonucKodu;
                                                            medulaReportResult.ResultExplanation = response.sonucMesaji;
                                                            InfoBox.Show("Rapor Onayı İptal Edildi");
                                                        }
                                                        else
                                                        {
                                                            if (!string.IsNullOrEmpty(response.uyariMesaji))
                                                            {
                                                                MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Canceled;
                                                                medulaReportResult.ResultCode = response.sonucKodu;
                                                                medulaReportResult.ResultExplanation = response.uyariMesaji;
                                                                InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                                                            }

                                                        }
                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir İlaç Raporunu Medulada Onay İptal İşlemi Yapamazsınız!!!");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }



                }
                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnRaporuSil"))
                {
                    try
                    {

                        if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                        {
                            ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                            if (currentCell != null)
                            {
                                ITTGridRow currentRow = currentCell.OwningRow;
                                if (currentRow != null)
                                {
                                    MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
                                    if (currentMedulaReportResult != null)
                                    {
                                        if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                        {
                                            DialogResult dialogResult = MessageBox.Show("Seçili Raporu Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
                                            if (dialogResult == DialogResult.OK)
                                            {
                                                if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "1")
                                                {
                                                    RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
                                                    //TODO : MEDULA20140501
                                                    raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                                                    RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
                                                    _raporOkuDVO.no = currentMedulaReportResult.ReportNumber;
                                                    _raporOkuDVO.raporSiraNo = currentMedulaReportResult.ReportRowNumber.ToString();
                                                    _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                                    _raporOkuDVO.tarih = currentMedulaReportResult.SendReportDate.Value.ToString("dd.MM.yyyy");
                                                    _raporOkuDVO.turu = "10";
                                                    raporSorguDVO.raporBilgisi = _raporOkuDVO;

                                                    RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
                                                    if (response != null)
                                                    {
                                                        //if (response.sonucKodu != null)
                                                        {
                                                            if (response.sonucKodu.Equals(0))
                                                            {
                                                                TTObjectContext context = _ParticipatnFreeDrugReport.ObjectContext;
                                                                MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._ParticipatnFreeDrugReport.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                                                //   MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                                                                medulaReportResult.ResultCode = response.sonucKodu.ToString();
                                                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                                medulaReportResult.ReportChasingNo = "";
                                                                medulaReportResult.ReportNumber = "";
                                                                medulaReportResult.ReportRowNumber = null;

                                                                context.Save();

                                                            }
                                                            else
                                                            {
                                                                if (!string.IsNullOrEmpty(response.sonucAciklamasi))
                                                                {
                                                                    TTObjectContext context = _ParticipatnFreeDrugReport.ObjectContext;
                                                                    MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._ParticipatnFreeDrugReport.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                                                    //   MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                                    medulaReportResult.ResultCode = response.sonucKodu.ToString();
                                                                    medulaReportResult.ResultExplanation = response.sonucAciklamasi;
                                                                    InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);

                                                                    context.Save();
                                                                }

                                                            }
                                                        }

                                                    }
                                                }
                                                else
                                                {
                                                    IlacRaporuServis.eraporSilIstekDVO eraporSilIstekDVO = new IlacRaporuServis.eraporSilIstekDVO();

                                                    eraporSilIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                                    eraporSilIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                                    eraporSilIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;

                                                    _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                                                    if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                                    {
                                                        TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                                                        medulaPasswordForm.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                                                        if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                                        {
                                                            InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                                            return;
                                                        }
                                                    }
                                                    string password = "";
                                                    if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                                        password = this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword;
                                                    else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                                        password = this._ParticipatnFreeDrugReport.MedulaPassword;

                                                    IlacRaporuServis.eraporSilCevapDVO response = IlacRaporuServis.WebMethods.eraporSil(Sites.SiteLocalHost, this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporSilIstekDVO);
                                                    if (response != null)
                                                    {
                                                        if (response.sonucKodu != null)
                                                        {
                                                            if (response.sonucKodu == "0000")
                                                            {
                                                                TTObjectContext context = _ParticipatnFreeDrugReport.ObjectContext;
                                                                MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._ParticipatnFreeDrugReport.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                                                //   MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                                                                medulaReportResult.ResultCode = response.sonucKodu;
                                                                medulaReportResult.ResultExplanation = "Rapor Bilgisi Silinmiştir";
                                                                medulaReportResult.ReportRowNumber = null;
                                                                medulaReportResult.ReportNumber = "";
                                                                medulaReportResult.ReportChasingNo = "";


                                                                context.Save();
                                                            }
                                                            else
                                                            {
                                                                if (!string.IsNullOrEmpty(response.sonucMesaji))
                                                                {
                                                                    TTObjectContext context = _ParticipatnFreeDrugReport.ObjectContext;
                                                                    MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(this._ParticipatnFreeDrugReport.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                                                    // MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                                    medulaReportResult.ResultCode = response.sonucKodu;
                                                                    medulaReportResult.ResultExplanation = response.sonucMesaji;
                                                                    InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);

                                                                    context.Save();
                                                                }

                                                            }
                                                        }

                                                    }
                                                }

                                            }
                                        }
                                        else
                                        {
                                            InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir İlaç Raporunu Meduladan Silme İşlemi Yapamazsınız!!!");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnGridAciklamaEkle"))
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
                    {
                        if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                        {
                            ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                            if (currentCell != null)
                            {
                                ITTGridRow currentRow = currentCell.OwningRow;
                                if (currentRow != null)
                                {
                                    MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
                                    if (currentMedulaReportResult != null)
                                    {
                                        if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                        {
                                            this.tttabIslemler.HideTabPage(tabTaniEkle);
                                            this.tttabIslemler.ShowTabPage(tabAciklamaEkle);
                                            this.tttabIslemler.HideTabPage(tabEtkinMaddeEkle);
                                            this.tttabIslemler.HideTabPage(tabTeshisEkle);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnGridTaniEkle"))
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
                    {
                        if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                        {
                            ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                            if (currentCell != null)
                            {
                                ITTGridRow currentRow = currentCell.OwningRow;
                                if (currentRow != null)
                                {
                                    MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
                                    if (currentMedulaReportResult != null)
                                    {
                                        if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                        {
                                            this.tttabIslemler.ShowTabPage(tabTaniEkle);
                                            this.tttabIslemler.HideTabPage(tabAciklamaEkle);
                                            this.tttabIslemler.HideTabPage(tabEtkinMaddeEkle);
                                            this.tttabIslemler.HideTabPage(tabTeshisEkle);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnGridTeshisEkle"))
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
                    {
                        if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                        {
                            ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                            if (currentCell != null)
                            {
                                ITTGridRow currentRow = currentCell.OwningRow;
                                if (currentRow != null)
                                {
                                    MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
                                    if (currentMedulaReportResult != null)
                                    {
                                        if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                        {
                                            this.tttabIslemler.HideTabPage(tabTaniEkle);
                                            this.tttabIslemler.HideTabPage(tabAciklamaEkle);
                                            this.tttabIslemler.HideTabPage(tabEtkinMaddeEkle);
                                            this.tttabIslemler.ShowTabPage(tabTeshisEkle);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnGridEtkinMaddeEkle"))
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
                    {
                        if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                        {
                            ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                            if (currentCell != null)
                            {
                                ITTGridRow currentRow = currentCell.OwningRow;
                                if (currentRow != null)
                                {
                                    MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
                                    if (currentMedulaReportResult != null)
                                    {
                                        if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                        {
                                            this.tttabIslemler.HideTabPage(tabTaniEkle);
                                            this.tttabIslemler.HideTabPage(tabAciklamaEkle);
                                            this.tttabIslemler.ShowTabPage(tabEtkinMaddeEkle);
                                            this.tttabIslemler.HideTabPage(tabTeshisEkle);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            //             if(Common.CurrentUser.Status == UserStatusEnum.SuperUser)
            //            {
            //                 this.MedulaReportResults.Rows[rowIndex].Cells[SendReportDateMedulaReportResult.Name].ReadOnly = false;
            //               // foreach(ITTGridRow  medulaReport in  this.MedulaReportResults.Rows)
            //               // {
            //                  //  medulaReport.Cells[SendReportDateMedulaReportResult.Name].ReadOnly = false;
            ////                        newRow.Cells[txtTakipNo1.Name].Value
            ////                        this.MedulaReportResults.ReadOnly
            //               // }
            //            }
#endregion ParticipationFreeDrugReportNewForm_MedulaReportResults_CellContentClick
        }

        private void btnAciklamaEkle_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnAciklamaEkle_Click
   try
            {
                if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                {
                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;

                            if (currentMedulaReportResult != null)
                            {
                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                {
                                    IlacRaporuServis.eraporAciklamaEkleIstekDVO eraporAciklamaEkleIstekDVO = new IlacRaporuServis.eraporAciklamaEkleIstekDVO();

                                    eraporAciklamaEkleIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                    eraporAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                    eraporAciklamaEkleIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;
                                    IlacRaporuServis.eraporAciklamaDVO eraporAciklamaDVO = new IlacRaporuServis.eraporAciklamaDVO();
                                    if (txtAciklamaEkleTakipFormuNo == null)
                                    {
                                        throw new TTUtils.TTException("Açıklama Giriniz!");
                                    }
                                    else
                                    {
                                        eraporAciklamaDVO.aciklama = txtAciklamaEkleAciklama.Text;
                                        eraporAciklamaDVO.takipFormuNo = txtAciklamaEkleTakipFormuNo.Text;
                                        eraporAciklamaEkleIstekDVO.eraporAciklamaDVO = eraporAciklamaDVO;
                                    }

                                    _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                                    if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                    {
                                        TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                                        medulaPasswordForm.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                                        if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                        {
                                            InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                            return;
                                        }
                                    }
                                    string password = "";
                                    if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                        password = this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword;
                                    else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                        password = this._ParticipatnFreeDrugReport.MedulaPassword;

                                    IlacRaporuServis.eraporAciklamaEkleCevapDVO response = IlacRaporuServis.WebMethods.eraporAciklamaEkle(Sites.SiteLocalHost, this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporAciklamaEkleIstekDVO);
                                    if (response != null)
                                    {
                                        if (response.sonucKodu != null)
                                        {
                                            if (response.sonucKodu == "0000")
                                            {
                                                txtAciklamaEkleSonucMesaji.Text = response.sonucMesaji + " " + response.uyariMesaji + " " + "İşlem Başarılı.";

                                                TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                                ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));
                                                string aciklama = string.Empty;
                                                aciklama = Common.GetTextOfRTFString(_participationFreeDrugReport.Description.ToString());
                                                aciklama += txtAciklamaEkleAciklama.Text;
                                                _participationFreeDrugReport.Description = Common.GetRTFOfTextString(aciklama);
                                                _context.Save();
                                            }
                                            else
                                            {
                                                if (!string.IsNullOrEmpty(response.sonucMesaji))
                                                {
                                                    InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.uyariMesaji + "" + response.sonucMesaji + " Rapor Onaylanamamıştır.  !!!");
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception)
            {

                throw;
            }
#endregion ParticipationFreeDrugReportNewForm_btnAciklamaEkle_Click
        }

        private void btnTaniEkle_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnTaniEkle_Click
   try
            {
                if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                {
                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;

                            if (currentMedulaReportResult != null)
                            {
                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                {
                                    if (lstDiagnosisAddedToEpisode.SelectedObject == null)
                                    {
                                        InfoBox.Show("Tanıyı Seçiniz!");
                                        return;
                                    }
                                }
                                if (lstTeshisAddedToDiagnosis.SelectedObject == null)
                                {
                                    InfoBox.Show("Tanıyı Eklemek İstediğiniz Teşhisi Seçiniz!");
                                    return;
                                }
                                IlacRaporuServis.eraporTaniEkleIstekDVO eraporTaniEkleIstekDVO = new IlacRaporuServis.eraporTaniEkleIstekDVO();
                                eraporTaniEkleIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                eraporTaniEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                eraporTaniEkleIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;
                                eraporTaniEkleIstekDVO.raporTeshisKodu = ((Teshis)lstTeshisAddedToDiagnosis.SelectedObject).teshisKodu != null ? ((Teshis)lstTeshisAddedToDiagnosis.SelectedObject).teshisKodu.ToString() : "";

                                IlacRaporuServis.eraporTaniDVO eraporTaniDVO = new IlacRaporuServis.eraporTaniDVO();
                                eraporTaniDVO.taniKodu = ((DiagnosisDefinition)lstDiagnosisAddedToEpisode.SelectedObject).Code;
                                eraporTaniDVO.taniAdi = ((DiagnosisDefinition)lstDiagnosisAddedToEpisode.SelectedObject).Name;
                                eraporTaniEkleIstekDVO.eraporTaniDVO = eraporTaniDVO;

                                _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                                if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                {
                                    TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                                    medulaPasswordForm.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                                    if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                    {
                                        InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                        return;
                                    }
                                }
                                string password = "";
                                if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                    password = this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword;
                                else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                    password = this._ParticipatnFreeDrugReport.MedulaPassword;

                                IlacRaporuServis.eraporTaniEkleCevapDVO response = IlacRaporuServis.WebMethods.eraporTaniEkle(Sites.SiteLocalHost, this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporTaniEkleIstekDVO);
                                if (response != null)
                                {

                                    if (response.sonucKodu != null)
                                    {
                                        if (response.sonucKodu == "0000")
                                        {
                                            txtTaniEkleSonucKodu.Text = response.sonucKodu;
                                            txtTaniEkleSonucMesaji.Text = "İşlem Başarılı.";
                                            TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                            ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));

                                            DiagnosisGrid newdg = new DiagnosisGrid(_participationFreeDrugReport.ObjectContext);
                                            newdg.EpisodeAction = _ParticipatnFreeDrugReport;
                                            newdg.AddToHistory = false;
                                            newdg.Diagnose = ((DiagnosisDefinition)lstDiagnosisAddedToEpisode.SelectedObject);
                                            newdg.DiagnosisType = DiagnosisTypeEnum.Primer;
                                            newdg.IsMainDiagnose = false;
                                            newdg.ResponsibleUser = this._ParticipatnFreeDrugReport.ProcedureDoctor;//(ResUser)lstDoctorAddedToEpisodeDiagnosis.SelectedObject;
                                            newdg.DiagnoseDate = System.DateTime.Now;
                                            newdg.Episode = this._ParticipatnFreeDrugReport.Episode;
                                            //newdg.Teshis = ((Teshis)lstTeshisAddedToDiagnosis.SelectedObject);
                                            _context.Save();
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(response.sonucMesaji))
                                            {
                                                txtTaniEkleSonucKodu.Text = response.sonucKodu;
                                                txtTaniEkleSonucMesaji.Text = response.sonucMesaji;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            catch (Exception)
            {

                throw;
            }
#endregion ParticipationFreeDrugReportNewForm_btnTaniEkle_Click
        }

        private void lstDiagnosisAddedToEpisode_SelectedObjectChanged()
        {
#region ParticipationFreeDrugReportNewForm_lstDiagnosisAddedToEpisode_SelectedObjectChanged
   DiagnosisDefinition diagnosisDefinition = ((DiagnosisDefinition)lstDiagnosisAddedToEpisode.SelectedObject);
            if (diagnosisDefinition.Teshis != null)
            {
                // this.GridDiagnosis.Rows[rowIndex].Cells["Teshis"].Value = secDiagnosisGrid.Diagnose.Teshis;
                lstTeshisAddedToDiagnosis.SelectedObject = diagnosisDefinition.Teshis;
            }
#endregion ParticipationFreeDrugReportNewForm_lstDiagnosisAddedToEpisode_SelectedObjectChanged
        }

        private void btnTeshisEkle_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnTeshisEkle_Click
   try
            {
                if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                {
                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;

                            if (currentMedulaReportResult != null)
                            {
                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                {
                                    if (lstDiagnoseAddedToTeshis.SelectedObject == null)
                                    {
                                        InfoBox.Show("Teşhis Seçiniz!");
                                        return;
                                    }
                                }
                                if (gridAddedDiagnosis.Rows.Count == 0)
                                {
                                    InfoBox.Show("Tanı Seçiniz!");
                                    return;
                                }
                                IlacRaporuServis.eraporTeshisEkleIstekDVO eraporTeshisEkleIstekDVO = new IlacRaporuServis.eraporTeshisEkleIstekDVO();
                                eraporTeshisEkleIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                eraporTeshisEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                eraporTeshisEkleIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;

                                IlacRaporuServis.eraporTeshisDVO eraporTeshisDVO = new IlacRaporuServis.eraporTeshisDVO();
                                eraporTeshisDVO.raporTeshisKodu = ((Teshis)lstDiagnoseAddedToTeshis.SelectedObject).teshisKodu != null ? ((Teshis)lstDiagnoseAddedToTeshis.SelectedObject).teshisKodu.ToString() : "";
                                eraporTeshisDVO.baslangicTarihi = Convert.ToDateTime(this.TeshistStartDate.NullableValue).ToString("dd.MM.yyyy");
                                eraporTeshisDVO.bitisTarihi = Convert.ToDateTime(this.TeshisEndDate.NullableValue).ToString("dd.MM.yyyy");

                                List<IlacRaporuServis.taniDVO> taniDVOList = new List<IlacRaporuServis.taniDVO>();

                                foreach (ITTGridRow item in gridAddedDiagnosis.Rows)
                                {
                                    IlacRaporuServis.taniDVO taniDVO = new IlacRaporuServis.taniDVO();
                                    DiagnosisDefinition tani = (DiagnosisDefinition)_ParticipatnFreeDrugReport.ObjectContext.GetObject((Guid)item.Cells[gridTeshisEkleTanilari.Name].Value, typeof(DiagnosisDefinition));
                                    taniDVO.kodu = tani.Code;
                                    taniDVO.adi = tani.Name;
                                    taniDVOList.Add(taniDVO);
                                }
                                eraporTeshisDVO.taniListesi = taniDVOList.ToArray();
                                eraporTeshisEkleIstekDVO.eraporTeshisDVO = eraporTeshisDVO;

                                _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                                if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                {
                                    TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                                    medulaPasswordForm.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                                    if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                    {
                                        InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                        return;
                                    }
                                }
                                string password = "";
                                if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                    password = this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword;
                                else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                    password = this._ParticipatnFreeDrugReport.MedulaPassword;

                                IlacRaporuServis.eraporTeshisEkleCevapDVO response = IlacRaporuServis.WebMethods.eraporTeshisEkle(Sites.SiteLocalHost, this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporTeshisEkleIstekDVO);
                                if (response != null)
                                {

                                    if (response.sonucKodu != null)
                                    {
                                        if (response.sonucKodu == "0000")
                                        {
                                            txtTeshisEkleSonucKodu.Text = response.sonucKodu;
                                            txtTeshisEkleSonucMesaji.Text = "İşlem Başarılı.";
                                            foreach (ITTGridRow item in gridAddedDiagnosis.Rows)
                                            {
                                                TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                                ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));

                                                //DiagnosisDefinition tani = (DiagnosisDefinition)_ParticipatnFreeDrugReport.ObjectContext.GetObject((Guid)item.Cells[gridTeshisEkleTanilari.Name].Value, typeof(DiagnosisDefinition));
                                                DiagnosisGrid newdg = new DiagnosisGrid(_participationFreeDrugReport.ObjectContext);
                                                newdg.EpisodeAction = _ParticipatnFreeDrugReport;
                                                newdg.AddToHistory = false;
                                                newdg.Diagnose = ((DiagnosisDefinition)_ParticipatnFreeDrugReport.ObjectContext.GetObject((Guid)item.Cells[gridTeshisEkleTanilari.Name].Value, typeof(DiagnosisDefinition)));
                                                newdg.DiagnosisType = DiagnosisTypeEnum.Primer;
                                                newdg.IsMainDiagnose = false;
                                                newdg.ResponsibleUser = this._ParticipatnFreeDrugReport.ProcedureDoctor;//(ResUser)lstDoctorAddedToEpisodeDiagnosis.SelectedObject;
                                                newdg.DiagnoseDate = System.DateTime.Now;
                                                newdg.Episode = this._ParticipatnFreeDrugReport.Episode;
                                                //newdg.Teshis = ((Teshis)lstDiagnoseAddedToTeshis.SelectedObject);
                                                _context.Save();
                                            }
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(response.sonucMesaji))
                                            {
                                                txtTeshisEkleSonucKodu.Text = response.sonucKodu;
                                                txtTeshisEkleSonucMesaji.Text = response.sonucMesaji;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception)
            {

                throw;
            }
#endregion ParticipationFreeDrugReportNewForm_btnTeshisEkle_Click
        }

        private void btnEtkinMaddeEkle_Click()
        {
#region ParticipationFreeDrugReportNewForm_btnEtkinMaddeEkle_Click
   try
            {
                if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
                {
                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;

                            if (currentMedulaReportResult != null)
                            {
                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
                                {
                                    if (lstEklenecekEtkinMadde.SelectedObject == null)
                                    {
                                        InfoBox.Show("Etkin Madde Seçiniz!");
                                        return;
                                    }
                                }
                                if (cmbEklenecekDozAraligi.SelectedItem == null || cmbEklenecekDozAraligi.SelectedItem.Value == null)
                                {
                                    InfoBox.Show("Doz Aralığı Seçiniz!");
                                    return;
                                }
                                if (cmbEklenecekDozBirimi.SelectedItem == null || cmbEklenecekDozBirimi.SelectedItem.Value == null)
                                {
                                    InfoBox.Show("Doz Birimi Seçiniz!");
                                    return;
                                }
                                if (cmdEkelenecekPeriyodBirimi.SelectedItem == null || cmdEkelenecekPeriyodBirimi.SelectedItem.Value == null)
                                {
                                    InfoBox.Show("Periyod Birimi Seçiniz!");
                                    return;
                                }
                                if (string.IsNullOrEmpty(txtEklenecekDoz.Text))
                                {
                                    InfoBox.Show("Doz Giriniz!");
                                    return;
                                }
                                if (string.IsNullOrEmpty(txtEklenecekPeriyodu.Text))
                                {
                                    InfoBox.Show("Periyodu Giriniz!");
                                    return;
                                }

                                IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO eraporEtkinMaddeEkleIstekDVO = new IlacRaporuServis.eraporEtkinMaddeEkleIstekDVO();
                                eraporEtkinMaddeEkleIstekDVO.doktorTcKimlikNo = this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                eraporEtkinMaddeEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                eraporEtkinMaddeEkleIstekDVO.raporTakipNo = currentMedulaReportResult.ReportChasingNo;

                                IlacRaporuServis.eraporEtkinMaddeDVO _eraporEtkinMaddeDVO = new IlacRaporuServis.eraporEtkinMaddeDVO();
                                _eraporEtkinMaddeDVO.etkinMaddeKodu = ((EtkinMadde)lstEklenecekEtkinMadde.SelectedObject).etkinMaddeKodu;
                                _eraporEtkinMaddeDVO.kullanimDoz1 = DrugOrder.GetDetailCount((FrequencyEnum)Enum.Parse(typeof(FrequencyEnum), cmbEklenecekDozAraligi.ControlValue.ToString())).ToString();
                                _eraporEtkinMaddeDVO.kullanimDoz2 = txtEklenecekDoz.Text;
                                _eraporEtkinMaddeDVO.kullanimDozBirimi = ((int)cmbEklenecekDozBirimi.SelectedItem.Value).ToString();
                                _eraporEtkinMaddeDVO.kullanimDozPeriyot = txtEklenecekPeriyodu.Text;
                                _eraporEtkinMaddeDVO.kullanimDozPeriyotBirimi = ((int)cmdEkelenecekPeriyodBirimi.SelectedItem.Value).ToString();

                                IlacRaporuServis.etkinMaddeDVO _etkinMaddeDVO = new IlacRaporuServis.etkinMaddeDVO();
                                _etkinMaddeDVO.kodu = ((EtkinMadde)lstEklenecekEtkinMadde.SelectedObject).etkinMaddeKodu;
                                _etkinMaddeDVO.adi = ((EtkinMadde)lstEklenecekEtkinMadde.SelectedObject).etkinMaddeAdi;
                                _etkinMaddeDVO.icerikMiktari = ((EtkinMadde)lstEklenecekEtkinMadde.SelectedObject).icerikMiktari;
                                _etkinMaddeDVO.formu = ((EtkinMadde)lstEklenecekEtkinMadde.SelectedObject).form;
                                _eraporEtkinMaddeDVO.etkinMaddeDVO = _etkinMaddeDVO;

                                eraporEtkinMaddeEkleIstekDVO.eraporEtkinMaddeDVO = _eraporEtkinMaddeDVO;

                                _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                                if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                {
                                    TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                                    medulaPasswordForm.ShowEdit(this.FindForm(), _ParticipatnFreeDrugReport, true);

                                    if (string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                    {
                                        InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                        return;
                                    }
                                }
                                string password = "";
                                if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                    password = this._ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword;
                                else if (!string.IsNullOrEmpty(this._ParticipatnFreeDrugReport.MedulaPassword))
                                    password = this._ParticipatnFreeDrugReport.MedulaPassword;

                                IlacRaporuServis.eraporEtkinMaddeEkleCevapDVO response = IlacRaporuServis.WebMethods.eraporEtkinMaddeEkle(Sites.SiteLocalHost, this._ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporEtkinMaddeEkleIstekDVO);
                                if (response != null)
                                {

                                    if (response.sonucKodu != null)
                                    {
                                        if (response.sonucKodu == "0000")
                                        {
                                            txtEtkinMaddeEkleSonucKodu.Text = response.sonucKodu;
                                            txtEtkinMaddeEkleSonucMesaji.Text = "İşlem Başarılı.";

                                            TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
                                            ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));

                                            ParticipationFreeDrgGrid newdg = new ParticipationFreeDrgGrid(_participationFreeDrugReport.ObjectContext);
                                            newdg.EtkinMadde = ((EtkinMadde)lstEklenecekEtkinMadde.SelectedObject);

                                            newdg.Frequency = (cmbEklenecekDozAraligi.SelectedItem.Value).ToString() == "0" ? FrequencyEnum.Q1H :
                                                (cmbEklenecekDozAraligi.SelectedItem.Value).ToString() == "1" ? FrequencyEnum.Q3H :
                                                (cmbEklenecekDozAraligi.SelectedItem.Value).ToString() == "2" ? FrequencyEnum.Q6H :
                                                (cmbEklenecekDozAraligi.SelectedItem.Value).ToString() == "3" ? FrequencyEnum.Q8H :
                                                (cmbEklenecekDozAraligi.SelectedItem.Value).ToString() == "4" ? FrequencyEnum.Q12H :
                                                (cmbEklenecekDozAraligi.SelectedItem.Value).ToString() == "5" ? FrequencyEnum.Q24H :
                                                (cmbEklenecekDozAraligi.SelectedItem.Value).ToString() == "6" ? FrequencyEnum.Q2H : FrequencyEnum.Q4H;

                                            newdg.PeriodUnitType = (cmdEkelenecekPeriyodBirimi.SelectedItem.Value).ToString() == "3" ? PeriodUnitTypeEnum.DayPeriod :
                                                (cmdEkelenecekPeriyodBirimi.SelectedItem.Value).ToString() == "4" ? PeriodUnitTypeEnum.WeekPeriod :
                                                (cmdEkelenecekPeriyodBirimi.SelectedItem.Value).ToString() == "5" ? PeriodUnitTypeEnum.MonthPeriod : PeriodUnitTypeEnum.YearPeriod;

                                            newdg.ParticipatnFreeDrugReport = _ParticipatnFreeDrugReport;
                                            newdg.MedulaDoseInteger = txtEklenecekDoz.Text;

                                            newdg.UsageDoseUnitType = (cmbEklenecekDozBirimi.SelectedItem.Value).ToString() == "1" ? UsageDoseUnitTypeEnum.Adet :
                                                (cmbEklenecekDozBirimi.SelectedItem.Value).ToString() == "2" ? UsageDoseUnitTypeEnum.Mililitre :
                                                (cmbEklenecekDozBirimi.SelectedItem.Value).ToString() == "3" ? UsageDoseUnitTypeEnum.Miligram :
                                                (cmbEklenecekDozBirimi.SelectedItem.Value).ToString() == "4" ? UsageDoseUnitTypeEnum.Gram :
                                                (cmbEklenecekDozBirimi.SelectedItem.Value).ToString() == "5" ? UsageDoseUnitTypeEnum.Damla :
                                                (cmbEklenecekDozBirimi.SelectedItem.Value).ToString() == "6" ? UsageDoseUnitTypeEnum.Unite :
                                                (cmbEklenecekDozBirimi.SelectedItem.Value).ToString() == "7" ? UsageDoseUnitTypeEnum.Kutu :
                                                (cmbEklenecekDozBirimi.SelectedItem.Value).ToString() == "8" ? UsageDoseUnitTypeEnum.Mikrogram : UsageDoseUnitTypeEnum.Mikrolitre;

                                            newdg.Day = Convert.ToInt32(txtEklenecekPeriyodu.Text);
                                            _context.Save();
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(response.sonucMesaji))
                                            {
                                                txtEtkinMaddeEkleSonucKodu.Text = response.sonucKodu;
                                                txtEtkinMaddeEkleSonucMesaji.Text = response.sonucMesaji;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception)
            {

                throw;
            }
#endregion ParticipationFreeDrugReportNewForm_btnEtkinMaddeEkle_Click
        }

        private void ParticipationFreeDrugs_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ParticipationFreeDrugReportNewForm_ParticipationFreeDrugs_CellValueChanged
   if (rowIndex > -1 && columnIndex > -1 && columnIndex == 0)
            {
                if (ParticipationFreeDrugs.CurrentCell.OwningColumn.Name.Equals(EtkinMaddeParticipationFreeDrgGrid.Name))
                {
                    if (ParticipationFreeDrugs.CurrentCell.OwningRow.Cells[DrugName.Name].Value != null)
                    {
                        ParticipationFreeDrugs.CurrentCell.OwningRow.Cells[DrugName.Name].Value = null;
                        InfoBox.Show("Aynı satırda hem medula kapsamında hemde medula haricinde etkin madde seçilemez!");
                    }
                }
                else if (ParticipationFreeDrugs.CurrentCell.OwningColumn.Name.Equals(DrugName.Name))
                {
                    if (ParticipationFreeDrugs.CurrentCell.OwningRow.Cells[EtkinMaddeParticipationFreeDrgGrid.Name].Value != null)
                    {
                        ParticipationFreeDrugs.CurrentCell.OwningRow.Cells[EtkinMaddeParticipationFreeDrgGrid.Name].Value = null;
                        InfoBox.Show("Aynı satırda hem medula kapsamında hemde medula haricinde etkin madde seçilemez!");
                    }
                }
            }
#endregion ParticipationFreeDrugReportNewForm_ParticipationFreeDrugs_CellValueChanged
        }

        private void ParticipationFreeDrugs_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ParticipationFreeDrugReportNewForm_ParticipationFreeDrugs_CellContentClick
   if (ParticipationFreeDrugs.CurrentCell != null)
            {
                if (ParticipationFreeDrugs.CurrentCell.OwningColumn.Name == ParticipationFreeDrugs.Columns[SUTRules.Name].Name)
                {
                    if (ParticipationFreeDrugs.CurrentCell.OwningRow.TTObject == null)
                        return;

                    ParticipationFreeDrgGrid pfd = (ParticipationFreeDrgGrid)ParticipationFreeDrugs.CurrentCell.OwningRow.TTObject;
                    if (pfd.EtkinMadde == null)
                        return;

                    string filter = "ETKINMADDE = '" + pfd.EtkinMadde.ObjectID.ToString() + "'";
                    IList acts = _ParticipatnFreeDrugReport.ObjectContext.QueryObjects(typeof(ActiveIngredientSUTRuleDef).Name, filter);
                    if (acts.Count == 0)
                    {
                        InfoBox.Show("Bu etken maddeye ait kural tanımı bulunamadı!");
                        return;
                    }
                    else
                    {
                        ActiveIngredientSUTRuleDef act = (ActiveIngredientSUTRuleDef)acts[0];
                        TTDefinitionForm frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["ActiveIngredientSUTRuleDefinitionList"], filter);
                        frm.ShowEdit(this.FindForm(), TTObjectDefManager.Instance.ListDefs["ActiveIngredientSUTRuleDefinitionList"], act);
                    }
                }
                if (ParticipationFreeDrugs.CurrentCell.OwningColumn.Name == ParticipationFreeDrugs.Columns[IlacEtkinMadde.Name].Name)
                {
                    ParticipationFreeDrgGrid pfd = (ParticipationFreeDrgGrid)ParticipationFreeDrugs.CurrentCell.OwningRow.TTObject;
                    if (pfd.EtkinMadde != null)
                    {
                        string filter = "ETKINMADDE = '" + pfd.EtkinMadde.ObjectID.ToString() + "'";
                        IList dds = _ParticipatnFreeDrugReport.ObjectContext.QueryObjects(typeof(DrugDefinition).Name, filter);
                        if (dds.Count == 0)
                        {
                            InfoBox.Show("Bu etken maddeye ait ilaç bulunamadı!");
                            return;
                        }
                    }

                    ParticipationFreeDrgGrid participationFreeDrgGrid = (ParticipationFreeDrgGrid)ParticipationFreeDrugs.CurrentCell.OwningRow.TTObject;
                    //  TTVisual.TTForm ilacEtkinMaddeSorgulamaForm = new TTFormClasses.IlacEtkinMaddeSorgulamaForm(drugDefinition);
                    EtkenMaddeIlacSorgulamaFormu etkenMaddeIlacSorgulamaFormu = EtkenMaddeIlacSorgulamaFormu.NewIEtkenMaddeIlacSorgulamaFormu2(participationFreeDrgGrid);
                    InfoBox.Show("etkenMaddeIlacSorgulamaFormu.ShowDialog(this);");
                    //                    
                    //                    TTVisual.TTForm ilacEtkinMaddeSorgulamaForm = new TTFormClasses.IlacEtkinMaddeSorgulamaForm();
                    //                    ilacEtkinMaddeSorgulamaForm.ShowEdit(this.FindForm(),(ParticipationFreeDrgGrid)ParticipationFreeDrugs.CurrentCell.OwningRow.TTObject);

                }
            }
#endregion ParticipationFreeDrugReportNewForm_ParticipationFreeDrugs_CellContentClick
        }

        private void GridDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ParticipationFreeDrugReportNewForm_GridDiagnosis_CellContentClick
   // if (_ParticipatnFreeDrugReport.TumTeshisler.HasValue && _ParticipatnFreeDrugReport.TumTeshisler.Value == false)
            //            {
            //                if (GridDiagnosis.CurrentCell.OwningColumn.Name == "Diagnose")
            //                {
            //                    SecDiagnosisGrid secDiagnosisGrid = (SecDiagnosisGrid)((ITTGridRow)this.GridDiagnosis.Rows[rowIndex]).TTObject;
            //                    //if (secDiagnosisGrid.Diagnose.Teshis != null)
            //                    //{
            //                    //    // this.GridDiagnosis.Rows[rowIndex].Cells["Teshis"].Value = secDiagnosisGrid.Diagnose.Teshis;
            //                    //    secDiagnosisGrid.Teshis = secDiagnosisGrid.Diagnose.Teshis;
            //                    //}
            //
            //
            //
            //                    if (secDiagnosisGrid.Diagnose.DiagnosisDefTeshis.Count > 0)
            //                    {
            //                        string filterExpression = " TESHISKODU IN (";
            //                        int i = 1;
            //                        foreach (DiagnosisDefTeshis diagnosisDefTeshis in secDiagnosisGrid.Diagnose.DiagnosisDefTeshis)
            //                        {
            //                            if (diagnosisDefTeshis.Teshis != null)
            //                            {
            //                                filterExpression += diagnosisDefTeshis.Teshis.teshisKodu != null ? diagnosisDefTeshis.Teshis.teshisKodu.ToString() : null;
            //                                if (i < secDiagnosisGrid.Diagnose.DiagnosisDefTeshis.Count)
            //                                    filterExpression += ",";
            //                            }
            //                            i++;
            //                        }
            //                        filterExpression += ")";
            //                        ((ITTListBoxColumn)((ITTGridColumn)this.GridDiagnosis.Columns["Teshis"])).ListFilterExpression = filterExpression;
            //                    }
            //                }
            //            }
            //            else
            //                ((ITTListBoxColumn)((ITTGridColumn)this.GridDiagnosis.Columns["Teshis"])).ListFilterExpression = null;
#endregion ParticipationFreeDrugReportNewForm_GridDiagnosis_CellContentClick
        }

        private void GridDiagnosis_CurrentCellChanged()
        {
        }

        private void GridDiagnosis_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ParticipationFreeDrugReportNewForm_GridDiagnosis_CellValueChanged
   bool filtre = false;

            if (GridDiagnosis.CurrentCell.OwningColumn.Name == "Diagnose" || GridDiagnosis.CurrentCell.OwningColumn.Name == "chkTumTeshisler")
            {
                DiagnosisGrid secDiagnosisGrid = (DiagnosisGrid)((ITTGridRow)this.GridDiagnosis.Rows[rowIndex]).TTObject;

                if (secDiagnosisGrid.Diagnose != null && secDiagnosisGrid.Diagnose.DiagnosisDefTeshis.Count > 0)
                {
                    //if (this.GridDiagnosis.Rows[rowIndex].Cells["chkTumTeshisler"].Value == null)
                    //    filtre = true;
                    //else if (this.GridDiagnosis.Rows[rowIndex].Cells["chkTumTeshisler"].Value.ToString() == "False")
                    //    filtre = true;

                    if (secDiagnosisGrid.AllDiagnosisDefTeshis == null)
                        filtre = true;
                    else if (secDiagnosisGrid.AllDiagnosisDefTeshis == false)
                        filtre = true;

                    if (filtre == true)
                    {
                        string filterExpression = " TESHISKODU IN (";
                        int i = 1;
                        foreach (DiagnosisDefTeshis diagnosisDefTeshis in secDiagnosisGrid.Diagnose.DiagnosisDefTeshis)
                        {
                            if (diagnosisDefTeshis.Teshis != null)
                            {
                                filterExpression += diagnosisDefTeshis.Teshis.teshisKodu != null ? diagnosisDefTeshis.Teshis.teshisKodu.ToString() : null;
                                if (i < secDiagnosisGrid.Diagnose.DiagnosisDefTeshis.Count)
                                    filterExpression += ",";
                            }
                            i++;
                        }
                        filterExpression += ")";
                        ((ITTListBoxColumn)((ITTGridColumn)this.GridDiagnosis.Columns["Teshis"])).ListFilterExpression = filterExpression;

                        //if (secDiagnosisGrid.Diagnose.DiagnosisDefTeshis.Count == 1)
                            //secDiagnosisGrid.Teshis = secDiagnosisGrid.Diagnose.DiagnosisDefTeshis[0].Teshis;
                    }
                    else
                        ((ITTListBoxColumn)((ITTGridColumn)this.GridDiagnosis.Columns["Teshis"])).ListFilterExpression = null;
                }
                else
                    ((ITTListBoxColumn)((ITTGridColumn)this.GridDiagnosis.Columns["Teshis"])).ListFilterExpression = null;
            }
#endregion ParticipationFreeDrugReportNewForm_GridDiagnosis_CellValueChanged
        }

        private void ProcedureDoctor_SelectedObjectChanged()
        {
#region ParticipationFreeDrugReportNewForm_ProcedureDoctor_SelectedObjectChanged
   /*
            this.DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows.Clear();
            ITTGridRow row = this.DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows.Add();
            row.Cells[drTescilNoDiabetesMellitusPursuitDoctor.Name].Value = this.ProcedureDoctor.SelectedObject.ObjectID;

            if (this._ParticipatnFreeDrugReport.ProcedureDoctor != null && this._ParticipatnFreeDrugReport.ProcedureDoctor.ResourceSpecialities != null)
            {

                foreach (ResourceSpecialityGrid rsg in this._ParticipatnFreeDrugReport.ProcedureDoctor.ResourceSpecialities)
                {
                    if (rsg.MainSpeciality != null && rsg.MainSpeciality == true)
                        row.Cells[drBransKoduDiabetesMellitusPursuitDoctor.Name].Value = rsg.Speciality.ObjectID;
                }
            }
            */
            //            row.Cells[drBransKoduDiabetesMellitusPursuitDoctor.Name].Value = (SpecialityDefinition) ((ResUser)this.ProcedureDoctor.SelectedValue).res;
#endregion ParticipationFreeDrugReportNewForm_ProcedureDoctor_SelectedObjectChanged
        }

        private void btnChoose_Click()
        {
            #region ParticipationFreeDrugReportNewForm_btnChoose_Click
            //FolderBrowserDialog fbd = new FolderBrowserDialog();

            //         fbd.ShowNewFolderButton = true;

            //         DialogResult result = fbd.ShowDialog();

            //         if (result == DialogResult.OK)
            //         {
            //             this.FilePath.Text = fbd.SelectedPath;
            //         }
            //         else
            //         {
            //             InfoBox.Show("Hatalı İşlemler Dosya Yolunu Seçiniz");
            //         }
            var a = 1;
            #endregion ParticipationFreeDrugReportNewForm_btnChoose_Click
        }

  

        protected override void PreScript()
        {
#region ParticipationFreeDrugReportNewForm_PreScript
    base.PreScript();
            //            if (Common.CurrentUser.IsSuperUser)
            //            {
            //                btnMedulayaTopluGonder.Visible = true;
            //                btnChoose.Visible = true;
            //                FilePath.Visible = true;
            //                labelFilePath.Visible = true;
            //            }

         //   this.CheckForDiagnosys();

            if (this._ParticipatnFreeDrugReport.SubEpisode.PatientAdmission.Payer != null)
            {
                this.PatientEnterprise.Text = this._ParticipatnFreeDrugReport.SubEpisode.PatientAdmission.Payer.Name;
                if (this._ParticipatnFreeDrugReport.SubEpisode.PatientAdmission.Payer.Type != null)
                    this.SocialInsurance.Text = this._ParticipatnFreeDrugReport.SubEpisode.PatientAdmission.Payer.Type.Name;
            }
            this.SetProcedureDoctorAsCurrentResource();

            if (!Common.CurrentUser.IsSuperUser)
                ProcedureDoctor.ReadOnly = true;
            else
                ProcedureDoctor.ReadOnly = false;



            if (this._ParticipatnFreeDrugReport.ExaminationDate == null)
                this.ExaminationDate.ControlValue = Common.RecTime();

            if (this.TeshistStartDate == null || this.TeshistStartDate != null)
                this.TeshistStartDate.ControlValue = Common.RecTime();

            if (this.TeshisEndDate == null || this.TeshisEndDate != null)
                this.TeshisEndDate.ControlValue = Common.RecTime();

            ((ITTListBoxColumn)this.ParticipationFreeDrugs.Columns["EtkinMaddeParticipationFreeDrgGrid"]).ListFilterExpression = "BITISTARIHI > TO_DATE('" + Common.RecTime().ToShortDateString() + "','dd.mm.yyyy') AND BASLANGICTARIHI < TO_DATE('" + Common.RecTime().ToShortDateString() + "','dd.mm.yyyy')";
            //((ITTListBoxColumn)this.ParticipationFreeDrugs.Columns["EtkinMaddeParticipationFreeDrgGrid"]).ListFilterExpression = "GETDATE() BETWEEN BASLANGICTARIHI AND BITISTARIHI";

          

            if (((TTVisual.TTCheckBox)(CommitteeReport)).Value == null)
                ((TTVisual.TTCheckBox)(CommitteeReport)).Value = false;

            if (((TTVisual.TTCheckBox)(CommitteeReport)).Checked)
            {
                this.listSecondDoctor.Visible = true;
                this.listSecondDoctor.Required = true;
                this.labelSecondDoctor.Visible = true;
                this.ThirdDoctor.Visible = true;
                this.ThirdDoctor.Required = true;
                this.labelThirdDoctor.Visible = true;
                //                this.btnIkinciTabipOnay.Visible = true;
                //                this.btnUcuncuTabipOnay.Visible = true;
            }
            else
            {
                this.listSecondDoctor.Visible = false;
                this.listSecondDoctor.Required = false;
                this.labelSecondDoctor.Visible = false;
                this.ThirdDoctor.Visible = false;
                this.ThirdDoctor.Required = false;
                this.labelThirdDoctor.Visible = false;
                //                this.btnIkinciTabipOnay.Visible = false;
                //                this.btnUcuncuTabipOnay.Visible = false;
            }

            if (Common.CurrentUser.Status == UserStatusEnum.SuperUser)
            {
                this.MedulaReportResults.Columns[btnRaporuSil.Name].Visible = true;
                foreach (ITTGridRow row in MedulaReportResults.Rows)
                {
                    this.MedulaReportResults.Rows[row.Index].Cells[ReportChasingNoMedulaReportResult.Name].ReadOnly = false;
                    this.MedulaReportResults.Rows[row.Index].Cells[SendReportDateMedulaReportResult.Name].ReadOnly = false;
                    this.MedulaReportResults.Rows[row.Index].Cells[ReportNumberMedulaReportResult.Name].ReadOnly = false;
                    this.MedulaReportResults.Rows[row.Index].Cells[ReportRowNumberMedulaReportResult.Name].ReadOnly = false;
                }
            }
            else
            {
                foreach (ITTGridRow row in MedulaReportResults.Rows)
                {
                    this.MedulaReportResults.Rows[row.Index].Cells[ReportChasingNoMedulaReportResult.Name].ReadOnly = true;
                    this.MedulaReportResults.Rows[row.Index].Cells[SendReportDateMedulaReportResult.Name].ReadOnly = true;
                    this.MedulaReportResults.Rows[row.Index].Cells[ReportNumberMedulaReportResult.Name].ReadOnly = true;
                    this.MedulaReportResults.Rows[row.Index].Cells[ReportRowNumberMedulaReportResult.Name].ReadOnly = true;
                }
                if (_ParticipatnFreeDrugReport.CurrentStateDefID != ParticipatnFreeDrugReport.States.New)
                    this.MedulaReportResults.Columns[btnRaporuSil.Name].Visible = false;
                else
                    this.MedulaReportResults.Columns[btnRaporuSil.Name].Visible = true;
            }
            foreach (ParticipationFreeDrgGrid i in _ParticipatnFreeDrugReport.ParticipationFreeDrugs)
            {
                if (i.MedulaDose != null && i.MedulaDoseInteger == null)
                    i.MedulaDoseInteger = i.MedulaDose.ToString();
            }

            if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "1")
                btnHastaIlacRaporuListesi.Visible = false;
            else
                btnHastaIlacRaporuListesi.Visible = true;

            this.tttabIslemler.HideTabPage(tabTaniEkle);
            this.tttabIslemler.HideTabPage(tabAciklamaEkle);
            this.tttabIslemler.HideTabPage(tabTeshisEkle);
            this.tttabIslemler.HideTabPage(tabEtkinMaddeEkle);
            this.tttabIslemler.HideTabPage(tabIlacRaporlari);


            if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULAILACRAPORUGONDERIMTIPI", "0") == "0")
            {
                if (_ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.Approval)
                    this.btnMedulaBashekimOnay.Visible = true;
                else
                    this.btnMedulaBashekimOnay.Visible = false;

                if (((TTVisual.TTCheckBox)(CommitteeReport)).Checked)
                {
                    if (_ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.New)
                    {
                        this.DropStateButton(ParticipatnFreeDrugReport.States.Approval);
                        this.AddStateButton(ParticipatnFreeDrugReport.States.SecondDoctorApproval);
                        CommitteeReport.ReadOnly = false;
                        this.btnIkinciTabipOnay.Visible = false;
                        this.btnUcuncuTabipOnay.Visible = false;
                    }
                    else if (_ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval)
                    {
                        if (this._ParticipatnFreeDrugReport.SecondDoctor != null)
                        {
                            if (Common.CurrentUser.IsSuperUser == false && this._ParticipatnFreeDrugReport.SecondDoctor.ObjectID.ToString() != Common.CurrentResource.ObjectID.ToString())
                            {
                                this.DropStateButton(ParticipatnFreeDrugReport.States.ThirdDoctorApproval);
                                this.DropStateButton(ParticipatnFreeDrugReport.States.New);
                                this.btnIkinciTabipOnay.Visible = false;
                                CommitteeReport.ReadOnly = true;
                            }
                            else
                            {
                                this.AddStateButton(ParticipatnFreeDrugReport.States.ThirdDoctorApproval);
                                CommitteeReport.ReadOnly = true;
                                this.btnIkinciTabipOnay.Visible = true;
                            }
                        }
                    }
                    else if (_ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval)
                    {

                        if (this._ParticipatnFreeDrugReport.ThirdDoctor != null)
                        {
                            if (Common.CurrentUser.IsSuperUser == false && this._ParticipatnFreeDrugReport.ThirdDoctor.ObjectID.ToString() != Common.CurrentResource.ObjectID.ToString())
                            {
                                this.DropStateButton(ParticipatnFreeDrugReport.States.Approval);
                                this.DropStateButton(ParticipatnFreeDrugReport.States.New);
                                this.btnUcuncuTabipOnay.Visible = false;
                                CommitteeReport.ReadOnly = true;
                            }
                            else
                            {
                                this.AddStateButton(ParticipatnFreeDrugReport.States.Approval);
                                CommitteeReport.ReadOnly = false;
                                this.btnUcuncuTabipOnay.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        CommitteeReport.ReadOnly = true;
                        this.btnIkinciTabipOnay.Visible = false;
                        this.btnUcuncuTabipOnay.Visible = false;
                    }
                }
                else
                {
                    if (_ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.New)
                    {
                        CommitteeReport.ReadOnly = false;
                        this.btnIkinciTabipOnay.Visible = false;
                        this.btnUcuncuTabipOnay.Visible = false;
                        this.DropStateButton(ParticipatnFreeDrugReport.States.SecondDoctorApproval);
                        this.DropStateButton(ParticipatnFreeDrugReport.States.ThirdDoctorApproval);
                    }
                    else
                        CommitteeReport.ReadOnly = true;

                    this.AddStateButton(ParticipatnFreeDrugReport.States.Approval);
                    //                    this.DropStateButton(ParticipatnFreeDrugReport.States.SecondDoctorApproval);
                    //                    this.DropStateButton(ParticipatnFreeDrugReport.States.ThirdDoctorApproval);
                }
            }
            else
            {
                this.btnMedulaBashekimOnay.Visible = false;
                this.DropStateButton(ParticipatnFreeDrugReport.States.SecondDoctorApproval);
                this.DropStateButton(ParticipatnFreeDrugReport.States.ThirdDoctorApproval);
            }
            //TTObjectContext _context = _ParticipatnFreeDrugReport.ObjectContext;
            //ParticipatnFreeDrugReport _participationFreeDrugReport = (ParticipatnFreeDrugReport)_context.GetObject(this._ParticipatnFreeDrugReport.ObjectID, typeof(ParticipatnFreeDrugReport));
            //if (_participationFreeDrugReport.ReportNo == null)
            //    _participationFreeDrugReport.ReportNo.GetNextValue();



            /* 
             * Doktor Bilgileri alanının formu açan doktorun bilgileri ile otomatik doldurulması (INC027553)
             */
         
            
            List<DiagnosisGrid> diagnosises = new List<DiagnosisGrid>();
            if(this._ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.New)
            {
                foreach(PatientExamination examination in this._ParticipatnFreeDrugReport.Episode.PatientExaminations)
                {
                    foreach (DiagnosisGrid secDiagnosis in examination.SecDiagnosis)
                    {
                        if ( diagnosises.Contains(secDiagnosis) == false)
                        {
                            if(this._ParticipatnFreeDrugReport.SecDiagnosis.Count == 0)
                                diagnosises.Add(secDiagnosis);
                            
                            foreach(DiagnosisGrid pfdSecDiagnosis in this._ParticipatnFreeDrugReport.SecDiagnosis)
                            {
                                if(pfdSecDiagnosis.DiagnoseCode != secDiagnosis.DiagnoseCode)
                                    diagnosises.Add(secDiagnosis);
                            }
                        }
                    }
                }
            }
            
            if (diagnosises.Count > 0)
            {
                foreach (DiagnosisGrid secDiagnosis in diagnosises)
                {
                    
                    DiagnosisGrid newSecDiagnosis = new DiagnosisGrid(this._ParticipatnFreeDrugReport.ObjectContext);
                    newSecDiagnosis.AddToHistory = secDiagnosis.AddToHistory;
                    newSecDiagnosis.Diagnose = secDiagnosis.Diagnose;
                    newSecDiagnosis.DiagnoseDate = Common.RecTime();
                    newSecDiagnosis.Episode = secDiagnosis.Episode;
                    newSecDiagnosis.EntryActionType = secDiagnosis.EntryActionType;
                    newSecDiagnosis.EpisodeAction = this._ParticipatnFreeDrugReport;
                    newSecDiagnosis.FreeDiagnosis = secDiagnosis.FreeDiagnosis;
                    newSecDiagnosis.ImportantMedicalInformation = secDiagnosis.ImportantMedicalInformation;
                    newSecDiagnosis.IsMainDiagnose = secDiagnosis.IsMainDiagnose;
                    newSecDiagnosis.SubactionProcedure = secDiagnosis.SubactionProcedure;
                    newSecDiagnosis.DiagnosisType = secDiagnosis.DiagnosisType;
                    
                }
            }

            foreach (DiagnosisGrid secDiagnose in this._ParticipatnFreeDrugReport.SecDiagnosis)
            {
                string filterExpression = string.Empty;
                int i = 1;
                
                if(secDiagnose.Diagnose.DiagnosisDefTeshis.Count > 0)
                {
                    filterExpression = " TESHISKODU IN (";
                    foreach (DiagnosisDefTeshis diagnosisDefTeshis in secDiagnose.Diagnose.DiagnosisDefTeshis)
                    {
                        if (diagnosisDefTeshis.Teshis != null)
                        {
                            filterExpression += diagnosisDefTeshis.Teshis.teshisKodu != null ? diagnosisDefTeshis.Teshis.teshisKodu.ToString() : null;
                            if (i < secDiagnose.Diagnose.DiagnosisDefTeshis.Count)
                                filterExpression += ",";
                        }
                        i++;
                    }
                    filterExpression += ")";
                }
                ((ITTListBoxColumn)((ITTGridColumn)this.GridDiagnosis.Columns["Teshis"])).ListFilterExpression = filterExpression;

                //if (secDiagnose.Diagnose.DiagnosisDefTeshis.Count == 1)
                //    secDiagnose.Teshis = secDiagnose.Diagnose.DiagnosisDefTeshis[0].Teshis;
            }




            /* 
             * XXXXXXde yapılmış tetkik sonuçlarının Diyabet Takp Formundaki ilgili alanları otomatik doldurması (INC027553)
             */
            //this.boyDiabetesMellitusPursuit.Text =  this._ParticipatnFreeDrugReport.Episode.Patient.Heigth.Value.ToString();
            //this.kiloDiabetesMellitusPursuit.Text =  this._ParticipatnFreeDrugReport.Episode.Patient.Weight.Value.ToString();
            //            if (this._ParticipatnFreeDrugReport.Episode.EpisodeActions != null) {
            //                foreach(EpisodeAction action in this._ParticipatnFreeDrugReport.Episode.EpisodeActions)
            //                {
            //                    if (action != null && action.ActionType != null) {
            //                        if (action.ActionType.Equals(ActionTypeEnum.LaboratoryRequest)) {
            //                            TTObjectClasses.LaboratoryRequest labReq = (TTObjectClasses.LaboratoryRequest)action;
            //                            if (labReq.LaboratoryProcedures != null)
            //                                foreach(LaboratoryProcedure proc in labReq.LaboratoryProcedures)
            //                            {
            //                                if(proc != null && proc.ProcedureObject != null && proc.ProcedureObject.SUTCode != null) {
            //                                    if(String.IsNullOrEmpty(hbA1cDiabetesMellitusPursuit.Text) && "901460".Equals(proc.ProcedureObject.SUTCode)) {
            //                                        hbA1cDiabetesMellitusPursuit.Text = proc.Result;
            //                                    }
            //                                    else if(String.IsNullOrEmpty(trigliseridDiabetesMellitusPursuit.Text) && "903990".Equals(proc.ProcedureObject.SUTCode)) {
            //                                        trigliseridDiabetesMellitusPursuit.Text = proc.Result;
            //                                    }
            //                                    else if(String.IsNullOrEmpty(ldlKolDiabetesMellitusPursuit.Text) && "902290".Equals(proc.ProcedureObject.SUTCode)) {
            //                                        ldlKolDiabetesMellitusPursuit.Text = proc.Result;
            //                                    }
            //                                    else if(String.IsNullOrEmpty(hdlKolDiabetesMellitusPursuit.Text) && "901580".Equals(proc.ProcedureObject.SUTCode)) {
            //                                        hdlKolDiabetesMellitusPursuit.Text = proc.Result;
            //                                    }
            //                                    else if(String.IsNullOrEmpty(altDiabetesMellitusPursuit.Text) && "900200".Equals(proc.ProcedureObject.SUTCode)) {
            //                                        altDiabetesMellitusPursuit.Text = proc.Result;
            //                                    }
            //                                    else if(String.IsNullOrEmpty(kreatininDiabetesMellitusPursuit.Text) && "902210".Equals(proc.ProcedureObject.SUTCode)) {
            //                                        kreatininDiabetesMellitusPursuit.Text = proc.Result;
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
#endregion ParticipationFreeDrugReportNewForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region ParticipationFreeDrugReportNewForm_ClientSidePreScript
    base.ClientSidePreScript();
#endregion ParticipationFreeDrugReportNewForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ParticipationFreeDrugReportNewForm_PostScript
    base.PostScript(transDef);
            bool checkPatientApprovalFormNo = false;
            string etkinMaddeAdi = String.Empty;
            CheckParticipationFreeDrugs();

            if (this._ParticipatnFreeDrugReport.CurrentStateDefID == ParticipatnFreeDrugReport.States.New)
            {
                if (this._ParticipatnFreeDrugReport.ExamptionProtocolNo.Value == null)
                    this._ParticipatnFreeDrugReport.ExamptionProtocolNo.GetNextValue();
            }

            
            foreach (ParticipationFreeDrgGrid pd in _ParticipatnFreeDrugReport.ParticipationFreeDrugs)
            {
                CheckParticipationFreeDrugDoseContent(pd.MedulaDoseInteger);
                if(pd.EtkinMadde != null && pd.EtkinMadde.hastaGvnlikveIzlemFrmGerek.HasValue && pd.EtkinMadde.hastaGvnlikveIzlemFrmGerek.Value == true)
                {
                    checkPatientApprovalFormNo = true;
                    etkinMaddeAdi = pd.EtkinMadde.etkinMaddeAdi;
                }
            }
            
            if(String.IsNullOrEmpty(this._ParticipatnFreeDrugReport.PatientApprovalFormNo) && checkPatientApprovalFormNo)
                throw new Exception("'" + etkinMaddeAdi + "' etkin maddesi Hasta Güvenlik ve İzlem Formu gerektirir. 'Hasta Onay Form No' alanını giriniz. ");
#endregion ParticipationFreeDrugReportNewForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ParticipationFreeDrugReportNewForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef != null)
            {
                if(transDef.FromStateDefID == ParticipatnFreeDrugReport.States.Report && transDef.ToStateDefID == ParticipatnFreeDrugReport.States.New)
                {
                    if (_ParticipatnFreeDrugReport.HeadDoctorApproval == 1)
                    {
                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Rapor Medula'dan iptal edilecektir !!!. \nDevam etmek istediğinize emin misiniz?") == "H")
                            throw new TTUtils.TTException("İşlemden vazgeçildi");
                        else
                        {
                            if (_ParticipatnFreeDrugReport.MedulaReportResults.Count > 0)
                            {
                                if (_ParticipatnFreeDrugReport.MedulaReportResults[0] != null && _ParticipatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo != null)
                                {
                                    IlacRaporuServis.eraporSilIstekDVO eraporSilIstekDVO = new IlacRaporuServis.eraporSilIstekDVO();

                                    eraporSilIstekDVO.doktorTcKimlikNo = _ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString();
                                    eraporSilIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                                    eraporSilIstekDVO.raporTakipNo = _ParticipatnFreeDrugReport.MedulaReportResults[0].ReportChasingNo;

                                    _ParticipatnFreeDrugReport.ReportApprovalType = ReportApproveTypeEnum.ProcedureDoktorApprove;
                                    if (string.IsNullOrEmpty(_ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                    {
                                        TTVisual.TTForm medulaPasswordForm = new TTFormClasses.MedulaPasswordForm();
                                        TTFormClasses.ParticipationFreeDrugReportNewForm participationFreeDrugReportNewForm = new TTFormClasses.ParticipationFreeDrugReportNewForm();
                                        medulaPasswordForm.ShowEdit(participationFreeDrugReportNewForm.FindForm(), _ParticipatnFreeDrugReport, true);

                                        if (string.IsNullOrEmpty(_ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword) && string.IsNullOrEmpty(_ParticipatnFreeDrugReport.MedulaPassword))
                                        {
                                            InfoBox.Show("E-Reçete Şifreniz Boş Olamaz");
                                            return;
                                        }
                                    }

                                    string password = "";
                                    if (!string.IsNullOrEmpty(_ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword))
                                        password = _ParticipatnFreeDrugReport.ProcedureDoctor.ErecetePassword;
                                    else if (!string.IsNullOrEmpty(_ParticipatnFreeDrugReport.MedulaPassword))
                                        password = _ParticipatnFreeDrugReport.MedulaPassword;

                                    IlacRaporuServis.eraporSilCevapDVO response = IlacRaporuServis.WebMethods.eraporSil(Sites.SiteLocalHost, _ParticipatnFreeDrugReport.ProcedureDoctor.Person.UniqueRefNo.Value.ToString(), password, eraporSilIstekDVO);

                                    if (response != null)
                                    {
                                        if (response.sonucKodu != null)
                                        {
                                            if (response.sonucKodu == "0000")
                                            {
                                                TTObjectContext context = _ParticipatnFreeDrugReport.ObjectContext;
                                                MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(_ParticipatnFreeDrugReport.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                                //   MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Completed;
                                                medulaReportResult.ResultCode = response.sonucKodu;
                                                medulaReportResult.ResultExplanation = "Rapor Bilgisi Silinmiştir";
                                                medulaReportResult.ReportRowNumber = null;
                                                medulaReportResult.ReportNumber = "";
                                                medulaReportResult.ReportChasingNo = "";

                                                _ParticipatnFreeDrugReport.HeadDoctorApproval = 0;
                                                _ParticipatnFreeDrugReport.SecondDoctorApproval = 0;
                                                _ParticipatnFreeDrugReport.ThirdDoctorApproval = 0;

                                            }
                                            else
                                            {
                                                if (!string.IsNullOrEmpty(response.sonucMesaji))
                                                {
                                                    TTObjectContext context = _ParticipatnFreeDrugReport.ObjectContext;
                                                    MedulaReportResult medulaReportResult = (MedulaReportResult)context.GetObject(_ParticipatnFreeDrugReport.MedulaReportResults[0].ObjectID, typeof(MedulaReportResult));
                                                    // MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
                                                    medulaReportResult.ResultCode = response.sonucKodu;
                                                    medulaReportResult.ResultExplanation = response.sonucMesaji;
                                                    //InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                                                }
                                                throw new TTUtils.TTException("Rapor Silinemedi!!! Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                                            }
                                        }
                                        else
                                            throw new TTUtils.TTException("Rapor silinirken bir hata oluştu !!!");
                                    }

                                }
                            }
                        }
                    }
                }
                
                if((transDef.FromStateDefID == ParticipatnFreeDrugReport.States.ThirdDoctorApproval && transDef.ToStateDefID == ParticipatnFreeDrugReport.States.New) ||
                   (transDef.FromStateDefID == ParticipatnFreeDrugReport.States.SecondDoctorApproval && transDef.ToStateDefID == ParticipatnFreeDrugReport.States.New))
                {
                    if (_ParticipatnFreeDrugReport.ThirdDoctorApproval == 1 || _ParticipatnFreeDrugReport.SecondDoctorApproval == 1)
                    {
                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Raporu Medula'da onayladınız. \nİade ettiğinizde Medula onayı iptal edilmeyecektir !!!. \nDevam etmek istediğinize emin misiniz?") == "H")
                            throw new TTUtils.TTException("İşlemden vazgeçildi");
                    }
                }
                
                if (transDef.FromStateDefID == ParticipatnFreeDrugReport.States.Approval && transDef.ToStateDefID == ParticipatnFreeDrugReport.States.New)
                {
                    
                    if (_ParticipatnFreeDrugReport.HeadDoctorApproval == 1)
                    {
                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Raporu Medula'da onayladınız. \nİade ettiğinizde Medula onayı iptal edilmeyecektir !!!. \nDevam etmek istediğinize emin misiniz?") == "H")
                            throw new TTUtils.TTException("İşlemden vazgeçildi");
                    }
                }
            }
#endregion ParticipationFreeDrugReportNewForm_ClientSidePostScript

        }

#region ParticipationFreeDrugReportNewForm_Methods
        //private class TaniTeshisPair
        //{

        //    private Teshis teshis;

        //    public Teshis Teshis
        //    {
        //        get { return teshis; }
        //        set { teshis = value; }
        //    }

        //    private List<TaniListesi> tanilar;

        //    public List<TaniListesi> Tanilar
        //    {
        //        get { return tanilar; }
        //        set { tanilar = value; }
        //    }
        //}

        //private class TaniListesi
        //{
        //    private string kodu;

        //    public string Kodu
        //    {
        //        get { return kodu; }
        //        set { kodu = value; }
        //    }
        //}

        public override void SetProcedureDoctorAsCurrentResource()
        {
            if (Common.CurrentUser.IsSuperUser != true)
            {
                if (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist)
                {
                    if (this._ParticipatnFreeDrugReport.ProcedureDoctor == null)
                    {
                        this._ParticipatnFreeDrugReport.ProcedureDoctor = Common.CurrentResource;
                    }
                    //                    else
                    //                    {
                    //                        if(this._ParticipatnFreeDrugReport.ProcedureDoctor.ObjectID != Common.CurrentResource.ObjectID)
                    //                        {
                    //                            string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Hasta Muayene","İşlemin sorumlu doktoru :  "  + this._PatientExamination.ProcedureDoctor.Name + " . \r\nİşlemi yine de açmak istediğinize emin misiniz? \r\n \r\nBilgi: İşlemi açtığınızda sorumlu doktor olarak kaydedileceksiniz.");
                    //                            if(result == "E")
                    //                            {
                    //                                this._ParticipatnFreeDrugReport.ProcedureDoctor = Common.CurrentResource;
                    //                            }
                    //                        }
                    //                    }
                }
            }

            if (((ITTObject)this._ParticipatnFreeDrugReport).HasErrors == true)
                throw new Exception(((ITTObject)this._ParticipatnFreeDrugReport).GetErrors());
        }


        public void CheckParticipationFreeDrugs()
        {
            foreach (ParticipationFreeDrgGrid pd in _ParticipatnFreeDrugReport.ParticipationFreeDrugs)
            {
                if (pd.EtkinMadde == null && pd.DrugName == null)
                    throw new TTUtils.TTException("Hiçbir etkin madde seçmeden devam edemezsiniz!");
            }
        }

   

        public void CheckParticipationFreeDrugDoseContent(string dose)
        {
            char[] characters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
            if (!string.IsNullOrEmpty(dose))
            {
                foreach (Char doseCh in dose)
                {
                    bool ctrl = false;
                    foreach (Char ch in characters)
                    {
                        if (doseCh.Equals(ch))
                            ctrl = true;
                    }
                    if (ctrl == false)
                        throw new TTUtils.TTException("Doz değerine sayısal karakterler ve . haricinde giriş yapılamaz!");
                }
            }

            if (dose.Length > 5)
            {
                throw new TTUtils.TTException("Doz değerine 5 karakterden fazla giriş yapılamaz!");
            }
        }
        
#endregion ParticipationFreeDrugReportNewForm_Methods
    }
}