
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
    /// İlaç Direktifi Giriş
    /// </summary>
    public partial class DrugOrderIntroductionNewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            AutoSearch.CheckedChanged += new TTControlEventDelegate(AutoSearch_CheckedChanged);
            cmdSearch.Click += new TTControlEventDelegate(cmdSearch_Click);
            btnIlacBilgileri.Click += new TTControlEventDelegate(btnIlacBilgileri_Click);
            btnSUTBilgileri.Click += new TTControlEventDelegate(btnSUTBilgileri_Click);
            cmdAddDrug.Click += new TTControlEventDelegate(cmdAddDrug_Click);
            SearchTextbox.TextChanged += new TTControlEventDelegate(SearchTextbox_TextChanged);
            DrugListview.DoubleClick += new TTControlEventDelegate(DrugListview_DoubleClick);
            DrugListview.SelectedIndexChanged += new TTControlEventDelegate(DrugListview_SelectedIndexChanged);
            cmdGetTemplate.Click += new TTControlEventDelegate(cmdGetTemplate_Click);
            cmdAddTemplate.Click += new TTControlEventDelegate(cmdAddTemplate_Click);
            FavoriteDrugListview.SelectedIndexChanged += new TTControlEventDelegate(FavoriteDrugListview_SelectedIndexChanged);
            OldDrugOrders.CellContentClick += new TTGridCellEventDelegate(OldDrugOrders_CellContentClick);
            cmdFavoriteDrug.Click += new TTControlEventDelegate(cmdFavoriteDrug_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            AutoSearch.CheckedChanged -= new TTControlEventDelegate(AutoSearch_CheckedChanged);
            cmdSearch.Click -= new TTControlEventDelegate(cmdSearch_Click);
            btnIlacBilgileri.Click -= new TTControlEventDelegate(btnIlacBilgileri_Click);
            btnSUTBilgileri.Click -= new TTControlEventDelegate(btnSUTBilgileri_Click);
            cmdAddDrug.Click -= new TTControlEventDelegate(cmdAddDrug_Click);
            SearchTextbox.TextChanged -= new TTControlEventDelegate(SearchTextbox_TextChanged);
            DrugListview.DoubleClick -= new TTControlEventDelegate(DrugListview_DoubleClick);
            DrugListview.SelectedIndexChanged -= new TTControlEventDelegate(DrugListview_SelectedIndexChanged);
            cmdGetTemplate.Click -= new TTControlEventDelegate(cmdGetTemplate_Click);
            cmdAddTemplate.Click -= new TTControlEventDelegate(cmdAddTemplate_Click);
            FavoriteDrugListview.SelectedIndexChanged -= new TTControlEventDelegate(FavoriteDrugListview_SelectedIndexChanged);
            OldDrugOrders.CellContentClick -= new TTGridCellEventDelegate(OldDrugOrders_CellContentClick);
            cmdFavoriteDrug.Click -= new TTControlEventDelegate(cmdFavoriteDrug_Click);
            base.UnBindControlEvents();
        }

        private void AutoSearch_CheckedChanged()
        {
#region DrugOrderIntroductionNewForm_AutoSearch_CheckedChanged
   if ((bool)_DrugOrderIntroduction.AutoSearch)
                this.cmdSearch.Enabled = false;
            else
                this.cmdSearch.Enabled = true;
#endregion DrugOrderIntroductionNewForm_AutoSearch_CheckedChanged
        }

        private void cmdSearch_Click()
        {
#region DrugOrderIntroductionNewForm_cmdSearch_Click
   if ((bool)_DrugOrderIntroduction.AutoSearch.HasValue && (bool)_DrugOrderIntroduction.AutoSearch == false)
                SearchDrug(this.SearchTextbox.Text);
#endregion DrugOrderIntroductionNewForm_cmdSearch_Click
        }

        private void btnIlacBilgileri_Click()
        {
#region DrugOrderIntroductionNewForm_btnIlacBilgileri_Click
   if (_DrugOrderIntroduction.DrugObjectID != null)
            {
                DrugDefinition drug = (DrugDefinition)_DrugOrderIntroduction.ObjectContext.GetObject((Guid)_DrugOrderIntroduction.DrugObjectID, typeof(DrugDefinition));
                DrugOrderIntroductionNewUnbound drugOrderIntroductionNewUnbound = new DrugOrderIntroductionNewUnbound(_DrugOrderIntroduction);
                InfoBox.Show("drugOrderIntroductionNewUnbound.ShowDialog(this);");
                if ((DrugDefinition)drugOrderIntroductionNewUnbound.Tag != null)
                {
                    drug = (DrugDefinition)drugOrderIntroductionNewUnbound.Tag;
                    _DrugOrderIntroduction.DrugName = drug.Name;
                    _DrugOrderIntroduction.Dose = drug.Dose;
                    _DrugOrderIntroduction.Volume = drug.Volume;
                    if (drug.Unit != null)
                        _DrugOrderIntroduction.Unit = drug.Unit.Name;
                    _DrugOrderIntroduction.RoutineDay = drug.RoutineDay;
                    _DrugOrderIntroduction.RoutineDose = drug.RoutineDose;
                    _DrugOrderIntroduction.Frequency = drug.Frequency;
                    _DrugOrderIntroduction.MaxDose = drug.MaxDose;
                    _DrugOrderIntroduction.MaxDoseDay = drug.MaxDoseDay;
                    _DrugOrderIntroduction.DrugObjectID = drug.ObjectID;
                }
            }
#endregion DrugOrderIntroductionNewForm_btnIlacBilgileri_Click
        }

        private void btnSUTBilgileri_Click()
        {
#region DrugOrderIntroductionNewForm_btnSUTBilgileri_Click
   DrugDefinition drug = (DrugDefinition)_DrugOrderIntroduction.ObjectContext.GetObject((Guid)_DrugOrderIntroduction.DrugObjectID, typeof(DrugDefinition));

            if (drug.EtkinMadde == null)
            {
                InfoBox.Alert("Bu ilaç herhangi bir medula etkin madde tanımı ile eşleştirilmemiştir.");
                return;
            }

            string filter = "ETKINMADDE = '" + drug.EtkinMadde.ObjectID.ToString() + "'";
            IList acts = _DrugOrderIntroduction.ObjectContext.QueryObjects(typeof(ActiveIngredientPrescriptionSUTRuleDef).Name, filter);
            if (acts.Count == 0)
            {
                InfoBox.Alert("Bu etken maddeye ait kural tanımı bulunamadı!");
                return;
            }
            else
            {
                ActiveIngredientPrescriptionSUTRuleDef act = (ActiveIngredientPrescriptionSUTRuleDef)acts[0];
                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["ActiveIngredientPrescriptionSUTRuleDefinitionList"], filter);
                frm.ShowEdit(this.FindForm(), TTObjectDefManager.Instance.ListDefs["ActiveIngredientPrescriptionSUTRuleDefinitionList"], act);
            }
