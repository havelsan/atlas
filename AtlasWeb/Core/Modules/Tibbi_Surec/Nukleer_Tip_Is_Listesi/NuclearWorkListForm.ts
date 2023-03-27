//$5932D9FE
import { Component, ViewChild, Output, EventEmitter, Renderer2 } from '@angular/core';
import { Headers, RequestOptions } from "@angular/http";
import { NuclearWorkListFormViewModel, QueryInputDVO, NuclearWorkListItem, NuclearWorkListStateItem, MenuOutputDVO, StateOutputDVO, UserResourceOutputDVO, NuclearWorkListItemModel, DynamicComponentInfoDVO, SpecialPanelOutputDVO, SpecialPanelInputDVO, SpecialPanelListItem, UserResourceItem, ActiveInfoDVO, EquipmentItem, NuclearEquipmentOutputDVO  } from "./NuclearWorkListFormViewModel";
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
import { Subscription } from 'rxjs';
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: "hvl-nuclear-worklist-view",
    inputs: ['Model'],
    templateUrl: './NuclearWorkListForm.html',
    providers: [SystemApiService],
})
export class NuclearWorkListForm extends  BaseComponent< NuclearWorkListFormViewModel >{


    btnListele: TTVisual.ITTButton;
    btnSpecialPanelKaydet: TTVisual.ITTButton;
    btnSpecialPanelSil: TTVisual.ITTButton;
    PatientStatus: TTVisual.ITTEnumComboBox;
    chkOutPatient: TTVisual.ITTCheckBox;
    chkInPatient: TTVisual.ITTCheckBox;
    private _selectedObjectDefName: string;
    private _specialPanelListItems: Array<SpecialPanelListItem>;
    @Output() OnObjectSelected: EventEmitter<Guid> = new EventEmitter<Guid>();
    public selectedNuclearId: string;

    NuclearTestList: Array<NuclearWorkListItemModel>;
    public menuList: Array<MenuDefinition>;
    public stateList: Array<TTObjectStateDef>;
    public searchMenuTxt: string;
    public componentInfo: DynamicComponentInfo;
    public componentPatientInfo: DynamicComponentInfo;
    public selectedAccordionItem: any;
    public NuclearWorkListItems: Array<NuclearWorkListItem>;
    public NuclearWorkListStateItems: Array<NuclearWorkListStateItem>;
    public SelectedNuclearWorkListItems: Array<NuclearWorkListItem>;
    public SelectedNuclearWorkListStateItems: Array<NuclearWorkListStateItem>;
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
            dataType: 'string',
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
            dataField: "NuclearTestName",
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

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';


    private episodeActionWorkListSubscription: Subscription;
    private refreshEpisodeActionSubscription: Subscription;

    openSpecialList() {
        this.autoCompleteInstance.instance.open();
    }

    constructor(container: ServiceContainer, private httpService: NeHttpService, public systemApiService: SystemApiService, private activeUserService: IActiveUserService, private renderer: Renderer2) {
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
        this.Model = new NuclearWorkListFormViewModel();
        this.Model.txtPatient = "";
        this.Model.NuclearWorkListItems = new Array<NuclearWorkListItem>();
        this.Model.NuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
        this.Model.SelectedNuclearWorkListItems = new Array<NuclearWorkListItem>();
        this.Model.SelectedNuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
        this.Model.SelectedStateTypes = new Array<string>();
        this.Model.SelectedStateTypesEM = new Array<string>();
        this.Model.UserResourceItems = new Array<UserResourceItem>();
        this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
        this.Model.NuclearEquipmentItems = new Array<EquipmentItem>();
        this.Model.SelectedNuclearEquipmentItems = new Array<EquipmentItem>();
        this.Model.StateType = "UNCOMPLETED";
        this.Model.SelectedStateTypes.push("UNCOMPLETED");
        this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
        this.Model.PatientStatus = "0";
        this.Model.WorkListCount = 20;
    }

    async ngOnInit() {
        await this.getNuclearEquipmentList();
        await this.getUserResourceList();
        await this.getMenuList();
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

        this.loadNuclearWorklistPanelOperation(true, i18n("M15370", "Hastalar listeleniyor, lütfen bekleyiniz."));
        this.doSearch();
        //this.filteraccordion.instance.collapseItem(0);
    }

