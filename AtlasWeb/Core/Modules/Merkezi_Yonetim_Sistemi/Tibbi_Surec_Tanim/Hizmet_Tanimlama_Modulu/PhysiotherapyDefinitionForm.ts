//$F78957A5
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PhysiotherapyDefinitionFormViewModel } from './PhysiotherapyDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysiotherapyDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyTreatmentRoomGrid } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyTreatmentUnitGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResTreatmentDiagnosisRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResTreatmentDiagnosisUnit } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'PhysiotherapyDefinitionForm',
    templateUrl: './PhysiotherapyDefinitionForm.html',
    providers: [MessageService]
})
export class PhysiotherapyDefinitionForm extends TTVisual.TTForm  implements OnInit {
    Chargable: TTVisual.ITTCheckBox;
    Code: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    ESWTTransaction: TTVisual.ITTCheckBox;
    ExaminationSubClass: TTVisual.ITTEnumComboBox;
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
    labelTreatmentDuration: TTVisual.ITTLabel;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    OrderNo: TTVisual.ITTTextBox;
    ProcedureTree: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    TreatmentDiagnosisUnit0: TTVisual.ITTListBoxColumn;
    TreatmentDuration: TTVisual.ITTTextBox;
    TreatmentRoom0: TTVisual.ITTListBoxColumn;
    TreatmentRooms: TTVisual.ITTGrid;
    TreatmentUnits: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    public TreatmentRoomsColumns = [];
    public TreatmentUnitsColumns = [];
    public physiotherapyDefinitionFormViewModel: PhysiotherapyDefinitionFormViewModel = new PhysiotherapyDefinitionFormViewModel();
    public get _PhysiotherapyDefinition(): PhysiotherapyDefinition {
        return this._TTObject as PhysiotherapyDefinition;
    }
    private PhysiotherapyDefinitionForm_DocumentUrl: string = '/api/PhysiotherapyDefinitionService/PhysiotherapyDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("PHYSIOTHERAPYDEFINITION", "PhysiotherapyDefinitionForm");
        this._DocumentServiceUrl = this.PhysiotherapyDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PhysiotherapyDefinition();
        this.physiotherapyDefinitionFormViewModel = new PhysiotherapyDefinitionFormViewModel();
        this._ViewModel = this.physiotherapyDefinitionFormViewModel;
        this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition = this._TTObject as PhysiotherapyDefinition;
        this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.TreatmentUnits = new Array<PhysiotherapyTreatmentUnitGrid>();
        this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.TreatmentRooms = new Array<PhysiotherapyTreatmentRoomGrid>();

        this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.PackageProcedure = new PackageProcedureDefinition();
	    this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.GILDefinition = new GILDefinition();
        this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>(); 
        this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.physiotherapyDefinitionFormViewModel = this._ViewModel as PhysiotherapyDefinitionFormViewModel;
        that._TTObject = this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition;
        if (this.physiotherapyDefinitionFormViewModel == null)
            this.physiotherapyDefinitionFormViewModel = new PhysiotherapyDefinitionFormViewModel();
        if (this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition == null)
            this.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition = new PhysiotherapyDefinition();
        let procedureTreeObjectID = that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.physiotherapyDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.ProcedureTree = procedureTree;
            }
        }

    
    that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.TreatmentUnits = that.physiotherapyDefinitionFormViewModel.TreatmentUnitsGridList;
    for(let detailItem of that.physiotherapyDefinitionFormViewModel.TreatmentUnitsGridList) {
        let treatmentDiagnosisUnitObjectID = detailItem["TreatmentDiagnosisUnit"];
        if (treatmentDiagnosisUnitObjectID != null && (typeof treatmentDiagnosisUnitObjectID === "string")) {
            let treatmentDiagnosisUnit = that.physiotherapyDefinitionFormViewModel.ResTreatmentDiagnosisUnits.find(o => o.ObjectID.toString() === treatmentDiagnosisUnitObjectID.toString());
            if (treatmentDiagnosisUnit) {
                detailItem.TreatmentDiagnosisUnit = treatmentDiagnosisUnit;
            }
        }

    }

