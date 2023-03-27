
import { Input, Component, ViewChild, ViewChildren, OnInit, QueryList, Renderer2 } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import {
    DrugOrderIntroductionDet,
    DescriptionTypeEnum, DrugUsageTypeEnum, ResSection, DrugOrderIntroduction, DrugOrderTypeEnum,
    Episode, SubEpisode, InPatientPhysicianApplication, ResUser, DrugShapeTypeEnum, RefactoredFrequencyEnum, HospitalTimeSchedule, DrugOrderStatusEnum, DrugDefinition, DrugReportType, DrugOrderDetail, DrugSpecificationEnum, PTSAction
} from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionService, DrugInfo, GetDrugReportNo_Input, DrugIngredient, ControlRepeatDay_Output } from 'NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { DxDataGridComponent, DxRadioGroupComponent } from 'devextreme-angular';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import DataSource from 'devextreme/data/data_source';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { UserHelper } from 'app/Helper/UserHelper';
import { FavoriteDrugService } from 'ObjectClassService/FavoriteDrugService';
import { DrugOrderIntroductionGridViewModel, DrugOrderTimceSchedule, DrugOrderIntroductionNewForm_Output, DrugOrderIntroductionFormViewModel, SaveDrugOrder_Output, DrugOrderIntroductionNewForm_Input, PatientDTO, StopDrugOrders_Input, StopDrugOrders_Output, DrugOrderInfo_Input, DrugOrderInfo_Output, UpgradeDrugOrderDVO, PrepareInteraction_Input, PrepareInteraction_Output, GetAllDrugOrderGridViewModel_Input } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { DrugOrderAddRequirement } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Requirements/DrugOrderAddRequirement';
import { AtlasObjectCloner } from 'app/NebulaClient/ClassTransformer/AtlasObjectCloner';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { QueryVademecumInteractionDVONew } from 'app/Logistic/Models/LogisticDashboardViewModel';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DrugOrderIntroductionNewFormViewModel } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderIntroductionNewFormViewModel';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { stringify } from 'querystring';
import { ComboListItem } from 'app/NebulaClient/Visual/ComboListItem';
import { InputForm } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { find } from 'rxjs/operators';
import { OrderTemplateDetailItem } from 'app/Logistic/Views/OrderTemplateComponent';
import { Resolve } from '@angular/router';
import { DrugOrderGridComponent } from './DrugOrderGridComponent';
import { Headers, RequestOptions } from '@angular/http';


@Component({
    selector: 'tele-order-grid-component',
    templateUrl: './TeleOrderGridComponentFormView.html',
    providers: [{ provide: IESignatureService, useClass: ESignatureService }]
})

export class TeleOrderGridComponent extends DrugOrderGridComponent implements OnInit {

    //#region DrugOrder verilirken gereken resource ve diğer bilgiler input olarak tanımlandı.
    public _masterResource: ResSection;
    @Input() set MasterResource(propVal: ResSection) {
        this._masterResource = propVal;
    }
    get MasterResource(): ResSection {
        return this._masterResource;
    }
    public _secondaryMasterResource: ResSection;
    @Input() set SecondaryMasterResource(propVal: ResSection) {
        this._secondaryMasterResource = propVal;
    }
    get SecondaryMasterResource(): ResSection {
        return this._secondaryMasterResource;
    }
    public _episode: Episode;
    @Input() set Episode(propVal: Episode) {
        this._episode = propVal;
    }
    get Episode(): Episode {
        return this._episode;
    }
    public _subEpisode: SubEpisode;
    @Input() set SubEpisode(propVal: SubEpisode) {
        this._subEpisode = propVal;
    }
    get SubEpisode(): SubEpisode {
        return this._subEpisode;
    }
    public _activeInPatientPhysicianApp: InPatientPhysicianApplication;
    @Input() set ActiveInPatientPhysicianApp(propVal: InPatientPhysicianApplication) {
        this._activeInPatientPhysicianApp = propVal;
    }
    get ActiveInPatientPhysicianApp(): InPatientPhysicianApplication {
        return this._activeInPatientPhysicianApp;
    }

