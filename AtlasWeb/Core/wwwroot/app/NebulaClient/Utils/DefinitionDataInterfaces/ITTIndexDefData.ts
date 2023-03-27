import { Guid } from "../../Mscorlib/Guid";
import { ICollection } from "../../System/Collections/ICollection";

export interface ITTIndexDefData {
    IndexDefID: Guid;
    ObjectDefID: Guid;
    Name: string;
    Description: string;
    IsUnique: boolean;
    StorageParameters: string;
    MemberDefs: ICollection<any>;
}