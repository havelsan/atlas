

//$08330762
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { TigEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { TIGPatientTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from "NebulaClient/ClassTransformer";


export class TigEpisodeFormViewModel extends BaseViewModel {
    @Type(() => TigEpisode)
    public _TigEpisode: TigEpisode = new TigEpisode();
    public TigEpisodeFormSearchModel: TigEpisodeFormSearchModel;
    public TigEpisodeCollectionList: TigEpisodeSearchResultModel[];

    constructor() {
        super();
        this.TigEpisodeCollectionList = new Array<TigEpisodeSearchResultModel>();
        this.TigEpisodeFormSearchModel = new TigEpisodeFormSearchModel();
    }
    public selectedEpisode: Guid = null;
}

export class TigEpisodeFormSearchModel {
    public DischargeDateBegin: Date = null;
    public DischargeDateEnd: Date = null;
    public XMLCreationDateBegin: Date = null;
    public XMLCreationDateEnd: Date = null;
    public CodingDateBegin: Date = null;
    public CodingDateEnd: Date = null;
    public PatientType: TIGPatientTypeEnum = null;
    public XMLStatus: number = null;
    public CodingStatus: number = null;
    public InvoiceStatus: number = null;
    public PathologyRequestStatus: number = null;
    public PathologyReportStatus: number = null;
    public AppointmentStatus: number = null;
    public EpicrisisStatus: number = null;
    public SelectedDoctorsListItems: Array<TagBoxObject> = new Array<TagBoxObject>();
    public SelectedClinicsListItems: Array<TagBoxObject> = new Array<TagBoxObject>();
    public SelectedSpecialitiesListItems: Array<TagBoxObject> = new Array<TagBoxObject>();
    public SelectedXMLCreatedByUserListItems: Array<TagBoxObject> = new Array<TagBoxObject>();
    public SelectedCodingByUserListItems: Array<TagBoxObject> = new Array<TagBoxObject>();
    public Description: string = null;
    public ProtocolNo: string = null;
    public ArchiveNo: string = null;
    public PatientID: Guid = null;

}

export class TigEpisodeSearchResultModel {
    public TigObjectID: Guid = null;
    public EpisodeGuid: Guid = null;
    public EpisodeNo: string = null;
    public PatientName: string = null;
    public PatientSurname: string = null;
    public PatientUniqueRefNo: string = null;
    public Resource: string = null;
    public InpatientDate: Date = null;
    public DischargeDate: Date = null;
    public XMLStatus: boolean = null;
    public XMLCreationDate: boolean = null;
    public CodingStatus: boolean = null;
    public CodingDate: Date = null;
    public Description: string = null;
    public InvoiceNum: string = null;
    public DoctorName: string = null;
    public DoctorUniqueRefNo: string = null;
    public DischargerDoctorName: string = null;
    public BranchName: string = null;
    public BranchCode: string = null;
    public PayerName: string = null;
    public PatientType: string = null;
    public Diagnosis: string = null;
    public InPatientProtocolNo: string = null;
    public Surgeries: string = null;
    public AppointmentDate: Date = null;
    public PathologyRequest: string = null;
    public PathologyStatus: string = null;
    public XMLCreatedByUserName: string = null;
    public CodingByUserName: string = null;
    public RecordType: string = null;
}

export class TagBoxObject {
    public ObjectID: number;
    public Name: string;
}