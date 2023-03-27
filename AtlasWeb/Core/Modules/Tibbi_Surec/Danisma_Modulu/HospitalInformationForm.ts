//$D7562D09
import { Component, OnInit, NgZone } from '@angular/core';
import { HospitalInformationFormViewModel, PersonnelSearchModel, LocationSearchModel, VisitorSearchModel, AppointmentSearchModel, ExaminationSearchingResultModel, ExaminationSearchModel } from './HospitalInformationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { HospitalInformation, UserTitleEnum, UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { AppointmentResultModel } from './HospitalInformationResultModels/AppointmentResultModel';

import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientVisitor } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { RequirementExecutor } from "Fw/Requirements/RequirementExecutor";
import { PersonnelWorkItemSearchModel } from "../Personel_Entegrasyon_Modulu/Models/PersonnelWorkItemSearchModel";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import List from 'app/NebulaClient/System/Collections/List';
import { RequestOptions } from '@angular/http';


export enum InformationTabs {
    PatientInformation = 1,
    PersonnelInformation,
    LocationInformation,
    AppointmentInformation,
    ShiftInformation,
    RemunerationInformation,
    VisitorRecord,
    Announcements,
    ExaminationInformation,
}

@Component({
    selector: 'HospitalInformationForm',
    templateUrl: './HospitalInformationForm.html',
    providers: [MessageService, SystemApiService]
})
export class HospitalInformationForm extends TTVisual.TTForm implements OnInit {

    AppointmentBithDatePicker: TTVisual.ITTDateTimePicker;
    AppointmentDateEndPicker: TTVisual.ITTDateTimePicker;
    AppointmentDateStartPicker: TTVisual.ITTDateTimePicker;
    AppointmentGrid: TTVisual.ITTGrid;
    AppointmentPatientBirthCityTextbox: TTVisual.ITTTextBox;
    AppointmentPatientDoctorTextbox: TTVisual.TTObjectListBox;
    AppointmentPatientFatherNameTextbox: TTVisual.ITTTextBox;
    AppointmentPatientIdentifyTextbox: TTVisual.ITTTextBox;
    AppointmentPatientMotherNameTextbox: TTVisual.ITTTextBox;
    AppointmentPatientNameTextbox: TTVisual.ITTTextBox;
    AppointmentPatientNoTextbox: TTVisual.ITTTextBox;
    AppointmentPatientSurnameTextbox: TTVisual.ITTTextBox;
    AppointmentSearchTab: TTVisual.ITTTabPage;
    BirthDatePerson: TTVisual.ITTDateTimePicker;
    BuildingTTListBox: TTVisual.ITTObjectListBox;
    CityOfBirthPerson: TTVisual.ITTObjectListBox;
    ClearButton: TTVisual.ITTButton;
    DischargeDatePicker: TTVisual.ITTDateTimePicker;
    FatherNamePerson: TTVisual.ITTTextBox;
    IDPatient: TTVisual.ITTTextBox;
    InformationTab: TTVisual.ITTTabControl;

    InPatientGrid: TTVisual.ITTGrid;
    isTodayCheckBox: TTVisual.ITTCheckBox;

    LocationGrid: TTVisual.ITTGrid;

    LocationTab: TTVisual.ITTTabPage;
    MotherNamePerson: TTVisual.ITTTextBox;
    NamePerson: TTVisual.ITTTextBox;
    PassportNoPerson: TTVisual.ITTTextBox;
    PatientAdmissionDatePicker: TTVisual.ITTDateTimePicker;
    PatientInformation: TTVisual.ITTTabPage;
    PatientPatientVisitor: TTVisual.ITTObjectListBox;
    PersonnelDepartmentTextbox: TTVisual.TTObjectListBox;
    PersonnelGrid: TTVisual.ITTGrid;
    PersonnelInformation: TTVisual.ITTTabPage;

    PersonnelMissionTextbox: TTVisual.TTObjectListBox;

    PersonnelNameTextbox: TTVisual.ITTTextBox;

    PersonnelSectionTextbox: TTVisual.TTObjectListBox;
    PersonnelShiftDepartmentTextbox: TTVisual.ITTTextBox;
    PersonnelShiftMissionTextbox: TTVisual.ITTTextBox;
    PersonnelShiftNameTextbox: TTVisual.ITTTextBox;
    PersonnelShiftSectionTextbox: TTVisual.ITTTextBox;
    PersonnelShiftSurnameTextbox: TTVisual.ITTTextBox;
    PersonnelShiftTab: TTVisual.ITTTabPage;
    PersonnelShiftTitleTextbox: TTVisual.ITTTextBox;
    PersonnelSurnameTextbox: TTVisual.ITTTextBox;
    PersonnelTitleTextbox: TTVisual.TTObjectListBox;
    PolyclinicTTListBox: TTVisual.ITTObjectListBox;
    protected _ttList: Array<any>;
    RemunerationTab: TTVisual.ITTTabPage;
    SearchButton: TTVisual.ITTButton;
    SexPerson: TTVisual.ITTObjectListBox;
    StandingPatientGrid: TTVisual.ITTGrid;
    SurnamePerson: TTVisual.ITTTextBox;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttgrid1: TTVisual.ITTGrid;
    ttgrid2: TTVisual.ITTGrid;

    UniqueRefNoPerson: TTVisual.ITTTextBox;
    VisitorBirthCity: TTVisual.ITTObjectListBox;
    VisitorBirthDatePatientVisitor: TTVisual.ITTDateTimePicker;
    VisitorEnterDatePatientVisitor: TTVisual.ITTDateTimePicker;
    VisitorExitDatePatientVisitor: TTVisual.ITTDateTimePicker;
    VisitorFatherNamePatientVisitor: TTVisual.ITTTextBox;
    VisitorMotherNamePatientVisitor: TTVisual.ITTTextBox;
    VisitorNamePatientVisitor: TTVisual.ITTTextBox;
    VisitorNotePatientVisitor: TTVisual.ITTTextBox;
    VisitorPhoneNumberPatientVisitor: TTVisual.TTMaskedTextBox;
    VisitorRelationStatePatientVisitor: TTVisual.ITTTextBox;
    VisitorSex: TTVisual.ITTObjectListBox;
    VisitorSurnamePatientVisitor: TTVisual.ITTTextBox;
    VisitorTab: TTVisual.ITTTabPage;
    VisitorUnicRefIdPatientVisitor: TTVisual.ITTTextBox;
    btnInfo: TTVisual.ITTButtonColumn;


    public AppointmentGridColumns = [];
    public InPatientGridColumns = [];
    public LocationGridColumns = [];
    public PersonnelGridColumns = [];
    public StandingPatientGridColumns = [];
    public ttgrid1Columns = [];
    public ttgrid2Columns = [];
    public hospitalInformationFormViewModel: HospitalInformationFormViewModel = new HospitalInformationFormViewModel();
    public _PersonnelGridSearchResult: Array<any> = [];
    public _LocationGridSearchResult: Array<any> = [];
    public _AppointmentGridSearchResult: Array<any> = [];

    public _PatientVisitorGridSearchResult: Array<any> = [];
    public _AppointmentSearchingResultList: Array<AppointmentResultModel> = [];
    isInPatientSelected: boolean = false;
    public imageSource = "../../Content/PatientAdmission/avatar_unknown.png";

