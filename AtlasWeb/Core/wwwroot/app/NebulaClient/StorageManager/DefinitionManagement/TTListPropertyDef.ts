import { Guid } from "../../Mscorlib/Guid";
import { TTObjectPropertyDef } from "./TTObjectPropertyDef";
import { ListPropertyDefAccessEnum } from "../../Utils/Enums/ListPropertyDefAccessEnum";
import { TTListDef } from "./TTListDef";
import { TTObjectCodedPropertyDef } from "./TTObjectCodedPropertyDef";
import { TTFormFieldDef } from "./TTFormFieldDef";
import { TTDataType } from "../../DataDictionary/TTDataType";

export class TTListPropertyDef {
    public ListDef: TTListDef;
    public ListDefID: Guid;
    public ListPropertyDefID: Guid;
    public PropertyDef: TTObjectPropertyDef;
    public CodedPropertyDef: TTObjectCodedPropertyDef;
    public MemberName: string;
    public DataType: TTDataType;
    public Caption: string;
    public AccessType: ListPropertyDefAccessEnum;
    public CriteriaOrder: number;
    public ControlWidth: number;
    public FormFieldDef: TTFormFieldDef;
    public FormFieldDefID: Guid;
    public IsPartialLeft: boolean;
    public IsPartialRight: boolean;
    public IsPartialFull: boolean;
    public IsPartial: boolean;
    public ToString(): string {
        return null;
    }
    public GetFilterExpression(userData: string): string {
        return null;
    }
}
