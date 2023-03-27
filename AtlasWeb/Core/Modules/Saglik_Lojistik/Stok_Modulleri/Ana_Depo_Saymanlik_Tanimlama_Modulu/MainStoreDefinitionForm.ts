//$9D8802A3
import { Component, OnInit  } from '@angular/core';
import { MainStoreDefinitionFormViewModel } from './MainStoreDefinitionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTReportTool from 'NebulaClient/Visual/ReportTool/TTReport';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Dictionary } from 'NebulaClient/System/Collections/Dictionaries/Dictionary';
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'MainStoreDefinitionForm',
    templateUrl: './MainStoreDefinitionForm.html',
    providers: [MessageService]
})
export class MainStoreDefinitionForm extends TTVisual.TTForm implements OnInit {
    Accountancy: TTVisual.ITTObjectListBox;
    AccountManager: TTVisual.ITTObjectListBox;
    cmdInfoCard: TTVisual.ITTButton;
    Description: TTVisual.ITTTextBox;
    GoodsAccountant: TTVisual.ITTObjectListBox;
    GoodsResponsible: TTVisual.ITTObjectListBox;
    IntegrationScope: TTVisual.ITTEnumComboBox;
    IsActive: TTVisual.ITTCheckBox;
    labelAccountancy: TTVisual.ITTLabel;
    labelAccountManager: TTVisual.ITTLabel;
    labelGoodsAccountant: TTVisual.ITTLabel;
    labelGoodsResponsible: TTVisual.ITTLabel;
    labelIntegrationScope: TTVisual.ITTLabel;
    labelMKYS_ButceTuru: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQREF: TTVisual.ITTLabel;
    labelStatus: TTVisual.ITTLabel;
    labelStoreCode: TTVisual.ITTLabel;
    labelStoreRecordNo: TTVisual.ITTLabel;
    labelUnitRecordNo: TTVisual.ITTLabel;
    MKYS_ButceTuru: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    QREF: TTVisual.ITTTextBox;
    Status: TTVisual.ITTEnumComboBox;
    StoreCode: TTVisual.ITTTextBox;
    StoreRecordNo: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    UnitRecordNo: TTVisual.ITTTextBox;
    public mainStoreDefinitionFormViewModel: MainStoreDefinitionFormViewModel = new MainStoreDefinitionFormViewModel();
    public get _MainStoreDefinition(): MainStoreDefinition {
        return this._TTObject as MainStoreDefinition;
    }
    private MainStoreDefinitionForm_DocumentUrl: string = '/api/MainStoreDefinitionService/MainStoreDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('MAINSTOREDEFINITION', 'MainStoreDefinitionForm');
        this._DocumentServiceUrl = this.MainStoreDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async cmdInfoCard_Click(): Promise<void> {
        if (this._MainStoreDefinition.GoodsResponsible !== null) {
            let parameter: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
            let objectID: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
            //TTReportTool.PropertyCache<object> birlik = new TTReportTool.PropertyCache<object>();
            objectID.push('VALUE', this._MainStoreDefinition.ObjectID.toString());
            // parameter.push('TTOBJECTID', objectID);
            //birlik.Add("VALUE", _MainStoreDefinition.Accountancy.AccountancyMilitaryUnit.Name.ToString());
            //parameter.Add("BIRLIK",objectID);
            TTReportTool.TTReport.PrintReport('TTReportClasses.I_InfoCardReport', true, 1, parameter);
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MainStoreDefinition();
        this.mainStoreDefinitionFormViewModel = new MainStoreDefinitionFormViewModel();
        this._ViewModel = this.mainStoreDefinitionFormViewModel;
        this.mainStoreDefinitionFormViewModel._MainStoreDefinition = this._TTObject as MainStoreDefinition;
        this.mainStoreDefinitionFormViewModel._MainStoreDefinition.AccountManager = new ResUser();
        this.mainStoreDefinitionFormViewModel._MainStoreDefinition.GoodsResponsible = new ResUser();
        this.mainStoreDefinitionFormViewModel._MainStoreDefinition.GoodsAccountant = new ResUser();
        this.mainStoreDefinitionFormViewModel._MainStoreDefinition.Accountancy = new Accountancy();
    }

    protected loadViewModel() {
        let that = this;
        that.mainStoreDefinitionFormViewModel = this._ViewModel as MainStoreDefinitionFormViewModel;
        that._TTObject = this.mainStoreDefinitionFormViewModel._MainStoreDefinition;
        if (this.mainStoreDefinitionFormViewModel == null)
            this.mainStoreDefinitionFormViewModel = new MainStoreDefinitionFormViewModel();
        if (this.mainStoreDefinitionFormViewModel._MainStoreDefinition == null)
            this.mainStoreDefinitionFormViewModel._MainStoreDefinition = new MainStoreDefinition();
        let accountManagerObjectID = that.mainStoreDefinitionFormViewModel._MainStoreDefinition["AccountManager"];
        if (accountManagerObjectID != null && (typeof accountManagerObjectID === "string")) {
            let accountManager = that.mainStoreDefinitionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === accountManagerObjectID.toString());
            if (accountManager) {
                that.mainStoreDefinitionFormViewModel._MainStoreDefinition.AccountManager = accountManager;
            }
        }
        let goodsResponsibleObjectID = that.mainStoreDefinitionFormViewModel._MainStoreDefinition["GoodsResponsible"];
        if (goodsResponsibleObjectID != null && (typeof goodsResponsibleObjectID === "string")) {
            let goodsResponsible = that.mainStoreDefinitionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === goodsResponsibleObjectID.toString());
            if (goodsResponsible) {
                that.mainStoreDefinitionFormViewModel._MainStoreDefinition.GoodsResponsible = goodsResponsible;
            }
        }
        let goodsAccountantObjectID = that.mainStoreDefinitionFormViewModel._MainStoreDefinition["GoodsAccountant"];
        if (goodsAccountantObjectID != null && (typeof goodsAccountantObjectID === "string")) {
            let goodsAccountant = that.mainStoreDefinitionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === goodsAccountantObjectID.toString());
            if (goodsAccountant) {
                that.mainStoreDefinitionFormViewModel._MainStoreDefinition.GoodsAccountant = goodsAccountant;
            }
        }
        let accountancyObjectID = that.mainStoreDefinitionFormViewModel._MainStoreDefinition["Accountancy"];
        if (accountancyObjectID != null && (typeof accountancyObjectID === "string")) {
            let accountancy = that.mainStoreDefinitionFormViewModel.Accountancys.find(o => o.ObjectID.toString() === accountancyObjectID.toString());
            if (accountancy) {
                that.mainStoreDefinitionFormViewModel._MainStoreDefinition.Accountancy = accountancy;
            }
        }

    }

    async ngOnInit() {
        await this.load();
    }

    public onAccountancyChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.Accountancy != event) {
                this._MainStoreDefinition.Accountancy = event;
            }
        }
    }

    public onAccountManagerChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.AccountManager != event) {
                this._MainStoreDefinition.AccountManager = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.Description != event) {
                this._MainStoreDefinition.Description = event;
            }
        }
    }

    public onGoodsAccountantChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.GoodsAccountant != event) {
                this._MainStoreDefinition.GoodsAccountant = event;
            }
        }
    }

    public onGoodsResponsibleChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.GoodsResponsible != event) {
                this._MainStoreDefinition.GoodsResponsible = event;
            }
        }
    }

    public onIntegrationScopeChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.IntegrationScope != event) {
                this._MainStoreDefinition.IntegrationScope = event;
            }
        }
    }

    public onIsActiveChanged(event): void {
        if (event != null) {
            /*if (this._MainStoreDefinition != null && this._MainStoreDefinition.ISACTIVE != event) {
                this._MainStoreDefinition.ISACTIVE = event;
            }*/
        }
    }

    public onMKYS_ButceTuruChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.MKYS_ButceTuru != event) {
                this._MainStoreDefinition.MKYS_ButceTuru = event;
            }
        }
    }

    public onNameChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.Name != event) {
                this._MainStoreDefinition.Name = event;
            }
        }
    }

    public onQREFChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.QREF != event) {
                this._MainStoreDefinition.QREF = event;
            }
        }
    }

    public onStatusChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.Status != event) {
                this._MainStoreDefinition.Status = event;
            }
        }
    }

    public onStoreCodeChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.StoreCode != event) {
                this._MainStoreDefinition.StoreCode = event;
            }
        }
    }

    public onStoreRecordNoChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.StoreRecordNo != event) {
                this._MainStoreDefinition.StoreRecordNo = event;
            }
        }
    }

    public onUnitRecordNoChanged(event): void {
        if (event != null) {
            if (this._MainStoreDefinition != null && this._MainStoreDefinition.UnitRecordNo != event) {
                this._MainStoreDefinition.UnitRecordNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Status, "Value", this.__ttObject, "Status");
        redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.IntegrationScope, "Value", this.__ttObject, "IntegrationScope");
        redirectProperty(this.StoreCode, "Text", this.__ttObject, "StoreCode");
        redirectProperty(this.StoreRecordNo, "Text", this.__ttObject, "StoreRecordNo");
        redirectProperty(this.UnitRecordNo, "Text", this.__ttObject, "UnitRecordNo");
        redirectProperty(this.MKYS_ButceTuru, "Value", this.__ttObject, "MKYS_ButceTuru");
        redirectProperty(this.QREF, "Text", this.__ttObject, "QREF");
        redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    }

    public initFormControls(): void {
        this.labelUnitRecordNo = new TTVisual.TTLabel();
        this.labelUnitRecordNo.Text = "Birim Kayıt No";
        this.labelUnitRecordNo.Name = "labelUnitRecordNo";
        this.labelUnitRecordNo.TabIndex = 31;

        this.UnitRecordNo = new TTVisual.TTTextBox();
        this.UnitRecordNo.Name = "UnitRecordNo";
        this.UnitRecordNo.TabIndex = 30;

        this.StoreRecordNo = new TTVisual.TTTextBox();
        this.StoreRecordNo.Name = "StoreRecordNo";
        this.StoreRecordNo.TabIndex = 28;

        this.StoreCode = new TTVisual.TTTextBox();
        this.StoreCode.Name = "StoreCode";
        this.StoreCode.TabIndex = 26;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 5;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Name.Name = "Name";
        this.Name.TabIndex = 1;

        this.QREF = new TTVisual.TTTextBox();
        this.QREF.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.QREF.Name = "QREF";
        this.QREF.TabIndex = 0;

        this.labelStoreRecordNo = new TTVisual.TTLabel();
        this.labelStoreRecordNo.Text = "Depo Kayıt No";
        this.labelStoreRecordNo.Name = "labelStoreRecordNo";
        this.labelStoreRecordNo.TabIndex = 29;

        this.labelStoreCode = new TTVisual.TTLabel();
        this.labelStoreCode.Text = "Depo Kodu";
        this.labelStoreCode.Name = "labelStoreCode";
        this.labelStoreCode.TabIndex = 27;

        this.labelIntegrationScope = new TTVisual.TTLabel();
        this.labelIntegrationScope.Text = "Entegrasyon Kapsaminda";
        this.labelIntegrationScope.Name = "labelIntegrationScope";
        this.labelIntegrationScope.TabIndex = 25;

        this.IntegrationScope = new TTVisual.TTEnumComboBox();
        this.IntegrationScope.DataTypeName = "MKYS_EEntegrasyonDurumuEnum";
        this.IntegrationScope.Name = "IntegrationScope";
        this.IntegrationScope.TabIndex = 24;

        this.labelMKYS_ButceTuru = new TTVisual.TTLabel();
        this.labelMKYS_ButceTuru.Text = "MKYS Bütçe Türü";
        this.labelMKYS_ButceTuru.Name = "labelMKYS_ButceTuru";
        this.labelMKYS_ButceTuru.TabIndex = 23;

        this.MKYS_ButceTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ButceTuru.DataTypeName = "MKYS_EButceTurEnum";
        this.MKYS_ButceTuru.Name = "MKYS_ButceTuru";
        this.MKYS_ButceTuru.TabIndex = 22;

        this.labelAccountManager = new TTVisual.TTLabel();
        this.labelAccountManager.Text = "Hesap Sorumlusu";
        this.labelAccountManager.Name = "labelAccountManager";
        this.labelAccountManager.TabIndex = 17;

        this.AccountManager = new TTVisual.TTObjectListBox();
        this.AccountManager.ListDefName = "UserListDefinition";
        this.AccountManager.Name = "AccountManager";
        this.AccountManager.TabIndex = 16;

        this.cmdInfoCard = new TTVisual.TTButton();
        this.cmdInfoCard.Text = "Mal Sorumlusu Tanıtma Kartı Bas";
        this.cmdInfoCard.Name = "cmdInfoCard";
        this.cmdInfoCard.TabIndex = 15;
        this.cmdInfoCard.Visible = false;

        this.labelGoodsAccountant = new TTVisual.TTLabel();
        this.labelGoodsAccountant.Text = "Mal Saymanı ( Depo Sorumlusu)";
        this.labelGoodsAccountant.BackColor = "#DCDCDC";
        this.labelGoodsAccountant.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelGoodsAccountant.ForeColor = "#000000";
        this.labelGoodsAccountant.Name = "labelGoodsAccountant";
        this.labelGoodsAccountant.TabIndex = 14;

        this.GoodsResponsible = new TTVisual.TTObjectListBox();
        this.GoodsResponsible.ListDefName = "UserListDefinition";
        this.GoodsResponsible.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GoodsResponsible.Name = "GoodsResponsible";
        this.GoodsResponsible.TabIndex = 1;

        this.labelGoodsResponsible = new TTVisual.TTLabel();
        this.labelGoodsResponsible.Text = "Mal Sorumlusu";
        this.labelGoodsResponsible.BackColor = "#DCDCDC";
        this.labelGoodsResponsible.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelGoodsResponsible.ForeColor = "#000000";
        this.labelGoodsResponsible.Name = "labelGoodsResponsible";
        this.labelGoodsResponsible.TabIndex = 14;

        this.Status = new TTVisual.TTEnumComboBox();
        this.Status.DataTypeName = "OpenCloseEnum";
        this.Status.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Status.Name = "Status";
        this.Status.TabIndex = 2;

        this.GoodsAccountant = new TTVisual.TTObjectListBox();
        this.GoodsAccountant.ListDefName = "UserListDefinition";
        this.GoodsAccountant.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GoodsAccountant.Name = "GoodsAccountant";
        this.GoodsAccountant.TabIndex = 0;

        this.Accountancy = new TTVisual.TTObjectListBox();
        this.Accountancy.ListDefName = "AccountancyList";
        this.Accountancy.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Accountancy.Name = "Accountancy";
        this.Accountancy.TabIndex = 3;

        this.labelAccountancy = new TTVisual.TTLabel();
        this.labelAccountancy.Text = "Saymanlık";
        this.labelAccountancy.BackColor = "#DCDCDC";
        this.labelAccountancy.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelAccountancy.ForeColor = "#000000";
        this.labelAccountancy.Name = "labelAccountancy";
        this.labelAccountancy.TabIndex = 14;

        this.IsActive = new TTVisual.TTCheckBox();
        this.IsActive.Value = false;
        this.IsActive.Text = "Aktif/Pasif";
        this.IsActive.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IsActive.Name = "IsActive";
        this.IsActive.TabIndex = 4;

        this.labelStatus = new TTVisual.TTLabel();
        this.labelStatus.Text = "Durum";
        this.labelStatus.BackColor = "#DCDCDC";
        this.labelStatus.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStatus.ForeColor = "#000000";
        this.labelStatus.Name = "labelStatus";
        this.labelStatus.TabIndex = 1;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "Adı";
        this.labelName.BackColor = "#DCDCDC";
        this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelName.ForeColor = "#000000";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 5;

        this.labelQREF = new TTVisual.TTLabel();
        this.labelQREF.Text = "Hızlı Referans";
        this.labelQREF.BackColor = "#DCDCDC";
        this.labelQREF.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelQREF.ForeColor = "#000000";
        this.labelQREF.Name = "labelQREF";
        this.labelQREF.TabIndex = 7;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Açıklama";
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 7;

        this.Controls = [this.labelUnitRecordNo, this.UnitRecordNo, this.StoreRecordNo, this.StoreCode, this.Description, this.Name, this.QREF, this.labelStoreRecordNo, this.labelStoreCode, this.labelIntegrationScope, this.IntegrationScope, this.labelMKYS_ButceTuru, this.MKYS_ButceTuru, this.labelAccountManager, this.AccountManager, this.cmdInfoCard, this.labelGoodsAccountant, this.GoodsResponsible, this.labelGoodsResponsible, this.Status, this.GoodsAccountant, this.Accountancy, this.labelAccountancy, this.IsActive, this.labelStatus, this.labelName, this.labelQREF, this.ttlabel1];

    }


}
