//$30B142C8
import { Component, OnInit, NgZone, Renderer2 } from '@angular/core';
import { HCExaminationFormViewModel, HCExaminationInfo } from './HCExaminationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DiagnosisGrid, Common, ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { EvetHayirDegerlendirilmediEnum, LargeMajorityUnanimityEnum, PositiveNegativeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { HealthCommittee } from 'NebulaClient/Model/AtlasClientModel';
import { ITTObject } from 'NebulaClient/StorageManager/InstanceManagement/ITTObject';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeService } from "ObjectClassService/SubEpisodeService";
import { SystemForHealthCommitteeGrid } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BaseHealthCommittee_ExtDoctorGrid } from 'NebulaClient/Model/AtlasClientModel';
import { BaseHealthCommittee_HospitalsUnitsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { IntendedUseOfDisabledReport } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDisabledGroup } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { MemberOfHealthCommiittee } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewTriState } from 'NebulaClient/Utils/Enums/DataGridViewTriState';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { EpisodeActionData } from 'Modules/Tibbi_Surec/Hasta_Dosyasi/MainPatientFolderFormViewModel';
import { ModalStateService, ModalActionResult, ModalInfo } from "Fw/Models/ModalInfo";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { UserTemplateModel } from '../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel';
import { ShowBox, InputForm } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { TTUser } from 'app/NebulaClient/StorageManager/Security/TTUser';
import { HCCommissionList } from './HCNewFormViewModel';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'HCExaminationForm',
    templateUrl: './HCExaminationForm.html',
    providers: [MessageService, SystemApiService]
})
export class HCExaminationForm extends EpisodeActionForm implements OnInit {
    ApproveBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTCheckBoxColumn;
    ApproveMemberOfHealthCommiittee: TTVisual.ITTCheckBoxColumn;
    BodyMassIndex: TTVisual.ITTTextBox;
    BookNumber: TTVisual.ITTTextBox;
    ChronicMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    ClinicalFindings: TTVisual.ITTRichTextBoxControl;
    Definition: TTVisual.ITTRichTextBoxControl;
    DegreeOfBloodRelatives: TTVisual.ITTEnumComboBox;
    DescriptionBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTTextBoxColumn;
    DescriptionMemberOfHealthCommiittee: TTVisual.ITTTextBoxColumn;
    Diagnosis: TTVisual.ITTGrid;
    DisabledChaiEvaluationIntendedUseOfDisabledReport: TTVisual.ITTEnumComboBox;
    DisabledIdentityCardEvalutionIntendedUseOfDisabledReport: TTVisual.ITTEnumComboBox;
    DisabledOfferDecisionSystemForHealthCommitteeGrid: TTVisual.ITTTextBoxColumn;
    DisabledRatio: TTVisual.ITTTextBoxColumn;
    DoctorBaseHealthCommittee_HospitalsUnitsGrid: TTVisual.ITTListBoxColumn;
    DocumentDate: TTVisual.ITTDateTimePicker;
    DocumentNumber: TTVisual.ITTTextBox;
    EducationEvaluationIntendedUseOfDisabledReport: TTVisual.ITTEnumComboBox;
    EmploymentEvaluationIntendedUseOfDisabledReport: TTVisual.ITTEnumComboBox;
    ExternalDoctorInfo: TTVisual.ITTLabel;
    ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTTextBoxColumn;
    ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTTextBoxColumn;
    ExternalDoctors: TTVisual.ITTGrid;
    FunctionRatio: TTVisual.ITTTextBox;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    HAddToHistory: TTVisual.ITTCheckBoxColumn;
    HCDecisionTime: TTVisual.ITTTextBox;
    HCDecisionUnitOfTime: TTVisual.ITTEnumComboBox;
    HCRequestReason: TTVisual.ITTObjectListBox;
    HCStartDate: TTVisual.ITTDateTimePicker;
    HDiagnose: TTVisual.ITTListBoxColumn;
    HDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    HealthCommitteeDecision: TTVisual.ITTRichTextBoxControl;
    HearingMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    HFreeDiagnosis: TTVisual.ITTTextBoxColumn;
    HIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    HospitalsUnits: TTVisual.ITTGrid;
    HResponsibleUser: TTVisual.ITTListBoxColumn;
    IsHeavyDisabled: TTVisual.ITTCheckBox;
    labelBodyMassIndex: TTVisual.ITTLabel;
    labelBookNumber: TTVisual.ITTLabel;
    labelClinicalFindings: TTVisual.ITTLabel;
    labelDefinition: TTVisual.ITTLabel;
    labelDegreeOfBloodRelatives: TTVisual.ITTLabel;
    labelDisabledChaiEvaluationIntendedUseOfDisabledReport: TTVisual.ITTLabel;
    labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport: TTVisual.ITTLabel;
    labelDocumentDate: TTVisual.ITTLabel;
    labelEducationEvaluationIntendedUseOfDisabledReport: TTVisual.ITTLabel;
    labelEmploymentEvaluationIntendedUseOfDisabledReport: TTVisual.ITTLabel;
    labelFunctionRatio: TTVisual.ITTLabel;
    labelHCDecisionTime: TTVisual.ITTLabel;
    labelHCRequestReason: TTVisual.ITTLabel;
    labelLawNo2022EvaluationIntendedUseOfDisabledReport: TTVisual.ITTLabel;
    LabelMasterResource: TTVisual.ITTLabel;
    labelNameSurnameReceiveReport: TTVisual.ITTLabel;
    labelNumberOfDocumnets: TTVisual.ITTLabel;
    labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport: TTVisual.ITTLabel;
    labelOtherExplanationIntendedUseOfDisabledReport: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelQulityOfUnemployableWorks: TTVisual.ITTLabel;
    labelRation: TTVisual.ITTLabel;
    labelReasonForExaminationHCRequestReason: TTVisual.ITTLabel;
    labelReportDate: TTVisual.ITTLabel;
    labelReportNo: TTVisual.ITTLabel;
    labelSendExamination: TTVisual.ITTLabel;
    labelSocialAidEvaluationIntendedUseOfDisabledReport: TTVisual.ITTLabel;
    labelStartDate: TTVisual.ITTLabel;
    labelUnanimity: TTVisual.ITTLabel;
    labelUniqueRefReceiveReport: TTVisual.ITTLabel;
    labelUnworkField: TTVisual.ITTLabel;
    LawNo2022EvaluationIntendedUseOfDisabledReport: TTVisual.ITTEnumComboBox;
    MasterResource: TTVisual.ITTObjectListBox;
    MemberDoctorMemberOfHealthCommiittee: TTVisual.ITTListBoxColumn;
    Members: TTVisual.ITTGrid;
    MentalMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    NameSurnameReceiveReport: TTVisual.ITTTextBox;
    OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport: TTVisual.ITTEnumComboBox;
    OrthopedicMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    OtherExplanationIntendedUseOfDisabledReport: TTVisual.ITTTextBox;
    ProtocolNo: TTVisual.ITTTextBox;
    PsychicAndEmotionalMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    QulityOfUnemployableWorks: TTVisual.ITTTextBox;
    Ration: TTVisual.ITTEnumComboBox;
    RationHeight: TTVisual.ITTTextBox;
    RationWeight: TTVisual.ITTTextBox;
    ReasonForExaminationHCRequestReason: TTVisual.ITTObjectListBox;
    RejectBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTCheckBoxColumn;
    ReportDate: TTVisual.ITTDateTimePicker;
    RejectMemberOfHealthCommiittee: TTVisual.ITTCheckBoxColumn;
    ReportDiagnosis: TTVisual.ITTRichTextBoxControl;
    ReportNo: TTVisual.ITTTextBox;
    ResultedLabel: TTVisual.ITTLabel;
    SendExamination: TTVisual.ITTEnumComboBox;
    SocialAidEvaluationIntendedUseOfDisabledReport: TTVisual.ITTEnumComboBox;
    SpecialityBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTListBoxColumn;
    SpecialityBaseHealthCommittee_HospitalsUnitsGrid: TTVisual.ITTListBoxColumn;
    SpeechAndLanguageMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    SpecialityMemberOfHealthCommiittee: TTVisual.ITTListBoxColumn;
    SystemForDisabledSystemForHealthCommitteeGrid: TTVisual.ITTListBoxColumn;
    SystemForHealthCommitteeGrid: TTVisual.ITTGrid;
    ttcheckboxcolumn4: TTVisual.ITTCheckBoxColumn;
    ttcheckboxcolumn5: TTVisual.ITTCheckBoxColumn;
    ttdatetimepickercolumn3: TTVisual.ITTDateTimePickerColumn;
    ttenumcomboboxcolumn2: TTVisual.ITTEnumComboBoxColumn;
    ttenumcomboboxcolumn3: TTVisual.ITTEnumComboBoxColumn;
    ttgroupEngel: TTVisual.ITTGroupBox;
    ttgroupKullanimAmaci: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlistboxcolumn4: TTVisual.ITTListBoxColumn;
    ttlistboxcolumn5: TTVisual.ITTListBoxColumn;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrolMain: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpageHC: TTVisual.ITTTabPage;
    Unanimity: TTVisual.ITTEnumComboBox;
    UnclassifiedMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    UniqueRefReceiveReport: TTVisual.ITTTextBox;
    UnitBaseHealthCommittee_HospitalsUnitsGrid: TTVisual.ITTListBoxColumn;
    UnworkField: TTVisual.ITTTextBox;
    VFreeDiagnosis: TTVisual.ITTTextBoxColumn;
    VisionMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    SystemForHealthCommitteeColumns = [];
    public systemsDefArray: Array<any> = [];
    public systemsDefCache: any;
    public DiagnosisColumns = [];
    public ExternalDoctorsColumns = [];
    public GridEpisodeDiagnosisColumns = [];
    public HospitalsUnitsColumns = [];
    public MembersColumns = [];
    public SystemForHealthCommitteeGridColumns = [];
    public hCExaminationFormViewModel: HCExaminationFormViewModel = new HCExaminationFormViewModel();
    public selectConsGridResult: object;
    public _saveCommandVisible = true;
    public IsEntryState: boolean = true;
    public selectedUserTemplate;
    public userTemplateName;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    public commissionList : Array <HCCommissionList>= new Array<HCCommissionList>();
    public ShowHcCommission: boolean = false;
    public _selectedCommission = null;
    public get _HealthCommittee(): HealthCommittee {
        return this._TTObject as HealthCommittee;
    }
    private HCExaminationForm_DocumentUrl: string = '/api/HealthCommitteeService/HCExaminationForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService, private objectContextService: ObjectContextService, 
        public systemApiService: SystemApiService, private reportService: AtlasReportService,
        protected ngZone: NgZone, private renderer: Renderer2, private modalStateService: ModalStateService, 
        private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService,
        protected modalService: IModalService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.HCExaminationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async BackCommitteeForReturn(): Promise<void> {

    }

