//$C985ABC3
import { Component, OnInit, EventEmitter, Output, Renderer2, ViewChild } from '@angular/core';
import {
    MedicalStuffReportFormViewModel, MedulaResult, PrepareSignedSearchReportContent_Input, SendSignedSearchReportContent_Input, eRaporOnayCevapDVO, MedicalStuffReportApproveModel, AddTibbiMalzemeClass, AddDiagnosisClass, ChangeReportDescriptionClass
} from './MedicalStuffReportFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ResUser, DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { MedicalStuff } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalStuffGroup } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalStuffUsageType } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { MedicalStuffReport, MedicalStuffPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';

import { ModalInfo, ModalActionResult, ModalStateService } from "Fw/Models/ModalInfo";
import { TTTextBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTTextBoxColumn';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { UserHelper } from 'app/Helper/UserHelper';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { TTEnumComboBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { UsernamePwdInput, UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { UsernamePwdFormViewModel } from 'Fw/Components/UsernamePwdFormComponent';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { DxSelectBoxComponent } from 'devextreme-angular';
import { UserTemplateModel } from '../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel';
import { TibbiMalzemeERaporIslemleri } from 'app/NebulaClient/Services/External/TibbiMalzemeERaporIslemleri';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { CommonHelper } from 'app/Helper/CommonHelper';

@Component({
    selector: 'MedicalStuffReportForm',
    templateUrl: './MedicalStuffReportForm.html',
    providers: [MessageService, { provide: IESignatureService, useClass: ESignatureService }],
    outputs: ['OnClosing']
})
export class MedicalStuffReportForm extends TTVisual.TTForm implements OnInit {
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    MedicalStuffPlaceOfUsage: TTVisual.TTObjectListBox;
    StuffUsageType: TTVisual.TTObjectListBox;
    MedicalStuffGroup: TTVisual.TTObjectListBox;
    StartDate: TTVisual.ITTDateTimePicker;
    EndDate: TTVisual.ITTDateTimePicker;
    ReportDecision: TTVisual.ITTRichTextBoxControl;
    Description: TTVisual.ITTRichTextBoxControl;
    MedulaDescription: TTVisual.ITTTextBox;
    ReportNo: TTVisual.ITTTextBox;
    RaporTakipNo: TTVisual.ITTTextBox;
    StuffAmount: TTVisual.ITTTextBoxColumn;
    StuffDescription: TTVisual.ITTTextBoxColumn;
    DiagnosisDetail: TTVisual.ITTTextBox;
    ReportListView: TTVisual.ITTListView;
    MedulaReportListView: TTVisual.ITTListView;
    txtStuffName: TTVisual.ITTTextBoxColumn;
    txtStuffCode: TTVisual.ITTTextBoxColumn;
    PeriodUnitType: TTVisual.ITTEnumComboBox;
    PeriodUnit: TTVisual.ITTTextBoxColumn;
    lstTabip2: TTVisual.ITTObjectListBox;
    lstTabip3: TTVisual.ITTObjectListBox;
    lstDiagnosisAddedToReport: TTVisual.ITTObjectListBox;

    public addedMedicalStuff: MedicalStuff = null;
    public addedDiagnosis: DiagnosisDefinition = null;

    openedReportAsPopUp: boolean = false;
    selecttedStuffName: string;
    selecttedStuffCode: string;
    IsCompletedUnsuccessfullyState: boolean = true;
    isNewState: boolean;
    MedicalStuffDef: TTVisual.ITTObjectListBox;
    labelTabip2: string;
    labelTabip3: string;
    chkFtrHeyetRaporu: TTVisual.ITTCheckBox;
    lblTabip2: TTVisual.ITTLabel;
    lblTabip3: TTVisual.ITTLabel;
    cmbRaporSureTuru: TTVisual.ITTEnumComboBox;
    medulaReportList: any;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public enableMedulaPasswordEntrance: boolean = false;
    public enableStartDateBounds: boolean = false;
    public showMainDiagnoseDefinitions: boolean = false;


    public globalReportObjectID: any;
    public ResultSetList = null;
    public gridMedulaStuffColumns = [];

    public ReportDurationComboItems;

    public addExtraMaterialPopUp = false;
    public changeDescriptionPopUp = false;
    public addExtraDiagnosisPopUp = false;
    @ViewChild('TemplateCombo') TemplateCombo: DxSelectBoxComponent;
    public userTemplateName;

    public medicalStuffColumns = [
        {
            caption: 'Kodu',
            dataField: 'MedicalStuffDef.Code',
            allowEditing: false,
            width: '10%',
            cellTemplate: 'medicalStuffCodeTemplate'
        },
        {
            caption: 'Adı',
            dataField: 'MedicalStuffDef.Name',
            allowEditing: false,
            width: '22%',
            cellTemplate: 'medicalStuffNameTemplate'
        },
        {
            caption: 'Malzeme Grubu',
            dataField: 'MedicalStuffGroup',
            width: '15%',
            cellTemplate: 'medicalStuffGroupTemplate'
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
        {
            caption: 'Açıklama',
            dataField: 'StuffDescription',
            width: '12%',
            cellTemplate: 'stuffDescriptionTemplate'
        },
    ];

    EtkinMaddeColumns = [];
    public demographicEpisodeAction: Guid;
    public lastSelectedReportObjectId: string;
    public newCreatedPrescriptionObject: MedicalStuffPrescription;
    public PrepareSignedReportContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedReportContent';
    public PrepareSignedApprovalReportContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedApprovalReportContent';
    public PrepareSignedDeleteReportContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedDeleteReportContent';
    public PrepareSignedSearchReportContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedSearchReportContent';
    public SendSignedReportContentUrl: string = '/api/MedicalStuffReportService/SendSignedReportContent';
    public SendSignedApprovalReportContentUrl: string = '/api/MedicalStuffReportService/SendSignedApprovalReportContent';
    public SendSignedDeleteReportContentUrl: string = '/api/MedicalStuffReportService/SendSignedDeleteReportContent';
    public SendSignedSearchReportContentUrl: string = '/api/MedicalStuffReportService/SendSignedSearchReportContent';

    public PrepareSignedDiagnosisReportContentUrl: string = '/api/MedicalStuffReportService/PrepareSignedDiagnosisReportContent';
    public SendSignedDiagnosisReportContentUrl: string = '/api/MedicalStuffReportService/SendSignedDiagnosisReportContent';


    public medicalStuffReportFormViewModel: MedicalStuffReportFormViewModel = new MedicalStuffReportFormViewModel();

    public get _MedicalStuffReport(): MedicalStuffReport {
        return this._TTObject as MedicalStuffReport;
    }
    public MedicalStuffReportForm_DocumentUrl: string = '/api/MedicalStuffReportService/MedicalStuffReportForm';

    constructor(public httpService: NeHttpService,
        public messageService: MessageService,
        public objectContextService: ObjectContextService,
        public signService: IESignatureService,
        private sideBarMenuService: ISidebarMenuService,
        protected modalService: IModalService,
        private renderer: Renderer2,
        protected modalStateService: ModalStateService) {
        super('MEDICALSTUFFREPORT', 'MedicalStuffReportForm');
        this._DocumentServiceUrl = this.MedicalStuffReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.ReportDurationComboItems = [
            {
                key: "0",
                value: "3 Ay"
            },
            {
                key: "1",
                value: "6 Ay"
            },
            {
                key: "2",
                value: "1 Yıl"
            },
            {
                key: "3",
                value: "2 Yıl"
            },

        ];
    }
    public _modalInfo: ModalInfo;

    @Output() sendMedicalStuffViewModel: EventEmitter<any> = new EventEmitter<any>();

    public setInputParam(value: MedicalStuffReport) {
        if (value != null && !value.IsNew)
            this.ObjectID = value.ObjectID;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
        if (value == null)
            this.openedReportAsPopUp = false;
        else
            this.openedReportAsPopUp = true;
    }

    // ***** Method declarations start *****
    comingViewModel(data: any) {
        this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel = data;
        if (this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel != null && this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList != null) {
            if (this.medicalStuffReportFormViewModel.diagnosisCodeList == null)
                this.medicalStuffReportFormViewModel.diagnosisCodeList = new Array<string>();

            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.DiagnosisDetail == null) {
                this.medicalStuffReportFormViewModel._MedicalStuffReport.DiagnosisDetail = "";
                for (let diagnosis of this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList) {
                    let code: string = null;
                    if (this.medicalStuffReportFormViewModel.diagnosisCodeList != null && this.medicalStuffReportFormViewModel.diagnosisCodeList.length > 0)
                        code = this.medicalStuffReportFormViewModel.diagnosisCodeList.find(t => t === diagnosis.DiagnoseCode);
                    if (code == null) {
                        this.medicalStuffReportFormViewModel.diagnosisCodeList.push(diagnosis.DiagnoseCode);
                        this.medicalStuffReportFormViewModel._MedicalStuffReport.DiagnosisDetail += diagnosis.DiagnoseName + " ";
                    }
                }
            }
            else {
                if (this.medicalStuffReportFormViewModel.diagnosisCodeList.length == 0) {
                    for (let diagnosis of data.ReportDiagnosisGridList) {
                        this.medicalStuffReportFormViewModel.diagnosisCodeList.push(diagnosis.DiagnoseCode);
                    }
                }
                if (this.medicalStuffReportFormViewModel.diagnosisCodeList != null && this.medicalStuffReportFormViewModel.diagnosisCodeList.length > 0) {
                    for (let diagnosis of this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList) {
                        let code: string = null;
                        if (this.medicalStuffReportFormViewModel.diagnosisCodeList != null && this.medicalStuffReportFormViewModel.diagnosisCodeList.length > 0)
                            code = this.medicalStuffReportFormViewModel.diagnosisCodeList.find(t => t === diagnosis.DiagnoseCode);
                        if (code == null) {
                            this.medicalStuffReportFormViewModel.diagnosisCodeList.push(diagnosis.DiagnoseCode);
                            this.medicalStuffReportFormViewModel._MedicalStuffReport.DiagnosisDetail += diagnosis.DiagnoseName + " ";
                        }
                    }
                }
            }
        }
    }
    public actionIdForDemografic(): void {
        if (this._MedicalStuffReport.MasterAction != null) {
            if (typeof this._MedicalStuffReport.MasterAction === "string") {
                this.demographicEpisodeAction = this._MedicalStuffReport.MasterAction;
                //return this._MedicalStuffReport.MasterAction;
            }
            else {
                this.demographicEpisodeAction = this._MedicalStuffReport.MasterAction.ObjectID;
                //return this._MedicalStuffReport.MasterAction.ObjectID;
            }
        }
        //this.demographicEpisodeAction=this._MedicalStuffReport.ObjectID;
        //return this._MedicalStuffReport.ObjectID;

    }
    // *****Method declarations end *****

    async medicalStuffGroupChange(data, row) {
        row.data.MedicalStuffGroup = data;
    }

    async medicalStuffPlaceOfUsageChange(data, row) {
        row.data.PlaceOfUsage = data;
    }

    async medicalStuffPeriodUnitChange(data, row) {
        row.data.PeriodUnitType = data;
    }

    public initViewModel(): void {
        this._TTObject = new MedicalStuffReport();
        this.medicalStuffReportFormViewModel = new MedicalStuffReportFormViewModel();
        this._ViewModel = this.medicalStuffReportFormViewModel;
        this.medicalStuffReportFormViewModel._MedicalStuffReport = this._TTObject as MedicalStuffReport;

        this.medicalStuffReportFormViewModel._MedicalStuffReport.ProcedureDoctor = new ResUser();
        this.medicalStuffReportFormViewModel._MedicalStuffReport.MedicalStuff = new Array<MedicalStuff>();
        this.medicalStuffReportFormViewModel._MedicalStuffReport.ThirdDoctor = new ResUser();
        this.medicalStuffReportFormViewModel._MedicalStuffReport.SecondDoctor = new ResUser();

    }

    public loadViewModel() {
        let that = this;
        that.medicalStuffReportFormViewModel = this._ViewModel as MedicalStuffReportFormViewModel;
        that._TTObject = this.medicalStuffReportFormViewModel._MedicalStuffReport;
        if (this.medicalStuffReportFormViewModel == null)
            this.medicalStuffReportFormViewModel = new MedicalStuffReportFormViewModel();

        if (this.medicalStuffReportFormViewModel._MedicalStuffReport == null)
            this.medicalStuffReportFormViewModel._MedicalStuffReport = new MedicalStuffReport();

        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.CurrentStateDefID.valueOf() == MedicalStuffReport.MedicalStuffReportStates.New.id)
            this.isNewState = true;
        else
            this.isNewState = false;

        let procedureDoctorObjectID = that.medicalStuffReportFormViewModel._MedicalStuffReport["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.medicalStuffReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.medicalStuffReportFormViewModel._MedicalStuffReport.ProcedureDoctor = procedureDoctor;
            }
        }
        let thirdDoctorObjectID = that.medicalStuffReportFormViewModel._MedicalStuffReport["ThirdDoctor"];
        if (thirdDoctorObjectID != null && (typeof thirdDoctorObjectID === "string")) {
            let thirdDoctor = that.medicalStuffReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === thirdDoctorObjectID.toString());
            if (thirdDoctor) {
                that.medicalStuffReportFormViewModel._MedicalStuffReport.ThirdDoctor = thirdDoctor;
            }
        }
        let secondDoctorObjectID = that.medicalStuffReportFormViewModel._MedicalStuffReport["SecondDoctor"];
        if (secondDoctorObjectID != null && (typeof secondDoctorObjectID === "string")) {
            let secondDoctor = that.medicalStuffReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === secondDoctorObjectID.toString());
            if (secondDoctor) {
                that.medicalStuffReportFormViewModel._MedicalStuffReport.SecondDoctor = secondDoctor;
            }
        }

        that.medicalStuffReportFormViewModel._MedicalStuffReport.MedicalStuff = that.medicalStuffReportFormViewModel.MedicalStuffGridGridList;
        for (let detailItem of that.medicalStuffReportFormViewModel.MedicalStuffGridGridList) {
            let medicalStuffDefObjectID = detailItem["MedicalStuffDef"];
            if (medicalStuffDefObjectID != null && (typeof medicalStuffDefObjectID === "string")) {
                let medicalStuffDef = that.medicalStuffReportFormViewModel.MedicalStuffDefinitions.find(o => o.ObjectID.toString() === medicalStuffDefObjectID.toString());
                if (medicalStuffDef) {
                    detailItem.MedicalStuffDef = medicalStuffDef;
                }
            }
            let medicalStuffGroupObjectID = detailItem["MedicalStuffGroup"];
            if (medicalStuffGroupObjectID != null && (typeof medicalStuffGroupObjectID === "string")) {
                let medicalStuffGroup = that.medicalStuffReportFormViewModel.MedicalStuffGroups.find(o => o.ObjectID.toString() === medicalStuffGroupObjectID.toString());
                if (medicalStuffGroup) {
                    detailItem.MedicalStuffGroup = medicalStuffGroup;
                }
            }
            let medicalStuffUsageTypeObjectID = detailItem["MedicalStuffUsageType"];
            if (medicalStuffUsageTypeObjectID != null && (typeof medicalStuffUsageTypeObjectID === "string")) {
                let medicalStuffUsageType = that.medicalStuffReportFormViewModel.MedicalStuffUsageTypes.find(o => o.ObjectID.toString() === medicalStuffUsageTypeObjectID.toString());
                if (medicalStuffUsageType) {
                    detailItem.MedicalStuffUsageType = medicalStuffUsageType;
                }
            }
            let medicalStuffPlaceOfUsageObjectID = detailItem["MedicalStuffPlaceOfUsage"];
            if (medicalStuffPlaceOfUsageObjectID != null && (typeof medicalStuffPlaceOfUsageObjectID === "string")) {
                let medicalStuffPlaceOfUsage = that.medicalStuffReportFormViewModel.MedicalStuffPlaceOfUsages.find(o => o.ObjectID.toString() === medicalStuffPlaceOfUsageObjectID.toString());
                if (medicalStuffPlaceOfUsage) {
                    detailItem.MedicalStuffPlaceOfUsage = medicalStuffPlaceOfUsage;
                }
            }
        }


        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate == null || this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate == undefined)
            this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate = new Date();
        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.IsNew == true && (this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate == null || this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate == undefined))
            this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = new Date().AddYears(1);

        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.MedulaDescription != null) {
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.IsSendedMedula == true)
                this.MedulaDescription.BackColor = "#c1ffc1"; //#b6fcd5 66FFCC
            else
                this.MedulaDescription.BackColor = "#f39999"; //f08080
        }

        this.actionIdForDemografic();
        this.GenerateColumns();

        if (this.enableStartDateBounds == true) {
            this.StartDate.Min = this.medicalStuffReportFormViewModel.minReportDate;
            this.StartDate.Max = this.medicalStuffReportFormViewModel.maxReportDate;
        }
    }

    public createPrescription(): void {
        /*let that = this;
        if (that.newCreatedPrescriptionObject == null) {
            let apiUrl: string = '/api/MedicalStuffReportService/GetMedicalStuffPrescriptionObject?lastSelectedReportObjectId=' + that.lastSelectedReportObjectId;
            this.httpService.get<MedicalStuffPrescription>(apiUrl).then(response => {
                that.newCreatedPrescriptionObject = response;
            }).catch(error => {
                console.log(error);
            });
        }*/

    }

    public selectReportDuration(event: any) {
        if (event.itemData != null) {
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate != null) {
                if (event.itemData.key == "0" || event.itemData.key == "1") { //3 - 6 - 1 - 2
                    let month = 3 * (+event.itemData.key + 1);
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate.AddMonths(month);
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.Duration = month;
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.DurationType = PeriodUnitTypeEnum.MonthPeriod;
                } else if (event.itemData.key == "2" || event.itemData.key == "3") { //3 - 6 - 1 - 2
                    let year = +event.itemData.key - 1;
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate.AddYears(year);
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.Duration = year;
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.DurationType = PeriodUnitTypeEnum.YearPeriod;
                }
            } else {
                TTVisual.InfoBox.Alert("Uyarı", i18n("M18392", "Lütfen Rapor Başlangıç Tarihini Giriniz!"), MessageIconEnum.WarningMessage);
            }
        }
    }

    public async Print() {
    }

    public resetSavedPassword() {
        let savePwd = window.sessionStorage.getItem('savePasswordForSession')
        if (savePwd == 'true') {
            window.sessionStorage.setItem('MedulaUsername', '');
            window.sessionStorage.setItem('MedulaPwd', '');
            window.sessionStorage.setItem('savePasswordForSession', 'false');
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
            this.medicalStuffReportFormViewModel.medulaUsername = params.userName;
            this.medicalStuffReportFormViewModel.medulaPassword = params.password;
        }
    }

    public async MedulaPasswordApprovePanel(approveModel: MedicalStuffReportApproveModel): Promise<void> {
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
            approveModel.medulaUsername = params.userName;
            approveModel.medulaPassword = params.password;
        }
    }

    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {

            if (this.medicalStuffReportFormViewModel.selectedUserTemplate == null || (this.medicalStuffReportFormViewModel.selectedUserTemplate.ObjectID != event.itemData.ObjectID)) {
                this.medicalStuffReportFormViewModel.selectedUserTemplate = event.itemData;
                const that = this;
                this.loadPanelOperation(true, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                that.loadReportByTemplate();
                this.loadPanelOperation(false, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                //this.onProcedureDoctorChanged(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ProcedureDoctor);
            }
        }

    }

    protected async loadReportByTemplate() {
        try {


            let fullApiUrl: string = "";


            fullApiUrl = "/api/MedicalStuffReportService/MedicalStuffReportFormTemplate";

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.post<MedicalStuffReportFormViewModel>(fullApiUrl, this.medicalStuffReportFormViewModel, MedicalStuffReportFormViewModel);
            this.initViewModel();
            this.initFormControls();
            //this.selectedUserTemplate = null;
            this._ViewModel = response;


            this.loadViewModel();

            await this.ClientSidePreScript();
            await this.PreScript();
            //await this.Report.getReadOnlyDiagnosis();
            //await this.SetButtonVisibility();
            //this.medicalstuffgr.instance.refresh();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    async btnClearUserTemplate_Click(): Promise<void> {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Şablon Temizlenerek Boş bir Form Açılacaktır. Devam Etmek İstiyor Musunuz? "), 1);
        if (result === "H")
            return;
        this.loadPanelOperation(true, 'Form Açılıyor, Lütfen Bekleyiniz');

        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.IsNew) {
            this.LoadEmptyForm();
        } else {
            this.loadMedicalStuffReportByID(this._MedicalStuffReport.ObjectID);
        }
        this.loadPanelOperation(false, '');

        this.TemplateCombo.value = null;
        //this.selectedUserTemplate = null;
        this.medicalStuffReportFormViewModel.selectedUserTemplate = null;
    }

    async btnDeleteSelectedUserTemplate_Click(): Promise<void> {
        try {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Şablon Sistemden Silinecektir!! Devam Etmek İstiyor Musunuz ? "), 1);
            if (result === "H")
                return;
            let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

            savedUserTemplate.ObjectID = this.medicalStuffReportFormViewModel.selectedUserTemplate.ObjectID;
            savedUserTemplate.TAObjectDefID = this.medicalStuffReportFormViewModel._MedicalStuffReport.ObjectDefID;
            let apiUrl: string = 'api/MedicalStuffReportService/SaveMedicalStuffReportUserTemplate';
            this.loadPanelOperation(true, 'Şablon Siliniyor, Lütfen Bekleyiniz');
            await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                this.medicalStuffReportFormViewModel.userTemplateList = result;
                this.medicalStuffReportFormViewModel.selectedUserTemplate = null;
                this.userTemplateName = "";
                ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Silindi");
            });
            this.loadPanelOperation(false, '');

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    async btnAddUserTemplate_Click(): Promise<void> {
        try {
            if (this.userTemplateName != null || (this.userTemplateName != null && !this.userTemplateName.toString().isNullOrEmpty())) {
                let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

                savedUserTemplate.Description = this.userTemplateName;
                savedUserTemplate.TAObjectDefID = this.medicalStuffReportFormViewModel._MedicalStuffReport.ObjectDefID;
                savedUserTemplate.TAObjectID = this.medicalStuffReportFormViewModel._MedicalStuffReport.ObjectID;

                let apiUrl: string = 'api/MedicalStuffReportService/SaveMedicalStuffReportUserTemplate';
                this.loadPanelOperation(true, 'Şablon Kaydediliyor, Lütfen Bekleyiniz');
                await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                    this.medicalStuffReportFormViewModel.userTemplateList = result;
                    this.medicalStuffReportFormViewModel.selectedUserTemplate = null;
                    this.userTemplateName = "";
                    ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Oluşturuldu");
                });
                this.loadPanelOperation(false, '');
            } else {
                ServiceLocator.MessageService.showError("Şablon ismi girmeden yeni şablon oluşturamazsınız");
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    public async SendToMedula() {

        if (this.medicalStuffReportFormViewModel.MedicalStuffGridGridList != null) {
            if (this.checkReportType()) {
                this.medicalStuffReportFormViewModel.MedicalStuffGridGridList.forEach(MedicalStuff => {
                    if (MedicalStuff.MedicalStuffUsageType == null) {
                        this.messageService.showInfo("İşitme cihazları için kullanım şekli alanı zorunludur ");
                        return;
                    }
                });
            }
        }

        if (this.medicalStuffReportFormViewModel.ToState == MedicalStuffReport.MedicalStuffReportStates.Cancel) {
            this.messageService.showInfo("İptal edilmiş rapor bilgisi Medulaya gönderilemez! ");
            return;
        }

        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
        }

        try {
            //if (this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo == null)
            //this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo = "0";

            if (this.medicalStuffReportFormViewModel.MedicalStuffReportList != null)
                this.medicalStuffReportFormViewModel.MedicalStuffReportList.Clear();



            this.messageService.showInfo(i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));

            let user: ResUser = await UserHelper.CurrentResource;
            /*if (user.UserType == UserTypeEnum.Doctor)//imzali
            {
                await this.signService.showLoginModal();
                this.signService.
                let willSend: PrepareSignedReportContent_Input = new PrepareSignedReportContent_Input();
                willSend.eRaporObjectID = this.medicalStuffReportFormViewModel._MedicalStuffReport.ObjectID;
                let signedReportOutput: string = await this.httpService.post<string>(this.PrepareSignedReportContentUrl, willSend);

                let signedContent: string = await this.signService.signContent(signedReportOutput);

                let preSend: SendSignedReportContent_Input = new SendSignedReportContent_Input();
                preSend.singContent = signedContent;
                preSend.MedicalStuffReportFormViewModel = this.medicalStuffReportFormViewModel;
                let sonuc: boolean = await this.httpService.post<boolean>(this.SendSignedReportContentUrl, preSend);
                if (sonuc === true) {
                    ServiceLocator.MessageService.showInfo(this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo + ' numaralı kaydedilmiştir.');
                    //let res = <MedicalStuffReport.GetMedicalStuffReportListByID_Class>await this.httpService.post('/api/MedicalStuffReportService/GetEReportList', this.medicalStuffReportFormViewModel);
                    //this.LoadReportListView(res., false);
                } else {
                    ServiceLocator.MessageService.showError(this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo + ' numaralı kaydedilememiştir.');
                }
                //for (let signContentItem of signedReportOutput.ReportSignContentList) {
                //    let signedContent = await this.signService.signContent(signContentItem.SignContent);
                //    let reportSignedContent = new ReportSignContent();
                //    reportSignedContent.ReportObjectID = signContentItem.ReportObjectID;
                //    reportSignedContent.SignContent = signedContent;
                //    reportSignedContent.OrderNo = signContentItem.OrderNo;
                //    if (this.medicalStuffReportFormViewModel.ReportSignContentList === null) {
                //        this.medicalStuffReportFormViewModel.ReportSignContentList = new Array<ReportSignContent>();
                //    }
                //    this.medicalStuffReportFormViewModel.ReportSignContentList.push(reportSignedContent);
                //}

                await this.httpService.post<void>(this.SendSignedApprovalReportContentUrl, this.medicalStuffReportFormViewModel);
            }
            else {*/
            let result = <MedulaResult>await this.httpService.post('/api/MedicalStuffReportService/eRaporGiris', this.medicalStuffReportFormViewModel);

            if (result != null) {
                if (result.SonucKodu == "0000") {
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo = result.TakipNo;
                }
                else if (result != null && result.SonucKodu == "9107") {
                    this.resetSavedPassword();
                }
                this.medicalStuffReportFormViewModel._MedicalStuffReport.MedulaDescription = result.SonucMesaji;

            }
            //}
        }
        catch (Exception) {
            this.messageService.showError(Exception);
            //throw Exception;
        }
    }

    public async AddEtkinMadde() {
        let inputClass: AddTibbiMalzemeClass = new AddTibbiMalzemeClass();

        if (this.addedMedicalStuff.StuffAmount == null) {
            this.messageService.showInfo("Miktar Alanı Boş Geçilemez ! ");
            return;
        }
        if (this.addedMedicalStuff.MedicalStuffGroup == null) {
            this.messageService.showInfo("Malzeme Grubu Alanı Boş Geçilemez ! ");
            return;
        }
        if (this.addedMedicalStuff.MedicalStuffPlaceOfUsage == null) {
            this.messageService.showInfo("Kullanım Yeri Alanı Boş Geçilemez ! ");
            return;
        }
        if (this.addedMedicalStuff.PeriodUnit == null) {
            this.messageService.showInfo("Kullanım Periyodu Alanı Boş Geçilemez ! ");
            return;
        }
        if (this.addedMedicalStuff.PeriodUnitType == null) {
            this.messageService.showInfo("Kullanım Periyodu Birimi Alanı Boş Geçilemez ! ");
            return;
        }

        if (this.checkReportType()) {
            if (this.addedMedicalStuff.MedicalStuffUsageType == null) {
                this.messageService.showInfo("İşitme cihazları için kullanım şekli alanı zorunludur ");
                return;
            }
        }

        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
            inputClass.medulaUsername = this.medicalStuffReportFormViewModel.medulaUsername;
            inputClass.medulaPassword = this.medicalStuffReportFormViewModel.medulaPassword;
        }
        inputClass.medicalStuff = this.addedMedicalStuff;
        this.loadPanelOperation(true, "Tıbbi Malzeme Ekleniyor Lütfen Bekleyiniz.");
        this.httpService.post<TibbiMalzemeERaporIslemleri.eRaporCevapDVO>('/api/MedicalStuffReportService/RaporMalzemeEkle', inputClass).then(result => {
            if (result != null) {
                if (result.sonucKodu == "0000") {
                    this.messageService.showSuccess("Malzeme Başarıyla Eklendi");
                    this.load();
                } else {
                    this.messageService.showError("Malzeme Eklenirken bir hata oluştu. Hata : " + result.sonucMesaji);
                    this.loadPanelOperation(false, "");
                }
            }
        }).catch(e => {
            this.messageService.showError(e);
            this.loadPanelOperation(false, "");
        });


        this.loadPanelOperation(false, "");

    }

    public async AddExtraDiagnosis() {
        let inputClass: AddDiagnosisClass = new AddDiagnosisClass();
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
            inputClass.medulaUsername = this.medicalStuffReportFormViewModel.medulaUsername;
            inputClass.medulaPassword = this.medicalStuffReportFormViewModel.medulaPassword;
        }
        inputClass.Diagnose = this.addedDiagnosis;
        inputClass.ReportObject = this.medicalStuffReportFormViewModel._MedicalStuffReport;
        this.loadPanelOperation(true, "Tanı Ekleniyor Lütfen Bekleyiniz.");
        this.httpService.post<TibbiMalzemeERaporIslemleri.eRaporCevapDVO>('/api/MedicalStuffReportService/RaporTaniEkle', inputClass).then(result => {
            if (result != null) {
                if (result.sonucKodu == "0000") {
                    this.messageService.showSuccess("Tanı Başarıyla Eklendi");
                    this.load();
                } else {
                    this.messageService.showError("Tanı Eklenirken bir hata oluştu. Hata : " + result.sonucMesaji);
                    this.loadPanelOperation(false, "");
                }
            }
        }).catch(e => {
            this.messageService.showError(e);
            this.loadPanelOperation(false, "");
        });


        this.loadPanelOperation(false, "");

    }

    public async changeReportDescription() {
        let inputClass: ChangeReportDescriptionClass = new ChangeReportDescriptionClass();
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
            inputClass.medulaUsername = this.medicalStuffReportFormViewModel.medulaUsername;
            inputClass.medulaPassword = this.medicalStuffReportFormViewModel.medulaPassword;
        }
        inputClass.medicalStuffReport = this.medicalStuffReportFormViewModel._MedicalStuffReport;
        this.loadPanelOperation(true, "Açıklama Güncelleniyor Lütfen Bekleyiniz.");
        this.httpService.post<TibbiMalzemeERaporIslemleri.eRaporCevapDVO>('/api/MedicalStuffReportService/RaporAciklamaGuncelle', inputClass).then(result => {
            if (result != null) {
                if (result.sonucKodu == "0000") {
                    this.messageService.showSuccess("Açıklama Başarıyla Eklendi");
                    this.load();
                } else {
                    this.messageService.showError("Açıklama Güncellenirken bir hata oluştu. Hata : " + result.sonucMesaji);
                    this.loadPanelOperation(false, "");
                }
            }
        }).catch(e => {
            this.messageService.showError(e);
            this.loadPanelOperation(false, "");
        });

        this.loadPanelOperation(false, "");


    }



    public openTibbiMalzemePopUp() {
        this.addExtraMaterialPopUp = true;
    }

    public openDiagnosisPopUp() {
        this.addExtraDiagnosisPopUp = true;
    }

    public openChangeDescriptionPopUp() {
        this.changeDescriptionPopUp = true;
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo != null) {
            let addTibbiMalzeme = new DynamicSidebarMenuItem();
            addTibbiMalzeme.key = 'addTibbiMalzeme';
            addTibbiMalzeme.icon = 'fa fa-plus-square';
            addTibbiMalzeme.label = "Tıbbi Malzeme Ekle";
            addTibbiMalzeme.componentInstance = this;
            addTibbiMalzeme.clickFunction = this.openTibbiMalzemePopUp;
            this.sideBarMenuService.addMenu('YardimciMenu', addTibbiMalzeme);

            let addDiagnosis = new DynamicSidebarMenuItem();
            addDiagnosis.key = 'addDiagnosis';
            addDiagnosis.icon = 'fa fa-plus';
            addDiagnosis.label = "Tanı Ekle";
            addDiagnosis.componentInstance = this;
            addDiagnosis.clickFunction = this.openDiagnosisPopUp;
            this.sideBarMenuService.addMenu('YardimciMenu', addDiagnosis);

            let changeDiagnosis = new DynamicSidebarMenuItem();
            changeDiagnosis.key = 'changeDiagnosis';
            changeDiagnosis.icon = 'fa fa-pencil';
            changeDiagnosis.label = "Açıklama Güncelle";
            changeDiagnosis.componentInstance = this;
            changeDiagnosis.clickFunction = this.openChangeDescriptionPopUp;
            this.sideBarMenuService.addMenu('YardimciMenu', changeDiagnosis);
        }
    }

    private RemoveMenuFromHelpMenu() {
        if (this.medicalStuffReportFormViewModel.isPrescriptionWriteable == true) {
            this.sideBarMenuService.removeMenu('addTibbiMalzeme');
            this.sideBarMenuService.removeMenu('addDiagnosis');
            this.sideBarMenuService.removeMenu('changeDiagnosis');
        }
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public async DeleteFromMedula() {
        if (this.medicalStuffReportFormViewModel.MedicalStuffReportList != null)
            this.medicalStuffReportFormViewModel.MedicalStuffReportList.Clear();


        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel();
        }

        try {
            let res: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Raporu Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? "), 1);
            if (res === "H")
                ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
            let user: ResUser = await UserHelper.CurrentResource;
            /* if (user.UserType == UserTypeEnum.Doctor)//imzali
             {
                 await this.signService.showLoginModal();
                 let preInput: PrepareSignedDeleteReportContent_Input = new PrepareSignedDeleteReportContent_Input();
                 preInput.eRaporTakipNo = this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo;

                 let signedReportOutput: string = await this.httpService.post<string>(this.PrepareSignedDeleteReportContentUrl, preInput);
                 let signedContent: string = await this.signService.signContent(signedReportOutput);
                 let preSend: SendSignedDeleteReportContent_Input = new SendSignedDeleteReportContent_Input();
                 preSend.singContent = signedContent;
                 let sonuc: boolean = await this.httpService.post<boolean>(this.SendSignedDeleteReportContentUrl, preSend);
                 if (sonuc === true) {
                     ServiceLocator.MessageService.showInfo(this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo + ' numaralı rapor silinmiştir.');
                     //let res = <MedicalStuffReport.GetMedicalStuffReportListByID_Class>await this.httpService.post('/api/MedicalStuffReportService/GetEReportList', this.medicalStuffReportFormViewModel);
                     //this.LoadReportListView(res., false);
                 } else {
                     ServiceLocator.MessageService.showError(this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo + ' numaralı rapor iptal edilememiştir.');
                 }
             }
             else {*/
            let result = <MedulaResult>await this.httpService.post('/api/MedicalStuffReportService/eRaporSil', this.medicalStuffReportFormViewModel);
            if (result != null) {
                this.medicalStuffReportFormViewModel._MedicalStuffReport.MedulaDescription = result.SonucMesaji;
            }
            else
                this.messageService.showInfo("Rapor Servisinden Gelen Sonuç Mesajı : Servise ulaşılamamıştır !!!");
            // }
        }
        catch (Exception) {
            this.messageService.showError(Exception);
            //throw Exception;
        }
    }

    public async GetReportFromMedula() {
        if (this.medicalStuffReportFormViewModel.MedicalStuffReportList != null)
            this.medicalStuffReportFormViewModel.MedicalStuffReportList.Clear();

        let user: ResUser = await UserHelper.CurrentResource;
        if (user.UserType == UserTypeEnum.Doctor)//imzali
        {
            await this.signService.showLoginModal();
            let preInput: PrepareSignedSearchReportContent_Input = new PrepareSignedSearchReportContent_Input();
            preInput.eRaporTakipNo = this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo;

            let signedReportOutput: string = await this.httpService.post<string>(this.PrepareSignedSearchReportContentUrl, preInput);
            let signedContent: string = await this.signService.signContent(signedReportOutput);
            let preSend: SendSignedSearchReportContent_Input = new SendSignedSearchReportContent_Input();
            preSend.singContent = signedContent;
            preSend.MedicalStuffReportFormViewModel = this.medicalStuffReportFormViewModel;
            let sonuc: boolean = await this.httpService.post<boolean>(this.SendSignedSearchReportContentUrl, preSend);
            if (sonuc === true) {
                this.loadViewModel();
            } else {
                ServiceLocator.MessageService.showError(this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo + ' numaralı rapor sorgulanamamıştır.');
            }
        }
        else {

            let result = <MedulaResult>await this.httpService.post('/api/MedicalStuffReportService/eRaporSorgu', this.medicalStuffReportFormViewModel);
            if (result != null) {
                this.medicalStuffReportFormViewModel._MedicalStuffReport.MedulaDescription = result.SonucMesaji;
            }
        }
    }

    private async btnIkinciTabipOnay_Click(): Promise<void> {
        let approveModel: MedicalStuffReportApproveModel = new MedicalStuffReportApproveModel();
        approveModel.isSecondDoctorApprove = true;
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordApprovePanel(approveModel);
            let approveDoctor = <string>await this.httpService.post('/api/MedicalStuffReportService/getUniqueRefnoOfApproveUser', this.medicalStuffReportFormViewModel._MedicalStuffReport);
            /*if (approveDoctor != approveModel.medulaUsername) {
                console.log("Diğer hekim yerine rapor onayı yapamazsınız!!");
                ServiceLocator.MessageService.showError("Diğer hekim yerine rapor onayı yapamazsınız!!");
                this.resetSavedPassword();
                return;
            }*/
            if (this.medicalStuffReportFormViewModel.secondDoctor != approveModel.medulaUsername) {
                console.log("Diğer hekim yerine rapor onayı yapamazsınız!!");
                ServiceLocator.MessageService.showError("Diğer hekim yerine rapor onayı yapamazsınız!!");
                return;
            }
        }
        try {
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo != null) {
                approveModel.medicalStuffReport = this.medicalStuffReportFormViewModel._MedicalStuffReport;


                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                let result = <eRaporOnayCevapDVO>await this.httpService.post('/api/MedicalStuffReportService/Onay', approveModel);
                this.loadPanelOperation(false, '');
                if (result != null && result.sonucKodu === '0000') {
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.CurrentStateDefID = MedicalStuffReport.MedicalStuffReportStates.ThirdDoctorApproval;
                    this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));

                }
                else if (result != null && result.sonucKodu === 'RAP_0052') {
                    this.messageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                }
                else if (result != null && result.sonucKodu == "9107") {
                    this.resetSavedPassword();
                }
                else {
                    if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                        this.messageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                    }
                }

                const objectIdParam = new Guid(this._MedicalStuffReport.ObjectID);
                await this.loadMedicalStuffReportByID(objectIdParam);
                await this.LoadReportListView(this.medicalStuffReportFormViewModel.MedicalStuffReportList, false);

                this.showSaveSuccessMessage();
            }
            else
                this.messageService.showError("Medulaya Kaydı Yapılmamış Bir Malzeme Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
        }
        catch (e) {
            this.loadPanelOperation(false, '');
            this.messageService.showError(e);
        }

    }

    private async btnUcuncuTabipOnay_Click(): Promise<void> {
        let approveModel: MedicalStuffReportApproveModel = new MedicalStuffReportApproveModel();
        approveModel.isThirdDoctorApprove = true;
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordApprovePanel(approveModel);
            let approveDoctor = <string>await this.httpService.post('/api/MedicalStuffReportService/getUniqueRefnoOfApproveUser', this.medicalStuffReportFormViewModel._MedicalStuffReport);
            /*if (approveDoctor != approveModel.medulaUsername) {
                console.log("Diğer hekim yerine rapor onayı yapamazsınız!!");
                ServiceLocator.MessageService.showError("Diğer hekim yerine rapor onayı yapamazsınız!!");
                this.resetSavedPassword();
                return;
            }*/

            if (this.medicalStuffReportFormViewModel.thirdDoctor != approveModel.medulaUsername) {
                console.log("Diğer hekim yerine rapor onayı yapamazsınız!!");
                ServiceLocator.MessageService.showError("Diğer hekim yerine rapor onayı yapamazsınız!!");
                return;
            }
        }
        try {
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo != null) {
                approveModel.medicalStuffReport = this.medicalStuffReportFormViewModel._MedicalStuffReport;
                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                let result = <eRaporOnayCevapDVO>await this.httpService.post('/api/MedicalStuffReportService/Onay', approveModel);
                this.loadPanelOperation(false, '');
                if (result != null && result.sonucKodu === '0000') {
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.CurrentStateDefID = MedicalStuffReport.MedicalStuffReportStates.ThirdDoctorApproval;
                    this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));

                }
                else if (result != null && result.sonucKodu === 'RAP_0052') {
                    this.messageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                }
                else if (result != null && result.sonucKodu == "9107") {
                    this.resetSavedPassword();
                }
                else {
                    if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                        this.messageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                    }
                }

                const objectIdParam = new Guid(this._MedicalStuffReport.ObjectID);
                await this.loadMedicalStuffReportByID(objectIdParam);
                await this.LoadReportListView(this.medicalStuffReportFormViewModel.MedicalStuffReportList, false);

                this.showSaveSuccessMessage();
            }
            else
                this.messageService.showError("Medulaya Kaydı Yapılmamış Bir Malzeme Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
        }
        catch (e) {
            this.loadPanelOperation(false, '');
            this.messageService.showError(e);
        }
    }

    private OpenMedicalStuffPrescription(): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'MedicalStuffPrescriptionForm';
            componentInfo.ModuleName = 'TibbiMalzemeModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tibbi_Malzeme_Modulu/TibbiMalzemeModule';
            componentInfo.InputParam = new DynamicComponentInputParam(null, new ActiveIDsModel(this._MedicalStuffReport.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Tıbbi Malzeme Reçetesi';
            modalInfo.Width = 1020;
            modalInfo.Height = 600;
            modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    private async btnBasTabipOnay_Click(): Promise<void> {
        let approveModel: MedicalStuffReportApproveModel = new MedicalStuffReportApproveModel();
        if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordApprovePanel(approveModel);
        }
        try {
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo != null) {
                approveModel.medicalStuffReport = this.medicalStuffReportFormViewModel._MedicalStuffReport;
                this.loadPanelOperation(true, i18n("M18851", "Medulaya gönderiliyor, lütfen bekleyiniz."));
                let result = <eRaporOnayCevapDVO>await this.httpService.post('/api/MedicalStuffReportService/BashekimOnay', approveModel);
                this.loadPanelOperation(false, '');
                if (result != null && result.sonucKodu === '0000') {
                    this.medicalStuffReportFormViewModel._MedicalStuffReport.CurrentStateDefID = MedicalStuffReport.MedicalStuffReportStates.Complete;
                    this.messageService.showSuccess(i18n("M20833", "Rapor Onaylandı."));

                }
                else if (result != null && result.sonucKodu === 'RAP_0052') {
                    this.messageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji);
                }
                else if (result != null && result.sonucKodu == "9107") {
                    this.resetSavedPassword();
                }
                else {
                    if (!String.isNullOrEmpty(result.sonucMesaji) || !String.isNullOrEmpty(result.uyariMesaji)) {
                        this.messageService.showError(i18n("M20842", "Rapor Servisinden Gelen Uyarı Mesajı : ") + result.uyariMesaji + '' + result.sonucMesaji + i18n("M20831", " Rapor Onaylanamamıştır.  !!!"));
                    }
                }

                const objectIdParam = new Guid(this._MedicalStuffReport.ObjectID);
                await this.loadMedicalStuffReportByID(objectIdParam);
                await this.LoadReportListView(this.medicalStuffReportFormViewModel.MedicalStuffReportList, false);

                this.showSaveSuccessMessage();
            }
            else
                this.messageService.showError("Medulaya Kaydı Yapılmamış Bir Malzeme Raporunu Medulada Onaylama İşlemi Yapamazsınız!!!");
        }
        catch (e) {
            this.loadPanelOperation(false, '');
            this.messageService.showError(e);
        }

    }


    public MedulaReportListViewRowPrepared(event: any) {
    }

    public MedulaReportListView_Click(event: any) {
    }

    public comingPrescriptionViewModel(event: any) {
    }

    public async ERaporListeSorgu() {
        if (this.medicalStuffReportFormViewModel.MedicalStuffReportList != null)
            this.medicalStuffReportFormViewModel.MedicalStuffReportList.Clear();

        let user: ResUser = await UserHelper.CurrentResource;
        if (user.UserType == UserTypeEnum.Doctor)//imzali
        {

        }
        else {

            let result = <MedulaResult>await this.httpService.post('/api/MedicalStuffReportService/eRaporListeSorgu', this.medicalStuffReportFormViewModel);
            if (result != null) {
                this.medicalStuffReportFormViewModel._MedicalStuffReport.MedulaDescription = result.SonucMesaji;

                //  this.MedulaReportListView = result.;
            }
        }
    }

    public async Save() {
        try {
            let that = this;

            /* if (this.medicalStuffReportFormViewModel._MedicalStuffReport.IsSendedMedula == true) {
                 ServiceLocator.MessageService.showError("İşleme devam etmek için raporu Meduladan siliniz.");
                 return;
             }*/
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate == null) {
                this.messageService.showInfo(i18n("M11941", "Bitiş Tarihi Boş Geçilemez ! "));
                return;
            }
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate == null) {
                this.messageService.showInfo(i18n("M11639", "Başlangıç Tarihi Boş Geçilemez ! "));
                return;
            }
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate <= this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate) {
                this.messageService.showInfo(i18n("M11944", "Bitiş Tarihi, Başlangıç Tarihinden büyük olmalıdır ! "));
                return;
            }
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.ProcedureDoctor == null) {
                this.messageService.showInfo(i18n("M13157", "Doktor Alanı Boş Geçilemez ! "));
                return;
            }

            if (this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel == null || this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList.length == 0) {
                this.messageService.showInfo(i18n("M22770", "Tanı Seçmeniz Gerekmektedir ! "));
                return;
            }
            else {
                for (let item of this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList) {
                    if (item.DiagnoseCode == null) {
                        this.messageService.showInfo(i18n("M21576", "Seçtiğiniz Tanının Tanı Kodu Boş olmamalıdır ! "));
                        return;
                    }
                }
            }

            if (this.medicalStuffReportFormViewModel.MedicalStuffGridGridList == null && this.medicalStuffReportFormViewModel.MedicalStuffGridGridList.length == 0) {
                this.messageService.showInfo("Hiçbir tıbbi malzeme seçmeden devam edemezsiniz!");
                return;
            }
            else {
                for (let item of this.medicalStuffReportFormViewModel.MedicalStuffGridGridList) {
                    if (item.StuffAmount == null) {
                        this.messageService.showInfo("Miktar Alanı Boş Geçilemez ! ");
                        return;
                    }
                    if (item.MedicalStuffGroup == null) {
                        this.messageService.showInfo("Malzeme Grubu Alanı Boş Geçilemez ! ");
                        return;
                    }
                    if (item.MedicalStuffPlaceOfUsage == null) {
                        this.messageService.showInfo("Kullanım Yeri Alanı Boş Geçilemez ! ");
                        return;
                    }
                    if (item.PeriodUnit == null) {
                        this.messageService.showInfo("Kullanım Periyodu Alanı Boş Geçilemez ! ");
                        return;
                    }
                    if (item.PeriodUnitType == null) {
                        this.messageService.showInfo("Kullanım Periyodu Birimi Alanı Boş Geçilemez ! ");
                        return;
                    }
                }
            }

            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.CurrentStateDefID.valueOf() == MedicalStuffReport.MedicalStuffReportStates.Complete.id) {
                this.messageService.showInfo("Raporda değişiklik yapabilmek için raporu Medula'dan iptal ediniz.");
                return;
            }


            if (this.medicalStuffReportFormViewModel.MedicalStuffGridGridList != null) {
                if (this.checkReportType()) {
                    this.medicalStuffReportFormViewModel.MedicalStuffGridGridList.forEach(MedicalStuff => {
                        if (MedicalStuff.MedicalStuffUsageType == null) {
                            this.messageService.showInfo("İşitme cihazları için kullanım şekli alanı zorunludur ");
                            return;
                        }
                    });
                }
            }

            this.ReportListView.Items = new Array<any>();
            this.MedulaReportListView.Items = new Array<any>();

            if (this.medicalStuffReportFormViewModel.MedicalStuffReportList != null)
                this.medicalStuffReportFormViewModel.MedicalStuffReportList.Clear();

            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.CurrentStateDefID == null)
                this.medicalStuffReportFormViewModel._MedicalStuffReport.CurrentStateDefID = MedicalStuffReport.MedicalStuffReportStates.New;


            await this.ClientSidePostScript(null);
            await this.PostScript(null);
            let injector = ServiceLocator.Injector;
            let messageService: MessageService = injector.get(MessageService);
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            this.ResultSetList = await httpService.post(this._DocumentServiceUrl, this._ViewModel, MedicalStuffReportFormViewModel);
            this.globalReportObjectID = this.ResultSetList.ObjectID;
            await this.AfterContextSavedScript(null);

            await this.loadMedicalStuffReportByID(new Guid(this.globalReportObjectID));

            await this.LoadReportListView(this.medicalStuffReportFormViewModel.MedicalStuffReportList, false);



            this.showSaveSuccessMessage();

            await this.MedulaErrorValidator();
            this.lastSelectedReportObjectId = this._TTObject.ObjectID.toString();
            this.httpService.medicalStuffReportSharedService.updateReportGridObservable(true);
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

    }

    public async Cancel() {
        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo != null && this.medicalStuffReportFormViewModel._MedicalStuffReport.RaporTakipNo != "0") {
            this.messageService.showInfo("Raporu iptal etmek için raporu Medula'dan siliniz.");
        }
        else {
            let that = this;

            if (this.medicalStuffReportFormViewModel.MedicalStuffReportList != null)
                this.medicalStuffReportFormViewModel.MedicalStuffReportList.Clear();

            let apiUrlForRaporBilgisBul: string = '/api/MedicalStuffReportService/Cancel';
            let response = <boolean>await this.httpService.post(apiUrlForRaporBilgisBul, this.medicalStuffReportFormViewModel._MedicalStuffReport);
            if (response == true) {
                this.medicalStuffReportFormViewModel._MedicalStuffReport.CurrentStateDefID = MedicalStuffReport.MedicalStuffReportStates.Cancel;
                this.messageService.showInfo("Rapor silindi.");
                this.httpService.medicalStuffReportSharedService.updateReportGridObservable(true);
                return;
            }
        }
    }

    public async loadMedicalStuffReportByID(objectID: Guid) {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";

            if (objectID != null) {
                fullApiUrl = this.MedicalStuffReportForm_DocumentUrl + '/?id=' + objectID;
            }
            else {
                fullApiUrl = `${this.MedicalStuffReportForm_DocumentUrl}/${Guid.Empty}`;
            }

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<MedicalStuffReportFormViewModel>(fullApiUrl, MedicalStuffReportFormViewModel);
            this._ViewModel = response;

            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async LoadEmptyForm() {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";
            fullApiUrl = this.MedicalStuffReportForm_DocumentUrl + "Load";
            let formLoadInput = { Id: Guid.Empty, Model: this.ActiveIDsModel };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.post<MedicalStuffReportFormViewModel>(fullApiUrl, formLoadInput, MedicalStuffReportFormViewModel);

            this._ViewModel = response;

            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            //await this.Report.getReadOnlyDiagnosis();
            //await this.SetButtonVisibility();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    public async PreScript() {
        super.PreScript();
        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.CommitteeReport == null)
            this.medicalStuffReportFormViewModel._MedicalStuffReport.CommitteeReport = false;
        if (this.medicalStuffReportFormViewModel._MedicalStuffReport.CommitteeReport == true) {
            this.lstTabip2.Visible = true;
            this.lstTabip2.Required = true;
            this.labelTabip2 = i18n("M10220", "2.Doktor");
            this.labelTabip3 = i18n("M10289", "3.Doktor");
            this.lstTabip3.Visible = true;
            this.lstTabip3.Required = true;
        }

        await this.LoadReportListView(this.medicalStuffReportFormViewModel.MedicalStuffReportList, false);
    }
    public async MedulaErrorValidator(): Promise<void> {

        if (this.medicalStuffReportFormViewModel._MedicalStuffReport != null && this.medicalStuffReportFormViewModel._MedicalStuffReport.MedulaDescription != null &&
            this.medicalStuffReportFormViewModel._MedicalStuffReport.MedulaDescription != "0000")
            this.MedulaDescription.BackColor = "#fdcdcd";
        else
            this.MedulaDescription.BackColor = "#F0F0F0";
    }

    public async ReportListView_Click(val: any): Promise<void> {

        if (val != null) {
            let data = val.ObjectId.toString();
            this.ObjectID = new Guid(data);
            this.lastSelectedReportObjectId = data;
            await this.load(MedicalStuffReportFormViewModel, this.MedicalStuffReportForm_DocumentUrl);
            await this.MedulaErrorValidator();
        }
    }
    public ReportListViewRowPrepared(row) {
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


    public LoadReportListView(reportListView: Array<any>, canShowMessage: boolean): void {
        if (reportListView != null) {
            try {
                let itemList = new Array<any>();
                for (let reportHistory of reportListView) {

                    let p = {
                        ObjectId: reportHistory.ObjectID,
                        IsSendedMedula: (reportHistory.IsSendedMedula == null) ? false : reportHistory.IsSendedMedula,
                        SubItems:
                            [
                                { Text: (reportHistory.RaporTakipNo !== null ? reportHistory.RaporTakipNo : "....") },
                                { Text: (reportHistory.ReportNo != null) ? reportHistory.ReportNo : "...." },
                                { Text: (reportHistory.StartDate.toString("dd/mm/YYYY")) },
                                { Text: (reportHistory.EndDate.toString("dd/mm/YYYY")) },
                                { Text: (reportHistory.Proceduredoctor !== null ? reportHistory.Proceduredoctor : "....") },
                                { Text: (reportHistory.Seconddoctor !== null ? reportHistory.Seconddoctor : "....") },
                                { Text: (reportHistory.Thirddoctor !== null ? reportHistory.Thirddoctor : "....") }
                            ]
                    };


                    itemList.push(p);
                }

                this.ReportListView.Items = itemList;


            } catch (e) {
                ServiceLocator.MessageService.showError((<Error>e).message);
            }
        }


    }



    public async chkFtrHeyetRaporuChanged(event): Promise<void> {

        if (event == true) {
            this.labelTabip2 = i18n("M10220", "2.Doktor");
            this.labelTabip3 = i18n("M10289", "3.Doktor");
            this.lstTabip3.Enabled = true;
            this.lstTabip2.Enabled = true;
        }
        else {
            this.labelTabip2 = "";
            this.labelTabip3 = "";
            this.lstTabip3.Enabled = false;
            this.lstTabip2.Enabled = false;
        }
    }
    public async selectedMedicalStuffChanged(selectedMedicalStuff: any) {
        if (selectedMedicalStuff != null) {
            if (this.isExists(selectedMedicalStuff.Code) == true) {
                this.messageService.showInfo("Bu malzeme daha önce eklenmiştir.Tekrar ekleyemezsiniz.");
            }
            else {
                if (this.medicalStuffReportFormViewModel.MedicalStuffGridGridList.length == 0) {
                    if (selectedMedicalStuff != null) {

                        this.selecttedStuffCode = selectedMedicalStuff.Code;
                        this.selecttedStuffName = selectedMedicalStuff.Name;

                        let medicalStuff: MedicalStuff = new MedicalStuff();
                        medicalStuff.MedicalStuffDef = selectedMedicalStuff;
                        medicalStuff.StuffAmount = 1;


                        let medicalStuffGroup: MedicalStuffGroup = await this.objectContextService.getObject<MedicalStuffGroup>(selectedMedicalStuff.MedicalStuffGroup, MedicalStuffGroup.ObjectDefID);

                        medicalStuff.MedicalStuffGroup = medicalStuffGroup;
                        this.medicalStuffReportFormViewModel.MedicalStuffGridGridList.push(medicalStuff);

                        //this.MedicalStuffDef = null;    
                    }
                } else {
                    let stuffType: boolean; //true:İşitme cihazı, false:malzeme
                    if (selectedMedicalStuff.Code == "DO1004" || selectedMedicalStuff.Code == "DO1005" || selectedMedicalStuff.Code == "A10106") {
                        stuffType = true;
                    } else {
                        stuffType = false;
                    }

                    if (this.checkReportType() == stuffType) {
                        if (selectedMedicalStuff != null) {

                            this.selecttedStuffCode = selectedMedicalStuff.Code;
                            this.selecttedStuffName = selectedMedicalStuff.Name;

                            let medicalStuff: MedicalStuff = new MedicalStuff();
                            medicalStuff.MedicalStuffDef = selectedMedicalStuff;
                            medicalStuff.StuffAmount = 1;


                            let medicalStuffGroup: MedicalStuffGroup = await this.objectContextService.getObject<MedicalStuffGroup>(selectedMedicalStuff.MedicalStuffGroup, MedicalStuffGroup.ObjectDefID);

                            medicalStuff.MedicalStuffGroup = medicalStuffGroup;
                            this.medicalStuffReportFormViewModel.MedicalStuffGridGridList.push(medicalStuff);

                            //this.MedicalStuffDef = null;


                        }
                    } else {
                        ServiceLocator.MessageService.showError("Bu rapora farklı türden malzeme ekleyemezsiniz");
                    }
                }

            }
        }

    }

    public async selectedAdditionalMedicalStuffSelected(selectedMedicalStuff: any) {
        if (selectedMedicalStuff != null) {
            if (this.isExists(selectedMedicalStuff.Code) == true) {
                this.messageService.showInfo("Bu malzeme daha önce eklenmiştir.Tekrar ekleyemezsiniz.");
            }
            else {
                let stuffType: boolean; //true:İşitme cihazı, false:malzeme
                if (selectedMedicalStuff.Code == "DO1004" || selectedMedicalStuff.Code == "DO1005" || selectedMedicalStuff.Code == "A10106") {
                    stuffType = true;
                } else {
                    stuffType = false;
                }

                if (this.checkReportType() == stuffType) {
                    if (selectedMedicalStuff != null) {

                        this.selecttedStuffCode = selectedMedicalStuff.Code;
                        this.selecttedStuffName = selectedMedicalStuff.Name;

                        this.addedMedicalStuff = new MedicalStuff();
                        this.addedMedicalStuff.MedicalStuffDef = selectedMedicalStuff;
                        this.addedMedicalStuff.StuffAmount = 1;
                        this.addedMedicalStuff.MedicalStuffReport = this.medicalStuffReportFormViewModel._MedicalStuffReport;
                        let medicalStuffGroup: MedicalStuffGroup = await this.objectContextService.getObject<MedicalStuffGroup>(selectedMedicalStuff.MedicalStuffGroup, MedicalStuffGroup.ObjectDefID);

                        this.addedMedicalStuff.MedicalStuffGroup = medicalStuffGroup;
                    }
                } else {
                    ServiceLocator.MessageService.showError("Bu rapora farklı türden malzeme ekleyemezsiniz");
                }
            }
        }

    }

    public async selectAdditionalDiagnosis(diagnosis: any) {
        if (diagnosis != null) {
            if (this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel != null
                && this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList != null) {
                let diagnoseList = this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList;

                let isDiagnosisExists = diagnoseList.find(t => t.DiagnoseCode === diagnosis.DiagnoseCode);
                if (isDiagnosisExists == null) {
                    this.addedDiagnosis = diagnosis;
                }
            }
            //if(this.medicalStuffReportFormViewModel.reportDiagnosisFormViewModel.ReportDiagnosisGridList)
        }

    }
    public cmbRaporSureTuruChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.DurationType != event) {
                this._MedicalStuffReport.DurationType = event;
            }
            if (this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate == null) {
                this.messageService.showInfo(i18n("M20775", "Rapor Başlangıç Tarihi Girmelisiniz!"));
                return;
            }
            let thisdate: Date = new Date();
            thisdate = this.medicalStuffReportFormViewModel._MedicalStuffReport.StartDate;
            if (event == PeriodUnitTypeEnum.DayPeriod) {
                this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = thisdate.AddDays(this.medicalStuffReportFormViewModel._MedicalStuffReport.Duration);
                this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate.AddDays(-1);
            }
            if (event == PeriodUnitTypeEnum.MonthPeriod) {
                this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = thisdate.AddMonths(this.medicalStuffReportFormViewModel._MedicalStuffReport.Duration);
                this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate.AddDays(-1);
            }
            if (event == PeriodUnitTypeEnum.YearPeriod) {
                this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = thisdate.AddYears(this.medicalStuffReportFormViewModel._MedicalStuffReport.Duration);
                this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate.AddDays(-1);
            }
            if (event == PeriodUnitTypeEnum.WeekPeriod) {
                let gun: number = this.medicalStuffReportFormViewModel._MedicalStuffReport.Duration * 7;
                this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = thisdate.AddDays(gun);
                this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate = this.medicalStuffReportFormViewModel._MedicalStuffReport.EndDate.AddDays(-1);
            }
        }
    }
    async  onRowDeleted(data, row) {

    }
    public isExists(selectedMedicalStuffCode) {
        let itemCount = 0;
        let isExists: Boolean = false;
        for (let item of this.medicalStuffReportFormViewModel.MedicalStuffGridGridList) {
            if (selectedMedicalStuffCode.toString() == item.MedicalStuffDef.Code) {
                itemCount += 1;
            }
        }
        return (itemCount > 1) ? true : false;
    }

    getActivePassive(tabnumber: number): string {
        if (this.medicalStuffReportFormViewModel.activeTab !== 0) {
            if (this.medicalStuffReportFormViewModel.activeTab === tabnumber)
                return 'active';
            else
                return '';
        } else
            return 'active';

    }

    clickScreen(key: number) {
        this.medicalStuffReportFormViewModel.activeTab = key;

    }
    public onMedicalStuffRemoving(event) {
        console.log("asdasda");
        let item: MedicalStuff = event.data;
        item.EntityState = EntityStateEnum.Cancelled;
        item.MedicalStuffReport = null;
    }

    async clickRepScreen(key: number) {
        if (key == 2) {
            await this.ERaporListeSorgu();
        }

    }
    getActivePassivePane(tabnumber: number): string {
        if (this.medicalStuffReportFormViewModel.activeTab !== 0) {
            if (this.medicalStuffReportFormViewModel.activeTab === tabnumber)
                return 'tab-pane fade in active';
            else
                return 'tab-pane fade';
        } else
            return 'tab-pane fade';
    }

    public canShowMainScreen() {
        this.medicalStuffReportFormViewModel.activeTab = 1;
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
        let enableStartDateBounds: string = (await SystemParameterService.GetParameterValue('RAPORBASLANGICTARIHISINIR', 'FALSE'));
        if (enableStartDateBounds === 'TRUE') {
            this.enableStartDateBounds = true;
        }
        else {
            this.enableStartDateBounds = false;
        }

        let showMainDiagnose: string = (await SystemParameterService.GetParameterValue('ANATANIGOSTER', 'TRUE'));
        if (showMainDiagnose === 'TRUE') {
            this.showMainDiagnoseDefinitions = true;
            this.lstDiagnosisAddedToReport.ListFilterExpression = "ISLEAF=1";
        }
        this.AddHelpMenu();
    }

    async ngOnDestroy() {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._ViewModel);
    }

    public async onStartDateChanged(event) {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.StartDate != event) {
                this._MedicalStuffReport.StartDate = event;
                if (this._MedicalStuffReport.Duration != null && this._MedicalStuffReport.DurationType != null)
                    this.cmbRaporSureTuruChanged(this._MedicalStuffReport.DurationType);
            }

            if (this._MedicalStuffReport.ProcedureDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedicalStuffReport.ProcedureDoctor.ObjectID, this._MedicalStuffReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedicalStuffReport.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedicalStuffReport.ProcedureDoctor = null;
                    }, 500);
                }
            }

            if (this._MedicalStuffReport.SecondDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedicalStuffReport.SecondDoctor.ObjectID, this._MedicalStuffReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedicalStuffReport.SecondDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedicalStuffReport.SecondDoctor = null;
                    }, 500);
                }
            }

            if (this._MedicalStuffReport.ThirdDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedicalStuffReport.ThirdDoctor.ObjectID, this._MedicalStuffReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedicalStuffReport.ThirdDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedicalStuffReport.ThirdDoctor = null;
                    }, 500);
                }
            }
        }
    }
    public onEndDateChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.EndDate != event) {
                this._MedicalStuffReport.EndDate = event;
            }
        }
    }
    public onDiagnosisDetailChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.DiagnosisDetail != event) {
                this._MedicalStuffReport.DiagnosisDetail = event;
            }
        }
    }

    public onReportNoChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.ReportNo != event) {
                this._MedicalStuffReport.ReportNo = event;
            }
        }
    }

    public onRaporTakipNoChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.RaporTakipNo != event) {
                this._MedicalStuffReport.RaporTakipNo = event;
            }
        }
    }


    public onReportDecisionChanged(event): void {
        //if (event != null) {
        if (this._MedicalStuffReport != null && this._MedicalStuffReport.ReportDecision != event) {
            this._MedicalStuffReport.ReportDecision = event;
        }
        //}
    }
    public async onlstTabip2Changed(event) {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.SecondDoctor != event) {
                this._MedicalStuffReport.SecondDoctor = event;
                this.medicalStuffReportFormViewModel._MedicalStuffReport.SecondDoctor = event;

                /*let filterExpression: string = " AND  ObjectID <>'";
                filterExpression += event.ObjectID + "'";

                this.lstTabip3.ListFilterExpression += filterExpression;*/
            }

            if (this._MedicalStuffReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedicalStuffReport.SecondDoctor.ObjectID, this._MedicalStuffReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedicalStuffReport.SecondDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedicalStuffReport.SecondDoctor = null;
                    }, 500);
                }
            }
        }
    }
    public async onlstTabip3Changed(event) {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.ThirdDoctor != event) {
                this._MedicalStuffReport.ThirdDoctor = event;
                this.medicalStuffReportFormViewModel._MedicalStuffReport.ThirdDoctor = event;
            }

            if (this._MedicalStuffReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedicalStuffReport.ThirdDoctor.ObjectID, this._MedicalStuffReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedicalStuffReport.ThirdDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedicalStuffReport.ThirdDoctor = null;
                    }, 500);
                }
            }
        }
    }

    public checkReportType(): boolean {            //true : İşitme Cihazları, false : normal malzemeler
        if (this.medicalStuffReportFormViewModel.MedicalStuffGridGridList != null && this.medicalStuffReportFormViewModel.MedicalStuffGridGridList.length > 0) {
            let medicalStuffObject = this.medicalStuffReportFormViewModel.MedicalStuffGridGridList[0]
            if (medicalStuffObject.MedicalStuffDef.Code == "DO1004" || medicalStuffObject.MedicalStuffDef.Code == "DO1005" || medicalStuffObject.MedicalStuffDef.Code == "A10106") {
                return true;
            } else {
                return false;
            }

        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.ProcedureDoctor != event) {
                this._MedicalStuffReport.ProcedureDoctor = event;


                /*let filterExpression: string = " AND  ObjectID <>'";
                filterExpression += event.ObjectID + "'";

                this.lstTabip2.ListFilterExpression += filterExpression;
                this.lstTabip3.ListFilterExpression += filterExpression;*/
            }

            if (this._MedicalStuffReport.StartDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this._MedicalStuffReport.ProcedureDoctor.ObjectID, this._MedicalStuffReport.StartDate);
                if (a) {
                    this.messageService.showInfo(this._MedicalStuffReport.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._MedicalStuffReport.ProcedureDoctor = null;
                    }, 500);
                }
            }
        }
    }
    public onchkFtrHeyetRaporuChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.CommitteeReport != event) {
                this._MedicalStuffReport.CommitteeReport = event;
            }
        }
        this.chkFtrHeyetRaporuChanged(event);
    }

    public onDescriptionChanged(event): void {
        if (this._MedicalStuffReport != null && this._MedicalStuffReport.Description != event) {
            this._MedicalStuffReport.Description = event;
        }
    }


    public onMedulaDescriptionChanged(event): void {
        if (event != null) {
            if (this._MedicalStuffReport != null && this._MedicalStuffReport.MedulaDescription != event) {
                this._MedicalStuffReport.MedulaDescription = event;
            }
        }
    }


    public redirectProperties(): void {
        redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.Description, "Rtf", this.__ttObject, "Description");

        redirectProperty(this.MedulaDescription, "Text", this.__ttObject, "MedulaDescription");

        redirectProperty(this.ReportDecision, "Rtf", this.__ttObject, "ReportDecision");
        redirectProperty(this.DiagnosisDetail, "Text", this.__ttObject, "DiagnosisDetail");
        redirectProperty(this.ReportNo, "Text", this.__ttObject, "ReportNo");
        redirectProperty(this.RaporTakipNo, "Text", this.__ttObject, "RaporTakipNo");
        redirectProperty(this.chkFtrHeyetRaporu, "Value", this.__ttObject, "CommitteeReport");

    }

    GenerateColumns() {
        let that = this;

    }

    public initFormControls(): void {

        this.lstDiagnosisAddedToReport = new TTVisual.TTObjectListBox();
        this.lstDiagnosisAddedToReport.ListDefName = "DiagnosisListDefinition";
        this.lstDiagnosisAddedToReport.Name = "lstDiagnosisAddedToReport";
        this.lstDiagnosisAddedToReport.TabIndex = 1;
        this.lstDiagnosisAddedToReport.ListFilterExpression = "ISLEAF=1"

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ReadOnly = false;
        this.ProcedureDoctor.ListDefName = "DoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 18;

        this.lstTabip3 = new TTVisual.TTObjectListBox();
        this.lstTabip3.ListDefName = "SpecialistDoctorListDefinition";
        this.lstTabip3.Name = "lstTabip3";
        this.lstTabip3.TabIndex = 8;
        //this.lstTabip3.Visible = false;
        this.lstTabip3.Enabled = false;

        this.lstTabip2 = new TTVisual.TTObjectListBox();
        this.lstTabip2.ListDefName = "SpecialistDoctorListDefinition";
        this.lstTabip2.Name = "lstTabip2";
        this.lstTabip2.TabIndex = 7;
        //this.lstTabip2.Visible = false;
        this.lstTabip2.Enabled = false;

        this.lblTabip3 = new TTVisual.TTLabel();
        this.lblTabip3.Text = i18n("M10291", "3.Tabip");
        this.lblTabip3.Name = "lblTabip3";
        this.lblTabip3.TabIndex = 13;
        this.lblTabip3.Visible = false;

        this.lblTabip2 = new TTVisual.TTLabel();
        this.lblTabip2.Text = i18n("M10223", "2.Tabip");
        this.lblTabip2.Name = "lblTabip2";
        this.lblTabip2.TabIndex = 12;
        this.lblTabip2.Visible = false;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.Format = DateTimePickerFormat.Short;
        this.StartDate.Name = "StartDate";
        this.StartDate.TabIndex = 8;

        this.ReportNo = new TTVisual.TTTextBox();
        this.ReportNo.Name = "ReportNo";
        this.ReportNo.TabIndex = 6;
        this.ReportNo.Enabled = false;
        this.ReportNo.ReadOnly = true;

        this.RaporTakipNo = new TTVisual.TTTextBox();
        this.RaporTakipNo.Name = "RaporTakipNo";
        this.RaporTakipNo.TabIndex = 6;
        this.RaporTakipNo.Enabled = false;
        this.RaporTakipNo.ReadOnly = true;

        this.MedicalStuffDef = new TTVisual.TTObjectListBox();
        this.MedicalStuffDef.ListDefName = "MedicalStuffDefinitionListDef";
        this.MedicalStuffDef.Name = "MedicalStuffDef";
        this.MedicalStuffDef.TabIndex = 4;
        this.MedicalStuffDef.AutoCompleteDialogWidth = "60%";

        this.Description = new TTVisual.TTRichTextBoxControl();
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.StuffUsageType = new TTVisual.TTObjectListBox();
        this.StuffUsageType.ListDefName = "MedicalStuffUsageTypeListDef";
        this.StuffUsageType.DataMember = "MedicalStuffUsageType";
        this.StuffUsageType.Name = "StuffUsageType";
        this.StuffUsageType.AutoCompleteDialogWidth = "300";

        this.MedulaDescription = new TTVisual.TTTextBox();
        this.MedulaDescription.Multiline = false;
        this.MedulaDescription.Name = "MedulaDescription";
        this.MedulaDescription.TabIndex = 0;
        this.MedulaDescription.ReadOnly = true;


        this.ReportDecision = new TTVisual.TTRichTextBoxControl();
        this.ReportDecision.Name = "ReportDecision";
        this.ReportDecision.TabIndex = 4;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.Format = DateTimePickerFormat.Short;
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 2;
        this.EndDate.Enabled = true;

        this.DiagnosisDetail = new TTVisual.TTTextBox();
        this.DiagnosisDetail.Multiline = true;
        this.DiagnosisDetail.Name = "DiagnosisDetail";
        this.DiagnosisDetail.TabIndex = 0;
        this.DiagnosisDetail.Height = "100px";

        this.chkFtrHeyetRaporu = new TTVisual.TTCheckBox();
        this.chkFtrHeyetRaporu.Value = false;
        this.chkFtrHeyetRaporu.Title = i18n("M15760", "Heyet");
        this.chkFtrHeyetRaporu.Name = "chkFtrHeyetRaporu";
        this.chkFtrHeyetRaporu.TabIndex = 6;



        this.ReportListView = <TTVisual.TTListView>{
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
                { Text: i18n("M20855", "Rapor Takip No") },
                { Text: i18n("M20821", "Rapor No") },
                { Text: i18n("M11637", "Başlangıç Tarihi"), DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: i18n("M11939", "Bitiş Tarihi"), DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: "1.Doktor" },
                { Text: i18n("M10220", "2.Doktor") },
                { Text: i18n("M10289", "3.Doktor") }
            ]
        };
        this.ReportListView.Name = "ReportListView";
        this.ReportListView.TabIndex = 0;
        this.ReportListView.Height = 100;
        this.ReportListView.MultiSelect = false;



        this.MedulaReportListView = <TTVisual.TTListView>{
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
                { Text: i18n("M20821", "Rapor No") },
                { Text: i18n("M11637", "Başlangıç Tarihi"), DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: i18n("M11939", "Bitiş Tarihi"), DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: "Doktor" }
            ]
        };

        this.MedulaReportListView.Name = "MedulaReportListView";
        this.MedulaReportListView.TabIndex = 0;
        this.MedulaReportListView.Height = 100;
        this.MedulaReportListView.MultiSelect = false;


        this.txtStuffName = new TTTextBoxColumn();
        this.txtStuffName.DataMember = "MedicalStuffDef.Name";
        this.txtStuffName.Name = "Name";
        this.txtStuffName.ToolTipText = i18n("M10514", "Adı");
        this.txtStuffName.Width = 300;
        this.txtStuffName.DisplayIndex = 1;
        this.txtStuffName.HeaderText = i18n("M18550", "Malzeme Adı");

        this.txtStuffCode = new TTTextBoxColumn();
        this.txtStuffCode.DataMember = "MedicalStuffDef.Code";
        this.txtStuffCode.Name = "Code";
        this.txtStuffCode.ToolTipText = "Kodu";
        this.txtStuffCode.Width = 100;
        this.txtStuffCode.DisplayIndex = 2;
        this.txtStuffCode.HeaderText = i18n("M18587", "Malzeme Kodu");

        this.MedicalStuffGroup = new TTVisual.TTObjectListBox();
        this.MedicalStuffGroup.ListDefName = "MedicalStuffGroupListDef";
        this.MedicalStuffGroup.DataMember = "MedicalStuffGroup";
        this.MedicalStuffGroup.Name = "MedicalStuffGroup";
        this.MedicalStuffGroup.Width = 200;
        this.MedicalStuffGroup.AutoCompleteDialogWidth = "30%";
        /*this.MedicalStuffGroup.DisplayIndex = 3;
        this.MedicalStuffGroup.HeaderText = i18n("M18577", "Malzeme Grubu");
*/
        this.StuffAmount = new TTTextBoxColumn();
        this.StuffAmount.DataMember = "StuffAmount";
        this.StuffAmount.Name = "StuffAmount";
        this.StuffAmount.ToolTipText = i18n("M19030", "Miktar");
        this.StuffAmount.ReadOnly = false;
        this.StuffAmount.Width = 50;
        this.StuffAmount.DisplayIndex = 4;
        this.StuffAmount.HeaderText = i18n("M19030", "Miktar");

        this.cmbRaporSureTuru = new TTVisual.TTEnumComboBox();
        this.cmbRaporSureTuru.DataTypeName = "PeriodUnitTypeEnum";
        this.cmbRaporSureTuru.Required = true;
        this.cmbRaporSureTuru.BackColor = "#F0F0F0";
        this.cmbRaporSureTuru.Enabled = true;
        this.cmbRaporSureTuru.Name = "cmbRaporSureTuru";
        this.cmbRaporSureTuru.TabIndex = 4;

        this.MedicalStuffPlaceOfUsage = new TTVisual.TTObjectListBox();
        this.MedicalStuffPlaceOfUsage.ListDefName = "MedicalStuffPlaceListDef";
        this.MedicalStuffPlaceOfUsage.DataMember = "MedicalStuffPlaceOfUsage";
        this.MedicalStuffPlaceOfUsage.Name = "MedicalStuffPlaceOfUsage";
        this.MedicalStuffPlaceOfUsage.Width = 130;
        this.MedicalStuffPlaceOfUsage.AutoCompleteDialogWidth = "30%";
        /*this.MedicalStuffPlaceOfUsage.HeaderText = "Kullanım Yeri";
        this.MedicalStuffPlaceOfUsage.DisplayIndex = 5;
*/

        this.PeriodUnit = new TTTextBoxColumn();
        this.PeriodUnit.DataMember = "PeriodUnit";
        this.PeriodUnit.Name = "PeriodUnit";
        this.PeriodUnit.ToolTipText = i18n("M17974", "Kullanım Periyodu");
        this.PeriodUnit.ReadOnly = false;
        this.PeriodUnit.Width = 100;
        this.PeriodUnit.DisplayIndex = 6;
        this.PeriodUnit.HeaderText = "K. Periyodu";

        this.PeriodUnitType = new TTEnumComboBox();
        this.PeriodUnitType.DataTypeName = "PeriodUnitTypeEnum";
        this.PeriodUnitType.DataMember = "PeriodUnitType";
        this.PeriodUnitType.Name = "PeriodUnitType";
        this.PeriodUnitType.ReadOnly = false;
        /*this.PeriodUnitType.Width = 120;
        this.PeriodUnitType.DisplayIndex = 6;
        this.PeriodUnitType.HeaderText = "K.P. Birimi";
*/
        this.StuffDescription = new TTTextBoxColumn();
        this.StuffDescription.DataMember = "StuffDescription";
        this.StuffDescription.Name = "StuffDescription";
        this.StuffDescription.ToolTipText = i18n("M10469", "Açıklama");
        this.StuffDescription.ReadOnly = false;
        this.StuffDescription.Width = 200;
        this.StuffDescription.DisplayIndex = 8;
        this.StuffDescription.HeaderText = i18n("M10469", "Açıklama");

        this.gridMedulaStuffColumns = [this.txtStuffCode, this.txtStuffName, this.StuffUsageType, this.MedicalStuffGroup, this.StuffAmount, this.MedicalStuffPlaceOfUsage, this.PeriodUnit, this.PeriodUnitType, this.StuffDescription];

        this.Controls = [this.Description, this.ReportNo, this.StartDate, this.EndDate, this.ProcedureDoctor];






    }


}
