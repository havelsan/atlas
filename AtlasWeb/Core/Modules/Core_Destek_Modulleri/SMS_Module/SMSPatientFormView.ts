import { Component, OnInit, Input, AfterViewInit, ViewChild, ApplicationRef } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { SMSPersonnelGridViewModel, SendPersonnelSMSModel, SMSPatientFormViewModel, SMSPatientGridViewModel, SMSPatientSearchModel, SendPatientSMSModel } from "./SMSFormViewModel";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { SKRSGenderEnum } from "app/NebulaClient/Utils/Enums/SKRSGenderEnum";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import Regex from "app/NebulaClient/System/Text/RegularExpressions";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { ShowBox } from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { async } from "rxjs/internal/scheduler/async";
import { SMSFormView } from "./SMSFormView";
import { plainToClass } from "app/NebulaClient/ClassTransformer";
import { SMSTypeEnum } from "./SMSTypeEnum";


@Component({
    selector: 'sms-patient-form',
    templateUrl: './SMSPatientFormView.html',
    providers: [MessageService, SystemApiService]
})
export class SMSPatientFormView extends SMSFormView implements OnInit, AfterViewInit {

    public viewModel: SMSPatientFormViewModel = new SMSPatientFormViewModel();
    public GenderDataSource = SKRSGenderEnum.Items;
    public SKRSILCEDatasourceForBirthPlace: DataSource;
    public SKRSILCEDatasourceForAddress: DataSource;
    public SKRSUlkeKodlariDataSource: DataSource;
    public PayerDefinitionDataSource: DataSource;
    public DiagnosisDataSource: DataSource;
    public ResourceDataSource: DataSource;
    public ClinicDoctorDataSource: DataSource;
    public patientGridColumns = [];
    public showLoadPanel = false;
    public selectedPatientList: Array<SMSPatientGridViewModel> = new Array<SMSPatientGridViewModel>();
    public CountyForBirthPlaceReadOnly = true;
    public CountyForAddressReadOnly = true;
    public AdmissionStartDateRelatedCriteriasReadOnly = true;
    public runningTaskID: any;
    public ExecObjectID: Guid;
    public SMSTypeDataSource = SMSTypeEnum.Items;
    public SelectedSMSType?: number;

    public provizyonTibiSearchExp = [
        'provizyonTipiAdi_Shadow',
        'provizyonTipiAdi',
        'provizyonTipiKodu'];

    public IstisnaiHalSearchExpr = [
        'Kodu',
        'Adi'
    ];

    public TedaviTuruSearchExpr = [
        'tedaviTuruAdi',
        'tedaviTuruAdi_Shadow',
        'tedaviTuruKodu'
    ];

    public SepcialitySearchExpr = [
        'Name_LowerCase',
        'Name_UpperCase',
        'Name_Shadow',
        'Code'
    ];

    public SKRSILSearchExpr = [
        'KODU',
        'ADI_UpperCase',
        'ADI_LowerCase',
        'ADI'
    ];

    public _SKRSIlDataSource: Array<any>;
    @Input() set SKRSIlDataSource(propVal: Array<any>) {
        this._SKRSIlDataSource = propVal;
    }

    get SKRSIlDataSource(): Array<any> {
        return this._SKRSIlDataSource;
    }

    public _ProvizyonTipiDataSource: Array<any>;
    @Input() set ProvizyonTipiDataSource(propVal: Array<any>) {
        this._ProvizyonTipiDataSource = propVal;
    }

    get ProvizyonTipiDataSource(): Array<any> {
        return this._ProvizyonTipiDataSource;
    }

    public _IstisnaiHalDataSource: Array<any>;
    @Input() set IstisnaiHalDataSource(propVal: Array<any>) {
        this._IstisnaiHalDataSource = propVal;
    }

    get IstisnaiHalDataSource(): Array<any> {
        return this._IstisnaiHalDataSource;
    }

    public _TedaviTuruDataSource: Array<any>;
    @Input() set TedaviTuruDataSource(propVal: Array<any>) {
        this._TedaviTuruDataSource = propVal;
    }

    get TedaviTuruDataSource(): Array<any> {
        return this._TedaviTuruDataSource;
    }

    public _SpecialityDefDataSource: Array<any>;
    @Input() set SpecialityDefDataSource(propVal: Array<any>) {
        this._SpecialityDefDataSource = propVal;
    }

    get SpecialityDefDataSource(): Array<any> {
        return this._SpecialityDefDataSource;
    }