#endregion DrugOrderIntroductionNewForm_btnSUTBilgileri_Click
        }

        private void cmdAddDrug_Click()
        {
#region DrugOrderIntroductionNewForm_cmdAddDrug_Click
   string errorMsg = string.Empty;
            bool error = false;
            if (_DrugOrderIntroduction.OrderDay == null)
            {
                errorMsg = errorMsg + "Direktif günü boş olamaz. \r\n";
                error = true;
            }
            if (_DrugOrderIntroduction.PlannedStartTime == null)
            {
                errorMsg = errorMsg + "Uygulama Başlangıç Zamanı boş olamaz. \r\n";
                error = true;
            }
            if (_DrugOrderIntroduction.OrderDose == null)
            {
                errorMsg = errorMsg + "Direktif dozu boş olamaz. \r\n";
                error = true;
            }
            if (_DrugOrderIntroduction.OrderFrequency == null)
            {
                errorMsg = errorMsg + "Direktif doz aralığı boş olamaz. \r\n";
                error = true;
            }
            
            bool gunuBirlikHastaMi = _DrugOrderIntroduction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily);
            if (gunuBirlikHastaMi)
            {
                if (_DrugOrderIntroduction.DrugUsageType == null)
                {
                    errorMsg = errorMsg + "Kullanım Şekli boş olamaz. \r\n";
                    error = true;
                }
            }

            if (_DrugOrderIntroduction.DrugObjectID == null)
            {
                errorMsg = errorMsg + "İlaç seçmediniz. \r\n";
                error = true;
            }
            DrugDefinition drug = (DrugDefinition)_DrugOrderIntroduction.ObjectContext.GetObject((Guid)_DrugOrderIntroduction.DrugObjectID, typeof(DrugDefinition));
            if (drug.PatientSafetyFrom.HasValue && (bool)drug.PatientSafetyFrom)
            {
                if (string.IsNullOrEmpty(_DrugOrderIntroduction.DrugDescription))
                {
                    errorMsg = errorMsg + drug.Name + " ilacı için Hasta Güvenlik ve İzleme Formu seri numarası girmelisiniz. \r\n";
                    error = true;
                }
            }

            if (error == false)
            {
                bool addDrug = true;

                if (gunuBirlikHastaMi)
                {
                    double inheld = drug.StockInheld(_DrugOrderIntroduction.SecondaryMasterResource.Store);
                    if (inheld > 0)
                    {
                        string result = "V";// ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Mevcut İlaç", "Order etmek istediğiniz " + drug.Name + " isimli ilaç deponuzda mevcuttur.Bu ilacı isterseniz deponuzdan kullanabilirsiniz.\r\nDepo Adı: " + _DrugOrderIntroduction.SecondaryMasterResource.Store.Name + "\r\nMevcut: " + inheld.ToString() + "\r\nOrder İşlemine Devam Etmek İstiyor Musunuz?");
                        if (result == "V")
                        {
                            addDrug = false;

                            this.OrderFrequency.Text = string.Empty;
                            this.OrderDose.Text = string.Empty;
                            this.OrderDay.Text = string.Empty;
                            this.DrugUsageType = null;
                            _DrugOrderIntroduction.DrugObjectID = null;
                            InfoBox.Alert("Order işleminden vazgeçtiniz.", MessageIconEnum.InformationMessage);
                        }
                    }
                }
                if (addDrug)
                {
                    DrugOrderIntroductionDet drugOrderIntroductionDet = new DrugOrderIntroductionDet(_DrugOrderIntroduction.ObjectContext);
                    drugOrderIntroductionDet.Material = drug;
                    drugOrderIntroductionDet.PlannedStartTime = (DateTime)_DrugOrderIntroduction.PlannedStartTime;
                    drugOrderIntroductionDet.Day = (int)_DrugOrderIntroduction.OrderDay;
                    drugOrderIntroductionDet.PatientOwnDrug = _DrugOrderIntroduction.PatientOwnDrug;
                    double dose = 1;
                    if (_DrugOrderIntroduction.Dose != null)
                        dose = (double)_DrugOrderIntroduction.Dose;
                    drugOrderIntroductionDet.DoseAmount = dose * _DrugOrderIntroduction.OrderDose;
                    switch (_DrugOrderIntroduction.OrderFrequency.ToString())
                    {
                        case "1":
                            {
                                drugOrderIntroductionDet.Frequency = FrequencyEnum.Q24H;
                                break;
                            }
                        case "2":
                            {
                                drugOrderIntroductionDet.Frequency = FrequencyEnum.Q12H;
                                break;
                            }
                        case "3":
                            {
                                drugOrderIntroductionDet.Frequency = FrequencyEnum.Q8H;
                                break;
                            }
                        case "4":
                            {
                                drugOrderIntroductionDet.Frequency = FrequencyEnum.Q6H;
                                break;
                            }
                        case "6":
                            {
                                drugOrderIntroductionDet.Frequency = FrequencyEnum.Q4H;
                                break;
                            }
                        case "8":
                            {
                                drugOrderIntroductionDet.Frequency = FrequencyEnum.Q3H;
                                break;
                            }
                        case "12":
                            {
                                drugOrderIntroductionDet.Frequency = FrequencyEnum.Q2H;
                                break;
                            }
                        case "24":
                            {
                                drugOrderIntroductionDet.Frequency = FrequencyEnum.Q1H;
                                break;
                            }
                        default:
                            {
                                throw new TTException(" Yazdığınız doz aralığı planlamaya uygun değildir.");
                                //break;
                            }
                    }

                    drugOrderIntroductionDet.DrugOrderIntroduction = _DrugOrderIntroduction;
                    _DrugOrderIntroduction.CreateDrugOrder(drugOrderIntroductionDet);
                    if (drugOrderIntroductionDet != null)
                    {
                        if (drugOrderIntroductionDet.DrugOrder != null)
                        {

                            if (gunuBirlikHastaMi)
                                _DrugOrderIntroduction.AddOutpatientPrescription(drugOrderIntroductionDet);
                            else
                                _DrugOrderIntroduction.AddInpatientPrescription(drugOrderIntroductionDet);

                            this.OrderFrequency.Text = string.Empty;
                            this.OrderDose.Text = string.Empty;
                            this.OrderDay.Text = string.Empty;
                            this.DrugUsageType = null;
                        }
                        else
                            ((ITTObject)drugOrderIntroductionDet).Delete();
                    }
                }
            }
            else
                InfoBox.Alert(errorMsg, MessageIconEnum.ErrorMessage);

            //            if (_DrugOrderIntroduction.CheckFavoriteDrug == false)
            //            {
            //                Guid drugGuid = new Guid(this.DrugListview.SelectedItems[0].SubItems[2].Text);
            //                DrugDefinition drug =(DrugDefinition)_DrugOrderIntroduction.ObjectContext.GetObject(drugGuid, typeof(DrugDefinition));
            //                DrugOrderIntroductionDet drugOrderIntroductionDet = new DrugOrderIntroductionDet(_DrugOrderIntroduction.ObjectContext);
            //                drugOrderIntroductionDet.Material = drug;
            //                drugOrderIntroductionDet.PlannedStartTime = (DateTime)_DrugOrderIntroduction.PlannedStartTime;
            //                drugOrderIntroductionDet.DrugOrderIntroduction = _DrugOrderIntroduction;
            //            }
            //            else
            //            {
            //                foreach (ITTListViewItem item in this.FavoriteDrugListview.SelectedItems)
            //                {
            //                    Guid drugGuid = new Guid(item.SubItems[1].Text);
            //                    DrugDefinition drug = (DrugDefinition)_DrugOrderIntroduction.ObjectContext.GetObject(drugGuid, typeof(DrugDefinition));
            //                    DrugOrderIntroductionDet drugOrderIntroductionDet = new DrugOrderIntroductionDet(_DrugOrderIntroduction.ObjectContext);
            //                    drugOrderIntroductionDet.Material = drug;
            //                    drugOrderIntroductionDet.PlannedStartTime = (DateTime)_DrugOrderIntroduction.PlannedStartTime;
            //                    drugOrderIntroductionDet.DrugOrderIntroduction = _DrugOrderIntroduction;
            //                }
            //            }
