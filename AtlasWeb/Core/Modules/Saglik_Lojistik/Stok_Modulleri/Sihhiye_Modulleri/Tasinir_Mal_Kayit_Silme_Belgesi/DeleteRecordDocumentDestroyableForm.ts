//$0A2B7F22
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { DeleteRecordDocumentDestroyableFormViewModel } from './DeleteRecordDocumentDestroyableFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseDeleteRecordDocumentDestroyableForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Kayit_Silme_Belgesi/BaseDeleteRecordDocumentDestroyableForm";
import { DeleteRecordDocumentDestroyable } from 'NebulaClient/Model/AtlasClientModel';
import { DeleteRecordDocumentDestroyableMaterialOut } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspection } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspectionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';

import { StockActionService, StockActionInspection_Output } from "ObjectClassService/StockActionService";
import { InspectionUserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
@Component({
    selector: 'DeleteRecordDocumentDestroyableForm',
    templateUrl: './DeleteRecordDocumentDestroyableForm.html',
    providers: [MessageService]
})
export class DeleteRecordDocumentDestroyableForm extends BaseDeleteRecordDocumentDestroyableForm implements OnInit {
    public StockActionInspectionDetailsStockActionInspectionDetailColumns = [];
   // public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public deleteRecordDocumentDestroyableFormViewModel: DeleteRecordDocumentDestroyableFormViewModel = new DeleteRecordDocumentDestroyableFormViewModel();
    public get _DeleteRecordDocumentDestroyable(): DeleteRecordDocumentDestroyable {
        return this._TTObject as DeleteRecordDocumentDestroyable;
    }
    private DeleteRecordDocumentDestroyableForm_DocumentUrl: string = '/api/DeleteRecordDocumentDestroyableService/DeleteRecordDocumentDestroyableForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private changeDetectorRef: ChangeDetectorRef,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DeleteRecordDocumentDestroyableForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async BarcodeRead(value: string): Promise<void> {
        super.BarcodeRead(value);
        /* let material: Material = null;
        let materials: Array<any> = this._DeleteRecordDocumentDestroyable.ObjectContext.QueryObjects('MATERIAL', 'BARCODE='' + value  + ''');
        if (materials.length === 0)
            TTVisual.InfoBox.Show(value + ' UBB/Barkodlu malzeme bulunamadı.', MessageIconEnum.ErrorMessage);
        else if (materials.length === 1)
            material = <Material>materials[0];
        else {
            let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let m of materials) {
                multiSelectForm.AddMSItem(m.Name, m.Name, m);
            }
            let key: string = multiSelectForm.GetMSItem(ParentForm, 'Malzeme seçin');
            if (String.isNullOrEmpty(key))
                TTVisual.InfoBox.Show('Herhangibir malzeme seçilmedi.', MessageIconEnum.ErrorMessage);
            else material = multiSelectForm.MSSelectedItemObject as Material;
        }
        if (material !== null) {
            //Miktar girişi
            let retAmount: string = TTVisual.InputForm.GetText('Miktar Bilgisini Giriniz.');
            let amount: Currency = 0;
            if (String.isNullOrEmpty(retAmount) === false) {
                if (CurrencyType.TryConvertFrom(retAmount, false, amount) === false)
                    throw new TTException((await SystemMessageService.GetMessageV3(1192, [retAmount.toString()])));
            }
            let returningDocument: DeleteRecordDocumentDestroyableMaterialOut = this._DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableOutMaterials.AddNew();
            returningDocument.Material = material;
            returningDocument.Amount = amount;
        }*/
    }

    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async PreScript() {
        await super.PreScript();

        if (this._DeleteRecordDocumentDestroyable.Store == null) {
            this._DeleteRecordDocumentDestroyable.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }
        //if (this._DeleteRecordDocumentDestroyable.CurrentStateDefID.toString() === DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableStates.New.id)
        if (this._DeleteRecordDocumentDestroyable.Store != null)
            this.Material.ListFilterExpression = "STOCKS.STORE= '" + this._DeleteRecordDocumentDestroyable.Store.ObjectID + "'  AND STOCKS.INHELD > 0 AND STOCKS.MATERIAL.OBJECTDEFID <> 'f38f2111-0ee4-4b9f-9707-a63ac02d29f4'"; //FixedAssetDefinition

        this._DeleteRecordDocumentDestroyable.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckKullanilmazHaleGelmeYokOlma;
        this._DeleteRecordDocumentDestroyable.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
        if (this._DeleteRecordDocumentDestroyable.StockActionInspection == null) {
            this.deleteRecordDocumentDestroyableFormViewModel.StockActionInspections = new Array<StockActionInspection>();
            let enumArray: Array<InspectionUserTypeEnum> = new Array<InspectionUserTypeEnum>();
            enumArray.push(InspectionUserTypeEnum.Baskan);
            enumArray.push(InspectionUserTypeEnum.Uye);
            enumArray.push(InspectionUserTypeEnum.TeknikUye);
            enumArray.push(InspectionUserTypeEnum.TeknikUye);
            let output: StockActionInspection_Output = await StockActionService.StockActionInspectionTS(enumArray);
            this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection = output.stockActionInspection;
            this.deleteRecordDocumentDestroyableFormViewModel.StockActionInspections.push(output.stockActionInspection);
            this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionDate = output.stockActionInspection.InspectionDate;
            this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection.ReportNumberNotSeq = output.stockActionInspection.ReportNumberNotSeq;
            for (let det of output.stockActionInspectionDets) {
                this.deleteRecordDocumentDestroyableFormViewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList.push(det);
            }
            this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection.StockActionInspectionDetails = output.stockActionInspectionDets;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DeleteRecordDocumentDestroyable();
        this.deleteRecordDocumentDestroyableFormViewModel = new DeleteRecordDocumentDestroyableFormViewModel();
        this._ViewModel = this.deleteRecordDocumentDestroyableFormViewModel;
        this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable = this._TTObject as DeleteRecordDocumentDestroyable;
        this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableOutMaterials = new Array<DeleteRecordDocumentDestroyableMaterialOut>();
        this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.Store = new Store();
        this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection = new StockActionInspection();
        this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection.StockActionInspectionDetails = new Array<StockActionInspectionDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.deleteRecordDocumentDestroyableFormViewModel = this._ViewModel as DeleteRecordDocumentDestroyableFormViewModel;
        that._TTObject = this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable;
        if (this.deleteRecordDocumentDestroyableFormViewModel == null)
            this.deleteRecordDocumentDestroyableFormViewModel = new DeleteRecordDocumentDestroyableFormViewModel();
        if (this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable == null)
            this.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable = new DeleteRecordDocumentDestroyable();
        that.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableOutMaterials = that.deleteRecordDocumentDestroyableFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.deleteRecordDocumentDestroyableFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.deleteRecordDocumentDestroyableFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.deleteRecordDocumentDestroyableFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.deleteRecordDocumentDestroyableFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.deleteRecordDocumentDestroyableFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionSignDetails = that.deleteRecordDocumentDestroyableFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.deleteRecordDocumentDestroyableFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.deleteRecordDocumentDestroyableFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                 if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        let storeObjectID = that.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.deleteRecordDocumentDestroyableFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.Store = store;
            }
        }
        let stockActionInspectionObjectID = that.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable["StockActionInspection"];
        if (stockActionInspectionObjectID != null && (typeof stockActionInspectionObjectID === 'string')) {
            let stockActionInspection = that.deleteRecordDocumentDestroyableFormViewModel.StockActionInspections.find(o => o.ObjectID.toString() === stockActionInspectionObjectID.toString());
             if (stockActionInspection) {
                that.deleteRecordDocumentDestroyableFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection = stockActionInspection;
            }
            if (stockActionInspection != null) {
                stockActionInspection.StockActionInspectionDetails = that.deleteRecordDocumentDestroyableFormViewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList;
                for (let detailItem of that.deleteRecordDocumentDestroyableFormViewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList) {
                    let inspectionUserObjectID = detailItem["InspectionUser"];
                    if (inspectionUserObjectID != null && (typeof inspectionUserObjectID === 'string')) {
                        let inspectionUser = that.deleteRecordDocumentDestroyableFormViewModel.ResUsers.find(o => o.ObjectID.toString() === inspectionUserObjectID.toString());
                         if (inspectionUser) {
                            detailItem.InspectionUser = inspectionUser;
                        }
                    }
                }
            }
        }
        //that._ViewModel._DeleteRecordDocumentDestroyable.StockActionInspection = <StockActionInspection>{ InspectionDate: new Date() };
    }


    async ngOnInit()  {
        let that = this;
        await this.load(DeleteRecordDocumentDestroyableFormViewModel);
        this.FormCaption = "Kayıt Silme Belgesi Yok Edilen ( Yeni )";
        this.changeDetectorRef.detectChanges();

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.Description != event) {
                this._DeleteRecordDocumentDestroyable.Description = event;
            }
        }
    }

    public onInspectionDateChanged(event: any) {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null &&
                this._DeleteRecordDocumentDestroyable.StockActionInspection != null && this._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionDate != event) {
                this._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionDate = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.MKYS_CikisIslemTuru != event) {
                this._DeleteRecordDocumentDestroyable.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.MKYS_CikisStokHareketTuru != event) {
                this._DeleteRecordDocumentDestroyable.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.MKYS_TeslimAlan != event) {
                this._DeleteRecordDocumentDestroyable.MKYS_TeslimAlan = event;
            }
            if (this._DeleteRecordDocumentDestroyable.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.MKYS_TeslimEden != event) {
                this._DeleteRecordDocumentDestroyable.MKYS_TeslimEden = event;
            }
            if (this._DeleteRecordDocumentDestroyable.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
        }
    }

    public onReportNOChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null &&
                this._DeleteRecordDocumentDestroyable.StockActionInspection != null && this._DeleteRecordDocumentDestroyable.StockActionInspection.ReportNumberNotSeq != event) {
                this._DeleteRecordDocumentDestroyable.StockActionInspection.ReportNumberNotSeq = event;
            }
        }
    }

    public onReturningDocumentNumberChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.ReturningDocumentNumber != event) {
                this._DeleteRecordDocumentDestroyable.ReturningDocumentNumber = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.StockActionID != event) {
                this._DeleteRecordDocumentDestroyable.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.Store != event) {
                this._DeleteRecordDocumentDestroyable.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.TransactionDate != event) {
                this._DeleteRecordDocumentDestroyable.TransactionDate = event;
            }
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.TechnicalReport != event) {
                this._DeleteRecordDocumentDestroyable.TechnicalReport = event;
            }
        }
    }

    public onttrichtextboxcontrol2Changed(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null &&
                this._DeleteRecordDocumentDestroyable.StockActionInspection != null && this._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionReport != event) {
                this._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionReport = event;
            }
        }
    }

     //<this.StockActionOutDetail gridde kullanılıyordu dx-gride çevrilince kullanılmıyore çevrildi

    DeleteRecordDocumentDestroyableOutMaterials_CellValueChangedEmitted(data: any) {
        if (data && this.StockActionOutDetails && data.Row && data.Column) {
            this.DeleteRecordDocumentDestroyableOutMaterials_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }


    public async DeleteRecordDocumentDestroyableOutMaterials_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.DeleteRecordDocumentDestroyable_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: any) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
    }

    onSelectionChange(data: any) {
    }
       //this.StockActionOutDetail gridde kullanılıyordu >

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.ReturningDocumentNumber, "Text", this.__ttObject, "ReturningDocumentNumber");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "TechnicalReport");
        redirectProperty(this.ttrichtextboxcontrol2, "Rtf", this.__ttObject, "StockActionInspection.InspectionReport");
        redirectProperty(this.InspectionDate, "Value", this.__ttObject, "StockActionInspection.InspectionDate");
        redirectProperty(this.ReportNO, "Text", this.__ttObject, "StockActionInspection.ReportNumberNotSeq");
    }

    public initFormControls(): void {
        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 4;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.MaterialTabPage = new TTVisual.TTTabPage();
        this.MaterialTabPage.DisplayIndex = 0;
        this.MaterialTabPage.BackColor = "#FFFFFF";
        this.MaterialTabPage.TabIndex = 0;
        this.MaterialTabPage.Text = "Taşınır Malın";
        this.MaterialTabPage.Name = "MaterialTabPage";

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 39;

        //StockActionOutDetailsColumns da
        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.Required = true;
        this.StockActionOutDetails.BackColor = "#FFE3C6";
        this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionOutDetails.Name = "StockActionOutDetails";
        this.StockActionOutDetails.TabIndex = 0;
        this.StockActionOutDetails.Height = 350;


        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 37;

        //StockActionOutDetailsColumns da
        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.ReturningDocumentNumber = new TTVisual.TTTextBox();
        this.ReturningDocumentNumber.BackColor = "#F0F0F0";
        this.ReturningDocumentNumber.ReadOnly = true;
        this.ReturningDocumentNumber.Name = "ReturningDocumentNumber";
        this.ReturningDocumentNumber.TabIndex = 5;


        //StockActionOutDetailsColumns da seçilebilir olacak
        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 400;
        this.Material.ReadOnly = this.ReadOnly;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        //StockActionOutDetailsColumns da
        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod/UBB";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;
        this.StockActionSignDetails.Visible = false;

        //StockActionOutDetailsColumns da
        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 150;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.Width = 120;

        //StockActionOutDetailsColumns da
        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 300;

        //StockActionOutDetailsColumns da
        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.Format = "N2";
        this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Amount.DisplayIndex = 5;
        this.Amount.HeaderText = i18n("M19036", "Miktarı");
        this.Amount.Name = "Amount";
        this.Amount.Width = 120;
        this.Amount.IsNumeric = true;

        this.FreeTextSignUser = new TTVisual.TTTextBoxColumn();
        this.FreeTextSignUser.DataMember = "NameString";
        this.FreeTextSignUser.DisplayIndex = 2;
        this.FreeTextSignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.FreeTextSignUser.Name = "FreeTextSignUser";
        this.FreeTextSignUser.Width = 200;

        //StockActionOutDetailsColumns da
        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.Format = "#,###.#########";
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11860", "Birim Fiyatı");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Visible = false;
        this.UnitPrice.Width = 120;
        this.UnitPrice.IsNumeric = true;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 3;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        //StockActionOutDetailsColumns da
        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.Format = "#,###.#########";
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 7;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Visible = false;
        this.Price.Width = 120;
        this.Price.IsNumeric = true;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 40;

        //StockActionOutDetailsColumns da
        this.Startdate = new TTVisual.TTDateTimePickerColumn();
        this.Startdate.Format = DateTimePickerFormat.Short;
        this.Startdate.DataMember = "StartDate";
        this.Startdate.DisplayIndex = 8;
        this.Startdate.HeaderText = i18n("M11637", "Başlangıç Tarihi");
        this.Startdate.Name = "Startdate";
        this.Startdate.Width = 125;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 38;

        //StockActionOutDetailsColumns da
        this.ttenumcomboboxcolumn1 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn1.DataTypeName = "AuthorityClassStatusEnum";
        this.ttenumcomboboxcolumn1.DataMember = "AuthorityClass";
        this.ttenumcomboboxcolumn1.DisplayIndex = 9;
        this.ttenumcomboboxcolumn1.HeaderText = i18n("M24649", "Yetki Sembolü");
        this.ttenumcomboboxcolumn1.Name = "ttenumcomboboxcolumn1";
        this.ttenumcomboboxcolumn1.Width = 100;
        this.ttenumcomboboxcolumn1.Visible = false;

        this.labelMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisStokHareketTuru.Text = i18n("M12364", "Çıkış  Hareket Türü");
        this.labelMKYS_CikisStokHareketTuru.Name = "labelMKYS_CikisStokHareketTuru";
        this.labelMKYS_CikisStokHareketTuru.TabIndex = 36;

        //StockActionOutDetailsColumns da seçilebilir olacak
        this.DeleteRecordReason = new TTVisual.TTEnumComboBoxColumn();
        this.DeleteRecordReason.DataTypeName = "DeleteRecordReasonEnum";
        this.DeleteRecordReason.DataMember = "DeleteRecordReason";
        this.DeleteRecordReason.DisplayIndex = 10;
        this.DeleteRecordReason.HeaderText = i18n("M17417", "Kayıt Silme Nedeni");
        this.DeleteRecordReason.Name = "DeleteRecordReason";
        this.DeleteRecordReason.Width = 100;
        this.DeleteRecordReason.ReadOnly = this.ReadOnly;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 35;
        this.MKYS_CikisStokHareketTuru.ReadOnly = true;
        this.MKYS_CikisStokHareketTuru.Enabled = false;

        //StockActionOutDetailsColumns da  Seçilebilir olacak
        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 11;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 100;
        this.StockLevelType.ReadOnly = this.ReadOnly;

        this.labelMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisIslemTuru.Text = i18n("M12381", "Çıkış Türü");
        this.labelMKYS_CikisIslemTuru.Name = "labelMKYS_CikisIslemTuru";
        this.labelMKYS_CikisIslemTuru.TabIndex = 34;

        //StockActionOutDetailsColumns da
        this.Opinions = new TTVisual.TTTextBoxColumn();
        this.Opinions.DataMember = "Opinions";
        this.Opinions.DisplayIndex = 12;
        this.Opinions.HeaderText = i18n("M10483", "Açıklamalar");
        this.Opinions.Name = "Opinions";
        this.Opinions.Width = 200;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 33;
        this.MKYS_CikisIslemTuru.ReadOnly = true;
        this.MKYS_CikisIslemTuru.Enabled = false;

        //StockActionOutDetailsColumns da
        this.DestroyLocation = new TTVisual.TTTextBoxColumn();
        this.DestroyLocation.DataMember = "DestroyLocation";
        this.DestroyLocation.DisplayIndex = 13;
        this.DestroyLocation.HeaderText = i18n("M19442", "Nerede Yok Edildiği");
        this.DestroyLocation.Name = "DestroyLocation";
        this.DestroyLocation.Width = 180;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16901", "İşlem Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 32;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 31;

        this.labelReturningDocumentNumber = new TTVisual.TTLabel();
        this.labelReturningDocumentNumber.Text = i18n("M10651", "Aktarılan Belge Numarası");
        this.labelReturningDocumentNumber.Name = "labelReturningDocumentNumber";
        this.labelReturningDocumentNumber.TabIndex = 30;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.CustomFormat = "";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = "#DCDCDC";
        this.labelStockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockActionID.ForeColor = "#000000";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 5;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = "#DCDCDC";
        this.labelTransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTransactionDate.ForeColor = "#000000";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 9;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 6;

        this.TechnicalReportTabpage = new TTVisual.TTTabPage();
        this.TechnicalReportTabpage.DisplayIndex = 0;
        this.TechnicalReportTabpage.TabIndex = 2;
        this.TechnicalReportTabpage.Text = i18n("M23096", "Teknik Rapor");
        this.TechnicalReportTabpage.Name = "TechnicalReportTabpage";

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 7;

        this.InspectionTabpage = new TTVisual.TTTabPage();
        this.InspectionTabpage.DisplayIndex = 1;
        this.InspectionTabpage.TabIndex = 3;
        this.InspectionTabpage.Text = i18n("M19196", "Muayene Komisyonu");
        this.InspectionTabpage.Name = "InspectionTabpage";

        this.StockActionInspectionDetailsStockActionInspectionDetail = new TTVisual.TTGrid();
        this.StockActionInspectionDetailsStockActionInspectionDetail.Name = "StockActionInspectionDetailsStockActionInspectionDetail";
        this.StockActionInspectionDetailsStockActionInspectionDetail.TabIndex = 33;
        this.StockActionInspectionDetailsStockActionInspectionDetail.Height = 200;

        this.InspectionUserTypeStockActionInspectionDetail = new TTVisual.TTEnumComboBoxColumn();
        this.InspectionUserTypeStockActionInspectionDetail.DataTypeName = "InspectionUserTypeEnum";
        this.InspectionUserTypeStockActionInspectionDetail.DataMember = "InspectionUserType";
        this.InspectionUserTypeStockActionInspectionDetail.Required = true;
        this.InspectionUserTypeStockActionInspectionDetail.DisplayIndex = 0;
        this.InspectionUserTypeStockActionInspectionDetail.HeaderText = "Görevi";
        this.InspectionUserTypeStockActionInspectionDetail.Name = "InspectionUserTypeStockActionInspectionDetail";
        this.InspectionUserTypeStockActionInspectionDetail.Width = 100;

        this.InspectionUserStockActionInspectionDetail = new TTVisual.TTListBoxColumn();
        this.InspectionUserStockActionInspectionDetail.ListDefName = "UserListDefinition";
        this.InspectionUserStockActionInspectionDetail.DataMember = "InspectionUser";
        this.InspectionUserStockActionInspectionDetail.DisplayIndex = 1;
        this.InspectionUserStockActionInspectionDetail.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.InspectionUserStockActionInspectionDetail.Name = "InspectionUserStockActionInspectionDetail";
        this.InspectionUserStockActionInspectionDetail.Width = 300;

        this.NameStringStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.NameStringStockActionInspectionDetail.DataMember = "NameString";
        this.NameStringStockActionInspectionDetail.Required = true;
        this.NameStringStockActionInspectionDetail.DisplayIndex = 2;
        this.NameStringStockActionInspectionDetail.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.NameStringStockActionInspectionDetail.Name = "NameStringStockActionInspectionDetail";
        this.NameStringStockActionInspectionDetail.Width = 200;

        this.ShortMilitaryClassStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.ShortMilitaryClassStockActionInspectionDetail.DataMember = "ShortMilitaryClass";
        this.ShortMilitaryClassStockActionInspectionDetail.DisplayIndex = 3;
        this.ShortMilitaryClassStockActionInspectionDetail.HeaderText = i18n("M21810", "Sınıf Kısaltması");
        this.ShortMilitaryClassStockActionInspectionDetail.Name = "ShortMilitaryClassStockActionInspectionDetail";
        this.ShortMilitaryClassStockActionInspectionDetail.Width = 80;
        this.ShortMilitaryClassStockActionInspectionDetail.Visible = false;

        this.ShortRankStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.ShortRankStockActionInspectionDetail.DataMember = "ShortRank";
        this.ShortRankStockActionInspectionDetail.DisplayIndex = 4;
        this.ShortRankStockActionInspectionDetail.HeaderText = i18n("M21078", "Rütbe Kısaltması");
        this.ShortRankStockActionInspectionDetail.Name = "ShortRankStockActionInspectionDetail";
        this.ShortRankStockActionInspectionDetail.Width = 80;
        this.ShortRankStockActionInspectionDetail.Visible = false;

        this.EmploymentRecordIDStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.EmploymentRecordIDStockActionInspectionDetail.DataMember = "EmploymentRecordID";
        this.EmploymentRecordIDStockActionInspectionDetail.DisplayIndex = 5;
        this.EmploymentRecordIDStockActionInspectionDetail.HeaderText = i18n("M21831", "Sicil No");
        this.EmploymentRecordIDStockActionInspectionDetail.Name = "EmploymentRecordIDStockActionInspectionDetail";
        this.EmploymentRecordIDStockActionInspectionDetail.Width = 80;
        this.EmploymentRecordIDStockActionInspectionDetail.Visible = false;

        this.ttrichtextboxcontrol2 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol2.DisplayText = i18n("M19212", "Muayene Raporu");
        this.ttrichtextboxcontrol2.TemplateGroupName = i18n("M22331", "Stok İşlemleri Muayene Raporları");
        this.ttrichtextboxcontrol2.Name = "ttrichtextboxcontrol2";
        this.ttrichtextboxcontrol2.TabIndex = 2;

        this.labelInspectionDate = new TTVisual.TTLabel();
        this.labelInspectionDate.Text = i18n("M19222", "Muayene Tarihi");
        this.labelInspectionDate.BackColor = "#DCDCDC";
        this.labelInspectionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelInspectionDate.ForeColor = "#000000";
        this.labelInspectionDate.Name = "labelInspectionDate";
        this.labelInspectionDate.TabIndex = 11;

        this.ReportNO = new TTVisual.TTTextBox();
        this.ReportNO.Name = "ReportNO";
        this.ReportNO.TabIndex = 1;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M20824", "Rapor Numarası");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 11;

        this.InspectionDate = new TTVisual.TTDateTimePicker();
        this.InspectionDate.CustomFormat = "";
        this.InspectionDate.Format = DateTimePickerFormat.Short;
        this.InspectionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InspectionDate.Name = "InspectionDate";
        this.InspectionDate.TabIndex = 0;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M10469", "Açıklama");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 16;

       // this.StockActionOutDetailsColumns = [this.Detail, this.Material, this.Barcode, this.DistributionType, this.StoreStock, this.Amount, this.UnitPrice, this.Price, this.Startdate, this.ttenumcomboboxcolumn1, this.DeleteRecordReason, this.StockLevelType, this.Opinions, this.DestroyLocation];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.FreeTextSignUser, this.IsDeputy];
        this.StockActionInspectionDetailsStockActionInspectionDetailColumns = [this.InspectionUserTypeStockActionInspectionDetail, this.InspectionUserStockActionInspectionDetail, this.NameStringStockActionInspectionDetail, this.ShortMilitaryClassStockActionInspectionDetail, this.ShortRankStockActionInspectionDetail, this.EmploymentRecordIDStockActionInspectionDetail];
        this.tttabcontrol2.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.StockActionOutDetails];
        this.DescriptionAndSignTabControl.Controls = [this.TechnicalReportTabpage, this.InspectionTabpage];
        this.TechnicalReportTabpage.Controls = [this.ttrichtextboxcontrol1];
        this.InspectionTabpage.Controls = [this.StockActionInspectionDetailsStockActionInspectionDetail, this.ttrichtextboxcontrol2, this.labelInspectionDate, this.ReportNO, this.ttlabel1, this.InspectionDate];
        this.Controls = [this.tttabcontrol2, this.Description, this.MaterialTabPage, this.MKYS_TeslimEden, this.StockActionOutDetails, this.MKYS_TeslimAlan, this.Detail, this.ReturningDocumentNumber, this.Material, this.StockActionID, this.Barcode, this.StockActionSignDetails, this.DistributionType, this.SignUserType, this.StoreStock, this.SignUser, this.Amount, this.FreeTextSignUser, this.UnitPrice, this.IsDeputy, this.Price, this.labelMKYS_TeslimEden, this.Startdate, this.labelMKYS_TeslimAlan, this.ttenumcomboboxcolumn1, this.labelMKYS_CikisStokHareketTuru, this.DeleteRecordReason, this.MKYS_CikisStokHareketTuru, this.StockLevelType, this.labelMKYS_CikisIslemTuru, this.Opinions, this.MKYS_CikisIslemTuru, this.DestroyLocation, this.labelStore, this.Store, this.labelReturningDocumentNumber, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate, this.DescriptionAndSignTabControl, this.TechnicalReportTabpage, this.ttrichtextboxcontrol1, this.InspectionTabpage, this.StockActionInspectionDetailsStockActionInspectionDetail, this.InspectionUserTypeStockActionInspectionDetail, this.InspectionUserStockActionInspectionDetail, this.NameStringStockActionInspectionDetail, this.ShortMilitaryClassStockActionInspectionDetail, this.ShortRankStockActionInspectionDetail, this.EmploymentRecordIDStockActionInspectionDetail, this.ttrichtextboxcontrol2, this.labelInspectionDate, this.ReportNO, this.ttlabel1, this.InspectionDate, this.TTTeslimEdenButon, this.TTTeslimAlanButon, this.ttlabel6];

    }


}
