import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Patient, Episode } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from "NebulaClient/ClassTransformer";

export class EpisodeInfoDto {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Date)
    public OpeningDate: Date;
    public MainSpeciality: string;
    @Type(() => Number)
    public ID: number;
    @Type(() => Date)
    public ClosingDate: Date;
}

export class ProcedureDto {
    @Type(() => Guid)
    public ObjectID: string;
    public Code: string;
    public Name: string;
}

export class DoctorDto {
    @Type(() => Guid)
    public ObjectID: string;
    public ID: number;
    public Name: string;
}

export class SpecialityDto {
    @Type(() => Guid)
    public ObjectID: string;
    public Code: string;
    public Name: string;
}


export class EpisodeList {
    public Episodes: Array<EpisodeInfoDto>;
}

export class ProcedureList {
    public Procedures: Array<ProcedureDto>;
    public TotalCount: number;
}

export class DoctorList {
    public Doctors: Array<DoctorDto>;
    public TotalCount: number;
}

export class SpecialityList {
    public Specialities: Array<SpecialityDto>;
    public TotalCount: number;
}

export class TestComponentViewModel extends BaseViewModel {
    public Patient: Patient;
    public Episodes: Array<Episode>;
}

export class EpisodeRequestInfo {
    public EpisodeID: Guid;
    public RequestDetails: Array<EpisodeRequestDetailInfo>;
}

export class EpisodeRequestDetailInfo {
    public DetailID: Guid;
    public RequestDate: Date;
    public ProcedureCode: string;
    public ProcedureName: string;
    public Quantity: number;
    public RequestDoctor: string;
}

export class DataSourceParams {
    public Filter: string;
    public Sort: string;
    public Group: string;
    public Skip?: number;
    public Take?: number;
    public Select: string;
    public SearchValue: string;
    public SearchOperation: string;
    public SearchExpr: string;
}