    constructor(private httpService: NeHttpService) {

        super(httpService);
        //#region DataSources
        this.SKRSILCEDatasourceForBirthPlace = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: async (loadOptions: any) => {
                    let that = this;
                    let city = that.SKRSIlDataSource.find(x => x.ObjectID == that.viewModel.PatientSearchModel.SelectedCityOfBirthPlace);
                    if (city == null) {
                        return new Array<any>();
                    }
                    else {
                        if (loadOptions.take == null || loadOptions.take == 0) {
                            loadOptions.take = 200;
                        }
                        loadOptions.Params = {
                            searchText: loadOptions.searchValue,
                            definitionName: 'SKRSIlceKodlariList',
                            injectionFilter: "ILKODU = '" + city.KODU + "'"
                        }
                        return await this.httpService.post<any>("/api/SMSFormApi/GetCountyListDefinition", loadOptions);
                    }
                },
                byKey: async (key: any) => {
                    return await this.httpService.post<any>("/api/SMSFormApi/GetCountyListDefinition?key=" + key, null);
                }
            }),
            paginate: true,
            pageSize: 200
        });

        this.SKRSILCEDatasourceForAddress = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                load: async (loadOptions: any) => {
                    let that = this;
                    let city = that.SKRSIlDataSource.find(x => x.ObjectID == that.viewModel.PatientSearchModel.SelectedCityOfAddress);
                    if (city == null) {
                        return new Array<any>();
                    }
                    else {
                        if (loadOptions.take == null || loadOptions.take == 0) {
                            loadOptions.take = 200;
                        }
                        loadOptions.Params = {
                            searchText: loadOptions.searchValue,
                            definitionName: 'SKRSIlceKodlariList',
                            injectionFilter: "ILKODU = '" + city.KODU + "'"
                        }
                        return await this.httpService.post<any>("/api/SMSFormApi/GetCountyListDefinition", loadOptions);
                    }
                },
                byKey: async (key: any) => {
                    return await this.httpService.post<any>("/api/SMSFormApi/GetCountyListDefinition?key=" + key, null);
                }
            }),
            paginate: true,
            pageSize: 200
        });

        this.SKRSUlkeKodlariDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SKRSUlkeKodlariList',
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.httpService.post<any>("/api/SMSFormApi/GetListDefinition", loadOptions);
                    return data;
                }
            }),
            paginate: true,
            pageSize: 50
        });

        this.PayerDefinitionDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'PayerListDefinition',
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.httpService.post<any>("/api/SMSFormApi/GetListDefinition", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.viewModel.PatientSearchModel.SelectedPayers = data.map(x => x.ObjectID)
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });

        this.DiagnosisDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'DiagnosisListDefinition',
                        injectionFilter: 'ISLEAF=1'
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.httpService.post<any>("/api/SMSFormApi/GetDiagnosisListDefinition", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.viewModel.PatientSearchModel.SelectedDiagnosis = data.map(x => x.ObjectID)
                        //that.viewModel.PersonnelSearcModel.SelectedCitiesObjectIDs = selectedData;
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });

        this.ResourceDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectId',
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'ResourceList',
                        ResourceTypes: [
                            'ResPoliclinic'
                            , 'ResClinic'
                            , 'ResDepartment'
                        ],
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.httpService.post<any>("/api/SMSFormApi/GetResources", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.viewModel.PatientSearchModel.SelectedPoliclinics = data.map(x => x.ObjectId)
                        //that.viewModel.PersonnelSearcModel.SelectedCitiesObjectIDs = selectedData;
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });

        this.ClinicDoctorDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'ClinicDoctorListDefinition',
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.httpService.post<any>("/api/SMSFormApi/GetListDefinition", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.viewModel.PatientSearchModel.SelectedAdmissionDoctor = data.map(x => x.ObjectID)
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });

        //#endregion DataSources
    }

    public onAdmissionStartDateChanged(event: any) {
        let that = this;
        if (event.value != null)
            that.AdmissionStartDateRelatedCriteriasReadOnly = false;
        else {
            that.viewModel.PatientSearchModel.SetNullAdmissionStartDateRelatedCriterias();
            that.AdmissionStartDateRelatedCriteriasReadOnly = true;
        }
    }

    public async onValueChangedCityForBirthPlace(event: any) {
        if (event.value == null) {
            this.viewModel.PatientSearchModel.SelectedCountyOfBirthPlace = null;
            this.CountyForBirthPlaceReadOnly = true;
        }
        else {
            this.CountyForBirthPlaceReadOnly = false;
            await this.SKRSILCEDatasourceForBirthPlace.reload();
        }
        if (event.previousValue != null) {
            this.viewModel.PatientSearchModel.SelectedCountyOfBirthPlace = null;
            await this.SKRSILCEDatasourceForBirthPlace.reload();
        }
    }

    public async onValueChangedCityForAddress(event: any) {
        if (event.value == null) {
            this.viewModel.PatientSearchModel.SelectedCountyOfAddress = null;
            this.CountyForAddressReadOnly = true;
        }
        else {
            this.CountyForAddressReadOnly = false;
            await this.SKRSILCEDatasourceForAddress.reload();
        }
        if (event.previousValue != null) {
            this.viewModel.PatientSearchModel.SelectedCountyOfAddress = null;
            await this.SKRSILCEDatasourceForAddress.reload();
        }
    }

    public SearchPatient() {
        let that = this;
        that.showLoadPanel = true;
        that.httpService.post<Array<SMSPatientGridViewModel>>("/api/SMSFormApi/GetPatientList", this.viewModel.PatientSearchModel).then(res => {
            that.viewModel.GridViewModel = res;
            that.showLoadPanel = false;
        }).catch(err => {
            that.showLoadPanel = false;
            ServiceLocator.MessageService.showError(err);
        });
    }

    public async SendSMS() {
        let that = this;
        let RegexDesen = /^(5(\d{9}))$/;

        if (that.SelectedSMSType == null) {
            ServiceLocator.MessageService.showError('SMS Türü boş olamaz!');
        }

        if (that.selectedPatientList.length == 0) {
            ServiceLocator.MessageService.showError('Lütfen önce listeden SMS gönderilecek kişileri seçiniz.');
            return;
        }
        else {
            let numberListToSendSMS = that.selectedPatientList.filter(x => RegexDesen.test(x.Phone));
            if (numberListToSendSMS.length == 0) {
                ServiceLocator.MessageService.showError('Seçilen kişilerden numara formatı SMS göndermeye uygun personel bulunamadı. Lütfen girilen numaraları kontrol ediniz.');
                return;
            }
            else {
                if (String.isNullOrEmpty(that.viewModel.SMSText)) {
                    ServiceLocator.MessageService.showError('SMS Metni boş olamaz.!');
                    return;
                }
                let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', 'Seçilen Kişi Sayısı: ' + that.selectedPatientList.length + '\r\n SMS Gönderilecek Kişi Sayısı: ' + numberListToSendSMS.length + ' Göndermek istediğinize emin misiniz?');
                if (result === "OK") {
                    let smsModel = new SendPatientSMSModel();
                    smsModel.SMSModel = numberListToSendSMS;
                    smsModel.SMSText = that.viewModel.SMSText;
                    smsModel.SMSType = that.SelectedSMSType;
                    that.showLoadPanel = true;
                    that.httpService.post<any>('/api/SMSFormApi/SaveSMSToPatient', smsModel).then(res => {
                        that.ExecObjectID = res;
                        that.Exec(res);
                    }).catch(err => {
                        that.showLoadPanel = false;
                        ServiceLocator.MessageService.showError(err);
                    });
                }
            }
        }
    }

    Exec(masterSMS: Guid) {
        this.httpService.get('/api/SMSFormApi/Exec?masterSmsID=' + masterSMS).then(res => {
            this.runningTaskID = setInterval(() => { this.GetCheckSMSMasterResult(masterSMS); }, 5000);
        });
    }

    GetCheckSMSMasterResult(masterSMS: Guid) {
        this.httpService.get<boolean>('/api/SMSFormApi/CheckSMSMaster?masterSmsID=' + masterSMS).then(res => {
            this.showLoadPanel = res;
            if (!res)
                clearInterval(this.runningTaskID);
        }).catch(err => {
            clearInterval(this.runningTaskID);
            ServiceLocator.MessageService.showError(err + ' mesaj gönderilemedi.');
            this.showLoadPanel = false;
        });
    }

    public CancelSMS() {
        this.httpService.get('/api/SMSFormApi/CancelSMS?masterSmsID=' + this.ExecObjectID).then(res => {
            clearInterval(this.runningTaskID);
            this.runningTaskID = null;
            this.showLoadPanel = false;
        });
    }


    public userSearchModelLoaded(value) {
        if (value != null)
            this.viewModel.PatientSearchModel = plainToClass<SMSPatientSearchModel, Object>(SMSPatientSearchModel, JSON.parse(value));
        else
            this.viewModel.PatientSearchModel = new SMSPatientSearchModel();
    }

    public smsTemplateLoaded(value) {
        if (value != null)
            this.viewModel.SMSText = JSON.parse(value);
        else
            this.viewModel.SMSText = '';
    }

    ngOnInit(): void {
        this.patientGridColumns = [
            {
                caption: 'Adı',
                dataField: 'Name'
            },
            {
                caption: 'Soyadı',
                dataField: 'SurName'
            },
            {
                caption: 'Telefon No',
                dataField: 'Phone'
            },
            {
                caption: 'TC No',
                dataField: 'UniqueRefNo'
            }
        ];
    }

    ngAfterViewInit(): void {

    }
}