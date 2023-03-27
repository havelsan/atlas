//$C4462073
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { TigEpisodeFormViewModel } from './TigEpisodeFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TigEpisode } from 'NebulaClient/Model/AtlasClientModel';

import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { TigEpisodeFormSearchModel, TigEpisodeSearchResultModel } from './TigEpisodeFormViewModel';
import { IModalService } from "Fw/Services/IModalService";
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { DxPopoverComponent, DxDataGridComponent } from 'devextreme-angular';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';





@Component({
    selector: 'TigEpisodeForm',
    templateUrl: './TigEpisodeForm.html',
    providers: [MessageService]
})
export class TigEpisodeForm extends TTVisual.TTForm implements OnInit {
    public tigEpisodeFormViewModel: TigEpisodeFormViewModel = new TigEpisodeFormViewModel();
    public xMLStatus: ComboBoxElement[];
    public codingStatus: ComboBoxElement[];
    public invoiceStatus: ComboBoxElement[];
    public pathologyRequestStatus: ComboBoxElement[];
    public pathologyReportStatus: ComboBoxElement[];
    public appointmentStatus: ComboBoxElement[];
    public epicrisisStatus: ComboBoxElement[];
    public doctorArray: Array<any> = [];
    public clinicArray: Array<any> = [];
    public specialityArray: Array<any> = [];
    public tigResponsiblePersonelArray: Array<any> = [];
    public selectedTigEpisodeItems: Array<TigEpisodeSearchResultModel> = new Array<TigEpisodeSearchResultModel>();
    public showPatientHistoryPopup: boolean = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Kayıtlar Yükleniyor, Lütfen Bekleyiniz.';
    public popupTitle: string = "Hasta Geçmişi";
    @ViewChild(DxPopoverComponent) popOver: DxPopoverComponent;
    @ViewChild('tigepisodes') TigEpisodeGrid: DxDataGridComponent;


