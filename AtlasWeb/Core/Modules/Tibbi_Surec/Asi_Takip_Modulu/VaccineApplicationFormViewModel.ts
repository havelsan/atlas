//$886D9715
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { VaccineDetails } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKurumlar } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSASIISLEMTURU } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiOzelDurumNedeni } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiKodu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsininDozu } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsininUygulamaSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiUygulamaYeri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiYapilmamaNedeni } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsiYapilmamaDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { VaccineFollowUp } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAsininSaglandigiKaynak } from 'NebulaClient/Model/AtlasClientModel';

export class VaccineApplicationFormViewModel extends BaseViewModel {
    @Type(() => VaccineDetails)
    public _VaccineDetails: VaccineDetails = new VaccineDetails();
    @Type(() => SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki)
    public SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtkis: Array<SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki> = new Array<SKRSBildirimiZorunluAsiSonrasiIstenmeyenEtki>();
    @Type(() => SKRSKurumlar)
    public SKRSKurumlars: Array<SKRSKurumlar> = new Array<SKRSKurumlar>();
    @Type(() => SKRSASIISLEMTURU)
    public SKRSASIISLEMTURUs: Array<SKRSASIISLEMTURU> = new Array<SKRSASIISLEMTURU>();
    @Type(() => SKRSAsiOzelDurumNedeni)
    public SKRSAsiOzelDurumNedenis: Array<SKRSAsiOzelDurumNedeni> = new Array<SKRSAsiOzelDurumNedeni>();
    @Type(() => SKRSAsiKodu)
    public SKRSAsiKodus: Array<SKRSAsiKodu> = new Array<SKRSAsiKodu>();
    @Type(() => SKRSAsininDozu)
    public SKRSAsininDozus: Array<SKRSAsininDozu> = new Array<SKRSAsininDozu>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSAsininUygulamaSekli)
    public SKRSAsininUygulamaSeklis: Array<SKRSAsininUygulamaSekli> = new Array<SKRSAsininUygulamaSekli>();
    @Type(() => SKRSAsiUygulamaYeri)
    public SKRSAsiUygulamaYeris: Array<SKRSAsiUygulamaYeri> = new Array<SKRSAsiUygulamaYeri>();
    @Type(() => SKRSAsiYapilmamaNedeni)
    public SKRSAsiYapilmamaNedenis: Array<SKRSAsiYapilmamaNedeni> = new Array<SKRSAsiYapilmamaNedeni>();
    @Type(() => SKRSAsiYapilmamaDurumu)
    public SKRSAsiYapilmamaDurumus: Array<SKRSAsiYapilmamaDurumu> = new Array<SKRSAsiYapilmamaDurumu>();
    @Type(() => SKRSAsininSaglandigiKaynak)
    public SKRSAsininSaglandigiKaynaks: Array<SKRSAsininSaglandigiKaynak> = new Array<SKRSAsininSaglandigiKaynak>();
    public _StateName: string;

}

export class ATSSorgulaInput {
    karekod: string;
    skrsAsiKodu: string;
    skrsAsiDozu: string;
    skrsAsiSaglandigiKaynakKod: string;
    geziciHizmetMi: boolean;
    patientID: Guid;
    vaccineFollowupEA: VaccineFollowUp = new VaccineFollowUp();
    ResponsibleDoctor: ResUser = new ResUser();
    vaccineDetailObjectID : Guid;
}

export class ATSSorgulaResult
{
    SonKullanmaTarihi: Date;
    Barkod: string;
    PartiNo: string;
    SeriNo: string;
    Kirilim: string;
    ats_output_Bilgi: string;
    ats_output_KullanilabilirlikDurum: string;
    ats_output_SorguNo: string;

}

export class ATSBildirimResult
{
    IsSuccess: boolean;
    Result: string;
    ApplicationDate: Date;
}

export class BarcodeShortInfo {
    Barkod: string;
    SeriNo: string;
    PartiNo: string;
    SonKullanmaTarihi: Date;
    BirimKirilimDegerleri: string;
}
