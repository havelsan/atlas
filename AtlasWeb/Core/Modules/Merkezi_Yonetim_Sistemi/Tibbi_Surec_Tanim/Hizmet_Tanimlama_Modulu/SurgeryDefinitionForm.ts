//$B66FE5A9
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { SurgeryDefinitionFormViewModel } from './SurgeryDefinitionFormViewModel';
 import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
 import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SurgeryDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, ProcedureDefGroupEnum, SurgeyProcedureTypeEnum, RequiredDiagnoseProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DefinitionConcept } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryCodelessMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Exception } from 'NebulaClient/Mscorlib/Exception';

import { SurgeryBranchDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

@Component({
    selector: 'SurgeryDefinitionForm',
    templateUrl: './SurgeryDefinitionForm.html',
    providers: [MessageService]
})
export class SurgeryDefinitionForm extends TTVisual.TTForm implements OnInit {
    Branches: TTVisual.ITTGrid;
    Code: TTVisual.ITTTextBox;
    CodelessMaterialsGrid: TTVisual.ITTGrid;
    ConceptDefinitionConcept: TTVisual.ITTTextBoxColumn;
    DefinitionConcepts: TTVisual.ITTGrid;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    GILGroup: TTVisual.ITTEnumComboBox;
    InVitroFertilizationProcess: TTVisual.ITTCheckBox;
    IsActive: TTVisual.ITTCheckBox;
    IsAdditionalApplication: TTVisual.ITTCheckBox;
    IsDescriptionNeeded: TTVisual.ITTCheckBox;
    IsManipulation: TTVisual.ITTCheckBox;
    IsNeedEuroScore: TTVisual.ITTCheckBox;
    IsSurgery: TTVisual.ITTCheckBox;
    labelCode: TTVisual.ITTLabel;
    SpecialityDefinitionSurgeryBranchDefinition: TTVisual.ITTListBoxColumn;
    labelDescription: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelManipulationFormName: TTVisual.ITTLabel;
    labelManipulationStartState: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelPhysiotherapyFormName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelResource: TTVisual.ITTLabel;
    labelSurgeyProcedureType: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    lblGILGroup: TTVisual.ITTLabel;
    lblSUTGroup: TTVisual.ITTLabel;
    ManipulationFormName: TTVisual.ITTEnumComboBox;
    ManipulationStartState: TTVisual.ITTEnumComboBox;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    MedulaProvisionNecessity: TTVisual.ITTCheckBox;
    Name: TTVisual.ITTTextBox;
    OnamFormuIste: TTVisual.ITTCheckBox;
    PhysiotherapyFormName: TTVisual.ITTEnumComboBox;
    ProcedureTree: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    ReportIsRequired: TTVisual.ITTCheckBox;
    Resource: TTVisual.ITTObjectListBox;
    SurgeryCodelessMaterial: TTVisual.ITTListBoxColumn;
    SurgeryPointGroup: TTVisual.ITTEnumComboBox;
    SurgeyProcedureType: TTVisual.ITTEnumComboBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    SUTGroup: TTVisual.ITTEnumComboBox;
    tabCodelessMaterials: TTVisual.ITTTabPage;
    tabConcepts: TTVisual.ITTTabPage;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    public _tempProcedureTpe: any;
    public BranchesColumns = [];
    public CodelessMaterialsGridColumns = [];
    public DefinitionConceptsColumns = [];
    public surgeryDefinitionFormViewModel: SurgeryDefinitionFormViewModel = new SurgeryDefinitionFormViewModel();
    public get _SurgeryDefinition(): SurgeryDefinition {
        return this._TTObject as SurgeryDefinition;
    }
    private SurgeryDefinitionForm_DocumentUrl: string = '/api/SurgeryDefinitionService/SurgeryDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("SURGERYDEFINITION", "SurgeryDefinitionForm");
        this._DocumentServiceUrl = this.SurgeryDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public setInputParam(value: Object) {
        this._tempProcedureTpe = value;

    }

    public initViewModel(): void {
        this._TTObject = new SurgeryDefinition();
        this.surgeryDefinitionFormViewModel = new SurgeryDefinitionFormViewModel();
        this._ViewModel = this.surgeryDefinitionFormViewModel;
        this.surgeryDefinitionFormViewModel._SurgeryDefinition = this._TTObject as SurgeryDefinition;
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.Resource = new Resource();
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.DefinitionConcepts = new Array<DefinitionConcept>();
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.SurgeryCodelessMaterials = new Array<SurgeryCodelessMaterial>();
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.Branches = new Array<SurgeryBranchDefinition>();
        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.GILDefinition = new GILDefinition();
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>(); 
        this.surgeryDefinitionFormViewModel._SurgeryDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.surgeryDefinitionFormViewModel = this._ViewModel as SurgeryDefinitionFormViewModel;
        that._TTObject = this.surgeryDefinitionFormViewModel._SurgeryDefinition;
        if (this.surgeryDefinitionFormViewModel == null)
            this.surgeryDefinitionFormViewModel = new SurgeryDefinitionFormViewModel();
        if (this.surgeryDefinitionFormViewModel._SurgeryDefinition == null)
            this.surgeryDefinitionFormViewModel._SurgeryDefinition = new SurgeryDefinition();
        let resourceObjectID = that.surgeryDefinitionFormViewModel._SurgeryDefinition["Resource"];
        if (resourceObjectID != null && (typeof resourceObjectID === "string")) {
            let resource = that.surgeryDefinitionFormViewModel.Resources.find(o => o.ObjectID.toString() === resourceObjectID.toString());
            if (resource) {
                that.surgeryDefinitionFormViewModel._SurgeryDefinition.Resource = resource;
            }
        }


        that.surgeryDefinitionFormViewModel._SurgeryDefinition.DefinitionConcepts = that.surgeryDefinitionFormViewModel.DefinitionConceptsGridList;
        for (let detailItem of that.surgeryDefinitionFormViewModel.DefinitionConceptsGridList) {
        }
        that.surgeryDefinitionFormViewModel._SurgeryDefinition.SurgeryCodelessMaterials = that.surgeryDefinitionFormViewModel.CodelessMaterialsGridGridList;
        for (let detailItem of that.surgeryDefinitionFormViewModel.CodelessMaterialsGridGridList) {
            let dPA22FCodelessMaterialDefObjectID = detailItem["DPA22FCodelessMaterialDef"];
            if (dPA22FCodelessMaterialDefObjectID != null && (typeof dPA22FCodelessMaterialDefObjectID === "string")) {
                let dPA22FCodelessMaterialDef = that.surgeryDefinitionFormViewModel.DPA22FCodelessMaterialDefs.find(o => o.ObjectID.toString() === dPA22FCodelessMaterialDefObjectID.toString());
                if (dPA22FCodelessMaterialDef) {
                    detailItem.DPA22FCodelessMaterialDef = dPA22FCodelessMaterialDef;
                }
            }

        }

        let procedureTreeObjectID = that.surgeryDefinitionFormViewModel._SurgeryDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.surgeryDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.surgeryDefinitionFormViewModel._SurgeryDefinition.ProcedureTree = procedureTree;
            }
        }

                /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.surgeryDefinitionFormViewModel._SurgeryDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.surgeryDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.surgeryDefinitionFormViewModel._SurgeryDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.surgeryDefinitionFormViewModel._SurgeryDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.surgeryDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.surgeryDefinitionFormViewModel._SurgeryDefinition.GILDefinition = gILDefinition;
            }
        }

        that.surgeryDefinitionFormViewModel._SurgeryDefinition.SubProcedureDefinitions = that.surgeryDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.surgeryDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.surgeryDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.surgeryDefinitionFormViewModel._SurgeryDefinition.RequiredDiagnoseProcedures = that.surgeryDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.surgeryDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.surgeryDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
                if (diagnosisDefinition) {
                    detailItem.DiagnosisDefinition = diagnosisDefinition;
                }
            }
        }

        that.surgeryDefinitionFormViewModel._SurgeryDefinition.Branches = that.surgeryDefinitionFormViewModel.BranchesGridList;
        for (let detailItem of that.surgeryDefinitionFormViewModel.BranchesGridList) {
            let specialityDefinitionObjectID = detailItem["SpecialityDefinition"];
            if (specialityDefinitionObjectID != null && (typeof specialityDefinitionObjectID === "string")) {
                let specialityDefinition = that.surgeryDefinitionFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityDefinitionObjectID.toString());
                if (specialityDefinition) {
                    detailItem.SpecialityDefinition = specialityDefinition;
                }
            }

        }

        //this.surgeryDefinitionFormViewModel._SurgeryDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
        /**
         * Her Tanım Ekranına Eklenmeli Base için Bitiş
         */


    }

