import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from "@angular/core";

export class DynamicComponentInfo {
    public ComponentType?: Type<any>;
    public ComponentName?: string;
    public ModuleName?: string;
    public ModulePath?: string;
    public objectID: string;
    public ParentObjectID?: Guid;
    public InputParam: any;
    public RenderPreCheckUri?: string;
    public CloseWithStateTransition?: boolean;
    public DestroyComponentOnSave?: boolean;
    public RefreshComponent?: boolean;
    public ParentInstance? : any;
}

