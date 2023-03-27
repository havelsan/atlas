//$EE35DF84
import { Component, OnInit, NgZone } from '@angular/core';
import { NuclearMedicineProcedureFormViewModel } from './NuclearMedicineProcedureFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedRadPharmMatGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTreatmentMat } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';


@Component({
    selector: 'NuclearMedicineProcedureForm',
    templateUrl: './NuclearMedicineProcedureForm.html',
    providers: [MessageService]
})
export class NuclearMedicineProcedureForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    AmountDirectPurchaseGrid: TTVisual.ITTTextBoxColumn;
    Barkod: TTVisual.ITTTextBoxColumn;
    DirectPurchaseGrids: TTVisual.ITTGrid;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridNuclearMedicineMaterial: TTVisual.ITTGrid;
    INJECTIONDATE: TTVisual.ITTDateTimePicker;
    IsEmergency: TTVisual.ITTCheckBox;
    IsInjection: TTVisual.ITTCheckBoxColumn;
    labelProcessTime: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    MaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    MaterialDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    Note: TTVisual.ITTTextBoxColumn;
    NUCMEDDOCTORNOTE: TTVisual.ITTTextBox;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PATIENTPHONENUMBER: TTVisual.ITTTextBox;
    PATIENTWEIGHT: TTVisual.ITTTextBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureDate: TTVisual.ITTDateTimePicker;
    RADIOPHARMACYDESC: TTVisual.ITTTextBox;
    RadPharmMatTab: TTVisual.ITTTabPage;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    TABNuclearMedicine: TTVisual.ITTTabControl;
    TabPageMaterial: TTVisual.ITTTabPage;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepickercolumn2: TTVisual.ITTDateTimePickerColumn;
    ttgrid2: TTVisual.ITTGrid;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlistboxcolumn2: TTVisual.ITTListBoxColumn;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextboxcolumn3: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn4: TTVisual.ITTTextBoxColumn;
    Units: TTVisual.ITTListBoxColumn;
    public DirectPurchaseGridsColumns = [];
    public TreatmentMaterialTypeName1: String;
    public TreatmentMaterialTypeName2: String;

    public GridEpisodeDiagnosisColumns = [];
    public GridNuclearMedicineMaterialColumns = [];
    public ttgrid2Columns = [];
    public nuclearMedicineProcedureFormViewModel: NuclearMedicineProcedureFormViewModel = new NuclearMedicineProcedureFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineProcedureForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineProcedureForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    /*
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
    } */
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.AddHelpMenu();
        //if (this._NuclearMedicine.NuclearMedicineTests.length > 0) {
        //    if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject !== null) {
        //        this.nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
        //    }
        //}
        //this.SetTreatmentMaterialListFilter(<TTObjectDef>TTObjectDefManager.Instance.ObjectDefs['NucMedTreatmentMat'], <TTVisual.ITTGridColumn>this.GridNuclearMedicineMaterial.Columns['Material']);
    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let radiologyHistory = new DynamicSidebarMenuItem();
        radiologyHistory.key = 'radiologyHistory';
        radiologyHistory.icon = 'glyphicon glyphicon-cd';
        radiologyHistory.label = 'Radyoloji Sonuçları';
        radiologyHistory.componentInstance = this.helpMenuService;
        radiologyHistory.clickFunction = this.helpMenuService.openRadiologyHistory;
        radiologyHistory.parameterFunctionInstance = this;
        radiologyHistory.getParamsFunction = this.getClickFunctionParams;
        radiologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', radiologyHistory);

        let pathologyHistory = new DynamicSidebarMenuItem();
        pathologyHistory.key = 'pathologyHistory';
        pathologyHistory.icon = 'fas fa-notes-medical';
        pathologyHistory.label = 'Patoloji Sonuçları';
        pathologyHistory.componentInstance = this.helpMenuService;
        pathologyHistory.clickFunction = this.helpMenuService.openPathologyHistory;
        pathologyHistory.parameterFunctionInstance = this;
        pathologyHistory.getParamsFunction = this.getClickFunctionParams;
        pathologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', pathologyHistory);

        let testHistory = new DynamicSidebarMenuItem();
        testHistory.key = 'testHistory';
        testHistory.icon = 'fa fa-flask';
        testHistory.label = 'Laboratuvar Sonuçları';
        testHistory.componentInstance = this.helpMenuService;
        testHistory.clickFunction = this.helpMenuService.openTestHistory;
        testHistory.parameterFunctionInstance = this;
        testHistory.getParamsFunction = this.getClickFunctionParams;
        testHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', testHistory);

    }

    public RemoveMenuFromHelpMenu(): void {

        this.sideBarMenuService.removeMenu('radiologyHistory');
        this.sideBarMenuService.removeMenu('pathologyHistory');
        this.sideBarMenuService.removeMenu('testHistory');
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicineProcedureFormViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
        await this.load(NuclearMedicineProcedureFormViewModel);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineProcedureFormViewModel = new NuclearMedicineProcedureFormViewModel();
        this._ViewModel = this.nuclearMedicineProcedureFormViewModel;
        this.nuclearMedicineProcedureFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineProcedureFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineProcedureFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nuclearMedicineProcedureFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
        this.nuclearMedicineProcedureFormViewModel._NuclearMedicine.NucMedTreatmentMats = new Array<NucMedTreatmentMat>();
        this.nuclearMedicineProcedureFormViewModel._NuclearMedicine.RadPharmMaterials = new Array<NucMedRadPharmMatGrid>();
        this.nuclearMedicineProcedureFormViewModel._NuclearMedicine.DirectPurchaseGrids = new Array<DirectPurchaseGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineProcedureFormViewModel = this._ViewModel as NuclearMedicineProcedureFormViewModel;
        that._TTObject = this.nuclearMedicineProcedureFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineProcedureFormViewModel == null)
            this.nuclearMedicineProcedureFormViewModel = new NuclearMedicineProcedureFormViewModel();
        if (this.nuclearMedicineProcedureFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineProcedureFormViewModel._NuclearMedicine = new NuclearMedicine();
        let episodeObjectID = that.nuclearMedicineProcedureFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineProcedureFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineProcedureFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineProcedureFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineProcedureFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineProcedureFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let requestDoctorObjectID = that.nuclearMedicineProcedureFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineProcedureFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }
        that.nuclearMedicineProcedureFormViewModel._NuclearMedicine.NucMedTreatmentMats = that.nuclearMedicineProcedureFormViewModel.GridNuclearMedicineMaterialGridList;
        for (let detailItem of that.nuclearMedicineProcedureFormViewModel.GridNuclearMedicineMaterialGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }
        that.nuclearMedicineProcedureFormViewModel._NuclearMedicine.RadPharmMaterials = that.nuclearMedicineProcedureFormViewModel.ttgrid2GridList;
        for (let detailItem of that.nuclearMedicineProcedureFormViewModel.ttgrid2GridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.nuclearMedicineProcedureFormViewModel.RadioPharmaceuticalUnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    detailItem.Unit = unit;
                }
            }
        }

        that.nuclearMedicineProcedureFormViewModel._NuclearMedicine.DirectPurchaseGrids = that.nuclearMedicineProcedureFormViewModel.DirectPurchaseGridsGridList;
        for (let detailItem of that.nuclearMedicineProcedureFormViewModel.DirectPurchaseGridsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }



    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineProcedureFormViewModel);
  

        that.TreatmentMaterialTypeName1 = 'NUCMEDTREATMENTMAT';
        that.TreatmentMaterialTypeName2 = 'NUCMEDRADPHARMMATGRID';
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ActionDate != event) {
                this._NuclearMedicine.ActionDate = event;
            }
        }
    }

    public onINJECTIONDATEChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.InjectionDate != event) {
                this._NuclearMedicine.InjectionDate = event;
            }
        }
    }

    public onIsEmergencyChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.IsEmergency != event) {
                this._NuclearMedicine.IsEmergency = event;
            }
        }
    }

    public onNUCMEDDOCTORNOTEChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.NucMedDoctorNote != event) {
                this._NuclearMedicine.NucMedDoctorNote = event;
            }
        }
    }

    public onPATIENTPHONENUMBERChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientPhoneNumber != event) {
                this._NuclearMedicine.PatientPhoneNumber = event;
            }
        }
    }

    public onPATIENTWEIGHTChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientWeight != event) {
                this._NuclearMedicine.PatientWeight = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PreDiagnosis != event) {
                this._NuclearMedicine.PreDiagnosis = event;
            }
        }
    }

    public onProcedureDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProcedureDate != event) {
                this._NuclearMedicine.ProcedureDate = event;
            }
        }
    }

    public onRADIOPHARMACYDESCChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RadioPharmacyDescription != event) {
                this._NuclearMedicine.RadioPharmacyDescription = event;
            }
        }
    }

    public onREQUESTDOCTORChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RequestDoctor != event) {
                this._NuclearMedicine.RequestDoctor = event;
            }
        }
    }

    public onREQUESTDOCTORPHONEChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null &&
                this._NuclearMedicine.RequestDoctor != null && this._NuclearMedicine.RequestDoctor.PhoneNumber != event) {
                this._NuclearMedicine.RequestDoctor.PhoneNumber = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PharmaceuticalPrepDate != event) {
                this._NuclearMedicine.PharmaceuticalPrepDate = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientAge != event) {
                this._NuclearMedicine.PatientAge = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProtocolNo != event) {
                this._NuclearMedicine.ProtocolNo = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.TestSequenceNo != event) {
                this._NuclearMedicine.TestSequenceNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.PATIENTPHONENUMBER, "Text", this.__ttObject, "PatientPhoneNumber");
        redirectProperty(this.INJECTIONDATE, "Value", this.__ttObject, "InjectionDate");
        redirectProperty(this.ProcedureDate, "Value", this.__ttObject, "ProcedureDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PatientAge");
        redirectProperty(this.PATIENTWEIGHT, "Text", this.__ttObject, "PatientWeight");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TestSequenceNo");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.RADIOPHARMACYDESC, "Text", this.__ttObject, "RadioPharmacyDescription");
        redirectProperty(this.NUCMEDDOCTORNOTE, "Text", this.__ttObject, "NucMedDoctorNote");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "PharmaceuticalPrepDate");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#DCDCDC";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = "Test Sıra No";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 15;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker1.Enabled = false;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 15;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 9;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "Farmasötik Hazırla Tarihi";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 2;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tetkik";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 14;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.tttabpage1.Name = "tttabpage1";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 50;
        this.PREDIAGNOSIS.Height = "150px";

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = "N.T. Tabip Notu";
        this.tttabpage2.Name = "tttabpage2";

        this.RADIOPHARMACYDESC = new TTVisual.TTTextBox();
        this.RADIOPHARMACYDESC.Multiline = true;
        this.RADIOPHARMACYDESC.BackColor = "#F0F0F0";
        this.RADIOPHARMACYDESC.ReadOnly = true;
        this.RADIOPHARMACYDESC.Name = "RADIOPHARMACYDESC";
        this.RADIOPHARMACYDESC.TabIndex = 19;
        this.RADIOPHARMACYDESC.Height = "150px";

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.BackColor = "#FFFFFF";
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = "Teknisyen Notu";
        this.tttabpage3.Name = "tttabpage3";

        this.NUCMEDDOCTORNOTE = new TTVisual.TTTextBox();
        this.NUCMEDDOCTORNOTE.Multiline = true;
        this.NUCMEDDOCTORNOTE.Name = "NUCMEDDOCTORNOTE";
        this.NUCMEDDOCTORNOTE.TabIndex = 0;

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 10;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "AdmissionTypeListDef";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.BackColor = "#F0F0F0";
        this.tttextbox2.ReadOnly = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 3;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Protokol No";
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 8;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 7;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Hastanın Yaşı";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 15;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 13;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmiş";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 60;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisDefinitionList";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 330;

        this.EpisodeDiagnoseType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnoseType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnoseType.DataMember = "DiagnosisType";
        this.EpisodeDiagnoseType.DisplayIndex = 2;
        this.EpisodeDiagnoseType.HeaderText = "Tanı Tipi";
        this.EpisodeDiagnoseType.Name = "EpisodeDiagnoseType";
        this.EpisodeDiagnoseType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = "Ana Tanı";
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 60;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = "Tanı Koyan";
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = "Tanı Giriş Tarihi";
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = "Giriş Yapılan İşlem";
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İşlem Zamanı";
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 0;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Enabled = false;
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 14;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "İstek Yapan Tabip Telefon";
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 12;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 12;

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 11;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "İstek Yapan Tabip";
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 10;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Hastanın Telefonu";
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 8;

        this.PATIENTPHONENUMBER = new TTVisual.TTTextBox();
        this.PATIENTPHONENUMBER.Name = "PATIENTPHONENUMBER";
        this.PATIENTPHONENUMBER.TabIndex = 4;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Enjeksiyon Zamanı";
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 63;

        this.INJECTIONDATE = new TTVisual.TTDateTimePicker();
        this.INJECTIONDATE.CustomFormat = "dd/MM/yyyy HH:mm";
        this.INJECTIONDATE.Format = DateTimePickerFormat.Custom;
        this.INJECTIONDATE.Name = "INJECTIONDATE";
        this.INJECTIONDATE.TabIndex = 5;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Hastanın Kilosu";
        this.ttlabel5.BackColor = "#DCDCDC";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 61;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Kabul Sebebi";
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 60;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Hasta Grubu";
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 59;

        this.PATIENTWEIGHT = new TTVisual.TTTextBox();
        this.PATIENTWEIGHT.Name = "PATIENTWEIGHT";
        this.PATIENTWEIGHT.TabIndex = 8;

        this.ProcedureDate = new TTVisual.TTDateTimePicker();
        this.ProcedureDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ProcedureDate.Format = DateTimePickerFormat.Custom;
        this.ProcedureDate.Name = "ProcedureDate";
        this.ProcedureDate.TabIndex = 6;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "Çekim Tarihi ve Saati";
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 48;

        this.TABNuclearMedicine = new TTVisual.TTTabControl();
        this.TABNuclearMedicine.Name = "TABNuclearMedicine";
        this.TABNuclearMedicine.TabIndex = 1;

        this.TabPageMaterial = new TTVisual.TTTabPage();
        this.TabPageMaterial.DisplayIndex = 0;
        this.TabPageMaterial.BackColor = "#FFFFFF";
        this.TabPageMaterial.TabIndex = 1;
        this.TabPageMaterial.Text = "Nükleer Tıp Sarf";
        this.TabPageMaterial.Name = "TabPageMaterial";

        this.GridNuclearMedicineMaterial = new TTVisual.TTGrid();
        this.GridNuclearMedicineMaterial.Name = "GridNuclearMedicineMaterial";
        this.GridNuclearMedicineMaterial.TabIndex = 1;

        this.MaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.MaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.MaterialActionDate.DataMember = "ActionDate";
        this.MaterialActionDate.DisplayIndex = 0;
        this.MaterialActionDate.HeaderText = "Tarih/Saat";
        this.MaterialActionDate.Name = "MaterialActionDate";
        this.MaterialActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = "Sarf Edilen Malzemeler";
        this.Material.Name = "Material";
        this.Material.Width = 320;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = "Miktar";
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = "Note";
        this.Note.DisplayIndex = 3;
        this.Note.HeaderText = "Notlar";
        this.Note.Name = "Note";
        this.Note.Width = 220;

        this.Barkod = new TTVisual.TTTextBoxColumn();
        this.Barkod.DataMember = "Barcode";
        this.Barkod.DisplayIndex = 4;
        this.Barkod.HeaderText = "Barkod \ UBB";
        this.Barkod.Name = "Barkod";
        this.Barkod.Width = 100;

        this.RadPharmMatTab = new TTVisual.TTTabPage();
        this.RadPharmMatTab.DisplayIndex = 1;
        this.RadPharmMatTab.TabIndex = 2;
        this.RadPharmMatTab.Text = "Radyofarmasötik Madde Sarf";
        this.RadPharmMatTab.Name = "RadPharmMatTab";

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.Name = "ttgrid2";
        this.ttgrid2.TabIndex = 1;

        this.ttdatetimepickercolumn2 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn2.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn2.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn2.DataMember = "ActionDate";
        this.ttdatetimepickercolumn2.DisplayIndex = 0;
        this.ttdatetimepickercolumn2.HeaderText = "Tarih/Saat";
        this.ttdatetimepickercolumn2.Name = "ttdatetimepickercolumn2";
        this.ttdatetimepickercolumn2.ReadOnly = true;
        this.ttdatetimepickercolumn2.Width = 140;

        this.ttlistboxcolumn2 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn2.ListDefName = "NucMedPharmMatListDef";
        this.ttlistboxcolumn2.DataMember = "Material";
        this.ttlistboxcolumn2.DisplayIndex = 1;
        this.ttlistboxcolumn2.HeaderText = "Sarf Edilen Malzemeler";
        this.ttlistboxcolumn2.Name = "ttlistboxcolumn2";
        this.ttlistboxcolumn2.ReadOnly = true;
        this.ttlistboxcolumn2.Width = 320;

        this.IsInjection = new TTVisual.TTCheckBoxColumn();
        this.IsInjection.DisplayIndex = 2;
        this.IsInjection.HeaderText = "Enjeksiyon";
        this.IsInjection.Name = "IsInjection";
        this.IsInjection.Width = 60;

        this.tttextboxcolumn3 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn3.DataMember = "Note";
        this.tttextboxcolumn3.DisplayIndex = 3;
        this.tttextboxcolumn3.HeaderText = "Erişkin Dozu";
        this.tttextboxcolumn3.Name = "tttextboxcolumn3";
        this.tttextboxcolumn3.ReadOnly = true;
        this.tttextboxcolumn3.Width = 100;

        this.tttextboxcolumn4 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn4.DataMember = "Amount";
        this.tttextboxcolumn4.DisplayIndex = 4;
        this.tttextboxcolumn4.HeaderText = "Verilen Doz";
        this.tttextboxcolumn4.Name = "tttextboxcolumn4";
        this.tttextboxcolumn4.Width = 100;

        this.Units = new TTVisual.TTListBoxColumn();
        this.Units.ListDefName = "RadioPharmaceuticalUnitListDefinition";
        this.Units.DataMember = "Unit";
        this.Units.DisplayIndex = 5;
        this.Units.HeaderText = "Birim";
        this.Units.Name = "Units";
        this.Units.Width = 80;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 2;
        this.tttabpage4.TabIndex = 3;
        this.tttabpage4.Text = "Doğrudan Tedarik Edilen Malzemeler";
        this.tttabpage4.Name = "tttabpage4";

        this.DirectPurchaseGrids = new TTVisual.TTGrid();
        this.DirectPurchaseGrids.Name = "DirectPurchaseGrids";
        this.DirectPurchaseGrids.TabIndex = 0;
        this.DirectPurchaseGrids.ShowFilterCombo = true;
        this.DirectPurchaseGrids.FilterColumnName = "MaterialDirectPurchaseGrid";
        this.DirectPurchaseGrids.FilterLabel = i18n("M18545", "Malzeme");
        this.DirectPurchaseGrids.Filter = { ListDefName: "MaterialListDefinition" };
        this.DirectPurchaseGrids.AllowUserToAddRows = true;
        this.DirectPurchaseGrids.AllowUserToDeleteRows = true;
        this.DirectPurchaseGrids.DeleteButtonWidth = "5%";
        this.DirectPurchaseGrids.ShowTotalNumberOfRows = false;
        this.DirectPurchaseGrids.IsFilterLabelSingleLine = false;
        this.DirectPurchaseGrids.Height = "300";

        this.MaterialDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.MaterialDirectPurchaseGrid.ListDefName = "MaterialListDefinition";
        this.MaterialDirectPurchaseGrid.DataMember = "Material";
        this.MaterialDirectPurchaseGrid.DisplayIndex = 0;
        this.MaterialDirectPurchaseGrid.HeaderText = "Malzeme";
        this.MaterialDirectPurchaseGrid.Name = "MaterialDirectPurchaseGrid";
        this.MaterialDirectPurchaseGrid.Width = 300;
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogWidth = '75%';
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogHeight = '50%';

        this.AmountDirectPurchaseGrid = new TTVisual.TTTextBoxColumn();
        this.AmountDirectPurchaseGrid.DataMember = "Amount";
        this.AmountDirectPurchaseGrid.DisplayIndex = 1;
        this.AmountDirectPurchaseGrid.HeaderText = "Miktar";
        this.AmountDirectPurchaseGrid.Name = "AmountDirectPurchaseGrid";
        this.AmountDirectPurchaseGrid.Width = 80;
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridNuclearMedicineMaterialColumns = [this.MaterialActionDate, this.Material, this.Amount, this.Note, this.Barkod];
        this.ttgrid2Columns = [this.ttdatetimepickercolumn2, this.ttlistboxcolumn2, this.IsInjection, this.tttextboxcolumn3, this.tttextboxcolumn4, this.Units];
        this.DirectPurchaseGridsColumns = [this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid];
        this.ttgroupbox1.Controls = [this.ttlabel12, this.ttdatetimepicker1, this.tttextbox3, this.ttlabel10, this.ttlabel1, this.tttabcontrol1, this.nucMedSelectedTesttxt, this.ReasonForAdmission, this.PATIENTGROUPENUM, this.tttextbox2, this.ttlabel15, this.tttextbox1, this.ttlabel11, this.GridEpisodeDiagnosis, this.ttlabel2, this.IsEmergency, this.ttlabel9, this.REQUESTDOCTORPHONE, this.REQUESTDOCTOR, this.ttlabel8, this.ttlabel7, this.PATIENTPHONENUMBER, this.ActionDate, this.ttlabel6, this.INJECTIONDATE, this.ttlabel5, this.ttlabel4, this.ttlabel3, this.PATIENTWEIGHT, this.ProcedureDate, this.labelProcessTime];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3];
        this.tttabpage1.Controls = [this.PREDIAGNOSIS];
        this.tttabpage2.Controls = [this.RADIOPHARMACYDESC];
        this.tttabpage3.Controls = [this.NUCMEDDOCTORNOTE];
        this.TABNuclearMedicine.Controls = [this.TabPageMaterial, this.RadPharmMatTab, this.tttabpage4];
        this.TabPageMaterial.Controls = [this.GridNuclearMedicineMaterial];
        this.RadPharmMatTab.Controls = [this.ttgrid2];
        this.tttabpage4.Controls = [this.DirectPurchaseGrids];
        this.Controls = [this.ttgroupbox1, this.ttlabel12, this.ttdatetimepicker1, this.tttextbox3, this.ttlabel10, this.ttlabel1, this.tttabcontrol1, this.tttabpage1, this.PREDIAGNOSIS, this.tttabpage2, this.RADIOPHARMACYDESC, this.tttabpage3, this.NUCMEDDOCTORNOTE, this.nucMedSelectedTesttxt, this.ReasonForAdmission, this.PATIENTGROUPENUM, this.tttextbox2, this.ttlabel15, this.tttextbox1, this.ttlabel11, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttlabel2, this.IsEmergency, this.ttlabel9, this.REQUESTDOCTORPHONE, this.REQUESTDOCTOR, this.ttlabel8, this.ttlabel7, this.PATIENTPHONENUMBER, this.ActionDate, this.ttlabel6, this.INJECTIONDATE, this.ttlabel5, this.ttlabel4, this.ttlabel3, this.PATIENTWEIGHT, this.ProcedureDate, this.labelProcessTime, this.TABNuclearMedicine, this.TabPageMaterial, this.GridNuclearMedicineMaterial, this.MaterialActionDate, this.Material, this.Amount, this.Note, this.Barkod, this.RadPharmMatTab, this.ttgrid2, this.ttdatetimepickercolumn2, this.ttlistboxcolumn2, this.IsInjection, this.tttextboxcolumn3, this.tttextboxcolumn4, this.Units];

    }


}
