//$5932D9FE
import { Component, ViewChild, Output, EventEmitter, Renderer2, ViewEncapsulation } from '@angular/core';
import { Headers, RequestOptions } from "@angular/http";
import { RadiologyWorkListFormViewModel, QueryInputDVO, RadiologyWorkListItem, RadiologyWorkListStateItem, RadiologyStatisticBaseObject,RadiologyStatisticReportViewModel,MenuOutputDVO, StateOutputDVO, UserResourceOutputDVO, RadiologyWorkListItemModel, DynamicComponentInfoDVO, SpecialPanelOutputDVO, SpecialPanelInputDVO, SpecialPanelListItem, UserResourceItem, ActiveInfoDVO, EquipmentItem, RadiologyEquipmentOutputDVO  } from "./RadiologyWorkListFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DxAccordionComponent, DxAutocompleteComponent, DxDataGridComponent } from "devextreme-angular";
import { MenuDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTListDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTListDef';
import { TTObjectStateDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { CommonService } from "ObjectClassService/CommonService";
import { Subscription, Observable } from 'rxjs';
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';

import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { ComposeComponent } from 'Fw/Components/ComposeComponent';
import { DynamicSidebarMenuItem } from '../../../wwwroot/app/SidebarMenu/Models/DynamicSidebarMenuItem';


import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicReportParameters } from '../../../wwwroot/app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { ModalInfo } from '../../../wwwroot/app/Fw/Models/ModalInfo';
import { IModalService } from '../../../wwwroot/app/Fw/Services/IModalService';

@Component({
    selector: "hvl-radiology-worklist-view",
    inputs: ['Model'],
    templateUrl: './RadiologyWorkListForm.html',
    providers: [SystemApiService],
    encapsulation: ViewEncapsulation.None
})
export class RadiologyWorkListForm extends  BaseComponent< RadiologyWorkListFormViewModel >{


    btnListele: TTVisual.ITTButton;
    btnSpecialPanelKaydet: TTVisual.ITTButton;
    btnSpecialPanelSil: TTVisual.ITTButton;
    PatientStatus: TTVisual.ITTEnumComboBox;
    chkOutPatient: TTVisual.ITTCheckBox;
    chkInPatient: TTVisual.ITTCheckBox;
    txtSEProtocolNo: TTVisual.ITTTextBox;
    private _selectedObjectDefName: string;
    private _specialPanelListItems: Array<SpecialPanelListItem>;
    @Output() OnObjectSelected: EventEmitter<Guid> = new EventEmitter<Guid>();
    public selectedRadiologyId: string;

    RadiologyTestList: Array<RadiologyWorkListItemModel>;
    public menuList: Array<MenuDefinition>;
    public stateList: Array<TTObjectStateDef>;
    public searchMenuTxt: string;
    public componentInfo: DynamicComponentInfo;
    public componentPatientInfo: DynamicComponentInfo;
    public selectedAccordionItem: any;
    public RadiologyWorkListItems: Array<RadiologyWorkListItem>;
    public RadiologyWorkListStateItems: Array<RadiologyWorkListStateItem>;
    public SelectedRadiologyWorkListItems: Array<RadiologyWorkListItem>;
    public SelectedRadiologyWorkListStateItems: Array<RadiologyWorkListStateItem>;
    public definitionMenuItems: Array<TTListDef>;
    public get SpecialPanelListItems(): Array<SpecialPanelListItem> {
        return this._specialPanelListItems;
    }
    public set SpecialPanelListItems(value: Array<SpecialPanelListItem>) {
        this._specialPanelListItems = value;
    }
    public LastSelectedSpecialPanel: SpecialPanelListItem;
    private collapseAttr = 0;
    private activeResUserObjectID: string;

    public WorkListColumns = [

        {
            caption: i18n("M16902", "İşlem Zamanı"),
            dataField: "ActionDate",
            //dataType: 'string',
            width: "auto",
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: "auto",
            cellTemplate: "PriorityCellTemplate",
            allowSorting: true
        },
        {
            "caption": i18n("M16818", "İşlem"),
            dataField: "RadiologyTestName",
            dataType: 'string',
            width: 150,
            allowSorting: true,
            cellTemplate: "TestPriorityCellTemplate"
        },
        {
            "caption": i18n("M16838", "İşlem Durumu"),
            dataField: "StateName",
            dataType: 'string',
            width: 100,
            allowSorting: true
        },
        {
            "caption": i18n("M16722", "İsteyen Klinik"),
            dataField: "FromResourceName",
            dataType: 'string',
            width: 150,
            allowSorting: true,
        }
    ];
    @ViewChild('workListGrid') workListGridInstance: DxDataGridComponent;
    @ViewChild(DxAutocompleteComponent) autoCompleteInstance: DxAutocompleteComponent;
    @ViewChild('dynamicComponent') dynamicComponent: ComposeComponent;

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    private selectedRowData: any;

    private episodeActionWorkListSubscription: Subscription;
    private refreshEpisodeActionSubscription: Subscription;

    openSpecialList() {
        this.autoCompleteInstance.instance.open();
    }

    constructor(container: ServiceContainer, private httpService: NeHttpService, public systemApiService: SystemApiService, private activeUserService: IActiveUserService, private renderer: Renderer2, private sideBarMenuService: ISidebarMenuService, protected modalService: IModalService) {
        super(container);
        this.initViewModel();
        this.initFormControls();
        this.SpecialPanelListItems = new Array<SpecialPanelListItem>();
        this.episodeActionWorkListSubscription = this.httpService.episodeActionWorkListSharedService.EpisodeActionWorkListItem.subscribe(
            EpisodeActionWorkListSharedItemModel => {
                this.openDynamicComponent(EpisodeActionWorkListSharedItemModel.ObjectDefName, EpisodeActionWorkListSharedItemModel.ObjectID, EpisodeActionWorkListSharedItemModel.FormDefID, EpisodeActionWorkListSharedItemModel.InputParam);
            }
        );

        this.refreshEpisodeActionSubscription = this.httpService.episodeActionWorkListSharedService.RefreshEpisodeActionWorkList.subscribe(
            RefreshEpisodeActionWorkList => {
                if (RefreshEpisodeActionWorkList) {
                    this.doSearch();
                }
                this.httpService.episodeActionWorkListSharedService.refreshWorklist(false);
            });
        this.activeResUserObjectID = activeUserService.ActiveUser.UserObject.ObjectID.toString();
    }

    public initViewModel(): void {
        this.SpecialPanelListItems = new Array<SpecialPanelListItem>();
        this.Model = new RadiologyWorkListFormViewModel();
        this.Model.txtPatient = "";
        this.Model.RadiologyWorkListItems = new Array<RadiologyWorkListItem>();
        this.Model.RadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
        this.Model.SelectedRadiologyWorkListItems = new Array<RadiologyWorkListItem>();
        this.Model.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
        this.Model.SelectedStateTypes = new Array<string>();
        this.Model.SelectedStateTypesEM = new Array<string>();
        this.Model.UserResourceItems = new Array<UserResourceItem>();
        this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
        this.Model.RadiologyEquipmentItems = new Array<EquipmentItem>();
        this.Model.SelectedRadiologyEquipmentItems = new Array<EquipmentItem>();
        //this.Model.StateType = "UNCOMPLETED";
        //this.Model.SelectedStateTypes.push("UNCOMPLETED");
        //this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
        this.Model.PatientStatus = "0";
        this.Model.WorkListCount = 20;
    }

    async ngOnInit() {
        let that = this;

        await this.getRadiologyEquipmentList();
        await this.getUserResourceList();
        await this.getMenuList();
        await this.getStateList(this.Model.SelectedRadiologyWorkListItems); 
        //let result: MenuOutputDVO = new MenuOutputDVO();

        this.AddHelpMenu();
        //let item: RadiologyWorkListItem = new RadiologyWorkListItem();
        //item.ObjectDefID = "2cf639c4-5819-4cf4-b295-2594a294c6a0";
        //item.ObjectDefName = "Radyoloji Tetkik";

        //let itemArray: Array<RadiologyWorkListItem> = new Array<RadiologyWorkListItem>();
        //itemArray.push(item);




      

        await this.getSpecialPanelList();
        if (this.LastSelectedSpecialPanel) {
            await this.loadSpecialCriteria(this.LastSelectedSpecialPanel);
        }

        await this.doSearch();

    }

    ngOnDestroy() {
        if (this.episodeActionWorkListSubscription != null) {
            this.episodeActionWorkListSubscription.unsubscribe();
            this.episodeActionWorkListSubscription = null;
        }
        if (this.refreshEpisodeActionSubscription != null) {
            this.refreshEpisodeActionSubscription.unsubscribe();
            this.refreshEpisodeActionSubscription = null;
        }
    }

    async clientPreScript() {

    }
    clientPostScript(state: String) {

    }

    btnListele_Click() {
        this.workListGridInstance.instance.clearFilter();
        this.workListGridInstance.instance.clearSelection();
        if (this.systemApiService.componentInfo)
            this.closeDynamicComponent();

        this.loadRadiologyWorklistPanelOperation(true, i18n("M15370", "Hastalar listeleniyor, lütfen bekleyiniz."));
        this.doSearch();
    }

    loadRadiologyWorklistPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    async btnSpecialPanelKaydet_Click() {
        if (this.Model.LastSelectedSpecialPanel && !this.Model.LastSelectedSpecialPanel.User && this.Model.LastSelectedSpecialPanelCaption == this.Model.LastSelectedSpecialPanel.Caption) {
            ServiceLocator.MessageService.showError("'" + this.Model.LastSelectedSpecialPanel.Caption + i18n("M20100", " özel panelini değiştiremezsiniz. Lütfen yeni bir özel panel ismi giriniz."));
        }
        else {

            let specialPanelInputDVO = new SpecialPanelInputDVO();
            specialPanelInputDVO.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;
            specialPanelInputDVO.SelectedWorkListItems = this.Model.SelectedRadiologyWorkListItems;
            specialPanelInputDVO.SelectedWorkListStateItems = this.SelectedRadiologyWorkListStateItems;
            specialPanelInputDVO.SpecialPanelListItemCaption = this.Model.LastSelectedSpecialPanelCaption;
            specialPanelInputDVO.SpecialPanelListItems = this.Model.SpecialPanelListItems;
            specialPanelInputDVO.activeResUserObjectID = this.activeResUserObjectID;
            let that = this;
            let fullApiUrl: string = "api/EpisodeActionWorkListService/SaveSpecialPanel";
            let body = specialPanelInputDVO;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<SpecialPanelInputDVO>(fullApiUrl, body).then(response => {
                let result = <SpecialPanelInputDVO>response;
                if (result) {
                    this.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
                    this.Model.LastSelectedSpecialPanelCaption = result.SpecialPanelListItemCaption;
                    this.SpecialPanelListItems = result.SpecialPanelListItems;
                    this.Model.SpecialPanelListItems = result.SpecialPanelListItems;
                    this.Model.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
                    this.getSpecialPanelList();
                    ServiceLocator.MessageService.showSuccess("'" + result.SpecialPanelListItemCaption + i18n("M20098", " özel paneli başarılı olarak kaydedildi."));
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
    }


    async btnSpecialPanelSil_Click() {

        if (this.Model.LastSelectedSpecialPanel && !this.Model.LastSelectedSpecialPanel.User) {
            ServiceLocator.MessageService.showError("'" + this.Model.LastSelectedSpecialPanel.Caption + i18n("M20101", " özel panelini silemezsiniz."));
        }
        else {
            let specialPanelInputDVO = new SpecialPanelInputDVO();
            specialPanelInputDVO.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;
            specialPanelInputDVO.SelectedWorkListItems = this.Model.SelectedRadiologyWorkListItems;
            specialPanelInputDVO.SelectedWorkListStateItems = this.SelectedRadiologyWorkListStateItems;
            specialPanelInputDVO.SpecialPanelListItemCaption = this.Model.LastSelectedSpecialPanelCaption;
            let deletedSpecialPanelCaption: string = this.Model.LastSelectedSpecialPanelCaption;
            specialPanelInputDVO.SpecialPanelListItems = this.Model.SpecialPanelListItems;
            specialPanelInputDVO.activeResUserObjectID = this.activeResUserObjectID;
            let that = this;
            let fullApiUrl: string = "api/EpisodeActionWorkListService/DeleteSpecialPanel";
            let body = specialPanelInputDVO;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<SpecialPanelInputDVO>(fullApiUrl, body).then(response => {
                let result = <SpecialPanelInputDVO>response;
                if (result) {
                    this.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
                    this.Model.LastSelectedSpecialPanelCaption = result.SpecialPanelListItemCaption;
                    this.SpecialPanelListItems = result.SpecialPanelListItems;
                    this.Model.SpecialPanelListItems = result.SpecialPanelListItems;
                    this.Model.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
                    this.getSpecialPanelList();
                    ServiceLocator.MessageService.showSuccess("'" + deletedSpecialPanelCaption + i18n("M20099", " özel paneli başarılı olarak silindi."));
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
    }

    btnCollapse() {

        if (this.collapseAttr == 1) {
            this.collapseAttr = 0;
        } else
            this.collapseAttr = 1;

    }
    public collapseIconProperties(): string {

        if (this.collapseAttr == 1) {
            return "fa fa-2x fa-angle-up";
        }
        return "fa fa-2x fa-angle-left";

    }
    public collapseBtnProperties(): string {

        if (this.collapseAttr == 1) {
            return "float-left";
        }
        return "float-right";

    }
    public collapseSelectedDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "hidden";
        }
        return "col-md-4";

    }
    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-8";

    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }

    queueList: Array<ExaminationQueueDefinition> = new Array<ExaminationQueueDefinition>();
    public getQueueList(): any {
        let that = this;
        let attt: GetSortedQueueItemsByArray_Input = new GetSortedQueueItemsByArray_Input();
        if (this.activeUserService.SelectedOutPatientResource != null) {
            attt.currentResUserID = this.activeUserService.ActiveUser.UserObject.ObjectID;
            attt.outPatientResID = this.activeUserService.SelectedOutPatientResource.ObjectID;
            attt.includeCalleds = false;
            let apiUrl: string = '/api/CommonService/GetQueueDefinition';
            this.httpService.post<any>(apiUrl, attt, ExaminationQueueDefinition).then(
                x => {
                    that.queueList = x as Array<ExaminationQueueDefinition>;
                    this.activeUserService.SelectedQueue = that.queueList[0];
                    return that.queueList;
                }
            );
        }

    }

    onContextMenuPreparing(e: any): void {
        let that = this;
        let menuItemHasProvision = false;
        let menuItemStatus: string;


        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {
                e.items = [{
                    text: i18n("M15531", "Hastayı Çağır"),
                    disabled: false,
                    onItemClick: function () {

                        that.CallSelectedPatient(e.row.data);
                    }
                }
                ];
            }
        }
    }

    async CallSelectedPatient(data: any) {
        if (!this.activeUserService.SelectedQueue)
            this.getQueueList();
        if (this.activeUserService.SelectedQueue == undefined && this.queueList.length == 0) {
            await CommonService.openUserResourceSelectionView();
        }

        let audio = new Audio();
        let currentLocation = window.location.href.replace("/radyoloji", "");
        audio.src = currentLocation + "/Content/doorbell.wav";
        audio.load();
        audio.play();

        let attt: CallNexttPatientParam = new CallNexttPatientParam();
        attt.ObjectId = data.EpisodeActionObjectID;
        let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
        attt.outPatientResID = new Guid(outPatientResID);
        attt.OrderNo = data.QueueNumberToSort;
        let apiUrl: string = '/api/CommonService/CallSelectedPatient';
        this.httpService.post<any>(apiUrl, attt).then(
            x => {
            }
        );

        this.openDynamicComponent(data.ObjectDefName, data.ObjectID);
    }

    async OpenLcdMonitor() {
        if (!this.activeUserService.SelectedQueue)
            this.getQueueList();
        if (this.activeUserService.SelectedQueue == undefined && this.queueList.length == 0) {
            await CommonService.openUserResourceSelectionView();
        }
        let names: any = this.activeUserService.ActiveUser.UserObject;
        let doktorName = names.Name.toString();

        if(this.activeUserService.SelectedQueue == null){
            ServiceLocator.MessageService.showError("Lütfen kullanıcı birim değiştirme ekranından, Ayaktan Hasta Birimini seçiniz.");
            return;
        }

        let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
        let currentLocation = window.location.href.replace("/radyoloji", "");
        let url = currentLocation + "/PatientCaller/HastaCagriForm2?currentResUserID=00000000-0000-0000-0000-000000000000&outPatientResID=" + outPatientResID + "&includeCalleds=false&doktorName=" + "";
        let input: any = { Url: encodeURI(url) };
        let httpPrintServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
        this.httpService.post(httpPrintServiceUrl, input);
        sessionStorage.setItem('isLCDOpened', 'true');
        //this.openInNewTab(currentLocation + "/PatientCaller/HastaCagriForm2?currentResUserID=00000000-0000-0000-0000-000000000000&outPatientResID=" + outPatientResID + "&includeCalleds=false&doktorName=" + doktorName);
    }


    async doSearch(): Promise<void> {
        if (!this.activeUserService.SelectedOutPatientResource && !this.activeUserService.SelectedInPatientResource) {
            await CommonService.openUserResourceSelectionView();
            await this.setSelectedUserResourceList();
        }
        let inputDvo = new QueryInputDVO();
        inputDvo.txtPatient = this.Model.txtPatient;
        inputDvo.SEProtocolNo = this.txtSEProtocolNo.Text;
        inputDvo.StartDate = this.Model.StartDate;
        inputDvo.EndDate = this.Model.EndDate;
        inputDvo.ID = this.Model.ID;
        inputDvo.WorkListCount = this.Model.WorkListCount;
        inputDvo.StateType = this.Model.StateType;
        inputDvo.PatientStatus = "";
        if (this.chkOutPatient.Value == true && this.chkInPatient.Value == true)
            this.Model.PatientStatus = "0,1,2,3";
        else if (this.chkOutPatient.Value == true)
            this.Model.PatientStatus = "0";
        else if (this.chkInPatient.Value == true)
            this.Model.PatientStatus = "1,2,3";
        inputDvo.PatientStatus = this.Model.PatientStatus;
        inputDvo.SelectedWorkListItems = this.Model.SelectedRadiologyWorkListItems;
        inputDvo.SelectedWorkListStateItems = this.SelectedRadiologyWorkListStateItems;
        inputDvo.WorkListItems = this.Model.RadiologyWorkListItems;
        inputDvo.WorkListStateItems = this.Model.RadiologyWorkListStateItemsAll;
        inputDvo.SelectedStateTypes = new Array<string>();
        inputDvo.SelectedStateTypesEM = Array<string>();
        inputDvo.UserResourceItems = this.Model.UserResourceItems;
        inputDvo.SelectedUserResourceItems = this.Model.SelectedUserResourceItems;
        inputDvo.RadiologyEquipmentItems = this.Model.RadiologyEquipmentItems;
        inputDvo.SelectedRadiologyEquipmentItems = this.Model.SelectedRadiologyEquipmentItems;
        inputDvo.activeResUserObjectID = this.activeResUserObjectID;
        //inputDvo.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;
        if (this.activeUserService.SelectedQueue !== undefined)
            inputDvo.SelectedQueueObjectID = this.activeUserService.SelectedQueue.ObjectID;


        let that = this;
        let fullApiUrl: string = "api/RadiologyWorkListService/QueryRadiologyWorkList";

        let result = await this.httpService.post<RadiologyWorkListFormViewModel>(fullApiUrl, inputDvo, RadiologyWorkListFormViewModel);
        this.Model.RadiologyList = result.RadiologyList;
        this.Model.txtPatient = result.txtPatient;
        this.Model.StartDate = result.StartDate;
        this.Model.EndDate = result.EndDate;
        this.Model.ID = result.ID;
        this.Model.WorkListCount = result.WorkListCount;
        this.Model.StateType = result.StateType;
        this.Model.SelectedStateTypes = result.SelectedStateTypes;
        this.Model.SelectedStateTypesEM = result.SelectedStateTypesEM;
        this.Model.PatientStatus = result.PatientStatus;

        this.loadRadiologyWorklistPanelOperation(false, '');
    }

    async setSelectedUserResourceList() {
        //Radyoloji iş listesi için tüm birimler seçili gelsin.
        //this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
        //this.Model.SelectedUserResourceItems = this.Model.UserResourceItems;

        // 45851  nolu task icin degisiklik yapildi, 14/11/2017 GNL
        this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
        let userResourceItem: UserResourceItem;
        if (this.activeUserService.SelectedOutPatientResource) {
            this.SelectUserResource(this.activeUserService.SelectedOutPatientResource.ObjectID.toString());
        }
        if (this.activeUserService.SelectedInPatientResource) {
            this.SelectUserResource(this.activeUserService.SelectedInPatientResource.ObjectID.toString());
        }
        if (this.activeUserService.SelectedSecMasterResource) {
            this.SelectUserResource(this.activeUserService.SelectedSecMasterResource.ObjectID.toString());
        }
    }

    async getUserResourceList() {
        let that = this;
        await this.httpService.get<UserResourceOutputDVO>("api/EpisodeActionWorkListService/GetUserResources?FromRadiology=true" ).then(response => {
            let output = <UserResourceOutputDVO>response;
            if (output) {
                that.Model.UserResourceItems = output.WorkListSearchUserResourceItem;
                this.setSelectedUserResourceList();
                //that.Model.SelectedUserResourceItems = output.SelectedWorkListSearchUserResourceItem;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }

    async getRadiologyEquipmentList() {
        let that = this;
        await this.httpService.get<RadiologyEquipmentOutputDVO>("api/RadiologyWorkListService/GetRadiologyEquipment").then(response => {
            let output = <RadiologyEquipmentOutputDVO>response;
            if (output) {
                that.Model.RadiologyEquipmentItems = output.EquipmentItemList;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }
    async getMenuList() {
        let that = this;
        let fullApiUrl: string = "api/RadiologyWorkListService/GetEpisodeActionMenuDefinition";
        let result = await this.httpService.get<MenuOutputDVO>(fullApiUrl, MenuOutputDVO);

        this.RadiologyWorkListItems = result.WorkListSearchItem;
        that.Model.RadiologyWorkListStateItemsAll = result.WorkListSearchStateItem;
        this.Model.RadiologyWorkListItems = result.WorkListSearchItem;
        this.Model.SelectedRadiologyWorkListItems = result.WorkListSearchItem; //Sadece Radyoloji Tetkik geliyor.
        this.SelectedRadiologyWorkListItems = result.WorkListSearchItem;
        
    }

    async getStateList2(value: any) {
        let that = this;
        let fullApiUrl: string = "api/RadiologyWorkListService/GetEpisodeActionStateDefinition";
        let result = await this.httpService.post<StateOutputDVO>(fullApiUrl, value, StateOutputDVO);

        this.RadiologyWorkListStateItems = result.WorkListSearchStateItem;
        this.Model.RadiologyWorkListStateItems = result.WorkListSearchStateItem;
        this.Model.SelectedRadiologyWorkListStateItems = result.WorkListSearchStateItem;

    }

    async getStateList(value: any) {
        let that = this;
        let fullApiUrl: string = "api/RadiologyWorkListService/GetEpisodeActionStateDefinition";
        let result = await this.httpService.post<StateOutputDVO>(fullApiUrl, value, StateOutputDVO);

        that.RadiologyWorkListStateItems = result.WorkListSearchStateItem;
        that.Model.SelectedRadiologyWorkListStateItems = result.WorkListSearchStateItem;
        that.Model.RadiologyWorkListStateItems = result.WorkListSearchStateItem;

    }

    loadWorklistPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    async select(value: any): Promise<void> {
        let component = value.component;
        //this.loadWorklistPanelOperation(true, 'İşlemler listeleniyor, lütfen bekleyiniz.');

        if (this.dynamicComponent && this.dynamicComponent.isBoundFormModified() === true) {
            const result = confirm('Değişiklikler kaydedilmemiş. Yine de devam etmek istiyor musunuz?');
            if (result === false) {
                if (value.component && value.component.getSelectedRowKeys().length) {
                    value.component.deselectRows(value.component.getSelectedRowKeys());
                    value.component.getSelectedRowKeys().splice(0, value.component.getSelectedRowKeys().length);
                    if (this.selectedRowData) {
                        value.component.selectRows([this.selectedRowData]);
                    }
                }
                //this.loadWorklistPanelOperation(false, '');
                return;
            }
        }

        this.selectedRowData = value;
        let selectedModel: RadiologyWorkListItemModel = value.data as RadiologyWorkListItemModel;
        if (selectedModel)
            this.openDynamicComponent(selectedModel.ObjectDefName, selectedModel.ObjectID);

        //let _data: RadiologyWorkListItemModel = value.selectedRowsData[0] as RadiologyWorkListItemModel;
        //if ( _data) {
        //    this.openDynamicComponent(_data.ObjectDefName, _data.ObjectID);
        //}

    }

    canDeactivate(): Observable<boolean> | Promise<boolean> | boolean {

        if (this.dynamicComponent && this.dynamicComponent.isBoundFormModified() === true) {
            const result = confirm('Değişiklikler kaydedilmemiş. Yine de devam etmek istiyor musunuz?');
            if (result === false) {
                return false;
            }
        }
        return true;
    }

    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam);
            this.selectedRadiologyId = objectID;

        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
            });
        }
    }

    async selectIfSingleRadiology(): Promise<void> {
        if (this.Model.RadiologyList != null && this.Model.RadiologyList.length > 0) {
            this.systemApiService.open(this.Model.RadiologyList[0].ObjectID, this.Model.RadiologyList[0].ObjectDefName);
            this.selectedRadiologyId = this.Model.RadiologyList[0].ObjectID;

            let fullApiUrl: string = "api/RadiologyWorkListService/GetDynamicComponentPatientInfo?ObjectId=" + this.selectedRadiologyId;
            let result = await this.httpService.get<DynamicComponentInfoDVO>(fullApiUrl, DynamicComponentInfoDVO);

            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = result.ComponentName;
            compInfo.ModuleName = result.ModuleName;
            compInfo.ModulePath = result.ModulePath;
            compInfo.objectID = result.objectID;
            this.componentPatientInfo = compInfo;
        }
    }

    async radiologyWorkListItemsSelectionChanged(values: any) {
        this.Model.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
        //if(this.Model.SelectedEpisodeActionWorkListItems != null && this.Model.SelectedEpisodeActionWorkListItems.length == 1)
        //console.log(values);
        if (values) {
            if (values.length > 0) {
                let _episodeActionWorkListItems: Array<RadiologyWorkListItem> = new Array<RadiologyWorkListItem>();
                for (let item of values) {
                    let _episodeActionWorkListItem: RadiologyWorkListItem = new RadiologyWorkListItem();
                    _episodeActionWorkListItem = item; //values[0];
                    _episodeActionWorkListItems.push(_episodeActionWorkListItem);
                }
                await this.getStateList2(_episodeActionWorkListItems);
            }
            // this.SelectedEpisodeActionWorkListItems = values;
            this.Model.SelectedRadiologyWorkListItems = values;
        }
        else {
            //console.log(values);
            this.RadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
            this.Model.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
        }
    }

    async radiologyWorkListStateItemsSelectionChanged(values: any) {
        if (this.Model.SelectedRadiologyWorkListStateItems && this.Model.SelectedRadiologyWorkListStateItems.length > 0) {
            this.Model.SelectedStateTypesEM = new Array<string>();
        }
        else {
            if (this.Model.txtPatient == null || this.Model.txtPatient == "") {
                //this.Model.SelectedStateTypes.push("UNCOMPLETED");
                //this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
            }
        }
        //if (values)
        //    this.Model.SelectedRadiologyWorkListStateItems = values;
        //else
        //    this.Model.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
    }

    patientChanged(patient: any) {
        let sysDate: Date = new Date(Date.now());
        if (patient) {
            this.Model.txtPatient = patient.ObjectID;
            this.Model.SelectedStateTypes = new Array<string>();
            this.Model.SelectedStateTypesEM = new Array<string>();
            //this.Model.SelectedRadiologyWorkListItems = new Array<RadiologyWorkListItem>();
            this.Model.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
            this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.Model.StartDate = (Convert.ToDateTime(this.Model.EndDate).AddMonths(-6));
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = true;
        }
        else {
            this.Model.txtPatient = "";
            //this.Model.SelectedStateTypes.push("UNCOMPLETED");
            //this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
            this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.Model.StartDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 0, 0, 0);
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = false;
        }
        this.btnListele_Click();
    }

    txtSEProtocolNoChanged(e) {
        let sysDate: Date = new Date(Date.now());
        if (this.txtSEProtocolNo.Text != null && this.txtSEProtocolNo.Text != "") {
            this.Model.SEProtocolNo = this.txtSEProtocolNo.Text;
            this.Model.SelectedStateTypes = new Array<string>();
            this.Model.SelectedStateTypesEM = new Array<string>();
            //this.Model.SelectedRadiologyWorkListItems = new Array<RadiologyWorkListItem>();
            this.Model.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
            this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.Model.StartDate = (Convert.ToDateTime(this.Model.EndDate).AddMonths(-6));
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = true;
        }
        else {
            this.Model.SEProtocolNo = "";
            //this.Model.SelectedStateTypes.push("UNCOMPLETED");
            //this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
            this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.Model.StartDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 0, 0, 0);
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = false;
        }
        this.btnListele_Click();
    }

    changed(e: any): void {
        alert(e);
    }

    closeDynamicComponent() {
        this.systemApiService.componentInfo = null;
        this.selectedRadiologyId = "";
    }

    
    async getSpecialPanelList() {

        let that = this;
        await this.httpService.get<SpecialPanelOutputDVO>("api/EpisodeActionWorkListService/GetSpecialPanelDefinition?activeResUserObjectID=" + this.activeResUserObjectID).then(response => {
            let output = <SpecialPanelOutputDVO>response;
            if (output) {
                that.SpecialPanelListItems = output.SpecialPanelList;
                that.Model.SpecialPanelListItems = output.SpecialPanelList;
                if (output.LastSelectedSpecialPanel)
                    that.Model.LastSelectedSpecialPanelCaption = output.LastSelectedSpecialPanel.Caption;
                that.Model.LastSelectedSpecialPanel = output.LastSelectedSpecialPanel;
                that.LastSelectedSpecialPanel = output.LastSelectedSpecialPanel;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });


    }

    async userResourceItemsSelectionChanged()  {

    }
    async loadSpecialCriteria(data: any) {
        if (typeof data == 'object') {
            this.Model.LastSelectedSpecialPanel = data;
            //this.SelectedRadiologyWorkListItems = new Array<RadiologyWorkListItem>();
            this.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
            if (this.Model.LastSelectedSpecialPanel && this.Model.LastSelectedSpecialPanel.SpecialPanelCriteriaValues && this.Model.LastSelectedSpecialPanel.SpecialPanelCriteriaValues.length > 0) {
                this.Model.LastSelectedSpecialPanel.SpecialPanelCriteriaValues.forEach(crValM => {
                    if (crValM.Value) {
                        if (crValM.Name == "OBJECTDEFINITIONS") {
                            let values: string[] = crValM.Value.split(',');
                            values.forEach(ID => {
                                this.SelectObjectDefinition(ID);
                            });
                        }
                    }
                });
                //this.Model.SelectedRadiologyWorkListItems = this.SelectedRadiologyWorkListItems;
                if (this.Model.SelectedRadiologyWorkListItems.length > 0) {

                    await this.getStateList(this.Model.SelectedRadiologyWorkListItems); //.then(() => {
                    this.Model.LastSelectedSpecialPanel.SpecialPanelCriteriaValues.forEach(crValS => {
                        if (crValS.Value) {
                            if (crValS.Name == "STATES") {
                                let values: string[] = crValS.Value.split(',');
                                values.forEach(ID => {
                                    this.SelectState(ID);
                                });
                            }
                        }

                    });
                    //});
                    this.Model.SelectedRadiologyWorkListStateItems = this.SelectedRadiologyWorkListStateItems;
                }
                else {
                    this.RadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
                    this.Model.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
                }
                this.doSearch();
            }
        }
    }

    SelectObjectDefinition(objectDefID: string) {
        if (this.Model.RadiologyWorkListItems != null)
        {
            let episodeActionWorkListItem = this.Model.RadiologyWorkListItems.find(o => o.ObjectDefID === objectDefID);
            if (episodeActionWorkListItem) {
                if (!this.SelectedRadiologyWorkListItems)
                    this.SelectedRadiologyWorkListItems = new Array<RadiologyWorkListItem>();
                this.SelectedRadiologyWorkListItems.push(episodeActionWorkListItem);
            }
        }
    }

    SelectState(stateDefID: string) {
        let episodeActionWorkListStateItem = this.Model.RadiologyWorkListStateItems.find(s => s.StateDefID === stateDefID);
        if (episodeActionWorkListStateItem) {
            if (!this.SelectedRadiologyWorkListStateItems)
                this.SelectedRadiologyWorkListStateItems = new Array<RadiologyWorkListStateItem>();
            this.SelectedRadiologyWorkListStateItems.push(episodeActionWorkListStateItem);
        }
    }

    async SelectUserResource(resourceID: string) {
        let userResourceItem = this.Model.UserResourceItems.find(s => s.ResourceID === resourceID);
        if (userResourceItem) {
            if (!this.Model.SelectedUserResourceItems)
                this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
            this.Model.SelectedUserResourceItems.push(userResourceItem);
        }
    }
    async stateTypeSelectionChanged() {
        this.Model.SelectedStateTypesEM = new Array<string>();
        for (let stateType of this.Model.SelectedStateTypes) {
            if (stateType === "SUCCESSFUL")
                this.Model.SelectedStateTypesEM.push("COMPLETEDSUCCESSFULLY");
            else if (stateType === "UNSUCCESSFUL")
                this.Model.SelectedStateTypesEM.push("COMPLETEDUNSUCCESSFULLY");
            else
                this.Model.SelectedStateTypesEM.push(stateType);
        }
    }
    rowPrepared(row: any) {
        if (row.rowType == "data") {
            if (row.data.RowColor != null && row.data.RowColor != "") {
                 this.renderer.setStyle(row.rowElement.firstItem(), "background-color", row.data.RowColor);
             }
        }
    }


    public initFormControls(): void {

        this.btnSpecialPanelKaydet = new TTVisual.TTButton();
        this.btnSpecialPanelKaydet.Text = i18n("M17386", "Kaydet");
        this.btnSpecialPanelKaydet.Name = "btnSpecialPanelKaydet";
        this.btnSpecialPanelKaydet.TabIndex = 12;

        this.btnSpecialPanelSil = new TTVisual.TTButton();
        this.btnSpecialPanelSil.Text = "Sil";
        this.btnSpecialPanelSil.Name = "btnSpecialPanelSil";
        this.btnSpecialPanelSil.TabIndex = 12;

        this.btnListele = new TTVisual.TTButton();
        this.btnListele.Text = "Listele";
        this.btnListele.Name = "btnListele";
        this.btnListele.TabIndex = 12;

        this.PatientStatus = new TTVisual.TTEnumComboBox();
        this.PatientStatus.DataTypeName = "PatientStatusEnum";
        this.PatientStatus.Name = "PatientStatus";
        this.PatientStatus.TabIndex = 13;

        this.chkOutPatient = new TTVisual.TTCheckBox();
        this.chkOutPatient.Value = true;
        this.chkOutPatient.Text = i18n("M11281", "Ayaktan");
        this.chkOutPatient.Name = "chkOutPatient";
        this.chkOutPatient.TabIndex = 10;

        this.chkInPatient = new TTVisual.TTCheckBox();
        this.chkInPatient.Value = true;
        this.chkInPatient.Text = i18n("M24377", "Yatan");
        this.chkInPatient.Name = "chkInPatient";
        this.chkInPatient.TabIndex = 10;

        this.txtSEProtocolNo = new TTVisual.TTTextBox();
        this.txtSEProtocolNo.Text = "";
        this.txtSEProtocolNo.Name = "txtSEProtocolNo";
        this.txtSEProtocolNo.TabIndex = 10;
    }

    returnTemplateText(data) {
        return i18n("M18284", "Listelenen İşlem Sayısı:") + data.value;
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let radiologyStatisticReport = new DynamicSidebarMenuItem();
        radiologyStatisticReport.key = 'radiologyStatisticReport';
        radiologyStatisticReport.icon = 'fa fa-file-text-o';
        radiologyStatisticReport.label = "Radyoloji İstatistik Raporu";
        radiologyStatisticReport.componentInstance = this;
        radiologyStatisticReport.clickFunction = this.openRadiologyStatisticReportForm;
        radiologyStatisticReport.parameterFunctionInstance = this;
        radiologyStatisticReport.getParamsFunction = null;
        radiologyStatisticReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', radiologyStatisticReport);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('radiologyStatisticReport');

    }
    _showStaticticReport: boolean = false;
    _requestStartDate: Date = new Date();
    _requestEndDate: Date = new Date();
    _reportStartDate: Date = new Date();
    _reportEndDate: Date = new Date();
    _testType: RadiologyStatisticBaseObject = new RadiologyStatisticBaseObject();
    _radiologytest: RadiologyStatisticBaseObject = new RadiologyStatisticBaseObject();
    _gender: RadiologyStatisticBaseObject = new RadiologyStatisticBaseObject();
    _payer: RadiologyStatisticBaseObject = new RadiologyStatisticBaseObject();
    _resource: RadiologyStatisticBaseObject = new RadiologyStatisticBaseObject();
    _equipment: RadiologyStatisticBaseObject = new RadiologyStatisticBaseObject();
    _procedureDoctor: RadiologyStatisticBaseObject = new RadiologyStatisticBaseObject();
    _hasAppointment: boolean = false;
    _minAge: any;
    _maxAge: any;
    radiologyStatisticReportViewModel: RadiologyStatisticReportViewModel = new RadiologyStatisticReportViewModel();

    openRadiologyStatisticReportForm() {

        let that = this;
        let fullApiUrl: string = "/api/RadiologyWorkListService/LoadRadiologyStatisticReportViewModel";
        this.httpService.get<RadiologyStatisticReportViewModel>(fullApiUrl)
            .then(response => {
                that.radiologyStatisticReportViewModel = response as RadiologyStatisticReportViewModel;
                this._showStaticticReport = true;
            })
            .catch(error => {
                console.log(error);
            });
    }

    CancelRadiologyStatisticReport() {
        this._showStaticticReport = false;
    }

    PrintRadiologyStatisticReport() {
        let reportData: DynamicReportParameters = {

            Code: 'RADYOLOJIISTATISTIKRAPORU',
            ReportParams: {
                RequestStartDate: this._requestStartDate, RequestEndDate: this._requestEndDate, ReportStartDate: this._reportStartDate, ReportEndDate: this._reportEndDate, TestType: this._testType, RadiologyTestDefObjectID: this._radiologytest, Gender: this._gender,
                Payer: this._payer, ResourceObjectID: this._resource, Equipment: this._equipment, ProcedureDoctor: this._procedureDoctor, HasAppointment: this._hasAppointment, MinAge: this._minAge, MaxAge: this._maxAge
            },
            ViewerMode: true

        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "RADYOLOJI İSTATİSTİK RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    TestTypeChanged(data ) {
        let that = this;
    
  
        let fullApiUrl: string = "/api/RadiologyWorkListService/GetRadiologyTestDefinitionByTestType?TestTypeObjectID="+data.value;
        let input = { "TestTypeObjectID": data.value };

        this.httpService.get<Array<RadiologyStatisticBaseObject>>(fullApiUrl)
            .then(response => {
                that.radiologyStatisticReportViewModel.RadiologyTestList = response as Array<RadiologyStatisticBaseObject>;


            })
            .catch(error => {
                console.log(error);
            });


        //that.SelectedClinicID = clinic.ObjectID;
    }

   


}

export class ExaminationQueueDefinitionParamClass {
    public selectedQueue: ExaminationQueueDefinition;
    public outResourceId: Guid;
    public currentResourceId: Guid;
}
export class GetSortedQueueItemsByArray_Input {
    public outPatientResID: Guid;
    public currentResUserID: Guid;
    public includeCalleds: boolean;
}

export class CallNexttPatientParam {
    public ObjectId: Guid;
    public outPatientResID: Guid;
    public OrderNo: number;
}