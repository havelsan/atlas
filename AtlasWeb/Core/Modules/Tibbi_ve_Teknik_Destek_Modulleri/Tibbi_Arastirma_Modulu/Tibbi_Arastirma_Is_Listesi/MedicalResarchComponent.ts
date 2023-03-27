import { Component, ViewChild, Output, EventEmitter } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { MessageService } from 'Fw/Services/MessageService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { MedicalResarchDTO, MedicalResarchViewModel, InputDTO } from './MedicalResarchViewModel';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { MedicalResarchProcedur, MedicalResarchDoctor } from 'app/NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: 'MedicalResarchComponent',
    templateUrl: './MedicalResarchComponent.html',
    providers: [MessageService, SystemApiService]
})
export class MedicalResarchComponent implements IModal {
    public model: MedicalResarchDTO = new MedicalResarchDTO();
    public _viewModel: MedicalResarchViewModel = new MedicalResarchViewModel();
    public openTermDef: boolean = false;
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "";

    medicalResarchDefDataSource: DataSource;
    selectedMedicalResarchProcedurs: Array<MedicalResarchProcedur> = new Array<MedicalResarchProcedur>();
    selectedMedicalResarchDoctors: Array<MedicalResarchDoctor> = new Array<MedicalResarchDoctor>();

    public btnsaveResarch: boolean = true;
    public btncomplatedResarch: boolean = false;
    public btncancelResarch: boolean = false;
    public btnupdateResarch: boolean = false;
    public formIsReadOnly: boolean = false;
    public termReadOnly: boolean = false;
    public PatientAdIsReadOnly: boolean = true;
    public formName: string;
    medicalResarchDoctorDataSource: DataSource;

    constructor(private modalStateService: ModalStateService, private http: NeHttpService, protected modalService: IModalService, protected systemApiService: SystemApiService) {
        this.newResarchClick();
    }

    public ProcedureColumns = [
        {
            caption: 'Hizmet Kodu',
            dataField: 'Code',
        },
        {
            caption: 'Hizmet Adı',
            dataField: 'Name',
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        },
    ];
    public DoctorColumns = [
        {
            caption: 'Doktor Adı',
            dataField: 'Name',
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        },
    ];


