
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
    public partial class MedulaTesisYatakSorguIslemleri : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnSorgula.Click += new TTControlEventDelegate(btnSorgula_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnSorgula.Click -= new TTControlEventDelegate(btnSorgula_Click);
            base.UnBindControlEvents();
        }

        private void btnSorgula_Click()
        {
#region MedulaTesisYatakSorguIslemleri_btnSorgula_Click
   gridYataklar.Rows.Clear();
            this.txtSonucKodu.Text = String.Empty;
            this.txtSonucMesaji.Text = String.Empty;
            MedulaYardimciIslemler.tesisYatakSorguGirisDVO _tesisYatakSorguGirisDVO = new MedulaYardimciIslemler.tesisYatakSorguGirisDVO();
            
            _tesisYatakSorguGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            if (dtpTarih.ControlValue != null)
            {
                string tarihDateTime = ((DateTime)((ITTDateTimePicker)dtpTarih).ControlValue).ToString("dd.MM.yyyy");
                if (string.IsNullOrEmpty(tarihDateTime) == false && tarihDateTime.Length >= 10)
                    _tesisYatakSorguGirisDVO.tarih = tarihDateTime.Substring(0, 10);
            }
            
            MedulaYardimciIslemler.tesisYatakSorguCevapDVO response = MedulaYardimciIslemler.WebMethods.tesisYatakSorguSync(Sites.SiteLocalHost, _tesisYatakSorguGirisDVO);
            if (response != null)
            {
                if (!String.IsNullOrEmpty(response.sonucKodu))
                {
                    this.txtSonucKodu.Text = response.sonucKodu;
                    this.txtSonucMesaji.Text = response.sonucMesaji;
                    if (response.sonucKodu.Equals("0000"))
                    {
                        if (response.yataklar == null)
                        {
                            InfoBox.Show("Yatak bulunamadı.", MessageIconEnum.InformationMessage);
                            return;
                        }

                        foreach (MedulaYardimciIslemler.tesisYatakBilgiDVO item in response.yataklar)
                        {
                            ITTGridRow newRow = gridYataklar.Rows.Add();
                            newRow.Cells[yatakKodu.Name].Value = item.yatakKodu;
                            if (item.turu == "E")
                                newRow.Cells[turu.Name].Value =(Common.GetEnumValueDefOfEnumValue((Enum)MedulaTesisYatakSorguYatakTuru.E)).DisplayText;
                            else if (item.turu == "P")
                                newRow.Cells[turu.Name].Value = (Common.GetEnumValueDefOfEnumValue((Enum)MedulaTesisYatakSorguYatakTuru.P)).DisplayText; 
                            else if (item.turu == "Y")
                                newRow.Cells[turu.Name].Value = (Common.GetEnumValueDefOfEnumValue((Enum)MedulaTesisYatakSorguYatakTuru.Y)).DisplayText;
                            
                            newRow.Cells[tescilTuru.Name].Value = Common.GetEnumValueDefOfEnumValueV2("MedulaTesisYatakSorguTescilTuru", item.tescilTuru).DisplayText;
                            newRow.Cells[seviye.Name].Value = Common.GetEnumValueDefOfEnumValueV2("MedulaTesisYatakSorguSeviye", item.seviye).DisplayText;
                            newRow.Cells[gecerlilikBaslangicTarihi.Name].Value = item.gecerlilikBaslangicTarihi;
                            newRow.Cells[gecerlilikBitisTarihi.Name].Value = item.gecerlilikBitisTarihi;
                        }
                    }
                }
                else
                {
                    InfoBox.Show("Medula' dan sonuç alınamadı", MessageIconEnum.InformationMessage);
                    return;
                }
            }
#endregion MedulaTesisYatakSorguIslemleri_btnSorgula_Click
        }
    }
}