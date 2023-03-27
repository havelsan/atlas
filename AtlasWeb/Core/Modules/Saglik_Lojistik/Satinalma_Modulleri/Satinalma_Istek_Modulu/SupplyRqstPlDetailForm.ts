//$374A51CA
import { Component, OnInit, NgZone } from '@angular/core';
import { SupplyRqstPlDetailFormViewModel } from './SupplyRqstPlDetailFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

import { City } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { SupplyRqstPlDetStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SupplyRequestDetailService, ExcessStocks_Output, MKYSExcessStockItem_Input, HospitalExcessStockItem_Input, StockCardInfo_Input, StockCardInfo_Output } from 'NebulaClient/Services/ObjectService/SupplyRequestDetailService';
@Component({
    selector: 'SupplyRqstPlDetailForm',
    templateUrl: './SupplyRqstPlDetailForm.html',
    providers: [MessageService]
})
export class SupplyRqstPlDetailForm extends TTVisual.TTForm implements OnInit {
    BaseMaterialGroupSupplyRequestDetail: TTVisual.ITTListBoxColumn;
    DetailDescriptionSupplyRequestDetail: TTVisual.ITTTextBoxColumn;
    DistributionTypeSupplyRequestDetail: TTVisual.ITTTextBoxColumn;
    IsImmediateMat: TTVisual.ITTCheckBoxColumn;
    MaterialSupplyRequestDetail: TTVisual.ITTListBoxColumn;
    PurchaseAmountSupplyRequestDetail: TTVisual.ITTTextBoxColumn;
    RequestAmountSupplyRequestDetail: TTVisual.ITTTextBoxColumn;
    RequestedStore: TTVisual.ITTListBoxColumn;
    SupplyRequestDetails: TTVisual.ITTGrid;
    SupplyRequestStatusSupplyRequestDetail: TTVisual.ITTEnumComboBoxColumn;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttMaterialName: TTVisual.ITTTextBox;
    ttTotalRequestAmount: TTVisual.ITTTextBox;
    ttAmount: TTVisual.ITTTextBox;
    ttPurchaseAmount: TTVisual.ITTTextBox;
    ttExcessAmount: TTVisual.ITTTextBox;
    ttDistributionType: TTVisual.ITTTextBox;
    CityListBox: TTVisual.ITTObjectListBox;
    birimTextBox: TTVisual.ITTTextBox;
    adeti: TTVisual.ITTTextBoxColumn;
    birimAdi: TTVisual.ITTTextBoxColumn;
    btnExcessQuery: TTVisual.ITTButton;
    btnMkysExcessQuery: TTVisual.ITTButton;
    ihtiyacFazlasiItemsGrid: TTVisual.ITTGrid;
    ilAdi: TTVisual.ITTTextBoxColumn;
    ilKodu: TTVisual.ITTTextBoxColumn;
    malzemeAdi: TTVisual.ITTTextBoxColumn;
    malzemeDigerAciklama: TTVisual.ITTTextBoxColumn;
    malzemeKodu: TTVisual.ITTTextBoxColumn;
    siraNo: TTVisual.ITTTextBoxColumn;
    tarih: TTVisual.ITTDateTimePickerColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    vergiliBirimFiyat: TTVisual.ITTTextBoxColumn;
    public ihtiyacFazlasiItemsGridColumns = [];

    public loadIndicatorVisible: boolean = false;

    public MaterialName: string;
    public MaterialCode: string;
    public DistributionTypeName: string;
    public BarcodeName: string;
    public stockCardObjectID: string;
    public dataSoruce: Array<any>;
    //public dataSourceStore: ExcessStockItemForStore[];
    //public dataSourceMkys: ExcessStockItem[];