#endregion DrugOrderIntroductionNewForm_cmdAddDrug_Click
        }

        private void SearchTextbox_TextChanged()
        {
#region DrugOrderIntroductionNewForm_SearchTextbox_TextChanged
   if ((bool)_DrugOrderIntroduction.AutoSearch.HasValue && (bool)_DrugOrderIntroduction.AutoSearch)
                if (this.SearchTextbox.Text.Length > 2)
                    SearchDrug(this.SearchTextbox.Text);
#endregion DrugOrderIntroductionNewForm_SearchTextbox_TextChanged
        }

        private void DrugListview_DoubleClick()
        {
#region DrugOrderIntroductionNewForm_DrugListview_DoubleClick
   //Guid drugGuid = new Guid(this.DrugListview.SelectedItems[0].SubItems[2].Text);
            //_DrugOrderIntroduction.AddDrug(drugGuid, (DateTime)_DrugOrderIntroduction.PlannedStartTime);
#endregion DrugOrderIntroductionNewForm_DrugListview_DoubleClick
        }

        private void DrugListview_SelectedIndexChanged()
        {
#region DrugOrderIntroductionNewForm_DrugListview_SelectedIndexChanged
   if (this.DrugListview.SelectedItems.Count > 0)
            {
                Guid drugGuid = new Guid(this.DrugListview.SelectedItems[0].SubItems[3].Text);
                DrugDefinition drug = (DrugDefinition)_DrugOrderIntroduction.ObjectContext.GetObject(drugGuid, typeof(DrugDefinition));
                _DrugOrderIntroduction.DrugName = drug.Name;
                _DrugOrderIntroduction.Dose = drug.Dose;
                _DrugOrderIntroduction.Volume = drug.Volume;
                if (drug.Unit != null)
                    _DrugOrderIntroduction.Unit = drug.Unit.Name;
                _DrugOrderIntroduction.RoutineDay = drug.RoutineDay;
                _DrugOrderIntroduction.RoutineDose = drug.RoutineDose;
                _DrugOrderIntroduction.Frequency = drug.Frequency;
                _DrugOrderIntroduction.MaxDose = drug.MaxDose;
                _DrugOrderIntroduction.MaxDoseDay = drug.MaxDoseDay;
                _DrugOrderIntroduction.DrugObjectID = drug.ObjectID;
            }
            else
            {
                _DrugOrderIntroduction.DrugName = string.Empty;
                _DrugOrderIntroduction.Dose = null;
                _DrugOrderIntroduction.Volume = null;
                _DrugOrderIntroduction.Unit = null;
                _DrugOrderIntroduction.RoutineDay = null;
                _DrugOrderIntroduction.RoutineDose = null;
                _DrugOrderIntroduction.Frequency = null;
                _DrugOrderIntroduction.MaxDose = null;
                _DrugOrderIntroduction.MaxDoseDay = null;
                _DrugOrderIntroduction.DrugObjectID = null;

            }
#endregion DrugOrderIntroductionNewForm_DrugListview_SelectedIndexChanged
        }

        private void cmdGetTemplate_Click()
        {
#region DrugOrderIntroductionNewForm_cmdGetTemplate_Click
   IList userTemplates = _DrugOrderIntroduction.ObjectContext.QueryObjects("USERTEMPLATE", "RESUSER =" + ConnectionManager.GuidToString(Common.CurrentResource.ObjectID) + "AND TAOBJECTDEFID = " + ConnectionManager.GuidToString(_DrugOrderIntroduction.ObjectDef.ID) + " AND FILITERDATA ='DrugOrderIntroduction'");

            if (userTemplates.Count > 0)
            {
                MultiSelectForm pForm = new MultiSelectForm();
                foreach (UserTemplate userTemplate in userTemplates)
                {
                    pForm.AddMSItem(userTemplate.Description, userTemplate.ObjectID.ToString(), userTemplate);

                }
                string sKey = pForm.GetMSItem(this, "Şablon seçiniz.", false, false, false, false, true, false);
                if (!String.IsNullOrEmpty(sKey))
                {
                    UserTemplate selectedTemplate = (UserTemplate)pForm.MSSelectedItemObject;
                    DrugOrderIntroduction drugOrderIntroduction = (DrugOrderIntroduction)_DrugOrderIntroduction.ObjectContext.GetObject((Guid)selectedTemplate.TAObjectID, (Guid)selectedTemplate.TAObjectDefID);

                    foreach (DrugOrderIntroductionDet introductionDet in drugOrderIntroduction.DrugOrderIntroductionDetails)
                    {
                        DrugOrderIntroductionDet drugOrderIntroductionDet = new DrugOrderIntroductionDet(_DrugOrderIntroduction.ObjectContext);
                        drugOrderIntroductionDet.Material = introductionDet.Material;
                        drugOrderIntroductionDet.PlannedStartTime = (DateTime)_DrugOrderIntroduction.PlannedStartTime;
                        drugOrderIntroductionDet.Day = introductionDet.Day;
                        drugOrderIntroductionDet.DoseAmount = introductionDet.DoseAmount;
                        drugOrderIntroductionDet.Frequency = introductionDet.Frequency;
                        drugOrderIntroductionDet.DrugOrderIntroduction = _DrugOrderIntroduction;
                        _DrugOrderIntroduction.CreateDrugOrder(drugOrderIntroductionDet);
                        _DrugOrderIntroduction.AddInpatientPrescription(drugOrderIntroductionDet);
                    }
                }
            }
            else
                InfoBox.Alert("Herhangibir reçete şablonunuz bulunmamaktadır", MessageIconEnum.InformationMessage);
#endregion DrugOrderIntroductionNewForm_cmdGetTemplate_Click
        }

        private void cmdAddTemplate_Click()
        {
#region DrugOrderIntroductionNewForm_cmdAddTemplate_Click
   string description = InputForm.GetText("Şablon Açıklaması");
            if (string.IsNullOrEmpty(description) == false)
            {
                IList userTemplates = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(_DrugOrderIntroduction.ObjectDef.ID) + " AND DESCRIPTION = '" + description + "'");

                if (userTemplates.Count == 0)
                {
                    UserTemplate userTemplate = new UserTemplate(_DrugOrderIntroduction.ObjectContext);
                    userTemplate.ResUser = (ResUser)Common.CurrentResource;
                    userTemplate.Description = description;
                    userTemplate.TAObjectID = _DrugOrderIntroduction.ObjectID;
                    userTemplate.TAObjectDefID = _DrugOrderIntroduction.ObjectDef.ID;
                    userTemplate.FiliterData = "DrugOrderIntroduction";
                    this.cmdAddTemplate.Enabled = false;
                }
                else
                {
                    InfoBox.Alert(description + " isimli şablonunuz bulunduğu için şablon kayıt edilemedi", MessageIconEnum.ErrorMessage);
                }
            }
            else
                InfoBox.Alert("Şablona isim vermeden kaydedemezsiniz.", MessageIconEnum.ErrorMessage);