that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.TreatmentRooms = that.physiotherapyDefinitionFormViewModel.TreatmentRoomsGridList;
for (let detailItem of that.physiotherapyDefinitionFormViewModel.TreatmentRoomsGridList) {
    let treatmentRoomObjectID = detailItem["TreatmentRoom"];
    if (treatmentRoomObjectID != null && (typeof treatmentRoomObjectID === "string")) {
        let treatmentRoom = that.physiotherapyDefinitionFormViewModel.ResTreatmentDiagnosisRooms.find(o => o.ObjectID.toString() === treatmentRoomObjectID.toString());
        if (treatmentRoom) {
            detailItem.TreatmentRoom = treatmentRoom;
        }
    }

}

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.physiotherapyDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.physiotherapyDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.GILDefinition = gILDefinition;
            }
        }

        that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.SubProcedureDefinitions = that.physiotherapyDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.physiotherapyDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.physiotherapyDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.physiotherapyDefinitionFormViewModel._PhysiotherapyDefinition.RequiredDiagnoseProcedures = that.physiotherapyDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.physiotherapyDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.physiotherapyDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.Chargable != event) { 
    this._PhysiotherapyDefinition.Chargable = event;
}
}

public onCodeChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.Code != event) { 
    this._PhysiotherapyDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.Description != event) { 
    this._PhysiotherapyDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.EnglishName != event) { 
    this._PhysiotherapyDefinition.EnglishName = event;
}
}

public onESWTTransactionChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.ESWTTransaction != event) { 
    this._PhysiotherapyDefinition.ESWTTransaction = event;
}
}

public onExaminationSubClassChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.ExaminationSubClass != event) { 
    this._PhysiotherapyDefinition.ExaminationSubClass = event;
}
}

public onIDChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.ID != event) { 
    this._PhysiotherapyDefinition.ID = event;
}
}

public onIsActiveChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.IsActive != event) { 
    this._PhysiotherapyDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.MedulaProcedureType != event) { 
    this._PhysiotherapyDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.Name != event) { 
    this._PhysiotherapyDefinition.Name = event;
}
}

public onOrderNoChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.OrderNo != event) { 
    this._PhysiotherapyDefinition.OrderNo = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.ProcedureTree != event) { 
    this._PhysiotherapyDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.Qref != event) { 
    this._PhysiotherapyDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.SUTAppendix != event) { 
    this._PhysiotherapyDefinition.SUTAppendix = event;
}
}

