//$FC9C5EB7
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { DentalProsthesisDefinitionFormViewModel } from './DentalProsthesisDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DentalProsthesisDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisDepartmentGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'DentalProsthesisDefinitionForm',
    templateUrl: './DentalProsthesisDefinitionForm.html',
    providers: [MessageService]
})
export class DentalProsthesisDefinitionForm extends TTVisual.TTForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    DentalProsthesisDefinition0: TTVisual.ITTListBoxColumn;
    Departments: TTVisual.ITTGrid;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    labelCode: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    ProcedureTree: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    public DepartmentsColumns = [];
    public dentalProsthesisDefinitionFormViewModel: DentalProsthesisDefinitionFormViewModel = new DentalProsthesisDefinitionFormViewModel();
    public get _DentalProsthesisDefinition(): DentalProsthesisDefinition {
        return this._TTObject as DentalProsthesisDefinition;
    }
    private DentalProsthesisDefinitionForm_DocumentUrl: string = '/api/DentalProsthesisDefinitionService/DentalProsthesisDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("DENTALPROSTHESISDEFINITION", "DentalProsthesisDefinitionForm");
        this._DocumentServiceUrl = this.DentalProsthesisDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DentalProsthesisDefinition();
        this.dentalProsthesisDefinitionFormViewModel = new DentalProsthesisDefinitionFormViewModel();
        this._ViewModel = this.dentalProsthesisDefinitionFormViewModel;
        this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition = this._TTObject as DentalProsthesisDefinition;
        this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.Departments = new Array<DentalProsthesisDepartmentGrid>();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.GILDefinition = new GILDefinition();
        this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();    
        this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.dentalProsthesisDefinitionFormViewModel = this._ViewModel as DentalProsthesisDefinitionFormViewModel;
        that._TTObject = this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition;
        if (this.dentalProsthesisDefinitionFormViewModel == null)
            this.dentalProsthesisDefinitionFormViewModel = new DentalProsthesisDefinitionFormViewModel();
        if (this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition == null)
            this.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition = new DentalProsthesisDefinition();
        let procedureTreeObjectID = that.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.dentalProsthesisDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.ProcedureTree = procedureTree;
            }
        }

    
    that.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.Departments = that.dentalProsthesisDefinitionFormViewModel.DepartmentsGridList;
    for(let detailItem of that.dentalProsthesisDefinitionFormViewModel.DepartmentsGridList) {
        let departmentObjectID = detailItem["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === "string")) {
            let department = that.dentalProsthesisDefinitionFormViewModel.ResSections.find(o => o.ObjectID.toString() === departmentObjectID.toString());
            if (department) {
                detailItem.Department = department;
            }
        }

    }
        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.dentalProsthesisDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.dentalProsthesisDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.GILDefinition = gILDefinition;
            }
        }

        that.dentalProsthesisDefinitionFormViewModel._DentalProsthesisDefinition.SubProcedureDefinitions = that.dentalProsthesisDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.dentalProsthesisDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.dentalProsthesisDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
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
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.Code != event) { 
    this._DentalProsthesisDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.Description != event) { 
    this._DentalProsthesisDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.EnglishName != event) { 
    this._DentalProsthesisDefinition.EnglishName = event;
}
}

public onIsActiveChanged(event): void {
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.IsActive != event) { 
    this._DentalProsthesisDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.MedulaProcedureType != event) { 
    this._DentalProsthesisDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.Name != event) { 
    this._DentalProsthesisDefinition.Name = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.ProcedureTree != event) { 
    this._DentalProsthesisDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.Qref != event) { 
    this._DentalProsthesisDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._DentalProsthesisDefinition != null && this._DentalProsthesisDefinition.SUTAppendix != event) { 
    this._DentalProsthesisDefinition.SUTAppendix = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 60;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 59;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 58;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 57;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Hizmet Grubu";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 56;

    this.ProcedureTree = new TTVisual.TTObjectListBox();
    this.ProcedureTree.ListDefName = "ProcedureTreeListDefinition";
    this.ProcedureTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ProcedureTree.Name = "ProcedureTree";
    this.ProcedureTree.TabIndex = 55;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Bağlı Olduğu";
    this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 54;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Adı";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 51;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 50;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Name = "Name";
    this.Name.TabIndex = 48;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 45;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Name = "Description";
    this.Description.TabIndex = 43;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Name = "Code";
    this.Code.TabIndex = 41;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Adı";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 49;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = true;
    this.IsActive.Text = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 47;

    this.labelEnglishName = new TTVisual.TTLabel();
    this.labelEnglishName.Text = "İngilizce Adı";
    this.labelEnglishName.ForeColor = "#000000";
    this.labelEnglishName.Name = "labelEnglishName";
    this.labelEnglishName.TabIndex = 46;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 44;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Kodu";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 42;

    this.Departments = new TTVisual.TTGrid();
    this.Departments.Name = "Departments";
    this.Departments.TabIndex = 15;

    this.DentalProsthesisDefinition0 = new TTVisual.TTListBoxColumn();
    this.DentalProsthesisDefinition0.ListDefName = "ResourceListDefinition";
    this.DentalProsthesisDefinition0.DataMember = "Department";
    this.DentalProsthesisDefinition0.DisplayIndex = 0;
    this.DentalProsthesisDefinition0.HeaderText = "Diş Protez Birimleri";
    this.DentalProsthesisDefinition0.Name = "DentalProsthesisDefinition0";
    this.DentalProsthesisDefinition0.Width = 300;

    this.DepartmentsColumns = [this.DentalProsthesisDefinition0];
    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.ttlabel3, this.ProcedureTree, this.ttlabel2, this.labelQref, this.Qref, this.Name, this.EnglishName, this.Description, this.Code, this.labelName, this.IsActive, this.labelEnglishName, this.labelDescription, this.labelCode, this.Departments, this.DentalProsthesisDefinition0];

}


}
