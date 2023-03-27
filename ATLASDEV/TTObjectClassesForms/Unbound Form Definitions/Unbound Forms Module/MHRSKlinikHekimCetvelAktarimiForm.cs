
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
    /// MHRS Klinik-Hekim-Cetvel Aktarımı
    /// </summary>
    public partial class MHRSKlinikHekimCetvelAktarimi : TTUnboundForm
    {
        override protected void BindControlEvents()
        {            
            btnAltKlinikAktar.Click += new TTControlEventDelegate(btnAltKlinikAktar_Click);
            btnPlanAktar.Click += new TTControlEventDelegate(btnPlanAktar_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnAltKlinikAktar.Click -= new TTControlEventDelegate(btnAltKlinikAktar_Click);
            btnPlanAktar.Click -= new TTControlEventDelegate(btnPlanAktar_Click);
            base.UnBindControlEvents();
        }

       
        private void btnAltKlinikAktar_Click()
        {
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");

            if (userName != null && password != null && MHRSKurumKodu != null)
            {
                MHRSServis.KurumAltKlinikSorgulamaTalepType kurumAltKlinikSorgulamaTalep = new MHRSServis.KurumAltKlinikSorgulamaTalepType();
                MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                MHRSServis.KurumAltKlinikSorgulamaCevapType kurumAltKlinikSorgulamaCevap = new MHRSServis.KurumAltKlinikSorgulamaCevapType();

                yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

                kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
                kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                kurumBilgileri.KurumKoduSpecified = true;
                kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

                kurumAltKlinikSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
                kurumAltKlinikSorgulamaTalep.KurumBilgileri = kurumBilgileri;

                TTObjectContext objectContext = new TTObjectContext(false);
                BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetAllPoliclinics(objectContext);

                foreach (ResPoliclinic policlinic in policlinicList)
                {
                    if (policlinic.IsActive == true && policlinic.MHRSCode != null && policlinic.MHRSAltKlinikKodu == null)
                    {
                        kurumAltKlinikSorgulamaTalep.KlinikKodu = Convert.ToInt32(policlinic.MHRSCode);

                        kurumAltKlinikSorgulamaCevap = MHRSServis.WebMethods.KurumAltKlinikSorgulamaSync(Sites.SiteLocalHost, kurumAltKlinikSorgulamaTalep);
                        if (kurumAltKlinikSorgulamaCevap != null && kurumAltKlinikSorgulamaCevap.TemelCevapBilgileri != null)
                        {
                            if (kurumAltKlinikSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true && kurumAltKlinikSorgulamaCevap.AltKlinikBilgileri != null)
                            {
                                policlinic.MHRSAltKlinikKodu = kurumAltKlinikSorgulamaCevap.AltKlinikBilgileri[0].AltKlinikKodu;
                            }
                        }
                    }
                }
                objectContext.Save();
            }
        }    
        
        private void btnPlanAktar_Click()
        {
            //string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
            //string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
            //string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
            //string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");
            //string MHRSIslemYapanKisiTC = TTObjectClasses.SystemParameter.GetParameterValue("MHRSISLEMYAPANKISITC", "");

            //if (userName != null && password != null && MHRSKurumKodu != null)
            //{
            //    MHRSServis.KurumKesinCetvelSorgulamaTalepType kurumKesinCetvelSorgulamaTalep = new MHRSServis.KurumKesinCetvelSorgulamaTalepType();
            //    MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
            //    MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
            //    MHRSServis.KurumKesinCetvelSorgulamaCevapType kurumKesinCetvelSorgulamaCevap = new MHRSServis.KurumKesinCetvelSorgulamaCevapType();

            //    yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
            //    yetkilendirmeGirisBilgileri.KullaniciSifre = password;
            //    yetkilendirmeGirisBilgileri.KulaniciTuru = 2;

            //    kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(MHRSIslemYapanKisiTC);
            //    kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
            //    kurumBilgileri.KurumKoduSpecified = true;
            //    kurumBilgileri.GonderenBirim = MHRSFirmaKodu;

            //    kurumKesinCetvelSorgulamaTalep.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;
            //    kurumKesinCetvelSorgulamaTalep.KurumBilgileri = kurumBilgileri;

            //    TTObjectContext objectContext = new TTObjectContext(false);
            //    BindingList<ResPoliclinic> policlinicList = ResPoliclinic.GetAllPoliclinics(objectContext);

            //    foreach (ResPoliclinic policlinic in policlinicList)
            //    {
            //        if (policlinic.IsActive == true && policlinic.MHRSCode != null && policlinic.MHRSAltKlinikKodu == null)
            //        {

            //            kurumKesinCetvelSorgulamaCevap = MHRSServis.WebMethods.KurumKesinCetvelSorgulamaSync(Sites.SiteLocalHost, kurumKesinCetvelSorgulamaTalep);
            //            if (kurumKesinCetvelSorgulamaCevap != null && kurumKesinCetvelSorgulamaCevap.TemelCevapBilgileri != null)
            //            {
            //                if (kurumKesinCetvelSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true)
            //                {
            //                    policlinic.MHRSAltKlinikKodu = kurumKesinCetvelSorgulamaCevap.AltKlinikBilgileri[0].AltKlinikKodu;
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}