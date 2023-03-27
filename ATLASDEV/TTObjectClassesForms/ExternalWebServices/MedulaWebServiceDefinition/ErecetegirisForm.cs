
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
    public partial class ErecetegirisForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton6.Click += new TTControlEventDelegate(ttbutton6_Click);
            ttbutton5.Click += new TTControlEventDelegate(ttbutton5_Click);
            TckimliknoSorgula.Click += new TTControlEventDelegate(TckimliknoSorgula_Click);
            faturaKaydet.Click += new TTControlEventDelegate(faturaKaydet_Click);
            ttbutton4.Click += new TTControlEventDelegate(ttbutton4_Click);
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            urunDogrula.Click += new TTControlEventDelegate(urunDogrula_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            ttbtnEreceteOnay.Click += new TTControlEventDelegate(ttbtnEreceteOnay_Click);
            EreceteGiris.Click += new TTControlEventDelegate(EreceteGiris_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton6.Click -= new TTControlEventDelegate(ttbutton6_Click);
            ttbutton5.Click -= new TTControlEventDelegate(ttbutton5_Click);
            TckimliknoSorgula.Click -= new TTControlEventDelegate(TckimliknoSorgula_Click);
            faturaKaydet.Click -= new TTControlEventDelegate(faturaKaydet_Click);
            ttbutton4.Click -= new TTControlEventDelegate(ttbutton4_Click);
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            urunDogrula.Click -= new TTControlEventDelegate(urunDogrula_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            ttbtnEreceteOnay.Click -= new TTControlEventDelegate(ttbtnEreceteOnay_Click);
            EreceteGiris.Click -= new TTControlEventDelegate(EreceteGiris_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton6_Click()
        {
#region ErecetegirisForm_ttbutton6_Click
   TTObjectClasses.Acil112Servis.PersonelBilgileri[] lis= new  TTObjectClasses.Acil112Servis.PersonelBilgileri[1];
            lis[0] = new TTObjectClasses.Acil112Servis.PersonelBilgileri();
            string[] ss = new string[1];
            ss[0] = "kı";
            
#endregion ErecetegirisForm_ttbutton6_Click
        }

        private void ttbutton5_Click()
        {
#region ErecetegirisForm_ttbutton5_Click
   //            HizmetKayitIslemleri.hizmetOkuGirisDVO basvuruTakipOkuDVO = new HizmetKayitIslemleri.hizmetOkuGirisDVO();
//            basvuruTakipOkuDVO.hizmetSunucuRefNolari=null;
//            basvuruTakipOkuDVO.islemSiraNumaralari=null;
//            basvuruTakipOkuDVO.saglikTesisKodu=12;
//            basvuruTakipOkuDVO.takipNo="xxxxxxx";

            // HastaKabulIslemleri.BasvuruTakipOkuCevapDVO cevap = HastaKabulIslemleri.RemoteMethods.basvuruTakipOkuS(TTObjectClasses.Sites.SiteLocalHost, basvuruTakipOkuDVO);

            //HizmetKayitIslemleri.RemoteMethods.hizmetOkuSync(TTObjectClasses.Sites.SiteLocalHost, basvuruTakipOkuDVO);
#endregion ErecetegirisForm_ttbutton5_Click
        }

        private void TckimliknoSorgula_Click()
        {
#region ErecetegirisForm_TckimliknoSorgula_Click

//      
//
//            // HastaKabulIslemleri.BasvuruTakipOkuCevapDVO cevap = HastaKabulIslemleri.RemoteMethods.basvuruTakipOkuS(TTObjectClasses.Sites.SiteLocalHost, basvuruTakipOkuDVO);
//
//            KPSPublic.RemoteMethods.TCKimlikNoDogrula(TTObjectClasses.Sites.SiteLocalHost, req , new TestWebCaller());
#endregion ErecetegirisForm_TckimliknoSorgula_Click
        }

        private void faturaKaydet_Click()
        {
#region ErecetegirisForm_faturaKaydet_Click
   //            FaturaKayitIslemleri.faturaGirisDVO giris = new FaturaKayitIslemleri.faturaGirisDVO();
//            giris.faturaRefNo = "444";
//            giris.faturaTarihi = "29.08.2013";
//            giris.hastaBasvuruNo = "B_101210";
//            giris.saglikTesisKodu = 1111;

            // HastaKabulIslemleri.BasvuruTakipOkuCevapDVO cevap = HastaKabulIslemleri.RemoteMethods.basvuruTakipOkuS(TTObjectClasses.Sites.SiteLocalHost, basvuruTakipOkuDVO);

            //FaturaKayitIslemleri.RemoteMethods.faturaKayitASync(TTObjectClasses.Sites.SiteLocalHost, giris, new TestWebCaller());
#endregion ErecetegirisForm_faturaKaydet_Click
        }

        private void ttbutton4_Click()
        {
#region ErecetegirisForm_ttbutton4_Click
   //
//   HastaKabulIslemleri.TakipOkuGirisDVO istek = new HastaKabulIslemleri.TakipOkuGirisDVO();
//            istek.saglikTesisKodu = 122;
//            istek.takipNo = "2";
//            istek.yeniTedaviTipi = 3;


//HizmetKayitIslemleri.hizmetKayitGirisDVO istek = new HizmetKayitIslemleri.hizmetKayitGirisDVO();
//istek.ameliyatveGirisimBilgileri=null;
//istek.digerIslemBilgileri=null;
//istek.disBilgileri=null;
//istek.hastaBasvuruNo="";
//istek.hastaYatisBilgileri=null;
//istek.ilacBilgileri=null;
//HizmetKayitIslemleri.RemoteMethods.hizmetKayitASync(TTObjectClasses.Sites.SiteLocalHost,istek, new TestWebCaller() );
    //HastaKabulIslemleri.RemoteMethods.hastaKabulOkuSync(TTObjectClasses.Sites.SiteLocalHost, istek);
#endregion ErecetegirisForm_ttbutton4_Click
        }

        private void ttbutton3_Click()
        {
#region ErecetegirisForm_ttbutton3_Click
   HastaKabulIslemleri.basvuruTakipOkuDVO basvuruTakipOkuDVO = new HastaKabulIslemleri.basvuruTakipOkuDVO();
            basvuruTakipOkuDVO.saglikTesisKodu = 1111;
            basvuruTakipOkuDVO.hastaBasvuruNo = "2223";

            // HastaKabulIslemleri.BasvuruTakipOkuCevapDVO cevap = HastaKabulIslemleri.RemoteMethods.basvuruTakipOkuS(TTObjectClasses.Sites.SiteLocalHost, basvuruTakipOkuDVO);

            //HastaKabulIslemleri.RemoteMethods.basvuruTakipOkuASync(TTObjectClasses.Sites.SiteLocalHost, basvuruTakipOkuDVO, new TestWebCaller());
#endregion ErecetegirisForm_ttbutton3_Click
        }

        private void ttbutton2_Click()
        {
#region ErecetegirisForm_ttbutton2_Click
   EReceteIslemleri.ereceteEhuOnayiIstekDVO istek2 = new EReceteIslemleri.ereceteEhuOnayiIstekDVO();

            EReceteIslemleri.ereceteEhuOnayiCevapDVO cevap = null;// = TTObjectClasses.EReceteIslemleri.RemoteMethods.ereceteEhuOnayi(Sites.SiteLocalHost, istek2, new TestWebCaller());
            InfoBox.Show("cevap geldi");
#endregion ErecetegirisForm_ttbutton2_Click
        }

        private void urunDogrula_Click()
        {
#region ErecetegirisForm_urunDogrula_Click
   //ITSUrunDogrulamaServis.UrunDogrulamaBildirimType istek = new ITSUrunDogrulamaServis.UrunDogrulamaBildirimType();
   //         istek.DT = "";
   //         istek.FR = "";
   //         istek.URUNLER = null;
   //         //ITSUrunDogrulamaServis.UrunDogrulamaBildirimCevapType cevap = TTObjectClasses.ITSUrunDogrulamaServis.RemoteMethods.UrunDogrulamaBildir(Sites.SiteLocalHost, istek, new TestWebCaller());
   //         InfoBox.Show("cevap geldi");
#endregion ErecetegirisForm_urunDogrula_Click
        }

        private void ttbutton1_Click()
        {
#region ErecetegirisForm_ttbutton1_Click
   EReceteIslemleri.ereceteSorguIstekDVO istek2 = new EReceteIslemleri.ereceteSorguIstekDVO();
            istek2.tesisKodu = 11068891;
            istek2.ereceteNo = "123";
            istek2.doktorTcKimlikNo = 10000000000;//10000000000;

            EReceteIslemleri.ereceteSorguCevapDVO cevap = null;// TTObjectClasses.EReceteIslemleri.RemoteMethods.ereceteSorgula(Sites.SiteLocalHost, istek2, new TestWebCaller());
            InfoBox.Show("cevap geldi");
#endregion ErecetegirisForm_ttbutton1_Click
        }

        private void ttbtnEreceteOnay_Click()
        {
#region ErecetegirisForm_ttbtnEreceteOnay_Click
   EReceteIslemleri.ereceteSilIstekDVO istek2 = new EReceteIslemleri.ereceteSilIstekDVO();
            istek2.tesisKodu = 11068891;
            istek2.ereceteNo = "123";
            istek2.doktorTcKimlikNo = 10000000000;

            EReceteIslemleri.ereceteSilCevapDVO cevap = null;// TTObjectClasses.EReceteIslemleri.RemoteMethods.ereceteSil(Sites.SiteLocalHost, istek2);
            InfoBox.Show("cevap geldi");
#endregion ErecetegirisForm_ttbtnEreceteOnay_Click
        }

        private void EreceteGiris_Click()
        {
#region ErecetegirisForm_EreceteGiris_Click
   //   EReceteIslemleri.ereceteGirisIstekDVO istek2 = new EReceteIslemleri.ereceteGirisIstekDVO();
//            istek2.doktorTcKimlikNo = 0;
//            istek2.ereceteDVO = null;
//            istek2.tesisKodu = 11068891;
//            TTObjectClasses.EReceteIslemleri.RemoteMethods.ereceteGiris(Sites.SiteLocalHost, istek2, new TestWebCaller());
//            MessageBox.Show("cevap geldi");
#endregion ErecetegirisForm_EreceteGiris_Click
        }

#region ErecetegirisForm_Methods
        [Serializable]
        public class TestWebCaller : IWebMethodCallback
        {
            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                    System.IO.File.AppendAllText("c:\\temp\\webmethodcalls.txt", returnValue.ToString());
                else
                    System.IO.File.AppendAllText("c:\\temp\\webmethodcalls.txt", "hello world");
                return false;
            }

            public TTObjectContext ObjectContext { get { return new TTObjectContext(false); } }
        }
        
#endregion ErecetegirisForm_Methods
    }
}