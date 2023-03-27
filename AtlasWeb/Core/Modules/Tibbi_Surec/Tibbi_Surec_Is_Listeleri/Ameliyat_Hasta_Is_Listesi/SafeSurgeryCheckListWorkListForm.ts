
import { Component, Renderer2, OnInit, ChangeDetectorRef } from '@angular/core';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import DataSource from 'devextreme/data/data_source';
import { SimpleTimer } from 'ng2-simple-timer';
import { IModalService } from 'Fw/Services/IModalService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { CheckListObject, SafeSurgeryChecklistWorkListViewModel, SafeSurgeryChecklistItem } from './SafeSurgeryCheckListWorkListViewModel';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { ListObject } from '../Ayaktan_Hasta_Is_Listesi/ExaminationWorkListViewModel';

@Component({
    selector: 'SafeSurgeryChecklistWorkListForm',
    templateUrl: 'SafeSurgeryCheckListWorkListForm.html',
    providers: [SystemApiService, MessageService, { provide: IESignatureService, useClass: ESignatureService }]
})
export class SafeSurgeryChecklistWorkListForm implements OnInit {

    public ActionNameList: CheckListObject[];
    public selectedActionNameListItems: CheckListObject[];
    public ActionNameResources: DataSource;

    public ActionStateList: CheckListObject[];
    public selectedActionStateListItems: CheckListObject[];
    public ActionStateResources: DataSource;

    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService,
        public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer,
        protected modalService: IModalService, public renderer: Renderer2,
        protected reportService: AtlasReportService, private sideBarMenuService: ISidebarMenuService,
        public signService: IESignatureService,
        private changeDetectorRef: ChangeDetectorRef
    ) {
        this.ActionStateList = [
            {
                TypeName: i18n("M30314", "Tamamlandı (Klinikten Ayrılmadan Önce)"),
                TypeID: 0
            }, {
                TypeName: i18n("M30315", "Tamamlandı (Anestezi Verilmeden Önce)"),
                TypeID: 1
            }, {
                TypeName: i18n("M30316", "Tamamlandı (Ameliyat Kesisinden Önce)"),
                TypeID: 2
            }, {
                TypeName: i18n("M30317", "Tamamlandı (Ameliyattan Çıkmadan Önce)"),
                TypeID: 3
            }
        ];
        this.ActionStateResources = new DataSource({
            store: this.ActionStateList,
            searchOperation: 'contains',
            searchExpr: 'TypeName'
        });

        this.safeSurgeryWorkListViewModel._SearchCriteria.ActionStatus = new Array<CheckListObject>();
        this.selectedActionStateListItems = this.ActionStateList;


    }
    public safeSurgeryWorkListViewModel: SafeSurgeryChecklistWorkListViewModel = new SafeSurgeryChecklistWorkListViewModel();
    public WorkListColumns = [];
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    GenerateWorkListColumns() {
        let that = this;
        this.WorkListColumns = [
            {
                caption: i18n("M15133", "Hasta Adı Soyadı"),
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: 300,
                allowSorting: true
            },
            {
                caption: i18n("M13132", "İstek Tarihi"),
                dataField: "RequestDate",
                dataType: 'date',
                width: 150,
                visible: true,
                allowSorting: true,
                //  cssClass: 'worklistGridCellFont',
            },
            {
                caption: "Tamamlanma Durumu",
                dataField: "CompletedStatus",
                dataType: 'string',
                width: 150,
                visible: true,
                allowSorting: true
            },


        ];

    }


    ngOnInit() {
        // this.OpenLcdMonitor();
        this.GenerateWorkListColumns();
        this.loadViewModel();

    }

    ngOnDestroy() {
    }

    public loadViewModel() {

        let that = this;
        let fullApiUrl: string = "/api/SafeSurgeryChecklistWorkListService/LoadSafeSurgeryWorkListViewModel";
             this.httpService.get<SafeSurgeryChecklistWorkListViewModel>(fullApiUrl)
                 .then(response => {
                     that.safeSurgeryWorkListViewModel = response as SafeSurgeryChecklistWorkListViewModel;
                 })
                 .catch(error => {
                     console.log(error);
                 }); 

    }

    ngAfterViewInit(): void {
    }


    patientChanged(patient: any) {
        if (patient) {
            this.safeSurgeryWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
        }
        else
            this.safeSurgeryWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    fillList() {

        let that = this;
        this.showLoadPanel = true;
        this.LoadPanelMessage = 'İşlemler listeleniyor, lütfen bekleyiniz';
        that.httpService.post<SafeSurgeryChecklistWorkListViewModel>("api/SafeSurgeryChecklistWorkListService/GetChecklistWorkList", that.safeSurgeryWorkListViewModel._SearchCriteria)
            .then(response => {
                let viewModel: SafeSurgeryChecklistWorkListViewModel = response as SafeSurgeryChecklistWorkListViewModel;
                that.safeSurgeryWorkListViewModel.WorkList = viewModel.WorkList;
                this.showLoadPanel = false;
                this.LoadPanelMessage = '';
            })
            .catch(error => {
                this.showLoadPanel = false;
                this.LoadPanelMessage = '';                
                that.messageService.showError(error);

            });
    }

    async select(value: any) {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            console.log();
            let _data: SafeSurgeryChecklistItem = value.data as SafeSurgeryChecklistItem;

            
        return new Promise(async (resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = null;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'SafeSurgeryCheckListForm';
            componentInfo.ModuleName = "AmeliyatModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = false;
            componentInfo.InputParam = new DynamicComponentInputParam(_data, activeIDsModel);
            componentInfo.objectID = _data.ObjectID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M14483", "Güvenli Cerrahi Kontrol Listesi");
            modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    
        }

    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public componentInfo: DynamicComponentInfo;
    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).then(resolveCompInfo => {
                this.componentInfo = resolveCompInfo;
                this.componentInfo.CloseWithStateTransition = true;
                this.componentInfo.DestroyComponentOnSave = true;
                this.componentInfo.RefreshComponent = true;
                this.loadPanelOperation(false, '');
            });
        } else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(resolveCompInfo => {
                this.componentInfo = resolveCompInfo;
                this.componentInfo.CloseWithStateTransition = true;
                this.componentInfo.DestroyComponentOnSave = true;
                this.componentInfo.RefreshComponent = true;
                this.loadPanelOperation(false, '');
            });
        }

     
    }


}

