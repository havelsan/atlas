//$F14A2D14
import { Component, OnInit, NgZone  } from '@angular/core';
import { NuclearMedicinePreparationFormViewModel } from './NuclearMedicinePreparationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedRadPharmMatGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTreatmentMat } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';

@Component({
    selector: 'NuclearMedicinePreparationForm',
    templateUrl: './NuclearMedicinePreparationForm.html',
    providers: [MessageService]
})
export class NuclearMedicinePreparationForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    //cmdPrintBarcode: TTVisual.ITTButton;
    DistributionType: TTVisual.ITTTextBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridNuclearMedicineMaterial: TTVisual.ITTGrid;
    GridRadPharmMaterials: TTVisual.ITTGrid;
    IsEmergency: TTVisual.ITTCheckBox;
    IsInjection: TTVisual.ITTCheckBoxColumn;
    labelPreInformation: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    MaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    Note: TTVisual.ITTTextBoxColumn;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PATIENTWEIGHT: TTVisual.ITTTextBox;
    PatientPhone: TTVisual.ITTTextBox;
    PharmMaterial: TTVisual.ITTListBoxColumn;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    RADIOPHARMACYDESC: TTVisual.ITTTextBox;
    RadPharmMatTab: TTVisual.ITTTabPage;
    ReasonForAdmission1: TTVisual.ITTGroupBox;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    TABNuclearMedicine: TTVisual.ITTTabControl;
    TabPageMaterial: TTVisual.ITTTabPage;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepickercolumn2: TTVisual.ITTDateTimePickerColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox3: TTVisual.ITTObjectListBox;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextboxcolumn3: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn4: TTVisual.ITTTextBoxColumn;
    Units: TTVisual.ITTListBoxColumn;

    public TreatmentMaterialTypeName1: String;
    public TreatmentMaterialTypeName2: String;

    public GridEpisodeDiagnosisColumns = [];
    public GridNuclearMedicineMaterialColumns = [];
    public GridRadPharmMaterialsColumns = [];
    public nuclearMedicinePreparationFormViewModel: NuclearMedicinePreparationFormViewModel = new NuclearMedicinePreparationFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicinePreparationForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicinePreparationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService,protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicinePreparationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    //private async cmdPrintBarcode_Click(): Promise<void> {
    //    (await NuclearMedicineService.PrintNuclearBarcode(this._NuclearMedicine));
    //}

    public async cmdBarcode_Click(): Promise<void> {

    }


    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.DropStateButton(NuclearMedicine.NuclearMedicineStates.AdmissionAppointment);
        this.AddHelpMenu();
        //if (this._NuclearMedicine.NuclearMedicineTests.length > 0) {
        //    if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject !== null) {
        //        this.nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
        //    }
        //}
        //this.SetTreatmentMaterialListFilter(<TTObjectDef>TTObjectDefManager.Instance.ObjectDefs[typeof NucMedTreatmentMat], <TTVisual.ITTGridColumn>this.GridNuclearMedicineMaterial.Columns['Material']);
        //this.SetTreatmentMaterialListFilter(<TTObjectDef>TTObjectDefManager.Instance.ObjectDefs[typeof NucMedRadPharmMatGrid], <TTVisual.ITTGridColumn>this.GridRadPharmMaterials.Columns['PharmMaterial']);
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
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicinePreparationFormViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
        await this.load(NuclearMedicinePreparationFormViewModel);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicinePreparationFormViewModel = new NuclearMedicinePreparationFormViewModel();
        this._ViewModel = this.nuclearMedicinePreparationFormViewModel;
        this.nuclearMedicinePreparationFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicinePreparationFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
        this.nuclearMedicinePreparationFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicinePreparationFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nuclearMedicinePreparationFormViewModel._NuclearMedicine.NucMedTreatmentMats = new Array<NucMedTreatmentMat>();
        this.nuclearMedicinePreparationFormViewModel._NuclearMedicine.RadPharmMaterials = new Array<NucMedRadPharmMatGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicinePreparationFormViewModel = this._ViewModel as NuclearMedicinePreparationFormViewModel;
        that._TTObject = this.nuclearMedicinePreparationFormViewModel._NuclearMedicine;
        if (this.nuclearMedicinePreparationFormViewModel == null)
            this.nuclearMedicinePreparationFormViewModel = new NuclearMedicinePreparationFormViewModel();
        if (this.nuclearMedicinePreparationFormViewModel._NuclearMedicine == null)
            this.nuclearMedicinePreparationFormViewModel._NuclearMedicine = new NuclearMedicine();
        let requestDoctorObjectID = that.nuclearMedicinePreparationFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicinePreparationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicinePreparationFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.nuclearMedicinePreparationFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicinePreparationFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicinePreparationFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicinePreparationFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicinePreparationFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicinePreparationFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicinePreparationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        that.nuclearMedicinePreparationFormViewModel._NuclearMedicine.NucMedTreatmentMats = that.nuclearMedicinePreparationFormViewModel.GridNuclearMedicineMaterialGridList;
        for (let detailItem of that.nuclearMedicinePreparationFormViewModel.GridNuclearMedicineMaterialGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicinePreparationFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.nuclearMedicinePreparationFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.nuclearMedicinePreparationFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.nuclearMedicinePreparationFormViewModel._NuclearMedicine.RadPharmMaterials = that.nuclearMedicinePreparationFormViewModel.GridRadPharmMaterialsGridList;
        for (let detailItem of that.nuclearMedicinePreparationFormViewModel.GridRadPharmMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicinePreparationFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.nuclearMedicinePreparationFormViewModel.RadioPharmaceuticalUnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    detailItem.Unit = unit;
                }
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicinePreparationFormViewModel);
  

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

    public onIsEmergencyChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.IsEmergency != event) {
                this._NuclearMedicine.IsEmergency = event;
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

    public onPatientPhoneChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientPhoneNumber != event) {
                this._NuclearMedicine.PatientPhoneNumber = event;
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
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PatientAge");
        redirectProperty(this.PATIENTWEIGHT, "Text", this.__ttObject, "PatientWeight");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TestSequenceNo");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.PatientPhone, "Text", this.__ttObject, "PatientPhoneNumber");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.RADIOPHARMACYDESC, "Text", this.__ttObject, "RadioPharmacyDescription");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "PharmaceuticalPrepDate");
    }

    public initFormControls(): void {
        this.ReasonForAdmission1 = new TTVisual.TTGroupBox();
        this.ReasonForAdmission1.BackColor = "#FFFFFF";
        this.ReasonForAdmission1.Name = "ReasonForAdmission1";
        this.ReasonForAdmission1.TabIndex = 0;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Test Sıra No";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 15;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "Farmasötik Hazırlama Tarihi";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 2;

        //this.cmdPrintBarcode = new TTVisual.TTButton();
        //this.cmdPrintBarcode.Text = "Barkod Bas";
        //this.cmdPrintBarcode.Name = "cmdPrintBarcode";
        //this.cmdPrintBarcode.TabIndex = 16;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 7;

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 6;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.Required = true;
        this.ttdatetimepicker1.BackColor = "#FFE3C6";
        this.ttdatetimepicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 15;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Tetkik";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 17;

        this.ttobjectlistbox3 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox3.ReadOnly = true;
        this.ttobjectlistbox3.ListDefName = "ReasonForAdmissionListDefinition";
        this.ttobjectlistbox3.Name = "ttobjectlistbox3";
        this.ttobjectlistbox3.TabIndex = 3;

        this.RADIOPHARMACYDESC = new TTVisual.TTTextBox();
        this.RADIOPHARMACYDESC.Multiline = true;
        this.RADIOPHARMACYDESC.Name = "RADIOPHARMACYDESC";
        this.RADIOPHARMACYDESC.TabIndex = 14;
        this.RADIOPHARMACYDESC.Height = "150px";

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 8;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.BackColor = "#F0F0F0";
        this.tttextbox2.ReadOnly = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 1;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Enabled = false;
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 11;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Protokol No";
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 8;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 2;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 4;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "Hastanın Yaşı";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 15;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 12;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmişe Ekle";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisDefinitionList";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 250;

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
        this.EpisodeIsMainDiagnose.Width = 75;

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

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "İstek Yapan Tabip Telefon";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 12;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 9;

        this.PatientPhone = new TTVisual.TTTextBox();
        this.PatientPhone.Name = "PatientPhone";
        this.PatientPhone.TabIndex = 10;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Hastanın Telefonu";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 8;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Hastanın Kilosu";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 6;

        this.PATIENTWEIGHT = new TTVisual.TTTextBox();
        this.PATIENTWEIGHT.Name = "PATIENTWEIGHT";
        this.PATIENTWEIGHT.TabIndex = 5;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Kabul Sebebi";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 4;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Hasta Grubu";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 2;

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 13;
        this.PREDIAGNOSIS.Height = "150px";

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "İşlem Zamanı";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 16;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İstek Yapan Tabip";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 10;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "N.T. Tabip Notu";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 18;

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

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = "Ölçü Birimi";
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = "Miktar";
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = "Note";
        this.Note.DisplayIndex = 4;
        this.Note.HeaderText = "Notlar";
        this.Note.Name = "Note";
        this.Note.Width = 220;

        this.RadPharmMatTab = new TTVisual.TTTabPage();
        this.RadPharmMatTab.DisplayIndex = 1;
        this.RadPharmMatTab.TabIndex = 2;
        this.RadPharmMatTab.Text = "Radyofarmasötik Madde Sarf";
        this.RadPharmMatTab.Name = "RadPharmMatTab";

        this.GridRadPharmMaterials = new TTVisual.TTGrid();
        this.GridRadPharmMaterials.Name = "GridRadPharmMaterials";
        this.GridRadPharmMaterials.TabIndex = 1;

        this.ttdatetimepickercolumn2 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn2.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn2.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn2.DataMember = "ActionDate";
        this.ttdatetimepickercolumn2.DisplayIndex = 0;
        this.ttdatetimepickercolumn2.HeaderText = "Tarih/Saat";
        this.ttdatetimepickercolumn2.Name = "ttdatetimepickercolumn2";
        this.ttdatetimepickercolumn2.ReadOnly = true;
        this.ttdatetimepickercolumn2.Width = 140;

        this.PharmMaterial = new TTVisual.TTListBoxColumn();
        this.PharmMaterial.ListDefName = "NucMedPharmMatListDef";
        this.PharmMaterial.DataMember = "Material";
        this.PharmMaterial.DisplayIndex = 1;
        this.PharmMaterial.HeaderText = "Sarf Edilen Malzemeler";
        this.PharmMaterial.Name = "PharmMaterial";
        this.PharmMaterial.Width = 320;

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

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridNuclearMedicineMaterialColumns = [this.MaterialActionDate, this.Material, this.DistributionType, this.Amount, this.Note];
        this.GridRadPharmMaterialsColumns = [this.ttdatetimepickercolumn2, this.PharmMaterial, this.IsInjection, this.tttextboxcolumn3, this.tttextboxcolumn4, this.Units];
        this.ReasonForAdmission1.Controls = [this.ttlabel11, this.ttlabel9, this.tttextbox3, this.nucMedSelectedTesttxt, this.ttdatetimepicker1, this.ttlabel8, this.ttobjectlistbox3, this.RADIOPHARMACYDESC, this.REQUESTDOCTOR, this.tttextbox2, this.IsEmergency, this.ttlabel15, this.PATIENTGROUPENUM, this.tttextbox1, this.ttlabel10, this.GridEpisodeDiagnosis, this.ttlabel7, this.REQUESTDOCTORPHONE, this.PatientPhone, this.ttlabel6, this.ttlabel5, this.PATIENTWEIGHT, this.ttlabel4, this.ttlabel3, this.PREDIAGNOSIS, this.labelProcessTime, this.ActionDate, this.labelPreInformation, this.ttlabel2, this.ttlabel1];
        this.TABNuclearMedicine.Controls = [this.TabPageMaterial, this.RadPharmMatTab];
        this.TabPageMaterial.Controls = [this.GridNuclearMedicineMaterial];
        this.RadPharmMatTab.Controls = [this.GridRadPharmMaterials];
        this.Controls = [this.ReasonForAdmission1, this.ttlabel11, this.ttlabel9, this.tttextbox3, this.nucMedSelectedTesttxt, this.ttdatetimepicker1, this.ttlabel8, this.ttobjectlistbox3, this.RADIOPHARMACYDESC, this.REQUESTDOCTOR, this.tttextbox2, this.IsEmergency, this.ttlabel15, this.PATIENTGROUPENUM, this.tttextbox1, this.ttlabel10, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttlabel7, this.REQUESTDOCTORPHONE, this.PatientPhone, this.ttlabel6, this.ttlabel5, this.PATIENTWEIGHT, this.ttlabel4, this.ttlabel3, this.PREDIAGNOSIS, this.labelProcessTime, this.ActionDate, this.labelPreInformation, this.ttlabel2, this.ttlabel1, this.TABNuclearMedicine, this.TabPageMaterial, this.GridNuclearMedicineMaterial, this.MaterialActionDate, this.Material, this.DistributionType, this.Amount, this.Note, this.RadPharmMatTab, this.GridRadPharmMaterials, this.ttdatetimepickercolumn2, this.PharmMaterial, this.IsInjection, this.tttextboxcolumn3, this.tttextboxcolumn4, this.Units];

    }


}
