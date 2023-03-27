
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
    /// Oral Diagnoz ve Radyoloji
    /// </summary>
    public partial class DentalExaminationForm : BaseDentalEpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            ttbuttonPatoloji.Click += new TTControlEventDelegate(ttbuttonPatoloji_Click);
            ttbuttonBiyokimya.Click += new TTControlEventDelegate(ttbuttonBiyokimya_Click);
            ttbuttonMikrobiyoloji.Click += new TTControlEventDelegate(ttbuttonMikrobiyoloji_Click);
            ttbuttonRadyoloji.Click += new TTControlEventDelegate(ttbuttonRadyoloji_Click);
            ttbuttonTemizle.Click += new TTControlEventDelegate(ttbuttonTemizle_Click);
            ttbuttonPrescription.Click += new TTControlEventDelegate(ttbuttonPrescription_Click);
            ttbuttonTopluIslemTamamla.Click += new TTControlEventDelegate(ttbuttonTopluIslemTamamla_Click);
            ttlistviewDentalSpecialityList.DoubleClick += new TTControlEventDelegate(ttlistviewDentalSpecialityList_DoubleClick);
            ttButtonHizmetKontrol.Click += new TTControlEventDelegate(ttButtonHizmetKontrol_Click);
            ttButtonOrtodontiForm.Click += new TTControlEventDelegate(ttButtonOrtodontiForm_Click);
            ttChkBoxGeneralAnesthesia.CheckedChanged += new TTControlEventDelegate(ttChkBoxGeneralAnesthesia_CheckedChanged);
            cmbTriajCode.SelectedIndexChanged += new TTControlEventDelegate(cmbTriajCode_SelectedIndexChanged);
            TabExaminationType.SelectedTabChanged += new TTControlEventDelegate(TabExaminationType_SelectedTabChanged);
            SecDiagnosisGrid.CellContentClick += new TTGridCellEventDelegate(SecDiagnosisGrid_CellContentClick);
            DentalProsthesis.CellContentClick += new TTGridCellEventDelegate(DentalProsthesis_CellContentClick);
            DentalProsthesis.CellValueChanged += new TTGridCellEventDelegate(DentalProsthesis_CellValueChanged);
            TTListBoxDrAnesteziTescilNo.SelectedObjectChanged += new TTControlEventDelegate(TTListBoxDrAnesteziTescilNo_SelectedObjectChanged);
            ttgrid3.CellValueChanged += new TTGridCellEventDelegate(ttgrid3_CellValueChanged);
            btnNewTreatmentDischarge.Click += new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ttButtonTaahhut.Click += new TTControlEventDelegate(ttButtonTaahhut_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            ttbuttonPatoloji.Click -= new TTControlEventDelegate(ttbuttonPatoloji_Click);
            ttbuttonBiyokimya.Click -= new TTControlEventDelegate(ttbuttonBiyokimya_Click);
            ttbuttonMikrobiyoloji.Click -= new TTControlEventDelegate(ttbuttonMikrobiyoloji_Click);
            ttbuttonRadyoloji.Click -= new TTControlEventDelegate(ttbuttonRadyoloji_Click);
            ttbuttonTemizle.Click -= new TTControlEventDelegate(ttbuttonTemizle_Click);
            ttbuttonPrescription.Click -= new TTControlEventDelegate(ttbuttonPrescription_Click);
            ttbuttonTopluIslemTamamla.Click -= new TTControlEventDelegate(ttbuttonTopluIslemTamamla_Click);
            ttlistviewDentalSpecialityList.DoubleClick -= new TTControlEventDelegate(ttlistviewDentalSpecialityList_DoubleClick);
            ttButtonHizmetKontrol.Click -= new TTControlEventDelegate(ttButtonHizmetKontrol_Click);
            ttButtonOrtodontiForm.Click -= new TTControlEventDelegate(ttButtonOrtodontiForm_Click);
            ttChkBoxGeneralAnesthesia.CheckedChanged -= new TTControlEventDelegate(ttChkBoxGeneralAnesthesia_CheckedChanged);
            cmbTriajCode.SelectedIndexChanged -= new TTControlEventDelegate(cmbTriajCode_SelectedIndexChanged);
            TabExaminationType.SelectedTabChanged -= new TTControlEventDelegate(TabExaminationType_SelectedTabChanged);
            SecDiagnosisGrid.CellContentClick -= new TTGridCellEventDelegate(SecDiagnosisGrid_CellContentClick);
            DentalProsthesis.CellContentClick -= new TTGridCellEventDelegate(DentalProsthesis_CellContentClick);
            DentalProsthesis.CellValueChanged -= new TTGridCellEventDelegate(DentalProsthesis_CellValueChanged);
            TTListBoxDrAnesteziTescilNo.SelectedObjectChanged -= new TTControlEventDelegate(TTListBoxDrAnesteziTescilNo_SelectedObjectChanged);
            ttgrid3.CellValueChanged -= new TTGridCellEventDelegate(ttgrid3_CellValueChanged);
            btnNewTreatmentDischarge.Click -= new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ttButtonTaahhut.Click -= new TTControlEventDelegate(ttButtonTaahhut_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton3_Click()
        {
#region DentalExaminationForm_ttbutton3_Click
   StringBuilder sb = new StringBuilder("");
            getSelectedToothNumbers(sb, this.Controls);
            
            if ("".Equals(sb.ToString()))
            {
                InfoBox.Show("Diş seçimi yapmadan hastayı sıraya alamazsınız!");
                return;
            }
            if (  this._DentalExamination.CurrentStateDefID == TTObjectClasses.DentalExamination.States.OrderedPatient)
            {
                InfoBox.Show("Hasta önceden sıraya alınmıştır, tekrar sıraya alamazsınız!");
                return;
            }
            TTObjectContext context = new TTObjectContext(false);
            TTObjectClasses.DentalQueue dq = new TTObjectClasses.DentalQueue(context);
            dq.CurrentStateDefID = TTObjectClasses.DentalQueue.States.New;
            dq.DentalExamination = this._DentalExamination;
            dq.Patient = this._DentalExamination.Episode.Patient;
            dq.Description = "Ad Soyad: " + dq.Patient.FullName  + "\n" + "Doğum tarihi: " + dq.Patient.BirthDate.Value.ToLongDateString() + "\n" +
                "Adres: " + dq.Patient.PatientAddress.HomeAddress;
            dq.ToothNumbers = sb.ToString();
            TTForm theForm = TTForm.GetEditForm(dq);
            theForm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            theForm.GetTemplates = this.GetTemplates;
            theForm.SaveTemplate = this.SaveTemplate;
            theForm.TemplateSelected = this.TemplateSelected;
            if (theForm.ShowEdit(this.FindForm(), dq) == DialogResult.OK) {
                //this._DentalExamination.CurrentStateDefID = TTObjectClasses.DentalExamination.States.Completed;
                String examinationText  = null;
                if (this.DentalExaminationFile1.Rtf != null)
                    examinationText = Common.GetTextOfRTFString(this.DentalExaminationFile1.Rtf);
                if (examinationText == null)
                    examinationText = "";
                if (examinationText != null && !"".Equals(examinationText))
                      examinationText += "\n ";
                examinationText += "Hasta " + Common.RecTime().Date.ToShortDateString() + " tarihinde sıraya alındı";
                this.DentalExaminationFile1.Rtf = Common.GetRTFOfTextString(examinationText);
                context.Save();
                InfoBox.Show("Hasta başarıyla sıraya alındı.", MessageIconEnum.InformationMessage);
                //ttbuttonTemizle_Click();
                //ttgrid3.Rows.Clear();
                TTObjectStateTransitionDef transDef = (TTObjectStateTransitionDef)this._EpisodeAction.CurrentStateDef.FindOutoingTransitionDefFromStateDefID(TTObjectClasses.DentalExamination.States.Completed);
                if(DoContextUpdate(transDef))
                    this.DialogResult = DialogResult.OK;
            }
#endregion DentalExaminationForm_ttbutton3_Click
        }

        private void ttbuttonPatoloji_Click()
        {
#region DentalExaminationForm_ttbuttonPatoloji_Click
   CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyRequest)), null);
#endregion DentalExaminationForm_ttbuttonPatoloji_Click
        }

        private void ttbuttonBiyokimya_Click()
        {
#region DentalExaminationForm_ttbuttonBiyokimya_Click
   Guid microBiologyGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("BIYOKIMYAMAINRESGUID", Guid.Empty.ToString()));

            ResLaboratoryDepartment labDep = (ResLaboratoryDepartment)_DentalExamination.ObjectContext.GetObject(microBiologyGuid, TTObjectDefManager.Instance.ObjectDefs[typeof(ResLaboratoryDepartment).Name], false);
            if (labDep == null)
                CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), null);
            else
                CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), labDep.ObjectID);
#endregion DentalExaminationForm_ttbuttonBiyokimya_Click
        }

        private void ttbuttonMikrobiyoloji_Click()
        {
#region DentalExaminationForm_ttbuttonMikrobiyoloji_Click
   Guid microBiologyGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("MIKROBIYOLOJIMAINRESGUID", Guid.Empty.ToString()));

            ResLaboratoryDepartment labDep = (ResLaboratoryDepartment)_DentalExamination.ObjectContext.GetObject(microBiologyGuid, TTObjectDefManager.Instance.ObjectDefs[typeof(ResLaboratoryDepartment).Name], false);
            if (labDep == null)
                CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), null);
            else
                CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)), labDep.ObjectID);
#endregion DentalExaminationForm_ttbuttonMikrobiyoloji_Click
        }

        private void ttbuttonRadyoloji_Click()
        {
#region DentalExaminationForm_ttbuttonRadyoloji_Click
   CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof(Radiology)), null);
