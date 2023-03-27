
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
    /// E Reçete Detayı
    /// </summary>
    public partial class EReceteDetayForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdAddSignedDrugDetail.Click += new TTControlEventDelegate(cmdAddSignedDrugDetail_Click);
            cmdAddDrugDetail.Click += new TTControlEventDelegate(cmdAddDrugDetail_Click);
            cmdClose.Click += new TTControlEventDelegate(cmdClose_Click);
            cmdAddDiag.Click += new TTControlEventDelegate(cmdAddDiag_Click);
            cmdAddSignedDiag.Click += new TTControlEventDelegate(cmdAddSignedDiag_Click);
            cmdAddPresDesc.Click += new TTControlEventDelegate(cmdAddPresDesc_Click);
            cmdAddSignedPresDesc.Click += new TTControlEventDelegate(cmdAddSignedPresDesc_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdAddSignedDrugDetail.Click -= new TTControlEventDelegate(cmdAddSignedDrugDetail_Click);
            cmdAddDrugDetail.Click -= new TTControlEventDelegate(cmdAddDrugDetail_Click);
            cmdClose.Click -= new TTControlEventDelegate(cmdClose_Click);
            cmdAddDiag.Click -= new TTControlEventDelegate(cmdAddDiag_Click);
            cmdAddSignedDiag.Click -= new TTControlEventDelegate(cmdAddSignedDiag_Click);
            cmdAddPresDesc.Click -= new TTControlEventDelegate(cmdAddPresDesc_Click);
            cmdAddSignedPresDesc.Click -= new TTControlEventDelegate(cmdAddSignedPresDesc_Click);
            base.UnBindControlEvents();
        }

        private void cmdAddSignedDrugDetail_Click()
        {
#region EReceteDetayForm_cmdAddSignedDrugDetail_Click
   bool error = false;
            if (string.IsNullOrEmpty(this.DrugDescription.Text))
            {
                InfoBox.Show("Eklenecek Açıklama boş geçilemez", MessageIconEnum.ErrorMessage);
                error = true;
            }
            if (this.descriptionType.SelectedItem == null)
            {
                InfoBox.Show("Açıklama Türü boş geçilemez", MessageIconEnum.ErrorMessage);
                error = true;
            }

            if (error == false)
            {
                EReceteIslemleri.ereceteIlacAciklamaDVO ereceteAciklamaDVO = new EReceteIslemleri.ereceteIlacAciklamaDVO();
                ereceteAciklamaDVO.aciklama = this.DrugDescription.Text;
                ereceteAciklamaDVO.aciklamaTuru = (int)this.descriptionType.SelectedItem.Value;
                int count = 0;

                string barcode = string.Empty;
                for (int i = 0; i < this.ilacGrid.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.ilacGrid.Rows[i].Cells["Check"].Value))
                    {
                        barcode = this.ilacGrid.Rows[i].Cells["Barcode"].Value.ToString();
                        count++;
                    }
                }
                if (count == 1)
                {
                    EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO ereceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO();
                    ereceteIlacAciklamaEkleIstekDVO.barkod = Convert.ToInt64(barcode);
                    ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this.edtDoktorTC.Text);
                    ereceteIlacAciklamaEkleIstekDVO.ereceteNo = this.EReceteNo.Text ;
                    ereceteIlacAciklamaEkleIstekDVO.ereceteIlacAciklamaDVO = ereceteAciklamaDVO;
                    ereceteIlacAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                    string imzalanacakXml = Common.SerializeObjectToXml(ereceteIlacAciklamaEkleIstekDVO);
                    imzalanacakXml = imzalanacakXml.Replace("ereceteIlacAciklamaEkleIstekDVO", "imzaliEreceteIlacAciklamaBilgisi");
                    imzalanacakXml = imzalanacakXml.Replace("ereceteIlacAciklamaDVO", "ereceteIlacAciklamaBilgisi");

                    byte[] signedContent = CommonForm.SignContent("E-reçete İlaç Açıklama İçerik İmzalama", imzalanacakXml);
                    if (signedContent == null)
                        throw new TTException("E-reçete giriş içeriği imzalanamadı");

                    EReceteIslemleri.imzaliEreceteIlacAciklamaEkleIstekDVO imzaliEreceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.imzaliEreceteIlacAciklamaEkleIstekDVO();
                    imzaliEreceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo.ToString();
                    imzaliEreceteIlacAciklamaEkleIstekDVO.imzaliEreceteIlacAciklama = signedContent;
                    imzaliEreceteIlacAciklamaEkleIstekDVO.surumNumarasi = "1";
                    imzaliEreceteIlacAciklamaEkleIstekDVO.tesisKodu = ereceteIlacAciklamaEkleIstekDVO.tesisKodu.ToString();

                    EReceteIslemleri.imzaliEreceteIlacAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteIlacAciklamaEkleSync(Sites.SiteLocalHost, this.edtDoktorTC.Text, this.edtPassword.Text, imzaliEreceteIlacAciklamaEkleIstekDVO);
                    if (response != null)
                    {
                        if (response.sonucKodu.Equals("0000"))
                            InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                        else
                            InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                    }
                }
                else if (count == 0)
                    InfoBox.Show("Açıklama eklenecek ilaç seçmediniz", MessageIconEnum.ErrorMessage);
                else
                    InfoBox.Show("Sadece bir ilaç seçebilirsiniz.", MessageIconEnum.ErrorMessage);
            }
