//$98DD09E8
import { Component, OnInit } from '@angular/core';
import { AppointmentFormViewModel, AppointmentCarrierDVO, AppointmentTypeDVO, AppointmentTypeListDVO, MasterResourceDVO, MasterResourceInputDVO, SubResourceDVO, SubResourceInputDVO, AppointmentForUpdateDeleteApproveDVO, GivenAppointment, AppointmentStateItem } from './AppointmentFormViewModel';
import { AppointmentInputDVO, GivenAppointmentsAndSchedules, GivenResource, ResourceAndColorDVO, AppOrSchType, AppointmentToUpdateDVO, AppointmentListItem, AppointmentListInputDVO } from './AppointmentFormViewModel';
import { Patient, PhoneTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
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
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { PlannedAction } from 'NebulaClient/Model/AtlasClientModel';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { GuidParam } from '../../../wwwroot/app/NebulaClient/Mscorlib/GuidParam';
import { ArrayParam } from '../../../wwwroot/app/NebulaClient/Mscorlib/ArrayParam';
import { StringParam, BooleanParam } from '../../../wwwroot/app/NebulaClient/Mscorlib/QueryParam';


@Component({
    selector: 'AppointmentListForm',
    templateUrl: './AppointmentListForm.html',
    inputs: ['Model'],
    providers: [SystemApiService],
})
export class AppointmentListForm extends TTVisual.TTForm implements OnInit {

    public showAppointmentsOfPatient: boolean = false;
    patientSearchFormVisible: boolean = true;

    appointmentsData: GivenAppointment[] = new Array<GivenAppointment>();
    resourcesData: GivenResource[] = new Array<GivenResource>();
    masterResourcesData: GivenResource[] = new Array<GivenResource>();
    appOrSchTypesData: AppOrSchType[] = new Array<AppOrSchType>();
    currentDate: Date = new Date(Date.now());
    recTime: Date = new Date(Date.now());

    dateRangeChanged: boolean = true;
    timeOut: any;

    appListStartDate: Date;
    appListEndDate: Date;
    appointmentListItems: Array<GivenAppointment> = new Array<GivenAppointment>();
    filterAppListByAppDef: boolean = true;
    criteria: string;

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

    public appointmentFormViewModel: AppointmentFormViewModel = new AppointmentFormViewModel();
    public get _Appointment(): Appointment {
        return this._TTObject as Appointment;
    }
    private AppointmentListForm_DocumentUrl: string = '/api/AppointmentService/AppointmentListForm';
    public AppointmentListColumns = [
        {
            caption: i18n("M22846", "Tarihi"),
            dataField: "strAppDate",
            width: "auto",
            fixed: true,
            allowSorting: true
        },
        {
            caption: i18n("M21089", "Saati"),
            dataField: "strAppTime",
            width: "auto",
            fixed: true,
            allowSorting: true
        },
        {
            caption: i18n("M23679", "Türü"),
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

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private modalService: IModalService, private reportService: AtlasReportService) {
        super('APPOINTMENT', 'AppointmentListForm');
        this._DocumentServiceUrl = this.AppointmentListForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public setInputParam(value: AppointmentFormViewModel) {
        if (value != null) {
            this.appointmentFormViewModel = new AppointmentFormViewModel();
            this.appointmentFormViewModel.CurrentObject = value.CurrentObject;
            this.appointmentFormViewModel.CurrentObjectTransDefID = value.CurrentObjectTransDefID;
            this._ViewModel = this.appointmentFormViewModel;
            if (value.currentPatient)
                this.txtPatientIsDisabled = true;
            else
                this.txtPatientIsDisabled = false;
        }
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    isFirstLoad: boolean;
    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Appointment();
        this.appointmentFormViewModel = new AppointmentFormViewModel();
        this._ViewModel = this.appointmentFormViewModel;
        this.appointmentFormViewModel._Appointment = this._TTObject as Appointment;
        this.appointmentFormViewModel._Appointment.AppointmentDefinition = new AppointmentDefinition();
        this.appointmentFormViewModel.AppointmentDefinitionToList = new AppointmentDefinition();
        this.appointmentFormViewModel._Appointment.AppointmentCarrier = new AppointmentCarrier();
        this.appointmentFormViewModel.AppointmentCarrierToList = new AppointmentCarrier();
        this.appointmentFormViewModel._Appointment.MasterResource = new Resource();
        this.appointmentFormViewModel.MasterResourceToList = new Resource();
        this.appointmentFormViewModel._Appointment.Resource = new Resource();
        this.appointmentFormViewModel.ResourceToList = new Resource();
        this.appointmentFormViewModel.appointmentToUpdateDVO = new AppointmentToUpdateDVO();
        this.appointmentFormViewModel.CurrentObject = null;
        this.appointmentFormViewModel.currentPatient = null;
        this.appointmentFormViewModel.ReadOnly = true;
        this.appointmentFormViewModel.isAppointmentListForm = true;
        this.appointmentFormViewModel.AppointmentStateItems = new Array<AppointmentStateItem>();
        this.appointmentFormViewModel.SelectedAppointmentStateItems = new Array<AppointmentStateItem>();
        this.txtPatientIsDisabled = true;
    }

    protected loadViewModel() {
        let that = this;
        that.isFirstLoad = true;
        that.appointmentFormViewModel = that._ViewModel as AppointmentFormViewModel;
        that._TTObject = plainToClass<Appointment, {}>(Appointment, that.appointmentFormViewModel._Appointment);
        if (that.appointmentFormViewModel == null)
            that.appointmentFormViewModel = new AppointmentFormViewModel();
        if (that.appointmentFormViewModel._Appointment == null)
            that.appointmentFormViewModel._Appointment = new Appointment();

        if (that.appointmentFormViewModel.currentPatient) {
            that.appointmentFormViewModel._Appointment.Patient = that.appointmentFormViewModel.currentPatient;
            that.appointmentFormViewModel.PatientToList = that.appointmentFormViewModel.currentPatient;
            if (!that.appointmentFormViewModel.txtPatient) {
                that.appointmentFormViewModel.txtPatient = that.appointmentFormViewModel.currentPatient.PatientIDandFullName;
                that.appointmentFormViewModel.txtPatientToList = that.appointmentFormViewModel.currentPatient.PatientIDandFullName;
            }
            that.patientSearchFormVisible = false;
        }

        let appointmentDefinitionObjectID = that.appointmentFormViewModel._Appointment["AppointmentDefinition"];
        if (appointmentDefinitionObjectID && that.appointmentFormViewModel.AppointmentDefinitionList) {
            let appointmentDefinition = that.appointmentFormViewModel.AppointmentDefinitionList.find(o => o.ObjectID.toString() === appointmentDefinitionObjectID.toString());
            if (appointmentDefinition) {
                that.appointmentFormViewModel._Appointment.AppointmentDefinition = appointmentDefinition;
                that.appointmentFormViewModel.AppointmentDefinitionToList = appointmentDefinition;
            }
        }

        let appointmentCarrierObjectID = that.appointmentFormViewModel._Appointment["AppointmentCarrier"];
        if (appointmentCarrierObjectID && that.appointmentFormViewModel.AppointmentCarrierList) {
            let appointmentCarrier = that.appointmentFormViewModel.AppointmentCarrierList.find(o => o.ObjectID.toString() === appointmentCarrierObjectID.toString());
            if (appointmentCarrier) {
                that.appointmentFormViewModel._Appointment.AppointmentCarrier = appointmentCarrier;
                that.appointmentFormViewModel.AppointmentCarrierToList = appointmentCarrier;

            }
        }
        if (that.appointmentFormViewModel.AppointmentType) {
            let appointmentTypeObjectID = that.appointmentFormViewModel.AppointmentType.AppointmentType["ObjectID"];
            if (appointmentTypeObjectID && that.appointmentFormViewModel.AppointmentTypeList) {
                let appointmentType = that.appointmentFormViewModel.AppointmentTypeList.find(o => o.AppointmentType.ObjectID.toString() === appointmentTypeObjectID.toString());
                that.appointmentFormViewModel.AppointmentType = appointmentType;
                that.appointmentFormViewModel.AppointmentTypeToList = appointmentType;
            }
        }

        let masterResourceObjectID = that.appointmentFormViewModel._Appointment["MasterResource"];
        if (masterResourceObjectID && that.appointmentFormViewModel.MasterResourceList) {
            let masterResource = that.appointmentFormViewModel.MasterResourceList.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.appointmentFormViewModel._Appointment.MasterResource = masterResource;
                that.appointmentFormViewModel.MasterResourceToList = masterResource;

            }
        }

        let resourceObjectID = that.appointmentFormViewModel._Appointment["Resource"];
        if (resourceObjectID && that.appointmentFormViewModel.SubResourceList) {
            let resource = that.appointmentFormViewModel.SubResourceList.find(o => o.ObjectID.toString() === resourceObjectID.toString());
            if (resource) {
                that.appointmentFormViewModel._Appointment.Resource = resource;
                that.appointmentFormViewModel.ResourceToList = resource;

            }
        }
        let startTime: Date = (Convert.ToDateTime(that.appointmentFormViewModel.appListStartDate));
        let endTime: Date = (Convert.ToDateTime(that.appointmentFormViewModel.appListEndDate));

        that.appointmentFormViewModel.appListStartDate = new Date(startTime.getFullYear(), startTime.getMonth(), startTime.getDate(), 0, 0, 0);
        that.appointmentFormViewModel.appListEndDate = new Date(endTime.getFullYear(), endTime.getMonth(), endTime.getDate(), 23, 59, 59);

    }

    async ngOnInit() {
        this.appointmentFormViewModel.allowAdding = true;
        this.appointmentFormViewModel.allowDeleting = true;
        this.appointmentFormViewModel.allowDragging = true;
        this.appointmentFormViewModel.allowUpdating = true;
        if (this.appointmentFormViewModel.CurrentObject && this.appointmentFormViewModel.CurrentObjectTransDefID)
            await this.loadForState();
        else
            await this.load();
    }

    loadForState(): Promise<void> {
        let that = this;
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




    async ngAfterViewInit() {

    }

    async clientPreScript() {
        this.appointmentFormViewModel.selectedAppointmentListItem = null;
    }

    clientPostScript(state: String) {

    }

    patientChanged(patient: any) {
        if (patient) {
            this.appointmentFormViewModel.txtPatient = patient.PatientIDandFullName;
            this.appointmentFormViewModel.txtPatientToList = patient.PatientIDandFullName;
            this.appointmentFormViewModel.currentPatient = <Patient>patient;
            this.appointmentFormViewModel._Appointment.Patient = <Patient>patient;
            this.appointmentFormViewModel.PatientToList = <Patient>patient;
        }
        else {
            this.appointmentFormViewModel.currentPatient = null;
            this.appointmentFormViewModel._Appointment.Patient = null;
            this.appointmentFormViewModel.txtPatient = "";
            this.appointmentFormViewModel.txtPatientToList = "";
            this.appointmentFormViewModel.PatientToList = null;
        }
    }

    async appointmentDefinitionToListSelectedItemChanged() {
        this.appointmentFormViewModel.labelSubResourceVisible = true;
        this.appointmentFormViewModel.subResourceVisible = true;
        if (this.appointmentFormViewModel.AppointmentDefinitionToList) {
            this.appointmentFormViewModel._Appointment.AppointmentDefinition = this.appointmentFormViewModel.AppointmentDefinitionToList;
            let appDef: AppointmentDefinition = <AppointmentDefinition>this.appointmentFormViewModel.AppointmentDefinitionToList;
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
        else {
            this.appointmentFormViewModel.AppointmentDefinitionToList = null;
            this.appointmentFormViewModel._Appointment.AppointmentDefinition = null;
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
                this.appointmentFormViewModel.AppointmentCarrierToList = targetCarrier;
                this.appointmentFormViewModel._Appointment.AppointmentCarrier = targetCarrier;
            }
            else {
                if (this.appointmentFormViewModel.AppointmentCarrierList.length > 0) {
                    this.appointmentFormViewModel.AppointmentCarrierToList = <AppointmentCarrier>this.appointmentFormViewModel.AppointmentCarrierList[0];
                    this.appointmentFormViewModel._Appointment.AppointmentCarrier = <AppointmentCarrier>this.appointmentFormViewModel.AppointmentCarrierList[0];
                }
            }
        }
        else {
            this.appointmentFormViewModel.AppointmentCarrierToList = null;
            this.appointmentFormViewModel._Appointment.AppointmentCarrier = null;
        }
    }

    async appointmentCarrierToListSelectedItemChanged(value: any) {
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
                this.appointmentFormViewModel.AppointmentCarrierToList = null;
        }
    }

    async getMasterResourceList(value: AppointmentCarrier) {
        if (value) {
            let masterResourceInputDVO = new MasterResourceInputDVO();
            masterResourceInputDVO.appointmentCarrierObjectID = value.ObjectID.toString();
            masterResourceInputDVO.appointmentDefObjectID = this.appointmentFormViewModel.AppointmentDefinitionToList.ObjectID.toString();
            masterResourceInputDVO.masterResourceFilter = value.MasterResourceFilter;
            masterResourceInputDVO.masterResourceType = value.MasterResource;
            if (this.appointmentFormViewModel.CurrentObject instanceof PlannedAction) {
                masterResourceInputDVO.currentObjectIsPlannedAction = true;
                masterResourceInputDVO.currentPlannedActionMasterResourceID = (<PlannedAction>this.appointmentFormViewModel.CurrentObject).MasterResource.ObjectID.toString();
            }
            else
                masterResourceInputDVO.currentObjectIsPlannedAction = false;
            masterResourceInputDVO.isAppointmentListForm = this.appointmentFormViewModel.isAppointmentListForm;

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
            //if (output.defaultMasterResource != null) {
            //    let targetMasterResource = this.appointmentFormViewModel.MasterResourceList.find(ms => ms.ObjectID.valueOf() === output.defaultMasterResource.ObjectID.valueOf());
            //    this.appointmentFormViewModel.MasterResourceToList = targetMasterResource;
            //}
            //else {
            //    if (this.appointmentFormViewModel.MasterResourceList.length > 0)
            //        this.appointmentFormViewModel.MasterResourceToList = <Resource>this.appointmentFormViewModel.MasterResourceList[0];
            //}
        }
        else
            this.appointmentFormViewModel.MasterResourceToList = null;
    }

    async appointmentTypeToListSelectedItemChanged(value: any) {
        if (typeof value == 'object') {
            if (value) {
                let appointmentType: AppointmentTypeListDVO = <AppointmentTypeListDVO>value;
                this.appointmentFormViewModel.AppointmentTypeToList = appointmentType;
            }
            else
                this.appointmentFormViewModel.AppointmentTypeToList = null;
        }
    }

    async getAppointmentTypeList(value: AppointmentCarrier) {
        if (value) {
            this.appointmentFormViewModel.AppointmentTypeList = new Array<AppointmentTypeListDVO>();
            let apiUrlAppType: string = 'api/AppointmentService/FillAppointmentTypeCombo?appointmentCarrierObjectID=' + value.ObjectID.toString() + '&isAppointmentListForm=' + this.appointmentFormViewModel.isAppointmentListForm;
            let res = await this.httpService.get<AppointmentTypeDVO>(apiUrlAppType, AppointmentTypeDVO);
            let result = res;
            let output = <AppointmentTypeDVO>result;
            this.appointmentFormViewModel.AppointmentTypeList = output.AppointmentTypeList;
            if (output.defaultAppType && output.defaultAppType.AppointmentType) {
                let targetAppointmentType = this.appointmentFormViewModel.AppointmentTypeList.find(ms => ms.AppointmentType.ObjectID.valueOf() === output.defaultAppType.AppointmentType.ObjectID.valueOf());
                this.appointmentFormViewModel.AppointmentTypeToList = targetAppointmentType;
            }
            else {
                this.appointmentFormViewModel.AppointmentTypeToList = null;
            }
        }
        else {
            this.appointmentFormViewModel.AppointmentTypeToList = null;
        }
    }

    async masterResourceToListSelectedItemChanged(value: any) {
        this.appointmentFormViewModel.SubResourceList = new Array<Resource>();
        this.appointmentFormViewModel.SelectedSubResourceList = new Array<string>();
        this.appointmentFormViewModel._Appointment.Resource = null;
        this.appointmentFormViewModel.ResourceToList = null;
        if (typeof value == 'object') {
            if (value) {
                //this.appointmentFormViewModel.SelectedSubResourceList = new Array<string>();
                await this.getSubResourceListToFilter(this.appointmentFormViewModel.AppointmentCarrierToList);
                //TODO Burada schedule ın güncellenmesi sağlanmalı.
                //if (_currentAppDefinition.GiveToMaster == true)
                //    FillAppointmentsListView();
                //else
                //    this.appointmentFormViewModel.MasterResourceToList = null;
            }
        }
    }

    async getSubResourceList(value: AppointmentCarrier) {
        if (value) {
            let subResourceInputDVO = new SubResourceInputDVO();
            subResourceInputDVO.appointmentCarrierObjectID = value.ObjectID.toString();
            subResourceInputDVO.appointmentDefObjectID = this.appointmentFormViewModel.AppointmentDefinitionToList.ObjectID.toString();
            subResourceInputDVO.relationParentName = value.RelationParentName;
            subResourceInputDVO.subResourceType = value.SubResource;
            subResourceInputDVO.defaultMasterResourceObjectID = this.appointmentFormViewModel._Appointment.MasterResource.ObjectID.toString();
            subResourceInputDVO.isAppointmentListForm = this.appointmentFormViewModel.isAppointmentListForm;
            if (this.appointmentFormViewModel._Appointment.Resource)
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
        }
        else
            this.appointmentFormViewModel._Appointment.Resource = null;
    }

    async getSubResourceListToFilter(value: AppointmentCarrier) {
        if (value) {
            let subResourceInputDVO = new SubResourceInputDVO();
            subResourceInputDVO.appointmentCarrierObjectID = value.ObjectID.toString();
            subResourceInputDVO.appointmentDefObjectID = this.appointmentFormViewModel.AppointmentDefinitionToList.ObjectID.toString();
            subResourceInputDVO.relationParentName = value.RelationParentName;
            subResourceInputDVO.subResourceType = value.SubResource;
            subResourceInputDVO.defaultMasterResourceObjectID = this.appointmentFormViewModel.MasterResourceToList.ObjectID.toString();
            subResourceInputDVO.isAppointmentListForm = this.appointmentFormViewModel.isAppointmentListForm;
            
                subResourceInputDVO.defaultSubResourceObjectID = "";

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
        }
    }

    async subResourceSelectedItemChanged(value: any) {
        let that = this;
        if (typeof value == 'object') {
            if (value) {
                let subResource: Resource = <Resource>value;
                //await this.FillAppointments();
            }
            else
                this.appointmentFormViewModel.ResourceToList = null;
        }
    }

    SearchTextChanged(text: string) {
        this.appointmentFormViewModel.txtPatient = text;
        this.appointmentFormViewModel.txtPatientToList = text;
        this.appointmentFormViewModel.currentPatient = null;
        this.appointmentFormViewModel._Appointment.Patient = null;
        this.appointmentFormViewModel.PatientToList = null;
    }

    async subResourceSelectedItemsChanged(value: any) {
        if (!this.isFirstLoad) {
            if (value) {
                let hasChanged: boolean = false;
                if (value.addedItems && value.addedItems.length > 0)
                    hasChanged = true;
                if (value.removedItems && value.removedItems.length > 0)
                    hasChanged = true;
                //if (hasChanged)
                //    await this.FillAppointments();
            }
        }
    }

    async FillAppointments() {
        let appStartTime: Date = (Convert.ToDateTime(this.appointmentFormViewModel.appListStartDate));
        appStartTime = new Date(appStartTime.getFullYear(), appStartTime.getMonth(), appStartTime.getDate(), appStartTime.getHours(), appStartTime.getMinutes(), 0);
        let appEndTime: Date = (Convert.ToDateTime(this.appointmentFormViewModel.appListEndDate));
        appEndTime = new Date(appEndTime.getFullYear(), appEndTime.getMonth(), appEndTime.getDate(), appEndTime.getHours(), appEndTime.getMinutes(), 0);
        if (appEndTime < appStartTime) {
            //TTVisual.InfoBox.Alert("Bitiş tarihi, başlangıç tarihinden önce olamaz.", MessageIconEnum.ErrorMessage);
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), (await SystemMessageService.GetMessage(288)), MessageIconEnum.WarningMessage);
            return;
        }
        let appointmentListInputDVO: AppointmentListInputDVO = new AppointmentListInputDVO();
        appointmentListInputDVO.appListAppointmentCarrier = this.appointmentFormViewModel.AppointmentCarrierToList;
        appointmentListInputDVO.appListAppointmentDefinition = this.appointmentFormViewModel.AppointmentDefinitionToList;
        appointmentListInputDVO.appListAppointmentType = this.appointmentFormViewModel.AppointmentTypeToList;
        appointmentListInputDVO.appListEndDate = this.appointmentFormViewModel.appListEndDate;
        appointmentListInputDVO.appListStartDate = this.appointmentFormViewModel.appListStartDate;
        appointmentListInputDVO.appListMasterResource = this.appointmentFormViewModel.MasterResourceToList;
        appointmentListInputDVO.appListResource = this.appointmentFormViewModel.ResourceToList;
        appointmentListInputDVO.SelectedOwnerResources = this.appointmentFormViewModel.SelectedSubResourceList;
        appointmentListInputDVO.filterAppListByAppDef = this.appointmentFormViewModel.filterAppListByAppDef;
        appointmentListInputDVO.MasterResourceCaption = this.appointmentFormViewModel.MasterResourceCaption;
        appointmentListInputDVO.MasterResourceList = this.appointmentFormViewModel.MasterResourceList;
        appointmentListInputDVO.SubResourceCaption = this.appointmentFormViewModel.SubResourceCaption;
        appointmentListInputDVO.currentPatient = this.appointmentFormViewModel.PatientToList;
        appointmentListInputDVO.SelectedAppointmentStateItems = this.appointmentFormViewModel.SelectedAppointmentStateItems;
        let url: string = "/api/AppointmentService/FillAppointmentsList";
        let body = appointmentListInputDVO;
        await this.httpService.post<AppointmentListInputDVO>(url, body, AppointmentListInputDVO).then(response => {
            let result = <AppointmentListInputDVO>response;
            if (result) {
                this.criteria = result.criteria;
                this.appointmentListItems = result.appointmentListItems;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }

    async GetAppointmentsAndSchedules(appointmentInputDVO: AppointmentInputDVO): Promise<GivenAppointmentsAndSchedules> {
        let url: string = "/api/AppointmentService/GetAppointmentsAndSchedules";
        let body = appointmentInputDVO;
        let result = await this.httpService.post<GivenAppointmentsAndSchedules>(url, body, GivenAppointmentsAndSchedules);
        let output: GivenAppointmentsAndSchedules = (result as GivenAppointmentsAndSchedules);
        return output;
    }

    protected cancelClick() {
        ServiceLocator.ModalStateService().callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    //onAppointmentUpdating(e: any) {
    //    let that = this;
    //    let sysDate: Date = new Date(Date.now());
    //    if (e.oldData && e.oldData.objectDefName == "APPOINTMENT") {
    //        if (e.newData.startDate < sysDate) {
    //            ServiceLocator.MessageService.showError("Randevu tarihi bugünün tarihinden önce olamaz.");
    //            e.cancel = true;
    //            return false;
    //        }
    //        else {
    //            e.newData.ownerObject = that.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == e.newData.ownerObjectID.toString());
    //            that.updateGivenAppointments(e.newData);
    //        }
    //    }
    //    else {
    //        ServiceLocator.MessageService.showError("Planlama türünde olan öğeler sürüklenemez.");
    //        e.cancel = true;
    //        return false;
    //    }
    //}


    onAppointmentClick(e: any) {
        //let that = this;
        //clearTimeout(that.timeOut);
    }

    //onCellClick(e: any) {
    //    let component = e.component,
    //        prevClickTime = component.lastClickTime;
    //    component.lastClickTime = new Date();
    //    if (prevClickTime && (component.lastClickTime - prevClickTime < 250)) {
    //        //Double click code
    //        this.openGivenAppointment();
    //    }
    //    if (this.appointmentFormViewModel._Appointment.AppointmentDefinition.StateOnly && this.appointmentFormViewModel.isAdmissionAppointment) {
    //        ServiceLocator.MessageService.showError("Süreç randevusu türündeki randevular, sadece süreç içinden verilebilir.");
    //        e.cancel = true;
    //        return false;
    //    }

    //    this.appointmentFormViewModel.selectedAppointmentSchedule = null;
    //    this.appointmentFormViewModel._myOldAppointment = null;
    //    if (this.appointmentFormViewModel.currentPatient) {
    //        this.appointmentFormViewModel._Appointment.Patient = this.appointmentFormViewModel.currentPatient;
    //        if (!this.appointmentFormViewModel.txtPatient)
    //            this.appointmentFormViewModel.txtPatient = this.appointmentFormViewModel.currentPatient.PatientIDandFullName;
    //    }
    //    else {
    //        this.appointmentFormViewModel._Appointment.Patient = null;
    //        this.appointmentFormViewModel.txtPatient = null;
    //    }
    //    this.appointmentFormViewModel._Appointment.AppDate = e.cellData.startDate;
    //    this.appointmentFormViewModel._Appointment.StartTime = e.cellData.startDate;
    //    this.appointmentFormViewModel._Appointment.EndTime = e.cellData.endDate;
    //    this.appointmentFormViewModel._Appointment.Resource = this.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == e.cellData.groups.ownerObjectID.toString());
    //    e.cancel = false;
    //}

    onAppointmentDblClick(e: any) {

    }

    //async onOptionChanged(e: any) {
    //    if (e.name == 'currentDate') {
    //        let previousDate: Date = new Date(e.previousValue);
    //        let currDate: Date = new Date(e.value);
    //        //let color: string = window['randomColor']({
    //        //    luminosity: 'light'
    //        //});
    //        let previousDateWeekNumber = previousDate.getWeekNumber();
    //        let currDateWeekNumber = currDate.getWeekNumber();
    //        let appDate = new Date(this.appointmentFormViewModel._Appointment.AppDate).getWeekNumber();
    //        let appDateWeekNumber = new Date(appDate).getWeekNumber();
    //        if (previousDateWeekNumber != currDateWeekNumber && appDateWeekNumber != currDateWeekNumber) {
    //            this.appointmentFormViewModel._Appointment.AppDate = currDate;
    //            await this.FillAppointments();
    //        }
    //    }
    //}

    async onAppointmentUpdated(e: any) {
    }

    async selectionChanged(e: any) {
        if (e) {
            this.appointmentFormViewModel.selectedAppointmentListItem = e.selectedRowsData[0] as GivenAppointment;
        }
        else
            this.appointmentFormViewModel.selectedAppointmentListItem = null;
    }

    onAppointmentFormCreated(data) {
        this.openGivenAppointment();
    }

    async cancelAppointment(givenAppointment: any) {
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
                    //this.appointmentFormViewModel.selectedAppointmentSchedule = null;
                    //this.appointmentFormViewModel._myOldAppointment = null;
                    //this.appointmentFormViewModel._Appointment.Patient = null;
                    //this.appointmentFormViewModel.txtPatient = null;
                    //this.appointmentFormViewModel.TCKNo = null;
                    //this.appointmentFormViewModel.PhoneNumber = null;
                    //this.appointmentFormViewModel._Appointment.Notes = null;
                    //this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.Home;
                    //this.appointmentFormViewModel._Appointment = new Appointment();
                    this.FillAppointments();
                    ServiceLocator.MessageService.showSuccess(i18n("M20725", "Randevu iptali başarı ile tamamlandı."));
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
        }
    }

    async approveAppointment(givenAppointment: any) {
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

    async updateGivenAppointments(givenAppointment: any) {
        if (givenAppointment) {
            let givenApp: GivenAppointment = <GivenAppointment>givenAppointment;
            if (givenApp.objectDefName == 'APPOINTMENT') {
                let checkAppForUpdateAppUrl: string = 'api/AppointmentService/CheckAppointmentForUpdate';
                let appointmentForUpdateDVO: AppointmentForUpdateDeleteApproveDVO = new AppointmentForUpdateDeleteApproveDVO();
                appointmentForUpdateDVO.appointmentObjectID = givenApp.objectID;
                let body = appointmentForUpdateDVO;
                let output: AppointmentToUpdateDVO = new AppointmentToUpdateDVO(); //= await this.httpService.post<AppointmentToUpdateDVO>(checkAppForUpdateAppUrl, body, AppointmentToUpdateDVO);
                await this.httpService.post<AppointmentToUpdateDVO>(checkAppForUpdateAppUrl, body, AppointmentToUpdateDVO).then(response => {
                    let result = response;
                    output = <AppointmentToUpdateDVO>result;
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                    return;
                });
                this.appointmentFormViewModel.appointmentToUpdateDVO = output;
                this.appointmentFormViewModel.selectedAppointmentSchedule = null;
                this.appointmentFormViewModel._myOldAppointment = givenApp;
                this.appointmentFormViewModel._Appointment.Patient = <Patient>givenApp.patient;
                this.appointmentFormViewModel.currentPatient = <Patient>givenApp.patient;
                this.appointmentFormViewModel.txtPatient = givenApp.txtPatient;
                this.appointmentFormViewModel.TCKNo = givenApp.TCKNo;
                this.appointmentFormViewModel.PhoneNumber = givenApp.PhoneNumber;
                this.appointmentFormViewModel.osPhoneType = givenApp.osPhoneType;
                this.appointmentFormViewModel._Appointment.AppDate = givenApp.startDate;
                this.appointmentFormViewModel._Appointment.StartTime = givenApp.startDate;
                this.appointmentFormViewModel._Appointment.EndTime = givenApp.endDate;
                this.appointmentFormViewModel._Appointment.Notes = givenApp.notes;
                this.appointmentFormViewModel._Appointment.AppointmentType = givenApp.appointmentTypeEnum;
                this.appointmentFormViewModel.AppointmentDef = output._appointmentDef;
                this.appointmentFormViewModel.CurrentObject = output.CurrentObject;
                if(givenApp.appointmentTypeEnum != null)
                    this.appointmentFormViewModel.AppointmentType = this.appointmentFormViewModel.AppointmentTypeList.find(ms => ms.AppointmentTypeEnumValue.valueOf() === givenApp.appointmentTypeEnum.valueOf());
                this.appointmentFormViewModel._Appointment.MasterResource = this.appointmentFormViewModel.MasterResourceList.find(r => r.ObjectID.toString() == givenApp.masterOwnerObjectID.toString());
                //if (this.appointmentFormViewModel.SubResourceList.length === 0)
                await this.getSubResourceList(this.appointmentFormViewModel._Appointment.AppointmentCarrier);
                this.appointmentFormViewModel._Appointment.Resource = this.appointmentFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == givenApp.ownerObject.ObjectID.toString());
                this.openGivenAppointment();
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

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                //that.appointmentFormViewModel._Appointment.Patient = null;
                //that.appointmentFormViewModel._Appointment.Notes = null;
                //that.appointmentFormViewModel.txtPatient = null;
                //that.appointmentFormViewModel.TCKNo = null;
                //that.appointmentFormViewModel.PhoneNumber = null;
                //that.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.GSM;
                //that.appointmentFormViewModel.selectedAppointmentSchedule = null;
                //that.appointmentFormViewModel._myOldAppointment = null;
                //that.appointmentFormViewModel.SelectedSubResourceList = new Array<string>();
                //that.appointmentFormViewModel._Appointment = new Appointment();
                if (inner.Result && inner.Result == 1) {
                    //if (that.isStateAppointment)
                    //    //that.cancelClick();
                    //    ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
                    //else {
                    that.FillAppointments();
                }
                //that.appointmentFormViewModel._Appointment.Patient = null;
                //that.appointmentFormViewModel._Appointment.Notes = null;
                //that.appointmentFormViewModel.txtPatient = null;
                //that.appointmentFormViewModel.TCKNo = null;
                //that.appointmentFormViewModel.PhoneNumber = null;
                //that.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.GSM;
                //that.appointmentFormViewModel.selectedAppointmentSchedule = null;
                //that.appointmentFormViewModel._myOldAppointment = null;
                //that.appointmentFormViewModel.SelectedSubResourceList = new Array<string>();
                //that.appointmentFormViewModel._Appointment = new Appointment();
            }).catch(err => {
                reject(err);
            });
        });
    }

    changeAppointmentVisible(e) {
        return e.row.data.rowButtonType == 1;
    }

    cancelAppointmentVisible(e) {
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
                //else if (row.data.rowButtonType == 1) {
                //    row.rowElement.firstItem().style.fontWeight = 550;
                //    //this.renderer.setStyle(row.rowElement.firstItem(), "font-weight", 550);
                //}
                //else if (row.data.rowButtonType == 2) {

                //}
            }
        }
    }

    public async listAppointments_Click(): Promise<void> {
        await this.FillAppointments();
    }

    public async approveAppointment_Click(val: any): Promise<void> {
        if (this.appointmentFormViewModel.selectedAppointmentListItem) {
            await this.approveAppointment(this.appointmentFormViewModel.selectedAppointmentListItem);
        }
        else {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M19998", "Önce onaylamak istediğiniz randevuyu seçiniz."), MessageIconEnum.WarningMessage);
            return;
        }
    }
    public async cancelAppointment_Click(e) {
        if (e.row.data) {
            this.contextMenuCellData = e.row.data;
            this.cancelAppointment(e.row.data);
        }
        else {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M19996", "Önce iptal etmek istediğiniz randevuyu seçiniz."), MessageIconEnum.WarningMessage);
            return;
        }
        //if (this.appointmentFormViewModel.selectedAppointmentListItem) {
        //    await this.cancelAppointment(this.appointmentFormViewModel.selectedAppointmentListItem);
        //}
        //else {
        //    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M19996", "Önce iptal etmek istediğiniz randevuyu seçiniz."), MessageIconEnum.WarningMessage);
        //    return;
        //}
    }
    public async changeAppointment_Click(e) {
        if (e.row.data) {
            this.contextMenuCellData = e.row.data;
            await this.updateGivenAppointments(e.row.data);
        }
        else {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M19993", "Önce değiştirmek istediğiniz randevuyu seçiniz."), MessageIconEnum.WarningMessage);
            return;
        }
        //if (this.appointmentFormViewModel.selectedAppointmentListItem) {
        //    this.openGivenAppointment();
        //}
        //else {
        //    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M19993", "Önce değiştirmek istediğiniz randevuyu seçiniz."), MessageIconEnum.WarningMessage);
        //    return;
        //}
    }


    contextMenuCellData: any;
    onCellContextMenu(e) {
        this.contextMenuCellData = e.cellData;
    }

    onContextMenuItemClick(e) {
        e.itemData.onItemClick(e.itemData);
    }

    public async printAppointment_Click(val: any): Promise<void> {
        try {
            if (this.appointmentListItems != null && this.appointmentListItems.length > 0) {
                let objectIdsParam: Array<GuidParam> = new Array<GuidParam>();
                for (let item of this.appointmentListItems) {
                    const objectIdParam = new GuidParam(item.objectID);
                    objectIdsParam.push(objectIdParam);
                }
                const objectIdsParameter = new ArrayParam(objectIdsParam);
                const criteriaParameter = new StringParam(this.criteria);
                const showNoteParameter = new BooleanParam(true);
                let reportParameters: any = { 'OBJECTIDS': objectIdsParameter, 'CRITERIA': criteriaParameter, 'SHOWNOTE': showNoteParameter };
                this.reportService.showReport("AppointmentListReport", reportParameters);
            }
            else
                ServiceLocator.MessageService.showError('Yazdırılacak veri bulunmamaktadır.');
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public async onAppListStartDateChanged(event) {
        if (event) {
            if (event.previousValue) {
                let currDate: Date = new Date(event.value);
                this.currentDate = currDate;
                if (currDate >= this.appointmentFormViewModel.appListEndDate)
                    this.appointmentFormViewModel.appListEndDate = new Date(currDate.getFullYear(), currDate.getMonth(), currDate.getDate(), 23, 59, 59);
            }
        }
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {

    }


}