#endregion DentalExaminationForm_ttbuttonRadyoloji_Click
        }

        private void ttbuttonTemizle_Click()
        {
#region DentalExaminationForm_ttbuttonTemizle_Click
   //this.TTListBoxProc.SelectedObject = null;
            this.DentalProcessNew.Rows.Clear();
            foreach (TTCheckBox tempChkbox in selectedCheckboxes)
            {
                tempChkbox.Checked = false;
            }
            selectedCheckboxes.Clear();
#endregion DentalExaminationForm_ttbuttonTemizle_Click
        }

        private void ttbuttonPrescription_Click()
        {
#region DentalExaminationForm_ttbuttonPrescription_Click
   this.CreateNewOutPatientPrescriptionn();
#endregion DentalExaminationForm_ttbuttonPrescription_Click
        }

        private void ttbuttonTopluIslemTamamla_Click()
        {
#region DentalExaminationForm_ttbuttonTopluIslemTamamla_Click
   if (this.DentalProcessNew.Rows.Count == 0 )
            {
                InfoBox.Show("Toplu işlem girişi için en az 1 diş ve en az 1 diş ya da protez işlemi seçmelisiniz.", MessageIconEnum.ErrorMessage);
            }            
            addDentalProsthesisRows(this.Controls);
            if (this.DentalProsthesis.Rows.Count == 0  && this.ttgrid3.Rows.Count == 0)
            {
                InfoBox.Show("Toplu işlem girişi için en az 1 diş ve en az 1 diş ya da protez işlemi seçmelisiniz.", MessageIconEnum.ErrorMessage);
            }
            else
            {
                paintRows();
                ttbuttonTemizle_Click();
            }
#endregion DentalExaminationForm_ttbuttonTopluIslemTamamla_Click
        }

        private void ttlistviewDentalSpecialityList_DoubleClick()
        {
#region DentalExaminationForm_ttlistviewDentalSpecialityList_DoubleClick
   StringBuilder istekAciklama = new StringBuilder();
            try
            {
                addDentalConsultationRows(this.Controls, istekAciklama);
            }
            catch (Exception e)
            {
                this.DentalConsultation.Rows.Clear();
                InfoBox.Show("Diş seçilirken bir hata oluştu!");
            }
            if (istekAciklama == null || "".Equals(istekAciklama.ToString()) || istekAciklama.Length == 0)
            {
                InfoBox.Show("Diş seçiniz!");
                return;
            }
            try
            {
                foreach (ITTListViewItem tempItem in this.ttlistviewDentalSpecialityList.SelectedItems)
                {
                    ITTGridRow newRow = this.DentalConsultation.Rows.Add();
                    TTObjectContext context = new TTObjectContext(false);
                    BindingList<ResSection> resSectionList = ResPoliclinic.GetBySpeciality(context, SpecialityDefinition.GetSpecialityByCode(context, tempItem.Name)[0].ObjectID);
                    if (resSectionList != null && resSectionList.Count > 0)
                    foreach (ResSection rs in resSectionList)
                    {
                        if (rs.GetType() == typeof(TTObjectClasses.ResPoliclinic))
                        {
                            newRow.Cells[0].Value = rs.ObjectID;
                            break;
                        }
                    }
                    if (newRow.Cells[0].Value == null) {
                        throw new Exception("İlgili poliklinik sistemde kayıtlı değil!");
                    }
                    String istekAciklamaStr = istekAciklama.ToString();
                    newRow.Cells[1].Value = istekAciklamaStr.Substring(0, istekAciklamaStr.Length - 1) + " numaralı dişler " + tempItem.Text + " branşına " + Common.RecTime() + " tarihinde yönlendirilmiştir.";
                    newRow.Cells[2].Value = istekAciklamaStr.Substring(0, istekAciklamaStr.Length - 1);
                    disMuayene += newRow.Cells[1].Value + "\n";
                }
                this.ttlistviewDentalSpecialityList.SelectedItems.Clear();
                foreach (TTCheckBox tempChkbox in selectedCheckboxes)
                {
                    tempChkbox.Checked = false;
                }
                selectedCheckboxes.Clear();
            }
            catch (Exception e)
            {
                this.DentalConsultation.Rows.Clear();
                InfoBox.Show("İlgili poliklinik sistem kayıtlı değil!");
            }
#endregion DentalExaminationForm_ttlistviewDentalSpecialityList_DoubleClick
        }

        private void ttButtonHizmetKontrol_Click()
        {
#region DentalExaminationForm_ttButtonHizmetKontrol_Click
   fireMustehaklikKontrol(null);
#endregion DentalExaminationForm_ttButtonHizmetKontrol_Click
        }

        private void ttButtonOrtodontiForm_Click()
        {
#region DentalExaminationForm_ttButtonOrtodontiForm_Click
   MedulaOrtodontiIslemleri medulaOrtodontiIslemleri = new MedulaOrtodontiIslemleri(this._EpisodeAction.GetCurrentAction().Episode.Patient);
            medulaOrtodontiIslemleri.Show();
#endregion DentalExaminationForm_ttButtonOrtodontiForm_Click
        }

        private void ttChkBoxGeneralAnesthesia_CheckedChanged()
        {
#region DentalExaminationForm_ttChkBoxGeneralAnesthesia_CheckedChanged
   if (ttChkBoxGeneralAnesthesia.Value.HasValue && ttChkBoxGeneralAnesthesia.Value.Value)
            {
                TTObjectContext context = new TTObjectContext(true);
                BindingList<OzelDurum> oList = TTObjectClasses.OzelDurum.GetOzelDurumByKod(context, "Y");
                if (oList.Count > 0)
                    this._DentalExamination.OzelDurum = oList[0];
                context.Dispose();
            }
            else
            {
                if (this._DentalExamination.OzelDurum != null && this._DentalExamination.OzelDurum.ozelDurumKodu == "Y")
                {
                    this._DentalExamination.OzelDurum = null;
                }
            }
#endregion DentalExaminationForm_ttChkBoxGeneralAnesthesia_CheckedChanged
        }

        private void cmbTriajCode_SelectedIndexChanged()
        {
#region DentalExaminationForm_cmbTriajCode_SelectedIndexChanged
   if (((TTVisual.TTComboBoxItem)(((TTEnumComboBox)cmbTriajCode).SelectedItem)).Value != null)
            {
                TriajCode result = (TriajCode)((TTVisual.TTComboBoxItem)(((TTEnumComboBox)cmbTriajCode).SelectedItem)).Value;
                switch (result)
                {
                    case TriajCode.Red:
                        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Red;
                        break;
                    case TriajCode.Yellow:
                        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Yellow;
                        break;
                    case TriajCode.Green:
                        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Green;
                        break;

                    default: ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Transparent;
                        break;
                }
            }
            else
            {
                ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.White;
            }
#endregion DentalExaminationForm_cmbTriajCode_SelectedIndexChanged
        }

        private void TabExaminationType_SelectedTabChanged()
        {
#region DentalExaminationForm_TabExaminationType_SelectedTabChanged
   switch (TabExaminationType.SelectedTab.Name)
            {
                case "OlduExaminations":
                    if (!OldDentalExaminationsGridFilled)
                    {
                        FillDentalExaminationFile1Grid(this.OldDentalExaminationsGrid);
                        OldDentalExaminationsGridFilled = true;
                    }
                    break;
                default:
                    break;

            }
#endregion DentalExaminationForm_TabExaminationType_SelectedTabChanged
        }

        private void SecDiagnosisGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalExaminationForm_SecDiagnosisGrid_CellContentClick
   /* if (this.SecDiagnosisGrid.CurrentCell.OwningColumn.Name.Equals(ToothSchemaButton.Name))
                this.SecDiagnosisGrid.ShowTTObject(rowIndex, false);*/
#endregion DentalExaminationForm_SecDiagnosisGrid_CellContentClick
        }

        private void DentalProsthesis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalExaminationForm_DentalProsthesis_CellContentClick
   /* if (this.DentalProsthesis.CurrentCell.OwningColumn.Name.Equals(ProcedureToothSchema.Name))
                this.DentalProsthesis.ShowTTObject(rowIndex, false); */

            SubActionProcedure procedure = (SubActionProcedure)DentalProsthesis.CurrentCell.OwningRow.TTObject;
            // MT Çoklu özel durum düğmesi basılınca Çoklu özel durum formu açılır.
            if (((ITTGridCell)DentalProsthesis.CurrentCell).OwningColumn.Name == "CokluOzelDurum")
            {
                DentalProcedure_CokluOzelDurumForm dpcodf = new DentalProcedure_CokluOzelDurumForm();
                dpcodf.ShowEdit(this.FindForm(), procedure, true);
            }
            if (((ITTGridCell)DentalProsthesis.CurrentCell).OwningColumn.Name == "Mustehaklik")
            {
                fireMustehaklikKontrol(((ITTGridCell)DentalProsthesis.CurrentCell).OwningRow);
            }
