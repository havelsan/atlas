//$E0976F0A
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseStockActionDetailFormViewModel } from "./BaseStockActionDetailFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';

import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { HorizontalAlignment } from "NebulaClient/Utils/Enums/HorizontalAlignment";



@Component({
    selector: 'BaseStockActionDetailForm',
    templateUrl: './BaseStockActionDetailForm.html',
    providers: [MessageService]
})
export class BaseStockActionDetailForm extends TTVisual.TTForm implements OnInit {
    Amount: TTVisual.ITTTextBox;
    labelAmount: TTVisual.ITTLabel;
    labelMaterial: TTVisual.ITTLabel;
    labelStockLevelType: TTVisual.ITTLabel;
    Material: TTVisual.ITTObjectListBox;
    StockLevelType: TTVisual.ITTListDefComboBox;
    public baseStockActionDetailFormViewModel: BaseStockActionDetailFormViewModel = new BaseStockActionDetailFormViewModel();
    public get _StockActionDetail(): StockActionDetail {
        return this._TTObject as StockActionDetail;
    }
    private BaseStockActionDetailForm_DocumentUrl: string = '/api/StockActionDetailService/BaseStockActionDetailForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("STOCKACTIONDETAIL", "BaseStockActionDetailForm");
        this._DocumentServiceUrl = this.BaseStockActionDetailForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new StockActionDetail();
        this.baseStockActionDetailFormViewModel = new BaseStockActionDetailFormViewModel();
        this._ViewModel = this.baseStockActionDetailFormViewModel;
        this.baseStockActionDetailFormViewModel._StockActionDetail = this._TTObject as StockActionDetail;
        this.baseStockActionDetailFormViewModel._StockActionDetail.StockLevelType = new StockLevelType();
        this.baseStockActionDetailFormViewModel._StockActionDetail.Material = new Material();
    }

    protected loadViewModel() {
        let that = this;
        that.baseStockActionDetailFormViewModel = this._ViewModel as BaseStockActionDetailFormViewModel;
        that._TTObject = this.baseStockActionDetailFormViewModel._StockActionDetail;
        if (this.baseStockActionDetailFormViewModel == null)
            this.baseStockActionDetailFormViewModel = new BaseStockActionDetailFormViewModel();
        if (this.baseStockActionDetailFormViewModel._StockActionDetail == null)
            this.baseStockActionDetailFormViewModel._StockActionDetail = new StockActionDetail();
        let stockLevelTypeObjectID = that.baseStockActionDetailFormViewModel._StockActionDetail["StockLevelType"];
        if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
            let stockLevelType = that.baseStockActionDetailFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
             if (stockLevelType) {
                that.baseStockActionDetailFormViewModel._StockActionDetail.StockLevelType = stockLevelType;
            }
        }
        let materialObjectID = that.baseStockActionDetailFormViewModel._StockActionDetail["Material"];
        if (materialObjectID != null && (typeof materialObjectID === 'string')) {
            let material = that.baseStockActionDetailFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
             if (material) {
                that.baseStockActionDetailFormViewModel._StockActionDetail.Material = material;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseStockActionDetailFormViewModel);
  
    }


    public onAmountChanged(event): void {
        if (event != null) {
            if (this._StockActionDetail != null && this._StockActionDetail.Amount != event) {
                this._StockActionDetail.Amount = event;
            }
        }
    }

    public onMaterialChanged(event): void {
        if (event != null) {
            if (this._StockActionDetail != null && this._StockActionDetail.Material != event) {
                this._StockActionDetail.Material = event;
            }
        }
    }

    public onStockLevelTypeChanged(event): void {
        if (event != null) {
            if (this._StockActionDetail != null && this._StockActionDetail.StockLevelType != event) {
                this._StockActionDetail.StockLevelType = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Amount, "Text", this.__ttObject, "Amount");
        redirectProperty(this.StockLevelType, "SelectedObject", this.__ttObject, "StockLevelType");
    }

    public initFormControls(): void {
        this.StockLevelType = new TTVisual.TTListDefComboBox();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.BackColor = "#F0F0F0";
        this.StockLevelType.Enabled = false;
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.TabIndex = 11;

        this.labelMaterial = new TTVisual.TTLabel();
        this.labelMaterial.Text = i18n("M18545", "Malzeme");
        this.labelMaterial.Name = "labelMaterial";
        this.labelMaterial.TabIndex = 9;

        this.Material = new TTVisual.TTObjectListBox();
        this.Material.ReadOnly = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.Name = "Material";
        this.Material.TabIndex = 8;

        this.labelAmount = new TTVisual.TTLabel();
        this.labelAmount.Text = i18n("M19030", "Miktar");
        this.labelAmount.Name = "labelAmount";
        this.labelAmount.TabIndex = 1;

        this.Amount = new TTVisual.TTTextBox();
        this.Amount.Text = "0";
        this.Amount.TextAlign = HorizontalAlignment.Right;
        this.Amount.BackColor = "#F0F0F0";
        this.Amount.ReadOnly = true;
        this.Amount.Name = "Amount";
        this.Amount.TabIndex = 0;

        this.labelStockLevelType = new TTVisual.TTLabel();
        this.labelStockLevelType.Text = i18n("M18519", "Malın Durumu");
        this.labelStockLevelType.Name = "labelStockLevelType";
        this.labelStockLevelType.TabIndex = 3;

        this.Controls = [this.StockLevelType, this.labelMaterial, this.Material, this.labelAmount, this.Amount, this.labelStockLevelType];

    }


}
