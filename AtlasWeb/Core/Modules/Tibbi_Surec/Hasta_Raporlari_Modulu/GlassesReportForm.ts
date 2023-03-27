//$BCA179E5
import { Component, OnInit, AfterViewInit, NgZone, Input, ViewChildren, QueryList } from '@angular/core';
import { GlassesReportFormViewModel } from './GlassesReportFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm';
import { EpisodeService } from 'ObjectClassService/EpisodeService';
import { GlassesPrescriptionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { GlassesReport } from 'NebulaClient/Model/AtlasClientModel';
import { OptikReceteIslemleri } from 'NebulaClient/Services/External/OptikReceteIslemleri';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { HvlTextBox } from "Fw/Components/HvlTextBox";
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ModalStateService, ModalInfo, IModal, ModalActionResult } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { UsernamePwdFormViewModel } from 'app/Fw/Components/UsernamePwdFormComponent';
import { UsernamePwdBox, UsernamePwdInput } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
@Component({
    selector: 'GlassesReportForm',
    templateUrl: './GlassesReportForm.html',
    providers: [MessageService]
})

export class GlassesReportForm extends EpisodeActionForm implements OnInit, AfterViewInit, IModal {

    AddToHistoryDiagnosisGrid: TTVisual.ITTCheckBoxColumn;
    AddToHistorySecDiagnosisGrid: TTVisual.ITTCheckBoxColumn;
    AxLeftFar: TTVisual.ITTTextBox;
    AxLeftNear: TTVisual.ITTTextBox;
    AxRightFar: TTVisual.ITTTextBox;
    AxRightNear: TTVisual.ITTTextBox;
    btnReceteKaydet: TTVisual.ITTButton;
    btnReceteSil: TTVisual.ITTButton;
    cbxVitrumCloseReading: TTVisual.ITTCheckBox;
    cbxVitrumFar: TTVisual.ITTCheckBox;
    cbxVitrumNear: TTVisual.ITTCheckBox;
    CylLeftFar: TTVisual.ITTTextBox;
    CylLeftNear: TTVisual.ITTTextBox;
    CylRightFar: TTVisual.ITTTextBox;
    CylRightNear: TTVisual.ITTTextBox;
    DiagnoseDateDiagnosisGrid: TTVisual.ITTDateTimePickerColumn;
    DiagnoseDateSecDiagnosisGrid: TTVisual.ITTDateTimePickerColumn;
    DiagnoseDiagnosisGrid: TTVisual.ITTListBoxColumn;
    DiagnoseSecDiagnosisGrid: TTVisual.ITTListBoxColumn;
    DiagnosisDiagnosisGrid: TTVisual.ITTGrid;
    DiagnosisTypeDiagnosisGrid: TTVisual.ITTEnumComboBoxColumn;
    DiameterLeftFar: TTVisual.ITTTextBox;
    DiameterLeftNear: TTVisual.ITTTextBox;
    DiameterRightFar: TTVisual.ITTTextBox;
    DiameterRightNear: TTVisual.ITTTextBox;
    EntryActionTypeDiagnosisGrid: TTVisual.ITTEnumComboBoxColumn;
    EReceteNo: TTVisual.ITTTextBox;
    GlassColorLeftFar: TTVisual.ITTEnumComboBox;
    GlassColorLeftNear: TTVisual.ITTEnumComboBox;
    GlassColorRightFar: TTVisual.ITTEnumComboBox;
    GlassColorRightNear: TTVisual.ITTEnumComboBox;
    GlassLeftTypeFar: TTVisual.ITTEnumComboBox;
    GlassLeftTypeNear: TTVisual.ITTEnumComboBox;
    GlassRightTypeFar: TTVisual.ITTEnumComboBox;
    GlassRightTypeNear: TTVisual.ITTEnumComboBox;
    GradientLeftFar: TTVisual.ITTTextBox;
    GradientLeftNear: TTVisual.ITTTextBox;
    GradientRightFar: TTVisual.ITTTextBox;
    GradientRightNear: TTVisual.ITTTextBox;
    IsMainDiagnoseDiagnosisGrid: TTVisual.ITTCheckBoxColumn;
    IsMainDiagnoseSecDiagnosisGrid: TTVisual.ITTCheckBoxColumn;
    labelAxLeft: TTVisual.ITTLabel;
    labelAxRight: TTVisual.ITTLabel;
    labelCylLeft: TTVisual.ITTLabel;
    labelCylRight: TTVisual.ITTLabel;
    labelDiameterLeftFar: TTVisual.ITTLabel;
    labelDiameterRightFar: TTVisual.ITTLabel;
    labelEReceteNo: TTVisual.ITTLabel;
    labelGlassColorLeftFar: TTVisual.ITTLabel;
    labelGlassColorRightFar: TTVisual.ITTLabel;
    labelGlassRightTypeFar: TTVisual.ITTLabel;
    labelGlassRightTypeNear: TTVisual.ITTLabel;
    labelGradientLeftNear: TTVisual.ITTLabel;
    labelGradientRightFar: TTVisual.ITTLabel;
    labelLeft: TTVisual.ITTLabel;
    labelPatientGroup: TTVisual.ITTLabel;
    labelPrescriptionType: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelReasonForAdmission: TTVisual.ITTLabel;
    labelRecordID: TTVisual.ITTLabel;
    labelReportDate: TTVisual.ITTLabel;
    labelRight: TTVisual.ITTLabel;
    labelSonucAciklamasi: TTVisual.ITTLabel;
    labelSonucKodu: TTVisual.ITTLabel;
    labelSphLeft: TTVisual.ITTLabel;
    labelSphRight: TTVisual.ITTLabel;
    labelTeleskopikGlassesTypeRighRead: TTVisual.ITTLabel;
    labelTeleskopikGlassesTypeRightFar: TTVisual.ITTLabel;
    labelVitrum: TTVisual.ITTLabel;
    PatientGroup: TTVisual.ITTTextBox;
    PrescriptionType: TTVisual.ITTEnumComboBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    ReasonForAdmission: TTVisual.ITTTextBox;
    RecordID: TTVisual.ITTTextBox;
    ReportDate: TTVisual.ITTDateTimePicker;
    ResponsibleUserDiagnosisGrid: TTVisual.ITTListBoxColumn;
    ResponsibleUserSecDiagnosisGrid: TTVisual.ITTListBoxColumn;
    SecDiagnosis: TTVisual.ITTGrid;
    SonucAciklamasi: TTVisual.ITTTextBox;
    SonucKodu: TTVisual.ITTTextBox;
    SphLeftFar: TTVisual.ITTTextBox;
    SphLeftNear: TTVisual.ITTTextBox;
    SphRightFar: TTVisual.ITTTextBox;
    SphRightNear: TTVisual.ITTTextBox;
    TeleskopikGlassesTypeLeftFar: TTVisual.ITTEnumComboBox;
    TeleskopikGlassesTypeLeftNear: TTVisual.ITTEnumComboBox;
    TeleskopikGlassesTypeLeftRead: TTVisual.ITTEnumComboBox;
    TeleskopikGlassesTypeRighNear: TTVisual.ITTEnumComboBox;
    TeleskopikGlassesTypeRighRead: TTVisual.ITTEnumComboBox;
    TeleskopikGlassesTypeRightFar: TTVisual.ITTEnumComboBox;
    TemporaryLens: TTVisual.ITTCheckBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;

    MedulaOldGlassesReports: any;
    selectedOldGlassesReport: OptikReceteIslemleri.receteTesisDVO;
    medulaReceteMessage: string = null;
    showMedulaResultPopupVisible: boolean = false;
    selectedOldGlassesReportInfoPopupVisible: boolean = false;
    selectedOldGlassesReportInfoPopupVisibleTwoGlasses: boolean = false;
    oldGlassesReportType: number = null;
    selectedOldInfo: OptikReceteIslemleri.receteTesisDVO;
    selectedOldGlassesInfoPopupHeight: string = "300px";
    @ViewChildren(HvlTextBox) TextBoxes: QueryList<HvlTextBox>;

    public enableMedulaPasswordEntrance = false;
    public DiagnosisDiagnosisGridColumns = [];
    public SecDiagnosisColumns = [];
    public glassesReportFormViewModel: GlassesReportFormViewModel = new GlassesReportFormViewModel();
    public get _GlassesReport(): GlassesReport {
        return this._TTObject as GlassesReport;
    }
    public GlassesReportForm_DocumentUrl: string = '/api/GlassesReportService/GlassesReportForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone, protected modalStateService: ModalStateService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.GlassesReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public _inputParam: Object;
    setInputParam(value: Object) {
        this._inputParam = value;
    }

    protected _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    public _glassesReport: GlassesReport;
    @Input() set glassesReport(value: GlassesReport) {
        this._glassesReport = value;
        if (this._glassesReport) {
            this.glassesReportFormViewModel._GlassesReport = this._glassesReport;
        }
    }
    get glassesReport(): GlassesReport {
        return this._glassesReport;
    }


    protected async save() {
        super.save();
        //this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.glassesReportFormViewModel._GlassesReport.ObjectID);
    }

