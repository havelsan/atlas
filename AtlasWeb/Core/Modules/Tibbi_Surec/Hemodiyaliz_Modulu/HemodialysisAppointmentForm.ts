//$368A2ADF
import { Component, OnInit, ViewChild } from '@angular/core';
import { HemodialysisAppointmentFormViewModel, HemodialysisSearchCriteria, HemodialysisAppointmentItem, AppointmentInputDVO, GivenAppointment, GivenResource, AppOrSchType, GivenAppointmentsAndSchedules, GivenHemodialysisAppointmentDVO } from './HemodialysisAppointmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionWorkListItem, StateOutputDVO } from '../Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel';
import { DynamicComponentInfo } from '../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { SystemApiService } from '../../../wwwroot/app/Fw/Services/SystemApiService';
import { DateTimePickerFormat } from '../../../wwwroot/app/NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ResEquipment, PackageProcedureDefinition, SKRSDiyalizeGirmeSikligi, HemodialysisOrder, Resource, Appointment } from '../../../wwwroot/app/NebulaClient/Model/AtlasClientModel';
import { Convert } from '../../../wwwroot/app/NebulaClient/Mscorlib/Convert';
import { DxSchedulerComponent, DxSelectBoxComponent } from 'devextreme-angular';
import { ServiceLocator } from '../../../wwwroot/app/Fw/Services/ServiceLocator';
import { ShowBoxTypeEnum } from '../../../wwwroot/app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';


@Component({
    selector: 'HemodialysisAppointmentForm',
    templateUrl: './HemodialysisAppointmentForm.html',
    providers: [MessageService, SystemApiService]
})
export class HemodialysisAppointmentForm extends TTVisual.TTForm implements OnInit {
    DialysisFrequency: TTVisual.ITTObjectListBox;
    Duration: TTVisual.ITTTextBox;
    Emergency: TTVisual.ITTCheckBox;
    Information: TTVisual.ITTTextBox;
    IsWeekendInclude: TTVisual.ITTCheckBox;
    labelDialysisFrequency: TTVisual.ITTLabel;
    labelDuration: TTVisual.ITTLabel;
    labelInformation: TTVisual.ITTLabel;
    labelPackageProcedure: TTVisual.ITTLabel;
    labelSessionCount: TTVisual.ITTLabel;
    labelSessionDayRange: TTVisual.ITTLabel;
    labelSessionDayRangeType: TTVisual.ITTLabel;
    labelTreatmentEquipment: TTVisual.ITTLabel;
    labelTreatmentStartDateTime: TTVisual.ITTLabel;
    PackageProcedure: TTVisual.ITTObjectListBox;
    SessionCount: TTVisual.ITTTextBox;
    SessionDayRange: TTVisual.ITTTextBox;
    SessionDayRangeType: TTVisual.ITTEnumComboBox;
    TreatmentEquipment: TTVisual.ITTObjectListBox;
    TreatmentStartDateTime: TTVisual.ITTDateTimePicker;

    public hemodialysisAppointmentFormViewModel: HemodialysisAppointmentFormViewModel = new HemodialysisAppointmentFormViewModel();
    //public get _HemodialysisAppointment(): HemodialysisAppointment {
    //    return this._TTObject as HemodialysisAppointment;
    //}
    //private HemodialysisAppointmentForm_DocumentUrl: string = '/api/HemodialysisAppointmentService/HemodialysisAppointmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService) {
        super('HEMODIALYSISREQUEST', 'HemodialysisAppointmentForm');
        //this._DocumentServiceUrl = this.HemodialysisAppointmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

        let _episodeActionWorkListItems: Array<EpisodeActionWorkListItem> = new Array<EpisodeActionWorkListItem>();

        let _episodeActionWorkListItem: EpisodeActionWorkListItem = new EpisodeActionWorkListItem();
        _episodeActionWorkListItem.ObjectDefName = "HEMODIALYSISORDER";
        _episodeActionWorkListItem.ObjectDefID = "c458664d-91b0-4003-a2d2-18f194eb4727";
        _episodeActionWorkListItems.push(_episodeActionWorkListItem);