    private async HCRequestReason_SelectedObjectChanged(): Promise<void> {
        let apiUrlForResourceExists: string = '/api/HealthCommitteeService/IsDisabledReport?HCRequestReasonID=' + this._HealthCommittee.HCRequestReason.ObjectID;
        this.hCExaminationFormViewModel.IsDisabled = <boolean>await this.httpService.get(apiUrlForResourceExists);

        if (this.hCExaminationFormViewModel.IsDisabled == true) {
            if (this.hCExaminationFormViewModel._HealthCommittee.IntendedUseOfDisabledReport == null) {
                let intendedUseOfDisabledReport: IntendedUseOfDisabledReport = new IntendedUseOfDisabledReport(this._HealthCommittee.ObjectContext);
                //healthCommittee.IntendedUseOfDisabledReport = intendedUseOfDisabledReport;

                this._HealthCommittee.IntendedUseOfDisabledReport = intendedUseOfDisabledReport;
                if (this.hCExaminationFormViewModel.IntendedUseEvaluationParameter == i18n("M12527", "Değerlendirilmedi")) {
                    intendedUseOfDisabledReport.EducationEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                    intendedUseOfDisabledReport.EmploymentEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                    intendedUseOfDisabledReport.SocialAidEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                    intendedUseOfDisabledReport.OrtesisProsthesEquEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                    intendedUseOfDisabledReport.DisabledChaiEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                    intendedUseOfDisabledReport.DisabledIdentityCardEvalution = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                    intendedUseOfDisabledReport.LawNo2022Evaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                }
                if (this.hCExaminationFormViewModel.IntendedUseEvaluationParameter == i18n("M15570", "Hayır")) {
                    intendedUseOfDisabledReport.EducationEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                    intendedUseOfDisabledReport.EmploymentEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                    intendedUseOfDisabledReport.SocialAidEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                    intendedUseOfDisabledReport.OrtesisProsthesEquEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                    intendedUseOfDisabledReport.DisabledChaiEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                    intendedUseOfDisabledReport.DisabledIdentityCardEvalution = EvetHayirDegerlendirilmediEnum.Hayir;
                    intendedUseOfDisabledReport.LawNo2022Evaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                }
            }
            this.ttgroupEngel.Visible = true;
            this.ttgroupKullanimAmaci.Visible = true;
            this.labelUnworkField.Text = i18n("M12305", "Çalışamayacağı Alan");
            this.UnworkField.Visible = true;
            this.IsHeavyDisabled.Visible = true;
            this.labelSendExamination.Text = i18n("M19260", "Muayeneye Gönderen");
            this.SendExamination.Visible = true;
        }
        else {
            this.ttgroupEngel.Visible = false;
            this.ttgroupKullanimAmaci.Visible = false;
            this.labelUnworkField.Text = "";
            this.UnworkField.Visible = false;
            this.IsHeavyDisabled.Visible = false;
            this.labelSendExamination.Text = "";
            this.SendExamination.Visible = false;
        }
    }
    private async RationHeight_TextChanged(): Promise<void> {
        //            double weight = 0F,height = 1F;
        //            double index = 0F;
        //            double.TryParse(this.RationWeight.Text, out weight);
        //            double.TryParse(this.RationHeight.Text, out height);
        //            if(height == 0) height = 1;
        //            index = (weight / (height*height));
        //            this.OtherMeasurements.Text = index.ToString();

        //let height: number = 1;
        //let weight: number = 0;
        //let index: number = 0;
        //if (this.RationHeight.Text !== "")
        //    height = Convert.ToDouble(this.RationHeight.Text) / 100;
        //if (this.RationWeight.Text !== "")
        //    weight = Convert.ToDouble(this.RationWeight.Text);
        //if (height === 0)
        //    height = 1;
        //index = (weight / (height * height));
        //this.BodyMassIndex.Text = index.toString();
    }
    private async RationWeight_TextChanged(): Promise<void> {
        //          double weight = 0F,height = 1F;
        //          double index = 0F;
        //          double.TryParse(this.RationWeight.Text, out weight);
        //          double.TryParse(this.RationHeight.Text, out height);
        //let height: number = 1;
        //let weight: number = 0;
        //let index: number = 0;
        //if (this.RationHeight.Text !== "")
        //    height = Convert.ToDouble(this.RationHeight.Text) / 100;
        //if (this.RationWeight.Text !== "")
        //    weight = Convert.ToDouble(this.RationWeight.Text);
        //if (height === 0)
        //    height = 1;
        //index = (weight / (height * height));
        //this.BodyMassIndex.Text = index.toString();
    }
    private async SetDocumentNumber(): Promise<void> {
        let nDocNumber: number = 0;
        let sCategory: string = "";

        nDocNumber = 1;  // defter numaralarının kaldırılması istendi bu yüzden hepsi 1 yapıldı
        if (!(<ITTObject>this._HealthCommittee).IsReadOnly) {
            this.BookNumber.Text = nDocNumber.toString();
        }
    }
    private async SetEpisodeRelations(): Promise<void> {
        //let subEpisode = new SubEpisode();
        //subEpisode.ObjectID = new Guid(<any>this._HealthCommittee["SubEpisode"] as string);
        ////let episode = new Episode();
        ////episode.ObjectID = new Guid(<any>this._HealthCommittee["Episode"] as string);

        //subEpisode.Episode = this._HealthCommittee.Episode;
        let subEpisode: SubEpisode = await this.objectContextService.getObject<SubEpisode>(new Guid(this.hCExaminationFormViewModel._HealthCommittee.SubEpisode.toString()), SubEpisode.ObjectDefID, SubEpisode);
        this.DocumentNumber.Text = (await SubEpisodeService.MyDocumentNumber(subEpisode));
        let pDocDate: Date = (await SubEpisodeService.MyDocumentDate(subEpisode));
        if (pDocDate !== null)
            this.DocumentDate.ControlValue = pDocDate.Value;
    }
    private async UnsuitableForMilitServ_CheckedChanged(): Promise<void> {

    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        //this.SetDocumentNumber();
        if (transDef !== null) {

            if (transDef.ToStateDefID.valueOf() == HealthCommittee.HealthCommitteeStates.Cancelled.id)
                await this.setReasonOfCancel(i18n("M16561", "İptal Sebebi :"), i18n("M16527", "İptal - "));
            else{
                this.hCExaminationFormViewModel.MembersGridList.forEach(x => {
                    if ((x.Approve == null && x.Reject == null) || (x.Approve == false && x.Reject == false))
                        throw new Exception(i18n("M23115", "Üyelerin hepsi red ve onay seçimi yapmak zorundadır."));
                    if (x.Reject == true && String.isNullOrEmpty(x.Description))
                        throw new Exception(i18n("M23115", "Red veren üyeler için red sebebini giriniz."));
                });

                this.hCExaminationFormViewModel.ExternalDoctorsGridList.forEach(x => {
                    if ((x.Approve == null && x.Reject == null) || (x.Approve == false && x.Reject == false))
                        throw new Exception(i18n("M23115", "Üyelerin hepsi red ve onay seçimi yapmak zorundadır."));
                    if (x.Reject == true && String.isNullOrEmpty(x.Description))
                        throw new Exception(i18n("M23115", "Red veren üyeler için red sebebini giriniz."));
                });

                if (this.hCExaminationFormViewModel._HealthCommittee.Ration == null)
                    throw new Exception("Lütfen Rapor Akibeti bilgisini seçiniz.");
                else if (this.hCExaminationFormViewModel._HealthCommittee.Unanimity == null)
                    throw new Exception("Lütfen Oy Durumu bilgisini seçiniz.");
                else if (this.hCExaminationFormViewModel._HealthCommittee.HCDecisionTime == null || this.hCExaminationFormViewModel._HealthCommittee.HCDecisionUnitOfTime == null)
                    throw new Exception("Lütfen Geçerlilik Süresi bilgisini seçiniz.");
            }
        }

    }

    async setReasonOfCancel(note: string, type: string) {
        let returnReason: string = await InputForm.GetText(note + i18n("M14794", " İptal Nedeni Giriniz."), "", true, true);
        if (returnReason != null && returnReason != "" && typeof returnReason === "string") {
            let recTime: Date = (await CommonService.RecTime());
            let recTimeString = recTime.getDate() + "."+ (recTime.getMonth() +1)+ "."+ recTime.getFullYear()+ " " +recTime.getHours()+ ":"+recTime.getMinutes();
            let iptalEden=<ResUser>TTUser.CurrentUser.UserObject;
            this.hCExaminationFormViewModel._HealthCommittee.ReasonOfCancel ="İptal Zamanı=" + recTimeString + " \r\n <br/>  İptal Eden="+ iptalEden.Name +" \r\n <br/>  İptal Nedeni="+ type + returnReason;
        }
        else
            throw new Exception(i18n("M16563", "İptal sebebini girmeden işleme devam edemezsiniz."));

    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

        if (this.hCExaminationFormViewModel.IsDisabled == true) {
            this.ttgroupEngel.Visible = true;
            this.ttgroupKullanimAmaci.Visible = true;
            this.labelUnworkField.Text = i18n("M12305", "Çalışamayacağı Alan");
            this.UnworkField.Visible = true;
            this.IsHeavyDisabled.Visible = true;
            this.labelSendExamination.Text = i18n("M19260", "Muayeneye Gönderen");
            this.SendExamination.Visible = true;
            // this.DecisionOffer.Visible = false;
            this.HealthCommitteeDecision.DisplayText = i18n("M23291", "Teşhisler");
            this.FunctionRatio.Visible = true;
        }
        else {
            this.ttgroupEngel.Visible = false;
            this.ttgroupKullanimAmaci.Visible = false;
            this.labelUnworkField.Text = "";
            this.UnworkField.Visible = false;
            this.IsHeavyDisabled.Visible = false;
            this.SendExamination.Visible = false;
            this.labelSendExamination.Text = "";
            //    this.DecisionOffer.Visible = true;
            this.HealthCommitteeDecision.DisplayText = i18n("M17270", "Karar");
            this.FunctionRatio.Visible = false;
        }

    }
    protected async PreScript() {
        super.PreScript();
        this.SetEpisodeRelations();
        //this.SetDocumentNumber();
        //this._HealthCommittee.HCHeight = this._HealthCommittee.ClinicHeight;
        //this._HealthCommittee.HCWeight = this._HealthCommittee.ClinicWeight;
        if (this._HealthCommittee.HCRequestReason !== null && this._HealthCommittee.HCRequestReason.ReasonForExamination !== null) {
            this.HCRequestReason.ListFilterExpression = "REASONFOREXAMINATION='" + this._HealthCommittee.HCRequestReason.ReasonForExamination.ObjectID.toString() + "'";
        }

        if (HealthCommittee.HealthCommitteeStates.Completed == this._HealthCommittee.CurrentStateDefID) {
            this._saveCommandVisible = false;
        }
    }

    public clearGridRejectValue(newData, value, currentRowData) {
        if (value) {
            newData.Approve = true;
            newData.Reject = false;
        }
    }

    public clearGridApproveValue(newData, value, currentRowData) {
        if (value) {
            newData.Approve = false;
            newData.Reject = true;
        }
    }

