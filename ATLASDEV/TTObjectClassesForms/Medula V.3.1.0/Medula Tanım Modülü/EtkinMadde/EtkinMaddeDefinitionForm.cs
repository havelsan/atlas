
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
    public partial class EtkinMaddeDefinitionForm : BaseMedulaDefinitionForm
    {
        override protected void BindControlEvents()
        {
            btnEtkinMaddeSutListesiSorgula.Click += new TTControlEventDelegate(btnEtkinMaddeSutListesiSorgula_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnEtkinMaddeSutListesiSorgula.Click -= new TTControlEventDelegate(btnEtkinMaddeSutListesiSorgula_Click);
            base.UnBindControlEvents();
        }

        private void btnEtkinMaddeSutListesiSorgula_Click()
        {
#region EtkinMaddeDefinitionForm_btnEtkinMaddeSutListesiSorgula_Click
   TTObjectContext objectContextReadOnly = new TTObjectContext(true);

            try
            {
                
                YardimciIslemler.etkinMaddeSutListesiSorguIstekDVO request = new YardimciIslemler.etkinMaddeSutListesiSorguIstekDVO();
                request.doktorTcKimlikNo = Convert.ToInt64(TTObjectClasses.SystemParameter.GetParameterValue("MEDULADOKTORKIMLIKNO", "0"));
                request.tesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                request.etkinMaddeKodu = etkinMaddeKodu.Text;
                request.raporTarihi = DateTime.Now.ToString("dd.MM.yyyy");
                YardimciIslemler.etkinMaddeSutListesiSorguCevapDVO response = YardimciIslemler.WebMethods.etkinMaddeSutListesiSorgulaSync(Sites.SiteLocalHost, request);
                if (response != null)
                {
                    if (response.sonucKodu.Equals("0000"))
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (YardimciIslemler.etkinMaddeSutDVO item in response.etkinMaddeSutListesi)
                        {

                            sb.AppendLine("Etkin Madde Sut Numarası :" + item.etkinMaddeSutNo);
                            foreach (YardimciIslemler.raporTeshisDVO teshis in item.raporTeshisListesi)
                            {
                                sb.AppendLine("Rapor Teshis Kodu :" + teshis.raporTeshisKodu);
                                sb.AppendLine("Rapor Teshis Açıklama :" + teshis.aciklama);
                                sb.AppendLine("-----------------------------------------------");
                            }

                            sb.AppendLine("Rapor Düzenleme Türü :" + item.raporDuzenlemeTuru);
                        }
                        if (!string.IsNullOrEmpty(sb.ToString()))
                        {
                            txtSUTList.Text = "";
                            txtSUTList.Text = sb.ToString();
                        }
                        else
                        {
                            txtSUTList.Text = "";
                            txtSUTList.Text = "Etkin Madde Koduna ait SUT Listesi Bulunamamıştır";
                        }
                    }
                    else
                    {
                        txtSUTList.Text = "";
                        txtSUTList.Text = response.sonucMesaji+" "+response.uyariMesaji;
                    }
                    
                }
                


            }
            catch (Exception ex)
            {

            }
#endregion EtkinMaddeDefinitionForm_btnEtkinMaddeSutListesiSorgula_Click
        }
    }
}