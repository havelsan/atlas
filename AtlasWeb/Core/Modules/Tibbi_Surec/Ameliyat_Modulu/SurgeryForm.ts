
import { Component, ViewChild, OnInit, ApplicationRef, NgZone, HostListener, OnDestroy } from '@angular/core';
import { SurgeryFormViewModel, SurgeryPersonneSpecilaity } from './SurgeryFormViewModel';
import { SurgeryProcedureFormViewModel, GetNewViewModelByProcedureObject } from './SurgeryProcedureFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AnesthesiaAndReanimation, AyniFarkliKesi, SurgeryProcedure, SurgeryRejectReason } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { AnesthesiaPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryExpend } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { HvlDataGrid } from 'app/Fw/Components/HvlDataGrid';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { SurgeryResultDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryRobsonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { StringParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { ClickFunctionParams, ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { type } from 'devexpress-dashboard/model/index.metadata';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { SurgeryRejectReasonFormViewModel } from './SurgeryRejectReasonFormViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { CommonHelper } from '../../../wwwroot/app/Helper/CommonHelper';
@Component({
    selector: 'SurgeryForm',
    templateUrl: './SurgeryForm.html',
    providers: [MessageService]
})
export class SurgeryForm extends EpisodeActionForm implements OnInit, OnDestroy {
    @ViewChild('scrollPanel') ScrollPanel: HTMLElement;
    @ViewChild('gridAnesthesisSurgeryPersonnels') gridAnesthesisSurgeryPersonnels: HvlDataGrid;
    @ViewChild('gridSurgeryPersonnelsMain') gridSurgeryPersonnelsMain: HvlDataGrid;
    @ViewChild('surgeryPanel') surgeryPanel: HTMLElement;
    ACActionDate: TTVisual.ITTDateTimePickerColumn;
    ACNote: TTVisual.ITTTextBoxColumn;
    ACProcedureDoctor: TTVisual.ITTListBoxColumn;
    ACProcedureObject: TTVisual.ITTListBoxColumn;
    Ameliyat: TTVisual.ITTTabControl;
    AmountDirectPurchaseGrid: TTVisual.ITTTextBoxColumn;
    AnestesiaProcedureDoctor: TTVisual.ITTObjectListBox;
    AnestesiaProcedureDoctor2: TTVisual.ITTObjectListBox;
    AnesthesiaReport: TTVisual.ITTRichTextBoxControl;
    AnesteziTeknigi: TTVisual.ITTEnumComboBox;
    AnesthesiaEndDateTime: TTVisual.ITTDateTimePicker;
    AnesthesiaInfo: TTVisual.ITTTabPage;
    AnesthesiaPersonnel: TTVisual.ITTListBoxColumn;
    AnesthesiaStartDateTime: TTVisual.ITTDateTimePicker;
    CAMaterial: TTVisual.ITTListBoxColumn;
    CARole: TTVisual.ITTEnumComboBoxColumn;
    CAStore: TTVisual.ITTListBoxColumn;
    DescriptionToPreOp: TTVisual.ITTRichTextBoxControl;
    DirectPurchase: TTVisual.ITTTabPage;
    DirectPurchaseGrids: TTVisual.ITTGrid;
    DistributionType: TTVisual.ITTTextBoxColumn;
    DonorID: TTVisual.ITTTextBoxColumn;
    Emergency: TTVisual.ITTCheckBox;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridAnesthesiaPersonnels: TTVisual.ITTGrid;
    GridAnesthesiaProcedures: TTVisual.ITTGrid;
    GridDiagnosis: TTVisual.ITTGrid;
    GridSurgeryExpends: TTVisual.ITTGrid;
    GridSurgeryPersonnels: TTVisual.ITTGrid;
    labelAnesthesiaEndDateTime: TTVisual.ITTLabel;
    labelAnesthesiaStartDateTime: TTVisual.ITTLabel;
    labelPlannedSurgeryDescription: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProcedureDoctor2: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelReasonOfReject: TTVisual.ITTLabel;
    labelRequestDate: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    labelSurgeryDesk: TTVisual.ITTLabel;
    labelSurgeryEndTime: TTVisual.ITTLabel;
    labelSurgeryShift: TTVisual.ITTLabel;
    labelSurgeryPointGroup: TTVisual.ITTLabel;
    labelSurgeryStartTime: TTVisual.ITTLabel;
    labelSurgeryStatus: TTVisual.ITTLabel;
    MainSurgeryProcedures: TTVisual.ITTTabPage;
    MasterResource: TTVisual.ITTObjectListBox;
    MaterialDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    PlannedSurgeryDate: TTVisual.ITTDateTimePicker;
    PlannedSurgeryDescription: TTVisual.ITTTextBox;
    PreOpDescriptions: TTVisual.ITTRichTextBoxControl;
    PreOperativeInfo: TTVisual.ITTTabPage;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    ReasonOfReject: TTVisual.ITTRichTextBoxControl;
    RequestDate: TTVisual.ITTDateTimePicker;

    //Role: TTVisual.ITTTextBoxColumn;
    SurgeryDesk: TTVisual.ITTObjectListBox;
    SurgeryEndTime: TTVisual.ITTDateTimePicker;
    SurgeryExpend: TTVisual.ITTTabPage;
    SurgeryInfo: TTVisual.ITTTabPage;
    SurgeryPersonnel: TTVisual.ITTListBoxColumn;
    SurgeryPersonnelSpeciality: TTVisual.ITTTextBoxColumn;
    SurgeryProcedures: TTVisual.ITTTabPage;
    SurgeryReport: TTVisual.ITTRichTextBoxControl;
    SurgeryReportDate: TTVisual.ITTDateTimePicker;
    SurgeryResult: TTVisual.ITTObjectListBox;
    SurgeryRobson: TTVisual.ITTObjectListBox;
    SurgeryRoom: TTVisual.ITTObjectListBox;
    SurgeryShift: TTVisual.ITTEnumComboBox;
    SurgeryPointGroup: TTVisual.ITTEnumComboBox;
    SurgeryStartTime: TTVisual.ITTDateTimePicker;
    SurgeryStatus: TTVisual.ITTEnumComboBox;
    SurgeryTeam: TTVisual.ITTTabPage;
    TabOperative: TTVisual.ITTTabControl;
    ttdatetimepickercolumn1: TTVisual.ITTDateTimePickerColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    tttextboxcolumn1: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn2: TTVisual.ITTTextBoxColumn;
    SelectedSurgeryProcedure: TTVisual.ITTObjectListBox;
    ASAType: TTVisual.ITTEnumComboBoxColumn;
    ASATypeAnesthesiaAndReanimation: TTVisual.ITTEnumComboBox;
    ScarTypeAnesthesiaAndReanimation: TTVisual.ITTEnumComboBox;
    ASAScoreAnesthesiaAndReanimation: TTVisual.ITTEnumComboBox;
    AnesthesiaReportDateAnesthesiaAndReanimation: TTVisual.ITTDateTimePicker;
    LaparoscopyAnesthesiaAndReanimation: TTVisual.ITTEnumComboBox;
    HasComplicationAnesthesiaAndReanimation: TTVisual.ITTCheckBox;
    ComplicationDescriptionAnesthesiaAndReanimation: TTVisual.ITTTextBox;

    public ComfirmAddRowByPersonelFilterSelectionFunc: Function;
    public ComfirmAddRowByPersonelFilterSelectionAnesthesisFunc: Function;

