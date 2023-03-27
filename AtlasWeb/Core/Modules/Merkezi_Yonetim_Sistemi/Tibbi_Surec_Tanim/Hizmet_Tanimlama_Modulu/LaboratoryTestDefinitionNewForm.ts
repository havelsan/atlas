//$AAFF3F7D
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { LaboratoryTestDefinitionNewFormViewModel } from './LaboratoryTestDefinitionNewFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Dictionary } from 'NebulaClient/System/Collections/Dictionaries/Dictionary';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { LaboratoryTestDefinition, PackageProcedureDefinition, SubProcedureDefinition, GILDefinition, RequiredDiagnoseProcedure, LabGridSpecialityDefinition  } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Sites } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { LaboratoryGridBoundedTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryGridDepartmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryGridMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryGridPanelTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryGridRestrictedTestDefiniton } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryRequestFormTabDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryTabNamesGrid } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryTestTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResLaboratoryDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSLOINC } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TahlilTipi } from 'NebulaClient/Model/AtlasClientModel';

import { ProcedureForm } from './ProcedureForm';

@Component({
    selector: 'LaboratoryTestDefinitionNewForm',
    templateUrl: './LaboratoryTestDefinitionNewForm.html',
    providers: [MessageService]
})
export class LaboratoryTestDefinitionNewForm extends TTVisual.TTForm implements OnInit {
    AdultAlert: TTVisual.ITTTextBox;
    AdultNegative: TTVisual.ITTCheckBox;
    AdultPositive: TTVisual.ITTCheckBox;
    BoundedTestName: TTVisual.ITTListBoxColumn;
    Branch: TTVisual.ITTObjectListBox;
    chkNotLISTest: TTVisual.ITTCheckBox;
    chkPassiveNow: TTVisual.ITTCheckBox;
    chkPrintInOneReport: TTVisual.ITTCheckBox;
    chkSendOtherResults: TTVisual.ITTCheckBox;
    Code: TTVisual.ITTTextBox;
    DefaultTab: TTVisual.ITTObjectListBox;
    Department: TTVisual.ITTListBoxColumn;
    Description: TTVisual.ITTTextBox;
    DurationValue: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    GridBoundedTests: TTVisual.ITTGrid;
    GridDepartments: TTVisual.ITTGrid;
    GridMaterials: TTVisual.ITTGrid;
    GridPanelTests: TTVisual.ITTGrid;
    GridRestrictedTests: TTVisual.ITTGrid;
    IsActive: TTVisual.ITTCheckBox;
    IsBoundedTest: TTVisual.ITTCheckBox;
    IsDurationControl: TTVisual.ITTCheckBox;
    IsGroup: TTVisual.ITTCheckBox;
    IsPanel: TTVisual.ITTCheckBox;
    IsPrintEveryPage: TTVisual.ITTCheckBox;
    IsRestrictedTest: TTVisual.ITTCheckBox;
    IsSAT: TTVisual.ITTCheckBox;
    IsSexControl: TTVisual.ITTCheckBox;
    IsSubTest: TTVisual.ITTCheckBox;
    labelAdultAlert: TTVisual.ITTLabel;
    labelBranch: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelNewBornAlert: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    labelTahlilTipi: TTVisual.ITTLabel;
    lblDefaultTab: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    PackageProcedure: TTVisual.ITTObjectListBox;
    NewBornAlert: TTVisual.ITTTextBox;
    NewBornNegative: TTVisual.ITTCheckBox;
    NewBornPositive: TTVisual.ITTCheckBox;
    PanelTest: TTVisual.ITTListBoxColumn;
    PriceCoefficient: TTVisual.ITTTextBox;
    ProcedureTree: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    RequiresDiabetesForm: TTVisual.ITTCheckBox;
    RestrictedTestName: TTVisual.ITTListBoxColumn;
    SequenceNo: TTVisual.ITTTextBoxColumn;
    sexListBox: TTVisual.ITTObjectListBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    TabControlInfos: TTVisual.ITTTabControl;
    TabDescription: TTVisual.ITTTextBox;
    TabNameGrid: TTVisual.ITTGrid;
    TabNames: TTVisual.ITTListBoxColumn;
    TabOrder: TTVisual.ITTTextBoxColumn;
    TabPageAdult: TTVisual.ITTTabPage;
    TabPageBoundRestrictedTests: TTVisual.ITTTabPage;
    TabPageGeneralInfo: TTVisual.ITTTabPage;
    TabPageMaterial: TTVisual.ITTTabPage;
    TabPageMedula: TTVisual.ITTTabPage;
    TabPageNewBorn: TTVisual.ITTTabPage;
    TabPagePanel: TTVisual.ITTTabPage;
    TabPagePrerequisiteForms: TTVisual.ITTTabPage;
    TabPageResource: TTVisual.ITTTabPage;
    TabPageTestAlert: TTVisual.ITTTabPage;
    TabTestBranchRelation: TTVisual.ITTTabPage;
    TahlilTipi: TTVisual.ITTObjectListBox;
    TestName: TTVisual.ITTTextBox;
    TestType: TTVisual.ITTObjectListBox;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttcheckbox2: TTVisual.ITTCheckBox;
    ttgrid1: TTVisual.ITTGrid;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel19: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel23: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    TTListBox: TTVisual.ITTObjectListBox;
    ttlistboxcolumn2: TTVisual.ITTListBoxColumn;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttReqiresTripleTestForm: TTVisual.ITTCheckBox;
    ttRequiresBinaryScanForm: TTVisual.ITTCheckBox;
    ttRequiresUreaBreathTestReport: TTVisual.ITTCheckBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextbox4: TTVisual.ITTTextBox;
    tttextbox5: TTVisual.ITTTextBox;
    public GridBoundedTestsColumns = [];
    public GridDepartmentsColumns = [];
    public GridMaterialsColumns = [];
    public GridPanelTestsColumns = [];
    public GridRestrictedTestsColumns = [];
    public TabNameGridColumns = [];
    public ttgrid1Columns = [];
    public laboratoryTestDefinitionNewFormViewModel: LaboratoryTestDefinitionNewFormViewModel = new LaboratoryTestDefinitionNewFormViewModel();
    public get _LaboratoryTestDefinition(): LaboratoryTestDefinition {
        return this._TTObject as LaboratoryTestDefinition;
    }
    private LaboratoryTestDefinitionNewForm_DocumentUrl: string = '/api/LaboratoryTestDefinitionService/LaboratoryTestDefinitionNewForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('LABORATORYTESTDEFINITION', 'LaboratoryTestDefinitionNewForm');
        this._DocumentServiceUrl = this.LaboratoryTestDefinitionNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async CheckAndAddToDictionary(dictionary: Dictionary<string, Object>, Code: string, ttObject: Object, description: string): Promise<void> {
        if (dictionary.containsKey(Code)) {
            throw new Exception((await SystemMessageService.GetMessage(1265)));
        }
        else {
            let item :Dictionary<string, Object>=null;
            
            dictionary.push({
                key:   Code,
                value: ttObject
            });
        }
    }
    private async isGridHasZeroRows(ttGrid: TTVisual.ITTGrid): Promise<boolean> {
        if (ttGrid.Rows.length === 0)
            return true;
        return false;
    }
    private async SetSubTestDefAsNotChargable(): Promise<void> {
        let siteIDGuid: Guid = new Guid((await SystemParameterService.GetParameterValue('SITEID', Guid.Empty.toString())));
        // if (Sites.SiteMerkezSagKom === siteIDGuid) {
        //     let isSubTest: boolean = this.IsSubTest.Value;
        //     if (isSubTest)
        //         this._LaboratoryTestDefinition.Chargable = false;
        // }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        this.CheckLaboratoryTestDefinitionConsistency();
        this.CheckCollectionElementDuplication();
        this.SetSubTestDefAsNotChargable();
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        if (this._LaboratoryTestDefinition.IsPassiveNow === null)
            this.chkPassiveNow.Value = false;
        if (this._LaboratoryTestDefinition.IsPanel === null)
            this.IsPanel.Value = false;
        if (this._LaboratoryTestDefinition.IsSubTest === null)
            this.IsSubTest.Value = false;
        if (this._LaboratoryTestDefinition.IsSat === null)
            this.IsSAT.Value = false;
        if (this._LaboratoryTestDefinition.IsDurationControl === null)
            this.IsDurationControl.Value = false;
        if (this._LaboratoryTestDefinition.IsBoundedTest === null)
            this.IsBoundedTest.Value = false;
        if (this._LaboratoryTestDefinition.IsRestrictedTest === null)
            this.IsRestrictedTest.Value = false;
        if (this._LaboratoryTestDefinition.IsSexControl === null)
            this.IsSexControl.Value = false;
        if (this._LaboratoryTestDefinition.IsPrintEveryPage === null)
            this.IsPrintEveryPage.Value = false;
        if (this._LaboratoryTestDefinition.IsPrintEveryPage === null)
            this.chkPrintInOneReport.Value = false;
        if (this._LaboratoryTestDefinition.NotLISTest === null)
            this.chkNotLISTest.Value = false;
        if (this._LaboratoryTestDefinition.RequiresBinaryScanForm === null)
            this.ttRequiresBinaryScanForm.Value = false;
        if (this._LaboratoryTestDefinition.RequiresTripleTestForm === null)
            this.ttReqiresTripleTestForm.Value = false;
        // (<IEditableObject>this._LaboratoryTestDefinition).EndEdit();
    }
    public async CheckCollectionElementDuplication(): Promise<void> {
        let dictionary: Dictionary<string, Object> = new Dictionary<string, Object>();
        let siteIDGuid: Guid = new Guid((await SystemParameterService.GetParameterValue('SITEID', Guid.Empty.toString())));
        // if (Sites.SiteMerkezSagKom !== siteIDGuid) {
        //     if (this._LaboratoryTestDefinition.Departments.length === 0)
        //         throw new Exception((await SystemMessageService.GetMessage(1264)));
        // }
        // Aynı Bölüm Kontrolü
        for (let i: number = 0; i < this._LaboratoryTestDefinition.Departments.length; i++) {
            let Code: string = this._LaboratoryTestDefinition.Departments[i].Department.ObjectID.toString();
            this.CheckAndAddToDictionary(dictionary, Code, this._TTObject, 'Bölüm');
        }
        dictionary.clear();
        // Aynı Cihaz Kontrolü

        for (let i: number = 0; i < this._LaboratoryTestDefinition.Equipments.length; i++) {
            let Code: string = this._LaboratoryTestDefinition.Equipments[i].Equipment.ObjectID.toString();
            this.CheckAndAddToDictionary(dictionary, Code, this._TTObject, 'Cihaz');
        }
        dictionary.clear();
        // Aynı Malzeme Kontrolü
        for (let i: number = 0; i < this._LaboratoryTestDefinition.Materials.length; i++) {
            let Code: string = this._LaboratoryTestDefinition.Materials[i].Material.ObjectID.toString();
            this.CheckAndAddToDictionary(dictionary, Code, this._TTObject, 'Malzeme');
        }
        dictionary.clear();
        // Aynı PanelTests Kontrolü
        for (let i: number = 0; i < this._LaboratoryTestDefinition.PanelTests.length; i++) {
            let Code: string = this._LaboratoryTestDefinition.PanelTests[i].LaboratoryTest.ObjectID.toString();
            this.CheckAndAddToDictionary(dictionary, Code, this._TTObject, 'Malzeme');
        }
        dictionary.clear();
    }
    public async CheckLaboratoryTestDefinitionConsistency(): Promise<void> {
        let isPanel: boolean = this.IsPanel.Value;
        let isSubTest: boolean = this.IsSubTest.Value;
        let isSAT: boolean = this.IsSAT.Value;
        let isDurationControl: boolean = this.IsDurationControl.Value;
        let isBoundedTest: boolean = this.IsBoundedTest.Value;
        let isRestrictedTest: boolean = this.IsRestrictedTest.Value;
        let isSexControl: boolean = this.IsSexControl.Value;
        //bool isHeader = IsHeader.Value.Value;
        let isPrintEveryPage: boolean = this.IsPrintEveryPage.Value;
        if (isPanel) {
            if (this.isGridHasZeroRows(this.GridPanelTests))
                throw new Exception((await SystemMessageService.GetMessage(1256)));
            if (isSubTest)
                throw new Exception((await SystemMessageService.GetMessage(1257)));
        }
        if (isSubTest && !this.isGridHasZeroRows(this.TabNameGrid))
            throw new Exception((await SystemMessageService.GetMessage(1258)));
        if (isSubTest && isBoundedTest)
            throw new Exception((await SystemMessageService.GetMessage(1259)));
        if (isBoundedTest && this.isGridHasZeroRows(this.GridBoundedTests))
            throw new Exception((await SystemMessageService.GetMessage(1260)));
        if (isRestrictedTest && this.isGridHasZeroRows(this.GridRestrictedTests))
            throw new Exception((await SystemMessageService.GetMessage(1261)));
        if (isSexControl && this.sexListBox.SelectedObject === null)
            throw new Exception((await SystemMessageService.GetMessage(1262)));
        if (isDurationControl && this.DurationValue.Text === null)
            throw new Exception((await SystemMessageService.GetMessage(1263)));
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryTestDefinition();
        this.laboratoryTestDefinitionNewFormViewModel = new LaboratoryTestDefinitionNewFormViewModel();
        this._ViewModel = this.laboratoryTestDefinitionNewFormViewModel;
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition = this._TTObject as LaboratoryTestDefinition;
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.SKRSLoincKodu = new SKRSLOINC();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.RequestFormTab = new LaboratoryRequestFormTabDefinition();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Sex = new SKRSCinsiyet();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.TestType = new LaboratoryTestTypeDefinition();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.TabNames = new Array<LaboratoryTabNamesGrid>();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.PanelTests = new Array<LaboratoryGridPanelTestDefinition>();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Departments = new Array<LaboratoryGridDepartmentDefinition>();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.RestrictedTests = new Array<LaboratoryGridRestrictedTestDefiniton>();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.BoundedTests = new Array<LaboratoryGridBoundedTestDefinition>();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Materials = new Array<LaboratoryGridMaterialDefinition>();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Branch = new SpecialityDefinition();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.TahlilTipi = new TahlilTipi();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Branchs = new Array<LabGridSpecialityDefinition>();

        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.GILDefinition = new GILDefinition();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();
        this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.laboratoryTestDefinitionNewFormViewModel = this._ViewModel as LaboratoryTestDefinitionNewFormViewModel;
        that._TTObject = this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition;
        if (this.laboratoryTestDefinitionNewFormViewModel == null)
            this.laboratoryTestDefinitionNewFormViewModel = new LaboratoryTestDefinitionNewFormViewModel();
        if (this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition == null)
            this.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition = new LaboratoryTestDefinition();
        let sKRSLoincKoduObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["SKRSLoincKodu"];
        if (sKRSLoincKoduObjectID != null && (typeof sKRSLoincKoduObjectID === "string")) {
            let sKRSLoincKodu = that.laboratoryTestDefinitionNewFormViewModel.SKRSLOINCs.find(o => o.ObjectID.toString() === sKRSLoincKoduObjectID.toString());
            if (sKRSLoincKodu) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.SKRSLoincKodu = sKRSLoincKodu;
            }
        }


