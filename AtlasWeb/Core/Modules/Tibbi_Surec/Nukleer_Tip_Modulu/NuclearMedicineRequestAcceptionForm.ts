//$F84D307F
import { Component, OnInit, NgZone  } from '@angular/core';
import { NuclearMedicineRequestAcceptionFormViewModel } from './NuclearMedicineRequestAcceptionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicineTest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';

@Component({
    selector: 'NuclearMedicineRequestAcceptionForm',
    templateUrl: './NuclearMedicineRequestAcceptionForm.html',
    providers: [MessageService]
})
export class NuclearMedicineRequestAcceptionForm extends EpisodeActionForm implements OnInit {
    AccessionNoNuclearMedicineTest: TTVisual.ITTTextBoxColumn;
    AccountOperationDoneNuclearMedicineTest: TTVisual.ITTCheckBoxColumn;
    AccTrxsMultipliedByAmountNuclearMedicineTest: TTVisual.ITTCheckBoxColumn;
    ActionDate: TTVisual.ITTDateTimePicker;
    ActionDateNuclearMedicineTest: TTVisual.ITTDateTimePickerColumn;
    ActiveNuclearMedicineTest: TTVisual.ITTCheckBoxColumn;
    AmountNuclearMedicineTest: TTVisual.ITTTextBoxColumn;
    CreationDateNuclearMedicineTest: TTVisual.ITTDateTimePickerColumn;
    DiscountPercentNuclearMedicineTest: TTVisual.ITTTextBoxColumn;
    EligibleNuclearMedicineTest: TTVisual.ITTCheckBoxColumn;
    EmergencyNuclearMedicineTest: TTVisual.ITTCheckBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeActionNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    EquipmentNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    ExtraDescriptionNuclearMedicineTest: TTVisual.ITTTextBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    IDNuclearMedicineTest: TTVisual.ITTTextBoxColumn;
    IsEmergency: TTVisual.ITTCheckBox;
    IsOldActionNuclearMedicineTest: TTVisual.ITTCheckBoxColumn;
    labelPreInformation: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    MasterPackgSubActionProcedureNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    MasterSubActionProcedureNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    MedulaHastaKabulNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    MedulaReportNoNuclearMedicineTest: TTVisual.ITTTextBoxColumn;
    NuclearMedicineTests: TTVisual.ITTGrid;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    OlapDateNuclearMedicineTest: TTVisual.ITTDateTimePickerColumn;
    OlapLastUpdateNuclearMedicineTest: TTVisual.ITTDateTimePickerColumn;
    PackageDefinitionNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PatientPayNuclearMedicineTest: TTVisual.ITTCheckBoxColumn;
    PerformedDateNuclearMedicineTest: TTVisual.ITTDateTimePickerColumn;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    PricingDateNuclearMedicineTest: TTVisual.ITTDateTimePickerColumn;
    ProcedureByUserNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureDoctorNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    ProcedureObjectNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    ProcedureSpecialityNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    ReasonOfCancelNuclearMedicineTest: TTVisual.ITTTextBoxColumn;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    RequestedByUserNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    SubEpisodeNuclearMedicineTest: TTVisual.ITTListBoxColumn;
    SUTRuleStatusNuclearMedicineTest: TTVisual.ITTEnumComboBoxColumn;
    //ttbutton1: TTVisual.ITTButton;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    WorkListDateNuclearMedicineTest: TTVisual.ITTDateTimePickerColumn;
    public GridEpisodeDiagnosisColumns = [];
    public NuclearMedicineTestsColumns = [];
    public nuclearMedicineRequestAcceptionFormViewModel: NuclearMedicineRequestAcceptionFormViewModel = new NuclearMedicineRequestAcceptionFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineRequestAcceptionForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineRequestAcceptionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineRequestAcceptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    //private async ttbutton1_Click(): Promise<void> {
    //    (await NuclearMedicineService.PrintNuclearBarcode(this._NuclearMedicine));
    //}
    public async cmdBarcode_Click(): Promise<void> {

    }


    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.PostScript(transDef);
    }


    protected async PreScript(): Promise<void> {

        super.PreScript();
        this.AddHelpMenu();
        //this.SetProcedureDoctorAsCurrentResource();
        //let hasInitialObjectIDForAdmissionAppointment: boolean = false;
        //if (this._NuclearMedicine.SubEpisode.PatientAdmission !== null) {
        //    if (this._NuclearMedicine.SubEpisode.PatientAdmission.AdmissionAppointment !== null) {
        //        if (this._NuclearMedicine.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.length > 0) {
        //            if (this._NuclearMedicine.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments[0].InitialObjectID !== null)
        //                hasInitialObjectIDForAdmissionAppointment = true;
        //        }
        //    }
        //}
        //if (this._NuclearMedicine.NuclearMedicineTests.length > 0) {
        //    if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject !== null) {
        //        this.nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
        //    }
        //}
        //if (<boolean>this._NuclearMedicine.IsEmergency || hasInitialObjectIDForAdmissionAppointment) {
        //    this.DropStateButton(NuclearMedicine.NuclearMedicineStates.AppointmentInfo);
        //}
        //else {
        //    this.DropStateButton(NuclearMedicine.NuclearMedicineStates.Preparation);
        //}
        //if (this._EpisodeAction.MyNotApprovedAppointments().length > 0)
        //    this.DropStateButton(NuclearMedicine.NuclearMedicineStates.AppointmentInfo);
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
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineRequestAcceptionFormViewModel = new NuclearMedicineRequestAcceptionFormViewModel();
        this._ViewModel = this.nuclearMedicineRequestAcceptionFormViewModel;
        this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.NuclearMedicineTests = new Array<NuclearMedicineTest>();
        this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.ProcedureDoctor = new ResUser();
        this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
        this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineRequestAcceptionFormViewModel = this._ViewModel as NuclearMedicineRequestAcceptionFormViewModel;
        that._TTObject = this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineRequestAcceptionFormViewModel == null)
            this.nuclearMedicineRequestAcceptionFormViewModel = new NuclearMedicineRequestAcceptionFormViewModel();
        if (this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine = new NuclearMedicine();
        that.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.NuclearMedicineTests = that.nuclearMedicineRequestAcceptionFormViewModel.NuclearMedicineTestsGridList;
        for (let detailItem of that.nuclearMedicineRequestAcceptionFormViewModel.NuclearMedicineTestsGridList) {
            let equipmentObjectID = detailItem["Equipment"];
            if (equipmentObjectID != null && (typeof equipmentObjectID === "string")) {
                let equipment = that.nuclearMedicineRequestAcceptionFormViewModel.ResNuclearMedicineEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
                if (equipment) {
                    detailItem.Equipment = equipment;
                }
            }
            let episodeObjectID = detailItem["Episode"];
            if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
                let episode = that.nuclearMedicineRequestAcceptionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                if (episode) {
                    detailItem.Episode = episode;
                }
            }
            let procedureSpecialityObjectID = detailItem["ProcedureSpeciality"];
            if (procedureSpecialityObjectID != null && (typeof procedureSpecialityObjectID === "string")) {
                let procedureSpeciality = that.nuclearMedicineRequestAcceptionFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === procedureSpecialityObjectID.toString());
                if (procedureSpeciality) {
                    detailItem.ProcedureSpeciality = procedureSpeciality;
                }
            }
            let episodeActionObjectID = detailItem["EpisodeAction"];
            if (episodeActionObjectID != null && (typeof episodeActionObjectID === "string")) {
                let episodeAction = that.nuclearMedicineRequestAcceptionFormViewModel.EpisodeActions.find(o => o.ObjectID.toString() === episodeActionObjectID.toString());
                if (episodeAction) {
                    detailItem.EpisodeAction = episodeAction;
                }
            }
            let packageDefinitionObjectID = detailItem["PackageDefinition"];
            if (packageDefinitionObjectID != null && (typeof packageDefinitionObjectID === "string")) {
                let packageDefinition = that.nuclearMedicineRequestAcceptionFormViewModel.PackageDefinitions.find(o => o.ObjectID.toString() === packageDefinitionObjectID.toString());
                if (packageDefinition) {
                    detailItem.PackageDefinition = packageDefinition;
                }
            }
            let masterSubActionProcedureObjectID = detailItem["MasterSubActionProcedure"];
            if (masterSubActionProcedureObjectID != null && (typeof masterSubActionProcedureObjectID === "string")) {
                let masterSubActionProcedure = that.nuclearMedicineRequestAcceptionFormViewModel.SubActionProcedures.find(o => o.ObjectID.toString() === masterSubActionProcedureObjectID.toString());
                if (masterSubActionProcedure) {
                    detailItem.MasterSubActionProcedure = masterSubActionProcedure;
                }
            }
            let masterPackgSubActionProcedureObjectID = detailItem["MasterPackgSubActionProcedure"];
            if (masterPackgSubActionProcedureObjectID != null && (typeof masterPackgSubActionProcedureObjectID === "string")) {
                let masterPackgSubActionProcedure = that.nuclearMedicineRequestAcceptionFormViewModel.SubActionProcedures.find(o => o.ObjectID.toString() === masterPackgSubActionProcedureObjectID.toString());
                if (masterPackgSubActionProcedure) {
                    detailItem.MasterPackgSubActionProcedure = masterPackgSubActionProcedure;
                }
            }
            let medulaHastaKabulObjectID = detailItem["MedulaHastaKabul"];
            if (medulaHastaKabulObjectID != null && (typeof medulaHastaKabulObjectID === "string")) {
                let medulaHastaKabul = that.nuclearMedicineRequestAcceptionFormViewModel.PatientMedulaHastaKabuls.find(o => o.ObjectID.toString() === medulaHastaKabulObjectID.toString());
                if (medulaHastaKabul) {
                    detailItem.MedulaHastaKabul = medulaHastaKabul;
                }
            }
            let subEpisodeObjectID = detailItem["SubEpisode"];
            if (subEpisodeObjectID != null && (typeof subEpisodeObjectID === "string")) {
                let subEpisode = that.nuclearMedicineRequestAcceptionFormViewModel.SubEpisodes.find(o => o.ObjectID.toString() === subEpisodeObjectID.toString());
                if (subEpisode) {
                    detailItem.SubEpisode = subEpisode;
                }
            }
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                let procedureObject = that.nuclearMedicineRequestAcceptionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                let procedureDoctor = that.nuclearMedicineRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
            let procedureByUserObjectID = detailItem["ProcedureByUser"];
            if (procedureByUserObjectID != null && (typeof procedureByUserObjectID === "string")) {
                let procedureByUser = that.nuclearMedicineRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureByUserObjectID.toString());
                if (procedureByUser) {
                    detailItem.ProcedureByUser = procedureByUser;
                }
            }
            let requestedByUserObjectID = detailItem["RequestedByUser"];
            if (requestedByUserObjectID != null && (typeof requestedByUserObjectID === "string")) {
                let requestedByUser = that.nuclearMedicineRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestedByUserObjectID.toString());
                if (requestedByUser) {
                    detailItem.RequestedByUser = requestedByUser;
                }
            }
        }
        let procedureDoctorObjectID = that.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.nuclearMedicineRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.ProcedureDoctor = procedureDoctor;
            }
        }
        let requestDoctorObjectID = that.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineRequestAcceptionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineRequestAcceptionFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineRequestAcceptionFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineRequestAcceptionFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineRequestAcceptionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineRequestAcceptionFormViewModel);
  
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

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PreDiagnosis != event) {
                this._NuclearMedicine.PreDiagnosis = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.Description != event) {
                this._NuclearMedicine.Description = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProcedureDoctor != event) {
                this._NuclearMedicine.ProcedureDoctor = event;
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
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PatientAge");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TestSequenceNo");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");

    }

    public initFormControls(): void {
        this.NuclearMedicineTests = new TTVisual.TTGrid();
        this.NuclearMedicineTests.Name = "NuclearMedicineTests";
        this.NuclearMedicineTests.TabIndex = 1;
        this.NuclearMedicineTests.Visible = false;

        this.EquipmentNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.EquipmentNuclearMedicineTest.DataMember = "Equipment";
        this.EquipmentNuclearMedicineTest.DisplayIndex = 0;
        this.EquipmentNuclearMedicineTest.HeaderText = "Cihaz";
        this.EquipmentNuclearMedicineTest.Name = "EquipmentNuclearMedicineTest";
        this.EquipmentNuclearMedicineTest.Width = 300;

        this.EpisodeNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.EpisodeNuclearMedicineTest.DataMember = "Episode";
        this.EpisodeNuclearMedicineTest.DisplayIndex = 1;
        this.EpisodeNuclearMedicineTest.HeaderText = "";
        this.EpisodeNuclearMedicineTest.Name = "EpisodeNuclearMedicineTest";
        this.EpisodeNuclearMedicineTest.Width = 300;

        this.ProcedureSpecialityNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.ProcedureSpecialityNuclearMedicineTest.DataMember = "ProcedureSpeciality";
        this.ProcedureSpecialityNuclearMedicineTest.DisplayIndex = 2;
        this.ProcedureSpecialityNuclearMedicineTest.HeaderText = "İşlemin Yapıldığı Uzmanlık Dalı";
        this.ProcedureSpecialityNuclearMedicineTest.Name = "ProcedureSpecialityNuclearMedicineTest";
        this.ProcedureSpecialityNuclearMedicineTest.Width = 300;

        this.EpisodeActionNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.EpisodeActionNuclearMedicineTest.DataMember = "EpisodeAction";
        this.EpisodeActionNuclearMedicineTest.DisplayIndex = 3;
        this.EpisodeActionNuclearMedicineTest.HeaderText = "";
        this.EpisodeActionNuclearMedicineTest.Name = "EpisodeActionNuclearMedicineTest";
        this.EpisodeActionNuclearMedicineTest.Width = 300;

        this.PackageDefinitionNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.PackageDefinitionNuclearMedicineTest.DataMember = "PackageDefinition";
        this.PackageDefinitionNuclearMedicineTest.DisplayIndex = 4;
        this.PackageDefinitionNuclearMedicineTest.HeaderText = "";
        this.PackageDefinitionNuclearMedicineTest.Name = "PackageDefinitionNuclearMedicineTest";
        this.PackageDefinitionNuclearMedicineTest.Width = 300;

        this.MasterSubActionProcedureNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.MasterSubActionProcedureNuclearMedicineTest.DataMember = "MasterSubActionProcedure";
        this.MasterSubActionProcedureNuclearMedicineTest.DisplayIndex = 5;
        this.MasterSubActionProcedureNuclearMedicineTest.HeaderText = "";
        this.MasterSubActionProcedureNuclearMedicineTest.Name = "MasterSubActionProcedureNuclearMedicineTest";
        this.MasterSubActionProcedureNuclearMedicineTest.Width = 300;

        this.MasterPackgSubActionProcedureNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.MasterPackgSubActionProcedureNuclearMedicineTest.DataMember = "MasterPackgSubActionProcedure";
        this.MasterPackgSubActionProcedureNuclearMedicineTest.DisplayIndex = 6;
        this.MasterPackgSubActionProcedureNuclearMedicineTest.HeaderText = "";
        this.MasterPackgSubActionProcedureNuclearMedicineTest.Name = "MasterPackgSubActionProcedureNuclearMedicineTest";
        this.MasterPackgSubActionProcedureNuclearMedicineTest.Width = 300;

        this.MedulaHastaKabulNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.MedulaHastaKabulNuclearMedicineTest.DataMember = "MedulaHastaKabul";
        this.MedulaHastaKabulNuclearMedicineTest.DisplayIndex = 7;
        this.MedulaHastaKabulNuclearMedicineTest.HeaderText = "Medula Hasta Kabul";
        this.MedulaHastaKabulNuclearMedicineTest.Name = "MedulaHastaKabulNuclearMedicineTest";
        this.MedulaHastaKabulNuclearMedicineTest.Width = 300;

        this.SubEpisodeNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.SubEpisodeNuclearMedicineTest.DataMember = "SubEpisode";
        this.SubEpisodeNuclearMedicineTest.DisplayIndex = 8;
        this.SubEpisodeNuclearMedicineTest.HeaderText = "";
        this.SubEpisodeNuclearMedicineTest.Name = "SubEpisodeNuclearMedicineTest";
        this.SubEpisodeNuclearMedicineTest.Width = 300;

        this.ProcedureObjectNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.ProcedureObjectNuclearMedicineTest.DataMember = "ProcedureObject";
        this.ProcedureObjectNuclearMedicineTest.DisplayIndex = 9;
        this.ProcedureObjectNuclearMedicineTest.HeaderText = "İşlem";
        this.ProcedureObjectNuclearMedicineTest.Name = "ProcedureObjectNuclearMedicineTest";
        this.ProcedureObjectNuclearMedicineTest.Width = 300;

        this.ProcedureDoctorNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorNuclearMedicineTest.DataMember = "ProcedureDoctor";
        this.ProcedureDoctorNuclearMedicineTest.DisplayIndex = 10;
        this.ProcedureDoctorNuclearMedicineTest.HeaderText = "İşlemi Yapan Doktor";
        this.ProcedureDoctorNuclearMedicineTest.Name = "ProcedureDoctorNuclearMedicineTest";
        this.ProcedureDoctorNuclearMedicineTest.Width = 300;

        this.ProcedureByUserNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.ProcedureByUserNuclearMedicineTest.DataMember = "ProcedureByUser";
        this.ProcedureByUserNuclearMedicineTest.DisplayIndex = 11;
        this.ProcedureByUserNuclearMedicineTest.HeaderText = "";
        this.ProcedureByUserNuclearMedicineTest.Name = "ProcedureByUserNuclearMedicineTest";
        this.ProcedureByUserNuclearMedicineTest.Width = 300;

        this.RequestedByUserNuclearMedicineTest = new TTVisual.TTListBoxColumn();
        this.RequestedByUserNuclearMedicineTest.DataMember = "RequestedByUser";
        this.RequestedByUserNuclearMedicineTest.DisplayIndex = 12;
        this.RequestedByUserNuclearMedicineTest.HeaderText = "İşlemi İsteyen Kullanıcı";
        this.RequestedByUserNuclearMedicineTest.Name = "RequestedByUserNuclearMedicineTest";
        this.RequestedByUserNuclearMedicineTest.Width = 300;

        this.AccessionNoNuclearMedicineTest = new TTVisual.TTTextBoxColumn();
        this.AccessionNoNuclearMedicineTest.DataMember = "AccessionNo";
        this.AccessionNoNuclearMedicineTest.DisplayIndex = 13;
        this.AccessionNoNuclearMedicineTest.HeaderText = "Accession Number";
        this.AccessionNoNuclearMedicineTest.Name = "AccessionNoNuclearMedicineTest";
        this.AccessionNoNuclearMedicineTest.Width = 80;

        this.AccountOperationDoneNuclearMedicineTest = new TTVisual.TTCheckBoxColumn();
        this.AccountOperationDoneNuclearMedicineTest.DataMember = "AccountOperationDone";
        this.AccountOperationDoneNuclearMedicineTest.DisplayIndex = 14;
        this.AccountOperationDoneNuclearMedicineTest.HeaderText = "Ücretlendi mi";
        this.AccountOperationDoneNuclearMedicineTest.Name = "AccountOperationDoneNuclearMedicineTest";
        this.AccountOperationDoneNuclearMedicineTest.Width = 80;

        this.AccTrxsMultipliedByAmountNuclearMedicineTest = new TTVisual.TTCheckBoxColumn();
        this.AccTrxsMultipliedByAmountNuclearMedicineTest.DataMember = "AccTrxsMultipliedByAmount";
        this.AccTrxsMultipliedByAmountNuclearMedicineTest.DisplayIndex = 15;
        this.AccTrxsMultipliedByAmountNuclearMedicineTest.HeaderText = "Medula AccTrx leri miktara göre çoğaltıldı";
        this.AccTrxsMultipliedByAmountNuclearMedicineTest.Name = "AccTrxsMultipliedByAmountNuclearMedicineTest";
        this.AccTrxsMultipliedByAmountNuclearMedicineTest.Width = 80;

        this.ActionDateNuclearMedicineTest = new TTVisual.TTDateTimePickerColumn();
        this.ActionDateNuclearMedicineTest.DataMember = "ActionDate";
        this.ActionDateNuclearMedicineTest.DisplayIndex = 16;
        this.ActionDateNuclearMedicineTest.HeaderText = "İşlem Tarihi";
        this.ActionDateNuclearMedicineTest.Name = "ActionDateNuclearMedicineTest";
        this.ActionDateNuclearMedicineTest.Width = 180;

        this.ActiveNuclearMedicineTest = new TTVisual.TTCheckBoxColumn();
        this.ActiveNuclearMedicineTest.DataMember = "Active";
        this.ActiveNuclearMedicineTest.DisplayIndex = 17;
        this.ActiveNuclearMedicineTest.HeaderText = "Aktif";
        this.ActiveNuclearMedicineTest.Name = "ActiveNuclearMedicineTest";
        this.ActiveNuclearMedicineTest.Width = 80;

        this.AmountNuclearMedicineTest = new TTVisual.TTTextBoxColumn();
        this.AmountNuclearMedicineTest.DataMember = "Amount";
        this.AmountNuclearMedicineTest.DisplayIndex = 18;
        this.AmountNuclearMedicineTest.HeaderText = "Miktar";
        this.AmountNuclearMedicineTest.Name = "AmountNuclearMedicineTest";
        this.AmountNuclearMedicineTest.Width = 80;

        this.CreationDateNuclearMedicineTest = new TTVisual.TTDateTimePickerColumn();
        this.CreationDateNuclearMedicineTest.DataMember = "CreationDate";
        this.CreationDateNuclearMedicineTest.DisplayIndex = 19;
        this.CreationDateNuclearMedicineTest.HeaderText = "Oluşturulma Tarihi";
        this.CreationDateNuclearMedicineTest.Name = "CreationDateNuclearMedicineTest";
        this.CreationDateNuclearMedicineTest.Width = 180;

        this.DiscountPercentNuclearMedicineTest = new TTVisual.TTTextBoxColumn();
        this.DiscountPercentNuclearMedicineTest.DataMember = "DiscountPercent";
        this.DiscountPercentNuclearMedicineTest.DisplayIndex = 20;
        this.DiscountPercentNuclearMedicineTest.HeaderText = "İndirim Oranı";
        this.DiscountPercentNuclearMedicineTest.Name = "DiscountPercentNuclearMedicineTest";
        this.DiscountPercentNuclearMedicineTest.Width = 80;

        this.EligibleNuclearMedicineTest = new TTVisual.TTCheckBoxColumn();
        this.EligibleNuclearMedicineTest.DataMember = "Eligible";
        this.EligibleNuclearMedicineTest.DisplayIndex = 21;
        this.EligibleNuclearMedicineTest.HeaderText = "Ücret olusturup olusturmama flag ı";
        this.EligibleNuclearMedicineTest.Name = "EligibleNuclearMedicineTest";
        this.EligibleNuclearMedicineTest.Width = 80;

        this.EmergencyNuclearMedicineTest = new TTVisual.TTCheckBoxColumn();
        this.EmergencyNuclearMedicineTest.DataMember = "Emergency";
        this.EmergencyNuclearMedicineTest.DisplayIndex = 22;
        this.EmergencyNuclearMedicineTest.HeaderText = "Acil";
        this.EmergencyNuclearMedicineTest.Name = "EmergencyNuclearMedicineTest";
        this.EmergencyNuclearMedicineTest.Width = 80;

        this.ExtraDescriptionNuclearMedicineTest = new TTVisual.TTTextBoxColumn();
        this.ExtraDescriptionNuclearMedicineTest.DataMember = "ExtraDescription";
        this.ExtraDescriptionNuclearMedicineTest.DisplayIndex = 23;
        this.ExtraDescriptionNuclearMedicineTest.HeaderText = "Ek Açıklama";
        this.ExtraDescriptionNuclearMedicineTest.Name = "ExtraDescriptionNuclearMedicineTest";
        this.ExtraDescriptionNuclearMedicineTest.Width = 80;

        this.IDNuclearMedicineTest = new TTVisual.TTTextBoxColumn();
        this.IDNuclearMedicineTest.DataMember = "ID";
        this.IDNuclearMedicineTest.DisplayIndex = 24;
        this.IDNuclearMedicineTest.HeaderText = "İşlem No";
        this.IDNuclearMedicineTest.Name = "IDNuclearMedicineTest";
        this.IDNuclearMedicineTest.Width = 80;

        this.IsOldActionNuclearMedicineTest = new TTVisual.TTCheckBoxColumn();
        this.IsOldActionNuclearMedicineTest.DataMember = "IsOldAction";
        this.IsOldActionNuclearMedicineTest.DisplayIndex = 25;
        this.IsOldActionNuclearMedicineTest.HeaderText = "";
        this.IsOldActionNuclearMedicineTest.Name = "IsOldActionNuclearMedicineTest";
        this.IsOldActionNuclearMedicineTest.Width = 80;

        this.MedulaReportNoNuclearMedicineTest = new TTVisual.TTTextBoxColumn();
        this.MedulaReportNoNuclearMedicineTest.DataMember = "MedulaReportNo";
        this.MedulaReportNoNuclearMedicineTest.DisplayIndex = 26;
        this.MedulaReportNoNuclearMedicineTest.HeaderText = "Medula Rapor Numarası";
        this.MedulaReportNoNuclearMedicineTest.Name = "MedulaReportNoNuclearMedicineTest";
        this.MedulaReportNoNuclearMedicineTest.Width = 80;

        this.OlapDateNuclearMedicineTest = new TTVisual.TTDateTimePickerColumn();
        this.OlapDateNuclearMedicineTest.DataMember = "OlapDate";
        this.OlapDateNuclearMedicineTest.DisplayIndex = 27;
        this.OlapDateNuclearMedicineTest.HeaderText = "Olap İşlem Tarihi";
        this.OlapDateNuclearMedicineTest.Name = "OlapDateNuclearMedicineTest";
        this.OlapDateNuclearMedicineTest.Width = 180;

        this.OlapLastUpdateNuclearMedicineTest = new TTVisual.TTDateTimePickerColumn();
        this.OlapLastUpdateNuclearMedicineTest.DataMember = "OlapLastUpdate";
        this.OlapLastUpdateNuclearMedicineTest.DisplayIndex = 28;
        this.OlapLastUpdateNuclearMedicineTest.HeaderText = "Olap Güncelleme Tarihi";
        this.OlapLastUpdateNuclearMedicineTest.Name = "OlapLastUpdateNuclearMedicineTest";
        this.OlapLastUpdateNuclearMedicineTest.Width = 180;

        this.PatientPayNuclearMedicineTest = new TTVisual.TTCheckBoxColumn();
        this.PatientPayNuclearMedicineTest.DataMember = "PatientPay";
        this.PatientPayNuclearMedicineTest.DisplayIndex = 29;
        this.PatientPayNuclearMedicineTest.HeaderText = "Hasta Öder";
        this.PatientPayNuclearMedicineTest.Name = "PatientPayNuclearMedicineTest";
        this.PatientPayNuclearMedicineTest.Width = 80;

        this.PerformedDateNuclearMedicineTest = new TTVisual.TTDateTimePickerColumn();
        this.PerformedDateNuclearMedicineTest.DataMember = "PerformedDate";
        this.PerformedDateNuclearMedicineTest.DisplayIndex = 30;
        this.PerformedDateNuclearMedicineTest.HeaderText = "İşlem Zamanı";
        this.PerformedDateNuclearMedicineTest.Name = "PerformedDateNuclearMedicineTest";
        this.PerformedDateNuclearMedicineTest.Width = 180;

        this.PricingDateNuclearMedicineTest = new TTVisual.TTDateTimePickerColumn();
        this.PricingDateNuclearMedicineTest.DataMember = "PricingDate";
        this.PricingDateNuclearMedicineTest.DisplayIndex = 31;
        this.PricingDateNuclearMedicineTest.HeaderText = "Ücretlendirilme Tarihi";
        this.PricingDateNuclearMedicineTest.Name = "PricingDateNuclearMedicineTest";
        this.PricingDateNuclearMedicineTest.Width = 180;

        this.ReasonOfCancelNuclearMedicineTest = new TTVisual.TTTextBoxColumn();
        this.ReasonOfCancelNuclearMedicineTest.DataMember = "ReasonOfCancel";
        this.ReasonOfCancelNuclearMedicineTest.DisplayIndex = 32;
        this.ReasonOfCancelNuclearMedicineTest.HeaderText = "İşlem İptal Sebebi";
        this.ReasonOfCancelNuclearMedicineTest.Name = "ReasonOfCancelNuclearMedicineTest";
        this.ReasonOfCancelNuclearMedicineTest.Width = 80;

        this.SUTRuleStatusNuclearMedicineTest = new TTVisual.TTEnumComboBoxColumn();
        this.SUTRuleStatusNuclearMedicineTest.DataMember = "SUTRuleStatus";
        this.SUTRuleStatusNuclearMedicineTest.DisplayIndex = 33;
        this.SUTRuleStatusNuclearMedicineTest.HeaderText = "SUT Kural Kontrol Durumu";
        this.SUTRuleStatusNuclearMedicineTest.Name = "SUTRuleStatusNuclearMedicineTest";
        this.SUTRuleStatusNuclearMedicineTest.Width = 80;

        this.WorkListDateNuclearMedicineTest = new TTVisual.TTDateTimePickerColumn();
        this.WorkListDateNuclearMedicineTest.DataMember = "WorkListDate";
        this.WorkListDateNuclearMedicineTest.DisplayIndex = 34;
        this.WorkListDateNuclearMedicineTest.HeaderText = "İş Listesi Tarihi";
        this.WorkListDateNuclearMedicineTest.Name = "WorkListDateNuclearMedicineTest";
        this.WorkListDateNuclearMedicineTest.Width = 180;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#FFFFFF";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = "İşlemi Yapan Doktor";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 19;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 18;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Test Sıra No";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 15;

        //this.ttbutton1 = new TTVisual.TTButton();
        //this.ttbutton1.Text = "Barkod Bas";
        //this.ttbutton1.Name = "ttbutton1";
        //this.ttbutton1.TabIndex = 5;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 9;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tetkik";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Font = "Name=Tahoma, Size=9, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 6;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 3;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Hastanın Yaşı";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 15;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.BackColor = "#F0F0F0";
        this.tttextbox2.ReadOnly = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 4;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "AdmissionTypeListDef";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Protokol No";
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 8;

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 7;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Enabled = false;
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 10;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 11;

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

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "İstek Yapan Tabip Tel";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 8;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 8;

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
        this.PREDIAGNOSIS.TabIndex = 12;
        this.PREDIAGNOSIS.Height = "150px";

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.BackColor = "#F0F0F0";
        this.Description.ReadOnly = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 12;
        this.Description.Height = "150px";

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
        this.labelPreInformation.TabIndex = 12;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İstek Yapan Tabip";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 6;

        this.NuclearMedicineTestsColumns = [this.EquipmentNuclearMedicineTest, this.EpisodeNuclearMedicineTest, this.ProcedureSpecialityNuclearMedicineTest, this.EpisodeActionNuclearMedicineTest, this.PackageDefinitionNuclearMedicineTest, this.MasterSubActionProcedureNuclearMedicineTest, this.MasterPackgSubActionProcedureNuclearMedicineTest, this.MedulaHastaKabulNuclearMedicineTest, this.SubEpisodeNuclearMedicineTest, this.ProcedureObjectNuclearMedicineTest, this.ProcedureDoctorNuclearMedicineTest, this.ProcedureByUserNuclearMedicineTest, this.RequestedByUserNuclearMedicineTest, this.AccessionNoNuclearMedicineTest, this.AccountOperationDoneNuclearMedicineTest, this.AccTrxsMultipliedByAmountNuclearMedicineTest, this.ActionDateNuclearMedicineTest, this.ActiveNuclearMedicineTest, this.AmountNuclearMedicineTest, this.CreationDateNuclearMedicineTest, this.DiscountPercentNuclearMedicineTest, this.EligibleNuclearMedicineTest, this.EmergencyNuclearMedicineTest, this.ExtraDescriptionNuclearMedicineTest, this.IDNuclearMedicineTest, this.IsOldActionNuclearMedicineTest, this.MedulaReportNoNuclearMedicineTest, this.OlapDateNuclearMedicineTest, this.OlapLastUpdateNuclearMedicineTest, this.PatientPayNuclearMedicineTest, this.PerformedDateNuclearMedicineTest, this.PricingDateNuclearMedicineTest, this.ReasonOfCancelNuclearMedicineTest, this.SUTRuleStatusNuclearMedicineTest, this.WorkListDateNuclearMedicineTest];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.ttgroupbox1.Controls = [this.labelProcedureDoctor, this.ProcedureDoctor, this.ttlabel5, this.tttextbox3, this.ttlabel1, this.nucMedSelectedTesttxt, this.tttextbox1, this.ttlabel6, this.tttextbox2, this.ReasonForAdmission, this.ttlabel15, this.REQUESTDOCTOR, this.IsEmergency, this.PATIENTGROUPENUM, this.GridEpisodeDiagnosis, this.ttlabel7, this.REQUESTDOCTORPHONE, this.ttlabel4, this.ttlabel3, this.PREDIAGNOSIS, this.Description,  this.labelProcessTime, this.ActionDate, this.labelPreInformation, this.ttlabel2];
        this.Controls = [this.NuclearMedicineTests, this.EquipmentNuclearMedicineTest, this.EpisodeNuclearMedicineTest, this.ProcedureSpecialityNuclearMedicineTest, this.EpisodeActionNuclearMedicineTest, this.PackageDefinitionNuclearMedicineTest, this.MasterSubActionProcedureNuclearMedicineTest, this.MasterPackgSubActionProcedureNuclearMedicineTest, this.MedulaHastaKabulNuclearMedicineTest, this.SubEpisodeNuclearMedicineTest, this.ProcedureObjectNuclearMedicineTest, this.ProcedureDoctorNuclearMedicineTest, this.ProcedureByUserNuclearMedicineTest, this.RequestedByUserNuclearMedicineTest, this.AccessionNoNuclearMedicineTest, this.AccountOperationDoneNuclearMedicineTest, this.AccTrxsMultipliedByAmountNuclearMedicineTest, this.ActionDateNuclearMedicineTest, this.ActiveNuclearMedicineTest, this.AmountNuclearMedicineTest, this.CreationDateNuclearMedicineTest, this.DiscountPercentNuclearMedicineTest, this.EligibleNuclearMedicineTest, this.EmergencyNuclearMedicineTest, this.ExtraDescriptionNuclearMedicineTest, this.IDNuclearMedicineTest, this.IsOldActionNuclearMedicineTest, this.MedulaReportNoNuclearMedicineTest, this.OlapDateNuclearMedicineTest, this.OlapLastUpdateNuclearMedicineTest, this.PatientPayNuclearMedicineTest, this.PerformedDateNuclearMedicineTest, this.PricingDateNuclearMedicineTest, this.ReasonOfCancelNuclearMedicineTest, this.SUTRuleStatusNuclearMedicineTest, this.WorkListDateNuclearMedicineTest, this.ttgroupbox1, this.labelProcedureDoctor, this.ProcedureDoctor, this.ttlabel5, this.tttextbox3, this.ttlabel1, this.nucMedSelectedTesttxt, this.tttextbox1, this.ttlabel6, this.tttextbox2, this.ReasonForAdmission, this.ttlabel15, this.REQUESTDOCTOR, this.IsEmergency, this.PATIENTGROUPENUM, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttlabel7, this.REQUESTDOCTORPHONE, this.ttlabel4, this.ttlabel3, this.PREDIAGNOSIS, this.labelProcessTime, this.ActionDate, this.labelPreInformation, this.ttlabel2];

    }


}
