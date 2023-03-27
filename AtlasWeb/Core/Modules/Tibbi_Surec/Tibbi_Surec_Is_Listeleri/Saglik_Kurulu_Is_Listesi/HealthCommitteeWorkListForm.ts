import { Component, Renderer2 } from '@angular/core';
import { HealthCommitteeWorkListViewModel, HealthCommitteeWorkListItem, ListObject } from './HealthCommitteeWorkListViewModel';
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
import { CostomDrugOrder } from 'Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/Hemsirelik_Is_Listesi/NursingWorkListViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { OrderTypeEnum, ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

@Component({
    selector: 'HealthCommitteeWorkListForm',
    templateUrl: './HealthCommitteeWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class HealthCommitteeWorkListForm extends BaseEpisodeActionWorkListForm {

    public ReportStateList: ListObject[];
    public ReportStateSelections: DataSource;

    public VoteStatusList: ListObject[];

    public PageName = "HealthCommitteeWorkListForm";// Kolonlar kullanıcılara göre kaydedilirken Kullanılır 

    public _dateFormat = "date";

    public caseOfNeedDrugOrders: Array<CostomDrugOrder>;
    public selectedTempCaseOfNeedItems: Array<CostomDrugOrder>;
    public toolbarCaseOfNeedItems: any[];
    public toolbarItems: any[];

    public _gridSelectionMode = "";

    public _gridToolBarItem: any[];

    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService,
        public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer,
        protected modalService: IModalService, public renderer: Renderer2, private sideBarMenuService: ISidebarMenuService) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);

        this.ReportStateList = [
            {
                TypeName: 'Yeni',
                TypeID: 0
            },
            // {
            //     TypeName: "Onay Bekleyen",
            //     TypeID: 1
            // }, 
            {
                TypeName: "Heyet Kabul",
                TypeID: 2
            }, {
                TypeName: "Tamamlanan",
                TypeID: 3
            }, {
                TypeName: "İptal Edilmiş",
                TypeID: 4
            }
        ];

        this.ReportStateSelections = new DataSource({
            store: this.ReportStateList,
            searchOperation: 'contains',
            searchExpr: 'TypeName'
        });

        this.VoteStatusList = [
            {
                TypeName: 'Tümü',
                TypeID: 2
            }, {
                TypeName: "Pozitif",
                TypeID: 1
            }, {
                TypeName: "Negatif",
                TypeID: 0
            }
        ];

        this.healthCommitteeWorkListViewModel._SearchCriteria.HCStateItems = new Array<ListObject>();
        this.healthCommitteeWorkListViewModel._SearchCriteria.HCStateItems.push(this.ReportStateList[1]);

    }

    public healthCommitteeWorkListViewModel: HealthCommitteeWorkListViewModel = new HealthCommitteeWorkListViewModel();

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: i18n("M16650", "Tarih"),
                dataField: "startDate",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 100,
                allowSorting: true,
                visible: true,
                //cssClass: 'worklistGridCellFont'
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
                cellTemplate: "PriorityCellTemplate",// Yaşlı Genç için html tarafına referans
                visible: true,
                allowSorting: true
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: "KabulNo",
                dataType: 'string',
                width: 100,
                visible: true,
                allowSorting: true
            }, {
                caption: i18n("M22514", "T.C. Kimlik No"),
                dataField: "UniqueRefno",
                dataType: 'string',
                width: 120,
                visible: true,
                allowSorting: true
            }, {
                caption: "Rapor Adı",
                dataField: "ReportName",
                dataType: 'string',
                width: 120,
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
            }, {
                caption: "Muayene Durumu",
                dataField: "ExaminationStatus",
                dataType: 'string',
                width: 175,
                visible: true,
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
            },
            {
                caption: i18n("M13132", "Doğum Tarihi"),
                dataField: "BirthDate",
                dataType: 'date',
                width: "auto",
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M11390", "Baba Adı"),
                dataField: "FatherName",
                dataType: 'string',
                width: "auto",
                visible: false,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M23138", "Telefon Numarası"),
                dataField: "PhoneNumber",
                dataType: 'string',
                width: 150,
                visible: false,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont',
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
            },
            {
                caption:  "İptal Nedeni",
                dataField: "ReasonOfCancel",
                dataType: 'string',
                width: 200,
                visible: false,
                allowSorting: false,
                // cssClass: 'worklistGridCellFont',
            }

        ];
        super.GenerateResultListColumns(columnNameAndOrder);
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();



        let disabledReportSecretaryIndex = new DynamicSidebarMenuItem();
        disabledReportSecretaryIndex.key = 'disabledReportSecretaryIndex';
        disabledReportSecretaryIndex.componentInstance = this;
        disabledReportSecretaryIndex.label = 'e-Engelli Sekreter Index';
        disabledReportSecretaryIndex.icon = 'ai ai-recete';
        disabledReportSecretaryIndex.clickFunction = this.openEDisabledSecretaryIndex;
        this.sideBarMenuService.addMenu('YardimciMenu', disabledReportSecretaryIndex);

        let disabledReportCouncilIndex = new DynamicSidebarMenuItem();
        disabledReportCouncilIndex.key = 'disabledReportCouncilIndex';
        disabledReportCouncilIndex.icon = 'ai ai-tibbi-uygulama-istek';
        disabledReportCouncilIndex.label = 'e-Engelli Kurul Ekranı';
        disabledReportCouncilIndex.componentInstance = this;
        disabledReportCouncilIndex.clickFunction = this.openCouncilIndex;
        disabledReportCouncilIndex.parameterFunctionInstance = this;
        disabledReportCouncilIndex.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', disabledReportCouncilIndex);

        let disabledReportCreateApplication = new DynamicSidebarMenuItem();
        disabledReportCreateApplication.key = 'disabledReportCreateApplication';
        disabledReportCreateApplication.componentInstance = this;
        disabledReportCreateApplication.label = 'e-Engelli Hasta Kayıt';
        disabledReportCreateApplication.icon = 'ai ai-recete';
        disabledReportCreateApplication.clickFunction = this.openCreateApplication;
        this.sideBarMenuService.addMenu('YardimciMenu', disabledReportCreateApplication);

        let disabledReportCreateCouncil = new DynamicSidebarMenuItem();
        disabledReportCreateCouncil.key = 'disabledReportCreateCouncil';
        disabledReportCreateCouncil.componentInstance = this;
        disabledReportCreateCouncil.label = 'e-Engelli Kurul İşlemleri';
        disabledReportCreateCouncil.icon = 'ai ai-recete';
        disabledReportCreateCouncil.clickFunction = this.openCouncilDescription;
        this.sideBarMenuService.addMenu('YardimciMenu', disabledReportCreateCouncil);

        let cozgerReportCreateApplication = new DynamicSidebarMenuItem();
        cozgerReportCreateApplication.key = 'cozgerReportCreateApplication';
        cozgerReportCreateApplication.componentInstance = this;
        cozgerReportCreateApplication.label = 'Çözger Hasta Kayıt';
        cozgerReportCreateApplication.icon = 'ai ai-recete';
        cozgerReportCreateApplication.clickFunction = this.openCreateCozgerApplication;
        this.sideBarMenuService.addMenu('YardimciMenu', cozgerReportCreateApplication);

        let cozgerReportSecretaryIndex = new DynamicSidebarMenuItem();
        cozgerReportSecretaryIndex.key = 'cozgerReportSecretaryIndex';
        cozgerReportSecretaryIndex.componentInstance = this;
        cozgerReportSecretaryIndex.label = 'Çözger Sekreter Index';
        cozgerReportSecretaryIndex.icon = 'ai ai-recete';
        cozgerReportSecretaryIndex.clickFunction = this.openCozgerSecretaryIndex;
        this.sideBarMenuService.addMenu('YardimciMenu', cozgerReportSecretaryIndex);

        ///

        let eDurumBildirirReportSecretaryIndex = new DynamicSidebarMenuItem();
        eDurumBildirirReportSecretaryIndex.key = 'eDurumBildirirReportSecretaryIndex';
        eDurumBildirirReportSecretaryIndex.componentInstance = this;
        eDurumBildirirReportSecretaryIndex.label = 'e-Durum Bildirir Sekreter Index';
        eDurumBildirirReportSecretaryIndex.icon = 'ai ai-recete';
        eDurumBildirirReportSecretaryIndex.clickFunction = this.openDurumBildirirSecretaryIndex;
        this.sideBarMenuService.addMenu('YardimciMenu', eDurumBildirirReportSecretaryIndex);

        let eDurumBildirirReportCouncilIndex = new DynamicSidebarMenuItem();
        eDurumBildirirReportCouncilIndex.key = 'eDurumBildirirReportCouncilIndex';
        eDurumBildirirReportCouncilIndex.icon = 'ai ai-tibbi-uygulama-istek';
        eDurumBildirirReportCouncilIndex.label = 'e-Durum Bildirir Kurul Ekranı';
        eDurumBildirirReportCouncilIndex.componentInstance = this;
        eDurumBildirirReportCouncilIndex.clickFunction = this.openDurumBildirirCouncilIndex;
        eDurumBildirirReportCouncilIndex.parameterFunctionInstance = this;
        eDurumBildirirReportCouncilIndex.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', eDurumBildirirReportCouncilIndex);

        let eDurumBildirirCreateApplication = new DynamicSidebarMenuItem();
        eDurumBildirirCreateApplication.key = 'eDurumBildirirCreateApplication';
        eDurumBildirirCreateApplication.componentInstance = this;
        eDurumBildirirCreateApplication.label = 'e-Durum Bildirir Hasta Kayıt';
        eDurumBildirirCreateApplication.icon = 'ai ai-recete';
        eDurumBildirirCreateApplication.clickFunction = this.openEDurumBildirirCreateApplication;
        this.sideBarMenuService.addMenu('YardimciMenu', eDurumBildirirCreateApplication);

        let eDurumBildirirReportCreateCouncil = new DynamicSidebarMenuItem();
        eDurumBildirirReportCreateCouncil.key = 'eDurumBildirirReportCreateCouncil';
        eDurumBildirirReportCreateCouncil.componentInstance = this;
        eDurumBildirirReportCreateCouncil.label = 'e-Durum Bildirir Kurul İşlemleri';
        eDurumBildirirReportCreateCouncil.icon = 'ai ai-recete';
        eDurumBildirirReportCreateCouncil.clickFunction = this.openEDurumBildirirCouncilDescription;
        this.sideBarMenuService.addMenu('YardimciMenu', eDurumBildirirReportCreateCouncil);


    }

    private RemoveMenuFromHelpMenu() {

        this.sideBarMenuService.removeMenu('disabledReportCouncilIndex');
        this.sideBarMenuService.removeMenu('disabledReportSecretaryIndex');
        this.sideBarMenuService.removeMenu('disabledReportCreateApplication');
        this.sideBarMenuService.removeMenu('disabledReportCreateCouncil');
        this.sideBarMenuService.removeMenu('cozgerReportSecretaryIndex');
        this.sideBarMenuService.removeMenu('cozgerReportCreateApplication');

        this.sideBarMenuService.removeMenu('eDurumBildirirReportSecretaryIndex');
        this.sideBarMenuService.removeMenu('eDurumBildirirReportCouncilIndex');
        this.sideBarMenuService.removeMenu('eDurumBildirirCreateApplication');
        this.sideBarMenuService.removeMenu('eDurumBildirirReportCreateCouncil');

    }
    
    public openEDisabledSecretaryIndex() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenEDisabledReportIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openCozgerSecretaryIndex() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenCozgerReportIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openDurumBildirirSecretaryIndex() {
        let fullApiUrl: string = 'api/EDurumBildirirKurulService/OpenEDurumBildirirReportIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openCouncilDescription() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenEDisabledCouncilIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openEDurumBildirirCouncilDescription() {
        let fullApiUrl: string = 'api/EDurumBildirirKurulService/OpenEDurumBildirirReportCouncilIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openCreateApplication() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenEDisabledReportCreateApplication';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openCreateCozgerApplication() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenCozgerReportCreateApplication';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openEDurumBildirirCreateApplication() {
        let fullApiUrl: string = 'api/EDurumBildirirKurulService/OpenEDurumBildirirReportCreateApplication';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openCouncilIndex() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenEDisabledReportCouncil';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openDurumBildirirCouncilIndex() {
        let fullApiUrl: string = 'api/EDurumBildirirKurulService/OpenEDurumBildirirReportCouncil';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    //htmldeki  Listeleme İşlemi ismi hep btnSearchClicked olsun
    fillList() {

        super.fillList();
        let that = this;
        this.loadSearchingPanel();
        that.httpService.post<HealthCommitteeWorkListViewModel>("api/HealthCommitteeWorkListService/GetHealthCommitteeWorkList", that.healthCommitteeWorkListViewModel._SearchCriteria)
            .then(response => {

                let viewModel: HealthCommitteeWorkListViewModel = response as HealthCommitteeWorkListViewModel;

                that.healthCommitteeWorkListViewModel.WorkList = viewModel.WorkList;// Array < InPatientWorkListItem >
                that.healthCommitteeWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                that.unloadSearchingPanel();

            })
            .catch(error => {
                that.unloadSearchingPanel();
                that.messageService.showError(error);

            });

    }

    loadViewModel() {

        let that = this;
        let fullApiUrl: string = "/api/HealthCommitteeWorkListService/LoadHealthCommitteeWorkListViewModel";
        this.httpService.get<HealthCommitteeWorkListViewModel>(fullApiUrl)
            .then(response => {
                that.healthCommitteeWorkListViewModel = response as HealthCommitteeWorkListViewModel;
                that.ViewModel = response as BaseEpisodeActionWorkListFormViewModel;

                if (that.healthCommitteeWorkListViewModel._SearchCriteria.HCStateItems == null || that.healthCommitteeWorkListViewModel._SearchCriteria.HCStateItems.length == 0) {
                    that.healthCommitteeWorkListViewModel._SearchCriteria.HCStateItems = new Array<ListObject>();
                    that.healthCommitteeWorkListViewModel._SearchCriteria.HCStateItems.push(that.ReportStateList[0]);//Yeni
                }

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
            this.healthCommitteeWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
            this.btnSearchClicked();
        }
        else
            this.healthCommitteeWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    ngAfterViewInit(): void {
        let that = this;
        super.ngAfterViewInit();
        this.AddHelpMenu();
        //setTimeout(function () {
        //    that.WorkListGrid.instance.repaint();
        //}, 30);
    }

    // async select(value: any): Promise<void> {

    //     for (let i=0; i<10000;i++)
    //     {
    //         console.log("i");
    //     }
    //     super.select(value);
    // }

    clearGridItems() {
        this.healthCommitteeWorkListViewModel.WorkList = new Array<HealthCommitteeWorkListItem>();
        this.selectedRowKeysResultList = null;
    }

    onStartDateChanged(event: any) {
        this.healthCommitteeWorkListViewModel._SearchCriteria.WorkListStartDate = event.value;
    }

    onHCRequestReasonChanged(event: any) {
        this.healthCommitteeWorkListViewModel._SearchCriteria._HCRequestReason = event.value;
    }

    onEndDateChanged(event: any) {
        this.healthCommitteeWorkListViewModel._SearchCriteria.WorkListEndDate = event.value;
    }

    onVoteStatusChanged(event: any) {
        this.healthCommitteeWorkListViewModel._SearchCriteria.VoteStatus = event.value;
    }

    async controlofPharmcyOpenOrClose() {
        let that = this
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
            let that = this
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