#endregion EReceteDetayForm_cmdAddSignedDrugDetail_Click
        }

        private void cmdAddDrugDetail_Click()
        {
#region EReceteDetayForm_cmdAddDrugDetail_Click
   bool error = false;
            if (string.IsNullOrEmpty(this.DrugDescription.Text))
            {
                InfoBox.Show("Eklenecek Açıklama boş geçilemez", MessageIconEnum.ErrorMessage);
                error = true;
            }
            if (this.descriptionType.SelectedItem == null)
            {
                InfoBox.Show("Açıklama Türü boş geçilemez", MessageIconEnum.ErrorMessage);
                error = true;
            }

            if (error == false)
            {
                EReceteIslemleri.ereceteIlacAciklamaDVO ereceteAciklamaDVO = new EReceteIslemleri.ereceteIlacAciklamaDVO();
                ereceteAciklamaDVO.aciklama = this.DrugDescription.Text;
                ereceteAciklamaDVO.aciklamaTuru = (int)this.descriptionType.SelectedItem.Value;
                int count = 0;

                string barcode = string.Empty;
                for (int i = 0; i < this.ilacGrid.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.ilacGrid.Rows[i].Cells["Select"].Value))
                    {
                        barcode = this.ilacGrid.Rows[i].Cells["Barcode"].Value.ToString();
                        count++;
                    }
                }
                if (count == 1)
                {
                    EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO ereceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO();
                    ereceteIlacAciklamaEkleIstekDVO.barkod = Convert.ToInt64(barcode);
                    ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this.edtDoktorTC.Text);
                    ereceteIlacAciklamaEkleIstekDVO.ereceteNo = this.EReceteNo.Text;
                    ereceteIlacAciklamaEkleIstekDVO.ereceteIlacAciklamaDVO = ereceteAciklamaDVO;
                    ereceteIlacAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                    EReceteIslemleri.ereceteIlacAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.ereceteIlacAciklamaEkle(Sites.SiteLocalHost, this.edtDoktorTC.Text, this.edtPassword.Text, ereceteIlacAciklamaEkleIstekDVO);
                    if (response != null)
                    {
                        if (response.sonucKodu.Equals("0000"))
                            InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                        else
                            InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                    }
                }
                else if (count == 0)
                    InfoBox.Show("Açıklama eklenecek ilaç seçmediniz", MessageIconEnum.ErrorMessage);
                else
                    InfoBox.Show("Sadece bir ilaç seçebilirsiniz.", MessageIconEnum.ErrorMessage);
            }
