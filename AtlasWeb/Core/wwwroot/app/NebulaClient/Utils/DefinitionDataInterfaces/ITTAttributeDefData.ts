import { Guid } from "../../Mscorlib/Guid";
import { ITTObjectDefBaseData } from "./ITTObjectDefBaseData";
import { AttributeTargetEnum } from "../Enums/AttributeTargetEnum";
import { AttributeEventTypeEnum } from "../Enums/AttributeEventTypeEnum";
import { AttributeWhenEnum } from "../Enums/AttributeWhenEnum";

export interface ITTAttributeDefData extends ITTObjectDefBaseData {
    InterfaceDefID: Guid;
    Body: string;
    CheckBody: string;
    Target: AttributeTargetEnum;
    EventType: AttributeEventTypeEnum;
    When: AttributeWhenEnum;
}