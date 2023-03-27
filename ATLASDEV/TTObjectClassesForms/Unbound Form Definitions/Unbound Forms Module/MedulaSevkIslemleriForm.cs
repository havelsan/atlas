
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
    /// Medula Sevk Işlemleri
    /// </summary>
    public partial class MedulaSevkIslemleri : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttgridHastaSevkListesi.CellContentClick += new TTGridCellEventDelegate(ttgridHastaSevkListesi_CellContentClick);
            btnMedulaSevkListele.Click += new TTControlEventDelegate(btnMedulaSevkListele_Click);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            buttonSaglikTesisiAra.Click += new TTControlEventDelegate(buttonSaglikTesisiAra_Click);
            ttbuttonTeshisleriOku.Click += new TTControlEventDelegate(ttbuttonTeshisleriOku_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttgridHastaSevkListesi.CellContentClick -= new TTGridCellEventDelegate(ttgridHastaSevkListesi_CellContentClick);
            btnMedulaSevkListele.Click -= new TTControlEventDelegate(btnMedulaSevkListele_Click);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            buttonSaglikTesisiAra.Click -= new TTControlEventDelegate(buttonSaglikTesisiAra_Click);
            ttbuttonTeshisleriOku.Click -= new TTControlEventDelegate(ttbuttonTeshisleriOku_Click);
            base.UnBindControlEvents();
        }

        private void ttgridHastaSevkListesi_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaSevkIslemleri_ttgridHastaSevkListesi_CellContentClick
   if (ttgridHastaSevkListesi.Rows.Count > 0 && ttgridHastaSevkListesi.CurrentCell != null)
            {
                if ((((ITTGridCell)ttgridHastaSevkListesi.CurrentCell).OwningColumn != null) && (((ITTGridCell)ttgridHastaSevkListesi.CurrentCell).OwningColumn.Name == "SevkSil"))
                {
                    ITTGridCell currentCell = ttgridHastaSevkListesi.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            if (currentRow.Cells[2].Value != null)
                            {
                                InfoBox.Show("Seçili Olan Sevk İşlemi Meduladan Silinecektir!! ",MessageIconEnum.InformationMessage);
                                
                                
                                SevkIslemleri.sevkBildirimIptalDVO sevkBildirimIptalDVO= new SevkIslemleri.sevkBildirimIptalDVO();
                                
                                sevkBildirimIptalDVO.sevkTakipNo = currentRow.Cells[2].Value.ToString();
                                
                                sevkBildirimIptalDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                                
                                try
                                {
                                    
                                    SevkIslemleri.sevkIptalCevapDVO sevkIptalCevapDVO= SevkIslemleri.WebMethods.sevkBildirimIptalSync(TTObjectClasses.Sites.SiteLocalHost, sevkBildirimIptalDVO);
                                    if(sevkIptalCevapDVO != null)
                                    {
                                        if(sevkIptalCevapDVO.Equals("0000"))
                                        {
                                            currentRow.Cells[0].Value = "";
                                            currentRow.Cells[1].Value = "";
                                            currentRow.Cells[2].Value = "";
                                            currentRow.Cells[3].Value = "";
                                            currentRow.Cells[4].Value = "";
                                            currentRow.Cells[5].Value = "";
                                            currentRow.Cells[6].Value = "";
                                            currentRow.Cells[7].Value = "";
                                            currentRow.Cells[8].Value = "";
                                            currentRow.Cells[9].Value = "";
                                            currentRow.Cells[10].Value = "";
                                            currentRow.Cells[11].Value = "";
                                            currentRow.Cells[12].Value = "";
                                            currentRow.Cells[13].Value = "";
                                            currentRow.Cells[14].Value = "";
                                            currentRow.Cells[15].Value = "";
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji))
                                            {
                                                InfoBox.Show("Medula Sevk Servisinden Gelen Sonuç Mesajı : " + sevkIptalCevapDVO.sonucMesaji);
                                                return;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                    }
                }
            }
#endregion MedulaSevkIslemleri_ttgridHastaSevkListesi_CellContentClick
        }

        private void btnMedulaSevkListele_Click()
        {
#region MedulaSevkIslemleri_btnMedulaSevkListele_Click
   try{
                
                ((ITTGrid) this.ttgridHastaSevkListesi).Rows.Clear();
                SevkIslemleri.sevkListeDVO  _sevkListeDVO = new SevkIslemleri.sevkListeDVO();
                _sevkListeDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _sevkListeDVO.tcKimlikNo = (long)Convert.ToInt64(txtTCKNo.Text.Trim());
                SevkIslemleri.sevkListeCevapDVO _sevkListeCevapDVO = SevkIslemleri.WebMethods.sevkListeleSync(TTObjectClasses.Sites.SiteLocalHost,_sevkListeDVO);
                
                if(_sevkListeCevapDVO != null){
                    if(string.IsNullOrEmpty(_sevkListeCevapDVO.sonucKodu) == false){
                        if(_sevkListeCevapDVO.sonucKodu.Equals("0000")){
                            InfoBox.Show( _sevkListeDVO.tcKimlikNo.ToString() +" TC Kimlik No'lu hastanın sevklerini sorgulama işlemi başarılı şekilde yapıldı.");
                            if(_sevkListeCevapDVO.sevkListesi != null)
                            {
                                for (int i = 0; i < _sevkListeCevapDVO.sevkListesi.Length; i++)
                                {
                                    SevkIslemleri.sevkDVO sevkDVO = _sevkListeCevapDVO.sevkListesi[i];
                                    ITTGridRow row = this.ttgridHastaSevkListesi.Rows.Add();
                                    row.Cells[sevkId.Name].Value = sevkDVO.sevkId.ToString();
                                    row.Cells[tcKimlikNo.Name].Value = sevkDVO.tcKimlikNo.ToString();
                                    row.Cells[sevkTakipNo.Name].Value = sevkDVO.sevkTakipNo;
                                    row.Cells[protokolNo.Name].Value = sevkDVO.protokolNo;
                                    row.Cells[sevkEdilenIl.Name].Value = sevkDVO.sevkEdilenIl.ToString();
                                    row.Cells[sevkTarihi.Name].Value = sevkDVO.sevkTarihi;
                                    row.Cells[sevkVasitasi.Name].Value = sevkDVO.sevkVasitasi.ToString();
                                    row.Cells[sevkNedeniAciklama.Name].Value = sevkDVO.sevkNedeniAciklama;
                                    row.Cells[sevkNedeni.Name].Value = sevkDVO.sevkNedeni.ToString();
                                    row.Cells[tedaviTipi.Name].Value = sevkDVO.tedaviTipi.ToString();
                                    row.Cells[kabulEdenTesis.Name].Value = sevkDVO.kabulEdenTesis.ToString();
                                    row.Cells[kabulEdenTakip.Name].Value = sevkDVO.kabulEdenTakip;
                                    row.Cells[sevkEdenBrans.Name].Value = sevkDVO.sevkEdenBrans;
                                    row.Cells[sevkEdenTesis.Name].Value = sevkDVO.sevkEdenTesis.ToString() != "0" ? Common.GetSaglikTesisleri(sevkDVO.sevkEdenTesis.ToString()) : sevkDVO.sevkEdenTesis.ToString();
                                }
                            }
                        }else{
                            if(string.IsNullOrEmpty(_sevkListeCevapDVO.sonucMesaji) == false)
                                InfoBox.Show("Hastaya ait sevklerin listelenmesi işleminde hata var.Hata Mesajı: "+_sevkListeCevapDVO.sonucMesaji);
                            else
                                InfoBox.Show("Hastaya ait sevklerin listelenmesi işleminde hata var.Sonuç Mesajı boş!");
                        }
                        
                    }else
                        InfoBox.Show("Hastaya ait sevklerin listelenmesi işleminde hata var.Sonuç Kodu boş!");
                }else{
                    InfoBox.Show("Hastaya ait sevklerin listelenmesi işlemi yapılamadı. Tekrar deneyiniz!");
                }
                
            }catch(Exception e){
                InfoBox.Show("Hastaya ait sevklerin listelenmesi sırasında hata oluştu. Tekrar deneyiniz!");
            }
#endregion MedulaSevkIslemleri_btnMedulaSevkListele_Click
        }

        private void cmdSearchPatient_Click()
        {
#region MedulaSevkIslemleri_cmdSearchPatient_Click
   using (PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();

                if (patient != null)
                {
                    pnlSearchResult.Visible = true;
                    txtPatientName.Tag = patient.ObjectID;
                    
                    txtName.Text = patient.Name;
                    txtSurname.Text = patient.Surname;
                    if (patient.YUPASSNO != null)
                    {
                        lblTCNumarasi.Text = "YUPASS No";
                        txtTCKNo.Text = patient.YUPASSNO != null ? (patient.YUPASSNO.Value.ToString() + "") : "";
                    }
                    else
                    {
                        lblTCNumarasi.Text = "TC Kimlik Numarası";
                        txtTCKNo.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
                    }
                    txtPatientName.Text = txtTCKNo.Text + " - " + patient.FullName;
                    txtBirthDate.Text = patient.BirthDate != null ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : "";
                    if (patient.Sex != null)
                    {

                        if (patient.Sex.ADI == "ERKEK")
                            txtSex.Text = "Erkek";
                        else
                            txtSex.Text = "Bayan";
                    }
                }
                else
                {
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                    pnlSearchResult.Visible = false;
                    txtSex.Text = "";
                    txtBirthDate.Text = "";
                    txtTCKNo.Text = "";
                    txtSurname.Text = "";
                    txtName.Text = "";

                }
            }
#endregion MedulaSevkIslemleri_cmdSearchPatient_Click
        }

        private void buttonSaglikTesisiAra_Click()
        {
#region MedulaSevkIslemleri_buttonSaglikTesisiAra_Click
   try{
                ttpanelMedulaSaglikTesisiAraCevap.Visible = false;
                ((ITTGrid) this.ttgridSaglikTesisleri).Rows.Clear();
                this.tttextboxSonucMesaji.Text="";
                this.tttextboxSonucKodu.Text="";
                MedulaYardimciIslemler.saglikTesisiAraCevapDVO saglikTesisiAraCevapDVO=MedulaYardimciIslemler.WebMethods.saglikTesisiAraSync(TTObjectClasses.Sites.SiteLocalHost,GetSaglikTesisiAraGirisDVO());
                ttpanelMedulaSaglikTesisiAraCevap.Visible = true;
                if(saglikTesisiAraCevapDVO != null){
                    if(string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucKodu)== false){
                        this.tttextboxSonucKodu.Text = saglikTesisiAraCevapDVO.sonucKodu;
                        if (saglikTesisiAraCevapDVO.sonucKodu.Equals("0000") == true)
                        {
                            this.tttextboxSonucKodu.Text = "Başarılı";
                            for (int i = 0; i < saglikTesisiAraCevapDVO.tesisler.Length; i++)
                            {
                                MedulaYardimciIslemler.saglikTesisiListDVO saglikTesisiListDVO = saglikTesisiAraCevapDVO.tesisler[i];
                                ITTGridRow row = this.ttgridSaglikTesisleri.Rows.Add();
                                row.Cells[TesisIl.Name].Value = saglikTesisiListDVO.tesisIl;
                                row.Cells[TesisAdi.Name].Value = saglikTesisiListDVO.tesisAdi;
                                row.Cells[TesisKodu.Name].Value = saglikTesisiListDVO.tesisKodu.ToString();
                                row.Cells[TesisSinifKodu.Name].Value = saglikTesisiListDVO.tesisSinifKodu;
                                row.Cells[TesisTuru.Name].Value = saglikTesisiListDVO.tesisTuru;

                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucMesaji) == false)
                            {
                                this.tttextboxSonucMesaji.Text = saglikTesisiAraCevapDVO.sonucMesaji;
                            }
                        }
                    }
                    if(string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucMesaji)== false){
                        this.tttextboxSonucMesaji.Text = saglikTesisiAraCevapDVO.sonucMesaji;
                    }
                }
                else{
                    this.tttextboxSonucMesaji.Text = "İşlem gerçekleştirilemedi.";
                    if (string.IsNullOrEmpty(saglikTesisiAraCevapDVO.sonucMesaji) == false)
                    {
                        this.tttextboxSonucMesaji.Text = saglikTesisiAraCevapDVO.sonucMesaji;
                    }
                }
            }catch(Exception e){
                InfoBox.Show(e.Message.ToString());
            }
