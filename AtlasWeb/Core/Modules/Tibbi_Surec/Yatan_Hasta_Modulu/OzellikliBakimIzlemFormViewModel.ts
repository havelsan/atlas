//$B8EEFEE0
import { BaseViewModel } from "../../../wwwroot/app/NebulaClient/Model/BaseViewModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class OzellikliBakimIzlemFormViewModel extends BaseViewModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => DataModel)
    public SKRSDurumList: Array<DataModel> = new Array<DataModel>();
    @Type(() => DataModel)
    public SKRSBtCekimDurumuList: Array<DataModel> = new Array<DataModel>();
    @Type(() => DataModel)
    public SKRSGenelDurumList: Array<DataModel> = new Array<DataModel>();
    @Type(() => Guid)
    public Azitromisin: Guid;
    @Type(() => Guid)
    public CTResult: Guid;
    @Type(() => Guid)
    public FavipavirAvigan: Guid;
    @Type(() => Guid)
    public GeneralStatus: Guid;
    @Type(() => Guid)
    public HasClinicalFinding: Guid;
    @Type(() => Guid)
    public HasCT: Guid;
    @Type(() => Guid)
    public HasIntubation: Guid;
    @Type(() => Guid)
    public HasPneumonia: Guid;
    @Type(() => Guid)
    public HighDoseCvitamin: Guid;
    @Type(() => Guid)
    public Hydroxychloroquine: Guid;
    @Type(() => Guid)
    public IsIntensiveCare: Guid;
    @Type(() => Guid)
    public IsIsolatedInpatient: Guid;
    @Type(() => Guid)
    public Kaletra: Guid;
    @Type(() => Guid)
    public NonCovidInpatient: Guid;
    @Type(() => Guid)
    public Oseltamivir: Guid;
    public Description: Object;
    public PaoFioRatio: number;
    public ProgressDate: Date = new Date();
    public InpatientPhysicianProgressesID: Guid;
    public InpatientPhysicianAppId: Guid;
}

export class DataModel {
    public Id: Guid;
    public Name: string;
}

export class ProgressMedicineParameter {
    public physicianappId: Guid;
    public progressDate: Date;
}

export class ProgressMedicineValues {
    public Azitromisin: Guid;
    public FavipavirAvigan: Guid;
    public HighDoseCvitamin: Guid;
    public Hydroxychloroquine: Guid;
    public Kaletra: Guid;
    public Oseltamivir: Guid;
}

export class OzellikliBakimIzlemParameterModel {
    public id: Guid;
    public physicianAppId: Guid;
}
