using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTObjectClasses;

namespace Core.Controllers.Invoice.Helpers.HizmetKayit
{
    public class HizmetKayitGirisDVOWithList
    {
        /// <summary>
        /// Medulanın HizmetKayitGirisDVO nesnesindeki elemanlar diziydi(array) , diziye yeni bir eleman eklemek zor olduğundan dolayı böyle list elemanları olan ve HizmetKayitGirisDVO üreten bir sınıf tasarlandı.
        /// </summary>
        public HizmetKayitGirisDVOWithList()
        {
            ameliyatveGirisimBilgileri = new List<HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO>();
            digerIslemBilgileri = new List<HizmetKayitIslemleri.digerIslemBilgisiDVO>();
            disBilgileri = new List<HizmetKayitIslemleri.disBilgisiDVO>();
            ilacBilgileri = new List<HizmetKayitIslemleri.ilacBilgisiDVO>();
            kanBilgileri = new List<HizmetKayitIslemleri.kanBilgisiDVO>();
            konsultasyonBilgileri = new List<HizmetKayitIslemleri.konsultasyonBilgisiDVO>();
            malzemeBilgileri = new List<HizmetKayitIslemleri.malzemeBilgisiDVO>();
            tahlilBilgileri = new List<HizmetKayitIslemleri.tahlilBilgisiDVO>();
            tanilar = new List<HizmetKayitIslemleri.taniBilgisiDVO>();
            tetkikveRadyolojiBilgileri = new List<HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO>();
            hastaYatisBilgileri = new List<HizmetKayitIslemleri.hastaYatisBilgisiDVO>();
        }

        private TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO = new HizmetKayitIslemleri.hizmetKayitGirisDVO();
        public TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO HizmetKayitGirisDVO
        {
            get
            {
                return GetHizmetKayitGirisDVO();
            }
        }

        public List<HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO> ameliyatveGirisimBilgileri
        {
            get;
            set;
        }

        public string asaKodu
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.digerIslemBilgisiDVO> digerIslemBilgileri
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.disBilgisiDVO> disBilgileri
        {
            get;
            set;
        }

        public string hastaBasvuruNo
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.hastaYatisBilgisiDVO> hastaYatisBilgileri
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.ilacBilgisiDVO> ilacBilgileri
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.kanBilgisiDVO> kanBilgileri
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.konsultasyonBilgisiDVO> konsultasyonBilgileri
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.malzemeBilgisiDVO> malzemeBilgileri
        {
            get;
            set;
        }

        public HizmetKayitIslemleri.muayeneBilgisiDVO muayeneBilgisi
        {
            get;
            set;
        }

        public int saglikTesisKodu
        {
            get;
            set;
        }

        public string ktsHbysKodu
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.tahlilBilgisiDVO> tahlilBilgileri
        {
            get;
            set;
        }

        public string takipNo
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.taniBilgisiDVO> tanilar
        {
            get;
            set;
        }

        public List<HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO> tetkikveRadyolojiBilgileri
        {
            get;
            set;
        }

        public string triajBeyani
        {
            get;
            set;
        }

        public TedaviTuru TedaviTuru
        {
            get;
            set;
        }

        private int HizmetSayisiBul()
        {
            int result = 0;
            if (muayeneBilgisi != null)
                result = 1;
            if (ameliyatveGirisimBilgileri != null)
                result = result + ameliyatveGirisimBilgileri.Count;
            if (digerIslemBilgileri != null)
                result = result + digerIslemBilgileri.Count;
            if (disBilgileri != null)
                result = result + disBilgileri.Count;
            if (hastaYatisBilgileri != null)
                result = result + hastaYatisBilgileri.Count;
            if (ilacBilgileri != null)
                result = result + ilacBilgileri.Count;
            if (kanBilgileri != null)
                result = result + kanBilgileri.Count;
            if (konsultasyonBilgileri != null)
                result = result + konsultasyonBilgileri.Count;
            if (malzemeBilgileri != null)
                result = result + malzemeBilgileri.Count;
            if (tahlilBilgileri != null)
                result = result + tahlilBilgileri.Count;
            if (tanilar != null)
                result = result + tanilar.Count;
            if (tetkikveRadyolojiBilgileri != null)
                result = result + tetkikveRadyolojiBilgileri.Count;
            return result;
        }

        /// <summary>
        /// Medulaya gönderilecek olan hizmet sayısını ifade etmektedir.
        /// </summary>
        public int HizmetSayisi
        {
            get
            {
                return HizmetSayisiBul();
            }
        }

