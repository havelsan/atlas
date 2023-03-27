
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { InvoiceSEPSearchCriteria } from "./InvoiceSEPSearchFormViewModel";

export class InvoiceEpisodeSearchResultFormModel
{

    public InvoiceEpisodeResultList: InvoiceEpisodeResultGrid[];
    public InvoiceSEPSearchCriteria: InvoiceSEPSearchCriteria;
    constructor()
    {
        this.InvoiceEpisodeResultList = new Array<InvoiceEpisodeResultGrid>();
    }

}


export class InvoiceEpisodeResultGrid
{
    public ObjectID: Guid; //SepObjectID
    public Episode: Guid;
    public HospitalProtocolNo: string;
    public FaturaTutari: Currency;
    public HBYSTutari: Currency;
    public Date: Date;
    public InPatientDate: Date;
    public DischargeDate: Date;
    public Patientname: string;
    public Patientsurname: string;
    public Specialityname: string;
    public Status: Object;
    public Tedavituru: string;
    public UniqueRefNo: number;
    public Payername: string;
    public PayetTypeEnum: number;
    public ICName: string;
    public ICNo: string;
}


