//$A8E1F0F3
import { Component, OnInit, NgZone } from '@angular/core';
import { OrthesisProsthesisCancelledFormViewModel } from './OrthesisProsthesisCancelledFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'OrthesisProsthesisCancelledForm',
    templateUrl: './OrthesisProsthesisCancelledForm.html',
    providers: [MessageService]
})
export class OrthesisProsthesisCancelledForm extends EpisodeActionForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    IsPrintReport: TTVisual.ITTCheckBoxColumn;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProcedureSpeciality: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    LabelRequestDate: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    OrthesisProsthesisProcedures: TTVisual.ITTGrid;
    PatientGroup: TTVisual.ITTEnumComboBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ProcedureSpeciality: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    ReasonOfCancel: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    SideO: TTVisual.ITTEnumComboBoxColumn;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    tttabcontrolDiagnose: TTVisual.ITTTabControl;
    tttabpageDiagnosis: TTVisual.ITTTabPage;
    tttabpageOrthesis: TTVisual.ITTTabPage;
    public GridEpisodeDiagnosisColumns = [];
    public OrthesisProsthesisProceduresColumns = [];
    public orthesisProsthesisCancelledFormViewModel: OrthesisProsthesisCancelledFormViewModel = new OrthesisProsthesisCancelledFormViewModel();
    public get _OrthesisProsthesisRequest(): OrthesisProsthesisRequest {
        return this._TTObject as OrthesisProsthesisRequest;
    }
    private OrthesisProsthesisCancelledForm_DocumentUrl: string = '/api/OrthesisProsthesisRequestService/OrthesisProsthesisCancelledForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.OrthesisProsthesisCancelledForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        if (this.ProcedureDoctor.SelectedObject === null)
            throw new Exception((await SystemMessageService.GetMessage(669)));
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        // this.SetProcedureDoctorAsCurrentResource();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OrthesisProsthesisRequest();
        this.orthesisProsthesisCancelledFormViewModel = new OrthesisProsthesisCancelledFormViewModel();
        this._ViewModel = this.orthesisProsthesisCancelledFormViewModel;
        this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest = this._TTObject as OrthesisProsthesisRequest;
        this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.MasterResource = new ResSection();
        this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures = new Array<OrthesisProsthesisProcedure>();
        this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.Episode = new Episode();
        this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.ProcedureDoctor = new ResUser();
        this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.ProcedureSpeciality = new SpecialityDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.orthesisProsthesisCancelledFormViewModel = this._ViewModel as OrthesisProsthesisCancelledFormViewModel;
        that._TTObject = this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest;
        if (this.orthesisProsthesisCancelledFormViewModel == null)
            this.orthesisProsthesisCancelledFormViewModel = new OrthesisProsthesisCancelledFormViewModel();
        if (this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest == null)
            this.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest = new OrthesisProsthesisRequest();
        let masterResourceObjectID = that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.orthesisProsthesisCancelledFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
             if (masterResource) {
                that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.MasterResource = masterResource;
            }
        }
        that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures = that.orthesisProsthesisCancelledFormViewModel.OrthesisProsthesisProceduresGridList;
        for (let detailItem of that.orthesisProsthesisCancelledFormViewModel.OrthesisProsthesisProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                let procedureObject = that.orthesisProsthesisCancelledFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
        let episodeObjectID = that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.orthesisProsthesisCancelledFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.orthesisProsthesisCancelledFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.orthesisProsthesisCancelledFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.orthesisProsthesisCancelledFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.orthesisProsthesisCancelledFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let procedureDoctorObjectID = that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.orthesisProsthesisCancelledFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.ProcedureDoctor = procedureDoctor;
            }
        }
        let procedureSpecialityObjectID = that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest["ProcedureSpeciality"];
        if (procedureSpecialityObjectID != null && (typeof procedureSpecialityObjectID === "string")) {
            let procedureSpeciality = that.orthesisProsthesisCancelledFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === procedureSpecialityObjectID.toString());
             if (procedureSpeciality) {
                that.orthesisProsthesisCancelledFormViewModel._OrthesisProsthesisRequest.ProcedureSpeciality = procedureSpeciality;
            }
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OrthesisProsthesisCancelledFormViewModel);
  
    }


    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.MasterResource != event) {
                this._OrthesisProsthesisRequest.MasterResource = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ProcedureDoctor != event) {
                this._OrthesisProsthesisRequest.ProcedureDoctor = event;
            }
        }
    }

    public onProcedureSpecialityChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ProcedureSpeciality != event) {
                this._OrthesisProsthesisRequest.ProcedureSpeciality = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ProtocolNo != event) {
                this._OrthesisProsthesisRequest.ProtocolNo = event;
            }
        }
    }

    public onReasonOfCancelChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ReasonOfCancel != event) {
                this._OrthesisProsthesisRequest.ReasonOfCancel = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.RequestDate != event) {
                this._OrthesisProsthesisRequest.RequestDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.ReasonOfCancel, "Text", this.__ttObject, "ReasonOfCancel");
    }

    public initFormControls(): void {
        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "ResourceListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 17460;
        this.MasterResource.Visible = false;

        this.ReasonOfCancel = new TTVisual.TTTextBox();
        this.ReasonOfCancel.Multiline = true;
        this.ReasonOfCancel.Name = "ReasonOfCancel";
        this.ReasonOfCancel.TabIndex = 5;
        this.ReasonOfCancel.Height = "250";

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M22474", "Şema");
        this.ttgroupbox1.BackColor = "#DCDCDC";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 6;

        this.tttabcontrolDiagnose = new TTVisual.TTTabControl();
        this.tttabcontrolDiagnose.Name = "tttabcontrolDiagnose";
        this.tttabcontrolDiagnose.TabIndex = 200;

        this.tttabpageOrthesis = new TTVisual.TTTabPage();
        this.tttabpageOrthesis.DisplayIndex = 0;
        this.tttabpageOrthesis.BackColor = "#FFFFFF";
        this.tttabpageOrthesis.TabIndex = 1;
        this.tttabpageOrthesis.Text = i18n("M19775", "Ortez Protez");
        this.tttabpageOrthesis.Name = "tttabpageOrthesis";

        this.OrthesisProsthesisProcedures = new TTVisual.TTGrid();
        this.OrthesisProsthesisProcedures.Name = "OrthesisProsthesisProcedures";
        this.OrthesisProsthesisProcedures.TabIndex = 0;
        this.OrthesisProsthesisProcedures.AllowUserToAddRows = false;
        this.OrthesisProsthesisProcedures.AllowUserToDeleteRows = false;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "OrtesisProsthesisListDefinition";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 0;
        this.ProcedureObject.HeaderText = i18n("M19781", "Ortez Protez İşlemi");
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.Width = 460;

        this.SideO = new TTVisual.TTEnumComboBoxColumn();
        this.SideO.DataTypeName = "SideEnum";
        this.SideO.DataMember = "Side";
        this.SideO.DisplayIndex = 1;
        this.SideO.HeaderText = i18n("M22824", "Taraf");
        this.SideO.Name = "SideO";
        this.SideO.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.IsPrintReport = new TTVisual.TTCheckBoxColumn();
        this.IsPrintReport.DisplayIndex = 3;
        this.IsPrintReport.HeaderText = i18n("M20766", "Rapor Bas");
        this.IsPrintReport.Name = "IsPrintReport";
        this.IsPrintReport.Visible = false;
        this.IsPrintReport.Width = 100;

        this.tttabpageDiagnosis = new TTVisual.TTTabPage();
        this.tttabpageDiagnosis.DisplayIndex = 1;
        this.tttabpageDiagnosis.BackColor = "#FFFFFF";
        this.tttabpageDiagnosis.TabIndex = 0;
        this.tttabpageDiagnosis.Text = i18n("M24028", "Vaka Tanıları");
        this.tttabpageDiagnosis.Name = "tttabpageDiagnosis";

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 6;

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
        this.EpisodeDiagnose.HeaderText = i18n("M22736", "Tanı");
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
        this.ProtocolNo.TabIndex = 0;

        this.LabelRequestDate = new TTVisual.TTLabel();
        this.LabelRequestDate.Text = i18n("M16650", "İstek Tarihi");
        this.LabelRequestDate.BackColor = "#DCDCDC";
        this.LabelRequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelRequestDate.ForeColor = "#000000";
        this.LabelRequestDate.Name = "LabelRequestDate";
        this.LabelRequestDate.TabIndex = 184;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 1;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.LinkedControlName = "MasterResource";
        this.ProcedureDoctor.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 4;

        this.labelProcedureSpeciality = new TTVisual.TTLabel();
        this.labelProcedureSpeciality.Text = i18n("M16950", "İşlemin Yapıldığı Uzmanlık Dalı");
        this.labelProcedureSpeciality.BackColor = "#DCDCDC";
        this.labelProcedureSpeciality.ForeColor = "#000000";
        this.labelProcedureSpeciality.Name = "labelProcedureSpeciality";
        this.labelProcedureSpeciality.TabIndex = 167;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 126;

        this.ProcedureSpeciality = new TTVisual.TTObjectListBox();
        this.ProcedureSpeciality.ListDefName = "SpecialityListDefinition";
        this.ProcedureSpeciality.Name = "ProcedureSpeciality";
        this.ProcedureSpeciality.TabIndex = 3;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16935", "İşlemi Yapan Tabip");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 165;

        this.PatientGroup = new TTVisual.TTEnumComboBox();
        this.PatientGroup.DataTypeName = "PatientGroupEnum";
        this.PatientGroup.BackColor = "#F0F0F0";
        this.PatientGroup.Enabled = false;
        this.PatientGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientGroup.Name = "PatientGroup";
        this.PatientGroup.TabIndex = 2;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 17459;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M16528", "İptal Açıklaması");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 184;

        this.OrthesisProsthesisProceduresColumns = [this.ProcedureObject, this.SideO, this.Amount, this.IsPrintReport];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.tttabcontrolDiagnose.Controls = [this.tttabpageOrthesis, this.tttabpageDiagnosis];
        this.tttabpageOrthesis.Controls = [this.OrthesisProsthesisProcedures];
        this.tttabpageDiagnosis.Controls = [this.GridEpisodeDiagnosis];
        this.Controls = [this.MasterResource, this.ReasonOfCancel, this.ttgroupbox1, this.tttabcontrolDiagnose, this.tttabpageOrthesis, this.OrthesisProsthesisProcedures, this.ProcedureObject, this.SideO, this.Amount, this.IsPrintReport, this.tttabpageDiagnosis, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ProtocolNo, this.LabelRequestDate, this.RequestDate, this.ProcedureDoctor, this.labelProcedureSpeciality, this.labelProtocolNo, this.ProcedureSpeciality, this.labelProcedureDoctor, this.PatientGroup, this.ttlabel2, this.ttlabel1];

    }


}
