import { Guid } from '../../Mscorlib/Guid';
import { TTObjectDef } from  './TTObjectDef';
import { TTObjectStateDef } from  './TTObjectStateDef';
import { TTObjectStateTransitionReportDef } from './TTObjectStateTransitionReportDef';
import { TTObjectTransitionRequiredPropertyDef } from './TTObjectTransitionRequiredPropertyDef';
import { TTObjectTransitionRequiredRelationDef } from './TTObjectTransitionRequiredRelationDef';
import { Type } from 'NebulaClient/ClassTransformer';
import { StateStatusEnum } from 'NebulaClient/Utils/Enums/StateStatusEnum';

export class TTObjectStateTransitionDef {
    @Type(() => Guid)
    public StateTransitionDefID: Guid;
    public Name: string;
    public DisplayText: string;
    public Description: string;
    public ObjectDef: TTObjectDef;
    @Type(() => Guid)
    public ObjectDefID: Guid;
    public FromStateDef: TTObjectStateDef;
    @Type(() => Guid)
    public FromStateDefID: Guid;
    public ToStateStatus: StateStatusEnum;
    public ToStateDef: TTObjectStateDef;
    @Type(() => Guid)
    public ToStateFormDefID: Guid;
    @Type(() => Guid)
    public ToStateDefID: Guid;
    public ShouldCallBasePreScript: boolean;
    public ShouldCallBasePostScript: boolean;
    public ShouldCallBaseUndoScript: boolean;
    public ChildShouldCallPreScript: boolean;
    public ChildShouldCallPostScript: boolean;
    public ChildShouldCallUndoScript: boolean;
    public PreScript: string;
    public PostScript: string;
    public UndoScript: string;
    public BaseTransDef: TTObjectStateTransitionDef;
    public PreScriptMethodName: string;
    public PostScriptMethodName: string;
    public UndoScriptMethodName: string;
    public OrderNo: number;
    public IsSave: boolean;
    public SaveAndClose: boolean;
    //public Attributes: TTDefCollection<TTAttribute>;
    //public AllAttributes: TTDefCollection<TTAttribute>;
    public ReportDefs: Array<TTObjectStateTransitionReportDef>;
    public RequiredPropertyDefs: Array<TTObjectTransitionRequiredPropertyDef>;
    public RequiredRelationDefs: Array<TTObjectTransitionRequiredRelationDef>;
    public IsPropertyRequired(propertyName: string): boolean {
        return null;
    }
    public IsRelationRequired(relationName: string): boolean {
        return null;
    }
    public ToString(): string {
        return this.StateTransitionDefID.toString();
    }
}