#endregion DrugOrderIntroductionNewForm_cmdAddTemplate_Click
        }

        private void FavoriteDrugListview_SelectedIndexChanged()
        {
#region DrugOrderIntroductionNewForm_FavoriteDrugListview_SelectedIndexChanged
   if (this.FavoriteDrugListview.SelectedItems.Count > 0)
            {
                Guid drugGuid = new Guid(this.FavoriteDrugListview.SelectedItems[0].SubItems[2].Text);
                DrugDefinition drug = (DrugDefinition)_DrugOrderIntroduction.ObjectContext.GetObject(drugGuid, typeof(DrugDefinition));
                _DrugOrderIntroduction.DrugName = drug.Name;
                _DrugOrderIntroduction.Dose = drug.Dose;
                _DrugOrderIntroduction.Volume = drug.Volume;
                if (drug.Unit != null)
                    _DrugOrderIntroduction.Unit = drug.Unit.Name;
                _DrugOrderIntroduction.RoutineDay = drug.RoutineDay;
                _DrugOrderIntroduction.RoutineDose = drug.RoutineDose;
                _DrugOrderIntroduction.Frequency = drug.Frequency;
                _DrugOrderIntroduction.MaxDose = drug.MaxDose;
                _DrugOrderIntroduction.MaxDoseDay = drug.MaxDoseDay;
                _DrugOrderIntroduction.DrugObjectID = drug.ObjectID;
            }
            else
            {
                _DrugOrderIntroduction.DrugName = string.Empty;
                _DrugOrderIntroduction.Dose = null;
                _DrugOrderIntroduction.Volume = null;
                _DrugOrderIntroduction.Unit = null;
                _DrugOrderIntroduction.RoutineDay = null;
                _DrugOrderIntroduction.RoutineDose = null;
                _DrugOrderIntroduction.Frequency = null;
                _DrugOrderIntroduction.MaxDose = null;
                _DrugOrderIntroduction.MaxDoseDay = null;
                _DrugOrderIntroduction.DrugObjectID = null;

            }
#endregion DrugOrderIntroductionNewForm_FavoriteDrugListview_SelectedIndexChanged
        }

        private void OldDrugOrders_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DrugOrderIntroductionNewForm_OldDrugOrders_CellContentClick
   if (rowIndex < this.OldDrugOrders.Rows.Count && rowIndex > -1)
            {
                if (columnIndex == 0)
                {
                    string result = "E";// ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Uyarı", "Bu Direktifi tekrarlamak istediğinize emin misiniz?", "", 1);
                    if (result == "E")
                    {
                        string tresult = "E";
                        bool getTime = false;

                        if (tresult == "E")
                        {
                            DateTime? bTarih = InputForm.GetDateTime("Planlama Başlangıç Zamanı Seçiniz", "dd/mm/yyyy hh:mm");
                            if (bTarih == null)
                            {
                                tresult = "H"; // ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Uyarı", "Planlama Başlangıç Zamanını girmeden talimat tekrarlıyamazsınız.Talimatı tekrarlamak istediğinize emin misiniz?", "", 1);
                                if (tresult == "H")
                                {
                                    getTime = true;
                                    InfoBox.Alert("Direktif Tekrardan vazgeçildi");
                                }
                            }
                            else
                            {
                                DrugOrder rptDrugOrder = ((OldDrugOrder)((ITTGridRow)this.OldDrugOrders.Rows[rowIndex]).TTObject).DrugOrder;
                                DrugOrderIntroductionDet drugOrderIntroductionDet = new DrugOrderIntroductionDet(_DrugOrderIntroduction.ObjectContext);
                                drugOrderIntroductionDet.Material = rptDrugOrder.Material;
                                drugOrderIntroductionDet.Day = rptDrugOrder.Day;
                                drugOrderIntroductionDet.DoseAmount = rptDrugOrder.DoseAmount;
                                drugOrderIntroductionDet.Frequency = rptDrugOrder.Frequency;
                                drugOrderIntroductionDet.PatientOwnDrug = rptDrugOrder.PatientOwnDrug;
                                drugOrderIntroductionDet.PlannedStartTime = bTarih;
                                drugOrderIntroductionDet.UsageNote = rptDrugOrder.UsageNote;
                                drugOrderIntroductionDet.DrugOrderIntroduction = _DrugOrderIntroduction;
                                _DrugOrderIntroduction.CreateDrugOrder(drugOrderIntroductionDet);
                                _DrugOrderIntroduction.AddInpatientPrescription(drugOrderIntroductionDet);
                            }
                        }
                    }
                    else
                    {
                        InfoBox.Alert("Direktif Tekrardan vazgeçildi");
                    }

                }
            }
