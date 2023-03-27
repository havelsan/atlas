import { Component, Renderer2 } from '@angular/core';
import { PathologyWorkListViewModel, ListObject} from './PathologyWorkListViewModel';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import DataSource from 'devextreme/data/data_source';
import { BaseEpisodeActionWorkListForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListForm";
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { SimpleTimer } from 'ng2-simple-timer';
import { IModalService } from 'Fw/Services/IModalService';
import { BaseEpisodeActionWorkListFormViewModel, BaseEpisodeActionWorkListItem } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';



@Component({
    selector: 'PathologyWorkListForm',
    templateUrl: './PathologyWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class PathologyWorkListForm extends BaseEpisodeActionWorkListForm {

    public radioGroupPatientTypeItems: any[] = [];
    public ActionTypeList: ListObject[];    
    public ActionTypeResources: DataSource;

    //public ReportStateList: ListObject[];
    //public ReportStateSelections: DataSource;

    //public VoteStatusList: ListObject[];

    //public PageName = "HealthCommitteeWorkListForm";// Kolonlar kullanıcılara göre kaydedilirken Kullanılır 

    //public _dateFormat = "date";

    //public caseOfNeedDrugOrders: Array<CostomDrugOrder>;
    //public selectedTempCaseOfNeedItems: Array<CostomDrugOrder>;
    //public toolbarCaseOfNeedItems: any[];
    //public toolbarItems: any[];

    //public _gridSelectionMode = "";

    //public _gridToolBarItem: any[];
    public radioGroupEAType_Value = 1;
    radioGroupEATypeItems = [
        { text: "Patoloji", value: 1 },
        { text: "Patoloji İstek", value: 2 }
       
    ];

    constructor(protected container: ServiceContainer,
        protected httpService: NeHttpService,
        protected messageService: MessageService,
        public systemApiService: SystemApiService,
        protected activeUserService: IActiveUserService,
        protected st: SimpleTimer,
        protected modalService: IModalService,
        public renderer: Renderer2) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);

        this.radioGroupPatientTypeItems = [
            { text: "Benim Hastalarım", value: 1 },
            { text: "Tüm Hastalar", value: 2 }
        ];

        this.ActionTypeList = [
            {
                TypeName: "Patoloji",
                TypeID: 0
            }, {
                TypeName: "Patoloji İstek",
                TypeID: 1
            }
        ];
        this.ActionTypeResources = new DataSource({
            store: this.ActionTypeList,
            searchOperation: 'contains',
            searchExpr: 'TypeName'
        });
       

    }

    public pathologyWorkListViewModel: PathologyWorkListViewModel = new PathologyWorkListViewModel();

   

    //htmldeki  Listeleme İşlemi ismi hep btnSearchClicked olsun
    fillList() {

        super.fillList();
        let that = this;
        this.loadSearchingPanel();
        that.httpService.post<PathologyWorkListViewModel>("api/PathologyWorkListService/GetPathologyWorkList", that.pathologyWorkListViewModel._SearchCriteria)
            .then(response => {

                let viewModel: PathologyWorkListViewModel = response as PathologyWorkListViewModel;

                that.pathologyWorkListViewModel.WorkList = viewModel.WorkList;// Array < InPatientWorkListItem >
                //that.pathologyWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                that.unloadSearchingPanel();

            })
            .catch(error => {
                that.unloadSearchingPanel();
                that.messageService.showError(error);

            });

    }

    loadViewModel() {

        let that = this;
        let fullApiUrl: string = "/api/PathologyWorkListService/LoadPathologyWorkListViewModel";
        this.httpService.get<PathologyWorkListViewModel>(fullApiUrl)
            .then(response => {
                that.pathologyWorkListViewModel = response as PathologyWorkListViewModel;
                that.ViewModel = response as BaseEpisodeActionWorkListFormViewModel;

                this.pathologyWorkListViewModel._SearchCriteria.pathology_EA = true;
                this.pathologyWorkListViewModel._SearchCriteria.pathologyRequest_EA = false;
                this.pathologyWorkListViewModel._SearchCriteria.PatientType = 1;
                //setTimeout(function () {
                //    that.WorkListGrid.instance.repaint();
                //}, 30);
            })
            .catch(error => {
                console.log(error);
            });

    }

    patientChanged(patient: any) {
        if (patient) {
            this.pathologyWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
            this.btnSearchClicked();
        }
        else
            this.pathologyWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    ngAfterViewInit(): void {
        let that = this;
        super.ngAfterViewInit();
        //setTimeout(function () {
        //    that.WorkListGrid.instance.repaint();
        //}, 30);
    }

    onradioGroupEAType_ValueChanged(e: any) {

        if (e.value == 2) {
            this.pathologyWorkListViewModel._SearchCriteria.pathology_EA = false;
            this.pathologyWorkListViewModel._SearchCriteria.pathologyRequest_EA = true;

        }
        else if (e.value == 1) {
            this.pathologyWorkListViewModel._SearchCriteria.pathology_EA = true;
            this.pathologyWorkListViewModel._SearchCriteria.pathologyRequest_EA = false;
          
        }
    }
    customizeCountText(data) {
        return "Kayıt Sayısı:" + data.value;
    }

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: "İstek Tarihi",
                dataField: "RequestDate",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 'auto',
                allowSorting: true
             
            },
            {
                caption: i18n("M15133", "Hasta Adı Soyadı"),
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: "auto",
                minWidth: 200,
                allowSorting: true
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: "AdmissionProtocolNo",
                dataType: 'string',
                width: 'auto',
                allowSorting: true
            },
            {
                caption: i18n("M22514", "Kimlik Numarası"),
                dataField: "PatientTRID",
                dataType: 'string',
                width: 'auto',
                allowSorting: true
            },
            {
                "caption": "Hasta Türü",
                dataField: "PatientType",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
          
            },
            {
                "caption": "Kabul Birimi",
                dataField: "AdmissionResource",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
            },
            {
                caption: "İşlem",
                dataField: "ActionType",
                dataType: 'string',
                width: '150',
                visible: true,
                allowSorting: true
            }
            ,
            {
                caption: "İşlem Durumu",
                dataField: "ActionState",
                dataType: 'string',
                width: "auto",
                allowSorting: true,

            },
            
           {
                caption: "İstek Yapan Birim",
                dataField: "RequestResource",
                dataType: 'string',
                width: 'auto',
                allowSorting: true
            }


        ];

        super.GenerateResultListColumns(columnNameAndOrder);
    }

    onRowPreparedWorkList(e: any): void {

        //if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' ) {
        if (e.rowElement.firstItem() !== undefined && e.rowType == 'data' && e.rowElement.firstItem() !== undefined) {
            if (e.data.HasFrozen) {
                this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "#FFE3C6");
            }
           

        }
    }
    
   

}