    public DirectPurchaseGridsColumns = [];
    public GridAnesthesiaPersonnelsColumns = [];
    public GridAnesthesiaProceduresColumns = [];
    public GridDiagnosisColumns = [];
    public GridSurgeryExpendsColumns = [];
    public GridSurgeryPersonnelsColumns = [];
    public surgeryFormViewModel: SurgeryFormViewModel = new SurgeryFormViewModel();
    public get _Surgery(): Surgery {
        return this._TTObject as Surgery;
    }
    private SurgeryForm_DocumentUrl: string = '/api/SurgeryService/SurgeryForm';
    constructor(private sideBarMenuService: ISidebarMenuService, protected httpService: NeHttpService,
        protected messageService: MessageService, protected helpMenuService: HelpMenuService,
        private detector: ApplicationRef, private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SurgeryForm_DocumentUrl;
        this.ComfirmAddRowByPersonelFilterSelectionFunc = this.comfirmAddRowByPersonelFilterSelection.bind(this);
        this.ComfirmAddRowByPersonelFilterSelectionAnesthesisFunc = this.comfirmAddRowByPersonelAnesthesisFilterSelection.bind(this);
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected showSurgeryRejectForm(transDef: TTObjectStateTransitionDef): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let data: SurgeryRejectReasonFormViewModel = new SurgeryRejectReasonFormViewModel();

            // data._SurgeryRejectReason= this._Surgery.SurgeryRejectReason;
            // if (transDef) {
            //     data.CurrentObjectTransDefID = transDef.StateTransitionDefID;
            //     data.CurrentObject = this._TTObject;
            // }

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "SurgeryRejectReasonForm";
            componentInfo.ModuleName = "AmeliyatModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._Surgery.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Ameliyat Ret/Erteleme Nedeni";
            modalInfo.Width = 600;
            modalInfo.Height = 240;
            modalInfo.IsShowCloseButton = false;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            if (transDef.ToStateDefID.valueOf() == Surgery.SurgeryStates.Cancelled.id ||
                (transDef.FromStateDefID.valueOf() == Surgery.SurgeryStates.Surgery.id && transDef.ToStateDefID.valueOf() == Surgery.SurgeryStates.SurgeryRequest.id)) {
                // if (this._Surgery.ReasonOfReject == null) {
                // throw new Exception("Ameliyatın Yapılamama Nedeni giriniz");
                // this._Surgery.ReasonOfReject = await InputForm.GetText(i18n("M10870", "Ameliyatın Yapılamama Nedeni."), "", true, true);

                let result = await this.showSurgeryRejectForm(transDef);
                let _reason = result.Param as SurgeryRejectReason;

                if (result.Result === DialogResult.Cancel) {
                    // this.messageService.showInfo("İşlemden vazgeçildi");
                    throw new Exception("'Ameliyatın Yapılamama Nedenini' girmeden iptal edemezsiniz.");
                }
                else {
                    this._Surgery.SurgeryRejectReason = _reason;
                    this.surgeryFormViewModel.SurgeryRejectReasons.push(_reason);
                }

                // throw new Exception("ismail"); 

            }
            else if (transDef.ToStateDefID != null && (transDef.ToStateDefID.id != Surgery.SurgeryStates.Cancelled.id && transDef.ToStateDefID.id != Surgery.SurgeryStates.Rejected.id)) {

                let mainSurgeryList = this.surgeryFormViewModel.SurgeryProcedureFormViewModelList.filter(x => x._SurgeryProcedure.AyniFarkliKesi.ayniFarkliKesiKodu == "2" && x._SurgeryProcedure.CurrentStateDefID.id != SurgeryProcedure.SurgeryProcedureStates.Cancelled.id);
                if (mainSurgeryList.length == 0) {

                    throw new TTException("En Az 1 Ana Ameliyat Seçmek Zorunludur!");
                }
                if (mainSurgeryList.length > 1) {

                    throw new TTException("1'den fazla Ana Ameliyat Seçilemez!");
                }
                //en yüksek sut değerine sahip ameliyat işlemi bulunuyor.
                let maxSutPointSurgery = this.surgeryFormViewModel.SurgeryProcedureFormViewModelList.sort((a, b) => b._SurgeryProcedure.SutPoint - a._SurgeryProcedure.SutPoint)[0];
                //Ana ameliyat seçilen işlem en yüksek sut değerine sahip işlem değilse uyarı verilecek.
                if (this.surgeryFormViewModel.SurgeryProcedureFormViewModelList.filter(x => x._SurgeryProcedure.AyniFarkliKesi.ayniFarkliKesiKodu == "2" && x._SurgeryProcedure.ObjectID == maxSutPointSurgery._SurgeryProcedure.ObjectID).length == 0) {
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Ana Ameliyat Seçimi!", "En Yüksek Sut Puanına Sahip Ameliyatı Ana Ameliyat Olarak Seçmediniz!\r\nDevam etmek istiyor musunuz?");
                    if (messageResult === "E") {
                    } else {
                        throw new TTException("Ekranı kaydetmediniz! Gerekli işlemleri yaptıktan sonra kaydetmeyi unutmayınız!");
                    }
                }


                if (this._Surgery.SurgeryReport == null || this._Surgery.SurgeryReport == "" || CommonHelper.getInnerText(this._Surgery.SurgeryReport.toString()).length <= 0)
                    throw new TTException("Ameliyat Raporu giriniz!");
                if (this._Surgery.ProcedureDoctor == null)
                    throw new TTException(i18n("M22138", "Sorumlu cerrah bilgisini giriniz!"));
                if (this._Surgery.SurgeryRoom == null)
                    throw new Exception(i18n("M10839", "Ameliyat Salonu' Alanı boş olamaz"));
                if (this._Surgery.SurgeryDesk == null)
                    throw new Exception(i18n("M18682", "Masa' alanı boş geçilemez"));
                if (this._Surgery.SurgeryStartTime == null)
                    throw new Exception(i18n("M10858", "Ameliyatı Başlatma Tarih/ Saat' Alanı boş olamaz"));
                if (this._Surgery.SurgeryEndTime == null)
                    throw new Exception(i18n("M10860", "Ameliyatı Bitirme Tarih/ Saat' Alanı boş olamaz"));
                if (this._Surgery.SurgeryResult == null)
                    throw new Exception("Ameliyat Sonucu' Alanı boş olamaz");

                if (Convert.ToDateTime(this._Surgery.SurgeryEndTime) <= Convert.ToDateTime(this._Surgery.SurgeryStartTime))
                    throw new Exception(i18n("M10801", "Ameliyat Başlama Tarihi' , 'Ameliyat Bitiş Tarihinden' sonra olamaz."));
            }
        }
    }

    private AddHelpMenu() {
        let printInpatientTreatmentBarcode = new DynamicSidebarMenuItem();
        printInpatientTreatmentBarcode.key = 'printInpatientTreatmentBarcode';
        printInpatientTreatmentBarcode.icon = 'ai ai-barkod-bas';
        printInpatientTreatmentBarcode.label = 'Yatan Hasta Barkodu Bas';
        printInpatientTreatmentBarcode.componentInstance = this.helpMenuService;
        printInpatientTreatmentBarcode.clickFunction = this.helpMenuService.printInpatientTreatmentBarcode;
        printInpatientTreatmentBarcode.parameterFunctionInstance = this;
        printInpatientTreatmentBarcode.ParentInstance = this;
        printInpatientTreatmentBarcode.getParamsFunction = this.getClickFunctionParams;
        this.sideBarMenuService.addMenu('Barkod', printInpatientTreatmentBarcode);

        let printEpicrisisForm = new DynamicSidebarMenuItem();
        printEpicrisisForm.key = 'printEpicrisisForm';
        printEpicrisisForm.icon = 'fa fa-file-text-o';
        printEpicrisisForm.label = 'Epikriz Formu';
        printEpicrisisForm.componentInstance = this;
        printEpicrisisForm.clickFunction = this.printEpicrisisReport;
        printEpicrisisForm.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        printEpicrisisForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printEpicrisisForm);

        let pathologyRequest = new DynamicSidebarMenuItem();
        pathologyRequest.key = 'pathologyRequest';
        pathologyRequest.icon = 'ai ai-chemical';
        pathologyRequest.label = i18n("M20230", "Patoloji İstek");
        pathologyRequest.componentInstance = this.helpMenuService;
        pathologyRequest.clickFunction = this.helpMenuService.onPathologyRequest;
        pathologyRequest.parameterFunctionInstance = this;
        pathologyRequest.getParamsFunction = this.getClickFunctionParams;
        pathologyRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', pathologyRequest);

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

        let surgeryReport = new DynamicSidebarMenuItem();
        surgeryReport.key = 'surgeryReport';
        surgeryReport.icon = 'fa fa-print';
        surgeryReport.label = "Ameliyat Raporu";
        surgeryReport.componentInstance = this;
        surgeryReport.clickFunction = this.printSurgeryReport;
        this.sideBarMenuService.addMenu('ReportMainItem', surgeryReport);

        let checklist = new DynamicSidebarMenuItem();
        checklist.key = 'checklist';
        checklist.icon = 'fa fa-list-ol';
        checklist.label = "Güvenli Cerrahi Kontrol Listesi";
        checklist.componentInstance = this;
        checklist.clickFunction = this.openSafeSurgeryChecklists;
        this.sideBarMenuService.addMenu('YardimciMenu', checklist);
    }


    protected async PreScript(): Promise<void> {
        super.PreScript();
        for (let detailItem of this._Surgery.AllSurgeryPersonnels) {

            let personelindex = this.surgeryFormViewModel.SurgeryPersonneSpecilaityList.findIndex(dr => dr.userObjectId == detailItem.Personnel.ObjectID.toString());
            if (personelindex != -1) {
                detailItem["PersonnelSpeciality"] = this.surgeryFormViewModel.SurgeryPersonneSpecilaityList[personelindex].specilaityName;
            }
        }

        // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
        //if (this._Surgery.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(_Surgery.Episode) == true  && this.IsMedulaProvisionNecessaryProcedureExists() == true)
        //{
        //                if (this._Surgery.MedulaProvision == null)
        //                {
        //                    TTObjectContext context = new TTObjectContext(false);
        //                    MedulaProvision _medulaProvision = new MedulaProvision(context);
        //                    this._Surgery.SetMedulaProvisionInitalProperties(_medulaProvision);
        //                    this._Surgery.MedulaProvision = _medulaProvision;
        //                    context.Save();
        //                }
        //}
        //else
        //{
        //    this._Surgery.CreateSubEpisode = false;
        //    this.TabSubaction.HideTabPage(MedulaTakipBilgileriTabPage);
        //    this.TedaviTipiMedulaProvision.Required = false;
        //    this.TakipTipiMedulaProvision.Required = false;
        //    this.BransMedulaProvision.Required = false;
        //}
        this.DropStateButton(Surgery.SurgeryStates.Rejected);
        if (this.surgeryFormViewModel.HasUncompleteSubSurgery == false) {//Tüm Ek Ameliyatlar, Ek İşlemler ve Anestezi tamamlandıysa Tamam'e harici butonlar kalkmalı
            this.DropStateButton(Surgery.SurgeryStates.WaitingForSubSurgeries);
            this.DropStateButton(Surgery.SurgeryStates.Cancelled);
        }
        else {
            this.DropStateButton(Surgery.SurgeryStates.Completed); //Tüm Ek Ameliyatlar, Ek İşlemler ve Anestezi tamamlanmadıysa WaitingForSubSurgeries'e harici butonlar kalkmalı
        }

        this.ArrangeTriggers();
        this.hasRequestedProceduresForm = true;

        this.SelectedSurgeryProcedure.ReadOnly = this.ReadOnly;
        this.GridSurgeryPersonnels.ShowFilterCombo = !this.ReadOnly;
        this.GridSurgeryPersonnels.AllowUserToDeleteRows = !this.ReadOnly;
        this.DirectPurchaseGrids.ShowFilterCombo = !this.ReadOnly;
        this.DirectPurchaseGrids.AllowUserToDeleteRows = !this.ReadOnly;
        this.GridAnesthesiaPersonnels.ShowFilterCombo = !this.ReadOnly;
        this.GridAnesthesiaPersonnels.AllowUserToDeleteRows = !this.ReadOnly;

        if (this.surgeryFormViewModel.IsRequiredPathology == true) {
            TTVisual.InfoBox.Alert("Patoloji isteği gerektiren ameliyat hizmetiniz mevcut! Ameliyatın tamamlanması için lütfen ekranı önce 'Patoloji isteği' yapınız!");
        }
        this.resize(undefined);
    }

    @HostListener('window:resize', ['$event'])
    resize(event: Event) {
        if (this.ScrollPanel) {
            let rect: ClientRect = this.ScrollPanel['nativeElement'].getBoundingClientRect();
            let top = rect.top;

            let viewPortHeight: number = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
            this.ScrollPanel['nativeElement'].style.height = (viewPortHeight - (top + 17)).toString() + "px";
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef); // Tanı için Süperin Çağırılması zorunlu
        if (this._Surgery.SurgeryTemplate != null && this._Surgery.SurgeryTemplate == true) {
            if (transDef !== null) {
                let description: string = await TTVisual.InputForm.GetText(i18n("M22447", "Şablon İsmini Giriniz"));
                if (String.isNullOrEmpty(description) == false) {
                    this.surgeryFormViewModel.SurgeryTemplateDescription = description;
                }
                else TTVisual.InfoBox.Show(i18n("M22458", "Şablona isim vermeden kaydedemezsiniz."), MessageIconEnum.ErrorMessage);
            }
        }
        await this.load(SurgeryFormViewModel);
    }

    onSelectedSurgeryProcedureChanged(surgeryDefinition: any) {
        let that = this;
        let surgeryProcedureForm_DocumentUrl: string = '/api/SurgeryProcedureService/GetNewViewModelByProcedureObject';
        if (surgeryDefinition != null) {
            let getNewViewModelByProcedureObjectParameter: GetNewViewModelByProcedureObject = new GetNewViewModelByProcedureObject();
            getNewViewModelByProcedureObjectParameter.episodeAction = this._Surgery;
            getNewViewModelByProcedureObjectParameter.surgeryDefinition = surgeryDefinition.ObjectID;

            that.httpService.post<SurgeryProcedureFormViewModel>(surgeryProcedureForm_DocumentUrl, getNewViewModelByProcedureObjectParameter).then(newSurgeryProcedureFormViewModel => {
                if (newSurgeryProcedureFormViewModel != null) {
                    if (newSurgeryProcedureFormViewModel._SurgeryProcedure != null && newSurgeryProcedureFormViewModel._SurgeryProcedure.ProcedureObject != null)
                        that.surgeryFormViewModel.SurgeryProcedureFormViewModelList.unshift(newSurgeryProcedureFormViewModel);

                    if (newSurgeryProcedureFormViewModel.IsRequiredPathology == true) {
                        if (typeof that._Surgery.Episode === "string") {
                            that.helpMenuService.onPathologyRequest(new ClickFunctionParams(that, new ActiveIDsModel(that._EpisodeAction.ObjectID, that._Surgery.Episode, null)));
                        } else {
                            that.helpMenuService.onPathologyRequest(new ClickFunctionParams(that, new ActiveIDsModel(that._EpisodeAction.ObjectID, that._Surgery.Episode.ObjectID, null)));
                        }
                        that.surgeryFormViewModel.IsRequiredPathology = true;
                    }
                }
            });
        }
        window.setTimeout(t => {
            if (that.surgeryFormViewModel._selectedSurgeryProcedure === null) {
                that.surgeryFormViewModel._selectedSurgeryProcedure = new Object();
                that.surgeryFormViewModel._selectedSurgeryProcedure = undefined;
            }
            else
                that.surgeryFormViewModel._selectedSurgeryProcedure = null;
            that.detector.tick();
        }, 10);
    }

    //AMELİYATHANE  MASA YATAK

    private getObjectID(ttObject): string {
        if (ttObject == null)
            return null;
        if (typeof ttObject == "string") {
            return ttObject;
        }
        else
            return ttObject.ObjectID.toString();
    }

    private triggerLoadChildComboBoxBySurgeryDepartment(surgeryDepartment): void {

        if (surgeryDepartment != null) {
            this.SurgeryRoom.ListFilterExpression = " THIS.SURGERYDEPARTMENT= '" + surgeryDepartment.ObjectID.toString() + "'";
            if (this._Surgery.SurgeryRoom != null && (this._Surgery.SurgeryRoom.SurgeryDepartment == null || this.getObjectID(this._Surgery.SurgeryRoom.SurgeryDepartment) != surgeryDepartment.ObjectID))
                this._Surgery.SurgeryRoom = null;
        }
        else {
            this.SurgeryRoom.ListFilterExpression = " ";
            this._Surgery.SurgeryRoom = null;
        }


    }

    private triggerLoadChildComboBoxBySurgeryRoom(surgeryRoom): void {

        if (surgeryRoom != null) {
            this.SurgeryDesk.ListFilterExpression = " THIS.SURGERYROOM= '" + surgeryRoom.ObjectID.toString() + "'";
            if (this._Surgery.SurgeryDesk != null && (this._Surgery.SurgeryDesk.SurgeryRoom == null || this.getObjectID(this._Surgery.SurgeryDesk.SurgeryRoom) != surgeryRoom.ObjectID))
                this._Surgery.SurgeryDesk = null;

            if (this._Surgery.MasterResource == null || this._Surgery.MasterResource.ObjectID != surgeryRoom.SurgeryDepartment)
                this._Surgery.MasterResource = surgeryRoom.SurgeryDepartment;
        }
        else {
            this.SurgeryDesk.ListFilterExpression = " ";
            this._Surgery.SurgeryDesk = null;
        }
    }


    private triggerLoadChildComboBoxBySurgeryDesk(surgeryDesk): void {
        if (surgeryDesk != null) {
            if (this._Surgery.SurgeryRoom == null || this._Surgery.SurgeryRoom.ObjectID != surgeryDesk.SurgeryRoom)
                this._Surgery.SurgeryRoom = surgeryDesk.SurgeryRoom;
        }
    }

    protected ArrangeTriggers() {
        if (this._Surgery.MasterResource != null)
            this.triggerLoadChildComboBoxBySurgeryDepartment(this._Surgery.MasterResource);
        if (this._Surgery.SurgeryRoom != null)
            this.triggerLoadChildComboBoxBySurgeryRoom(this._Surgery.SurgeryRoom);

    }


    public printEpicrisisReport() {
        let selectedInpatientPhysicianApplication;
        let selectedDoctorParam;
        if (this.surgeryFormViewModel._Surgery.ProcedureDoctor != null) {
            if (this.surgeryFormViewModel.InpatientPhyAppObjectId != null) {
                selectedDoctorParam = new StringParam(this.surgeryFormViewModel._Surgery.ProcedureDoctor.ObjectID.toString());
                selectedInpatientPhysicianApplication = new StringParam(this.surgeryFormViewModel.InpatientPhyAppObjectId.toString());
                let reportParameters: any = { 'TTOBJECTID': selectedInpatientPhysicianApplication, 'Doctor': selectedDoctorParam };
                this.reportService.showReport("EpicrisisReportForPatient", reportParameters);
            } else {
                TTVisual.InfoBox.Alert("Epikriz Yazılacak Yatan Hasta İşlemi Bulunamadı!");
            }
        } else {
            TTVisual.InfoBox.Alert("Sorumlu Cerrah(1.Cerrah) Seçmeden Bu Raporu Yazdıramazsınız!");
        }

    }


    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;

        this.setPatientHistoryShown(this.surgeryFormViewModel._Surgery.ObjectID);
    }


    public setPatientHistoryShown(episodeActionId: Guid) {
        let that = this;
        that.httpService.get<any>("api/PatientHistoryService/SetPatientHistoryShown?episodeActionId=" + episodeActionId)
            .then(response => {
            })
            .catch(error => {
            });
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Surgery();
        this.surgeryFormViewModel = new SurgeryFormViewModel();
        this._ViewModel = this.surgeryFormViewModel;
        this.surgeryFormViewModel._Surgery = this._TTObject as Surgery;
        this.surgeryFormViewModel._Surgery.SurgeryResult = new SurgeryResultDefinition();
        this.surgeryFormViewModel._Surgery.SurgeryRobson = new SurgeryRobsonDefinition();
        this.surgeryFormViewModel._Surgery.Episode = new Episode();
        this.surgeryFormViewModel._Surgery.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.surgeryFormViewModel._Surgery.ProcedureDoctor = new ResUser();
        this.surgeryFormViewModel._Surgery.SurgeryRoom = new ResSurgeryRoom();
        this.surgeryFormViewModel._Surgery.AllSurgeryPersonnels = new Array<SurgeryPersonnel>();
        this.surgeryFormViewModel._Surgery.SurgeryExpends = new Array<SurgeryExpend>();
        this.surgeryFormViewModel._Surgery.DirectPurchaseGrids = new Array<DirectPurchaseGrid>();
        this.surgeryFormViewModel._Surgery.AnesthesiaAndReanimation = new AnesthesiaAndReanimation();
        this.surgeryFormViewModel._Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures = new Array<AnesthesiaProcedure>();
        this.surgeryFormViewModel._Surgery.AnesthesiaAndReanimation.AnesthesiaPersonnels = new Array<AnesthesiaPersonnel>();
        this.surgeryFormViewModel._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2 = new ResUser();
        this.surgeryFormViewModel._Surgery.AnesthesiaAndReanimation.ProcedureDoctor = new ResUser();
        this.surgeryFormViewModel._Surgery.MasterResource = new ResSection();
        this.surgeryFormViewModel._Surgery.SurgeryDesk = new ResSurgeryDesk();
        this.surgeryFormViewModel._Surgery.SurgeryRejectReason = new SurgeryRejectReason();
    }

    protected loadViewModel() {
        let that = this;

        that.surgeryFormViewModel = this._ViewModel as SurgeryFormViewModel;
        that._TTObject = this.surgeryFormViewModel._Surgery;
        if (this.surgeryFormViewModel == null)
            this.surgeryFormViewModel = new SurgeryFormViewModel();
        if (this.surgeryFormViewModel._Surgery == null)
            this.surgeryFormViewModel._Surgery = new Surgery();
        let surgeryResultObjectID = that.surgeryFormViewModel._Surgery["SurgeryResult"];
        if (surgeryResultObjectID != null && (typeof surgeryResultObjectID === "string")) {
            let surgeryResult = that.surgeryFormViewModel.SurgeryResultDefinitions.find(o => o.ObjectID.toString() === surgeryResultObjectID.toString());
            if (surgeryResult) {
                that.surgeryFormViewModel._Surgery.SurgeryResult = surgeryResult;
            }
        }
        let surgeryRobsonObjectID = that.surgeryFormViewModel._Surgery["SurgeryRobson"];
        if (surgeryRobsonObjectID != null && (typeof surgeryRobsonObjectID === "string")) {
            let surgeryRobson = that.surgeryFormViewModel.SurgeryRobsonDefinitions.find(o => o.ObjectID.toString() === surgeryRobsonObjectID.toString());
            if (surgeryRobson) {
                that.surgeryFormViewModel._Surgery.SurgeryRobson = surgeryRobson;
            }
        }
        let episodeObjectID = that.surgeryFormViewModel._Surgery["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.surgeryFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.surgeryFormViewModel._Surgery.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.surgeryFormViewModel.GridDiagnosisGridList;
                for (let detailItem of that.surgeryFormViewModel.GridDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.surgeryFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.surgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let procedureDoctorObjectID = that.surgeryFormViewModel._Surgery["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.surgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.surgeryFormViewModel._Surgery.ProcedureDoctor = procedureDoctor;
            }
        }
        let surgeryRoomObjectID = that.surgeryFormViewModel._Surgery["SurgeryRoom"];
        if (surgeryRoomObjectID != null && (typeof surgeryRoomObjectID === "string")) {
            let surgeryRoom = that.surgeryFormViewModel.ResSurgeryRooms.find(o => o.ObjectID.toString() === surgeryRoomObjectID.toString());
            if (surgeryRoom) {
                that.surgeryFormViewModel._Surgery.SurgeryRoom = surgeryRoom;
            }
        }

        let surgeryRejectObjectID = that.surgeryFormViewModel._Surgery["SurgeryRejectReason"];
        if (surgeryRejectObjectID != null && (typeof surgeryRejectObjectID === "string")) {
            let surgeryReject = that.surgeryFormViewModel.SurgeryRejectReasons.find(o => o.ObjectID.toString() === surgeryRejectObjectID.toString());
            if (surgeryReject) {
                that.surgeryFormViewModel._Surgery.SurgeryRejectReason = surgeryReject;
            }
        }
        that.surgeryFormViewModel._Surgery.AllSurgeryPersonnels = that.surgeryFormViewModel.GridSurgeryPersonnelsGridList;
        for (let detailItem of that.surgeryFormViewModel.GridSurgeryPersonnelsGridList) {
            let personnelObjectID = detailItem["Personnel"];
            if (personnelObjectID != null && (typeof personnelObjectID === "string")) {
                let personnel = that.surgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === personnelObjectID.toString());
                if (personnel) {
                    detailItem.Personnel = personnel;
                }
            }
        }
        that.surgeryFormViewModel._Surgery.SurgeryExpends = that.surgeryFormViewModel.GridSurgeryExpendsGridList;
        for (let detailItem of that.surgeryFormViewModel.GridSurgeryExpendsGridList) {
            let storeObjectID = detailItem["Store"];
            if (storeObjectID != null && (typeof storeObjectID === "string")) {
                let store = that.surgeryFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                if (store) {
                    detailItem.Store = store;
                }
            }
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.surgeryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.surgeryFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.surgeryFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.surgeryFormViewModel._Surgery.DirectPurchaseGrids = that.surgeryFormViewModel.DirectPurchaseGridsGridList;
        for (let detailItem of that.surgeryFormViewModel.DirectPurchaseGridsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.surgeryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }
        let anesthesiaAndReanimationObjectID = that.surgeryFormViewModel._Surgery["AnesthesiaAndReanimation"];
        if (anesthesiaAndReanimationObjectID != null && (typeof anesthesiaAndReanimationObjectID === "string")) {
            let anesthesiaAndReanimation = that.surgeryFormViewModel.AnesthesiaAndReanimations.find(o => o.ObjectID.toString() === anesthesiaAndReanimationObjectID.toString());
            if (anesthesiaAndReanimation) {
                that.surgeryFormViewModel._Surgery.AnesthesiaAndReanimation = anesthesiaAndReanimation;
            }
            if (anesthesiaAndReanimation != null) {
                anesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures = that.surgeryFormViewModel.GridAnesthesiaProceduresGridList;
                for (let detailItem of that.surgeryFormViewModel.GridAnesthesiaProceduresGridList) {
                    let procedureObjectObjectID = detailItem["ProcedureObject"];
                    if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                        let procedureObject = that.surgeryFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                        if (procedureObject) {
                            detailItem.ProcedureObject = procedureObject;
                        }
                    }
                    let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
                    if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                        let procedureDoctor = that.surgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                        if (procedureDoctor) {
                            detailItem.ProcedureDoctor = procedureDoctor;
                        }
                    }
                }
            }
            if (anesthesiaAndReanimation != null) {
                anesthesiaAndReanimation.AnesthesiaPersonnels = that.surgeryFormViewModel.GridAnesthesiaPersonnelsGridList;
                for (let detailItem of that.surgeryFormViewModel.GridAnesthesiaPersonnelsGridList) {
                    let anesthesiaPersonnelObjectID = detailItem["AnesthesiaPersonnel"];
                    if (anesthesiaPersonnelObjectID != null && (typeof anesthesiaPersonnelObjectID === "string")) {
                        let anesthesiaPersonnel = that.surgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === anesthesiaPersonnelObjectID.toString());
                        if (anesthesiaPersonnel) {
                            detailItem.AnesthesiaPersonnel = anesthesiaPersonnel;
                        }
                    }
                }
            }
            if (anesthesiaAndReanimation != null) {
                let procedureDoctor2ObjectID = anesthesiaAndReanimation["ProcedureDoctor2"];
                if (procedureDoctor2ObjectID != null && (typeof procedureDoctor2ObjectID === "string")) {
                    let procedureDoctor2 = that.surgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctor2ObjectID.toString());
                    if (procedureDoctor2) {
                        anesthesiaAndReanimation.ProcedureDoctor2 = procedureDoctor2;
                    }
                }
            }
            if (anesthesiaAndReanimation != null) {
                let procedureDoctorObjectID = anesthesiaAndReanimation["ProcedureDoctor"];
                if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                    let procedureDoctor = that.surgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                    if (procedureDoctor) {
                        anesthesiaAndReanimation.ProcedureDoctor = procedureDoctor;
                    }
                }
            }
        }
        let masterResourceObjectID = that.surgeryFormViewModel._Surgery["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.surgeryFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.surgeryFormViewModel._Surgery.MasterResource = masterResource;
            }
        }
        let surgeryDeskObjectID = that.surgeryFormViewModel._Surgery["SurgeryDesk"];
        if (surgeryDeskObjectID != null && (typeof surgeryDeskObjectID === "string")) {
            let surgeryDesk = that.surgeryFormViewModel.ResSurgeryDesks.find(o => o.ObjectID.toString() === surgeryDeskObjectID.toString());
            if (surgeryDesk) {
                that.surgeryFormViewModel._Surgery.SurgeryDesk = surgeryDesk;
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(SurgeryFormViewModel);
        this.AddHelpMenu();
    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

    }
    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('printInpatientTreatmentBarcode');
        this.sideBarMenuService.removeMenu('printEpicrisisForm');
        this.sideBarMenuService.removeMenu('pathologyRequest');
        this.sideBarMenuService.removeMenu('surgeryReport');
        this.sideBarMenuService.removeMenu('checklist');

    }




    public async onAnestesiaProcedureDoctor2Changed(event) {
        if (event != null) {
            if (this._Surgery != null &&
                this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2 != event) {
                this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2 = event;

                //if (this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime != null) {
                //    let a = await CommonService.PersonelIzinKontrol(this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2.ObjectID, this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime);
                //    if (a) {
                //        this.messageService.showInfo(this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                //        setTimeout(() => {
                //            this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2 = null;
                //        }, 500);

                //    }
                //}
            }
        }
    }

    public async onAnestesiaProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._Surgery != null &&
                this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor != event) {
                this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor = event;

                //if (this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime != null) {
                //    let a = await CommonService.PersonelIzinKontrol(this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor.ObjectID, this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime);
                //    if (a) {
                //        this.messageService.showInfo(this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                //        setTimeout(() => {
                //            this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor = null;
                //        }, 500);

                //    }
                //}
            }
        }
    }

    public onAnesthesiaReportChanged(event): void {
        if (event != null) {
            if (this._Surgery != null &&
                this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.AnesthesiaReport != event) {
                this._Surgery.AnesthesiaAndReanimation.AnesthesiaReport = event;
            }
        }
    }

    public onAnesteziTeknigiChanged(event): void {
        if (event != null) {
            if (this._Surgery != null &&
                this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.AnesthesiaTechnique != event) {
                this._Surgery.AnesthesiaAndReanimation.AnesthesiaTechnique = event;
            }
        }
    }

    public onAnesthesiaEndDateTimeChanged(event): void {
        if (event != null) {
            if (this._Surgery != null &&
                this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.AnesthesiaEndDateTime != event) {
                this._Surgery.AnesthesiaAndReanimation.AnesthesiaEndDateTime = event;
            }
        }
    }

    public async onAnesthesiaStartDateTimeChanged(event) {
        if (event != null) {
            if (this._Surgery != null &&
                this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime != event) {
                this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime = event;

                if (this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor.ObjectID, this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime);
                    if (a) {
                        this.messageService.showInfo(this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor = null;
                        }, 500);

                    }
                }

                if (this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2 != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2.ObjectID, this._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime);
                    if (a) {
                        this.messageService.showInfo(this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._Surgery.AnesthesiaAndReanimation.ProcedureDoctor2 = null;
                        }, 500);

                    }
                }
            }
        }
    }

    public onDescriptionToPreOpChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.DescriptionToPreOp != event) {
                this._Surgery.DescriptionToPreOp = event;
            }
        }
    }

    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.Emergency != event) {
                this._Surgery.Emergency = event;
            }
        }
    }

    public onPlannedSurgeryDateChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.PlannedSurgeryDate != event) {
                this._Surgery.PlannedSurgeryDate = event;
            }
        }
    }

    public onPlannedSurgeryDescriptionChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.PlannedSurgeryDescription != event) {
                this._Surgery.PlannedSurgeryDescription = event;
            }
        }
    }

    public onPreOpDescriptionsChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.PreOpDescriptions != event) {
                this._Surgery.PreOpDescriptions = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.ProcedureDoctor != event) {
                this._Surgery.ProcedureDoctor = event;

                let a = await CommonService.PersonelIzinKontrol(this._Surgery.ProcedureDoctor.ObjectID, this._Surgery.PlannedSurgeryDate);
                if (a) {
                    this.messageService.showInfo(this._Surgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._Surgery.ProcedureDoctor = null;
                    }, 500);

                }
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.ProtocolNo != event) {
                this._Surgery.ProtocolNo = event;
            }
        }
    }

    public onReasonOfRejectChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.ReasonOfReject != event) {
                this._Surgery.ReasonOfReject = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.RequestDate != event) {
                this._Surgery.RequestDate = event;
            }
        }
    }


    public onSurgeryEndTimeChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryEndTime != event) {
                this._Surgery.SurgeryEndTime = event;
            }
        }
    }

    public onSurgeryReportChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryReport != event) {
                this._Surgery.SurgeryReport = event;
            }
        }
    }

    public onSurgeryReportDateChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryReportDate != event) {
                this._Surgery.SurgeryReportDate = event;
            }
        }
    }

    public onSurgeryResultChanged(event): void {
        if (this._Surgery != null && this._Surgery.SurgeryResult != event) {
            this._Surgery.SurgeryResult = event;
        }
    }
    public onSurgeryRobsonChanged(event): void {
        if (this._Surgery != null && this._Surgery.SurgeryRobson != event) {
            this._Surgery.SurgeryRobson = event;
        }
    }

    public onSurgeryShiftChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryShift != event) {
                this._Surgery.SurgeryShift = event;
            }
        }
    }

    public onSurgeryPointGroupChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryPointGroup != event) {
                this._Surgery.SurgeryPointGroup = event;
            }
        }
    }

    public async onSurgeryStartTimeChanged(event) {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryStartTime != event) {
                this._Surgery.SurgeryStartTime = event;

                if (this._Surgery.ProcedureDoctor != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._Surgery.ProcedureDoctor.ObjectID, this._Surgery.SurgeryStartTime);
                    if (a) {
                        this.messageService.showInfo(this._Surgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._Surgery.ProcedureDoctor = null;
                        }, 500);

                    }
                }
            }
        }
    }

    public onSurgeryStatusChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryStatus != event) {
                this._Surgery.SurgeryStatus = event;
            }
        }
    }



    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.MasterResource != event) {
                this._Surgery.MasterResource = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryDepartment(event);
    }


    public onSurgeryRoomChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryRoom != event) {
                this._Surgery.SurgeryRoom = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryRoom(event);
    }
    public onSurgeryDeskChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryDesk != event) {
                this._Surgery.SurgeryDesk = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryDesk(event);
    }
    public onASATypeAnesthesiaAndReanimationChanged(event): void {
        if (this._Surgery != null &&
            this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.ASAType != event) {
            this._Surgery.AnesthesiaAndReanimation.ASAType = event;
        }
    }

    public onScarTypeAnesthesiaAndReanimationChanged(event): void {
        if (this._Surgery != null &&
            this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.ScarType != event) {
            this._Surgery.AnesthesiaAndReanimation.ScarType = event;
        }
    }

    public onASAScoreAnesthesiaAndReanimationChanged(event): void {
        if (this._Surgery != null &&
            this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.ASAScore != event) {
            this._Surgery.AnesthesiaAndReanimation.ASAScore = event;
        }
    }

    public onAnesthesiaReportDateAnesthesiaAndReanimationChanged(event): void {
        if (this._Surgery != null &&
            this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.AnesthesiaReportDate != event) {
            this._Surgery.AnesthesiaAndReanimation.AnesthesiaReportDate = event;
        }
    }

    public onLaparoscopyAnesthesiaAndReanimationChanged(event): void {
        if (this._Surgery != null &&
            this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.Laparoscopy != event) {
            this._Surgery.AnesthesiaAndReanimation.Laparoscopy = event;
        }
    }

    public onHasComplicationAnesthesiaAndReanimationChanged(event): void {
        if (this._Surgery != null &&
            this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.HasComplication != event) {
            this._Surgery.AnesthesiaAndReanimation.HasComplication = event;
        }
    }

    public onComplicationDescriptionAnesthesiaAndReanimationChanged(event): void {
        if (this._Surgery != null &&
            this._Surgery.AnesthesiaAndReanimation != null && this._Surgery.AnesthesiaAndReanimation.ComplicationDescription != event) {
            this._Surgery.AnesthesiaAndReanimation.ComplicationDescription = event;
        }
    }

    public comfirmAddRowByPersonelFilterSelection(event) {
        if (event != null) {
            if (event.ObjectID) {
                if (this.surgeryFormViewModel._Surgery.AllSurgeryPersonnels.findIndex(dr => dr.Personnel != null && dr.Personnel.ObjectID == event.ObjectID && dr.EntityState != EntityStateEnum.Deleted) != -1) {
                    this.messageService.showError("Bu personel zaten ekli");
                    return false;
                }

                let that = this;
                let tempData = event;
                if (that._Surgery.SurgeryStartTime == null) {
                    this.messageService.showInfo("Lütfen personel eklemeden önce ameliyat başlangıç tarihini seçiniz.");
                    return false;
                }

                CommonService.PersonelIzinKontrol(event.ObjectID, that._Surgery.SurgeryStartTime).then(a => {
                    if (a) {
                        this.messageService.showInfo(event.Name + " isimli personel izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            // alert("iso")
                        }, 500);
                    }
                    else {
                        that.gridSurgeryPersonnelsMain.gridInstance.instance.addRow()
                        that.gridSurgeryPersonnelsMain.gridInstance.instance.saveEditData();
                    }

                });

                return false;
            }
        }
        else
            return true;
    }

    public comfirmAddRowByPersonelAnesthesisFilterSelection(event) {
        if (event != null) {
            if (event.ObjectID) {
                if (this.surgeryFormViewModel._Surgery.AnesthesiaAndReanimation.AnesthesiaPersonnels.findIndex(dr => dr.AnesthesiaPersonnel != null && dr.AnesthesiaPersonnel.ObjectID == event.ObjectID && dr.EntityState != EntityStateEnum.Deleted) != -1) {
                    this.messageService.showError("Bu personel zaten ekli");
                    return false;
                }

                let that = this;
                let tempData = event;
                //if (that._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime == null) {
                //    this.messageService.showInfo("Lütfen personel eklemeden önce anestezi başlangıç tarihini seçiniz.");
                //    return false;
                //}

                //CommonService.PersonelIzinKontrol(event.ObjectID, that._Surgery.AnesthesiaAndReanimation.AnesthesiaStartDateTime).then(a => {
                //    if (a) {
                //        this.messageService.showInfo(event.Name + " isimli personel izinli olduğu için seçim yapamazsınız.");
                //        setTimeout(() => {
                //            // alert("iso")
                //        }, 500);
                //    }
                //    else {
                //        that.gridAnesthesisSurgeryPersonnels.gridInstance.instance.addRow()
                //        that.gridAnesthesisSurgeryPersonnels.gridInstance.instance.saveEditData();
                //    }

                //});

                return false;
            }
        }
        else
            return true;
    }

    public personnelSelectedFilterChanged(event) {
        if (event != null) {
            if (event.Personnel && event.Personnel.ObjectID) {
                let that = this;
                let personelindex = that.surgeryFormViewModel.SurgeryPersonneSpecilaityList.findIndex(dr => dr.userObjectId == event.Personnel.ObjectID);
                if (personelindex != -1) {
                    event["PersonnelSpeciality"] = that.surgeryFormViewModel.SurgeryPersonneSpecilaityList[personelindex].specilaityName;
                }
                else {
                    this.httpService.get<string>("/api/SurgeryService/GetSpecialityOfUser?UserObjectID=" + event.Personnel.ObjectID)
                        .then(result => {
                            let surgeryPersonel = that._Surgery.AllSurgeryPersonnels.find(dr => dr.Personnel.ObjectID == event.Personnel.ObjectID);
                            surgeryPersonel["PersonnelSpeciality"] = result;
                            let surgeryPersonneSpecilaity = new SurgeryPersonneSpecilaity();
                            surgeryPersonneSpecilaity.userObjectId = event.Personnel.ObjectID;
                            surgeryPersonneSpecilaity.specilaityName = result;
                            this.surgeryFormViewModel.SurgeryPersonneSpecilaityList.unshift(surgeryPersonneSpecilaity);
                        })
                        .catch(error => {
                            console.log(error);
                        });
                }
            }
        }
    }
    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.PlannedSurgeryDate, "Value", this.__ttObject, "PlannedSurgeryDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.SurgeryStartTime, "Value", this.__ttObject, "SurgeryStartTime");
        redirectProperty(this.SurgeryEndTime, "Value", this.__ttObject, "SurgeryEndTime");
        redirectProperty(this.PlannedSurgeryDescription, "Text", this.__ttObject, "PlannedSurgeryDescription");
        redirectProperty(this.SurgeryReportDate, "Value", this.__ttObject, "SurgeryReportDate");
        redirectProperty(this.SurgeryReport, "Rtf", this.__ttObject, "SurgeryReport");
        redirectProperty(this.DescriptionToPreOp, "Rtf", this.__ttObject, "DescriptionToPreOp");
        redirectProperty(this.PreOpDescriptions, "Rtf", this.__ttObject, "PreOpDescriptions");
        redirectProperty(this.AnesthesiaStartDateTime, "Value", this.__ttObject, "AnesthesiaAndReanimation.AnesthesiaStartDateTime");
        redirectProperty(this.AnesthesiaEndDateTime, "Value", this.__ttObject, "AnesthesiaAndReanimation.AnesthesiaEndDateTime");
        redirectProperty(this.AnesthesiaReport, "Rtf", this.__ttObject, "AnesthesiaAndReanimation.AnesthesiaReport");
        redirectProperty(this.AnesteziTeknigi, "Value", this.__ttObject, "AnesthesiaAndReanimation.AnesthesiaTechnique");
        redirectProperty(this.ASATypeAnesthesiaAndReanimation, "Value", this.__ttObject, "AnesthesiaAndReanimation.ASAType");
        redirectProperty(this.SurgeryShift, "Value", this.__ttObject, "SurgeryShift");
        redirectProperty(this.SurgeryPointGroup, "Value", this.__ttObject, "SurgeryPointGroup");
        redirectProperty(this.SurgeryStatus, "Value", this.__ttObject, "SurgeryStatus");
        redirectProperty(this.ReasonOfReject, "Rtf", this.__ttObject, "ReasonOfReject");
        redirectProperty(this.ScarTypeAnesthesiaAndReanimation, "Value", this.__ttObject, "AnesthesiaAndReanimation.ScarType");
        redirectProperty(this.ASAScoreAnesthesiaAndReanimation, "Value", this.__ttObject, "AnesthesiaAndReanimation.ASAScore");
        redirectProperty(this.AnesthesiaReportDateAnesthesiaAndReanimation, "Value", this.__ttObject, "AnesthesiaAndReanimation.AnesthesiaReportDate");
        redirectProperty(this.LaparoscopyAnesthesiaAndReanimation, "Value", this.__ttObject, "AnesthesiaAndReanimation.Laparoscopy");
        redirectProperty(this.HasComplicationAnesthesiaAndReanimation, "Value", this.__ttObject, "AnesthesiaAndReanimation.HasComplication");
        redirectProperty(this.ComplicationDescriptionAnesthesiaAndReanimation, "Text", this.__ttObject, "AnesthesiaAndReanimation.ComplicationDescription");
    }

    public initFormControls(): void {


        this.ScarTypeAnesthesiaAndReanimation = new TTVisual.TTEnumComboBox();
        this.ScarTypeAnesthesiaAndReanimation.DataTypeName = "AnesthesiaScarEnum";
        this.ScarTypeAnesthesiaAndReanimation.BackColor = "#F0F0F0";
        this.ScarTypeAnesthesiaAndReanimation.Enabled = false;
        this.ScarTypeAnesthesiaAndReanimation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ScarTypeAnesthesiaAndReanimation.Name = "ScarTypeAnesthesiaAndReanimation";
        this.ScarTypeAnesthesiaAndReanimation.TabIndex = 130;

        this.ASAScoreAnesthesiaAndReanimation = new TTVisual.TTEnumComboBox();
        this.ASAScoreAnesthesiaAndReanimation.DataTypeName = "AnesthesiaASAScoreEnum";
        this.ASAScoreAnesthesiaAndReanimation.BackColor = "#F0F0F0";
        this.ASAScoreAnesthesiaAndReanimation.Enabled = false;
        this.ASAScoreAnesthesiaAndReanimation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ASAScoreAnesthesiaAndReanimation.Name = "ASAScoreAnesthesiaAndReanimation";
        this.ASAScoreAnesthesiaAndReanimation.TabIndex = 128;

        this.AnesthesiaReportDateAnesthesiaAndReanimation = new TTVisual.TTDateTimePicker();
        this.AnesthesiaReportDateAnesthesiaAndReanimation.BackColor = "#F0F0F0";
        this.AnesthesiaReportDateAnesthesiaAndReanimation.Format = DateTimePickerFormat.Long;
        this.AnesthesiaReportDateAnesthesiaAndReanimation.Enabled = false;
        this.AnesthesiaReportDateAnesthesiaAndReanimation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaReportDateAnesthesiaAndReanimation.Name = "AnesthesiaReportDateAnesthesiaAndReanimation";
        this.AnesthesiaReportDateAnesthesiaAndReanimation.TabIndex = 124;

        this.LaparoscopyAnesthesiaAndReanimation = new TTVisual.TTEnumComboBox();
        this.LaparoscopyAnesthesiaAndReanimation.DataTypeName = "";
        this.LaparoscopyAnesthesiaAndReanimation.BackColor = "#F0F0F0";
        this.LaparoscopyAnesthesiaAndReanimation.Enabled = false;
        this.LaparoscopyAnesthesiaAndReanimation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LaparoscopyAnesthesiaAndReanimation.Name = "LaparoscopyAnesthesiaAndReanimation";
        this.LaparoscopyAnesthesiaAndReanimation.TabIndex = 135;

        this.HasComplicationAnesthesiaAndReanimation = new TTVisual.TTCheckBox();
        this.HasComplicationAnesthesiaAndReanimation.Value = false;
        this.HasComplicationAnesthesiaAndReanimation.Text = "Anestezi Komplikasyonu Var";
        this.HasComplicationAnesthesiaAndReanimation.Title = "Anestezi Komplikasyonu Var";
        this.HasComplicationAnesthesiaAndReanimation.Enabled = false;
        this.HasComplicationAnesthesiaAndReanimation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.HasComplicationAnesthesiaAndReanimation.Name = "HasComplicationAnesthesiaAndReanimation";
        this.HasComplicationAnesthesiaAndReanimation.TabIndex = 134;

        this.ComplicationDescriptionAnesthesiaAndReanimation = new TTVisual.TTTextBox();
        this.ComplicationDescriptionAnesthesiaAndReanimation.BackColor = "#F0F0F0";
        this.ComplicationDescriptionAnesthesiaAndReanimation.ReadOnly = true;
        this.ComplicationDescriptionAnesthesiaAndReanimation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ComplicationDescriptionAnesthesiaAndReanimation.Name = "ComplicationDescriptionAnesthesiaAndReanimation";
        this.ComplicationDescriptionAnesthesiaAndReanimation.TabIndex = 132;

        this.SurgeryResult = new TTVisual.TTObjectListBox();
        this.SurgeryResult.ListDefName = "SurgeryResultDefList";
        this.SurgeryResult.Name = "SurgeryResult";
        this.SurgeryResult.TabIndex = 131;

        this.SurgeryRobson = new TTVisual.TTObjectListBox();
        this.SurgeryRobson.ListDefName = "SurgeryRobsonDefinitionList";
        this.SurgeryRobson.Name = "SurgeryRobson";
        this.SurgeryRobson.TabIndex = 131;

        this.ASATypeAnesthesiaAndReanimation = new TTVisual.TTEnumComboBox();
        this.ASATypeAnesthesiaAndReanimation.DataTypeName = "AnesthesiaASATypeEnum";
        this.ASATypeAnesthesiaAndReanimation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ASATypeAnesthesiaAndReanimation.Name = "ASATypeAnesthesiaAndReanimation";
        this.ASATypeAnesthesiaAndReanimation.Enabled = false;
        this.ASATypeAnesthesiaAndReanimation.TabIndex = 122;

        this.labelSurgeryStatus = new TTVisual.TTLabel();
        this.labelSurgeryStatus.Text = "Ameliyat Durumu";
        this.labelSurgeryStatus.Name = "labelSurgeryStatus";
        this.labelSurgeryStatus.TabIndex = 130;

        this.SurgeryStatus = new TTVisual.TTEnumComboBox();
        this.SurgeryStatus.DataTypeName = "SurgeryStatusEnum";
        this.SurgeryStatus.Name = "SurgeryStatus";
        this.SurgeryStatus.TabIndex = 129;

        this.labelSurgeryShift = new TTVisual.TTLabel();
        this.labelSurgeryShift.Text = "Mesai Durumu";
        this.labelSurgeryShift.Name = "labelSurgeryShift";
        this.labelSurgeryShift.TabIndex = 128;

        this.SurgeryShift = new TTVisual.TTEnumComboBox();
        this.SurgeryShift.DataTypeName = "SurgeryShiftEnum";
        this.SurgeryShift.Name = "SurgeryShift";
        this.SurgeryShift.TabIndex = 127;

        this.labelSurgeryPointGroup = new TTVisual.TTLabel();
        this.labelSurgeryPointGroup.Text = "Ameliyat Tipi";
        this.labelSurgeryPointGroup.Name = "labelSurgeryPointGroup";
        this.labelSurgeryPointGroup.TabIndex = 128;

        this.SurgeryPointGroup = new TTVisual.TTEnumComboBox();
        this.SurgeryPointGroup.DataTypeName = "SurgeryPointGroupEnum";
        this.SurgeryPointGroup.Name = "SurgeryPointGroup";
        this.SurgeryPointGroup.TabIndex = 127;

        this.SelectedSurgeryProcedure = new TTVisual.TTObjectListBox();
        this.SelectedSurgeryProcedure.ListDefName = "SurgeryListDefinition";
        this.SelectedSurgeryProcedure.Name = "SelectedSurgeryProcedure";
        this.SelectedSurgeryProcedure.AutoCompleteDialogWidth = "40%";
        this.SelectedSurgeryProcedure.ReadOnly = this.ReadOnly;




        this.labelReasonOfReject = new TTVisual.TTLabel();
        this.labelReasonOfReject.Text = i18n("M10869", "Ameliyatın Yapılamama Nedeni");
        this.labelReasonOfReject.Name = "labelReasonOfReject";
        this.labelReasonOfReject.TabIndex = 126;

        this.ReasonOfReject = new TTVisual.TTRichTextBoxControl();
        this.ReasonOfReject.Name = "ReasonOfReject";
        this.ReasonOfReject.TabIndex = 125;
        this.ReasonOfReject.ReadOnly = true;

        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.ReadOnly = true;
        this.GridDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.TabIndex = 6;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisListDefinition";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = i18n("M24028", "Vaka Tanıları");
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 275;

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
        this.EpisodeIsMainDiagnose.Width = 75;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

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

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 88;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M22140", "Sorumlu Cerrah(1.Cerrah)");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 121;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 2;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Short;
        this.RequestDate.ReadOnly = true;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M10816", "Ameliyat İstek Tarihi");
        this.labelRequestDate.BackColor = "#DCDCDC";
        this.labelRequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRequestDate.ForeColor = "#000000";
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 119;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M20395", "Planlanan Ameliyat Tarihi");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 117;

        this.PlannedSurgeryDate = new TTVisual.TTDateTimePicker();
        this.PlannedSurgeryDate.CustomFormat = "";
        this.PlannedSurgeryDate.Format = DateTimePickerFormat.Short;
        this.PlannedSurgeryDate.Name = "PlannedSurgeryDate";
        this.PlannedSurgeryDate.TabIndex = 1;

        this.labelSurgeryEndTime = new TTVisual.TTLabel();
        this.labelSurgeryEndTime.Text = i18n("M10861", "Ameliyatı Bitirme Tarih/Saat");
        this.labelSurgeryEndTime.BackColor = "#DCDCDC";
        this.labelSurgeryEndTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurgeryEndTime.ForeColor = "#000000";
        this.labelSurgeryEndTime.Name = "labelSurgeryEndTime";
        this.labelSurgeryEndTime.TabIndex = 100;

        this.SurgeryEndTime = new TTVisual.TTDateTimePicker();
        this.SurgeryEndTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SurgeryEndTime.Format = DateTimePickerFormat.Long;
        this.SurgeryEndTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryEndTime.Name = "SurgeryEndTime";
        this.SurgeryEndTime.TabIndex = 8;

        this.SurgeryRoom = new TTVisual.TTObjectListBox();
        this.SurgeryRoom.LinkedControlName = "MasterResource";
        this.SurgeryRoom.ListDefName = "SurgeryRoomListDefinition";
        this.SurgeryRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryRoom.Name = "SurgeryRoom";
        this.SurgeryRoom.TabIndex = 5;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Title = i18n("M27300", "Acil");
        this.Emergency.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 89;

        this.labelSurgeryStartTime = new TTVisual.TTLabel();
        this.labelSurgeryStartTime.Text = i18n("M10859", "Ameliyatı Başlatma Tarih/Saat");
        this.labelSurgeryStartTime.BackColor = "#DCDCDC";
        this.labelSurgeryStartTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurgeryStartTime.ForeColor = "#000000";
        this.labelSurgeryStartTime.Name = "labelSurgeryStartTime";
        this.labelSurgeryStartTime.TabIndex = 92;

        this.SurgeryStartTime = new TTVisual.TTDateTimePicker();
        this.SurgeryStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SurgeryStartTime.Format = DateTimePickerFormat.Long;
        this.SurgeryStartTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryStartTime.Name = "SurgeryStartTime";
        this.SurgeryStartTime.TabIndex = 7;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10854", "Ameliyathane");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 95;

        this.labelRoom = new TTVisual.TTLabel();
        this.labelRoom.Text = i18n("M21284", "Salon");
        this.labelRoom.BackColor = "#DCDCDC";
        this.labelRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoom.ForeColor = "#000000";
        this.labelRoom.Name = "labelRoom";
        this.labelRoom.TabIndex = 84;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 91;

        this.TabOperative = new TTVisual.TTTabControl();
        this.TabOperative.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabOperative.Name = "TabOperative";
        this.TabOperative.TabIndex = 9;

        this.SurgeryInfo = new TTVisual.TTTabPage();
        this.SurgeryInfo.DisplayIndex = 0;
        this.SurgeryInfo.BackColor = "#FFFFFF";
        this.SurgeryInfo.TabIndex = 0;
        this.SurgeryInfo.Text = i18n("M10802", "Ameliyat Bilgileri");
        this.SurgeryInfo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryInfo.Name = "SurgeryInfo";

        this.SurgeryReport = new TTVisual.TTRichTextBoxControl();
        this.SurgeryReport.DisplayText = i18n("M10837", "Ameliyat Raporu");
        this.SurgeryReport.TemplateGroupName = "SURGERYREPORT";
        this.SurgeryReport.BackColor = "#FFFFFF";
        this.SurgeryReport.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryReport.Name = "SurgeryReport";
        this.SurgeryReport.TabIndex = 92;

        this.SurgeryReportDate = new TTVisual.TTDateTimePicker();
        this.SurgeryReportDate.CustomFormat = "";
        this.SurgeryReportDate.Format = DateTimePickerFormat.Long;
        this.SurgeryReportDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryReportDate.Name = "SurgeryReportDate";
        this.SurgeryReportDate.TabIndex = 118;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M10836", "Ameliyat Rapor Tarihi");
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 119;

        this.Ameliyat = new TTVisual.TTTabControl();
        this.Ameliyat.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Ameliyat.Name = "Ameliyat";
        this.Ameliyat.TabIndex = 10;

        this.MainSurgeryProcedures = new TTVisual.TTTabPage();
        this.MainSurgeryProcedures.DisplayIndex = 0;
        this.MainSurgeryProcedures.BackColor = "#FFFFFF";
        this.MainSurgeryProcedures.TabIndex = 1;
        this.MainSurgeryProcedures.Text = i18n("M10871", "Ameliyatlar");
        this.MainSurgeryProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MainSurgeryProcedures.Name = "MainSurgeryProcedures";

        this.SurgeryProcedures = new TTVisual.TTTabPage();
        this.SurgeryProcedures.DisplayIndex = 1;
        this.SurgeryProcedures.BackColor = "#FFFFFF";
        this.SurgeryProcedures.TabIndex = 0;
        this.SurgeryProcedures.Text = i18n("M17354", "Katılan Birimlere Ait Ameliyatlar");
        this.SurgeryProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryProcedures.Name = "SurgeryProcedures";

        this.SurgeryTeam = new TTVisual.TTTabPage();
        this.SurgeryTeam.DisplayIndex = 2;
        this.SurgeryTeam.BackColor = "#FFFFFF";
        this.SurgeryTeam.TabIndex = 0;
        this.SurgeryTeam.Text = i18n("M12206", "Cerrahi Ekip");
        this.SurgeryTeam.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryTeam.Name = "SurgeryTeam";

        this.GridSurgeryPersonnels = new TTVisual.TTGrid();
        this.GridSurgeryPersonnels.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridSurgeryPersonnels.Name = "GridSurgeryPersonnels";
        this.GridSurgeryPersonnels.TabIndex = 0;
        this.GridSurgeryPersonnels.Height = 110;
        this.GridSurgeryPersonnels.ShowFilterCombo = !this.ReadOnly;
        this.GridSurgeryPersonnels.FilterColumnName = "SurgeryPersonnel";
        this.GridSurgeryPersonnels.FilterLabel = i18n("M12206", "Cerrahi Ekip");
        this.GridSurgeryPersonnels.Filter = { ListDefName: "SurgeryTeamListDefinition" };
        this.GridSurgeryPersonnels.AllowUserToAddRows = false;
        this.GridSurgeryPersonnels.AllowUserToDeleteRows = !this.ReadOnly;
        this.GridSurgeryPersonnels.DeleteButtonWidth = "7%";
        this.GridSurgeryPersonnels.ShowTotalNumberOfRows = false;
        this.GridSurgeryPersonnels.IsFilterLabelSingleLine = false;

        this.SurgeryPersonnel = new TTVisual.TTListBoxColumn();
        this.SurgeryPersonnel.ListDefName = "SurgeryTeamListDefinition";
        this.SurgeryPersonnel.DataMember = "Personnel";
        this.SurgeryPersonnel.DisplayIndex = 0;
        this.SurgeryPersonnel.HeaderText = i18n("M12206", "Cerrahi Ekip");
        this.SurgeryPersonnel.Name = "SurgeryPersonnel";
        this.SurgeryPersonnel.Width = "50%";

        this.SurgeryPersonnelSpeciality = new TTVisual.TTTextBoxColumn();
        this.SurgeryPersonnelSpeciality.DataMember = "PersonnelSpeciality";
        this.SurgeryPersonnelSpeciality.DisplayIndex = 0;
        this.SurgeryPersonnelSpeciality.HeaderText = i18n("M27149", "Uzmanlık Dalı");
        this.SurgeryPersonnelSpeciality.Name = "PersonnelSpeciality";
        this.SurgeryPersonnelSpeciality.Width = "40%";
        this.SurgeryPersonnelSpeciality.ReadOnly = true;


        this.CARole = new TTVisual.TTEnumComboBoxColumn();
        this.CARole.DataTypeName = "SurgeryRoleEnum";
        this.CARole.DataMember = "Role";
        this.CARole.DisplayIndex = 1;
        this.CARole.HeaderText = i18n("M27329", "Görevi");
        this.CARole.Name = "CARole";
        this.CARole.Width = "33%";

        this.SurgeryExpend = new TTVisual.TTTabPage();
        this.SurgeryExpend.DisplayIndex = 3;
        this.SurgeryExpend.BackColor = "#FFFFFF";
        this.SurgeryExpend.TabIndex = 0;
        this.SurgeryExpend.Text = i18n("M12207", "Cerrahi Sarf");
        this.SurgeryExpend.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryExpend.Name = "SurgeryExpend";

        this.GridSurgeryExpends = new TTVisual.TTGrid();
        this.GridSurgeryExpends.AllowUserToDeleteRows = false;
        this.GridSurgeryExpends.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridSurgeryExpends.Name = "GridSurgeryExpends";
        this.GridSurgeryExpends.TabIndex = 0;

        this.ttdatetimepickercolumn1 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn1.DataMember = "ActionDate";
        this.ttdatetimepickercolumn1.DisplayIndex = 0;
        this.ttdatetimepickercolumn1.HeaderText = "Tarih/Saat";
        this.ttdatetimepickercolumn1.Name = "ttdatetimepickercolumn1";
        this.ttdatetimepickercolumn1.Width = 150;

        this.CAStore = new TTVisual.TTListBoxColumn();
        this.CAStore.AllowMultiSelect = true;
        this.CAStore.ListDefName = "StoreListDefinition";
        this.CAStore.DataMember = "Store";
        this.CAStore.ForceLinkedParentSelection = true;
        this.CAStore.DisplayIndex = 1;
        this.CAStore.HeaderText = i18n("M12615", "Depo");
        this.CAStore.Name = "CAStore";
        this.CAStore.Width = 200;

        this.CAMaterial = new TTVisual.TTListBoxColumn();
        this.CAMaterial.AllowMultiSelect = true;
        this.CAMaterial.ListDefName = "ConsumableMaterialAndDrugList";
        this.CAMaterial.DataMember = "Material";
        this.CAMaterial.ForceLinkedParentSelection = true;
        this.CAMaterial.DisplayIndex = 2;
        this.CAMaterial.HeaderText = i18n("M12207", "Cerrahi Sarf");
        this.CAMaterial.Name = "CAMaterial";
        this.CAMaterial.Width = 380;

        this.tttextboxcolumn1 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn1.DataMember = "Barcode";
        this.tttextboxcolumn1.DisplayIndex = 3;
        this.tttextboxcolumn1.HeaderText = "Barkodu";
        this.tttextboxcolumn1.Name = "tttextboxcolumn1";
        this.tttextboxcolumn1.ReadOnly = true;
        this.tttextboxcolumn1.Width = 100;

        this.tttextboxcolumn2 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn2.DataMember = "Amount";
        this.tttextboxcolumn2.DisplayIndex = 4;
        this.tttextboxcolumn2.HeaderText = i18n("M19030", "Miktar");
        this.tttextboxcolumn2.Name = "tttextboxcolumn2";
        this.tttextboxcolumn2.Width = 100;

        this.DonorID = new TTVisual.TTTextBoxColumn();
        this.DonorID.DataMember = "DonorID";
        this.DonorID.DisplayIndex = 5;
        this.DonorID.HeaderText = i18n("M13332", "Dönor ID");
        this.DonorID.Name = "DonorID";
        this.DonorID.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 6;
        this.DistributionType.HeaderText = "";
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.DirectPurchase = new TTVisual.TTTabPage();
        this.DirectPurchase.DisplayIndex = 4;
        this.DirectPurchase.TabIndex = 2;
        this.DirectPurchase.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.DirectPurchase.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DirectPurchase.Name = "DirectPurchase";

        this.DirectPurchaseGrids = new TTVisual.TTGrid();
        this.DirectPurchaseGrids.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DirectPurchaseGrids.Name = "DirectPurchaseGrids";
        this.DirectPurchaseGrids.TabIndex = 124;
        this.DirectPurchaseGrids.ShowFilterCombo = !this.ReadOnly;
        this.DirectPurchaseGrids.FilterColumnName = "MaterialDirectPurchaseGrid";
        this.DirectPurchaseGrids.FilterLabel = i18n("M18545", "Malzeme");
        this.DirectPurchaseGrids.Filter = { ListDefName: "MaterialListDefinition" };
        this.DirectPurchaseGrids.AllowUserToAddRows = false;
        this.DirectPurchaseGrids.AllowUserToDeleteRows = !this.ReadOnly;
        this.DirectPurchaseGrids.DeleteButtonWidth = "5%";
        this.DirectPurchaseGrids.ShowTotalNumberOfRows = false;
        this.DirectPurchaseGrids.IsFilterLabelSingleLine = false;
        this.DirectPurchaseGrids.ReadOnly = this.ReadOnly;


        this.MaterialDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.MaterialDirectPurchaseGrid.ListDefName = "MaterialListDefinition";
        this.MaterialDirectPurchaseGrid.DataMember = "Material";
        this.MaterialDirectPurchaseGrid.DisplayIndex = 0;
        this.MaterialDirectPurchaseGrid.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialDirectPurchaseGrid.Name = "MaterialDirectPurchaseGrid";
        this.MaterialDirectPurchaseGrid.Width = "75%";
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogWidth = '75%';
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogHeight = '50%';

        this.AmountDirectPurchaseGrid = new TTVisual.TTTextBoxColumn();
        this.AmountDirectPurchaseGrid.DataMember = "Amount";
        this.AmountDirectPurchaseGrid.DisplayIndex = 1;
        this.AmountDirectPurchaseGrid.HeaderText = i18n("M19030", "Miktar");
        this.AmountDirectPurchaseGrid.Name = "AmountDirectPurchaseGrid";
        this.AmountDirectPurchaseGrid.Width = "10%";

        this.PreOperativeInfo = new TTVisual.TTTabPage();
        this.PreOperativeInfo.DisplayIndex = 1;
        this.PreOperativeInfo.BackColor = "#FFFFFF";
        this.PreOperativeInfo.TabIndex = 0;
        this.PreOperativeInfo.Text = i18n("M19973", "Ön Hazırlık Bilgileri");
        this.PreOperativeInfo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PreOperativeInfo.Name = "PreOperativeInfo";

        this.DescriptionToPreOp = new TTVisual.TTRichTextBoxControl();
        this.DescriptionToPreOp.DisplayText = i18n("M19974", "Ön Hazırlık İçin Direktifler");
        this.DescriptionToPreOp.BackColor = "#FFFFFF";
        this.DescriptionToPreOp.Name = "DescriptionToPreOp";
        this.DescriptionToPreOp.TabIndex = 0;

        this.PreOpDescriptions = new TTVisual.TTRichTextBoxControl();
        this.PreOpDescriptions.DisplayText = i18n("M19972", "Ön Hazırlık Açıklamaları");
        this.PreOpDescriptions.BackColor = "#FFFFFF";
        this.PreOpDescriptions.Name = "PreOpDescriptions";
        this.PreOpDescriptions.TabIndex = 118;

        this.AnesthesiaInfo = new TTVisual.TTTabPage();
        this.AnesthesiaInfo.DisplayIndex = 2;
        this.AnesthesiaInfo.TabIndex = 1;
        this.AnesthesiaInfo.Text = i18n("M10981", "Anestezi İşlemleri");
        this.AnesthesiaInfo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaInfo.Name = "AnesthesiaInfo";

        this.labelAnesthesiaEndDateTime = new TTVisual.TTLabel();
        this.labelAnesthesiaEndDateTime.Text = i18n("M10962", "Anestezi Bitiş Tarihi");
        this.labelAnesthesiaEndDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelAnesthesiaEndDateTime.ForeColor = "#000000";
        this.labelAnesthesiaEndDateTime.Name = "labelAnesthesiaEndDateTime";
        this.labelAnesthesiaEndDateTime.TabIndex = 31;

        this.AnesthesiaReport = new TTVisual.TTRichTextBoxControl();
        this.AnesthesiaReport.DisplayText = i18n("M10997", "Anestezi Raporu");
        this.AnesthesiaReport.BackColor = "#FFFFFF";
        this.AnesthesiaReport.Name = "AnesthesiaReport";
        this.AnesthesiaReport.TabIndex = 1;
        this.AnesthesiaReport.ReadOnly = true;

        this.AnesthesiaEndDateTime = new TTVisual.TTDateTimePicker();
        this.AnesthesiaEndDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.AnesthesiaEndDateTime.Format = DateTimePickerFormat.Long;
        this.AnesthesiaEndDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaEndDateTime.Name = "AnesthesiaEndDateTime";
        this.AnesthesiaEndDateTime.TabIndex = 2;
        this.AnesthesiaEndDateTime.ReadOnly = true;

        this.labelAnesthesiaStartDateTime = new TTVisual.TTLabel();
        this.labelAnesthesiaStartDateTime.Text = i18n("M10961", "Anestezi Başlama Tarihi");
        this.labelAnesthesiaStartDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelAnesthesiaStartDateTime.ForeColor = "#000000";
        this.labelAnesthesiaStartDateTime.Name = "labelAnesthesiaStartDateTime";
        this.labelAnesthesiaStartDateTime.TabIndex = 25;

        this.AnesthesiaStartDateTime = new TTVisual.TTDateTimePicker();
        this.AnesthesiaStartDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.AnesthesiaStartDateTime.Format = DateTimePickerFormat.Long;
        this.AnesthesiaStartDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaStartDateTime.Name = "AnesthesiaStartDateTime";
        this.AnesthesiaStartDateTime.TabIndex = 1;
        this.AnesthesiaStartDateTime.ReadOnly = true;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Gerçekleşen Anestezi Tekniği";
        this.ttlabel5.BackColor = "#DCDCDC";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 104;

        this.GridAnesthesiaProcedures = new TTVisual.TTGrid();
        this.GridAnesthesiaProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridAnesthesiaProcedures.ReadOnly = true;
        this.GridAnesthesiaProcedures.Name = "GridAnesthesiaProcedures";
        this.GridAnesthesiaProcedures.TabIndex = 0;

        this.ACActionDate = new TTVisual.TTDateTimePickerColumn();
        this.ACActionDate.Format = DateTimePickerFormat.Long;
        this.ACActionDate.DataMember = "ActionDate";
        this.ACActionDate.DisplayIndex = 0;
        this.ACActionDate.HeaderText = "Tarih/Saat";
        this.ACActionDate.Name = "ACActionDate";
        this.ACActionDate.Width = 180;

        this.ACProcedureObject = new TTVisual.TTListBoxColumn();
        this.ACProcedureObject.ListDefName = "AnesthesiaListDefinition";
        this.ACProcedureObject.DataMember = "ProcedureObject";
        this.ACProcedureObject.DisplayIndex = 1;
        this.ACProcedureObject.HeaderText = i18n("M10959", "Anestezi");
        this.ACProcedureObject.Name = "ACProcedureObject";
        this.ACProcedureObject.Width = 300;

        this.ACProcedureDoctor = new TTVisual.TTListBoxColumn();
        this.ACProcedureDoctor.ListDefName = "DoctorListDefinition";
        this.ACProcedureDoctor.DataMember = "ProcedureDoctor";
        this.ACProcedureDoctor.DisplayIndex = 2;
        this.ACProcedureDoctor.HeaderText = i18n("M15947", "Hizmeti Veren");
        this.ACProcedureDoctor.Name = "ACProcedureDoctor";
        this.ACProcedureDoctor.Width = 140;

        this.ACNote = new TTVisual.TTTextBoxColumn();
        this.ACNote.DataMember = "Note";
        this.ACNote.DisplayIndex = 3;
        this.ACNote.HeaderText = i18n("M10469", "Açıklama");
        this.ACNote.Name = "ACNote";
        this.ACNote.Width = 115;

        this.AnesteziTeknigi = new TTVisual.TTEnumComboBox();
        this.AnesteziTeknigi.DataTypeName = "AnesthesiaTechniqueEnum";
        this.AnesteziTeknigi.BackColor = "#F0F0F0";
        this.AnesteziTeknigi.Enabled = false;
        this.AnesteziTeknigi.Name = "AnesteziTeknigi";
        this.AnesteziTeknigi.TabIndex = 103;

        this.GridAnesthesiaPersonnels = new TTVisual.TTGrid();
        this.GridAnesthesiaPersonnels.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridAnesthesiaPersonnels.Name = "GridAnesthesiaPersonnels";
        this.GridAnesthesiaPersonnels.TabIndex = 0;
        this.GridAnesthesiaPersonnels.Height = 120;
        this.GridAnesthesiaPersonnels.ShowFilterCombo = !this.ReadOnly;
        this.GridAnesthesiaPersonnels.FilterColumnName = "AnesthesiaPersonnel";
        this.GridAnesthesiaPersonnels.FilterLabel = i18n("M10970", "Anestezi Ekibi"); //
        this.GridAnesthesiaPersonnels.Filter = { ListDefName: "AnaesthesiaTeamListDefinition" };
        this.GridAnesthesiaPersonnels.AllowUserToAddRows = false;
        this.GridAnesthesiaPersonnels.AllowUserToDeleteRows = !this.ReadOnly;
        this.GridAnesthesiaPersonnels.DeleteButtonWidth = "5%";
        this.GridAnesthesiaPersonnels.ShowTotalNumberOfRows = false;
        this.GridAnesthesiaPersonnels.IsFilterLabelSingleLine = false;
        this.GridAnesthesiaPersonnels.ReadOnly = true;

        this.AnesthesiaPersonnel = new TTVisual.TTListBoxColumn();
        this.AnesthesiaPersonnel.ListDefName = "AnaesthesiaTeamListDefinition";
        this.AnesthesiaPersonnel.DataMember = "AnesthesiaPersonnel";
        this.AnesthesiaPersonnel.DisplayIndex = 0;
        this.AnesthesiaPersonnel.HeaderText = "Personel";
        this.AnesthesiaPersonnel.Name = "AnesthesiaPersonnel";
        this.AnesthesiaPersonnel.Width = "90%";
        this.AnesthesiaPersonnel.ReadOnly = this.ReadOnly;

        //this.Role = new TTVisual.TTTextBoxColumn();
        //this.Role.DataMember = "Role";
        //this.Role.DisplayIndex = 1;
        //this.Role.HeaderText = "Görevi";
        //this.Role.Name = "Role";
        //this.Role.Width = 300;
        // this.ASAType.ReadOnly = this.ReadOnly;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M22134", "Sorumlu Anestezi Uzmanı");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 121;

        this.AnestesiaProcedureDoctor2 = new TTVisual.TTObjectListBox();
        this.AnestesiaProcedureDoctor2.ListDefName = "SpecialistDoctorListDefinition";
        this.AnestesiaProcedureDoctor2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnestesiaProcedureDoctor2.Name = "AnestesiaProcedureDoctor2";
        this.AnestesiaProcedureDoctor2.TabIndex = 3;
        this.AnestesiaProcedureDoctor2.ReadOnly = true;

        this.labelProcedureDoctor2 = new TTVisual.TTLabel();
        this.labelProcedureDoctor2.Text = i18n("M10222", "2.Sorumlu Anestezi Uzmanı");
        this.labelProcedureDoctor2.BackColor = "#DCDCDC";
        this.labelProcedureDoctor2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor2.ForeColor = "#000000";
        this.labelProcedureDoctor2.Name = "labelProcedureDoctor2";
        this.labelProcedureDoctor2.TabIndex = 121;

        this.AnestesiaProcedureDoctor = new TTVisual.TTObjectListBox();
        this.AnestesiaProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.AnestesiaProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnestesiaProcedureDoctor.Name = "AnestesiaProcedureDoctor";
        this.AnestesiaProcedureDoctor.TabIndex = 3;
        this.AnestesiaProcedureDoctor.ReadOnly = true;

        this.PlannedSurgeryDescription = new TTVisual.TTTextBox();
        this.PlannedSurgeryDescription.Multiline = true;
        this.PlannedSurgeryDescription.BackColor = "#F0F0F0";
        this.PlannedSurgeryDescription.Height = "40";
        this.PlannedSurgeryDescription.ReadOnly = true;
        this.PlannedSurgeryDescription.Name = "PlannedSurgeryDescription";
        this.PlannedSurgeryDescription.TabIndex = 103;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "SurgreyDepartmentListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 3;
        this.MasterResource.ReadOnly = true;

        this.labelPlannedSurgeryDescription = new TTVisual.TTLabel();
        this.labelPlannedSurgeryDescription.Text = i18n("M20394", "Planlanan Ameliyat Açıklaması");
        this.labelPlannedSurgeryDescription.Name = "labelPlannedSurgeryDescription";
        this.labelPlannedSurgeryDescription.TabIndex = 104;

        this.SurgeryDesk = new TTVisual.TTObjectListBox();
        this.SurgeryDesk.LinkedControlName = "SurgeryRoom";
        this.SurgeryDesk.ListDefName = "SurgeryDeskListDefinition";
        this.SurgeryDesk.Name = "SurgeryDesk";
        this.SurgeryDesk.TabIndex = 105;

        this.labelSurgeryDesk = new TTVisual.TTLabel();
        this.labelSurgeryDesk.Text = i18n("M18680", "Masa");
        this.labelSurgeryDesk.Name = "labelSurgeryDesk";
        this.labelSurgeryDesk.TabIndex = 106;

        this.GridDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridSurgeryPersonnelsColumns = [this.SurgeryPersonnel, this.SurgeryPersonnelSpeciality, this.CARole];
        this.GridSurgeryExpendsColumns = [this.ttdatetimepickercolumn1, this.CAStore, this.CAMaterial, this.tttextboxcolumn1, this.tttextboxcolumn2, this.DonorID, this.DistributionType];
        this.DirectPurchaseGridsColumns = [this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid];
        this.GridAnesthesiaProceduresColumns = [this.ACActionDate, this.ACProcedureObject, this.ACProcedureDoctor, this.ACNote];
        this.GridAnesthesiaPersonnelsColumns = [this.AnesthesiaPersonnel]; //, this.Role
        this.TabOperative.Controls = [this.SurgeryInfo, this.PreOperativeInfo, this.AnesthesiaInfo];
        this.SurgeryInfo.Controls = [this.SurgeryReport, this.SurgeryReportDate, this.ttlabel3, this.Ameliyat];
        this.Ameliyat.Controls = [this.MainSurgeryProcedures, this.SurgeryProcedures, this.SurgeryTeam, this.SurgeryExpend, this.DirectPurchase];
        this.SurgeryTeam.Controls = [this.GridSurgeryPersonnels];
        this.SurgeryExpend.Controls = [this.GridSurgeryExpends];
        this.DirectPurchase.Controls = [this.DirectPurchaseGrids];
        this.PreOperativeInfo.Controls = [this.DescriptionToPreOp, this.PreOpDescriptions];
        this.AnesthesiaInfo.Controls = [this.ScarTypeAnesthesiaAndReanimation, this.ASAScoreAnesthesiaAndReanimation, this.AnesthesiaReportDateAnesthesiaAndReanimation, this.LaparoscopyAnesthesiaAndReanimation, this.HasComplicationAnesthesiaAndReanimation, this.ComplicationDescriptionAnesthesiaAndReanimation, this.labelAnesthesiaEndDateTime, this.AnesthesiaReport, this.AnesthesiaEndDateTime, this.labelAnesthesiaStartDateTime, this.AnesthesiaStartDateTime, this.ttlabel5, this.GridAnesthesiaProcedures, this.AnesteziTeknigi, this.GridAnesthesiaPersonnels, this.ttlabel2, this.AnestesiaProcedureDoctor2, this.labelProcedureDoctor2, this.AnestesiaProcedureDoctor];
        this.Controls = [this.ScarTypeAnesthesiaAndReanimation, this.ASAScoreAnesthesiaAndReanimation, this.AnesthesiaReportDateAnesthesiaAndReanimation, this.LaparoscopyAnesthesiaAndReanimation, this.HasComplicationAnesthesiaAndReanimation, this.ComplicationDescriptionAnesthesiaAndReanimation, this.SurgeryResult, this.SurgeryRobson, this.labelSurgeryStatus, this.SurgeryStatus, this.labelSurgeryShift, this.SurgeryShift, this.labelSurgeryPointGroup, this.SurgeryPointGroup, this.labelReasonOfReject, this.ReasonOfReject, this.GridDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ProtocolNo, this.labelProcedureDoctor, this.ProcedureDoctor, this.RequestDate, this.labelRequestDate, this.ttlabel9, this.PlannedSurgeryDate, this.labelSurgeryEndTime, this.SurgeryEndTime, this.SurgeryRoom, this.Emergency, this.labelSurgeryStartTime, this.SurgeryStartTime, this.ttlabel1, this.labelRoom, this.labelProtocolNo, this.TabOperative, this.SurgeryInfo, this.SurgeryReport, this.SurgeryReportDate, this.ttlabel3, this.Ameliyat, this.MainSurgeryProcedures, this.SurgeryProcedures, this.SurgeryTeam, this.GridSurgeryPersonnels, this.SurgeryPersonnel, this.CARole, this.SurgeryExpend, this.GridSurgeryExpends, this.ttdatetimepickercolumn1, this.CAStore, this.CAMaterial, this.tttextboxcolumn1, this.tttextboxcolumn2, this.DonorID, this.DistributionType, this.DirectPurchase, this.DirectPurchaseGrids, this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid, this.PreOperativeInfo, this.DescriptionToPreOp, this.PreOpDescriptions, this.AnesthesiaInfo, this.labelAnesthesiaEndDateTime, this.AnesthesiaReport, this.AnesthesiaEndDateTime, this.labelAnesthesiaStartDateTime, this.AnesthesiaStartDateTime, this.ttlabel5, this.GridAnesthesiaProcedures, this.ACActionDate, this.ACProcedureObject, this.ACProcedureDoctor, this.ACNote, this.AnesteziTeknigi, this.GridAnesthesiaPersonnels, this.AnesthesiaPersonnel, this.ttlabel2, this.AnestesiaProcedureDoctor2, this.labelProcedureDoctor2, this.AnestesiaProcedureDoctor, this.PlannedSurgeryDescription, this.MasterResource, this.labelPlannedSurgeryDescription, this.SurgeryDesk, this.labelSurgeryDesk
            , this.SelectedSurgeryProcedure]; //this.Role,

    }

    filterByBranch(event): void {
        if (event.value === true) {
            this.SelectedSurgeryProcedure.ListFilterExpression = "  Branches(SpecialityDefinition.OBJECTID IN ('" + this.surgeryFormViewModel.MasterResourceSpecialityID + "')).EXISTS ";
        }
        else {
            this.SelectedSurgeryProcedure.ListFilterExpression = "";
        }
    }

    async printSurgeryReport() {

        let reportData: DynamicReportParameters = {

            Code: 'AMELIYATRAPORU',
            ReportParams: { ObjectID: this._Surgery.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "AMELİYAT RAPORU"

            modalInfo.fullScreen = true;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }
    showChecklistSelection: boolean = false;
    public async openSafeSurgeryChecklists() {
        let that = this;
        if (this._Surgery.SafeSurgeryCheckList == null) {
            ServiceLocator.MessageService.showError("Bu ameliyat için oluşturulmuş bir Güvenli Cerrahi Kontrol Listesi bulunmamaktadır")
        }
        else {
            let param: ClickFunctionParams = this.getClickFunctionParams();
            if (typeof this._Surgery.SafeSurgeryCheckList === "string")
                await that.helpMenuService.showSurgeryChecklist(this._Surgery.SafeSurgeryCheckList, param);
        }
    }
}
