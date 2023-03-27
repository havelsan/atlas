//$EFC29092
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { RadiologyTestDefinitionFormViewModel } from './RadiologyTestDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Dictionary } from 'NebulaClient/System/Collections/Dictionaries/Dictionary';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { RadiologyTestDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyGridDepartmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyGridEquipmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyGridMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyGridRestrictedTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyGridTestDescriptionDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTabDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTabNamesGrid } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTestDescriptionDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTestTMDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTestTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSLOINC } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'RadiologyTestDefinitionForm',
    templateUrl: './RadiologyTestDefinitionForm.html',
    providers: [MessageService]
})
export class RadiologyTestDefinitionForm extends TTVisual.TTForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    chkAccessionModality: TTVisual.ITTCheckBox;
    chkFriday: TTVisual.ITTCheckBox;
    chkMonday: TTVisual.ITTCheckBox;
    chkSaturday: TTVisual.ITTCheckBox;
    chkSunday: TTVisual.ITTCheckBox;
    chkThursday: TTVisual.ITTCheckBox;
    chkTuesday: TTVisual.ITTCheckBox;
    chkWednesday: TTVisual.ITTCheckBox;
    chlPassiveNow: TTVisual.ITTCheckBox;
    Code: TTVisual.ITTTextBox;
    Department: TTVisual.ITTListBoxColumn;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    Equipment: TTVisual.ITTListBoxColumn;
    ID: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    labelBodyPart: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTListBoxColumn;
    OrderNo: TTVisual.ITTTextBoxColumn;
    Qref: TTVisual.ITTTextBox;
    labelPreInformation: TTVisual.ITTLabel;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    TabNameGrid: TTVisual.ITTGrid;
    PreInformation: TTVisual.ITTTextBox;
    TabNames: TTVisual.ITTListBoxColumn;
    TabOrder: TTVisual.ITTTextBoxColumn;
    TabRow: TTVisual.ITTTextBox;
    Test: TTVisual.ITTListBoxColumn;
    TestType: TTVisual.ITTObjectListBox;
    TimeLimit: TTVisual.ITTTextBox;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttcheckbox2: TTVisual.ITTCheckBox;
    ttcheckbox3: TTVisual.ITTCheckBox;
    ttenumcombobox1: TTVisual.ITTEnumComboBox;
    ttenumcombobox2: TTVisual.ITTEnumComboBox;
    ttgrid1: TTVisual.ITTGrid;
    ttgrid2: TTVisual.ITTGrid;
    ttgrid3: TTVisual.ITTGrid;
    ttgrid4: TTVisual.ITTGrid;
    ttgrid5: TTVisual.ITTGrid;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    TTListBox: TTVisual.ITTObjectListBox;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttobjectlistbox2: TTVisual.ITTObjectListBox;
    ttobjectlistbox3: TTVisual.ITTObjectListBox;
    ttobjectlistbox4: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttabpage5: TTVisual.ITTTabPage;
    tttabpage6: TTVisual.ITTTabPage;
    tttabpage7: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttabpage8: TTVisual.ITTTabPage;
    txtReasonForPassive: TTVisual.ITTTextBox;
    public TabNameGridColumns = [];
    public ttgrid1Columns = [];
    public ttgrid2Columns = [];
    public ttgrid3Columns = [];
    public ttgrid4Columns = [];
    public ttgrid5Columns = [];
    public radiologyTestDefinitionFormViewModel: RadiologyTestDefinitionFormViewModel = new RadiologyTestDefinitionFormViewModel();
    public get _RadiologyTestDefinition(): RadiologyTestDefinition {
        return this._TTObject as RadiologyTestDefinition;
    }
    private RadiologyTestDefinitionForm_DocumentUrl: string = '/api/RadiologyTestDefinitionService/RadiologyTestDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('RADIOLOGYTESTDEFINITION', 'RadiologyTestDefinitionForm');
        this._DocumentServiceUrl = this.RadiologyTestDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async ttobjectlistbox3_SelectedObjectChanged(): Promise<void> {

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        // let dictionary: Dictionary<string, Object> = new Dictionary<string, Object>();
        // // Aynı Bölüm Kontrolü
        // for (let i: number = 0; i < this._RadiologyTestDefinition.Departments.length; i++) {
        //     let Code: string = this._RadiologyTestDefinition.Departments[i].Department.Name.toString();
        //     if (dictionary.containsKey(Code)) {
        //         throw new Exception('Aynı Bölüm eklenmiş!');
        //     }
        //     else {
        //         dictionary.push({key:Code, value: this._TTObject});
        //     }
        // }
        // dictionary.clear();
        // // Aynı Cihaz Kontrolü
        // for (let i: number = 0; i < this._RadiologyTestDefinition.Equipments.length; i++) {
        //     let Code: string = this._RadiologyTestDefinition.Equipments[i].Equipment.Name.toString();
        //     if (dictionary.containsKey(Code)) {
        //         throw new Exception('Aynı Cihaz eklenmiş!');
        //     }
        //     else {
        //         dictionary.push({key:Code, value: this._TTObject});
        //     }
        // }
        // dictionary.clear();

        // if (!(this._RadiologyTestDefinition.TestID.Value !== undefined))
        //     this._RadiologyTestDefinition.TestID.GetNextValue();
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTestDefinition();
        this.radiologyTestDefinitionFormViewModel = new RadiologyTestDefinitionFormViewModel();
        this._ViewModel = this.radiologyTestDefinitionFormViewModel;
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition = this._TTObject as RadiologyTestDefinition;
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TMRadTest = new RadiologyTestTMDefinition();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TabNames = new Array<RadiologyTabNamesGrid>();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TestType = new RadiologyTestTypeDefinition();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TestSubType = new RadiologyTestTypeDefinition();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TestTab = new RadiologyTabDefinition();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.Restricteds = new Array<RadiologyGridRestrictedTestDefinition>();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.Departments = new Array<RadiologyGridDepartmentDefinition>();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.Equipments = new Array<RadiologyGridEquipmentDefinition>();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.Materials = new Array<RadiologyGridMaterialDefinition>();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.RadiologyTestDescriptions = new Array<RadiologyGridTestDescriptionDefinition>();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.SKRSLoincKodu = new SKRSLOINC();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.GILDefinition = new GILDefinition();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();
        this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestDefinitionFormViewModel = this._ViewModel as RadiologyTestDefinitionFormViewModel;
        that._TTObject = this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition;
        if (this.radiologyTestDefinitionFormViewModel == null)
            this.radiologyTestDefinitionFormViewModel = new RadiologyTestDefinitionFormViewModel();
        if (this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition == null)
            this.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition = new RadiologyTestDefinition();
        let tMRadTestObjectID = that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition["TMRadTest"];
        if (tMRadTestObjectID != null && (typeof tMRadTestObjectID === "string")) {
            let tMRadTest = that.radiologyTestDefinitionFormViewModel.RadiologyTestTMDefinitions.find(o => o.ObjectID.toString() === tMRadTestObjectID.toString());
            if (tMRadTest) {
                that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TMRadTest = tMRadTest;
            }
        }

    that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TabNames = that.radiologyTestDefinitionFormViewModel.TabNameGridGridList;
    for(let detailItem of that.radiologyTestDefinitionFormViewModel.TabNameGridGridList) {
        let requestFormTabObjectID = detailItem["RequestFormTab"];
        if (requestFormTabObjectID != null && (typeof requestFormTabObjectID === "string")) {
            let requestFormTab = that.radiologyTestDefinitionFormViewModel.RadiologyTabDefinitions.find(o => o.ObjectID.toString() === requestFormTabObjectID.toString());
            if (requestFormTab) {
                detailItem.RequestFormTab = requestFormTab;
            }
        }

    }

let testTypeObjectID = that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition["TestType"];
if (testTypeObjectID != null && (typeof testTypeObjectID === "string")) {
    let testType = that.radiologyTestDefinitionFormViewModel.RadiologyTestTypeDefinitions.find(o => o.ObjectID.toString() === testTypeObjectID.toString());
    if (testType) {
        that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TestType = testType;
    }
}

let testSubTypeObjectID = that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition["TestSubType"];
if (testSubTypeObjectID != null && (typeof testSubTypeObjectID === "string")) {
    let testSubType = that.radiologyTestDefinitionFormViewModel.RadiologyTestTypeDefinitions.find(o => o.ObjectID.toString() === testSubTypeObjectID.toString());
    if (testSubType) {
        that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TestSubType = testSubType;
    }
}

let testTabObjectID = that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition["TestTab"];
if (testTabObjectID != null && (typeof testTabObjectID === "string")) {
    let testTab = that.radiologyTestDefinitionFormViewModel.RadiologyTabDefinitions.find(o => o.ObjectID.toString() === testTabObjectID.toString());
    if (testTab) {
        that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.TestTab = testTab;
    }
}

let procedureTreeObjectID = that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition["ProcedureTree"];
if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
    let procedureTree = that.radiologyTestDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
    if (procedureTree) {
        that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.ProcedureTree = procedureTree;
    }
}