#endregion EReceteDetayForm_cmdAddDrugDetail_Click
        }

        private void cmdClose_Click()
        {
#region EReceteDetayForm_cmdClose_Click
   Close();
#endregion EReceteDetayForm_cmdClose_Click
        }

        private void cmdAddDiag_Click()
        {
#region EReceteDetayForm_cmdAddDiag_Click
   if (this.Diag.SelectedObjectID != null)
            {
                DiagnosisDefinition diagnosis = (DiagnosisDefinition)this.Diag.SelectedObject;
                EReceteIslemleri.ereceteTaniDVO ereceteTaniDVO = new EReceteIslemleri.ereceteTaniDVO();
                ereceteTaniDVO.taniAdi = diagnosis.Name;
                if (diagnosis.Code.Length > 5)
                    ereceteTaniDVO.taniKodu = diagnosis.Code.Substring(0, 5);
                else
                    ereceteTaniDVO.taniKodu = diagnosis.Code;

                EReceteIslemleri.ereceteTaniEkleIstekDVO ereceteTaniEkleIstekDVO = new EReceteIslemleri.ereceteTaniEkleIstekDVO();
                ereceteTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this.edtDoktorTC.Text);
                ereceteTaniEkleIstekDVO.ereceteNo = this.EReceteNo.Text;
                ereceteTaniEkleIstekDVO.ereceteTaniDVO = ereceteTaniDVO;
                ereceteTaniEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                EReceteIslemleri.ereceteTaniEkleCevapDVO response = EReceteIslemleri.WebMethods.ereceteTaniEkle(Sites.SiteLocalHost, this.edtDoktorTC.Text, this.edtPassword.Text , ereceteTaniEkleIstekDVO);
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        InfoBox.Show("Tanı eklenmiştir.", MessageIconEnum.InformationMessage);
                        this.Close();
                    }
                    else
                        InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                }
            }
            else
                InfoBox.Show("Tanı seçmediniz.", MessageIconEnum.ErrorMessage);
#endregion EReceteDetayForm_cmdAddDiag_Click
        }

        private void cmdAddSignedDiag_Click()
        {
#region EReceteDetayForm_cmdAddSignedDiag_Click
   if (this.Diag.SelectedObjectID != null)
            {
                DiagnosisDefinition diagnosis = (DiagnosisDefinition)this.Diag.SelectedObject;
                EReceteIslemleri.ereceteTaniDVO ereceteTaniDVO = new EReceteIslemleri.ereceteTaniDVO();
                ereceteTaniDVO.taniAdi = diagnosis.Name;
                if (diagnosis.Code.Length > 5)
                    ereceteTaniDVO.taniKodu = diagnosis.Code.Substring(0, 5);
                else
                    ereceteTaniDVO.taniKodu = diagnosis.Code;

                EReceteIslemleri.ereceteTaniEkleIstekDVO ereceteTaniEkleIstekDVO = new EReceteIslemleri.ereceteTaniEkleIstekDVO();
                ereceteTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this.edtDoktorTC.Text);
                ereceteTaniEkleIstekDVO.ereceteNo = this.EReceteNo.Text;
                ereceteTaniEkleIstekDVO.ereceteTaniDVO = ereceteTaniDVO;
                ereceteTaniEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                string imzalanacakXml = Common.SerializeObjectToXml(ereceteTaniEkleIstekDVO);
                imzalanacakXml = imzalanacakXml.Replace("ereceteTaniEkleIstekDVO", "imzaliEreceteTaniBilgisi");
                imzalanacakXml = imzalanacakXml.Replace("ereceteTaniDVO", "ereceteTaniBilgisi");

                byte[] signedContent = CommonForm.SignContent("E-reçete Tanı Bilgisi İçerik İmzalama", imzalanacakXml);
                if (signedContent == null)
                    throw new TTException("E-reçete tanı ekleme bilgisi içeriği imzalanamadı");

                EReceteIslemleri.imzaliEreceteTaniEkleIstekDVO imzaliEreceteTaniEkleIstekDVO = new EReceteIslemleri.imzaliEreceteTaniEkleIstekDVO();
                imzaliEreceteTaniEkleIstekDVO.doktorTcKimlikNo = ereceteTaniEkleIstekDVO.doktorTcKimlikNo.ToString();
                imzaliEreceteTaniEkleIstekDVO.imzaliEreceteTani = signedContent;
                imzaliEreceteTaniEkleIstekDVO.surumNumarasi = "1";
                imzaliEreceteTaniEkleIstekDVO.tesisKodu = ereceteTaniEkleIstekDVO.tesisKodu.ToString();

                EReceteIslemleri.imzaliEreceteTaniEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteTaniEkleSync(Sites.SiteLocalHost, this.edtDoktorTC.Text, this.edtPassword.Text, imzaliEreceteTaniEkleIstekDVO);

                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        InfoBox.Show("Tanı eklenmiştir.", MessageIconEnum.InformationMessage);
                        this.Close();
                    }
                    else
                        InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                }
            }
            else
                InfoBox.Show("Tanı seçmediniz.", MessageIconEnum.ErrorMessage);
