//$F2E666BF
import { Component, ViewChild, Output, EventEmitter } from '@angular/core';
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
import { ServiceLocator } from "Fw/Services/ServiceLocator";

import { LaboratoryWorkListFormViewModel, QueryInputDVO, LaboratoryWorkListItem, LaboratoryWorkListStateItem, MenuOutputDVO, StateOutputDVO, LaboratoryWorkListItemMasterModel, LaboratoryWorkListItemDetailModel, SpecialPanelOutputDVO, SpecialPanelInputDVO, SpecialPanelListItem, QueryInputDVOByEpisode, ProcedureTreeObject } from "./LaboratoryWorkListFormViewModel";
import { ISidebarMenuService } from '../../../wwwroot/app/Fw/Services/ISidebarMenuService';
import { IModalService } from '../../../wwwroot/app/Fw/Services/IModalService';
import { DynamicSidebarMenuItem } from '../../../wwwroot/app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { DynamicReportParameters } from '../../../wwwroot/app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { ModalInfo } from '../../../wwwroot/app/Fw/Models/ModalInfo';


@Component({
    selector: "hvl-laboratory-main-worklist-view",
    inputs: ['Model'],
    templateUrl: './LaboratoryMainWorkListForm.html',
    providers: [SystemApiService],
})
export class LaboratoryMainWorkListForm extends BaseComponent<LaboratoryWorkListFormViewModel>{

    btnListele: TTVisual.ITTButton;
    btnSpecialPanelKaydet: TTVisual.ITTButton;
    btnSpecialPanelSil: TTVisual.ITTButton;
    PatientStatus: TTVisual.ITTEnumComboBox;
    chkOutPatient: TTVisual.ITTCheckBox;
    chkInPatient: TTVisual.ITTCheckBox;
    private _selectedObjectDefName: string;
    private _specialPanelListItems: Array<SpecialPanelListItem>;
    @ViewChild('filterAccordion') filteraccordion: DxAccordionComponent;
    @Output() OnObjectSelected: EventEmitter<LaboratoryWorkListItemMasterModel> = new EventEmitter<LaboratoryWorkListItemMasterModel>();
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
    public BarcodeValue: string = "";

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

    constructor(container: ServiceContainer, private httpService: NeHttpService, public systemApiService: SystemApiService, private sideBarMenuService: ISidebarMenuService, protected modalService: IModalService) {
        super(container);
        this.initFormControls();
        this.SpecialPanelListItems = new Array<SpecialPanelListItem>();
    }

    async clientPreScript() {
        this.AddHelpMenu();

        this.Model = new LaboratoryWorkListFormViewModel();
        this.Model.txtPatient = "";
        this.Model.LaboratoryWorkListItems = new Array<LaboratoryWorkListItem>();
        this.Model.SelectedLaboratoryWorkListItems = new Array<LaboratoryWorkListItem>();
        this.Model.LaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
        //this.Model.StateType = "UNCOMPLETED";
        this.Model.PatientStatus = "0";
        this.Model.WorkListCount = 20;

        //let laboratoryWorkListItem = new LaboratoryWorkListItem();
        //laboratoryWorkListItem.ObjectDefID = "f87eac33-a91e-4934-a010-edf6029d2d18";
        //laboratoryWorkListItem.ObjectDefName = "Laboruvar test";
        //this.Model.LaboratoryWorkListItems.push(laboratoryWorkListItem);

        //this.Model.SelectedLaboratoryWorkListItems.push(laboratoryWorkListItem);

        let _episodeActionWorkListItems: Array<LaboratoryWorkListItem> = new Array<LaboratoryWorkListItem>();

        let _episodeActionWorkListItem: LaboratoryWorkListItem = new LaboratoryWorkListItem();
        _episodeActionWorkListItem.ObjectDefID = "f87eac33-a91e-4934-a010-edf6029d2d18";  //values[0];
        _episodeActionWorkListItem.ObjectDefName = "Laboratory Test";
        _episodeActionWorkListItems.push(_episodeActionWorkListItem);


        await this.getStateList2(_episodeActionWorkListItems);

        await this.doSearch();
        this.selectIfSingleLaboratory();

        this.AddHelpMenu();

    }
    clientPostScript(state: String) {

    }

    btnListele_Click() {
        this.OnListBtnClick.emit(true);
        this.loadLabMainWorklistPanelOperation(true, i18n("M15370", "Hastalar listeleniyor, lütfen bekleyiniz."));

        this.doSearch().then(() => {
            this.selectIfSingleLaboratory();
        });
    }