    public _isVisible: boolean = true;
    @Input() set IsVisible(propVal: boolean) {
        this._isVisible = propVal;
        if (this._isVisible === false)
            this.checkBoxesMode = 'none';
    }
    get IsVisible(): boolean {
        return this._isVisible;
    }

    //#endregion

    // private _patientOwnDrug: ResSection;
    // @Input() set PatientOwnDrug(propVal: ResSection) {
    //     this._patientOwnDrug = propVal;
    // }

    
    @ViewChild('orderMasterGrid') orderMasterGrid: DxDataGridComponent;
    @ViewChildren('orderDetailGrid') orderDetailGrids: QueryList<DxDataGridComponent>;
    @ViewChild('eventRadioGroup') eventRadioGroup: DxRadioGroupComponent;


    public CreateMasterGridColumns(): Array<any> {
        if (this.timeScheduleDataSource != null)
            return this.MasterGridColumns = [
                {
                    caption: "Durum",
                    dataField: 'Status',
                    lookup: { dataSource: this.DrugOrderStatusDataSource, valueExpr: 'ordinal', displayExpr: 'description' },
                    width: 'auto',
                    fixed: true,
                    visibleIndex: 0,
                    allowEditing: false,

                },
                {
                    caption: "Order Tarihi",
                    dataField: 'CreationDate',
                    dataType: 'date',
                    format: 'dd/MM/yyyy',
                    fixed: true,
                    allowEditing: false,
                    width: 'auto',
                    visibleIndex: 1,
                    sortOrder: 'desc'
                },
                {
                    caption: i18n("M27573", "Uyg. Baş. Tarihi"),
                    dataField: 'PlannedStartTime',
                    dataType: 'date',
                    format: 'dd/MM/yyyy',
                    fixed: true,
                    width: 'auto',
                    visibleIndex: 2,
                    sortOrder: 'desc',
                    editorOptions: {
                        min: this.drugOrderMinDate,
                        max: this.drugOrderMaxDate
                    }
                },
                {
                    caption: 'Baş. Saati',
                    dataField: 'DrugOrderIntroDuctionTimeSchedule[0].Time',
                    dataType: "date",
                    format: "shortTime",
                    fixed: true,
                    width: 80,
                    visibleIndex: 3,
                    allowEditing: false,
                    editorOptions: { type: "time" },
                },
                {
                    caption: 'Baş. Saati',
                    dataField: 'OrderStartTime',
                    dataType: "date",
                    format: "shortTime",
                    visible: false,
                    allowEditing: true,
                    editorOptions: { type: "time" },
                },
                {
                    caption: "Uyg. Bit. Tarihi",
                    dataField: 'PlannedEndTime',
                    dataType: 'date',
                    format: 'dd/MM/yyyy HH:mm',
                    fixed: true,
                    width: 'auto',
                    visibleIndex: 4,
                    allowEditing: false,
                    editorOptions: {
                        min: this.drugOrderMinDate,
                        max: this.drugOrderMaxDate
                    }
                },
                {
                    caption: i18n("M16287", "İlaç"),
                    dataField: 'Material.name',
                    fixed: true,
                    allowEditing: false,
                    width: 200,
                },
                {
                    caption: i18n("M13285", "Doz Aralığı"),
                    dataField: 'HospitalTimeScheduleObjectID',
                    lookup: { dataSource: this.timeScheduleDataSource, valueExpr: 'ObjectID', displayExpr: 'Name' },
                    alignment: 'right',
                    fixed: true,
                    width: 80,
                    validationRules: [{ type: 'required', message: 'Doz Aralığı Boş Geçilemez' }]
                },
                {
                    caption: i18n("M13294", "Doz Miktarı"),
                    dataField: 'DoseAmount',
                    dataType: 'number',
                    //format: '##,#',
                    /*editorOptions: {
                        onKeyPress: function (e) {
                            let event = e.event,
                                str = String.fromCharCode(event.keyCode);
                            if (!/[0-9]/.test(str))
                                event.preventDefault();
                        }
                    },*/
                    alignment: 'left',
                    fixed: true,
                    width: 'auto',
                    validationRules: [{ type: 'required', message: 'Doz Miktarı Boş Geçilemez' }]
                },
                {
                    caption: i18n("M14998", "Gün"),
                    dataField: 'Day',
                    dataType: 'number',
                    format: '#',
                    editorOptions: {
                        onKeyPress: function (e) {
                            let event = e.event,
                                str = String.fromCharCode(event.keyCode);
                            if (!/[0-9]/.test(str))
                                event.preventDefault();
                            /*if (Number(event.key) > 9) {
                                event.preventDefault();
                                ServiceLocator.MessageService.showError('En fazla 3 günlük Order verebilirsiniz!');
                            }*/
                        }
                    },
                    fixed: true,
                    width: 50,
                    validationRules: [{ type: 'required', message: 'Gün Boş Geçilemez' }]
                },
                {
                    caption: i18n("M17991", "Kullanma Açıklaması"),
                    dataField: 'UsageNote',
                    width: 200,
                },
                {
                    caption: i18n("M10430", "Acil İlaç"),
                    dataField: 'IsImmediate',
                    dataType: 'boolean',
                    width: 'auto',
                },
                {
                    caption: "CV",
                    dataField: 'IsCV',
                    dataType: 'boolean',
                    allowEditing: false,
                    width: 'auto',
                },
                {
                    caption: "Sözel Order",
                    dataField: 'IsTeleOrder',
                    dataType: 'boolean',
                    allowEditing: false,
                    width: 'auto',
                },
                {
                    caption: "Hastanın İlacı",
                    dataField: 'PatientOwnDrug',
                    dataType: 'boolean',
                    width: 'auto',
                    //allowEditing: false,
                },
                {
                    caption: i18n("M26386", "Lüzumu Halinde"),
                    dataField: 'CaseOfNeed',
                    dataType: 'boolean',
                    width: 'auto',
                },
                {
                    caption: i18n("M17982", "Kullanım Şekli"),
                    dataField: 'DrugUsageType',
                    lookup: { dataSource: this.DrugUsageTypeSource, valueExpr: 'ordinal', displayExpr: 'description' },
                    width: 'auto',
                    validationRules: [{ type: 'required', message: 'Kullanım Şekli Boş Geçilemez' }]
                },
                {
                    caption: i18n("M17982", "Tedavi Türü"),
                    dataField: 'DrugOrderType',
                    lookup: { dataSource: DrugOrderTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
                    width: 90,
                },
                {
                    caption: 'Doktor Adı',
                    dataField: 'DoctorName',
                    allowEditing: false,
                    width: 'auto',
                },
                {
                    caption: 'Doktor',
                    dataField: 'DoctorGuid',
                    width: 0,
                    lookup: { dataSource: this.doctorList, valueExpr: 'ObjectID', displayExpr: 'Name' },
                    validationRules: [{ type: 'required', message: 'Doktor Boş Geçilemez' }]
                }
            ];
    }


    public CreateDetailGridColumns(): Array<any> {
        return this.DrugOrderDetailGridColumns = [
            {
                caption: 'T',
                dataField: 'DetailNo',
                dataType: 'number',
                allowEditing: false,
                width: 40,
            },
            {
                caption: 'Tarih',
                dataField: 'Time',
                dataType: "date",
                format: "shortDateShortTime",
                width: 160,
                allowEditing: false,
            },
            {
                caption: 'Saat',
                dataField: 'Time',
                dataType: "date",
                format: "shortTime",
                width: 80,
                editorOptions: {
                    type: "time",
                    min: this.drugOrderMinDate,
                    //max: this.drugOrderMaxDate,
                },
            },
            {
                caption: i18n("M13294", "Doz Miktarı"),
                dataField: 'DoseAmount',
                dataType: 'number',
                //format: '#.#',
                /*editorOptions: {
                    onKeyPress: function (e) {
                        let event = e.event,
                            str = String.fromCharCode(event.keyCode);
                        if (!/[0-9]/.test(str))
                            event.preventDefault();
                        if (Number(event.key) <= 0) {
                            event.preventDefault();
                            ServiceLocator.MessageService.showError('Doz Miktarı sıfırdan büyük olmalıdır!');
                        }
                    }
                },*/
                alignment: 'left',
                width: 120,
            },
            {
                caption: i18n("M17991", "Kullanma Açıklaması"),
                dataField: 'UsageNote',
                width: 250,
            }
        ];
    }

    constructor(protected http: NeHttpService, public signService: IESignatureService, public renderer: Renderer2) {
        super(http, signService, renderer);
    }

    async ngOnInit(): Promise<void> {
        this.loadingVisible = true;
        await this.FillDataSources();
        await super.ngOnInit();
        this.isTeleOrder = true;
        setTimeout(x => {
            this.loadingVisible = false;
        }, 2000);
    }

    async FillDataSources() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugReturnReportService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await that.http.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    that.doctorList = result.DoctorList;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public async StopDrugOrders() {
        let input: StopDrugOrders_Input = new StopDrugOrders_Input();
        let selectedItemsToStopped = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.filter(x => x.Status == DrugOrderStatusEnum.Continue && x.SelectionCheck == true && x.IsTeleOrder == true);
        if (selectedItemsToStopped.length > 0) {
            let message = selectedItemsToStopped.map(x => x.Material.name).join(', ');
            message += '</br>İlaçlara ait Direktifler Durdurulacaktır! Devam etmek istiyor musunuz?';
            let result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20924", "Direktif Durdur"),
                message);
            if (result === 'T') {
                input.DrugOrderObjectIDList = selectedItemsToStopped.map(x => x.LastDrugOrderObjectID);
                this.http.post<StopDrugOrders_Output>(this.url + '/StopDrugOrders', input).then(res => {
                    if (res.Result) {
                        res.details.forEach(item => {
                            selectedItemsToStopped.find(x => x.LastDrugOrderObjectID === item.objectId).Status = item.status;
                        });
                        TTVisual.InfoBox.Alert(res.ResultMessage);
                        this.filterOrders(this.SelectedOrderStatus);
                    }
                    else
                        TTVisual.InfoBox.Alert(res.ResultMessage);

                });
            }
        }
        else
            TTVisual.InfoBox.Alert('Sadece Devam Ediyor durumundaki ve Sözel orderlar durdurulabilir!');
    }