that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.Restricteds = that.radiologyTestDefinitionFormViewModel.ttgrid2GridList;
for (let detailItem of that.radiologyTestDefinitionFormViewModel.ttgrid2GridList) {
    let testObjectID = detailItem["Test"];
    if (testObjectID != null && (typeof testObjectID === "string")) {
        let test = that.radiologyTestDefinitionFormViewModel.RadiologyTestDefinitions.find(o => o.ObjectID.toString() === testObjectID.toString());
        if (test) {
            detailItem.Test = test;
        }
    }

}

that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.Departments = that.radiologyTestDefinitionFormViewModel.ttgrid3GridList;
for (let detailItem of that.radiologyTestDefinitionFormViewModel.ttgrid3GridList) {
    let departmentObjectID = detailItem["Department"];
    if (departmentObjectID != null && (typeof departmentObjectID === "string")) {
        let department = that.radiologyTestDefinitionFormViewModel.ResRadiologyDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
        if (department) {
            detailItem.Department = department;
        }
    }

}

that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.Equipments = that.radiologyTestDefinitionFormViewModel.ttgrid4GridList;
for (let detailItem of that.radiologyTestDefinitionFormViewModel.ttgrid4GridList) {
    let equipmentObjectID = detailItem["Equipment"];
    if (equipmentObjectID != null && (typeof equipmentObjectID === "string")) {
        let equipment = that.radiologyTestDefinitionFormViewModel.ResRadiologyEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
        if (equipment) {
            detailItem.Equipment = equipment;
        }
    }

}

