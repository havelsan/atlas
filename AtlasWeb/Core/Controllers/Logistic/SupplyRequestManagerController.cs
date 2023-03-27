using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using TTDataDictionary;
using System.Drawing;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using TTStorageManager;
using static TTObjectClasses.FsTasinirWebServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class SupplyRequestManagerController : Controller
    {
    

        public class QueryInput
        {
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public Guid storeObjID { get; set; }
        }


        // XXXXXXTasinirMal
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Satinalma_Yonetimi)]
        public SupplyRequestManagerViewModel GetStatusPurchese(QueryInput input)
        {
            SupplyRequestManagerViewModel model = new SupplyRequestManagerViewModel();
            List<SupplyRequestStatus> SupplyRequestStatusList = new List<SupplyRequestStatus>();

            string BolumId = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "");
            string ehipWsUsername = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI", "");
            string ehipWsPassword = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI", "");
            XXXXXXTasinirMal.IslemSonuc sonuc = XXXXXXTasinirMal.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, BolumId, ehipWsUsername, ehipWsPassword);

            TTObjectContext context = new TTObjectContext(false);
            BindingList<SupplyRequestPool> poolList = SupplyRequestPool.GetSupplyRequestPoolByDate(context, input.startDate, input.endDate, input.storeObjID);
            if (poolList.Count > 0)
            {
                foreach (SupplyRequestPool pool in poolList)
                {
                    SupplyRequestStatus st = new SupplyRequestStatus();
                    st.isImmediate = pool.IsImmediate != null ? (bool)pool.IsImmediate : false;

                    if (pool.SignUser != null)
                        st.requestedUser = pool.SignUser.Name;

                    st.stockActionDate = (DateTime)pool.TransactionDate;
                    st.stockActionID = pool.StockActionID.ToString();
                    st.XXXXXXKayitId = pool.XXXXXXKayitId.ToString();
                    XXXXXXTasinirMal.IslemSonuc talepSonuc = XXXXXXTasinirMal.WebMethods.TalepKontrolSync(Sites.SiteLocalHost, sonuc.Mesaj, pool.XXXXXXKayitId.ToString());
                    List<IslemSonuc> islemSonucs = new List<IslemSonuc>();
                    IslemSonuc islemSonuc = new IslemSonuc();
                    islemSonuc.etkilenenAdetField = talepSonuc.EtkilenenAdet;
                    islemSonuc.islemBasariliField = talepSonuc.IslemBasarili;
                    islemSonuc.kayitIDField = talepSonuc.KayitID;
                    islemSonuc.mesajField = talepSonuc.Mesaj;
                    islemSonucs.Add(islemSonuc);
                    st.islemSonucs = islemSonucs;
                    SupplyRequestStatusList.Add(st);
                }
            }
            model.SupplyRequestStatusList = SupplyRequestStatusList;
            return model;
        }



        //FastSoft
       [HttpPost]
       [AtlasRequiredRoles(TTRoleNames.Satinalma_Yonetimi)]
        public SupplyRequestManagerViewModel GetStatusPurcheseFastSoft(QueryInput input)
        {
            SupplyRequestManagerViewModel model = new SupplyRequestManagerViewModel();
            List<SupplyRequestStatusFastSoft> SupplyRequestStatusFastSoftList = new List<SupplyRequestStatusFastSoft>();

            string birim_ID = TTObjectClasses.SystemParameter.GetParameterValue("FASTSOFTBIRIMID", "");

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Guid siteID = Sites.SiteLocalHost;
                FsTasinirWebServis.MuayeneFaturaAramaKriterInfoWS AramaKriter = new FsTasinirWebServis.MuayeneFaturaAramaKriterInfoWS
                {
                    FaturaTarihiStart = input.startDate,
                    FaturaTarihiEnd = input.endDate
                };
                if (input.storeObjID != null && input.storeObjID != new Guid())
                {
                    Store store = (Store)objectContext.GetObject((Guid)input.storeObjID, typeof(Store));
                    //  AramaKriter.DepoTurId = todo
                }
                try
                {
                    MuayeneFaturaInfoWS[] MuayeneFaturaInfos = FsTasinirWebServis.WebMethods.MuayeneFaturaGetSync(siteID, "", "", birim_ID, AramaKriter);

                    List<string> invoiceNumbers = MuayeneFaturaInfos.Select(x => x.FaturaNo).ToList();
                    int listMaxSize = 900;
                    int loopCount = invoiceNumbers.Count() / listMaxSize;
                    List<ChattelDocumentWithPurchase.GetChattelDocumentWithPurchaseByInvoiceNumber_Class> results = new List<ChattelDocumentWithPurchase.GetChattelDocumentWithPurchaseByInvoiceNumber_Class>();
                    List<string> tmpInvoiceNumbers;
                    for (int i = 0; i <= loopCount; i++)
                    {
                        if (i < loopCount)
                            tmpInvoiceNumbers = invoiceNumbers.GetRange(i * listMaxSize, listMaxSize);
                        else
                            tmpInvoiceNumbers = invoiceNumbers.GetRange(i * listMaxSize, invoiceNumbers.Count() % listMaxSize);
                        results = results.Concat(ChattelDocumentWithPurchase.GetChattelDocumentWithPurchaseByInvoiceNumber(objectContext, tmpInvoiceNumbers)).ToList();
                    }
                    List<string> SavedChattelDocumentWithPurchaseInvoiceNumbers = results.Select(x => x.Waybill).ToList();
                    foreach (var MuayeneFaturaInfo in MuayeneFaturaInfos)
                    {
                        SupplyRequestStatusFastSoft st = new SupplyRequestStatusFastSoft
                        {
                            InvoiceNumber = MuayeneFaturaInfo.FaturaNo,
                            ActionDate = MuayeneFaturaInfo.IrsaliyeTarihi,
                            SupplierName = MuayeneFaturaInfo.FirmaAdi,
                            ItemCount = MuayeneFaturaInfo.MuayeneFaturaKalemList == null ? 0 : MuayeneFaturaInfo.MuayeneFaturaKalemList.Count(),
                            ItemInfos = new List<SupplyRequestStatusFastSoftItemInfo>(),
                            Status = SavedChattelDocumentWithPurchaseInvoiceNumbers.Contains(MuayeneFaturaInfo.FaturaNo) ? "Tamamlandı" : "Yeni"
                        };

                        if (MuayeneFaturaInfo.MuayeneFaturaKalemList != null)
                            foreach (var kalemdetay in MuayeneFaturaInfo.MuayeneFaturaKalemList)
                            {
                                SupplyRequestStatusFastSoftItemInfo itemInfo = new SupplyRequestStatusFastSoftItemInfo();
                                if (kalemdetay.Barkod != null)
                                {
                                    itemInfo.Barcode = kalemdetay.Barkod;
                                    itemInfo.MaterialName = kalemdetay.MalzemeAdi;
                                    itemInfo.Amount = kalemdetay.Miktar;
                                    itemInfo.Price = kalemdetay.Tutar;
                                }
                                st.ItemInfos.Add(itemInfo);
                            }
                        SupplyRequestStatusFastSoftList.Add(st);
                    }
                    model.SupplyRequestStatusFastSoftList = SupplyRequestStatusFastSoftList;
                    return model;
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }

            }
        }
    }
}
