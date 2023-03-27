
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
    public partial class BaseTedaviRaporuKaydetForm : BaseRaporBilgisiKaydetForm
    {
        override protected void BindControlEvents()
        {
            tedaviRaporuYaz.Click += new TTControlEventDelegate(tedaviRaporuYaz_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tedaviRaporuYaz.Click -= new TTControlEventDelegate(tedaviRaporuYaz_Click);
            base.UnBindControlEvents();
        }

        private void tedaviRaporuYaz_Click()
        {
#region BaseTedaviRaporuKaydetForm_tedaviRaporuYaz_Click
   /*
            try
            {
                if (_BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.tedaviRaporTuru.HasValue)
                {
                    TedaviIslemBilgisiDVO tedaviIslemBilgisiDVO = null;
                    if (_BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.islemler.Count > 0)
                    {
                        tedaviIslemBilgisiDVO = _BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.islemler[0];
                    }
                    else
                    {
                        tedaviIslemBilgisiDVO = _BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.islemler.AddNew();
                        TedaviRaporTuru tedaviRaporTuru = TedaviRaporTuru.GetTedaviRaporTuru(_BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.tedaviRaporTuru.Value);
                        switch (_BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.tedaviRaporTuru)
                        {
                            case 1: // Diyaliz
                                throw new TTException(tedaviRaporTuru.tedaviRaporTuruAdi + " ileride duyurulacak bir tarihe kadar kapalıdır!");
                                //tedaviIslemBilgisiDVO.diyalizRaporBilgisi = new DiyalizRaporBilgisiDVO(_BaseTedaviRaporuKaydet.ObjectContext);
                                //break;
                            case 2: // Hiperbarik Oksijen Tedavisi
                                throw new TTException(tedaviRaporTuru.tedaviRaporTuruAdi + " ileride duyurulacak bir tarihe kadar kapalıdır!");
                                //tedaviIslemBilgisiDVO.hotRaporBilgisi = new HOTRaporBilgisiDVO(_BaseTedaviRaporuKaydet.ObjectContext);
                                //break;
                            case 3: // ESWT
                                tedaviIslemBilgisiDVO.eswtRaporBilgisi = new ESWTRaporBilgisiDVO(_BaseTedaviRaporuKaydet.ObjectContext);
                                break;
                            case 4: // Tüpbebek Tedavisi
                                throw new TTException(tedaviRaporTuru.tedaviRaporTuruAdi + " ileride duyurulacak bir tarihe kadar kapalıdır!");
                                //tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = new TupBebekRaporBilgisiDVO(_BaseTedaviRaporuKaydet.ObjectContext);
                                //break;
                            case 5: // Fizik Tedavi ve Rehabilitasyon
                                tedaviIslemBilgisiDVO.ftrRaporBilgisi = new FTRRaporBilgisiDVO(_BaseTedaviRaporuKaydet.ObjectContext);
                                break;
                            case 6: // ESWL
                                tedaviIslemBilgisiDVO.eswlRaporBilgisi = new ESWLRaporBilgisiDVO(_BaseTedaviRaporuKaydet.ObjectContext);
                                break;
                        }
                        tedaviRaporTuruTedaviRaporDVO.ReadOnly = true;
                        tedaviRaporuYaz.Text = "Tedavi Raporu Düzelt";
                    }
                    MedulaGlobals.ShowTedaviIslemBilgisi(this, _BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.tedaviRaporTuru.Value, tedaviIslemBilgisiDVO, false);
                }
                else
                {
                    throw new TTException("Tedavi raporu yazmak için önce \"Tedavi Rapor Türü\" seçmelisiniz.");
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
                if (_BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.islemler.Count > 0)
                    for (int i = 0; i < _BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.islemler.Count; i++)
                    ((ITTObject)_BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.islemler[i]).Delete();
            }
            */
#endregion BaseTedaviRaporuKaydetForm_tedaviRaporuYaz_Click
        }

        protected override void PreScript()
        {
#region BaseTedaviRaporuKaydetForm_PreScript
    base.PreScript();


            if (_BaseTedaviRaporuKaydet.raporGirisDVO.tedaviRapor.tedaviRaporTuru.HasValue)
            {
                tedaviRaporTuruTedaviRaporDVO.ReadOnly = true;
                tedaviRaporuYaz.Text = "Tedavi Raporu Düzelt";
            }
#endregion BaseTedaviRaporuKaydetForm_PreScript

            }
                }
}