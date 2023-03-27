import { Guid } from "../../Mscorlib/Guid";
import { StateStatusEnum } from "../Enums/StateStatusEnum";
import { IList } from "../../System/Collections/IList";

export interface ITTObjectStateDefData {
    ObjectDefID: Guid;
    StateDefID: Guid;
    Name: string;
    Description: string;
    DisplayText: string;
    BaseStateDefID: Guid;
    IsEntry: boolean;
    IsPropertiesProtected: boolean;
    Status: StateStatusEnum;
    FormDefID: Guid;
    GetDerivedStateDefIDs(): IList<Guid>;
    Disabled: boolean;
}