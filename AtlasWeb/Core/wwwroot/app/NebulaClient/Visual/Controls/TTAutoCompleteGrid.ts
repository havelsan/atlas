import { TTControl } from "./TTControl";

export class TTAutoCompleteGrid extends TTControl {
    MinSearchLength?: Number;
    SearchTimeout?: Number;
    PageSize?: Number;
    StyleExpression?: String;
    AutoCompleteDisplayExpression: String;
    AutoCompleteGridColumns?: Array<any>;
    SearchMode: SearchMode;
    AutoCompleteMode: AutoCompleteMode;
    AutoCompleteDialogHeight?: any;
    AutoCompleteDialogWidth?: any;
    SearchText?: String;
    ShowClearButton?: Boolean;
    Width?: String;
    Height?: String;
    PlaceHolder?: String;
    EnablePaging?: Boolean;
    IdExpression?: String;
    SelectSingleResultAutomatically?: Boolean;
    PopupDialogFieldConfig?: Array<ListBoxSearchCriteria>;
    PopupDialogGridColumns?: Array<any>;
    PopupDialogWidth?: any;
    PopupDialogHeight?: any;
    PopupDialogTitle?: String;
}

export class LoadDataSourceEventArgs {
    AsyncLoader: Promise<PagedResult>;
    PopupAsyncLoader: Promise<PagedResult>;
    RequireCount: Boolean = false;
    Filter: String;
    Take: number;
    Skip: number;
    IsPopupDataSource: Boolean = false;
}

export enum SearchMode {
    OnEnterPressed,
    OnKeyPressed
}

export enum AutoCompleteMode {
    List,
    Grid,
    Popup
}

export class PagedResult{
    Data: Array<any>;
    RecordCount: Number;
}

export class ListBoxSearchCriteria {
    Label: String;
    Column: String;
    Value?: String;
    Width?: String;
}