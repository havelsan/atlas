//$37C6AA57
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { OrtesisProsthesisDefinitionFormViewModel } from './OrtesisProsthesisDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { OrtesisProsthesisDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { OrtesisProsthesisMaterialGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OrtesisProsthesisDefinitionForm',
    templateUrl: './OrtesisProsthesisDefinitionForm.html',
    providers: [MessageService]
})
export class OrtesisProsthesisDefinitionForm extends TTVisual.TTForm  implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    Code: TTVisual.ITTTextBox;
    DefaultAmount: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    HCType: TTVisual.ITTEnumComboBox;
    IsActive: TTVisual.ITTCheckBox;
    labelCode: TTVisual.ITTLabel;
    labelDefaultAmount: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    labelWarranty: TTVisual.ITTLabel;
    MaterialName: TTVisual.ITTListBoxColumn;
    MaterialsGrid: TTVisual.ITTGrid;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    ProcedureTree: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    SideSelect: TTVisual.ITTCheckBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    Warranty: TTVisual.ITTTextBox;
    public MaterialsGridColumns = [];
    public ortesisProsthesisDefinitionFormViewModel: OrtesisProsthesisDefinitionFormViewModel = new OrtesisProsthesisDefinitionFormViewModel();
    public get _OrtesisProsthesisDefinition(): OrtesisProsthesisDefinition {
        return this._TTObject as OrtesisProsthesisDefinition;
    }
    private OrtesisProsthesisDefinitionForm_DocumentUrl: string = '/api/OrtesisProsthesisDefinitionService/OrtesisProsthesisDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("ORTESISPROSTHESISDEFINITION", "OrtesisProsthesisDefinitionForm");
        this._DocumentServiceUrl = this.OrtesisProsthesisDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OrtesisProsthesisDefinition();
        this.ortesisProsthesisDefinitionFormViewModel = new OrtesisProsthesisDefinitionFormViewModel();
        this._ViewModel = this.ortesisProsthesisDefinitionFormViewModel;
        this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition = this._TTObject as OrtesisProsthesisDefinition;
        this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.Materials = new Array<OrtesisProsthesisMaterialGrid>();

      	this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.PackageProcedure = new PackageProcedureDefinition();
	    this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.GILDefinition = new GILDefinition();
        this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>(); 
        this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 

    }

    protected loadViewModel() {
        let that = this;
        that.ortesisProsthesisDefinitionFormViewModel = this._ViewModel as OrtesisProsthesisDefinitionFormViewModel;
        that._TTObject = this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition;
        if (this.ortesisProsthesisDefinitionFormViewModel == null)
            this.ortesisProsthesisDefinitionFormViewModel = new OrtesisProsthesisDefinitionFormViewModel();
        if (this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition == null)
            this.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition = new OrtesisProsthesisDefinition();
        let procedureTreeObjectID = that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.ortesisProsthesisDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.ProcedureTree = procedureTree;
            }
        }

    
    that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.Materials = that.ortesisProsthesisDefinitionFormViewModel.MaterialsGridGridList;
    for(let detailItem of that.ortesisProsthesisDefinitionFormViewModel.MaterialsGridGridList) {
        let materialObjectID = detailItem["Material"];
        if (materialObjectID != null && (typeof materialObjectID === "string")) {
            let material = that.ortesisProsthesisDefinitionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
            if (material) {
                detailItem.Material = material;
            }
        }

    }

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.ortesisProsthesisDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.ortesisProsthesisDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.GILDefinition = gILDefinition;
            }
        }

        that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.SubProcedureDefinitions = that.ortesisProsthesisDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.ortesisProsthesisDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.ortesisProsthesisDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }
        that.ortesisProsthesisDefinitionFormViewModel._OrtesisProsthesisDefinition.RequiredDiagnoseProcedures = that.ortesisProsthesisDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.ortesisProsthesisDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.ortesisProsthesisDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.Code != event) { 
    this._OrtesisProsthesisDefinition.Code = event;
}
}

public onDefaultAmountChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.DefaultAmount != event) { 
    this._OrtesisProsthesisDefinition.DefaultAmount = event;
}
}

public onDescriptionChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.Description != event) { 
    this._OrtesisProsthesisDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.EnglishName != event) { 
    this._OrtesisProsthesisDefinition.EnglishName = event;
}
}

public onHCTypeChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.HealthCommitteeType != event) { 
    this._OrtesisProsthesisDefinition.HealthCommitteeType = event;
}
}

public onIsActiveChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.IsActive != event) { 
    this._OrtesisProsthesisDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.MedulaProcedureType != event) { 
    this._OrtesisProsthesisDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.Name != event) { 
    this._OrtesisProsthesisDefinition.Name = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.ProcedureTree != event) { 
    this._OrtesisProsthesisDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.Qref != event) { 
    this._OrtesisProsthesisDefinition.Qref = event;
}
}

public onSideSelectChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.SideSelect != event) { 
    this._OrtesisProsthesisDefinition.SideSelect = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.SUTAppendix != event) { 
    this._OrtesisProsthesisDefinition.SUTAppendix = event;
}
}

public onWarrantyChanged(event): void {
    if(this._OrtesisProsthesisDefinition != null && this._OrtesisProsthesisDefinition.Warranty != event) { 
    this._OrtesisProsthesisDefinition.Warranty = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.DefaultAmount, "Text", this.__ttObject, "DefaultAmount");
    redirectProperty(this.SideSelect, "Value", this.__ttObject, "SideSelect");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.HCType, "Value", this.__ttObject, "HealthCommitteeType");
    redirectProperty(this.Warranty, "Text", this.__ttObject, "Warranty");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 55;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 54;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 53;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 52;

    this.labelWarranty = new TTVisual.TTLabel();
    this.labelWarranty.Text = "Garanti Süresi";
    this.labelWarranty.Name = "labelWarranty";
    this.labelWarranty.TabIndex = 51;

    this.Warranty = new TTVisual.TTTextBox();
    this.Warranty.Name = "Warranty";
    this.Warranty.TabIndex = 50;

    this.DefaultAmount = new TTVisual.TTTextBox();
    this.DefaultAmount.Text = "1";
    this.DefaultAmount.Name = "DefaultAmount";
    this.DefaultAmount.TabIndex = 47;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 37;
    this.Qref.Visible = false;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Name = "Name";
    this.Name.TabIndex = 35;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 32;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Name = "Description";
    this.Description.TabIndex = 30;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Name = "Code";
    this.Code.TabIndex = 28;

    this.SideSelect = new TTVisual.TTCheckBox();
    this.SideSelect.Value = false;
    this.SideSelect.Title = "Yön (Taraf) Seçimi";
    this.SideSelect.Name = "SideSelect";
    this.SideSelect.TabIndex = 49;

    this.labelDefaultAmount = new TTVisual.TTLabel();
    this.labelDefaultAmount.Text = "Varsayılan Miktar";
    this.labelDefaultAmount.Name = "labelDefaultAmount";
    this.labelDefaultAmount.TabIndex = 48;

    this.HCType = new TTVisual.TTEnumComboBox();
    this.HCType.DataTypeName = "OrthesisProsthesisHCType";
    this.HCType.Name = "HCType";
    this.HCType.TabIndex = 46;
    this.HCType.Visible = false;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "SUT Grubu";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 45;

    this.ProcedureTree = new TTVisual.TTObjectListBox();
    this.ProcedureTree.ListDefName = "ProcedureTreeListDefinition";
    this.ProcedureTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ProcedureTree.Name = "ProcedureTree";
    this.ProcedureTree.TabIndex = 44;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Bağlı Olduğu";
    this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 43;

    this.MaterialsGrid = new TTVisual.TTGrid();
    this.MaterialsGrid.Name = "MaterialsGrid";
    this.MaterialsGrid.TabIndex = 42;

    this.MaterialName = new TTVisual.TTListBoxColumn();
    this.MaterialName.ListDefName = "MaterialListDefinition";
    this.MaterialName.DataMember = "Material";
    this.MaterialName.DisplayIndex = 0;
    this.MaterialName.HeaderText = "Malzeme Adı";
    this.MaterialName.Name = "MaterialName";
    this.MaterialName.Width = 400;

    this.Amount = new TTVisual.TTTextBoxColumn();
    this.Amount.DataMember = "Amount";
    this.Amount.DisplayIndex = 1;
    this.Amount.HeaderText = "Miktarı";
    this.Amount.Name = "Amount";
    this.Amount.Width = 100;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Malzemeler";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 41;

    this.ttlabel4 = new TTVisual.TTLabel();
    this.ttlabel4.Text = "Rapor Tipi";
    this.ttlabel4.ForeColor = "#000000";
    this.ttlabel4.Name = "ttlabel4";
    this.ttlabel4.TabIndex = 40;
    this.ttlabel4.Visible = false;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Adı";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 38;
    this.labelQref.Visible = false;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Adı";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 36;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = true;
    this.IsActive.Title = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 34;

    this.labelEnglishName = new TTVisual.TTLabel();
    this.labelEnglishName.Text = "İngilizce Adı";
    this.labelEnglishName.ForeColor = "#000000";
    this.labelEnglishName.Name = "labelEnglishName";
    this.labelEnglishName.TabIndex = 33;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 31;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Kodu";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 29;

    this.MaterialsGridColumns = [this.MaterialName, this.Amount];
    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.labelWarranty, this.Warranty, this.DefaultAmount, this.Qref, this.Name, this.EnglishName, this.Description, this.Code, this.SideSelect, this.labelDefaultAmount, this.HCType, this.ttlabel3, this.ProcedureTree, this.ttlabel2, this.MaterialsGrid, this.MaterialName, this.Amount, this.ttlabel1, this.ttlabel4, this.labelQref, this.labelName, this.IsActive, this.labelEnglishName, this.labelDescription, this.labelCode];

}


}
