import { InvoiceTerm } from 'NebulaClient/Model/AtlasClientModel';

export class InvoiceTermFormViewModel
{
    public InvoiceTermList: InvoiceTerm[];
}

export class InvoiceTermFormDetailViewModel
{
    public ProcedureTotal: number;
    public FaturaTutari: number;
    public DrugTotal: number;
    public MaterialTotal: number;
    public FaturaSayisi: number;
    public SonIslemiYapan: string;
    public LastUpdateDate: Date;
    public InvoicePrice: Currency;
    public InvoiceCollectionList: any[];
}