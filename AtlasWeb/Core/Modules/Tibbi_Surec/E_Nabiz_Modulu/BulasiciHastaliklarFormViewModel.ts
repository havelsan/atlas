//$C42B0B7D
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BulasiciHastaliklarEA } from 'NebulaClient/Model/AtlasClientModel';
import { BulasiciHastalikTelefon } from 'NebulaClient/Model/AtlasClientModel';
import { BulasiciHastalikVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCSBMTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMahalleKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKoyKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBucakKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTelefonTipi } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICD } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSVakaTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIlceKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BulasiciHastaliklarFormViewModel extends BaseViewModel {
    @Type(() => BulasiciHastaliklarEA)
    public _BulasiciHastaliklarEA: BulasiciHastaliklarEA = new BulasiciHastaliklarEA();
    @Type(() => BulasiciHastalikTelefon)
    public BulasiciHastalikTelefonBulasiciHastalikTelefonGridList: Array<BulasiciHastalikTelefon> = new Array<BulasiciHastalikTelefon>();
    @Type(() => BulasiciHastalikVeriSeti)
    public BulasiciHastalikVeriSetis: Array<BulasiciHastalikVeriSeti> = new Array<BulasiciHastalikVeriSeti>();
    @Type(() => SKRSCSBMTipi)
    public SKRSCSBMTipis: Array<SKRSCSBMTipi> = new Array<SKRSCSBMTipi>();
    @Type(() => SKRSMahalleKodlari)
    public SKRSMahalleKodlaris: Array<SKRSMahalleKodlari> = new Array<SKRSMahalleKodlari>();
    @Type(() => SKRSKoyKodlari)
    public SKRSKoyKodlaris: Array<SKRSKoyKodlari> = new Array<SKRSKoyKodlari>();
    @Type(() => SKRSBucakKodlari)
    public SKRSBucakKodlaris: Array<SKRSBucakKodlari> = new Array<SKRSBucakKodlari>();
    @Type(() => SKRSTelefonTipi)
    public SKRSTelefonTipis: Array<SKRSTelefonTipi> = new Array<SKRSTelefonTipi>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSICD)
    public SKRSICDs: Array<SKRSICD> = new Array<SKRSICD>();
    @Type(() => SKRSVakaTipi)
    public SKRSVakaTipis: Array<SKRSVakaTipi> = new Array<SKRSVakaTipi>();
    @Type(() => SKRSIlceKodlari)
    public SKRSIlceKodlaris: Array<SKRSIlceKodlari> = new Array<SKRSIlceKodlari>();
    @Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
}