public onTreatmentDurationChanged(event): void {
    if(this._PhysiotherapyDefinition != null && this._PhysiotherapyDefinition.TreatmentDuration != event) { 
    this._PhysiotherapyDefinition.TreatmentDuration = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.ID, "Text", this.__ttObject, "ID");
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.Chargable, "Value", this.__ttObject, "Chargable");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.ESWTTransaction, "Value", this.__ttObject, "ESWTTransaction");
    redirectProperty(this.TreatmentDuration, "Text", this.__ttObject, "TreatmentDuration");
    redirectProperty(this.OrderNo, "Text", this.__ttObject, "OrderNo");
    redirectProperty(this.ExaminationSubClass, "Value", this.__ttObject, "ExaminationSubClass");
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
    this.labelSUTAppendix.TabIndex = 55;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 54;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 51;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 50;

    this.OrderNo = new TTVisual.TTTextBox();
    this.OrderNo.Name = "OrderNo";
    this.OrderNo.TabIndex = 6;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 2;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Name = "Name";
    this.Name.TabIndex = 8;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 9;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Name = "Description";
    this.Description.TabIndex = 10;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Name = "Code";
    this.Code.TabIndex = 1;

    this.TreatmentDuration = new TTVisual.TTTextBox();
    this.TreatmentDuration.Name = "TreatmentDuration";
    this.TreatmentDuration.TabIndex = 5;

    this.ID = new TTVisual.TTTextBox();
    this.ID.BackColor = "#F0F0F0";
    this.ID.ReadOnly = true;
    this.ID.Name = "ID";
    this.ID.TabIndex = 0;

    this.ESWTTransaction = new TTVisual.TTCheckBox();
    this.ESWTTransaction.Value = false;
    this.ESWTTransaction.Title = "ESWT İşlemi";
    this.ESWTTransaction.Name = "ESWTTransaction";
    this.ESWTTransaction.TabIndex = 49;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Hizmet Grubu";
    this.ttlabel2.BackColor = "#DCDCDC";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 48;

    this.ProcedureTree = new TTVisual.TTObjectListBox();
    this.ProcedureTree.ListDefName = "ProcedureTreeListDefinition";
    this.ProcedureTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ProcedureTree.Name = "ProcedureTree";
    this.ProcedureTree.TabIndex = 11;

    this.ttlabel5 = new TTVisual.TTLabel();
    this.ttlabel5.Text = "Bağlı Olduğu";
    this.ttlabel5.BackColor = "#DCDCDC";
    this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel5.ForeColor = "#000000";
    this.ttlabel5.Name = "ttlabel5";
    this.ttlabel5.TabIndex = 46;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Sıra No";
    this.ttlabel1.BackColor = "#DCDCDC";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 44;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Tetkik Alt Sınıfı";
    this.ttlabel3.BackColor = "#DCDCDC";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 42;

    this.ExaminationSubClass = new TTVisual.TTEnumComboBox();
    this.ExaminationSubClass.DataTypeName = "ExaminationSubClassEnum";
    this.ExaminationSubClass.Name = "ExaminationSubClass";
    this.ExaminationSubClass.TabIndex = 7;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Adı";
    this.labelQref.BackColor = "#DCDCDC";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 38;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Adı";
    this.labelName.BackColor = "#DCDCDC";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 36;

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
    this.labelEnglishName.TabIndex = 33;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.BackColor = "#DCDCDC";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 31;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Kodu";
    this.labelCode.BackColor = "#DCDCDC";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 29;

    this.TreatmentUnits = new TTVisual.TTGrid();
    this.TreatmentUnits.BackColor = "#DCDCDC";
    this.TreatmentUnits.Name = "TreatmentUnits";
    this.TreatmentUnits.TabIndex = 12;

    this.TreatmentDiagnosisUnit0 = new TTVisual.TTListBoxColumn();
    this.TreatmentDiagnosisUnit0.ListDefName = "TreatmentDiagnosisUnitListDefinition";
    this.TreatmentDiagnosisUnit0.DataMember = "TreatmentDiagnosisUnit";
    this.TreatmentDiagnosisUnit0.DisplayIndex = 0;
    this.TreatmentDiagnosisUnit0.HeaderText = "Tanı Tedavi Ünitesi";
    this.TreatmentDiagnosisUnit0.Name = "TreatmentDiagnosisUnit0";
    this.TreatmentDiagnosisUnit0.Width = 250;

    this.TreatmentRooms = new TTVisual.TTGrid();
    this.TreatmentRooms.BackColor = "#DCDCDC";
    this.TreatmentRooms.Name = "TreatmentRooms";
    this.TreatmentRooms.TabIndex = 13;

    this.TreatmentRoom0 = new TTVisual.TTListBoxColumn();
    this.TreatmentRoom0.ListDefName = "TreatmentDiagnosisRoomListDefinition";
    this.TreatmentRoom0.DataMember = "TreatmentRoom";
    this.TreatmentRoom0.DisplayIndex = 0;
    this.TreatmentRoom0.HeaderText = "Tedavi Odası";
    this.TreatmentRoom0.Name = "TreatmentRoom0";
    this.TreatmentRoom0.Width = 250;

    this.labelTreatmentDuration = new TTVisual.TTLabel();
    this.labelTreatmentDuration.Text = "Tedavi Süresi";
    this.labelTreatmentDuration.BackColor = "#DCDCDC";
    this.labelTreatmentDuration.ForeColor = "#000000";
    this.labelTreatmentDuration.Name = "labelTreatmentDuration";
    this.labelTreatmentDuration.TabIndex = 1;

    this.labelID = new TTVisual.TTLabel();
    this.labelID.Text = "ID";
    this.labelID.Name = "labelID";
    this.labelID.TabIndex = 8;

    this.Chargable = new TTVisual.TTCheckBox();
    this.Chargable.Value = true;
    this.Chargable.Text = "Ücretli";
    this.Chargable.Name = "Chargable";
    this.Chargable.TabIndex = 3;

    this.TreatmentUnitsColumns = [this.TreatmentDiagnosisUnit0];
    this.TreatmentRoomsColumns = [this.TreatmentRoom0];
    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.OrderNo, this.Qref, this.Name, this.EnglishName, this.Description, this.Code, this.TreatmentDuration, this.ID, this.ESWTTransaction, this.ttlabel2, this.ProcedureTree, this.ttlabel5, this.ttlabel1, this.ttlabel3, this.ExaminationSubClass, this.labelQref, this.labelName, this.IsActive, this.labelEnglishName, this.labelDescription, this.labelCode, this.TreatmentUnits, this.TreatmentDiagnosisUnit0, this.TreatmentRooms, this.TreatmentRoom0, this.labelTreatmentDuration, this.labelID, this.Chargable];

}


}
