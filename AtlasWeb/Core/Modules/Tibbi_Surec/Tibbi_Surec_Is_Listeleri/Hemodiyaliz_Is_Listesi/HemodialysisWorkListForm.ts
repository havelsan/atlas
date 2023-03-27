
import { Component, Renderer2 } from '@angular/core';
import { HemodialysisWorkListViewModel, HemodialysisWorkListItem, SelectedHemodialysisStatusItem } from './HemodialysisWorkListViewModel';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { BaseEpisodeActionWorkListForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListForm";
import { SimpleTimer } from 'ng2-simple-timer';
import { BaseEpisodeActionWorkListFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';
import { IModalService } from 'Fw/Services/IModalService';
import { ResSection } from 'app/NebulaClient/Model/AtlasClientModel';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { EpisodeActionWorkListItem, EpisodeActionWorkListStateItem, StateOutputDVO } from '../../Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel';

import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';

@Component({
    selector: 'HemodialysisWorkListForm',
    templateUrl: './HemodialysisWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class HemodialysisWorkListForm extends BaseEpisodeActionWorkListForm {
    public PatientTypeList = [];
    public hemodialysisWorkListViewModel: HemodialysisWorkListViewModel = new HemodialysisWorkListViewModel();

    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer, protected modalService: IModalService, public renderer: Renderer2, 
        private sideBarMenuService: ISidebarMenuService) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);

        this.PatientTypeList = [
            {
                TypeName: 'Tümü',
                TypeID: -1
            }, {
                TypeName: 'Ayaktan',
                TypeID: 0
            }, {
                TypeName: 'Yatan',
                TypeID: 1
            }
        ];
    }

    public PageName = "HemodialysisWorkListForm"; // Kolonlar kullanıcılara göre kaydedilirken Kullanılır

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: i18n("M15133", "Hasta Adı Soyadı"),
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: 220,
                allowSorting: true
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: "AdmissionNumber",
                dataType: 'string',
                width: 100,
                visible: false,
                allowSorting: true
            },
            {
                caption: "Arşiv No",
                dataField: "ArchiveNumber",
                dataType: 'string',
                width: 100,
                visible: false,
                allowSorting: true
            },
            {
                caption: i18n("M22514", "T.C. Kimlik No"),
                dataField: "UniqueRefno",
                dataType: 'string',
                width: 120,
                visible: false,
                allowSorting: true
            }, {
                caption: "İstek Yapan Hekim",
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: 220,
                allowSorting: true
            },
            {
                caption: "Kabul Tarihi",
                dataField: "AdmissionDate",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 100,
                allowSorting: true,
            },
            {
                caption: "Başlangıç Tarihi",
                dataField: "StartDate",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 100,
                allowSorting: true,
            },
            {
                caption: "Bitiş Tarihi",
                dataField: "FinishDate",
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: 100,
                allowSorting: true,
            },
            {
                "caption": "Durumu",
                dataField: "HemodialysisState",
                dataType: 'string',
                width: 100,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            }
        ];
        super.GenerateResultListColumns(columnNameAndOrder);
    }

    //<override edilen methodlar
    // Listeleme İşlemi ismi hep btnSearchClicked olsun
    public fillList() {
        super.fillList();
        let that = this;
        this.loadSearchingPanel();
        that.httpService.post<HemodialysisWorkListViewModel>("api/HemodialysisWorkListService/GetHemodialysisWorkList", that.hemodialysisWorkListViewModel._SearchCriteria)
            .then(response => {

                let viewModel: HemodialysisWorkListViewModel = response as HemodialysisWorkListViewModel;

                that.hemodialysisWorkListViewModel.WorkList = viewModel.WorkList; // Array < HemodialysisWorkListItem >
                that.hemodialysisWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;

                that.unloadSearchingPanel();
            })
            .catch(error => {
                that.unloadSearchingPanel();
                that.messageService.showError(error);

            });

    }

    public loadViewModel(): void {

        let that = this;
        let fullApiUrl: string = "/api/HemodialysisWorkListService/LoadHemodialysisWorkListViewModel";
        this.httpService.get<HemodialysisWorkListViewModel>(fullApiUrl)
            .then(response => {
                that.hemodialysisWorkListViewModel = response as HemodialysisWorkListViewModel;
                that.ViewModel = response as BaseEpisodeActionWorkListFormViewModel;

                setTimeout(function () {
                    that.WorkListGrid.instance.repaint();
                }, 30);

            })
            .catch(error => {
                console.log(error);
            });

    }


    //override edilen methodlar>



    //_SearchCriteria için

    //this.HemodialysisPhysicianApplication_EA_options = "";
    //this.consultation_EA_options = "display: none";


    patientChanged(patient: any) {
        if (patient) {
            this.hemodialysisWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
            this.btnSearchClicked();
        }
        else
            this.hemodialysisWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    onPatientTypeChanged(e: any): void {
        this.hemodialysisWorkListViewModel._SearchCriteria.Patienttype = e.value;
    }
    onradioGroupEAType_ValueChanged(e: any) {

    }

    async ngOnInit() {

        this.AddHelpMenu();
    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let updateEquipment = new DynamicSidebarMenuItem();
        updateEquipment.key = 'updateEquipment';
        updateEquipment.icon = 'fas fa-sync-alt';
        updateEquipment.label = "Cihaz Durumu Güncelle";
        updateEquipment.componentInstance = this;
        updateEquipment.clickFunction = this.UpdateEquipment;
        updateEquipment.parameterFunctionInstance = this;
        updateEquipment.getParamsFunction = null;
        updateEquipment.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', updateEquipment);

    }
    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('updateEquipment');
    }

    public UpdateEquipment() {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'UpdateEquipmentForm';
            componentInfo.ModuleName = 'HemodialysisWorkListModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/Hemodiyaliz_Is_Listesi/HemodialysisWorkListModule';
            componentInfo.InputParam = null;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Cihaz Durumu Güncelle';
            modalInfo.Width = 500;
            modalInfo.Height = 530;


            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });

        });
    }

}

