
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
    public partial class MedulaDiabetTakipFormuIslemleri : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbuttonDiyabetTakipFormuKaydet.Click += new TTControlEventDelegate(ttbuttonDiyabetTakipFormuKaydet_Click);
            cmdSaveAsTemplate.Click += new TTControlEventDelegate(cmdSaveAsTemplate_Click);
            cmdDeleteTemplate.Click += new TTControlEventDelegate(cmdDeleteTemplate_Click);
            cmdLoadTemplate.Click += new TTControlEventDelegate(cmdLoadTemplate_Click);
            ttbuttonOku.Click += new TTControlEventDelegate(ttbuttonOku_Click);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbuttonDiyabetTakipFormuKaydet.Click -= new TTControlEventDelegate(ttbuttonDiyabetTakipFormuKaydet_Click);
            cmdSaveAsTemplate.Click -= new TTControlEventDelegate(cmdSaveAsTemplate_Click);
            cmdDeleteTemplate.Click -= new TTControlEventDelegate(cmdDeleteTemplate_Click);
            cmdLoadTemplate.Click -= new TTControlEventDelegate(cmdLoadTemplate_Click);
            ttbuttonOku.Click -= new TTControlEventDelegate(ttbuttonOku_Click);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            base.UnBindControlEvents();
        }

        private void ttbuttonDiyabetTakipFormuKaydet_Click()
        {
#region MedulaDiabetTakipFormuIslemleri_ttbuttonDiyabetTakipFormuKaydet_Click
   //            TTObjectContext context = new TTObjectContext(false);
//            this.MedulaDiabetTakipFormuKaydet(context);
#endregion MedulaDiabetTakipFormuIslemleri_ttbuttonDiyabetTakipFormuKaydet_Click
        }

        private void cmdSaveAsTemplate_Click()
        {
#region MedulaDiabetTakipFormuIslemleri_cmdSaveAsTemplate_Click
   //            TTObjectContext mycontext = new TTObjectContext(false);
//            string templateName = InputForm.GetText("Şablon adını giriniz.");
//            DiabetesMellitusPursuitTemplate dpsTemp = new DiabetesMellitusPursuitTemplate(mycontext);
//            dpsTemp.ResUser = Common.CurrentResource;
//            dpsTemp.TemplateName = templateName;
//            Patient myPatient =  (Patient) mycontext.QueryObjects("PATIENT", "OBJECTID = '" + tttxtboxAd.Tag + "'")[0];
//            if(myPatient.DiabetesMellitusPursuit != null)
//            {
//                myPatient.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt = dpsTemp;
//                // Ekrandan girilen değerler Diyabet takip alanlarına set ediliyor.
//                CloneDiabetesMellitusPursiut(myPatient.DiabetesMellitusPursuit);
//            }
//              if(myPatient.DiabetesMellitusPursuit == null)
//            {
//                  myPatient.DiabetesMellitusPursuit = new DiabetesMellitusPursuit(mycontext);
//                  myPatient.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt = dpsTemp;
//                // Ekrandan girilen değerler Diyabet takip alanlarına set ediliyor.
//                CloneDiabetesMellitusPursiut(myPatient.DiabetesMellitusPursuit);
//            }
//            
//            
//            
//            mycontext.Save();
//            mycontext.Dispose();
//            InfoBox.Show("Şablon kaydedildi.", MessageIconEnum.InformationMessage);
#endregion MedulaDiabetTakipFormuIslemleri_cmdSaveAsTemplate_Click
        }

        private void cmdDeleteTemplate_Click()
        {
#region MedulaDiabetTakipFormuIslemleri_cmdDeleteTemplate_Click
   //   TTObjectContext mycontext = new TTObjectContext(false);
//             Patient myPatient =  (Patient) mycontext.QueryObjects("PATIENT", "OBJECTID = '" + tttxtboxAd.Tag + "'")[0];
//             if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Mevcut şablon silinecek.\nDevam etmek istediğinize emin misiniz?") == "E")
//            {
//                if (myPatient.DiabetesMellitusPursuit != null && myPatient.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt != null)
//                {                    
//                    Guid objectID = myPatient.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt.ObjectID;
//                    IBindingList objects = mycontext.QueryObjects(typeof(DiabetesMellitusPursuit).Name, "DIABETESMELLITUSPURSUITTMPLT = '" + myPatient.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt.ObjectID.ToString() + "'");
//                    foreach (DiabetesMellitusPursuit pts in objects)
//                    {
//                        pts.DiabetesMellitusPursuitTmplt = null;
//                    }
//                    
//                    DiabetesMellitusPursuitTemplate tempToDel = (DiabetesMellitusPursuitTemplate)mycontext.GetObject(objectID, typeof(DiabetesMellitusPursuitTemplate).Name);
//                    ((ITTObject)tempToDel).Delete();
//                    mycontext.Save();
//                    mycontext.Dispose();
//                    InfoBox.Show("Şablon silindi.", MessageIconEnum.InformationMessage);
//                }
//            }
#endregion MedulaDiabetTakipFormuIslemleri_cmdDeleteTemplate_Click
        }

        private void cmdLoadTemplate_Click()
        {
#region MedulaDiabetTakipFormuIslemleri_cmdLoadTemplate_Click
   //   TTObjectContext context= new TTObjectContext(false);
//            Patient myPatient =  (Patient) context.QueryObjects("PATIENT", "OBJECTID = '" + tttxtboxAd.Tag + "'")[0];
//            IBindingList userTemlates = context.QueryObjects(typeof(DiabetesMellitusPursuitTemplate).Name, "RESUSER = '" + Common.CurrentResource.ObjectID.ToString() + "'");
//            if (userTemlates.Count == 0)
//                InfoBox.Show("Daha önce kaydettiğiniz bir şablon bulunmamaktadır.", MessageIconEnum.InformationMessage);
//            else
//            {
//                MultiSelectForm mSelectForm = new MultiSelectForm();
//                foreach (DiabetesMellitusPursuitTemplate dps in userTemlates)
//                    mSelectForm.AddMSItem(dps.TemplateName, dps.ObjectID.ToString(), dps);
//
//                string mkey = mSelectForm.GetMSItem(this, "Şablon seçiniz", true);
//                if (string.IsNullOrEmpty(mkey))
//                    return;
//                else
//                {
//                    IBindingList diabetesMellitusPursuits = context.QueryObjects(typeof(DiabetesMellitusPursuit).Name, "DIABETESMELLITUSPURSUITTMPLT = '" + ((DiabetesMellitusPursuitTemplate)mSelectForm.MSSelectedItemObject).ObjectID.ToString() + "'");
//                    if (diabetesMellitusPursuits.Count == 0)
//                    {
//                        InfoBox.Show("Seçtiğiniz şablonla kaydedilmiş herhangi bir diyabet takip raporuna ulaşılamadı!", MessageIconEnum.ErrorMessage);
//                        return;
//                    }
//                    else
//                    {
//                        DiabetesMellitusPursuit targetDiabetesMellitusPursuit = (DiabetesMellitusPursuit)diabetesMellitusPursuits[0];
//                        DiabetesMellitusPursuit newDiabetesMellitusPursuit = (DiabetesMellitusPursuit)((TTObject)targetDiabetesMellitusPursuit).Clone();
//                        
//                        //Hastaya ait Diabet Takip alanlarının değerleri atanıyor.
//                        
//                        newDiabetesMellitusPursuit.vizitTarihi = Common.RecTime().Date;
//                        newDiabetesMellitusPursuit.taniTarihi = null;
//                        newDiabetesMellitusPursuit.boy = null;
//                        newDiabetesMellitusPursuit.kilo = null;
//                        newDiabetesMellitusPursuit.vki = null;
//                        newDiabetesMellitusPursuit.insulinPompasiDegTarihi = null;
//                        newDiabetesMellitusPursuit.insulinPompasiVerTarihi = null;
//
//                        
//                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction != null) {
//                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction.Count; i++) {
//                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction.Add((DiabetesMellitusPursuitInstruction)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction[i].Clone());
//                                ITTGridRow row = this.DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows.Add();
//                                row.Cells[bireyselEgitimSayisiDiabetesMellitusPursuitInstruction.Name].Value =  ((DiabetesMellitusPursuitInstruction)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction[i]).bireyselEgitimSayisi;
//                                row.Cells[grupEgitimiSayisiDiabetesMellitusPursuitInstruction.Name].Value = ((DiabetesMellitusPursuitInstruction)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction[i]).grupEgitimiSayisi;
//                                row.Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitInstruction.Name].Value =  (EvetHayirDurumEnum)(((DiabetesMellitusPursuitInstruction)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction[i]).dmEgitimiAlmisMi.Value);
//                            }
//                        }
//                        
//                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor != null) {
//                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor.Count; i++) {
//                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor.Add((DiabetesMellitusPursuitDoctor)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor[i].Clone());
//                                ITTGridRow row = this.DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows.Add();
//                                row.Cells[drTescilNoDiabetesMellitusPursuitDoctor.Name].Value = targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor[i].drTescilNo != null ? targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor[i].drTescilNo : null ;
//                                row.Cells[drBransKoduDiabetesMellitusPursuitDoctor.Name].Value = targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor[i].BransKodu != null ? targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor[i].BransKodu : null;
//                                row.Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitDoctor.Name].Value = targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor[i].dmEgitimiAlmisMi != null ? targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor[i].dmEgitimiAlmisMi : null;
//                            }
//                        }
//                        
//                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit != null) {
//                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit.Count; i++) {
//                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit.Add((DiabetesMellitusPursuitHabit)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit[i].Clone());
//                                ITTGridRow row = this.DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows.Add();
//                                if(targetDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit[i].aliskanlik != null)
//                                row.Cells[aliskanlikDiabetesMellitusPursuitHabit.Name].Value =  (AliskanlikKoduEnum)((DiabetesMellitusPursuitHabit)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit[i]).aliskanlik.Value;
//                                
//                            }
//                        }
//                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug != null) {
//                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug.Count; i++) {
//                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug.Add((DiabetesMellitusPursuitUsedDrug)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug[i].Clone());
//                                ITTGridRow row = this.DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows.Add();
//                                row.Cells[barkodDiabetesMellitusPursuitUsedDrug.Name].Value = targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug[i].barkod != null ? ((DiabetesMellitusPursuitUsedDrug)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug[i]).barkod : null;
//                                row.Cells[gunlukDozDiabetesMellitusPursuitUsedDrug.Name].Value = ((DiabetesMellitusPursuitUsedDrug)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug[i]).gunlukDoz != null ?((DiabetesMellitusPursuitUsedDrug)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug[i]).gunlukDoz : null;
//                            }
//                        }
//                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease != null) {
//                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease.Count; i++) {
//                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease.Add((DiabetesMellitusPursuitDisease)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease[i].Clone());
//                                ITTGridRow row = this.DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows.Add();
//                                if(targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease[i].hastalikKodu != null)
//                                row.Cells[hastalikKoduDiabetesMellitusPursuitDisease.Name].Value =  (HastalikKoduEnum)(((DiabetesMellitusPursuitDisease)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease[i]).hastalikKodu.Value);
//                                row.Cells[digerHastalikTaniKoduDiabetesMellitusPursuitDisease.Name].Value = targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease[i].digerHastalikTaniKodu != null ? ((DiabetesMellitusPursuitDisease)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease[i]).digerHastalikTaniKodu : null ;
//                            }
//                            
//                        }
//                        
//                        myPatient.DiabetesMellitusPursuit = newDiabetesMellitusPursuit;
//                        
//                        // Ekran üzerindeki alanların değerleri atanıyor.
//                        vizitTarihiDiabetesMellitusPursuit.Text = Common.RecTime().Date.ToString();
//                        taniTarihiDiabetesMellitusPursuit.Text= null;
//                        boyDiabetesMellitusPursuit.Text = null;
//                        kiloDiabetesMellitusPursuit.Text = null;
//                        vkiDiabetesMellitusPursuit.Text = null;
//                        insulinPompasiDegTarihiDiabetesMellitusPursuit.Text = null;
//                        insulinPompasiVerTarihiDiabetesMellitusPursuit.Text = null;
//                        
//                        protokolNoDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.protokolNo;
//                        trigliseridDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.trigliserid!= null ? targetDiabetesMellitusPursuit.trigliserid.ToString() : null;
//                        kanSekeriTakipSayisiDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.kanSekeriTakipSayisi != null ? targetDiabetesMellitusPursuit.kanSekeriTakipSayisi.ToString() : null;
//                        altDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.alt != null ? targetDiabetesMellitusPursuit.alt.ToString() : null;
//                        hbA1cDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.hbA1c != null ? targetDiabetesMellitusPursuit.hbA1c.ToString() : null;
//                        diyastolikKanBasinciDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.diyastolikKanBasinci != null ? targetDiabetesMellitusPursuit.diyastolikKanBasinci.ToString() : null;
//                        sistolikKanBasinciDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.sistolikKanBasinci != null ? targetDiabetesMellitusPursuit.sistolikKanBasinci.ToString() : null;
//                        kreatininDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.kreatinin != null ? targetDiabetesMellitusPursuit.kreatinin.ToString() : null;
//                        yatisGunDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.yatisGun != null ? targetDiabetesMellitusPursuit.yatisGun.ToString() : null;
//                        tpgDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.tpg != null ? targetDiabetesMellitusPursuit.tpg.ToString() : null;
//                        apgDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.apg != null ? targetDiabetesMellitusPursuit.apg.ToString() : null;
//                        hdlKolDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.hdlKol != null ? targetDiabetesMellitusPursuit.hdlKol.ToString() : null;
//                        ldlKolDiabetesMellitusPursuit.Text = targetDiabetesMellitusPursuit.ldlKol != null ? targetDiabetesMellitusPursuit.ldlKol.ToString() : null;
//
//
//                        tibbiBeslenmeTedavisiDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.tibbiBeslenmeTedavisi != null && targetDiabetesMellitusPursuit.tibbiBeslenmeTedavisi.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.tibbiBeslenmeTedavisi.Value).Value : tibbiBeslenmeTedavisiDiabetesMellitusPursuit.SelectedIndex;
//                        akutKomplikasyonDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.akutKomplikasyon != null && targetDiabetesMellitusPursuit.akutKomplikasyon.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.akutKomplikasyon.Value).Value : akutKomplikasyonDiabetesMellitusPursuit.SelectedIndex;
//                        antiGADDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.antiGAD != null && targetDiabetesMellitusPursuit.antiGAD.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.antiGAD.Value).Value : antiGADDiabetesMellitusPursuit.SelectedIndex;
//                        ayakMuayenesiDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.ayakMuayenesi != null && targetDiabetesMellitusPursuit.ayakMuayenesi.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.ayakMuayenesi.Value).Value : ayakMuayenesiDiabetesMellitusPursuit.SelectedIndex;
//                        basvuruNedeniDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.basvuruNedeni != null && targetDiabetesMellitusPursuit.basvuruNedeni.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.basvuruNedeni.Value).Value : basvuruNedeniDiabetesMellitusPursuit.SelectedIndex;
//                        serebrovaskulerHDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.serebrovaskulerH != null && targetDiabetesMellitusPursuit.serebrovaskulerH.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.serebrovaskulerH.Value).Value : serebrovaskulerHDiabetesMellitusPursuit.SelectedIndex;
//                        glukoMetreDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.glukoMetre != null && targetDiabetesMellitusPursuit.glukoMetre.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.glukoMetre.Value).Value : glukoMetreDiabetesMellitusPursuit.SelectedIndex;
//                        gozMuayenesiDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.gozMuayenesi != null && targetDiabetesMellitusPursuit.gozMuayenesi.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.gozMuayenesi.Value).Value : gozMuayenesiDiabetesMellitusPursuit.SelectedIndex;
//                        ikametTuruDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.ikametTuru != null && targetDiabetesMellitusPursuit.ikametTuru.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.ikametTuru.Value).Value : ikametTuruDiabetesMellitusPursuit.SelectedIndex;
//                        egzersizDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.egzersiz != null && targetDiabetesMellitusPursuit.egzersiz.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.egzersiz.Value).Value : egzersizDiabetesMellitusPursuit.SelectedIndex;
//                        ekgDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.ekg != null && targetDiabetesMellitusPursuit.ekg.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.ekg.Value).Value : ekgDiabetesMellitusPursuit.SelectedIndex;
//                        koronerArterHDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.koronerArterH != null && targetDiabetesMellitusPursuit.koronerArterH.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.koronerArterH.Value).Value : koronerArterHDiabetesMellitusPursuit.SelectedIndex;
//                        mikroalbuminuriDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.mikroalbuminuri != null && targetDiabetesMellitusPursuit.mikroalbuminuri.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.mikroalbuminuri.Value).Value : mikroalbuminuriDiabetesMellitusPursuit.SelectedIndex;
//                        periferikSensoryalDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.periferikSensoryal != null && targetDiabetesMellitusPursuit.periferikSensoryal.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.periferikSensoryal.Value).Value : periferikSensoryalDiabetesMellitusPursuit.SelectedIndex;
//                        insulinPompasiDiabetesMellitusPursuit.SelectedIndex = (targetDiabetesMellitusPursuit.insulinPompasi != null && targetDiabetesMellitusPursuit.insulinPompasi.Value != null) ? Common.GetEnumValueDefOfEnumValue(targetDiabetesMellitusPursuit.insulinPompasi.Value).Value : insulinPompasiDiabetesMellitusPursuit.SelectedIndex;
//                        
//                        
//                        
//                        
//                        
//                        context.Save();
//                        context.Dispose();
//                        
//                        
//                        
//                        
//                    }
//                }
//            }
#endregion MedulaDiabetTakipFormuIslemleri_cmdLoadTemplate_Click
        }

        private void ttbuttonOku_Click()
        {
#region MedulaDiabetTakipFormuIslemleri_ttbuttonOku_Click
   //
//   try
//            {
//                this.ttgridDiabetTakipFormlari.Rows.Clear();
//                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
//                TakipFormuIslemleri.takipFormuOkuGirisDVO takipFormuOkuGirisDVO = new TakipFormuIslemleri.takipFormuOkuGirisDVO();
//                takipFormuOkuGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
//                if (!string.IsNullOrEmpty(this.tttxtboxTCKimlik.Text))
//                    takipFormuOkuGirisDVO.tcKimlikNo = this.tttxtboxTCKimlik.Text;
//                else
//                    throw new Exception("Diabet Takip Formu Okumak için Hastanın TC Kimlik No alanı dolu olmalıdır!");
//
//                TakipFormuIslemleri.takipFormuOkuCevapDVO takipFormuOkuCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuOku(siteID, takipFormuOkuGirisDVO);
//                if (takipFormuOkuCevapDVO != null)
//                {
//                    if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucKodu) == false)
//                    {
//                        if (takipFormuOkuCevapDVO.sonucKodu.Equals("0000"))
//                        {
//                            if (takipFormuOkuCevapDVO.diabetTakipFormlari != null && takipFormuOkuCevapDVO.diabetTakipFormlari.Length <= 0)
//                                InfoBox.Show("Hastaya Ait Diabet Takip Formu bulunamadı", MessageIconEnum.InformationMessage);
//                            else if (takipFormuOkuCevapDVO.diabetTakipFormlari != null && takipFormuOkuCevapDVO.diabetTakipFormlari.Length > 0)
//                            {
//                                InfoBox.Show("Hastaya Ait Diabet Takip Formlarının okunması işlemi başarılı şekilde yapıldı.", MessageIconEnum.InformationMessage);
//
//                                // Grid Doldurulur.
//                                for (int i = 0; i < takipFormuOkuCevapDVO.diabetTakipFormlari.Length; i++)
//                                {
//                                    TakipFormuIslemleri.diabetTakipFormuDVO diabetTakipFormuDVO = takipFormuOkuCevapDVO.diabetTakipFormlari[i];
//                                    ITTGridRow row = this.ttgridDiabetTakipFormlari.Rows.Add();
//                                    row.Cells[TakipFormuNo.Name].Value = diabetTakipFormuDVO.takipFormuNo;
//                                    row.Cells[ProtokolNo.Name].Value = diabetTakipFormuDVO.protokolNo;
//                                    row.Cells[VizitTarihi.Name].Value = diabetTakipFormuDVO.vizitTarihi;
//                                    row.Cells[IkametTuru.Name].Value = diabetTakipFormuDVO.ikametTuru;
//                                    row.Cells[Tani.Name].Value = diabetTakipFormuDVO.taniKodu;
//                                    row.Cells[TaniTarihi.Name].Value = diabetTakipFormuDVO.taniTarihi;
//                                    row.Cells[TibbiBeslenmeTedavisi.Name].Value = diabetTakipFormuDVO.tibbiBeslenmeTedavisi.ToString();
//                                    row.Cells[Egzersiz.Name].Value = diabetTakipFormuDVO.egzersiz.ToString();
//                                    row.Cells[BasvuruNedeni.Name].Value = diabetTakipFormuDVO.basvuruNedeni.ToString();
//                                    row.Cells[GlukoMetre.Name].Value = diabetTakipFormuDVO.glukoMetre;
//                                    row.Cells[KanSekeriTakipSayisi.Name].Value = diabetTakipFormuDVO.kanSekeriTakipSayisi.ToString();
//                                    row.Cells[SistolikKanBasinci.Name].Value = diabetTakipFormuDVO.sistolikKanBasinci.ToString();
//                                    row.Cells[DiyastolikKanBasinci.Name].Value = diabetTakipFormuDVO.diyastolikKanBasinci.ToString();
//                                    row.Cells[Boy.Name].Value = diabetTakipFormuDVO.boy.ToString();
//                                    row.Cells[Kilo.Name].Value = diabetTakipFormuDVO.kilo.ToString();
//                                    row.Cells[VKI.Name].Value = diabetTakipFormuDVO.vki.ToString();
//                                    row.Cells[APG.Name].Value = diabetTakipFormuDVO.apg.ToString();
//                                    row.Cells[TPG.Name].Value = diabetTakipFormuDVO.tpg.ToString();
//                                    row.Cells[HbA1c.Name].Value = diabetTakipFormuDVO.hbA1c.ToString();
//                                    row.Cells[Kreatinin.Name].Value = diabetTakipFormuDVO.kreatinin.ToString();
//                                    row.Cells[Trigliserid.Name].Value = diabetTakipFormuDVO.trigliserid.ToString();
//                                    row.Cells[LDLKol.Name].Value = diabetTakipFormuDVO.ldlKol.ToString();
//                                    row.Cells[HDLKol.Name].Value = diabetTakipFormuDVO.hdlKol.ToString();
//                                    row.Cells[ALT.Name].Value = diabetTakipFormuDVO.alt.ToString();
//                                    row.Cells[AntiGAD.Name].Value = diabetTakipFormuDVO.antiGAD;
//                                    row.Cells[EKG.Name].Value = diabetTakipFormuDVO.ekg.ToString();
//                                    row.Cells[Mikroalbuminuri.Name].Value = diabetTakipFormuDVO.mikroalbuminuri;
//                                    row.Cells[GozMuayenesi.Name].Value = diabetTakipFormuDVO.gozMuayenesi.ToString();
//                                    row.Cells[PeriferikSensoryalNoropati.Name].Value = diabetTakipFormuDVO.periferikSensoryal;
//                                    row.Cells[KoronerArterH.Name].Value = diabetTakipFormuDVO.koronerArterH;
//                                    row.Cells[SerebrovaskulerH.Name].Value = diabetTakipFormuDVO.serebrovaskulerH;
//                                    row.Cells[AyakMuayenesi.Name].Value = diabetTakipFormuDVO.ayakMuayenesi;
//                                    row.Cells[AkutKomplikasyon.Name].Value = diabetTakipFormuDVO.akutKomplikasyon.ToString();
//                                    row.Cells[YatisGun.Name].Value = diabetTakipFormuDVO.yatisGun.ToString();
//                                    row.Cells[İnsulinPompasi.Name].Value = diabetTakipFormuDVO.insulinPompasi;
//                                    row.Cells[İnsulinPompasiVerTarihi.Name].Value = diabetTakipFormuDVO.insulinPompasiVerTarihi;
//                                    row.Cells[İnsulinPompasiDegTarihi.Name].Value = diabetTakipFormuDVO.insulinPompasiDegTarihi;
//
//                                    this.tttxtboxAd.Text = diabetTakipFormuDVO.ad;
//                                    this.tttxtboxTCKimlik.Text = diabetTakipFormuDVO.tcKimlikNo;
//                                    this.tttxtboxSoyad.Text = diabetTakipFormuDVO.soyad;
//                                    this.tttxtboxCep.Text = diabetTakipFormuDVO.cepTel;
//                                    this.tttxtboxCinsiyet.Text = diabetTakipFormuDVO.cinsiyet;
//                                }
//                            }
//                        }
//                        else
//                        {
//                            if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucMesaji) == false)
//                                //Olmamış :P
//                                throw new Exception("Meduladan gelen mesaj : " + takipFormuOkuCevapDVO.sonucMesaji);
//                            else
//                                throw new Exception("Hastaya Ait Diabet Takip Formlarının Meduladan okunması işleminde hata var.");
//                        }
//                    }
//                    else
//                    {
//                        if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucMesaji) == false)
//                            //Olmamış :P
//                            throw new Exception("Meduladan gelen mesaj : " + takipFormuOkuCevapDVO.sonucMesaji);
//                        else
//                            throw new Exception("Hastaya Ait Diabet Takip Formlarının Meduladan okunması sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!");
//                    }
//                }
//                else
//                    throw new Exception("Hastaya Ait Diabet Takip Formları Meduladan okunamadı!");
//
//            }
//            catch (Exception e)
//            {
//                InfoBox.Show(e.Message);
//            }
#endregion MedulaDiabetTakipFormuIslemleri_ttbuttonOku_Click
        }

        private void cmdSearchPatient_Click()
        {
#region MedulaDiabetTakipFormuIslemleri_cmdSearchPatient_Click
   using (PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();

                if (patient != null)
                {
                    tttabcontrol1.Visible = true;
                    tttxtboxAd.Text = patient.Name;
                    tttxtboxAd.Tag = patient.ObjectID;
                    tttxtboxSoyad.Text = patient.Surname;
                    if (patient.YUPASSNO != null)
                    {
                        lblKimlikNo.Text = "YUPASS No";
                        tttxtboxTCKimlik.Text = patient.YUPASSNO != null ? (patient.YUPASSNO.Value.ToString() + "") : "";
                    }
                    else
                    {
                        lblKimlikNo.Text = "TC Kimlik Numarası";
                        tttxtboxTCKimlik.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
                    }

                    tttxtboxCep.Text = patient.PatientAddress.MobilePhone != null ? patient.PatientAddress.MobilePhone.ToString() : "";
                    if (patient.Sex != null)
                    {
                        if (patient.Sex.ADI == "ERKEK")
                            tttxtboxCinsiyet.Text = "Erkek";
                        else
                            tttxtboxCinsiyet.Text = "Bayan"; 
                    }
                }
                else
                {
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                    tttabcontrol1.Visible = false;
                    tttxtboxCinsiyet.Text = "";
                    tttxtboxCep.Text = "";
                    tttxtboxTCKimlik.Text = "";
                    tttxtboxSoyad.Text = "";
                    tttxtboxAd.Text = "";
                }
            }
#endregion MedulaDiabetTakipFormuIslemleri_cmdSearchPatient_Click
        }

