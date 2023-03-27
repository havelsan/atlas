import { BaseViewModel } from "app/NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { Type } from "app/NebulaClient/ClassTransformer";

export class PatientFolderContentDefFormViewModel extends BaseViewModel {
 @Type(() => PatientFolderContent)
 public FolderList: Array<PatientFolderContent>;
}

export class PatientFolderContent {
    public ObjectID: Guid;
    public Name: string;
    public Active: boolean;
}
