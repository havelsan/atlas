//$CB106DA7
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { DentalTreatmentDefinitionFormViewModel } from './DentalTreatmentDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DentalTreatmentDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { DentalRequestTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DentalTreatmentDepartmentGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'DentalTreatmentDefinitionForm',
    templateUrl: './DentalTreatmentDefinitionForm.html',
    providers: [MessageService]
})
export class DentalTreatmentDefinitionForm extends TTVisual.TTForm implements OnInit {
    Category: TTVisual.ITTEnumComboBox;
    Code: TTVisual.ITTTextBox;
    DentalRequestType: TTVisual.ITTObjectListBox;
    Department0: TTVisual.ITTListBoxColumn;
    Departments: TTVisual.ITTGrid;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    labelCategory: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelDentalRequestType: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    labelToothNumber: TTVisual.ITTLabel;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    ProcedureTree: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    ToothNumber: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    public DepartmentsColumns = [];
    public dentalTreatmentDefinitionFormViewModel: DentalTreatmentDefinitionFormViewModel = new DentalTreatmentDefinitionFormViewModel();
    public get _DentalTreatmentDefinition(): DentalTreatmentDefinition {
        return this._TTObject as DentalTreatmentDefinition;
    }
    private DentalTreatmentDefinitionForm_DocumentUrl: string = '/api/DentalTreatmentDefinitionService/DentalTreatmentDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("DENTALTREATMENTDEFINITION", "DentalTreatmentDefinitionForm");
        this._DocumentServiceUrl = this.DentalTreatmentDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DentalTreatmentDefinition();
        this.dentalTreatmentDefinitionFormViewModel = new DentalTreatmentDefinitionFormViewModel();
        this._ViewModel = this.dentalTreatmentDefinitionFormViewModel;
        this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition = this._TTObject as DentalTreatmentDefinition;
        this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.Departments = new Array<DentalTreatmentDepartmentGrid>();
        this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.DentalRequestType = new DentalRequestTypeDefinition();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.GILDefinition = new GILDefinition();
        this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>(); 
        this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.dentalTreatmentDefinitionFormViewModel = this._ViewModel as DentalTreatmentDefinitionFormViewModel;
        that._TTObject = this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition;
        if (this.dentalTreatmentDefinitionFormViewModel == null)
            this.dentalTreatmentDefinitionFormViewModel = new DentalTreatmentDefinitionFormViewModel();
        if (this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition == null)
            this.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition = new DentalTreatmentDefinition();
        let procedureTreeObjectID = that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.dentalTreatmentDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.ProcedureTree = procedureTree;
            }
        }

    
    that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.Departments = that.dentalTreatmentDefinitionFormViewModel.DepartmentsGridList;
    for(let detailItem of that.dentalTreatmentDefinitionFormViewModel.DepartmentsGridList) {
        let departmentObjectID = detailItem["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === "string")) {
            let department = that.dentalTreatmentDefinitionFormViewModel.ResSections.find(o => o.ObjectID.toString() === departmentObjectID.toString());
            if (department) {
                detailItem.Department = department;
            }
        }

    }

let dentalRequestTypeObjectID = that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition["DentalRequestType"];
if (dentalRequestTypeObjectID != null && (typeof dentalRequestTypeObjectID === "string")) {
    let dentalRequestType = that.dentalTreatmentDefinitionFormViewModel.DentalRequestTypeDefinitions.find(o => o.ObjectID.toString() === dentalRequestTypeObjectID.toString());
    if (dentalRequestType) {
        that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.DentalRequestType = dentalRequestType;
    }
}

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.dentalTreatmentDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.dentalTreatmentDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.GILDefinition = gILDefinition;
            }
        }

        that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.SubProcedureDefinitions = that.dentalTreatmentDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.dentalTreatmentDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.dentalTreatmentDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.dentalTreatmentDefinitionFormViewModel._DentalTreatmentDefinition.RequiredDiagnoseProcedures = that.dentalTreatmentDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.dentalTreatmentDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.dentalTreatmentDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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

public onCategoryChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.Category != event) { 
    this._DentalTreatmentDefinition.Category = event;
}
}

public onCodeChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.Code != event) { 
    this._DentalTreatmentDefinition.Code = event;
}
}

public onDentalRequestTypeChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.DentalRequestType != event) { 
    this._DentalTreatmentDefinition.DentalRequestType = event;
}
}

public onDescriptionChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.Description != event) { 
    this._DentalTreatmentDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.EnglishName != event) { 
    this._DentalTreatmentDefinition.EnglishName = event;
}
}

public onIsActiveChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.IsActive != event) { 
    this._DentalTreatmentDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.MedulaProcedureType != event) { 
    this._DentalTreatmentDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.Name != event) { 
    this._DentalTreatmentDefinition.Name = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.ProcedureTree != event) { 
    this._DentalTreatmentDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.Qref != event) { 
    this._DentalTreatmentDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.SUTAppendix != event) { 
    this._DentalTreatmentDefinition.SUTAppendix = event;
}
}

public onToothNumberChanged(event): void {
    if(this._DentalTreatmentDefinition != null && this._DentalTreatmentDefinition.ToothNumber != event) { 
    this._DentalTreatmentDefinition.ToothNumber = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.Category, "Value", this.__ttObject, "Category");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.ToothNumber, "Value", this.__ttObject, "ToothNumber");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 65;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 64;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 63;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 62;

    this.labelToothNumber = new TTVisual.TTLabel();
    this.labelToothNumber.Text = "Diş No";
    this.labelToothNumber.Name = "labelToothNumber";
    this.labelToothNumber.TabIndex = 61;

    this.ToothNumber = new TTVisual.TTEnumComboBox();
    this.ToothNumber.DataTypeName = "ToothNumberEnum";
    this.ToothNumber.Name = "ToothNumber";
    this.ToothNumber.TabIndex = 60;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Hizmet Grubu";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 59;

    this.ProcedureTree = new TTVisual.TTObjectListBox();
    this.ProcedureTree.ListDefName = "ProcedureTreeListDefinition";
    this.ProcedureTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ProcedureTree.Name = "ProcedureTree";
    this.ProcedureTree.TabIndex = 58;

    this.ttlabel6 = new TTVisual.TTLabel();
    this.ttlabel6.Text = "Bağlı Olduğu";
    this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel6.ForeColor = "#000000";
    this.ttlabel6.Name = "ttlabel6";
    this.ttlabel6.TabIndex = 57;

    this.ttlabel5 = new TTVisual.TTLabel();
    this.ttlabel5.Text = "Yapılacak";
    this.ttlabel5.ForeColor = "#000000";
    this.ttlabel5.Name = "ttlabel5";
    this.ttlabel5.TabIndex = 56;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Birim(ler)";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 55;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Tedavi";
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
    this.Departments.TabIndex = 19;

    this.Department0 = new TTVisual.TTListBoxColumn();
    this.Department0.ListDefName = "ResourceListDefinition";
    this.Department0.DataMember = "Department";
    this.Department0.DisplayIndex = 0;
    this.Department0.HeaderText = "Diş Tedavi Birimleri";
    this.Department0.Name = "Department0";
    this.Department0.Width = 480;

    this.labelDentalRequestType = new TTVisual.TTLabel();
    this.labelDentalRequestType.Text = "Tedavi İstek Türü";
    this.labelDentalRequestType.ForeColor = "#000000";
    this.labelDentalRequestType.Name = "labelDentalRequestType";
    this.labelDentalRequestType.TabIndex = 16;

    this.DentalRequestType = new TTVisual.TTObjectListBox();
    this.DentalRequestType.ListDefName = "DentalRequestTypeListDefinition";
    this.DentalRequestType.Name = "DentalRequestType";
    this.DentalRequestType.TabIndex = 15;

    this.labelCategory = new TTVisual.TTLabel();
    this.labelCategory.Text = "Kategori";
    this.labelCategory.ForeColor = "#000000";
    this.labelCategory.Name = "labelCategory";
    this.labelCategory.TabIndex = 1;

    this.Category = new TTVisual.TTEnumComboBox();
    this.Category.DataTypeName = "DentalRequestTypeEnum";
    this.Category.Name = "Category";
    this.Category.TabIndex = 0;

    this.DepartmentsColumns = [this.Department0];
    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.labelToothNumber, this.ToothNumber, this.ttlabel1, this.ProcedureTree, this.ttlabel6, this.ttlabel5, this.ttlabel3, this.ttlabel2, this.labelQref, this.Qref, this.Name, this.EnglishName, this.Description, this.Code, this.labelName, this.IsActive, this.labelEnglishName, this.labelDescription, this.labelCode, this.Departments, this.Department0, this.labelDentalRequestType, this.DentalRequestType, this.labelCategory, this.Category];

}


}
