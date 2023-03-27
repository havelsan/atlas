//$3B885636
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PackageProcedureDefinitionFormViewModel } from './PackageProcedureDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'PackageProcedureDefinitionForm',
    templateUrl: './PackageProcedureDefinitionForm.html',
    providers: [MessageService]
})
export class PackageProcedureDefinitionForm extends TTVisual.TTForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    holidaysIncluded: TTVisual.ITTCheckBox;
    ID: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    labelCode: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    lblType: TTVisual.ITTLabel;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    Qref: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    Type: TTVisual.ITTEnumComboBox;
    public packageProcedureDefinitionFormViewModel: PackageProcedureDefinitionFormViewModel = new PackageProcedureDefinitionFormViewModel();
    public get _PackageProcedureDefinition(): PackageProcedureDefinition {
        return this._TTObject as PackageProcedureDefinition;
    }
    private PackageProcedureDefinitionForm_DocumentUrl: string = '/api/PackageProcedureDefinitionService/PackageProcedureDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("PACKAGEPROCEDUREDEFINITION", "PackageProcedureDefinitionForm");
        this._DocumentServiceUrl = this.PackageProcedureDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PackageProcedureDefinition();
        this.packageProcedureDefinitionFormViewModel = new PackageProcedureDefinitionFormViewModel();
        this._ViewModel = this.packageProcedureDefinitionFormViewModel;
        this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition = this._TTObject as PackageProcedureDefinition;
        this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.ProcedureTree = new ProcedureTreeDefinition();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.GILDefinition = new GILDefinition();
        this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();
        this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.packageProcedureDefinitionFormViewModel = this._ViewModel as PackageProcedureDefinitionFormViewModel;
        that._TTObject = this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition;
        if (this.packageProcedureDefinitionFormViewModel == null)
            this.packageProcedureDefinitionFormViewModel = new PackageProcedureDefinitionFormViewModel();
        if (this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition == null)
            this.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition = new PackageProcedureDefinition();
        let procedureTreeObjectID = that.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.packageProcedureDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.ProcedureTree = procedureTree;
            }
        }

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.packageProcedureDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.packageProcedureDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.GILDefinition = gILDefinition;
            }
        }

        that.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.SubProcedureDefinitions = that.packageProcedureDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.packageProcedureDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.packageProcedureDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.packageProcedureDefinitionFormViewModel._PackageProcedureDefinition.RequiredDiagnoseProcedures = that.packageProcedureDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.packageProcedureDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.packageProcedureDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.Code != event) { 
    this._PackageProcedureDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.Description != event) { 
    this._PackageProcedureDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.EnglishName != event) { 
    this._PackageProcedureDefinition.EnglishName = event;
}
}

public onholidaysIncludedChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.HolidaysIncluded != event) { 
    this._PackageProcedureDefinition.HolidaysIncluded = event;
}
}

public onIDChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.ID != event) { 
    this._PackageProcedureDefinition.ID = event;
}
}

public onIsActiveChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.IsActive != event) { 
    this._PackageProcedureDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.MedulaProcedureType != event) { 
    this._PackageProcedureDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.Name != event) { 
    this._PackageProcedureDefinition.Name = event;
}
}

public onQrefChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.Qref != event) { 
    this._PackageProcedureDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.SUTAppendix != event) { 
    this._PackageProcedureDefinition.SUTAppendix = event;
}
}

public onttobjectlistbox1Changed(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.ProcedureTree != event) { 
    this._PackageProcedureDefinition.ProcedureTree = event;
}
}

public onTypeChanged(event): void {
    if(this._PackageProcedureDefinition != null && this._PackageProcedureDefinition.Type != event) { 
    this._PackageProcedureDefinition.Type = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.ID, "Text", this.__ttObject, "ID");
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.Type, "Value", this.__ttObject, "Type");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.holidaysIncluded, "Value", this.__ttObject, "HolidaysIncluded");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 21;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 20;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 19;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 18;

    this.lblType = new TTVisual.TTLabel();
    this.lblType.Text = "Tür";
    this.lblType.Name = "lblType";
    this.lblType.TabIndex = 15;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Ad";
    this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 12;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Description.Name = "Description";
    this.Description.TabIndex = 6;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 2;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Code.Name = "Code";
    this.Code.TabIndex = 1;

    this.ID = new TTVisual.TTTextBox();
    this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ID.Name = "ID";
    this.ID.TabIndex = 0;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 8;
    this.EnglishName.Visible = false;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Name.Name = "Name";
    this.Name.TabIndex = 4;

    this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox1.ListDefName = "ProcedureTreeListDefinition";
    this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttobjectlistbox1.Name = "ttobjectlistbox1";
    this.ttobjectlistbox1.TabIndex = 5;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Kod";
    this.labelCode.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 10;

    this.labelEnglishName = new TTVisual.TTLabel();
    this.labelEnglishName.Text = "İngilizce Ad";
    this.labelEnglishName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelEnglishName.ForeColor = "#000000";
    this.labelEnglishName.Name = "labelEnglishName";
    this.labelEnglishName.TabIndex = 7;
    this.labelEnglishName.Visible = false;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Bağlı Olduğu Hizmet Grubu";
    this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 13;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = false;
    this.IsActive.Text = "Aktif";
    this.IsActive.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 3;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Ad";
    this.labelQref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 11;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 14;

    this.labelID = new TTVisual.TTLabel();
    this.labelID.Text = "No";
    this.labelID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelID.ForeColor = "#000000";
    this.labelID.Name = "labelID";
    this.labelID.TabIndex = 9;

    this.Type = new TTVisual.TTEnumComboBox();
    this.Type.DataTypeName = "PackageProcedureTypeEnum";
    this.Type.Name = "Type";
    this.Type.TabIndex = 17;

    this.holidaysIncluded = new TTVisual.TTCheckBox();
    this.holidaysIncluded.Value = false;
    this.holidaysIncluded.Title = "Tatiller Dahil";
    this.holidaysIncluded.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.holidaysIncluded.Name = "holidaysIncluded";
    this.holidaysIncluded.TabIndex = 3;

    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.lblType, this.labelName, this.Description, this.Qref, this.Code, this.ID, this.EnglishName, this.Name, this.ttobjectlistbox1, this.labelCode, this.labelEnglishName, this.ttlabel1, this.IsActive, this.labelQref, this.labelDescription, this.labelID, this.Type, this.holidaysIncluded];

}


}
