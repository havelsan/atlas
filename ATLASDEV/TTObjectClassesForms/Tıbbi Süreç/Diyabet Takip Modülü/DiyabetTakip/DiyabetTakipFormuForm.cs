
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
    /// Diyabet Takip Formu
    /// </summary>
    public partial class DiyabetTakipFormu : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttbuttonDiyabetTakipFormuKaydet.Click += new TTControlEventDelegate(ttbuttonDiyabetTakipFormuKaydet_Click);
            btnChoose.Click += new TTControlEventDelegate(btnChoose_Click);
            cmdSaveAsTemplate.Click += new TTControlEventDelegate(cmdSaveAsTemplate_Click);
            cmdDeleteTemplate.Click += new TTControlEventDelegate(cmdDeleteTemplate_Click);
            btnMedulayaTopluGonder.Click += new TTControlEventDelegate(btnMedulayaTopluGonder_Click);
            cmdLoadTemplate.Click += new TTControlEventDelegate(cmdLoadTemplate_Click);
            kiloDiabetesMellitusPursuit.TextChanged += new TTControlEventDelegate(kiloDiabetesMellitusPursuit_TextChanged);
            boyDiabetesMellitusPursuit.TextChanged += new TTControlEventDelegate(boyDiabetesMellitusPursuit_TextChanged);
            ttgridDiabetTakipFormlari.CellContentClick += new TTGridCellEventDelegate(ttgridDiabetTakipFormlari_CellContentClick);
            ttbuttonOku.Click += new TTControlEventDelegate(ttbuttonOku_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbuttonDiyabetTakipFormuKaydet.Click -= new TTControlEventDelegate(ttbuttonDiyabetTakipFormuKaydet_Click);
            btnChoose.Click -= new TTControlEventDelegate(btnChoose_Click);
            cmdSaveAsTemplate.Click -= new TTControlEventDelegate(cmdSaveAsTemplate_Click);
            cmdDeleteTemplate.Click -= new TTControlEventDelegate(cmdDeleteTemplate_Click);
            btnMedulayaTopluGonder.Click -= new TTControlEventDelegate(btnMedulayaTopluGonder_Click);
            cmdLoadTemplate.Click -= new TTControlEventDelegate(cmdLoadTemplate_Click);
            kiloDiabetesMellitusPursuit.TextChanged -= new TTControlEventDelegate(kiloDiabetesMellitusPursuit_TextChanged);
            boyDiabetesMellitusPursuit.TextChanged -= new TTControlEventDelegate(boyDiabetesMellitusPursuit_TextChanged);
            ttgridDiabetTakipFormlari.CellContentClick -= new TTGridCellEventDelegate(ttgridDiabetTakipFormlari_CellContentClick);
            ttbuttonOku.Click -= new TTControlEventDelegate(ttbuttonOku_Click);
            base.UnBindControlEvents();
        }

        private void ttbuttonDiyabetTakipFormuKaydet_Click()
        {
#region DiyabetTakipFormu_ttbuttonDiyabetTakipFormuKaydet_Click
   this._DiyabetTakip.MedulaDiabetTakipFormuKaydet();
#endregion DiyabetTakipFormu_ttbuttonDiyabetTakipFormuKaydet_Click
        }

        private void btnChoose_Click()
        {
            #region DiyabetTakipFormu_btnChoose_Click
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
            #endregion DiyabetTakipFormu_btnChoose_Click
        }

        private void cmdSaveAsTemplate_Click()
        {
#region DiyabetTakipFormu_cmdSaveAsTemplate_Click
   string templateName = InputForm.GetText("Şablon adını giriniz.");
            DiabetesMellitusPursuitTemplate dpsTemp = new DiabetesMellitusPursuitTemplate(_DiyabetTakip.ObjectContext);
            dpsTemp.ResUser = Common.CurrentResource;
            dpsTemp.TemplateName = templateName;
            _DiyabetTakip.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt = dpsTemp;
            InfoBox.Show("Şablon kaydedildi.", MessageIconEnum.InformationMessage);
#endregion DiyabetTakipFormu_cmdSaveAsTemplate_Click
        }

        private void cmdDeleteTemplate_Click()
        {
#region DiyabetTakipFormu_cmdDeleteTemplate_Click
   if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Mevcut şablon silinecek.\nDevam etmek istediğinize emin misiniz?") == "E")
            {
                if (_DiyabetTakip.DiabetesMellitusPursuit != null && _DiyabetTakip.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt != null)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    Guid objectID = _DiyabetTakip.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt.ObjectID;
                    IBindingList objects = context.QueryObjects(typeof(DiabetesMellitusPursuit).Name, "DIABETESMELLITUSPURSUITTMPLT = '" + _DiyabetTakip.DiabetesMellitusPursuit.DiabetesMellitusPursuitTmplt.ObjectID.ToString() + "'");
                    foreach (DiabetesMellitusPursuit pts in objects)
                    {
                        pts.DiabetesMellitusPursuitTmplt = null;
                    }
                    
                    DiabetesMellitusPursuitTemplate tempToDel = (DiabetesMellitusPursuitTemplate)context.GetObject(objectID, typeof(DiabetesMellitusPursuitTemplate).Name);
                    ((ITTObject)tempToDel).Delete();
                    context.Save();
                    context.Dispose();
                    InfoBox.Show("Şablon silindi.", MessageIconEnum.InformationMessage);
                }
            }