#endregion EReceteDetayForm_cmdAddSignedDiag_Click
        }

        private void cmdAddPresDesc_Click()
        {
#region EReceteDetayForm_cmdAddPresDesc_Click
   bool error = false;
            if (string.IsNullOrEmpty(this.PresDesc.Text))
            {
                InfoBox.Show("Eklenecek Açıklama boş geçilemez", MessageIconEnum.ErrorMessage);
                error = true;
            }
            if (this.presDescriptionType.SelectedItem == null)
            {
                InfoBox.Show("Açıklama Türü boş geçilemez", MessageIconEnum.ErrorMessage);
                error = true;
            }
            if (error == false)
            {
                EReceteIslemleri.ereceteAciklamaDVO ereceteAciklamaDVO = new EReceteIslemleri.ereceteAciklamaDVO();
                ereceteAciklamaDVO.aciklama = this.PresDesc.Text;
                ereceteAciklamaDVO.aciklamaTuru = (int)this.presDescriptionType.SelectedItem.Value;
                EReceteIslemleri.ereceteAciklamaEkleIstekDVO ereceteAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteAciklamaEkleIstekDVO();
                ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this.edtDoktorTC.Text);
                ereceteAciklamaEkleIstekDVO.ereceteNo = this.EReceteNo.Text;
                ereceteAciklamaEkleIstekDVO.ereceteAciklamaDVO = ereceteAciklamaDVO;
                ereceteAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                EReceteIslemleri.ereceteAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.ereceteAciklamaEkle(Sites.SiteLocalHost, this.edtDoktorTC.Text,this.edtPassword.Text, ereceteAciklamaEkleIstekDVO);
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                        InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                    else
                        InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                }
            }
