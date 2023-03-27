//$0D23E1A1
import { Component, ViewChild, OnDestroy} from '@angular/core';
import { DietWorkListViewModel, DietWorkListItemModel, DietWorkListSearchCriteria, DietWorkListRaitonSearchCriteria, DietRationCountItem } from './DietWorkListViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CommonService } from "ObjectClassService/CommonService";
import { EpisodeActionWorkListStateItem, StateOutputDVO, EpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ITTObjectListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTObjectListBox';
import { DietOrderDetail, MealTypes } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from "devextreme-angular";
import { DatePipe } from '@angular/common';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { IModalService } from "Fw/Services/IModalService";
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'diet-workList-form',
    templateUrl: './DietWorkListForm.html',
    providers: [SystemApiService, MessageService, DatePipe]
})
export class DietWorkListForm extends BaseComponent<DietWorkListViewModel> implements OnDestroy{

    public dietWorkListViewModel: DietWorkListViewModel = new DietWorkListViewModel();
    public selectedRowKeysResultList: Array<DietWorkListItemModel> = [];
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public DietWorkListStateItems: Array<EpisodeActionWorkListStateItem>;
    public DietRationCountList: Array<DietRationCountItem>;
    public showRationPopup: boolean;
    public _SearchCriteria: DietWorkListRaitonSearchCriteria = new DietWorkListRaitonSearchCriteria();
    public openForm=false;

    public MealTypeList: Array<any> = new Array<any>();
    public SelectedMealTypeList: Array<any> = new Array<any>();
    public StartDate: Date = new Date();
    public EndDatee: Date = new Date();
    public ShowPatientDietListPopup: boolean = false;

    @ViewChild('dietWorkListGrid') dietWorkListGrid: DxDataGridComponent;
    //@ViewChild(DxPopoverComponent) popOver: DxPopoverComponent;

    btnListele: TTVisual.ITTButton;