#endregion DiyabetTakipFormu_cmdDeleteTemplate_Click
        }

        private void btnMedulayaTopluGonder_Click()
        {
#region DiyabetTakipFormu_btnMedulayaTopluGonder_Click
   TTObjectContext context = new TTObjectContext(false);
            IBindingList _list = context.QueryObjects(typeof(DiyabetTakip).Name, "DIABETESMELLITUSPURSUIT IS NOT NULL");
            if (_list != null && _list.Count > 0)
            {
                string uKey = "";
                string filename = string.Empty;
                int count = 0;
                uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Diyabet Takip Formu", _list.Count + " Hastanın Diyabet Takip Formu Medulaya Gönderilecektir. Devam Etmek İstiyor musunuz?");
                if (String.IsNullOrEmpty(uKey) || uKey == "E")
                {
                    if (string.IsNullOrEmpty(FilePath.Text) == true)
                        throw new TTUtils.TTException("Hatalı Kayıtları Görebilmek İçin Dosya Yolunu Seçmelisiniz");
                    //else
                    //    filename = System.IO.Path.Combine(FilePath.Text, "HATALIKAYITLAR.txt");
                    
                    string s = string.Empty;
                    foreach (DiyabetTakip item in _list)
                    {
                        if(string.IsNullOrEmpty(item.DiabetesMellitusPursuit.takipFormuNo))
                        {
                            count++;
                            if (count == 1)
                            {
                                //if (string.IsNullOrEmpty(filename) == false)
                                //    System.IO.File.Delete(filename);

                                s = System.DateTime.Now.ToShortDateString() + "\r\n";
                            }
                            
                            TakipFormuIslemleri.takipFormuKaydetGirisDVO takipFormuKaydetGirisDVO = new TakipFormuIslemleri.takipFormuKaydetGirisDVO();

                            TakipFormuIslemleri.diabetTakipFormuKayitDVO diabetTakipFormuKayitDVO = new TakipFormuIslemleri.diabetTakipFormuKayitDVO();


                            //Hastanın Bilgileri
                            // TC Kimlik No//Zorunlu
                            if (item.Episode.Patient != null && item.Episode.Patient.UniqueRefNo != null)
                                diabetTakipFormuKayitDVO.tcKimlikNo = item.Episode.Patient.UniqueRefNo.Value.ToString();

                            // Ad//Zorunlu
                            if (item.Episode.Patient != null &&  !string.IsNullOrEmpty(item.Episode.Patient.Name))
                                diabetTakipFormuKayitDVO.ad = item.Episode.Patient.Name;

                            // Soyad//Zorunlu
                            if (item.Episode.Patient != null &&  !string.IsNullOrEmpty(item.Episode.Patient.Surname))
                                diabetTakipFormuKayitDVO.soyad = item.Episode.Patient.Surname;


                            // Cep Telefonu//Zorunlu
                            String mobilePhone = "";
                        
                            if (item.Episode.Patient != null && !string.IsNullOrEmpty(item.Episode.Patient.PatientAddress.MobilePhone))
                            {

                                mobilePhone = item.Episode.Patient.PatientAddress.MobilePhone.Replace('(', ' ');
                                mobilePhone = mobilePhone.Replace(')', ' ');
                                mobilePhone = mobilePhone.Remove(4, 1);
                                diabetTakipFormuKayitDVO.cepTel = mobilePhone.Trim();
                            }
                            else if (item.Episode.Patient != null && !string.IsNullOrEmpty(item.Episode.Patient.PatientAddress.HomePhone))
                            {
                                mobilePhone = this._DiyabetTakip.Episode.Patient.PatientAddress.HomePhone.Replace('(', ' ');
                                mobilePhone = mobilePhone.Replace(')', ' ');
                                mobilePhone = mobilePhone.Remove(4, 1);
                                diabetTakipFormuKayitDVO.cepTel = mobilePhone.Trim();
                            }
                      

                            // protokol No//Zorunlu
                            if (!string.IsNullOrEmpty(item.DiabetesMellitusPursuit.protokolNo))
                                diabetTakipFormuKayitDVO.protokolNo = item.DiabetesMellitusPursuit.protokolNo;
                            

                            // vizit tarihi//Zorunlu
                            if (item.DiabetesMellitusPursuit.vizitTarihi != null && item.DiabetesMellitusPursuit.vizitTarihi.Value != null)
                                diabetTakipFormuKayitDVO.vizitTarihi = item.DiabetesMellitusPursuit.vizitTarihi.Value.ToShortDateString();
                            else
                                diabetTakipFormuKayitDVO.vizitTarihi=this._DiyabetTakip.SubEpisode.PatientAdmission.ActionDate.Value.ToShortDateString();

                            // sağlık tesis kodu
                            diabetTakipFormuKayitDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                            // Cinsiyet//Zorunlu
                            if (item.Episode.Patient != null && item.Episode.Patient.Sex != null )
                            {
                                if (item.Episode.Patient.Sex.ADI == "KADIN")
                                    diabetTakipFormuKayitDVO.cinsiyet = "K";
                                else
                                    diabetTakipFormuKayitDVO.cinsiyet = "E";

                            }



                            // ikamet Türü//Zorunlu
                            if (item.DiabetesMellitusPursuit.ikametTuru != null )
                                diabetTakipFormuKayitDVO.ikametTuru = item.DiabetesMellitusPursuit.ikametTuru.GetHashCode();
                            else
                                diabetTakipFormuKayitDVO.ikametTuru = (int)ikametTuruEnum.IlMerkezi;

                            // TODO Doktor Bilgileri
                            List<TakipFormuIslemleri.takipFormuDoktorBilgisiDVO> doktorBilgisiDVOList = new List<TakipFormuIslemleri.takipFormuDoktorBilgisiDVO>();

                            if (item.DiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor != null && item.DiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor.Count > 0)
                            {
                                foreach (DiabetesMellitusPursuitDoctor doctor in item.DiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor)
                                {
                                    TakipFormuIslemleri.takipFormuDoktorBilgisiDVO doktorBilgisi = new TakipFormuIslemleri.takipFormuDoktorBilgisiDVO();
                                    if (doctor.Doktor != null && !string.IsNullOrEmpty(doctor.Doktor.DiplomaRegisterNo))
                                        doktorBilgisi.drTescilNo = doctor.Doktor.DiplomaRegisterNo;

                                    if (doctor.BransKodu != null && doctor.BransKodu.Code != null)
                                        doktorBilgisi.drBransKodu = doctor.BransKodu.Code;


                                    if (doctor.dmEgitimiAlmisMi != null )
                                    {
                                        if (doctor.dmEgitimiAlmisMi.Value == EvetHayirDurumEnum.E)
                                            doktorBilgisi.dmEgitimiAlmisMi = "E";
                                        else
                                            doktorBilgisi.dmEgitimiAlmisMi = "H";
                                    }

                                    doktorBilgisiDVOList.Add(doktorBilgisi);
                                }

                            }
                            if (doktorBilgisiDVOList != null && doktorBilgisiDVOList.Count > 0)
                                diabetTakipFormuKayitDVO.doktorBilgileri = doktorBilgisiDVOList.ToArray();

                            // Tanı//Zorunlu
                            if (item.DiabetesMellitusPursuit.HastaTanisi != null && item.DiabetesMellitusPursuit.HastaTanisi.Code != null)
                                diabetTakipFormuKayitDVO.taniKodu = item.DiabetesMellitusPursuit.HastaTanisi.Code;
                            else
                                diabetTakipFormuKayitDVO.taniKodu="E14.8";

                            // Tanı Tarihi//Zorunlu
                            if (item.DiabetesMellitusPursuit.taniTarihi != null && item.DiabetesMellitusPursuit.taniTarihi.Value != null)
                                diabetTakipFormuKayitDVO.taniTarihi = item.DiabetesMellitusPursuit.taniTarihi.Value.ToShortDateString();
                            else
                                diabetTakipFormuKayitDVO.taniTarihi=this._DiyabetTakip.SubEpisode.PatientAdmission.ActionDate.Value.ToShortDateString();


                            // TODO Diabet Eğitimi
                            TakipFormuIslemleri.takipFormuDiabetEgitimiDVO diabetEgitimi = new TakipFormuIslemleri.takipFormuDiabetEgitimiDVO();
                            if (item.DiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction != null && item.DiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction.Count > 0)
                            {
                                foreach (DiabetesMellitusPursuitInstruction instruction in item.DiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction)
                                {

                                    if (instruction.bireyselEgitimSayisi != null)
                                        diabetEgitimi.bireyselEgitimSayisi = Convert.ToInt32(instruction.bireyselEgitimSayisi);

                                    if (instruction.grupEgitimiSayisi != null)
                                        diabetEgitimi.grupEgitimiSayisi = Convert.ToInt32(instruction.grupEgitimiSayisi);


                                    if (instruction.dmEgitimiAlmisMi != null)
                                    {
                                        if (instruction.dmEgitimiAlmisMi.Value == EvetHayirDurumEnum.E)
                                            diabetEgitimi.dmEgitimiAlmisMi = "E";
                                        else
                                            diabetEgitimi.dmEgitimiAlmisMi = "H";
                                    }

                                }
                            }

                            if(string.IsNullOrEmpty(diabetEgitimi.dmEgitimiAlmisMi))
                                diabetEgitimi.dmEgitimiAlmisMi = "H";
                            diabetTakipFormuKayitDVO.diabetEgitimi = diabetEgitimi;

                            //Tıbbı Beslenme Tedavisi//Zorunlu
                            if (item.DiabetesMellitusPursuit.tibbiBeslenmeTedavisi != null )
                                diabetTakipFormuKayitDVO.tibbiBeslenmeTedavisi = Convert.ToInt32(item.DiabetesMellitusPursuit.tibbiBeslenmeTedavisi.GetHashCode().ToString());
                            else
                                diabetTakipFormuKayitDVO.tibbiBeslenmeTedavisi = (int)TibbiBeslenmeTedavisiEnum.Bilinmiyor;

                            //Egzersiz//Zorunlu
                            if (item.DiabetesMellitusPursuit.egzersiz != null )
                                diabetTakipFormuKayitDVO.egzersiz = Convert.ToInt32(item.DiabetesMellitusPursuit.egzersiz.GetHashCode().ToString());
                            else
                                diabetTakipFormuKayitDVO.egzersiz = (int)EgzersizEnum.Bilinmiyor;

                            //TODO Hastalıklar Zorunlu değil
                            List<TakipFormuIslemleri.takipFormuHastalikDVO> hastalikDVOList = new List<TakipFormuIslemleri.takipFormuHastalikDVO>();

                            if (item.DiabetesMellitusPursuit.DiabetesMellitusPursuitDisease != null && item.DiabetesMellitusPursuit.DiabetesMellitusPursuitDisease.Count > 0)
                            {
                                foreach (DiabetesMellitusPursuitDisease disease in item.DiabetesMellitusPursuit.DiabetesMellitusPursuitDisease)
                                {
                                    TakipFormuIslemleri.takipFormuHastalikDVO hastalik = new TakipFormuIslemleri.takipFormuHastalikDVO();
                                    if (disease.hastalikKodu != null )
                                    {
                                        hastalik.hastalikKodu = Convert.ToInt32(disease.hastalikKodu.GetHashCode().ToString());
                                        if (disease.hastalikKodu.Value == HastalikKoduEnum.Diger)
                                        {
                                            if (disease.digerHastalikTaniKodu != null)
                                                hastalik.digerHastalikTaniKodu = disease.digerHastalikTaniKodu;

                                        }
                                    }


                                    hastalikDVOList.Add(hastalik);
                                }
                            }
                            if (hastalikDVOList != null && hastalikDVOList.Count > 0)
                                diabetTakipFormuKayitDVO.hastaliklar = hastalikDVOList.ToArray();

                            //Başvuru Nedeni//Zorunlu
                            if (item.DiabetesMellitusPursuit.basvuruNedeni != null )
                                diabetTakipFormuKayitDVO.basvuruNedeni = Convert.ToInt32(item.DiabetesMellitusPursuit.basvuruNedeni.GetHashCode().ToString());
                            else
                                diabetTakipFormuKayitDVO.basvuruNedeni = (int)BasvuruNedeniEnum.GenelKontrol;

                            //TODO ALışkanlıklar zorunlu değil
                            List<TakipFormuIslemleri.takipFormuAliskanlikDVO> aliskanlikDVOList = new List<TakipFormuIslemleri.takipFormuAliskanlikDVO>();

                            if (item.DiabetesMellitusPursuit.DiabetesMellitusPursuitHabit != null && item.DiabetesMellitusPursuit.DiabetesMellitusPursuitHabit.Count > 0)
                            {
                                foreach (DiabetesMellitusPursuitHabit habit in item.DiabetesMellitusPursuit.DiabetesMellitusPursuitHabit)
                                {
                                    TakipFormuIslemleri.takipFormuAliskanlikDVO aliskanlik = new TakipFormuIslemleri.takipFormuAliskanlikDVO();
                                    if (habit.aliskanlik != null )
                                        aliskanlik.aliskanlik = Convert.ToInt32(habit.aliskanlik.GetHashCode().ToString());

                                    aliskanlikDVOList.Add(aliskanlik);
                                }
                            }
                            if (aliskanlikDVOList != null && aliskanlikDVOList.Count > 0)
                                diabetTakipFormuKayitDVO.aliskanliklar = aliskanlikDVOList.ToArray();

                            // Glukometre//Zorunlu
                            if (item.DiabetesMellitusPursuit.glukoMetre != null )
                                diabetTakipFormuKayitDVO.glukoMetre = this._DiyabetTakip.getMedulaCode(item.DiabetesMellitusPursuit.glukoMetre.Value);
                            else
                                diabetTakipFormuKayitDVO.glukoMetre = VarYokEnum.Y.ToString();

                            //Kan Şekeri takip sayısı//Zorunlu
                            if (item.DiabetesMellitusPursuit.kanSekeriTakipSayisi != null)
                                diabetTakipFormuKayitDVO.kanSekeriTakipSayisi = Convert.ToInt32(item.DiabetesMellitusPursuit.kanSekeriTakipSayisi);
                            else
                                diabetTakipFormuKayitDVO.kanSekeriTakipSayisi = 3;

                            //TODO Kullanılan İlaçlar zorunlu değil
                            List<TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO> kullanilanIlacDVOList = new List<TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO>();

                            if (item.DiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug != null && item.DiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug.Count > 0)
                            {
                                foreach (DiabetesMellitusPursuitUsedDrug usedDrug in item.DiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug)
                                {
                                    TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO kullanilanIlac = new TakipFormuIslemleri.takipFormuKullanilanIlaclarDVO();

                                    if (usedDrug.barkod != null)
                                        kullanilanIlac.barkod = usedDrug.barkod;

                                    if (usedDrug.gunlukDoz != null)
                                        kullanilanIlac.gunlukDoz = usedDrug.gunlukDoz;

                                    kullanilanIlacDVOList.Add(kullanilanIlac);
                                }
                            }
                            if (kullanilanIlacDVOList != null && kullanilanIlacDVOList.Count > 0)
                                diabetTakipFormuKayitDVO.kullanilanIlaclar = kullanilanIlacDVOList.ToArray();

                            //Sistolik Kan Basıncı zorunlu değil
                            if (item.DiabetesMellitusPursuit.sistolikKanBasinci != null)
                                diabetTakipFormuKayitDVO.sistolikKanBasinci = Convert.ToInt32(item.DiabetesMellitusPursuit.sistolikKanBasinci);

                            //Diyastolik Kan Basıncı zorunlu değil
                            if (item.DiabetesMellitusPursuit.diyastolikKanBasinci != null)
                                diabetTakipFormuKayitDVO.diyastolikKanBasinci = Convert.ToInt32(item.DiabetesMellitusPursuit.diyastolikKanBasinci);

                            //Boy
                            if (item.DiabetesMellitusPursuit.boy != null)
                                diabetTakipFormuKayitDVO.boy = Convert.ToDouble(item.DiabetesMellitusPursuit.boy);
                            else
                                diabetTakipFormuKayitDVO.boy = Convert.ToDouble("170");

                            //Kilo
                            if (item.DiabetesMellitusPursuit.kilo != null)
                                diabetTakipFormuKayitDVO.kilo = Convert.ToDouble(item.DiabetesMellitusPursuit.kilo);
                            else
                                diabetTakipFormuKayitDVO.kilo = Convert.ToDouble("60");

                            //VKİ
                            if (item.DiabetesMellitusPursuit.vki != null)
                                diabetTakipFormuKayitDVO.vki = Convert.ToDouble(item.DiabetesMellitusPursuit.vki);
                            else
                                diabetTakipFormuKayitDVO.vki = Convert.ToDouble("21");

                            // APG
                            if (item.DiabetesMellitusPursuit.apg != null)
                                diabetTakipFormuKayitDVO.apg = Convert.ToDouble(item.DiabetesMellitusPursuit.apg);
                            else
                                diabetTakipFormuKayitDVO.apg = Convert.ToDouble("1");

                            // TPG
                            if (item.DiabetesMellitusPursuit.tpg != null)
                                diabetTakipFormuKayitDVO.tpg = Convert.ToDouble(item.DiabetesMellitusPursuit.tpg);
                            else
                                diabetTakipFormuKayitDVO.tpg = Convert.ToDouble("1");

                            //HbA1c
                            if (item.DiabetesMellitusPursuit.hbA1c != null)
                                diabetTakipFormuKayitDVO.hbA1c = Convert.ToDouble(item.DiabetesMellitusPursuit.hbA1c);
                            else
                                diabetTakipFormuKayitDVO.hbA1c = Convert.ToDouble("0");

                            //Kreatinin
                            if (item.DiabetesMellitusPursuit.kreatinin != null)
                                diabetTakipFormuKayitDVO.kreatinin = Convert.ToDouble(item.DiabetesMellitusPursuit.kreatinin);
                            else
                                diabetTakipFormuKayitDVO.kreatinin = Convert.ToDouble("0");

                            //Trigliserid
                            if (item.DiabetesMellitusPursuit.trigliserid != null)
                                diabetTakipFormuKayitDVO.trigliserid = Convert.ToDouble(item.DiabetesMellitusPursuit.trigliserid);
                            else
                                diabetTakipFormuKayitDVO.trigliserid = Convert.ToDouble("0");

                            //LDL-Kol
                            if (item.DiabetesMellitusPursuit.ldlKol != null)
                                diabetTakipFormuKayitDVO.ldlKol = Convert.ToDouble(item.DiabetesMellitusPursuit.ldlKol);
                            else
                                diabetTakipFormuKayitDVO.ldlKol = Convert.ToDouble("0");

                            //HDL-Kol
                            if (item.DiabetesMellitusPursuit.hdlKol != null)
                                diabetTakipFormuKayitDVO.hdlKol = Convert.ToDouble(item.DiabetesMellitusPursuit.hdlKol);
                            else
                                diabetTakipFormuKayitDVO.hdlKol = Convert.ToDouble("0");

                            //ALT
                            if (item.DiabetesMellitusPursuit.alt != null)
                                diabetTakipFormuKayitDVO.alt = Convert.ToDouble(item.DiabetesMellitusPursuit.alt);
                            else
                                diabetTakipFormuKayitDVO.alt = Convert.ToDouble("0");

                            //AntiGAD
                            if (item.DiabetesMellitusPursuit.antiGAD != null )
                            {
                                if (item.DiabetesMellitusPursuit.antiGAD.Value == AntiGADEnum.B)
                                    diabetTakipFormuKayitDVO.antiGAD = "B";
                                else if (item.DiabetesMellitusPursuit.antiGAD.Value == AntiGADEnum.N)
                                    diabetTakipFormuKayitDVO.antiGAD = "N";
                                else if (item.DiabetesMellitusPursuit.antiGAD.Value == AntiGADEnum.P)
                                    diabetTakipFormuKayitDVO.antiGAD = "P";
                            }
                            else
                                diabetTakipFormuKayitDVO.antiGAD = "B";

                            //EKG
                            if (item.DiabetesMellitusPursuit.ekg != null )
                                diabetTakipFormuKayitDVO.ekg = Convert.ToInt32(item.DiabetesMellitusPursuit.ekg.GetHashCode().ToString());
                            else
                                diabetTakipFormuKayitDVO.ekg = (int)EkgEnum.Bilinmiyor;

                            //Mikroalbuminüri
                            if (item.DiabetesMellitusPursuit.mikroalbuminuri != null )
                                diabetTakipFormuKayitDVO.mikroalbuminuri = this._DiyabetTakip.getMedulaCode(item.DiabetesMellitusPursuit.mikroalbuminuri.Value);
                            else
                                diabetTakipFormuKayitDVO.mikroalbuminuri = VarYokEnum.Y.ToString();

                            //gozMuayenesi
                            if (item.DiabetesMellitusPursuit.gozMuayenesi != null )
                                diabetTakipFormuKayitDVO.gozMuayenesi = Convert.ToInt32(item.DiabetesMellitusPursuit.gozMuayenesi.GetHashCode().ToString());
                            else
                                diabetTakipFormuKayitDVO.gozMuayenesi = (int)GozMuayenesiEnum.Bilinmiyor;

                            //Periferik Sensoryal Nöropati
                            if (item.DiabetesMellitusPursuit.periferikSensoryal != null )
                                diabetTakipFormuKayitDVO.periferikSensoryal = this._DiyabetTakip.getMedulaCode(item.DiabetesMellitusPursuit.periferikSensoryal.Value);
                            else
                                diabetTakipFormuKayitDVO.periferikSensoryal = VarYokEnum.Y.ToString();

                            //Koroner Arter H zorunlu değil
                            if (item.DiabetesMellitusPursuit.koronerArterH != null )
                                diabetTakipFormuKayitDVO.koronerArterH = this._DiyabetTakip.getMedulaCode(item.DiabetesMellitusPursuit.koronerArterH.Value);
                            else
                                diabetTakipFormuKayitDVO.koronerArterH=  VarYokEnum.Y.ToString();
                            

                            //Serebrovasküler H
                            if (item.DiabetesMellitusPursuit.serebrovaskulerH != null)
                                diabetTakipFormuKayitDVO.serebrovaskulerH = this._DiyabetTakip.getMedulaCode(item.DiabetesMellitusPursuit.serebrovaskulerH.Value);
                            else
                                diabetTakipFormuKayitDVO.serebrovaskulerH = VarYokEnum.Y.ToString();

                            //Ayak Muayenesi
                            if (item.DiabetesMellitusPursuit.ayakMuayenesi != null )
                            {
                                if (item.DiabetesMellitusPursuit.ayakMuayenesi.Value == AyakMuayenesiEnum.B)
                                    diabetTakipFormuKayitDVO.ayakMuayenesi = "B";
                                else if (item.DiabetesMellitusPursuit.ayakMuayenesi.Value == AyakMuayenesiEnum.V)
                                    diabetTakipFormuKayitDVO.ayakMuayenesi = "V";
                                else if (item.DiabetesMellitusPursuit.ayakMuayenesi.Value == AyakMuayenesiEnum.Y)
                                    diabetTakipFormuKayitDVO.ayakMuayenesi = "Y";
                            }
                            else
                                diabetTakipFormuKayitDVO.ayakMuayenesi = AyakMuayenesiEnum.B.ToString();

                            //Akut komplikasyonu
                            if (item.DiabetesMellitusPursuit.akutKomplikasyon != null )
                                diabetTakipFormuKayitDVO.akutKomplikasyon = Convert.ToInt32(item.DiabetesMellitusPursuit.akutKomplikasyon.GetHashCode().ToString());
                            else
                                diabetTakipFormuKayitDVO.akutKomplikasyon = (int)AkutKomplikasyonEnum.HHD;

                            //Hasta Yatış Gün
                            if (item.DiabetesMellitusPursuit.yatisGun != null)
                                diabetTakipFormuKayitDVO.yatisGun = Convert.ToInt32(item.DiabetesMellitusPursuit.yatisGun);
                            else
                                diabetTakipFormuKayitDVO.yatisGun = 0;

                            //İnsulinPompasi
                            if (item.DiabetesMellitusPursuit.insulinPompasi != null )
                                diabetTakipFormuKayitDVO.insulinPompasi = this._DiyabetTakip.getMedulaCode(item.DiabetesMellitusPursuit.insulinPompasi.Value);
                            else
                                diabetTakipFormuKayitDVO.insulinPompasi = VarYokEnum.Y.ToString();


                            //insulinPompasiVerTarihi
                            if (item.DiabetesMellitusPursuit.insulinPompasiVerTarihi != null && item.DiabetesMellitusPursuit.insulinPompasiVerTarihi.Value != null)
                                diabetTakipFormuKayitDVO.insulinPompasiVerTarihi = item.DiabetesMellitusPursuit.insulinPompasiVerTarihi.Value.ToShortDateString();
                            else
                            {
                                if (item.DiabetesMellitusPursuit.insulinPompasi == VarYokEnum.V)
                                    diabetTakipFormuKayitDVO.insulinPompasiVerTarihi=this._DiyabetTakip.SubEpisode.PatientAdmission.ActionDate.Value.ToShortDateString();
                            }

                            //insulinPompasiDegTarihi
                            if (item.DiabetesMellitusPursuit.insulinPompasiDegTarihi != null && item.DiabetesMellitusPursuit.insulinPompasiDegTarihi.Value != null)
                                diabetTakipFormuKayitDVO.insulinPompasiDegTarihi = item.DiabetesMellitusPursuit.insulinPompasiDegTarihi.Value.ToShortDateString();
                            else
                            {
                                if (item.DiabetesMellitusPursuit.insulinPompasi == VarYokEnum.V)
                                    diabetTakipFormuKayitDVO.insulinPompasiDegTarihi=this._DiyabetTakip.SubEpisode.PatientAdmission.ActionDate.Value.ToShortDateString();
                            }
                            takipFormuKaydetGirisDVO.diabetTakipFormu = diabetTakipFormuKayitDVO;

                            // kullanıcı tesis kodu
                            takipFormuKaydetGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                            
                            Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());

                            TakipFormuIslemleri.takipFormuKaydetCevapDVO takipFormuKaydetCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuKaydet(siteID, takipFormuKaydetGirisDVO);
                            if (takipFormuKaydetCevapDVO != null)
                            {
                                if (string.IsNullOrEmpty(takipFormuKaydetCevapDVO.sonucKodu) == false)
                                {
                                    if (takipFormuKaydetCevapDVO.sonucKodu.Equals("0000"))
                                    {
                                        if (takipFormuKaydetCevapDVO.diabetTakipFormu != null && !string.IsNullOrEmpty(takipFormuKaydetCevapDVO.diabetTakipFormu.takipFormuNo))
                                        {
                                            item.DiabetesMellitusPursuit.takipFormuNo = takipFormuKaydetCevapDVO.diabetTakipFormu.takipFormuNo;
                                            context.Save();
                                        }
                                        
                                    }
                                    else
                                        s += diabetTakipFormuKayitDVO.tcKimlikNo + "  " + takipFormuKaydetCevapDVO.sonucKodu + "--" + takipFormuKaydetCevapDVO.sonucMesaji + "\r\n";
                                }
                            }
                        }
                    }
                    //TTUtils.Globals.Write2Log(s, filename);
                    FilePath.Text="";
                    InfoBox.Show("Gönderim İşlemi Tamamlanmıştır. Hatalı Kayıtlar için Dosyaya Bakınız",MessageIconEnum.InformationMessage);
                }
                
            }
            else
                InfoBox.Show("Takip Formu Numarası Alınmamış Hasta Bulunmamaktdır!!!",MessageIconEnum.InformationMessage);
