
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
    public partial class MedulaBarkodSutEslesmeSorguIslemleri : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnFirmaBul.Click += new TTControlEventDelegate(btnFirmaBul_Click);
            btnMalzemeBul.Click += new TTControlEventDelegate(btnMalzemeBul_Click);
            listBoxFirma.SelectedObjectChanged += new TTControlEventDelegate(listBoxFirma_SelectedObjectChanged);
            btnSorgula.Click += new TTControlEventDelegate(btnSorgula_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnFirmaBul.Click -= new TTControlEventDelegate(btnFirmaBul_Click);
            btnMalzemeBul.Click -= new TTControlEventDelegate(btnMalzemeBul_Click);
            listBoxFirma.SelectedObjectChanged -= new TTControlEventDelegate(listBoxFirma_SelectedObjectChanged);
            btnSorgula.Click -= new TTControlEventDelegate(btnSorgula_Click);
            base.UnBindControlEvents();
        }

        private void btnFirmaBul_Click()
        {
#region MedulaBarkodSutEslesmeSorguIslemleri_btnFirmaBul_Click
   this.listBoxFirma.SelectedObject = null;
            if(!String.IsNullOrEmpty(this.txtFirmaTanimlayiciNo.Text))
            {
                TTObjectContext objectContext = new TTObjectContext(true);
                BindingList<FirmDefinition> firmList = FirmDefinition.GetFirmByIdentityNumber(objectContext,Convert.ToInt64(this.txtFirmaTanimlayiciNo.Text));
                if(firmList.Count > 0)
                {
                    this.listBoxFirma.SelectedObject = firmList[0];
                }
                else
                {
                    InfoBox.Show("Girilen firma tanımlayıcı numarası XXXXXX' ta kayıtlı değildir.",MessageIconEnum.InformationMessage);
                    return;
                }
            }
            else
            {
                InfoBox.Show("Firma Tanımlayıcı No alanına veri girişi yapınız.",MessageIconEnum.InformationMessage);
                return;
            }
#endregion MedulaBarkodSutEslesmeSorguIslemleri_btnFirmaBul_Click
        }

        private void btnMalzemeBul_Click()
        {
#region MedulaBarkodSutEslesmeSorguIslemleri_btnMalzemeBul_Click
   this.listBoxMalzeme.SelectedObject = null;
            if(!String.IsNullOrEmpty(this.txtBarkod.Text))
            {
                TTObjectContext objectContext = new TTObjectContext(true);
                BindingList<Material> materialList = Material.GetMaterialByBarcode(objectContext,this.txtBarkod.Text);
                if(materialList.Count > 0)
                {
                    this.listBoxMalzeme.SelectedObject = materialList[0];
                }
                else
                {
                    InfoBox.Show("Girilen barkod XXXXXX' ta kayıtlı değildir.",MessageIconEnum.InformationMessage);
                    return;
                }
            }
            else
            {
                InfoBox.Show("Barkod alanına veri girişi yapınız.",MessageIconEnum.InformationMessage);
                return;
            }
#endregion MedulaBarkodSutEslesmeSorguIslemleri_btnMalzemeBul_Click
        }

        private void listBoxFirma_SelectedObjectChanged()
        {
#region MedulaBarkodSutEslesmeSorguIslemleri_listBoxFirma_SelectedObjectChanged
   if(this.listBoxFirma.SelectedObject !=null && ((FirmDefinition)this.listBoxFirma.SelectedObject).IdentityNumber != null)
            {
                this.txtFirmaTanimlayiciNo.Text = ((FirmDefinition)this.listBoxFirma.SelectedObject).IdentityNumber.ToString();
            }
#endregion MedulaBarkodSutEslesmeSorguIslemleri_listBoxFirma_SelectedObjectChanged
        }

        private void btnSorgula_Click()
        {
#region MedulaBarkodSutEslesmeSorguIslemleri_btnSorgula_Click
   gridEslesmeler.Rows.Clear();
            this.txtSonucKodu.Text = String.Empty;
            this.txtSonucMesaji.Text = String.Empty;
            MedulaYardimciIslemler.barkodSutEslesmeSorguGirisDVO _barkodSutEslesmeSorguGirisDVO = new MedulaYardimciIslemler.barkodSutEslesmeSorguGirisDVO();

            _barkodSutEslesmeSorguGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            if (dtpTarih.ControlValue != null)
            {
                string tarihDateTime = ((DateTime)((ITTDateTimePicker)dtpTarih).ControlValue).ToString("dd.MM.yyyy");
                if (string.IsNullOrEmpty(tarihDateTime) == false && tarihDateTime.Length >= 10)
                    _barkodSutEslesmeSorguGirisDVO.tarih = tarihDateTime.Substring(0, 10);
            }
            
            if (!String.IsNullOrEmpty(this.txtSutKodu.Text))
            {
                _barkodSutEslesmeSorguGirisDVO.sutKodu = this.txtSutKodu.Text;
            }
            else if (!String.IsNullOrEmpty(this.firmaTanimlayiciNo.Text) && !String.IsNullOrEmpty(this.txtBarkod.Text))
            {
                _barkodSutEslesmeSorguGirisDVO.firmaTanimlayiciNo = this.txtFirmaTanimlayiciNo.Text;
                _barkodSutEslesmeSorguGirisDVO.barkod = this.txtBarkod.Text;
            }
            else
            {
                InfoBox.Show("Barkod ve firma tanımlayıcı no ile sorgulama yapılacaksa Barkod ve Firma bilgilerini, Sut kodu ile sorgulama yapılacaksa Sut Kodu bilgisini giriniz.", MessageIconEnum.InformationMessage);
                return;
            }
            
            MedulaYardimciIslemler.barkodSutEslesmeSorguCevapDVO response = MedulaYardimciIslemler.WebMethods.barkodSutEslesmeSorguSync(Sites.SiteLocalHost, _barkodSutEslesmeSorguGirisDVO);
            if (response != null)
            {
                if (!String.IsNullOrEmpty(response.sonucKodu))
                {
                    this.txtSonucKodu.Text = response.sonucKodu;
                    this.txtSonucMesaji.Text = response.sonucMesaji;
                    if (response.sonucKodu.Equals("0000"))
                    {
                        if (response.eslesmeler == null)
                        {
                            InfoBox.Show("Eşleşme bulunamadı.", MessageIconEnum.InformationMessage);
                            return;
                        }
                        TTObjectContext objectContext = new TTObjectContext(true);
                        foreach (MedulaYardimciIslemler.barkodSutDVO item in response.eslesmeler)
                        {
                            ITTGridRow newRow = gridEslesmeler.Rows.Add();
                            BindingList<Material> materialList = Material.GetMaterialByBarcode(objectContext,item.barkod);
                            if(materialList.Count > 0)
                                newRow.Cells[barkod.Name].Value = item.barkod + " - " + materialList[0].Name;
                            else
                                newRow.Cells[barkod.Name].Value = item.barkod;
                            
                            BindingList<FirmDefinition> firmList = FirmDefinition.GetFirmByIdentityNumber(objectContext,Convert.ToInt64(item.firmaTanimlayiciNo));
                            if(firmList.Count > 0)
                                newRow.Cells[firmaTanimlayiciNo.Name].Value = item.firmaTanimlayiciNo + " - " +  firmList[0].Name;
                            else
                                newRow.Cells[firmaTanimlayiciNo.Name].Value = item.firmaTanimlayiciNo;
                            newRow.Cells[sutKodu.Name].Value = item.sutKodu;
                            newRow.Cells[baslangicTarihi.Name].Value = item.baslangicTarihi;
                            newRow.Cells[bitisTarihi.Name].Value = item.bitisTarihi;
                        }
                        objectContext.Dispose();
                    }
                }
                else
                {
                    InfoBox.Show("Medula' dan sonuç alınamadı", MessageIconEnum.InformationMessage);
                    return;
                }
            }
#endregion MedulaBarkodSutEslesmeSorguIslemleri_btnSorgula_Click
        }
    }
}