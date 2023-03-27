//$0E9699C3
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseStockActionDetailInFormViewModel } from "./BaseStockActionDetailInFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseStockActionDetailForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/BaseStockActionDetailForm";
import { FixedAssetInDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { QRCodeInDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailIn } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { HorizontalAlignment } from "NebulaClient/Utils/Enums/HorizontalAlignment";
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";



@Component({
    selector: 'BaseStockActionDetailInForm',
    templateUrl: './BaseStockActionDetailInForm.html',
    providers: [MessageService]
})
export class BaseStockActionDetailInForm extends BaseStockActionDetailForm implements OnInit, IModal {
    BarcodeMaterial: TTVisual.ITTTextBox;
    BarcodeQRCodeInDetail: TTVisual.ITTTextBoxColumn;
    BoxNoQRCodeInDetail: TTVisual.ITTTextBoxColumn;
    BunchNoQRCodeInDetail: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    ExpirationDate: TTVisual.ITTDateTimePicker;
    ExpireDateQRCodeInDetail: TTVisual.ITTDateTimePickerColumn;
    FixedAssetDetails: TTVisual.ITTGrid;
    FixedAssetNO: TTVisual.ITTTextBoxColumn;
    FixedAssetStatus: TTVisual.ITTEnumComboBoxColumn;
    FixedAssetTabPage: TTVisual.ITTTabPage;
    Frequency: TTVisual.ITTTextBoxColumn;
    FrequencyTemp: TTVisual.ITTTextBox;
    GuarantyEndDate: TTVisual.ITTDateTimePickerColumn;
    GuarantyEndDateTemp: TTVisual.ITTDateTimePicker;
    GuarantyStartDate: TTVisual.ITTDateTimePickerColumn;
    GuarantyStartDateTemp: TTVisual.ITTDateTimePicker;
    labelBarcodeMaterial: TTVisual.ITTLabel;
    labelExpirationDate: TTVisual.ITTLabel;
    labelLotNo: TTVisual.ITTLabel;
    labelQRCodeCount: TTVisual.ITTLabel;
    LotNo: TTVisual.ITTTextBox;
    LotNoQRCodeInDetail: TTVisual.ITTTextBoxColumn;
    Mark: TTVisual.ITTTextBoxColumn;
    MarkTemp: TTVisual.ITTTextBox;
    Model: TTVisual.ITTTextBoxColumn;
    ModelTemp: TTVisual.ITTTextBox;
    OrderNoQRCodeInDetail: TTVisual.ITTTextBoxColumn;
    PackageNoQRCodeInDetail: TTVisual.ITTTextBoxColumn;
    PalletNoQRCodeInDetail: TTVisual.ITTTextBoxColumn;
    Power: TTVisual.ITTTextBoxColumn;
    PowerTemp: TTVisual.ITTTextBox;
    ProductionDate: TTVisual.ITTDateTimePickerColumn;
    ProductionDateTemp: TTVisual.ITTDateTimePicker;
    QRCodeCountLabel: TTVisual.ITTLabel;
    QRCodeInDetails: TTVisual.ITTGrid;
    QRCodeTabPage: TTVisual.ITTTabPage;
    Resource: TTVisual.ITTListBoxColumn;
    SerialNumber: TTVisual.ITTTextBoxColumn;
    SmallBunchNoQRCodeInDetail: TTVisual.ITTTextBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    UpdateButton: TTVisual.ITTButton;
    Voltage: TTVisual.ITTTextBoxColumn;
    VoltageTemp: TTVisual.ITTTextBox;
    public FixedAssetDetailsColumns = [];
    public QRCodeInDetailsColumns = [];
    public baseStockActionDetailInFormViewModel: BaseStockActionDetailInFormViewModel = new BaseStockActionDetailInFormViewModel();
    public get _StockActionDetailIn(): StockActionDetailIn {
        return this._TTObject as StockActionDetailIn;
    }
    private BaseStockActionDetailInForm_DocumentUrl: string = '/api/StockActionDetailInService/BaseStockActionDetailInForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService
        , private modalStateService: ModalStateService
    , protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseStockActionDetailInForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    private _inputItem: any;
    public setInputParam(value: Object) {

        this._inputItem = Object.create(value);
        //this._inputItem = new StockActionDetailIn();
        this._inputItem = Object.assign(this._inputItem, value);
        this._TTObject = this._inputItem as StockActionDetailIn;
        this.baseStockActionDetailInFormViewModel._StockActionDetailIn = this._inputItem as StockActionDetailIn;
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public onSave(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._inputItem);
    }

    public onCancel(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    // ***** Method declarations start *****

    private async UpdateButton_Click(): Promise<void> {
        if (this.FixedAssetDetails.Rows.length > 0) {
            for (let row of this.FixedAssetDetails.Rows) {
                row.Cells["GuarantyStartDate"].Value = this.GuarantyStartDateTemp.NullableValue;
                row.Cells["GuarantyEndDate"].Value = this.GuarantyEndDateTemp.NullableValue;
                row.Cells["Mark"].Value = this.MarkTemp.Text;
                row.Cells["Model"].Value = this.ModelTemp.Text;
                row.Cells["ProductionDate"].Value = this.ProductionDateTemp.NullableValue;
                row.Cells["Power"].Value = this.PowerTemp.Text;
                row.Cells["Voltage"].Value = this.VoltageTemp.Text;
                row.Cells["Frequency"].Value = this.FrequencyTemp.Text;
            }
        }
    }
    protected async BarcodeRead(value: string): Promise<void> {
        super.BarcodeRead(value); /*
        if (this._StockActionDetailIn.Material.StockCard.StockMethod === StockMethodEnum.QRCodeUsed) {
            let addableBarcode: boolean = false;
            let addableLotNo: boolean = false;
            let addableExpDate: boolean = false;
            let addableOrderNo: boolean = true;
            let qrCode: Code2D = new Code2D(value);
            if (this._StockActionDetailIn.Material.Barcode.Equals(qrCode.Barcode.toString()))
                addableBarcode = true;
            else {
                TTVisual.InfoBox.Show("Okuttuğunuz karekod ile seçmiş olduğunuz malzeme aynı değil.", MessageIconEnum.ErrorMessage);
                return;
            }
            if (this._StockActionDetailIn.LotNo === null) {
                this._StockActionDetailIn.LotNo = qrCode.BatchNo;
                addableLotNo = true;
            }
            else {
                if (this._StockActionDetailIn.LotNo.Equals(qrCode.BatchNo))
                    addableLotNo = true;
                else {
                    TTVisual.InfoBox.Show("Okuttuğunuz karekod ile seçmiş olduğunuz malzemenin lotu aynı değil.", MessageIconEnum.ErrorMessage);
                    return;
                }
            }
            if (this._StockActionDetailIn.ExpirationDate === null) {
                this._StockActionDetailIn.ExpirationDate = qrCode.ExpirationDate;
                addableExpDate = true;
            }
            else {
                if (this._StockActionDetailIn.ExpirationDate.Equals(qrCode.ExpirationDate))
                    addableExpDate = true;
                else {
                    TTVisual.InfoBox.Show("Okuttuğunuz karekod ile seçmiş olduğunuz malzemenin son kullanma tarihi aynı değil.", MessageIconEnum.ErrorMessage);
                    return;
                }
            }
            for (let inDetail of this._StockActionDetailIn.QRCodeInDetails) {
                if (inDetail.OrderNo.Equals(qrCode.PackageCode)) {
                    addableOrderNo = false;
                    TTVisual.InfoBox.Show("Okutmuş olduğunuz karekodu daha öncede okutmuştunuz.", MessageIconEnum.ErrorMessage);
                    return;
                }
            }
            if (addableBarcode && addableLotNo && addableExpDate && addableOrderNo) {
                let qRCodeInDetail: QRCodeInDetail = this._StockActionDetailIn.QRCodeInDetails.AddNew();
                qRCodeInDetail.Barcode = qrCode.Barcode.toString();
                qRCodeInDetail.LotNo = qrCode.BatchNo;
                qRCodeInDetail.ExpireDate = qrCode.ExpirationDate;
                qRCodeInDetail.OrderNo = qrCode.PackageCode;
            }
        }*/
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    protected async PreScript() {
        super.PreScript();
        let objectStateDef: TTObjectStateDef = this._StockActionDetailIn.StockAction.CurrentStateDef;
        /*while (true) {
            if (objectStateDef.BaseStateDef === null)
                break;
            objectStateDef = objectStateDef.BaseStateDef;
            if (objectStateDef.ObjectDef.CodeName.Equals(typeof StockAction))
                break;
        }
        switch (this._StockActionDetail.Material.StockCard.StockMethod) {
            case StockMethodEnum.QRCodeUsed:
                this.tttabcontrol1.HideTabPage(this.FixedAssetTabPage);
                if (objectStateDef !== null && objectStateDef.StateDefID === StockAction.StockActionStates.New && this._StockActionDetailIn.QRCodeInDetails.length === 0) {
                    if (this._StockActionDetailIn.Material === null || this._StockActionDetailIn.Amount === 0)
                        throw new TTException("Karekod detayları girmeden önce Miktar girmeniz Malzeme seçmeniz gerekmektedir.\r\nMiktar : " + this._StockActionDetailIn.Amount);
                    let QRCodeAmount: number = 0;
                    if (this._StockActionDetailIn.Material.PackageAmount === null || this._StockActionDetailIn.Material.PackageAmount === 0)
                        QRCodeAmount = 1;
                    else QRCodeAmount = Math.Floor((<number>this._StockActionDetailIn.Amount) / (<number>this._StockActionDetailIn.Material.PackageAmount));
                    this.QRCodeCountLabel.Text = QRCodeAmount.toString();
                }
                break;
            case StockMethodEnum.SerialNumbered:
                this.tttabcontrol1.HideTabPage(this.QRCodeTabPage);
                if (this._StockActionDetailIn.Material instanceof FixedAssetDefinition) {
                    if (objectStateDef !== null && objectStateDef.StateDefID === StockAction.StockActionStates.New && this._StockActionDetailIn.FixedAssetInDetails.length === 0) {
                        if (this._StockActionDetailIn.Material === null || this._StockActionDetailIn.Amount === 0)
                            throw new TTException("Detayları girmeden önce Miktar girmeniz Malzeme seçmeniz gerekmektedir.\r\nMiktar : " + this._StockActionDetailIn.Amount);
                        for (let i: number = 0; i < this._StockActionDetailIn.Amount; i++) {
                            let fixedAssetInDetail: FixedAssetInDetail = new FixedAssetInDetail(this._StockActionDetailIn.ObjectContext);
                            fixedAssetInDetail.StockActionDetail = this._StockActionDetailIn;
                            fixedAssetInDetail.SetNewFixedAssetSerialNumber();
                            fixedAssetInDetail.FixedAssetMaterialDefDetail = new FixedAssetMaterialDefinitionDetail(this._StockActionDetailIn.ObjectContext);
                        }
                    }
                }
                break;
            case StockMethodEnum.ExpirationDated:
            case StockMethodEnum.LotUsed:
            case StockMethodEnum.StockNumbered:
                this.tttabcontrol1.TabPages["FixedAssetTabPage"].ReadOnly = true;
                this.tttabcontrol1.TabPages["QRCodeTabPage"].ReadOnly = true;
                break;
            default:
                throw new TTException("Tanımsız Stok Methodu");
        }*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new StockActionDetailIn();
        this.baseStockActionDetailInFormViewModel = new BaseStockActionDetailInFormViewModel();
        this._ViewModel = this.baseStockActionDetailInFormViewModel;
        this.baseStockActionDetailInFormViewModel._StockActionDetailIn = this._TTObject as StockActionDetailIn;
        this.baseStockActionDetailInFormViewModel._StockActionDetailIn.FixedAssetInDetails = new Array<FixedAssetInDetail>();
        this.baseStockActionDetailInFormViewModel._StockActionDetailIn.Material = new Material();
        this.baseStockActionDetailInFormViewModel._StockActionDetailIn.QRCodeInDetails = new Array<QRCodeInDetail>();
        this.baseStockActionDetailInFormViewModel._StockActionDetailIn.StockLevelType = new StockLevelType();
    }

    protected loadViewModel() {
        let that = this;
        that.baseStockActionDetailInFormViewModel = this._ViewModel as BaseStockActionDetailInFormViewModel;
        that._TTObject = this.baseStockActionDetailInFormViewModel._StockActionDetailIn;
        if (this.baseStockActionDetailInFormViewModel == null)
            this.baseStockActionDetailInFormViewModel = new BaseStockActionDetailInFormViewModel();
        if (this.baseStockActionDetailInFormViewModel._StockActionDetailIn == null)
            this.baseStockActionDetailInFormViewModel._StockActionDetailIn = new StockActionDetailIn();
        that.baseStockActionDetailInFormViewModel._StockActionDetailIn.FixedAssetInDetails = that.baseStockActionDetailInFormViewModel.FixedAssetDetailsGridList;
        for (let detailItem of that.baseStockActionDetailInFormViewModel.FixedAssetDetailsGridList) {
            let resourceObjectID = detailItem["Resource"];
            if (resourceObjectID != null && (typeof resourceObjectID === 'string')) {
                let resource = that.baseStockActionDetailInFormViewModel.Resources.find(o => o.ObjectID.toString() === resourceObjectID.toString());
                 if (resource) {
                    detailItem.Resource = resource;
                }
            }
        }
        let materialObjectID = that.baseStockActionDetailInFormViewModel._StockActionDetailIn["Material"];
        if (materialObjectID != null && (typeof materialObjectID === 'string')) {
            let material = that.baseStockActionDetailInFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
             if (material) {
                that.baseStockActionDetailInFormViewModel._StockActionDetailIn.Material = material;
            }
        }
        that.baseStockActionDetailInFormViewModel._StockActionDetailIn.QRCodeInDetails = that.baseStockActionDetailInFormViewModel.QRCodeInDetailsGridList;
        for (let detailItem of that.baseStockActionDetailInFormViewModel.QRCodeInDetailsGridList) {
        }
        let stockLevelTypeObjectID = that.baseStockActionDetailInFormViewModel._StockActionDetailIn["StockLevelType"];
        if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
            let stockLevelType = that.baseStockActionDetailInFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
             if (stockLevelType) {
                that.baseStockActionDetailInFormViewModel._StockActionDetailIn.StockLevelType = stockLevelType;
            }
        }
    }


    async ngOnInit() {
        if (this.isModal()) {

        } else {
            //  await this.load();
            console.log('Not Modal');
        }
    }

    public onAmountChanged(event): void {
        if (event != null) {
            if (this._StockActionDetailIn != null && this._StockActionDetailIn.Amount != event) {
                this._StockActionDetailIn.Amount = event;
            }
        }
    }

    public onBarcodeMaterialChanged(event): void {
        if (event != null) {
            if (this._StockActionDetailIn != null &&
                this._StockActionDetailIn.Material != null && this._StockActionDetailIn.Material.Barcode != event) {
                this._StockActionDetailIn.Material.Barcode = event;
            }
        }
    }

    public onExpirationDateChanged(event): void {
        if (event != null) {
            if (this._StockActionDetailIn != null && this._StockActionDetailIn.ExpirationDate != event) {
                this._StockActionDetailIn.ExpirationDate = event;
            }
        }
    }

    public onLotNoChanged(event): void {
        if (event != null) {
            if (this._StockActionDetailIn != null && this._StockActionDetailIn.LotNo != event) {
                this._StockActionDetailIn.LotNo = event;
            }
        }
    }

    public onMaterialChanged(event): void {
        if (event != null) {
            if (this._StockActionDetailIn != null && this._StockActionDetailIn.Material != event) {
                this._StockActionDetailIn.Material = event;
            }
        }
    }

    public onStockLevelTypeChanged(event): void {
        if (event != null) {
            if (this._StockActionDetailIn != null && this._StockActionDetailIn.StockLevelType != event) {
                this._StockActionDetailIn.StockLevelType = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Amount, "Text", this.__ttObject, "Amount");
        redirectProperty(this.StockLevelType, "SelectedObject", this.__ttObject, "StockLevelType");
        redirectProperty(this.BarcodeMaterial, "Text", this.__ttObject, "Material.Barcode");
        redirectProperty(this.LotNo, "Text", this.__ttObject, "LotNo");
        redirectProperty(this.ExpirationDate, "Value", this.__ttObject, "ExpirationDate");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 13;

        this.StockLevelType = new TTVisual.TTListDefComboBox();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.BackColor = "#F0F0F0";
        this.StockLevelType.Enabled = false;
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.TabIndex = 11;

        this.FixedAssetTabPage = new TTVisual.TTTabPage();
        this.FixedAssetTabPage.DisplayIndex = 0;
        this.FixedAssetTabPage.TabIndex = 0;
        this.FixedAssetTabPage.Text = i18n("M12579", "Demirbaşlar");
        this.FixedAssetTabPage.Name = "FixedAssetTabPage";

        this.labelMaterial = new TTVisual.TTLabel();
        this.labelMaterial.Text = i18n("M18545", "Malzeme");
        this.labelMaterial.Name = "labelMaterial";
        this.labelMaterial.TabIndex = 9;

        this.FixedAssetDetails = new TTVisual.TTGrid();
        this.FixedAssetDetails.AllowUserToDeleteRows = false;
        this.FixedAssetDetails.AllowUserToOrderColumns = true;
        this.FixedAssetDetails.Name = "FixedAssetDetails";
        this.FixedAssetDetails.TabIndex = 12;

        this.Material = new TTVisual.TTObjectListBox();
        this.Material.ReadOnly = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.Name = "Material";
        this.Material.TabIndex = 8;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 0;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.Width = 200;

        this.labelAmount = new TTVisual.TTLabel();
        this.labelAmount.Text = i18n("M19030", "Miktar");
        this.labelAmount.Name = "labelAmount";
        this.labelAmount.TabIndex = 1;

        this.FixedAssetNO = new TTVisual.TTTextBoxColumn();
        this.FixedAssetNO.DataMember = "FixedAssetNO";
        this.FixedAssetNO.DisplayIndex = 1;
        this.FixedAssetNO.HeaderText = i18n("M12574", "Demirbaş Nu.");
        this.FixedAssetNO.Name = "FixedAssetNO";
        this.FixedAssetNO.Width = 150;

        this.Amount = new TTVisual.TTTextBox();
        this.Amount.Text = "0";
        this.Amount.TextAlign = HorizontalAlignment.Right;
        this.Amount.BackColor = "#F0F0F0";
        this.Amount.ReadOnly = true;
        this.Amount.Name = "Amount";
        this.Amount.TabIndex = 0;

        this.GuarantyStartDate = new TTVisual.TTDateTimePickerColumn();
        this.GuarantyStartDate.DataMember = "GuarantyStartDate";
        this.GuarantyStartDate.DisplayIndex = 2;
        this.GuarantyStartDate.HeaderText = i18n("M14509", "Garanti Başlama Tarihi");
        this.GuarantyStartDate.Name = "GuarantyStartDate";
        this.GuarantyStartDate.Width = 100;

        this.labelStockLevelType = new TTVisual.TTLabel();
        this.labelStockLevelType.Text = i18n("M18519", "Malın Durumu");
        this.labelStockLevelType.Name = "labelStockLevelType";
        this.labelStockLevelType.TabIndex = 3;

        this.GuarantyEndDate = new TTVisual.TTDateTimePickerColumn();
        this.GuarantyEndDate.DataMember = "GuarantyEndDate";
        this.GuarantyEndDate.DisplayIndex = 3;
        this.GuarantyEndDate.HeaderText = i18n("M14511", "Garanti Bitiş Tarihi");
        this.GuarantyEndDate.Name = "GuarantyEndDate";
        this.GuarantyEndDate.Width = 100;

        this.Mark = new TTVisual.TTTextBoxColumn();
        this.Mark.DataMember = "Mark";
        this.Mark.DisplayIndex = 4;
        this.Mark.HeaderText = i18n("M18671", "Marka");
        this.Mark.Name = "Mark";
        this.Mark.Width = 80;

        this.Model = new TTVisual.TTTextBoxColumn();
        this.Model.DataMember = "Model";
        this.Model.DisplayIndex = 5;
        this.Model.HeaderText = "Model";
        this.Model.Name = "Model";
        this.Model.Width = 80;

        this.SerialNumber = new TTVisual.TTTextBoxColumn();
        this.SerialNumber.DataMember = "SerialNumber";
        this.SerialNumber.DisplayIndex = 6;
        this.SerialNumber.HeaderText = i18n("M21638", "Seri Nu.");
        this.SerialNumber.Name = "SerialNumber";
        this.SerialNumber.Width = 80;

        this.ProductionDate = new TTVisual.TTDateTimePickerColumn();
        this.ProductionDate.DataMember = "ProductionDate";
        this.ProductionDate.DisplayIndex = 7;
        this.ProductionDate.HeaderText = i18n("M16465", "İmal Tarihi");
        this.ProductionDate.Name = "ProductionDate";
        this.ProductionDate.Width = 100;

        this.Power = new TTVisual.TTTextBoxColumn();
        this.Power.DataMember = "Power";
        this.Power.DisplayIndex = 8;
        this.Power.HeaderText = i18n("M14995", "Güç");
        this.Power.Name = "Power";
        this.Power.Width = 100;

        this.Voltage = new TTVisual.TTTextBoxColumn();
        this.Voltage.DataMember = "Voltage";
        this.Voltage.DisplayIndex = 9;
        this.Voltage.HeaderText = i18n("M24180", "Voltaj");
        this.Voltage.Name = "Voltage";
        this.Voltage.Width = 100;

        this.Frequency = new TTVisual.TTTextBoxColumn();
        this.Frequency.DataMember = "Frequency";
        this.Frequency.DisplayIndex = 10;
        this.Frequency.HeaderText = i18n("M14480", "Frekans");
        this.Frequency.Name = "Frequency";
        this.Frequency.Width = 100;

        this.Resource = new TTVisual.TTListBoxColumn();
        this.Resource.ListDefName = "ResourceListDefinition";
        this.Resource.DataMember = "Resource";
        this.Resource.Required = true;
        this.Resource.DisplayIndex = 11;
        this.Resource.HeaderText = i18n("M12127", "Bulunduğu Kaynak");
        this.Resource.Name = "Resource";
        this.Resource.Width = 200;

        this.FixedAssetStatus = new TTVisual.TTEnumComboBoxColumn();
        this.FixedAssetStatus.DataTypeName = "FixedAssetStatusEnum";
        this.FixedAssetStatus.DataMember = "Status";
        this.FixedAssetStatus.Required = true;
        this.FixedAssetStatus.DisplayIndex = 12;
        this.FixedAssetStatus.HeaderText = "Durum";
        this.FixedAssetStatus.Name = "FixedAssetStatus";
        this.FixedAssetStatus.ReadOnly = true;
        this.FixedAssetStatus.Width = 80;

        this.MarkTemp = new TTVisual.TTTextBox();
        this.MarkTemp.Name = "MarkTemp";
        this.MarkTemp.TabIndex = 15;
        this.MarkTemp.Visible = false;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M14480", "Frekans");
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 9;
        this.ttlabel8.Visible = false;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M24180", "Voltaj");
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 9;
        this.ttlabel7.Visible = false;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M14995", "Güç");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 9;
        this.ttlabel6.Visible = false;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M16465", "İmal Tarihi");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 9;
        this.ttlabel5.Visible = false;

        this.UpdateButton = new TTVisual.TTButton();
        this.UpdateButton.Text = i18n("M15005", "Güncelle");
        this.UpdateButton.Name = "UpdateButton";
        this.UpdateButton.TabIndex = 16;
        this.UpdateButton.Visible = false;

        this.ProductionDateTemp = new TTVisual.TTDateTimePicker();
        this.ProductionDateTemp.Format = DateTimePickerFormat.Short;
        this.ProductionDateTemp.Name = "ProductionDateTemp";
        this.ProductionDateTemp.TabIndex = 14;
        this.ProductionDateTemp.Visible = false;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Model";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 9;
        this.ttlabel4.Visible = false;

        this.GuarantyStartDateTemp = new TTVisual.TTDateTimePicker();
        this.GuarantyStartDateTemp.Format = DateTimePickerFormat.Short;
        this.GuarantyStartDateTemp.Name = "GuarantyStartDateTemp";
        this.GuarantyStartDateTemp.TabIndex = 14;
        this.GuarantyStartDateTemp.Visible = false;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M18671", "Marka");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 9;
        this.ttlabel3.Visible = false;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M14511", "Garanti Bitiş Tarihi");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 9;
        this.ttlabel2.Visible = false;

        this.ModelTemp = new TTVisual.TTTextBox();
        this.ModelTemp.Name = "ModelTemp";
        this.ModelTemp.TabIndex = 15;
        this.ModelTemp.Visible = false;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M14509", "Garanti Başlama Tarihi");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 9;
        this.ttlabel1.Visible = false;

        this.PowerTemp = new TTVisual.TTTextBox();
        this.PowerTemp.Name = "PowerTemp";
        this.PowerTemp.TabIndex = 15;
        this.PowerTemp.Visible = false;

        this.GuarantyEndDateTemp = new TTVisual.TTDateTimePicker();
        this.GuarantyEndDateTemp.Format = DateTimePickerFormat.Short;
        this.GuarantyEndDateTemp.Name = "GuarantyEndDateTemp";
        this.GuarantyEndDateTemp.TabIndex = 14;
        this.GuarantyEndDateTemp.Visible = false;

        this.VoltageTemp = new TTVisual.TTTextBox();
        this.VoltageTemp.Name = "VoltageTemp";
        this.VoltageTemp.TabIndex = 15;
        this.VoltageTemp.Visible = false;

        this.FrequencyTemp = new TTVisual.TTTextBox();
        this.FrequencyTemp.Name = "FrequencyTemp";
        this.FrequencyTemp.TabIndex = 15;
        this.FrequencyTemp.Visible = false;

        this.QRCodeTabPage = new TTVisual.TTTabPage();
        this.QRCodeTabPage.DisplayIndex = 1;
        this.QRCodeTabPage.TabIndex = 1;
        this.QRCodeTabPage.Text = i18n("M17298", "KareKod Detayları");
        this.QRCodeTabPage.Name = "QRCodeTabPage";

        this.labelExpirationDate = new TTVisual.TTLabel();
        this.labelExpirationDate.Text = i18n("M22057", "Son Kullanma Tarihi");
        this.labelExpirationDate.Name = "labelExpirationDate";
        this.labelExpirationDate.TabIndex = 15;

        this.labelLotNo = new TTVisual.TTLabel();
        this.labelLotNo.Text = i18n("M18356", "Lot Nu.");
        this.labelLotNo.Name = "labelLotNo";
        this.labelLotNo.TabIndex = 17;

        this.ExpirationDate = new TTVisual.TTDateTimePicker();
        this.ExpirationDate.BackColor = "#F0F0F0";
        this.ExpirationDate.CustomFormat = "MM/yyyy";
        this.ExpirationDate.Format = DateTimePickerFormat.Custom;
        this.ExpirationDate.Enabled = false;
        this.ExpirationDate.Name = "ExpirationDate";
        this.ExpirationDate.TabIndex = 14;

        this.labelBarcodeMaterial = new TTVisual.TTLabel();
        this.labelBarcodeMaterial.Text = "Barkod";
        this.labelBarcodeMaterial.Name = "labelBarcodeMaterial";
        this.labelBarcodeMaterial.TabIndex = 19;

        this.LotNo = new TTVisual.TTTextBox();
        this.LotNo.BackColor = "#F0F0F0";
        this.LotNo.ReadOnly = true;
        this.LotNo.Name = "LotNo";
        this.LotNo.TabIndex = 16;

        this.QRCodeCountLabel = new TTVisual.TTLabel();
        this.QRCodeCountLabel.Text = "0";
        this.QRCodeCountLabel.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.QRCodeCountLabel.ForeColor = "#FF0000";
        this.QRCodeCountLabel.Name = "QRCodeCountLabel";
        this.QRCodeCountLabel.TabIndex = 1;

        this.BarcodeMaterial = new TTVisual.TTTextBox();
        this.BarcodeMaterial.BackColor = "#F0F0F0";
        this.BarcodeMaterial.ReadOnly = true;
        this.BarcodeMaterial.Name = "BarcodeMaterial";
        this.BarcodeMaterial.TabIndex = 18;

        this.labelQRCodeCount = new TTVisual.TTLabel();
        this.labelQRCodeCount.Text = i18n("M14793", "Girilmesi Gereken Karekod Sayısı");
        this.labelQRCodeCount.Name = "labelQRCodeCount";
        this.labelQRCodeCount.TabIndex = 15;

        this.QRCodeInDetails = new TTVisual.TTGrid();
        this.QRCodeInDetails.AllowUserToDeleteRows = false;
        this.QRCodeInDetails.Name = "QRCodeInDetails";
        this.QRCodeInDetails.TabIndex = 17;

        this.BarcodeQRCodeInDetail = new TTVisual.TTTextBoxColumn();
        this.BarcodeQRCodeInDetail.DataMember = "Barcode";
        this.BarcodeQRCodeInDetail.Required = true;
        this.BarcodeQRCodeInDetail.DisplayIndex = 0;
        this.BarcodeQRCodeInDetail.HeaderText = "Barkod";
        this.BarcodeQRCodeInDetail.Name = "BarcodeQRCodeInDetail";
        this.BarcodeQRCodeInDetail.Width = 100;

        this.LotNoQRCodeInDetail = new TTVisual.TTTextBoxColumn();
        this.LotNoQRCodeInDetail.DataMember = "LotNo";
        this.LotNoQRCodeInDetail.Required = true;
        this.LotNoQRCodeInDetail.DisplayIndex = 1;
        this.LotNoQRCodeInDetail.HeaderText = i18n("M18356", "Lot Nu.");
        this.LotNoQRCodeInDetail.Name = "LotNoQRCodeInDetail";
        this.LotNoQRCodeInDetail.Width = 100;

        this.ExpireDateQRCodeInDetail = new TTVisual.TTDateTimePickerColumn();
        this.ExpireDateQRCodeInDetail.Format = DateTimePickerFormat.Custom;
        this.ExpireDateQRCodeInDetail.CustomFormat = "MM/yyyy";
        this.ExpireDateQRCodeInDetail.DataMember = "ExpireDate";
        this.ExpireDateQRCodeInDetail.Required = true;
        this.ExpireDateQRCodeInDetail.DisplayIndex = 2;
        this.ExpireDateQRCodeInDetail.HeaderText = "S.K.Tarihi";
        this.ExpireDateQRCodeInDetail.Name = "ExpireDateQRCodeInDetail";
        this.ExpireDateQRCodeInDetail.Width = 100;

        this.OrderNoQRCodeInDetail = new TTVisual.TTTextBoxColumn();
        this.OrderNoQRCodeInDetail.DataMember = "OrderNo";
        this.OrderNoQRCodeInDetail.Required = true;
        this.OrderNoQRCodeInDetail.DisplayIndex = 3;
        this.OrderNoQRCodeInDetail.HeaderText = i18n("M21816", "Sıra Nu.");
        this.OrderNoQRCodeInDetail.Name = "OrderNoQRCodeInDetail";
        this.OrderNoQRCodeInDetail.Width = 100;

        this.PalletNoQRCodeInDetail = new TTVisual.TTTextBoxColumn();
        this.PalletNoQRCodeInDetail.DataMember = "PalletNo";
        this.PalletNoQRCodeInDetail.DisplayIndex = 4;
        this.PalletNoQRCodeInDetail.HeaderText = i18n("M20180", "Palet Nu.");
        this.PalletNoQRCodeInDetail.Name = "PalletNoQRCodeInDetail";
        this.PalletNoQRCodeInDetail.Width = 80;

        this.PackageNoQRCodeInDetail = new TTVisual.TTTextBoxColumn();
        this.PackageNoQRCodeInDetail.DataMember = "PackageNo";
        this.PackageNoQRCodeInDetail.DisplayIndex = 5;
        this.PackageNoQRCodeInDetail.HeaderText = i18n("M17699", "Koli Nu.");
        this.PackageNoQRCodeInDetail.Name = "PackageNoQRCodeInDetail";
        this.PackageNoQRCodeInDetail.Width = 80;

        this.BunchNoQRCodeInDetail = new TTVisual.TTTextBoxColumn();
        this.BunchNoQRCodeInDetail.DataMember = "BunchNo";
        this.BunchNoQRCodeInDetail.DisplayIndex = 6;
        this.BunchNoQRCodeInDetail.HeaderText = "Bağ Nu.";
        this.BunchNoQRCodeInDetail.Name = "BunchNoQRCodeInDetail";
        this.BunchNoQRCodeInDetail.Width = 80;

        this.BoxNoQRCodeInDetail = new TTVisual.TTTextBoxColumn();
        this.BoxNoQRCodeInDetail.DataMember = "BoxNo";
        this.BoxNoQRCodeInDetail.DisplayIndex = 7;
        this.BoxNoQRCodeInDetail.HeaderText = i18n("M17698", "Koli İçi Kutu Nu.");
        this.BoxNoQRCodeInDetail.Name = "BoxNoQRCodeInDetail";
        this.BoxNoQRCodeInDetail.Width = 80;

        this.SmallBunchNoQRCodeInDetail = new TTVisual.TTTextBoxColumn();
        this.SmallBunchNoQRCodeInDetail.DataMember = "SmallBunchNo";
        this.SmallBunchNoQRCodeInDetail.DisplayIndex = 8;
        this.SmallBunchNoQRCodeInDetail.HeaderText = "Küçük Bağ Nu.";
        this.SmallBunchNoQRCodeInDetail.Name = "SmallBunchNoQRCodeInDetail";
        this.SmallBunchNoQRCodeInDetail.Width = 80;

        this.FixedAssetDetailsColumns = [this.Description, this.FixedAssetNO, this.GuarantyStartDate, this.GuarantyEndDate, this.Mark, this.Model, this.SerialNumber, this.ProductionDate, this.Power, this.Voltage, this.Frequency, this.Resource, this.FixedAssetStatus];
        this.QRCodeInDetailsColumns = [this.BarcodeQRCodeInDetail, this.LotNoQRCodeInDetail, this.ExpireDateQRCodeInDetail, this.OrderNoQRCodeInDetail, this.PalletNoQRCodeInDetail, this.PackageNoQRCodeInDetail, this.BunchNoQRCodeInDetail, this.BoxNoQRCodeInDetail, this.SmallBunchNoQRCodeInDetail];
        this.tttabcontrol1.Controls = [this.FixedAssetTabPage, this.QRCodeTabPage];
        this.FixedAssetTabPage.Controls = [this.FixedAssetDetails, this.MarkTemp, this.ttlabel8, this.ttlabel7, this.ttlabel6, this.ttlabel5, this.UpdateButton, this.ProductionDateTemp, this.ttlabel4, this.GuarantyStartDateTemp, this.ttlabel3, this.ttlabel2, this.ModelTemp, this.ttlabel1, this.PowerTemp, this.GuarantyEndDateTemp, this.VoltageTemp, this.FrequencyTemp];
        this.QRCodeTabPage.Controls = [this.labelExpirationDate, this.labelLotNo, this.ExpirationDate, this.labelBarcodeMaterial, this.LotNo, this.QRCodeCountLabel, this.BarcodeMaterial, this.labelQRCodeCount, this.QRCodeInDetails];
        this.Controls = [this.tttabcontrol1, this.StockLevelType, this.FixedAssetTabPage, this.labelMaterial, this.FixedAssetDetails, this.Material, this.Description, this.labelAmount, this.FixedAssetNO, this.Amount, this.GuarantyStartDate, this.labelStockLevelType, this.GuarantyEndDate, this.Mark, this.Model, this.SerialNumber, this.ProductionDate, this.Power, this.Voltage, this.Frequency, this.Resource, this.FixedAssetStatus, this.MarkTemp, this.ttlabel8, this.ttlabel7, this.ttlabel6, this.ttlabel5, this.UpdateButton, this.ProductionDateTemp, this.ttlabel4, this.GuarantyStartDateTemp, this.ttlabel3, this.ttlabel2, this.ModelTemp, this.ttlabel1, this.PowerTemp, this.GuarantyEndDateTemp, this.VoltageTemp, this.FrequencyTemp, this.QRCodeTabPage, this.labelExpirationDate, this.labelLotNo, this.ExpirationDate, this.labelBarcodeMaterial, this.LotNo, this.QRCodeCountLabel, this.BarcodeMaterial, this.labelQRCodeCount, this.QRCodeInDetails, this.BarcodeQRCodeInDetail, this.LotNoQRCodeInDetail, this.ExpireDateQRCodeInDetail, this.OrderNoQRCodeInDetail, this.PalletNoQRCodeInDetail, this.PackageNoQRCodeInDetail, this.BunchNoQRCodeInDetail, this.BoxNoQRCodeInDetail, this.SmallBunchNoQRCodeInDetail];

    }


}