#endregion DiyabetTakipFormu_btnMedulayaTopluGonder_Click
        }

        private void cmdLoadTemplate_Click()
        {
#region DiyabetTakipFormu_cmdLoadTemplate_Click
   IBindingList userTemplates = _DiyabetTakip.ObjectContext.QueryObjects(typeof(DiabetesMellitusPursuitTemplate).Name, "RESUSER = '" + Common.CurrentResource.ObjectID.ToString() + "'");
            if (userTemplates.Count == 0)
                InfoBox.Show("Daha önce kaydettiğiniz bir şablon bulunmamaktadır.", MessageIconEnum.InformationMessage);
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (DiabetesMellitusPursuitTemplate dps in userTemplates)
                    mSelectForm.AddMSItem(dps.TemplateName, dps.ObjectID.ToString(), dps);

                string mkey = mSelectForm.GetMSItem(this, "Şablon seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                    return;
                else
                {
                    IBindingList diabetesMellitusPursuits = _DiyabetTakip.ObjectContext.QueryObjects(typeof(DiabetesMellitusPursuit).Name, "DIABETESMELLITUSPURSUITTMPLT = '" + ((DiabetesMellitusPursuitTemplate)mSelectForm.MSSelectedItemObject).ObjectID.ToString() + "'");
                    if (diabetesMellitusPursuits.Count == 0)
                    {
                        InfoBox.Show("Seçtiğiniz şablonla kaydedilmiş herhangi bir diyabet takip raporuna ulaşılamadı!", MessageIconEnum.ErrorMessage);
                        return;
                    }
                    else
                    {
                        DiabetesMellitusPursuit targetDiabetesMellitusPursuit = (DiabetesMellitusPursuit)diabetesMellitusPursuits[0];
                        DiabetesMellitusPursuit newDiabetesMellitusPursuit = (DiabetesMellitusPursuit)((TTObject)targetDiabetesMellitusPursuit).Clone();
                        
                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction != null) {
                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction.Count; i++) {
                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction.Add((DiabetesMellitusPursuitInstruction)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitInstruction[i].Clone());
                            }
                        }
                        
                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor != null) {
                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor.Count; i++) {
                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor.Add((DiabetesMellitusPursuitDoctor)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDoctor[i].Clone());
                            }
                        }
                        
                          
                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit != null) {
                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit.Count; i++) {
                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit.Add((DiabetesMellitusPursuitHabit)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitHabit[i].Clone());
                            }
                        }
                        
                         if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug != null) {
                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug.Count; i++) {
                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug.Add((DiabetesMellitusPursuitUsedDrug)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitUsedDrug[i].Clone());
                            }
                        }
                        
                        if (targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease != null) {
                            for(int i = 0; i < targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease.Count; i++) {
                                newDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease.Add((DiabetesMellitusPursuitDisease)targetDiabetesMellitusPursuit.DiabetesMellitusPursuitDisease[i].Clone());
                            }
                        }
                        
                        
                        newDiabetesMellitusPursuit.vizitTarihi = Common.RecTime().Date;
                        newDiabetesMellitusPursuit.taniTarihi = null;
                        newDiabetesMellitusPursuit.boy = null;
                        newDiabetesMellitusPursuit.kilo = null;
                        newDiabetesMellitusPursuit.vki = null;
                        newDiabetesMellitusPursuit.insulinPompasiDegTarihi = null;
                        newDiabetesMellitusPursuit.insulinPompasiVerTarihi = null;
                        
                        _DiyabetTakip.DiabetesMellitusPursuit = newDiabetesMellitusPursuit;
                    }
                }
            }
