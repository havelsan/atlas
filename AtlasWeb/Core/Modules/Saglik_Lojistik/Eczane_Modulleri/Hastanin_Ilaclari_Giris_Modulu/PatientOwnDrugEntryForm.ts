//$66B4F319
import { Component, OnInit, ViewChild } from '@angular/core';
import { PatientOwnDrugEntryFormViewModel } from './PatientOwnDrugEntryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { PatientOwnDrugEntry, DrugDefinition, Material, DrugReturnActionDetail, PatientLastUseDrug } from 'NebulaClient/Model/AtlasClientModel';
import { PatientOwnDrugEntryDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ModalInfo } from 'Fw/Models/ModalInfo';

import { DrugOrderIntroductionService, DrugInfo, PatientOwnDrugInfo } from 'ObjectClassService/DrugOrderIntroductionService';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { DrugStickerInfo } from 'app/Barcode/Models/DrugBarcodeInfo';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { DatePipe } from '@angular/common';
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { DxDataGridComponent } from 'devextreme-angular';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
@Component({
    selector: 'PatientOwnDrugEntryForm',
    templateUrl: './PatientOwnDrugEntryForm.html',
    providers: [MessageService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }]
})
export class PatientOwnDrugEntryForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountPatientOwnDrugEntryDetail: TTVisual.ITTTextBoxColumn;
    ExpirationDatePatientOwnDrugEntryDetail: TTVisual.ITTDateTimePickerColumn;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    MaterialPatientOwnDrugEntryDetail: TTVisual.TTObjectListBox;
    PatientOwnDrugEntryDetails: TTVisual.ITTGrid;
    public patientOwnDrugs: Array<PatientOwnDrugInfo>;
    public PatientOwnDrugEntryDetailsColumns = [];
    public patientOwnDrugEntryFormViewModel: PatientOwnDrugEntryFormViewModel = new PatientOwnDrugEntryFormViewModel();
    public get _PatientOwnDrugEntry(): PatientOwnDrugEntry {
        return this._TTObject as PatientOwnDrugEntry;
    }
    private PatientOwnDrugEntryForm_DocumentUrl: string = '/api/PatientOwnDrugEntryService/PatientOwnDrugEntryForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService,
        private barcodePrintService: IBarcodePrintService) {
        super('PATIENTOWNDRUGENTRY', 'PatientOwnDrugEntryForm');
        this._DocumentServiceUrl = this.PatientOwnDrugEntryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public async setInputParam(value: Object) {
        this._TTObject = value as PatientOwnDrugEntry;
        this.patientOwnDrugEntryFormViewModel = new PatientOwnDrugEntryFormViewModel();
        this._ViewModel = this.patientOwnDrugEntryFormViewModel;
        this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry = value as PatientOwnDrugEntry;
        this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry.PatientOwnDrugEntryDetails = this.patientOwnDrugEntryFormViewModel.PatientOwnDrugEntryDetailsGridList;
        for (let detailItem of this.patientOwnDrugEntryFormViewModel.PatientOwnDrugEntryDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = this.patientOwnDrugEntryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                detailItem.Material = material;
            }
        }
        this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry.PatientLastUseDrugs = this.patientOwnDrugEntryFormViewModel.PatientLastUseDrugs;
        for (let detailItem of this.patientOwnDrugEntryFormViewModel.PatientLastUseDrugs) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = this.patientOwnDrugEntryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                detailItem.Material = material;
            }
        }

        //await this.PreScript();

    }

    columns = [
        {
            caption: "İlaç",
            name: "Material",
            dataField: "Material.Name",
            width: '50%',
            allowEditing: false
        },
        {
            caption: i18n("M19030", "Miktar"),
            name: "AmountPatientOwnDrugEntryDetail",
            dataField: "SendAmount",
            alignment: "left",
            width: '20%',
            allowEditing: true,
            validationRules: [{ type: 'required', message: 'Miktar Boş Geçilemez' }]
        },
        {
            caption: i18n("M27047", "Tarih"),
            name: "ExpirationDateStockActionDetailIn",
            dataField: "ExpirationDate",
            alignment: "left",
            format: 'dd/MM/yyyy',
            dataType: "date",
            width: '20%',
            allowEditing: true,
            validationRules: [{ type: 'required', message: 'Tarih Boş Geçilemez' }]
        },
        {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            alignment: "left",
            width: '3%',
            cellTemplate: "deleteCellTemplate"
        }
    ];

    columsOwnDrug = [
        {
            caption: "Barkod",
            name: "barcode",
            dataField: "barcode",
            width: "auto",
            allowEditing: false
        },
        {
            caption: "İlaç",
            name: "name",
            dataField: "name",
            alignment: "left",
            width: '40%',
            allowEditing: false
        },
        {
            caption: i18n("M27047", "Son Kul.Tarih"),
            name: "expireDate",
            dataField: "expireDate",
            alignment: "left",
            format: 'dd/MM/yyyy',
            dataType: "date",
            width: "auto",
            allowEditing: false
        },
        {
            caption: "Giriş Miktarı",
            name: "amount",
            dataField: "amount",
            alignment: "left",
            width: "auto",
            allowEditing: false
        },
        {
            caption: "Kalan Miktar",
            name: "restamount",
            dataField: "restamount",
            alignment: "left",
            width: "auto",
            allowEditing: false
        },
        {
            caption: "Barkod",
            name: "barcodeCellTemplate",
            alignment: "left",
            width: "auto",
            cellTemplate: "barcodeCellTemplate"
        },
        {
            caption: i18n("M27286", "Sil"),
            name: "RowDeleteOwnDetail",
            alignment: "left",
            width: '2%',
            cellTemplate: "deleteCellTemplate"
        }
    ];

    columnsLastDrug = [
        {
            caption: "İlaç",
            name: "Material",
            dataField: "Material.Name",
            width: '50%',
            allowEditing: false
        },
        {
            caption: i18n("M19030", "Miktar"),
            name: "AmountPatientOwnDrugEntryDetail",
            dataField: "Amount",
            alignment: "left",
            width: '20%',
            allowEditing: true,
            validationRules: [{ type: 'required', message: 'Miktar Boş Geçilemez' }]
        },
        {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            alignment: "left",
            width: '3%',
            cellTemplate: "deleteCellTemplate"
        }
    ];

    public selectedMaterial: Material;
    public async onMaterialSelectionChange(event: any) {

        if (this.selectedMaterial != null) {
            let newRow: PatientOwnDrugEntryDetail = new PatientOwnDrugEntryDetail();
            newRow.Material = this.selectedMaterial;
            this._PatientOwnDrugEntry.PatientOwnDrugEntryDetails.push(newRow);
        }

        this.selectedMaterial = null;
    }

    public selectedUsedMaterial: Material;
    public async onUsedMaterialSelectionChange(event: any) {

        if (this.selectedUsedMaterial != null) {
            let newRow: PatientLastUseDrug = new PatientLastUseDrug();
            newRow.Material = this.selectedUsedMaterial;
            this._PatientOwnDrugEntry.PatientLastUseDrugs.push(newRow);
        }

        this.selectedUsedMaterial = null;
    }

    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;
    async gridTreatmentMaterialGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    this.materialGrid.instance.deleteRow(data.rowIndex);
                }
            }
        }
    }

    @ViewChild('lastUsedDrugGrid') lastUsedDrugGrid: DxDataGridComponent;
    async gridLastUsedDrugGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    this.lastUsedDrugGrid.instance.deleteRow(data.rowIndex);
                }
            }
        }
    }

    public MaterialGridCellChanged(event: any) {
        let data = <PatientOwnDrugEntryDetail>event.key;
        if (data.ExpirationDate !== null) {
            let currentDate: Date = new Date();
            let endOfMonth: Date = new Date(data.ExpirationDate);
            if (currentDate <= data.ExpirationDate) {
                data.ExpirationDate = endOfMonth;
            } else {
                TTVisual.InfoBox.Alert(i18n("M22059", "Son kullanma tarihi bugunden küçük olamaz."));
                data.ExpirationDate = null;
            }
        }
    }

    public returnMessage: string;
    @ViewChild('oldDrug') oldDrug: DxDataGridComponent;
    async PatientOwnDetail_CellContentClicked(data: any) {
        if (data.column.name == "RowDeleteOwnDetail") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.amount === data.row.key.restamount) {
                        this.returnMessage = await DrugOrderIntroductionService.DeletePatientOwnDrugDetail(data.row.key.objectID);
                        ServiceLocator.MessageService.showSuccess(this.returnMessage);
                        let subepisodeID: Guid = <any>this._PatientOwnDrugEntry['SubEpisode'];
                        this.patientOwnDrugs = await DrugOrderIntroductionService.GetPatientOwnDrugDetail(subepisodeID);
                    } else {
                        ServiceLocator.MessageService.showError("Kullanılmış girişler silinemez sadece hastaya teslim yapılabilir.");
                    }

                }
            }
        }
        if (data.column.name == "barcodeCellTemplate") {
            if (data.row != null) {
                if (data.row.key != null) {
                    let datePipe = new DatePipe("en-US");
                    let infoBarcode: DrugStickerInfo = new DrugStickerInfo;
                    infoBarcode.DrugName = data.row.key.name;
                    if (data.row.key.expireDate != null) {
                        infoBarcode.ExpireDate = datePipe.transform(data.row.key.expireDate, "dd.MM.yyyy").toString();
                    }
                    else {
                        infoBarcode.ExpireDate = '';
                    }
                    infoBarcode.BarcodeCode = data.row.key.barcode;
                    infoBarcode.HospitalName = (await SystemParameterService.GetParameterValue("HOSPITALSHORTNAME", "GAZİLER FTR EĞİTİM ARŞ.HST"));
                    this.barcodePrintService.printAllBarcode(infoBarcode, "generateDrugSticker", "printDrugSticker");
                }
            }
        }
    }

    async btnMaterialBarcode(): Promise<void> {
        let datePipe = new DatePipe("en-US");
        for (let detail of this._PatientOwnDrugEntry.PatientOwnDrugEntryDetails) {
            for (let i = 0; i < detail.SendAmount; i++) {
                let infoBarcode: DrugStickerInfo = new DrugStickerInfo;
                infoBarcode.DrugName = detail.Material.Name;
                if (detail.ExpirationDate != null) {
                    infoBarcode.ExpireDate = datePipe.transform(detail.ExpirationDate, "dd.MM.yyyy").toString();
                }
                else {
                    infoBarcode.ExpireDate = '';
                }
                infoBarcode.BarcodeCode = detail.Material.Barcode;
                infoBarcode.HospitalName = (await SystemParameterService.GetParameterValue("HOSPITALSHORTNAME", "GAZİLER FTR EĞİTİM ARŞ.HST"));
                this.barcodePrintService.printAllBarcode(infoBarcode, "generateDrugSticker", "printDrugSticker");
                console.log(infoBarcode);
            }
        }
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    protected isLoadViewModel(): boolean {
        return false;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PatientOwnDrugEntry();
        this.patientOwnDrugEntryFormViewModel = new PatientOwnDrugEntryFormViewModel();
        this._ViewModel = this.patientOwnDrugEntryFormViewModel;
        this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry = this._TTObject as PatientOwnDrugEntry;
        this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry.PatientOwnDrugEntryDetails = new Array<PatientOwnDrugEntryDetail>();
        this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry.PatientLastUseDrugs = new Array<PatientLastUseDrug>();
    }

    protected loadViewModel() {
        let that = this;
        that.patientOwnDrugEntryFormViewModel = this._ViewModel as PatientOwnDrugEntryFormViewModel;
        that._TTObject = this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry;
        if (this.patientOwnDrugEntryFormViewModel == null)
            this.patientOwnDrugEntryFormViewModel = new PatientOwnDrugEntryFormViewModel();
        if (this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry == null)
            this.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry = new PatientOwnDrugEntry();
        that.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry.PatientOwnDrugEntryDetails = that.patientOwnDrugEntryFormViewModel.PatientOwnDrugEntryDetailsGridList;
        for (let detailItem of that.patientOwnDrugEntryFormViewModel.PatientOwnDrugEntryDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.patientOwnDrugEntryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }
        that.patientOwnDrugEntryFormViewModel._PatientOwnDrugEntry.PatientLastUseDrugs = that.patientOwnDrugEntryFormViewModel.PatientLastUseDrugs;
        for (let detailItem of that.patientOwnDrugEntryFormViewModel.PatientLastUseDrugs) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.patientOwnDrugEntryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }

    }

    async ngOnInit() {
        await this.load();
        this.FormCaption = i18n("M15461", "Hastanın İlaçları Giriş ( Yeni )");
        let subepisodeID: Guid = <any>this._PatientOwnDrugEntry['SubEpisode'];
        this.patientOwnDrugs = await DrugOrderIntroductionService.GetPatientOwnDrugDetail(subepisodeID);
    }
    public isApproval: string;
    protected async ClientSidePreScript(): Promise<void> {
        this.isApproval = (await SystemParameterService.GetParameterValue('PATIENTOWNDRUGSTATENEWTOCOMPLETED', 'FALSE'));
        if (this.isApproval === 'TRUE') {
            this.DropStateButton(PatientOwnDrugEntry.PatientOwnDrugEntryStates.PharmacyApproval);
        }
        else {
            this.DropStateButton(PatientOwnDrugEntry.PatientOwnDrugEntryStates.Completed);
        }
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        if (this._PatientOwnDrugEntry.PatientOwnDrugEntryDetails.length == 0 && this._PatientOwnDrugEntry.PatientLastUseDrugs.length == 0) {
            throw new TTException("İlaç girmeden işleme devam edemessiniz");

        }

        if (this._PatientOwnDrugEntry.PatientOwnDrugEntryDetails.length > 0) {
            for (let det of this._PatientOwnDrugEntry.PatientOwnDrugEntryDetails) {
                if (det.ExpirationDate == null)
                    throw new TTException("son kullanma tarihi olmadan işleme devam edemessiniz");
                if (Date.Now <= det.ExpirationDate)
                    throw new TTException("son kullanma tarihi geçmiş tarihi kontrol ediniz");

            }


            if (transDef != null) {
                super.ClientSidePostScript(transDef);
                for (let detailItem of this._PatientOwnDrugEntry.PatientOwnDrugEntryDetails) {
                    detailItem.Amount = detailItem.SendAmount;
                }

                if (transDef.ToStateDefID == PatientOwnDrugEntry.PatientOwnDrugEntryStates.Completed) {
                    this.btnMaterialBarcode();
                }
            }
        }

        if(this._PatientOwnDrugEntry.PatientLastUseDrugs.length > 0){
            for (let det of this._PatientOwnDrugEntry.PatientLastUseDrugs) {
                if (det.Amount == null)
                    throw new TTException("Son 24 Saatte kullanılan ilaçların miktarı boş olamaz.");
            }
        }
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._PatientOwnDrugEntry != null && this._PatientOwnDrugEntry.ActionDate !== event) {
                this._PatientOwnDrugEntry.ActionDate = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._PatientOwnDrugEntry != null && this._PatientOwnDrugEntry.ID !== event) {
                this._PatientOwnDrugEntry.ID = event;
            }
        }
    }

    PatientOwnDrugEntryDetails_CellValueChangedEmitted(data: any) {
        if (data && this.PatientOwnDrugEntryDetails_CellValueChanged && data.Row && data.Column) {
            this.PatientOwnDrugEntryDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public async PatientOwnDrugEntryDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        if (data.Column.Name === "ExpirationDateStockActionDetailIn") {
            let patientOwnDrugEntryDetail: PatientOwnDrugEntryDetail = <PatientOwnDrugEntryDetail>data.Row.TTObject;
            let currentDate: Date = new Date();
            let endOfMonth: Date = new Date(patientOwnDrugEntryDetail.ExpirationDate.getFullYear(), patientOwnDrugEntryDetail.ExpirationDate.getMonth() + 1, 1).AddDays(-1);
            if (currentDate <= patientOwnDrugEntryDetail.ExpirationDate) {
                patientOwnDrugEntryDetail.ExpirationDate = endOfMonth;
            } else {
                TTVisual.InfoBox.Alert(i18n("M22059", "Son kullanma tarihi bugunden küçük olamaz."));
                patientOwnDrugEntryDetail.ExpirationDate = null;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.ID, 'Text', this.__ttObject, 'ID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
    }

    public initFormControls(): void {
        this.PatientOwnDrugEntryDetails = new TTVisual.TTGrid();
        this.PatientOwnDrugEntryDetails.Name = 'PatientOwnDrugEntryDetails';
        this.PatientOwnDrugEntryDetails.TabIndex = 4;
        this.PatientOwnDrugEntryDetails.Height = 300;

        this.MaterialPatientOwnDrugEntryDetail = new TTVisual.TTObjectListBox();
        this.MaterialPatientOwnDrugEntryDetail.ListDefName = 'DrugList';
        this.MaterialPatientOwnDrugEntryDetail.DataMember = 'Material';
        // this.MaterialPatientOwnDrugEntryDetail.DisplayIndex = 0;
        // this.MaterialPatientOwnDrugEntryDetail.HeaderText = i18n("M16287", "İlaç");
        this.MaterialPatientOwnDrugEntryDetail.Name = 'MaterialPatientOwnDrugEntryDetail';
        this.MaterialPatientOwnDrugEntryDetail.Width = 300;
        this.MaterialPatientOwnDrugEntryDetail.AutoCompleteDialogHeight = '150';
        this.MaterialPatientOwnDrugEntryDetail.AutoCompleteDialogWidth = '50%';
        this.MaterialPatientOwnDrugEntryDetail.ListFilterExpression = "ISACTIVE = 1";





        this.AmountPatientOwnDrugEntryDetail = new TTVisual.TTTextBoxColumn();
        this.AmountPatientOwnDrugEntryDetail.DataMember = 'SendAmount';
        this.AmountPatientOwnDrugEntryDetail.DisplayIndex = 1;
        this.AmountPatientOwnDrugEntryDetail.HeaderText = i18n("M19030", "Miktar");
        this.AmountPatientOwnDrugEntryDetail.Name = 'AmountPatientOwnDrugEntryDetail';
        this.AmountPatientOwnDrugEntryDetail.Width = 80;

        this.ExpirationDatePatientOwnDrugEntryDetail = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDatePatientOwnDrugEntryDetail.Format = DateTimePickerFormat.Custom;
        this.ExpirationDatePatientOwnDrugEntryDetail.CustomFormat = "MM/yyyy";
        this.ExpirationDatePatientOwnDrugEntryDetail.DataMember = "ExpirationDate";
        this.ExpirationDatePatientOwnDrugEntryDetail.DisplayIndex = 13;
        this.ExpirationDatePatientOwnDrugEntryDetail.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDatePatientOwnDrugEntryDetail.Name = "ExpirationDateStockActionDetailIn";
        this.ExpirationDatePatientOwnDrugEntryDetail.Width = 180;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16869", "İşlem Nu.");
        this.labelID.Name = 'labelID';
        this.labelID.TabIndex = 3;

        this.ID = new TTVisual.TTTextBox();
        this.ID.Name = 'ID';
        this.ID.TabIndex = 2;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 1;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 0;

        this.PatientOwnDrugEntryDetailsColumns = [this.MaterialPatientOwnDrugEntryDetail, this.AmountPatientOwnDrugEntryDetail, this.ExpirationDatePatientOwnDrugEntryDetail];
        this.Controls = [this.PatientOwnDrugEntryDetails, this.MaterialPatientOwnDrugEntryDetail, this.AmountPatientOwnDrugEntryDetail, this.labelID, this.ID, this.labelActionDate, this.ActionDate, this.ExpirationDatePatientOwnDrugEntryDetail];

    }


}
