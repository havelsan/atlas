import { Guid } from "../../Mscorlib/Guid";
import { TTObjectSubTypeEnum } from "../../Utils/Enums/TTObjectSubTypeEnum";
import { TTInterfaceDef } from "./TTInterfaceDef";
import { AttributeTargetEnum } from "../../Utils/Enums/AttributeTargetEnum";
import { AttributeEventTypeEnum } from "../../Utils/Enums/AttributeEventTypeEnum";
import { AttributeWhenEnum } from "../../Utils/Enums/AttributeWhenEnum";
import { TTDefCollection } from "./TTDefCollection";
import { TTAttributeParameterDef } from "./TTAttributeParameterDef";

export class TTAttributeDef {
    public SubType: TTObjectSubTypeEnum;
    public InterfaceDef: TTInterfaceDef;
    public InterfaceDefID: Guid;
    public Body: string;
    public CheckBody: string;
    public Target: AttributeTargetEnum;
    public EventType: AttributeEventTypeEnum;
    public When: AttributeWhenEnum;
    public AllParameterDefs: TTDefCollection<TTAttributeParameterDef>;
    public CanBeRun(target: AttributeTargetEnum, eventType: AttributeEventTypeEnum, when: AttributeWhenEnum): boolean {
        return null;
    }
}