#endregion MedulaSevkIslemleri_buttonSaglikTesisiAra_Click
        }

        private void ttbuttonTeshisleriOku_Click()
        {
#region MedulaSevkIslemleri_ttbuttonTeshisleriOku_Click
   // Yardımcı İşlemlerden kaldırılmış. 02.02.2016
// TODO : yerine konulacak bir servis var mı incelenecek. A.Ş.
            
//   try{
//                MedulaYardimciIslemler.teshisOkuGirisDVO teshisOkuGirisDVO = new MedulaYardimciIslemler.teshisOkuGirisDVO();
//                
//                teshisOkuGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
//                MedulaYardimciIslemler.teshisOkuCevapDVO teshisOkuCevap = MedulaYardimciIslemler.WebMethods.teshisleriOkuSync(TTObjectClasses.Sites.SiteLocalHost, teshisOkuGirisDVO);
//
//                if (teshisOkuCevap != null)
//                {
//                    this.ttpanelTeshisleriAra.Visible = true;
//                    if (teshisOkuCevap.sonucKodu != null)
//                    {
//                        
//                        if (teshisOkuCevap.sonucKodu == "0000")
//                        {
//                            this.txtboxTeshisleriOkuSonucKodu.Text = "Başarılı";
//                            
//                            if (teshisOkuCevap.sonucMesaji != null)
//                            {
//                                this.txtboxTeshisleriOkuSonucMesaji.Text = teshisOkuCevap.sonucMesaji;
//                            }
//                            
//                            for (int i = 0; i < teshisOkuCevap.teshisler.Length; i++)
//                            {
//                                MedulaYardimciIslemler.teshisDVO teshisDVO = teshisOkuCevap.teshisler[i];
//                                if(teshisDVO != null){
//                                    ITTGridRow row = this.ttgridTeshisleriOku.Rows.Add();
//                                    row.Cells[Kodu.Name].Value = teshisDVO.kodu.ToString();
//                                    row.Cells[Adi.Name].Value = teshisDVO.adi;
//                                }
//                            }
//                            
//                            
//                        }
//                        else
//                        {
//                            this.txtboxTeshisleriOkuSonucKodu.Text = teshisOkuCevap.sonucKodu.ToString();
//                            if (teshisOkuCevap.sonucMesaji != null)
//                            {
//                                this.txtboxTeshisleriOkuSonucMesaji.Text = teshisOkuCevap.sonucMesaji;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        this.txtboxTeshisleriOkuSonucMesaji.Text = "Sonuç Kodu boş!";
//                        if (teshisOkuCevap.sonucMesaji != null)
//                        {
//                            this.txtboxTeshisleriOkuSonucMesaji.Text += teshisOkuCevap.sonucMesaji;
//                        }
//                    }
//                }
//                else
//                {
//                    this.ttpanelTeshisleriAra.Visible = false;
//                    InfoBox.Show("Meduladan teşhis okuma işlemi gerçekleştirilemedi!");
//                }
//            }catch(Exception e){
//                InfoBox.Show(e.Message.ToString());
//            }
#endregion MedulaSevkIslemleri_ttbuttonTeshisleriOku_Click
        }