#endregion DentalExaminationForm_DentalProsthesis_CellContentClick
        }

        private void DentalProsthesis_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalExaminationForm_DentalProsthesis_CellValueChanged
   if (this.DentalProsthesis.CurrentCell != null && this.DentalProsthesis.CurrentCell.OwningColumn != null)
            {
                if (this.DentalProsthesis.CurrentCell.OwningColumn.Name == "ProcedureObject" || this.DentalProsthesis.CurrentCell.OwningColumn.Name == "columnHastaOdeme")
                {
                    if (rowIndex < this.DentalProsthesis.Rows.Count && rowIndex > -1)
                    {
                        TTObjectClasses.DentalProcedure dentalProcedure = (TTObjectClasses.DentalProcedure)this.DentalProsthesis.CurrentCell.OwningRow.TTObject;
                        if (dentalProcedure.ProcedureObject != null)
                        {
                            if (this.DentalProsthesis.CurrentCell.OwningColumn.Name == "ProcedureObject")
                            {
                                if (dentalProcedure.ProcedureObject.GetType() == typeof(DentalTreatmentDefinition))
                                {
                                    DentalTreatmentDefinition treatmentDef = (DentalTreatmentDefinition)dentalProcedure.ProcedureObject;
                                    dentalProcedure.ToothNumber = treatmentDef.ToothNumber;
                                }
                                else if (dentalProcedure.ProcedureObject.GetType() == typeof(DentalProsthesisDefinition))
                                {
                                    //TODO Protezlerede diş tanımı yapılırsa açılacak
                                    //DentalProsthesisDefinition treatmentDef = (DentalProsthesisDefinition)dentalProcedure.ProcedureObject;
                                    // dentalProcedure.ToothNumber = treatmentDef.ToothNumber;
                                    dentalProcedure.ToothNumber = null;
                                }
                            }
                            
                            if (dentalProcedure.PatientPay.HasValue && dentalProcedure.PatientPay.Value == true)
                            {
                                IList pricingListDefinitions = null;
                                ArrayList pricingDetailList = new ArrayList();
                                dentalProcedure.PatientPrice = GetPatientPrice(dentalProcedure.ProcedureObject, false);
                                if(TTObjectClasses.SystemParameter.GetParameterValue("UNIVERSITEXXXXXX","FALSE") == "TRUE")   //Universite XXXXXX
                                {
                                    pricingListDefinitions = PricingListDefinition.GetByCode(dentalProcedure.ObjectContext, "6");
                                }
                                else if(TTObjectClasses.SystemParameter.GetParameterValue("UNIVERSITEXXXXXX","FALSE") == "FALSE")   // değil
                                {
                                    pricingListDefinitions = PricingListDefinition.GetByCode(dentalProcedure.ObjectContext, "5");
                                }
                                
                                if(pricingListDefinitions.Count > 0)
                                {
                                    PricingListDefinition pld = (PricingListDefinition)pricingListDefinitions[0];
                                    ProcedureDefinition pd = (ProcedureDefinition) dentalProcedure.ProcedureObject;
                                    pricingDetailList = pd.GetProcedurePricingDetail(pld,DateTime.Now);
                                    if(pricingDetailList.Count > 0)
                                    {
                                        dentalProcedure.PatientPrice = ((PricingDetailDefinition)pricingDetailList[0]).Price;
                                    }
                                    else
                                    {
                                        dentalProcedure.PatientPrice = 2 * dentalProcedure.PatientPrice;
                                    }
                                }
                                
                            }
                            else
                                dentalProcedure.PatientPrice = GetPatientPrice(dentalProcedure.ProcedureObject, true);
                        }
                    }
                }
            }
#endregion DentalExaminationForm_DentalProsthesis_CellValueChanged
        }

        private void TTListBoxDrAnesteziTescilNo_SelectedObjectChanged()
        {
#region DentalExaminationForm_TTListBoxDrAnesteziTescilNo_SelectedObjectChanged
   if (this.TTListBoxDrAnesteziTescilNo.SelectedObject != null)
            {
                ResUser resUser = (ResUser)this.TTListBoxDrAnesteziTescilNo.SelectedObject;
                _DentalExamination.DrAnesteziTescilNo = (resUser.DiplomaRegisterNo == null) ? null : resUser.DiplomaRegisterNo.ToString();
                //_DentalExamination.DrAnesteziTescilNo = _DentalExamination.ResUser.DiplomaRegisterNo.ToString();
            }
#endregion DentalExaminationForm_TTListBoxDrAnesteziTescilNo_SelectedObjectChanged
        }

        private void ttgrid3_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalExaminationForm_ttgrid3_CellValueChanged
   if(this.ttgrid3.CurrentCell.OwningColumn.Name == "SUGGESTEDPROSTHESISPROCEDURE")
            {
                if (rowIndex < this.ttgrid3.Rows.Count && rowIndex > -1)
                {
                    DentalProsthesisRequestSuggestedProsthesis sugPro = (DentalProsthesisRequestSuggestedProsthesis)((ITTGridRow)ttgrid3.Rows[rowIndex]).TTObject;
                    if(sugPro.SuggestedProsthesisProcedure!=null)
                    {
                        if(((DentalProsthesisDefinition)sugPro.SuggestedProsthesisProcedure).Departments.Count > 0)
                        {
                            sugPro.Department=((DentalProsthesisDepartmentGrid)((DentalProsthesisDefinition)sugPro.SuggestedProsthesisProcedure).Departments[0]).Department;
                        }
                    }
                }
            }
