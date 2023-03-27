//$872083CB
import { Component, OnInit, NgZone, EventEmitter, OnDestroy } from '@angular/core';
import { DentalExaminationFormViewModel } from './DentalExaminationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DentalCommitment, DisDurumEnum, ToothNumberEnum, ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { BaseDentalEpisodeActionForm } from 'Modules/Tibbi_Surec/Dis_Muayene_Modulu/BaseDentalEpisodeActionForm';
import { DentalConsultationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { DentalExamination, MedicalStuffReport } from 'NebulaClient/Model/AtlasClientModel';
import { DentalExaminationSuggestedProsthesis } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisRequestSuggestedProsthesis } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SubActionProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from 'ObjectClassService/SystemParameterService';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BaseDentalEpisodeActionDiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SortByEnum } from 'NebulaClient/Utils/Enums/SortByEnum';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { DentalExaminationService, AddDentalProcedures_Output, GetDepartment_Output, CalcPatientPrice_Output } from 'ObjectClassService/DentalExaminationService';
import DataSource from 'devextreme/data/data_source';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DentalExaminationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroduction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionService, OldDrugOrderIntroduction } from 'ObjectClassService/DrugOrderIntroductionService';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { PatientExaminationService } from 'ObjectClassService/PatientExaminationService';

import { PatientReportInfo, NewConsultationRequestInfo } from '../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel';
import { ReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ParticipatnFreeDrugReport } from 'NebulaClient/Model/AtlasClientModel';
import { StatusNotificationReport } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaTreatmentReport, Consultation, PatientInterviewForm, ConsultationFromExternalHospital } from 'NebulaClient/Model/AtlasClientModel';
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { vmProcedureRequestFormDefinition, DailyProvisionInputModel } from "Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import {
    OpenColorPrescription_Input
} from 'ObjectClassService/DrugOrderIntroductionService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { Subscription } from 'rxjs';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { EpisodeActionService } from 'app/NebulaClient/Services/ObjectService/EpisodeActionService';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import List from 'app/NebulaClient/System/Collections/List';
import { DailyInpatientInfoModel } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel';
import { DispatchToOtherHospitalComponentInfoViewModel } from 'Modules/Tibbi_Surec/XXXXXXler_Arasi_Sevk_Modulu/DispatchToOtherHospitalFormViewModel';
import { DispatchToOtherHospitalForm } from '../XXXXXXler_Arasi_Sevk_Modulu/DispatchToOtherHospitalForm';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';

@Component({
    selector: 'DentalExaminationForm',
    templateUrl: './DentalExaminationForm.html',
    providers: [MessageService, NqlQueryService]
})
export class DentalExaminationForm extends BaseDentalEpisodeActionForm implements OnInit, OnDestroy, IDestroyEvent {

    OnDestroy: EventEmitter<any> = new EventEmitter<any>();
    ReportParamActiveIDsModel: ActiveIDsModel;

    ActionDate: TTVisual.ITTDateTimePickerColumn;
    AddToHistory: TTVisual.ITTCheckBoxColumn;
    Amount: TTVisual.ITTTextBoxColumn;
    Anomali: TTVisual.ITTCheckBoxColumn;
    AyniFarkliKesi: TTVisual.ITTListBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    btnNewTreatmentDischarge: TTVisual.ITTButton;
    ch1: TTVisual.ITTCheckBox;
    ch2: TTVisual.ITTCheckBox;
    ch3: TTVisual.ITTCheckBox;
    ch4: TTVisual.ITTCheckBox;
    ch5: TTVisual.ITTCheckBox;
    ch6: TTVisual.ITTCheckBox;
    ch7: TTVisual.ITTCheckBox;
    cmbTriajCode: TTVisual.ITTEnumComboBox;
    CokluOzelDurum: TTVisual.ITTButtonColumn;
    cokluOzelDurumColumn: TTVisual.ITTListBoxColumn;
    columnHastaOdeme: TTVisual.ITTCheckBoxColumn;
    columnHizmetKaydedildi: TTVisual.ITTCheckBoxColumn;
    CurrentState: TTVisual.ITTEnumComboBox;
    ProsthesisDepartment: TTVisual.ITTObjectListBox;
    DentalConsultation: TTVisual.ITTGrid;
    DentalExaminationFile1: TTVisual.ITTRichTextBoxControl;
    DentalProcessNew: TTVisual.ITTGrid;
    DentalProsthesis: TTVisual.ITTGrid;
    Diagnose: TTVisual.ITTListBoxColumn;
    DiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    DiagnosisGrid: TTVisual.ITTGrid;
    DisKonsultasyonIstek: TTVisual.ITTTabPage;
    DistributionType: TTVisual.ITTButtonColumn;
    Doctor: TTVisual.ITTObjectListBox;
    Emergency: TTVisual.ITTCheckBox;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosis: TTVisual.ITTTabPage;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    Examination: TTVisual.ITTTabPage;
    ExaminationDateTime: TTVisual.ITTDateTimePickerColumn;
    ExaminationIndication: TTVisual.ITTTextBoxColumn;
    GridDiagnosisEntry: TTVisual.ITTTabPage;
    IsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    Kdv: TTVisual.ITTTextBoxColumn;
    KodsuzMalzemeFiyati: TTVisual.ITTTextBoxColumn;
    KonsultasyonIstekAciklamasi: TTVisual.ITTTextBoxColumn;
    KonsultasyonIstenenBirim: TTVisual.ITTListBoxColumn;
    labelDrAnesteziTescilNo: TTVisual.ITTLabel;
    labelOzelDurum: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelTriajCode: TTVisual.ITTLabel;
    MalzemeBrans: TTVisual.ITTTextBoxColumn;
    MalzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    MalzemeTuru: TTVisual.ITTListBoxColumn;
    MasterResource: TTVisual.ITTObjectListBox;
    Material: TTVisual.ITTListBoxColumn;
    MedulaBilgileri: TTVisual.ITTTabPage;
    MedulaDisBilgileriTab: TTVisual.ITTTabPage;
    Mustehaklik: TTVisual.ITTButtonColumn;
    Note: TTVisual.ITTTextBoxColumn;
    OldDentalExaminationsGrid: TTVisual.ITTGrid;
    OlduExaminations: TTVisual.ITTTabPage;
    OnerilenIslemler: TTVisual.ITTTabPage;
    OzelDurum: TTVisual.ITTListBoxColumn;
    PatientPrice: TTVisual.ITTTextBoxColumn;
    private disMuayene: string = '';
    private OldDentalExaminationsGridFilled: boolean = false;
    // private rowTable: Dictionary<string, ITTGridRow> = new Dictionary<string, ITTGridRow>();
    //private selectedCheckboxes: Array<TTCheckBox> = new Array<TTCheckBox>();
    cmbReportType: TTVisual.ITTEnumComboBox;
    txtReportName: TTVisual.TTTextBoxColumn;
    txtStartDate: TTVisual.TTTextBoxColumn;
    txtEndDate: TTVisual.TTTextBoxColumn;
    btnEdit: TTVisual.TTButtonColumn;
    GridPatientReportsColumns = [];
    ExaminationProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureDoctor: TTVisual.ITTListBoxColumn;
    ProcedureEntry: TTVisual.ITTTabPage;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ProcessTime: TTVisual.ITTDateTimePicker;
    ProdecureObject: TTVisual.ITTListBoxColumn;
    ProsthesisToothNum: TTVisual.ITTEnumComboBoxColumn;
    ProtocolNo: TTVisual.ITTTextBox;
    ResponsibleUser: TTVisual.ITTListBoxColumn;
    SecDiagnosisGrid: TTVisual.ITTGrid;
    SecToothNum: TTVisual.ITTEnumComboBoxColumn;
    SelectedToothNumbers: TTVisual.ITTTextBoxColumn;
    SUGGESTEDPROSTHESISPROCEDURE: TTVisual.ITTObjectListBox;
    TabExaminationType: TTVisual.ITTTabControl;
    TeethMasterResource: TTVisual.ITTListBoxColumn;
    TreatmentMatEnrty: TTVisual.ITTTabPage;
    TriajColor: TTVisual.ITTTextBox;
    ttbutton3: TTVisual.ITTButton;
    ttbuttonBiyokimya: TTVisual.ITTButton;
    ttButtonHizmetKontrol: TTVisual.ITTButton;
    ttbuttonMikrobiyoloji: TTVisual.ITTButton;
    ttButtonOrtodontiForm: TTVisual.ITTButton;
    ttbuttonPatoloji: TTVisual.ITTButton;
    ttbuttonPrescription: TTVisual.ITTButton;
    ttbuttonRadyoloji: TTVisual.ITTButton;
    ttButtonTaahhut: TTVisual.ITTButton;
    ttbuttonTemizle: TTVisual.ITTButton;
    ttbuttonTopluIslemTamamla: TTVisual.ITTButton;
    ttcheckboxcolumn1: TTVisual.ITTCheckBoxColumn;
    ttChkBoxGeneralAnesthesia: TTVisual.ITTCheckBox;
    ttdatetimepickercolumn1: TTVisual.ITTDateTimePickerColumn;
    ProsthesisToothNumber: TTVisual.ITTEnumComboBox;
    ttgrid1: TTVisual.ITTGrid;
    ttgrid3: TTVisual.ITTGrid;
    ttlabel11: TTVisual.ITTLabel;
    TTListBoxDrAnesteziTescilNo: TTVisual.ITTObjectListBox;
    ttlistviewDentalSpecialityList: TTVisual.ITTListView;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttextboxcolumn1: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn2: TTVisual.ITTTextBoxColumn;
    UBBCODE: TTVisual.ITTTextBoxColumn;
    UsedMaterials: TTVisual.ITTGrid;
    UsedMaterials_OzelDurum: TTVisual.ITTListBoxColumn;
    ActivePage: string = "muayene";
    RecentActiveTab: string;
    dentalProcedure: any;
    selectedDentalProcedure: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    PrescriptionGrid: TTVisual.ITTGrid;
    PhysicianDrug: TTVisual.ITTListBoxColumn;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    Day: TTVisual.ITTTextBoxColumn;
    DrugUsageType: TTVisual.ITTEnumComboBoxColumn;
    UsageNote: TTVisual.ITTTextBoxColumn;


    txtReportRequestReason: TTVisual.TTTextBoxColumn;
    txtReportAdmissionDate: TTVisual.TTTextBoxColumn;
    txtReportMasterResource: TTVisual.TTTextBoxColumn;



    //Konsültasyon

    RequesterDoctor: TTVisual.ITTObjectListBox;
    FromResource: TTVisual.ITTObjectListBox;
    RequestDescription: TTVisual.ITTRichTextBoxControl;
    RequestDate: TTVisual.ITTDateTimePicker;
    //ActionDate
    ConsultationResultAndOffers: TTVisual.ITTRichTextBoxControl;

    public enablePrescriptionTab: boolean;

    public isConsultation: boolean = false;
    public hasSpecialityBasedObject: boolean = false;
    public hasEmergencySpecialityBasedObject: boolean = true;

    public PrescriptionGridColumns = [];
    public PrescriptionList: Array<OldDrugOrderIntroduction> = new Array<OldDrugOrderIntroduction>();
    private checkList: Array<string> = new Array<string>();
    private checkValues: Array<boolean> = new Array<boolean>();
    public DentalConsultationColumns = [];
    public DentalProcessNewColumns = [];
    public DentalProsthesisColumns = [];
    public DiagnosisGridColumns = [];
    public OldDentalExaminationsGridColumns = [];
    public SecDiagnosisGridColumns = [];
    public ttgrid1Columns = [];
    public ttgrid3Columns = [];
    public dentalProsthesisesColumns = [];
    public UsedMaterialsColumns = [];
    showNabizPopup = false;
    private _eNabizViewModels: Array<any> = [];
    showStatusNotificationReportForm = false;
    showMedulaTedaviRaporlariForm = false;
    showParticipationFreeDrugReportNewForm = false;
    public statusNotificationReportObject = new StatusNotificationReport;
    public ParticipationFreeDrugReportNewFormObject = new ParticipatnFreeDrugReport;
    public medulaTedaviRaporlariObject = new MedulaTreatmentReport;
    public currentActionReports: boolean = false;
    isSaveAndCancelCommandVisible: boolean = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    private dentalCommitmentObjectSubscription: Subscription;

    panelMessage: string = "Günübirlik Yatış İşlemleri Yapılıyor Lütfen Bekleyiniz";

    public reportTypeList: Array<EnumItem>;
    public selectedReportType: EnumItem;
    private refreshReportGridSubscription: Subscription;

    public showEDurumBildirirComponent = false;

