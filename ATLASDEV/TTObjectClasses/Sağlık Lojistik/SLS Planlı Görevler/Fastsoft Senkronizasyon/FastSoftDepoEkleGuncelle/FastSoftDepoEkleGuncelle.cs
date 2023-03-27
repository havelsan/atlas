
using System;
using System.Linq;
using System.Collections.Generic;
using TTInstanceManagement;
namespace TTObjectClasses
{
    /// <summary>
    /// Bu methot günde 1 kere akþam saatlerinde çalýþtýrýlmalý
    /// </summary>
    public  partial class FastSoftDepoEkleGuncelle : BaseScheduledTask
    {
        public override void TaskScript()
        {
            try
            {
                string birim_ID = TTObjectClasses.SystemParameter.GetParameterValue("FASTSOFTBIRIMID", "");                
                Guid siteID = Sites.SiteLocalHost;
                FsTasinirWebServis.HbysDepoInfo HbysDepoInfo;
                FsTasinirWebServis.KayitSonuc kayitSonuc;

                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    List<Store> stores = Store.OLAP_Store(objectContext).Where(x => x.ID != null).ToList();

                    foreach (var store in stores)
                    {
                        HbysDepoInfo = new FsTasinirWebServis.HbysDepoInfo
                        {
                            HbysDepoId = (int)store.ID,
                            MkysBirimId = (int)store.ID,
                            DepoAdi = store.Name,

                            //1-> Cep Depo, 2-> Ana Depo
                            HbysDepoTuru = store is MainStoreDefinition ? 2 : 1,

                            //1-> Aktif, 0-> Pasif
                            Aktif = store.IsActive != null && store.IsActive.Value ? 1 : 0
                        };
                        kayitSonuc = FsTasinirWebServis.WebMethods.HBYSDepoEkleGuncelleSync(siteID, "", "", birim_ID, HbysDepoInfo);
                        if (!kayitSonuc.basariDurumu)
                        {
                            AddLog("Fastsoft’un otomatik HBYSDepoEkleGuncelle fonksiyonunda " + store.Name + "  deposunda beklenmedik bir hata oluþtu. Mesaj : " + kayitSonuc.mesaj);
                        }
                    }
                    AddLog("Fastsoft için otomatik HBYSDepoEkleGuncelle fonksiyonu " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + " gerçekleþti");
                }             
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