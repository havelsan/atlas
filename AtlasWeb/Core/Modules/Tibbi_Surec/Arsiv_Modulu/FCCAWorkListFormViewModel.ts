//$ADD2B22C
import { EpisodeFolder } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { PatientStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import List from 'app/NebulaClient/System/Collections/List';

export class FCCAWorkListFormViewModel extends BaseViewModel {
    @Type(() => WorkListModel)
    dataSource: Array<WorkListModel> = new Array<WorkListModel>();
    @Type(() => WorkListQueryFilter)
    QueryModel: WorkListQueryFilter;
    @Type(() => ArchiveRequestSourceModel)
    archiveRequestDataSource: Array<ArchiveRequestSourceModel> = new Array<ArchiveRequestSourceModel>();
    @Type(() => ArchiveRequestSource)
    requestWorkListModel: Array<ArchiveRequestSource> = new Array<ArchiveRequestSource>(); //yeri:istek olan arsivleri arsiv is listesi ekraninda listelemek icin

    constructor() {
        super();
        this.QueryModel = new WorkListQueryFilter();
    }
}

export class WorkListQueryFilter {

    psEnum: PatientStatusEnum;
    @Type(() => Guid)
    FolderLocation: Guid;
    @Type(() => Date)
    StartDate: Date = new Date();
    @Type(() => Date)
    EndDate: Date = new Date();
    @Type(() => Guid)
    Location: Guid;
    @Type(() => Date)
    public ArchiveStartDate: Date;
    @Type(() => Date)
    public ArchiveEndDate: Date;
    @Type(() => String)
    public ProtocolNo: string;
    @Type(() => String)
    public PatientUniqueRefNo: string;
    @Type(() => Guid)
    public PatientObjectID: Guid;

    @Type(() => Object)
    _selectedDiagnosis: Object;
    public selectedDiagnosis: any = [];
    public selectedDiagnosisStr: string;
    public episodeFolderID: string;

    constructor() {

    }
}

export class ArchiveRequestSourceModel{
        FileCreationAndAnalysis: Guid;
        ObjectID: Guid;
        EpisodeFolderID: string;
        Name: string;
        ProcedureDoctor: Guid;
        Ptname: Object;
        MotherName: string;
        FatherName: string;
        BirthDate: Date;
        UniqueRefNo: number;
        Shelf: string;
        Row: string;
        PatientFolderID: number;
        Episode: Guid;
        HospitalDischargeDate: Date;
        HospitalInPatientDate: Date;
        ProtocolNo: string;
        DisplayText: string;
        CurrentStateDefID: Guid;
        ManuelArchiveNo: string;
        FolderLocation: string;

}

export class ArchiveRequestSource{
    FileCreationAndAnalysis: Guid;
    ObjectID: Guid;
    EpisodeFolderID: string;
    Name: string;
    ProcedureDoctor: Guid;
    Ptname: Object;
    MotherName: string;
    FatherName: string;
    BirthDate: Date;
    UniqueRefNo: number;
    Shelf: string;
    Row: string;
    PatientFolderID: number;
    Episode: Guid;
    HospitalDischargeDate: Date;
    HospitalInPatientDate: Date;
    ProtocolNo: string;
    DisplayText: string;
    CurrentStateDefID: Guid;
    ManuelArchiveNo: string;
    FolderLocation: string;
    RequesterName: string;
    Description: string;
    RequesterSection: string;
    @Type(() => Date)
    RequestDate: Date;
    RequesterSectionID: Guid;
    RequestID: Guid;

}

export class RequesterSectionModel{
    RequesterSectionName: string;
    RequesterSectionID: Guid;
}

export class WorkListModel{
    FileCreationAndAnalysis: Guid;
    ObjectID: Guid;
    EpisodeFolderID: string;
    Name: string;
    ProcedureDoctor: Guid;
    Ptname: Object;
    MotherName: string;
    FatherName: string;
    BirthDate: Date;
    UniqueRefNo: number;
    Shelf: string;
    Row: string;
    PatientFolderID: number;
    Episode: Guid;
    HospitalDischargeDate: Date;
    HospitalInPatientDate: Date;
    ProtocolNo: string;
    DisplayText: string;
    CurrentStateDefID: Guid;
    ManuelArchiveNo: string;
    ShelfName: string;
    CabinetName: string;

}