        this.getStateList(_episodeActionWorkListItems);

        this.getViewmodelList();
    }


    // ***** Method declarations start *****

    protected async PreScript() {
        super.PreScript();
    }

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    isDynamicComponentOpened: boolean = false;
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public HemodialysisListColumns = [
        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: "Kabul Tarihi",
            dataField: "TreatmentStartDateTime",
            dataType: 'date',
            format: 'dd.MM.yyyy',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M15187", "Durumu"),
            dataField: "HemodialysisStateName",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        }
    ];

    //hemodiyaliz state listesi
    async getStateList(value: any) {
        let that = this;

        let res = await this.httpService.post("api/EpisodeActionWorkListService/GetEpisodeActionStateDefinition", value);
        let output = <StateOutputDVO>res;

        this.hemodialysisAppointmentFormViewModel.HemodialysisStateItems = output.WorkListSearchStateItem;
    }

    async getViewmodelList() {
        let that = this;

        this.loadPanelOperation(true, i18n("M14461", "Form hazırlanıyor, lütfen bekleyiniz."));
        that.httpService.get<any>("api/HemodialysisAppointmentService/HemodialysisAppointmentForm")
            .then(async response => {
                let result: HemodialysisAppointmentFormViewModel = <HemodialysisAppointmentFormViewModel>response;
                this.hemodialysisAppointmentFormViewModel.SKRSDiyalizeGirmeSikligiList = result.SKRSDiyalizeGirmeSikligiList;
                this.hemodialysisAppointmentFormViewModel.PackageProcedureList = result.PackageProcedureList;
                this.hemodialysisAppointmentFormViewModel.TreatmentEquipmentList = result.TreatmentEquipmentList;

                this.loadPanelOperation(false, '');
            })
            .catch(error => {
                this.messageService.showError(error);
                this.loadPanelOperation(false, '');
            });
    }

    public btnSearchClicked(): void {
        if (this.hemodialysisAppointmentFormViewModel._hemodialysisSearchCriteria == null || this.hemodialysisAppointmentFormViewModel._hemodialysisSearchCriteria.HemodialysisState == null) {
            ServiceLocator.MessageService.showError("Lütfen Statü Seçiniz!");
        } else {
            this.getHemodialysisAppointmentList();
        }
    }
    getHemodialysisAppointmentList() {

        let that = this;
        let _SearchCriteria: HemodialysisSearchCriteria = new HemodialysisSearchCriteria();

        this.loadPanelOperation(true, 'Hemodiyaliz İşlemleri listeleniyor, lütfen bekleyiniz.');

        that.httpService.post<HemodialysisAppointmentItem[]>("api/HemodialysisAppointmentService/GetHemodialysisAppointmentItem",
            that.hemodialysisAppointmentFormViewModel._hemodialysisSearchCriteria)
            .then(response => {
                that.hemodialysisAppointmentFormViewModel.HemodialysisAppointmentItemList = response as HemodialysisAppointmentItem[];

                that.loadPanelOperation(false, '');
                //setTimeout(function () {
                //    //that.physiotherapyWorkListGrid.instance.repaint();
                //}, 150);
            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                this.messageService.showError(error);

            });

    }

    @ViewChild('dialysisFrequencySelectbox') dialysisFrequencySelectbox: DxSelectBoxComponent;
    @ViewChild('packageProcedureSelectbox') packageProcedureSelectbox: DxSelectBoxComponent;
    @ViewChild('treatmentEquipmentSelectbox') treatmentEquipmentSelectbox: DxSelectBoxComponent;

    async select(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            this.loadPanelOperation(true, i18n("M14461", "Form hazırlanıyor, lütfen bekleyiniz."));
            console.log();
            let _data: HemodialysisAppointmentItem = value.data as HemodialysisAppointmentItem;

            let that = this;

            this.isTakvim = false;

            that.httpService.get<any>("api/HemodialysisAppointmentService/GetHemodialysisObject?ObjectID=" + _data.ObjectID + "&ObjectDefID=" + _data.ObjectDefID)
                .then(async response => {
                    let result: HemodialysisAppointmentFormViewModel = <HemodialysisAppointmentFormViewModel>response;
                    this.hemodialysisAppointmentFormViewModel._HemodialysisOrder = result._HemodialysisOrder as HemodialysisOrder;
                    this.hemodialysisAppointmentFormViewModel._Appointment = result._Appointment as Appointment;

                    if (typeof (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.DialysisFrequency) == 'string') {
                        this.dialysisFrequencySelectbox.value = this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.DialysisFrequency;
                    } else {
                        this.dialysisFrequencySelectbox.value = this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.DialysisFrequency.ObjectID;
                    }

                    if (typeof (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.PackageProcedure) == 'string') {
                        this.packageProcedureSelectbox.value = this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.PackageProcedure;
                    } else {
                        this.packageProcedureSelectbox.value = this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.PackageProcedure.ObjectID;
                    }

                    if (typeof (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.TreatmentEquipment) == 'string') {
                        this.treatmentEquipmentSelectbox.value = this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.TreatmentEquipment;
                    } else {
                        this.treatmentEquipmentSelectbox.value = this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.TreatmentEquipment.ObjectID;
                    }

                    await this.FillAppointments();
                    this.isTakvim = true;

                    this.loadPanelOperation(false, '');
                })
                .catch(error => {
                    this.messageService.showError(error);
                    this.loadPanelOperation(false, '');
                });
        }
    }

    //#region Takvim

    @ViewChild('detailScheduler') _detailSchedulerInstance: DxSchedulerComponent;

    isTakvim: any = false;

    appointmentsData: GivenAppointment[];
    resourcesData: GivenResource[];
    masterResourcesData: GivenResource[];
    appOrSchTypesData: AppOrSchType[];
    currentDate: Date = new Date(Date.now());
    recTime: Date = new Date(Date.now());
    MobilePhone: TTVisual.ITTMaskedTextBox;
    public CellDurationForAppointMent: Number = 15;
    private _txtPatientIsDisabled: boolean;


    dateRangeChanged: boolean = true;
    timeOut: any;
    groups: ['masterOwnerObjectID', 'ownerObjectID'];
    views: any = [{
        type: 'day',
        groups: ['masterOwnerObjectID', 'ownerObjectID'],
        dateCellTemplate: 'dateCellTemplate',
        text: 'Gün',
    }, {
        type: 'week',
        groups: ['masterOwnerObjectID', 'ownerObjectID'],
        dateCellTemplate: 'dateCellTemplate',
        text: 'Hafta',

    }, {
        type: 'month',
        groups: ['masterOwnerObjectID', 'ownerObjectID'],
        dateCellTemplate: 'dateCellTemplate',
        text: 'Ay',
    }];

    async FillAppointments() {
        //if (this.hemodialysisAppointmentFormViewModel.SelectedSubResourceList.length > 0) {
        this.dateRangeChanged = false;
        let appointmentInputDVO: AppointmentInputDVO = new AppointmentInputDVO();
        this.appointmentsData = new Array<GivenAppointment>();
        this.resourcesData = new Array<GivenResource>();
        this.masterResourcesData = new Array<GivenResource>();
        this.appOrSchTypesData = new Array<AppOrSchType>();
        let appDate: Date = Convert.ToDateTime(this.hemodialysisAppointmentFormViewModel._Appointment.AppDate);
        this.currentDate = appDate;
        appointmentInputDVO.AppDate = new Date(appDate.getFullYear(), appDate.getMonth(), appDate.getDate(), 0, 0, 0);

        if (this.hemodialysisAppointmentFormViewModel._Appointment.Resource) {
            if (typeof this.hemodialysisAppointmentFormViewModel._Appointment.Resource == "string") {
                appointmentInputDVO.ownerObjectID = this.hemodialysisAppointmentFormViewModel._Appointment.Resource;
                appointmentInputDVO.SelectedOwnerResources.push(appointmentInputDVO.ownerObjectID);
            } else {
                appointmentInputDVO.ownerObjectID = this.hemodialysisAppointmentFormViewModel._Appointment.Resource.ObjectID.toString();
                appointmentInputDVO.SelectedOwnerResources.push(appointmentInputDVO.ownerObjectID);
            }
        }
        //appointmentInputDVO.SelectedOwnerResources = this.hemodialysisAppointmentFormViewModel.SelectedSubResourceList;
        if (typeof this.hemodialysisAppointmentFormViewModel._Appointment.MasterResource == "string") {
            appointmentInputDVO.masterOwnerObjectID = this.hemodialysisAppointmentFormViewModel._Appointment.MasterResource;
        } else {
            appointmentInputDVO.masterOwnerObjectID = this.hemodialysisAppointmentFormViewModel._Appointment.MasterResource.ObjectID.toString();
        }

        appointmentInputDVO.AllResourcesAndColors = this.hemodialysisAppointmentFormViewModel.AllResourcesAndColors;
        //appointmentInputDVO.appointmentType = this.hemodialysisAppointmentFormViewModel._Appointment.AppointmentType;
        //appointmentInputDVO.showAppointmentsOfPatient = this.showAppointmentsOfPatient;
        //if (this._detailSchedulerInstance.currentView)
        appointmentInputDVO.currentView = "week";//this._detailSchedulerInstance.currentView.toString();
        let givenAppointmentsAndSchedules: GivenAppointmentsAndSchedules = await this.GetAppointmentsAndSchedules(appointmentInputDVO);
        this.appointmentsData = givenAppointmentsAndSchedules.GivenAppointments;
        this.resourcesData = givenAppointmentsAndSchedules.SubResources;
        this.masterResourcesData = givenAppointmentsAndSchedules.MasterResources;
        this.appOrSchTypesData = givenAppointmentsAndSchedules.AppOrSchTypes;
        if (this.hemodialysisAppointmentFormViewModel.SubResourceList.length > 0) {
            let resource: Resource = this.hemodialysisAppointmentFormViewModel.SubResourceList.find(x => x.ObjectID.toString() == this.hemodialysisAppointmentFormViewModel.SelectedSubResourceList[0])
            if (resource)
                this.hemodialysisAppointmentFormViewModel._Appointment.Resource = resource;
        }
        //}
        //else
        //    this.hemodialysisAppointmentFormViewModel._Appointment.Resource = null;
        await this.repaintScheduler();
    }

    async GetAppointmentsAndSchedules(appointmentInputDVO: AppointmentInputDVO): Promise<GivenAppointmentsAndSchedules> {
        let url: string = "/api/AppointmentService/GetAppointmentsAndSchedules";
        let body = appointmentInputDVO;
        let result = await this.httpService.post<GivenAppointmentsAndSchedules>(url, body, GivenAppointmentsAndSchedules);
        let output: GivenAppointmentsAndSchedules = result;
        return output;
    }

    onAppointmentFormCreated(data) {
        //var form = data.form;
        this._detailSchedulerInstance.instance.hideAppointmentPopup(false);
        //this.openGivenAppointment();
    }

    async repaintScheduler() {
        let that = this;
        setTimeout(function () {
            that._detailSchedulerInstance.instance.repaint();
            let appDate: Date;
            if (that.hemodialysisAppointmentFormViewModel._Appointment.AppDate) {
                appDate = (Convert.ToDateTime(that.hemodialysisAppointmentFormViewModel._Appointment.AppDate));

                //that._detailSchedulerInstance.instance.scrollToTime(appDate.getHours(), 0, appDate);
                that._detailSchedulerInstance.instance.scrollToTime(7, 0, appDate);
            }
        }, 50);
    }
    //#endregion

    public saveClick() {
        let that = this;

        this.loadPanelOperation(true, 'Randevu işlemi kaydediliyor, lütfen bekleyiniz.');

        that.httpService.post<any>("api/HemodialysisAppointmentService/CreateOrderDetailAndAppointment", this.hemodialysisAppointmentFormViewModel)
            .then(async response => {
                this.messageService.showSuccess("Randevu işlemi başarılı bir şekilde kaydedildi.");

                await this.FillAppointments();

                this.loadPanelOperation(false, '');

            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                this.messageService.showError(error);

            });
    }

    onAppointmentClick(e: any) {
        //let that = this;
        //clearTimeout(that.timeOut);
    }


    public componentUpdateAppointmentInfo: DynamicComponentInfo = new DynamicComponentInfo();
    public showUpdateAppointmentPopup: boolean = false;
    updateGivenAppointments(givenAppointment: any) {
        if (givenAppointment) {
            let givenApp: GivenAppointment = <GivenAppointment>givenAppointment;
            let that = this;
            that.httpService.post<GivenHemodialysisAppointmentDVO>("api/HemodialysisAppointmentService/GetGivenHemodialysisAppointmentDVO", givenApp)
                .then(response => {
                    let result = response as GivenHemodialysisAppointmentDVO;
                    this.hemodialysisAppointmentFormViewModel._GivenHemodialysisAppointmentDVO = result;

                    let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                    if (result.hemodialysisOrderObjectId != null) {
                        compInfo.objectID = result.hemodialysisOrderObjectId.toString();
                    } else {
                        compInfo.objectID = null;
                    }
                    compInfo.ComponentName = 'HemodialysisPlanForm';
                    compInfo.ModuleName = 'HemodiyalizModule';
                    compInfo.ModulePath = 'Modules/Tibbi_Surec/Hemodiyaliz_Modulu/HemodiyalizModule';

                    this.componentUpdateAppointmentInfo = compInfo;

                    this.showUpdateAppointmentPopup = true;
                    this.loadPanelOperation(false, '');
                })
                .catch(error => {
                    this.loadPanelOperation(false, '');
                    this.showUpdateAppointmentPopup = false;
                    this.messageService.showError(error);

                });
        }
        else {
            ServiceLocator.MessageService.showError("Randevu türünde olmayan öğeler güncellenemez.");
        }
    }
    public cancelupdateClick() {
        this.showUpdateAppointmentPopup = false;
    }
    public updateClick() {
        let that = this;

        this.loadPanelOperation(true, 'Randevu işlemi güncelleniyor, lütfen bekleyiniz.');

        that.httpService.post<any>("api/HemodialysisAppointmentService/UpdateOrderDetailAndAppointment", this.hemodialysisAppointmentFormViewModel._GivenHemodialysisAppointmentDVO)
            .then(async response => {
                this.messageService.showSuccess("Randevu işlemi başarılı bir şekilde güncellendi.");

                this.showUpdateAppointmentPopup = false;

                await this.FillAppointments();

                this.loadPanelOperation(false, '');
            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                this.showUpdateAppointmentPopup = false;
                this.messageService.showError(error);

            });
    }


    public async cancelAppointments(givenAppointment: any) {
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Randevu silme!", "Seçtiğiniz randevu silinecektir. Devam etmek istiyor musunuz?");
        if (messageResult === "E") {
            if (givenAppointment) {
                let givenApp: GivenAppointment = <GivenAppointment>givenAppointment;
                let that = this;
                that.httpService.post<GivenHemodialysisAppointmentDVO>("api/HemodialysisAppointmentService/CancelOrderDetailAndAppointment", givenApp)
                    .then(async response => {

                        this.messageService.showSuccess("Randevu işlemi başarılı bir şekilde silindi.");

                        await this.FillAppointments();

                        this.loadPanelOperation(false, '');
                    })
                    .catch(error => {
                        this.loadPanelOperation(false, '');
                        this.messageService.showError(error);

                    });
            }
            else {
                ServiceLocator.MessageService.showError("Randevu türünde olmayan öğeler silinemez.");
            }
        } else {
            //this.messageService.showError("Pandemi olgusu U07.3 tanısı eklemeden pandemi olgusunu kayıt edemezsiniz!");
            return;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this.hemodialysisAppointmentFormViewModel = new HemodialysisAppointmentFormViewModel();
        this.hemodialysisAppointmentFormViewModel._Appointment = new Appointment();
        //this.hemodialysisAppointmentFormViewModel._Appointment.AppointmentDefinition = new AppointmentDefinition();
        //this.hemodialysisAppointmentFormViewModel._Appointment.AppointmentCarrier = new AppointmentCarrier();
        this.hemodialysisAppointmentFormViewModel._Appointment.MasterResource = new Resource();
        this.hemodialysisAppointmentFormViewModel._Appointment.Resource = new Resource();

        this.hemodialysisAppointmentFormViewModel.ReadOnly = true;

        this.hemodialysisAppointmentFormViewModel._hemodialysisSearchCriteria = new HemodialysisSearchCriteria();

        this.hemodialysisAppointmentFormViewModel._HemodialysisOrder = new HemodialysisOrder();

        this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.TreatmentEquipment = new ResEquipment();
        this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.PackageProcedure = new PackageProcedureDefinition();
        this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.DialysisFrequency = new SKRSDiyalizeGirmeSikligi();
    }

    protected loadViewModel() {
        let that = this;
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder == null)
            this.hemodialysisAppointmentFormViewModel = new HemodialysisAppointmentFormViewModel();
        if (that.hemodialysisAppointmentFormViewModel._Appointment == null)
            that.hemodialysisAppointmentFormViewModel._Appointment = new Appointment();

        this.hemodialysisAppointmentFormViewModel._Appointment.AppDate = this.currentDate;

        //let startTime: Date = Convert.ToDateTime(that.hemodialysisAppointmentFormViewModel._Appointment.StartTime);
        //let endTime: Date = Convert.ToDateTime(that.hemodialysisAppointmentFormViewModel._Appointment.EndTime);

        that.hemodialysisAppointmentFormViewModel._Appointment.StartTime = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth(), this.currentDate.getDate(), 8, 0, 0);
        that.hemodialysisAppointmentFormViewModel._Appointment.EndTime = new Date(this.currentDate.getFullYear(), this.currentDate.getMonth(), this.currentDate.getDate(), 8, 15, 0);
    }

    async ngOnInit() {
        let that = this;
        this.loadViewModel();
    }


    public onDialysisFrequencyChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.DialysisFrequency != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.DialysisFrequency = event;
        }
    }

    public onDurationChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.Duration != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.Duration = event;
        }
    }

    public onEmergencyChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.Emergency != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.Emergency = event;
        }
    }

    public onInformationChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.Information != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.Information = event;
        }
    }

    public onIsWeekendIncludeChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.IsWeekendInclude != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.IsWeekendInclude = event;
        }
    }

    public onPackageProcedureChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.PackageProcedure != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.PackageProcedure = event;
        }
    }

    public onSessionCountChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.SessionCount != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.SessionCount = event;
        }
    }

    public onSessionDayRangeChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.SessionDayRange != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.SessionDayRange = event;
        }
    }

    public onSessionDayRangeTypeChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.SessionDayRangeType != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.SessionDayRangeType = event;
        }
    }

    public onTreatmentEquipmentChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.TreatmentEquipment != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.TreatmentEquipment = event;
        }
    }

    public onTreatmentStartDateTimeChanged(event): void {
        if (this.hemodialysisAppointmentFormViewModel._HemodialysisOrder != null && this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.TreatmentStartDateTime != event) {
            this.hemodialysisAppointmentFormViewModel._HemodialysisOrder.TreatmentStartDateTime = event;
        }
    }

    public async onAppDateChanged(event) {
        if (event) {
            if (event.previousValue) {
                let currDate: Date = new Date(event.value);
                this.currentDate = currDate;
                if (this.hemodialysisAppointmentFormViewModel._Appointment.StartTime == null) {
                    this.hemodialysisAppointmentFormViewModel._Appointment.StartTime = event.value;
                }
                this.hemodialysisAppointmentFormViewModel._Appointment.StartTime = new Date(currDate.getFullYear(), currDate.getMonth(), currDate.getDate(), this.hemodialysisAppointmentFormViewModel._Appointment.StartTime.getHours(), this.hemodialysisAppointmentFormViewModel._Appointment.StartTime.getMinutes(), 0);
            }
        }
    }

    public async onAppStartTimeChanged(event) {
        if (event) {
            if (event.previousValue) {
                let currTime: Date = new Date(event.value);
                let previousTime: Date = new Date(event.previousValue);

                if (currTime != previousTime) {
                    //this.hemodialysisAppointmentFormViewModel._Appointment.AppDate = currTime;
                    if (this.hemodialysisAppointmentFormViewModel.selectedAppointmentSchedule)
                        this.hemodialysisAppointmentFormViewModel._Appointment.EndTime = this.hemodialysisAppointmentFormViewModel.selectedAppointmentSchedule.endDate;
                    else if (this.hemodialysisAppointmentFormViewModel._myOldAppointment)
                        this.hemodialysisAppointmentFormViewModel._Appointment.EndTime = this.hemodialysisAppointmentFormViewModel._myOldAppointment.endDate;
                    else
                        this.hemodialysisAppointmentFormViewModel._Appointment.EndTime = currTime.AddMinutes(15); //15dk ekleme
                }
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.TreatmentStartDateTime, "Value", this.__ttObject, "TreatmentStartDateTime");
        redirectProperty(this.SessionDayRange, "Text", this.__ttObject, "SessionDayRange");
        redirectProperty(this.SessionDayRangeType, "Value", this.__ttObject, "SessionDayRangeType");
        redirectProperty(this.SessionCount, "Text", this.__ttObject, "SessionCount");
        redirectProperty(this.Duration, "Text", this.__ttObject, "Duration");
        redirectProperty(this.IsWeekendInclude, "Value", this.__ttObject, "IsWeekendInclude");
        redirectProperty(this.Information, "Text", this.__ttObject, "Information");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
    }

    public initFormControls(): void {
        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = "Acil";
        this.Emergency.Title = "Acil";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 26;

        this.IsWeekendInclude = new TTVisual.TTCheckBox();
        this.IsWeekendInclude.Value = false;
        this.IsWeekendInclude.Text = "Hafta Sonları Dahil";
        this.IsWeekendInclude.Title = "Hafta Sonları Dahil";
        this.IsWeekendInclude.Name = "IsWeekendInclude";
        this.IsWeekendInclude.TabIndex = 25;

        this.labelDuration = new TTVisual.TTLabel();
        this.labelDuration.Text = "Süre";
        this.labelDuration.Name = "labelDuration";
        this.labelDuration.TabIndex = 24;

        this.Duration = new TTVisual.TTTextBox();
        //this.Duration.Required = true;
        //this.Duration.BackColor = "#FFE3C6";
        this.Duration.Name = "Duration";
        this.Duration.TabIndex = 23;

        this.SessionDayRange = new TTVisual.TTTextBox();
        this.SessionDayRange.Name = "SessionDayRange";
        this.SessionDayRange.TabIndex = 2;

        this.SessionCount = new TTVisual.TTTextBox();
        this.SessionCount.Name = "SessionCount";
        this.SessionCount.TabIndex = 0;

        this.Information = new TTVisual.TTTextBox();
        this.Information.Name = "Information";
        this.Information.TabIndex = 19;

        this.labelTreatmentEquipment = new TTVisual.TTLabel();
        this.labelTreatmentEquipment.Text = "Cihaz";
        this.labelTreatmentEquipment.Name = "labelTreatmentEquipment";
        this.labelTreatmentEquipment.TabIndex = 22;

        this.TreatmentEquipment = new TTVisual.TTObjectListBox();
        this.TreatmentEquipment.Required = true;
        this.TreatmentEquipment.ListDefName = "EquipmentListDefinition";
        this.TreatmentEquipment.Name = "TreatmentEquipment";
        this.TreatmentEquipment.TabIndex = 21;

        this.labelPackageProcedure = new TTVisual.TTLabel();
        this.labelPackageProcedure.Text = "İşlem";
        this.labelPackageProcedure.Name = "labelPackageProcedure";
        this.labelPackageProcedure.TabIndex = 16;

        this.PackageProcedure = new TTVisual.TTObjectListBox();
        this.PackageProcedure.ListDefName = "DialysisPackageProcedureList";
        this.PackageProcedure.Name = "PackageProcedure";
        this.PackageProcedure.TabIndex = 15;

        this.labelDialysisFrequency = new TTVisual.TTLabel();
        this.labelDialysisFrequency.Text = "Diyalize Girme Sıklığı";
        this.labelDialysisFrequency.Name = "labelDialysisFrequency";
        this.labelDialysisFrequency.TabIndex = 14;

        this.DialysisFrequency = new TTVisual.TTObjectListBox();
        this.DialysisFrequency.ListDefName = "SKRSDiyalizeGirmeSikligiList";
        this.DialysisFrequency.Name = "DialysisFrequency";
        this.DialysisFrequency.TabIndex = 13;

        this.labelTreatmentStartDateTime = new TTVisual.TTLabel();
        this.labelTreatmentStartDateTime.Text = "Başlangıç Tarihi";
        this.labelTreatmentStartDateTime.Name = "labelTreatmentStartDateTime";
        this.labelTreatmentStartDateTime.TabIndex = 9;

        this.TreatmentStartDateTime = new TTVisual.TTDateTimePicker();
        this.TreatmentStartDateTime.Format = DateTimePickerFormat.Long;
        this.TreatmentStartDateTime.Name = "TreatmentStartDateTime";
        this.TreatmentStartDateTime.TabIndex = 8;

        this.labelSessionDayRangeType = new TTVisual.TTLabel();
        this.labelSessionDayRangeType.Text = "Seans Gün Aralığı Tipi";
        this.labelSessionDayRangeType.Name = "labelSessionDayRangeType";
        this.labelSessionDayRangeType.TabIndex = 5;

        this.SessionDayRangeType = new TTVisual.TTEnumComboBox();
        this.SessionDayRangeType.DataTypeName = "PeriodUnitTypeEnum";
        this.SessionDayRangeType.Name = "SessionDayRangeType";
        this.SessionDayRangeType.TabIndex = 4;

        this.labelSessionDayRange = new TTVisual.TTLabel();
        this.labelSessionDayRange.Text = "Seans Gün Aralığı";
        this.labelSessionDayRange.Name = "labelSessionDayRange";
        this.labelSessionDayRange.TabIndex = 3;

        this.labelSessionCount = new TTVisual.TTLabel();
        this.labelSessionCount.Text = "Seans Sayısı";
        this.labelSessionCount.Name = "labelSessionCount";
        this.labelSessionCount.TabIndex = 1;

        this.labelInformation = new TTVisual.TTLabel();
        this.labelInformation.Text = "Açıklama";
        this.labelInformation.Name = "labelInformation";
        this.labelInformation.TabIndex = 20;

        this.Controls = [this.Emergency, this.IsWeekendInclude, this.labelDuration, this.Duration, this.SessionDayRange, this.SessionCount, this.Information, this.labelTreatmentEquipment, this.TreatmentEquipment, this.labelPackageProcedure, this.PackageProcedure, this.labelDialysisFrequency, this.DialysisFrequency, this.labelTreatmentStartDateTime, this.TreatmentStartDateTime, this.labelSessionDayRangeType, this.SessionDayRangeType, this.labelSessionDayRange, this.labelSessionCount, this.labelInformation];

    }


}
