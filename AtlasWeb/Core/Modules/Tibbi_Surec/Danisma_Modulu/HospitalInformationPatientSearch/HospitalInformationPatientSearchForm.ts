//$69752EA9

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { HospitalInformationPatientSearchFormViewModel } from './HospitalInformationPatientSearchFormViewModel';

import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Convert } from "NebulaClient/Mscorlib/Convert";

@Component({
    selector: 'HospitalInformationPatientSearchForm',
    templateUrl: './HospitalInformationPatientSearchForm.html',
    inputs: ['hospitalInformationPatientSearchFormViewModel'],
    outputs: ['SelectedInPatientChanged', 'SelectedOutPatientChanged']
})
export class HospitalInformationPatientSearchForm extends TTVisual.TTForm implements OnInit {

    CityOfBirthPerson: TTVisual.ITTObjectListBox;
    SexPerson: TTVisual.ITTObjectListBox;
    BirthDatePerson: TTVisual.ITTDateTimePicker;


    public hospitalInformationPatientSearchFormViewModel: HospitalInformationPatientSearchFormViewModel;
    public _InPatientListOfSearchResult: Array<any> = [];
    public _OutPatientListOfSearchResult: Array<any> = [];
    SelectedOutPatientChanged: EventEmitter<any> = new EventEmitter<any>();
    SelectedInPatientChanged: EventEmitter<any> = new EventEmitter<any>();
    InPatientSearching: boolean = true;
    OutPatientSearching: boolean = false;
    public LoadPanelMessage: string = 'Kayıtlar Yükleniyor, Lütfen Bekleyiniz';
    public showLoadPanel = false;


    constructor(protected http: NeHttpService, protected messageService: MessageService, protected httpService: NeHttpService,
        ) {
        super("CONVTEST", "ConvTestForm");
        this.hospitalInformationPatientSearchFormViewModel = new HospitalInformationPatientSearchFormViewModel();
        this.loadAll();

    }


    private _isOutPatientCanCalling: boolean = true;
    @Input() set isOutPatientCanCalling(value: boolean) {
        this._isOutPatientCanCalling = value;
    }
    get isOutPatientCanCalling(): boolean {
        return this._isOutPatientCanCalling;
    }

    keyDownForNumericControl(event: any) {

        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }

