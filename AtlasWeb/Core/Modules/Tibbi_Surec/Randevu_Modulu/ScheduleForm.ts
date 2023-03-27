//$214E74C3
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { AppointmentTypeDVO, AppointmentTypeListDVO, MasterResourceDVO, MasterResourceInputDVO, SubResourceDVO, SubResourceInputDVO, ResourceAndColorDVO, GivenResource, AppointmentCarrierDVO } from './AppointmentFormViewModel';
import { ScheduleFormViewModel, ScheduleToConfirmDVO, CalismaPlaniGuncelleDVO } from './ScheduleFormViewModel';
import { ScheduleInputDVO, GivenSchedules, GivenSchedule, ScheduleToSaveDVO, ScheduleToUpdateDVO, MHRSActionInputDVO, MHRSActionDVO, ScheduleToCopyDVO, ScheduleRecurrenceToDeleteDVO } from './ScheduleFormViewModel';
import { DxSchedulerComponent } from "devextreme-angular";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { AppointmentDefinition, ScheduleJobRule, MHRSJobRuleTypeEnum, MHRSJobRuleTimeCriteriaEnum } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentCarrier } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { MHRSActionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ScheduleTypeEnum,CetvelTipiEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { Schedule } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { DxDataGridComponent } from 'devextreme-angular';
import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ConversionPanelExtension } from 'devexpress-dashboard/designer';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'ScheduleForm',
    templateUrl: './ScheduleForm.html',
    inputs: ['Model'],
    providers: [SystemApiService]
})

export class ScheduleForm extends TTVisual.TTForm implements OnInit {
    public appointmentCarrierList: Array<AppointmentCarrierDVO>;
    public policlinicList: Array<MasterResourceDVO>;
    public doctorlist: Array<Resource>;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    appointmentsData: GivenSchedule[] = new Array<GivenSchedule>();
    resourcesData: GivenResource[] = new Array<GivenResource>();
    masterResourcesData: GivenResource[] = new Array<GivenResource>();
    currentDate: Date = new Date(Date.now());

    dateRangeChanged: boolean = true;

    chkMHRSBildir: TTVisual.ITTCheckBox;
    public scheduleJobRulesColumns = [];

    isFirstLoad: boolean;

    views: any = [{
        type: 'day',
        groups: ['ownerObjectID'],
        dateCellTemplate: 'dateCellTemplate'
    }, {
        type: 'week',
        groups: ['ownerObjectID'],
        dateCellTemplate: 'dateCellTemplate'
    }, {
        type: 'month',
        groups: ['ownerObjectID'],
        dateCellTemplate: 'dateCellTemplate'
    }];

    @ViewChild('detailScheduler') _detailScheduler: DxSchedulerComponent;
    @ViewChild('scheduleJobRuleGrid') scheduleJobRuleGrid: DxDataGridComponent;