    loadNuclearWorklistPanelOperation(visible: boolean, message: string): void {
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
            specialPanelInputDVO.SelectedWorkListItems = this.Model.SelectedNuclearWorkListItems;
            specialPanelInputDVO.SelectedWorkListStateItems = this.SelectedNuclearWorkListStateItems;
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
            specialPanelInputDVO.SelectedWorkListItems = this.Model.SelectedNuclearWorkListItems;
            specialPanelInputDVO.SelectedWorkListStateItems = this.SelectedNuclearWorkListStateItems;
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
        return "col-md-3";

    }
    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-9";

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
        inputDvo.SelectedWorkListItems = this.Model.SelectedNuclearWorkListItems;
        inputDvo.SelectedWorkListStateItems = this.SelectedNuclearWorkListStateItems;
        inputDvo.WorkListItems = this.Model.NuclearWorkListItems;
        inputDvo.WorkListStateItems = this.Model.NuclearWorkListStateItemsAll;
        inputDvo.SelectedStateTypes = this.Model.SelectedStateTypes;
        inputDvo.SelectedStateTypesEM = this.Model.SelectedStateTypesEM;
        inputDvo.UserResourceItems = this.Model.UserResourceItems;
        inputDvo.SelectedUserResourceItems = this.Model.SelectedUserResourceItems;
        inputDvo.NuclearEquipmentItems = this.Model.NuclearEquipmentItems;
        inputDvo.SelectedNuclearEquipmentItems = this.Model.SelectedNuclearEquipmentItems;
        inputDvo.activeResUserObjectID = this.activeResUserObjectID;
        //inputDvo.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;
        inputDvo.SelectedQueueObjectID = this.activeUserService.SelectedQueue.ObjectID;


        let that = this;
        let fullApiUrl: string = "api/NuclearWorkListService/QueryNuclearWorkList";

        let result = await this.httpService.post<NuclearWorkListFormViewModel>(fullApiUrl, inputDvo, NuclearWorkListFormViewModel);
        this.Model.NuclearList = result.NuclearList;
        this.Model.txtPatient = result.txtPatient;
        this.Model.StartDate = result.StartDate;
        this.Model.EndDate = result.EndDate;
        this.Model.ID = result.ID;
        this.Model.WorkListCount = result.WorkListCount;
        this.Model.StateType = result.StateType;
        this.Model.SelectedStateTypes = result.SelectedStateTypes;
        this.Model.SelectedStateTypesEM = result.SelectedStateTypesEM;
        this.Model.PatientStatus = result.PatientStatus;

        this.loadNuclearWorklistPanelOperation(false, '');
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
        await this.httpService.get<UserResourceOutputDVO>("api/EpisodeActionWorkListService/GetUserResources").then(response => {
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

    async getNuclearEquipmentList() {
        let that = this;
        await this.httpService.get<NuclearEquipmentOutputDVO>("api/NuclearWorkListService/GetNuclearEquipment").then(response => {
            let output = <NuclearEquipmentOutputDVO>response;
            if (output) {
                that.Model.NuclearEquipmentItems = output.EquipmentItemList;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }
    async getMenuList() {
        let that = this;
        let fullApiUrl: string = "api/NuclearWorkListService/GetEpisodeActionMenuDefinition";
        let result = await this.httpService.get<MenuOutputDVO>(fullApiUrl, MenuOutputDVO);

        this.NuclearWorkListItems = result.WorkListSearchItem;
        that.Model.NuclearWorkListStateItemsAll = result.WorkListSearchStateItem;
        this.Model.NuclearWorkListItems = result.WorkListSearchItem;
        this.Model.SelectedNuclearWorkListItems = result.WorkListSearchItem;
    }

    async getStateList2(value: any) {
        let that = this;
        let fullApiUrl: string = "api/NuclearWorkListService/GetEpisodeActionStateDefinition";
        let result = await this.httpService.post<StateOutputDVO>(fullApiUrl, value, StateOutputDVO);

        this.NuclearWorkListStateItems = result.WorkListSearchStateItem;
        this.Model.NuclearWorkListStateItems = result.WorkListSearchStateItem;
        this.Model.SelectedNuclearWorkListStateItems = result.WorkListSearchStateItem;

    }

    async getStateList(value: any) {
        let that = this;
        let fullApiUrl: string = "api/NuclearWorkListService/GetEpisodeActionStateDefinition";
        let result = await this.httpService.post<StateOutputDVO>(fullApiUrl, value, StateOutputDVO);

        that.NuclearWorkListStateItems = result.WorkListSearchStateItem;
        that.Model.SelectedNuclearWorkListStateItems = result.WorkListSearchStateItem;
        that.Model.NuclearWorkListStateItems = result.WorkListSearchStateItem;

    }

    async select(value: any): Promise<void> {

        let _data: NuclearWorkListItemModel = value.selectedRowsData[0] as NuclearWorkListItemModel;
        this.openDynamicComponent(_data.ObjectDefName, _data.ObjectID);


    }

    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam);
            this.selectedNuclearId = objectID;
        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
            });
        }
    }

