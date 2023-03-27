//$B1FFFA10
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { EstheticAlternativeProcedureDefinitionFormViewModel } from './EstheticAlternativeProcedureDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EstheticAlternativeProcedureDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'EstheticAlternativeProcedureDefinitionForm',
    templateUrl: './EstheticAlternativeProcedureDefinitionForm.html',
    providers: [MessageService]
})
export class EstheticAlternativeProcedureDefinitionForm extends TTVisual.TTForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    ID: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    labelCode: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    Qref: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    public estheticAlternativeProcedureDefinitionFormViewModel: EstheticAlternativeProcedureDefinitionFormViewModel = new EstheticAlternativeProcedureDefinitionFormViewModel();
    public get _EstheticAlternativeProcedureDefinition(): EstheticAlternativeProcedureDefinition {
        return this._TTObject as EstheticAlternativeProcedureDefinition;
    }
    private EstheticAlternativeProcedureDefinitionForm_DocumentUrl: string = '/api/EstheticAlternativeProcedureDefinitionService/EstheticAlternativeProcedureDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("ESTHETICALTERNATIVEPROCEDUREDEFINITION", "EstheticAlternativeProcedureDefinitionForm");
        this._DocumentServiceUrl = this.EstheticAlternativeProcedureDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EstheticAlternativeProcedureDefinition();
        this.estheticAlternativeProcedureDefinitionFormViewModel = new EstheticAlternativeProcedureDefinitionFormViewModel();
        this._ViewModel = this.estheticAlternativeProcedureDefinitionFormViewModel;
        this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition = this._TTObject as EstheticAlternativeProcedureDefinition;
        this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.ProcedureTree = new ProcedureTreeDefinition();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.GILDefinition = new GILDefinition();
        this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>(); 
        this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.estheticAlternativeProcedureDefinitionFormViewModel = this._ViewModel as EstheticAlternativeProcedureDefinitionFormViewModel;
        that._TTObject = this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition;
        if (this.estheticAlternativeProcedureDefinitionFormViewModel == null)
            this.estheticAlternativeProcedureDefinitionFormViewModel = new EstheticAlternativeProcedureDefinitionFormViewModel();
        if (this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition == null)
            this.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition = new EstheticAlternativeProcedureDefinition();
        let procedureTreeObjectID = that.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.estheticAlternativeProcedureDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.ProcedureTree = procedureTree;
            }
        }

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.estheticAlternativeProcedureDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.estheticAlternativeProcedureDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.GILDefinition = gILDefinition;
            }
        }

        that.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.SubProcedureDefinitions = that.estheticAlternativeProcedureDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.estheticAlternativeProcedureDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.estheticAlternativeProcedureDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.estheticAlternativeProcedureDefinitionFormViewModel._EstheticAlternativeProcedureDefinition.RequiredDiagnoseProcedures = that.estheticAlternativeProcedureDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.estheticAlternativeProcedureDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.estheticAlternativeProcedureDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.Code != event) { 
    this._EstheticAlternativeProcedureDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.Description != event) { 
    this._EstheticAlternativeProcedureDefinition.Description = event;
}
}

public onIDChanged(event): void {
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.ID != event) { 
    this._EstheticAlternativeProcedureDefinition.ID = event;
}
}

public onIsActiveChanged(event): void {
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.IsActive != event) { 
    this._EstheticAlternativeProcedureDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.MedulaProcedureType != event) { 
    this._EstheticAlternativeProcedureDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.Name != event) { 
    this._EstheticAlternativeProcedureDefinition.Name = event;
}
}

public onQrefChanged(event): void {
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.Qref != event) { 
    this._EstheticAlternativeProcedureDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.SUTAppendix != event) { 
    this._EstheticAlternativeProcedureDefinition.SUTAppendix = event;
}
}

public onttobjectlistbox1Changed(event): void {
    if(this._EstheticAlternativeProcedureDefinition != null && this._EstheticAlternativeProcedureDefinition.ProcedureTree != event) { 
    this._EstheticAlternativeProcedureDefinition.ProcedureTree = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.ID, "Text", this.__ttObject, "ID");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 18;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 17;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 16;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 15;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Code.Name = "Code";
    this.Code.TabIndex = 0;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Name.Name = "Name";
    this.Name.TabIndex = 4;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Description.Name = "Description";
    this.Description.TabIndex = 6;

    this.ID = new TTVisual.TTTextBox();
    this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ID.Name = "ID";
    this.ID.TabIndex = 2;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 1;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Ad";
    this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 12;

    this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox1.ListDefName = "ProcedureTreeListDefinition";
    this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttobjectlistbox1.Name = "ttobjectlistbox1";
    this.ttobjectlistbox1.TabIndex = 5;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Bağlı Olduğu Hizmet Grubu";
    this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 13;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 14;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Ad";
    this.labelQref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 10;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = true;
    this.IsActive.Text = "Aktif";
    this.IsActive.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 3;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Kod";
    this.labelCode.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 9;

    this.labelID = new TTVisual.TTLabel();
    this.labelID.Text = "No";
    this.labelID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelID.ForeColor = "#000000";
    this.labelID.Name = "labelID";
    this.labelID.TabIndex = 11;

    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.Code, this.Name, this.Description, this.ID, this.Qref, this.labelName, this.ttobjectlistbox1, this.ttlabel1, this.labelDescription, this.labelQref, this.IsActive, this.labelCode, this.labelID];

}


}
