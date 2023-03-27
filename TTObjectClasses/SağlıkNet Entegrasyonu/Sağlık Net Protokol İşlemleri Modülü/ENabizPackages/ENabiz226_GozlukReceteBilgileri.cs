using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz226_GozlukReceteBilgileri
    {
        public class SYSSendMessage
        {
            public input input = new input();
        }
        public class input
        {
            public SYSMessage SYSMessage = new SYSMessage();
        }
        public class SYSMessage
        {
            public messageGuid messageGuid = new messageGuid();
            public messageType messageType = new messageType();

            public documentGenerationTime documentGenerationTime = new documentGenerationTime();
            public author author = new author();
            public firmaKodu firmaKodu = new firmaKodu();

            public recordData recordData = new recordData();

            public SYSMessage()
            {
                messageType.code = "226";
                messageType.value = TTUtils.CultureService.GetText("M25739", "Gözlük Reçete Bilgileri");
            }
        }
        public class healthcareProvider : CodeBase
        {
            public healthcareProvider()
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";

            }

            public healthcareProvider(string Code, string Value)
            {
                codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
                version = "1";
                code = Code;
                value = Value;

            }
        }
        public class recordData
        {
            public GOZLUK_RECETE_BILGILERI GOZLUK_RECETE_BILGILERI = new GOZLUK_RECETE_BILGILERI();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }

        public class GOZLUK_RECETE_BILGILERI
        {
            public GOZLUK_RECETE_TIPI GOZLUK_RECETE_TIPI;
            public RECETE_NUMARASI RECETE_NUMARASI;
            public RECETE_TARIHI RECETE_TARIHI;
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI;
            [System.Xml.Serialization.XmlElement("GOZLUK_BILGILERI", Type = typeof(GOZLUK_BILGILERI))]
            public List<GOZLUK_BILGILERI> GOZLUK_BILGILERI;
        }

        public class GOZLUK_BILGILERI
        {
            public GOZLUK_TURU GOZLUK_TURU;
            public SAG_CAM_BILGILERI SAG_CAM_BILGILERI;
            public SOL_CAM_BILGILERI SOL_CAM_BILGILERI;
            public SAG_LENS_BILGILERI SAG_LENS_BILGILERI;
            public SOL_LENS_BILGILERI SOL_LENS_BILGILERI;
            public SAG_KERATAKONUS_BILGILERI SAG_KERATAKONUS_BILGILERI;
            public SOL_KERATAKONUS_BILGILERI SOL_KERATAKONUS_BILGILERI;
            public TELESKOPIK_GOZLUK_BILGILERI TELESKOPIK_GOZLUK_BILGILERI;
        }

        public class SAG_CAM_BILGILERI
        {
            public CAM_TIPI CAM_TIPI;
            public CAM_RENGI CAM_RENGI;
            public CAM_SFERIK CAM_SFERIK;
            public CAM_SILINDIRIK CAM_SILINDIRIK;
            public CAM_AKS CAM_AKS;
        }
        public class SOL_CAM_BILGILERI
        {
            public CAM_TIPI CAM_TIPI;
            public CAM_RENGI CAM_RENGI;
            public CAM_SFERIK CAM_SFERIK;
            public CAM_SILINDIRIK CAM_SILINDIRIK;
            public CAM_AKS CAM_AKS;
        }
        public class SAG_LENS_BILGILERI
        {
            public CAM_SFERIK CAM_SFERIK;
            public CAM_SILINDIRIK CAM_SILINDIRIK;
            public CAM_AKS CAM_AKS;
            public CAM_CAP CAM_CAP;
            public CAM_EGIM CAM_EGIM;
            public CAM_LENS_SECIMI GECICI_MADDE;
        }
        public class SOL_LENS_BILGILERI
        {
            public CAM_SFERIK CAM_SFERIK;
            public CAM_SILINDIRIK CAM_SILINDIRIK;
            public CAM_AKS CAM_AKS;
            public CAM_CAP CAM_CAP;
            public CAM_EGIM CAM_EGIM;
            public CAM_LENS_SECIMI GECICI_MADDE;
        }
        public class SAG_KERATAKONUS_BILGILERI
        {
            public CAM_SFERIK CAM_SFERIK;
            public CAM_SILINDIRIK CAM_SILINDIRIK;
            public CAM_AKS CAM_AKS;
            public CAM_CAP CAM_CAP;
            public CAM_EGIM CAM_EGIM;
        }
        public class SOL_KERATAKONUS_BILGILERI
        {
            public CAM_SFERIK CAM_SFERIK;
            public CAM_SILINDIRIK CAM_SILINDIRIK;
            public CAM_AKS CAM_AKS;
            public CAM_CAP CAM_CAP;
            public CAM_EGIM CAM_EGIM;
        }

        public class TELESKOPIK_GOZLUK_BILGILERI
        {
            public TELESKOPIK_GOZLUK_TIPI TELESKOPIK_GOZLUK_TIPI;
            public TELESKOPIK_GOZLUK_TURU TELESKOPIK_GOZLUK_TURU;
            public CAM_LENS_SECIMI SAG_CAM;
            public CAM_LENS_SECIMI SOL_CAM;
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                GlassesReport gozlukRecetesi = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as GlassesReport;
                if (gozlukRecetesi == null)
                    throw new Exception("'226' paketini göndermek için " + InternalObjectId + " ObjectId'li GlassesReport Objesi bulunamadı.");

                recordData _recordData = new recordData();

                _recordData.GOZLUK_RECETE_BILGILERI.HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
                _recordData.GOZLUK_RECETE_BILGILERI.HEKIM_KIMLIK_NUMARASI.value = ((long)gozlukRecetesi.ProcedureDoctor.Person.UniqueRefNo).ToString();

                _recordData.GOZLUK_RECETE_BILGILERI.RECETE_NUMARASI = new RECETE_NUMARASI();
                _recordData.GOZLUK_RECETE_BILGILERI.RECETE_NUMARASI.value = gozlukRecetesi.EReceteNo;

                _recordData.GOZLUK_RECETE_BILGILERI.RECETE_TARIHI = new RECETE_TARIHI();
                _recordData.GOZLUK_RECETE_BILGILERI.RECETE_TARIHI.value = ((DateTime)gozlukRecetesi.ReportDate).ToString("yyyyMMddHHmm");

                _recordData.GOZLUK_RECETE_BILGILERI.GOZLUK_BILGILERI = new List<GOZLUK_BILGILERI>();

                if (gozlukRecetesi.PrescriptionType == GlassesPrescriptionTypeEnum.Normal)
                {
                    _recordData.GOZLUK_RECETE_BILGILERI.GOZLUK_RECETE_TIPI = new GOZLUK_RECETE_TIPI("1", "NORMAL");
                    if (gozlukRecetesi.VitrumFar == true)
                    {
                        GOZLUK_BILGILERI gozlukBilgisi = new GOZLUK_BILGILERI();
                        gozlukBilgisi.GOZLUK_TURU = new GOZLUK_TURU("1", "UZAK");
                        gozlukBilgisi.SAG_CAM_BILGILERI = new SAG_CAM_BILGILERI();

                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_SFERIK = new CAM_SFERIK();
                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_SFERIK.value = gozlukRecetesi.SphRightFar != null ? gozlukRecetesi.SphRightFar : "";

                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_SILINDIRIK = new CAM_SILINDIRIK();
                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_SILINDIRIK.value = gozlukRecetesi.CylRightFar != null ? gozlukRecetesi.CylRightFar : "";

                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_AKS = new CAM_AKS();
                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_AKS.value = gozlukRecetesi.AxRightFar != null ? gozlukRecetesi.AxRightFar : "";

                        if (gozlukRecetesi.GlassColorLeftFar == GlassColorEnum.Beyaz)
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_RENGI = new CAM_RENGI("2", "BEYAZ");
                        }
                        else if (gozlukRecetesi.GlassColorLeftFar == GlassColorEnum.Colormatik)
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_RENGI = new CAM_RENGI("1", "COLORMATİK");
                        }

                        if (gozlukRecetesi.GlassLeftTypeFar == GlassTypeEnum.Duz)
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("1", "DÜZ");
                        }
                        else if (gozlukRecetesi.GlassLeftTypeFar == GlassTypeEnum.Organik)
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("2", "ORGANİK");
                        }
                        else
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("3", "BİFOCAL-PROGRESİF");
                        }

                        gozlukBilgisi.SOL_CAM_BILGILERI = new SOL_CAM_BILGILERI();

                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_SFERIK = new CAM_SFERIK();
                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_SFERIK.value = gozlukRecetesi.SphLeftFar != null ? gozlukRecetesi.SphLeftFar : "";

                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_SILINDIRIK = new CAM_SILINDIRIK();
                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_SILINDIRIK.value = gozlukRecetesi.CylLeftFar != null ? gozlukRecetesi.CylLeftFar : "";

                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_AKS = new CAM_AKS();
                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_AKS.value = gozlukRecetesi.AxLeftFar != null ? gozlukRecetesi.AxLeftFar : "";

                        if (gozlukRecetesi.GlassColorLeftFar == GlassColorEnum.Beyaz)
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_RENGI = new CAM_RENGI("2", "BEYAZ");
                        }
                        else if (gozlukRecetesi.GlassColorLeftFar == GlassColorEnum.Colormatik)
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_RENGI = new CAM_RENGI("1", "COLORMATİK");
                        }

                        if (gozlukRecetesi.GlassLeftTypeFar == GlassTypeEnum.Duz)
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("1", "DÜZ");
                        }
                        else if (gozlukRecetesi.GlassLeftTypeFar == GlassTypeEnum.Organik)
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("2", "ORGANİK");
                        }
                        else
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("3", "BİFOCAL-PROGRESİF");
                        }

                        _recordData.GOZLUK_RECETE_BILGILERI.GOZLUK_BILGILERI.Add(gozlukBilgisi);
                    }
                    if (gozlukRecetesi.VitrumNear == true)
                    {
                        GOZLUK_BILGILERI gozlukBilgisi = new GOZLUK_BILGILERI();
                        gozlukBilgisi.GOZLUK_TURU = new GOZLUK_TURU("2", "YAKIN");
                        gozlukBilgisi.SAG_CAM_BILGILERI = new SAG_CAM_BILGILERI();

                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_SFERIK = new CAM_SFERIK();
                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_SFERIK.value = gozlukRecetesi.SphRightNear != null ? gozlukRecetesi.SphRightNear : "";

                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_SILINDIRIK = new CAM_SILINDIRIK();
                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_SILINDIRIK.value = gozlukRecetesi.CylRightNear != null ? gozlukRecetesi.CylRightNear : "";

                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_AKS = new CAM_AKS();
                        gozlukBilgisi.SAG_CAM_BILGILERI.CAM_AKS.value = gozlukRecetesi.AxRightNear != null ? gozlukRecetesi.AxRightNear : "";

                        if (gozlukRecetesi.GlassColorLeftNear == GlassColorEnum.Beyaz)
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_RENGI = new CAM_RENGI("2", "BEYAZ");
                        }
                        else if (gozlukRecetesi.GlassColorLeftNear == GlassColorEnum.Colormatik)
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_RENGI = new CAM_RENGI("1", "COLORMATİK");
                        }

                        if (gozlukRecetesi.GlassLeftTypeNear == GlassTypeEnum.Duz)
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("1", "DÜZ");
                        }
                        else if (gozlukRecetesi.GlassLeftTypeNear == GlassTypeEnum.Organik)
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("2", "ORGANİK");
                        }
                        else
                        {
                            gozlukBilgisi.SAG_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("3", "BİFOCAL-PROGRESİF");
                        }

                        gozlukBilgisi.SOL_CAM_BILGILERI = new SOL_CAM_BILGILERI();

                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_SFERIK = new CAM_SFERIK();
                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_SFERIK.value = gozlukRecetesi.SphLeftNear != null ? gozlukRecetesi.SphLeftNear : "";

                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_SILINDIRIK = new CAM_SILINDIRIK();
                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_SILINDIRIK.value = gozlukRecetesi.CylLeftNear != null ? gozlukRecetesi.CylLeftNear : "";

                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_AKS = new CAM_AKS();
                        gozlukBilgisi.SOL_CAM_BILGILERI.CAM_AKS.value = gozlukRecetesi.AxLeftNear != null ? gozlukRecetesi.AxLeftNear : "";

                        if (gozlukRecetesi.GlassColorLeftNear == GlassColorEnum.Beyaz)
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_RENGI = new CAM_RENGI("2", "BEYAZ");
                        }
                        else if (gozlukRecetesi.GlassColorLeftNear == GlassColorEnum.Colormatik)
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_RENGI = new CAM_RENGI("1", "COLORMATİK");
                        }

                        if (gozlukRecetesi.GlassLeftTypeNear == GlassTypeEnum.Duz)
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("1", "DÜZ");
                        }
                        else if (gozlukRecetesi.GlassLeftTypeNear == GlassTypeEnum.Organik)
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("2", "ORGANİK");
                        }
                        else
                        {
                            gozlukBilgisi.SOL_CAM_BILGILERI.CAM_TIPI = new CAM_TIPI("3", "BİFOCAL-PROGRESİF");
                        }
                        _recordData.GOZLUK_RECETE_BILGILERI.GOZLUK_BILGILERI.Add(gozlukBilgisi);
                    }
                }
                else if (gozlukRecetesi.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik)
                {
                    _recordData.GOZLUK_RECETE_BILGILERI.GOZLUK_RECETE_TIPI = new GOZLUK_RECETE_TIPI("2", "TELESKOPİK");
                }
                else if (gozlukRecetesi.PrescriptionType == GlassesPrescriptionTypeEnum.Lens)
                {
                    _recordData.GOZLUK_RECETE_BILGILERI.GOZLUK_RECETE_TIPI = new GOZLUK_RECETE_TIPI("3", "LENS");
                    GOZLUK_BILGILERI gozlukBilgisi = new GOZLUK_BILGILERI();
                    gozlukBilgisi.GOZLUK_TURU = new GOZLUK_TURU("1", "UZAK");
                    gozlukBilgisi.SAG_LENS_BILGILERI = new SAG_LENS_BILGILERI();

                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_SFERIK = new CAM_SFERIK();
                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_SFERIK.value = gozlukRecetesi.SphRightFar != null ? gozlukRecetesi.SphRightFar : "";

                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_SILINDIRIK = new CAM_SILINDIRIK();
                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_SILINDIRIK.value = gozlukRecetesi.CylRightFar != null ? gozlukRecetesi.CylRightFar : "";

                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_AKS = new CAM_AKS();
                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_AKS.value = gozlukRecetesi.AxRightFar != null ? gozlukRecetesi.AxRightFar : "";

                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_EGIM = new CAM_EGIM();
                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_EGIM.value = gozlukRecetesi.DiameterRightFar != null ? gozlukRecetesi.DiameterRightFar : "";

                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_CAP = new CAM_CAP();
                    gozlukBilgisi.SAG_LENS_BILGILERI.CAM_CAP.value = gozlukRecetesi.GradientRightFar != null ? gozlukRecetesi.GradientRightFar : "";



                    gozlukBilgisi.SOL_LENS_BILGILERI = new SOL_LENS_BILGILERI();

                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_SFERIK = new CAM_SFERIK();
                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_SFERIK.value = gozlukRecetesi.SphLeftFar != null ? gozlukRecetesi.SphLeftFar : "";

                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_SILINDIRIK = new CAM_SILINDIRIK();
                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_SILINDIRIK.value = gozlukRecetesi.CylLeftFar != null ? gozlukRecetesi.CylLeftFar : "";

                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_AKS = new CAM_AKS();
                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_AKS.value = gozlukRecetesi.AxLeftFar != null ? gozlukRecetesi.AxLeftFar : "";

                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_EGIM = new CAM_EGIM();
                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_EGIM.value = gozlukRecetesi.DiameterLeftFar != null ? gozlukRecetesi.DiameterLeftFar : "";

                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_CAP = new CAM_CAP();
                    gozlukBilgisi.SOL_LENS_BILGILERI.CAM_CAP.value = gozlukRecetesi.DiameterLeftFar != null ? gozlukRecetesi.DiameterLeftFar : "";

                    if (gozlukRecetesi.TemporaryLens != null && gozlukRecetesi.TemporaryLens == true)
                    {
                        gozlukBilgisi.SAG_LENS_BILGILERI.GECICI_MADDE = new CAM_LENS_SECIMI("1", "EVET");
                        gozlukBilgisi.SOL_LENS_BILGILERI.GECICI_MADDE = new CAM_LENS_SECIMI("1", "EVET");
                    }
                    else
                    {
                        gozlukBilgisi.SAG_LENS_BILGILERI.GECICI_MADDE = new CAM_LENS_SECIMI("2", "HAYIR");
                        gozlukBilgisi.SOL_LENS_BILGILERI.GECICI_MADDE = new CAM_LENS_SECIMI("2", "HAYIR");
                    }

                    _recordData.GOZLUK_RECETE_BILGILERI.GOZLUK_BILGILERI.Add(gozlukBilgisi);
                }
                else
                {
                    _recordData.GOZLUK_RECETE_BILGILERI.GOZLUK_RECETE_TIPI = new GOZLUK_RECETE_TIPI("4", "KERATAKONUSLENS");
                    GOZLUK_BILGILERI gozlukBilgisi = new GOZLUK_BILGILERI();
                    gozlukBilgisi.GOZLUK_TURU = new GOZLUK_TURU("1", "UZAK");
                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI = new SAG_KERATAKONUS_BILGILERI();

                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_SFERIK = new CAM_SFERIK();
                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_SFERIK.value = gozlukRecetesi.SphRightFar != null ? gozlukRecetesi.SphRightFar : "";

                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_SILINDIRIK = new CAM_SILINDIRIK();
                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_SILINDIRIK.value = gozlukRecetesi.CylRightFar != null ? gozlukRecetesi.CylRightFar : "";

                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_AKS = new CAM_AKS();
                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_AKS.value = gozlukRecetesi.AxRightFar != null ? gozlukRecetesi.AxRightFar : "";

                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_EGIM = new CAM_EGIM();
                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_EGIM.value = gozlukRecetesi.DiameterRightFar != null ? gozlukRecetesi.DiameterRightFar : "";

                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_CAP = new CAM_CAP();
                    gozlukBilgisi.SAG_KERATAKONUS_BILGILERI.CAM_CAP.value = gozlukRecetesi.GradientRightFar != null ? gozlukRecetesi.GradientRightFar : "";



                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI = new SOL_KERATAKONUS_BILGILERI();

                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_SFERIK = new CAM_SFERIK();
                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_SFERIK.value = gozlukRecetesi.SphLeftFar != null ? gozlukRecetesi.SphLeftFar : "";

                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_SILINDIRIK = new CAM_SILINDIRIK();
                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_SILINDIRIK.value = gozlukRecetesi.CylLeftFar != null ? gozlukRecetesi.CylLeftFar : "";

                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_AKS = new CAM_AKS();
                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_AKS.value = gozlukRecetesi.AxLeftFar != null ? gozlukRecetesi.AxLeftFar : "";

                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_EGIM = new CAM_EGIM();
                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_EGIM.value = gozlukRecetesi.DiameterLeftFar != null ? gozlukRecetesi.DiameterLeftFar : "";

                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_CAP = new CAM_CAP();
                    gozlukBilgisi.SOL_KERATAKONUS_BILGILERI.CAM_CAP.value = gozlukRecetesi.DiameterLeftFar != null ? gozlukRecetesi.DiameterLeftFar : "";

                    
                }
  
                if (gozlukRecetesi.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = gozlukRecetesi.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }
        }
    }
}
