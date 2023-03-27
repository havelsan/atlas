
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
    /// Medula Ortodonti İşlemleri
    /// </summary>
    public partial class MedulaOrtodontiIslemleri : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            buttonOrtodontiKaydet.Click += new TTControlEventDelegate(buttonOrtodontiKaydet_Click);
            butttonOrtodontiFormuSil.Click += new TTControlEventDelegate(butttonOrtodontiFormuSil_Click);
            butttonOrtodontiFormuOku.Click += new TTControlEventDelegate(butttonOrtodontiFormuOku_Click);
            chkTCKimlikNoIleSorgula.CheckedChanged += new TTControlEventDelegate(chkTCKimlikNoIleSorgula_CheckedChanged);
            chkOrtodontiKaydet.CheckedChanged += new TTControlEventDelegate(chkOrtodontiKaydet_CheckedChanged);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            buttonOrtodontiKaydet.Click -= new TTControlEventDelegate(buttonOrtodontiKaydet_Click);
            butttonOrtodontiFormuSil.Click -= new TTControlEventDelegate(butttonOrtodontiFormuSil_Click);
            butttonOrtodontiFormuOku.Click -= new TTControlEventDelegate(butttonOrtodontiFormuOku_Click);
            chkTCKimlikNoIleSorgula.CheckedChanged -= new TTControlEventDelegate(chkTCKimlikNoIleSorgula_CheckedChanged);
            chkOrtodontiKaydet.CheckedChanged -= new TTControlEventDelegate(chkOrtodontiKaydet_CheckedChanged);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            base.UnBindControlEvents();
        }

        private void buttonOrtodontiKaydet_Click()
        {
#region MedulaOrtodontiIslemleri_buttonOrtodontiKaydet_Click
   if (lstSUTKodu.SelectedValue == null)
            {
                InfoBox.Show("SUT Kodu Alanı Boş Geçilemez ! ");
                return;
            }
          
            OrtodontiIslemleri.ortodontiFormuKaydetGirisDVO _ortodontiFormuKaydetGirisDVO = new OrtodontiIslemleri.ortodontiFormuKaydetGirisDVO();
         
            TedaviRaporiIslemKodlari sut = (TedaviRaporiIslemKodlari)((TTListBox)this.lstSUTKodu).SelectedObject; //(SUTDefinition)((TTListBox)this.lstSUTKodu).SelectedObject;
            _ortodontiFormuKaydetGirisDVO.sutKodu = sut.TedaviRaporuIslemKodu;
            _ortodontiFormuKaydetGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            _ortodontiFormuKaydetGirisDVO.islemTarihi =  Convert.ToDateTime(IslemTarihi.NullableValue).ToString("dd.MM.yyyy");
            _ortodontiFormuKaydetGirisDVO.tcKimlikNo =txtTCKNo.Text;
            _ortodontiFormuKaydetGirisDVO.formNo = txtFormNumarasi.Text == "" || txtFormNumarasi.Text == "0" ? "" : txtFormNumarasi.Text;
            
            if (gridHastaAktifTakipleri.CurrentCell != null && gridHastaAktifTakipleri.CurrentCell.RowIndex >= 0)
            {
                ITTGridRow selectedRow = gridHastaAktifTakipleri.CurrentCell.OwningRow;
                if (selectedRow != null )
                {
                    _ortodontiFormuKaydetGirisDVO.provizyonNo = selectedRow.Cells[3].Value.ToString();
                }
            }
            else
            {
                InfoBox.Show("Hastanın Bu Rapor İçin Geçerli Bir Branşta Takibi Bulunamamktadır ! ");
                return;
            }

            OrtodontiIslemleri.ortodontiFormuKaydetCevapDVO response = OrtodontiIslemleri.WebMethods.ortodontiFormuKaydetSync(Sites.SiteLocalHost, _ortodontiFormuKaydetGirisDVO);
            if (response != null)
            {
                if (response.sonucKodu == "0000")
                {
                    txtFormNumarasi.Text = response.formNo.ToString();
                    txtSonucMesaji.Text = response.sonucMesaji;
                    txtSonucKodu1.Text = response.sonucKodu;
                    InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji, MessageIconEnum.InformationMessage);
                    ////return;
                }
                else
                {
                    txtFormNumarasi.Text = "";
                    txtSonucMesaji.Text = response.sonucMesaji;
                    txtSonucKodu1.Text = response.sonucKodu;
                    InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.sonucMesaji + "  Rapor Takip Numarası Alınamamıştır.  !!!");
                    return;
                }
                txtSonucMesaji.Text = response.sonucMesaji;
            }
