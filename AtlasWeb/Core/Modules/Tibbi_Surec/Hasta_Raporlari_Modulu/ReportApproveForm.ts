
import { Component, OnInit, Input, EventEmitter, OnDestroy, ViewChild, ChangeDetectorRef, AfterViewInit } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { UsernamePwdInput, UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { UsernamePwdFormViewModel } from 'app/Fw/Components/UsernamePwdFormComponent';
import { ReportApproveListItem, ReportApproveListSearchCriteria, SendReportApproveModel, UserPropertiesModel } from './ReportApproveFormViewModel';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { DxDataGridComponent } from 'devextreme-angular';
import { IlacRaporuServis } from 'app/NebulaClient/Services/External/IlacRaporuServis';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { MedulaResult, eRaporOnayCevapDVO } from '../Tibbi_Malzeme_Modulu/MedicalStuffReportFormViewModel';
import { ComposeComponent } from 'app/Fw/Components/ComposeComponent';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import DevExpress from 'devextreme/bundles/dx.all';

@Component({
    selector: "ReportApproveForm",
    templateUrl: './ReportApproveForm.html',
    providers: [MessageService, { provide: IESignatureService, useClass: ESignatureService }, SystemApiService]

})
export class ReportApproveForm implements OnInit, OnDestroy, AfterViewInit {

    ngAfterViewInit() {
        this.dataGrid.instance.repaint();
    }

    _PatientID: Guid;
    _showReportPopup: boolean = false;
    _AdditionalReport: Object;
    _BaseAdditionalApplicationObjectID: Guid = Guid.Empty;


    constructor(protected httpService: NeHttpService,
        public systemApiService: SystemApiService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        public signService: IESignatureService,
        private changeDetectorRef: ChangeDetectorRef) {
        let element = document.getElementsByClassName('m-content')[0];
        this.popUpWidth = element.clientWidth;
        this.popUpHeight = element.clientHeight;
        let positionConfig: DevExpress.positionConfig = {

            my: "top",
            at: "top",
            offset: '0 60'
        }
        this.popUpPosition = positionConfig;
    }
    public ReportStartDate: Date = new Date();
    public ReportEndDate: Date = new Date();
    public ReportList: Array<any> = new Array<any>();
    public selectedReports = new Array<Guid>();
    public showLoadPanel = false;
    public LoadPanelMessage = "";
    public enableMedulaPasswordEntrance: boolean = false;
    public activeUserUniqueRefNo: string = "";
    public showOtherDoctorButtons: boolean = false;
    public reportTitle: string = "";
    public ReportVisible: boolean = false;
    public popUpHeight: any = "90%";
    public popUpWidth: any = "90%";
    public popUpPosition: any;
    public infoPopUpVisible: boolean = false;
    public reportDateInterval: number;
    @ViewChild('ReportGrid') dataGrid: DxDataGridComponent;
    @ViewChild('dynamicComponent') dynamicComponent: ComposeComponent;

    public ReportColumns = [

        {
            caption: i18n("M16650", "İstek Tarihi"),
            dataField: "Date",
            dataType: 'date',
            format: 'dd.MM.yyyy HH:mm',
            width: 'auto',
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,
            //sortOrder: 'asc',
            //sortIndex: 0,
            //cssClass: 'worklistGridCellFont'
        },
        {
            "caption": i18n("M16838", "Rapor Türü"),
            dataField: "ItemType",
            dataType: 'string',
            width: "auto",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        },
        {
            "caption": "Rapor",
            cellTemplate: "ShowReportTemplate",
            width: '50px',
            cssClass: "verticalAlignRepApproveForm",
            // cssClass: 'worklistGridCellFont',
        },
        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: "auto",
            minWidth: 150,
            cellTemplate: "PriorityCellTemplate",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true
        },
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "KabulNo",
            dataType: 'string',
            width: 'auto',
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true
        },
        {
            caption: i18n("M22514", "Hasta Kimlik No"),
            dataField: "UniqueRefno",
            dataType: 'string',
            width: 'auto',
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true
        },
        {
            caption: i18n("M27339", "Doktoru"),
            dataField: "DoctorName",
            dataType: 'string',
            width: "auto",
            cellTemplate: "ProcedureDoctorCellTemplate",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        },
        {
            caption: i18n("M27339", "2.Doktor"),
            dataField: "secondDoctorName",
            dataType: 'string',
            width: "auto",
            allowSorting: true,
            cssClass: "verticalAlignRepApproveForm",
            cellTemplate: "SecondDoctorCellTemplate",
            // cssClass: 'worklistGridCellFont',
        },
        {
            caption: i18n("M27339", "3.Doktor"),
            dataField: "thirdDoctorName",
            dataType: 'string',
            width: "auto",
            allowSorting: true,
            cssClass: "verticalAlignRepApproveForm",
            cellTemplate: "ThirdDoctorCellTemplate",
            // cssClass: 'worklistGridCellFont',
        },

        {
            "caption": i18n("M16838", "İşlem Durumu"),
            dataField: "currentStateText",
            dataType: 'string',
            width: "auto",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        },
        {
            "caption": i18n("M16838", "Gönderim Sonucu"),
            dataField: "StateName",
            dataType: 'string',
            width: "auto",
            cssClass: "verticalAlignRepApproveForm",
            allowSorting: true,
            // cssClass: 'worklistGridCellFont',
        }


    ];

    panelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public showInfoPopUp() {
        this.infoPopUpVisible = true;
    }

    async ngOnInit() {
        let enableMedulaPasswordEntrance: string = (await SystemParameterService.GetParameterValue('MEDULASIFREGIRISEKRANIAKTIF', 'FALSE'));
        if (enableMedulaPasswordEntrance === 'TRUE') {
            this.enableMedulaPasswordEntrance = true;
        }
        else {
            this.enableMedulaPasswordEntrance = false;
        }
        let reportDateInterval: string = (await SystemParameterService.GetParameterValue('RAPOREKRANIGUNARALIGI', '30'));
        this.reportDateInterval = +reportDateInterval;

        this.ReportStartDate = this.ReportStartDate.AddDays(-this.reportDateInterval);
        this.ListReports();
        this.GetActiveUserUniqueNo();
    }

    async select(value: any): Promise<void> {
        let selectedModel: ReportApproveListItem = value.data as ReportApproveListItem;
        if (selectedModel) {
            this.reportTitle = selectedModel.ItemType;
            this.openDynamicComponent(selectedModel.ObjectDefName, selectedModel.ObjectID);
        }
    }

    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.ReportVisible = true;
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam);
        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
            });
        }
    }

    public dynamicComponentClosed(e: any) {
        this.ListReports();
    }

    public async MedulaPasswordSignedApprovePanel(approveModel: SendReportApproveModel): Promise<void> {
        let userNamePwdInput = new UsernamePwdInput();
        userNamePwdInput.GetMkysUsernameOnInit = false;
        userNamePwdInput.SessionStoragePwdName = 'MedulaPwd';
        userNamePwdInput.SessionStorageUsername = 'MedulaUsername';
        userNamePwdInput.Title = 'Medula Şifre Ekranı';
        userNamePwdInput.GetUserUniqueRefNoOnInit = true;
        userNamePwdInput.doNotOpenSavedScreen = true;

        let userNamePwdResult = await UsernamePwdBox.Show(false, userNamePwdInput);
        if ((<ModalActionResult>userNamePwdResult).Result === DialogResult.OK) {
            let params = <UsernamePwdFormViewModel>(<ModalActionResult>userNamePwdResult).Param;
            approveModel.medulaUsername = params.userName;
            approveModel.medulaPassword = params.password;
        }
    }

    public async MedulaPasswordSignedReportApprovePanel(approveModel: SendReportApproveModel): Promise<void> {
        let userNamePwdInput = new UsernamePwdInput();
        userNamePwdInput.GetMkysUsernameOnInit = false;
        userNamePwdInput.SessionStoragePwdName = 'MedulaPwd';
        userNamePwdInput.SessionStorageUsername = 'MedulaUsername';
        userNamePwdInput.Title = 'Medula Şifre Ekranı';
        userNamePwdInput.GetUserUniqueRefNoOnInit = true;
        userNamePwdInput.doNotOpenSavedScreen = true;

        let userNamePwdResult = await UsernamePwdBox.Show(false, userNamePwdInput);
        if ((<ModalActionResult>userNamePwdResult).Result === DialogResult.OK) {
            let params = <UsernamePwdFormViewModel>(<ModalActionResult>userNamePwdResult).Param;
            approveModel.medulaUsername = params.userName;
            approveModel.medulaPassword = params.password;
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

    public ListReports() {
        let that = this;
        let searchCriteria: ReportApproveListSearchCriteria = new ReportApproveListSearchCriteria();
        searchCriteria.startDate = this.ReportStartDate;
        searchCriteria.endDate = this.ReportEndDate;
        this.panelOperation(true, "Raporlar Listeleniyor, Lütfen Bekleyin");
        let requestString = "api/ReportApproveFormService/getDoctorApproveReports";
        that.httpService.post<Array<ReportApproveListItem>>(requestString, searchCriteria)
            .then(response => {
                that.ReportList = response;
                that.panelOperation(false, "");
            })
            .catch(error => {
                that.panelOperation(false, "");
                that.messageService.showError(error);

            });
    }

    public async GetActiveUserUniqueNo() {
        let url = 'api/ReportApproveFormService/GetActiveUserProperties';
        this.httpService.post<UserPropertiesModel>(url, null, UserPropertiesModel).then(res => {
            this.activeUserUniqueRefNo = res.UniqueRefNo;
            this.showOtherDoctorButtons = res.hasRoleToSeeAllButtons;
        });
    }

    public async RaporOnay(event: ReportApproveListItem) {
        let eSignatureNeeded = false;

        if (event.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f") {
            eSignatureNeeded = true;
        }
        let approveModel: SendReportApproveModel = new SendReportApproveModel();
        if (this.enableMedulaPasswordEntrance == true) {
            await this.MedulaPasswordSignedReportApprovePanel(approveModel);
            if (String.isNullOrEmpty(approveModel.medulaUsername) || String.isNullOrEmpty(approveModel.medulaPassword)) {
                ServiceLocator.MessageService.showError("Kullanıcı Adınız veya şifreniz boş olamaz.!");
                return;
            } else if ((approveModel.medulaUsername.toString() != event.secondDoctorUniqueRefNo.toString()) && (approveModel.medulaUsername.toString() != event.thirdDoctorUniqueRefNo.toString())) {
                ServiceLocator.MessageService.showError("Girilen Kimlik Numarası Hekim Listesinde Bulunmamaktadır!");
                this.resetSavedPassword();
                return;
            }
            if (approveModel.medulaUsername.toString() == event.secondDoctorUniqueRefNo.toString() && event.secondDoctorApprovalStatus != true)
                approveModel.isSecondDoctorApprove = true;
            else if (approveModel.medulaUsername.toString() == event.thirdDoctorUniqueRefNo.toString() && event.thirdDoctorApprovalStatus != true)
                approveModel.isThirdDoctorApprove = true;
            else {
                ServiceLocator.MessageService.showError("Bu Rapor Girilen Kimlik Numarası ile Daha Önce Onaylanmıştır");
                return;
            }

        } else {
            if (this.activeUserUniqueRefNo.toString() == event.secondDoctorUniqueRefNo.toString() && event.secondDoctorApprovalStatus != true) {
                approveModel.isSecondDoctorApprove = true;
            } else if (this.activeUserUniqueRefNo.toString() == event.thirdDoctorUniqueRefNo.toString() && event.thirdDoctorApprovalStatus != true) {
                approveModel.isThirdDoctorApprove = true;
            } else {
                ServiceLocator.MessageService.showError("Hekim Listesinde Bulunmadığınız için veya Daha Önce Onayladığınız için Onay Yapamazsınız!");
                return;
            }
        }
        if (eSignatureNeeded == true)
            await this.signService.showLoginModal();
        approveModel.reportObjectID = event.ObjectID;
        this.panelOperation(true, i18n("M18851", "Rapor onaylanıyor, lütfen bekleyiniz."));

        if (event.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f") {
            await this.ApproveDrugReport(approveModel, event.ObjectID);
        } else if (event.ObjectDefID.toString() == "7e8b0668-9e8f-4075-8122-a829279a85d7") {
            await this.ApproveMedicalStuffReport(approveModel, event.ObjectID);
        }
        this.panelOperation(false, i18n("M18851", ""));

    }


    public async MedulayaGonder(event: ReportApproveListItem) {
        let eSignatureNeeded = false;

        if (event.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f") {
            eSignatureNeeded = true;
        }
        let approveModel: SendReportApproveModel = new SendReportApproveModel();
        if (this.enableMedulaPasswordEntrance == true) {
            await this.MedulaPasswordSignedReportApprovePanel(approveModel);
            if (String.isNullOrEmpty(approveModel.medulaUsername) || String.isNullOrEmpty(approveModel.medulaPassword)) {
                ServiceLocator.MessageService.showError("Kullanıcı Adınız veya şifreniz boş olamaz.!");
                return;
            } else if (approveModel.medulaUsername.toString() != event.procedureDoctorUniqueRefNo.toString()) {
                ServiceLocator.MessageService.showError("Diğer Hekim Yerine Medulaya Gönderim Yapamazsınız.!");
                this.resetSavedPassword();
                return;
            }
        }
        if (eSignatureNeeded == true)
            await this.signService.showLoginModal();
        approveModel.reportObjectID = event.ObjectID;
        this.panelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

        if (event.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f") {
            await this.SendDrugReportToMedula(approveModel, event.ObjectID);
        } else if (event.ObjectDefID.toString() == "7e8b0668-9e8f-4075-8122-a829279a85d7") {
            await this.SendMedicalStuffReportToMedula(approveModel, event.ObjectID);
        }
        this.panelOperation(false, i18n("M18851", ""));

    }


    public async SendDrugReportToMedula(approveModel: SendReportApproveModel, elementGuid: Guid) {

        try {

            let signedReportOutput: string = await this.httpService.post<string>('/api/ReportApproveFormService/PrepareSignedReportContent', approveModel);

            let signedContent: string = await this.signService.signContent(signedReportOutput);


            approveModel.signContent = signedContent
            let result = <IlacRaporuServis.imzaliEraporBashekimOnayCevapDVO>await this.httpService.post('/api/ReportApproveFormService/SendSignedReportContent', approveModel);
            if (result != null && result.sonucKodu === '0000') {
                this.changeRowAppearance(elementGuid, '#84e684', "Rapor Medulaya Başarıyla Gönderildi");

            }
            else if (result != null && result.sonucKodu == "9107") {
                this.resetSavedPassword();
            }
            else {
                if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                    this.changeRowAppearance(elementGuid, '#ffa5a5', result.uyariMesaji + " " + result.sonucMesaji);
                }
            }
            this.panelOperation(false, i18n("M18851", ""));

        }
        catch (ex) {
            console.log(ex);
            let a = ex;

            this.changeRowAppearance(elementGuid, '#ffa5a5', "Bir Hata ile Karşılaşıldı");

        }
        finally {

        }

    }

    public async SendMedicalStuffReportToMedula(approveModel: SendReportApproveModel, elementGuid: Guid) {
        let element = this.ReportList.find(x => x.ObjectID == elementGuid);
        try {

            let result = <MedulaResult>await this.httpService.post('/api/ReportApproveFormService/eRaporGiris', approveModel);
            if (result != null && result.SonucKodu === '0000') {
                this.changeRowAppearance(elementGuid, '#84e684', "Rapor Medulaya Başarıyla Gönderildi");

                if (element.secondDoctorUniqueRefNo != null) {
                    element.currentStateID = 2;
                    element.currentStateText = "Hekim Onayında";
                }
            } else if (result != null && result.SonucKodu == "9107") {
                this.resetSavedPassword();
            } else {
                if (!String.isNullOrEmpty(result.SonucKodu) || !String.isNullOrEmpty(result.SonucMesaji)) {
                    this.changeRowAppearance(elementGuid, '#ffa5a5', result.SonucKodu + " " + result.SonucMesaji);

                }
            }

        }
        catch (ex) {
            console.log(ex);
            let a = ex;
            this.changeRowAppearance(elementGuid, '#ffa5a5', "Bir Hata ile Karşılaşıldı");
        }
        finally {
            this.panelOperation(false, i18n("M18851", ""));

        }

    }


    public async ApproveDrugReport(approveModel: SendReportApproveModel, elementGuid: Guid) {
        let element = this.ReportList.find(x => x.ObjectID == elementGuid);
        try {

            let signedReportOutput: string = await this.httpService.post<string>('/api/ReportApproveFormService/PrepareSignedReportApproveContent', approveModel);

            let signedContent: string = await this.signService.signContent(signedReportOutput);


            approveModel.signContent = signedContent
            let result = <IlacRaporuServis.imzaliEraporOnayCevapDVO>await this.httpService.post('/api/ReportApproveFormService/SendSignedReportApproveContent', approveModel);
            if (result != null && result.sonucKodu === '0000') {
                this.changeRowAppearance(elementGuid, '#84e684', "Rapor Onaylandı");

                if (approveModel.isSecondDoctorApprove === true)
                    element.secondDoctorApprovalStatus = true;
                if (approveModel.isThirdDoctorApprove === true)
                    element.thirdDoctorApprovalStatus = true;

                if (element.secondDoctorApprovalStatus == true && element.thirdDoctorApprovalStatus == true) {
                    element.currentStateText = "Başhekim Onayında";
                    element.currentStateID = 3;
                }
            }
            else if (result != null && result.sonucKodu === 'RAP_0047') {
                this.changeRowAppearance(elementGuid, '#84e684', "Rapor Onaylandı");
            } else if (result != null && result.sonucKodu == "9107") {
                this.resetSavedPassword();
            }
            else {
                if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                    this.changeRowAppearance(elementGuid, '#ffa5a5', result.uyariMesaji + " " + result.sonucMesaji);
                }
            }
            this.panelOperation(false, i18n("M18851", ""));

        }
        catch (ex) {
            console.log(ex);
            let a = ex;
            this.changeRowAppearance(elementGuid, '#ffa5a5', "Bir Hata ile Karşılaşıldı");
        }
        finally {
            this.panelOperation(false, i18n("M18851", ""));

        }



    }
    public async ApproveMedicalStuffReport(approveModel: SendReportApproveModel, elementGuid: Guid) {
        let rowIndex = this.dataGrid.instance.getRowIndexByKey(elementGuid);
        let element = this.ReportList.find(x => x.ObjectID == elementGuid);

        try {

            let result = <eRaporOnayCevapDVO>await this.httpService.post('/api/ReportApproveFormService/Onay', approveModel);
            if (result != null && result.sonucKodu === '0000') {

                if (approveModel.isSecondDoctorApprove === true)
                    element.secondDoctorApprovalStatus = true;
                if (approveModel.isThirdDoctorApprove === true)
                    element.thirdDoctorApprovalStatus = true;

                if (element.secondDoctorApprovalStatus == true && element.thirdDoctorApprovalStatus == true) {
                    element.currentStateText = "Başhekim Onayında";
                    element.currentStateID = 3;
                }
                this.changeRowAppearance(elementGuid, '#84e684', "Rapor Onaylandı");

            } else if (result != null && result.sonucKodu == "9107") {
                this.resetSavedPassword();
            }
            else {
                if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                    this.changeRowAppearance(elementGuid, '#ffa5a5', result.uyariMesaji + " " + result.sonucMesaji);
                }
            }
        }
        catch (ex) {
            console.log(ex);
            let a = ex;
            this.changeRowAppearance(elementGuid, '#ffa5a5', "Bir Hata ile Karşılaşıldı");

        }
        finally {
            this.panelOperation(false, i18n("M18851", ""));

        }


    }

    public async ApproveOrSendSelectedReports() {
        let eSignatureNeeded = false;
        for (let j = 0; j < this.selectedReports.length; j++) {
            let element = this.ReportList.find(x => x.ObjectID == this.selectedReports[j]);
            if (element.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f") {
                eSignatureNeeded = true;
                break;
            }
        }
        let approveModel: SendReportApproveModel = new SendReportApproveModel();
        if (this.enableMedulaPasswordEntrance == true) {
            await this.MedulaPasswordSignedApprovePanel(approveModel);
            if (String.isNullOrEmpty(approveModel.medulaUsername) || String.isNullOrEmpty(approveModel.medulaPassword)) {
                ServiceLocator.MessageService.showError("Kullanıcı Adınız veya şifreniz boş olamaz.!");
                return;
            }
        }
        if (eSignatureNeeded == true)
            await this.signService.showLoginModal();
        this.panelOperation(true, i18n("M18851", "Gönderim & Onaylama yapılıyor, lütfen bekleyiniz."));

        try {
            for (let i = 0; i < this.selectedReports.length; i++) {
                let element = this.ReportList.find(x => x.ObjectID == this.selectedReports[i]);
                if (element.currentStateID.toString() == "1") {
                    if (this.enableMedulaPasswordEntrance == true) {
                        if (approveModel.medulaUsername.toString() != element.procedureDoctorUniqueRefNo.toString()) {
                            this.changeRowAppearance(this.selectedReports[i], '#ffa5a5', "Diğer Hekim Yerine Medulaya Gönderim Yapamazsınız.!");
                            this.resetSavedPassword();
                            continue;
                        }
                    }
                    approveModel.reportObjectID = element.ObjectID;

                    if (element.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f") {
                        await this.SendDrugReportToMedula(approveModel, element.ObjectID);
                    } else if (element.ObjectDefID.toString() == "7e8b0668-9e8f-4075-8122-a829279a85d7") {
                        await this.SendMedicalStuffReportToMedula(approveModel, element.ObjectID);
                    }
                } else if (element.currentStateID.toString() == "2") {
                    if (this.enableMedulaPasswordEntrance == true) {
                        if ((approveModel.medulaUsername.toString() != element.secondDoctorUniqueRefNo.toString()) && (approveModel.medulaUsername.toString() != element.thirdDoctorUniqueRefNo.toString())) {
                            this.changeRowAppearance(this.selectedReports[i], '#ffa5a5', "Girilen Kimlik Numarası Hekim Listesinde Bulunmamaktadır!");
                            this.resetSavedPassword();
                            continue;
                        }
                        if (approveModel.medulaUsername.toString() == element.secondDoctorUniqueRefNo.toString() && element.secondDoctorApprovalStatus != true)
                            approveModel.isSecondDoctorApprove = true;
                        else if (approveModel.medulaUsername.toString() == element.thirdDoctorUniqueRefNo.toString() && element.thirdDoctorApprovalStatus != true)
                            approveModel.isThirdDoctorApprove = true;
                        else {
                            this.changeRowAppearance(this.selectedReports[i], '#ffa5a5', "Bu Rapor Girilen Kimlik Numarası ile Daha Önce Onaylanmıştır");
                            continue;
                        }
                    } else {

                        if (this.activeUserUniqueRefNo.toString() == element.secondDoctorUniqueRefNo.toString() && element.secondDoctorApprovalStatus != true) {
                            approveModel.isSecondDoctorApprove = true;
                        } else if (this.activeUserUniqueRefNo.toString() == element.thirdDoctorUniqueRefNo.toString() && element.thirdDoctorApprovalStatus != true) {
                            approveModel.isThirdDoctorApprove = true;
                        } else {
                            this.changeRowAppearance(this.selectedReports[i], '#ffa5a5', "Hekim Listesinde Bulunmadığınız için veya Daha Önce Onayladığınız için Onay Yapamazsınız!");
                            continue;
                        }
                    }

                    approveModel.reportObjectID = element.ObjectID;

                    if (element.ObjectDefID.toString() == "c3d26685-4b86-4454-9884-1ae2c8bc932f") {
                        await this.ApproveDrugReport(approveModel, element.ObjectID);
                    } else if (element.ObjectDefID.toString() == "7e8b0668-9e8f-4075-8122-a829279a85d7") {
                        await this.ApproveMedicalStuffReport(approveModel, element.ObjectID);
                    }
                }
            }

            this.panelOperation(false, '');


        } catch{

        }
    }

    public changeRowAppearance(ObjectId, RowColor, RowText) {

        let rowIndex = this.dataGrid.instance.getRowIndexByKey(ObjectId);
        let element = this.ReportList.find(x => x.ObjectID.toString() == ObjectId.toString());
        element.RowColor = RowColor;
        element.StateName = RowText;
        this.changeDetectorRef.detectChanges();

        let rowElement = this.dataGrid.instance.getRowElement(rowIndex);
        if (rowElement != null && rowElement.length > 0) {

            rowElement[0].style.backgroundColor = element.RowColor;
        }
    }

    public onCellPrepared(e) {
        if (e.rowType === "data" && e.column.command === 'select') {
            if (e.data != null) {
                if (this.showOtherDoctorButtons != true) {
                    if (e.data.currentStateID === 1) {
                        if (e.data.procedureDoctorUniqueRefNo.toString() !== this.activeUserUniqueRefNo.toString()) {
                            //e.cellElement.find('.dx-select-checkbox').dxCheckBox("instance").option("disabled", true);
                            jQuery(e.cellElement).find('.dx-select-checkbox').addClass('hidden');

                            e.cellElement.off();
                        }
                    } else if (e.data.currentStateID === 2) {
                        if (e.data.secondDoctorUniqueRefNo.toString() === this.activeUserUniqueRefNo.toString() && e.data.secondDoctorApprovalStatus === true) {
                            //e.cellElement.find('.dx-select-checkbox').dxCheckBox("instance").option("disabled", true);
                            jQuery(e.cellElement).find('.dx-select-checkbox').addClass('hidden');
                            e.cellElement.off();
                        } else if (e.data.thirdDoctorUniqueRefNo.toString() === this.activeUserUniqueRefNo.toString() && e.data.thirdDoctorApprovalStatus === true) {
                            //e.cellElement.find('.dx-select-checkbox').dxCheckBox("instance").option("disabled", true);
                            jQuery(e.cellElement).find('.dx-select-checkbox').addClass('hidden');
                            e.cellElement.off();
                        } else if (e.data.secondDoctorUniqueRefNo.toString() !== this.activeUserUniqueRefNo.toString() && e.data.thirdDoctorUniqueRefNo.toString() !== this.activeUserUniqueRefNo.toString()) {
                            //e.cellElement.find('.dx-select-checkbox').dxCheckBox("instance").option("disabled", true);
                            jQuery(e.cellElement).find('.dx-select-checkbox').addClass('hidden');
                            e.cellElement.off();
                        }
                    } else {
                        //e.cellElement.find('.dx-select-checkbox').dxCheckBox("instance").option("disabled", true);
                        jQuery(e.cellElement).find('.dx-select-checkbox').addClass('hidden');
                        e.cellElement.off();
                    }
                } else {
                    if (e.data.currentStateID === 3) {
                        //e.cellElement.find('.dx-select-checkbox').dxCheckBox("instance").option("disabled", true);
                        jQuery(e.cellElement).find('.dx-select-checkbox').addClass('hidden');
                        e.cellElement.off();
                    }
                }
            }

        }
    }
    clientPostScript(state: String) {

    }

    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }


    openReport(reportData: DynamicReportParameters) {
        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = new ActiveIDsModel(null, null, null);
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, activeIDsModel);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "İşlem Raporu"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
}