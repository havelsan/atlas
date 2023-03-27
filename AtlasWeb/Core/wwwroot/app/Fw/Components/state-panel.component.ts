import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component, Input, Output, EventEmitter, SimpleChange } from '@angular/core';
import { TTObjectStateDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DefinitionService } from 'Fw/Services/DefinitionService';
import { TTReportDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTReportDef';
import { MessageService } from 'Fw/Services/MessageService';
import { AtlasReportService } from '../../Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";

import { AsyncSubject } from "rxjs";
import { KSchedule } from 'app/NebulaClient/Model/AtlasClientModel';

const OutgoingTransitionsPropertyName = 'OutgoingTransitions';
const CurrentStateDefIDPropertyName = 'CurrentStateDefID';

@Component({
    selector: 'NeStatePanelComponent',
    template: `
<dx-load-panel
    #statepanelloadPanel
    shadingColor="rgba(0,0,0,0.4)"
    [position]="{ my: 'center', at: 'center', of: window }"
    [(visible)]="loadingVisible"
    [showIndicator]="true"
    message="Kaydediliyor..."
    [showPane]="true"
    [shading]="true"
    [closeOnOutsideClick]="false"
    (onShown)="onShown()">
</dx-load-panel>
<div class="row" style="margin-bottom:2px">
    <div [ngClass]="StatesPanelClass" *ngIf="!StateCommandsVisible"></div>
    <div [ngClass]="StatesPanelClass" *ngIf="StateCommandsVisible">
        <ul style="list-style-type: none; margin: 0; padding: 0; overflow: hidden;">
            <li style="float: left" *ngFor="let transitionDef of filteredOutgoingTransitions">
            <dx-button type="success" style="margin: 0px 5px 0px 0px" [text]="transitionDef?.DisplayText" (onClick)="onStateButtonClicked(transitionDef)"></dx-button></li>
        </ul>
    </div>
    <div [ngClass]="FixedCommandsPanelClass" *ngIf="FixedCommandsVisible">
        <ng-content select=".CustomButton"></ng-content>
        <div style="float: right" *ngIf="CustomButtonVisible">
            <dx-button icon="{{CustomButtonIcon}}" type="{{CustomButtonType}}" style="margin: 0px 5px 0px 0px" text="{{CustomButtonCaption}}" (onClick)="onCustomButtonClickInternal()"></dx-button>
        </div>
        <div style="float: right" *ngIf="SaveAndCloseCommandVisible">
            <dx-button icon="save" type="default" style="margin: 0px 5px 0px 0px" text="{{SaveAndCloseButtonCaption}}" (onClick)="onSaveAndCloseInternal()"></dx-button>
        </div>
        <div style="float: right" *ngIf="SaveCommandVisible">
            <dx-button icon="save" type="default" style="margin: 0px 5px 0px 0px" text="{{SaveButtonCaption}}" (onClick)="onSaveInternal()"></dx-button>
        </div>
        <div style="float: right" *ngIf="CancelCommandVisible">
            <dx-button icon="fa fa-undo" type="danger" style="margin: 0px 5px 0px 0px" text="{{CancelButtonCaption}}" (onClick)="onCancelInternal()"></dx-button>
        </div>
        <div style="float: right" *ngIf="PrintCommandVisible">
            <dx-button id="btnReport" icon="fa fa-undo" type="default" icon="spindown" style="margin: 0px 5px 0px 0px" text="{{PrintButtonCaption}}" (onClick)="showReportMenu()"></dx-button>
            <dx-context-menu [(visible)]="_printMenuVisible" [displayExpr]="'Caption'" [dataSource]="StateReports"  target="#btnReport" [position]="{at: 'left bottom'}" (onItemClick)="onReportMenuClick($event)">
            </dx-context-menu>
        </div>
        <div style="float: right" *ngIf="PrintReportCommandVisible">
            <dx-button icon="fa fa-undo" type="default" icon="spindown" style="margin: 0px 5px 0px 0px" text="Rapor Yazdır" (onClick)="onReportButtonClick()"></dx-button>
        </div>
    </div>
</div> `,
    providers: [MessageService, DefinitionService]
})
export class NeStatePanelComponent {
    loadingVisible = false;
    private _filteredOutgoingTransitions: Array<TTObjectStateTransitionDef>;
    private _outgoingTransitions: Array<TTObjectStateTransitionDef>;
    private _stateReports: Array<TTReportDef>;
    public objectStates: Array<TTObjectStateDef>;

    private _fixedCommandsVisible: boolean = true;
    private _objectID: Guid;
    private _objectDefID: string;
    private _currentStateDefID: Guid;
    private _saveAndCloseCommandVisible: boolean = false;
    private _saveCommandVisible: boolean = true;
    private _cancelCommandVisible: boolean = true;
    private _printCommandVisible: boolean = true;
    private _customButtonVisible: boolean = false;

    private _printReportCommandVisible: boolean = false;

    private _stateCommandsVisible: boolean = true;
    private _statesPanelClass: string = 'col-lg-9';
    private _fixedCommandsPanelClass: string = 'col-lg-3';
    private _dropStateList: Array<Guid>;
    private _addStateList: Array<Guid>;
    private _refreshStateButtons: Boolean;
    private _printMenuVisible: boolean = false;
    private _customButtontype: string = 'btn btn-default';

    public set filteredOutgoingTransitions(value: Array<TTObjectStateTransitionDef>) {
        let filteredTransitions = this.getFilteredTransitionList(value);
        this._filteredOutgoingTransitions = filteredTransitions;
        this.onStateButtonsRendered.emit(this.filteredOutgoingTransitions);
    }
    public get filteredOutgoingTransitions(): Array<TTObjectStateTransitionDef> {
        return this._filteredOutgoingTransitions;
    }

    @Input() set StateReports(value: Array<TTReportDef>) {
        this._stateReports = value;
    }

    get StateReports(): Array<TTReportDef> {
        return this._stateReports;
    }

    @Input() set OutgoingTransitions(value: Array<TTObjectStateTransitionDef>) {
        this._outgoingTransitions = value;
    }
    get OutgoingTransitions(): Array<TTObjectStateTransitionDef> {
        return this._outgoingTransitions;
    }

    @Input() SaveButtonCaption: string = 'Kaydet';
    @Input() SaveAndCloseButtonCaption: string = 'Kaydet/Kapat';
    @Input() CancelButtonCaption: string = 'Vazgeç';
    @Input() PrintButtonCaption: string = 'Raporlar';
    @Input() CloseWithStateTransition: boolean = false;
    @Input() CustomButtonCaption: string = '';
    @Input() CustomButtonIcon: string = '';
    @Input() set CustomButtonType(value: string) {
        if (value != null) {
            this._customButtontype = value;
        }
    }
    get CustomButtonType(): string {
        return this._customButtontype;
    }

    @Input() set DropStateList(value: Array<Guid>) {
        this._dropStateList = value;
        let filteredTransitions = this.getFilteredTransitionList(this._filteredOutgoingTransitions);
        this._filteredOutgoingTransitions = filteredTransitions;
    }
    get DropStateList(): Array<Guid> {
        return this._dropStateList;
    }

    @Input() set AddStateList(value: Array<Guid>) {
        this._addStateList = value;
        let filteredTransitions = this.getFilteredTransitionList(this._filteredOutgoingTransitions);
        this._filteredOutgoingTransitions = filteredTransitions;
    }
    get AddStateList(): Array<Guid> {
        return this._addStateList;
    }

    @Input() set StatesPanelClass(value: string) {
        this._statesPanelClass = value;
    }
    get StatesPanelClass(): string {
        return this._statesPanelClass;
    }
    @Input() set FixedCommandsPanelClass(value: string) {
        this._fixedCommandsPanelClass = value;
    }
    get FixedCommandsPanelClass(): string {
        return this._fixedCommandsPanelClass;
    }
    @Input() set FixedCommandsVisible(value: boolean) {
        this._fixedCommandsVisible = value;
    }
    get FixedCommandsVisible(): boolean {
        if (this._objectDefID == null) {
            return false;
        }
        return this._fixedCommandsVisible;
    }

    @Input() set StateCommandsVisible(value: boolean) {
        this._stateCommandsVisible = value;
    }
    get StateCommandsVisible(): boolean {
        return this._stateCommandsVisible;
    }

    @Input() set SaveCommandVisible(value: boolean) {
        this._saveCommandVisible = value;
    }
    get SaveCommandVisible(): boolean {
        return this._saveCommandVisible;
    }

    @Input() set CustomButtonVisible(value: boolean) {
        this._customButtonVisible = value;
    }
    get CustomButtonVisible(): boolean {
        return this._customButtonVisible;
    }

    @Input() set SaveAndCloseCommandVisible(value: boolean) {
        this._saveAndCloseCommandVisible = value;
    }
    get SaveAndCloseCommandVisible(): boolean {
        return this._saveAndCloseCommandVisible;
    }

    @Input() set CancelCommandVisible(value: boolean) {
        this._cancelCommandVisible = value;
    }
    get CancelCommandVisible(): boolean {
        return this._cancelCommandVisible;
    }

    @Input() set PrintCommandVisible(value: boolean) {
        this._printCommandVisible = value;
    }
    get PrintCommandVisible(): boolean {
        if (this._stateReports == null) {
            return false;
        }
        if (this._stateReports.length < 1) {
            return false;
        }
        return this._printCommandVisible;
    }

    @Input() set PrintReportCommandVisible(value: boolean) {
        this._printReportCommandVisible = value;
    }
    get PrintReportCommandVisible(): boolean {

        return this._printReportCommandVisible;
    }

    @Input() set ObjectDefID(value: string) {
        this._objectDefID = value;
        this.getStateDefinitions(value);
    }
    get ObjectDefID(): string {
        return this._objectDefID;
    }

    @Input() set ObjectID(value: Guid | string) {
        let objectID: Guid = value as Guid;
        if ((typeof value) === 'string') {
            objectID = new Guid(value as string);
        }
        this._objectID = objectID;
    }
    get ObjectID(): Guid | string {
        return this._objectID;
    }

    @Input() set RefreshStateButtons(value: Boolean) {
        this._refreshStateButtons = value;
        if (value) {
            if (this.ObjectDefID) {
                this.getStateDefinitions(this.ObjectDefID);
            }
        }
    }
    get RefreshStateButtons(): Boolean {
        return this._refreshStateButtons;
    }

    @Input() set CurrentStateDefID(value: string | Guid) {
        let curStateDefID: Guid = value as Guid;
        if ((typeof value) === 'string') {
            curStateDefID = new Guid(value as string);
        }
        this._currentStateDefID = curStateDefID;
        if (value != null) {
            this.setOutgoingTransitionDefs(curStateDefID);
        }
    }
    get CurrentStateDefID(): string | Guid {
        return this._currentStateDefID;
    }

    @Output() onSetState = new EventEmitter<FormSaveInfo>();
    @Output() onSaveChanges = new EventEmitter<FormSaveInfo>();
    @Output() onCancel = new EventEmitter<any>();
    @Output() onStateButtonsRendered = new EventEmitter<Array<TTObjectStateTransitionDef>>();
    @Output() onPrintReport = new EventEmitter<string>();
    @Output() onCustomButtonClick = new EventEmitter<any>();

    constructor(private definitionService: DefinitionService, private messageService: MessageService, private reportService: AtlasReportService) {
        this.objectStates = new Array<TTObjectStateDef>();
        this.filteredOutgoingTransitions = new Array<TTObjectStateTransitionDef>();
    }

    public getFilteredTransitionList(value: Array<TTObjectStateTransitionDef>) {
        let filteredTransitions = value;
        if (this._dropStateList != null && value != null) {
            filteredTransitions = value.filter(item => this._dropStateList.find(ds => ds.valueOf() === item.ToStateDefID.valueOf()) == null);
        }
        if (this._addStateList != null && value != null) {
            this._addStateList.forEach(addState => {
                let currentState = this.objectStates.find(s => s.StateDefID.valueOf() === this.CurrentStateDefID.valueOf());
                if (currentState != null) {
                    currentState.OutgoingTransitions.forEach(transDef => {
                        if (transDef.ToStateDefID.valueOf() === addState.valueOf()) {
                            let checkItem = filteredTransitions.find(t => t.ToStateDefID.valueOf() === transDef.ToStateDefID.valueOf());
                            if (checkItem == null) {
                                filteredTransitions.push(transDef);
                            }
                        }
                    });
                }
            });
        }
        return filteredTransitions;
    }

    private getStateDefinitions(objectDefID: string): Promise<void> {
        let that = this;
        this.objectStates = new Array<TTObjectStateDef>();
        this.filteredOutgoingTransitions = new Array<TTObjectStateTransitionDef>();
        if (objectDefID == null) {
            return;
        }
        if (this.OutgoingTransitions != null) {
            // Sunucudan geçerli duruma göre geçiş yapılabilecek işlemler gönderildi
            this.filteredOutgoingTransitions = this.OutgoingTransitions;
            return;
        }
        this.definitionService.getObjectStateDefList(objectDefID).then(res => {

            that.objectStates = res;

            if (that.CurrentStateDefID != null) {
                let currentState = that.objectStates.find(s => s.StateDefID.valueOf() === that.CurrentStateDefID.valueOf());
                if (currentState != null) {
                    that.setOutgoingTransitionDefs(currentState);
                }

            } else {
                let entryState = that.objectStates.find(s => s.IsEntry === true);
                if (entryState != null) {
                    that.setOutgoingTransitionDefs(entryState);
                }
            }
        }).catch(err => {
            console.log(err);
        });
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {

        const outgoingTransitionsChanged = changes.hasOwnProperty(OutgoingTransitionsPropertyName);
        const currentStateDefIDChanged = changes.hasOwnProperty(CurrentStateDefIDPropertyName);

        if (outgoingTransitionsChanged == true && currentStateDefIDChanged == false) {
            const outgoingTransitions = changes[OutgoingTransitionsPropertyName].currentValue as Array<TTObjectStateTransitionDef>;
            this.filteredOutgoingTransitions = outgoingTransitions;
        }
    }

    onShown() {
        setTimeout(() => {
            this.loadingVisible = false;
        }, 1000);
    }

    private setOutgoingTransitionDefs(value: Guid | TTObjectStateDef): void {

        if (value != null && ((value instanceof Object) && (value instanceof Guid) === false)) {
            let targetStateDef: TTObjectStateDef = value as TTObjectStateDef;
            this.filteredOutgoingTransitions = targetStateDef.SortedOutgoingTransitions;
        } else if (value != null && value instanceof Guid) {
            let targetStateDefID: Guid = value as Guid;
            if (targetStateDefID != null) {
                let targetStateDef = this.objectStates.find(s => s.StateDefID.valueOf() === targetStateDefID.valueOf());
                if (targetStateDef != null) {
                    this.filteredOutgoingTransitions = targetStateDef.SortedOutgoingTransitions;
                }
            }
        }
    }

    public onStateButtonClicked(transDef: TTObjectStateTransitionDef): void {
        const that = this;
        if (transDef != null) {
            this.loadingVisible = true;
            transDef.SaveAndClose = this.CloseWithStateTransition;
            const param = new FormSaveInfo(this._objectDefID, this.CloseWithStateTransition);
            param.transDef = transDef;
            param.saveCompleted = new AsyncSubject<Object>();
            param.saveCompleted.subscribe(r => {
                that.loadingVisible = false;
            }, err => {
                that.loadingVisible = false;
            });
            this.onSetState.emit(param);
        }
    }

    onSaveInternal(): void {
        this.loadingVisible = true;
        const param = new FormSaveInfo(this._objectDefID, false);
        this.onSaveChanges.emit(param);
    }

    onSaveAndCloseInternal(): void {
        const that = this;
        this.loadingVisible = true;
        const param = new FormSaveInfo(this._objectDefID, true);
        param.saveCompleted = new AsyncSubject<Object>();
        param.saveCompleted.subscribe(r => {
            that.loadingVisible = false;
        }, err => {
            that.loadingVisible = false;
        });
        this.onSaveChanges.emit(param);
    }

    onCancelInternal(): void {
        this.onCancel.emit(null);
    }

    showReportMenu(): void {
        this._printMenuVisible = true;
    }

    onReportButtonClick() {
        this.onPrintReport.emit();
    }
    onCustomButtonClickInternal() {
        this.onCustomButtonClick.emit();
        if(this._outgoingTransitions){
            let td: TTObjectStateTransitionDef = this._outgoingTransitions.find(x => x.ToStateDefID.valueOf() === KSchedule.KScheduleStates.Cancelled.id)
            this.onStateButtonClicked(td);
        }
    }

    onReportMenuClick(e: any) {
        const reportDef = e.itemData as TTReportDef;
        if (e != null && reportDef != null && this.ObjectID != null) {
            const objectIdParam = new GuidParam(this.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport(reportDef.Name, reportParameters);
        }
    }
}
