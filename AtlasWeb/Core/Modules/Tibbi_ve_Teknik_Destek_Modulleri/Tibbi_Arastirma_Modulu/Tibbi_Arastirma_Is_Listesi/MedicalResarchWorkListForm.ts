
import { Component, Renderer2, ViewChild, ComponentRef } from '@angular/core';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { SimpleTimer } from 'ng2-simple-timer';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DxAccordionComponent, DxDataGridComponent } from 'devextreme-angular';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { MedicalResarchWorkListViewModel, ResarchWorkList_Input, MedicalResarchActionListDTO, DynamicComponentInfoDVO, ResarchPatientWorkList_Input, MedicalResarchActionPatientWorkListDTO } from './MedicalResarchWorkListViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Patient } from 'app/NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'MedicalResarchWorkListForm',
    templateUrl: './MedicalResarchWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class MedicalResarchWorkListForm {
    public componentInfo: DynamicComponentInfo;
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "";
    public selectedMedicalResarchCode: string;
    public medicalResarchActionList: Array<MedicalResarchActionListDTO> = new Array<MedicalResarchActionListDTO>();
    public medicalResarchWorkListViewModel: MedicalResarchWorkListViewModel = new MedicalResarchWorkListViewModel();
    public medicalResarchPatientWorkList:Array<MedicalResarchActionPatientWorkListDTO> = new Array<MedicalResarchActionPatientWorkListDTO>();
    public priorities: string[];
    public priority: string;
    public MedicalResarchOnlyWork: boolean = false;
    public medicalResarchTermStatus: boolean = true;
    public medicalResarchPatientWork: boolean = false;
    constructor(protected container: ServiceContainer, protected httpService: NeHttpService,
        protected messageService: MessageService, public systemApiService: SystemApiService,
        protected activeUserService: IActiveUserService, protected st: SimpleTimer, protected modalService: IModalService, public renderer: Renderer2) {

        this.priorities = [
            "Araştırmalar",
            "İşlemler"
        ];
    }

    @ViewChild('searchAccordion') searchAccordion: DxAccordionComponent;

    async onValueChanged($event) {
        if ('Araştırmalar' === $event.value) {
            this.MedicalResarchOnlyWork = false;
            this.medicalResarchPatientWork = false;

        }
        else if ('İşlemler' === $event.value) {
            this.MedicalResarchOnlyWork = true;
            this.medicalResarchPatientWork = true;
        }
    }


    public WorkListColumns = [
        {
            caption: 'Dönem Adı',
            dataField: 'TermName',
        },
        {
            caption: 'Araştırma Kodu',
            dataField: 'Code',
        },
        {
            caption: 'Araştırma Adı',
            dataField: 'Name',
        },
        {
            caption: 'Araştırma Bütçesi',
            dataField: 'BudgetTotalPrice',
        },
        {
            caption: 'Hasta Sayısı',
            dataField: 'PatientCount',
        },
        {
            caption: 'Durumu',
            dataField: 'Status',
        },
    ];

    public PatinetWorkListColumns = [
        {
            caption: 'Dönem Adı',
            dataField: 'TermName',
        },
        {
            caption: 'Araştırma Kodu',
            dataField: 'MedicalResarchCode',
        },
        {
            caption: 'Araştırma Adı',
            dataField: 'MedicalResarchName',
        },
        {
            caption: 'Hasta Adı Soyadı',
            dataField: 'PatientNameSurname',
        },
        {
            caption: 'Hasta Kabul No',
            dataField: 'PatientProtocolNo',
        },
        {
            caption: 'Kabul Tutarı',
            dataField: 'PatientBudgetPrice',
        },
        {
            caption: 'Durumu',
            dataField: 'PatientStatus',
        },
    ];

    openMedicalResarchDefDropDown() {
        this.getMedicalResarchDefDataSource();
    }

    selectedMedicalResarchTermDefItem: any = {};
    selectMedicalResarchTermDef(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMedicalResarchTermDefItem = e.data;
    }



    medicalResarchDefDataSource: DataSource;
    getMedicalResarchDefDataSource() {
        this.medicalResarchDefDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'MedicalResarchTermDefList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/MedicalResarchWorkListService/GetMedicalResarchDefList?medicalResarchTermStatus=' + this.medicalResarchTermStatus, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }




    medicalResarchTermDef() {
        new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'MedicalResarchTermDefComponent';
            componentInfo.ModuleName = 'MedicalResarchWorkListModule';
            componentInfo.ModulePath = 'Modules/Tibbi_ve_Teknik_Destek_Modulleri/Tibbi_Arastirma_Modulu/Tibbi_Arastirma_Is_Listesi/MedicalResarchWorkListModule';
            componentInfo.ParentInstance = this;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Tıbbi Araştıma Dönem Tanım Ekranı"
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    medicalResarchDef() {
        new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'MedicalResarchComponent';
            componentInfo.ModuleName = 'MedicalResarchWorkListModule';
            componentInfo.ModulePath = 'Modules/Tibbi_ve_Teknik_Destek_Modulleri/Tibbi_Arastirma_Modulu/Tibbi_Arastirma_Is_Listesi/MedicalResarchWorkListModule';
            componentInfo.ParentInstance = this;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Tıbbi Araştıma Tanım Ekranı"
            modalInfo.Width = 1200;
            modalInfo.Height = 600;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public selectedPatient:Patient;
    patientChanged(patient: any) {
        if (patient) {
            this.medicalResarchWorkListViewModel.PatientObjectID = patient.ObjectID;
            this.selectedPatient = patient;
        }
        else
            this.medicalResarchWorkListViewModel.PatientObjectID = "";
    }


    async getMedicalResarchClicked() {
        if (this.medicalResarchPatientWork != true) {
            if (this.selectedMedicalResarchTermDefItem.ObjectID != null) {
                this.loadingVisible = true;
                this.LoadPanelMessage = "İşlemler Listeleniyor..";
                let inputDTO: ResarchWorkList_Input = new ResarchWorkList_Input();
                inputDTO.MedicalResarchCode = this.selectedMedicalResarchCode;
                inputDTO.MedicalResarchTermDef = this.selectedMedicalResarchTermDefItem;
                let fullApiUrl: string = 'api/MedicalResarchWorkListService/getMedicalResarch';
                await this.httpService.post(fullApiUrl, inputDTO)
                    .then((res) => {
                        this.medicalResarchActionList = res as Array<MedicalResarchActionListDTO>;
                        this.loadingVisible = false;
                    })
                    .catch(error => {
                        ServiceLocator.MessageService.showError(error);
                        this.loadingVisible = false;
                    });
            }
            else {
                ServiceLocator.MessageService.showError("Dönem Seçimi Zorunludur. Önce Dönem Seçmeniz Gerekir.");
            }
        }
        else{
            if (this.selectedMedicalResarchTermDefItem.ObjectID != null) {
                this.loadingVisible = true;
                this.LoadPanelMessage = "İşlemler Listeleniyor..";
                let inputDTO: ResarchPatientWorkList_Input = new ResarchPatientWorkList_Input();
                inputDTO.MedicalResarchCode = this.selectedMedicalResarchCode;
                inputDTO.MedicalResarchTermDef = this.selectedMedicalResarchTermDefItem;
                inputDTO.SelectedPatient = this.selectedPatient;
                let fullApiUrl: string = 'api/MedicalResarchWorkListService/getMedicalResarchForPatientWorkList';
                await this.httpService.post(fullApiUrl, inputDTO)
                    .then((res) => {
                        this.medicalResarchPatientWorkList = res as Array<MedicalResarchActionPatientWorkListDTO>;
                        this.loadingVisible = false;
                    })
                    .catch(error => {
                        ServiceLocator.MessageService.showError(error);
                        this.loadingVisible = false;
                    });
            }
            else {
                ServiceLocator.MessageService.showError("Dönem Seçimi Zorunludur. Önce Dönem Seçmeniz Gerekir.");
            }
        }
    }




    public selectedMedicalResarchObjectID: any;
    public selectedMedicalResarchPatientObjectID: any;
    @ViewChild(DxDataGridComponent, {}) medicalResarchWorkListGrid: DxDataGridComponent;

    public onComponentCreated(compRef: ComponentRef<any>) {
    }

    public dynamicComponentActionExecuted(eventParam: any): void {
        if (eventParam.hasOwnProperty('IsSave') == false)
            return;

        let dynamicComponentSaved = eventParam['IsSave'] as boolean;
        if (dynamicComponentSaved === true) {
            this.searchAccordion.instance.expandItem(0);
        }
    }

    public componentIsActive = false;
    async openacomponent() {
        if (this.componentIsActive == false) {

            this.httpService.get<DynamicComponentInfoDVO>('api/MedicalResarchWorkListService/GetDynamicComponentInfo?ObjectId=' + this.selectedMedicalResarchObjectID).then((result: DynamicComponentInfoDVO) => {
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                compInfo.ComponentName = result.ComponentName;
                compInfo.ModuleName ='MedicalResarchWorkListModule';
                compInfo.ModulePath = 'Modules/Tibbi_ve_Teknik_Destek_Modulleri/Tibbi_Arastirma_Modulu/Tibbi_Arastirma_Is_Listesi/MedicalResarchWorkListModule';
                compInfo.objectID = result.objectID;
                compInfo.InputParam = this.selectedMedicalResarchObjectID;
                this.componentInfo = compInfo;

                this.searchAccordion.instance.collapseItem(0);
                /*this.patientInfoCollapseAttr = 0;
                this.btnCollapse();*/
            }).then(() => {

            });
        }
    }

    async select(value: any) {

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.selectedMedicalResarchObjectID = value.data.ObjectID;
            await this.openacomponent();
        }
    }

    async selectPatient(value: any) {

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.selectedMedicalResarchPatientObjectID = value.data.ObjectID;
            await this.openacomponentPatient();
        }
    }
    public componentIsActivePatient = false;
    async openacomponentPatient() {
        if (this.componentIsActivePatient == false) {
            this.httpService.get<DynamicComponentInfoDVO>('api/MedicalResarchWorkListService/GetDynamicComponentPatientInfo?ObjectId=' + this.selectedMedicalResarchPatientObjectID).then((result: DynamicComponentInfoDVO) => {
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                compInfo.ComponentName = result.ComponentName;
                compInfo.ModuleName ='MedicalResarchWorkListModule';
                compInfo.ModulePath = 'Modules/Tibbi_ve_Teknik_Destek_Modulleri/Tibbi_Arastirma_Modulu/Tibbi_Arastirma_Is_Listesi/MedicalResarchWorkListModule';
                compInfo.objectID = result.objectID;
                compInfo.InputParam = this.selectedMedicalResarchPatientObjectID;
                this.componentInfo = compInfo;
                this.searchAccordion.instance.collapseItem(0);
            }).then(() => {

            });
        }
    }
}

