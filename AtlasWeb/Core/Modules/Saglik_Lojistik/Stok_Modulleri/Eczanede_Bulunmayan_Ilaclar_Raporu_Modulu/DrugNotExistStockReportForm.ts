import { Component, OnInit, ViewChild, Input, Renderer2 } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import {
    DynamicComponentInfoDVO
} from 'app/Logistic/Models/LogisticMainViewModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from "app/NebulaClient/Visual/TTUnboundForm";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { Headers, RequestOptions } from '@angular/http';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { TransactionTypeEnum, ResUser, ResClinic, ActiveIngredientDefinition, DrugSpecificationEnum, DrugShapeTypeEnum } from "app/NebulaClient/Model/AtlasClientModel";
import { DxAccordionComponent } from "devextreme-angular";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { IModalService } from "app/Fw/Services/IModalService";
import { DrugNotExistStockReportFormViewModel, GetNotExistDrug_Output } from './DrugNotExistStockReportFormViewModel';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { MaterialModel } from 'Modules/Saglik_Lojistik/Tasinir_Islem_Fisi_Rapor_Modulleri/Cikis_Rapor_Modulu/MovableTransactionOutVoucherFormViewModel';

@Component({
    selector: "DrugNotExistStockReportForm",
    templateUrl: './DrugNotExistStockReportForm.html',
    providers: [SystemApiService, MessageService]
})

export class DrugNotExistStockReportForm extends TTUnboundForm implements OnInit {
    public DrugNotExistStockReportFormViewModel: DrugNotExistStockReportFormViewModel;
    public visibility: boolean = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    public notExistDrugList: Array<GetNotExistDrug_Output> = new Array<GetNotExistDrug_Output>();
    public TotalNumberOfRows: number;
    public DrugSpecificationEnumDef: Array<EnumItem> = new Array<EnumItem>();
    public DrugShapeTypeEnumDef: Array<EnumItem> = new Array<EnumItem>();
    public selectedSpecificationList: Array<number> = new Array<number>();
    public selectedShapeTypeList: Array<number> = new Array<number>();
    public SelectedActiveIngredients: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> = new Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>();

    public NotExistDrugGridColumns = [
        {
            'caption': "İlaç",
            dataField: 'DrugName',
            dataType: 'string',
            allowSorting: true,
        },
        {
            'caption': "Barkod",
            dataField: 'Barcode',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "Etken Madde",
            dataField: 'IngredientName',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "Miktar",
            dataField: 'Amount',
            dataType: 'number',
            allowSorting: true
        },

    ];

    @Input() set StoreObjectId(object: string) {
        if (object != null) {
            this.DrugNotExistStockReportFormViewModel.SelectedStore = new Guid(object);
        }
    }
    get StoreObjectId(): string {
        return this.DrugNotExistStockReportFormViewModel.SelectedStore.toString();
    }

    constructor(protected httpService: NeHttpService, private modalService: IModalService, protected messageService: MessageService, public systemApiService: SystemApiService, private renderer: Renderer2) {
        super('DrugNotExistStockReport', 'DrugNotExistStockReportForm');
        this.initViewModel();
    }

    public initViewModel(): void {
        this.DrugNotExistStockReportFormViewModel = new DrugNotExistStockReportFormViewModel();
    }

    async ngOnInit() {
        this.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;
        this.DrugShapeTypeEnumDef = DrugShapeTypeEnum.Items;
        this.FillDataSources();
    }

    ActiveIngredientList: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>;
    async FillDataSources() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugReturnReportService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.ActiveIngredientList = result.ActiveIngredientList;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    private showActiveIngredientsMaterialMultiSelectForm: boolean = false;
    OpenActiveIngredientsMaterialMultiSelectComponent() {
        this.showActiveIngredientsMaterialMultiSelectForm = true;

    }

    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.showMaterialMultiSelectForm = true;
    }

    public selectedMaterialsText: string = "";
    async MaterialsSelected(event) {
        let selectedMaterials = event;
        this.DrugNotExistStockReportFormViewModel.SelectedMaterialList = new Array<Guid>();
        for (let selectedItem of selectedMaterials) {
            this.DrugNotExistStockReportFormViewModel.SelectedMaterialList.push(selectedItem.ObjectID);
        }
        this.showMaterialMultiSelectForm = false;

        if (this.DrugNotExistStockReportFormViewModel.SelectedMaterialList.length != 0) {
            //this.visible = true;
        }
    }

    public selectedChangeOnActiveIngredient() {
        this.DrugNotExistStockReportFormViewModel.SelectedActiveIngredients = new Array<Guid>();
        for (let selectedItem of this.SelectedActiveIngredients) {
            this.DrugNotExistStockReportFormViewModel.SelectedActiveIngredients.push(selectedItem.ObjectID);
        }
        this.showActiveIngredientsMaterialMultiSelectForm = false;
    }

    public OzellikChanged(data) {
        if (data.addedItems.length === 1) {
            this.selectedSpecificationList.push(data.addedItems[0].code);
        }
        else if (data.removedItems.length === 1) {
            this.selectedSpecificationList.splice(this.selectedSpecificationList.findIndex(x => x === (data.removedItems[0].code)), 1);
        }
        this.DrugNotExistStockReportFormViewModel.SelectedSpecificationList = this.selectedSpecificationList;
    }

    public TurChanged(data) {
        if (data.addedItems.length === 1) {
            this.selectedShapeTypeList.push(data.addedItems[0].code);
        }
        else if (data.removedItems.length === 1) {
            this.selectedShapeTypeList.splice(this.selectedShapeTypeList.findIndex(x => x === (data.removedItems[0].code)), 1);
        }
        this.DrugNotExistStockReportFormViewModel.SelectedShapeTypeList = this.selectedShapeTypeList;
    }

    public async GetNotExistDrugList() {
        this.showLoadPanel = true;
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugNotExistStockReportService/GetNotExistDrugs';
            let body = { 'viewModel': this.DrugNotExistStockReportFormViewModel };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<Array<GetNotExistDrug_Output>>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.notExistDrugList = result;

                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
            this.TotalNumberOfRows = this.notExistDrugList.length;
        }
        catch (ex) {

        }
        finally {
            this.showLoadPanel = false;
        }
    }
}
