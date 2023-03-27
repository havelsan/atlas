
import { Component, Renderer2 } from '@angular/core';
import { InfectionCommitteeWorkListViewModel } from './InfectionCommitteeWorkListViewModel';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { BaseEpisodeActionWorkListForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListForm";
import { SimpleTimer } from 'ng2-simple-timer';
import { BaseEpisodeActionWorkListFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';
import { IModalService } from 'Fw/Services/IModalService';
import { ResSection, ResUser } from 'app/NebulaClient/Model/AtlasClientModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'InfectionCommitteeWorkListForm',
    templateUrl: './InfectionCommitteeWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class InfectionCommitteeWorkListForm extends BaseEpisodeActionWorkListForm {
    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer, protected modalService: IModalService, public renderer: Renderer2) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);
    }
    public infectionCommitteeWorkListViewModel: InfectionCommitteeWorkListViewModel = new InfectionCommitteeWorkListViewModel();

    public SelectedDoctor: Array<ResUser.DoctorListNQL_Class>;
    public PageName = "InfectionCommitteeWorkListForm"; // Kolonlar kullanıcılara göre kaydedilirken Kullanılır

    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        this.WorkListColumns = [
            {
                caption: "Tarih",
                dataField: "Date",
                dataType: 'date',
                format: 'dd.MM.yyyy',
                width: 100,
                allowSorting: true,
            },
            {
                caption: "Hasta Adı Soyadı",
                dataField: "PatientNameSurname",
                dataType: 'string',
                width: 220,
                allowSorting: true
            },
            {
                caption: "Kabul No",
                dataField: "KabulNo",
                dataType: 'string',
                width: 100,
                allowSorting: true
            },
            {
                caption: "T.C. Kimlik No",
                dataField: "UniqueRefno",
                dataType: 'string',
                width: 120,
                allowSorting: true
            },
            {
                caption: "Servisi",
                dataField: "MasterResource",
                dataType: 'string',
                width: 170,
                allowSorting: true,
            },
            {
                caption: "Yatak Servisi",
                dataField: "RoomResource",
                dataType: 'string',
                width: 170,
                allowSorting: true,
            },
            {
                caption: "Oda",
                dataField: "Room",
                dataType: 'string',
                width: 120,
                allowSorting: true,
            },
            {
                caption: "Yatak",
                dataField: "Bed",
                dataType: 'string',
                width: 120,
                allowSorting: true,
            },
            {
                caption: "Order Veren Doktor",
                dataField: "DoctorName",
                dataType: 'string',
                width: 130,
                allowSorting: true,
            },
            {
                caption: "Yatış Tarihi",
                dataField: "InpatientDate",
                dataType: 'date',
                format: 'dd.MM.yyyy',
                width: 100,
                allowSorting: true,
            },
        ];
        super.GenerateResultListColumns(columnNameAndOrder);
    }


    public preparePageProperties() {
        this.refreshWorkListAutomatically = false;
    }

    public fillList() {
        super.fillList();
        if (this.SelectedDoctor != null) {
            this.infectionCommitteeWorkListViewModel._SearchCriteria.SelectedDoctor = new Array<Guid>();
            for (let doctor of this.SelectedDoctor) {
                this.infectionCommitteeWorkListViewModel._SearchCriteria.SelectedDoctor.push(doctor.ObjectID);
            }
        } else
            this.infectionCommitteeWorkListViewModel._SearchCriteria.SelectedDoctor = new Array<Guid>();
        let that = this;
        this.loadSearchingPanel();
        that.httpService.post<InfectionCommitteeWorkListViewModel>("api/InfectionCommitteeWorkListService/GetInfectionCommitteeWorkList", that.infectionCommitteeWorkListViewModel._SearchCriteria)
            .then(response => {
                let viewModel: InfectionCommitteeWorkListViewModel = response as InfectionCommitteeWorkListViewModel;
                that.infectionCommitteeWorkListViewModel.WorkList = viewModel.WorkList;
                that.infectionCommitteeWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
                that.unloadSearchingPanel();
            })
            .catch(error => {
                that.unloadSearchingPanel();
                that.messageService.showError(error);
            });

    }

    public loadViewModel(): void {

        let that = this;
        let fullApiUrl: string = "/api/InfectionCommitteeWorkListService/LoadInfectionCommitteeWorkListViewModel";
        this.httpService.get<InfectionCommitteeWorkListViewModel>(fullApiUrl)
            .then(response => {
                that.infectionCommitteeWorkListViewModel = response as InfectionCommitteeWorkListViewModel;
                that.ViewModel = response as BaseEpisodeActionWorkListFormViewModel;

                // serverdan gelen listelerin referansı farklı olduğu için böyle bir yola gitmek gerekti
                let _tempSection = new Array<ResSection>();
                that.infectionCommitteeWorkListViewModel._SearchCriteria.Resources.forEach(element => {
                    let listItem = that.infectionCommitteeWorkListViewModel.ResourceList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                    if (listItem) {
                        _tempSection.push(listItem);
                    }
                });

                that.infectionCommitteeWorkListViewModel._SearchCriteria.Resources = new Array<ResSection>();
                that.infectionCommitteeWorkListViewModel._SearchCriteria.Resources = _tempSection;

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
            this.infectionCommitteeWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
            this.btnSearchClicked();
        }
        else
            this.infectionCommitteeWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    States = [
        { text: "Onaylanmayanlar", value: 0 },
        { text: "Onaylananlar", value: 1 },
        { text: "Tümü", value: 2 },
        { text: "Reddedilenler", value: 3 }

    ];

    onProtocolNoEnterKeyDown(e) {
        super.btnSearchClicked();
    }
}

