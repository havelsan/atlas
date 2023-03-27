//$D6CAE7EC
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { DialysisDefinitionFormViewModel } from './DialysisDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DialysisDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DialysisTreatmentEquipmentGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DialysisTreatmentUnitGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ResTreatmentDiagnosisUnit } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'DialysisDefinitionForm',
    templateUrl: './DialysisDefinitionForm.html',
    providers: [MessageService]
})
export class DialysisDefinitionForm extends TTVisual.TTForm implements OnInit {
    Chargable: TTVisual.ITTCheckBox;
    Code: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    DialysisTreatmentEquipments: TTVisual.ITTGrid;
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
    ProcedureTree: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    TreatmentDiagnosisUnit: TTVisual.ITTListBoxColumn;
    TREATMENTDURATION: TTVisual.ITTTextBox;
    TreatmentEquipment: TTVisual.ITTListBoxColumn;
    TreatmentUnits: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    public DialysisTreatmentEquipmentsColumns = [];
    public TreatmentUnitsColumns = [];
    public dialysisDefinitionFormViewModel: DialysisDefinitionFormViewModel = new DialysisDefinitionFormViewModel();
    public get _DialysisDefinition(): DialysisDefinition {
        return this._TTObject as DialysisDefinition;
    }
    private DialysisDefinitionForm_DocumentUrl: string = '/api/DialysisDefinitionService/DialysisDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("DIALYSISDEFINITION", "DialysisDefinitionForm");
        this._DocumentServiceUrl = this.DialysisDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DialysisDefinition();
        this.dialysisDefinitionFormViewModel = new DialysisDefinitionFormViewModel();
        this._ViewModel = this.dialysisDefinitionFormViewModel;
        this.dialysisDefinitionFormViewModel._DialysisDefinition = this._TTObject as DialysisDefinition;
        this.dialysisDefinitionFormViewModel._DialysisDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.dialysisDefinitionFormViewModel._DialysisDefinition.TreatmentUnits = new Array<DialysisTreatmentUnitGrid>();
        this.dialysisDefinitionFormViewModel._DialysisDefinition.DialysisTreatmentEquipments = new Array<DialysisTreatmentEquipmentGrid>();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.dialysisDefinitionFormViewModel._DialysisDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.dialysisDefinitionFormViewModel._DialysisDefinition.GILDefinition = new GILDefinition();
        this.dialysisDefinitionFormViewModel._DialysisDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();  
        this.dialysisDefinitionFormViewModel._DialysisDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.dialysisDefinitionFormViewModel = this._ViewModel as DialysisDefinitionFormViewModel;
        that._TTObject = this.dialysisDefinitionFormViewModel._DialysisDefinition;
        if (this.dialysisDefinitionFormViewModel == null)
            this.dialysisDefinitionFormViewModel = new DialysisDefinitionFormViewModel();
        if (this.dialysisDefinitionFormViewModel._DialysisDefinition == null)
            this.dialysisDefinitionFormViewModel._DialysisDefinition = new DialysisDefinition();
        let procedureTreeObjectID = that.dialysisDefinitionFormViewModel._DialysisDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.dialysisDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.dialysisDefinitionFormViewModel._DialysisDefinition.ProcedureTree = procedureTree;
            }
        }

    
    that.dialysisDefinitionFormViewModel._DialysisDefinition.TreatmentUnits = that.dialysisDefinitionFormViewModel.TreatmentUnitsGridList;
    for(let detailItem of that.dialysisDefinitionFormViewModel.TreatmentUnitsGridList) {
        let treatmentDiagnosisUnitObjectID = detailItem["TreatmentDiagnosisUnit"];
        if (treatmentDiagnosisUnitObjectID != null && (typeof treatmentDiagnosisUnitObjectID === "string")) {
            let treatmentDiagnosisUnit = that.dialysisDefinitionFormViewModel.ResTreatmentDiagnosisUnits.find(o => o.ObjectID.toString() === treatmentDiagnosisUnitObjectID.toString());
            if (treatmentDiagnosisUnit) {
                detailItem.TreatmentDiagnosisUnit = treatmentDiagnosisUnit;
            }
        }

    }

that.dialysisDefinitionFormViewModel._DialysisDefinition.DialysisTreatmentEquipments = that.dialysisDefinitionFormViewModel.DialysisTreatmentEquipmentsGridList;
for (let detailItem of that.dialysisDefinitionFormViewModel.DialysisTreatmentEquipmentsGridList) {
    let treatmentEquipmentObjectID = detailItem["TreatmentEquipment"];
    if (treatmentEquipmentObjectID != null && (typeof treatmentEquipmentObjectID === "string")) {
        let treatmentEquipment = that.dialysisDefinitionFormViewModel.ResEquipments.find(o => o.ObjectID.toString() === treatmentEquipmentObjectID.toString());
        if (treatmentEquipment) {
            detailItem.TreatmentEquipment = treatmentEquipment;
        }
    }

}

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.dialysisDefinitionFormViewModel._DialysisDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.dialysisDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.dialysisDefinitionFormViewModel._DialysisDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.dialysisDefinitionFormViewModel._DialysisDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.dialysisDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.dialysisDefinitionFormViewModel._DialysisDefinition.GILDefinition = gILDefinition;
            }
        }

        that.dialysisDefinitionFormViewModel._DialysisDefinition.SubProcedureDefinitions = that.dialysisDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.dialysisDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.dialysisDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.dialysisDefinitionFormViewModel._DialysisDefinition.RequiredDiagnoseProcedures = that.dialysisDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.dialysisDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.dialysisDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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

public onChargableChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.Chargable != event) { 
    this._DialysisDefinition.Chargable = event;
}
}

public onCodeChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.Code != event) { 
    this._DialysisDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.Description != event) { 
    this._DialysisDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.EnglishName != event) { 
    this._DialysisDefinition.EnglishName = event;
}
}

public onIDChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.ID != event) { 
    this._DialysisDefinition.ID = event;
}
}

public onIsActiveChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.IsActive != event) { 
    this._DialysisDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.MedulaProcedureType != event) { 
    this._DialysisDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.Name != event) { 
    this._DialysisDefinition.Name = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.ProcedureTree != event) { 
    this._DialysisDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.Qref != event) { 
    this._DialysisDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.SUTAppendix != event) { 
    this._DialysisDefinition.SUTAppendix = event;
}
}

public onTREATMENTDURATIONChanged(event): void {
    if(this._DialysisDefinition != null && this._DialysisDefinition.TreatmentDuration != event) { 
    this._DialysisDefinition.TreatmentDuration = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.ID, "Text", this.__ttObject, "ID");
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.Chargable, "Value", this.__ttObject, "Chargable");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.TREATMENTDURATION, "Text", this.__ttObject, "TreatmentDuration");
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

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Hizmet Grubu";
    this.ttlabel3.BackColor = "#DCDCDC";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 61;

    this.ProcedureTree = new TTVisual.TTObjectListBox();
    this.ProcedureTree.ListDefName = "ProcedureTreeListDefinition";
    this.ProcedureTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ProcedureTree.Name = "ProcedureTree";
    this.ProcedureTree.TabIndex = 8;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Bağlı Olduğu";
    this.ttlabel1.BackColor = "#DCDCDC";
    this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 59;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Adı";
    this.labelName.BackColor = "#DCDCDC";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 54;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Name = "Name";
    this.Name.TabIndex = 5;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 6;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Name = "Description";
    this.Description.TabIndex = 7;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Name = "Code";
    this.Code.TabIndex = 1;

    this.TREATMENTDURATION = new TTVisual.TTTextBox();
    this.TREATMENTDURATION.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TREATMENTDURATION.Name = "TREATMENTDURATION";
    this.TREATMENTDURATION.TabIndex = 9;

    this.ID = new TTVisual.TTTextBox();
    this.ID.BackColor = "#F0F0F0";
    this.ID.ReadOnly = true;
    this.ID.Name = "ID";
    this.ID.TabIndex = 0;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 2;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = true;
    this.IsActive.Text = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 4;

    this.labelEnglishName = new TTVisual.TTLabel();
    this.labelEnglishName.Text = "İngilizce Adı";
    this.labelEnglishName.BackColor = "#DCDCDC";
    this.labelEnglishName.ForeColor = "#000000";
    this.labelEnglishName.Name = "labelEnglishName";
    this.labelEnglishName.TabIndex = 51;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.BackColor = "#DCDCDC";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 49;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Kodu";
    this.labelCode.BackColor = "#DCDCDC";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 47;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Tedavi Süresi";
    this.ttlabel2.BackColor = "#DCDCDC";
    this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 31;

    this.Chargable = new TTVisual.TTCheckBox();
    this.Chargable.Value = true;
    this.Chargable.Text = "Ücretli";
    this.Chargable.Name = "Chargable";
    this.Chargable.TabIndex = 3;

    this.labelID = new TTVisual.TTLabel();
    this.labelID.Text = "ID";
    this.labelID.Name = "labelID";
    this.labelID.TabIndex = 8;

    this.TreatmentUnits = new TTVisual.TTGrid();
    this.TreatmentUnits.Name = "TreatmentUnits";
    this.TreatmentUnits.TabIndex = 10;

    this.TreatmentDiagnosisUnit = new TTVisual.TTListBoxColumn();
    this.TreatmentDiagnosisUnit.ListDefName = "TreatmentDiagnosisUnitListDefinition";
    this.TreatmentDiagnosisUnit.DataMember = "TreatmentDiagnosisUnit";
    this.TreatmentDiagnosisUnit.DisplayIndex = 0;
    this.TreatmentDiagnosisUnit.HeaderText = "Tanı Tedavi Üniteleri";
    this.TreatmentDiagnosisUnit.Name = "TreatmentDiagnosisUnit";
    this.TreatmentDiagnosisUnit.Width = 250;

    this.DialysisTreatmentEquipments = new TTVisual.TTGrid();
    this.DialysisTreatmentEquipments.Name = "DialysisTreatmentEquipments";
    this.DialysisTreatmentEquipments.TabIndex = 11;

    this.TreatmentEquipment = new TTVisual.TTListBoxColumn();
    this.TreatmentEquipment.ListDefName = "EquipmentListDefinition";
    this.TreatmentEquipment.DataMember = "TreatmentEquipment";
    this.TreatmentEquipment.DisplayIndex = 0;
    this.TreatmentEquipment.HeaderText = "Tedavi Cihazı";
    this.TreatmentEquipment.Name = "TreatmentEquipment";
    this.TreatmentEquipment.Width = 250;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Adı";
    this.labelQref.BackColor = "#DCDCDC";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 38;

    this.TreatmentUnitsColumns = [this.TreatmentDiagnosisUnit];
    this.DialysisTreatmentEquipmentsColumns = [this.TreatmentEquipment];
    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.ttlabel3, this.ProcedureTree, this.ttlabel1, this.labelName, this.Name, this.EnglishName, this.Description, this.Code, this.TREATMENTDURATION, this.ID, this.Qref, this.IsActive, this.labelEnglishName, this.labelDescription, this.labelCode, this.ttlabel2, this.Chargable, this.labelID, this.TreatmentUnits, this.TreatmentDiagnosisUnit, this.DialysisTreatmentEquipments, this.TreatmentEquipment, this.labelQref];

}


}
