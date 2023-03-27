//$5932D9FE
import { Component, ViewChild, Output, EventEmitter, Renderer2, OnInit } from '@angular/core';
import { MessageService } from "Fw/Services/MessageService";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DxAccordionComponent, DxAutocompleteComponent, DxDataGridComponent } from "devextreme-angular";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { BaseEpisodeActionWorkListForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListForm";

import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { NuclearMedicineWorkListFormViewModel, StateOutputDVO, NuclearMedicineWorkListStateItem, NuclearMedicineWorkListItem, NuclearMedicineWorkListItemModel, NuclearMedicineInputDVO, UserResourceItem, UserResourceOutputDVO } from "./NuclearMedicineWorkListFormViewModel";
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { SimpleTimer } from 'ng2-simple-timer';
import { IModalService } from 'Fw/Services/IModalService';


@Component({
    selector: "hvl-nuclearmedicine-worklist-view",
    inputs: ['Model'],
    templateUrl: './NuclearMedicineWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class NuclearMedicineWorkListForm extends BaseEpisodeActionWorkListForm implements OnInit{


    @ViewChild('menuAccordion') accordion: DxAccordionComponent;
    @ViewChild(DxAutocompleteComponent) autoComplete: DxAutocompleteComponent;
    @ViewChild('filterAccordion') filteraccordion: DxAccordionComponent;
    @Output() OnObjectSelected: EventEmitter<Guid> = new EventEmitter<Guid>();
    @ViewChild('searchAndListAccordion') searchAndListAccordion: DxAccordionComponent;
    @ViewChild('WorkListGrid') WorkListGrid: DxDataGridComponent;

    public NuclearMedicineWorkListModel: NuclearMedicineWorkListFormViewModel = new NuclearMedicineWorkListFormViewModel();

    public componentInfo: DynamicComponentInfo;

    public selectedNuclearMedicineId: string;

    private activeResUserObjectID: string;

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    public NuclearMedicineWorkListStateItems: Array<NuclearMedicineWorkListStateItem>;
    public SelectedNuclearMedicineWorkListStateItems: Array<NuclearMedicineWorkListStateItem>;

    radioGroupOnlyOwnPatientItems = [
        { text: "Benim Hastalarım", value: true },
        { text: "Tüm Hastalar", value: false }

    ];
    public PageName = "NuclearMedicineWorkListForm"; // Kolonlar kullanıcılara göre kaydedilirken Kullanılır

    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer, protected modalService: IModalService, public renderer: Renderer2) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);

        this.initViewModel();
        this.initFormControls();
    }

    public initViewModel(): void {
  
        this.NuclearMedicineWorkListModel.NuclearMedicineWorkListItems = new Array<NuclearMedicineWorkListItem>();
        this.NuclearMedicineWorkListModel.NuclearMedicineWorkListStateItems = new Array<NuclearMedicineWorkListStateItem>();
        this.NuclearMedicineWorkListModel.SelectedNuclearMedicineWorkListItems = new Array<NuclearMedicineWorkListItem>();
        this.NuclearMedicineWorkListModel.SelectedNuclearMedicineWorkListStateItems = new Array<NuclearMedicineWorkListStateItem>();
        this.NuclearMedicineWorkListModel.SelectedStateTypes = new Array<string>();
        this.NuclearMedicineWorkListModel.SelectedStateTypesEM = new Array<string>();
        this.NuclearMedicineWorkListModel.UserResourceItems = new Array<UserResourceItem>();
        this.NuclearMedicineWorkListModel.SelectedUserResourceItems = new Array<UserResourceItem>();
        this.NuclearMedicineWorkListModel.StateType = "UNCOMPLETED";
        this.NuclearMedicineWorkListModel.SelectedStateTypes.push("UNCOMPLETED");
        this.NuclearMedicineWorkListModel.SelectedStateTypesEM.push("UNCOMPLETED");
        this.NuclearMedicineWorkListModel.OnlyOwnPatient = false;
    }

    async ngOnInit() {
        let episodeActionWorkListItems: Array<NuclearMedicineWorkListItem> = new Array<NuclearMedicineWorkListItem>();
        let episodeActionWorkListItem: NuclearMedicineWorkListItem = new NuclearMedicineWorkListItem();
        episodeActionWorkListItem.ObjectDefID = 'ffb5f11a-93ec-4b54-881c-57ca00f26f63';
        episodeActionWorkListItem.ObjectDefName = 'NUCLEARMEDICINE';
        episodeActionWorkListItems.push(episodeActionWorkListItem);
        await this.getStateList(episodeActionWorkListItems);
        await this.getUserResourceList();

        await this.doSearch();
    }
    loadViewModel() {
    }

    ngOnDestroy() {

    }

    async clientPreScript() {
    }

    clientPostScript(state: String) {
    }

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: i18n("M16650", "İşlem Zamanı"),
                dataField: "ActionDate",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 'auto',
                allowSorting: true,
            },
            {
                caption: i18n("M15133", "Hasta Adı Soyadı"),
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: "auto",
                minWidth: 150,
                cellTemplate: "PriorityCellTemplate",
                allowSorting: true
            },
            {
                "caption": i18n("M16818", "İşlem"),
                dataField: "NuclearMedicineTestName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
            },
            {
                "caption": i18n("M16838", "İşlem Durumu"),
                dataField: "StateName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
            },
            {
                caption: i18n("M27357", "İsteyen Klinik"),
                dataField: "FromResourceName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
            }
        ];
        super.GenerateResultListColumns(columnNameAndOrder);
    }

    async getStateList(value: any) {
        let that = this;
        let fullApiUrl: string = "api/NuclearMedicineWorkListService/GetEpisodeActionStateDefinition";
        let result = await this.httpService.post<StateOutputDVO>(fullApiUrl, value, StateOutputDVO);
        that.NuclearMedicineWorkListStateItems = result.WorkListSearchStateItem;
    }

    btnListele_Click() {
        let that = this;
        that.showLoadPanel = true;
        that.LoadPanelMessage = "İşlemler Listeleniyor...";
        that.doSearch();
        setTimeout(() => {
            that.LoadPanelMessage = "";
            this.showLoadPanel = false;
        }, 2000);
    }

    //async select(value: any): Promise<void> {
    //    let component = value.component,
    //        prevClickTime = component.lastClickTime;
    //    component.lastClickTime = new Date();
    //    if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
    //        let that = this;
    //        that.showLoadPanel = true;
    //        that.LoadPanelMessage = "İşlem Açılıyor, lütfen bekleyiniz.";
    //        try {
    //            let _data: NuclearMedicineWorkListItemModel = value.data as NuclearMedicineWorkListItemModel;
    //            this.openDynamicComponent(_data.ObjectDefName, _data.ObjectID);
    //        } catch (error) {
    //            that.messageService.showError(error);
    //        }

    //    }
    //}

    //openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
    //    if (objectID != null) {
    //        this.systemApiService.open(objectID, objectDefName, formDefId, inputparam);
    //        this.selectedNuclearMedicineId = objectID;
    //    }
    //    else {
    //        this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
    //        });
    //    }

    //    setTimeout(() => {
    //        this.showLoadPanel = false;
    //    }, 2000);
    //}

    //public dynamicComponentCreated(e: any) {
    //    let that = this;
    //    that.RepaintWorkListGrid();
    //    that.close_searchAndListAccordion();
    //}

    //public dynamicComponentClosed(e: any) {
    //    let that = this;
    //    setTimeout(function () {
    //        if (this.WorkListGrid != null && this.WorkListGrid.instance != null && this.WorkListGrid.instance["_disposed"] == null) {
    //            this.WorkListGrid.instance.repaint();

    //        }
    //    }, 30);

    //    that.showLoadPanel = true;
    //    that.LoadPanelMessage = "";
    //    this.doSearch();
    //    setTimeout(() => {
    //        this.showLoadPanel = false;
    //    }, 2000);

    //    that.open_searchAndListAccordion();
    //}

    //open_searchAndListAccordion() {
    //    if (this.searchAndListAccordion)
    //        this.searchAndListAccordion.selectedIndex = 0;
    //}
    //close_searchAndListAccordion() {
    //    if (this.searchAndListAccordion)
    //        this.searchAndListAccordion.selectedIndex = -1;
    //}

    //public RepaintWorkListGrid() {
    //    setTimeout(function () {
    //        if (this.WorkListGrid != null && this.WorkListGrid.instance != null) {
    //            this.WorkListGrid.instance.repaint();
    //        }
    //    }, 30);
    //}

    async getUserResourceList() {
        let that = this;
        await this.httpService.get<UserResourceOutputDVO>("api/EpisodeActionWorkListService/GetUserResources").then(response => {
            let output = <UserResourceOutputDVO>response;
            if (output) {
                that.NuclearMedicineWorkListModel.UserResourceItems = output.WorkListSearchUserResourceItem;
                this.setSelectedUserResourceList();
                //that.Model.SelectedUserResourceItems = output.SelectedWorkListSearchUserResourceItem;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }

    async setSelectedUserResourceList() {
        this.NuclearMedicineWorkListModel.SelectedUserResourceItems = new Array<UserResourceItem>();
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

    async SelectUserResource(resourceID: string) {
        let userResourceItem = this.NuclearMedicineWorkListModel.UserResourceItems.find(s => s.ResourceID === resourceID);
        if (userResourceItem) {
            if (!this.NuclearMedicineWorkListModel.SelectedUserResourceItems)
                this.NuclearMedicineWorkListModel.SelectedUserResourceItems = new Array<UserResourceItem>();
            this.NuclearMedicineWorkListModel.SelectedUserResourceItems.push(userResourceItem);
        }
    }

    async userResourceItemsSelectionChanged() {

    }

    patientChanged(patient: any) {
        let sysDate: Date = new Date(Date.now());
        if (patient) {
            this.NuclearMedicineWorkListModel.txtPatient = patient.ObjectID;
            this.NuclearMedicineWorkListModel.SelectedStateTypes = new Array<string>();
            this.NuclearMedicineWorkListModel.SelectedStateTypesEM = new Array<string>();
            this.NuclearMedicineWorkListModel.SelectedNuclearMedicineWorkListItems = new Array<NuclearMedicineWorkListItem>();
            this.NuclearMedicineWorkListModel.SelectedNuclearMedicineWorkListStateItems = new Array<NuclearMedicineWorkListStateItem>();
            this.NuclearMedicineWorkListModel.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.NuclearMedicineWorkListModel.StartDate = (Convert.ToDateTime(this.NuclearMedicineWorkListModel.EndDate).AddMonths(-6));
        }
        else {
            this.NuclearMedicineWorkListModel.txtPatient = "";
            this.NuclearMedicineWorkListModel.SelectedStateTypes.push("UNCOMPLETED");
            this.NuclearMedicineWorkListModel.SelectedStateTypesEM.push("UNCOMPLETED");
            this.NuclearMedicineWorkListModel.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.NuclearMedicineWorkListModel.StartDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 0, 0, 0);
        }
        this.btnListele_Click();
    }

    async doSearch(): Promise<void> {
        let inputDvo = new NuclearMedicineInputDVO();
        inputDvo.txtPatient = this.NuclearMedicineWorkListModel.txtPatient;
        inputDvo.StartDate = this.NuclearMedicineWorkListModel.StartDate;
        inputDvo.EndDate = this.NuclearMedicineWorkListModel.EndDate;
        inputDvo.ID = this.NuclearMedicineWorkListModel.ID;
        inputDvo.WorkListCount = this.NuclearMedicineWorkListModel.WorkListCount;
        inputDvo.StateType = this.NuclearMedicineWorkListModel.StateType;
        inputDvo.PatientStatus = "";
        inputDvo.PatientStatus = this.NuclearMedicineWorkListModel.PatientStatus;
        inputDvo.SelectedWorkListItems = this.NuclearMedicineWorkListModel.SelectedNuclearMedicineWorkListItems;
        inputDvo.SelectedWorkListStateItems = this.SelectedNuclearMedicineWorkListStateItems;
        inputDvo.WorkListItems = this.NuclearMedicineWorkListModel.NuclearMedicineWorkListItems;
        inputDvo.WorkListStateItems = this.NuclearMedicineWorkListModel.NuclearMedicineWorkListStateItemsAll;
        inputDvo.SelectedStateTypes = this.NuclearMedicineWorkListModel.SelectedStateTypes;
        inputDvo.SelectedStateTypesEM = this.NuclearMedicineWorkListModel.SelectedStateTypesEM;
        inputDvo.UserResourceItems = this.NuclearMedicineWorkListModel.UserResourceItems;
        inputDvo.SelectedUserResourceItems = this.NuclearMedicineWorkListModel.SelectedUserResourceItems;
        inputDvo.NuclearMedicineEquipmentItems = this.NuclearMedicineWorkListModel.RadiologyEquipmentItems;
        inputDvo.SelectedNuclearMedicineEquipmentItems = this.NuclearMedicineWorkListModel.SelectedNuclearMedicineEquipmentItems;
        inputDvo.activeResUserObjectID = this.activeResUserObjectID;
        //inputDvo.SelectedQueueObjectID = this.activeUserService.SelectedQueue.ObjectID;
        inputDvo.ProtocolNo = this.NuclearMedicineWorkListModel.ProtocolNo;
        inputDvo.OnlyOwnPatient = this.NuclearMedicineWorkListModel.OnlyOwnPatient;

        let that = this;
        let fullApiUrl: string = "api/NuclearMedicineWorkListService/QueryNuclearMedicineWorkList";

        let result = await this.httpService.post<NuclearMedicineWorkListFormViewModel>(fullApiUrl, inputDvo, NuclearMedicineWorkListFormViewModel);
        this.NuclearMedicineWorkListModel.NuclearMedicineList = result.NuclearMedicineList;
        this.NuclearMedicineWorkListModel.txtPatient = result.txtPatient;
        this.NuclearMedicineWorkListModel.StartDate = result.StartDate;
        this.NuclearMedicineWorkListModel.EndDate = result.EndDate;
        this.NuclearMedicineWorkListModel.ID = result.ID;
        this.NuclearMedicineWorkListModel.WorkListCount = result.WorkListCount;
        this.NuclearMedicineWorkListModel.StateType = result.StateType;
        this.NuclearMedicineWorkListModel.SelectedStateTypes = result.SelectedStateTypes;
        this.NuclearMedicineWorkListModel.SelectedStateTypesEM = result.SelectedStateTypesEM;
        this.NuclearMedicineWorkListModel.PatientStatus = result.PatientStatus;
    }

    async nuclearMedicineWorkListStateItemsSelectionChanged(values: any) {
        if (values)
            this.NuclearMedicineWorkListModel.SelectedNuclearMedicineWorkListStateItems = values;
        else
            this.NuclearMedicineWorkListModel.SelectedNuclearMedicineWorkListStateItems = new Array<NuclearMedicineWorkListStateItem>();
    }

    async stateTypeSelectionChanged() {
        this.NuclearMedicineWorkListModel.SelectedStateTypesEM = new Array<string>();
        for (let stateType of this.NuclearMedicineWorkListModel.SelectedStateTypes) {
            if (stateType === "SUCCESSFUL")
                this.NuclearMedicineWorkListModel.SelectedStateTypesEM.push("COMPLETEDSUCCESSFULLY");
            else if (stateType === "UNSUCCESSFUL")
                this.NuclearMedicineWorkListModel.SelectedStateTypesEM.push("COMPLETEDUNSUCCESSFULLY");
            else
                this.NuclearMedicineWorkListModel.SelectedStateTypesEM.push(stateType);
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
    }

    onProtocolNoEnterKeyDown(e) {
        this.btnListele_Click();
    }
}