    public selectedPersonnelInfo = null;
    public UserTitleDataSource = UserTitleEnum.Items;
    public UserTypeDataSource = UserTypeEnum.Items;

    public VisitorGridSearchingColumns = [
        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientFullName",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M30005", "Hasta Tc Kimlk No"),
            dataField: "PatientCitizenID",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M30006", "Hasta Telefon No"),
            dataField: "PatientPhoneNumber",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M24783", "Ziyaretçi Adı Soyadı"),
            dataField: "VisitorFullName",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M23135", "Telefon No"),
            dataField: "VisitorPhoneNumber",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M24253", "Yakınlık Derecesi"),
            dataField: "VisitorRelationState",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M19476", "Not"),
            dataField: "Note",
            width: 200,
            allowSorting: true
        }
    ];

    public LocationGridSearchingColumns = [
        {
            caption: i18n("M30007", "Birim"),
            dataField: "Policlinic",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M23135", "Telefon No"),
            dataField: "Phone",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M18351", "Lokasyon Bilgisi"),
            dataField: "LocationInfo",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M15120", "Harita Çıktısı"),
            dataField: "map",
            width: 200,
            allowSorting: true
        }
    ];
    public AppointmentGridSearchingColumns = [
        {
            caption: i18n("M30004", "Tc Kimlk No"),
            dataField: "UniqueRefNo",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M10517", "Adı Soyadı"),
            dataField: "PatientFullName",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M20715", "Randevu Alınan"),
            dataField: "AppointmentObjectFullName",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M11037", "Anne Adı"),
            dataField: "MotherName",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M11390", "Baba Adı"),
            dataField: "FatherName",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M20740", "Randevu Tarihi"),
            dataField: "AppointmentDate",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M30007", "Birim"),
            dataField: "AppointmentSection",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M11872", "Birim Telefon No"),
            dataField: "AppointmentSectionPhone",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M11865", "Birim Lokasyonu"),
            dataField: "AppointmentSectionLocation",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M10469", "Açıklama"),
            dataField: "AppointmentDefinition",
            width: 200,
            allowSorting: true
        }
    ];
    public PersonnelGridSearchingColumns = [

        {
            caption: i18n("M10514", "Adı"),
            dataField: "Name",
            width: 'auto',
            allowSorting: true
        },
        {
            caption: i18n("M22205", "Soyadı"),
            dataField: "Surname",
            width: 'auto',
            allowSorting: true
        },
        {
            caption: i18n("M12048", "Branş"),
            dataField: "Department",
            width: 150,
            allowSorting: true
        },
      /*  {
            caption: i18n("M12048", "Bölüm"),
            dataField: "Section",
            width: 150,
            allowSorting: true
        },*/
        {
            caption: 'Bölüm',
            dataField: '',
            cellTemplate: 'detailButtonTemplate',
            Name: 'btnInfo',
            width: 60
            //width: 400
        },
        {
            caption: i18n("M14910", "Görev"),
            dataField: "Mission",
            width: 'auto',
            allowSorting: true
        },
        {
            caption: i18n("M23932", "Ünvan"),
            dataField: "Title",
            width: 'auto',
            allowSorting: true
        },
        {
            caption: i18n("M12198", "Cep Telefonu"),
            dataField: "PhoneNumber",
            width: 'auto',
            allowSorting: true
        },
        {
            caption: i18n("M12336", "Çalıştığı Yer"),
            dataField: "WorkPlace",
            width: 'auto',
            allowSorting: true
        },
        {
            caption: i18n("M12336", "Göreve Başlama Tarihi"),
            dataField: "DateOfJoin",
            width: 'auto',
            allowSorting: true,
            dataType: 'date', 
            format: 'dd.MM.yyyy'
        },
        {
            caption: i18n("M12336", "Görev Bitiş Tarihi"),
            dataField: "DateOfLeave",
            width: 'auto',
            allowSorting: true,
            dataType: 'date', 
            format: 'dd.MM.yyyy'
        }
        
    ];

    public ExaminationSearchingColumns = [

        {
            caption: i18n("M21815", "Sıra Numarası"),
            dataField: "AdmissionQueueNo",
            dataType: 'string',
            width: 150,
            allowSorting: true,
            //sortOrder: 'asc',
            //sortIndex: 1,
            //cssClass: 'worklistGridCellFont'
        },
        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: 150,
            minWidth: 150,
            allowSorting: true
        },
        {
            caption: i18n("M22514", "T.C. Kimlik Numarası"),
            dataField: "UniqueRefno",
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
    /*    {
            caption: i18n("M17021", "Kabul No"),
            dataField: "KabulNo",
            dataType: 'string',
            width: 150,
            allowSorting: true
        },

        {
            "caption": i18n("M16838", "İşlem Durumu"),
            dataField: "StateName",
            dataType: 'string',
            width: 150,
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        },
        {
            caption: "Protokol No",
            dataField: "ExaminationProtocolNo",
            dataType: 'string',
            width: 150,
            visible: true,
            allowSorting: true
        }
        ,
        {
            caption: i18n("M27339", "Doktoru"),
            dataField: "DoctorName",
            dataType: 'string',
            width: 150,
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        }, */
        {
            caption: i18n("M27339", "Tahmini Muayene Saati"),
            dataField: "ExpectedExaminationTime",
            dataType: 'string',
            width: 150,
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        }

    ];

    public SectionInformationColumns = [
        {
            caption: i18n("M11865", "Birim"),
            dataField: "SectionName",
            width: 250,
            allowSorting: true
        },
        {
            caption: i18n("M10469", "Durum"),
            dataField: "SectionStatus",
            width: 100,
            allowSorting: true
        }
    ];
    public get _HospitalInformation(): HospitalInformation {
        return this._TTObject as HospitalInformation;
    }

    //MMMM
    reqResultCode: RequirementResultCode;
    reqExecutor: RequirementExecutor;
    selectedTab: InformationTabs = InformationTabs.PatientInformation;


    private HospitalInformationForm_DocumentUrl: string = '/api/HospitalInformationService/HospitalInformationForm';
    constructor(protected http: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone,
        protected httpService: NeHttpService,
        public systemApiService: SystemApiService) {
        super('HOSPITALINFORMATION', 'HospitalInformationForm');
        this._DocumentServiceUrl = this.HospitalInformationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    keyDownForNumericControl(event: any) {

        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }

    private updateAvatarPhoto(Patient: any): void {

        if (this.hospitalInformationFormViewModel._RecordPatientVisitor.Patient.Sex != null) {
            if (this.hospitalInformationFormViewModel._RecordPatientVisitor.Patient.Sex.ADI === "ERKEK")
                this.imageSource = "../../Content/PatientAdmission/avatar_men.png";
            else
                this.imageSource = "../../Content/PatientAdmission/avatar_women.png";
        }
        else {
            this.imageSource = "../../Content/PatientAdmission/avatar_unknown.png";
        }


    }

    // ***** Method declarations start *****
    WorkItemSearchingModel: PersonnelWorkItemSearchModel;

    async selectSearchingPersonnel(event) {

        if (event != null) {
            this.selectedPersonnelInfo = event.data;
            try {
                let that = this;
                this.WorkItemSearchingModel = new PersonnelWorkItemSearchModel();
                this.WorkItemSearchingModel.CitizenId = this.selectedPersonnelInfo.UniqueRefNo;
                let dateNow = new Date();
                this.WorkItemSearchingModel.Type = "2";

                this.WorkItemSearchingModel.StartTime = Convert.ToDateTime(Convert.ToDateTime(dateNow).ToShortDateString() + " 00:00:00");
                this.WorkItemSearchingModel.EndTime = Convert.ToDateTime(Convert.ToDateTime(dateNow).ToShortDateString() + " 23:59:59");
                let apiUrlForPASearchUrl = '/api/PersonnelIntegrationService/PersonnelWorkPlan?personnelWorkPlanSearchingModel=';

                let result = await this.http.post(apiUrlForPASearchUrl, that.WorkItemSearchingModel);
                this.loadSelectSearchingPersonnel(result);

            }
            catch (ex) {
                ServiceLocator.MessageService.showError(ex);
            }
        }

    }

    loadSelectSearchingPersonnel(result) {
        // this.selectedPersonnelInfo = result;
    }

    private LoadSearchingPersonnelList(PersonnelListOfSearchResult): void {

        if (PersonnelListOfSearchResult == null)
            PersonnelListOfSearchResult = [];

        this._PersonnelGridSearchResult = PersonnelListOfSearchResult;

    }
    private LoadAppointmentList(AppointmentSearchingResultList): void {

        if (AppointmentSearchingResultList == null)
            AppointmentSearchingResultList = [];

        this._AppointmentSearchingResultList = AppointmentSearchingResultList;

    }

    OutPatientChanged(event): void {
        if (event != null && event.data != null && event.data.Patient != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._RecordPatientVisitor != null)
                this.hospitalInformationFormViewModel._RecordPatientVisitor.Patient = event.data.Patient;

        }
    }

    InPatientChanged(event): void {

        if (event != null && event.data != null && event.data.Patient != null) {
            if (event.data.IsIntensiveCare) {
                ServiceLocator.MessageService.showInfo(i18n("M24694", "Yoğun Bakım Hastasına Ziyaretçi Kabulü Yoktur."));
            }
            else if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._RecordPatientVisitor != null) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.Patient = event.data.Patient;
                this.isInPatientSelected = true;
            }
        }
    }


    public printPatientFamilyInfoReport() {

        if (this.selectedAppointment != null) {
            const objectIdParam = new GuidParam(this.selectedAppointment.ObjectID.toString());
            let reportParameters: any = { 'OBJECTID': objectIdParam };
            this.reportService.showReport('AppointmentInfoReport', reportParameters);
        }
        else {

            ServiceLocator.MessageService.showInfo(i18n("M30008", "Öncelikle Randevu Seçiniz"));

        }

    }

    public examinationList;
    public async onResourceSelectionChanged(data: any){
 
        this.hospitalInformationFormViewModel._ExaminationSearchModel.ResourceID = data.selectedItem.ObjectID;
        let that = this;
        let ResourceID: Guid = this.hospitalInformationFormViewModel._ExaminationSearchModel.ResourceID;
        let body = "";
        let headers = new Headers({ 'Content-Type': 'application/json' });

        try {
            let apiUrl: string = '/api/HospitalInformationService/GetPatientExaminationList?ResourceID=' + ResourceID;
            let result = await this.httpService.get<Array<ExaminationSearchingResultModel>>(apiUrl);
            if (result) {
                that.examinationList = result;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
        
    }

    private selectedAppointment: AppointmentResultModel = null;
    public selectionAppointmentChanged(event: any) {

        if (event != null && event.selectedRowsData != null){
            this.selectedAppointment = event.selectedRowsData[0];
        }
    }


    async SearchAppointmentWithDetails() {

        try {
            let that = this;

            let apiUrlForPASearchUrl: string = '/api/HospitalInformationService/AppointmentSearchingWithDetails?appointmentSearchModel=';

            let result = await this.http.post(apiUrlForPASearchUrl, that.hospitalInformationFormViewModel._AppointmentSearchModel);
            this.LoadAppointmentList(result);

        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

    }

    
    inbox = new Array<any>();
    async getsysMessages() {

        let apiUrl: string = '/api/UserMessageService/GetUnreadSysMessages';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.inbox = x;
            }

        );
    }

    
    selectedChange(data: any) {
        if (data.itemData.Messageid != undefined) {
            if (data.itemData.Durumu != 0) {
                let param: InputParam = new InputParam();
                param.ObjectID = new Guid(data.itemData.Messageid);
                let apiUrl: string = '/api/UserMessageService/IsMessageRead';
                this.httpService.post<any>(apiUrl, param).then(
                    x => {
                        this.updateCurrentBox();
                    }
                );
            }
            this.systemApiService.open(data.itemData.Messageid, 'USERMESSAGE', 'b40ac20a-68fd-485e-9915-ce7c66d5801a');
        }
    }

    async updateCurrentBox() {
        await this.getsysMessages();
    }

    public showPersonnelSection: boolean = false;
    public sectionInformationList: List <SectionResultModel>  = new List <SectionResultModel>(); 
    ShowSectionInfo_CellContentClickEmitted(data: any){
        if(data != null && data.column.Name == 'btnInfo'){
            this.showPersonnelSection = true;
            this.sectionInformationList = data.data.Sections;
        }
    }



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HospitalInformation();
        this.hospitalInformationFormViewModel = new HospitalInformationFormViewModel();
        this._ViewModel = this.hospitalInformationFormViewModel;
        this.hospitalInformationFormViewModel._HospitalInformation = this._TTObject as HospitalInformation;
        this.hospitalInformationFormViewModel._AppointmentSearchModel = new AppointmentSearchModel();
        this.hospitalInformationFormViewModel._RecordPatientVisitor = new PatientVisitor();
        this.hospitalInformationFormViewModel._ExaminationSearchModel = new ExaminationSearchModel();
        this.hospitalInformationFormViewModel._RecordPatientVisitor.Patient = new Patient();

        let dateFirst = new Date();
        let dateSecond = new Date();
        // dateFirst = dateFirst.AddMonths(-1);
        this.hospitalInformationFormViewModel._PersonnelSearchModel = new PersonnelSearchModel();
        this.hospitalInformationFormViewModel._LocationSearchModel = new LocationSearchModel();


    }

    protected loadViewModel() {
        let that = this;
        that.hospitalInformationFormViewModel = this._ViewModel as HospitalInformationFormViewModel;
        that._TTObject = this.hospitalInformationFormViewModel._HospitalInformation;
        if (this.hospitalInformationFormViewModel == null)
            this.hospitalInformationFormViewModel = new HospitalInformationFormViewModel();
        if (this.hospitalInformationFormViewModel._HospitalInformation == null)
            this.hospitalInformationFormViewModel._HospitalInformation = new HospitalInformation();
        if (this.hospitalInformationFormViewModel._LocationSearchModel == null) {
            this.hospitalInformationFormViewModel._LocationSearchModel = new LocationSearchModel();
        }
        if (this.hospitalInformationFormViewModel._PersonnelSearchModel == null) {
            this.hospitalInformationFormViewModel._PersonnelSearchModel = new PersonnelSearchModel();
        }
        if (this.hospitalInformationFormViewModel._RecordPatientVisitor == null) {
            this.hospitalInformationFormViewModel._RecordPatientVisitor = new PatientVisitor();
            this.hospitalInformationFormViewModel._RecordPatientVisitor.Patient = new Patient();
        }
        if (this.hospitalInformationFormViewModel._AppointmentSearchModel == null) {
            this.hospitalInformationFormViewModel._AppointmentSearchModel = new AppointmentSearchModel();
        }
        if (this.hospitalInformationFormViewModel._ExaminationSearchModel == null) {
            this.hospitalInformationFormViewModel._ExaminationSearchModel = new ExaminationSearchModel();
        }
        let patientVisitorObjectID = that.hospitalInformationFormViewModel._HospitalInformation["PatientVisitor"];
        if (patientVisitorObjectID != null && (typeof patientVisitorObjectID === 'string')) {
            let patientVisitor = that.hospitalInformationFormViewModel.PatientVisitors.find(o => o.ObjectID.toString() === patientVisitorObjectID.toString());
             if (patientVisitor) {
                that.hospitalInformationFormViewModel._RecordPatientVisitor = patientVisitor;
            }
            if (patientVisitor != null) {
                let patientObjectID = patientVisitor["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.hospitalInformationFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        patientVisitor.Patient = patient;
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(HospitalInformationFormViewModel);
  
    }

    async ngAfterViewInit() 
   {
       this.getsysMessages();
    }


    /////////////////////////////////////////////////
    /*
       PersonnelSearchin Event Methods start
   */

    public onPersonnelNameTextboxChanged(event): void {

        if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel.Name != event) {
            this.hospitalInformationFormViewModel._PersonnelSearchModel.Name = event.value;
        }

    }
    public onPersonnelSurnameTextboxChanged(event): void {
        if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel.Surname != event) {
            this.hospitalInformationFormViewModel._PersonnelSearchModel.Surname = event.value;
        }
    }
    public onPersonnelMissionTextboxChanged(event): void {
        if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel.Mission != event) {
            this.hospitalInformationFormViewModel._PersonnelSearchModel.Mission = event;
        }
    }

    public onPersonnelTitleTextboxChanged(event): void {

        if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel.Title != event) {
            if (event == null)
                event = -1;
            this.hospitalInformationFormViewModel._PersonnelSearchModel.Title = event;
        }
    }
    public onPersonnelDepartmentTextboxChanged(event): void {
        if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel.Department != event) {
            this.hospitalInformationFormViewModel._PersonnelSearchModel.Department = event;
        }
    }
    public onPersonnelSectionTextboxChanged(event): void {
        if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel != null && this.hospitalInformationFormViewModel._PersonnelSearchModel.Section != event) {
            this.hospitalInformationFormViewModel._PersonnelSearchModel.Section = event;
        }
    }

    /*
       PatientSearch Event Methods end
   */

    /*
    Location Info Start
    */

    public onLocationBuildingChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._LocationSearchModel != null && this.hospitalInformationFormViewModel._LocationSearchModel.Building != event) {
                this.hospitalInformationFormViewModel._LocationSearchModel.Building = event.ObjectID.toString();
                this.PolyclinicTTListBox.ListFilterExpression = " THIS.BUILDING= '" + event.ObjectID.toString() + "'";
            }
        } else {
            this.PolyclinicTTListBox.ListFilterExpression = "";
        }
    }

    public onLocationPoliclinicChanged(event): void {

        if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._LocationSearchModel != null && this.hospitalInformationFormViewModel._LocationSearchModel.Policlinic != event) {
            this.hospitalInformationFormViewModel._LocationSearchModel.Policlinic = event;
        }

        this.LoadLocationGrid();

    }

    public async LoadLocationGrid()
    {
        try {
            let that = this;
            let model = this.hospitalInformationFormViewModel._LocationSearchModel;
            let searchModel = new LocationSearchModel();
            if (model != null && model.Policlinic != null)
                searchModel.Policlinic = model.Policlinic.ObjectID.toString();

            let apiUrlForLocationSearch: string = '/api/HospitalInformationService/LoadLocationGrid?' + searchModel;
            let result = await this.http.post(apiUrlForLocationSearch, searchModel) as Array<Object>;
            this._LocationGridSearchResult = result;
        }
        catch (ex) {
            if (ex != null) {
                if (ex.error != null)
                    ServiceLocator.MessageService.showError(ex.error);
                else
                    ServiceLocator.MessageService.showError(ex);
            }
        }
    }

    /**
     *    LocationInfo End
     */

    /**
 *    Appointment start
 */
    public onAppointmentUniqRefNoChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.UnicRefNo != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.UnicRefNo = event.value;
            }
        }
    }
    public onAppointmentAdmissionNoChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.AdmissionNo != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.AdmissionNo = event.value;
            }
        }
    }
    public onAppointmentNameChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.Name != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.Name = event.value;
            }
        }
    }
    public onAppointmentsurnameChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.Surname != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.Surname = event.value;
            }
        }
    }
    public onAppointmentMotherNameChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.MotherName != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.MotherName = event.value;
            }
        }
    }
    public onAppointmentFatherNameChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.FatherName != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.FatherName = event.value;
            }
        }
    }
    public onAppointmentPatientBirthCityTextboxChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.BirthCity != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.BirthCity = event.value;
            }
        }
    }
    public onAppointmentBithDatePickerChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.BirthDate != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.BirthDate = event.value;
            }
        }
    }
    public onAppointmentPatientDoctorTextboxChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.Doctor != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.Doctor = event.value;
            }
        }
    }
    public onAppointmentDateFirstChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.DateFirst != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.DateFirst = Convert.ToDateTime(Convert.ToDateTime(event.value).ToShortDateString() + " 00:00:00");
            }
        }
    }
    public onAppointmentDateSecondChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel != null && this.hospitalInformationFormViewModel._AppointmentSearchModel.DateSecond != event) {
                this.hospitalInformationFormViewModel._AppointmentSearchModel.DateSecond = Convert.ToDateTime(Convert.ToDateTime(event.value).ToShortDateString() + " 23:59:59");
            }
        }
    }

    /**
 *    Appointment End
 */
    public onCityOfBirthPersonChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.BirthPlace != event) {
                this._HospitalInformation.Patient.BirthPlace = event;
            }
        }
    }

    public onFatherNamePersonChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.FatherName != event) {
                this._HospitalInformation.Patient.FatherName = event;
            }
        }
    }

    public onIDPatientChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.ID != event) {
                this._HospitalInformation.Patient.ID = event;
            }
        }
    }

    public onMotherNamePersonChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.MotherName != event) {
                this._HospitalInformation.Patient.MotherName = event;
            }
        }
    }

    public onNamePersonChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.Name != event) {
                this._HospitalInformation.Patient.Name = event;
            }
        }
    }

    public onPassportNoPersonChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.PassportNo != event) {
                this._HospitalInformation.Patient.PassportNo = event;
            }
        }
    }



    public onSexPersonChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.Sex != event) {
                this._HospitalInformation.Patient.Sex = event;
            }
        }
    }

    public onSurnamePersonChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.Surname != event) {
                this._HospitalInformation.Patient.Surname = event;
            }
        }
    }

    public onUniqueRefNoPersonChanged(event): void {
        if (event != null) {
            if (this._HospitalInformation != null &&
                this._HospitalInformation.Patient != null && this._HospitalInformation.Patient.UniqueRefNo != event) {
                this._HospitalInformation.Patient.UniqueRefNo = event;
            }
        }
    }

    onPatientFromVisitUniqueRefNoChanged(event): void {

    }

    onPatientFromVisitNameChanged(event): void {

    }

    onPatientFromVisitSurnameChanged(event): void {

    }

    public onPatientPatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.Patient != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.Patient = event;
            }
        }
    }
    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorExitDate != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorExitDate = event;
            }
        }
    }



    public onVisitorBirthCityChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorBirthCity != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorBirthCity = event;
            }
        }
    }

    public onVisitorBirthDatePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorBirthDate != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorBirthDate = event;
            }
        }
    }

    public onVisitorEnterDatePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorEnterDate != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorEnterDate = event;
            }
        }
    }

    public onVisitorExitDatePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorExitDate != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorExitDate = event;
            }
        }
    }

    public onVisitorFatherNamePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorFatherName != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorFatherName = event;
            }
        }
    }

    public onVisitorMotherNamePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorMotherName != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorMotherName = event;
            }
        }
    }

    public onVisitorNamePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorName != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorName = event;
            }
        }
    }

    public onVisitorNotePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorNote != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorNote = event;
            }
        }
    }

    public onVisitorPhoneNumberPatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorPhoneNumber != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorPhoneNumber = event;
            }
        }
    }

    public onVisitorRelationStatePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorRelationState != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorRelationState = event;
            }
        }
    }

    public onVisitorSexChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorSex != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorSex = event;
            }
        }
    }

    public onVisitorSurnamePatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorSurname != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorSurname = event;
            }
        }
    }

    public onVisitorUnicRefIdPatientVisitorChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationFormViewModel != null &&
                this.hospitalInformationFormViewModel._RecordPatientVisitor != null && this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorUnicRefId != event) {
                this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorUnicRefId = event;
            }
        }
    }

    async LoadPatientVisitorList() {

        try {
            let that = this;
            let searchModel = new VisitorSearchModel();

            let dateNow = new Date();
            searchModel.firstDate = Convert.ToDateTime(Convert.ToDateTime(dateNow).ToShortDateString() + " 00:00:00");
            searchModel.secondDate = Convert.ToDateTime(Convert.ToDateTime(dateNow).ToShortDateString() + " 23:59:59");

            let apiUrlForPASearchUrl: string = '/api/HospitalInformationService/LoadPatientVisitors?' + searchModel;
            let result = await this.http.post(apiUrlForPASearchUrl, searchModel) as Array<Object>;
            this._PatientVisitorGridSearchResult = result;


        }
        catch (ex) {
            if (ex != null)
            {
                if (ex.error != null)
                    ServiceLocator.MessageService.showError(ex.error);
                else
                    ServiceLocator.MessageService.showError(ex);
            }
        }
    }
    ClearPatientVisitor(): void {

        if (this.hospitalInformationFormViewModel._RecordPatientVisitor == null) {
            this.hospitalInformationFormViewModel._RecordPatientVisitor = new PatientVisitor();
        }

        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorSex = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorFatherName = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorMotherName = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorName = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorSurname = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorNote = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorPhoneNumber = null;

        let dateNow = new Date();

        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorEnterDate = new Date();
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorExitDate = new Date();

        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorRelationState = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorBirthCity = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorBirthDate = null;
        this.hospitalInformationFormViewModel._RecordPatientVisitor.VisitorUnicRefId = null;
        this.isInPatientSelected = false;
    }

    async SavePatientVisitor() {

        try {
            let apiUrlForPASearchUrl: string = '/api/HospitalInformationService/SavePatientVisitor';

            await this.httpService.post(apiUrlForPASearchUrl, this.hospitalInformationFormViewModel._RecordPatientVisitor).then(result => {
                this.LoadPatientVisitorList();
                this.ClearPatientVisitor();
                this.showSaveSuccessMessage();            
            });
            
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async SearchPersonnelWithDetails() {


        try {
            let that = this;

            let apiUrlForPASearchUrl: string = '/api/HospitalInformationService/PersonnelSearchingWithDetailsForm?personnelSearchModel=';

            let result = await this.http.post(apiUrlForPASearchUrl, that.hospitalInformationFormViewModel._PersonnelSearchModel);
            this.LoadSearchingPersonnelList(result);

        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    SearchButton_Clicked(): void {


    }

    ClearButton_Clicked(): void {

    }

    public async selectedTabChanged(event): Promise<void> {

        let selectedItem: string = event.addedItems[0].title;

        if (selectedItem == i18n("M30011", "Ziyaretçi Kaydı")) {
            this.selectedTab = InformationTabs.VisitorRecord;
            this.ClearButton.Visible = false;
            this.SearchButton.Visible = false;
            this.LoadPatientVisitorList();
        } else {

            this.ClearButton.Visible = true;
            this.SearchButton.Visible = true;

            if (selectedItem == i18n("M30010", "Hasta Sorgulama")) {
                this.selectedTab = InformationTabs.PatientInformation;
            } else if (selectedItem == i18n("M20339", "Personel Sorgulama")) {
                this.selectedTab = InformationTabs.PersonnelInformation;
            } else if (selectedItem == i18n("M18352", "Lokasyon Sorgulama")) {
                this.selectedTab = InformationTabs.LocationInformation;
                if (this._LocationGridSearchResult == null || this._LocationGridSearchResult.length == 0)
                    this.LoadLocationGrid();
            } else if (selectedItem == i18n("M30009", "Randevu Sorgulama")) {
                this.selectedTab = InformationTabs.AppointmentInformation;
            } else if (selectedItem == i18n("M20333", "Personel Nöbet Sorgulama")) {
                this.selectedTab = InformationTabs.ShiftInformation;
            } else if (selectedItem == i18n("M15906", "Hizmet Sorgulama")) {
                this.selectedTab = InformationTabs.RemunerationInformation;
            }
            else if (selectedItem == i18n("M15906", "Duyurular")) {
                this.selectedTab = InformationTabs.Announcements;
            }
            else if (selectedItem == i18n("M15906", "Muayene Sorgulama")) {
                this.selectedTab = InformationTabs.ExaminationInformation;

                if(this.hospitalInformationFormViewModel.ClinicList == null || this.hospitalInformationFormViewModel.ClinicList.length == 0)
                try {
                    let that = this;
                    let body = "";
                    let apiUrlForPASearchUrl: string;
                    let headers = new Headers({ 'Content-Type': 'application/json' });
                    apiUrlForPASearchUrl = '/api/HospitalInformationService/GetPoliclinicList';
        
                    await this.httpService.post<any>(apiUrlForPASearchUrl, null).then(response => {
                        let result = response;
                        if (result) {
                            that.hospitalInformationFormViewModel.ClinicList = result;
                        }
    
    
                    }).catch(error => {
                        ServiceLocator.MessageService.showError("Hata : " + error);
                    });
                }
    
                catch (ex) {
                    ServiceLocator.MessageService.showError(ex);
                }
            }
        }
    }

    private PatientSearchFormIconShowable = 0;
    public PatientSearchFormIconProperties(): string {
        if (this.PatientSearchFormIconShowable == 0)
            return "fa fa-2x fa-angle-down";
        else
            return "fa fa-2x fa-angle-up";
    }

    protected redirectProperties(): void {
        redirectProperty(this.VisitorUnicRefIdPatientVisitor, "Text", this.__ttObject, "PatientVisitor.VisitorUnicRefId");
        redirectProperty(this.VisitorMotherNamePatientVisitor, "Text", this.__ttObject, "PatientVisitor.VisitorMotherName");
        redirectProperty(this.VisitorEnterDatePatientVisitor, "Value", this.__ttObject, "PatientVisitor.VisitorEnterDate");
        redirectProperty(this.VisitorPhoneNumberPatientVisitor, "Text", this.__ttObject, "PatientVisitor.VisitorPhoneNumber");
        redirectProperty(this.VisitorNamePatientVisitor, "Text", this.__ttObject, "PatientVisitor.VisitorName");
        redirectProperty(this.VisitorBirthDatePatientVisitor, "Value", this.__ttObject, "PatientVisitor.VisitorBirthDate");
        redirectProperty(this.VisitorExitDatePatientVisitor, "Value", this.__ttObject, "PatientVisitor.VisitorExitDate");
        redirectProperty(this.VisitorRelationStatePatientVisitor, "Text", this.__ttObject, "PatientVisitor.VisitorRelationState");
        redirectProperty(this.VisitorFatherNamePatientVisitor, "Text", this.__ttObject, "PatientVisitor.VisitorFatherName");
        redirectProperty(this.VisitorSurnamePatientVisitor, "Text", this.__ttObject, "PatientVisitor.VisitorSurname");
        redirectProperty(this.VisitorSex, "Text", this.__ttObject, "PatientVisitor.VisitorSex");
        redirectProperty(this.VisitorBirthCity, "Text", this.__ttObject, "PatientVisitor.VisitorBirthCity");
        redirectProperty(this.VisitorNotePatientVisitor, "Text", this.__ttObject, "PatientVisitor.VisitorNote");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "PatientVisitor.VisitorExitDate");
    }

    public initFormControls(): void {
        this.SearchButton = new TTVisual.TTButton();
        this.SearchButton.Text = i18n("M22125", "Sorgula");
        this.SearchButton.Name = "SearchButton";
        this.SearchButton.TabIndex = 2;

        this.ClearButton = new TTVisual.TTButton();
        this.ClearButton.Text = i18n("M23181", "Temizle");
        this.ClearButton.Name = "ClearButton";
        this.ClearButton.TabIndex = 1;

        this.InformationTab = new TTVisual.TTTabControl();
        this.InformationTab.Text = i18n("M12490", "Danışma Ekranı");
        this.InformationTab.Name = "InformationTab";
        this.InformationTab.TabIndex = 0;

        this.PatientInformation = new TTVisual.TTTabPage();
        this.PatientInformation.DisplayIndex = 0;
        this.PatientInformation.TabIndex = 0;
        this.PatientInformation.Text = i18n("M30010", "Hasta Sorgulama");
        this.PatientInformation.Name = "PatientInformation";

        this.IDPatient = new TTVisual.TTTextBox();
        this.IDPatient.Name = "IDPatient";
        this.IDPatient.TabIndex = 53;

        this.SexPerson = new TTVisual.TTObjectListBox();
        this.SexPerson.ListDefName = "SKRSCinsiyetList";
        this.SexPerson.Name = "SexPerson";
        this.SexPerson.TabIndex = 51;

        this.CityOfBirthPerson = new TTVisual.TTObjectListBox();
        this.CityOfBirthPerson.ListDefName = "CityListDefinition";
        this.CityOfBirthPerson.Name = "CityOfBirthPerson";
        this.CityOfBirthPerson.TabIndex = 49;


        this.UniqueRefNoPerson = new TTVisual.TTTextBox();
        this.UniqueRefNoPerson.Name = "UniqueRefNoPerson";
        this.UniqueRefNoPerson.TabIndex = 47;

        this.SurnamePerson = new TTVisual.TTTextBox();
        this.SurnamePerson.Name = "SurnamePerson";
        this.SurnamePerson.TabIndex = 45;


        this.PassportNoPerson = new TTVisual.TTTextBox();
        this.PassportNoPerson.Name = "PassportNoPerson";
        this.PassportNoPerson.TabIndex = 43;

        this.NamePerson = new TTVisual.TTTextBox();
        this.NamePerson.Name = "NamePerson";
        this.NamePerson.TabIndex = 41;

        this.MotherNamePerson = new TTVisual.TTTextBox();
        this.MotherNamePerson.Name = "MotherNamePerson";
        this.MotherNamePerson.TabIndex = 39;


        this.FatherNamePerson = new TTVisual.TTTextBox();
        this.FatherNamePerson.Name = "FatherNamePerson";
        this.FatherNamePerson.TabIndex = 37;


        this.BirthDatePerson = new TTVisual.TTDateTimePicker();
        this.BirthDatePerson.Format = DateTimePickerFormat.Long;
        this.BirthDatePerson.Name = "BirthDatePerson";
        this.BirthDatePerson.TabIndex = 35;

        this.isTodayCheckBox = new TTVisual.TTCheckBox();
        this.isTodayCheckBox.Value = false;
        this.isTodayCheckBox.Text = i18n("M12100", "Bugün");
        this.isTodayCheckBox.Name = "isTodayCheckBox";
        this.isTodayCheckBox.TabIndex = 30;

        this.DischargeDatePicker = new TTVisual.TTDateTimePicker();
        this.DischargeDatePicker.Format = DateTimePickerFormat.Long;
        this.DischargeDatePicker.Name = "DischargeDatePicker";
        this.DischargeDatePicker.TabIndex = 29;

        this.PatientAdmissionDatePicker = new TTVisual.TTDateTimePicker();
        this.PatientAdmissionDatePicker.Format = DateTimePickerFormat.Long;
        this.PatientAdmissionDatePicker.Name = "PatientAdmissionDatePicker";
        this.PatientAdmissionDatePicker.TabIndex = 28;

        this.InPatientGrid = new TTVisual.TTGrid();
        this.InPatientGrid.Name = "InPatientGrid";
        this.InPatientGrid.TabIndex = 25;


        this.StandingPatientGrid = new TTVisual.TTGrid();
        this.StandingPatientGrid.Name = "StandingPatientGrid";
        this.StandingPatientGrid.TabIndex = 24;


        this.PersonnelInformation = new TTVisual.TTTabPage();
        this.PersonnelInformation.DisplayIndex = 1;
        this.PersonnelInformation.TabIndex = 1;
        this.PersonnelInformation.Text = i18n("M20339", "Personel Sorgulama");
        this.PersonnelInformation.Name = "PersonnelInformation";

        this.PersonnelGrid = new TTVisual.TTGrid();
        this.PersonnelGrid.Name = "PersonnelGrid";
        this.PersonnelGrid.TabIndex = 12;

        this.PersonnelSectionTextbox = new TTVisual.TTObjectListBox();
        this.PersonnelSectionTextbox.LinkedRelationPath = "";
        this.PersonnelSectionTextbox.ListDefName = "ResourceListDefinition";
        this.PersonnelSectionTextbox.Name = "PersonnelSectionTextbox";
        this.PersonnelSectionTextbox.TabIndex = 161;
        this.PersonnelSectionTextbox.ListFilterExpression = "OBJECTDEFNAME IN ('RESPOLICLINIC','RESCLINIC')";


        this.PersonnelTitleTextbox = new TTVisual.TTObjectListBox();
        this.PersonnelTitleTextbox.ListDefName = "AdministrativeStatusTypeDefinition";
        this.PersonnelTitleTextbox.Name = "PersonnelTitleTextbox";
        this.PersonnelTitleTextbox.TabIndex = 4;

        this.PersonnelMissionTextbox = new TTVisual.TTObjectListBox();
        this.PersonnelMissionTextbox.ListDefName = "CKYSUserTypeListDefinition";
        this.PersonnelMissionTextbox.Name = "PersonnelMissionTextbox";
        this.PersonnelMissionTextbox.TabIndex = 161;


        this.PersonnelDepartmentTextbox = new TTVisual.TTObjectListBox();
        this.PersonnelDepartmentTextbox.LinkedRelationPath = "";
        this.PersonnelDepartmentTextbox.ListDefName = "SpecialityListDefinition";
        this.PersonnelDepartmentTextbox.Name = "Speciality";
        this.PersonnelDepartmentTextbox.TabIndex = 161;

        this.PersonnelSurnameTextbox = new TTVisual.TTTextBox();
        this.PersonnelSurnameTextbox.Name = "PersonnelSurnameTextbox";
        this.PersonnelSurnameTextbox.TabIndex = 2;


        this.PersonnelNameTextbox = new TTVisual.TTTextBox();
        this.PersonnelNameTextbox.Name = "PersonnelNameTextbox";
        this.PersonnelNameTextbox.TabIndex = 0;

        this.LocationTab = new TTVisual.TTTabPage();
        this.LocationTab.DisplayIndex = 2;
        this.LocationTab.TabIndex = 2;
        this.LocationTab.Text = i18n("M18352", "Lokasyon Sorgulama");
        this.LocationTab.Name = "LocationTab";

        this.BuildingTTListBox = new TTVisual.TTObjectListBox();
        this.BuildingTTListBox.ListDefName = "BuildinglistDefinition";
        this.BuildingTTListBox.Name = "BuildingTTListBox";
        this.BuildingTTListBox.TabIndex = 6;

        this.PolyclinicTTListBox = new TTVisual.TTObjectListBox();
        this.PolyclinicTTListBox.LinkedControlName = "Branch";
        this.PolyclinicTTListBox.LinkedRelationPath = "";
        this.PolyclinicTTListBox.ListDefName = "PoliclinicsListDefinition";
        this.PolyclinicTTListBox.Name = "Policlinic";
        this.PolyclinicTTListBox.TabIndex = 5;

        this.LocationGrid = new TTVisual.TTGrid();
        this.LocationGrid.Name = "LocationGrid";
        this.LocationGrid.TabIndex = 4;


        this.AppointmentSearchTab = new TTVisual.TTTabPage();
        this.AppointmentSearchTab.DisplayIndex = 3;
        this.AppointmentSearchTab.TabIndex = 3;
        this.AppointmentSearchTab.Text = i18n("M30009", "Randevu Sorgulama");
        this.AppointmentSearchTab.Name = "AppointmentSearchTab";

        this.AppointmentGrid = new TTVisual.TTGrid();
        this.AppointmentGrid.Name = "AppointmentGrid";
        this.AppointmentGrid.TabIndex = 25;

        this.AppointmentDateEndPicker = new TTVisual.TTDateTimePicker();
        this.AppointmentDateEndPicker.Format = DateTimePickerFormat.Long;
        this.AppointmentDateEndPicker.Name = "AppointmentDateEndPicker";
        this.AppointmentDateEndPicker.TabIndex = 24;

        this.AppointmentDateStartPicker = new TTVisual.TTDateTimePicker();
        this.AppointmentDateStartPicker.Format = DateTimePickerFormat.Long;
        this.AppointmentDateStartPicker.Name = "AppointmentDateStartPicker";
        this.AppointmentDateStartPicker.TabIndex = 23;

        this.AppointmentBithDatePicker = new TTVisual.TTDateTimePicker();
        this.AppointmentBithDatePicker.Format = DateTimePickerFormat.Long;
        this.AppointmentBithDatePicker.Name = "AppointmentBithDatePicker";
        this.AppointmentBithDatePicker.TabIndex = 22;

        this.AppointmentPatientDoctorTextbox = new TTVisual.TTObjectListBox();
        this.AppointmentPatientDoctorTextbox.LinkedControlName = "Policlinic";
        this.AppointmentPatientDoctorTextbox.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.AppointmentPatientDoctorTextbox.ListDefName = "SpecialistDoctorListDefinition";
        this.AppointmentPatientDoctorTextbox.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AppointmentPatientDoctorTextbox.Name = "AppointmentPatientDoctorTextbox";
        this.AppointmentPatientDoctorTextbox.TabIndex = 154;

        this.AppointmentPatientBirthCityTextbox = new TTVisual.TTTextBox();
        this.AppointmentPatientBirthCityTextbox.Name = "AppointmentPatientBirthCityTextbox";
        this.AppointmentPatientBirthCityTextbox.TabIndex = 49;

        this.AppointmentPatientFatherNameTextbox = new TTVisual.TTTextBox();
        this.AppointmentPatientFatherNameTextbox.Name = "AppointmentPatientFatherNameTextbox";
        this.AppointmentPatientFatherNameTextbox.TabIndex = 5;

        this.AppointmentPatientMotherNameTextbox = new TTVisual.TTTextBox();
        this.AppointmentPatientMotherNameTextbox.Name = "AppointmentPatientMotherNameTextbox";
        this.AppointmentPatientMotherNameTextbox.TabIndex = 4;

        this.AppointmentPatientSurnameTextbox = new TTVisual.TTTextBox();
        this.AppointmentPatientSurnameTextbox.Name = "AppointmentPatientSurnameTextbox";
        this.AppointmentPatientSurnameTextbox.TabIndex = 3;

        this.AppointmentPatientNameTextbox = new TTVisual.TTTextBox();
        this.AppointmentPatientNameTextbox.Name = "AppointmentPatientNameTextbox";
        this.AppointmentPatientNameTextbox.TabIndex = 2;

        this.AppointmentPatientNoTextbox = new TTVisual.TTTextBox();
        this.AppointmentPatientNoTextbox.Name = "AppointmentPatientNoTextbox";
        this.AppointmentPatientNoTextbox.TabIndex = 1;

        this.AppointmentPatientIdentifyTextbox = new TTVisual.TTTextBox();
        this.AppointmentPatientIdentifyTextbox.Name = "AppointmentPatientIdentifyTextbox";
        this.AppointmentPatientIdentifyTextbox.TabIndex = 0;

        this.PersonnelShiftTab = new TTVisual.TTTabPage();
        this.PersonnelShiftTab.DisplayIndex = 4;
        this.PersonnelShiftTab.TabIndex = 4;
        this.PersonnelShiftTab.Text = i18n("M20352", "Personnel Nöbet Sorgulama");
        this.PersonnelShiftTab.Name = "PersonnelShiftTab";

        this.ttgrid1 = new TTVisual.TTGrid();
        this.ttgrid1.Name = "ttgrid1";
        this.ttgrid1.TabIndex = 12;


        this.PersonnelShiftSectionTextbox = new TTVisual.TTTextBox();
        this.PersonnelShiftSectionTextbox.Name = "PersonnelShiftSectionTextbox";
        this.PersonnelShiftSectionTextbox.TabIndex = 5;

        this.PersonnelShiftDepartmentTextbox = new TTVisual.TTTextBox();
        this.PersonnelShiftDepartmentTextbox.Name = "PersonnelShiftDepartmentTextbox";
        this.PersonnelShiftDepartmentTextbox.TabIndex = 4;

        this.PersonnelShiftTitleTextbox = new TTVisual.TTTextBox();
        this.PersonnelShiftTitleTextbox.Name = "PersonnelShiftTitleTextbox";
        this.PersonnelShiftTitleTextbox.TabIndex = 3;

        this.PersonnelShiftMissionTextbox = new TTVisual.TTTextBox();
        this.PersonnelShiftMissionTextbox.Name = "PersonnelShiftMissionTextbox";
        this.PersonnelShiftMissionTextbox.TabIndex = 2;

        this.PersonnelShiftSurnameTextbox = new TTVisual.TTTextBox();
        this.PersonnelShiftSurnameTextbox.Name = "PersonnelShiftSurnameTextbox";
        this.PersonnelShiftSurnameTextbox.TabIndex = 1;

        this.PersonnelShiftNameTextbox = new TTVisual.TTTextBox();
        this.PersonnelShiftNameTextbox.Name = "PersonnelShiftNameTextbox";
        this.PersonnelShiftNameTextbox.TabIndex = 0;

        this.RemunerationTab = new TTVisual.TTTabPage();
        this.RemunerationTab.DisplayIndex = 5;
        this.RemunerationTab.TabIndex = 6;
        this.RemunerationTab.Text = i18n("M15906", "Hizmet Sorgulama");
        this.RemunerationTab.Name = "RemunerationTab";

        this.VisitorTab = new TTVisual.TTTabPage();
        this.VisitorTab.DisplayIndex = 6;
        this.VisitorTab.TabIndex = 5;
        this.VisitorTab.Text = i18n("M30011", "Ziyaretçi Kaydı");
        this.VisitorTab.Name = "VisitorTab";

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.Name = "ttgrid2";
        this.ttgrid2.TabIndex = 69;

        this.ttcheckbox1 = new TTVisual.TTCheckBox();
        this.ttcheckbox1.Value = false;
        this.ttcheckbox1.Text = i18n("M12100", "Bugün");
        this.ttcheckbox1.Name = "ttcheckbox1";
        this.ttcheckbox1.TabIndex = 68;


        this.VisitorNotePatientVisitor = new TTVisual.TTTextBox();
        this.VisitorNotePatientVisitor.Name = "VisitorNotePatientVisitor";
        this.VisitorNotePatientVisitor.TabIndex = 64;


        this.VisitorRelationStatePatientVisitor = new TTVisual.TTTextBox();
        this.VisitorRelationStatePatientVisitor.Name = "VisitorRelationStatePatientVisitor";
        this.VisitorRelationStatePatientVisitor.TabIndex = 62;

        this.VisitorPhoneNumberPatientVisitor = new TTVisual.TTMaskedTextBox();
        this.VisitorPhoneNumberPatientVisitor.Mask = "999 9999999";
        this.VisitorPhoneNumberPatientVisitor.Name = "VisitorPhoneNumberPatientVisitor";
        this.VisitorPhoneNumberPatientVisitor.TabIndex = 7;


        this.VisitorExitDatePatientVisitor = new TTVisual.TTDateTimePicker();
        this.VisitorExitDatePatientVisitor.Format = DateTimePickerFormat.Long;
        this.VisitorExitDatePatientVisitor.Name = "VisitorExitDatePatientVisitor";
        this.VisitorExitDatePatientVisitor.TabIndex = 58;


        this.VisitorEnterDatePatientVisitor = new TTVisual.TTDateTimePicker();
        this.VisitorEnterDatePatientVisitor.Format = DateTimePickerFormat.Long;
        this.VisitorEnterDatePatientVisitor.Name = "VisitorEnterDatePatientVisitor";
        this.VisitorEnterDatePatientVisitor.TabIndex = 56;


        this.VisitorSex = new TTVisual.TTObjectListBox();
        this.VisitorSex.ListDefName = "SKRSCinsiyetList";
        this.VisitorSex.Name = "VisitorSex";
        this.VisitorSex.TabIndex = 166;
        this.VisitorSex.AutoCompleteDialogWidth = "15%";


        this.VisitorBirthCity = new TTVisual.TTObjectListBox();
        this.VisitorBirthCity.LinkedControlName = "CountryOfBirth";
        this.VisitorBirthCity.ListDefName = "SKRSILKodlariList";
        this.VisitorBirthCity.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.VisitorBirthCity.Name = "VisitorBirthCity";
        this.VisitorBirthCity.TabIndex = 17;
        this.VisitorBirthCity.AutoCompleteDialogWidth = "15%";

        this.VisitorBirthDatePatientVisitor = new TTVisual.TTDateTimePicker();
        this.VisitorBirthDatePatientVisitor.Format = DateTimePickerFormat.Long;
        this.VisitorBirthDatePatientVisitor.Name = "VisitorBirthDatePatientVisitor";
        this.VisitorBirthDatePatientVisitor.TabIndex = 50;


        this.VisitorMotherNamePatientVisitor = new TTVisual.TTTextBox();
        this.VisitorMotherNamePatientVisitor.Name = "VisitorMotherNamePatientVisitor";
        this.VisitorMotherNamePatientVisitor.TabIndex = 48;


        this.VisitorFatherNamePatientVisitor = new TTVisual.TTTextBox();
        this.VisitorFatherNamePatientVisitor.Name = "VisitorFatherNamePatientVisitor";
        this.VisitorFatherNamePatientVisitor.TabIndex = 46;


        this.VisitorSurnamePatientVisitor = new TTVisual.TTTextBox();
        this.VisitorSurnamePatientVisitor.Name = "VisitorSurnamePatientVisitor";
        this.VisitorSurnamePatientVisitor.TabIndex = 44;


        this.VisitorNamePatientVisitor = new TTVisual.TTTextBox();
        this.VisitorNamePatientVisitor.Name = "VisitorNamePatientVisitor";
        this.VisitorNamePatientVisitor.TabIndex = 42;


        this.VisitorUnicRefIdPatientVisitor = new TTVisual.TTTextBox();
        this.VisitorUnicRefIdPatientVisitor.Name = "VisitorUnicRefIdPatientVisitor";
        this.VisitorUnicRefIdPatientVisitor.TabIndex = 40;


        this.PatientPatientVisitor = new TTVisual.TTObjectListBox();
        this.PatientPatientVisitor.ListDefName = "";
        this.PatientPatientVisitor.Name = "PatientPatientVisitor";
        this.PatientPatientVisitor.TabIndex = 28;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 20;

        this.btnInfo = new TTVisual.TTButtonColumn();
        this.btnInfo.HeaderText = "";
        this.btnInfo.Name = "btnInfo";
        this.btnInfo.Visible = true;
        this.btnInfo.Text = "Bölüm Bilgisi";

    }


}

export class InputParam {
    public ObjectID: Guid;
    public CurrentBox: string;
}

export class SectionResultModel
{
    public SectionName: string; 
    public SectionStatus: string;  
    public SectionID: Guid; 
}