that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.Materials = that.radiologyTestDefinitionFormViewModel.ttgrid1GridList;
for (let detailItem of that.radiologyTestDefinitionFormViewModel.ttgrid1GridList) {
    let materialObjectID = detailItem["Material"];
    if (materialObjectID != null && (typeof materialObjectID === "string")) {
        let material = that.radiologyTestDefinitionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
        if (material) {
            detailItem.Material = material;
        }
    }

}

that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.RadiologyTestDescriptions = that.radiologyTestDefinitionFormViewModel.ttgrid5GridList;
for (let detailItem of that.radiologyTestDefinitionFormViewModel.ttgrid5GridList) {
    let testDescriptionObjectID = detailItem["TestDescription"];
    if (testDescriptionObjectID != null && (typeof testDescriptionObjectID === "string")) {
        let testDescription = that.radiologyTestDefinitionFormViewModel.RadiologyTestDescriptionDefinitions.find(o => o.ObjectID.toString() === testDescriptionObjectID.toString());
        if (testDescription) {
            detailItem.TestDescription = testDescription;
        }
    }

}

let sKRSLoincKoduObjectID = that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition["SKRSLoincKodu"];
if (sKRSLoincKoduObjectID != null && (typeof sKRSLoincKoduObjectID === "string")) {
    let sKRSLoincKodu = that.radiologyTestDefinitionFormViewModel.SKRSLOINCs.find(o => o.ObjectID.toString() === sKRSLoincKoduObjectID.toString());
    if (sKRSLoincKodu) {
        that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.SKRSLoincKodu = sKRSLoincKodu;
    }
}

let packageProcedureObjectID = that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition["PackageProcedure"];
if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
    let packageProcedure = that.radiologyTestDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
    if (packageProcedure) {
        that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.PackageProcedure = packageProcedure;
    }
}

let gILDefinitionObjectID = that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition["GILDefinition"];
if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
    let gILDefinition = that.radiologyTestDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
    if (gILDefinition) {
        that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.GILDefinition = gILDefinition;
    }
}

that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.SubProcedureDefinitions = that.radiologyTestDefinitionFormViewModel.GridSubProceduresGridList;
for (let detailItem of that.radiologyTestDefinitionFormViewModel.GridSubProceduresGridList) {
    let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
    if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
        let childProcedureDefinition = that.radiologyTestDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
        if (childProcedureDefinition) {
            detailItem.ChildProcedureDefinition = childProcedureDefinition;
        }
    }

}


        that.radiologyTestDefinitionFormViewModel._RadiologyTestDefinition.RequiredDiagnoseProcedures = that.radiologyTestDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.radiologyTestDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.radiologyTestDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
                if (diagnosisDefinition) {
                    detailItem.DiagnosisDefinition = diagnosisDefinition;
                }
            }
        }
}

async ngOnInit() {
    await this.load();
}

public onchkAccessionModalityChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.AccessionModalityRequires != event) { 
    this._RadiologyTestDefinition.AccessionModalityRequires = event;
}
}

public onchkFridayChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.OnFriday != event) { 
    this._RadiologyTestDefinition.OnFriday = event;
}
}

public onchkMondayChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.OnMonday != event) { 
    this._RadiologyTestDefinition.OnMonday = event;
}
}

public onchkSaturdayChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.OnSaturday != event) { 
    this._RadiologyTestDefinition.OnSaturday = event;
}
}

public onchkSundayChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.OnSunday != event) { 
    this._RadiologyTestDefinition.OnSunday = event;
}
}

public onchkThursdayChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.OnThursday != event) { 
    this._RadiologyTestDefinition.OnThursday = event;
}
}

public onchkTuesdayChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.OnTuesday != event) { 
    this._RadiologyTestDefinition.OnTuesday = event;
}
}

public onchkWednesdayChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.OnWednesday != event) { 
    this._RadiologyTestDefinition.OnWednesday = event;
}
}

public onchlPassiveNowChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.IsPassiveNow != event) { 
    this._RadiologyTestDefinition.IsPassiveNow = event;
}
}

public onCodeChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.Code != event) { 
    this._RadiologyTestDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.Description != event) { 
    this._RadiologyTestDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.EnglishName != event) { 
    this._RadiologyTestDefinition.EnglishName = event;
}
}

public onIDChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.TestID != event) { 
    this._RadiologyTestDefinition.TestID = event;
}
}

public onIsActiveChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.IsActive != event) { 
    this._RadiologyTestDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.MedulaProcedureType != event) { 
    this._RadiologyTestDefinition.MedulaProcedureType = event;
}
}

public onQrefChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.Qref != event) { 
    this._RadiologyTestDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.SUTAppendix != event) { 
    this._RadiologyTestDefinition.SUTAppendix = event;
}
}

public onTabRowChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.TabRow != event) { 
    this._RadiologyTestDefinition.TabRow = event;
}
}

public onTestTypeChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.TestType != event) { 
    this._RadiologyTestDefinition.TestType = event;
}
}

public onTimeLimitChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.TimeLimit != event) { 
    this._RadiologyTestDefinition.TimeLimit = event;
}
}

public onttcheckbox1Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.IsRestrictedTest != event) { 
    this._RadiologyTestDefinition.IsRestrictedTest = event;
}
}

public onttcheckbox2Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.IsHeader != event) { 
    this._RadiologyTestDefinition.IsHeader = event;
}
}

public onttcheckbox3Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.IsRISEntegratedTest != event) { 
    this._RadiologyTestDefinition.IsRISEntegratedTest = event;
}
}