    public async MasterGridUpdatingFunction(event: any): Promise<boolean> {
        return new Promise<boolean>(async (resolve, reject) => {
            let drugOrderIntroductionGridViewModel = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.key);
            if (drugOrderIntroductionGridViewModel.Status === DrugOrderStatusEnum.Continue) {
                if (event.newData.HospitalTimeScheduleObjectID != null
                    || event.newData.DoseAmount != null
                ) {
                    ServiceLocator.MessageService.showError('Güncellenen direktiflerde sadece Kullanma Açıklaması değiştirilebilir ');
                    resolve(true);
                    return;
                }
            }



            if (event.newData.PatientOwnDrug === false) {
                if (drugOrderIntroductionGridViewModel.Material.inheldStatus === "0") {
                    ServiceLocator.MessageService.showError('İlacın mevcudu olmadığı için sadece "Hastanın İlacı" olarak order edebilirsiniz.');
                    resolve(true);
                    return;
                }
                if (drugOrderIntroductionGridViewModel.Material.isPatientOwnDrug != null) {
                    if (drugOrderIntroductionGridViewModel.Material.isPatientOwnDrug === true) {
                        ServiceLocator.MessageService.showError('Sadece "Hastanın İlacı" olarak order edebilirsiniz.');
                        resolve(true);
                        return;
                    }
                }
            }

            if (event.newData.PlannedStartTime != null || event.newData.HospitalTimeScheduleObjectID != null
                || event.newData.DoseAmount != null
                || event.newData.Day != null) {
                let plannedStartTime: Date;
                let timeSchedule: Guid;
                let doseAmount: number;
                let day: number;
                if (event.newData.DoseAmount != null && event.newData.DoseAmount <= 0) {
                    ServiceLocator.MessageService.showError('Doz Miktarı sıfırdan büyük olmalıdır!');
                    resolve(true);
                    return;
                }
                let orderDayPeriod: string = (await SystemParameterService.GetParameterValue('ORDERPLANNIGDAYPERIOD', '3'));
                if (event.newData.Day != null && event.newData.Day > Number.parseInt(orderDayPeriod)) {
                    ServiceLocator.MessageService.showError('Gün ' + orderDayPeriod + ' den büyük olmamalıdır!');
                    resolve(true);
                    return;
                }
                if (event.newData.HospitalTimeScheduleObjectID != null)
                    timeSchedule = event.newData.HospitalTimeScheduleObjectID;
                else
                    timeSchedule = drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID;

                if (timeSchedule == null) {
                    ServiceLocator.MessageService.showError('Doz Aralığı seçiniz');
                    resolve(true);
                    return;
                } else {
                    if (event.newData.PlannedStartTime != null) {
                        if (timeSchedule != null)
                            plannedStartTime = this.FindFirstDetailTime(this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule), new Date(event.newData.PlannedStartTime));
                        else
                            plannedStartTime = new Date(event.newData.PlannedStartTime);
                    }
                    else {
                        if (timeSchedule != null)
                            plannedStartTime = this.FindFirstDetailTime(this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule), event.oldData.PlannedStartTime);
                        else
                            plannedStartTime = new Date(drugOrderIntroductionGridViewModel.PlannedStartTime.toString());
                    }

                    if (event.newData.DoseAmount != null) {
                        if (timeSchedule != null) {
                            doseAmount = event.newData.DoseAmount * <number>this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule).Frequency;
                        }
                        else
                            doseAmount = drugOrderIntroductionGridViewModel.DoseAmount * <number>this.timeScheduleDataSource.find(x => x.ObjectID == timeSchedule).Frequency;
                    }
                }
                if (event.newData.Day)
                    day = event.newData.Day;
                else
                    day = drugOrderIntroductionGridViewModel.Day;

