//$12DF1789
import { Component, ViewChild, OnInit, EventEmitter, Input, SimpleChanges, Output, Renderer2 } from '@angular/core';
import {
    MedicalStuffPrescriptionFormViewModel, MedulaResult, OldMedicalStuffPrescriptionModel, AddDiagnosisToPrescriptionClass, AddDiagnosisToPrescriptionResponseClass, eReceteListeSorgulaClass
} from './MedicalStuffPrescriptionFormViewModel';
import { MedicalStuffPrescription, ResUser, DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

import { TTTextBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTTextBoxColumn';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { UserHelper } from 'app/Helper/UserHelper';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { MedicalStuff, MedicalStuffReport } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ReportDiagnosisForm } from "Modules/Tibbi_Surec/Tani_Modulu/ReportDiagnosisForm";
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { UsernamePwdInput, UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { UsernamePwdFormViewModel } from 'Fw/Components/UsernamePwdFormComponent';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { ModalActionResult } from "Fw/Models/ModalInfo";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { MedicalStuffUsageType } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: 'MedicalStuffPrescriptionForm',
    templateUrl: './MedicalStuffPrescriptionForm.html',
    providers: [MessageService, { provide: IESignatureService, useClass: ESignatureService }]
})
export class MedicalStuffPrescriptionForm extends TTVisual.TTForm implements OnInit {
    public globalPrescriptionID: any;
    public ResultSetList = null;
    DescriptionTypeEnum: TTVisual.ITTEnumComboBox;
    PrescriptionDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    PrescriptionDescription: TTVisual.ITTRichTextBoxControl;
    StuffUsageType: TTVisual.TTObjectListBox;
    MedulaPrescriptionDescription: TTVisual.ITTTextBox;
    ReceteTakipNo: TTVisual.ITTTextBox;
    MedulaDescription: TTVisual.ITTTextBox;
    PrescriptionReportListView: TTVisual.ITTListView;
    PrescriptionListView: TTVisual.ITTListView;
    MedulaPrescriptionListView: TTVisual.ITTListView;
    DescriptionType: TTVisual.ITTEnumComboBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    public medulaReportNo: string = "";
    public gridMedulaStuffColumns = [];
    StuffAmount: TTVisual.ITTTextBoxColumn;
    StuffDescription: TTVisual.ITTTextBoxColumn;
    txtStuffName: TTVisual.ITTTextBoxColumn;
    txtStuffCode: TTVisual.ITTTextBoxColumn;
    PeriodUnitType: TTVisual.ITTEnumComboBox;
    PeriodUnit: TTVisual.ITTTextBoxColumn;
    cmbRaporSureTuru: TTVisual.ITTEnumComboBox;
    MedicalStuffPlaceOfUsage: TTVisual.TTObjectListBox;
    MedicalStuffGroup: TTVisual.TTObjectListBox;
    lstDiagnosisAddedToReport: TTVisual.ITTObjectListBox;
    public showLoadPanel = false;
    public LoadPanelMessage = "";
    public enableMedulaPasswordEntrance: boolean = false;
    public addExtraDiagnosisPopUp = false;

    public medicalStuffReport: MedicalStuffReport;
    public addedDiagnosis: DiagnosisDefinition = null;

    public ePrescriptionList: Array<any>[] = new Array<any>();
    public prescriptionTani: Array<any>[] = new Array<any>();

    public prescriptionMalzeme: Array<any>[] = new Array<any>();

    public lastSelectedEprescription: any = null;
    public showPrescriptionListPopUp = false;

    public medicalStuffColumns = [
        {
            caption: 'Kodu',
            dataField: 'MedicalStuffDef',
            allowEditing: false,
            width: '10%',
            cellTemplate: 'medicalStuffCodeTemplate'
        },
        {
            caption: 'Adı',
            dataField: 'MedicalStuffDef',
            allowEditing: false,
            width: '22%',
            cellTemplate: 'medicalStuffNameTemplate'
        },
        {
            caption: 'Miktar',
            dataField: 'StuffAmount',
            width: '9%',
            cellTemplate: 'medicalStuffAmountTemplate'
        },
        {
            caption: 'Kullanım Yeri',
            dataField: 'MedicalStuffPlaceOfUsage',
            width: '13%',
            cellTemplate: 'medicalStuffPlaceOfUsageTemplate'
        },
        {
            caption: 'Kullanım Şekli',
            dataField: 'MedicalStuffUsageType',
            width: '13%',
            cellTemplate: 'medicalStuffUsageTypeTemplate'
        },
        {
            caption: 'Odyometri Test Id',
            dataField: 'OdyometryTestId',
            width: '9%',
            cellTemplate: 'medicalStuffOdyometryTestIdTemplate'
        },
        {
            caption: 'Kullanım Periyodu',
            dataField: 'PeriodUnit',
            width: '9%',
            cellTemplate: 'medicalStuffPeriodUnitTemplate'
        },
        {
            caption: 'K.P. Birimi',
            dataField: 'PeriodUnitType',
            width: '13%',
            cellTemplate: 'medicalStuffPeriodUnitTypeTemplate'
        },
        /*{
            caption: 'Açıklama',
            dataField: 'StuffDescription',
            width: '12%',
            cellTemplate: 'stuffDescriptionTemplate'
        },*/
    ];

    public PrepareSignedPrescriptionContentUrl: string = '/api/MedicalStuffPrescriptionService/PrepareSignedPrescriptionContent';
    public SendSignedPrescriptionContentUrl: string = '/api/MedicalStuffPrescriptionService/SendSignedPrescriptionContent';

    public PrepareSignedApprovalPrescriptionContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedApprovalPrescriptionContent';
    public PrepareSignedDeletePrescriptionContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedDeletePrescriptionContent';
    public SendSignedApprovalPrescriptionContentUrl: string = '/api/MedicalStuffReportService/SendSignedApprovalPrescriptionContent';
    public SendSignedDeletePrescriptionContentUrl: string = '/api/MedicalStuffReportService/SendSignedDeletePrescriptionContent';

    public PrepareSignedDiagnosisPrescriptionContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedDiagnosisPrescriptionContent';
    public SendSignedDiagnosisPrescriptionContentUrl: string = '/api/MedicalStuffReportService/SendSignedDiagnosisPrescriptionContent';

    public PrepareSignedDescriptionPrescriptionContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedDescriptionPrescriptionContent';
    public SendSignedDescriptionPrescriptionContentUrl: string = '/api/MedicalStuffReportService/SendSignedDescriptionPrescriptionContent';

    public medicalStuffPrescriptionFormViewModel: MedicalStuffPrescriptionFormViewModel = new MedicalStuffPrescriptionFormViewModel();
    public get _MedicalStuffPrescription(): MedicalStuffPrescription {
        return this._TTObject as MedicalStuffPrescription;
    }
    public MedicalStuffPrescriptionForm_DocumentUrl: string = '/api/MedicalStuffPrescriptionService/MedicalStuffPrescriptionForm';
    constructor(public httpService: NeHttpService, public messageService: MessageService, private renderer: Renderer2, public signService: IESignatureService) {
        super('MEDICALSTUFFPRESCRIPTION', 'MedicalStuffPrescriptionForm');
        this._DocumentServiceUrl = this.MedicalStuffPrescriptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    @Output() sendPrescriptionViewModel: EventEmitter<any> = new EventEmitter<any>();


    public _MedicalStuffReportObject: MedicalStuffReport;
    @Input() set MedicalStuffReportObject(value: MedicalStuffReport) {
        this._MedicalStuffReportObject = value;
        //this.medicalStuffPrescriptionFormViewModel.prescriptionEpisodeAction = value;
        this.getForm();
    }
    get MedicalStuffReportObject(): MedicalStuffReport {
        return this._MedicalStuffReportObject;
    }
    public _MedicalStuffPrescriptionStuffs: Array<any>;
    @Input() set MedicalStuffReportStuffs(value: Array<any>) {
        this._MedicalStuffPrescriptionStuffs = value;
        //this.medicalStuffPrescriptionFormViewModel.prescriptionEpisodeAction = value;

    }
    get MedicalStuffReportStuffs(): Array<any> {
        return this._MedicalStuffPrescriptionStuffs;
    }

    @Input() set Episode(value: Guid) {
        this.medicalStuffPrescriptionFormViewModel.episode = value;

    }
    get Episode(): Guid {
        return this.medicalStuffPrescriptionFormViewModel.episode;
    }

    public showReportDiagnosis = false;


    public async btndiagnosis_Click(): Promise<void> {
        this.showReportDiagnosis = true;

        //await this.Report.getReadOnlyDiagnosis();
    }

    public getMedicalStuffReport() {
        let apiURL = "api/MedicalStuffReportService/GetMedicalStuffReportObject?reportNo=" + this.medulaReportNo;
        this.httpService.get<MedicalStuffReport>(apiURL).then(result => {
            if (result != null) {
                this.medicalStuffReport = result as MedicalStuffReport;
                this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedicalStuffReport = this.medicalStuffReport;
                this.getReportMaterials();
                this.loadOldPrescriptions();
            } else {
                TTVisual.InfoBox.Show("Verilen Rapor Takip Numarasına Uygun Rapor Bulunamadı.");
            }
        });
    }


    public async getReportMaterials(): Promise<void> {
        let apiURL = "api/MedicalStuffPrescriptionService/GetMedicalStuffReportMaterials?reportObjectId=" + this.medicalStuffReport.ObjectID.toString();
        this.httpService.get<Array<any>>(apiURL).then(result => {
            this.medicalStuffPrescriptionFormViewModel.medicalStuffs = result;
            this.loadViewModel();
        });
    }

    public async loadOldPrescriptions(): Promise<void> {
        let apiUrl = "/api/MedicalStuffPrescriptionService/GetOldMedicalStuffPrescriptions?reportObjectId=";
        if (this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedicalStuffReport.ObjectID != null) {
            apiUrl += this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedicalStuffReport.ObjectID.toString();
        } else {
            apiUrl += this.medicalStuffReport.ObjectID.toString();
        }
        let response = await this.httpService.get<Array<OldMedicalStuffPrescriptionModel>>(apiUrl);
        this.LoadPrescriptionListView(response, false);
    }

    public async getForm(): Promise<void> {
        let apiUrl = "/api/MedicalStuffReportService/MedicalStuffReportForm?id=" + Guid.Empty;
        let response = await this.httpService.get<MedicalStuffPrescriptionFormViewModel>("/api/MedicalStuffPrescriptionService/MedicalStuffPrescriptionForm", MedicalStuffPrescriptionFormViewModel);
        this._ViewModel = response;
        this.loadViewModel();
        this.processReadOnly();
        this.redirectProperties();
        this.loadOldPrescriptions();

    }
    // ***** Method declarations start *****


    public async AddExtraDiagnosis() {
        let inputClass: AddDiagnosisToPrescriptionClass = new AddDiagnosisToPrescriptionClass();
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
            inputClass.medulaUsername = this.medicalStuffPrescriptionFormViewModel.medulaUsername;
            inputClass.medulaPassword = this.medicalStuffPrescriptionFormViewModel.medulaPassword;
        }
        inputClass.Diagnose = this.addedDiagnosis;
        inputClass.PrescriptionObject = this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription;
        this.loadPanelOperation(true, "Tanı Ekleniyor Lütfen Bekleyiniz.");
        this.httpService.post<AddDiagnosisToPrescriptionResponseClass>('/api/MedicalStuffPrescriptionService/ReceteTaniEkle', inputClass).then(result => {
            if (result != null) {
                if (result.sonucKodu == "0000") {
                    this.messageService.showSuccess("Tanı Başarıyla Eklendi");
                    this.load();
                } else {
                    this.messageService.showError("Tanı Eklenirken bir hata oluştu. Hata : " + result.sonucMesaji);
                    //this.loadPanelOperation(false, "");
                }
            }
        }).catch(e => {
            this.messageService.showError(e);
            this.loadPanelOperation(false, "");
        });


        this.loadPanelOperation(false, "");
    }

    public async eReceteListeSorgula() {
        let inputClass: eReceteListeSorgulaClass = new eReceteListeSorgulaClass();
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
            inputClass.medulaUsername = this.medicalStuffPrescriptionFormViewModel.medulaUsername;
            inputClass.medulaPassword = this.medicalStuffPrescriptionFormViewModel.medulaPassword;
        }
        inputClass.PrescriptionObject = this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription;
        //this.loadPanelOperation(true, "Tanı Ekleniyor Lütfen Bekleyiniz.");
        this.httpService.post<any>('/api/MedicalStuffPrescriptionService/ReceteListeSorgula', inputClass).then( result =>{
            if (result != null) {
                if (result.sonucKodu == "0000") {
                    this.messageService.showSuccess("Sorgu Başarıyla getirildi.");
                    this.ePrescriptionList = result.receteCevapDVO;
                    this.prescriptionTani = result.taniListesi;
                    this.prescriptionMalzeme = result.malzemeListesi;
                    this.showPrescriptionListPopUp = true;
                } else {
                    this.messageService.showError("Tanı Eklenirken bir hata oluştu. Hata : " + result.sonucMesaji);
                    //this.loadPanelOperation(false, "");
                }
            }
        }).catch(e =>{
            this.messageService.showError(e);
            this.loadPanelOperation(false, "");
        });

        
        //this.loadPanelOperation(false, "");
    }

    selectPrescription(event: any) {
        this.lastSelectedEprescription = event.itemData;
    }

    public openDiagnosisPopUp() {
        this.addExtraDiagnosisPopUp = true;
    }

    public async selectAdditionalDiagnosis(diagnosis: any) {
        if (diagnosis != null) {
            if (this.medicalStuffPrescriptionFormViewModel.reportDiagnosisFormViewModel != null
                && this.medicalStuffPrescriptionFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList != null) {
                let diagnoseList = this.medicalStuffPrescriptionFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList;

                let isDiagnosisExists = diagnoseList.find(t => t.DiagnoseCode === diagnosis.DiagnoseCode);
                if (isDiagnosisExists == null) {
                    this.addedDiagnosis = diagnosis;
                }
            }
            //if(this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList)
        }

    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public actionIdForDemografic(): Guid {
        /* if (this._MedicalStuffPrescription.MasterAction != null) {
             if (typeof this._MedicalStuffPrescription.MasterAction === "string") {
                 return this._MedicalStuffPrescription.MasterAction;
             }
             else {
                 return this._MedicalStuffPrescription.MasterAction.ObjectID;
             }
         }*/
        if (this._MedicalStuffReportObject != null)
            return this._MedicalStuffReportObject.ObjectID;
        else
            return this._MedicalStuffPrescription.ObjectID;
    }

    public episodeForDiagnosis(): Guid {
        /* if (this._MedicalStuffPrescription.MasterAction != null) {
             if (typeof this._MedicalStuffPrescription.MasterAction === "string") {
                 return this._MedicalStuffPrescription.MasterAction;
             }
             else {
                 return this._MedicalStuffPrescription.MasterAction.ObjectID;
             }
         }*/
        if (this._MedicalStuffPrescription.Episode != null)
            return this._MedicalStuffPrescription.Episode.ObjectID;
        else
            return this._MedicalStuffReportObject.Episode.ObjectID;
    }

    public async PrescriptionListView_Click(val: any): Promise<void> {

        if (val != null) {
            let data = val.ObjectId.toString();
            this.ObjectID = new Guid(data);
            await this.load(MedicalStuffPrescriptionFormViewModel, this.MedicalStuffPrescriptionForm_DocumentUrl);
            //await this.MedulaErrorValidator();
        }
    }


    public PrescriptionListViewRowPrepared(row) {
        if (row.rowType == "data") {

            let rowValue = row.data.IsSendedMedula.toString();

            if (rowValue == "0") {
                this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', '#ffbebe');
                //row.rowElement.firstItem().css('background-color', '#ffbebe');
            }
            else {
                if (row.rowIndex % 2 == 0)
                    this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', '#fff');
                //row.rowElement.firstItem().css('background-color', '#fff');
                else
                    this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', '#f8f8f8');
                //row.rowElement.firstItem().css('background-color', '#f8f8f8');
            }

        }
    }

    public PrescriptionReportListViewRowPrepared(row) {
        if (row.rowType == "data") {

            let rowValue = row.data.IsSendedMedula;

            if (rowValue == false) {
                row.rowElement.firstItem().css('background-color', '#ffbebe');
            }
            else {
                if (row.rowIndex % 2 == 0)
                    row.rowElement.firstItem().css('background-color', '#fff');
                else
                    row.rowElement.firstItem().css('background-color', '#f8f8f8');
            }

        }
    }

    public LoadPrescriptionListView(prescriptionListView: Array<any>, canShowMessage: boolean): void {

        try {
            let itemList = new Array<any>();
            for (let prescriptionHistory of prescriptionListView) {

                let p = {
                    ObjectId: prescriptionHistory.ObjectID,
                    IsSendedMedula: (prescriptionHistory.IsSendedMedula == null) ? false : prescriptionHistory.IsSendedMedula,
                    SubItems:
                        [
                            { Text: (prescriptionHistory.PrescriptionNo !== null ? prescriptionHistory.PrescriptionNo : "....") },
                            { Text: (prescriptionHistory.RaporTakipNo !== null ? prescriptionHistory.RaporTakipNo : "....") },
                            { Text: (prescriptionHistory.ReportNo != null) ? prescriptionHistory.ReportNo : "...." },
                            { Text: (prescriptionHistory.ActionDate.toString("dd/mm/YYYY")) },
                            { Text: (prescriptionHistory.ProcedureDoctor !== null ? prescriptionHistory.ProcedureDoctor : "....") }
                        ]
                };


                itemList.push(p);
            }

            this.PrescriptionListView.Items = itemList;


        } catch (e) {
            ServiceLocator.MessageService.showError((<Error>e).message);
        }

    }
    public AddPrescriptionDiagnosis() {

    }
    public onReceteTakipNoChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffPrescription != null && this._MedicalStuffPrescription.ReceteTakipNo != event) {
                this._MedicalStuffPrescription.ReceteTakipNo = event;
            }
        }
    }
    public onPrescriptionDescriptionChanged(event): void {
        if (this._MedicalStuffPrescription != null && this._MedicalStuffPrescription.Description != event) {
            this._MedicalStuffPrescription.Description = event;
        }
    }
    public onDescriptionTypeChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffPrescription != null && this._MedicalStuffPrescription.DescriptionType !== event) {
                this._MedicalStuffPrescription.DescriptionType = event;
            }
        }
    }
    public onMedulaPrescriptionDescriptionChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffPrescription != null && this._MedicalStuffPrescription.MedulaDescription != event) {
                this._MedicalStuffPrescription.MedulaDescription = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (this._MedicalStuffPrescription != null && this._MedicalStuffPrescription.ProcedureDoctor != event) {
            this._MedicalStuffPrescription.ProcedureDoctor = event;

            if (this._MedicalStuffPrescription.PrescriptionDate != null && event != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedicalStuffPrescription.ProcedureDoctor.ObjectID, this._MedicalStuffPrescription.PrescriptionDate);
                if (a) {
                    this.messageService.showInfo(this._MedicalStuffPrescription.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedicalStuffPrescription.ProcedureDoctor = null;
                    }, 500);
                }
            }
        }
    }

    public async onPrescriptionDateChanged(event) {
        if (this._MedicalStuffPrescription != null && this._MedicalStuffPrescription.PrescriptionDate != event) {
            this._MedicalStuffPrescription.PrescriptionDate = event;

            if (this._MedicalStuffPrescription.ProcedureDoctor != null && event != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedicalStuffPrescription.ProcedureDoctor.ObjectID, this._MedicalStuffPrescription.PrescriptionDate);
                if (a) {
                    this.messageService.showInfo(this._MedicalStuffPrescription.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedicalStuffPrescription.ProcedureDoctor = null;
                    }, 500);
                }
            }
        }
    }

    comingViewModel(data) {
        this.medicalStuffPrescriptionFormViewModel.reportDiagnosisFormViewModel = data;
        /*if (this.medicalStuffPrescriptionFormViewModel.reportDiagnosisFormViewModel != null && this.medicalStuffPrescriptionFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList != null) {
            if (this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList == null)
                this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList = new Array<string>();


            else {
                if (this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList.length == 0) {
                    for (let diagnosis of data.ReportDiagnosisGridList) {
                        this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList.push(diagnosis.DiagnoseCode)
                    }
                }
                if (this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList != null && this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList.length > 0) {
                    for (let diagnosis of this.medicalStuffPrescriptionFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList) {
                        let code: string = null;
                        if (this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList != null && this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList.length > 0)
                            code = this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList.find(t => t === diagnosis.DiagnoseCode);
                        if (code == null) {
                            this.medicalStuffPrescriptionFormViewModel.diagnosisCodeList.push(diagnosis.DiagnoseCode);
                            this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.DiagnosisDetail += diagnosis.DiagnoseName + " ";
                        }
                    }
                }
            }
        }*/
    }

    public async DeletePrescriptionFromMedula() {
        let res: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Reçete Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? "), 1);
        if (res === "H")
            ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
        let user: ResUser = await UserHelper.CurrentResource;

        try {
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSendPanel();
            }
            /*await this.signService.showLoginModal();
            let preInput: PrepareSignedDeletePrescriptionContent_Input = new PrepareSignedDeletePrescriptionContent_Input();
            preInput.eReceteNo = this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.ReceteTakipNo;
            let signedPrescriptionOutput: string = await this.httpService.post<string>(this.PrepareSignedDeletePrescriptionContentUrl, preInput);
            let signedContent: string = await this.signService.signContent(signedPrescriptionOutput);
            let preSend: SendSignedDeletePrescriptionContent_Input = new SendSignedDeletePrescriptionContent_Input();
            preSend.singContent = signedContent;
            let sonuc: boolean = await this.httpService.post<boolean>(this.SendSignedDeletePrescriptionContentUrl, preSend);*/
            this.loadPanelOperation(true, "Reçete Meduladan Siliniyor Lütfen Bekleyiniz.");

            let result = <MedulaResult>await this.httpService.post('/api/MedicalStuffPrescriptionService/eReceteSil', this.medicalStuffPrescriptionFormViewModel);
            if (result != null) {
                if (result.SonucKodu == "9107") {
                    this.resetSavedPassword();
                }
                this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedulaDescription = result.SonucMesaji;
            }
            else
                this.messageService.showInfo("Rapor Servisinden Gelen Sonuç Mesajı : Servise ulaşılamamıştır !!!");
            /*if (sonuc === true) {
                ServiceLocator.MessageService.showInfo(this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.ReceteTakipNo + ' numaralı reçete silinmiştir.');
                //let res = <MedicalStuffReport.GetMedicalStuffReportListByID_Class>await this.httpService.post('/api/MedicalStuffReportService/GetEReportList', this.medicalStuffPrescriptionFormViewModel);
                //this.LoadReportListView(res., false);
            } else {
                ServiceLocator.MessageService.showError(this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.ReceteTakipNo + ' numaralı reçete iptal edilememiştir.');
            }*/
            this.loadPanelOperation(false, "");

        } catch (Exception) {
            this.loadPanelOperation(false, "");

        } finally {
            this.globalPrescriptionID = this._TTObject.ObjectID;
            await this.loadMedicalStuffPrescriptionByID(new Guid(this.globalPrescriptionID));
        }
    }

    public async MedulaPasswordSendPanel(): Promise<void> {
        let userNamePwdInput = new UsernamePwdInput();
        userNamePwdInput.GetMkysUsernameOnInit = false;
        userNamePwdInput.SessionStoragePwdName = 'MedulaPwd';
        userNamePwdInput.SessionStorageUsername = 'MedulaUsername';
        userNamePwdInput.Title = 'E-Rapor Kaydet';
        userNamePwdInput.GetUserUniqueRefNoOnInit = true;
        userNamePwdInput.doNotOpenSavedScreen = true;

        let userNamePwdResult = await UsernamePwdBox.Show(false, userNamePwdInput);
        if ((<ModalActionResult>userNamePwdResult).Result === DialogResult.OK) {
            let params = <UsernamePwdFormViewModel>(<ModalActionResult>userNamePwdResult).Param;
            this.medicalStuffPrescriptionFormViewModel.medulaUsername = params.userName;
            this.medicalStuffPrescriptionFormViewModel.medulaPassword = params.password;
        }
    }

    public resetSavedPassword() {
        let savePwd = window.sessionStorage.getItem('savePasswordForSession')
        if (savePwd == 'true') {
            window.sessionStorage.setItem('MedulaUsername', '');
            window.sessionStorage.setItem('MedulaPwd', '');
            window.sessionStorage.setItem('savePasswordForSession', 'false');
        }

    }

    public clearLastSelectedItem() {
        this.lastSelectedEprescription = null;
    }

    public async SendPrescriptionToMedula() {
        if (this.medicalStuffPrescriptionFormViewModel.ToState == MedicalStuffPrescription.MedicalStuffPrescriptionStates.New) {
            this.messageService.showInfo("Kaydedilmemiş Reçete bilgisi Medulaya gönderilemez! ");
            return;
        }
        if (this.medicalStuffPrescriptionFormViewModel.ToState == MedicalStuffPrescription.MedicalStuffPrescriptionStates.Cancelled) {
            this.messageService.showInfo("İptal edilmiş Reçete bilgisi Medulaya gönderilemez! ");
            return;
        }

        try {
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSendPanel();
            }
            /*let user: ResUser = await UserHelper.CurrentResource;
            await this.signService.showLoginModal();
            let willSend: PrepareSignedPrescriptionContent_Input = new PrepareSignedPrescriptionContent_Input();
            willSend.eReceteObjectID = this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.ObjectID;
            let signedPrescriptionOutput: string = await this.httpService.post<string>(this.PrepareSignedPrescriptionContentUrl, willSend);
            let signedContent: string = await this.signService.signContent(signedPrescriptionOutput);
            let preSend: SendSignedPrescriptionContent_Input = new SendSignedPrescriptionContent_Input();
            preSend.signContent = signedContent;*/
            this.loadPanelOperation(true, "Reçete Medulaya Gönderiliyor Lütfen Bekleyiniz.");

            let sonuc: MedulaResult = await this.httpService.post<MedulaResult>('/api/MedicalStuffPrescriptionService/eReceteGiris', this.medicalStuffPrescriptionFormViewModel);
            if (sonuc != null) {
                if (sonuc.SonucKodu == "0000") {
                    this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.ReceteTakipNo = sonuc.TakipNo;
                }

                if (sonuc.SonucKodu == "9107") {
                    this.resetSavedPassword();
                }
                this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedulaDescription = sonuc.SonucMesaji;
            }
            this.loadPanelOperation(false, "");


        } catch (Exception) {
            this.messageService.showError(Exception);
            this.loadPanelOperation(false, "");
        }
        this.globalPrescriptionID = this._TTObject.ObjectID;
        await this.loadMedicalStuffPrescriptionByID(new Guid(this.globalPrescriptionID));

    }

    public async SavePrescription() {
        this.PrescriptionListView.Items = new Array<any>();
        if (this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedicalStuffReport == null) {
            this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedicalStuffReport = this.MedicalStuffReportObject;
        }

        await this.ClientSidePostScript(null);
        await this.PostScript(null);
        let injector = ServiceLocator.Injector;
        let messageService: MessageService = injector.get(MessageService);
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        this.globalPrescriptionID = this._TTObject.ObjectID;
        this.ResultSetList = await httpService.post(this._DocumentServiceUrl, this._ViewModel);
        //this.globalPrescriptionID = this.ResultSetList.ObjectID;
        await this.AfterContextSavedScript(null);
        await this.loadMedicalStuffPrescriptionByID(new Guid(this.globalPrescriptionID));

        //await this.LoadReportListView(this.medicalStuffPrescriptionFormViewModel.MedicalStuffReportList, false);

    }
    PrintPrescription() {

    }
    CancelPrescription() {

    }
    clickRepScreen(event) {

    }
    MedulaPrescriptionListViewRowPrepared(event) {

    }
    MedulaPrescriptionListView_Click(event) {

    }


    public async loadMedicalStuffPrescriptionByID(objectID: Guid) {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";

            if (objectID != null) {
                fullApiUrl = this.MedicalStuffPrescriptionForm_DocumentUrl + '/?id=' + objectID;
            }
            else {
                fullApiUrl = `${this.MedicalStuffPrescriptionForm_DocumentUrl}/${Guid.Empty}`;
            }

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<MedicalStuffPrescriptionFormViewModel>(fullApiUrl, MedicalStuffPrescriptionFormViewModel);
            this._ViewModel = response;

            this.loadViewModel();
            this.loadOldPrescriptions();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MedicalStuffPrescription();
        this.medicalStuffPrescriptionFormViewModel = new MedicalStuffPrescriptionFormViewModel();
        this._ViewModel = this.medicalStuffPrescriptionFormViewModel;
        this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription = this._TTObject as MedicalStuffPrescription;
    }

    public loadViewModel() {
        let that = this;
        that.medicalStuffPrescriptionFormViewModel = this._ViewModel as MedicalStuffPrescriptionFormViewModel;
        that._TTObject = this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription;
        if (this.medicalStuffPrescriptionFormViewModel == null)
            this.medicalStuffPrescriptionFormViewModel = new MedicalStuffPrescriptionFormViewModel();
        if (this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription == null)
            this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription = new MedicalStuffPrescription();
        let procedureDoctorObjectID = that.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.medicalStuffPrescriptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.ProcedureDoctor = procedureDoctor;
            }
        }
        /*if (that.medicalStuffPrescriptionFormViewModel.MedicalStuffGridGridList == null || that.medicalStuffPrescriptionFormViewModel.MedicalStuffGridGridList.length == 0) {
            this.getReportMaterials();
        }*/

        that.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedicalStuff = that.medicalStuffPrescriptionFormViewModel.MedicalStuffGridGridList;
        for (let detailItem of that.medicalStuffPrescriptionFormViewModel.MedicalStuffGridGridList) {
            let medicalStuffDefObjectID = detailItem["MedicalStuffDef"];
            if (medicalStuffDefObjectID != null && (typeof medicalStuffDefObjectID === "string")) {
                let medicalStuffDef = that.medicalStuffPrescriptionFormViewModel.MedicalStuffDefinitions.find(o => o.ObjectID.toString() === medicalStuffDefObjectID.toString());
                if (medicalStuffDef) {
                    detailItem.MedicalStuffDef = medicalStuffDef;
                }
            }
            let medicalStuffGroupObjectID = detailItem["MedicalStuffGroup"];
            if (medicalStuffGroupObjectID != null && (typeof medicalStuffGroupObjectID === "string")) {
                let medicalStuffGroup = that.medicalStuffPrescriptionFormViewModel.MedicalStuffGroups.find(o => o.ObjectID.toString() === medicalStuffGroupObjectID.toString());
                if (medicalStuffGroup) {
                    detailItem.MedicalStuffGroup = medicalStuffGroup;
                }
            }
            let medicalStuffUsageTypeObjectID = detailItem["MedicalStuffUsageType"];
            if (medicalStuffUsageTypeObjectID != null && (typeof medicalStuffUsageTypeObjectID === "string")) {
                let medicalStuffUsageType = that.medicalStuffPrescriptionFormViewModel.MedicalStuffUsageTypes.find(o => o.ObjectID.toString() === medicalStuffUsageTypeObjectID.toString());
                if (medicalStuffUsageType) {
                    detailItem.MedicalStuffUsageType = medicalStuffUsageType;
                }
            }
            let medicalStuffPlaceOfUsageObjectID = detailItem["MedicalStuffPlaceOfUsage"];
            if (medicalStuffPlaceOfUsageObjectID != null && (typeof medicalStuffPlaceOfUsageObjectID === "string")) {
                let medicalStuffPlaceOfUsage = that.medicalStuffPrescriptionFormViewModel.MedicalStuffPlaceOfUsages.find(o => o.ObjectID.toString() === medicalStuffPlaceOfUsageObjectID.toString());
                if (medicalStuffPlaceOfUsage) {
                    detailItem.MedicalStuffPlaceOfUsage = medicalStuffPlaceOfUsage;
                }
            }

        }

        if (this.MedicalStuffReportStuffs != null && this.medicalStuffPrescriptionFormViewModel.MedicalStuffGridGridList != null) {
            that.medicalStuffPrescriptionFormViewModel.MedicalStuffGridGridList = this.MedicalStuffReportStuffs;
        }

        if (this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedicalStuffReport != null) {
            this.medicalStuffReport = this.medicalStuffPrescriptionFormViewModel._MedicalStuffPrescription.MedicalStuffReport;
            this.medulaReportNo = this.medicalStuffReport.RaporTakipNo;
        }
        this.LoadPrescriptionListView(this.medicalStuffPrescriptionFormViewModel.oldMedicalStuffPrescriptions, false);

    }
    async ngAfterViewInit() {
        this.loadViewModel();
    }

    async ngOnInit() {
        let that = this;
        await this.load();

        let enableMedulaPasswordEntrance: string = (await SystemParameterService.GetParameterValue('MEDULASIFREGIRISEKRANIAKTIF', 'FALSE'));
        if (enableMedulaPasswordEntrance === 'TRUE') {
            this.enableMedulaPasswordEntrance = true;
        }
        else {
            this.enableMedulaPasswordEntrance = false;
        }

        let showMainDiagnose: string = (await SystemParameterService.GetParameterValue('ANATANIGOSTER', 'TRUE'));
        if (showMainDiagnose === 'TRUE') {
            //this.showMainDiagnoseDefinitions = true;
            this.lstDiagnosisAddedToReport.ListFilterExpression = "ISLEAF=1";
        }

    }
    async ngOnChanges(changes: SimpleChanges) {
    }

    public getReadOnlyPrescription() {
        let that = this;
        if (that.Episode != null && that.MedicalStuffReportObject != null) {
            let episodeAction = that.MedicalStuffReportObject;
            let episode = that.Episode;
            this.httpService.get<Array<MedicalStuff>>(this._DocumentServiceUrl + "PreScriptReportDiagnosisForm?reportEpisodeAction=" + episodeAction.toString() + "&episode=" + episode.toString())
                .then(result => {
                    this.medicalStuffPrescriptionFormViewModel.MedicalStuffGridGridList = result as Array<MedicalStuff>;
                    this.sendPrescriptionViewModel.emit(this.medicalStuffPrescriptionFormViewModel);
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }
    public redirectProperties(): void {
        redirectProperty(this.PrescriptionDescription, "Rtf", this.__ttObject, "Description");
        redirectProperty(this.MedulaPrescriptionDescription, "Text", this.__ttObject, "MedulaDescription");
        redirectProperty(this.ReceteTakipNo, "Text", this.__ttObject, "ReceteTakipNo");
        redirectProperty(this.DescriptionType, 'Value', this.__ttObject, 'MedicalStuffPrescription.DescriptionType');
        redirectProperty(this.PrescriptionDate, "Value", this.__ttObject, "PrescriptionDate");

    }

    public initFormControls(): void {

        this.PrescriptionDate = new TTVisual.TTDateTimePicker();
        this.PrescriptionDate.Format = DateTimePickerFormat.Long;
        this.PrescriptionDate.Name = "PrescriptionDate";
        this.PrescriptionDate.TabIndex = 25;

        this.DescriptionType = new TTVisual.TTEnumComboBox();
        this.DescriptionType.DataMember = "MedicalStuffPrescription.DescriptionType";
        this.DescriptionType.DataTypeName = "DescriptionTypeEnum";
        this.DescriptionType.Name = "DescriptionType";
        this.DescriptionType.TabIndex = 20;
        this.DescriptionType.ReadOnly = false;
        this.DescriptionType.Enabled = true;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "DoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 26;

        this.MedulaPrescriptionDescription = new TTVisual.TTTextBox();
        this.MedulaPrescriptionDescription.Multiline = false;
        this.MedulaPrescriptionDescription.DataMember = "MedicalStuffPrescription.MedulaDescription";
        this.MedulaPrescriptionDescription.Name = "MedulaDescription";
        this.MedulaPrescriptionDescription.TabIndex = 0;
        this.MedulaPrescriptionDescription.ReadOnly = false;

        this.ReceteTakipNo = new TTVisual.TTTextBox();
        this.ReceteTakipNo.Multiline = false;
        this.ReceteTakipNo.DataMember = "MedicalStuffPrescription.ReceteTakipNo";
        this.ReceteTakipNo.Name = "MedulaDescription";
        this.ReceteTakipNo.TabIndex = 0;
        this.ReceteTakipNo.ReadOnly = true;

        this.StuffUsageType = new TTVisual.TTObjectListBox();
        this.StuffUsageType.ListDefName = "MedicalStuffUsageTypeListDef";
        this.StuffUsageType.DataMember = "MedicalStuffUsageType";
        this.StuffUsageType.Name = "StuffUsageType";

        this.PrescriptionDescription = new TTVisual.TTRichTextBoxControl();
        this.PrescriptionDescription.DataMember = "MedicalStuffPrescription.Description";
        this.PrescriptionDescription.Name = "PrescriptionDescription";
        this.PrescriptionDescription.TabIndex = 0;

        this.PrescriptionReportListView = <TTVisual.TTListView>{
            Visible: true,
            Height: 150,
            ReadOnly: false,
            BackColor: "black",
            ForeColor: "yellow",
            RowDisablePath: 'Disable',
            Font: {
                Bold: false,
                Italic: false,
                Name: "Impact",
                Size: 11,
                Strikeout: false,
                Underline: false
            },
            Columns: [
                //{ Text: "E-Reçete No" },
                { Text: i18n("M20855", "Rapor Takip No") },
                { Text: i18n("M20821", "Rapor No") },
                { Text: "Malzeme Adı" },
                { Text: i18n("M18587", "Malzeme Kodu") },
                { Text: "Başlangıç Tarihi", DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: "Bitiş Tarihi", DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: "Miktarı" },
                { Text: "K.Yeri" },
                { Text: "K.Periyodu" },
                { Text: "K.P.Birimi" }
            ]
        };
        this.PrescriptionReportListView.Name = "PrescriptionReportListView";
        this.PrescriptionReportListView.TabIndex = 0;
        //this.PrescriptionReportListView.Height = 150;
        this.PrescriptionReportListView.MultiSelect = false;


        this.PrescriptionListView = <TTVisual.TTListView>{
            Visible: true,
            Height: 150,
            ReadOnly: false,
            BackColor: "black",
            ForeColor: "yellow",
            RowDisablePath: 'Disable',
            Font: {
                Bold: false,
                Italic: false,
                Name: "Impact",
                Size: 11,
                Strikeout: false,
                Underline: false
            },
            Columns: [
                { Text: i18n("M13425", "Reçete No") },
                { Text: i18n("M20855", "Rapor Takip No") },
                { Text: i18n("M20821", "Rapor No") },
                { Text: i18n("M11637", "Reçete Tarihi"), DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: "Doktor" },
            ]
        };
        this.PrescriptionListView.Name = "PrescriptionListView";
        this.PrescriptionListView.TabIndex = 0;
        this.PrescriptionListView.Height = 100;
        this.PrescriptionListView.MultiSelect = false;

        this.lstDiagnosisAddedToReport = new TTVisual.TTObjectListBox();
        this.lstDiagnosisAddedToReport.ListDefName = "DiagnosisListDefinition";
        this.lstDiagnosisAddedToReport.Name = "lstDiagnosisAddedToReport";
        this.lstDiagnosisAddedToReport.TabIndex = 1;
        this.lstDiagnosisAddedToReport.ListFilterExpression = "ISLEAF=1"








        this.txtStuffName = new TTTextBoxColumn();
        this.txtStuffName.DataMember = "MedicalStuffDef.Name";
        this.txtStuffName.Name = "Name";
        this.txtStuffName.ToolTipText = i18n("M10514", "Adı");
        this.txtStuffName.Width = 300;
        this.txtStuffName.DisplayIndex = 1;
        this.txtStuffName.HeaderText = i18n("M18550", "Malzeme Adı");
        this.txtStuffName.ReadOnly = true;

        this.txtStuffCode = new TTTextBoxColumn();
        this.txtStuffCode.DataMember = "MedicalStuffDef.Code";
        this.txtStuffCode.Name = "Code";
        this.txtStuffCode.ToolTipText = "Kodu";
        this.txtStuffCode.Width = 100;
        this.txtStuffCode.DisplayIndex = 2;
        this.txtStuffCode.HeaderText = i18n("M18587", "Malzeme Kodu");
        this.txtStuffCode.ReadOnly = true;

        this.MedicalStuffGroup = new TTVisual.TTObjectListBox();
        this.MedicalStuffGroup.ListDefName = "MedicalStuffGroupListDef";
        this.MedicalStuffGroup.DataMember = "MedicalStuffGroup";
        this.MedicalStuffGroup.Name = "MedicalStuffGroup";
        this.MedicalStuffGroup.Width = 200;
        /*this.MedicalStuffGroup.DisplayIndex = 3;
        this.MedicalStuffGroup.HeaderText = i18n("M18577", "Malzeme Grubu");*/
        this.MedicalStuffGroup.ReadOnly = true;

        this.StuffAmount = new TTTextBoxColumn();
        this.StuffAmount.DataMember = "StuffAmount";
        this.StuffAmount.Name = "StuffAmount";
        this.StuffAmount.ToolTipText = i18n("M19030", "Miktar");
        this.StuffAmount.ReadOnly = false;
        this.StuffAmount.Width = 50;
        this.StuffAmount.DisplayIndex = 4;
        this.StuffAmount.HeaderText = i18n("M19030", "Miktar");
        this.StuffAmount.ReadOnly = true;

        this.cmbRaporSureTuru = new TTVisual.TTEnumComboBox();
        this.cmbRaporSureTuru.DataTypeName = "PeriodUnitTypeEnum";
        this.cmbRaporSureTuru.Required = true;
        this.cmbRaporSureTuru.BackColor = "#F0F0F0";
        this.cmbRaporSureTuru.Enabled = true;
        this.cmbRaporSureTuru.Name = "cmbRaporSureTuru";
        this.cmbRaporSureTuru.TabIndex = 4;
        this.cmbRaporSureTuru.ReadOnly = false;

        this.MedicalStuffPlaceOfUsage = new TTVisual.TTObjectListBox();
        this.MedicalStuffPlaceOfUsage.ListDefName = "MedicalStuffPlaceListDef";
        this.MedicalStuffPlaceOfUsage.DataMember = "MedicalStuffPlaceOfUsage";
        //this.MedicalStuffPlaceOfUsage.HeaderText = "Kullanım Yeri";
        this.MedicalStuffPlaceOfUsage.Name = "MedicalStuffPlaceOfUsage";
        this.MedicalStuffPlaceOfUsage.Width = 130;
        //this.MedicalStuffPlaceOfUsage.DisplayIndex = 5;
        this.MedicalStuffPlaceOfUsage.ReadOnly = true;

        this.PeriodUnit = new TTTextBoxColumn();
        this.PeriodUnit.DataMember = "PeriodUnit";
        this.PeriodUnit.Name = "PeriodUnit";
        this.PeriodUnit.ToolTipText = i18n("M17974", "Kullanım Periyodu");
        this.PeriodUnit.ReadOnly = false;
        this.PeriodUnit.Width = 100;
        this.PeriodUnit.DisplayIndex = 6;
        this.PeriodUnit.HeaderText = "K. Periyodu";
        this.PeriodUnit.ReadOnly = true;

        this.PeriodUnitType = new TTVisual.TTEnumComboBox();
        this.PeriodUnitType.DataTypeName = "PeriodUnitTypeEnum";
        this.PeriodUnitType.DataMember = "PeriodUnitType";
        /*this.PeriodUnitType.DisplayIndex = 6;
        this.PeriodUnitType.HeaderText = "K.P. Birimi";*/
        this.PeriodUnitType.Name = "PeriodUnitType";
        this.PeriodUnitType.ReadOnly = false;
        //this.PeriodUnitType.Width = 120;
        //this.PeriodUnitType.ReadOnly = true;

        this.StuffDescription = new TTTextBoxColumn();
        this.StuffDescription.DataMember = "StuffDescription";
        this.StuffDescription.Name = "StuffDescription";
        this.StuffDescription.ToolTipText = i18n("M10469", "Açıklama");
        this.StuffDescription.ReadOnly = false;
        this.StuffDescription.Width = 200;
        this.StuffDescription.DisplayIndex = 8;
        this.StuffDescription.HeaderText = i18n("M10469", "Açıklama");
        this.StuffDescription.ReadOnly = true;

        this.gridMedulaStuffColumns = [this.txtStuffCode, this.txtStuffName, this.MedicalStuffGroup, this.StuffAmount, this.MedicalStuffPlaceOfUsage, this.PeriodUnit, this.PeriodUnitType, this.StuffDescription];







    }


}
