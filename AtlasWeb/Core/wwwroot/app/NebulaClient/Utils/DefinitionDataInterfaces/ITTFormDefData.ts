import { Guid } from "../../Mscorlib/Guid";
import { ITTUnboundFormDefData } from "./ITTUnboundFormDefData";
import { FormTypeEnum } from "../Enums/FormTypeEnum";

export interface ITTFormDefData extends ITTUnboundFormDefData {
    ObjectDefID: Guid;
    PreScript: string;
    PostScript: string;
    FormType: FormTypeEnum;
}