using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace Core.Controllers.CashOfficeFormView
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class CashOfficeFormViewApiController : Controller
    {
        [HttpGet]
        public CashOfficeFormViewModel InitCashOfficeForm()
        {
            CashOfficeFormViewModel model = new CashOfficeFormViewModel();
            model.CurrencyTypes = GetCurrencyTypes();
            GetDailyCurrencyValues();
            return model;
        }

        [HttpPost]
        public bool GetDailyCurrencyValues()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    XDocument xDocument = XDocument.Load("http://xxxxxx.com/kurlar/today.xml");
                    DateTime lastUpdateDate = Convert.ToDateTime(xDocument.Root.Attribute("Tarih").Value);

                    var rates = objectContext.QueryObjects<DailyRateDefinition>("RATEDATE = TODATE('" + lastUpdateDate.ToString("yyyy-MM-dd HH:mm:ss") + "')");

                    var kurbilgileri = from kurlar in xDocument.Descendants("Currency")
                                       select kurlar;

                    if (kurbilgileri != null && kurbilgileri.Count() > 0)
                    {
                        foreach (var kur in kurbilgileri)
                        {
                            string qref = kur.Attribute("CurrencyCode").Value.ToUpper();
                            var currencyType = objectContext.QueryObjects<CurrencyTypeDefinition>("QREF = '" + qref + "' AND ISACTIVE =1");
                            if (currencyType != null && currencyType.Count > 0)
                            {
                                bool isRateExists = false;
                                if (rates.Count > 0)
                                {
                                    isRateExists = rates.Any(x => x.CurrencyType.Qref == qref);
                                }
                                if (isRateExists == false)
                                {
                                    DailyRateDefinition dailyRateDefinition = new DailyRateDefinition(objectContext);
                                    dailyRateDefinition["CURRENCYRATETYPE"] = new Guid("1cd74eb8-92b5-454d-9fa6-cbbceed83544");
                                    dailyRateDefinition["CURRENCYTYPE"] = currencyType[0].ObjectID;
                                    dailyRateDefinition.RateDate = lastUpdateDate;
                                    int power = kur.Element("BanknoteBuying").Value.Length - 1 - kur.Element("BanknoteBuying").Value.IndexOf('.');
                                    int powerstart = kur.Element("BanknoteBuying").Value.Split('.')[0].Length;
                                    var price = Convert.ToDouble(kur.Element("BanknoteBuying").Value.Remove(powerstart, 1)) / Math.Pow(10, power);
                                    dailyRateDefinition.DailyRate = Math.Round(price, 4);
                                }
                            }
                        }

                    }

                    var rateTL = objectContext.QueryObjects<DailyRateDefinition>("CURRENCYTYPE.QREF ='TL'");
                    if (rateTL.Count == 0)
                    {
                        var currencyType = objectContext.QueryObjects<CurrencyTypeDefinition>("QREF = 'TL' AND ISACTIVE = 1");
                        if (currencyType.Count == 0)
                            throw new TTException("Bu döviz türne ait aktif bir tanım bulanamadı. Lütfen bilgi işlemi arayınız.");
                        DailyRateDefinition dailyRateDefinition = new DailyRateDefinition(objectContext);
                        dailyRateDefinition["CURRENCYRATETYPE"] = new Guid("1cd74eb8-92b5-454d-9fa6-cbbceed83544");
                        dailyRateDefinition["CURRENCYTYPE"] = currencyType[0].ObjectID;
                        dailyRateDefinition.RateDate = lastUpdateDate;
                        dailyRateDefinition.DailyRate = 1;
                    }
                    objectContext.Save();

                    return true;
                }

                catch
                {
                    return false;
                }
            }
        }

        [HttpGet]
        public object GetCurrencyValue(string qref)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {

                DataSourceLoadOptions loadOptions = new DataSourceLoadOptions();
                loadOptions.Skip = 0;
                loadOptions.Take = 10;

                CurrencyTypeDefinition selectedCurrencyType = null;

                var currencyType = objectContext.QueryObjects<CurrencyTypeDefinition>("QREF = '" + qref + "'");
                if (currencyType != null && currencyType.Count > 0)
                    selectedCurrencyType = currencyType[0];
                else
                    throw new TTException("Bu döviz türne ait aktif bir tanım bulanamadı. Lütfen bilgi işlemi arayınız.");

                LoadResult result = null;
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DailyRateDefinition"].QueryDefs["GetDailyRateDefinitions"];
                Dictionary<string, object> paramList = new Dictionary<string, object>();

                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, "CURRENCYTYPE = '" + selectedCurrencyType.ObjectID + "'", "RATEDATE DESC");
                var data = result.GetData<DailyRateDefinition.GetDailyRateDefinitions_Class>();
                if (data.Count == 0)
                    throw new TTException("Seçilen döviz türüne ait kur bilgisi bulunamadı.");
                return data.FirstOrDefault();
            }
        }

        public IEnumerable<CurrencyTypeDefinition> GetCurrencyTypes()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    return objectContext.QueryObjects<CurrencyTypeDefinition>("ISACTIVE = 1");
                }
                catch (Exception ex)
                {
                    throw new TTException(ex.Message);
                }
            }
        }

    }

    public class CashOfficeFormViewModel
    {
        public IEnumerable<CurrencyTypeDefinition> CurrencyTypes { get; set; }
    }
}