#region MedulaDiabetTakipFormuIslemleri_Methods
        //public void CloneDiabetesMellitusPursiut(DiabetesMellitusPursuit dmp)
//        {
//            
//            TTObjectContext con = new TTObjectContext(false);
//            dmp.protokolNo = protokolNoDiabetesMellitusPursuit.Text;
//            dmp.trigliserid = (string.IsNullOrEmpty(trigliseridDiabetesMellitusPursuit.Text) == false) ? (Convert.ToDouble(trigliseridDiabetesMellitusPursuit.Text)) : dmp.trigliserid;
//            dmp.vki = (!string.IsNullOrEmpty(vkiDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(vkiDiabetesMellitusPursuit.Text) : dmp.vki;
//            dmp.kanSekeriTakipSayisi = (!string.IsNullOrEmpty(kanSekeriTakipSayisiDiabetesMellitusPursuit.Text)) ? Convert.ToInt32(kanSekeriTakipSayisiDiabetesMellitusPursuit.Text) : dmp.kanSekeriTakipSayisi;
//            dmp.alt = (!string.IsNullOrEmpty(altDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(altDiabetesMellitusPursuit.Text) : dmp.alt;
//            dmp.hbA1c =  (!string.IsNullOrEmpty(hbA1cDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(hbA1cDiabetesMellitusPursuit.Text) : dmp.hbA1c;
//            dmp.diyastolikKanBasinci = (!string.IsNullOrEmpty(diyastolikKanBasinciDiabetesMellitusPursuit.Text)) ? Convert.ToInt32(diyastolikKanBasinciDiabetesMellitusPursuit.Text) : dmp.diyastolikKanBasinci;
//            dmp.sistolikKanBasinci =  (!string.IsNullOrEmpty(sistolikKanBasinciDiabetesMellitusPursuit.Text)) ? Convert.ToInt32(sistolikKanBasinciDiabetesMellitusPursuit.Text) : dmp.sistolikKanBasinci;
//            dmp.kreatinin = (!string.IsNullOrEmpty(kreatininDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(kreatininDiabetesMellitusPursuit.Text) : dmp.kreatinin;
//            dmp.yatisGun = (!string.IsNullOrEmpty(yatisGunDiabetesMellitusPursuit.Text)) ? Convert.ToInt32(yatisGunDiabetesMellitusPursuit.Text) : dmp.yatisGun;
//            dmp.tpg = (!string.IsNullOrEmpty(tpgDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(tpgDiabetesMellitusPursuit.Text) : dmp.tpg;
//            dmp.apg = (!string.IsNullOrEmpty(apgDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(apgDiabetesMellitusPursuit.Text) : dmp.apg;
//            dmp.hdlKol =  (!string.IsNullOrEmpty(hdlKolDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(hdlKolDiabetesMellitusPursuit.Text) : dmp.hdlKol;
//            dmp.ldlKol =  (!string.IsNullOrEmpty(ldlKolDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(ldlKolDiabetesMellitusPursuit.Text) : dmp.ldlKol;
//
//            dmp.vizitTarihi = ((TTDateTimePicker)vizitTarihiDiabetesMellitusPursuit != null && ((TTDateTimePicker)vizitTarihiDiabetesMellitusPursuit).Value != null) ? ((TTDateTimePicker)vizitTarihiDiabetesMellitusPursuit).Value.Date : dmp.vizitTarihi;
//            dmp.kilo =  (!string.IsNullOrEmpty(kiloDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(kiloDiabetesMellitusPursuit.Text) : dmp.kilo;
//            dmp.boy = (!string.IsNullOrEmpty(boyDiabetesMellitusPursuit.Text)) ? Convert.ToDouble(boyDiabetesMellitusPursuit.Text) : dmp.boy;
//
//            dmp.taniTarihi = ((TTDateTimePicker)taniTarihiDiabetesMellitusPursuit != null && ((TTDateTimePicker)taniTarihiDiabetesMellitusPursuit).Value != null) ? ((TTDateTimePicker)taniTarihiDiabetesMellitusPursuit).Value.Date : dmp.taniTarihi;
//            dmp.insulinPompasiDegTarihi = ((TTDateTimePicker)insulinPompasiDegTarihiDiabetesMellitusPursuit != null && ((TTDateTimePicker)insulinPompasiDegTarihiDiabetesMellitusPursuit).Value != null) ? ((TTDateTimePicker)insulinPompasiDegTarihiDiabetesMellitusPursuit).Value.Date : dmp.insulinPompasiDegTarihi;
//            dmp.insulinPompasiVerTarihi = ((TTDateTimePicker)insulinPompasiVerTarihiDiabetesMellitusPursuit != null && ((TTDateTimePicker)insulinPompasiVerTarihiDiabetesMellitusPursuit).Value != null) ? ((TTDateTimePicker)insulinPompasiVerTarihiDiabetesMellitusPursuit).Value.Date : dmp.insulinPompasiVerTarihi;
//            
//            dmp.tibbiBeslenmeTedavisi = (tibbiBeslenmeTedavisiDiabetesMellitusPursuit.SelectedItem != null) ? (TibbiBeslenmeTedavisiEnum)(tibbiBeslenmeTedavisiDiabetesMellitusPursuit.SelectedItem.Value) : dmp.tibbiBeslenmeTedavisi;
//            dmp.akutKomplikasyon = (akutKomplikasyonDiabetesMellitusPursuit.SelectedItem != null) ? (AkutKomplikasyonEnum)(akutKomplikasyonDiabetesMellitusPursuit.SelectedItem.Value) : dmp.akutKomplikasyon;
//            dmp.antiGAD = (antiGADDiabetesMellitusPursuit.SelectedItem != null) ? (AntiGADEnum)(antiGADDiabetesMellitusPursuit.SelectedItem.Value) : dmp.antiGAD;
//            dmp.ayakMuayenesi = (ayakMuayenesiDiabetesMellitusPursuit.SelectedItem != null) ? (AyakMuayenesiEnum)(ayakMuayenesiDiabetesMellitusPursuit.SelectedItem.Value) : dmp.ayakMuayenesi;
//            dmp.basvuruNedeni = (basvuruNedeniDiabetesMellitusPursuit.SelectedItem != null) ? (BasvuruNedeniEnum)(basvuruNedeniDiabetesMellitusPursuit.SelectedItem.Value) : dmp.basvuruNedeni;
//            dmp.serebrovaskulerH = (serebrovaskulerHDiabetesMellitusPursuit.SelectedItem != null) ? (VarYokEnum)(serebrovaskulerHDiabetesMellitusPursuit.SelectedItem.Value) : dmp.serebrovaskulerH;
//            dmp.glukoMetre = (glukoMetreDiabetesMellitusPursuit.SelectedItem != null) ? (VarYokEnum)(glukoMetreDiabetesMellitusPursuit.SelectedItem.Value) : dmp.glukoMetre;
//            dmp.gozMuayenesi = (gozMuayenesiDiabetesMellitusPursuit.SelectedItem != null) ? (GozMuayenesiEnum)(gozMuayenesiDiabetesMellitusPursuit.SelectedItem.Value) : dmp.gozMuayenesi;
//            dmp.ikametTuru = (ikametTuruDiabetesMellitusPursuit.SelectedItem != null) ? (ikametTuruEnum)(ikametTuruDiabetesMellitusPursuit.SelectedItem.Value) : dmp.ikametTuru;
//            dmp.egzersiz = (egzersizDiabetesMellitusPursuit.SelectedItem != null) ? (EgzersizEnum)(egzersizDiabetesMellitusPursuit.SelectedItem.Value) : dmp.egzersiz;
//            dmp.ekg = (ekgDiabetesMellitusPursuit.SelectedItem != null) ? (EkgEnum)(ekgDiabetesMellitusPursuit.SelectedItem.Value) : dmp.ekg;
//            dmp.koronerArterH = (koronerArterHDiabetesMellitusPursuit.SelectedItem != null) ? (VarYokEnum)(koronerArterHDiabetesMellitusPursuit.SelectedItem.Value) : dmp.koronerArterH;
//            dmp.mikroalbuminuri = (mikroalbuminuriDiabetesMellitusPursuit.SelectedItem != null) ? (VarYokEnum)(mikroalbuminuriDiabetesMellitusPursuit.SelectedItem.Value) : dmp.mikroalbuminuri;
//            dmp.periferikSensoryal = (periferikSensoryalDiabetesMellitusPursuit.SelectedItem != null) ? (VarYokEnum)(periferikSensoryalDiabetesMellitusPursuit.SelectedItem.Value) : dmp.periferikSensoryal;
//            dmp.insulinPompasi = (insulinPompasiDiabetesMellitusPursuit.SelectedItem != null) ? (VarYokEnum)(insulinPompasiDiabetesMellitusPursuit.SelectedItem.Value) : dmp.insulinPompasi;
//
//            dmp.HastaTanisi = (TTListBoxtaniDiabetesMellitusPursuit.SelectedObject != null) ? ((DiagnosisDefinition)TTListBoxtaniDiabetesMellitusPursuit.SelectedObject) : dmp.HastaTanisi;
//            
//            //Doktor Bilgileri
//            for( int i= 0;  i < DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows.Count  ; i++)
//            {
//                DiabetesMellitusPursuitDoctor doctor = new DiabetesMellitusPursuitDoctor(con);
//                if(DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[drTescilNoDiabetesMellitusPursuitDoctor.Name].Value != null)
//                {
//                    ResUser resUser =  (ResUser) con.QueryObjects("RESUSER", "OBJECTID = '" + DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[drTescilNoDiabetesMellitusPursuitDoctor.Name].Value.ToString() + "'")[0];
//                    doctor.Doktor = resUser;
//                }
//                if(DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[drBransKoduDiabetesMellitusPursuitDoctor.Name].Value != null)
//                {
//                    SpecialityDefinition specDef =  (SpecialityDefinition) con.QueryObjects("SPECIALITYDEFINITION", "OBJECTID = '" + DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[drBransKoduDiabetesMellitusPursuitDoctor.Name].Value.ToString() + "'")[0];
//                    doctor.BransKodu = specDef;
//                }
//                if (DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitDoctor.Name].Value != null)
//                {
//                    doctor.dmEgitimiAlmisMi = (EvetHayirDurumEnum) (DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitDoctor.Name].Value) ;
//                }
//                dmp.DiabetesMellitusPursuitDoctor.Add(doctor);
//                //doctor.DiabetesMellitusPursuit = dmp;
//            }
//            
//            // İlaç Bilgileri
//            for( int i= 0; i < DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows.Count ; i++)
//            {
//                DiabetesMellitusPursuitUsedDrug drug = new DiabetesMellitusPursuitUsedDrug(con);
//                
//                if (DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows[i].Cells[barkodDiabetesMellitusPursuitUsedDrug.Name].Value != null)
//                {
//                    drug.barkod = DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows[i].Cells[barkodDiabetesMellitusPursuitUsedDrug.Name].Value.ToString() ;
//                }
//                if (DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows[i].Cells[gunlukDozDiabetesMellitusPursuitUsedDrug.Name].Value != null)
//                {
//                    drug.gunlukDoz = DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows[i].Cells[gunlukDozDiabetesMellitusPursuitUsedDrug.Name].Value.ToString() ;
//                }
//                dmp.DiabetesMellitusPursuitUsedDrug.Add(drug);
//            }
//            
//            // Alışkanlıklar
//            for( int i= 0; i < DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows.Count ; i++)
//            {
//                DiabetesMellitusPursuitHabit habit = new DiabetesMellitusPursuitHabit(con);
//                
//                if (DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows[i].Cells[aliskanlikDiabetesMellitusPursuitHabit.Name].Value != null)
//                {
//                    habit.aliskanlik = (AliskanlikKoduEnum)(DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows[i].Cells[aliskanlikDiabetesMellitusPursuitHabit.Name].Value) ;
//                }
//                
//                dmp.DiabetesMellitusPursuitHabit.Add(habit);
//            }
//            
//            
//            //Eğitim Bilgileri
//            for( int i= 0; i < DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows.Count ; i++)
//            {
//                DiabetesMellitusPursuitInstruction instruction = new DiabetesMellitusPursuitInstruction(con);
//                
//                if (DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[bireyselEgitimSayisiDiabetesMellitusPursuitInstruction.Name].Value != null)
//                {
//                    instruction.bireyselEgitimSayisi = Convert.ToInt32( DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[bireyselEgitimSayisiDiabetesMellitusPursuitInstruction.Name].Value) ;
//                }
//                
//                if (DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[grupEgitimiSayisiDiabetesMellitusPursuitInstruction.Name].Value != null)
//                {
//                    instruction.grupEgitimiSayisi = Convert.ToInt32(DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[grupEgitimiSayisiDiabetesMellitusPursuitInstruction.Name].Value) ;
//                }
//                
//                if (DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitInstruction.Name].Value != null)
//                {
//                    instruction.dmEgitimiAlmisMi = (EvetHayirDurumEnum)(DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitInstruction.Name].Value) ;
//                }
//                
//                dmp.DiabetesMellitusPursuitInstruction.Add(instruction);
//            }
//            
//            //Hastalık Bilgileri
//            
//            for( int i= 0; i < DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows.Count ; i++)
//            {
//                DiabetesMellitusPursuitDisease disease = new DiabetesMellitusPursuitDisease(con);
//                
//                if (DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[hastalikKoduDiabetesMellitusPursuitDisease.Name].Value != null)
//                {
//                    disease.hastalikKodu = (HastalikKoduEnum)(DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[hastalikKoduDiabetesMellitusPursuitDisease.Name].Value) ;
//                }
//                if (DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[digerHastalikTaniKoduDiabetesMellitusPursuitDisease.Name].Value != null)
//                {
//                    disease.digerHastalikTaniKodu = DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[digerHastalikTaniKoduDiabetesMellitusPursuitDisease.Name].Value.ToString() ;
//                }
//                
//                dmp.DiabetesMellitusPursuitDisease.Add(disease);
//            }
//            
//        }
        
        
        // Diabet Takip Formu Kaydet

