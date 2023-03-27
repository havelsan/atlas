export class ComboListItem {

    private _dataValue: any;
    public get DataValue(): any {
        return this._dataValue;
    }

    private _displayText: string;
    public get DisplayText(): string {
        return this._displayText;
    }

    public constructor(dataValue: any, displayText: string) {
        this._displayText = displayText;
        this._dataValue = dataValue;
    }
}