//$D90465F9
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component, OnInit } from '@angular/core';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTReportDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTReportDef';

@Component({
    selector: 'state-panel-test-component',
    template: `
    <h2>Nebula StatePanel</h2>

<button (click)='CheckAndEnableEmergencySurgeryBotton()'>Test Drop State Panel</button>
<button (click)='onClick()'>Change Bootstrap Class</button>

<hr />

    <NeStatePanelComponent [ObjectDefID]='ObjectDefID'
     [StatesPanelClass]="StatesPanelClass"
     [CurrentStateDefID]="CurrentStateDefID"
     [FixedCommandsPanelClass]="FixedCommandsPanelClass"
     (onSetState)='onSetState($event)' (onSaveChanges)="onSaveChanges($event)"
     (onStateButtonsRendered)= "stateButtonsRendered($event)"
     [DropStateList]="DropStateList"
     [StateReports]="_stateReports"
     [AddStateList]="AddStateList"
     >
</NeStatePanelComponent>
    `
})
export class StatePanelTestComponent implements OnInit {
    public ObjectDefID: Guid;
    public CurrentStateDefID: Guid;
    public StatesPanelClass: string;
    public FixedCommandsPanelClass: string;
    public IgnoreSurgeryApproval: boolean = true;
    private _Surgery: Surgery;
    private _dropStateList: Array<Guid> = new Array<Guid>();
    public DropStateList: Array<Guid> = new Array<Guid>();
    private _addStateList: Array<Guid> = new Array<Guid>();
    public AddStateList: Array<Guid> = new Array<Guid>();
    public _stateReports: Array<TTReportDef>;

    constructor() {
        this.ObjectDefID = new Guid('8dc586f0-14a5-42a3-a7c6-51e1be031ee0');
        this.StatesPanelClass = 'col-lg-9';
        this.FixedCommandsPanelClass = 'col-lg-3';
    }

    public ngOnInit() {
        let that = this;
        let objectID = new Guid('c970530b-81a4-46f7-8e97-f9168c42abc0');
        let stateReports = new Array<TTReportDef>();
        const r1 = new TTReportDef();
        r1.ID = Guid.newGuid();
        r1.Caption = i18n("M12595", "Deneme Rapor");
        stateReports.push(r1);
        const r2 = new TTReportDef();
        r2.ID = Guid.newGuid();
        r2.Caption = i18n("M12787", "Diğer bir rapor");
        stateReports.push(r2);
        this._stateReports = stateReports;
        ServiceLocator.getObject<Surgery>(objectID, Surgery.ObjectDefID).then(s => {
            that._Surgery = s;
            that.CurrentStateDefID = s.CurrentStateDefID;
        });
    }

    public onSetState(e): void {
        console.log(e);
    }

    public onSaveChanges(e): void {
        console.log(e);
    }

    public onClick() {
        this.StatesPanelClass = 'col-lg-9';
        this.FixedCommandsPanelClass = 'col-lg-3';
    }

    public stateButtonsRendered(stateList: Array<TTObjectStateTransitionDef>) {
        console.log(stateList);
        if (stateList != null && stateList.length > 0) {
            let state = stateList[0];
            // state.DisplayText = 'Değişiklik denemesi';
            console.log(state);
        }
    }

    public AddStateButton(stateDefID: Guid): void {
        let checkItem = this._addStateList.find(s => s.id.valueOf() === stateDefID.valueOf());
        if (checkItem == null) {
            this._addStateList.push(stateDefID);
        }

        let tempAddStateList = new Array<Guid>();
        let addStateList = tempAddStateList.concat(this._addStateList);
        this.AddStateList = addStateList;
    }

    public DropStateButton(stateDefID: Guid): void {
        let checkItem = this._dropStateList.find(s => s.id.valueOf() === stateDefID.valueOf());
        if (checkItem == null) {
            this._dropStateList.push(stateDefID);
        }

        let tempDropStateList = new Array<Guid>();
        let dropStateList = tempDropStateList.concat(this._dropStateList);
        this.DropStateList = dropStateList;
    }

    public CheckAndEnableEmergencySurgeryBotton() {

        console.log('Test Drop state button');


    }
}
