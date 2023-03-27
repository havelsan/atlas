
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
    /// Olay Afet Bilgisini SKRS den �eker
    /// </summary>
    public partial class SKRSOlayAfetBilgisiGetir : BaseScheduledTask
    {
        public override void TaskScript()
        {
            GetSKRSOlayAfetBilgisi(1);
        }

        public void GetSKRSOlayAfetBilgisi(int page)
        {
            //System.Diagnostics.Debugger.Break();
            if (Logger.IsInitialized() == false)
                Logger.Initialize("SKRSOlayAfetBilgisi", true);

            bool errorOccured = false;
            string log = string.Empty;
            try
            {
                TTObjectContext sistemCnx = new TTObjectContext(false);
                var lstSKRSSistemKodlari = sistemCnx.QueryObjects<SKRSSistemKodlari>("");
                Dictionary<string, SKRSSistemKodlari> dctSKRSSistemKodlari = new Dictionary<string, SKRSSistemKodlari>();
                foreach (var sysKod in lstSKRSSistemKodlari)
                    dctSKRSSistemKodlari.Add(sysKod.SKRSGuid, sysKod);

                TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs.Values.FirstOrDefault(x => x.ObjectTableName == "SKRSOLAYAFETBILGISI");
                if (objDef == null)
                    throw new Exception("SKRSOLAYAFETBILGISI tablosu, SKRS ler i�inde bulunamad�.");

                try
                {
                    SKRSSistemKodlari sysKod;
                    if (dctSKRSSistemKodlari.TryGetValue(objDef.Description, out sysKod))
                    {
                        if (sysKod.AKTIF == "True" && sysKod.LastUpdate.HasValue)
                        {
                            if (sysKod.SqlFilter == null)
                                throw new Exception(objDef.CodeName + " i�in SKRSSistemKodlar�, SQLFilter alan�nda PK tan�ml� olmal�yd�.");

                            var dt = DateTime.Now.AddHours(-1).AddMinutes(-5); // Saatler geri al�n�r vs ve dakikalar tutmazsa...
                            System.Diagnostics.Debug.WriteLine(objDef.CodeName);
                            int counter = 100;
                            SKRSSistemlerRest.GetOlayAfetBilgisiResponse response = null;

                            string kurumNo = SystemParameter.GetParameterValue("SAGLIKNETKURUMKODU", "XXXXXX");
                            while (counter > 0)
                            {
                                try
                                {
                                    response = SKRSSistemlerRest.WebMethods.GetOlayAfetBilgisiSync(TTObjectClasses.Sites.SiteLocalHost, objDef.Description, page, sysKod.LastUpdate.Value);
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
                                                    filter += Globals.CUCase(cell.Name, false, true) + " = '" + typeof(SKRSSistemlerRest.SKRSOlayAfetBilgisi).GetProperty(Globals.CUCase(cell.Name, false, true)).GetValue(satir).ToString().Replace("'", "''") + "'";
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
                                            var aktifcell = typeof(SKRSSistemlerRest.SKRSOlayAfetBilgisi).GetProperties().Where(x => Globals.CUCase(x.Name, false, true) == "AKTIF").FirstOrDefault();
                                            if (aktifcell != null)
                                            {
                                                filter += " and AKTIF = " + typeof(SKRSSistemlerRest.SKRSOlayAfetBilgisi).GetProperty("AKTIF").GetValue(satir).ToString();
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
                                                    throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26029", "i�in, filter '") + filter + "' ile birden �ok veri gelmemeliydi. PK da hata var.");
                                            }
                                            else
                                                throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26029", "i�in, filter '") + filter + "' ile birden �ok veri gelmemeliydi. PK da hata var.");
                                        }

                                        if (tt["ISACTIVE"] == null)
                                            tt["ISACTIVE"] = 1; //Set default to 1

                                        foreach (var cell in typeof(SKRSSistemlerRest.SKRSOlayAfetBilgisi).GetProperties())
                                        {
                                            TTObjectPropertyDef p;
                                            var pname = cell.Name;
                                            if (objDef.AllPropertyDefs.TryGetValue(Globals.CUCase(pname, false, true), out p) == true)
                                            {
                                                var deger = typeof(SKRSSistemlerRest.SKRSOlayAfetBilgisi).GetProperty(pname).GetValue(satir);
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
                                                throw new Exception(objDef.CodeName + "i�in, " + Globals.CUCase(pname, false, true) + " alan� bulunamad�.");
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
                                    GetSKRSOlayAfetBilgisi(response.sonuc.sonrakiSayfa);
                            }
                            else if (response.mesaj != null)
                                throw new Exception(objDef.CodeName + TTUtils.CultureService.GetText("M26026", "i�in SKRS den gelen hata :") + response.mesaj);
                            else
                                throw new Exception(objDef.CodeName + " isimli SKRS nesnesinde hata al�nd�. SKRS servisinden hata mesaj� g�nderilmedi.");
                        }
                    }
                    else
                        throw new Exception(objDef.CodeName + " in description alan�ndaki SKRSID, SKRS ler i�inde bulunamad�.");
                }
                catch (Exception ex)
                {
                    errorOccured = true;
                    log += objDef.CodeName + " i�in hata olu�tu: " + ex.ToString();
                    //AddLog(log);
                    Logger.WriteException(objDef.CodeName + " i�in hata olu�tu:", ex);
                }

            }
            catch (Exception ex)
            {
                errorOccured = true;
                log += "Error in SKRSOlayAfetBilgisiGetir : " + ex.ToString();
                //AddLog(log);
                Logger.WriteException("Error in SKRSOlayAfetBilgisiGetir : ", ex);
            }
            finally
            {
                if (string.IsNullOrEmpty(log))
                    log = TTUtils.CultureService.GetText("M26698", "Planl� g�rev ba�ar�yla tamamlanm��t�r.");
                AddLog(log);
                if (errorOccured)
                    throw new Exception("Error occured in SKRSOlayAfetBilgisiGetir. See Eventlog for details.");
            }
        }
    }
}