//        public void MedulaDiabetTakipFormuKaydet(TTObjectContext context)
//        {
//
//            try
//            {
//                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
//                Patient myPatient =  (Patient) context.QueryObjects("PATIENT", "OBJECTID = '" + tttxtboxAd.Tag + "'")[0];
//                TakipFormuIslemleri.takipFormuKaydetCevapDVO takipFormuKaydetCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuKaydet(siteID, GetTakipFormuKaydetGirisDVO(context));
//                if (takipFormuKaydetCevapDVO != null)
//                {
//                    if (string.IsNullOrEmpty(takipFormuKaydetCevapDVO.sonucKodu) == false)
//                    {
//                        if (takipFormuKaydetCevapDVO.sonucKodu.Equals("0000"))
//                        {
//                            if (takipFormuKaydetCevapDVO.diabetTakipFormu != null && !string.IsNullOrEmpty(takipFormuKaydetCevapDVO.diabetTakipFormu.takipFormuNo))
//                            {
//                                InfoBox.Show("Diabet Takip Formu kaydetme işlemi başarılı şekilde yapıldı. Takip Form Numarası: " + takipFormuKaydetCevapDVO.diabetTakipFormu.takipFormuNo, MessageIconEnum.InformationMessage);
//                                myPatient.DiabetesMellitusPursuit.takipFormuNo = takipFormuKaydetCevapDVO.diabetTakipFormu.takipFormuNo;
//                            }
//                        }
//                        else
//                        {
//                            if (string.IsNullOrEmpty(takipFormuKaydetCevapDVO.sonucMesaji) == false)
//                                throw new Exception("Diabet Takip Formu Medulaya kaydedilmesi işleminde hata var. Sonuç Mesajı :" + takipFormuKaydetCevapDVO.sonucMesaji);
//                            else
//                                throw new Exception("Diabet Takip Formu Medulaya kaydedilmesi işleminde hata var.");
//                        }
//                    }
//                    else
//                    {
//                        if (string.IsNullOrEmpty(takipFormuKaydetCevapDVO.sonucMesaji) == false)
//                            throw new Exception("Diabet Takip Formunun Medulaya kaydedilmesi işleminde hata var: " + takipFormuKaydetCevapDVO.sonucMesaji);
//                        else
//                            throw new Exception("Diabet Takip Formunun Medulaya kaydedilmesi sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!");
//                    }
//
//                }
//                else
//                    throw new Exception("Diabet Takip Formunun Medulaya kaydedilemedi!");
//
//            }
//            catch (Exception e)
//            {
//                InfoBox.Show(e.Message);
//            }
//        }
//        
//        
//        
//        /*
//         * MEDULA Takip Formu Kaydet Giriş DVO Hazırlanması
//         * */
//
//        public TakipFormuIslemleri.takipFormuKaydetGirisDVO GetTakipFormuKaydetGirisDVO(TTObjectContext context)
//        {
//
//            TakipFormuIslemleri.takipFormuKaydetGirisDVO takipFormuKaydetGirisDVO = new TakipFormuIslemleri.takipFormuKaydetGirisDVO();
//
//            TakipFormuIslemleri.diabetTakipFormuKayitDVO diabetTakipFormuKayitDVO = new TakipFormuIslemleri.diabetTakipFormuKayitDVO();
//            
//            Patient myPatient =  (Patient) context.QueryObjects("PATIENT", "OBJECTID = '" + tttxtboxAd.Tag + "'")[0];
//
//            //Hastanın Bilgileri
//            // TC Kimlik No
//            if (!string.IsNullOrEmpty(tttxtboxTCKimlik.Text) )
//                diabetTakipFormuKayitDVO.tcKimlikNo = tttxtboxTCKimlik.Text;
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için hasta kimlik numarası alanı dolu olmalıdır!");
//
//            // Ad
//            if (!string.IsNullOrEmpty(tttxtboxAd.Text))
//                diabetTakipFormuKayitDVO.ad = tttxtboxAd.Text;
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için hastanın adı dolu olmalıdır!");
//
//            // Soyad
//            if (!string.IsNullOrEmpty(tttxtboxSoyad.Text))
//                diabetTakipFormuKayitDVO.soyad = tttxtboxSoyad.Text;
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için hastanın soyadı dolu olmalıdır!");
//
//            // Cep Telefonu
//            String mobilePhone = "";
//            if (myPatient != null && !string.IsNullOrEmpty(myPatient.MobilePhone))
//            {
//
//                mobilePhone = myPatient.MobilePhone.Replace('(', ' ');
//                mobilePhone = mobilePhone.Replace(')', ' ');
//                mobilePhone = mobilePhone.Remove(4, 1);
//                diabetTakipFormuKayitDVO.cepTel = mobilePhone.Trim();
//            }
//            else if (myPatient != null && !string.IsNullOrEmpty(myPatient.HomePhone))
//            {
//                mobilePhone = myPatient.HomePhone.Replace('(', ' ');
//                mobilePhone = mobilePhone.Replace(')', ' ');
//                mobilePhone = mobilePhone.Remove(4, 1);
//                diabetTakipFormuKayitDVO.cepTel = mobilePhone.Trim();
//            }
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için hastanın cep telefonu bilgisi olmalıdır!");
//
//            // protokol No
//            if (!string.IsNullOrEmpty(protokolNoDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.protokolNo = protokolNoDiabetesMellitusPursuit.Text;
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için protokol numarası bilgisi olmalıdır!");
//
//            // vizit tarihi
//            if (((TTDateTimePicker)vizitTarihiDiabetesMellitusPursuit).Value != null)
//                diabetTakipFormuKayitDVO.vizitTarihi = ((TTDateTimePicker)vizitTarihiDiabetesMellitusPursuit).Value.ToShortDateString();
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için vizit tarihi bilgisi olmalıdır!");
//
//            // sağlık tesis kodu
//            diabetTakipFormuKayitDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
//
//            // Cinsiyet
//            if (myPatient!= null && myPatient.Sex != null && myPatient.Sex.Value != null)
//            {
//                if (myPatient.Sex.Value == SexEnum.Female)
//                    diabetTakipFormuKayitDVO.cinsiyet = "K";
//                else if (myPatient.Sex.Value == SexEnum.Male)
//                    diabetTakipFormuKayitDVO.cinsiyet = "E";
//                else
//                    throw new Exception("Diabet Takip Formu Kaydı için hastanın cinsiyet bilgisi  belirlenmiş olmalıdır!");
//            }
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için hastanın cinsiyet bilgisi dolu olmalıdır!");
//
//
//            // ikamet Türü
//            if (ikametTuruDiabetesMellitusPursuit.SelectedItem != null)
//                diabetTakipFormuKayitDVO.ikametTuru = ((ikametTuruEnum)ikametTuruDiabetesMellitusPursuit.SelectedItem.Value).GetHashCode();
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için ikamet türü bilgisi dolu olmalıdır!");
//
//            // TODO Doktor Bilgileri
//            diabetTakipFormuKayitDVO.doktorBilgileri = getTakipFormuDoktorBilgisiDVOList(context);
//
//            // Tanı
//            if (TTListBoxtaniDiabetesMellitusPursuit.SelectedObject != null && ((DiagnosisDefinition)TTListBoxtaniDiabetesMellitusPursuit.SelectedObject).Code != null)
//                diabetTakipFormuKayitDVO.taniKodu = ((DiagnosisDefinition)TTListBoxtaniDiabetesMellitusPursuit.SelectedObject).Code;
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için tanı bilgisi dolu olmalıdır!");
//
//            // Tanı Tarihi
//            if (taniTarihiDiabetesMellitusPursuit != null && ((TTDateTimePicker)taniTarihiDiabetesMellitusPursuit).Value != null && ((TTDateTimePicker)taniTarihiDiabetesMellitusPursuit).Value.Date != null)
//                diabetTakipFormuKayitDVO.taniTarihi = ((TTDateTimePicker)taniTarihiDiabetesMellitusPursuit).Value.Date.ToShortDateString();
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için hastanın tanıyı aldığı ilk tarih bilgisi dolu olmalıdır!");
//
//            // TODO Diabet Eğitimi
//            diabetTakipFormuKayitDVO.diabetEgitimi = getTakipFormuDiabetEgitimiDVO();
//
//            //Tıbbı Beslenme Tedavisi
//            if (tibbiBeslenmeTedavisiDiabetesMellitusPursuit != null && tibbiBeslenmeTedavisiDiabetesMellitusPursuit.SelectedItem != null && tibbiBeslenmeTedavisiDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.tibbiBeslenmeTedavisi = Convert.ToInt32(tibbiBeslenmeTedavisiDiabetesMellitusPursuit.SelectedItem.Value);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için tıbbi beslenme tedavisi bilgisi dolu olmalıdır!");
//
//            //Egzersiz
//            if (egzersizDiabetesMellitusPursuit != null && egzersizDiabetesMellitusPursuit.SelectedItem != null && egzersizDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.egzersiz = Convert.ToInt32(egzersizDiabetesMellitusPursuit.SelectedItem.Value);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için egzersiz bilgisi dolu olmalıdır!");
//
//            //TODO Hastalıklar Zorunlu değil
//            diabetTakipFormuKayitDVO.hastaliklar = getTakipFormuHastalikDVOList();
//
//            //Başvuru Nedeni
//            if (basvuruNedeniDiabetesMellitusPursuit != null && basvuruNedeniDiabetesMellitusPursuit.SelectedItem != null && basvuruNedeniDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.basvuruNedeni = Convert.ToInt32(basvuruNedeniDiabetesMellitusPursuit.SelectedItem.Value);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için başvuru nedeni bilgisi dolu olmalıdır!");
//
//            //TODO ALışkanlıklar zorunlu değil
//            diabetTakipFormuKayitDVO.aliskanliklar = getTakipFormuAliskanlikDVOList();
//
//            // Glukometre
//            if (glukoMetreDiabetesMellitusPursuit != null && glukoMetreDiabetesMellitusPursuit.SelectedItem != null && glukoMetreDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.glukoMetre = getMedulaCode((VarYokEnum)glukoMetreDiabetesMellitusPursuit.SelectedItem.Value);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için gluko metre bilgisi dolu olmalıdır!");
//
//            //Kan Şekeri takip sayısı
//            if (kanSekeriTakipSayisiDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(kanSekeriTakipSayisiDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.kanSekeriTakipSayisi = Convert.ToInt32(kanSekeriTakipSayisiDiabetesMellitusPursuit.Text);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için Kan Şekeri takip sayısı bilgisi dolu olmalıdır!");
//
//            //TODO Kullanılan İlaçlar zorunlu değil
//            diabetTakipFormuKayitDVO.kullanilanIlaclar = getTakipFormuKullanilanIlacDVOList();
//
//            //Sistolik Kan Basıncı zorunlu değil
//            if (sistolikKanBasinciDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(sistolikKanBasinciDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.sistolikKanBasinci = Convert.ToInt32(sistolikKanBasinciDiabetesMellitusPursuit.Text);
//
//            //Diyastolik Kan Basıncı zorunlu değil
//            if (diyastolikKanBasinciDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(diyastolikKanBasinciDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.diyastolikKanBasinci = Convert.ToInt32(diyastolikKanBasinciDiabetesMellitusPursuit.Text);
//
//            //Boy
//            if (boyDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(boyDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.boy = Convert.ToDouble(boyDiabetesMellitusPursuit.Text);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için boy bilgisi dolu olmalıdır!");
//
//            //Kilo
//            if (kiloDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(kiloDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.kilo = Convert.ToDouble(kiloDiabetesMellitusPursuit.Text);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için Kilo bilgisi dolu olmalıdır!");
//
//            //VKİ
//            if (vkiDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(vkiDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.vki =Convert.ToDouble( vkiDiabetesMellitusPursuit.Text);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için VKİ bilgisi dolu olmalıdır!");
//
//            // APG
//            if (apgDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(apgDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.apg = Convert.ToDouble(apgDiabetesMellitusPursuit.Text);
//            else
//                diabetTakipFormuKayitDVO.apg = Convert.ToDouble("0");
//
//            // TPG
//            if (tpgDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(tpgDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.tpg = Convert.ToDouble(tpgDiabetesMellitusPursuit.Text);
//            else
//                diabetTakipFormuKayitDVO.tpg = Convert.ToDouble("0");
//
//            //HbA1c
//            if (hbA1cDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(hbA1cDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.hbA1c = Convert.ToDouble(hbA1cDiabetesMellitusPursuit.Text);
//            else
//                diabetTakipFormuKayitDVO.hbA1c = Convert.ToDouble("0");
//
//            //Kreatinin
//            if (kreatininDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(kreatininDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.kreatinin = Convert.ToDouble(kreatininDiabetesMellitusPursuit.Text);
//            else
//                diabetTakipFormuKayitDVO.kreatinin = Convert.ToDouble("0");
//
//            //Trigliserid
//            if (trigliseridDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(trigliseridDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.trigliserid = Convert.ToDouble(trigliseridDiabetesMellitusPursuit.Text);
//            else
//                diabetTakipFormuKayitDVO.trigliserid = Convert.ToDouble("0");
//
//            //LDL-Kol
//            if (ldlKolDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(ldlKolDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.ldlKol = Convert.ToDouble(ldlKolDiabetesMellitusPursuit.Text);
//            else
//                diabetTakipFormuKayitDVO.ldlKol = Convert.ToDouble("0");
//
//            //HDL-Kol
//            if (hdlKolDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(hdlKolDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.hdlKol = Convert.ToDouble(hdlKolDiabetesMellitusPursuit.Text);
//            else
//                diabetTakipFormuKayitDVO.hdlKol = Convert.ToDouble("0");
//
//            //ALT
//            if (altDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(altDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.alt = Convert.ToDouble(altDiabetesMellitusPursuit.Text);
//            else
//                diabetTakipFormuKayitDVO.alt = Convert.ToDouble("0");
//
//            //AntiGAD
//            if (antiGADDiabetesMellitusPursuit != null && antiGADDiabetesMellitusPursuit.SelectedItem != null && antiGADDiabetesMellitusPursuit.SelectedItem.Value != null )
//            {
//                if ( (AntiGADEnum)antiGADDiabetesMellitusPursuit.SelectedItem.Value == AntiGADEnum.B)
//                    diabetTakipFormuKayitDVO.antiGAD = "B";
//                else if ((AntiGADEnum)antiGADDiabetesMellitusPursuit.SelectedItem.Value == AntiGADEnum.N)
//                    diabetTakipFormuKayitDVO.antiGAD = "N";
//                else if ((AntiGADEnum)antiGADDiabetesMellitusPursuit.SelectedItem.Value == AntiGADEnum.P)
//                    diabetTakipFormuKayitDVO.antiGAD = "P";
//            }
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için antiGAD bilgisi dolu olmalıdır!");
//
//            //EKG
//            if (ekgDiabetesMellitusPursuit != null && ekgDiabetesMellitusPursuit.SelectedItem != null && ekgDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.ekg = Convert.ToInt32(ekgDiabetesMellitusPursuit.SelectedItem.Value.GetHashCode().ToString());
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için EKG bilgisi dolu olmalıdır!");
//
//            //Mikroalbuminüri
//            if (mikroalbuminuriDiabetesMellitusPursuit != null && mikroalbuminuriDiabetesMellitusPursuit.SelectedItem != null && mikroalbuminuriDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.mikroalbuminuri = getMedulaCode((VarYokEnum)mikroalbuminuriDiabetesMellitusPursuit.SelectedItem.Value);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için mikroalbuminuri bilgisi dolu olmalıdır!");
//
//            //gozMuayenesi
//            if (gozMuayenesiDiabetesMellitusPursuit != null && gozMuayenesiDiabetesMellitusPursuit.SelectedItem != null && gozMuayenesiDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.gozMuayenesi = Convert.ToInt32(gozMuayenesiDiabetesMellitusPursuit.SelectedItem.Value.GetHashCode().ToString());
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için göz muayene bilgisi dolu olmalıdır!");
//
//            //Periferik Sensoryal Nöropati
//            if (periferikSensoryalDiabetesMellitusPursuit != null && periferikSensoryalDiabetesMellitusPursuit.SelectedItem != null && periferikSensoryalDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.periferikSensoryal = getMedulaCode((VarYokEnum)periferikSensoryalDiabetesMellitusPursuit.SelectedItem.Value);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için Periferik Sensoryal Nöropati bilgisi dolu olmalıdır!");
//
//            //Koroner Arter H zorunlu değil
//            if (koronerArterHDiabetesMellitusPursuit != null && koronerArterHDiabetesMellitusPursuit.SelectedItem != null && koronerArterHDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.koronerArterH = getMedulaCode((VarYokEnum)koronerArterHDiabetesMellitusPursuit.SelectedItem.Value);
//
//
//            //Serebrovasküler H
//            if (serebrovaskulerHDiabetesMellitusPursuit != null && serebrovaskulerHDiabetesMellitusPursuit.SelectedItem != null && serebrovaskulerHDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.serebrovaskulerH = getMedulaCode((VarYokEnum)serebrovaskulerHDiabetesMellitusPursuit.SelectedItem.Value);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için Serebrovasküler H bilgisi dolu olmalıdır!");
//
//            //Ayak Muayenesi
//            if (ayakMuayenesiDiabetesMellitusPursuit != null && ayakMuayenesiDiabetesMellitusPursuit.SelectedItem != null && ayakMuayenesiDiabetesMellitusPursuit.SelectedItem.Value != null)
//            {
//                if ((AyakMuayenesiEnum) ayakMuayenesiDiabetesMellitusPursuit.SelectedItem.Value == AyakMuayenesiEnum.B)
//                    diabetTakipFormuKayitDVO.ayakMuayenesi = "B";
//                else if ((AyakMuayenesiEnum)ayakMuayenesiDiabetesMellitusPursuit.SelectedItem.Value == AyakMuayenesiEnum.V)
//                    diabetTakipFormuKayitDVO.ayakMuayenesi = "V";
//                else if ((AyakMuayenesiEnum)ayakMuayenesiDiabetesMellitusPursuit.SelectedItem.Value == AyakMuayenesiEnum.Y)
//                    diabetTakipFormuKayitDVO.ayakMuayenesi = "Y";
//            }
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için Ayak Muayenesi bilgisi dolu olmalıdır!");
//
//            //Akut komplikasyonu
//            if (akutKomplikasyonDiabetesMellitusPursuit!= null && akutKomplikasyonDiabetesMellitusPursuit.SelectedItem != null && akutKomplikasyonDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.akutKomplikasyon = Convert.ToInt32(akutKomplikasyonDiabetesMellitusPursuit.SelectedItem.Value.GetHashCode().ToString());
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için Akut komplikasyonu bilgisi dolu olmalıdır!");
//
//
//            //Hasta Yatış Gün
//            if (yatisGunDiabetesMellitusPursuit != null && !string.IsNullOrEmpty(yatisGunDiabetesMellitusPursuit.Text))
//                diabetTakipFormuKayitDVO.yatisGun = Convert.ToInt32(yatisGunDiabetesMellitusPursuit.Text);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için Hasta Yatış Gün bilgisi dolu olmalıdır!");
//
//            //İnsulinPompasi
//            if (insulinPompasiDiabetesMellitusPursuit != null && insulinPompasiDiabetesMellitusPursuit.SelectedItem != null && insulinPompasiDiabetesMellitusPursuit.SelectedItem.Value != null)
//                diabetTakipFormuKayitDVO.insulinPompasi = getMedulaCode((VarYokEnum)insulinPompasiDiabetesMellitusPursuit.SelectedItem.Value);
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için insülin pompasının var olup olmadığı bilgisi dolu olmalıdır!");
//
//
//            //insulinPompasiVerTarihi
//            if (insulinPompasiVerTarihiDiabetesMellitusPursuit != null && ((TTDateTimePicker)insulinPompasiVerTarihiDiabetesMellitusPursuit).Value != null && ((TTDateTimePicker)insulinPompasiVerTarihiDiabetesMellitusPursuit).Value.Date != null)
//                diabetTakipFormuKayitDVO.insulinPompasiVerTarihi = ((TTDateTimePicker)insulinPompasiVerTarihiDiabetesMellitusPursuit).Value.Date.ToShortDateString();
//            else
//            {
//                if (diabetTakipFormuKayitDVO.insulinPompasi == "V")
//                    throw new Exception("Diabet Takip Formu Kaydı için insülin pompası verilmiş ise insülin Pompası Veriliş tarihi bilgisi dolu olmalıdır!");
//                diabetTakipFormuKayitDVO.insulinPompasiVerTarihi = "";
//            }
//            //insulinPompasiDegTarihi
//            if (insulinPompasiDegTarihiDiabetesMellitusPursuit != null && ((TTDateTimePicker)insulinPompasiDegTarihiDiabetesMellitusPursuit).Value != null && ((TTDateTimePicker)insulinPompasiDegTarihiDiabetesMellitusPursuit).Value.Date != null)
//                diabetTakipFormuKayitDVO.insulinPompasiDegTarihi = ((TTDateTimePicker)insulinPompasiDegTarihiDiabetesMellitusPursuit).Value.Date.ToShortDateString();
//            else
//            {
//                if (diabetTakipFormuKayitDVO.insulinPompasi == "V")
//                    throw new Exception("Diabet Takip Formu Kaydı için nsülin pompası verilmiş ise insülin Pompası Değiştirme tarihi bilgisi dolu olmalıdır!");
//                diabetTakipFormuKayitDVO.insulinPompasiDegTarihi = "";
//            }
//            takipFormuKaydetGirisDVO.diabetTakipFormu = diabetTakipFormuKayitDVO;
//
//            // kullanıcı tesis kodu
//            takipFormuKaydetGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
//
//            return takipFormuKaydetGirisDVO;
//        }
//        
//        
//        public String getMedulaCode(VarYokEnum varYokEnum)
//        {
//            if (varYokEnum == VarYokEnum.B)
//                return "B";
//            else if (varYokEnum == VarYokEnum.V)
//                return "V";
//            else if (varYokEnum == VarYokEnum.Y)
//                return "Y";
//            else
//                return "";
//        }
//
//        public TakipFormuIslemleri.takipFormuDoktorBilgisiDVO[] getTakipFormuDoktorBilgisiDVOList(TTObjectContext con)
//        {
//            
//            List<TakipFormuIslemleri.takipFormuDoktorBilgisiDVO> doktorBilgisiDVOList = new List<TakipFormuIslemleri.takipFormuDoktorBilgisiDVO>();
//
//            if (DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor != null && DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows.Count > 0)
//            {
//                for (int i=0; i < DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows.Count ;i++)
//                {
//                    ResUser doctor ;
//                    TakipFormuIslemleri.takipFormuDoktorBilgisiDVO doktorBilgisi = new TakipFormuIslemleri.takipFormuDoktorBilgisiDVO();
//                    if (DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[drTescilNoDiabetesMellitusPursuitDoctor.Name].Value != null)
//                    {
//                        doctor = (ResUser)con.QueryObjects("RESUSER", "OBJECTID = '" + DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[drTescilNoDiabetesMellitusPursuitDoctor.Name].Value.ToString() + "'")[0];
//                        doktorBilgisi.drTescilNo = doctor.DiplomaRegisterNo;
//                    }
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen doktorun dr tescil no alanı dolu olmalıdır!");
//
//                    if (DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[drBransKoduDiabetesMellitusPursuitDoctor.Name].Value != null)
//                        doktorBilgisi.drBransKodu = DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[drBransKoduDiabetesMellitusPursuitDoctor.Name].Value.ToString();
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen doktorun dr branş kodu alanı dolu olmalıdır!");
//
//                    if (DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitDoctor.Name].Value != null)
//                    {
//                        if ( (EvetHayirDurumEnum)DiabetesMellitusPursuitDoctorDiabetesMellitusPursuitDoctor.Rows[i].Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitDoctor.Name].Value == EvetHayirDurumEnum.E)
//                            doktorBilgisi.dmEgitimiAlmisMi = "E";
//                        else
//                            doktorBilgisi.dmEgitimiAlmisMi = "H";
//                    }
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen doktorun diabet eğitimi alıp/almamış olma durumu dolu olmalıdır!");
//                    doktorBilgisiDVOList.Add(doktorBilgisi);
//                }
//
//            }
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için doktor bilgileri gönderimi zorunludur.");
//            return doktorBilgisiDVOList.ToArray();
//        }
//
//
//        public TakipFormuIslemleri.takipFormuHastalikDVO[] getTakipFormuHastalikDVOList()
//        {
//            List<TakipFormuIslemleri.takipFormuHastalikDVO> hastalikDVOList = new List<TakipFormuIslemleri.takipFormuHastalikDVO>();
//
//            if (DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease != null && DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows != null && DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows.Count > 0)
//            {
//                for (int i = 0; i < DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows.Count; i++ )
//                {
//                    TakipFormuIslemleri.takipFormuHastalikDVO hastalik = new TakipFormuIslemleri.takipFormuHastalikDVO();
//                    if (DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[hastalikKoduDiabetesMellitusPursuitDisease.Name] != null && DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[hastalikKoduDiabetesMellitusPursuitDisease.Name].Value != null)
//                    {
//                        hastalik.hastalikKodu = Convert.ToInt32(DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[hastalikKoduDiabetesMellitusPursuitDisease.Name].Value.ToString());
//                        if ((HastalikKoduEnum) DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[hastalikKoduDiabetesMellitusPursuitDisease.Name].Value == HastalikKoduEnum.Diger)
//                        {
//                            if (DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[digerHastalikTaniKoduDiabetesMellitusPursuitDisease.Name].Value != null)
//                                hastalik.digerHastalikTaniKodu = DiabetesMellitusPursuitDiseaseDiabetesMellitusPursuitDisease.Rows[i].Cells[digerHastalikTaniKoduDiabetesMellitusPursuitDisease.Name].Value.ToString();
//                            else
//                                throw new Exception("Diabet Takip Formu Kaydı için girilen hastalığın kodu diğer seçildiğinden diğer hastalık kodu alanı dolu olmalıdır!");
//                        }
//                    }
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen hastalığın kodu dolu olmalıdır!");
//
//                    hastalikDVOList.Add(hastalik);
//                }
//            }
//            return hastalikDVOList.ToArray();
//        }
//
//        public TakipFormuIslemleri.takipFormuDiabetEgitimiDVO getTakipFormuDiabetEgitimiDVO()
//        {
//
//            if (DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction != null && DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows != null && DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows.Count > 0)
//            {
//                for (int i = 0; i < DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows.Count; i++ )
//                {
//                    TakipFormuIslemleri.takipFormuDiabetEgitimiDVO diabetEgitimi = new TakipFormuIslemleri.takipFormuDiabetEgitimiDVO();
//                    if (DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[bireyselEgitimSayisiDiabetesMellitusPursuitInstruction.Name].Value != null)
//                        diabetEgitimi.bireyselEgitimSayisi = Convert.ToInt32(DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[bireyselEgitimSayisiDiabetesMellitusPursuitInstruction.Name].Value.ToString());
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen diabet eğitiminin bireysel eğitim sayısı bilgisi dolu olmalıdır!");
//                    if (DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[grupEgitimiSayisiDiabetesMellitusPursuitInstruction.Name].Value != null)
//                        diabetEgitimi.grupEgitimiSayisi = Convert.ToInt32(DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[grupEgitimiSayisiDiabetesMellitusPursuitInstruction.Name].Value);
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen diabet eğitiminin grup eğitimi sayısı bilgisi dolu olmalıdır!");
//
//                    if (DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitInstruction.Name].Value != null)
//                    {
//                        if ( (EvetHayirDurumEnum)DiabetesMellitusPursuitInstructionDiabetesMellitusPursuitInstruction.Rows[i].Cells[dmEgitimiAlmisMiDiabetesMellitusPursuitInstruction.Name].Value == EvetHayirDurumEnum.E)
//                            diabetEgitimi.dmEgitimiAlmisMi = "E";
//                        else
//                            diabetEgitimi.dmEgitimiAlmisMi = "H";
//                    }
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen diabet eğitim bilgilerindeki diabet eğitimi alıp/almamış olma durumu dolu olmalıdır!");
//                    return diabetEgitimi;
//                }
//            }
//            else
//                throw new Exception("Diabet Takip Formu Kaydı için diyabet eğitim bilgileri zorunludur.");
//            return null;
//        }
//
//        public TakipFormuIslemleri.takipFormuAliskanlikDVO[] getTakipFormuAliskanlikDVOList()
//        {
//            List<TakipFormuIslemleri.takipFormuAliskanlikDVO> aliskanlikDVOList = new List<TakipFormuIslemleri.takipFormuAliskanlikDVO>();
//
//            if (DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit != null && DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows != null && DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows.Count > 0)
//            {
//                for (int i=0 ; i< DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows.Count ; i++)
//                {
//                    TakipFormuIslemleri.takipFormuAliskanlikDVO aliskanlik = new TakipFormuIslemleri.takipFormuAliskanlikDVO();
//                    if (DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows[i].Cells[aliskanlikDiabetesMellitusPursuitHabit.Name].Value != null)
//                        aliskanlik.aliskanlik = Convert.ToInt32(DiabetesMellitusPursuitHabitDiabetesMellitusPursuitHabit.Rows[i].Cells[aliskanlikDiabetesMellitusPursuitHabit.Name].Value.ToString());
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen hastaya ait alışkanlık bilgilerinden alışkanlık bilgisi dolu olmalıdır!");
//                    aliskanlikDVOList.Add(aliskanlik);
//                }
//            }
//            return aliskanlikDVOList.ToArray();
//        }
//
//        public TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO[] getTakipFormuKullanilanIlacDVOList()
//        {
//            List<TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO> kullanilanIlacDVOList = new List<TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO>();
//
//            if (DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug != null && DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows != null && DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows.Count > 0)
//            {
//                for (int i = 0; i < DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows.Count; i++ )
//                {
//                    TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO kullanilanIlac = new TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO();
//
//                    if (DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows[i].Cells[barkodDiabetesMellitusPursuitUsedDrug.Name].Value != null)
//                        kullanilanIlac.barkod = DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows[i].Cells[barkodDiabetesMellitusPursuitUsedDrug.Name].Value.ToString();
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen kullanılan ilac bilgilerinden barkod bilgisi dolu olmalıdır!");
//                    if (DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows[i].Cells[gunlukDozDiabetesMellitusPursuitUsedDrug.Name].Value != null)
//                        kullanilanIlac.gunlukDoz = DiabetesMellitusPursuitUsedDrugDiabetesMellitusPursuitUsedDrug.Rows[i].Cells[gunlukDozDiabetesMellitusPursuitUsedDrug.Name].Value.ToString();
//                    else
//                        throw new Exception("Diabet Takip Formu Kaydı için girilen kullanılan ilac bilgilerinden günlük doz bilgisi dolu olmalıdır!");
//                    kullanilanIlacDVOList.Add(kullanilanIlac);
//                }
//            }
//            return kullanilanIlacDVOList.ToArray();
//        }
        
#endregion MedulaDiabetTakipFormuIslemleri_Methods
    }
}