#endregion DrugOrderIntroductionNewForm_OldDrugOrders_CellContentClick
        }

        private void cmdFavoriteDrug_Click()
        {
#region DrugOrderIntroductionNewForm_cmdFavoriteDrug_Click
   if (_DrugOrderIntroduction.OrderDay == null)
                throw new TTException("Direktif günü boş olamaz.");
            if (_DrugOrderIntroduction.PlannedStartTime == null)
                throw new TTException("Uygulama Başlangıç Zamanı boş olamaz");
            if (_DrugOrderIntroduction.OrderDose == null)
                throw new TTException("Direktif dozu boş olamaz.");
            if (_DrugOrderIntroduction.OrderFrequency == null)
                throw new TTException("Direktif doz aralığı boş olamaz.");

            if (_DrugOrderIntroduction.DrugObjectID != null)
            {
                DrugDefinition drug = (DrugDefinition)_DrugOrderIntroduction.ObjectContext.GetObject((Guid)_DrugOrderIntroduction.DrugObjectID, typeof(DrugDefinition));
                DrugOrderIntroductionDet drugOrderIntroductionDet = new DrugOrderIntroductionDet(_DrugOrderIntroduction.ObjectContext);
                drugOrderIntroductionDet.Material = drug;
                drugOrderIntroductionDet.PlannedStartTime = (DateTime)_DrugOrderIntroduction.PlannedStartTime;
                drugOrderIntroductionDet.Day = (int)_DrugOrderIntroduction.OrderDay;
                drugOrderIntroductionDet.DoseAmount = _DrugOrderIntroduction.Dose * _DrugOrderIntroduction.OrderDose;
                switch (_DrugOrderIntroduction.OrderFrequency.ToString())
                {
                    case "1":
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q24H;
                            break;
                        }
                    case "2":
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q12H;
                            break;
                        }
                    case "3":
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q8H;
                            break;
                        }
                    case "4":
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q6H;
                            break;
                        }
                    case "6":
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q4H;
                            break;
                        }
                    case "8":
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q3H;
                            break;
                        }
                    case "12":
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q2H;
                            break;
                        }
                    case "24":
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q1H;
                            break;
                        }
                    default:
                        {
                            throw new TTException(" Yazdığınız doz aralığı planlamaya uygun değildir.");
                            //break;
                        }
                }

                drugOrderIntroductionDet.DrugOrderIntroduction = _DrugOrderIntroduction;
                _DrugOrderIntroduction.CreateDrugOrder(drugOrderIntroductionDet);
                _DrugOrderIntroduction.AddInpatientPrescription(drugOrderIntroductionDet);
                this.FavoriteDrugFrequency.Text = string.Empty;
                this.FavoriteDrugDose.Text = string.Empty;
                this.FavoriteDrugDay.Text = string.Empty;
            }
            else
                throw new TTException("İlaç seçmediniz.");
