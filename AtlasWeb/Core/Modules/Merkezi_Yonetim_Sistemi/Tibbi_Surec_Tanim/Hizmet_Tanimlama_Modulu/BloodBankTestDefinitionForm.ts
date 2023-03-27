//$FFE08B9D
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { BloodBankTestDefinitionFormViewModel } from './BloodBankTestDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BloodBankTestDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { BloodBankGridMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BloodBankGridProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'BloodBankTestDefinitionForm',
    templateUrl: './BloodBankTestDefinitionForm.html',
    providers: [MessageService]
})
export class BloodBankTestDefinitionForm extends TTVisual.TTForm implements OnInit {
    barcodetextbox: TTVisual.ITTTextBox;
    Code: TTVisual.ITTTextBox;
    ColumnMaterial: TTVisual.ITTListBoxColumn;
    ColumnSubProcedures: TTVisual.ITTListBoxColumn;
    GridMaterials: TTVisual.ITTGrid;
    GridProcedures: TTVisual.ITTGrid;
    ID: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    labelCode: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    OnlyChargeWithProduct: TTVisual.ITTCheckBox;
    Qref: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    TabControl: TTVisual.ITTTabControl;
    TabPageMaterials: TTVisual.ITTTabPage;
    TabPageTests: TTVisual.ITTTabPage;
    ttenumcombobox2: TTVisual.ITTEnumComboBox;
    ttenumcombobox3: TTVisual.ITTEnumComboBox;
    ttenumcombobox4: TTVisual.ITTEnumComboBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttextbox5: TTVisual.ITTTextBox;
    tttextbox6: TTVisual.ITTTextBox;
    tttextbox7: TTVisual.ITTTextBox;
    tttextbox8: TTVisual.ITTTextBox;
    tttextbox9: TTVisual.ITTTextBox;
    public GridMaterialsColumns = [];
    public GridProceduresColumns = [];
    public bloodBankTestDefinitionFormViewModel: BloodBankTestDefinitionFormViewModel = new BloodBankTestDefinitionFormViewModel();
    public get _BloodBankTestDefinition(): BloodBankTestDefinition {
        return this._TTObject as BloodBankTestDefinition;
    }
    private BloodBankTestDefinitionForm_DocumentUrl: string = '/api/BloodBankTestDefinitionService/BloodBankTestDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("BLOODBANKTESTDEFINITION", "BloodBankTestDefinitionForm");
        this._DocumentServiceUrl = this.BloodBankTestDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BloodBankTestDefinition();
        this.bloodBankTestDefinitionFormViewModel = new BloodBankTestDefinitionFormViewModel();
        this._ViewModel = this.bloodBankTestDefinitionFormViewModel;
        this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition = this._TTObject as BloodBankTestDefinition;
        this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.SubProcedures = new Array<BloodBankGridProcedureDefinition>();
        this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.Materials = new Array<BloodBankGridMaterialDefinition>();
        this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.ProcedureTree = new ProcedureTreeDefinition();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.GILDefinition = new GILDefinition();
        this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>(); 
        this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.bloodBankTestDefinitionFormViewModel = this._ViewModel as BloodBankTestDefinitionFormViewModel;
        that._TTObject = this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition;
        if (this.bloodBankTestDefinitionFormViewModel == null)
            this.bloodBankTestDefinitionFormViewModel = new BloodBankTestDefinitionFormViewModel();
        if (this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition == null)
            this.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition = new BloodBankTestDefinition();
        that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.SubProcedures = that.bloodBankTestDefinitionFormViewModel.GridProceduresGridList;
        for (let detailItem of that.bloodBankTestDefinitionFormViewModel.GridProceduresGridList) {
            let subProcedureObjectID = detailItem["SubProcedure"];
            if (subProcedureObjectID != null && (typeof subProcedureObjectID === "string")) {
                let subProcedure = that.bloodBankTestDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === subProcedureObjectID.toString());
                if (subProcedure) {
                    detailItem.SubProcedure = subProcedure;
                }
            }

        }

        that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.Materials = that.bloodBankTestDefinitionFormViewModel.GridMaterialsGridList;
        for (let detailItem of that.bloodBankTestDefinitionFormViewModel.GridMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.bloodBankTestDefinitionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }

        let procedureTreeObjectID = that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.bloodBankTestDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.ProcedureTree = procedureTree;
            }
        }
        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.bloodBankTestDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.bloodBankTestDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.GILDefinition = gILDefinition;
            }
        }

        that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.SubProcedureDefinitions = that.bloodBankTestDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.bloodBankTestDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.bloodBankTestDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.bloodBankTestDefinitionFormViewModel._BloodBankTestDefinition.RequiredDiagnoseProcedures = that.bloodBankTestDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.bloodBankTestDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.bloodBankTestDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
                if (diagnosisDefinition) {
                    detailItem.DiagnosisDefinition = diagnosisDefinition;
                }
            }
        }
        /**
         * Her Tanım Ekranına Eklenmeli Base için Bitiş
         */ 


    }

