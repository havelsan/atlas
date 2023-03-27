
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

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    /// <summary>
    /// Bu methot günde 1 kere akþam saatlerinde HBYSDepoEkleGuncelle  den sonra çalýþtýrýlmalý.
    /// </summary>
    public  partial class HBYSDepoDurumEkle : BaseScheduledTask
    {
        public override void TaskScript()
        {
            try
            {
                string birim_ID = TTObjectClasses.SystemParameter.GetParameterValue("FASTSOFTBIRIMID", "");
                Guid siteID = Sites.SiteLocalHost;
                FsTasinirWebServis.HBYSDepoDurumInfo HBYSDepoDurumInfo;
                FsTasinirWebServis.KayitSonuc kayitSonuc;

                //using (TTObjectContext objectContext = new TTObjectContext(false))
                //{
                //    List<Store> stores = Store.OLAP_Store(objectContext).ToList();

                //    HBYSDepoDurumInfo[] HBYSDepoDurumInfo;

                //    foreach (var store in stores)
                //    {
                //        if (store.ID != null)
                //        {
                //            HBYSDepoDurumInfo = new FsTasinirWebServis.HBYSDepoDurumInfo
                //            {
                //                MkysBirimId = (int)store.ID,
                //                HbysDepoId = (int)store.ID,
                //                MalzemeKayitId = store.Name,
                //                MalzemeAciklama =
                //                OlcuBirimi =
                //                StokMiktari = 
                //            };
                //            kayitSonuc = FsTasinirWebServis.WebMethods.HBYSDepoDurumEkleSync(siteID, "", "", birim_ID, HBYSDepoDurumInfo);
                //            if (!kayitSonuc.basariDurumu)
                //            {
                //                AddLog("Fastsoft’un otomatik HBYSDepoEkleGuncelle fonksiyonunda " + store.Name + "  deposunda beklenmedik bir hata oluþtu. Mesaj : " + kayitSonuc.mesaj);
                //            }
                //        }
                //    }
                //    AddLog("Fastsoft için otomatik HBYSDepoEkleGuncelle fonksiyonu " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + " gerçekleþti");
                //}
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }

        public override void AddLog(string log)
        {
            base.AddLog(log);
        }
    }
}