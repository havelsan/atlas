//$98DD09E8

import { Component, ViewChild, OnInit, NgZone, Renderer2 } from '@angular/core';
import { AppointmentFormViewModel, AppointmentCarrierDVO, AppointmentTypeDVO, AppointmentTypeListDVO, MasterResourceDVO, MasterResourceInputDVO, SubResourceDVO, SubResourceInputDVO } from './AppointmentFormViewModel';
import { AppointmentInputDVO, GivenAppointmentsAndSchedules, GivenResource, GivenAppointment, ResourceAndColorDVO, AppOrSchType, AppointmentToSaveDVO, AppointmentToUpdateDVO, AppointmentForUpdateDeleteApproveDVO } from './AppointmentFormViewModel';
import { DxSchedulerComponent, DxContextMenuComponent } from "devextreme-angular";
import { Patient, PatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentCarrier } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { PhoneTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { PlannedAction } from 'NebulaClient/Model/AtlasClientModel';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { MernisPatientModel } from "../Kayit_Kabul_Modulu/PatientAdmissionFormViewModel";
import { CommonHelper } from 'app/Helper/CommonHelper';

import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { SystemParameterService } from '../../../wwwroot/app/NebulaClient/Services/ObjectService/SystemParameterService';

@Component({
    selector: 'AppointmentForm',
    templateUrl: './AppointmentForm.html',
    inputs: ['Model'],
    providers: [SystemApiService],
})
export class AppointmentForm extends TTVisual.TTForm implements OnInit {
    public appointmentCarrierList: Array<AppointmentCarrierDVO>;
    public policlinicList: Array<MasterResourceDVO>;
    public doctorlist: Array<Resource>;
    public searchMenuTxt: string;
    cellContextMenuItems: any;
    //AppointmentsListView: TTVisual.ITTListView;
    phoneTypeRadioItems: PhoneTypeEnum; //Array<any> = [{ value: 0, text: 'Ev' }, { value: 1, text: 'Cep' }];

    //TODO Hastanın tüm randevularını göstermek için kullanılabilir.(sonra)
    public showAppointmentsOfPatient: boolean = false;
    //patientSearchFormVisible: boolean = true;

    appointmentsData: GivenAppointment[] = new Array<GivenAppointment>();
    resourcesData: GivenResource[] = new Array<GivenResource>();
    masterResourcesData: GivenResource[] = new Array<GivenResource>();
    appOrSchTypesData: AppOrSchType[] = new Array<AppOrSchType>();
    currentDate: Date = new Date(Date.now());
    recTime: Date = new Date(Date.now());
    MobilePhone: TTVisual.ITTMaskedTextBox;
    public CellDurationForAppointMent: Number = 15;
    private _txtPatientIsDisabled: boolean;

    public get txtPatientIsDisabled(): boolean {
        if (this.appointmentFormViewModel.currentPatient != null || this.appointmentFormViewModel.currentPatient != undefined)
            this._txtPatientIsDisabled = true;
        else
            this._txtPatientIsDisabled = false;
        return this._txtPatientIsDisabled;
    }

    public set txtPatientIsDisabled(value: boolean) {
        this._txtPatientIsDisabled = value;
    }
    private _isStateAppointment: boolean;

    public get isStateAppointment(): boolean {
        //if (this.appointmentFormViewModel.CurrentObject && this.appointmentFormViewModel.CurrentObjectTransDefID)
        if (!this.appointmentFormViewModel.isAdmissionAppointment)
            this._isStateAppointment = true;
        else
            this._isStateAppointment = false;
        return this._isStateAppointment;
    }

    public set isStateAppointment(value: boolean) {
        this._isStateAppointment = value;
    }

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

    currentView: any = this.views[1].type;

    public AppointmentColumns = [
        {
            caption: i18n("M22846", "Tarihi"),
            dataField: "strAppDate",
            width: "auto",
            fixed: true,
            sortOrder: 'asc',
            sortIndex: 0,
            allowSorting: true
        },
        {
            caption: i18n("M21089", "Saati"),
            dataField: "strAppTime",
            width: "auto",
            fixed: true,
            sortOrder: 'asc',
            sortIndex: 1,
            allowSorting: true
        },
        {
            caption: i18n("M23679", "Cinsi"),
            dataField: "strType",
            width: "auto",
            fixed: true,
            allowSorting: true
        },
        {
            "caption": i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "txtPatient",
            width: "auto",
            fixed: true,
            allowSorting: true
        },
        {
            "caption": i18n("M17440", "Kaynak"),
            dataField: "appResources",
            width: "auto",
            visible: true,
            allowSorting: true
        },
        {
            "caption": "Durum",
            dataField: "appStatus",
            width: "auto",
            allowSorting: true
        },
        {
            "caption": i18n("M17350", "Kategori"),
            dataField: "appCategory",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M19476", "Not"),
            dataField: "text",
            width: 75,
            allowSorting: true
        },
        {
            cellTemplate: 'buttonCellTemplate',
            alignment: 'left',
            allowResizing: false,
            allowEditing: false,
            fixedPosition: "right",
            fixed: true,
            cssClass: 'remove-padding',
            width: "auto",
        }
    ];

    btnGiveAppVisible(e) {
        return e.row.data.rowButtonType == 2;
    }

    btnUpdateAppVisible(e) {
        return e.row.data.rowButtonType == 1;
    }


    rowPrepared(row: any) {
        if (row.rowType == "data") {
            if (row.data.rowColor != null && row.data.rowColor != "") {
                //this.renderer.setStyle(row.rowElement.firstItem(), "color", row.data.rowColor);
                row.rowElement.firstItem().style.color = row.data.rowColor;
            }
            if (row.data.rowButtonType) {
                if (row.data.rowButtonType == 3) {
                    //this.renderer.setStyle(row.rowElement.firstItem(), "font-weight", 550);
                    row.rowElement.firstItem().style.fontWeight = 550;
                }
                else if (row.data.rowButtonType == 1) {
                    row.rowElement.firstItem().style.fontWeight = 550;
                    //this.renderer.setStyle(row.rowElement.firstItem(), "font-weight", 550);
                }
                else if (row.data.rowButtonType == 2) {

                }
            }
        }
    }


    @ViewChild('detailScheduler') _detailSchedulerInstance: DxSchedulerComponent;

    public appointmentFormViewModel: AppointmentFormViewModel = new AppointmentFormViewModel();
    public get _Appointment(): Appointment {
        return this._TTObject as Appointment;
    }
    private AppointmentForm_DocumentUrl: string = '/api/AppointmentService/AppointmentForm';

    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalService: IModalService,
        protected ngZone: NgZone,
        private renderer: Renderer2) {
        super('APPOINTMENT', 'AppointmentForm');
        this._DocumentServiceUrl = this.AppointmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.cellContextMenuItems = [
            { text: 'Yeni Randevu', onItemClick: () => this.createAppointment() },
            //{ text: 'Yeni Planlı Randevu', onItemClick: () => this.createRecurringAppointment() },
            //{ text: 'Group by Room/Ungroup', beginGroup: true, onItemClick: () => this.groupCell() },
            //{ text: 'Bugüne Git', onItemClick: () => this.showCurrentDate() }
        ];
    }
    contextMenuCellData: any;
    onCellContextMenu(e) {
        this.contextMenuCellData = e.cellData;
    }

    onContextMenuItemClick(e) {
        e.itemData.onItemClick(e.itemData);
    }

    btnGiveAppClick(e) {
        if (e.row.data) {
            this.contextMenuCellData = e.row.data;
            this.giveAppointments(e.row.data);
        }
    }

    btnUpdateAppClick(e) {
        if (e.row.data) {
            this.contextMenuCellData = e.row.data;
            this.updateGivenAppointments(e.row.data);
        }
    }

    btnCancelAppClick(e) {
        if (e.row.data) {
            this.contextMenuCellData = e.row.data;
            this.cancelAppointments(e.row.data);
        }
    }

    ////Seçilen hastayı çağırmak için right click
    //onContextMenuPreparing(e: any): void {
    //    let that = this;

    //    if (e.row !== undefined && e.row !== null) {
    //        if (e.row.rowType === 'data') {
    //            e.items = [{
    //                text: i18n("M15531", "Yeni Randevu"),
    //                disabled: false,
    //                onItemClick: function () {
    //                    that.createAppointment();
    //                }
    //            }];
    //        }
    //    }
    //}

    public createAppointment() {
        this.appointmentFormViewModel.selectedAppointmentSchedule = null;
        this.appointmentFormViewModel._myOldAppointment = null;
        if (this.appointmentFormViewModel.currentPatient) {
            this.appointmentFormViewModel._Appointment.Patient = this.appointmentFormViewModel.currentPatient;
            if (!this.appointmentFormViewModel.txtPatient)
                this.appointmentFormViewModel.txtPatient = this.appointmentFormViewModel.currentPatient.PatientIDandFullName;
            this.appointmentFormViewModel.TCKNo = this.appointmentFormViewModel.currentPatient.UniqueRefNo;
            this.appointmentFormViewModel.PhoneNumber = this.appointmentFormViewModel.currentPatient.MobilePhone;
            this.appointmentFormViewModel.osPhoneType = this.appointmentFormViewModel.osPhoneType;
        }
        else {
            this.appointmentFormViewModel._Appointment.Patient = null;
            this.appointmentFormViewModel.txtPatient = null;
            this.appointmentFormViewModel.TCKNo = null;
            this.appointmentFormViewModel.PhoneNumber = null;
            this.appointmentFormViewModel.osPhoneType = this.appointmentFormViewModel.osPhoneType;
        }
        this.appointmentFormViewModel._Appointment.AppDate = this.contextMenuCellData.startDate;
        this.appointmentFormViewModel._Appointment.StartTime = this.contextMenuCellData.startDate;
        this.appointmentFormViewModel._Appointment.EndTime = this.contextMenuCellData.endDate;
        if (this.contextMenuCellData.groups)
            this.appointmentFormViewModel._Appointment.Resource = this.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == this.contextMenuCellData.groups.ownerObjectID.toString());
        else
            this.appointmentFormViewModel._Appointment.Resource = this.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == this.contextMenuCellData.ownerObjectID.toString());
        this.contextMenuCellData.cancel = false;
        this.openGivenAppointment();
        if (this.appointmentFormViewModel._Appointment.AppointmentDefinition.StateOnly && this.appointmentFormViewModel.isAdmissionAppointment) {
            ServiceLocator.MessageService.showError(i18n("M22418", "Süreç randevusu türündeki randevular, sadece süreç içinden verilebilir."));
            this.contextMenuCellData.cancel = true;
            return false;
        }

    }

    createRecurringAppointment() {
        this._detailSchedulerInstance.instance.showAppointmentPopup({
            startDate: this.contextMenuCellData.startDate,
            recurrenceRule: "FREQ=DAILY"
        }, true);
    }

    public setInputParam(value: AppointmentFormViewModel) {
        if (value != null) {
            this.appointmentFormViewModel = new AppointmentFormViewModel();
            this.appointmentFormViewModel.CurrentObject = value.CurrentObject;
            this.appointmentFormViewModel.StarterObject = value.StarterObject;
            this.appointmentFormViewModel.CurrentObjectTransDefID = value.CurrentObjectTransDefID;
            this._ViewModel = this.appointmentFormViewModel;
        }
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    isFirstLoad: boolean;
    doNotLoadSubResource: boolean;
    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Appointment();
        this.appointmentFormViewModel = new AppointmentFormViewModel();
        this._ViewModel = this.appointmentFormViewModel;
        this.appointmentFormViewModel._Appointment = this._TTObject as Appointment;
        this.appointmentFormViewModel._Appointment.AppointmentDefinition = new AppointmentDefinition();
        this.appointmentFormViewModel._Appointment.AppointmentCarrier = new AppointmentCarrier();
        this.appointmentFormViewModel._Appointment.MasterResource = new Resource();
        this.appointmentFormViewModel._Appointment.Resource = new Resource();
        this.appointmentFormViewModel.appointmentToUpdateDVO = new AppointmentToUpdateDVO();
        this.appointmentFormViewModel._myOldAppointment = null;
        this.appointmentFormViewModel.CurrentObject = null;
        this.appointmentFormViewModel.StarterObject = null;
        this.appointmentFormViewModel.currentPatient = null;
        this.appointmentFormViewModel.ReadOnly = true;
        this.txtPatientIsDisabled = true;
    }

    protected loadViewModel() {
        let that = this;
        that.isFirstLoad = true;
        that.appointmentFormViewModel = that._ViewModel as AppointmentFormViewModel;
        that._TTObject = that.appointmentFormViewModel._Appointment;
        if (that.appointmentFormViewModel == null)
            that.appointmentFormViewModel = new AppointmentFormViewModel();
        if (that.appointmentFormViewModel._Appointment == null)
            that.appointmentFormViewModel._Appointment = new Appointment();

        if (that.appointmentFormViewModel.currentPatient) {
            that.appointmentFormViewModel._Appointment.Patient = that.appointmentFormViewModel.currentPatient;
            if (!that.appointmentFormViewModel.txtPatient)
                that.appointmentFormViewModel.txtPatient = that.appointmentFormViewModel.currentPatient.PatientIDandFullName;
            that.appointmentFormViewModel.TCKNo = (<Patient>that.appointmentFormViewModel.currentPatient).UniqueRefNo;
            that.appointmentFormViewModel.PhoneNumber = that.appointmentFormViewModel.currentPatient.MobilePhone;
            that.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.GSM;
            if (that.appointmentFormViewModel.StarterObject && that.appointmentFormViewModel.StarterObject.ObjectDefID.toString() === PatientAdmission.ObjectDefID.id)
                that.appointmentFormViewModel.patientSearchFormVisible = true;
            else
                that.appointmentFormViewModel.patientSearchFormVisible = false;
        }
        else
            that.appointmentFormViewModel.patientSearchFormVisible = true;

        let appointmentDefinitionObjectID = that.appointmentFormViewModel._Appointment["AppointmentDefinition"];
        if (appointmentDefinitionObjectID && that.appointmentFormViewModel.AppointmentDefinitionList) {
            let appointmentDefinition = that.appointmentFormViewModel.AppointmentDefinitionList.find(o => o.ObjectID.toString() === appointmentDefinitionObjectID.toString());
            if (appointmentDefinition) {
                that.appointmentFormViewModel._Appointment.AppointmentDefinition = appointmentDefinition;
            }
        }

        let appointmentCarrierObjectID = that.appointmentFormViewModel._Appointment["AppointmentCarrier"];
        if (appointmentCarrierObjectID && that.appointmentFormViewModel.AppointmentCarrierList) {
            let appointmentCarrier = that.appointmentFormViewModel.AppointmentCarrierList.find(o => o.ObjectID.toString() === appointmentCarrierObjectID.toString());
            if (appointmentCarrier) {
                that.appointmentFormViewModel._Appointment.AppointmentCarrier = appointmentCarrier;
            }
        }
        if (that.appointmentFormViewModel.AppointmentType) {
            let appointmentTypeObjectID = that.appointmentFormViewModel.AppointmentType.AppointmentType["ObjectID"];
            if (appointmentTypeObjectID && that.appointmentFormViewModel.AppointmentTypeList) {
                let appointmentType = that.appointmentFormViewModel.AppointmentTypeList.find(o => o.AppointmentType.ObjectID.toString() === appointmentTypeObjectID.toString());
                that.appointmentFormViewModel._Appointment.AppointmentType = appointmentType.AppointmentType.Type;
                that.appointmentFormViewModel.AppointmentType = appointmentType;
            }
        }

        let masterResourceObjectID = that.appointmentFormViewModel._Appointment["MasterResource"];
        if (masterResourceObjectID && that.appointmentFormViewModel.MasterResourceList) {
            let masterResource = that.appointmentFormViewModel.MasterResourceList.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.appointmentFormViewModel._Appointment.MasterResource = masterResource;
            }
        }

        let resourceObjectID = that.appointmentFormViewModel._Appointment["Resource"];
        if (resourceObjectID && that.appointmentFormViewModel.SubResourceList) {
            let resource = that.appointmentFormViewModel.SubResourceList.find(o => o.ObjectID.toString() === resourceObjectID.toString());
            if (resource) {
                that.appointmentFormViewModel._Appointment.Resource = resource;
                //that.appointmentFormViewModel.SelectedSubResourceList = new Array<string>();
                //that.appointmentFormViewModel.SelectedSubResourceList.push(resource.ObjectID.toString());
                that.doNotLoadSubResource = true;
            }
            else
                that.doNotLoadSubResource = false;
        }
        let startTime: Date = Convert.ToDateTime(that.appointmentFormViewModel._Appointment.StartTime);
        let endTime: Date = Convert.ToDateTime(that.appointmentFormViewModel._Appointment.EndTime);

        that.appointmentFormViewModel._Appointment.StartTime = new Date(startTime.getFullYear(), startTime.getMonth(), startTime.getDate(), 8, 0, 0);
        that.appointmentFormViewModel._Appointment.EndTime = new Date(endTime.getFullYear(), endTime.getMonth(), endTime.getDate(), 8, 15, 0);
        that.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.GSM;
        //Süreç randevularında(örn Radyoloji) Gün seçeneği default seçili gelsin.
        if (that.isStateAppointment)
            this.currentView = this.views[0].type;
        else
            this.currentView = this._detailSchedulerInstance.currentView;
    }

    async ngOnInit() {
        let that = this;
        this.appointmentFormViewModel.allowAdding = true;
        this.appointmentFormViewModel.allowDeleting = true;
        this.appointmentFormViewModel.allowDragging = true;
        this.appointmentFormViewModel.allowUpdating = true;
        this.isRandevu = await SystemParameterService.GetParameterValue("SHOWLISTVIEWAPPFORM", "TRUE") == "TRUE";
        
        if ((this.appointmentFormViewModel.CurrentObject && this.appointmentFormViewModel.CurrentObjectTransDefID) || this.appointmentFormViewModel.StarterObject) {
            await this.loadForState();

        }
        else {
            await this.load(AppointmentFormViewModel);

        }

    }


    loadForState(): Promise<void> {
        let that = this;
        that._modalInfo.IsShowCloseButton = false;
        let fullApiUrl: string = '/api/AppointmentService/StateAppointmentForm';
        return new Promise<void>((resolve, reject) => {
            let promiseLoad = new Promise<void>((resolveLoad, rejectLoad) => {
                this.httpService.post<AppointmentFormViewModel>(fullApiUrl, that.appointmentFormViewModel, AppointmentFormViewModel).then(response => {
                    that._ViewModel = response;
                    that.loadViewModel();
                    that.processReadOnly();
                    resolveLoad();
                }).catch(err => {
                    rejectLoad(err);
                });
            });

            promiseLoad.then(r1 => {
                that.redirectProperties();
                that.ClientSidePreScript();
            }).then(r2 => {
                that.PreScript().then(r3 => {
                    resolve();
                });
            }).catch(err => {
                reject(err);
            });
        });
    }

    async repaintScheduler() {
        let that = this;
        setTimeout(function () {
            that._detailSchedulerInstance.instance.repaint();
            let appDate: Date;
            if (that.appointmentFormViewModel._Appointment.AppDate) {
                appDate = (Convert.ToDateTime(that.appointmentFormViewModel._Appointment.AppDate));

                //that._detailSchedulerInstance.instance.scrollToTime(appDate.getHours(), 0, appDate);
                that._detailSchedulerInstance.instance.scrollToTime(7, 0, appDate);
            }
        }, 50);
    }


    async ngAfterViewInit() {
        if (!this.isStateAppointment)
            await this.repaintScheduler();
    }

    async clientPreScript() {
        await this.repaintScheduler();
    }

    clientPostScript(state: String) {

    }
    public onMobilePhoneChanged(event): void {
        this.appointmentFormViewModel.PhoneNumber = event;
    }

    async patientChanged(patient: any) {
        if (patient) {
            this.appointmentFormViewModel.txtPatient = patient.PatientIDandFullName;
            this.appointmentFormViewModel.currentPatient = <Patient>patient;
            this.appointmentFormViewModel._Appointment.Patient = <Patient>patient;
            this.appointmentFormViewModel.TCKNo = (<Patient>patient).UniqueRefNo;
            this.appointmentFormViewModel.PhoneNumber = patient.MobilePhone;
            this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.GSM;
        }
        else {
            this.appointmentFormViewModel.currentPatient = null;
            this.appointmentFormViewModel._Appointment.Patient = null;
            this.appointmentFormViewModel.PhoneNumber = null;
            this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.Home;
            if (CommonHelper.IsNumeric(this.appointmentFormViewModel.txtPatient)) {
                let apiUrlKPS: string = 'api/AppointmentService/GetPatientInfoFromKPS?kimlikNo=' + this.appointmentFormViewModel.txtPatient;
                let res = await this.httpService.get<MernisPatientModel>(apiUrlKPS, MernisPatientModel).then(t => {
                    let result = t;
                    if (result) {
                        let output = <MernisPatientModel>result;
                        if (output.KPSName) {
                            if (output.KPSForeign)
                                this.appointmentFormViewModel.TCKNo = output.KPsForeignUniqueRefNo;
                            else
                                this.appointmentFormViewModel.TCKNo = output.KPSUniqueRefNo;
                            this.appointmentFormViewModel.txtPatient = output.KPSName + " " + output.KPSSurname;
                        }
                        else {
                            this.appointmentFormViewModel.TCKNo = null;
                            this.appointmentFormViewModel.txtPatient = "";
                        }
                    }
                    else {
                        this.appointmentFormViewModel.TCKNo = null;
                        this.appointmentFormViewModel.txtPatient = "";
                    }
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
        }
    }

    async appointmentDefinitionSelectedItemChanged() {
        this.appointmentFormViewModel.labelSubResourceVisible = true;
        this.appointmentFormViewModel.subResourceVisible = true;
        if (this.appointmentFormViewModel._Appointment.AppointmentDefinition) {
            let appDef: AppointmentDefinition = <AppointmentDefinition>this.appointmentFormViewModel._Appointment.AppointmentDefinition;
            if (appDef.GiveToMaster) {
                this.appointmentFormViewModel.labelSubResourceVisible = false;
                this.appointmentFormViewModel.subResourceVisible = false;
            }
            if (!this.isFirstLoad) {
                await this.getAppointmentCarrierList(appDef.ObjectID.toString());
            }
            else
                this.isFirstLoad = false;
        }
        else
            this.appointmentFormViewModel._Appointment.AppointmentDefinition = null;

        if (this.appointmentFormViewModel._Appointment.AppointmentDefinition == null) {
            this.CellDurationForAppointMent = 15;
        }
        else {

            if (this.appointmentFormViewModel._Appointment.AppointmentDefinition.ObjectID.toString() == "bd5ac482-0957-47f9-82e7-5c803ad11d08") {
                this.CellDurationForAppointMent = 5;
            } else {
                this.CellDurationForAppointMent = 15;
            }
        }
    }

    async getAppointmentCarrierList(value: string) {
        if (value) {
            let apiUrlCarrier: string = 'api/AppointmentService/FillAppointmentCarrierCombo?appointmentDefObjectID=' + value.toString() + '&isAppointmentListForm=' + this.appointmentFormViewModel.isAppointmentListForm;
            this.appointmentFormViewModel.AppointmentCarrierList = new Array<AppointmentCarrier>();
            this.appointmentFormViewModel.MasterResourceList = new Array<Resource>();
            this.appointmentFormViewModel.SubResourceList = new Array<Resource>();
            let res = await this.httpService.get<AppointmentCarrierDVO>(apiUrlCarrier, AppointmentCarrierDVO);
            let result = res;
            let output = <AppointmentCarrierDVO>result;
            this.appointmentFormViewModel.AppointmentCarrierList = output.AppointmentCarrierList;
            if (output.defaultCarrier != null) {
                let targetCarrier = this.appointmentFormViewModel.AppointmentCarrierList.find(ac => ac.ObjectID.valueOf() === output.defaultCarrier.ObjectID.valueOf());
                if (targetCarrier)
                    this.appointmentFormViewModel._Appointment.AppointmentCarrier = targetCarrier;
                else {
                    if (this.appointmentFormViewModel.AppointmentCarrierList.length > 0)
                        this.appointmentFormViewModel._Appointment.AppointmentCarrier = <AppointmentCarrier>this.appointmentFormViewModel.AppointmentCarrierList[0];
                }
            }
            else {
                if (this.appointmentFormViewModel.AppointmentCarrierList.length > 0)
                    this.appointmentFormViewModel._Appointment.AppointmentCarrier = <AppointmentCarrier>this.appointmentFormViewModel.AppointmentCarrierList[0];
            }
        }
        else
            this.appointmentFormViewModel._Appointment.AppointmentCarrier = null;
    }

    async appointmentCarrierSelectedItemChanged(value: any) {
        if (typeof value == 'object') {
            if (value) {
                let appCarrier: AppointmentCarrier = <AppointmentCarrier>value;
                this.appointmentFormViewModel.MasterResourceCaption = appCarrier.MasterResourceCaption;
                this.appointmentFormViewModel.SubResourceCaption = appCarrier.SubResourceCaption;
                await this.getMasterResourceList(appCarrier);
                await this.getAppointmentTypeList(appCarrier);
                //TODO
                //_appointmentCarrierList.Clear();
                //_appointmentCarrierList.Add(_defaultCarrier);
            }
            else
                this.appointmentFormViewModel._Appointment.AppointmentCarrier = null;
        }
    }

    async getMasterResourceList(value: AppointmentCarrier) {
        if (value) {
            let masterResourceInputDVO = new MasterResourceInputDVO();
            masterResourceInputDVO.appointmentCarrierObjectID = value.ObjectID.toString();
            masterResourceInputDVO.appointmentDefObjectID = this.appointmentFormViewModel._Appointment.AppointmentDefinition.ObjectID.toString();
            masterResourceInputDVO.masterResourceFilter = value.MasterResourceFilter;
            masterResourceInputDVO.masterResourceType = value.MasterResource;
            if (this.appointmentFormViewModel.CurrentObject instanceof PlannedAction) {
                masterResourceInputDVO.currentObjectIsPlannedAction = true;
                masterResourceInputDVO.currentPlannedActionMasterResourceID = (<PlannedAction>this.appointmentFormViewModel.CurrentObject).MasterResource.ObjectID.toString();
            }
            else
                masterResourceInputDVO.currentObjectIsPlannedAction = false;
            if (this.appointmentFormViewModel._Appointment.MasterResource && this.appointmentFormViewModel._Appointment.MasterResource.ObjectID)
                masterResourceInputDVO.defaultMasterResourceObjectID = this.appointmentFormViewModel._Appointment.MasterResource.ObjectID.toString();
            this.appointmentFormViewModel.MasterResourceList = new Array<Resource>();
            this.appointmentFormViewModel.SubResourceList = new Array<Resource>();
            this.appointmentFormViewModel.AllResourcesAndColors = new Array<ResourceAndColorDVO>();
            let apiUrlMasRes: string = 'api/AppointmentService/FillMasterResourceCombo';
            let body = masterResourceInputDVO;

            let res = await this.httpService.post<MasterResourceDVO>(apiUrlMasRes, body, MasterResourceDVO);
            let result = res;
            let output = <MasterResourceDVO>result;
            this.appointmentFormViewModel.MasterResourceList = output.MasterResourceList;
            for (let item of this.appointmentFormViewModel.MasterResourceList) {
                let resourceAndColorDVO: ResourceAndColorDVO = new ResourceAndColorDVO();
                //resourceAndColorDVO.resourceColor = item.ResourceColor; //TODO:FIXME
                resourceAndColorDVO.resourceObjectID = item.ObjectID.toString();
                this.appointmentFormViewModel.AllResourcesAndColors.push(resourceAndColorDVO);
            }
            if (output.defaultMasterResource != null) {
                let targetMasterResource = this.appointmentFormViewModel.MasterResourceList.find(ms => ms.ObjectID.valueOf() === output.defaultMasterResource.ObjectID.valueOf());
                if (targetMasterResource)
                    this.appointmentFormViewModel._Appointment.MasterResource = targetMasterResource;
                else {
                    if (this.appointmentFormViewModel.MasterResourceList.length > 0)
                        this.appointmentFormViewModel._Appointment.MasterResource = <Resource>this.appointmentFormViewModel.MasterResourceList[0];
                }
            }
            else {
                if (this.appointmentFormViewModel.MasterResourceList.length > 0)
                    this.appointmentFormViewModel._Appointment.MasterResource = <Resource>this.appointmentFormViewModel.MasterResourceList[0];
            }
        }
        else
            this.appointmentFormViewModel._Appointment.MasterResource = null;
    }

    async appointmentTypeSelectedItemChanged(value: any) {
        if (typeof value == 'object') {
            if (value) {
                let appointmentType: AppointmentTypeListDVO = <AppointmentTypeListDVO>value;
                this.appointmentFormViewModel._Appointment.AppointmentType = appointmentType.AppointmentTypeEnumValue;
            }
            else
                this.appointmentFormViewModel._Appointment.AppointmentType = null;
        }
    }

    async getAppointmentTypeList(value: AppointmentCarrier) {
        if (value) {
            this.appointmentFormViewModel.AppointmentTypeList = new Array<AppointmentTypeListDVO>();
            let apiUrlAppType: string = 'api/AppointmentService/FillAppointmentTypeCombo?appointmentCarrierObjectID=' + value.ObjectID.toString();
            let res = await this.httpService.get<AppointmentTypeDVO>(apiUrlAppType, AppointmentTypeDVO);
            let result = res;
            let output = <AppointmentTypeDVO>result;
            this.appointmentFormViewModel.AppointmentTypeList = output.AppointmentTypeList;
            if (output.defaultAppType && output.defaultAppType.AppointmentType) {
                let targetAppointmentType = this.appointmentFormViewModel.AppointmentTypeList.find(ms => ms.AppointmentType.ObjectID.valueOf() === output.defaultAppType.AppointmentType.ObjectID.valueOf());
                this.appointmentFormViewModel._Appointment.AppointmentType = targetAppointmentType.AppointmentType.Type;
                this.appointmentFormViewModel.AppointmentType = targetAppointmentType;
            }
            else {
                this.appointmentFormViewModel._Appointment.AppointmentType = null;
                this.appointmentFormViewModel.AppointmentType = null;
            }
        }
        else {
            this.appointmentFormViewModel._Appointment.AppointmentType = null;
            this.appointmentFormViewModel.AppointmentType = null;
        }
    }

    async masterResourceSelectedItemChanged(value: any) {
        if (typeof value == 'object') {
            if (value) {
                this.appointmentFormViewModel.SelectedSubResourceList = new Array<string>();
                //if (!this.isStateAppointment)
                //    this.appointmentFormViewModel._Appointment.Resource = null;
                await this.getSubResourceList(this.appointmentFormViewModel._Appointment.AppointmentCarrier);

                //TODO Burada schedule ın güncellenmesi sağlanmalı.
                //if (_currentAppDefinition.GiveToMaster == true)
                //    FillAppointmentsListView();
                //else
                //    this.appointmentFormViewModel._Appointment.MasterResource = null;
            }
        }
    }

    async getSubResourceList(value: AppointmentCarrier) {
        if (value) {
            let subResourceInputDVO = new SubResourceInputDVO();
            subResourceInputDVO.appointmentCarrierObjectID = value.ObjectID.toString();
            subResourceInputDVO.appointmentDefObjectID = this.appointmentFormViewModel._Appointment.AppointmentDefinition.ObjectID.toString();
            subResourceInputDVO.relationParentName = value.RelationParentName;
            subResourceInputDVO.subResourceType = value.SubResource;
            if (this.appointmentFormViewModel._Appointment.MasterResource && this.appointmentFormViewModel._Appointment.MasterResource.ObjectID)
                subResourceInputDVO.defaultMasterResourceObjectID = this.appointmentFormViewModel._Appointment.MasterResource.ObjectID.toString();
            if (this.appointmentFormViewModel._Appointment.Resource && this.appointmentFormViewModel._Appointment.Resource.ObjectID)
                subResourceInputDVO.defaultSubResourceObjectID = this.appointmentFormViewModel._Appointment.Resource.ObjectID.toString();

            let apiUrlSubRes: string = 'api/AppointmentService/FillSubResourceCombo';
            let body = subResourceInputDVO;

            this.appointmentFormViewModel.SubResourceList = new Array<Resource>();

            let output = await this.httpService.post<SubResourceDVO>(apiUrlSubRes, body, SubResourceDVO);

            this.appointmentFormViewModel.SubResourceList = output.SubResourceList;
            for (let item of this.appointmentFormViewModel.SubResourceList) {
                let resourceAndColorDVO: ResourceAndColorDVO = new ResourceAndColorDVO();
                //resourceAndColorDVO.resourceColor = item.ResourceColor; //TODO:FIXME
                resourceAndColorDVO.resourceObjectID = item.ObjectID.toString();
                this.appointmentFormViewModel.AllResourcesAndColors.push(resourceAndColorDVO);
            }
            if (output.defaultSubResource != null) {
                let targetSubResource = this.appointmentFormViewModel.SubResourceList.find(sr => sr.ObjectID.valueOf() === output.defaultSubResource.ObjectID.valueOf());
                if (targetSubResource) {
                    this.appointmentFormViewModel._Appointment.Resource = targetSubResource;
                    if (this.appointmentFormViewModel.SelectedSubResourceList && this.appointmentFormViewModel.SelectedSubResourceList.includes(targetSubResource.ObjectID.toString()) == false)
                        this.appointmentFormViewModel.SelectedSubResourceList.push(targetSubResource.ObjectID.toString());
                }
                else {
                    if (this.appointmentFormViewModel.SubResourceList.length > 0) {
                        this.appointmentFormViewModel._Appointment.Resource = <Resource>this.appointmentFormViewModel.SubResourceList[0];
                        if (this.appointmentFormViewModel.SelectedSubResourceList && this.appointmentFormViewModel.SelectedSubResourceList.includes(this.appointmentFormViewModel.SubResourceList[0].ObjectID.toString()) == false)
                            this.appointmentFormViewModel.SelectedSubResourceList.push(this.appointmentFormViewModel.SubResourceList[0].ObjectID.toString());
                    }
                }
            }
            else {
                if (this.appointmentFormViewModel.SubResourceList.length > 0) {
                    this.appointmentFormViewModel._Appointment.Resource = <Resource>this.appointmentFormViewModel.SubResourceList[0];
                    if (this.appointmentFormViewModel.SelectedSubResourceList && this.appointmentFormViewModel.SelectedSubResourceList.includes(this.appointmentFormViewModel.SubResourceList[0].ObjectID.toString()) == false)
                        this.appointmentFormViewModel.SelectedSubResourceList.push(this.appointmentFormViewModel.SubResourceList[0].ObjectID.toString());
                }
            }
        }
        else
            this.appointmentFormViewModel._Appointment.Resource = null;
    }

    async subResourceSelectedItemChanged(value: any) {
        let that = this;
        if (typeof value == 'object') {
            if (value) {
                let subResource: Resource = <Resource>value;
                await this.FillAppointments();
            }
            else
                this.appointmentFormViewModel._Appointment.Resource = null;
        }
    }

    SearchTextChanged(text: string) {
        this.appointmentFormViewModel.txtPatient = text;
        this.appointmentFormViewModel.currentPatient = null;
        this.appointmentFormViewModel._Appointment.Patient = null;
        this.appointmentFormViewModel.TCKNo = null;
        this.appointmentFormViewModel.PhoneNumber = null;
        this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.Home;
    }

    async subResourceSelectedItemsChanged(value: any) {
        if (!this.isFirstLoad) {
            if (value) {
                let hasChanged: boolean = false;
                if (value.addedItems && value.addedItems.length > 0)
                    hasChanged = true;
                if (value.removedItems && value.removedItems.length > 0)
                    hasChanged = true;
                if (hasChanged)
                    await this.FillAppointments();
            }
        }
    }

    async FillAppointments() {
        if (this.appointmentFormViewModel.SelectedSubResourceList.length > 0) {
            this.dateRangeChanged = false;
            let appointmentInputDVO: AppointmentInputDVO = new AppointmentInputDVO();
            this.appointmentsData = new Array<GivenAppointment>();
            this.resourcesData = new Array<GivenResource>();
            this.masterResourcesData = new Array<GivenResource>();
            this.appOrSchTypesData = new Array<AppOrSchType>();
            let appDate: Date = Convert.ToDateTime(this.appointmentFormViewModel._Appointment.AppDate);
            appointmentInputDVO.AppDate = new Date(appDate.getFullYear(), appDate.getMonth(), appDate.getDate(), 0, 0, 0);
            if (this.appointmentFormViewModel._Appointment.Resource)
                appointmentInputDVO.ownerObjectID = this.appointmentFormViewModel._Appointment.Resource.ObjectID.toString();
            appointmentInputDVO.SelectedOwnerResources = this.appointmentFormViewModel.SelectedSubResourceList;
            appointmentInputDVO.masterOwnerObjectID = this.appointmentFormViewModel._Appointment.MasterResource.ObjectID.toString();
            appointmentInputDVO.AllResourcesAndColors = this.appointmentFormViewModel.AllResourcesAndColors;
            appointmentInputDVO.appointmentType = this.appointmentFormViewModel._Appointment.AppointmentType;
            appointmentInputDVO.showAppointmentsOfPatient = this.showAppointmentsOfPatient;
            if (this._detailSchedulerInstance.currentView)
                appointmentInputDVO.currentView = this._detailSchedulerInstance.currentView.toString();
            let givenAppointmentsAndSchedules: GivenAppointmentsAndSchedules = await this.GetAppointmentsAndSchedules(appointmentInputDVO);
            this.appointmentsData = givenAppointmentsAndSchedules.GivenAppointments;
            this.resourcesData = givenAppointmentsAndSchedules.SubResources;
            this.masterResourcesData = givenAppointmentsAndSchedules.MasterResources;
            this.appOrSchTypesData = givenAppointmentsAndSchedules.AppOrSchTypes;
            if (this.appointmentFormViewModel.SubResourceList.length > 0) {
                let resource: Resource = this.appointmentFormViewModel.SubResourceList.find(x => x.ObjectID.toString() == this.appointmentFormViewModel.SelectedSubResourceList[0])
                if (resource)
                    this.appointmentFormViewModel._Appointment.Resource = resource;
            }
        }
        else
            this.appointmentFormViewModel._Appointment.Resource = null;
        await this.repaintScheduler();
    }

    isTakvim: any = true;
    isRandevu: any = true;

    selectTab(e) {
        let selectedItem: string = e.addedItems[0].title;
        if (selectedItem == i18n("M17742", "Takvim")) {
            this.isTakvim = true;
        }
        if (selectedItem == i18n("M20924", "Randevu")) {
            this.isRandevu = true;
        }
    }

    async GetAppointmentsAndSchedules(appointmentInputDVO: AppointmentInputDVO): Promise<GivenAppointmentsAndSchedules> {
        let url: string = "/api/AppointmentService/GetAppointmentsAndSchedules";
        let body = appointmentInputDVO;
        let result = await this.httpService.post<GivenAppointmentsAndSchedules>(url, body, GivenAppointmentsAndSchedules);
        let output: GivenAppointmentsAndSchedules = result;
        return output;
    }

    public subResourceKeyPress(e: any) {
        //let charArray: Array<string> = new Array<string>();
        let _jQueryEvent = e.jQueryEvent.key;

        let tempData = _jQueryEvent.normalize('NFD').replace(/[\u0300-\u036f]/g, '');
        tempData = tempData.normalize('NFD').replace(/ı/g, 'i');
        e.element.text = tempData;

        //charArray = ['ç', 'Ç', 'ö', 'Ö', 'ş', 'Ş', 'ü', 'Ü', 'Ğ', 'ğ', 'ı', 'İ', '-'];

        //if ((_jQueryEvent < 'A' || _jQueryEvent > 'z') && charArray.findIndex(p => p == _jQueryEvent) < 0)
        //    e.jQueryEvent.preventDefault();
    }

    public async checkAppointmentToSave(): Promise<boolean> {
        let appDate: Date = (Convert.ToDateTime(this.appointmentFormViewModel._Appointment.AppDate));
        this.appointmentFormViewModel._Appointment.StartTime = new Date(appDate.getFullYear(), appDate.getMonth(), appDate.getDate(), this.appointmentFormViewModel._Appointment.StartTime.getHours(), this.appointmentFormViewModel._Appointment.StartTime.getMinutes(), 0);
        this.appointmentFormViewModel._Appointment.EndTime = new Date(appDate.getFullYear(), appDate.getMonth(), appDate.getDate(), this.appointmentFormViewModel._Appointment.EndTime.getHours(), this.appointmentFormViewModel._Appointment.EndTime.getMinutes(), 0);

        let app: Appointment = this.appointmentFormViewModel._Appointment;
        let appStartTime: Date = Convert.ToDateTime(app.StartTime);
        appStartTime = new Date(appStartTime.getFullYear(), appStartTime.getMonth(), appStartTime.getDate(), appStartTime.getHours(), appStartTime.getMinutes(), 0);
        let appEndTime: Date = Convert.ToDateTime(app.EndTime);
        appEndTime = new Date(appEndTime.getFullYear(), appEndTime.getMonth(), appEndTime.getDate(), appEndTime.getHours(), appEndTime.getMinutes(), 0);
        let sysDate: Date = new Date(Date.now());
        let currDate: Date = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), sysDate.getHours(), sysDate.getMinutes(), 0);

        if (appEndTime < currDate) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M20741", "Randevu tarihi bugünün tarihinden önce olamaz."), MessageIconEnum.WarningMessage);
            return false;
        }

        if (appEndTime < appStartTime) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M30307", "Randevunun Bitiş Saati, Başlangıç Saatinden büyük veya ona eşit olmalıdır."), MessageIconEnum.WarningMessage);
            return false;
        }

        if (app.AppointmentDefinition.IsDescReqForNonScheduledApps == true) {
            if (!this.appointmentFormViewModel.selectedAppointmentSchedule && String.isNullOrEmpty(app.Notes)) {
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M30308", "Plan dışı bir saate randevu veriyorsunuz. Lütfen açıklama giriniz."), MessageIconEnum.WarningMessage);
                return false;
            }
        }

        if (this.appointmentFormViewModel._Appointment.MasterResource == null) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), this.appointmentFormViewModel._Appointment.AppointmentCarrier.MasterResourceCaption.toString() + " " + i18n("M30309", "boş olamaz"), MessageIconEnum.WarningMessage);
            return false;
        }

        if (this.appointmentFormViewModel._Appointment.Resource == null) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), this.appointmentFormViewModel._Appointment.AppointmentCarrier.SubResourceCaption.toString() + " " + i18n("M30309", "boş olamaz"), MessageIconEnum.WarningMessage);
            return false;
        }

        if (this.appointmentFormViewModel._Appointment.Patient == null) {
            //Hasta kayıtlı değilse herzaman TC, Telefon ve Telefon tipi istenmeli bence.
            //let mhrsyeBildir: string = (await SystemParameterService.GetParameterValue('MHRSYEBILDIR', 'FALSE'));

            //let appResource = this.appointmentFormViewModel._Appointment.Resource;
            //if (mhrsyeBildir.toUpperCase() == "TRUE" && appResource && (<Resource>appResource) instanceof ResUser) {
            //    let appUniqueRefNoRequired: string = (await SystemParameterService.GetParameterValue('APPOINTMENTUNIQUEREFNOREQUIRED', 'FALSE'));
            //    if ((<ResUser>appResource).SentToMHRS == true || ((<ResUser>appResource).SentToMHRS != true && appUniqueRefNoRequired.toUpperCase() == "TRUE")) {
            if ((!this.appointmentFormViewModel.TCKNo) || (this.appointmentFormViewModel.TCKNo && String.isNullOrEmpty(this.appointmentFormViewModel.TCKNo.toString()) && this.appointmentFormViewModel.TCKNo.toString().length != 11)) {
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M22515", "T.C. kimlik numarasını girmediniz!"), MessageIconEnum.ErrorMessage);
                return false;
            }
            if ((!this.appointmentFormViewModel.PhoneNumber) || (this.appointmentFormViewModel.PhoneNumber && String.isNullOrEmpty(this.appointmentFormViewModel.PhoneNumber.toString()) && this.appointmentFormViewModel.PhoneNumber.toString().Length != 12)) {
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M23141", "Telefon numarasını girmediniz!"), MessageIconEnum.ErrorMessage);
                return false;
            }
            if (this.appointmentFormViewModel.osPhoneType == null) {
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M23143", "Telefon tipi seçmediniz!"), MessageIconEnum.ErrorMessage);
                return false;
            }
            //    }
            //}
        }
        return true;
    }

    public async saveClick() {
        let canBeSaved: boolean = await this.checkAppointmentToSave();
        if (canBeSaved) {
            await this.SaveAppointment(false);
            if (this.isStateAppointment)
                ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
            //let hasSaved: boolean = await this.SaveAppointment(false);
            //if (hasSaved) {
            //    if (!this.isStateAppointment) {
            //        this.SearchTextChanged("");
            //        this.FillAppointments();
            //        ServiceLocator.MessageService.showSuccess(i18n("M16825", "İşlem başarı ile tamamlandı."));
            //    }
            //}
            //await this.SaveAppointment(false).then(response => {
            //    let result = response; 
            //    if (result) {
            //        if (!this.isStateAppointment) {
            //            this.SearchTextChanged("");
            //            this.FillAppointments();
            //            ServiceLocator.MessageService.showSuccess(i18n("M16825", "İşlem başarı ile tamamlandı."));
            //        }
            //    }
            //});
        }
    }

    public cancelClick() {
        ServiceLocator.ModalStateService().callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    async SaveAppointment(isBreak: boolean): Promise<void> {
        try {
            let url: string = "/api/AppointmentService/SaveAppointment";
            let appointmentToSaveDVO: AppointmentToSaveDVO = new AppointmentToSaveDVO();
            appointmentToSaveDVO.appointmentToSave = this.appointmentFormViewModel._Appointment;
            appointmentToSaveDVO.CurrentObject = this.appointmentFormViewModel.CurrentObject;
            appointmentToSaveDVO.isBreak = isBreak;
            appointmentToSaveDVO.nextAvailableAppointmentOrder = 1;
            //TODO
            if (this.appointmentFormViewModel.selectedAppointmentSchedule)
                appointmentToSaveDVO.selectedCalendarItems.push(this.appointmentFormViewModel.selectedAppointmentSchedule);
            appointmentToSaveDVO.txtPatient = this.appointmentFormViewModel.txtPatient;
            appointmentToSaveDVO.TCKNo = this.appointmentFormViewModel.TCKNo;
            appointmentToSaveDVO.PhoneNumber = this.appointmentFormViewModel.PhoneNumber;
            appointmentToSaveDVO.osPhoneType = this.appointmentFormViewModel.osPhoneType;
            appointmentToSaveDVO._carrierList = this.appointmentFormViewModel.AppointmentCarrierList;
            appointmentToSaveDVO._myOldAppointment = this.appointmentFormViewModel._myOldAppointment;
            //TODO
            appointmentToSaveDVO._retAppointment = null;
            appointmentToSaveDVO.AppointmentDef = this.appointmentFormViewModel.AppointmentDef;
            let body = appointmentToSaveDVO;
            this.httpService.post(url, body).then(response => {
                let result = response;
                //TTVisual.InfoBox.Show("İşlem başarı ile tamamlandı.", MessageIconEnum.InformationMessage);
                ServiceLocator.MessageService.showSuccess(i18n("M16825", "İşlem başarı ile tamamlandı."));
                if (!this.isStateAppointment) {
                    this.SearchTextChanged("");
                    this.FillAppointments();
                    this.appointmentFormViewModel.selectedAppointmentSchedule = null;
                }

                //return true;
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
                //return false;
            });
        } catch (e) {
            ServiceLocator.MessageService.showError("Hata : " + e);
            //return false;
        }
    }

    onAppointmentUpdating(e: any) {
        let that = this;
        let sysDate: Date = new Date(Date.now());
        if (e.oldData && e.oldData.objectDefName == "APPOINTMENT") {
            if (e.newData.startDate < sysDate) {
                ServiceLocator.MessageService.showError(i18n("M20741", "Randevu tarihi bugünün tarihinden önce olamaz."));
                e.cancel = true;
                return false;
            }
            else {
                e.newData.ownerObject = that.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == e.newData.ownerObjectID.toString());
                that.updateGivenAppointments(e.newData);
            }
        }
        else {
            ServiceLocator.MessageService.showError(i18n("M20384", "Planlama türünde olan öğeler sürüklenemez."));
            e.cancel = true;
            return false;
        }
    }


    onAppointmentClick(e: any) {
        //let that = this;
        //clearTimeout(that.timeOut);
    }

    onAppointmentRendered(e) {
        let that = this;
        e.appointmentElement.style.backgroundColor = e.appointmentData.color;
        e.appointmentElement.ondragend = function () {
            if (e.appointmentData) {
                let givenApp: GivenAppointment = <GivenAppointment>e.appointmentData;
                if (givenApp.objectDefName == 'SCHEDULE') {
                    e.cancel = true;
                    return false;
                }
            }
        };
    }


    onCellClick(e: any) {
        this.appointmentFormViewModel._Appointment.AppDate = e.cellData.startDate;
        this.appointmentFormViewModel._Appointment.StartTime = e.cellData.startDate;
        this.appointmentFormViewModel._Appointment.EndTime = e.cellData.endDate;
        this.appointmentFormViewModel._Appointment.Resource = this.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == e.cellData.groups.ownerObjectID.toString());
        e.cancel = false;
    }



    onAppointmentDblClick(e: any) {
        e.cancel = true;
    }

    async onOptionChanged(e: any) {
        if (e.name == 'currentDate') {
            let previousDate: Date = new Date(e.previousValue);
            let currDate: Date = new Date(e.value);
            if (this.appointmentFormViewModel._Appointment.AppDate.valueOf() != currDate.valueOf()) {
                this.appointmentFormViewModel._Appointment.AppDate = currDate;
                await this.FillAppointments();
                ////let color: string = window['randomColor']({
                ////    luminosity: 'light'
                ////});
            }
        }
        else if (e.name == 'currentView') {
            this.currentView = this._detailSchedulerInstance.currentView;
            await this.repaintScheduler();
            await this.FillAppointments();
        }
    }

    async onRadioOptionChanged(e: any) {
        return e;
    }

    async onRadioValueChanged(e: any) {
        if (e) {
            if (e.value != this._detailSchedulerInstance.currentView)
                this._detailSchedulerInstance.currentView = e.value;
        }
    }

    async onAppointmentUpdated(e: any) {
    }

    onAppointmentFormOpening(data) {
        //var form = data.form;
        data.cancel = true;
        //this._detailSchedulerInstance.instance.hideAppointmentPopup(false);
        //this.openGivenAppointment();
    }

    keyDownForNumericControl(event: any) {
        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }

    giveAppointments(givenAppointment: any) {
        if (givenAppointment) {
            let givenApp: GivenAppointment = <GivenAppointment>givenAppointment;
            if (givenApp.objectDefName == 'SCHEDULE') {
                this.appointmentFormViewModel.selectedAppointmentSchedule = givenApp;
                this.appointmentFormViewModel._myOldAppointment = null;
                if (this.appointmentFormViewModel.currentPatient) {
                    this.appointmentFormViewModel._Appointment.Patient = this.appointmentFormViewModel.currentPatient;
                    if (!this.appointmentFormViewModel.txtPatient)
                        this.appointmentFormViewModel.txtPatient = this.appointmentFormViewModel.currentPatient.PatientIDandFullName;
                    this.appointmentFormViewModel.TCKNo = this.appointmentFormViewModel.currentPatient.UniqueRefNo;
                    this.appointmentFormViewModel.PhoneNumber = this.appointmentFormViewModel.currentPatient.MobilePhone;
                    this.appointmentFormViewModel.osPhoneType = this.appointmentFormViewModel.osPhoneType;
                }
                else {
                    this.appointmentFormViewModel._Appointment.Patient = null;
                    this.appointmentFormViewModel.txtPatient = null;
                    this.appointmentFormViewModel.TCKNo = null;
                    this.appointmentFormViewModel.PhoneNumber = null;
                    this.appointmentFormViewModel.osPhoneType = this.appointmentFormViewModel.osPhoneType;
                }
                this.appointmentFormViewModel._Appointment.AppDate = givenApp.startDate;
                this.appointmentFormViewModel._Appointment.StartTime = givenApp.startDate;
                this.appointmentFormViewModel._Appointment.EndTime = givenApp.endDate;
                this.appointmentFormViewModel._Appointment.Notes = givenApp.notes;
                this.appointmentFormViewModel._Appointment.Resource = this.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == givenApp.ownerObject.ObjectID.toString());
                this.openGivenAppointment();
            }
        }
        else {
            ServiceLocator.MessageService.showError(i18n("M20385", "Planlama türünde olmayan öğelere randevu verilemez."));
            return false;
        }
    }

    async cancelAppointments(givenAppointment: any) {
        if (givenAppointment) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20724", "Randevu İptali"), await SystemMessageService.GetMessage(292));
            if (result === "H")
                return;
            let givenApp: GivenAppointment = <GivenAppointment>givenAppointment;
            if (givenApp.objectDefName == 'APPOINTMENT') {
                let checkAppForCancelAppUrl: string = 'api/AppointmentService/CheckAppointmentForCancel';
                let appointmentForCancelDVO: AppointmentForUpdateDeleteApproveDVO = new AppointmentForUpdateDeleteApproveDVO();
                appointmentForCancelDVO.appointmentObjectID = givenApp.objectID;
                let body = appointmentForCancelDVO;
                this.httpService.post(checkAppForCancelAppUrl, body).then(response => {
                    this.appointmentFormViewModel.selectedAppointmentSchedule = null;
                    this.appointmentFormViewModel._myOldAppointment = null;
                    this.appointmentFormViewModel._Appointment.Patient = null;
                    this.appointmentFormViewModel.txtPatient = null;
                    this.appointmentFormViewModel.TCKNo = null;
                    this.appointmentFormViewModel.PhoneNumber = null;
                    this.appointmentFormViewModel._Appointment.Notes = null;
                    this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.Home;
                    this.FillAppointments();
                    ServiceLocator.MessageService.showSuccess(i18n("M20725", "Randevu iptali başarı ile tamamlandı."));
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
        }
        else {
            ServiceLocator.MessageService.showError(i18n("M20748", "Randevu türünde olmayan öğeler iptal edilemez."));
        }
    }

    async approveAppointments(givenAppointment: any) {
        if (givenAppointment) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20729", "Randevu Onayı"), await SystemMessageService.GetMessage(296));
            if (result === "H")
                return;
            let givenApp: GivenAppointment = <GivenAppointment>givenAppointment;
            if (givenApp.objectDefName == 'APPOINTMENT') {
                let checkAppForUpdateAppUrl: string = 'api/AppointmentService/CheckAppointmentForApprove';
                let appointmentForApproveDVO: AppointmentForUpdateDeleteApproveDVO = new AppointmentForUpdateDeleteApproveDVO();
                appointmentForApproveDVO.appointmentObjectID = givenApp.objectID;
                let body = appointmentForApproveDVO;
                this.httpService.post(checkAppForUpdateAppUrl, body).then(response => {
                    this.appointmentFormViewModel.selectedAppointmentSchedule = null;
                    this.appointmentFormViewModel._myOldAppointment = null;
                    this.appointmentFormViewModel._Appointment.Patient = null;
                    this.appointmentFormViewModel.txtPatient = null;
                    this.appointmentFormViewModel.TCKNo = null;
                    this.appointmentFormViewModel.PhoneNumber = null;
                    this.appointmentFormViewModel._Appointment.Notes = null;
                    this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.Home;
                    this.FillAppointments();
                    ServiceLocator.MessageService.showSuccess(i18n("M20730", "Randevu onaylama başarı ile tamamlandı."));
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
        }
        else {
            ServiceLocator.MessageService.showError(i18n("M20748", "Randevu türünde olmayan öğeler iptal edilemez."));
        }
    }

    updateGivenAppointments(givenAppointment: any) {
        if (givenAppointment) {
            let givenApp: GivenAppointment = <GivenAppointment>givenAppointment;
            if (givenApp.objectDefName == 'APPOINTMENT') {
                let checkAppForUpdateAppUrl: string = 'api/AppointmentService/CheckAppointmentForUpdate';
                let appointmentForUpdateDVO: AppointmentForUpdateDeleteApproveDVO = new AppointmentForUpdateDeleteApproveDVO();
                appointmentForUpdateDVO.appointmentObjectID = givenApp.objectID;
                let body = appointmentForUpdateDVO;
                this.httpService.post<AppointmentToUpdateDVO>(checkAppForUpdateAppUrl, body, AppointmentToUpdateDVO).then(response => {
                    let result = response;
                    let output = <AppointmentToUpdateDVO>result;
                    this.appointmentFormViewModel.appointmentToUpdateDVO = output;
                    this.appointmentFormViewModel.selectedAppointmentSchedule = null;
                    this.appointmentFormViewModel._myOldAppointment = givenApp;
                    this.appointmentFormViewModel._Appointment.Patient = <Patient>givenApp.patient;
                    this.appointmentFormViewModel.txtPatient = givenApp.txtPatient;
                    this.appointmentFormViewModel.TCKNo = givenApp.TCKNo;
                    this.appointmentFormViewModel.PhoneNumber = givenApp.PhoneNumber;
                    this.appointmentFormViewModel.osPhoneType = givenApp.osPhoneType;
                    this.appointmentFormViewModel._Appointment.AppDate = givenApp.startDate;
                    this.appointmentFormViewModel._Appointment.StartTime = givenApp.startDate;
                    this.appointmentFormViewModel._Appointment.EndTime = givenApp.endDate;
                    this.appointmentFormViewModel._Appointment.Notes = givenApp.notes;
                    this.appointmentFormViewModel._Appointment.Resource = this.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == givenApp.ownerObject.ObjectID.toString());
                    this.openGivenAppointment();
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
        }
        else {
            ServiceLocator.MessageService.showError(i18n("M20747", "Randevu türünde olmayan öğeler güncellenemez."));
        }
    }

    private openGivenAppointment(): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "GiveOrUpdateAppointmentForm";
            componentInfo.ModuleName = "RandevuModule";
            componentInfo.ModulePath = "Modules/Tibbi_Surec/Randevu_Modulu/RandevuModule";

            let appFormViewModel: AppointmentFormViewModel = new AppointmentFormViewModel();
            appFormViewModel = that.appointmentFormViewModel;
            componentInfo.InputParam = new DynamicComponentInputParam(appFormViewModel, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20752", "Randevu Verme - Güncelleme - İptal");
            modalInfo.Width = 600;
            modalInfo.Height = 600;
            modalInfo.IsShowCloseButton = false;
            //modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                if (inner.Result && inner.Result == 1) {
                    if (that.isStateAppointment)
                        //that.cancelClick();
                        ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
                    else {
                        that.FillAppointments();
                        that.appointmentFormViewModel._Appointment.Patient = null;
                        that.appointmentFormViewModel._Appointment.Notes = null;
                        that.appointmentFormViewModel.txtPatient = null;
                        that.appointmentFormViewModel.TCKNo = null;
                        that.appointmentFormViewModel.PhoneNumber = null;
                        that.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.GSM;
                        that.appointmentFormViewModel.selectedAppointmentSchedule = null;
                        that.appointmentFormViewModel._myOldAppointment = null;
                    }
                }
                else {
                    that.appointmentFormViewModel.selectedAppointmentSchedule = null;
                    that.appointmentFormViewModel._myOldAppointment = null;
                }
                //}
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async onAppDateChanged(event) {
        if (event) {
            if (event.previousValue) {
                let currDate: Date = new Date(event.value);
                let previousDate: Date = new Date(event.previousValue);

                if (currDate != previousDate) {
                    this.currentDate = currDate;
                    this.appointmentFormViewModel._Appointment.StartTime = new Date(currDate.getFullYear(), currDate.getMonth(), currDate.getDate(), this.appointmentFormViewModel._Appointment.StartTime.getHours(), this.appointmentFormViewModel._Appointment.StartTime.getMinutes(), 0);
                }
            }
        }
    }

    public async onAppStartTimeChanged(event) {
        if (event) {
            if (event.previousValue) {
                let currTime: Date = new Date(event.value);
                let previousTime: Date = new Date(event.previousValue);

                if (currTime != previousTime) {
                    //this.appointmentFormViewModel._Appointment.AppDate = currTime;
                    if (this.appointmentFormViewModel.selectedAppointmentSchedule)
                        this.appointmentFormViewModel._Appointment.EndTime = this.appointmentFormViewModel.selectedAppointmentSchedule.endDate;
                    else if (this.appointmentFormViewModel._myOldAppointment)
                        this.appointmentFormViewModel._Appointment.EndTime = this.appointmentFormViewModel._myOldAppointment.endDate;
                    else
                        this.appointmentFormViewModel._Appointment.EndTime = currTime.AddMinutes(15); //15dk ekleme
                }
            }
        }
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {

        this.MobilePhone = new TTVisual.TTMaskedTextBox();
        this.MobilePhone.Name = "MobilePhone";
        this.MobilePhone.TabIndex = 28;
        this.MobilePhone.Mask = "(999)9999999"; //.replace(/\s/g, "");
        this.MobilePhone.Visible = true;

        //this.AppointmentsListView = <TTVisual.TTListView>{
        //    Visible: true,
        //    ReadOnly: false,
        //    BackColor: "black",
        //    ForeColor: "yellow",
        //    Font: {
        //        Bold: false,
        //        Italic: false,
        //        Name: "Impact",
        //        Size: 11,
        //        Strikeout: false,
        //        Underline: false
        //    },
        //    Columns: [
        //        { Text: "Saati" },
        //        { Text: "Info" },
        //        { Text: "Cinsi" },
        //        // { Text: "Tarih", DataType: 'date', Format: 'dd/MM/yyyy' },
        //        { Text: "T�r�" },
        //        { Text: "Hasta Ad� Soyad�" },
        //        { Text: "Ana Kaynak" },
        //        { Text: "Not" }
        //    ]
        //};
        //this.AppointmentsListView.Name = "AppointmentsListView";
        //this.AppointmentsListView.TabIndex = 0;
        //this.AppointmentsListView.Height = 310;
        //this.AppointmentsListView.MultiSelect = false;

        this.Controls = [this.MobilePhone];

    }


}

