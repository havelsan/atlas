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
    /// Tedarik Talepleri Havuzu
    /// </summary>
    public partial class SupplyRequestPool : StockAction
    {
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Satinalma_Talep_Havuz_Iptal, TTRoleNames.Satinalma_Talep_Havuz_Tamam)]
        public static string SendSupplyRequestPoolToXXXXXX_TS(SupplyRequestPool supplyRequestPool)
        {
            return supplyRequestPool.SendSupplyRequestPoolToXXXXXX(supplyRequestPool);
        }

#region Methods
        public string SendSupplyRequestPoolToXXXXXX(SupplyRequestPool supplyRequestPool)
        {
            string errorMessage = string.Empty;
            try
            {
                List<XXXXXXTasinirMal.TalepBildirimDetayInfoWS> detayList = new List<XXXXXXTasinirMal.TalepBildirimDetayInfoWS>();
                List<XXXXXXTasinirMal.VenStokInfo> infoReturnList;
                XXXXXXTasinirMal.VenStokAramaKriterInfo kr;
                XXXXXXTasinirMal.TalepBildirimInfoWS talep = new XXXXXXTasinirMal.TalepBildirimInfoWS();
                string BolumId = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "");
                string ehipWsUsername = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI", "");
                string ehipWsPassword = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI", "");
                XXXXXXTasinirMal.IslemSonuc sonuc = XXXXXXTasinirMal.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, BolumId, ehipWsUsername, ehipWsPassword);
                foreach (SupplyRequestPoolDetail detailPool in supplyRequestPool.SupplyRequestPoolDetails)
                {
                    kr = new XXXXXXTasinirMal.VenStokAramaKriterInfo();
                    kr.MalzemeKodu = detailPool.Material.StockCard.NATOStockNO;
                    infoReturnList = XXXXXXTasinirMal.WebMethods.GetStokListSync(Sites.SiteLocalHost, sonuc.Mesaj, kr).ToList();
                    if (infoReturnList.Count == 0)
                    {
                        errorMessage += detailPool.Material.Name + " , ";
                    }

                    if (infoReturnList.Count >= 1)
                    {
                        detailPool.RedimoStockCard = infoReturnList[0].RedimoStokkartId;
                        XXXXXXTasinirMal.TalepBildirimDetayInfoWS detay = new XXXXXXTasinirMal.TalepBildirimDetayInfoWS();
                        detay.Aciklama = detailPool.DetailDescription;
                        detay.MalzemeKayitId = infoReturnList[0].MalzemeKayitId;
                        detay.MkysOlcuBirimKodu = infoReturnList[0].OlcuBirimi;
                        detay.RedimoStokkartId = infoReturnList[0].RedimoStokkartId;
                        detay.TalepMiktar = (double)detailPool.PurchaseAmount;
                        detay.SutKodu = infoReturnList[0].SutKodu;
                        detayList.Add(detay);
                        infoReturnList = null;
                    }
                //TODO: SERVER KONTROLÜ OLMASIMI GEREKİYOR YOKSA CLIENTDAMI
                }

                talep.Aciklama = supplyRequestPool.Description;
                talep.TalepTurId = (XXXXXXTasinirMal.ETalepTur)Enum.Parse(typeof (XXXXXXTasinirMal.ETalepTur), ((int)(SupplyRequestTypeEnum)RequestType).ToString());
                talep.TalepNedeni = supplyRequestPool.Description;
                talep.Acil = supplyRequestPool.IsImmediate == null || supplyRequestPool.IsImmediate.Value == false ? 0 : 1;
                talep.MkysDepoKayitNo = ((MainStoreDefinition)(supplyRequestPool.Store)).StoreRecordNo.Value;
                talep.TalepKullaniciTC = long.Parse("10000000000"); //long.Parse(supplyRequestPool.SignUser.UniqueNo); //TODO geçici bir süreliğine direkt set edilecek.
                talep.TalepTarihi = DateTime.Now;
                talep.KarsilanmaTarihi = (DateTime)supplyRequestPool.DateOfSupply;
                talep.TalepEdenBirimAdi = supplyRequestPool.Store.Name;
                talep.TalepMalzemeListesi = detayList.ToArray();
                if (!String.IsNullOrEmpty(errorMessage))
                {
                    return errorMessage + " satınalma sisteminde stokKartı kaydı bulunamamıştır.\r\n";
                }

                XXXXXXTasinirMal.IslemSonuc islemSonucTalepBildirim = XXXXXXTasinirMal.WebMethods.TalepBildirSync(Sites.SiteLocalHost, sonuc.Mesaj, talep);
                supplyRequestPool.XXXXXXEtkilenenAdet = islemSonucTalepBildirim.EtkilenenAdet;
                supplyRequestPool.XXXXXXIslemBasarili = islemSonucTalepBildirim.IslemBasarili;
                supplyRequestPool.XXXXXXKayitId = islemSonucTalepBildirim.KayitID;
                supplyRequestPool.XXXXXXMesaj = islemSonucTalepBildirim.Mesaj;
                supplyRequestPool.ObjectContext.Save();
                return islemSonucTalepBildirim.Mesaj;
            }
            catch (Exception ex)
            {
                errorMessage += "\r\n" + ex.ToString();
                return errorMessage;
            }
        }
#endregion Methods
    }
}