//$08CE8C33
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { CostActionNewFormViewModel } from './CostActionNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseCostActionForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Aylik_Maliyet_Analizi/BaseCostActionForm";
import { CostAction } from 'NebulaClient/Model/AtlasClientModel';
import { CostActionService, CostActionCreateTS_Output, StockActionData_Output, GetActiveStockAction_Output } from "ObjectClassService/CostActionService";
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { CostActionMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { SystemParameterService } from 'ObjectClassService/SystemParameterService';

import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { DynamicComponentInfoDVO } from 'Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
@Component({
    selector: 'CostActionNewForm',
    templateUrl: './CostActionNewForm.html',
    providers: [MessageService]
})
export class CostActionNewForm extends BaseCostActionForm implements OnInit {
    public CostActionMaterialsColumns = [];
    public activeStockAction: Array<GetActiveStockAction_Output> = new Array<GetActiveStockAction_Output>();
    public costActionNewFormViewModel: CostActionNewFormViewModel = new CostActionNewFormViewModel();
    public loadingVisible: boolean = false;
    public showActiveAction: boolean = false;
    public get _CostAction(): CostAction {
        return this._TTObject as CostAction;
    }
    private CostActionNewForm_DocumentUrl: string = '/api/CostActionService/CostActionNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private objectContextService: ObjectContextService,
        private changeDetectorRef: ChangeDetectorRef,private modalService: IModalService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.CostActionNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    NewFormCancel() {
        super.cancel();
    }

    // ***** Method declarations start *****

    protected async PreScript(): Promise<void> {
        let costactionToComp: string = (await SystemParameterService.GetParameterValue('COSTACTIONAPPROVALSTATEBYPASS', 'TRUE'));
        if (costactionToComp === 'TRUE') {
            this.DropStateButton(CostAction.CostActionStates.Approval);
        }

        if (this._CostAction.CurrentStateDefID.toString() === CostAction.CostActionStates.New.id && this._CostAction.CostActionMaterials.length === 0) {
            super.PreScript();
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
            this.activeStockAction = await CostActionService.GetActiveStockAction(this._CostAction.Store.ObjectID);
            let controlAction: boolean = false;
            if (this.activeStockAction.length > 0) {
                this.showActiveAction = true;
            } else {
                controlAction = true;
            }

            if (controlAction === true) {
                this.loadingVisible = true;
                let costActionOutputs: CostActionCreateTS_Output = await CostActionService.CostActionDateCreatTS(this._CostAction);

                for (let costDets of costActionOutputs.costActionMaterials) {
                    let mat: Guid = <any>costDets["Material"];
                    let material: Material = costActionOutputs.materials.find(x => x.ObjectID === mat);
                    costDets.Material = material;
                    this.costActionNewFormViewModel._CostAction.CostActionMaterials.push(costDets);
                }

                this.costActionNewFormViewModel._CostAction.StartDate = costActionOutputs.dateStart;
                this.costActionNewFormViewModel._CostAction.EndDate = costActionOutputs.dateEnd;
                this.CostActionMaterials.ReadOnly = true;
                this.CostActionMaterials.AllowUserToAddRows = false;
                if (costActionOutputs.dateStart != null && costActionOutputs.dateEnd != null) {
                    this.costActionNewFormViewModel._CostAction.Description = this._CostAction.Store.Name + "  " + costActionOutputs.desctiption + i18n("M11089", " Maliyet Hesaplama");
                    this.costActionNewFormViewModel._CostAction.CostActionDesciption = costActionOutputs.desctiption;
                }

                this.stockActionDataOutput = costActionOutputs.stockActionData_Outputs;
                this.loadingVisible = false;
            }
        }
    }

    public async continueClick()
    {
        this.loadingVisible = true;
        let costActionOutputs: CostActionCreateTS_Output = await CostActionService.CostActionDateCreatTS(this._CostAction);

        for (let costDets of costActionOutputs.costActionMaterials) {
            let mat: Guid = <any>costDets["Material"];
            let material: Material = costActionOutputs.materials.find(x => x.ObjectID === mat);
            costDets.Material = material;
            this.costActionNewFormViewModel._CostAction.CostActionMaterials.push(costDets);
        }

        this.costActionNewFormViewModel._CostAction.StartDate = costActionOutputs.dateStart;
        this.costActionNewFormViewModel._CostAction.EndDate = costActionOutputs.dateEnd;
        this.CostActionMaterials.ReadOnly = true;
        this.CostActionMaterials.AllowUserToAddRows = false;
        if (costActionOutputs.dateStart != null && costActionOutputs.dateEnd != null) {
            this.costActionNewFormViewModel._CostAction.Description = this._CostAction.Store.Name + "  " + costActionOutputs.desctiption + i18n("M11089", " Maliyet Hesaplama");
            this.costActionNewFormViewModel._CostAction.CostActionDesciption = costActionOutputs.desctiption;
        }

        this.stockActionDataOutput = costActionOutputs.stockActionData_Outputs;
        this.loadingVisible = false;
        this.showActiveAction = false;
    }

    public  cancelClick(){
        ServiceLocator.MessageService.showError('İşlem iptal edildi. İlgili işlemleri iptal edebilirsiniz.');
        this.showActiveAction= false;
    }

    // *****Method declarations end *****
    public stockActionDataOutput: Array<StockActionData_Output> = new Array<StockActionData_Output>();
    public StockActionDataGrid = [
        {
            caption: i18n("M16870", "İşlem Numarası"),
            dataField: 'StockActionID'
        },
        {
            caption: i18n("M23452", "TİF Numarası"),
            dataField: 'DocumentRecordLogNumber',
            allowSorting: true
        },
        {
            caption: "İşlem Türü",
            dataField: 'documentTransactionType',
            cellTemplate: 'enumCmbTemplate',
            allowSorting: true
        },
        {
            caption: "MKYS Durumu",
            dataField: 'mkysControlEnum',
            cellTemplate: 'enumMKYSTemplate',
            allowSorting: true
        },
        {
            caption: i18n("M16818", "İşlem"),
            dataField: 'Desciption',
            allowSorting: true
        }, {
            caption: 'İşlemi Aç',
            dataField: 'StockActionObjectId',
            cellTemplate: 'buttonCellTemplate',
            width: 50
        }];

    public CostActionDetailCol = [
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: 'Malzeme',
            dataField: 'Material.Name',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: 'Devreden Miktar',
            dataField: 'PreviousMothInheld',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Devreden Toplam Maliyet',
            dataField: 'PreviousMonthPrice',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Toplam Aylık Giriş',
            dataField: 'TotalAmount',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Toplam Aylık Çıkış',
            dataField: 'TotalOutAmunt',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Aylık Toplam Giriş Fiyatı',
            dataField: 'TotalPrice',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Birim Maliyet',
            dataField: 'AvarageUnitePrice',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Satış Fiyatı',
            dataField: 'MaterialPrice',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Kar / Zarar',
            dataField: 'ProfitAndLoss',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Bir Sonraki Aya Devreden Toplam Maliyet',
            dataField: 'DifAvarageUnitePrice',
            dataType: "number",
            width: 'auto',
            allowEditing: false,
        },
        {
            caption: 'Bir Sonraki Aya Devreden Miktar',
            dataField: 'TransferredAmount',
            dataType: "number",
            width: 160,
            allowEditing: false,
        },
    ];

    public initViewModel(): void {
        this._TTObject = new CostAction();
        this.costActionNewFormViewModel = new CostActionNewFormViewModel();
        this._ViewModel = this.costActionNewFormViewModel;
        this.costActionNewFormViewModel._CostAction = this._TTObject as CostAction;
        this.costActionNewFormViewModel._CostAction.CostActionMaterials = new Array<CostActionMaterial>();
        this.costActionNewFormViewModel._CostAction.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.costActionNewFormViewModel = this._ViewModel as CostActionNewFormViewModel;
        that._TTObject = this.costActionNewFormViewModel._CostAction;
        if (this.costActionNewFormViewModel == null)
            this.costActionNewFormViewModel = new CostActionNewFormViewModel();
        if (this.costActionNewFormViewModel._CostAction == null)
            this.costActionNewFormViewModel._CostAction = new CostAction();
        that.costActionNewFormViewModel._CostAction.CostActionMaterials = that.costActionNewFormViewModel.CostActionMaterialsGridList;
        for (let detailItem of that.costActionNewFormViewModel.CostActionMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.costActionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }
        let storeObjectID = that.costActionNewFormViewModel._CostAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.costActionNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.costActionNewFormViewModel._CostAction.Store = store;
            }
        }
    }

    public componentInfo: DynamicComponentInfo;
    async select(value: any): Promise<void> {
        this.httpService.get<DynamicComponentInfoDVO>('api/LogisticWorkList/GetDynamicComponentInfo?ObjectId=' + value.data.StockActionObjectId).then((result: DynamicComponentInfoDVO) => {
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = result.ComponentName;
            compInfo.ModuleName = result.ModuleName;
            compInfo.ModulePath = result.ModulePath;
            compInfo.objectID = result.objectID;
            this.componentInfo = compInfo;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "İşlem Detayı");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let resultx = this.modalService.create(this.componentInfo, modalInfo);
            
        });
    }

    async selectCancelAction(value: any): Promise<void> {
        this.httpService.get<DynamicComponentInfoDVO>('api/LogisticWorkList/GetDynamicComponentInfo?ObjectId=' + value.data.objectID).then((result: DynamicComponentInfoDVO) => {
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = result.ComponentName;
            compInfo.ModuleName = result.ModuleName;
            compInfo.ModulePath = result.ModulePath;
            compInfo.objectID = result.objectID;
            this.componentInfo = compInfo;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "İşlem Detayı");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let resultx = this.modalService.create(this.componentInfo, modalInfo);
            
        });
    }

    async ngOnInit() {
        let that = this;
        await this.load(CostActionNewFormViewModel);
        this.FormCaption = "Aylık Ortalama Maliyet Analizi ( Yeni )";
        this.changeDetectorRef.detectChanges();

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.Description != event) {
                this._CostAction.Description = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.StockActionID != event) {
                this._CostAction.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.Store != event) {
                this._CostAction.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.TransactionDate != event) {
                this._CostAction.TransactionDate = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.StartDate != event) {
                this._CostAction.StartDate = event;
            }
        }
    }

    public onttdatetimepicker2Changed(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.EndDate != event) {
                this._CostAction.EndDate = event;
            }
        }
    }

    CostActionMaterials_CellValueChangedEmitted(data: any) {
        if (data && this.CostActionMaterials_CellValueChangedEmitted && data.Row && data.Column) {
            this.CostActionMaterials_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {

    }
    public async CostActionMaterials_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        // await super.CostActionMaterials_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: CostActionMaterial) {
    }

    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.ttdatetimepicker2, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 15;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 14;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 13;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 12;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M10469", "Açıklama");
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 11;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 9;

        this.TTDatetime = new TTVisual.TTLabel();
        this.TTDatetime.Text = i18n("M11637", "Başlangıç Tarihi");
        this.TTDatetime.Name = "TTDatetime";
        this.TTDatetime.TabIndex = 8;

        this.ttdatetimepicker2 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker2.BackColor = "#F0F0F0";
        this.ttdatetimepicker2.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker2.Enabled = false;
        this.ttdatetimepicker2.Name = "ttdatetimepicker2";
        this.ttdatetimepicker2.TabIndex = 7;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.Enabled = false;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 6;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M18564", "Malzeme Detayları");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 5;

        this.CostActionMaterials = new TTVisual.TTGrid();
        this.CostActionMaterials.Name = "CostActionMaterials";
        this.CostActionMaterials.TabIndex = 16;
        this.CostActionMaterials.AllowUserToDeleteRows = false;
        this.CostActionMaterials.Height = 500;
        this.CostActionMaterials.ReadOnly = true;


        this.MaterialCostActionMaterial = new TTVisual.TTListBoxColumn();
        this.MaterialCostActionMaterial.ListDefName = "MaterialListDefinition";
        this.MaterialCostActionMaterial.DataMember = "Material";
        this.MaterialCostActionMaterial.DisplayIndex = 0;
        this.MaterialCostActionMaterial.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialCostActionMaterial.Name = "MaterialCostActionMaterial";
        this.MaterialCostActionMaterial.Width = 450;
        this.MaterialCostActionMaterial.ReadOnly = true;

        this.PreviousMothInheldCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.PreviousMothInheldCostActionMaterial.DataMember = "PreviousMothInheld";
        this.PreviousMothInheldCostActionMaterial.DisplayIndex = 1;
        this.PreviousMothInheldCostActionMaterial.HeaderText = i18n("M12707", "Devreden Miktar");
        this.PreviousMothInheldCostActionMaterial.Name = "PreviousMothInheldCostActionMaterial";
        this.PreviousMothInheldCostActionMaterial.Width = 120;
        this.PreviousMothInheldCostActionMaterial.ReadOnly = true;

        this.PreviousMonthPriceCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.PreviousMonthPriceCostActionMaterial.DataMember = "PreviousMonthPrice";
        this.PreviousMonthPriceCostActionMaterial.DisplayIndex = 2;
        this.PreviousMonthPriceCostActionMaterial.HeaderText = i18n("M12708", "Devreden Toplam Maliyet");
        this.PreviousMonthPriceCostActionMaterial.Name = "PreviousMonthPriceCostActionMaterial";
        this.PreviousMonthPriceCostActionMaterial.Width = 169;
        this.PreviousMonthPriceCostActionMaterial.ReadOnly = true;

        this.TotalAmountCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.TotalAmountCostActionMaterial.DataMember = "TotalAmount";
        this.TotalAmountCostActionMaterial.DisplayIndex = 3;
        this.TotalAmountCostActionMaterial.HeaderText = i18n("M23479", "Toplam Aylık Giriş");
        this.TotalAmountCostActionMaterial.Name = "TotalAmountCostActionMaterial";
        this.TotalAmountCostActionMaterial.Width = 124;
        this.TotalAmountCostActionMaterial.ReadOnly = true;

        this.TotalOutAmuntCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.TotalOutAmuntCostActionMaterial.DataMember = "TotalOutAmunt";
        this.TotalOutAmuntCostActionMaterial.DisplayIndex = 4;
        this.TotalOutAmuntCostActionMaterial.HeaderText = i18n("M23478", "Toplam Aylık Çıkış");
        this.TotalOutAmuntCostActionMaterial.Name = "TotalOutAmuntCostActionMaterial";
        this.TotalOutAmuntCostActionMaterial.Width = 128;
        this.TotalOutAmuntCostActionMaterial.ReadOnly = true;


        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "TotalPrice";
        this.TotalPrice.DisplayIndex = 5;
        this.TotalPrice.HeaderText = i18n("M11333", "Aylık Toplam Giriş Fiyatı");
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.Width = 160;
        this.TotalPrice.ReadOnly = true;

        this.AvarageUnitePriceCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.AvarageUnitePriceCostActionMaterial.DataMember = "AvarageUnitePrice";
        this.AvarageUnitePriceCostActionMaterial.DisplayIndex = 6;
        this.AvarageUnitePriceCostActionMaterial.HeaderText = i18n("M11867", "Birim Maliyet");
        this.AvarageUnitePriceCostActionMaterial.Name = "AvarageUnitePriceCostActionMaterial";
        this.AvarageUnitePriceCostActionMaterial.Width = 103;
        this.AvarageUnitePriceCostActionMaterial.ReadOnly = true;

        this.MaterialPriceCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.MaterialPriceCostActionMaterial.DataMember = "MaterialPrice";
        this.MaterialPriceCostActionMaterial.DisplayIndex = 7;
        this.MaterialPriceCostActionMaterial.HeaderText = i18n("M21392", "Satış Fiyatı");
        this.MaterialPriceCostActionMaterial.Name = "MaterialPriceCostActionMaterial";
        this.MaterialPriceCostActionMaterial.Width = 86;
        this.MaterialPriceCostActionMaterial.ReadOnly = true;

        this.ProfitAndLossCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.ProfitAndLossCostActionMaterial.DataMember = "ProfitAndLoss";
        this.ProfitAndLossCostActionMaterial.DisplayIndex = 8;
        this.ProfitAndLossCostActionMaterial.HeaderText = i18n("M17260", "Kar / Zarar");
        this.ProfitAndLossCostActionMaterial.Name = "ProfitAndLossCostActionMaterial";
        this.ProfitAndLossCostActionMaterial.Width = 82;
        this.ProfitAndLossCostActionMaterial.ReadOnly = true;

        this.DifAvarageUnitePriceCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.DifAvarageUnitePriceCostActionMaterial.DataMember = "DifAvarageUnitePrice";
        this.DifAvarageUnitePriceCostActionMaterial.DisplayIndex = 9;
        this.DifAvarageUnitePriceCostActionMaterial.HeaderText = i18n("M11842", "Bir Sonraki Aya Devreden Toplam Maliyet");
        this.DifAvarageUnitePriceCostActionMaterial.Name = "DifAvarageUnitePriceCostActionMaterial";
        this.DifAvarageUnitePriceCostActionMaterial.Width = 263;
        this.DifAvarageUnitePriceCostActionMaterial.ReadOnly = true;

        this.TransferredAmount = new TTVisual.TTTextBoxColumn();
        this.TransferredAmount.DataMember = "TransferredAmount";
        this.TransferredAmount.DisplayIndex = 10;
        this.TransferredAmount.HeaderText = "Bir Sonraki Aya Devreden Miktar";
        this.TransferredAmount.Name = "TransferredAmount";
        this.TransferredAmount.Width = 168;
        this.TransferredAmount.ReadOnly = true;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M10896", "Ana Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 1;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 0;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M11939", "Bitiş Tarihi");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 8;

        this.CostActionMaterialsColumns = [this.MaterialCostActionMaterial, this.PreviousMothInheldCostActionMaterial, this.PreviousMonthPriceCostActionMaterial, this.TotalAmountCostActionMaterial, this.TotalOutAmuntCostActionMaterial, this.TotalPrice, this.AvarageUnitePriceCostActionMaterial, this.MaterialPriceCostActionMaterial, this.ProfitAndLossCostActionMaterial, this.DifAvarageUnitePriceCostActionMaterial, this.TransferredAmount];
        this.ttgroupbox2.Controls = [this.Description];
        this.ttgroupbox1.Controls = [this.CostActionMaterials];
        this.Controls = [this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.StockActionID, this.ttgroupbox2, this.Description, this.TTDatetime, this.ttdatetimepicker2, this.ttdatetimepicker1, this.ttgroupbox1, this.CostActionMaterials, this.MaterialCostActionMaterial, this.PreviousMothInheldCostActionMaterial, this.PreviousMonthPriceCostActionMaterial, this.TotalAmountCostActionMaterial, this.TotalOutAmuntCostActionMaterial, this.TotalPrice, this.AvarageUnitePriceCostActionMaterial, this.MaterialPriceCostActionMaterial, this.ProfitAndLossCostActionMaterial, this.DifAvarageUnitePriceCostActionMaterial, this.TransferredAmount, this.labelStore, this.Store, this.ttlabel2];

    }


}