    public dentalExaminationFormViewModel: DentalExaminationFormViewModel = new DentalExaminationFormViewModel();
    public get _DentalExamination(): DentalExamination {
        return this._TTObject as DentalExamination;
    }
    private DentalExaminationForm_DocumentUrl: string = '/api/DentalExaminationService/DentalExaminationForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected tabService: IActiveTabService,
        private objectContextService: ObjectContextService,
        protected modalService: IModalService,
        private sideBarMenuService: ISidebarMenuService,
        private reportService: AtlasReportService,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DentalExaminationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.checkValues = Array.apply(null, Array(58)).map(Boolean.prototype.valueOf, false);
        this.selectedDentalProcedure = new Array<ProcedureDefinition>();
        this.dentalCommitmentObjectSubscription = this.httpService.dentalCommitmentFormSharedService.dentalCommitmentObjectObservable.subscribe(
            dentalCommitmentObjectObservable => {
                if (this.dentalExaminationFormViewModel._DentalExamination.DentalCommitment == null || this.dentalExaminationFormViewModel._DentalExamination.DentalCommitment == undefined) {
                    this.dentalExaminationFormViewModel._DentalExamination.DentalCommitment = dentalCommitmentObjectObservable as DentalCommitment;
                }
            }
        );
        this.reportTypeList = ReportTypeEnum.Items;

    }

    public loadLabGridColumns() {
        this.dentalProsthesisesColumns = [
            {
                "caption": "İşlem Tarihi",
                cellTemplate: 'actionDateTemplate',
                //dataField: "ActionDate",
                width: '130'

            },
            {
                "caption": "Acil",
                dataField: "Emergency",
                dataType: "boolean",
                width: 80,
                allowEditing: true,
                fixed: true
            },
            {
                caption: 'Önerilen Diş Protez',
                //dataField: 'ProcedureObject',
                cellTemplate: 'lstBoxProcedureObject',
                width: '250'
            },

            {
                caption: "Durum",
                //dataField: 'CurrentState',
                cellTemplate: 'currentStateTemplate',
                //allowEditing: true,
                width: 175,
                //lookup: { dataSource: DisDurumEnum.Items, valueExpr: "ordinal", displayExpr: "description" },
            },
            {
                caption: "Diş Nu./Ağız Bölgesi",
                cellTemplate: 'toothNumberTemplate',
                //dataField: 'ToothNumber',
                //allowEditing: true,
                width: 125,
                //lookup: { dataSource: ToothNumberEnum.Items, valueExpr: "ordinal", displayExpr: "description" },
            },
            {
                caption: 'Protez Birimi',
                //dataField: 'ProcedureObject',
                cellTemplate: 'lstBoxResourceObject',
                width: 200
            },
            {
                caption: 'Açıklama',
                //dataField: 'ProcedureObject',
                cellTemplate: 'descriptionTemplate',
                width: 150
            },
            {
                caption: 'Renk',
                //dataField: 'ProcedureObject',
                cellTemplate: 'colorTemplate',
                width: 100
            }
        ];
    }



    TabPanelClick(source) {
        this.tabService.setActiveTab(source, 'pedfn');
        this.RecentActiveTab = source;
    }


    ActiveAcc: string;
    RecentAcc: string;

    AccPinClick(acc) {
        this.tabService.setActiveTab(acc, 'pedfnacc');
        this.RecentAcc = acc;
    }


    isLabIslemleri: any = false;
    isKonsultasyon: any = false;
    isMlzSarf: any = false;
    isRecete: any = false;
    isRaporlar: any = false;
    isSevk: any = false;

    selectTab(e) {
        let selectedItem: string = e.addedItems[0].title;
        if (selectedItem == i18n("M17742", "Konsültasyon")) {
            this.isKonsultasyon = true;
        }
        if (selectedItem == i18n("M20924", "Reçete")) {
            this.isRecete = true;
        }
        if (selectedItem == i18n("M19108", "Mlz.Sarf")) {
            this.isMlzSarf = true;
        }
        if (selectedItem == i18n("M18144", "Lab İşlemleri")) {
            this.isLabIslemleri = true;
        }
        if (selectedItem == i18n("M20887", "Raporlar")) {
            this.isRaporlar = true;
        }
        if (selectedItem == i18n("M21695", "Sevk")) {
            this.isSevk = true;
        }
    }

    public saveDispatchComponent: boolean = true;
    public dispatchComponentInfo: DynamicComponentInfo;
    public dispatchQueryParameters: QueryParams;

    protected getComponentInfo() {
        let componentInfoViewModel: DispatchToOtherHospitalComponentInfoViewModel = DispatchToOtherHospitalForm.getComponentInfoViewModel(this.dentalExaminationFormViewModel._DentalExamination.ObjectID, this.dentalExaminationFormViewModel._DentalExamination.Episode.ObjectID, this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient.ObjectID, "examination");
        this.dispatchQueryParameters = componentInfoViewModel.dispatchQueryParameters;
        this.dispatchComponentInfo = componentInfoViewModel.dispatchComponentInfo;

    }

    dispatchQueryResultLoaded(e: any) {
        DispatchToOtherHospitalForm.dispatchQueryResultLoaded(e);
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public isEmergencyIntervention(): Number {
        if (this._DentalExamination == null) {
            return 0;
        }
        /*if (this._DentalExamination.EmergencyIntervention == null) {
            return 0;
        }
        if (this._DentalExamination.EmergencyIntervention != null) {
            return 1;
        }*/
        return 0;

    }


    public setPatientHistoryShown(episodeActionId: Guid) {
        let that = this;
        that.httpService.get<any>("api/PatientHistoryService/SetPatientHistoryShown?episodeActionId=" + episodeActionId)
            .then(response => {
            })
            .catch(error => {
            });
    }

    public openIstemTab: boolean = false;
    openIstem() {
        this.openIstemTab = true;
    }

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;

        this.setPatientHistoryShown(this.dentalExaminationFormViewModel._DentalExamination.ObjectID);
    }

    public openUzmanlikTab: boolean = false;
    public openUzmanlik() {
        this.openUzmanlikTab = true;
    }

    searchProcedure(e) {
        this.dentalProcedure.searchValue(e.value);
        this.dentalProcedure.load();
    }

    optionChanged(e: string) {
        if (e.substr(0, 1) === '+') {
            let item = e.substr(1, e.length - 1);
            let foundItem = this.checkList.find(x => x === item);
            if (!foundItem) {
                this.checkList.push(item);
            }
        } else if (e.substr(0, 1) === '-') {
            let item = e.substr(1, e.length - 1);
            let foundItem = this.checkList.find(x => x === item);
            if (foundItem) {
                let index = this.checkList.indexOf(item);
                this.checkList.splice(index, 1);
            }
        }
    }

    async GridPatientReports_CellContentClicked(data: any) {
        let that = this;
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this.dentalExaminationFormViewModel._DentalExamination.ObjectID, this.dentalExaminationFormViewModel._DentalExamination.Episode.ObjectID, this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient.ObjectID);

        if (this.ReadOnly != true) {
            if (data.Column.Name == "btnEdit") {
                if (data.Row != null) {
                    if (data.Row.TTObject != null) {
                        let patientReportGrid = data.Row.TTObject;
                        if (patientReportGrid.ObjectID != null && patientReportGrid.ObjectDefName != null) {
                            if (patientReportGrid.ObjectDefName == "PARTICIPATNFREEDRUGREPORT")
                                this.onParticipatientReportOpen(patientReportGrid.ObjectID);
                            if (patientReportGrid.ObjectDefName == "STATUSNOTIFICATIONREPORT")
                                this.onStatusNotificationReportOpen(patientReportGrid.ObjectID);
                            if (patientReportGrid.ObjectDefName == "MEDULATREATMENTREPORT")
                                this.onMedulaTreatmentReportOpen(patientReportGrid.ObjectID);
                            if (patientReportGrid.ObjectDefName == "MEDICALSTUFFREPORT")
                                this.onMedicalStuffReportOpen(patientReportGrid.ObjectID);
                        }
                    }
                }
            }

        }
    }

    async onDrugOrderIntruductionOpen(data: any) {

        let subEpisodeID: Guid = <any>this._DentalExamination['SubEpisode'];
        let diagnosisControlResult = await PatientExaminationService.CheckPatientSubEpisodeDiagnosisExistence(subEpisodeID);
        if (diagnosisControlResult === false) {
            ServiceLocator.MessageService.showError('Vakaya, Ön Tanı  girilip kaydedilmeden işleme devam edilemez!');
            return;
        }

        let subEps: SubEpisode = await this.objectContextService.getObject<SubEpisode>(subEpisodeID, SubEpisode.ObjectDefID);
        this.objectContextService.getNewObject<DrugOrderIntroduction>(DrugOrderIntroduction.ObjectDefID, DrugOrderIntroduction).then(result => {
            let drugOrderIntroduction: DrugOrderIntroduction = result;
            drugOrderIntroduction.MasterResource = this._DentalExamination.MasterResource;
            drugOrderIntroduction.SecondaryMasterResource = this._DentalExamination.SecondaryMasterResource;
            drugOrderIntroduction.Episode = this._DentalExamination.Episode;
            drugOrderIntroduction.SubEpisode = subEps;
            drugOrderIntroduction.PatientOwnDrug = false;
            drugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.DrugOrderIntroductionStates.New;
            drugOrderIntroduction.DrugOrderIntroductionDetails = new Array<DrugOrderIntroductionDet>();

            // tslint:disable-next-line:no-shadowed-variable
            this.showDrugOrderIntroduction(drugOrderIntroduction).then(result => {
                DrugOrderIntroductionService.GetOldDrugOrderIntroductions(this._DentalExamination.Episode).then(drugOrderIntDets => {
                    this.PrescriptionList = drugOrderIntDets;
                }).catch(err => {
                    this.messageService.showError(err);
                });
            }).catch(err2 => {
                this.messageService.showError(err2);
            });
        }).catch(err3 => {
            this.messageService.showError(err3);
        });
    }

    private showDrugOrderIntroduction(data: DrugOrderIntroduction): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderIntroductionNewForm';
            componentInfo.ModuleName = 'IlacDirektifiGirisModule';
            componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/IlacDirektifiGirisModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._DentalExamination.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20924", "Reçete");
            modalInfo.Width = 1200;
            modalInfo.Height = 850;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    select(value: any) {

        let objectID: Guid = value.data.ObjectId;
        this.objectContextService.getObject<DrugOrderIntroduction>(objectID, DrugOrderIntroduction.ObjectDefID).then(result => {
            let drugOrderIntroduction: DrugOrderIntroduction = result;
            // tslint:disable-next-line:no-shadowed-variable
            this.showDrugOrderIntroduction(drugOrderIntroduction).then(result => {
                DrugOrderIntroductionService.GetOldDrugOrderIntroductions(this._DentalExamination.Episode).then(drugOrderIntDets => {
                    this.PrescriptionList = drugOrderIntDets;
                }).catch(err => {
                    this.messageService.showError(err);
                });
            }).catch(err2 => {
                this.messageService.showError(err2);
            });
        }).catch(err3 => {
            this.messageService.showError(err3);
        });
    }

    public async btnDentalExaminationSave_Click(event) {
        if (event.component != null) {
            let component = event.component,
                prevClickTime = component.lastClickTime;
            component.lastClickTime = new Date();
            if (prevClickTime && (component.lastClickTime - prevClickTime < 500)) {
                ServiceLocator.MessageService.showInfo("İşleminiz gerçekleştiriliyor, Lütfen Bekleyiniz...");
            }
            else {
                const param = new FormSaveInfo(this._EpisodeAction.ObjectDefID.toString(), false);
                this.DentalExaminationSave(param);
            }
        }
    }

    public async btnDentalExaminationSaveAndClose_Click(event) {
        if (event.component != null) {
            let component = event.component,
                prevClickTime = component.lastClickTime;
            component.lastClickTime = new Date();
            if (prevClickTime && (component.lastClickTime - prevClickTime < 500)) {
                ServiceLocator.MessageService.showInfo("İşleminiz gerçekleştiriliyor, Lütfen Bekleyiniz...");
            }
            else {
                const param = new FormSaveInfo(this._EpisodeAction.ObjectDefID.toString(), true);
                this.DentalExaminationSave(param);
            }
        }
    }

    public async btnDentalExaminationCancel_Click(event) {
        await this.cancel();
    }

    colorPresClick() {
        let input: OpenColorPrescription_Input = new OpenColorPrescription_Input();
        input.SubEpisodeObjectID = new Guid(this._DentalExamination.SubEpisode.toString());
        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSON';
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    async reloadReportList() {
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient + '&subepisodeObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.dentalExaminationFormViewModel.PatientReportInfoList = res;
    }

    private async DentalExaminationSave(saveInfo?: FormSaveInfo) {
        try {
            this.loadPanelOperation(true, 'İşlem kaydediliyor, lütfen bekleyiniz.');
            //if (this.dentalExaminationFormViewModel.DiagnosisGridGridList) {
            //    if (this.dentalExaminationFormViewModel.DiagnosisGridGridList.filter(dr => dr.RemoveSubEpisodeRelation != true).length <= 0) {
            //        throw new TTException(await SystemMessageService.GetMessage(635));
            //    }
            //} else {
            //    throw new TTException(await SystemMessageService.GetMessage(635));
            //}

            await this.CheckIsDiagnosisExists(this.dentalExaminationFormViewModel.DiagnosisGridGridList);

            /*if (this.dentalExaminationFormViewModel._DentalExamination.ProcedureDoctor == null) {
                throw new TTException("Sorumlu doktor seçmeden muayene kaydedemezsiniz.");
            }*/

            if (this.dentalExaminationFormViewModel.ConsultationsHistory != null)
                this.dentalExaminationFormViewModel.ConsultationsHistory.Clear();

            let saveuserOption = await this.requestedProceduresFormInstance.saveProcedureTestFilterUserOption();
            let returnValue: number;
            returnValue = await this.requestedProceduresFormInstance.fireRequestedProceduresActions(this.dentalExaminationFormViewModel._DentalExamination);
            if (returnValue == 0) {
                this.dentalExaminationFormViewModel.createNewProcedure = true;
            }
            /*
            else if (returnValue == 1) {
                await this.save();
            }
            else if (returnValue == 2) {
                throw new TTException("SUT Kural ihlali oldu ve işlemden vazgeçildi!");

            }*/
            if (returnValue != null)
                await this.save(saveInfo);

            this.loadPanelOperation(false, '');

        } catch (err) {
            ServiceLocator.MessageService.showError(err);
            this.loadPanelOperation(false, '');
        }
    }


    // ***** Method declarations start *****

    private async btnNewTreatmentDischarge_Click(): Promise<void> {
        //this.CreateNewTreatmentDischarge();
    }
    private async cmbTriajCode_SelectedIndexChanged(): Promise<void> {/*
        if ((<TTVisual.TTComboBoxItem>((<TTEnumComboBox>this.cmbTriajCode).SelectedItem)).Value !== null) {
            let result: TriajCode = <TriajCode>(<TTVisual.TTComboBoxItem>((<TTEnumComboBox>this.cmbTriajCode).SelectedItem)).Value;
            switch (result) {
                case TriajCode.Red:
                    (<TTVisual.ITTControl>this.TriajColor).BackColor = Color.Red;
                    break;
                case TriajCode.Yellow:
                    (<TTVisual.ITTControl>this.TriajColor).BackColor = Color.Yellow;
                    break;
                case TriajCode.Green:
                    (<TTVisual.ITTControl>this.TriajColor).BackColor = Color.Green;
                    break;
                default:
                    (<TTVisual.ITTControl>this.TriajColor).BackColor = Color.Transparent;
                    break;
            }
        } else {
            (<TTVisual.ITTControl>this.TriajColor).BackColor = Color.White;
        }*/
    }

    DentalProsthesis_CellContentClickEmitted(data: any) {
        if (data && this.DentalProsthesis_CellContentClick && data.Row && data.Column) {
            this.DentalProsthesis.CurrentCell = {
                OwningRow: data.Row,
                OwningColumn: data.Column
            };
            this.DentalProsthesis_CellContentClick(data.RowIndex, data.ColIndex);
        }
    }
    private async DentalProsthesis_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        /* if (this.DentalProsthesis.CurrentCell.OwningColumn.Name.Equals(ProcedureToothSchema.Name))
                     this.DentalProsthesis.ShowTTObject(rowIndex, false); */

        let procedure: SubActionProcedure = <SubActionProcedure>this.DentalProsthesis.CurrentCell.OwningRow.TTObject;
        // MT Çoklu özel durum düğmesi basılınca Çoklu özel durum formu açılır.
        /*if ((<TTVisual.ITTGridCell>this.DentalProsthesis.CurrentCell).OwningColumn.Name === 'CokluOzelDurum') {
            let dpcodf: DentalProcedure_CokluOzelDurumForm = new DentalProcedure_CokluOzelDurumForm();
            dpcodf.ShowEdit(this.FindForm(), procedure, true);
        }*/
        if ((<TTVisual.ITTGridCell>this.DentalProsthesis.CurrentCell).OwningColumn.Name === 'Mustehaklik') {
            let dentalProcedure: DentalProcedure = (<DentalProcedure>(this.DentalProsthesis.CurrentCell.OwningRow.TTObject));
            let procedureObject: ProcedureDefinition = <ProcedureDefinition>dentalProcedure.ProcedureObject;
            let output: AddDentalProcedures_Output = await DentalExaminationService.MustehaklikKontrol(dentalProcedure, this._DentalExamination, procedureObject);
            dentalProcedure.AccountRecordable = output.isRecourdable;
            if (output.succsess === false) {
                ServiceLocator.MessageService.showError(output.errorMessage);
            }
            if (output.resultMessage !== '') {
                ServiceLocator.MessageService.showInfo(output.resultMessage);
            }
        }

        if ((<TTVisual.ITTGridCell>this.DentalProsthesis.CurrentCell).OwningColumn.Name === 'columnHastaOdeme') {
            let dentalProcedure: DentalProcedure = (<DentalProcedure>(this.DentalProsthesis.CurrentCell.OwningRow.TTObject));
            let procedureObject: ProcedureDefinition = <ProcedureDefinition>dentalProcedure.ProcedureObject;
            let output: CalcPatientPrice_Output = await DentalExaminationService.CalcPatientPrice(dentalProcedure, this._DentalExamination, procedureObject);
            dentalProcedure.PatientPrice = output.patientPrice;
        }
    }
    private async DentalProsthesis_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        /*    if (this.DentalProsthesis.CurrentCell !== null && this.DentalProsthesis.CurrentCell.OwningColumn !== null) {
                if (this.DentalProsthesis.CurrentCell.OwningColumn.Name === 'ProcedureObject' || this.DentalProsthesis.CurrentCell.OwningColumn.Name === 'columnHastaOdeme') {
                    if (rowIndex < this.DentalProsthesis.Rows.length && rowIndex > -1) {
                        let dentalProcedure: DentalProcedure = <DentalProcedure>this.DentalProsthesis.CurrentCell.OwningRow.TTObject;
                        if (dentalProcedure.ProcedureObject !== null) {
                            if (this.DentalProsthesis.CurrentCell.OwningColumn.Name === 'ProcedureObject') {
                                if (dentalProcedure.ProcedureObject === DentalTreatmentDefinition) {
                                    let treatmentDef: DentalTreatmentDefinition = <DentalTreatmentDefinition>dentalProcedure.ProcedureObject;
                                    dentalProcedure.ToothNumber = treatmentDef.ToothNumber;
                                } else if (dentalProcedure.ProcedureObject.GetType() === typeof DentalProsthesisDefinition) {
                                    //TODO Protezlerede diş tanımı yapılırsa açılacak
                                    //DentalProsthesisDefinition treatmentDef = (DentalProsthesisDefinition)dentalProcedure.ProcedureObject;
                                    // dentalProcedure.ToothNumber = treatmentDef.ToothNumber;
                                    dentalProcedure.ToothNumber = null;
                                }
                            }
                            if ((dentalProcedure.PatientPay !== undefined) && dentalProcedure.PatientPay === true) {
                                let pricingListDefinitions: Array<any> = null;
                                let pricingDetailList: Array<any> = new Array<any>();
                                dentalProcedure.PatientPrice = await this.GetPatientPrice(dentalProcedure.ProcedureObject, false);
                                if ((await SystemParameterService.GetParameterValue('UNIVERSITEXXXXXX', 'FALSE')) === 'TRUE') {
                                    pricingListDefinitions = PricingListDefinition.GetByCode(dentalProcedure.ObjectContext, '6');
                                } else if ((await SystemParameterService.GetParameterValue('UNIVERSITEXXXXXX', 'FALSE')) === 'FALSE') {
                                    pricingListDefinitions = PricingListDefinition.GetByCode(dentalProcedure.ObjectContext, '5');
                                }
                                if (pricingListDefinitions.length > 0) {
                                    let pld: PricingListDefinition = <PricingListDefinition>pricingListDefinitions[0];
                                    let pd: ProcedureDefinition = <ProcedureDefinition>dentalProcedure.ProcedureObject;
                                    pricingDetailList = pd.GetProcedurePricingDetail(pld, Date.Now);
                                    if (pricingDetailList.length > 0) {
                                        dentalProcedure.PatientPrice = (<PricingDetailDefinition>pricingDetailList[0]).Price;
                                    } else {
                                        dentalProcedure.PatientPrice = 2 * dentalProcedure.PatientPrice;
                                    }
                                }
                            } else {
                                dentalProcedure.PatientPrice = await this.GetPatientPrice(dentalProcedure.ProcedureObject, true);
                            }
                        }
                    }
                }
            }*/
    }


    private async SecDiagnosisGrid_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {

    }
    private async TabExaminationType_SelectedTabChanged(): Promise<void> {
        switch (this.TabExaminationType.SelectedTab.Name) {
            case 'OlduExaminations':
                if (!this.OldDentalExaminationsGridFilled) {
                    this.FillDentalExaminationFile1Grid(this.OldDentalExaminationsGrid);
                    this.OldDentalExaminationsGridFilled = true;
                }
                break;
            default:
                break;
        }
    }
    private async ttbutton3_Click(): Promise<void> {
        /* let sb: StringBuilder = new StringBuilder('');
         this.getSelectedToothNumbers(sb, this.Controls);
         if (''.Equals(sb.toString())) {
             TTVisual.InfoBox.Show('Diş seçimi yapmadan hastayı sıraya alamazsınız!');
             return;
         }
         if (this._DentalExamination.CurrentStateDefID === DentalExamination.DentalExaminationStates.OrderedPatient) {
             TTVisual.InfoBox.Show('Hasta önceden sıraya alınmıştır, tekrar sıraya alamazsınız!');
             return;
         }
         let context: TTObjectContext = new TTObjectContext(false);
         let dq: DentalQueue = new DentalQueue(context);
         dq.CurrentStateDefID = DentalQueue.DentalQueueStates.New;
         dq.DentalExamination = this._DentalExamination;
         dq.Patient = this._DentalExamination.Episode.Patient;
         dq.Description = 'Ad Soyad: ' + dq.Patient.FullName + '\n' + 'Doğum tarihi: ' + dq.Patient.BirthDate.Value.ToLongDateString() + '\n' + 'Adres: ' + dq.Patient.PatientAddress.HomeAddress;
         dq.ToothNumbers = sb.toString();
         let theForm: TTVisual.TTForm = TTVisual.TTForm.GetEditForm(dq);
         theForm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
         theForm.GetTemplates = this.GetTemplates;
         theForm.SaveTemplate = this.SaveTemplate;
         theForm.TemplateSelected = this.TemplateSelected;
         if (theForm.ShowEdit(this.FindForm(), dq) === DialogResult.OK) {
             let examinationText: string = null;
             if (this.DentalExaminationFile1.Rtf !== null) {
                 examinationText = (await CommonService.GetTextOfRTFString(this.DentalExaminationFile1.Rtf));
             }
             if (examinationText === null) {
                 examinationText = '';
             }
             if (examinationText !== null && !''.Equals(examinationText)) {
                 examinationText += '\n ';
             }
             examinationText += 'Hasta ' + (await CommonService.RecTime()).Date.ToShortDateString() + ' tarihinde sıraya alındı';
             this.DentalExaminationFile1.Rtf = (await CommonService.GetRTFOfTextString(examinationText));
             context.Save();
             TTVisual.InfoBox.Show('Hasta başarıyla sıraya alındı.', MessageIconEnum.InformationMessage);
             //ttbuttonTemizle_Click();
             //ttgrid3.Rows.Clear();
             let transDef: TTObjectStateTransitionDef = <TTObjectStateTransitionDef>this._EpisodeAction.CurrentStateDef
                 .FindOutoingTransitionDefFromStateDefID(DentalExamination.DentalExaminationStates.Completed);
             if (DoContextUpdate(transDef))
                 this.DialogResult = DialogResult.OK;
         }*/
    }

    private delay(milliseconds: number) {
        return new Promise<void>(resolve => {
            setTimeout(resolve, milliseconds);
        });
    }
    private async ttButtonHizmetKontrol_Click(): Promise<void> {
        let errorMsg: string = '';
        let resultMsg: string = '';
        let sccss: boolean = true;
        for (let dentalProcedure of this._DentalExamination.DentalProcedures) {
            if (dentalProcedure.AccountRecordable !== true) {
                let procedureObject: ProcedureDefinition = <ProcedureDefinition>dentalProcedure.ProcedureObject;
                let output: AddDentalProcedures_Output = await DentalExaminationService.MustehaklikKontrol(dentalProcedure, this._DentalExamination, procedureObject);
                dentalProcedure.AccountRecordable = output.isRecourdable;
                if (output.succsess === false) {
                    sccss = false;
                    errorMsg = errorMsg + output.errorMessage;
                }
                if (output.resultMessage !== '') {
                    resultMsg = resultMsg + output.resultMessage;
                }
                await this.delay(3000);
            }
        }
        if (sccss === false) {
            ServiceLocator.MessageService.showError(errorMsg);
        }

        if (resultMsg !== '') {
            ServiceLocator.MessageService.showInfo(resultMsg);
        }
    }

    private async ttButtonOrtodontiForm_Click(): Promise<void> {
        let patientObjID: Guid = <any>this._DentalExamination.Episode['Patient'];
        let patient: Patient = await this.objectContextService.getObject<Patient>(patientObjID, Patient.ObjectDefID);
        this.ShowOrtodontiForm(patient);
    }

    private ShowOrtodontiForm(patient: Patient): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'OrtodontiFormComponent';
            componentInfo.ModuleName = 'DisMuayeneModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Dis_Muayene_Modulu/DisMuayeneModule';
            componentInfo.InputParam = new DynamicComponentInputParam(patient, new ActiveIDsModel(this._DentalExamination.ObjectID, this._DentalExamination.Episode.ObjectID, this._DentalExamination.Episode.Patient.ObjectID));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M19801", "Ortodonti Formu");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    CheckProtesisPocedures(): boolean {
        let that = this;
        let result: boolean = false;

        this.httpService.get<boolean>('api/DentalExaminationService/CheckProtesisPocedures?DentalExaminationID=' + this.dentalExaminationFormViewModel._DentalExamination.ObjectID).then((output: boolean) => {
            result = output;
        });

        return result;

    }
    private async ttButtonTaahhut_Click(): Promise<void> {

        //if (!this.CheckProtesisPocedures())
        //{
        //    ServiceLocator.MessageService.showError("Hastanın üstünde protez işlemi olmadan Diş Taahhüt formu açılamaz.");
        //    return;

        //}

        if (this.dentalExaminationFormViewModel._DentalExamination.DentalCommitment != null || this.dentalExaminationFormViewModel._DentalExamination.DentalCommitment != undefined) {
            this.ShowTaahutForm(this.dentalExaminationFormViewModel._DentalExamination.DentalCommitment);
        } else {
            this.ShowTaahutForm(null);
        }



    }


    private ShowTaahutForm(dentalCommitment: DentalCommitment): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DentalCommitmentForm';
            componentInfo.ModuleName = 'DisMuayeneModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Dis_Muayene_Modulu/DisMuayeneModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = false;
            componentInfo.InputParam = new DynamicComponentInputParam(dentalCommitment, new ActiveIDsModel(this._DentalExamination.ObjectID, this._DentalExamination.Episode.ObjectID, this._DentalExamination.Episode.Patient.ObjectID));

            if (dentalCommitment != null || dentalCommitment != undefined) {
                componentInfo.objectID = dentalCommitment.ObjectID.toString();
            }


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Diş Taahhüt Formu';
            modalInfo.Width = 1200;
            modalInfo.Height = 800;
            modalInfo.fullScreen = false;
            modalInfo.IsShowCloseButton = false;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    private async createProcedure(): Promise<void> {
        if (this.checkList.length !== 0) {
            if (this.selectedDentalProcedure.length !== 0) {
                let procedures: Array<DentalProcedure> = await DentalExaminationService.AddDentalProcedures(this.checkList, this.selectedDentalProcedure, this._DentalExamination);
                if (this.dentalExaminationFormViewModel.DentalProsthesisGridList.length === 0) {
                    this.dentalExaminationFormViewModel.DentalProsthesisGridList = new Array<DentalProcedure>();
                }
                for (let dentalPro of procedures) {
                    let procedureObjectID = dentalPro['ProcedureObject'];
                    let dProcedure = this.dentalProcedure.find(o => o.ObjectID.toString() === procedureObjectID.toString());
                    dentalPro.ProcedureObject = dProcedure;
                    dentalPro.ProcedureDoctor = this.dentalExaminationFormViewModel._DentalExamination.ProcedureDoctor;
                    dentalPro.MasterResource = this.dentalExaminationFormViewModel._DentalExamination.MasterResource;
                    this.dentalExaminationFormViewModel.DentalProsthesisGridList.unshift(dentalPro);
                    //this._DentalExamination.DentalProcedures.push(dentalPro);
                }
                this.checkValues = Array.apply(null, Array(58)).map(Boolean.prototype.valueOf, false);
                this.checkList = new Array<string>();
            }
        } else {
            if (this.selectedDentalProcedure.length !== 0) {
                TTVisual.InfoBox.Alert("Diş seçmeden işlem ekleyemezsiniz!");
            }
        }
        this.selectedDentalProcedure = new Array<ProcedureDefinition>();

    }


    private async ttbuttonTemizle_Click(): Promise<void> {
        this.checkValues = Array.apply(null, Array(58)).map(Boolean.prototype.valueOf, false);
        this.selectedDentalProcedure = new Array<ProcedureDefinition>();
        this.checkList = new Array<string>();
    }
    private async ttbuttonTopluIslemTamamla_Click(): Promise<void> {
        if (this.selectedDentalProcedure.length !== 0 && this.checkList.length !== 0) {
            let procedures: Array<DentalProcedure> = await DentalExaminationService.AddDentalProcedures(this.checkList, this.selectedDentalProcedure, this._DentalExamination);
            if (this.dentalExaminationFormViewModel.DentalProsthesisGridList.length === 0) {
                this.dentalExaminationFormViewModel.DentalProsthesisGridList = new Array<DentalProcedure>();
            }
            /*if (this._DentalExamination.DentalProcedures.length === 0) {
                this._DentalExamination.DentalProcedures = new Array<DentalProcedure>();
            }*/
            for (let dentalPro of procedures) {
                let procedureObjectID = dentalPro['ProcedureObject'];
                let dProcedure = this.dentalProcedure.find(o => o.ObjectID.toString() === procedureObjectID.toString());
                dentalPro.ProcedureObject = dProcedure;
                dentalPro.ProcedureDoctor = this.dentalExaminationFormViewModel._DentalExamination.ProcedureDoctor;
                dentalPro.MasterResource = this.dentalExaminationFormViewModel._DentalExamination.MasterResource;
                this.dentalExaminationFormViewModel.DentalProsthesisGridList.unshift(dentalPro);
                //this._DentalExamination.DentalProcedures.push(dentalPro);
            }
            this.checkValues = Array.apply(null, Array(58)).map(Boolean.prototype.valueOf, false);
            this.selectedDentalProcedure = new Array<ProcedureDefinition>();
            this.checkList = new Array<string>();
        } else {
            if (this.selectedDentalProcedure.length === 0) {
                ServiceLocator.MessageService.showError(i18n("M23560", "Toplu işlem girişi için en az 1 diş ve en az 1 diş ya da protez işlemi seçmelisiniz."));
            }

            if (this.checkList.length === 0) {
                ServiceLocator.MessageService.showError(i18n("M23560", "Toplu işlem girişi için en az 1 diş ve en az 1 diş ya da protez işlemi seçmelisiniz."));
            }
        }
    }
    private async ttChkBoxGeneralAnesthesia_CheckedChanged(): Promise<void> {
        /*if ((this.ttChkBoxGeneralAnesthesia.Value !== undefined) && this.ttChkBoxGeneralAnesthesia.Value.Value) {
            let context: TTObjectContext = new TTObjectContext(true);
            let oList: Array<OzelDurum> = (await OzelDurumService.GetOzelDurumByKod(context, 'Y'));
            if (oList.length > 0)
                this._DentalExamination.OzelDurum = oList[0];
            context.Dispose();
        }
        else {
            if (this._DentalExamination.OzelDurum !== null && this._DentalExamination.OzelDurum.ozelDurumKodu === 'Y') {
                this._DentalExamination.OzelDurum = null;
            }
        }*/
    }
    private async ttgrid3_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.ttgrid3.CurrentCell.OwningColumn.Name === 'SUGGESTEDPROSTHESISPROCEDURE') {
            let sugPro: DentalProsthesisRequestSuggestedProsthesis = <DentalProsthesisRequestSuggestedProsthesis>(this.ttgrid3.CurrentCell.OwningRow.TTObject);
            if (sugPro.SuggestedProsthesisProcedure !== null) {
                if (this.dentalExaminationFormViewModel.DentalProsthesisDefinitions.length === 0) {
                    this.dentalExaminationFormViewModel.DentalProsthesisDefinitions = new Array<DentalProsthesisDefinition>();
                }
                this.dentalExaminationFormViewModel.DentalProsthesisDefinitions.push(sugPro.SuggestedProsthesisProcedure);
                let output: GetDepartment_Output = await DentalExaminationService.GetDepartment(sugPro.SuggestedProsthesisProcedure);
                if (output.department !== null) {
                    sugPro.Department = output.department;
                    if (this.dentalExaminationFormViewModel.ResSections.length === 0) {
                        this.dentalExaminationFormViewModel.ResSections = new Array<ResSection>();
                    }
                    this.dentalExaminationFormViewModel.ResSections.push(sugPro.Department);
                }
                sugPro.ActionDate = output.actionDate;
                if (this._DentalExamination.Emergency !== null) {
                    sugPro.Emergency = this._DentalExamination.Emergency;
                } else {
                    sugPro.Emergency = false;
                }
            }
        }
    }
    private async TTListBoxDrAnesteziTescilNo_SelectedObjectChanged(): Promise<void> {
        if (this.TTListBoxDrAnesteziTescilNo.SelectedObject !== null) {
            let resUser: ResUser = <ResUser>this.TTListBoxDrAnesteziTescilNo.SelectedObject;
            this._DentalExamination.DrAnesteziTescilNo = (resUser.DiplomaRegisterNo === null) ? null : resUser.DiplomaRegisterNo.toString();
        }
    }
    private async ttlistviewDentalSpecialityList_DoubleClick(): Promise<void> {
        /*  let istekAciklama: StringBuilder = new StringBuilder();
          try {
              addDentalConsultationRows(this.Controls, istekAciklama);
          } catch (e) {
              this.DentalConsultation.Rows.Clear();
              TTVisual.InfoBox.Show('Diş seçilirken bir hata oluştu!');
          }

          if (istekAciklama === null || ''.Equals(istekAciklama.toString()) || istekAciklama.Length === 0) {
              TTVisual.InfoBox.Show('Diş seçiniz!');
              return;
          }
          try {
              for (let tempItem of this.ttlistviewDentalSpecialityList.SelectedItems) {
                  let newRow: TTVisual.ITTGridRow = this.DentalConsultation.Rows.push();
                  let context: TTObjectContext = new TTObjectContext(false);
                  let resSectionList: Array<ResSection> = (await ResSectionService.GetBySpeciality(SpecialityDefinition.GetSpecialityByCode(tempItem.Name)[0].ObjectID));
                  if (resSectionList !== null && resSectionList.length > 0)
                      for (let rs of resSectionList) {
                          if (rs.GetType() === typeof TTObjectClasses.ResPoliclinic) {
                              newRow.Cells[0].Value = rs.ObjectID;
                              break;
                          }
                      }
                  if (newRow.Cells[0].Value === null) {
                      throw new Exception('İlgili poliklinik sistemde kayıtlı değil!');
                  }
                  let istekAciklamaStr: string = istekAciklama.toString();
                  newRow.Cells[1].Value = istekAciklamaStr.substring(0, istekAciklamaStr.length - 1)
                  + ' numaralı dişler ' + tempItem.Text + ' branşına ' + (await CommonService.RecTime()) + ' tarihinde yönlendirilmiştir.';
                  newRow.Cells[2].Value = istekAciklamaStr.substring(0, istekAciklamaStr.length - 1);
                  this.disMuayene += newRow.Cells[1].Value + '\n';
              }
              this.ttlistviewDentalSpecialityList.SelectedItems.Clear();
              for (let tempChkbox of this.selectedCheckboxes) {
                  tempChkbox.Checked = false;
              }
              this.selectedCheckboxes.Clear();
          }
          catch (e) {
              this.DentalConsultation.Rows.Clear();
              TTVisual.InfoBox.Show('İlgili poliklinik sistem kayıtlı değil!');
          }*/

    }
    protected async ClientSidePreScript(): Promise<void> {
        await super.ClientSidePreScript();
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (this.dentalExaminationFormViewModel._DentalExamination.IsConsultation === true) {
            if (transDef != null && transDef.ToStateDefID.toString() === DentalExamination.DentalExaminationStates.Completed.toString()) {
                if (this.dentalExaminationFormViewModel._DentalExamination.ConsultationResultAndOffers != null) {
                    super.ClientSidePostScript(transDef);
                } else {
                    throw new TTException(i18n("M17794", "Konsültasyonu Tamamlamak İçin Sonuç Girmeniz Gerekmektedir.!"));
                }
            }
        } else {
            super.ClientSidePostScript(transDef);
        }

    }

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        /* if (transDef !== null) {
             if (transDef.ToStateDefID.Equals(DentalExamination.DentalExaminationStates.PatientNoShown)) {
                 let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', 'Uyarı',
                     'Hasta Gelmedi Butonuna Bastınız', 'Hasta gelmedi butonuna bastınız. Diş Muayene işlemi geri alınmamak üzere kapatılacaktır.\r\n İşleme devam etmek ister misiniz? ');
                 if (result === 'H') {
                     throw new Exception((await SystemMessageService.GetMessage(80)));
                 }
             }
         }
         if (transDef !== null && transDef.ToStateDefID !== DentalExamination.DentalExaminationStates.PatientNoShown && transDef.ToStateDefID !== DentalExamination.DentalExaminationStates.Cancelled) {
             if ((await SystemParameterService.GetParameterValue('ISENTEGRATEDTODENTALINE', 'FALSE')) !== 'TRUE') {
                 if (this._DentalExamination.Diagnosis.length === 0) {
                     throw new Exception((await SystemMessageService.GetMessage(635)));
                 }
             }
         }
         if (transDef === null || ((transDef !== null) && (transDef.ToStateDefID === DentalExamination.DentalExaminationStates.Completed))) {
             for (let dentalExaminationProcedure of this._DentalExamination.DentalExaminationProcedures) {
                 dentalExaminationProcedure.SetPerformedDate();
             }
         }
         if (transDef === null || (transDef !== null && (transDef.ToStateDefID === DentalExamination.DentalExaminationStates.Completed
             || transDef.ToStateDefID === DentalConsultation.DentalConsultationStates.Completed))) {
             this.CompleteMyExaminationQueueItems();
             let examinationRtf: string = '';
             for (let dp of this._DentalExamination.DentalProcedures) {
                 let pricingListDefinitions: Array<any> = null;
                 let pricingDetailList: Array<any> = new Array<any>();
                 if ((await SystemParameterService.GetParameterValue('UNIVERSITEXXXXXX', 'FALSE')) === 'TRUE') {
                     pricingListDefinitions = PricingListDefinition.GetByCode(dp.ObjectContext, '6');
                 }
                 else if ((await SystemParameterService.GetParameterValue('UNIVERSITEXXXXXX', 'FALSE')) === 'FALSE') {
                     pricingListDefinitions = PricingListDefinition.GetByCode(dp.ObjectContext, '5');
                 }
                 dp.AccountOperation(AccountOperationTimeEnum.PREPOST);
                 if (dp.PatientPay !== null && dp.PatientPay.Value === true) {
                     let payer: number = 0;
                     let patient: number = 1;
                     if (pricingListDefinitions.length > 0) {
                         let pld: PricingListDefinition = <PricingListDefinition>pricingListDefinitions[0];
                         let pd: ProcedureDefinition = <ProcedureDefinition>dp.ProcedureObject;
                         pricingDetailList = pd.GetProcedurePricingDetail(pld, Date.Now);
                         if (pricingDetailList.length > 0) {
                             dp.TurnMyAccTrxsToPatientOrPayerShare(<PricingDetailDefinition>pricingDetailList[0], payer, patient);
                         } else if (pricingDetailList.length === 0) {
                             let SUTPriceList: PricingListDefinition = <PricingListDefinition>PricingListDefinition
                             .GetByObjectID(this._DentalExamination.ObjectContext, (await SystemParameterService.GetParameterValue('SUTPRICELISTOBJECTID', '')).toString())[0];
                             pricingDetailList = pd.GetProcedurePricingDetail(SUTPriceList, Date.Now);
                             dp.TurnMyAccTrxsToPatientOrPayerShare(<PricingDetailDefinition>pricingDetailList[0], payer, patient);
                         }
                     }
                 } else {
                     let payer: number = 1;
                     let patient: number = 0;
                     let SUTPriceList: PricingListDefinition = <PricingListDefinition>PricingListDefinition
                     .GetByObjectID(this._DentalExamination.ObjectContext, (await SystemParameterService.GetParameterValue('SUTPRICELISTOBJECTID', '')).toString())[0];
                     let pd: ProcedureDefinition = <ProcedureDefinition>dp.ProcedureObject;
                     pricingDetailList = pd.GetProcedurePricingDetail(SUTPriceList, Date.Now);
                     dp.TurnMyAccTrxsToPatientOrPayerShare(<PricingDetailDefinition>pricingDetailList[0], payer, patient);
                 }
                 let disNo: string = '';
                 for (let row of this.DentalProsthesis.Rows) {
                     if ((<DentalProcedure>row.TTObject).Equals(dp)) {
                         disNo = row.Cells[4].Value.toString();
                         break;
                     }
                 }
                 examinationRtf = (await CommonService.GetTextOfRTFString(this.DentalExaminationFile1.Rtf));
                 let examinationText: string = dp.ProcedureObject.Code + '-' + dp.ProcedureObject.Description +
                     ' işlemi ' + (await CommonService.RecTime()).Date.ToShortDateString() + ' tarihinde ' + disNo + ' dişine yapılmıştır.\n';
                 if (!examinationRtf.Contains(examinationText)) {
                     examinationRtf += examinationText;
                     this.DentalExaminationFile1.Rtf = (await CommonService.GetRTFOfTextString(examinationRtf));
                 }
             }
             // Kaydet ve Tamamla yapıldığında Sarf Malzemelerin ücretlenmesi için
             for (let treatmentMaterial of this._DentalExamination.TreatmentMaterials) { treatmentMaterial.AccountOperation(AccountOperationTimeEnum.PREPOST); }
             for (let dentalConsRequest of this._DentalExamination.DentalConsultationRequest) {
                 if (dentalConsRequest.CurrentStateDefID === DentalConsultationRequest.DentalConsultationRequestStates.Request) {
                     dentalConsRequest.MasterResource = dentalConsRequest.ConsultationDepartment;
                     dentalConsRequest.FromResource = this._DentalExamination.MasterResource;
                     dentalConsRequest.Episode = dentalConsRequest.DentalExamination.Episode;
                     dentalConsRequest.DescriptionForWorkList = dentalConsRequest.RequestDescription;
                     dentalConsRequest.RequestDescription = Common.GetRTFOfTextString(dentalConsRequest.RequestDescription);
                     dentalConsRequest.ResUser = this._DentalExamination.ProcedureDoctor;
                     let isInsertedBefore: boolean = false;
                     for (let deptemp of dentalConsRequest.Department) {
                         if (deptemp.ResSection.Equals(dentalConsRequest.ConsultationDepartment)) {
                             isInsertedBefore = true;
                             break;
                         }
                     }
                     if (!isInsertedBefore) {
                         let dep: DentalConsultationDepartment = new DentalConsultationDepartment(this._DentalExamination.ObjectContext);
                         dep.ResSection = dentalConsRequest.ConsultationDepartment;
                         dep.DentalConsultationRequest = dentalConsRequest;
                     }
                 }
             }
             if (''.Equals(examinationRtf)) {
                 examinationRtf = (await CommonService.GetTextOfRTFString(this.DentalExaminationFile1.Rtf));
             }
             if (!examinationRtf.Contains(this.disMuayene)) {
                 examinationRtf += this.disMuayene;
                 this.DentalExaminationFile1.Rtf = (await CommonService.GetRTFOfTextString(examinationRtf));
             }*/
        /*if (ttgrid3.Rows != null && ttgrid3.Rows.Count > 0) {
            if (this._DentalExamination.Laboratory == null || this._DentalExamination.Laboratory.Count == 0) {
                DentalLaboratoryProcedure dentalLab = new DentalLaboratoryProcedure(this._DentalExamination.ObjectContext,this._DentalExamination);
                foreach(DentalExaminationSuggestedProsthesis sp in this._DentalExamination.SuggestedProsthesis) {
                    sp.DentalLaboratoryProcedure = dentalLab;
                    //protez işlemi oluşturmak için eklenmişti. Ancak muayene içinden istendiği için kaldırıldı.
                    //DentalLaboratoryProcedureProthesis dentalLaboratoryProcedureProthesis = new DentalLaboratoryProcedureProthesis(this._DentalExamination.ObjectContext,dentalLab,sp);
                }
            }
            else {
                DentalLaboratoryProcedure dentalLab = this._DentalExamination.Laboratory[0];
                if (dentalLab.CurrentStateDefID == DentalLaboratoryProcedure.States.Completed){
                    InfoBox.Show("Laboratuvar işlemi tamamlandı durumunda olduğundan değişiklik yapamazsınız, önce laboratuvar işlemini yeni adımına geçiriniz.");
                    return;
                }
                foreach(DentalExaminationSuggestedProsthesis sp in this._DentalExamination.SuggestedProsthesis) {
                    if(sp.DentalLaboratoryProcedure == null)
                    {
                        sp.DentalLaboratoryProcedure = dentalLab;
                        //protez işlemi oluşturmak için eklenmişti. Ancak muayene içinden istendiği için kaldırıldı.
                        //DentalLaboratoryProcedureProthesis dentalLaboratoryProcedureProthesis = new DentalLaboratoryProcedureProthesis(this._DentalExamination.ObjectContext,dentalLab,sp);
                    }
                }
            }
        }
        else  if (this._DentalExamination.Laboratory != null && this._DentalExamination.Laboratory.Count > 0) {
            //DentalLaboratoryProcedure dentalLab = this._DentalExamination.Laboratory[0];
            //dentalLab.CurrentStateDefID = DentalLaboratoryProcedure.States.Cancelled;
        }*/


        /*
                    let found: boolean;
                    for (let sp of this._DentalExamination.SuggestedProsthesis) {
                        found = false;
                        if (sp.DentalLaboratoryProcedure === null && sp.Department !== null) {
                            for (let dp of this._DentalExamination.Laboratory) {
                                if (dp.MasterResource.ObjectID === sp.Department.ObjectID) {
                                    if (dp.CurrentStateDefID !== DentalLaboratoryProcedure.DentalLaboratoryProcedureStates.Completed) {
                                        sp.DentalLaboratoryProcedure = dp;
                                        found = true;
                                        break;
                                    } else {
                                        TTVisual.InfoBox.Show(dp.MasterResource.Name + ' birimine ait Laboratuvar işlemi tamamlandı durumunda olduğundan'
                                            + ' değişiklik yapamazsınız, önce laboratuvar işlemini yeni adımına geçiriniz.');
                                        return;
                                    }
                                }
                            }
                            if (!found) {
                                //let dentalLab: DentalLaboratoryProcedure = new DentalLaboratoryProcedure(this._DentalExamination, sp);
                                //sp.DentalLaboratoryProcedure = dentalLab;
                            }
                        }
                    }
                }*/

        this.dentalExaminationFormViewModel.GrdConsultationGridList = new Array<Consultation>();
        this.dentalExaminationFormViewModel.GrdPatientInterviewFormGridList = new Array<PatientInterviewForm>();
        this.dentalExaminationFormViewModel.GrdExternalConsultationGridList = new Array<ConsultationFromExternalHospital>();
        this.dentalExaminationFormViewModel.GrdDentalExaminationGridList = new Array<DentalExamination>();

        for (let detailItem of this.dentalExaminationFormViewModel.GrdConsAndPatientInterviewFormGridList) {
            if (detailItem instanceof Consultation) {
                this.dentalExaminationFormViewModel.GrdConsultationGridList.push(<Consultation>detailItem);
            } else if (detailItem instanceof PatientInterviewForm) {
                this.dentalExaminationFormViewModel.GrdPatientInterviewFormGridList.push(<PatientInterviewForm>detailItem);
            } else if (detailItem instanceof ConsultationFromExternalHospital) {
                this.dentalExaminationFormViewModel.GrdExternalConsultationGridList.push(<ConsultationFromExternalHospital>detailItem);
            } else if (detailItem instanceof DentalExamination) {
                this.dentalExaminationFormViewModel.GrdDentalExaminationGridList.push(<DentalExamination>detailItem);
            }
        }

        if (this.dentalExaminationFormViewModel.ConsultationsHistory != null)
            this.dentalExaminationFormViewModel.ConsultationsHistory.Clear();


    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.DropStateButton(DentalExamination.DentalExaminationStates.OrderedPatient);
        this.getComponentInfo();

        this.dentalProcedure = new DataSource({
            store: await DentalExaminationService.GetDentalProcedures(),
            searchOperation: 'contains',
            searchExpr: 'Name'
        });
        this.dentalProcedure = await DentalExaminationService.GetDentalProcedures();
        this.dentalProcedure.forEach(element => {
            element.Name = element.Code + " - " + element.Name;
        });
        //this.selectedDentalProcedure = new Array<ProcedureDefinition>();

        let drugOrderIntDets: Array<OldDrugOrderIntroduction> = await DrugOrderIntroductionService.GetOldDrugOrderIntroductions(this._DentalExamination.Episode);
        if (drugOrderIntDets !== null) {
            this.PrescriptionList = new Array<OldDrugOrderIntroduction>();
            for (let drugOrder of drugOrderIntDets) {
                this.PrescriptionList.push(drugOrder);
            }
        }

        this.ActivePage = this.tabService.getActiveTab('pedfn');
        if (this.ActivePage === undefined) {
            if (this.hasSpecialityBasedObject === true)
                this.ActivePage = 'uzmanlik';
            if (this.hasEmergencySpecialityBasedObject === true)
                this.ActivePage = 'muayene';
        } else if (this.ActivePage !== undefined) {
            if (this.hasSpecialityBasedObject === false && this.ActivePage === 'uzmanlik')
                this.ActivePage = 'muayene';
            if (this.hasEmergencySpecialityBasedObject === false && this.ActivePage === 'muayene')
                this.ActivePage = 'uzmanlik';
            if (this.ActivePage === 'istem')
                this.openIstemTab = true;
            if (this.ActivePage === 'hastaGecmisi')
                this.openHastaGecmisi();
        }
        if (this.ActivePage === 'uzmanlik')
            this.openUzmanlikTab = true;
        this.RecentActiveTab = this.ActivePage;

        let message: string = await DentalExaminationService.Paid(this._DentalExamination.ObjectID);
        if (message !== '') {
            ServiceLocator.MessageService.showError(message);
        }

        /*let item: TTListViewItem = new TTListViewItem();
        item.Text = 'Oral Diagnoz';
        item.Name = '5600';
        this.ttlistviewDentalSpecialityList.Items.push(item);
        item = new TTListViewItem();
        item.Text = 'Tedavi';
        item.Name = '5700';
        this.ttlistviewDentalSpecialityList.Items.push(item);
        item = new TTListViewItem();
        item.Text = 'Periodontoloji';
        item.Name = '5500';
        this.ttlistviewDentalSpecialityList.Items.push(item);
        item = new TTListViewItem();
        item.Text = 'Cerrahi';
        item.Name = '5100';
        this.ttlistviewDentalSpecialityList.Items.push(item);
        item = new TTListViewItem();
        item.Text = 'Pedodonti';
        item.Name = '5300';
        this.ttlistviewDentalSpecialityList.Items.push(item);
        item = new TTListViewItem();
        item.Text = 'Ortodonti';
        item.Name = '5200';
        this.ttlistviewDentalSpecialityList.Items.push(item);
        item = new TTListViewItem();
        item.Text = 'Protez';
        item.Name = '5400';
        this.ttlistviewDentalSpecialityList.Items.push(item);
        item = new TTListViewItem();
        item.Text = 'Endodonti';
        item.Name = '5150';
        this.ttlistviewDentalSpecialityList.Items.push(item);
        let b: Button = <Button>this.ttbuttonRadyoloji;
        b.ImageAlign = ContentAlignment.MiddleLeft;
        b.TextAlign = ContentAlignment.MiddleRight;
        b.Image = <Image>TTUtils.Deserialize.StringToObject(DentalExaminationForm.RadyolojiIMG);
        b = <Button>this.ttbuttonBiyokimya;
        b.ImageAlign = ContentAlignment.MiddleLeft;
        b.TextAlign = ContentAlignment.MiddleRight;
        b.Image = <Image>TTUtils.Deserialize.StringToObject(DentalExaminationForm.BiyokimyaIMG);
        b = <Button>this.ttbuttonMikrobiyoloji;
        b.ImageAlign = ContentAlignment.MiddleLeft;
        b.TextAlign = ContentAlignment.MiddleRight;
        b.Image = <Image>TTUtils.Deserialize.StringToObject(DentalExaminationForm.MikrobiyolojiIMG);
        b = <Button>this.ttbuttonPatoloji;
        b.ImageAlign = ContentAlignment.MiddleLeft;
        b.TextAlign = ContentAlignment.MiddleRight;
        b.Image = <Image>TTUtils.Deserialize.StringToObject(DentalExaminationForm.PatolojiIMG);
        this.SetProcedureDoctorAsCurrentResource();
        this.SetTreatmentMaterialListFilter(this._DentalExamination.ObjectDef, <TTVisual.ITTGridColumn>this.UsedMaterials.Columns['Material']);
        if (this._DentalExamination.SubEpisode.PatientAdmission.AdmissionType.Equals(13)) {
            (<TTCheckBox>this.Emergency).Checked = true;
            this.Emergency.ReadOnly = true;
            this.cmbTriajCode.Visible = true;
            this.TriajColor.Visible = true;
            this.labelTriajCode.Visible = true;
            this.cmbTriajCode.Required = true;
        }
        else {
            (<TTCheckBox>this.Emergency).Enabled = false;
            this.Emergency.ReadOnly = true;
            this.cmbTriajCode.Visible = false;
            this.TriajColor.Visible = false;
            this.labelTriajCode.Visible = false;
        }
        if ((await SystemParameterService.GetParameterValue('ISENTEGRATEDTODENTALINE', 'FALSE')) === 'TRUE') {
            this.DropStateButton(DentalExamination.DentalExaminationStates.Completed);
            this.DropStateButton(DentalExamination.DentalExaminationStates.Cancelled);
            this.DropStateButton(DentalExamination.DentalExaminationStates.PatientNoShown);
            this.panelTooth.ReadOnly = true;
            this.DentalProsthesis.ReadOnly = true;
            //PreDiagnosisGrid.ReadOnly = true;
            this.SecDiagnosisGrid.ReadOnly = true;
            let removedTabCount: number = 0;
            if (this.TabExaminationType.TabPages.Contains(this.Examination)) {
                this.TabExaminationType.TabPages.RemoveAt(this.Examination.DisplayIndex - removedTabCount);
                removedTabCount++;
            }
        }
        let context: TTObjectContext = new TTObjectContext(false);
        // BindingList<ProcedureDefinition> islemList = ProcedureDefinition.GetAllProcedureDefinitions(context, null);
        this.paintRows();
        for (let tempRow of this.DentalConsultation.Rows) {
            try {
                tempRow.Cells[1].Value = (await CommonService.GetTextOfRTFString(tempRow.Cells[1].Value.toString()));
            }
            catch (e) {

            }

        }
        try {
            if (this.DentalExaminationFile1 !== null && this.DentalExaminationFile1.Text !== null) {
                this.DentalExaminationFile1.Rtf = (await CommonService.GetRTFOfTextString(this.DentalExaminationFile1.Text));
                if (this._DentalExamination.DentalExaminationFile !== null)
                    this._DentalExamination.DentalExaminationFile = this.DentalExaminationFile1.Rtf;
            }
        }
        catch (e) {

        }

        if (this._DentalExamination.CurrentStateDef.Status !== StateStatusEnum.Uncompleted) {
            for (let control of this.pnlControls.Controls) {
                if (control instanceof TTButton)
                    control.Enabled = false;
            }
        }
        if (this._DentalExamination.CurrentStateDefID === DentalExamination.DentalExaminationStates.Examination)
            this.DropStateButton(DentalExamination.DentalExaminationStates.PatientNoShown);*/
    }
    public async FillDentalExaminationFile1Grid(DentalExaminationsGrid: TTVisual.ITTGrid): Promise<void> {
        /* let examList: Array<EpisodeAction> = EpisodeAction.GetAllDentalExaminationsOfPatient(this._DentalExamination.Episode.Patient.ObjectID.toString());
         let examinationIndication: Object = null;
         for (let ea of examList) {
             if (ea instanceof DentalExamination) {
                 let de: DentalExamination = <DentalExamination>ea;
                 if (de.DentalExaminationFile !== null) {
                     try {
                         examinationIndication = TTObjectClasses.Common.GetTextOfRTFString(de.DentalExaminationFile.toString());
                     }
                     catch (err) {
                         examinationIndication = de.DentalExaminationFile.toString();
                     }

                 }
             }
             if (examinationIndication !== null) {
                 let gridRow: TTVisual.ITTGridRow = DentalExaminationsGrid.Rows.push();
                 gridRow.Cells['ExaminationDateTime'].Value = ea.ActionDate.Value;
                 gridRow.Cells['ExaminationIndication'].Value = examinationIndication;
             }
         }*/
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DentalExamination();
        this.dentalExaminationFormViewModel = new DentalExaminationFormViewModel();
        this._ViewModel = this.dentalExaminationFormViewModel;
        this.dentalExaminationFormViewModel._DentalExamination = this._TTObject as DentalExamination;
        this.dentalExaminationFormViewModel._DentalExamination.MasterResource = new ResSection();
        this.dentalExaminationFormViewModel._DentalExamination.Diagnosis = new Array<BaseDentalEpisodeActionDiagnosisGrid>();
        this.dentalExaminationFormViewModel._DentalExamination.DentalProcedures = new Array<DentalProcedure>();
        this.dentalExaminationFormViewModel._DentalExamination.DentalConsultationRequest = new Array<DentalConsultationRequest>();
        this.dentalExaminationFormViewModel._DentalExamination.DentalExaminationTreatmentMaterials = new Array<DentalExaminationTreatmentMaterial>();
        this.dentalExaminationFormViewModel._DentalExamination.ResUser = new ResUser();
        this.dentalExaminationFormViewModel._DentalExamination.OzelDurum = new OzelDurum();
        this.dentalExaminationFormViewModel._DentalExamination.SuggestedProsthesis = new Array<DentalExaminationSuggestedProsthesis>();
        this.dentalExaminationFormViewModel._DentalExamination.Episode = new Episode();
        this.dentalExaminationFormViewModel._DentalExamination.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.dentalExaminationFormViewModel._DentalExamination.ProcedureDoctor = new ResUser();
        this.dentalExaminationFormViewModel._DentalExamination.Consultations = new Array<Consultation>();
        this.dentalExaminationFormViewModel._DentalExamination.PatientInteviewForms = new Array<PatientInterviewForm>();
        this.dentalExaminationFormViewModel._DentalExamination.LinkedDentalConsultations = new Array<DentalExamination>();
        this.dentalExaminationFormViewModel._DentalExamination.RequesterDoctor = new ResUser();
        this.dentalExaminationFormViewModel._DentalExamination.FromResource = new ResSection();
        this.dentalExaminationFormViewModel.UserMostUsedFormDefinitions = new Array<vmProcedureRequestFormDefinition>();
        this.dentalExaminationFormViewModel.ProcedureRequestFormResourceIDs = new Array<Guid>();
        this.dentalExaminationFormViewModel._DentalExamination.DentalCommitment = new DentalCommitment();
    }


    protected loadViewModel() {
        this.loadLabGridColumns();
        let that = this;
        that.dentalExaminationFormViewModel.createNewProcedure = false;
        that.dentalExaminationFormViewModel = this._ViewModel as DentalExaminationFormViewModel;
        that._TTObject = this.dentalExaminationFormViewModel._DentalExamination;
        if (this.dentalExaminationFormViewModel == null) {
            this.dentalExaminationFormViewModel = new DentalExaminationFormViewModel();
        }
        if (this.dentalExaminationFormViewModel._DentalExamination == null) {
            this.dentalExaminationFormViewModel._DentalExamination = new DentalExamination();
        }
        if (this.dentalExaminationFormViewModel.NewConsultationRequests == null)
            this.dentalExaminationFormViewModel.NewConsultationRequests = new Array<NewConsultationRequestInfo>();
        that.dentalExaminationFormViewModel.UserMostUsedFormDefinitions = new Array<vmProcedureRequestFormDefinition>();
        that.dentalExaminationFormViewModel.ProcedureRequestFormResourceIDs = new Array<Guid>();
        let dentalCommitmentObjectID = that.dentalExaminationFormViewModel._DentalExamination["DentalCommitment"];
        if (dentalCommitmentObjectID != null && (typeof dentalCommitmentObjectID === "string")) {
            let dentalCommitment = that.dentalExaminationFormViewModel.DentalCommitments.find(o => o.ObjectID.toString() === dentalCommitmentObjectID.toString());
            if (dentalCommitment) {
                that.dentalExaminationFormViewModel._DentalExamination.DentalCommitment = dentalCommitment;
            }
        }
        let requesterDoctorObjectID = that.dentalExaminationFormViewModel._DentalExamination["RequesterDoctor"];
        if (requesterDoctorObjectID != null && (typeof requesterDoctorObjectID === "string")) {
            let requesterDoctor = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requesterDoctorObjectID.toString());
            if (requesterDoctor) {
                that.dentalExaminationFormViewModel._DentalExamination.RequesterDoctor = requesterDoctor;
            }
        }
        let masterResourceObjectID = that.dentalExaminationFormViewModel._DentalExamination['MasterResource'];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.dentalExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.dentalExaminationFormViewModel._DentalExamination.MasterResource = masterResource;
            }
            that.dentalExaminationFormViewModel.ProcedureRequestFormResourceIDs.push(masterResource.ObjectID);

        }
        that.dentalExaminationFormViewModel._DentalExamination.Diagnosis = that.dentalExaminationFormViewModel.SecDiagnosisGridGridList;
        for (let detailItem of that.dentalExaminationFormViewModel.SecDiagnosisGridGridList) {
            let diagnoseObjectID = detailItem['Diagnose'];
            if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                let diagnose = that.dentalExaminationFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                if (diagnose) {
                    detailItem.Diagnose = diagnose;
                }
            }
            let responsibleUserObjectID = detailItem['ResponsibleUser'];
            if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                let responsibleUser = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                if (responsibleUser) {
                    detailItem.ResponsibleUser = responsibleUser;
                }
            }
        }
        that.dentalExaminationFormViewModel._DentalExamination.DentalProcedures = that.dentalExaminationFormViewModel.DentalProsthesisGridList;
        for (let detailItem of that.dentalExaminationFormViewModel.DentalProsthesisGridList) {
            let procedureObjectObjectID = detailItem['ProcedureObject'];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.dentalExaminationFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
            let ayniFarkliKesiObjectID = detailItem['AyniFarkliKesi'];
            if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === 'string')) {
                let ayniFarkliKesi = that.dentalExaminationFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
                if (ayniFarkliKesi) {
                    detailItem.AyniFarkliKesi = ayniFarkliKesi;
                }
            }
            let ozelDurumObjectID = detailItem['OzelDurum'];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.dentalExaminationFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.dentalExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
        }
        that.dentalExaminationFormViewModel._DentalExamination.DentalConsultationRequest = that.dentalExaminationFormViewModel.DentalConsultationGridList;
        for (let detailItem of that.dentalExaminationFormViewModel.DentalConsultationGridList) {
            let consultationDepartmentObjectID = detailItem['ConsultationDepartment'];
            if (consultationDepartmentObjectID != null && (typeof consultationDepartmentObjectID === 'string')) {
                let consultationDepartment = that.dentalExaminationFormViewModel.ResPoliclinics.find(o => o.ObjectID.toString() === consultationDepartmentObjectID.toString());
                if (consultationDepartment) {
                    detailItem.ConsultationDepartment = consultationDepartment;
                }
            }
        }
        that.dentalExaminationFormViewModel._DentalExamination.TreatmentMaterials = that.dentalExaminationFormViewModel.UsedMaterialsGridList;
        for (let detailItem of that.dentalExaminationFormViewModel.UsedMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.dentalExaminationFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.dentalExaminationFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.dentalExaminationFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let malzemeTuruObjectID = detailItem['MalzemeTuru'];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === 'string')) {
                let malzemeTuru = that.dentalExaminationFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem['OzelDurum'];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.dentalExaminationFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        let resUserObjectID = that.dentalExaminationFormViewModel._DentalExamination['ResUser'];
        if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
            let resUser = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
            if (resUser) {
                that.dentalExaminationFormViewModel._DentalExamination.ResUser = resUser;
            }
        }
        let ozelDurumObjectID = that.dentalExaminationFormViewModel._DentalExamination['OzelDurum'];
        if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
            let ozelDurum = that.dentalExaminationFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
            if (ozelDurum) {
                that.dentalExaminationFormViewModel._DentalExamination.OzelDurum = ozelDurum;
            }
        }
        that.dentalExaminationFormViewModel._DentalExamination.SuggestedProsthesis = that.dentalExaminationFormViewModel.ttgrid3GridList;
        for (let detailItem of that.dentalExaminationFormViewModel.ttgrid3GridList) {
            let suggestedProsthesisProcedureObjectID = detailItem['SuggestedProsthesisProcedure'];
            if (suggestedProsthesisProcedureObjectID != null && (typeof suggestedProsthesisProcedureObjectID === 'string')) {
                let suggestedProsthesisProcedure = that.dentalExaminationFormViewModel.DentalProsthesisDefinitions.find(o => o.ObjectID.toString() === suggestedProsthesisProcedureObjectID.toString());
                if (suggestedProsthesisProcedure) {
                    detailItem.SuggestedProsthesisProcedure = suggestedProsthesisProcedure;
                }
            }
            let departmentObjectID = detailItem['Department'];
            if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
                let department = that.dentalExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === departmentObjectID.toString());
                if (department) {
                    detailItem.Department = department;
                }
            }
        }
        let episodeObjectID = that.dentalExaminationFormViewModel._DentalExamination['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.dentalExaminationFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.dentalExaminationFormViewModel._DentalExamination.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.dentalExaminationFormViewModel.DiagnosisGridGridList;
                for (let detailItem of that.dentalExaminationFormViewModel.DiagnosisGridGridList) {
                    let diagnoseObjectID = detailItem['Diagnose'];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.dentalExaminationFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem['ResponsibleUser'];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }


                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.dentalExaminationFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }



        for (let detailItem of that.dentalExaminationFormViewModel.GrdConsAndPatientInterviewFormGridList) {
            if (detailItem instanceof Consultation) {
                that.dentalExaminationFormViewModel.GrdConsultationGridList.push(<Consultation>detailItem);
            } else if (detailItem instanceof PatientInterviewForm) {
                that.dentalExaminationFormViewModel.GrdPatientInterviewFormGridList.push(<PatientInterviewForm>detailItem);
            } else if (detailItem instanceof ConsultationFromExternalHospital) {
                that.dentalExaminationFormViewModel.GrdExternalConsultationGridList.push(<ConsultationFromExternalHospital>detailItem);
            } else if (detailItem instanceof DentalExamination) {
                that.dentalExaminationFormViewModel.GrdDentalExaminationGridList.push(<DentalExamination>detailItem);
            }
        }

        let fromResourceObjectID = that.dentalExaminationFormViewModel._DentalExamination["FromResource"];
        if (fromResourceObjectID != null && (typeof fromResourceObjectID === 'string')) {
            let fromResource = that.dentalExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (fromResource) {
                that.dentalExaminationFormViewModel._DentalExamination.FromResource = fromResource;
            }
            //that.consultationDoctorExaminationFormNewViewModel._ConsultationMasterResourseID = masterResource.ObjectID;
            //that.dentalExaminationFormViewModel.Res.push(masterResource.ObjectID);
        }
        that.dentalExaminationFormViewModel._DentalExamination.Consultations = that.dentalExaminationFormViewModel.GrdConsultationGridList;
        for (let detailItem of that.dentalExaminationFormViewModel.GrdConsultationGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.dentalExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.dentalExaminationFormViewModel._DentalExamination.ExternalConsultations = that.dentalExaminationFormViewModel.GrdExternalConsultationGridList;
        for (let detailItem of that.dentalExaminationFormViewModel.GrdExternalConsultationGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.dentalExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.dentalExaminationFormViewModel._DentalExamination.LinkedDentalConsultations = that.dentalExaminationFormViewModel.GrdDentalExaminationGridList;
        for (let detailItem of that.dentalExaminationFormViewModel.GrdDentalExaminationGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.dentalExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        let procedureDoctorObjectID = that.dentalExaminationFormViewModel._DentalExamination['ProcedureDoctor'];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.dentalExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.dentalExaminationFormViewModel._DentalExamination.ProcedureDoctor = procedureDoctor;
            }
            that.dentalExaminationFormViewModel.ProcedureRequestFormResourceIDs.push(procedureDoctor.ObjectID);
        }

        if (this.dentalExaminationFormViewModel._DentalExamination.IsConsultation != null && this.dentalExaminationFormViewModel._DentalExamination.IsConsultation == true) {
            this.isConsultation = true;
        }

        this.controlDailyInpatient();
        that.dentalExaminationFormViewModel.ExaminationProcessAndEndDate = this.dentalExaminationFormViewModel.ExaminationProcessAndEndDate;
        this.dentalExaminationFormViewModel.ENabizViewModels = [];
    }

    async ngOnInit() {
        let that = this;
        await this.load(DentalExaminationFormViewModel);

        this.AddHelpMenu();
        //this.httpService.eNabizButtonSharedService.changeButtonVisible(true);

        //Parametre değeri TRUE ise Reçete tabının gizlenmesi sağlanıyor.
        let enableColorPrescriptionWithJSON: string = (await SystemParameterService.GetParameterValue('ENABLECOLORPRESCRIPTIONWITHJSON', 'FALSE'));
        if (enableColorPrescriptionWithJSON === 'TRUE') {
            this.enablePrescriptionTab = false;
        }
        else {
            this.enablePrescriptionTab = true;
        }
    }

    async ngAfterViewInit() {
        this.openSubscribers();
    }

    public openSubscribers() {
        let that = this;
        this.refreshReportGridSubscription = this.httpService.medicalStuffReportSharedService.medicalStuffReportUpdateObservable.subscribe(value => {
            this.reloadReportList();
        });
    }

    public async openEDurumBildirirReport() {
        if (this.CheckIsDiagnosisExistsForReports(this.dentalExaminationFormViewModel.DiagnosisGridGridList) == false) {
            ServiceLocator.MessageService.showError("Hasta üzerinde kayıtlı bir tanı olmadan Rapor yazamazsınız.!");
            return;
        }
        let parameterValue = await this.helpMenuService.getEDurumBildirirParameter();
        if (parameterValue)
            this.showEDurumBildirirComponent = true;
        else {
            this.helpMenuService.openEDurumBildirirReportPopUp(this.dentalExaminationFormViewModel._DentalExamination.ObjectID.toString());
        }
    }

    public ngOnDestroy(): void {
        if (this.refreshReportGridSubscription != null) {
            this.refreshReportGridSubscription.unsubscribe();
            this.refreshReportGridSubscription = null;
        }
        this.RemoveMenuFromHelpMenu();
        this.OnDestroy.emit();
        //this.httpService.eNabizButtonSharedService.changeButtonVisible(false);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('colorPrescription');
        this.sideBarMenuService.removeMenu('openprosthesisreport');
        this.sideBarMenuService.removeMenu('openConstantprosthesisreport');
        this.sideBarMenuService.removeMenu('toothExtractionReport');
        this.sideBarMenuService.removeMenu('opendentalrootreport');
        this.sideBarMenuService.removeMenu('commitmentForm');
        this.sideBarMenuService.removeMenu('orthodonticsForm');
        this.sideBarMenuService.removeMenu('treatmentDecision');
        this.sideBarMenuService.removeMenu('dailyInpatient');
        this.sideBarMenuService.removeMenu('greenList');
        this.sideBarMenuService.removeMenu('greenListSearch');
        this.sideBarMenuService.removeMenu('createEDurumBildirirReport');
        this.sideBarMenuService.removeMenu('openEDurumBildirirReportIndex');
    }


    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let createEDurumBildirirReport = new DynamicSidebarMenuItem();
        createEDurumBildirirReport.key = 'createEDurumBildirirReport';
        createEDurumBildirirReport.icon = 'fa fa-plus';
        createEDurumBildirirReport.label = 'E-Durum Bildirir Raporu Yaz';
        createEDurumBildirirReport.componentInstance = this;
        createEDurumBildirirReport.clickFunction = this.openEDurumBildirirReport;
        createEDurumBildirirReport.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        createEDurumBildirirReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('SaglikBakanligiRaporlari', createEDurumBildirirReport);
        let openEDurumBildirirReportIndex = new DynamicSidebarMenuItem();
        openEDurumBildirirReportIndex.key = 'openEDurumBildirirReportIndex';
        openEDurumBildirirReportIndex.icon = 'fa fa-list';
        openEDurumBildirirReportIndex.label = 'E-Durum Bildirir Raporu Index';
        openEDurumBildirirReportIndex.componentInstance = this;
        openEDurumBildirirReportIndex.clickFunction = this.helpMenuService.OpenEDurumBildirirIndex;
        openEDurumBildirirReportIndex.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        openEDurumBildirirReportIndex.ParentInstance = this;
        this.sideBarMenuService.addMenu('SaglikBakanligiRaporlari', openEDurumBildirirReportIndex);

        if (this.dentalExaminationFormViewModel.isNewMHRS) {
            let addgreenList_New = new DynamicSidebarMenuItem();
            addgreenList_New.key = 'addgreenList_New';
            addgreenList_New.icon = 'ai ai-addlist ';
            addgreenList_New.label = "Yeşil Listeye Ekle/Güncelle(180 Gün)";
            addgreenList_New.componentInstance = this.helpMenuService;
            addgreenList_New.clickFunction = this.helpMenuService.addMHRSGreenList_New;
            addgreenList_New.parameterFunctionInstance = this;
            addgreenList_New.getParamsFunction = this.getClickFunctionParams;
            addgreenList_New.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', addgreenList_New);

            let searchgreenList_New = new DynamicSidebarMenuItem();
            searchgreenList_New.key = 'searchgreenList_New';
            searchgreenList_New.icon = 'ai ai-checkist';
            searchgreenList_New.label = "Yeşil Liste Sorgula";
            searchgreenList_New.componentInstance = this.helpMenuService;
            searchgreenList_New.clickFunction = this.helpMenuService.searchMHRSGreenList_New;
            searchgreenList_New.parameterFunctionInstance = this;
            searchgreenList_New.getParamsFunction = this.getClickFunctionParams;
            searchgreenList_New.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', searchgreenList_New);

        } else {

            let greenList = new DynamicSidebarMenuItem();
            greenList.key = 'greenList';
            greenList.icon = 'ai ai-addlist ';
            greenList.label = i18n("M24637", "Yeşil Listeye Ekle(90 Gün)");
            greenList.componentInstance = this.helpMenuService;
            greenList.clickFunction = this.helpMenuService.addMHRSGreenList;
            greenList.parameterFunctionInstance = this;
            greenList.getParamsFunction = this.getClickFunctionParams;
            greenList.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', greenList);

            let greenListSearch = new DynamicSidebarMenuItem();
            greenListSearch.key = 'greenListSearch';
            greenListSearch.icon = 'ai ai-checkist';
            greenListSearch.label = i18n("M24638", "Yeşil Listeye Ekle/Onayla(Kronik Hasta)");
            greenListSearch.componentInstance = this.helpMenuService;
            greenListSearch.clickFunction = this.helpMenuService.searchAddAproveMHRSGreenList;
            greenListSearch.parameterFunctionInstance = this;
            greenListSearch.getParamsFunction = this.getClickFunctionParams;
            greenListSearch.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', greenListSearch);
        }

        let colorPrescription = new DynamicSidebarMenuItem();
        colorPrescription.key = 'colorPrescription';
        colorPrescription.componentInstance = this;
        colorPrescription.label = 'Reçete';
        colorPrescription.icon = 'ai ai-recete';
        colorPrescription.clickFunction = this.colorPresClick;
        this.sideBarMenuService.addMenu('YardimciMenu', colorPrescription);

        let openprosthesisreport = new DynamicSidebarMenuItem();
        openprosthesisreport.key = 'openprosthesisreport';
        openprosthesisreport.componentInstance = this;
        openprosthesisreport.label = 'Hareketli Protez Rıza Bilgisi';
        openprosthesisreport.icon = 'fa fa-file-text-o';
        openprosthesisreport.clickFunction = this.openProsthesisPatientInfoReport;
        this.sideBarMenuService.addMenu('YardimciMenu', openprosthesisreport);

        let openConstantprosthesisreport = new DynamicSidebarMenuItem();
        openConstantprosthesisreport.key = 'openConstantprosthesisreport';
        openConstantprosthesisreport.componentInstance = this;
        openConstantprosthesisreport.label = 'Sabit Protez Rıza Bilgisi';
        openConstantprosthesisreport.icon = 'fa fa-file-text-o';
        openConstantprosthesisreport.clickFunction = this.openConstantProsthesisPatientInfoReport;
        this.sideBarMenuService.addMenu('YardimciMenu', openConstantprosthesisreport);

        let opendentalrootreport = new DynamicSidebarMenuItem();
        opendentalrootreport.key = 'opendentalrootreport';
        opendentalrootreport.icon = 'fa fa-file-text-o';
        opendentalrootreport.componentInstance = this;
        opendentalrootreport.label = 'Dolgu-Kanal Rıza Bilgisi';
        opendentalrootreport.clickFunction = this.openRootCanalInfoReport;
        this.sideBarMenuService.addMenu('YardimciMenu', opendentalrootreport);

        let toothExtractionReport = new DynamicSidebarMenuItem();
        toothExtractionReport.key = 'toothExtractionReport';
        toothExtractionReport.icon = 'fa fa-file-text-o';
        toothExtractionReport.componentInstance = this;
        toothExtractionReport.label = 'Diş Çekimi Rıza Bilgisi';
        toothExtractionReport.clickFunction = this.openToothExtractionInfoReport;
        this.sideBarMenuService.addMenu('YardimciMenu', toothExtractionReport);

        let orthodonticsForm = new DynamicSidebarMenuItem();
        orthodonticsForm.key = 'orthodonticsForm';
        orthodonticsForm.icon = 'fa fa-file-text-o';
        orthodonticsForm.label = i18n("M19801", "Ortodonti Formu");
        orthodonticsForm.clickFunction = this.ttButtonOrtodontiForm_Click;
        this.sideBarMenuService.addMenu('YardimciMenu', orthodonticsForm);

        let commitmentForm = new DynamicSidebarMenuItem();
        commitmentForm.key = 'commitmentForm';
        commitmentForm.icon = 'fa fa-file-text-o';
        commitmentForm.label = i18n("M12941", "Diş Taahhüt Formu");
        commitmentForm.componentInstance = this;
        commitmentForm.clickFunction = this.ttButtonTaahhut_Click;
        this.sideBarMenuService.addMenu('YardimciMenu', commitmentForm);

        let treatmentDecision = new DynamicSidebarMenuItem();
        treatmentDecision.key = 'treatmentDecision';
        treatmentDecision.icon = 'fa fa-stethoscope';
        treatmentDecision.label = i18n("M22996", "Tedavi Kararı");
        treatmentDecision.componentInstance = this;
        treatmentDecision.clickFunction = this.btnNewTreatmentDischarge_Click;
        treatmentDecision.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', treatmentDecision);

        if (this._DentalExamination.CurrentStateDefID == DentalExamination.DentalExaminationStates.ExaminationCompleted) {
            let dailyInpatient = new DynamicSidebarMenuItem();
            dailyInpatient.key = 'dailyInpatient';
            dailyInpatient.icon = 'fas fa-bed';
            dailyInpatient.label = 'Günübirlik Yatış Başlat';
            dailyInpatient.componentInstance = this;
            dailyInpatient.clickFunction = this.onDailyOperationClick;
            dailyInpatient.parameterFunctionInstance = this;
            dailyInpatient.getParamsFunction = this.getClickFunctionParams;
            dailyInpatient.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', dailyInpatient);
        }

    }

    openProsthesisPatientInfoReport() {
        const objectIdParam = new GuidParam(this.dentalExaminationFormViewModel._DentalExamination.ObjectID);
        let reportParameters: any = { 'DentalExaminationObject': objectIdParam };
        this.reportService.showReport('DentalMovableProsthesisInfoReport', reportParameters);
    }

    openConstantProsthesisPatientInfoReport() {
        const objectIdParam = new GuidParam(this.dentalExaminationFormViewModel._DentalExamination.ObjectID);
        let reportParameters: any = { 'DentalExaminationObject': objectIdParam };
        this.reportService.showReport('DentalConstantProsthesisInfoReport', reportParameters);
    }

    openToothExtractionInfoReport() {
        const objectIdParam = new GuidParam(this.dentalExaminationFormViewModel._DentalExamination.ObjectID);
        let reportParameters: any = { 'DentalExaminationObject': objectIdParam };
        this.reportService.showReport('ToothExtractionInfoReport', reportParameters);
    }

    openRootCanalInfoReport() {
        const objectIdParam = new GuidParam(this.dentalExaminationFormViewModel._DentalExamination.ObjectID);
        let reportParameters: any = { 'DentalExaminationObject': objectIdParam };
        this.reportService.showReport('DentalRootCanalOperationInfoReport', reportParameters);
    }
    public oncmbTriajCodeChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.TriajCode !== event) {
                this._DentalExamination.TriajCode = event;
            }
        }
    }

    public onDentalExaminationFile1Changed(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.DentalExaminationFile !== event) {
                this._DentalExamination.DentalExaminationFile = event;
            }
        } else {
            this._DentalExamination.DentalExaminationFile = "";
        }
    }

    public onDoctorChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.ProcedureDoctor !== event) {
                this._DentalExamination.ProcedureDoctor = event;
            }
        }
    }

    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.Emergency !== event) {
                this._DentalExamination.Emergency = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.MasterResource !== event) {
                this._DentalExamination.MasterResource = event;
            }
        }
    }

    public onProcessTimeChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.ProcessTime !== event) {
                this._DentalExamination.ProcessTime = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.ProtocolNo !== event) {
                this._DentalExamination.ProtocolNo = event;
            }
        }
    }

    public onttChkBoxGeneralAnesthesiaChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.GeneralAnesthesia !== event) {
                this._DentalExamination.GeneralAnesthesia = event;
            }
        }
        this.ttChkBoxGeneralAnesthesia_CheckedChanged();
    }

    public onTTListBoxDrAnesteziTescilNoChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.ResUser !== event) {
                this._DentalExamination.ResUser = event;
            }
        }
        this.TTListBoxDrAnesteziTescilNo_SelectedObjectChanged();
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.OzelDurum !== event) {
                this._DentalExamination.OzelDurum = event;
            }
        }
    }

    public onRequestDescriptionChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.RequestDescription != event) {
                this._DentalExamination.RequestDescription = event;
            }
        }
    }

    DentalProsthesis_CellValueChangedEmitted(data: any) {
        if (data && this.DentalProsthesis_CellValueChanged && data.Row && data.Column) {
            this.DentalProsthesis.CurrentCell = {
                OwningRow: data.Row,
                OwningColumn: data.Column
            };
            this.DentalProsthesis_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    ttgrid3_CellValueChangedEmitted(data: any) {
        if (data && this.ttgrid3_CellValueChanged && data.Row && data.Column) {
            this.ttgrid3.CurrentCell = {
                OwningRow: data.Row,
                OwningColumn: data.Column
            };
            this.ttgrid3_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    public onExaminationProcedureDoctorChanged(event): void {
        let user: TTUser = TTUser.CurrentUser;
        if (!user.IsSuperUser) {
            if (this.dentalExaminationFormViewModel.hasSavedDiagnosis) {
                throw new TTException('Tanısı girilmiş işlemin sorumlu doktorunu sadece super user türündeki kullanıcılar değiştirebilir.');
            }
        }
        if (this._DentalExamination != null && this._DentalExamination.ProcedureDoctor !== event) {
            this._DentalExamination.ProcedureDoctor = event;
            TTUser.CurrentUser.ResponsibleSpecialist = <ResUser>event;
        }
    }
    public onRequesterDoctorChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.RequesterDoctor != event) {
                this._DentalExamination.RequesterDoctor = event;
            }
        }
    }
    public onFromResourceChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.MasterResource != event) {
                this._DentalExamination.MasterResource = event;
            }
        }
    }

    public onProcessDateChanged(event): void {
        if (event != null) {
            let processDate: Date = new Date(event);
            if (this._DentalExamination != null && this._DentalExamination.ProcessDate != processDate) {
                this._DentalExamination.ProcessDate = processDate;
            }
        }
    }

    public onConsultationResultAndOffersChanged(event): void {
        if (event != null) {
            if (this._DentalExamination != null && this._DentalExamination.ConsultationResultAndOffers != event) {
                this._DentalExamination.ConsultationResultAndOffers = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.ProcessTime, 'Value', this.__ttObject, 'ProcessTime');
        redirectProperty(this.ProtocolNo, 'Text', this.__ttObject, 'ProtocolNo');
        redirectProperty(this.cmbTriajCode, 'Value', this.__ttObject, 'TriajCode');
        redirectProperty(this.Emergency, 'Value', this.__ttObject, 'Emergency');
        redirectProperty(this.ttChkBoxGeneralAnesthesia, 'Value', this.__ttObject, 'GeneralAnesthesia');
        redirectProperty(this.DentalExaminationFile1, 'Rtf', this.__ttObject, 'DentalExaminationFile');
        redirectProperty(this.ConsultationResultAndOffers, "Rtf", this.__ttObject, "ConsultationResultAndOffers");
        redirectProperty(this.RequestDescription, "Rtf", this.__ttObject, "RequestDescription");
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "ProcessDate");

    }

    public initFormControls(): void {
        this.RequesterDoctor = new TTVisual.TTObjectListBox();
        this.RequesterDoctor.ReadOnly = true;
        this.RequesterDoctor.ListDefName = "ResUserListDefinition";
        this.RequesterDoctor.Name = "RequesterDoctor";
        this.RequesterDoctor.TabIndex = 0;

        this.FromResource = new TTVisual.TTObjectListBox();
        this.FromResource.ReadOnly = true;
        this.FromResource.ListDefName = "ResourceListDefinition";
        this.FromResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FromResource.Name = "FromResource";
        this.FromResource.TabIndex = 5;

        this.RequestDescription = new TTVisual.TTRichTextBoxControl();
        this.RequestDescription.DisplayText = i18n("M16609", "İstek Açıklaması");
        this.RequestDescription.TemplateGroupName = i18n("M17755", "Konsültasyon İstek Açıklaması");
        this.RequestDescription.BackColor = "#DCDCDC";
        this.RequestDescription.Name = "RequestDescription";
        this.RequestDescription.TabIndex = 10;
        this.RequestDescription.ReadOnly = true;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        //this.ProcessDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "dd/MM/yyyy hh:mm";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        //this.ProcessDate.ReadOnly = true;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 3;

        this.ConsultationResultAndOffers = new TTVisual.TTRichTextBoxControl();
        this.ConsultationResultAndOffers.DisplayText = "Konsültasyon Sonuç Ve Önerileri";
        this.ConsultationResultAndOffers.TemplateGroupName = "Konsültasyon Sonuç Ve Önerileri";
        this.ConsultationResultAndOffers.BackColor = "#DCDCDC";
        this.ConsultationResultAndOffers.Name = "ConsultationResultAndOffers";
        this.ConsultationResultAndOffers.TabIndex = 11;




        this.ch3 = new TTVisual.TTCheckBox();
        this.ch3.Value = false;
        this.ch3.Title = i18n("M10740", "Alt Çene");
        this.ch3.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch3.Name = 'ch3';
        this.ch3.TabIndex = 59;

        this.panelTooth = new TTVisual.TTPanel();
        this.panelTooth.AutoSize = true;
        this.panelTooth.Text = '18';
        this.panelTooth.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.panelTooth.Name = 'panelTooth';
        this.panelTooth.TabIndex = 6;

        this.ch4 = new TTVisual.TTCheckBox();
        this.ch4.Value = false;
        this.ch4.Title = i18n("M21152", "Sağ Üst Çene");
        this.ch4.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch4.Name = 'ch4';
        this.ch4.TabIndex = 2;

        this.ttbutton2 = new TTVisual.TTButton();
        this.ttbutton2.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttbutton2.Name = 'ttbutton2';
        this.ttbutton2.TabIndex = 19;

        this.ch6 = new TTVisual.TTCheckBox();
        this.ch6.Value = false;
        this.ch6.Title = i18n("M21126", "Sağ Alt Çene");
        this.ch6.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch6.Name = 'ch6';
        this.ch6.TabIndex = 57;

        this.ttbutton1 = new TTVisual.TTButton();
        this.ttbutton1.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttbutton1.Name = 'ttbutton1';
        this.ttbutton1.TabIndex = 18;

        this.ch5 = new TTVisual.TTCheckBox();
        this.ch5.Value = false;
        this.ch5.Title = i18n("M22021", "Sol Üst Çene");
        this.ch5.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch5.Name = 'ch5';
        this.ch5.TabIndex = 3;

        this.ch18 = new TTVisual.TTCheckBox();
        this.ch18.Value = false;
        this.ch18.Title = '18';
        this.ch18.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch18.Name = 'ch18';
        this.ch18.TabIndex = 17;

        this.ch7 = new TTVisual.TTCheckBox();
        this.ch7.Value = false;
        this.ch7.Title = i18n("M22002", "Sol Alt Çene");
        this.ch7.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch7.Name = 'ch7';
        this.ch7.TabIndex = 58;

        this.ch17 = new TTVisual.TTCheckBox();
        this.ch17.Value = false;
        this.ch17.Title = '17';
        this.ch17.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch17.Name = 'ch17';
        this.ch17.TabIndex = 17;

        this.ch2 = new TTVisual.TTCheckBox();
        this.ch2.Value = false;
        this.ch2.Title = i18n("M23981", "Üst Çene");
        this.ch2.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch2.Name = 'ch2';
        this.ch2.TabIndex = 1;

        this.ch16 = new TTVisual.TTCheckBox();
        this.ch16.Value = false;
        this.ch16.Title = '16';
        this.ch16.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch16.Name = 'ch16';
        this.ch16.TabIndex = 17;

        this.ch1 = new TTVisual.TTCheckBox();
        this.ch1.Value = false;
        this.ch1.Title = i18n("M23631", "Tüm Ağız");
        this.ch1.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch1.Name = 'ch1';
        this.ch1.TabIndex = 0;

        this.ch15 = new TTVisual.TTCheckBox();
        this.ch15.Value = false;
        this.ch15.Title = '15';
        this.ch15.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch15.Name = 'ch15';
        this.ch15.TabIndex = 17;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = 'ResourceListDefinition';
        this.MasterResource.Name = 'MasterResource';
        this.MasterResource.TabIndex = 202;
        this.MasterResource.Visible = false;

        this.ch14 = new TTVisual.TTCheckBox();
        this.ch14.Value = false;
        this.ch14.Title = '14';
        this.ch14.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch14.Name = 'ch14';
        this.ch14.TabIndex = 17;

        this.ttbutton3 = new TTVisual.TTButton();
        this.ttbutton3.Text = i18n("M21824", "Sıraya Al");
        this.ttbutton3.Name = 'ttbutton3';
        this.ttbutton3.TabIndex = 21;

        this.ch13 = new TTVisual.TTCheckBox();
        this.ch13.Value = false;
        this.ch13.Title = '13';
        this.ch13.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch13.Name = 'ch13';
        this.ch13.TabIndex = 17;

        this.DentalProcessNew = new TTVisual.TTGrid();
        //this.DentalProcessNew.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.DentalProcessNew.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.DentalProcessNew.Name = 'DentalProcessNew';
        this.DentalProcessNew.TabIndex = 12;

        this.ch12 = new TTVisual.TTCheckBox();
        this.ch12.Value = false;
        this.ch12.Title = '12';
        this.ch12.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch12.Name = 'ch12';
        this.ch12.TabIndex = 17;

        this.ProdecureObject = new TTVisual.TTListBoxColumn();
        this.ProdecureObject.ListDefName = 'ProcedureListDefinition';
        this.ProdecureObject.ListFilterExpression = 'OBJECTDEFNAME IN (\'DENTALPROSTHESISDEFINITION\',\'DENTALTREATMENTDEFINITION\') AND ISACTIVE = 1';
        this.ProdecureObject.DisplayIndex = 0;
        this.ProdecureObject.HeaderText = i18n("M16818", "İşlem");
        this.ProdecureObject.Name = 'ProdecureObject';
        this.ProdecureObject.Width = 470;

        this.ch31 = new TTVisual.TTCheckBox();
        this.ch31.Value = false;
        this.ch31.Title = '31';
        this.ch31.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch31.Name = 'ch31';
        this.ch31.TabIndex = 17;

        this.ttbuttonPatoloji = new TTVisual.TTButton();
        this.ttbuttonPatoloji.Text = 'Patoloji';
        this.ttbuttonPatoloji.Name = 'ttbuttonPatoloji';
        this.ttbuttonPatoloji.TabIndex = 15;

        this.ch32 = new TTVisual.TTCheckBox();
        this.ch32.Value = false;
        this.ch32.Title = '32';
        this.ch32.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch32.Name = 'ch32';
        this.ch32.TabIndex = 17;

        this.ttbuttonBiyokimya = new TTVisual.TTButton();
        this.ttbuttonBiyokimya.Text = i18n("M11948", "Biyokimya");
        this.ttbuttonBiyokimya.Name = 'ttbuttonBiyokimya';
        this.ttbuttonBiyokimya.TabIndex = 14;

        this.ch75 = new TTVisual.TTCheckBox();
        this.ch75.Value = false;
        this.ch75.Title = '75';
        this.ch75.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch75.Name = 'ch75';
        this.ch75.TabIndex = 17;

        this.ttbuttonMikrobiyoloji = new TTVisual.TTButton();
        this.ttbuttonMikrobiyoloji.Text = i18n("M19026", "Mikrobiyoloji");
        this.ttbuttonMikrobiyoloji.Name = 'ttbuttonMikrobiyoloji';
        this.ttbuttonMikrobiyoloji.TabIndex = 17;

        this.ch33 = new TTVisual.TTCheckBox();
        this.ch33.Value = false;
        this.ch33.Title = '33';
        this.ch33.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch33.Name = 'ch33';
        this.ch33.TabIndex = 17;

        this.ttbuttonRadyoloji = new TTVisual.TTButton();
        this.ttbuttonRadyoloji.Text = i18n("M20653", "Radyoloji");
        this.ttbuttonRadyoloji.Name = 'ttbuttonRadyoloji';
        this.ttbuttonRadyoloji.TabIndex = 16;

        this.ch74 = new TTVisual.TTCheckBox();
        this.ch74.Value = false;
        this.ch74.Title = '74';
        this.ch74.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch74.Name = 'ch74';
        this.ch74.TabIndex = 17;

        this.ttbuttonTemizle = new TTVisual.TTButton();
        this.ttbuttonTemizle.Text = i18n("M16957", "İşlemleri temizle");
        this.ttbuttonTemizle.Name = 'ttbuttonTemizle';
        this.ttbuttonTemizle.TabIndex = 19;

        this.ch34 = new TTVisual.TTCheckBox();
        this.ch34.Value = false;
        this.ch34.Title = '34';
        this.ch34.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch34.Name = 'ch34';
        this.ch34.TabIndex = 17;

        this.ttbuttonPrescription = new TTVisual.TTButton();
        this.ttbuttonPrescription.Text = i18n("M20924", "Reçete");
        this.ttbuttonPrescription.Name = 'ttbuttonPrescription';
        this.ttbuttonPrescription.TabIndex = 10;

        this.ch81 = new TTVisual.TTCheckBox();
        this.ch81.Value = false;
        this.ch81.Title = '81';
        this.ch81.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch81.Name = 'ch81';
        this.ch81.TabIndex = 17;

        this.ttbuttonTopluIslemTamamla = new TTVisual.TTButton();
        this.ttbuttonTopluIslemTamamla.Text = i18n("M16956", "İşlemleri oluştur");
        this.ttbuttonTopluIslemTamamla.Name = 'ttbuttonTopluIslemTamamla';
        this.ttbuttonTopluIslemTamamla.TabIndex = 18;

        this.ch35 = new TTVisual.TTCheckBox();
        this.ch35.Value = false;
        this.ch35.Title = '35';
        this.ch35.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch35.Name = 'ch35';
        this.ch35.TabIndex = 17;

        this.ttlistviewDentalSpecialityList = new TTVisual.TTListView();
        this.ttlistviewDentalSpecialityList.MultiSelect = false;
        //this.ttlistviewDentalSpecialityList.View = View.List;
        this.ttlistviewDentalSpecialityList.Font = 'Name=Tahoma, Size=9,27, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlistviewDentalSpecialityList.Name = 'ttlistviewDentalSpecialityList';
        this.ttlistviewDentalSpecialityList.TabIndex = 13;
        this.ttlistviewDentalSpecialityList.Height = '250';

        this.ch73 = new TTVisual.TTCheckBox();
        this.ch73.Value = false;
        this.ch73.Title = '73';
        this.ch73.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch73.Name = 'ch73';
        this.ch73.TabIndex = 17;

        this.ttButtonHizmetKontrol = new TTVisual.TTButton();
        this.ttButtonHizmetKontrol.Text = i18n("M23558", "Toplu Hizmet Müstehaklık Kontrolü Yap");
        this.ttButtonHizmetKontrol.Name = 'ttButtonHizmetKontrol';
        this.ttButtonHizmetKontrol.TabIndex = 22;

        this.ch36 = new TTVisual.TTCheckBox();
        this.ch36.Value = false;
        this.ch36.Title = '36';
        this.ch36.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch36.Name = 'ch36';
        this.ch36.TabIndex = 17;

        this.ttButtonOrtodontiForm = new TTVisual.TTButton();
        this.ttButtonOrtodontiForm.Text = i18n("M19801", "Ortodonti Formu");
        this.ttButtonOrtodontiForm.Name = 'ttButtonOrtodontiForm';
        this.ttButtonOrtodontiForm.TabIndex = 3;

        this.ch82 = new TTVisual.TTCheckBox();
        this.ch82.Value = false;
        this.ch82.Title = '82';
        this.ch82.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch82.Name = 'ch82';
        this.ch82.TabIndex = 17;

        this.ttChkBoxGeneralAnesthesia = new TTVisual.TTCheckBox();
        this.ttChkBoxGeneralAnesthesia.Value = false;
        this.ttChkBoxGeneralAnesthesia.Title = i18n("M14679", "Genel Anestezi");
        this.ttChkBoxGeneralAnesthesia.Name = 'ttChkBoxGeneralAnesthesia';
        this.ttChkBoxGeneralAnesthesia.TabIndex = 8;

        this.ch37 = new TTVisual.TTCheckBox();
        this.ch37.Value = false;
        this.ch37.Title = '37';
        this.ch37.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch37.Name = 'ch37';
        this.ch37.TabIndex = 17;

        this.labelTriajCode = new TTVisual.TTLabel();
        this.labelTriajCode.Text = i18n("M23584", "Triaj Kodu");
        this.labelTriajCode.Name = 'labelTriajCode';
        this.labelTriajCode.TabIndex = 201;
        this.labelTriajCode.Visible = false;

        this.ch72 = new TTVisual.TTCheckBox();
        this.ch72.Value = false;
        this.ch72.Title = '72';
        this.ch72.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch72.Name = 'ch72';
        this.ch72.TabIndex = 17;

        this.cmbTriajCode = new TTVisual.TTEnumComboBox();
        this.cmbTriajCode.DataTypeName = 'TriajCode';
        this.cmbTriajCode.Name = 'cmbTriajCode';
        this.cmbTriajCode.TabIndex = 5;

        this.ch38 = new TTVisual.TTCheckBox();
        this.ch38.Value = false;
        this.ch38.Title = '38';
        this.ch38.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch38.Name = 'ch38';
        this.ch38.TabIndex = 17;

        this.TabExaminationType = new TTVisual.TTTabControl();
        this.TabExaminationType.Name = 'TabExaminationType';
        this.TabExaminationType.TabIndex = 20;

        this.ch48 = new TTVisual.TTCheckBox();
        this.ch48.Value = false;
        this.ch48.Title = '48';
        this.ch48.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch48.Name = 'ch48';
        this.ch48.TabIndex = 17;

        this.Examination = new TTVisual.TTTabPage();
        this.Examination.DisplayIndex = 0;
        this.Examination.TabIndex = 0;
        this.Examination.Text = i18n("M12914", "Diş Muayenesi");
        this.Examination.Name = 'Examination';

        this.ch71 = new TTVisual.TTCheckBox();
        this.ch71.Value = false;
        this.ch71.Title = '71';
        this.ch71.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch71.Name = 'ch71';
        this.ch71.TabIndex = 17;

        this.DentalExaminationFile1 = new TTVisual.TTRichTextBoxControl();
        this.DentalExaminationFile1.DisplayText = i18n("M12911", "Diş Muayene Dosyası");
        this.DentalExaminationFile1.TemplateGroupName = 'DENTALEXAMINATIONFILE';
        this.DentalExaminationFile1.Name = 'DentalExaminationFile1';
        this.DentalExaminationFile1.TabIndex = 0;

        this.ch83 = new TTVisual.TTCheckBox();
        this.ch83.Value = false;
        this.ch83.Title = '83';
        this.ch83.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch83.Name = 'ch83';
        this.ch83.TabIndex = 17;

        this.GridDiagnosisEntry = new TTVisual.TTTabPage();
        this.GridDiagnosisEntry.DisplayIndex = 1;
        this.GridDiagnosisEntry.TabIndex = 5;
        this.GridDiagnosisEntry.Text = i18n("M22736", "Tanı");
        this.GridDiagnosisEntry.Name = 'GridDiagnosisEntry';

        this.ch65 = new TTVisual.TTCheckBox();
        this.ch65.Value = false;
        this.ch65.Title = '65';
        this.ch65.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch65.Name = 'ch65';
        this.ch65.TabIndex = 17;

        this.SecDiagnosisGrid = new TTVisual.TTGrid();
        this.SecDiagnosisGrid.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.SecDiagnosisGrid.Text = i18n("M22736", "Tanı");
        this.SecDiagnosisGrid.Name = 'SecDiagnosisGrid';
        this.SecDiagnosisGrid.TabIndex = 0;

        this.ch84 = new TTVisual.TTCheckBox();
        this.ch84.Value = false;
        this.ch84.Title = '84';
        this.ch84.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch84.Name = 'ch84';
        this.ch84.TabIndex = 17;

        this.AddToHistory = new TTVisual.TTCheckBoxColumn();
        this.AddToHistory.DataMember = 'AddToHistory';
        this.AddToHistory.DisplayIndex = 0;
        this.AddToHistory.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.AddToHistory.Name = 'AddToHistory';
        this.AddToHistory.Width = 90;

        this.ch47 = new TTVisual.TTCheckBox();
        this.ch47.Value = false;
        this.ch47.Title = '47';
        this.ch47.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch47.Name = 'ch47';
        this.ch47.TabIndex = 17;

        this.SecToothNum = new TTVisual.TTEnumComboBoxColumn();
        this.SecToothNum.DataTypeName = 'ToothNumberEnum';
        this.SecToothNum.SortBy = SortByEnum.Value;
        this.SecToothNum.DataMember = 'ToothNumber';
        this.SecToothNum.DisplayIndex = 1;
        this.SecToothNum.HeaderText = i18n("M12916", "Diş Nu./Ağız Bölgesi");
        this.SecToothNum.Name = 'SecToothNum';
        this.SecToothNum.Visible = false;
        this.SecToothNum.Width = 100;

        this.ch85 = new TTVisual.TTCheckBox();
        this.ch85.Value = false;
        this.ch85.Title = '85';
        this.ch85.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch85.Name = 'ch85';
        this.ch85.TabIndex = 17;

        this.Diagnose = new TTVisual.TTListBoxColumn();
        this.Diagnose.AllowMultiSelect = true;
        this.Diagnose.ListDefName = 'DiagnosisListDefinition';
        this.Diagnose.DataMember = 'Diagnose';
        this.Diagnose.DisplayIndex = 2;
        this.Diagnose.HeaderText = i18n("M22736", "Tanı");
        this.Diagnose.Name = 'Diagnose';
        this.Diagnose.Width = 320;

        this.ch64 = new TTVisual.TTCheckBox();
        this.ch64.Value = false;
        this.ch64.Title = '64';
        this.ch64.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch64.Name = 'ch64';
        this.ch64.TabIndex = 17;

        this.IsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.IsMainDiagnose.DataMember = 'IsMainDiagnose';
        this.IsMainDiagnose.DisplayIndex = 3;
        this.IsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.IsMainDiagnose.Name = 'IsMainDiagnose';
        this.IsMainDiagnose.Width = 75;

        this.ch46 = new TTVisual.TTCheckBox();
        this.ch46.Value = false;
        this.ch46.Title = '46';
        this.ch46.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch46.Name = 'ch46';
        this.ch46.TabIndex = 17;

        this.ResponsibleUser = new TTVisual.TTListBoxColumn();
        this.ResponsibleUser.ListDefName = 'UserListDefinition';
        this.ResponsibleUser.DataMember = 'ResponsibleUser';
        this.ResponsibleUser.DisplayIndex = 4;
        this.ResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.ResponsibleUser.Name = 'ResponsibleUser';
        this.ResponsibleUser.ReadOnly = true;
        this.ResponsibleUser.Width = 200;

        this.ch45 = new TTVisual.TTCheckBox();
        this.ch45.Value = false;
        this.ch45.Title = '45';
        this.ch45.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch45.Name = 'ch45';
        this.ch45.TabIndex = 17;

        this.DiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.DiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.DiagnoseDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.DiagnoseDate.DataMember = 'DiagnoseDate';
        this.DiagnoseDate.DisplayIndex = 5;
        this.DiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.DiagnoseDate.Name = 'DiagnoseDate';
        this.DiagnoseDate.ReadOnly = true;
        this.DiagnoseDate.Width = 180;

        this.ch63 = new TTVisual.TTCheckBox();
        this.ch63.Value = false;
        this.ch63.Title = '63';
        this.ch63.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch63.Name = 'ch63';
        this.ch63.TabIndex = 17;

        this.ProcedureEntry = new TTVisual.TTTabPage();
        this.ProcedureEntry.DisplayIndex = 2;
        this.ProcedureEntry.TabIndex = 1;
        this.ProcedureEntry.Text = i18n("M12897", "Diş İşlemi");
        this.ProcedureEntry.Name = 'ProcedureEntry';

        this.ch44 = new TTVisual.TTCheckBox();
        this.ch44.Value = false;
        this.ch44.Title = '44';
        this.ch44.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch44.Name = 'ch44';
        this.ch44.TabIndex = 17;

        this.DentalProsthesis = new TTVisual.TTGrid();
        this.DentalProsthesis.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.DentalProsthesis.Name = 'DentalProsthesis';
        this.DentalProsthesis.TabIndex = 26;
        this.DentalProsthesis.Height = '250';
        this.DentalProsthesis.AllowUserToAddRows = false;
        this.DentalProsthesis.AllowUserToDeleteRows = true;

        this.ch62 = new TTVisual.TTCheckBox();
        this.ch62.Value = false;
        this.ch62.Title = '62';
        this.ch62.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch62.Name = 'ch62';
        this.ch62.TabIndex = 17;

        this.Mustehaklik = new TTVisual.TTButtonColumn();
        this.Mustehaklik.Text = i18n("M22125", "Sorgula");
        this.Mustehaklik.UseColumnTextForButtonValue = true;
        this.Mustehaklik.DisplayIndex = 0;
        this.Mustehaklik.HeaderText = i18n("M19361", "Müstehaklık");
        this.Mustehaklik.Name = 'Mustehaklik';
        this.Mustehaklik.Width = 100;

        this.ch43 = new TTVisual.TTCheckBox();
        this.ch43.Value = false;
        this.ch43.Title = '43';
        this.ch43.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch43.Name = 'ch43';
        this.ch43.TabIndex = 17;

        this.columnHastaOdeme = new TTVisual.TTCheckBoxColumn();
        this.columnHastaOdeme.DataMember = 'PatientPay';
        this.columnHastaOdeme.DisplayIndex = 1;
        this.columnHastaOdeme.HeaderText = i18n("M15290", "Hasta Ödeyecek");
        this.columnHastaOdeme.Name = 'columnHastaOdeme';
        this.columnHastaOdeme.Width = 100;

        this.ch61 = new TTVisual.TTCheckBox();
        this.ch61.Value = false;
        this.ch61.Title = '61';
        this.ch61.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch61.Name = 'ch61';
        this.ch61.TabIndex = 17;

        this.columnHizmetKaydedildi = new TTVisual.TTCheckBoxColumn();
        this.columnHizmetKaydedildi.DataMember = 'AccountRecordable';
        this.columnHizmetKaydedildi.DisplayIndex = 2;
        this.columnHizmetKaydedildi.HeaderText = i18n("M15873", "Hizmet Kaydedilebildi");
        this.columnHizmetKaydedildi.Name = 'columnHizmetKaydedildi';
        this.columnHizmetKaydedildi.Width = 100;
        this.columnHizmetKaydedildi.ReadOnly = true;

        this.ch42 = new TTVisual.TTCheckBox();
        this.ch42.Value = false;
        this.ch42.Title = '42';
        this.ch42.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch42.Name = 'ch42';
        this.ch42.TabIndex = 17;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = 'ProcedureListDefinition';
        this.ProcedureObject.ListFilterExpression = 'OBJECTDEFNAME IN (\'DENTALPROSTHESISDEFINITION\',\'DENTALTREATMENTDEFINITION\') AND ISACTIVE = 1';
        this.ProcedureObject.DataMember = 'ProcedureObject';
        this.ProcedureObject.DisplayIndex = 3;
        this.ProcedureObject.HeaderText = i18n("M16818", "İşlem");
        this.ProcedureObject.Name = 'ProcedureObject';
        this.ProcedureObject.Width = 400;

        this.cmbReportType = new TTVisual.TTEnumComboBox();
        this.cmbReportType.DataTypeName = 'ReportTypeEnum';
        this.cmbReportType.Name = 'cmbReportType';
        this.cmbReportType.TabIndex = 3;
        this.cmbReportType.ShowClearButton = true;

        this.ch51 = new TTVisual.TTCheckBox();
        this.ch51.Value = false;
        this.ch51.Title = '51';
        this.ch51.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch51.Name = 'ch51';
        this.ch51.TabIndex = 17;

        this.ProcedureDoctor = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctor.ListDefName = 'SpecialistDoctorListDefinition';
        this.ProcedureDoctor.DataMember = 'ProcedureDoctor';
        this.ProcedureDoctor.LinkedControlName = 'TeethMasterResource';
        this.ProcedureDoctor.LinkedRelationPath = 'USERRESOURCES.RESOURCE';
        this.ProcedureDoctor.DisplayIndex = 4;
        this.ProcedureDoctor.HeaderText = i18n("M16925", "İşlemi Yapan");
        this.ProcedureDoctor.Name = 'ProcedureDoctor';
        this.ProcedureDoctor.Width = 200;

        this.ExaminationProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ExaminationProcedureDoctor.ListDefName = 'SpecialistDoctorListDefinition';
        this.ExaminationProcedureDoctor.DataMember = 'ProcedureDoctor';
        this.ExaminationProcedureDoctor.LinkedControlName = 'TeethMasterResource';
        this.ExaminationProcedureDoctor.LinkedRelationPath = 'USERRESOURCES.RESOURCE';
        this.ExaminationProcedureDoctor.Name = 'ProcedureDoctor';
        this.ExaminationProcedureDoctor.Width = 200;
        this.ExaminationProcedureDoctor.TabIndex = 1;

        this.ch41 = new TTVisual.TTCheckBox();
        this.ch41.Value = false;
        this.ch41.Title = '41';
        this.ch41.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch41.Name = 'ch41';
        this.ch41.TabIndex = 17;

        this.ProsthesisToothNum = new TTVisual.TTEnumComboBoxColumn();
        this.ProsthesisToothNum.DataTypeName = 'ToothNumberEnum';
        this.ProsthesisToothNum.SortBy = SortByEnum.Value;
        this.ProsthesisToothNum.DataMember = 'ToothNumber';
        this.ProsthesisToothNum.Required = true;
        this.ProsthesisToothNum.DisplayIndex = 5;
        this.ProsthesisToothNum.HeaderText = i18n("M12916", "Diş Nu./Ağız Bölgesi");
        this.ProsthesisToothNum.Name = 'ProsthesisToothNum';
        this.ProsthesisToothNum.Width = 150;

        this.ch52 = new TTVisual.TTCheckBox();
        this.ch52.Value = false;
        this.ch52.Title = '52';
        this.ch52.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch52.Name = 'ch52';
        this.ch52.TabIndex = 17;

        this.AyniFarkliKesi = new TTVisual.TTListBoxColumn();
        this.AyniFarkliKesi.ListDefName = 'AyniFarkliKesiListDefinition';
        this.AyniFarkliKesi.DataMember = 'AyniFarkliKesi';
        this.AyniFarkliKesi.DisplayIndex = 6;
        this.AyniFarkliKesi.HeaderText = i18n("M11343", "Aynı Farklı Kesi");
        this.AyniFarkliKesi.Name = 'AyniFarkliKesi';
        this.AyniFarkliKesi.Width = 70;

        this.ch53 = new TTVisual.TTCheckBox();
        this.ch53.Value = false;
        this.ch53.Title = '53';
        this.ch53.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch53.Name = 'ch53';
        this.ch53.TabIndex = 17;

        this.Anomali = new TTVisual.TTCheckBoxColumn();
        this.Anomali.DataMember = 'Anomali';
        this.Anomali.DisplayIndex = 7;
        this.Anomali.HeaderText = 'Anomali';
        this.Anomali.Name = 'Anomali';
        this.Anomali.Width = 50;

        this.ch54 = new TTVisual.TTCheckBox();
        this.ch54.Value = false;
        this.ch54.Title = '54';
        this.ch54.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch54.Name = 'ch54';
        this.ch54.TabIndex = 17;

        this.OzelDurum = new TTVisual.TTListBoxColumn();
        this.OzelDurum.ListDefName = 'OzelDurumListDefinition';
        this.OzelDurum.DataMember = 'OzelDurum';
        this.OzelDurum.DisplayIndex = 8;
        this.OzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.OzelDurum.Name = 'OzelDurum';
        this.OzelDurum.Width = 50;

        this.ch55 = new TTVisual.TTCheckBox();
        this.ch55.Value = false;
        this.ch55.Title = '55';
        this.ch55.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch55.Name = 'ch55';
        this.ch55.TabIndex = 17;

        this.CokluOzelDurum = new TTVisual.TTButtonColumn();
        this.CokluOzelDurum.Text = i18n("M14796", "Giriş");
        this.CokluOzelDurum.UseColumnTextForButtonValue = true;
        this.CokluOzelDurum.DisplayIndex = 9;
        this.CokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.CokluOzelDurum.Name = 'CokluOzelDurum';
        this.CokluOzelDurum.Width = 50;

        this.ch28 = new TTVisual.TTCheckBox();
        this.ch28.Value = false;
        this.ch28.Title = '28';
        this.ch28.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch28.Name = 'ch28';
        this.ch28.TabIndex = 17;

        this.PatientPrice = new TTVisual.TTTextBoxColumn();
        this.PatientPrice.DataMember = 'PatientPrice';
        this.PatientPrice.DisplayIndex = 10;
        this.PatientPrice.HeaderText = i18n("M30514", 'Hasta Payı');
        this.PatientPrice.Name = 'PatientPrice';
        this.PatientPrice.ReadOnly = true;
        this.PatientPrice.Width = 50;

        this.ch11 = new TTVisual.TTCheckBox();
        this.ch11.Value = false;
        this.ch11.Title = '11';
        this.ch11.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch11.Name = 'ch11';
        this.ch11.TabIndex = 17;

        this.TeethMasterResource = new TTVisual.TTListBoxColumn();
        this.TeethMasterResource.ListDefName = 'ResourceListDefinition';
        this.TeethMasterResource.DataMember = 'MasterResource';
        this.TeethMasterResource.DisplayIndex = 11;
        this.TeethMasterResource.HeaderText = i18n("M12048", "Branş");
        this.TeethMasterResource.Name = 'TeethMasterResource';
        this.TeethMasterResource.Visible = false;
        this.TeethMasterResource.Width = 100;

        this.ch21 = new TTVisual.TTCheckBox();
        this.ch21.Value = false;
        this.ch21.Title = '21';
        this.ch21.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch21.Name = 'ch21';
        this.ch21.TabIndex = 17;

        this.DisKonsultasyonIstek = new TTVisual.TTTabPage();
        this.DisKonsultasyonIstek.DisplayIndex = 3;
        this.DisKonsultasyonIstek.TabIndex = 8;
        this.DisKonsultasyonIstek.Text = i18n("M24714", "Yönlendirme");
        this.DisKonsultasyonIstek.Name = 'DisKonsultasyonIstek';

        this.ch27 = new TTVisual.TTCheckBox();
        this.ch27.Value = false;
        this.ch27.Title = '27';
        this.ch27.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch27.Name = 'ch27';
        this.ch27.TabIndex = 17;

        this.DentalConsultation = new TTVisual.TTGrid();
        this.DentalConsultation.Name = 'DentalConsultation';
        this.DentalConsultation.TabIndex = 0;
        this.DentalConsultation.Height = '250';

        this.ch26 = new TTVisual.TTCheckBox();
        this.ch26.Value = false;
        this.ch26.Title = '26';
        this.ch26.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch26.Name = 'ch26';
        this.ch26.TabIndex = 17;

        this.KonsultasyonIstenenBirim = new TTVisual.TTListBoxColumn();
        this.KonsultasyonIstenenBirim.ListDefName = 'ResourceListDefinition';
        this.KonsultasyonIstenenBirim.DataMember = 'ConsultationDepartment';
        this.KonsultasyonIstenenBirim.DisplayIndex = 0;
        this.KonsultasyonIstenenBirim.HeaderText = i18n("M17765", "Konsültasyon İstenen Birim");
        this.KonsultasyonIstenenBirim.Name = 'KonsultasyonIstenenBirim';
        this.KonsultasyonIstenenBirim.Width = 250;

        this.ch25 = new TTVisual.TTCheckBox();
        this.ch25.Value = false;
        this.ch25.Title = '25';
        this.ch25.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch25.Name = 'ch25';
        this.ch25.TabIndex = 17;

        this.KonsultasyonIstekAciklamasi = new TTVisual.TTTextBoxColumn();
        this.KonsultasyonIstekAciklamasi.DataMember = 'RequestDescription';
        this.KonsultasyonIstekAciklamasi.DisplayIndex = 1;
        this.KonsultasyonIstekAciklamasi.HeaderText = i18n("M16609", "İstek Açıklaması");
        this.KonsultasyonIstekAciklamasi.Name = 'KonsultasyonIstekAciklamasi';
        this.KonsultasyonIstekAciklamasi.Width = 400;

        this.ch24 = new TTVisual.TTCheckBox();
        this.ch24.Value = false;
        this.ch24.Title = '24';
        this.ch24.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch24.Name = 'ch24';
        this.ch24.TabIndex = 17;

        this.SelectedToothNumbers = new TTVisual.TTTextBoxColumn();
        this.SelectedToothNumbers.DataMember = 'SelectedToothNumbers';
        this.SelectedToothNumbers.DisplayIndex = 2;
        this.SelectedToothNumbers.HeaderText = i18n("M21513", "Seçilen Dişler");
        this.SelectedToothNumbers.Name = 'SelectedToothNumbers';
        this.SelectedToothNumbers.ReadOnly = true;
        this.SelectedToothNumbers.Visible = false;
        this.SelectedToothNumbers.Width = 100;

        this.ch23 = new TTVisual.TTCheckBox();
        this.ch23.Value = false;
        this.ch23.Title = '23';
        this.ch23.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch23.Name = 'ch23';
        this.ch23.TabIndex = 17;

        this.TreatmentMatEnrty = new TTVisual.TTTabPage();
        this.TreatmentMatEnrty.DisplayIndex = 4;
        this.TreatmentMatEnrty.TabIndex = 2;
        this.TreatmentMatEnrty.Text = i18n("M21309", "Sarf");
        this.TreatmentMatEnrty.Name = 'TreatmentMatEnrty';

        this.ch22 = new TTVisual.TTCheckBox();
        this.ch22.Value = false;
        this.ch22.Title = '22';
        this.ch22.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ch22.Name = 'ch22';
        this.ch22.TabIndex = 17;

        this.UsedMaterials = new TTVisual.TTGrid();
        this.UsedMaterials.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.UsedMaterials.Name = 'UsedMaterials';
        this.UsedMaterials.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePickerColumn();
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.ActionDate.DataMember = 'ActionDate';
        this.ActionDate.DisplayIndex = 0;
        this.ActionDate.HeaderText = 'Tarih/Saat';
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.Width = 100;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = 'ConsumableMaterialAndDrugList';
        this.Material.DataMember = 'Material';
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = 'Material';
        this.Material.Width = 250;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Barcode';
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkodu';
        this.Barcode.Name = 'Barcode';
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTButtonColumn();
        this.DistributionType.DataMember = 'DistributionType';
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = 'Amount';
        this.Amount.DisplayIndex = 4;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = 'Amount';
        this.Amount.Width = 50;

        this.UBBCODE = new TTVisual.TTTextBoxColumn();
        this.UBBCODE.DataMember = 'UBBCode';
        this.UBBCODE.DisplayIndex = 5;
        this.UBBCODE.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCODE.Name = 'UBBCODE';
        this.UBBCODE.Width = 100;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = 'Note';
        this.Note.DisplayIndex = 6;
        this.Note.HeaderText = i18n("M19476", "Not");
        this.Note.Name = 'Note';
        this.Note.Width = 140;

        this.KodsuzMalzemeFiyati = new TTVisual.TTTextBoxColumn();
        this.KodsuzMalzemeFiyati.DataMember = 'KodsuzMalzemeFiyati';
        this.KodsuzMalzemeFiyati.DisplayIndex = 7;
        this.KodsuzMalzemeFiyati.HeaderText = i18n("M17688", "Kodsuz Malzeme Fiyatı");
        this.KodsuzMalzemeFiyati.Name = 'KodsuzMalzemeFiyati';
        this.KodsuzMalzemeFiyati.Visible = false;
        this.KodsuzMalzemeFiyati.Width = 100;

        this.MalzemeTuru = new TTVisual.TTListBoxColumn();
        this.MalzemeTuru.ListDefName = 'MalzemeTuruListDefinition';
        this.MalzemeTuru.DataMember = 'MalzemeTuru';
        this.MalzemeTuru.DisplayIndex = 8;
        this.MalzemeTuru.HeaderText = i18n("M18614", "Malzeme Türü");
        this.MalzemeTuru.Name = 'MalzemeTuru';
        this.MalzemeTuru.Visible = false;
        this.MalzemeTuru.Width = 100;

        this.Kdv = new TTVisual.TTTextBoxColumn();
        this.Kdv.DataMember = 'Kdv';
        this.Kdv.DisplayIndex = 9;
        this.Kdv.HeaderText = 'Kdv';
        this.Kdv.Name = 'Kdv';
        this.Kdv.Visible = false;
        this.Kdv.Width = 100;

        this.MalzemeBrans = new TTVisual.TTTextBoxColumn();
        this.MalzemeBrans.DataMember = 'MalzemeBrans';
        this.MalzemeBrans.DisplayIndex = 10;
        this.MalzemeBrans.HeaderText = i18n("M18556", "Malzeme Branş");
        this.MalzemeBrans.Name = 'MalzemeBrans';
        this.MalzemeBrans.Visible = false;
        this.MalzemeBrans.Width = 100;

        this.MalzemeSatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MalzemeSatinAlisTarihi.CustomFormat = 'MALZEMESATINALISTARIHI';
        this.MalzemeSatinAlisTarihi.DisplayIndex = 11;
        this.MalzemeSatinAlisTarihi.HeaderText = i18n("M18604", "Malzeme Satın Alış Tarihi");
        this.MalzemeSatinAlisTarihi.Name = 'MalzemeSatinAlisTarihi';
        this.MalzemeSatinAlisTarihi.Visible = false;
        this.MalzemeSatinAlisTarihi.Width = 100;

        this.UsedMaterials_OzelDurum = new TTVisual.TTListBoxColumn();
        this.UsedMaterials_OzelDurum.ListDefName = 'OzelDurumListDefinition';
        this.UsedMaterials_OzelDurum.DataMember = 'OzelDurum';
        this.UsedMaterials_OzelDurum.DisplayIndex = 12;
        this.UsedMaterials_OzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.UsedMaterials_OzelDurum.Name = 'UsedMaterials_OzelDurum';
        this.UsedMaterials_OzelDurum.Visible = false;
        this.UsedMaterials_OzelDurum.Width = 100;

        this.MedulaBilgileri = new TTVisual.TTTabPage();
        this.MedulaBilgileri.DisplayIndex = 5;
        this.MedulaBilgileri.TabIndex = 4;
        this.MedulaBilgileri.Text = 'Medula';
        this.MedulaBilgileri.Name = 'MedulaBilgileri';

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 10;

        this.MedulaDisBilgileriTab = new TTVisual.TTTabPage();
        this.MedulaDisBilgileriTab.DisplayIndex = 0;
        this.MedulaDisBilgileriTab.TabIndex = 0;
        this.MedulaDisBilgileriTab.Text = i18n("M18739", "Medula Diş Bilgileri");
        this.MedulaDisBilgileriTab.Name = 'MedulaDisBilgileriTab';

        this.TTListBoxDrAnesteziTescilNo = new TTVisual.TTObjectListBox();
        this.TTListBoxDrAnesteziTescilNo.ListDefName = 'ResUserListDefinition';
        this.TTListBoxDrAnesteziTescilNo.Name = 'TTListBoxDrAnesteziTescilNo';
        this.TTListBoxDrAnesteziTescilNo.TabIndex = 14;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = 'OzelDurumListDefinition';
        this.ttobjectlistbox1.Name = 'ttobjectlistbox1';
        this.ttobjectlistbox1.TabIndex = 13;

        this.labelDrAnesteziTescilNo = new TTVisual.TTLabel();
        this.labelDrAnesteziTescilNo.Text = i18n("M13345", "Dr Anestezi Tescil No");
        this.labelDrAnesteziTescilNo.Name = 'labelDrAnesteziTescilNo';
        this.labelDrAnesteziTescilNo.TabIndex = 11;

        this.ttgrid1 = new TTVisual.TTGrid();
        this.ttgrid1.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttgrid1.Name = 'ttgrid1';
        this.ttgrid1.TabIndex = 9;

        this.cokluOzelDurumColumn = new TTVisual.TTListBoxColumn();
        this.cokluOzelDurumColumn.ListDefName = 'OzelDurumListDefinition';
        this.cokluOzelDurumColumn.DataMember = 'OZELDURUM';
        this.cokluOzelDurumColumn.DisplayIndex = 0;
        this.cokluOzelDurumColumn.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.cokluOzelDurumColumn.Name = 'cokluOzelDurumColumn';
        this.cokluOzelDurumColumn.Width = 350;

        this.labelOzelDurum = new TTVisual.TTLabel();
        this.labelOzelDurum.Text = i18n("M20090", "Özel Durumu");
        this.labelOzelDurum.Name = 'labelOzelDurum';
        this.labelOzelDurum.TabIndex = 6;

        this.OnerilenIslemler = new TTVisual.TTTabPage();
        this.OnerilenIslemler.DisplayIndex = 6;
        this.OnerilenIslemler.TabIndex = 7;
        this.OnerilenIslemler.Text = i18n("M18144", "Lab İşlemleri");
        this.OnerilenIslemler.Name = 'OnerilenIslemler';

        this.ttgrid3 = new TTVisual.TTGrid();
        this.ttgrid3.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttgrid3.Name = 'ttgrid3';
        this.ttgrid3.TabIndex = 0;
        this.ttgrid3.Height = '250';

        this.ttdatetimepickercolumn1 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn1.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.ttdatetimepickercolumn1.DataMember = 'ActionDate';
        this.ttdatetimepickercolumn1.DisplayIndex = 0;
        this.ttdatetimepickercolumn1.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.ttdatetimepickercolumn1.Name = 'ttdatetimepickercolumn1';
        this.ttdatetimepickercolumn1.Width = 100;

        this.ttcheckboxcolumn1 = new TTVisual.TTCheckBoxColumn();
        this.ttcheckboxcolumn1.DataMember = 'Emergency';
        this.ttcheckboxcolumn1.DisplayIndex = 1;
        this.ttcheckboxcolumn1.HeaderText = 'Acil';
        this.ttcheckboxcolumn1.Name = 'ttcheckboxcolumn1';
        this.ttcheckboxcolumn1.Width = 30;

        this.SUGGESTEDPROSTHESISPROCEDURE = new TTVisual.TTObjectListBox();
        this.SUGGESTEDPROSTHESISPROCEDURE.ListDefName = 'DentalProsthesisListDefinition';
        this.SUGGESTEDPROSTHESISPROCEDURE.DataMember = 'SuggestedProsthesisProcedure';
        // this.SUGGESTEDPROSTHESISPROCEDURE.DisplayIndex = 2;
        //this.SUGGESTEDPROSTHESISPROCEDURE.HeaderText = i18n("M20027", "Önerilen Diş Protez");
        this.SUGGESTEDPROSTHESISPROCEDURE.Name = 'SUGGESTEDPROSTHESISPROCEDURE';
        this.SUGGESTEDPROSTHESISPROCEDURE.Width = '250px';

        this.CurrentState = new TTVisual.TTEnumComboBox();
        this.CurrentState.DataTypeName = 'DisDurumEnum';
        this.CurrentState.DataMember = 'CurrentState';
        //this.CurrentState.DisplayIndex = 3;
        //this.CurrentState.HeaderText = 'Durum';
        this.CurrentState.Name = 'CurrentState';
        //this.CurrentState.Width = 100;

        this.ProsthesisToothNumber = new TTVisual.TTEnumComboBox();
        this.ProsthesisToothNumber.DataTypeName = 'ToothNumberEnum';
        this.ProsthesisToothNumber.SortBy = SortByEnum.Value;
        this.ProsthesisToothNumber.DataMember = 'ToothNumber';
        //this.ProsthesisToothNumber.Required = true;
        //this.ProsthesisToothNumber.DisplayIndex = 4;
        //this.ProsthesisToothNumber.HeaderText = i18n("M12916", "Diş Nu./Ağız Bölgesi");
        this.ProsthesisToothNumber.Name = 'ProsthesisToothNumber';
        //this.ProsthesisToothNumber.Width = 110;

        this.ProsthesisDepartment = new TTVisual.TTObjectListBox();
        this.ProsthesisDepartment.ListDefName = 'ResourceListDefinition';
        this.ProsthesisDepartment.DataMember = 'Department';
        this.ProsthesisDepartment.LinkedControlName = 'SUGGESTEDPROSTHESISPROCEDURE';
        this.ProsthesisDepartment.LinkedRelationPath = 'DPDEPARTMENTGRIDS.DENTALPROSTHESISDEFINITION';
        //this.ProsthesisDepartment.DisplayIndex = 5;
        //this.ProsthesisDepartment.HeaderText = i18n("M20560", "Protez Birimi");
        this.ProsthesisDepartment.Name = 'ProsthesisDepartment';
        this.ProsthesisDepartment.Width = '175px';

        this.tttextboxcolumn1 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn1.DataMember = 'Definition';
        this.tttextboxcolumn1.DisplayIndex = 6;
        this.tttextboxcolumn1.HeaderText = i18n("M10469", "Açıklama");
        this.tttextboxcolumn1.Name = 'tttextboxcolumn1';
        this.tttextboxcolumn1.Width = 200;

        this.tttextboxcolumn2 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn2.DataMember = 'Color';
        this.tttextboxcolumn2.DisplayIndex = 7;
        this.tttextboxcolumn2.HeaderText = i18n("M21020", "Renk");
        this.tttextboxcolumn2.Name = 'tttextboxcolumn2';
        this.tttextboxcolumn2.Width = 100;

        this.EpisodeDiagnosis = new TTVisual.TTTabPage();
        this.EpisodeDiagnosis.DisplayIndex = 7;
        this.EpisodeDiagnosis.TabIndex = 6;
        this.EpisodeDiagnosis.Text = i18n("M24028", "Vaka Tanıları");
        this.EpisodeDiagnosis.Name = 'EpisodeDiagnosis';

        this.DiagnosisGrid = new TTVisual.TTGrid();
        this.DiagnosisGrid.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.DiagnosisGrid.ReadOnly = true;
        this.DiagnosisGrid.Text = i18n("M22736", "Tanı");
        this.DiagnosisGrid.Name = 'DiagnosisGrid';
        this.DiagnosisGrid.TabIndex = 6;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = 'AddToHistory';
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.EpisodeAddToHistory.Name = 'EpisodeAddToHistory';
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = 'DiagnosisListDefinition';
        this.EpisodeDiagnose.DataMember = 'Diagnose';
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = i18n("M22736", "Tanı");
        this.EpisodeDiagnose.Name = 'EpisodeDiagnose';
        this.EpisodeDiagnose.Width = 310;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = 'DiagnosisTypeEnum';
        this.EpisodeDiagnosisType.DataMember = 'DiagnosisType';
        this.EpisodeDiagnosisType.DisplayIndex = 2;
        this.EpisodeDiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.EpisodeDiagnosisType.Name = 'EpisodeDiagnosisType';
        this.EpisodeDiagnosisType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = 'IsMainDiagnose';
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.EpisodeIsMainDiagnose.Name = 'EpisodeIsMainDiagnose';
        this.EpisodeIsMainDiagnose.Width = 75;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = 'UserListDefinition';
        this.EpisodeResponsibleUser.DataMember = 'ResponsibleUser';
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.EpisodeResponsibleUser.Name = 'EpisodeResponsibleUser';
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.EpisodeDiagnoseDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.EpisodeDiagnoseDate.DataMember = 'DiagnoseDate';
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.EpisodeDiagnoseDate.Name = 'EpisodeDiagnoseDate';
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = 'ActionTypeEnum';
        this.EntryActionType.DataMember = 'EntryActionType';
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.EntryActionType.Name = 'EntryActionType';
        this.EntryActionType.Width = 100;

        this.OlduExaminations = new TTVisual.TTTabPage();
        this.OlduExaminations.DisplayIndex = 8;
        this.OlduExaminations.TabIndex = 9;
        this.OlduExaminations.Text = i18n("M13870", "Eski Muayeneleri");
        this.OlduExaminations.Name = 'OlduExaminations';

        this.OldDentalExaminationsGrid = new TTVisual.TTGrid();
        this.OldDentalExaminationsGrid.Name = 'OldDentalExaminationsGrid';
        this.OldDentalExaminationsGrid.TabIndex = 0;

        this.ExaminationDateTime = new TTVisual.TTDateTimePickerColumn();
        this.ExaminationDateTime.DisplayIndex = 0;
        this.ExaminationDateTime.HeaderText = i18n("M19222", "Muayene Tarihi");
        this.ExaminationDateTime.Name = 'ExaminationDateTime';
        this.ExaminationDateTime.ReadOnly = true;
        this.ExaminationDateTime.Width = 125;

        this.ExaminationIndication = new TTVisual.TTTextBoxColumn();
        this.ExaminationIndication.DisplayIndex = 1;
        this.ExaminationIndication.HeaderText = i18n("M19173", "Muayene Bulguları");
        this.ExaminationIndication.Name = 'ExaminationIndication';
        this.ExaminationIndication.Width = 360;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = '#F0F0F0';
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ProtocolNo.Name = 'ProtocolNo';
        this.ProtocolNo.TabIndex = 1;

        this.TriajColor = new TTVisual.TTTextBox();
        this.TriajColor.BackColor = '#F0F0F0';
        this.TriajColor.ReadOnly = true;
        this.TriajColor.Name = 'TriajColor';
        this.TriajColor.TabIndex = 6;

        this.ProcessTime = new TTVisual.TTDateTimePicker();
        this.ProcessTime.BackColor = '#F0F0F0';
        this.ProcessTime.CustomFormat = '';
        this.ProcessTime.Format = DateTimePickerFormat.Long;
        this.ProcessTime.Enabled = false;
        this.ProcessTime.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ProcessTime.Name = 'ProcessTime';
        this.ProcessTime.TabIndex = 0;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Title = 'Acil';
        this.Emergency.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Emergency.ForeColor = '#000000';
        this.Emergency.Name = 'Emergency';
        this.Emergency.TabIndex = 7;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M22534", "Tabip Adı");
        this.ttlabel11.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel11.ForeColor = '#000000';
        this.ttlabel11.Name = 'ttlabel11';
        this.ttlabel11.TabIndex = 68;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelProtocolNo.ForeColor = '#000000';
        this.labelProtocolNo.Name = 'labelProtocolNo';
        this.labelProtocolNo.TabIndex = 9;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M19251", "Muayenenin Yapıldığı Tarih");
        this.labelProcessTime.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelProcessTime.ForeColor = '#000000';
        this.labelProcessTime.Name = 'labelProcessTime';
        this.labelProcessTime.TabIndex = 3;

        this.Doctor = new TTVisual.TTObjectListBox();
        this.Doctor.Required = true;
        this.Doctor.LinkedControlName = 'MasterResource';
        this.Doctor.LinkedRelationPath = 'USERRESOURCES.RESOURCE';
        this.Doctor.ListDefName = 'SpecialistDoctorListDefinition';
        this.Doctor.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Doctor.Name = 'Doctor';
        this.Doctor.TabIndex = 2;

        this.btnNewTreatmentDischarge = new TTVisual.TTButton();
        this.btnNewTreatmentDischarge.Text = i18n("M22997", "Tedavi Kararı");
        this.btnNewTreatmentDischarge.Name = 'btnNewTreatmentDischarge';
        this.btnNewTreatmentDischarge.TabIndex = 4;

        this.ttButtonTaahhut = new TTVisual.TTButton();
        this.ttButtonTaahhut.Text = 'Taahhut Formu';
        this.ttButtonTaahhut.Name = 'ttButtonTaahhut';
        this.ttButtonTaahhut.TabIndex = 9;

        this.PrescriptionGrid = new TTVisual.TTGrid();
        this.PrescriptionGrid.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.PrescriptionGrid.Text = i18n("M20924", "Reçete");
        this.PrescriptionGrid.Name = 'PrescriptionGrid';
        this.PrescriptionGrid.AllowUserToAddRows = false;
        this.PrescriptionGrid.AllowUserToDeleteRows = false;
        this.PrescriptionGrid.TabIndex = 6;

        this.PhysicianDrug = new TTVisual.TTListBoxColumn();
        this.PhysicianDrug.AllowMultiSelect = false;
        this.PhysicianDrug.ListDefName = 'DrugList';
        this.PhysicianDrug.DataMember = 'Material';
        this.PhysicianDrug.DisplayIndex = 2;
        this.PhysicianDrug.HeaderText = i18n("M16287", "İlaç");
        this.PhysicianDrug.Name = 'PhysicianDrug';
        this.PhysicianDrug.Width = '50%';

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = 'FrequencyEnum';
        this.Frequency.DataMember = 'Frequency';
        this.Frequency.Required = true;
        this.Frequency.DisplayIndex = 5;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = 'Frequency';
        this.Frequency.Width = '10%';

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DataMember = 'DoseAmount';
        this.DoseAmount.DisplayIndex = 7;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = 'DoseAmount';
        this.DoseAmount.Width = '10%';

        this.Day = new TTVisual.TTTextBoxColumn();
        this.Day.DataMember = 'Day';
        this.Day.DisplayIndex = 7;
        this.Day.HeaderText = i18n("M17001", "K. Peryodu (Gün)");
        this.Day.Name = 'Day';
        this.Day.Width = '10%';

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = 'UsageNote';
        this.UsageNote.DisplayIndex = 7;
        this.UsageNote.HeaderText = i18n("M17992", "Kullanma Tarifi");
        this.UsageNote.Name = 'UsageNote';
        this.UsageNote.Width = '20%';



        this.txtReportName = new TTVisual.TTTextBoxColumn();
        this.txtReportName.DataMember = "ReportName";
        this.txtReportName.Name = "ReportName";
        this.txtReportName.ToolTipText = "ReportName";
        this.txtReportName.Width = "50%";
        this.txtReportName.DisplayIndex = 1;
        this.txtReportName.HeaderText = "Rapor";

        this.txtReportRequestReason = new TTVisual.TTTextBoxColumn();
        this.txtReportRequestReason.DataMember = "RequestReason";
        this.txtReportRequestReason.Name = "RequestReason";
        this.txtReportRequestReason.ToolTipText = "RequestReason";
        this.txtReportRequestReason.Width = "20%";
        this.txtReportRequestReason.DisplayIndex = 1;
        this.txtReportRequestReason.HeaderText = "İstek Nedeni";

        this.txtReportAdmissionDate = new TTVisual.TTTextBoxColumn();
        this.txtReportAdmissionDate.DataMember = "AdmissionDate";
        this.txtReportAdmissionDate.Name = "AdmissionDate";
        this.txtReportAdmissionDate.ToolTipText = "AdmissionDate";
        this.txtReportAdmissionDate.Width = "10%";
        this.txtReportAdmissionDate.DisplayIndex = 1;
        this.txtReportAdmissionDate.HeaderText = "Kabul Tarihi";

        this.txtReportMasterResource = new TTVisual.TTTextBoxColumn();
        this.txtReportMasterResource.DataMember = "MasterResource";
        this.txtReportMasterResource.Name = "MasterResource";
        this.txtReportMasterResource.ToolTipText = "MasterResource";
        this.txtReportMasterResource.Width = "20%";
        this.txtReportMasterResource.DisplayIndex = 1;
        this.txtReportMasterResource.HeaderText = "Birim";


        this.txtStartDate = new TTVisual.TTTextBoxColumn();
        this.txtStartDate.DataMember = "StartDate";
        this.txtStartDate.Name = "StartDate";
        this.txtStartDate.ToolTipText = "StartDate";
        this.txtStartDate.Width = "20%";
        this.txtStartDate.DisplayIndex = 0;
        this.txtStartDate.HeaderText = i18n("M11637", "Başlangıç Tarihi");

        this.txtEndDate = new TTVisual.TTTextBoxColumn();
        this.txtEndDate.DataMember = "EndDate";
        this.txtEndDate.Name = "EndDate";
        this.txtEndDate.ToolTipText = "EndDate";
        this.txtEndDate.Width = "20%";
        this.txtEndDate.DisplayIndex = 0;
        this.txtEndDate.HeaderText = i18n("M11939", "Bitiş Tarihi");

        this.btnEdit = new TTVisual.TTButtonColumn();
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Width = "10%";
        this.btnEdit.DisplayIndex = 0;
        this.btnEdit.HeaderText = i18n("M13405", "Düzenle");
        this.GridPatientReportsColumns = [this.txtReportName, this.txtReportRequestReason, this.txtReportAdmissionDate, this.txtReportMasterResource, this.txtStartDate, this.txtEndDate, this.btnEdit];


        this.PrescriptionGridColumns = [
            {
                caption: ' ',
                dataField: 'ObjectId',
                cellTemplate: 'buttonCellTemplate',
                width: 50
            },
            {
                'caption': i18n("M16886", "İşlem Tarihi"),
                dataField: 'ActionDate',
                allowSorting: true,
                dataType: 'date'
            },
            {
                'caption': i18n("M10469", "Açıklama"),
                dataField: 'Description',
                allowSorting: true
            },
            {
                'caption': i18n("M13814", "E-Reçete Durumu"),
                dataField: 'EReceteStatus',
                allowSorting: true
            }
        ];
        this.DentalProcessNewColumns = [this.ProdecureObject];
        this.SecDiagnosisGridColumns = [this.AddToHistory, this.SecToothNum, this.Diagnose, this.IsMainDiagnose, this.ResponsibleUser, this.DiagnoseDate];
        this.DentalProsthesisColumns = [this.Mustehaklik, this.columnHastaOdeme, this.columnHizmetKaydedildi, this.ProcedureObject, this.ProcedureDoctor,
        this.ProsthesisToothNum, this.AyniFarkliKesi, this.Anomali, /*this.OzelDurum, this.CokluOzelDurum,*/ this.PatientPrice, this.TeethMasterResource];
        this.DentalConsultationColumns = [this.KonsultasyonIstenenBirim, this.KonsultasyonIstekAciklamasi, this.SelectedToothNumbers];
        this.UsedMaterialsColumns = [this.ActionDate, this.Material, this.Barcode, this.DistributionType, this.Amount, this.UBBCODE, this.Note,
        this.KodsuzMalzemeFiyati, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.MalzemeSatinAlisTarihi, this.UsedMaterials_OzelDurum];
        this.ttgrid1Columns = [this.cokluOzelDurumColumn];
        this.ttgrid3Columns = [this.ttdatetimepickercolumn1, this.ttcheckboxcolumn1, this.SUGGESTEDPROSTHESISPROCEDURE, this.CurrentState,
        this.ProsthesisToothNumber, this.ProsthesisDepartment, this.tttextboxcolumn1, this.tttextboxcolumn2];
        this.DiagnosisGridColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose,
        this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.OldDentalExaminationsGridColumns = [this.ExaminationDateTime, this.ExaminationIndication];
        this.panelTooth.Controls = [this.ch3, this.ch4, this.ttbutton2, this.ch6, this.ttbutton1, this.ch5, this.ch18, this.ch7, this.ch17,
        this.ch2, this.ch16, this.ch1, this.ch15, this.ch14, this.ch13, this.ch12, this.ch31, this.ch32, this.ch75, this.ch33, this.ch74, this.ch34,
        this.ch81, this.ch35, this.ch73, this.ch36, this.ch82, this.ch37, this.ch72, this.ch38, this.ch48, this.ch71, this.ch83, this.ch65, this.ch84,
        this.ch47, this.ch85, this.ch64, this.ch46, this.ch45, this.ch63, this.ch44, this.ch62, this.ch43, this.ch61, this.ch42, this.ch51, this.ch41,
        this.ch52, this.ch53, this.ch54, this.ch55, this.ch28, this.ch11, this.ch21, this.ch27, this.ch26, this.ch25, this.ch24, this.ch23, this.ch22];
        this.TabExaminationType.Controls = [this.Examination, this.GridDiagnosisEntry, this.ProcedureEntry, this.DisKonsultasyonIstek,
        this.TreatmentMatEnrty, this.MedulaBilgileri, this.OnerilenIslemler, this.EpisodeDiagnosis, this.OlduExaminations];
        this.Examination.Controls = [this.DentalExaminationFile1];
        this.GridDiagnosisEntry.Controls = [this.SecDiagnosisGrid];
        this.ProcedureEntry.Controls = [this.DentalProsthesis];
        this.DisKonsultasyonIstek.Controls = [this.DentalConsultation];
        this.TreatmentMatEnrty.Controls = [this.UsedMaterials];
        this.MedulaBilgileri.Controls = [this.tttabcontrol1];
        this.tttabcontrol1.Controls = [this.MedulaDisBilgileriTab];
        this.MedulaDisBilgileriTab.Controls = [this.TTListBoxDrAnesteziTescilNo, this.ttobjectlistbox1, this.labelDrAnesteziTescilNo, this.ttgrid1, this.labelOzelDurum];
        this.OnerilenIslemler.Controls = [this.ttgrid3];
        this.EpisodeDiagnosis.Controls = [this.DiagnosisGrid];
        this.OlduExaminations.Controls = [this.OldDentalExaminationsGrid];
        this.Controls = [this.ExaminationProcedureDoctor, this.ConsultationResultAndOffers, this.RequestDate, this.RequestDescription, this.FromResource, this.RequesterDoctor, this.ch3, this.panelTooth, this.ch4, this.ttbutton2, this.ch6, this.ttbutton1, this.ch5, this.ch18, this.ch7, this.ch17,
        this.ch2, this.ch16, this.ch1, this.ch15, this.MasterResource, this.ch14, this.ttbutton3, this.ch13, this.DentalProcessNew, this.ch12,
        this.ProdecureObject, this.ch31, this.ttbuttonPatoloji, this.ch32, this.ttbuttonBiyokimya, this.ch75, this.ttbuttonMikrobiyoloji, this.ch33,
        this.ttbuttonRadyoloji, this.ch74, this.ttbuttonTemizle, this.ch34, this.ttbuttonPrescription, this.ch81, this.ttbuttonTopluIslemTamamla,
        this.ch35, this.ttlistviewDentalSpecialityList, this.ch73, this.ttButtonHizmetKontrol, this.ch36, this.ttButtonOrtodontiForm, this.ch82,
        this.ttChkBoxGeneralAnesthesia, this.ch37, this.labelTriajCode, this.ch72, this.cmbTriajCode, this.ch38, this.TabExaminationType, this.ch48,
        this.Examination, this.ch71, this.DentalExaminationFile1, this.ch83, this.GridDiagnosisEntry, this.ch65, this.SecDiagnosisGrid, this.ch84,
        this.AddToHistory, this.ch47, this.SecToothNum, this.ch85, this.Diagnose, this.ch64, this.IsMainDiagnose, this.ch46, this.ResponsibleUser,
        this.ch45, this.DiagnoseDate, this.ch63, this.ProcedureEntry, this.ch44, this.DentalProsthesis, this.ch62, this.Mustehaklik, this.ch43,
        this.columnHastaOdeme, this.ch61, this.columnHizmetKaydedildi, this.ch42, this.ProcedureObject, this.ch51, this.ProcedureDoctor, this.ch41,
        this.ProsthesisToothNum, this.ch52, this.AyniFarkliKesi, this.ch53, this.Anomali, this.ch54, this.OzelDurum, this.ch55, this.CokluOzelDurum,
        this.ch28, this.PatientPrice, this.ch11, this.TeethMasterResource, this.ch21, this.DisKonsultasyonIstek, this.ch27, this.DentalConsultation,
        this.ch26, this.KonsultasyonIstenenBirim, this.ch25, this.KonsultasyonIstekAciklamasi, this.ch24, this.SelectedToothNumbers, this.ch23,
        this.TreatmentMatEnrty, this.ch22, this.UsedMaterials, this.ActionDate, this.Material, this.Barcode, this.DistributionType, this.Amount,
        this.UBBCODE, this.Note, this.KodsuzMalzemeFiyati, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.MalzemeSatinAlisTarihi,
        this.UsedMaterials_OzelDurum, this.MedulaBilgileri, this.tttabcontrol1, this.MedulaDisBilgileriTab, this.TTListBoxDrAnesteziTescilNo,
        this.ttobjectlistbox1, this.labelDrAnesteziTescilNo, this.ttgrid1, this.cokluOzelDurumColumn, this.labelOzelDurum, this.OnerilenIslemler,
        this.ttgrid3, this.ttdatetimepickercolumn1, this.ttcheckboxcolumn1, this.SUGGESTEDPROSTHESISPROCEDURE, this.CurrentState,
        this.ProsthesisToothNumber, this.ProsthesisDepartment, this.tttextboxcolumn1, this.tttextboxcolumn2, this.EpisodeDiagnosis, this.DiagnosisGrid,
        this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser,
        this.EpisodeDiagnoseDate, this.EntryActionType, this.OlduExaminations, this.OldDentalExaminationsGrid, this.ExaminationDateTime,
        this.ExaminationIndication, this.ProtocolNo, this.TriajColor, this.ProcessTime, this.Emergency, this.ttlabel11, this.labelProtocolNo,
        this.labelProcessTime, this.Doctor, this.btnNewTreatmentDischarge, this.ttButtonTaahhut];

    }
    public async onSelectedReportOpen(data: any) {
        if (this.CheckIsDiagnosisExistsForReports(this.dentalExaminationFormViewModel.DiagnosisGridGridList) == false) {
            ServiceLocator.MessageService.showError("Hasta üzerinde kayıtlı bir tanı olmadan Rapor yazamazsınız.!");
            return;
        }
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this.dentalExaminationFormViewModel._DentalExamination.ObjectID, this.dentalExaminationFormViewModel._DentalExamination.Episode.ObjectID, this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient.ObjectID);

        if (data.code === ReportTypeEnum.DrugReport) {
            if (!(await EpisodeActionService.CheckInvoicedCompletely(this._DentalExamination.ObjectID)))
                this.onParticipatientReportOpen(null);
            else
                ServiceLocator.MessageService.showError("Faturası Kesilmiş Hastalara İlaç Raporu Yazamazsınız");
        }
        else if (data.code === ReportTypeEnum.TreatmentReport) {
            //if (await EpisodeActionService.CheckProvision()) {
            this.onMedulaTreatmentReportOpen(null);
            /*} else {
                TTVisual.InfoBox.Alert("Hastanın Takip Numarası Yoktur. Medula Tedavi Raporu Yazılamaz");
            }*/
        }
        else if (data.code === ReportTypeEnum.OtherReport) {
            this.onStatusNotificationReportOpen(null);
        } else if (data.code === ReportTypeEnum.MedicalStuffReport) {
            this.onMedicalStuffReportOpen(null);
        }
    }

    onMedicalStuffReportOpen(episodeAction: any) {
        if (episodeAction == null) {
            this.objectContextService.getNewObject<MedicalStuffReport>(MedicalStuffReport.ObjectDefID, MedicalStuffReport).then(result => {
                let medicalStuffReport: MedicalStuffReport = result;

                // tslint:disable-next-line:no-shadowed-variable
                this.showMedicalStuffReport(medicalStuffReport).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as MedicalStuffReport;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        }
        else {
            this.objectContextService.getObject<MedicalStuffReport>(episodeAction, MedicalStuffReport.ObjectDefID, MedicalStuffReport).then(result => {
                let medicalStuffReport: MedicalStuffReport = result;

                // tslint:disable-next-line:no-shadowed-variable
                this.showMedicalStuffReport(medicalStuffReport).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as MedicalStuffReport;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        }


    }

    private showMedicalStuffReport(data: MedicalStuffReport): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'MedicalStuffReportForm';
            componentInfo.ModuleName = 'TibbiMalzemeModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tibbi_Malzeme_Modulu/TibbiMalzemeModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._DentalExamination.ObjectID, this._DentalExamination.Episode.ObjectID, this._DentalExamination.Episode.Patient.ObjectID));
            componentInfo.ParentInstance = this;
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M23409", "Tıbbi Malzeme Raporu");
            /*modalInfo.Width = 1300;
            modalInfo.Height = 900;*/
            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                let add: boolean = true;
                let report: MedicalStuffReport = inner.Param as MedicalStuffReport;
                //for (let item of this.patientExaminationDoctorFormNewViewModel.PatientReportInfoList) {
                //    if (item.ObjectID == report.ObjectID) {
                //        item.EndDate = (report.EndDate != null || report.EndDate != undefined) ? this.toShortDateStringWithDot(report.EndDate) : null;
                //        item.StartDate = this.toShortDateStringWithDot(report.StartDate);
                //        add = false;
                //    }
                //    else if (report.ObjectID == null)
                //        add = false;
                //}
                //if (add) {
                //    let patientReportInfo: PatientReportInfo = new PatientReportInfo();
                //    patientReportInfo.ObjectID = report.ObjectID;
                //    patientReportInfo.ObjectDefName = "MEDICALSTUFFREPORT";
                //    patientReportInfo.ID = (report.ID != null || report.ID != undefined) ? report.ID.toString() : null;
                //    patientReportInfo.StartDate = this.toShortDateStringWithDot(report.StartDate);
                //    patientReportInfo.EndDate = (report.EndDate != null || report.EndDate != undefined) ? this.toShortDateStringWithDot(report.EndDate) : null;
                //    patientReportInfo.ReportName = "Tıbbi Malzeme Raporu";
                //    that.patientExaminationDoctorFormNewViewModel.PatientReportInfoList.push(patientReportInfo);
                //}
            }).catch(err => {
                reject(err);
            });
        });
    }

    onMedulaTreatmentReportOpen(episodeAction: any) {
        /*  if (this.dentalExaminationFormViewModel.IsAuthorizedToWriteTreatmentReport == false) {
              this.messageService.showInfo(i18n("M23021", "Tedavi raporu yazmaya yetkili bir uzmanlık dalına sahip değilsiniz, Rapor yazamazsınız!"));
              return;
          }*/

        if (episodeAction == null) {
            this.showMedulaTreatmentReport(null);
        }
        else {
            this.objectContextService.getObject<MedulaTreatmentReport>(episodeAction, MedulaTreatmentReport.ObjectDefID, MedulaTreatmentReport).then(result => {
                let temp: MedulaTreatmentReport = result;
                temp = result;
                this.showMedulaTreatmentReport(temp);
            });
        }
    }
    private showMedulaTreatmentReport(data: MedulaTreatmentReport) {
        this.showMedulaTedaviRaporlariForm = true;

        this.medulaTedaviRaporlariObject = data as MedulaTreatmentReport;
    }

    onParticipatientReportOpen(episodeAction: any) {
        let temp;

        if (episodeAction == null) {
            this.showParticipatnFreeDrugReport(null);
        }
        else {
            this.objectContextService.getObject<ParticipatnFreeDrugReport>(episodeAction, ParticipatnFreeDrugReport.ObjectDefID, ParticipatnFreeDrugReport).then(result => {
                let temp: ParticipatnFreeDrugReport = result;
                temp = result;
                this.showParticipatnFreeDrugReport(temp);
            });
        }
    }
    private showParticipatnFreeDrugReport(data: ParticipatnFreeDrugReport) {
        this.showParticipationFreeDrugReportNewForm = true;

        this.ParticipationFreeDrugReportNewFormObject = data as ParticipatnFreeDrugReport;
    }

    async onStatusNotificationReportForm(event: any) {
        this.showStatusNotificationReportForm = false;
    }

    onStatusNotificationReportOpen(episodeAction: any) {
        let temp;
        if (episodeAction == null) {
            this.showStatusNotificationReport(null);
        }
        else {
            this.objectContextService.getObject<StatusNotificationReport>(episodeAction, StatusNotificationReport.ObjectDefID, StatusNotificationReport).then(result => {
                let temp: StatusNotificationReport = result;
                temp = result;
                this.showStatusNotificationReport(temp);
            });
        }
    }
    private showStatusNotificationReport(data: StatusNotificationReport) {
        this.showStatusNotificationReportForm = true;

        this.statusNotificationReportObject = data as StatusNotificationReport;


    }


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        let message: string = await DentalExaminationService.Paid(this._DentalExamination.ObjectID);
        if (message !== '') {
            ServiceLocator.MessageService.showError(message);
            //TTVisual.InfoBox.Alert(message);
        }
        if (this.dentalExaminationFormViewModel.GrdExternalConsultationGridList && this.dentalExaminationFormViewModel.GrdExternalConsultationGridList.length > 0) {
            for (let extConsultation of this.dentalExaminationFormViewModel.GrdExternalConsultationGridList) {
                try {
                    let extConsultationObjectID = extConsultation['ObjectID'];
                    if (extConsultationObjectID != null && (typeof extConsultationObjectID === 'string')) {
                        const objectIdParam = new GuidParam(extConsultationObjectID);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                        this.reportService.showReport("ConsultationFromExternalHospitalReport", reportParameters);
                    }
                } catch (err) {
                    ServiceLocator.MessageService.showError(err);
                }
            }
        }
        await super.AfterContextSavedScript(transDef);


        if (this.requestedProceduresFormInstance != undefined && this.requestedProceduresFormInstance.operationControl === true) {
            this.loadingVisible = true;
            await this.requestedProceduresFormInstance.DailyOperationsSave(this.dentalExaminationFormViewModel._DentalExamination);
        }

        else if (this.treatmentMaterialFormInstance != undefined && this.treatmentMaterialFormInstance.operationControl === true) {
            this.loadingVisible = true;
            await this.treatmentMaterialFormInstance.DailyOperationsSave(this.dentalExaminationFormViewModel._DentalExamination);
        }

        this.loadingVisible = false;

        await this.load(DentalExaminationFormViewModel);


    }
    async OnMedulaTedaviRaporlariFormClosing(e) {
        if (e == true)
            this.showMedulaTedaviRaporlariForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient + '&subepisodeObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.dentalExaminationFormViewModel.PatientReportInfoList = res;*/
    }

    async OnParticipationFreeDrugReportNewFormClosing(e) {
        if (e == true)
            this.showParticipationFreeDrugReportNewForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient + '&subepisodeObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.dentalExaminationFormViewModel.PatientReportInfoList = res;*/
    }

    async onParticipationFreeDrugReportNewForm(event: any) {
        this.showParticipationFreeDrugReportNewForm = false;
        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient + '&subepisodeObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.dentalExaminationFormViewModel.PatientReportInfoList = res;*/
    }

    public async onShowCancelledReports(val: any): Promise<void> {
        if (val.value != null) {

            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient + '&subepisodeObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.SubEpisode + '&includedCancelledReports=' + val.value + '&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.dentalExaminationFormViewModel.PatientReportInfoList = res;
        }
    }
    public async onShowAllReports(val: any): Promise<void> {
        if (val.value != null) {
            this.currentActionReports = !(val.value);
            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient + '&subepisodeObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.dentalExaminationFormViewModel.PatientReportInfoList = res;
        }
    }

    async OnStatusNotificationReportFormClosing(e) {
        //this.showStatusNotificationReportForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.Episode.Patient + '&subepisodeObjectID=' + this.dentalExaminationFormViewModel._DentalExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.dentalExaminationFormViewModel.PatientReportInfoList = res;*/
    }

    public setENabizViewModel(viewModels: Array<any>) {

        for (let i = 0; i < viewModels.length; i++) {
            this.dentalExaminationFormViewModel.ENabizViewModels.push(viewModels[i]);
        }

    }

    public async btnAppointment_Click() {
        try {
            let result = await this.showAppointmentForm(null);
            if (result.Result === DialogResult.Cancel) {
                ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
                return;
            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

}
