import { Type } from 'NebulaClient/ClassTransformer';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTReportDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTReportDef';

export class BaseViewModel {
    public ReadOnly: boolean;
    public ReadOnlyFields: Array<string>;
    @Type(() => TTObjectStateTransitionDef)
    public OutgoingTransitions: Array<TTObjectStateTransitionDef>;
    @Type(() => TTReportDef)
    public CurrentStateReports: Array<TTReportDef>;
    public ListDefDisplayExpressions: any;
    public UpdatedObjects: Array<Object>;
}