#endregion DentalExaminationForm_ttgrid3_CellValueChanged
        }

        private void btnNewTreatmentDischarge_Click()
        {
#region DentalExaminationForm_btnNewTreatmentDischarge_Click
   CreateNewTreatmentDischarge();
#endregion DentalExaminationForm_btnNewTreatmentDischarge_Click
        }

        private void ttButtonTaahhut_Click()
        {
#region DentalExaminationForm_ttButtonTaahhut_Click
   MedulaDisTaahhutIslemleri medulaTaahhutIslemleri = new MedulaDisTaahhutIslemleri(this._EpisodeAction.GetCurrentAction().Episode.Patient);
            medulaTaahhutIslemleri.Show();
#endregion DentalExaminationForm_ttButtonTaahhut_Click
        }

        protected override void PreScript()
        {
#region DentalExaminationForm_PreScript
    base.PreScript();
            this.DropStateButton(TTObjectClasses.DentalExamination.States.OrderedPatient);
            TTListViewItem item = new TTListViewItem();
            item.Text = "Oral Diagnoz";
            item.Name = "5600";
            this.ttlistviewDentalSpecialityList.Items.Add(item);
            item = new TTListViewItem();
            item.Text = "Tedavi";
            item.Name = "5700";
            this.ttlistviewDentalSpecialityList.Items.Add(item);
            item = new TTListViewItem();
            item.Text = "Periodontoloji";
            item.Name = "5500";
            this.ttlistviewDentalSpecialityList.Items.Add(item);
            item = new TTListViewItem();
            item.Text = "Cerrahi";
            item.Name = "5100";
            this.ttlistviewDentalSpecialityList.Items.Add(item);
            item = new TTListViewItem();
            item.Text = "Pedodonti";
            item.Name = "5300";
            this.ttlistviewDentalSpecialityList.Items.Add(item);
            item = new TTListViewItem();
            item.Text = "Ortodonti";
            item.Name = "5200";
            this.ttlistviewDentalSpecialityList.Items.Add(item);
            item = new TTListViewItem();
            item.Text = "Protez";
            item.Name = "5400";
            this.ttlistviewDentalSpecialityList.Items.Add(item);             
            item = new TTListViewItem();
            item.Text = "Endodonti";
            item.Name = "5150";
            this.ttlistviewDentalSpecialityList.Items.Add(item);

            Button b = (Button)this.ttbuttonRadyoloji;
            b.ImageAlign = ContentAlignment.MiddleLeft;
            b.TextAlign = ContentAlignment.MiddleRight;
            b.Image = (Image)TTUtils.Deserialize.StringToObject(RadyolojiIMG);

            b = (Button)this.ttbuttonBiyokimya;
            b.ImageAlign = ContentAlignment.MiddleLeft;
            b.TextAlign = ContentAlignment.MiddleRight;
            b.Image = (Image)TTUtils.Deserialize.StringToObject(BiyokimyaIMG);

            b = (Button)this.ttbuttonMikrobiyoloji;
            b.ImageAlign = ContentAlignment.MiddleLeft;
            b.TextAlign = ContentAlignment.MiddleRight;
            b.Image = (Image)TTUtils.Deserialize.StringToObject(MikrobiyolojiIMG);

            b = (Button)this.ttbuttonPatoloji;
            b.ImageAlign = ContentAlignment.MiddleLeft;
            b.TextAlign = ContentAlignment.MiddleRight;
            b.Image = (Image)TTUtils.Deserialize.StringToObject(PatolojiIMG);

            this.SetProcedureDoctorAsCurrentResource();

            this.SetTreatmentMaterialListFilter(this._DentalExamination.ObjectDef, (ITTGridColumn)this.UsedMaterials.Columns["Material"]);
            if (this._DentalExamination.SubEpisode.PatientAdmission.AdmissionType.Equals(13))
            {
                ((TTCheckBox)Emergency).Checked = true;
                Emergency.ReadOnly = true;
                cmbTriajCode.Visible = true;
                TriajColor.Visible = true;
                labelTriajCode.Visible = true;
                cmbTriajCode.Required = true;
            }
            else
            {
                ((TTCheckBox)Emergency).Enabled = false;
                Emergency.ReadOnly = true;
                cmbTriajCode.Visible = false;
                TriajColor.Visible = false;
                labelTriajCode.Visible = false;
            }

            if (TTObjectClasses.SystemParameter.GetParameterValue("ISENTEGRATEDTODENTALINE", "FALSE") == "TRUE")
            {
                this.DropStateButton(DentalExamination.States.Completed);
                this.DropStateButton(DentalExamination.States.Cancelled);
                this.DropStateButton(DentalExamination.States.PatientNoShown);
                panelTooth.ReadOnly = true;
                DentalProsthesis.ReadOnly = true;
                //PreDiagnosisGrid.ReadOnly = true;
                SecDiagnosisGrid.ReadOnly = true;
                int removedTabCount = 0;
                if (this.TabExaminationType.TabPages.Contains(this.Examination))
                {
                    this.TabExaminationType.TabPages.RemoveAt(this.Examination.DisplayIndex - removedTabCount);
                    removedTabCount++;
                }
            }

            TTObjectContext context = new TTObjectContext(false);
            // BindingList<ProcedureDefinition> islemList = ProcedureDefinition.GetAllProcedureDefinitions(context, null);
            paintRows();

            foreach (ITTGridRow tempRow in this.DentalConsultation.Rows)
            {
                try
                {
                    tempRow.Cells[1].Value = Common.GetTextOfRTFString(tempRow.Cells[1].Value.ToString());
                }
                catch (Exception e)
                {
                    //TODO
                }
            }
            
            try {
                if (this.DentalExaminationFile1 != null && this.DentalExaminationFile1.Text != null) {
                    this.DentalExaminationFile1.Rtf = Common.GetRTFOfTextString(this.DentalExaminationFile1.Text);
                    if (this._DentalExamination.DentalExaminationFile != null)
                        this._DentalExamination.DentalExaminationFile =  this.DentalExaminationFile1.Rtf;
                }
            } catch(Exception e) {
                //TODO
            }
            
            if(this._DentalExamination.CurrentStateDef.Status != StateStatusEnum.Uncompleted)
            {
                
                foreach (Control control in this.pnlControls.Controls)
                {
                    if(control is TTButton)
                        control.Enabled = false;
                }
            }
            
            if(this._DentalExamination.CurrentStateDefID == DentalExamination.States.Examination)
                this.DropStateButton(DentalExamination.States.PatientNoShown);
#endregion DentalExaminationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalExaminationForm_PostScript
    base.PostScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID.Equals(DentalExamination.States.PatientNoShown))
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hasta Gelmedi Butonuna Bastınız", "Hasta gelmedi butonuna bastınız. Diş Muayene işlemi geri alınmamak üzere kapatılacaktır.\r\n İşleme devam etmek ister misiniz? ");
                    if (result == "H")
                    {
                        throw new Exception(SystemMessage.GetMessage(80));
                    }
                }
            }

            if (transDef != null && transDef.ToStateDefID != DentalExamination.States.PatientNoShown && transDef.ToStateDefID != DentalExamination.States.Cancelled)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("ISENTEGRATEDTODENTALINE", "FALSE") != "TRUE")
                {
                    if (_DentalExamination.Diagnosis.Count == 0)
                        throw new Exception(SystemMessage.GetMessage(635));
                }
            }


            if (transDef == null || ((transDef != null) && (transDef.ToStateDefID == DentalExamination.States.Completed)))
            {
                foreach(DentalExaminationProcedure dentalExaminationProcedure in this._DentalExamination.DentalExaminationProcedures)
                {
                    dentalExaminationProcedure.SetPerformedDate();
                }
            }
            
            if (transDef == null || (transDef != null && (transDef.ToStateDefID == DentalExamination.States.Completed || transDef.ToStateDefID == TTObjectClasses.DentalConsultation.States.Completed)))
            {
                this.CompleteMyExaminationQueueItems();
                String examinationRtf = "";
                foreach (TTObjectClasses.DentalProcedure dp in _DentalExamination.DentalProcedures)
                {
                    IList pricingListDefinitions = null;
                    ArrayList pricingDetailList = new ArrayList();
                    if(TTObjectClasses.SystemParameter.GetParameterValue("UNIVERSITEXXXXXX","FALSE") == "TRUE")   //Universite XXXXXX
                    {
                        pricingListDefinitions = PricingListDefinition.GetByCode(dp.ObjectContext, "6");
                    }
                    else if(TTObjectClasses.SystemParameter.GetParameterValue("UNIVERSITEXXXXXX","FALSE") == "FALSE")
                    {
                        pricingListDefinitions = PricingListDefinition.GetByCode(dp.ObjectContext, "5");
                    }
                    dp.AccountOperation(AccountOperationTimeEnum.PREPOST);
                    if (dp.PatientPay != null && dp.PatientPay.Value == true)
                    {
                        int payer = 0;
                        int patient = 1;
                        if(pricingListDefinitions.Count > 0)
                        {
                            PricingListDefinition pld = (PricingListDefinition)pricingListDefinitions[0];
                            ProcedureDefinition pd = (ProcedureDefinition) dp.ProcedureObject;
                            pricingDetailList = pd.GetProcedurePricingDetail(pld,DateTime.Now);
                            if(pricingDetailList.Count > 0)
                            {
                                //dp.TurnMyAccTrxsToPatientOrPayerShare((PricingDetailDefinition)pricingDetailList[0],payer,patient);
                            }
                            else if(pricingDetailList.Count == 0)
                            {
                                PricingListDefinition SUTPriceList = (PricingListDefinition)PricingListDefinition.GetByObjectID(_DentalExamination.ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("SUTPRICELISTOBJECTID", "").ToString())[0];
                                pricingDetailList = pd.GetProcedurePricingDetail(SUTPriceList,DateTime.Now);
                               // dp.TurnMyAccTrxsToPatientOrPayerShare((PricingDetailDefinition)pricingDetailList[0],payer,patient);
                            }
                            
                        }
                        
                        //dp.TurnMyAccountTransactionsToPatientShare(false);
                        
                    }
                    else
                    {
                        int payer = 1;
                        int patient = 0;
                        PricingListDefinition SUTPriceList = (PricingListDefinition)PricingListDefinition.GetByObjectID(_DentalExamination.ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("SUTPRICELISTOBJECTID", "").ToString())[0];
                        ProcedureDefinition pd = (ProcedureDefinition) dp.ProcedureObject;
                        pricingDetailList = pd.GetProcedurePricingDetail(SUTPriceList,DateTime.Now);
                        //dp.TurnMyAccTrxsToPatientOrPayerShare((PricingDetailDefinition)pricingDetailList[0],payer,patient);
                    }
                    String disNo = "";
                    foreach (ITTGridRow row in DentalProsthesis.Rows)
                    {
                        if (((TTObjectClasses.DentalProcedure)row.TTObject).Equals(dp))
                        {
                            disNo = row.Cells[4].Value.ToString();
                            break;
                        }
                    }

                    examinationRtf = Common.GetTextOfRTFString(this.DentalExaminationFile1.Rtf);
                    String examinationText = dp.ProcedureObject.Code + "-" + dp.ProcedureObject.Description + " işlemi " + Common.RecTime().Date.ToShortDateString() + " tarihinde " + disNo + " dişine yapılmıştır.\n";

                    if (!examinationRtf.Contains(examinationText))
                    {
                        examinationRtf += examinationText;
                        this.DentalExaminationFile1.Rtf = Common.GetRTFOfTextString(examinationRtf);
                    }
                }
                
                // Kaydet ve Tamamla yapıldığında Sarf Malzemelerin ücretlenmesi için
                foreach(BaseTreatmentMaterial treatmentMaterial in _DentalExamination.TreatmentMaterials)
                    treatmentMaterial.AccountOperation(AccountOperationTimeEnum.PREPOST);
                foreach(DentalConsultationRequest dentalConsRequest in this._DentalExamination.DentalConsultationRequest)
                {
                    if(dentalConsRequest.CurrentStateDefID == DentalConsultationRequest.States.Request)
                    {
                        dentalConsRequest.MasterResource = dentalConsRequest.ConsultationDepartment;
                        dentalConsRequest.FromResource = this._DentalExamination.MasterResource;
                        dentalConsRequest.Episode = dentalConsRequest.DentalExamination.Episode;
                        dentalConsRequest.DescriptionForWorkList = dentalConsRequest.RequestDescription;
                        dentalConsRequest.RequestDescription = Common.GetRTFOfTextString(dentalConsRequest.RequestDescription);
                        dentalConsRequest.ResUser = this._DentalExamination.ProcedureDoctor;
                        
                        bool isInsertedBefore = false;
                        foreach (DentalConsultationDepartment deptemp in dentalConsRequest.Department)
                        {
                            if (deptemp.ResSection.Equals(dentalConsRequest.ConsultationDepartment))
                            {
                                isInsertedBefore = true;
                                break;
                            }
                        }
                        if (!isInsertedBefore)
                        {
                            DentalConsultationDepartment dep = new DentalConsultationDepartment(this._DentalExamination.ObjectContext);
                            dep.ResSection = dentalConsRequest.ConsultationDepartment;
                            dep.DentalConsultationRequest = dentalConsRequest;
                            //newConsultationRequest.Department.Add(dep);
                        }
                        //objenin preUpdate ine taşındı.
                        // dentalConsRequest.CurrentStateDefID = DentalConsultationRequest.States.Completed;
                    }
                    
                }
                
                if ("".Equals(examinationRtf))
                    examinationRtf = Common.GetTextOfRTFString(this.DentalExaminationFile1.Rtf);
                if (!examinationRtf.Contains(disMuayene))
                {
                    examinationRtf += disMuayene;
                    this.DentalExaminationFile1.Rtf = Common.GetRTFOfTextString(examinationRtf);
                }
                /*if (ttgrid3.Rows != null && ttgrid3.Rows.Count > 0) {
                    if (this._DentalExamination.Laboratory == null || this._DentalExamination.Laboratory.Count == 0) {
                        DentalLaboratoryProcedure dentalLab = new DentalLaboratoryProcedure(this._DentalExamination.ObjectContext,this._DentalExamination);
                        foreach(DentalExaminationSuggestedProsthesis sp in this._DentalExamination.SuggestedProsthesis) {
                            sp.DentalLaboratoryProcedure = dentalLab;
                            //protez işlemi oluşturmak için eklenmişti. Ancak muayene içinden istendiği için kaldırıldı.
                            //DentalLaboratoryProcedureProthesis dentalLaboratoryProcedureProthesis = new DentalLaboratoryProcedureProthesis(this._DentalExamination.ObjectContext,dentalLab,sp);
                        }
                    }
                    else {
                        DentalLaboratoryProcedure dentalLab = this._DentalExamination.Laboratory[0];
                        if (dentalLab.CurrentStateDefID == DentalLaboratoryProcedure.States.Completed){
                            InfoBox.Show("Laboratuvar işlemi tamamlandı durumunda olduğundan değişiklik yapamazsınız, önce laboratuvar işlemini yeni adımına geçiriniz.");
                            return;
                        }
                        foreach(DentalExaminationSuggestedProsthesis sp in this._DentalExamination.SuggestedProsthesis) {
                            if(sp.DentalLaboratoryProcedure == null)
                            {
                                sp.DentalLaboratoryProcedure = dentalLab;
                                //protez işlemi oluşturmak için eklenmişti. Ancak muayene içinden istendiği için kaldırıldı.
                                //DentalLaboratoryProcedureProthesis dentalLaboratoryProcedureProthesis = new DentalLaboratoryProcedureProthesis(this._DentalExamination.ObjectContext,dentalLab,sp);
                            }
                        }
                    }
                }
                else  if (this._DentalExamination.Laboratory != null && this._DentalExamination.Laboratory.Count > 0) {
                    //DentalLaboratoryProcedure dentalLab = this._DentalExamination.Laboratory[0];
                    //dentalLab.CurrentStateDefID = DentalLaboratoryProcedure.States.Cancelled;
                }*/
                
                
                
                bool found;
                foreach(DentalExaminationSuggestedProsthesis sp in this._DentalExamination.SuggestedProsthesis)
                {
                    found = false;
                    if(sp.DentalLaboratoryProcedure == null && sp.Department != null)
                    {
                        foreach(DentalLaboratoryProcedure dp in this._DentalExamination.Laboratory)
                        {
                            if(dp.MasterResource.ObjectID == sp.Department.ObjectID)
                            {
                                if(dp.CurrentStateDefID != DentalLaboratoryProcedure.States.Completed)
                                {
                                    sp.DentalLaboratoryProcedure = dp;
                                    found = true;
                                    break;
                                }
                                else
                                {
                                    InfoBox.Show(dp.MasterResource.Name + " birimine ait Laboratuvar işlemi tamamlandı durumunda olduğundan değişiklik yapamazsınız, önce laboratuvar işlemini yeni adımına geçiriniz.");
                                    return;
                                }
                            }
                        }
                        if (!found)
                        {
                            DentalLaboratoryProcedure dentalLab = new DentalLaboratoryProcedure(this._DentalExamination.ObjectContext, this._DentalExamination, sp);
                            sp.DentalLaboratoryProcedure = dentalLab;
                        }
                    }
                }
            }
