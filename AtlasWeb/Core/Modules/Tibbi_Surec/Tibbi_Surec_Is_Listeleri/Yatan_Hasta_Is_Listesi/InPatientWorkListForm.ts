
import { Component, Renderer2 } from '@angular/core';
import { InPatientWorkListViewModel, InPatientWorkListItem } from './InPatientWorkListViewModel';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { BaseEpisodeActionWorkListForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListForm";
import { SimpleTimer } from 'ng2-simple-timer';
import { BaseEpisodeActionWorkListFormViewModel, BaseEpisodeActionWorkListItem, FollowingPatientList } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';
import { IModalService } from 'Fw/Services/IModalService';
import { ResSection } from 'app/NebulaClient/Model/AtlasClientModel';
import { DynamicSidebarMenuItem } from '../../../../wwwroot/app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from '../../../../wwwroot/app/Fw/Services/ISidebarMenuService';
import { DynamicComponentInfo } from '../../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from '../../../../wwwroot/app/Fw/Models/ModalInfo';

@Component({
    selector: 'InPatientWorkListForm',
    templateUrl: './InPatientWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class InPatientWorkListForm extends BaseEpisodeActionWorkListForm {
    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer, protected modalService: IModalService, public renderer: Renderer2, private sideBarMenuService: ISidebarMenuService) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);
    }
    public inPatientWorkListViewModel: InPatientWorkListViewModel = new InPatientWorkListViewModel();


    public PageName = "InPatientWorkListForm"; // Kolonlar kullanıcılara göre kaydedilirken Kullanılır

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: i18n("M27302", "Tarih"),
                dataField: "Date",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 100,
                allowSorting: true,
                // cssClass: 'worklistGridCellFont'
            },
            {
                caption: i18n("M15133", "Hasta Adı Soyadı"),
                dataField: "PatientNameSurname",
                dataType: 'string',
                cellTemplate: "PriorityCellTemplate", // Yaşlı Genç için html tarafına referans
                width: 220,
                allowSorting: true
            },

            {
                "caption": i18n("M30303", "İşlem"),
                dataField: "EpisodeActionName",
                dataType: 'string',
                width: 130,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                "caption": i18n("M16838", "İşlem Durumu"),
                dataField: "StateName",
                dataType: 'string',
                width: 130,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },

            {
                caption: i18n("M27304", "Birim"),
                dataField: "MasterResource",
                dataType: 'string',
                width: 170,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                "caption": i18n("M07217", "Alerji Durumu"),
                dataField: "MedicalInformation",
                dataType: 'string',
                width: 120,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M30111", "Oda/Yatak "),
                dataField: "RoomBed",
                dataType: 'string',
                width: 120,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27339", "Doktoru"),
                dataField: "DoctorName",
                dataType: 'string',
                width: 130,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            // Gizli Kolonları için
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: "KabulNo",
                dataType: 'string',
                width: 100,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M17021", "Yatış Gün Sayısı"),
                dataField: "InpatientDay",
                dataType: 'string',
                width: 100,
                allowSorting: true
            },
            {
                caption: i18n("M22514", "T.C. Kimlik No"),
                dataField: "UniqueRefno",
                dataType: 'string',
                width: 120,
                visible: false,
                allowSorting: true
            },

            {
                caption: i18n("M27384", "Hemşire Adı"),
                dataField: "NurseName",
                dataType: 'string',
                width: 130,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M14664", "Geliş Sebebi"),
                dataField: "AdmissionType",
                dataType: 'string',
                width: 110,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M18009", "Kurumu"),
                dataField: "PayerName",
                dataType: 'string',
                width: 170,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M13132", "Doğum Tarihi"),
                dataField: "BirthDate",
                dataType: 'date',
                format: 'dd.MM.yyyy',
                width: 100,
                allowSorting: true,
                visible: false,
                // cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M11390", "Baba Adı"),
                dataField: "FatherName",
                dataType: 'string',
                width: 130,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M23138", "Telefon Numarası"),
                dataField: "TelNo",
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
            }, {
                caption: i18n("M20014", "Öncelik Durumu"),
                dataField: "OncelikDurumu",
                dataType: 'string',
                width: 120,
                visible: false,
                allowSorting: true
            }, {
                caption: i18n("M22736", "Tanı"),
                dataField: "Diagnosis",
                dataType: 'string',
                width: 120,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M22736", "Yatış Tarihi"),
                dataField: "InpatientDate",
                dataType: 'date',
                format: 'dd.MM.yyyy',
                width: 100,
                allowSorting: true,
                visible: false
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


    public preparePageProperties() {
        this.refreshWorkListAutomatically = true;
    }

    //<override edilen methodlar
    public fillList() {
        super.fillList();
        let that = this;
        this.loadSearchingPanel();
        that.httpService.post<InPatientWorkListViewModel>("api/InPatientWorkListService/GetInPatientWorkList", that.inPatientWorkListViewModel._SearchCriteria)
            .then(response => {

                let viewModel: InPatientWorkListViewModel = response as InPatientWorkListViewModel;

                that.inPatientWorkListViewModel.WorkList = viewModel.WorkList; // Array < InPatientWorkListItem >
                that.inPatientWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                //that.saveOrtezWorklistFilterUserOption();
                //that.systemApiService.componentInfo = null;
                that.unloadSearchingPanel();
            })
            .catch(error => {
                that.unloadSearchingPanel();
                that.messageService.showError(error);

            });

    }

    public loadViewModel(): void {

        let that = this;
        let fullApiUrl: string = "/api/InPatientWorkListService/LoadInPatientWorkListViewModel";
        this.httpService.get<InPatientWorkListViewModel>(fullApiUrl)
            .then(response => {
                that.inPatientWorkListViewModel = response as InPatientWorkListViewModel;
                that.ViewModel = response as BaseEpisodeActionWorkListFormViewModel;

                if (this.inPatientWorkListViewModel._SearchCriteria.consultation_EA == true)
                    that.radioGroupEAType_Value = 2;
                else if (this.inPatientWorkListViewModel._SearchCriteria.inPatientPhysicianApplication_EA == true)
                    that.radioGroupEAType_Value = 1;
                else if (this.inPatientWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA == true)
                    that.radioGroupEAType_Value = 3;

                // serverdan gelen listelerin referansı farklı olduğu için böyle bir yola gitmek gerekti
                let _tempSection = new Array<ResSection>();
                that.inPatientWorkListViewModel._SearchCriteria.Resources.forEach(element => {
                    let listItem = that.inPatientWorkListViewModel.ResourceList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                    if (listItem) {
                        _tempSection.push(listItem);
                    }
                });

                that.inPatientWorkListViewModel._SearchCriteria.Resources = new Array<ResSection>();
                that.inPatientWorkListViewModel._SearchCriteria.Resources = _tempSection;

                setTimeout(function () {
                    that.WorkListGrid.instance.repaint();
                }, 30);

            })
            .catch(error => {
                console.log(error);
            });

    }
    public onRowPrepared(value: any) {

        let _data: InPatientWorkListItem = value.data as InPatientWorkListItem;
        if (_data != null && _data.OrderNumber < 40) {
            let visibleIndex = value.columns.find(x => x.dataField == "StateName").visibleIndex;
            value.cells[visibleIndex].cellElement[0].style.backgroundColor = '#FFA5A5';
        }
    }

    //override edilen methodlar>



    //_SearchCriteria için

    //this.inPatientPhysicianApplication_EA_options = "";
    //this.consultation_EA_options = "display: none";


    patientChanged(patient: any) {
        if (patient) {
            this.inPatientWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
            this.btnSearchClicked();
        }
        else
            this.inPatientWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    radioGroupOnlyOwnPatientItems = [
        { text: "Benim Hastalarım", value: true },
        { text: "Tüm Hastalar", value: false }

    ];

    public radioGroupEAType_Value = 1;
    radioGroupEATypeItems = [
        { text: "Yatan Hasta", value: 1 },
        { text: "Konsültasyon", value: 2 },
        { text: "Rapor Onayı", value: 3 },
    ];

    onradioGroupEAType_ValueChanged(e: any) {

        if (e.value == 2) {
            this.inPatientWorkListViewModel._SearchCriteria.inPatientPhysicianApplication_EA = false;
            this.inPatientWorkListViewModel._SearchCriteria.consultation_EA = true;
            this.inPatientWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA = false;
        }
        else if (e.value == 1) {
            this.inPatientWorkListViewModel._SearchCriteria.inPatientPhysicianApplication_EA = true;
            this.inPatientWorkListViewModel._SearchCriteria.consultation_EA = false;
            this.inPatientWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA = false;
        }
        else if (e.value == 3) {
            this.inPatientWorkListViewModel._SearchCriteria.participatnFreeDrugReport_EA = true;
            this.inPatientWorkListViewModel._SearchCriteria.inPatientPhysicianApplication_EA = false;
            this.inPatientWorkListViewModel._SearchCriteria.consultation_EA = false;
        }


    }


    onProtocolNoEnterKeyDown(e) {
        super.btnSearchClicked();
    }

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
                    this.inPatientWorkListViewModel._SearchCriteria.ProtocolNo = _data.ProtocolNO;                    
                    this.showTrackingPatients = false;
                    super.btnSearchClicked();
                }
                else if (_data.Type == "Arşiv Bazlı")
                {                                 
                    this.showTrackingPatients = false;
                    this.inPatientWorkListViewModel._SearchCriteria.PatientObjectID = _data.PatientID.toString();
                    this.btnSearchClicked();
                }
            }
            catch (error) {
                that.messageService.showError(error);
            }
        }
    }

    async ngOnInit() {

        this.AddHelpMenu();
    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let inpatientStatisticReport = new DynamicSidebarMenuItem();
        inpatientStatisticReport.key = 'inpatientStatisticReport';
        inpatientStatisticReport.icon = 'far fa-file-alt';
        inpatientStatisticReport.label = "Yatan Hasta İstatistik Raporu";
        inpatientStatisticReport.componentInstance = this;
        inpatientStatisticReport.clickFunction = this.OpenInpatientStatisticReport;
        inpatientStatisticReport.parameterFunctionInstance = this;
        inpatientStatisticReport.getParamsFunction = null;
        inpatientStatisticReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', inpatientStatisticReport);

    }
    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('inpatientStatisticReport');
    }

    public OpenInpatientStatisticReport()
    {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'InpatientStatisticReport';
            componentInfo.ModuleName = 'InPatientWorkListModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Yatan_Hasta_Is_Listesi/InPatientWorkListModule';
            componentInfo.InputParam = null;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Yatan Hasta İstatistik';
            modalInfo.Width = 1000;
            modalInfo.Height = 800;


            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });

        });
    }

}

