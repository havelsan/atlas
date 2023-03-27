import { Guid } from "../../Mscorlib/Guid";
import { TTDataType } from "../../DataDictionary/TTDataType";
import { TTAttributeDef } from "./TTAttributeDef";
import { AttributeParameterSubtypeEnum } from "../../Utils/Enums/AttributeParameterSubtypeEnum";
import { AttributeParameterTargetEnum } from "../../Utils/Enums/AttributeParameterTargetEnum";
import { TTObjectDef } from "../DefinitionManagement/TTObjectDef";

export class TTAttributeParameterDef {
    public AttributeDef: TTAttributeDef;
    public AttributeDefID: Guid;
    public ParameterDefID: Guid;
    public Name: string;
    public Description: string;
    public DataType: TTDataType;
    public DataTypeID: Guid;
    public IsRequired: boolean;
    public ObjectDef: TTObjectDef;
    public ObjectDefID: Guid;
    public SubType: AttributeParameterSubtypeEnum;
    public Target: AttributeParameterTargetEnum;
    public ToString(): string {
        return null;
    }
}