#endregion EReceteDetayForm_cmdAddPresDesc_Click
        }

        private void cmdAddSignedPresDesc_Click()
        {
#region EReceteDetayForm_cmdAddSignedPresDesc_Click
   bool error = false;
            if (string.IsNullOrEmpty(this.PresDesc.Text))
            {
                InfoBox.Show("Eklenecek Açıklama boş geçilemez", MessageIconEnum.ErrorMessage);
                error = true;
            }
            if (this.presDescriptionType.SelectedItem == null)
            {
                InfoBox.Show("Açıklama Türü boş geçilemez", MessageIconEnum.ErrorMessage);
                error = true;
            }
            if (error == false)
            {
                EReceteIslemleri.ereceteAciklamaDVO ereceteAciklamaDVO = new EReceteIslemleri.ereceteAciklamaDVO();
                ereceteAciklamaDVO.aciklama = this.PresDesc.Text;
                ereceteAciklamaDVO.aciklamaTuru = (int)this.presDescriptionType.SelectedItem.Value;
                EReceteIslemleri.ereceteAciklamaEkleIstekDVO ereceteAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteAciklamaEkleIstekDVO();
                ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(this.edtDoktorTC.Text);
                ereceteAciklamaEkleIstekDVO.ereceteNo = this.EReceteNo.Text;
                ereceteAciklamaEkleIstekDVO.ereceteAciklamaDVO = ereceteAciklamaDVO;
                ereceteAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                string imzalanacakXml = Common.SerializeObjectToXml(ereceteAciklamaEkleIstekDVO);
                imzalanacakXml = imzalanacakXml.Replace("ereceteAciklamaEkleIstekDVO", "imzaliEreceteAciklamaBilgisi");
                imzalanacakXml = imzalanacakXml.Replace("ereceteAciklamaDVO", "ereceteAciklamaBilgisi");

                byte[] signedContent = CommonForm.SignContent("E-reçete Açıklama Ekleme İçerik İmzalama", imzalanacakXml);
                if (signedContent == null)
                    throw new TTException("E-reçete açıklama ekleme içeriği imzalanamadı");

                EReceteIslemleri.imzaliEreceteAciklamaEkleIstekDVO imzaliEreceteAciklamaEkleIstekDVO = new EReceteIslemleri.imzaliEreceteAciklamaEkleIstekDVO();
                imzaliEreceteAciklamaEkleIstekDVO.doktorTcKimlikNo = ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo.ToString();
                imzaliEreceteAciklamaEkleIstekDVO.imzaliEreceteAciklama = signedContent;
                imzaliEreceteAciklamaEkleIstekDVO.surumNumarasi = "1";
                imzaliEreceteAciklamaEkleIstekDVO.tesisKodu = ereceteAciklamaEkleIstekDVO.tesisKodu.ToString();

                EReceteIslemleri.imzaliEreceteAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteAciklamaEkleSync(Sites.SiteLocalHost, this.edtDoktorTC.Text, this.edtPassword.Text, imzaliEreceteAciklamaEkleIstekDVO);

                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                        InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                    else
                        InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                }
            }
#endregion EReceteDetayForm_cmdAddSignedPresDesc_Click
        }

#region EReceteDetayForm_Methods
        public EReceteDetayForm(EReceteIslemleri.ereceteDVO  ereceteDVO, string doktorTc, string password)
            : this()
        {
            this.EReceteNo.Text = ereceteDVO.ereceteNo;
            this.edtDoktorTC.Text = doktorTc;
            this.edtPassword.Text = password;

            foreach (EReceteIslemleri.ereceteIlacDVO ilac in ereceteDVO.ereceteIlacListesi)
            {
                ITTGridRow addedRow = this.ilacGrid.Rows.Add();
                addedRow.Cells["Check"].Value =false;
                addedRow.Cells["Barcode"].Value =ilac.barkod;
                addedRow.Cells["Name"].Value = ilac.ilacAdi;
                addedRow.Cells["Frequency"].Value = ilac.kullanimDoz1.ToString();
                addedRow.Cells["DoseAmount"].Value = ilac.kullanimDoz2.ToString();
                addedRow.Cells["Day"].Value = ilac.kullanimPeriyot.ToString() ;
                if(ilac.kullanimPeriyotBirimi == 3)
                    addedRow.Cells["PeryodUnit"].Value = "Gün";
                else if(ilac.kullanimPeriyotBirimi == 4)
                    addedRow.Cells["PeryodUnit"].Value = "Hafta";
                else if(ilac.kullanimPeriyotBirimi == 5)
                    addedRow.Cells["PeryodUnit"].Value = "Ay";
                else if(ilac.kullanimPeriyotBirimi == 6)
                    addedRow.Cells["PeryodUnit"].Value = "Yıl";
                else
                    addedRow.Cells["PeryodUnit"].Value = ilac.kullanimPeriyotBirimi.ToString();
                addedRow.Cells["Amount"].Value = ilac.adet.ToString();
            }
            
        }
        
#endregion EReceteDetayForm_Methods
    }
}