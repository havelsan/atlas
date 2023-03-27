//$B8B30550
import { Component, OnInit, NgZone  } from '@angular/core';
import { NuclearMedicineReportedFormViewModel, NuclearMedicineTestInfo } from './NuclearMedicineReportedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';

@Component({
    selector: 'NuclearMedicineReportedForm',
    templateUrl: './NuclearMedicineReportedForm.html',
    providers: [MessageService]
})
export class NuclearMedicineReportedForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    //cmdReport: TTVisual.ITTButton;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    IsEmergency: TTVisual.ITTCheckBox;
    labelProcedureDoctor: TTVisual.ITTLabel;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ResponsibleDoctor: TTVisual.ITTObjectListBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    RADIOPHARMACYDESC: TTVisual.ITTTextBox;
    tttextbox1: TTVisual.ITTTextBox;

    public nuclearMedicineTestInfo: NuclearMedicineTestInfo;

    public GridEpisodeDiagnosisColumns = [];
    public nuclearMedicineReportedFormViewModel: NuclearMedicineReportedFormViewModel = new NuclearMedicineReportedFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineReportedForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineReportedForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService,protected ngZone: NgZone, private reportService: AtlasReportService, ) {
        super(httpService, messageService , ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineReportedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdImage_Click(): Promise<void> {
        //TODO:Showedit!
        //            string accessionNoStr = this._RadiologyTest.AccessionNo.ToString();
        //            string patientIdStr = this._RadiologyTest.EpisodeAction.Episode.Patient.ID.ToString();
        //            TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);

        let url: string = '/api/NuclearMedicineService/RetrieveNuclearMedicineTestInfo';
        let input = { 'NuclearMedicineObjectID': this._NuclearMedicine.ObjectID.toString()};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<NuclearMedicineTestInfo>(url, input);
        this.nuclearMedicineTestInfo = result;


        let accessionNoStr: string = this.nuclearMedicineTestInfo.AccessionNo; //this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.toString();
        let sysparam: string = (await SystemParameterService.GetParameterValue("PACSVIEWERURL", null));
        let URLLink: string = sysparam + "?an=" +  accessionNoStr + "&usr=extreme"; //http://X.X.X.X:35005/?an=0000000&usr=extreme

        if (URLLink == null) {
            InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
        } else {
            let win = window.open(URLLink, '_blank');
            win.focus();
        }

    }

    public async prepareDocument_Click(): Promise<void> {
        let that = this;
        const objectIdParam = new GuidParam(that.nuclearMedicineReportedFormViewModel._NuclearMedicine.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('NuclearMedicineResultReport', reportParameters);
    }

    //private async cmdReport_Click(): Promise<void> {
    //    //this._NuclearMedicine.ShowViewer();

    //    //TODO:ShowEdit!
    //    //string accessionNoStr = this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.ToString();
    //    //string patientIdStr = this._NuclearMedicine.Episode.Patient.ID.ToString();
    //    //TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
    //    let a = 1;
    //}
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.AddHelpMenu();
    }

    // *****Method declarations end *****

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let nuclearMedicineResultreport = new DynamicSidebarMenuItem();
        nuclearMedicineResultreport.key = 'nuclearMedicineResultreport';
        nuclearMedicineResultreport.componentInstance = this;
        nuclearMedicineResultreport.label = 'Sonuç Raporu';
        nuclearMedicineResultreport.icon = 'fa fa-file-text-o';
        nuclearMedicineResultreport.clickFunction = this.prepareDocument_Click;
        this.sideBarMenuService.addMenu('YardimciMenu', nuclearMedicineResultreport);

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
        this.sideBarMenuService.removeMenu('nuclearMedicineResultreport');
    }

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineReportedFormViewModel = new NuclearMedicineReportedFormViewModel();
        this._ViewModel = this.nuclearMedicineReportedFormViewModel;
        this.nuclearMedicineReportedFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineReportedFormViewModel._NuclearMedicine.ProcedureDoctor = new ResUser();
        this.nuclearMedicineReportedFormViewModel._NuclearMedicine.ResponsibleDoctor = new ResUser();
        this.nuclearMedicineReportedFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineReportedFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nuclearMedicineReportedFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineReportedFormViewModel = this._ViewModel as NuclearMedicineReportedFormViewModel;
        that._TTObject = this.nuclearMedicineReportedFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineReportedFormViewModel == null)
            this.nuclearMedicineReportedFormViewModel = new NuclearMedicineReportedFormViewModel();
        if (this.nuclearMedicineReportedFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineReportedFormViewModel._NuclearMedicine = new NuclearMedicine();

        let masterResourceID = that.nuclearMedicineReportedFormViewModel._NuclearMedicine["MasterResource"];
        that.ProcedureDoctor.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResourceID.toString() + '\'';
        that.ResponsibleDoctor.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResourceID.toString() + '\'';



        let procedureDoctorObjectID = that.nuclearMedicineReportedFormViewModel._NuclearMedicine["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.nuclearMedicineReportedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.nuclearMedicineReportedFormViewModel._NuclearMedicine.ProcedureDoctor = procedureDoctor;
            }
        }

        let responsibleDoctorObjectID = that.nuclearMedicineReportedFormViewModel._NuclearMedicine["ResponsibleDoctor"];
        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === "string")) {
            let responsibleDoctor = that.nuclearMedicineReportedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
            if (responsibleDoctor) {
                that.nuclearMedicineReportedFormViewModel._NuclearMedicine.ResponsibleDoctor = responsibleDoctor;
            }
        }

        let episodeObjectID = that.nuclearMedicineReportedFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineReportedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineReportedFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineReportedFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineReportedFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineReportedFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineReportedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let requestDoctorObjectID = that.nuclearMedicineReportedFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineReportedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineReportedFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineReportedFormViewModel);
  
    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

  
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

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProcedureDoctor != event) {
                this._NuclearMedicine.ProcedureDoctor = event;
            }
        }
    }

    public onResponsibleDoctorChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ResponsibleDoctor != event) {
                this._NuclearMedicine.ResponsibleDoctor = event;
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

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.Report != event) {
                this._NuclearMedicine.Report = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "Report");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#DCDCDC";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = "İşlemi Yapan Doktor";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 3;

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 4;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ReadOnly = true;
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 2;

        this.ResponsibleDoctor = new TTVisual.TTObjectListBox();
        this.ResponsibleDoctor.ReadOnly = true;
        this.ResponsibleDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ResponsibleDoctor.Name = "ResponsibleDoctor";
        this.ResponsibleDoctor.TabIndex = 2;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tetkik";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        //this.cmdReport = new TTVisual.TTButton();
        //this.cmdReport.Text = "İmaj Görüntüle";
        //this.cmdReport.Name = "cmdReport";
        //this.cmdReport.TabIndex = 3;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "AdmissionTypeListDef";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 8;

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

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Enabled = false;
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 7;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 5;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "İstek Yapan Tabip";
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 10;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "İşlem Zamanı";
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 6;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "İstek Yapan Tabip Telefon";
        this.ttlabel10.BackColor = "#DCDCDC";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 12;

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

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 1;

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
        this.PREDIAGNOSIS.TabIndex = 0;
        this.PREDIAGNOSIS.Height = "150px";

        this.RADIOPHARMACYDESC = new TTVisual.TTTextBox();
        this.RADIOPHARMACYDESC.Multiline = true;
        this.RADIOPHARMACYDESC.BackColor = "#F0F0F0";
        this.RADIOPHARMACYDESC.ReadOnly = true;
        this.RADIOPHARMACYDESC.Name = "RADIOPHARMACYDESC";
        this.RADIOPHARMACYDESC.TabIndex = 19;
        this.RADIOPHARMACYDESC.Height = "150px";

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 0;
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Height = "150px";

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 1;
        this.tttabpage3.BackColor = "#FFFFFF";
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = "Rapor";
        this.tttabpage3.Name = "tttabpage3";

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.DisplayText = "Rapor";
        this.ttrichtextboxcontrol1.BackColor = "#F0F0F0";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 73;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.ttgroupbox1.Controls = [this.labelProcedureDoctor, this.nucMedSelectedTesttxt, this.ProcedureDoctor, this.ResponsibleDoctor, this.ttlabel1, this.ReasonForAdmission, this.GridEpisodeDiagnosis, this.IsEmergency, this.PATIENTGROUPENUM, this.REQUESTDOCTOR, this.ttlabel9, this.ttlabel8, this.ActionDate, this.REQUESTDOCTORPHONE, this.ttlabel10, this.ttlabel4, this.ttlabel3];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage3];
        this.tttabpage1.Controls = [this.PREDIAGNOSIS];
        this.tttabpage3.Controls = [this.ttrichtextboxcontrol1];
        this.Controls = [this.ttgroupbox1, this.labelProcedureDoctor, this.nucMedSelectedTesttxt, this.ProcedureDoctor, this.ResponsibleDoctor, this.ttlabel1, this.ReasonForAdmission, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.IsEmergency, this.PATIENTGROUPENUM, this.REQUESTDOCTOR, this.ttlabel9, this.ttlabel8, this.ActionDate, this.REQUESTDOCTORPHONE, this.ttlabel10, this.ttlabel4, this.ttlabel3, this.tttabcontrol1, this.tttabpage1, this.PREDIAGNOSIS, this.tttabpage3, this.ttrichtextboxcontrol1];

    }


}
