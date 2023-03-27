//$66C767A9
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace SKRSSistemlerServis {
    export enum kodDegeriKolonIcerigiTipi {
        /// <remarks/>
        NUMBER,
        /// <remarks/>
        BOOLEAN,
        /// <remarks/>
        TEXT,
        /// <remarks/>
        DATE,
        /// <remarks/>
        NULL,
        /// <remarks/>
        UNKNOWN
    }

    export class wsskrsSistemlerResponse {
        public hata: hata;
        public sistemler: Array<responseSistemler>;
    }

    export class hata {
        public yerelHataAciklamasi: string;
        public hataTanimi: hataTanimi;
        public yerelHataListesi: Array<hataOgesi>;
        public throwableStackTrace: string;
        public yerelHataKapsami: string;
        public yerelHataKodu: string;
    }

    export class hataTanimi {
        public genelHataAciklamasi: string;
        public genelHataKapsami: string;
        public genelHataKodu: string;
    }

    export class kodDegeriKolonIcerigi {
        public kodDegeriKolonIcerigiTipi: kodDegeriKolonIcerigiTipi;
        public kodDegeriKolonIcerigiTipiSpecified: boolean;
        public Value: string;
    }

    export class kodDegeriKolonu {
        public kolonIcerigi: kodDegeriKolonIcerigi;
        public kolonAdi: string;
    }

    export class kodDegerleriResponse {
        public hata: hata;
        public kodDegerleri: Array<kodDegeriKolonu>;
    }

    export class responseSistemler {
        public adi: string;
        public aktif: boolean;
        public aktifSpecified: boolean;
        public guncellenmeTarihi: Date;
        public guncellenmeTarihiSpecified: boolean;
        public hata: hata;
        public hl7Kodu: string;
        public kodu: string;
        public olusturulmaTarihi: Date;
        public olusturulmaTarihiSpecified: boolean;
    }

    export class hataOgesi {
        public hataAciklamasi: string;
        public hataKapsami: string;
        public hataKodu: string;
    }

    export class SistemlerRequest {
        constructor() {
        }

    }


    export class SistemlerResponse {
        constructor(sistemlerOutput?: SKRSSistemlerServis.wsskrsSistemlerResponse) {

            if (arguments.length == 0)
                this.SistemlerResponseConstructorV0();
            if (arguments.length == 1)
                this.SistemlerResponseConstructorV1(sistemlerOutput);
        }

        public sistemlerOutput: SKRSSistemlerServis.wsskrsSistemlerResponse;
        public SistemlerResponseConstructorV0(): void {

        }
        public SistemlerResponseConstructorV1(sistemlerOutput: SKRSSistemlerServis.wsskrsSistemlerResponse): void {
            this.sistemlerOutput = sistemlerOutput;
        }
    }


    export class SistemKodlariRequest {
        constructor(sistemKoduInput?: string, tarihInput?: Date) {

            if (arguments.length == 0)
                this.SistemKodlariRequestConstructorV0();
            if (arguments.length == 2)
                this.SistemKodlariRequestConstructorV1(sistemKoduInput, tarihInput);
        }

        public sistemKoduInput: string;
        public tarihInput: Date;
        public SistemKodlariRequestConstructorV0(): void {

        }
        public SistemKodlariRequestConstructorV1(sistemKoduInput: string, tarihInput: Date): void {
            this.sistemKoduInput = sistemKoduInput;
            this.tarihInput = tarihInput;
        }
    }


    export class SistemKodlariResponse {
        constructor(sistemKodlariOutput?: SKRSSistemlerServis.kodDegerleriResponse) {

            if (arguments.length == 0)
                this.SistemKodlariResponseConstructorV0();
            if (arguments.length == 1)
                this.SistemKodlariResponseConstructorV1(sistemKodlariOutput);
        }

        public sistemKodlariOutput: SKRSSistemlerServis.kodDegerleriResponse;
        public SistemKodlariResponseConstructorV0(): void {

        }
        public SistemKodlariResponseConstructorV1(sistemKodlariOutput: SKRSSistemlerServis.kodDegerleriResponse): void {
            this.sistemKodlariOutput = sistemKodlariOutput;
        }
    }


    export class SistemKodlariSayfaGetirRequest {
        constructor(sistemKoduInput?: string, tarihInput?: Date, skrsKod?: number) {

            if (arguments.length == 0)
                this.SistemKodlariSayfaGetirRequestConstructorV0();
            if (arguments.length == 3)
                this.SistemKodlariSayfaGetirRequestConstructorV1(sistemKoduInput, tarihInput, skrsKod);
        }

        public sistemKoduInput: string;
        public tarihInput: Date;
        public skrsKod: number;
        public SistemKodlariSayfaGetirRequestConstructorV0(): void {

        }
        public SistemKodlariSayfaGetirRequestConstructorV1(sistemKoduInput: string, tarihInput: Date, skrsKod: number): void {
            this.sistemKoduInput = sistemKoduInput;
            this.tarihInput = tarihInput;
            this.skrsKod = skrsKod;
        }
    }


    export class SistemKodlariSayfaGetirResponse {
        constructor(sistemKodlariOutput?: SKRSSistemlerServis.kodDegerleriResponse) {

            if (arguments.length == 0)
                this.SistemKodlariSayfaGetirResponseConstructorV0();
            if (arguments.length == 1)
                this.SistemKodlariSayfaGetirResponseConstructorV1(sistemKodlariOutput);
        }

        public sistemKodlariOutput: SKRSSistemlerServis.kodDegerleriResponse;
        public SistemKodlariSayfaGetirResponseConstructorV0(): void {

        }
        public SistemKodlariSayfaGetirResponseConstructorV1(sistemKodlariOutput: SKRSSistemlerServis.kodDegerleriResponse): void {
            this.sistemKodlariOutput = sistemKodlariOutput;
        }
    }


    export class WebMethods {
        public static async SistemKodlariSayfaGetirSync(siteID: Guid, sistemKoduInput: string, tarihInput: Date): Promise<kodDegerleriResponse> {
            let url: string = "/api/SKRSSistemlerServisController/SistemKodlariSayfaGetirSync";
            let inputDto = { "siteID": siteID, "sistemKoduInput": sistemKoduInput, "tarihInput": tarihInput };
            let result = await ServiceLocator.post(url, inputDto) as kodDegerleriResponse;
            return result;
        }
        public static async SistemKodlariSync(siteID: Guid, sistemKoduInput: string, tarihInput: Date): Promise<kodDegerleriResponse> {
            let url: string = "/api/SKRSSistemlerServisController/SistemKodlariSync";
            let inputDto = { "siteID": siteID, "sistemKoduInput": sistemKoduInput, "tarihInput": tarihInput };
            let result = await ServiceLocator.post(url, inputDto) as kodDegerleriResponse;
            return result;
        }
        public static async SistemlerSync(siteID: Guid): Promise<wsskrsSistemlerResponse> {
            let url: string = "/api/SKRSSistemlerServisController/SistemlerSync";
            let inputDto = { "siteID": siteID };
            let result = await ServiceLocator.post(url, inputDto) as wsskrsSistemlerResponse;
            return result;
        }
    }
}
