//$CB503DC7

export namespace SKRSObjects {
    export class ValueBase {
        constructor() {
            this.value = "";
        }

        public value: string;
    }


    export class CodeBase {
        public version: string;
        public codeSystemGuid: string;
        public code: string;
        public value: string;
    }

    export class SYSSendMessage {
        public input: input = new input();
    }

    export class input {
        public SYSMessage: SYSMessage = new SYSMessage();
    }

    export class messageGuid extends ValueBase {

    }

    export class messageType extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.messageTypeConstructorV0();
            if (arguments.length == 2)
                this.messageTypeConstructorV1(Code, Value);
        }

        public messageTypeConstructorV0(): void {
            this.codeSystemGuid = "0a9ba485-e7e0-4abb-9c86-0a14fd364bb8";
            this.version = "1";
        }
        public messageTypeConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "0a9ba485-e7e0-4abb-9c86-0a14fd364bb8";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class documentGenerationTime extends ValueBase {
        constructor() {
            super();
            this.value = Date.Now.format("yyyyMMddHHmm");
        }

    }


    export class healthcareProvider extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.healthcareProviderConstructorV0();
            if (arguments.length == 2)
                this.healthcareProviderConstructorV1(Code, Value);
        }

        public healthcareProviderConstructorV0(): void {
            this.codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            this.version = "1";
        }
        public healthcareProviderConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class author {
        public healthcareProvider: healthcareProvider = new healthcareProvider(999997, "TEST DEVLET XXXXXXSİ");
    }

    export class firmaKodu extends ValueBase {
        constructor() {
            super();
            this.value = "C740D0288F1DC45FE0407C0A04162BDD";
        }

    }


    export class SYSMessage {
        constructor() {
            this.messageType.code = "101"; this.messageType.value = "Hasta Kayıt";
        }

        public messageGuid: messageGuid = new messageGuid();
        public messageType: messageType = new messageType();
        public documentGenerationTime: documentGenerationTime = new documentGenerationTime();
        public author: author = new author();
        public firmaKodu: firmaKodu = new firmaKodu();
        public recordData: recordData = new recordData();
    }


    export class AMBULANS_TAKIP_NUMARASI extends ValueBase {

    }

    export class KAYIT_YERI extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.KAYIT_YERIConstructorV0();
            if (arguments.length == 2)
                this.KAYIT_YERIConstructorV1(Code, Value);
        }

        public KAYIT_YERIConstructorV0(): void {
            this.codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            this.version = "1";
        }
        public KAYIT_YERIConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class HIZMET_SUNUCU extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.HIZMET_SUNUCUConstructorV0();
            if (arguments.length == 2)
                this.HIZMET_SUNUCUConstructorV1(Code, Value);
        }

        public HIZMET_SUNUCUConstructorV0(): void {
            this.codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            this.version = "1";
        }
        public HIZMET_SUNUCUConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class PROTOKOL_NUMARASI extends ValueBase {

    }

    export class XXXXXX_REFERANS_NUMARASI extends ValueBase {
        constructor() {
            super();
            this.value = "0";
        }

    }


    export class SGK_TAKIP_NUMARASI extends ValueBase {

    }

    export class KABUL_ZAMANI extends ValueBase {
        constructor() {
            super();
            this.value = Date.Now.AddDays(-1).format("yyyyMMddHHmm");
        }

    }


    export class KLINIK_KODU extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.KLINIK_KODUConstructorV0();
            if (arguments.length == 2)
                this.KLINIK_KODUConstructorV1(Code, Value);
        }

        public KLINIK_KODUConstructorV0(): void {
            this.codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            this.version = "1";
        }
        public KLINIK_KODUConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "c04bee57-c5d4-443d-e040-7b0a6f146a3d";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class SOSYAL_GUVENCE_DURUMU extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.SOSYAL_GUVENCE_DURUMUConstructorV0();
            if (arguments.length == 2)
                this.SOSYAL_GUVENCE_DURUMUConstructorV1(Code, Value);
        }

        public SOSYAL_GUVENCE_DURUMUConstructorV0(): void {
            this.codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
            this.version = "1";
        }
        public SOSYAL_GUVENCE_DURUMUConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "530da738-2be0-4adc-a7c1-aca18c66a3f8";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class HEKIM_KIMLIK_NUMARASI extends ValueBase {

    }

    export class VAKA_TURU extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.VAKA_TURUConstructorV0();
            if (arguments.length == 2)
                this.VAKA_TURUConstructorV1(Code, Value);
        }

        public VAKA_TURUConstructorV0(): void {
            this.codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
            this.version = "1";
        }
        public VAKA_TURUConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "46380e82-d8b1-407d-9554-255d95a9f959";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class MHRS_RANDEVU_NUMARASI extends ValueBase {

    }

    export class TRIAJ extends ValueBase {

    }

    export class YATIS_KABUL_ZAMANI extends ValueBase {

    }

    export class YATAK_NO extends ValueBase {

    }

    export class YATIS_GUNUBIRLIK_MI extends ValueBase {

    }

    export class YATISIN_ACILIYETI extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.YATISIN_ACILIYETIConstructorV0();
            if (arguments.length == 2)
                this.YATISIN_ACILIYETIConstructorV1(Code, Value);
        }

        public YATISIN_ACILIYETIConstructorV0(): void {
            this.codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
            this.version = "1";
        }
        public YATISIN_ACILIYETIConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "dc6ff680-555f-44b2-855e-a47c51207e4f";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class YATIS_BILGISI {
        public YATIS_KABUL_ZAMANI: YATIS_KABUL_ZAMANI = new YATIS_KABUL_ZAMANI();
        public YATAK_NO: YATAK_NO = new YATAK_NO();
        public YATIS_GUNUBIRLIK_MI: YATIS_GUNUBIRLIK_MI = new YATIS_GUNUBIRLIK_MI();
        public YATISIN_ACILIYETI: YATISIN_ACILIYETI = new YATISIN_ACILIYETI();
    }

    export class SYSTakipNo extends ValueBase {

    }

    export class HASTA_BASVURU_BILGILERI {
        public AMBULANS_TAKIP_NUMARASI: AMBULANS_TAKIP_NUMARASI = new AMBULANS_TAKIP_NUMARASI();
        public KAYIT_YERI: KAYIT_YERI = new KAYIT_YERI();
        public HIZMET_SUNUCU: HIZMET_SUNUCU = new HIZMET_SUNUCU();
        public PROTOKOL_NUMARASI: PROTOKOL_NUMARASI = new PROTOKOL_NUMARASI();
        public XXXXXX_REFERANS_NUMARASI: XXXXXX_REFERANS_NUMARASI = new XXXXXX_REFERANS_NUMARASI();
        public SGK_TAKIP_NUMARASI: SGK_TAKIP_NUMARASI = new SGK_TAKIP_NUMARASI();
        public KABUL_ZAMANI: KABUL_ZAMANI = new KABUL_ZAMANI();
        public KLINIK_KODU: KLINIK_KODU = new KLINIK_KODU();
        public SOSYAL_GUVENCE_DURUMU: SOSYAL_GUVENCE_DURUMU = new SOSYAL_GUVENCE_DURUMU();
        public HEKIM_KIMLIK_NUMARASI: HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
        public VAKA_TURU: VAKA_TURU = new VAKA_TURU();
        public MHRS_RANDEVU_NUMARASI: MHRS_RANDEVU_NUMARASI = new MHRS_RANDEVU_NUMARASI();
        public TRIAJ: TRIAJ = new TRIAJ();
        public YATIS_BILGISI: YATIS_BILGISI = new YATIS_BILGISI();
        public SYSTakipNo: SYSTakipNo = new SYSTakipNo();
    }

    export class HASTA_KIMLIK_NUMARASI extends ValueBase {

    }

    export class AD extends ValueBase {

    }

    export class SOYAD extends ValueBase {

    }

    export class DOGUM_TARIHI extends ValueBase {

    }

    export class CINSIYET extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.CINSIYETConstructorV0();
            if (arguments.length == 2)
                this.CINSIYETConstructorV1(Code, Value);
        }

        public CINSIYETConstructorV0(): void {
            this.codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
            this.version = "1";
        }
        public CINSIYETConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "784d0f4f-0603-4425-937f-1a3941fc3a1f";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class UYRUK extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.UYRUKConstructorV0();
            if (arguments.length == 2)
                this.UYRUKConstructorV1(Code, Value);
        }

        public UYRUKConstructorV0(): void {
            this.codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
            this.version = "1";
        }
        public UYRUKConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "d650777a-3d4d-a259-e040-7c0a01167a83";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class ANNE_KIMLIK_NUMARASI extends ValueBase {

    }

    export class DOGUM_SIRASI extends ValueBase {

    }

    export class YABANCI_HASTA_KIMLIK_NUMARASI extends ValueBase {

    }

    export class PASAPORT_NO extends ValueBase {

    }

    export class KIMLIKSIZ_HASTA_BILGISI extends ValueBase {

    }

    export class ADRES_KODU_SEVIYESI extends CodeBase {
        constructor(Code?: number, Value?: string) {
            super();

            if (arguments.length == 0)
                this.ADRES_KODU_SEVIYESIConstructorV0();
            if (arguments.length == 2)
                this.ADRES_KODU_SEVIYESIConstructorV1(Code, Value);
        }

        public ADRES_KODU_SEVIYESIConstructorV0(): void {
            this.codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
            this.version = "1";
        }
        public ADRES_KODU_SEVIYESIConstructorV1(Code: number, Value: string): void {
            this.codeSystemGuid = "aa0e83ba-e9db-4817-80da-577fd6a17373";
            this.version = "1";
            this.code = Code.toString();
            this.value = Value;
        }
    }


    export class ADRES_KODU extends ValueBase {

    }

    export class ACIK_ADRES extends ValueBase {

    }

    export class ACIK_ADRES_IL extends ValueBase {

    }

    export class ACIK_ADRES_ILCE extends ValueBase {

    }

    export class ADRES_BILGISI {
        public ADRES_KODU_SEVIYESI: ADRES_KODU_SEVIYESI = new ADRES_KODU_SEVIYESI();
        public ADRES_KODU: ADRES_KODU = new ADRES_KODU();
        public ACIK_ADRES: ACIK_ADRES = new ACIK_ADRES();
        public ACIK_ADRES_IL: ACIK_ADRES_IL = new ACIK_ADRES_IL();
        public ACIK_ADRES_ILCE: ACIK_ADRES_ILCE = new ACIK_ADRES_ILCE();
    }

    export class HASTA_KIMLIK_BILGILERI {
        public HASTA_KIMLIK_NUMARASI: HASTA_KIMLIK_NUMARASI = new HASTA_KIMLIK_NUMARASI();
        public AD: AD = new AD();
        public SOYAD: SOYAD = new SOYAD();
        public DOGUM_TARIHI: DOGUM_TARIHI = new DOGUM_TARIHI();
        public CINSIYET: CINSIYET = new CINSIYET();
        public UYRUK: UYRUK = new UYRUK();
        public ANNE_KIMLIK_NUMARASI: ANNE_KIMLIK_NUMARASI = new ANNE_KIMLIK_NUMARASI();
        public DOGUM_SIRASI: DOGUM_SIRASI = new DOGUM_SIRASI();
        public YABANCI_HASTA_KIMLIK_NUMARASI: YABANCI_HASTA_KIMLIK_NUMARASI = new YABANCI_HASTA_KIMLIK_NUMARASI();
        public PASAPORT_NO: PASAPORT_NO = new PASAPORT_NO();
        public KIMLIKSIZ_HASTA_BILGISI: KIMLIKSIZ_HASTA_BILGISI = new KIMLIKSIZ_HASTA_BILGISI();
        public ADRES_BILGISI: ADRES_BILGISI = new ADRES_BILGISI();
    }

    export class recordData {
        public HASTA_KIMLIK_BILGILERI: HASTA_KIMLIK_BILGILERI = new HASTA_KIMLIK_BILGILERI();
        public HASTA_BASVURU_BILGILERI: HASTA_BASVURU_BILGILERI = new HASTA_BASVURU_BILGILERI();
    }

    export class WebMethods {

    }
}
