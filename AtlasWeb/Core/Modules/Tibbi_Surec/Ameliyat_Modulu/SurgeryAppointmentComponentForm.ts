
import { Component, OnInit, Input, EventEmitter, OnDestroy, ViewChild, ChangeDetectorRef, AfterViewInit, Output } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { UsernamePwdInput, UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { UsernamePwdFormViewModel } from 'app/Fw/Components/UsernamePwdFormComponent';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { DxDataGridComponent, DxDropDownBoxComponent } from 'devextreme-angular';
import { IlacRaporuServis } from 'app/NebulaClient/Services/External/IlacRaporuServis';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { MedulaResult, eRaporOnayCevapDVO } from '../Tibbi_Malzeme_Modulu/MedicalStuffReportFormViewModel';
import { ComposeComponent } from 'app/Fw/Components/ComposeComponent';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import DevExpress from 'devextreme/bundles/dx.all';
import { SurgeryAppointmentListItem, SurgeryAppointmentComponentFormViewModel, SurgeryAppointmentListSearchCriteria, MasterView } from './SurgeryAppointmentComponentFormViewModel';
import { SurgeryAppointmentSharedService } from './SurgeryAppointmentSharedService';
import { Subscription } from 'rxjs';
import { Store, ProcedureDefinition } from 'app/NebulaClient/Model/AtlasClientModel';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';

@Component({
    selector: "SurgeryAppointmentComponentForm",
    templateUrl: './SurgeryAppointmentComponentForm.html',
    providers: [MessageService, { provide: IESignatureService, useClass: ESignatureService }, SystemApiService]

})
export class SurgeryAppointmentComponentForm implements OnInit, OnDestroy, AfterViewInit {

    ngAfterViewInit() {
        // this.dataGrid.instance.repaint();
    }

    _PatientID: Guid;


    constructor(protected httpService: NeHttpService,
        public systemApiService: SystemApiService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        public signService: IESignatureService,
        private changeDetectorRef: ChangeDetectorRef,
        private surgeryAppointmentSharedService: SurgeryAppointmentSharedService) {

    }
    private _formLoadInput: ActiveIDsModel = null;

    @Input() set FormLoadInput(value: ActiveIDsModel) {
        if (value.episodeActionId != null) {
            this.isOpenedFromMenu = false;
        }
        this._formLoadInput = value;
    }
    get FormLoadInput(): ActiveIDsModel {
        return this._formLoadInput;
    }
    public isOpenedFromMenu: boolean = true;
    public headDoctorApproveParameterActive: boolean = false;
    public LoadPanelMessage = '';
    public showLoadPanel: boolean = false;
    SurgeryAppointmentList: Array<SurgeryAppointmentListItem> = new Array<SurgeryAppointmentListItem>();
    public surgeryAppointmentFormComponentViewModel: SurgeryAppointmentComponentFormViewModel = new SurgeryAppointmentComponentFormViewModel();
    public SurgeryAppointmentListColumns = [
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "ProtocolNo",
            dataType: 'string',
            width: 'auto',
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true
        },
        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientName",
            dataType: 'string',
            width: "auto",
            minWidth: 150,
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true
        },
        {
            caption: "Yattığı Servis",
            dataField: "Clinic",
            dataType: 'string',
            width: "auto",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,

        },
        {
            caption: "Ameliyathane",
            dataField: "SurgeryDepartment",
            dataType: 'string',
            width: "auto",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,

        },
        {
            caption: "Ameliyat Salonu",
            dataField: "SurgeryRoom",
            dataType: 'string',
            width: "auto",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,

        },
        {
            caption: "Ameliyat İşlemi",
            dataField: "SurgeryProcedure",
            dataType: 'string',
            width: "150px",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,

        },
        {
            caption: i18n("M16650", "Randevu Tarihi"),
            dataField: "AppointmentDate",
            dataType: 'date',
            format: 'dd.MM.yyyy HH:mm',
            width: 'auto',
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true
        },
        {
            caption: "Randevu Doktoru",
            dataField: "AppointmentDoctor",
            dataType: 'string',
            width: "auto",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,

        },
        {
            caption: "Statüsü",
            dataField: "Status",
            dataType: 'string',
            width: "auto",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,

        },
        {
            caption: "İşlemler",
            cellTemplate: "ButtonCellTemplate",
            width: '75px',
            cssClass: "verticalAlignRepApproveForm",
            visible: this.isOpenedFromMenu

        },
        {
            caption: 'Ameliyat Malzemeleri',
            dataField: '',
            cellTemplate: 'detailButtonTemplate',
            Name: 'btnInfo',
            width: "auto"
            //width: 400
        },



    ];

    public stores: Array<Store> = new Array<Store>();
    public selectedStore: Store;
    public materialListFilter: string = "";
    public materialAmount: number;
    public selectedProcedure: ProcedureDefinition;

    @Output() ClosePopUp: EventEmitter<boolean> = new EventEmitter<boolean>();

    public selectedMasterGridRowKeys: Array<string> = new Array<string>();


    public onAppointmentFormSaved(event) {
        if (this.isOpenedFromMenu == true) {
            this._formLoadInput = null;
        }else{
            this.ClosePopUp.emit(true);
        }
    }

    panelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public SearchCriteriaSubscription: Subscription;
    public initSubscriptions() {
        if (this.SearchCriteriaSubscription == null) {
            this.SearchCriteriaSubscription = this.surgeryAppointmentSharedService.AppointmentListSearchCriteria.subscribe(
                searchCriteria => {
                    if (this.isOpenedFromMenu == false || searchCriteria.searchForAppointmentCount == true) {
                        this.ListAppointmentsFromSubscription(searchCriteria);
                    }
                }
            )
        }
    }

    public destroySubscriptions() {
        if (this.SearchCriteriaSubscription != null) {
            this.SearchCriteriaSubscription.unsubscribe();
            this.SearchCriteriaSubscription = null;
        }
    }

    async ngOnInit() {
        let enableHeadDoctorApprove: string = await SystemParameterService.GetParameterValue('AMELIYATRANDEVUBASHEKIMONAYAKTIF', 'FALSE');
        if (enableHeadDoctorApprove === 'TRUE') {
            this.headDoctorApproveParameterActive = true;
        }
        else {
            this.headDoctorApproveParameterActive = false;
        }

        await this.getViewModel();
        this.initSubscriptions();
    }


    async ngOnDestroy() {
        this.destroySubscriptions();
    }
    patientChanged(patient: any) {
        if (patient) {
            //this.surgeryAppointmentFormComponentViewModel._SearchCriteria.PatientId = patient.ObjectID;
            let activeIDsModel: ActiveIDsModel = new ActiveIDsModel(null, null, patient.ObjectID);
            this._formLoadInput = activeIDsModel;
        }
        else {
            //this.surgeryAppointmentFormComponentViewModel._SearchCriteria.PatientId = null;
            this._formLoadInput = null;
        }
    }

    searchCriteriaPatientChanged(patient: any) {
        if (patient) {
            this.surgeryAppointmentFormComponentViewModel._SearchCriteria.PatientId = patient.ObjectID;
        }
        else {
            this.surgeryAppointmentFormComponentViewModel._SearchCriteria.PatientId = null;
        }
    }

    public async getViewModel() {
        let that = this;
        that.panelOperation(true, "Lütfen Bekleyiniz");
        let requestString = "api/SurgeryAppointmentComponentFormService/getSurgeryAppointmentCompoentViewModel";
        that.httpService.get<SurgeryAppointmentComponentFormViewModel>(requestString)
            .then(response => {
                that.surgeryAppointmentFormComponentViewModel = response;
                that.panelOperation(false, "");
            })
            .catch(error => {
                that.panelOperation(false, "");
                that.messageService.showError(error);

            });
    }

    async updateAppointment(appointmentObjectId: Guid, isDoctorApprove: boolean, isCancelled: boolean) {
        let that = this;
        let requestString = "api/SurgeryAppointmentComponentFormService/UpdateSurgeryAppointment?appointmentObjectId=" + appointmentObjectId + "&isDoctorApprove=" + isDoctorApprove + "&isCancelled=" + isCancelled;
        that.httpService.get<boolean>(requestString)
            .then(response => {
                if (response == true) {
                    if (isCancelled == false)
                        ServiceLocator.MessageService.showSuccess("Randevu Başarıyla Onaylandı");
                    else
                        ServiceLocator.MessageService.showSuccess("Randevu Başarıyla İptal Edildi");
                    // Randevu Listesi Baştan yüklenecek
                }
                that.panelOperation(false, "");
            })
            .catch(error => {
                that.panelOperation(false, "");
                that.messageService.showError(error);

            });
    }


    ListAppointmentsFromSubscription(searchCriteria: SurgeryAppointmentListSearchCriteria) {
        searchCriteria.isCalledByAppointmentForm = true;
        this.ListAppointments(searchCriteria);
    };

    ListAppointmentsFromButton() {
        this.ListAppointments(this.surgeryAppointmentFormComponentViewModel._SearchCriteria);
    }


    public MasterDataList: Array<MasterView>; 
    public ListAppointments(searchCriteria: SurgeryAppointmentListSearchCriteria) {
        let that = this;
        this.panelOperation(true, "Raporlar Listeleniyor, Lütfen Bekleyin");
        let requestString = "api/SurgeryAppointmentComponentFormService/GetSurgeryWorkList";
        that.httpService.post<Array<SurgeryAppointmentListItem>>(requestString, searchCriteria)
            .then(response => {
                if (searchCriteria.searchForAppointmentCount == false)
                    that.SurgeryAppointmentList = response;
                if (that.isOpenedFromMenu == false && searchCriteria.isCalledByAppointmentForm == true) {
                    that.surgeryAppointmentSharedService.sendResponseList(response);
                }
                if (searchCriteria.searchForAppointmentCount == true)
                    that.surgeryAppointmentSharedService.sendResponseList(response);
                that.panelOperation(false, "");
            })
            .catch(error => {
                that.panelOperation(false, "");
                that.messageService.showError(error);

            });
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    public MasterGridColumns = [
        {
            caption: "İşlem",
            dataField: 'Procedure.Name',
            width: 'auto',
            fixed: true,
            visibleIndex: 0,
            allowEditing: false,

        }
    ];

    public DetailGridColumns = [
     
        {
            caption: 'Malzeme',
            dataField: 'MaterialName',
            dataType: "string",
            width: 200,
            allowEditing: false,
        },
        {
            caption: i18n("M13294", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            alignment: 'left',
            width: 80,
        },
        {
            caption: 'Depo',
            dataField: 'StoreName',
            dataType: 'string',
            allowEditing: false,
            width: 200,
        }
    ];

    public async CreateStoreDataSources() {
        try {
            if(this.stores.length == 0){
            let apiUrl: string = '/api/SurgeryAppointmentComponentFormService/GetStoresList';
            await this.httpService.post< Array<Store>>(apiUrl, "").then(result => {
                this.stores = result;
            });
        }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public onMasterGridSelectionChanged(event: any) {
        if(event != null){
            
        }
    }

    public surgeryMaterialVisible: boolean = false;
    public appointmentID: Guid = new Guid();
    async ShowSectionInfo_CellContentClickEmitted(data: any) {
        if (data != null && data.column.Name == 'btnInfo') {        
        try {
            let apiUrl: string = '/api/SurgeryAppointmentComponentFormService/GetSurgeryMaterials?ApppointmentId='+data.data.AppointmentObjectId;
            this.appointmentID = data.data.AppointmentObjectId;
            await this.httpService.post<Array<MasterView>>(apiUrl, "").then(result => {
                this.MasterDataList = result;
                this.CreateStoreDataSources();
                this.surgeryMaterialVisible = true;
            });
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    }

    public async selectedStoreChange() {
        if (this.selectedStore) {
            this.materialListFilter = 'THIS.OBJECTDEFNAME IN (\'CONSUMABLEMATERIALDEFINITION\',\'DRUGDEFINITION\') ';

            if (this.selectedStore.ObjectID == null) {
                this.materialListFilter = this.materialListFilter + ' AND STOCKS.INHELD>0 AND STOCKS.STORE = \'' + await this.selectedStore + '\'';
            } else {
                this.materialListFilter = this.materialListFilter + ' AND STOCKS.INHELD>0 AND STOCKS.STORE = \'' + await this.selectedStore.ObjectID.toString() + '\'';
            }
            //}
        } else {
            this.materialListFilter = '1=0';
        }
    }

    openMaterialDropDown(e: any) {
        this.getMaterialDataSource();
    }

    materialDataSource: DataSource;
    getMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'AllowedConsumableMaterialAndDrugList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/TreatmentMaterialService/GetMaterialList?storeID=' + this.materialListFilter, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    selectedMaterialItem: any = {};
    @ViewChild('materialDrop') materialDrop: DxDropDownBoxComponent;
    selectMaterial(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMaterialItem = e.data;
        this.materialDrop.instance.close();
    }

    public onClearMaterial(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedMaterialItem = {};
        }
    }

    public clearScreen() {
        this.selectedMaterialItem = {};
        this.selectedStore= null;
        this.materialAmount = null;

    }

    public AddNewAppointmentMaterial(event: any) {

        if (this.selectedStore == null) {
            ServiceLocator.MessageService.showError("Depo seçimi yapınız");
            return;
        }

        if (this.selectedMaterialItem.ObjectID == null) {
            ServiceLocator.MessageService.showError("Eklenecek malzemeyi seçiniz");
            return;
        }

        if (this.materialAmount == null) {
            ServiceLocator.MessageService.showError("Miktar alanı boş bırakılamaz");
            return;
        }
        let that = this;
        let requestString: string = "";
        let storeID: Guid;
        let materialID: Guid;
        let procedureID: Guid;
        if(typeof this.selectedStore == "string"){
            storeID = new Guid(this.selectedStore);
        }
        else{
            storeID = this.selectedStore.ObjectID;
        }
        if(typeof this.selectedMaterialItem == "string"){
            materialID = new Guid(this.selectedMaterialItem);
        }
        else{
            materialID = this.selectedMaterialItem.ObjectID;
        }
   
        requestString = "api/SurgeryAppointmentComponentFormService/SaveAppointmentMaterial?AppointmentID="+ this.appointmentID +"&ProcedureID=" + event.key + "&MaterialID=" + materialID + "&StoreID=" + storeID + "&Amount=" + this.materialAmount;

        that.httpService.get<Array<MasterView>>(requestString)
            .then(response => {
                that.MasterDataList = response;
                that.clearScreen();
                ServiceLocator.MessageService.showSuccess("İşlem başarılı bir şekilde kaydedildi");
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);

            });
    }
}