    async loadAll(): Promise<void> {

        let dateFirst = new Date();
        let dateSecond = new Date();

        this.BirthDatePerson = new TTVisual.TTDateTimePicker();
        this.BirthDatePerson.Format = DateTimePickerFormat.Long;
        this.BirthDatePerson.Name = "BirthDatePerson";
        this.BirthDatePerson.TabIndex = 35;

        this.CityOfBirthPerson = new TTVisual.TTObjectListBox();
        this.CityOfBirthPerson.ListDefName = "CityListDefinition";
        this.CityOfBirthPerson.Name = "CityOfBirthPerson";
        this.CityOfBirthPerson.TabIndex = 49;

        this.SexPerson = new TTVisual.TTObjectListBox();
        this.SexPerson.ListDefName = "SKRSCinsiyetList";
        this.SexPerson.Name = "SexPerson";
        this.SexPerson.TabIndex = 51;

        this.hospitalInformationPatientSearchFormViewModel.AdmissionDateFirst = Convert.ToDateTime(Convert.ToDateTime(dateFirst).ToShortDateString() + " 00:00:00");
        this.hospitalInformationPatientSearchFormViewModel.AdmissionDateSecond = Convert.ToDateTime(Convert.ToDateTime(dateSecond).ToShortDateString() + " 23:59:59");

        if(this.hospitalInformationPatientSearchFormViewModel.ResourceListOutPatient == null || this.hospitalInformationPatientSearchFormViewModel.ResourceListOutPatient.length == 0){
        try {
            let that = this;
            let body = "";
            let apiUrlForPASearchUrl: string;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            apiUrlForPASearchUrl = '/api/HospitalInformationService/GetResourceList';

            await this.httpService.post<any>(apiUrlForPASearchUrl, null).then(response => {
                let result = response;
                if (result) {
                    that.hospitalInformationPatientSearchFormViewModel.ResourceListOutPatient = result;
                }


            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    if(this.hospitalInformationPatientSearchFormViewModel.ResourceListInPatient == null || this.hospitalInformationPatientSearchFormViewModel.ResourceListInPatient.length == 0){
        try {
            let that = this;
            let body = "";
            let apiUrlForPASearchUrl: string;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            apiUrlForPASearchUrl = '/api/HospitalInformationService/GetResClinicList';

            await this.httpService.post<any>(apiUrlForPASearchUrl, null).then(response => {
                let result = response;
                if (result) {
                    that.hospitalInformationPatientSearchFormViewModel.ResourceListInPatient = result;
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

    public selectOutPatient(event) {
        if (event != null && event.data != null)
            this.SelectedOutPatientChanged.emit(event);
    }

    public selectInPatient(event) {
        if (event != null && event.data != null)
            this.SelectedInPatientChanged.emit(event);
    }

   async SearchPatientWithDetails(){

        try {
            let that = this;

            let apiUrlForPASearchUrl: string = "";
            if (this.InPatientSearching) {
                apiUrlForPASearchUrl = '/api/HospitalInformationPatientSearchService/InPatientSearchWithDetailsForm?patientSearchModel=';
            }
            else {
                apiUrlForPASearchUrl = '/api/HospitalInformationPatientSearchService/OutPatientSearchWithDetailsForm?patientSearchModel=';
            }
            this.showLoadPanel = true;
            let result = await this.http.post(apiUrlForPASearchUrl, that.hospitalInformationPatientSearchFormViewModel);
            this.LoadSearchingPatientList(result);

        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
            this.showLoadPanel = false;
        }
    }

    private LoadSearchingPatientList(PatientListOfSearchResult): void {

        if (PatientListOfSearchResult == null)
            PatientListOfSearchResult = [];

        if (this.InPatientSearching) {
            this._InPatientListOfSearchResult = PatientListOfSearchResult;
        }
        else {
            this._OutPatientListOfSearchResult = PatientListOfSearchResult;
        }
        this.showLoadPanel = false;
    }


    ngOnInit() {

    }

    public onPatientSexChanged(event): void {

        if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.Sex != event) {
            this.hospitalInformationPatientSearchFormViewModel.Sex = event;
        }

    }
    public onPatientNameChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.Name != event) {
                this.hospitalInformationPatientSearchFormViewModel.Name = event.value;
            }
        }
    }
    public onPatientSurnameChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.Surname != event) {
                this.hospitalInformationPatientSearchFormViewModel.Surname = event.value;
            }
        }
    }
    public onPatientIDChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.ID != event) {
                this.hospitalInformationPatientSearchFormViewModel.ID = event.value;
            }
        }
    }
    public onPatientUnicRefNoChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.UnicRefNo != event) {
                this.hospitalInformationPatientSearchFormViewModel.UnicRefNo = event.value;
            }
        }
    }
    public onPatientPassportNohanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.PassportNo != event) {
                this.hospitalInformationPatientSearchFormViewModel.PassportNo = event.value;
            }
        }
    }
    public onPatientAdmissionNumberChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.AdmissionNumber != event) {
                this.hospitalInformationPatientSearchFormViewModel.AdmissionNumber = event.value;
            }
        }
    }
    public onPatientMotherNameChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.MotherName != event) {
                this.hospitalInformationPatientSearchFormViewModel.MotherName = event.value;
            }
        }
    }
    public onPatientFatherNameChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.FatherName != event) {
                this.hospitalInformationPatientSearchFormViewModel.FatherName = event.value;
            }
        }
    }
    public onPatientBirthCityChanged(event): void {
        if (event != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.BirthCity != event) {
                this.hospitalInformationPatientSearchFormViewModel.BirthCity = event.value;
            }
        }
    }
    public onPatientBirthDateChanged(event): void {
        if (event != null && event.value != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.BirthDate != event.value) {
                this.hospitalInformationPatientSearchFormViewModel.BirthDate = event.value;
            }
        }
    }

    public onPatientAdmissionDateFirstChanged(event): void {
        if (event != null && event.value != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.AdmissionDateFirst != event.value) {
                this.hospitalInformationPatientSearchFormViewModel.AdmissionDateFirst = event.value;
            }
        }
    }
    public onPatientAdmissionDateSecondChanged(event): void {
        if (event != null && event.value != null) {
            if (this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel != null && this.hospitalInformationPatientSearchFormViewModel.AdmissionDateSecond != event.value) {
                this.hospitalInformationPatientSearchFormViewModel.AdmissionDateSecond = event.value;
            }
        }
    }

    public onInPatientSearchingChanged(event): void {
        if (event != null && event.value != null) {
            this.OutPatientSearching = !(event.value);
            this.InPatientSearching = event.value;
        }
    }
    public onOutPatientSearchingChanged(event): void {
        if (event != null && event.value != null) {
            this.OutPatientSearching = event.value;
            this.InPatientSearching = !(event.value);
        }
    }


    public OutPatientColumns = [
        {
            caption: i18n("M30004", "Tc Kimlk No"),
            dataField: "Patient.UniqueRefNo",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M10514", "Adı"),
            dataField: "Patient.Name",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M22205", "Soyadı"),
            dataField: "Patient.Surname",
            width: 100,
            allowSorting: true
        },

        {
            caption: i18n("M11037", "Anne Adı"),
            dataField: "Patient.MotherName",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M11390", "Baba Adı"),
            dataField: "Patient.FatherName",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M12048", "Branş"),
            dataField: "Department",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M20431", "Poliklinik"),
            dataField: "Policlinic",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M30001", "Doktor"),
            dataField: "Doctor",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M22841", "Tarih ve Saat"),
            dataField: "ActionDate",
            width: 200,
            allowSorting: true,
            dataType: 'date', 
            format: 'dd/MM/yyyy hh:mm',
        },
        {
            caption: i18n("M23135", "Telefon No"),
            dataField: "PhoneNumber",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M30001", "Adres"),
            dataField: "Address",
            width: 200,
            allowSorting: true
        }
    ];


    public InPatientColumns = [
        {
            caption: i18n("M30004", "Tc Kimlk No"),
            dataField: "UniqueRefNo",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M10514", "Adı"),
            dataField: "Name",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M22205", "Soyadı"),
            dataField: "Surname",
            width: 100,
            allowSorting: true
        },

        {
            caption: i18n("M11037", "Anne Adı"),
            dataField: "MotherName",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M11390", "Baba Adı"),
            dataField: "FatherName",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M23135", "Telefon No"),
            dataField: "PhoneNumber",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M30001", "Adres"),
            dataField: "Address",
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M12048", "Branş"),
            dataField: "Department",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M23001", "Tedavi Kliniği"),
            dataField: "Clinic",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M30001", "Doktor"),
            dataField: "Doctor",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M24457", "Yattığı Klinik"),
            dataField: "PhysicalStateClinic",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M24448", "Yatış Tarihi"),
            dataField: "ActionDate",
            width: 100,
            allowSorting: true,
            dataType: 'date', 
            format: 'dd.MM.yyyy'
        },
        {
            caption: i18n("M24436", "Yatış Kararı Doktoru"),
            dataField: "InPatientDecisionDoctor",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M24431", "Yatış Doktoru"),
            dataField: "InPatientDoctor",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M21663", "Servis Katı"),
            dataField: "ServiceFloor",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M19602", "Oda"),
            dataField: "Room",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M19616", "Oda Telefonu"),
            dataField: "RoomPhone",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M24353", "Yatak"),
            dataField: "Bed",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M24371", "Yatak Telefonu"),
            dataField: "BedPhone",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M15650", "Hemşire Masası"),
            dataField: "NurseTablePhone",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M30003", "Taburcu/Yatış durumu"),
            dataField: "DischargeOrInPatientState",
            width: 100,
            allowSorting: true
        }
    ];
}