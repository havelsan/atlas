//$9F3BBCCF
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyTestResultEntryFormViewModel, AddRadiologyProcedureViewModel, RadiologyProcedureObject, AddRadiologyProcedureInput } from './RadiologyTestResultEntryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ITTObject } from 'NebulaClient/StorageManager/InstanceManagement/ITTObject';
import { RadiologyTest, RadiologyTemplate } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTestBaseForm } from "Modules/Tibbi_Surec/Radyoloji_Modulu/RadiologyTestBaseForm";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SagSol } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { RadiologyTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { vmPatientRadiologyTest } from "./RadiologyTestResultEntryFormViewModel";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { OpenColorPrescription_Input } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { CommonHelper } from 'app/Helper/CommonHelper';

@Component({
    selector: 'RadiologyTestResultEntryForm',
    templateUrl: './RadiologyTestResultEntryForm.html',
    providers: [MessageService]
})
export class RadiologyTestResultEntryForm extends RadiologyTestBaseForm implements OnInit {

    cmbDateInterval: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: 'MontlyDateIntervalEnum',
        ShowClearButton: true,
    };
    MonthlyTimeInterval: string;
    showPathologyResultsPopUp: boolean = false;
    showAddRadiologyProcedurePopup: boolean = false;
    addRadiologyProcedureViewModel: AddRadiologyProcedureViewModel = new AddRadiologyProcedureViewModel();
    addRadiologyProcedureInput: AddRadiologyProcedureInput = new AddRadiologyProcedureInput();
    showAddRadiologyTemplatePopup: boolean = false;

    public RadiologyTestColumns = [{
        "caption": "İşlem Kodu",
        dataField: "Code",
        width: 80,
        allowSorting: false,
        fixed: true
    }, {
            "caption": "İşlem Adı",
            dataField: "Name",
            width: 250,
            allowSorting: false,
            fixed: true
        }];

    public RadiologyTemplateColumns = [ {
        "caption": "Şablon Adı",
        dataField: "TemplateName",
        width: 250,
        allowSorting: false
      
    }, {
            "caption": "",
            width: 77,
            allowSorting: false,
            allowEditing: false,
            cellTemplate: "radiologyTemplate"

        }];

    public PatientAllRadiologyTestsColumns = [
        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 100,
            allowSorting: true,
            fixed: true,
            dataType: 'date',
            format: 'dd/MM/yyyy'
        },
        {
            "caption": i18n("M16696", "İstem Yapan"),
            dataField: "RequestedByResUser",
            allowSorting: true
        },
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "ProcedureCode",
            width: 80,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "ProcedureName",
            width: 250,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M16837", "İşlem Durum"),
            dataField: "ActionStatus",
            width: 100,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M22078", "Sonuç"),
            dataField: "ProcedureResultLink",
            width: 60,
            allowSorting: true,
            cellTemplate: "linkCellTemplateResult",
            fixed: true
        },
        {
            "caption": "Rapor",
            dataField: "ProcedureReportLink",
            width: 60,
            allowSorting: true,
            cellTemplate: "linkCellTemplateReport",
            fixed: true
        },
        {
            "caption": i18n("M16695", "İstem Uygulayan"),
            dataField: "ProcedureResUser",
            width: 150,
            allowSorting: true
        },
        {
            "caption": i18n("M16461", "İmaj Erişim No"),
            dataField: "AccessionNo",
            width: 150,
            allowSorting: true
        }

    ];
    PatientAllRadiologyTests: Array<vmPatientRadiologyTest> = new Array<vmPatientRadiologyTest>();


    ActionDate: TTVisual.ITTDateTimePicker;
    AccessionNo: TTVisual.ITTTextBox;
    Amount: TTVisual.ITTTextBoxColumn;
    ApprovedBy: TTVisual.ITTObjectListBox;
    Barcode: TTVisual.ITTTextBoxColumn;
    cmdImage: TTVisual.ITTButton;
    CommonDescription: TTVisual.ITTTextBox;
    Deparment: TTVisual.ITTObjectListBox;
    Description: TTVisual.ITTTextBox;
    DisTaahhutNo: TTVisual.ITTTextBox;
    DistributionType: TTVisual.ITTTextBoxColumn;
    DPADetailFirmPriceOffer: TTVisual.ITTListBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    Equipment: TTVisual.ITTObjectListBox;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    kdv: TTVisual.ITTTextBoxColumn;
    kodsuzMalzemeFiyati: TTVisual.ITTTextBoxColumn;
    labelDisTaahhutNo: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    malzemeBrans: TTVisual.ITTTextBoxColumn;
    malzemeCokluOzelDurum: TTVisual.ITTButtonColumn;
    malzemeOzelDurum: TTVisual.ITTListBoxColumn;
    malzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    malzemeTuru: TTVisual.ITTListBoxColumn;
    Material: TTVisual.ITTListBoxColumn;
    Materials: TTVisual.ITTGrid;
    OwnerType: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    ReportedBy: TTVisual.ITTObjectListBox;
    Requester: TTVisual.ITTObjectListBox;
    rtfReport: TTVisual.ITTRichTextBoxControl;
    SurgeryDirectPurchaseGrids: TTVisual.ITTGrid;
    tabAdditionalRequest: TTVisual.ITTTabPage;
    tabAnamnez: TTVisual.ITTTabPage;
    RequestReasonAssesment: TTVisual.ITTEnumComboBox;
    tabDescription: TTVisual.ITTTabPage;
    taniCokluOzelDurum: TTVisual.ITTButtonColumn;
    taniOzelDurum: TTVisual.ITTListBoxColumn;
    TestTechnicianNote: TTVisual.ITTTextBox;
    ttbuttonToothSchema: TTVisual.ITTButton;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlabelBirim: TTVisual.ITTLabel;
    ttlabelDrAnesteziTescilNo: TTVisual.ITTLabel;
    ttlabelKesi: TTVisual.ITTLabel;
    ttlabelSagSol: TTVisual.ITTLabel;
    TTListBoxDrAnesteziTescilNo: TTVisual.ITTObjectListBox;
    TTListBoxKesi: TTVisual.ITTObjectListBox;
    TTListBoxSagSol: TTVisual.ITTObjectListBox;
    ttMasterResourceUserCheck: TTVisual.ITTCheckBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextboxBirim: TTVisual.ITTTextBox;
    txtBarcode: TTVisual.ITTTextBoxColumn;
    txtKesinlesenMiktar: TTVisual.ITTTextBoxColumn;
    UBBCode: TTVisual.ITTTextBoxColumn;
    RadiographyTechnique: TTVisual.ITTRichTextBoxControl;
    Results: TTVisual.ITTRichTextBoxControl;
    ComparisonInfo: TTVisual.ITTRichTextBoxControl;
    ImageQualityAssesment: TTVisual.ITTEnumComboBox;
    public GridEpisodeDiagnosisColumns = [];
    public MaterialsColumns = [];
    public SurgeryDirectPurchaseGridsColumns = [];
    _PatientObjectID: string = "";
    public radiologyTestResultEntryFormViewModel: RadiologyTestResultEntryFormViewModel = new RadiologyTestResultEntryFormViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    private RadiologyTestResultEntryForm_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestResultEntryForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private sideBarMenuService: ISidebarMenuService,
                private objectContextService: ObjectContextService,
        protected activeUserService: IActiveUserService,
        protected helpMenuService: HelpMenuService,
                protected ngZone: NgZone,
                private reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyTestResultEntryForm_DocumentUrl;
        this.showPathologyResultsPopUp = false;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdImage_Click(): Promise<void> {
        //TODO:Showedit!
        //            string accessionNoStr = this._RadiologyTest.AccessionNo.ToString();
        //            string patientIdStr = this._RadiologyTest.EpisodeAction.Episode.Patient.ID.ToString();
        //            TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
        if (this._RadiologyTest.AccessionNo != null)
        {

            let accessionNoStr: string = this._RadiologyTest.AccessionNo.toString();

            let sysparam: string = (await SystemParameterService.GetParameterValue("PACSVIEWERURL", null));
            let URLLink: string = "";

            if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME") {
                URLLink = sysparam + "?an=" + accessionNoStr + "&usr=extreme";
            }
            else if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2") {
                let patient: Patient = await this.objectContextService.getObject<Patient>(new Guid(this._RadiologyTest.Episode.Patient.toString()), Patient.ObjectDefID);
                URLLink = sysparam + "?accession=" + accessionNoStr + "&patientid=" + patient.UniqueRefNo.toString() + "&ietab=true";
            }
            else if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX") {
                URLLink = sysparam + "&accession=" + accessionNoStr + "&StudyReload=1";
            }


            if (URLLink == null) {
                InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
            } else {
                let win = window.open(URLLink, '_blank');
                win.focus();
            }
        }
        else {
            InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
        }

    }
    public cmdGetPatientAllRadiologyTests_Click(): void {

        this.PatientAllRadiologyTests = new Array<vmPatientRadiologyTest>();
        if (this.MonthlyTimeInterval !== undefined && this.MonthlyTimeInterval !== null) {
            let apiUrl: string = 'api/RadiologyTestService/GetPatientAllRadiologyTests?PatientObjectId=' + this._RadiologyTest.Episode.Patient.toString() + '&TimeInterval=' + this.MonthlyTimeInterval.toString();
            this.httpService.get<Array<vmPatientRadiologyTest>>(apiUrl).then(result => {
                if (result != null)
                {
                    for (let radTest of result) {
                        let vmRadiologyTest: vmPatientRadiologyTest = new vmPatientRadiologyTest();
                        vmRadiologyTest.SubActionProcedureObjectId = radTest.SubActionProcedureObjectId;
                        vmRadiologyTest.ActionStatus = radTest.ActionStatus;
                        vmRadiologyTest.ProcedureCode = radTest.ProcedureCode;
                        vmRadiologyTest.ProcedureName = radTest.ProcedureName;
                        vmRadiologyTest.RequestDate = radTest.RequestDate;
                        vmRadiologyTest.RequestedByResUser = radTest.RequestedByResUser;
                        vmRadiologyTest.ProcedureResUser = radTest.ProcedureResUser;
                        vmRadiologyTest.ProcedureReportLink = radTest.ProcedureReportLink;
                        vmRadiologyTest.ProcedureResultLink = radTest.ProcedureResultLink;
                        vmRadiologyTest.isReportShown = radTest.isReportShown;
                        vmRadiologyTest.isResultShown = radTest.isResultShown;
                        vmRadiologyTest.AccessionNo = radTest.AccessionNo;
                        this.PatientAllRadiologyTests.push(vmRadiologyTest);
                    }
                }
            });
        }
        else
            InfoBox.Alert(i18n("M30807", "Geçmiş tarih aralığı seçmelisiniz!"));
    }

    async selectReport(row) {
            this.openRadiologyReport(row.data.SubActionProcedureObjectId);
    }

    async selectResultView(row) {
            this.openInNewTab(row.displayValue);
    }

    async openRadiologyReport(SubActionProcedureObjectId: Guid) {
        let that = this;

        const objectIdParam = new GuidParam(SubActionProcedureObjectId);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('RadiologyTestResultReport', reportParameters);


    }

    btnShowLISResultViewForAllEpisodes_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURLForAllEpisodes(this.radiologyTestResultEntryFormViewModel.EpisodeID, this.radiologyTestResultEntryFormViewModel.PatientTCNo).then(() => {
            this.openInNewTab(this.viewResultURL);
        });
    }

    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Bu hizmetin sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }
    public async GridEpisodeDiagnosis_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:ShowEdit!
        //   if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
        //            {

        //                RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
        //                rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
        //            }
        let a = 1;
    }
    public async Materials_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:Showedit!
        //            if (((ITTGridCell)Materials.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
        //            {

        //                RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
        //                rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
        //            }
        let a = 1;
    }
    public async ttbuttonToothSchema_Click(): Promise<void> {
        //TODO:Showedit!
        //   RadiologyTestDentalToothSchema radiologyTestDentalForm = new RadiologyTestDentalToothSchema();
        //            if (radiologyTestDentalForm != null)
        //                radiologyTestDentalForm.ShowReadOnly(this,_RadiologyTest);
        let a = 1;
    }
    public async ttMasterResourceUserCheck_CheckedChanged(): Promise<void> {
        if (this.ttMasterResourceUserCheck.Value === true) {
            this.ReportedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.toString() + "'";
        }
        else {
            this.ReportedBy.ListFilterExpression = null;
        }
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            if (transDef.FromStateDefID === RadiologyTest.RadiologyTestStates.ResultEntry && transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Procedure)
                this.DisplayRadiologyRepeatReason();
            if (transDef.FromStateDefID === RadiologyTest.RadiologyTestStates.ResultEntry && transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Completed)
                this.LinkRadiologyTestToCopyReportInfo(transDef);
        }
        if (this.radiologyTestResultEntryFormViewModel.TestType == "CR" || this.radiologyTestResultEntryFormViewModel.TestType == "US" || this.radiologyTestResultEntryFormViewModel.TestType == "MR" || this.radiologyTestResultEntryFormViewModel.TestType == "CT" || this.radiologyTestResultEntryFormViewModel.TestType == "MG") {

            if (this._RadiologyTest.Report == null || this._RadiologyTest.Report == "") { //|| CommonHelper.getInnerText(this._RadiologyTest.Report.toString()).length < 50)

                throw new TTException("Rapor İçeriği En Az 50 Karakterden Oluşmalıdır.");
            } else {
                let report_tr: string = CommonHelper.getInnerText(this._RadiologyTest.Report.toString()).trimRight();
                let report_tl: string = report_tr.trimLeft();
                if (report_tl.length < 50)
                    throw new TTException("Rapor İçeriği En Az 50 Karakterden Oluşmalıdır.");
            }
        }

        if (this.radiologyTestResultEntryFormViewModel.TestType == "MR" || this.radiologyTestResultEntryFormViewModel.TestType == "CT" || this.radiologyTestResultEntryFormViewModel.TestType == "MG") {
            if (this._RadiologyTest.RequestReasonAssesment == null)
                throw new TTException("Tetkik İstem Nedeni Değerlendime Alanını Seçiniz.");
            if (this._RadiologyTest.ImageQualityAssesment == null)
                throw new TTException("Çekim Kalitesi Değerlendime Alanını Seçiniz.");
            if (this._RadiologyTest.Results == null || this._RadiologyTest.Results == "")// || CommonHelper.getInnerText(this._RadiologyTest.Results.toString()).length < 50)
                throw new TTException("Bulgular Alanına En Az 50 Karakter Olacak Şekilde Veri Girişi Yapınız.");
            else {
                let result_tr: string = CommonHelper.getInnerText(this._RadiologyTest.Results.toString()).trimRight();
                let result_tl: string = result_tr.trimLeft();
                if (result_tl.length < 50)
                    throw new TTException("Rapor İçeriği En Az 50 Karakterden Oluşmalıdır.");
            }
        }

     

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    protected async PreScript() {
        super.PreScript();

        this.AddHelpMenu();


        if (this.radiologyTestResultEntryFormViewModel.RadiologyTemplates.length > 0) {
            if (this._RadiologyTest.Report == null || this._RadiologyTest.Report == "")
                this.showAddRadiologyTemplatePopup = true;

        }


        //this.SetProcedureDoctorAsCurrentResource();

        //if ((<ITTObject>this._RadiologyTest).IsReadOnly === false)
        //{
        //    let resUser: ResUser = await this.objectContextService.getObject<ResUser>(this.activeUserService.ActiveUser.UserObject.ObjectID, ResUser.ObjectDefID);
        //    this._RadiologyTest.ReportedBy = resUser;

        //    //Tabip ve Radyoloji uzmanı rolu varsa Sorumlu Tabip alanına current user gelecek
        //    if (this.activeUserService.ActiveUser.HasRole(new Guid('8876d00f-f5ff-4477-8848-7c176f2eb061')) || this.activeUserService.ActiveUser.HasRole(new Guid('c318a87a-c781-4024-b4b1-d6c3bffe9bc6')))
        //        this._RadiologyTest.ProcedureDoctor = resUser;
        //}

        /*
        if (this.ttMasterResourceUserCheck.Value !== null && this.ttMasterResourceUserCheck.Value === true) {
            this.ReportedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource + "'";
        }

        let guidRoleID: Guid = new Guid("c318a87a-c781-4024-b4b1-d6c3bffe9bc6"); //Radyoloji Uzmanı roleID
        if (Common.CurrentUser.HasRole(guidRoleID)) {
            this.DropStateButton(RadiologyTest.RadiologyTestStates.Approve);
        }
        else {
            this.DropStateButton(RadiologyTest.RadiologyTestStates.Completed);
        }

        this.SetTreatmentMaterialListFilter(<TTObjectDef>TTObjectDefManager.Instance.ObjectDefs["RadiologyMaterial"], <TTVisual.ITTGridColumn>this.Materials.Columns["Material"]);
        if ((<ITTObject>this._RadiologyTest).IsReadOnly === false) {
            this._RadiologyTest.ReportedBy = Common.CurrentResource;
        }
        if (this._RadiologyTest.IsGunubirlikTakip === true && this._RadiologyTest.MedulaProvision !== null && this._RadiologyTest.MedulaProvision.ProvisionNo !== null) {
            this.rtfReport.Required = true;
        }
        */

    }

    protected async ClientSidePreScript(): Promise<void> {

        let radTestDef: RadiologyTestDefinition = await this.objectContextService.getObject<RadiologyTestDefinition>(this._RadiologyTest.ProcedureObject.ObjectID, RadiologyTestDefinition.ObjectDefID);
        if (radTestDef.IsRISEntegratedTest == false)
            this.DropStateButton(RadiologyTest.RadiologyTestStates.Procedure);
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("RADIOLOGYTEST", this.radiologyTestResultEntryFormViewModel._RadiologyTest.ObjectID, null,new DynamicComponentInputParam(null, new ActiveIDsModel(this.radiologyTestResultEntryFormViewModel._RadiologyTest.ObjectID,null,null)));

        }
        super.AfterContextSavedScript(transDef);
        await this.load(RadiologyTestResultEntryFormViewModel);
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestResultEntryFormViewModel = new RadiologyTestResultEntryFormViewModel();
        this._ViewModel = this.radiologyTestResultEntryFormViewModel;
        this.radiologyTestResultEntryFormViewModel._RadiologyTest = this._TTObject as RadiologyTest;
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.Radiology = new Radiology();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.Radiology.RequestDoctor = new ResUser();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.Episode = new Episode();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.ResUser = new ResUser();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.SagSol = new SagSol();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.AyniFarkliKesi = new AyniFarkliKesi();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.Equipment = new ResRadiologyEquipment();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.ProcedureObject = new ProcedureDefinition();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.ProcedureDoctor = new ResUser();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.Department = new ResRadiologyDepartment();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = new Array<RadiologyMaterial>();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids = new Array<SurgeryDirectPurchaseGrid>();
        this.radiologyTestResultEntryFormViewModel._RadiologyTest.ReportedBy = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestResultEntryFormViewModel = this._ViewModel as RadiologyTestResultEntryFormViewModel;
        that._TTObject = this.radiologyTestResultEntryFormViewModel._RadiologyTest;
        if (this.radiologyTestResultEntryFormViewModel == null)
            this.radiologyTestResultEntryFormViewModel = new RadiologyTestResultEntryFormViewModel();
        if (this.radiologyTestResultEntryFormViewModel._RadiologyTest == null)
            this.radiologyTestResultEntryFormViewModel._RadiologyTest = new RadiologyTest();
        let radiologyObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["EpisodeAction"];
        if (radiologyObjectID != null && (typeof radiologyObjectID === 'string')) {
            let radiology = that.radiologyTestResultEntryFormViewModel.Radiologys.find(o => o.ObjectID.toString() === radiologyObjectID.toString());
             if (radiology) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.Radiology = radiology;
            }
            if (radiology != null) {
                let requestDoctorObjectID = radiology["RequestDoctor"];
                if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
                    let requestDoctor = that.radiologyTestResultEntryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                     if (requestDoctor) {
                        radiology.RequestDoctor = requestDoctor;
                    }
                }
            }
        }
        let episodeObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyTestResultEntryFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.Episode = episode;
            }
            that.radiologyTestResultEntryFormViewModel._RadiologyTest.Radiology.Episode = episode;
            if (episode != null) {
                episode.Diagnosis = that.radiologyTestResultEntryFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyTestResultEntryFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyTestResultEntryFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyTestResultEntryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                    let ozelDurumObjectID = detailItem["OzelDurum"];
                    if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                        let ozelDurum = that.radiologyTestResultEntryFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                         if (ozelDurum) {
                            detailItem.OzelDurum = ozelDurum;
                        }
                    }
                }
            }
        }
        let resUserObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["ResUser"];
        if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
            let resUser = that.radiologyTestResultEntryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
             if (resUser) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.ResUser = resUser;
            }
        }
        let sagSolObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["SagSol"];
        if (sagSolObjectID != null && (typeof sagSolObjectID === 'string')) {
            let sagSol = that.radiologyTestResultEntryFormViewModel.SagSols.find(o => o.ObjectID.toString() === sagSolObjectID.toString());
             if (sagSol) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.SagSol = sagSol;
            }
        }
        let ayniFarkliKesiObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["AyniFarkliKesi"];
        if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === 'string')) {
            let ayniFarkliKesi = that.radiologyTestResultEntryFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
             if (ayniFarkliKesi) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.AyniFarkliKesi = ayniFarkliKesi;
            }
        }
        let equipmentObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["Equipment"];
        if (equipmentObjectID != null && (typeof equipmentObjectID === 'string')) {
            let equipment = that.radiologyTestResultEntryFormViewModel.ResRadiologyEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
             if (equipment) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.Equipment = equipment;
            }
        }
        let procedureObjectObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.radiologyTestResultEntryFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
             if (procedureObject) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.ProcedureObject = procedureObject;
            }
        }
        let procedureDoctorObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.radiologyTestResultEntryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.ProcedureDoctor = procedureDoctor;
            }
        }
        let departmentObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
            let department = that.radiologyTestResultEntryFormViewModel.ResRadiologyDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
             if (department) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.Department = department;
            }
        }
        that.radiologyTestResultEntryFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = that.radiologyTestResultEntryFormViewModel.MaterialsGridList;
        for (let detailItem of that.radiologyTestResultEntryFormViewModel.MaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.radiologyTestResultEntryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.radiologyTestResultEntryFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.radiologyTestResultEntryFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let malzemeTuruObjectID = detailItem["MalzemeTuru"];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === 'string')) {
                let malzemeTuru = that.radiologyTestResultEntryFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                 if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.radiologyTestResultEntryFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        that.radiologyTestResultEntryFormViewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids = that.radiologyTestResultEntryFormViewModel.SurgeryDirectPurchaseGridsGridList;
        for (let detailItem of that.radiologyTestResultEntryFormViewModel.SurgeryDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === 'string')) {
                let dPADetailFirmPriceOffer = that.radiologyTestResultEntryFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                 if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
                if (dPADetailFirmPriceOffer != null) {
                    let offeredUBBObjectID = dPADetailFirmPriceOffer["OfferedUBB"];
                    if (offeredUBBObjectID != null && (typeof offeredUBBObjectID === 'string')) {
                        let offeredUBB = that.radiologyTestResultEntryFormViewModel.ProductDefinitions.find(o => o.ObjectID.toString() === offeredUBBObjectID.toString());
                         if (offeredUBB) {
                            dPADetailFirmPriceOffer.OfferedUBB = offeredUBB;
                        }
                    }
                }
                if (dPADetailFirmPriceOffer != null) {
                    let directPurchaseActionDetailObjectID = dPADetailFirmPriceOffer["DirectPurchaseActionDetail"];
                    if (directPurchaseActionDetailObjectID != null && (typeof directPurchaseActionDetailObjectID === 'string')) {
                        let directPurchaseActionDetail = that.radiologyTestResultEntryFormViewModel.DirectPurchaseActionDetails.find(o => o.ObjectID.toString() === directPurchaseActionDetailObjectID.toString());
                         if (directPurchaseActionDetail) {
                            dPADetailFirmPriceOffer.DirectPurchaseActionDetail = directPurchaseActionDetail;
                        }
                    }
                }
            }
        }
        let reportedByObjectID = that.radiologyTestResultEntryFormViewModel._RadiologyTest["ReportedBy"];
        if (reportedByObjectID != null && (typeof reportedByObjectID === 'string')) {
            let reportedBy = that.radiologyTestResultEntryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === reportedByObjectID.toString());
             if (reportedBy) {
                that.radiologyTestResultEntryFormViewModel._RadiologyTest.ReportedBy = reportedBy;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyTestResultEntryFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ActionDate != event) {
                this._RadiologyTest.ActionDate = event;
            }
        }
    }

    public onApprovedByChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ProcedureDoctor != event) {
                this._RadiologyTest.ProcedureDoctor = event;
            }
        }
    }

    public onCommonDescriptionChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.GeneralDescription != event) {
                this._RadiologyTest.GeneralDescription = event;
            }
        }
    }

    public onDeparmentChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Department != event) {
                this._RadiologyTest.Department = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Description != event) {
                this._RadiologyTest.Description = event;
            }
        }
    }

    public onRequestReasonAssesmentChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.RequestReasonAssesment != event) {
                this._RadiologyTest.RequestReasonAssesment = event;
            }
        }
    }

    public onDisTaahhutNoChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.DisTaahhutNo != event) {
                this._RadiologyTest.DisTaahhutNo = event;
            }
        }
    }

    public onEquipmentChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Equipment != event) {
                this._RadiologyTest.Equipment = event;
            }
        }
    }

    public onOwnerTypeChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.OwnerType != event) {
                this._RadiologyTest.OwnerType = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.PreDiagnosis != event) {
                this._RadiologyTest.PreDiagnosis = event;
            }
        }
    }

    public onProcedureObjectChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ProcedureObject != event) {
                this._RadiologyTest.ProcedureObject = event;
            }
        }
    }

    public onReportedByChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ReportedBy != event) {
                this._RadiologyTest.ReportedBy = event;
            }
        }
    }

    public onRequesterChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Radiology != null && this._RadiologyTest.Radiology.RequestDoctor != event) {
                this._RadiologyTest.Radiology.RequestDoctor = event;
            }
        }
    }

    public onrtfReportChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Report != event) {
                this._RadiologyTest.Report = event;
            }
        }
    }
    public onRadiographyTechniqueChanged(event): void {
        if (this._RadiologyTest != null && this._RadiologyTest.RadiographyTechnique != event) {
            this._RadiologyTest.RadiographyTechnique = event;
        }
    }
    public onResultsChanged(event): void {
        if (this._RadiologyTest != null && this._RadiologyTest.Results != event) {
            this._RadiologyTest.Results = event;
        }
    }
    public onComparisonInfoChanged(event): void {
        if (this._RadiologyTest != null && this._RadiologyTest.ComparisonInfo != event) {
            this._RadiologyTest.ComparisonInfo = event;
        }
    }
    public onImageQualityAssesmentChanged(event): void {
        if (this._RadiologyTest != null && this._RadiologyTest.ImageQualityAssesment != event) {
            this._RadiologyTest.ImageQualityAssesment = event;
        }
    }

    public onTestTechnicianNoteChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.TechnicianNote != event) {
                this._RadiologyTest.TechnicianNote = event;
            }
        }
    }

    public onTTListBoxDrAnesteziTescilNoChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ResUser != event) {
                this._RadiologyTest.ResUser = event;
            }
        }
    }

    public onTTListBoxKesiChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.AyniFarkliKesi != event) {
                this._RadiologyTest.AyniFarkliKesi = event;
            }
        }
    }

    public onTTListBoxSagSolChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.SagSol != event) {
                this._RadiologyTest.SagSol = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.AdditionalRequest != event) {
                this._RadiologyTest.AdditionalRequest = event;
            }
        }
    }

    public ontttextboxBirimChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.birim != event) {
                this._RadiologyTest.birim = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.CommonDescription, "Text", this.__ttObject, "GeneralDescription");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "AdditionalRequest");
        redirectProperty(this.OwnerType, "Text", this.__ttObject, "OwnerType");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.TestTechnicianNote, "Text", this.__ttObject, "TechnicianNote");
        redirectProperty(this.tttextboxBirim, "Text", this.__ttObject, "birim");
        redirectProperty(this.rtfReport, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.RequestReasonAssesment, "Value", this.__ttObject, "RequestReasonAssesment");
        redirectProperty(this.DisTaahhutNo, "Text", this.__ttObject, "DisTaahhutNo");
        redirectProperty(this.RadiographyTechnique, "Rtf", this.__ttObject, "RadiographyTechnique");
        redirectProperty(this.Results, "Rtf", this.__ttObject, "Results");
        redirectProperty(this.ComparisonInfo, "Rtf", this.__ttObject, "ComparisonInfo");
        redirectProperty(this.ImageQualityAssesment, "Value", this.__ttObject, "ImageQualityAssesment");
    }

    public initFormControls(): void {
        this.ttMasterResourceUserCheck = new TTVisual.TTCheckBox();
        this.ttMasterResourceUserCheck.Value = true;
        this.ttMasterResourceUserCheck.Text = i18n("M21102", "Sadece Bölüme Bağlı Kullanıcıları Listele");
        this.ttMasterResourceUserCheck.Font = "Name=Times New Roman, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttMasterResourceUserCheck.Name = "ttMasterResourceUserCheck";
        this.ttMasterResourceUserCheck.TabIndex = 7;


        this.RadiographyTechnique = new TTVisual.TTRichTextBoxControl();
        this.RadiographyTechnique.Name = "RadiographyTechnique";
        this.RadiographyTechnique.TabIndex = 33;

        this.Results = new TTVisual.TTRichTextBoxControl();
        this.Results.Name = "Results";
        this.Results.TabIndex = 31;

        this.ImageQualityAssesment = new TTVisual.TTEnumComboBox();
        this.ImageQualityAssesment.DataTypeName = "ImageQualityAssesmentEnum";
        this.ImageQualityAssesment.Name = "ImageQualityAssesment";
        this.ImageQualityAssesment.TabIndex = 29;

        this.ComparisonInfo = new TTVisual.TTRichTextBoxControl();
        this.ComparisonInfo.Name = "ComparisonInfo";
        this.ComparisonInfo.TabIndex = 35;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 5;

        this.tabAnamnez = new TTVisual.TTTabPage();
        this.tabAnamnez.DisplayIndex = 0;
        this.tabAnamnez.TabIndex = 0;
        this.tabAnamnez.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.tabAnamnez.Name = "tabAnamnez";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 0;
        this.PREDIAGNOSIS.Height = "100px";

        this.tabDescription = new TTVisual.TTTabPage();
        this.tabDescription.DisplayIndex = 1;
        this.tabDescription.TabIndex = 1;
        this.tabDescription.Text = i18n("M10483", "Açıklamalar");
        this.tabDescription.Name = "tabDescription";

        this.RequestReasonAssesment = new TTVisual.TTEnumComboBox();
        this.RequestReasonAssesment.DataTypeName = "RequestReasonAssesment";
        this.RequestReasonAssesment.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestReasonAssesment.Name = "RequestReasonAssesment";
        this.RequestReasonAssesment.TabIndex = 82;

        this.CommonDescription = new TTVisual.TTTextBox();
        this.CommonDescription.Multiline = true;
        this.CommonDescription.BackColor = "#F0F0F0";
        this.CommonDescription.ReadOnly = true;
        this.CommonDescription.Name = "CommonDescription";
        this.CommonDescription.TabIndex = 7;
        this.CommonDescription.Height = "100px";

        this.tabAdditionalRequest = new TTVisual.TTTabPage();
        this.tabAdditionalRequest.DisplayIndex = 2;
        this.tabAdditionalRequest.TabIndex = 2;
        this.tabAdditionalRequest.Text = i18n("M13522", "Ek İstek");
        this.tabAdditionalRequest.Name = "tabAdditionalRequest";

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 7;
        this.tttextbox1.Height = "100px";

        this.OwnerType = new TTVisual.TTTextBox();
        this.OwnerType.Name = "OwnerType";
        this.OwnerType.TabIndex = 8;
        this.OwnerType.Visible = false;

        this.Requester = new TTVisual.TTObjectListBox();
        this.Requester.ReadOnly = true;
        this.Requester.ListDefName = "UserListDefinition";
        this.Requester.Name = "Requester";
        this.Requester.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16902", "İşlem Zamanı");
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 22;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel13.BackColor = "#DCDCDC";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 28;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = i18n("M17026", "Kabul Sebebi");
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 4;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel16.BackColor = "#DCDCDC";
        this.ttlabel16.ForeColor = "#000000";
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 2;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 4;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = i18n("M20117", "Özgeçmiş");
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 60;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisListDefinition";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = i18n("M22736", "Tanı");
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 400;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnosisType.DataMember = "DiagnosisType";
        this.EpisodeDiagnosisType.DisplayIndex = 2;
        this.EpisodeDiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.EpisodeDiagnosisType.Name = "EpisodeDiagnosisType";
        this.EpisodeDiagnosisType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 60;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 130;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.taniOzelDurum = new TTVisual.TTListBoxColumn();
        this.taniOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.taniOzelDurum.DataMember = "OzelDurum";
        this.taniOzelDurum.DisplayIndex = 7;
        this.taniOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.taniOzelDurum.Name = "taniOzelDurum";
        this.taniOzelDurum.Width = 100;

        this.taniCokluOzelDurum = new TTVisual.TTButtonColumn();
        this.taniCokluOzelDurum.DisplayIndex = 8;
        this.taniCokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.taniCokluOzelDurum.Name = "taniCokluOzelDurum";
        this.taniCokluOzelDurum.Width = 100;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 10;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M23303", "Tetkik Bilgileri");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.TTListBoxDrAnesteziTescilNo = new TTVisual.TTObjectListBox();
        this.TTListBoxDrAnesteziTescilNo.ListDefName = "ResUserListDefinition";
        this.TTListBoxDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxDrAnesteziTescilNo.Name = "TTListBoxDrAnesteziTescilNo";
        this.TTListBoxDrAnesteziTescilNo.TabIndex = 9;

        this.ttlabelDrAnesteziTescilNo = new TTVisual.TTLabel();
        this.ttlabelDrAnesteziTescilNo.Text = i18n("M10968", "Anestezi Dr. Tescil No.");
        this.ttlabelDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelDrAnesteziTescilNo.Name = "ttlabelDrAnesteziTescilNo";
        this.ttlabelDrAnesteziTescilNo.TabIndex = 81;

        this.TTListBoxSagSol = new TTVisual.TTObjectListBox();
        this.TTListBoxSagSol.ListDefName = "SagSolListDefinition";
        this.TTListBoxSagSol.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxSagSol.Name = "TTListBoxSagSol";
        this.TTListBoxSagSol.TabIndex = 6;

        this.TTListBoxKesi = new TTVisual.TTObjectListBox();
        this.TTListBoxKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.TTListBoxKesi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxKesi.Name = "TTListBoxKesi";
        this.TTListBoxKesi.TabIndex = 3;


        this.ttlabelSagSol = new TTVisual.TTLabel();
        this.ttlabelSagSol.Text = i18n("M21122", "Sağ / Sol");
        this.ttlabelSagSol.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelSagSol.Name = "ttlabelSagSol";
        this.ttlabelSagSol.TabIndex = 77;

        this.ttlabelKesi = new TTVisual.TTLabel();
        this.ttlabelKesi.Text = "Aynı Kesi/ Farklı Seans";
        this.ttlabelKesi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelKesi.Name = "ttlabelKesi";
        this.ttlabelKesi.TabIndex = 75;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12031", " Bölüm");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 0;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 4;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M12222", "Cihaz");
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 2;

        this.rtfReport = new TTVisual.TTRichTextBoxControl();
        this.rtfReport.TemplateGroupName = "RADIOLOGY";
        this.rtfReport.BackColor = "#FFFFFF";
        this.rtfReport.Name = "rtfReport";
        this.rtfReport.TabIndex = 7;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M23112", "Teknisyen Notu");
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 66;

        this.Equipment = new TTVisual.TTObjectListBox();
        this.Equipment.ListDefName = "ResRadiologyEquipmentListDefinition";
        this.Equipment.Name = "Equipment";
        this.Equipment.TabIndex = 2;

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.ListDefName = "RadiologyTestListDefinition";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 0;

        this.tttextboxBirim = new TTVisual.TTTextBox();
        this.tttextboxBirim.Name = "tttextboxBirim";
        this.tttextboxBirim.TabIndex = 8;

        this.ttlabelBirim = new TTVisual.TTLabel();
        this.ttlabelBirim.Text = "Birim";
        this.ttlabelBirim.Name = "ttlabelBirim";
        this.ttlabelBirim.TabIndex = 81;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M10469", "Açıklama");
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 65;

        this.ApprovedBy = new TTVisual.TTObjectListBox();
        this.ApprovedBy.Required = true;
        this.ApprovedBy.ListDefName = "SpecialistDoctorListDefinition";
        this.ApprovedBy.Name = "ApprovedBy";
        this.ApprovedBy.TabIndex = 11;

        this.DisTaahhutNo = new TTVisual.TTTextBox();
        this.DisTaahhutNo.Name = "DisTaahhutNo";
        this.DisTaahhutNo.TabIndex = 10;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M22158", "Sorumlu Tabip");
        this.ttlabel12.BackColor = "#DCDCDC";
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 28;

        this.Deparment = new TTVisual.TTObjectListBox();
        this.Deparment.ReadOnly = true;
        this.Deparment.ListDefName = "ResRadiologyDepartmentListDefinition";
        this.Deparment.Name = "Deparment";
        this.Deparment.TabIndex = 1;

        this.ttbuttonToothSchema = new TTVisual.TTButton();
        this.ttbuttonToothSchema.Text = i18n("M12940", "Diş Şeması");
        this.ttbuttonToothSchema.Name = "ttbuttonToothSchema";
        this.ttbuttonToothSchema.TabIndex = 11;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "TETKİK";
        this.ttlabel1.Font = "Name=Tahoma, Size=9,75, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#FF0000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 70;

        this.labelDisTaahhutNo = new TTVisual.TTLabel();
        this.labelDisTaahhutNo.Text = i18n("M12945", "Diş Taahhüt Numarası");
        this.labelDisTaahhutNo.Name = "labelDisTaahhutNo";
        this.labelDisTaahhutNo.TabIndex = 38;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Rapor";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 68;

        this.TestTechnicianNote = new TTVisual.TTTextBox();
        this.TestTechnicianNote.Multiline = true;
        this.TestTechnicianNote.Name = "TestTechnicianNote";
        this.TestTechnicianNote.TabIndex = 5;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = i18n("M18553", "Malzeme Bilgileri");
        this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage2.Name = "tttabpage2";

        this.Materials = new TTVisual.TTGrid();
        this.Materials.Name = "Materials";
        this.Materials.TabIndex = 75;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "ConsumableMaterialAndDrugList";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M21314", "Sarf Edilen Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 500;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Visible = false;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 75;

        this.UBBCode = new TTVisual.TTTextBoxColumn();
        this.UBBCode.DataMember = "UBBCode";
        this.UBBCode.DisplayIndex = 4;
        this.UBBCode.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCode.Name = "UBBCode";
        this.UBBCode.ReadOnly = true;
        this.UBBCode.Width = 80;

        this.kodsuzMalzemeFiyati = new TTVisual.TTTextBoxColumn();
        this.kodsuzMalzemeFiyati.DataMember = "KodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyati.DisplayIndex = 5;
        this.kodsuzMalzemeFiyati.HeaderText = i18n("M17688", "Kodsuz Malzeme Fiyatı");
        this.kodsuzMalzemeFiyati.Name = "kodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyati.Visible = false;
        this.kodsuzMalzemeFiyati.Width = 100;

        this.malzemeTuru = new TTVisual.TTListBoxColumn();
        this.malzemeTuru.ListDefName = "MalzemeTuruListDefinition";
        this.malzemeTuru.DataMember = "MalzemeTuru";
        this.malzemeTuru.DisplayIndex = 6;
        this.malzemeTuru.HeaderText = i18n("M18650", "Malzemenin Türü");
        this.malzemeTuru.Name = "malzemeTuru";
        this.malzemeTuru.Visible = false;
        this.malzemeTuru.Width = 100;

        this.kdv = new TTVisual.TTTextBoxColumn();
        this.kdv.DataMember = "Kdv";
        this.kdv.DisplayIndex = 7;
        this.kdv.HeaderText = "KDV";
        this.kdv.Name = "kdv";
        this.kdv.Visible = false;
        this.kdv.Width = 100;

        this.malzemeBrans = new TTVisual.TTTextBoxColumn();
        this.malzemeBrans.DataMember = "MalzemeBrans";
        this.malzemeBrans.DisplayIndex = 8;
        this.malzemeBrans.HeaderText = i18n("M18636", "Malzemenin Branşı");
        this.malzemeBrans.Name = "malzemeBrans";
        this.malzemeBrans.Visible = false;
        this.malzemeBrans.Width = 100;

        this.malzemeSatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.malzemeSatinAlisTarihi.DataMember = "ActionDate";
        this.malzemeSatinAlisTarihi.DisplayIndex = 9;
        this.malzemeSatinAlisTarihi.HeaderText = i18n("M18604", "Malzeme Satın Alış Tarihi");
        this.malzemeSatinAlisTarihi.Name = "malzemeSatinAlisTarihi";
        this.malzemeSatinAlisTarihi.Visible = false;
        this.malzemeSatinAlisTarihi.Width = 100;

        this.malzemeOzelDurum = new TTVisual.TTListBoxColumn();
        this.malzemeOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.malzemeOzelDurum.DataMember = "OzelDurum";
        this.malzemeOzelDurum.DisplayIndex = 10;
        this.malzemeOzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.malzemeOzelDurum.Name = "malzemeOzelDurum";
        this.malzemeOzelDurum.Visible = false;
        this.malzemeOzelDurum.Width = 100;

        this.malzemeCokluOzelDurum = new TTVisual.TTButtonColumn();
        this.malzemeCokluOzelDurum.DisplayIndex = 11;
        this.malzemeCokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.malzemeCokluOzelDurum.Name = "malzemeCokluOzelDurum";
        this.malzemeCokluOzelDurum.Visible = false;
        this.malzemeCokluOzelDurum.Width = 100;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.TabIndex = 1;
        this.tttabpage3.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.tttabpage3.Name = "tttabpage3";

        this.SurgeryDirectPurchaseGrids = new TTVisual.TTGrid();
        this.SurgeryDirectPurchaseGrids.AllowUserToDeleteRows = false;
        this.SurgeryDirectPurchaseGrids.AllowUserToAddRows = false;
        this.SurgeryDirectPurchaseGrids.ReadOnly = true;
        this.SurgeryDirectPurchaseGrids.Name = "SurgeryDirectPurchaseGrids";
        this.SurgeryDirectPurchaseGrids.TabIndex = 0;
        this.SurgeryDirectPurchaseGrids.AllowUserToAddRows = false;

        this.DPADetailFirmPriceOffer = new TTVisual.TTListBoxColumn();
        this.DPADetailFirmPriceOffer.ListDefName = "DirectPurchaseActionDetailList";
        this.DPADetailFirmPriceOffer.DataMember = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.DisplayIndex = 0;
        this.DPADetailFirmPriceOffer.HeaderText = i18n("M10240", "22F Malzeme");
        this.DPADetailFirmPriceOffer.Name = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.Width = 500;

        this.txtBarcode = new TTVisual.TTTextBoxColumn();
        this.txtBarcode.DataMember = "ProductNumber";
        this.txtBarcode.DisplayIndex = 1;
        this.txtBarcode.HeaderText = "Barkod";
        this.txtBarcode.Name = "txtBarcode";
        this.txtBarcode.ReadOnly = true;
        this.txtBarcode.Width = 300;

        this.txtKesinlesenMiktar = new TTVisual.TTTextBoxColumn();
        this.txtKesinlesenMiktar.DataMember = "CertainAmount";
        this.txtKesinlesenMiktar.DisplayIndex = 2;
        this.txtKesinlesenMiktar.HeaderText = i18n("M17504", "Kesinleşen Miktar");
        this.txtKesinlesenMiktar.Name = "txtKesinlesenMiktar";
        this.txtKesinlesenMiktar.ReadOnly = true;
        this.txtKesinlesenMiktar.Width = "400";

        this.ReportedBy = new TTVisual.TTObjectListBox();
        this.ReportedBy.Required = true;
        this.ReportedBy.ListDefName = "RadiologyUserListDefinition";
        this.ReportedBy.Name = "ReportedBy";
        this.ReportedBy.TabIndex = 6;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M20880", "Rapor Yazan");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 28;

        this.cmdImage = new TTVisual.TTButton();
        this.cmdImage.Text = i18n("M16462", "İmaj Görüntüle");
        this.cmdImage.Name = "cmdImage";
        this.cmdImage.TabIndex = 9;

        this.AccessionNo = new TTVisual.TTTextBox();
        this.AccessionNo.BackColor = "#F0F0F0";
        this.AccessionNo.ReadOnly = true;
        this.AccessionNo.Name = "AccessionNo";
        this.AccessionNo.TabIndex = 3;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.taniOzelDurum, this.taniCokluOzelDurum];
        this.MaterialsColumns = [this.Material, this.Barcode, this.DistributionType, this.Amount, this.UBBCode, this.kodsuzMalzemeFiyati, this.malzemeTuru, this.kdv, this.malzemeBrans, this.malzemeSatinAlisTarihi, this.malzemeOzelDurum, this.malzemeCokluOzelDurum];
        this.SurgeryDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar];
        this.tttabcontrol2.Controls = [this.tabAnamnez, this.tabDescription, this.tabAdditionalRequest];
        this.tabAnamnez.Controls = [this.PREDIAGNOSIS];
        this.tabDescription.Controls = [this.CommonDescription];
        this.tabAdditionalRequest.Controls = [this.tttextbox1];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3];
        this.tttabpage1.Controls = [this.TTListBoxDrAnesteziTescilNo, this.ttlabelDrAnesteziTescilNo, this.RequestReasonAssesment,this.TTListBoxSagSol, this.TTListBoxKesi, this.ttlabelSagSol, this.ttlabelKesi, this.ttlabel4, this.Description, this.ttlabel5, this.rtfReport, this.ttlabel10, this.Equipment, this.ProcedureObject, this.tttextboxBirim, this.ttlabelBirim, this.ttlabel9, this.ApprovedBy, this.DisTaahhutNo, this.ttlabel12, this.Deparment, this.ttbuttonToothSchema, this.ttlabel1, this.labelDisTaahhutNo, this.ttlabel11, this.TestTechnicianNote];
        this.tttabpage2.Controls = [this.Materials];
        this.tttabpage3.Controls = [this.SurgeryDirectPurchaseGrids];
        this.Controls = [this.ComparisonInfo, this.RadiographyTechnique, this.Results, this.ImageQualityAssesment,this.ttMasterResourceUserCheck, this.RequestReasonAssesment,this.tttabcontrol2, this.tabAnamnez, this.PREDIAGNOSIS, this.tabDescription, this.CommonDescription, this.tabAdditionalRequest, this.tttextbox1, this.OwnerType, this.Requester, this.ActionDate, this.labelProcessTime, this.ttlabel13, this.ttlabel15, this.PATIENTGROUPENUM, this.ttlabel16, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.taniOzelDurum, this.taniCokluOzelDurum, this.ReasonForAdmission, this.tttabcontrol1, this.tttabpage1, this.TTListBoxDrAnesteziTescilNo, this.ttlabelDrAnesteziTescilNo, this.TTListBoxSagSol, this.TTListBoxKesi, this.ttlabelSagSol, this.ttlabelKesi, this.ttlabel4, this.Description, this.ttlabel5, this.rtfReport, this.ttlabel10, this.Equipment, this.ProcedureObject, this.tttextboxBirim, this.ttlabelBirim, this.ttlabel9, this.ApprovedBy, this.DisTaahhutNo, this.ttlabel12, this.Deparment, this.ttbuttonToothSchema, this.ttlabel1, this.labelDisTaahhutNo, this.ttlabel11, this.TestTechnicianNote, this.tttabpage2, this.Materials, this.Material, this.Barcode, this.DistributionType, this.Amount, this.UBBCode, this.kodsuzMalzemeFiyati, this.malzemeTuru, this.kdv, this.malzemeBrans, this.malzemeSatinAlisTarihi, this.malzemeOzelDurum, this.malzemeCokluOzelDurum, this.tttabpage3, this.SurgeryDirectPurchaseGrids, this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar, this.ReportedBy, this.ttlabel8, this.cmdImage, this.AccessionNo];

    }

    colorPresClick() {
        let input: OpenColorPrescription_Input = new OpenColorPrescription_Input();
        input.SubEpisodeObjectID = new Guid(this._RadiologyTest.SubEpisode.toString());
        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSON';
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let colorPrescriptionForRadiology = new DynamicSidebarMenuItem();
        colorPrescriptionForRadiology.key = 'colorPrescriptionForRadiology';
        colorPrescriptionForRadiology.componentInstance = this;
        colorPrescriptionForRadiology.label = 'Reçete';
        colorPrescriptionForRadiology.icon = 'ai ai-recete';
        colorPrescriptionForRadiology.clickFunction = this.colorPresClick;
        this.sideBarMenuService.addMenu('YardimciMenu', colorPrescriptionForRadiology);

        let pathologyRequest = new DynamicSidebarMenuItem();
        pathologyRequest.key = 'pathologyRequest';
        pathologyRequest.icon = 'ai ai-chemical';
        pathologyRequest.label = i18n("M20230", "Patoloji İstek");
        pathologyRequest.componentInstance = this.helpMenuService;
        pathologyRequest.clickFunction = this.helpMenuService.onPathologyRequest;
        pathologyRequest.parameterFunctionInstance = this;
        pathologyRequest.getParamsFunction = this.getParamsFunctionForRadiology;
        pathologyRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', pathologyRequest);

        let radiologyHistory = new DynamicSidebarMenuItem();
        radiologyHistory.key = 'radiologyHistory';
        radiologyHistory.icon = 'glyphicon glyphicon-cd';
        radiologyHistory.label = 'Radyoloji Sonuçları';
        radiologyHistory.componentInstance = this.helpMenuService;
        radiologyHistory.clickFunction = this.helpMenuService.openRadiologyHistory;
        radiologyHistory.parameterFunctionInstance = this;
        radiologyHistory.getParamsFunction = this.getParamsFunctionForRadiology;
        radiologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', radiologyHistory);

        let pathologyHistory = new DynamicSidebarMenuItem();
        pathologyHistory.key = 'pathologyHistory';
        pathologyHistory.icon = 'fas fa-notes-medical';
        pathologyHistory.label = 'Patoloji Sonuçları';
        pathologyHistory.componentInstance = this.helpMenuService;
        pathologyHistory.clickFunction = this.helpMenuService.openPathologyHistory;
        pathologyHistory.parameterFunctionInstance = this;
        pathologyHistory.getParamsFunction = this.getParamsFunctionForRadiology;
        pathologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', pathologyHistory);

        let testHistory = new DynamicSidebarMenuItem();
        testHistory.key = 'testHistory';
        testHistory.icon = 'fa fa-flask';
        testHistory.label = 'Laboratuvar Sonuçları';
        testHistory.componentInstance = this.helpMenuService;
        testHistory.clickFunction = this.helpMenuService.openTestHistory;
        testHistory.parameterFunctionInstance = this;
        testHistory.getParamsFunction = this.getParamsFunctionForRadiology;
        testHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', testHistory);

        let addRadiologyProcedure = new DynamicSidebarMenuItem();
        addRadiologyProcedure.key = 'addRadiologyProcedure';
        addRadiologyProcedure.icon = 'fas fa-plus';
        addRadiologyProcedure.label = "Radyoloji İşlemi Ekle";
        addRadiologyProcedure.componentInstance = this;
        addRadiologyProcedure.clickFunction = this.AddRadiologyProcedure;
        addRadiologyProcedure.parameterFunctionInstance = this;
        addRadiologyProcedure.getParamsFunction = this.getParamsFunctionForRadiology;
        addRadiologyProcedure.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', addRadiologyProcedure);

        let radiologyTemplate = new DynamicSidebarMenuItem();
        radiologyTemplate.key = 'radiologyTemplate';
        radiologyTemplate.icon = 'fas fa-file-alt';
        radiologyTemplate.label = "Radyoloji Şablon Tanımları";
        radiologyTemplate.componentInstance = this.helpMenuService;
        radiologyTemplate.clickFunction = this.helpMenuService.OpenRadiologyTemplate;
        radiologyTemplate.parameterFunctionInstance = this;
        radiologyTemplate.getParamsFunction = this.getParamsFunctionForRadiology;
        radiologyTemplate.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', radiologyTemplate);



        //let pathologyHistory = new DynamicSidebarMenuItem();
        //pathologyHistory.key = 'pathologyHistory';
        //pathologyHistory.icon = 'fas fa-notes-medical';
        //pathologyHistory.label = "Tüm Patoloji Sonuçları";
        //pathologyHistory.componentInstance = this;
        //pathologyHistory.clickFunction = this.onOpenPathologyHistory;
        //pathologyHistory.parameterFunctionInstance = this;
        //pathologyHistory.getParamsFunction = this.getParamsFunctionForRadiology;
        //pathologyHistory.ParentInstance = this;
        //this.sideBarMenuService.addMenu('YardimciMenu', pathologyHistory);

    }

  
    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('colorPrescriptionForRadiology');
        this.sideBarMenuService.removeMenu('pathologyRequest');
        this.sideBarMenuService.removeMenu('radiologyHistory');
        this.sideBarMenuService.removeMenu('pathologyHistory');
        this.sideBarMenuService.removeMenu('testHistory');
        this.sideBarMenuService.removeMenu('addRadiologyProcedure');
        this.sideBarMenuService.removeMenu('radiologyTemplate');
    }

    public onOpenPathologyHistory() {
        this._PatientObjectID = this._RadiologyTest.Episode.Patient.toString();
        this.showPathologyResultsPopUp = true;
    }



    public AddRadiologyProcedure() {
        let that = this;
        this.showAddRadiologyProcedurePopup = true;

        let fullApiUrl: string = "/api/RadiologyTestService/LoadAddRadiologyProcedureViewModel";

        this.httpService.get<AddRadiologyProcedureViewModel>(fullApiUrl)
            .then(response => {
                that.addRadiologyProcedureViewModel = response as AddRadiologyProcedureViewModel;
                that.addRadiologyProcedureInput = new AddRadiologyProcedureInput();
                that.addRadiologyProcedureInput.SelectedRadiologyProcedureList = new Array<RadiologyProcedureObject>();
                this.addRadiologyProcedureInput.RadiologyTestObjectID = this.radiologyTestResultEntryFormViewModel._RadiologyTest.ObjectID.toString();
            })
            .catch(error => {
                console.log(error);
            });

    }

    public RadiologyProcedureSelected(data) {
        let radiologyTest = data.selectedItem as RadiologyProcedureObject;
        this.addRadiologyProcedureInput.SelectedRadiologyProcedureList.push(radiologyTest);
        
    }

    public SaveSelectedRadiologyTests() {
        let that = this;
        let fullApiUrl: string = "/api/RadiologyTestService/SaveSelectedRadiologyTests";
        this.httpService.post<any>(fullApiUrl, that.addRadiologyProcedureInput)
            .then(response => {
                this.messageService.showSuccess("İşlem Kaydedildi.");
                that.addRadiologyProcedureInput.SelectedRadiologyProcedureList = new Array<RadiologyProcedureObject>();
            })
            .catch(error => {
                console.log(error);
            });
    }

    public SelectRadiologyTemplate(row: RadiologyTemplate) {
        this._RadiologyTest.Report = row.Report;
        this._RadiologyTest.Results = row.Results;
        this._RadiologyTest.ComparisonInfo = row.ComparisonInfo;
        this._RadiologyTest.RadiographyTechnique = row.RadiographyTechnique;
        this.showAddRadiologyTemplatePopup = false;
    }

    public CloseRadiologyTemplate() {
        this.showAddRadiologyTemplatePopup = false;
    }
}
