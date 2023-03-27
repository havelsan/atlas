
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
using System.IO;

namespace TTFormClasses
{
    public partial class MKYSMaterialGetWebService : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            getUnitStore.Click += new TTControlEventDelegate(getUnitStore_Click);
            getMaterial.Click += new TTControlEventDelegate(getMaterial_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            getUnitStore.Click -= new TTControlEventDelegate(getUnitStore_Click);
            getMaterial.Click -= new TTControlEventDelegate(getMaterial_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region MKYSMaterialGetWebService_ttbutton1_Click
   try
            {
              //  this.Cursor = Cursors.WaitCursor;
                TTObjectClasses.MKYS_ServisDepo.AddMKYSServisDepo();
                InfoBox.Show("Kayıt Tamamlandı.");
            }
            
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
            finally
            {
               // this.Cursor = Cursors.Default;
            }
#endregion MKYSMaterialGetWebService_ttbutton1_Click
        }

        private void getUnitStore_Click()
        {
#region MKYSMaterialGetWebService_getUnitStore_Click
   try
            {
              //  this.Cursor = Cursors.WaitCursor;
                UnitStoreGetData.AddMKYSUnitStoreGetData();
                InfoBox.Show("Kayıt Tamamlandı.");
            }
            
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
            finally
            {
              //  this.Cursor = Cursors.Default;
            }
#endregion MKYSMaterialGetWebService_getUnitStore_Click
        }

        private void getMaterial_Click()
        {
            #region MKYSMaterialGetWebService_getMaterial_Click


            MkysServis.ihtiyacFazlasiKriterItem kriter = new MkysServis.ihtiyacFazlasiKriterItem();
            kriter.ilAdi = "XXXXXX";
           // kriter.malzemeAdi = "ZOLADEX DEPOT 10,8 MG (SUBKÜTAN İMPLANT)";
            kriter.malzemeKodu = "255-02-02-01-03";
           // kriter.birimAdi = "KIBRIS EĞİTİM VE ARAŞTIRMA XXXXXXSİ";

           MkysServis.ihtiyacFazlasiItem[] item = MkysServis.WebMethods.ihtiyacFazlasiGetDataSync(Sites.SiteLocalHost, kriter);
            StreamWriter sw = new StreamWriter(@"D:\\Deneme.txt", true);
            string st = "";
            foreach (MkysServis.ihtiyacFazlasiItem sinif in item)
            {
                st += sinif.birimAdi+"    "+sinif.adeti+"     "+sinif.ilAdi+"    "+sinif.malzemeAdi+"    "+sinif.malzemeKodu+"    "+sinif.vergiliBirimFiyat + sw.NewLine;
            }
            sw.WriteLine(st);
            sw.Close();



            //MkysServis.malzemeSiniflandirmaItem[] a = MkysServis.WebMethods.malzemeSiniflandirmaGetDataSync(Sites.SiteLocalHost, new DateTime(1900, 1, 1), MkysServis.EDepoTurId.medikalSarf);


            //MkysServis.malzemeItem[] k = MkysServis.WebMethods.malzemeGetDataSync(Sites.SiteLocalHost, new DateTime(1900, 1, 1));

            //StreamWriter sw = new StreamWriter(@"D:\\Deneme5.txt", true);
            //string st = "";
            //foreach (MkysServis.malzemeItem sinif in k)
            //{
            //    st += sinif.malzemeKodu + "     " + sinif.malzemeAdi + sw.NewLine;
            //}
            //sw.WriteLine(st);
            //sw.Close();
            //MalzemeGetData.malzemeSiniflandirmaGetData(new DateTime(1900, 1, 1), depoTuru);
            //   MalzemeGetData.AddMKYSMalzemeGetData(gunlemeTarihi.NullableValue.Value);


            InfoBox.Show("Malzemeler Güncellendi");
#endregion MKYSMaterialGetWebService_getMaterial_Click
        }
    }
}