        /// <summary>
        /// XXXXXX'dan gelen DVO'nun tipi ile o işlemin tanımındaki Medula DVO tipinin karşılaştırılması yapılmakta.
        /// </summary>
        /// <param name = "objMedula">XXXXXX DVO Nesnesi</param>
        /// <param name = "actx">AccountTransaction Nesnesi</param>
        /// <returns>Kontrol sonucunun başarılı olup olmadığı</returns>
        public TTObjectClasses.SubEpisodeProtocol.MedulaResult DVOMedulaProcedureTypeKontrol(object objMedula, AccountTransaction actx)
        {
            TTObjectClasses.SubEpisodeProtocol.MedulaResult result = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            if (actx.SubActionProcedure != null && actx.SubActionProcedure.ProcedureObject != null && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != null)
            {
                if ((objMedula is TTObjectClasses.HizmetKayitIslemleri.muayeneBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.muayeneBilgisi) || (objMedula is TTObjectClasses.HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.ameliyatveGirisimBilgileri) || (objMedula is TTObjectClasses.HizmetKayitIslemleri.digerIslemBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.digerIslemBilgileri) || (objMedula is TTObjectClasses.HizmetKayitIslemleri.disBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.disBilgileri) || (objMedula is TTObjectClasses.HizmetKayitIslemleri.hastaYatisBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.hastaYatisBilgileri) || (objMedula is TTObjectClasses.HizmetKayitIslemleri.konsultasyonBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.konsultasyonBilgileri) || (objMedula is TTObjectClasses.HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri) || (objMedula is TTObjectClasses.HizmetKayitIslemleri.tahlilBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.tahlilBilgileri) || (objMedula is TTObjectClasses.HizmetKayitIslemleri.kanBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.kanBilgileri))
                {
                    result.SonucKodu = "AXXX1";
                    result.SonucMesaji = string.Format(" SutKodu:{0}  Gelen Nesne:{1}  Olması Gereken {2}  ", actx.ExternalCode, objMedula.GetType().Name, actx.SubActionProcedure.ProcedureObject.MedulaProcedureType.ToString());
                }
            }
            else if (actx.SubActionProcedure == null && actx.SubActionMaterial != null)
            {
                if (Utils.GetAccountTransactionType(actx) != "İLAÇ" && objMedula is TTObjectClasses.HizmetKayitIslemleri.ilacBilgisiDVO)
                {
                    result.SonucKodu = "AXXX2";
                    result.SonucMesaji = string.Format(" Kodu {0},  Gelen Nesne {1}, Olması Gereken MALZEME {2} ", actx.ExternalCode, objMedula.GetType().Name);
                }
                else if (Utils.GetAccountTransactionType(actx) != "MALZEME" && objMedula is TTObjectClasses.HizmetKayitIslemleri.malzemeBilgisiDVO)
                {
                    result.SonucKodu = "AXXX3";
                    result.SonucMesaji = string.Format(" Kodu {0},  Gelen Nesne {1}, Olması Gereken İLAÇ {2} ", actx.ExternalCode, objMedula.GetType().Name);
                }
            }

            return result;
        }

