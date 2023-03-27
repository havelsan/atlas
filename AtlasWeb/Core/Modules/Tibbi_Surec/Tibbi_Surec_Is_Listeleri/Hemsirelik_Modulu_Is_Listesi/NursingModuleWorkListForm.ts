
import { Component, Renderer2 } from '@angular/core';
import { NursingModuleWorkListViewModel, NursingModuleWorkListSearchCriteria, NursingModuleWorkListItem, ListObject, InputFor_StateUpdateForSelecetedItem, UnnotifiedBaseTreatmentMaterialViewModel } from './NursingModuleWorkListViewModel';
import { EpisodeActionWorkListStateItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { KScheduleService, GetCompletedKSchedule_Input, GetCompletedKSchedule_Output, CompletedKscheduleAction, PrintBarcodeForGivenActions_Input, DrugBarcodesContainer } from 'ObjectClassService/KScheduleService';
import { BaseTreatmentMaterialUTSUsageNotificationResultViewModel } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialFormViewModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import DataSource from 'devextreme/data/data_source';
import { DatePipe } from '@angular/common';
import { BaseEpisodeActionWorkListForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListForm";
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { SimpleTimer } from 'ng2-simple-timer';
import { IModalService } from 'Fw/Services/IModalService';
import { BaseEpisodeActionWorkListFormViewModel, BaseEpisodeActionWorkListItem } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';
import { CostomDrugOrder } from 'Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/Hemsirelik_Is_Listesi/NursingWorkListViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { OrderTypeEnum, ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { DrugBarcodeInfo, DrugsInfo, DrugUsedInfo } from 'app/Barcode/Models/DrugBarcodeInfo';
import { InpatientTreatmentBarcodeInfo } from 'app/Barcode/Models/InpatientTreatmentBarcodeInfo';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Headers, RequestOptions } from '@angular/http';
import { StockActionService, InputFor_UnnotifiedBaseTreatmentMaterialToUTS } from 'app/NebulaClient/Services/ObjectService/StockActionService';


@Component({
    selector: 'NursingModuleWorkListForm',
    templateUrl: './NursingModuleWorkListForm.html',
    providers: [SystemApiService, MessageService, DatePipe]
})

export class NursingModuleWorkListForm extends BaseEpisodeActionWorkListForm {

    public InpatientTypeList: ListObject[];
    public InpatientTypeResources: DataSource;
    completedActions: CompletedKscheduleAction[];
    selectedRows: any[];
    public radioGroupPatientTypeItems: any[] = [];
    public radioGroupActionTypeItems: any[] = [];

    public PageName = "NursingModuleWorkListForm"; // Kolonlar kullanıcılara göre kaydedilirken Kullanılır

    public _dateFormat = "date";

    public caseOfNeedDrugOrders: Array<CostomDrugOrder>;
    public selectedTempCaseOfNeedItems: Array<CostomDrugOrder>;
    public toolbarCaseOfNeedItems: any[];
    public toolbarItems: any[];


    public _gridSelectionMode = "single";

    public _gridToolBarItem: any[];
    public TreatmentMaterialGridList: Array<any> = new Array<any>();

    constructor(private datePipe: DatePipe, protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, private barcodePrintService: IBarcodePrintService,
        protected activeUserService: IActiveUserService, protected st: SimpleTimer, protected modalService: IModalService, public renderer: Renderer2) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);

        this.InpatientTypeList = [
            {
                TypeName: 'Yatış Bekleyen Hasta',
                TypeID: 0
            }, {
                TypeName: i18n("M15641", "Yatan Hasta"),
                TypeID: 1
            }, {
                TypeName: i18n("M16311", "Taburcu"),
                TypeID: 2
            }
            , {
                TypeName: i18n("M16311", "Ön Taburcu"),
                TypeID: 3
            }
            , {
                TypeName: i18n("M16311", "Günübirlik Yatış"),
                TypeID: 4
            }
        ];

        this.InpatientTypeResources = new DataSource({
            store: this.InpatientTypeList,
            searchOperation: 'contains',
            searchExpr: 'TypeName'
        });

        this.radioGroupPatientTypeItems = [
            { text: "Benim Hastalarım", value: 1 },
            { text: "Tüm Hastalar", value: 2 }
        ];

        this.radioGroupActionTypeItems = [
            { text: "Yatan Hastalar", value: 1 },
            { text: "Hemşirelik Uygulamaları", value: 2 }
        ];

        this.nursingModuleWorkListViewModel._SearchCriteria.DrugOrderStatesItem = new Array<EpisodeActionWorkListStateItem>();
        this.nursingModuleWorkListViewModel._SearchCriteria.NursingOrderStateItem = new Array<EpisodeActionWorkListStateItem>();
        this.nursingModuleWorkListViewModel._SearchCriteria.InpatientTypeResources = new Array<ListObject>();
        this.nursingModuleWorkListViewModel._SearchCriteria.InpatientTypeResources.push(this.InpatientTypeList[1]);

        this.caseOfNeedDrugOrders = new Array<CostomDrugOrder>();
        this.toolbarCaseOfNeedItems = [
            {
                location: 'after',
                widget: 'dxButton',
                locateInMenu: 'auto',
                options: {
                    icon: 'fa fa-check-square-o',
                    text: i18n("M16639", "İstek Oluştur"),
                    type: 'success',
                    onClick: () => {
                        this.controlofPharmcyOpenOrClose();
                    }
                }
            }
        ];

        this.toolbarItems = [

        ];

    }

    utsColumns = [
        {
            caption: "Hasta Adı",
            name: "Patientname",
            dataField: "Patientname",
            alignment: "left",
            width: '15%',
            visibleIndex: 1
        },
        {
            caption: "Hasta Kabul No",
            name: "ProtocolNo",
            dataField: "ProtocolNo",
            alignment: "left",
            width: '10%',
            visibleIndex: 1
        },
        {
            caption: i18n("M27047", "Tarih/Saat"),
            name: "TreatmentMaterialActionDate",
            dataField: "ActionDate",
            alignment: "center",
            format: 'dd/MM/yyyy hh:mm',
            dataType: "datetime",
            width: '12%',
            visibleIndex: 2
        },
        {
            caption: i18n("M12615", "Depo"),
            name: "Store",
            dataField: "Storename",
            width: '22%',
            visibleIndex: 3

        },
        {
            caption: i18n("M12615", "Sarf Malzeme"),
            name: "Material",
            dataField: "Materialname",
            width: '22%',
            visibleIndex: 4

        },
        {
            caption: i18n("M19030", "Miktar"),
            name: "Amount",
            dataField: "Amount",
            alignment: "center",
            width: '5%',
            visibleIndex: 5
        },
        {
            caption: i18n("M27355", "Barkodu"),
            name: "Barcode",
            alignment: "center",
            dataField: "Barcode",
            width: '10%',
            visibleIndex: 6
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            name: "DistributionType",
            alignment: "center",
            dataField: "DistributionType",
            width: '7%',
            visibleIndex: 7
        },
        {
            caption: i18n("M19485", "Notlar"),
            name: "Notes",
            dataField: "Note",
            width: '10%',
            visibleIndex: 8
        },
        {
            caption: "UTS Kullanım Bildirimi",
            name: "UTSUseNotification",
            dataField: "Utsusenotification",
            alignment: "center",
            width: '10%',
            visibleIndex: 9
        },
    ];

    private async SendActionsForBarcodePrint(): Promise<void> {
        if (this.selectedRows == null) {
            ServiceLocator.MessageService.showError('İşlem seçiniz!');
            return;
        }
        else {
            if (this.selectedRows.length == 0) {
                ServiceLocator.MessageService.showError('İşlem seçiniz!');
                return;
            }
        }
        for (let item of this.selectedRows) {

            let param2: DrugUsedInfo = new DrugUsedInfo();
            //param2.PatientName = item.PatientNameSurname;
            //param2.BirthDate =item.BirthDate;
            //param2.Clinicname = item.MasterResourceName;

            param2.PatientName = item.PatientNameSurname;
            param2.BirthDate = this.datePipe.transform(new Date(item.BirthDate), 'dd.MM.yyyy');
            param2.ClinicName = item.MasterResourceName;
            let drugName: string = item.text;
            let DrugNames: Array<string> = new Array<string>();
            DrugNames = drugName.split(" ");

            let str1: string = "";
            let str2: string = "";

            for (let val of DrugNames) {

                if (str1.length < 20)
                    str1 += val + " ";
                else
                    str2 += val + " ";
            }
            param2.Drug = str1;
            param2.Drug2 = str2;
            param2.DrugDate = this.datePipe.transform(new Date(item.startDate), 'dd.MM.yyyy ');
            param2.DrugHour = this.datePipe.transform(new Date(item.startDate), 'HH:mm');
            param2.AcceptionNumber = item.KabulNo;
            param2.Room = item.RoomAndBedName;
            param2.Dose = item.Dose + " " + item.UsageType;
            this.barcodePrintService.printAllBarcode(param2, "generateDrugUsedBarcode", "printDrugUsedBarcode");

        }
    }

    public onToolbarPreparing(e: any) {
        super.onToolbarPreparing(e);
        e.toolbarOptions.items.unshift({
            location: 'before',
            widget: 'dxButton',
            locateInMenu: 'auto',
            options: {
                icon: 'preferences',
                text: 'GİÇ Oluştur',
                type: 'success',
                visible: this.nursingModuleWorkListViewModel.GicActive == true ? true : false,
                onClick: () => {
                    this.DailyDrugClick();
                }
            }
        }, {
            location: 'center',
            locateInMenu: 'never',
            template: () => {
                return i18n("M10052", "<div class=\'toolbar-label\'><b>HEMŞİRELİK HİZMETLERİ</b></div>");
            }
        },
            {
                location: 'after',
                widget: 'dxButton',
                locateInMenu: 'auto',
                visible: this.nursingModuleWorkListViewModel._SearchCriteria.ActionType == 2 ? true : false,
                options: {
                    icon: 'fa fa-check-square-o',
                    text: i18n("M23745", "Uygula"),
                    type: 'success',
                    onClick: () => {
                        if (this.selectedRowKeysResultList.length > 0) {
                            this.selectedGridItem();
                        }
                    }
                }
            });
        this._gridToolBarItem = e.toolbarOptions;
    }

    public nursingModuleWorkListViewModel: NursingModuleWorkListViewModel = new NursingModuleWorkListViewModel();

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: i18n("M16650", "Tarih"),
                dataField: "startDate",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm:ss',
                width: 100,
                allowSorting: true,
                visible: true,
                //cssClass: 'worklistGridCellFont'
            },
            {
                caption: i18n("M21815", "Alerji Durumu"),
                dataField: "MedicalInformation",
                dataType: 'string',
                width: 50,
                allowSorting: true,
                visible: true
            },
            {
                caption: i18n("M15133", "Hasta Adı Soyadı"),
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: "auto",
                minWidth: 100,
                visible: true,
                allowSorting: true
            },
            {
                caption: i18n("M20080", "Özel Durum"),
                dataField: "OzelDurum",
                dataType: 'string',
                width: 100,
                cellTemplate: "PriorityCellTemplate", // Yaşlı Genç için html tarafına referans
                visible: true,
                allowSorting: true
            },
            {
                caption: i18n("M16818", "İşlem"),
                dataField: "text",
                dataType: 'string',
                width: 'auto',
                minWidth: 100,
                visible: true,
                allowSorting: true
            },
            {
                caption: i18n("M16838", "Durumu"),
                dataField: "statusName",
                dataType: 'string',
                width: 'auto',
                minWidth: 100,
                visible: true,
                allowSorting: true
            },
            {
                "caption": i18n("M22078", "Sonuç"),
                dataField: "Result",
                dataType: 'string',
                width: "auto",
                allowSorting: false,
                visible: false,
                //cssClass: 'worklistGridCellFont',
            },
            {
                "caption": i18n("M19485", "Notlar"),
                dataField: "doctorDescription",
                dataType: 'string',
                width: "auto",
                allowSorting: false,
                visible: false,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27304", "Birim"),
                dataField: "MasterResourceName",
                dataType: 'string',
                width: "auto",
                minWidth: 100,
                visible: true,
                allowSorting: true,
            },
            {
                caption: i18n("M30111", "Oda/Yatak "),
                dataField: "RoomAndBedName",
                dataType: 'string',
                width: "auto",
                visible: true,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27384", "Hemşire Adı"),
                dataField: "ResponsibleNurse",
                dataType: 'string',
                width: "auto",
                visible: true,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27339", "Doktoru"),
                dataField: "DoctorName",
                dataType: 'string',
                width: 130,
                visible: false,
                allowSorting: true,
                //  cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: "KabulNo",
                dataType: 'string',
                width: 100,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M14664", "Geliş Sebebi"),
                dataField: "ComingReason",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M18035", "Kurum Bilgisi"),
                dataField: "PayerInfo",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M13132", "Doğum Tarihi"),
                dataField: "BirthDate",
                dataType: 'date',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M11390", "Baba Adı"),
                dataField: "FatherName",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            }
            ,
            {
                caption: i18n("M23138", "Telefon Numarası"),
                dataField: "PhoneNumber",
                dataType: 'string',
                width: 150,
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            }, {
                caption: i18n("M22514", "T.C. Kimlik No"),
                dataField: "UniqueRefno",
                dataType: 'string',
                width: 120,
                visible: false,
                allowSorting: true
            }, {
                caption: i18n("M15322", "Hasta Türü"),
                dataField: "HastaTuru",
                dataType: 'string',
                width: 120,
                visible: false,
                allowSorting: true
            }, {
                caption: i18n("M27441", "Başvuru Türü"),
                dataField: "BasvuruTuru",
                dataType: 'string',
                width: 120,
                visible: false,
                allowSorting: true
            }, {
                caption: i18n("M20989", "Refakatçi"),
                dataField: "Companion",
                dataType: 'string',
                width: 120,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M27384", "Uygulayan Adı"),
                dataField: "ProcedureByUser",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27384", "Uygulama Zamanı"),
                dataField: "ExecutionDate",
                dataType: 'datetime',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            }

        ];
        super.GenerateResultListColumns(columnNameAndOrder);
    }

    public selectedTabIndex = 0;


    //htmldeki  Listeleme İşlemi ismi hep btnSearchClicked olsun
    fillList() {

        if (this.nursingModuleWorkListViewModel._SearchCriteria.ActionType == 2) {
            this.openAsPopup = true;
            this.get_caseOfNeeDrugOrder(this.nursingModuleWorkListViewModel._SearchCriteria);
            this.closeDynamicComponent(); // Daha önceden Sayfada DynamicComponent Sayfada açıldı ise o kapatılır .

        }
        else
            this.openAsPopup = false;

        if (this.selectedTabIndex == 2) {
            this.GetMaterialListWithFilter();
        }

        super.fillList();
        let that = this;
        this.loadSearchingPanel();
        that.httpService.post<NursingModuleWorkListViewModel>("api/NursingModuleWorkListService/GetNursingModuleWorkList", that.nursingModuleWorkListViewModel._SearchCriteria)
            .then(response => {

                let viewModel: NursingModuleWorkListViewModel = response as NursingModuleWorkListViewModel;

                that.nursingModuleWorkListViewModel.WorkList = viewModel.WorkList; // Array < InPatientWorkListItem >
                that.nursingModuleWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                that.unloadSearchingPanel();

            })
            .catch(error => {
                that.unloadSearchingPanel();
                that.messageService.showError(error);

            });



    }

    loadViewModel() {

        let that = this;
        let fullApiUrl: string = "/api/NursingModuleWorkListService/LoadNursingModuleWorkListViewModel";
        this.httpService.get<NursingModuleWorkListViewModel>(fullApiUrl)
            .then(response => {
                that.nursingModuleWorkListViewModel = response as NursingModuleWorkListViewModel;
                that.ViewModel = response as BaseEpisodeActionWorkListFormViewModel;
                //if (this.examinationWorkListViewModel._SearchCriteria.ActionNames == null || this.examinationWorkListViewModel._SearchCriteria.ActionNames.length == 0)
                //    this.examinationWorkListViewModel._SearchCriteria.ActionNames = this.selectedActionNameListItems;
                if (that.nursingModuleWorkListViewModel._SearchCriteria.InpatientTypeResources == null || that.nursingModuleWorkListViewModel._SearchCriteria.InpatientTypeResources.length == 0) {
                    that.nursingModuleWorkListViewModel._SearchCriteria.InpatientTypeResources = new Array<ListObject>();
                    that.nursingModuleWorkListViewModel._SearchCriteria.InpatientTypeResources.push(that.InpatientTypeList[1]); //Bekleyen
                }

                // serverdan gelen listelerin referansı farklı olduğu için böyle bir yola gitmek gerekti
                let _tempList: Array<EpisodeActionWorkListStateItem> = new Array<EpisodeActionWorkListStateItem>();
                that.nursingModuleWorkListViewModel._SearchCriteria.DrugOrderStatesItem.forEach(element => {
                    let listItem = that.nursingModuleWorkListViewModel.DrugOrderWorkListStateItem.find(o => o.StateDefID.toString() === element.StateDefID.toString());
                    if (listItem) {
                        _tempList.push(listItem);
                    }
                });

                that.nursingModuleWorkListViewModel._SearchCriteria.DrugOrderStatesItem = new Array<EpisodeActionWorkListStateItem>();
                that.nursingModuleWorkListViewModel._SearchCriteria.DrugOrderStatesItem = _tempList;

                // serverdan gelen listelerin referansı farklı olduğu için böyle bir yola gitmek gerekti
                _tempList = new Array<EpisodeActionWorkListStateItem>();
                that.nursingModuleWorkListViewModel._SearchCriteria.NursingOrderStateItem.forEach(element => {
                    let listItem = that.nursingModuleWorkListViewModel.NursingOrderWorkListStateItem.find(o => o.StateDefID.toString() === element.StateDefID.toString());
                    if (listItem) {
                        _tempList.push(listItem);
                    }
                });

                that.nursingModuleWorkListViewModel._SearchCriteria.NursingOrderStateItem = new Array<EpisodeActionWorkListStateItem>();
                that.nursingModuleWorkListViewModel._SearchCriteria.NursingOrderStateItem = _tempList;

                // serverdan gelen listelerin referansı farklı olduğu için böyle bir yola gitmek gerekti
                let _tempSection = new Array<ResSection>();
                that.nursingModuleWorkListViewModel._SearchCriteria.Resources.forEach(element => {
                    let listItem = that.nursingModuleWorkListViewModel.ResourceList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                    if (listItem) {
                        _tempSection.push(listItem);
                    }
                });

                that.nursingModuleWorkListViewModel._SearchCriteria.Resources = new Array<ResSection>();
                that.nursingModuleWorkListViewModel._SearchCriteria.Resources = _tempSection;

                if (that.nursingModuleWorkListViewModel._SearchCriteria.PatientType == null || that.nursingModuleWorkListViewModel._SearchCriteria.PatientType == 0)
                    that.nursingModuleWorkListViewModel._SearchCriteria.PatientType = 1;
                if (that.nursingModuleWorkListViewModel._SearchCriteria.ActionType == null || that.nursingModuleWorkListViewModel._SearchCriteria.ActionType == 0)
                    that.nursingModuleWorkListViewModel._SearchCriteria.ActionType = 1;

                setTimeout(function () {
                    that.WorkListGrid.instance.repaint();
                }, 30);
            })
            .catch(error => {
                console.log(error);
            });

    }

    patientChanged(patient: any) {
        if (patient) {
            this.nursingModuleWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
            this.btnSearchClicked();
        }
        else
            this.nursingModuleWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    ngAfterViewInit(): void {
        let that = this;
        super.ngAfterViewInit();
        //setTimeout(function () {
        //    that.WorkListGrid.instance.repaint();
        //}, 30);
    }

    onradioGroupActionType_ValueChanged(e: any) {
        let that = this;
        if (e.value == 1) {
            this._dateFormat = "date";
            //$('#WorkListGrid').dxDataGrid('columnOption', 'Result', 'visible', false);
            //$('#WorkListGrid').dxDataGrid('columnOption', 'doctorDescription', 'visible', false);

            // if(this.WorkListGrid.columns.find(x => x.dataField == "Result") != null)
            // {
            // this.WorkListGrid.columns.find(x => x.dataField == "Result").visible = false;
            // setTimeout(function () {
            //     that.WorkListGrid.instance.refresh();
            // }, 30);
            // }

            // this.WorkListColumns.find(x => x.dataField == "Result").visible = false;

            if (this.WorkListColumns.find(x => x.dataField == "Result") != null) {
                this.WorkListColumns.find(x => x.dataField == "Result").visible = false;
            }

            if (this.WorkListColumns.find(x => x.dataField == "doctorDescription") != null) {
                this.WorkListColumns.find(x => x.dataField == "doctorDescription").visible = false;
            }

            if (this.WorkListGrid.instance != null) {
                this._gridSelectionMode = "single";
            }

            //uygula butonu
            let _after = this._gridToolBarItem["items"].find(x => x.location == "after");
            if (_after != null)
                _after.visible = false;

            this.clearGridItems();
        }
        else {
            this._dateFormat = "datetime";
            // if(this.WorkListGrid.columns.find(x => x.dataField == "Result") != null)
            // {
            // this.WorkListGrid.columns.find(x => x.dataField == "Result").visible = true;
            // setTimeout(function () {
            //     that.WorkListGrid.instance.refresh();
            // }, 30);
            // }

            // this.WorkListColumns.find(x => x.dataField == "Result").visible = true;

            if (this.WorkListColumns.find(x => x.dataField == "Result") != null) {
                this.WorkListColumns.find(x => x.dataField == "Result").visible = true;
            }

            if (this.WorkListColumns.find(x => x.dataField == "doctorDescription") != null) {
                this.WorkListColumns.find(x => x.dataField == "doctorDescription").visible = true;
            }

            if (this.WorkListGrid.instance != null) {
                this._gridSelectionMode = "multiple";
            }

            //uygula butonu
            let _after = this._gridToolBarItem["items"].find(x => x.location == "after");
            if (_after != null)
                _after.visible = true;

            this.clearGridItems();
            //$('#WorkListGrid').dxDataGrid('columnOption', 'Result', 'visible', true);
            //$('#WorkListGrid').dxDataGrid('columnOption', 'doctorDescription', 'visible', true);
        }

    }

    clearGridItems() {
        this.nursingModuleWorkListViewModel.WorkList = new Array<NursingModuleWorkListItem>();
        this.selectedRowKeysResultList = null;
    }

    onStartDateChanged(event: any) {
        this.nursingModuleWorkListViewModel._SearchCriteria.WorkListStartDate = event.value;
    }

    onEndDateChanged(event: any) {
        this.nursingModuleWorkListViewModel._SearchCriteria.WorkListEndDate = event.value;
    }

    onResourceListChanged(event: any) {
        //this.nursingModuleWorkListViewModel._SearchCriteria.Resources = event.value;
    }

    async get_caseOfNeeDrugOrder(input: NursingModuleWorkListSearchCriteria) {
        let inputDvo = input;
        let that = this;

        let fullApiUrl: string = 'api/NursingModuleWorkListService/Get_caseOfNeeDrugOrder';
        that.httpService.post<CostomDrugOrder[]>(fullApiUrl, inputDvo)
            .then(response => {
                that.caseOfNeedDrugOrders = response as CostomDrugOrder[];
            })
            .catch(error => {
                console.log(error);
            });
    }

    async controlofPharmcyOpenOrClose() {
        let that = this;
        let fullApiUrl: string = 'api/NursingModuleWorkListService/controlOfPharmacyOpenned';
        that.httpService.post(fullApiUrl, null)
            .then((res: boolean) => {
                if (that.selectedTempCaseOfNeedItems != null && that.selectedTempCaseOfNeedItems.length > 0) {
                    if (res) {
                        that.createByCaseOfNeed(that.selectedTempCaseOfNeedItems);
                    }
                    else {
                        that.awaitCreateDrugOrder();
                    }
                }

            })
            .catch(error => {
                console.log(error);
            });
    }

    async awaitCreateDrugOrder() {
        let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", i18n("M13443", "Ecz. Kapalı Genede İste"));
        if (result === "OK") {
            this.createByCaseOfNeed(this.selectedTempCaseOfNeedItems);
        }
    }

    async createByCaseOfNeed(items: Array<CostomDrugOrder>) {
        if (items.length > 0) {
            let inputCaseOfNeed = items;
            let that = this;
            let fullApiUrl: string = 'api/NursingModuleWorkListService/Create_CaseOfNeeDrugOrder';
            that.httpService.post(fullApiUrl, inputCaseOfNeed)
                .then((res: string) => {
                    ServiceLocator.MessageService.showInfo(res);
                    that.caseOfNeedDrugOrders = new Array<any>();
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }

    async  DailyDrugClick() {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DailyDrugScheduleNewForm';
            componentInfo.ModuleName = 'GunlukIlacCizelgesiModule';
            componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Gunluk_Ilac_Cizelgesi_Modulu/GunlukIlacCizelgesiModule';

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16335", "İlaç İstek");
            modalInfo.Width = 1200;
            modalInfo.Height = 750;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    async selectDrugOrderDetail(data: any) {
        /**
         * Hemşirelik uygulamaları seçili ise çalışssın
         */
        if (this.nursingModuleWorkListViewModel._SearchCriteria.ActionType == 2) {
            this.selectedRows = data.selectedRowKeys;
            let isMessageShownBefore: boolean = false;
            if (data.currentSelectedRowKeys.length >= 1) {
                if (data.currentSelectedRowKeys != null) {

                    for (let i = 0; (i < data.currentSelectedRowKeys.length); i++) {
                        if ((data.currentSelectedRowKeys[i].typeId === OrderTypeEnum.NursingOrder) ||
                            (DrugOrderDetail.DrugOrderDetailStates.UseRestDose.id !== data.currentSelectedRowKeys[i].stateDefID.toString()
                                && DrugOrderDetail.DrugOrderDetailStates.Supply.id !== data.currentSelectedRowKeys[i].stateDefID.toString())) {


                            if (!isMessageShownBefore && data.currentSelectedRowKeys[i].typeId !== OrderTypeEnum.NursingOrder) //üstten tamamını seçtiği zaman mesajı bir kere göstersin ve hemşire direktif değilse
                                this.messageService.showInfo(i18n("M12087", "Bu işlemler ilerletilemez!"));

                            isMessageShownBefore = true;

                            data.component.deselectRows(data.currentSelectedRowKeys[i]);
                        }
                    }
                }
            }
        }
    }

    selectedGridItem() {
        if (this.selectedRowKeysResultList.length > 0) {
            let inputObj: InputFor_StateUpdateForSelecetedItem = new InputFor_StateUpdateForSelecetedItem();
            inputObj.DrugOrderDetails = new Array<Guid>();

            for (let drugOrderDet of this.selectedRowKeysResultList) {
                inputObj.DrugOrderDetails.push(drugOrderDet.ObjectID);
            }

            this.stateUpdateForSelecetedItem(inputObj);
            this.selectedRowKeysResultList = new Array<BaseEpisodeActionWorkListItem>();
        }
    }

    stateUpdateForSelecetedItem(input: InputFor_StateUpdateForSelecetedItem) {
        let inputDvo = input;
        let that = this;
        let fullApiUrl: string = 'api/NursingModuleWorkListService/StateUpdateForSelecetedItem';
        that.httpService.post(fullApiUrl, inputDvo)
            .then((res: number) => {
                let result = res;
                this.messageService.showInfo(i18n("M16953", "İşlemler Başarılı Şekilde Tamamlandı."));
                this.fillList();
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
    }

    onProtocolNoEnterKeyDown(e) {
        super.btnSearchClicked();
    }

    async GetMaterialListWithFilter() {

        try {
            var intput = new InputFor_UnnotifiedBaseTreatmentMaterialToUTS();
            intput.ResourceIds = new Array<Guid>();
            for (let i = 0; i < this.nursingModuleWorkListViewModel._SearchCriteria.Resources.length; i++) {
                intput.ResourceIds.push(this.nursingModuleWorkListViewModel._SearchCriteria.Resources[i].ObjectID);
            }

            let inputDvo = intput;
            let that = this;
            let fullApiUrl: string = '/api/NursingModuleWorkListService/GetUnnotifiedBaseTreatmentMaterialToUTS';
            that.httpService.post(fullApiUrl, inputDvo)
                .then((res: Array<UnnotifiedBaseTreatmentMaterialViewModel>) => {
                    let result = res;
                    that.TreatmentMaterialGridList = res;
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public async MakeUsageNotificationAll(): Promise<void> {


        var updateList: Array<string> = new Array<string>();
        this.panelOperation(true, 'İşlemler Yapılıyor, lütfen bekleyiniz.');

        for (let i = 0; i < this.TreatmentMaterialGridList.length; i++) {
            if (this.TreatmentMaterialGridList[i].Utsusenotification !== undefined) {
                if (this.TreatmentMaterialGridList[i].Utsusenotification == "Bildirilmedi") {
                    updateList.push(this.TreatmentMaterialGridList[i].ObjectID.toString());
                }
            }
        }

        try {
            let apiUrl = '/api/UTSIslemleriService/MakeUTSUsageNotificationAll';
            await this.httpService.post<any>(apiUrl, updateList).then(response => {
                let result: Array<BaseTreatmentMaterialUTSUsageNotificationResultViewModel> = response;
                if (result != null) {
                    for (var item of result) {
                        if (item.Message == "Succeed") {
                            this.TreatmentMaterialGridList.find(x => x.ObjectId == item.ObjectId).Utsusenotification = item.UTSUseNotificationState;

                        }
                        else {
                            ServiceLocator.MessageService.showError("Hata : " + item.Message);
                        }
                    }
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
        this.panelOperation(false, '');
    }

}

