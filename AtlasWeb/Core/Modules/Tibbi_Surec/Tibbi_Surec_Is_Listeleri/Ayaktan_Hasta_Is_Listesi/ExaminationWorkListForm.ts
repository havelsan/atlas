
import { Component, Renderer2, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ExaminationWorkListViewModel, ListObject, ExaminationWorkListItem, SendWorklistSignedReportApproveModel } from './ExaminationWorkListViewModel';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import DataSource from 'devextreme/data/data_source';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { BaseEpisodeActionWorkListForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListForm";
import { BaseEpisodeActionWorkListFormViewModel, FollowingPatientList } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';
import { ExaminationRetunClass, ExaminationQueueDefinitionParamClass, SetPatientStatusParam, GetSortedQueueItemsByArray_Input, CallNexttPatientParam } from 'Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListForm';
import { ExaminationQueueDefinition, ResSection, LCDNotificationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { MultiSelectForm } from 'NebulaClient/Visual/MultiSelectForm';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { SimpleTimer } from 'ng2-simple-timer';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { DateParam } from 'app/NebulaClient/Mscorlib/DateParam';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { UsernamePwdBox, UsernamePwdInput } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { UsernamePwdFormViewModel } from 'app/Fw/Components/UsernamePwdFormComponent';
import { IlacRaporuServis } from 'app/NebulaClient/Services/External/IlacRaporuServis';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { DxDataGridComponent } from 'devextreme-angular';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { eRaporOnayCevapDVO } from 'Modules/Tibbi_Surec/Tibbi_Malzeme_Modulu/MedicalStuffReportFormViewModel';
import { TTException } from 'app/NebulaClient/Utils/Exceptions/TTException';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';

@Component({
    selector: 'ExaminationWorkListForm',
    templateUrl: './ExaminationWorkListForm.html',
    providers: [SystemApiService, MessageService, { provide: IESignatureService, useClass: ESignatureService }]
})
export class ExaminationWorkListForm extends BaseEpisodeActionWorkListForm implements OnInit {

    public ActionNameList: ListObject[];
    public selectedActionNameListItems: ListObject[];
    public ActionNameResources: DataSource;

    public ActionStateList: ListObject[];
    public ReportStateList: ListObject[];
    public selectedActionStateListItems: ListObject[];
    public selectedReportStateListItems: ListObject[];
    public ActionStateResources: DataSource;
    public ReportStateResources: DataSource;

    public radioGroupPatientTypeItems: any[] = [];
    public PageName = "ExaminationWorkListForm"; // Kolonlar kullanıcılara göre kaydedilirken Kullanılır

    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService,
        public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer,
        protected modalService: IModalService, public renderer: Renderer2,
        protected reportService: AtlasReportService, private sideBarMenuService: ISidebarMenuService,
        public signService: IESignatureService,
        private changeDetectorRef: ChangeDetectorRef
    ) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);

        this.ActionNameList = [
            {
                TypeName: i18n("M15277", "Muayene"),
                TypeID: 0
            }, {
                TypeName: i18n("M17742", "Konsültasyon"),
                TypeID: 1
            }, {
                TypeName: i18n("M21215", "Sağlık Kurulu"),
                TypeID: 2
            }, {
                TypeName: i18n("M22078", "Sonuç"),
                TypeID: 3
            }, {
                TypeName: i18n("M12910", "Diş Muayene"),
                TypeID: 4
            }
        ];

        this.ActionStateList = [
            {
                TypeName: i18n("M30314", "Bekleyen"),
                TypeID: 0
            }, {
                TypeName: i18n("M30315", "Takipte"),
                TypeID: 1
            }, {
                TypeName: i18n("M30316", "Tamamlanan"),
                TypeID: 2
            }, {
                TypeName: i18n("M30317", "Reddedilen"),
                TypeID: 3
            }
        ];

        this.ReportStateList = [
            {
                TypeName: i18n("M30314", "Raporda"),
                TypeID: 0
            }, {
                TypeName: i18n("M30315", "Doktor Onayında"),
                TypeID: 1
            }, {
                TypeName: i18n("M30316", "Başhekim Onayında"),
                TypeID: 2
            }, {
                TypeName: i18n("M30317", "Tamamlanan (Rapor onayı tamamlanan hastalar)"),
                TypeID: 3
            }, {
                TypeName: i18n("M30317", "Reddedilen (Rapor onayı reddedilen hastalar)"),
                TypeID: 4
            }
        ];

        this.ActionNameResources = new DataSource({
            store: this.ActionNameList,
            searchOperation: 'contains',
            searchExpr: 'TypeName'
        });

        this.ActionStateResources = new DataSource({
            store: this.ActionStateList,
            searchOperation: 'contains',
            searchExpr: 'TypeName'
        });

        this.ReportStateResources = new DataSource({
            store: this.ReportStateList,
            searchOperation: 'contains',
            searchExpr: 'TypeName'
        });

        this.selectedActionNameListItems = new Array<ListObject>();
        this.selectedActionStateListItems = new Array<ListObject>();
        this.selectedReportStateListItems = new Array<ListObject>();

        this.selectedActionNameListItems = this.ActionNameList;

        this.selectedActionStateListItems = this.ActionStateList;
        this.selectedReportStateListItems = this.ReportStateList;

        this.radioGroupPatientTypeItems = [
            { text: "Benim Hastalarım", value: 1 },
            { text: "Tüm Hastalar", value: 2 }
        ];

        this.examinationWorkListViewModel._SearchCriteria.ActionNames = new Array<ListObject>();
        this.examinationWorkListViewModel._SearchCriteria.ActionStatus = new Array<ListObject>();
        this.examinationWorkListViewModel._SearchCriteria.ReportStatus = new Array<ListObject>();

    }
    public examinationWorkListViewModel: ExaminationWorkListViewModel = new ExaminationWorkListViewModel();
    public enableMedulaPasswordEntrance: boolean = false;

    public radioGroupEAType_Value = 1;
    radioGroupEATypeItems = [
        { text: "Poliklinik İşlemleri", value: 1 },
        { text: "Rapor Onayı", value: 2 },
    ];

    onradioGroupEAType_ValueChanged(e: any) {

        if (e.value == 2) {
            this.examinationWorkListViewModel._SearchCriteria.policlinic_EA = false;
            this.examinationWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA = true;
            this.examinationWorkListViewModel._SearchCriteria.ReportStatus = new Array<ListObject>();
            this.examinationWorkListViewModel._SearchCriteria.ReportStatus.push(this.selectedReportStateListItems[0]); //Bekleyen
        }
        else if (e.value == 1) {
            this.examinationWorkListViewModel._SearchCriteria.policlinic_EA = true;
            this.examinationWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA = false;
            this.examinationWorkListViewModel._SearchCriteria.ActionStatus = new Array<ListObject>();
            this.examinationWorkListViewModel._SearchCriteria.ActionStatus.push(this.selectedActionStateListItems[0]); //Bekleyen
        }
    }
    @ViewChild('ReportGrid') dataGrid: DxDataGridComponent;

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: i18n("M21815", "S.No"),
                dataField: "AdmissionQueueNo",
                dataType: 'string',
                width: 50,
                allowSorting: true,
                //sortOrder: 'asc',
                //sortIndex: 1,
                //cssClass: 'worklistGridCellFont'
            },
            {
                caption: i18n("M16650", "İstek Tarihi"),
                dataField: "Date",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 'auto',
                allowSorting: true,
                //sortOrder: 'asc',
                //sortIndex: 0,
                //cssClass: 'worklistGridCellFont'
            },
            {
                caption: i18n("M15133", "Hasta Adı Soyadı"),
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: "auto",
                minWidth: 150,
                cellTemplate: "PriorityCellTemplate", // Yaşlı Genç için html tarafına referans
                allowSorting: true
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: "KabulNo",
                dataType: 'string',
                width: 'auto',
                allowSorting: true
            },
            {
                caption: i18n("M22514", "T.C. Kimlik Numarası"),
                dataField: "UniqueRefno",
                dataType: 'string',
                width: 'auto',
                allowSorting: true
            },
            {
                "caption": i18n("M16818", "İşlem"),
                dataField: "EpisodeActionName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            },
            {
                "caption": i18n("M16838", "İşlem Durumu"),
                dataField: "StateName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            },
            {
                caption: "Protokol No",
                dataField: "ExaminationProtocolNo",
                dataType: 'string',
                width: 'auto',
                visible: true,
                allowSorting: true
            }
            ,
            {
                caption: i18n("M27339", "Doktoru"),
                dataField: "DoctorName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27357", "Birimi"),
                dataField: "ResourceName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                //  cssClass: 'worklistGridCellFont',
            }
            ,

            {
                caption: i18n("M21815", "Alerji Durumu"),
                dataField: "MedicalInformation",
                dataType: 'string',
                width: 50,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont'
            },

            {
                caption: i18n("M14664", "Geliş Sebebi"),
                dataField: "ComingReason",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M15322", "Hasta Türü"),
                dataField: "PatientClassGroup",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M27441", "Başvuru Türü"),
                dataField: "ApplicationReason",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                //  cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M18035", "Kurum Bilgisi"),
                dataField: "PayerInfo",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                //  cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M13132", "Doğum Tarihi"),
                dataField: "BirthDate",
                dataType: 'date',
                width: "auto",
                visible: false,
                allowSorting: true,
                //  cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M11390", "Baba Adı"),
                dataField: "FatherName",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M23138", "Telefon Numarası"),
                dataField: "PhoneNumber",
                dataType: 'string',
                width: 'auto',
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            }, {
                caption: i18n("M22736", "Tanı"),
                dataField: "Diagnosis",
                dataType: 'string',
                width: 'auto',
                visible: false,
                allowSorting: true
            }, {
                caption: "Triaj",
                dataField: "Triage",
                dataType: 'string',
                width: 'auto',
                visible: false,
                allowSorting: true
            }, {
                caption: "Hasta Çağırılma Durumu",
                dataField: "PatientCallStatus",
                dataType: 'string',
                width: 'auto',
                visible: true,
                allowSorting: true
            }, {
                caption: "Yaş",
                dataField: "Age",
                dataType: 'string',
                width: 'auto',
                visible: false,
                allowSorting: true
            }


        ];

        super.GenerateResultListColumns(columnNameAndOrder);
    }
    public ReportColumns = [

        {
            caption: i18n("M16650", "İstek Tarihi"),
            dataField: "Date",
            dataType: 'date',
            format: 'dd.MM.yyyy HH:mm',
            width: 'auto',
            allowSorting: true,
            //sortOrder: 'asc',
            //sortIndex: 0,
            //cssClass: 'worklistGridCellFont'
        },
        {
            "caption": i18n("M16838", "Rapor Türü"),
            dataField: "ObjectDefName",
            dataType: 'string',
            width: "auto",
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        },
        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: "auto",
            minWidth: 150,
            cellTemplate: "PriorityCellTemplate", // Yaşlı Genç için html tarafına referans
            allowSorting: true
        },
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "KabulNo",
            dataType: 'string',
            width: 'auto',
            allowSorting: true
        },
        {
            caption: i18n("M22514", "T.C. Kimlik Numarası"),
            dataField: "UniqueRefno",
            dataType: 'string',
            width: 'auto',
            allowSorting: true
        },
        {
            caption: i18n("M27339", "Doktoru"),
            dataField: "DoctorName",
            dataType: 'string',
            width: "auto",
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        },
        {
            caption: i18n("M27357", "Birimi"),
            dataField: "ResourceName",
            dataType: 'string',
            width: "auto",
            allowSorting: true,
            //  cssClass: 'worklistGridCellFont',
        },
        {
            "caption": i18n("M16838", "İşlem Durumu"),
            dataField: "StateName",
            dataType: 'string',
            width: "auto",
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        }


    ];
    public onRowPrepared(row: any): void {

        super.onRowPrepared(row);


        let j = 0;

        for (j = 0; j < row.columns.length; j++) {
            if (row.columns[j].dataField == "Triage") {
                break;
            }
        }

        if (row.rowElement.firstItem() !== undefined && row.rowType !== 'header' && row.rowType !== 'filter' && row.rowElement.firstItem() !== undefined && row.rowElement.firstItem().cells[j] !== undefined) {

            let data: ExaminationWorkListItem = row.data as ExaminationWorkListItem;
            let currentValueforTriage = data.Triage;
            {
                if (data.Triage != null) {
                    if (data.Triage.Equals("YEŞİL")) {
                        row.rowElement.firstItem().cells[j].bgColor = '#84e684';
                    }

                    if (data.Triage.Equals("SARI")) {
                        row.rowElement.firstItem().cells[j].bgColor = '#f1f10b';
                    }

                    if (data.Triage.Equals("KIRMIZI")) {
                        row.rowElement.firstItem().cells[j].bgColor = '#ffa5a5';

                    }

                    if (data.Triage.Equals("SİYAH")) {
                        row.rowElement.firstItem().cells[j].bgColor = '#756c6c';

                    }
                }

            }
        }


    }

    //htmldeki  Listeleme İşlemi ismi hep btnSearchClicked olsun
    fillList() {

        super.fillList();

        let that = this;
        if (that.examinationWorkListViewModel._SearchCriteria.policlinic_EA && (that.examinationWorkListViewModel._SearchCriteria.ActionStatus == null || that.examinationWorkListViewModel._SearchCriteria.ActionStatus.length <= 0)) {
            ServiceLocator.MessageService.showError("En az bir işlem durumu seçiniz.");
        }
        else if (that.examinationWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA && (that.examinationWorkListViewModel._SearchCriteria.ReportStatus == null || that.examinationWorkListViewModel._SearchCriteria.ReportStatus.length <= 0)) {
            ServiceLocator.MessageService.showError("En az bir işlem durumu seçiniz.");
        }
        else {
            this.loadSearchingPanel();
            that.httpService.post<ExaminationWorkListViewModel>("api/ExaminationWorkListService/GetExaminationWorkList", that.examinationWorkListViewModel._SearchCriteria)
                .then(response => {

                    let viewModel: ExaminationWorkListViewModel = response as ExaminationWorkListViewModel;

                    that.examinationWorkListViewModel.WorkList = viewModel.WorkList; // Array < InPatientWorkListItem >
                    that.examinationWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                    //that.examinationWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                    //that.saveOrtezWorklistFilterUserOption();
                    //that.systemApiService.componentInfo = null;
                    that.unloadSearchingPanel();

                })
                .catch(error => {
                    that.unloadSearchingPanel();
                    that.messageService.showError(error);

                });
        }
    }

    ngOnInit() {
        // this.OpenLcdMonitor();
    
    }

    ngOnDestroy() {
        super.ngOnDestroy();
        this.RemoveMenuFromHelpMenu();
    }

    loadViewModel() {

        let that = this;
        let fullApiUrl: string = "/api/ExaminationWorkListService/LoadExaminationWorkListViewModel";
        this.httpService.get<ExaminationWorkListViewModel>(fullApiUrl)
            .then(response => {
                that.examinationWorkListViewModel = response as ExaminationWorkListViewModel;
                that.ViewModel = response as BaseEpisodeActionWorkListFormViewModel;

                if (this.examinationWorkListViewModel._SearchCriteria.policlinic_EA == true)
                    that.radioGroupEAType_Value = 1;
                else if (this.examinationWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA == true)
                    that.radioGroupEAType_Value = 2;

                if (that.examinationWorkListViewModel._SearchCriteria.ActionNames == null || that.examinationWorkListViewModel._SearchCriteria.ActionNames.length == 0) {
                    that.examinationWorkListViewModel._SearchCriteria.ActionNames = new Array<ListObject>();
                    for (let i = 0; i < 5; i++) {
                        that.examinationWorkListViewModel._SearchCriteria.ActionNames.push(that.selectedActionNameListItems[i]);
                    }
                }
                //that.examinationWorkListViewModel._SearchCriteria.ActionNames = that.selectedActionNameListItems;
                if (that.examinationWorkListViewModel._SearchCriteria.policlinic_EA) {
                    if (that.examinationWorkListViewModel._SearchCriteria.ActionStatus == null || that.examinationWorkListViewModel._SearchCriteria.ActionStatus.length == 0) {
                        that.examinationWorkListViewModel._SearchCriteria.ActionStatus = new Array<ListObject>();
                        that.examinationWorkListViewModel._SearchCriteria.ActionStatus.push(that.selectedActionStateListItems[0]); //Bekleyen
                    }
                }
                if (that.examinationWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA) {
                    if (that.examinationWorkListViewModel._SearchCriteria.ReportStatus == null || that.examinationWorkListViewModel._SearchCriteria.ReportStatus.length == 0) {
                        that.examinationWorkListViewModel._SearchCriteria.ReportStatus = new Array<ListObject>();
                        that.examinationWorkListViewModel._SearchCriteria.ReportStatus.push(that.selectedReportStateListItems[0]); //Bekleyen
                    }
                }
                if (that.examinationWorkListViewModel._SearchCriteria.PatientType == null || that.examinationWorkListViewModel._SearchCriteria.PatientType == 0) {
                    if (that.activeUserService.isPoolQueue)
                        that.examinationWorkListViewModel._SearchCriteria.PatientType = 2;
                    else
                        that.examinationWorkListViewModel._SearchCriteria.PatientType = 1;
                }

                // serverdan gelen listelerin referansı farklı olduğu için böyle bir yola gitmek gerekti
                let _tempSection = new Array<ResSection>();
                that.examinationWorkListViewModel._SearchCriteria.Resources.forEach(element => {
                    let listItem = that.examinationWorkListViewModel.ResourceList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                    if (listItem) {
                        _tempSection.push(listItem);
                    }
                });

                that.examinationWorkListViewModel._SearchCriteria.Resources = new Array<ResSection>();
                that.examinationWorkListViewModel._SearchCriteria.Resources = _tempSection;

                that.examinationWorkListViewModel._SearchCriteria.doNotListCalleds == false;

                this.AddHelpMenu();
                this.loadMedulaPasswordPanelParameter();
                setTimeout(function () {
                    that.WorkListGrid.instance.repaint();
                }, 30);
            })
            .catch(error => {
                console.log(error);
            });

    }

    public async loadMedulaPasswordPanelParameter () {
        let enableMedulaPasswordEntrance: string = (await SystemParameterService.GetParameterValue('MEDULASIFREGIRISEKRANIAKTIF', 'FALSE'));
        if (enableMedulaPasswordEntrance === 'TRUE') {
            this.enableMedulaPasswordEntrance = true;
        }
        else {
            this.enableMedulaPasswordEntrance = false;
        }
    }

    patientChanged(patient: any) {
        if (patient) {
            this.examinationWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
            this.btnSearchClicked();
        }
        else
            this.examinationWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    ngAfterViewInit(): void {
        let that = this;
        super.ngAfterViewInit();
        //this.AddHelpMenu();
        //setTimeout(function () {
        //    that.WorkListGrid.instance.repaint();
        //}, 30);
    }

    onradioGroupPatientType_ValueChanged(e: any) {

        //if (e.value == 2) {
        //    this.examinationWorkListViewModel._SearchCriteria. = false;
        //    this.inPatientWorkListViewModel._SearchCriteria.consultation_EA = true;
        //}
        //else {
        //    this.inPatientWorkListViewModel._SearchCriteria.inPatientPhysicianApplication_EA = true;
        //    this.inPatientWorkListViewModel._SearchCriteria.consultation_EA = false;
        //}


    }

    public ListReports() {
        let that = this;
        this.loadSearchingPanel();
        let requestString = "api/ExaminationWorkListService/getHeadDoctorApproveReports?startDate=" + this.ReportStartDate.ToShortDateString() + "&endDate=" + this.ReportEndDate.ToShortDateString();
        that.httpService.get<ExaminationWorkListViewModel>(requestString)
            .then(response => {

                let viewModel: ExaminationWorkListViewModel = response as ExaminationWorkListViewModel;

                that.examinationWorkListViewModel.ReportApproveWorkList = viewModel.WorkList; // Array < InPatientWorkListItem >
                //that.examinationWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                //that.examinationWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                //that.saveOrtezWorklistFilterUserOption();
                //that.systemApiService.componentInfo = null;
                that.unloadSearchingPanel();

            })
            .catch(error => {
                that.unloadSearchingPanel();
                that.messageService.showError(error);

            });
    }

    public async MedulaPasswordSignedApprovePanel(approveModel: SendWorklistSignedReportApproveModel): Promise<void> {
        let userNamePwdInput = new UsernamePwdInput();
        userNamePwdInput.GetMkysUsernameOnInit = false;
        userNamePwdInput.SessionStoragePwdName = 'MedulaPwd';
        userNamePwdInput.SessionStorageUsername = 'MedulaUsername';
        userNamePwdInput.Title = 'E-Rapor Kaydet';
        userNamePwdInput.GetUserUniqueRefNoOnInit = true;

        let userNamePwdResult = await UsernamePwdBox.Show(false, userNamePwdInput);
        if ((<ModalActionResult>userNamePwdResult).Result === DialogResult.OK) {
            let params = <UsernamePwdFormViewModel>(<ModalActionResult>userNamePwdResult).Param;
            approveModel.medulaUsername = params.userName;
            approveModel.medulaPassword = params.password;
        }
    }

    selectedReports = new Array<Guid>();

    public async ApproveSelectedReports() {
        let eSignatureNeeded = false;
        for (let j = 0; j < this.selectedReports.length; j++) {
            let element = this.examinationWorkListViewModel.ReportApproveWorkList.find(x=> x.ObjectID == this.selectedReports[j]);
            if(element.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f"){
                eSignatureNeeded = true;
                break;
            }
        }
        let approveModel: SendWorklistSignedReportApproveModel = new SendWorklistSignedReportApproveModel();
        if(this.enableMedulaPasswordEntrance == true){
            await this.MedulaPasswordSignedApprovePanel(approveModel);
            if(String.isNullOrEmpty(approveModel.medulaUsername) || String.isNullOrEmpty(approveModel.medulaPassword)){
                ServiceLocator.MessageService.showError("Kullanıcı Adınız veya şifreniz boş olamaz.!");
                return;
            }
        }
        if(eSignatureNeeded == true)
            await this.signService.showLoginModal();
        this.panelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

        try {
            for (let i = 0; i < this.selectedReports.length; i++) {
                approveModel.reportObjectId = this.selectedReports[i];
                let element = this.examinationWorkListViewModel.ReportApproveWorkList.find(x => x.ObjectID == this.selectedReports[i]);
                if (element.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f") {
                    await this.sendDrugReportRow(approveModel, this.selectedReports[i]);
                } else if (element.ObjectDefID.toString() == "7e8b0668-9e8f-4075-8122-a829279a85d7") {
                    await this.sendMedicalStuffReportRow(approveModel, this.selectedReports[i]);
                }
            }

            this.panelOperation(false, '');


        } catch{

        }
    }

    public async sendDrugReportRow(approveModel: SendWorklistSignedReportApproveModel, elementGuid: Guid) {
        let rowIndex = this.dataGrid.instance.getRowIndexByKey(elementGuid);
        let element = this.examinationWorkListViewModel.ReportApproveWorkList.find(x => x.ObjectID == elementGuid);
        try {

            let signedReportOutput: string = await this.httpService.post<string>('/api/ExaminationWorkListService/PrepareSignedReportHeadDoctorApproveContent', approveModel);

            let signedContent: string = await this.signService.signContent(signedReportOutput);


            approveModel.signContent = signedContent
            let result = <IlacRaporuServis.imzaliEraporBashekimOnayCevapDVO>await this.httpService.post('/api/ExaminationWorkListService/SendSignedReportHeadDoctorApproveContent', approveModel);
            if (result != null && result.sonucKodu === '0000') {
                element.RowColor = '#84e684';
                element.StateName = "Rapor Onaylandı";

            }
            else if (result != null && result.sonucKodu === 'RAP_0047') {
                element.RowColor = '#84e684';
                element.StateName = "Rapor Onaylandı";


            } else {
                if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                    element.RowColor = '#ffa5a5';
                    element.StateName = result.uyariMesaji + " " + result.sonucMesaji;

                }
            }

        }
        catch (ex) {
            console.log(ex);
            let a = ex;
            element.RowColor = '#ffa5a5';
            element.StateName = "Bir Hata ile Karşılaşıldı";
        }
        finally {
            this.changeDetectorRef.detectChanges();

            let rowElement = this.dataGrid.instance.getRowElement(rowIndex);
            if (rowElement != null && rowElement.length > 0) {
                rowElement[0].style.backgroundColor = element.RowColor;
            }
        }




    }

    public async sendMedicalStuffReportRow(approveModel: SendWorklistSignedReportApproveModel, elementGuid: Guid) {
        let rowIndex = this.dataGrid.instance.getRowIndexByKey(elementGuid);
        let element = this.examinationWorkListViewModel.ReportApproveWorkList.find(x => x.ObjectID == elementGuid);

        try {

            let result = <eRaporOnayCevapDVO>await this.httpService.post('/api/ExaminationWorkListService/TibbiMalzemeRaporuBashekimOnay', approveModel);
            if (result != null && result.sonucKodu === '0000') {
                element.RowColor = '#84e684';
                element.StateName = "Rapor Onaylandı";
    
            }
            else if (result != null && result.sonucKodu === 'RAP_0047') {
                element.RowColor = '#84e684';
                element.StateName = "Rapor Onaylandı";
    
    
            } else {
                if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                    element.RowColor = '#ffa5a5';
                    element.StateName = result.uyariMesaji + " " + result.sonucMesaji;
    
                }
            }
        }
        catch (ex) {
            console.log(ex);
            let a = ex;
            element.RowColor = '#ffa5a5';
            element.StateName = "Bir Hata ile Karşılaşıldı";
        }
        finally{
            this.changeDetectorRef.detectChanges();

            let rowElement = this.dataGrid.instance.getRowElement(rowIndex);
            if (rowElement != null && rowElement.length > 0) {
                rowElement[0].style.backgroundColor = element.RowColor;
            }
        }
        


        

    }

    public onMHRSAppointmentsReport(event) {

        let currentDate: Date = new Date(Date.now());
        let sdate: Date = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate(), 0, 0, 0, 0);
        let edate: Date = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate(), 23, 59, 59, 0);
        let masterResource: GuidParam = new GuidParam();
        if (this.activeUserService.SelectedOutPatientResource) {
            masterResource = new GuidParam(this.activeUserService.SelectedOutPatientResource.ObjectID.toString());
        }
        let resource: GuidParam = new GuidParam();
        if (this.activeUserService.ActiveUser.UserObject) {
            resource = new GuidParam(this.activeUserService.ActiveUser.UserObject.ObjectID.toString());
        }
        let reportParameters: any = { 'MASTERRESOURCE': masterResource, 'RESOURCE': resource, 'STARTDATE': new DateParam(sdate), 'ENDDATE': new DateParam(edate) };

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

        if (this.examinationWorkListViewModel.hasHeadDoctorRole == true) {
            let ReportHeadDoctorApprove = new DynamicSidebarMenuItem();
            ReportHeadDoctorApprove.key = 'ReportHeadDoctorApprove';
            ReportHeadDoctorApprove.icon = 'fa fa-file-text-o';
            ReportHeadDoctorApprove.label = "Toplu Başhekim Onay";
            ReportHeadDoctorApprove.componentInstance = this;
            ReportHeadDoctorApprove.clickFunction = this.ReportHeadDoctorApprove;
            this.sideBarMenuService.addMenu('YardimciMenu', ReportHeadDoctorApprove);

        }
        if (this.examinationWorkListViewModel.isNewLcd == "TRUE") {
            let SetLCDNotification = new DynamicSidebarMenuItem();
            SetLCDNotification.key = 'SetLCDNotification';
            SetLCDNotification.icon = 'fa fa-file-text-o';
            SetLCDNotification.label = "LCD Bilgi Ekle";
            SetLCDNotification.componentInstance = this;
            SetLCDNotification.clickFunction = this.SetLCDNotification;
            this.sideBarMenuService.addMenu('YardimciMenu', SetLCDNotification);
        }
        let pandemicPatientReport = new DynamicSidebarMenuItem();
        pandemicPatientReport.key = 'pandemicPatientReport';
        pandemicPatientReport.icon = 'fa fa-file-text-o';
        pandemicPatientReport.label = "Pandemi Hasta Listesi Raporu";
        pandemicPatientReport.componentInstance = this;
        pandemicPatientReport.clickFunction = this.onPrintPandemicReport;
        this.sideBarMenuService.addMenu('ReportMainItem', pandemicPatientReport);
    }

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
                if (this.examinationWorkListViewModel.LCDNotificationList.length > 0) {
                    let listItem: LCDNotificationDefinition = this.examinationWorkListViewModel.LCDNotificationList.find(o => o.ObjectID.toString() === response.ObjectID.toString());
                    this.examinationWorkListViewModel.LCDNotification = listItem;
                }
                else
                    this.examinationWorkListViewModel.LCDNotification = null;
            }
            else
                this.examinationWorkListViewModel.LCDNotification = null;
            //this.examinationWorkListViewModel.LCDNotification = <LCDNotificationDefinition>response;
        });
        //this.examinationWorkListViewModel.LCDNotification = lcdNotification;
        this.showLCDNotificationForm = true;
    }

    async lcdNotificationItemChanged(value: any) {
        if (typeof value == 'object') {
            if (value) {
                let lcdNotification: LCDNotificationDefinition = <LCDNotificationDefinition>value;
                this.examinationWorkListViewModel.LCDNotification = lcdNotification;
            }
            else
                this.examinationWorkListViewModel.LCDNotification = null;
        }
    }

    async popLCDNotification(data: any) {
        this.showLCDNotificationForm = false;
        let queueID = this.activeUserService.SelectedQueue.ObjectID;
        await CommonService.SetLCDNotification(queueID,this.examinationWorkListViewModel.LCDNotification);
    }


    public ReportApproveVisible = false;
    public ReportStartDate: Date = new Date();
    public ReportEndDate: Date = new Date();
    public ReportHeadDoctorApprove() {
        this.ReportApproveVisible = true;
    }
    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('onMHRSAppointmentsReport');
        if (this.examinationWorkListViewModel.hasHeadDoctorRole == true)
            this.sideBarMenuService.removeMenu('ReportHeadDoctorApprove');
        if (this.examinationWorkListViewModel.isNewLcd == "TRUE")
            this.sideBarMenuService.removeMenu('SetLCDNotification');
        this.sideBarMenuService.removeMenu('pandemicPatientReport');

    }

    ///#region LCD BEGİN
    async OpenLcdMonitor() {
        this.loadSearchingPanel();
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
            if (this.examinationWorkListViewModel.isNewLcd == "FALSE") {
                try {

                    let names: any = this.activeUserService.ActiveUser.UserObject;
                    let doktorName = names.Name.toString();
                    let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
                    let currentLocation = window.location.href.replace("/ayaktanislistesi", "");
                    let url = currentLocation + "/PatientCaller/HastaCagriForm2?currentResUserID=00000000-0000-0000-0000-000000000000&outPatientResID=" + outPatientResID + "&includeCalleds=false&doktorName=" + doktorName;
                    let input: any = { Url: encodeURI(url) };
                    console.log(input);
                    let httpPrintServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
                    this.httpService.post(httpPrintServiceUrl, input);
                    sessionStorage.setItem('isLCDOpened', 'true');
                    this.unloadSearchingPanel();
                }
                catch (e) {
                    sessionStorage.setItem('isLCDOpened', 'false');
                    this.unloadSearchingPanel();
                }
            } else {
                try {

                    let names: any = this.activeUserService.ActiveUser.UserObject;
                    let doktorName = names.Name.toString();
                    let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
                    let currentLocation = window.location.href.replace("/ayaktanislistesi", "");
                    let httpPrintServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
                    let url;
                    let polLCDOnlyCalledPatient = await SystemParameterService.GetParameterValue('POLICLINICLCDONLYCALLEDPATIENT', 'TRUE');
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
                    this.unloadSearchingPanel();
                }
                catch (e) {
                    sessionStorage.setItem('isLCDOpened', 'false');
                    this.unloadSearchingPanel();
                }
            }
        }
    }



    openEmergencyLcd() {
        let names: any = this.activeUserService.ActiveUser.UserObject;
        let doktorName = names.Name.toString();
        let outPatientResID = this.activeUserService.SelectedQueue.ObjectID;
        let currentLocation = window.location.href.replace("/ayaktanislistesi", "");
        let url = currentLocation + "/lcd/emergenyCallPatientForm?showAsAnonymous&IDS=" + outPatientResID + "&DrName=" + doktorName + "&DrObjectID=" + this.activeUserService.ActiveUser.UserObject.ObjectID;
        let input: any = { Url: encodeURI(url) };
        console.log(input);
        let httpServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
        this.httpService.post(httpServiceUrl, input);
        sessionStorage.setItem('isLCDOpened', 'true');
        this.unloadSearchingPanel();
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
            let currentLocation = window.location.href.replace("/ayaktanislistesi", "");
            audio.src = currentLocation + "/Content/doorbell.wav";
            audio.load();
            audio.play();
            let param: SetPatientStatusParam = new SetPatientStatusParam();
            param.result = result;
            param.examinationQueueItem = that.examinationRetunClass.examinationQueueItem;
            that.setPatientStatusParam(param);
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
                        that.loadCompComponent();
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
        else if (!CommonHelper.getInnerText(this.PatientCallDesc.toString())) {
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
            await this.AutoCallSelectedPatient(data).then(
                x => {
                    this.openDynamicComponent(data.ObjectDefName, data.ObjectID);
                    this.PatientCallDesc = null;
                    this.currentRowData = null;
                }
            ).catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.unloadCompComponent();
            });
        }
        catch (e) { this.unloadCompComponent(); }
    }

    async AutoCallSelectedPatient(data: any) : Promise<any> {
        try {
            //
            if (!this.activeUserService.SelectedQueue)
                this.getQueueList();
            if (this.activeUserService.SelectedQueue == undefined && this.queueList.length == 0) {
                await CommonService.openUserResourceSelectionView();
            }

            let audio = new Audio();
            let currentLocation = window.location.href.replace("/ayaktanislistesi", "");
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
            return this.httpService.post<any>(apiUrl, attt).then(ret => {
                this.examinationWorkListViewModel.LCDNotification = null;
                this.showLCDNotificationForm = false;
            }).catch(error => {
                //ServiceLocator.MessageService.showError(error);
                TTVisual.InfoBox.Alert("Uyarı", error, MessageIconEnum.ErrorMessage);
                this.unloadCompComponent();
            });
        }
        catch (e) { this.unloadCompComponent(); }
    }

    ///#region LCD END

    public selectTrackingPatient(value: any)
    {
        let component = value.component,
        prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        let _data = value.data as FollowingPatientList;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            
            let that = this;
            try {
                if(_data.Type == "Kabul Bazlı")
                {
                    this.examinationWorkListViewModel._SearchCriteria.ProtocolNo = _data.ProtocolNO;                    
                    this.showTrackingPatients = false;
                    super.btnSearchClicked();
                }
                else if (_data.Type == "Arşiv Bazlı")
                {                                 
                    this.showTrackingPatients = false;
                    this.examinationWorkListViewModel._SearchCriteria.PatientObjectID = _data.PatientID.toString();
                    this.btnSearchClicked();
                }
            }
            catch (error) {
                that.messageService.showError(error);
            }
        }
    }


    public PandemicStartDate: Date = new Date();
    public PandemicEndDate: Date = new Date();
    public pandemicReport: boolean = false;
    public PandemicReportResources: Array<Guid> = new Array <Guid>();
    public async onPrintPandemicReport() {
        this.pandemicReport = true;
    }

    public async GetPandemicReport(): Promise<ModalActionResult> {
        

        let that = this;

        let reportData: DynamicReportParameters = {

            Code: 'PANDEMIRAPORU',
            ReportParams: { BaslangicTarihi: this.PandemicStartDate, BitisTarihi: this.PandemicEndDate, Poliklinik: this.PandemicReportResources},
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "PANDEMİ HASTA LİSTESİ RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                that.PandemicReportResources=new Array<Guid>();
                that.pandemicReport = false;
            }).catch(err => {
                reject(err);
            });
        });
    }

  

}

