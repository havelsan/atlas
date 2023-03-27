//$E55B336E
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { AnesthesiaDefinitionFormViewModel } from './AnesthesiaDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AnesthesiaDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'AnesthesiaDefinitionForm',
    templateUrl: './AnesthesiaDefinitionForm.html',
    providers: [MessageService]
})
export class AnesthesiaDefinitionForm extends TTVisual.TTForm implements OnInit {
    Code: TTVisual.ITTTextBox;
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
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    public anesthesiaDefinitionFormViewModel: AnesthesiaDefinitionFormViewModel = new AnesthesiaDefinitionFormViewModel();
    public get _AnesthesiaDefinition(): AnesthesiaDefinition {
        return this._TTObject as AnesthesiaDefinition;
    }
    private AnesthesiaDefinitionForm_DocumentUrl: string = '/api/AnesthesiaDefinitionService/AnesthesiaDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("ANESTHESIADEFINITION", "AnesthesiaDefinitionForm");
        this._DocumentServiceUrl = this.AnesthesiaDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AnesthesiaDefinition();
        this.anesthesiaDefinitionFormViewModel = new AnesthesiaDefinitionFormViewModel();
        this._ViewModel = this.anesthesiaDefinitionFormViewModel;
        this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition = this._TTObject as AnesthesiaDefinition;
        this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.ProcedureTree = new ProcedureTreeDefinition();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.GILDefinition = new GILDefinition();
        this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();   
        this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.anesthesiaDefinitionFormViewModel = this._ViewModel as AnesthesiaDefinitionFormViewModel;
        that._TTObject = this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition;
        if (this.anesthesiaDefinitionFormViewModel == null)
            this.anesthesiaDefinitionFormViewModel = new AnesthesiaDefinitionFormViewModel();
        if (this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition == null)
            this.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition = new AnesthesiaDefinition();
        let procedureTreeObjectID = that.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.anesthesiaDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.ProcedureTree = procedureTree;
            }
        }

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.anesthesiaDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.anesthesiaDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.GILDefinition = gILDefinition;
            }
        }

        that.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.SubProcedureDefinitions = that.anesthesiaDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.anesthesiaDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.anesthesiaDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.anesthesiaDefinitionFormViewModel._AnesthesiaDefinition.RequiredDiagnoseProcedures = that.anesthesiaDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.anesthesiaDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.anesthesiaDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.Code != event) { 
    this._AnesthesiaDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.Description != event) { 
    this._AnesthesiaDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.EnglishName != event) { 
    this._AnesthesiaDefinition.EnglishName = event;
}
}

public onIsActiveChanged(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.IsActive != event) { 
    this._AnesthesiaDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.MedulaProcedureType != event) { 
    this._AnesthesiaDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.Name != event) { 
    this._AnesthesiaDefinition.Name = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.ProcedureTree != event) { 
    this._AnesthesiaDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.Qref != event) { 
    this._AnesthesiaDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.SUTAppendix != event) { 
    this._AnesthesiaDefinition.SUTAppendix = event;
}
}

public onttcheckbox1Changed(event): void {
    if(this._AnesthesiaDefinition != null && this._AnesthesiaDefinition.Chargable != event) { 
    this._AnesthesiaDefinition.Chargable = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "Chargable");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 52;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 51;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 50;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 49;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Hizmet Grubu";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 48;

    this.ProcedureTree = new TTVisual.TTObjectListBox();
    this.ProcedureTree.ListDefName = "ProcedureTreeListDefinition";
    this.ProcedureTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ProcedureTree.Name = "ProcedureTree";
    this.ProcedureTree.TabIndex = 47;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Bağlı Olduğu";
    this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 46;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Ad";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 38;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 37;

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

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Adı";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 36;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = true;
    this.IsActive.Text = "Aktif";
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

    this.ttcheckbox1 = new TTVisual.TTCheckBox();
    this.ttcheckbox1.Value = true;
    this.ttcheckbox1.Text = "Ücretli";
    this.ttcheckbox1.Name = "ttcheckbox1";
    this.ttcheckbox1.TabIndex = 34;

    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.ttlabel3, this.ProcedureTree, this.ttlabel2, this.labelQref, this.Qref, this.Name, this.EnglishName, this.Description, this.Code, this.labelName, this.IsActive, this.labelEnglishName, this.labelDescription, this.labelCode, this.ttcheckbox1];

}


}
