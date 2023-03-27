
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
    public partial class WS_Test_Form : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton5.Click += new TTControlEventDelegate(ttbutton5_Click);
            ttbutton4.Click += new TTControlEventDelegate(ttbutton4_Click);
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton5.Click -= new TTControlEventDelegate(ttbutton5_Click);
            ttbutton4.Click -= new TTControlEventDelegate(ttbutton4_Click);
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton5_Click()
        {
#region WS_Test_Form_ttbutton5_Click
   /*TaahhutIslemleri.TaahhutKayitDVO istek2 = new TaahhutIslemleri.TaahhutKayitDVO();
            istek2.saglikTesisKodu=147852;
            istek2.taahhut= null;
            istek2.taahhutDiss = null;
            istek2.takipNo="";
           
           // TTObjectClasses.MernisServis.RemoteMethods.TCKimlikNoDogrula(Sites.SiteLocalHost, istek2, new TestWebCaller());
           TaahhutIslemleri.TaahhutCevapDVO c= TTObjectClasses.TaahhutIslemleri.RemoteMethods.disTaahhutKayit(Sites.SiteLocalHost, istek2);  */
#endregion WS_Test_Form_ttbutton5_Click
        }

        private void ttbutton4_Click()
        {
#region WS_Test_Form_ttbutton4_Click
   /*MernisServis.TCKimlikPaket  istek2 = new MernisServis.TCKimlikPaket();
            istek2.Ad="Ali";
            istek2.Soyad="Dede";
            istek2.DogumYili=1098;
            istek2.TCKimlikNo=10000000000;
           
            TTObjectClasses.MernisServis.RemoteMethods.TCKimlikNoDogrula(Sites.SiteLocalHost, istek2, new TestWebCaller());*/
           //MernisServis.KPSServisSonucuKisiAdresBilgisi c = TTObjectClasses.MernisServis.RemoteMethods.TcKimlikNoIleAdresBilgisiSorgula(Sites.SiteLocalHost, 10000000000,false);
#endregion WS_Test_Form_ttbutton4_Click
        }

        private void ttbutton3_Click()
        {
#region WS_Test_Form_ttbutton3_Click
   //ITSStakeHolderServis.stakeholderRequest istek2 = new ITSStakeHolderServis.stakeholderRequest();

   //         //TTObjectClasses.ITSStakeHolderServis.RemoteMethods.CallStakeholder(Sites.SiteLocalHost, istek2, new TestWebCaller());
   //         InfoBox.Show("cevap geldi");
#endregion WS_Test_Form_ttbutton3_Click
        }

        private void ttbutton2_Click()
        {
#region WS_Test_Form_ttbutton2_Click
   //ITSUrunDogrulamaServis.UrunDogrulamaBildirimType istek2 = new ITSUrunDogrulamaServis.UrunDogrulamaBildirimType();
   //         istek2.DT   ="";
   //         istek2.FR ="";
   //         istek2.URUNLER=null;
            
   //         //TTObjectClasses.ITSUrunDogrulamaServis.RemoteMethods.UrunDogrulamaBildir(Sites.SiteLocalHost, istek2, new TestWebCaller());
   //         InfoBox.Show("cevap geldi");
#endregion WS_Test_Form_ttbutton2_Click
        }

        private void ttbutton1_Click()
        {
#region WS_Test_Form_ttbutton1_Click
   //ITSSarfBildirimServis.XXXXXXSarfType istek2 = new ITSSarfBildirimServis.XXXXXXSarfType();
   //         istek2.BELGE = null;
   //         istek2.DT="";
   //         istek2.FR="";
   //         istek2.ISACIKLAMA="";
   //         istek2.URUNLER=null;

   //         // TTObjectClasses.ITSSarfBildirimServis.RemoteMethods.XXXXXXSarfBildir(Sites.SiteLocalHost, istek2, new TestWebCaller());
   //         InfoBox.Show("cevap geldi");
#endregion WS_Test_Form_ttbutton1_Click
        }

#region WS_Test_Form_Methods
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
        
#endregion WS_Test_Form_Methods
    }
}