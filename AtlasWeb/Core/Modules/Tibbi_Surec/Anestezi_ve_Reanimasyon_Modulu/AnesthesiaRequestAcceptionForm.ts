//$5CCD9D3E
import { Component, OnInit, NgZone } from '@angular/core';
import { AnesthesiaRequestAcceptionFormViewModel } from './AnesthesiaRequestAcceptionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AnesthesiaAndReanimation } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { AnesthesiaAndReanimationRequestedProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


import { Exception } from 'NebulaClient/Mscorlib/Exception';

@Component({
    selector: 'AnesthesiaRequestAcceptionForm',
    templateUrl: './AnesthesiaRequestAcceptionForm.html',
    providers: [MessageService]
})
export class AnesthesiaRequestAcceptionForm extends EpisodeActionForm implements OnInit {
    AnesthesiaPersonnel: TTVisual.ITTListBoxColumn;
    ApprovalFormGiven: TTVisual.ITTCheckBox;
    ASAType: TTVisual.ITTEnumComboBox;
    CAProcedureObject: TTVisual.ITTListBoxColumn;
    DescriptionOfObj: TTVisual.ITTRichTextBoxControlColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridAnesthesiaPersonnels: TTVisual.ITTGrid;
    GridDiagnosis: TTVisual.ITTGrid;
    GridSurgeryProcedures: TTVisual.ITTGrid;
    labelASAType: TTVisual.ITTLabel;
    labelPlannedSurgeryDescription: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    LabelRequest: TTVisual.ITTLabel;
    labelRequestNote: TTVisual.ITTLabel;
    PlannedSurgeryDescription: TTVisual.ITTTextBox;
    Procedure: TTVisual.ITTListBoxColumn;
    ProtocolNo: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    RequestedProcedure: TTVisual.ITTGrid;
    RequestNote: TTVisual.ITTTextBox;
    SuggestedAnesthesiaTechnique: TTVisual.ITTEnumComboBoxColumn;
    SuggestedAnesthesiaTechniqueGrid: TTVisual.ITTGrid;
    PlannedAnesthsiaDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    ttrichtextboxcontrolConsultationNote: TTVisual.ITTRichTextBoxControl;
    public GridAnesthesiaPersonnelsColumns = [];
    public GridDiagnosisColumns = [];
    public GridSurgeryProceduresColumns = [];
    public RequestedProcedureColumns = [];
    public SuggestedAnesthesiaTechniqueGridColumns = [];
    public anesthesiaRequestAcceptionFormViewModel: AnesthesiaRequestAcceptionFormViewModel = new AnesthesiaRequestAcceptionFormViewModel();
    public get _AnesthesiaAndReanimation(): AnesthesiaAndReanimation {
        return this._TTObject as AnesthesiaAndReanimation;
    }
    private AnesthesiaRequestAcceptionForm_DocumentUrl: string = '/api/AnesthesiaAndReanimationService/AnesthesiaRequestAcceptionForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.AnesthesiaRequestAcceptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public isFiredBySurgery: Boolean;

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        if (transDef != null) {
            if (transDef.ToStateDefID == AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.ReturnedToDoctor) {
                if (this._AnesthesiaAndReanimation.ReasonOfReject == null)
                {
                    throw new Exception(i18n("M16072", "İade Sebebi girilmeden doktora iade edilemez"));
                }
            }
            else if (transDef.ToStateDefID.valueOf() == AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.AnesthesiaExpend.id || transDef.ToStateDefID.valueOf() == AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.SurgeryAnestesia.id) {
                this._AnesthesiaAndReanimation.IsPatientApprovalFormGiven = await this.GetIfPatientApprovalFormIsGiven(this._AnesthesiaAndReanimation.IsPatientApprovalFormGiven);
            }
        }
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.DropStateButton(AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.Cancelled);
        if (this._AnesthesiaAndReanimation.MainSurgery == null) {
            //this.RequestedProcedure.Visible = true;
            //this.labelPlannedSurgeryDescription.Visible = false;
            //this.PlannedSurgeryDescription.Visible = false;
            //this.GridSurgeryProcedures.Visible = false;
            this.isFiredBySurgery = false;
            this.DropStateButton(AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.SurgeryAnestesia);
        }
        else {
            //this.RequestedProcedure.Visible = false;
            //this.labelPlannedSurgeryDescription.Visible = true;
            //this.PlannedSurgeryDescription.Visible = true;
            //this.GridSurgeryProcedures.Visible = true;
            this.isFiredBySurgery = true;
            this.DropStateButton(AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.AnesthesiaExpend);
            if (this.anesthesiaRequestAcceptionFormViewModel.isSurgeryDelay) {
                TTVisual.InfoBox.Show((await SystemMessageService.GetMessage(208)));
            }
        }
    }

    // *****Method declarations end *****


    public initViewModel(): void {
        this._TTObject = new AnesthesiaAndReanimation();
        this.anesthesiaRequestAcceptionFormViewModel = new AnesthesiaRequestAcceptionFormViewModel();
        this._ViewModel = this.anesthesiaRequestAcceptionFormViewModel;
        this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation = this._TTObject as AnesthesiaAndReanimation;
        //this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.SuggestedAnesthesiaTechniques = new Array<AnesthesiaAndReanimationSuggestedTechniqueGrid>();
        this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.RequestedProcedure = new Array<AnesthesiaAndReanimationRequestedProcedure>();
        this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.MainSurgery = new Surgery();
        this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.MainSurgery.SurgeryProcedures = new Array<SurgeryProcedure>();
        this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.Episode = new Episode();
        this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.Episode.Diagnosis = new Array<DiagnosisGrid>();
        //this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.AnesthesiaSuggestedPersonnel = new Array<AnesthesiaSuggestedPersonnel>();
    }

    protected loadViewModel() {
        let that = this;

        that.anesthesiaRequestAcceptionFormViewModel = this._ViewModel as AnesthesiaRequestAcceptionFormViewModel;
        that._TTObject = this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation;
        if (this.anesthesiaRequestAcceptionFormViewModel == null)
            this.anesthesiaRequestAcceptionFormViewModel = new AnesthesiaRequestAcceptionFormViewModel();
        if (this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation == null)
            this.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation = new AnesthesiaAndReanimation();
        that.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.RequestedProcedure = that.anesthesiaRequestAcceptionFormViewModel.RequestedProcedureGridList;
        for (let detailItem of that.anesthesiaRequestAcceptionFormViewModel.RequestedProcedureGridList) {
            let procedureObjectID = detailItem["Procedure"];
            if (procedureObjectID != null && (typeof procedureObjectID === 'string')) {
                let procedure = that.anesthesiaRequestAcceptionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectID.toString());
                 if (procedure) {
                    detailItem.Procedure = procedure;
                }
            }
        }
        let mainSurgeryObjectID = that.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation["MainSurgery"];
        if (mainSurgeryObjectID != null && (typeof mainSurgeryObjectID === 'string')) {
            let mainSurgery = that.anesthesiaRequestAcceptionFormViewModel.Surgerys.find(o => o.ObjectID.toString() === mainSurgeryObjectID.toString());
             if (mainSurgery) {
                that.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.MainSurgery = mainSurgery;
            }
            if (mainSurgery != null) {
                mainSurgery.SurgeryProcedures = that.anesthesiaRequestAcceptionFormViewModel.GridSurgeryProceduresGridList;
                for (let detailItem of that.anesthesiaRequestAcceptionFormViewModel.GridSurgeryProceduresGridList) {
                    let procedureObjectObjectID = detailItem["ProcedureObject"];
                    if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                        let procedureObject = that.anesthesiaRequestAcceptionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                         if (procedureObject) {
                            detailItem.ProcedureObject = procedureObject;
                        }
                    }
                }
            }
        }
        let episodeObjectID = that.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.anesthesiaRequestAcceptionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.anesthesiaRequestAcceptionFormViewModel._AnesthesiaAndReanimation.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.anesthesiaRequestAcceptionFormViewModel.GridDiagnosisGridList;
                for (let detailItem of that.anesthesiaRequestAcceptionFormViewModel.GridDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.anesthesiaRequestAcceptionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.anesthesiaRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }

    }


    async ngOnInit()  {
        let that = this;
        await this.load(AnesthesiaRequestAcceptionFormViewModel);
  
    }


    public onApprovalFormGivenChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.IsPatientApprovalFormGiven != event) {
                this._AnesthesiaAndReanimation.IsPatientApprovalFormGiven = event;
            }
        }
    }

    public onASATypeChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ASAType != event) {
                this._AnesthesiaAndReanimation.ASAType = event;
            }
        }
    }

    public onPlannedSurgeryDescriptionChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null &&
                this._AnesthesiaAndReanimation.MainSurgery != null && this._AnesthesiaAndReanimation.MainSurgery.PlannedSurgeryDescription != event) {
                this._AnesthesiaAndReanimation.MainSurgery.PlannedSurgeryDescription = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ProtocolNo != event) {
                this._AnesthesiaAndReanimation.ProtocolNo = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.RequestDate != event) {
                this._AnesthesiaAndReanimation.RequestDate = event;
            }
        }
    }

    public onRequestNoteChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.RequestNote != event) {
                this._AnesthesiaAndReanimation.RequestNote = event;
            }
        }
    }

    public onttdatetimepicker3Changed(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.PlannedAnesthesiaDate != event) {
                this._AnesthesiaAndReanimation.PlannedAnesthesiaDate = event;
            }
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ReasonOfReject != event) {
                this._AnesthesiaAndReanimation.ReasonOfReject = event;
            }
        }
    }

    public onttrichtextboxcontrolConsultationNoteChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.AnesthesiaNote != event) {
                this._AnesthesiaAndReanimation.AnesthesiaNote = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.PlannedAnesthsiaDate, "Value", this.__ttObject, "PlannedAnesthesiaDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.ApprovalFormGiven, "Value", this.__ttObject, "IsPatientApprovalFormGiven");
        redirectProperty(this.RequestNote, "Text", this.__ttObject, "RequestNote");
        redirectProperty(this.PlannedSurgeryDescription, "Text", this.__ttObject, "MainSurgery.PlannedSurgeryDescription");
        redirectProperty(this.ASAType, "Value", this.__ttObject, "ASAType");
        redirectProperty(this.ttrichtextboxcontrolConsultationNote, "Rtf", this.__ttObject, "AnesthesiaNote");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "ReasonOfReject");
    }

    public initFormControls(): void {
        this.SuggestedAnesthesiaTechniqueGrid = new TTVisual.TTGrid();
        this.SuggestedAnesthesiaTechniqueGrid.BackColor = "#DCDCDC";
        this.SuggestedAnesthesiaTechniqueGrid.Name = "SuggestedAnesthesiaTechniqueGrid";
        this.SuggestedAnesthesiaTechniqueGrid.TabIndex = 4;
        this.SuggestedAnesthesiaTechniqueGrid.Height = 100;

        this.SuggestedAnesthesiaTechnique = new TTVisual.TTEnumComboBoxColumn();
        this.SuggestedAnesthesiaTechnique.DataTypeName = "AnesthesiaTechniqueEnum";
        this.SuggestedAnesthesiaTechnique.DataMember = "AnesthesiaTechnique";
        this.SuggestedAnesthesiaTechnique.DisplayIndex = 0;
        this.SuggestedAnesthesiaTechnique.HeaderText = i18n("M20031", "Öngörülen Anestezi Teknikleri");
        this.SuggestedAnesthesiaTechnique.Name = "SuggestedAnesthesiaTechnique";
        this.SuggestedAnesthesiaTechnique.Width = 550;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M20401", "Planlanan Uygulama Tarihi");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 95;

        this.PlannedAnesthsiaDate = new TTVisual.TTDateTimePicker();
        this.PlannedAnesthsiaDate.CustomFormat = "";
        this.PlannedAnesthsiaDate.Format = DateTimePickerFormat.Long;
        this.PlannedAnesthsiaDate.Name = "ttdatetimepicker3";
        this.PlannedAnesthsiaDate.TabIndex = 94;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10960", "Anestezi  Notu");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 93;

        this.ttrichtextboxcontrolConsultationNote = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrolConsultationNote.TemplateGroupName = "ANESTHESIANOTE";
        this.ttrichtextboxcontrolConsultationNote.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrolConsultationNote.Name = "ttrichtextboxcontrolConsultationNote";
        this.ttrichtextboxcontrolConsultationNote.TabIndex = 7;

        this.RequestedProcedure = new TTVisual.TTGrid();
        this.RequestedProcedure.BackColor = "#DCDCDC";
        this.RequestedProcedure.ReadOnly = true;
        this.RequestedProcedure.Name = "RequestedProcedure";
        this.RequestedProcedure.TabIndex = 59;
        this.RequestedProcedure.Height = 120;

        this.Procedure = new TTVisual.TTListBoxColumn();
        this.Procedure.ListDefName = "ProcedureListDefinition";
        this.Procedure.DataMember = "Procedure";
        this.Procedure.DisplayIndex = 0;
        this.Procedure.HeaderText = i18n("M10976", "Anestezi Gerektiren İşlemler");
        this.Procedure.Name = "Procedure";
        this.Procedure.Width = 800;

        this.LabelRequest = new TTVisual.TTLabel();
        this.LabelRequest.Text = i18n("M10979", "Anestezi İstek Tarihi");
        this.LabelRequest.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelRequest.ForeColor = "#000000";
        this.LabelRequest.Name = "LabelRequest";
        this.LabelRequest.TabIndex = 14;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 15;

        this.RequestNote = new TTVisual.TTTextBox();
        this.RequestNote.Multiline = true;
        this.RequestNote.BackColor = "#F0F0F0";
        this.RequestNote.ReadOnly = true;
        this.RequestNote.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestNote.Name = "RequestNote";
        this.RequestNote.TabIndex = 2;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 88;

        this.PlannedSurgeryDescription = new TTVisual.TTTextBox();
        this.PlannedSurgeryDescription.Multiline = true;
        this.PlannedSurgeryDescription.BackColor = "#F0F0F0";
        this.PlannedSurgeryDescription.ReadOnly = true;
        this.PlannedSurgeryDescription.Name = "PlannedSurgeryDescription";
        this.PlannedSurgeryDescription.TabIndex = 103;
        this.PlannedSurgeryDescription.Height = "128px";

        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.BackColor = "#DCDCDC";
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.ReadOnly = true;
        this.GridDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.TabIndex = 0;

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
        this.EpisodeDiagnoseDate.HeaderText = i18n("M22748", "Tanı Giriş   Tarihi");
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.labelRequestNote = new TTVisual.TTLabel();
        this.labelRequestNote.Text = i18n("M16637", "İstek Notu");
        this.labelRequestNote.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRequestNote.ForeColor = "#000000";
        this.labelRequestNote.Name = "labelRequestNote";
        this.labelRequestNote.TabIndex = 1;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 91;

        this.GridAnesthesiaPersonnels = new TTVisual.TTGrid();
        this.GridAnesthesiaPersonnels.BackColor = "#DCDCDC";
        this.GridAnesthesiaPersonnels.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridAnesthesiaPersonnels.Name = "GridAnesthesiaPersonnels";
        this.GridAnesthesiaPersonnels.TabIndex = 6;
        this.GridAnesthesiaPersonnels.Height = 100;

        this.AnesthesiaPersonnel = new TTVisual.TTListBoxColumn();
        this.AnesthesiaPersonnel.ListDefName = "AnaesthesiaTeamListDefinition";
        this.AnesthesiaPersonnel.DataMember = "AnesthesiaPersonnel";
        this.AnesthesiaPersonnel.DisplayIndex = 0;
        this.AnesthesiaPersonnel.HeaderText = i18n("M20030", "Öngörülen Anestezi Ekibi");
        this.AnesthesiaPersonnel.Name = "AnesthesiaPersonnel";
        this.AnesthesiaPersonnel.Width = 550;

        this.labelASAType = new TTVisual.TTLabel();
        this.labelASAType.Text = i18n("M11119", "ASA Kriteri");
        this.labelASAType.Name = "labelASAType";
        this.labelASAType.TabIndex = 22;

        this.ASAType = new TTVisual.TTEnumComboBox();
        this.ASAType.DataTypeName = "AnesthesiaASATypeEnum";
        this.ASAType.Name = "ASAType";
        this.ASAType.TabIndex = 5;

        this.ApprovalFormGiven = new TTVisual.TTCheckBox();
        this.ApprovalFormGiven.Value = false;
        this.ApprovalFormGiven.Title = i18n("M11306", "Aydınlatılmış Onam Formu");
        this.ApprovalFormGiven.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ApprovalFormGiven.Name = "ApprovalFormGiven";
        this.ApprovalFormGiven.TabIndex = 89;

        this.GridSurgeryProcedures = new TTVisual.TTGrid();
        this.GridSurgeryProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridSurgeryProcedures.Name = "GridSurgeryProcedures";
        this.GridSurgeryProcedures.TabIndex = 0;
        this.GridSurgeryProcedures.ReadOnly = true;
        this.GridSurgeryProcedures.Height = 100;
        this.GridSurgeryProcedures.AllowUserToAddRows = false;
        this.GridSurgeryProcedures.AllowUserToDeleteRows = false;

        this.CAProcedureObject = new TTVisual.TTListBoxColumn();
        this.CAProcedureObject.ListDefName = "SurgeryListDefinition";
        this.CAProcedureObject.DataMember = "ProcedureObject";
        this.CAProcedureObject.DisplayIndex = 0;
        this.CAProcedureObject.HeaderText = "Ameliyat";
        this.CAProcedureObject.Name = "CAProcedureObject";
        this.CAProcedureObject.ReadOnly = true;
        this.CAProcedureObject.Width = 600;

        //this.DescriptionOfObj = new TTVisual.TTRichTextBoxControlColumn();
        //this.DescriptionOfObj.DataMember = "DescriptionOfProcedureObject";
        //this.DescriptionOfObj.DisplayIndex = 1;
        //this.DescriptionOfObj.HeaderText = "Detaylı Tanımlama";
        //this.DescriptionOfObj.Name = "DescriptionOfObj";
        //this.DescriptionOfObj.ReadOnly = true;
        //this.DescriptionOfObj.Width = 150;

        this.labelPlannedSurgeryDescription = new TTVisual.TTLabel();
        this.labelPlannedSurgeryDescription.Text = i18n("M20394", "Planlanan Ameliyat Açıklaması");
        this.labelPlannedSurgeryDescription.Name = "labelPlannedSurgeryDescription";
        this.labelPlannedSurgeryDescription.TabIndex = 104;

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.DisplayText = i18n("M16071", "İade Sebebi");
        this.ttrichtextboxcontrol1.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 5;

        this.SuggestedAnesthesiaTechniqueGridColumns = [this.SuggestedAnesthesiaTechnique];
        this.RequestedProcedureColumns = [this.Procedure];
        this.GridDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridAnesthesiaPersonnelsColumns = [this.AnesthesiaPersonnel];
        this.GridSurgeryProceduresColumns = [this.CAProcedureObject];
        this.Controls = [this.SuggestedAnesthesiaTechniqueGrid, this.SuggestedAnesthesiaTechnique, this.ttlabel4, this.PlannedAnesthsiaDate, this.ttlabel1, this.ttrichtextboxcontrolConsultationNote, this.RequestedProcedure, this.Procedure, this.LabelRequest, this.RequestDate, this.RequestNote, this.ProtocolNo, this.PlannedSurgeryDescription, this.GridDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.labelRequestNote, this.labelProtocolNo, this.GridAnesthesiaPersonnels, this.AnesthesiaPersonnel, this.labelASAType, this.ASAType, this.ApprovalFormGiven, this.GridSurgeryProcedures, this.CAProcedureObject, this.DescriptionOfObj, this.labelPlannedSurgeryDescription, this.ttrichtextboxcontrol1];

    }


}
