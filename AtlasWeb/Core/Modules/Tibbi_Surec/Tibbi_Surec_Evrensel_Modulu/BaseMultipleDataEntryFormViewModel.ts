//$BCC857AF
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseMultipleDataEntry } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "NebulaClient/Mscorlib/Guid";

export class BaseMultipleDataEntryFormViewModel extends BaseViewModel {
    @Type(() => BaseMultipleDataEntry)
    public _BaseMultipleDataEntry: BaseMultipleDataEntry = new BaseMultipleDataEntry();
}
export class MultipleDataComponent_SummaryInfo {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Date)
    public EntryDate: Date;
    public EntryUserName: string;
    public Summary: string;
    public RowColor: string;
}