        let requestFormTabObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["RequestFormTab"];
        if (requestFormTabObjectID != null && (typeof requestFormTabObjectID === "string")) {
            let requestFormTab = that.laboratoryTestDefinitionNewFormViewModel.LaboratoryRequestFormTabDefinitions.find(o => o.ObjectID.toString() === requestFormTabObjectID.toString());
            if (requestFormTab) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.RequestFormTab = requestFormTab;
            }
        }


        let sexObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["Sex"];
        if (sexObjectID != null && (typeof sexObjectID === "string")) {
            let sex = that.laboratoryTestDefinitionNewFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
            if (sex) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Sex = sex;
            }
        }


        let procedureTreeObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.laboratoryTestDefinitionNewFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.ProcedureTree = procedureTree;
            }
        }


        let testTypeObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["TestType"];
        if (testTypeObjectID != null && (typeof testTypeObjectID === "string")) {
            let testType = that.laboratoryTestDefinitionNewFormViewModel.LaboratoryTestTypeDefinitions.find(o => o.ObjectID.toString() === testTypeObjectID.toString());
            if (testType) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.TestType = testType;
            }
        }


        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.TabNames = that.laboratoryTestDefinitionNewFormViewModel.TabNameGridGridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.TabNameGridGridList) {
            let requestFormTabObjectID = detailItem["RequestFormTab"];
            if (requestFormTabObjectID != null && (typeof requestFormTabObjectID === "string")) {
                let requestFormTab = that.laboratoryTestDefinitionNewFormViewModel.LaboratoryRequestFormTabDefinitions.find(o => o.ObjectID.toString() === requestFormTabObjectID.toString());
                if (requestFormTab) {
                    detailItem.RequestFormTab = requestFormTab;
                }
            }

        }

        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.PanelTests = that.laboratoryTestDefinitionNewFormViewModel.GridPanelTestsGridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.GridPanelTestsGridList) {
            let laboratoryTestObjectID = detailItem["LaboratoryTest"];
            if (laboratoryTestObjectID != null && (typeof laboratoryTestObjectID === "string")) {
                let laboratoryTest = that.laboratoryTestDefinitionNewFormViewModel.LaboratoryTestDefinitions.find(o => o.ObjectID.toString() === laboratoryTestObjectID.toString());
                if (laboratoryTest) {
                    detailItem.LaboratoryTest = laboratoryTest;
                }
            }

        }

        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Departments = that.laboratoryTestDefinitionNewFormViewModel.GridDepartmentsGridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.GridDepartmentsGridList) {
            let departmentObjectID = detailItem["Department"];
            if (departmentObjectID != null && (typeof departmentObjectID === "string")) {
                let department = that.laboratoryTestDefinitionNewFormViewModel.ResLaboratoryDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
                if (department) {
                    detailItem.Department = department;
                }
            }

        }

        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.RestrictedTests = that.laboratoryTestDefinitionNewFormViewModel.GridRestrictedTestsGridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.GridRestrictedTestsGridList) {
            let laboratoryTestObjectID = detailItem["LaboratoryTest"];
            if (laboratoryTestObjectID != null && (typeof laboratoryTestObjectID === "string")) {
                let laboratoryTest = that.laboratoryTestDefinitionNewFormViewModel.LaboratoryTestDefinitions.find(o => o.ObjectID.toString() === laboratoryTestObjectID.toString());
                if (laboratoryTest) {
                    detailItem.LaboratoryTest = laboratoryTest;
                }
            }

        }

        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.BoundedTests = that.laboratoryTestDefinitionNewFormViewModel.GridBoundedTestsGridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.GridBoundedTestsGridList) {
            let laboratoryTestObjectID = detailItem["LaboratoryTest"];
            if (laboratoryTestObjectID != null && (typeof laboratoryTestObjectID === "string")) {
                let laboratoryTest = that.laboratoryTestDefinitionNewFormViewModel.LaboratoryTestDefinitions.find(o => o.ObjectID.toString() === laboratoryTestObjectID.toString());
                if (laboratoryTest) {
                    detailItem.LaboratoryTest = laboratoryTest;
                }
            }

        }

        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Materials = that.laboratoryTestDefinitionNewFormViewModel.GridMaterialsGridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.GridMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.laboratoryTestDefinitionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }

        let branchObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["Branch"];
        if (branchObjectID != null && (typeof branchObjectID === "string")) {
            let branch = that.laboratoryTestDefinitionNewFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === branchObjectID.toString());
            if (branch) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Branch = branch;
            }
        }


        let tahlilTipiObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["TahlilTipi"];
        if (tahlilTipiObjectID != null && (typeof tahlilTipiObjectID === "string")) {
            let tahlilTipi = that.laboratoryTestDefinitionNewFormViewModel.TahlilTipis.find(o => o.ObjectID.toString() === tahlilTipiObjectID.toString());
            if (tahlilTipi) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.TahlilTipi = tahlilTipi;
            }
        }

        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.Branchs = that.laboratoryTestDefinitionNewFormViewModel.ttgrid1GridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.ttgrid1GridList) {
            let specialityDefinitonObjectID = detailItem["SpecialityDefiniton"];
            if (specialityDefinitonObjectID != null && (typeof specialityDefinitonObjectID === "string")) {
                let specialityDefiniton = that.laboratoryTestDefinitionNewFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityDefinitonObjectID.toString());
                if (specialityDefiniton) {
                    detailItem.SpecialityDefiniton = specialityDefiniton;
                }
            }
        }

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.laboratoryTestDefinitionNewFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.laboratoryTestDefinitionNewFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.GILDefinition = gILDefinition;
            }
        }

        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.SubProcedureDefinitions = that.laboratoryTestDefinitionNewFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.laboratoryTestDefinitionNewFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.laboratoryTestDefinitionNewFormViewModel._LaboratoryTestDefinition.RequiredDiagnoseProcedures = that.laboratoryTestDefinitionNewFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.laboratoryTestDefinitionNewFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.laboratoryTestDefinitionNewFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
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

public onAdultAlertChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.AdultAlert != event) { 
    this._LaboratoryTestDefinition.AdultAlert = event;
}
}

public onAdultNegativeChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.AdultNegative != event) { 
    this._LaboratoryTestDefinition.AdultNegative = event;
}
}

public onAdultPositiveChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.AdultPositive != event) { 
    this._LaboratoryTestDefinition.AdultPositive = event;
}
}

public onBranchChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.Branch != event) { 
    this._LaboratoryTestDefinition.Branch = event;
}
}

public onchkNotLISTestChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.NotLISTest != event) { 
    this._LaboratoryTestDefinition.NotLISTest = event;
}
}

public onchkPassiveNowChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsPassiveNow != event) { 
    this._LaboratoryTestDefinition.IsPassiveNow = event;
}
}

public onchkPrintInOneReportChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.PrintInOneReport != event) { 
    this._LaboratoryTestDefinition.PrintInOneReport = event;
}
}

public onchkSendOtherResultsChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.SendOtherResultsToMedula != event) { 
    this._LaboratoryTestDefinition.SendOtherResultsToMedula = event;
}
}

public onCodeChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.Code != event) { 
    this._LaboratoryTestDefinition.Code = event;
}
}

public onDefaultTabChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.RequestFormTab != event) { 
    this._LaboratoryTestDefinition.RequestFormTab = event;
}
}

public onDescriptionChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.Description != event) { 
    this._LaboratoryTestDefinition.Description = event;
}
}

public onDurationValueChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.DurationValue != event) { 
    this._LaboratoryTestDefinition.DurationValue = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.EnglishName != event) { 
    this._LaboratoryTestDefinition.EnglishName = event;
}
}

public onIsActiveChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsActive != event) { 
    this._LaboratoryTestDefinition.IsActive = event;
}
}

public onIsBoundedTestChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsBoundedTest != event) { 
    this._LaboratoryTestDefinition.IsBoundedTest = event;
}
}

public onIsDurationControlChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsDurationControl != event) { 
    this._LaboratoryTestDefinition.IsDurationControl = event;
}
}

public onIsGroupChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsGroupTest != event) { 
    this._LaboratoryTestDefinition.IsGroupTest = event;
}
}

public onIsPanelChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsPanel != event) { 
    this._LaboratoryTestDefinition.IsPanel = event;
}
}

public onIsPrintEveryPageChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsPrintEveryPage != event) { 
    this._LaboratoryTestDefinition.IsPrintEveryPage = event;
}
}

public onIsRestrictedTestChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsRestrictedTest != event) { 
    this._LaboratoryTestDefinition.IsRestrictedTest = event;
}
}

public onIsSATChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsSat != event) { 
    this._LaboratoryTestDefinition.IsSat = event;
}
}

public onIsSexControlChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsSexControl != event) { 
    this._LaboratoryTestDefinition.IsSexControl = event;
}
}

public onIsSubTestChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.IsSubTest != event) { 
    this._LaboratoryTestDefinition.IsSubTest = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.MedulaProcedureType != event) { 
    this._LaboratoryTestDefinition.MedulaProcedureType = event;
}
}

public onNewBornAlertChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.NewBornAlert != event) { 
    this._LaboratoryTestDefinition.NewBornAlert = event;
}
}

public onNewBornNegativeChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.NewBornNegative != event) { 
    this._LaboratoryTestDefinition.NewBornNegative = event;
}
}

public onNewBornPositiveChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.NewBornPositive != event) { 
    this._LaboratoryTestDefinition.NewBornPositive = event;
}
}

public onPriceCoefficientChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.PriceCoefficient != event) { 
    this._LaboratoryTestDefinition.PriceCoefficient = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.ProcedureTree != event) { 
    this._LaboratoryTestDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.Qref != event) { 
    this._LaboratoryTestDefinition.Qref = event;
}
}

public onRequiresDiabetesFormChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.RequiresDiabetesForm != event) { 
    this._LaboratoryTestDefinition.RequiresDiabetesForm = event;
}
}

public onsexListBoxChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.Sex != event) { 
    this._LaboratoryTestDefinition.Sex = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.SUTAppendix != event) { 
    this._LaboratoryTestDefinition.SUTAppendix = event;
}
}

public onTabDescriptionChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.TabDescription != event) { 
    this._LaboratoryTestDefinition.TabDescription = event;
}
}

public onTahlilTipiChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.TahlilTipi != event) { 
    this._LaboratoryTestDefinition.TahlilTipi = event;
}
}

public onTestNameChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.Name != event) { 
    this._LaboratoryTestDefinition.Name = event;
}
}

public onTestTypeChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.TestType != event) { 
    this._LaboratoryTestDefinition.TestType = event;
}
}

public onttcheckbox1Changed(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.SendByRequestDoctor != event) { 
    this._LaboratoryTestDefinition.SendByRequestDoctor = event;
}
}

public onttcheckbox2Changed(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.NotLISTest != event) { 
    this._LaboratoryTestDefinition.NotLISTest = event;
}
}

public onTTListBoxChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.SKRSLoincKodu != event) { 
    this._LaboratoryTestDefinition.SKRSLoincKodu = event;
}
}

public onttReqiresTripleTestFormChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.RequiresTripleTestForm != event) { 
    this._LaboratoryTestDefinition.RequiresTripleTestForm = event;
}
}

public onttRequiresBinaryScanFormChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.RequiresBinaryScanForm != event) { 
    this._LaboratoryTestDefinition.RequiresBinaryScanForm = event;
}
}

public onttRequiresUreaBreathTestReportChanged(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.RequiresUreaBreathTestReport != event) { 
    this._LaboratoryTestDefinition.RequiresUreaBreathTestReport = event;
}
}

public ontttextbox1Changed(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.Description != event) { 
    this._LaboratoryTestDefinition.Description = event;
}
}

public ontttextbox2Changed(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.ReasonForPassive != event) { 
    this._LaboratoryTestDefinition.ReasonForPassive = event;
}
}

public ontttextbox3Changed(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.Description != event) { 
    this._LaboratoryTestDefinition.Description = event;
}
}

public ontttextbox4Changed(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.TestDescription != event) { 
    this._LaboratoryTestDefinition.TestDescription = event;
}
}

public ontttextbox5Changed(event): void {
    if(this._LaboratoryTestDefinition != null && this._LaboratoryTestDefinition.FreeLOINCCode != event) { 
    this._LaboratoryTestDefinition.FreeLOINCCode = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.TestName, "Text", this.__ttObject, "Name");
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.tttextbox2, "Text", this.__ttObject, "ReasonForPassive");
    redirectProperty(this.chkPassiveNow, "Value", this.__ttObject, "IsPassiveNow");
    redirectProperty(this.tttextbox5, "Text", this.__ttObject, "FreeLOINCCode");
    redirectProperty(this.IsPanel, "Value", this.__ttObject, "IsPanel");
    redirectProperty(this.IsSubTest, "Value", this.__ttObject, "IsSubTest");
    redirectProperty(this.IsSAT, "Value", this.__ttObject, "IsSat");
    redirectProperty(this.IsDurationControl, "Value", this.__ttObject, "IsDurationControl");
    redirectProperty(this.IsBoundedTest, "Value", this.__ttObject, "IsBoundedTest");
    redirectProperty(this.IsRestrictedTest, "Value", this.__ttObject, "IsRestrictedTest");
    redirectProperty(this.IsSexControl, "Value", this.__ttObject, "IsSexControl");
    redirectProperty(this.IsPrintEveryPage, "Value", this.__ttObject, "IsPrintEveryPage");
    redirectProperty(this.chkPrintInOneReport, "Value", this.__ttObject, "PrintInOneReport");
    redirectProperty(this.chkNotLISTest, "Value", this.__ttObject, "NotLISTest");
    redirectProperty(this.IsGroup, "Value", this.__ttObject, "IsGroupTest");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.TabDescription, "Text", this.__ttObject, "TabDescription");
    redirectProperty(this.DurationValue, "Text", this.__ttObject, "DurationValue");
    redirectProperty(this.PriceCoefficient, "Text", this.__ttObject, "PriceCoefficient");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
    redirectProperty(this.chkSendOtherResults, "Value", this.__ttObject, "SendOtherResultsToMedula");
    redirectProperty(this.RequiresDiabetesForm, "Value", this.__ttObject, "RequiresDiabetesForm");
    redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "SendByRequestDoctor");
    redirectProperty(this.ttRequiresBinaryScanForm, "Value", this.__ttObject, "RequiresBinaryScanForm");
    redirectProperty(this.ttReqiresTripleTestForm, "Value", this.__ttObject, "RequiresTripleTestForm");
    redirectProperty(this.ttRequiresUreaBreathTestReport, "Value", this.__ttObject, "RequiresUreaBreathTestReport");
    redirectProperty(this.tttextbox4, "Text", this.__ttObject, "TestDescription");
    redirectProperty(this.AdultPositive, "Value", this.__ttObject, "AdultPositive");
    redirectProperty(this.AdultNegative, "Value", this.__ttObject, "AdultNegative");
    redirectProperty(this.AdultAlert, "Text", this.__ttObject, "AdultAlert");
    redirectProperty(this.NewBornPositive, "Value", this.__ttObject, "NewBornPositive");
    redirectProperty(this.NewBornNegative, "Value", this.__ttObject, "NewBornNegative");
    redirectProperty(this.NewBornAlert, "Text", this.__ttObject, "NewBornAlert");
    redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Description");
    redirectProperty(this.tttextbox3, "Text", this.__ttObject, "Description");
    redirectProperty(this.ttcheckbox2, "Value", this.__ttObject, "NotLISTest");
}

