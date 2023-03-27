//$00A89F9C
import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { MultiSelectForm } from "NebulaClient/Visual/MultiSelectForm";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { Router , NavigationStart} from '@angular/router';

@Component({
    selector: "hvl-multiselect-component",
    template: `
        <div class="col-sm-12">
            <dx-text-box mode="search" placeholder="Arama" [(value)]="searchTxt" (onValueChanged)="txtChange()" valueChangeEvent="keyup"></dx-text-box>
            <dx-data-grid [columns]="Columns" height="295" [dataSource]="_multiSelectForm?._storageItems" [selection]="selection" (onSelectionChanged)="select($event)" (onRowClick)="rowClicked($event)"></dx-data-grid>
        </div>
        <div class="col-sm-8 m--margin-bottom-10 m--margin-top-5" style="float: left">
            <dx-button type="danger" text="İptal" (onClick)="cancelClick()"></dx-button>
        </div>
        <div class="col-sm-3 m--margin-bottom-10 m--margin-top-5" style="float: right">
            <dx-button style="float: right" type="default" text="Tamam" (onClick)="selectClick()"></dx-button>
        </div>
    `
})
export class MultiSelectComponent implements IModal {
    public searchTxt: string;
    public SearchResults: Array<any>;
    public selectedData: any = null;
    public _multiSelectForm: MultiSelectForm;
    private _modalInfo: ModalInfo;

    public Columns = [
        {
            caption: i18n("M10514", "Adı"),
            dataField: "MSItem"
        }
    ];

    public selection =
        {
            mode: "single"
        };

    constructor(private modalStateService: ModalStateService,private router: Router) {
        this.searchTxt = "";
        this.SearchResults = new Array<any>();
        this.router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
            }
            
        });
    }

    public setInputParam(value: Object) {
        this._multiSelectForm = value as MultiSelectForm;
        if (this._multiSelectForm._isMultiSelect)
            this.selection =
                {
                    mode: "multiple"
                };
        else
            this.selection =
                {
                    mode: "single"
                };
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public selectClick(): void {
        //if (this.selectedData === null)
           // InfoBox.Alert("Lütfen Seçim Yapınız.");
        //else
        if (this.selectedData != null)
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedData);
    }

    public txtChange(): void {
        if (this.SearchResults.length == 0)
            this.SearchResults = this._multiSelectForm._storageItems;
        if (this.searchTxt != "") {
            let excludeList: Array<any> = Array<any>();

            let searchText = this.searchTxt.toUpperCase().replace("İ", "I");
            for (let mc of this.SearchResults) {
                if (mc.MSItem.toUpperCase().replace("İ", "I").includes(searchText)) {
                    excludeList.push(mc);
                }
            }
            this._multiSelectForm._storageItems = excludeList;
        }
        else {
            this._multiSelectForm._storageItems = this.SearchResults;
        }
    }

    rowClicked(event)
    {
        let component = event.component,
        prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            if (this.selectedData != null)
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedData);
        }
        else {
            //Single click code
        }
    }

    public select(data: any) {

        this.selectedData = data.selectedRowKeys;
    }

}