#endregion DrugOrderIntroductionNewForm_cmdFavoriteDrug_Click
        }

        protected override void PreScript()
        {
#region DrugOrderIntroductionNewForm_PreScript
    base.PreScript();

            if (_DrugOrderIntroduction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) == true)
            {
                SecondaryMasterResource.ReadOnly = false;
                EpisodeAction firstAction = _DrugOrderIntroduction.Episode.EpisodeActions[0];
                if (firstAction != null)
                {
                    _DrugOrderIntroduction.SecondaryMasterResource = firstAction.SecondaryMasterResource;
                    if (_DrugOrderIntroduction.SecondaryMasterResource == null)
                        _DrugOrderIntroduction.SecondaryMasterResource = firstAction.MasterResource;
                }
                tttabcontrol1.HideTabPage(PrescriptionTabPage);
            }
            else
            {
                tttabcontrol1.HideTabPage(OutPatientTabPage);
                SecondaryMasterResource.ReadOnly = true;
            }

            TTDateTimePicker startDate = ((TTDateTimePicker)this.PlannedStartTime);
            startDate.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + "08:00:00");
            _DrugOrderIntroduction.PatientOwnDrug = false;
            _DrugOrderIntroduction.CheckFavoriteDrug = false;
            _DrugOrderIntroduction.AutoSearch = true;
            _DrugOrderIntroduction.IsInheldDrug = false;
            _DrugOrderIntroduction.IsBarcode = false;
            bool isInpatientApp = false;

        
            bool gunuBirlikHastaMi = _DrugOrderIntroduction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily);
            if (gunuBirlikHastaMi)
                _DrugOrderIntroduction.IsInheldDrug = true;


            foreach (InPatientTreatmentClinicApplication app in _DrugOrderIntroduction.Episode.InPatientTreatmentClinicApplications)
            {
                if (app.InPatientPhysicianApplication.Count > 0)
                    isInpatientApp = true;

                foreach (InPatientPhysicianApplication pApp in app.InPatientPhysicianApplication)
                {
                    if (pApp.CurrentStateDefID == InPatientPhysicianApplication.States.Application)
                    {
                        _DrugOrderIntroduction.ActiveInPatientPhysicianApp = pApp;
                        foreach (DrugOrder order in app.InPatientPhysicianApplication[0].DrugOrders)
                        {
                            OldDrugOrder oldDrugOrder = new OldDrugOrder(_DrugOrderIntroduction.ObjectContext);
                            oldDrugOrder.DrugOrder = order;
                            oldDrugOrder.DrugOrderIntroduction = _DrugOrderIntroduction;
                        }
                    }
                }
            }

            _DrugOrderIntroduction.UseRoutineValue = false;

            // Günübirlik hasta için İlaç Direktifi verilebilsin A.Ş. 2016.01.18
           
            
            if (_DrugOrderIntroduction.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily) == false)
                if (_DrugOrderIntroduction.ActiveInPatientPhysicianApp == null)
                    throw new TTException("Hastanın Klinik Doktor işlemi bulunmadığından ilaç direktifi veremezsiniz");


            IBindingList drugs = FavoriteDrug.GetFavoriteDrugs(((ResUser)Common.CurrentUser.UserObject).ObjectID);

            foreach (FavoriteDrug.GetFavoriteDrugs_Class d in drugs)
            {
                ITTListViewItem item = FavoriteDrugListview.Items.Add(d.Name);
                item.SubItems.Add(d.Miktar.ToString());
                item.SubItems.Add(d.DrugDefinition.ToString());
            }



            //            IBindingList drugs = _DrugOrderIntroduction.ObjectContext.QueryObjects("FAVORITEDRUG", "RESUSER =" + ConnectionManager.GuidToString(((ResUser)Common.CurrentUser.UserObject).ObjectID));
            //            Hashtable unSortedFavoriteDrugList = new Hashtable();
            //
            //
            //            foreach (FavoriteDrug favoriteDrug in drugs)
            //            {
            //                if (unSortedFavoriteDrugList.ContainsKey(favoriteDrug.DrugDefinition) == false)
            //                {
            //                    Common.TTDoubleSortableList favoriteDrugListItem = new Common.TTDoubleSortableList();
            //                    favoriteDrugListItem.ID = favoriteDrug.DrugDefinition;
            //                    favoriteDrugListItem.Value = (double)favoriteDrug.Count;
            //                    unSortedFavoriteDrugList.Add(favoriteDrugListItem.ID, favoriteDrugListItem);
            //                }
            //            }
            //
            //            List<Common.TTDoubleSortableList> favoriteDrugList = Common.SortedDoubleItems(unSortedFavoriteDrugList);
            //            favoriteDrugList.Reverse();
            //            foreach (Common.TTDoubleSortableList sortList in favoriteDrugList)
            //            {
            //                ITTListViewItem item = FavoriteDrugListview.Items.Add(((DrugDefinition)sortList.ID).Name);
            //                item.SubItems.Add(sortList.Value.ToString());
            //                item.SubItems.Add(((DrugDefinition)sortList.ID).ObjectID.ToString());
            //            }

            Dictionary<Guid, SPTSDiagnosisInfo> diagnosisInfo = new Dictionary<Guid, SPTSDiagnosisInfo>();
            Dictionary<Guid, DiagnosisDefinition> diags = new Dictionary<Guid, DiagnosisDefinition>();

            foreach (DiagnosisGrid diag in _DrugOrderIntroduction.Episode.Diagnosis)
            {
                if (!diags.ContainsKey(diag.Diagnose.ObjectID))
                    diags.Add(diag.Diagnose.ObjectID, diag.Diagnose);
            }

            if (diags.Count > 0)
            {
                foreach (KeyValuePair<Guid, DiagnosisDefinition> diag in diags)
                {
                    DiagnosisForPresc diagForPresc = new DiagnosisForPresc(_DrugOrderIntroduction.ObjectContext);
                    diagForPresc.Code = diag.Value.Code;
                    diagForPresc.Name = diag.Value.Name.ToString();
                    diagForPresc.DrugOrderIntroduction = _DrugOrderIntroduction;
                    foreach (SPTSMatchICD SPTSDiag in diag.Value.SPTSMatchICDs)
                    {
                        if (!diagnosisInfo.ContainsKey(SPTSDiag.SPTSDiagnosisInfo.ObjectID))
                        {
                            diagnosisInfo.Add(SPTSDiag.SPTSDiagnosisInfo.ObjectID, SPTSDiag.SPTSDiagnosisInfo);
                        }
                    }
                }
                if (diagnosisInfo.Count > 0)
                {
                    foreach (KeyValuePair<Guid, SPTSDiagnosisInfo> diagnosisSPTS in diagnosisInfo)
                    {
                        DiagnosisForSPTS diagnosisForSPTS = new DiagnosisForSPTS(_DrugOrderIntroduction.ObjectContext);
                        diagnosisForSPTS.SPTSDiagnosisInfo = ((SPTSDiagnosisInfo)diagnosisSPTS.Value);
                        diagnosisForSPTS.DrugOrderIntroduction = _DrugOrderIntroduction;
                    }
                }
            }
