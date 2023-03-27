
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { InvoiceSEPSearchCriteria } from "./InvoiceSEPSearchFormViewModel";
import DateTime from "app/NebulaClient/System/Time/DateTime";

export class InvoiceSEPSearchResultFormModel
{

    public InvoiceSEPResultList: InvoiceSEPResultGrid[];
    public InvoiceSEPSearchCriteria: InvoiceSEPSearchCriteria;
    constructor()
    {
        this.InvoiceSEPSearchCriteria = new InvoiceSEPSearchCriteria();
        this.InvoiceSEPResultList = new Array<InvoiceSEPResultGrid>();
    }

}

export class TrxTotalAmount_Model
{
    public procedure: Guid;
    public amount: number;
    public unitPrice: number;
    public totalPrice: number;
    public externalCode: string;
    public description: string;
    public choice: number;
}

export class InvoiceSEPResultGrid
{
    public ObjectID: string;
    public Episode: string;
    public HospitalProtocolNo: string;
    public MedulaBasvuruNo: string;
    public Medulafaturatutari: Currency;
    public HBYSTutari: Currency;
    public MedulaTakipNo: string;
    public Medulatakipno1: string;
    public Date: Date;
    public InPatientDate: Date;
    public DischargeDate: Date;
    public Patientname: string;
    public Patientsurname: string;
    public Specialityname: string;
    public Status: any;
    public SubEpisode: string;
    public Tedavituru: string;
    public UniqueRefNo: number;
    public Id: number;
    public Payername: string;
    public PayetTypeEnum: number;
    public IzlemUser: string;
    public ICName: string;
    public ICNo: string;
    public MedulaSonucKodu: string;
    public MedulaSonucMesaji: string;
    public RessectionName: string;
}

export class ButtonVisibityOnPopup {
    public takipAl: boolean;
    public takipSil: boolean;
    public takipOku: boolean;
    public takipBazliHizmetKayit: boolean;
    public takipBazliHizmetKayitIptal: boolean;
    public kuralCalistir: boolean;
    public faturaKayit: boolean;
    public faturaIptal: boolean;
    public faturaTutarOku: boolean;
    public arrangeInvoice: boolean;
    
    public changeDoctor: boolean;
    public addDiagnosis: boolean;
    public addMedulaDescription: boolean;
    public fix1108: boolean;
    public faturaKayitOnFix: boolean;
    public SetDonotSendMedula: boolean;
    public SendNabiz: boolean;
    public SendNabiz700: boolean;
    public faturaTutarOkuFix: boolean;
    public takipBazliHizmetKayitFix: boolean;

    constructor() {
        this.takipAl = false;
        this.takipSil = false;
        this.takipOku = false;
        this.takipBazliHizmetKayit = false;
        this.takipBazliHizmetKayitIptal = false;
        this.kuralCalistir = false;
        this.faturaKayit = false;
        this.faturaIptal = false;
        this.faturaTutarOku = false;
        this.arrangeInvoice = false;
        this.SendNabiz700 = false;

        this.changeDoctor= false;
        this.addDiagnosis= false;
        this.addMedulaDescription= false;
        this.fix1108= false;
        this.faturaKayitOnFix= false;
        this.SetDonotSendMedula = false;
        this.SendNabiz = false;
        this.faturaTutarOkuFix= false;
        this.takipBazliHizmetKayitFix= false;
    }
}
export class SavedTaskListModel{
    public CioObjectID: Guid;
    public CreateDate: Date
    public ExecDate: Date;
    public Status: string;
    public CurrentStateDefID: Guid;
}
export class TaskListModel{
    public Order : number;
    public TaskString: string;
    public TaskEnum: number;
    public NextTaskEnum: number;
    public Detail: string;
    public SearchCriteria: InvoiceSEPSearchCriteria;
    public TotalCount :number;
    public NewCount :number;
    public SuccesCount:number;
    public ErrorCount :number;
}
export class FixTaskListModel extends TaskListModel {
    public ErrorCodeText: string;
    public SutCode: string;
    public ErrorCode: Guid;
}
export class ScheduledTaskModel{
    public TaskList: Array<TaskListModel> = new Array<TaskListModel>(); 
    public FixTaskList: Array<FixTaskListModel> = new Array<FixTaskListModel>();
    public ExecTime:DateTime ;
    public ObjectID: Guid;
    constructor()
    {
        this.FixTaskList = new Array<FixTaskListModel>();
        this.TaskList = new Array<TaskListModel>();
    }
}
export class ScheduledTaskViewModel {
    
    public Task:ScheduledTaskModel;
    public SavedTaskList: Array<SavedTaskListModel>;
    constructor()
    { 
        this.Task = new ScheduledTaskModel();
        this.SavedTaskList = new Array<SavedTaskListModel>();
       
    }
}

