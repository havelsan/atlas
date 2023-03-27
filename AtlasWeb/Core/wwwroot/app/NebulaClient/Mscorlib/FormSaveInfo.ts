import { AsyncSubject } from "rxjs";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";

export class FormSaveInfo {
    constructor(public objectDefId: string,
    public saveAndClose: boolean) {
    }

    public saveCompleted: AsyncSubject<Object>;
    public transDef: TTObjectStateTransitionDef;
}