    // ***** Method declarations start *****

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
            this.glassesReportFormViewModel.medulaUsername = params.userName;
            this.glassesReportFormViewModel.medulaPassword = params.password;
        }
    }

    public async btnReceteKaydet_Click(): Promise<void> {
        if (this.checkFields()) {
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSendPanel();
                if(String.isNullOrEmpty(this.glassesReportFormViewModel.medulaUsername) || String.isNullOrEmpty(this.glassesReportFormViewModel.medulaPassword)){
                    ServiceLocator.MessageService.showError("Kullanıcı adı veya şifreniz boş olamaz!");
                    return;
                }
            }
            this.glassesReportFormViewModel.stateToComplete = true;
            this.glassesReportFormViewModel.stateToNew = false;
            let result = <BaseViewModel>await this.httpService.post('/api/GlassesReportService/GlassesReportForm', this.glassesReportFormViewModel);
            if (result != null) {
                //if (result.UpdatedObjects != null && result.UpdatedObjects.lenght > 0)
                this.AfterContextSavedScript(null);
            }
            let tempGlassesReport = result.UpdatedObjects[0] as GlassesReport;
            if (tempGlassesReport.EReceteNo != null){
                this.glassesReportFormViewModel._GlassesReport.EReceteNo = tempGlassesReport.EReceteNo;
            }
            if (tempGlassesReport.SonucKodu != null){
                this.glassesReportFormViewModel._GlassesReport.SonucKodu = tempGlassesReport.SonucKodu;
            }
            if (tempGlassesReport.SonucAciklamasi != null){
                this.glassesReportFormViewModel._GlassesReport.SonucAciklamasi = tempGlassesReport.SonucAciklamasi;
            }
        }
        this.glassesReportFormViewModel.stateToComplete = false;
        this.glassesReportFormViewModel.stateToNew = false;
        this.modalStateService.callActionExecuted(DialogResult.Yes, this._modalInfo.ContainerItemID, this.glassesReportFormViewModel._GlassesReport);

        /*
                if(this.checkFields()){
                    this._ViewModel.stateToComplete = true;
                    this._ViewModel.stateToNew = false;
                    this.save();
                    this.modalStateService.callActionExecuted(DialogResult.OK,new Guid(),this.glassesReportFormViewModel._GlassesReport,null,false);
                }*/
    }
    /*protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        //this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("GLASSESREPORT", this.glassesReportFormViewModel._GlassesReport.ObjectID, null);
        this.loadViewModel();
    }*/

    async searchClick() {
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
            if(String.isNullOrEmpty(this.glassesReportFormViewModel.medulaUsername) || String.isNullOrEmpty(this.glassesReportFormViewModel.medulaPassword)){
                ServiceLocator.MessageService.showError("Kullanıcı adı veya şifreniz boş olamaz!");
                return;
            }
        }
        this.httpService.get<Array<any>>(`api/GlassesReportService/GetOldMedulaGlassesReports?MasterAction=${this.glassesReportFormViewModel._GlassesReport.MasterAction}&medulaUsername=${this.glassesReportFormViewModel.medulaUsername}&medulaPassword=${this.glassesReportFormViewModel.medulaPassword}`).then(result => {
            this.MedulaOldGlassesReports = result;
        });
    }

    async deleteClick() {
        if(this.selectedOldGlassesReport != null){
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSendPanel();
                if(String.isNullOrEmpty(this.glassesReportFormViewModel.medulaUsername) || String.isNullOrEmpty(this.glassesReportFormViewModel.medulaPassword)){
                    ServiceLocator.MessageService.showError("Kullanıcı adı veya şifreniz boş olamaz!");
                    return;
                }
            }
            let eReceteNo: string = this.selectedOldGlassesReport[0].eReceteNo;
            this.httpService.get<Array<any>>(`api/GlassesReportService/RemoveOldGlassesReport?oldGlassesReportNo=${eReceteNo}&_GlassesReport=${this.glassesReportFormViewModel._GlassesReport.ObjectID}&medulaUsername=${this.glassesReportFormViewModel.medulaUsername}&medulaPassword=${this.glassesReportFormViewModel.medulaPassword}`).then(result => {
                this.medulaReceteMessage = result.toString();
                this.showMedulaResultPopupVisible = true;
            });
        }
        

        this.searchClick();

    }

    public grdOldGlassesReportClick(event: any): void {
        this.selectedOldGlassesInfoPopupHeight = "300px";
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 250)) {
            this.selectedOldInfo = this.selectedOldGlassesReport[0];
            if (this.selectedOldInfo.receteTipi == "Normal") {
                if (this.selectedOldInfo.gozlukTuru1 != null) {
                    this.oldGlassesReportType = 1;
                }
                if (this.selectedOldInfo.gozlukTuru2 != null) {
                    this.oldGlassesReportType = 5;
                }
            } else if (this.selectedOldInfo.receteTipi == "Keratakonuslens") {
                if (this.selectedOldInfo.gozlukTuru1 != null) {
                    this.oldGlassesReportType = 2;
                }
            } else if (this.selectedOldInfo.receteTipi == "Lens") {
                if (this.selectedOldInfo.gozlukTuru1 != null) {
                    this.oldGlassesReportType = 3;
                }
            } else {
                this.oldGlassesReportType = 4;
            }
            if (this.oldGlassesReportType == 5) {
                this.selectedOldGlassesReportInfoPopupVisible = false;
                this.selectedOldGlassesReportInfoPopupVisibleTwoGlasses = true;
            } else {
                this.selectedOldGlassesReportInfoPopupVisible = true;
                this.selectedOldGlassesReportInfoPopupVisibleTwoGlasses = false;
            }
        }
    }

    public async btnReceteSil_Click(): Promise<void> {
        if (this._GlassesReport.EReceteNo != null) {
            if (this.enableMedulaPasswordEntrance) {
                await this.MedulaPasswordSendPanel();
                if(String.isNullOrEmpty(this.glassesReportFormViewModel.medulaUsername) || String.isNullOrEmpty(this.glassesReportFormViewModel.medulaPassword)){
                    ServiceLocator.MessageService.showError("Kullanıcı adı veya şifreniz boş olamaz!");
                    return;
                }
            }
            this.glassesReportFormViewModel.stateToComplete = false;
            this.glassesReportFormViewModel.stateToNew = true;
            let result = <BaseViewModel>await this.httpService.post('/api/GlassesReportService/GlassesReportForm', this.glassesReportFormViewModel);
        } else {
            TTVisual.InfoBox.Alert(i18n("M21871", "Silinecek E-Reçete Bulunamadı.!"));
        }
        this.glassesReportFormViewModel.stateToComplete = false;
        this.glassesReportFormViewModel.stateToNew = false;
        this.modalStateService.callActionExecuted(DialogResult.Abort, this._modalInfo.ContainerItemID, this.glassesReportFormViewModel._GlassesReport);
    }


    public checkFields(): boolean {
        if (this._GlassesReport.VitrumFar != true && this._GlassesReport.VitrumNear != true && this._GlassesReport.VitrumCloseReading != true) {
            TTVisual.InfoBox.Alert(i18n("M23824", "Uzak, Yakın ya da Yakın Okuma Kepi alanlarından en az birini seçiniz."));
            return false;
        }
        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal) {
            if (this._GlassesReport.VitrumFar == true && (this._GlassesReport.SphRightFar == null || this._GlassesReport.CylRightFar == null || this._GlassesReport.AxRightFar == null || this._GlassesReport.GlassColorRightFar == null || this._GlassesReport.GlassRightTypeFar == null)) {
                if (this._GlassesReport.SphRightFar == null) {
                    this._GlassesReport.SphRightFar = "0";
                }
                if (this._GlassesReport.CylRightFar == null) {
                    this._GlassesReport.CylRightFar = "0";
                }
                if (this._GlassesReport.AxRightFar == null) {
                    this._GlassesReport.AxRightFar = "0";
                }
                /*if (this._GlassesReport.GlassRightTypeFar == null) {
                    TTVisual.InfoBox.Alert("Sağ Gözlük Tipi alanı boş geçilemez!");
                    return false;
                }
                if (this._GlassesReport.GlassColorRightFar == null) {
                    TTVisual.InfoBox.Alert("Sağ Cam Rengi alanı boş geçilemez!");
                    return false;
                }*/
            }
            if (this._GlassesReport.VitrumFar == true && (this._GlassesReport.SphLeftFar == null || this._GlassesReport.CylLeftFar == null || this._GlassesReport.AxLeftFar == null || this._GlassesReport.GlassColorLeftFar == null || this._GlassesReport.GlassLeftTypeFar == null)) {
                if (this._GlassesReport.SphLeftFar == null) {
                    this._GlassesReport.SphLeftFar = "0";
                }
                if (this._GlassesReport.CylLeftFar == null) {
                    this._GlassesReport.CylLeftFar = "0";
                }
                if (this._GlassesReport.AxLeftFar == null) {
                    this._GlassesReport.AxLeftFar = "0";
                }
            }
            if (this._GlassesReport.VitrumFar == true && (this._GlassesReport.GlassColorLeftFar == null || this._GlassesReport.GlassLeftTypeFar == null)) {
                if (this._GlassesReport.GlassLeftTypeFar == null) {
                    TTVisual.InfoBox.Alert("Uzak Gözlük Tipi alanı boş geçilemez!");
                    return false;
                }
                if (this._GlassesReport.GlassColorLeftFar == null) {
                    TTVisual.InfoBox.Alert("Uzak Gözlük Cam Rengi alanı boş geçilemez!");
                    return false;
                }
            }
            if (this._GlassesReport.VitrumNear == true && (this._GlassesReport.SphRightNear == null || this._GlassesReport.CylRightNear == null || this._GlassesReport.AxRightNear == null || this._GlassesReport.GlassColorRightNear == null || this._GlassesReport.GlassRightTypeNear == null)) {
                if (this._GlassesReport.SphRightNear == null) {
                    this._GlassesReport.SphRightNear = "0";
                }
                if (this._GlassesReport.CylRightNear == null) {
                    this._GlassesReport.CylRightNear = "0";
                }
                if (this._GlassesReport.AxRightNear == null) {
                    this._GlassesReport.AxRightNear = "0";
                }
                /*if (this._GlassesReport.GlassRightTypeNear == null) {
                    TTVisual.InfoBox.Alert("Sağ Gözlük Tipi alanı boş geçilemez!");
                    return false;
                }
                if (this._GlassesReport.GlassColorRightNear == null) {
                    TTVisual.InfoBox.Alert("Sağ Cam Rengi alanı boş geçilemez!");
                    return false;
                }*/
            }

            if (this._GlassesReport.VitrumNear == true && (this._GlassesReport.SphLeftNear == null || this._GlassesReport.CylLeftNear == null || this._GlassesReport.AxLeftNear == null || this._GlassesReport.GlassColorLeftNear == null || this._GlassesReport.GlassLeftTypeNear == null)) {
                if (this._GlassesReport.SphLeftNear == null) {
                    this._GlassesReport.SphLeftNear = "0";
                }
                if (this._GlassesReport.CylLeftNear == null) {
                    this._GlassesReport.CylLeftNear = "0";
                }
                if (this._GlassesReport.AxLeftNear == null) {
                    this._GlassesReport.AxLeftNear = "0";
                }

            }
            if (this._GlassesReport.VitrumNear == true && (this._GlassesReport.GlassColorLeftNear == null || this._GlassesReport.GlassLeftTypeNear == null)) {
                if (this._GlassesReport.GlassColorLeftNear == null) {
                    TTVisual.InfoBox.Alert("Yakın Gözlük Tipi alanı boş geçilemez!");
                    return false;
                }
                if (this._GlassesReport.GlassLeftTypeNear == null) {
                    TTVisual.InfoBox.Alert("Yakın Gözlük Cam Rengi alanı boş geçilemez!");
                    return false;
                }
            }
        }
        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens) {
            if (this._GlassesReport.VitrumFar == true && (this._GlassesReport.SphRightFar == null || this._GlassesReport.CylRightFar == null || this._GlassesReport.AxRightFar == null || this._GlassesReport.DiameterRightFar == null || this._GlassesReport.GradientRightFar == null)) {
                if (this._GlassesReport.SphRightFar == null) {
                    this._GlassesReport.SphRightFar = "0";
                }
                if (this._GlassesReport.CylRightFar == null) {
                    this._GlassesReport.CylRightFar = "0";
                }
                if (this._GlassesReport.AxRightFar == null) {
                    this._GlassesReport.AxRightFar = "0";
                }
                if (this._GlassesReport.DiameterRightFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21133", "Sağ Eğim alanı boş geçilemez!"));
                    return false;
                }
                if (this._GlassesReport.GradientRightFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21132", "Sağ Çap alanı boş geçilemez!"));
                    return false;
                }
            }
            if (this._GlassesReport.VitrumFar == true && (this._GlassesReport.SphLeftFar == null || this._GlassesReport.CylLeftFar == null || this._GlassesReport.AxLeftFar == null || this._GlassesReport.DiameterLeftFar == null || this._GlassesReport.GradientLeftFar == null)) {
                if (this._GlassesReport.SphLeftFar == null) {
                    this._GlassesReport.SphLeftFar = "0";
                }
                if (this._GlassesReport.CylLeftFar == null) {
                    this._GlassesReport.CylLeftFar = "0";
                }
                if (this._GlassesReport.AxLeftFar == null) {
                    this._GlassesReport.AxLeftFar = "0";
                }
                if (this._GlassesReport.DiameterLeftFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21133", "Sağ Eğim alanı boş geçilemez!"));
                    return false;
                }
                if (this._GlassesReport.GradientLeftFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21132", "Sağ Çap alanı boş geçilemez!"));
                    return false;
                }
            }
        }
        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
            if (this._GlassesReport.VitrumFar == true && (this._GlassesReport.SphRightFar == null || this._GlassesReport.GradientRightFar == null)) {
                if (this._GlassesReport.SphRightFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21139", "Sağ Sferik alanı boş geçilemez!"));
                    return false;
                }
                if (this._GlassesReport.GradientRightFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21132", "Sağ Çap alanı boş geçilemez!"));
                    return false;
                }
            }

            if (this._GlassesReport.VitrumFar == true && (this._GlassesReport.SphLeftFar == null || this._GlassesReport.GradientLeftFar == null)) {
                if (this._GlassesReport.SphLeftFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21139", "Sağ Sferik alanı boş geçilemez!"));
                    return false;
                }
                if (this._GlassesReport.GradientLeftFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21132", "Sağ Çap alanı boş geçilemez!"));
                    return false;
                }
            }
        }

        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
            if (this._GlassesReport.VitrumFar == true && this._GlassesReport.TeleskopikGlassesTypeRightFar == null) {
                if (this._GlassesReport.TeleskopikGlassesTypeRightFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M21147", "Sağ Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    return false;
                }
            }

            if (this._GlassesReport.VitrumFar == true && this._GlassesReport.TeleskopikGlassesTypeLeftFar == null) {
                if (this._GlassesReport.TeleskopikGlassesTypeLeftFar == null) {
                    TTVisual.InfoBox.Alert(i18n("M22017", "Sol Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    return false;
                }
            }

            if (this._GlassesReport.VitrumNear == true && this._GlassesReport.TeleskopikGlassesTypeRighNear == null) {
                if (this._GlassesReport.TeleskopikGlassesTypeRighNear == null) {
                    TTVisual.InfoBox.Alert(i18n("M21147", "Sağ Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    return false;
                }
            }

            if (this._GlassesReport.VitrumNear == true && this._GlassesReport.TeleskopikGlassesTypeLeftNear == null) {
                if (this._GlassesReport.TeleskopikGlassesTypeLeftNear == null) {
                    TTVisual.InfoBox.Alert(i18n("M22017", "Sol Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    return false;
                }
            }

            if (this._GlassesReport.VitrumCloseReading == true && this._GlassesReport.TeleskopikGlassesTypeRighRead == null) {
                if (this._GlassesReport.TeleskopikGlassesTypeRighRead == null) {
                    TTVisual.InfoBox.Alert(i18n("M21147", "Sağ Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    return false;
                }
            }

            if (this._GlassesReport.VitrumCloseReading == true && this._GlassesReport.TeleskopikGlassesTypeLeftRead == null) {
                if (this._GlassesReport.TeleskopikGlassesTypeLeftRead == null) {
                    TTVisual.InfoBox.Alert(i18n("M22017", "Sol Teleskopik Gözlük Tipi alanı boş geçilemez!"));
                    return false;
                }
            }
        }
        return true;
    }

    public changeBackgroundColorsForFarGlass(): void {
        if (this._GlassesReport.VitrumFar == true) {
            if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal) {
                this.SphRightFar.BackColor = "#fffddd";
                this.SphLeftFar.BackColor = "#fffddd";
                this.CylRightFar.BackColor = "#fffddd";
                this.CylLeftFar.BackColor = "#fffddd";
                this.AxRightFar.BackColor = "#fffddd";
                this.AxLeftFar.BackColor = "#fffddd";
                this.GlassRightTypeFar.BackColor = "#fffddd";
                this.GlassLeftTypeFar.BackColor = "#fffddd";
                this.GlassColorRightFar.BackColor = "#fffddd";
                this.GlassColorLeftFar.BackColor = "#fffddd";
            }
            else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens) {
                this.SphRightFar.BackColor = "#fffddd";
                this.SphLeftFar.BackColor = "#fffddd";
                this.CylRightFar.BackColor = "#fffddd";
                this.CylLeftFar.BackColor = "#fffddd";
                this.AxRightFar.BackColor = "#fffddd";
                this.AxLeftFar.BackColor = "#fffddd";
                this.DiameterRightFar.BackColor = "#fffddd";
                this.DiameterLeftFar.BackColor = "#fffddd";
                this.GradientRightFar.BackColor = "#fffddd";
                this.GradientLeftFar.BackColor = "#fffddd";
            }
            else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
                this.SphRightFar.BackColor = "#fffddd";
                this.SphLeftFar.BackColor = "#fffddd";
                this.CylRightFar.BackColor = "#fffddd";
                this.CylLeftFar.BackColor = "#fffddd";
                this.AxRightFar.BackColor = "#fffddd";
                this.AxLeftFar.BackColor = "#fffddd";
                this.DiameterRightFar.BackColor = "#fffddd";
                this.DiameterLeftFar.BackColor = "#fffddd";
                this.GradientRightFar.BackColor = "#fffddd";
                this.GradientLeftFar.BackColor = "#fffddd";
            }
            else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
                this.TeleskopikGlassesTypeRightFar.BackColor = "#fffddd";
                this.TeleskopikGlassesTypeLeftFar.BackColor = "#fffddd";
            }
        }
        else {
            this.SphRightFar.BackColor = "#ffffff";
            this.SphLeftFar.BackColor = "#ffffff";
            this.CylRightFar.BackColor = "#ffffff";
            this.CylLeftFar.BackColor = "#ffffff";
            this.AxRightFar.BackColor = "#ffffff";
            this.AxLeftFar.BackColor = "#ffffff";
            this.DiameterRightFar.BackColor = "#ffffff";
            this.DiameterLeftFar.BackColor = "#ffffff";
            this.GradientRightFar.BackColor = "#ffffff";
            this.GradientLeftFar.BackColor = "#ffffff";
            this.GlassRightTypeFar.BackColor = "#ffffff";
            this.GlassLeftTypeFar.BackColor = "#ffffff";
            this.GlassColorRightFar.BackColor = "#ffffff";
            this.GlassColorLeftFar.BackColor = "#ffffff";
            this.TeleskopikGlassesTypeRightFar.BackColor = "#ffffff";
            this.TeleskopikGlassesTypeLeftFar.BackColor = "#ffffff";
        }
    }
    public changeBackgroundColorsForNearGlass(): void {
        if (this._GlassesReport.VitrumNear == true) {
            if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal) {
                this.SphRightNear.BackColor = "#fffddd";
                this.SphLeftNear.BackColor = "#fffddd";
                this.CylRightNear.BackColor = "#fffddd";
                this.CylLeftNear.BackColor = "#fffddd";
                this.AxRightNear.BackColor = "#fffddd";
                this.AxLeftNear.BackColor = "#fffddd";
                this.GlassRightTypeNear.BackColor = "#fffddd";
                this.GlassLeftTypeNear.BackColor = "#fffddd";
                this.GlassColorRightNear.BackColor = "#fffddd";
                this.GlassColorLeftNear.BackColor = "#fffddd";
            }
            else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens) {
                this.SphRightNear.BackColor = "#fffddd";
                this.SphLeftNear.BackColor = "#fffddd";
                this.CylRightNear.BackColor = "#fffddd";
                this.CylLeftNear.BackColor = "#fffddd";
                this.AxRightNear.BackColor = "#fffddd";
                this.AxLeftNear.BackColor = "#fffddd";
                this.DiameterRightNear.BackColor = "#fffddd";
                this.DiameterLeftNear.BackColor = "#fffddd";
                this.GradientRightNear.BackColor = "#fffddd";
                this.GradientLeftNear.BackColor = "#fffddd";
            }
            else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
                this.SphRightNear.BackColor = "#fffddd";
                this.SphLeftNear.BackColor = "#fffddd";
                this.CylRightNear.BackColor = "#fffddd";
                this.CylLeftNear.BackColor = "#fffddd";
                this.AxRightNear.BackColor = "#fffddd";
                this.AxLeftNear.BackColor = "#fffddd";
                this.DiameterRightNear.BackColor = "#fffddd";
                this.DiameterLeftNear.BackColor = "#fffddd";
                this.GradientRightNear.BackColor = "#fffddd";
                this.GradientLeftNear.BackColor = "#fffddd";
            }
            else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
                this.TeleskopikGlassesTypeRighNear.BackColor = "#fffddd";
                this.TeleskopikGlassesTypeLeftNear.BackColor = "#fffddd";
            }
        }
        else {
            this.SphRightNear.BackColor = "#ffffff";
            this.SphLeftNear.BackColor = "#ffffff";
            this.CylRightNear.BackColor = "#ffffff";
            this.CylLeftNear.BackColor = "#ffffff";
            this.AxRightNear.BackColor = "#ffffff";
            this.AxLeftNear.BackColor = "#ffffff";
            this.DiameterRightNear.BackColor = "#ffffff";
            this.DiameterLeftNear.BackColor = "#ffffff";
            this.GradientRightNear.BackColor = "#ffffff";
            this.GradientLeftNear.BackColor = "#ffffff";
            this.GlassRightTypeNear.BackColor = "#ffffff";
            this.GlassLeftTypeNear.BackColor = "#ffffff";
            this.GlassColorRightNear.BackColor = "#ffffff";
            this.GlassColorLeftNear.BackColor = "#ffffff";
            this.TeleskopikGlassesTypeRighNear.BackColor = "#ffffff";
            this.TeleskopikGlassesTypeLeftNear.BackColor = "#ffffff";
        }
    }
    public changeBackgroundColorsForCloseReadingGlass(): void {
        if (this._GlassesReport.VitrumCloseReading == true) {
            this.TeleskopikGlassesTypeRighRead.BackColor = "#fffddd";
            this.TeleskopikGlassesTypeLeftRead.BackColor = "#fffddd";
        }
        else {
            this.TeleskopikGlassesTypeRighRead.BackColor = "#ffffff";
            this.TeleskopikGlassesTypeLeftRead.BackColor = "#ffffff";
        }
    }

    public cbxVitrumFar_CheckedChanged(event): void {
        let teleskopikCheckControl: boolean = false;
        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
            teleskopikCheckControl = true;
        }
        if (teleskopikCheckControl) {
            if (event != null) {
                if (this._GlassesReport != null && this._GlassesReport.VitrumFar != event) {
                    this._GlassesReport.VitrumFar = event;
                    if (event == true) {
                        if (this._GlassesReport.VitrumCloseReading == true)
                            this.cbxVitrumNear.Enabled = false;
                        else if (this._GlassesReport.VitrumNear == true)
                            this.cbxVitrumCloseReading.Enabled = false;
                    }else {
                        this.cbxVitrumCloseReading.Enabled = true;
                        this.cbxVitrumFar.Enabled = true;
                        this.cbxVitrumNear.Enabled = true;
                    }
                }
            }
            if (this._GlassesReport.VitrumFar == true) {
                if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal) {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    this.GlassRightTypeFar.Enabled = true;
                    this.onGlassRightTypeFarChanged(null);
                    this.GlassLeftTypeFar.Enabled = true;
                    this.onGlassLeftTypeFarChanged(null);
                    this.GlassColorRightFar.Enabled = true;
                    this.onGlassColorRightFarChanged(null);
                    this.GlassColorLeftFar.Enabled = true;
                    this.onGlassColorLeftFarChanged(null);
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens) {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    this.DiameterRightFar.Enabled = true;
                    this.DiameterLeftFar.Enabled = true;
                    this.GradientRightFar.Enabled = true;
                    this.GradientLeftFar.Enabled = true;
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    this.DiameterRightFar.Enabled = true;
                    this.DiameterLeftFar.Enabled = true;
                    this.GradientRightFar.Enabled = true;
                    this.GradientLeftFar.Enabled = true;
                    this.cbxVitrumNear.Enabled = false;
                    this.cbxVitrumCloseReading.Enabled = false;
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
                    this.TeleskopikGlassesTypeRightFar.Enabled = true;
                    this.onTeleskopikGlassesTypeRightFarChanged(null);
                    this.TeleskopikGlassesTypeLeftFar.Enabled = true;
                    this.onTeleskopikGlassesTypeLeftFarChanged(null);
                }
            }
            else {
                this.SphRightFar.Enabled = false;
                this.SphLeftFar.Enabled = false;
                this.CylRightFar.Enabled = false;
                this.CylLeftFar.Enabled = false;
                this.AxRightFar.Enabled = false;
                this.AxLeftFar.Enabled = false;
                this.DiameterRightFar.Enabled = false;
                this.DiameterLeftFar.Enabled = false;
                this.GradientRightFar.Enabled = false;
                this.GradientLeftFar.Enabled = false;
                this.GlassRightTypeFar.Enabled = false;
                this.onGlassRightTypeFarChanged(null);
                this.GlassLeftTypeFar.Enabled = false;
                this.onGlassLeftTypeFarChanged(null);
                this.GlassColorRightFar.Enabled = false;
                this.onGlassColorRightFarChanged(null);
                this.GlassColorLeftFar.Enabled = false;
                this.onGlassColorLeftFarChanged(null);
                this.TeleskopikGlassesTypeRightFar.Enabled = false;
                this.onTeleskopikGlassesTypeRightFarChanged(null);
                this.TeleskopikGlassesTypeLeftFar.Enabled = false;
                this.onTeleskopikGlassesTypeLeftFarChanged(null);
            }
            this.glassesReportFormViewModel.cbxVitrumFarVal = this._GlassesReport.VitrumFar;
            this.changeBackgroundColorsForFarGlass();


        } else {
            if (event != null) {
                if (this._GlassesReport != null && this._GlassesReport.VitrumFar != event) {
                    this._GlassesReport.VitrumFar = event;
                }
            }
            if (this._GlassesReport.VitrumFar == true) {
                if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal) {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    this.GlassRightTypeFar.Enabled = true;
                    this.onGlassRightTypeFarChanged(null);
                    this.GlassLeftTypeFar.Enabled = true;
                    this.onGlassLeftTypeFarChanged(null);
                    this.GlassColorRightFar.Enabled = true;
                    this.onGlassColorRightFarChanged(null);
                    this.GlassColorLeftFar.Enabled = true;
                    this.onGlassColorLeftFarChanged(null);
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens) {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    this.DiameterRightFar.Enabled = true;
                    this.DiameterLeftFar.Enabled = true;
                    this.GradientRightFar.Enabled = true;
                    this.GradientLeftFar.Enabled = true;
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
                    this.SphRightFar.Enabled = true;
                    this.SphLeftFar.Enabled = true;
                    this.CylRightFar.Enabled = true;
                    this.CylLeftFar.Enabled = true;
                    this.AxRightFar.Enabled = true;
                    this.AxLeftFar.Enabled = true;
                    this.DiameterRightFar.Enabled = true;
                    this.DiameterLeftFar.Enabled = true;
                    this.GradientRightFar.Enabled = true;
                    this.GradientLeftFar.Enabled = true;
                    this.cbxVitrumNear.Enabled = false;
                    this.cbxVitrumCloseReading.Enabled = false;
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
                    this.TeleskopikGlassesTypeRightFar.Enabled = true;
                    this.onTeleskopikGlassesTypeRightFarChanged(null);
                    this.TeleskopikGlassesTypeLeftFar.Enabled = true;
                    this.onTeleskopikGlassesTypeLeftFarChanged(null);
                }
            }
            else {
                this.SphRightFar.Enabled = false;
                this.SphLeftFar.Enabled = false;
                this.CylRightFar.Enabled = false;
                this.CylLeftFar.Enabled = false;
                this.AxRightFar.Enabled = false;
                this.AxLeftFar.Enabled = false;
                this.DiameterRightFar.Enabled = false;
                this.DiameterLeftFar.Enabled = false;
                this.GradientRightFar.Enabled = false;
                this.GradientLeftFar.Enabled = false;
                this.GlassRightTypeFar.Enabled = false;
                this.onGlassRightTypeFarChanged(null);
                this.GlassLeftTypeFar.Enabled = false;
                this.onGlassLeftTypeFarChanged(null);
                this.GlassColorRightFar.Enabled = false;
                this.onGlassColorRightFarChanged(null);
                this.GlassColorLeftFar.Enabled = false;
                this.onGlassColorLeftFarChanged(null);
                this.TeleskopikGlassesTypeRightFar.Enabled = false;
                this.onTeleskopikGlassesTypeRightFarChanged(null);
                this.TeleskopikGlassesTypeLeftFar.Enabled = false;
                this.onTeleskopikGlassesTypeLeftFarChanged(null);
            }
            this.glassesReportFormViewModel.cbxVitrumFarVal = this._GlassesReport.VitrumFar;
            this.changeBackgroundColorsForFarGlass();
        }

    }
    public cbxVitrumNear_CheckedChanged(event): void {
        let teleskopikCheckControl: boolean = false;
        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
            teleskopikCheckControl = true;
        }
        if (teleskopikCheckControl) {

            if (event != null) {
                if (this._GlassesReport != null && this._GlassesReport.VitrumNear != event) {
                    this._GlassesReport.VitrumNear = event;
                    if (event == true) {
                        if (this._GlassesReport.VitrumFar == true)
                            this.cbxVitrumCloseReading.Enabled = false;
                        else if (this._GlassesReport.VitrumCloseReading == true)
                            this.cbxVitrumFar.Enabled = false;
                    }else {
                        this.cbxVitrumCloseReading.Enabled = true;
                        this.cbxVitrumFar.Enabled = true;
                        this.cbxVitrumNear.Enabled = true;
                    }
                }
            }
            if (this._GlassesReport.VitrumNear == true) {
                if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal) {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    this.GlassRightTypeNear.Enabled = true;
                    this.onGlassRightTypeNearChanged(null);
                    this.GlassLeftTypeNear.Enabled = true;
                    this.onGlassLeftTypeNearChanged(null);
                    this.GlassColorRightNear.Enabled = true;
                    this.onGlassColorRightNearChanged(null);
                    this.GlassColorLeftNear.Enabled = true;
                    this.onGlassColorLeftNearChanged(null);
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens) {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    this.DiameterRightNear.Enabled = true;
                    this.DiameterLeftNear.Enabled = true;
                    this.GradientRightNear.Enabled = true;
                    this.GradientLeftNear.Enabled = true;
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    this.DiameterRightNear.Enabled = true;
                    this.DiameterLeftNear.Enabled = true;
                    this.GradientRightNear.Enabled = true;
                    this.GradientLeftNear.Enabled = true;
                    //this.cbxVitrumFar.Enabled = false;
                    this.cbxVitrumCloseReading.Enabled = false;
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
                    this.TeleskopikGlassesTypeRighNear.Enabled = true;
                    this.onTeleskopikGlassesTypeRighNearChanged(null);
                    this.TeleskopikGlassesTypeLeftNear.Enabled = true;
                    this.onTeleskopikGlassesTypeLeftNearChanged(null);
                    this.cbxVitrumCloseReading.Enabled = true;

                }

            }
            else {
                this.SphRightNear.Enabled = false;
                this.SphLeftNear.Enabled = false;
                this.CylRightNear.Enabled = false;
                this.CylLeftNear.Enabled = false;
                this.AxRightNear.Enabled = false;
                this.AxLeftNear.Enabled = false;
                this.DiameterRightNear.Enabled = false;
                this.DiameterLeftNear.Enabled = false;
                this.GradientRightNear.Enabled = false;
                this.GradientLeftNear.Enabled = false;
                this.GlassRightTypeNear.Enabled = false;
                this.onGlassRightTypeNearChanged(null);
                this.GlassLeftTypeNear.Enabled = false;
                this.onGlassLeftTypeNearChanged(null);
                this.GlassColorRightNear.Enabled = false;
                this.onGlassColorRightNearChanged(null);
                this.GlassColorLeftNear.Enabled = false;
                this.onGlassColorLeftNearChanged(null);
                this.TeleskopikGlassesTypeRighNear.Enabled = false;
                this.onTeleskopikGlassesTypeRighNearChanged(null);
                this.TeleskopikGlassesTypeLeftNear.Enabled = false;
                this.onTeleskopikGlassesTypeLeftNearChanged(null);
            }
            this.glassesReportFormViewModel.cbxVitrumNearVal = this._GlassesReport.VitrumNear;

            this.changeBackgroundColorsForNearGlass();

        } else {
            if (event != null) {
                if (this._GlassesReport != null && this._GlassesReport.VitrumNear != event) {
                    this._GlassesReport.VitrumNear = event;
                }
            }
            if (this._GlassesReport.VitrumNear == true) {
                if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal) {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    this.GlassRightTypeNear.Enabled = true;
                    this.onGlassRightTypeNearChanged(null);
                    this.GlassLeftTypeNear.Enabled = true;
                    this.onGlassLeftTypeNearChanged(null);
                    this.GlassColorRightNear.Enabled = true;
                    this.onGlassColorRightNearChanged(null);
                    this.GlassColorLeftNear.Enabled = true;
                    this.onGlassColorLeftNearChanged(null);
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens) {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    this.DiameterRightNear.Enabled = true;
                    this.DiameterLeftNear.Enabled = true;
                    this.GradientRightNear.Enabled = true;
                    this.GradientLeftNear.Enabled = true;
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
                    this.SphRightNear.Enabled = true;
                    this.SphLeftNear.Enabled = true;
                    this.CylRightNear.Enabled = true;
                    this.CylLeftNear.Enabled = true;
                    this.AxRightNear.Enabled = true;
                    this.AxLeftNear.Enabled = true;
                    this.DiameterRightNear.Enabled = true;
                    this.DiameterLeftNear.Enabled = true;
                    this.GradientRightNear.Enabled = true;
                    this.GradientLeftNear.Enabled = true;
                    //this.cbxVitrumFar.Enabled = false;
                    this.cbxVitrumCloseReading.Enabled = false;
                }
                else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
                    this.TeleskopikGlassesTypeRighNear.Enabled = true;
                    this.onTeleskopikGlassesTypeRighNearChanged(null);
                    this.TeleskopikGlassesTypeLeftNear.Enabled = true;
                    this.onTeleskopikGlassesTypeLeftNearChanged(null);
                    this.cbxVitrumCloseReading.Enabled = true;

                }

            }
            else {
                this.SphRightNear.Enabled = false;
                this.SphLeftNear.Enabled = false;
                this.CylRightNear.Enabled = false;
                this.CylLeftNear.Enabled = false;
                this.AxRightNear.Enabled = false;
                this.AxLeftNear.Enabled = false;
                this.DiameterRightNear.Enabled = false;
                this.DiameterLeftNear.Enabled = false;
                this.GradientRightNear.Enabled = false;
                this.GradientLeftNear.Enabled = false;
                this.GlassRightTypeNear.Enabled = false;
                this.onGlassRightTypeNearChanged(null);
                this.GlassLeftTypeNear.Enabled = false;
                this.onGlassLeftTypeNearChanged(null);
                this.GlassColorRightNear.Enabled = false;
                this.onGlassColorRightNearChanged(null);
                this.GlassColorLeftNear.Enabled = false;
                this.onGlassColorLeftNearChanged(null);
                this.TeleskopikGlassesTypeRighNear.Enabled = false;
                this.onTeleskopikGlassesTypeRighNearChanged(null);
                this.TeleskopikGlassesTypeLeftNear.Enabled = false;
                this.onTeleskopikGlassesTypeLeftNearChanged(null);
            }
            this.glassesReportFormViewModel.cbxVitrumNearVal = this._GlassesReport.VitrumNear;

            this.changeBackgroundColorsForNearGlass();
        }



    }
    public cbxVitrumCloseReading_CheckedChanged(event): void {
        let teleskopikCheckControl: boolean = false;
        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
            teleskopikCheckControl = true;
        }
        if (teleskopikCheckControl) {

            if (event != null) {
                if (this._GlassesReport != null && this._GlassesReport.VitrumCloseReading != event) {
                    this._GlassesReport.VitrumCloseReading = event;
                    if (event == true) {
                        if (this._GlassesReport.VitrumFar == true)
                            this.cbxVitrumNear.Enabled = false;
                        else if (this._GlassesReport.VitrumNear == true)
                            this.cbxVitrumFar.Enabled = false;
                    }
                    else {
                        this.cbxVitrumCloseReading.Enabled = true;
                        this.cbxVitrumFar.Enabled = true;
                        this.cbxVitrumNear.Enabled = true;
                    }
                }
            }
            if (this._GlassesReport.VitrumCloseReading == true) {
                this.TeleskopikGlassesTypeRighRead.Enabled = true;
                this.TeleskopikGlassesTypeLeftRead.Enabled = true;
            }
            else {
                this.TeleskopikGlassesTypeRighRead.Enabled = false;
                this.TeleskopikGlassesTypeLeftRead.Enabled = false;
            }
            this.glassesReportFormViewModel.cbxVitrumCloseReadingVal = this._GlassesReport.VitrumCloseReading;

            this.changeBackgroundColorsForCloseReadingGlass();

        } else {
            if (event != null) {
                if (this._GlassesReport != null && this._GlassesReport.VitrumCloseReading != event) {
                    this._GlassesReport.VitrumCloseReading = event;
                }
            }
            if (this._GlassesReport.VitrumCloseReading == true) {
                this.TeleskopikGlassesTypeRighRead.Enabled = true;
                this.TeleskopikGlassesTypeLeftRead.Enabled = true;
            }
            else {
                this.TeleskopikGlassesTypeRighRead.Enabled = false;
                this.TeleskopikGlassesTypeLeftRead.Enabled = false;
            }
            this.glassesReportFormViewModel.cbxVitrumCloseReadingVal = this._GlassesReport.VitrumCloseReading;

            this.changeBackgroundColorsForCloseReadingGlass();
        }




    }

    public CommaControl(text: string): string {
        if (typeof text === 'string') {
            if (text.includes(',', 0)) {
                text = text.replace(',', '.');
            }
        }
        return text;
    }
    public checkAxisBoundary(enteredValue: string): boolean {
        let checkVal: number = +enteredValue;
        if (checkVal >= 0 && checkVal < 181) {
            return true;
        }
        else {
            return false;
        }
    }

    public resetForm(): void {
        this.cbxVitrumFar_CheckedChanged(this._GlassesReport.VitrumFar);
        this.cbxVitrumNear_CheckedChanged(this._GlassesReport.VitrumNear);
        this.cbxVitrumCloseReading_CheckedChanged(this._GlassesReport.VitrumCloseReading);
        this.SphRightFar.Text = null;
        this.SphRightFar_TextChanged();
        this.CylRightFar.Text = null;
        this.CylRightFar_TextChanged();
        this.AxRightFar.Text = null;
        this.AxRightFar_TextChanged();
        this.DiameterRightFar.Text = null;
        this.DiameterRightFar_TextChanged();
        this.GradientRightFar.Text = null;
        this.GradientRightFar_TextChanged();
        this.SphLeftFar.Text = null;
        this.SphLeftFar_TextChanged();
        this.CylLeftFar.Text = null;
        this.CylLeftFar_TextChanged();
        this.AxLeftFar.Text = null;
        this.AxLeftFar_TextChanged();
        this.DiameterLeftFar.Text = null;
        this.DiameterLeftFar_TextChanged();
        this.GradientLeftFar.Text = null;
        this.GradientLeftFar_TextChanged();
        this.SphRightNear.Text = null;
        this.SphRightNear_TextChanged();
        this.CylRightNear.Text = null;
        this.CylRightNear_TextChanged();
        this.AxRightNear.Text = null;
        this.AxRightNear_TextChanged();
        this.DiameterRightNear.Text = null;
        this.DiameterRightNear_TextChanged();
        this.GradientRightNear.Text = null;
        this.GradientRightNear_TextChanged();
        this.SphLeftNear.Text = null;
        this.SphLeftNear_TextChanged();
        this.CylLeftNear.Text = null;
        this.CylLeftNear_TextChanged();
        this.AxLeftNear.Text = null;
        this.AxLeftNear_TextChanged();
        this.DiameterLeftNear.Text = null;
        this.DiameterLeftNear_TextChanged();
        this.GradientLeftNear.Text = null;
        this.GradientLeftNear_TextChanged();
    }

    public CylLeftFar_TextChanged(): void {
        this.CylLeftFar.Text = this.CommaControl(this.CylLeftFar.Text);
        if (this._GlassesReport.CylLeftFar != null) {
            this.CommaControl(this._GlassesReport.CylLeftFar);
        }
    }
    public CylLeftNear_TextChanged(): void {
        this.CylLeftNear.Text = this.CommaControl(this.CylLeftNear.Text);
        if (this._GlassesReport.CylLeftNear != null) {
            this.CommaControl(this._GlassesReport.CylLeftNear);
        }
    }
    public CylRightFar_TextChanged(): void {
        this.CylRightFar.Text = this.CommaControl(this.CylRightFar.Text);
        if (this._GlassesReport.CylRightFar != null) {
            this.CommaControl(this._GlassesReport.CylRightFar);
        }
    }
    public CylRightNear_TextChanged(): void {
        this.CylRightNear.Text = this.CommaControl(this.CylRightNear.Text);
        if (this._GlassesReport.CylRightNear != null) {
            this.CommaControl(this._GlassesReport.CylRightNear);
        }
    }
    public GradientLeftFar_TextChanged(): void {
        this.GradientLeftFar.Text = this.CommaControl(this.GradientLeftFar.Text);
        if (this._GlassesReport.GradientLeftFar != null) {
            this.CommaControl(this._GlassesReport.GradientLeftFar);
        }
    }
    public GradientLeftNear_TextChanged(): void {
        this.GradientLeftNear.Text = this.CommaControl(this.GradientLeftNear.Text);
        if (this._GlassesReport.GradientLeftNear != null) {
            this.CommaControl(this._GlassesReport.GradientLeftNear);
        }
    }
    public GradientRightFar_TextChanged(): void {
        this.GradientRightFar.Text = this.CommaControl(this.GradientRightFar.Text);
        if (this._GlassesReport.GradientRightFar != null) {
            this.CommaControl(this._GlassesReport.GradientRightFar);
        }
    }
    public GradientRightNear_TextChanged(): void {
        this.GradientRightNear.Text = this.CommaControl(this.GradientRightNear.Text);
        if (this._GlassesReport.GradientRightNear != null) {
            this.CommaControl(this._GlassesReport.GradientRightNear);
        }
    }
    public PrescriptionType_SelectedIndexChanged(): void {

        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Teleskopik) {
            this.cbxVitrumCloseReading.Enabled = true;
            // this._GlassesReport.VitrumNear = false;
            this.cbxVitrumNear.Enabled = true;
            this.TemporaryLens.Enabled = false;
            this.TemporaryLens.Value = false;
            if (this._GlassesReport.VitrumFar == true) {
                this.TeleskopikGlassesTypeRightFar.Enabled = true;
                this.TeleskopikGlassesTypeLeftFar.Enabled = true;
                this.SphRightFar.Enabled = false;
                this.SphLeftFar.Enabled = false;
                this.CylRightFar.Enabled = false;
                this.CylLeftFar.Enabled = false;
                this.AxRightFar.Enabled = false;
                this.AxLeftFar.Enabled = false;
                this.GlassRightTypeFar.Enabled = false;
                this.GlassLeftTypeFar.Enabled = false;
                this.GlassColorRightFar.Enabled = false;
                this.GlassColorLeftFar.Enabled = false;
                this.DiameterRightFar.Enabled = false;
                this.DiameterLeftFar.Enabled = false;
                this.GradientRightFar.Enabled = false;
                this.GradientLeftFar.Enabled = false;
            }
            if (this._GlassesReport.VitrumNear == true) {
                this.TeleskopikGlassesTypeRighNear.Enabled = true;
                this.TeleskopikGlassesTypeLeftNear.Enabled = true;
                this.SphRightNear.Enabled = false;
                this.SphLeftNear.Enabled = false;
                this.CylRightNear.Enabled = false;
                this.CylLeftNear.Enabled = false;
                this.AxRightNear.Enabled = false;
                this.AxLeftNear.Enabled = false;
                this.GlassRightTypeNear.Enabled = false;
                this.GlassLeftTypeNear.Enabled = false;
                this.GlassColorRightNear.Enabled = false;
                this.GlassColorLeftNear.Enabled = false;
                this.DiameterRightNear.Enabled = false;
                this.DiameterLeftNear.Enabled = false;
                this.GradientRightNear.Enabled = false;
                this.GradientLeftNear.Enabled = false;
            }
        }
        else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens || this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
            if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens)
                this.TemporaryLens.Enabled = true;
            else {
                this.TemporaryLens.Enabled = false;
                this.TemporaryLens.Value = false;
            }
            this.cbxVitrumNear.Enabled = false;
            this.cbxVitrumFar.Enabled = true;
            this._GlassesReport.VitrumCloseReading = false;

            this.cbxVitrumCloseReading.Enabled = false;
            this._GlassesReport.VitrumNear = false;
            this.TeleskopikGlassesTypeRighRead.Enabled = false;
            this.TeleskopikGlassesTypeLeftRead.Enabled = false;
            this.SphRightNear.Enabled = false;
            this.SphLeftNear.Enabled = false;
            this.CylRightNear.Enabled = false;
            this.CylLeftNear.Enabled = false;
            this.AxRightNear.Enabled = false;
            this.AxLeftNear.Enabled = false;
            this.DiameterRightNear.Enabled = false;
            this.DiameterLeftNear.Enabled = false;
            this.GradientRightNear.Enabled = false;
            this.GradientLeftNear.Enabled = false;
            this.GlassRightTypeNear.Enabled = false;
            this.GlassLeftTypeNear.Enabled = false;
            this.GlassColorRightNear.Enabled = false;
            this.GlassColorLeftNear.Enabled = false;
            this.TeleskopikGlassesTypeRighNear.Enabled = false;
            this.TeleskopikGlassesTypeLeftNear.Enabled = false;
            this.TeleskopikGlassesTypeRightFar.Enabled = false;
            this.TeleskopikGlassesTypeLeftFar.Enabled = false;
            this.GlassRightTypeFar.Enabled = true;
            this.GlassLeftTypeFar.Enabled = true;
            this.GlassColorRightFar.Enabled = false;
            this.GlassColorLeftFar.Enabled = false;
            this.SphRightFar.Enabled = true;
            this.SphLeftFar.Enabled = true;
            this.CylRightFar.Enabled = true;
            this.CylLeftFar.Enabled = true;
            this.AxRightFar.Enabled = true;
            this.AxLeftFar.Enabled = true;
            this.DiameterRightFar.Enabled = true;
            this.DiameterLeftFar.Enabled = true;
            this.GradientRightFar.Enabled = true;
            this.GradientLeftFar.Enabled = true;
        }
        else if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Normal) {
            this.cbxVitrumNear.Enabled = true;
            this.cbxVitrumFar.Enabled = true;
            this._GlassesReport.VitrumCloseReading = false;
            this.cbxVitrumCloseReading.Enabled = false;
            this.TeleskopikGlassesTypeRighRead.Enabled = false;
            this.TeleskopikGlassesTypeLeftRead.Enabled = false;
            this.TeleskopikGlassesTypeRightFar.Enabled = false;
            this.TeleskopikGlassesTypeLeftFar.Enabled = false;
            this.TeleskopikGlassesTypeRighNear.Enabled = false;
            this.TeleskopikGlassesTypeLeftNear.Enabled = false;
            this.GradientRightFar.Enabled = false;
            this.GradientLeftFar.Enabled = false;
            this.DiameterRightFar.Enabled = false;
            this.DiameterRightNear.Enabled = false;
            this.DiameterLeftFar.Enabled = false;
            this.DiameterLeftNear.Enabled = false;
            this.TemporaryLens.Enabled = false;
            this.TemporaryLens.Value = false;
            this.GradientRightNear.Enabled = false;
            this.GradientLeftNear.Enabled = false;
            if (this._GlassesReport.VitrumFar == true) {
                this.SphRightFar.Enabled = true;
                this.SphLeftFar.Enabled = true;
                this.CylRightFar.Enabled = true;
                this.CylLeftFar.Enabled = true;
                this.AxRightFar.Enabled = true;
                this.AxLeftFar.Enabled = true;
                this.GlassRightTypeFar.Enabled = true;
                this.GlassLeftTypeFar.Enabled = true;
                this.GlassColorRightFar.Enabled = true;
                this.GlassColorLeftFar.Enabled = true;
            }
            if (this._GlassesReport.VitrumNear == true) {
                this.SphRightNear.Enabled = true;
                this.SphLeftNear.Enabled = true;
                this.CylRightNear.Enabled = true;
                this.CylLeftNear.Enabled = true;
                this.AxRightNear.Enabled = true;
                this.AxLeftNear.Enabled = true;
                this.GlassRightTypeNear.Enabled = true;
                this.GlassLeftTypeNear.Enabled = true;
                this.GlassColorRightNear.Enabled = true;
                this.GlassColorLeftNear.Enabled = true;
            }
        }
        this.resetForm();
        if (this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Lens || this._GlassesReport.PrescriptionType == GlassesPrescriptionTypeEnum.Keratakonuslens) {
            //this._GlassesReport.VitrumFar = true;
            this.cbxVitrumFar_CheckedChanged(this._GlassesReport.VitrumFar);
        }
    }
    public SphLeftFar_TextChanged(): void {
        this.SphLeftFar.Text = this.CommaControl(this.SphLeftFar.Text);
        if (this._GlassesReport.SphLeftFar != null) {
            this.CommaControl(this._GlassesReport.SphLeftFar);
        }
    }
    public SphLeftNear_TextChanged(): void {
        this.SphLeftNear.Text = this.CommaControl(this.SphLeftNear.Text);
        if (this._GlassesReport.SphLeftNear != null) {
            this.CommaControl(this._GlassesReport.SphLeftNear);
        }
    }
    public SphRightFar_TextChanged(): void {
        this.SphRightFar.Text = this.CommaControl(this.SphRightFar.Text);
        if (this._GlassesReport.SphRightFar != null) {
            this.CommaControl(this._GlassesReport.SphRightFar);
        }
    }
    public SphRightNear_TextChanged(): void {
        this.SphRightNear.Text = this.CommaControl(this.SphRightNear.Text);
        if (this._GlassesReport.SphRightNear != null) {
            this.CommaControl(this._GlassesReport.SphRightNear);
        }
    }
    public AxLeftFar_TextChanged(): void {
        if (!this.checkAxisBoundary(this.AxLeftFar.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.AxLeftFar.Text = '';
        }
        if (this._GlassesReport.AxLeftFar != null) {
            this.CommaControl(this._GlassesReport.AxLeftFar);
        }
    }
    public AxLeftNear_TextChanged(): void {
        if (!this.checkAxisBoundary(this.AxLeftNear.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.AxLeftNear.Text = '';
        }
        if (this._GlassesReport.AxLeftNear != null) {
            this.CommaControl(this._GlassesReport.AxLeftNear);
        }
    }
    public AxRightFar_TextChanged(): void {
        if (!this.checkAxisBoundary(this.AxRightFar.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.AxRightFar.Text = '';
        }
        if (this._GlassesReport.AxRightFar != null) {
            this.CommaControl(this._GlassesReport.AxRightFar);
        }
    }
    public AxRightNear_TextChanged(): void {
        if (!this.checkAxisBoundary(this.AxRightNear.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.AxRightNear.Text = '';
        }
        if (this._GlassesReport.AxRightNear != null) {
            this.CommaControl(this._GlassesReport.AxRightNear);
        }
    }
    public DiameterLeftFar_TextChanged(): void {
        this.DiameterLeftFar.Text = this.CommaControl(this.DiameterLeftFar.Text);
        if (this._GlassesReport.DiameterLeftFar != null) {
            this.CommaControl(this._GlassesReport.DiameterLeftFar);
        }
    }
    public DiameterLeftNear_TextChanged(): void {
        this.DiameterLeftNear.Text = this.CommaControl(this.DiameterLeftNear.Text);
        if (this._GlassesReport.DiameterLeftNear != null) {
            this.CommaControl(this._GlassesReport.DiameterLeftNear);
        }
    }
    public DiameterRightFar_TextChanged(): void {
        this.DiameterRightFar.Text = this.CommaControl(this.DiameterRightFar.Text);
        if (this._GlassesReport.DiameterRightFar != null) {
            this.CommaControl(this._GlassesReport.DiameterRightFar);
        }
    }
    public DiameterRightNear_TextChanged(): void {
        this.DiameterRightNear.Text = this.CommaControl(this.DiameterRightNear.Text);
        if (this._GlassesReport.DiameterRightNear != null) {
            this.CommaControl(this._GlassesReport.DiameterRightNear);
        }
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (transDef != null) {
            if (transDef.ToStateDefID === GlassesReport.GlassesReportStates.Completed && this._GlassesReport.EReceteNo === null) {
                if (GlassesReportForm.MedulaEpisodeControl(this._GlassesReport)) {
                    //                    TTVisual.InfoBox.Alert("Hastanın Reçetesini Medulaya Bildirmediniz !");
                    //
                    if (await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M15475", "Hastanın Reçetesini Medulaya Bildirmediniz!\nDevam etmek istediğinize emin misiniz?")) === 'H') {
                        throw new TTException(i18n("M16907", "İşlemden vazgeçildi"));
                    }
                }
            }
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        this.DropStateButton(GlassesReport.GlassesReportStates.Completed);

    }
    protected async PreScript() {
        super.PreScript();
        if (this.ProcedureDoctor.SelectedObject === null) {
            let currentUser: ResUser = <ResUser>TTUser.CurrentUser.UserObject;
            if (currentUser.UserType === UserTypeEnum.Doctor) {
                this.ProcedureDoctor.SelectedObject = <ResUser>TTUser.CurrentUser.UserObject;
            }
        }
        let diagnoseControl: boolean = false;
        /*if (this._GlassesReport.Episode != null && this._GlassesReport.Episode.Diagnosis != null) {
            for (let diagnosis of this._GlassesReport.Episode.Diagnosis) {
                for (let glassesDiagnosis of this._GlassesReport.Diagnosis) {
                    if (glassesDiagnosis.ObjectID === diagnosis.ObjectID)
                        diagnoseControl = true;
                }
                if (this._GlassesReport.Diagnosis === null || this._GlassesReport.Diagnosis.length === 0)
                    diagnoseControl = true;
                if (diagnoseControl === false)
                    this._GlassesReport.Diagnosis.push(diagnosis);
            }
        }*/
        //    this.ReasonForAdmission.Text = this._GlassesReport.Episode.ReasonForAdmission.Description;
        // this.PatientGroup.Text = Common.GetEnumValueDefOfEnumValue(this._GlassesReport.Episode.Patient.PatientGroup.Value).DisplayText;
        //            this.RecordID.Text = this._GlassesReport.Episode.RetirementFundID; //SGK Sicil No



        this.DropStateButton(GlassesReport.GlassesReportStates.Completed);
    }


    static async MedulaEpisodeControl(glassesReport: GlassesReport): Promise<boolean> {
        return (await EpisodeService.IsMedulaEpisode(glassesReport.Episode));
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GlassesReport();
        this.glassesReportFormViewModel = new GlassesReportFormViewModel();
        this._ViewModel = this.glassesReportFormViewModel;
        this.glassesReportFormViewModel._GlassesReport = this._TTObject as GlassesReport;
        //this.glassesReportFormViewModel._GlassesReport.Diagnosis = new Array<DiagnosisGrid>();
        this.glassesReportFormViewModel._GlassesReport.Episode = new Episode();
        //this.glassesReportFormViewModel._GlassesReport.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.glassesReportFormViewModel._GlassesReport.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.glassesReportFormViewModel = this._ViewModel as GlassesReportFormViewModel;
        that._TTObject = this.glassesReportFormViewModel._GlassesReport;
        if (this.glassesReportFormViewModel == null)
            this.glassesReportFormViewModel = new GlassesReportFormViewModel();
        if (this.glassesReportFormViewModel._GlassesReport == null)
            this.glassesReportFormViewModel._GlassesReport = new GlassesReport();
        /* that.glassesReportFormViewModel._GlassesReport.Diagnosis = that.glassesReportFormViewModel.SecDiagnosisGridList;
         for (let detailItem of that.glassesReportFormViewModel.SecDiagnosisGridList) {
             let diagnoseObjectID = detailItem["Diagnose"];
             if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                 let diagnose = that.glassesReportFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                 detailItem.Diagnose = diagnose;
             }
             let responsibleUserObjectID = detailItem["ResponsibleUser"];
             if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                 let responsibleUser = that.glassesReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                 detailItem.ResponsibleUser = responsibleUser;
             }
         }*/
        let episodeObjectID = that.glassesReportFormViewModel._GlassesReport['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.glassesReportFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.glassesReportFormViewModel._GlassesReport.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.glassesReportFormViewModel.DiagnosisDiagnosisGridGridList;
                /*for (let detailItem of that.glassesReportFormViewModel.DiagnosisDiagnosisGridGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.glassesReportFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        detailItem.Diagnose = diagnose;
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.glassesReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        detailItem.ResponsibleUser = responsibleUser;
                    }
                }*/
            }
        }
        let procedureDoctorObjectID = that.glassesReportFormViewModel._GlassesReport['ProcedureDoctor'];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.glassesReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.glassesReportFormViewModel._GlassesReport.ProcedureDoctor = procedureDoctor;
            }
        }
        if (this._GlassesReport.PrescriptionType == null) {
            this.onPrescriptionTypeChanged(0);
            this.PrescriptionType_SelectedIndexChanged();
        }

    }


    async ngOnInit() {
        let that = this;
        await this.load(GlassesReportFormViewModel);
        let enableMedulaPasswordEntrance: string = (await SystemParameterService.GetParameterValue('MEDULASIFREGIRISEKRANIAKTIF', 'FALSE'));
        if (enableMedulaPasswordEntrance === 'TRUE') {
            this.enableMedulaPasswordEntrance = true;
        }
        else {
            this.enableMedulaPasswordEntrance = false;
        }
    }


    async ngAfterViewInit() {

    }
    public onAxLeftFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.AxLeftFar != event) {
            this._GlassesReport.AxLeftFar = event;
        }
        this.AxLeftFar_TextChanged();
    }

    public onAxLeftNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.AxLeftNear != event) {
            this._GlassesReport.AxLeftNear = event;
        }
        this.AxLeftNear_TextChanged();
    }

    public onAxRightFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.AxRightFar != event) {
            this._GlassesReport.AxRightFar = event;
        }
        this.AxRightFar_TextChanged();
    }

    public onAxRightNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.AxRightNear != event) {
            this._GlassesReport.AxRightNear = event;
        }
        this.AxRightNear_TextChanged();
    }

    public onCylLeftFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.CylLeftFar != event) {
            this._GlassesReport.CylLeftFar = event;
        }
        this.CylLeftFar_TextChanged();
    }

    public onCylLeftNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.CylLeftNear != event) {
            this._GlassesReport.CylLeftNear = event;
        }
        this.CylLeftNear_TextChanged();
    }

    public onCylRightFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.CylRightFar != event) {
            this._GlassesReport.CylRightFar = event;
        }
        this.CylRightFar_TextChanged();
    }

    public onCylRightNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.CylRightNear != event) {
            this._GlassesReport.CylRightNear = event;
        }
        this.CylRightNear_TextChanged();
    }

    public onDiameterLeftFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.DiameterLeftFar != event) {
            this._GlassesReport.DiameterLeftFar = event;
        }
        this.DiameterLeftFar_TextChanged();
    }

    public onDiameterLeftNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.DiameterLeftNear != event) {
            this._GlassesReport.DiameterLeftNear = event;
        }
        this.DiameterLeftNear_TextChanged();
    }

    public onDiameterRightFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.DiameterRightFar != event) {
            this._GlassesReport.DiameterRightFar = event;
        }
        this.DiameterRightFar_TextChanged();
    }

    public onDiameterRightNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.DiameterRightNear != event) {
            this._GlassesReport.DiameterRightNear = event;
        }
        this.DiameterRightNear_TextChanged();
    }

    public onEReceteNoChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.EReceteNo != event) {
            this._GlassesReport.EReceteNo = event;
        }
    }

    public onGlassColorLeftFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GlassColorLeftFar != event) {
            this._GlassesReport.GlassColorLeftFar = event;
        }
    }

    public onGlassColorLeftNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GlassColorLeftNear != event) {
            this._GlassesReport.GlassColorLeftNear = event;
        }
    }

    public onGlassColorRightFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GlassColorRightFar != event) {
            this._GlassesReport.GlassColorRightFar = event;
        }
    }

    public onGlassColorRightNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GlassColorRightNear != event) {
            this._GlassesReport.GlassColorRightNear = event;
        }
    }

    public onGlassLeftTypeFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GlassLeftTypeFar != event) {
            this._GlassesReport.GlassLeftTypeFar = event;
        }
    }

    public onGlassLeftTypeNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GlassLeftTypeNear != event) {
            this._GlassesReport.GlassLeftTypeNear = event;
        }
    }

    public onGlassRightTypeFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GlassRightTypeFar != event) {
            this._GlassesReport.GlassRightTypeFar = event;
        }
    }

    public onGlassRightTypeNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GlassRightTypeNear != event) {
            this._GlassesReport.GlassRightTypeNear = event;
        }
    }

    public onGradientLeftFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GradientLeftFar != event) {
            this._GlassesReport.GradientLeftFar = event;
        }
        this.GradientLeftFar_TextChanged();
    }

    public onGradientLeftNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GradientLeftNear != event) {
            this._GlassesReport.GradientLeftNear = event;
        }
        this.GradientLeftNear_TextChanged();
    }

    public onGradientRightFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GradientRightFar != event) {
            this._GlassesReport.GradientRightFar = event;
        }
        this.GradientRightFar_TextChanged();
    }

    public onGradientRightNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.GradientRightNear != event) {
            this._GlassesReport.GradientRightNear = event;
        }
        this.GradientRightNear_TextChanged();
    }

    public onPrescriptionTypeChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.PrescriptionType != event) {
            this._GlassesReport.PrescriptionType = event;
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.ProcedureDoctor != event) {
            this._GlassesReport.ProcedureDoctor = event;
        }
    }

    public onProtocolNoChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.ProtocolNo != event) {
            this._GlassesReport.ProtocolNo = event;
        }
    }

    public onReportDateChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.ReportDate != event) {
            this._GlassesReport.ReportDate = event;
        }
    }

    public onSonucAciklamasiChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.SonucAciklamasi != event) {
            this._GlassesReport.SonucAciklamasi = event;
        }
    }

    public onSonucKoduChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.SonucKodu != event) {
            this._GlassesReport.SonucKodu = event;
        }
    }

    public onSphLeftFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.SphLeftFar != event) {
            this._GlassesReport.SphLeftFar = event;
        }
        this.SphLeftFar_TextChanged();
    }

    public onSphLeftNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.SphLeftNear != event) {
            this._GlassesReport.SphLeftNear = event;
        }
        this.SphLeftNear_TextChanged();
    }

    public onSphRightFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.SphRightFar != event) {
            this._GlassesReport.SphRightFar = event;
        }
        this.SphRightFar_TextChanged();
    }

    public onSphRightNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.SphRightNear != event) {
            this._GlassesReport.SphRightNear = event;
        }
        this.SphRightNear_TextChanged();
    }

    public onTeleskopikGlassesTypeLeftFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.TeleskopikGlassesTypeLeftFar != event) {
            this._GlassesReport.TeleskopikGlassesTypeLeftFar = event;
        }
    }

    public onTeleskopikGlassesTypeLeftNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.TeleskopikGlassesTypeLeftNear != event) {
            this._GlassesReport.TeleskopikGlassesTypeLeftNear = event;
        }
    }

    public onTeleskopikGlassesTypeLeftReadChanged(event): void {

        if (this._GlassesReport != null && this._GlassesReport.TeleskopikGlassesTypeLeftRead != event) {
            this._GlassesReport.TeleskopikGlassesTypeLeftRead = event;
        }
    }

    public onTeleskopikGlassesTypeRighNearChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.TeleskopikGlassesTypeRighNear != event) {
            this._GlassesReport.TeleskopikGlassesTypeRighNear = event;
        }
    }

    public onTeleskopikGlassesTypeRighReadChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.TeleskopikGlassesTypeRighRead != event) {
            this._GlassesReport.TeleskopikGlassesTypeRighRead = event;
        }
    }

    public onTeleskopikGlassesTypeRightFarChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.TeleskopikGlassesTypeRightFar != event) {
            this._GlassesReport.TeleskopikGlassesTypeRightFar = event;
        }
    }

    public onTemporaryLensChanged(event): void {
        if (this._GlassesReport != null && this._GlassesReport.TemporaryLens != event) {
            this._GlassesReport.TemporaryLens = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ReportDate, 'Value', this.__ttObject, 'ReportDate');
        redirectProperty(this.ProtocolNo, 'Text', this.__ttObject, 'ProtocolNo');
        redirectProperty(this.PrescriptionType, 'Value', this.__ttObject, 'PrescriptionType');
        redirectProperty(this.TemporaryLens, 'Value', this.__ttObject, 'TemporaryLens');
        redirectProperty(this.EReceteNo, 'Text', this.__ttObject, 'EReceteNo');
        redirectProperty(this.SonucKodu, 'Text', this.__ttObject, 'SonucKodu');
        redirectProperty(this.SonucAciklamasi, 'Text', this.__ttObject, 'SonucAciklamasi');
        redirectProperty(this.SphRightFar, 'Text', this.__ttObject, 'SphRightFar');
        redirectProperty(this.CylRightFar, 'Text', this.__ttObject, 'CylRightFar');
        redirectProperty(this.AxRightFar, 'Text', this.__ttObject, 'AxRightFar');
        redirectProperty(this.DiameterRightFar, 'Text', this.__ttObject, 'DiameterRightFar');
        redirectProperty(this.GradientRightFar, 'Text', this.__ttObject, 'GradientRightFar');
        redirectProperty(this.GlassRightTypeFar, 'Value', this.__ttObject, 'GlassRightTypeFar');
        redirectProperty(this.GlassColorRightFar, 'Value', this.__ttObject, 'GlassColorRightFar');
        redirectProperty(this.TeleskopikGlassesTypeRightFar, 'Value', this.__ttObject, 'TeleskopikGlassesTypeRightFar');
        redirectProperty(this.SphLeftFar, 'Text', this.__ttObject, 'SphLeftFar');
        redirectProperty(this.CylLeftFar, 'Text', this.__ttObject, 'CylLeftFar');
        redirectProperty(this.AxLeftFar, 'Text', this.__ttObject, 'AxLeftFar');
        redirectProperty(this.DiameterLeftFar, 'Text', this.__ttObject, 'DiameterLeftFar');
        redirectProperty(this.GradientLeftFar, 'Text', this.__ttObject, 'GradientLeftFar');
        redirectProperty(this.GlassLeftTypeFar, 'Value', this.__ttObject, 'GlassLeftTypeFar');
        redirectProperty(this.GlassColorLeftFar, 'Value', this.__ttObject, 'GlassColorLeftFar');
        redirectProperty(this.TeleskopikGlassesTypeLeftFar, 'Value', this.__ttObject, 'TeleskopikGlassesTypeLeftFar');
        redirectProperty(this.SphRightNear, 'Text', this.__ttObject, 'SphRightNear');
        redirectProperty(this.CylRightNear, 'Text', this.__ttObject, 'CylRightNear');
        redirectProperty(this.AxRightNear, 'Text', this.__ttObject, 'AxRightNear');
        redirectProperty(this.DiameterRightNear, 'Text', this.__ttObject, 'DiameterRightNear');
        redirectProperty(this.GradientRightNear, 'Text', this.__ttObject, 'GradientRightNear');
        redirectProperty(this.GlassRightTypeNear, 'Value', this.__ttObject, 'GlassRightTypeNear');
        redirectProperty(this.GlassColorRightNear, 'Value', this.__ttObject, 'GlassColorRightNear');
        redirectProperty(this.TeleskopikGlassesTypeRighNear, 'Value', this.__ttObject, 'TeleskopikGlassesTypeRighNear');
        redirectProperty(this.SphLeftNear, 'Text', this.__ttObject, 'SphLeftNear');
        redirectProperty(this.CylLeftNear, 'Text', this.__ttObject, 'CylLeftNear');
        redirectProperty(this.AxLeftNear, 'Text', this.__ttObject, 'AxLeftNear');
        redirectProperty(this.DiameterLeftNear, 'Text', this.__ttObject, 'DiameterLeftNear');
        redirectProperty(this.GradientLeftNear, 'Text', this.__ttObject, 'GradientLeftNear');
        redirectProperty(this.GlassLeftTypeNear, 'Value', this.__ttObject, 'GlassLeftTypeNear');
        redirectProperty(this.GlassColorLeftNear, 'Value', this.__ttObject, 'GlassColorLeftNear');
        redirectProperty(this.TeleskopikGlassesTypeLeftNear, 'Value', this.__ttObject, 'TeleskopikGlassesTypeLeftNear');
        redirectProperty(this.TeleskopikGlassesTypeRighRead, 'Value', this.__ttObject, 'TeleskopikGlassesTypeRighRead');
        redirectProperty(this.TeleskopikGlassesTypeLeftRead, 'Value', this.__ttObject, 'TeleskopikGlassesTypeLeftRead');
    }

    public initFormControls(): void {
        this.CylLeftNear = new TTVisual.TTTextBox();
        this.CylLeftNear.Name = 'CylLeftNear';
        this.CylLeftNear.TabIndex = 40;

        this.CylLeftFar = new TTVisual.TTTextBox();
        this.CylLeftFar.Name = 'CylLeftFar';
        this.CylLeftFar.TabIndex = 23;

        this.SphLeftNear = new TTVisual.TTTextBox();
        this.SphLeftNear.Name = 'SphLeftNear';
        this.SphLeftNear.TabIndex = 39;

        this.SphLeftFar = new TTVisual.TTTextBox();
        this.SphLeftFar.Name = 'SphLeftFar';
        this.SphLeftFar.TabIndex = 22;

        this.CylRightNear = new TTVisual.TTTextBox();
        this.CylRightNear.Name = 'CylRightNear';
        this.CylRightNear.TabIndex = 32;

        this.SphRightNear = new TTVisual.TTTextBox();
        this.SphRightNear.Name = 'SphRightNear';
        this.SphRightNear.TabIndex = 31;

        this.CylRightFar = new TTVisual.TTTextBox();
        this.CylRightFar.Name = 'CylRightFar';
        this.CylRightFar.TabIndex = 15;

        this.SphRightFar = new TTVisual.TTTextBox();
        this.SphRightFar.Name = 'SphRightFar';
        this.SphRightFar.TabIndex = 14;

        this.AxRightFar = new TTVisual.TTTextBox();
        this.AxRightFar.Name = 'AxRightFar';
        this.AxRightFar.TabIndex = 16;

        this.SonucAciklamasi = new TTVisual.TTTextBox();
        this.SonucAciklamasi.Multiline = true;
        this.SonucAciklamasi.BackColor = '#F0F0F0';
        this.SonucAciklamasi.ReadOnly = true;
        this.SonucAciklamasi.Name = 'SonucAciklamasi';
        this.SonucAciklamasi.TabIndex = 11;

        this.SonucKodu = new TTVisual.TTTextBox();
        this.SonucKodu.BackColor = '#F0F0F0';
        this.SonucKodu.ReadOnly = true;
        this.SonucKodu.Name = 'SonucKodu';
        this.SonucKodu.TabIndex = 10;

        this.EReceteNo = new TTVisual.TTTextBox();
        this.EReceteNo.BackColor = '#F0F0F0';
        this.EReceteNo.ReadOnly = true;
        this.EReceteNo.Name = 'EReceteNo';
        this.EReceteNo.TabIndex = 9;

        this.GradientLeftNear = new TTVisual.TTTextBox();
        this.GradientLeftNear.Name = 'GradientLeftNear';
        this.GradientLeftNear.TabIndex = 43;

        this.GradientRightNear = new TTVisual.TTTextBox();
        this.GradientRightNear.Name = 'GradientRightNear';
        this.GradientRightNear.TabIndex = 35;

        this.GradientLeftFar = new TTVisual.TTTextBox();
        this.GradientLeftFar.Name = 'GradientLeftFar';
        this.GradientLeftFar.TabIndex = 26;

        this.GradientRightFar = new TTVisual.TTTextBox();
        this.GradientRightFar.Name = 'GradientRightFar';
        this.GradientRightFar.TabIndex = 18;

        this.DiameterLeftNear = new TTVisual.TTTextBox();
        this.DiameterLeftNear.Name = 'DiameterLeftNear';
        this.DiameterLeftNear.TabIndex = 42;

        this.DiameterRightNear = new TTVisual.TTTextBox();
        this.DiameterRightNear.Name = 'DiameterRightNear';
        this.DiameterRightNear.TabIndex = 34;

        this.DiameterLeftFar = new TTVisual.TTTextBox();
        this.DiameterLeftFar.Name = 'DiameterLeftFar';
        this.DiameterLeftFar.TabIndex = 25;

        this.DiameterRightFar = new TTVisual.TTTextBox();
        this.DiameterRightFar.Name = 'DiameterRightFar';
        this.DiameterRightFar.TabIndex = 17;

        this.btnReceteSil = new TTVisual.TTButton();
        this.btnReceteSil.Text = i18n("M20957", "Reçete Sil");
        this.btnReceteSil.Name = 'btnReceteSil';
        this.btnReceteSil.TabIndex = 122;

        this.TemporaryLens = new TTVisual.TTCheckBox();
        this.TemporaryLens.Text = i18n("M14617", "Geçici Lens");
        this.TemporaryLens.Name = 'TemporaryLens';
        this.TemporaryLens.Title = i18n("M14617", "Geçici Lens");
        this.TemporaryLens.TabIndex = 7;

        this.labelSonucAciklamasi = new TTVisual.TTLabel();
        this.labelSonucAciklamasi.Text = i18n("M22088", "Sonuç Açıklaması");
        this.labelSonucAciklamasi.Name = 'labelSonucAciklamasi';
        this.labelSonucAciklamasi.TabIndex = 121;

        this.labelSonucKodu = new TTVisual.TTLabel();
        this.labelSonucKodu.Text = i18n("M22099", "Sonuç Kodu");
        this.labelSonucKodu.Name = 'labelSonucKodu';
        this.labelSonucKodu.TabIndex = 119;

        this.labelEReceteNo = new TTVisual.TTLabel();
        this.labelEReceteNo.Text = i18n("M13824", "E-Reçete Nu.");
        this.labelEReceteNo.Name = 'labelEReceteNo';
        this.labelEReceteNo.TabIndex = 117;

        this.btnReceteKaydet = new TTVisual.TTButton();
        this.btnReceteKaydet.Text = i18n("M20949", "Reçete Kaydet");
        this.btnReceteKaydet.Name = 'btnReceteKaydet';
        this.btnReceteKaydet.TabIndex = 8;

        this.labelGradientLeftNear = new TTVisual.TTLabel();
        this.labelGradientLeftNear.Text = i18n("M13490", "Eğim");
        this.labelGradientLeftNear.Name = 'labelGradientLeftNear';
        this.labelGradientLeftNear.TabIndex = 114;

        this.labelGradientRightFar = new TTVisual.TTLabel();
        this.labelGradientRightFar.Text = i18n("M13490", "Eğim");
        this.labelGradientRightFar.Name = 'labelGradientRightFar';
        this.labelGradientRightFar.TabIndex = 108;

        this.labelDiameterLeftFar = new TTVisual.TTLabel();
        this.labelDiameterLeftFar.Text = 'Çap';
        this.labelDiameterLeftFar.Name = 'labelDiameterLeftFar';
        this.labelDiameterLeftFar.TabIndex = 103;

        this.labelDiameterRightFar = new TTVisual.TTLabel();
        this.labelDiameterRightFar.Text = 'Çap';
        this.labelDiameterRightFar.Name = 'labelDiameterRightFar';
        this.labelDiameterRightFar.TabIndex = 101;

        this.TeleskopikGlassesTypeLeftRead = new TTVisual.TTEnumComboBox();
        this.TeleskopikGlassesTypeLeftRead.DataTypeName = 'TeleskopikGlassesTypeEnum';
        this.TeleskopikGlassesTypeLeftRead.Name = 'TeleskopikGlassesTypeLeftRead';
        this.TeleskopikGlassesTypeLeftRead.TabIndex = 51;

        this.labelTeleskopikGlassesTypeRighRead = new TTVisual.TTLabel();
        this.labelTeleskopikGlassesTypeRighRead.Text = 'Teles. Göz. Tipi';
        this.labelTeleskopikGlassesTypeRighRead.Name = 'labelTeleskopikGlassesTypeRighRead';
        this.labelTeleskopikGlassesTypeRighRead.TabIndex = 98;

        this.TeleskopikGlassesTypeRighRead = new TTVisual.TTEnumComboBox();
        this.TeleskopikGlassesTypeRighRead.DataTypeName = 'TeleskopikGlassesTypeEnum';
        this.TeleskopikGlassesTypeRighRead.Name = 'TeleskopikGlassesTypeRighRead';
        this.TeleskopikGlassesTypeRighRead.TabIndex = 49;

        this.TeleskopikGlassesTypeRighNear = new TTVisual.TTEnumComboBox();
        this.TeleskopikGlassesTypeRighNear.DataTypeName = 'TeleskopikGlassesTypeEnum';
        this.TeleskopikGlassesTypeRighNear.Name = 'TeleskopikGlassesTypeRighNear';
        this.TeleskopikGlassesTypeRighNear.TabIndex = 38;

        this.TeleskopikGlassesTypeLeftNear = new TTVisual.TTEnumComboBox();
        this.TeleskopikGlassesTypeLeftNear.DataTypeName = 'TeleskopikGlassesTypeEnum';
        this.TeleskopikGlassesTypeLeftNear.Name = 'TeleskopikGlassesTypeLeftNear';
        this.TeleskopikGlassesTypeLeftNear.TabIndex = 46;

        this.TeleskopikGlassesTypeLeftFar = new TTVisual.TTEnumComboBox();
        this.TeleskopikGlassesTypeLeftFar.DataTypeName = 'TeleskopikGlassesTypeEnum';
        this.TeleskopikGlassesTypeLeftFar.Name = 'TeleskopikGlassesTypeLeftFar';
        this.TeleskopikGlassesTypeLeftFar.TabIndex = 29;

        this.labelTeleskopikGlassesTypeRightFar = new TTVisual.TTLabel();
        this.labelTeleskopikGlassesTypeRightFar.Text = 'Teles. Göz. Tipi';
        this.labelTeleskopikGlassesTypeRightFar.Name = 'labelTeleskopikGlassesTypeRightFar';
        this.labelTeleskopikGlassesTypeRightFar.TabIndex = 90;

        this.TeleskopikGlassesTypeRightFar = new TTVisual.TTEnumComboBox();
        this.TeleskopikGlassesTypeRightFar.DataTypeName = 'TeleskopikGlassesTypeEnum';
        this.TeleskopikGlassesTypeRightFar.Name = 'TeleskopikGlassesTypeRightFar';
        this.TeleskopikGlassesTypeRightFar.TabIndex = 21;

        this.GlassColorLeftNear = new TTVisual.TTEnumComboBox();
        this.GlassColorLeftNear.DataTypeName = 'GlassColorEnum';
        this.GlassColorLeftNear.Name = 'GlassColorLeftNear';
        this.GlassColorLeftNear.TabIndex = 45;

        this.labelGlassColorLeftFar = new TTVisual.TTLabel();
        this.labelGlassColorLeftFar.Text = i18n("M12165", "Cam Rengi");
        this.labelGlassColorLeftFar.Name = 'labelGlassColorLeftFar';
        this.labelGlassColorLeftFar.TabIndex = 87;

        this.GlassColorLeftFar = new TTVisual.TTEnumComboBox();
        this.GlassColorLeftFar.DataTypeName = 'GlassColorEnum';
        this.GlassColorLeftFar.Name = 'GlassColorLeftFar';
        this.GlassColorLeftFar.TabIndex = 28;

        this.GlassColorRightNear = new TTVisual.TTEnumComboBox();
        this.GlassColorRightNear.DataTypeName = 'GlassColorEnum';
        this.GlassColorRightNear.Name = 'GlassColorRightNear';
        this.GlassColorRightNear.TabIndex = 37;

        this.labelGlassColorRightFar = new TTVisual.TTLabel();
        this.labelGlassColorRightFar.Text = i18n("M12165", "Cam Rengi");
        this.labelGlassColorRightFar.Name = 'labelGlassColorRightFar';
        this.labelGlassColorRightFar.TabIndex = 83;

        this.GlassColorRightFar = new TTVisual.TTEnumComboBox();
        this.GlassColorRightFar.DataTypeName = 'GlassColorEnum';
        this.GlassColorRightFar.Name = 'GlassColorRightFar';
        this.GlassColorRightFar.TabIndex = 20;

        this.labelGlassRightTypeNear = new TTVisual.TTLabel();
        this.labelGlassRightTypeNear.Text = i18n("M12167", "Cam Tipi");
        this.labelGlassRightTypeNear.Name = 'labelGlassRightTypeNear';
        this.labelGlassRightTypeNear.TabIndex = 81;

        this.GlassRightTypeNear = new TTVisual.TTEnumComboBox();
        this.GlassRightTypeNear.DataTypeName = 'GlassTypeEnum';
        this.GlassRightTypeNear.Name = 'GlassRightTypeNear';
        this.GlassRightTypeNear.TabIndex = 36;

        this.GlassLeftTypeNear = new TTVisual.TTEnumComboBox();
        this.GlassLeftTypeNear.DataTypeName = 'GlassTypeEnum';
        this.GlassLeftTypeNear.Name = 'GlassLeftTypeNear';
        this.GlassLeftTypeNear.TabIndex = 44;

        this.GlassLeftTypeFar = new TTVisual.TTEnumComboBox();
        this.GlassLeftTypeFar.DataTypeName = 'GlassTypeEnum';
        this.GlassLeftTypeFar.Name = 'GlassLeftTypeFar';
        this.GlassLeftTypeFar.TabIndex = 27;

        this.labelGlassRightTypeFar = new TTVisual.TTLabel();
        this.labelGlassRightTypeFar.Text = i18n("M12167", "Cam Tipi");
        this.labelGlassRightTypeFar.Name = 'labelGlassRightTypeFar';
        this.labelGlassRightTypeFar.TabIndex = 75;

        this.GlassRightTypeFar = new TTVisual.TTEnumComboBox();
        this.GlassRightTypeFar.DataTypeName = 'GlassTypeEnum';
        this.GlassRightTypeFar.Name = 'GlassRightTypeFar';
        this.GlassRightTypeFar.TabIndex = 19;

        this.labelPrescriptionType = new TTVisual.TTLabel();
        this.labelPrescriptionType.Text = i18n("M20960", "Reçete Tipi");
        this.labelPrescriptionType.Name = 'labelPrescriptionType';
        this.labelPrescriptionType.TabIndex = 73;

        this.PrescriptionType = new TTVisual.TTEnumComboBox();
        this.PrescriptionType.DataTypeName = 'GlassesPrescriptionTypeEnum';
        this.PrescriptionType.Required = true;
        this.PrescriptionType.BackColor = '#FFE3C6';
        this.PrescriptionType.Name = 'PrescriptionType';
        this.PrescriptionType.TabIndex = 6;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 12;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M22752", "Tanı Girişi");
        this.tttabpage1.Name = 'tttabpage1';

        this.SecDiagnosis = new TTVisual.TTGrid();
        this.SecDiagnosis.Name = 'SecDiagnosis';
        this.SecDiagnosis.TabIndex = 0;

        this.AddToHistorySecDiagnosisGrid = new TTVisual.TTCheckBoxColumn();
        this.AddToHistorySecDiagnosisGrid.DataMember = 'AddToHistory';
        this.AddToHistorySecDiagnosisGrid.DisplayIndex = 0;
        this.AddToHistorySecDiagnosisGrid.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.AddToHistorySecDiagnosisGrid.Name = 'AddToHistorySecDiagnosisGrid';
        this.AddToHistorySecDiagnosisGrid.Width = 80;

        this.DiagnoseSecDiagnosisGrid = new TTVisual.TTListBoxColumn();
        this.DiagnoseSecDiagnosisGrid.ListDefName = 'DiagnosisListDefinition';
        this.DiagnoseSecDiagnosisGrid.DataMember = 'Diagnose';
        this.DiagnoseSecDiagnosisGrid.DisplayIndex = 1;
        this.DiagnoseSecDiagnosisGrid.HeaderText = i18n("M22736", "Tanı");
        this.DiagnoseSecDiagnosisGrid.Name = 'DiagnoseSecDiagnosisGrid';
        this.DiagnoseSecDiagnosisGrid.Width = 300;

        this.IsMainDiagnoseSecDiagnosisGrid = new TTVisual.TTCheckBoxColumn();
        this.IsMainDiagnoseSecDiagnosisGrid.DataMember = 'IsMainDiagnose';
        this.IsMainDiagnoseSecDiagnosisGrid.DisplayIndex = 2;
        this.IsMainDiagnoseSecDiagnosisGrid.HeaderText = i18n("M10926", "Ana Tanı");
        this.IsMainDiagnoseSecDiagnosisGrid.Name = 'IsMainDiagnoseSecDiagnosisGrid';
        this.IsMainDiagnoseSecDiagnosisGrid.Width = 80;

        this.ResponsibleUserSecDiagnosisGrid = new TTVisual.TTListBoxColumn();
        this.ResponsibleUserSecDiagnosisGrid.ListDefName = 'UserListDefinition';
        this.ResponsibleUserSecDiagnosisGrid.DataMember = 'ResponsibleUser';
        this.ResponsibleUserSecDiagnosisGrid.DisplayIndex = 3;
        this.ResponsibleUserSecDiagnosisGrid.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.ResponsibleUserSecDiagnosisGrid.Name = 'ResponsibleUserSecDiagnosisGrid';
        this.ResponsibleUserSecDiagnosisGrid.Width = 300;

        this.DiagnoseDateSecDiagnosisGrid = new TTVisual.TTDateTimePickerColumn();
        this.DiagnoseDateSecDiagnosisGrid.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.DiagnoseDateSecDiagnosisGrid.DataMember = 'DiagnoseDate';
        this.DiagnoseDateSecDiagnosisGrid.DisplayIndex = 4;
        this.DiagnoseDateSecDiagnosisGrid.HeaderText = i18n("M22750", "Tanı Giriş Tarihi  ");
        this.DiagnoseDateSecDiagnosisGrid.Name = 'DiagnoseDateSecDiagnosisGrid';
        this.DiagnoseDateSecDiagnosisGrid.Width = 180;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = i18n("M24028", "Vaka Tanıları");
        this.tttabpage2.Name = 'tttabpage2';

        this.DiagnosisDiagnosisGrid = new TTVisual.TTGrid();
        this.DiagnosisDiagnosisGrid.ReadOnly = true;
        this.DiagnosisDiagnosisGrid.Name = 'DiagnosisDiagnosisGrid';
        this.DiagnosisDiagnosisGrid.TabIndex = 0;

        this.AddToHistoryDiagnosisGrid = new TTVisual.TTCheckBoxColumn();
        this.AddToHistoryDiagnosisGrid.DataMember = 'AddToHistory';
        this.AddToHistoryDiagnosisGrid.DisplayIndex = 0;
        this.AddToHistoryDiagnosisGrid.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.AddToHistoryDiagnosisGrid.Name = 'AddToHistoryDiagnosisGrid';
        this.AddToHistoryDiagnosisGrid.Width = 80;

        this.DiagnoseDiagnosisGrid = new TTVisual.TTListBoxColumn();
        this.DiagnoseDiagnosisGrid.ListDefName = 'DiagnosisListDefinition';
        this.DiagnoseDiagnosisGrid.DataMember = 'Diagnose';
        this.DiagnoseDiagnosisGrid.DisplayIndex = 1;
        this.DiagnoseDiagnosisGrid.HeaderText = i18n("M22736", "Tanı");
        this.DiagnoseDiagnosisGrid.Name = 'DiagnoseDiagnosisGrid';
        this.DiagnoseDiagnosisGrid.Width = 300;

        this.DiagnosisTypeDiagnosisGrid = new TTVisual.TTEnumComboBoxColumn();
        this.DiagnosisTypeDiagnosisGrid.DataTypeName = 'DiagnosisTypeEnum';
        this.DiagnosisTypeDiagnosisGrid.DataMember = 'DiagnosisType';
        this.DiagnosisTypeDiagnosisGrid.DisplayIndex = 2;
        this.DiagnosisTypeDiagnosisGrid.HeaderText = i18n("M22781", "Tanı Tipi");
        this.DiagnosisTypeDiagnosisGrid.Name = 'DiagnosisTypeDiagnosisGrid';
        this.DiagnosisTypeDiagnosisGrid.Width = 80;

        this.IsMainDiagnoseDiagnosisGrid = new TTVisual.TTCheckBoxColumn();
        this.IsMainDiagnoseDiagnosisGrid.DataMember = 'IsMainDiagnose';
        this.IsMainDiagnoseDiagnosisGrid.DisplayIndex = 3;
        this.IsMainDiagnoseDiagnosisGrid.HeaderText = i18n("M10926", "Ana Tanı");
        this.IsMainDiagnoseDiagnosisGrid.Name = 'IsMainDiagnoseDiagnosisGrid';
        this.IsMainDiagnoseDiagnosisGrid.Width = 80;

        this.ResponsibleUserDiagnosisGrid = new TTVisual.TTListBoxColumn();
        this.ResponsibleUserDiagnosisGrid.ListDefName = 'UserListDefinition';
        this.ResponsibleUserDiagnosisGrid.DataMember = 'ResponsibleUser';
        this.ResponsibleUserDiagnosisGrid.DisplayIndex = 4;
        this.ResponsibleUserDiagnosisGrid.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.ResponsibleUserDiagnosisGrid.Name = 'ResponsibleUserDiagnosisGrid';
        this.ResponsibleUserDiagnosisGrid.Width = 300;

        this.DiagnoseDateDiagnosisGrid = new TTVisual.TTDateTimePickerColumn();
        this.DiagnoseDateDiagnosisGrid.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.DiagnoseDateDiagnosisGrid.DataMember = 'DiagnoseDate';
        this.DiagnoseDateDiagnosisGrid.DisplayIndex = 5;
        this.DiagnoseDateDiagnosisGrid.HeaderText = i18n("M22750", "Tanı Giriş Tarihi  ");
        this.DiagnoseDateDiagnosisGrid.Name = 'DiagnoseDateDiagnosisGrid';
        this.DiagnoseDateDiagnosisGrid.Width = 180;

        this.EntryActionTypeDiagnosisGrid = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionTypeDiagnosisGrid.DataTypeName = 'ActionTypeEnum';
        this.EntryActionTypeDiagnosisGrid.DataMember = 'EntryActionType';
        this.EntryActionTypeDiagnosisGrid.DisplayIndex = 6;
        this.EntryActionTypeDiagnosisGrid.HeaderText = 'Tanın Girildiği İşlem';
        this.EntryActionTypeDiagnosisGrid.Name = 'EntryActionTypeDiagnosisGrid';
        this.EntryActionTypeDiagnosisGrid.Width = 80;

        this.AxRightNear = new TTVisual.TTTextBox();
        this.AxRightNear.Name = 'AxRightNear';
        this.AxRightNear.TabIndex = 33;

        this.AxLeftNear = new TTVisual.TTTextBox();
        this.AxLeftNear.Name = 'AxLeftNear';
        this.AxLeftNear.TabIndex = 41;

        this.AxLeftFar = new TTVisual.TTTextBox();
        this.AxLeftFar.Name = 'AxLeftFar';
        this.AxLeftFar.TabIndex = 24;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = '#F0F0F0';
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Name = 'ProtocolNo';
        this.ProtocolNo.TabIndex = 1;

        this.ReasonForAdmission = new TTVisual.TTTextBox();
        this.ReasonForAdmission.BackColor = '#F0F0F0';
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.Name = 'ReasonForAdmission';
        this.ReasonForAdmission.TabIndex = 2;

        this.PatientGroup = new TTVisual.TTTextBox();
        this.PatientGroup.BackColor = '#F0F0F0';
        this.PatientGroup.ReadOnly = true;
        this.PatientGroup.Name = 'PatientGroup';
        this.PatientGroup.TabIndex = 3;

        this.RecordID = new TTVisual.TTTextBox();
        this.RecordID.BackColor = '#F0F0F0';
        this.RecordID.ReadOnly = true;
        this.RecordID.Name = 'RecordID';
        this.RecordID.TabIndex = 4;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16928", "İşlemi Yapan Doktor");
        this.labelProcedureDoctor.Name = 'labelProcedureDoctor';
        this.labelProcedureDoctor.TabIndex = 69;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.ListDefName = 'DoctorListDefinition';
        this.ProcedureDoctor.Name = 'ProcedureDoctor';
        this.ProcedureDoctor.TabIndex = 5;

        this.labelAxRight = new TTVisual.TTLabel();
        this.labelAxRight.Text = 'AX.';
        this.labelAxRight.Name = 'labelAxRight';
        this.labelAxRight.TabIndex = 55;

        this.labelAxLeft = new TTVisual.TTLabel();
        this.labelAxLeft.Text = 'AX.';
        this.labelAxLeft.Name = 'labelAxLeft';
        this.labelAxLeft.TabIndex = 60;

        this.labelCylRight = new TTVisual.TTLabel();
        this.labelCylRight.Text = 'CYL.';
        this.labelCylRight.Name = 'labelCylRight';
        this.labelCylRight.TabIndex = 54;

        this.labelCylLeft = new TTVisual.TTLabel();
        this.labelCylLeft.Text = 'CYL.';
        this.labelCylLeft.Name = 'labelCylLeft';
        this.labelCylLeft.TabIndex = 59;

        this.labelSphLeft = new TTVisual.TTLabel();
        this.labelSphLeft.Text = 'SPH.';
        this.labelSphLeft.Name = 'labelSphLeft';
        this.labelSphLeft.TabIndex = 58;

        this.labelSphRight = new TTVisual.TTLabel();
        this.labelSphRight.Text = 'SPH.';
        this.labelSphRight.Name = 'labelSphRight';
        this.labelSphRight.TabIndex = 53;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = 'Protocol No';
        this.labelProtocolNo.Name = 'labelProtocolNo';
        this.labelProtocolNo.TabIndex = 48;

        this.labelReportDate = new TTVisual.TTLabel();
        this.labelReportDate.Text = 'Tarih';
        this.labelReportDate.Name = 'labelReportDate';
        this.labelReportDate.TabIndex = 47;

        this.ReportDate = new TTVisual.TTDateTimePicker();
        this.ReportDate.BackColor = '#F0F0F0';
        this.ReportDate.Format = DateTimePickerFormat.Long;
        this.ReportDate.Enabled = false;
        this.ReportDate.Name = 'ReportDate';
        this.ReportDate.TabIndex = 0;

        this.cbxVitrumNear = new TTVisual.TTCheckBox();
        this.cbxVitrumNear.Text = i18n("M24243", "Yakın");
        this.cbxVitrumNear.Name = 'cbxVitrumNear';
        this.cbxVitrumNear.Title = i18n("M24243", "Yakın");
        this.cbxVitrumNear.TabIndex = 30;

        this.cbxVitrumCloseReading = new TTVisual.TTCheckBox();
        this.cbxVitrumCloseReading.Text = i18n("M24244", "Yakın Okuma Kepi");
        this.cbxVitrumCloseReading.Name = 'cbxVitrumCloseReading';
        this.cbxVitrumCloseReading.Title = i18n("M24244", "Yakın Okuma Kepi");
        this.cbxVitrumCloseReading.TabIndex = 47;

        this.cbxVitrumFar = new TTVisual.TTCheckBox();
        this.cbxVitrumFar.Text = 'Uzak';
        this.cbxVitrumFar.Name = 'cbxVitrumFar';
        this.cbxVitrumFar.Title = 'Uzak';
        this.cbxVitrumFar.TabIndex = 13;

        this.labelVitrum = new TTVisual.TTLabel();
        this.labelVitrum.Text = i18n("M24175", "Vitrum");
        this.labelVitrum.Name = 'labelVitrum';
        this.labelVitrum.TabIndex = 52;

        this.labelRight = new TTVisual.TTLabel();
        this.labelRight.Text = 'SAĞ';
        this.labelRight.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelRight.Name = 'labelRight';
        this.labelRight.TabIndex = 66;

        this.labelLeft = new TTVisual.TTLabel();
        this.labelLeft.Text = 'SOL';
        this.labelLeft.Font = 'Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelLeft.Name = 'labelLeft';
        this.labelLeft.TabIndex = 67;

        this.labelReasonForAdmission = new TTVisual.TTLabel();
        this.labelReasonForAdmission.Text = i18n("M17026", "Kabul Sebebi");
        this.labelReasonForAdmission.Name = 'labelReasonForAdmission';
        this.labelReasonForAdmission.TabIndex = 49;

        this.labelPatientGroup = new TTVisual.TTLabel();
        this.labelPatientGroup.Text = i18n("M15222", "Hasta Grubu");
        this.labelPatientGroup.Name = 'labelPatientGroup';
        this.labelPatientGroup.TabIndex = 50;

        this.labelRecordID = new TTVisual.TTLabel();
        this.labelRecordID.Text = i18n("M21784", "SGK Sicil No");
        this.labelRecordID.Name = 'labelRecordID';
        this.labelRecordID.TabIndex = 51;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M23153", "Teleskopik Gözlük Tipi");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 48;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M23153", "Teleskopik Gözlük Tipi");
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 50;

        this.SecDiagnosisColumns = [this.AddToHistorySecDiagnosisGrid, this.DiagnoseSecDiagnosisGrid, this.IsMainDiagnoseSecDiagnosisGrid, this.ResponsibleUserSecDiagnosisGrid, this.DiagnoseDateSecDiagnosisGrid];
        this.DiagnosisDiagnosisGridColumns = [this.AddToHistoryDiagnosisGrid, this.DiagnoseDiagnosisGrid, this.DiagnosisTypeDiagnosisGrid, this.IsMainDiagnoseDiagnosisGrid, this.ResponsibleUserDiagnosisGrid, this.DiagnoseDateDiagnosisGrid, this.EntryActionTypeDiagnosisGrid];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2];
        this.tttabpage1.Controls = [this.SecDiagnosis];
        this.tttabpage2.Controls = [this.DiagnosisDiagnosisGrid];
        this.Controls = [this.CylLeftNear, this.CylLeftFar, this.SphLeftNear, this.SphLeftFar, this.CylRightNear, this.SphRightNear, this.CylRightFar, this.SphRightFar, this.AxRightFar, this.SonucAciklamasi, this.SonucKodu, this.EReceteNo, this.GradientLeftNear, this.GradientRightNear, this.GradientLeftFar, this.GradientRightFar, this.DiameterLeftNear, this.DiameterRightNear, this.DiameterLeftFar, this.DiameterRightFar, this.btnReceteSil, this.TemporaryLens, this.labelSonucAciklamasi, this.labelSonucKodu, this.labelEReceteNo, this.btnReceteKaydet, this.labelGradientLeftNear, this.labelGradientRightFar, this.labelDiameterLeftFar, this.labelDiameterRightFar, this.TeleskopikGlassesTypeLeftRead, this.labelTeleskopikGlassesTypeRighRead, this.TeleskopikGlassesTypeRighRead, this.TeleskopikGlassesTypeRighNear, this.TeleskopikGlassesTypeLeftNear, this.TeleskopikGlassesTypeLeftFar, this.labelTeleskopikGlassesTypeRightFar, this.TeleskopikGlassesTypeRightFar, this.GlassColorLeftNear, this.labelGlassColorLeftFar, this.GlassColorLeftFar, this.GlassColorRightNear, this.labelGlassColorRightFar, this.GlassColorRightFar, this.labelGlassRightTypeNear, this.GlassRightTypeNear, this.GlassLeftTypeNear, this.GlassLeftTypeFar, this.labelGlassRightTypeFar, this.GlassRightTypeFar, this.labelPrescriptionType, this.PrescriptionType, this.tttabcontrol1, this.tttabpage1, this.SecDiagnosis, this.AddToHistorySecDiagnosisGrid, this.DiagnoseSecDiagnosisGrid, this.IsMainDiagnoseSecDiagnosisGrid, this.ResponsibleUserSecDiagnosisGrid, this.DiagnoseDateSecDiagnosisGrid, this.tttabpage2, this.DiagnosisDiagnosisGrid, this.AddToHistoryDiagnosisGrid, this.DiagnoseDiagnosisGrid, this.DiagnosisTypeDiagnosisGrid, this.IsMainDiagnoseDiagnosisGrid, this.ResponsibleUserDiagnosisGrid, this.DiagnoseDateDiagnosisGrid, this.EntryActionTypeDiagnosisGrid, this.AxRightNear, this.AxLeftNear, this.AxLeftFar, this.ProtocolNo, this.ReasonForAdmission, this.PatientGroup, this.RecordID, this.labelProcedureDoctor, this.ProcedureDoctor, this.labelAxRight, this.labelAxLeft, this.labelCylRight, this.labelCylLeft, this.labelSphLeft, this.labelSphRight, this.labelProtocolNo, this.labelReportDate, this.ReportDate, this.cbxVitrumNear, this.cbxVitrumCloseReading, this.cbxVitrumFar, this.labelVitrum, this.labelRight, this.labelLeft, this.labelReasonForAdmission, this.labelPatientGroup, this.labelRecordID, this.ttlabel1, this.ttlabel2];

    }


}