    public scheduleFormViewModel: ScheduleFormViewModel = new ScheduleFormViewModel();
    public get _Schedule(): Schedule {
        return this._TTObject as Schedule;
    }
    private ScheduleForm_DocumentUrl: string = '/api/ScheduleService/ScheduleForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalService: IModalService,
        private objectContextService: ObjectContextService,
        protected ngZone: NgZone) {
        super('SCHEDULE', 'ScheduleForm');
        this._DocumentServiceUrl = this.ScheduleForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Schedule();
        this.scheduleFormViewModel = new ScheduleFormViewModel();
        this._ViewModel = this.scheduleFormViewModel;
        this.scheduleFormViewModel._Schedule = this._TTObject as Schedule;
        this.scheduleFormViewModel._Schedule.AppointmentDefinition = new AppointmentDefinition();
        this.scheduleFormViewModel.AppointmentCarrier = new AppointmentCarrier();
        this.scheduleFormViewModel._Schedule.MasterResource = new Resource();
        this.scheduleFormViewModel._Schedule.Resource = new Resource();
        this.scheduleFormViewModel._Schedule.MHRSActionTypeDefinition = new MHRSActionTypeDefinition();
        this.scheduleFormViewModel.scheduleToUpdateDVO = new ScheduleToUpdateDVO();
        this.scheduleFormViewModel.AppointmentTypeList = new Array<AppointmentTypeListDVO>();
        this.scheduleFormViewModel.SelectedAppointmentTypeList = new Array<AppointmentTypeListDVO>();
        this.scheduleFormViewModel._Schedule.ScheduleJobRules = new Array<ScheduleJobRule>();
        this.scheduleFormViewModel.ReadOnly = true;
    }

    public loadJobRuleGridColumns() {
        this.scheduleJobRulesColumns = [
            {
                caption: "İş Kuralı Tipi",
                dataField: 'RuleType',
                lookup: { dataSource: MHRSJobRuleTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
                allowEditing: true,
                width: 175
            },
            {
                caption: "Zaman Kriteri",
                dataField: 'TimeCriteria',
                lookup: { dataSource: MHRSJobRuleTimeCriteriaEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
                allowEditing: true,
                width: 125
            },
            {
                caption: 'Değer',
                dataField: 'RuleValue',
                dataType: 'number',
                format: '#',
                editorOptions: {
                    onKeyPress: function (e) {
                        let event = e.event,
                            str = String.fromCharCode(event.keyCode);
                        if (!/[0-9]/.test(str))
                            event.preventDefault();
                    }
                },
                allowEditing: true,
                width: 'auto'
            }
        ];
    }
    protected loadViewModel() {
        this.loadJobRuleGridColumns();
        let that = this;
        that.isFirstLoad = true;
        that.scheduleFormViewModel = that._ViewModel as ScheduleFormViewModel;
        that._TTObject = that.scheduleFormViewModel._Schedule;
        if (that.scheduleFormViewModel == null)
            that.scheduleFormViewModel = new ScheduleFormViewModel();
        if (that.scheduleFormViewModel._Schedule == null)
            that.scheduleFormViewModel._Schedule = new Schedule();

        let appointmentDefinitionObjectID = that.scheduleFormViewModel._Schedule["AppointmentDefinition"];
        if (appointmentDefinitionObjectID && that.scheduleFormViewModel.AppointmentDefinitionList) {
            let appointmentDefinition = that.scheduleFormViewModel.AppointmentDefinitionList.find(o => o.ObjectID.toString() === appointmentDefinitionObjectID.toString());
            if (appointmentDefinition) {
                that.scheduleFormViewModel._Schedule.AppointmentDefinition = appointmentDefinition;
            }
        }

        let appointmentCarrierObjectID = that.scheduleFormViewModel.AppointmentCarrier["ObjectID"];
        if (appointmentCarrierObjectID && that.scheduleFormViewModel.AppointmentCarrierList) {
            let appointmentCarrier = that.scheduleFormViewModel.AppointmentCarrierList.find(o => o.ObjectID.toString() === appointmentCarrierObjectID.toString());
            if (appointmentCarrier) {
                that.scheduleFormViewModel.AppointmentCarrier = appointmentCarrier;
            }
        }
        if (that.scheduleFormViewModel.ScheduleAppointmentTypes) {
            that.scheduleFormViewModel._Schedule.ScheduleAppointmentTypes = that.scheduleFormViewModel.ScheduleAppointmentTypes;
        }

        that.scheduleFormViewModel._Schedule.ScheduleJobRules = new Array<ScheduleJobRule>();

        let masterResourceObjectID = that.scheduleFormViewModel._Schedule["MasterResource"];
        if (masterResourceObjectID && that.scheduleFormViewModel.MasterResourceList) {
            let masterResource = that.scheduleFormViewModel.MasterResourceList.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.scheduleFormViewModel._Schedule.MasterResource = masterResource;
            }
        }

        let resourceObjectID = that.scheduleFormViewModel._Schedule["Resource"];
        if (resourceObjectID && that.scheduleFormViewModel.SubResourceList) {
            let resource = that.scheduleFormViewModel.SubResourceList.find(o => o.ObjectID.toString() === resourceObjectID.toString());
            if (resource) {
                that.scheduleFormViewModel._Schedule.Resource = resource;
            }
        }

        let mhrsActionObjectID = that.scheduleFormViewModel._Schedule["MHRSActionTypeDefinition"];
        if (mhrsActionObjectID && that.scheduleFormViewModel.MHRSActionList) {
            let mhrsAction = that.scheduleFormViewModel.MHRSActionList.find(o => o.ObjectID.toString() === mhrsActionObjectID.toString());
            if (mhrsAction) {
                that.scheduleFormViewModel._Schedule.MHRSActionTypeDefinition = mhrsAction;
            }
        }

        let startTime: Date = (Convert.ToDateTime(that.scheduleFormViewModel._Schedule.StartTime));
        let endTime: Date = (Convert.ToDateTime(that.scheduleFormViewModel._Schedule.EndTime));
        let recurrenceStartDate: Date = (Convert.ToDateTime(that.scheduleFormViewModel.recurrenceStartDate));
        let recurrenceEndDate: Date = (Convert.ToDateTime(that.scheduleFormViewModel.recurrenceEndDate));

        that.scheduleFormViewModel._Schedule.StartTime = new Date(startTime.getFullYear(), startTime.getMonth(), startTime.getDate(), 8, 0, 0);
        that.scheduleFormViewModel._Schedule.EndTime = new Date(endTime.getFullYear(), endTime.getMonth(), endTime.getDate(), 9, 0, 0);
        that.scheduleFormViewModel.recurrenceStartDate = new Date(recurrenceStartDate.getFullYear(), recurrenceStartDate.getMonth(), recurrenceStartDate.getDate(), 0, 0, 0);
        that.scheduleFormViewModel.recurrenceEndDate = new Date(recurrenceEndDate.getFullYear(), recurrenceEndDate.getMonth(), recurrenceEndDate.getDate(), 0, 0, 0);

        // that.scheduleFormViewModel.cetvelTipi =that.scheduleFormViewModel._Schedule["CetvelTipiValue"];
    }

    async ngOnInit() {
        let that = this;
        this.scheduleFormViewModel.allowAdding = true;
        this.scheduleFormViewModel.allowDeleting = true;
        this.scheduleFormViewModel.allowDragging = true;
        this.scheduleFormViewModel.allowUpdating = true;
        await this.load(ScheduleFormViewModel);

    }


    async repaintScheduler() {
        let that = this;
        setTimeout(function () {
            that._detailScheduler.instance.repaint();
            //let schDate: Date = new Date(Date.now());
            let schDate: Date;
            if (that.scheduleFormViewModel._Schedule.ScheduleDate) {
                schDate = (Convert.ToDateTime(that.scheduleFormViewModel._Schedule.ScheduleDate));
                //schDate = new Date(schDate.getFullYear(), schDate.getMonth(), schDate.getDate(), 0, 0, 0);
                that._detailScheduler.instance.scrollToTime(7, 0, schDate);
            }
        }, 50);
    }


    async ngAfterViewInit() {
        await this.repaintScheduler();
    }

    async clientPreScript() {
        await this.repaintScheduler();
    }

    clientPostScript(state: String) {

    }

    async appointmentDefinitionSelectedItemChanged() {
        this.scheduleFormViewModel.labelSubResourceVisible = true;
        this.scheduleFormViewModel.subResourceVisible = true;
        if (this.scheduleFormViewModel._Schedule.AppointmentDefinition) {
            let appDef: AppointmentDefinition = <AppointmentDefinition>this.scheduleFormViewModel._Schedule.AppointmentDefinition;
            if (appDef.GiveToMaster) {
                this.scheduleFormViewModel.labelSubResourceVisible = false;
                this.scheduleFormViewModel.subResourceVisible = false;
            }
            if (!this.isFirstLoad) {
                await this.getAppointmentCarrierList(appDef.ObjectID.toString());
            }
            else
                this.isFirstLoad = false;
        }
        else
            this.scheduleFormViewModel._Schedule.AppointmentDefinition = null;
    }

    async getAppointmentCarrierList(value: string) {
        if (value) {
            let apiUrlCarrier: string = 'api/ScheduleService/FillAppointmentCarrierCombo?appointmentDefObjectID=' + value.toString();
            this.scheduleFormViewModel.AppointmentCarrierList = new Array<AppointmentCarrier>();
            this.scheduleFormViewModel.MasterResourceList = new Array<Resource>();
            this.scheduleFormViewModel.SubResourceList = new Array<Resource>();
            let res = await this.httpService.get<AppointmentCarrierDVO>(apiUrlCarrier, AppointmentCarrierDVO);
            let result = res;
            let output = <AppointmentCarrierDVO>result;
            this.scheduleFormViewModel.AppointmentCarrierList = output.AppointmentCarrierList;
            if (output.defaultCarrier != null) {
                let targetCarrier = this.scheduleFormViewModel.AppointmentCarrierList.find(ac => ac.ObjectID.valueOf() === output.defaultCarrier.ObjectID.valueOf());
                this.scheduleFormViewModel.AppointmentCarrier = targetCarrier;
            }
            else {
                if (this.scheduleFormViewModel.AppointmentCarrierList.length > 0)
                    this.scheduleFormViewModel.AppointmentCarrier = <AppointmentCarrier>this.scheduleFormViewModel.AppointmentCarrierList[0];
            }
        }
        else
            this.scheduleFormViewModel.AppointmentCarrier = null;
    }

    async appointmentCarrierSelectedItemChanged(value: any) {
        if (typeof value == 'object') {
            if (value) {
                let appCarrier: AppointmentCarrier = <AppointmentCarrier>value;
                this.scheduleFormViewModel.MasterResourceCaption = appCarrier.MasterResourceCaption;
                this.scheduleFormViewModel.SubResourceCaption = appCarrier.SubResourceCaption;
                this.scheduleFormViewModel._Schedule.MasterResource = null;
                this.scheduleFormViewModel._Schedule.Resource = null;
                //await this.getMasterResourceList(appCarrier);
                await this.getSubResourceList(appCarrier);
                await this.getAppointmentTypeList(appCarrier);
            }
            else
                this.scheduleFormViewModel.AppointmentCarrier = null;
        }
    }

    async getMasterResourceList(value: AppointmentCarrier) {
        if (value) {
            let masterResourceInputDVO = new MasterResourceInputDVO();
            masterResourceInputDVO.appointmentCarrierObjectID = value.ObjectID.toString();
            masterResourceInputDVO.appointmentDefObjectID = this.scheduleFormViewModel._Schedule.AppointmentDefinition.ObjectID.toString();
            masterResourceInputDVO.masterResourceFilter = value.MasterResourceFilter;
            masterResourceInputDVO.masterResourceType = value.MasterResource;
            masterResourceInputDVO.relationParentName = value.RelationParentName;
            masterResourceInputDVO.subResourceType = value.SubResource;
            if (this.scheduleFormViewModel._Schedule.Resource)
                masterResourceInputDVO.defaultSubResourceObjectID = this.scheduleFormViewModel._Schedule.Resource.ObjectID.toString();

            this.scheduleFormViewModel.MasterResourceList = new Array<Resource>();
            //this.scheduleFormViewModel.SubResourceList = new Array<Resource>();
            //this.scheduleFormViewModel.AllResourcesAndColors = new Array<ResourceAndColorDVO>();
            let apiUrlMasRes: string = 'api/ScheduleService/FillMasterResourceCombo';
            let body = masterResourceInputDVO;

            let res = await this.httpService.post<MasterResourceDVO>(apiUrlMasRes, body, MasterResourceDVO);
            let result = res;
            let output = <MasterResourceDVO>result;
            this.scheduleFormViewModel.MasterResourceList = output.MasterResourceList;
            for (let item of this.scheduleFormViewModel.MasterResourceList) {
                let resourceAndColorDVO: ResourceAndColorDVO = new ResourceAndColorDVO();
                //resourceAndColorDVO.resourceColor = item.ResourceColor; //TODO:FIXME
                resourceAndColorDVO.resourceObjectID = item.ObjectID.toString();
                this.scheduleFormViewModel.AllResourcesAndColors.push(resourceAndColorDVO);
            }
            if (output.defaultMasterResource != null) {
                let targetMasterResource = this.scheduleFormViewModel.MasterResourceList.find(ms => ms.ObjectID.valueOf() === output.defaultMasterResource.ObjectID.valueOf());
                this.scheduleFormViewModel._Schedule.MasterResource = targetMasterResource;
                if (this.scheduleFormViewModel.SelectedMasterResourceList && this.scheduleFormViewModel.SelectedMasterResourceList.includes(targetMasterResource.ObjectID.toString()) == false)
                    this.scheduleFormViewModel.SelectedMasterResourceList.push(targetMasterResource.ObjectID.toString());
            }
            else {
                if (this.scheduleFormViewModel.MasterResourceList.length > 0) {
                    this.scheduleFormViewModel._Schedule.MasterResource = <Resource>this.scheduleFormViewModel.MasterResourceList[0];
                    if (this.scheduleFormViewModel.SelectedMasterResourceList && this.scheduleFormViewModel.SelectedMasterResourceList.includes(this.scheduleFormViewModel._Schedule.MasterResource.ObjectID.toString()) == false)
                        this.scheduleFormViewModel.SelectedMasterResourceList.push(this.scheduleFormViewModel._Schedule.MasterResource.ObjectID.toString());
                }
            }
        }
        else {
            this.scheduleFormViewModel._Schedule.MasterResource = null;
        }
    }

    async appointmentTypeSelectedItemChanged(value: any) {
    }

    public onCetvelTipiChanged(event): void {
        if (this.scheduleFormViewModel.cetvelTipi != null && this.scheduleFormViewModel.cetvelTipi != event) {
            this.scheduleFormViewModel.cetvelTipi= event;

        }

    }

    async getAppointmentTypeList(value: AppointmentCarrier) {
        if (value) {
            this.scheduleFormViewModel.AppointmentTypeList = new Array<AppointmentTypeListDVO>();
            let apiUrlAppType: string = 'api/ScheduleService/FillScheduleAppointmentTypeList?appointmentCarrierObjectID=' + value.ObjectID.toString();
            let res = await this.httpService.get<AppointmentTypeDVO>(apiUrlAppType, AppointmentTypeDVO);
            let result = res;
            let output = <AppointmentTypeDVO>result;
            this.scheduleFormViewModel.AppointmentTypeList = output.AppointmentTypeList;
            this.scheduleFormViewModel.SelectedAppointmentTypeList = output.AppointmentTypeList;
            if (output.defaultAppType && output.defaultAppType.AppointmentType) {
                let targetAppointmentType = this.scheduleFormViewModel.AppointmentTypeList.find(ms => ms.AppointmentType.ObjectID.valueOf() === output.defaultAppType.AppointmentType.ObjectID.valueOf());
                this.scheduleFormViewModel.AppointmentType = targetAppointmentType;
            }
            else {
                this.scheduleFormViewModel.AppointmentType = null;
            }
        }
        else {
            this.scheduleFormViewModel.AppointmentType = null;
        }
    }

    async masterResourceSelectedItemChanged(value: any) {
        if (typeof value == 'object') {
            if (value) {
                await this.FillSchedules();
                //this.scheduleFormViewModel.SelectedSubResourceList = new Array<string>();
                //this.scheduleFormViewModel._Schedule.Resource = null;
                //await this.getSubResourceList(this.scheduleFormViewModel.AppointmentCarrier);
            }
        }
    }

    async getSubResourceList(value: AppointmentCarrier) {
        if (value) {
            let subResourceInputDVO = new SubResourceInputDVO();
            subResourceInputDVO.appointmentCarrierObjectID = value.ObjectID.toString();
            subResourceInputDVO.appointmentDefObjectID = this.scheduleFormViewModel._Schedule.AppointmentDefinition.ObjectID.toString();
            subResourceInputDVO.relationParentName = value.RelationParentName;
            subResourceInputDVO.subResourceType = value.SubResource;
            if (this.scheduleFormViewModel._Schedule.MasterResource)
                subResourceInputDVO.defaultMasterResourceObjectID = this.scheduleFormViewModel._Schedule.MasterResource.ObjectID.toString();
            this.scheduleFormViewModel.MasterResourceList = new Array<Resource>();
            this.scheduleFormViewModel.SubResourceList = new Array<Resource>();
            this.scheduleFormViewModel.AllResourcesAndColors = new Array<ResourceAndColorDVO>();
            let apiUrlSubRes: string = 'api/ScheduleService/FillSubResourceCombo';
            let body = subResourceInputDVO;

            let output = await this.httpService.post<SubResourceDVO>(apiUrlSubRes, body, SubResourceDVO);

            this.scheduleFormViewModel.SubResourceList = output.SubResourceList;
            for (let item of this.scheduleFormViewModel.SubResourceList) {
                let resourceAndColorDVO: ResourceAndColorDVO = new ResourceAndColorDVO();
                //resourceAndColorDVO.resourceColor = item.ResourceColor;    //TODO:FIXME
                resourceAndColorDVO.resourceObjectID = item.ObjectID.toString();
                this.scheduleFormViewModel.AllResourcesAndColors.push(resourceAndColorDVO);
            }
            if (output.defaultSubResource != null) {
                let targetSubResource = this.scheduleFormViewModel.SubResourceList.find(sr => sr.ObjectID.valueOf() === output.defaultSubResource.ObjectID.valueOf());
                this.scheduleFormViewModel._Schedule.Resource = targetSubResource;
                if (this.scheduleFormViewModel.SelectedSubResourceList && this.scheduleFormViewModel.SelectedSubResourceList.includes(targetSubResource.ObjectID.toString()) == false)
                    this.scheduleFormViewModel.SelectedSubResourceList.push(targetSubResource.ObjectID.toString());
            }
            else {
                if (this.scheduleFormViewModel.SubResourceList.length > 0) {
                    this.scheduleFormViewModel._Schedule.Resource = <Resource>this.scheduleFormViewModel.SubResourceList[0];
                    if (this.scheduleFormViewModel.SelectedSubResourceList && this.scheduleFormViewModel.SelectedSubResourceList.includes(this.scheduleFormViewModel.SubResourceList[0].ObjectID.toString()) == false)
                        this.scheduleFormViewModel.SelectedSubResourceList.push(this.scheduleFormViewModel.SubResourceList[0].ObjectID.toString());
                }
            }
        }
        else
            this.scheduleFormViewModel._Schedule.Resource = null;
    }

    //async masterResourceSelectedItemsChanged(value: any) {
    //    if (!this.isFirstLoad) {
    //        if (value) {
    //            let hasChanged: boolean = false;
    //            if (value.addedItems && value.addedItems.length > 0)
    //                hasChanged = true;
    //            if (value.removedItems && value.removedItems.length > 0)
    //                hasChanged = true;
    //            if (hasChanged)
    //                await this.FillSchedules();
    //        }
    //    }
    //}

    async subResourceSelectedItemChanged(value: any) {
        await this.IsSentToMHRS(this.scheduleFormViewModel._Schedule.Resource);
        this.scheduleFormViewModel.SelectedSubResourceList = new Array<string>();
        if (typeof value == 'object') {
            if (value) {
                let subResource: Resource = <Resource>value;
                this.scheduleFormViewModel.SelectedSubResourceList.push(subResource.ObjectID.toString());
                this.scheduleFormViewModel.SelectedMasterResourceList = new Array<string>();
                this.scheduleFormViewModel._Schedule.MasterResource = null;
                await this.getMasterResourceList(this.scheduleFormViewModel.AppointmentCarrier);
                //await this.FillSchedules();
            }
            else
                this.scheduleFormViewModel._Schedule.Resource = null;
        }
        else
            this.scheduleFormViewModel._Schedule.Resource = null;
    }

    async IsSentToMHRS(resource: Resource) {
        if (resource == null)
            this.scheduleFormViewModel.SentToMHRSVisible = false;
        else {
            let apiUrlIsSentToMHRS: string = 'api/ScheduleService/IsSentToMHRS';
            let body = resource;
            let output = await this.httpService.post<boolean>(apiUrlIsSentToMHRS, body);
            this.scheduleFormViewModel.SentToMHRSVisible = output;
            if (resource instanceof ResUser) {
                if ((<ResUser>resource).SentToMHRS == true)
                    this.scheduleFormViewModel._Schedule.SentToMHRS = true;
                else
                    this.scheduleFormViewModel._Schedule.SentToMHRS = false;
            }
        }
    }


    async subResourceSelectedItemsChanged(value: any) {
        if (value) {
            let hasChanged: boolean = false;
            if (value.addedItems && value.addedItems.length > 0)
                hasChanged = true;
            if (value.removedItems && value.removedItems.length > 0)
                hasChanged = true;
            if (hasChanged)
                await this.FillSchedules();
        }
    }

    async getMHRSActionList() {
        let mhrsActionInputDVO = new MHRSActionInputDVO();
        mhrsActionInputDVO.MHRSActionFilter = this.scheduleFormViewModel.MHRSActionFilter;

        let apiUrlMHRSAction: string = 'api/ScheduleService/FillMHRSActionCombo';
        let body = mhrsActionInputDVO;

        this.scheduleFormViewModel.MHRSActionList = new Array<MHRSActionTypeDefinition>();

        let output = await this.httpService.post<MHRSActionDVO>(apiUrlMHRSAction, body, MHRSActionDVO);

        this.scheduleFormViewModel.MHRSActionList = output.MHRSActionList;

        if (output.defaultMHRSAction != null) {
            let targetMHRSAction = this.scheduleFormViewModel.MHRSActionList.find(sr => sr.ObjectID.valueOf() === output.defaultMHRSAction.ObjectID.valueOf());
            this.scheduleFormViewModel._Schedule.MHRSActionTypeDefinition = targetMHRSAction;
        }
        else {
            if (this.scheduleFormViewModel.MHRSActionList.length > 0) {
                this.scheduleFormViewModel._Schedule.MHRSActionTypeDefinition = <MHRSActionTypeDefinition>this.scheduleFormViewModel.MHRSActionList[0];
            }
        }
    }

    async MHRSActionTypeDefinitionSelectedItemChanged(value: any) {
        let that = this;
        if (value) {
            if (value != null && ((<MHRSActionTypeDefinition>value).ActionCode == "77") || (<MHRSActionTypeDefinition>value).ActionCode == "311") { //XXXXXX
                that.scheduleFormViewModel.txtCountLimitDisabled = false;
                that.scheduleFormViewModel.txtDurationDisabled = true;
                that.scheduleFormViewModel._Schedule.Duration = 0;
            }
            else if (that.scheduleFormViewModel._Schedule.SentToMHRS == true) {
                that.scheduleFormViewModel.txtCountLimitDisabled = true;
                that.scheduleFormViewModel.txtDurationDisabled = false;
                that.scheduleFormViewModel._Schedule.CountLimit = 0;
            }
        }
    }

    async scheduleTypeChanged() {
        if (this.scheduleFormViewModel._Schedule.ScheduleType == ScheduleTypeEnum.NonWorkingHour) {
            this.scheduleFormViewModel.txtCountLimitDisabled = true;
            this.scheduleFormViewModel.txtDurationDisabled = true;
            this.scheduleFormViewModel._Schedule.CountLimit = 0;
            this.scheduleFormViewModel._Schedule.Duration = 0;
            this.scheduleFormViewModel._Schedule.IsWorkHour = false;
            this.scheduleFormViewModel.MHRSActionFilter = "ISWORKINGHOUR <> 1";
        }
        else if (this.scheduleFormViewModel._Schedule.ScheduleType == ScheduleTypeEnum.Ordered) {
            this.scheduleFormViewModel.txtCountLimitDisabled = false;
            this.scheduleFormViewModel.txtDurationDisabled = true;
            this.scheduleFormViewModel._Schedule.CountLimit = 0;
            this.scheduleFormViewModel._Schedule.Duration = 0;
            this.scheduleFormViewModel._Schedule.IsWorkHour = true;
            this.scheduleFormViewModel.MHRSActionFilter = "ISWORKINGHOUR = 1";
        }
        else if (this.scheduleFormViewModel._Schedule.ScheduleType == ScheduleTypeEnum.Timely) {
            this.scheduleFormViewModel.txtCountLimitDisabled = true;
            this.scheduleFormViewModel.txtDurationDisabled = false;
            this.scheduleFormViewModel._Schedule.CountLimit = 0;
            this.scheduleFormViewModel._Schedule.Duration = 0;
            this.scheduleFormViewModel._Schedule.IsWorkHour = true;
            this.scheduleFormViewModel.MHRSActionFilter = "ISWORKINGHOUR = 1";
        }
        await this.getMHRSActionList();
    }
    async FillSchedules() {
        if (this.scheduleFormViewModel.SelectedSubResourceList.length > 0) {
            this.dateRangeChanged = false;
            let scheduleInputDVO: ScheduleInputDVO = new ScheduleInputDVO();
            this.appointmentsData = new Array<GivenSchedule>();
            this.resourcesData = new Array<GivenResource>();
            this.masterResourcesData = new Array<GivenResource>();
            let schDate: Date = (Convert.ToDateTime(this.scheduleFormViewModel._Schedule.ScheduleDate));
            scheduleInputDVO.ScheduleDate = new Date(schDate.getFullYear(), schDate.getMonth(), schDate.getDate(), 0, 0, 0);
            if (this.scheduleFormViewModel._Schedule.Resource)
                scheduleInputDVO.ownerObjectID = this.scheduleFormViewModel._Schedule.Resource.ObjectID.toString();
            scheduleInputDVO.SelectedOwnerResources = this.scheduleFormViewModel.SelectedSubResourceList;
            scheduleInputDVO.SelectedMasterOwnerResources = this.scheduleFormViewModel.SelectedMasterResourceList;
            scheduleInputDVO.masterOwnerObjectID = this.scheduleFormViewModel._Schedule.MasterResource.ObjectID.toString();
            scheduleInputDVO.AllResourcesAndColors = this.scheduleFormViewModel.AllResourcesAndColors;
            if (this._detailScheduler.currentView)
                scheduleInputDVO.currentView = this._detailScheduler.currentView.toString();
            let givenSchedules: GivenSchedules = await this.GetSchedules(scheduleInputDVO);
            this.appointmentsData = givenSchedules.givenSchedules;
            this.resourcesData = givenSchedules.SubResources;
            this.masterResourcesData = givenSchedules.MasterResources;
            await this.repaintScheduler();
        }
    }

    async GetSchedules(scheduleInputDVO: ScheduleInputDVO): Promise<GivenSchedules> {
        let url: string = "/api/ScheduleService/GetSchedules";
        let body = scheduleInputDVO;
        let result = await this.httpService.post<GivenSchedules>(url, body, GivenSchedules);
        let output: GivenSchedules = result;
        return output;
    }

    public async saveScheduleClick() {
        await this.SaveSchedule();
        //ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    }
    public async confirmScheduleClick() {
        if (this._detailScheduler.currentView != "week") {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M17507", "Kesinleştirme işlemi için haftalık plan görünümünde olmalısınız!"), MessageIconEnum.ErrorMessage);
            return;
        }
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21548", "Seçili doktorun bu haftaya ait tüm planları kesinleştirilecektir!! .Devam Etmek İstiyor Musunuz ? "), 1);
        if (result === "H")
            ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
        else {
            try {
                let scheduleToConfirmDVO: ScheduleToConfirmDVO = new ScheduleToConfirmDVO();
                let currDate: Date = new Date(this._detailScheduler.currentDate.valueOf());
                scheduleToConfirmDVO.ScheduleDate = currDate;
                scheduleToConfirmDVO.ResourceID = this.scheduleFormViewModel._Schedule.Resource.ObjectID.toString();
                scheduleToConfirmDVO.MasterResourceID = this.scheduleFormViewModel._Schedule.MasterResource.ObjectID.toString();
                let url: string = "/api/ScheduleService/ConfirmScheduleFromMHRS";
                let body = scheduleToConfirmDVO;
                this.httpService.post(url, body)
                    .then(response => {
                        this.loadPanelOperation(false, '');
                        if (response == true)
                            ServiceLocator.MessageService.showSuccess(i18n("M15068", "Haftanın planları kesinleştirildi."));
                        this.FillSchedules();
                    }).catch(error => {
                        this.loadPanelOperation(false, '');
                        ServiceLocator.MessageService.showError("Hata : " + error);
                    });
            }
            catch (e) {
                ServiceLocator.MessageService.showError("Hata : " + e);
            }
        }
    }


    public async copyRecurrenceClick() {
        await this.copyRecurrence();
    }

    async copyRecurrence(): Promise<void> {
        try {
            let sch: Schedule = this.scheduleFormViewModel._Schedule;
            let recurrenceStartDate: Date = (Convert.ToDateTime(this.scheduleFormViewModel.recurrenceStartDate));
            recurrenceStartDate = new Date(recurrenceStartDate.getFullYear(), recurrenceStartDate.getMonth(), recurrenceStartDate.getDate(), 0, 0, 0);
            let recurrenceEndDate: Date = (Convert.ToDateTime(this.scheduleFormViewModel.recurrenceEndDate));
            recurrenceEndDate = new Date(recurrenceEndDate.getFullYear(), recurrenceEndDate.getMonth(), recurrenceEndDate.getDate(), 0, 0, 0);
            let sysDate = new Date(Date.now());
            let currDate: Date = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 0, 0, 0);
            if (recurrenceEndDate < recurrenceStartDate) {
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M11640", "Başlangıç Tarihi, Bitiş Tarihi' nden büyük olamaz."), MessageIconEnum.ErrorMessage);
                return;
            }

            if (recurrenceStartDate < currDate) {
                //TTVisual.InfoBox.Alert("Planlama tarihi, bugnn tarihinden nce olamaz.", MessageIconEnum.ErrorMessage);
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M30310", "Planlama tarihi, bugünün tarihinden önce olamaz."), MessageIconEnum.ErrorMessage);
                return;
            }

            let url: string = "/api/ScheduleService/CopyRecurrence";
            let scheduleToCopyDVO: ScheduleToCopyDVO = new ScheduleToCopyDVO();
            scheduleToCopyDVO.ScheduleDate = this.scheduleFormViewModel._Schedule.ScheduleDate;
            scheduleToCopyDVO.RecurrenceStartDate = this.scheduleFormViewModel.recurrenceStartDate;
            scheduleToCopyDVO.RecurrenceEndDate = this.scheduleFormViewModel.recurrenceEndDate;
            scheduleToCopyDVO.includeWeekend = this.scheduleFormViewModel.weekendIncluded;
            scheduleToCopyDVO.weeklyPlan = this.scheduleFormViewModel.weeklyPlan;
            scheduleToCopyDVO.currentSubResourceObjectID = this.scheduleFormViewModel._Schedule.Resource.ObjectID.toString();
            scheduleToCopyDVO.SentToMHRS = this.scheduleFormViewModel._Schedule.SentToMHRS;
            let body = scheduleToCopyDVO;
            this.loadPanelOperation(true, i18n("M20405", "Planlar Kopyalanıyor, lütfen bekleyiniz."));
            this.httpService.post(url, body).then(response => {
                let result = response;
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showSuccess(i18n("M12793", "Diğer günlere kopyalama tamamlandı."));
                this.FillSchedules();
            }).catch(error => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        } catch (e) {
            ServiceLocator.MessageService.showError("Hata : " + e);
        }
    }
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public async deleteRecurrenceClick() {
        await this.deleteRecurrence();
    }

    async deleteRecurrence(): Promise<void> {
        try {
            let sch: Schedule = this.scheduleFormViewModel._Schedule;

            if (this.scheduleFormViewModel.recurrenceEndDate < this.scheduleFormViewModel.recurrenceStartDate) {
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M11640", "Başlangıç Tarihi, Bitiş Tarihi' nden büyük olamaz."), MessageIconEnum.ErrorMessage);
                return;
            }

            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23562", "Toplu Planlama İptal"), i18n("M21537", "Seçilen tarih aralığındaki tüm planlamalar silinecek. \r\n\r\n Planlamaların silinmesini onaylıyor musunuz?"));
            if (result === "H")
                return;

            let url: string = "/api/ScheduleService/DeleteRecurrence";
            let scheduleRecurrenceToDeleteDVO: ScheduleRecurrenceToDeleteDVO = new ScheduleRecurrenceToDeleteDVO();
            scheduleRecurrenceToDeleteDVO.RecurrenceStartDate = this.scheduleFormViewModel.recurrenceStartDate;
            scheduleRecurrenceToDeleteDVO.RecurrenceEndDate = this.scheduleFormViewModel.recurrenceEndDate;
            scheduleRecurrenceToDeleteDVO.currentSubResourceObjectID = this.scheduleFormViewModel._Schedule.Resource.ObjectID.toString();
            scheduleRecurrenceToDeleteDVO.SentToMHRS = this.scheduleFormViewModel._Schedule.SentToMHRS;
            let body = scheduleRecurrenceToDeleteDVO;
            this.httpService.post(url, body).then(response => {
                let result = response;
                ServiceLocator.MessageService.showSuccess(result.toString());
                this.FillSchedules();
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        } catch (e) {
            ServiceLocator.MessageService.showError("Hata : " + e);
        }
    }

    async SaveSchedule(): Promise<void> {
        try {
            //EndTime tarihi scheduleDate ten farklı geldiği için burada tekrar set edildi.
            let schDate: Date = (Convert.ToDateTime(this.scheduleFormViewModel._Schedule.ScheduleDate));
            this.scheduleFormViewModel._Schedule.StartTime = new Date(schDate.getFullYear(), schDate.getMonth(), schDate.getDate(), this.scheduleFormViewModel._Schedule.StartTime.getHours(), this.scheduleFormViewModel._Schedule.StartTime.getMinutes(), 0);
            this.scheduleFormViewModel._Schedule.EndTime = new Date(schDate.getFullYear(), schDate.getMonth(), schDate.getDate(), this.scheduleFormViewModel._Schedule.EndTime.getHours(), this.scheduleFormViewModel._Schedule.EndTime.getMinutes(), 0);

            let sch: Schedule = this.scheduleFormViewModel._Schedule;
            let schStartTime: Date = (Convert.ToDateTime(sch.StartTime));
            schStartTime = new Date(schStartTime.getFullYear(), schStartTime.getMonth(), schStartTime.getDate(), schStartTime.getHours(), schStartTime.getMinutes(), 0);
            let schEndTime: Date = (Convert.ToDateTime(sch.EndTime));
            schEndTime = new Date(schEndTime.getFullYear(), schEndTime.getMonth(), schEndTime.getDate(), schEndTime.getHours(), schEndTime.getMinutes(), 0);
            let sysDate = new Date(Date.now());
            let currDate: Date = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), sysDate.getHours(), sysDate.getMinutes(), 0);

            if (!sch.MasterResource) {
                if (sch.AppointmentDefinition.GiveToMaster == true) {
                    let parameters: string[] = [this.scheduleFormViewModel.MasterResourceCaption];
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), this.scheduleFormViewModel.MasterResourceCaption + " " + i18n("M30309", "boş olamaz"), MessageIconEnum.ErrorMessage);
                    return;
                }
            }
            else if (!sch.Resource) {
                let parameters: string[] = [this.scheduleFormViewModel.SubResourceCaption];
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), this.scheduleFormViewModel.SubResourceCaption + " " + i18n("M30309", "boş olamaz"), MessageIconEnum.ErrorMessage);
                return;
            }

            if (schStartTime < currDate) {
                //TTVisual.InfoBox.Alert("Planlama tarihi, bugnn tarihinden nce olamaz.", MessageIconEnum.ErrorMessage);
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M30310", "Planlama tarihi, bugünün tarihinden önce olamaz."), MessageIconEnum.ErrorMessage);
                return;
            }

            if (schStartTime >= schEndTime) {
                //TTVisual.InfoBox.Alert("Balang saati, biti saatinden byk veya eit olamaz.", MessageIconEnum.ErrorMessage);
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M25287", "Bitiş tarihi başlangıç tarihinden sonra olmalıdır!"), MessageIconEnum.ErrorMessage);
                return;
            }

            let schType: ScheduleTypeEnum = ScheduleTypeEnum.Timely;
            if (sch.ScheduleType.HasValue()) {
                if (sch.ScheduleType.Value === ScheduleTypeEnum.Timely) {
                    if (sch.Duration == 0) {
                        TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M22406", "Süre giriniz."), MessageIconEnum.ErrorMessage);
                        return;
                    }
                    schType = ScheduleTypeEnum.Timely;
                }
                else if (sch.ScheduleType.Value === ScheduleTypeEnum.Ordered) {
                    if (sch.CountLimit == 0) {
                        TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M21402", "Sayı giriniz."), MessageIconEnum.ErrorMessage);
                        return;
                    }
                    schType = ScheduleTypeEnum.Ordered;
                }
                else if (sch.ScheduleType.Value === ScheduleTypeEnum.NonWorkingHour) {
                    schType = ScheduleTypeEnum.NonWorkingHour;
                }
            }
            else {
                let parameters: string[] = [i18n("M20382", "Planlama Tipi")];
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M20382", "Planlama Tipi") + " " + i18n("M30309", "boş olamaz"), MessageIconEnum.ErrorMessage);
                return;
            }

            //if (schType === ScheduleTypeEnum.NonWorkingHour) {
            //    if (this.scheduleFormViewModel.SelectedAppointmentTypeList && this.scheduleFormViewModel.SelectedAppointmentTypeList.length == 0) {
            //        TTVisual.InfoBox.Alert("Uyarı !", (await SystemMessageService.GetMessageV2(333, "En az bir tane Randevu Türü seçmelisiniz.")), MessageIconEnum.ErrorMessage);
            //        return;
            //    }
            //}
            if (this.scheduleFormViewModel._Schedule.SentToMHRS == true && this.scheduleFormViewModel._Schedule.ScheduleType.HasValue()) {
                if (this.scheduleFormViewModel._Schedule.ScheduleType.Value === ScheduleTypeEnum.Ordered) {
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M30311", "MHRS'ye bildirilen randevular saatli randevu olmak zorundadır !"), MessageIconEnum.ErrorMessage);
                    return;
                }
            }

            let url: string = "/api/ScheduleService/SaveSchedule";
            let scheduleToSaveDVO: ScheduleToSaveDVO = new ScheduleToSaveDVO();
            this.scheduleFormViewModel._Schedule["CetvelTipiValue"] = this.scheduleFormViewModel.cetvelTipi;
            scheduleToSaveDVO.scheduleToSave = this.scheduleFormViewModel._Schedule;
            scheduleToSaveDVO.ScheduleJobRules = this.scheduleFormViewModel._Schedule.ScheduleJobRules;
            if (this.scheduleFormViewModel.selectedSchedule)
                scheduleToSaveDVO.selectedCalendarItems.push(this.scheduleFormViewModel.selectedSchedule);
            scheduleToSaveDVO._carrierList = this.scheduleFormViewModel.AppointmentCarrierList;
            scheduleToSaveDVO.SelectedAppointmentTypeList = this.scheduleFormViewModel.SelectedAppointmentTypeList;
            scheduleToSaveDVO._myOldSchedule = this.scheduleFormViewModel._myOldSchedule;
            //TODO
            scheduleToSaveDVO._retSchedule = null;
            let body = scheduleToSaveDVO;
            this.httpService.post(url, body).then(response => {
                let result = response;
                ServiceLocator.MessageService.showSuccess(i18n("M16825", "İşlem başarı ile tamamlandı."));
                this.FillSchedules();
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        } catch (e) {
            ServiceLocator.MessageService.showError("Hata : " + e);
        }
    }

    updateGivenSchedules(givenSchedule: any) {
        if (givenSchedule) {
            let givenSch: GivenSchedule = <GivenSchedule>givenSchedule;
            let checkAppForUpdateAppUrl: string = 'api/ScheduleService/CheckScheduleForUpdate';
            let body = givenSch;
            this.httpService.post<ScheduleToUpdateDVO>(checkAppForUpdateAppUrl, body, ScheduleToUpdateDVO).then(response => {
                let result = response;
                let output = <ScheduleToUpdateDVO>result;
                this.scheduleFormViewModel.scheduleToUpdateDVO = output;
                this.scheduleFormViewModel.selectedSchedule = null;
                this.scheduleFormViewModel._myOldSchedule = givenSch;
                this.scheduleFormViewModel._Schedule.ScheduleDate = givenSch.startDate;
                this.scheduleFormViewModel._Schedule.StartTime = givenSch.startDate;
                this.scheduleFormViewModel._Schedule.EndTime = givenSch.endDate;
                this.scheduleFormViewModel._Schedule.Notes = givenSch.notes;
                this.scheduleFormViewModel._Schedule.Resource = this.scheduleFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == givenSch.ownerObject.ObjectID.toString());
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });

        }
    }

    public onAppointmentUpdating(e: any) {
        let that = this;
        let sysDate: Date = new Date(Date.now());
        if (e.newData.startDate < sysDate) {
            ServiceLocator.MessageService.showError(i18n("M20381", "Planlama tarihi bugünün tarihinden önce olamaz."));
            e.cancel = true;
            return false;
        }
        else {
            e.newData.ownerObject = that.scheduleFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == e.newData.ownerObjectID.toString());
            that.updateGivenSchedules(e.newData);
        }
    }
    public onAppointmentUpdated(e: any) {
    }
    onAppointmentRendered(e) {
        let that = this;
        e.appointmentElement.style.backgroundColor = e.appointmentData.color;
        e.appointmentElement.ondragend = function () {
            if (e.appointmentData) {
                e.cancel = true;
                return false;
            }
        };
    }

    onCellClick(e: any) {
        this.scheduleFormViewModel.selectedSchedule = null;
        this.scheduleFormViewModel._myOldSchedule = null;
        this.scheduleFormViewModel._Schedule.ScheduleDate = e.cellData.startDate;
        this.scheduleFormViewModel._Schedule.StartTime = e.cellData.startDate;
        this.scheduleFormViewModel._Schedule.EndTime = e.cellData.endDate;
        //this.scheduleFormViewModel._Schedule.MasterResource = this.scheduleFormViewModel.MasterResourceList.find(r => r.ObjectID.toString() == e.cellData.groups.masterOwnerObjectID.toString());
        //this.scheduleFormViewModel._Schedule.Resource = this.scheduleFormViewModel.SubResourceList.find(r => r.ObjectID.toString() == e.cellData.groups.ownerObjectID.toString());

        e.cancel = false;
    }

    onAppointmentDblClick(e: any) {
        e.cancel = true;
    }

    async onOptionChanged(e: any) {
        if (e.name == 'currentDate') {
            let previousDate: Date = new Date(e.previousValue);
            let currDate: Date = new Date(e.value);
            this.scheduleFormViewModel._Schedule.ScheduleDate = currDate;
            await this.FillSchedules();
            //let previousDateWeekNumber = previousDate.getWeekNumber();
            //let currDateWeekNumber = currDate.getWeekNumber();
            //let scheduleDate = new Date(this.scheduleFormViewModel._Schedule.ScheduleDate);
            //let scheduleDateWeekNumber = scheduleDate.getWeekNumber();
            //if (previousDateWeekNumber != currDateWeekNumber && scheduleDateWeekNumber != currDateWeekNumber) {
            //    this.scheduleFormViewModel._Schedule.ScheduleDate = currDate;
            //    await this.FillSchedules();
            //}
        }
        else if (e.name == 'currentView') {
            await this.repaintScheduler();
            await this.FillSchedules();
        }
    }


    onParticipatientReportOpen(sch: GivenSchedule) {

        this.showHRSExceptionForm(sch).then(result => {
            let modalActionResult = result as ModalActionResult;
            if (modalActionResult.Result == DialogResult.OK) {
                let obj = result.Param as GivenSchedule;
            }
        });

    }

    private showHRSExceptionForm(sch: GivenSchedule): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MHRSExceptionalForm";
            componentInfo.ModuleName = "MHRSExceptionalModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Randevu_Modulu/MHRSExceptionalModule";
            componentInfo.InputParam = new DynamicComponentInputParam(sch, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "MHRS İstisna Bildir";
            modalInfo.Width = 500;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async deleteSchedule(givenSchedule: any) {
        if (givenSchedule) {

            // let givenSch: GivenSchedule = <GivenSchedule>givenSchedule;
            let calismaPlaniGuncelleDVO: CalismaPlaniGuncelleDVO = new CalismaPlaniGuncelleDVO();
            
            calismaPlaniGuncelleDVO.givenSchedule =<GivenSchedule>givenSchedule;

           // throw new Exception("isail");
            
            if(this.scheduleFormViewModel.newMHRSParameter && calismaPlaniGuncelleDVO.givenSchedule.MHRSKesinCetvelID != null)
            {
                let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20379", "Planlama Silme"), i18n("M21536", "Seçilen planlama silinecek ve yerine 'Randevu Planlama' alanındaki bilgilere göre yeni cetvel eklenecektir. \r\n\r\n Planlamanın silinmesini onaylıyor musunuz?"));
                if (result === "H")
                    return;

                let returnMessage = await this.controlNewAppointmentInfo();// kesinleşmiş cetvel silinecek ise yerine artık yeni cetvel koymak gerekiyor
                if(returnMessage != "")
                {                 
                    let message = "Lütfen 'Randevu Planlama' alanından yeni eklenmesini istediğiniz cetvel bilgilerini seçiniz.\n" + returnMessage;
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), message, MessageIconEnum.ErrorMessage);
                    
                    return;
                }
                else{
                    let scheduleToSaveDVO: ScheduleToSaveDVO = new ScheduleToSaveDVO();
                    scheduleToSaveDVO.scheduleToSave = this.scheduleFormViewModel._Schedule;
                    scheduleToSaveDVO.ScheduleJobRules = this.scheduleFormViewModel._Schedule.ScheduleJobRules;
                    if (this.scheduleFormViewModel.selectedSchedule)
                        scheduleToSaveDVO.selectedCalendarItems.push(this.scheduleFormViewModel.selectedSchedule);
                    scheduleToSaveDVO._carrierList = this.scheduleFormViewModel.AppointmentCarrierList;
                    scheduleToSaveDVO.SelectedAppointmentTypeList = this.scheduleFormViewModel.SelectedAppointmentTypeList;
                    scheduleToSaveDVO._myOldSchedule = this.scheduleFormViewModel._myOldSchedule;
                    //TODO
                    scheduleToSaveDVO._retSchedule = null;
                    // let body = scheduleToSaveDVO;
                    calismaPlaniGuncelleDVO.scheduleToSaveDVO = scheduleToSaveDVO;
                }
            }
            else{
                let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20379", "Planlama Silme"), i18n("M21536", "Seçilen planlama silinecek. \r\n\r\n Planlamanın silinmesini onaylıyor musunuz?"));
                if (result === "H")
                    return;

                calismaPlaniGuncelleDVO.scheduleToSaveDVO = new ScheduleToSaveDVO();
            }

            // throw new Exception("isail");
            let checkAppForCancelAppUrl: string = 'api/ScheduleService/DeleteSelectedSchedules';
            let body = calismaPlaniGuncelleDVO;
            this.loadPanelOperation(true, i18n("M20371", "Plan Siliniyor, lütfen bekleyiniz."));
            this.httpService.post(checkAppForCancelAppUrl, body).then(response => {
                if (response) {
                    this.scheduleFormViewModel.selectedSchedule = null;
                    this.scheduleFormViewModel._myOldSchedule = null;
                    this.scheduleFormViewModel._Schedule.Notes = null;
                    this.loadPanelOperation(false, '');
                    ServiceLocator.MessageService.showSuccess(i18n("M20380", "Planlama silme başarı ile tamamlandı."));
                    this.FillSchedules();
                }
                else {
                    this.loadPanelOperation(false, '');
                    ServiceLocator.MessageService.showInfo(i18n("M21877", "Silinmek istenen planlamaya ") + this.scheduleFormViewModel.istisnasuresi + i18n("M21092", " saatten az kaldığı için plan silinemez! İstisna bildirmek için bilgilerinizi giriniz"));
                    this.onParticipatientReportOpen(calismaPlaniGuncelleDVO.givenSchedule);
                    this.FillSchedules();
                }

            }).catch(error => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
    }

    async controlNewAppointmentInfo(): Promise<string> {
        let schDate: Date = (Convert.ToDateTime(this.scheduleFormViewModel._Schedule.ScheduleDate));
        this.scheduleFormViewModel._Schedule.StartTime = new Date(schDate.getFullYear(), schDate.getMonth(), schDate.getDate(), this.scheduleFormViewModel._Schedule.StartTime.getHours(), this.scheduleFormViewModel._Schedule.StartTime.getMinutes(), 0);
        this.scheduleFormViewModel._Schedule.EndTime = new Date(schDate.getFullYear(), schDate.getMonth(), schDate.getDate(), this.scheduleFormViewModel._Schedule.EndTime.getHours(), this.scheduleFormViewModel._Schedule.EndTime.getMinutes(), 0);

        let sch: Schedule = this.scheduleFormViewModel._Schedule;
        let schStartTime: Date = (Convert.ToDateTime(sch.StartTime));
        schStartTime = new Date(schStartTime.getFullYear(), schStartTime.getMonth(), schStartTime.getDate(), schStartTime.getHours(), schStartTime.getMinutes(), 0);
        let schEndTime: Date = (Convert.ToDateTime(sch.EndTime));
        schEndTime = new Date(schEndTime.getFullYear(), schEndTime.getMonth(), schEndTime.getDate(), schEndTime.getHours(), schEndTime.getMinutes(), 0);
        let sysDate = new Date(Date.now());
        let currDate: Date = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), sysDate.getHours(), sysDate.getMinutes(), 0);

        if (!sch.MasterResource) {
            if (sch.AppointmentDefinition.GiveToMaster == true) {
                let parameters: string[] = [this.scheduleFormViewModel.MasterResourceCaption];
                return this.scheduleFormViewModel.MasterResourceCaption + " " + i18n("M30309", "boş olamaz");
            }
        }
        else if (!sch.Resource) {
            let parameters: string[] = [this.scheduleFormViewModel.SubResourceCaption];
            return this.scheduleFormViewModel.SubResourceCaption + " " + i18n("M30309", "boş olamaz");        
        }

        if (schStartTime < currDate) {
            //TTVisual.InfoBox.Alert("Planlama tarihi, bugnn tarihinden nce olamaz.", MessageIconEnum.ErrorMessage);
           return i18n("M30310", "Planlama tarihi, bugünün tarihinden önce olamaz.");
        }

        if (schStartTime >= schEndTime) {
            //TTVisual.InfoBox.Alert("Balang saati, biti saatinden byk veya eit olamaz.", MessageIconEnum.ErrorMessage);
           return i18n("M25287", "Bitiş tarihi başlangıç tarihinden sonra olmalıdır!");
        }

        let schType: ScheduleTypeEnum = ScheduleTypeEnum.Timely;
        if (sch.ScheduleType.HasValue()) {
            if (sch.ScheduleType.Value === ScheduleTypeEnum.Timely) {
                if (sch.Duration == 0) {
                    return i18n("M22406", "Süre giriniz.");
                }
                schType = ScheduleTypeEnum.Timely;
            }
            else if (sch.ScheduleType.Value === ScheduleTypeEnum.Ordered) {
                if (sch.CountLimit == 0) {
                   return i18n("M21402", "Sayı giriniz.");
                }
                schType = ScheduleTypeEnum.Ordered;
            }
            else if (sch.ScheduleType.Value === ScheduleTypeEnum.NonWorkingHour) {
                schType = ScheduleTypeEnum.NonWorkingHour;
            }
        }
        else {
            let parameters: string[] = [i18n("M20382", "Planlama Tipi")];
            return i18n("M20382", "Planlama Tipi") + " " + i18n("M30309", "boş olamaz");
        }

        //if (schType === ScheduleTypeEnum.NonWorkingHour) {
        //    if (this.scheduleFormViewModel.SelectedAppointmentTypeList && this.scheduleFormViewModel.SelectedAppointmentTypeList.length == 0) {
        //        TTVisual.InfoBox.Alert("Uyarı !", (await SystemMessageService.GetMessageV2(333, "En az bir tane Randevu Türü seçmelisiniz.")), MessageIconEnum.ErrorMessage);
        //        return;
        //    }
        //}
        if (this.scheduleFormViewModel._Schedule.SentToMHRS == true && this.scheduleFormViewModel._Schedule.ScheduleType.HasValue()) {
            if (this.scheduleFormViewModel._Schedule.ScheduleType.Value === ScheduleTypeEnum.Ordered) {
               return i18n("M30311", "MHRS'ye bildirilen randevular saatli randevu olmak zorundadır !");
            }
        }

        return "";
    }

    public async onScheduleDateChanged(event) {
        if (event) {
            if (event.previousValue) {
                let currDate: Date = new Date(event.value);
                this.currentDate = currDate;
                //this.scheduleFormViewModel._Schedule.StartTime = new Date(currDate.getFullYear(), currDate.getMonth(), currDate.getDate(), this.scheduleFormViewModel._Schedule.StartTime.getHours(), this.scheduleFormViewModel._Schedule.StartTime.getMinutes(), 0);
                //this.scheduleFormViewModel._Schedule.EndTime = new Date(currDate.getFullYear(), currDate.getMonth(), currDate.getDate(), this.scheduleFormViewModel._Schedule.EndTime.getHours(), this.scheduleFormViewModel._Schedule.EndTime.getMinutes(), 0);
            }
        }
    }

    //public async onSchStartTimeChanged(event) {
    //    if (event) {
    //        if (event.previousValue) {
    //            let currDate: Date = new Date(event.value);
    //           // this.scheduleFormViewModel._Schedule.StartTime = new Date(currDate.getFullYear(), currDate.getMonth(), currDate.getDate(), this.scheduleFormViewModel._Schedule.StartTime.getHours(), this.scheduleFormViewModel._Schedule.StartTime.getMinutes(), 0);
    //        }
    //    }
    //}

    //public async onSchEndTimeChanged(event) {
    //    if (event) {
    //        if (event.previousValue) {
    //            let currTime: Date = new Date(event.value);
    //            //this.scheduleFormViewModel._Schedule.EndTime = new Date(currTime.getFullYear(), currTime.getMonth(), currTime.getDate(), this.scheduleFormViewModel._Schedule.EndTime.getHours(), this.scheduleFormViewModel._Schedule.EndTime.getMinutes(), 0);
    //        }
    //    }
    //}

    onAppointmentFormOpening(e) {
        e.cancel = true;
    }

    sentToMHRSChanged(e: any) {
        let that = this;
        if (e.value) {
            if (e.value == true) {
                if (that.scheduleFormViewModel._Schedule.MHRSActionTypeDefinition != null && 
                    ((<MHRSActionTypeDefinition>that.scheduleFormViewModel._Schedule.MHRSActionTypeDefinition).ActionCode == "77") || ((<MHRSActionTypeDefinition>that.scheduleFormViewModel._Schedule.MHRSActionTypeDefinition).ActionCode == "311")) {
                    that.scheduleFormViewModel.txtCountLimitDisabled = false;
                    that.scheduleFormViewModel.txtDurationDisabled = true;
                    that.scheduleFormViewModel._Schedule.Duration = 0;
                }
                else {
                    that.scheduleFormViewModel.txtCountLimitDisabled = true;
                    that.scheduleFormViewModel.txtDurationDisabled = false;
                    that.scheduleFormViewModel._Schedule.CountLimit = 0;
                }
            }
            else if (that.scheduleFormViewModel._Schedule.ScheduleType == ScheduleTypeEnum.NonWorkingHour) {
                that.scheduleFormViewModel.txtCountLimitDisabled = false;
                that.scheduleFormViewModel.txtDurationDisabled = false;
                that.scheduleFormViewModel._Schedule.Duration = 0;
                that.scheduleFormViewModel._Schedule.CountLimit = 0;
            }
        }
    }

    onAppointmentClick(e: any) {
        if (e) {
            if (e.appointmentData) {
                this.scheduleFormViewModel.selectedSchedule = <GivenSchedule>e.appointmentData;
                e.cancel = false;
            }
            else {
                this.scheduleFormViewModel.selectedSchedule = null;
                e.cancel = true;
            }

        }
    }
    public async deleteScheduleClick() {
        if (this.scheduleFormViewModel.selectedSchedule != null) {
            await this.deleteSchedule(this.scheduleFormViewModel.selectedSchedule);
        }
        else {
            this.scheduleFormViewModel.selectedSchedule = null;
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M15779", "Hiç planlama seçmediniz."), MessageIconEnum.ErrorMessage);
            return;
        }
        //ServiceLocator.ModalStateService().callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.chkMHRSBildir = new TTVisual.TTCheckBox();
        this.chkMHRSBildir.Value = false;
        this.chkMHRSBildir.Text = "MHRS'ye Bildir";
        this.chkMHRSBildir.Name = "chkMHRSBildir";
        //this.chkMHRSBildir.TabIndex = 2;

        this.Controls = [];

    }


}