    patientType: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: 'TIGPatientTypeEnum',
        ShowClearButton: true,
    };

    public get _TigEpisode(): TigEpisode {
        return this._TTObject as TigEpisode;
    }
    private TigEpisodeForm_DocumentUrl: string = '/api/TigEpisodeService/TigEpisodeForm';
    constructor(protected httpService: NeHttpService,
        protected modalService: IModalService,
        protected messageService: MessageService,
        private http2: AtlasHttpService,
        protected ngZone: NgZone) {
        super('TIGEPISODE', 'TigEpisodeForm');
        this._DocumentServiceUrl = this.TigEpisodeForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        //
        this.xMLStatus = xMLStatus;
        this.codingStatus = codingStatus;
        this.invoiceStatus = invoiceStatus;
        this.pathologyRequestStatus = pathologyRequestStatus;
        this.pathologyReportStatus = pathologyReportStatus;
        this.appointmentStatus = appointmentStatus;
        this.epicrisisStatus = epicrisisStatus;

    }

    getRecords(): void {
        let apiUrl: string = '/api/TigEpisodeService/GetTigEpisodeRecords';

        this.showLoadPanel = true;
        this.httpService.post<Array<TigEpisodeSearchResultModel>>(apiUrl, this.tigEpisodeFormViewModel.TigEpisodeFormSearchModel).then(response => {
            let result = <Array<TigEpisodeSearchResultModel>>response;
            result.forEach(element => {

            });
            this.tigEpisodeFormViewModel.TigEpisodeCollectionList = response;
            this.showLoadPanel = false;
        }).catch(error => {
            console.log(error);
            this.showLoadPanel = false;
        });
    }


    createXML(): void {
        if (this.selectedTigEpisodeItems.length > 0) {
            let apiUrl: string = '/api/TigXmlFile/CreateXMLFileForSelectedEpisodes';
            let token = sessionStorage.getItem('token');
            let input = { TigObjectList: this.selectedTigEpisodeItems };
            let headers = new Headers();
            let options = new RequestOptions();
            options.headers = headers;
            options.responseType = ResponseContentType.Blob;

            this.http2.post(apiUrl, input, options).toPromise().then(
                (res) => {
                    CommonHelper.saveFile(res.blob(), "ATLAS_TIG_" + this.getCurrentDateString() + ".xml");
                    this.getRecords();
                });
        } else {
            TTVisual.InfoBox.Alert(i18n("M24224", "XML oluşturmak için en az 1 kayıt seçmeniz gerekmektedir!"));
        }
    }

    public tigObjectIdList: Array<Guid> = new Array<Guid>();
    public async printXMLReport(): Promise<ModalActionResult> {
        if (this.selectedTigEpisodeItems.length > 0) {
            this.selectedTigEpisodeItems.forEach(element => {
                this.tigObjectIdList.push(element.TigObjectID);
            });


            let reportData: DynamicReportParameters = {

                Code: 'XMLRAPORU',
                ReportParams: { TigObjectIDs: this.tigObjectIdList },
                ViewerMode: true
            };

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'HvlDynamicReportComponent';
                componentInfo.ModuleName = 'DevexpressReportingModule';
                componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "XML RAPORU"

                modalInfo.fullScreen = true;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        }
        else {
            TTVisual.InfoBox.Alert(i18n("M24224", "XML raporu oluşturmak için en az 1 kayıt seçmeniz gerekmektedir!"));
        }
    }

    getCurrentDateString(): string {
        let today = new Date();
        let dateString: string = "";
        today.getDate() < 10 ? dateString += "0" : ""; dateString += today.getDate().toString();
        today.getMonth() + 1 < 10 ? dateString += "0" : ""; dateString += (today.getMonth() + 1).toString();
        dateString += today.getFullYear().toString() + "_";
        dateString += today.getHours().toString() + today.getMinutes().toString() + today.getSeconds();
        return dateString;
    }
    onCellHover(e: any) {
        if (e.column != null && e.rowType == "data") {
            if (e.column.dataField == 'Diagnosis') {
                if (e.data.Diagnosis !== "") {
                    this.popOver.target = e.cellElement;
                    this.popOver.contentTemplate = e.data.Diagnosis;
                    this.popOver.visible = true;
                }
            } else if (e.column.dataField == 'Surgeries') {
                if (e.data.Surgeries !== "") {
                    this.popOver.target = e.cellElement;
                    this.popOver.contentTemplate = e.data.Surgeries;
                    this.popOver.visible = true;
                }
            } else {
                this.popOver.visible = false;
            }
        }
        else
            this.popOver.visible = false;
    }

    MarkCodedForSelectedEpisodes(): void {
        let apiUrl: string = '/api/TigEpisodeService/MarkCodedForSelectedEpisodes';
        this.httpService.post<string>(apiUrl, this.selectedTigEpisodeItems).then(response => {
            this.getRecords();

        }).catch(error => {
            console.log(error);
        });
    }

    public grdTigEpisodeRowClick(event: any): void {
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 250)) {
            this.tigEpisodeFormViewModel.selectedEpisode = event.data.EpisodeGuid;
            this.popupTitle = "Hasta Geçmişi -" + event.data.EpisodeNo + "   " + event.data.PatientName + " " + event.data.PatientSurname;
            this.showPatientHistoryPopup = true;
        }
    }

    public openTIGWebPage() {

        let win = window.open("http://xxxxxx.com/Login.aspx?IsApplicationRequest=true", '_blank');
        win.focus();

    }

    public openTIGDocuments() {

        let win = window.open("http://xxxxxx.com/TR,6177/dokumanlar.html", '_blank');
        win.focus();

    }

    public TigEpisodeDataGridColumns =
        [
            {
                caption: 'Episode No',
                dataField: 'EpisodeNo',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M15131", "Hasta Adı"),
                dataField: 'PatientName',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M15303", "Hasta Soyadı"),
                dataField: 'PatientSurname',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M17578", "Kimlik No"),
                dataField: 'PatientUniqueRefNo',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M21662", "Kayıt Tipi"),
                dataField: 'RecordType',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M21662", "Servis"),
                dataField: 'Resource',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M24448", "Yatış Tarihi"),
                dataField: 'InpatientDate',
                width: "auto",
                dataType: 'date',
                format: 'dd/MM/yyyy HH:mm:ss',
                allowEditing: false
            },
            {
                caption: i18n("M12379", "Çıkış Tarihi"),
                dataField: 'DischargeDate',
                width: "auto",
                dataType: 'date',
                format: 'dd/MM/yyyy HH:mm:ss',
                allowEditing: false
            },
            {
                caption: 'XML',
                dataField: 'XMLStatus',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M24225", "XML Oluşturulma Tarihi"),
                dataField: 'XMLCreationDate',
                width: "auto",
                dataType: 'date',
                format: 'dd/MM/yyyy HH:mm:ss',
                allowEditing: false
            },
            {
                caption: 'Kodlama',
                dataField: 'CodingStatus',
                width: "auto",
                allowEditing: false
            },
            {
                caption: 'Kodlama Tarihi',
                dataField: 'CodingDate',
                width: "auto",
                dataType: 'date',
                format: 'dd/MM/yyyy HH:mm:ss',
                allowEditing: false
            },
            {
                caption: i18n("M10469", "Açıklama"),
                dataField: 'Description',
                width: "auto"
            },
            {
                caption: i18n("M14179", "Fatura No"),
                dataField: 'InvoiceNum',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M13155", "Doktor Adı"),
                dataField: 'DoctorName',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M13206", "Doktor TC"),
                dataField: 'DoctorUniqueRefNo',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M22551", "Taburcu Eden Dr"),
                dataField: 'DischargerDoctorName',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M12049", "Branş Adı"),
                dataField: 'BranchName',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M12052", "Branş Kodu"),
                dataField: 'BranchCode',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M18009", "Kurum"),
                dataField: 'PayerName',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M23037", "Tedavi Türü"),
                dataField: 'PatientType',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M22736", "Tanı"),
                dataField: 'Diagnosis',
                width: 300,
                allowEditing: false
            },
            {
                caption: i18n("M24438", "Yatış No"),
                dataField: 'InPatientProtocolNo',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M10818", "Ameliyat İşlemi"),
                dataField: 'Surgeries',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M19359", "Müracaat Tarihi"),
                dataField: 'AppointmentDate',
                width: "auto",
                dataType: 'date',
                format: 'dd/MM/yyyy HH:mm:ss',
                allowEditing: false
            },
            {
                caption: i18n("M20238", "Patoloji İstemi"),
                dataField: 'PathologyRequest',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M20225", "Patoloji Durumu"),
                dataField: 'PathologyStatus',
                width: "auto",
                allowEditing: false
            },
            {
                caption: 'Arşiv Bilgisi',
                dataField: '',
                cellTemplate: 'detailButtonTemplate',
                Name: 'btnInfo',
                width: "auto"
                //width: 400
            },
            {
                caption: i18n("M24221", "XML Oluşturan Kullanıcı"),
                dataField: 'XMLCreatedByUserName',
                width: "auto",
                allowEditing: false
            },
            {
                caption: i18n("M17682", "Kodlama Yapan Kullanıcı"),
                dataField: 'CodingByUserName',
                width: "auto",
                allowEditing: false
            },
        ];







    userSearchModelLoaded(value) {
        if (value != null)
            this.tigEpisodeFormViewModel.TigEpisodeFormSearchModel = JSON.parse(value);
        else
            this.tigEpisodeFormViewModel.TigEpisodeFormSearchModel = new TigEpisodeFormSearchModel();
    }
    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new TigEpisode();
        this.tigEpisodeFormViewModel = new TigEpisodeFormViewModel();
        this._ViewModel = this.tigEpisodeFormViewModel;
        this.tigEpisodeFormViewModel._TigEpisode = this._TTObject as TigEpisode;
    }

    protected loadViewModel() {
        let that = this;

        that.tigEpisodeFormViewModel = this._ViewModel as TigEpisodeFormViewModel;
        that._TTObject = this.tigEpisodeFormViewModel._TigEpisode;
        if (this.tigEpisodeFormViewModel == null)
            this.tigEpisodeFormViewModel = new TigEpisodeFormViewModel();
        if (this.tigEpisodeFormViewModel._TigEpisode == null)
            this.tigEpisodeFormViewModel._TigEpisode = new TigEpisode();
        this.httpService.get<Array<any>>("api/TigEpisodeService/GetDoctor").then(result => {
            this.doctorArray = result;
        });
        this.httpService.get<Array<any>>("api/TigEpisodeService/GetClinics").then(result => {
            this.clinicArray = result;
        });
        this.httpService.get<Array<any>>("api/TigEpisodeService/GetSpecialities").then(result => {
            this.specialityArray = result;
        });
        this.httpService.get<Array<any>>("api/TigEpisodeService/GetTigPersonelList").then(result => {
            this.tigResponsiblePersonelArray = result;
        });
    }

    async ngOnInit() {
        let that = this;
        await this.load(TigEpisodeFormViewModel);

    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }

    public selectedTigEpisode: TigEpisode;
    public patientInfo: string;
    onContextMenuPreparingTIGEpisodes(e: any): void {
        let that = this;

        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {

                e.items = [{
                    text: i18n("M22634", "Açıklama Giriş"),
                    onItemClick: function () {
                        that.selectedTigEpisode = e.row.data as TigEpisode;
                        that.patientInfo = e.row.data.EpisodeNo + " - " + e.row.data.PatientName + " " + e.row.data.PatientSurname;
                        if (e.row.data.Description != null) {
                            that.TIGEpisodeDescription = e.row.data.Description;
                        }
                        that.openDescriptionPopUp(e.row.data.TigObjectID);
                    }
                }
                ];
            }
        }
    }

    public TIGEpisodeDescription: string;
    public createDescription: boolean = false;
    public TigID: Guid;
    openDescriptionPopUp(TIGEpisodeID: Guid): void {
        this.TigID = TIGEpisodeID;
        this.createDescription = true;
    }
    createTIGDescription(action: string): void {
        if (action.Equals("T")) {
            let that = this;
            let apiURL: string = '/api/TigEpisodeService/CreateDescriptionForSelectedTIG?TIGEpisodeID=' + this.TigID + "&description=" + this.TIGEpisodeDescription;
            this.httpService.get<string>(apiURL).then(response => {
                ServiceLocator.MessageService.showSuccess(i18n("M16830", "Açıklama eklendi."));
                that.selectedTigEpisode.Description = that.TIGEpisodeDescription;
                that.TIGEpisodeDescription = "";
                that.TigEpisodeGrid.instance.refresh();
                that.createDescription = false;
            }).catch(error => {
                console.log(error);
            });
        }
        if (action.Equals("V")) {
            this.createDescription = false;
        }
    }


    patientChanged(patient: any) {
        if (patient) {
            this.tigEpisodeFormViewModel.TigEpisodeFormSearchModel.PatientID = patient.ObjectID;
        }
        else {
            this.tigEpisodeFormViewModel.TigEpisodeFormSearchModel.PatientID = null;
        }
    }

    showArchive: boolean;
    FileCreationAndAnalysisID: Guid;
    ShowSectionInfo_CellContentClickEmitted(data: any) {
        if (data != null && data.column.Name == 'btnInfo') {
            this.showArchive = true;
            let apiURL: string = '/api/TigEpisodeService/GetFileCreationAndAnalysis?EpisodeID=' + data.data.EpisodeGuid;
            this.httpService.get<Guid>(apiURL).then(result => {
                if (result != null) {
                    this.FileCreationAndAnalysisID = result;
                    this.rowClick(this.FileCreationAndAnalysisID);
                }
                else {
                    ServiceLocator.MessageService.showError("Hastanın arşiv kaydı bulunmamaktadır");
                }
            });
        }
    }

    rowClick(FcaaID: Guid) {
        if (FcaaID != null) {
            return new Promise((resolve, reject) => {
                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'FormFCAAArchive';
                componentInfo.ModuleName = "ArsivModule";
                componentInfo.ModulePath = '/Modules/Tibbi_Surec/Arsiv_Modulu/ArsivModule';
                componentInfo.objectID = FcaaID.toString();

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = i18n("M11100", "Arşiv Kayıt");
                modalInfo.Width = 1248;
                modalInfo.Height = 900;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        }

    }


}

export class ComboBoxElement {
    public ID: number;
    public Name: string;
}

let xMLStatus: ComboBoxElement[] = [{
    ID: 0,
    Name: i18n("M19647", "Oluşturulmamış"),
}, {
    ID: 1,
    Name: i18n("M19648", "Oluşturulmuş")
}, {
    ID: 2,
    Name: i18n("M23653", "Tümü")
}];
let codingStatus: ComboBoxElement[] = [{
    ID: 0,
    Name: i18n("M17684", "Kodlanmamış"),
}, {
    ID: 1,
    Name: i18n("M17685", "Kodlanmış")
}, {
    ID: 2,
    Name: i18n("M23653", "Tümü")
}];
let invoiceStatus: ComboBoxElement[] = [{
    ID: 0,
    Name: i18n("M14259", "Faturası Kesilmiş"),
}, {
    ID: 1,
    Name: i18n("M14258", "Faturası Kesilmemiş")
}, {
    ID: 2,
    Name: i18n("M23653", "Tümü")
}];
let pathologyRequestStatus: ComboBoxElement[] = [{
    ID: 0,
    Name: "Var",
}, {
    ID: 1,
    Name: i18n("M24703", "Yok")
}, {
    ID: 2,
    Name: i18n("M23653", "Tümü")
}];
let pathologyReportStatus: ComboBoxElement[] = [{
    ID: 0,
    Name: i18n("M19698", "Onaylanan"),
}, {
    ID: 1,
    Name: i18n("M19704", "Onaylanmayan")
}, {
    ID: 2,
    Name: i18n("M23653", "Tümü")
}];
let appointmentStatus: ComboBoxElement[] = [{
    ID: 0,
    Name: i18n("M20712", "Rand. Onaylanan"),
}, {
    ID: 1,
    Name: i18n("M20713", "Rand. Onaylanmayan")
}, {
    ID: 2,
    Name: i18n("M23653", "Tümü")
}];
let epicrisisStatus: ComboBoxElement[] = [{
    ID: 0,
    Name: i18n("M19629", "Olan"),
}, {
    ID: 1,
    Name: i18n("M19640", "Olmayan")
}, {
    ID: 2,
    Name: i18n("M23653", "Tümü")
}];