    public SupplyRequestDetailsColumns = [];
    public supplyRqstPlDetailFormViewModel: SupplyRqstPlDetailFormViewModel = new SupplyRqstPlDetailFormViewModel();
    public get _SupplyRequestPoolDetail(): SupplyRequestPoolDetail {
        return this._TTObject as SupplyRequestPoolDetail;
    }
    private SupplyRqstPlDetailForm_DocumentUrl: string = '/api/SupplyRequestPoolDetailService/SupplyRqstPlDetailForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private modalStateService: ModalStateService,
                private objectContextService: ObjectContextService,
                protected ngZone: NgZone) {
        super('SUPPLYREQUESTPOOLDETAIL', 'SupplyRqstPlDetailForm');
        this._DocumentServiceUrl = this.SupplyRqstPlDetailForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public async btnHospitalExcessQuery_Click(): Promise<void> {

        this.loadIndicatorVisible = true;

        let inputDvo: HospitalExcessStockItem_Input = new HospitalExcessStockItem_Input();
        if (this._SupplyRequestPoolDetail.Material != null)
            inputDvo.malzemeObjectID = this._SupplyRequestPoolDetail.Material.toString();

        let queryOutput: ExcessStocks_Output = await SupplyRequestDetailService.GetHospitalExcessStocks(inputDvo);
        if (queryOutput != null && queryOutput.excessStockStoreList != null) {
            if (queryOutput.excessStockStoreList.length > 0) {
                this.dataSoruce = queryOutput.excessStockStoreList;
            }
        }


        this.loadIndicatorVisible = false;

    }

    public async btnMkysExcessQuery_Click(): Promise<void> {

        let inputDvo: MKYSExcessStockItem_Input = new MKYSExcessStockItem_Input();
        inputDvo.birimAdi = this.birimTextBox.Text;
        if (this.CityListBox.SelectedObject != undefined) {
            inputDvo.ilAdi = (<City>this.CityListBox.SelectedObject).Name;
        }
        inputDvo.malzemeAdi = this.MaterialName;
        inputDvo.malzemeKodu = this.MaterialCode;
        let mkysOutput: ExcessStocks_Output = await SupplyRequestDetailService.GetMKYSExcessStocks(inputDvo);
        if (mkysOutput != null && mkysOutput.excessStockStoreList != null) {
            if (mkysOutput.excessStockList.length > 0) {
                this.dataSoruce = mkysOutput.excessStockList;
            }
        }
    }

    public setInputParam(value: Object) {
        this.ObjectID = new Guid(value.toString());
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    //protected async save() {
    //    await super.save();
    //    this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._SupplyRequestPoolDetail);
    //}

    //protected cancel() {
    //    this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    //}

    protected async save() {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._SupplyRequestPoolDetail);
    }
    public cancel() {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }


    public initViewModel(): void {
        this._TTObject = new SupplyRequestPoolDetail();
        this.supplyRqstPlDetailFormViewModel = new SupplyRqstPlDetailFormViewModel();
        this._ViewModel = this.supplyRqstPlDetailFormViewModel;
        this.supplyRqstPlDetailFormViewModel._SupplyRequestPoolDetail = this._TTObject as SupplyRequestPoolDetail;
        this.supplyRqstPlDetailFormViewModel._SupplyRequestPoolDetail.SupplyRequestDetails = new Array<SupplyRequestDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.supplyRqstPlDetailFormViewModel = this._ViewModel as SupplyRqstPlDetailFormViewModel;
        that._TTObject = this.supplyRqstPlDetailFormViewModel._SupplyRequestPoolDetail;
        if (this.supplyRqstPlDetailFormViewModel == null)
            this.supplyRqstPlDetailFormViewModel = new SupplyRqstPlDetailFormViewModel();
        if (this.supplyRqstPlDetailFormViewModel._SupplyRequestPoolDetail == null)
            this.supplyRqstPlDetailFormViewModel._SupplyRequestPoolDetail = new SupplyRequestPoolDetail();
        that.supplyRqstPlDetailFormViewModel._SupplyRequestPoolDetail.SupplyRequestDetails = that.supplyRqstPlDetailFormViewModel.SupplyRequestDetailsGridList;
        for (let detailItem of that.supplyRqstPlDetailFormViewModel.SupplyRequestDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.supplyRqstPlDetailFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                this.MaterialName = material.Name;
                this.DistributionTypeName = material.DistributionTypeName;
                this.BarcodeName = material.Barcode;
                //this.stockCardObjectID = material.StockCard.toString();
                //if (this.stockCardObjectID != null) {
                //    let stockCard = that.supplyRqstPlDetailFormViewModel.StockCards.find(o => o.ObjectID.toString() === this.stockCardObjectID);
                //    this.MaterialCode = stockCard.NATOStockNO;
                //}
            }
            let purchaseGroupObjectID = detailItem["PurchaseGroup"];
            if (purchaseGroupObjectID != null && (typeof purchaseGroupObjectID === 'string')) {
                let purchaseGroup = that.supplyRqstPlDetailFormViewModel.PurchaseGroups.find(o => o.ObjectID.toString() === purchaseGroupObjectID.toString());
                 if (purchaseGroup) {
                    detailItem.PurchaseGroup = purchaseGroup;
                }
            }
            let distributionTypeObjectID = detailItem["DistributionType"];
            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                let distributionType = that.supplyRqstPlDetailFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                 if (distributionType) {
                    detailItem.DistributionType = distributionType;
                }
                //this.DistributionTypeName = distributionType.DistributionType;
                //this.DistributionTypeName = mate
            }
            let supplyRequestObjectID = detailItem["SupplyRequest"];
            if (supplyRequestObjectID != null && (typeof supplyRequestObjectID === 'string')) {
                let supplyRequest = that.supplyRqstPlDetailFormViewModel.SupplyRequests.find(o => o.ObjectID.toString() === supplyRequestObjectID.toString());
                 if (supplyRequest) {
                    detailItem.SupplyRequest = supplyRequest;
                }
                if (supplyRequest != null) {
                    let storeObjectID = supplyRequest["Store"];
                    if (storeObjectID != null && (typeof storeObjectID === 'string')) {
                        let store = that.supplyRqstPlDetailFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                         if (store) {
                            supplyRequest.Store = store;
                        }
                    }
                }
            }
        }
    }

    onExcessAmount()
    {
        let det: SupplyRequestPoolDetail = this._SupplyRequestPoolDetail;
        if (det.ExcessAmount !== null || det.ExcessAmount.toString() !== "") {
            det.PurchaseAmount = this.tempAmount;
            det.PurchaseAmount = det.Amount - det.ExcessAmount;
            if (det.PurchaseAmount <= 0) {
                det.PurchaseAmount = 0;
                det.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.SupplyWithExcess;
            }
        }
        else {
            det.PurchaseAmount = det.Amount;
            det.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.ToBeSent;
        }
    }
    public tempAmount;
    async ngOnInit()  {
        let that = this;
        await this.load(SupplyRqstPlDetailFormViewModel);
        this.FormCaption = i18n("M21370", "Satınalma Talep Havuz Detay");
        if (that._SupplyRequestPoolDetail != undefined) {
            if (that._SupplyRequestPoolDetail.Material != undefined) {

                let inputForStockCard: StockCardInfo_Input = new StockCardInfo_Input();
                inputForStockCard.MaterialID = this._SupplyRequestPoolDetail.Material.toString();
                let outputForStockCard: StockCardInfo_Output = await SupplyRequestDetailService.GetStockCardInfoByMaterial(inputForStockCard);
                this.MaterialCode = outputForStockCard.NatoStockNo;

            }
        }
        let det: SupplyRequestPoolDetail = this._SupplyRequestPoolDetail;
        this.tempAmount = det.PurchaseAmount;
  
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {



        this.birimTextBox = new TTVisual.TTTextBox();
        this.birimTextBox.Name = "birimTextBox";
        this.birimTextBox.TabIndex = 4;

        this.CityListBox = new TTVisual.TTObjectListBox();
        this.CityListBox.ListDefName = "CityNameList";
        this.CityListBox.Name = "CityListBox";
        this.CityListBox.TabIndex = 9;

        this.ihtiyacFazlasiItemsGrid = new TTVisual.TTGrid();
        this.ihtiyacFazlasiItemsGrid.Name = "ihtiyacFazlasiItemsGrid";
        this.ihtiyacFazlasiItemsGrid.TabIndex = 8;

        this.siraNo = new TTVisual.TTTextBoxColumn();
        this.siraNo.DisplayIndex = 0;
        this.siraNo.HeaderText = i18n("M21815", "Sıra No");
        this.siraNo.Name = "siraNo";
        this.siraNo.ReadOnly = true;
        this.siraNo.Width = 100;

        this.malzemeKodu = new TTVisual.TTTextBoxColumn();
        this.malzemeKodu.DisplayIndex = 1;
        this.malzemeKodu.HeaderText = i18n("M18587", "Malzeme Kodu");
        this.malzemeKodu.Name = "malzemeKodu";
        this.malzemeKodu.ReadOnly = true;
        this.malzemeKodu.Width = 100;

        this.malzemeAdi = new TTVisual.TTTextBoxColumn();
        this.malzemeAdi.DisplayIndex = 2;
        this.malzemeAdi.HeaderText = i18n("M18550", "Malzeme Adı");
        this.malzemeAdi.Name = "malzemeAdi";
        this.malzemeAdi.ReadOnly = true;
        this.malzemeAdi.Width = 100;

        this.malzemeDigerAciklama = new TTVisual.TTTextBoxColumn();
        this.malzemeDigerAciklama.DisplayIndex = 3;
        this.malzemeDigerAciklama.HeaderText = i18n("M18565", "Malzeme Diğer Açıklama");
        this.malzemeDigerAciklama.Name = "malzemeDigerAciklama";
        this.malzemeDigerAciklama.ReadOnly = true;
        this.malzemeDigerAciklama.Width = 100;

        this.adeti = new TTVisual.TTTextBoxColumn();
        this.adeti.DisplayIndex = 4;
        this.adeti.HeaderText = i18n("M10513", "Adeti");
        this.adeti.Name = "adeti";
        this.adeti.ReadOnly = true;
        this.adeti.Width = 100;

        this.vergiliBirimFiyat = new TTVisual.TTTextBoxColumn();
        this.vergiliBirimFiyat.DisplayIndex = 5;
        this.vergiliBirimFiyat.HeaderText = i18n("M24092", "Vergili Birim Fiyatı");
        this.vergiliBirimFiyat.Name = "vergiliBirimFiyat";
        this.vergiliBirimFiyat.ReadOnly = true;
        this.vergiliBirimFiyat.Width = 100;

        this.tarih = new TTVisual.TTDateTimePickerColumn();
        this.tarih.DisplayIndex = 6;
        this.tarih.HeaderText = "Tarih";
        this.tarih.Name = "tarih";
        this.tarih.ReadOnly = true;
        this.tarih.Width = 100;

        this.ilAdi = new TTVisual.TTTextBoxColumn();
        this.ilAdi.DisplayIndex = 7;
        this.ilAdi.HeaderText = i18n("M16270", "İl Adı");
        this.ilAdi.Name = "ilAdi";
        this.ilAdi.ReadOnly = true;
        this.ilAdi.Width = 100;

        this.ilKodu = new TTVisual.TTTextBoxColumn();
        this.ilKodu.DisplayIndex = 8;
        this.ilKodu.HeaderText = "İl Kodu";
        this.ilKodu.Name = "ilKodu";
        this.ilKodu.ReadOnly = true;
        this.ilKodu.Width = 100;

        this.birimAdi = new TTVisual.TTTextBoxColumn();
        this.birimAdi.DisplayIndex = 9;
        this.birimAdi.HeaderText = i18n("M11851", "Birim Adı");
        this.birimAdi.Name = "birimAdi";
        this.birimAdi.ReadOnly = true;
        this.birimAdi.Width = 100;

        this.btnExcessQuery = new TTVisual.TTButton();
        this.btnExcessQuery.Text = i18n("M15408", "XXXXXX'de Sorgula");
        this.btnExcessQuery.Name = "btnExcessQuery";
        this.btnExcessQuery.TabIndex = 7;

        this.btnMkysExcessQuery = new TTVisual.TTButton();
        this.btnMkysExcessQuery.Text = "MKYS'de Sorgula";
        this.btnMkysExcessQuery.Name = "btnMkysExcessQuery";


        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M22468", "Şehir Adı");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 3;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M18587", "Malzeme Kodu");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 2;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M11851", "Birim Adı");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 1;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M18550", "Malzeme Adı");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 0;

        this.ihtiyacFazlasiItemsGridColumns = [this.siraNo, this.malzemeKodu, this.malzemeAdi, this.malzemeDigerAciklama, this.adeti, this.vergiliBirimFiyat, this.tarih, this.ilAdi, this.ilKodu, this.birimAdi];

        this.ttMaterialName = new TTVisual.TTTextBox();
        this.ttMaterialName.BackColor = "#F0F0F0";
        this.ttMaterialName.ReadOnly = true;
        this.ttMaterialName.Name = "MaterialName";
        this.ttMaterialName.TabIndex = 2;

        this.ttTotalRequestAmount = new TTVisual.TTTextBox();
        this.ttTotalRequestAmount.BackColor = "#e5e5e5";
        this.ttTotalRequestAmount.ReadOnly = true;
        this.ttTotalRequestAmount.Name = "TotalRequestAmount";
        this.ttTotalRequestAmount.TabIndex = 2;
        this.ttTotalRequestAmount.Enabled = false;

        this.ttAmount = new TTVisual.TTTextBox();
        this.ttAmount.BackColor = "#e5e5e5";
        this.ttAmount.ReadOnly = true;
        this.ttAmount.Name = "Amount";
        this.ttAmount.TabIndex = 2;
        this.ttAmount.Enabled = false;

        this.ttPurchaseAmount = new TTVisual.TTTextBox();
        this.ttPurchaseAmount.BackColor = "#F0F0F0";
        this.ttPurchaseAmount.ReadOnly = false;
        this.ttPurchaseAmount.Name = "PurchaseAmount";
        this.ttPurchaseAmount.TabIndex = 2;

        this.ttExcessAmount = new TTVisual.TTTextBox();
        this.ttExcessAmount.BackColor = "#F0F0F0";
        this.ttExcessAmount.ReadOnly = false;
        this.ttExcessAmount.Name = "ExcessAmount";
        this.ttExcessAmount.TabIndex = 2;

        this.ttDistributionType = new TTVisual.TTTextBox();
        this.ttDistributionType.BackColor = "#F0F0F0";
        this.ttDistributionType.ReadOnly = false;
        this.ttDistributionType.Name = "DistributionType";
        this.ttDistributionType.TabIndex = 2;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M16616", "İstek Detayları");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.SupplyRequestDetails = new TTVisual.TTGrid();
        this.SupplyRequestDetails.Name = "SupplyRequestDetails";
        this.SupplyRequestDetails.TabIndex = 0;
        this.SupplyRequestDetails.Height = 280;
        this.SupplyRequestDetails.AllowUserToAddRows = false;
        this.SupplyRequestDetails.AllowUserToDeleteRows = false;

        this.MaterialSupplyRequestDetail = new TTVisual.TTListBoxColumn();
        this.MaterialSupplyRequestDetail.ListDefName = "MaterialListDefinition";
        this.MaterialSupplyRequestDetail.DataMember = "Material";
        this.MaterialSupplyRequestDetail.DisplayIndex = 0;
        this.MaterialSupplyRequestDetail.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialSupplyRequestDetail.Name = "MaterialSupplyRequestDetail";
        this.MaterialSupplyRequestDetail.ReadOnly = true;
        this.MaterialSupplyRequestDetail.Width = 100;
        this.MaterialSupplyRequestDetail.Visible = false;

        this.BaseMaterialGroupSupplyRequestDetail = new TTVisual.TTListBoxColumn();
        this.BaseMaterialGroupSupplyRequestDetail.ListDefName = "PurchaseGroupList";
        this.BaseMaterialGroupSupplyRequestDetail.DataMember = "PurchaseGroup";
        this.BaseMaterialGroupSupplyRequestDetail.DisplayIndex = 91;
        this.BaseMaterialGroupSupplyRequestDetail.HeaderText = i18n("M16627", "İstek Kalemi");
        this.BaseMaterialGroupSupplyRequestDetail.Name = "BaseMaterialGroupSupplyRequestDetail";
        this.BaseMaterialGroupSupplyRequestDetail.ReadOnly = true;
        this.BaseMaterialGroupSupplyRequestDetail.Visible = false;
        this.BaseMaterialGroupSupplyRequestDetail.Width = 300;

        this.DistributionTypeSupplyRequestDetail = new TTVisual.TTTextBoxColumn();
       // this.DistributionTypeSupplyRequestDetail.ListDefName = "DistributionTypeList";
        this.DistributionTypeSupplyRequestDetail.DataMember = "Material.DistributionTypeName";
        this.DistributionTypeSupplyRequestDetail.DisplayIndex = 92;
        this.DistributionTypeSupplyRequestDetail.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionTypeSupplyRequestDetail.Name = "DistributionTypeSupplyRequestDetail";
        this.DistributionTypeSupplyRequestDetail.ReadOnly = true;
        this.DistributionTypeSupplyRequestDetail.Width = 120;
        this.DistributionTypeSupplyRequestDetail.Visible = false;

        this.RequestAmountSupplyRequestDetail = new TTVisual.TTTextBoxColumn();
        this.RequestAmountSupplyRequestDetail.DataMember = "RequestAmount";
        this.RequestAmountSupplyRequestDetail.DisplayIndex = 2;
        this.RequestAmountSupplyRequestDetail.HeaderText = i18n("M16632", "İstek Miktarı");
        this.RequestAmountSupplyRequestDetail.Name = "RequestAmountSupplyRequestDetail";
        this.RequestAmountSupplyRequestDetail.ReadOnly = true;
        this.RequestAmountSupplyRequestDetail.Width = 120;
        this.RequestAmountSupplyRequestDetail.IsNumeric = true;

        this.PurchaseAmountSupplyRequestDetail = new TTVisual.TTTextBoxColumn();
        this.PurchaseAmountSupplyRequestDetail.DataMember = "PurchaseAmount";
        this.PurchaseAmountSupplyRequestDetail.DisplayIndex = 3;
        this.PurchaseAmountSupplyRequestDetail.HeaderText = i18n("M21358", "Satınalma Miktarı");
        this.PurchaseAmountSupplyRequestDetail.Name = "PurchaseAmountSupplyRequestDetail";
        this.PurchaseAmountSupplyRequestDetail.ReadOnly = true;
        this.PurchaseAmountSupplyRequestDetail.Width = 140;
        this.PurchaseAmountSupplyRequestDetail.IsNumeric = true;

        this.DetailDescriptionSupplyRequestDetail = new TTVisual.TTTextBoxColumn();
        this.DetailDescriptionSupplyRequestDetail.DataMember = "DetailDescription";
        this.DetailDescriptionSupplyRequestDetail.DisplayIndex = 5;
        this.DetailDescriptionSupplyRequestDetail.HeaderText = i18n("M10469", "Açıklama");
        this.DetailDescriptionSupplyRequestDetail.Name = "DetailDescriptionSupplyRequestDetail";
        this.DetailDescriptionSupplyRequestDetail.ReadOnly = true;
        this.DetailDescriptionSupplyRequestDetail.Width = 300;

        this.SupplyRequestStatusSupplyRequestDetail = new TTVisual.TTEnumComboBoxColumn();
        this.SupplyRequestStatusSupplyRequestDetail.DataTypeName = "SupplyRequestStatusEnum";
        this.SupplyRequestStatusSupplyRequestDetail.DataMember = "SupplyRequestStatus";
        this.SupplyRequestStatusSupplyRequestDetail.DisplayIndex = 6;
        this.SupplyRequestStatusSupplyRequestDetail.HeaderText = i18n("M22962", "Tedarik Talep Durumu");
        this.SupplyRequestStatusSupplyRequestDetail.Name = "SupplyRequestStatusSupplyRequestDetail";
        this.SupplyRequestStatusSupplyRequestDetail.ReadOnly = true;
        this.SupplyRequestStatusSupplyRequestDetail.Width = 180;

        this.RequestedStore = new TTVisual.TTListBoxColumn();
        this.RequestedStore.ListDefName = "StoresList";
        this.RequestedStore.DataMember = "SupplyRequest.Store";
        this.RequestedStore.DisplayIndex = 7;
        this.RequestedStore.HeaderText = i18n("M16657", "İstek Yapan Birim");
        this.RequestedStore.Name = "RequestedStore";
        this.RequestedStore.ReadOnly = true;
        this.RequestedStore.Width = 400;

        this.IsImmediateMat = new TTVisual.TTCheckBoxColumn();
        this.IsImmediateMat.DataMember = "IsImmediateMat";
        this.IsImmediateMat.DisplayIndex = 4;
        this.IsImmediateMat.HeaderText = "Acil";
        this.IsImmediateMat.Name = "IsImmediateMat";
        this.IsImmediateMat.ReadOnly = true;
        this.IsImmediateMat.Width = 80;

        this.SupplyRequestDetailsColumns = [this.RequestedStore, this.RequestAmountSupplyRequestDetail, this.PurchaseAmountSupplyRequestDetail, this.IsImmediateMat, this.DetailDescriptionSupplyRequestDetail, this.SupplyRequestStatusSupplyRequestDetail];
        //this.SupplyRequestDetailsColumns = [this.MaterialSupplyRequestDetail, this.BaseMaterialGroupSupplyRequestDetail, this.DistributionTypeSupplyRequestDetail, this.RequestAmountSupplyRequestDetail, this.PurchaseAmountSupplyRequestDetail, this.DetailDescriptionSupplyRequestDetail, this.SupplyRequestStatusSupplyRequestDetail, this.RequestedStore, this.IsImmediateMat];
        this.ttgroupbox1.Controls = [this.SupplyRequestDetails];
        this.Controls = [this.birimTextBox, this.CityListBox, this.ihtiyacFazlasiItemsGrid, this.siraNo, this.malzemeKodu, this.malzemeAdi, this.malzemeDigerAciklama, this.adeti, this.vergiliBirimFiyat, this.tarih, this.ilAdi, this.ilKodu, this.birimAdi, this.btnExcessQuery, this.btnMkysExcessQuery, this.ttlabel4, this.ttlabel3, this.ttlabel2, this.ttlabel1,
        this.ttExcessAmount, this.ttPurchaseAmount, this.ttDistributionType, this.ttMaterialName, this.ttTotalRequestAmount, this.ttAmount, this.ttgroupbox1, this.SupplyRequestDetails, this.MaterialSupplyRequestDetail, this.BaseMaterialGroupSupplyRequestDetail, this.DistributionTypeSupplyRequestDetail, this.RequestAmountSupplyRequestDetail, this.PurchaseAmountSupplyRequestDetail, this.DetailDescriptionSupplyRequestDetail, this.SupplyRequestStatusSupplyRequestDetail, this.RequestedStore, this.IsImmediateMat];

        for (let control of this.Controls) {
            if (control.Name == this.ttAmount.Name || control.Name == this.ttTotalRequestAmount.Name) {
                this.ttTotalRequestAmount.ReadOnly = true;
                this.ttTotalRequestAmount.Enabled = false;
                this.ttAmount.ReadOnly = true;
                this.ttAmount.Enabled = false;
            }

        }

    }


}
