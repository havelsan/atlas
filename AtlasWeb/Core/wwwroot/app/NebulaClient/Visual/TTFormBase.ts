import { Guid } from '../Mscorlib/Guid';
import { ITTComponentBase } from './ControlInterfaces/ITTComponentBase';
import { ITTControlBase } from './ControlInterfaces/ITTControlBase';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { TTControl } from 'NebulaClient/Visual/Controls/TTControl';

export class TTFormBase {

    public ObjectID: Guid;
    public FormCaption: string;
    protected Controls: Array<ITTControlBase>;

    private _formDefNameInternal: string;

    public get _formDefName(): string {
        return this._formDefNameInternal;
    }

    protected _readOnly: boolean;
    public get ReadOnly(): boolean {
        return this._readOnly;
    }
    public set ReadOnly(value: boolean) {
        this._readOnly = value;
        if (this.Controls != null) {
            for (let control of this.Controls) {
                if (control != null) {
                    control.ReadOnly = value;
                }
            }
        }
    }
    protected get ParentForm(): Object {
        return null;
    }
    constructor(objectDefName?: string, formDefName?: string) {
        this._formDefNameInternal = formDefName;
    }
    protected InitializeControls(): void {
    }
    protected BindControlEvents(): void {
    }
    protected UnBindControlEvents(): void {
    }
    protected AddControl(fieldDefID: Guid): ITTComponentBase {
        return null;
    }
    protected BarcodeRead(value: string): void {
    }
    protected FindForm(): Object {
        return null;
    }
    protected Hide(): void {
    }
    protected Show(): void {
    }
    protected Close(): void {
    }

    protected signalLoadCompleted() {
         if (this.Controls != null) {
            for (let control of this.Controls) {
                let ttcontrol = control as TTControl;
                if (ttcontrol && control['onLoadCompleted']) {
                    ttcontrol.onLoadCompleted();
                }
            }
        }
    }

    private _dialogResult: DialogResult;
    public get DialogResult(): DialogResult {
        return this._dialogResult;
    }

    public set DialogResult(value: DialogResult) {
        this._dialogResult = value;
    }
}