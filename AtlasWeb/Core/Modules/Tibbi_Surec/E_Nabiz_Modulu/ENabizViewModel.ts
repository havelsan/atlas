import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";

export class ENabizDataSets {
    @Type(() => Number)
    public PackageID: number;
    public PackageName: string;
    @Type(() => Guid)
    public DiagnosisObjectID: Guid;
    @Type(() => Guid)
    public ObjectID: Guid;

}

export class DataSetViewModel extends BaseViewModel{
    @Type(() => ENabizDataSets)
    public _DatasetList: Array<ENabizDataSets> = new Array<ENabizDataSets>();
}

export class EnabizInputObject {
    public ENabizDataSets: Array<ENabizDataSets> = new Array<ENabizDataSets>();
    public EpisodeActionID: Guid;
}

export class DataSetInput {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public EpisodeActionID: Guid;
    @Type(() => Guid)
    public DiagnosisObjectID: Guid;
}