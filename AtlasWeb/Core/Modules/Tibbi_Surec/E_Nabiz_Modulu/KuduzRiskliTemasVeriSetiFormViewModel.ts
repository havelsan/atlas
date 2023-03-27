//$9B2F0883
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { KuduzRiskliTemasVeriSeti } from "NebulaClient/Model/AtlasClientModel";
import { KuduzRiskliTemasTelefon } from "NebulaClient/Model/AtlasClientModel";
import { KuduzRiskliTemasRiskTemTip } from "NebulaClient/Model/AtlasClientModel";
import { KuduzRiskliTemasPlanProfBi } from "NebulaClient/Model/AtlasClientModel";
import { KuduzRiskliTemasAdres } from "NebulaClient/Model/AtlasClientModel";
import { SKRSRiskliTemasaSebepOlanHayvan } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKuduzRiskliTemasDegerlendirmeDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKategorizasyon } from "NebulaClient/Model/AtlasClientModel";
import { SKRSImmunglobulinTuru } from "NebulaClient/Model/AtlasClientModel";
import { SKRSHayvaninSahiplikDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSHayvaninMevcutDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSTelefonTipi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSRiskliTemasTipi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKisiyePlanlananKuduzProfilaksisi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAdresTipi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSBucakKodlari } from "NebulaClient/Model/AtlasClientModel";
import { SKRSCSBMTipi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIlceKodlari } from "NebulaClient/Model/AtlasClientModel";
import { SKRSILKodlari } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKoyKodlari } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMahalleKodlari } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class KuduzRiskliTemasVeriSetiFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.KuduzRiskliTemasVeriSetiFormViewModel, Core';
    @Type(() => KuduzRiskliTemasVeriSeti)
    public _KuduzRiskliTemasVeriSeti: KuduzRiskliTemasVeriSeti = new KuduzRiskliTemasVeriSeti();
    @Type(() => KuduzRiskliTemasTelefon)
    public KuduzRiskliTemasTelefonGridList: Array<KuduzRiskliTemasTelefon> = new Array<KuduzRiskliTemasTelefon>();
    @Type(() => KuduzRiskliTemasRiskTemTip)
    public KuduzRiskliTemasRiskTemTipGridList: Array<KuduzRiskliTemasRiskTemTip> = new Array<KuduzRiskliTemasRiskTemTip>();
    @Type(() => KuduzRiskliTemasPlanProfBi)
    public KuduzRiskliTemasPlanProfBiGridList: Array<KuduzRiskliTemasPlanProfBi> = new Array<KuduzRiskliTemasPlanProfBi>();
    @Type(() => KuduzRiskliTemasAdres)
    public KuduzRiskliTemasAdresGridList: Array<KuduzRiskliTemasAdres> = new Array<KuduzRiskliTemasAdres>();
    @Type(() => SKRSRiskliTemasaSebepOlanHayvan)
    public SKRSRiskliTemasaSebepOlanHayvans: Array<SKRSRiskliTemasaSebepOlanHayvan> = new Array<SKRSRiskliTemasaSebepOlanHayvan>();
    @Type(() => SKRSKuduzRiskliTemasDegerlendirmeDurumu)
    public SKRSKuduzRiskliTemasDegerlendirmeDurumus: Array<SKRSKuduzRiskliTemasDegerlendirmeDurumu> = new Array<SKRSKuduzRiskliTemasDegerlendirmeDurumu>();
    @Type(() => SKRSKategorizasyon)
    public SKRSKategorizasyons: Array<SKRSKategorizasyon> = new Array<SKRSKategorizasyon>();
    @Type(() => SKRSImmunglobulinTuru)
    public SKRSImmunglobulinTurus: Array<SKRSImmunglobulinTuru> = new Array<SKRSImmunglobulinTuru>();
    @Type(() => SKRSHayvaninSahiplikDurumu)
    public SKRSHayvaninSahiplikDurumus: Array<SKRSHayvaninSahiplikDurumu> = new Array<SKRSHayvaninSahiplikDurumu>();
    @Type(() => SKRSHayvaninMevcutDurumu)
    public SKRSHayvaninMevcutDurumus: Array<SKRSHayvaninMevcutDurumu> = new Array<SKRSHayvaninMevcutDurumu>();
    @Type(() => SKRSTelefonTipi)
    public SKRSTelefonTipis: Array<SKRSTelefonTipi> = new Array<SKRSTelefonTipi>();
    @Type(() => SKRSRiskliTemasTipi)
    public SKRSRiskliTemasTipis: Array<SKRSRiskliTemasTipi> = new Array<SKRSRiskliTemasTipi>();
    @Type(() => SKRSKisiyePlanlananKuduzProfilaksisi)
    public SKRSKisiyePlanlananKuduzProfilaksisis: Array<SKRSKisiyePlanlananKuduzProfilaksisi> = new Array<SKRSKisiyePlanlananKuduzProfilaksisi>();
    @Type(() => SKRSAdresTipi)
    public SKRSAdresTipis: Array<SKRSAdresTipi> = new Array<SKRSAdresTipi>();
    @Type(() => SKRSBucakKodlari)
    public SKRSBucakKodlaris: Array<SKRSBucakKodlari> = new Array<SKRSBucakKodlari>();
    @Type(() => SKRSCSBMTipi)
    public SKRSCSBMTipis: Array<SKRSCSBMTipi> = new Array<SKRSCSBMTipi>();
    @Type(() => SKRSIlceKodlari)
    public SKRSIlceKodlaris: Array<SKRSIlceKodlari> = new Array<SKRSIlceKodlari>();
    @Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    @Type(() => SKRSKoyKodlari)
    public SKRSKoyKodlaris: Array<SKRSKoyKodlari> = new Array<SKRSKoyKodlari>();
    @Type(() => SKRSMahalleKodlari)
    public SKRSMahalleKodlaris: Array<SKRSMahalleKodlari> = new Array<SKRSMahalleKodlari>();
}