    cmbPhysicalstateclinic: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'WardListDefinition'
    };

    cmbTreatmentclinic: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'WardListDefinition'
    };

    cmbResponsibledoctor: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'DoctorListDefinition'
    };

    cmbDiettype: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'DietListDefinition'
    };

    public RationGridColumns = [
        {
            caption: i18n("M13038", "Diyet"),
            dataField: "DietName",
            width: "50%",
            allowSorting: true
        },
        {
            caption: "K",
            dataField: "BreakfastCount",
            width: "6%",
            allowSorting: true
        },
        {
            caption: "Ö",
            dataField: "LunchCount",
            width: "6%",
            allowSorting: true
        },
        {
            caption: "A",
            dataField: "DinnerCount",
            width: "6%",
            allowSorting: true
        },
        {
            caption: "G.K",
            dataField: "NightBreakfastCount",
            width: "6%",
            allowSorting: true
        },
        {
            caption: "A1",
            dataField: "Snack1Count",
            width: "6%",
            allowSorting: true
        },
        {
            caption: "A2",
            dataField: "Snack2Count",
            width: "6%",
            allowSorting: true
        },
        {
            caption: "A3",
            dataField: "Snack3Count",
            width: "6%",
            allowSorting: true
        },
        {
            caption: "Toplam",
            dataField: "TotalCount",
            width: "6%",
            allowSorting: true
        }
    ];

    public WorkListColumns = [

        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M13053", "Diyet Tipi"),
            dataField: "DietType",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M13049", "Diyet Tarihi"),
            dataField: "WorkListDate",
            dataType: "date",
            format: "dd/MM/yyyy",
            width: "auto",
            allowSorting: true
        },
        {
            caption: "K",
            dataField: "Breakfast",
            width: 50,
            allowSorting: true
        },
        {
            caption: "Ö",
            dataField: "Lunch",
            width: 50,
            allowSorting: true
        },
        {
            caption: "A",
            dataField: "Dinner",
            width: 50,
            allowSorting: true
        },
        {
            caption: "G.K",
            dataField: "NightBreakfast",
            width: 50,
            allowSorting: true
        },
        {
            caption: "A1",
            dataField: "Snack1",
            width: 50,
            allowSorting: true
        },
        {
            caption: "A2",
            dataField: "Snack2",
            width: 50,
            allowSorting: true
        },
        {
            caption: "A3",
            dataField: "Snack3",
            width: 50,
            allowSorting: true
        },
        {
            caption: i18n("M24432", "Yatış Durumu"),
            dataField: "PatientStatus",
            width: 100,
            allowSorting: true
        },
        {
            caption: i18n("M22986", "Tedavi Gördüğü Klinik"),
            dataField: "TreatmentClinic",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M24457", "Yattığı Klinik"),
            dataField: "PhysicianClinic",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: "Oda No",
            dataField: "Room",
            width: 75,
            allowSorting: true
        },
        {
            caption: i18n("M24365", "Yatak No"),
            dataField: "Bed",
            width: 75,
            allowSorting: true
        },
        {
            caption: i18n("M19680", "Onay Durumu"),
            dataField: "CurrentState",
            width: 75,
            allowSorting: true
        },
        {
            caption: i18n("M10469", "Açıklama"),
            dataField: "OrderDescription",
            dataType: 'string',
            width: '10%',
            allowSorting: false
        }

    ];


    constructor(private sideBarMenuService: ISidebarMenuService,
        protected httpService: NeHttpService, 
        protected messageService: MessageService, 
        protected modalService: IModalService,
        container: ServiceContainer, 
        public systemApiService: SystemApiService) {
        super(container);
        this.initFormControls();

        let _episodeActionWorkListItems: Array<EpisodeActionWorkListItem> = new Array<EpisodeActionWorkListItem>();

        let _episodeActionWorkListItem: EpisodeActionWorkListItem = new EpisodeActionWorkListItem();
        _episodeActionWorkListItem.ObjectDefName = "DIETORDERDETAIL";
        _episodeActionWorkListItem.ObjectDefID = "bb947e4d-9beb-4922-a408-8cf969dcffd7";
        _episodeActionWorkListItems.push(_episodeActionWorkListItem);

        this.getStateList(_episodeActionWorkListItems);

        this._SearchCriteria.workListStartDate = new Date(Date.now());
        this._SearchCriteria.workListEndDate = new Date(Date.now());

        this.dietWorkListViewModel._dietWorkListSearchCriteria.workListStartDate = new Date(Date.now());
        this.dietWorkListViewModel._dietWorkListSearchCriteria.workListEndDate = new Date(Date.now());

        this.dietWorkListViewModel._dietWorkListSearchCriteria.inpatientStatus = false;
    }

    getDietList() {

        let that = this;
        let _SearchCriteria: DietWorkListSearchCriteria = new DietWorkListSearchCriteria();

        that.httpService.post<DietWorkListItemModel[]>("api/DietWorkListService/GetDietActionWorkList", that.dietWorkListViewModel._dietWorkListSearchCriteria)
            .then(response => {
                that.dietWorkListViewModel.DietActionList = response as DietWorkListItemModel[];
            })
            .catch(error => {
                this.messageService.showError(error);

            });

        // });
    }

    async clientPreScript() {
        // let a = this.getDietList();
    }

    clientPostScript(state: String): void {
        // throw new Error('Method not implemented.');
    }

    async select(value: any): Promise<void> {

        //let _data: DietWorkListItemModel = value.selectedRowsData[0] as DietWorkListItemModel;
        //this.openDynamicComponent(_data.ObjectDefName, _data.ObjectID);

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            this.openForm = true;
            this.loadPanelOperation(true, i18n("M14461", "Form hazırlanıyor, lütfen bekleyiniz."));
            let _data: DietWorkListItemModel = value.data as DietWorkListItemModel;
            this.openDynamicComponent(_data.ObjectDefName, _data.ObjectID);
        }

    }

    async selectionChange(value: any): Promise<void> {

        let currentDate: Date = (await CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        let upComingTransactionCount: number = 0; //ileri tarihli işlemler
        let approvedTransactionCount: number = 0; //Onaylanacak statusü dışındaki işlemler

        for (let i = 0; i < value.currentSelectedRowKeys.length; i++) {
            if (value.currentSelectedRowKeys[i].CurrentSateDefID != DietOrderDetail.DietOrderDetailStates.Execution.toString())//"Onayla"
            {
                approvedTransactionCount++;
                value.component.deselectRows(value.currentSelectedRowKeys[i]);
            }
            else if (value.currentSelectedRowKeys[i].WorkListDate > currentDate.setHours(0, 0, 0))
            {
                upComingTransactionCount++;
                value.component.deselectRows(value.currentSelectedRowKeys[i]);
            }
            // value.component.clearSelection();
        }
        if (approvedTransactionCount > 0)
            this.messageService.showInfo(i18n("M19692", "Onayla durumunda olmayan diyetleri onaylayamazsınız."));
        if (upComingTransactionCount > 0)
            this.messageService.showInfo(i18n("M16403", "ileri tarihli diyetleri bugünden onaylayamazsınız."));

    }

    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).then(x => {
                this.loadPanelOperation(false, '');
        });
        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
                //this.selectedEpisodeActionId = c.ParentObjectID.toString();
            });
        }
        //    this.setComponentPatientInfo();

    }

    public approveRecords()
    {
        console.log(this.selectedRowKeysResultList);

        let _objectIDList: Array<string> = [];

        if (this.selectedRowKeysResultList.length == 0) {
            this.messageService.showReponseError(i18n("M19696", "Onaylanacak diyetler seçilmediği için işleme devam edilemedi."));
            return false;
        }

        for (let i = 0; i < this.selectedRowKeysResultList.length ; i++)
        {
            _objectIDList.push(this.selectedRowKeysResultList[i].ObjectID);
        }

        let that = this;
        let _SearchCriteria: DietWorkListSearchCriteria = new DietWorkListSearchCriteria();

        that.httpService.post<any>("api/DietWorkListService/ApproveAllSelectedDietRecordsByID", this.selectedRowKeysResultList)
            .then(response => {
                this.messageService.showSuccess(i18n("M21514", "Seçilen Diyetler Başarılı Bir Şekilde Onaylandı"));
                this.getDietList();
                this.dietWorkListGrid.instance.refresh();
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    public initFormControls(): void {


        this.btnListele = new TTVisual.TTButton();
        this.btnListele.Text = i18n("M27337", "Listele");
        this.btnListele.Name = "btnListele";
        this.btnListele.TabIndex = 12;
    }

    public btnSearchClicked(): void{

        let a = this.getDietList();
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    async getStateList(value: any) {
        let that = this;

        let res = await this.httpService.post("api/EpisodeActionWorkListService/GetEpisodeActionStateDefinition", value);
        let output = <StateOutputDVO>res;
        this.DietWorkListStateItems = output.WorkListSearchStateItem;

    }

    onDietWorkListStateItems(e: any): void {
        this.dietWorkListViewModel._dietWorkListSearchCriteria.dietWorkListStateItem = e.value;
    }


    public onIncludeReported(event): void {
        if (event != null) {
            if (this._SearchCriteria.includeReported != null) {
                this._SearchCriteria.includeReported = event;
            }
        }
    }

    public onadditionalReported(event): void {
        if (event != null) {
            if (this._SearchCriteria.additionalReport != null) {
                this._SearchCriteria.additionalReport = event;
            }
        }
    }

    btnshowPopup()
    {
        this.showRationPopup = true;
        this.DietRationCountList = new Array<DietRationCountItem>();
    }

    async btnGetRationClicked()
    {
        let that = this;

        that.httpService.post<DietRationCountItem[]>("api/DietWorkListService/GetDietOrderDetailRationCount", this._SearchCriteria)
            .then(response => {
                that.DietRationCountList = response as DietRationCountItem[];
            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }

    btnPrintRationReportClicked() {

        let that = this;

        if (that.DietRationCountList == null || that.DietRationCountList.length == 0)
        {
            this.messageService.showInfo(i18n("M20891", "Raporu basmak için önce sorgulama yapmalısınız."));
            return false;
        }

        that.httpService.post<any>("api/DietWorkListService/SetDietOrderDetailIsReported", this._SearchCriteria)
            .then(response => {
             })
            .catch(error => {
                this.messageService.showError(error);
            });
    }

    //onCellHover(e: any) {
    //    if (e.column != null && e.rowType == "data") {
    //        this.popOver.target = e.cellElement;
    //        this.popOver.contentTemplate = e.values[e.columnIndex];
    //        this.popOver.visible = true;
    //    }
    //    else
    //        this.popOver.visible = false;
    //}

    async ngOnInit() {

        this.AddHelpMenu();
    }

    ngOnDestroy() {
        this.RemoveMenuFromHelpMenu();
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        
        let yemekCikanHastaListesi = new DynamicSidebarMenuItem();
        yemekCikanHastaListesi.key = 'yemekCikanHastaListesi';
        yemekCikanHastaListesi.icon = 'fa fa-print';
        yemekCikanHastaListesi.label = "Yemek Çıkan Hasta Listesi";
        yemekCikanHastaListesi.componentInstance = this;
        yemekCikanHastaListesi.clickFunction = this.getMealTypes;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', yemekCikanHastaListesi);
    }

    public RemoveMenuFromHelpMenu(): void {
   
        this.sideBarMenuService.removeMenu('yemekCikanHastaListesi');    
    }

    public getMealTypes() {

        this.MealTypeList=[{ObjectID:1,Name:'Sabah'},{ObjectID:2,Name:'Öğlen'}];
        this.ShowPatientDietListPopup = true;

        // let that = this;
        // this.httpService.get<Array<MealTypes>>("api/DietWorkListService/GetMealTypes")
        //     .then(result => {
        //         that.MealTypeList = result as Array<MealTypes>;
        //         that.ShowPatientDietListPopup = true;

        //     })
        //     .catch(error => {
        //         that.messageService.showError(error);
        //     });
    }

    public generateMealTypeList()
    {
        this.MealTypeList=[
            {ObjectID:1,Name:'Sabah'},
            {ObjectID:2,Name:'Öğlen'},
            {ObjectID:3,Name:'Akşam'},
            {ObjectID:4,Name:'Gece Kahvaltısı'},
            {ObjectID:5,Name:'Ara 1'},
            {ObjectID:6,Name:'Ara 2'},
            {ObjectID:7,Name:'Ara 3'}
        ]
    }

    printYemekCikanHastaListesi() {

        let reportData: DynamicReportParameters = {

            Code: 'YEMEKCIKANHASTA',            
            ReportParams: { BaslangicTarihi: this.StartDate, BitisTarihi: this.EndDatee, OgunListesi: this.SelectedMealTypeList },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "YEMEK ÇIKAN HASTA LİSTESİ"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public onGeneralReportPopupHiding()
    {
        this.ShowPatientDietListPopup = false;        
    }

}