    public MedicalResarchObjectID: string;
    public async setInputParam(value: any) {
        this.MedicalResarchObjectID = value;
        if (this.MedicalResarchObjectID != null) {
            this.createDynemicDataSource();
        }
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    @Output() public ActionExecuted: EventEmitter<any> = new EventEmitter<any>();
    public cancelClick(): void {
        if (this._modalInfo != null) {
            this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
        } else {
            this.ActionExecuted.emit({ Cancelled: true });
        }
    }

    public okClick(): void {
    }


    newResarchClick() {
        this.openTermDef = true;
        this.model = new MedicalResarchDTO();
    }
    async saveResarchClick() {
        this.loadingVisible = true;
        this.LoadPanelMessage = "Araştırma Kaydı Yapılıyor Lütfen Bekleyiniz.";
        let fullApiUrl: string = 'api/MedicalResarchService/saveMedicalResarch';
        let inputDTO: MedicalResarchViewModel = new MedicalResarchViewModel();
        inputDTO.MedicalResarchDTO = this.model;
        inputDTO.MedicalResarchTermDef = this.selectedMedicalResarchTermDefItem;
        inputDTO.MedicalResarchDoctorList = this.medicalResarchDoktorDataSourceList;
        inputDTO.MedicalResarchProcedurList = this.medicalResarchProcedureDataSourceList;
        await this.http.post(fullApiUrl, inputDTO)
            .then((res) => {
                let resulst: string = res as string;
                ServiceLocator.MessageService.showInfo(resulst);
                this.loadingVisible = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadingVisible = false;
            });
    }

    async complatedResarchClick() {
        this.loadingVisible = true;
        this.LoadPanelMessage = "Araştırma Kaydı Tamamlanıyor Lütfen Bekleyiniz.";
        let fullApiUrl: string = 'api/MedicalResarchService/complatedMedicalResarch';
        let inputDTO: MedicalResarchViewModel = new MedicalResarchViewModel();
        inputDTO.MedicalResarchDTO = this.model;
        inputDTO.MedicalResarchTermDef = this.selectedMedicalResarchTermDefItem;
        inputDTO.MedicalResarchDoctorList = this.medicalResarchDoktorDataSourceList;
        inputDTO.MedicalResarchProcedurList = this.medicalResarchProcedureDataSourceList;
        await this.http.post(fullApiUrl, inputDTO)
            .then((res) => {
                let resulst: string = res as string;
                ServiceLocator.MessageService.showInfo(resulst);
                this.loadingVisible = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadingVisible = false;
            });
    }

    async updateResarchClick() {
        this.loadingVisible = true;
        this.LoadPanelMessage = "Araştırma Kaydı Güncelleniyor Lütfen Bekleyiniz.";
        let fullApiUrl: string = 'api/MedicalResarchService/updateMedicalResarch';
        let inputDTO: MedicalResarchViewModel = new MedicalResarchViewModel();
        inputDTO.MedicalResarchDTO = this.model;
        inputDTO.MedicalResarchTermDef = this.selectedMedicalResarchTermDefItem;
       // inputDTO.MedicalResarchDoctorList = this.medicalResarchDoktorDataSourceList;
        inputDTO.MedicalResarchProcedurList = new  Array<MedicalResarchProcedur>();
        for (let pro of this.medicalResarchProcedureDataSourceList) {
            if (pro.ObjectDefName != null)
                inputDTO.MedicalResarchProcedurList.push(pro);
        }

        await this.http.post(fullApiUrl, inputDTO)
            .then((res) => {
                let resulst: string = res as string;
                ServiceLocator.MessageService.showInfo(resulst);
                this.loadingVisible = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadingVisible = false;
            });
    }
    async cancelResarchClick() {
        this.loadingVisible = true;
        this.LoadPanelMessage = "Araştırma Kaydı İptal Ediliyor Lütfen Bekleyiniz.";
        let fullApiUrl: string = 'api/MedicalResarchService/cancelMedicalResarch';
        let inputDTO: MedicalResarchViewModel = new MedicalResarchViewModel();
        inputDTO.MedicalResarchDTO = this.model;
        await this.http.post(fullApiUrl, inputDTO)
            .then((res) => {
                let resulst: string = res as string;
                ServiceLocator.MessageService.showInfo(resulst);
                this.loadingVisible = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadingVisible = false;
            });
    }


    async createDynemicDataSource() {
        let that = this;
        that.loadingVisible = true;
        that.PatientAdIsReadOnly = false;
        this.btnsaveResarch = false;
        this.btncomplatedResarch = true;
        this.btncancelResarch = true;
        this.btnupdateResarch = true;

        that.LoadPanelMessage = "Lütfen Bekleyiniz.";
        let inputDTO: InputDTO = new InputDTO();
        inputDTO.MedicalResarchObjectID = this.MedicalResarchObjectID;
        let fullApiUrl: string = 'api/MedicalResarchService/createDynemicDataSource';
        await that.http.post<MedicalResarchViewModel>(fullApiUrl, inputDTO)
            .then((res) => {
                that._viewModel = res as MedicalResarchViewModel;
                that.model = that._viewModel.MedicalResarchDTO;
                that.medicalResarchDoktorDataSourceList = that._viewModel.DoctorResUserList;
                that.medicalResarchProcedureDataSourceList = that._viewModel.ProcedureDefList;
                that.selectedMedicalResarchTermDefItem = that._viewModel.MedicalResarchTermDef;
                that.formIsReadOnly = that._viewModel.formIsReadOnly;
                that.termReadOnly = true;
                that.formName = that._viewModel.formName;
                if (that.formIsReadOnly === true) {
                    that.btnsaveResarch = false;
                    that.btncomplatedResarch = false;
                    that.btncancelResarch = false;
                    that.btnupdateResarch = false;
                    that.PatientAdIsReadOnly = true;
                }
                that.loadingVisible = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                that.loadingVisible = false;
            });
    }

    openMedicalResarchDefDropDown() {
        this.getMedicalResarchDefDataSource();
    }
    openMedicalResarchDoctorDropDown() {
        this.getMedicalResarchDoctorDataSource();
    }

    openMedicalResarchProcedureDropDown() {
        this.getMedicalResarchProcedureDataSource();
    }

    getMedicalResarchDoctorDataSource() {
        this.medicalResarchDoctorDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'DoctorListDefinition'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.http.post<any>('/api/MedicalResarchService/GetMedicalResarchDoctorList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

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
                    return this.http.post<any>('/api/MedicalResarchService/GetMedicalResarchDefList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    getMedicalResarchProcedureDataSource() {
        this.medicalResarchProcedureDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'ProcedureListDefinition'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.http.post<any>('/api/MedicalResarchService/GetMedicalResarchProcedureList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }


    selectedMedicalResarchTermDefItem: any = {};
    selectMedicalResarchTermDef(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMedicalResarchTermDefItem = e.data;
        this.model.StartDate = e.data.StartDate;
        this.model.EndDate = e.data.EndDate;
    }

    selectedMedicalResarchDoktorItem: any = {};
    medicalResarchDoktorDataSourceList: any[] = [];
    selectMedicalResarchDoctor(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedMedicalResarchDoktorItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.controlOfAddDoctor();
        }
    }

    selectedMedicalResarchProcedureItem: any = {};
    medicalResarchProcedureDataSource: any = {};
    medicalResarchProcedureDataSourceList: any[] = [];

    selectMedicalResarchProcedure(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedMedicalResarchProcedureItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.controlOfAddProcedure();
        }
    }


    controlOfAddDoctor() {
        if (this.selectedMedicalResarchDoktorItem != null) {
            if (this.medicalResarchDoktorDataSourceList.filter(x => x.ObjectID == this.selectedMedicalResarchDoktorItem.ObjectID).length == 0) {
                this.medicalResarchDoktorDataSourceList.push(this.selectedMedicalResarchDoktorItem);
            }
            else {
                ServiceLocator.MessageService.showError("Aynı Doktoru Birden Fazla Giremezsiniz !");
            }
        }
        else {
            this.medicalResarchDoktorDataSourceList.push(this.selectedMedicalResarchDoktorItem);
        }
    }

    controlOfAddProcedure() {
        if (this.selectedMedicalResarchProcedureItem != null) {
            if (this.medicalResarchProcedureDataSourceList.filter(x => x.ObjectID == this.selectedMedicalResarchProcedureItem.ObjectID).length == 0) {
                this.medicalResarchProcedureDataSourceList.push(this.selectedMedicalResarchProcedureItem);
            }
            else {
                ServiceLocator.MessageService.showError("Aynı Araştırma İşlemini Birden Fazla Giremezsiniz !");
            }
        }
        else {
            this.medicalResarchProcedureDataSourceList.push(this.selectedMedicalResarchProcedureItem);
        }
    }


    @ViewChild('medicalResarchDoktorDataSourceGrid') medicalResarchDoktorDataSourceGrid: DxDataGridComponent;
    medicalResarchDoktorDataSourceGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    this.medicalResarchDoktorDataSourceGrid.instance.deleteRow(data.rowIndex);
                }
            }
        }
    }

    @ViewChild('medicalResarchProcedureDataSourceGrid') medicalResarchProcedureDataSourceGrid: DxDataGridComponent;
    medicalResarchProcedureDataSourceGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    this.medicalResarchProcedureDataSourceGrid.instance.deleteRow(data.rowIndex);
                }
            }
        }
    }

    public showPatientAdmissionPopup: boolean = false;

    addPatient() {
        new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'MedicalResarchPatientAd';
            componentInfo.ModuleName = 'MedicalResarchWorkListModule';
            componentInfo.ModulePath = 'Modules/Tibbi_ve_Teknik_Destek_Modulleri/Tibbi_Arastirma_Modulu/Tibbi_Arastirma_Is_Listesi/MedicalResarchWorkListModule';
            componentInfo.ParentInstance = this;
            componentInfo.InputParam = this.model.ObjectId;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Tıbbı Araştırma Hasta Kayıt"
            modalInfo.Width = 800;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }
}

