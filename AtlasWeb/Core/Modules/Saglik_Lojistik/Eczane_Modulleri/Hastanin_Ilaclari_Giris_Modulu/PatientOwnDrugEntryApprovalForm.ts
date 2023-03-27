//$4BEC2A51
import { Component, OnInit } from '@angular/core';
import { PatientOwnDrugEntryApprovalFormViewModel } from './PatientOwnDrugEntryApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { PatientOwnDrugEntry } from 'NebulaClient/Model/AtlasClientModel';
import { PatientOwnDrugEntryDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { DrugStickerInfo } from 'app/Barcode/Models/DrugBarcodeInfo';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'PatientOwnDrugEntryApprovalForm',
    templateUrl: './PatientOwnDrugEntryApprovalForm.html',
    providers: [MessageService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }]
})
export class PatientOwnDrugEntryApprovalForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountPatientOwnDrugEntryDetail: TTVisual.ITTTextBoxColumn;
    BarcodeAmountPatientOwnDrugEntryDetail: TTVisual.ITTTextBoxColumn;
    ExpirationDatePatientOwnDrugEntryDetail: TTVisual.ITTDateTimePickerColumn;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    MaterialPatientOwnDrugEntryDetail: TTVisual.ITTListBoxColumn;
    PatientOwnDrugEntryDetails: TTVisual.ITTGrid;
    SendAmountPatientOwnDrugEntryDetail: TTVisual.ITTTextBoxColumn;
    public PatientOwnDrugEntryDetailsColumns = [];
    public patientOwnDrugEntryApprovalFormViewModel: PatientOwnDrugEntryApprovalFormViewModel = new PatientOwnDrugEntryApprovalFormViewModel();
    public get _PatientOwnDrugEntry(): PatientOwnDrugEntry {
        return this._TTObject as PatientOwnDrugEntry;
    }
    private PatientOwnDrugEntryApprovalForm_DocumentUrl: string = '/api/PatientOwnDrugEntryService/PatientOwnDrugEntryApprovalForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private barcodePrintService: IBarcodePrintService) {
        super('PATIENTOWNDRUGENTRY', 'PatientOwnDrugEntryApprovalForm');
        this._DocumentServiceUrl = this.PatientOwnDrugEntryApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        if (this._PatientOwnDrugEntry.CurrentStateDefID.toString() === PatientOwnDrugEntry.PatientOwnDrugEntryStates.Completed.id) {
            this.PatientOwnDrugEntryDetails.AllowUserToDeleteRows = false;
        }
    }

    GridDiagnosisGridList;
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PatientOwnDrugEntry();
        this.patientOwnDrugEntryApprovalFormViewModel = new PatientOwnDrugEntryApprovalFormViewModel();
        this._ViewModel = this.patientOwnDrugEntryApprovalFormViewModel;
        this.patientOwnDrugEntryApprovalFormViewModel._PatientOwnDrugEntry = this._TTObject as PatientOwnDrugEntry;
        this.patientOwnDrugEntryApprovalFormViewModel._PatientOwnDrugEntry.PatientOwnDrugEntryDetails = new Array<PatientOwnDrugEntryDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.patientOwnDrugEntryApprovalFormViewModel = this._ViewModel as PatientOwnDrugEntryApprovalFormViewModel;
        that._TTObject = this.patientOwnDrugEntryApprovalFormViewModel._PatientOwnDrugEntry;
        if (this.patientOwnDrugEntryApprovalFormViewModel == null)
            this.patientOwnDrugEntryApprovalFormViewModel = new PatientOwnDrugEntryApprovalFormViewModel();
        if (this.patientOwnDrugEntryApprovalFormViewModel._PatientOwnDrugEntry == null)
            this.patientOwnDrugEntryApprovalFormViewModel._PatientOwnDrugEntry = new PatientOwnDrugEntry();
        that.patientOwnDrugEntryApprovalFormViewModel._PatientOwnDrugEntry.PatientOwnDrugEntryDetails = that.patientOwnDrugEntryApprovalFormViewModel.PatientOwnDrugEntryDetailsGridList;
        for (let detailItem of that.patientOwnDrugEntryApprovalFormViewModel.PatientOwnDrugEntryDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.patientOwnDrugEntryApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }

    }
    public PatientOwnDrugEntryColumns = [

        {
            caption: 'İlaç ',
            dataField: 'Material.Name',
            width: 500
        },
        {
            caption: 'Gönderilen Miktar ',
            dataField: 'SendAmount',
            dataType: 'number',
            width: 120
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            dataType: 'number',
            width: 120
        },
        {
            caption: 'Barkod Miktarı',
            dataField: 'BarcodeAmount',
            dataType: 'number',
            width: 120
        },
        {
            caption: 'Son Kullanma Tarihi ',
            dataField: 'ExpirationDate',
            width: 120
        },
        
    ];

    async btnMaterialBarcode(): Promise<void> {
        let datePipe = new DatePipe("en-US");
        for (let detail of this._PatientOwnDrugEntry.PatientOwnDrugEntryDetails) {
            for (let i = 0; i < detail.BarcodeAmount; i++) {
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

    async ngOnInit() {
        await this.load();
        this.FormCaption = 'Hastanın İlaçları Giriş ( Onay )';
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
        this.PatientOwnDrugEntryDetails.AllowUserToAddRows = false;
        this.PatientOwnDrugEntryDetails.DeleteButtonWidth = 5;


        this.MaterialPatientOwnDrugEntryDetail = new TTVisual.TTListBoxColumn();
        this.MaterialPatientOwnDrugEntryDetail.ListDefName = 'DrugList';
        this.MaterialPatientOwnDrugEntryDetail.DataMember = 'Material';
        this.MaterialPatientOwnDrugEntryDetail.DisplayIndex = 0;
        this.MaterialPatientOwnDrugEntryDetail.HeaderText = i18n("M16287", "İlaç");
        this.MaterialPatientOwnDrugEntryDetail.Name = 'MaterialPatientOwnDrugEntryDetail';
        this.MaterialPatientOwnDrugEntryDetail.Width = 700;
        this.MaterialPatientOwnDrugEntryDetail.ReadOnly = false;

        this.SendAmountPatientOwnDrugEntryDetail = new TTVisual.TTTextBoxColumn();
        this.SendAmountPatientOwnDrugEntryDetail.DataMember = 'SendAmount';
        this.SendAmountPatientOwnDrugEntryDetail.DisplayIndex = 1;
        this.SendAmountPatientOwnDrugEntryDetail.HeaderText = i18n("M14895", "Gönderilen Miktar");
        this.SendAmountPatientOwnDrugEntryDetail.Name = 'SendAmountPatientOwnDrugEntryDetail';
        this.SendAmountPatientOwnDrugEntryDetail.ReadOnly = false;
        this.SendAmountPatientOwnDrugEntryDetail.Width = 100;

        this.AmountPatientOwnDrugEntryDetail = new TTVisual.TTTextBoxColumn();
        this.AmountPatientOwnDrugEntryDetail.DataMember = 'Amount';
        this.AmountPatientOwnDrugEntryDetail.DisplayIndex = 1;
        this.AmountPatientOwnDrugEntryDetail.HeaderText = i18n("M19030", "Miktar");
        this.AmountPatientOwnDrugEntryDetail.Name = 'AmountPatientOwnDrugEntryDetail';
        this.AmountPatientOwnDrugEntryDetail.Width = 200;

        this.BarcodeAmountPatientOwnDrugEntryDetail = new TTVisual.TTTextBoxColumn();
        this.BarcodeAmountPatientOwnDrugEntryDetail.DataMember = 'BarcodeAmount';
        this.BarcodeAmountPatientOwnDrugEntryDetail.DisplayIndex = 1;
        this.BarcodeAmountPatientOwnDrugEntryDetail.HeaderText = i18n("M19031", "BarkodMiktar");
        this.BarcodeAmountPatientOwnDrugEntryDetail.Name = 'BarcodeAmountPatientOwnDrugEntryDetail';
        this.BarcodeAmountPatientOwnDrugEntryDetail.Width = 200;

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
 
        this.PatientOwnDrugEntryDetailsColumns = [this.MaterialPatientOwnDrugEntryDetail, this.SendAmountPatientOwnDrugEntryDetail, this.AmountPatientOwnDrugEntryDetail,this.BarcodeAmountPatientOwnDrugEntryDetail, this.ExpirationDatePatientOwnDrugEntryDetail];
        this.Controls = [this.PatientOwnDrugEntryDetails, this.MaterialPatientOwnDrugEntryDetail, this.SendAmountPatientOwnDrugEntryDetail, this.ExpirationDatePatientOwnDrugEntryDetail,
        this.AmountPatientOwnDrugEntryDetail,this.BarcodeAmountPatientOwnDrugEntryDetail, this.labelID, this.ID, this.labelActionDate, this.ActionDate];

    }


}
