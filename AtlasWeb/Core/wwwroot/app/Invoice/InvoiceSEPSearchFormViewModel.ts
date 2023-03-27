//$5FFBDD1F

import { Guid } from "NebulaClient/Mscorlib/Guid";
import { InvoiceSEPResultGrid } from "./InvoiceSEPSearchResultFormViewModel";
import { InvoiceEpisodeResultGrid } from "./InvoiceEpisodeSearchResultFormViewModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class InvoiceSEPSearchFormModel {

    public InvoiceSEPSearchCriteria: InvoiceSEPSearchCriteria;


    constructor() {
        this.InvoiceSEPSearchCriteria = new InvoiceSEPSearchCriteria();
    }

}

export class InvoiceSearchResultModel {
    public EpisodeResultList: Array<InvoiceEpisodeResultGrid>;
    public SEPResultList: Array<InvoiceSEPResultGrid>;

    constructor() {
        this.SEPResultList = new Array<InvoiceSEPResultGrid>();
        this.EpisodeResultList = new Array<InvoiceEpisodeResultGrid>();
    }
}


export class InvoiceSEPSearchCriteria {
    @Type(() => Date)
    public episodeStartDate: Date = null;
    @Type(() => Date)
    public episodeEndDate: Date = null;
    @Type(() => Date)
    public inPatientAdmissionStartDate: Date = null;
    @Type(() => Date)
    public inPatientAdmissionEndDate: Date = null;
    @Type(() => Date)
    public dischargeStartDate: Date = null;
    @Type(() => Date)
    public dischargeEndDate: Date = null;
    @Type(() => Date)
    public invoiceStartDate: Date = null;
    @Type(() => Date)
    public invoiceEndDate: Date = null;
    public status: Array<number>;
    public controlStatus: Array<string>;
    public procedureStateDef: Array<Guid>;
    public tedaviTuru: Array<Guid>;
    public tedaviTipi: Array<Guid>;
    public takipTipi: Array<Guid>;
    public provizyonTipi: Array<Guid>;
    public devredilenKurum: Array<Guid>;
    public term: Guid;
    public payerType: Guid;
    public payer: Guid;
    public building: Guid;
    public section: Guid;
    public branch: Guid;
    public doctor: Guid;
    public invoiceBlockingState: Guid;
    public diagnosState: Guid;
    public diagnos: Guid;
    public procedure1State: Guid;
    public procedure1: Guid;
    public procedure2State: Guid;
    public procedure2: Guid;
    public materialState: Guid;
    public material: Guid;
    public materialGroupState: Guid;
    public materialGroup: Guid;
    public procedureGroupState: Guid;
    public procedureGroup: string;
    public procedureSUTAppendixState: Guid;
    public procedureSUTAppendix: Guid;
    public bagliTakip: Guid;
    public controlEpisode: Guid;
    public bannedInvoice: Guid;
    public inPatientPackage: Guid;
    public examination: Guid;
    public flowableProcedure: Guid;
    public traficAccidentForm: Guid;
    public invoiceCancel: number;
    public accTrxUnitPriceUpdate: number;
    public epicrisis: number;
    public followList: Guid;
    public patientName: string;
    public patientSurname: string;
    public patientUniqueRefNo: string;
    public episodeProtocolNo: string;
    public takipNo: string;
    public basvuruNo: string;
    public inPatientAdmissionNo: string;
    public patientAdmissionNo: string;
    public InvoiceSearchType: number;
    public searchResultType: string;
    public tabOpenType: string;
    public sepWatchType: number;
    public inPatientStatus: number;
    public onlyStatus: boolean;
    public tedaviTuruSadeceAyaktan: boolean;
    public investigation: boolean;
    public checkedValue: boolean;
    public sex: Guid;
    public treatmentResult: number;
    public FirstSelectErrorCode: Guid;
    public SecondSelectErrorCode: string;
    public istisnaiHal: Array<Guid>;
    public triaj: Array<Guid>;
    public nabizStatus: number;
    public BannedState: Guid; 
    public specialCase: number;
    public firstInvoicePrice: number;
    public lastInvoicePrice: number;
    public lastXDaysForInvoice: number;
    public InvoiceUser: Guid;
    public SEPDescriptionState: Guid;
    public SEPDescription: string;
    public admissionStatus: number;
    public taburcuTipi: Array<Guid>;
    constructor() {
        //  this.payer = new listboxObject();
        //  this.section = new listboxObject();
        //  this.branch = new listboxObject();
        //  this.doctor = new listboxObject();
        //  this.diagnos = new listboxObject();
        //  this.procedure1 = new listboxObject();
        //  this.procedure2 = new listboxObject();
        //  this.material = new listboxObject();
        //  this.materialGroup = new listboxObject();
        this.InvoiceSearchType = 0;
        this.status = new Array<number>();
       
        this.searchResultType = i18n("M22633", "Takip");
        this.tabOpenType = i18n("M24515", "Yeni");
    }

}


