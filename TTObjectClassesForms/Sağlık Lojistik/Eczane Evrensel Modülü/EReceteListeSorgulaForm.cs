
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
    /// Elektronik Reçete Listele Sorgulama
    /// </summary>
    public partial class EReceteListeSorgulaForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdClose.Click += new TTControlEventDelegate(cmdClose_Click);
            EreceteList.DoubleClick += new TTControlEventDelegate(EreceteList_DoubleClick);
            checkboxType.CheckedChanged += new TTControlEventDelegate(checkboxType_CheckedChanged);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            btnIptalEt.Click += new TTControlEventDelegate(btnIptalEt_Click);
            btnImzaliIptalEt.Click += new TTControlEventDelegate(btnImzaliIptalEt_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdClose.Click -= new TTControlEventDelegate(cmdClose_Click);
            EreceteList.DoubleClick -= new TTControlEventDelegate(EreceteList_DoubleClick);
            checkboxType.CheckedChanged -= new TTControlEventDelegate(checkboxType_CheckedChanged);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            btnIptalEt.Click -= new TTControlEventDelegate(btnIptalEt_Click);
            btnImzaliIptalEt.Click -= new TTControlEventDelegate(btnImzaliIptalEt_Click);
            base.UnBindControlEvents();
        }

        private void cmdClose_Click()
        {
#region EReceteListeSorgulaForm_cmdClose_Click
   Close();
#endregion EReceteListeSorgulaForm_cmdClose_Click
        }

        private void EreceteList_DoubleClick()
        {
#region EReceteListeSorgulaForm_EreceteList_DoubleClick
   EReceteIslemleri.ereceteDVO ereceteDVO = (EReceteIslemleri.ereceteDVO)EreceteList.SelectedItems[0].Tag;
            if(ereceteDVO.ereceteIlacListesi != null)
            {
                
                EReceteDetayForm eReceteDetayForm = new EReceteDetayForm(ereceteDVO,this.edtDoktorTC.Text,this.edtPassword.Text);
                InfoBox.Show("eReceteDetayForm.ShowDialog(this);");
            }
            else
            {
                EReceteIslemleri.ereceteSorguIstekDVO request = new EReceteIslemleri.ereceteSorguIstekDVO();
                request.doktorTcKimlikNo =  (long)Convert.ToDouble(edtDoktorTC.Text);
                request.ereceteNo = ereceteDVO.ereceteNo;
                request.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                EReceteIslemleri.ereceteSorguCevapDVO response = EReceteIslemleri.WebMethods.ereceteSorgulaSync(Sites.SiteLocalHost,edtDoktorTC.Text,edtPassword.Text,request);
                if(response != null)
                {
                    EReceteDetayForm eReceteDetayForm = new EReceteDetayForm(response.ereceteDVO, this.edtDoktorTC.Text,this.edtPassword.Text);
                    InfoBox.Show("eReceteDetayForm.ShowDialog(this);");
                }
                else
                    InfoBox.Show(response.sonucMesaji ,MessageIconEnum.ErrorMessage);
                
            }
#endregion EReceteListeSorgulaForm_EreceteList_DoubleClick
        }

        private void checkboxType_CheckedChanged()
        {
#region EReceteListeSorgulaForm_checkboxType_CheckedChanged
   if (checkboxType.Value != null)
            {
                if ((bool)checkboxType.Value)
                {
                    edtHastaTC.Enabled = false;
                    edtHastaTC.Text = string.Empty;
                    edtEreceteNo.Enabled = true;
                }
                else
                {
                    edtHastaTC.Enabled = true;
                    edtEreceteNo.Enabled = false;
                    edtEreceteNo.Text= string.Empty;
                }
                
            }
#endregion EReceteListeSorgulaForm_checkboxType_CheckedChanged
        }

        private void ttbutton1_Click()
        {
#region EReceteListeSorgulaForm_ttbutton1_Click
   if ((bool)checkboxType.Value)
            {
                if (string.IsNullOrEmpty(edtEreceteNo.Text) || string.IsNullOrEmpty(edtDoktorTC.Text) || string.IsNullOrEmpty(edtPassword.Text) )
                {
                    InfoBox.Show("Lütfen Tüm Alanları Doldurunuz.");
                }
                else
                {
                    EReceteIslemleri.ereceteSorguIstekDVO request = new EReceteIslemleri.ereceteSorguIstekDVO();
                    request.doktorTcKimlikNo =  (long)Convert.ToDouble(edtDoktorTC.Text);
                    request.ereceteNo = edtEreceteNo.Text.ToString();
                    request.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                    EReceteIslemleri.ereceteSorguCevapDVO response = EReceteIslemleri.WebMethods.ereceteSorgulaSync(Sites.SiteLocalHost,edtDoktorTC.Text,edtPassword.Text,request);

                    EreceteList.Items.Clear();
                    if (response != null)
                    {
                        if (response.ereceteDVO != null)
                        {
                            ITTListViewItem listViewItem = EreceteList.Items.Add(response.ereceteDVO.ereceteNo);
                            listViewItem.SubItems.Add(response.ereceteDVO.takipNo.ToString());
                            listViewItem.SubItems.Add(response.ereceteDVO.receteTarihi.ToString());
                            listViewItem.SubItems.Add(response.ereceteDVO.protokolNo.ToString());
                            listViewItem.SubItems.Add(response.ereceteDVO.seriNo.ToString());
                            listViewItem.Tag = response.ereceteDVO;
                        }
                    }
                    else
                        InfoBox.Show(response.sonucMesaji, MessageIconEnum.ErrorMessage);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(edtDoktorTC.Text) || string.IsNullOrEmpty(edtHastaTC.Text) || string.IsNullOrEmpty(edtPassword.Text))
                {
                    InfoBox.Show("Lütfen Tüm Alanları Doldurunuz.");
                }
                else
                {
                    if (edtDoktorTC.Text.Length != 11 || edtHastaTC.Text.Length != 11)
                    {
                         InfoBox.Show("TC Kimlik No 11 Hane olmalıdır.");
                    }
                    else
                    {
                        EReceteIslemleri.ereceteListeSorguIstekDVO request = new EReceteIslemleri.ereceteListeSorguIstekDVO();
                        request.doktorTcKimlikNo = (long)Convert.ToDouble(edtDoktorTC.Text);
                        request.hastaTcKimlikNo = (long)Convert.ToDouble(edtHastaTC.Text);
                        request.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

                        EReceteIslemleri.ereceteListeSorguCevapDVO response = EReceteIslemleri.WebMethods.ereceteListeSorgulaSync(Sites.SiteLocalHost,edtDoktorTC.Text,edtPassword.Text, request);

                        EreceteList.Items.Clear();
                        if (response != null)
                        {
                            if (response.ereceteListesi != null)
                            {
                                foreach (EReceteIslemleri.ereceteDVO item in response.ereceteListesi)
                                {
                                    ITTListViewItem listViewItem = EreceteList.Items.Add(item.ereceteNo);
                                    listViewItem.SubItems.Add(item.takipNo.ToString());
                                    listViewItem.SubItems.Add(item.receteTarihi.ToString());
                                    listViewItem.SubItems.Add(item.protokolNo.ToString());
                                    listViewItem.SubItems.Add(item.seriNo.ToString());
                                    listViewItem.Tag = item;
                                }
                            }
                        }
                        else
                            InfoBox.Show(response.sonucMesaji, MessageIconEnum.ErrorMessage);
                    }
                }
            }
#endregion EReceteListeSorgulaForm_ttbutton1_Click
        }

        private void btnIptalEt_Click()
        {
#region EReceteListeSorgulaForm_btnIptalEt_Click
   string doktorTCKimlikNoString = edtDoktorTC.Text.Trim();
            string doktorEreceteSifre = edtPassword.Text.Trim();
            string ereceteNo = edtEreceteNo.Text.Trim();
            
            if (string.IsNullOrEmpty(ereceteNo) || string.IsNullOrEmpty(doktorTCKimlikNoString) || string.IsNullOrEmpty(doktorEreceteSifre) )
            {
                InfoBox.Show("E-reçete no, Doktor kimlik no ve/veya E-reçete şifresini doldurunuz.");
                return;
            }
            
            long doktorTCKimlikNo;
            if ( long.TryParse(doktorTCKimlikNoString, out doktorTCKimlikNo) == false )
                throw new TTException("Doktor kimlik numarası hatalı");
            
            ITTListViewItem listViewItem = EreceteList.SelectedItems[0];
            if ( listViewItem == null )
            {
                TTVisual.InfoBox.Show("Lütfen listeden iptal edilecek e-reçeteyi seçiniz", MessageIconEnum.InformationMessage);
                return;
            }
            
            TTObjectClasses.EReceteIslemleri.ereceteDVO ereceteDvo = listViewItem.Tag  as TTObjectClasses.EReceteIslemleri.ereceteDVO;
            if ( ereceteDvo == null )
                throw new TTException("E-Reçete bilgisi alınamadı");
            
            TTObjectClasses.EReceteIslemleri.ereceteSilIstekDVO silIstekDvo = new TTObjectClasses.EReceteIslemleri.ereceteSilIstekDVO();
            silIstekDvo.doktorTcKimlikNo = doktorTCKimlikNo;
            silIstekDvo.ereceteNo = ereceteNo;
            silIstekDvo.tesisKodu = ereceteDvo.tesisKodu;
            
            EReceteIslemleri.ereceteSilCevapDVO response = EReceteIslemleri.WebMethods.ereceteSil(Sites.SiteLocalHost, doktorTCKimlikNoString, doktorEreceteSifre, silIstekDvo);
            if (response != null)
            {
                if (response.sonucKodu.Equals("0000"))
                {
                    InfoBox.Show("E reçete başarıyla iptal edilmiştir.");
                }
                else
                {
                    if (!string.IsNullOrEmpty(response.uyariMesaji))
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
                    else
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                }
            }
#endregion EReceteListeSorgulaForm_btnIptalEt_Click
        }

        private void btnImzaliIptalEt_Click()
        {
#region EReceteListeSorgulaForm_btnImzaliIptalEt_Click
   string doktorTCKimlikNoString = edtDoktorTC.Text.Trim();
            string doktorEreceteSifre = edtPassword.Text.Trim();
            string ereceteNo = edtEreceteNo.Text.Trim();
            
            if (string.IsNullOrEmpty(ereceteNo) || string.IsNullOrEmpty(doktorTCKimlikNoString) || string.IsNullOrEmpty(doktorEreceteSifre) )
            {
                InfoBox.Show("E-reçete no, Doktor kimlik no ve/veya E-reçete şifresini doldurunuz.");
                return;
            }
            
            ITTListViewItem listViewItem = EreceteList.SelectedItems[0];
            if ( listViewItem == null )
            {
                TTVisual.InfoBox.Show("Lütfen listeden iptal edilecek e-reçeteyi seçiniz", MessageIconEnum.InformationMessage);
                return;
            }
            
            long doktorTCKimlikNo;
            if ( long.TryParse(doktorTCKimlikNoString, out doktorTCKimlikNo) == false )
                throw new TTException("Doktor kimlik numarası hatalı");
            
            
            TTObjectClasses.EReceteIslemleri.ereceteDVO ereceteDvo = listViewItem.Tag  as TTObjectClasses.EReceteIslemleri.ereceteDVO;
            if ( ereceteDvo == null )
                throw new TTException("E-Reçete bilgisi alınamadı");
            
            TTObjectClasses.EReceteIslemleri.ereceteSilIstekDVO silIstekDvo = new TTObjectClasses.EReceteIslemleri.ereceteSilIstekDVO();
            silIstekDvo.doktorTcKimlikNo = doktorTCKimlikNo;
            silIstekDvo.ereceteNo = ereceteNo;
            silIstekDvo.tesisKodu = ereceteDvo.tesisKodu;
            
            string imzalanacakXml = Common.SerializeObjectToXml(silIstekDvo);
            imzalanacakXml = imzalanacakXml.Replace("ereceteSilIstekDVO", "imzaliEreceteSilBilgisi");
            byte[] signedContent = CommonForm.SignContent(imzalanacakXml);
            if ( signedContent == null )
                throw new TTException("E-reçete iptal içeriği imzalanamadı");
            
            TTObjectClasses.EReceteIslemleri.imzaliEreceteSilIstekDVO imzaliEreceteSilIstek = new TTObjectClasses.EReceteIslemleri.imzaliEreceteSilIstekDVO();
            imzaliEreceteSilIstek.doktorTcKimlikNo = silIstekDvo.doktorTcKimlikNo.ToString();
            imzaliEreceteSilIstek.imzaliEreceteSil = signedContent;
            imzaliEreceteSilIstek.tesisKodu = silIstekDvo.tesisKodu.ToString();
            imzaliEreceteSilIstek.surumNumarasi = "1";

            EReceteIslemleri.imzaliEreceteSilCevapDVO response = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, doktorTCKimlikNoString, doktorEreceteSifre, imzaliEreceteSilIstek);
            if (response != null)
            {
                if (response.sonucKodu.Equals("0000"))
                {
                    InfoBox.Show("E reçete başarıyla iptal edilmiştir.");
                }
                else
                {
                    if (!string.IsNullOrEmpty(response.uyariMesaji))
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
                    else
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                }
            }
#endregion EReceteListeSorgulaForm_btnImzaliIptalEt_Click
        }

#region EReceteListeSorgulaForm_Methods
        protected override void OnLoad(EventArgs e)
        {
            this.checkboxType.Value = true;
            ResUser currentUser = Common.CurrentResource;
            ((ITTObject)currentUser).Refresh();
            this.edtDoktorTC.Text = currentUser.UniqueNo ;
            if(string.IsNullOrEmpty(currentUser.ErecetePassword) == false)
            {
                this.edtPassword.Text = currentUser.ErecetePassword;
                this.edtPassword.Enabled = false;
            }
        }
        
#endregion EReceteListeSorgulaForm_Methods
    }
}