#endregion DiyabetTakipFormu_cmdLoadTemplate_Click
        }

        private void kiloDiabetesMellitusPursuit_TextChanged()
        {
#region DiyabetTakipFormu_kiloDiabetesMellitusPursuit_TextChanged
   CalculateVKI();
#endregion DiyabetTakipFormu_kiloDiabetesMellitusPursuit_TextChanged
        }

        private void boyDiabetesMellitusPursuit_TextChanged()
        {
#region DiyabetTakipFormu_boyDiabetesMellitusPursuit_TextChanged
   CalculateVKI();
#endregion DiyabetTakipFormu_boyDiabetesMellitusPursuit_TextChanged
        }

        private void ttgridDiabetTakipFormlari_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DiyabetTakipFormu_ttgridDiabetTakipFormlari_CellContentClick
   if ((((ITTGridCell)ttgridDiabetTakipFormlari.CurrentCell).OwningColumn != null) && (((ITTGridCell)ttgridDiabetTakipFormlari.CurrentCell).OwningColumn.Name == "TakipFormuSil"))
            {
                this.tttxtboxTakipFormuNo.Text = ((ITTGridRow)((ITTGridCell)ttgridDiabetTakipFormlari.CurrentCell).OwningRow).Cells[TakipFormuNo.Name].Value.ToString();
                try
                {
                    Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());

                    TakipFormuIslemleri.takipFormuSilGirisDVO takipFormuSilGirisDVO = new TakipFormuIslemleri.takipFormuSilGirisDVO();
                    takipFormuSilGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                    if (this.tttxtboxTakipFormuNo != null && !string.IsNullOrEmpty(this.tttxtboxTakipFormuNo.Text))
                        takipFormuSilGirisDVO.takipFormuNo = this.tttxtboxTakipFormuNo.Text;
                    else
                        throw new Exception("Diabet Takip Formunun Meduladan silme işleminde Takip Formu Numarası alanı dolu olmalıdır.");

                    TakipFormuIslemleri.takipFormuSilCevapDVO takipFormuSilCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuSil(siteID, takipFormuSilGirisDVO);
                    if (takipFormuSilCevapDVO != null)
                    {
                        if (string.IsNullOrEmpty(takipFormuSilCevapDVO.sonucKodu) == false)
                        {
                            if (takipFormuSilCevapDVO.sonucKodu.Equals("0000"))
                            {
                                InfoBox.Show("Diabet Takip Formu silme işlemi başarılı şekilde yapıldı.", MessageIconEnum.InformationMessage);
                                this.ttbuttonOku_Click();
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(takipFormuSilCevapDVO.sonucMesaji) == false)
                                    throw new Exception("Diabet Takip Formunun Meduladan silme işleminde hata var. Sonuç Mesajı :" + takipFormuSilCevapDVO.sonucMesaji);
                                else
                                    throw new Exception("Diabet Takip Formunun Meduladan silme işleminde hata var.");
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(takipFormuSilCevapDVO.sonucMesaji) == false)
                                throw new Exception("Diabet Takip Formunun Meduladan silinmesi işleminde hata var: " + takipFormuSilCevapDVO.sonucMesaji);
                            else
                                throw new Exception("Diabet Takip Formunun Meduladan silinmesi sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!");
                        }

                    }
                    else
                        throw new Exception("Diabet Takip Formu Meduladan silinemedi!");

                }
                catch (Exception e)
                {
                    InfoBox.Show(e.Message);
                }
            }
