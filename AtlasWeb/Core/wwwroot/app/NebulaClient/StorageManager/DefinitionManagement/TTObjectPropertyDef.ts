import { Guid } from "../../Mscorlib/Guid";
import { TTObjectDef } from "./TTObjectDef";
import { TTObjectStateDef } from "./TTObjectStateDef";
import { TTDataType } from "../../DataDictionary/TTDataType";
import { PropertyDefaultValueTypeEnum } from "../../Utils/Enums/PropertyDefaultValueTypeEnum";

export class TTObjectPropertyDef {
    public ObjectDef: TTObjectDef;
    public ObjectDefID: Guid;
    public PropertyDefID: Guid;
    public ShadowOfPropertyDefID: Guid;
    public CodeName: string;
    public Name: string;
    public Description: string;
    public Caption: string;
    public SetScript: string;
    public DataType: TTDataType;
    public DataTypeID: Guid;
    public DefaultValueType: PropertyDefaultValueTypeEnum;
    public DefaultValue: Object;
    public IsDynamic: boolean;
    public IsRequired: boolean;
    public IsProtected: boolean;
    public IsNoLock: boolean;
    //public ParentPropagations: ReadOnlyCollection<TTPropertyPropagationDef>;
    //public ChildPropagations: ReadOnlyCollection<TTPropertyPropagationDef>;
    //public ShadowProperties: ReadOnlyCollection<TTObjectPropertyDef>;
    public IsProtectedOnState(stateDef: TTObjectStateDef): boolean {
        return null;
    }
    public IsCompatibleValue(value: Object): boolean {
        return null;
    }
    public GetSqlLiteral(value: Object): string {
        return null;
    }
    public GetNqlLiteral(value: Object): string {
        return null;
    }
    public ToString(): string {
        return null;
    }
}
