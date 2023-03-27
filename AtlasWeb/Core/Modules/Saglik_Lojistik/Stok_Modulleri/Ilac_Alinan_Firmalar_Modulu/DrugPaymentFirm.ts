import { Component, OnInit, ViewChild, Input, Renderer2 } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import {  Material } from "app/NebulaClient/Model/AtlasClientModel";
import { IModalService } from "app/Fw/Services/IModalService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DrugPaymentFirmList, DrugPaymentInputDTO } from './DrugPaymentFirmViewModel';

@Component({
    selector: "DrugPaymentFirm",
    templateUrl: './DrugPaymentFirmReport.html',
    providers: [SystemApiService, MessageService]
})

export class DrugPaymentFirm {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    private _StoreObjectId: string;
    public StartDate: Date = new Date();
    public EndDate: Date = new Date();
    public SelectedFilterMaterials: Array<Material> = new Array<Material>();
    public showLoadPanel: boolean;
    public Supplier: TTVisual.ITTObjectListBox;
    public SupplierObjectID: Guid;
    public TotalNumberOfRows: number;
    public drugPaymentFirmList: Array<DrugPaymentFirmList> = new Array<DrugPaymentFirmList>();
    

    @Input() set SelectedMainStore(value: any) {
        if (value != null && value != undefined)
            this._StoreObjectId = value.ObjectID;
    }
    get SelectedMainStore(): any {
        return this._StoreObjectId;
    }

    constructor(protected httpService: NeHttpService, private reportService: AtlasReportService, protected messageService: MessageService, public systemApiService: SystemApiService, private modalService: IModalService) {
        this.initViewModel();
    }

    public initViewModel(): void {
        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = false;
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 9;
    }

    public DrugPaymentFirmGridColumns = [
        {
            caption: "İlaç / Malzeme Adı",
            dataField: 'Materialname',
            dataType: 'string',
            allowSorting: true
        },
        {
            caption: "Barkod",
            dataField: 'Barcode',
            dataType: 'string',
            allowSorting: true,
        },
        {
            caption: "Miktar",
            dataField: 'Amount',
            dataType: 'string',
            allowSorting: true,
        },
        {
            caption: "Alış Tarihi",
            dataField: 'Transactiondate',
            dataType: 'date',
            allowSorting: true,
        },
        {
            caption: "İşlem Numarası",
            dataField: 'Stockactionid',
            dataType: 'string',
            allowSorting: true,
        },
        {
            caption: "Firma",
            dataField: 'Suppliername',
            dataType: 'string',
            allowSorting: true,
        },
    ];

    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.showMaterialMultiSelectForm = true;
    }

    public onSupplierChanged(event): void {
        if (event != null) {
            if (this.SupplierObjectID != event.ObjectID) {
                this.SupplierObjectID = event.ObjectID;
            }
        } else {
            this.SupplierObjectID = null;
        }
    }

    async MaterialsSelected(event) {
        this.showMaterialMultiSelectForm = false;
        let selectedMaterialItems = event;

        selectedMaterialItems.forEach(element => {
            let selectedMaterials: Material = new Material();
            selectedMaterials = element;
            this.SelectedFilterMaterials.push(selectedMaterials);
        });
    }
    async MaterialsCleared() {
        this.SelectedFilterMaterials = new Array<Material>();
    }

    async ngOnInit() {

    }

    public setDefaultDates() {

    }


    async GetWithFilter() {
        try {
            this.showLoadPanel = true;
            let input: DrugPaymentInputDTO = new DrugPaymentInputDTO();
            input.StartDate = this.StartDate;
            input.EndDate = this.EndDate;
            input.Materials = new Array<Material>();
            input.Materials = this.SelectedFilterMaterials;
            input.SupplierObjectID = this.SupplierObjectID;
            let apiUrl: string = 'api/DrugPaymetFirmService/GetDrugPaymentFirm';
            this.httpService.post<Array<DrugPaymentFirmList>>(apiUrl, input).then(
                result => {
                   this.drugPaymentFirmList = result;
                   this.TotalNumberOfRows = this.drugPaymentFirmList.length;
                   this.showLoadPanel = false;
                    
                }).catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    this.showLoadPanel = false;
                });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
            this.showLoadPanel = false;
        }
    }
}