                if (this.checkDrugAmount) {
                    if (drugOrderIntroductionGridViewModel.PatientOwnDrug === false && drugOrderIntroductionGridViewModel.Material.drugType != null && drugOrderIntroductionGridViewModel.Material.drugType) {
                        let totalAmount: number = doseAmount * day;
                        if (totalAmount > Number.parseInt(drugOrderIntroductionGridViewModel.Material.inheldStatus)) {
                            ServiceLocator.MessageService.showError('Eczanede yeterli mevcut bulunmamaktadır. İstenen: ' + totalAmount.toString() + ' Mevcut: ' + drugOrderIntroductionGridViewModel.Material.inheldStatus);
                            resolve(true);
                            return;
                        }
                    }
                    if (this.isHimssRequired && drugOrderIntroductionGridViewModel.PatientOwnDrug && drugOrderIntroductionGridViewModel.Material.drugType != null && drugOrderIntroductionGridViewModel.Material.drugType) {
                        let totalAmount: number = doseAmount * day;
                        if (totalAmount > Number.parseInt(drugOrderIntroductionGridViewModel.Material.inheldStatus)) {
                            ServiceLocator.MessageService.showError('Hastanın yeterli mevcutlu ilacı bulunmamaktadır.');
                            resolve(true);
                            return;
                        }
                    }
                } else {
                    if (this.isHimssRequired && drugOrderIntroductionGridViewModel.PatientOwnDrug && drugOrderIntroductionGridViewModel.Material.drugType != null && drugOrderIntroductionGridViewModel.Material.drugType) {
                        let totalAmount: number = doseAmount * day;
                        if (totalAmount > Number.parseInt(drugOrderIntroductionGridViewModel.Material.inheldStatus)) {
                            ServiceLocator.MessageService.showError('Hastanın yeterli mevcutlu ilacı bulunmamaktadır.');
                            resolve(true);
                            return;
                        }
                    }
                }