async ngOnInit() {
    await this.load();
}

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (this._SurgeryDefinition.IsAdditionalApplication == null)
            this._SurgeryDefinition.IsAdditionalApplication = false;

        if (this._SurgeryDefinition.IsManipulation == null)
            this._SurgeryDefinition.IsManipulation = false;

        if (this._SurgeryDefinition.IsSurgery == null)
            this._SurgeryDefinition.IsSurgery = false;

        if (this._SurgeryDefinition.ProcedureType == ProcedureDefGroupEnum.digerIslemBilgileri)//Ek uygulamalar
        {
            if (this._SurgeryDefinition.IsAdditionalApplication && this._SurgeryDefinition.IsManipulation)
                this._SurgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.ManipulationAdditionalApplication;
            else if (this._SurgeryDefinition.IsAdditionalApplication)
                this._SurgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.OnlyAdditionalApplication;
            else if (this._SurgeryDefinition.IsManipulation)
                this._SurgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.OnlyManipulation;
            else
                throw new Exception("İşlem Tipi Alanlarından En Az Bir Tanesini Seçmek Zorundasınız.");
        }
        else if (this._SurgeryDefinition.ProcedureType == ProcedureDefGroupEnum.ameliyatveGirisimBilgileri)//Ameliyat ve Tetkik
        {
            if (this._SurgeryDefinition.IsSurgery && this._SurgeryDefinition.IsManipulation)
                this._SurgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.SurgeryAndManiplation;
            else if (this._SurgeryDefinition.IsSurgery)
                this._SurgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.OnlySurgery;
            else if (this._SurgeryDefinition.IsManipulation)
                this._SurgeryDefinition.SurgeryProcedureType = SurgeyProcedureTypeEnum.OnlyManipulation;
            else
                throw new Exception("İşlem Tipi Alanlarından En Az Bir Tanesini Seçmek Zorundasınız.");
        }

        super.ClientSidePostScript(transDef);
    }

public onCodeChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.Code != event) { 
    this._SurgeryDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.Description != event) { 
    this._SurgeryDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.EnglishName != event) { 
    this._SurgeryDefinition.EnglishName = event;
}
}

public onGILGroupChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.GILGroup != event) { 
    this._SurgeryDefinition.GILGroup = event;
}
}

public onInVitroFertilizationProcessChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.InVitroFertilizationProcess != event) { 
    this._SurgeryDefinition.InVitroFertilizationProcess = event;
}
}

public onIsActiveChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.IsActive != event) { 
    this._SurgeryDefinition.IsActive = event;
}
}

public onIsAdditionalApplicationChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.IsAdditionalApplication != event) { 
    this._SurgeryDefinition.IsAdditionalApplication = event;
}
}

public onIsDescriptionNeededChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.IsDescriptionNeeded_1 != event) { 
    this._SurgeryDefinition.IsDescriptionNeeded_1 = event;
}
}

public onIsManipulationChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.IsManipulation != event) { 
    this._SurgeryDefinition.IsManipulation = event;
}
}

public onIsNeedEuroScoreChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.IsNeedEuroScore != event) { 
    this._SurgeryDefinition.IsNeedEuroScore = event;
}
}

public onIsSurgeryChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.IsSurgery != event) { 
    this._SurgeryDefinition.IsSurgery = event;
}
}

public onManipulationFormNameChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.ManipulationFormName != event) { 
    this._SurgeryDefinition.ManipulationFormName = event;
}
}

public onManipulationStartStateChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.ManipulationStartState != event) { 
    this._SurgeryDefinition.ManipulationStartState = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.MedulaProcedureType != event) { 
    this._SurgeryDefinition.MedulaProcedureType = event;
}
}

public onMedulaProvisionNecessityChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.DailyMedulaProvisionNecessity != event) { 
    this._SurgeryDefinition.DailyMedulaProvisionNecessity = event;
}
}

public onNameChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.Name != event) { 
    this._SurgeryDefinition.Name = event;
}
}

public onOnamFormuIsteChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.OnamFormuIste != event) { 
    this._SurgeryDefinition.OnamFormuIste = event;
}
}

public onPhysiotherapyFormNameChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.PhysiotherapyFormName != event) { 
    this._SurgeryDefinition.PhysiotherapyFormName = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.ProcedureTree != event) { 
    this._SurgeryDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.Qref != event) { 
    this._SurgeryDefinition.Qref = event;
}
}

public onReportIsRequiredChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.ReportIsRequired != event) { 
    this._SurgeryDefinition.ReportIsRequired = event;
}
}

public onResourceChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.Resource != event) { 
    this._SurgeryDefinition.Resource = event;
}
}

public onSurgeryPointGroupChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.SurgeryPointGroup != event) { 
    this._SurgeryDefinition.SurgeryPointGroup = event;
}
}

public onSurgeyProcedureTypeChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.SurgeryProcedureType != event) { 
    this._SurgeryDefinition.SurgeryProcedureType = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.SUTAppendix != event) { 
    this._SurgeryDefinition.SUTAppendix = event;
}
}

public onSUTGroupChanged(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.SUTGroup != event) { 
    this._SurgeryDefinition.SUTGroup = event;
}
}

public onttcheckbox1Changed(event): void {
    if(this._SurgeryDefinition != null && this._SurgeryDefinition.Chargable != event) { 
    this._SurgeryDefinition.Chargable = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "Chargable");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.ReportIsRequired, "Value", this.__ttObject, "ReportIsRequired");
    redirectProperty(this.InVitroFertilizationProcess, "Value", this.__ttObject, "InVitroFertilizationProcess");
    redirectProperty(this.MedulaProvisionNecessity, "Value", this.__ttObject, "DailyMedulaProvisionNecessity");
    redirectProperty(this.IsNeedEuroScore, "Value", this.__ttObject, "IsNeedEuroScore");
    redirectProperty(this.IsDescriptionNeeded, "Value", this.__ttObject, "IsDescriptionNeeded_1");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.SurgeryPointGroup, "Value", this.__ttObject, "SurgeryPointGroup");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.SUTGroup, "Value", this.__ttObject, "SUTGroup");
    redirectProperty(this.GILGroup, "Value", this.__ttObject, "GILGroup");
    redirectProperty(this.SurgeyProcedureType, "Value", this.__ttObject, "SurgeryProcedureType");
    redirectProperty(this.ManipulationFormName, "Value", this.__ttObject, "ManipulationFormName");
    redirectProperty(this.ManipulationStartState, "Value", this.__ttObject, "ManipulationStartState");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.PhysiotherapyFormName, "Value", this.__ttObject, "PhysiotherapyFormName");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
    redirectProperty(this.OnamFormuIste, "Value", this.__ttObject, "OnamFormuIste");
    redirectProperty(this.IsSurgery, "Value", this.__ttObject, "IsSurgery");
    redirectProperty(this.IsManipulation, "Value", this.__ttObject, "IsManipulation");
    redirectProperty(this.IsAdditionalApplication, "Value", this.__ttObject, "IsAdditionalApplication");
}