    public hCExaminationColumns = [
        {
            caption: 'Rapor',
            dataField: '',
            cellTemplate: 'buttonCellTemplate',
            allowEditing: true,
            width: 80
        }, {
            caption: i18n("M17021", "İstem Birimi"),
            dataField: "MasterResource",
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
        {
            caption: i18n("M17578", "Doktor"),
            dataField: "ProcedureDoctor",
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
        {
            caption: i18n("M15133", "Muayene Tarihi"),
            dataField: "ExaminationDate",
            dataType: 'string',
            width: 80,
            allowSorting: true
        },
        {
            caption: i18n("M15133", "Karar Teklifi"),
            dataField: "OfferOfDecision",
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
        {
            caption: i18n("M17578", "Tedavi Bilgileri"),
            dataField: "TreatmentInfo",
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
        {
            caption: i18n("M17578", "Klinik Bulgular"),
            dataField: "ClinicalInfo",
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
        {
            caption: i18n("M17578", "Radyoloji Bulgular"),
            dataField: "RadiologicalInfo",
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
        {
            caption: i18n("M17578", "Laboratuvar Bulgular"),
            dataField: "LabrotoryInfo",
            dataType: 'string',
            width: 150,
            allowSorting: true
        }
    ];

    public hcConsultationColumns = [
        {
            caption: i18n("M17021", "İstem Birimi"),
            dataField: "MasterResource",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M17578", "Doktor"),
            dataField: "ProcedureDoctor",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M15133", "Konsültasyon Tarihi"),
            dataField: "ProcessDate",
            dataType: 'string',
            width: 150,
            allowSorting: true
        }
    ];

    async select(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            let _data: HCExaminationInfo = value.data as HCExaminationInfo;

            let _inputParam = {};
            _inputParam['IsReadOnly'] = true;
            //_inputParam['MinimizeForm'] = true;

            this.openDynamicComponent(_data.ObjectDefName, _data.ObjectId, _data.FormDefId, _inputParam);
        }
    }

    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, new DynamicComponentInputParam(inputparam, this.getActiveIDsModel())).then(x => { });
        } else {
            this.systemApiService.new(objectDefName, null, formDefId, new DynamicComponentInputParam(inputparam, this.getActiveIDsModel())).then(c => { });
        }

    }

    public selectConsGrid(value: any) {
        this.selectConsGridResult = value.data.ConsultationResult;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HealthCommittee();
        this.hCExaminationFormViewModel = new HCExaminationFormViewModel();
        this._ViewModel = this.hCExaminationFormViewModel;
        this.hCExaminationFormViewModel._HealthCommittee = this._TTObject as HealthCommittee;
        this.hCExaminationFormViewModel._HealthCommittee.Members = new Array<MemberOfHealthCommiittee>();
        this.hCExaminationFormViewModel._HealthCommittee.ExternalDoctors = new Array<BaseHealthCommittee_ExtDoctorGrid>();
        this.hCExaminationFormViewModel._HealthCommittee.HospitalsUnits = new Array<BaseHealthCommittee_HospitalsUnitsGrid>();
        this.hCExaminationFormViewModel._HealthCommittee.SystemForHealthCommitteeGrid = new Array<SystemForHealthCommitteeGrid>();
        this.hCExaminationFormViewModel._HealthCommittee.Episode = new Episode();
        this.hCExaminationFormViewModel._HealthCommittee.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.hCExaminationFormViewModel._HealthCommittee.Episode.Patient = new Patient();
        this.hCExaminationFormViewModel._HealthCommittee.Episode.Patient.MedicalInformation = new MedicalInformation();
        this.hCExaminationFormViewModel._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
        this.hCExaminationFormViewModel._HealthCommittee.Diagnosis = new Array<DiagnosisGrid>();
        this.hCExaminationFormViewModel._HealthCommittee.IntendedUseOfDisabledReport = new IntendedUseOfDisabledReport();
        this.hCExaminationFormViewModel._HealthCommittee.HCRequestReason = new HCRequestReason();
        this.hCExaminationFormViewModel._HealthCommittee.HCRequestReason.ReasonForExamination = new ReasonForExaminationDefinition();
        this.hCExaminationFormViewModel._HealthCommittee.MasterResource = new ResSection();
    }

    protected loadViewModel() {
        let that = this;

        that.hCExaminationFormViewModel = this._ViewModel as HCExaminationFormViewModel;
        that._TTObject = this.hCExaminationFormViewModel._HealthCommittee;
        if (this.hCExaminationFormViewModel._HealthCommittee.CurrentStateDefID.valueOf() == HealthCommittee.HealthCommitteeStates.Completed.id)
            that.ReadOnly = true;
        if (this.hCExaminationFormViewModel == null)
            this.hCExaminationFormViewModel = new HCExaminationFormViewModel();
        if (this.hCExaminationFormViewModel._HealthCommittee == null)
            this.hCExaminationFormViewModel._HealthCommittee = new HealthCommittee();

        that.hCExaminationFormViewModel._HealthCommittee.Members = that.hCExaminationFormViewModel.MembersGridList;
        for (let detailItem of that.hCExaminationFormViewModel.MembersGridList) {
            let memberDoctorObjectID = detailItem["MemberDoctor"];
            if (memberDoctorObjectID != null && (typeof memberDoctorObjectID === "string")) {
                let memberDoctor = that.hCExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === memberDoctorObjectID.toString());
                if (memberDoctor) {
                    detailItem.MemberDoctor = memberDoctor;
                }
            }

            let specialityObjectID = detailItem["Speciality"];
            if (specialityObjectID != null && (typeof specialityObjectID === "string")) {
                let speciality = that.hCExaminationFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityObjectID.toString());
                if (speciality) {
                    detailItem.Speciality = speciality;
                }
            }

        }

        that.hCExaminationFormViewModel._HealthCommittee.ExternalDoctors = that.hCExaminationFormViewModel.ExternalDoctorsGridList;
        for (let detailItem of that.hCExaminationFormViewModel.ExternalDoctorsGridList) {
            let specialityObjectID = detailItem["Speciality"];
            if (specialityObjectID != null && (typeof specialityObjectID === "string")) {
                let speciality = that.hCExaminationFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityObjectID.toString());
                if (speciality) {
                    detailItem.Speciality = speciality;
                }
            }

        }
        that.hCExaminationFormViewModel._HealthCommittee.HospitalsUnits = that.hCExaminationFormViewModel.HospitalsUnitsGridList;
        for (let detailItem of that.hCExaminationFormViewModel.HospitalsUnitsGridList) {
            let doctorObjectID = detailItem["Doctor"];
            if (doctorObjectID != null && (typeof doctorObjectID === "string")) {
                let doctor = that.hCExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === doctorObjectID.toString());
                if (doctor) {
                    detailItem.Doctor = doctor;
                }
            }

            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.hCExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    detailItem.Unit = unit;
                }
            }

            let specialityObjectID = detailItem["Speciality"];
            if (specialityObjectID != null && (typeof specialityObjectID === "string")) {
                let speciality = that.hCExaminationFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityObjectID.toString());
                if (speciality) {
                    detailItem.Speciality = speciality;
                }
            }

        }

        that.hCExaminationFormViewModel._HealthCommittee.SystemForHealthCommitteeGrid = that.hCExaminationFormViewModel.SystemForHealthCommitteeGridGridList;
        for (let detailItem of that.hCExaminationFormViewModel.SystemForHealthCommitteeGridGridList) {
            let systemForDisabledObjectID = detailItem["SystemForDisabled"];
            if (systemForDisabledObjectID != null && (typeof systemForDisabledObjectID === 'string')) {
                let systemForDisabled = that.hCExaminationFormViewModel.SystemForDisabledReportDefinitions.find(o => o.ObjectID.toString() === systemForDisabledObjectID.toString());
                if (systemForDisabled) {
                    detailItem.SystemForDisabled = systemForDisabled;
                }
            }
        }
        let episodeObjectID = that.hCExaminationFormViewModel._HealthCommittee["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.hCExaminationFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.hCExaminationFormViewModel._HealthCommittee.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.hCExaminationFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.hCExaminationFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.hCExaminationFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.hCExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.hCExaminationFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                    if (patient != null) {
                        let medicalInformationObjectID = patient["MedicalInformation"];
                        if (medicalInformationObjectID != null && (typeof medicalInformationObjectID === 'string')) {
                            let medicalInformation = that.hCExaminationFormViewModel.MedicalInformations.find(o => o.ObjectID.toString() === medicalInformationObjectID.toString());
                            if (medicalInformation) {
                                patient.MedicalInformation = medicalInformation;
                            }
                            if (medicalInformation != null) {
                                let medicalInfoDisabledGroupObjectID = medicalInformation["MedicalInfoDisabledGroup"];
                                if (medicalInfoDisabledGroupObjectID != null && (typeof medicalInfoDisabledGroupObjectID === 'string')) {
                                    let medicalInfoDisabledGroup = that.hCExaminationFormViewModel.MedicalInfoDisabledGroups.find(o => o.ObjectID.toString() === medicalInfoDisabledGroupObjectID.toString());
                                    if (medicalInfoDisabledGroup) {
                                        medicalInformation.MedicalInfoDisabledGroup = medicalInfoDisabledGroup;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        that.hCExaminationFormViewModel._HealthCommittee.Diagnosis = that.hCExaminationFormViewModel.DiagnosisGridList;
        for (let detailItem of that.hCExaminationFormViewModel.DiagnosisGridList) {
            let diagnoseObjectID = detailItem["Diagnose"];
            if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                let diagnose = that.hCExaminationFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                if (diagnose) {
                    detailItem.Diagnose = diagnose;
                }
            }
            let responsibleUserObjectID = detailItem["ResponsibleUser"];
            if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                let responsibleUser = that.hCExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                if (responsibleUser) {
                    detailItem.ResponsibleUser = responsibleUser;
                }
            }
        }
        let intendedUseOfDisabledReportObjectID = that.hCExaminationFormViewModel._HealthCommittee["IntendedUseOfDisabledReport"];
        if (intendedUseOfDisabledReportObjectID != null && (typeof intendedUseOfDisabledReportObjectID === 'string')) {
            let intendedUseOfDisabledReport = that.hCExaminationFormViewModel.IntendedUseOfDisabledReports.find(o => o.ObjectID.toString() === intendedUseOfDisabledReportObjectID.toString());
            if (intendedUseOfDisabledReport) {
                that.hCExaminationFormViewModel._HealthCommittee.IntendedUseOfDisabledReport = intendedUseOfDisabledReport;
            }
        }
        let hCRequestReasonObjectID = that.hCExaminationFormViewModel._HealthCommittee["HCRequestReason"];
        if (hCRequestReasonObjectID != null && (typeof hCRequestReasonObjectID === 'string')) {
            let hCRequestReason = that.hCExaminationFormViewModel.HCRequestReasons.find(o => o.ObjectID.toString() === hCRequestReasonObjectID.toString());
            if (hCRequestReason) {
                that.hCExaminationFormViewModel._HealthCommittee.HCRequestReason = hCRequestReason;
            }
            if (hCRequestReason != null) {
                let reasonForExaminationObjectID = hCRequestReason["ReasonForExamination"];
                if (reasonForExaminationObjectID != null && (typeof reasonForExaminationObjectID === 'string')) {
                    let reasonForExamination = that.hCExaminationFormViewModel.ReasonForExaminationDefinitions.find(o => o.ObjectID.toString() === reasonForExaminationObjectID.toString());
                    if (reasonForExamination) {
                        hCRequestReason.ReasonForExamination = reasonForExamination;
                    }
                }
            }
        }
        let masterResourceObjectID = that.hCExaminationFormViewModel._HealthCommittee["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.hCExaminationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.hCExaminationFormViewModel._HealthCommittee.MasterResource = masterResource;
            }
        }

        this.AddHelpMenu();

    }



    public GenerateSystemForHealthCommitteeColumns() {
        let that = this;

        this.SystemForHealthCommitteeColumns = [
            {
                caption: 'Sistem',
                dataField: 'SystemForDisabled',
                // lookup: { dataSource: that.systemsDefArray, valueExpr: 'ItemKey', displayExpr: 'Name' },
                width: 300,
                allowEditing: false
            },
            {
                caption: i18n("M13741", "Engelli Karar Önerisi"),
                dataField: 'DisabledOfferDecision',
                width: 700,
                allowEditing: true
            },
            {
                caption: i18n("M13731", "Engel Oranı"),
                dataField: 'DisabledRatio',
                width: 100,
                allowEditing: true
            }
        ];
    }
    public async Systems(): Promise<any> {
        let listDefName: string = "SystemForDisabledReportListDefinition";
        if (!this.systemsDefCache) {
            this.systemsDefCache = await this.httpService.get("/api/MedulaTreatmentReportService/GetListDefValues?listDefName=" + listDefName + '&listFilterExpression=' + '&linkFilterExpression=');
            return this.systemsDefCache;
        }
        else {
            return this.systemsDefCache;
        }
    }
    async ngOnInit() {
        let that = this;
        let promiseArray: Array<Promise<any>> = new Array<any>();
        promiseArray.push(this.Systems());
        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            that.systemsDefArray = sonuc[0];

            that.GenerateSystemForHealthCommitteeColumns();

            this.load(HCExaminationFormViewModel);
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });

    }

    async ngAfterViewInit() {
    }

    async ngOnDestroy() {
        this.RemoveMenuFromHelpMenu();
    }


    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let radiologyHistory = new DynamicSidebarMenuItem();
        radiologyHistory.key = 'radiologyHistory';
        radiologyHistory.icon = 'glyphicon glyphicon-cd';
        radiologyHistory.label = 'Radyoloji Sonuçları';
        radiologyHistory.componentInstance = this.helpMenuService;
        radiologyHistory.clickFunction = this.helpMenuService.openRadiologyHistory;
        radiologyHistory.parameterFunctionInstance = this;
        radiologyHistory.getParamsFunction = this.getClickFunctionParams;
        radiologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', radiologyHistory);

        let pathologyHistory = new DynamicSidebarMenuItem();
        pathologyHistory.key = 'pathologyHistory';
        pathologyHistory.icon = 'fas fa-notes-medical';
        pathologyHistory.label = 'Patoloji Sonuçları';
        pathologyHistory.componentInstance = this.helpMenuService;
        pathologyHistory.clickFunction = this.helpMenuService.openPathologyHistory;
        pathologyHistory.parameterFunctionInstance = this;
        pathologyHistory.getParamsFunction = this.getClickFunctionParams;
        pathologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', pathologyHistory);

        let testHistory = new DynamicSidebarMenuItem();
        testHistory.key = 'testHistory';
        testHistory.icon = 'fa fa-flask';
        testHistory.label = 'Laboratuvar Sonuçları';
        testHistory.componentInstance = this.helpMenuService;
        testHistory.clickFunction = this.helpMenuService.openTestHistory;
        testHistory.parameterFunctionInstance = this;
        testHistory.getParamsFunction = this.getClickFunctionParams;
        testHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', testHistory);

        let openHCMemberDef = new DynamicSidebarMenuItem();
        openHCMemberDef.key = 'openHCMemberDef';
        openHCMemberDef.componentInstance = this;
        openHCMemberDef.label = 'Heyet Tanım Ekranı';
        openHCMemberDef.icon = 'fas fa-users';
        openHCMemberDef.clickFunction = this.showMemberDefSelection;
        this.sideBarMenuService.addMenu('YardimciMenu', openHCMemberDef);

        let openHCReportReport = new DynamicSidebarMenuItem();
        openHCReportReport.key = 'openHCReportReport';
        openHCReportReport.icon = 'fa fa-file-alt';
        openHCReportReport.label = 'Sağlık Kurulu Raporu';
        openHCReportReport.componentInstance = this;
        openHCReportReport.clickFunction = this.printHCReport;
        openHCReportReport.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        openHCReportReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('ReportMainItem', openHCReportReport);        

        if (this.hCExaminationFormViewModel.IsDisabled) {
            /*let disabledReportSecretaryIndex = new DynamicSidebarMenuItem();
            disabledReportSecretaryIndex.key = 'disabledReportSecretaryIndex';
            disabledReportSecretaryIndex.componentInstance = this;
            disabledReportSecretaryIndex.label = 'Sekreter Index';
            disabledReportSecretaryIndex.icon = 'ai ai-recete';
            disabledReportSecretaryIndex.clickFunction = this.openSecretaryIndex;
            this.sideBarMenuService.addMenu('YardimciMenu', disabledReportSecretaryIndex);


            let disabledReportCouncilIndex = new DynamicSidebarMenuItem();
            disabledReportCouncilIndex.key = 'disabledReportCouncilIndex';
            disabledReportCouncilIndex.icon = 'ai ai-tibbi-uygulama-istek';
            disabledReportCouncilIndex.label = 'Kurul Ekranı';
            disabledReportCouncilIndex.componentInstance = this;
            disabledReportCouncilIndex.clickFunction = this.openCouncilIndex;
            disabledReportCouncilIndex.parameterFunctionInstance = this;
            disabledReportCouncilIndex.getParamsFunction = this.getClickFunctionParams;
            disabledReportCouncilIndex.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', disabledReportCouncilIndex);

            let disabledReportCreateApplication = new DynamicSidebarMenuItem();
            disabledReportCreateApplication.key = 'disabledReportCreateApplication';
            disabledReportCreateApplication.componentInstance = this;
            disabledReportCreateApplication.label = 'e-Hasta Kayıt';
            disabledReportCreateApplication.icon = 'ai ai-recete';
            disabledReportCreateApplication.clickFunction = this.openCreateApplication;
            this.sideBarMenuService.addMenu('YardimciMenu', disabledReportCreateApplication);

            let disabledReportCreateCouncil = new DynamicSidebarMenuItem();
            disabledReportCreateCouncil.key = 'disabledReportCreateCouncil';
            disabledReportCreateCouncil.componentInstance = this;
            disabledReportCreateCouncil.label = 'e-Engelli Kurul Tanımlama';
            disabledReportCreateCouncil.icon = 'ai ai-recete';
            disabledReportCreateCouncil.clickFunction = this.openCouncilDescription;
            this.sideBarMenuService.addMenu('YardimciMenu', disabledReportCreateCouncil);

            let disabledReportReSendButton = new DynamicSidebarMenuItem();
            disabledReportReSendButton.key = 'disabledReportReSendButton';
            disabledReportReSendButton.componentInstance = this;
            disabledReportReSendButton.label = 'Entegrasyon Verisini Tekrar Gönder';
            disabledReportReSendButton.icon = 'ai ai-recete';
            disabledReportReSendButton.clickFunction = this.reSendEntegrationForDisabledReport;
            this.sideBarMenuService.addMenu('YardimciMenu', disabledReportReSendButton);*/
        }

    }

    private RemoveMenuFromHelpMenu() {
        this.sideBarMenuService.removeMenu('radiologyHistory');
        this.sideBarMenuService.removeMenu('pathologyHistory');
        this.sideBarMenuService.removeMenu('testHistory');
        this.sideBarMenuService.removeMenu('openHCMemberDef');
        this.sideBarMenuService.removeMenu('openHCReportReport');        

        if (this.hCExaminationFormViewModel.IsDisabled) {

            /*this.sideBarMenuService.removeMenu('disabledReportCouncilIndex');
            this.sideBarMenuService.removeMenu('disabledReportSecretaryIndex');
            this.sideBarMenuService.removeMenu('disabledReportCreateApplication');
            this.sideBarMenuService.removeMenu('disabledReportCreateCouncil');
            this.sideBarMenuService.removeMenu('disabledReportReSendButton');*/

        }
    }

    printHCReport() {
        this.openHCReport(this._HealthCommittee.ObjectID);
    }

    openHCReport(ObjectID:any): Promise<ModalActionResult>
    {
        let disablePrintButton: boolean = false;
        if (this._HealthCommittee.CurrentStateDefID != HealthCommittee.HealthCommitteeStates.Completed)
            disablePrintButton = true;

        let reportData: DynamicReportParameters = {

            Code: 'HCREPORT',
            ReportParams: { ObjectID: ObjectID.toString() },
            ViewerMode: true,
            DisablePrintButtons: disablePrintButton
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(this._HealthCommittee.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "SAĞLIK KURULU RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private showMemberDefSelection()
    {
        let that = this;
        this.httpService.get<Array<HCCommissionList>>("api/HealthCommitteeService/GetHcCommissionList/")
            .then(result => {
                this.commissionList = result as Array<HCCommissionList>;

                if (this.commissionList != null && this.commissionList.length > 0) {
                    this.ShowHcCommission = true;
                }

            })
            .catch(error => {
                that.messageService.showError(error);
            });

    }

    private openHCMemberDefinitionForm(isNew:boolean): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MemberOfHealthCommitteeDefinitionForm";
            componentInfo.ModuleName = "SaglikKuruluModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Saglik_Kurulu_Modulu/SaglikKuruluModule";
            componentInfo.InputParam = new DynamicComponentInputParam("", null);
            if(isNew)
                componentInfo.objectID = null;
            else
                componentInfo.objectID = this._selectedCommission;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title ="Heyet Tanım Ekranı";
           
            modalInfo.Width = 960;
            modalInfo.Height = 700;
            // modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openSecretaryIndex() {
        let fullApiUrl: string = 'api/EDisabledReportService/GetSecretaryIndexLink?healthCommitteeOjbectId=' + this.hCExaminationFormViewModel._HealthCommittee.ObjectID.toString();
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openCouncilDescription() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenEDisabledCouncilIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public reSendEntegrationForDisabledReport() {
        let fullApiUrl: string = 'api/EDisabledReportService/ReSendEReportApplication?healthCommitteeOjbectId=' + this.hCExaminationFormViewModel._HealthCommittee.ObjectID.toString();
        this.httpService.get(fullApiUrl).then((res: string) => {
            TTVisual.InfoBox.Alert(res);
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openCreateApplication() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenEDisabledReportCreateApplication';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openCouncilIndex() {
        let fullApiUrl: string = 'api/EDisabledReportService/GetCouncilLink?healthCommitteeOjbectId=' + this.hCExaminationFormViewModel._HealthCommittee.ObjectID.toString();
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public onBodyMassIndexChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.BodyMassIndex != event) {
                this._HealthCommittee.BodyMassIndex = event;
            }
        }
    }

    public onBookNumberChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.BookNumber != event) {
                this._HealthCommittee.BookNumber = event;
            }
        }
    }

    public onChronicMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null &&
                this._HealthCommittee.Episode.Patient != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Chronic != event) {
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Chronic = event;
            }
        }
    }

    public onClinicalFindingsChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.ClinicalFindings != event) {
                this._HealthCommittee.ClinicalFindings = event;
            }
        }
    }

    public onDefinitionChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.Definition != event) {
                this._HealthCommittee.Definition = event;
            }
        }
    }

    public onDegreeOfBloodRelativesChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.DegreeOfBloodRelatives != event) {
                this._HealthCommittee.DegreeOfBloodRelatives = event;
            }
        }
    }

    public onDisabledChaiEvaluationIntendedUseOfDisabledReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.IntendedUseOfDisabledReport != null && this._HealthCommittee.IntendedUseOfDisabledReport.DisabledChaiEvaluation != event) {
                this._HealthCommittee.IntendedUseOfDisabledReport.DisabledChaiEvaluation = event;
            }
        }
    }

    public onDisabledIdentityCardEvalutionIntendedUseOfDisabledReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.IntendedUseOfDisabledReport != null && this._HealthCommittee.IntendedUseOfDisabledReport.DisabledIdentityCardEvalution != event) {
                this._HealthCommittee.IntendedUseOfDisabledReport.DisabledIdentityCardEvalution = event;
            }
        }
    }

    public onEducationEvaluationIntendedUseOfDisabledReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.IntendedUseOfDisabledReport != null && this._HealthCommittee.IntendedUseOfDisabledReport.EducationEvaluation != event) {
                this._HealthCommittee.IntendedUseOfDisabledReport.EducationEvaluation = event;
            }
        }
    }

    public onEmploymentEvaluationIntendedUseOfDisabledReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.IntendedUseOfDisabledReport != null && this._HealthCommittee.IntendedUseOfDisabledReport.EmploymentEvaluation != event) {
                this._HealthCommittee.IntendedUseOfDisabledReport.EmploymentEvaluation = event;
            }
        }
    }

    public onFunctionRatioChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.FunctionRatio != event) {
                this._HealthCommittee.FunctionRatio = event;
            }
        }
    }

    public onHCDecisionTimeChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.HCDecisionTime != event) {
                this._HealthCommittee.HCDecisionTime = event;
            }
        }
    }

    public onHCDecisionUnitOfTimeChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.HCDecisionUnitOfTime != event) {
                this._HealthCommittee.HCDecisionUnitOfTime = event;
            }
        }
    }

    public onHCRequestReasonChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.HCRequestReason != event) {
                this._HealthCommittee.HCRequestReason = event;
            }
        }
        this.HCRequestReason_SelectedObjectChanged();
    }

    public onHCStartDateChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null && this._HealthCommittee.Episode.OpeningDate != event) {
                this._HealthCommittee.Episode.OpeningDate = event;
            }
        }
    }

    public onHealthCommitteeDecisionChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.HealthCommitteeDecision != event) {
                this._HealthCommittee.HealthCommitteeDecision = event;
            }
        }
    }

    public onHearingMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null &&
                this._HealthCommittee.Episode.Patient != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Hearing != event) {
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Hearing = event;
            }
        }
    }

    public onIsHeavyDisabledChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.IsHeavyDisabled != event) {
                this._HealthCommittee.IsHeavyDisabled = event;
            }
        }
    }

    public onLawNo2022EvaluationIntendedUseOfDisabledReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.IntendedUseOfDisabledReport != null && this._HealthCommittee.IntendedUseOfDisabledReport.LawNo2022Evaluation != event) {
                this._HealthCommittee.IntendedUseOfDisabledReport.LawNo2022Evaluation = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.MasterResource != event) {
                this._HealthCommittee.MasterResource = event;
            }
        }
    }

    public onMentalMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null &&
                this._HealthCommittee.Episode.Patient != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Mental != event) {
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Mental = event;
            }
        }
    }

    public onNameSurnameReceiveReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.NameSurnameReceiveReport != event) {
                this._HealthCommittee.NameSurnameReceiveReport = event;
            }
        }
    }

    public onOrtesisProsthesEquEvaluationIntendedUseOfDisabledReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.IntendedUseOfDisabledReport != null && this._HealthCommittee.IntendedUseOfDisabledReport.OrtesisProsthesEquEvaluation != event) {
                this._HealthCommittee.IntendedUseOfDisabledReport.OrtesisProsthesEquEvaluation = event;
            }
        }
    }

    public onOrthopedicMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null &&
                this._HealthCommittee.Episode.Patient != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Orthopedic != event) {
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Orthopedic = event;
            }
        }
    }

    public onOtherExplanationIntendedUseOfDisabledReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.IntendedUseOfDisabledReport != null && this._HealthCommittee.IntendedUseOfDisabledReport.OtherExplanation != event) {
                this._HealthCommittee.IntendedUseOfDisabledReport.OtherExplanation = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.ProtocolNo != event) {
                this._HealthCommittee.ProtocolNo = event;
            }
        }
    }

    public onPsychicAndEmotionalMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null &&
                this._HealthCommittee.Episode.Patient != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional != event) {
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional = event;
            }
        }
    }

    public onQulityOfUnemployableWorksChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.QulityOfUnemployableWorks != event) {
                this._HealthCommittee.QulityOfUnemployableWorks = event;
            }
        }
    }

    public onRationChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.Ration != event) {
                this._HealthCommittee.Ration = event;
            }

            this.arrangeHC_ApproveState(); //oybirliği seçili ise hepsini onaylı yapsın
        }
    }

    public onRationHeightChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.HCHeight != event) {
                this._HealthCommittee.HCHeight = event;
            }
        }
        this.RationHeight_TextChanged();
    }

    public onRationWeightChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.HCWeight != event) {
                this._HealthCommittee.HCWeight = event;
            }
        }
        this.RationWeight_TextChanged();
    }

    public onReasonForExaminationHCRequestReasonChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.HCRequestReason != null && this._HealthCommittee.HCRequestReason.ReasonForExamination != event) {
                this._HealthCommittee.HCRequestReason.ReasonForExamination = event;
            }
        }
    }

    public onReportDateChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.ReportDate != event) {
                this._HealthCommittee.ReportDate = event;
            }
        }
    }

    public onReportDiagnosisChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.ReportDiagnosis != event) {
                this._HealthCommittee.ReportDiagnosis = event;
            }
        }
    }

    public onReportNoChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.ReportNo != event) {
                this._HealthCommittee.ReportNo = event;
            }
        }
    }

    public onSendExaminationChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.SendExamination != event) {
                this._HealthCommittee.SendExamination = event;
            }
        }
    }

    public onSocialAidEvaluationIntendedUseOfDisabledReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.IntendedUseOfDisabledReport != null && this._HealthCommittee.IntendedUseOfDisabledReport.SocialAidEvaluation != event) {
                this._HealthCommittee.IntendedUseOfDisabledReport.SocialAidEvaluation = event;
            }
        }
    }

    public onSpeechAndLanguageMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null &&
                this._HealthCommittee.Episode.Patient != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage != event) {
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage = event;
            }
        }
    }

    public onUnanimityChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.Unanimity != event) {
                this._HealthCommittee.Unanimity = event;
            }
        }
    }

    public arrangeHC_ApproveState() {
        if (this._HealthCommittee.Unanimity == LargeMajorityUnanimityEnum.Unanimity) {
            if (this._HealthCommittee.Ration == PositiveNegativeEnum.Positive) {
                this._HealthCommittee.ExternalDoctors.forEach(x => {
                    x.Approve = true;
                    x.Reject = false;
                });

                this._HealthCommittee.Members.forEach(x => {
                    x.Approve = true;
                    x.Reject = false;
                });
            }
            else {
                this._HealthCommittee.ExternalDoctors.forEach(x => {
                    x.Approve = false;
                    x.Reject = true;
                });

                this._HealthCommittee.Members.forEach(x => {
                    x.Approve = false;
                    x.Reject = true;
                });
            }
        }


    }

    public onUnclassifiedMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null &&
                this._HealthCommittee.Episode.Patient != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Unclassified != event) {
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Unclassified = event;
            }
        }
    }

    public onUniqueRefReceiveReportChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.UniqueRefReceiveReport != event) {
                this._HealthCommittee.UniqueRefReceiveReport = event;
            }
        }
    }

    public onUnworkFieldChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.UnworkField != event) {
                this._HealthCommittee.UnworkField = event;
            }
        }
    }

    public onVisionMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.Episode != null &&
                this._HealthCommittee.Episode.Patient != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation != null &&
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Vision != event) {
                this._HealthCommittee.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Vision = event;
            }
        }
    }

    public printDynamicHCReport(e: any) {
        const objectIdParam = new GuidParam(e.data.ObjectId.id);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReportModal('HC_LowerExtremiteReport', reportParameters);
    }

    protected redirectProperties(): void {
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.ReportDate, "Value", this.__ttObject, "ReportDate");
        redirectProperty(this.ReportNo, "Text", this.__ttObject, "ReportNo");
        redirectProperty(this.BookNumber, "Text", this.__ttObject, "BookNumber");
        redirectProperty(this.HCDecisionTime, "Text", this.__ttObject, "HCDecisionTime");
        redirectProperty(this.HCDecisionUnitOfTime, "Value", this.__ttObject, "HCDecisionUnitOfTime");
        redirectProperty(this.BodyMassIndex, "Text", this.__ttObject, "BodyMassIndex");
        redirectProperty(this.Ration, "Value", this.__ttObject, "Ration");
        redirectProperty(this.Unanimity, "Value", this.__ttObject, "Unanimity");
        redirectProperty(this.Definition, "Text", this.__ttObject, "Definition");
        redirectProperty(this.FunctionRatio, "Text", this.__ttObject, "FunctionRatio");
        redirectProperty(this.ReportDiagnosis, "Rtf", this.__ttObject, "ReportDiagnosis");
        redirectProperty(this.OrthopedicMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Orthopedic");
        redirectProperty(this.VisionMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Vision");
        redirectProperty(this.HearingMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Hearing");
        redirectProperty(this.SpeechAndLanguageMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage");
        redirectProperty(this.MentalMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Mental");
        redirectProperty(this.ChronicMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Chronic");
        redirectProperty(this.UnclassifiedMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Unclassified");
        redirectProperty(this.PsychicAndEmotionalMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional");
        redirectProperty(this.EducationEvaluationIntendedUseOfDisabledReport, "Value", this.__ttObject, "IntendedUseOfDisabledReport.EducationEvaluation");
        redirectProperty(this.EmploymentEvaluationIntendedUseOfDisabledReport, "Value", this.__ttObject, "IntendedUseOfDisabledReport.EmploymentEvaluation");
        redirectProperty(this.SocialAidEvaluationIntendedUseOfDisabledReport, "Value", this.__ttObject, "IntendedUseOfDisabledReport.SocialAidEvaluation");
        redirectProperty(this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport, "Value", this.__ttObject, "IntendedUseOfDisabledReport.OrtesisProsthesEquEvaluation");
        redirectProperty(this.DisabledChaiEvaluationIntendedUseOfDisabledReport, "Value", this.__ttObject, "IntendedUseOfDisabledReport.DisabledChaiEvaluation");
        redirectProperty(this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport, "Value", this.__ttObject, "IntendedUseOfDisabledReport.DisabledIdentityCardEvalution");
        redirectProperty(this.LawNo2022EvaluationIntendedUseOfDisabledReport, "Value", this.__ttObject, "IntendedUseOfDisabledReport.LawNo2022Evaluation");
        redirectProperty(this.OtherExplanationIntendedUseOfDisabledReport, "Text", this.__ttObject, "IntendedUseOfDisabledReport.OtherExplanation");
        redirectProperty(this.ClinicalFindings, "Text", this.__ttObject, "ClinicalFindings");
        redirectProperty(this.UnworkField, "Text", this.__ttObject, "UnworkField");
        redirectProperty(this.QulityOfUnemployableWorks, "Text", this.__ttObject, "QulityOfUnemployableWorks");
        redirectProperty(this.HealthCommitteeDecision, "Rtf", this.__ttObject, "HealthCommitteeDecision");
        redirectProperty(this.IsHeavyDisabled, "Value", this.__ttObject, "IsHeavyDisabled");
        redirectProperty(this.SendExamination, "Value", this.__ttObject, "SendExamination");
        redirectProperty(this.UniqueRefReceiveReport, "Text", this.__ttObject, "UniqueRefReceiveReport");
        redirectProperty(this.NameSurnameReceiveReport, "Text", this.__ttObject, "NameSurnameReceiveReport");
        redirectProperty(this.DegreeOfBloodRelatives, "Value", this.__ttObject, "DegreeOfBloodRelatives");
        redirectProperty(this.HCStartDate, "Value", this.__ttObject, "Episode.OpeningDate");
        redirectProperty(this.RationWeight, "Text", this.__ttObject, "HCWeight");
        redirectProperty(this.RationHeight, "Text", this.__ttObject, "HCHeight");
    }

    public initFormControls(): void {
        this.tttabcontrolMain = new TTVisual.TTTabControl();
        this.tttabcontrolMain.Name = "tttabcontrolMain";
        this.tttabcontrolMain.TabIndex = 0;

        this.tttabpageHC = new TTVisual.TTTabPage();
        this.tttabpageHC.DisplayIndex = 0;
        this.tttabpageHC.BackColor = "#FFFFFF";
        this.tttabpageHC.TabIndex = 0;
        this.tttabpageHC.Text = i18n("M21178", "Sağlık Kurulu Bilgileri");
        this.tttabpageHC.Name = "tttabpageHC";

        this.Members = new TTVisual.TTGrid();
        this.Members.Name = "Members";
        this.Members.TabIndex = 17562;

        this.MemberDoctorMemberOfHealthCommiittee = new TTVisual.TTListBoxColumn();
        this.MemberDoctorMemberOfHealthCommiittee.ListDefName = "SpecialistDoctorListDefinition";
        this.MemberDoctorMemberOfHealthCommiittee.DataMember = "MemberDoctor";
        this.MemberDoctorMemberOfHealthCommiittee.DisplayIndex = 0;
        this.MemberDoctorMemberOfHealthCommiittee.HeaderText = "Doktor";
        this.MemberDoctorMemberOfHealthCommiittee.Name = "MemberDoctorMemberOfHealthCommiittee";
        this.MemberDoctorMemberOfHealthCommiittee.ReadOnly = true;
        this.MemberDoctorMemberOfHealthCommiittee.Width = 300;

        this.SpecialityMemberOfHealthCommiittee = new TTVisual.TTListBoxColumn();
        this.SpecialityMemberOfHealthCommiittee.ListDefName = "SpecialityListDefinition";
        this.SpecialityMemberOfHealthCommiittee.DataMember = "Speciality";
        this.SpecialityMemberOfHealthCommiittee.DisplayIndex = 1;
        this.SpecialityMemberOfHealthCommiittee.HeaderText = "Branş";
        this.SpecialityMemberOfHealthCommiittee.Name = "SpecialityMemberOfHealthCommiittee";
        this.SpecialityMemberOfHealthCommiittee.ReadOnly = true;
        this.SpecialityMemberOfHealthCommiittee.Width = 300;

        this.ApproveMemberOfHealthCommiittee = new TTVisual.TTCheckBoxColumn();
        this.ApproveMemberOfHealthCommiittee.DataMember = "Approve";
        this.ApproveMemberOfHealthCommiittee.DisplayIndex = 2;
        this.ApproveMemberOfHealthCommiittee.HeaderText = "Onay";
        this.ApproveMemberOfHealthCommiittee.Name = "ApproveMemberOfHealthCommiittee";
        this.ApproveMemberOfHealthCommiittee.Width = 80;

        this.RejectMemberOfHealthCommiittee = new TTVisual.TTCheckBoxColumn();
        this.RejectMemberOfHealthCommiittee.DataMember = "Reject";
        this.RejectMemberOfHealthCommiittee.DisplayIndex = 3;
        this.RejectMemberOfHealthCommiittee.HeaderText = "Red";
        this.RejectMemberOfHealthCommiittee.Name = "RejectMemberOfHealthCommiittee";
        this.RejectMemberOfHealthCommiittee.Width = 80;

        this.DescriptionMemberOfHealthCommiittee = new TTVisual.TTTextBoxColumn();
        this.DescriptionMemberOfHealthCommiittee.DataMember = "Description";
        this.DescriptionMemberOfHealthCommiittee.DisplayIndex = 4;
        this.DescriptionMemberOfHealthCommiittee.HeaderText = "Red Sebebi";
        this.DescriptionMemberOfHealthCommiittee.Name = "DescriptionMemberOfHealthCommiittee";
        this.DescriptionMemberOfHealthCommiittee.Width = 80;

        this.ExternalDoctorInfo = new TTVisual.TTLabel();
        this.ExternalDoctorInfo.Text = "Dış XXXXXX Doktor Bilgileri";
        this.ExternalDoctorInfo.ForeColor = "#000000";
        this.ExternalDoctorInfo.Name = "ExternalDoctorInfo";
        this.ExternalDoctorInfo.TabIndex = 20;

        this.ExternalDoctors = new TTVisual.TTGrid();
        this.ExternalDoctors.Name = "ExternalDoctors";
        this.ExternalDoctors.TabIndex = 17490;

        this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTTextBoxColumn();
        this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.DataMember = "ExternalDoctorName";
        this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 0;
        this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Doktor Adı";
        this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.Name = "ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid";
        this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.ReadOnly = true;
        this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.Width = 200;

        this.SpecialityBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTListBoxColumn();
        this.SpecialityBaseHealthCommittee_ExtDoctorGrid.ListDefName = "SpecialityListDefinition";
        this.SpecialityBaseHealthCommittee_ExtDoctorGrid.DataMember = "Speciality";
        this.SpecialityBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 1;
        this.SpecialityBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Branş";
        this.SpecialityBaseHealthCommittee_ExtDoctorGrid.Name = "SpecialityBaseHealthCommittee_ExtDoctorGrid";
        this.SpecialityBaseHealthCommittee_ExtDoctorGrid.ReadOnly = true;
        this.SpecialityBaseHealthCommittee_ExtDoctorGrid.Width = 200;

        this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTTextBoxColumn();
        this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.DataMember = "ExternalDoctorRegNumber";
        this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 2;
        this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Tescil Numarası";
        this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.Name = "ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid";
        this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.ReadOnly = true;
        this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.Width = 200;

        this.ApproveBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTCheckBoxColumn();
        this.ApproveBaseHealthCommittee_ExtDoctorGrid.DataMember = "Approve";
        this.ApproveBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 3;
        this.ApproveBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Onay";
        this.ApproveBaseHealthCommittee_ExtDoctorGrid.Name = "ApproveBaseHealthCommittee_ExtDoctorGrid";
        this.ApproveBaseHealthCommittee_ExtDoctorGrid.Width = 75;

        this.RejectBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTCheckBoxColumn();
        this.RejectBaseHealthCommittee_ExtDoctorGrid.DataMember = "Reject";
        this.RejectBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 4;
        this.RejectBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Red";
        this.RejectBaseHealthCommittee_ExtDoctorGrid.Name = "RejectBaseHealthCommittee_ExtDoctorGrid";
        this.RejectBaseHealthCommittee_ExtDoctorGrid.Width = 75;

        this.DescriptionBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTTextBoxColumn();
        this.DescriptionBaseHealthCommittee_ExtDoctorGrid.DataMember = "Description";
        this.DescriptionBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 5;
        this.DescriptionBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Red Sebebi";
        this.DescriptionBaseHealthCommittee_ExtDoctorGrid.Name = "DescriptionBaseHealthCommittee_ExtDoctorGrid";
        this.DescriptionBaseHealthCommittee_ExtDoctorGrid.Width = 250;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Muayene Edileceği Birimler";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17483;

        this.labelNameSurnameReceiveReport = new TTVisual.TTLabel();
        this.labelNameSurnameReceiveReport.Text = i18n("M20899", "Raporu Teslim Alanın Adı Soyadı");
        this.labelNameSurnameReceiveReport.Name = "labelNameSurnameReceiveReport";
        this.labelNameSurnameReceiveReport.TabIndex = 17561;

        this.HospitalsUnits = new TTVisual.TTGrid();
        this.HospitalsUnits.Name = "HospitalsUnits";
        this.HospitalsUnits.TabIndex = 17482;

        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid = new TTVisual.TTListBoxColumn();
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.ListDefName = "SpecialistDoctorListDefinition";
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.DataMember = "Doctor";
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.DisplayIndex = 0;
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.HeaderText = "Doktor";
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.Name = "DoctorBaseHealthCommittee_HospitalsUnitsGrid";
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.ReadOnly = true;
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.Width = 200;

        this.UnitBaseHealthCommittee_HospitalsUnitsGrid = new TTVisual.TTListBoxColumn();
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.ListDefName = "PoliclinicAndEmergencyListDefinition";
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.DataMember = "Unit";
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.DisplayIndex = 1;
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.HeaderText = "Birim";
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.Name = "UnitBaseHealthCommittee_HospitalsUnitsGrid";
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.ReadOnly = true;
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.Width = 200;

        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid = new TTVisual.TTListBoxColumn();
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.ListDefName = "SpecialityListDefinition";
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.DataMember = "Speciality";
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.DisplayIndex = 2;
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.HeaderText = "Branş";
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.Name = "SpecialityBaseHealthCommittee_HospitalsUnitsGrid";
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.ReadOnly = true;
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.Width = 200;

        this.NameSurnameReceiveReport = new TTVisual.TTTextBox();
        this.NameSurnameReceiveReport.Name = "NameSurnameReceiveReport";
        this.NameSurnameReceiveReport.TabIndex = 17560;

        this.labelUnworkField = new TTVisual.TTLabel();
        this.labelUnworkField.Text = i18n("M12305", "Çalışamayacağı Alan");
        this.labelUnworkField.Name = "labelUnworkField";

        this.labelUniqueRefReceiveReport = new TTVisual.TTLabel();
        this.labelUniqueRefReceiveReport.Text = i18n("M20900", "Raporu Teslim Alanın TC Kimlik No");
        this.labelUniqueRefReceiveReport.Name = "labelUniqueRefReceiveReport";
        this.labelUniqueRefReceiveReport.TabIndex = 17559;

        this.UniqueRefReceiveReport = new TTVisual.TTTextBox();
        this.UniqueRefReceiveReport.Name = "UniqueRefReceiveReport";
        this.UniqueRefReceiveReport.TabIndex = 17558;

        this.labelDegreeOfBloodRelatives = new TTVisual.TTLabel();
        this.labelDegreeOfBloodRelatives.Text = i18n("M24253", "Yakınlık Derecesi");
        this.labelDegreeOfBloodRelatives.Name = "labelDegreeOfBloodRelatives";
        this.labelDegreeOfBloodRelatives.TabIndex = 17557;

        this.DegreeOfBloodRelatives = new TTVisual.TTEnumComboBox();
        this.DegreeOfBloodRelatives.DataTypeName = "DegreeOfBloodRelativesEnum";
        this.DegreeOfBloodRelatives.Name = "DegreeOfBloodRelatives";
        this.DegreeOfBloodRelatives.TabIndex = 17556;

        this.labelClinicalFindings = new TTVisual.TTLabel();
        this.labelClinicalFindings.Text = i18n("M17626", "Klinik Bulgular");
        this.labelClinicalFindings.Name = "labelClinicalFindings";
        this.labelClinicalFindings.TabIndex = 17555;

        this.ClinicalFindings = new TTVisual.TTRichTextBoxControl();
        this.ClinicalFindings.DisplayText = "Klinik Bulgular";
        this.ClinicalFindings.Name = "ClinicalFindings";
        this.ClinicalFindings.TabIndex = 17554;
        this.ClinicalFindings.TemplateGroupName = "HCCLINICALFINDINGS";

        this.labelBodyMassIndex = new TTVisual.TTLabel();
        this.labelBodyMassIndex.Text = i18n("M24196", "Vücut Kitle İndeksi");
        this.labelBodyMassIndex.Name = "labelBodyMassIndex";
        this.labelBodyMassIndex.TabIndex = 17553;

        this.BodyMassIndex = new TTVisual.TTTextBox();
        this.BodyMassIndex.BackColor = "#F0F0F0";
        this.BodyMassIndex.ReadOnly = true;
        this.BodyMassIndex.Name = "BodyMassIndex";
        this.BodyMassIndex.TabIndex = 17552;

        this.SystemForHealthCommitteeGrid = new TTVisual.TTGrid();
        this.SystemForHealthCommitteeGrid.AllowUserToDeleteRows = false;
        this.SystemForHealthCommitteeGrid.Name = "SystemForHealthCommitteeGrid";
        this.SystemForHealthCommitteeGrid.TabIndex = 17551;

        this.SystemForDisabledSystemForHealthCommitteeGrid = new TTVisual.TTListBoxColumn();
        this.SystemForDisabledSystemForHealthCommitteeGrid.ListDefName = "SystemForDisabledReportListDefinition";
        this.SystemForDisabledSystemForHealthCommitteeGrid.DataMember = "SystemForDisabled";
        this.SystemForDisabledSystemForHealthCommitteeGrid.DisplayIndex = 0;
        this.SystemForDisabledSystemForHealthCommitteeGrid.HeaderText = "Sistem";
        this.SystemForDisabledSystemForHealthCommitteeGrid.Name = "SystemForDisabledSystemForHealthCommitteeGrid";
        this.SystemForDisabledSystemForHealthCommitteeGrid.Width = 300;

        this.DisabledOfferDecisionSystemForHealthCommitteeGrid = new TTVisual.TTTextBoxColumn();
        this.DisabledOfferDecisionSystemForHealthCommitteeGrid.DataMember = "DisabledOfferDecision";
        this.DisabledOfferDecisionSystemForHealthCommitteeGrid.WrapMode = DataGridViewTriState.True;
        this.DisabledOfferDecisionSystemForHealthCommitteeGrid.DisplayIndex = 1;
        this.DisabledOfferDecisionSystemForHealthCommitteeGrid.HeaderText = i18n("M13741", "Engelli Karar Önerisi");
        this.DisabledOfferDecisionSystemForHealthCommitteeGrid.Name = "DisabledOfferDecisionSystemForHealthCommitteeGrid";
        this.DisabledOfferDecisionSystemForHealthCommitteeGrid.Width = 300;

        this.DisabledRatio = new TTVisual.TTTextBoxColumn();
        this.DisabledRatio.DisplayIndex = 2;
        this.DisabledRatio.HeaderText = "DisabledRatio";
        this.DisabledRatio.Name = "DisabledRatio";
        this.DisabledRatio.Width = 100;

        this.HealthCommitteeDecision = new TTVisual.TTRichTextBoxControl();
        this.HealthCommitteeDecision.DisplayText = i18n("M17270", "Karar");
        this.HealthCommitteeDecision.TemplateGroupName = "HCDECISION";
        this.HealthCommitteeDecision.Name = "HealthCommitteeDecision";
        this.HealthCommitteeDecision.TabIndex = 17550;



        this.SendExamination = new TTVisual.TTEnumComboBox();
        this.SendExamination.DataTypeName = "SendExaminationEnum";
        this.SendExamination.Name = "SendExamination";
        this.SendExamination.TabIndex = 17548;
        this.SendExamination.Visible = false;

        this.IsHeavyDisabled = new TTVisual.TTCheckBox();
        this.IsHeavyDisabled.Value = false;
        this.IsHeavyDisabled.Title = i18n("M10561", "Ağır Engelli");
        this.IsHeavyDisabled.Name = "IsHeavyDisabled";
        this.IsHeavyDisabled.TabIndex = 17547;
        this.IsHeavyDisabled.Visible = false;

        this.labelQulityOfUnemployableWorks = new TTVisual.TTLabel();
        this.labelQulityOfUnemployableWorks.Text = "Çalıştırılamayacağı İşlerin Niteliği";
        this.labelQulityOfUnemployableWorks.Name = "labelQulityOfUnemployableWorks";
        this.labelQulityOfUnemployableWorks.TabIndex = 17546;

        this.QulityOfUnemployableWorks = new TTVisual.TTTextBox();
        this.QulityOfUnemployableWorks.Multiline = true;
        this.QulityOfUnemployableWorks.Name = "QulityOfUnemployableWorks";
        this.QulityOfUnemployableWorks.TabIndex = 17545;

        this.labelUnanimity = new TTVisual.TTLabel();
        this.labelUnanimity.Text = i18n("M19834", "Oy Durumu");
        this.labelUnanimity.Name = "labelUnanimity";
        this.labelUnanimity.TabIndex = 17544;

        this.Unanimity = new TTVisual.TTEnumComboBox();
        this.Unanimity.DataTypeName = "LargeMajorityUnanimityEnum";
        this.Unanimity.Required = true;
        this.Unanimity.BackColor = "#FFE3C6";
        this.Unanimity.Name = "Unanimity";
        this.Unanimity.TabIndex = 17543;

        this.labelRation = new TTVisual.TTLabel();
        this.labelRation.Text = i18n("M20763", "Rapor Akıbeti");
        this.labelRation.Name = "labelRation";
        this.labelRation.TabIndex = 17542;

        this.Ration = new TTVisual.TTEnumComboBox();
        this.Ration.DataTypeName = "PositiveNegativeEnum";
        this.Ration.Required = true;
        this.Ration.BackColor = "#FFE3C6";
        this.Ration.Name = "Ration";
        this.Ration.TabIndex = 17541;

        this.ReportDiagnosis = new TTVisual.TTRichTextBoxControl();
        this.ReportDiagnosis.DisplayText = i18n("M20863", "Rapor Tanıları");
        this.ReportDiagnosis.Name = "ReportDiagnosis";
        this.ReportDiagnosis.TabIndex = 17539;

        this.labelDefinition = new TTVisual.TTLabel();
        this.labelDefinition.Text = i18n("M10469", "Açıklama");
        this.labelDefinition.Name = "labelDefinition";
        this.labelDefinition.TabIndex = 17538;

        this.Definition = new TTVisual.TTRichTextBoxControl();
        this.Definition.DisplayText = "Tıbbi gerekçeler";
        this.Definition.Name = "Definition";
        this.Definition.TabIndex = 17537;
        this.Definition.TemplateGroupName = "HCDEFINITION";

        this.UnworkField = new TTVisual.TTTextBox();
        this.UnworkField.Multiline = true;
        this.UnworkField.Name = "UnworkField";
        this.UnworkField.TabIndex = 17535;
        this.UnworkField.Visible = false;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 17489;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 0;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = i18n("M24028", "Vaka Tanıları");
        this.tttabpage2.Name = "tttabpage2";

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 6;

        this.ttcheckboxcolumn4 = new TTVisual.TTCheckBoxColumn();
        this.ttcheckboxcolumn4.DataMember = "AddToHistory";
        this.ttcheckboxcolumn4.DisplayIndex = 0;
        this.ttcheckboxcolumn4.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.ttcheckboxcolumn4.Name = "ttcheckboxcolumn4";
        this.ttcheckboxcolumn4.Width = 90;

        this.ttlistboxcolumn4 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn4.ListDefName = "DiagnosisListDefinition";
        this.ttlistboxcolumn4.DataMember = "Diagnose";
        this.ttlistboxcolumn4.DisplayIndex = 1;
        this.ttlistboxcolumn4.HeaderText = i18n("M22736", "Tanı");
        this.ttlistboxcolumn4.Name = "ttlistboxcolumn4";
        this.ttlistboxcolumn4.Width = 275;

        this.ttenumcomboboxcolumn2 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn2.DataTypeName = "DiagnosisTypeEnum";
        this.ttenumcomboboxcolumn2.DataMember = "DiagnosisType";
        this.ttenumcomboboxcolumn2.DisplayIndex = 2;
        this.ttenumcomboboxcolumn2.HeaderText = i18n("M22781", "Tanı Tipi");
        this.ttenumcomboboxcolumn2.Name = "ttenumcomboboxcolumn2";
        this.ttenumcomboboxcolumn2.Width = 80;

        this.VFreeDiagnosis = new TTVisual.TTTextBoxColumn();
        this.VFreeDiagnosis.DataMember = "FreeDiagnosis";
        this.VFreeDiagnosis.DisplayIndex = 3;
        this.VFreeDiagnosis.HeaderText = i18n("M22737", "Tanı Açıklaması");
        this.VFreeDiagnosis.Name = "VFreeDiagnosis";
        this.VFreeDiagnosis.Width = 200;

        this.ttcheckboxcolumn5 = new TTVisual.TTCheckBoxColumn();
        this.ttcheckboxcolumn5.DataMember = "IsMainDiagnose";
        this.ttcheckboxcolumn5.DisplayIndex = 4;
        this.ttcheckboxcolumn5.HeaderText = i18n("M10926", "Ana Tanı");
        this.ttcheckboxcolumn5.Name = "ttcheckboxcolumn5";
        this.ttcheckboxcolumn5.Width = 75;

        this.ttlistboxcolumn5 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn5.ListDefName = "UserListDefinition";
        this.ttlistboxcolumn5.DataMember = "ResponsibleUser";
        this.ttlistboxcolumn5.DisplayIndex = 5;
        this.ttlistboxcolumn5.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.ttlistboxcolumn5.Name = "ttlistboxcolumn5";
        this.ttlistboxcolumn5.Width = 115;

        this.ttdatetimepickercolumn3 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn3.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn3.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn3.DataMember = "DiagnoseDate";
        this.ttdatetimepickercolumn3.DisplayIndex = 6;
        this.ttdatetimepickercolumn3.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.ttdatetimepickercolumn3.Name = "ttdatetimepickercolumn3";
        this.ttdatetimepickercolumn3.Width = 100;

        this.ttenumcomboboxcolumn3 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn3.DataTypeName = "ActionTypeEnum";
        this.ttenumcomboboxcolumn3.DataMember = "EntryActionType";
        this.ttenumcomboboxcolumn3.DisplayIndex = 7;
        this.ttenumcomboboxcolumn3.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.ttenumcomboboxcolumn3.Name = "ttenumcomboboxcolumn3";
        this.ttenumcomboboxcolumn3.Width = 100;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 1;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M22747", "Tanı Giriş");
        this.tttabpage1.Name = "tttabpage1";

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = i18n("M15767", "Heyet Tanısı");
        this.ttlabel15.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 17486;

        this.Diagnosis = new TTVisual.TTGrid();
        this.Diagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Diagnosis.Text = i18n("M22736", "Tanı");
        this.Diagnosis.Name = "Diagnosis";
        this.Diagnosis.TabIndex = 1;

        this.HAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.HAddToHistory.DataMember = "AddToHistory";
        this.HAddToHistory.DisplayIndex = 0;
        this.HAddToHistory.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.HAddToHistory.Name = "HAddToHistory";
        this.HAddToHistory.Width = 90;

        this.HDiagnose = new TTVisual.TTListBoxColumn();
        this.HDiagnose.ListDefName = "DiagnosisListDefinition";
        this.HDiagnose.DataMember = "Diagnose";
        this.HDiagnose.DisplayIndex = 1;
        this.HDiagnose.HeaderText = i18n("M22736", "Tanı");
        this.HDiagnose.Name = "HDiagnose";
        this.HDiagnose.Width = 300;

        this.HFreeDiagnosis = new TTVisual.TTTextBoxColumn();
        this.HFreeDiagnosis.DataMember = "FreeDiagnosis";
        this.HFreeDiagnosis.DisplayIndex = 2;
        this.HFreeDiagnosis.HeaderText = i18n("M22737", "Tanı Açıklaması");
        this.HFreeDiagnosis.Name = "HFreeDiagnosis";
        this.HFreeDiagnosis.Width = 200;

        this.HIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.HIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.HIsMainDiagnose.DisplayIndex = 3;
        this.HIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.HIsMainDiagnose.Name = "HIsMainDiagnose";
        this.HIsMainDiagnose.Width = 75;

        this.HResponsibleUser = new TTVisual.TTListBoxColumn();
        this.HResponsibleUser.ListDefName = "UserListDefinition";
        this.HResponsibleUser.DataMember = "ResponsibleUser";
        this.HResponsibleUser.DisplayIndex = 4;
        this.HResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.HResponsibleUser.Name = "HResponsibleUser";
        this.HResponsibleUser.ReadOnly = true;
        this.HResponsibleUser.Width = 200;

        this.HDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.HDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.HDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.HDiagnoseDate.DataMember = "DiagnoseDate";
        this.HDiagnoseDate.DisplayIndex = 5;
        this.HDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.HDiagnoseDate.Name = "HDiagnoseDate";
        this.HDiagnoseDate.ReadOnly = true;
        this.HDiagnoseDate.Width = 180;

        this.HCDecisionUnitOfTime = new TTVisual.TTEnumComboBox();
        this.HCDecisionUnitOfTime.DataTypeName = "UnitOfTimeEnum";
        this.HCDecisionUnitOfTime.Required = true;
        this.HCDecisionUnitOfTime.BackColor = "#FFE3C6";
        this.HCDecisionUnitOfTime.Name = "HCDecisionUnitOfTime";
        this.HCDecisionUnitOfTime.TabIndex = 17532;

        this.labelHCDecisionTime = new TTVisual.TTLabel();
        this.labelHCDecisionTime.Text = i18n("M14599", "Geçerlilik Süresi");
        this.labelHCDecisionTime.Name = "labelHCDecisionTime";
        this.labelHCDecisionTime.TabIndex = 17531;

        this.HCDecisionTime = new TTVisual.TTTextBox();
        this.HCDecisionTime.Required = true;
        this.HCDecisionTime.BackColor = "#FFE3C6";
        this.HCDecisionTime.Name = "HCDecisionTime";
        this.HCDecisionTime.TabIndex = 17530;

        this.ttgroupKullanimAmaci = new TTVisual.TTGroupBox();
        this.ttgroupKullanimAmaci.Text = i18n("M20910", "Raporun Kullanım Amacı");
        this.ttgroupKullanimAmaci.Name = "ttgroupKullanimAmaci";
        this.ttgroupKullanimAmaci.TabIndex = 17529;
        this.ttgroupKullanimAmaci.Visible = false;

        this.labelEducationEvaluationIntendedUseOfDisabledReport = new TTVisual.TTLabel();
        this.labelEducationEvaluationIntendedUseOfDisabledReport.Text = "Eğitim";
        this.labelEducationEvaluationIntendedUseOfDisabledReport.Name = "labelEducationEvaluationIntendedUseOfDisabledReport";
        this.labelEducationEvaluationIntendedUseOfDisabledReport.TabIndex = 17516;

        this.OtherExplanationIntendedUseOfDisabledReport = new TTVisual.TTTextBox();
        this.OtherExplanationIntendedUseOfDisabledReport.Multiline = true;
        this.OtherExplanationIntendedUseOfDisabledReport.Name = "OtherExplanationIntendedUseOfDisabledReport";
        this.OtherExplanationIntendedUseOfDisabledReport.TabIndex = 17525;

        this.labelOtherExplanationIntendedUseOfDisabledReport = new TTVisual.TTLabel();
        this.labelOtherExplanationIntendedUseOfDisabledReport.Text = i18n("M12847", "Diğer(Açıklama)");
        this.labelOtherExplanationIntendedUseOfDisabledReport.Name = "labelOtherExplanationIntendedUseOfDisabledReport";
        this.labelOtherExplanationIntendedUseOfDisabledReport.TabIndex = 17526;

        this.labelSocialAidEvaluationIntendedUseOfDisabledReport = new TTVisual.TTLabel();
        this.labelSocialAidEvaluationIntendedUseOfDisabledReport.Text = i18n("M22194", "Sosyal Yardım");
        this.labelSocialAidEvaluationIntendedUseOfDisabledReport.Name = "labelSocialAidEvaluationIntendedUseOfDisabledReport";
        this.labelSocialAidEvaluationIntendedUseOfDisabledReport.TabIndex = 17528;

        this.SocialAidEvaluationIntendedUseOfDisabledReport = new TTVisual.TTEnumComboBox();
        this.SocialAidEvaluationIntendedUseOfDisabledReport.DataTypeName = i18n("M14023", "EvetHayirDegerlendirilmediEnum");
        this.SocialAidEvaluationIntendedUseOfDisabledReport.Name = "SocialAidEvaluationIntendedUseOfDisabledReport";
        this.SocialAidEvaluationIntendedUseOfDisabledReport.TabIndex = 17527;

        this.EducationEvaluationIntendedUseOfDisabledReport = new TTVisual.TTEnumComboBox();
        this.EducationEvaluationIntendedUseOfDisabledReport.DataTypeName = i18n("M14023", "EvetHayirDegerlendirilmediEnum");
        this.EducationEvaluationIntendedUseOfDisabledReport.Name = "EducationEvaluationIntendedUseOfDisabledReport";
        this.EducationEvaluationIntendedUseOfDisabledReport.TabIndex = 17515;

        this.labelEmploymentEvaluationIntendedUseOfDisabledReport = new TTVisual.TTLabel();
        this.labelEmploymentEvaluationIntendedUseOfDisabledReport.Text = i18n("M16728", "İstihdam");
        this.labelEmploymentEvaluationIntendedUseOfDisabledReport.Name = "labelEmploymentEvaluationIntendedUseOfDisabledReport";
        this.labelEmploymentEvaluationIntendedUseOfDisabledReport.TabIndex = 17518;

        this.LawNo2022EvaluationIntendedUseOfDisabledReport = new TTVisual.TTEnumComboBox();
        this.LawNo2022EvaluationIntendedUseOfDisabledReport.DataTypeName = i18n("M14023", "EvetHayirDegerlendirilmediEnum");
        this.LawNo2022EvaluationIntendedUseOfDisabledReport.Name = "LawNo2022EvaluationIntendedUseOfDisabledReport";
        this.LawNo2022EvaluationIntendedUseOfDisabledReport.TabIndex = 17519;

        this.labelLawNo2022EvaluationIntendedUseOfDisabledReport = new TTVisual.TTLabel();
        this.labelLawNo2022EvaluationIntendedUseOfDisabledReport.Text = i18n("M10226", "2022 Sayılı Kanun");
        this.labelLawNo2022EvaluationIntendedUseOfDisabledReport.Name = "labelLawNo2022EvaluationIntendedUseOfDisabledReport";
        this.labelLawNo2022EvaluationIntendedUseOfDisabledReport.TabIndex = 17520;

        this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport = new TTVisual.TTEnumComboBox();
        this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport.DataTypeName = i18n("M14023", "EvetHayirDegerlendirilmediEnum");
        this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport.Name = "OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport";
        this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport.TabIndex = 17521;

        this.labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport = new TTVisual.TTLabel();
        this.labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport.Text = "Ortez/Protez/İşitme Cihazı";
        this.labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport.Name = "labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport";
        this.labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport.TabIndex = 17522;

        this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport = new TTVisual.TTEnumComboBox();
        this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport.DataTypeName = i18n("M14023", "EvetHayirDegerlendirilmediEnum");
        this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport.Name = "DisabledIdentityCardEvalutionIntendedUseOfDisabledReport";
        this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport.TabIndex = 17513;

        this.labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport = new TTVisual.TTLabel();
        this.labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport.Text = i18n("M13742", "Engelli Kimlik Kartı");
        this.labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport.Name = "labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport";
        this.labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport.TabIndex = 17514;

        this.EmploymentEvaluationIntendedUseOfDisabledReport = new TTVisual.TTEnumComboBox();
        this.EmploymentEvaluationIntendedUseOfDisabledReport.DataTypeName = i18n("M14023", "EvetHayirDegerlendirilmediEnum");
        this.EmploymentEvaluationIntendedUseOfDisabledReport.Name = "EmploymentEvaluationIntendedUseOfDisabledReport";
        this.EmploymentEvaluationIntendedUseOfDisabledReport.TabIndex = 17517;

        this.labelDisabledChaiEvaluationIntendedUseOfDisabledReport = new TTVisual.TTLabel();
        this.labelDisabledChaiEvaluationIntendedUseOfDisabledReport.Text = i18n("M23077", "Tekerlekli Sandalye");
        this.labelDisabledChaiEvaluationIntendedUseOfDisabledReport.Name = "labelDisabledChaiEvaluationIntendedUseOfDisabledReport";
        this.labelDisabledChaiEvaluationIntendedUseOfDisabledReport.TabIndex = 17512;

        this.DisabledChaiEvaluationIntendedUseOfDisabledReport = new TTVisual.TTEnumComboBox();
        this.DisabledChaiEvaluationIntendedUseOfDisabledReport.DataTypeName = i18n("M14023", "EvetHayirDegerlendirilmediEnum");
        this.DisabledChaiEvaluationIntendedUseOfDisabledReport.Name = "DisabledChaiEvaluationIntendedUseOfDisabledReport";
        this.DisabledChaiEvaluationIntendedUseOfDisabledReport.TabIndex = 17511;

        this.ttgroupEngel = new TTVisual.TTGroupBox();
        this.ttgroupEngel.Text = i18n("M17597", "Kişinin Engel Grubu");
        this.ttgroupEngel.Name = "ttgroupEngel";
        this.ttgroupEngel.TabIndex = 17508;
        this.ttgroupEngel.Visible = false;

        this.OrthopedicMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.OrthopedicMedicalInfoDisabledGroup.Value = false;
        this.OrthopedicMedicalInfoDisabledGroup.Title = i18n("M19803", "Ortopedik");
        this.OrthopedicMedicalInfoDisabledGroup.Name = "OrthopedicMedicalInfoDisabledGroup";
        this.OrthopedicMedicalInfoDisabledGroup.TabIndex = 17503;

        this.UnclassifiedMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.UnclassifiedMedicalInfoDisabledGroup.Value = false;
        this.UnclassifiedMedicalInfoDisabledGroup.Title = i18n("M21813", "Sınıflanmayan");
        this.UnclassifiedMedicalInfoDisabledGroup.Name = "UnclassifiedMedicalInfoDisabledGroup";
        this.UnclassifiedMedicalInfoDisabledGroup.TabIndex = 17506;

        this.VisionMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.VisionMedicalInfoDisabledGroup.Value = false;
        this.VisionMedicalInfoDisabledGroup.Title = i18n("M14922", "Görme");
        this.VisionMedicalInfoDisabledGroup.Name = "VisionMedicalInfoDisabledGroup";
        this.VisionMedicalInfoDisabledGroup.TabIndex = 17507;

        this.ChronicMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.ChronicMedicalInfoDisabledGroup.Value = false;
        this.ChronicMedicalInfoDisabledGroup.Title = i18n("M22422", "Süreğen(Kronik)");
        this.ChronicMedicalInfoDisabledGroup.Name = "ChronicMedicalInfoDisabledGroup";
        this.ChronicMedicalInfoDisabledGroup.TabIndex = 17500;

        this.PsychicAndEmotionalMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Value = false;
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Title = i18n("M21065", "Ruhsal ve Duygusal");
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Name = "PsychicAndEmotionalMedicalInfoDisabledGroup";
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.TabIndex = 17504;

        this.SpeechAndLanguageMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Value = false;
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Title = i18n("M12854", "Dil ve Konuşma");
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Name = "SpeechAndLanguageMedicalInfoDisabledGroup";
        this.SpeechAndLanguageMedicalInfoDisabledGroup.TabIndex = 17505;

        this.MentalMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.MentalMedicalInfoDisabledGroup.Value = false;
        this.MentalMedicalInfoDisabledGroup.Title = i18n("M24771", "Zihinsel");
        this.MentalMedicalInfoDisabledGroup.Name = "MentalMedicalInfoDisabledGroup";
        this.MentalMedicalInfoDisabledGroup.TabIndex = 17502;

        this.HearingMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.HearingMedicalInfoDisabledGroup.Value = false;
        this.HearingMedicalInfoDisabledGroup.Title = i18n("M16816", "İşitme");
        this.HearingMedicalInfoDisabledGroup.Name = "HearingMedicalInfoDisabledGroup";
        this.HearingMedicalInfoDisabledGroup.TabIndex = 17501;

        this.labelReasonForExaminationHCRequestReason = new TTVisual.TTLabel();
        this.labelReasonForExaminationHCRequestReason.Text = i18n("M20869", "Rapor Türü");
        this.labelReasonForExaminationHCRequestReason.Name = "labelReasonForExaminationHCRequestReason";
        this.labelReasonForExaminationHCRequestReason.TabIndex = 17499;

        this.ReasonForExaminationHCRequestReason = new TTVisual.TTObjectListBox();
        this.ReasonForExaminationHCRequestReason.Enabled = false;
        this.ReasonForExaminationHCRequestReason.ListDefName = "HealthCommitteeExaminationReasonListDefinition";
        this.ReasonForExaminationHCRequestReason.Name = "ReasonForExaminationHCRequestReason";
        this.ReasonForExaminationHCRequestReason.TabIndex = 17498;
        // this.ReasonForExaminationHCRequestReason.AutoCompleteDialogWidth = "300px"

        this.labelHCRequestReason = new TTVisual.TTLabel();
        this.labelHCRequestReason.Text = i18n("M16646", "İstek Sebebi");
        this.labelHCRequestReason.Name = "labelHCRequestReason";
        this.labelHCRequestReason.TabIndex = 17497;

        this.HCRequestReason = new TTVisual.TTObjectListBox();
        this.HCRequestReason.ReadOnly = true;
        this.HCRequestReason.ListDefName = "HCRequestReasonListDefinition";
        this.HCRequestReason.Name = "HCRequestReason";
        this.HCRequestReason.TabIndex = 17496;

        this.ResultedLabel = new TTVisual.TTLabel();
        this.ResultedLabel.Text = i18n("M21209", "Sağlık Kurulu Muayene İşlemleri Sonuçlanmıştır");
        this.ResultedLabel.Font = "Name=Tahoma, Size=9,75, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResultedLabel.ForeColor = "#FF0000";
        this.ResultedLabel.Name = "ResultedLabel";
        this.ResultedLabel.TabIndex = 17495;

        this.FunctionRatio = new TTVisual.TTTextBox();
        this.FunctionRatio.BackColor = "#F0F0F0";
        this.FunctionRatio.ReadOnly = true;
        this.FunctionRatio.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FunctionRatio.Name = "FunctionRatio";
        this.FunctionRatio.TabIndex = 21;

        this.labelFunctionRatio = new TTVisual.TTLabel();
        this.labelFunctionRatio.Text = i18n("M24193", "Vücut Foksiyon Kayıp Oranı");
        this.labelFunctionRatio.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelFunctionRatio.ForeColor = "#000000";
        this.labelFunctionRatio.Name = "labelFunctionRatio";
        this.labelFunctionRatio.TabIndex = 17488;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 17443;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 0;

        this.HCStartDate = new TTVisual.TTDateTimePicker();
        this.HCStartDate.BackColor = "#F0F0F0";
        this.HCStartDate.CustomFormat = "";
        this.HCStartDate.Format = DateTimePickerFormat.Long;
        this.HCStartDate.Enabled = false;
        this.HCStartDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.HCStartDate.Name = "HCStartDate";
        this.HCStartDate.TabIndex = 1;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = i18n("M15425", "XXXXXXye Müracaat Tarihi");
        this.labelStartDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStartDate.ForeColor = "#000000";
        this.labelStartDate.Name = "labelStartDate";
        this.labelStartDate.TabIndex = 17444;

        this.ReportDate = new TTVisual.TTDateTimePicker();
        this.ReportDate.BackColor = "#F0F0F0";
        this.ReportDate.CustomFormat = "";
        this.ReportDate.Format = DateTimePickerFormat.Long;
        this.ReportDate.Enabled = false;
        this.ReportDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReportDate.Name = "ReportDate";
        this.ReportDate.TabIndex = 2;

        this.labelReportDate = new TTVisual.TTLabel();
        this.labelReportDate.Text = i18n("M20864", "Rapor Tarihi");
        this.labelReportDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReportDate.ForeColor = "#000000";
        this.labelReportDate.Name = "labelReportDate";
        this.labelReportDate.TabIndex = 86;

        this.RationWeight = new TTVisual.TTTextBox();
        this.RationWeight.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RationWeight.Name = "RationWeight";
        this.RationWeight.TabIndex = 20;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M11992", "Boy(cm)");
        this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 17473;

        this.DocumentDate = new TTVisual.TTDateTimePicker();
        this.DocumentDate.BackColor = "#F0F0F0";
        this.DocumentDate.CustomFormat = "";
        this.DocumentDate.Format = DateTimePickerFormat.Long;
        this.DocumentDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DocumentDate.Name = "DocumentDate";
        this.DocumentDate.TabIndex = 3;

        this.labelDocumentDate = new TTVisual.TTLabel();
        this.labelDocumentDate.Text = "Evrak/Sevk Tarihi";
        this.labelDocumentDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDocumentDate.ForeColor = "#000000";
        this.labelDocumentDate.Name = "labelDocumentDate";
        this.labelDocumentDate.TabIndex = 17447;

        this.DocumentNumber = new TTVisual.TTTextBox();
        this.DocumentNumber.BackColor = "#F0F0F0";
        this.DocumentNumber.ReadOnly = true;
        this.DocumentNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DocumentNumber.Name = "DocumentNumber";
        this.DocumentNumber.TabIndex = 4;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M10569", "Ağırlık(Kg)");
        this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 17472;

        this.RationHeight = new TTVisual.TTTextBox();
        this.RationHeight.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RationHeight.Name = "RationHeight";
        this.RationHeight.TabIndex = 24;

        this.labelNumberOfDocumnets = new TTVisual.TTLabel();
        this.labelNumberOfDocumnets.Text = i18n("M21725", "Sevk No");
        this.labelNumberOfDocumnets.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelNumberOfDocumnets.ForeColor = "#000000";
        this.labelNumberOfDocumnets.Name = "labelNumberOfDocumnets";
        this.labelNumberOfDocumnets.TabIndex = 17448;

        this.BookNumber = new TTVisual.TTTextBox();
        //this.BookNumber.BackColor = "#F0F0F0";
        this.BookNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BookNumber.Name = "BookNumber";
        this.BookNumber.TabIndex = 16;

        this.LabelMasterResource = new TTVisual.TTLabel();
        this.LabelMasterResource.Text = "Birimi";
        this.LabelMasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelMasterResource.ForeColor = "#000000";
        this.LabelMasterResource.Name = "LabelMasterResource";
        this.LabelMasterResource.TabIndex = 17454;

        this.ReportNo = new TTVisual.TTTextBox();
        this.ReportNo.BackColor = "#F0F0F0";
        this.ReportNo.ReadOnly = true;
        this.ReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReportNo.Name = "ReportNo";
        this.ReportNo.TabIndex = 15;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.ListDefName = "ResourceListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 8;

        this.labelBookNumber = new TTVisual.TTLabel();
        this.labelBookNumber.Text = i18n("M12519", "Defter No");
        this.labelBookNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBookNumber.ForeColor = "#000000";
        this.labelBookNumber.Name = "labelBookNumber";
        this.labelBookNumber.TabIndex = 80;

        this.labelReportNo = new TTVisual.TTLabel();
        this.labelReportNo.Text = i18n("M20821", "Rapor No");
        this.labelReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReportNo.ForeColor = "#000000";
        this.labelReportNo.Name = "labelReportNo";
        this.labelReportNo.TabIndex = 76;

        this.labelSendExamination = new TTVisual.TTLabel();
        this.labelSendExamination.Text = i18n("M19260", "Muayeneye Gönderen");
        this.labelSendExamination.Name = "labelSendExamination";

        this.MembersColumns = [this.MemberDoctorMemberOfHealthCommiittee, this.SpecialityMemberOfHealthCommiittee, this.ApproveMemberOfHealthCommiittee, this.RejectMemberOfHealthCommiittee, this.DescriptionMemberOfHealthCommiittee];
        this.ExternalDoctorsColumns = [this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid, this.SpecialityBaseHealthCommittee_ExtDoctorGrid, this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid, this.ApproveBaseHealthCommittee_ExtDoctorGrid, this.RejectBaseHealthCommittee_ExtDoctorGrid, this.DescriptionBaseHealthCommittee_ExtDoctorGrid];
        this.HospitalsUnitsColumns = [this.DoctorBaseHealthCommittee_HospitalsUnitsGrid, this.UnitBaseHealthCommittee_HospitalsUnitsGrid, this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid];
        this.SystemForHealthCommitteeGridColumns = [this.SystemForDisabledSystemForHealthCommitteeGrid, this.DisabledOfferDecisionSystemForHealthCommitteeGrid, this.DisabledRatio];
        this.GridEpisodeDiagnosisColumns = [this.ttcheckboxcolumn4, this.ttlistboxcolumn4, this.ttenumcomboboxcolumn2, this.VFreeDiagnosis, this.ttcheckboxcolumn5, this.ttlistboxcolumn5, this.ttdatetimepickercolumn3, this.ttenumcomboboxcolumn3];
        this.DiagnosisColumns = [this.HAddToHistory, this.HDiagnose, this.HFreeDiagnosis, this.HIsMainDiagnose, this.HResponsibleUser, this.HDiagnoseDate];
        this.tttabcontrolMain.Controls = [this.tttabpageHC];
        this.tttabpageHC.Controls = [this.Members, this.ExternalDoctorInfo, this.ExternalDoctors, this.ttlabel1, this.labelNameSurnameReceiveReport, this.HospitalsUnits, this.NameSurnameReceiveReport, this.labelUniqueRefReceiveReport, this.UniqueRefReceiveReport, this.labelDegreeOfBloodRelatives, this.DegreeOfBloodRelatives, this.labelClinicalFindings, this.ClinicalFindings, this.labelBodyMassIndex, this.BodyMassIndex, this.SystemForHealthCommitteeGrid, this.HealthCommitteeDecision, this.labelSendExamination, this.SendExamination, this.IsHeavyDisabled, this.labelQulityOfUnemployableWorks, this.QulityOfUnemployableWorks, this.labelUnanimity, this.Unanimity, this.labelRation, this.Ration, this.ReportDiagnosis, this.labelDefinition, this.Definition, this.labelUnworkField, this.UnworkField, this.tttabcontrol1, this.HCDecisionUnitOfTime, this.labelHCDecisionTime, this.HCDecisionTime, this.ttgroupKullanimAmaci, this.ttgroupEngel, this.labelReasonForExaminationHCRequestReason, this.ReasonForExaminationHCRequestReason, this.labelHCRequestReason, this.HCRequestReason, this.FunctionRatio, this.labelFunctionRatio, this.labelProtocolNo, this.ProtocolNo, this.HCStartDate, this.labelStartDate, this.ReportDate, this.labelReportDate, this.RationWeight, this.ttlabel10, this.DocumentDate, this.labelDocumentDate, this.DocumentNumber, this.ttlabel9, this.RationHeight, this.labelNumberOfDocumnets, this.BookNumber, this.LabelMasterResource, this.ReportNo, this.MasterResource, this.labelBookNumber, this.labelReportNo];
        this.tttabcontrol1.Controls = [this.tttabpage2, this.tttabpage1];
        this.tttabpage2.Controls = [this.GridEpisodeDiagnosis];
        this.tttabpage1.Controls = [this.ttlabel15, this.Diagnosis];
        this.ttgroupKullanimAmaci.Controls = [this.labelEducationEvaluationIntendedUseOfDisabledReport, this.OtherExplanationIntendedUseOfDisabledReport, this.labelOtherExplanationIntendedUseOfDisabledReport, this.labelSocialAidEvaluationIntendedUseOfDisabledReport, this.SocialAidEvaluationIntendedUseOfDisabledReport, this.EducationEvaluationIntendedUseOfDisabledReport, this.labelEmploymentEvaluationIntendedUseOfDisabledReport, this.LawNo2022EvaluationIntendedUseOfDisabledReport, this.labelLawNo2022EvaluationIntendedUseOfDisabledReport, this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport, this.labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport, this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport, this.labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport, this.EmploymentEvaluationIntendedUseOfDisabledReport, this.labelDisabledChaiEvaluationIntendedUseOfDisabledReport, this.DisabledChaiEvaluationIntendedUseOfDisabledReport];
        this.ttgroupEngel.Controls = [this.OrthopedicMedicalInfoDisabledGroup, this.UnclassifiedMedicalInfoDisabledGroup, this.VisionMedicalInfoDisabledGroup, this.ChronicMedicalInfoDisabledGroup, this.PsychicAndEmotionalMedicalInfoDisabledGroup, this.SpeechAndLanguageMedicalInfoDisabledGroup, this.MentalMedicalInfoDisabledGroup, this.HearingMedicalInfoDisabledGroup];
        this.Controls = [this.tttabcontrolMain, this.tttabpageHC, this.Members, this.MemberDoctorMemberOfHealthCommiittee, this.SpecialityMemberOfHealthCommiittee, this.ApproveMemberOfHealthCommiittee, this.RejectMemberOfHealthCommiittee, this.DescriptionMemberOfHealthCommiittee, this.ExternalDoctorInfo, this.ExternalDoctors, this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid, this.SpecialityBaseHealthCommittee_ExtDoctorGrid, this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid, this.ApproveBaseHealthCommittee_ExtDoctorGrid, this.RejectBaseHealthCommittee_ExtDoctorGrid, this.DescriptionBaseHealthCommittee_ExtDoctorGrid, this.ttlabel1, this.labelNameSurnameReceiveReport, this.HospitalsUnits, this.DoctorBaseHealthCommittee_HospitalsUnitsGrid, this.UnitBaseHealthCommittee_HospitalsUnitsGrid, this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid, this.NameSurnameReceiveReport, this.labelUniqueRefReceiveReport, this.UniqueRefReceiveReport, this.labelDegreeOfBloodRelatives, this.DegreeOfBloodRelatives, this.labelClinicalFindings, this.ClinicalFindings, this.labelBodyMassIndex, this.BodyMassIndex, this.SystemForHealthCommitteeGrid, this.SystemForDisabledSystemForHealthCommitteeGrid, this.DisabledOfferDecisionSystemForHealthCommitteeGrid, this.DisabledRatio, this.HealthCommitteeDecision, this.labelSendExamination, this.SendExamination, this.IsHeavyDisabled, this.labelQulityOfUnemployableWorks, this.QulityOfUnemployableWorks, this.labelUnanimity, this.Unanimity, this.labelRation, this.Ration, this.ReportDiagnosis, this.labelDefinition, this.Definition, this.labelUnworkField, this.UnworkField, this.tttabcontrol1, this.tttabpage2, this.GridEpisodeDiagnosis, this.ttcheckboxcolumn4, this.ttlistboxcolumn4, this.ttenumcomboboxcolumn2, this.VFreeDiagnosis, this.ttcheckboxcolumn5, this.ttlistboxcolumn5, this.ttdatetimepickercolumn3, this.ttenumcomboboxcolumn3, this.tttabpage1, this.ttlabel15, this.Diagnosis, this.HAddToHistory, this.HDiagnose, this.HFreeDiagnosis, this.HIsMainDiagnose, this.HResponsibleUser, this.HDiagnoseDate, this.HCDecisionUnitOfTime, this.labelHCDecisionTime, this.HCDecisionTime, this.ttgroupKullanimAmaci, this.labelEducationEvaluationIntendedUseOfDisabledReport, this.OtherExplanationIntendedUseOfDisabledReport, this.labelOtherExplanationIntendedUseOfDisabledReport, this.labelSocialAidEvaluationIntendedUseOfDisabledReport, this.SocialAidEvaluationIntendedUseOfDisabledReport, this.EducationEvaluationIntendedUseOfDisabledReport, this.labelEmploymentEvaluationIntendedUseOfDisabledReport, this.LawNo2022EvaluationIntendedUseOfDisabledReport, this.labelLawNo2022EvaluationIntendedUseOfDisabledReport, this.OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport, this.labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport, this.DisabledIdentityCardEvalutionIntendedUseOfDisabledReport, this.labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport, this.EmploymentEvaluationIntendedUseOfDisabledReport, this.labelDisabledChaiEvaluationIntendedUseOfDisabledReport, this.DisabledChaiEvaluationIntendedUseOfDisabledReport, this.ttgroupEngel, this.OrthopedicMedicalInfoDisabledGroup, this.UnclassifiedMedicalInfoDisabledGroup, this.VisionMedicalInfoDisabledGroup, this.ChronicMedicalInfoDisabledGroup, this.PsychicAndEmotionalMedicalInfoDisabledGroup, this.SpeechAndLanguageMedicalInfoDisabledGroup, this.MentalMedicalInfoDisabledGroup, this.HearingMedicalInfoDisabledGroup, this.labelReasonForExaminationHCRequestReason, this.ReasonForExaminationHCRequestReason, this.labelHCRequestReason, this.HCRequestReason, this.FunctionRatio, this.labelFunctionRatio, this.labelProtocolNo, this.ProtocolNo, this.HCStartDate, this.labelStartDate, this.ReportDate, this.labelReportDate, this.RationWeight, this.ttlabel10, this.DocumentDate, this.labelDocumentDate, this.DocumentNumber, this.ttlabel9, this.RationHeight, this.labelNumberOfDocumnets, this.BookNumber, this.LabelMasterResource, this.ReportNo, this.MasterResource, this.labelBookNumber, this.labelReportNo];

    }

    public onhCExaminationGridRowPrepared(e: any): void {
        //e.rowElement.firstItem().css({ 'line-height': '12px' });
        this.renderer.setStyle(e.rowElement.firstItem(), "line-height", "12px");
        //this.renderer.setStyle(e.rowElement.firstItem(), "height", "41px");
    }

    async  undoHCExamination() {
        let massage: string = "";
        let that = this;
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İşlem Geri Alma',
            massage + " Sağlık kurulu işlemi geri alınacaktır.Devam etmek istediğinize emin misiniz? ");
        if (result === 'V') {
            ServiceLocator.MessageService.showSuccess(i18n("M14753", "Geri Alma İşleminden Vazgeçildi"));
        }
        else {

            let _DocumentServiceUrl: string = "/api/HealthCommitteeService/UndoHCExamination?ObjectId=" + that.hCExaminationFormViewModel._HealthCommittee.ObjectID.toString();
            that.httpService.get<Array<EpisodeActionData>>(_DocumentServiceUrl).then(result => {
                ServiceLocator.MessageService.showSuccess("İşlem geri alınmıştır");
                //this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PATIENTINTERVIEWFORM", this.nursingOrderDetailFormViewModel._NursingOrderDetail.ObjectID, null);
                this.httpService.episodeActionWorkListSharedService.refreshWorklist(this.isRefreshWorkList);

                let compInfo :DynamicComponentInfo=new DynamicComponentInfo();
                
                let hc = result.find(o => o.ObjectDefName.toString() === "HEALTHCOMMITTEE");
                if (hc) {                                  
                
                    if (hc.State == "Yeni") 
                        compInfo.ComponentName = 'HCNewForm';
                    else
                        compInfo.ComponentName = 'HCExaminationForm';

                    compInfo.ModuleName = 'SaglikKuruluModule';
                    compInfo.ModulePath = '/Modules/Tibbi_Surec/Saglik_Kurulu_Modulu/SaglikKuruluModule';
                    compInfo.objectID = hc.ObjectID.toString();
                    compInfo.InputParam = null;

                    this.httpService.episodeActionWorkListSharedService.refreshHCExaminationForm(compInfo);
                }
            }).catch(err => {
                ServiceLocator.MessageService.showError(i18n("M16843", "İşlem geri alınamamıştır.") + err);
            });
        }
    }

    async btnAddUserTemplate_Click(): Promise<void> {
        try {

            let message: string = "Şablon Olarak En son Kaydetmiş Olduğunuz Veri Saklanacaktır.(Her zaman Ekranda Görünen Veri Olmayabilir). Devam Etmek İstiyor Musunuz?";
            let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", message, 1);
            if (result === "OK") {             

                if (this.userTemplateName != null || (this.userTemplateName != null && !this.userTemplateName.toString().isNullOrEmpty())) {
                    let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

                    savedUserTemplate.Description = this.userTemplateName;
                    savedUserTemplate.TAObjectDefID = this.hCExaminationFormViewModel._HealthCommittee.ObjectDefID;
                    savedUserTemplate.TAObjectID = this.hCExaminationFormViewModel._HealthCommittee.ObjectID;

                    let apiUrl: string = 'api/HealthCommitteeService/SaveHcExaminationtUserTemplate';
                    this.loadPanelOperation(true, 'Şablon Kaydediliyor, Lütfen Bekleyiniz');
                    await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                        this.hCExaminationFormViewModel.userTemplateList = result;
                        this.hCExaminationFormViewModel.selectedUserTemplate = null;
                        this.userTemplateName = "";
                        ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Oluşturuldu");
                    });
                    this.loadPanelOperation(false, '');
                } else {
                    ServiceLocator.MessageService.showError("Şablon ismi girmeden yeni şablon oluşturamazsınız");
                }
            }

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            // TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {

            if (this.hCExaminationFormViewModel.selectedUserTemplate == null || (this.hCExaminationFormViewModel.selectedUserTemplate.ObjectID != event.itemData.ObjectID)) {
                this.hCExaminationFormViewModel.selectedUserTemplate = event.itemData;
                const that = this;

                this.loadPanelOperation(true, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                that.loadExaminationByTemplate();
                this.loadPanelOperation(false, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
            }
        }

    }
    
    protected async loadExaminationByTemplate() {
        try {


            let fullApiUrl: string = "";


            fullApiUrl = "/api/HealthCommitteeService/GetHCExaminationFormTemplate?TAObjectID="+  this.hCExaminationFormViewModel.selectedUserTemplate.TAObjectID;

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<HealthCommittee>(fullApiUrl);
            
            if(response != null )
            {
                if(response.HealthCommitteeDecision != null)
                    this._HealthCommittee.HealthCommitteeDecision = response.HealthCommitteeDecision;

                if(response.ClinicalFindings != null)    
                    this._HealthCommittee.ClinicalFindings =response.ClinicalFindings;

                if(response.ClinicalFindings != null)    
                    this._HealthCommittee.ClinicalFindings =response.ClinicalFindings;             
                    
                if(response.Definition != null)    
                    this._HealthCommittee.Definition =response.Definition;     

                if(response.HCDecisionTime != null)    
                    this._HealthCommittee.HCDecisionTime =response.HCDecisionTime;                                     
                    
                if(response.HCDecisionUnitOfTime != null)    
                    this._HealthCommittee.HCDecisionUnitOfTime =response.HCDecisionUnitOfTime;                  

            }


        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            // TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    
    async btnDeleteSelectedUserTemplate_Click(): Promise<void> {
        try {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Şablon Sistemden Silinecektir!! Devam Etmek İstiyor Musunuz ? "), 1);
            if (result === "H")
                return;
            let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

            savedUserTemplate.ObjectID = this.hCExaminationFormViewModel.selectedUserTemplate.ObjectID;
            savedUserTemplate.TAObjectDefID = this.hCExaminationFormViewModel._HealthCommittee.ObjectDefID;
            let apiUrl: string = 'api/HealthCommitteeService/SaveHcExaminationtUserTemplate';
            this.loadPanelOperation(true, 'Şablon Siliniyor, Lütfen Bekleyiniz');
            await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                this.hCExaminationFormViewModel.userTemplateList = result;
                this.hCExaminationFormViewModel.selectedUserTemplate = null;
                this.userTemplateName = "";
                ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Silindi");
            });
            this.loadPanelOperation(false, '');

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            // TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

}