    loadLabMainWorklistPanelOperation(visible: boolean, message: string): void {
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

            let that = this;
            let fullApiUrl: string = "api/EpisodeActionWorkListService/SaveSpecialPanel";
            let result = await this.httpService.post<SpecialPanelInputDVO>(fullApiUrl, specialPanelInputDVO, SpecialPanelInputDVO);

            this.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
            this.Model.LastSelectedSpecialPanelCaption = result.SpecialPanelListItemCaption;
            this.SpecialPanelListItems = result.SpecialPanelListItems;
            this.SelectedLaboratoryWorkListItems = result.SelectedWorkListItems;
            this.SelectedLaboratoryWorkListStateItems = result.SelectedWorkListStateItems;
            this.Model.SelectedLaboratoryWorkListItems = result.SelectedWorkListItems;
            this.Model.SelectedLaboratoryWorkListStateItems = result.SelectedWorkListStateItems;
            this.Model.SpecialPanelListItems = result.SpecialPanelListItems;
            this.Model.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
            this.getSpecialPanelList();
            ServiceLocator.MessageService.showSuccess("'" + result.SpecialPanelListItemCaption + i18n("M20098", " özel paneli başarılı olarak kaydedildi."));
        }
    }


    async btnSpecialPanelSil_Click() {
        if (this.Model.LastSelectedSpecialPanel == undefined || this.Model.LastSelectedSpecialPanel == null) {
            ServiceLocator.MessageService.showError("Silmek İçin Özel Panel Seçiniz.");
        }
        else if (this.Model.LastSelectedSpecialPanel && !this.Model.LastSelectedSpecialPanel.User) {
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

            let that = this;
            let fullApiUrl: string = "api/EpisodeActionWorkListService/DeleteSpecialPanel";
            let result = await this.httpService.post<SpecialPanelInputDVO>(fullApiUrl, specialPanelInputDVO, SpecialPanelInputDVO);

            this.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
            this.Model.LastSelectedSpecialPanelCaption = result.SpecialPanelListItemCaption;
            this.SpecialPanelListItems = result.SpecialPanelListItems;
            this.SelectedLaboratoryWorkListItems = result.SelectedWorkListItems;
            this.SelectedLaboratoryWorkListStateItems = result.SelectedWorkListStateItems;
            this.Model.SelectedLaboratoryWorkListItems = result.SelectedWorkListItems;
            this.Model.SelectedLaboratoryWorkListStateItems = result.SelectedWorkListStateItems;
            this.Model.SpecialPanelListItems = result.SpecialPanelListItems;
            this.Model.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
            this.getSpecialPanelList();
            ServiceLocator.MessageService.showSuccess("'" + deletedSpecialPanelCaption + i18n("M20099", " özel paneli başarılı olarak silindi."));
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

    onProtocolNoEnterKeyDown(e) {
        this.doSearch();
    }

    async doSearch(): Promise<void> {
        let inputDvo = new QueryInputDVO();
        inputDvo.txtPatient = this.Model.txtPatient;
        inputDvo.StartDate = this.Model.StartDate;
        inputDvo.EndDate = this.Model.EndDate;
        inputDvo.ID = this.Model.ID;
        inputDvo.WorkListCount = this.Model.WorkListCount;
        inputDvo.StateType = this.Model.StateType;
        inputDvo.PatientStatus = "";
        inputDvo.txtSEProtocolNo = this.Model.txtSEProtocolNo;
        if (this.chkOutPatient.Value == true && this.chkInPatient.Value == true)
            this.Model.PatientStatus = "0,1,2,3";
        else if (this.chkOutPatient.Value == true)
            this.Model.PatientStatus = "0";
        else if (this.chkInPatient.Value == true)
            this.Model.PatientStatus = "1,2,3";
        inputDvo.PatientStatus = this.Model.PatientStatus;
        //inputDvo.SelectedWorkListItems = this.Model.SelectedLaboratoryWorkListItems;
        inputDvo.SelectedWorkListStateItems = this.Model.SelectedLaboratoryWorkListStateItems;
        //inputDvo.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;

        let that = this;
        let fullApiUrl: string = "api/LaboratoryWorkListService/QueryLaboratoryWorkList";
        let result = await this.httpService.post<LaboratoryWorkListFormViewModel>(fullApiUrl, inputDvo, LaboratoryWorkListFormViewModel);

        this.Model.LaboratoryProcedureMasterList = result.LaboratoryProcedureMasterList;
        this.Model.txtPatient = result.txtPatient;
        this.Model.StartDate = result.StartDate;
        this.Model.EndDate = result.EndDate;
        this.Model.EpisodeID = result.EpisodeID;
        this.Model.WorkListCount = result.WorkListCount;
        this.Model.StateType = result.StateType;
        this.Model.PatientStatus = result.PatientStatus;

        this.loadLabMainWorklistPanelOperation(false, '');
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
        this.Model.LaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
        this.Model.SelectedLaboratoryWorkListStateItems = new Array<LaboratoryWorkListStateItem>();

        let fullApiUrl: string = "api/EpisodeActionWorkListService/GetEpisodeActionStateDefinition";
        let result = await this.httpService.post<StateOutputDVO>(fullApiUrl, value, StateOutputDVO);
        this.LaboratoryWorkListStateItems = result.WorkListSearchStateItem;
        for (let item of result.WorkListSearchStateItem) {
            if (item.StateDefID != "5eaf4c46-c99e-491c-a880-37d07484437e" && item.StateDefID != "5b6b040c-cea8-4d4f-96d7-f394c9b28f87" && item.StateDefID != "e3b32262-fba4-4255-9a0f-c34c1ad78973")  //Istek kabul, Numune Alma, Numune Kontrol asamaları ıslem adımı combosunda cıkmamalı
            {
                this.Model.LaboratoryWorkListStateItems.push(item);
                this.Model.SelectedLaboratoryWorkListStateItems.push(item);
            }
        }
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

        let _data: LaboratoryWorkListItemMasterModel = value.selectedRowsData[0] as LaboratoryWorkListItemMasterModel;
        this.OnObjectSelected.emit(_data);

    }

    loadLabRequestSampleWorklistPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    private currentSelectedRowKeys: Array<LaboratoryWorkListItemMasterModel> = new Array<LaboratoryWorkListItemMasterModel>();

    async workListItemSelect2(value: any): Promise<void> {

        this.loadLabRequestSampleWorklistPanelOperation(true, 'Hasta yükleniyor, lütfen bekleyiniz.');
        try {
            let _data: LaboratoryWorkListItemMasterModel;
            if (value.selectedRowsData != undefined)
            {
                if (value.selectedRowsData.length > 0)
                { 
                    this.currentSelectedRowKeys = value.currentSelectedRowKeys;
                    //let _data: LaboratoryWorkListItemMasterModel = value.selectedRowsData[0] as LaboratoryWorkListItemMasterModel;
                    _data = value.selectedRowsData[0];
                }
            }
            else
            {
                _data = value;
            }
            if (_data) {
                let queryDVO: QueryInputDVOByEpisode = new QueryInputDVOByEpisode();
                queryDVO.EpisodeID = _data.EpisodeID;
                queryDVO.StartDate = this.Model.StartDate;
                queryDVO.EndDate = this.Model.EndDate;
                queryDVO.PatientStatus = this.Model.PatientStatus;
                queryDVO.SelectedWorkListStateItems = new Array<LaboratoryWorkListStateItem>();
                queryDVO.LabRequestObjectID = _data.LabRequestObjectID;

                //this.OnObjectSelected2.emit(queryDVO);

                //Satır secıldıkce detaylar yuklenıyor.
                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/QueryLaboratoryDetailItemByEpisodeForMainLabWorkList";
                await this.httpService.post<LaboratoryWorkListItemMasterModel>(fullApiUrl, queryDVO, LaboratoryWorkListItemMasterModel).then(result => {
                    if (result != null)
                        this.OnObjectSelected.emit(result);
                    this.loadLabRequestSampleWorklistPanelOperation(false, '');
                }).catch(error => {
                    this.loadLabRequestSampleWorklistPanelOperation(false, '');
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
            //else
                this.loadLabRequestSampleWorklistPanelOperation(false, '');
        }
        catch (err) {
            this.loadLabRequestSampleWorklistPanelOperation(false, '');
            ServiceLocator.MessageService.showError(err);
        }

    }

    async selectIfSingleLaboratory(): Promise<void> {
        if (this.Model.LaboratoryProcedureMasterList != null && this.Model.LaboratoryProcedureMasterList.length > 0)
        {
            let _data: LaboratoryWorkListItemMasterModel = this.Model.LaboratoryProcedureMasterList[0] as LaboratoryWorkListItemMasterModel;
            this.OnObjectSelected.emit(_data);

            this.workListItemSelect2(_data);
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
        if (patient)
            this.Model.txtPatient = patient.ObjectID;
        else
            this.Model.txtPatient = "";
        this.btnListele_Click();
    }

    changed(e: any): void {
        alert(e);
    }

    async getSpecialPanelList() {

        let fullApiUrl: string = "api/EpisodeActionWorkListService/GetSpecialPanelDefinition";
        let result = await this.httpService.get<SpecialPanelOutputDVO>(fullApiUrl, SpecialPanelOutputDVO);

        this.SpecialPanelListItems = result.SpecialPanelList;
        this.Model.SpecialPanelListItems = result.SpecialPanelList;
        if (result.LastSelectedSpecialPanel)
            this.Model.LastSelectedSpecialPanelCaption = result.LastSelectedSpecialPanel.Caption;
        this.Model.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;
        this.LastSelectedSpecialPanel = result.LastSelectedSpecialPanel;

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
                this.doSearch();
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

    rowPrepared(row: any) {

    }


    onBarcodeChanged(event) {
        let that = this;
        if (event.charCode === 13)
           that.QueryLaboratoryWorkListByResultBarcode();

    }

    public async QueryLaboratoryWorkListByResultBarcode() {

        if (this.BarcodeValue != null && this.BarcodeValue.toString() != "")
        {
            let fullApiUrl: string = "api/LaboratoryWorkListService/QueryLaboratoryWorkListByResultBarcode?specimenID=" + this.BarcodeValue.toString();
            let result = await this.httpService.get<LaboratoryWorkListFormViewModel>(fullApiUrl);

            if (result != null) {
                this.Model.LaboratoryProcedureMasterList = result.LaboratoryProcedureMasterList;
                this.OnObjectSelected.emit(result.LaboratoryProcedureMasterList[0]);
            }
        }
        else
        {
            this.Model.LaboratoryProcedureMasterList = new Array<LaboratoryWorkListItemMasterModel>();
            let emptyModel: LaboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();
            this.OnObjectSelected.emit(emptyModel);
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
        this.chkInPatient.Value = false;
        this.chkInPatient.Text = i18n("M24377", "Yatan");
        this.chkInPatient.Name = "chkInPatient";
        this.chkInPatient.TabIndex = 10;
    }

    returnTemplateText(data) {
        return i18n("M18284", "Listelenen İşlem Sayısı:") + data.value;
    }


    public onchkOutPatientChanged(event): void {
        this.chkOutPatient.Value = event;
        //if (event == true) {
        //    this.chkInPatient.Value = false;
        //}
    }

    public onchkInPatientChanged(event): void {
        this.chkInPatient.Value = event;
        //if (event == true) {
        //    this.chkOutPatient.Value = false;
        //}
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let labTestList = new DynamicSidebarMenuItem();
        labTestList.key = 'labTestList';
        labTestList.componentInstance = this;
        labTestList.label = 'Laboratuvar Test Sayıları';
        labTestList.icon = 'far fa-file-alt';
        labTestList.clickFunction = this.openLabTestListReport;
        this.sideBarMenuService.addMenu('YardimciMenu', labTestList);

    }


    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('labTestList');

    }
    showLabTestNumberPopup: boolean = false;
    public ReportStartDate: Date = new Date();
    public ReportEndDate: Date = new Date(); 
    public ProcedureTreeList: Array<ProcedureTreeObject> = new Array<ProcedureTreeObject>();
    public SelectedProcedureTree: Array<ProcedureTreeObject> = new Array<ProcedureTreeObject>();

    public openLabTestListReport() {

        let fullApiUrl: string = "/api/LaboratoryWorkListService/GetLabProcedureTreeList";

        this.httpService.get<Array<ProcedureTreeObject>>(fullApiUrl)
            .then(response => {
                this.ProcedureTreeList = response as Array<ProcedureTreeObject>;

                this.showLabTestNumberPopup = true;
            })
            .catch(error => {
                console.log(error);
            });

    }

    public PrepareLabTestReport() {

        let that = this;
        let reportData: DynamicReportParameters = {

            Code: 'LABTESTSAYISIRAPORU',
            ReportParams: { ReportStartDate: this.ReportStartDate, ReportEndDate: this.ReportEndDate, SelectedProcedureTree: this.SelectedProcedureTree },
            ViewerMode: true

        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "LABORATUVAR TEST SAYISI RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
}