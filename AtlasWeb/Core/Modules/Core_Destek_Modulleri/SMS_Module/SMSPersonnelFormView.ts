import { Component, OnInit, Input, AfterViewInit, ViewChild, ApplicationRef } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { WorkStatusEnum, SMSPersonnelSearchModel, SMSPersonnelGridViewModel, SendPersonnelSMSModel, SMSPersonnelFormViewModel } from "./SMSFormViewModel";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { SKRSGenderEnum } from "app/NebulaClient/Utils/Enums/SKRSGenderEnum";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import { UserTypeEnum, UserTitleEnum } from "app/NebulaClient/Model/AtlasClientModel";
import Regex from "app/NebulaClient/System/Text/RegularExpressions";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { ShowBox } from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { SMSFormView } from "./SMSFormView";
import { SMSTypeEnum } from "./SMSTypeEnum";


@Component({
    selector: 'sms-personnel-form',
    templateUrl: './SMSPersonnelFormView.html',
    providers: [MessageService, SystemApiService]
})
export class SMSPersonnelFormView extends SMSFormView implements OnInit, AfterViewInit {

    public viewModel: SMSPersonnelFormViewModel = new SMSPersonnelFormViewModel();
    public WorkStatusDataSource = WorkStatusEnum.Items;
    public GenderDataSource = SKRSGenderEnum.Items;
    public OccupationDataSource = UserTypeEnum.Items;
    public UserTitleDataSource = UserTitleEnum.Items;
    public BirthPlaceDataSource: DataSource;
    public ResourceDataSource: DataSource;
    public personnelGridColumns = [];
    public showLoadPanel = false;
    public runningTaskID: any;
    public selectedPersonnelList: Array<SMSPersonnelGridViewModel> = new Array<SMSPersonnelGridViewModel>();
    public ExecObjectID: Guid;
    public SMSTypeDataSource = SMSTypeEnum.Items;
    public SelectedSMSType?: number;

    private _SpecialityDataSource: Array<any>;
    @Input() set SpecialityDataSource(propVal: any) {
        this._SpecialityDataSource = propVal;
    }

    get SpecialityDataSource(): any {
        return this._SpecialityDataSource;
    }

    constructor(private httpService: NeHttpService) {

        super(httpService);
        this.BirthPlaceDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                byKey: (key: any) => {
                    console.log(key);
                    return null;
                },
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'CityListDefinition',
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.httpService.post<any>("/api/SMSFormApi/GetListDefinition", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.viewModel.PersonnelSearcModel.SelectedCitiesObjectIDs = data.map(x => x.ObjectID)
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
                byKey: (key: any) => {
                    console.log(key);
                    return null;
                },
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

                        that.viewModel.PersonnelSearcModel.SelectedResourcesObjectIDs = data.map(x => x.ObjectId)
                        //that.viewModel.PersonnelSearcModel.SelectedCitiesObjectIDs = selectedData;
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });
    }


    public SearchPersonnel() {
        let that = this;
        that.showLoadPanel = true;
        that.httpService.post<Array<SMSPersonnelGridViewModel>>("/api/SMSFormApi/GetPersonnelList", this.viewModel.PersonnelSearcModel).then(res => {
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

        if (that.selectedPersonnelList.length == 0) {
            ServiceLocator.MessageService.showError('Lütfen önce listeden SMS gönderilecek kişileri seçiniz.');
            return;
        }
        else {
            let numberListToSendSMS = that.selectedPersonnelList.filter(x => RegexDesen.test(x.Phone));
            if (numberListToSendSMS.length == 0) {
                ServiceLocator.MessageService.showError('Seçilen kişilerden numara formatı SMS göndermeye uygun personel bulunamadı. Lütfen girilen numaraları kontrol ediniz.');
                return;
            }
            else {
                if (String.isNullOrEmpty(that.viewModel.SMSText)) {
                    ServiceLocator.MessageService.showError('SMS Metni boş olamaz.!');
                    return;
                }
                let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', 'Seçilen Kişi Sayısı: ' + that.selectedPersonnelList.length + '\r\n -- SMS Gönderilecek Kişi Sayısı: ' + numberListToSendSMS.length + ' Göndermek istediğinize emin misiniz?');
                if (result === "OK") {
                    let smsModel = new SendPersonnelSMSModel();
                    smsModel.SMSModel = numberListToSendSMS;
                    smsModel.SMSText = that.viewModel.SMSText;
                    smsModel.SMSType = that.SelectedSMSType;
                    that.showLoadPanel = true;
                    that.httpService.post<any>('/api/SMSFormApi/SaveSMSToPersonnel', smsModel).then(res => {
                        that.ExecObjectID = res;
                        this.Exec(res);
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
            if (!res) {
                clearInterval(this.runningTaskID);
                ServiceLocator.MessageService.showError('Mesaj gönderim işlemi tamamlandı.');
            }
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
            this.viewModel.PersonnelSearcModel = JSON.parse(value);
        else
            this.viewModel.PersonnelSearcModel = new SMSPersonnelSearchModel();
    }

    public smsTemplateLoaded(value) {
        if (value != null)
            this.viewModel.SMSText = JSON.parse(value);
        else
            this.viewModel.SMSText = '';
    }

    ngOnInit(): void {
        this.personnelGridColumns = [
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
                caption: 'Çalışma Durumu',
                dataField: 'WorkStatus'
            },
            {
                caption: 'Görevi',
                dataField: 'Position'
            }
        ];
    }

    ngAfterViewInit(): void {

    }
}