#endregion DrugOrderIntroductionNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DrugOrderIntroductionNewForm_PostScript
    base.PostScript(transDef);
#endregion DrugOrderIntroductionNewForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region DrugOrderIntroductionNewForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef.ToStateDefID == DrugOrderIntroduction.States.Completed)
            {
                if (_DrugOrderIntroduction.InpatientPresDetails.Count > 0)
                {
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                    ((ITTObject)currentUser).Refresh();

                    if (SubEpisode.IsSGKSubEpisode(_DrugOrderIntroduction.SubEpisode))
                    {
                        if (string.IsNullOrEmpty(currentUser.ErecetePassword))
                        {
                            TTVisual.TTForm passwordForm = new TTFormClasses.DrugOrderIntPasswordForm();
                            passwordForm.ShowEdit(this, _DrugOrderIntroduction, true);
                        }
                        else
                            _DrugOrderIntroduction.ERecetePassword = currentUser.ErecetePassword;

                        if (string.IsNullOrEmpty(_DrugOrderIntroduction.ERecetePassword))
                            throw new TTException("E reçete şifresi girilmediği için işlemden vazgeçildi");
                    }
                }
                
                string message = string.Empty;
                foreach (InpatientPresDetail detail in _DrugOrderIntroduction.InpatientPresDetails)
                {
                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
                    {
                        message = message + "Normal Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder normal in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + normal.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
                    {
                        message = message + "Yeşil Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder green in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + green.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
                    {
                        message = message + "Turuncu Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder orange in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + orange.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
                    {
                        message = message + "Kırmızı Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder red in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + red.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
                    {
                        message = message + "Mor Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder purple in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + purple.Material.Name.ToString() + "\r\n";
                    }
                }

                foreach (OutpatientPresDetail detail in _DrugOrderIntroduction.OutpatientPresDetails)
                {
                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
                    {
                        message = message + "Normal Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder normal in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + normal.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
                    {
                        message = message + "Yeşil Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder green in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + green.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
                    {
                        message = message + "Turuncu Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder orange in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + orange.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
                    {
                        message = message + "Kırmızı Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder red in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + red.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
                    {
                        message = message + "Mor Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder purple in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + purple.Material.Name.ToString() + "\r\n";
                    }
                }

                if (message != string.Empty)
                {
                    string result = "T";// ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Reçete Türü", "Yatan Hasta Reçetesine Çıkacak ilaçların Reçete Türü : \r\n" + message + "\r\n" + "Devam Etmek İstiyor Musunuz?");
                    if (result == "V")
                    {
                        throw new Exception(SystemMessage.GetMessage(719));
                    }
                }

                if (_DrugOrderIntroduction.InpatientPresDetails.Count > 0)
                {
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                    _DrugOrderIntroduction.ERecetePassword = currentUser.ErecetePassword;
                    _DrugOrderIntroduction.SendERecete();
                    _DrugOrderIntroduction.SendEReceteEHUApproval();
                }

                if (_DrugOrderIntroduction.OutpatientPresDetails.Count > 0)
                {
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                    _DrugOrderIntroduction.ERecetePassword = currentUser.ErecetePassword;
                    _DrugOrderIntroduction.SendDailyERecete();
                }
            }
            
            if (transDef.ToStateDefID == DrugOrderIntroduction.States.CompletedWithSign)
            {
                string message = string.Empty;
                foreach (InpatientPresDetail detail in _DrugOrderIntroduction.InpatientPresDetails)
                {
                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
                    {
                        message = message + "Normal Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder normal in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + normal.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
                    {
                        message = message + "Yeşil Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder green in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + green.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
                    {
                        message = message + "Turuncu Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder orange in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + orange.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
                    {
                        message = message + "Kırmızı Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder red in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + red.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.InpatientPrescription.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
                    {
                        message = message + "Mor Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (InpatientDrugOrder purple in detail.InpatientPrescription.InpatientDrugOrders)
                            message = message + purple.Material.Name.ToString() + "\r\n";
                    }
                }

                foreach (OutpatientPresDetail detail in _DrugOrderIntroduction.OutpatientPresDetails)
                {
                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.NormalPrescription)
                    {
                        message = message + "Normal Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder normal in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + normal.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.GreenPrescription)
                    {
                        message = message + "Yeşil Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder green in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + green.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.OrangePrescription)
                    {
                        message = message + "Turuncu Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder orange in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + orange.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.RedPrescription)
                    {
                        message = message + "Kırmızı Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder red in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + red.Material.Name.ToString() + "\r\n";
                    }

                    if (detail.OutPatientPrescription.PrescriptionType == PrescriptionTypeEnum.PurplePrescription)
                    {
                        message = message + "Mor Reçeteye Çıkacak İlaçlar: \r\n";
                        foreach (OutPatientDrugOrder purple in detail.OutPatientPrescription.OutPatientDrugOrders)
                            message = message + purple.Material.Name.ToString() + "\r\n";
                    }
                }

                if (message != string.Empty)
                {
                    string result = "T";// ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Reçete Türü", "Yatan Hasta Reçetesine Çıkacak ilaçların Reçete Türü : \r\n" + message + "\r\n" + "Devam Etmek İstiyor Musunuz?");
                    if (result == "V")
                    {
                        throw new Exception(SystemMessage.GetMessage(719));
                    }
                }

                if (_DrugOrderIntroduction.InpatientPresDetails.Count > 0)
                {
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                    _DrugOrderIntroduction.ERecetePassword = currentUser.ErecetePassword;
                    _DrugOrderIntroduction.SendERecete();
                    _DrugOrderIntroduction.SendEReceteEHUApproval();
                }

                if (_DrugOrderIntroduction.OutpatientPresDetails.Count > 0)
                {
                    ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                    _DrugOrderIntroduction.ERecetePassword = currentUser.ErecetePassword;
                    _DrugOrderIntroduction.SendDailyERecete();
                }
            }
#endregion DrugOrderIntroductionNewForm_ClientSidePostScript

        }

#region DrugOrderIntroductionNewForm_Methods
        public void SearchDrug(string Name)
        {
            this.DrugListview.Items.Clear();
            TTObjectContext context = new TTObjectContext(true);
            string filiter = "NAME_SHADOW like '" + Name + "%'";

            if ((bool)_DrugOrderIntroduction.IsBarcode == true)
                filiter = filiter + " AND BARCODE IS NOT NULL";

            IList drugs = context.QueryObjects("DRUGDEFINITION", filiter);
            if ((bool)_DrugOrderIntroduction.IsInheldDrug == true)
            {
                foreach (DrugDefinition drug in drugs)
                {
                    if (drug.PharmacyInheldStatus == "Var")
                    {
                        ITTListViewItem item = this.DrugListview.Items.Add(drug.Name);
                        item.SubItems.Add(drug.Barcode);
                        item.SubItems.Add(drug.PharmacyInheldStatus);
                        item.SubItems.Add(drug.ObjectID.ToString());
                    }
                }
            }
            else
            {
                foreach (DrugDefinition drug in drugs)
                {
                    ITTListViewItem item = this.DrugListview.Items.Add(drug.Name);
                    item.SubItems.Add(drug.Barcode);
                    item.SubItems.Add(drug.PharmacyInheldStatus);
                    item.SubItems.Add(drug.ObjectID.ToString());
                }
            }
        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                foreach (InpatientPresDetail item in _DrugOrderIntroduction.InpatientPresDetails)
                {
                    Guid objectid = item.InpatientPrescription.ObjectID;

                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                    TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
                    pc.Add("VALUE", objectid);
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.PropertyCache<object> pc1 = new TTReportTool.PropertyCache<object>();
                    pc1.Add("VALUE", item.InpatientPrescription.PrescriptionType);
                    parameters.Add("PRESCRIPTIONTYPE", pc1);
                    TTReportTool.TTReport.PrintReport((typeof(TTReportClasses.I_PrescriptionReportByDrungOrderIntroduction)), true, 1, parameters);
                }
            }
        }
        
#endregion DrugOrderIntroductionNewForm_Methods
    }
}