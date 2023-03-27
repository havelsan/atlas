
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
    /// SKRSLOINC Tablosunu Güncelleyen AutoScript
    /// </summary>
    public  partial class SKRSLOINCGuncelleme : BaseScheduledTask
    {
        public override void TaskScript()
        {
            SKRSLOINCGuncelle(1);
        }

        public void SKRSLOINCGuncelle(int page)
        {
            //System.Diagnostics.Debugger.Break();
            if (Logger.IsInitialized() == false)
                Logger.Initialize("SKRSLOINC", true);

            bool errorOccured = false;
            string log = string.Empty;
            try
            {
                TTObjectContext sistemCnx = new TTObjectContext(false);
                var lstSKRSSistemKodlari = sistemCnx.QueryObjects<SKRSSistemKodlari>("");
                Dictionary<string, SKRSSistemKodlari> dctSKRSSistemKodlari = new Dictionary<string, SKRSSistemKodlari>();
                foreach (var sysKod in lstSKRSSistemKodlari)
                    dctSKRSSistemKodlari.Add(sysKod.SKRSGuid, sysKod);

                TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs.Values.FirstOrDefault(x => x.ObjectTableName == "SKRSLOINC");
                if (objDef == null)
                    throw new Exception("SKRSLOINC tablosu, SKRS ler içinde bulunamadı.");

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
                            SKRSSistemlerRest.GetLOINCResponse response = null;

                            string kurumNo = SystemParameter.GetParameterValue("SAGLIKNETKURUMKODU", "XXXXXX");
                            while (counter > 0)
                            {
                                try
                                {
                                    response = SKRSSistemlerRest.WebMethods.GetLOINCSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
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
                                    System.Diagnostics.Debug.WriteLine(" " + response.sonuc.kayit.Length + " rows; page : " + response.sonuc.sonrakiSayfa.ToString());
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
                                                    filter += Globals.CUCase(cell.Name, false, true) + " = '" + typeof(SKRSSistemlerRest.SKRSLOINC).GetProperty(Globals.CUCase(cell.Name, false, true)).GetValue(satir).ToString().Replace("'", "''") + "'";
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
                                            var aktifcell = typeof(SKRSSistemlerRest.SKRSLOINC).GetProperties().Where(x => Globals.CUCase(x.Name, false, true) == "AKTIF").FirstOrDefault();
                                            if (aktifcell != null)
                                            {
                                                filter += " and AKTIF = " + typeof(SKRSSistemlerRest.SKRSLOINC).GetProperty("AKTIF").GetValue(satir).ToString();
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

                                        foreach (var cell in typeof(SKRSSistemlerRest.SKRSLOINC).GetProperties())
                                        {
                                            TTObjectPropertyDef p;
                                            var pname = cell.Name;
                                            if (objDef.AllPropertyDefs.TryGetValue(Globals.CUCase(pname, false, true), out p) == true)
                                            {
                                                var deger = typeof(SKRSSistemlerRest.SKRSLOINC).GetProperty(pname).GetValue(satir);
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
                                if (response.sonuc.sonrakiSayfa != 1)
                                    SKRSLOINCGuncelle(response.sonuc.sonrakiSayfa);
                            }
                            else if (response.mesaj != null)
                                throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26026", "için SKRS den gelen hata :") + response.mesaj);
                            else
                                throw new Exception(objDef.CodeName + " isimli SKRS nesnesinde hata alındı. SKRS servisinden hata mesajı gönderilmedi.");
                        }
                    }
                    else
                        throw new Exception(objDef.CodeName + " in description alanındaki SKRSID, SKRS ler içinde bulunamadı.");
                }
                catch (Exception ex)
                {
                    errorOccured = true;
                    log += objDef.CodeName + " için hata oluştu: " + ex.ToString();
                    //AddLog(log);
                    Logger.WriteException(objDef.CodeName + " için hata oluştu:", ex);
                }

            }
            catch (Exception ex)
            {
                errorOccured = true;
                log += "Error in SKRSLOINCGuncelle : " + ex.ToString();
                //AddLog(log);
                Logger.WriteException("Error in SKRSLOINCGuncelle : ", ex);
            }
            finally
            {
                if (string.IsNullOrEmpty(log))
                    log = TTUtils.CultureService.GetText("M26698", "Planlı görev başarıyla tamamlanmıştır.");
                AddLog(log);
                if (errorOccured)
                    throw new Exception("Error occured in SKRSLOINCGuncelle. See Eventlog for details.");
            }
        }
    }
}