#endregion DiyabetTakipFormu_ttgridDiabetTakipFormlari_CellContentClick
        }

        private void ttbuttonOku_Click()
        {
#region DiyabetTakipFormu_ttbuttonOku_Click
   try
            {
                this.ttgridDiabetTakipFormlari.Rows.Clear();
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                TakipFormuIslemleri.takipFormuOkuGirisDVO takipFormuOkuGirisDVO = new TakipFormuIslemleri.takipFormuOkuGirisDVO();
                takipFormuOkuGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                if (this._DiyabetTakip.Episode.Patient != null && this._DiyabetTakip.Episode.Patient.UniqueRefNo != null)
                    takipFormuOkuGirisDVO.tcKimlikNo = this._DiyabetTakip.Episode.Patient.UniqueRefNo.ToString();
                else
                    throw new Exception("Diabet Takip Formu Okumak için Hastanın TC Kimlik No alanı dolu olmalıdır!");

                TakipFormuIslemleri.takipFormuOkuCevapDVO takipFormuOkuCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuOku(siteID, takipFormuOkuGirisDVO);
                if (takipFormuOkuCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucKodu) == false)
                    {
                        if (takipFormuOkuCevapDVO.sonucKodu.Equals("0000"))
                        {
                            if (takipFormuOkuCevapDVO.diabetTakipFormlari != null && takipFormuOkuCevapDVO.diabetTakipFormlari.Length <= 0)
                                InfoBox.Show("Hastaya Ait Diabet Takip Formu bulunamadı", MessageIconEnum.InformationMessage);
                            else if (takipFormuOkuCevapDVO.diabetTakipFormlari != null && takipFormuOkuCevapDVO.diabetTakipFormlari.Length > 0)
                            {
                                InfoBox.Show("Hastaya Ait Diabet Takip Formlarının okunması işlemi başarılı şekilde yapıldı.", MessageIconEnum.InformationMessage);

                                // Grid Doldurulur.
                                for (int i = 0; i < takipFormuOkuCevapDVO.diabetTakipFormlari.Length; i++)
                                {
                                    TakipFormuIslemleri.diabetTakipFormuDVO diabetTakipFormuDVO = takipFormuOkuCevapDVO.diabetTakipFormlari[i];
                                    ITTGridRow row = this.ttgridDiabetTakipFormlari.Rows.Add();
                                    row.Cells[TakipFormuNo.Name].Value = diabetTakipFormuDVO.takipFormuNo;
                                    row.Cells[ProtokolNo.Name].Value = diabetTakipFormuDVO.protokolNo;
                                    row.Cells[VizitTarihi.Name].Value = diabetTakipFormuDVO.vizitTarihi;
                                    row.Cells[IkametTuru.Name].Value = diabetTakipFormuDVO.ikametTuru;
                                    row.Cells[Tani.Name].Value = diabetTakipFormuDVO.taniKodu;
                                    row.Cells[TaniTarihi.Name].Value = diabetTakipFormuDVO.taniTarihi;
                                    row.Cells[TibbiBeslenmeTedavisi.Name].Value = diabetTakipFormuDVO.tibbiBeslenmeTedavisi.ToString();
                                    row.Cells[Egzersiz.Name].Value = diabetTakipFormuDVO.egzersiz.ToString();
                                    row.Cells[BasvuruNedeni.Name].Value = diabetTakipFormuDVO.basvuruNedeni.ToString();
                                    row.Cells[GlukoMetre.Name].Value = diabetTakipFormuDVO.glukoMetre;
                                    row.Cells[KanSekeriTakipSayisi.Name].Value = diabetTakipFormuDVO.kanSekeriTakipSayisi.ToString();
                                    row.Cells[SistolikKanBasinci.Name].Value = diabetTakipFormuDVO.sistolikKanBasinci.ToString();
                                    row.Cells[DiyastolikKanBasinci.Name].Value = diabetTakipFormuDVO.diyastolikKanBasinci.ToString();
                                    row.Cells[Boy.Name].Value = diabetTakipFormuDVO.boy.ToString();
                                    row.Cells[Kilo.Name].Value = diabetTakipFormuDVO.kilo.ToString();
                                    row.Cells[VKI.Name].Value = diabetTakipFormuDVO.vki.ToString();
                                    row.Cells[APG.Name].Value = diabetTakipFormuDVO.apg.ToString();
                                    row.Cells[TPG.Name].Value = diabetTakipFormuDVO.tpg.ToString();
                                    row.Cells[HbA1c.Name].Value = diabetTakipFormuDVO.hbA1c.ToString();
                                    row.Cells[Kreatinin.Name].Value = diabetTakipFormuDVO.kreatinin.ToString();
                                    row.Cells[Trigliserid.Name].Value = diabetTakipFormuDVO.trigliserid.ToString();
                                    row.Cells[LDLKol.Name].Value = diabetTakipFormuDVO.ldlKol.ToString();
                                    row.Cells[HDLKol.Name].Value = diabetTakipFormuDVO.hdlKol.ToString();
                                    row.Cells[ALT.Name].Value = diabetTakipFormuDVO.alt.ToString();
                                    row.Cells[AntiGAD.Name].Value = diabetTakipFormuDVO.antiGAD;
                                    row.Cells[EKG.Name].Value = diabetTakipFormuDVO.ekg.ToString();
                                    row.Cells[Mikroalbuminuri.Name].Value = diabetTakipFormuDVO.mikroalbuminuri;
                                    row.Cells[GozMuayenesi.Name].Value = diabetTakipFormuDVO.gozMuayenesi.ToString();
                                    row.Cells[PeriferikSensoryalNoropati.Name].Value = diabetTakipFormuDVO.periferikSensoryal;
                                    row.Cells[KoronerArterH.Name].Value = diabetTakipFormuDVO.koronerArterH;
                                    row.Cells[SerebrovaskulerH.Name].Value = diabetTakipFormuDVO.serebrovaskulerH;
                                    row.Cells[AyakMuayenesi.Name].Value = diabetTakipFormuDVO.ayakMuayenesi;
                                    row.Cells[AkutKomplikasyon.Name].Value = diabetTakipFormuDVO.akutKomplikasyon.ToString();
                                    row.Cells[YatisGun.Name].Value = diabetTakipFormuDVO.yatisGun.ToString();
                                    row.Cells[İnsulinPompasi.Name].Value = diabetTakipFormuDVO.insulinPompasi;
                                    row.Cells[İnsulinPompasiVerTarihi.Name].Value = diabetTakipFormuDVO.insulinPompasiVerTarihi;
                                    row.Cells[İnsulinPompasiDegTarihi.Name].Value = diabetTakipFormuDVO.insulinPompasiDegTarihi;

//                                    this.tttxtboxAd.Text = diabetTakipFormuDVO.ad;
//                                    this.tttxtboxTCKimlik.Text = diabetTakipFormuDVO.tcKimlikNo;
//                                    this.tttxtboxSoyad.Text = diabetTakipFormuDVO.soyad;
//                                    this.tttxtboxCep.Text = diabetTakipFormuDVO.cepTel;
//                                    this.tttxtboxCinsiyet.Text = diabetTakipFormuDVO.cinsiyet;
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucMesaji) == false)
                              
                                throw new Exception("Meduladan gelen mesaj : " + takipFormuOkuCevapDVO.sonucMesaji);
                            else
                                throw new Exception("Hastaya Ait Diabet Takip Formlarının Meduladan okunması işleminde hata var.");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucMesaji) == false)
                           
                            throw new Exception("Meduladan gelen mesaj : " + takipFormuOkuCevapDVO.sonucMesaji);
                        else
                            throw new Exception("Hastaya Ait Diabet Takip Formlarının Meduladan okunması sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!");
                    }
                }
                else
                    throw new Exception("Hastaya Ait Diabet Takip Formları Meduladan okunamadı!");

            }
            catch (Exception e)
            {
                InfoBox.Show(e.Message);
            }