public onttenumcombobox1Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.BodyPart != event) { 
    this._RadiologyTestDefinition.BodyPart = event;
}
}

public onttenumcombobox2Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.SexControl != event) { 
    this._RadiologyTestDefinition.SexControl = event;
}
}

public onTTListBoxChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.SKRSLoincKodu != event) { 
    this._RadiologyTestDefinition.SKRSLoincKodu = event;
}
}

public onttobjectlistbox1Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.TestSubType != event) { 
    this._RadiologyTestDefinition.TestSubType = event;
}
}

public onttobjectlistbox2Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.TestTab != event) { 
    this._RadiologyTestDefinition.TestTab = event;
}
}

public onttobjectlistbox3Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.TMRadTest != event) { 
    this._RadiologyTestDefinition.TMRadTest = event;
}
    }
    public onPreInformationChanged(event): void {
        if (this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.PreInformation != event) {
            this._RadiologyTestDefinition.PreInformation = event;
        }
    }

public onttobjectlistbox4Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.ProcedureTree != event) { 
    this._RadiologyTestDefinition.ProcedureTree = event;
}
}

public ontttextbox1Changed(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.Name != event) { 
    this._RadiologyTestDefinition.Name = event;
}
}

public ontxtReasonForPassiveChanged(event): void {
    if(this._RadiologyTestDefinition != null && this._RadiologyTestDefinition.ReasonForPassive != event) { 
    this._RadiologyTestDefinition.ReasonForPassive = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.ID, "Text", this.__ttObject, "TestID");
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.ttcheckbox3, "Value", this.__ttObject, "IsRISEntegratedTest");
    redirectProperty(this.chlPassiveNow, "Value", this.__ttObject, "IsPassiveNow");
    redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Name");
    redirectProperty(this.txtReasonForPassive, "Text", this.__ttObject, "ReasonForPassive");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
    redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "IsRestrictedTest");
    redirectProperty(this.ttcheckbox2, "Value", this.__ttObject, "IsHeader");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.ttenumcombobox1, "Value", this.__ttObject, "BodyPart");
    redirectProperty(this.TimeLimit, "Text", this.__ttObject, "TimeLimit");
    redirectProperty(this.ttenumcombobox2, "Value", this.__ttObject, "SexControl");
    redirectProperty(this.chkTuesday, "Value", this.__ttObject, "OnTuesday");
    redirectProperty(this.chkFriday, "Value", this.__ttObject, "OnFriday");
    redirectProperty(this.chkMonday, "Value", this.__ttObject, "OnMonday");
    redirectProperty(this.chkWednesday, "Value", this.__ttObject, "OnWednesday");
    redirectProperty(this.chkThursday, "Value", this.__ttObject, "OnThursday");
    redirectProperty(this.chkSaturday, "Value", this.__ttObject, "OnSaturday");
    redirectProperty(this.chkSunday, "Value", this.__ttObject, "OnSunday");
    redirectProperty(this.TabRow, "Text", this.__ttObject, "TabRow");
    redirectProperty(this.chkAccessionModality, "Value", this.__ttObject, "AccessionModalityRequires");
    redirectProperty(this.PreInformation, "Text", this.__ttObject, "PreInformation");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 154;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 153;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 152;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 151;

    this.ttlabel15 = new TTVisual.TTLabel();
    this.ttlabel15.Text = "Çalışılmama Nedeni";
    this.ttlabel15.Name = "ttlabel15";
    this.ttlabel15.TabIndex = 56;

    this.txtReasonForPassive = new TTVisual.TTTextBox();
    this.txtReasonForPassive.Multiline = true;
    this.txtReasonForPassive.Name = "txtReasonForPassive";
    this.txtReasonForPassive.TabIndex = 8;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 2;

    this.ID = new TTVisual.TTTextBox();
    this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ID.Name = "ID";
    this.ID.TabIndex = 0;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 5;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Code.Name = "Code";
    this.Code.TabIndex = 1;

    this.chlPassiveNow = new TTVisual.TTCheckBox();
    this.chlPassiveNow.Value = false;
    this.chlPassiveNow.Title = "Çalışılmayan Tetkik";
    this.chlPassiveNow.Name = "chlPassiveNow";
    this.chlPassiveNow.TabIndex = 7;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Tetkik Adı";
    this.labelName.BackColor = "#DCDCDC";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 29;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Adı";
    this.labelQref.BackColor = "#DCDCDC";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 20;

    this.labelID = new TTVisual.TTLabel();
    this.labelID.Text = "Tetkik Id";
    this.labelID.BackColor = "#DCDCDC";
    this.labelID.ForeColor = "#000000";
    this.labelID.Name = "labelID";
    this.labelID.TabIndex = 27;

    this.tttabpage8 = new TTVisual.TTTabPage();
    this.tttabpage8.DisplayIndex = 7;
    this.tttabpage8.TabIndex = 2;
    this.tttabpage8.Text = "Ön Bilgi";
    this.tttabpage8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage8.Name = "tttabpage8";

    this.labelPreInformation = new TTVisual.TTLabel();
    this.labelPreInformation.Text = "Ön Bilgi";
    this.labelPreInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelPreInformation.Name = "labelPreInformation";
    this.labelPreInformation.TabIndex = 1;


    this.PreInformation = new TTVisual.TTTextBox();
    this.PreInformation.Multiline = true;
    this.PreInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.PreInformation.Name = "PreInformation";
    this.PreInformation.TabIndex = 0;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = false;
    this.IsActive.Title = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 6;

    this.ttlabel14 = new TTVisual.TTLabel();
    this.ttlabel14.Text = "TM Radyoloji Testi";
    this.ttlabel14.BackColor = "#DCDCDC";
    this.ttlabel14.ForeColor = "#000000";
    this.ttlabel14.Name = "ttlabel14";
    this.ttlabel14.TabIndex = 53;
    this.ttlabel14.Visible = false;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Tetkik Kodu";
    this.labelCode.BackColor = "#DCDCDC";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 24;

    this.ttobjectlistbox3 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox3.ListDefName = "RadiologyTestLisTMDefinition";
    this.ttobjectlistbox3.Name = "ttobjectlistbox3";
    this.ttobjectlistbox3.TabIndex = 3;
    this.ttobjectlistbox3.Visible = false;

    this.labelEnglishName = new TTVisual.TTLabel();
    this.labelEnglishName.Text = "İngilizce Adı";
    this.labelEnglishName.BackColor = "#DCDCDC";
    this.labelEnglishName.ForeColor = "#000000";
    this.labelEnglishName.Name = "labelEnglishName";
    this.labelEnglishName.TabIndex = 22;

    this.tttabcontrol1 = new TTVisual.TTTabControl();
    this.tttabcontrol1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabcontrol1.Name = "tttabcontrol1";
    this.tttabcontrol1.TabIndex = 9;

    this.tttabpage4 = new TTVisual.TTTabPage();
    this.tttabpage4.DisplayIndex = 0;
    this.tttabpage4.BackColor = "#FFFFFF";
    this.tttabpage4.TabIndex = 0;
    this.tttabpage4.Text = "Genel Tanımlar";
    this.tttabpage4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage4.Name = "tttabpage4";

    this.ttlabel16 = new TTVisual.TTLabel();
    this.ttlabel16.Text = "İstek Ekranı Kategori Tanımları";
    this.ttlabel16.Name = "ttlabel16";
    this.ttlabel16.TabIndex = 117;

    this.TabNameGrid = new TTVisual.TTGrid();
    this.TabNameGrid.Name = "TabNameGrid";
    this.TabNameGrid.TabIndex = 6;

    this.TabNames = new TTVisual.TTListBoxColumn();
    this.TabNames.ListDefName = "RadiologyTabListDefinition";
    this.TabNames.DataMember = "RequestFormTab";
    this.TabNames.DisplayIndex = 0;
    this.TabNames.HeaderText = "Kategori Adı";
    this.TabNames.Name = "TabNames";
    this.TabNames.Width = 180;

    this.TabOrder = new TTVisual.TTTextBoxColumn();
    this.TabOrder.DataMember = "TabOrder";
    this.TabOrder.DisplayIndex = 1;
    this.TabOrder.HeaderText = "Sıra No";
    this.TabOrder.Name = "TabOrder";
    this.TabOrder.Width = 50;

    this.ttgroupbox2 = new TTVisual.TTGroupBox();
    this.ttgroupbox2.Text = "Çalışma Günleri";
    this.ttgroupbox2.Name = "ttgroupbox2";
    this.ttgroupbox2.TabIndex = 116;

    this.chkSunday = new TTVisual.TTCheckBox();
    this.chkSunday.Value = false;
    this.chkSunday.Title = "Pazar";
    this.chkSunday.Name = "chkSunday";
    this.chkSunday.TabIndex = 6;

    this.chkSaturday = new TTVisual.TTCheckBox();
    this.chkSaturday.Value = false;
    this.chkSaturday.Title = "Cumartesi";
    this.chkSaturday.Name = "chkSaturday";
    this.chkSaturday.TabIndex = 5;

    this.chkFriday = new TTVisual.TTCheckBox();
    this.chkFriday.Value = false;
    this.chkFriday.Title = "Cuma";
    this.chkFriday.Name = "chkFriday";
    this.chkFriday.TabIndex = 4;

    this.chkThursday = new TTVisual.TTCheckBox();
    this.chkThursday.Value = false;
    this.chkThursday.Title = "Perşembe";
    this.chkThursday.Name = "chkThursday";
    this.chkThursday.TabIndex = 3;

    this.chkWednesday = new TTVisual.TTCheckBox();
    this.chkWednesday.Value = false;
    this.chkWednesday.Title = "Çarşamba";
    this.chkWednesday.Name = "chkWednesday";
    this.chkWednesday.TabIndex = 2;

    this.chkTuesday = new TTVisual.TTCheckBox();
    this.chkTuesday.Value = false;
    this.chkTuesday.Title = "Salı";
    this.chkTuesday.Name = "chkTuesday";
    this.chkTuesday.TabIndex = 1;

    this.chkMonday = new TTVisual.TTCheckBox();
    this.chkMonday.Value = false;
    this.chkMonday.Title = "Pazartesi";
    this.chkMonday.Name = "chkMonday";
    this.chkMonday.TabIndex = 0;

    this.ttcheckbox1 = new TTVisual.TTCheckBox();
    this.ttcheckbox1.Value = false;
    this.ttcheckbox1.Title = "Kısıtlamalı Tetkik";
    this.ttcheckbox1.Name = "ttcheckbox1";
    this.ttcheckbox1.TabIndex = 4;

    this.labelBodyPart = new TTVisual.TTLabel();
    this.labelBodyPart.Text = "Vücut Bölgesi";
    this.labelBodyPart.ForeColor = "#000000";
    this.labelBodyPart.Name = "labelBodyPart";
    this.labelBodyPart.TabIndex = 33;

    this.ttcheckbox2 = new TTVisual.TTCheckBox();
    this.ttcheckbox2.Value = false;
    this.ttcheckbox2.Text = "Başlık";
    this.ttcheckbox2.Name = "ttcheckbox2";
    this.ttcheckbox2.TabIndex = 5;
    this.ttcheckbox2.Visible = false;

    this.ttenumcombobox2 = new TTVisual.TTEnumComboBox();
    this.ttenumcombobox2.DataTypeName = "SexEnum";
    this.ttenumcombobox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttenumcombobox2.Name = "ttenumcombobox2";
    this.ttenumcombobox2.TabIndex = 8;

    this.TimeLimit = new TTVisual.TTTextBox();
    this.TimeLimit.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TimeLimit.Name = "TimeLimit";
    this.TimeLimit.TabIndex = 7;

    this.TabRow = new TTVisual.TTTextBox();
    this.TabRow.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabRow.Name = "TabRow";
    this.TabRow.TabIndex = 57;
    this.TabRow.Visible = false;

    this.ttlabel7 = new TTVisual.TTLabel();
    this.ttlabel7.Text = "Tab Sıra No";
    this.ttlabel7.ForeColor = "#000000";
    this.ttlabel7.Name = "ttlabel7";
    this.ttlabel7.TabIndex = 56;
    this.ttlabel7.Visible = false;

    this.ttlabel8 = new TTVisual.TTLabel();
    this.ttlabel8.Text = "Tetkik Türü";
    this.ttlabel8.ForeColor = "#000000";
    this.ttlabel8.Name = "ttlabel8";
    this.ttlabel8.TabIndex = 59;

    this.TestType = new TTVisual.TTObjectListBox();
    this.TestType.ListDefName = "RadiologyTestTypeListDefinition";
    this.TestType.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TestType.Name = "TestType";
    this.TestType.TabIndex = 1;

    this.ttlabel6 = new TTVisual.TTLabel();
    this.ttlabel6.Text = "Cinsiyet Kontrolü";
    this.ttlabel6.ForeColor = "#000000";
    this.ttlabel6.Name = "ttlabel6";
    this.ttlabel6.TabIndex = 69;

    this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox1.ListDefName = "RadiologyTestTypeListDefinition";
    this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttobjectlistbox1.Name = "ttobjectlistbox1";
    this.ttobjectlistbox1.TabIndex = 64;
    this.ttobjectlistbox1.Visible = false;

    this.ttenumcombobox1 = new TTVisual.TTEnumComboBox();
    this.ttenumcombobox1.DataTypeName = "RadiologyBodyPartEnum";
    this.ttenumcombobox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttenumcombobox1.Name = "ttenumcombobox1";
    this.ttenumcombobox1.TabIndex = 2;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 46;

    this.ttobjectlistbox2 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox2.ListDefName = "RadiologyTabListDefinition";
    this.ttobjectlistbox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttobjectlistbox2.Name = "ttobjectlistbox2";
    this.ttobjectlistbox2.TabIndex = 66;
    this.ttobjectlistbox2.Visible = false;

    this.ttobjectlistbox4 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox4.ListDefName = "ProcedureTreeListDefinition";
    this.ttobjectlistbox4.Name = "ttobjectlistbox4";
    this.ttobjectlistbox4.TabIndex = 3;

    this.ttlabel12 = new TTVisual.TTLabel();
    this.ttlabel12.Text = "Hizmet Grubu";
    this.ttlabel12.BackColor = "#DCDCDC";
    this.ttlabel12.ForeColor = "#000000";
    this.ttlabel12.Name = "ttlabel12";
    this.ttlabel12.TabIndex = 54;

    this.ttlabel5 = new TTVisual.TTLabel();
    this.ttlabel5.Text = "Süre Kontrolü(Gün) ";
    this.ttlabel5.ForeColor = "#000000";
    this.ttlabel5.Name = "ttlabel5";
    this.ttlabel5.TabIndex = 67;

    this.ttlabel13 = new TTVisual.TTLabel();
    this.ttlabel13.Text = "Tab Adı";
    this.ttlabel13.ForeColor = "#000000";
    this.ttlabel13.Name = "ttlabel13";
    this.ttlabel13.TabIndex = 65;
    this.ttlabel13.Visible = false;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Description.Name = "Description";
    this.Description.TabIndex = 0;

    this.ttlabel11 = new TTVisual.TTLabel();
    this.ttlabel11.Text = "Tetkik Alt Türü";
    this.ttlabel11.ForeColor = "#000000";
    this.ttlabel11.Name = "ttlabel11";
    this.ttlabel11.TabIndex = 63;
    this.ttlabel11.Visible = false;

    this.tttabpage6 = new TTVisual.TTTabPage();
    this.tttabpage6.DisplayIndex = 1;
    this.tttabpage6.BackColor = "#FFFFFF";
    this.tttabpage6.TabIndex = 0;
    this.tttabpage6.Text = "Kısıtlamalı Tetkikler";
    this.tttabpage6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage6.Name = "tttabpage6";

    this.ttlabel4 = new TTVisual.TTLabel();
    this.ttlabel4.Text = "Kısıtlamalı Tetkikler";
    this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel4.Name = "ttlabel4";
    this.ttlabel4.TabIndex = 55;

    this.ttgrid2 = new TTVisual.TTGrid();
    this.ttgrid2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttgrid2.Name = "ttgrid2";
    this.ttgrid2.TabIndex = 54;

    this.Test = new TTVisual.TTListBoxColumn();
    this.Test.ListDefName = "RadiologyTestListDefinition";
    this.Test.DataMember = "Test";
    this.Test.DisplayIndex = 0;
    this.Test.HeaderText = "Tetkik Adı";
    this.Test.Name = "Test";
    this.Test.Width = 300;

    this.tttabpage1 = new TTVisual.TTTabPage();
    this.tttabpage1.DisplayIndex = 2;
    this.tttabpage1.BackColor = "#FFFFFF";
    this.tttabpage1.TabIndex = 0;
    this.tttabpage1.Text = "Bölümler";
    this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage1.Name = "tttabpage1";

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Çalışacak Bölümler";
    this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 49;

    this.ttgrid3 = new TTVisual.TTGrid();
    this.ttgrid3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttgrid3.Name = "ttgrid3";
    this.ttgrid3.TabIndex = 52;

    this.Department = new TTVisual.TTListBoxColumn();
    this.Department.ListDefName = "ResRadiologyDepartmentListDefinition";
    this.Department.DataMember = "Department";
    this.Department.DisplayIndex = 0;
    this.Department.HeaderText = "Bölüm";
    this.Department.Name = "Department";
    this.Department.Width = 300;

    this.tttabpage7 = new TTVisual.TTTabPage();
    this.tttabpage7.DisplayIndex = 3;
    this.tttabpage7.BackColor = "#FFFFFF";
    this.tttabpage7.TabIndex = 0;
    this.tttabpage7.Text = "Cihazlar";
    this.tttabpage7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage7.Name = "tttabpage7";

    this.ttgrid4 = new TTVisual.TTGrid();
    this.ttgrid4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttgrid4.Name = "ttgrid4";
    this.ttgrid4.TabIndex = 53;

    this.Equipment = new TTVisual.TTListBoxColumn();
    this.Equipment.ListDefName = "ResRadiologyEquipmentListDefinition";
    this.Equipment.DataMember = "Equipment";
    this.Equipment.DisplayIndex = 0;
    this.Equipment.HeaderText = "Cihaz";
    this.Equipment.Name = "Equipment";
    this.Equipment.Width = 300;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Çalışacak Cihazlar";
    this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 50;

    this.tttabpage5 = new TTVisual.TTTabPage();
    this.tttabpage5.DisplayIndex = 4;
    this.tttabpage5.BackColor = "#FFFFFF";
    this.tttabpage5.TabIndex = 0;
    this.tttabpage5.Text = "Malzeme Tanımları";
    this.tttabpage5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage5.Name = "tttabpage5";

    this.ttgrid1 = new TTVisual.TTGrid();
    this.ttgrid1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttgrid1.Name = "ttgrid1";
    this.ttgrid1.TabIndex = 53;

    this.Material = new TTVisual.TTListBoxColumn();
    this.Material.ListDefName = "MaterialListDefinition";
    this.Material.DataMember = "Material";
    this.Material.DisplayIndex = 0;
    this.Material.HeaderText = "Malzeme";
    this.Material.Name = "Material";
    this.Material.Width = 300;

    this.Amount = new TTVisual.TTTextBoxColumn();
    this.Amount.DataMember = "Amount";
    this.Amount.DisplayIndex = 1;
    this.Amount.HeaderText = "Miktar";
    this.Amount.Name = "Amount";
    this.Amount.Width = 100;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Kullanılan Malzemeler";
    this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 51;

    this.tttabpage3 = new TTVisual.TTTabPage();
    this.tttabpage3.DisplayIndex = 5;
    this.tttabpage3.BackColor = "#FFFFFF";
    this.tttabpage3.TabIndex = 0;
    this.tttabpage3.Text = "Açıklama Tanımları";
    this.tttabpage3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage3.Name = "tttabpage3";

    this.ttgrid5 = new TTVisual.TTGrid();
    this.ttgrid5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttgrid5.Name = "ttgrid5";
    this.ttgrid5.TabIndex = 53;

    this.OrderNo = new TTVisual.TTTextBoxColumn();
    this.OrderNo.DataMember = "OrderNo";
    this.OrderNo.DisplayIndex = 0;
    this.OrderNo.HeaderText = "Sıra No";
    this.OrderNo.Name = "OrderNo";
    this.OrderNo.Width = 40;

    this.Name = new TTVisual.TTListBoxColumn();
    this.Name.ListDefName = "RadiologyTestDescriptionListDefinition";
    this.Name.DataMember = "TestDescription";
    this.Name.DisplayIndex = 1;
    this.Name.HeaderText = "Açıklama";
    this.Name.Name = "Name";
    this.Name.Width = 300;

    this.ttlabel9 = new TTVisual.TTLabel();
    this.ttlabel9.Text = "Tetkik Açıklamaları";
    this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel9.ForeColor = "#000000";
    this.ttlabel9.Name = "ttlabel9";
    this.ttlabel9.TabIndex = 23;

    this.ttlabel10 = new TTVisual.TTLabel();
    this.ttlabel10.Text = "İngilizce Adı";
    this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel10.ForeColor = "#000000";
    this.ttlabel10.Name = "ttlabel10";
    this.ttlabel10.TabIndex = 22;

    this.tttabpage2 = new TTVisual.TTTabPage();
    this.tttabpage2.DisplayIndex = 6;
    this.tttabpage2.TabIndex = 1;
    this.tttabpage2.Text = "Medula";
    this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage2.Name = "tttabpage2";

    this.chkAccessionModality = new TTVisual.TTCheckBox();
    this.chkAccessionModality.Value = false;
    this.chkAccessionModality.Title = "Medulaya Accession No Gönder";
    this.chkAccessionModality.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.chkAccessionModality.Name = "chkAccessionModality";
    this.chkAccessionModality.TabIndex = 0;

    this.tttextbox1 = new TTVisual.TTTextBox();
    this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttextbox1.Name = "tttextbox1";
    this.tttextbox1.TabIndex = 4;

    this.ttcheckbox3 = new TTVisual.TTCheckBox();
    this.ttcheckbox3.Value = false;
    this.ttcheckbox3.Title = "RIS Entegre Tetkik";
    this.ttcheckbox3.Name = "ttcheckbox3";
    this.ttcheckbox3.TabIndex = 6;

    this.ttlabel17 = new TTVisual.TTLabel();
    this.ttlabel17.Text = "LOINC Kodu";
    this.ttlabel17.BackColor = "#DCDCDC";
    this.ttlabel17.ForeColor = "#000000";
    this.ttlabel17.Name = "ttlabel17";
    this.ttlabel17.TabIndex = 40;

    this.TTListBox = new TTVisual.TTObjectListBox();
    this.TTListBox.ListDefName = "SKRSLOINCList";
    this.TTListBox.Text = "LOINC Listesi";
    this.TTListBox.Name = "TTListBox";
    this.TTListBox.TabIndex = 150;

    this.TabNameGridColumns = [this.TabNames, this.TabOrder];
    this.ttgrid2Columns = [this.Test];
    this.ttgrid3Columns = [this.Department];
    this.ttgrid4Columns = [this.Equipment];
    this.ttgrid1Columns = [this.Material, this.Amount];
    this.ttgrid5Columns = [this.OrderNo, this.Name];
    this.tttabcontrol1.Controls = [this.tttabpage4, this.tttabpage6, this.tttabpage1, this.tttabpage7, this.tttabpage5, this.tttabpage3, this.tttabpage2, this.tttabpage8];
    this.tttabpage4.Controls = [this.ttlabel16, this.TabNameGrid, this.ttgroupbox2, this.ttcheckbox1, this.labelBodyPart, this.ttcheckbox2, this.ttenumcombobox2, this.TimeLimit, this.TabRow, this.ttlabel7, this.ttlabel8, this.TestType, this.ttlabel6, this.ttobjectlistbox1, this.ttenumcombobox1, this.labelDescription, this.ttobjectlistbox2, this.ttobjectlistbox4, this.ttlabel12, this.ttlabel5, this.ttlabel13, this.Description, this.ttlabel11];
    this.ttgroupbox2.Controls = [this.chkSunday, this.chkSaturday, this.chkFriday, this.chkThursday, this.chkWednesday, this.chkTuesday, this.chkMonday];
    this.tttabpage6.Controls = [this.ttlabel4, this.ttgrid2];
    this.tttabpage1.Controls = [this.ttlabel1, this.ttgrid3];
    this.tttabpage7.Controls = [this.ttgrid4, this.ttlabel2];
    this.tttabpage5.Controls = [this.ttgrid1, this.ttlabel3];
    this.tttabpage3.Controls = [this.ttgrid5, this.ttlabel9, this.ttlabel10];
    this.tttabpage2.Controls = [this.chkAccessionModality];
    this.tttabpage8.Controls = [this.labelPreInformation, this.PreInformation];
    this.Controls = [this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.labelPreInformation, this.tttabpage8,this.PreInformation,  this.MedulaProcedureType, this.ttlabel15, this.txtReasonForPassive, this.Qref, this.ID, this.EnglishName, this.Code, this.chlPassiveNow, this.labelName, this.labelQref, this.labelID, this.IsActive, this.ttlabel14, this.labelCode, this.ttobjectlistbox3, this.labelEnglishName, this.tttabcontrol1, this.tttabpage4, this.ttlabel16, this.TabNameGrid, this.TabNames, this.TabOrder, this.ttgroupbox2, this.chkSunday, this.chkSaturday, this.chkFriday, this.chkThursday, this.chkWednesday, this.chkTuesday, this.chkMonday, this.ttcheckbox1, this.labelBodyPart, this.ttcheckbox2, this.ttenumcombobox2, this.TimeLimit, this.TabRow, this.ttlabel7, this.ttlabel8, this.TestType, this.ttlabel6, this.ttobjectlistbox1, this.ttenumcombobox1, this.labelDescription, this.ttobjectlistbox2, this.ttobjectlistbox4, this.ttlabel12, this.ttlabel5, this.ttlabel13, this.Description, this.ttlabel11, this.tttabpage6, this.ttlabel4, this.ttgrid2, this.Test, this.tttabpage1, this.ttlabel1, this.ttgrid3, this.Department, this.tttabpage7, this.ttgrid4, this.Equipment, this.ttlabel2, this.tttabpage5, this.ttgrid1, this.Material, this.Amount, this.ttlabel3, this.tttabpage3, this.ttgrid5, this.OrderNo, this.Name, this.ttlabel9, this.ttlabel10, this.tttabpage2, this.chkAccessionModality, this.tttextbox1, this.ttcheckbox3, this.ttlabel17, this.TTListBox];

}


}
