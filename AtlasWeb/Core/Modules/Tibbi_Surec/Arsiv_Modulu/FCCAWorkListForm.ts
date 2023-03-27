//$6A4829A2
import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { FCCAWorkListFormViewModel, WorkListQueryFilter, ArchiveRequestSource, ArchiveRequestSourceModel, RequesterSectionModel, WorkListModel } from './FCCAWorkListFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ITTValueListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTValueListBox';

import { PatientStatusEnum, EpisodeFolder, ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { EnumItem } from "NebulaClient/Mscorlib/EnumItem";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { ArchiveBarcodeInfo } from 'app/Barcode/Models/ArchiveBarcodeInfo';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from "devextreme/data/data_source";
import List from 'app/NebulaClient/System/Collections/List';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';

@Component({
    selector: 'FCCAWorkListForm',
    templateUrl: './FCCAWorkListForm.html',
    providers: [MessageService]
})
export class FCCAWorkListForm implements OnInit, OnDestroy {
    ServiceValue: any;
    public ServiceDt = [
        {
            Name: i18n("M30703", "Fatura"),
            ObjectID: 'e2f883dc-e42c-4728-bf2c-01f301b7080f'
        },
        {
            Name: 'Tig',
            ObjectID: 'bd7396be-17ca-478b-a045-9e7fdae563fa'
        },
        {
            Name: i18n("M21662", "Servis"),
            ObjectID: "Servis"
        },
        {
            Name: i18n("M11097", "Arşiv"),
            ObjectID: '2e4789c1-d71a-4fc1-b9ad-209daf62871d'
        },
        {
            Name: i18n("M11106", "Arşivde Olanlar"),
            ObjectID: "Arsiv"
        },
        {
            Name: i18n("M11106", "Arşiv İstekleri"),
            ObjectID: "request"
        }

    ];
    loadingVisible: boolean;
    public get psEnum(): Array<EnumItem> {
        return PatientStatusEnum.Items;
    }
    public ViewModel: FCCAWorkListFormViewModel;
    public QueryModel: WorkListQueryFilter;
    cmbFolderLocation: ITTValueListBox;
    public showMainDiagnoseDefinitions: boolean = true;
    DiagnosisList: List<Object> = new List<Object>();

    //request

    public ArchiveRequestDescription: string = "";
    public ArchiveRequesterSection: Guid = null;

    public get fCCAWorkListFormViewModel(): FCCAWorkListFormViewModel {
        return this.ViewModel;
    }
    constructor(private sideBarMenuService: ISidebarMenuService, protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService, private barcodePrintService: IBarcodePrintService) {
        this.ViewModel = new FCCAWorkListFormViewModel();
        this.cmbFolderLocation = new TTVisual.TTValueListBox();
        this.cmbFolderLocation.ListDefName = 'ClinicListDefinition';
        this.cmbFolderLocation.Name = 'cmbFolderLocation';
        this.cmbFolderLocation.Enabled = false;
        this.ServiceValue = '2e4789c1-d71a-4fc1-b9ad-209daf62871d';
        this.getSystemParameter();
    }

    @ViewChild('archiveGrid') archiveGrid: DxDataGridComponent;

    public useManuelArchiveNo: boolean;

    async getSystemParameter() {
        let systemParameter: string = (await SystemParameterService.GetParameterValue('MANUELARSIVNUMARASIKULLAN', 'FALSE'));
        if (systemParameter === 'TRUE') {
            this.useManuelArchiveNo = true;
        }
        else {
            this.useManuelArchiveNo = false;
        }
        this.createProcedureListColumns();
        this.createRequestListColumns();
        this.createRequestWLListColumns();
    }

    public GridColumns = [];

    createProcedureListColumns() {
        this.GridColumns = [
            {
                'caption': i18n("M30702", 'Tc Kimlik No'),
                dataField: 'UniqueRefNo',
                allowSorting: true
            },
            {
                'caption': i18n("M20568", "Arşiv Numarası"),
                dataField: 'EpisodeFolderID',
                allowSorting: true,
                visible: !this.useManuelArchiveNo

            },
            {
                'caption': i18n("M20568", "Arşiv Numarası"),
                dataField: 'ManuelArchiveNo',
                allowSorting: true,
                visible: this.useManuelArchiveNo
            },
            {
                'caption': "Kabul No",
                dataField: 'ProtocolNo',
                allowSorting: true
            },
            //{
            //    'caption': i18n("M30701", 'Hasta Adı'),
            //    dataField: 'Name1',
            //    allowSorting: true
            //},
            //{
            //    'caption': i18n("M15304", "Hasta Soyadı"),
            //    dataField: 'Surname',
            //    allowSorting: true
            //},
            {
                'caption': "Hasta Adı Soyadı",
                dataField: 'Ptname',
                allowSorting: true
            },
            {
                'caption': "Anne Adı",
                dataField: 'MotherName',
                allowSorting: true
            },
            {
                'caption': "Baba Adı",
                dataField: 'FatherName',
                allowSorting: true
            },
            {
                'caption': 'Doğum Tarihi',
                dataField: 'BirthDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': 'Yatış Tarihi',
                dataField: 'HospitalInPatientDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': 'Çıkış Tarihi',
                dataField: 'HospitalDischargeDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': i18n("M24454", "Yatış Yeri"),
                dataField: 'Name',
                allowSorting: true
            },
            {
                'caption': i18n("M20708", "Raf"),
                dataField: 'Shelf',
                allowSorting: true
            },
            {
                'caption': i18n("M30700", 'Sıra'),
                dataField: 'Row',
                allowSorting: true
            },
            {
                'caption': i18n("M13372", "Durumu"),
                dataField: 'DisplayText',
                allowSorting: true
            }
        ];
        this.archiveGrid.instance.refresh();
    }

    public RequestWLGridColumns = [];

    createRequestWLListColumns() {
        this.RequestWLGridColumns = [
            {
                'caption': i18n("M30702", 'Tc Kimlik No'),
                dataField: 'UniqueRefNo',
                allowSorting: true
            },
            {
                'caption': i18n("M20568", "Arşiv Numarası"),
                dataField: 'EpisodeFolderID',
                allowSorting: true,
                visible: !this.useManuelArchiveNo

            },
            {
                'caption': i18n("M20568", "Arşiv Numarası"),
                dataField: 'ManuelArchiveNo',
                allowSorting: true,
                visible: this.useManuelArchiveNo
            },
            {
                'caption': "Kabul No",
                dataField: 'ProtocolNo',
                allowSorting: true
            },
            {
                'caption': "Hasta Adı Soyadı",
                dataField: 'Ptname',
                allowSorting: true
            },
            {
                'caption': "Anne Adı",
                dataField: 'MotherName',
                allowSorting: true
            },
            {
                'caption': "Baba Adı",
                dataField: 'FatherName',
                allowSorting: true
            },
            {
                'caption': 'Doğum Tarihi',
                dataField: 'BirthDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': 'Yatış Tarihi',
                dataField: 'HospitalInPatientDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': 'Çıkış Tarihi',
                dataField: 'HospitalDischargeDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': i18n("M24454", "Yatış Yeri"),
                dataField: 'Name',
                allowSorting: true
            },
            {
                'caption': i18n("M20708", "Raf"),
                dataField: 'Shelf',
                allowSorting: true
            },
            {
                'caption': i18n("M30700", 'Sıra'),
                dataField: 'Row',
                allowSorting: true
            },
            {
                'caption': i18n("M13372", "Durumu"),
                dataField: 'DisplayText',
                allowSorting: true
            },
            {
                'caption': i18n("M13372", "İstek Yapan Birim"),
                dataField: 'RequesterSection',
                allowSorting: true


            },
            {
                'caption': i18n("M13372", "İstek Tarihi"),
                dataField: 'RequestDate',
                allowSorting: true,
                format: 'dd.MM.yyyy',
                dataType: 'date',

            },
            {
                'caption': i18n("M13372", "Açıklama"),
                dataField: 'Description',
                allowSorting: true



            },
            {
                'caption': i18n("M13372", "İstek Yapan Kullanıcı"),
                dataField: 'RequesterName',
                allowSorting: true
            }
        ];
        this.archiveGrid.instance.refresh();

    }

    public RequestGridColumns = [];

    createRequestListColumns() {
        this.RequestGridColumns = [
            {
                'caption': i18n("M30702", 'Tc Kimlik No'),
                dataField: 'UniqueRefNo',
                allowSorting: true
            },
            {
                'caption': i18n("M20568", "Arşiv Numarası"),
                dataField: 'EpisodeFolderID',
                allowSorting: true,
                visible: !this.useManuelArchiveNo

            },
            {
                'caption': i18n("M20568", "Arşiv Numarası"),
                dataField: 'ManuelArchiveNo',
                allowSorting: true,
                visible: this.useManuelArchiveNo
            },
            {
                'caption': i18n("M24454", "Arşiv Yeri"),
                dataField: 'FolderLocation',
                allowSorting: true
            },
            {
                'caption': "Kabul No",
                dataField: 'ProtocolNo',
                allowSorting: true
            },
            {
                'caption': "Hasta Adı Soyadı",
                dataField: 'Ptname',
                allowSorting: true
            },
            {
                'caption': 'Doğum Tarihi',
                dataField: 'BirthDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': 'Yatış Tarihi',
                dataField: 'HospitalInPatientDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': 'Çıkış Tarihi',
                dataField: 'HospitalDischargeDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
            },
            {
                'caption': i18n("M24454", "Yatış Yeri"),
                dataField: 'Name',
                allowSorting: true
            }
        ];
    }

    public ResSections: List<RequesterSectionModel> = new List<RequesterSectionModel>();
    public async selectedTabChanged(event): Promise<void> {

        let selectedItem: string = event.addedItems[0].title;
        this.fCCAWorkListFormViewModel.QueryModel.PatientUniqueRefNo = "";
        this.fCCAWorkListFormViewModel.QueryModel.PatientObjectID = Guid.empty();
        this.fCCAWorkListFormViewModel.QueryModel.ProtocolNo = "";
        
        if (selectedItem == i18n("M30011", "Arşiv İstek")) {
            this.cmbFolderLocation.Enabled = true;
            this.ViewModel.archiveRequestDataSource = new Array<ArchiveRequestSourceModel>();
            if (this.ResSections.count == 0) {
                let apiUrl: string = '/api/FCCAWorkListService/GetArchiveRequesterSections';

                this.httpService.post<any>(apiUrl, null).then(
                    result => {
                        if (result != null)
                            this.ResSections = result;
                    }

                );
            }
        }

        this.ViewModel.dataSource = new Array<WorkListModel>();
    }



    objectId: Guid;

    sendArchive() {

        let apiUrl: string = '/api/FCCAWorkListService/transfer';
        this.objectId = new Guid("2e4789c1-d71a-4fc1-b9ad-209daf62871d");
        let params: TransferClass = new TransferClass();
        for (let mc of this.selectedPatients) {
            params.EpisodeFolders.push(mc.ObjectID);
        }
        params.Location = this.objectId;

        this.httpService.post<any>(apiUrl, params).then(
            x => {
                this.query();

            }

        );
    }

    public openWorkListTab: boolean = false;
    public openWorkList() {
        this.openWorkListTab = true;
    }

    public openRequestTab: boolean = false;
    public openRequest() {
        this.openRequestTab = true;
    }

    async ngOnInit() {
        let printBarcode = new DynamicSidebarMenuItem();
        printBarcode.icon = 'ai ai-barkod-bas';
        printBarcode.key = 'barkodbas';
        printBarcode.label = i18n("M30704", "Barkod bas"),
            printBarcode.componentInstance = this;
        printBarcode.clickFunction = this.printBarcode;
        this.sideBarMenuService.addMenu('YardimciMenu', printBarcode);
        this.LoadAllDiagnosisDefinitions();
        this.diagnoseEnable = false;
        this.filtersEnable = true;
        this.request = false;


    }

    showArchive: boolean;
    ShowSectionInfo_CellContentClickEmitted() {

        this.showArchive = true;

    }

    public ngOnDestroy(): void {
        this.sideBarMenuService.removeMenu('barkodbas');
    }
    printBarcode() {
        let info: ArchiveBarcodeInfo = new ArchiveBarcodeInfo();
        for (let mc of this.selectedPatients) {
            info.PatientName = mc.Name1 + " " + mc.Surname;
            info.PatientIdentifier = mc.UniqueRefNo.toString();
            info.ProtocolNumber = mc.ProtocolNo.toString();
            info.Row = mc.Row.toString();
            info.Shelf = mc.Shelf.toString();
            info.PolicilinicName = mc.Name.toString();
            this.barcodePrintService.printAllBarcode(info, "generateArchiveBarcode", "printArchiveBarcode");
        }

    }


    sendTig() {
        let apiUrl: string = '/api/FCCAWorkListService/transfer';
        this.objectId = new Guid("bd7396be-17ca-478b-a045-9e7fdae563fa");
        let params: TransferClass = new TransferClass();
        for (let mc of this.selectedPatients) {
            params.EpisodeFolders.push(mc.ObjectID);
        }
        params.Location = this.objectId;

        this.httpService.post<any>(apiUrl, params).then(
            x => {
                this.query();

            }

        );
    }

    undo() {
        let apiUrl: string = '/api/FCCAWorkListService/undo';
        this.objectId = new Guid("e2f883dc-e42c-4728-bf2c-01f301b7080f");
        let params: TransferClass = new TransferClass();
        for (let mc of this.selectedPatients) {
            params.EpisodeFolders.push(mc.ObjectID);
        }
        params.Location = this.objectId;

        this.httpService.post<any>(apiUrl, params).then(
            x => {
                this.query();

            }

        );
    }

    sendInvoice() {
        let apiUrl: string = '/api/FCCAWorkListService/transfer';
        this.objectId = new Guid("e2f883dc-e42c-4728-bf2c-01f301b7080f");
        let params: TransferClass = new TransferClass();
        for (let mc of this.selectedPatients) {
            params.EpisodeFolders.push(mc.ObjectID);
        }
        params.Location = this.objectId;

        this.httpService.post<any>(apiUrl, params).then(
            x => {
                this.query();

            }

        );
    }
    ServiceFolderLocation: any;
    sendService() {
        let apiUrl: string = '/api/FCCAWorkListService/transfer';
        this.objectId = new Guid(this.ServiceFolderLocation);
        let params: TransferClass = new TransferClass();
        for (let mc of this.selectedPatients) {
            params.EpisodeFolders.push(mc.ObjectID);
        }
        params.Location = this.objectId;

        this.httpService.post<any>(apiUrl, params).then(
            x => {
                this.query();

            }

        );
    }
    sendToCompleteRequest() {
        let apiUrl: string = '/api/FCCAWorkListService/CompleteArchiveRequest';
        let params: Array<ArchiveRequestSource> = new Array<ArchiveRequestSource>();
        params = this.selectedRequests;

        if (this.selectedRequests.length > 0) {
            this.httpService.post<any>(apiUrl, params).then(
                x => {
                    this.query();
                }

            );
        }
        else
            ServiceLocator.MessageService.showError("Karşılanacak istekleri seçiniz");
    }
    selectedPatients: Array<any> = new Array<any>();
    selectionPatient(data) {
        this.selectedPatients = data.selectedRowsData;

    }
    selectedRequests: Array<any> = new Array<any>();
    selectionRequestedArchives(data) {
        this.selectedRequests = data.selectedRowsData;

    }

    select: boolean = false;
    selectionDataRow(data) {
        this.select = true;

    }
    rowClick(event) {

        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            if (event.data.FileCreationAndAnalysis != null) {
                return new Promise((resolve, reject) => {
                    let componentInfo = new DynamicComponentInfo();
                    componentInfo.ComponentName = 'FormFCAAArchive';
                    componentInfo.ModuleName = "ArsivModule";
                    componentInfo.ModulePath = '/Modules/Tibbi_Surec/Arsiv_Modulu/ArsivModule';
                    componentInfo.objectID = event.data.FileCreationAndAnalysis;

                    let modalInfo: ModalInfo = new ModalInfo();
                    modalInfo.Title = i18n("M11100", "Arşiv Kayıt");
                    modalInfo.Width = 1248;
                    modalInfo.Height = 900;

                    let result = this.modalService.create(componentInfo, modalInfo);
                    result.then(inner => {
                        resolve(inner);
                    }).catch(err => {
                        reject(err);
                    });
                });
            }
        }

    }



    public acceptArchive(): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'FormFCAAArchive';
            componentInfo.ModuleName = "ArsivModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Arsiv_Modulu/ArsivModule';
            componentInfo.objectID = this.selectedPatients[0].FileCreationAndAnalysis;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M11100", "Arşiv Kayıt");
            modalInfo.Width = 1248;
            modalInfo.Height = 900;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    acceptArchivevisible: boolean = true;
    archiveVisible: boolean = true;
    tigVisible: boolean = true;
    invoiceVisible: boolean = true;
    serviceVisible: boolean = true;

    patientChanged(patient: any) {
        if (patient != undefined)
            this.ViewModel.QueryModel.PatientObjectID = patient.ObjectID;
        if (patient == null || patient == undefined)
            this.ViewModel.QueryModel.PatientObjectID = Guid.empty();
    }

    diagnoseEnable: boolean = false;
    columnVisible: boolean;
    filtersEnable: boolean = true;
    request: boolean = false;
    LocationChanged(dat) {
        if (dat.selectedItem.Name == i18n("M11106", "Arşivde Olanlar")) {
            this.archiveVisible = false;
            this.acceptArchivevisible = false;
            this.tigVisible = true;
            this.invoiceVisible = true;
            this.serviceVisible = true;
            this.columnVisible = false;
            this.request = false;

        }
        if (dat.selectedItem.Name == i18n("M11097", "Arşiv")) {
            this.archiveVisible = false;
            this.acceptArchivevisible = true;
            this.tigVisible = true;
            this.invoiceVisible = true;
            this.serviceVisible = true;
            this.columnVisible = false;
            this.request = false;

        }


        if (dat.selectedItem.Name == "Tig") {
            this.archiveVisible = true;
            this.acceptArchivevisible = true;
            this.tigVisible = false;
            this.acceptArchivevisible = false;
            this.serviceVisible = true;
            this.invoiceVisible = true;
            this.columnVisible = false;
            this.request = false;

        }


        if (dat.selectedItem.Name == i18n("M30703", "Fatura")) {
            this.archiveVisible = true;
            this.acceptArchivevisible = true;
            this.tigVisible = true;
            this.acceptArchivevisible = false;
            this.invoiceVisible = false;
            this.serviceVisible = true;
            this.columnVisible = false;
            this.request = false;

        }


        if (dat.selectedItem.Name == i18n("M21662", "Servis")) {
            this.serviceVisible = false;
            this.archiveVisible = true;
            this.acceptArchivevisible = false;
            this.tigVisible = true;
            this.invoiceVisible = true;
            this.columnVisible = false;
            this.request = false;

        }


        if (dat.selectedItem.Name == i18n("M21662", "Servis"))
            this.cmbFolderLocation.Enabled = true;
        else
            this.cmbFolderLocation.Enabled = false;

        if (dat.selectedItem.Name == i18n("M11106", "Arşivde Olanlar"))
            this.diagnoseEnable = true;
        else
            this.diagnoseEnable = false;

        if (dat.selectedItem.Name == i18n("M21662", "Arşiv İstekleri"))
            this.filtersEnable = false;
        else
            this.filtersEnable = true;



        if (dat.selectedItem.Name == i18n("M21662", "Arşiv İstekleri")) {
            this.serviceVisible = false;
            this.archiveVisible = false;
            this.acceptArchivevisible = false;
            this.tigVisible = false;
            this.invoiceVisible = false;
            this.columnVisible = true;
            this.request = true;

        }


    }

    query() {
        if (this.ServiceValue == i18n("M11096", "Arsiv")) {
            this.loadingVisible = true;
            let apiUrl: string = '/api/FCCAWorkListService/Archive';
            this.ViewModel.QueryModel.selectedDiagnosisStr = JSON.stringify(this.ViewModel.QueryModel.selectedDiagnosis);

            this.QueryModel = this.ViewModel.QueryModel;
            this.httpService.post<any>(apiUrl, this.QueryModel).then(
                x => {
                    this.ViewModel.dataSource = x.archiveDataSource;
                    this.loadingVisible = false;
                }

            );
        }
        else if (this.ServiceValue == i18n("M11096", "request")) {
            let apiUrl: string = '/api/FCCAWorkListService/ArchiveRequests';
            this.httpService.post<any>(apiUrl, null).then(
                x => {
                    this.ViewModel.requestWorkListModel = x.requestWorkListModel;
                    this.loadingVisible = false;
                }

            );
        }
        else {
            this.loadingVisible = true;
            let apiUrl: string = '/api/FCCAWorkListService/FCCAWorkListQuery';

            if (this.ServiceValue != i18n("M21662", "Servis"))
                this.ViewModel.QueryModel.Location = new Guid(this.ServiceValue);
            else
                this.ViewModel.QueryModel.Location = this.ViewModel.QueryModel.FolderLocation;
            this.QueryModel = this.ViewModel.QueryModel;

            this.httpService.post<any>(apiUrl, this.QueryModel).then(
                x => {
                    this.ViewModel.dataSource = x.dataSource;
                    this.loadingVisible = false;
                }

            );
        }
    }


    archiveQuery() {
        this.loadingVisible = true;
        let apiUrl: string = '/api/FCCAWorkListService/ArchiveRequestQuery';
        this.QueryModel = this.ViewModel.QueryModel;
        this.httpService.post<any>(apiUrl, this.QueryModel).then(
            x => {
                this.ViewModel.archiveRequestDataSource = x.archiveRequestDataSource;
                this.loadingVisible = false;
            }

        );
    }


    public DiagnosisArray: any;
    public async LoadAllDiagnosisDefinitions() {

        this.DiagnosisArray = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'DiagnosisListDef',
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>("/api/DefinitionQuery/GetDiagnosisForTagBox", loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });


    }

    public FCAAForRequest: Guid;
    public EpisodeFolderForRequest: Guid;
    public requestRowClick(event) {
        this.FCAAForRequest = event.data.FileCreationAndAnalysis;
        this.EpisodeFolderForRequest = event.data.ObjectID;
        this.select = true;
    }


    archiveRequestFormInput: Guid;
    public async CreateArchiveRequest() {
        let that = this;
        let requestURL: string = '/api/FCCAWorkListService/CreateArchiveRequest?episodeFolderId=' + this.EpisodeFolderForRequest
            + "&fileCreationAndAnalysis=" + this.FCAAForRequest + "&description=" + this.ArchiveRequestDescription + "&requesterSectionId=" + this.ArchiveRequesterSection;

        if (this.ArchiveRequestDescription == "") {
            ServiceLocator.MessageService.showError("İstek açıklaması yazılmadan arşiv isteği yapılamaz");
            return;
        }

        if (this.ArchiveRequesterSection == null) {
            ServiceLocator.MessageService.showError("İstek yapan birim seçilmeden arşiv isteği yapılamaz");
            return;
        }
        that.httpService.get<any>(requestURL).then(
            async result => {
                this.archiveRequestFormInput = result;
                this.messageService.showInfo("İstek Oluşturuldu");
                this.archiveQuery();
                this.showArchive = false;
                this.ArchiveRequestDescription = "";
                this.ArchiveRequesterSection = null;
                this.select = false;
                this.printRequestForm();
            }).catch(error => {
                this.messageService.showError(error);
            });
    }
    public async printRequestForm(): Promise<ModalActionResult> {

        
        let reportData: DynamicReportParameters = {

            Code: 'ARSIVISTEKFORMU',
            ReportParams: { ArchiveRequestObjectID: this.archiveRequestFormInput},
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "ARŞİV İSTEK FORMU"

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




export class TransferClass {
    EpisodeFolders: Array<string> = new Array<string>();
    Location: Guid;
}