    async selectIfSingleNuclear(): Promise<void> {
        if (this.Model.NuclearList != null && this.Model.NuclearList.length > 0) {
            this.systemApiService.open(this.Model.NuclearList[0].ObjectID, this.Model.NuclearList[0].ObjectDefName);
            this.selectedNuclearId = this.Model.NuclearList[0].ObjectID;

            let fullApiUrl: string = "api/NuclearWorkListService/GetDynamicComponentPatientInfo?ObjectId=" + this.selectedNuclearId;
            let result = await this.httpService.get<DynamicComponentInfoDVO>(fullApiUrl, DynamicComponentInfoDVO);

            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = result.ComponentName;
            compInfo.ModuleName = result.ModuleName;
            compInfo.ModulePath = result.ModulePath;
            compInfo.objectID = result.objectID;
            this.componentPatientInfo = compInfo;
        }
    }

    async NuclearWorkListItemsSelectionChanged(values: any) {
        this.Model.SelectedNuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
        //if(this.Model.SelectedEpisodeActionWorkListItems != null && this.Model.SelectedEpisodeActionWorkListItems.length == 1)
        //console.log(values);
        if (values) {
            if (values.length > 0) {
                let _episodeActionWorkListItems: Array<NuclearWorkListItem> = new Array<NuclearWorkListItem>();
                for (let item of values) {
                    let _episodeActionWorkListItem: NuclearWorkListItem = new NuclearWorkListItem();
                    _episodeActionWorkListItem = item; //values[0];
                    _episodeActionWorkListItems.push(_episodeActionWorkListItem);
                }
                await this.getStateList2(_episodeActionWorkListItems);
            }
            // this.SelectedEpisodeActionWorkListItems = values;
            this.Model.SelectedNuclearWorkListItems = values;
        }
        else {
            //console.log(values);
            this.NuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
            this.Model.SelectedNuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
        }
    }

    async NuclearWorkListStateItemsSelectionChanged(values: any) {
        if (this.Model.SelectedNuclearWorkListStateItems && this.Model.SelectedNuclearWorkListStateItems.length > 0) {
            this.Model.SelectedStateTypes = new Array<string>();
            this.Model.SelectedStateTypesEM = new Array<string>();
        }
        else {
            if (this.Model.txtPatient == null || this.Model.txtPatient == "") {
                this.Model.SelectedStateTypes.push("UNCOMPLETED");
                this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
            }
        }
        //if (values)
        //    this.Model.SelectedNuclearWorkListStateItems = values;
        //else
        //    this.Model.SelectedNuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
    }

    patientChanged(patient: any) {
        let sysDate: Date = new Date(Date.now());
        if (patient) {
            this.Model.txtPatient = patient.ObjectID;
            this.Model.SelectedStateTypes = new Array<string>();
            this.Model.SelectedStateTypesEM = new Array<string>();
            this.Model.SelectedNuclearWorkListItems = new Array<NuclearWorkListItem>();
            this.Model.SelectedNuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
            this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.Model.StartDate = new Date(this.Model.EndDate.AddMonths(-6).toString());
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = true;
        }
        else {
            this.Model.txtPatient = "";
            this.Model.SelectedStateTypes.push("UNCOMPLETED");
            this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
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
        this.selectedNuclearId = "";
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
            this.SelectedNuclearWorkListItems = new Array<NuclearWorkListItem>();
            this.SelectedNuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
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
                this.Model.SelectedNuclearWorkListItems = this.SelectedNuclearWorkListItems;
                if (this.Model.SelectedNuclearWorkListItems.length > 0) {

                    await this.getStateList(this.Model.SelectedNuclearWorkListItems); //.then(() => {
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
                    this.Model.SelectedNuclearWorkListStateItems = this.SelectedNuclearWorkListStateItems;
                }
                else {
                    this.NuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
                    this.Model.SelectedNuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
                }
                this.doSearch();
            }
        }
    }

    SelectObjectDefinition(objectDefID: string) {
        if (this.Model.NuclearWorkListItems != null)
        {
            let episodeActionWorkListItem = this.Model.NuclearWorkListItems.find(o => o.ObjectDefID === objectDefID);
            if (episodeActionWorkListItem) {
                if (!this.SelectedNuclearWorkListItems)
                    this.SelectedNuclearWorkListItems = new Array<NuclearWorkListItem>();
                this.SelectedNuclearWorkListItems.push(episodeActionWorkListItem);
            }
        }
    }

    SelectState(stateDefID: string) {
        let episodeActionWorkListStateItem = this.Model.NuclearWorkListStateItems.find(s => s.StateDefID === stateDefID);
        if (episodeActionWorkListStateItem) {
            if (!this.SelectedNuclearWorkListStateItems)
                this.SelectedNuclearWorkListStateItems = new Array<NuclearWorkListStateItem>();
            this.SelectedNuclearWorkListStateItems.push(episodeActionWorkListStateItem);
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
    }

    returnTemplateText(data) {
        return i18n("M18284", "Listelenen İşlem Sayısı:") + data.value;
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