async ngOnInit() {
    await this.load();
}

public onCodeChanged(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.Code != event) { 
    this._BloodBankTestDefinition.Code = event;
}
}

public onIDChanged(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.ID != event) { 
    this._BloodBankTestDefinition.ID = event;
}
}

public onIsActiveChanged(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.IsActive != event) { 
    this._BloodBankTestDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.MedulaProcedureType != event) { 
    this._BloodBankTestDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.Name != event) { 
    this._BloodBankTestDefinition.Name = event;
}
}

public onOnlyChargeWithProductChanged(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.OnlyChargeWithProduct != event) { 
    this._BloodBankTestDefinition.OnlyChargeWithProduct = event;
}
}

public onQrefChanged(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.Qref != event) { 
    this._BloodBankTestDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.SUTAppendix != event) { 
    this._BloodBankTestDefinition.SUTAppendix = event;
}
}

public onttobjectlistbox1Changed(event): void {
    if(this._BloodBankTestDefinition != null && this._BloodBankTestDefinition.ProcedureTree != event) { 
    this._BloodBankTestDefinition.ProcedureTree = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.OnlyChargeWithProduct, "Value", this.__ttObject, "OnlyChargeWithProduct");
    redirectProperty(this.ID, "Text", this.__ttObject, "ID");
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
}

