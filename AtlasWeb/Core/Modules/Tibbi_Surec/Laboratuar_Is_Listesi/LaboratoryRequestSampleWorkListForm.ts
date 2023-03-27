//$C95296E8
import { Component, ViewChild, Output, EventEmitter } from '@angular/core';
import { Headers, RequestOptions } from "@angular/http";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DxAccordionComponent, DxAutocompleteComponent } from "devextreme-angular";
import { MenuDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTListDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTListDef';
import { TTObjectStateDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";

import { LaboratoryWorkListFormViewModel, QueryInputDVO, LaboratoryWorkListItem, LaboratoryWorkListStateItem, MenuOutputDVO, StateOutputDVO, LaboratoryWorkListItemMasterModel, LaboratoryWorkListItemDetailModel, SpecialPanelOutputDVO, SpecialPanelInputDVO, SpecialPanelListItem, QueryInputDVOByEpisode, UserResourceItem, UserResourceOutputDVO } from "./LaboratoryWorkListFormViewModel";
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { DxDataGridComponent } from 'devextreme-angular';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';

@Component({
    selector: "hvl-laboratory-requestsample-worklist-view",
    inputs: ['Model'],
    templateUrl: './LaboratoryRequestSampleWorkListForm.html',
    providers: [SystemApiService],
})
export class LaboratoryRequestSampleWorkListForm extends BaseComponent<LaboratoryWorkListFormViewModel>{

    @ViewChild('worklistDataGrid') worklistDataGrid: DxDataGridComponent;

    btnListele: TTVisual.ITTButton;
    btnSpecialPanelKaydet: TTVisual.ITTButton;
    btnSpecialPanelSil: TTVisual.ITTButton;
    PatientStatus: TTVisual.ITTEnumComboBox;
    chkOutPatient: TTVisual.ITTCheckBox;
    chkInPatient: TTVisual.ITTCheckBox;
    chkSampleAccept: TTVisual.ITTCheckBox;
    chkSampleTaking: TTVisual.ITTCheckBox;
    txtSEProtocolNo: TTVisual.ITTTextBox;
    private _selectedObjectDefName: string;
    private _specialPanelListItems: Array<SpecialPanelListItem>;
    //@ViewChild('examinationPanel') examinationPanel: HTMLDivElement;
    @Output() OnObjectSelected: EventEmitter<LaboratoryWorkListItemMasterModel> = new EventEmitter<LaboratoryWorkListItemMasterModel>();
    @Output() OnObjectSelected2: EventEmitter<QueryInputDVOByEpisode> = new EventEmitter<QueryInputDVOByEpisode>();
    @Output() OnListBtnClick: EventEmitter<boolean> = new EventEmitter<boolean>();
    public selectedLaboratoryId: string;

    LaboratoryTestList: Array<LaboratoryWorkListItemDetailModel>;
    public menuList: Array<MenuDefinition>;
    public stateList: Array<TTObjectStateDef>;
    public searchMenuTxt: string;
    public componentInfo: DynamicComponentInfo;
    public componentPatientInfo: DynamicComponentInfo;
    public selectedAccordionItem: any;
    public LaboratoryWorkListItems: Array<LaboratoryWorkListItem>;
    public LaboratoryWorkListStateItems: Array<LaboratoryWorkListStateItem>;
    public SelectedLaboratoryWorkListItems: Array<LaboratoryWorkListItem>;
    public SelectedLaboratoryWorkListStateItems: Array<LaboratoryWorkListStateItem>;
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

        //{
        //    caption: "Sıra No",
        //    dataField: "AdmissionQueueNumber",
        //    width: "auto",
        //    allowSorting: true
        //},
        {
            "caption": i18n("M15318", "Hasta TCNo"),
            dataField: "PatientTCNo",
            width: "auto",
            allowSorting: true
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
            "caption": i18n("M16697", "İsteyen Klinik"),
            dataField: "FromResourceName",
            dataType: 'string',
            width: 150,
            allowSorting: true,
        }
    ];

    @ViewChild('menuAccordion') accordion: DxAccordionComponent;
    @ViewChild(DxAutocompleteComponent) autoComplete: DxAutocompleteComponent;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    openSpecialList() {
        this.autoComplete.instance.open();
    }

    constructor(container: ServiceContainer, private httpService: NeHttpService, public systemApiService: SystemApiService, private activeUserService: IActiveUserService) {
        super(container);
        this.initFormControls();
        this.SpecialPanelListItems = new Array<SpecialPanelListItem>();
        this.activeResUserObjectID = activeUserService.ActiveUser.UserObject.ObjectID.toString();
    }

    async clientPreScript() {
        this.Model = new LaboratoryWorkListFormViewModel();
        this.Model.txtPatient = "";
        this.Model.LaboratoryWorkListItems = new Array<LaboratoryWorkListItem>();
        this.Model.LaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
        this.Model.StateType = "UNCOMPLETED";
        this.Model.PatientStatus = "0"; // SubEpisodeStatusEnum
        this.Model.WorkListCount = 20;
        this.Model.UserResourceItems = new Array<UserResourceItem>();
        this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
        this.Model.SelectedLaboratoryWorkListItems = new Array<LaboratoryWorkListItem>();

        //Default Tarih Aralığı sadece son 10 gün olacak şekilde değişiklik oldu. 
        let today = new Date(Date.now());
        this.Model.StartDate = today.AddDays(-10);
        this.Model.EndDate = today;

        let resourceList = await this.getUserResourceList();

        //Laboratuvar Is Lıstesınde tum menuyu almaya gerek yok. Sadece LaboratoryProcedure objectdef ı yuklense yeterlı.
        //let menuList = await this.getMenuList();
        let laboratoryWorkListItem: LaboratoryWorkListItem = new LaboratoryWorkListItem();
        laboratoryWorkListItem.ObjectDefName = "LaboratoryProcedure";
        laboratoryWorkListItem.ObjectDefID = "f87eac33-a91e-4934-a010-edf6029d2d18";
        this.Model.SelectedLaboratoryWorkListItems.push(laboratoryWorkListItem);
        this.Model.LaboratoryWorkListItems.push(laboratoryWorkListItem);

        let specialPanelList = await this.getSpecialPanelList();
        if (this.LastSelectedSpecialPanel) {
            this.loadSpecialCriteria(this.LastSelectedSpecialPanel);
        }
        this.systemParameterOnSearchingOperation = (await SystemParameterService.GetParameterValue("LABSAMPLEACCEPTLISTFORCEPATIENTSEARCH", "FALSE"));
        if(this.systemParameterOnSearchingOperation == "FALSE")
            this.btnSearchDisabled = false;             
    }

    clientPostScript(state: String) {

    }

    btnListele_Click() {
        this.OnListBtnClick.emit(true);
        this.loadLabRequestSampleWorklistPanelOperation(true, i18n("M15370", "Hastalar listeleniyor, lütfen bekleyiniz."));
        this.doSearch().then(() => {
            this.selectIfSingleLaboratory();
            this.loadLabRequestSampleWorklistPanelOperation(false, '');
        });
    }

    async userResourceItemsSelectionChanged() {

    }

    loadLabRequestSampleWorklistPanelOperation(visible: boolean, message: string): void {
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
            specialPanelInputDVO.SelectedWorkListItems = this.Model.SelectedLaboratoryWorkListItems;
            specialPanelInputDVO.SelectedWorkListStateItems = this.Model.SelectedLaboratoryWorkListStateItems;
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
            specialPanelInputDVO.SelectedWorkListItems = this.Model.SelectedLaboratoryWorkListItems;
            specialPanelInputDVO.SelectedWorkListStateItems = this.Model.SelectedLaboratoryWorkListStateItems;
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

    //Seçilen hastayı çağırmak için right click
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
        let currentLocation = window.location.href.replace("/islistesi", "");
        audio.src = currentLocation + "/Content/doorbell.wav";
        audio.load();
        audio.play();

        let attt: CallNexttPatientParam = new CallNexttPatientParam();
        attt.ObjectId = data.LabRequestObjectID;
        let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
        attt.outPatientResID = new Guid(outPatientResID);
        attt.OrderNo = 0;
        let apiUrl: string = '/api/CommonService/CallSelectedPatient';
        this.httpService.post<any>(apiUrl, attt).then(
            x => {
            }
        );

    }

    queueList: Array<ExaminationQueueDefinition> = new Array<ExaminationQueueDefinition>();
    public async getQueueList(): Promise<any> {
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
        return "col-md-3 col-sm-4";

    }
    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-9 col-sm-8";

    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }

    async setSelectedUserResourceList() {
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

    async doSearch(): Promise<void> {
        if (!this.activeUserService.SelectedOutPatientResource && !this.activeUserService.SelectedInPatientResource) {
            await CommonService.openUserResourceSelectionView();
            await this.setSelectedUserResourceList();
        }

        let inputDvo = new QueryInputDVO();
        inputDvo.txtPatient = this.Model.txtPatient;
        inputDvo.txtSEProtocolNo = this.txtSEProtocolNo.Text;
        inputDvo.StartDate = this.Model.StartDate;
        inputDvo.EndDate = this.Model.EndDate;
        inputDvo.ID = this.Model.ID;
        inputDvo.WorkListCount = this.Model.WorkListCount;
        inputDvo.StateType = this.Model.StateType;
        inputDvo.PatientStatus = "";
        if (this.chkOutPatient.Value == true && this.chkInPatient.Value == true)
            this.Model.PatientStatus = "0,1,3";
        else if (this.chkOutPatient.Value == true)
            this.Model.PatientStatus = "0,3"; //Ayaktan, Günübirlik
        else if (this.chkInPatient.Value == true)
            this.Model.PatientStatus = "1"; // Yatan
        inputDvo.PatientStatus = this.Model.PatientStatus;
        inputDvo.activeResUserObjectID = this.activeResUserObjectID;

        inputDvo.SelectedWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
        let stateItem: LaboratoryWorkListStateItem;

        if (this.chkSampleAccept.Value == true) {
            stateItem = new LaboratoryWorkListStateItem();
            stateItem.StateDefID = "5eaf4c46-c99e-491c-a880-37d07484437e";
            inputDvo.SelectedWorkListStateItems.push(stateItem);
            //this.chkSampleTaking.Value = false;
        }
        if (this.chkSampleTaking.Value == true) {
            stateItem = new LaboratoryWorkListStateItem();
            stateItem.StateDefID = "5b6b040c-cea8-4d4f-96d7-f394c9b28f87";
            inputDvo.SelectedWorkListStateItems.push(stateItem);
            //this.chkSampleAccept.Value = false;

        }

        inputDvo.UserResourceItems = this.Model.UserResourceItems;
        inputDvo.SelectedUserResourceItems = this.Model.SelectedUserResourceItems;
        if (this.activeUserService.SelectedQueue !== undefined)
            inputDvo.SelectedQueueObjectID = this.activeUserService.SelectedQueue.ObjectID;



        //inputDvo.SelectedWorkListItems = this.Model.SelectedLaboratoryWorkListItems;
        //inputDvo.SelectedWorkListStateItems = this.Model.SelectedLaboratoryWorkListStateItems;
        //inputDvo.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;

        let that = this;
        let fullApiUrl: string = "api/LaboratoryWorkListService/QueryLaboratorySampleAcceptListGroupByPatient"; //QueryLaboratorySampleAcceptList";

        let result = await this.httpService.post<LaboratoryWorkListFormViewModel>(fullApiUrl, inputDvo, LaboratoryWorkListFormViewModel);
        this.Model.LaboratoryProcedureMasterList = result.LaboratoryProcedureMasterList;
        this.Model.txtPatient = result.txtPatient;
        this.Model.StartDate = result.StartDate;
        this.Model.EndDate = result.EndDate;
        this.Model.EpisodeID = result.EpisodeID;
        this.Model.WorkListCount = result.WorkListCount;
        this.Model.StateType = result.StateType;
        this.Model.PatientStatus = result.PatientStatus;

        this.loadLabRequestSampleWorklistPanelOperation(false, '');

    }

    public onchkSampleTakingChanged(event): void {
        this.chkSampleTaking.Value = event;
        if (event == true)
            this.chkSampleAccept.Value = false;

        this.Model.SelectedLaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
        let stateItem: LaboratoryWorkListStateItem;
        stateItem = new LaboratoryWorkListStateItem();
        stateItem.StateDefID = "5b6b040c-cea8-4d4f-96d7-f394c9b28f87";
        this.Model.SelectedLaboratoryWorkListStateItems.push(stateItem);
        
        this.btnSearchDisabled = false;
    }

    public btnSearchDisabled: boolean = true;
    public systemParameterOnSearchingOperation: String = "TRUE";
    public onchkOutPatientChanged(event): void {
        this.chkOutPatient.Value = event;
        if (event == true) {
            this.chkInPatient.Value = false;
        }
        if (this.chkSampleAccept.Value && this.chkOutPatient.Value && this.systemParameterOnSearchingOperation == "TRUE") {
            this.btnSearchDisabled = true;
        }
    }

    public onchkInPatientChanged(event): void {
        this.chkInPatient.Value = event;
        if (event == true) {
            this.chkOutPatient.Value = false;
        }
        this.btnSearchDisabled = false;
    }

    public onchkSampleAcceptChanged(event): void {
        this.chkSampleAccept.Value = event;
        if (event == true) {
            this.chkSampleTaking.Value = false;
        }
        if (this.chkSampleAccept.Value && this.chkOutPatient.Value && this.systemParameterOnSearchingOperation == "TRUE") {
            this.btnSearchDisabled = true;
        }
        this.Model.SelectedLaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
        let stateItem: LaboratoryWorkListStateItem;
        stateItem = new LaboratoryWorkListStateItem();
        stateItem.StateDefID = "5eaf4c46-c99e-491c-a880-37d07484437e";
        this.Model.SelectedLaboratoryWorkListStateItems.push(stateItem);
    }

    async getMenuList() {
        let that = this;
        let fullApiUrl: string = "api/EpisodeActionWorkListService/GetEpisodeActionMenuDefinition";
        let result = await this.httpService.get<MenuOutputDVO>(fullApiUrl, MenuOutputDVO);

        this.LaboratoryWorkListItems = result.WorkListSearchItem;
        this.Model.LaboratoryWorkListItems = result.WorkListSearchItem;
        this.Model.SelectedLaboratoryWorkListItems = result.WorkListSearchItem;
    }

    async getStateList2(value: any) {
        let that = this;
        let fullApiUrl: string = "api/EpisodeActionWorkListService/GetEpisodeActionStateDefinition";
        let result = await this.httpService.post<StateOutputDVO>(fullApiUrl, value, StateOutputDVO);

        this.LaboratoryWorkListStateItems = result.WorkListSearchStateItem;
        this.Model.LaboratoryWorkListStateItems = result.WorkListSearchStateItem;
        this.Model.SelectedLaboratoryWorkListStateItems = result.WorkListSearchStateItem;

    }

    async OpenLcdMonitor() {
        if (!this.activeUserService.SelectedQueue)
            await this.getQueueList();
        if (this.activeUserService.SelectedQueue == undefined && this.queueList.length == 0) {
            await CommonService.openUserResourceSelectionView();
        }
        let names: any = this.activeUserService.ActiveUser.UserObject;
        let doktorName = names.Name.toString();
        let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
        let currentLocation = window.location.href.replace("/laboratuvar/numunealma", "");
        let url = currentLocation + "/PatientCaller/HastaCagriForm2?currentResUserID=00000000-0000-0000-0000-000000000000&outPatientResID=" + outPatientResID + "&includeCalleds=false&doktorName=" + "";
        let input: any = { Url: encodeURI(url) };
        let httpPrintServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
        this.httpService.post(httpPrintServiceUrl, input);
        sessionStorage.setItem('isLCDOpened', 'true');
        //this.openInNewTab(currentLocation + "/PatientCaller/HastaCagriForm2?currentResUserID=00000000-0000-0000-0000-000000000000&outPatientResID=" + outPatientResID + "&includeCalleds=false&doktorName=" + doktorName);
    }

    async getStateList(value: any) {
        let that = this;
        let fullApiUrl: string = "api/EpisodeActionWorkListService/GetEpisodeActionStateDefinition";

        let result = await this.httpService.post<StateOutputDVO>(fullApiUrl, value, StateOutputDVO);
        that.LaboratoryWorkListStateItems = result.WorkListSearchStateItem;
        that.Model.SelectedLaboratoryWorkListStateItems = result.WorkListSearchStateItem;
        that.Model.LaboratoryWorkListStateItems = result.WorkListSearchStateItem;
    }


    async workListItemSelect(value: any): Promise<void> {

        this.loadLabRequestSampleWorklistPanelOperation(true, 'Hasta yükleniyor, lütfen bekleyiniz.');
        try {
            if (value.selectedRowsData.length > 0) {
                this.currentSelectedRowKeys = value.currentSelectedRowKeys;

                let _data: LaboratoryWorkListItemMasterModel = value.selectedRowsData[0] as LaboratoryWorkListItemMasterModel;

                let queryDVO: QueryInputDVOByEpisode = new QueryInputDVOByEpisode();
                queryDVO.EpisodeID = _data.EpisodeID;
                queryDVO.StartDate = this.Model.StartDate;
                queryDVO.EndDate = this.Model.EndDate;
                queryDVO.PatientStatus = this.Model.PatientStatus;
                queryDVO.SelectedWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
                queryDVO.LabRequestObjectID = _data.LabRequestObjectID;
                queryDVO.PatientObjectID = _data.PatientObjectID;

                let stateItem: LaboratoryWorkListStateItem;
                if (this.chkSampleAccept.Value == true) {
                    stateItem = new LaboratoryWorkListStateItem();
                    stateItem.StateDefID = "5eaf4c46-c99e-491c-a880-37d07484437e";
                    queryDVO.SelectedWorkListStateItems.push(stateItem);
                }
                if (this.chkSampleTaking.Value == true) {
                    stateItem = new LaboratoryWorkListStateItem();
                    stateItem.StateDefID = "5b6b040c-cea8-4d4f-96d7-f394c9b28f87";
                    queryDVO.SelectedWorkListStateItems.push(stateItem);
                }
                this.OnObjectSelected2.emit(queryDVO);

                //Satır secıldıkce detaylar yuklenıyor.
                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/QueryLaboratoryDetailItemByPatient"; //QueryLaboratoryDetailItemByEpisode ";
                await this.httpService.post<LaboratoryWorkListItemMasterModel>(fullApiUrl, queryDVO, LaboratoryWorkListItemMasterModel).then(result => {
                    if (result != null)
                        this.OnObjectSelected.emit(result);
                    this.loadLabRequestSampleWorklistPanelOperation(false, '');
                }).catch(error => {
                    this.loadLabRequestSampleWorklistPanelOperation(false, '');
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
            else
                this.loadLabRequestSampleWorklistPanelOperation(false, '');
        }
        catch (err) {
            this.loadLabRequestSampleWorklistPanelOperation(false, '');
            ServiceLocator.MessageService.showError(err);
        }

    }
    private currentSelectedRowKeys: Array<LaboratoryWorkListItemMasterModel> = new Array<LaboratoryWorkListItemMasterModel>();

    async selectIfSingleLaboratory(): Promise<void> {
        if (this.Model.LaboratoryProcedureMasterList != null && this.Model.LaboratoryProcedureMasterList.length == 1) {
            let _data: LaboratoryWorkListItemMasterModel = this.Model.LaboratoryProcedureMasterList[0] as LaboratoryWorkListItemMasterModel;

            let queryDVO: QueryInputDVOByEpisode = new QueryInputDVOByEpisode();
            queryDVO.EpisodeID = _data.EpisodeID;
            queryDVO.StartDate = this.Model.StartDate;
            queryDVO.EndDate = this.Model.EndDate;
            queryDVO.PatientStatus = this.Model.PatientStatus;
            queryDVO.SelectedWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
            queryDVO.LabRequestObjectID = _data.LabRequestObjectID;
            queryDVO.PatientObjectID = _data.PatientObjectID;

            let stateItem: LaboratoryWorkListStateItem;
            if (this.chkSampleAccept.Value == true) {
                stateItem = new LaboratoryWorkListStateItem();
                stateItem.StateDefID = "5eaf4c46-c99e-491c-a880-37d07484437e";
                queryDVO.SelectedWorkListStateItems.push(stateItem);
            }
            if (this.chkSampleTaking.Value == true) {
                stateItem = new LaboratoryWorkListStateItem();
                stateItem.StateDefID = "5b6b040c-cea8-4d4f-96d7-f394c9b28f87";
                queryDVO.SelectedWorkListStateItems.push(stateItem);
            }

            this.OnObjectSelected2.emit(queryDVO);

            //Ilk Satır otomatık yuklenıyor.
            let that = this;
            let fullApiUrl: string = "api/LaboratoryWorkListService/QueryLaboratoryDetailItemByPatient";
            let result = await this.httpService.post<LaboratoryWorkListItemMasterModel>(fullApiUrl, queryDVO, LaboratoryWorkListItemMasterModel);

            this.worklistDataGrid.instance.clearFilter();
            this.worklistDataGrid.instance.clearSelection();

            if (result != null)
                this.OnObjectSelected.emit(result);

            let selectedIndex = 0;
            if (this.currentSelectedRowKeys != null && this.currentSelectedRowKeys.length > 0) {
                selectedIndex = this.worklistDataGrid.instance.getRowIndexByKey(this.currentSelectedRowKeys[0]);
                if (selectedIndex == -1)
                    selectedIndex = 0;
            }
            let indexes: Array<number> = new Array<number>();
            indexes.push(selectedIndex);
            this.worklistDataGrid.instance.selectRowsByIndexes(indexes);

        } else {
            this.OnObjectSelected2.emit(null);
            this.OnObjectSelected.emit(null);
        }
    }

    async laboratoryWorkListItemsSelectionChanged(values: any) {
        //if(this.Model.SelectedEpisodeActionWorkListItems != null && this.Model.SelectedEpisodeActionWorkListItems.length == 1)
        //console.log(values);
        if (values) {
            if (values.length > 0) {
                let _episodeActionWorkListItems: Array<LaboratoryWorkListItem> = new Array<LaboratoryWorkListItem>();
                for (let item of values) {
                    let _episodeActionWorkListItem: LaboratoryWorkListItem = new LaboratoryWorkListItem();
                    _episodeActionWorkListItem = item; //values[0];
                    _episodeActionWorkListItems.push(_episodeActionWorkListItem);
                }
                await this.getStateList2(_episodeActionWorkListItems);
            }
            // this.SelectedEpisodeActionWorkListItems = values;
            this.Model.SelectedLaboratoryWorkListItems = values;
        }
        else {
            //console.log(values);
            this.LaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
            this.Model.SelectedLaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
        }
    }

    async laboratoryWorkListStateItemsSelectionChanged(values: any) {
        if (values)
            this.Model.SelectedLaboratoryWorkListStateItems = values;
        else
            this.Model.SelectedLaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
    }

    patientChanged(patient: any) {
        if (patient) {
            this.Model.txtPatient = patient.ObjectID;
            this.btnListele_Click();
        }
        else {
            this.Model.txtPatient = "";
            this.Model.LaboratoryProcedureMasterList = [];
            this.OnObjectSelected2.emit(null);
            this.OnObjectSelected.emit(null);
        }
    }


    txtSEProtocolNoChanged(e) {
        if (this.txtSEProtocolNo.Text != null && this.txtSEProtocolNo.Text != "") {
            this.Model.txtSEProtocolNo = this.txtSEProtocolNo.Text;
            this.btnListele_Click();
        }
        else {
            this.Model.txtSEProtocolNo = "";
            this.Model.LaboratoryProcedureMasterList = [];
            this.OnObjectSelected2.emit(null);
            this.OnObjectSelected.emit(null);
        }
    }
    changed(e: any): void {
        alert(e);
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

    async loadSpecialCriteria(data: any) {
        if (typeof data == 'object') {
            this.Model.LastSelectedSpecialPanel = data;
            this.SelectedLaboratoryWorkListItems = new Array<LaboratoryWorkListItem>();
            this.SelectedLaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
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
                this.Model.SelectedLaboratoryWorkListItems = this.SelectedLaboratoryWorkListItems;
                if (this.Model.SelectedLaboratoryWorkListItems.length > 0) {

                    await this.getStateList(this.Model.SelectedLaboratoryWorkListItems); //.then(() => {
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
                    this.Model.SelectedLaboratoryWorkListStateItems = this.SelectedLaboratoryWorkListStateItems;
                }
                else {
                    this.LaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
                    this.Model.SelectedLaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
                }

                //  this.Model.SelectedLaboratoryWorkListStateItems dakı objectstate e gore checkler ısaretlenıyor
                for (let stateItem of this.Model.SelectedLaboratoryWorkListStateItems) {
                    if (stateItem.StateDefID == "5b6b040c-cea8-4d4f-96d7-f394c9b28f87") {
                        this.chkSampleTaking.Value = true;
                        this.chkSampleAccept.Value = false;
                    }

                    else if (stateItem.StateDefID == "5eaf4c46-c99e-491c-a880-37d07484437e") {
                        this.chkSampleAccept.Value = true;
                        this.chkSampleTaking.Value = false;
                    }
                }
            } 
        }
    }

    SelectObjectDefinition(objectDefID: string) {
        if (this.Model.LaboratoryWorkListItems != null) {
            let episodeActionWorkListItem = this.Model.LaboratoryWorkListItems.find(o => o.ObjectDefID === objectDefID);
            if (episodeActionWorkListItem) {
                if (!this.SelectedLaboratoryWorkListItems)
                    this.SelectedLaboratoryWorkListItems = new Array<LaboratoryWorkListItem>();
                this.SelectedLaboratoryWorkListItems.push(episodeActionWorkListItem);
            }
        }
    }

    SelectState(stateDefID: string) {
        let episodeActionWorkListStateItem = this.Model.LaboratoryWorkListStateItems.find(s => s.StateDefID === stateDefID);
        if (episodeActionWorkListStateItem) {
            if (!this.SelectedLaboratoryWorkListStateItems)
                this.SelectedLaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
            this.SelectedLaboratoryWorkListStateItems.push(episodeActionWorkListStateItem);
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

    rowPrepared(row: any) {

    }


    public initFormControls(): void {

        this.btnSpecialPanelKaydet = new TTVisual.TTButton();
        this.btnSpecialPanelKaydet.Text = i18n("M17386", "Kaydet");
        this.btnSpecialPanelKaydet.Name = "btnSpecialPanelKaydet";
        this.btnSpecialPanelKaydet.TabIndex = 12;

        this.btnSpecialPanelSil = new TTVisual.TTButton();
        this.btnSpecialPanelSil.Text = i18n("M27286", "Sil");
        this.btnSpecialPanelSil.Name = "btnSpecialPanelSil";
        this.btnSpecialPanelSil.TabIndex = 12;

        this.btnListele = new TTVisual.TTButton();
        this.btnListele.Text = i18n("M27337", "Listele");
        this.btnListele.Name = "btnListele";
        this.btnListele.TabIndex = 12;

        this.PatientStatus = new TTVisual.TTEnumComboBox();
        this.PatientStatus.DataTypeName = "SubEpisodeStatusEnum";
        this.PatientStatus.Name = "PatientStatus";
        this.PatientStatus.TabIndex = 13;

        this.chkOutPatient = new TTVisual.TTCheckBox();
        this.chkOutPatient.Value = true;
        this.chkOutPatient.Title = i18n("M11281", "Ayaktan");
        this.chkOutPatient.Name = "chkOutPatient";
        this.chkOutPatient.TabIndex = 10;

        this.chkInPatient = new TTVisual.TTCheckBox();
        this.chkInPatient.Value = false;
        this.chkInPatient.Title = i18n("M24377", "Yatan");
        this.chkInPatient.Name = "chkInPatient";
        this.chkInPatient.TabIndex = 10;

        this.chkSampleAccept = new TTVisual.TTCheckBox();
        this.chkSampleAccept.Value = true;
        this.chkSampleAccept.Title = i18n("M16623", "İstek Kabul");
        this.chkSampleAccept.Name = "chkSampleAccept";
        this.chkSampleAccept.TabIndex = 10;

        this.chkSampleTaking = new TTVisual.TTCheckBox();
        this.chkSampleTaking.Value = false;
        this.chkSampleTaking.Title = i18n("M19538", "Numune Alma");
        this.chkSampleTaking.Name = "chkSampleTaking";
        this.chkSampleTaking.TabIndex = 10;

        this.txtSEProtocolNo = new TTVisual.TTTextBox();
        this.txtSEProtocolNo.Text = "";
        this.txtSEProtocolNo.Name = "txtSEProtocolNo";
        this.txtSEProtocolNo.TabIndex = 10;
    }

    returnTemplateText(data) {
        return i18n("M18284", "Listelenen İşlem Sayısı:") + data.value;
    }



}
export class CallNexttPatientParam {
    public ObjectId: Guid;
    public outPatientResID: Guid;
    public OrderNo: number;
}
export class GetSortedQueueItemsByArray_Input {
    public outPatientResID: Guid;
    public currentResUserID: Guid;
    public includeCalleds: boolean;
}