#endregion DiyabetTakipFormu_ttbuttonOku_Click
        }

        protected override void PreScript()
        {
#region DiyabetTakipFormu_PreScript
    base.PreScript();
            
            if(this._DiyabetTakip.Episode != null && this._DiyabetTakip.Episode.Patient != null)
            {
                if(SubEpisode.IsSGKSubEpisode(_DiyabetTakip.SubEpisode) == false)
                    throw new Exception ("Medula ile bağlantılı olmayan hastalarda Diyabet Takip Formu yazılamaz.");
                
                if(this._DiyabetTakip.DiabetesMellitusPursuit == null)
                    this._DiyabetTakip.DiabetesMellitusPursuit = new DiabetesMellitusPursuit(this._DiyabetTakip.ObjectContext);
                
                if(this._DiyabetTakip.Episode.HospitalProtocolNo != null && this._DiyabetTakip.Episode.HospitalProtocolNo.Value !=null)
                    this._DiyabetTakip.DiabetesMellitusPursuit.protokolNo= this._DiyabetTakip.Episode.HospitalProtocolNo.Value.ToString();
                
                tttxtboxAd.Text = this._DiyabetTakip.Episode.Patient.Name;
                tttxtboxAd.Tag = this._DiyabetTakip.Episode.Patient.ObjectID;
                tttxtboxSoyad.Text = this._DiyabetTakip.Episode.Patient.Surname;
                tttxtboxTCKimlik.Text = this._DiyabetTakip.Episode.Patient.UniqueRefNo != null ? this._DiyabetTakip.Episode.Patient.UniqueRefNo.Value.ToString() : "";
                 tttxtboxCep.Text = this._DiyabetTakip.Episode.Patient.PatientAddress.MobilePhone != null ? this._DiyabetTakip.Episode.Patient.PatientAddress.MobilePhone.ToString() : "";
                if (this._DiyabetTakip.Episode.Patient.Sex != null)
                {
                    if (this._DiyabetTakip.Episode.Patient.Sex.ADI == "ERKEK")
                        tttxtboxCinsiyet.Text = "Erkek";
                    else 
                        tttxtboxCinsiyet.Text = "Bayan";
                }
            }
#endregion DiyabetTakipFormu_PreScript

            }
            
