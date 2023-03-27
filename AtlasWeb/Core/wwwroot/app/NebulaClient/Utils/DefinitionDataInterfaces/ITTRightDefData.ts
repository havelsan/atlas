import { Guid } from "../../Mscorlib/Guid";
import { RightDefTargetEnum } from "../Enums/RightDefTargetEnum";

export interface ITTRightDefData {
    RightDefID: number;
    PermissionDefID: Guid;
    Name: string;
    Target: RightDefTargetEnum;
}