#endregion MedulaOrtodontiIslemleri_buttonOrtodontiKaydet_Click
        }

        private void butttonOrtodontiFormuSil_Click()
        {
#region MedulaOrtodontiIslemleri_butttonOrtodontiFormuSil_Click
   if (lstSUTKodu.SelectedValue == null)
            {
                InfoBox.Show("SUT Kodu Alanı Boş Geçilemez ! ");
                return;
            }
            OrtodontiIslemleri.ortodontiFormuIptalGirisDVO _ortodontiFormuIptalGirisDVO = new OrtodontiIslemleri.ortodontiFormuIptalGirisDVO();
            
            TedaviRaporiIslemKodlari sut = (TedaviRaporiIslemKodlari)((TTListBox)this.lstSUTKodu).SelectedObject; //(SUTDefinition)((TTListBox)this.lstSUTKodu).SelectedObject;
            _ortodontiFormuIptalGirisDVO.sutKodu = sut.TedaviRaporuIslemKodu;
            _ortodontiFormuIptalGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            _ortodontiFormuIptalGirisDVO.tcKimlikNo =txtTCKNo.Text;
            _ortodontiFormuIptalGirisDVO.formNo =  txtFormNumarasi.Text == "" || txtFormNumarasi.Text == "0" ? null : txtFormNumarasi.Text;


            OrtodontiIslemleri.ortodontiFormuIptalCevapDVO response = OrtodontiIslemleri.WebMethods.ortodontiFormuIptalSync(Sites.SiteLocalHost, _ortodontiFormuIptalGirisDVO);
            if (response != null)
            {
                if (response.sonucKodu == "0000")
                {
                    txtFormNumarasi.Text = response.formNo.ToString();
                    txtSonucMesaji2.Text = response.sonucMesaji;
                    txtSonucKodu.Text = response.sonucKodu;
                    txtProvizyonNo1.Text ="";
                    IslemTarihi1.Text ="";
                    txtTesis1.Text = "";
                    txtProvizyonNo2.Text ="";
                    IslemTarihi2.Text = "";
                    txtTesis2.Text = "";
                    txtProvizyonNo3.Text ="";
                    IslemTarihi3.Text = "";
                    txtTesis3.Text = "";
                }
                 else
                {
                    txtSonucMesaji2.Text = response.sonucMesaji;
                    txtSonucKodu.Text = response.sonucKodu;
                    txtProvizyonNo1.Text ="";
                    IslemTarihi1.Text ="";
                    txtTesis1.Text = "";
                    txtProvizyonNo2.Text ="";
                    IslemTarihi2.Text = "";
                    txtTesis2.Text = "";
                    txtProvizyonNo3.Text ="";
                    IslemTarihi3.Text = "";
                    txtTesis3.Text = "";
                  //  InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.sonucMesaji );
                   // return;
                }
            }
#endregion MedulaOrtodontiIslemleri_butttonOrtodontiFormuSil_Click
        }

        private void butttonOrtodontiFormuOku_Click()
        {
#region MedulaOrtodontiIslemleri_butttonOrtodontiFormuOku_Click
   string tesisAdi ;
            
            if (lstSUTKodu.SelectedValue == null)
            {
                InfoBox.Show("SUT Kodu Alanı Boş Geçilemez ! ");
                return;
            }
            OrtodontiIslemleri.ortodontiFormuOkuGirisDVO _ortodontiFormuOkuGirisDVO = new OrtodontiIslemleri.ortodontiFormuOkuGirisDVO();
            
            TedaviRaporiIslemKodlari sut = (TedaviRaporiIslemKodlari)((TTListBox)this.lstSUTKodu).SelectedObject; //(SUTDefinition)((TTListBox)this.lstSUTKodu).SelectedObject;
            _ortodontiFormuOkuGirisDVO.sutKodu = sut.TedaviRaporuIslemKodu;
            _ortodontiFormuOkuGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            _ortodontiFormuOkuGirisDVO.tcKimlikNo =txtTCKNo.Text;
            _ortodontiFormuOkuGirisDVO.formNo = txtFormNumarasi.Text == "" || txtFormNumarasi.Text == "0" ? "" : txtFormNumarasi.Text;


            OrtodontiIslemleri.ortodontiFormuOkuCevapDVO response = OrtodontiIslemleri.WebMethods.ortodontiFormuOkuSync(Sites.SiteLocalHost, _ortodontiFormuOkuGirisDVO);
            if (response != null)
            {
                if (response.sonucKodu == "0000")
                {
                    txtFormNumarasi.Text = response.formNo.ToString();
                    txtIslemTuru.Text = response.islemTuru;
                    txtSonucKodu2.Text = response.sonucKodu;
                    txtSonucMesaji2.Text = response.sonucMesaji;
                    txtProvizyonNo1.Text = response.provizyonNo1;
                    if(response.islem_tarihi_1 != null || response.islem_tarihi_1 != "null")
                        IslemTarihi1.Text =  response.islem_tarihi_1.ToString();
                    if(response.tesis_kodu_1 != 0)
                    {
                        tesisAdi = Common.GetSaglikTesisleri(response.tesis_kodu_1.ToString());
                        if (string.IsNullOrEmpty(tesisAdi) == false)
                            txtTesis1.Text = tesisAdi;
                    }

                    txtProvizyonNo2.Text = response.provizyonNo2;
                    if(response.islem_tarihi_2 != null  || response.islem_tarihi_2 != "null")
                        IslemTarihi2.Text = response.islem_tarihi_2.ToString();
                    if(response.tesis_kodu_2 != 0)
                    {
                        tesisAdi = Common.GetSaglikTesisleri(response.tesis_kodu_2.ToString());
                        if (string.IsNullOrEmpty(tesisAdi) == false)
                            txtTesis2.Text = tesisAdi;
                    }

                    txtProvizyonNo3.Text = response.provizyonNo3;
                    if(response.islem_tarihi_3 != null  || response.islem_tarihi_3 != "null")
                        IslemTarihi3.Text = response.islem_tarihi_3.ToString();
                    if(response.tesis_kodu_3 != 0)
                    {
                        tesisAdi = Common.GetSaglikTesisleri(response.tesis_kodu_3.ToString());
                        if (string.IsNullOrEmpty(tesisAdi) == false)
                            txtTesis3.Text = tesisAdi;
                    }

                    // InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji, MessageIconEnum.InformationMessage);
                    ////return;
                }
                else
                {
                    txtSonucMesaji2.Text = response.sonucMesaji;
                    txtSonucKodu2.Text = response.sonucKodu;
                    txtProvizyonNo1.Text ="";
                    IslemTarihi1.Text ="";
                    txtTesis1.Text = "";
                    txtProvizyonNo2.Text ="";
                    IslemTarihi2.Text = "";
                    txtTesis2.Text = "";
                    txtProvizyonNo3.Text ="";
                    IslemTarihi3.Text = "";
                    txtTesis3.Text = "";
                    //  InfoBox.Show("Rapor Servisinden Gelen Uyarı Mesajı : " + response.sonucMesaji );
                    // return;
                }
                txtSonucMesaji2.Text = response.sonucMesaji;
            }
#endregion MedulaOrtodontiIslemleri_butttonOrtodontiFormuOku_Click
        }

        private void chkTCKimlikNoIleSorgula_CheckedChanged()
        {
#region MedulaOrtodontiIslemleri_chkTCKimlikNoIleSorgula_CheckedChanged
   if (!((TTVisual.TTCheckBox)(chkTCKimlikNoIleSorgula)).Checked)
            {
                tttabSearchBenchMarks.HideTabPage(OrtodontiOku);  
               // IslemTarihi.Required =false;
            }
            else
            {
                this.tttabSearchBenchMarks.Visible = true ;
                this.tttabSearchBenchMarks.ShowTabPage(OrtodontiOku);
                this.tttabSearchBenchMarks.HideTabPage(OrtodontiKaydet); 
                ((TTVisual.TTCheckBox)(chkOrtodontiKaydet)).Checked = false;
                //IslemTarihi.Required = true;
            }
#endregion MedulaOrtodontiIslemleri_chkTCKimlikNoIleSorgula_CheckedChanged
        }

        private void chkOrtodontiKaydet_CheckedChanged()
        {
#region MedulaOrtodontiIslemleri_chkOrtodontiKaydet_CheckedChanged
   if (!((TTVisual.TTCheckBox)(chkOrtodontiKaydet)).Checked)
            {
                tttabSearchBenchMarks.HideTabPage(OrtodontiKaydet);  
                IslemTarihi.Required =false;
            }
            else
            {
                this.tttabSearchBenchMarks.Visible = true ;
                this.tttabSearchBenchMarks.ShowTabPage(OrtodontiKaydet);
                this.tttabSearchBenchMarks.HideTabPage(OrtodontiOku); 
                IslemTarihi.Required = true;
               ((TTVisual.TTCheckBox)(chkTCKimlikNoIleSorgula)).Checked = false;
            }
#endregion MedulaOrtodontiIslemleri_chkOrtodontiKaydet_CheckedChanged
        }

        private void cmdSearchPatient_Click()
        {
#region MedulaOrtodontiIslemleri_cmdSearchPatient_Click
   using (PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();
                List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
                
                if (patient != null)
                {
                    retList = patient.GetActiveSGKSEPs(Common.RecTime(), Common.RecTime());
                    txtName.Text = patient.Name;
                    txtSurname.Text = patient.Surname;
                    if (patient.YUPASSNO != null)
                    {
                        lblKimlikNo.Text = "YUPASS No";
                        txtTCKNo.Text = patient.YUPASSNO != null ? (patient.YUPASSNO.Value.ToString() + "") : "";
                    }
                    else
                    {
                        lblKimlikNo.Text = "TC Kimlik Numarası";
                        txtTCKNo.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
                    }
                    txtBirthDate.Text = patient.BirthDate != null ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : "";
                    if (patient.Sex != null)
                    {
                        if (patient.Sex.ADI == "ERKEK")
                            txtSex.Text = "Erkek";
                        else
                            txtSex.Text = "Bayan";
                    }
                    groupboxOrtodontiIslemTuru.Visible = true;                    
                }
                else
                {
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                    txtSex.Text = "";
                    txtBirthDate.Text = "";
                    txtTCKNo.Text = "";
                    txtSurname.Text = "";
                    txtName.Text = "";
                    groupboxOrtodontiIslemTuru.Visible = false;

                }
                foreach(SubEpisodeProtocol item in retList)
                {
                    if (item.MedulaTakipNo != null)
                    {
                        if(item.Brans.Code == "5200")
                        {
                            ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                            newRow.Cells[txtTakipNo1.Name].Value = item.MedulaTakipNo;
                            newRow.Cells[txtBrans1.Name].Value = item.Brans.Name_Shadow;
                            newRow.Cells[txtProvizyonTarihi1.Name].Value = item.MedulaProvizyonTarihi.ToString();
                            newRow.Cells[txtBasvuruNumarasi1.Name].Value = item.MedulaBasvuruNo;
                            newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Episode.HospitalProtocolNo;
                            newRow.Cells[txtVakaAcilisTarihi1.Name].Value  = item.Episode.OpeningDate;
                            newRow.Cells[txtBransKodu1.Name].Value  = item.Brans.Code;
                        }
                    }
                }
            }
#endregion MedulaOrtodontiIslemleri_cmdSearchPatient_Click
        }