public initFormControls() : void {
    this.ttgroupbox1 = new TTVisual.TTGroupBox();
    this.ttgroupbox1.Text = "Ürün Özellikleri";
    this.ttgroupbox1.Name = "ttgroupbox1";
    this.ttgroupbox1.TabIndex = 59;

    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 70;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 69;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 68;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaSUTGroupEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 67;

    this.TabControl = new TTVisual.TTTabControl();
    this.TabControl.Name = "TabControl";
    this.TabControl.TabIndex = 60;

    this.TabPageTests = new TTVisual.TTTabPage();
    this.TabPageTests.DisplayIndex = 0;
    this.TabPageTests.TabIndex = 0;
    this.TabPageTests.Text = "Ek Tetkikler";
    this.TabPageTests.Name = "TabPageTests";

    this.GridProcedures = new TTVisual.TTGrid();
    this.GridProcedures.Name = "GridProcedures";
    this.GridProcedures.TabIndex = 0;

    this.ColumnSubProcedures = new TTVisual.TTListBoxColumn();
    this.ColumnSubProcedures.ListDefName = "ProcedureListDefinition";
    this.ColumnSubProcedures.DataMember = "SubProcedure";
    this.ColumnSubProcedures.DisplayIndex = 0;
    this.ColumnSubProcedures.HeaderText = "Tetkik Adı";
    this.ColumnSubProcedures.Name = "ColumnSubProcedures";
    this.ColumnSubProcedures.Width = 300;

    this.TabPageMaterials = new TTVisual.TTTabPage();
    this.TabPageMaterials.DisplayIndex = 1;
    this.TabPageMaterials.TabIndex = 1;
    this.TabPageMaterials.Text = "Kullanılan Malzemeler";
    this.TabPageMaterials.Name = "TabPageMaterials";

    this.GridMaterials = new TTVisual.TTGrid();
    this.GridMaterials.Name = "GridMaterials";
    this.GridMaterials.TabIndex = 0;

    this.ColumnMaterial = new TTVisual.TTListBoxColumn();
    this.ColumnMaterial.ListDefName = "TreatmentMaterialListDefinition";
    this.ColumnMaterial.DataMember = "Material";
    this.ColumnMaterial.DisplayIndex = 0;
    this.ColumnMaterial.HeaderText = "Malzeme";
    this.ColumnMaterial.Name = "ColumnMaterial";
    this.ColumnMaterial.Width = 300;

    this.OnlyChargeWithProduct = new TTVisual.TTCheckBox();
    this.OnlyChargeWithProduct.Value = false;
    this.OnlyChargeWithProduct.Title = "Ürün Bazında Ücretlenir";
    this.OnlyChargeWithProduct.Name = "OnlyChargeWithProduct";
    this.OnlyChargeWithProduct.TabIndex = 66;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Name.Name = "Name";
    this.Name.TabIndex = 39;

    this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox1.ListDefName = "ProcedureTreeListDefinition";
    this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttobjectlistbox1.Name = "ttobjectlistbox1";
    this.ttobjectlistbox1.TabIndex = 6;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Bağlı Olduğu Hizmet Grubu";
    this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 15;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = false;
    this.IsActive.Text = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 43;

    this.tttextbox7 = new TTVisual.TTTextBox();
    this.tttextbox7.Name = "tttextbox7";
    this.tttextbox7.TabIndex = 58;
    this.tttextbox7.Visible = false;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Barkod No";
    this.ttlabel3.BackColor = "#F0F0F0";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 46;
    this.ttlabel3.Visible = false;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Malzeme Kodu";
    this.labelCode.BackColor = "#F0F0F0";
    this.labelCode.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 35;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Adı";
    this.labelQref.BackColor = "#F0F0F0";
    this.labelQref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 31;

    this.barcodetextbox = new TTVisual.TTTextBox();
    this.barcodetextbox.Name = "barcodetextbox";
    this.barcodetextbox.TabIndex = 52;
    this.barcodetextbox.Visible = false;

    this.ttlabel7 = new TTVisual.TTLabel();
    this.ttlabel7.Text = "Sınıfı";
    this.ttlabel7.BackColor = "#F0F0F0";
    this.ttlabel7.ForeColor = "#000000";
    this.ttlabel7.Name = "ttlabel7";
    this.ttlabel7.TabIndex = 50;
    this.ttlabel7.Visible = false;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 30;

    this.ttlabel5 = new TTVisual.TTLabel();
    this.ttlabel5.Text = "Kan Ürünü Türü";
    this.ttlabel5.BackColor = "#F0F0F0";
    this.ttlabel5.ForeColor = "#000000";
    this.ttlabel5.Name = "ttlabel5";
    this.ttlabel5.TabIndex = 48;
    this.ttlabel5.Visible = false;

    this.ttenumcombobox4 = new TTVisual.TTEnumComboBox();
    this.ttenumcombobox4.DataTypeName = "BloodDeliveryType";
    this.ttenumcombobox4.Name = "ttenumcombobox4";
    this.ttenumcombobox4.TabIndex = 65;
    this.ttenumcombobox4.Visible = false;

    this.ttlabel8 = new TTVisual.TTLabel();
    this.ttlabel8.Text = "Miad Süresi(Gün)";
    this.ttlabel8.BackColor = "#F0F0F0";
    this.ttlabel8.ForeColor = "#000000";
    this.ttlabel8.Name = "ttlabel8";
    this.ttlabel8.TabIndex = 51;
    this.ttlabel8.Visible = false;

    this.ttlabel9 = new TTVisual.TTLabel();
    this.ttlabel9.Text = "Açıklama";
    this.ttlabel9.BackColor = "#F0F0F0";
    this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel9.ForeColor = "#000000";
    this.ttlabel9.Name = "ttlabel9";
    this.ttlabel9.TabIndex = 60;
    this.ttlabel9.Visible = false;

    this.tttextbox6 = new TTVisual.TTTextBox();
    this.tttextbox6.Name = "tttextbox6";
    this.tttextbox6.TabIndex = 57;
    this.tttextbox6.Visible = false;

    this.tttextbox5 = new TTVisual.TTTextBox();
    this.tttextbox5.Name = "tttextbox5";
    this.tttextbox5.TabIndex = 56;
    this.tttextbox5.Visible = true;

    this.ttlabel10 = new TTVisual.TTLabel();
    this.ttlabel10.Text = "Bağlı Olduğu Stok No,Stok Kartı";
    this.ttlabel10.BackColor = "#F0F0F0";
    this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel10.ForeColor = "#000000";
    this.ttlabel10.Name = "ttlabel10";
    this.ttlabel10.TabIndex = 62;
    this.ttlabel10.Visible = false;

    this.ttenumcombobox2 = new TTVisual.TTEnumComboBox();
    this.ttenumcombobox2.DataTypeName = "BloodGroupEnum";
    this.ttenumcombobox2.Name = "ttenumcombobox2";
    this.ttenumcombobox2.TabIndex = 63;
    this.ttenumcombobox2.Visible = false;

    this.ttlabel6 = new TTVisual.TTLabel();
    this.ttlabel6.Text = "Gelir Grubu";
    this.ttlabel6.BackColor = "#F0F0F0";
    this.ttlabel6.ForeColor = "#000000";
    this.ttlabel6.Name = "ttlabel6";
    this.ttlabel6.TabIndex = 49;
    this.ttlabel6.Visible = false;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Malzeme Adı";
    this.labelName.BackColor = "#F0F0F0";
    this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 40;

    this.ttlabel4 = new TTVisual.TTLabel();
    this.ttlabel4.Text = "Kan Grubu";
    this.ttlabel4.BackColor = "#F0F0F0";
    this.ttlabel4.ForeColor = "#000000";
    this.ttlabel4.Name = "ttlabel4";
    this.ttlabel4.TabIndex = 47;
    this.ttlabel4.Visible = false;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Dağıtım Şekli";
    this.ttlabel2.BackColor = "#F0F0F0";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 45;
    this.ttlabel2.Visible = false;

    this.tttextbox9 = new TTVisual.TTTextBox();
    this.tttextbox9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttextbox9.Name = "tttextbox9";
    this.tttextbox9.TabIndex = 61;
    this.tttextbox9.Visible = false;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Code.Name = "Code";
    this.Code.TabIndex = 34;

    this.tttextbox8 = new TTVisual.TTTextBox();
    this.tttextbox8.Multiline = true;
    this.tttextbox8.Name = "tttextbox8";
    this.tttextbox8.TabIndex = 59;
    this.tttextbox8.Visible = false;

    this.ID = new TTVisual.TTTextBox();
    this.ID.BackColor = "#F0F0F0";
    this.ID.ReadOnly = true;
    this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ID.Name = "ID";
    this.ID.TabIndex = 37;

    this.ttenumcombobox3 = new TTVisual.TTEnumComboBox();
    this.ttenumcombobox3.DataTypeName = "BloodProductType";
    this.ttenumcombobox3.Name = "ttenumcombobox3";
    this.ttenumcombobox3.TabIndex = 64;
    this.ttenumcombobox3.Visible = true;

    this.labelID = new TTVisual.TTLabel();
    this.labelID.Text = "Malzeme No";
    this.labelID.BackColor = "#F0F0F0";
    this.labelID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelID.ForeColor = "#000000";
    this.labelID.Name = "labelID";
    this.labelID.TabIndex = 38;

    this.GridProceduresColumns = [this.ColumnSubProcedures];
    this.GridMaterialsColumns = [this.ColumnMaterial];
    this.ttgroupbox1.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.TabControl, this.OnlyChargeWithProduct, this.Name, this.ttobjectlistbox1, this.ttlabel1, this.IsActive, this.tttextbox7, this.ttlabel3, this.labelCode, this.labelQref, this.barcodetextbox, this.ttlabel7, this.Qref, this.ttlabel5, this.ttenumcombobox4, this.ttlabel8, this.ttlabel9, this.tttextbox6, this.tttextbox5, this.ttlabel10, this.ttenumcombobox2, this.ttlabel6, this.labelName, this.ttlabel4, this.ttlabel2, this.tttextbox9, this.Code, this.tttextbox8, this.ID, this.ttenumcombobox3, this.labelID];
    this.TabControl.Controls = [this.TabPageTests, this.TabPageMaterials];
    this.TabPageTests.Controls = [this.GridProcedures];
    this.TabPageMaterials.Controls = [this.GridMaterials];
    this.Controls = [this.ttgroupbox1, this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.TabControl, this.TabPageTests, this.GridProcedures, this.ColumnSubProcedures, this.TabPageMaterials, this.GridMaterials, this.ColumnMaterial, this.OnlyChargeWithProduct, this.Name, this.ttobjectlistbox1, this.ttlabel1, this.IsActive, this.tttextbox7, this.ttlabel3, this.labelCode, this.labelQref, this.barcodetextbox, this.ttlabel7, this.Qref, this.ttlabel5, this.ttenumcombobox4, this.ttlabel8, this.ttlabel9, this.tttextbox6, this.tttextbox5, this.ttlabel10, this.ttenumcombobox2, this.ttlabel6, this.labelName, this.ttlabel4, this.ttlabel2, this.tttextbox9, this.Code, this.tttextbox8, this.ID, this.ttenumcombobox3, this.labelID];

}


}
