import { Component, OnInit, ViewChild, Input, Renderer2 } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { DrugUsageReportFormViewModel } from './DrugUsageReportFormViewModel';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from "app/NebulaClient/Visual/TTUnboundForm";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { Headers, RequestOptions } from '@angular/http';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { Patient, ParticipatnFreeDrugReport } from "app/NebulaClient/Model/AtlasClientModel";
import { DxAccordionComponent } from "devextreme-angular";
import { ModalInfo } from "app/Fw/Models/ModalInfo";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { IModalService } from "app/Fw/Services/IModalService";
import { ObjectContextService } from "Fw/Services/ObjectContextService";

@Component({
    selector: "DrugUsageReportForm",
    templateUrl: './DrugUsageReportForm.html',
    providers: [SystemApiService, MessageService]
})

export class DrugUsageReportForm extends TTUnboundForm implements OnInit {
    public DrugUsageReportFormViewModel: DrugUsageReportFormViewModel;
    public DayQueryNumber: number;
    private _StoreObjectId: string;
    public SelectedMaterials: Array<Guid> = new Array<Guid>();
    public StartDate: Date;
    public EndDate: Date;
    public visibility: boolean = false;
    public DrugActiveIngredientList: TTVisual.ITTObjectListBox;
    drugReturnActionState: number = 0;
    DrugUsageInfoGridList: Array<DrugUsageInfoGrid>;
    SelectedDrugActiveIngredients: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public TotalNumberOfRows: number;
    AllActiveIngredientDefs: boolean;
    public componentInfo: DynamicComponentInfo;
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';

    @ViewChild('materialActionDetayAccordion') materialActionDetayAccordion: DxAccordionComponent;

    public DrugUsageInfoListColumns = [
        {
            caption: '',
            dataField: 'ReportObjectID',
            width: 50,
            cellTemplate: 'buttonCellTemplate',
        },
        {
            'caption': "Hasta Adı Soyadı",
            dataField: 'PatientName',
            allowSorting: true
        },
        {
            'caption': "TC Kimlik No",
            dataField: 'PatientUniqueRefNo',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "Rapor Başlangıç Tarihi",
            dataField: 'ReportStartDate',
            allowSorting: true,
            dataType: 'date',
            format: 'dd/MM/yyyy'
        },
        {
            'caption': "Kabul No",
            dataField: 'AdmissionNo',
            dataType: 'string',
            allowSorting: true,
        },
        {
            'caption': "Doktor",
            dataField: 'DoctorName',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "Servis",
            dataField: 'MasterResourceName',
            dataType: 'string',
            allowSorting: true
        },


    ];
    @Input() set StoreObjectId(object: string) {
        if (object != null && this._StoreObjectId != object) {
            this._StoreObjectId = object;
        }
    }
    get StoreObjectId(): string {
        return this._StoreObjectId;
    }

    constructor(protected httpService: NeHttpService, private modalService: IModalService, protected objectContextService: ObjectContextService, protected messageService: MessageService, public systemApiService: SystemApiService, private renderer: Renderer2) {
        super('DrugUsageReport', 'DrugUsageReportForm');
               this.initViewModel();
    }

    public initViewModel(): void {
        this.DrugUsageReportFormViewModel = new DrugUsageReportFormViewModel();
      //  this.AllActiveIngredientDefs = false;
    }

    async ngOnInit() {
        this.setDefaultDates();
       // this.FillDataSources();
    }


    ActiveIngredientList: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    async FillDataSources() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugUsageReportService/FillDataSources?AllActiveIngredientDefs=' + this.AllActiveIngredientDefs;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.get<any>(apiUrlForPASearchUrl).then(response => {
                let result = response;
                if (result) {
                    this.ActiveIngredientList = result.ActiveIngredientList;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    onAllActiveIngredientClicked(){
        this.FillDataSources();
    }

    selectedPatient: Patient = new Patient();
    async patientChanged(patient: any) {

        let that = this;
        if (!that.selectedPatient) {
            that.selectedPatient = new Patient();
        }
        that.selectedPatient = patient;
    }

    AdmissionNo: string = "";
    PatientUniqueRefNo: string = "";

    public setDefaultDates() {
        this.StartDate = new Date();
        this.StartDate.setHours(0, 0, 0, 0);
        this.EndDate = new Date();
        this.EndDate.setHours(23, 59, 59, 0);
    }

    onParticipatientReportOpen(data: any) {
        let temp;


            this.objectContextService.getObject<ParticipatnFreeDrugReport>(data.key.ReportObjectID, ParticipatnFreeDrugReport.ObjectDefID, ParticipatnFreeDrugReport).then(result => {
                let temp: ParticipatnFreeDrugReport = result;
                temp = result;
                this.showParticipatnFreeDrugReport(temp);
            });
    }

    showParticipatnFreeDrugReport(value: any){
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ParticipationFreeDrugReportNewForm';
            componentInfo.ModuleName = "HastaRaporlariModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule';
            componentInfo.InputParam = value;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "İlaç Raporu";
            //modalInfo.Width = 1024;
            //modalInfo.Height = 768;
            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async GetDrugUsageInfoGridListList() {
        this.showLoadPanel = true;
        try {
            if (this.selectedPatient == undefined || this.selectedPatient == null)
                this.selectedPatient = new Patient();
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugUsageReportService/GetDrugUsageInfo';
            let body = { 'StartDate': this.StartDate, 'EndDate': this.EndDate, 'PatientID': this.selectedPatient.ObjectID, 'PatientUniqueRefNo': this.PatientUniqueRefNo, 'SelectedDrugActiveIngredients': this.SelectedDrugActiveIngredients, 'AdmissionNo': this.AdmissionNo};
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DrugUsageInfoGridList = result;
                }
                this.TotalNumberOfRows = this.DrugUsageInfoGridList.length;
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {

        }
        finally {
            this.showLoadPanel = false;
        }
    }


}


export class DrugUsageInfoGrid {
    public ReportObjectID: Guid;
    public PatientName: string;
    public PatientUniqueRefNo: string;
    public ReportStartDate: Date;
    public AdmissionNo: string;
    public MaterialName: string;
    public DoctorName: string;
    public MasterResourceName: string;
}

export class ListMaterialsObject {
    public ObjectID: Guid;
    public Name: string;
    public InHeldAmount: string;
}