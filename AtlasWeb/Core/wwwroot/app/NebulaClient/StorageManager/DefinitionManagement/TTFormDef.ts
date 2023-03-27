import { Guid } from "../../Mscorlib/Guid";
import { TTObjectDef } from "../DefinitionManagement/TTObjectDef";
import { FormTypeEnum } from "../../Utils/Enums/FormTypeEnum";
import { TTPermissionDef } from "./TTPermissionDef";

export class TTFormDef {
    public PermissionDefID: Guid;
    public PermissionDef: TTPermissionDef;
    public ObjectDef: TTObjectDef;
    public ObjectDefID: Guid;
    public PreScript: string;
    public PostScript: string;
    public ClientSidePreScript: string;
    public ClientSidePostScript: string;
    public FormType: FormTypeEnum;
    public HelpNameSpace: string;
    public ToString(): string {
        return null;
    }
    public GetChildObjectDef(dataMember: string): TTObjectDef {
        return null;
    }
}