#region DiyabetTakipFormu_Methods
        public void CalculateVKI()
        {
            if(string.IsNullOrEmpty(this.boyDiabetesMellitusPursuit.Text) || string.IsNullOrEmpty(this.kiloDiabetesMellitusPursuit.Text))
                return;
            
            string sboy= String.IsNullOrEmpty(this.boyDiabetesMellitusPursuit.Text) ? "0" : this.boyDiabetesMellitusPursuit.Text.Replace('.',',') ;
            double boy = Convert.ToDouble(sboy)/100;
            string skilo = String.IsNullOrEmpty(this.kiloDiabetesMellitusPursuit.Text) ? "0" : this.kiloDiabetesMellitusPursuit.Text.Replace('.', ',');
            this._DiyabetTakip.DiabetesMellitusPursuit.vki = Convert.ToDouble(skilo) / (boy * boy);
            this._DiyabetTakip.DiabetesMellitusPursuit.vki = Convert.ToDouble(string.IsNullOrEmpty(String.Format("{0:0.##}", this._DiyabetTakip.DiabetesMellitusPursuit.vki)) ? "0" : String.Format("{0:0.##}", this._DiyabetTakip.DiabetesMellitusPursuit.vki));
        }
        
#endregion DiyabetTakipFormu_Methods
    }
}