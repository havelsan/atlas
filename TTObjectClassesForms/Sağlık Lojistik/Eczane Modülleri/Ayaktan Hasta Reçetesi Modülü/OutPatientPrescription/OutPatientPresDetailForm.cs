
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
    /// E Reçete Detay Ekleme
    /// </summary>
    public partial class OutPatientPresDetailForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdAddDrugDetail.Click += new TTControlEventDelegate(cmdAddDrugDetail_Click);
            cmdAddSignedDrugDetail.Click += new TTControlEventDelegate(cmdAddSignedDrugDetail_Click);
            cmdAddDiag.Click += new TTControlEventDelegate(cmdAddDiag_Click);
            cmdAddSignedDiag.Click += new TTControlEventDelegate(cmdAddSignedDiag_Click);
            cmdAddPresDesc.Click += new TTControlEventDelegate(cmdAddPresDesc_Click);
            cmdAddSignedPresDesc.Click += new TTControlEventDelegate(cmdAddSignedPresDesc_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdAddDrugDetail.Click -= new TTControlEventDelegate(cmdAddDrugDetail_Click);
            cmdAddSignedDrugDetail.Click -= new TTControlEventDelegate(cmdAddSignedDrugDetail_Click);
            cmdAddDiag.Click -= new TTControlEventDelegate(cmdAddDiag_Click);
            cmdAddSignedDiag.Click -= new TTControlEventDelegate(cmdAddSignedDiag_Click);
            cmdAddPresDesc.Click -= new TTControlEventDelegate(cmdAddPresDesc_Click);
            cmdAddSignedPresDesc.Click -= new TTControlEventDelegate(cmdAddSignedPresDesc_Click);
            base.UnBindControlEvents();
        }

        private void cmdAddDrugDetail_Click()
        {
#region OutPatientPresDetailForm_cmdAddDrugDetail_Click
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
                for (int i = 0; i < this.DrugGrid.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.DrugGrid.Rows[i].Cells["Select"].Value))
                    {
                        barcode = this.DrugGrid.Rows[i].Cells["Barcode"].Value.ToString();
                        count++;
                    }
                }
                if (count == 1)
                {
                    EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO ereceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO();
                    ereceteIlacAciklamaEkleIstekDVO.barkod = Convert.ToInt64(barcode);
                    ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(_OutPatientPrescription.ProcedureDoctor.UniqueNo);
                    ereceteIlacAciklamaEkleIstekDVO.ereceteNo = _OutPatientPrescription.EReceteNo;
                    ereceteIlacAciklamaEkleIstekDVO.ereceteIlacAciklamaDVO = ereceteAciklamaDVO;
                    ereceteIlacAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                    EReceteIslemleri.ereceteIlacAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.ereceteIlacAciklamaEkle(Sites.SiteLocalHost, _OutPatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), ereceteIlacAciklamaEkleIstekDVO);
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
#endregion OutPatientPresDetailForm_cmdAddDrugDetail_Click
        }

        private void cmdAddSignedDrugDetail_Click()
        {
#region OutPatientPresDetailForm_cmdAddSignedDrugDetail_Click
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
                for (int i = 0; i < this.DrugGrid.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.DrugGrid.Rows[i].Cells["Select"].Value))
                    {
                        barcode = this.DrugGrid.Rows[i].Cells["Barcode"].Value.ToString();
                        count++;
                    }
                }
                if (count == 1)
                {
                    EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO ereceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO();
                    ereceteIlacAciklamaEkleIstekDVO.barkod = Convert.ToInt64(barcode);
                    ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(_OutPatientPrescription.ProcedureDoctor.UniqueNo);
                    ereceteIlacAciklamaEkleIstekDVO.ereceteNo = _OutPatientPrescription.EReceteNo;
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

                    EReceteIslemleri.imzaliEreceteIlacAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteIlacAciklamaEkleSync(Sites.SiteLocalHost, _OutPatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), imzaliEreceteIlacAciklamaEkleIstekDVO);
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
#endregion OutPatientPresDetailForm_cmdAddSignedDrugDetail_Click
        }

        private void cmdAddDiag_Click()
        {
#region OutPatientPresDetailForm_cmdAddDiag_Click
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
                ereceteTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(_OutPatientPrescription.ProcedureDoctor.UniqueNo);
                ereceteTaniEkleIstekDVO.ereceteNo = _OutPatientPrescription.EReceteNo;
                ereceteTaniEkleIstekDVO.ereceteTaniDVO = ereceteTaniDVO;
                ereceteTaniEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                EReceteIslemleri.ereceteTaniEkleCevapDVO response = EReceteIslemleri.WebMethods.ereceteTaniEkle(Sites.SiteLocalHost, _OutPatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), ereceteTaniEkleIstekDVO);
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
#endregion OutPatientPresDetailForm_cmdAddDiag_Click
        }

        private void cmdAddSignedDiag_Click()
        {
#region OutPatientPresDetailForm_cmdAddSignedDiag_Click
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
                ereceteTaniEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(_OutPatientPrescription.ProcedureDoctor.UniqueNo);
                ereceteTaniEkleIstekDVO.ereceteNo = _OutPatientPrescription.EReceteNo;
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

                EReceteIslemleri.imzaliEreceteTaniEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteTaniEkleSync(Sites.SiteLocalHost, _OutPatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), imzaliEreceteTaniEkleIstekDVO);

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
#endregion OutPatientPresDetailForm_cmdAddSignedDiag_Click
        }

        private void cmdAddPresDesc_Click()
        {
#region OutPatientPresDetailForm_cmdAddPresDesc_Click
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
                ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(_OutPatientPrescription.ProcedureDoctor.UniqueNo);
                ereceteAciklamaEkleIstekDVO.ereceteNo = _OutPatientPrescription.EReceteNo;
                ereceteAciklamaEkleIstekDVO.ereceteAciklamaDVO = ereceteAciklamaDVO;
                ereceteAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                EReceteIslemleri.ereceteAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.ereceteAciklamaEkle(Sites.SiteLocalHost, _OutPatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), ereceteAciklamaEkleIstekDVO);
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                        InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                    else
                        InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                }
            }
