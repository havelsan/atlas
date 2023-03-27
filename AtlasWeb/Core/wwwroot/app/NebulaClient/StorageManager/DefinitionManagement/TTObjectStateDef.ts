import { Guid } from '../../Mscorlib/Guid';
import { TTObjectDef } from './TTObjectDef';
import { StateStatusEnum } from '../../Utils/Enums/StateStatusEnum';
import { TTFormDef } from './TTFormDef';
import { TTObjectStateTransitionDef } from './TTObjectStateTransitionDef';
import { RequiredWhenEnum } from 'NebulaClient/Utils/Enums/RequiredWhenEnum';
import { TTObjectStateReportDef } from './TTObjectStateReportDef';
import { Type } from 'NebulaClient/ClassTransformer';

export class TTObjectStateDef {
    public ObjectDef: TTObjectDef;
    @Type(() => Guid)
    public ObjectDefID: Guid;
    @Type(() => Guid)
    public StateDefID: Guid;
    public Name: string;
    public Description: string;
    public DisplayText: string;
    public BaseStateDef: TTObjectStateDef;
    @Type(() => Guid)
    public BaseStateDefID: Guid;
    public IsPropertiesProtected: boolean;
    public Status: StateStatusEnum;
    public IsEntry: boolean;
    public Disabled: boolean;
    public FormDef: TTFormDef;
    @Type(() => Guid)
    public FormDefID: Guid;
    @Type(() => TTObjectStateTransitionDef)
    public IncomingGlobalTransition: TTObjectStateTransitionDef;
    @Type(() => TTObjectStateTransitionDef)
    public IncomingTransitions: Array<TTObjectStateTransitionDef>;
    @Type(() => TTObjectStateTransitionDef)
    public OutgoingTransitions: Array<TTObjectStateTransitionDef>;
    @Type(() => TTObjectStateTransitionDef)
    public SortedOutgoingTransitions: Array<TTObjectStateTransitionDef>;
    public ReportDefs: Array<TTObjectStateReportDef>;
    public RequiredWhen(name: string): RequiredWhenEnum {
        return null;
    }
    public IsPreRequired(name: string): boolean {
        return null;
    }
    public IsPostRequired(name: string): boolean {
        return null;
    }
    public IsProtected(name: string): boolean {
        return null;
    }
    public ToString(): string {
        return null;
    }
    public FindOutoingTransitionDefFromStateDefID(stateDefID: Guid): TTObjectStateTransitionDef {
        return null;
    }
}