#endregion DentalExaminationForm_PostScript

            }
            
#region DentalExaminationForm_Methods
        private const string BiyokimyaIMG = "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";
        private const string MikrobiyolojiIMG = "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";
        private const string PatolojiIMG = "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";
        private const string RadyolojiIMG = "AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAoRAAAAL/2P/gABBKRklGAAEBAQBIAEgAAP/hAGhFeGlmAABNTQAqAAAACAAEARoABQAAAAEAAAA+ARsABQAAAAEAAABGASgAAwAAAAEAAgAAATEAAgAAABIAAABOAAAAAAAAAEgAAAABAAAASAAAAAFQYWludC5ORVQgdjMuNS4xMAD/2wBDAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/2wBDAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/wAARCAAtAEIDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwA/bj/4Kl/8FGvg7+3F+1j8JtE/aS8feFvC/g/43fEO2+H/AIRtB4I0eTQvh8fFvibTfBiwaX4g8I6hqmt6JNY2dldWWqx39rFPY2U0aXUgvY7y02v2Y/8AgrH+3/8AFXWvDvhnWv2q7LSvDni34g6BoM3xH1OXwRJp/hwaTaeIV1bQ9Wv7100qKPWpr3TYtfu9EvHvdGu9P064tIraKV7e4/br4q/8EEPBnxm+NXxn+MXjzx5oGo6n8WfjJ8UPiKGj0TV4NT0jw94x1OHUPCnhz7XBqUMVxL4TN94pZmmhmtbqfX5pLaOzZ7h5fKPhb/wbvWnwn/tLw34W+JngXR/A1z8QfCvjfSZtF8N63YePvDx8M3GpK623imae8u9Wvtb027gstXuNcuL5ZjD9oh+z3kGnXdi42ur7X10uB8A/tc/8FNv26Phi2q/D3wL+034l1vxFY+Jb2fwx4h8CeEdD8YaN4luNW8BWepeHvhTofiDRfDFxqvibxJLdaHrd497q+m6Jb2mpW/iK2gmu7e0mntPfP+CJH/BQz9tP4leNvjPoP7Y/xo8b+KtR8Ffsl+NvirY+CviN8P8A/hFNT0vXfDXxR0DwpYeI11WLw5o+m6/Zau+pyafp8ulPcWP2e4it7gG7tLl192/aX/4IbeJNb8SeDPiBoH7VPwy+Fx0D4zeJPib4qn+I2i3F7Z+OtI1axOnQ6HcajLqWhvoc2mabd3enQNazX1lZ28lpcwQpei+m1Hl/AX7CF7+zv8dfFPxl0v8Aat+DvxZ8CfF7wPb/AABg+GHw7uoNV8R+GPDa+NNA+NGtazceJDrl++rwSv8ADGa01C4/s7T5YV1KztFZrdZRcdfJhHQclVl9Z50o0eR8nJeKb5m3d6u6797nE6uOWOhTWGhLBcnNOvze+pq3u8ml/Pda9yh8bf2rdG+E2lv4++NvxZHhSw1i5murU+JfE11aXmuXE7tM7LCksmpX11c/ehs9PgcFMqqNgvHpfszft/8A7OPxrvotJ0bxRoHiV3CtsstQ1KPVo037DNNpOuwWd/LbggGS4trWNE3qz3BIMdfw9/8ABSL9oH4qftGftX/ETxldXMs/hGy8S+JPC/ww0R2uE0/R/Bvh7Xb3Q7KfToIpEt4JNbk0ttTvXWMuJGWxMr22n2qR8h+x3pH7SXjn4z6X4W+Blzplj4+0DR/E3jbSb6+1HUdOilbwXotzrV1psbQWl/uuNXe1XQ7WKaMWN5LqMUd/JFYSTyx/f0uCMMsqqYrHYjGYfGKhGtzqgp4OHNCMlGTinJq0lzSukr6J2sfKVuL8VLM4YfBUMJXwvtfZzh7ZxxUtbOUeZcie9ov4raNas/0/tS+Ccni/4e3XjH4farHpllcP9hbVo1g1GXS5zJppS7Gn3k8AnMovkgiiR5RG2+W4hiSNTN31v8PW+GPj39lG4ktvsPjPXtX8YWnibUYkazurrTlk0JbTTWjWeae3sTY6hPJLp91cXM8c1/dQXcpIEMXyd/wRP/amX9oD4JeEPEFw8UQ+IfgLSfFC2pSYSWHiTSZLjT/EOh26iR44YbC/TXIpDMiF/wCz4Cphdzbv94/Hi6uX/al/ZhsB9pktluNZutiyoLW2lknjMkzRyzp+8uEsYo2aCGSSQQRrIQEjx+dqg6OJqQlb2kPaU5NXtLkUl3Wjf6bn3Ma7q0aW3I/3sbxip3qRhdSkld25Ukm2k723PuOiiisBBXkXxY+P3wQ+BWgat4n+MfxZ+H/w10XRNMu9X1C58YeKtH0WcWNlbPdzGz067uk1LU7p4UIs9P0y0vNQ1Cd4rWwtbm6mhhf8HfjD8Z/ih8VfEuuaR8d9d+JPgbw/F4t1fSx4T0DXPFvgjRtHvLW2e3fw/cWmgax4Yl1k2OlaojSHWJNRmuRPHqfzzeTKnhvxRm+A/gX4gH4eeFf+Cbvx8/bH+IejaX4Z1W78b3PgOfWPhjc3mu+HrDV7GSx+JfjmTxLD9rg0/ULey1K+uLKP7LeRXtn9qmkinLb4fC4jF1HSw8ISklzNzqwpRjFNJtym4rr3v1IrVaOGh7TEVOSDajHljKbk3rZRim3p5H5h/wDBS79vf9nP/goP8fPDHiywvr6/8O/DTTLrwl8OvBdtY3viOfULD+2J9WvfE+swaXLe6dZ634oma2tr7TbZRbWWmaZo9g+q6pPHLct8w/EH9ta++AvxSsP2k/EvwYi+G2o+JfEGpX+hzXPws1j4deB9ZurnSDper6Vo1pBaaLYyC/065uJ9QtNHvGlP26e4LKW8yv2J+I/7Vf7XPwS0CTVdO/Y5/Y7/AGOPDa21zMt58StW8Y/HTxJptlZRPM89z4Z/Zd8J+JNU06WKGMmK31nRLWHzkMXLcD8UP2h/+CtP7Sfxtv8Awd8M/AH7Yd/q/irWPE2oXVtaeFv2QvC3wq+G3he20Lwzrt7da54V8cfEG9l+MM3iOBhBpmmLc+BfDgOmalqFzJrSzRjTLz3cFwpjMVOF8dgabcrXhOVflknF70I1IXV9nJa22sefV4noUF7OngMTVvHlTqU1RU1K2q9vKm3e28V8tD89bX4XeOf2jtO1L/hRfwB+MPi+51KGWCy8Q6H8NviN4m0Z9Km8Ty+J5km1Dw74R1O0gkOoyzvHeXbwW62ccUb3TyJJM8nwyT4wf8Et/j58Hfjn8cfA2j23hufUtb8M614S0n4g/DrXPH1zomsaDeadrA1DwFp3iefxl4bvLGC7TVNNfxbomgWV7qNhBYm9ikkfb4L+038QP2nfF7t/wtr9pj43fFe7uZHWK08UfE3xp4g04uWAWK00XUL6Syt1eRisMNtAqfdCRrwB+zv7Jn/BFH4gePv2Xf2Xf2mf2oJfD+m/DnxTqetah4Y+CcHw7g8G/EzWn0vWtct7HWfi94zu9Ms/E+oeGdWstNS403SRLLd6pot1YzW1zp1peRX11+m4ivjOHMnqYfOMzp4vD4+M0oSoylWmnTjBU6UuZOyVNNJwVm23JXsfnkMNhc8ziOIy3AvC4nAypufJVUacGp83POK92Um5WdpSb2tZaft9/wAG+9trfw3+AX7Pd94isTBqXijTNa1e10meWSyjhHxi8a6/q/hm2Z/s9y8MMWm+K9KvZEjtpmithIyxlUJr+gP4sWQ1L9rz9nW1MvleRonijUc+X5gzpthruohMbkwZzZeTv3Hy94k2Pt8t/wAyf2WNI06x+Lnwj0DS4YreysfE+iSRW8EUcMKjSdlwnlwQqkUEUaW2IYY0SKCICCJQiqK/UH4hMT+2Z8A067fBnjV/pu0Lxiufx2kV+NVantMRXrWUfa+2klva6fKvknGPyP1SnB06dOk3d06cIN92oq7+/bysfZFFFFcZR518QvhH8NPivZW+n/EXwVoHi23tJUmtDqtkr3VpIglCm1v4TDfWy/vpd0cNykblyXVjgjR8MfDrwP4NsNP0zw34X0nTLTSUSLTVW2FzPYxxhRHHbXl6bm8jSMKBGi3G2PHyAZNdpRRdrYL9OnY/kp8HX1zP+0NBoeoyf2jpkVvbqmm6lHHf2cLt4g161mMUF2k0UbSJDEjsq7sRJgqETH6//tw/8E4/B37bn7I+jfB/wPN4I+CHja/1D4ceK7L4taR4D0mfxHoaaTDFJrv9nTafDp19Jfa7pN3f6TLJLfJE0d9LLcibaI2/P39sD9mTXP2P/icnxw0T4kad428O+IdblbSvAWq+A5dI1PQdLvPEuo6jZ6Y/jSy8aXMGrPp4vza/bpPB9nNdRQxySRpMXdv15+E3jj4s/GLS9I0TQvGOhfDPR9H8I+E726vNJ8Fx+JPFl2l5pkIFvZar4l1y78NaeEVkMkt14K1d5ZIwyCBGeI9dCtWw1WlicPU9nOhKnOMt0qkeVpuLTUlezs009muhFalTr0nSqJShOLhKKunZrW0lZrsrO6tpbp+U3wQ/4NoP2BPhHeWnjX4yeLvi58fvEnhu5t/EEGuePfGA8KeHNJudL/0yTUG0Xw81tAtnbvAl35epapdW1uIXkuGnHzp9d/tp+Mfhkfhv8OfBvwf/ALV8XeHPA+sX8V5P8O/DnjX4i+GvDtm2mYt49S8Y+HtK8R6LBIsrzRyrfa21zBIJIrnynBUfodafs+fDyWW0vPGqa98WdTsZpLi1vvixrt542tbS5kEYe503wtfmPwPotyTDE/n6F4X0yXfHE27MEHl+1www20MVvbwxW9vbxRwwQQxrFDDDEgSKKKKMKkcUaKqRxoqoiKFUAACtcbmeOzKcamPxdfFyjflVWfuwva6pxXuQTS2hGKvrbvhg8Dg8AnHCYalQUneXJG0pPvObvKTX96T8j+eP9jr4r/CiH9ofwXJrXxA8CabDpSeJ7q+XXfEWiaW2mvD4R17yJtQh1W7tnsJIbryWja5jheK5WIqVl2V+kviXXfFXxC/aK+GnxO+DfgLXfiF4V8KeD9Z0+78Samt18PfBkt9q0fiXTYTZeIvFmm291r9jGNTtrmXUvBGheLoPJEiR+ZMjxp9xah4b8Patf6bquqaDoupapo8y3GkalqGl2N5f6VOhYrNpt5cQSXFjMpZislrJE4LMQwJNbVcfPu0ndrld2no99orX5/gdbd3c8ihf49PDE9xb/CK3naNGnt4bzxneQwTMoMkMV29jYvdRxOWRLl7KzadVErWtuWMKFeu0VHy/P/P+r+gj/9kL";
        private string disMuayene = "";
        private bool OldDentalExaminationsGridFilled = false;
        private List<TTCheckBox> selectedCheckboxes = new List<TTCheckBox>();
        private Dictionary<String, ITTGridRow> rowTable = new Dictionary<String, ITTGridRow>();
        private void fireMustehaklikKontrol(ITTGridRow row)
        {
            if (this._BaseDentalEpisodeAction.SubEpisode.SGKSEP == null)
                throw new Exception("Medula kaydı olmayanlar hastalarda sorgulama yapılamaz!");

            HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayit = new HizmetKayitIslemleri.hizmetKayitGirisDVO();
            hizmetKayit.disBilgileri = GetDisIslemDVOArray(row);
            hizmetKayit.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            hizmetKayit.hastaBasvuruNo = this._BaseDentalEpisodeAction.SubEpisode.SGKSEP.MedulaBasvuruNo;
            hizmetKayit.takipNo = this._BaseDentalEpisodeAction.SubEpisode.SGKSEP.MedulaTakipNo;
            Guid? procedureID = this._DentalExamination.SubactionProcedures[0].ProcedureObject.ObjectID;
            HizmetKayitIslemleri.hizmetKayitCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(TTObjectClasses.Sites.SiteLocalHost, procedureID, hizmetKayit);

            if (result.hataliKayitlar != null)
            {
                string hataMesajlari = "";
                for (int i = 0; i < result.hataliKayitlar.Length; i++)
                {
                    HizmetKayitIslemleri.hataliIslemBilgisiDVO hata = result.hataliKayitlar[i];
                    if (hata != null)
                    {
                        IEnumerator disBilgiEnum = hizmetKayit.disBilgileri.GetEnumerator();
                        while (disBilgiEnum.MoveNext())
                        {
                            HizmetKayitIslemleri.disBilgisiDVO tempDisBilgisi = (HizmetKayitIslemleri.disBilgisiDVO)disBilgiEnum.Current;
                            if (tempDisBilgisi != null && tempDisBilgisi.hizmetSunucuRefNo.Equals(hata.hizmetSunucuRefNo))
                            {
                                hataMesajlari += tempDisBilgisi.sutKodu + " - ";
                                break;
                            }
                        }
                        hataMesajlari += hata.hataKodu + " - " + hata.hataMesaji + " \n";
                    }
                    else
                    {
                        hataMesajlari += result.sonucMesaji + " \n";
                    }
                }
                InfoBox.Show(hataMesajlari, MessageIconEnum.ErrorMessage);
            }
            if (result.islemBilgileri != null && result.islemBilgileri.Length > 0 && result.islemBilgileri[0] != null)
            {
                HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptal = new HizmetKayitIslemleri.hizmetIptalGirisDVO();
                hizmetIptal.saglikTesisKodu = hizmetKayit.saglikTesisKodu;
                hizmetIptal.takipNo = hizmetKayit.takipNo;
                String[] islemNumaralari = new String[result.islemBilgileri.Length];
                hizmetIptal.islemSiraNumaralari = new String[result.islemBilgileri.Length];
                for (int i = 0; i < result.islemBilgileri.Length; i++)
                {
                    hizmetIptal.islemSiraNumaralari[i] = result.islemBilgileri[i].islemSiraNo;
                    if (this.DentalProsthesis.Rows != null && SubEpisode.IsSGKSubEpisode(_DentalExamination.SubEpisode))
                    {
                        foreach (ITTGridRow tempRow in this.DentalProsthesis.Rows)
                        {
                            foreach (KeyValuePair<String, ITTGridRow> entry in rowTable)
                            {
                                if (entry.Key.Equals(result.islemBilgileri[i].hizmetSunucuRefNo))
                                {
                                    paintRow(Color.PaleTurquoise, entry.Value);
                                    entry.Value.Cells[2].Value = true;
                                }
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(2000);
                HizmetKayitIslemleri.hizmetIptalCevapDVO iptalResult = HizmetKayitIslemleri.WebMethods.hizmetIptalSync(TTObjectClasses.Sites.SiteLocalHost, hizmetIptal);
                if (!"0000".Equals(iptalResult.sonucKodu))
                {
                    int count = 0;
                    while (count < 3 && !"0000".Equals(iptalResult.sonucKodu))
                    {
                        System.Threading.Thread.Sleep(2000);
                        iptalResult = HizmetKayitIslemleri.WebMethods.hizmetIptalSync(TTObjectClasses.Sites.SiteLocalHost, hizmetIptal);
                        count++;
                    }
                    if (!"0000".Equals(iptalResult.sonucKodu))
                    {
                        String islemNoSilinemeyen = "";
                        for (int i = 0; i < hizmetIptal.islemSiraNumaralari.Length; i++)
                        {
                            islemNoSilinemeyen += hizmetIptal.islemSiraNumaralari[i];
                        }
                        InfoBox.Show(islemNoSilinemeyen + " işlem numaralı hizmetler müstehaklık sorgusu sonucunda meduladan silinememiştir. Bu işlem numaralarını Bilgi İşleme acilen bildiriniz!", MessageIconEnum.ErrorMessage);
                    }
                }
                else
                {
                    InfoBox.Show("Müstehaklık sorgusu başarıyla yapılmış ve bir hata alınmamıştır.", MessageIconEnum.InformationMessage);
                }
            }
        }


        public HizmetKayitIslemleri.disBilgisiDVO[] GetDisIslemDVOArray(ITTGridRow row)
        {
            HizmetKayitIslemleri.disBilgisiDVO[] disBilgileri = null;
            if (row == null)
            {
                disBilgileri = new HizmetKayitIslemleri.disBilgisiDVO[this.DentalProsthesis.Rows.Count];
                int count = 0;
                foreach (ITTGridRow tempRow in this.DentalProsthesis.Rows)
                {
                    disBilgileri[count++] = getDisBilgisiDVOWithPropertiesSet(tempRow);
                }
            }
            else
            {
                disBilgileri = new HizmetKayitIslemleri.disBilgisiDVO[1];
                disBilgileri[0] = getDisBilgisiDVOWithPropertiesSet(row);
            }
            return disBilgileri;
        }

        private HizmetKayitIslemleri.disBilgisiDVO getDisBilgisiDVOWithPropertiesSet(ITTGridRow row)
        {
            String disNo = null;
            String pozisyon = null;
            //String disSema = null;
            String durum = null;
            String ayniFarkliKesi = null;
            String disTaahhutNo = null;
            String anomali = null;
            //String anesteziDrTescilNo = null;
            String ozelDurum = null;
            String cokluOzelDurum = null;

            SubActionProcedure procedure = (SubActionProcedure)row.TTObject;

            if (row.Cells[5] != null && row.Cells[5].Value != null)
                disNo = row.Cells[5].Value.ToString();
            //  if (row.Cells[3] != null && row.Cells[3].Value != null)
            durum = "Yeni";
            if (row.Cells[6] != null && row.Cells[6].Value != null)
                ayniFarkliKesi = row.Cells[6].Value.ToString();
            if (row.Cells[7] != null && row.Cells[7].Value != null)
                anomali = row.Cells[7].Value.ToString();
            if (row.Cells[8] != null && row.Cells[8].Value != null)
                ozelDurum = row.Cells[8].Value.ToString();
            if (row.Cells[9] != null && row.Cells[9].Value != null)
                cokluOzelDurum = row.Cells[9].Value.ToString();

            HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO = new HizmetKayitIslemleri.disBilgisiDVO();

            //            bool loopControl = false;
            //            foreach (EpisodeAction ea in this._DentalExamination.Episode.EpisodeActions)
            //            {
            //                if (ea != null && ea.MasterResource != null) // polikliniğin uzmanlığı set edilir
            //                {
            //                    foreach (ResourceSpecialityGrid resSpeciality in ea.MasterResource.ResourceSpecialities)
            //                    {
            //                        if (resSpeciality.Speciality != null)
            //                        {
            //                            disBilgisiDVO.bransKodu = resSpeciality.Speciality.Code;
            //                            loopControl = true;
            //                            break;
            //                        }
            //                    }
            //                }
            //                if (loopControl)
            //                    break;
            //            }
            String bransKodu = null;
            if (this._DentalExamination.GetType() == typeof(TTObjectClasses.DentalConsultation)) {
                DentalExamination dentalExamCons =  ((TTObjectClasses.DentalConsultation)(this._DentalExamination)).DentalExamination_Cons;
                if (dentalExamCons != null && dentalExamCons.DentalConsultationRequest != null && dentalExamCons.DentalConsultationRequest.Count > 0 && dentalExamCons.DentalConsultationRequest[0] != null) {
                    ResPoliclinic polic = dentalExamCons.DentalConsultationRequest[0].ConsultationDepartment;
                    if (polic != null && polic.Brans != null && polic.Brans.Code != null) {
                        bransKodu = polic.Brans.Code;
                    }
                }
            }
            
            if (bransKodu == null && _DentalExamination.Episode.MainSpeciality != null)
                bransKodu = _DentalExamination.Episode.MainSpeciality.Code;
            
            if (bransKodu != null)
                disBilgisiDVO.bransKodu = bransKodu;

            if (this._DentalExamination.ProcedureDoctor != null)
                disBilgisiDVO.drTescilNo = this._DentalExamination.ProcedureDoctor.DiplomaRegisterNo;

            if (string.IsNullOrEmpty(disBilgisiDVO.drTescilNo))
                disBilgisiDVO.drTescilNo = Common.GetDoctorRegisterNoByBranchCode(disBilgisiDVO.bransKodu);

            if (anomali != null && anomali.Equals(true))
            {
                disBilgisiDVO.anomali = "E";
            }
            else if (anomali != null && anomali.Equals(false))
            {
                disBilgisiDVO.anomali = "H";
            }
            else
            {
                disBilgisiDVO.anomali = "H";
            }

            disBilgisiDVO.adet = 1;
            //disBilgisiDVO.adetSpecified = true;
            disBilgisiDVO.hizmetSunucuRefNo = Guid.NewGuid().ToString().Substring(0, 20);
            rowTable.Add(disBilgisiDVO.hizmetSunucuRefNo, row);

            disBilgisiDVO.islemTarihi = Common.RecTime().ToShortDateString();

            List<int> listEriskin = new List<int>();
            List<int> listSut = new List<int>();
            List<int> listAnomali = new List<int>();
            List<int> listCene = new List<int>();

            if (Convert.ToInt32(disNo) >= 11 && Convert.ToInt32(disNo) <= 48)
                listEriskin.Add(Convert.ToInt32(disNo));
            else if (Convert.ToInt32(disNo) >= 51 && Convert.ToInt32(disNo) <= 85)
                listSut.Add(Convert.ToInt32(disNo));
            else if (Convert.ToInt32(disNo) >= 91 && Convert.ToInt32(disNo) <= 94)
                listAnomali.Add(Convert.ToInt32(disNo));
            else if (Convert.ToInt32(disNo) >= 1 && Convert.ToInt32(disNo) <= 7)
                listCene.Add(Convert.ToInt32(disNo));

            setEriskinDisler(listEriskin.ToArray(), disBilgisiDVO);
            setSutDisler(listSut.ToArray(), disBilgisiDVO);
            setAnomaliDisler(listAnomali.ToArray(), disBilgisiDVO);
            setCeneDisler(listCene.ToArray(), disBilgisiDVO);

            disBilgisiDVO.sutKodu = procedure.ProcedureObject.SUTCode;

            if (ayniFarkliKesi != null)
                disBilgisiDVO.ayniFarkliKesi = ayniFarkliKesi;
            else
                disBilgisiDVO.ayniFarkliKesi = null;

            if (ozelDurum != null)
            {
                OzelDurum ozelDurumObj = _DentalExamination.ObjectContext.GetObject(Guid.Parse(ozelDurum), typeof(OzelDurum).Name) as OzelDurum;
                disBilgisiDVO.ozelDurum = ozelDurumObj.ozelDurumKodu;
            }
            else
                disBilgisiDVO.ozelDurum = null;

            if (disTaahhutNo != null)
                disBilgisiDVO.disTaahhutNo = Convert.ToInt32(disTaahhutNo);
            else
                disBilgisiDVO.disTaahhutNo = null;

           // disBilgisiDVO.disTaahhutNoSpecified = true;

            if (cokluOzelDurum != null)
            {
                List<String> listCokluOzelDurum = new List<String>();
                String[] cokluOzelDurumArr = cokluOzelDurum.Split(';');
                disBilgisiDVO.cokluOzelDurum = cokluOzelDurumArr;
            }
            else
                disBilgisiDVO.cokluOzelDurum = null;

            /*if (this._DentalExamination.ResUser != null && this._DentalExamination.ResUser.DiplomaRegisterNo != null)
                disBilgisiDVO.drAnesteziTescilNo = this._DentalExamination.ResUser.DiplomaRegisterNo.ToString();
            else
                disBilgisiDVO.drAnesteziTescilNo = null;*/

            return disBilgisiDVO;
        }

        public void setEriskinDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] eDis = new String[32];
            disBilgisiDVO.sagUstCene = "";
            disBilgisiDVO.solUstCene = "";
            disBilgisiDVO.solAltCene = "";
            disBilgisiDVO.sagAltCene = "";

            for (int i = 0; i < eDis.Length; i++)
                eDis[i] = "_";

            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 11, l = 0; k <= eDis.Length + 16 && l < eDis.Length; k++, l++)
                {
                    if (k == 18 || k == 28 || k == 38 || k == 48)
                    {
                        if (str[j] == k)
                        {
                            eDis[l] = "E";
                            break;
                        }
                        k = k + 2;
                    }
                    else
                    {
                        if (str[j] == k)
                        {
                            eDis[l] = "E";
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < eDis.Length; i++)
            {
                if (i >= 0 && i < 8)
                    disBilgisiDVO.sagUstCene = disBilgisiDVO.sagUstCene + eDis[i];
                if (i >= 8 && i < 16)
                    disBilgisiDVO.solUstCene = disBilgisiDVO.solUstCene + eDis[i];
                if (i >= 16 && i < 24)
                    disBilgisiDVO.solAltCene = disBilgisiDVO.solAltCene + eDis[i];
                if (i >= 24 && i < 32)
                    disBilgisiDVO.sagAltCene = disBilgisiDVO.sagAltCene + eDis[i];
            }
        }

        //Tuğba:  Süt dişlerin string scheması oluşturulur.
        public void setSutDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] sDis = new String[20];
            disBilgisiDVO.sagSutUstCene = "";
            disBilgisiDVO.solSutUstCene = "";
            disBilgisiDVO.solSutAltCene = "";
            disBilgisiDVO.sagSutAltCene = "";

            for (int i = 0; i < sDis.Length; i++)
                sDis[i] = "_";

            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 51, l = 0; k <= sDis.Length + 65 && l < sDis.Length; k++, l++)
                {
                    if (k == 55 || k == 65 || k == 75 || k == 85)
                    {
                        if (str[j] == k)
                        {
                            sDis[l] = "E";
                            break;
                        }
                        k = k + 5;
                    }
                    else
                    {
                        if (str[j] == k)
                        {
                            sDis[l] = "E";
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < sDis.Length; i++)
            {
                if (i >= 0 && i < 5)
                    disBilgisiDVO.sagSutUstCene = disBilgisiDVO.sagSutUstCene + sDis[i];
                if (i >= 5 && i < 10)
                    disBilgisiDVO.solSutUstCene = disBilgisiDVO.solSutUstCene + sDis[i];
                if (i >= 10 && i < 15)
                    disBilgisiDVO.solSutAltCene = disBilgisiDVO.solSutAltCene + sDis[i];
                if (i >= 15 && i < 20)
                    disBilgisiDVO.sagSutAltCene = disBilgisiDVO.sagSutAltCene + sDis[i];
            }
        }

        //Tuğba:  Anomalili dişlerin string scheması oluşturulur.
        public void setAnomaliDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] aDis = new String[4];

            disBilgisiDVO.sagUstCeneAnomaliDis = "";//91
            disBilgisiDVO.solUstCeneAnomaliDis = "";//92
            disBilgisiDVO.sagAltCeneAnomaliDis = "";//93
            disBilgisiDVO.solAltCeneAnomaliDis = "";//94


            for (int i = 0; i < aDis.Length; i++)
                aDis[i] = "_";

            for (int j = 0; j < str.Length; j++)
                for (int k = 91, l = 0; k <= aDis.Length + 90 && l < aDis.Length; k++, l++)
            {
                if (str[j] == k)
                {
                    aDis[l] = "E";
                    break;
                }
            }

            disBilgisiDVO.sagUstCeneAnomaliDis = aDis[0];
            disBilgisiDVO.solUstCeneAnomaliDis = aDis[1];
            disBilgisiDVO.sagAltCeneAnomaliDis = aDis[2];
            disBilgisiDVO.solAltCeneAnomaliDis = aDis[3];
        }



        //Tuğba: Tüm,sağ,sol,üst,alt çene string scheması oluşturulur.
        public void setCeneDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {


            for (int j = 0; j < str.Length; j++)
            {

                if (str[j] == 1)
                {  //Tüm Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                } if (str[j] == 2)
                {  //Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                } if (str[j] == 3)
                {  //Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                } if (str[j] == 4)
                {  //Sağ Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                } if (str[j] == 5)
                {  //Sol Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                } if (str[j] == 6)
                {  //Sağ Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                } if (str[j] == 7)
                {  //Sol Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "________";
                }

            }

        }

        private void addDentalProsthesisRows(Control.ControlCollection controls)
        {
            foreach (Control currControl in controls)
            {
                if (currControl.GetType().Equals(typeof(TTCheckBox)) && currControl.Name.StartsWith("ch") && ((TTCheckBox)currControl).Checked)
                {
                    TTCheckBox currChkbox = (TTCheckBox)currControl;
                    foreach (ITTGridRow tempRow in this.DentalProcessNew.Rows)
                    {
                        ITTGridRow newRow = this.DentalProsthesis.Rows.Add();
                        //newRow.Cells[1].Value = ProcedureDefinition.GetByCode(new TTObjectContext(false), tempRow.Cells[0].Value.ToString().Split('-')[0]).ObjectID;
                        newRow.Cells[3].Value = tempRow.Cells[0].Value;
                        newRow.Cells[5].Value = Int32.Parse(currChkbox.Name.Substring(2, currChkbox.Name.Length - 2));
                        newRow.Cells[10].Value = GetPatientPrice(((SubActionProcedure)newRow.TTObject).ProcedureObject, true);
                        selectedCheckboxes.Add(currChkbox);
                        /*if (//protez olarak işaretli işlem ise)
                            {
                                ITTGridRow newRow = this.ttgrid3.Rows.Add();
                                //newRow.Cells[1].Value = ProcedureDefinition.GetByCode(new TTObjectContext(false), tempRow.Cells[0].Value.ToString().Split('-')[0]).ObjectID;
                                newRow.Cells[2].Value = tempRow.Cells[0].Value;
                                newRow.Cells[3].Value = Int32.Parse(currChkbox.Name.Substring(2, currChkbox.Name.Length - 2));
                            }*/
                    }
                }
                if (currControl.HasChildren)
                {
                    addDentalProsthesisRows(currControl.Controls);
                }
            }
        }

        private void addDentalConsultationRows(Control.ControlCollection controls, StringBuilder istekAciklama)
        {
            foreach (Control currControl in controls)
            {
                if (currControl.GetType().Equals(typeof(TTCheckBox)) && currControl.Name.StartsWith("ch") && ((TTCheckBox)currControl).Checked)
                {
                    TTCheckBox currChkbox = (TTCheckBox)currControl;
                    istekAciklama.Append(Int32.Parse(currChkbox.Name.Substring(2, currChkbox.Name.Length - 2)) + ",");
                    selectedCheckboxes.Add(currChkbox);
                }
                if (currControl.HasChildren)
                {
                    addDentalConsultationRows(currControl.Controls, istekAciklama);
                }
            }
        }


        public void FillDentalExaminationFile1Grid(ITTGrid DentalExaminationsGrid)
        {
            BindingList<EpisodeAction> examList = EpisodeAction.GetAllDentalExaminationsOfPatient(this._DentalExamination.ObjectContext, this._DentalExamination.Episode.Patient.ObjectID.ToString());

            object examinationIndication = null;
            foreach (EpisodeAction ea in examList)
            {
                if (ea is DentalExamination)
                {
                    DentalExamination de = (DentalExamination)ea;
                    if (de.DentalExaminationFile != null)
                    {
                        try
                        {
                            examinationIndication = TTObjectClasses.Common.GetTextOfRTFString(de.DentalExaminationFile.ToString());
                        }
                        catch
                        {
                            examinationIndication = de.DentalExaminationFile.ToString();
                        }
                    }
                }
                if (examinationIndication != null)
                {
                    ITTGridRow gridRow = DentalExaminationsGrid.Rows.Add();
                    gridRow.Cells["ExaminationDateTime"].Value = ea.ActionDate.Value;
                    gridRow.Cells["ExaminationIndication"].Value = examinationIndication;
                }
            }
        }

        public void paintRow(Color color, ITTGridRow row)
        {
            foreach (ITTGridCell cell in row.Cells)
            {
                cell.BackColor = color;
            }
        }

        public void paintRows()
        {
            if (DentalProsthesis.Rows != null && SubEpisode.IsSGKSubEpisode(_DentalExamination.SubEpisode))
            {
                foreach (ITTGridRow row in DentalProsthesis.Rows)
                {
                    TTObjectClasses.DentalProcedure dp = (TTObjectClasses.DentalProcedure)row.TTObject;
                    if ((dp.PatientPay == null || dp.PatientPay.Value == false) && (dp.AccountRecordable == null || dp.AccountRecordable.Value == false))
                    {
                        paintRow(Color.Salmon, row);
                    }
                    else if (dp.PatientPay != null && dp.PatientPay.Value == true && !dp.Paid())
                    {
                        paintRow(Color.Salmon, row);
                    }
                    else
                    {
                        paintRow(Color.PaleTurquoise, row);
                    }
                }
            }
        }
        
        public void getSelectedToothNumbers(StringBuilder sb, Control.ControlCollection controls){
            foreach (Control currControl in controls)
            {
                if (currControl.GetType().Equals(typeof(TTCheckBox)) && currControl.Name.StartsWith("ch") && ((TTCheckBox)currControl).Checked)
                {
                    TTCheckBox currChkbox = (TTCheckBox)currControl;
                    if (!"".Equals(sb.ToString()))
                        sb.Append(", ");
                    sb.Append(Int32.Parse(currChkbox.Name.Substring(2, currChkbox.Name.Length - 2)) + "");
                    selectedCheckboxes.Add(currChkbox);
                }
                if (currControl.HasChildren)
                {
                    getSelectedToothNumbers(sb, currControl.Controls);
                }
            }
        }

        public double? GetPatientPrice(TTObject procedureDefinition, bool onlyPatientPrice)
        {
            double? patientPrice = 0;
            SubEpisodeProtocol sep = _DentalExamination.SubEpisode.OpenSubEpisodeProtocol;
            
            if (sep == null)
                InfoBox.Show("Altvakada açık anlaşma bulunamadığı için hasta payı hesaplanamamıştır.", MessageIconEnum.InformationMessage);
            else 
                patientPrice = sep.Protocol.GetPrice(procedureDefinition, _DentalExamination.Episode.PatientStatus, null, Common.RecTime(), null, _DentalExamination.Episode.Patient.Age, onlyPatientPrice);
            
            if(patientPrice > 0)
                return patientPrice;
            else
                return null;
        }

        //        public void CreateNewDentalConsultationRequest()
        //        {
        //            DentalConsultationRequest dentalConsultationRequest;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                dentalConsultationRequest = new DentalConsultationRequest(objectContext);
        //                this._DentalExamination.DentalConsultationRequest.Add(dentalConsultationRequest);
        //                TTForm frm = TTForm.GetEditForm(dentalConsultationRequest);
        //                if(frm.ShowEdit(this.FindForm(), dentalConsultationRequest) == DialogResult.OK)
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
        
#endregion DentalExaminationForm_Methods
    }
}