public initFormControls() : void {
    this.TTListBox = new TTVisual.TTObjectListBox();
    this.TTListBox.ListDefName = "SKRSLOINCList";
    this.TTListBox.Text = "LOINC Listesi";
    this.TTListBox.Name = "TTListBox";
    this.TTListBox.TabIndex = 150;

    this.tttextbox2 = new TTVisual.TTTextBox();
    this.tttextbox2.Multiline = true;
    this.tttextbox2.Name = "tttextbox2";
    this.tttextbox2.TabIndex = 3;

    this.TestName = new TTVisual.TTTextBox();
    this.TestName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TestName.Name = "TestName";
    this.TestName.TabIndex = 1;

    this.ttlabel10 = new TTVisual.TTLabel();
    this.ttlabel10.Text = "Çalışmama Nedeni";
    this.ttlabel10.Name = "ttlabel10";
    this.ttlabel10.TabIndex = 147;

    this.chkPassiveNow = new TTVisual.TTCheckBox();
    this.chkPassiveNow.Value = false;
    this.chkPassiveNow.Title = "Çalışılmayan Tetkik";
    this.chkPassiveNow.Name = "chkPassiveNow";
    this.chkPassiveNow.TabIndex = 145;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = false;
    this.IsActive.Text = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 2;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Tetkik Adı";
    this.labelName.BackColor = "#DCDCDC";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 40;

    this.TabControlInfos = new TTVisual.TTTabControl();
    this.TabControlInfos.Name = "TabControlInfos";
    this.TabControlInfos.TabIndex = 52;

    this.TabPageGeneralInfo = new TTVisual.TTTabPage();
    this.TabPageGeneralInfo.DisplayIndex = 0;
    this.TabPageGeneralInfo.BackColor = "#FFFFFF";
    this.TabPageGeneralInfo.TabIndex = 0;
    this.TabPageGeneralInfo.Text = "Genel Tanımlar";
    this.TabPageGeneralInfo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabPageGeneralInfo.Name = "TabPageGeneralInfo";

    this.lblDefaultTab = new TTVisual.TTLabel();
    this.lblDefaultTab.Text = "Varsayılan Tab";
    this.lblDefaultTab.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.lblDefaultTab.Name = "lblDefaultTab";
    this.lblDefaultTab.TabIndex = 147;

    this.DefaultTab = new TTVisual.TTObjectListBox();
    this.DefaultTab.ListDefName = "LaboratoryRequestFormTabListDefinition";
    this.DefaultTab.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.DefaultTab.Name = "DefaultTab";
    this.DefaultTab.TabIndex = 146;

    this.chkPrintInOneReport = new TTVisual.TTCheckBox();
    this.chkPrintInOneReport.Value = false;
    this.chkPrintInOneReport.Title = "Kültür Sonucu (Tek Rapor)";
    this.chkPrintInOneReport.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.chkPrintInOneReport.Name = "chkPrintInOneReport";
    this.chkPrintInOneReport.TabIndex = 145;

    this.ttlabel5 = new TTVisual.TTLabel();
    this.ttlabel5.Text = "Hizmet";
    this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel5.Name = "ttlabel5";
    this.ttlabel5.TabIndex = 144;

    this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox1.ListDefName = "";
    this.ttobjectlistbox1.Text = "select * from labtestdef_v where sexcontrol is not null";
    this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttobjectlistbox1.Name = "ttobjectlistbox1";
    this.ttobjectlistbox1.TabIndex = 5;

    this.IsPrintEveryPage = new TTVisual.TTCheckBox();
    this.IsPrintEveryPage.Value = false;
    this.IsPrintEveryPage.Title = "Ayrı Sayfaya Basım";
    this.IsPrintEveryPage.Name = "IsPrintEveryPage";
    this.IsPrintEveryPage.TabIndex = 17;

    this.IsSexControl = new TTVisual.TTCheckBox();
    this.IsSexControl.Value = false;
    this.IsSexControl.Title = "Cinsiyet Kontrollü";
    this.IsSexControl.Name = "IsSexControl";
    this.IsSexControl.TabIndex = 16;

    this.IsRestrictedTest = new TTVisual.TTCheckBox();
    this.IsRestrictedTest.Value = false;
    this.IsRestrictedTest.Title = "Kısıtlamalı Tetkik";
    this.IsRestrictedTest.Name = "IsRestrictedTest";
    this.IsRestrictedTest.TabIndex = 15;

    this.ttlabel7 = new TTVisual.TTLabel();
    this.ttlabel7.Text = "Tab Açıklaması";
    this.ttlabel7.ForeColor = "#000000";
    this.ttlabel7.Name = "ttlabel7";
    this.ttlabel7.TabIndex = 88;

    this.TabDescription = new TTVisual.TTTextBox();
    this.TabDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabDescription.Name = "TabDescription";
    this.TabDescription.TabIndex = 9;

    this.IsDurationControl = new TTVisual.TTCheckBox();
    this.IsDurationControl.Value = false;
    this.IsDurationControl.Title = "Süre Kontrollü";
    this.IsDurationControl.Name = "IsDurationControl";
    this.IsDurationControl.TabIndex = 13;

    this.chkNotLISTest = new TTVisual.TTCheckBox();
    this.chkNotLISTest.Value = false;
    this.chkNotLISTest.Title = "LBS'ye Gönderme";
    this.chkNotLISTest.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.chkNotLISTest.Name = "chkNotLISTest";
    this.chkNotLISTest.TabIndex = 145;

    this.IsBoundedTest = new TTVisual.TTCheckBox();
    this.IsBoundedTest.Value = false;
    this.IsBoundedTest.Title = "Bağımlı Tetkik";
    this.IsBoundedTest.Name = "IsBoundedTest";
    this.IsBoundedTest.TabIndex = 14;

    this.PriceCoefficient = new TTVisual.TTTextBox();
    this.PriceCoefficient.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.PriceCoefficient.Name = "PriceCoefficient";
    this.PriceCoefficient.TabIndex = 8;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Fiyat Çarpan";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 126;

    this.ttlabel6 = new TTVisual.TTLabel();
    this.ttlabel6.Text = "Cinsiyet Kontrolü";
    this.ttlabel6.ForeColor = "#000000";
    this.ttlabel6.Name = "ttlabel6";
    this.ttlabel6.TabIndex = 69;

    this.IsSAT = new TTVisual.TTCheckBox();
    this.IsSAT.Value = false;
    this.IsSAT.Title = "S.A.T Zorunlu";
    this.IsSAT.Name = "IsSAT";
    this.IsSAT.TabIndex = 12;

    this.IsGroup = new TTVisual.TTCheckBox();
    this.IsGroup.Value = false;
    this.IsGroup.Title = "Grup Tetkik";
    this.IsGroup.Name = "IsGroup";
    this.IsGroup.TabIndex = 2;

    this.IsSubTest = new TTVisual.TTCheckBox();
    this.IsSubTest.Value = false;
    this.IsSubTest.Title = "Alt Tetkik";
    this.IsSubTest.Name = "IsSubTest";
    this.IsSubTest.TabIndex = 11;

    this.sexListBox = new TTVisual.TTObjectListBox();
    this.sexListBox.ListDefName = "SKRSCinsiyetList";
    this.sexListBox.Text = "Cinsiyet Listesi";
    this.sexListBox.Name = "sexListBox";
    this.sexListBox.TabIndex = 150;

    this.IsPanel = new TTVisual.TTCheckBox();
    this.IsPanel.Value = false;
    this.IsPanel.Title = "Panel";
    this.IsPanel.Name = "IsPanel";
    this.IsPanel.TabIndex = 10;

    this.DurationValue = new TTVisual.TTTextBox();
    this.DurationValue.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.DurationValue.Name = "DurationValue";
    this.DurationValue.TabIndex = 6;

    this.ttlabel23 = new TTVisual.TTLabel();
    this.ttlabel23.Text = "Süre Kontrol(Gün)";
    this.ttlabel23.Name = "ttlabel23";
    this.ttlabel23.TabIndex = 126;

    this.ProcedureTree = new TTVisual.TTObjectListBox();
    this.ProcedureTree.ListDefName = "ProcedureTreeListDefinition";
    this.ProcedureTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ProcedureTree.Name = "ProcedureTree";
    this.ProcedureTree.TabIndex = 3;

    this.ttlabel4 = new TTVisual.TTLabel();
    this.ttlabel4.Text = "Hizmet Sınıfı";
    this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel4.Name = "ttlabel4";
    this.ttlabel4.TabIndex = 119;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 0;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Açıklama";
    this.labelQref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 31;

    this.labelEnglishName = new TTVisual.TTLabel();
    this.labelEnglishName.Text = "Tetkik İngilizce Adı";
    this.labelEnglishName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelEnglishName.ForeColor = "#000000";
    this.labelEnglishName.Name = "labelEnglishName";
    this.labelEnglishName.TabIndex = 33;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 2;

    this.ttlabel8 = new TTVisual.TTLabel();
    this.ttlabel8.Text = "Tetkik Türü";
    this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel8.ForeColor = "#000000";
    this.ttlabel8.Name = "ttlabel8";
    this.ttlabel8.TabIndex = 81;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Description.Name = "Description";
    this.Description.TabIndex = 4;

    this.TestType = new TTVisual.TTObjectListBox();
    this.TestType.ListDefName = "LaboratoryTestTypeListDefinition";
    this.TestType.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TestType.Name = "TestType";
    this.TestType.TabIndex = 1;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 83;

    this.ttgroupbox1 = new TTVisual.TTGroupBox();
    this.ttgroupbox1.Text = "Tab Yerleşim Bilgileri";
    this.ttgroupbox1.BackColor = "#FFFFFF";
    this.ttgroupbox1.Name = "ttgroupbox1";
    this.ttgroupbox1.TabIndex = 114;

    this.TabNameGrid = new TTVisual.TTGrid();
    this.TabNameGrid.Name = "TabNameGrid";
    this.TabNameGrid.TabIndex = 0;

    this.TabNames = new TTVisual.TTListBoxColumn();
    this.TabNames.ListDefName = "LaboratoryRequestFormTabListDefinition";
    this.TabNames.DataMember = "RequestFormTab";
    this.TabNames.DisplayIndex = 0;
    this.TabNames.HeaderText = "Tab Adı";
    this.TabNames.Name = "TabNames";
    this.TabNames.Width = 320;

    this.TabOrder = new TTVisual.TTTextBoxColumn();
    this.TabOrder.DataMember = "TabOrder";
    this.TabOrder.DisplayIndex = 1;
    this.TabOrder.HeaderText = "Sıra No";
    this.TabOrder.Name = "TabOrder";
    this.TabOrder.Width = 50;

    this.TabPagePanel = new TTVisual.TTTabPage();
    this.TabPagePanel.DisplayIndex = 1;
    this.TabPagePanel.BackColor = "#FFFFFF";
    this.TabPagePanel.TabIndex = 0;
    this.TabPagePanel.Text = "Panel";
    this.TabPagePanel.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabPagePanel.Name = "TabPagePanel";

    this.ttlabel12 = new TTVisual.TTLabel();
    this.ttlabel12.Text = "Panel Tetkikleri";
    this.ttlabel12.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel12.ForeColor = "#000000";
    this.ttlabel12.Name = "ttlabel12";
    this.ttlabel12.TabIndex = 54;

    this.GridPanelTests = new TTVisual.TTGrid();
    this.GridPanelTests.Name = "GridPanelTests";
    this.GridPanelTests.TabIndex = 53;

    this.PanelTest = new TTVisual.TTListBoxColumn();
    this.PanelTest.ListDefName = "LaboratorySubTestListDefinition";
    this.PanelTest.DataMember = "LaboratoryTest";
    this.PanelTest.DisplayIndex = 0;
    this.PanelTest.HeaderText = "Alt Tetkik Adı";
    this.PanelTest.MinimumWidth = 350;
    this.PanelTest.Name = "PanelTest";
    this.PanelTest.Width = 450;
    this.PanelTest.PopupDialogHeight = "250px";
    this.PanelTest.AutoCompleteDialogHeight = "250px";

    this.SequenceNo = new TTVisual.TTTextBoxColumn();
    this.SequenceNo.DataMember = "SequenceNo";
    this.SequenceNo.DisplayIndex = 1;
    this.SequenceNo.HeaderText = "Sıra No";
    this.SequenceNo.MinimumWidth = 50;
    this.SequenceNo.Name = "SequenceNo";
    this.SequenceNo.Width = 50;

    this.TabPageResource = new TTVisual.TTTabPage();
    this.TabPageResource.DisplayIndex = 2;
    this.TabPageResource.BackColor = "#FFFFFF";
    this.TabPageResource.TabIndex = 0;
    this.TabPageResource.Text = "Bölüm";
    this.TabPageResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabPageResource.Name = "TabPageResource";

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Çalışacak Bölümler";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 50;

    this.GridDepartments = new TTVisual.TTGrid();
    this.GridDepartments.Name = "GridDepartments";
    this.GridDepartments.TabIndex = 54;

    this.Department = new TTVisual.TTListBoxColumn();
    this.Department.ListDefName = "ResLaboratoryDepartmentListDefinition";
    this.Department.DataMember = "Department";
    this.Department.DisplayIndex = 0;
    this.Department.HeaderText = "Bölüm";
    this.Department.Name = "Department";
    this.Department.Width = 420;

    this.TabPageBoundRestrictedTests = new TTVisual.TTTabPage();
    this.TabPageBoundRestrictedTests.DisplayIndex = 3;
    this.TabPageBoundRestrictedTests.BackColor = "#FFFFFF";
    this.TabPageBoundRestrictedTests.TabIndex = 1;
    this.TabPageBoundRestrictedTests.Text = "Bağımlı/Kısıtlamalı Tetkik";
    this.TabPageBoundRestrictedTests.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabPageBoundRestrictedTests.Name = "TabPageBoundRestrictedTests";

    this.ttlabel11 = new TTVisual.TTLabel();
    this.ttlabel11.Text = "Kısıtlı Tetkikler";
    this.ttlabel11.Name = "ttlabel11";
    this.ttlabel11.TabIndex = 3;

    this.GridRestrictedTests = new TTVisual.TTGrid();
    this.GridRestrictedTests.Name = "GridRestrictedTests";
    this.GridRestrictedTests.TabIndex = 2;

    this.RestrictedTestName = new TTVisual.TTListBoxColumn();
    this.RestrictedTestName.ListDefName = "LaboratoryNotSubTestListDefinition";
    this.RestrictedTestName.DataMember = "LaboratoryTest";
    this.RestrictedTestName.DisplayIndex = 0;
    this.RestrictedTestName.HeaderText = "Tetkik Adı";
    this.RestrictedTestName.Name = "RestrictedTestName";
    this.RestrictedTestName.Width = 420;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Bağımlı Tetkikler için Kullanılacak Tetkikler";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 1;

    this.GridBoundedTests = new TTVisual.TTGrid();
    this.GridBoundedTests.Name = "GridBoundedTests";
    this.GridBoundedTests.TabIndex = 0;

    this.BoundedTestName = new TTVisual.TTListBoxColumn();
    this.BoundedTestName.ListDefName = "LaboratoryNotSubTestListDefinition";
    this.BoundedTestName.DataMember = "LaboratoryTest";
    this.BoundedTestName.DisplayIndex = 0;
    this.BoundedTestName.HeaderText = "Tetkik Adı";
    this.BoundedTestName.Name = "BoundedTestName";
    this.BoundedTestName.Width = 420;

    this.TabPageMaterial = new TTVisual.TTTabPage();
    this.TabPageMaterial.DisplayIndex = 4;
    this.TabPageMaterial.BackColor = "#FFFFFF";
    this.TabPageMaterial.TabIndex = 0;
    this.TabPageMaterial.Text = "Malzeme";
    this.TabPageMaterial.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabPageMaterial.Name = "TabPageMaterial";

    this.ttlabel9 = new TTVisual.TTLabel();
    this.ttlabel9.Text = "Kullanılan Malzemeler";
    this.ttlabel9.ForeColor = "#000000";
    this.ttlabel9.Name = "ttlabel9";
    this.ttlabel9.TabIndex = 51;

    this.GridMaterials = new TTVisual.TTGrid();
    this.GridMaterials.Name = "GridMaterials";
    this.GridMaterials.TabIndex = 1;

    this.Material = new TTVisual.TTListBoxColumn();
    this.Material.ListDefName = "TreatmentMaterialListDefinition";
    this.Material.DataMember = "Material";
    this.Material.DisplayIndex = 0;
    this.Material.HeaderText = "Malzeme";
    this.Material.Name = "Material";
    this.Material.Width = 420;

    this.TabPageMedula = new TTVisual.TTTabPage();
    this.TabPageMedula.DisplayIndex = 5;
    this.TabPageMedula.BackColor = "#FFFFFF";
    this.TabPageMedula.TabIndex = 2;
    this.TabPageMedula.Text = "Medula";
    this.TabPageMedula.Name = "TabPageMedula";

    this.Branch = new TTVisual.TTObjectListBox();
    this.Branch.ListDefName = "SpecialityListDefinition";
    this.Branch.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Branch.Name = "Branch";
    this.Branch.TabIndex = 150;

    this.RequiresDiabetesForm = new TTVisual.TTCheckBox();
    this.RequiresDiabetesForm.Value = false;
    this.RequiresDiabetesForm.Title = "Diyabet Takip Formu Gerektirir";
    this.RequiresDiabetesForm.Name = "RequiresDiabetesForm";
    this.RequiresDiabetesForm.TabIndex = 148;

    this.TahlilTipi = new TTVisual.TTObjectListBox();
    this.TahlilTipi.ListDefName = "TahlilTipiListDefinition";
    this.TahlilTipi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TahlilTipi.Name = "TahlilTipi";
    this.TahlilTipi.TabIndex = 148;

    this.labelTahlilTipi = new TTVisual.TTLabel();
    this.labelTahlilTipi.Text = "Tahlil Kodu";
    this.labelTahlilTipi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelTahlilTipi.Name = "labelTahlilTipi";
    this.labelTahlilTipi.TabIndex = 149;

    this.chkSendOtherResults = new TTVisual.TTCheckBox();
    this.chkSendOtherResults.Value = false;
    this.chkSendOtherResults.Title = "Tahlil Kodu Diğer Olan Alt Tetkiklerin Sonuçlarını Medulaya Gönder";
    this.chkSendOtherResults.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.chkSendOtherResults.Name = "chkSendOtherResults";
    this.chkSendOtherResults.TabIndex = 145;

    this.labelBranch = new TTVisual.TTLabel();
    this.labelBranch.Text = "Brans";
    this.labelBranch.BackColor = "#DCDCDC";
    this.labelBranch.ForeColor = "#000000";
    this.labelBranch.Name = "labelBranch";
    this.labelBranch.TabIndex = 35;

    this.ttcheckbox1 = new TTVisual.TTCheckBox();
    this.ttcheckbox1.Value = false;
    this.ttcheckbox1.Title = "Hizmet Kaydı Yaparken İstek Yapan Doktor Tescil Numarasını Medulaya Gönder";
    this.ttcheckbox1.Name = "ttcheckbox1";
    this.ttcheckbox1.TabIndex = 148;

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
    this.MedulaProcedureType.DataTypeName = "MedulaSUTGroupEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 64;

    this.TabPagePrerequisiteForms = new TTVisual.TTTabPage();
    this.TabPagePrerequisiteForms.DisplayIndex = 6;
    this.TabPagePrerequisiteForms.TabIndex = 4;
    this.TabPagePrerequisiteForms.Text = "Test Önbilgi Formları";
    this.TabPagePrerequisiteForms.Name = "TabPagePrerequisiteForms";

    this.ttRequiresUreaBreathTestReport = new TTVisual.TTCheckBox();
    this.ttRequiresUreaBreathTestReport.Value = false;
    this.ttRequiresUreaBreathTestReport.Title = "Üre Nefes Testi Hasta Talimatı Gerektirir";
    this.ttRequiresUreaBreathTestReport.Name = "ttRequiresUreaBreathTestReport";
    this.ttRequiresUreaBreathTestReport.TabIndex = 2;

    this.ttReqiresTripleTestForm = new TTVisual.TTCheckBox();
    this.ttReqiresTripleTestForm.Value = false;
    this.ttReqiresTripleTestForm.Title = "Triple Test Formu Gerektirir";
    this.ttReqiresTripleTestForm.Name = "ttReqiresTripleTestForm";
    this.ttReqiresTripleTestForm.TabIndex = 1;

    this.ttRequiresBinaryScanForm = new TTVisual.TTCheckBox();
    this.ttRequiresBinaryScanForm.Value = false;
    this.ttRequiresBinaryScanForm.Title = "İkili Tarama Formu Gerektirir";
    this.ttRequiresBinaryScanForm.Name = "ttRequiresBinaryScanForm";
    this.ttRequiresBinaryScanForm.TabIndex = 0;

    this.tttextbox4 = new TTVisual.TTTextBox();
    this.tttextbox4.Multiline = true;
    this.tttextbox4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttextbox4.Name = "tttextbox4";
    this.tttextbox4.TabIndex = 4;

    this.ttlabel17 = new TTVisual.TTLabel();
    this.ttlabel17.Text = "Test Açıklamaları";
    this.ttlabel17.ForeColor = "#000000";
    this.ttlabel17.Name = "ttlabel17";
    this.ttlabel17.TabIndex = 83;

    this.TabTestBranchRelation = new TTVisual.TTTabPage();
    this.TabTestBranchRelation.DisplayIndex = 7;
    this.TabTestBranchRelation.TabIndex = 5;
    this.TabTestBranchRelation.Text = "İlişkili Branşlar";
    this.TabTestBranchRelation.Name = "TabTestBranchRelation";

    this.ttgrid1 = new TTVisual.TTGrid();
    this.ttgrid1.Name = "ttgrid1";
    this.ttgrid1.TabIndex = 54;

    this.ttlistboxcolumn2 = new TTVisual.TTListBoxColumn();
    this.ttlistboxcolumn2.ListDefName = "SpecialityListDefinition";
    this.ttlistboxcolumn2.DataMember = "SpecialityDefiniton";
    this.ttlistboxcolumn2.DisplayIndex = 0;
    this.ttlistboxcolumn2.HeaderText = "Branş";
    this.ttlistboxcolumn2.Name = "ttlistboxcolumn2";
    this.ttlistboxcolumn2.Width = 420;

    this.ttlabel19 = new TTVisual.TTLabel();
    this.ttlabel19.Text = "Çalışacak Bölümler";
    this.ttlabel19.ForeColor = "#000000";
    this.ttlabel19.Name = "ttlabel19";
    this.ttlabel19.TabIndex = 50;

    this.TabPageTestAlert = new TTVisual.TTTabPage();
    this.TabPageTestAlert.DisplayIndex = 8;
    this.TabPageTestAlert.TabIndex = 6;
    this.TabPageTestAlert.Text = "Test İstem Uyarısı";
    this.TabPageTestAlert.Name = "TabPageTestAlert";

    this.tttabcontrol1 = new TTVisual.TTTabControl();
    this.tttabcontrol1.Name = "tttabcontrol1";
    this.tttabcontrol1.TabIndex = 0;

    this.TabPageAdult = new TTVisual.TTTabPage();
    this.TabPageAdult.DisplayIndex = 0;
    this.TabPageAdult.TabIndex = 0;
    this.TabPageAdult.Text = "Yetişkin";
    this.TabPageAdult.Name = "TabPageAdult";

    this.AdultNegative = new TTVisual.TTCheckBox();
    this.AdultNegative.Value = false;
    this.AdultNegative.Title = "Negatif";
    this.AdultNegative.Name = "AdultNegative";
    this.AdultNegative.TabIndex = 3;

    this.AdultPositive = new TTVisual.TTCheckBox();
    this.AdultPositive.Value = false;
    this.AdultPositive.Title = "Pozitif";
    this.AdultPositive.Name = "AdultPositive";
    this.AdultPositive.TabIndex = 2;

    this.labelAdultAlert = new TTVisual.TTLabel();
    this.labelAdultAlert.Text = "Uyarı Mesajı";
    this.labelAdultAlert.Name = "labelAdultAlert";
    this.labelAdultAlert.TabIndex = 1;

    this.AdultAlert = new TTVisual.TTTextBox();
    this.AdultAlert.Multiline = true;
    this.AdultAlert.Name = "AdultAlert";
    this.AdultAlert.TabIndex = 0;

    this.TabPageNewBorn = new TTVisual.TTTabPage();
    this.TabPageNewBorn.DisplayIndex = 1;
    this.TabPageNewBorn.TabIndex = 1;
    this.TabPageNewBorn.Text = "Yeni Doğan";
    this.TabPageNewBorn.Name = "TabPageNewBorn";

    this.NewBornPositive = new TTVisual.TTCheckBox();
    this.NewBornPositive.Value = false;
    this.NewBornPositive.Title = "Pozitif";
    this.NewBornPositive.Name = "NewBornPositive";
    this.NewBornPositive.TabIndex = 3;

    this.NewBornNegative = new TTVisual.TTCheckBox();
    this.NewBornNegative.Value = false;
    this.NewBornNegative.Title = "Negatif";
    this.NewBornNegative.Name = "NewBornNegative";
    this.NewBornNegative.TabIndex = 2;

    this.labelNewBornAlert = new TTVisual.TTLabel();
    this.labelNewBornAlert.Text = "Uyarı Mesajı";
    this.labelNewBornAlert.Name = "labelNewBornAlert";
    this.labelNewBornAlert.TabIndex = 1;

    this.NewBornAlert = new TTVisual.TTTextBox();
    this.NewBornAlert.Multiline = true;
    this.NewBornAlert.Name = "NewBornAlert";
    this.NewBornAlert.TabIndex = 0;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Code.Name = "Code";
    this.Code.TabIndex = 0;

    this.tttextbox1 = new TTVisual.TTTextBox();
    this.tttextbox1.Multiline = true;
    this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttextbox1.Name = "tttextbox1";
    this.tttextbox1.TabIndex = 4;

    this.tttextbox3 = new TTVisual.TTTextBox();
    this.tttextbox3.Multiline = true;
    this.tttextbox3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttextbox3.Name = "tttextbox3";
    this.tttextbox3.TabIndex = 4;

    this.tttextbox5 = new TTVisual.TTTextBox();
    this.tttextbox5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttextbox5.Name = "tttextbox5";
    this.tttextbox5.TabIndex = 0;

    this.ttlabel13 = new TTVisual.TTLabel();
    this.ttlabel13.Text = "Tahlil Kodu";
    this.ttlabel13.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel13.Name = "ttlabel13";
    this.ttlabel13.TabIndex = 149;

    this.ttlabel14 = new TTVisual.TTLabel();
    this.ttlabel14.Text = "Tahlil Kodu";
    this.ttlabel14.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel14.Name = "ttlabel14";
    this.ttlabel14.TabIndex = 149;

    this.ttlabel15 = new TTVisual.TTLabel();
    this.ttlabel15.Text = "LOINC Kodu";
    this.ttlabel15.BackColor = "#DCDCDC";
    this.ttlabel15.ForeColor = "#000000";
    this.ttlabel15.Name = "ttlabel15";
    this.ttlabel15.TabIndex = 40;

    this.ttlabel16 = new TTVisual.TTLabel();
    this.ttlabel16.Text = "Açıklama";
    this.ttlabel16.ForeColor = "#000000";
    this.ttlabel16.Name = "ttlabel16";
    this.ttlabel16.TabIndex = 83;

    this.ttlabel18 = new TTVisual.TTLabel();
    this.ttlabel18.Text = "Serbest LOINC Kodu (LIS Entg. Kod)";
    this.ttlabel18.BackColor = "#DCDCDC";
    this.ttlabel18.ForeColor = "#000000";
    this.ttlabel18.Name = "ttlabel18";
    this.ttlabel18.TabIndex = 40;

    this.ttcheckbox2 = new TTVisual.TTCheckBox();
    this.ttcheckbox2.Value = false;
    this.ttcheckbox2.Title = "LBS'ye Gönderme";
    this.ttcheckbox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttcheckbox2.Name = "ttcheckbox2";
    this.ttcheckbox2.TabIndex = 145;

    this.PackageProcedure = new TTVisual.TTObjectListBox();
    this.PackageProcedure.ListDefName = "PackageProcedureListDefinition";
    this.PackageProcedure.Name = "PackageProcedure";
    this.PackageProcedure.TabIndex = 18;

    this.TabNameGridColumns = [this.TabNames, this.TabOrder];
    this.GridPanelTestsColumns = [this.PanelTest, this.SequenceNo];
    this.GridDepartmentsColumns = [this.Department];
    this.GridRestrictedTestsColumns = [this.RestrictedTestName];
    this.GridBoundedTestsColumns = [this.BoundedTestName];
    this.GridMaterialsColumns = [this.Material];
    this.ttgrid1Columns = [this.ttlistboxcolumn2];
    this.TabControlInfos.Controls = [this.TabPageGeneralInfo, this.TabPagePanel, this.TabPageResource, this.TabPageBoundRestrictedTests, this.TabPageMaterial, this.TabPageMedula, this.TabPagePrerequisiteForms, this.TabTestBranchRelation, this.TabPageTestAlert];
    this.TabPageGeneralInfo.Controls = [this.lblDefaultTab, this.DefaultTab, this.chkPrintInOneReport, this.ttlabel5, this.ttobjectlistbox1, this.IsPrintEveryPage, this.IsSexControl, this.IsRestrictedTest, this.ttlabel7, this.TabDescription, this.IsDurationControl, this.chkNotLISTest, this.IsBoundedTest, this.PriceCoefficient, this.ttlabel3, this.ttlabel6, this.IsSAT, this.IsGroup, this.IsSubTest, this.sexListBox, this.IsPanel, this.DurationValue, this.ttlabel23, this.ProcedureTree, this.ttlabel4, this.EnglishName, this.labelQref, this.labelEnglishName, this.Qref, this.ttlabel8, this.Description, this.TestType, this.labelDescription, this.ttgroupbox1];
    this.ttgroupbox1.Controls = [this.TabNameGrid];
    this.TabPagePanel.Controls = [this.ttlabel12, this.GridPanelTests];
    this.TabPageResource.Controls = [this.ttlabel1, this.GridDepartments];
    this.TabPageBoundRestrictedTests.Controls = [this.ttlabel11, this.GridRestrictedTests, this.ttlabel2, this.GridBoundedTests];
    this.TabPageMaterial.Controls = [this.ttlabel9, this.GridMaterials];
    this.TabPageMedula.Controls = [this.Branch, this.RequiresDiabetesForm, this.TahlilTipi, this.labelTahlilTipi, this.chkSendOtherResults, this.labelBranch, this.ttcheckbox1, this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType];
    this.TabPagePrerequisiteForms.Controls = [this.ttRequiresUreaBreathTestReport, this.ttReqiresTripleTestForm, this.ttRequiresBinaryScanForm, this.tttextbox4, this.ttlabel17];
    this.TabTestBranchRelation.Controls = [this.ttgrid1, this.ttlabel19];
    this.TabPageTestAlert.Controls = [this.tttabcontrol1];
    this.tttabcontrol1.Controls = [this.TabPageAdult, this.TabPageNewBorn];
    this.TabPageAdult.Controls = [this.AdultNegative, this.AdultPositive, this.labelAdultAlert, this.AdultAlert];
    this.TabPageNewBorn.Controls = [this.NewBornPositive, this.NewBornNegative, this.labelNewBornAlert, this.NewBornAlert];
    this.Controls = [this.TTListBox, this.tttextbox2, this.TestName, this.ttlabel10, this.chkPassiveNow, this.IsActive, this.labelName, this.TabControlInfos, this.TabPageGeneralInfo, this.lblDefaultTab, this.DefaultTab, this.chkPrintInOneReport, this.ttlabel5, this.ttobjectlistbox1, this.IsPrintEveryPage, this.IsSexControl, this.IsRestrictedTest, this.ttlabel7, this.TabDescription, this.IsDurationControl, this.chkNotLISTest, this.IsBoundedTest, this.PriceCoefficient, this.ttlabel3, this.ttlabel6, this.IsSAT, this.IsGroup, this.IsSubTest, this.sexListBox, this.IsPanel, this.DurationValue, this.ttlabel23, this.ProcedureTree, this.ttlabel4, this.EnglishName, this.labelQref, this.labelEnglishName, this.Qref, this.ttlabel8, this.Description, this.TestType, this.labelDescription, this.ttgroupbox1, this.TabNameGrid, this.TabNames, this.TabOrder, this.TabPagePanel, this.ttlabel12, this.GridPanelTests, this.PanelTest, this.SequenceNo, this.TabPageResource, this.ttlabel1, this.GridDepartments, this.Department, this.TabPageBoundRestrictedTests, this.ttlabel11, this.GridRestrictedTests, this.RestrictedTestName, this.ttlabel2, this.GridBoundedTests, this.BoundedTestName, this.TabPageMaterial, this.ttlabel9, this.GridMaterials, this.Material, this.TabPageMedula, this.Branch, this.RequiresDiabetesForm, this.TahlilTipi, this.labelTahlilTipi, this.chkSendOtherResults, this.labelBranch, this.ttcheckbox1, this.labelSUTAppendix, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.TabPagePrerequisiteForms, this.ttRequiresUreaBreathTestReport, this.ttReqiresTripleTestForm, this.ttRequiresBinaryScanForm, this.tttextbox4, this.ttlabel17, this.TabTestBranchRelation, this.ttgrid1, this.ttlistboxcolumn2, this.ttlabel19, this.TabPageTestAlert, this.tttabcontrol1, this.TabPageAdult, this.AdultNegative, this.AdultPositive, this.labelAdultAlert, this.AdultAlert, this.TabPageNewBorn, this.NewBornPositive, this.NewBornNegative, this.labelNewBornAlert, this.NewBornAlert, this.Code, this.tttextbox1, this.tttextbox3, this.tttextbox5, this.ttlabel13, this.ttlabel14, this.ttlabel15, this.ttlabel16, this.ttlabel18, this.ttcheckbox2];

}


}
