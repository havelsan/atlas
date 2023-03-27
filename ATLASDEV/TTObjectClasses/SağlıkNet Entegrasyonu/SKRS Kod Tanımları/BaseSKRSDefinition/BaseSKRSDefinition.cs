
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


using System.Threading;

namespace TTObjectClasses
{
    /// <summary>
    /// Farklı SKRS Kodlarının bağlı olduğu base
    /// </summary>
    public partial class BaseSKRSDefinition : TerminologyManagerDef
    {
        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            if (CanMatchByEnumValue() == true)
            {
                SKRSEnumMatchDefinition skrsEnumMatchDefinition = new SKRSEnumMatchDefinition(_objectContext);
                skrsEnumMatchDefinition.SKRSDefinitionObjectId = _objectDef.ID;
                skrsEnumMatchDefinition.SKRSDefinition = this;
            }
            #endregion PostInsert
        }

        #region Methods
        public static BaseSKRSDefinition GetByEnumValue(string SKRSObjectDefName, int enumValue)
        {
            Guid sKRSObjectDefinitionId = ((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs[SKRSObjectDefName]).ID;
            TTObjectContext objectContext = new TTObjectContext(true);
            var sKRSEnumMatchDefinitionList = SKRSEnumMatchDefinition.GetBySKRSDefObjectIdAndEnumValue(objectContext, sKRSObjectDefinitionId, enumValue, string.Empty);
            if (sKRSEnumMatchDefinitionList == null || sKRSEnumMatchDefinitionList.Count == 0)
            {
                var defaultSKRSDefinionList = BaseSKRSDefinition.GetDefaultBySKRSDefObjectId(objectContext, sKRSObjectDefinitionId);
                if (defaultSKRSDefinionList == null || defaultSKRSDefinionList.Count == 0)
                    return null;
                else
                    return (BaseSKRSDefinition)defaultSKRSDefinionList[0];

            }
            else
                return (BaseSKRSDefinition)sKRSEnumMatchDefinitionList[0].SKRSDefinition;

        }

        public static BaseSKRSDefinition GetMyDefault(string SKRSObjectDefName)
        {
            Guid sKRSObjectDefinitionId = ((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs[SKRSObjectDefName]).ID;
            TTObjectContext objectContext = new TTObjectContext(true);
            var defaultSKRSDefinionList = BaseSKRSDefinition.GetDefaultBySKRSDefObjectId(objectContext, sKRSObjectDefinitionId);
            if (defaultSKRSDefinionList != null && defaultSKRSDefinionList.Count > 0)
                return (BaseSKRSDefinition)defaultSKRSDefinionList[0];
            return null;
        }


        public virtual bool CanMatchByEnumValue()
        {
            return false;
        }
        /// <summary>
        /// Eski web servisle çalışan versiyon
        /// </summary>
        public static void RefreshSKRSSistemKodlari()
        {
            if (Logger.IsInitialized() == false)
                Logger.Initialize("SKRS", true);
            //try
            //{
            SKRSSistemlerServis.wsskrsSistemlerResponse service = SKRSSistemlerServis.WebMethods.SistemlerSync(TTObjectClasses.Sites.SiteLocalHost);
            if (service.hata == null)
            {
                TTObjectContext cnx = new TTObjectContext(false);
                foreach (var item in service.sistemler)
                {
                    if (item.aktif == true)
                    {
                        var skrsSistemKodlariList = SKRSSistemKodlari.GetBySKRSGuid(cnx, item.kodu);

                        if (skrsSistemKodlariList.Count == 0)
                        {
                            SKRSSistemKodlari skrsSistemKodlari = (SKRSSistemKodlari)cnx.CreateObject("SKRSSISTEMKODLARI");
                            skrsSistemKodlari.AKTIF = Convert.ToString(item.aktif);
                            skrsSistemKodlari.SKRSGuid = item.kodu;
                            skrsSistemKodlari.Adi = item.adi;
                            skrsSistemKodlari.SqlFilter = "KODU";
                        }
                    }
                    else
                    {
                        if (SKRSSistemKodlari.IsSKRSActive(item.kodu).Count == 0)//pasif yap
                        {
                            SKRSSistemKodlari skrsSistemKodlari = (SKRSSistemKodlari)cnx.GetObject(new Guid(item.kodu), "SKRSSISTEMKODLARI");
                            skrsSistemKodlari.AKTIF = Convert.ToString(item.aktif);
                        }
                    }
                }
                cnx.Save();
                cnx.Dispose();
            }
            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteException("Error in RefreshSKRSSistemKodlari", ex);
            //}
        }

        /// <summary>
        /// Yeni Rest Api servisle çalışan versiyon
        /// </summary>
        public static void RefreshSKRSSistemKodlariRest()
        {
            if (Logger.IsInitialized() == false)
                Logger.Initialize("SKRS", true);
            TTObjectContext cnx = new TTObjectContext(false);
            DateTime? lastUpdate = cnx.QueryObjects<SKRSSistemKodlari>("").Max(x => x.LastUpdate);
            if (lastUpdate == null)
                lastUpdate = Common.RecTime().AddYears(-1);
            SKRSSistemlerRest.GetSkrsListResponse service = SKRSSistemlerRest.WebMethods.GetSkrsListSync(TTObjectClasses.Sites.SiteLocalHost, lastUpdate.Value);

            if (service.durum == 1)
            {
                
                foreach (var item in service.sonuc)
                {
                    var skrsSistemKodlariList = SKRSSistemKodlari.GetBySKRSGuid(cnx, item.KODU);

                    if (skrsSistemKodlariList.Count == 0)
                    {
                        SKRSSistemKodlari skrsSistemKodlari = (SKRSSistemKodlari)cnx.CreateObject("SKRSSISTEMKODLARI");
                        skrsSistemKodlari.AKTIF = "True";
                        skrsSistemKodlari.SKRSGuid = item.KODU;
                        skrsSistemKodlari.Adi = item.ADI;
                        skrsSistemKodlari.SqlFilter = "KODU";
                    }
                    else
                    {
                        SKRSSistemKodlari skrsSistemKodlari = ((SKRSSistemKodlari)skrsSistemKodlariList[0]);
                        skrsSistemKodlari.Aciklama = item.ACIKLAMA;
                        skrsSistemKodlari.OlusturmaTarihi = item.OLUSTURULMATARIHI;
                        skrsSistemKodlari.GuncellemeTarihi = item.GUNCELLEMETARIHI;
                    }
                }
                cnx.Save();
                cnx.Dispose();
            }
            else
                Logger.WriteException("Error in RefreshSKRSSistemKodlariRest", new TTException(service.mesaj));
        }

        /// <summary>
        /// Eski web servisle çalışan versiyon
        /// </summary>
        public static void RefreshMaterialAktifForSkrs()
        {

            if (Logger.IsInitialized() == false)
                Logger.Initialize("SKRSMATERIALSTATUS", true);

            try
            {
                TTObjectContext sistemCnx = new TTObjectContext(true);
                var SKRSPasif = sistemCnx.QueryObjects<SKRSIlac>("");
                bool updateActiveOfDrugFromSKRS = SystemParameter.GetParameterValue("UPDATEACTIVEOFDRUGFROMSKRS", "FALSE").Equals("TRUE");
                foreach (SKRSIlac skrsItem in SKRSPasif)
                {
                    IBindingList materials = sistemCnx.QueryObjects("DRUGDEFINITION", "BARCODE = '" + skrsItem.BARKODU + "'");
                    foreach (Material material in materials)
                    {
                        /*if (skrsItem.IsActive != material.IsActive && updateActiveOfDrugFromSKRS)
                        {
                            TTObjectContext drugContext = new TTObjectContext(false);
                            DrugDefinition drug = (DrugDefinition)drugContext.GetObject(material.ObjectID, typeof(DrugDefinition));
                            drug.IsActive = skrsItem.IsActive;
                            drugContext.Save();
                            drugContext.Dispose();
                        }*/
                        if (skrsItem.GERIODEME != null)
                        {
                            TTObjectContext drugSgkPayContext = new TTObjectContext(false);
                            DrugDefinition drug = (DrugDefinition)drugSgkPayContext.GetObject(material.ObjectID, typeof(DrugDefinition));
                            drug.SgkReturnPay = skrsItem.GERIODEME == 1 ? true : false;
                            drugSgkPayContext.Save();
                            drugSgkPayContext.Dispose();
                        }
                    }
                }
                sistemCnx.Dispose();
            }
            catch (Exception ex)
            {
                Logger.WriteException("Error in RefreshMaterialAktifForSkrs : ", ex);
            }
        }

        /// <summary>
        /// Eski web servisle çalışan versiyon
        /// </summary>
        public static void RefreshSKRSTables()
        {
            //System.Diagnostics.Debugger.Break();
            if (Logger.IsInitialized() == false)
                Logger.Initialize("SKRS", true);

            bool errorOccured = false;

            try
            {
                TTObjectContext sistemCnx = new TTObjectContext(false);
                var lstSKRSSistemKodlari = sistemCnx.QueryObjects<SKRSSistemKodlari>("");
                Dictionary<string, SKRSSistemKodlari> dctSKRSSistemKodlari = new Dictionary<string, SKRSSistemKodlari>();
                foreach (var sysKod in lstSKRSSistemKodlari)
                    dctSKRSSistemKodlari.Add(sysKod.SKRSGuid, sysKod);

                //foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values.Where(x=>x.ObjectTableName.IndexOf("SKRSLOIN") >=0))
                foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values)
                {
                    if (objDef.IsOfType(typeof(BaseSKRSDefinition).Name.ToUpperInvariant()) && objDef.CodeName != "BaseSKRSDefinition" && objDef.CodeName != "BaseSKRSCommonDef" && objDef.CodeName != "TerminologyManagerDef")
                    {
                        try
                        {
                            SKRSSistemKodlari sysKod;
                            if (dctSKRSSistemKodlari.TryGetValue(objDef.Description, out sysKod))
                            {
                                if (sysKod.AKTIF == "True" && sysKod.LastUpdate.HasValue)
                                {
                                    if (sysKod.SqlFilter == null)
                                        throw new Exception(objDef.CodeName + " için SKRSSistemKodları, SQLFilter alanında PK tanımlı olmalıydı.");

                                    if (objDef.CodeName.ToUpperInvariant() == "SKRSLOINC" && DateTime.Now.Day != 1)  //SKRSLOINC i ayda 1 kere alsak ta yeter.
                                        continue;

                                    var dt = DateTime.Now.AddHours(-1).AddMinutes(-5); // Saatler geri alınır vs ve dakikalar tutmazsa...
                                    System.Diagnostics.Debug.WriteLine(objDef.CodeName);
                                    int counter = 100;
                                    SKRSSistemlerServis.kodDegerleriResponse response = null;

                                    string kurumNo = SystemParameter.GetParameterValue("SAGLIKNETKURUMKODU", "XXXXXX");
                                    while (counter > 0)
                                    {
                                        try
                                        {
                                            response = SKRSSistemlerServis.WebMethods.SistemKodlariSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, sysKod.LastUpdate.Value, true, kurumNo);
                                            counter = 0;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (ex.ToString().IndexOf("Unauthorized") >= 0 || ex.ToString().IndexOf("forcibly closed by the remote host") >= 0)
                                            {
                                                Thread.Sleep(5000);
                                                counter--;
                                            }
                                            else
                                                throw;
                                        }
                                    }
                                    string[] primaryKeys = sysKod.SqlFilter.Split(',');
                                    int sayac = 0;
                                    if (response.hata == null)
                                    {
                                        if (response.kodDegerleri.Length > 0)
                                        {
                                            System.Diagnostics.Debug.WriteLine(" " + response.kodDegerleri.Length + " rows");
                                            TTObjectContext cnx = new TTObjectContext(false);

                                            foreach (var satir in response.kodDegerleri)
                                            {
                                                sayac++;

                                                //if (sayac == 450)
                                                //{
                                                //    break;
                                                //}

                                                if (sayac % 100 == 0)
                                                {
                                                    System.Diagnostics.Debug.Write(".");
                                                }
                                                if (sayac % 10000 == 9999)
                                                {
                                                    System.Diagnostics.Debug.WriteLine("Intermediate saving...");
                                                    cnx.Save();
                                                    System.Diagnostics.Debug.WriteLine("Saved." + sayac);
                                                    cnx.Dispose();
                                                    cnx = new TTObjectContext(false);
                                                }
                                                TTObject tt = null;
                                                string filter = "";
                                                foreach (var cell in satir)
                                                {
                                                    for (int i = 0; i < primaryKeys.Length; i++)
                                                    {
                                                        if (Globals.CUCase(cell.kolonAdi, false, true) == Globals.CUCase(primaryKeys[i], false, true))
                                                        {
                                                            if (string.IsNullOrEmpty(filter) == false)
                                                                filter += " and ";
                                                            filter += Globals.CUCase(cell.kolonAdi, false, true) + " = '" + cell.kolonIcerigi.Value?.Replace("'", "''") + "'";
                                                        }
                                                    }
                                                }

                                                var ShouldOneObject = cnx.QueryObjects(objDef.Name, filter);
                                                if (ShouldOneObject.Count == 0)
                                                {
                                                    tt = cnx.CreateObject(objDef.Name);
                                                }
                                                else if (ShouldOneObject.Count == 1)
                                                {
                                                    tt = (TTObject)ShouldOneObject[0];
                                                }
                                                else
                                                {
                                                    var aktifcell = satir.Where(x => x.kolonAdi == "AKTIF").FirstOrDefault();
                                                    if (aktifcell != null)
                                                    {
                                                        filter += " and AKTIF = " + aktifcell.kolonIcerigi.Value;
                                                        ShouldOneObject = cnx.QueryObjects(objDef.Name, filter);
                                                        if (ShouldOneObject.Count == 0)
                                                        {
                                                            tt = cnx.CreateObject(objDef.Name);
                                                        }
                                                        else if (ShouldOneObject.Count == 1)
                                                        {
                                                            tt = (TTObject)ShouldOneObject[0];
                                                        }
                                                        else
                                                            throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26029", "için, filter '") + filter + "' ile birden çok veri gelmemeliydi. PK da hata var.");
                                                    }
                                                    else
                                                        throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26029", "için, filter '") + filter + "' ile birden çok veri gelmemeliydi. PK da hata var.");
                                                }

                                                if (tt["ISACTIVE"] == null)
                                                    tt["ISACTIVE"] = 1; //Set default to 1

                                                foreach (var cell in satir)
                                                {
                                                    TTObjectPropertyDef p;
                                                    var pname = cell.kolonAdi;
                                                    if (objDef.AllPropertyDefs.TryGetValue(Globals.CUCase(pname, false, true), out p) == true)
                                                    {
                                                        var deger = cell.kolonIcerigi.Value;
                                                        if (p.Name == "AKTIF")
                                                        {
                                                            if (string.IsNullOrEmpty(deger))
                                                                deger = "1";
                                                            else if (Globals.CUCase(deger, false, true) == "AKTIF")
                                                                deger = "1";
                                                            else if (deger.Trim() == "1")
                                                                deger = "1";
                                                            else
                                                                deger = "0";
                                                            tt["ISACTIVE"] = deger;
                                                        }
                                                        tt[p.Name] = deger;
                                                    }
                                                    else
                                                        throw new Exception(objDef.CodeName + "için, " + Globals.CUCase(pname, false, true) + " alanı bulunamadı.");
                                                }

                                            }
                                            System.Diagnostics.Debug.WriteLine("Saving.");
                                            cnx.Save();
                                            cnx.Dispose();
                                        }

                                        sysKod.LastUpdate = dt;
                                        sistemCnx.Save();
                                        System.Diagnostics.Debug.WriteLine("Saved.");
                                    }
                                    else if (response.hata.yerelHataKodu != "HS-19-0009" && response.hata.yerelHataKodu != "HS-19-0011")
                                        throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26026", "için SKRS den gelen hata :") + response.hata.yerelHataKodu + " " + response.hata.yerelHataAciklamasi);
                                }
                            }
                            else
                                throw new Exception(objDef.CodeName + " in description alanındaki SKRSID, SKRS ler içinde bulunamadı.");
                        }
                        catch (Exception ex)
                        {
                            errorOccured = true;
                            Logger.WriteException(objDef.CodeName + " için hata oluştu:", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorOccured = true;
                Logger.WriteException("Error in RefreshSKRSSistemKodlari : ", ex);
            }
            if (errorOccured)
                throw new Exception("Error occured in RefreshSKRSTables. See Eventlog for details.");
        }

        /// <summary>
        /// Yeni Rest Api servisle çalışan versiyon
        /// </summary>
        public static string RefreshSKRSTablesRest()
        {
            //System.Diagnostics.Debugger.Break();
            if (Logger.IsInitialized() == false)
                Logger.Initialize("SKRS", true);

            bool errorOccured = false;
            string log = string.Empty;

            try
            {
                TTObjectContext sistemCnx = new TTObjectContext(false);
                var lstSKRSSistemKodlari = sistemCnx.QueryObjects<SKRSSistemKodlari>("");
                Dictionary<string, SKRSSistemKodlari> dctSKRSSistemKodlari = new Dictionary<string, SKRSSistemKodlari>();
                foreach (var sysKod in lstSKRSSistemKodlari)
                    dctSKRSSistemKodlari.Add(sysKod.SKRSGuid, sysKod);

                //foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values.Where(x=>x.ObjectTableName.IndexOf("SKRSLOIN") >=0))
                foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values)
                {
                    if (objDef.IsOfType(typeof(BaseSKRSDefinition).Name.ToUpperInvariant()) &&
                        objDef.CodeName != "BaseSKRSDefinition"
                        && objDef.CodeName != "BaseSKRSCommonDef"
                        && objDef.CodeName != "TerminologyManagerDef"
                        //&& objDef.CodeName != "SKRSLOINC"
                        && objDef.CodeName != "SKRSOlayAfetBilgisi")
                    {
                        try
                        {
                            SKRSSistemKodlari sysKod;
                            if (dctSKRSSistemKodlari.TryGetValue(objDef.Description, out sysKod))
                            {
                                if (sysKod.AKTIF == "True" && sysKod.LastUpdate.HasValue)
                                {
                                    if (sysKod.SqlFilter == null)
                                        throw new Exception(objDef.CodeName + " için SKRSSistemKodları, SQLFilter alanında PK tanımlı olmalıydı.");

                                    RefreshSKRSObjects(objDef, sysKod, 1);
                                }
                            }
                            else
                                throw new Exception(objDef.CodeName + " in description alanındaki SKRSID, SKRS ler içinde bulunamadı.");
                        }
                        catch (Exception ex)
                        {
                            errorOccured = true;
                            Logger.WriteException(objDef.CodeName + " için hata oluştu:", ex);
                            log += objDef.CodeName + " için hata oluştu:" + ex.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorOccured = true;
                Logger.WriteException("Error in RefreshSKRSSistemKodlari : ", ex);
                log += "Error in RefreshSKRSSistemKodlari : " + ex.ToString();
            }
            finally
            {
                //if (errorOccured)
                //    throw new Exception("Error occured in RefreshSKRSTables. See Eventlog for details." + log);
            }
            return log;
        }

        public static void RefreshSKRSObjects(TTObjectDef objDef, SKRSSistemKodlari sysKod, int page)
        {

            TTObjectContext sistemCnx = new TTObjectContext(false);
            var lstSKRSSistemKodlari = sistemCnx.GetObject<SKRSSistemKodlari>(sysKod.ObjectID);
            var dt = DateTime.Now.AddHours(-1).AddMinutes(-5); // Saatler geri alınır vs ve dakikalar tutmazsa...
            System.Diagnostics.Debug.WriteLine(objDef.CodeName);
            int counter = 100;

            dynamic response = null;

            string kurumNo = SystemParameter.GetParameterValue("SAGLIKNETKURUMKODU", "XXXXXX");
            while (counter > 0)
            {
                try
                {
                    if(objDef.CodeName == "SKRSICD")
                        response = SKRSSistemlerRest.WebMethods.GetICD10Sync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSIlac")
                        response = SKRSSistemlerRest.WebMethods.GetSKRSIlacSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSLOINC" && DateTime.Now.Day == 1)
                        response = SKRSSistemlerRest.WebMethods.GetLOINCSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSKurumlar")
                        response = SKRSSistemlerRest.WebMethods.GetKurumSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSSUT")
                        response = SKRSSistemlerRest.WebMethods.GetSUTSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSASALHastalik")
                        response = SKRSSistemlerRest.WebMethods.GetASALHastalikSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSAsiTakvimi")
                        response = SKRSSistemlerRest.WebMethods.GetAsiTakvimiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSBebekIzlemTakvimi")
                        response = SKRSSistemlerRest.WebMethods.GetBebekIzlemTakvimiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSBucakKodlari")
                        response = SKRSSistemlerRest.WebMethods.GetBucakSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSCocukIzlemTakvimi")
                        response = SKRSSistemlerRest.WebMethods.GetCocukIzlemTakvimiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSEgitimKurumlari")
                        response = SKRSSistemlerRest.WebMethods.GetEgitimKurumlariSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSGebeIzlemTakvimi")
                        response = SKRSSistemlerRest.WebMethods.GetGebeIzlemTakvimiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSGETATUygulandigiDurumlar")
                        response = SKRSSistemlerRest.WebMethods.GetGETATUygulandigiDurumlarSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSGUNSONUOZETACIKLAMA")
                        response = SKRSSistemlerRest.WebMethods.GetGunSonuOzetAciklamaSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSICDOMORFOLOJIKODU")
                        response = SKRSSistemlerRest.WebMethods.GetICDOMorfolojiKoduSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSICDO")
                        response = SKRSSistemlerRest.WebMethods.GetICDOSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSICDMSVSIliskisi")
                        response = SKRSSistemlerRest.WebMethods.GetICD10MSVSIliskisiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSIlceKodlari")
                        response = SKRSSistemlerRest.WebMethods.GetIlceSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSKacinciLohusaIzlem")
                        response = SKRSSistemlerRest.WebMethods.GetKacinciLohusaIzlemSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSKoyKodlari")
                        response = SKRSSistemlerRest.WebMethods.GetKoySync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSMahalleKodlari")
                        response = SKRSSistemlerRest.WebMethods.GetMahalleSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSMeslekler")
                        response = SKRSSistemlerRest.WebMethods.GetMesleklerSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSMeslekHastaliklari")
                        response = SKRSSistemlerRest.WebMethods.GetMeslekHastaliklariSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSOkulCagiGenclikIzlemTakvimi")
                        response = SKRSSistemlerRest.WebMethods.GetOkulCagiGenclikIzlemTakvimiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSPersentil")
                        response = SKRSSistemlerRest.WebMethods.GetPersentilSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSSUTVS")
                        response = SKRSSistemlerRest.WebMethods.GetSKRSSUTVSSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSTELETIPKurumOnEkBilgileri")
                        response = SKRSSistemlerRest.WebMethods.GetTeletipKurumOnekBilgileriSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSTibbiBiyokimyaAkilciTestIstemiListesi")
                        response = SKRSSistemlerRest.WebMethods.GetTibbiBiyokimyaAkilciTestIstemiListesiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSTibbiIslemPuanBilgisi")
                        response = SKRSSistemlerRest.WebMethods.GetTibbiIslemPuanBilgisiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSUlkeKodlari")
                        response = SKRSSistemlerRest.WebMethods.GetUlkeSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else if (objDef.CodeName == "SKRSYasGruplari")
                        response = SKRSSistemlerRest.WebMethods.GetYasGruplariSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
                    else
                        response = SKRSSistemlerRest.WebMethods.GetSkrsObjectSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);

                    counter = 0;
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("Unauthorized") >= 0 || ex.ToString().IndexOf("forcibly closed by the remote host") >= 0)
                    {
                        Thread.Sleep(5000);
                        counter--;
                    }
                    else
                        throw;
                }
            }
            string[] primaryKeys = sysKod.SqlFilter.Split(',');
            int sayac = 0;
            if (response.durum == 1)
            {
                if (response.sonuc != null && response.sonuc.kayit != null && response.sonuc.kayit.Length > 0)
                {
                    int length = response.sonuc.kayit.Length;
                    int sonrakiSayfa = response.sonuc.sonrakiSayfa;
                    System.Diagnostics.Debug.WriteLine(" "
                        + length.ToString()
                        + " rows; page : "
                        + sonrakiSayfa.ToString());
                    TTObjectContext cnx = new TTObjectContext(false);

                    foreach (var satir in response.sonuc.kayit)
                    {
                        sayac++;

                        if (sayac % 100 == 0)
                        {
                            System.Diagnostics.Debug.Write(".");
                        }
                        if (sayac % 10000 == 9999)
                        {
                            System.Diagnostics.Debug.WriteLine("Intermediate saving...");
                            cnx.Save();
                            System.Diagnostics.Debug.WriteLine("Saved." + sayac);
                            cnx.Dispose();
                            cnx = new TTObjectContext(false);
                        }
                        TTObject tt = null;
                        string filter = "";
                        foreach (TTObjectPropertyDef cell in objDef.AllPropertyDefs)
                        {
                            for (int i = 0; i < primaryKeys.Length; i++)
                            {
                                if (Globals.CUCase(cell.Name, false, true) == Globals.CUCase(primaryKeys[i], false, true))
                                {
                                    if (string.IsNullOrEmpty(filter) == false)
                                        filter += " and ";
                                    filter += TTUtils.Globals.CUCase(cell.Name, false, true) + " = '" + response.sonuc.kayit[0].GetType().GetProperty(TTUtils.Globals.CUCase(cell.Name, false, true)).GetValue(satir).ToString().Replace("'", "''") + "'";
                                }
                            }
                        }

                        var ShouldOneObject = cnx.QueryObjects(objDef.Name, filter);
                        if (ShouldOneObject.Count == 0)
                        {
                            tt = cnx.CreateObject(objDef.Name);
                        }
                        else if (ShouldOneObject.Count == 1)
                        {
                            tt = (TTObject)ShouldOneObject[0];
                        }
                        else
                        {
                            bool hasAktifCell = false;
                            foreach (var property in response.sonuc.kayit[0].GetType().GetProperties())
                            {
                                if(Globals.CUCase(property.Name, false, true) == "AKTIF")
                                {
                                    hasAktifCell = true;
                                    filter += " and AKTIF = " + response.sonuc.kayit[0].GetType().GetProperty("AKTIF").GetValue(satir).ToString();
                                    ShouldOneObject = cnx.QueryObjects(objDef.Name, filter);
                                    if (ShouldOneObject.Count == 0)
                                    {
                                        tt = cnx.CreateObject(objDef.Name);
                                    }
                                    else if (ShouldOneObject.Count == 1)
                                    {
                                        tt = (TTObject)ShouldOneObject[0];
                                    }
                                    else
                                        throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26029", "için, filter '") + filter + "' ile birden çok veri gelmemeliydi. PK da hata var.");
                                }
                            }
                            
                            if(!hasAktifCell)
                                throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26029", "için, filter '") + filter + "' ile birden çok veri gelmemeliydi. PK da hata var.");
                        }

                        if (tt["ISACTIVE"] == null)
                            tt["ISACTIVE"] = 1; //Set default to 1

                        foreach (var cell in response.sonuc.kayit[0].GetType().GetProperties())
                        {
                            TTObjectPropertyDef p;
                            var pname = cell.Name;
                            if (objDef.AllPropertyDefs.TryGetValue(Globals.CUCase(pname, false, true), out p) == true)
                            {
                                var deger = response.sonuc.kayit[0].GetType().GetProperty(pname).GetValue(satir);
                                if (p.Name == "AKTIF")
                                {
                                    if (string.IsNullOrEmpty(deger.ToString()))
                                        deger = "1";
                                    else if (Globals.CUCase(deger.ToString(), false, true) == "AKTIF")
                                        deger = "1";
                                    else if (Globals.CUCase(deger.ToString(), false, true) == "TRUE")
                                        deger = "1";
                                    else if (deger.ToString().Trim() == "1")
                                        deger = "1";
                                    else
                                        deger = "0";
                                    tt["ISACTIVE"] = deger;
                                }
                                tt[p.Name] = deger;
                            }
                            else
                                throw new Exception(objDef.CodeName + " için, " + Globals.CUCase(pname, false, true) + " alanı bulunamadı.");
                        }

                    }
                    System.Diagnostics.Debug.WriteLine("Saving.");
                    cnx.Save();
                    cnx.Dispose();
                }

                sysKod.LastUpdate = dt;
                sistemCnx.Save();
                sistemCnx.Dispose();
                System.Diagnostics.Debug.WriteLine("Saved.");
                if (response.sonuc.sonrakiSayfa != 1)
                    RefreshSKRSObjects(objDef, sysKod, response.sonuc.sonrakiSayfa);
            }
            //else if (response.hata.yerelHataKodu != "HS-19-0009" && response.hata.yerelHataKodu != "HS-19-0011")
            else if (response.mesaj != null)
                throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26026", "için SKRS den gelen hata :") + response.mesaj);
            else
                throw new Exception(objDef.CodeName + " isimli SKRS nesnesinde hata alındı. SKRS servisinden hata mesajı gönderilmedi.");
        }

        
        /// <summary>
        /// webservisten dönen responseları loglamak için yazıldı.
        /// </summary>
        public static void RefreshSKRSTablesRestAll()
        {
            //System.Diagnostics.Debugger.Break();
            if (Logger.IsInitialized() == false)
                Logger.Initialize("SKRS", true);

            bool errorOccured = false;

            try
            {
                TTObjectContext sistemCnx = new TTObjectContext(false);
                var lstSKRSSistemKodlari = sistemCnx.QueryObjects<SKRSSistemKodlari>("");
                Dictionary<string, SKRSSistemKodlari> dctSKRSSistemKodlari = new Dictionary<string, SKRSSistemKodlari>();
                foreach (var sysKod in lstSKRSSistemKodlari)
                    dctSKRSSistemKodlari.Add(sysKod.SKRSGuid, sysKod);

                StringBuilder sb = new StringBuilder();
                


                //foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values.Where(x=>x.ObjectTableName.IndexOf("SKRSLOIN") >=0))
                foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values)
                {
                    if (objDef.IsOfType(typeof(BaseSKRSDefinition).Name.ToUpperInvariant()) &&
                        objDef.CodeName != "BaseSKRSDefinition"
                        && objDef.CodeName != "BaseSKRSCommonDef"
                        && objDef.CodeName != "TerminologyManagerDef")
                    {
                        try
                        {
                            SKRSSistemKodlari sysKod;
                            if (dctSKRSSistemKodlari.TryGetValue(objDef.Description, out sysKod))
                            {
                                if (sysKod.AKTIF == "True" && sysKod.LastUpdate.HasValue)
                                {
                                    if (sysKod.SqlFilter == null)
                                        throw new Exception(objDef.CodeName + " için SKRSSistemKodları, SQLFilter alanında PK tanımlı olmalıydı.");

                                    var dt = DateTime.Now.AddHours(-1).AddMinutes(-5); // Saatler geri alınır vs ve dakikalar tutmazsa...
                                    System.Diagnostics.Debug.WriteLine(objDef.CodeName);
                                    int counter = 100;

                                    SKRSSistemlerRest.GetSkrsObjectResponse response = null;

                                    //string skrskodlarSTR = "96184a9e-537c-4a70-8b3a-27a7a170355b,94f19f91-41ed-4bf7-beed-de14090172d9,c3dbbb53-3b59-06e1-e043-14031b0a9fe6,c3ea7995-3959-50f5-e043-14031b0aa6d4,c3ea8562-2875-5249-e043-14031b0a1764,822af824-4163-46f8-b028-3741259b8471,c3ea9144-3629-5377-e043-14031b0ae574,cfb749a9-c769-7414-e040-7c0a04165362,c3ea9c66-aada-54e5-e043-14031b0af497,f74b3dc6-d1dc-46d6-90b8-1a1f93e4fcaa,a0c4e5ed-0aca-4300-9978-df92d2974cb4,efff2f6f-5b5f-4ed3-b034-5b6336ee87c8,c3eaabad-8c4c-56ee-e043-14031b0a5530,a7de45ea-4792-4dda-8b43-3f26e856f62b,7b7a4434-2295-4512-91e7-d72c66ddfbb9,40220f50-1c9c-43c9-9bbd-45794d5cc7b2,fc24f548-c383-4855-be0b-0f1d23599bba,c3eab581-ae56-5807-e043-14031b0acb40,96184a9e-537c-4a70-8b3a-27a7a170355b,05d2b394-9c2b-4b2a-8a3a-8b5023187502,c3eac0b8-1aeb-5910-e043-14031b0a941d,186585bf-70b6-4db4-805e-22177714d12e,c3eade04-4f91-5dab-e043-14031b0ac9f9,39aef8d6-9b53-4b56-8c73-2f53b0599094,4733b4b6-b779-4b5d-adea-7cee1a934d25,8462635e-5253-4e7b-8010-6020fd1501df,c3eaea6c-3a71-5eb7-e043-14031b0af492,c3eaf407-b302-5fdd-e043-14031b0a2484,327b7e7e-c54b-469e-bbd4-40670324e1a6,c3eafda6-8064-6138-e043-14031b0a38cb,6fedbc09-c34f-4189-88b7-6c6f4798fcfc,c3eb0815-fe11-6223-e043-14031b0aef1e,c073f7bf-791f-40cf-8fd4-e7ac5e1683de,c3eb10bb-27b9-6344-e043-14031b0a5679,c9bdaced-ec0d-4520-9040-8691e06d710f,eeb835d8-18ab-4f86-9720-32be86df1eff,cee9ef3e-7b56-4a37-bf7b-67eb160033e8,77ff0441-e162-4e7f-8719-ebf34bb5c345,d650777a-3d4d-a259-e040-7c0a01167a83,c3eb21b9-4f9e-6538-e043-14031b0af8ec,c3eb2b86-0409-6623-e043-14031b0abf48";
                                    string skrskodlarSTR = "c3ea7995-3959-50f5-e043-14031b0aa6d4,c3ea8562-2875-5249-e043-14031b0a1764,c3ea9144-3629-5377-e043-14031b0ae574,c3ea9c66-aada-54e5-e043-14031b0af497,c3eaea6c-3a71-5eb7-e043-14031b0af492,fc24f548-c383-4855-be0b-0f1d23599bba,c3eaf407-b302-5fdd-e043-14031b0a2484,c3eb0815-fe11-6223-e043-14031b0aef1e,c3eb21b9-4f9e-6538-e043-14031b0af8ec,d650777a-3d4d-a259-e040-7c0a01167a83,f74b3dc6-d1dc-46d6-90b8-1a1f93e4fcaa,eeb835d8-18ab-4f86-9720-32be86df1eff,05d2b394-9c2b-4b2a-8a3a-8b5023187502,40220f50-1c9c-43c9-9bbd-45794d5cc7b2,94f19f91-41ed-4bf7-beed-de14090172d9";
                                    string[] skrskodlar = skrskodlarSTR.Split(',');
                                    string kurumNo = SystemParameter.GetParameterValue("SAGLIKNETKURUMKODU", "XXXXXX");
                                    while (counter > 0)
                                    {
                                        try
                                        {
                                            if(skrskodlar.Contains(objDef.Description))
                                                response = SKRSSistemlerRest.WebMethods.GetSkrsObjectSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, 1, sysKod.LastUpdate.Value.AddYears(-10));
                                            counter = 0;
                                        }
                                        catch (Exception ex)
                                        {
                                            if (ex.ToString().IndexOf("Unauthorized") >= 0 || ex.ToString().IndexOf("forcibly closed by the remote host") >= 0)
                                            {
                                                Thread.Sleep(5000);
                                                counter--;
                                            }
                                            else
                                                throw;
                                        }
                                    }                                   
                                }
                            }
                            else
                                throw new Exception(objDef.CodeName + " in description alanındaki SKRSID, SKRS ler içinde bulunamadı.");
                        }
                        catch (Exception ex)
                        {
                            errorOccured = true;
                            Logger.WriteException(objDef.CodeName + " için hata oluştu:", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorOccured = true;
                Logger.WriteException("Error in RefreshSKRSSistemKodlari : ", ex);
            }
            if (errorOccured)
                throw new Exception("Error occured in RefreshSKRSTables. See Eventlog for details.");
        }
        #endregion Methods

    }
}