        /// <summary>
        /// Zorunlu alanların belirtildiği tanım ekranındaki değerlere göre nesne üzerinde kontrol yapılmakta ayrıca "BransKodu,İslemTarihi,DrTescilNo" gibi değerlerin boş  olarak medulaya gönderilmemesi için kontrol yapılmakta.
        /// </summary>
        /// <param name = "objMedula">Medulaya gönderilecek olan DVO nesnesi</param>
        /// <returns>Kontrol sonucunun başarılı olup olmadığı</returns>
        public TTObjectClasses.SubEpisodeProtocol.MedulaResult ZorunluAlanKontrolu(object objMedula)
        {
            TTObjectClasses.SubEpisodeProtocol.MedulaResult result = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            result.SonucKodu = "0000";
            if (objMedula != null)
            {
                TTInstanceManagement.TTObjectContext context = new TTInstanceManagement.TTObjectContext(true);
                string dvoTypeName = objMedula.GetType().FullName;
                BindingList<MedulaMustDVOPropertyDef> list = TTObjectClasses.MedulaMustDVOPropertyDef.GetMedulaMustDVOPropertiesByDVOName(context, dvoTypeName);
                foreach (MedulaMustDVOPropertyDef defItem in list)
                {
                    PropertyInfo propitem = objMedula.GetType().GetProperty(defItem.PropertyName);
                    object val = propitem.GetValue(objMedula, null);
                    if ((val == null || (propitem.GetType().FullName.IndexOf("String") > -1 && val.ToString().Equals(""))) && (defItem.TedaviTuru == null || defItem.TedaviTuru == this.TedaviTuru))
                    {
                        result.SonucKodu = "AXXXX";
                        result.SonucMesaji = dvoTypeName + "  " + defItem.PropertyName + " değeri boş olamaz!";
                    }
                }

                if (result.SonucKodu == "0000")
                {
                    foreach (PropertyInfo item in objMedula.GetType().GetProperties())
                    {
                        if (item.Name == "bransKodu")
                        {
                            string val = (string)item.GetValue(objMedula, null);
                            if (string.IsNullOrEmpty(val))
                            {
                                result.SonucKodu = "A0515";
                                result.SonucMesaji = TTUtils.CultureService.GetText("M25295", "Branş Kodu bilgisi boş olamaz!");
                            }
                        }
                        else if (item.Name == "islemTarihi")
                        {
                            string val = (string)item.GetValue(objMedula, null);
                            if (string.IsNullOrEmpty(val))
                            {
                                result.SonucKodu = "A0720";
                                result.SonucMesaji = TTUtils.CultureService.GetText("M26214", "İşlem Tarihi bugünün tarihinden ileri bir tarih olamaz!");
                            }
                        }
                        else if (item.Name == "drTescilNo")
                        {
                            string val = (string)item.GetValue(objMedula, null);
                            if (string.IsNullOrEmpty(val))
                            {
                                result.SonucKodu = "A1176";
                                result.SonucMesaji = TTUtils.CultureService.GetText("M25527", "Doktor Tescil Numarası boş olamaz!");
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Medulaya gönderilecek olan HizmetKayitGirisDVO nesnesini oluşturan metot
        /// </summary>
        /// <returns>Medula Hizmet Kayıt Nesnesi</returns>
        private TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO GetHizmetKayitGirisDVO()
        {
            //hizmetKayitGirisDVO.asaKodu = this.asaKodu;
            hizmetKayitGirisDVO.hastaBasvuruNo = this.hastaBasvuruNo;
            hizmetKayitGirisDVO.muayeneBilgisi = this.muayeneBilgisi;
            hizmetKayitGirisDVO.saglikTesisKodu = this.saglikTesisKodu;
            hizmetKayitGirisDVO.ktsHbysKodu = this.ktsHbysKodu;
            hizmetKayitGirisDVO.takipNo = this.takipNo;
            hizmetKayitGirisDVO.triajBeyani = this.triajBeyani;

            if (ameliyatveGirisimBilgileri != null && ameliyatveGirisimBilgileri.Count > 0)
                hizmetKayitGirisDVO.ameliyatveGirisimBilgileri = ameliyatveGirisimBilgileri.ToArray();
            if (digerIslemBilgileri != null && digerIslemBilgileri.Count > 0)
                hizmetKayitGirisDVO.digerIslemBilgileri = digerIslemBilgileri.ToArray();
            if (disBilgileri != null && disBilgileri.Count > 0)
                hizmetKayitGirisDVO.disBilgileri = disBilgileri.ToArray();
            if (ilacBilgileri != null && ilacBilgileri.Count > 0)
                hizmetKayitGirisDVO.ilacBilgileri = ilacBilgileri.ToArray();
            if (kanBilgileri != null && kanBilgileri.Count > 0)
                hizmetKayitGirisDVO.kanBilgileri = kanBilgileri.ToArray();
            if (konsultasyonBilgileri != null && konsultasyonBilgileri.Count > 0)
                hizmetKayitGirisDVO.konsultasyonBilgileri = konsultasyonBilgileri.ToArray();
            if (malzemeBilgileri != null && malzemeBilgileri.Count > 0)
                hizmetKayitGirisDVO.malzemeBilgileri = malzemeBilgileri.ToArray();
            if (tahlilBilgileri != null && tahlilBilgileri.Count > 0)
                hizmetKayitGirisDVO.tahlilBilgileri = tahlilBilgileri.ToArray();
            if (tanilar != null && tanilar.Count > 0)
                hizmetKayitGirisDVO.tanilar = tanilar.ToArray();
            if (tetkikveRadyolojiBilgileri != null && tetkikveRadyolojiBilgileri.Count > 0)
                hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri = tetkikveRadyolojiBilgileri.ToArray();
            if (hastaYatisBilgileri != null && hastaYatisBilgileri.Count > 0)
                hizmetKayitGirisDVO.hastaYatisBilgileri = hastaYatisBilgileri.ToArray();

            return hizmetKayitGirisDVO;
        }
    }
}