                drugOrderIntroductionGridViewModel.UpdatedOnGrid = true;
                let drugOrderAddRequirementWithApproval = new DrugOrderAddRequirement(this.http, this.selectedMaterials, this.GetDrugOrderIntroductionGridViewModelDTO(),
                    this.timeScheduleDataSource, timeSchedule, plannedStartTime,
                    this.drugOrderMinDate,
                    this.patient,
                    doseAmount, day,
                    this._episode,
                    this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel,
                    true
                );
                let requirementResultWithApproval = await drugOrderAddRequirementWithApproval.ExecuteRequirementsWithApproval();
                if (requirementResultWithApproval.IsSuccess == false) {
                    // let keys = Object.keys(event.newData.DrugOrderIntroductionDetailDTO);
                    // keys.forEach(key => {
                    //     drugOrderIntroductionGridViewModel[key] = event.oldData.DrugOrderIntroductionDetailDTO[key];
                    // });
                    //this.orderMasterGrid.instance.cancelEditData();
                }
                resolve(!requirementResultWithApproval.IsSuccess);
            }
            else
                resolve(false);
        });
    }

    public async onDrugOrderIntroductionGridUpdating(event: any) {
        event.cancel = this.MasterGridUpdatingFunction(event);
    }

    public onDrugOrderIntroductionGridUpdated(event: any) {
        let row = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.key);
        if (row.PlannedStartTime || row.HospitalTimeScheduleObjectID || row.DoseAmount || row.Day) {
            let drugOrderIntroductionGridViewModel = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModel.find(x => x.ID == event.key);
            this.CreateDrugOrderIntroductionTimeModel(drugOrderIntroductionGridViewModel);

            let drugOrderIntroductionDTO: DrugOrderIntroductionGridViewModel = <DrugOrderIntroductionGridViewModel>this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.ID === event.key);
            drugOrderIntroductionDTO.Day = drugOrderIntroductionGridViewModel.Day;
            drugOrderIntroductionDTO.DrugOrderIntroDuctionTimeSchedule = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule;
            if (drugOrderIntroductionDTO.Material.InfectionApproval === true) {
                let pTime = drugOrderIntroductionDTO.PlannedEndTime;
                if (drugOrderIntroductionDTO.Day == 1)
                    pTime = drugOrderIntroductionDTO.PlannedStartTime;
                let activeInfectionCom = this.patient.ActiveInfectionCommiteeApproves.find(x => x.MaterialID.toString() === drugOrderIntroductionDTO.Material.drugObjectId);
                if (activeInfectionCom != null) {
                    if (new Date(pTime) > new Date(activeInfectionCom.EndDate)) {
                        TTVisual.InfoBox.Alert('Enfeksiyon Komitesi Onayına Gidecektir!');
                    }
                } else {
                    TTVisual.InfoBox.Alert('Enfeksiyon Komitesi Onayına Gidecektir!');
                }
            }
        }
    }

    public onMasterGirdRowRemoving(event: any) {
        if (event != null && event.data != null && event.data.Status == DrugOrderStatusEnum.New) {
            this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO = this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.filter(x => x.ID != event.data.ID);
            event.cancel = false;
        }
        else {
            TTVisual.InfoBox.Alert('Sadece Yeni durumundaki direktifler silinebilir!');
            event.cancel = true;
        }
    }

    public onMasterGridEditingStart(event: any) {
        let row = <DrugOrderIntroductionGridViewModel>event.data;

        if (row.Status != DrugOrderStatusEnum.New) {
            if (this.drugOrderIntroductionFormViewModel.DrugOrderIntroductionGridViewModelDTO.find(x => x.ID === event.data.ID) == null) {
                event.cancel = true;
                TTVisual.InfoBox.Alert('Sadece Yeni Durumunda olan veya  Tedavi Güncelle yapılan Direktifler güncellenebilir!');
            }
        } else {
            row.EditOnGrid = true;
        }
    }

    public onMasterGridEditorPreparing(event: any) {
        if (event.parentType == 'headerRow' && event.command == 'select') {
            event.editorElement.remove();
        }
    }

    onEditorPrepared(e) {
        if (e.parentType == "dataRow" && e.component.columnOption(e.dataField, "validationRules")) {
            setTimeout(function () {
                var validator = null;
                try {
                    if (e.row.rowType == "data")
                        validator = $(e.editorElement).dxValidator("instance");
                    else
                        validator = $(e.editorElement).parent().parent().dxValidator("instance");
                }
                catch (e) {

                }

                if (validator)
                    validator.validate();
            }, 100)
        }
    }
}
