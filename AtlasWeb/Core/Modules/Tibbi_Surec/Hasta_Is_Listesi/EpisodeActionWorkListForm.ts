//$4E54A6BC
import { Component, ViewChild, Output, EventEmitter, OnDestroy, OnInit, AfterViewInit, Renderer2 } from '@angular/core';
import { Headers, RequestOptions } from "@angular/http";
import { EpisodeActionWorkListFormViewModel, QueryInputDVO, EpisodeActionWorkListItem, EpisodeActionWorkListStateItem, MenuOutputDVO, StateOutputDVO, UserResourceOutputDVO, EpisodeActionWorkListItemModel, SpecialPanelOutputDVO, SpecialPanelInputDVO, SpecialPanelListItem, ActiveInfoDVO, UserResourceItem, LCDNotificationOutputDVO } from "./EpisodeActionWorkListFormViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DxAccordionComponent, DxAutocompleteComponent, DxDataGridComponent } from "devextreme-angular";
import { MenuDefinition, EtkinMaddeTeshisEslestirme, LCDNotificationDefinition, SystemParameter, HealthCommittee } from 'NebulaClient/Model/AtlasClientModel';
import { TTListDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTListDef';
import { TTObjectStateDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { MultiSelectForm } from 'NebulaClient/Visual/MultiSelectForm';
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ExaminationQueueItem } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { Subscription } from 'rxjs';
import { CommonService } from "ObjectClassService/CommonService";
import { ComposeComponent } from 'Fw/Components/ComposeComponent';
import { Observable } from 'rxjs';
import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { SimpleTimer } from 'ng2-simple-timer';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { DateParam } from 'app/NebulaClient/Mscorlib/DateParam';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { TTException } from 'app/NebulaClient/Utils/Exceptions/TTException';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
@Component({
    selector: "hvl-episodeaction-worklist-view",
    inputs: ['Model'],
    templateUrl: './EpisodeActionWorkListForm.html',
    providers: [SystemApiService],
})
export class EpisodeActionWorkListForm extends BaseComponent<EpisodeActionWorkListFormViewModel> implements OnInit, OnDestroy, AfterViewInit {
    btnListele: TTVisual.ITTButton;
    btnSpecialPanelKaydet: TTVisual.ITTButton;
    btnSpecialPanelSil: TTVisual.ITTButton;
    PatientStatus: TTVisual.ITTEnumComboBox;
    txtSEProtocolNo: TTVisual.ITTTextBox;
    chkOutPatient: TTVisual.ITTCheckBox;
    chkInPatient: TTVisual.ITTCheckBox;
    chkDailyInpatient: TTVisual.ITTCheckBox;
    private _selectedObjectDefName: string;
    private _specialPanelListItems: Array<SpecialPanelListItem>;
    @ViewChild('filterAccordion') filteraccordion: DxAccordionComponent;
    @ViewChild('dynamicComponent') dynamicComponent: ComposeComponent;
    //@ViewChild('examinationPanel') examinationPanel: HTMLDivElement;
    @Output() OnObjectSelected: EventEmitter<Guid> = new EventEmitter<Guid>();
    public selectedEpisodeActionId: string;


    EpisodeActionList: Array<EpisodeActionWorkListItemModel>;
    public menuList: Array<MenuDefinition>;
    public stateList: Array<TTObjectStateDef>;
    public searchMenuTxt: string;
    public componentInfo: DynamicComponentInfo;
    public componentPatientInfo: DynamicComponentInfo;
    public selectedAccordionItem: any;
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

    private selectedRowData: any;

    public WorkListColumns = [];
    @ViewChild('workListGrid') workListGrid: DxDataGridComponent;
    @ViewChild('menuAccordion') accordion: DxAccordionComponent;
    @ViewChild(DxAutocompleteComponent) autoComplete: DxAutocompleteComponent;

    private episodeActionWorkListSubscription: Subscription;
    private refreshEpisodeActionSubscription: Subscription;

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    openSpecialList() {
        this.autoComplete.instance.open();
    }

    constructor(container: ServiceContainer, protected httpService: NeHttpService, public systemApiService: SystemApiService, 
        private activeUserService: IActiveUserService, private renderer: Renderer2, protected st: SimpleTimer,
        protected reportService: AtlasReportService,private sideBarMenuService: ISidebarMenuService) {
        super(container);
        this.initViewModel();
        this.initFormControls();

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
        this.Model = new EpisodeActionWorkListFormViewModel();
        this.Model.txtPatient = "";
        this.Model.EpisodeActionWorkListItems = new Array<EpisodeActionWorkListItem>();
        this.Model.EpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
        this.Model.EpisodeActionWorkListStateItemsAll = new Array<EpisodeActionWorkListStateItem>();
        this.Model.SelectedEpisodeActionWorkListItems = new Array<EpisodeActionWorkListItem>();
        this.Model.SelectedEpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
        this.Model.SelectedStateTypes = new Array<string>();
        this.Model.SelectedStateTypesEM = new Array<string>();
        this.Model.UserResourceItems = new Array<UserResourceItem>();
        this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
        this.Model.LCDNotificationList = new Array<LCDNotificationDefinition>();
        this.Model.StateType = "UNCOMPLETED";
        this.Model.SelectedStateTypes.push("UNCOMPLETED");
        this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
        this.Model.PatientStatus = "";
        this.Model.WorkListCount = 20;
        this.Model.maxWorklistItemCount = 0;

    }

    async ngOnInit() {
        await this.getLCDNotificationList();
        await this.getUserResourceList();
        await this.getMenuList();
        await this.getSpecialPanelList();
        if (this.LastSelectedSpecialPanel) {
            await this.loadSpecialCriteria(this.LastSelectedSpecialPanel);
        }
        //else {
        await this.doSearch();
        //}
    }

    async ngAfterViewInit(): Promise<void> {
        this.Model.isNewLcd = await SystemParameterService.GetParameterValue('ISNEWLCD', 'FALSE');
        this.loadForm();
        let that = this;
        setTimeout(function () {
            that.accordionContainerHeight = that.setAccordionRowCotainerHeight('100%');
        }, 50);// Kullanıcı Bazlı Kolon Sırası get etmek için
    }


    loadForm(): void {
        let InvoiceSEPSearch: string = '/api/InvoiceApi/InvoiceSEPSearch';
        let apiUrlForInvoiceTransactionList: string = '/api/InvoiceApi/GetColumnAndOrder?gridName=workListGrid&pageName=EpisodeActionWorkListForm';
        let promiseArray: Array<Promise<any>> = new Array<any>();
        let that = this;

        promiseArray.push(that.httpService.get(apiUrlForInvoiceTransactionList));

        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            this.GenerateResultListColumns(sonuc[0]);
        });
        this.Model.StateType = "UNCOMPLETED";
        this.Model.SelectedStateTypes.push("UNCOMPLETED");
        this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
        this.AddHelpMenu();
    }

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: i18n("M21815", "Sıra No"),
                dataField: "AdmissionQueueNumber",
                width: "auto",
                fixed: true,
                visible: false,
                allowSorting: true,
                //sortOrder: 'asc',
                //sortIndex: 1,
                cssClass: 'worklistGridCellFont'
            },
            {
                "caption": i18n("M15133", "Hasta Adı Soyadı"),
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: "auto",
                cellTemplate: "PriorityCellTemplate",
                fixed: true,
                visible: false,
                allowSorting: true,
                cssClass: 'worklistGridCellFont',
            },
            {
                "caption": i18n("M17578", "Kimlik No"),
                dataField: "PatientIdentityNumber",
                width: "auto",
                visible: false,
                allowSorting: true,
                cssClass: 'worklistGridCellFont'
            },
            {
                "caption": i18n("M30303", "İşlem"),
                dataField: "EpisodeActionName",
                dataType: 'string',
                width: 150,
                visible: false,
                allowSorting: true,
                cssClass: 'worklistGridCellFont',
            },
            {
                "caption": i18n("M16838", "İşlem Durumu"),
                dataField: "StateName",
                dataType: 'string',
                width: 100,
                visible: false,
                allowSorting: true,
                cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: "ID",
                width: 75,
                visible: false,
                allowSorting: true,
                cssClass: 'worklistGridCellFont'
            },
            {
                //MasterResource gösterilecek şekilde değiştirildi. önceden subepisode un pa sının policlinic property si gösteriliyordu.
                caption: i18n("M17016", "Kabul Birimi"),
                dataField: "AdmissionResourceName",
                dataType: 'string',
                width: 150,
                visible: false,
                allowSorting: true,
                cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M16650", "İstek Tarihi"),
                dataField: "RequestDateStr",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 100,
                visible: false,
                allowSorting: true,
                //sortOrder: 'asc',
                //sortIndex: 0,
                cssClass: 'worklistGridCellFont'
            },
            {
                caption: i18n("", "Kabul Doktoru"),
                dataField: "AdmissionDoctorName",
                dataType: 'string',
                width: 150,
                visible: false,
                allowSorting: true,
                cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("", "Sorumlu Hemşire"),
                dataField: "ResponsibleNurseName",
                dataType: 'string',
                width: 150,
                visible: false,
                allowSorting: true,
                cssClass: 'worklistGridCellFont',
            },
            {
                caption: "Hasta Çağırılma Durumu",
                dataField: "PatientCallStatus",
                cellTemplate: "PatientCallCellTemplate",
                dataType: 'string',
                width: 'auto',
                visible: true,
                allowSorting: true
            }

        ];
        let i = 0;
        if (columnNameAndOrder.length > 0) {
            for (let item of columnNameAndOrder) {
                for (let baseItem of this.WorkListColumns) {
                    if (item == baseItem.dataField) {
                        baseItem.visible = true;
                        baseItem.visibleIndex = i;
                        i++;
                    }
                }
            }
        }
        else {
            for (let baseItem of this.WorkListColumns) {
                baseItem.visible = true;
                baseItem.visibleIndex = i;
                i++;
            }
        }
    }

    actionStatusArray: Array<any> =
        [{ Disabled: false, Group: null, Selected: false, Text: i18n("M16547", "İptaller"), Value: "CANCELLED;" },
        { Disabled: false, Group: null, Selected: false, Text: i18n("M11598", "Başarılı"), Value: "SUCCESSFUL" },
        { Disabled: false, Group: null, Selected: true, Text: i18n("M11602", "Başarısız"), Value: "UNSUCCESSFUL" },
        { Disabled: false, Group: null, Selected: false, Text: i18n("M22717", "Tamamlanmamış"), Value: "UNCOMPLETED" }];

    ngOnDestroy() {
        if (this.episodeActionWorkListSubscription != null) {
            this.episodeActionWorkListSubscription.unsubscribe();
            this.episodeActionWorkListSubscription = null;
        }
        if (this.refreshEpisodeActionSubscription != null) {
            this.refreshEpisodeActionSubscription.unsubscribe();
            this.refreshEpisodeActionSubscription = null;
        }
        this.RemoveMenuFromHelpMenu();
        this.st.delTimer(this.seachTimer);
    }

    // Timera Bağlı Listeleme
    public timerperiod: number = 60;
    public seachTimer: string = "seachTimer";

    timerId: string;

    subscribeTimer() {

        this.st.unsubscribe(this.timerId);
        this.timerId = this.st.subscribe(this.seachTimer, () => {
            this.fillList();
        });

    }
    public fillList() {
        let tempDate: Date = Convert.ToDateTime(this.Model.EndDate); //new Date(this.Model.EndDate.getVarDate());
        let tempStartDate: Date = Convert.ToDateTime(this.Model.StartDate); // new Date(this.Model.StartDate.getVarDate());
        tempDate = tempDate.AddDays(-1 * this.Model.WorkListMaxDayToSearch);
        if (!this.chkOutPatient.Value && !this.chkInPatient.Value && !this.chkDailyInpatient.Value) {
            ServiceLocator.MessageService.showError(i18n("M11299", "Ayaktan', 'Yatan' ya da 'Günübirlik' seçeneklerinden en az birini seçiniz."));
        }
        else if ((this.Model.txtPatient == null || this.Model.txtPatient == "") && tempDate > tempStartDate) {
            ServiceLocator.MessageService.showError("İş Listesi Kriterlerinden 'Başlangıç Tarihi' ve 'Bitiş Tarihi' arası " + this.Model.WorkListMaxDayToSearch.toString() + " günden fazla iken sorgulama yapılamaz.");
        }
        else {
            //this.workListGrid.instance.clearFilter();
            //this.workListGrid.instance.clearSelection();
            //if (this.systemApiService.componentInfo)
            //    this.closeDynamicComponent();
            this.loadEWorklistPanelOperation(true, i18n("M15370", "Hastalar listeleniyor, lütfen bekleyiniz."));
            this.doSearch();
        }
    }

    clientPreScript(): void {
    }

    clientPostScript(state: String) {
    }

    ontxtSEProtocolNoEnterKeyDown(e) {
        //Kabul Numarası girildiyse ayaktan ve yatan checkli gelsin, başlangıç tarihi 1 yıl öncesi olsun
        let sysDate: Date = new Date(Date.now());
        if (this.txtSEProtocolNo.Text) {
            let endDate: Date = Convert.ToDateTime(this.Model.EndDate); // new Date(this.Model.EndDate.getVarDate());
            this.Model.StartDate = Convert.ToDateTime(endDate.AddMonths(-12)); //new Date((endDate.AddMonths(-12)).getVarDate());
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = true;
            this.chkDailyInpatient.Value = true;
        }
        else {
            this.Model.StartDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 0, 0, 0);
            this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = false;
            this.chkDailyInpatient.Value = false;
        }
        this.btnListele_Click();
    }

    btnListele_Click() {
        if (this.Model.autoRefreshWorkList) {
            if (this.st.getTimer().length == 0) {
                if (this.Model) {
                    if (this.Model.timerPeriod) {
                        this.timerperiod = this.Model.timerPeriod;
                    }

                }
                this.st.newTimer(this.seachTimer, this.timerperiod);
            }
            this.subscribeTimer();
        }
        else
            this.fillList();
    }

    //btnSelectAllResources_Click() {
    //    this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
    //    this.Model.SelectedUserResourceItems = this.Model.UserResourceItems;
    //}

    //btnClearSelection_Click() {
    //    this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
    //}

    async btnSpecialPanelKaydet_Click(): Promise<void> {
        //if (this.Model.LastSelectedSpecialPanel != null && this.Model.LastSelectedSpecialPanel.Name == "@DEFAULT@" && this.Model.LastSelectedSpecialPanelCaption == "<Varsayılan>") {
        //    ServiceLocator.MessageService.showError("'<Varsayılan>' özel panelini değiştiremezsiniz. Lütfen yeni bir özel panel ismi giriniz.");
        //    //TTVisual.InfoBox.Alert("'<Varsayılan>' özel panelini değiştiremezsiniz. Lütfen yeni bir özel panel ismi giriniz.");
        //}
        if (this.Model.LastSelectedSpecialPanel && !this.Model.LastSelectedSpecialPanel.User && this.Model.LastSelectedSpecialPanelCaption == this.Model.LastSelectedSpecialPanel.Caption) {
            ServiceLocator.MessageService.showError("'" + this.Model.LastSelectedSpecialPanel.Caption + i18n("M20100", " özel panelini değiştiremezsiniz. Lütfen yeni bir özel panel ismi giriniz."));
        }
        else {
            let specialPanelInputDVO = new SpecialPanelInputDVO();
            specialPanelInputDVO.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;
            specialPanelInputDVO.SelectedWorkListItems = this.Model.SelectedEpisodeActionWorkListItems;
            specialPanelInputDVO.SelectedWorkListStateItems = this.Model.SelectedEpisodeActionWorkListStateItems;
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


    async btnSpecialPanelSil_Click(): Promise<void> {
        //if (this.Model.LastSelectedSpecialPanel != null && this.Model.LastSelectedSpecialPanel.Name == "@DEFAULT@" && this.Model.LastSelectedSpecialPanelCaption == "<Varsayılan>") {
        //    ServiceLocator.MessageService.showError("'<Varsayılan>' özel panelini silemezsiniz.");
        //}
        if (this.Model.LastSelectedSpecialPanel && !this.Model.LastSelectedSpecialPanel.User) {
            ServiceLocator.MessageService.showError("'" + this.Model.LastSelectedSpecialPanel.Caption + i18n("M20101", " özel panelini silemezsiniz."));
        }
        else {
            let specialPanelInputDVO = new SpecialPanelInputDVO();
            specialPanelInputDVO.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;
            specialPanelInputDVO.SelectedWorkListItems = this.Model.SelectedEpisodeActionWorkListItems;
            specialPanelInputDVO.SelectedWorkListStateItems = this.Model.SelectedEpisodeActionWorkListStateItems;
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

    public getTriageColor(event): string {

        if (event != null) {
            if (event == "1") {
                return "#84e684";
            }
            else if (event == "2") {
                return "#f1f10b";
            }
            else if (event == "3") {
                return "#ffa5a5";
            }
            else if (event == "4") {
                return "#756c6c";
            }
            else {
                return "#ffffff";
            }
        }
        else {
            return "#ffffff";
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

        this.Model.PatientStatus = "";

        if (this.chkOutPatient.Value == true && this.chkInPatient.Value == true && this.chkDailyInpatient.Value == true)
            this.Model.PatientStatus = "0,1,2,3";
        else {
            if (this.chkOutPatient.Value == true)
                this.Model.PatientStatus += "0,";
            if (this.chkInPatient.Value == true)
                this.Model.PatientStatus += "1,2,";
            if (this.chkDailyInpatient.Value == true)
                this.Model.PatientStatus += "3,";

           this.Model.PatientStatus = this.Model.PatientStatus.substring(0 , this.Model.PatientStatus.lastIndexOf(","));
        }
        inputDvo.PatientStatus = this.Model.PatientStatus;
        inputDvo.SelectedWorkListItems = this.Model.SelectedEpisodeActionWorkListItems;
        inputDvo.SelectedWorkListStateItems = this.Model.SelectedEpisodeActionWorkListStateItems;
        //inputDvo.WorkListItems = this.Model.EpisodeActionWorkListItems;
        //inputDvo.WorkListStateItems = this.Model.EpisodeActionWorkListStateItemsAll;
        inputDvo.UserResourceItems = this.Model.UserResourceItems;
        inputDvo.SelectedUserResourceItems = this.Model.SelectedUserResourceItems;
        inputDvo.activeResUserObjectID = this.activeResUserObjectID;
        inputDvo.userSelectedOutPatientResource = this.activeUserService.SelectedOutPatientResource;
        inputDvo.userSelectedInPatientResource = this.activeUserService.SelectedInPatientResource;
        inputDvo.userSelectedSecMasterResource = this.activeUserService.SelectedSecMasterResource;
        inputDvo.SelectedStateTypes = this.Model.SelectedStateTypes;
        inputDvo.SelectedStateTypesEM = this.Model.SelectedStateTypesEM;
        //inputDvo.LastSelectedSpecialPanel = this.Model.LastSelectedSpecialPanel;
        if (!this.chkOutPatient.Value && !this.chkInPatient.Value && !this.chkDailyInpatient.Value)
            return;
        let that = this;
        let fullApiUrl: string = "api/EpisodeActionWorkListService/Query";
        let body = inputDvo;
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        await this.httpService.post<EpisodeActionWorkListFormViewModel>(fullApiUrl, body).then(response => {
            let result = <EpisodeActionWorkListFormViewModel>response;
            if (result) {
                this.Model.EpisodeActionList = result.EpisodeActionList;
                this.Model.txtPatient = result.txtPatient;
                this.Model.StartDate = result.StartDate;
                this.Model.EndDate = result.EndDate;
                this.Model.ID = result.ID;
                this.Model.WorkListCount = result.WorkListCount;
                this.Model.StateType = result.StateType;
                this.Model.SelectedStateTypes = result.SelectedStateTypes;
                this.Model.SelectedStateTypesEM = result.SelectedStateTypesEM;
                this.Model.PatientStatus = result.PatientStatus;
                this.Model.maxWorklistItemCount = result.maxWorklistItemCount;
                this.loadEWorklistPanelOperation(false, '');
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);

            this.loadEWorklistPanelOperation(false, '');
        });
    }

    async setSelectedUserResourceList() {
        this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
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

    async getMenuList() {
        let that = this;
        await this.httpService.get<MenuOutputDVO>("api/EpisodeActionWorkListService/GetEpisodeActionMenuDefinition").then(response => {
            let output = <MenuOutputDVO>response;
            if (output) {
                that.Model.EpisodeActionWorkListItems = output.WorkListSearchItem;
                that.Model.EpisodeActionWorkListStateItemsAll = output.WorkListSearchStateItem;
                that.Model.StartDate = output.StartDate;
                that.Model.EndDate = output.EndDate;
                that.Model.WorkListMaxDayToSearch = output.WorkListMaxDayToSearch;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }

    async getStateList(value: any) {
        if (value) {
            let that = this;
            await that.httpService.post<StateOutputDVO>("api/EpisodeActionWorkListService/GetEpisodeActionStateDefinition", value).then(response => {
                let output = <StateOutputDVO>response;
                that.Model.EpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
                if (output)
                    that.Model.EpisodeActionWorkListStateItems = output.WorkListSearchStateItem;
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
    }

    async getLCDNotificationList() {
        
            let that = this;
            await that.httpService.get<LCDNotificationOutputDVO>("api/EpisodeActionWorkListService/GetLCDNotificationDefinition").then(response => {
                let output = <LCDNotificationOutputDVO>response;
                that.Model.LCDNotificationList = new Array<LCDNotificationDefinition>();
                if (output) {
                    that.Model.LCDNotificationList = output.LCDNotificationList;
                    that.Model.isNewLcd = output.isNewLcd;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
      
    }

    async select(value: any): Promise<void> {

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 700)) {

            this.loadEWorklistPanelOperation(true, 'İşlemler listeleniyor, lütfen bekleyiniz.');

            //if (!e && !e.selectedRowsData) {
            //    return;
            //}
            //if (e.selectedRowsData instanceof Array) {
            //    let rowDataArray = e.selectedRowsData as Array<any>;
            //    if (rowDataArray.length > 0) {
            //        const selectedRowData = rowDataArray[0];

            //        if (this.selectedRowData) {
            //            const selectedObjectJson = JSON.stringify(this.selectedRowData);
            //            const targetSelectedObjectJson = JSON.stringify(selectedRowData);
            //            if (selectedObjectJson === targetSelectedObjectJson) {
            //                return;
            //            }
            //        }
            //    }


            //}
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
                    this.loadEWorklistPanelOperation(false, '');
                    return;
                }
            }

            this.selectedRowData = value;
            let selectedModel: EpisodeActionWorkListItemModel = value.data as EpisodeActionWorkListItemModel;

            if (selectedModel.ObjectDefName == "HEALTHCOMMITTEE" && selectedModel.CurrentStateDefID == HealthCommittee.HealthCommitteeStates.Cancelled.toString()) {
                // that.messageService.showError("İptal Edilmiş Sağlık Kurulu Formlarını Görüntüleyemezsiniz");
                TTVisual.InfoBox.Alert("İptal Bilgisi",selectedModel["ReasonOfCancel"],MessageIconEnum.InformationMessage);
                this.loadEWorklistPanelOperation(false, '');

            }
            else{
                if (selectedModel)
                    this.openDynamicComponent(selectedModel.ObjectDefName, selectedModel.ObjectID);
            }

        }
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
            this.selectedEpisodeActionId = objectID;
        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
            });
        }
    }

    closeDynamicComponent() {
        this.systemApiService.componentInfo = null;
        this.selectedEpisodeActionId = "";
    }

    async selectIfSingleEpisodeAction(): Promise<void> {
        if (this.Model.EpisodeActionList != null && this.Model.EpisodeActionList.length > 0) {
            this.openDynamicComponent(this.Model.EpisodeActionList[0].ObjectDefName, this.Model.EpisodeActionList[0].ObjectID);
        }
    }



    //Hasta Çağrı//////////////////////////////////////////////////////

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

    public async setQueue(data: ExaminationQueueDefinition) {
        let attt: ExaminationQueueDefinitionParamClass = new ExaminationQueueDefinitionParamClass();
        attt.selectedQueue = data;
        attt.outResourceId = this.activeUserService.SelectedOutPatientResource.ObjectID;
        attt.currentResourceId = this.activeUserService.ActiveUser.UserObject.ObjectID;
        let apiUrl: string = '/api/CommonService/SetQueue';
        let x = await this.httpService.post<ExaminationRetunClass>(apiUrl, attt);
        return x;

    }

    public async setPatientStatusParam(data: SetPatientStatusParam): Promise<any> {
        let attt: SetPatientStatusParam = new SetPatientStatusParam();
        attt = data;
        let apiUrl: string = '/api/CommonService/SetPatientStatus';
        this.httpService.post<any>(apiUrl, attt).then(
            x => {
            }
        );


    }

    examinationRetunClass: ExaminationRetunClass = new ExaminationRetunClass();
    private async Callpatient(): Promise<void> {
        if (!this.activeUserService.SelectedQueue)
            this.getQueueList();
        if (this.activeUserService.SelectedQueue == undefined && this.queueList.length == 0) {
            await CommonService.openUserResourceSelectionView();
        }

        if (this.activeUserService.SelectedQueue == null) {
            if (this.queueList.length === 1)
                this.activeUserService.SelectedQueue = this.queueList[0];
            else {
                let pMSForm: MultiSelectForm = new MultiSelectForm();
                for (let queue of this.queueList) {
                    pMSForm.AddMSItem(queue.Name, queue.ObjectID.toString(), queue);
                }
                let sKey: string;
                sKey = await pMSForm.GetMSItem(this, i18n("M12304", "Çalışacağınız kuyruğu seçiniz."), false, true, false, false, true, true);
                if (sKey != "") {
                    this.activeUserService.SelectedQueue = <ExaminationQueueDefinition>pMSForm.MSSelectedItemObject;
                }
            }
        }
        if (this.activeUserService.SelectedQueue != null) {
            let that = this;
            that.examinationRetunClass = await that.setQueue(that.activeUserService.SelectedQueue);
            let nextItemsCount: number;
            let result: string = "";
            if (that.examinationRetunClass.examinationQueueItem.NextItemsCount > 0) {
                nextItemsCount = that.examinationRetunClass.examinationQueueItem.NextItemsCount.Value;
                result = await ShowBox.Show(ShowBoxTypeEnum.Message, i18n("M15217", "Hasta Gelsin,Ertele"), "G,E", i18n("M21820", "Sıradaki Hasta"), i18n("M21820", "Sıradaki Hasta"), that.examinationRetunClass.RefNo + " " + that.examinationRetunClass.FullName + i18n("M10038", "\r\n\r\nKalan Hasta Sayısı : ") + nextItemsCount.toString(), 1);
            }
            else {
                result = await ShowBox.Show(ShowBoxTypeEnum.Message, i18n("M15217", "Hasta Gelsin,Ertele"), "G,E", i18n("M21820", "Sıradaki Hasta"), i18n("M21820", "Sıradaki Hasta"), that.examinationRetunClass.RefNo + " " + that.examinationRetunClass.FullName, 1);
            }
            let audio = new Audio();
            let currentLocation = window.location.href.replace("/islistesi", "");
            audio.src = currentLocation + "/Content/doorbell.wav";
            audio.load();
            audio.play();
            let param: SetPatientStatusParam = new SetPatientStatusParam();
            param.result = result;
            param.examinationQueueItem = that.examinationRetunClass.examinationQueueItem;
            that.setPatientStatusParam(param);
        }

    }

    async OpenLcdMonitor() {
        if (!this.activeUserService.SelectedQueue)
            this.getQueueList();
        if (this.activeUserService.SelectedQueue == undefined && this.queueList.length == 0) {
            await CommonService.openUserResourceSelectionView();
        }

        if (this.activeUserService.isPoolQueue) {
            this.openEmergencyLcd();
        }
        else {
            //let isnewlcd = await SystemParameterService.GetParameterValue('ISNEWLCD', 'FALSE');
            if (this.Model.isNewLcd == "FALSE") {
                try {

                    let names: any = this.activeUserService.ActiveUser.UserObject;
                    let doktorName = names.Name.toString();
                    let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
                    let currentLocation = window.location.href.replace("/islistesi", "");
                    let url = currentLocation + "/PatientCaller/HastaCagriForm2?currentResUserID=00000000-0000-0000-0000-000000000000&outPatientResID=" + outPatientResID + "&includeCalleds=false&doktorName=" + doktorName;
                    let input: any = { Url: encodeURI(url) };
                    console.log(input);
                    let httpPrintServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
                    this.httpService.post(httpPrintServiceUrl, input);
                    sessionStorage.setItem('isLCDOpened', 'true');

                }
                catch (e) {
                    sessionStorage.setItem('isLCDOpened', 'false');

                }
            } else {
                try {
                    let names: any = this.activeUserService.ActiveUser.UserObject;
                    let doktorName = names.Name.toString();
                    let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
                    let currentLocation = window.location.href.replace("/islistesi", "");
                    let httpPrintServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
                    let polLCDOnlyCalledPatient = await SystemParameterService.GetParameterValue('POLICLINICLCDONLYCALLEDPATIENT', 'TRUE');
                    let url;
                    if (polLCDOnlyCalledPatient == "TRUE") {
                        url = currentLocation + "/lcd/polLcdCalledPatientForm?showAsAnonymous&IDS=" + outPatientResID + "&DrName=" + doktorName + "&DrObjectID=" + this.activeUserService.ActiveUser.UserObject.ObjectID;
                    }
                    else {
                        url = currentLocation + "/lcd/policlinicLcdForm?showAsAnonymous&IDS=" + outPatientResID + "&DrName=" + doktorName + "&DrObjectID=" + this.activeUserService.ActiveUser.UserObject.ObjectID;
                    }
                    let input: any = { Url: encodeURI(url) };
                    console.log(input);
                    this.httpService.post(httpPrintServiceUrl, input);
                    sessionStorage.setItem('isLCDOpened', 'true');

                }
                catch (e) {
                    sessionStorage.setItem('isLCDOpened', 'false');

                }
            }
        }
    }

    openEmergencyLcd() {
        let names: any = this.activeUserService.ActiveUser.UserObject;
        let doktorName = names.Name.toString();
        let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
        let currentLocation = window.location.href.replace("/islistesi", "");
        let url = currentLocation + "/lcd/emergenyCallPatientForm?showAsAnonymous&IDS=" + outPatientResID + "&DrName=" + doktorName + "&DrObjectID=" + this.activeUserService.ActiveUser.UserObject.ObjectID;
        let input: any = { Url: encodeURI(url) };
        console.log(input);
        let httpServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
        this.httpService.post(httpServiceUrl, input);
        sessionStorage.setItem('isLCDOpened', 'true');
    }

    openInNewTab(url) {
        if (url == null) {
            //InfoBox.Alert("Bu hizmetin sonucu bulunamadı!");
        } else {
            let win = window.open(url, '_blank');
            win.focus();
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
                },
                    {
                        text: i18n("M15531", "Açıklama ile Hastayı Çağır"),
                        disabled: false,
                        onItemClick: function () {

                            that.CallSelectedPatientByDesc(e.row.data);
                        }
                    }
                ];
            }
        }
    }

    showCallSelectedPatientByDesc = false;
    public PatientCallDesc: Object;
    public PatientCallDescTemplate: string = "Hasta Çağrı Açıklama";
    currentRowData: any;
    public onPatientCallDescChanged(event): void {
        if (event != null) {
                this.PatientCallDesc = event;
        }
    }

    async popCallSelectedPatientByDesc(data: any) {
        if (!this.PatientCallDesc) {
            ServiceLocator.MessageService.showError("Lütfen açıklama giriniz");
        }
        else if (!CommonHelper.getInnerText(this.PatientCallDesc.toString()))
        {
            ServiceLocator.MessageService.showError("Lütfen açıklama giriniz");
        }
        else {
            this.showCallSelectedPatientByDesc = false;
            await this.CallSelectedPatient(this.currentRowData);
        }
    }

    async cancelCallSelectedPatientByDesc() {
        this.showCallSelectedPatientByDesc = false;
    }

    async CallSelectedPatientByDesc(data: any) {
        try {
            this.showCallSelectedPatientByDesc = true;
            this.currentRowData = data;
        }
        catch (e) { this.unloadCompComponent(); }
    }

    async CallSelectedPatient(data: any) {
        try {
            //
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
            attt.ObjectId = data.ObjectID;
            let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
            attt.outPatientResID = new Guid(outPatientResID);
            attt.OrderNo = data.QueueNumberToSort;
            if (this.PatientCallDesc)
                attt.PatientCallDesc = CommonHelper.getInnerText(this.PatientCallDesc.toString());
            let apiUrl: string = '/api/CommonService/CallSelectedPatient';
            this.httpService.post<any>(apiUrl, attt).then(
                x => {
                    this.Model.LCDNotification = null;
                    this.showLCDNotificationForm = false;
                    this.openDynamicComponent(data.ObjectDefName, data.ObjectID);
                    this.PatientCallDesc = null;
                    this.currentRowData = null;
                }
            ).catch(error => {
                //ServiceLocator.MessageService.showError(error);
                TTVisual.InfoBox.Alert("Uyarı", error, MessageIconEnum.ErrorMessage);
                this.unloadCompComponent();
            });
        }
        catch (e) { this.unloadCompComponent(); }
    }

    //////////////////////////////////////////////////////////////////


    async episodeActionWorkListItemsSelectionChanged() {
        this.Model.SelectedEpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
        await this.getStateList(this.Model.SelectedEpisodeActionWorkListItems);
    }

    async episodeActionWorkListStateItemsSelectionChanged() {
        if (this.Model.SelectedEpisodeActionWorkListStateItems && this.Model.SelectedEpisodeActionWorkListStateItems.length > 0) {
            this.Model.SelectedStateTypes = new Array<string>();
            this.Model.SelectedStateTypesEM = new Array<string>();
        }
        else {
            if (this.Model.txtPatient == null || this.Model.txtPatient == "") {
                this.Model.SelectedStateTypes = new Array<string>();
                this.Model.SelectedStateTypesEM = new Array<string>();
                this.Model.SelectedStateTypes.push("UNCOMPLETED");
                this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
            }
        }
    }

    async userResourceItemsSelectionChanged() {

    }

    saveGridColumn() {
        let visibleSEPSearchResultListColumns = this.workListGrid.instance.getVisibleColumns();


        let sgcm = [];
        let oneGrid: any = {};
        let transColumnArray = [];
        for (let item of visibleSEPSearchResultListColumns) {
            transColumnArray.push(item.dataField);
        }
        oneGrid.PageName = "EpisodeActionWorkListForm";
        oneGrid.GridName = "workListGrid";
        oneGrid.ColumnNameList = transColumnArray;
        sgcm.push(oneGrid);


        let apiUrlForUserCustomizationKayit: string = '/api/InvoiceApi/SaveUserBasedGridColumnCustomization';

        this.httpService.post(apiUrlForUserCustomizationKayit, sgcm).then(response => {
            ServiceLocator.MessageService.showSuccess(i18n("M17905", "Kullanıcı Liste Özelleştirmeleri Kayıt Edildi."));
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });
    }

    //txtSEProtocolNoOnFocusOut(txt: string) {
    //    //Kabul Numarası girildiyse ayaktan ve yatan checkli gelsin, başlangıç tarihi 1 yıl öncesi olsun
    //    let sysDate: Date = new Date(Date.now());
    //    if (this.txtSEProtocolNo.Text) {
    //        let endDate: Date = Convert.ToDateTime(this.Model.EndDate); // new Date(this.Model.EndDate.getVarDate());
    //        this.Model.StartDate = Convert.ToDateTime(endDate.AddMonths(-12)); //new Date((endDate.AddMonths(-12)).getVarDate());
    //        this.chkOutPatient.Value = true;
    //        this.chkInPatient.Value = true;
    //    }
    //    else {
    //        this.Model.StartDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 0, 0, 0);
    //        this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
    //        this.chkOutPatient.Value = true;
    //        this.chkInPatient.Value = false;
    //    }
    //}
    patientChanged(patient: any) {
        let sysDate: Date = new Date(Date.now());
        if (patient) {
            this.Model.txtPatient = patient.ObjectID;
            this.Model.SelectedStateTypes = new Array<string>();
            this.Model.SelectedStateTypesEM = new Array<string>();
            this.Model.SelectedEpisodeActionWorkListItems = new Array<EpisodeActionWorkListItem>();
            this.Model.SelectedEpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
            this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.Model.StartDate = Convert.ToDateTime(this.Model.EndDate.AddMonths(-6)); // new Date(this.Model.EndDate.AddMonths(-6).getVarDate());
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = true;
            this.chkDailyInpatient.Value = true;
            this.btnListele_Click();
        }
        else {
            this.Model.txtPatient = "";
            this.Model.SelectedStateTypes = new Array<string>();
            this.Model.SelectedStateTypesEM = new Array<string>();
            this.Model.SelectedStateTypes.push("UNCOMPLETED");
            this.Model.SelectedStateTypesEM.push("UNCOMPLETED");
            this.Model.EndDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 23, 59, 59);
            this.Model.StartDate = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), 0, 0, 0);
            this.chkOutPatient.Value = true;
            this.chkInPatient.Value = false;
        }

    }

    changed(e: any): void {
        alert(e);
    }


    async getSpecialPanelList(): Promise<void> {
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

    async loadSpecialCriteria(data: SpecialPanelListItem) {
        if (typeof data == 'object') {
            this.Model.LastSelectedSpecialPanel = data;
            this.Model.SelectedEpisodeActionWorkListItems = new Array<EpisodeActionWorkListItem>();
            this.Model.SelectedEpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
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

                if (this.Model.SelectedEpisodeActionWorkListItems.length > 0) {
                    await this.getStateList(this.Model.SelectedEpisodeActionWorkListItems); //.then(() => {
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
                }
                else {
                    this.Model.SelectedEpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
                }
            }
            else {
                this.Model.SelectedEpisodeActionWorkListItems = new Array<EpisodeActionWorkListItem>();
                this.Model.SelectedEpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
            }

        }
    }

    async SelectObjectDefinition(objectDefID: string) {
        let episodeActionWorkListItem = this.Model.EpisodeActionWorkListItems.find(o => o.ObjectDefID === objectDefID);
        if (episodeActionWorkListItem) {
            if (!this.Model.SelectedEpisodeActionWorkListItems)
                this.Model.SelectedEpisodeActionWorkListItems = new Array<EpisodeActionWorkListItem>();
            this.Model.SelectedEpisodeActionWorkListItems.push(episodeActionWorkListItem);
        }
    }

    async SelectState(stateDefID: string) {
        let episodeActionWorkListStateItem = this.Model.EpisodeActionWorkListStateItems.find(s => s.StateDefID === stateDefID);
        if (episodeActionWorkListStateItem) {
            if (!this.Model.SelectedEpisodeActionWorkListStateItems)
                this.Model.SelectedEpisodeActionWorkListStateItems = new Array<EpisodeActionWorkListStateItem>();
            if (this.Model.SelectedEpisodeActionWorkListStateItems.findIndex(x => x.StateDefID == stateDefID) == -1)
                this.Model.SelectedEpisodeActionWorkListStateItems.push(episodeActionWorkListStateItem);
        }
    }

    async SelectUserResource(resourceID: string) {
        let userResourceItem = this.Model.UserResourceItems.find(s => s.ResourceID === resourceID);
        if (userResourceItem) {
            if (!this.Model.SelectedUserResourceItems)
                this.Model.SelectedUserResourceItems = new Array<UserResourceItem>();
            if (this.Model.SelectedUserResourceItems.findIndex(x => x.ResourceID == resourceID) == -1)
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
                // row.rowElement.firstItem().css('background-color', row.data.RowColor);
                this.renderer.setStyle(row.rowElement.firstItem(), "background-color", row.data.RowColor);
            }
            if (row.data.StateName != null) {
                let rowValue = row.data.StateName.toString();
                if (row.data.TriageCode != null) {
                    let triajCode = row.data.TriageCode.toString();
                    if (rowValue == "Muayene" || rowValue == "Acil Muayenede") {
                        //row.rowElement.firstItem().css('background-color', this.getTriageColor(triajCode));
                        this.renderer.setStyle(row.rowElement.firstItem(), "background-color", this.getTriageColor(triajCode));
                    }
                }
            }
        }
    }

    //#region Yeni İş Listesi Fonksiyonları

    @ViewChild('searchAndListAccordion') searchAndListAccordion: DxAccordionComponent; // yukardan  ve  arama kriterleri ile listeyi içeren akordion

    public accordionContainerHeight;
    public composeComponentRowContainerVisible = { 'display': 'none' };

    public accordionClick(event: any) {
        // console.log(event);
        let that = this;
        if (that.searchAndListAccordion.selectedIndex == -1) {
            setTimeout(function () {
                that.composeComponentRowContainerVisible = { 'display': 'none' };
                that.accordionContainerHeight = that.setAccordionRowCotainerHeight('100%');
            }, 50);
        }
        else {
            setTimeout(function () {
                that.composeComponentRowContainerVisible = { 'display': 'block' };
                that.accordionContainerHeight = that.setAccordionRowCotainerHeight('5%');
            }, 50);
        }
    }

    public dynamicComponentCreated(e: any) {
        //this.loadSearchingPanel();
        this.loadEWorklistPanelOperation(true, 'İşlemler listeleniyor, lütfen bekleyiniz.');
        let that = this;
        that.RepaintWorkListGrid();
        that.close_searchAndListAccordion();
    }

    public dynamicComponentClosed(e: any) {
        this.unloadCompComponent();
        let that = this;
        setTimeout(function () {
            if (this.WorkListGrid != null && this.WorkListGrid.instance != null && this.WorkListGrid.instance["_disposed"] == null) {//iş listesini açıp sonra başka iş listesine geçersen  compnenlar dispose olduğu için  _disposed null olmuyor hata veriyor
                this.WorkListGrid.instance.repaint();
            }
        }, 30);
        that.open_searchAndListAccordion();
    }

    public dynamicComponentViewModelLoaded(viewModel: any): void {

        this.unloadCompComponent();
    }

    public RepaintWorkListGrid() {
        setTimeout(function () {
            if (this.WorkListGrid != null && this.WorkListGrid.instance != null) {
                this.WorkListGrid.instance.repaint();
            }
        }, 30);
    }

    open_searchAndListAccordion() {
        let that = this;
        setTimeout(function () {
            that.accordionContainerHeight = that.setAccordionRowCotainerHeight('100%');
            that.composeComponentRowContainerVisible = { 'display': 'none' };
            if (that.searchAndListAccordion)
                that.searchAndListAccordion.selectedIndex = 0;
        }, 50);
    }
    close_searchAndListAccordion() {
        let that = this;
        setTimeout(function () {
            that.accordionContainerHeight = that.setAccordionRowCotainerHeight('5%');
            that.composeComponentRowContainerVisible = { 'display': 'block' };
            if (that.searchAndListAccordion)
                that.searchAndListAccordion.selectedIndex = -1;
        }, 50);
    }

    // ***** Yukardan accordiyonlu  Property ve Methodlar end *****
    setAccordionRowCotainerHeight(height: string) {
        return {
            'height': height
        }
    }

    unloadCompComponent(): void {
        this.loadEWorklistPanelOperation(false, '');
    }

    public onMHRSAppointmentsReport(event) {

        let currentDate: Date = new Date(Date.now());
        let sdate: Date = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate(), 0, 0, 0, 0);
        let edate: Date = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate(), 23, 59, 59, 0);
        let masterResource : GuidParam = new GuidParam();
        if(this.activeUserService.SelectedOutPatientResource){
            masterResource = new GuidParam(this.activeUserService.SelectedOutPatientResource.ObjectID.toString()) ;
        }
        let resource : GuidParam = new GuidParam();
        if(this.activeUserService.ActiveUser.UserObject)
        {
            resource =new GuidParam(this.activeUserService.ActiveUser.UserObject.ObjectID.toString());
        }
        let reportParameters: any = { 'MASTERRESOURCE': masterResource,'RESOURCE': resource, 'STARTDATE': new DateParam(sdate), 'ENDDATE': new DateParam(edate) };

        this.reportService.showReport('MHRSAppointmentsReport', reportParameters);
    }

   
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let onMHRSAppointmentsReport = new DynamicSidebarMenuItem();
        onMHRSAppointmentsReport.key = 'onMHRSAppointmentsReport';
        onMHRSAppointmentsReport.icon = 'fa fa-file-text-o';
        onMHRSAppointmentsReport.label = "MHRS Randevu Listesi(Poliklinik ve Doktora göre)";
        onMHRSAppointmentsReport.componentInstance = this;
        onMHRSAppointmentsReport.clickFunction = this.onMHRSAppointmentsReport;
        this.sideBarMenuService.addMenu('ReportMainItem', onMHRSAppointmentsReport);

        if (this.Model.isNewLcd == "TRUE") {
            let SetLCDNotification = new DynamicSidebarMenuItem();
            SetLCDNotification.key = 'SetLCDNotification';
            SetLCDNotification.icon = 'fa fa-file-text-o';
            SetLCDNotification.label = "LCD Bilgi Ekle";
            SetLCDNotification.componentInstance = this;
            SetLCDNotification.clickFunction = this.SetLCDNotification;
            this.sideBarMenuService.addMenu('YardimciMenu', SetLCDNotification);
        }
    }


    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('onMHRSAppointmentsReport');
        if (this.Model.isNewLcd == "TRUE")
            this.sideBarMenuService.removeMenu('SetLCDNotification');
    }
    //#endregion Yeni İş Listesi Fonksiyonları

    showLCDNotificationForm = false;
    public async SetLCDNotification() {
        // this.loadSearchingPanel();
        if (!this.activeUserService.SelectedQueue)
            this.getQueueList();
        if (this.activeUserService.SelectedQueue == undefined && this.queueList.length == 0) {
            await CommonService.openUserResourceSelectionView();
        }
        let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
        await CommonService.GetLCDNotification(outPatientResID, this.activeUserService.ActiveUser.UserObject.ObjectID).then(response => {
            if (response) {
                if (this.Model.LCDNotificationList.length > 0) {
                    let listItem: LCDNotificationDefinition = this.Model.LCDNotificationList.find(o => o.ObjectID.toString() === response.ObjectID.toString());
                    this.Model.LCDNotification = listItem;
                }
                else
                    this.Model.LCDNotification = null;
            }
            else
                this.Model.LCDNotification = null;
            //this.Model.LCDNotification = <LCDNotificationDefinition>response;
        });
        //this.Model.LCDNotification = lcdNotification;
        this.showLCDNotificationForm = true;
    }

    async lcdNotificationItemChanged(value: any) {
        if (typeof value == 'object') {
            if (value) {
                let lcdNotification: LCDNotificationDefinition = <LCDNotificationDefinition>value;
                this.Model.LCDNotification = lcdNotification;
            }
            else
                this.Model.LCDNotification = null;
        }
    }

    async popLCDNotification(data: any) {
        this.showLCDNotificationForm = false;
        let queueID = this.activeUserService.SelectedQueue.ObjectID;
        await CommonService.SetLCDNotification(queueID, this.Model.LCDNotification);
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

        this.txtSEProtocolNo = new TTVisual.TTTextBox();
        this.txtSEProtocolNo.Text = "";
        this.txtSEProtocolNo.Name = "txtSEProtocolNo";
        this.txtSEProtocolNo.TabIndex = 10;

        this.chkOutPatient = new TTVisual.TTCheckBox();
        this.chkOutPatient.Value = false;
        this.chkOutPatient.Text = i18n("M11281", "Ayaktan");
        this.chkOutPatient.Title = i18n("M11281", "Ayaktan");
        this.chkOutPatient.Name = "chkOutPatient";
        this.chkOutPatient.TabIndex = 10;

        this.chkInPatient = new TTVisual.TTCheckBox();
        this.chkInPatient.Value = false;
        this.chkInPatient.Text = i18n("M24377", "Yatan");
        this.chkInPatient.Title = i18n("M24377", "Yatan");
        this.chkInPatient.Name = "chkInPatient";
        this.chkInPatient.TabIndex = 10;

        this.chkDailyInpatient = new TTVisual.TTCheckBox();
        this.chkDailyInpatient.Value = false;
        this.chkDailyInpatient.Text = i18n("M27878", "Günübirlik");
        this.chkDailyInpatient.Title = i18n("M27878", "Günübirlik");
        this.chkDailyInpatient.Name = "chkDailyInpatient";
        this.chkDailyInpatient.TabIndex = 10;

    }

    returnTemplateText(data) {
        return i18n("M18284", "Listelenen İşlem Sayısı:") + data.value;
    }

    loadEWorklistPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }
}

export class GetSortedQueueItemsByArray_Input {
    public outPatientResID: Guid;
    public currentResUserID: Guid;
    public includeCalleds: boolean;
}
export class SetPatientStatusParam {
    public result: string;
    public examinationQueueItem: ExaminationQueueItem;
}
export class ExaminationRetunClass {
    public examinationQueueItem: ExaminationQueueItem;
    public RefNo: string;
    public FullName: string;
}
export class ExaminationQueueDefinitionParamClass {
    public selectedQueue: ExaminationQueueDefinition;
    public outResourceId: Guid;
    public currentResourceId: Guid;
}
export class CallNexttPatientParam {
    public ObjectId: Guid;
    public outPatientResID: Guid;
    public OrderNo: number;
    public PatientCallDesc: string;
}