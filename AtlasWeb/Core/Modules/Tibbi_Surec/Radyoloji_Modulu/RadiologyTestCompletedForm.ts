//$396C17EB
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyTestCompletedFormViewModel, RadiologyTestObject, CopyReportInput } from "./RadiologyTestCompletedFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Dictionary } from "NebulaClient/System/Collections/Dictionaries/Dictionary";
import { Episode, RadiologyAdditionalReport, EtkinMaddeTeshisEslestirme } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTestBaseForm } from "Modules/Tibbi_Surec/Radyoloji_Modulu/RadiologyTestBaseForm";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { RadiologyRepeatReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { OpenColorPrescription_Input } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicReportParameters } from '../../../wwwroot/app/Fw/Components/Reporting/HvlDynamicReportComponent';




@Component({
    selector: 'RadiologyTestCompletedForm',
    templateUrl: './RadiologyTestCompletedForm.html',
    providers: [MessageService]
})
export class RadiologyTestCompletedForm extends RadiologyTestBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AccessionNo: TTVisual.ITTTextBox;
    Amount: TTVisual.ITTTextBoxColumn;
    ApprovedBy: TTVisual.ITTObjectListBox;
    Barcode: TTVisual.ITTTextBoxColumn;
    cityOfBirth: TTVisual.ITTTextBox;
    cmdImage: TTVisual.ITTButton;
    CommonDescription: TTVisual.ITTTextBox;
    Deparment: TTVisual.ITTObjectListBox;
    Description: TTVisual.ITTTextBox;
    DPADetailFirmPriceOffer: TTVisual.ITTListBoxColumn;
    encboSex: TTVisual.ITTEnumComboBox;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    Equipment: TTVisual.ITTObjectListBox;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    labelProcessTime: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Materials: TTVisual.ITTGrid;
    OwnerType: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PatientBirthDate: TTVisual.ITTDateTimePicker;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    public nextTransitions: Dictionary<Guid, TTObjectStateTransitionDef>;
    //public OwnerTestGrid: TTGrid;
    public OwnerTypeX: string;
    public parentform: TTVisual.TTForm;
    public tgSelectedRowIndex: number;
    //public Uparentform: TTUnboundForm;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    RepeatReason: TTVisual.ITTObjectListBox;
    ReportedBy: TTVisual.ITTObjectListBox;
    rtfReport: TTVisual.ITTRichTextBoxControl;
    SurgeryDirectPurchaseGrids: TTVisual.ITTGrid;
    tabAdditionalRequest: TTVisual.ITTTabPage;
    tabAnamnez: TTVisual.ITTTabPage;
    tabDescription: TTVisual.ITTTabPage;
    TabPageHidden: TTVisual.ITTTabPage;
    TabPageInfo: TTVisual.ITTTabControl;
    TestDate: TTVisual.ITTDateTimePicker;
    TestTechnicianNote: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel19: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttobjectlistbox2: TTVisual.ITTObjectListBox;
    ttobjectlistbox3: TTVisual.ITTObjectListBox;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    txtBarcode: TTVisual.ITTTextBoxColumn;
    txtKesinlesenMiktar: TTVisual.ITTTextBoxColumn;
    RadiographyTechnique: TTVisual.ITTRichTextBoxControl;
    Results: TTVisual.ITTRichTextBoxControl;
    ComparisonInfo: TTVisual.ITTRichTextBoxControl;
    public GridEpisodeDiagnosisColumns = [];
    public MaterialsColumns = [];
    public SurgeryDirectPurchaseGridsColumns = [];
    public radiologyTestCompletedFormViewModel: RadiologyTestCompletedFormViewModel = new RadiologyTestCompletedFormViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    private RadiologyTestCompletedForm_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestCompletedForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private reportService: AtlasReportService,
                protected modalService: IModalService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyTestCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdImage_Click(): Promise<void> {

        if (this._RadiologyTest.AccessionNo != null)
        {
            let accessionNoStr: string = this._RadiologyTest.AccessionNo.toString();

            let sysparam: string = (await SystemParameterService.GetParameterValue("PACSVIEWERURL", null));
            let URLLink: string = "";

            if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME") {
                URLLink = sysparam + "?an=" + accessionNoStr + "&usr=extreme";

            }
            else if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2") {
                URLLink = sysparam + "?accession=" + accessionNoStr + "&patientid=" + this._RadiologyTest.Episode.Patient.UniqueRefNo.toString() + "&ietab=true";
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

    public async cmdPrintResultReport_Click(): Promise<ModalActionResult>  {
        //Yeni Rapor

        if (this.radiologyTestCompletedFormViewModel.paramNewRadiologyReport) {

            let reportData: DynamicReportParameters = {

                Code: 'RADYOLOJISONUCRAPOR',
                ReportParams: { ObjectID: this._RadiologyTest.ObjectID },
                ViewerMode: true

            };

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'HvlDynamicReportComponent';
                componentInfo.ModuleName = 'DevexpressReportingModule';
                componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                componentInfo.InputParam = reportData;

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "RADYOLOJI SONUÇ RAPORU"

                modalInfo.fullScreen = true;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {

                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        } else {
            //Eski Rapor
            const objectIdParam = new GuidParam(this._RadiologyTest.ObjectID.toString());
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('RadiologyTestResultReport', reportParameters);
        }

    }


    public async FillNextTransitionsOnPanel(): Promise<void> {
        /*
        this.nextTransitions = new Dictionary<Guid, TTObjectStateTransitionDef>();
        if (this._RadiologyTest.CurrentStateDef === null)
            return;
        for (let transDef of this._RadiologyTest.CurrentStateDef.OutgoingTransitions) {
            if (TTUser.CurrentUser.HasRight(transDef, this._RadiologyTest, <number>TTSecurityAuthority.RightsEnum.Transition)) {
                this.nextTransitions.push(transDef.StateTransitionDefID, transDef);
            }
        }
        */
    }
    public async stepBtn_ClickOnPanel(sender: Object, e: Object): Promise<void> {
        /*
        let transDef: TTObjectStateTransitionDef = <TTObjectStateTransitionDef>(<Button>sender).Tag;
        //  _RadiologyTest.CurrentStateDef = transDef.ToStateDef;
        OnOkClick(transDef);
        */
    }
    public async OnCancelClick(): Promise<void> {
        this.Close();
    }
    public async OnShown(e: Object): Promise<void> {
        /*
        super.OnShown(e);
        this.OwnerTypeX = this._RadiologyTest.OwnerType;
        this.OwnerType.Visible = false;
        if (this.OwnerTypeX === "TTUnboundForm") {
            this.OwnerTestGrid = (<TTGrid>(<TTGroupBox>Owner.Controls["ttgroupbox2"]).Controls["TestGrid"]);
            this.tgSelectedRowIndex = Convert.ToInt32((<TTTextBox>Owner.Controls["tgSelectedRow"]).Text);
        }
        */
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {

    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        if (transDef !== null) {
            if (transDef.FromStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.Completed.valueOf() && transDef.ToStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.Cancelled.valueOf())
            {
                let getDescription: string = await TTVisual.InputForm.GetText(i18n("M16531", "İptal açıklaması giriniz."), "", false, true);
                if (String.isNullOrEmpty(getDescription) === false)
                    this._RadiologyTest.ReasonOfCancel = getDescription;
                else
                    throw new TTException(i18n("M16532", "İptal açıklaması girmelisiniz!"));
            }
        }

    }

    protected async ClientSidePreScript(): Promise<void> {

        //Bu form hem Completed asamasında hem de Reported asamasında acılıyor. Completed asamasında Raporladı state ının drop edılmesı gerekıyor.
        //Completed asamasindan Cancelled asamasina gecmesi de engelleniyor.
        //Completed aşamasında Tekrar Nedeni alanı editable yapılıyor.
         if (this._RadiologyTest.CurrentStateDefID.toString() == RadiologyTest.RadiologyTestStates.Completed.toString())
         {
             this.DropStateButton(RadiologyTest.RadiologyTestStates.Reported);
             this.DropStateButton(RadiologyTest.RadiologyTestStates.Cancelled);
             this.RepeatReason.ReadOnly = false;
        }
    }

    protected async PreScript() {
        //            if(this._RadiologyTest.CurrentStateDefID == RadiologyTest.States.Completed && !(TTUser.CurrentUser.IsSuperUser || TTUser.CurrentUser.IsPowerUser))
        //            {
        //                bool hcFound  = false;
        //                foreach (TTUserRole role in TTUser.CurrentUser.Roles)
        //                {
        //                    if (role.Name == "Sağlık Kurulu Başkanı" || role.Name == "Sağlık Kurulu Yazıcısı")
        //                    {
        //                        foreach(EpisodeAction ea in this._RadiologyTest.Episode.EpisodeActions)
        //                        {
        //                            if(ea is HealthCommittee)
        //                            {
        //                                hcFound = true;
        //                                break;
        //                            }
        //                        }
        //                        if(!hcFound)
        //                            throw new Exception("Sağlık Kurulu işlemi olmayan bir vakada \"Radyoloji Test Sonuç Formu\"na erişim yetkiniz bulunmamaktadır.");
        //                        break;
        //                    }
        //                }
        //

/*
        (<TTTabControl>this.TabPageInfo).TabPages[0].BackColor = Color.FromArgb(239, 235, 222);
        (<TTTabControl>this.TabPageInfo).TabPages[1].BackColor = Color.FromArgb(239, 235, 222);
        for (let tabPage of this.TabPageInfo.TabPages) {
            if (tabPage.Visible === false)
                this.TabPageInfo.HideTabPage(tabPage);
        }
        */
    }

    // *****Method declarations end *****


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void>
    {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("RADIOLOGYTEST", this.radiologyTestCompletedFormViewModel._RadiologyTest.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
    }

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestCompletedFormViewModel = new RadiologyTestCompletedFormViewModel();
        this._ViewModel = this.radiologyTestCompletedFormViewModel;
        this.radiologyTestCompletedFormViewModel._RadiologyTest = this._TTObject as RadiologyTest;
        this.radiologyTestCompletedFormViewModel._RadiologyTest.ProcedureObject = new ProcedureDefinition();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.RepeatReason = new RadiologyRepeatReasonDefinition();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = new Array<RadiologyMaterial>();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.Episode = new Episode();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.Episode.Patient = new Patient();
     //   this.radiologyTestCompletedFormViewModel._RadiologyTest.Episode.Patient.CityOfBirth = new SKRSILKodlari();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.Episode.Patient.Sex = new SKRSCinsiyet();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.ProcedureDoctor = new ResUser();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.Department = new ResRadiologyDepartment();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.Equipment = new ResRadiologyEquipment();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.ReportedBy = new ResUser();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids = new Array<SurgeryDirectPurchaseGrid>();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.Radiology = new Radiology();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.Radiology.RequestDoctor = new ResUser();
        this.radiologyTestCompletedFormViewModel._RadiologyTest.RadiologyAdditionalReport = new RadiologyAdditionalReport();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestCompletedFormViewModel = this._ViewModel as RadiologyTestCompletedFormViewModel;
        that._TTObject = this.radiologyTestCompletedFormViewModel._RadiologyTest;
        if (this.radiologyTestCompletedFormViewModel == null)
            this.radiologyTestCompletedFormViewModel = new RadiologyTestCompletedFormViewModel();
        if (this.radiologyTestCompletedFormViewModel._RadiologyTest == null)
            this.radiologyTestCompletedFormViewModel._RadiologyTest = new RadiologyTest();
        let procedureObjectObjectID = that.radiologyTestCompletedFormViewModel._RadiologyTest["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.radiologyTestCompletedFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
             if (procedureObject) {
                that.radiologyTestCompletedFormViewModel._RadiologyTest.ProcedureObject = procedureObject;
            }
        }
        let repeatReasonObjectID = that.radiologyTestCompletedFormViewModel._RadiologyTest["RepeatReason"];
        if (repeatReasonObjectID != null && (typeof repeatReasonObjectID === "string")) {
            let repeatReason = that.radiologyTestCompletedFormViewModel.RadiologyRepeatReasonDefinitions.find(o => o.ObjectID.toString() === repeatReasonObjectID.toString());
            if (repeatReason) {
                that.radiologyTestCompletedFormViewModel._RadiologyTest.RepeatReason = repeatReason;
            }
        }

        that.radiologyTestCompletedFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = that.radiologyTestCompletedFormViewModel.MaterialsGridList;
        for (let detailItem of that.radiologyTestCompletedFormViewModel.MaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.radiologyTestCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
        let episodeObjectID = that.radiologyTestCompletedFormViewModel._RadiologyTest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyTestCompletedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.radiologyTestCompletedFormViewModel._RadiologyTest.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.radiologyTestCompletedFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                   /* if (patient != null) {
                        let cityOfBirthObjectID = patient["CityOfBirth"];
                        if (cityOfBirthObjectID != null && (typeof cityOfBirthObjectID === 'string')) {
                            let cityOfBirth = that.radiologyTestCompletedFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfBirthObjectID.toString());
                            patient.CityOfBirth = cityOfBirth;
                        }
                    }*/
                    if (patient != null) {
                        let sexObjectID = patient["Sex"];
                        if (sexObjectID != null && (typeof sexObjectID === 'string')) {
                            let sex = that.radiologyTestCompletedFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
                             if (sex) {
                                patient.Sex = sex;
                            }
                        }
                    }
                }
            }
            if (episode != null) {
                episode.Diagnosis = that.radiologyTestCompletedFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyTestCompletedFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyTestCompletedFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyTestCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let procedureDoctorObjectID = that.radiologyTestCompletedFormViewModel._RadiologyTest["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.radiologyTestCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.radiologyTestCompletedFormViewModel._RadiologyTest.ProcedureDoctor = procedureDoctor;
            }
        }
        let departmentObjectID = that.radiologyTestCompletedFormViewModel._RadiologyTest["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
            let department = that.radiologyTestCompletedFormViewModel.ResRadiologyDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
             if (department) {
                that.radiologyTestCompletedFormViewModel._RadiologyTest.Department = department;
            }
        }
        let equipmentObjectID = that.radiologyTestCompletedFormViewModel._RadiologyTest["Equipment"];
        if (equipmentObjectID != null && (typeof equipmentObjectID === 'string')) {
            let equipment = that.radiologyTestCompletedFormViewModel.ResRadiologyEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
             if (equipment) {
                that.radiologyTestCompletedFormViewModel._RadiologyTest.Equipment = equipment;
            }
        }
        let reportedByObjectID = that.radiologyTestCompletedFormViewModel._RadiologyTest["ReportedBy"];
        if (reportedByObjectID != null && (typeof reportedByObjectID === 'string')) {
            let reportedBy = that.radiologyTestCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === reportedByObjectID.toString());
             if (reportedBy) {
                that.radiologyTestCompletedFormViewModel._RadiologyTest.ReportedBy = reportedBy;
            }
        }

        
        that.radiologyTestCompletedFormViewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids = that.radiologyTestCompletedFormViewModel.SurgeryDirectPurchaseGridsGridList;
        for (let detailItem of that.radiologyTestCompletedFormViewModel.SurgeryDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === 'string')) {
                let dPADetailFirmPriceOffer = that.radiologyTestCompletedFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                 if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
                if (dPADetailFirmPriceOffer != null) {
                    let offeredUBBObjectID = dPADetailFirmPriceOffer["OfferedUBB"];
                    if (offeredUBBObjectID != null && (typeof offeredUBBObjectID === 'string')) {
                        let offeredUBB = that.radiologyTestCompletedFormViewModel.ProductDefinitions.find(o => o.ObjectID.toString() === offeredUBBObjectID.toString());
                         if (offeredUBB) {
                            dPADetailFirmPriceOffer.OfferedUBB = offeredUBB;
                        }
                    }
                }
                if (dPADetailFirmPriceOffer != null) {
                    let directPurchaseActionDetailObjectID = dPADetailFirmPriceOffer["DirectPurchaseActionDetail"];
                    if (directPurchaseActionDetailObjectID != null && (typeof directPurchaseActionDetailObjectID === 'string')) {
                        let directPurchaseActionDetail = that.radiologyTestCompletedFormViewModel.DirectPurchaseActionDetails.find(o => o.ObjectID.toString() === directPurchaseActionDetailObjectID.toString());
                         if (directPurchaseActionDetail) {
                            dPADetailFirmPriceOffer.DirectPurchaseActionDetail = directPurchaseActionDetail;
                        }
                    }
                }
            }
        }
        let radiologyObjectID = that.radiologyTestCompletedFormViewModel._RadiologyTest["EpisodeAction"];
        if (radiologyObjectID != null && (typeof radiologyObjectID === 'string')) {
            let radiology = that.radiologyTestCompletedFormViewModel.Radiologys.find(o => o.ObjectID.toString() === radiologyObjectID.toString());
             if (radiology) {
                that.radiologyTestCompletedFormViewModel._RadiologyTest.Radiology = radiology;
            }
            that.radiologyTestCompletedFormViewModel._RadiologyTest.Radiology.Episode = that.radiologyTestCompletedFormViewModel._RadiologyTest.Episode;
            if (radiology != null) {
                let requestDoctorObjectID = radiology["RequestDoctor"];
                if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
                    let requestDoctor = that.radiologyTestCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                     if (requestDoctor) {
                        radiology.RequestDoctor = requestDoctor;
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyTestCompletedFormViewModel);
        this.AddHelpMenu();
  
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

    public oncityOfBirthChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null &&
                this._RadiologyTest.Episode.Patient != null && this._RadiologyTest.Episode.Patient.BirthPlace != event) {
                this._RadiologyTest.Episode.Patient.BirthPlace = event;
            }
        }
    }

    public onCommonDescriptionChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Radiology != null && this._RadiologyTest.Radiology.Description != event) {
                this._RadiologyTest.Radiology.Description = event;
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

    public onencboSexChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null &&
                this._RadiologyTest.Episode.Patient != null && this._RadiologyTest.Episode.Patient.Sex != event) {
                this._RadiologyTest.Episode.Patient.Sex = event;
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

    public onPatientBirthDateChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null &&
                this._RadiologyTest.Episode.Patient != null && this._RadiologyTest.Episode.Patient.BirthDate != event) {
                this._RadiologyTest.Episode.Patient.BirthDate = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Radiology != null && this._RadiologyTest.Radiology.PreDiagnosis != event) {
                this._RadiologyTest.Radiology.PreDiagnosis = event;
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

    public onRepeatReasonChanged(event): void {
        if (this._RadiologyTest != null && this._RadiologyTest.RepeatReason != event) {
            this._RadiologyTest.RepeatReason = event;
        }
    }

    public onReportedByChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ReportedBy != event) {
                this._RadiologyTest.ReportedBy = event;
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

    public onTestDateChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.TestDate != event) {
                this._RadiologyTest.TestDate = event;
            }
        }
    }

    public onTestTechnicianNoteChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.TechnicianNote != event) {
                this._RadiologyTest.TechnicianNote = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Radiology != null && this._RadiologyTest.Radiology.RequestDoctor != event) {
                this._RadiologyTest.Radiology.RequestDoctor = event;
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

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null && this._RadiologyTest.Episode.HospitalProtocolNo != event) {
                this._RadiologyTest.Episode.HospitalProtocolNo = event;
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

    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "Radiology.PreDiagnosis");
        redirectProperty(this.CommonDescription, "Text", this.__ttObject, "Radiology.Description");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "AdditionalRequest");
        redirectProperty(this.rtfReport, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.encboSex, "Value", this.__ttObject, "Episode.Patient.Sex");
        redirectProperty(this.TestDate, "Value", this.__ttObject, "TestDate");
        redirectProperty(this.TestTechnicianNote, "Text", this.__ttObject, "TechnicianNote");
        redirectProperty(this.PatientBirthDate, "Value", this.__ttObject, "Episode.Patient.BirthDate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Episode.HospitalProtocolNo");
        redirectProperty(this.OwnerType, "Text", this.__ttObject, "OwnerType");
    }

    public initFormControls(): void {
        this.TabPageInfo = new TTVisual.TTTabControl();
        this.TabPageInfo.Name = "TabPageInfo";
        this.TabPageInfo.TabIndex = 76;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M23303", "Tetkik Bilgileri");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.rtfReport = new TTVisual.TTRichTextBoxControl();
        this.rtfReport.BackColor = "#FFFFFF";
        this.rtfReport.Name = "rtfReport";
        this.rtfReport.TabIndex = 74;
        this.rtfReport.TemplateGroupName = "RADYOLOJİ RAPOR TEMPLATE";
        this.rtfReport.ReadOnly = true;

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.ListDefName = "RadiologyTestListDefinition";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 0;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "TETKİK";
        this.ttlabel1.Font = "Name=Tahoma, Size=9,75, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#FF0000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 70;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Rapor";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 68;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Tekrar Nedeni";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 2;

        this.RepeatReason = new TTVisual.TTObjectListBox();
        this.RepeatReason.ListDefName = "RadiologyRepeatReasonListDefinition";
        this.RepeatReason.Name = "RepeatReason";
        this.RepeatReason.TabIndex = 3;


        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = i18n("M18553", "Malzeme Bilgileri");
        this.tttabpage2.Visible = false;
        this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage2.Name = "tttabpage2";

        this.Materials = new TTVisual.TTGrid();
        this.Materials.Name = "Materials";
        this.Materials.TabIndex = 75;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M18695", "Materyal");
        this.Material.Name = "Material";
        this.Material.Width = 500;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 75;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M21309", "Sarf");
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 74;

        this.TabPageHidden = new TTVisual.TTTabPage();
        this.TabPageHidden.DisplayIndex = 2;
        this.TabPageHidden.TabIndex = 1;
        this.TabPageHidden.Text = "TabPageHidden";
        this.TabPageHidden.Visible = false;
        this.TabPageHidden.Name = "TabPageHidden";

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 67;

      /*  this.cityOfBirth = new TTVisual.TTObjectListBox();
        this.cityOfBirth.ReadOnly = true;
        this.cityOfBirth.ListDefName = "CityListDefinition";
        this.cityOfBirth.Name = "cityOfBirth";
        this.cityOfBirth.TabIndex = 80;*/

        this.cityOfBirth = new TTVisual.TTTextBox();
        this.cityOfBirth.Name = "BirthPlace";
        this.cityOfBirth.TabIndex = 80;


        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12031", " Bölüm");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 0;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M10469", "Açıklama");
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 65;

        this.encboSex = new TTVisual.TTEnumComboBox();
        this.encboSex.DataTypeName = "SexEnum";
        this.encboSex.BackColor = "#F0F0F0";
        this.encboSex.Enabled = false;
        this.encboSex.Name = "encboSex";
        this.encboSex.TabIndex = 79;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M23112", "Teknisyen Notu");
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 66;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = i18n("M15436", "Hastanın Cinsiyeti");
        this.ttlabel18.BackColor = "#DCDCDC";
        this.ttlabel18.ForeColor = "#000000";
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 75;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = i18n("M15443", "Hastanın Doğum Yeri");
        this.ttlabel17.BackColor = "#DCDCDC";
        this.ttlabel17.ForeColor = "#000000";
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 75;

        this.TestTechnicianNote = new TTVisual.TTTextBox();
        this.TestTechnicianNote.Multiline = true;
        this.TestTechnicianNote.Name = "TestTechnicianNote";
        this.TestTechnicianNote.TabIndex = 64;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M15442", "Hastanın Doğum Tarihi");
        this.ttlabel14.BackColor = "#DCDCDC";
        this.ttlabel14.ForeColor = "#000000";
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 76;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M12222", "Cihaz");
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 2;

        this.OwnerType = new TTVisual.TTTextBox();
        this.OwnerType.Name = "OwnerType";
        this.OwnerType.TabIndex = 77;
        this.OwnerType.Visible = false;

        this.PatientBirthDate = new TTVisual.TTDateTimePicker();
        this.PatientBirthDate.BackColor = "#F0F0F0";
        this.PatientBirthDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.PatientBirthDate.Format = DateTimePickerFormat.Custom;
        this.PatientBirthDate.Enabled = false;
        this.PatientBirthDate.Name = "PatientBirthDate";
        this.PatientBirthDate.TabIndex = 78;

        this.ApprovedBy = new TTVisual.TTObjectListBox();
        this.ApprovedBy.ListDefName = "SpecialistDoctorListDefinition";
        this.ApprovedBy.Name = "ApprovedBy";
        this.ApprovedBy.TabIndex = 29;

        this.Deparment = new TTVisual.TTObjectListBox();
        this.Deparment.ListDefName = "ResRadiologyDepartmentListDefinition";
        this.Deparment.Name = "Deparment";
        this.Deparment.TabIndex = 1;

        this.ttlabel19 = new TTVisual.TTLabel();
        this.ttlabel19.Text = i18n("M20545", "Prokotol No");
        this.ttlabel19.BackColor = "#DCDCDC";
        this.ttlabel19.ForeColor = "#000000";
        this.ttlabel19.Name = "ttlabel19";
        this.ttlabel19.TabIndex = 75;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.BackColor = "#F0F0F0";
        this.tttextbox2.ReadOnly = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 81;

        this.Equipment = new TTVisual.TTObjectListBox();
        this.Equipment.ListDefName = "ResRadiologyEquipmentListDefinition";
        this.Equipment.Name = "Equipment";
        this.Equipment.TabIndex = 3;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M22158", "Sorumlu Tabip");
        this.ttlabel12.BackColor = "#DCDCDC";
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 28;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M20880", "Rapor Yazan");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 28;

        this.ReportedBy = new TTVisual.TTObjectListBox();
        this.ReportedBy.ListDefName = "UserListDefinition";
        this.ReportedBy.Name = "ReportedBy";
        this.ReportedBy.TabIndex = 29;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M19702", "Onaylanma Tarihi");
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 72;

        this.TestDate = new TTVisual.TTDateTimePicker();
        this.TestDate.BackColor = "#F0F0F0";
        this.TestDate.CustomFormat = "";
        this.TestDate.Format = DateTimePickerFormat.Long;
        this.TestDate.Enabled = false;
        this.TestDate.Name = "TestDate";
        this.TestDate.TabIndex = 73;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 3;
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.tttabpage3.Name = "tttabpage3";

        this.SurgeryDirectPurchaseGrids = new TTVisual.TTGrid();
        this.SurgeryDirectPurchaseGrids.AllowUserToDeleteRows = false;
        this.SurgeryDirectPurchaseGrids.AllowUserToAddRows = false;
        this.SurgeryDirectPurchaseGrids.ReadOnly = true;
        this.SurgeryDirectPurchaseGrids.Name = "SurgeryDirectPurchaseGrids";
        this.SurgeryDirectPurchaseGrids.TabIndex = 0;

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

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ReadOnly = true;
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 3;

        this.ttobjectlistbox2 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox2.ReadOnly = true;
        this.ttobjectlistbox2.ListDefName = "UserListDefinition";
        this.ttobjectlistbox2.Name = "ttobjectlistbox2";
        this.ttobjectlistbox2.TabIndex = 3;

        this.ttobjectlistbox3 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox3.ReadOnly = true;
        this.ttobjectlistbox3.ListDefName = "UserListDefinition";
        this.ttobjectlistbox3.Name = "ttobjectlistbox3";
        this.ttobjectlistbox3.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Long;
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
        this.GridEpisodeDiagnosis.TabIndex = 5;

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
        this.EpisodeResponsibleUser.Width = 150;

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

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 78;

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
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 7;
        this.tttextbox1.Height = "100px";

        this.cmdImage = new TTVisual.TTButton();
        this.cmdImage.Text = i18n("M16462", "İmaj Görüntüle");
        this.cmdImage.Name = "cmdImage";
        this.cmdImage.TabIndex = 4;

        this.AccessionNo = new TTVisual.TTTextBox();
        this.AccessionNo.BackColor = "#F0F0F0";
        this.AccessionNo.ReadOnly = true;
        this.AccessionNo.Name = "AccessionNo";
        this.AccessionNo.TabIndex = 3;

        this.MaterialsColumns = [this.Material, this.Barcode, this.Amount];
        this.SurgeryDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.TabPageInfo.Controls = [this.tttabpage1, this.tttabpage2, this.TabPageHidden, this.tttabpage3];
        this.tttabpage1.Controls = [this.rtfReport, this.ProcedureObject, this.ttlabel1, this.ttlabel11, this.ttlabel6, this.RepeatReason];
        this.tttabpage2.Controls = [this.Materials, this.ttlabel3];
        this.TabPageHidden.Controls = [this.Description, this.cityOfBirth, this.ttlabel4, this.ttlabel9, this.encboSex, this.ttlabel10, this.ttlabel18, this.ttlabel17, this.TestTechnicianNote, this.ttlabel14, this.ttlabel5, this.OwnerType, this.PatientBirthDate, this.ApprovedBy, this.Deparment, this.ttlabel19, this.tttextbox2, this.Equipment, this.ttlabel12, this.ttlabel8, this.ReportedBy, this.ttlabel2, this.TestDate];
        this.tttabpage3.Controls = [this.SurgeryDirectPurchaseGrids];
        this.tttabcontrol2.Controls = [this.tabAnamnez, this.tabDescription, this.tabAdditionalRequest];
        this.tabAnamnez.Controls = [this.PREDIAGNOSIS];
        this.tabDescription.Controls = [this.CommonDescription];
        this.tabAdditionalRequest.Controls = [this.tttextbox1];
        this.Controls = [this.TabPageInfo, this.tttabpage1, this.rtfReport, this.ProcedureObject, this.ttlabel1, this.ttlabel11, this.ttlabel6, this.RepeatReason, this.tttabpage2, this.Materials, this.Material, this.Barcode, this.Amount, this.ttlabel3, this.TabPageHidden, this.Description, this.cityOfBirth, this.ttlabel4, this.ttlabel9, this.encboSex, this.ttlabel10, this.ttlabel18, this.ttlabel17, this.TestTechnicianNote, this.ttlabel14, this.ttlabel5, this.OwnerType, this.PatientBirthDate, this.ApprovedBy, this.Deparment, this.ttlabel19, this.tttextbox2, this.Equipment, this.ttlabel12, this.ttlabel8, this.ReportedBy, this.ttlabel2, this.TestDate, this.tttabpage3, this.SurgeryDirectPurchaseGrids, this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar, this.ttobjectlistbox1, this.ttobjectlistbox2, this.ttobjectlistbox3, this.ActionDate, this.labelProcessTime, this.ttlabel13, this.ttlabel15, this.PATIENTGROUPENUM, this.ttlabel16, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ReasonForAdmission, this.tttabcontrol2, this.tabAnamnez, this.PREDIAGNOSIS, this.tabDescription, this.CommonDescription, this.tabAdditionalRequest, this.tttextbox1, this.cmdImage,  this.AccessionNo];

    }
    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();
    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        let additionalReport = new DynamicSidebarMenuItem();
        additionalReport.key = 'additionalReport';
        additionalReport.icon = 'far fa-file-alt';
        additionalReport.label = 'Ek Rapor';
        additionalReport.componentInstance = this;
        additionalReport.clickFunction = this.openAdditionalReport;
        this.sideBarMenuService.addMenu('YardimciMenu', additionalReport);

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

        let copyReports = new DynamicSidebarMenuItem();
        copyReports.key = 'copyReports';
        copyReports.icon = 'fas fa-copy';
        copyReports.label = 'Rapor İlişkilendir';
        copyReports.componentInstance = this;
        copyReports.clickFunction = this.copyReports;
        copyReports.parameterFunctionInstance = this;
        copyReports.getParamsFunction = this.getParamsFunctionForRadiology;
        copyReports.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', copyReports);

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

        

    }
    private RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('additionalReport');
        this.sideBarMenuService.removeMenu('colorPrescriptionForRadiology');
        this.sideBarMenuService.removeMenu('pathologyRequest');
        this.sideBarMenuService.removeMenu('copyReports');
        this.sideBarMenuService.removeMenu('radiologyHistory');
        this.sideBarMenuService.removeMenu('pathologyHistory');
        this.sideBarMenuService.removeMenu('testHistory');
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
    openAdditionalReport()
    {
      
       let that = this;
        this.httpService.get<string>("api/RadiologyTestService/CheckAdditionalReport?RadiologyTestID=" + that.radiologyTestCompletedFormViewModel._RadiologyTest.ObjectID).then(result => {

           let additionalReportID: string = result;

            that.showAdditionalReport(additionalReportID);

       }).catch(error => {
           that.messageService.showError(error);
       });
       
    }

    showAdditionalReport(RadiologyTestAdditionalReportID:string): Promise<ModalActionResult> {
        let that= this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "RadiologyTestAdditionalReportForm";
            componentInfo.ModuleName = "RadyolojiModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Radyoloji_Modulu/RadyolojiModule";
            componentInfo.InputParam = new DynamicComponentInputParam(RadiologyTestAdditionalReportID, new ActiveIDsModel(that._RadiologyTest.ObjectID, null, null));
     
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Radyoloji Ek Rapor";
            modalInfo.Width = 800;
            modalInfo.Height = 450;

            let result = that.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private _radiologyTests: Array<RadiologyTestObject> = new Array<RadiologyTestObject>();
    private selectedRadiologyTestList: Array<RadiologyTestObject> = new Array<RadiologyTestObject>();
    private showRadiologyTestsPopUp: boolean = false;
    public copyReports() {
        let that = this;
        let fullApiUrl: string = "/api/RadiologyTestService/GetRadiologyTests?RadiologyTestObjectID=" + this.radiologyTestCompletedFormViewModel._RadiologyTest.ObjectID.toString();
        this.httpService.get<Array<RadiologyTestObject>>(fullApiUrl)
            .then(response => {
                that._radiologyTests = response as Array<RadiologyTestObject>;
                if (that._radiologyTests.length == 0)
                    InfoBox.Alert("Rapor İlişkilendirilecek İşlem Bulunamadı. İlişkilendirilecek İşlemlerin Çekim Yapıldı Durumunda Olması Gerekmektedir.");
                else {
                    this.showRadiologyTestsPopUp = true;
                }

            })
            .catch(error => {
                console.log(error);
            });
    }

    CopyReportToRadiologyTests() {
        let that = this;

        if (this.selectedRadiologyTestList.length == 0) {
            InfoBox.Alert("İşleme Devam Etmek İçin Rapor İlişkilendirilecek İşlemleri Seçiniz.");
        } else {
            let input: CopyReportInput = new CopyReportInput();
            input.RadiologyTestObjectID = this.radiologyTestCompletedFormViewModel._RadiologyTest.ObjectID.toString();
            input.SelectedRadiologyTests = new Array<RadiologyTestObject>();
            input.SelectedRadiologyTests = this.selectedRadiologyTestList;

            let fullApiUrl: string = "/api/RadiologyTestService/CopyReportToRadiologyTests";
            this.httpService.post<any>(fullApiUrl, input)
                .then(response => {
                    this.messageService.showSuccess("İşlem Başarıyla Kaydedildi.");
                    this.showRadiologyTestsPopUp = false;
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }


    public radiologyTestsColumns = [

        {
            "caption": "İşlem Kodu",
            dataField: "ProcedureCode",
            width: 80,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": "İşlem Adı",
            dataField: "ProcedureName",
            width: 250,
            allowSorting: true,
            fixed: true
        }

    ];
}
