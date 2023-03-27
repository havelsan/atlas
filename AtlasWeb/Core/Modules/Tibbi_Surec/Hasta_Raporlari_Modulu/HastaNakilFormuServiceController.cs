using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using TTDefinitionManagement;
using TTStorageManager.Security;
using System.Data.Common;
using TTConnectionManager;
using System.Data;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class HastaNakilFormuServiceController : Controller
    {
        [HttpGet]
        public HastaNakilFormuViewModel LoadHastaNakilFormuModel(string EpisodeActionID)
        {
            HastaNakilFormuViewModel model = new HastaNakilFormuViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(EpisodeActionID));
                SubEpisode subepisode = episodeAction.SubEpisode;
                Patient patient = subepisode.Episode.Patient;

                model.SubepisodeID = subepisode.ObjectID.ToString();
                model._NabizDurumu = "";
                BindingList<HastaNakilFormu> reportList = HastaNakilFormu.GetHastaNakilFormuBySubepisode(objectContext, subepisode.ObjectID);

                Person reportPerson = new Person();
                ResUser currentResUser = (ResUser)(TTUser.CurrentUser.UserObject);
                if (currentResUser.UserType == UserTypeEnum.Doctor || currentResUser.UserType == UserTypeEnum.Dentist || currentResUser.UserType == UserTypeEnum.InternDoctor)
                {
                    reportPerson = currentResUser.Person;
                }
                else
                {
                    reportPerson = episodeAction.ProcedureDoctor.Person;
                }

                if (reportList.Count > 0)
                {
                    HastaNakilFormu form = new HastaNakilFormu();
                    form = reportList[0];
                    model.IsNew = false;
                    model.ObjectID = form.ObjectID.ToString();
                    model.TalepEdildigiZaman = form.TalepEdildigiZaman;
                    model.NakilTalepEdenKlinik = form.TalepEdenKlinik != null ? form.TalepEdenKlinik.ObjectID : Guid.Empty;
                    model.NakilEdilmekIstenilenKlinik = form.NakilEdilmekIstenilenKlinik != null ? form.NakilEdilmekIstenilenKlinik.ObjectID : Guid.Empty;
                    model.HastaninBulunduguKlinik = form.HastaninBulunduguKlinik != null ? form.HastaninBulunduguKlinik.ObjectID : Guid.Empty;
                    model.KomutaKontrolMerkezi = form.KomutaKontrolMerkezi != null ? form.KomutaKontrolMerkezi.ObjectID : Guid.Empty;
                    model.NakilGerceklestirmeYolu = form.NakilGerceklestirmeYolu != null ? form.NakilGerceklestirmeYolu.ObjectID : Guid.Empty;
                    model.SevkNedeni = form.SevkNedeni != null ? form.SevkNedeni.ObjectID : Guid.Empty;
                    model.SevkNedeniAciklama = form.SevkNedeniAciklama;
                    model.KabulEdenKurumIli = form.KabulEdenKurumIli != null ? form.KabulEdenKurumIli.ObjectID : Guid.Empty;
                    model.KabulEdenKurum = form.KabulEdenKurum != null ? form.KabulEdenKurum.ObjectID : Guid.Empty;
                    model.NakilKabulEdenKlinik = form.NakilKabulEdenKlinik != null ? form.NakilKabulEdenKlinik.ObjectID : Guid.Empty;
                    model.HastaHukumluMu = form.HastaHukumDurum != null ? form.HastaHukumDurum.ObjectID : Guid.Empty;
                    model.AdliVakaMi = form.AdliVakaDurum != null ? form.AdliVakaDurum.ObjectID : Guid.Empty;
                    model.KanGrubu = form.KabnGrubu != null ? form.KabnGrubu.ObjectID : Guid.Empty;
                    model.NakilTipi = form.HastaNakilTipi != null ? form.HastaNakilTipi.ObjectID : Guid.Empty;
                    model.DoktorIhtiyaci = form.DoktorIhtiyacDurumu != null ? form.DoktorIhtiyacDurumu.ObjectID : Guid.Empty;
                    model.BransIhtiyaci = form.BransIhtiyaci != null ? form.BransIhtiyaci.ObjectID : Guid.Empty;
                    model.TeyitliVakaMi = form.TeyitliVakaDurumu != null ? form.TeyitliVakaDurumu.ObjectID : Guid.Empty;
                    model.SistolikKanBasinci = Convert.ToInt32(form.SistolikKanBasinci);
                    model.DiastolikKanBasinci = Convert.ToInt32(form.DiastolikKanBasinci);
                    model.Solunum = form.Solunum != null ? form.Solunum.ObjectID : Guid.Empty;
                    model.SolunumSayisi = Convert.ToInt32(form.SolunumSayisi);
                    model.SolunumIslemi = "";
                    model.SolunumIslemi = form.SolunumIslemi;
                    model.GlaskowKomaSkalasi = Convert.ToInt32(form.GlaskowKomaSkalasi);
                    model.Gozler = Convert.ToInt32(form.Gozler);
                    model.Triaj = form.TriajKodu != null ? form.TriajKodu.ObjectID : Guid.Empty;
                    model.Ates = form.Ates;
                    model.NabizSayisi = Convert.ToInt32(form.NabizSayisi);
                    model.Bilinc = form.Bilinc.ObjectID;
                    model.KanSekeri = Convert.ToInt32(form.KanSekeri);
                    model.Sozel = Convert.ToInt32(form.Sozel);
                    model.Motor = Convert.ToInt32(form.Motor);
                    model.VitalBulgular = form.VitalBulgular;
                    model.PatolojikMuayeneBilgileri = form.PatolojikMuayeneBilgileri;
                    model.NakilSirasindaIstenilenMedikalIslemler = form.IstenilenMedikalIslemler;
                    model.TetkikBilgileri = form.TetkikBilgileri;
                    model.YapilanMedikalIslemler = form.YapilanMedikalIslemler;
                    model.YapilmasiIstenilenMedikalIslemler = form.YapilacakMedikalIslemler;
                    model.NakilSirasindakiGereksinimler = form.Gereksinimler;
                    model.TransportMalzemesi = form.TransportMalzemesi != null ? form.TransportMalzemesi.ObjectID : Guid.Empty;
                    model.MalzemeSayisi = Convert.ToInt32(form.MalzemeSayisi);
                    model.HastaYakiniAdi = form.HastaYakiniAdi;
                    model.HastaYakiniSoyadi = form.HastaYakiniSoyadi;
                    model.HastaYakiniTel = form.HastaYakiniTel;
                    model.HastaYakiniAdres = form.HastaYakiniAdresi;
                    model.EpikrizeEkAciklama = form.EkAciklama;
                    model.HekimAdi = form.HekimAdi != null ? form.HekimAdi : reportPerson.Name;
                    model.HekimSoyadi = form.HekimSoyadi != null ? form.HekimSoyadi : reportPerson.Surname;
                    model.HekimTel = form.HekimTel != null ? form.HekimTel : reportPerson.MobilePhone;
                    model.HekimTC = form.HekimTC != null ? form.HekimTC : reportPerson.UniqueRefNo.ToString();
                    model.PersonelAdi = form.PersonelAdi;
                    model.PersonelSoyadi = form.PersonelSoyad;
                    model.PersonelTel = form.PersonelTel;

                    model.SevkTaniList = new List<DiagnosisAndProcedureBaseModel>();
                    foreach (var hastaTanilar in form.HastaNakilTanilar)
                    {
                        var diagnosedef = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, hastaTanilar.SKRSICD.KODU).FirstOrDefault();
                        DiagnosisAndProcedureBaseModel diagnoseModel = new DiagnosisAndProcedureBaseModel
                        {
                            Code = diagnosedef.Code,
                            Name = diagnosedef.Name,
                            ObjectID = diagnosedef.ObjectID
                        };
                        model.SevkTaniList.Add(diagnoseModel);
                    }

                    //Nabız Durumu

                    DbConnection dbConnection = ConnectionManager.CreateConnection();

                    dbConnection.Open();
                    try
                    {
                        string paramSql = "select count(*) as SUCCESSCOUNT from sendtoenabiz where internalobjectID = '"+ model.ObjectID + "' and status = 1";


                        DbCommand cmd = ConnectionManager.CreateCommand(paramSql, dbConnection);
                        DbDataAdapter adap = ConnectionManager.CreateDataAdapter(cmd);
                        DataSet ds = new DataSet("DataSet");
                        adap.Fill(ds);
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            //foreach (DataRow row in ds.Tables[0].Rows) //Kodu ve Değeri gelecek
                            //{
                                int successCount = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                                if (successCount > 0)
                                    model._NabizDurumu = "Nabız Gönderim Durumu: Başarılı";
                                else
                                    model._NabizDurumu = "Nabız Gönderim Durumu: Başarısız";


                            //}
                            
                        }
                       

                    }
                    catch (Exception ex) { }
                    finally
                    {
                        dbConnection.Close();
                        dbConnection.Dispose();
                    }

                }
                else
                {
                    model.IsNew = true;
                    model.ObjectID = String.Empty;
                    model.TalepEdildigiZaman = DateTime.Now;

                    model.HekimAdi = reportPerson.Name;
                    model.HekimSoyadi = reportPerson.Surname;
                    model.HekimTel = reportPerson.MobilePhone;
                    model.HekimTC = reportPerson.UniqueRefNo.ToString();

                    model.SevkTaniList = new List<DiagnosisAndProcedureBaseModel>();
                    var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, subepisode.ObjectID.ToString());
                    foreach (var diagnose in diagnosisList)
                    {
                        DiagnosisAndProcedureBaseModel diagnoseModel = new DiagnosisAndProcedureBaseModel
                        {
                            Code = diagnose.Diagnose.Code,
                            Name = diagnose.Diagnose.Name,
                            ObjectID = diagnose.Diagnose.ObjectID
                        };
                        model.SevkTaniList.Add(diagnoseModel);
                    }
                }
            }
            return model;
        }

        [HttpGet]
        public HastaNakilSKRSModel LoadHastaNakilSKRSModel(string EpisodeActionID)
        {
            HastaNakilSKRSModel model = new HastaNakilSKRSModel();
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(new Guid(EpisodeActionID));
                SubEpisode subepisode = episodeAction.SubEpisode;

                model.SKRSKlinikList = SKRSKlinikler.GetSKRSKlinikList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSNakilYoluList = SKRSNAKILYOLU.GetSKRSNakilYoluList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSSevkNedeniList = SKRSSEVKNEDENI.GetSKRSSevkNedeniList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSILKodlariList = SKRSILKodlari.GetSKRSIlKodlariList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSDurumList = SKRSDurum.GetSkrsDurumObj(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSKanGrubuList = SKRSKanGrubu.GetSKRSKanGrubuList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSHastaNakilTipiList = SKRSHastaNakilTipi.GetSKRSHastaNakilTipi(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSSolunumList = SKRSSOLUNUM.GetSKRSSolunumList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSTransportMalzemesiList = SKRSTRANSPORTMALZEMESI.GetSKRSTransportMalzemesiList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSTriajKoduList = SKRSTRIAJKODU.GetSKRSTriajKoduList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSBilincList = SKRSBilinc.GetSKRSBilincList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();
                model.SKRSPersonelBransList = SKRSPersonelBransKodu.GetSKRSPersonelBransList(objectContext, " WHERE THIS.AKTIF = 1 ").ToList();

                model.DoctorList = new List<DoctorInfo>();
                foreach (var userItem in ResUser.DoctorListObjectNQL(objectContext, ""))
                {
                    DoctorInfo doktor = new DoctorInfo
                    {
                        ObjectID = userItem.ObjectID,
                        NameSurname=userItem.Name,
                        Name = userItem.Person.Name,
                        Surname = userItem.Person.Surname,
                        Phone = userItem.Person.MobilePhone,
                        UniqueRefNo = userItem.Person.UniqueRefNo.ToString()
                    };
                    model.DoctorList.Add(doktor);
                }
            }
            return model;
        }

        [HttpPost]
        public void SaveHastaNakilFormuModel(HastaNakilFormuViewModel model)
        {

            using (var objectContext = new TTObjectContext(false))
            {
                HastaNakilFormu form = null;
                SubEpisode subepisode = objectContext.GetObject<SubEpisode>(new Guid(model.SubepisodeID));

                if (SKRSDurum.GetSkrsDurumObj(objectContext, "WHERE OBJECTID='" + model.TeyitliVakaMi.Value + "'").FirstOrDefault().KODU == "1")
                {
                    if (model.KabulEdenKurumIli == null)
                    {
                        throw new Exception("Kabul Eden Kurum İli alanı boş geçilemez");
                    }
                    else if (model.KabulEdenKurum == null)
                    {
                        throw new Exception("Kabul Eden Kurum alanı boş geçilemez");
                    }
                    else if (model.NakilKabulEdenKlinik == null)
                    {
                        throw new Exception("Nakli Kabul Eden Klinik alanı boş geçilemez");
                    }
                    else if (String.IsNullOrEmpty(model.PersonelAdi))
                    {
                        throw new Exception("Kabul Eden Personel Adı alanı boş geçilemez");
                    }
                    else if (String.IsNullOrEmpty(model.PersonelSoyadi))
                    {
                        throw new Exception("Kabul Eden Personel Soyadı alanı boş geçilemez");
                    }
                    else if (String.IsNullOrEmpty(model.PersonelTel))
                    {
                        throw new Exception("Kabul Eden Personel Telefon Numarası alanı boş geçilemez");
                    }
                }

                if (subepisode.Episode.Patient.Age > 18)
                {
                    if (model.SolunumSayisi == null)
                    {
                        throw new Exception("Yetişkin hasta için Solunum Sayısı alanı boş geçilemez");
                    }
                }

                if (model.IsNew == true)
                {
                    form = new HastaNakilFormu(objectContext);
                    form.SubEpisode = subepisode;
                }
                else
                {
                    form = objectContext.GetObject<HastaNakilFormu>(new Guid(model.ObjectID));
                }
                form.TalepEdildigiZaman = model.TalepEdildigiZaman;
                form.TalepEdenKlinik = model.NakilTalepEdenKlinik != null && model.NakilTalepEdenKlinik != Guid.Empty ? objectContext.GetObject<SKRSKlinikler>(model.NakilTalepEdenKlinik.Value) : null;
                form.NakilEdilmekIstenilenKlinik = model.NakilEdilmekIstenilenKlinik != null && model.NakilEdilmekIstenilenKlinik != Guid.Empty ? objectContext.GetObject<SKRSKlinikler>(model.NakilEdilmekIstenilenKlinik.Value) : null;
                form.HastaninBulunduguKlinik = model.HastaninBulunduguKlinik != null && model.HastaninBulunduguKlinik != Guid.Empty ? objectContext.GetObject<SKRSKlinikler>(model.HastaninBulunduguKlinik.Value) : null;
                form.KomutaKontrolMerkezi = model.KomutaKontrolMerkezi != null && model.KomutaKontrolMerkezi != Guid.Empty ? objectContext.GetObject<SKRSKurumlar>(model.KomutaKontrolMerkezi.Value) : null;
                form.NakilGerceklestirmeYolu = model.NakilGerceklestirmeYolu != null && model.NakilGerceklestirmeYolu != Guid.Empty ? objectContext.GetObject<SKRSNAKILYOLU>(model.NakilGerceklestirmeYolu.Value) : null;
                form.SevkNedeni = model.SevkNedeni != null && model.SevkNedeni != Guid.Empty ? objectContext.GetObject<SKRSSEVKNEDENI>(model.SevkNedeni.Value) : null;
                form.SevkNedeniAciklama = model.SevkNedeniAciklama;
                form.KabulEdenKurumIli = model.KabulEdenKurumIli != null && model.KabulEdenKurumIli != Guid.Empty ? objectContext.GetObject<SKRSILKodlari>(model.KabulEdenKurumIli.Value) : null;
                form.KabulEdenKurum = model.KabulEdenKurum != null && model.KabulEdenKurum != Guid.Empty ? objectContext.GetObject<SKRSKurumlar>(model.KabulEdenKurum.Value) : null;
                form.NakilKabulEdenKlinik = model.NakilKabulEdenKlinik != null && model.NakilKabulEdenKlinik != Guid.Empty ? objectContext.GetObject<SKRSKlinikler>(model.NakilKabulEdenKlinik.Value) : null;
                form.HastaHukumDurum = model.HastaHukumluMu != null && model.HastaHukumluMu != Guid.Empty ? objectContext.GetObject<SKRSDurum>(model.HastaHukumluMu.Value) : null;
                form.AdliVakaDurum = model.AdliVakaMi != null && model.AdliVakaMi != Guid.Empty ? objectContext.GetObject<SKRSDurum>(model.AdliVakaMi.Value) : null;
                form.KabnGrubu = model.KanGrubu != null && model.KanGrubu != Guid.Empty ? objectContext.GetObject<SKRSKanGrubu>(model.KanGrubu.Value) : null;
                form.HastaNakilTipi = model.NakilTipi != null && model.NakilTipi != Guid.Empty ? objectContext.GetObject<SKRSHastaNakilTipi>(model.NakilTipi.Value) : null;
                form.DoktorIhtiyacDurumu = model.DoktorIhtiyaci != null && model.DoktorIhtiyaci != Guid.Empty ? objectContext.GetObject<SKRSDurum>(model.DoktorIhtiyaci.Value) : null;
                form.BransIhtiyaci = model.BransIhtiyaci != null && model.BransIhtiyaci != Guid.Empty ? objectContext.GetObject<SKRSPersonelBransKodu>(model.BransIhtiyaci.Value) : null;
                form.TeyitliVakaDurumu = model.TeyitliVakaMi != null && model.TeyitliVakaMi != Guid.Empty ? objectContext.GetObject<SKRSDurum>(model.TeyitliVakaMi.Value) : null;
                form.SistolikKanBasinci = model.SistolikKanBasinci != null ? model.SistolikKanBasinci.ToString() : null;
                form.DiastolikKanBasinci = model.DiastolikKanBasinci.ToString();
                form.Solunum = model.Solunum != null && model.Solunum != Guid.Empty ? objectContext.GetObject<SKRSSOLUNUM>(model.Solunum.Value) : null;
                form.SolunumSayisi = model.SolunumSayisi.ToString();
                form.SolunumIslemi = model.SolunumIslemi.ToString();
                form.GlaskowKomaSkalasi = model.GlaskowKomaSkalasi.ToString();
                form.Gozler = model.Gozler.ToString();
                form.TriajKodu = model.Triaj != null && model.Triaj != Guid.Empty ? objectContext.GetObject<SKRSTRIAJKODU>(model.Triaj) : null;
                form.Ates = model.Ates;
                form.NabizSayisi = model.NabizSayisi.ToString();
                form.Bilinc = model.Bilinc != null && model.Bilinc != Guid.Empty ? objectContext.GetObject<SKRSBilinc>(model.Bilinc.Value) : null;
                form.KanSekeri = model.KanSekeri.ToString();
                form.Sozel = model.Sozel.ToString();
                form.Motor = model.Motor.ToString();
                form.VitalBulgular = model.VitalBulgular;
                form.PatolojikMuayeneBilgileri = model.PatolojikMuayeneBilgileri;
                form.IstenilenMedikalIslemler = model.NakilSirasindaIstenilenMedikalIslemler;
                form.TetkikBilgileri = model.TetkikBilgileri;
                form.YapilanMedikalIslemler = model.YapilanMedikalIslemler;
                form.YapilacakMedikalIslemler = model.YapilmasiIstenilenMedikalIslemler;
                form.Gereksinimler = model.NakilSirasindakiGereksinimler;
                form.TransportMalzemesi = model.TransportMalzemesi != null && model.TransportMalzemesi != Guid.Empty ? objectContext.GetObject<SKRSTRANSPORTMALZEMESI>(model.TransportMalzemesi.Value) : null;
                form.MalzemeSayisi = model.MalzemeSayisi.ToString();
                form.HastaYakiniAdi = model.HastaYakiniAdi;
                form.HastaYakiniSoyadi = model.HastaYakiniSoyadi;
                form.HastaYakiniTel = model.HastaYakiniTel;
                form.HastaYakiniAdresi = model.HastaYakiniAdres;
                form.EkAciklama = model.EpikrizeEkAciklama;
                form.HekimAdi = model.HekimAdi;
                form.HekimSoyadi = model.HekimSoyadi;
                form.HekimTel = model.HekimTel;
                form.HekimTC = model.HekimTC.ToString();
                form.PersonelAdi = model.PersonelAdi;
                form.PersonelSoyad = model.PersonelSoyadi;
                form.PersonelTel = model.PersonelTel;

                if (model.IsNew == true)
                {
                    foreach (var tanı in model.SevkTaniList)
                    {
                        HastaNakilTanilar tanilar = new HastaNakilTanilar(objectContext);
                        SKRSICD skrsIcd = SKRSICD.GetByKodu(objectContext, tanı.Code).FirstOrDefault();
                        tanilar.SKRSICD = skrsIcd;
                        tanilar.HastaNakilFormu = form;
                        form.HastaNakilTanilar.Add(tanilar);
                    }
                }
                else
                {
                    foreach (var hastaNakilTani in form.HastaNakilTanilar.Select(string.Empty))
                    {
                        HastaNakilTanilar tanilar = objectContext.GetObject<HastaNakilTanilar>(hastaNakilTani.ObjectID);
                        ((ITTObject)tanilar).Delete();
                    }
                    foreach (var tanı in model.SevkTaniList)
                    {
                        HastaNakilTanilar tanilar = new HastaNakilTanilar(objectContext);
                        SKRSICD skrsIcd = SKRSICD.GetByKodu(objectContext, tanı.Code).FirstOrDefault();
                        tanilar.SKRSICD = skrsIcd;
                        tanilar.HastaNakilFormu = form;
                        form.HastaNakilTanilar.Add(tanilar);
                    }
                }

                new SendToENabiz(objectContext, subepisode, form.ObjectID, form.ObjectDef.Name, "262", Common.RecTime());

                objectContext.Save();
            }
        }

        [HttpGet]
        public string SendFormToEnabiz(string ObjectID)
        {
            string _NabizDurumu = "";
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend262(ObjectID);

            DbConnection dbConnection = ConnectionManager.CreateConnection();

            dbConnection.Open();
            try
            {
                string paramSql = "select count(*) as SUCCESSCOUNT from sendtoenabiz where internalobjectID = '" + ObjectID + "' and status = 1";


                DbCommand cmd = ConnectionManager.CreateCommand(paramSql, dbConnection);
                DbDataAdapter adap = ConnectionManager.CreateDataAdapter(cmd);
                DataSet ds = new DataSet("DataSet");
                adap.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //foreach (DataRow row in ds.Tables[0].Rows) //Kodu ve Değeri gelecek
                    //{
                    int successCount = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                    if (successCount > 0)
                        _NabizDurumu = "Nabız Gönderim Durumu: Başarılı";
                    else
                        _NabizDurumu = "Nabız Gönderim Durumu: Başarısız";


                    //}

                }


            }
            catch (Exception ex) { }
            finally
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }

            return _NabizDurumu;


        }


            [HttpPost]
        public object GetKurumlarListDefinition([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var result = objectContext.QueryObjects<SKRSKurumlar>("ObjectID = '" + key + "'").ToList().Select(x => new SKRSKurumDTO { ObjectID = x.ObjectID, ADI = x.ADI, KODU = x.KODU }).FirstOrDefault();
                    return result;
                }
            }
            else
            {
                LoadResult result = null;

                string definitionName = loadOptions.Params.definitionName;
                string searchText = loadOptions.Params.searchText;
                string injectionFilter = loadOptions.Params.injectionFilter;
                using (var objectContext = new TTObjectContext(true))
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        searchText = "ADI like '%" + searchText.ToUpper() + "%'";
                        injectionFilter += " AND " + searchText;
                    }

                    TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKurumlar"].QueryDefs["GetSKRSKurumlar"];
                    Dictionary<string, object> paramList = new Dictionary<string, object>();
                    result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injectionFilter);
                }
                return result.GetData<SKRSKurumlar.GetSKRSKurumlar_Class>().Select(x => new SKRSKurumDTO { ObjectID = x.ObjectID, ADI = x.ADI, KODU = x.KODU });
            }
        }

        //[HttpGet]
        //public void DeleteDiagnose(string DiagnoseCode, string FormObjectID)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        HastaNakilFormu form = objectContext.GetObject<HastaNakilFormu>(new Guid(FormObjectID));

        //        HastaNakilTanilar tanilar = form.HastaNakilTanilar.Where(c => c.SKRSICD.KODU == DiagnoseCode).FirstOrDefault();
        //        ((ITTObject)tanilar).Delete();
        //    }
        //}
    }
}