public initFormControls() : void {
    this.IsAdditionalApplication = new TTVisual.TTCheckBox();
    this.IsAdditionalApplication.Value = false;
    this.IsAdditionalApplication.Title = "Ek Uygulama";
    this.IsAdditionalApplication.Name = "IsAdditionalApplication";
    this.IsAdditionalApplication.TabIndex = 74;
    this.IsAdditionalApplication.ThreeState=false;

    this.IsManipulation = new TTVisual.TTCheckBox();
    this.IsManipulation.Value = false;
    this.IsManipulation.Title = "Manipulasyon";
    this.IsManipulation.Name = "IsManipulation";
    this.IsManipulation.TabIndex = 73;
    this.IsManipulation.ThreeState=false;

    this.Branches = new TTVisual.TTGrid();
    this.Branches.Name = "Branches";
    this.Branches.TabIndex = 0;

    this.SpecialityDefinitionSurgeryBranchDefinition = new TTVisual.TTListBoxColumn();
    this.SpecialityDefinitionSurgeryBranchDefinition.ListDefName = "SpecialityListDefinition";
    this.SpecialityDefinitionSurgeryBranchDefinition.DataMember = "SpecialityDefinition";
    this.SpecialityDefinitionSurgeryBranchDefinition.DisplayIndex = 0;
    this.SpecialityDefinitionSurgeryBranchDefinition.HeaderText = "Branş";
    this.SpecialityDefinitionSurgeryBranchDefinition.Name = "SpecialityDefinitionSurgeryBranchDefinition";
    this.SpecialityDefinitionSurgeryBranchDefinition.Width = 300;

    this.IsSurgery = new TTVisual.TTCheckBox();
    this.IsSurgery.Value = false;
    this.IsSurgery.Title = "Ameliyat";
    this.IsSurgery.Name = "IsSurgery";
    this.IsSurgery.TabIndex = 72;
    this.IsSurgery.ThreeState=false;

    this.labelManipulationStartState = new TTVisual.TTLabel();
    this.labelManipulationStartState.Text = "İlgili Manipulasyon Başlangıç Adımı";
    this.labelManipulationStartState.Name = "labelManipulationStartState";
    this.labelManipulationStartState.TabIndex = 71;

    this.ManipulationStartState = new TTVisual.TTEnumComboBox();
    this.ManipulationStartState.DataTypeName = "ManipulationStartStateEnum";
    this.ManipulationStartState.Name = "ManipulationStartState";
    this.ManipulationStartState.TabIndex = 70;

    this.labelManipulationFormName = new TTVisual.TTLabel();
    this.labelManipulationFormName.Text = "İlgili Manipulasyon Form Adı";
    this.labelManipulationFormName.Name = "labelManipulationFormName";
    this.labelManipulationFormName.TabIndex = 69;

    this.ManipulationFormName = new TTVisual.TTEnumComboBox();
    this.ManipulationFormName.DataTypeName = "ManipulationFormNameEnum";
    this.ManipulationFormName.Name = "ManipulationFormName";
    this.ManipulationFormName.TabIndex = 68;

    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 67;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 66;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 65;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 64;

    this.IsDescriptionNeeded = new TTVisual.TTCheckBox();
    this.IsDescriptionNeeded.Value = false;
    this.IsDescriptionNeeded.Title = "Açıklama Girilmesini gerektirir";
    this.IsDescriptionNeeded.Name = "IsDescriptionNeeded";
    this.IsDescriptionNeeded.TabIndex = 63;

    this.labelPhysiotherapyFormName = new TTVisual.TTLabel();
    this.labelPhysiotherapyFormName.Text = "İlgili Fizyoterapi Test Formu";
    this.labelPhysiotherapyFormName.Name = "labelPhysiotherapyFormName";
    this.labelPhysiotherapyFormName.TabIndex = 62;

    this.PhysiotherapyFormName = new TTVisual.TTEnumComboBox();
    this.PhysiotherapyFormName.DataTypeName = "PhysiotherapyFormsEnum";
    this.PhysiotherapyFormName.Name = "PhysiotherapyFormName";
    this.PhysiotherapyFormName.TabIndex = 61;

    this.labelResource = new TTVisual.TTLabel();
    this.labelResource.Text = " Birim";
    this.labelResource.Name = "labelResource";
    this.labelResource.TabIndex = 60;

    this.Resource = new TTVisual.TTObjectListBox();
    this.Resource.ListFilterExpression = "OBJECTDEFNAME IN ('RESPOLICLINIC','RESCLINIC', 'RESTREATMENTDIAGNOSISUNIT','RESOBSERVATIONUNIT','RESRADIOLOGYDEPARTMENT')";
    this.Resource.ListDefName = "ResourceListDefinition";
    this.Resource.Name = "Resource";
    this.Resource.TabIndex = 59;

    this.IsNeedEuroScore = new TTVisual.TTCheckBox();
    this.IsNeedEuroScore.Value = false;
    this.IsNeedEuroScore.Title = "EuroScore Bilgisi Gerektirir";
    this.IsNeedEuroScore.Name = "IsNeedEuroScore";
    this.IsNeedEuroScore.TabIndex = 58;

    this.lblSUTGroup = new TTVisual.TTLabel();
    this.lblSUTGroup.Text = "SUT Grubu";
    this.lblSUTGroup.Name = "lblSUTGroup";
    this.lblSUTGroup.TabIndex = 57;

    this.SUTGroup = new TTVisual.TTEnumComboBox();
    this.SUTGroup.DataTypeName = "SurgeryProcedureGroup";
    this.SUTGroup.Name = "SUTGroup";
    this.SUTGroup.TabIndex = 56;

    this.tttabcontrol1 = new TTVisual.TTTabControl();
    this.tttabcontrol1.Name = "tttabcontrol1";
    this.tttabcontrol1.TabIndex = 55;

    this.tabConcepts = new TTVisual.TTTabPage();
    this.tabConcepts.DisplayIndex = 0;
    this.tabConcepts.TabIndex = 0;
    this.tabConcepts.Text = "Kavramlar";
    this.tabConcepts.Name = "tabConcepts";

    this.DefinitionConcepts = new TTVisual.TTGrid();
    this.DefinitionConcepts.OnRowMarkerDoubleClickShowTTObjectForm = false;
    this.DefinitionConcepts.AllowUserToOrderColumns = true;
    this.DefinitionConcepts.RowHeadersVisible = false;
    this.DefinitionConcepts.Name = "DefinitionConcepts";
    this.DefinitionConcepts.TabIndex = 51;

    this.ConceptDefinitionConcept = new TTVisual.TTTextBoxColumn();
    this.ConceptDefinitionConcept.DataMember = "Concept";
    this.ConceptDefinitionConcept.DisplayIndex = 0;
    this.ConceptDefinitionConcept.HeaderText = "Kavram";
    this.ConceptDefinitionConcept.Name = "ConceptDefinitionConcept";
    this.ConceptDefinitionConcept.Width = 500;

    this.tabCodelessMaterials = new TTVisual.TTTabPage();
    this.tabCodelessMaterials.DisplayIndex = 1;
    this.tabCodelessMaterials.TabIndex = 1;
    this.tabCodelessMaterials.Text = "Kullanılan Kodsuz Malzeme";
    this.tabCodelessMaterials.Name = "tabCodelessMaterials";

    this.CodelessMaterialsGrid = new TTVisual.TTGrid();
    this.CodelessMaterialsGrid.Name = "CodelessMaterialsGrid";
    this.CodelessMaterialsGrid.TabIndex = 0;

    this.SurgeryCodelessMaterial = new TTVisual.TTListBoxColumn();
    this.SurgeryCodelessMaterial.ListDefName = "DPA22FCodelessMaterialList";
    this.SurgeryCodelessMaterial.DataMember = "DPA22FCodelessMaterialDef";
    this.SurgeryCodelessMaterial.DisplayIndex = 0;
    this.SurgeryCodelessMaterial.HeaderText = "Kodsuz Malzeme";
    this.SurgeryCodelessMaterial.Name = "SurgeryCodelessMaterial";
    this.SurgeryCodelessMaterial.Width = 350;

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

    this.InVitroFertilizationProcess = new TTVisual.TTCheckBox();
    this.InVitroFertilizationProcess.Value = false;
    this.InVitroFertilizationProcess.Title = "Tüp Bebek İşlemi";
    this.InVitroFertilizationProcess.Name = "InVitroFertilizationProcess";
    this.InVitroFertilizationProcess.TabIndex = 54;

    this.MedulaProvisionNecessity = new TTVisual.TTCheckBox();
    this.MedulaProvisionNecessity.Value = false;
    this.MedulaProvisionNecessity.Title = "Günübirlik Takip Alınmasını Gerektirir";
    this.MedulaProvisionNecessity.Name = "MedulaProvisionNecessity";
    this.MedulaProvisionNecessity.TabIndex = 53;

    this.ReportIsRequired = new TTVisual.TTCheckBox();
    this.ReportIsRequired.Value = false;
    this.ReportIsRequired.Title = "Rapor Yazılması Zorunlu";
    this.ReportIsRequired.Name = "ReportIsRequired";
    this.ReportIsRequired.TabIndex = 52;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Hizmet Grubu";
    this.ttlabel3.BackColor = "#DCDCDC";
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
    this.ttlabel2.BackColor = "#DCDCDC";
    this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 46;

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
    this.IsActive.Title = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 34;

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

    this.ttcheckbox1 = new TTVisual.TTCheckBox();
    this.ttcheckbox1.Value = true;
    this.ttcheckbox1.Title = "Ücretli";
    this.ttcheckbox1.Name = "ttcheckbox1";
    this.ttcheckbox1.TabIndex = 34;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "SUT Puan Grubu";
    this.ttlabel1.BackColor = "#DCDCDC";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 50;

    this.SurgeryPointGroup = new TTVisual.TTEnumComboBox();
    this.SurgeryPointGroup.DataTypeName = "SurgeryPointGroupEnum";
    this.SurgeryPointGroup.Name = "SurgeryPointGroup";
    this.SurgeryPointGroup.TabIndex = 31;

    this.labelSurgeyProcedureType = new TTVisual.TTLabel();
    this.labelSurgeyProcedureType.Text = "İşlem Tipi";
    this.labelSurgeyProcedureType.Name = "labelSurgeyProcedureType";
    this.labelSurgeyProcedureType.TabIndex = 5;

    this.SurgeyProcedureType = new TTVisual.TTEnumComboBox();
    this.SurgeyProcedureType.DataTypeName = "SurgeyProcedureTypeEnum";
    this.SurgeyProcedureType.Name = "SurgeyProcedureType";
    this.SurgeyProcedureType.TabIndex = 4;

    this.OnamFormuIste = new TTVisual.TTCheckBox();
    this.OnamFormuIste.Value = true;
    this.OnamFormuIste.Title = "Onam Formu İste";
    this.OnamFormuIste.Name = "OnamFormuIste";
    this.OnamFormuIste.TabIndex = 53;

    this.GILGroup = new TTVisual.TTEnumComboBox();
    this.GILGroup.DataTypeName = "SurgeryProcedureGroup";
    this.GILGroup.Name = "GILGroup";
    this.GILGroup.TabIndex = 56;

    this.lblGILGroup = new TTVisual.TTLabel();
    this.lblGILGroup.Text = "GİL Grubu";
    this.lblGILGroup.Name = "lblGILGroup";
    this.lblGILGroup.TabIndex = 57;

    this.DefinitionConceptsColumns = [this.ConceptDefinitionConcept];
    this.CodelessMaterialsGridColumns = [this.SurgeryCodelessMaterial];
    this.tttabcontrol1.Controls = [this.tabConcepts, this.tabCodelessMaterials];
    this.tabConcepts.Controls = [this.DefinitionConcepts];
    this.tabCodelessMaterials.Controls = [this.CodelessMaterialsGrid];
    this.BranchesColumns = [this.SpecialityDefinitionSurgeryBranchDefinition];
    this.Controls = [this.IsAdditionalApplication,  this.Branches, this.SpecialityDefinitionSurgeryBranchDefinition,  this.IsManipulation, this.IsSurgery, this.labelManipulationStartState, this.ManipulationStartState, this.labelManipulationFormName, this.ManipulationFormName, this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.IsDescriptionNeeded, this.labelPhysiotherapyFormName, this.PhysiotherapyFormName, this.labelResource, this.Resource, this.IsNeedEuroScore, this.lblSUTGroup, this.SUTGroup, this.tttabcontrol1, this.tabConcepts, this.DefinitionConcepts, this.ConceptDefinitionConcept, this.tabCodelessMaterials, this.CodelessMaterialsGrid, this.SurgeryCodelessMaterial, this.Qref, this.Name, this.EnglishName, this.Description, this.Code, this.InVitroFertilizationProcess, this.MedulaProvisionNecessity, this.ReportIsRequired, this.ttlabel3, this.ProcedureTree, this.ttlabel2, this.labelQref, this.labelName, this.IsActive, this.labelEnglishName, this.labelDescription, this.labelCode, this.ttcheckbox1, this.ttlabel1, this.SurgeryPointGroup, this.labelSurgeyProcedureType, this.SurgeyProcedureType, this.OnamFormuIste, this.GILGroup, this.lblGILGroup];

}


}
