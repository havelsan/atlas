
import { Component, Renderer2 } from '@angular/core';
import { SurgeryWorkListViewModel, SurgeryWorkListItem, SelectedSurgeryStatusItem } from './SurgeryWorkListViewModel';
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

@Component({
    selector: 'SurgeryWorkListForm',
    templateUrl: './SurgeryWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class SurgeryWorkListForm extends BaseEpisodeActionWorkListForm {
    surgeryProceduresDataSource: any;
    detailAccordionSelectedItems: number = -1;
    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer, protected modalService: IModalService, public renderer: Renderer2) {
        super(container, httpService, messageService, systemApiService, activeUserService, st, modalService, renderer);

        this.surgeryProceduresDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",

                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SurgeryListForWL'
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }

                    return this.httpService.post<any>("api/SurgeryWorkListService/GetSurgeryProcedures", loadOptions);

                },
            }),
            paginate: true,
            pageSize: 10
        })

    }
    public surgeryWorkListViewModel: SurgeryWorkListViewModel = new SurgeryWorkListViewModel();

    //#region Ameliyat Durumu Düzenleme
    public async changeSurgeryStatus(value: any) {
        if (this.selectedRowKeysResultList.length == 0) {
            this.messageService.showReponseError("Lütfen Ameliyat Seçiniz!");
        } else {
            if (this.selectedRowKeysResultList.filter(x => x.ObjectDefName != "SURGERY").length == 0) {//Ameliyat işleminden farklı 'Ameliyat ek işlemi' gibi bir işlem seçilmişse hata verilecek
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Ameliyat Süreç Düzenleme", "Seçili İşlemler " + value.Name + " Durumuna Güncellenecektir! \r\n\r\n Devam etmek istiyor musunuz?");
                if (messageResult === "E") {
                    let objectIdList: Array<Guid> = [];
                    for (let item of this.selectedRowKeysResultList) {
                        objectIdList.push(item.ObjectID);
                    }
                    this.surgeryWorkListViewModel.SelectedSurgeryStatusItem.SurgeryObjectIdList = objectIdList;

                    this.surgeryWorkListViewModel.SelectedSurgeryStatusItem.SurgeryObjectDefName = this.selectedRowKeysResultList[0].ObjectDefName;
                    this.surgeryWorkListViewModel.SelectedSurgeryStatusItem.SelectedSurgeryStatusDefinition = value;

                    let that = this;
                    that.httpService.post<any>("api/SurgeryWorkListService/ChangeSurgeryStatusDefinition", this.surgeryWorkListViewModel.SelectedSurgeryStatusItem)
                        .then(response => {
                            this.btnSearchClicked();
                            this.messageService.showSuccess("Ameliyat Süreci Başarılı Bir Şekilde Düzenlendi");
                        })
                        .catch(error => {
                            this.messageService.showError(error);
                        });

                } else if (messageResult === "H") {
                    this.messageService.showInfo("Ameliyat Süreci Düzenlemesinden Vazgeçildi");
                }
            } else {//Ameliyat işleminden farklı 'Ameliyat ek işlemi' gibi bir işlem seçilmişse hata verilecek
                this.messageService.showReponseError("Seçili işlem sadece Ameliyat işlemleri üzerinden yapılabilir!");
            }
        }
    }
    //#endregion Ameliyat Durumu Düzenleme

    public PageName = "SurgeryWorkListForm"; // Kolonlar kullanıcılara göre kaydedilirken Kullanılır

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
                width: 100,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                "caption": i18n("M16838", "Ameliyat Durumu"),
                dataField: "StatusName",
                dataType: 'string',
                width: 100,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27304", "Ameliyathane"),
                dataField: "SurgeryDepartment",
                dataType: 'string',
                width: 170,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M30111", "Salon"),
                dataField: "SurgeryRoom",
                dataType: 'string',
                width: 120,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M30111", "Masa"),
                dataField: "SurgeryDesk",
                dataType: 'string',
                width: 120,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27304", "Servisi"),
                dataField: "InpatientClinic",
                dataType: 'string',
                width: 170,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27339", "Operatör Doktor"),
                dataField: "SurgeryDoctorName",
                dataType: 'string',
                width: 130,
                allowSorting: true,
                //cssClass: 'worklistGridCellFont',
            },
            {
                caption: i18n("M27339", "Anestezi Doktoru"),
                dataField: "AnesthesiaDoctorName",
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
                caption: i18n("M22514", "T.C. Kimlik No"),
                dataField: "UniqueRefno",
                dataType: 'string',
                width: 120,
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
        that.surgeryWorkListViewModel._SearchCriteria.selectedSurgeryProceduresStr = JSON.stringify(that.surgeryWorkListViewModel._SearchCriteria.selectedSurgeryProcedures);
        that.httpService.post<SurgeryWorkListViewModel>("api/SurgeryWorkListService/GetSurgeryWorkList", that.surgeryWorkListViewModel._SearchCriteria)
            .then(response => {

                let viewModel: SurgeryWorkListViewModel = response as SurgeryWorkListViewModel ;

                that.surgeryWorkListViewModel.WorkList = viewModel.WorkList; // Array < SurgeryWorkListItem >
                that.surgeryWorkListViewModel.maxWorklistItemCount = viewModel.maxWorklistItemCount;
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
        let fullApiUrl: string = "/api/SurgeryWorkListService/LoadSurgeryWorkListViewModel";
        this.httpService.get<SurgeryWorkListViewModel>(fullApiUrl)
            .then(response => {
                that.surgeryWorkListViewModel = response as SurgeryWorkListViewModel ;
                that.ViewModel = response as BaseEpisodeActionWorkListFormViewModel ;

                if (this.surgeryWorkListViewModel._SearchCriteria.AnesthesiaAndReanimation_EA == true)
                    that.radioGroupEAType_Value = 2;
                else if (this.surgeryWorkListViewModel._SearchCriteria.Surgery_EA == true)
                    that.radioGroupEAType_Value = 1;

                // serverdan gelen listelerin referansı farklı olduğu için böyle bir yola gitmek gerekti
                let _tempSection = new Array<ResSection>();
                that.surgeryWorkListViewModel._SearchCriteria.Resources.forEach(element => {
                    let listItem = that.surgeryWorkListViewModel.ResourceList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                    if (listItem) {
                        _tempSection.push(listItem);
                    }
                });

                that.surgeryWorkListViewModel._SearchCriteria.Resources = new Array<ResSection>();
                that.surgeryWorkListViewModel._SearchCriteria.Resources = _tempSection;

                let _tempSurgeryDept = new Array<ResSection>();
                that.surgeryWorkListViewModel._SearchCriteria.SurgeryDepartments.forEach(element => {
                    let listItem = that.surgeryWorkListViewModel.SurgeryDepartmentList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                    if (listItem) {
                        _tempSurgeryDept.push(listItem);
                    }
                });

                that.surgeryWorkListViewModel._SearchCriteria.SurgeryDepartments = new Array<ResSection>();
                that.surgeryWorkListViewModel._SearchCriteria.SurgeryDepartments = _tempSurgeryDept;

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

    //this.SurgeryPhysicianApplication_EA_options = "";
    //this.consultation_EA_options = "display: none";


    patientChanged(patient: any) {
        if (patient) {
            this.surgeryWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
            this.btnSearchClicked();
        }
        else
            this.surgeryWorkListViewModel._SearchCriteria.PatientObjectID  = "";
    }

    radioGroupOnlyOwnPatientItems = [
        { text: "Benim Hastalarım", value: true },
        { text: "Tüm Hastalar", value: false }

    ];

    public radioGroupEAType_Value = 1;
    radioGroupEATypeItems = [
        { text: "Ameliyat", value: 1 },
        { text: "Anestezi ve Reanimasyon", value: 2 },

    ];

    onradioGroupEAType_ValueChanged(e: any) {

        if (e.value == 2) {
            this.surgeryWorkListViewModel._SearchCriteria.Surgery_EA = false;
            this.surgeryWorkListViewModel._SearchCriteria.AnesthesiaAndReanimation_EA = true;
        }
        else {
            this.surgeryWorkListViewModel._SearchCriteria.Surgery_EA = true;
            this.surgeryWorkListViewModel._SearchCriteria.AnesthesiaAndReanimation_EA = false;
        }


    }

    private detailSearchIconClassCollapse = 0;
    private showPopupDetailsSearch: boolean = false;
    public detailSearchCollapse_Click(): void {
        this.showPopupDetailsSearch = (!this.showPopupDetailsSearch);
        if (this.detailSearchIconClassCollapse == 0)
            this.detailSearchIconClassCollapse = 1;
        else
            this.detailSearchIconClassCollapse = 0;
    }


}