#region MedulaSevkIslemleri_Methods
        public MedulaYardimciIslemler.saglikTesisiAraGirisDVO GetSaglikTesisiAraGirisDVO(){
            MedulaYardimciIslemler.saglikTesisiAraGirisDVO saglikTesisiAraGirisDVO= new MedulaYardimciIslemler.saglikTesisiAraGirisDVO();
            if (string.IsNullOrEmpty(this.tesisAdiSaglikTesisiAraGirisDVO.Text) == false)
                saglikTesisiAraGirisDVO.tesisAdi = this.tesisAdiSaglikTesisiAraGirisDVO.Text;
            else
               throw new TTUtils.TTException("Tesis Adı boş olamaz!");
            if (string.IsNullOrEmpty(this.tesisIlKoduSaglikTesisiAraGirisDVO.Text) == false)
                saglikTesisiAraGirisDVO.tesisIlKodu= this.tesisIlKoduSaglikTesisiAraGirisDVO.Text;
            else
               throw new TTUtils.TTException("Tesis il Kodu boş olamaz!");
            if (string.IsNullOrEmpty(this.tesisKoduSaglikTesisiAraGirisDVO.Text) == false)
                saglikTesisiAraGirisDVO.tesisKodu = this.tesisKoduSaglikTesisiAraGirisDVO.Text;
            if (string.IsNullOrEmpty(this.tesisTuruSaglikTesisiAraGirisDVO.Text) == false)
                saglikTesisiAraGirisDVO.tesisTuru = this.tesisTuruSaglikTesisiAraGirisDVO.Text;
            
            saglikTesisiAraGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            return saglikTesisiAraGirisDVO;
        }
        
#endregion MedulaSevkIslemleri_Methods
    }
}