#endregion OutPatientPresDetailForm_cmdAddPresDesc_Click
        }

        private void cmdAddSignedPresDesc_Click()
        {
#region OutPatientPresDetailForm_cmdAddSignedPresDesc_Click
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
                ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo = Convert.ToInt64(_OutPatientPrescription.ProcedureDoctor.UniqueNo);
                ereceteAciklamaEkleIstekDVO.ereceteNo = _OutPatientPrescription.EReceteNo;
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

                EReceteIslemleri.imzaliEreceteAciklamaEkleCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteAciklamaEkleSync(Sites.SiteLocalHost, _OutPatientPrescription.ProcedureDoctor.UniqueNo.ToString(), _OutPatientPrescription.ERecetePassword.ToString(), imzaliEreceteAciklamaEkleIstekDVO);

                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                        InfoBox.Show("Açıklama eklenmiştir.", MessageIconEnum.InformationMessage);
                    else
                        InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji, MessageIconEnum.ErrorMessage);
                }
            }
#endregion OutPatientPresDetailForm_cmdAddSignedPresDesc_Click
        }

        protected override void PreScript()
        {
#region OutPatientPresDetailForm_PreScript
    base.PreScript();
            this.DrugGrid.ReadOnly = false;
            this.descriptionType.ReadOnly = false;
            this.Diag.ReadOnly = false;
            this.DrugDescription.ReadOnly = false;
            this.PresDesc.ReadOnly = false;
            this.presDescriptionType.ReadOnly = false;
            this.Select.ReadOnly = false;
            this.ttgroupbox1.ReadOnly = false;
            this.ttgroupbox2.ReadOnly = false;
            this.ttgroupbox3.ReadOnly = false;


            foreach (OutPatientDrugOrder outPatientDrugOrder in _OutPatientPrescription.OutPatientDrugOrders)
            {
                ITTGridRow addedRow = this.DrugGrid.Rows.Add();
                addedRow.Cells["Select"].Value = false;
                addedRow.Cells["Drug"].Value = outPatientDrugOrder.Material.ObjectID;
                addedRow.Cells["Frequency"].Value = outPatientDrugOrder.Frequency;
                addedRow.Cells["DoseAmount"].Value = outPatientDrugOrder.DoseAmount.ToString();
                addedRow.Cells["Barcode"].Value = outPatientDrugOrder.Material.Barcode;
            }
#endregion OutPatientPresDetailForm_PreScript

            }
                }
}