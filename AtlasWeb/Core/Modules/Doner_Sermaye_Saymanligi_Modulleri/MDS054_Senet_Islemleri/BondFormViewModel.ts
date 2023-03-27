//$13206EA9
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Bond } from 'NebulaClient/Model/AtlasClientModel';
import { BondDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BondProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { BondPerson } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIlceKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { BondDocument } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";

export class BondFormViewModel extends BaseViewModel {
    @Type(() => Bond)
    public _Bond: Bond = new Bond();
    @Type(() => BondDetail)
    public GrdBondDetailsGridList: Array<BondDetail> = new Array<BondDetail>();
    @Type(() => BondProcedure)
    public GrdBondProcedureGridList: Array<BondProcedure> = new Array<BondProcedure>();
    @Type(() => BondPerson)
    public BondPersons: Array<BondPerson> = new Array<BondPerson>();
    @Type(() => SKRSIlceKodlari)
    public SKRSIlceKodlaris: Array<SKRSIlceKodlari> = new Array<SKRSIlceKodlari>();
    @Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    @Type(() => Bond)
    public Bonds: Array<Bond> = new Array<Bond>();
    @Type(() => BondDocument)
    public BondDocuments: Array<BondDocument> = new Array<BondDocument>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Number)
    public OutPatientBondDayVariable: number;
    @Type(() => Number)
    public InPatientBondDayVariable: number;
    @Type(() => Number)
    public NumberOfPayments: number;
}
