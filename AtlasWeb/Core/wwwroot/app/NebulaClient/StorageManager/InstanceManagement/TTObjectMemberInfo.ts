import { RequirementEnum } from "../../Utils/Enums/RequirementEnum";
import { ProtectionEnum } from "../../Utils/Enums/ProtectionEnum";
import { TTObjectPropertyDef } from "../DefinitionManagement/TTObjectPropertyDef";
import { TTObjectCodedPropertyDef } from "../DefinitionManagement/TTObjectCodedPropertyDef";
import { TTObjectRelationDef } from "../DefinitionManagement/TTObjectRelationDef";

export class TTObjectMemberInfo {
    public Requirement: RequirementEnum;
    public Protection: ProtectionEnum;
    public PropertyDef: TTObjectPropertyDef;
    public CodedPropertyDef: TTObjectCodedPropertyDef;
    public RelationDef: TTObjectRelationDef;
}
