//$6235FC38
import { Component, OnInit, NgZone } from '@angular/core';
import { PathologyMainFormViewModel } from './PathologyMainFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Pathology } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyPanicAlert } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { IModal, ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { PathologyAdditionalReport } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { HelpMenuService } from "Fw/Services/HelpMenuService";

@Component({
    selector: 'PathologyMainForm',
    templateUrl: './PathologyMainForm.html',
    providers: [MessageService, AtlasReportService]
})
export class PathologyMainForm extends EpisodeActionForm implements OnInit, IModal {
    AcceptionDatePathologyRequest: TTVisual.ITTDateTimePicker;
    AcceptionNotePathologyRequest: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    ActionDateBaseTreatmentMaterial: TTVisual.ITTDateTimePickerColumn;
    AlindigiDokununTemelOzelligiPathologyMaterial: TTVisual.ITTListBoxColumn;
    AmountBaseTreatmentMaterial: TTVisual.ITTTextBoxColumn;
    ApproveDate: TTVisual.ITTDateTimePicker;
    SendToApproveDate: TTVisual.ITTDateTimePicker;
    AssistantDoctor: TTVisual.ITTObjectListBox;
    Barcode: TTVisual.ITTTextBoxColumn;
    ClinicalFindingsPathologyMaterial: TTVisual.ITTTextBoxColumn;
    ComplaintEpisode: TTVisual.ITTRichTextBoxControl;
    Consumables: TTVisual.ITTTabPage;
    DateOfSampleTakenPathologyMaterial: TTVisual.ITTDateTimePickerColumn;
    DescriptionPathologyMaterial: TTVisual.ITTTextBoxColumn;
    DiagnoseDiagnosisGrid: TTVisual.ITTListBoxColumn;
    DiagnosisDiagnosisGrid: TTVisual.ITTGrid;
    DiagnosisTypeDiagnosisGrid: TTVisual.ITTEnumComboBoxColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    EpisodeDiagnosisTab: TTVisual.ITTTabPage;
    labelAcceptionDatePathologyRequest: TTVisual.ITTLabel;
    labelAcceptionNotePathologyRequest: TTVisual.ITTLabel;
    labelRequestDate: TTVisual.ITTLabel;
    labelApproveDate: TTVisual.ITTLabel;
    labelAssistantDoctor: TTVisual.ITTLabel;
    labelComplaintEpisode: TTVisual.ITTLabel;
    labelMatPrtNoString: TTVisual.ITTLabel;
    labelPhoneNumberResUser: TTVisual.ITTLabel;
    labelPhysicalExaminationEpisode: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelReportDate: TTVisual.ITTLabel;
    labelRequestDoctorPathologyRequest: TTVisual.ITTLabel;
    labelSpecialDoctor: TTVisual.ITTLabel;
    labelTechnicianNote: TTVisual.ITTLabel;
    MacroscopyPathologyMaterial: TTVisual.ITTRichTextBoxControlColumn;
    Material: TTVisual.ITTListBoxColumn;
    MaterialNumberPathologyMaterial: TTVisual.ITTTextBoxColumn;
    Materials: TTVisual.ITTTabPage;
    MatPrtNoString: TTVisual.ITTTextBox;
    MicroscopyPathologyMaterial: TTVisual.ITTRichTextBoxControlColumn;
    MorfolojiKoduPathologyMaterial: TTVisual.ITTListBoxColumn;
    NotePathologyMaterial: TTVisual.ITTRichTextBoxControlColumn;
    NumuneAlinmaSekliPathologyMaterial: TTVisual.ITTListBoxColumn;
    PathologyMaterial: TTVisual.ITTGrid;
    PatolojiPreparatiDurumuPathologyMaterial: TTVisual.ITTListBoxColumn;
    PhoneNumberResUser: TTVisual.ITTTextBox;
    PhysicalExaminationEpisode: TTVisual.ITTRichTextBoxControl;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ReportDate: TTVisual.ITTDateTimePicker;
    RequestDoctorPathologyRequest: TTVisual.ITTObjectListBox;
    SpecialDoctor: TTVisual.ITTObjectListBox;
    TechnicianNote: TTVisual.ITTTextBox;
    TreatmentMaterials: TTVisual.ITTGrid;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    UBBCodeBaseTreatmentMaterial: TTVisual.ITTTextBoxColumn;
    YerlesimYeriPathologyMaterial: TTVisual.ITTListBoxColumn;
    public DiagnosisDiagnosisGridColumns = [];
    public PathologyMaterialColumns = [];
    public TreatmentMaterialsColumns = [];
    public pathologyMainFormViewModel: PathologyMainFormViewModel = new PathologyMainFormViewModel();

    PathologyMaterialsListColumns = [];
    private yerlesimYeriArray: Array<any> = [];
    private YerlesimYeriCache: any;
    private alindigiDokununTemelOzelligiArray: Array<any> = [];
    private AlindigiDokununTemelOzelligiCache: any;
    private numuneAlinmaSekliArray: Array<any> = [];
    private NumuneAlinmaSekliCache: any;
    isReadOnly: boolean = false;
    _showStateButtons: boolean = true;

