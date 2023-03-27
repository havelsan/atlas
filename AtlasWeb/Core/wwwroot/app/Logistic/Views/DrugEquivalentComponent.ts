import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import DataSource from 'devextreme/data/data_source';
import { DrugInfo } from 'ObjectClassService/DrugOrderIntroductionService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';

@Component({
    selector: 'drugequivalent-component',
    template: `
<p class="navbar-text" style="color:red">Seçmiş olduğunuz ilacın eczane mevcudu sizin direktifi karşılayamamaktadır. Bu ilacın eczanede mevcudu olan eşdeğelerinden seçmek istermisiniz?</p>
<div class="col-xs-12">
    <dx-list [dataSource]="drugSource" height="200px" (onItemClick)="selectedChange($event)">
        <div *dxTemplate="let data of 'item'">
            <div style="float:left; width:90%;">{{data.name}}</div>
        </div>
    </dx-list>
    <br />
    <div style="float: left">
        <dx-button type="btn btn-default" text="Değiştir" style="width:80px" (onClick)="okClick()"></dx-button>
    </div>
    <div style="float: right">
        <dx-button type="btn btn-default" text="Devam" style="width:80px" (onClick)="cancelClick()"></dx-button>
    </div>
</div>
 `
})
export class DrugEquivalentComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    drugSource: DataSource;
    selectedEquivalentDrug: DrugInfo;


    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public async setInputParam(value: Object) {
        this.drugSource = <any>value;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    selectedChange(e) {
        if (e.itemData !== null) {
            this.selectedEquivalentDrug = e.itemData;
        }
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        if (this.selectedEquivalentDrug != null) {
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedEquivalentDrug);
        } else {
            TTVisual.InfoBox.Alert("Eşdeğer ilaç seçmediniz.");
        }
    }
}