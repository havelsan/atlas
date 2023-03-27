using System.Collections.Generic;
using System.Linq;
using Core.Models;
using TTInstanceManagement;
using System;
using TTObjectClasses;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class DisTaahhutFormController : Controller
    {
        public class OnInitOutputDVO
        {
            public List<DentalProsthesisDefinition> procedures { get; set; }
            public List<ActiveMedulaProvision> provisions { get; set; }
            public string txtTCKNo { get; set; }
            public string txtBirthDate { get; set; }
            public string txtSex { get; set; }
            public List<City> cities { get; set; }
            public AdressInfo addressInfo { get; set; }
        }
        public class ActiveMedulaProvision
        {
            public string TakipNo { get; set; }
            public string Brans { get; set; }
            public DateTime ProvisionDate { get; set; }
            public string BarsvuruNo { get; set; }
            public string ProtocolNo { get; set; }
            public DateTime OpenDate { get; set; }
            public string BransKodu { get; set; }
        }
        public class AddSut
        {
            public string sutKodu { get; set; }
            public string disNo { get; set; }
            public DentalProsthesisDefinition sutDef { get; set; }

        }
        public class SaveTaahhutOutputDVO
        {
            public bool işlemSonuc { get; set; }
            public string işlemSonucMesajı { get; set; }
            public string txtSonucKoduTaahhutKaydet { get; set; }
            public string txtSonucMesajiTaahhutKaydet { get; set; }
            public string txtAlınanTaahhutNo { get; set; }
            public DateTime? taahhutGonderimTarihi { get; set; }
        }
        public class SaveTaahhutInputDVO
        {
            public int adressIlPlaka { get; set; }
            public string adressIlce { get; set; }
            public string adressPostaKodu { get; set; }
            public string adressCaddeSokak { get; set; }
            public string adressDisKapiNo { get; set; }
            public string adressIcKapiNo { get; set; }
            public string adressTelefon { get; set; }
            public string adressEposta { get; set; }
            public string taahhutAlanAd { get; set; }
            public string taahhutAlanSoyad { get; set; }
            public string hastaTCKimlikNo { get; set; }
            public List<AddSut> suts { get; set; }
            public string activeMedulaProvision { get; set; }
        }
        public class ReadTaahhutTCOutputDVO
        {
            public bool işlemSonuc { get; set; }
            public string işlemSonucMesajı { get; set; }
            public string txtSonucKoduTCKimlikNoileSorgula { get; set; }
            public string txtSonucMesajTCKimlikNoileSorgula { get; set; }
            public List<Taahhut> taahhutler { get; set; }
        }
        public class Taahhut
        {
            public string taahhutNo { get; set; }
        }
        public class DeleteTaahhutOutputDVO
        {
            public bool işlemSonuc { get; set; }
            public string işlemSonucMesajı { get; set; }
            public string txtSonucKoduTaahhutSil { get; set; }
            public string txtSonucMesajiTaahhutSil { get; set; }
        }
        public class ReadTaahhutOutputDVO
        {
            public bool işlemSonuc { get; set; }
            public string işlemSonucMesajı { get; set; }
            public string txtSonucKoduTaahhutNoileSorgula { get; set; }
            public string txtSonucMesajiTaahhutNoileSorgula { get; set; }
        }

        public class AdressInfo
        {
            public City adressIl { get; set; }
            public TownDefinitions adressIlce { get; set; }
            public string adressPostaKodu { get; set; }
            public string adressCaddeSokak { get; set; }
            public string adressDisKapiNo { get; set; }
            public string adressIcKapiNo { get; set; }
            public string adressTelefon { get; set; }
            public string adressEposta { get; set; }
        }
        [HttpGet]
        public OnInitOutputDVO GetForm([FromQuery] string PatientObjectId)
        {
            OnInitOutputDVO output = new OnInitOutputDVO();
            List<DentalProsthesisDefinition> procedures = new List<DentalProsthesisDefinition>();
            List<ActiveMedulaProvision> provisions = new List<ActiveMedulaProvision>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                Patient patient = (Patient)objectContext.GetObject(new Guid(PatientObjectId), typeof(Patient));
                List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
                retList = patient.GetActiveSGKSEPs(null, null);
                foreach (SubEpisodeProtocol sep in retList)
                {
                    if (sep.MedulaTakipNo != null)
                    {
                        if (sep.Brans.Code == "5600" || sep.Brans.Code == "5300" || sep.Brans.Code == "5500" || sep.Brans.Code == "5150" || sep.Brans.Code == "5400" || sep.Brans.Code == "5700" || sep.Brans.Code == "5100")
                        {
                            ActiveMedulaProvision activeMedulaProvision = new ActiveMedulaProvision();
                            activeMedulaProvision.TakipNo = sep.MedulaTakipNo;
                            activeMedulaProvision.Brans = sep.Brans.Name_Shadow;
                            activeMedulaProvision.ProvisionDate = (DateTime)sep.MedulaProvizyonTarihi;
                            activeMedulaProvision.BarsvuruNo = sep.MedulaBasvuruNo;
                            activeMedulaProvision.ProtocolNo = sep.Episode.HospitalProtocolNo.ToString();
                            activeMedulaProvision.OpenDate = (DateTime)sep.Episode.OpeningDate;
                            activeMedulaProvision.BransKodu = sep.Brans.Code;
                            provisions.Add(activeMedulaProvision);
                        }
                    }
                }

                IBindingList dentalProcedures = objectContext.QueryObjects("DentalProsthesisDefinition", "ISACTIVE = 1", "NAME");
                foreach (DentalProsthesisDefinition p in dentalProcedures)
                    procedures.Add(p);

                List<City> cities = new List<City>();
                IBindingList iller = objectContext.QueryObjects("CITY", string.Empty, "NAME");
                foreach (City p in iller)
                    cities.Add(p);

                output.procedures = procedures;
                output.provisions = provisions;
                output.txtTCKNo = patient.UniqueRefNo.ToString();
                output.txtBirthDate = patient.BirthDate.ToString();
                output.txtSex = patient.Sex.ADI;
                output.cities = cities;

                if (patient.IsTrusted != null && patient.IsTrusted == true)
                {
                    output.addressInfo = new AdressInfo();

                    if (patient.PatientAddress != null && patient.PatientAddress.SKRSILKodlari != null)
                    {
                        City[] cityArray = City.GetCityDefinitionByCode(objectContext, patient.PatientAddress.SKRSILKodlari.KODU.ToString()).ToArray();
                        if (cityArray.Length > 0)
                            output.addressInfo.adressIl = cityArray[0];
                    }
                    if (patient.PatientAddress != null && patient.PatientAddress.SKRSIlceKodlari != null)
                    {
                        TownDefinitions[] townArray = TownDefinitions.GetTownDefinitionsByMernisCode(objectContext, patient.PatientAddress.SKRSIlceKodlari.KODU.ToString()).ToArray();
                        if (townArray.Length > 0)
                            output.addressInfo.adressIlce = townArray[0];
                    }
                 
                    output.addressInfo.adressPostaKodu = patient.PatientAddress.HomePostcode == null ? "" : patient.PatientAddress.HomePostcode;
                    output.addressInfo.adressDisKapiNo = patient.PatientAddress.DisKapi == null ? "" : patient.PatientAddress.DisKapi;
                    output.addressInfo.adressIcKapiNo = patient.PatientAddress.IcKapi == null ? "" : patient.PatientAddress.IcKapi;
                    output.addressInfo.adressTelefon = patient.PatientAddress.MobilePhone == null ? "" : patient.PatientAddress.MobilePhone;
                    output.addressInfo.adressEposta = patient.EMail == null ? "" : patient.EMail;
                }
      


                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }
        [HttpGet]
        public List<TownDefinitions> GetTowns([FromQuery] string CityObjectId)
        {
            List<TownDefinitions> output = new List<TownDefinitions>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                City city = (City)objectContext.GetObject(new Guid(CityObjectId), typeof(City));
                foreach (TownDefinitions town in city.Towns)
                    output.Add(town);
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }
        [HttpPost]
        public SaveTaahhutOutputDVO SaveTaahhut(SaveTaahhutInputDVO inputdvo)
        {
            SaveTaahhutOutputDVO output = new SaveTaahhutOutputDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TaahhutIslemleri.taahhutKayitDVO _taahhutKayitDVO = new TaahhutIslemleri.taahhutKayitDVO();
                _taahhutKayitDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                TaahhutIslemleri.taahhutDVO taahhutDVO = new TaahhutIslemleri.taahhutDVO();
                taahhutDVO.adressIlPlaka = inputdvo.adressIlPlaka;
                taahhutDVO.adressIlce = inputdvo.adressIlce;
                taahhutDVO.adressPostaKodu = inputdvo.adressPostaKodu;
                taahhutDVO.adressCaddeSokak = inputdvo.adressCaddeSokak;
                taahhutDVO.adressDisKapiNo = inputdvo.adressDisKapiNo;
                taahhutDVO.adressIcKapiNo = inputdvo.adressIcKapiNo;
                taahhutDVO.adressTelefon = inputdvo.adressTelefon;
                taahhutDVO.adressEposta = inputdvo.adressEposta;
                taahhutDVO.taahhutAlanAd = inputdvo.taahhutAlanAd;
                taahhutDVO.taahhutAlanSoyad = inputdvo.taahhutAlanSoyad;
                taahhutDVO.hastaTCKimlikNo = inputdvo.hastaTCKimlikNo;

                _taahhutKayitDVO.taahhut = taahhutDVO;
                List<TaahhutIslemleri.taahhutDisDVO> taahhutDisDVOList = new List<TaahhutIslemleri.taahhutDisDVO>();

                if (inputdvo.suts.Count > 0)
                {
                    foreach (AddSut s in inputdvo.suts)
                    {
                        TaahhutIslemleri.taahhutDisDVO taahhutDisDVO = new TaahhutIslemleri.taahhutDisDVO();
                        
                        DentalProsthesisDefinition sut = (DentalProsthesisDefinition)objectContext.AddObject(s.sutDef);
                        taahhutDisDVO.sutKodu = sut.Code;
                        taahhutDisDVO.disNo = Convert.ToInt32(s.disNo);
                        taahhutDisDVOList.Add(taahhutDisDVO);
                    }
                }

                _taahhutKayitDVO.taahhutDiss = taahhutDisDVOList.ToArray();

                if (inputdvo.activeMedulaProvision != null || inputdvo.activeMedulaProvision != "")
                    _taahhutKayitDVO.takipNo = inputdvo.activeMedulaProvision;
                else
                {
                    output.işlemSonuc = false;
                    output.işlemSonucMesajı = "Hastanın Bu Rapor İçin Geçerli Bir Branşta Takibi Bulunamamktadır ! ";
                }

                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                try
                {
                    TaahhutIslemleri.taahhutCevapDVO _taahhutCevapDVO = TaahhutIslemleri.WebMethods.disTaahhutKayit(siteID, _taahhutKayitDVO);

                    if (_taahhutCevapDVO != null)
                    {
                        if (string.IsNullOrEmpty(_taahhutCevapDVO.sonucKodu) == false)
                        {
                            output.txtSonucKoduTaahhutKaydet = _taahhutCevapDVO.sonucKodu;
                            if (_taahhutCevapDVO.sonucKodu.Equals("0000"))
                            {
                                output.işlemSonuc = true;
                                output.işlemSonucMesajı = " Hastanın taahhüt bilgilerini kaydetme işlemi başarılı şekilde yapıldı. Taahhüt No: " + _taahhutCevapDVO.taahhutNo.ToString();
                                output.txtSonucMesajiTaahhutKaydet = _taahhutCevapDVO.sonucMesaji;
                                output.txtAlınanTaahhutNo = _taahhutCevapDVO.taahhutNo.ToString();
                                output.taahhutGonderimTarihi = Common.RecTime();
                                //string uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Diş Taahhüt Raporu", "Kaydedilen diş taahhüt raporunun çıktısını almak ister misiniz?");
                                //if (uKey == "E")
                                //    this.PrintTaahhut(_taahhutCevapDVO);
                                //else
                                //    throw new Exception("İşlemden vazgeçildi.");

                            }
                            else
                            {
                                if (string.IsNullOrEmpty(_taahhutCevapDVO.sonucMesaji) == false)
                                {
                                    output.txtSonucMesajiTaahhutKaydet = _taahhutCevapDVO.sonucMesaji;
                                    output.işlemSonuc = false;
                                    output.işlemSonucMesajı = "Hastanın taahhüt bilgilerini kaydetme işleminde hata var.Hata Mesajı: " + _taahhutCevapDVO.sonucMesaji;
                                }
                                else
                                {
                                    output.işlemSonuc = false;
                                    output.işlemSonucMesajı = TTUtils.CultureService.GetText("M25852", "Hastanın taahhüt bilgilerini kaydetme işleminde hata var.Sonuç Mesajı boş!");
                                }
                            }
                        }
                        else
                        {
                            output.işlemSonuc = false;
                            output.işlemSonucMesajı = "Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.";
                        }
                    }
                    else
                    {
                        output.işlemSonuc = false;
                        output.işlemSonucMesajı = "Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.";
                    }
                }
                catch (Exception e)
                {
                    output.işlemSonuc = false;
                    output.işlemSonucMesajı = "Taahhüt Medulaya Gönderilirken Bir hata oluştu.";
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }
        [HttpGet]
        public ReadTaahhutTCOutputDVO ReadTaahhutTC([FromQuery] string TcNo)
        {
            ReadTaahhutTCOutputDVO output = new ReadTaahhutTCOutputDVO();
            List<Taahhut> taahhutler = new List<Taahhut>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TaahhutIslemleri.taahhutKisiOkuDVO _taahhutKisiOkuDVO = new TaahhutIslemleri.taahhutKisiOkuDVO();
                _taahhutKisiOkuDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _taahhutKisiOkuDVO.tcKimlikNo = (long)Convert.ToInt64(TcNo);
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                TaahhutIslemleri.taahhutKisiCevapDVO _taahhutKisiCevapDVO = TaahhutIslemleri.WebMethods.okuKisiDisTaahhut(siteID, _taahhutKisiOkuDVO);

                if (_taahhutKisiCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(_taahhutKisiCevapDVO.sonucKodu) == false)
                    {
                        output.txtSonucKoduTCKimlikNoileSorgula = _taahhutKisiCevapDVO.sonucKodu;
                        if (_taahhutKisiCevapDVO.sonucKodu.Equals("0000"))
                        {
                            output.işlemSonuc = true;
                            output.işlemSonucMesajı = _taahhutKisiOkuDVO.tcKimlikNo.ToString() + " TC Kimlik No'lu hastanın taahhütlerini sorgulama işlemi başarılı şekilde yapıldı.";
                            output.txtSonucMesajTCKimlikNoileSorgula = _taahhutKisiCevapDVO.sonucMesaji;
                            if (_taahhutKisiCevapDVO.taahhutNo != null)
                            {
                                for (int i = 0; i < _taahhutKisiCevapDVO.taahhutNo.Length; i++)
                                {
                                    Taahhut t = new Taahhut();
                                    t.taahhutNo = _taahhutKisiCevapDVO.taahhutNo[i].ToString();
                                    taahhutler.Add(t);
                                }
                                output.taahhutler = taahhutler;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(_taahhutKisiCevapDVO.sonucMesaji) == false)
                            {
                                output.txtSonucMesajTCKimlikNoileSorgula = _taahhutKisiCevapDVO.sonucMesaji;
                                output.işlemSonuc = false;
                                output.işlemSonucMesajı = "Hastaya ait taahhütlerinin okunması işleminde hata var.Hata Mesajı: " + _taahhutKisiCevapDVO.sonucMesaji;
                            }
                            else
                            {
                                output.txtSonucMesajTCKimlikNoileSorgula = _taahhutKisiCevapDVO.sonucMesaji;
                                output.işlemSonuc = false;
                                output.işlemSonucMesajı = TTUtils.CultureService.GetText("M25880", "Hastaya ait taahhütlerinin okunması işleminde hata var.Sonuç Mesajı boş!");
                            }
                        }
                    }
                    else
                    {
                        output.txtSonucMesajTCKimlikNoileSorgula = _taahhutKisiCevapDVO.sonucMesaji;
                        output.işlemSonuc = false;
                        output.işlemSonucMesajı = "Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.";
                    }
                }
                else
                {
                    output.txtSonucMesajTCKimlikNoileSorgula = _taahhutKisiCevapDVO.sonucMesaji;
                    output.işlemSonuc = false;
                    output.işlemSonucMesajı = "Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.";
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }
        [HttpGet]
        public DeleteTaahhutOutputDVO DeleteTaahhut([FromQuery] string TaahhutNo)
        {
            DeleteTaahhutOutputDVO output = new DeleteTaahhutOutputDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TaahhutIslemleri.taahhutOkuDVO _taahhutOkuDVO = new TaahhutIslemleri.taahhutOkuDVO();
                _taahhutOkuDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _taahhutOkuDVO.taahhutNo = Convert.ToInt32(TaahhutNo);
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                TaahhutIslemleri.taahhutCevapDVO _taahhutCevapDVO = TaahhutIslemleri.WebMethods.silDisTaahhut(siteID, _taahhutOkuDVO);

                if (_taahhutCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(_taahhutCevapDVO.sonucKodu) == false)
                    {
                        output.txtSonucKoduTaahhutSil = _taahhutCevapDVO.sonucKodu;
                        if (_taahhutCevapDVO.sonucKodu.Equals("0000"))
                        {
                            output.işlemSonuc = true;
                            output.işlemSonucMesajı = TTUtils.CultureService.GetText("M26968", "Taahhüt silme işlemi başarılı şekilde yapıldı.");
                            output.txtSonucMesajiTaahhutSil = _taahhutCevapDVO.sonucMesaji;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(_taahhutCevapDVO.sonucMesaji) == false)
                            {
                                output.işlemSonuc = false;
                                output.işlemSonucMesajı = "Hastaya ait girilen taahhütün silinmesi işleminde hata var.Hata Mesajı: " + _taahhutCevapDVO.sonucMesaji;
                                output.txtSonucMesajiTaahhutSil = _taahhutCevapDVO.sonucMesaji;
                            }
                            else
                            {
                                output.işlemSonuc = false;
                                output.işlemSonucMesajı = TTUtils.CultureService.GetText("M25878", "Hastaya ait girilen taahhütün silinmesi işleminde hata var.Sonuç Mesajı boş!");
                                output.txtSonucMesajiTaahhutSil = _taahhutCevapDVO.sonucMesaji;
                            }
                        }
                    }
                    else
                    {
                        output.işlemSonuc = false;
                        output.işlemSonucMesajı = "Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.";
                        output.txtSonucMesajiTaahhutSil = _taahhutCevapDVO.sonucMesaji;
                    }
                }
                else
                {
                    output.işlemSonuc = false;
                    output.işlemSonucMesajı = "Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.";
                    output.txtSonucMesajiTaahhutSil = _taahhutCevapDVO.sonucMesaji;
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }
        [HttpGet]
        public ReadTaahhutOutputDVO ReadTaahhut([FromQuery] string TaahhutNo)
        {
            ReadTaahhutOutputDVO output = new ReadTaahhutOutputDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TaahhutIslemleri.taahhutOkuDVO _taahhutOkuDVO = new TaahhutIslemleri.taahhutOkuDVO();
                _taahhutOkuDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _taahhutOkuDVO.taahhutNo = Convert.ToInt32(TaahhutNo);
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                TaahhutIslemleri.taahhutCevapDVO _taahhutCevapDVO = TaahhutIslemleri.WebMethods.okuDisTaahhut(siteID, _taahhutOkuDVO);

                if (_taahhutCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(_taahhutCevapDVO.sonucKodu) == false)
                    {
                        output.txtSonucKoduTaahhutNoileSorgula = _taahhutCevapDVO.sonucKodu;
                        if (_taahhutCevapDVO.sonucKodu.Equals("0000"))
                        {
                            output.işlemSonuc = true;
                            output.işlemSonucMesajı = "Taahhüt okunması işlemi başarılı şekilde yapıldı.Taahhüt Numarası: " + _taahhutCevapDVO.taahhutNo;
                            output.txtSonucMesajiTaahhutNoileSorgula = _taahhutCevapDVO.sonucMesaji;
                            //string uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Diş Taahhüt Raporu", "Sorgulanan diş taahhütün raporunun çıktısını almak ister misiniz?");
                            //if (uKey == "E")
                            //    this.PrintTaahhut(_taahhutCevapDVO);
                            //else
                            //    throw new Exception("İşlemden vazgeçildi.");

                        }
                        else
                        {
                            if (string.IsNullOrEmpty(_taahhutCevapDVO.sonucMesaji) == false)
                            {
                                output.işlemSonuc = false;
                                output.işlemSonucMesajı = "Hastaya ait girilen taahhütün okunması işleminde hata var.Hata Mesajı: " + _taahhutCevapDVO.sonucMesaji;
                                output.txtSonucMesajiTaahhutNoileSorgula = _taahhutCevapDVO.sonucMesaji;
                            }
                            else
                            {
                                output.işlemSonuc = false;
                                output.işlemSonucMesajı = TTUtils.CultureService.GetText("M25876", "Hastaya ait girilen taahhütün okunması işleminde hata var.Sonuç Mesajı boş!");
                            }
                        }
                    }
                    else
                    {
                        output.işlemSonuc = false;
                        output.işlemSonucMesajı = "Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.";
                    }
                }
                else
                {
                    output.işlemSonuc = false;
                    output.işlemSonucMesajı = "Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.";
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }
 
    }
}