    public get _Pathology(): Pathology {
        return this._TTObject as Pathology;
    }
    private PathologyMainForm_DocumentUrl: string = '/api/PathologyService/PathologyMainForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected modalService: IModalService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.PathologyMainForm_DocumentUrl;

        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Pathology();
        this.pathologyMainFormViewModel = new PathologyMainFormViewModel();
        this._ViewModel = this.pathologyMainFormViewModel;
        this.pathologyMainFormViewModel._Pathology = this._TTObject as Pathology;
        //this.pathologyMainFormViewModel._Pathology.PathologyAdditionalReport = new Array<PathologyAdditionalReport>();
        this.pathologyMainFormViewModel._Pathology.PathologyRequest = new PathologyRequest();
        this.pathologyMainFormViewModel._Pathology.PathologyRequest.RequestDoctor = new ResUser();
        this.pathologyMainFormViewModel._Pathology.Episode = new Episode();
        this.pathologyMainFormViewModel._Pathology.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.pathologyMainFormViewModel._Pathology.PathologyMaterial = new Array<PathologyMaterial>();
        this.pathologyMainFormViewModel._Pathology.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
        this.pathologyMainFormViewModel._Pathology.AssistantDoctor = new ResUser();
        this.pathologyMainFormViewModel._Pathology.ProcedureDoctor = new ResUser();
        this.pathologyMainFormViewModel._Pathology.SpecialDoctor = new ResUser();
        this.pathologyMainFormViewModel._RequestedPathologyProceduresArray = [];
        //this.pathologyMainFormViewModel._Pathology.PathologyPanicAlert = new Array<PathologyPanicAlert>();
    }

    protected loadViewModel() {
        let that = this;

        that.pathologyMainFormViewModel = this._ViewModel as PathologyMainFormViewModel;
        that._TTObject = this.pathologyMainFormViewModel._Pathology;
        if (this.pathologyMainFormViewModel == null)
            this.pathologyMainFormViewModel = new PathologyMainFormViewModel();
        if (this.pathologyMainFormViewModel._Pathology == null)
            this.pathologyMainFormViewModel._Pathology = new Pathology();
        //that.pathologyMainFormViewModel._Pathology.PathologyAdditionalReport = that.pathologyMainFormViewModel.PathologyAdditionalReportGridList;
        //for (let detailItem of that.pathologyMainFormViewModel.PathologyAdditionalReportGridList) {
        //    detailItem.Pathology = that.pathologyMainFormViewModel._Pathology;

        //}

        //that.pathologyMainFormViewModel._Pathology.PathologyPanicAlert = that.pathologyMainFormViewModel.PathologyPanicAlertGridList;
        //for (let detailItem of that.pathologyMainFormViewModel.PathologyPanicAlertGridList) {
        //    detailItem.Pathology = that.pathologyMainFormViewModel._Pathology;
          

        //}

        let pathologyRequestObjectID = that.pathologyMainFormViewModel._Pathology["PathologyRequest"];
        if (pathologyRequestObjectID != null && (typeof pathologyRequestObjectID === 'string')) {
            let pathologyRequest = that.pathologyMainFormViewModel.PathologyRequests.find(o => o.ObjectID.toString() === pathologyRequestObjectID.toString());
            if (pathologyRequest) {
                that.pathologyMainFormViewModel._Pathology.PathologyRequest = pathologyRequest;
            }
            if (pathologyRequest != null) {
                let requestDoctorObjectID = pathologyRequest["RequestDoctor"];
                if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
                    let requestDoctor = that.pathologyMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                    if (requestDoctor) {
                        pathologyRequest.RequestDoctor = requestDoctor;
                    }
                }
            }
        }
        let episodeObjectID = that.pathologyMainFormViewModel._Pathology["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.pathologyMainFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.pathologyMainFormViewModel._Pathology.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.pathologyMainFormViewModel.DiagnosisDiagnosisGridGridList;
                for (let detailItem of that.pathologyMainFormViewModel.DiagnosisDiagnosisGridGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.pathologyMainFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                }
            }
        }
        that.pathologyMainFormViewModel._Pathology.PathologyMaterial = that.pathologyMainFormViewModel.PathologyMaterialGridList;
        for (let detailItem of that.pathologyMainFormViewModel.PathologyMaterialGridList) {
            let yerlesimYeriObjectID = detailItem["YerlesimYeri"];
            if (yerlesimYeriObjectID != null && (typeof yerlesimYeriObjectID === 'string')) {
                let yerlesimYeri = that.pathologyMainFormViewModel.SKRSICDOYERLESIMYERIs.find(o => o.ObjectID.toString() === yerlesimYeriObjectID.toString());
                if (yerlesimYeri) {
                    detailItem.YerlesimYeri = yerlesimYeri;
                }
            }
            let alindigiDokununTemelOzelligiObjectID = detailItem["AlindigiDokununTemelOzelligi"];
            if (alindigiDokununTemelOzelligiObjectID != null && (typeof alindigiDokununTemelOzelligiObjectID === 'string')) {
                let alindigiDokununTemelOzelligi = that.pathologyMainFormViewModel.SKRSNumuneAlindigiDokununTemelOzelligis.find(o => o.ObjectID.toString() === alindigiDokununTemelOzelligiObjectID.toString());
                if (alindigiDokununTemelOzelligi) {
                    detailItem.AlindigiDokununTemelOzelligi = alindigiDokununTemelOzelligi;
                }
            }
            let numuneAlinmaSekliObjectID = detailItem["NumuneAlinmaSekli"];
            if (numuneAlinmaSekliObjectID != null && (typeof numuneAlinmaSekliObjectID === 'string')) {
                let numuneAlinmaSekli = that.pathologyMainFormViewModel.SKRSNumuneAlinmaSeklis.find(o => o.ObjectID.toString() === numuneAlinmaSekliObjectID.toString());
                if (numuneAlinmaSekli) {
                    detailItem.NumuneAlinmaSekli = numuneAlinmaSekli;
                }
            }
            let patolojiPreparatiDurumuObjectID = detailItem["PatolojiPreparatiDurumu"];
            if (patolojiPreparatiDurumuObjectID != null && (typeof patolojiPreparatiDurumuObjectID === 'string')) {
                let patolojiPreparatiDurumu = that.pathologyMainFormViewModel.SKRSPatolojiPreparatiDurumus.find(o => o.ObjectID.toString() === patolojiPreparatiDurumuObjectID.toString());
                if (patolojiPreparatiDurumu) {
                    detailItem.PatolojiPreparatiDurumu = patolojiPreparatiDurumu;
                }
            }
            let morfolojiKoduObjectID = detailItem["MorfolojiKodu"];
            if (morfolojiKoduObjectID != null && (typeof morfolojiKoduObjectID === 'string')) {
                let morfolojiKodu = that.pathologyMainFormViewModel.SKRSICDOMORFOLOJIKODUs.find(o => o.ObjectID.toString() === morfolojiKoduObjectID.toString());
                if (morfolojiKodu) {
                    detailItem.MorfolojiKodu = morfolojiKodu;
                }
            }
        }
        that.pathologyMainFormViewModel._Pathology.TreatmentMaterials = that.pathologyMainFormViewModel.TreatmentMaterialsGridList;
        for (let detailItem of that.pathologyMainFormViewModel.TreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.pathologyMainFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.pathologyMainFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.pathologyMainFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        

        let masterResourceID = that.pathologyMainFormViewModel._Pathology["MasterResource"];
        that.ProcedureDoctor.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResourceID.toString() + '\'';
        that.SpecialDoctor.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResourceID.toString() + '\'';
        that.AssistantDoctor.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResourceID.toString() + '\'';


        let assistantDoctorObjectID = that.pathologyMainFormViewModel._Pathology["AssistantDoctor"];
        if (assistantDoctorObjectID != null && (typeof assistantDoctorObjectID === 'string')) {
            let assistantDoctor = that.pathologyMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === assistantDoctorObjectID.toString());
            if (assistantDoctor) {
                that.pathologyMainFormViewModel._Pathology.AssistantDoctor = assistantDoctor;
            }
        }
        let procedureDoctorObjectID = that.pathologyMainFormViewModel._Pathology["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.pathologyMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.pathologyMainFormViewModel._Pathology.ProcedureDoctor = procedureDoctor;
            }
        }
        let specialDoctorObjectID = that.pathologyMainFormViewModel._Pathology["SpecialDoctor"];
        if (specialDoctorObjectID != null && (typeof specialDoctorObjectID === 'string')) {
            let specialDoctor = that.pathologyMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === specialDoctorObjectID.toString());
            if (specialDoctor) {
                that.pathologyMainFormViewModel._Pathology.SpecialDoctor = specialDoctor;
            }
        }

        that.pathologyMainFormViewModel._RequestedPathologyProceduresArray = [];
    }


    async ngOnInit() {
        let that = this;
        that.yerlesimYeriArray = await this.YerlesimYeri();
        that.alindigiDokununTemelOzelligiArray = await this.AlindigiDokununTemelOzelligi();
        that.numuneAlinmaSekliArray = await this.NumuneAlinmaSekli();
        that.GenerateMaterialsListColumns();
        await this.load(PathologyMainFormViewModel);
        this.AddHelpMenu();

    }

  /*  public async setStateToTransition(saveInfo: FormSaveInfo) {
    }*/


    public OpenPathologyResultReportNew() {
        const objectIdParam = new GuidParam(this._Pathology.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReportModal('PathologyResultReportNew', reportParameters);       
    }


    public onAcceptionDatePathologyRequestChanged(event): void {
        if (event != null) {
            if (this._Pathology != null &&
                this._Pathology.PathologyRequest != null && this._Pathology.PathologyRequest.AcceptionDate != event) {
                this._Pathology.PathologyRequest.AcceptionDate = event;
            }
        }
    }

    public onAcceptionNotePathologyRequestChanged(event): void {
        if (event != null) {
            if (this._Pathology != null &&
                this._Pathology.PathologyRequest != null && this._Pathology.PathologyRequest.AcceptionNote != event) {
                this._Pathology.PathologyRequest.AcceptionNote = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._Pathology != null &&
                this._Pathology.PathologyRequest != null && this._Pathology.PathologyRequest.RequestDate != event) {
                this._Pathology.PathologyRequest.RequestDate = event;
            }
        }
    }

    public onApproveDateChanged(event): void {
        if (event != null) {
            if (this._Pathology != null && this._Pathology.ApproveDate != event) {
                this._Pathology.ApproveDate = event;
            }
        }
    }

    public onSendToApproveDateChanged(event): void {
        if (event != null) {
            if (this._Pathology != null && this._Pathology.SendToApproveDate != event) {
                this._Pathology.SendToApproveDate = event;
            }
        }
    }

    public onAssistantDoctorChanged(event): void {
        if (event != null) {
            if (this._Pathology != null && this._Pathology.AssistantDoctor != event) {
                this._Pathology.AssistantDoctor = event;
            }
        }
    }

    public onComplaintEpisodeChanged(event): void {
        if (event != null) {
            if (this._Pathology != null &&
                this._Pathology.Episode != null && this._Pathology.Episode.Complaint != event) {
                this._Pathology.Episode.Complaint = event;
            }
        }
    }

    public onMatPrtNoStringChanged(event): void {
        if (event != null) {
            if (this._Pathology != null && this._Pathology.MatPrtNoString != event) {
                this._Pathology.MatPrtNoString = event;
            }
        }
    }

    public onPhoneNumberResUserChanged(event): void {
        if (event != null) {
            if (this._Pathology != null &&
                this._Pathology.PathologyRequest != null &&
                this._Pathology.PathologyRequest.RequestDoctor != null && this._Pathology.PathologyRequest.RequestDoctor.PhoneNumber != event) {
                this._Pathology.PathologyRequest.RequestDoctor.PhoneNumber = event;
            }
        }
    }

    public onPhysicalExaminationEpisodeChanged(event): void {
        if (event != null) {
            if (this._Pathology != null &&
                this._Pathology.Episode != null && this._Pathology.Episode.PhysicalExamination != event) {
                this._Pathology.Episode.PhysicalExamination = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._Pathology != null && this._Pathology.ProcedureDoctor != event) {
                this._Pathology.ProcedureDoctor = event;
            }
        }
    }

    public onReportDateChanged(event): void {
        if (event != null) {
            if (this._Pathology != null && this._Pathology.ReportDate != event) {
                this._Pathology.ReportDate = event;
            }
        }
    }

    public onRequestDoctorPathologyRequestChanged(event): void {
        if (event != null) {
            if (this._Pathology != null &&
                this._Pathology.PathologyRequest != null && this._Pathology.PathologyRequest.RequestDoctor != event) {
                this._Pathology.PathologyRequest.RequestDoctor = event;
            }
        }
    }

    public onSpecialDoctorChanged(event): void {
        if (event != null) {
            if (this._Pathology != null && this._Pathology.SpecialDoctor != event) {
                this._Pathology.SpecialDoctor = event;
            }
        }
    }

    public onTechnicianNoteChanged(event): void {
        if (event != null) {
            if (this._Pathology != null && this._Pathology.TechnicianNote != event) {
                this._Pathology.TechnicianNote = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.MatPrtNoString, "Text", this.__ttObject, "MatPrtNoString");
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "PathologyRequest.RequestDate");
        redirectProperty(this.PhoneNumberResUser, "Text", this.__ttObject, "PathologyRequest.RequestDoctor.PhoneNumber");
        redirectProperty(this.ComplaintEpisode, "Rtf", this.__ttObject, "Episode.Complaint");
        redirectProperty(this.PhysicalExaminationEpisode, "Rtf", this.__ttObject, "Episode.PhysicalExamination");
        redirectProperty(this.AcceptionDatePathologyRequest, "Value", this.__ttObject, "PathologyRequest.AcceptionDate");
        redirectProperty(this.AcceptionNotePathologyRequest, "Text", this.__ttObject, "PathologyRequest.AcceptionNote");
        redirectProperty(this.TechnicianNote, "Text", this.__ttObject, "TechnicianNote");
        redirectProperty(this.ApproveDate, "Value", this.__ttObject, "ApproveDate");
        redirectProperty(this.SendToApproveDate, "Value", this.__ttObject, "SendToApproveDate");
        redirectProperty(this.ReportDate, "Value", this.__ttObject, "ReportDate");
    }

    public initFormControls(): void {
        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M16650", "İstek Tarihi");
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 34;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 33;
        this.RequestDate.Enabled = false;
        this.RequestDate.BackColor = "#F0F0F0";

        this.labelApproveDate = new TTVisual.TTLabel();
        this.labelApproveDate.Text = i18n("M19686", "Onay Tarih");
        this.labelApproveDate.Name = "labelApproveDate";
        this.labelApproveDate.TabIndex = 32;

        this.ApproveDate = new TTVisual.TTDateTimePicker();
        this.ApproveDate.Format = DateTimePickerFormat.Long;
        this.ApproveDate.Name = "ApproveDate";
        this.ApproveDate.TabIndex = 31;
        this.ApproveDate.Enabled = false;
        this.ApproveDate.BackColor = "#F0F0F0";

        this.SendToApproveDate = new TTVisual.TTDateTimePicker();
        this.SendToApproveDate.Format = DateTimePickerFormat.Long;
        this.SendToApproveDate.Name = "ApproveDate";
        this.SendToApproveDate.TabIndex = 31;
        this.SendToApproveDate.Enabled = false;
        this.SendToApproveDate.BackColor = "#F0F0F0";

        this.labelReportDate = new TTVisual.TTLabel();
        this.labelReportDate.Text = i18n("M20864", "Rapor Tarihi");
        this.labelReportDate.Name = "labelReportDate";
        this.labelReportDate.TabIndex = 30;

        this.ReportDate = new TTVisual.TTDateTimePicker();
        this.ReportDate.Format = DateTimePickerFormat.Long;
        this.ReportDate.Name = "ReportDate";
        this.ReportDate.TabIndex = 29;

        this.ReportDate.Enabled = false;
        this.ReportDate.BackColor = "#F0F0F0";

        this.labelTechnicianNote = new TTVisual.TTLabel();
        this.labelTechnicianNote.Text = i18n("M23112", "Teknisyen Notu");
        this.labelTechnicianNote.Name = "labelTechnicianNote";
        this.labelTechnicianNote.TabIndex = 28;

        this.TechnicianNote = new TTVisual.TTTextBox();
        this.TechnicianNote.Multiline = true;
        this.TechnicianNote.Name = "TechnicianNote";
        this.TechnicianNote.TabIndex = 27;
        this.TechnicianNote.Height = "80px";

        this.AcceptionNotePathologyRequest = new TTVisual.TTTextBox();
        this.AcceptionNotePathologyRequest.Multiline = true;
        this.AcceptionNotePathologyRequest.BackColor = "#F0F0F0";

        this.AcceptionNotePathologyRequest.Name = "AcceptionNotePathologyRequest";
        this.AcceptionNotePathologyRequest.TabIndex = 25;
        this.AcceptionNotePathologyRequest.Height = "80px";

        this.PhoneNumberResUser = new TTVisual.TTTextBox();
        this.PhoneNumberResUser.BackColor = "#F0F0F0";

        this.PhoneNumberResUser.Name = "PhoneNumberResUser";
        this.PhoneNumberResUser.TabIndex = 14;

        this.labelAcceptionNotePathologyRequest = new TTVisual.TTLabel();
        this.labelAcceptionNotePathologyRequest.Text = i18n("M18698", "Materyal Kabul Notu");
        this.labelAcceptionNotePathologyRequest.Name = "labelAcceptionNotePathologyRequest";
        this.labelAcceptionNotePathologyRequest.TabIndex = 26;

        this.labelAcceptionDatePathologyRequest = new TTVisual.TTLabel();
        this.labelAcceptionDatePathologyRequest.Text = i18n("M18699", "Materyal Kabul Tarihi");
        this.labelAcceptionDatePathologyRequest.Name = "labelAcceptionDatePathologyRequest";
        this.labelAcceptionDatePathologyRequest.TabIndex = 24;

        this.AcceptionDatePathologyRequest = new TTVisual.TTDateTimePicker();
        this.AcceptionDatePathologyRequest.BackColor = "#F0F0F0";
        this.AcceptionDatePathologyRequest.Format = DateTimePickerFormat.Long;
        this.AcceptionDatePathologyRequest.Enabled = false;
        this.AcceptionDatePathologyRequest.Name = "AcceptionDatePathologyRequest";
        this.AcceptionDatePathologyRequest.TabIndex = 23;

        this.labelPhysicalExaminationEpisode = new TTVisual.TTLabel();
        this.labelPhysicalExaminationEpisode.Text = i18n("M14383", "Fizik Muayene");
        this.labelPhysicalExaminationEpisode.Name = "labelPhysicalExaminationEpisode";
        this.labelPhysicalExaminationEpisode.TabIndex = 21;

        this.PhysicalExaminationEpisode = new TTVisual.TTRichTextBoxControl();
        this.PhysicalExaminationEpisode.Name = "PhysicalExaminationEpisode";
        this.PhysicalExaminationEpisode.TabIndex = 20;
        this.PhysicalExaminationEpisode.ReadOnly = true;

        this.labelComplaintEpisode = new TTVisual.TTLabel();
        this.labelComplaintEpisode.Text = i18n("M22483", "Şikayet");
        this.labelComplaintEpisode.Name = "labelComplaintEpisode";
        this.labelComplaintEpisode.TabIndex = 19;

        this.ComplaintEpisode = new TTVisual.TTRichTextBoxControl();
        this.ComplaintEpisode.Name = "ComplaintEpisode";
        this.ComplaintEpisode.TabIndex = 18;
        this.ComplaintEpisode.ReadOnly = true;

        this.labelPhoneNumberResUser = new TTVisual.TTLabel();
        this.labelPhoneNumberResUser.Text = i18n("M23135", "Telefon No");
        this.labelPhoneNumberResUser.Name = "labelPhoneNumberResUser";
        this.labelPhoneNumberResUser.TabIndex = 15;

        this.labelRequestDoctorPathologyRequest = new TTVisual.TTLabel();
        this.labelRequestDoctorPathologyRequest.Text = i18n("M16661", "İstek Yapan Doktor");
        this.labelRequestDoctorPathologyRequest.Name = "labelRequestDoctorPathologyRequest";
        this.labelRequestDoctorPathologyRequest.TabIndex = 13;

        this.RequestDoctorPathologyRequest = new TTVisual.TTObjectListBox();

        this.RequestDoctorPathologyRequest.ListDefName = "DoctorListDefinition";
        this.RequestDoctorPathologyRequest.Name = "RequestDoctorPathologyRequest";
        this.RequestDoctorPathologyRequest.TabIndex = 12;
        this.RequestDoctorPathologyRequest.Enabled = false;
        this.RequestDoctorPathologyRequest.BackColor = "#F0F0F0";

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 11;

        this.Materials = new TTVisual.TTTabPage();
        this.Materials.DisplayIndex = 0;
        this.Materials.TabIndex = 0;
        this.Materials.Text = i18n("M20246", "Patoloji Materyaller");
        this.Materials.Name = "Materials";

        this.PathologyMaterial = new TTVisual.TTGrid();
        this.PathologyMaterial.Name = "PathologyMaterial";
        this.PathologyMaterial.TabIndex = 10;

        this.MaterialNumberPathologyMaterial = new TTVisual.TTTextBoxColumn();
        this.MaterialNumberPathologyMaterial.DataMember = "MaterialNumber";
        this.MaterialNumberPathologyMaterial.DisplayIndex = 0;
        this.MaterialNumberPathologyMaterial.HeaderText = i18n("M18700", "Materyal Numarası");
        this.MaterialNumberPathologyMaterial.Name = "MaterialNumberPathologyMaterial";
        this.MaterialNumberPathologyMaterial.Width = 80;

        this.DateOfSampleTakenPathologyMaterial = new TTVisual.TTDateTimePickerColumn();
        this.DateOfSampleTakenPathologyMaterial.CustomFormat = "dd/MM/yyyy HH:mm";
        this.DateOfSampleTakenPathologyMaterial.DataMember = "DateOfSampleTaken";
        this.DateOfSampleTakenPathologyMaterial.DisplayIndex = 1;
        this.DateOfSampleTakenPathologyMaterial.HeaderText = i18n("M19537", "Numune Alınma Tarihi");
        this.DateOfSampleTakenPathologyMaterial.Name = "DateOfSampleTakenPathologyMaterial";
        this.DateOfSampleTakenPathologyMaterial.Width = 180;

        this.YerlesimYeriPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.YerlesimYeriPathologyMaterial.ListDefName = "SKRSICDOYERLESIMYERIList";
        this.YerlesimYeriPathologyMaterial.DataMember = "YerlesimYeri";
        this.YerlesimYeriPathologyMaterial.DisplayIndex = 2;
        this.YerlesimYeriPathologyMaterial.HeaderText = i18n("M10716", "Alındığı Organ");
        this.YerlesimYeriPathologyMaterial.Name = "YerlesimYeriPathologyMaterial";
        this.YerlesimYeriPathologyMaterial.Width = 300;

        this.AlindigiDokununTemelOzelligiPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.AlindigiDokununTemelOzelligiPathologyMaterial.ListDefName = "SKRSNumuneAlindigiDokununTemelOzelligiList";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.DataMember = "AlindigiDokununTemelOzelligi";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.DisplayIndex = 3;
        this.AlindigiDokununTemelOzelligiPathologyMaterial.HeaderText = i18n("M10715", "Alındığı Dokunun Temel Özelliği");
        this.AlindigiDokununTemelOzelligiPathologyMaterial.Name = "AlindigiDokununTemelOzelligiPathologyMaterial";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.Width = 300;

        this.NumuneAlinmaSekliPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.NumuneAlinmaSekliPathologyMaterial.ListDefName = "SKRSNumuneAlinmaSekliList";
        this.NumuneAlinmaSekliPathologyMaterial.DataMember = "NumuneAlinmaSekli";
        this.NumuneAlinmaSekliPathologyMaterial.DisplayIndex = 4;
        this.NumuneAlinmaSekliPathologyMaterial.HeaderText = i18n("M19536", "Numune Alınma Şekli");
        this.NumuneAlinmaSekliPathologyMaterial.Name = "NumuneAlinmaSekliPathologyMaterial";
        this.NumuneAlinmaSekliPathologyMaterial.Width = 300;

        this.PatolojiPreparatiDurumuPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.PatolojiPreparatiDurumuPathologyMaterial.ListDefName = "SKRSPatolojiPreparatiDurumuList";
        this.PatolojiPreparatiDurumuPathologyMaterial.DataMember = "PatolojiPreparatiDurumu";
        this.PatolojiPreparatiDurumuPathologyMaterial.DisplayIndex = 5;
        this.PatolojiPreparatiDurumuPathologyMaterial.HeaderText = i18n("M20470", "Preparat Durumu");
        this.PatolojiPreparatiDurumuPathologyMaterial.Name = "PatolojiPreparatiDurumuPathologyMaterial";
        this.PatolojiPreparatiDurumuPathologyMaterial.Width = 300;

        this.MorfolojiKoduPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.MorfolojiKoduPathologyMaterial.ListDefName = "SKRSICDOMORFOLOJIKODUList";
        this.MorfolojiKoduPathologyMaterial.DataMember = "MorfolojiKodu";
        this.MorfolojiKoduPathologyMaterial.DisplayIndex = 6;
        this.MorfolojiKoduPathologyMaterial.HeaderText = i18n("M19123", "Morfoloji Kodu");
        this.MorfolojiKoduPathologyMaterial.Name = "MorfolojiKoduPathologyMaterial";
        this.MorfolojiKoduPathologyMaterial.Width = 300;

        this.ClinicalFindingsPathologyMaterial = new TTVisual.TTTextBoxColumn();
        this.ClinicalFindingsPathologyMaterial.DataMember = "ClinicalFindings";
        this.ClinicalFindingsPathologyMaterial.DisplayIndex = 7;
        this.ClinicalFindingsPathologyMaterial.HeaderText = i18n("M17626", "Klinik Bulgular");
        this.ClinicalFindingsPathologyMaterial.Name = "ClinicalFindingsPathologyMaterial";
        this.ClinicalFindingsPathologyMaterial.Width = 80;

        this.DescriptionPathologyMaterial = new TTVisual.TTTextBoxColumn();
        this.DescriptionPathologyMaterial.DataMember = "Description";
        this.DescriptionPathologyMaterial.DisplayIndex = 8;
        this.DescriptionPathologyMaterial.HeaderText = i18n("M10469", "Açıklama");
        this.DescriptionPathologyMaterial.Name = "DescriptionPathologyMaterial";
        this.DescriptionPathologyMaterial.Width = 80;

        this.MacroscopyPathologyMaterial = new TTVisual.TTRichTextBoxControlColumn();
        this.MacroscopyPathologyMaterial.DataMember = "Macroscopy";
        this.MacroscopyPathologyMaterial.DisplayIndex = 9;
        this.MacroscopyPathologyMaterial.HeaderText = i18n("M18492", "Makroskopi");
        this.MacroscopyPathologyMaterial.Name = "MacroscopyPathologyMaterial";
        this.MacroscopyPathologyMaterial.Width = 80;

        this.MicroscopyPathologyMaterial = new TTVisual.TTRichTextBoxControlColumn();
        this.MicroscopyPathologyMaterial.DataMember = "Microscopy";
        this.MicroscopyPathologyMaterial.DisplayIndex = 10;
        this.MicroscopyPathologyMaterial.HeaderText = i18n("M19027", "Mikroskopi");
        this.MicroscopyPathologyMaterial.Name = "MicroscopyPathologyMaterial";
        this.MicroscopyPathologyMaterial.Width = 80;

        this.NotePathologyMaterial = new TTVisual.TTRichTextBoxControlColumn();
        this.NotePathologyMaterial.DataMember = "Note";
        this.NotePathologyMaterial.DisplayIndex = 11;
        this.NotePathologyMaterial.HeaderText = "Not/Yorum";
        this.NotePathologyMaterial.Name = "NotePathologyMaterial";
        this.NotePathologyMaterial.Width = 80;

        this.Consumables = new TTVisual.TTTabPage();
        this.Consumables.DisplayIndex = 1;
        this.Consumables.TabIndex = 1;
        this.Consumables.Text = i18n("M20263", "Patoloji Sarf Malzemeler");
        this.Consumables.Name = "Consumables";

        this.TreatmentMaterials = new TTVisual.TTGrid();
        this.TreatmentMaterials.Name = "TreatmentMaterials";
        this.TreatmentMaterials.TabIndex = 0;

        this.ActionDateBaseTreatmentMaterial = new TTVisual.TTDateTimePickerColumn();
        this.ActionDateBaseTreatmentMaterial.DataMember = "ActionDate";
        this.ActionDateBaseTreatmentMaterial.DisplayIndex = 0;
        this.ActionDateBaseTreatmentMaterial.HeaderText = "Tarih";
        this.ActionDateBaseTreatmentMaterial.Name = "ActionDateBaseTreatmentMaterial";
        this.ActionDateBaseTreatmentMaterial.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M21314", "Sarf Edilen Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 300;

        this.AmountBaseTreatmentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountBaseTreatmentMaterial.DataMember = "Amount";
        this.AmountBaseTreatmentMaterial.DisplayIndex = 2;
        this.AmountBaseTreatmentMaterial.HeaderText = i18n("M19030", "Miktar");
        this.AmountBaseTreatmentMaterial.Name = "AmountBaseTreatmentMaterial";
        this.AmountBaseTreatmentMaterial.Width = 80;

        this.UBBCodeBaseTreatmentMaterial = new TTVisual.TTTextBoxColumn();
        this.UBBCodeBaseTreatmentMaterial.DataMember = "UBBCode";
        this.UBBCodeBaseTreatmentMaterial.DisplayIndex = 3;
        this.UBBCodeBaseTreatmentMaterial.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCodeBaseTreatmentMaterial.Name = "UBBCodeBaseTreatmentMaterial";
        this.UBBCodeBaseTreatmentMaterial.Width = 80;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 4;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 5;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.Width = 100;

        this.MatPrtNoString = new TTVisual.TTTextBox();
        this.MatPrtNoString.Required = true;
        this.MatPrtNoString.BackColor = "#F0F0F0";
        this.MatPrtNoString.Enabled = false;
        this.MatPrtNoString.Name = "MatPrtNoString";
        this.MatPrtNoString.TabIndex = 4;

        this.labelAssistantDoctor = new TTVisual.TTLabel();
        this.labelAssistantDoctor.Text = "Asistan Doktor";
        this.labelAssistantDoctor.Name = "labelAssistantDoctor";
        this.labelAssistantDoctor.TabIndex = 9;

        this.AssistantDoctor = new TTVisual.TTObjectListBox();
        this.AssistantDoctor.ListDefName = "DoctorListDefinition";
        this.AssistantDoctor.Name = "AssistantDoctor";
        this.AssistantDoctor.TabIndex = 8;

        this.labelMatPrtNoString = new TTVisual.TTLabel();
        this.labelMatPrtNoString.Text = i18n("M20567", "Protokol Numarası");
        this.labelMatPrtNoString.Name = "labelMatPrtNoString";
        this.labelMatPrtNoString.TabIndex = 5;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16928", "İşlemi Yapan Doktor");
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 3;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 2;

        this.labelSpecialDoctor = new TTVisual.TTLabel();
        this.labelSpecialDoctor.Text = "Uzman Tabip";
        this.labelSpecialDoctor.Name = "labelSpecialDoctor";
        this.labelSpecialDoctor.TabIndex = 1;

        this.SpecialDoctor = new TTVisual.TTObjectListBox();
        this.SpecialDoctor.ListDefName = "DoctorListDefinition";
        this.SpecialDoctor.Name = "SpecialDoctor";
        this.SpecialDoctor.TabIndex = 0;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 22;

        this.EpisodeDiagnosisTab = new TTVisual.TTTabPage();
        this.EpisodeDiagnosisTab.DisplayIndex = 0;
        this.EpisodeDiagnosisTab.TabIndex = 0;
        this.EpisodeDiagnosisTab.Text = i18n("M24028", "Vaka Tanıları");
        this.EpisodeDiagnosisTab.Name = "EpisodeDiagnosisTab";

        this.DiagnosisDiagnosisGrid = new TTVisual.TTGrid();
        this.DiagnosisDiagnosisGrid.Name = "DiagnosisDiagnosisGrid";
        this.DiagnosisDiagnosisGrid.TabIndex = 16;

        this.DiagnoseDiagnosisGrid = new TTVisual.TTListBoxColumn();
        this.DiagnoseDiagnosisGrid.ListDefName = "DiagnosisDefinitionList";
        this.DiagnoseDiagnosisGrid.DataMember = "Diagnose";
        this.DiagnoseDiagnosisGrid.DisplayIndex = 0;
        this.DiagnoseDiagnosisGrid.HeaderText = i18n("M22736", "Tanı");
        this.DiagnoseDiagnosisGrid.Name = "DiagnoseDiagnosisGrid";
        this.DiagnoseDiagnosisGrid.Width = 330;

        this.DiagnosisTypeDiagnosisGrid = new TTVisual.TTEnumComboBoxColumn();
        this.DiagnosisTypeDiagnosisGrid.DataTypeName = "DiagnosisTypeEnum";
        this.DiagnosisTypeDiagnosisGrid.DataMember = "DiagnosisType";
        this.DiagnosisTypeDiagnosisGrid.DisplayIndex = 1;
        this.DiagnosisTypeDiagnosisGrid.HeaderText = i18n("M22781", "Tanı Tipi");
        this.DiagnosisTypeDiagnosisGrid.Name = "DiagnosisTypeDiagnosisGrid";
        this.DiagnosisTypeDiagnosisGrid.Width = 80;

        this.PathologyMaterialColumns = [this.MaterialNumberPathologyMaterial, this.DateOfSampleTakenPathologyMaterial, this.YerlesimYeriPathologyMaterial, this.AlindigiDokununTemelOzelligiPathologyMaterial, this.NumuneAlinmaSekliPathologyMaterial, this.PatolojiPreparatiDurumuPathologyMaterial, this.MorfolojiKoduPathologyMaterial, this.ClinicalFindingsPathologyMaterial, this.DescriptionPathologyMaterial, this.MacroscopyPathologyMaterial, this.MicroscopyPathologyMaterial, this.NotePathologyMaterial];
        this.TreatmentMaterialsColumns = [this.ActionDateBaseTreatmentMaterial, this.Material, this.AmountBaseTreatmentMaterial, this.UBBCodeBaseTreatmentMaterial, this.Barcode, this.DistributionType];
        this.DiagnosisDiagnosisGridColumns = [this.DiagnoseDiagnosisGrid, this.DiagnosisTypeDiagnosisGrid];
        this.tttabcontrol1.Controls = [this.Materials, this.Consumables];
        this.Materials.Controls = [this.PathologyMaterial];
        this.Consumables.Controls = [this.TreatmentMaterials];
        this.tttabcontrol2.Controls = [this.EpisodeDiagnosisTab];
        this.EpisodeDiagnosisTab.Controls = [this.DiagnosisDiagnosisGrid];
        this.Controls = [this.labelRequestDate, this.RequestDate, this.labelApproveDate, this.ApproveDate, this.SendToApproveDate, this.labelReportDate, this.ReportDate, this.labelTechnicianNote, this.TechnicianNote, this.AcceptionNotePathologyRequest, this.PhoneNumberResUser, this.labelAcceptionNotePathologyRequest, this.labelAcceptionDatePathologyRequest, this.AcceptionDatePathologyRequest, this.labelPhysicalExaminationEpisode, this.PhysicalExaminationEpisode, this.labelComplaintEpisode, this.ComplaintEpisode, this.labelPhoneNumberResUser, this.labelRequestDoctorPathologyRequest, this.RequestDoctorPathologyRequest, this.tttabcontrol1, this.Materials, this.PathologyMaterial, this.MaterialNumberPathologyMaterial, this.DateOfSampleTakenPathologyMaterial, this.YerlesimYeriPathologyMaterial, this.AlindigiDokununTemelOzelligiPathologyMaterial, this.NumuneAlinmaSekliPathologyMaterial, this.PatolojiPreparatiDurumuPathologyMaterial, this.MorfolojiKoduPathologyMaterial, this.ClinicalFindingsPathologyMaterial, this.DescriptionPathologyMaterial, this.MacroscopyPathologyMaterial, this.MicroscopyPathologyMaterial, this.NotePathologyMaterial, this.Consumables, this.TreatmentMaterials, this.ActionDateBaseTreatmentMaterial, this.Material, this.AmountBaseTreatmentMaterial, this.UBBCodeBaseTreatmentMaterial, this.Barcode, this.DistributionType, this.MatPrtNoString, this.labelAssistantDoctor, this.AssistantDoctor, this.labelMatPrtNoString, this.labelProcedureDoctor, this.ProcedureDoctor, this.labelSpecialDoctor, this.SpecialDoctor, this.tttabcontrol2, this.EpisodeDiagnosisTab, this.DiagnosisDiagnosisGrid, this.DiagnoseDiagnosisGrid, this.DiagnosisTypeDiagnosisGrid];

    }

    GenerateMaterialsListColumns() {
        let that = this;

        this.PathologyMaterialsListColumns = [
            {
                caption: i18n("M18694", "Material Arşiv Numarası"),
                dataField: 'MaterialNumber',
                allowEditing: false,
                allowSorting: false,
                fixed: true,
                width: '10%'
            },
            {
                caption: i18n("M19537", "Numune Alınma Tarihi"),
                dataField: 'DateOfSampleTaken',
                allowEditing: false,
                fixed: true,
                allowSorting: false,
                dataType: 'date',
                format: 'dd/MM/yyyy',
                width: '10%'
            },
            {
                caption: i18n("M18694", "Material Arşiv Numarası"),
                dataField: 'MaterialNumber',
                allowEditing: false,
                allowSorting: false,
                fixed: true,
                width: '10%'
            }
            , {
                caption: i18n("M10716", "Alındığı Organ"),
                dataField: 'YerlesimYeri.ObjectID',
                fixed: true, width: '10%',
                allowSorting: false,
                allowEditing: false,
                lookup: {
                    dataSource: that.yerlesimYeriArray, valueExpr: 'ObjectID', displayExpr: 'KODTANIMI'
                }
            },
            {
                caption: i18n("M10715", "Alındığı Dokunun Temel Özelliği"),
                dataField: 'AlindigiDokununTemelOzelligi.ObjectID',
                fixed: true, width: '10%',
                allowSorting: false,
                allowEditing: false,
                lookup: {
                    dataSource: that.alindigiDokununTemelOzelligiArray, valueExpr: 'ObjectID', displayExpr: 'ADI'
                }
            },
            {
                caption: i18n("M10718", "Alınma Şekli"),
                dataField: i18n("M19547", "NumuneAlinmaSekli.ObjectID"),
                fixed: true,
                width: '10%',
                allowSorting: false,
                allowEditing: false,
                lookup: {
                    dataSource: that.numuneAlinmaSekliArray, valueExpr: 'ObjectID', displayExpr: 'ADI'
                }
            },
            {
                caption: i18n("M17626", "Klinik Bulgular"),
                dataField: 'ClinicalFindings',
                fixed: true,
                width: '20%',
                allowSorting: false,
                allowEditing: false
            },
            {
                caption: i18n("M10469", "Açıklama"),
                dataField: 'Description',
                fixed: true,
                width: '20%',
                allowSorting: false,
                allowEditing: false
            }
        ];

    }

    private async YerlesimYeri(): Promise<any> {
        if (!this.YerlesimYeriCache) {
            this.YerlesimYeriCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSYerlesimYeri');
            return this.YerlesimYeriCache;
        }
        else {
            return this.YerlesimYeriCache;
        }
    }

    private async AlindigiDokununTemelOzelligi(): Promise<any> {
        if (!this.AlindigiDokununTemelOzelligiCache) {
            this.AlindigiDokununTemelOzelligiCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSAlindigiDokununTemelOzelligi');
            return this.AlindigiDokununTemelOzelligiCache;
        }
        else {
            return this.AlindigiDokununTemelOzelligiCache;
        }
    }
    private async NumuneAlinmaSekli(): Promise<any> {
        if (!this.NumuneAlinmaSekliCache) {
            this.NumuneAlinmaSekliCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSNumuneAlinmaSekli');
            return this.NumuneAlinmaSekliCache;
        }
        else {
            return this.NumuneAlinmaSekliCache;
        }

    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {

        if (transDef != null) {
            if (transDef.ToStateDefID == Pathology.PathologyStates.Approvement) {
                //Materyallerin makroskopi ya da mikroskopisinden herhangi biri yazılmadan onaylanamaz.
                //Üzerinde işlem olmayan materyal varsa onaylanamaz.
                //Materyallerin preparat durumu ve morfolojik kodu seçilmeden rapor onaylanamaz.

                let result: string = this.confirmApprove();
                if (result != "")
                    throw new Exception(result);

            }
        }

    }

    confirmApprove(): string {
        let flagReport = false;
        //var flagProcedure = false;
        let flagSKRS = false;
        let procedureFound = false;

        for (let i = 0; i < this.pathologyMainFormViewModel._Pathology.PathologyMaterial.length; i++) {

            if ((this.pathologyMainFormViewModel._Pathology.PathologyMaterial[i].Macroscopy == undefined || this.pathologyMainFormViewModel._Pathology.PathologyMaterial[i].Macroscopy == null) && (this.pathologyMainFormViewModel._Pathology.PathologyMaterial[i].Microscopy == undefined || this.pathologyMainFormViewModel._Pathology.PathologyMaterial[i].Microscopy == null)) {
                flagReport = true;
            }
            procedureFound = false;
            for (let j = 0; j < this.pathologyMainFormViewModel._RequestedPathologyProceduresArray.length; j++) {
                if (this.pathologyMainFormViewModel._Pathology.PathologyMaterial[i].ObjectID == this.pathologyMainFormViewModel._RequestedPathologyProceduresArray[j].MaterialObjectID) {
                    procedureFound = true;
                }
                if (procedureFound)
                    break;
            }


            if (this.pathologyMainFormViewModel._Pathology.PathologyMaterial[i].PatolojiPreparatiDurumu == undefined || this.pathologyMainFormViewModel._Pathology.PathologyMaterial[i].MorfolojiKodu == undefined) {
                flagSKRS = true;
            }


            if (flagReport || !procedureFound || flagSKRS)
                break;
        }
        if (flagReport)
            return i18n("M18708", "Materyallerin Makroskopi ya da Mikroskopilerinden Herhangi Biri Doldurulmadan Onay İşlemine Devam Edemezsiniz.");
        if (!procedureFound)
            return i18n("M18707", "Materyallere Tetkik Eklemeden Onay İşlemine Devam Edemezsiniz.");
        if (flagSKRS)
            return i18n("M18709", "Materyallerin Preparat Durumu ve Morfolojik Kodu Seçilmeden Onay İşlemine Devam Edemezsiniz.");

        if (this.pathologyMainFormViewModel._Pathology.ProcedureDoctor == undefined)
            return i18n("M16919", "İşlemi Uygulayan Doktoru Seçmeden Onay İşlemine Devam Edemezsiniz.");
        return "";

    }

    protected async ClientSidePreScript() {
        if (this.pathologyMainFormViewModel._Pathology.CurrentStateDefID == Pathology.PathologyStates.Approvement || this.pathologyMainFormViewModel._Pathology.CurrentStateDefID == Pathology.PathologyStates.Report) {
            this.ReadOnly = true;
            this.isReadOnly = true;
        }

        this.httpService.get<string>("api/PathologyService/CheckUnapprovedPathologyReports?PathologyID=" + this.pathologyMainFormViewModel._Pathology.ObjectID).then(result => {

             //Uyarı
            if (result != "")
                TTVisual.InfoBox.Alert(result);
              

        }).catch(error => {
            this.messageService.showError(error);
        });



       

    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);

        await this.load(PathologyMainFormViewModel);
    }


    openAdditionalReport()
    {
        let that = this;
        this.httpService.get<string>("api/PathologyService/CheckAdditionalReport?PathologyID=" + this.pathologyMainFormViewModel._Pathology.ObjectID).then(result => {

            let additionalReportID: string = result;

            that.showAdditionalReport(additionalReportID);

        }).catch(error => {
            this.messageService.showError(error);
        });
    }

    showAdditionalReport(PathologyAdditionalReportID:string): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "PathologyAdditionalReportForm";
            componentInfo.ModuleName = "PatolojiModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Patoloji_Modulu/PatolojiModule";
            //if (this.pathologyMainFormViewModel._Pathology.PathologyAdditionalReport.length > 0)
                componentInfo.InputParam = new DynamicComponentInputParam(PathologyAdditionalReportID, new ActiveIDsModel(this._Pathology.ObjectID, null, null));
            //else
            //    componentInfo.InputParam = new DynamicComponentInputParam("", new ActiveIDsModel(this._Pathology.ObjectID, null, null));
   

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20228", "Patoloji Ek Rapor");
            modalInfo.Width = 800;
            modalInfo.Height = 450;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async setInputParam(value: string) {

        if (value != null && value != undefined) {
            this.ObjectID = new Guid(value);
            this.ReadOnly = true;
            this._showStateButtons = false;
        }

    }

    public ngOnDestroy(): void {
        //this.RemoveMenuFromHelpMenu();
    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

     
            //let pathologyReport = new DynamicSidebarMenuItem();
            //pathologyReport.key = 'pathologyReport';
            //pathologyReport.icon = 'far fa-file-alt';
            //pathologyReport.label = 'Patoloji Raporu';
            //pathologyReport.componentInstance = this;
            //pathologyReport.clickFunction = this.openPathologyReport;
            //this.sideBarMenuService.addMenu('YardimciMenu', pathologyReport);

            let newPathologyResultReport = new DynamicSidebarMenuItem();
            newPathologyResultReport.key = 'newPathologyResultReport';
            newPathologyResultReport.icon = 'far fa-file-alt';
            newPathologyResultReport.label = 'Patoloji Sonuç Raporu';
            newPathologyResultReport.componentInstance = this;
            newPathologyResultReport.clickFunction = this.openNewPathologyResultReport;
            this.sideBarMenuService.addMenu('YardimciMenu', newPathologyResultReport);
        if (this.pathologyMainFormViewModel._Pathology.CurrentStateDefID == Pathology.PathologyStates.Report) {

            let additionalReport = new DynamicSidebarMenuItem();
            additionalReport.key = 'additionalReport';
            additionalReport.icon = 'far fa-file-alt';
            additionalReport.label = 'Ek Rapor';
            additionalReport.componentInstance = this;
            additionalReport.clickFunction = this.openAdditionalReport;
            this.sideBarMenuService.addMenu('YardimciMenu', additionalReport);
        }

     /*   let pathologyResultReport = new DynamicSidebarMenuItem();
        pathologyResultReport.key = 'pathologyResultReport';
        pathologyResultReport.icon = 'far fa-file-alt';
        pathologyResultReport.label = 'Patoloji Sonuç Raporu';
        pathologyResultReport.componentInstance = this;
        pathologyResultReport.clickFunction = this.OpenPathologyResultReportNew;
        this.sideBarMenuService.addMenu('YardimciMenu', pathologyResultReport);*/

      

        let panicBildirim = new DynamicSidebarMenuItem();
        panicBildirim.key = 'panicBildirim';
        panicBildirim.icon = 'fas fa-bell';
        panicBildirim.label = 'Panik Bildirim';
        panicBildirim.componentInstance = this;
        panicBildirim.clickFunction = this.openPanicBildirimForm;
        this.sideBarMenuService.addMenu('YardimciMenu', panicBildirim);


        let pathologyBarcode = new DynamicSidebarMenuItem();
        pathologyBarcode.key = 'pathologyBarcode';
        pathologyBarcode.icon = 'ai ai-barkod-bas';
        pathologyBarcode.label = 'Patoloji Barkodu';
        pathologyBarcode.componentInstance = this;
        pathologyBarcode.clickFunction = this.printPathologyBarcode;
        this.sideBarMenuService.addMenu('Barkod', pathologyBarcode);

        let radiologyHistory = new DynamicSidebarMenuItem();
        radiologyHistory.key = 'radiologyHistory';
        radiologyHistory.icon = 'glyphicon glyphicon-cd';
        radiologyHistory.label = 'Radyoloji Sonuçları';
        radiologyHistory.componentInstance = this.helpMenuService;
        radiologyHistory.clickFunction = this.helpMenuService.openRadiologyHistory;
        radiologyHistory.parameterFunctionInstance = this;
        radiologyHistory.getParamsFunction = this.getClickFunctionParamsForPathology;
        radiologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', radiologyHistory);

        let pathologyHistory = new DynamicSidebarMenuItem();
        pathologyHistory.key = 'pathologyHistory';
        pathologyHistory.icon = 'fas fa-notes-medical';
        pathologyHistory.label = 'Patoloji Sonuçları';
        pathologyHistory.componentInstance = this.helpMenuService;
        pathologyHistory.clickFunction = this.helpMenuService.openPathologyHistory;
        pathologyHistory.parameterFunctionInstance = this;
        pathologyHistory.getParamsFunction = this.getClickFunctionParamsForPathology;
        pathologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', pathologyHistory);

        let testHistory = new DynamicSidebarMenuItem();
        testHistory.key = 'testHistory';
        testHistory.icon = 'fa fa-flask';
        testHistory.label = 'Laboratuvar Sonuçları';
        testHistory.componentInstance = this.helpMenuService;
        testHistory.clickFunction = this.helpMenuService.openTestHistory;
        testHistory.parameterFunctionInstance = this;
        testHistory.getParamsFunction = this.getClickFunctionParamsForPathology;
        testHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', testHistory);

    }

    public getClickFunctionParamsForPathology(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams;

        if (typeof this._EpisodeAction.Episode.Patient == "string") 
            clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient ));
        else
            clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient.ObjectID));

        return clickFunctionParams;
    }

    private RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('pathologyReport');
        this.sideBarMenuService.removeMenu('additionalReport');
        this.sideBarMenuService.removeMenu('panicBildirim');
        this.sideBarMenuService.removeMenu('pathologyBarcode');
      //this.sideBarMenuService.removeMenu('pathologyResultReport');
        this.sideBarMenuService.removeMenu('newPathologyResultReport');
        this.sideBarMenuService.removeMenu('radiologyHistory');
        this.sideBarMenuService.removeMenu('pathologyHistory');
        this.sideBarMenuService.removeMenu('testHistory');
    }


    openPathologyReport() {

        const objectIdParam = new GuidParam(this.pathologyMainFormViewModel._Pathology.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('PathologyResultReportNew', reportParameters);

    }

    openPanicBildirimForm()
    {
        let that = this;
        this.httpService.get<string>("api/PathologyService/CheckPanicAlert?PathologyID=" + this.pathologyMainFormViewModel._Pathology.ObjectID).then(result => {

            let panicAlertID: string = result;

            that.showPanicBildirimForm(panicAlertID);

        }).catch(error => {
            this.messageService.showError(error);
        });
    }

    showPanicBildirimForm(panicAlertID:string) {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "PanicAlertForm";
            componentInfo.ModuleName = "PatolojiModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Patoloji_Modulu/PatolojiModule";
            //if (this.pathologyMainFormViewModel._Pathology.PathologyPanicAlert != null && this.pathologyMainFormViewModel._Pathology.PathologyPanicAlert != undefined && this.pathologyMainFormViewModel._Pathology.PathologyPanicAlert.length > 0)
                componentInfo.InputParam = new DynamicComponentInputParam(panicAlertID, new ActiveIDsModel(this._Pathology.ObjectID, null, null));
           // else
            //    componentInfo.InputParam = "";

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Panik Bildirim"
            modalInfo.Width = 400;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    printPathologyBarcode() {

    }

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;
    }

    public openNewPathologyResultReport(): Promise<ModalActionResult>
    {
        let disablePrintButton: boolean = false;
        if (this.pathologyMainFormViewModel._Pathology.CurrentStateDefID != Pathology.PathologyStates.Report)
            disablePrintButton = true;

        let reportData: DynamicReportParameters = {

            Code : 'PATOLOJISONUCRAPOR',
            ReportParams: { ObjectID: this._Pathology.ObjectID },
            ViewerMode: true,
            DisablePrintButtons: disablePrintButton
        };
  
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "PATOLOJİ SONUÇ RAPORU"

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