#region MedulaOrtodontiIslemleri_Methods
        public MedulaOrtodontiIslemleri(Patient patient) : base("MedulaOrtodontiIslemleri") {
            List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
            
            if (patient != null)
            {
                retList = patient.GetActiveSGKSEPs(Common.RecTime(), Common.RecTime());
                txtName.Text = patient.Name;
                txtSurname.Text = patient.Surname;
                if (patient.YUPASSNO != null)
                {
                    lblKimlikNo.Text = "YUPASS No";
                    txtTCKNo.Text = patient.YUPASSNO != null ? (patient.YUPASSNO.Value.ToString() + "") : "";
                }
                else
                {
                    lblKimlikNo.Text = "TC Kimlik Numarası";
                    txtTCKNo.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
                }
                txtBirthDate.Text = patient.BirthDate != null ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : "";
                if (patient.Sex != null)
                {
                    if (patient.Sex.ADI == "ERKEK")
                        txtSex.Text = "Erkek";
                    else 
                        txtSex.Text = "Bayan";
                        txtSex.Text = "";
                }
                groupboxOrtodontiIslemTuru.Visible = true;
            }
            else
            {
                InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                txtSex.Text = "";
                txtBirthDate.Text = "";
                txtTCKNo.Text = "";
                txtSurname.Text = "";
                txtName.Text = "";
                groupboxOrtodontiIslemTuru.Visible = false;

            }
            foreach(SubEpisodeProtocol item in retList)
            {
                if (item.MedulaTakipNo != null)
                {
                    if(item.Brans.Code == "5200")
                    {
                        ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                        newRow.Cells[txtTakipNo1.Name].Value = item.MedulaTakipNo;
                        newRow.Cells[txtBrans1.Name].Value = item.Brans.Name_Shadow;
                        newRow.Cells[txtProvizyonTarihi1.Name].Value = item.MedulaProvizyonTarihi.ToString();
                        newRow.Cells[txtBasvuruNumarasi1.Name].Value = item.MedulaBasvuruNo;
                        newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Episode.HospitalProtocolNo;
                        newRow.Cells[txtVakaAcilisTarihi1.Name].Value  = item.Episode.OpeningDate;
                        newRow.Cells[txtBransKodu1.Name].Value  = item.Brans.Code;
                    }
                }
            }
            chkOrtodontiKaydet.Value = true;
        }
        
        //        public string GetSaglikTesisleri(string tesisKodu)
        //        {
        //            string tesisAdi="";
        //            MedulaYardimciIslemler.saglikTesisiAraGirisDVO saglikTesisiAraGirisDVO= new MedulaYardimciIslemler.saglikTesisiAraGirisDVO();
        //            if (string.IsNullOrEmpty(tesisKodu) == false)
        //                saglikTesisiAraGirisDVO.tesisKodu =tesisKodu;
        //            saglikTesisiAraGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
        //            MedulaYardimciIslemler.saglikTesisiAraCevapDVO saglikTesisiAraCevapDVO=MedulaYardimciIslemler.WebMethods.saglikTesisiAraSync(TTObjectClasses.Sites.SiteLocalHost,saglikTesisiAraGirisDVO);
        //            if(saglikTesisiAraCevapDVO != null)
        //            {
        //                if(string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucKodu)== false)
        //                {
        //                    if (saglikTesisiAraCevapDVO.sonucKodu.Equals("0000") == true)
        //                    {
        //                        for (int i = 0; i < saglikTesisiAraCevapDVO.tesisler.Length; i++)
        //                        {
        //                            MedulaYardimciIslemler.saglikTesisiListDVO saglikTesisiListDVO = saglikTesisiAraCevapDVO.tesisler[i];
//
        //                            tesisAdi = saglikTesisiListDVO.tesisAdi;
//
        //                        }
        //                    }
        //                }
        //            }
        //            return tesisAdi;
//
        //        }
        
#endregion MedulaOrtodontiIslemleri_Methods
    }
}