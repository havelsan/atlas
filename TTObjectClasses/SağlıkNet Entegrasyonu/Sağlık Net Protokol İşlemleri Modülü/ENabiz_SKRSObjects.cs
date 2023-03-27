using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class messageType : CodeBase
    {
        public messageType()
        {
            codeSystemGuid = "0a9ba485-e7e0-4abb-9c86-0a14fd364bb8";
            version = "1";
        }
        public messageType(string Code, string Value)
        {
            codeSystemGuid = "0a9ba485-e7e0-4abb-9c86-0a14fd364bb8";
            version = "1";
            code = Code.ToString();
            value = Value;

        }
    }


    public class CINSIYET : CodeBase
    {
        public CINSIYET()
        {
            codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
            version = "1";
        }
        public CINSIYET(string Code, string Value)
        {
            codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
            version = "1";
            code = Code.ToString();
            value = Value;

        }
    }
    public class YATISIN_ACILIYETI : CodeBase
    {
        public YATISIN_ACILIYETI()
        {
            codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
            version = "1";
            code = "99";
            value = "BEL�RT�LMED�";

        }
        public YATISIN_ACILIYETI(string Code, string Value)
        {
            codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
            version = "1";
            code = Code.ToString();
            value = Value;

        }

    }
    public class UYRUK : CodeBase
    {
        public UYRUK()
        {
            codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
            version = "1";

        }

        public UYRUK(string Code, string Value)
        {
            codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
            version = "1";
            code = Code;
            value = Value;

        }
    }
    public class ADRES_KODU_SEVIYESI : CodeBase
    {
        public ADRES_KODU_SEVIYESI()
        {
            codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
            version = "1";

        }

        public ADRES_KODU_SEVIYESI(string Code, string Value)
        {
            codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
            version = "1";
            code = Code;
            value = Value;
        }

    }
    public class KAYIT_YERI : CodeBase
    {
        public KAYIT_YERI()
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";

        }
        public KAYIT_YERI(string Code, string Value)
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class HIZMET_SUNUCU : CodeBase
    {
        public HIZMET_SUNUCU()
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";

        }
        public HIZMET_SUNUCU(string Code, string Value)
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class KLINIK_KODU : CodeBase
    {
        public KLINIK_KODU()
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public KLINIK_KODU(string Code, string Value)
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class SOSYAL_GUVENCE_DURUMU : CodeBase
    {
        public SOSYAL_GUVENCE_DURUMU()
        {
            codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
            version = "1";

        }
        public SOSYAL_GUVENCE_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class VAKA_TURU : CodeBase
    {
        public VAKA_TURU()
        {
            codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
            version = "1";

        }
        public VAKA_TURU(string Code, string Value)
        {
            codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class RECETE_TURU : CodeBase
    {
        public RECETE_TURU()
        {
            codeSystemGuid = "c2fbe9bb-f6b3-4cb5-8670-47890ed7ed4b";
            version = "1";

        }
        public RECETE_TURU(string Code, string Value)
        {
            codeSystemGuid = "c2fbe9bb-f6b3-4cb5-8670-47890ed7ed4b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ILAC_KULLANIM_SEKLI : CodeBase
    {
        public ILAC_KULLANIM_SEKLI()
        {
            codeSystemGuid = "32d57611-4928-46da-afac-624aaaa388d8";
            version = "1";

        }
        public ILAC_KULLANIM_SEKLI(string Code, string Value)
        {
            codeSystemGuid = "32d57611-4928-46da-afac-624aaaa388d8";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ISLEM_TURU : CodeBase
    {
        public ISLEM_TURU()
        {
            codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
            version = "1";

        }
        public ISLEM_TURU(string Code, string Value)
        {
            codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
            version = "1";
            code = Code;
            value = Value;
        }
        public ISLEM_TURU(ISLEMTURU it)
        {
            codeSystemGuid = "d03e562d-252e-451f-9a80-98d48b47c2f2";
            version = "1";
            code = Convert.ToInt32(it).ToString();

            if (it == ISLEMTURU.ISLEM)
                value = "DI�ER (SUT, VAKA BA�I VEYA PAKET I�LEMLER)";
            else if (it == ISLEMTURU.ILAC)
                value = "�LA�";
            else if (it == ISLEMTURU.MALZEME)
                value = "MALZEME";


        }
    }
    public class ILAC_KULLANIM_PERIYODU_BIRIMI : CodeBase
    {
        public ILAC_KULLANIM_PERIYODU_BIRIMI()
        {
            codeSystemGuid = "64408499-b82a-4e64-805e-e821aa0c64c9";
            version = "1";

        }
        public ILAC_KULLANIM_PERIYODU_BIRIMI(string Code, string Value)
        {
            codeSystemGuid = "64408499-b82a-4e64-805e-e821aa0c64c9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class RAPOR_TURU : CodeBase
    {
        public RAPOR_TURU()
        {
            codeSystemGuid = "3fb672ac-0675-44ef-9f91-86856dc79370";
            version = "1";

        }
        public RAPOR_TURU(string Code, string Value)
        {
            codeSystemGuid = "3fb672ac-0675-44ef-9f91-86856dc79370";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ICD10 : CodeBase
    {
        public ICD10()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";

        }
        public ICD10(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class CIKIS_SEKLI : CodeBase
    {
        public CIKIS_SEKLI()
        {
            codeSystemGuid = "e8fba324-ae10-49a9-9178-e2c5ad0b57e9";
            version = "1";

        }
        public CIKIS_SEKLI(string Code, string Value)
        {
            codeSystemGuid = "e8fba324-ae10-49a9-9178-e2c5ad0b57e9";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class IZLEMIN_YAPILDIGI_YER : CodeBase
    {
        public IZLEMIN_YAPILDIGI_YER()
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";

        }
        public IZLEMIN_YAPILDIGI_YER(string Code, string Value)
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ASI : CodeBase
    {
        public ASI()
        {
            codeSystemGuid = "c3dbbb53-3b59-06e1-e043-14031b0a9fe6";
            version = "1";

        }
        public ASI(string Code, string Value)
        {
            codeSystemGuid = "c3dbbb53-3b59-06e1-e043-14031b0a9fe6";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ASI_DOZU : CodeBase
    {
        public ASI_DOZU()
        {
            codeSystemGuid = "da92a50e-b1a8-4e6a-be8c-2b6ca2c0a58b";
            version = "1";

        }
        public ASI_DOZU(string Code, string Value)
        {
            codeSystemGuid = "da92a50e-b1a8-4e6a-be8c-2b6ca2c0a58b";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class ASININ_DOZU : CodeBase
    {
        public ASININ_DOZU()
        {
            codeSystemGuid = "da92a50e-b1a8-4e6a-be8c-2b6ca2c0a58b";
            version = "1";

        }
        public ASININ_DOZU(string Code, string Value)
        {
            codeSystemGuid = "da92a50e-b1a8-4e6a-be8c-2b6ca2c0a58b";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class ASININ_UYGULAMA_SEKLI : CodeBase
    {
        public ASININ_UYGULAMA_SEKLI()
        {
            codeSystemGuid = "f20210e0-d780-4961-87eb-3323000b7dbb";
            version = "1";

        }
        public ASININ_UYGULAMA_SEKLI(string Code, string Value)
        {
            codeSystemGuid = "f20210e0-d780-4961-87eb-3323000b7dbb";
            version = "1";
            code = Code;
            value = Value;
        }
    }


    public class ASININ_SAGLANDIGI_KAYNAK : CodeBase
    {
        public ASININ_SAGLANDIGI_KAYNAK()
        {
            codeSystemGuid = "15068142-6853-4dab-86e1-e45e6e93b150";
            version = "1";

        }
        public ASININ_SAGLANDIGI_KAYNAK(string Code, string Value)
        {
            codeSystemGuid = "15068142-6853-4dab-86e1-e45e6e93b150";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class ASININ_UYGULAMA_YERI : CodeBase
    {
        public ASININ_UYGULAMA_YERI()
        {
            codeSystemGuid = "eb66330f-2b96-40a7-931e-fc9aed2b9409";
            version = "1";

        }
        public ASININ_UYGULAMA_YERI(string Code, string Value)
        {
            codeSystemGuid = "eb66330f-2b96-40a7-931e-fc9aed2b9409";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class ASI_UYGULAMA_YERI : CodeBase
    {
        public ASI_UYGULAMA_YERI()
        {
            codeSystemGuid = "eb66330f-2b96-40a7-931e-fc9aed2b9409";
            version = "1";

        }
        public ASI_UYGULAMA_YERI(string Code, string Value)
        {
            codeSystemGuid = "eb66330f-2b96-40a7-931e-fc9aed2b9409";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class YATAK_TURU : CodeBase
    {
        public YATAK_TURU()
        {
            codeSystemGuid = "51c26737-62f1-4072-8ab8-41caa7bd11da";
            version = "1";

        }
        public YATAK_TURU(string Code, string Value)
        {
            codeSystemGuid = "51c26737-62f1-4072-8ab8-41caa7bd11da";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ISTEM_YAPILAN_KLINIK : CodeBase
    {
        public ISTEM_YAPILAN_KLINIK()
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";

        }
        public ISTEM_YAPILAN_KLINIK(string Code, string Value)
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI : CodeBase
    {
        public NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI()
        {
            codeSystemGuid = "cf34c46d-c31f-4922-9b74-68cc69412cfc";
            version = "1";

        }
        public NUMUNENIN_ALINDIGI_DOKUNUN_TEMEL_OZELLIGI(string Code, string Value)
        {
            codeSystemGuid = "cf34c46d-c31f-4922-9b74-68cc69412cfc";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class NUMUNE_ALINMA_SEKLI : CodeBase
    {
        public NUMUNE_ALINMA_SEKLI()
        {
            codeSystemGuid = "051c2db0-f724-457a-ac46-7d3a741b7ae2";
            version = "1";

        }
        public NUMUNE_ALINMA_SEKLI(string Code, string Value)
        {
            codeSystemGuid = "051c2db0-f724-457a-ac46-7d3a741b7ae2";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class PREPARAT_DURUMU : CodeBase
    {
        public PREPARAT_DURUMU()
        {
            codeSystemGuid = "4016f2d2-9b44-43e1-834d-d1c045419fea";
            version = "1";

        }
        public PREPARAT_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "4016f2d2-9b44-43e1-834d-d1c045419fea";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class YERLESIM_YERI : CodeBase
    {
        public YERLESIM_YERI()
        {
            codeSystemGuid = "fc24f548-c383-4855-be0b-0f1d23599bba";
            version = "1";

        }
        public YERLESIM_YERI(string Code, string Value)
        {
            codeSystemGuid = "fc24f548-c383-4855-be0b-0f1d23599bba";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class MORFOLOJI_KODU : CodeBase
    {
        public MORFOLOJI_KODU()
        {
            codeSystemGuid = "40220f50-1c9c-43c9-9bbd-45794d5cc7b2";
            version = "1";

        }
        public MORFOLOJI_KODU(string Code, string Value)
        {
            codeSystemGuid = "40220f50-1c9c-43c9-9bbd-45794d5cc7b2";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class VAKA_TIPI : CodeBase
    {
        public VAKA_TIPI()
        {
            codeSystemGuid = "663db642-20db-4160-bd77-c9be99c7f496";
            version = "1";

        }
        public VAKA_TIPI(string Code, string Value)
        {
            codeSystemGuid = "663db642-20db-4160-bd77-c9be99c7f496";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class ADRES_TIPI : CodeBase
    {
        public ADRES_TIPI()
        {
            codeSystemGuid = "35f4968a-3e72-41ce-9ae4-f4d22f90ea2e";
            version = "1";

        }
        public ADRES_TIPI(string Code, string Value)
        {
            codeSystemGuid = "35f4968a-3e72-41ce-9ae4-f4d22f90ea2e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ILCE_KODU : CodeBase
    {
        public ILCE_KODU()
        {
            codeSystemGuid = "96184a9e-537c-4a70-8b3a-27a7a170355b";
            version = "1";

        }
        public ILCE_KODU(string Code, string Value)
        {
            codeSystemGuid = "96184a9e-537c-4a70-8b3a-27a7a170355b";
            version = "1";
            code = Code;
            value = Value;
        }
    }
    public class IL_KODU : CodeBase
    {
        public IL_KODU()
        {
            codeSystemGuid = "5bc508fa-782a-4d75-831f-34948e350e72";
            version = "1";

        }
        public IL_KODU(string Code, string Value)
        {
            codeSystemGuid = "5bc508fa-782a-4d75-831f-34948e350e72";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class TELEFON_TIPI : CodeBase
    {
        public TELEFON_TIPI()
        {
            codeSystemGuid = "e387c902-9062-4406-85ef-63e085754f9e";
            version = "1";

        }
        public TELEFON_TIPI(string Code, string Value)
        {
            codeSystemGuid = "e387c902-9062-4406-85ef-63e085754f9e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class ASI_OZEL_DURUM_NEDENI : CodeBase
    {
        public ASI_OZEL_DURUM_NEDENI()
        {
            codeSystemGuid = "0a8f681f-4ed0-4830-9dc9-a0295686398b";
            version = "1";

        }
        public ASI_OZEL_DURUM_NEDENI(string Code, string Value)
        {
            codeSystemGuid = "0a8f681f-4ed0-4830-9dc9-a0295686398b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class ASI_YAPILMAMA_DURUMU : CodeBase
    {
        public ASI_YAPILMAMA_DURUMU()
        {
            codeSystemGuid = "0d70eb6c-1b87-4a23-a744-d4dd68210270";
            version = "1";

        }
        public ASI_YAPILMAMA_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "0d70eb6c-1b87-4a23-a744-d4dd68210270";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class ASI_YAPILMAMA_NEDENI : CodeBase
    {
        public ASI_YAPILMAMA_NEDENI()
        {
            codeSystemGuid = "c6651718-aa25-a422-e0407-c0a011657e6";
            version = "1";

        }
        public ASI_YAPILMAMA_NEDENI(string Code, string Value)
        {
            codeSystemGuid = "c6651718-aa25-a422-e0407-c0a011657e6";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI : CodeBase
    {
        public BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI()
        {
            codeSystemGuid = "c6652612-6fcb-6fa8-e040-7c0a011670bd";
            version = "1";

        }
        public BILDIRIMI_ZORUNLU_ASI_SONRASI_ISTENMEYEN_ETKI_NEDENI(string Code, string Value)
        {
            codeSystemGuid = "c6652612-6fcb-6fa8-e040-7c0a011670bd";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class AGRI : CodeBase
    {
        public AGRI()
        {
            codeSystemGuid = "a87d1c7a-36f1-4950-87a3-0cc1b61c1265";
            version = "1";

        }
        public AGRI(string Code, string Value)
        {
            codeSystemGuid = "a87d1c7a-36f1-4950-87a3-0cc1b61c1265";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class AYDINLATMA : CodeBase
    {
        public AYDINLATMA()
        {
            codeSystemGuid = "cd2deead-3154-424b-88de-85b38ff63958";
            version = "1";

        }
        public AYDINLATMA(string Code, string Value)
        {
            codeSystemGuid = "cd2deead-3154-424b-88de-85b38ff63958";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BAKIM_VE_DESTEK_IHTIYACI : CodeBase
    {
        public BAKIM_VE_DESTEK_IHTIYACI()
        {
            codeSystemGuid = "9b5502a4-93a7-4594-88e6-3eeaf0c302c1";
            version = "1";

        }
        public BAKIM_VE_DESTEK_IHTIYACI(string Code, string Value)
        {
            codeSystemGuid = "9b5502a4-93a7-4594-88e6-3eeaf0c302c1";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BASI_DEGERLENDIRMESI : CodeBase
    {
        public BASI_DEGERLENDIRMESI()
        {
            codeSystemGuid = "26f3177d-b761-4e29-bbbc-b4fac7df3322";
            version = "1";

        }
        public BASI_DEGERLENDIRMESI(string Code, string Value)
        {
            codeSystemGuid = "26f3177d-b761-4e29-bbbc-b4fac7df3322";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BASVURU_TURU : CodeBase
    {
        public BASVURU_TURU()
        {
            codeSystemGuid = "8f04bf30-3501-4080-91df-458e20917be2";
            version = "1";

        }
        public BASVURU_TURU(string Code, string Value)
        {
            codeSystemGuid = "8f04bf30-3501-4080-91df-458e20917be2";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BESLENME : CodeBase
    {
        public BESLENME()
        {
            codeSystemGuid = "6a220e1d-3865-4cab-b98f-b7933d9aa1ba";
            version = "1";

        }
        public BESLENME(string Code, string Value)
        {
            codeSystemGuid = "6a220e1d-3865-4cab-b98f-b7933d9aa1ba";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BIR_SONRAKI_HIZMET_IHTIYACI : CodeBase
    {
        public BIR_SONRAKI_HIZMET_IHTIYACI()
        {
            codeSystemGuid = "1ac7dc71-e09d-4ddd-bea5-179735d35246";
            version = "1";

        }
        public BIR_SONRAKI_HIZMET_IHTIYACI(string Code, string Value)
        {
            codeSystemGuid = "1ac7dc71-e09d-4ddd-bea5-179735d35246";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class EV_HIJYENI : CodeBase
    {
        public EV_HIJYENI()
        {
            codeSystemGuid = "d26c2f94-5506-4d1e-a138-27e920f61008";
            version = "1";

        }
        public EV_HIJYENI(string Code, string Value)
        {
            codeSystemGuid = "d26c2f94-5506-4d1e-a138-27e920f61008";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GUVENLIK : CodeBase
    {
        public GUVENLIK()
        {
            codeSystemGuid = "a043c0be-cd98-422c-8ca6-6c3b4872d1c9";
            version = "1";

        }
        public GUVENLIK(string Code, string Value)
        {
            codeSystemGuid = "a043c0be-cd98-422c-8ca6-6c3b4872d1c9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ISINMA : CodeBase
    {
        public ISINMA()
        {
            codeSystemGuid = "28a8a3fc-bea3-4da0-bcd6-d9537d379093";
            version = "1";

        }
        public ISINMA(string Code, string Value)
        {
            codeSystemGuid = "28a8a3fc-bea3-4da0-bcd6-d9537d379093";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KISISEL_BAKIM : CodeBase
    {
        public KISISEL_BAKIM()
        {
            codeSystemGuid = "922fd54a-443f-4b47-9e82-53f9d7f96a0d";
            version = "1";

        }
        public KISISEL_BAKIM(string Code, string Value)
        {
            codeSystemGuid = "922fd54a-443f-4b47-9e82-53f9d7f96a0d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KISISEL_HIJYEN : CodeBase
    {
        public KISISEL_HIJYEN()
        {
            codeSystemGuid = "b5366d27-e84c-49c7-ad1f-66ef7636969a";
            version = "1";

        }
        public KISISEL_HIJYEN(string Code, string Value)
        {
            codeSystemGuid = "b5366d27-e84c-49c7-ad1f-66ef7636969a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KONUT_TIPI : CodeBase
    {
        public KONUT_TIPI()
        {
            codeSystemGuid = "9462baa3-789f-4d54-9475-8d7cd186b408";
            version = "1";

        }
        public KONUT_TIPI(string Code, string Value)
        {
            codeSystemGuid = "9462baa3-789f-4d54-9475-8d7cd186b408";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KULLANILAN_HELA_TIPI : CodeBase
    {
        public KULLANILAN_HELA_TIPI()
        {
            codeSystemGuid = "52d09f03-7eff-47aa-898f-f197e7597904";
            version = "1";

        }
        public KULLANILAN_HELA_TIPI(string Code, string Value)
        {
            codeSystemGuid = "52d09f03-7eff-47aa-898f-f197e7597904";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class YATAGA_BAGIMLILIK : CodeBase
    {
        public YATAGA_BAGIMLILIK()
        {
            codeSystemGuid = "7c011fa6-7896-409b-8fc7-9b4f501cc9db";
            version = "1";

        }
        public YATAGA_BAGIMLILIK(string Code, string Value)
        {
            codeSystemGuid = "7c011fa6-7896-409b-8fc7-9b4f501cc9db";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KULLANDIGI_YARDIMCI_ARACLAR : CodeBase
    {
        public KULLANDIGI_YARDIMCI_ARACLAR()
        {
            codeSystemGuid = "1435482c-1a3f-4f2d-b692-77c06f3827cd";
            version = "1";

        }
        public KULLANDIGI_YARDIMCI_ARACLAR(string Code, string Value)
        {
            codeSystemGuid = "1435482c-1a3f-4f2d-b692-77c06f3827cd";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class PSIKOLOJIK_DURUM_DEGERLENDIRMESI : CodeBase
    {
        public PSIKOLOJIK_DURUM_DEGERLENDIRMESI()
        {
            codeSystemGuid = "8ed2e8ce-b1fe-49f6-91ac-8f3340deac9d";
            version = "1";

        }
        public PSIKOLOJIK_DURUM_DEGERLENDIRMESI(string Code, string Value)
        {
            codeSystemGuid = "8ed2e8ce-b1fe-49f6-91ac-8f3340deac9d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class VERILEN_EGITIMLER : CodeBase
    {
        public VERILEN_EGITIMLER()
        {
            codeSystemGuid = "79aaa967-1886-4d9d-a5d8-cdde552d94ad";
            version = "1";

        }
        public VERILEN_EGITIMLER(string Code, string Value)
        {
            codeSystemGuid = "79aaa967-1886-4d9d-a5d8-cdde552d94ad";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class EVDE_SAGLIK_HIZMETININ_SONLANDIRILMASI : CodeBase
    {
        public EVDE_SAGLIK_HIZMETININ_SONLANDIRILMASI()
        {
            codeSystemGuid = "bb0d92ea-397f-4c8d-989c-f00aa9d5d7ff";
            version = "1";

        }
        public EVDE_SAGLIK_HIZMETININ_SONLANDIRILMASI(string Code, string Value)
        {
            codeSystemGuid = "bb0d92ea-397f-4c8d-989c-f00aa9d5d7ff";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class EVDE_SAGLIK_HIZMETLERI_HASTA_NAKLI : CodeBase
    {
        public EVDE_SAGLIK_HIZMETLERI_HASTA_NAKLI()
        {
            codeSystemGuid = "a301b5d0-f467-458b-81e1-27a48a049c99";
            version = "1";

        }
        public EVDE_SAGLIK_HIZMETLERI_HASTA_NAKLI(string Code, string Value)
        {
            codeSystemGuid = "a301b5d0-f467-458b-81e1-27a48a049c99";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KACINCI_GEBE_IZLEM : CodeBase
    {
        public KACINCI_GEBE_IZLEM()
        {
            codeSystemGuid = "a280b762-8804-4049-b587-7c471ff2cbee";
            version = "1";
        }
        public KACINCI_GEBE_IZLEM(string Code, string Value)
        {
            codeSystemGuid = "a280b762-8804-4049-b587-7c471ff2cbee";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GEBELIKTE_RISK_FAKTORLERI : CodeBase
    {
        public GEBELIKTE_RISK_FAKTORLERI()
        {
            codeSystemGuid = "ad9ae051-f75d-4180-b57f-38f45132a1b0";
            version = "1";
        }
        public GEBELIKTE_RISK_FAKTORLERI(string Code, string Value)
        {
            codeSystemGuid = "ad9ae051-f75d-4180-b57f-38f45132a1b0";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI : CodeBase
    {
        public GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI()
        {
            codeSystemGuid = "86d2237f-1896-41cc-bfd5-7745cd576e2d";
            version = "1";
        }
        public GEBELIK_LOHUSALIK_SEYRINDE_TEHLIKE_ISARETI(string Code, string Value)
        {
            codeSystemGuid = "86d2237f-1896-41cc-bfd5-7745cd576e2d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class DEMIR_LOJISTIGI_VE_DESTEGI : CodeBase
    {
        public DEMIR_LOJISTIGI_VE_DESTEGI()
        {
            codeSystemGuid = "83c966d5-1054-451c-87c6-19a0e11b287b";
            version = "1";
        }
        public DEMIR_LOJISTIGI_VE_DESTEGI(string Code, string Value)
        {
            codeSystemGuid = "83c966d5-1054-451c-87c6-19a0e11b287b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class D_VITAMINI_LOJISTIGI_VE_DESTEGI : CodeBase
    {
        public D_VITAMINI_LOJISTIGI_VE_DESTEGI()
        {
            codeSystemGuid = "672986f8-5e0d-43a6-b417-37bdc59cd09b";
            version = "1";
        }
        public D_VITAMINI_LOJISTIGI_VE_DESTEGI(string Code, string Value)
        {
            codeSystemGuid = "672986f8-5e0d-43a6-b417-37bdc59cd09b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KONJENITAL_ANOMALILI_DOGUM_VARLIGI : CodeBase
    {
        public KONJENITAL_ANOMALILI_DOGUM_VARLIGI()
        {
            codeSystemGuid = "484b2fc2-d1a2-4675-872e-c2c56e72d921";
            version = "1";
        }
        public KONJENITAL_ANOMALILI_DOGUM_VARLIGI(string Code, string Value)
        {
            codeSystemGuid = "484b2fc2-d1a2-4675-872e-c2c56e72d921";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KOMPLIKASYON_TANISI : CodeBase
    {
        public KOMPLIKASYON_TANISI()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
        }
        public KOMPLIKASYON_TANISI(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GEBE_BILGILENDIRME_VE_DANISMANLIK : CodeBase
    {
        public GEBE_BILGILENDIRME_VE_DANISMANLIK()
        {
            codeSystemGuid = "d7d1283b-3440-5c76-e040-7c0a04161e8f";
            version = "1";
        }
        public GEBE_BILGILENDIRME_VE_DANISMANLIK(string Code, string Value)
        {
            codeSystemGuid = "d7d1283b-3440-5c76-e040-7c0a04161e8f";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GEBELIKTE_RISK_OYKUSU : CodeBase
    {
        public GEBELIKTE_RISK_OYKUSU()
        {
            codeSystemGuid = "ad9ae051-f75d-4180-b57f-38f45132a1b0";
            version = "1";
        }
        public GEBELIKTE_RISK_OYKUSU(string Code, string Value)
        {
            codeSystemGuid = "ad9ae051-f75d-4180-b57f-38f45132a1b0";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GEBELIKTE_RISK_DURUMU : CodeBase
    {
        public GEBELIKTE_RISK_DURUMU()
        {
            codeSystemGuid = "cd4807ca-845a-4176-a8f2-f3a3a1274599";
            version = "1";
        }
        public GEBELIKTE_RISK_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "cd4807ca-845a-4176-a8f2-f3a3a1274599";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GESTASYONEL_DIYABET_TARAMASI : CodeBase
    {
        public GESTASYONEL_DIYABET_TARAMASI()
        {
            codeSystemGuid = "eac44682-3583-47f3-8066-7310aac49a21";
            version = "1";
        }
        public GESTASYONEL_DIYABET_TARAMASI(string Code, string Value)
        {
            codeSystemGuid = "eac44682-3583-47f3-8066-7310aac49a21";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KADIN_SAGLIGI_ISLEMLERI : CodeBase
    {
        public KADIN_SAGLIGI_ISLEMLERI()
        {
            codeSystemGuid = "9f10cc39-f47a-4611-b328-78e044a8a2bc";
            version = "1";
        }
        public KADIN_SAGLIGI_ISLEMLERI(string Code, string Value)
        {
            codeSystemGuid = "9f10cc39-f47a-4611-b328-78e044a8a2bc";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BILDIRIMI_ZORUNLU_RISK_FAKTORU : CodeBase
    {
        public BILDIRIMI_ZORUNLU_RISK_FAKTORU()
        {
            codeSystemGuid = "2d982b17-23c9-48d8-93a4-1c7f164c8ad8";
            version = "1";
        }
        public BILDIRIMI_ZORUNLU_RISK_FAKTORU(string Code, string Value)
        {
            codeSystemGuid = "2d982b17-23c9-48d8-93a4-1c7f164c8ad8";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class IDRARDA_PROTEIN : CodeBase
    {
        public IDRARDA_PROTEIN()
        {
            codeSystemGuid = "f3d218b5-1a31-4e67-a5f2-72f2d412a802";
            version = "1";
        }
        public IDRARDA_PROTEIN(string Code, string Value)
        {
            codeSystemGuid = "f3d218b5-1a31-4e67-a5f2-72f2d412a802";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER : CodeBase
    {
        public BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER()
        {
            codeSystemGuid = "c81e3e71-8c22-4363-af86-3b687c91b063";
            version = "1";
        }
        public BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER(string Code, string Value)
        {
            codeSystemGuid = "c81e3e71-8c22-4363-af86-3b687c91b063";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER : CodeBase
    {
        public BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER()
        {
            codeSystemGuid = "58078833-09f4-4046-883e-81777a548af0";
            version = "1";
        }
        public BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER(string Code, string Value)
        {
            codeSystemGuid = "58078833-09f4-4046-883e-81777a548af0";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GEBEDE_RISK_FAKTORLERINE_YAPILAN_MUDAHALE : CodeBase
    {
        public GEBEDE_RISK_FAKTORLERINE_YAPILAN_MUDAHALE()
        {
            codeSystemGuid = "d6572124-7f21-4cf2-aad8-e6240ea06e2a";
            version = "1";
        }
        public GEBEDE_RISK_FAKTORLERINE_YAPILAN_MUDAHALE(string Code, string Value)
        {
            codeSystemGuid = "d6572124-7f21-4cf2-aad8-e6240ea06e2a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GEBEDE_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI : CodeBase
    {
        public GEBEDE_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI()
        {
            codeSystemGuid = "02f4541a-3dcf-4519-9c43-c2251db70590";
            version = "1";
        }
        public GEBEDE_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI(string Code, string Value)
        {
            codeSystemGuid = "02f4541a-3dcf-4519-9c43-c2251db70590";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BABANIN_KAN_GRUBU : CodeBase
    {
        public BABANIN_KAN_GRUBU()
        {
            codeSystemGuid = "50b46fe7-a7b0-463a-aff6-d284f9550509";
            version = "1";
        }
        public BABANIN_KAN_GRUBU(string Code, string Value)
        {
            codeSystemGuid = "50b46fe7-a7b0-463a-aff6-d284f9550509";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KAN_GRUBU : CodeBase
    {
        public KAN_GRUBU()
        {
            codeSystemGuid = "a3d6e943-5d85-4c75-ac72-709115974fb7";
            version = "1";
        }
        public KAN_GRUBU(string Code, string Value)
        {
            codeSystemGuid = "a3d6e943-5d85-4c75-ac72-709115974fb7";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ONCEKI_DOGUM_DURUMU : CodeBase
    {
        public ONCEKI_DOGUM_DURUMU()
        {
            codeSystemGuid = "d7e6d65a-b82a-6717-e040-7c0a021654a2";
            version = "1";
        }
        public ONCEKI_DOGUM_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "d7e6d65a-b82a-6717-e040-7c0a021654a2";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class DUSUK_TURU : CodeBase
    {
        public DUSUK_TURU()
        {
            codeSystemGuid = "1a3c91f6-9086-4963-94db-d2a19d5cb5f1";
            version = "1";
        }
        public DUSUK_TURU(string Code, string Value)
        {
            codeSystemGuid = "1a3c91f6-9086-4963-94db-d2a19d5cb5f1";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class DOGUMA_YARDIM_EDEN : CodeBase
    {
        public DOGUMA_YARDIM_EDEN()
        {
            codeSystemGuid = "a85c1ba7-3ae9-44c5-b0d0-613f92c5281b";
            version = "1";
        }
        public DOGUMA_YARDIM_EDEN(string Code, string Value)
        {
            codeSystemGuid = "a85c1ba7-3ae9-44c5-b0d0-613f92c5281b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class DOGUMUN_GERCEKLESTIGI_YER : CodeBase
    {
        public DOGUMUN_GERCEKLESTIGI_YER()
        {
            codeSystemGuid = "bc2104af-0c2b-4a9d-a450-c0827effe607";
            version = "1";
        }
        public DOGUMUN_GERCEKLESTIGI_YER(string Code, string Value)
        {
            codeSystemGuid = "bc2104af-0c2b-4a9d-a450-c0827effe607";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class DOGUM_YONTEMI : CodeBase
    {
        public DOGUM_YONTEMI()
        {
            codeSystemGuid = "c03d71af-54c5-4245-aea4-ad58e876e8bd";
            version = "1";
        }
        public DOGUM_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "c03d71af-54c5-4245-aea4-ad58e876e8bd";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GEBELIK_SONUCU : CodeBase
    {
        public GEBELIK_SONUCU()
        {
            codeSystemGuid = "b5070ebb-a700-46dd-8f50-bee87e4b4596";
            version = "1";
        }
        public GEBELIK_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "b5070ebb-a700-46dd-8f50-bee87e4b4596";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class SEZARYAN_ENDIKASYON : CodeBase
    {
        public SEZARYAN_ENDIKASYON()
        {
            codeSystemGuid = "d7d14450-eaf1-7321-e040-7c0a04164cc0";
            version = "1";
        }
        public SEZARYAN_ENDIKASYON(string Code, string Value)
        {
            codeSystemGuid = "d7d14450-eaf1-7321-e040-7c0a04164cc0";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class ENDIKASYON_NEDENLERI : CodeBase
    {
        public ENDIKASYON_NEDENLERI()
        {
            codeSystemGuid = "d7d15411-dbc7-f5bd-e040-7c0a041665a6";
            version = "1";
        }
        public ENDIKASYON_NEDENLERI(string Code, string Value)
        {
            codeSystemGuid = "d7d15411-dbc7-f5bd-e040-7c0a041665a6";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class GAITADA_GIZLI_KAN_TESTI : CodeBase
    {
        public GAITADA_GIZLI_KAN_TESTI()
        {
            codeSystemGuid = "a6a592bd-2653-4410-b03e-7b8cd712d3bb";
            version = "1";
        }
        public GAITADA_GIZLI_KAN_TESTI(string Code, string Value)
        {
            codeSystemGuid = "a6a592bd-2653-4410-b03e-7b8cd712d3bb";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class HPV_TARAMA_TESTI : CodeBase
    {
        public HPV_TARAMA_TESTI()
        {
            codeSystemGuid = "a1edee3c-cdb4-4b36-810e-ae461b6faeeb";
            version = "1";
        }
        public HPV_TARAMA_TESTI(string Code, string Value)
        {
            codeSystemGuid = "a1edee3c-cdb4-4b36-810e-ae461b6faeeb";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KENDI_KENDINE_MEME_MUAYENESI : CodeBase
    {
        public KENDI_KENDINE_MEME_MUAYENESI()
        {
            codeSystemGuid = "ca7e0d3b-777c-4637-8094-1e17d4eca5f0";
            version = "1";
        }
        public KENDI_KENDINE_MEME_MUAYENESI(string Code, string Value)
        {
            codeSystemGuid = "ca7e0d3b-777c-4637-8094-1e17d4eca5f0";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KLINIK_MEME_MUAYENESI : CodeBase
    {
        public KLINIK_MEME_MUAYENESI()
        {
            codeSystemGuid = "46ff4cc1-3a97-4cb5-a188-b60ad5ef948c";
            version = "1";
        }
        public KLINIK_MEME_MUAYENESI(string Code, string Value)
        {
            codeSystemGuid = "46ff4cc1-3a97-4cb5-a188-b60ad5ef948c";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KOLONOSKOPI : CodeBase
    {
        public KOLONOSKOPI()
        {
            codeSystemGuid = "d7dfe101-8df8-95d6-e040-7c0a04163ae7";
            version = "1";
        }
        public KOLONOSKOPI(string Code, string Value)
        {
            codeSystemGuid = "d7dfe101-8df8-95d6-e040-7c0a04163ae7";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KOLONOSKOPININ_SURESI : CodeBase
    {
        public KOLONOSKOPININ_SURESI()
        {
            codeSystemGuid = "5a9738a0-2ba6-4985-8dbc-409e04b5d456";
            version = "1";
        }
        public KOLONOSKOPININ_SURESI(string Code, string Value)
        {
            codeSystemGuid = "5a9738a0-2ba6-4985-8dbc-409e04b5d456";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KOLON_GORUNTULEME_YONTEMI : CodeBase
    {
        public KOLON_GORUNTULEME_YONTEMI()
        {
            codeSystemGuid = "72ee89f5-de3d-4b1a-b806-d73ea34acbd0";
            version = "1";
        }
        public KOLON_GORUNTULEME_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "72ee89f5-de3d-4b1a-b806-d73ea34acbd0";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KOLPOSKOPI : CodeBase
    {
        public KOLPOSKOPI()
        {
            codeSystemGuid = "d7dff7a7-7d30-4ffb-e040-7c0a04165e5f";
            version = "1";
        }
        public KOLPOSKOPI(string Code, string Value)
        {
            codeSystemGuid = "d7dff7a7-7d30-4ffb-e040-7c0a04165e5f";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class MAMOGRAFI : CodeBase
    {
        public MAMOGRAFI()
        {
            codeSystemGuid = "6d1c6d74-d446-4d53-a056-5e75b19cad0f";
            version = "1";
        }
        public MAMOGRAFI(string Code, string Value)
        {
            codeSystemGuid = "6d1c6d74-d446-4d53-a056-5e75b19cad0f";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class MAMOGRAFI_SONUCU : CodeBase
    {
        public MAMOGRAFI_SONUCU()
        {
            codeSystemGuid = "397e2da4-e9be-4822-bd26-dbc82530c783";
            version = "1";
        }
        public MAMOGRAFI_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "397e2da4-e9be-4822-bd26-dbc82530c783";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class PAP_SMEAR_TESTI : CodeBase
    {
        public PAP_SMEAR_TESTI()
        {
            codeSystemGuid = "99db2341-c9e7-42a1-bed9-bb04e0388395";
            version = "1";
        }
        public PAP_SMEAR_TESTI(string Code, string Value)
        {
            codeSystemGuid = "99db2341-c9e7-42a1-bed9-bb04e0388395";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class SIGMOIDOSKOPI : CodeBase
    {
        public SIGMOIDOSKOPI()
        {
            codeSystemGuid = "5630141c-0ba4-49ea-89a1-8ec62a6aa88a";
            version = "1";
        }
        public SIGMOIDOSKOPI(string Code, string Value)
        {
            codeSystemGuid = "5630141c-0ba4-49ea-89a1-8ec62a6aa88a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class HPV_TIPI : CodeBase
    {
        public HPV_TIPI()
        {
            codeSystemGuid = "fe6835a3-5ee1-4d18-bb50-1f0cc336136a";
            version = "1";
        }
        public HPV_TIPI(string Code, string Value)
        {
            codeSystemGuid = "fe6835a3-5ee1-4d18-bb50-1f0cc336136a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KOLONOSKOPI_KALITE_KRITERLERI : CodeBase
    {
        public KOLONOSKOPI_KALITE_KRITERLERI()
        {
            codeSystemGuid = "e30b2b54-e402-4ca7-b8de-9db1c75abe01";
            version = "1";
        }
        public KOLONOSKOPI_KALITE_KRITERLERI(string Code, string Value)
        {
            codeSystemGuid = "e30b2b54-e402-4ca7-b8de-9db1c75abe01";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KOLOREKTAL_BIYOPSI_SONUCU : CodeBase
    {
        public KOLOREKTAL_BIYOPSI_SONUCU()
        {
            codeSystemGuid = "d7dfe924-93f5-5f95-e040-7c0a041645d7";
            version = "1";
        }
        public KOLOREKTAL_BIYOPSI_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "d7dfe924-93f5-5f95-e040-7c0a041645d7";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class MEMEDEN_BIYOPSI_ALIMI : CodeBase
    {
        public MEMEDEN_BIYOPSI_ALIMI()
        {
            codeSystemGuid = "1f2f89f4-daf3-467c-8c11-cfacae8cbafd";
            version = "1";
        }
        public MEMEDEN_BIYOPSI_ALIMI(string Code, string Value)
        {
            codeSystemGuid = "1f2f89f4-daf3-467c-8c11-cfacae8cbafd";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class MEME_BIYOPSI_SONUCU : CodeBase
    {
        public MEME_BIYOPSI_SONUCU()
        {
            codeSystemGuid = "7c69e4a6-8ddb-4db5-9f53-541d66ebfe51";
            version = "1";
        }
        public MEME_BIYOPSI_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "7c69e4a6-8ddb-4db5-9f53-541d66ebfe51";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class SERVIKAL_BIYOPSI_SONUCU : CodeBase
    {
        public SERVIKAL_BIYOPSI_SONUCU()
        {
            codeSystemGuid = "f1d82016-486d-492e-afd2-630c85363634";
            version = "1";
        }
        public SERVIKAL_BIYOPSI_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "f1d82016-486d-492e-afd2-630c85363634";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class SERVIKAL_SITOLOJI_SONUCU : CodeBase
    {
        public SERVIKAL_SITOLOJI_SONUCU()
        {
            codeSystemGuid = "197c1232-2886-47de-9a38-0d5401fe6510";
            version = "1";
        }
        public SERVIKAL_SITOLOJI_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "197c1232-2886-47de-9a38-0d5401fe6510";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class SPIROMETRI : CodeBase
    {
        public SPIROMETRI()
        {
            codeSystemGuid = "183e952f-4a72-43ff-85ab-793e0e6f892a";
            version = "1";

        }
        public SPIROMETRI(string Code, string Value)
        {
            codeSystemGuid = "183e952f-4a72-43ff-85ab-793e0e6f892a";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class AFET_OLAY_VATANDAS_TIPI : CodeBase
    {
        public AFET_OLAY_VATANDAS_TIPI()
        {
            codeSystemGuid = "ddb59d45-97c3-4b87-ba90-03fc7689b7eb";
            version = "1";

        }
        public AFET_OLAY_VATANDAS_TIPI(string Code, string Value)
        {
            codeSystemGuid = "ddb59d45-97c3-4b87-ba90-03fc7689b7eb";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class OLAY_ID : CodeBase
    {
        public OLAY_ID()
        {
            codeSystemGuid = "6fedbc09-c34f-4189-88b7-6c6f4798fcfc";
            version = "1";

        }
        public OLAY_ID(string Code, string Value)
        {
            codeSystemGuid = "6fedbc09-c34f-4189-88b7-6c6f4798fcfc";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class HAYATI_TEHLIKE_DURUMU : CodeBase
    {
        public HAYATI_TEHLIKE_DURUMU()
        {
            codeSystemGuid = "8999f472-8252-4dff-901e-66e3f9f57c68";
            version = "1";

        }
        public HAYATI_TEHLIKE_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "8999f472-8252-4dff-901e-66e3f9f57c68";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class DIYABET_EGITIMI : CodeBase
    {
        public DIYABET_EGITIMI()
        {
            codeSystemGuid = "f007d4ed-302d-4b7a-897d-48240924bb2d";
            version = "1";

        }
        public DIYABET_EGITIMI(string Code, string Value)
        {
            codeSystemGuid = "f007d4ed-302d-4b7a-897d-48240924bb2d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class DIYABET_KOMPLIKASYONLARI : CodeBase
    {
        public DIYABET_KOMPLIKASYONLARI()
        {
            codeSystemGuid = "0d4c699c-06ca-4983-b3b5-617dd5def8e6";
            version = "1";

        }
        public DIYABET_KOMPLIKASYONLARI(string Code, string Value)
        {
            codeSystemGuid = "0d4c699c-06ca-4983-b3b5-617dd5def8e6";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI : CodeBase
    {
        public DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI()
        {
            codeSystemGuid = "8c0e3f06-e381-4415-9446-a6251d655f91";
            version = "1";

        }
        public DIYET_TEDAVISI_TIBBI_BESLENME_TEDAVISI(string Code, string Value)
        {
            codeSystemGuid = "8c0e3f06-e381-4415-9446-a6251d655f91";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI : CodeBase
    {
        public MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI()
        {
            codeSystemGuid = "7516d5d8-7ed7-4bbc-88f6-cd26d7925c16";
            version = "1";

        }
        public MORBID_OBEZ_HASTA_LENFATIK_ODEM_VARLIGI(string Code, string Value)
        {
            codeSystemGuid = "7516d5d8-7ed7-4bbc-88f6-cd26d7925c16";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class OBEZITE_ILAC_TEDAVISI : CodeBase
    {
        public OBEZITE_ILAC_TEDAVISI()
        {
            codeSystemGuid = "e263f61b-bacb-482e-b048-f6eb89a6b3ba";
            version = "1";

        }
        public OBEZITE_ILAC_TEDAVISI(string Code, string Value)
        {
            codeSystemGuid = "e263f61b-bacb-482e-b048-f6eb89a6b3ba";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class PSIKOLOJIK_TEDAVI : CodeBase
    {
        public PSIKOLOJIK_TEDAVI()
        {
            codeSystemGuid = "e6e4e0ab-4f88-4e28-99cd-dd0dadcfbf3f";
            version = "1";

        }
        public PSIKOLOJIK_TEDAVI(string Code, string Value)
        {
            codeSystemGuid = "e6e4e0ab-4f88-4e28-99cd-dd0dadcfbf3f";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class EGZERSIZ : CodeBase
    {
        public EGZERSIZ()
        {
            codeSystemGuid = "f61204f8-08d4-4aae-9032-893f58319183";
            version = "1";

        }
        public EGZERSIZ(string Code, string Value)
        {
            codeSystemGuid = "f61204f8-08d4-4aae-9032-893f58319183";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BIRLIKTE_GORULEN_EK_HASTALIKLAR : CodeBase
    {
        public BIRLIKTE_GORULEN_EK_HASTALIKLAR()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";

        }
        public BIRLIKTE_GORULEN_EK_HASTALIKLAR(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class KLINIK_DURUMU : CodeBase
    {
        public KLINIK_DURUMU()
        {
            codeSystemGuid = "6007b4c1-767d-4ed7-b9fd-425a71356e8c";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public KLINIK_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "6007b4c1-767d-4ed7-b9fd-425a71356e8c";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class KLINIK_KAPALI_OLMA_NEDENI : CodeBase
    {
        public KLINIK_KAPALI_OLMA_NEDENI()
        {
            codeSystemGuid = "698206a8-9533-46d4-9cfa-a3ace88cb57a";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public KLINIK_KAPALI_OLMA_NEDENI(string Code, string Value)
        {
            codeSystemGuid = "698206a8-9533-46d4-9cfa-a3ace88cb57a";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class GOREV_TURU : CodeBase
    {
        public GOREV_TURU()
        {
            codeSystemGuid = "21cf297c-ccaa-4ae4-98f7-e39a0121bcbb";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public GOREV_TURU(string Code, string Value)
        {
            codeSystemGuid = "21cf297c-ccaa-4ae4-98f7-e39a0121bcbb";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class PERSONEL_GOREV_KODU : CodeBase
    {
        public PERSONEL_GOREV_KODU()
        {
            codeSystemGuid = "c1dcdc84-b1a4-401b-8db3-1eb20afaaa74";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public PERSONEL_GOREV_KODU(string Code, string Value)
        {
            codeSystemGuid = "c1dcdc84-b1a4-401b-8db3-1eb20afaaa74";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class MUDAHALE : CodeBase
    {
        public MUDAHALE()
        {
            codeSystemGuid = "c3eb10bb-27b9-6344-e043-14031b0a5679";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public MUDAHALE(string Code, string Value)
        {
            codeSystemGuid = "c3eb10bb-27b9-6344-e043-14031b0a5679";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class TEDAVI_EDILEN_DISIN_KODU : CodeBase
    {
        public TEDAVI_EDILEN_DISIN_KODU()
        {
            codeSystemGuid = "d5743829-cf07-4dda-bfb5-69439599628a";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public TEDAVI_EDILEN_DISIN_KODU(string Code, string Value)
        {
            codeSystemGuid = "d5743829-cf07-4dda-bfb5-69439599628a";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class MEVCUT_DIS_DURUMU : CodeBase
    {
        public MEVCUT_DIS_DURUMU()
        {
            codeSystemGuid = "633f6442-19f4-419c-a7c9-9b2e0bd16a00";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public MEVCUT_DIS_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "633f6442-19f4-419c-a7c9-9b2e0bd16a00";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class MEVCUT_DIS_KODU : CodeBase
    {
        public MEVCUT_DIS_KODU()
        {
            codeSystemGuid = "d5743829-cf07-4dda-bfb5-69439599628a";
            version = "1";
            code = string.Empty;
            value = string.Empty;

        }
        public MEVCUT_DIS_KODU(string Code, string Value)
        {
            codeSystemGuid = "d5743829-cf07-4dda-bfb5-69439599628a";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class KLINIK_KALITE_TANIM : CodeBase
    {
        public KLINIK_KALITE_TANIM()
        {
            codeSystemGuid = "4fa9b630-c081-44e1-8b8c-0ef0f967c17d";
            version = "1";

        }
        public KLINIK_KALITE_TANIM(string Code, string Value)
        {
            codeSystemGuid = "4fa9b630-c081-44e1-8b8c-0ef0f967c17d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class GELDIGI_ULKE : CodeBase
    {
        public GELDIGI_ULKE()
        {
            codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
            version = "1";

        }

        public GELDIGI_ULKE(string Code, string Value)
        {
            codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class HASTA_TIPI : CodeBase
    {
        public HASTA_TIPI()
        {
            codeSystemGuid = "4f4fd85e-6f52-4c38-a302-6d5e3d6dc1c4";
            version = "1";

        }

        public HASTA_TIPI(string Code, string Value)
        {
            codeSystemGuid = "4f4fd85e-6f52-4c38-a302-6d5e3d6dc1c4";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class YABANCI_HASTA_TURU : CodeBase
    {
        public YABANCI_HASTA_TURU()
        {
            codeSystemGuid = "d8e52cb9-4aa9-512c-e043-14031b0a419d";
            version = "1";

        }

        public YABANCI_HASTA_TURU(string Code, string Value)
        {
            codeSystemGuid = "d8e52cb9-4aa9-512c-e043-14031b0a419d";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class TARAF_BILGISI : CodeBase
    {
        public TARAF_BILGISI()
        {
            codeSystemGuid = "05c03e8c-79fd-461e-8b78-99c3cfad011e";
            version = "1";

        }

        public TARAF_BILGISI(string Code, string Value)
        {
            codeSystemGuid = "05c03e8c-79fd-461e-8b78-99c3cfad011e";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class SEVK_NEDENI : CodeBase
    {
        public SEVK_NEDENI()
        {
            codeSystemGuid = "8d1f1313-3921-4c01-8403-a2f03ab375f3";
            version = "1";

        }

        public SEVK_NEDENI(string Code, string Value)
        {
            codeSystemGuid = "8d1f1313-3921-4c01-8403-a2f03ab375f3";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class SEVK_TANISI : CodeBase
    {
        public SEVK_TANISI()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";

        }

        public SEVK_TANISI(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class SEVK_EDILEN_POLI_KLINIK : CodeBase
    {
        public SEVK_EDILEN_POLI_KLINIK()
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";

        }

        public SEVK_EDILEN_POLI_KLINIK(string Code, string Value)
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU : CodeBase
    {
        public EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";

        }

        public EVDE_SAGLIK_HIZMETINE_ESAS_HASTALIK_GRUBU(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class TRIAJ : CodeBase
    {
        public TRIAJ()
        {
            codeSystemGuid = "1ddcbef5-4006-41fe-87c0-6190c9801708";
            version = "1";

        }

        public TRIAJ(string Code, string Value)
        {
            codeSystemGuid = "1ddcbef5-4006-41fe-87c0-6190c9801708";
            version = "1";
            code = Code;
            value = Value;

        }
    }
    public class OLUM_YERI : CodeBase
    {
        public OLUM_YERI()
        {
            codeSystemGuid = "a4a991c6-70fa-4e40-9ffe-aaea2150faf2";
            version = "1";

        }

        public OLUM_YERI(string Code, string Value)
        {
            codeSystemGuid = "a4a991c6-70fa-4e40-9ffe-aaea2150faf2";
            version = "1";
            code = Code;
            value = Value;

        }
    }
    public class OTOPSI_DURUMU : CodeBase
    {
        public OTOPSI_DURUMU()
        {
            codeSystemGuid = "3854f1ab-d485-4882-9811-e1ec26ae35eb";
            version = "1";

        }

        public OTOPSI_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "3854f1ab-d485-4882-9811-e1ec26ae35eb";
            version = "1";
            code = Code;
            value = Value;

        }
    }
    public class YARALANMANIN_YERI : CodeBase
    {
        public YARALANMANIN_YERI()
        {
            codeSystemGuid = "aab59c51-81bf-46ca-9743-d08288c845cb";
            version = "1";

        }

        public YARALANMANIN_YERI(string Code, string Value)
        {
            codeSystemGuid = "aab59c51-81bf-46ca-9743-d08288c845cb";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class OLUM_NEDENI_TANI_KODU : CodeBase
    {
        public OLUM_NEDENI_TANI_KODU()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";

        }

        public OLUM_NEDENI_TANI_KODU(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class OLUM_NEDENI_TURU : CodeBase
    {
        public OLUM_NEDENI_TURU()
        {
            codeSystemGuid = "95c5182e-9715-4c27-b91c-f178dc383b21";
            version = "1";

        }

        public OLUM_NEDENI_TURU(string Code, string Value)
        {
            codeSystemGuid = "95c5182e-9715-4c27-b91c-f178dc383b21";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class OLUM_SEKLI : CodeBase
    {
        public OLUM_SEKLI()
        {
            codeSystemGuid = "2ae7bfff-3f84-4d21-a9d9-8cdbfe693f08";
            version = "1";

        }

        public OLUM_SEKLI(string Code, string Value)
        {
            codeSystemGuid = "2ae7bfff-3f84-4d21-a9d9-8cdbfe693f08";
            version = "1";
            code = Code;
            value = Value;

        }
    }

    public class ASI_ISLEM_TURU : CodeBase
    {
        public ASI_ISLEM_TURU()
        {
            codeSystemGuid = "5fff8778-89a4-4045-b33e-a7ffe0de0179";
            version = "1";

        }
        public ASI_ISLEM_TURU(string Code, string Value)
        {
            codeSystemGuid = "5fff8778-89a4-4045-b33e-a7ffe0de0179";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class DGT_UYGULAMASINI_YAPAN_KISI : CodeBase
    {
        public DGT_UYGULAMASINI_YAPAN_KISI()
        {
            codeSystemGuid = "be92738b-e77e-47d4-9afb-266eca7c9ab9";
            version = "1";
        
        }
        public DGT_UYGULAMASINI_YAPAN_KISI(string Code, string Value)
        {
            codeSystemGuid = "be92738b-e77e-47d4-9afb-266eca7c9ab9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class DGT_UYGULAMA_YERI : CodeBase
    {
        public DGT_UYGULAMA_YERI()
        {
            codeSystemGuid = "92ac5591-0042-4461-8d9b-4e0dfc7f086f";
            version = "1";
        }
        public DGT_UYGULAMA_YERI(string Code, string Value)
        {
            codeSystemGuid = "92ac5591-0042-4461-8d9b-4e0dfc7f086f";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class HASTANIN_TEDAVIYE_UYUMU : CodeBase
    {
        public HASTANIN_TEDAVIYE_UYUMU()
        {
            codeSystemGuid = "f3db1582-000e-47e8-a08c-8fe76ec37891";
            version = "1";
        }
        public HASTANIN_TEDAVIYE_UYUMU(string Code, string Value)
        {
            codeSystemGuid = "f3db1582-000e-47e8-a08c-8fe76ec37891";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class KULTUR_SONUCU : CodeBase
    {
        public KULTUR_SONUCU()
        {
            codeSystemGuid = "416e90f1-2de1-4739-a99e-00975bdeca26";
            version = "1";

        }
        public KULTUR_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "416e90f1-2de1-4739-a99e-00975bdeca26";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class VEREM_HASTASI_TEDAVI_YONTEMI : CodeBase
    {
        public VEREM_HASTASI_TEDAVI_YONTEMI()
        {
            codeSystemGuid = "eeb4ec17-28e7-4476-9ce9-21c5bd660b86";
            version = "1";

        }
        public VEREM_HASTASI_TEDAVI_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "eeb4ec17-28e7-4476-9ce9-21c5bd660b86";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class VEREM_OLGU_TANIMI : CodeBase
    {
        public VEREM_OLGU_TANIMI()
        {
            codeSystemGuid = "aaf78ab1-0d00-4dd5-8b70-bd9a6c3a2a0a";
            version = "1";

        }
        public VEREM_OLGU_TANIMI(string Code, string Value)
        {
            codeSystemGuid = "aaf78ab1-0d00-4dd5-8b70-bd9a6c3a2a0a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class YAYMA_SONUCU : CodeBase
    {
        public YAYMA_SONUCU()
        {
            codeSystemGuid = "82f99fcc-5282-4132-b5ff-70af5ec38a17";
            version = "1";

        }
        public YAYMA_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "82f99fcc-5282-4132-b5ff-70af5ec38a17";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class VEREM_HASTALIGININ_TUTULUM_YERI : CodeBase
    {
        public VEREM_HASTALIGININ_TUTULUM_YERI()
        {
            codeSystemGuid = "dc0248b9-4444-4ab7-bd8b-02355130611e";
            version = "1";

        }
        public VEREM_HASTALIGININ_TUTULUM_YERI(string Code, string Value)
        {
            codeSystemGuid = "dc0248b9-4444-4ab7-bd8b-02355130611e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class VEREM_HASTASI_KLINIK_ORNEGI : CodeBase
    {
        public VEREM_HASTASI_KLINIK_ORNEGI()
        {
            codeSystemGuid = "64bd7f03-db1d-4234-b77f-0496e22c6c45";
            version = "1";

        }
        public VEREM_HASTASI_KLINIK_ORNEGI(string Code, string Value)
        {
            codeSystemGuid = "64bd7f03-db1d-4234-b77f-0496e22c6c45";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ILAC_ADI_VEREM : CodeBase
    {
        public ILAC_ADI_VEREM()
        {
            codeSystemGuid = "932c2f19-dfd3-45c8-94c3-98ce9914425a";
            version = "1";

        }
        public ILAC_ADI_VEREM(string Code, string Value)
        {
            codeSystemGuid = "932c2f19-dfd3-45c8-94c3-98ce9914425a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ILAC_DIRENCI_VEREM : CodeBase
    {
        public ILAC_DIRENCI_VEREM()
        {
            codeSystemGuid = "06f4cabf-04d0-4a64-882c-ec73798a225c";
            version = "1";

        }
        public ILAC_DIRENCI_VEREM(string Code, string Value)
        {
            codeSystemGuid = "06f4cabf-04d0-4a64-882c-ec73798a225c";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class VEREM_TEDAVI_SONUCU : CodeBase
    {
        public VEREM_TEDAVI_SONUCU()
        {
            codeSystemGuid = "761d469a-9755-48e8-926b-49dd023ec914";
            version = "1";

        }
        public VEREM_TEDAVI_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "761d469a-9755-48e8-926b-49dd023ec914";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class RADYOLOJI_LOINC : CodeBase
    {
        public RADYOLOJI_LOINC()
        {
            codeSystemGuid = "39aef8d6-9b53-4b56-8c73-2f53b0599094";
            version = "1";
        }
        public RADYOLOJI_LOINC(string Code, string Value)
        {
            codeSystemGuid = "39aef8d6-9b53-4b56-8c73-2f53b0599094";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BEBEGIN_BESLENME_DURUMU : CodeBase
    {
        public BEBEGIN_BESLENME_DURUMU()
        {
            codeSystemGuid = "7f29ff54-3810-4875-9dda-01ac0d70fa21";
            version = "1";

        }
        public BEBEGIN_BESLENME_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "7f29ff54-3810-4875-9dda-01ac0d70fa21";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BEBEK_OLUM_NEDENLERI : CodeBase
    {
        public BEBEK_OLUM_NEDENLERI()
        {
            codeSystemGuid = "ae5efc06-8f12-4f4e-9c50-3cc5e5dfa5de";
            version = "1";

        }
        public BEBEK_OLUM_NEDENLERI(string Code, string Value)
        {
            codeSystemGuid = "ae5efc06-8f12-4f4e-9c50-3cc5e5dfa5de";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class GEBELIK_ARALIGI : CodeBase
    {
        public GEBELIK_ARALIGI()
        {
            codeSystemGuid = "fc683bce-5fc5-4aae-9924-33a84a4873fd";
            version = "1";

        }
        public GEBELIK_ARALIGI(string Code, string Value)
        {
            codeSystemGuid = "fc683bce-5fc5-4aae-9924-33a84a4873fd";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class GELISIM_TABLOSU_BILGILERININ_SORGULANMASI : CodeBase
    {
        public GELISIM_TABLOSU_BILGILERININ_SORGULANMASI()
        {
            codeSystemGuid = "b0f8712e-a51b-427a-a554-a21574abb07b";
            version = "1";

        }
        public GELISIM_TABLOSU_BILGILERININ_SORGULANMASI(string Code, string Value)
        {
            codeSystemGuid = "b0f8712e-a51b-427a-a554-a21574abb07b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI : CodeBase
    {
        public EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI()
        {
            codeSystemGuid = "3e30ff47-ed6f-425c-b099-5a4a8121fa10";
            version = "1";

        }
        public EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI(string Code, string Value)
        {
            codeSystemGuid = "3e30ff47-ed6f-425c-b099-5a4a8121fa10";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BEBEGIN_COCUGUN_RISK_FAKTORLERINE_YAPILAN_MUDAHALE : CodeBase
    {
        public BEBEGIN_COCUGUN_RISK_FAKTORLERINE_YAPILAN_MUDAHALE()
        {
            codeSystemGuid = "27f5f375-1755-4d5b-ba13-0b0f6817bfa5";
            version = "1";

        }
        public BEBEGIN_COCUGUN_RISK_FAKTORLERINE_YAPILAN_MUDAHALE(string Code, string Value)
        {
            codeSystemGuid = "27f5f375-1755-4d5b-ba13-0b0f6817bfa5";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BEBEK_COCUKTA_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI : CodeBase
    {
        public BEBEK_COCUKTA_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI()
        {
            codeSystemGuid = "9d81738b-2e2d-4251-b397-34dfb014dc9b";
            version = "1";

        }
        public BEBEK_COCUKTA_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI(string Code, string Value)
        {
            codeSystemGuid = "9d81738b-2e2d-4251-b397-34dfb014dc9b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class KACINCI_LOHUSA_IZLEM : CodeBase
    {
        public KACINCI_LOHUSA_IZLEM()
        {
            codeSystemGuid = "05d2b394-9c2b-4b2a-8a3a-8b5023187502";
            version = "1";

        }
        public KACINCI_LOHUSA_IZLEM(string Code, string Value)
        {
            codeSystemGuid = "05d2b394-9c2b-4b2a-8a3a-8b5023187502";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class POSTPARTUM_DEPRESYON : CodeBase
    {
        public POSTPARTUM_DEPRESYON()
        {
            codeSystemGuid = "8e9f8b79-e70a-427f-ad8c-add091dd4a7c";
            version = "1";

        }
        public POSTPARTUM_DEPRESYON(string Code, string Value)
        {
            codeSystemGuid = "8e9f8b79-e70a-427f-ad8c-add091dd4a7c";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class UTERUS_INVOLUSYON : CodeBase
    {
        public UTERUS_INVOLUSYON()
        {
            codeSystemGuid = "d7df9348-aefb-1248-e040-7c0a02161f00";
            version = "1";

        }
        public UTERUS_INVOLUSYON(string Code, string Value)
        {
            codeSystemGuid = "d7df9348-aefb-1248-e040-7c0a02161f00";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
  

    public class GOZLUK_RECETE_TIPI : CodeBase
    {
        public GOZLUK_RECETE_TIPI()
        {
            codeSystemGuid = "ca1c2edc-7030-43cf-8fef-6ff86be2bcce";
            version = "1";
        }
        public GOZLUK_RECETE_TIPI(string Code, string Value)
        {
            codeSystemGuid = "ca1c2edc-7030-43cf-8fef-6ff86be2bcce";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class GOZLUK_TURU : CodeBase
    {
        public GOZLUK_TURU()
        {
            codeSystemGuid = "7132312f-4bbb-4087-866f-88823f69aa93";
            version = "1";
        }
        public GOZLUK_TURU(string Code, string Value)
        {
            codeSystemGuid = "7132312f-4bbb-4087-866f-88823f69aa93";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class CAM_TIPI : CodeBase
    {
        public CAM_TIPI()
        {
            codeSystemGuid = "7f9adcbb-4ff2-47b8-b323-f48497dd3ae9";
            version = "1";
        }
        public CAM_TIPI(string Code, string Value)
        {
            codeSystemGuid = "7f9adcbb-4ff2-47b8-b323-f48497dd3ae9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class CAM_RENGI : CodeBase
    {
        public CAM_RENGI()
        {
            codeSystemGuid = "13391c91-140f-411a-a9da-b5a28ee00e32";
            version = "1";
        }
        public CAM_RENGI(string Code, string Value)
        {
            codeSystemGuid = "13391c91-140f-411a-a9da-b5a28ee00e32";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class CAM_LENS_SECIMI : CodeBase
    {
        public CAM_LENS_SECIMI()
        {
            codeSystemGuid = "3e25498d-74e7-466b-8f4d-cb93934ab9ad";
            version = "1";
        }
        public CAM_LENS_SECIMI(string Code, string Value)
        {
            codeSystemGuid = "3e25498d-74e7-466b-8f4d-cb93934ab9ad";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class TELESKOPIK_GOZLUK_TIPI : CodeBase
    {
        public TELESKOPIK_GOZLUK_TIPI()
        {
            codeSystemGuid = "d18f100b-454e-40a1-919c-ce4c80d8d228";
            version = "1";
        }
        public TELESKOPIK_GOZLUK_TIPI(string Code, string Value)
        {
            codeSystemGuid = "d18f100b-454e-40a1-919c-ce4c80d8d228";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class TELESKOPIK_GOZLUK_TURU : CodeBase
    {
        public TELESKOPIK_GOZLUK_TURU()
        {
            codeSystemGuid = "63cdd8a2-3b01-4c91-8511-ac26aac649f4";
            version = "1";
        }
        public TELESKOPIK_GOZLUK_TURU(string Code, string Value)
        {
            codeSystemGuid = "63cdd8a2-3b01-4c91-8511-ac26aac649f4";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class AGIZDAN_SIVI_TEDAVISI : CodeBase
    {
        public AGIZDAN_SIVI_TEDAVISI()
        {
            codeSystemGuid = "e5c10731-8c56-4664-b483-1790fd2132d3";
            version = "1";

        }
        public AGIZDAN_SIVI_TEDAVISI(string Code, string Value)
        {
            codeSystemGuid = "e5c10731-8c56-4664-b483-1790fd2132d3";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KACINCI_IZLEM : CodeBase
    {
        public KACINCI_IZLEM()
        {
            codeSystemGuid = "402e5a45-f723-4309-9cb8-686358dee75a";
            version = "1";
        }
        public KACINCI_IZLEM(string Code, string Value)
        {
            codeSystemGuid = "402e5a45-f723-4309-9cb8-686358dee75a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class TOPUK_KANI : CodeBase
    {
        public TOPUK_KANI()
        {
            codeSystemGuid = "39de4d69-b1db-4333-95a1-7a0d9faffe51";
            version = "1";

        }
        public TOPUK_KANI(string Code, string Value)
        {
            codeSystemGuid = "39de4d69-b1db-4333-95a1-7a0d9faffe51";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BEBEKTE_RISK_FAKTORLERI : CodeBase
    {
        public BEBEKTE_RISK_FAKTORLERI()
        {
            codeSystemGuid = "75c4b52d-6d04-4d01-aca9-f294095cc992";
            version = "1";

        }
        public BEBEKTE_RISK_FAKTORLERI(string Code, string Value)
        {
            codeSystemGuid = "75c4b52d-6d04-4d01-aca9-f294095cc992";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class TARAMA_SONUCU : CodeBase
    {
        public TARAMA_SONUCU()
        {
            codeSystemGuid = "578ce88f-5742-4ac0-84e7-083f7776ec16";
            version = "1";

        }
        public TARAMA_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "578ce88f-5742-4ac0-84e7-083f7776ec16";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class SIGARA_KULLANIMI : CodeBase
    {
        public SIGARA_KULLANIMI()
        {
            codeSystemGuid = "567e3679-be54-4307-abbf-c499a25fe69e";
            version = "1";
        }
        public SIGARA_KULLANIMI(string Code, string Value)
        {
            codeSystemGuid = "567e3679-be54-4307-abbf-c499a25fe69e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class TUTUN_DUMANINA_MARUZ_KALMA : CodeBase
    {
        public TUTUN_DUMANINA_MARUZ_KALMA()
        {
            codeSystemGuid = "c366b0b6-b15b-4819-920d-a9f465eed764";
            version = "1";
        }
        public TUTUN_DUMANINA_MARUZ_KALMA(string Code, string Value)
        {
            codeSystemGuid = "c366b0b6-b15b-4819-920d-a9f465eed764";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BAGIMLI_OLDUGU_URUN : CodeBase
    {
        public BAGIMLI_OLDUGU_URUN()
        {
            codeSystemGuid = "5342dd3f-5606-47a1-b6be-4a4427a02f4a";
            version = "1";
        }
        public BAGIMLI_OLDUGU_URUN(string Code, string Value)
        {
            codeSystemGuid = "5342dd3f-5606-47a1-b6be-4a4427a02f4a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class TEDAVI_SEKLI : CodeBase
    {
        public TEDAVI_SEKLI()
        {
            codeSystemGuid = "4cf6d20f-f01b-478f-ae96-1d5853030cae";
            version = "1";
        }
        public TEDAVI_SEKLI(string Code, string Value)
        {
            codeSystemGuid = "4cf6d20f-f01b-478f-ae96-1d5853030cae";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TUTUN_TEDAVI_SONUCU : CodeBase
    {
        public TUTUN_TEDAVI_SONUCU()
        {
            codeSystemGuid = "bdc7aa0a-2775-4149-9303-bf1bdc08c31a";
            version = "1";
        }
        public TUTUN_TEDAVI_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "bdc7aa0a-2775-4149-9303-bf1bdc08c31a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class YOGUN_BAKIM_SEVIYE_BILGISI : CodeBase
    {
        public YOGUN_BAKIM_SEVIYE_BILGISI()
        {
            codeSystemGuid = "3c20a43e-74ee-4a04-9649-05359b5f9c5d";
            version = "1";
        }
        public YOGUN_BAKIM_SEVIYE_BILGISI(string Code, string Value)
        {
            codeSystemGuid = "3c20a43e-74ee-4a04-9649-05359b5f9c5d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class YOGUN_BAKIM_YATIS_TANISI : CodeBase
    {
        public YOGUN_BAKIM_YATIS_TANISI()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
        }
        public YOGUN_BAKIM_YATIS_TANISI(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class KUDUZ_PROFILAKSISI_TAMAMLANMA_DURUMU : CodeBase
    {
        public KUDUZ_PROFILAKSISI_TAMAMLANMA_DURUMU()
        {
            codeSystemGuid = "033f9c18-2d1b-41a1-a605-082595f93632";
            version = "1";
        }
        public KUDUZ_PROFILAKSISI_TAMAMLANMA_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "033f9c18-2d1b-41a1-a605-082595f93632";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class KUDUZ_PROFILAKSISI_SONLANMA_DURUMU : CodeBase
    {
        public KUDUZ_PROFILAKSISI_SONLANMA_DURUMU()
        {
            codeSystemGuid = "033f9c18-2d1b-41a1-a605-082595f93632";
            version = "1";
        }
        public KUDUZ_PROFILAKSISI_SONLANMA_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "033f9c18-2d1b-41a1-a605-082595f93632";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    

    public class UYGULANAN_KUDUZ_PROFILAKSISI : CodeBase
    {
        public UYGULANAN_KUDUZ_PROFILAKSISI()
        {
            codeSystemGuid = "db1af0ba-193c-424f-a2fe-710001d552c9";
            version = "1";
        }
        public UYGULANAN_KUDUZ_PROFILAKSISI(string Code, string Value)
        {
            codeSystemGuid = "db1af0ba-193c-424f-a2fe-710001d552c9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class YAPTIRACAGINI_BEYAN_ETTIGI_TSM : CodeBase
    {
        public YAPTIRACAGINI_BEYAN_ETTIGI_TSM()
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
        }
        public YAPTIRACAGINI_BEYAN_ETTIGI_TSM(string Code, string Value)
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class HAYVANIN_MEVCUT_DURUMU : CodeBase
    {
        public HAYVANIN_MEVCUT_DURUMU()
        {
            codeSystemGuid = "83e7f79b-0a82-4fd6-8174-ba0a2555008e";
            version = "1";
        }
        public HAYVANIN_MEVCUT_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "83e7f79b-0a82-4fd6-8174-ba0a2555008e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class HAYVANIN_SAHIPLIK_DURUMU : CodeBase
    {
        public HAYVANIN_SAHIPLIK_DURUMU()
        {
            codeSystemGuid = "cb60a9b4-4063-4d09-a2b5-ea3dcb6586bf";
            version = "1";
        }
        public HAYVANIN_SAHIPLIK_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "cb60a9b4-4063-4d09-a2b5-ea3dcb6586bf";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class IMMUNGLOBULIN_TURU : CodeBase
    {
        public IMMUNGLOBULIN_TURU()
        {
            codeSystemGuid = "ecdaec49-6f7c-4fa9-9cbd-2dd40cfe39d1";
            version = "1";
        }
        public IMMUNGLOBULIN_TURU(string Code, string Value)
        {
            codeSystemGuid = "ecdaec49-6f7c-4fa9-9cbd-2dd40cfe39d1";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class KATEGORIZASYON : CodeBase
    {
        public KATEGORIZASYON()
        {
            codeSystemGuid = "4b099801-6c9c-4c74-a29e-5748be1d1cfd";
            version = "1";
        }
        public KATEGORIZASYON(string Code, string Value)
        {
            codeSystemGuid = "4b099801-6c9c-4c74-a29e-5748be1d1cfd";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class KUDUZ_SUPHELI_TEMAS_DEGERLENDIRME_DURUMU : CodeBase
    {
        public KUDUZ_SUPHELI_TEMAS_DEGERLENDIRME_DURUMU()
        {
            codeSystemGuid = "67be197d-3af4-40f9-b40e-59b6e86d8b44";
            version = "1";
        }
        public KUDUZ_SUPHELI_TEMAS_DEGERLENDIRME_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "67be197d-3af4-40f9-b40e-59b6e86d8b44";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class RISKLI_TEMASA_SEBEP_OLAN_HAYVAN : CodeBase
    {
        public RISKLI_TEMASA_SEBEP_OLAN_HAYVAN()
        {
            codeSystemGuid = "81eac734-5328-4f90-bae0-7191311ebbaf";
            version = "1";
        }
        public RISKLI_TEMASA_SEBEP_OLAN_HAYVAN(string Code, string Value)
        {
            codeSystemGuid = "81eac734-5328-4f90-bae0-7191311ebbaf";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI : CodeBase
    {
        public KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI()
        {
            codeSystemGuid = "f71eb1ea-1854-4836-9319-3c549b8d49a5";
            version = "1";
        }
        public KISIYE_PLANLANAN_KUDUZ_PROFILAKSISI(string Code, string Value)
        {
            codeSystemGuid = "f71eb1ea-1854-4836-9319-3c549b8d49a5";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class RISKLI_TEMAS_TIPI : CodeBase
    {
        public RISKLI_TEMAS_TIPI()
        {
            codeSystemGuid = "76578724-3b1a-433e-aba6-40ffd47d6dd7";
            version = "1";
        }
        public RISKLI_TEMAS_TIPI(string Code, string Value)
        {
            codeSystemGuid = "76578724-3b1a-433e-aba6-40ffd47d6dd7";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PRIMER_TANI : CodeBase
    {
        public PRIMER_TANI()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
        }
        public PRIMER_TANI(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class DIYALIZ_TEDAVISI_YONTEMI : CodeBase
    {
        public DIYALIZ_TEDAVISI_YONTEMI()
        {
            codeSystemGuid = "0a573429-c8d3-40c3-abd3-a46f3919d721";
            version = "1";
        }
        public DIYALIZ_TEDAVISI_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "0a573429-c8d3-40c3-abd3-a46f3919d721";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class HEMODIYALIZE_GECME_NEDENLERI : CodeBase
    {
        public HEMODIYALIZE_GECME_NEDENLERI()
        {
            codeSystemGuid = "044ba38d-1794-4798-90c8-f9b7097202e7";
            version = "1";
        }
        public HEMODIYALIZE_GECME_NEDENLERI(string Code, string Value)
        {
            codeSystemGuid = "044ba38d-1794-4798-90c8-f9b7097202e7";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ONCEKI_RRT_YONTEMI : CodeBase
    {
        public ONCEKI_RRT_YONTEMI()
        {
            codeSystemGuid = "2b54e14f-011c-4007-a0e3-9fcaaed1c0ff";
            version = "1";
        }
        public ONCEKI_RRT_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "2b54e14f-011c-4007-a0e3-9fcaaed1c0ff";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class BILINC : CodeBase
    {
        public BILINC()
        {
            codeSystemGuid = "556485f3-9765-4bff-8147-fba4ac1f2a29";
            version = "1";
        }
        public BILINC(string Code, string Value)
        {
            codeSystemGuid = "556485f3-9765-4bff-8147-fba4ac1f2a29";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class SOLUNUM : CodeBase
    {
        public SOLUNUM()
        {
            codeSystemGuid = "fec05758-b107-4a40-acbc-61b23a3243d5";
            version = "1";
        }
        public SOLUNUM(string Code, string Value)
        {
            codeSystemGuid = "fec05758-b107-4a40-acbc-61b23a3243d5";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class NAKIL_YOLU : CodeBase
    {
        public NAKIL_YOLU()
        {
            codeSystemGuid = "139c2d5f-c8a8-4437-b4f3-5f28c14d905e";
            version = "1";
        }
        public NAKIL_YOLU(string Code, string Value)
        {
            codeSystemGuid = "139c2d5f-c8a8-4437-b4f3-5f28c14d905e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class DOKTOR_IHTIYACI : CodeBase
    {
        public DOKTOR_IHTIYACI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public DOKTOR_IHTIYACI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class MALZEME : CodeBase
    {
        public MALZEME()
        {
            codeSystemGuid = "47c43bbf-c18b-4a51-bcdd-a32f72e53c42";
            version = "1";
        }
        public MALZEME(string Code, string Value)
        {
            codeSystemGuid = "47c43bbf-c18b-4a51-bcdd-a32f72e53c42";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class ANTIHIPERTANSIF_ILAC_KULLANIM_DURUMU : CodeBase
    {
        public ANTIHIPERTANSIF_ILAC_KULLANIM_DURUMU()
        {
            codeSystemGuid = "c3b1c7db-fc3a-4a8c-9c02-0583215eed24";
            version = "1";
        }
        public ANTIHIPERTANSIF_ILAC_KULLANIM_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "c3b1c7db-fc3a-4a8c-9c02-0583215eed24";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class DAMAR_ERISIM_YOLU : CodeBase
    {
        public DAMAR_ERISIM_YOLU()
        {
            codeSystemGuid = "74c60a72-ef10-450a-9e95-0cdae6fe8490";
            version = "1";
        }
        public DAMAR_ERISIM_YOLU(string Code, string Value)
        {
            codeSystemGuid = "74c60a72-ef10-450a-9e95-0cdae6fe8490";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class DIYALIZE_GIRME_SIKLIGI : CodeBase
    {
        public DIYALIZE_GIRME_SIKLIGI()
        {
            codeSystemGuid = "ced10d4a-2e20-4c30-bd42-72740c66c348";
            version = "1";
        }
        public DIYALIZE_GIRME_SIKLIGI(string Code, string Value)
        {
            codeSystemGuid = "ced10d4a-2e20-4c30-bd42-72740c66c348";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class DIYALIZOR_ALANI : CodeBase
    {
        public DIYALIZOR_ALANI()
        {
            codeSystemGuid = "a96fa435-723f-43d5-b5c2-26baf2871354";
            version = "1";
        }
        public DIYALIZOR_ALANI(string Code, string Value)
        {
            codeSystemGuid = "a96fa435-723f-43d5-b5c2-26baf2871354";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class DIYALIZOR_TIPI : CodeBase
    {
        public DIYALIZOR_TIPI()
        {
            codeSystemGuid = "ef5f5e04-7ad0-47e0-be5e-d8b508d19eda";
            version = "1";
        }
        public DIYALIZOR_TIPI(string Code, string Value)
        {
            codeSystemGuid = "ef5f5e04-7ad0-47e0-be5e-d8b508d19eda";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class KAN_AKIM_HIZI : CodeBase
    {
        public KAN_AKIM_HIZI()
        {
            codeSystemGuid = "c4bdb87e-da85-47fd-ab05-c5f6633d22e9";
            version = "1";
        }
        public KAN_AKIM_HIZI(string Code, string Value)
        {
            codeSystemGuid = "c4bdb87e-da85-47fd-ab05-c5f6633d22e9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class KULLANILAN_DIYALIZ_TEDAVISI : CodeBase
    {
        public KULLANILAN_DIYALIZ_TEDAVISI()
        {
            codeSystemGuid = "d60416ba-f319-437b-8e02-e992d57a3612";
            version = "1";
        }
        public KULLANILAN_DIYALIZ_TEDAVISI(string Code, string Value)
        {
            codeSystemGuid = "d60416ba-f319-437b-8e02-e992d57a3612";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PERITONEAL_GECIRGENLIK : CodeBase
    {
        public PERITONEAL_GECIRGENLIK()
        {
            codeSystemGuid = "9b552b26-2bee-4000-8ff3-b954b9825a50";
            version = "1";
        }
        public PERITONEAL_GECIRGENLIK(string Code, string Value)
        {
            codeSystemGuid = "9b552b26-2bee-4000-8ff3-b954b9825a50";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PERITON_DIYALIZI_KATETER_TIPI : CodeBase
    {
        public PERITON_DIYALIZI_KATETER_TIPI()
        {
            codeSystemGuid = "2bf0796b-a8fd-4c51-81a3-59ef5e8d6a10";
            version = "1";
        }
        public PERITON_DIYALIZI_KATETER_TIPI(string Code, string Value)
        {
            codeSystemGuid = "2bf0796b-a8fd-4c51-81a3-59ef5e8d6a10";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PERITON_DIYALIZ_KATETER_YERLESTIRME_YONTEMI : CodeBase
    {
        public PERITON_DIYALIZ_KATETER_YERLESTIRME_YONTEMI()
        {
            codeSystemGuid = "1ba51ab0-da51-4abf-828a-ac386459d265";
            version = "1";
        }
        public PERITON_DIYALIZ_KATETER_YERLESTIRME_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "1ba51ab0-da51-4abf-828a-ac386459d265";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PERITON_DIYALIZ_TUNEL_YONU : CodeBase
    {
        public PERITON_DIYALIZ_TUNEL_YONU()
        {
            codeSystemGuid = "3c6d5d1c-12d9-4570-a1e5-1a76d595b40a";
            version = "1";
        }
        public PERITON_DIYALIZ_TUNEL_YONU(string Code, string Value)
        {
            codeSystemGuid = "3c6d5d1c-12d9-4570-a1e5-1a76d595b40a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class SINEKALSET : CodeBase
    {
        public SINEKALSET()
        {
            codeSystemGuid = "26abb1b8-2f2c-45ac-b8b5-fc6c572c012a";
            version = "1";
        }
        public SINEKALSET(string Code, string Value)
        {
            codeSystemGuid = "26abb1b8-2f2c-45ac-b8b5-fc6c572c012a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TEDAVININ_SEYRI : CodeBase
    {
        public TEDAVININ_SEYRI()
        {
            codeSystemGuid = "850f9005-04ba-4c45-86f5-34cffdce02b1";
            version = "1";
        }
        public TEDAVININ_SEYRI(string Code, string Value)
        {
            codeSystemGuid = "850f9005-04ba-4c45-86f5-34cffdce02b1";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class AGIRLIK_OLCUM_ZAMANI : CodeBase
    {
        public AGIRLIK_OLCUM_ZAMANI()
        {
            codeSystemGuid = "85a98ad5-7b53-45d6-aa6b-5b84127efbcc";
            version = "1";
        }
        public AGIRLIK_OLCUM_ZAMANI(string Code, string Value)
        {
            codeSystemGuid = "85a98ad5-7b53-45d6-aa6b-5b84127efbcc";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class AKTIF_VITAMIN_D_KULLANIMI : CodeBase
    {
        public AKTIF_VITAMIN_D_KULLANIMI()
        {
            codeSystemGuid = "092fc5cb-1718-4d9e-a084-b666b2654021";
            version = "1";
        }
        public AKTIF_VITAMIN_D_KULLANIMI(string Code, string Value)
        {
            codeSystemGuid = "092fc5cb-1718-4d9e-a084-b666b2654021";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ANEMI_TEDAVISI_YONTEMI : CodeBase
    {
        public ANEMI_TEDAVISI_YONTEMI()
        {
            codeSystemGuid = "6037979e-61af-473e-ac5a-f58839804c34";
            version = "1";
        }
        public ANEMI_TEDAVISI_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "6037979e-61af-473e-ac5a-f58839804c34";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class FOSFOR_BAGLAYICI_AJAN : CodeBase
    {
        public FOSFOR_BAGLAYICI_AJAN()
        {
            codeSystemGuid = "57ac14e2-c27f-4aa1-8044-169bfc826d9e";
            version = "1";
        }
        public FOSFOR_BAGLAYICI_AJAN(string Code, string Value)
        {
            codeSystemGuid = "57ac14e2-c27f-4aa1-8044-169bfc826d9e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PERITON_DIYALIZI_KOMPLIKASYON : CodeBase
    {
        public PERITON_DIYALIZI_KOMPLIKASYON()
        {
            codeSystemGuid = "feb54346-61ae-4c83-ae69-3c3fd159f47d";
            version = "1";
        }
        public PERITON_DIYALIZI_KOMPLIKASYON(string Code, string Value)
        {
            codeSystemGuid = "feb54346-61ae-4c83-ae69-3c3fd159f47d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ALKOL_KULLANIMI : CodeBase
    {
        public ALKOL_KULLANIMI()
        {
            codeSystemGuid = "7e3e39e1-d1d8-481f-b898-174c5efa06e7";
            version = "1";
        }
        public ALKOL_KULLANIMI(string Code, string Value)
        {
            codeSystemGuid = "7e3e39e1-d1d8-481f-b898-174c5efa06e7";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class GONDEREN_BIRIM : CodeBase
    {
        public GONDEREN_BIRIM()
        {
            codeSystemGuid = "0368428a-5077-49c2-a1eb-99d26a210c3d";
            version = "1";
        }
        public GONDEREN_BIRIM(string Code, string Value)
        {
            codeSystemGuid = "0368428a-5077-49c2-a1eb-99d26a210c3d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class IS_DURUMU : CodeBase
    {
        public IS_DURUMU()
        {
            codeSystemGuid = "c5a44219-28d5-4963-984c-93f56e51cfbd";
            version = "1";
        }
        public IS_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "c5a44219-28d5-4963-984c-93f56e51cfbd";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class KULLANILAN_ESAS_MADDE : CodeBase
    {
        public KULLANILAN_ESAS_MADDE()
        {
            codeSystemGuid = "59722280-d12c-4adf-b184-1a5349076211";
            version = "1";
        }
        public KULLANILAN_ESAS_MADDE(string Code, string Value)
        {
            codeSystemGuid = "59722280-d12c-4adf-b184-1a5349076211";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class OGRENIM_DURUMU : CodeBase
    {
        public OGRENIM_DURUMU()
        {
            codeSystemGuid = "3cdc2ba0-03de-46f4-8ace-684c94712349";
            version = "1";
        }
        public OGRENIM_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "3cdc2ba0-03de-46f4-8ace-684c94712349";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TEDAVI_MERKEZI_TIPI : CodeBase
    {
        public TEDAVI_MERKEZI_TIPI()
        {
            codeSystemGuid = "325716a2-5ea4-4cf6-b88d-5fcbe27bd955";
            version = "1";
        }
        public TEDAVI_MERKEZI_TIPI(string Code, string Value)
        {
            codeSystemGuid = "325716a2-5ea4-4cf6-b88d-5fcbe27bd955";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TEDAVI_SONUCU_MADDE_BAGIMLILIGI : CodeBase
    {
        public TEDAVI_SONUCU_MADDE_BAGIMLILIGI()
        {
            codeSystemGuid = "d321b039-82fd-4bd2-b906-44dda0258ab6";
            version = "1";
        }
        public TEDAVI_SONUCU_MADDE_BAGIMLILIGI(string Code, string Value)
        {
            codeSystemGuid = "d321b039-82fd-4bd2-b906-44dda0258ab6";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI : CodeBase
    {
        public UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI()
        {
            codeSystemGuid = "67654983-7af8-4e08-a8fd-d90061cb4725";
            version = "1";
        }
        public UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI(string Code, string Value)
        {
            codeSystemGuid = "67654983-7af8-4e08-a8fd-d90061cb4725";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class YASADIGI_BOLGE : CodeBase
    {
        public YASADIGI_BOLGE()
        {
            codeSystemGuid = "730ea962-cf11-427b-b530-02abbfbc182f";
            version = "1";
        }
        public YASADIGI_BOLGE(string Code, string Value)
        {
            codeSystemGuid = "730ea962-cf11-427b-b530-02abbfbc182f";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU : CodeBase
    {
        public YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU()
        {
            codeSystemGuid = "90cd6c8d-e752-46aa-a6b2-f95261ca9889";
            version = "1";
        }
        public YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "90cd6c8d-e752-46aa-a6b2-f95261ca9889";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class YASAM_BICIMI : CodeBase
    {
        public YASAM_BICIMI()
        {
            codeSystemGuid = "13c79df8-e9f0-4003-9590-71b888b5d0bb";
            version = "1";
        }
        public YASAM_BICIMI(string Code, string Value)
        {
            codeSystemGuid = "13c79df8-e9f0-4003-9590-71b888b5d0bb";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class BULASICI_HASTALIK_DURUMU : CodeBase
    {
        public BULASICI_HASTALIK_DURUMU()
        {
            codeSystemGuid = "881d1b19-1779-40f4-8324-898bdd968f2e";
            version = "1";
        }
        public BULASICI_HASTALIK_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "881d1b19-1779-40f4-8324-898bdd968f2e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class KULLANILAN_DIGER_MADDE : CodeBase
    {
        public KULLANILAN_DIGER_MADDE()
        {
            codeSystemGuid = "59722280-d12c-4adf-b184-1a5349076211";
            version = "1";
        }
        public KULLANILAN_DIGER_MADDE(string Code, string Value)
        {
            codeSystemGuid = "59722280-d12c-4adf-b184-1a5349076211";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class MADDE_KULLANIM_SIKLIGI : CodeBase
    {
        public MADDE_KULLANIM_SIKLIGI()
        {
            codeSystemGuid = "45231382-8544-4b19-b518-0b196d594993";
            version = "1";
        }
        public MADDE_KULLANIM_SIKLIGI(string Code, string Value)
        {
            codeSystemGuid = "45231382-8544-4b19-b518-0b196d594993";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ENJEKTOR_PAYLASIM_DURUMU : CodeBase
    {
        public ENJEKTOR_PAYLASIM_DURUMU()
        {
            codeSystemGuid = "d7420140-0e59-4e86-9fee-ceb0baa66418";
            version = "1";
        }
        public ENJEKTOR_PAYLASIM_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "d7420140-0e59-4e86-9fee-ceb0baa66418";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class MADDE_KULLANIM_YOLU : CodeBase
    {
        public MADDE_KULLANIM_YOLU()
        {
            codeSystemGuid = "6f295203-2ef1-4ebc-915d-6382829330fc";
            version = "1";
        }
        public MADDE_KULLANIM_YOLU(string Code, string Value)
        {
            codeSystemGuid = "6f295203-2ef1-4ebc-915d-6382829330fc";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class INTIHAR_KRIZ_VAKA_TURU : CodeBase
    {
        public INTIHAR_KRIZ_VAKA_TURU()
        {
            codeSystemGuid = "bad13b15-cc1b-453b-802c-e7a257d2a7a0";
            version = "1";

        }
        public INTIHAR_KRIZ_VAKA_TURU(string Code, string Value)
        {
            codeSystemGuid = "bad13b15-cc1b-453b-802c-e7a257d2a7a0";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI : CodeBase
    {
        public INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI()
        {
            codeSystemGuid = "e400057e-d8df-482d-9fa5-4d59571ff35b";
            version = "1";

        }
        public INTIHAR_GIRISIMI_YA_DA_KRIZ_NEDENLERI(string Code, string Value)
        {
            codeSystemGuid = "e400057e-d8df-482d-9fa5-4d59571ff35b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME : CodeBase
    {
        public KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME()
        {
            codeSystemGuid = "baa4ecee-31c8-4fec-bbd6-8982289236c0";
            version = "1";
        }
        public KADINA_YONELIK_SIDDET_SONUCU_YONLENDIRME_VE_DEGERLENDIRME(string Code, string Value)
        {
            codeSystemGuid = "baa4ecee-31c8-4fec-bbd6-8982289236c0";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class SIDDET_TURU : CodeBase
    {
        public SIDDET_TURU()
        {
            codeSystemGuid = "a1abeb83-cc2a-4556-98be-0d5fa6b0980a";
            version = "1";
        }
        public SIDDET_TURU(string Code, string Value)
        {
            codeSystemGuid = "a1abeb83-cc2a-4556-98be-0d5fa6b0980a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class AILESINDE_INTIHAR_GIRISIMI : CodeBase
    {
        public AILESINDE_INTIHAR_GIRISIMI()
        {
            codeSystemGuid = "4e437b5d-4b13-420a-9c34-dc50539aa243";
            version = "1";
        }
        public AILESINDE_INTIHAR_GIRISIMI(string Code, string Value)
        {
            codeSystemGuid = "4e437b5d-4b13-420a-9c34-dc50539aa243";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class AILESINDE_PSIKIYATRIK_VAKA : CodeBase
    {
        public AILESINDE_PSIKIYATRIK_VAKA()
        {
            codeSystemGuid = "6e4539cb-e8d8-436f-aacf-406a073886de";
            version = "1";
        }
        public AILESINDE_PSIKIYATRIK_VAKA(string Code, string Value)
        {
            codeSystemGuid = "6e4539cb-e8d8-436f-aacf-406a073886de";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class INTIHAR_GIRISIMI_GECMISI : CodeBase
    {
        public INTIHAR_GIRISIMI_GECMISI()
        {
            codeSystemGuid = "5ad8d67a-08b9-4952-b348-ed3b53195789";
            version = "1";
        }
        public INTIHAR_GIRISIMI_GECMISI(string Code, string Value)
        {
            codeSystemGuid = "5ad8d67a-08b9-4952-b348-ed3b53195789";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }





    public class PSIKIYATRIK_TEDAVI_GECMISI : CodeBase
    {
        public PSIKIYATRIK_TEDAVI_GECMISI()
        {
            codeSystemGuid = "7cb4bcef-9998-4e0d-a442-8a83800bb614";
            version = "1";
        }
        public PSIKIYATRIK_TEDAVI_GECMISI(string Code, string Value)
        {
            codeSystemGuid = "7cb4bcef-9998-4e0d-a442-8a83800bb614";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


  

    public class INTIHAR_GIRISIMI_YONTEMI : CodeBase
    {
        public INTIHAR_GIRISIMI_YONTEMI()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
        }
        public INTIHAR_GIRISIMI_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class INTIHAR_KRIZ_VAKA_SONUCU : CodeBase
    {
        public INTIHAR_KRIZ_VAKA_SONUCU()
        {
            codeSystemGuid = "7c9c42e2-ecd0-425b-a1bb-73fe23947338";
            version = "1";
        }
        public INTIHAR_KRIZ_VAKA_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "7c9c42e2-ecd0-425b-a1bb-73fe23947338";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PSIKIYATRIK_TANI_GECMISI : CodeBase
    {
        public PSIKIYATRIK_TANI_GECMISI()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
        }
        public PSIKIYATRIK_TANI_GECMISI(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BIR_ONCEKI_DOGUM_DURUMU : CodeBase
    {
        public BIR_ONCEKI_DOGUM_DURUMU()
        {
            codeSystemGuid = "d7e6d65a-b82a-6717-e040-7c0a021654a2";
            version = "1";
        }
        public BIR_ONCEKI_DOGUM_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "d7e6d65a-b82a-6717-e040-7c0a021654a2";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class KULLANILAN_AILE_PLANLAMASI_YONTEMI : CodeBase
    {
        public KULLANILAN_AILE_PLANLAMASI_YONTEMI()
        {
            codeSystemGuid = "24d08065-6a3f-4ee3-b07b-1fe5d83241c1";
            version = "1";
        }
        public KULLANILAN_AILE_PLANLAMASI_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "24d08065-6a3f-4ee3-b07b-1fe5d83241c1";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class AILE_PLANLAMASI_YONTEMI_LOJISTIGI : CodeBase
    {
        public AILE_PLANLAMASI_YONTEMI_LOJISTIGI()
        {
            codeSystemGuid = "8335af99-322d-4aa5-bdaa-f888b351a30a";
            version = "1";
        }
        public AILE_PLANLAMASI_YONTEMI_LOJISTIGI(string Code, string Value)
        {
            codeSystemGuid = "8335af99-322d-4aa5-bdaa-f888b351a30a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI : CodeBase
    {
        public AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI()
        {
            codeSystemGuid = "084620ca-5f25-469b-af47-158f760f16b5";
            version = "1";
        }
        public AILE_PLANLAMASI_YONTEMI_KULLANMAMA_NEDENI(string Code, string Value)
        {
            codeSystemGuid = "084620ca-5f25-469b-af47-158f760f16b5";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI : CodeBase
    {
        public BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI()
        {
            codeSystemGuid = "636bdc8a-eea8-41cf-bcb8-b244cfa8e250";
            version = "1";
        }
        public BIR_ONCEKI_KULLANILAN_AILE_PLANLAMASI_YONTEMI(string Code, string Value)
        {
            codeSystemGuid = "636bdc8a-eea8-41cf-bcb8-b244cfa8e250";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class ANNE_OLUM_ZAMANI : CodeBase
    {
        public ANNE_OLUM_ZAMANI()
        {
            codeSystemGuid = "16073eac-a3f9-4efb-91ac-a08442c240a4";
            version = "1";
        }
        public ANNE_OLUM_ZAMANI(string Code, string Value)
        {
            codeSystemGuid = "16073eac-a3f9-4efb-91ac-a08442c240a4";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class UC_GECIKME_MODELI : CodeBase
    {
        public UC_GECIKME_MODELI()
        {
            codeSystemGuid = "645ec158-0090-4093-aeb0-dabcc7456a4c";
            version = "1";
        }
        public UC_GECIKME_MODELI(string Code, string Value)
        {
            codeSystemGuid = "645ec158-0090-4093-aeb0-dabcc7456a4c";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ANNE_OLUM_NEDENI : CodeBase
    {
        public ANNE_OLUM_NEDENI()
        {
            codeSystemGuid = "b9740b2a-67b5-47e4-beb4-95388d050929";
            version = "1";
        }
        public ANNE_OLUM_NEDENI(string Code, string Value)
        {
            codeSystemGuid = "b9740b2a-67b5-47e4-beb4-95388d050929";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class ALKOL_MADDE_BAGIMLILIGI : CodeBase
    {
        public ALKOL_MADDE_BAGIMLILIGI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public ALKOL_MADDE_BAGIMLILIGI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class BEDENSEL_RUHSAL_ILERI_TETKIK_BULGUSU : CodeBase
    {
        public BEDENSEL_RUHSAL_ILERI_TETKIK_BULGUSU()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public BEDENSEL_RUHSAL_ILERI_TETKIK_BULGUSU(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class GECMIS_HASTALIGA_DAIR_KAYIT : CodeBase
    {
        public GECMIS_HASTALIGA_DAIR_KAYIT()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public GECMIS_HASTALIGA_DAIR_KAYIT(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class GORME_ISITME_KAYBI : CodeBase
    {
        public GORME_ISITME_KAYBI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public GORME_ISITME_KAYBI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PSIKIYATRIK_RAHATSIZLIK : CodeBase
    {
        public PSIKIYATRIK_RAHATSIZLIK()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public PSIKIYATRIK_RAHATSIZLIK(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class UZUV_KAYBI_ORTOPEDIK_RAHATSIZLIK : CodeBase
    {
        public UZUV_KAYBI_ORTOPEDIK_RAHATSIZLIK()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public UZUV_KAYBI_ORTOPEDIK_RAHATSIZLIK(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ASAL_HASTALIK : CodeBase
    {
        public ASAL_HASTALIK()
        {
            codeSystemGuid = "94f19f91-41ed-4bf7-beed-de14090172d9";
            version = "1";
        }
        public ASAL_HASTALIK(string Code, string Value)
        {
            codeSystemGuid = "94f19f91-41ed-4bf7-beed-de14090172d9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ASAL_HASTALIK_TIPI : CodeBase
    {
        public ASAL_HASTALIK_TIPI()
        {
            codeSystemGuid = "5451a206-b7dc-4086-be04-fb929846f348";
            version = "1";
        }
        public ASAL_HASTALIK_TIPI(string Code, string Value)
        {
            codeSystemGuid = "5451a206-b7dc-4086-be04-fb929846f348";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class VEREM_TARAMA_SONUCU : CodeBase
    {
        public VEREM_TARAMA_SONUCU()
        {
            codeSystemGuid = "27e74b69-04ab-48b1-8c83-456f44bf32f7";
            version = "1";
        }
        public VEREM_TARAMA_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "27e74b69-04ab-48b1-8c83-456f44bf32f7";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TARAMA_TURU : CodeBase
    {
        public TARAMA_TURU()
        {
            codeSystemGuid = "52bcc87e-b051-4603-b6d6-43298fb0d443";
            version = "1";
        }
        public TARAMA_TURU(string Code, string Value)
        {
            codeSystemGuid = "52bcc87e-b051-4603-b6d6-43298fb0d443";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class IZLEM_ISLEM_TURU : CodeBase
    {
        public IZLEM_ISLEM_TURU()
        {
            codeSystemGuid = "5fff8778-89a4-4045-b33e-a7ffe0de0179";
            version = "1";
        }
        public IZLEM_ISLEM_TURU(string Code, string Value)
        {
            codeSystemGuid = "5fff8778-89a4-4045-b33e-a7ffe0de0179";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class GENCLIK_SAGLIGI_ISLEMLERI : CodeBase
    {
        public GENCLIK_SAGLIGI_ISLEMLERI()
        {
            codeSystemGuid = "a02655fd-acdf-4af9-84ba-ecb0d7d69247";
            version = "1";
        }
        public GENCLIK_SAGLIGI_ISLEMLERI(string Code, string Value)
        {
            codeSystemGuid = "a02655fd-acdf-4af9-84ba-ecb0d7d69247";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class DIYABET_TIPI : CodeBase
    {
        public DIYABET_TIPI()
        {
            codeSystemGuid = "35ae0624-4f4d-4ac0-886e-2687f017135b";
            version = "1";
        }
        public DIYABET_TIPI(string Code, string Value)
        {
            codeSystemGuid = "35ae0624-4f4d-4ac0-886e-2687f017135b";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class BEYIN_ODEMI : CodeBase
    {
        public BEYIN_ODEMI()
        {
            codeSystemGuid = "9ea880f3-b61b-4c6f-a691-c0f2d9fd6d83";
            version = "1";
        }
        public BEYIN_ODEMI(string Code, string Value)
        {
            codeSystemGuid = "9ea880f3-b61b-4c6f-a691-c0f2d9fd6d83";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class DIYABET_ILAC_TEDAVI_SEKLI : CodeBase
    {
        public DIYABET_ILAC_TEDAVI_SEKLI()
        {
            codeSystemGuid = "72f8fe9d-cdfe-4d8d-b154-66e0e706f06a";
            version = "1";
        }
        public DIYABET_ILAC_TEDAVI_SEKLI(string Code, string Value)
        {
            codeSystemGuid = "72f8fe9d-cdfe-4d8d-b154-66e0e706f06a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class KETOASIDOZ_SON_3_AY : CodeBase
    {
        public KETOASIDOZ_SON_3_AY()
        {
            codeSystemGuid = "9ea880f3-b61b-4c6f-a691-c0f2d9fd6d83";
            version = "1";
        }
        public KETOASIDOZ_SON_3_AY(string Code, string Value)
        {
            codeSystemGuid = "9ea880f3-b61b-4c6f-a691-c0f2d9fd6d83";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TIROID_MUAYENESI : CodeBase
    {
        public TIROID_MUAYENESI()
        {
            codeSystemGuid = "1683b32e-0668-4c28-97b7-8d3245ae2f4d";
            version = "1";
        }
        public TIROID_MUAYENESI(string Code, string Value)
        {
            codeSystemGuid = "1683b32e-0668-4c28-97b7-8d3245ae2f4d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class DIYABETLI_HASTA_AILE_OYKUSU : CodeBase
    {
        public DIYABETLI_HASTA_AILE_OYKUSU()
        {
            codeSystemGuid = "8cf96225-09f2-4e66-b1d3-5de56219a981";
            version = "1";
        }
        public DIYABETLI_HASTA_AILE_OYKUSU(string Code, string Value)
        {
            codeSystemGuid = "8cf96225-09f2-4e66-b1d3-5de56219a981";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class SIKAYET : CodeBase
    {
        public SIKAYET()
        {
            codeSystemGuid = "9584a55a-81c4-4925-857e-659a570012eb";
            version = "1";
        }
        public SIKAYET(string Code, string Value)
        {
            codeSystemGuid = "9584a55a-81c4-4925-857e-659a570012eb";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class AXILLER_KILLANMA : CodeBase
    {
        public AXILLER_KILLANMA()
        {
            codeSystemGuid = "9ea880f3-b61b-4c6f-a691-c0f2d9fd6d83";
            version = "1";
        }
        public AXILLER_KILLANMA(string Code, string Value)
        {
            codeSystemGuid = "9ea880f3-b61b-4c6f-a691-c0f2d9fd6d83";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class PUBIK_KILLANMA : CodeBase
    {
        public PUBIK_KILLANMA()
        {
            codeSystemGuid = "9ea880f3-b61b-4c6f-a691-c0f2d9fd6d83";
            version = "1";
        }
        public PUBIK_KILLANMA(string Code, string Value)
        {
            codeSystemGuid = "9ea880f3-b61b-4c6f-a691-c0f2d9fd6d83";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TANNER_EVRE : CodeBase
    {
        public TANNER_EVRE()
        {
            codeSystemGuid = "8aff5e1b-81ac-4354-9fdf-ce206a7c4f13";
            version = "1";
        }
        public TANNER_EVRE(string Code, string Value)
        {
            codeSystemGuid = "8aff5e1b-81ac-4354-9fdf-ce206a7c4f13";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class MEME_EVRE : CodeBase
    {
        public MEME_EVRE()
        {
            codeSystemGuid = "8aff5e1b-81ac-4354-9fdf-ce206a7c4f13";
            version = "1";
        }
        public MEME_EVRE(string Code, string Value)
        {
            codeSystemGuid = "8aff5e1b-81ac-4354-9fdf-ce206a7c4f13";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class ESLIK_EDEN_BASKA_HASTALIK : CodeBase
    {
        public ESLIK_EDEN_BASKA_HASTALIK()
        {
            codeSystemGuid = "94f19f91-44ed-4bf7-beed-de14090172d9";
            version = "1";
        }
        public ESLIK_EDEN_BASKA_HASTALIK(string Code, string Value)
        {
            codeSystemGuid = "94f19f91-44ed-4bf7-beed-de14090172d9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TARAMA_TIPI : CodeBase
    {
        public TARAMA_TIPI()
        {
            codeSystemGuid = "a332c5df-5662-4fe0-bb03-62d5d30567a4";
            version = "1";
        }
        public TARAMA_TIPI(string Code, string Value)
        {
            codeSystemGuid = "a332c5df-5662-4fe0-bb03-62d5d30567a4";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class HASTA_MESAJLARI_TURU : CodeBase
    {
        public HASTA_MESAJLARI_TURU()
        {
            codeSystemGuid = "db954393-57be-4a56-872c-58619e2779f3";
            version = "1";
        }
        public HASTA_MESAJLARI_TURU(string Code, string Value)
        {
            codeSystemGuid = "db954393-57be-4a56-872c-58619e2779f3";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }



    public class TIBBI_ISLEM_PUAN_BILGISI : CodeBase
    {
        public TIBBI_ISLEM_PUAN_BILGISI()
        {
            codeSystemGuid = "77ff0441-e162-4e7f-8719-ebf34bb5c345";
            version = "1";
        }
        public TIBBI_ISLEM_PUAN_BILGISI(string Code, string Value)
        {
            codeSystemGuid = "77ff0441-e162-4e7f-8719-ebf34bb5c345";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class GERI_BILDIRIMI_MECBURI_OLAN_KOMPLIKASYON : CodeBase
    {
        public GERI_BILDIRIMI_MECBURI_OLAN_KOMPLIKASYON()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
        }
        public GERI_BILDIRIMI_MECBURI_OLAN_KOMPLIKASYON(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class UYGULAMA_TURU : CodeBase
    {
        public UYGULAMA_TURU()
        {
            codeSystemGuid = "7cc5b0e9-63a0-492c-bc54-da5291e7df15";
            version = "1";
        }
        public UYGULAMA_TURU(string Code, string Value)
        {
            codeSystemGuid = "7cc5b0e9-63a0-492c-bc54-da5291e7df15";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class TEDAVI_SONUCU : CodeBase
    {
        public TEDAVI_SONUCU()
        {
            codeSystemGuid = "a4801c6b-8bd7-4407-8353-b8a143571f03";
            version = "1";
        }
        public TEDAVI_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "a4801c6b-8bd7-4407-8353-b8a143571f03";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class UYGULANDIGI_DURUM : CodeBase
    {
        public UYGULANDIGI_DURUM()
        {
            codeSystemGuid = "f74b3dc6-d1dc-46d6-90b8-1a1f93e4fcaa";
            version = "1";
        }
        public UYGULANDIGI_DURUM(string Code, string Value)
        {
            codeSystemGuid = "f74b3dc6-d1dc-46d6-90b8-1a1f93e4fcaa";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }


    public class UYGULAMA_BOLGESI : CodeBase
    {
        public UYGULAMA_BOLGESI()
        {
            codeSystemGuid = "f3863fa1-d7a9-4779-b01f-af604591a02e";
            version = "1";
        }
        public UYGULAMA_BOLGESI(string Code, string Value)
        {
            codeSystemGuid = "f3863fa1-d7a9-4779-b01f-af604591a02e";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class UYGULAMA_BIRIMI : CodeBase
    {
        public UYGULAMA_BIRIMI()
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
        }
        public UYGULAMA_BIRIMI(string Code, string Value)
        {
            codeSystemGuid = "c3eaabad-8c4c-56ee-e043-14031b0a5530";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class TANI_TURU : CodeBase
    {
        public TANI_TURU()
        {
            codeSystemGuid = "55894edb-1a8c-4f7f-a447-0119e61c14f1";
            version = "1";

        }
        public TANI_TURU(string Code, string Value)
        {
            codeSystemGuid = "55894edb-1a8c-4f7f-a447-0119e61c14f1";
            version = "1";
            code = Code;
            value = Value;
        }
    }

    public class GKD_TARAMA_SONUCU : CodeBase
    {
        public GKD_TARAMA_SONUCU()
        {
            codeSystemGuid = "03dee8e4-6d54-4009-9b53-84c11d302e14";
            version = "1";
        }
        public GKD_TARAMA_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "03dee8e4-6d54-4009-9b53-84c11d302e14";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class GORME_TARAMA_SONUCU : CodeBase
    {
        public GORME_TARAMA_SONUCU()
        {
            codeSystemGuid = "bb174db7-75ea-4bd4-a3e9-cf2a908511cb";
            version = "1";
        }
        public GORME_TARAMA_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "bb174db7-75ea-4bd4-a3e9-cf2a908511cb";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class NTP_TAKIP_BILGISI : CodeBase
    {
        public NTP_TAKIP_BILGISI()
        {
            codeSystemGuid = "b409d9c0-fe50-43e0-afab-889cf87a2855";
            version = "1";
        }
        public NTP_TAKIP_BILGISI(string Code, string Value)
        {
            codeSystemGuid = "b409d9c0-fe50-43e0-afab-889cf87a2855";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class YOGUN_BAKIM_TIPI : CodeBase
    {
        public YOGUN_BAKIM_TIPI()
        {
            codeSystemGuid = "e725df2c-402f-4f0d-ae8a-f4e23b6e178c";
            version = "1";

        }
        public YOGUN_BAKIM_TIPI(string Code, string Value)
        {
            codeSystemGuid = "e725df2c-402f-4f0d-ae8a-f4e23b6e178c";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class VENTILASYON_DURUMU : CodeBase
    {
        public VENTILASYON_DURUMU()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";

        }
        public VENTILASYON_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class SEPTIK_SOK : CodeBase
    {
        public SEPTIK_SOK()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";

        }
        public SEPTIK_SOK(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class SEPSIS_DURUMU : CodeBase
    {
        public SEPSIS_DURUMU()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";

        }
        public SEPSIS_DURUMU(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class GETAT_UYGULAMA_BIRIMI : CodeBase
    {
        public GETAT_UYGULAMA_BIRIMI()
        {
            codeSystemGuid = "dbcde848-ab30-407a-9a5c-169900b0b515";
            version = "1";
        }
        public GETAT_UYGULAMA_BIRIMI(string Code, string Value)
        {
            codeSystemGuid = "dbcde848-ab30-407a-9a5c-169900b0b515";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class YOGUN_BAKIMDA_MI : CodeBase
    {
        public YOGUN_BAKIMDA_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public YOGUN_BAKIMDA_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class XXXXXXDE_IZOLASYON_AMACLI_YATIS_MI : CodeBase
    {
        public XXXXXXDE_IZOLASYON_AMACLI_YATIS_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public XXXXXXDE_IZOLASYON_AMACLI_YATIS_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class XXXXXXDE_COVID_DISI_YATIS_MI : CodeBase
    {
        public XXXXXXDE_COVID_DISI_YATIS_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public XXXXXXDE_COVID_DISI_YATIS_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class KLINIK_BULGU_VAR_MI : CodeBase
    {
        public KLINIK_BULGU_VAR_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public KLINIK_BULGU_VAR_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BT_CEKILDI_MI : CodeBase
    {
        public BT_CEKILDI_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public BT_CEKILDI_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class PNOMONI_VAR_MI : CodeBase
    {
        public PNOMONI_VAR_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public PNOMONI_VAR_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class BT_SONUCU : CodeBase
    {
        public BT_SONUCU()
        {
            codeSystemGuid = "c1dcfa5d-9679-4b0c-876b-15f60d8f2415";
            version = "1";
        }
        public BT_SONUCU(string Code, string Value)
        {
            codeSystemGuid = "c1dcfa5d-9679-4b0c-876b-15f60d8f2415";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class ENTUBASYON_VAR_MI : CodeBase
    {
        public ENTUBASYON_VAR_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public ENTUBASYON_VAR_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class GENEL_DURUM : CodeBase
    {
        public GENEL_DURUM()
        {
            codeSystemGuid = "2bdb33d5-b077-4fe9-95e2-03e192c64f80";
            version = "1";
        }
        public GENEL_DURUM(string Code, string Value)
        {
            codeSystemGuid = "2bdb33d5-b077-4fe9-95e2-03e192c64f80";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class YUKSEK_DOZ_C_VITAMINI : CodeBase
    {
        public YUKSEK_DOZ_C_VITAMINI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public YUKSEK_DOZ_C_VITAMINI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class HIDROKSIKLOROKIN : CodeBase
    {
        public HIDROKSIKLOROKIN()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public HIDROKSIKLOROKIN(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class KALETRA : CodeBase
    {
        public KALETRA()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public KALETRA(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class OSELTAMIVIR_75GR_TANIFLU : CodeBase
    {
        public OSELTAMIVIR_75GR_TANIFLU()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public OSELTAMIVIR_75GR_TANIFLU(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class AZITROMISIN : CodeBase
    {
        public AZITROMISIN()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public AZITROMISIN(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class FAVIPAVIR_AVIGAN : CodeBase
    {
        public FAVIPAVIR_AVIGAN()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public FAVIPAVIR_AVIGAN(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class HASTA_HUKUMLU_MU : CodeBase
    {
        public HASTA_HUKUMLU_MU()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public HASTA_HUKUMLU_MU(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class HASTA_ADLI_VAKA_MI : CodeBase
    {
        public HASTA_ADLI_VAKA_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public HASTA_ADLI_VAKA_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class NAKIL_TALEP_EDEN_KURUM : CodeBase
    {
        public NAKIL_TALEP_EDEN_KURUM()
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
        }
        public NAKIL_TALEP_EDEN_KURUM(string Code, string Value)
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class NAKIL_TALEP_EDEN_KLINIK : CodeBase
    {
        public NAKIL_TALEP_EDEN_KLINIK()
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
        }
        public NAKIL_TALEP_EDEN_KLINIK(string Code, string Value)
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class HASTANIN_BULUNDUGU_KLINIK : CodeBase
    {
        public HASTANIN_BULUNDUGU_KLINIK()
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
        }
        public HASTANIN_BULUNDUGU_KLINIK(string Code, string Value)
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class NAKIL_EDILMEK_ISTENDIGI_KLINIK : CodeBase
    {
        public NAKIL_EDILMEK_ISTENDIGI_KLINIK()
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
        }
        public NAKIL_EDILMEK_ISTENDIGI_KLINIK(string Code, string Value)
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class HASTA_NAKIL_TIPI : CodeBase
    {
        public HASTA_NAKIL_TIPI()
        {
            codeSystemGuid = "c81aa38f-77b7-4520-957c-658648d4559a";
            version = "1";
        }
        public HASTA_NAKIL_TIPI(string Code, string Value)
        {
            codeSystemGuid = "c81aa38f-77b7-4520-957c-658648d4559a";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class GERCEKLESTIRILMESI_ISTENEN_KOMUTA_MERKEZI : CodeBase
    {
        public GERCEKLESTIRILMESI_ISTENEN_KOMUTA_MERKEZI()
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
        }
        public GERCEKLESTIRILMESI_ISTENEN_KOMUTA_MERKEZI(string Code, string Value)
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }

    public class SOLUNUM_ISLEMI : CodeBase
    {
        public SOLUNUM_ISLEMI()
        {
            codeSystemGuid = "1ec0522b-337c-4a7f-ba11-c31e5f9c75e2";
            version = "1";
        }
        public SOLUNUM_ISLEMI(string Code, string Value)
        {
            codeSystemGuid = "1ec0522b-337c-4a7f-ba11-c31e5f9c75e2";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class BRANS_IHTIYACI : CodeBase
    {
        public BRANS_IHTIYACI()
        {
            codeSystemGuid = "63dd9340-8c17-48c4-b798-7cf27067f301";
            version = "1";
        }
        public BRANS_IHTIYACI(string Code, string Value)
        {
            codeSystemGuid = "63dd9340-8c17-48c4-b798-7cf27067f301";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class TEYITLI_VAKA_MI : CodeBase
    {
        public TEYITLI_VAKA_MI()
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
        }
        public TEYITLI_VAKA_MI(string Code, string Value)
        {
            codeSystemGuid = "c9d56fee-d143-4602-ad7b-ba131ef92ad9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class IL : CodeBase
    {
        public IL()
        {
            codeSystemGuid = "5bc508fa-782a-4d75-831f-34948e350e72";
            version = "1";
        }
        public IL(string Code, string Value)
        {
            codeSystemGuid = "5bc508fa-782a-4d75-831f-34948e350e72";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KABUL_EDEN_KURUM : CodeBase
    {
        public KABUL_EDEN_KURUM()
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
        }
        public KABUL_EDEN_KURUM(string Code, string Value)
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
    public class KABUL_EDEN_KLINIK : CodeBase
    {
        public KABUL_EDEN_KLINIK()
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
        }
        public KABUL_EDEN_KLINIK(string Code, string Value)
        {
            codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            version = "1";
            code = Code.ToString();
            value = Value;
        }
    }
}
