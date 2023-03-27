//$4B0FFBE3
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { BulletinProcedureDefinitionFormViewModel } from './BulletinProcedureDefinitionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BulletinProcedureDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'BulletinProcedureDefinitionForm',
    templateUrl: './BulletinProcedureDefinitionForm.html',
    providers: [MessageService]
})
export class BulletinProcedureDefinitionForm extends TTVisual.TTForm implements OnInit {
    Code: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
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
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    Qref: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    public bulletinProcedureDefinitionFormViewModel: BulletinProcedureDefinitionFormViewModel = new BulletinProcedureDefinitionFormViewModel();
    public get _BulletinProcedureDefinition(): BulletinProcedureDefinition {
        return this._TTObject as BulletinProcedureDefinition;
    }
    private BulletinProcedureDefinitionForm_DocumentUrl: string = '/api/BulletinProcedureDefinitionService/BulletinProcedureDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("BULLETINPROCEDUREDEFINITION", "BulletinProcedureDefinitionForm");
        this._DocumentServiceUrl = this.BulletinProcedureDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BulletinProcedureDefinition();
        this.bulletinProcedureDefinitionFormViewModel = new BulletinProcedureDefinitionFormViewModel();
        this._ViewModel = this.bulletinProcedureDefinitionFormViewModel;
        this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition = this._TTObject as BulletinProcedureDefinition;
        this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.ProcedureTree = new ProcedureTreeDefinition();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.GILDefinition = new GILDefinition();
        this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();  
        this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.bulletinProcedureDefinitionFormViewModel = this._ViewModel as BulletinProcedureDefinitionFormViewModel;
        that._TTObject = this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition;
        if (this.bulletinProcedureDefinitionFormViewModel == null)
            this.bulletinProcedureDefinitionFormViewModel = new BulletinProcedureDefinitionFormViewModel();
        if (this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition == null)
            this.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition = new BulletinProcedureDefinition();
        let procedureTreeObjectID = that.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.bulletinProcedureDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.ProcedureTree = procedureTree;
            }
        }

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.bulletinProcedureDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.bulletinProcedureDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.GILDefinition = gILDefinition;
            }
        }

        that.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.SubProcedureDefinitions = that.bulletinProcedureDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.bulletinProcedureDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.bulletinProcedureDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.bulletinProcedureDefinitionFormViewModel._BulletinProcedureDefinition.RequiredDiagnoseProcedures = that.bulletinProcedureDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.bulletinProcedureDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.bulletinProcedureDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.Code != event) { 
    this._BulletinProcedureDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.Description != event) { 
    this._BulletinProcedureDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.EnglishName != event) { 
    this._BulletinProcedureDefinition.EnglishName = event;
}
}

public onIDChanged(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.ID != event) { 
    this._BulletinProcedureDefinition.ID = event;
}
}

public onIsActiveChanged(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.IsActive != event) { 
    this._BulletinProcedureDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.MedulaProcedureType != event) { 
    this._BulletinProcedureDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.Name != event) { 
    this._BulletinProcedureDefinition.Name = event;
}
}

public onQrefChanged(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.Qref != event) { 
    this._BulletinProcedureDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.SUTAppendix != event) { 
    this._BulletinProcedureDefinition.SUTAppendix = event;
}
}

public onttobjectlistbox1Changed(event): void {
    if(this._BulletinProcedureDefinition != null && this._BulletinProcedureDefinition.ProcedureTree != event) { 
    this._BulletinProcedureDefinition.ProcedureTree = event;
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
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
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

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Description.Name = "Description";
    this.Description.TabIndex = 6;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 8;
    this.EnglishName.Visible = false;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Name.Name = "Name";
    this.Name.TabIndex = 4;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Code.Name = "Code";
    this.Code.TabIndex = 0;

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

    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.Description, this.EnglishName, this.Name, this.Code, this.ID, this.Qref, this.labelName, this.ttobjectlistbox1, this.labelEnglishName, this.ttlabel1, this.labelDescription, this.labelQref, this.IsActive, this.labelCode, this.labelID];

}


}
