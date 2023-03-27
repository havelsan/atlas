//$2907DA3E
import { Component, ViewChild, OnInit, EventEmitter, NgZone, Input } from '@angular/core';
import { StatusNotificationReportFormViewModel } from './StatusNotificationReportFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { StatusNotificationReport, StatusNotificationReasonEnum } from 'NebulaClient/Model/AtlasClientModel';
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { PeriodUnitTypeWithUndefiniteEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';

import { ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { ReportDiagnosisForm } from "Modules/Tibbi_Surec/Tani_Modulu/ReportDiagnosisForm";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'StatusNotificationReportForm',
    templateUrl: './StatusNotificationReportForm.html',
    providers: [MessageService],
    outputs: ['OnClosing'],
})
export class StatusNotificationReportForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    CommitteeReport: TTVisual.ITTCheckBox;
    Appropriate: TTVisual.ITTCheckBox;
    InAppropriate: TTVisual.ITTCheckBox;
    Description: TTVisual.ITTTextBox;
    ReportDescription: TTVisual.ITTTextBox;
    DiagnosisDetail: TTVisual.ITTTextBox;
    txtRaporSuresi: TTVisual.ITTTextBox;
    EndDate: TTVisual.ITTDateTimePicker;
    HCRequestReason: TTVisual.ITTObjectListBox;
    labelActionDate: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    cmbRaporSureTuru: TTVisual.ITTEnumComboBox;
    labelEndDate: TTVisual.ITTLabel;
    labelHCRequestReason: TTVisual.ITTLabel;
    labelMasterResource: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelReasonForExaminationHCRequestReason: TTVisual.ITTLabel;
    labelReportDecision: TTVisual.ITTLabel;
    labelReportNo: TTVisual.ITTLabel;
    labelSecondDoctor: TTVisual.ITTLabel;
    labelStartDate: TTVisual.ITTLabel;
    labelThirdDoctor: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ReasonForExaminationHCRequestReason: TTVisual.ITTObjectListBox;
    Complaint: TTVisual.ITTTextBox;
    PatientHistory: TTVisual.ITTTextBox;
    PhysicalExamination: TTVisual.ITTTextBox;
    ReportDecision: TTVisual.ITTRichTextBoxControl;
    MTSConclusion: TTVisual.ITTTextBox;
    ReportNo: TTVisual.ITTTextBox;
    SecondDoctor: TTVisual.ITTObjectListBox;
    StartDate: TTVisual.ITTDateTimePicker;
    ThirdDoctor: TTVisual.ITTObjectListBox;
    ReportReason: TTVisual.ITTEnumComboBox;

    labelTabip2: string;
    labelTabip3: string;
    isNewState: boolean;

    complaintSelected: TTVisual.ITTCheckBox;
    historySelected: TTVisual.ITTCheckBox;
    physicalExaminationSelected: TTVisual.ITTCheckBox;
    MTSConclusionSelected: TTVisual.ITTCheckBox;
    showAnamnez: boolean = false;
    showReportDiagnosis: boolean = false;
    openedReportAsPopUp: boolean = false;
    public IsNewState: boolean = false;
    public IsCancelState: boolean = false;
    public CanPrint: boolean = false;
    public IsBackState: boolean = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public decisionText: string = "";
    /* XXXXXX Pursaklar Mı  */
    public isHospitalPursaklar: boolean = false;
    /* */
    public restReportDecisionVisible: boolean = false;
    public statusNotificationOneDoctorDecisionVisible: boolean = false;
    public defaultDecisionVisible: boolean = true;
    public enableStartDateBounds: boolean = false;

    @ViewChild('Report') Report: ReportDiagnosisForm;

    public statusNotificationReportFormViewModel: StatusNotificationReportFormViewModel = new StatusNotificationReportFormViewModel();
    public get _StatusNotificationReport(): StatusNotificationReport {
        return this._TTObject as StatusNotificationReport;
    }
    private StatusNotificationReportForm_DocumentUrl: string = '/api/StatusNotificationReportService/StatusNotificationReportForm';
    private StatusNotificationReportFormPre_DocumentUrl: string = '/api/StatusNotificationReportService/StatusNotificationReportFormPre';
    private StatusNotificationReportFormEmpty_DocumentUrl: string = '/api/StatusNotificationReportService/StatusNotificationReportFormEmpty';

    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalStateService: ModalStateService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super('STATUSNOTIFICATIONREPORT', 'StatusNotificationReportForm');
        this._DocumentServiceUrl = this.StatusNotificationReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    private _modalInfo: ModalInfo;

    public setInputParam(value: StatusNotificationReport) {
        if (value != null && !value.IsNew)
            this.ObjectID = value.ObjectID;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
        if (value == null)
            this.openedReportAsPopUp = false;
        else
            this.openedReportAsPopUp = true;
    }

    @Input() set StatusNotificationRep(value: StatusNotificationReport) {
        if (value != null) {
            this.ObjectID = value.ObjectID as Guid;
        }
        else {
        }
    }

    private _reportActiveIDsModel: ActiveIDsModel;
    @Input() set ReportActiveIDsModel(value: ActiveIDsModel) {
        this._reportActiveIDsModel = value;
        this.ActiveIDsModel = value
    }
    get reportActiveIDsModel(): ActiveIDsModel {
        return this._reportActiveIDsModel;
    }

    async ngOnInit() {
        if (this.ObjectID != null) {
            this.LoadForm();
        }
        else {
            await this.LoadEmptyForm();
            this.LoadForm();
        }
    }

    public async LoadForm() {
        let that = this;
        await this.load(StatusNotificationReportFormViewModel);


        let enableStartDateBounds: string = (await SystemParameterService.GetParameterValue('RAPORBASLANGICTARIHISINIR', 'FALSE'));
        if (enableStartDateBounds === 'TRUE') {
            this.enableStartDateBounds = true;
        }
        else {
            this.enableStartDateBounds = false;
        }
    }

    public async ngAfterViewInit() {
        let isHospitalPursaklar: string = (await SystemParameterService.GetParameterValue('DURUMBILDIRIRRAPORUPURSAKLAR', 'FALSE'));
        if (isHospitalPursaklar === 'TRUE') {
            this.isHospitalPursaklar = true;
        }
        else {
            this.isHospitalPursaklar = false;
        }
    }

    // ***** Method declarations start *****


    // *****Method declarations end *****

    OnClosing: EventEmitter<Boolean> = new EventEmitter<any>();

    public initViewModel(): void {
        this._TTObject = new StatusNotificationReport();
        this.statusNotificationReportFormViewModel = new StatusNotificationReportFormViewModel();
        this._ViewModel = this.statusNotificationReportFormViewModel;
        this.statusNotificationReportFormViewModel._StatusNotificationReport = this._TTObject as StatusNotificationReport;
        this.statusNotificationReportFormViewModel._StatusNotificationReport.ThirdDoctor = new ResUser();
        this.statusNotificationReportFormViewModel._StatusNotificationReport.SecondDoctor = new ResUser();
        this.statusNotificationReportFormViewModel._StatusNotificationReport.MasterResource = new ResSection();
        this.statusNotificationReportFormViewModel._StatusNotificationReport.ProcedureDoctor = new ResUser();
        this.statusNotificationReportFormViewModel._StatusNotificationReport.HCRequestReason = new HCRequestReason();
        this.statusNotificationReportFormViewModel._StatusNotificationReport.HCRequestReason.ReasonForExamination = new ReasonForExaminationDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.statusNotificationReportFormViewModel = this._ViewModel as StatusNotificationReportFormViewModel;
        that._TTObject = this.statusNotificationReportFormViewModel._StatusNotificationReport;
        if (this.statusNotificationReportFormViewModel == null)
            this.statusNotificationReportFormViewModel = new StatusNotificationReportFormViewModel();
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport == null)
            this.statusNotificationReportFormViewModel._StatusNotificationReport = new StatusNotificationReport();
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CurrentStateDefID.valueOf() == StatusNotificationReport.StatusNotificationReportStates.New.id)
            this.isNewState = true;
        else
            this.isNewState = false;
        let thirdDoctorObjectID = that.statusNotificationReportFormViewModel._StatusNotificationReport["ThirdDoctor"];
        if (thirdDoctorObjectID != null && (typeof thirdDoctorObjectID === "string")) {
            let thirdDoctor = that.statusNotificationReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === thirdDoctorObjectID.toString());
            if (thirdDoctor) {
                that.statusNotificationReportFormViewModel._StatusNotificationReport.ThirdDoctor = thirdDoctor;
            }
        }
        let secondDoctorObjectID = that.statusNotificationReportFormViewModel._StatusNotificationReport["SecondDoctor"];
        if (secondDoctorObjectID != null && (typeof secondDoctorObjectID === "string")) {
            let secondDoctor = that.statusNotificationReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === secondDoctorObjectID.toString());
            if (secondDoctor) {
                that.statusNotificationReportFormViewModel._StatusNotificationReport.SecondDoctor = secondDoctor;
            }
        }
        let masterResourceObjectID = that.statusNotificationReportFormViewModel._StatusNotificationReport["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.statusNotificationReportFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.statusNotificationReportFormViewModel._StatusNotificationReport.MasterResource = masterResource;
            }
        }
        let procedureDoctorObjectID = that.statusNotificationReportFormViewModel._StatusNotificationReport["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.statusNotificationReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.statusNotificationReportFormViewModel._StatusNotificationReport.ProcedureDoctor = procedureDoctor;
            }
        }
        let hCRequestReasonObjectID = that.statusNotificationReportFormViewModel._StatusNotificationReport["HCRequestReason"];
        if (hCRequestReasonObjectID != null && (typeof hCRequestReasonObjectID === "string")) {
            let hCRequestReason = that.statusNotificationReportFormViewModel.HCRequestReasons.find(o => o.ObjectID.toString() === hCRequestReasonObjectID.toString());
            if (hCRequestReason) {
                that.statusNotificationReportFormViewModel._StatusNotificationReport.HCRequestReason = hCRequestReason;
            }
            if (hCRequestReason != null) {
                let reasonForExaminationObjectID = hCRequestReason["ReasonForExamination"];
                if (reasonForExaminationObjectID != null && (typeof reasonForExaminationObjectID === "string")) {
                    let reasonForExamination = that.statusNotificationReportFormViewModel.ReasonForExaminationDefinitions.find(o => o.ObjectID.toString() === reasonForExaminationObjectID.toString());
                    if (reasonForExamination) {
                        hCRequestReason.ReasonForExamination = reasonForExamination;
                    }
                }
            }
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate == null || this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate == undefined)
            this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate = new Date();
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.IsNew == true && (this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate == null || this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate == undefined))
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = new Date();

        //reloadda hata alındığı için konuldu
        if (this._StatusNotificationReport.CurrentStateDefID.valueOf() == StatusNotificationReport.StatusNotificationReportStates.Cancelled.id) {
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate == null || this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate == undefined)
                this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = new Date();
        }

        /* if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CopyComplaint == true)
         {
             this.complaintSelected.Value = true;
         }
         if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CopyPatientHistory == true)
         {
             this.historySelected.Value = true;
         }
         if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CopyPhysicalExamination == true)
         {
             this.physicalExaminationSelected.Value = true;
         }
         if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CopyMTSConclusion == true)
         {
             this.MTSConclusionSelected.Value = true;
         }
         this.sendAnamnez();*/
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.HCRequestReason != null) {
            this.changeDecisionVisible();
        }

        if (this.enableStartDateBounds == true) {
            this.StartDate.Min = this.statusNotificationReportFormViewModel.minReportDate;
            this.StartDate.Max = this.statusNotificationReportFormViewModel.maxReportDate;
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration == null)
            this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration = 1;
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType == null)
            this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType = PeriodUnitTypeWithUndefiniteEnum.DayPeriod;
    }

    async LoadEmptyForm() {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";
            fullApiUrl = this.StatusNotificationReportFormEmpty_DocumentUrl;

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<StatusNotificationReportFormViewModel>(fullApiUrl, StatusNotificationReportFormViewModel);

            this._ViewModel = response;

            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            await this.Report.getReadOnlyDiagnosis();
            await this.SetButtonVisibility();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    protected async PreScript(): Promise<void> {
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CommitteeReport == null)
            this.statusNotificationReportFormViewModel._StatusNotificationReport.CommitteeReport = false;
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CommitteeReport == true) {
            this.SecondDoctor.Enabled = true;
            this.SecondDoctor.Required = true;
            this.ThirdDoctor.Enabled = true;
            this.ThirdDoctor.Required = true;
        }

        await this.SetButtonVisibility();
    }

    async SetButtonVisibility() {
        if (this._StatusNotificationReport.CurrentStateDefID.valueOf() == StatusNotificationReport.StatusNotificationReportStates.New.id) {
            this.CanPrint = false;
            this.IsBackState = true;
            this.IsCancelState = true;
            this.IsNewState = false;
        }
        else if (this._StatusNotificationReport.CurrentStateDefID.valueOf() == StatusNotificationReport.StatusNotificationReportStates.Saved.id) {
            this.IsCancelState = false;
            this.CanPrint = false;
            this.IsNewState = false;
            this.IsBackState = true;
        }
        else if (this._StatusNotificationReport.CurrentStateDefID.valueOf() == StatusNotificationReport.StatusNotificationReportStates.Completed.id) {
            this.CanPrint = false;
            this.IsBackState = false;
            this.IsCancelState = true;
            this.IsNewState = true;
        }
        else if (this._StatusNotificationReport.CurrentStateDefID.valueOf() == StatusNotificationReport.StatusNotificationReportStates.Cancelled.id) {
            this.CanPrint = true;
            this.IsBackState = true;
            this.IsCancelState = true;
            this.IsNewState = true;
        }
    }

    //protected async PostScript(transDef: TTObjectStateTransitionDef) {
    //    await super.PostScript(transDef);
    //}
    public cmbRaporSureTuruChanged(event): void {

        //if (this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate == null) {
        //    this.messageService.showError(i18n("M20775", "Rapor Başlangıç Tarihi Girmelisiniz!"));
        //    return;
        //}
        //if (event !== PeriodUnitTypeWithUndefiniteEnum.Undefinite && this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration == null) {
        //    this.messageService.showError(i18n("M30209", "Rapor Süresi Bilgisini Girmelisiniz!"));
        //    return;
        //}

        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.ReportDurationType != event) {
                this._StatusNotificationReport.ReportDurationType = event;
            }
        }

        let thisdate: Date = new Date();
        thisdate = this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate;
        if (event == PeriodUnitTypeWithUndefiniteEnum.DayPeriod) {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = thisdate.AddDays(parseInt(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration.toString()));
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(-1);
        }
        if (event == PeriodUnitTypeWithUndefiniteEnum.MonthPeriod) {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = thisdate.AddMonths(parseInt(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration.toString()));
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(-1);
        }
        if (event == PeriodUnitTypeWithUndefiniteEnum.YearPeriod) {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = thisdate.AddYears(parseInt(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration.toString()));
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(-1);
        }
        if (event == PeriodUnitTypeWithUndefiniteEnum.WeekPeriod) {
            let gun: number = parseInt(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration.toString()) * 7;
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = thisdate.AddDays(gun);
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(-1);
        }
        if (event == PeriodUnitTypeWithUndefiniteEnum.Undefinite || event == PeriodUnitTypeWithUndefiniteEnum.StillContinue) {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = null;
            this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration = null;
        }

        this.updateDecisionValues();
    }
    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.ActionDate != event) {
                this._StatusNotificationReport.ActionDate = event;
            }
        }
    }
    public actionIdForDemografic(): Guid {
        if (this._StatusNotificationReport.MasterAction != null) {
            if (typeof this._StatusNotificationReport.MasterAction === "string") {
                return this._StatusNotificationReport.MasterAction;
            }
            else {
                return this._StatusNotificationReport.MasterAction.ObjectID;
            }
        } else if (this.reportActiveIDsModel != null) {
            return this.reportActiveIDsModel.episodeActionId;
        }

        return this._StatusNotificationReport.ObjectID;
    }

    public async btnPrint_Click() {
        try {
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CurrentStateDefID != StatusNotificationReport.StatusNotificationReportStates.Completed) {
                ServiceLocator.MessageService.showError(i18n("M30214", "Tamamlanmamış raporlar yazdırılamaz."));
            }
            else {
                if (this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "842e1769-fff2-415d-80bb-30281dbf6b1e" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "02c9df60-3507-4c14-8162-1ba5584ae897" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "77b8dc29-8850-4733-8d31-5b51bf0d080b") {
                    const objectIdParam = new GuidParam(this._StatusNotificationReport.ObjectID);
                    let reportParameters: any = { 'OBJECTID': objectIdParam };
                    this.reportService.showReport('MEDICALSTUFFREPORTREPORT', reportParameters);
                } else if (this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "43a28b0f-e419-4ef0-a028-039fc40e4a77" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "bf32a4f5-79a8-4b9b-8200-1e15e56cc524" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "97c1f9a9-4a18-4720-ba75-6f3b0fbc0841" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "9de74dab-2fe2-430c-9621-39ffadbfc9cf") {
                    const objectIdParam = new GuidParam(this._StatusNotificationReport.ObjectID);
                    let reportParameters: any = { 'OBJECTID': objectIdParam };
                    this.reportService.showReport('STATUSNOTIFICATIONCOMITEEREPORTREPORT', reportParameters);
                } else if (this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "3ad998b1-111a-4e18-82b8-b21305f0f504" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "ec2bbc8c-5c50-4382-b028-e34542897d90" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "8e1b2ff0-633a-4cb2-ba13-5ad04e4e402a" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "8acf6a3d-6a37-476e-835c-5a2b504ba0da") {
                    const objectIdParam = new GuidParam(this._StatusNotificationReport.ObjectID);
                    let reportParameters: any = { 'OBJECTID': objectIdParam };
                    this.reportService.showReport('STATUSNOTIFICATIONRESTREPORTREPORT', reportParameters);
                } else if (this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "402650d7-d53d-4855-82b5-ac0a7520d9e0" ||
                    this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "f9b7c97b-073c-4f14-a3d2-db4e73bafe8f") {
                    const objectIdParam = new GuidParam(this._StatusNotificationReport.ObjectID);
                    let reportParameters: any = { 'OBJECTID': objectIdParam };
                    this.reportService.showReport('STATUSNOTIFICATIONONEDOCREPORTREPORT', reportParameters);
                }
                else {
                    const objectIdParam = new GuidParam(this._StatusNotificationReport.ObjectID);
                    let reportParameters: any = { 'OBJECTID': objectIdParam };
                    this.reportService.showReport('STATUSNOTIFICATIONREPORTREPORT', reportParameters);
                }

            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    public async btnBack_Click() {
        try {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.CurrentStateDefID = StatusNotificationReport.StatusNotificationReportStates.New;
            this.statusNotificationReportFormViewModel.ToState = StatusNotificationReport.StatusNotificationReportStates.Saved;

            await this.httpService.post('/api/StatusNotificationReportService/Undo', this.statusNotificationReportFormViewModel._StatusNotificationReport, StatusNotificationReport);
            const objectIdParam = new Guid(this._StatusNotificationReport.ObjectID);
            await this.loadReportByID(objectIdParam);

            this.showSaveSuccessMessage();

            await this.OnClosing.emit(true);
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    public async btnCancel_Click() {
        try {
            await this.httpService.post('/api/StatusNotificationReportService/Cancel', this.statusNotificationReportFormViewModel._StatusNotificationReport, StatusNotificationReport);
            const objectIdParam = new Guid(this._StatusNotificationReport.ObjectID);
            await this.loadReportByID(objectIdParam);

            ServiceLocator.MessageService.showInfo(i18n("M30210", "Rapor İptal Edildi."));

            await this.OnClosing.emit(true);
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    public async onCommitteeReportChanged(event): Promise<void> {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.CommitteeReport != event) {
                this._StatusNotificationReport.CommitteeReport = event;
            }

            if (event == true) {
                this.ThirdDoctor.Enabled = true;
                this.SecondDoctor.Enabled = true;

            }
            else {
                this.ThirdDoctor.Enabled = false;
                this.SecondDoctor.Enabled = false;
                this._StatusNotificationReport.ThirdDoctor = null;
                this._StatusNotificationReport.SecondDoctor = null;
            }
        }
    }

    public async onAppropriateChanged(event): Promise<void> {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.Appropriate != event) {
                this._StatusNotificationReport.Appropriate = event;
                this._StatusNotificationReport.InAppropriate = !event;
            }
        }
    }


    public async onInAppropriateChanged(event): Promise<void> {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.InAppropriate != event) {
                this._StatusNotificationReport.InAppropriate = event;
                this._StatusNotificationReport.Appropriate = !event;
            }
        }
    }

    private async HCRequestReason_SelectedObjectChanged(): Promise<void> {
        if (this._StatusNotificationReport.HCRequestReason != null) {
            let apiUrlForReasonForExamination: string = '/api/StatusNotificationReportService/GetReasonForExamination?requestReasonObjectID=' + this._StatusNotificationReport.HCRequestReason.ObjectID;
            this.statusNotificationReportFormViewModel._StatusNotificationReport.HCRequestReason.ReasonForExamination = <ReasonForExaminationDefinition>await this.httpService.get(apiUrlForReasonForExamination);
        }
    }
    openReportDiagnosisPopup() {
        this.showReportDiagnosis = true;
    }
    closeReportDiagnosisPopup() {
        this.showReportDiagnosis = false;
    }

    comingViewModel(data: any) {
        this.statusNotificationReportFormViewModel.reportDiagnosisFormViewModel = data;
        this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail = "";
        this.statusNotificationReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList.forEach(element => {
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail != "") {
                this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail += " ,";
            } else {
                this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail += "";

            }
            this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail += element.DiagnoseName;

        });
        //if (this.statusNotificationReportFormViewModel.reportDiagnosisFormViewModel != null && this.statusNotificationReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList != null) {
        //    if (this.statusNotificationReportFormViewModel.diagnosisCodeList == null)
        //        this.statusNotificationReportFormViewModel.diagnosisCodeList = new Array<string>();

        //    if (this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail == null) {
        //        this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail = "";
        //        for (let diagnosis of this.statusNotificationReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList) {
        //            let code: string = null;
        //            if (this.statusNotificationReportFormViewModel.diagnosisCodeList != null && this.statusNotificationReportFormViewModel.diagnosisCodeList.length > 0)
        //                code = this.statusNotificationReportFormViewModel.diagnosisCodeList.find(t => t === diagnosis.DiagnoseCode);
        //            if (code == null) {
        //                this.statusNotificationReportFormViewModel.diagnosisCodeList.push(diagnosis.DiagnoseCode);
        //                this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail += diagnosis.DiagnoseName + " ";
        //            }
        //        }
        //    }
        //    else {
        //        if (this.statusNotificationReportFormViewModel.diagnosisCodeList.length == 0) {
        //            for (let diagnosis of data.ReportDiagnosisGridList) {
        //                this.statusNotificationReportFormViewModel.diagnosisCodeList.push(diagnosis.DiagnoseCode)
        //            }
        //        }
        //        if (this.statusNotificationReportFormViewModel.diagnosisCodeList != null && this.statusNotificationReportFormViewModel.diagnosisCodeList.length > 0) {
        //            for (let diagnosis of this.statusNotificationReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList) {
        //                let code: string = null;
        //                if (this.statusNotificationReportFormViewModel.diagnosisCodeList != null && this.statusNotificationReportFormViewModel.diagnosisCodeList.length > 0)
        //                    code = this.statusNotificationReportFormViewModel.diagnosisCodeList.find(t => t === diagnosis.DiagnoseCode);
        //                if (code == null) {
        //                    this.statusNotificationReportFormViewModel.diagnosisCodeList.push(diagnosis.DiagnoseCode);
        //                    this.statusNotificationReportFormViewModel._StatusNotificationReport.DiagnosisDetail += diagnosis.DiagnoseName + " ";
        //                }
        //            }
        //        }
        //    }
        //}
    }
    public async loadPanelOperation(visible: boolean, message: string) {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public async onSaveDiagnosis() {

        
        
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ProcedureDoctor == null) {
            this.messageService.showInfo(i18n("M13200", "Doktor Seçiniz!"));
            return;
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate == null) {
            this.messageService.showInfo(i18n("M11632", "Başlangıç Saati Giriniz!"));
            return;
        }
        if (!(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.Undefinite || this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.StillContinue)
            && this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate == null) {
            this.messageService.showInfo(i18n("M11934", "Bitiş Saati Giriniz!"));
            return;
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.HCRequestReason == null) {
            this.messageService.showInfo(i18n("M16647", "İstek Sebebi Seçiniz!"));
            return;
        }
        /*  if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType != PeriodUnitTypeWithUndefiniteEnum.Undefinite && this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.getTime() <= this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate.getTime()) {
              this.messageService.showInfo(i18n("M11944", "Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! "));
              return;
          }*/
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CommitteeReport == true) {
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.SecondDoctor == null) {
                this.messageService.showInfo(i18n("M10182", "2. Doktor Alanı Boş Geçilemez ! "));
                return;
            }
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ThirdDoctor == null) {
                this.messageService.showInfo(i18n("M10268", "3. Doktor Alanı Boş Geçilemez ! "));
                return;
            }
        }
        this.statusNotificationReportFormViewModel._StatusNotificationReport.CurrentStateDefID = StatusNotificationReport.StatusNotificationReportStates.New;
        this.statusNotificationReportFormViewModel.ToState = StatusNotificationReport.StatusNotificationReportStates.Saved;

        if (this._modalInfo != null)
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.statusNotificationReportFormViewModel._StatusNotificationReport);

        try {
            //   this.loadPanelOperation(true, i18n("M15370", "Rapor kaydediliyor, lütfen bekleyiniz."));
            //await this.ClientSidePostScript(null);
            //await this.PostScript(null);
            let injector = ServiceLocator.Injector;
            let messageService: MessageService = injector.get(MessageService);
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let result = await httpService.post(this._DocumentServiceUrl, this._ViewModel, StatusNotificationReportFormViewModel);

            await this.loadPanelOperation(false, '');
            await this.AfterContextSavedScript(null);
            //await this.load(StatusNotificationReportFormViewModel);
            const objectIdParam = new Guid(this._StatusNotificationReport.ObjectID);
            await this.loadReportByID(objectIdParam);


            this.showSaveSuccessMessage();

            await this.OnClosing.emit(true);
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

        //let result = await this.httpService.post('/api/StatusNotificationReportService/StatusNotificationReportForm', this.statusNotificationReportFormViewModel);
        //if (result != null) {

        //}
    }
    protected async loadReportByID(objectID: Guid) {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";

            if (objectID != null) {
                fullApiUrl = this.StatusNotificationReportFormPre_DocumentUrl + '/?id=' + objectID;
            }
            else {
                fullApiUrl = `${this.StatusNotificationReportFormPre_DocumentUrl}/${Guid.Empty}`;
            }

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<StatusNotificationReportFormViewModel>(fullApiUrl, StatusNotificationReportFormViewModel);
            this._ViewModel = response;


            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            await this.Report.getReadOnlyDiagnosis();
            await this.SetButtonVisibility();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    async onSaveAndCompleteDiagnosis(): Promise<void> {

        if(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType != null){
            if(!(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.Undefinite || this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.StillContinue)
                && this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration == null){
                this.messageService.showInfo(i18n("M17288", "Rapor Süresi Alanı Boş Bırakılamaz!"));
                return;
            }
        }

        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ProcedureDoctor == null) {
            this.messageService.showInfo(i18n("M13200", "Doktor Seçiniz!"));
            return;
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate == null) {
            this.messageService.showInfo(i18n("M11632", "Başlangıç Saati Giriniz!"));
            return;
        }
        if (!(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.Undefinite || this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.StillContinue)
            && this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate == null) {
            this.messageService.showInfo(i18n("M11934", "Bitiş Saati Giriniz!"));
            return;
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.HCRequestReason == null) {
            this.messageService.showInfo(i18n("M16647", "İstek Sebebi Seçiniz!"));
            return;
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDecision == null && this.statusNotificationReportFormViewModel._StatusNotificationReport.Appropriate == null && this.statusNotificationReportFormViewModel._StatusNotificationReport.InAppropriate == null) {
            this.messageService.showInfo(i18n("M17288", "Karar Yazılmadan Raporu Tamamlayamazsınız!"));
            return;
        }
        /* if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDurationType != PeriodUnitTypeWithUndefiniteEnum.Undefinite && this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.getTime() <= this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate.getTime()) {
             this.messageService.showInfo(i18n("M11944", "Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! "));
             return;
         }
         */
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.CommitteeReport == true) {
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.SecondDoctor == null) {
                this.messageService.showInfo(i18n("M10182", "2. Doktor Alanı Boş Geçilemez ! "));
                return;
            }
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ThirdDoctor == null) {
                this.messageService.showInfo(i18n("M10268", "3. Doktor Alanı Boş Geçilemez ! "));
                return;
            }
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "f9b7c97b-073c-4f14-a3d2-db4e73bafe8f" && this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportReason == null) {
            this.messageService.showInfo("Rapor Türü Seçilmeden Raporu Tamamlayamazsınız.");
            return;
        }
        if (this._modalInfo != null)
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.statusNotificationReportFormViewModel._StatusNotificationReport);
        this.statusNotificationReportFormViewModel._StatusNotificationReport.CurrentStateDefID = StatusNotificationReport.StatusNotificationReportStates.Completed;
        this.statusNotificationReportFormViewModel.ToState = StatusNotificationReport.StatusNotificationReportStates.Completed;

        try {
            //    this.loadPanelOperation(true, i18n("M15370", "Rapor kaydediliyor, lütfen bekleyiniz."));
            let injector = ServiceLocator.Injector;
            let messageService: MessageService = injector.get(MessageService);
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let result = await httpService.post(this._DocumentServiceUrl, this._ViewModel, StatusNotificationReportFormViewModel);

            await this.loadPanelOperation(false, '');
            await this.AfterContextSavedScript(null);
            const objectIdParam = new Guid(this._StatusNotificationReport.ObjectID);
            await this.loadReportByID(objectIdParam);
            this.showSaveSuccessMessage();

            await this.OnClosing.emit(true);
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public fun(a: any) {

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PopupTextAreaForm';
        componentInfo.ModuleName = 'PopupTextAreaModule';
        componentInfo.ModulePath = 'Modules/Tibbi_Surec/Sosyal_Hizmetler_Modulu/PopupTextArea/PopupTextAreaModule';
        componentInfo.InputParam = new DynamicComponentInputParam(a.Text, new ActiveIDsModel(this._StatusNotificationReport.ObjectID, null, null));

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = "";
        modalInfo.Width = 950;
        modalInfo.Height = 950;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                if (res.Param.toString() != "[object Object]") {
                    a.Rtf = res.Param;

                    a.Text = res.Param;
                }
            }).catch(err => {
                reject(err);
            });
        });
        return promise;

    }
    anamnez(): void {
        this.showAnamnez = true;
    }

    copyComplaint(): void {
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == null) {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = "";
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == "") {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = this.statusNotificationReportFormViewModel.Complaint;
        } else {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = this.statusNotificationReportFormViewModel._StatusNotificationReport.Description + "\r\n" + this.statusNotificationReportFormViewModel.Complaint;
        }
    }
    copyHistory(): void {
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == null) {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = "";
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == "") {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = this.statusNotificationReportFormViewModel.PatientHistory;
        } else {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = this.statusNotificationReportFormViewModel._StatusNotificationReport.Description + "\r\n" + this.statusNotificationReportFormViewModel.PatientHistory;
        }
    }
    copyPhysicalExamination(): void {
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == null) {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = "";
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == "") {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = this.statusNotificationReportFormViewModel.PhysicalExamination;
        } else {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = this.statusNotificationReportFormViewModel._StatusNotificationReport.Description + "\r\n" + this.statusNotificationReportFormViewModel.PhysicalExamination;
        }
    }
    copyConclusion(): void {
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == null) {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = "";
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == "") {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = this.statusNotificationReportFormViewModel.MTSConclusion;
        } else {
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = this.statusNotificationReportFormViewModel._StatusNotificationReport.Description + "\r\n" + this.statusNotificationReportFormViewModel.MTSConclusion;
        }
    }
    sendAnamnez(): void {
        //if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Description == null)
        /* if (this.complaintSelected.Value || this.historySelected.Value || this.physicalExaminationSelected.Value || this.MTSConclusionSelected.Value) {
             this.statusNotificationReportFormViewModel._StatusNotificationReport.Description = "";
         }

         if (this.complaintSelected.Value && this.statusNotificationReportFormViewModel.Complaint != null)
             this.statusNotificationReportFormViewModel._StatusNotificationReport.Description += this.statusNotificationReportFormViewModel.Complaint + "\r\n";
         if (this.historySelected.Value && this.statusNotificationReportFormViewModel.PatientHistory != null)
             this.statusNotificationReportFormViewModel._StatusNotificationReport.Description += this.statusNotificationReportFormViewModel.PatientHistory + "\r\n";
         if (this.physicalExaminationSelected.Value && this.statusNotificationReportFormViewModel.PhysicalExamination != null)
             this.statusNotificationReportFormViewModel._StatusNotificationReport.Description += this.statusNotificationReportFormViewModel.PhysicalExamination + "\r\n";
         if (this.MTSConclusionSelected.Value && this.statusNotificationReportFormViewModel.MTSConclusion != null)
             this.statusNotificationReportFormViewModel._StatusNotificationReport.Description += this.statusNotificationReportFormViewModel.MTSConclusion + "\r\n";
 */
        this.showAnamnez = false;
    }

    public RestReportUpdateDecisionField(): void {
        let startDate: string;
        let endDate: string;
        let beginDate: string;

        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate != null) {
            startDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate.toLocaleDateString();
            this.decisionText = startDate + " den ";
        } else {
            this.decisionText = "...../...../...... den "; //startDate = "...../...../......";
        }

        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate != null) {
            endDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.toLocaleDateString();
            beginDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(1).toLocaleDateString();
            this.decisionText += endDate + " tarihine kadar istirahatlidir. " + beginDate + " tarihinde";
        } else {
            endDate = ""; //endDate = "...../...../......";
            this.decisionText += "...../...../...... tarihine kadar istirahatlidir. ...../...../...... tarihinde";
        }
        this.Appropriate.Title = " çalışır. / eğitim ve öğretime devam eder.";
        this.InAppropriate.Title = " kontrol önerilir.";

    }

    public StatusNotificationOneDocReportUpdateDecisionField() {
        let startDate: string;
        let reportDecision: string;

        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate != null) {
            startDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate.toLocaleDateString();
        } else {
            startDate = "_______________";
        }
        if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDecision != null) {

            reportDecision = this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDecision.toString();
        } else {
            reportDecision = "......................."; //startDate = "...../...../......";
        }
        let muayeneText = "fizik";
        if (this.isHospitalPursaklar == true) {
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportReason == StatusNotificationReasonEnum.MentalBalance 
                || this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportReason == StatusNotificationReasonEnum.Shotgun)
                muayeneText = "psikiyatri";
            this.Appropriate.Title = "Yukarıda bilgileri bulunan şahsın " + startDate + " tarihinde yapılan " + muayeneText + " muayenesi sonucunda " + reportDecision + " bildirir hekim kanaat raporudur. ";
            this.InAppropriate.Title = " Yukarıda bilgileri bulunan şahsın " + startDate + " tarihinde yapılan " + muayeneText + " muayenesi sonucunda ileri tetkik için üst basamak bir sağlık kuruluşunda değerlendirilmsei uygundur.";
        } else {
            this.Appropriate.Title = "Yukarıda bilgileri bulunan şahsın düzenlemiş olduğu bilgi formu ve " + startDate + " tarihinde yapılan "+muayeneText+" muayenesi sonucunda " + reportDecision + " engel bir durumu olmadığını bildirir hekim kanaat raporudur. ";
            this.InAppropriate.Title = " Yukarıda bilgileribulunan şahsın düzenlemiş olduğu bilgi formu ve " + startDate + " tarihinde yapılan "+muayeneText+" muayenesi sonucunda ileri tetkik için üst basamak bir sağlık kuruluşunda değerlendirilmsei uygundur.";        
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        if (this.statusNotificationReportFormViewModel.ToState == StatusNotificationReport.StatusNotificationReportStates.Completed) {
            this.btnPrint_Click();
        }
        // this.openDinamicCompFunc(this.statusNotificationReportFormViewModel._StatusNotificationReport.ObjectID, "STATUSNOTIFICATIONREPORT", null);
    }
    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.Description != event) {
                this._StatusNotificationReport.Description = event;
            }
        }
    }

    public ontxtRaporSuresiChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.ReportDuration != event) {
                this._StatusNotificationReport.ReportDuration = event;

                let thisdate: Date = new Date();
                thisdate = this.statusNotificationReportFormViewModel._StatusNotificationReport.StartDate;
                if (this._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.DayPeriod) {
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = thisdate.AddDays(parseInt(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration.toString()));
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(-1);
                }
                if (this._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.MonthPeriod) {
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = thisdate.AddMonths(parseInt(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration.toString()));
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(-1);
                }
                if (this._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.YearPeriod) {
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = thisdate.AddYears(parseInt(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration.toString()));
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(-1);
                }
                if (this._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.WeekPeriod) {
                    let gun: number = parseInt(this.statusNotificationReportFormViewModel._StatusNotificationReport.ReportDuration.toString()) * 7;
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = thisdate.AddDays(gun);
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate.AddDays(-1);
                }
                if (this._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.Undefinite || this._StatusNotificationReport.ReportDurationType == PeriodUnitTypeWithUndefiniteEnum.StillContinue) {
                    this.statusNotificationReportFormViewModel._StatusNotificationReport.EndDate = null;
                }
            }
            this.updateDecisionValues();
        }
    }

    public onEndDateChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.EndDate != event) {
                this._StatusNotificationReport.EndDate = event;
            }
        }
    }

    public onReportReasonChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.ReportReason != event) {
                this._StatusNotificationReport.ReportReason = event;
                this.StatusNotificationOneDocReportUpdateDecisionField();
            }
        }
    }

    public changeDecisionVisible() {
        if (this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "3ad998b1-111a-4e18-82b8-b21305f0f504" ||
            this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "ec2bbc8c-5c50-4382-b028-e34542897d90" ||
            this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "8e1b2ff0-633a-4cb2-ba13-5ad04e4e402a" ||
            this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "8acf6a3d-6a37-476e-835c-5a2b504ba0da") {
            this.restReportDecisionVisible = true;
            this.defaultDecisionVisible = false;
            this.statusNotificationOneDoctorDecisionVisible = false;
            this.RestReportUpdateDecisionField();
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Appropriate == null || this.statusNotificationReportFormViewModel._StatusNotificationReport.InAppropriate == null)
                this.statusNotificationReportFormViewModel._StatusNotificationReport.Appropriate = true;
        } else if (this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "402650d7-d53d-4855-82b5-ac0a7520d9e0" ||
            this._StatusNotificationReport.HCRequestReason.ObjectID.toString() == "f9b7c97b-073c-4f14-a3d2-db4e73bafe8f") {
            this.restReportDecisionVisible = false;
            this.defaultDecisionVisible = false;
            this.statusNotificationOneDoctorDecisionVisible = true;
            this.StatusNotificationOneDocReportUpdateDecisionField();
            if (this.statusNotificationReportFormViewModel._StatusNotificationReport.Appropriate == null || this.statusNotificationReportFormViewModel._StatusNotificationReport.InAppropriate == null)
                this.statusNotificationReportFormViewModel._StatusNotificationReport.Appropriate = true;
        } else {
            this.restReportDecisionVisible = false;
            this.defaultDecisionVisible = true;
            this.statusNotificationOneDoctorDecisionVisible = false;
            this.statusNotificationReportFormViewModel._StatusNotificationReport.Appropriate = null;
            this.statusNotificationReportFormViewModel._StatusNotificationReport.InAppropriate = null;
        }
    }

    public onHCRequestReasonChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.HCRequestReason != event) {
                this._StatusNotificationReport.HCRequestReason = event;
                this.changeDecisionVisible();
            }
        }
        this.HCRequestReason_SelectedObjectChanged();
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.MasterResource != event) {
                this._StatusNotificationReport.MasterResource = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.ProcedureDoctor != event) {
                this._StatusNotificationReport.ProcedureDoctor = event;
            }

            if (this._StatusNotificationReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._StatusNotificationReport.ProcedureDoctor.ObjectID, this._StatusNotificationReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._StatusNotificationReport.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._StatusNotificationReport.ProcedureDoctor = null;
                    }, 500);
                }
            }
        }
    }

    public onReasonForExaminationHCRequestReasonChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null &&
                this._StatusNotificationReport.HCRequestReason != null && this._StatusNotificationReport.HCRequestReason.ReasonForExamination != event) {
                this._StatusNotificationReport.HCRequestReason.ReasonForExamination = event;
            }
        }
    }

    public onReportDecisionChanged(event): void {

        if (this._StatusNotificationReport != null && this._StatusNotificationReport.ReportDecision != event) {
            this._StatusNotificationReport.ReportDecision = event;
            this.StatusNotificationOneDocReportUpdateDecisionField();
        }
    }


    public onReportDescriptionChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.ReportDescription != event) {
                this._StatusNotificationReport.ReportDescription = event;
            }
        }
    }

    public onDiagnosisDetailChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.DiagnosisDetail != event) {
                this._StatusNotificationReport.DiagnosisDetail = event;
            }
        }
    }

    public onReportNoChanged(event): void {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.ReportNo != event) {
                this._StatusNotificationReport.ReportNo = event;
            }
        }
    }

    public async onSecondDoctorChanged(event) {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.SecondDoctor != event) {
                this._StatusNotificationReport.SecondDoctor = event;
            }

            if (this._StatusNotificationReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._StatusNotificationReport.SecondDoctor.ObjectID, this._StatusNotificationReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._StatusNotificationReport.SecondDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._StatusNotificationReport.SecondDoctor = null;
                    }, 500);
                }
            }
        }
    }

    public updateDecisionValues() {
        if (this.restReportDecisionVisible == true) {
            this.RestReportUpdateDecisionField();
        } else if (this.statusNotificationOneDoctorDecisionVisible == true) {
            this.StatusNotificationOneDocReportUpdateDecisionField();
        }
    }

    public async onStartDateChanged(event) {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.StartDate != event) {
                this._StatusNotificationReport.StartDate = event;
                this.updateDecisionValues();
            }

            if (this._StatusNotificationReport.ProcedureDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._StatusNotificationReport.ProcedureDoctor.ObjectID, this._StatusNotificationReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._StatusNotificationReport.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._StatusNotificationReport.ProcedureDoctor = null;
                    }, 500);
                }
            }

            if (this._StatusNotificationReport.SecondDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._StatusNotificationReport.SecondDoctor.ObjectID, this._StatusNotificationReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._StatusNotificationReport.SecondDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._StatusNotificationReport.SecondDoctor = null;
                    }, 500);
                }
            }

            if (this._StatusNotificationReport.ThirdDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._StatusNotificationReport.ThirdDoctor.ObjectID, this._StatusNotificationReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._StatusNotificationReport.ThirdDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._StatusNotificationReport.ThirdDoctor = null;
                    }, 500);
                }
            }
        }
    }

    public async onThirdDoctorChanged(event) {
        if (event != null) {
            if (this._StatusNotificationReport != null && this._StatusNotificationReport.ThirdDoctor != event) {
                this._StatusNotificationReport.ThirdDoctor = event;
            }

            if (this._StatusNotificationReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._StatusNotificationReport.ThirdDoctor.ObjectID, this._StatusNotificationReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._StatusNotificationReport.ThirdDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._StatusNotificationReport.ThirdDoctor = null;
                    }, 500);
                }
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ReportNo, "Text", this.__ttObject, "ReportNo");
        redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.ReportDecision, "Rtf", this.__ttObject, "ReportDecision");
        redirectProperty(this.CommitteeReport, "Value", this.__ttObject, "CommitteeReport");
        redirectProperty(this.Appropriate, "Value", this.__ttObject, "Appropriate");
        redirectProperty(this.InAppropriate, "Value", this.__ttObject, "InAppropriate");
        redirectProperty(this.ReportDescription, "Text", this.__ttObject, "ReportDescription");
        redirectProperty(this.DiagnosisDetail, "Text", this.__ttObject, "DiagnosisDetail");
        redirectProperty(this.ReportReason, "Value", this.__ttObject, "ReportReason");
    }

    public initFormControls(): void {

        this.ReportReason = new TTVisual.TTEnumComboBox();
        this.ReportReason.DataTypeName = "StatusNotificationReasonEnum";
        this.ReportReason.Name = "ReportReason";
        this.ReportReason.TabIndex = 29;

        this.CommitteeReport = new TTVisual.TTCheckBox();
        this.CommitteeReport.Value = false;
        //this.CommitteeReport.Title = i18n("M15765", "Heyet");
        this.CommitteeReport.Name = "CommitteeReport";
        this.CommitteeReport.TabIndex = 26;
        this.CommitteeReport.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.Appropriate = new TTVisual.TTCheckBox();
        this.Appropriate.Value = true;
        //this.CommitteeReport.Title = i18n("M15765", "Heyet");
        this.Appropriate.Name = "Appropriate";
        this.Appropriate.TabIndex = 26;
        this.Appropriate.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.InAppropriate = new TTVisual.TTCheckBox();
        this.InAppropriate.Value = false;
        //this.CommitteeReport.Title = i18n("M15765", "Heyet");
        this.InAppropriate.Name = "InAppropriate";
        this.InAppropriate.TabIndex = 26;
        this.InAppropriate.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.labelThirdDoctor = new TTVisual.TTLabel();
        this.labelThirdDoctor.Text = i18n("M10289", "3.Doktor");
        this.labelThirdDoctor.Name = "labelThirdDoctor";
        this.labelThirdDoctor.TabIndex = 25;

        this.ThirdDoctor = new TTVisual.TTObjectListBox();
        this.ThirdDoctor.ListDefName = "DoctorListDefinition";
        this.ThirdDoctor.Name = "ThirdDoctor";
        this.ThirdDoctor.TabIndex = 24;
        this.ThirdDoctor.Visible = true;
        this.ThirdDoctor.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.labelSecondDoctor = new TTVisual.TTLabel();
        this.labelSecondDoctor.Text = i18n("M10220", "2.Doktor");
        this.labelSecondDoctor.Name = "labelSecondDoctor";
        this.labelSecondDoctor.TabIndex = 23;

        this.SecondDoctor = new TTVisual.TTObjectListBox();
        this.SecondDoctor.ListDefName = "DoctorListDefinition";
        this.SecondDoctor.Name = "SecondDoctor";
        this.SecondDoctor.TabIndex = 22;
        this.SecondDoctor.Visible = true;
        this.SecondDoctor.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.labelMasterResource = new TTVisual.TTLabel();
        this.labelMasterResource.Text = i18n("M15565", "Havale Edilen Birim");
        this.labelMasterResource.Name = "labelMasterResource";
        this.labelMasterResource.TabIndex = 21;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.ListDefName = "ResourceListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 20;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16928", "İşlemi Yapan Doktor");
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 19;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;
        this.ProcedureDoctor.ListDefName = "DoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 18;

        this.labelReasonForExaminationHCRequestReason = new TTVisual.TTLabel();
        this.labelReasonForExaminationHCRequestReason.Text = i18n("M20869", "Rapor Türü");
        this.labelReasonForExaminationHCRequestReason.Name = "labelReasonForExaminationHCRequestReason";
        this.labelReasonForExaminationHCRequestReason.TabIndex = 15;

        this.ReasonForExaminationHCRequestReason = new TTVisual.TTObjectListBox();
        this.ReasonForExaminationHCRequestReason.ReadOnly = true;
        this.ReasonForExaminationHCRequestReason.ListDefName = "HealthCommitteeExaminationReasonListDefinition";
        this.ReasonForExaminationHCRequestReason.Name = "ReasonForExaminationHCRequestReason";
        this.ReasonForExaminationHCRequestReason.TabIndex = 14;

        this.labelHCRequestReason = new TTVisual.TTLabel();
        this.labelHCRequestReason.Text = i18n("M16646", "İstek Sebebi");
        this.labelHCRequestReason.Name = "labelHCRequestReason";
        this.labelHCRequestReason.TabIndex = 13;

        this.HCRequestReason = new TTVisual.TTObjectListBox();
        this.HCRequestReason.ListDefName = "HCRequestReasonListDefinition";
        this.HCRequestReason.ListFilterExpression = "ReasonForExamination.HCREPORTTYPEDEFINITION.IsStatusNotification = 1 AND ISACTIVE IS NULL";
        this.HCRequestReason.Name = "HCRequestReason";
        this.HCRequestReason.TabIndex = 12;
        this.HCRequestReason.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 11;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Short;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 10;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = i18n("M11637", "Başlangıç Tarihi");
        this.labelStartDate.Name = "labelStartDate";
        this.labelStartDate.TabIndex = 9;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.Format = DateTimePickerFormat.Short;
        this.StartDate.Name = "StartDate";
        this.StartDate.TabIndex = 8;
        this.StartDate.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.labelReportNo = new TTVisual.TTLabel();
        this.labelReportNo.Text = i18n("M20824", "Rapor Numarası");
        this.labelReportNo.Name = "labelReportNo";
        this.labelReportNo.TabIndex = 7;

        this.ReportNo = new TTVisual.TTTextBox();
        this.ReportNo.Name = "ReportNo";
        this.ReportNo.TabIndex = 6;
        this.ReportNo.ReadOnly = true;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;
        this.Description.Height = "100px";
        this.Description.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.ReportDescription = new TTVisual.TTTextBox();
        this.ReportDescription.Multiline = true;
        this.ReportDescription.Name = "ReportDescription";
        this.ReportDescription.TabIndex = 0;
        this.ReportDescription.Height = "100px";
        this.ReportDescription.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.DiagnosisDetail = new TTVisual.TTTextBox();
        this.DiagnosisDetail.Multiline = true;
        this.DiagnosisDetail.Name = "DiagnosisDetail";
        this.DiagnosisDetail.TabIndex = 0;
        this.DiagnosisDetail.Height = "100px";
        this.DiagnosisDetail.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.txtRaporSuresi = new TTVisual.TTTextBox();
        this.txtRaporSuresi.Multiline = false;
        this.txtRaporSuresi.Name = "txtRaporSuresi";
        this.txtRaporSuresi.TabIndex = 0;
        this.txtRaporSuresi.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.labelReportDecision = new TTVisual.TTLabel();
        this.labelReportDecision.Text = i18n("M17270", "Karar");
        this.labelReportDecision.Name = "labelReportDecision";
        this.labelReportDecision.TabIndex = 5;

        this.ReportDecision = new TTVisual.TTRichTextBoxControl();
        this.ReportDecision.Name = "ReportDecision";
        this.ReportDecision.TabIndex = 4;
        this.ReportDecision.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = i18n("M11939", "Bitiş Tarihi");
        this.labelEndDate.Name = "labelEndDate";
        this.labelEndDate.TabIndex = 3;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.Format = DateTimePickerFormat.Short;
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 2;
        this.EndDate.Enabled = false;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 1;

        this.cmbRaporSureTuru = new TTVisual.TTEnumComboBox();
        this.cmbRaporSureTuru.DataTypeName = "PeriodUnitTypeWithUndefiniteEnum";
        this.cmbRaporSureTuru.Required = true;
        this.cmbRaporSureTuru.Name = "cmbRaporSureTuru";
        this.cmbRaporSureTuru.TabIndex = 4;
        this.cmbRaporSureTuru.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.Complaint = new TTVisual.TTTextBox();
        this.Complaint.Multiline = true;
        this.Complaint.Name = "Complaint";
        this.Complaint.TabIndex = 0;
        this.Complaint.Height = "100px";
        this.Complaint.ReadOnly = true;

        this.MTSConclusion = new TTVisual.TTTextBox();
        this.MTSConclusion.Multiline = true;
        this.MTSConclusion.Name = "MTSConclusion";
        this.MTSConclusion.TabIndex = 0;
        this.MTSConclusion.Height = "100px";
        this.MTSConclusion.ReadOnly = true;

        this.PhysicalExamination = new TTVisual.TTTextBox();
        this.PhysicalExamination.Multiline = true;
        this.PhysicalExamination.Name = "PhysicalExamination";
        this.PhysicalExamination.TabIndex = 0;
        this.PhysicalExamination.Height = "100px";
        this.PhysicalExamination.ReadOnly = true;

        this.PatientHistory = new TTVisual.TTTextBox();
        this.PatientHistory.Multiline = true;
        this.PatientHistory.Name = "PatientHistory";
        this.PatientHistory.TabIndex = 0;
        this.PatientHistory.Height = "100px";
        this.PatientHistory.ReadOnly = true;

        this.complaintSelected = new TTVisual.TTCheckBox();
        this.complaintSelected.Value = false;
        this.complaintSelected.Title = "";
        this.complaintSelected.Name = "complaintSelected";
        this.complaintSelected.TabIndex = 3;
        this.complaintSelected.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.historySelected = new TTVisual.TTCheckBox();
        this.historySelected.Value = false;
        this.historySelected.Title = "";
        this.historySelected.Name = "historySelected";
        this.historySelected.TabIndex = 3;
        this.historySelected.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.MTSConclusionSelected = new TTVisual.TTCheckBox();
        this.MTSConclusionSelected.Value = false;
        this.MTSConclusionSelected.Title = "";
        this.MTSConclusionSelected.Name = "MTSConclusionSelected";
        this.MTSConclusionSelected.TabIndex = 3;
        this.MTSConclusionSelected.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.physicalExaminationSelected = new TTVisual.TTCheckBox();
        this.physicalExaminationSelected.Value = false;
        this.physicalExaminationSelected.Title = "";
        this.physicalExaminationSelected.Name = "physicalExaminationSelected";
        this.physicalExaminationSelected.TabIndex = 3;
        this.physicalExaminationSelected.ReadOnly = this.statusNotificationReportFormViewModel.ReadOnly;

        this.Controls = [this.ReportReason, this.CommitteeReport, this.Appropriate, this.InAppropriate, this.historySelected, this.DiagnosisDetail, this.physicalExaminationSelected, this.MTSConclusionSelected, this.complaintSelected, this.labelThirdDoctor, this.ThirdDoctor, this.labelSecondDoctor, this.SecondDoctor, this.labelMasterResource, this.MasterResource, this.labelProcedureDoctor, this.ProcedureDoctor, this.labelReasonForExaminationHCRequestReason, this.ReasonForExaminationHCRequestReason, this.labelHCRequestReason, this.HCRequestReason, this.labelActionDate, this.ActionDate, this.labelStartDate, this.StartDate, this.labelReportNo, this.ReportNo, this.Description, this.labelReportDecision, this.ReportDecision, this.labelEndDate, this.EndDate, this.labelDescription, this.ReportDescription];

    }


}
