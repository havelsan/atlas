import { Component, OnInit, Input } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemApiService } from 'Fw/Services/SystemApiService';

import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MovableTransactionInputVoucherFormViewModel, MovableTransactionInputVoucherResultModel, VoucherDetailsInputModel, VoucherDetailsResultModel, MaterialDetailsInputModel, ModelForInfoInput, InventoryInput } from './MovableTransactionInputVoucherFormViewModel';
import { DrugSpecificationEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';




@Component({
    selector: 'MovableTransactionInputVoucherForm',
    templateUrl: './MovableTransactionInputVoucherForm.html',
    providers: [MessageService, SystemApiService]
})

export class MovableTransactionInputVoucherForm extends TTUnboundForm implements OnInit {

    _TTObject: any;
    public _ViewModel: MovableTransactionInputVoucherFormViewModel = new MovableTransactionInputVoucherFormViewModel();
    public CurrentPanelName: string = 'MovableTransactionInputVoucherForm';
    public Supplier: TTVisual.ITTObjectListBox;
    public BudgetTypeDefinition: TTVisual.ITTObjectListBox;
    public Accountancy: TTVisual.ITTObjectListBox;
    public voucherStockActionDetailIn: TTVisual.ITTListBoxColumn;
    public isDetailedSearch: boolean = true;
    public showZero: boolean = false;
    public visibility: boolean = false;
    public DrugSpecificationEnumDef;
    VademecumList: Array<number> = new Array<number>();
    public LoadPanelMessage: string = 'Kayıtlar Yükleniyor, Lütfen Bekleyiniz.';
    public showLoadPanel = false;

    Menu = [{
        id: "1",
        icon: "btn-default glyphicon glyphicon-list",
        items: [{
            id: "1_1",
            name: "Giriş Fişini Aç",
        }, {
            id: "1_2",
            name: "Çıkış Hareketlerini Göster",

        }, {
            id: "1_3",
            name: "XXXXXX Envanteri",

        }]}];

TotalText = "Toplam Kayıt:";
Sum = "Toplam";

    public MaterialList = [
        {
            caption: '',
            dataField: 'ObjectID',
            width: 75,
            cellTemplate: 'buttonCellTemplate',
        },
        {
            'caption': "Hasta Adı Soyadı",
            dataField: 'PatientName',
            allowSorting: true
        },
        {
            'caption': "Doktor Adı Soyadı",
            dataField: 'DoctorName',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "İade Tarihi",
            dataField: 'ReturnDate',
            allowSorting: true,
            format: "dd/MM/yyyy"
        },
        {
            'caption': "Servis",
            dataField: 'MasterResource',
            dataType: 'string',
            allowSorting: true,
        },
        {
            'caption': "Oda",
            dataField: 'Room',
            allowSorting: true
        },
        {
            'caption': "Yatak",
            dataField: 'Bed',
            dataType: 'string',
            allowSorting: true
        },

    ];

    private MovableTransactionInputVoucherForm_DocumentUrl: string = '/api/MovableTransactionInputVoucherService/MovableTransactionInputVoucherForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService,
         private modalService: IModalService,protected activeUserService: IActiveUserService ) {
        super('MovableTransactionInputVoucher', 'MovableTransactionInputVoucherForm');
        this.initViewModel();
    }


    public initViewModel(): void {

        this.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;

        this.Supplier = new TTVisual.TTObjectListBox();
        this.Supplier.ReadOnly = false;
        this.Supplier.ListDefName = "SupplierListDefinition";
        this.Supplier.Name = "Supplier";
        this.Supplier.TabIndex = 9;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 128;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '20%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ReadOnly = false;
        this.Accountancy.ListDefName = 'AccountancyList';
        this.Accountancy.Name = 'Accountancy';
        this.Accountancy.TabIndex = 121;

        this.voucherStockActionDetailIn = new TTVisual.TTListBoxColumn();
        //this.voucherStockActionDetailIn.AllowMultiSelect = true;
        this.voucherStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.voucherStockActionDetailIn.DataMember = "Material";
        this.voucherStockActionDetailIn.AutoCompleteDialogHeight = "60%";
        this.voucherStockActionDetailIn.AutoCompleteDialogWidth = "50%";
        this.voucherStockActionDetailIn.DisplayIndex = 1;
        this.voucherStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.voucherStockActionDetailIn.Name = "voucherStockActionDetailIn";
        this.voucherStockActionDetailIn.Width = 500;

    }

    async ngOnInit() {
        this.showOutTransactionPopUp = false;
        this.showMaterialDetailPopUp = false;
    }

    async ngAfterViewInit() {
    }



    @Input() set SelectedMainStore(value: any) {
        if (value != null && value != undefined)
            this._ViewModel.StoreID = value.ObjectID;
    }
    get SelectedMainStore(): any {
        return this._ViewModel.StoreID;
    }

    onStartDatePickerChanged(event) {
        if (event != null) {
            this._ViewModel.StartDate = Convert.ToDateTime(Convert.ToDateTime(event.value).ToShortDateString() + " 00:00:00");
        }
    }

    onFinishDatePickerChanged(event) {
        if (event != null) {
            this._ViewModel.EndDate = Convert.ToDateTime(Convert.ToDateTime(event.value).ToShortDateString() + " 23:59:00");

        }
    }

    public onSupplierChanged(event): void {

        if (event != null) {
            if (this._ViewModel.SupplierObjectID != event.ObjectID) {
                this._ViewModel.SupplierObjectID = event.ObjectID;
            }
        } else {
            this._ViewModel.SupplierObjectID = null;
        }
    }
    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ViewModel.BudgetTypeDefinitionObjectID !== event.ObjectID) {
                this._ViewModel.BudgetTypeDefinitionObjectID = event.ObjectID;
            }
        }
    }

    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._ViewModel.AccountancyObjectID !== event.ObjectID) {
                this._ViewModel.AccountancyObjectID = event.ObjectID;
            }
        } else {
            this._ViewModel.AccountancyObjectID = null;
        }
    }

    public selectedMaterialInDetailedSearch: Material;
    public onMaterialChanged(event): void {
        if (event != null) {
            if (this._ViewModel.MaterialObjectID !== event.ObjectID) {
                this._ViewModel.MaterialObjectID = event.ObjectID;
                this._ViewModel.SelectedMaterialInDetailedSearch = event;
            }
        }
        else {
            this._ViewModel.MaterialObjectID = null;
            this._ViewModel.SelectedMaterialInDetailedSearch = null;
        }
    }

    public onSearchSelectionChanged(event): void {
        this.FirstLevelResult = new Array<any>();
    }
    public showZeroValue(event): void {
        if (event.value === true) {
            this.showZero = true;
        }
        else {
            this.showZero = false;
        }
    }


    AutoDistributionButton: TTVisual.ITTButton;
    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.showMaterialMultiSelectForm = true;
    }

    public selectedMaterialsText: string = "";
    async MaterialsSelected(event) {
        this.showMaterialMultiSelectForm = false;
        let selectedMaterialItems = event;
        this.visibility = true;


        selectedMaterialItems.forEach(element => {
            let voucherMaterial: Material = new Material();
            voucherMaterial = element;
            this._ViewModel.SelectedFilterMaterials.push(voucherMaterial);
            this.selectedMaterialsText += element.Name + " - ";
        });
        // this.AutoDistributionButton.Enabled = false;
        // this.AutoDistributionButton.ReadOnly = true;
    }

    async MaterialsCleared() {
        //this.showMaterialMultiSelectForm = false;
        this._ViewModel.SelectedFilterMaterials = new Array<Material>();
        this.selectedMaterialsText = "";
    }


    itemClick(e, row){
        if (e.itemData.id == "1_1")
            this.selectAction(row);
        else if (e.itemData.id == "1_2")
            this.selectionChangedHandlerOnInMaterial(row);
        else if (e.itemData.id == "1_3")
            this.ChangeVisibility(row);
    }

    public FirstLevelResult;
    async GetWithFilter() {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string;
            this.showLoadPanel = true;
            if (this.isDetailedSearch === false) {
                apiUrlForPASearchUrl = '/api/MovableTransactionInputVoucherService/GetMovableTransactionInputVouchers';
            }
            else {
                apiUrlForPASearchUrl = '/api/MovableTransactionInputVoucherService/GetInputMaterialsForDetailedSearch';
            }
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            this._ViewModel.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
            await this.httpService.post(apiUrlForPASearchUrl, this._ViewModel).then(response => {
                let result = response;
                if (result) {
                    this.FirstLevelResult = result;
                    this.SelectedVoucher = null;
                    this.VoucherDetailList = new Array<any>();
                    this.SelectedMaterial = null;
                    this.MaterialDetailList = null;
                    this.showLoadPanel = false;
                }
            });



        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
            this.showLoadPanel = false;
        }
    }

    private ShowVoucherList: boolean = false;
    public StockTransactionID: Guid;
    public VoucherList;
    public async selectionChangedHandlerOnMaterialForDetailedSearch(value: any) {

        try {
            this.ShowVoucherDetailList = false;
            if (value != null) {
                this.StockTransactionID = value.value;
                let that = this;
                let input: ModelForInfoInput = new ModelForInfoInput();
                input.MaterialStockTransactionID = value.value;
                let apiUrlForPASearchUrl: string = '/api/MovableTransactionInputVoucherService/GetInVouchersForDetailedSearch';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.VoucherList = result;
                this.ShowVoucherList = true;
            } else {
                this.SelectedMaterial = null;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }


    private ShowOutVoucherList: boolean = false;
    public OutVouchers;
    public async selectionChangedHandlerOnMaterialForOutVouchers(value: any) {

        try {
            this.ShowVoucherDetailList = false;
            if (value != null) {
                let that = this;
                let input: ModelForInfoInput = new ModelForInfoInput();
                input.MaterialStockTransactionID = value.value;
                let apiUrlForPASearchUrl: string = '/api/MovableTransactionInputVoucherService/GetOutVouchersForDetailedSearch';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.OutVouchers = result;
                this.ShowOutVoucherList = true;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }


    public SelectedVoucher: MovableTransactionInputVoucherResultModel = new MovableTransactionInputVoucherResultModel();
    public VoucherDetailList: Array<any> = new Array<MovableTransactionInputVoucherResultModel>() ;
    private ShowVoucherDetailList: boolean = false;
    public async selectionChangedHandlerOnVoucher(event) {
        try {
            this.SelectedMaterial = null;
            this.MaterialDetailList = null;

            if (event != null && event.selectedRowsData != null && event.selectedRowsData[0] != null) {
                this.SelectedVoucher = event.selectedRowsData[0];
                let input: VoucherDetailsInputModel = new VoucherDetailsInputModel();
                input.StockActionObjectID = this.SelectedVoucher.StockActionObjectID;
                let that = this;
                let apiUrlForPASearchUrl: string = '/api/MovableTransactionInputVoucherService/GetVoucherDetailsOnMaterial';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });

                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.VoucherDetailList = new Array<MovableTransactionInputVoucherResultModel>();
                this.VoucherDetailList = this.VoucherDetailList.concat(result);
                if (this.isDetailedSearch === true) {
                    this.ShowVoucherDetailList = true;
                }
            } else {
                this.SelectedVoucher = null;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public clearSelectedMaterials() {
        this._ViewModel.SelectedFilterMaterials = new Array<Material>();
        this.selectedMaterialsText = "";

    }

    public SelectedMaterial: VoucherDetailsResultModel = new VoucherDetailsResultModel();
    public MaterialDetailList;
    public showMaterialDetailPopUp = false;
    public async selectionChangedHandlerOnMaterial(event) {
        try {
            if (event != null && event.data != null) {
                this.SelectedMaterial = event.data;

                let input: MaterialDetailsInputModel = new MaterialDetailsInputModel();
                input.StockActionObjectID = this.SelectedMaterial.StockActionObjectID;
                input.StockActionDetailObjectID = this.SelectedMaterial.StockActionDetailObjectID;
                input.MaterialObjectID = this.SelectedMaterial.MaterialObjectID;

                let that = this;
                let apiUrlForPASearchUrl: string = '/api/MovableTransactionInputVoucherService/GetMaterialDetailsOnStockTransaction';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });

                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.MaterialDetailList = result;
                this.showMaterialDetailPopUp = true;
            } else {
                this.SelectedMaterial = null;
                this.MaterialDetailList = null;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public OutTransactionList;
    public showOutTransactionPopUp;
    public async selectionChangedHandlerOnInMaterial(event) {

        try {
            this.ShowVoucherDetailList = false;
            if (event != null && event.data.StockTransactionID != null ) {
                let that = this;
                let input: ModelForInfoInput = new ModelForInfoInput();
                input.MaterialStockTransactionID = event.data.StockTransactionID;
                let apiUrlForPASearchUrl: string = '/api/MovableTransactionInputVoucherService/GetOutTransactionForInMaterials';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.OutTransactionList = result;
            }
            this.showOutTransactionPopUp = true;
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }


    }
    public inventoryList;
    private showInventoryDetail: boolean = false;

    public async ChangeVisibility(value: any) {

        try {
            this.showInventoryDetail = true;
            if (value != null) {
                let that = this;
                let input: InventoryInput = new InventoryInput();
                input.MaterialObjectID = value.value;
                input.viewModel = this._ViewModel;
                let apiUrlForPASearchUrl: string = '/api/MovableTransactionInputVoucherService/GetHospitalInventory';
                let body = "";
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: headers });
                let result = await this.httpService.post(apiUrlForPASearchUrl, input);
                this.inventoryList = result;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }
    private showStockAction(data: string): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DashboardActionComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;
            

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "İşlem Detayı");
            modalInfo.fullScreen = true;
            //modalInfo.Width = 1200;
            //modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async selectAction(value: any): Promise<void> {
        this.showStockAction(value.data.StockActionObjectID);
    }
    public OzellikChanged(data) {
        if (data.addedItems.length === 1) {
            this.VademecumList.push(data.addedItems[0].code);
        }
        else if (data.removedItems.length === 1) {
            this.VademecumList.splice(this.VademecumList.findIndex(x => x === (data.removedItems.code)), 1);
        }

        this._ViewModel.VademecumList = this.VademecumList;
    }


}