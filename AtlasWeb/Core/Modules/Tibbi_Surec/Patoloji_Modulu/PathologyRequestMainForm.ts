//$9287E89A
import { Component, ViewChild, OnInit, NgZone, Renderer2 } from '@angular/core';
import { PathologyRequestMainFormViewModel, TempPathologyMaterialViewModel, RejectedMaterialsViewModel ,MaterialBarcodeInfo} from './PathologyRequestMainFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PathologyRequest, Material } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { ReasonForPathologyRejection } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DxDataGridComponent } from "devextreme-angular";
import { vmRequestedPathologyProcedure } from './PathologyMaterialInfoViewModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { PatologyBarcodeInfo, PatientBarcodeInfo } from 'app/Barcode/Models/PatientBarcodeInfo';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: 'PathologyRequestMainForm',
    templateUrl: './PathologyRequestMainForm.html',
    providers: [MessageService]
})
export class PathologyRequestMainForm extends EpisodeActionForm implements OnInit {

    @ViewChild('materials') materialsGridInstance: DxDataGridComponent;
    AcceptionDate: TTVisual.ITTDateTimePicker;
    AcceptionNote: TTVisual.ITTTextBox;
    AlindigiDokununTemelOzelligiPathologyMaterial: TTVisual.ITTListBoxColumn;
    ClinicalFindingsPathologyMaterial: TTVisual.ITTTextBoxColumn;
    DateOfSampleTaken: TTVisual.ITTDateTimePickerColumn;
    DescriptionPathologyMaterial: TTVisual.ITTTextBoxColumn;
    DiagnoseDateDiagnosisGrid: TTVisual.ITTDateTimePickerColumn;
    DiagnoseDiagnosisGrid: TTVisual.ITTListBoxColumn;
    DiagnosisDiagnosisGrid: TTVisual.ITTGrid;
    DiagnosisTypeDiagnosisGrid: TTVisual.ITTEnumComboBoxColumn;
    labelAcceptionDate: TTVisual.ITTLabel;
    labelAcceptionNote: TTVisual.ITTLabel;
    labelMaterialResponsible: TTVisual.ITTLabel;
    labelPhoneNumberResUser: TTVisual.ITTLabel;
    labelRequestDate: TTVisual.ITTLabel;
    labelRequestDoctor: TTVisual.ITTLabel;
    labelRequestMaterialNumber: TTVisual.ITTLabel;
    MaterialNumber: TTVisual.ITTTextBoxColumn;
    MaterialResponsible: TTVisual.ITTTextBox;
    NumuneAlinmaSekliPathologyMaterial: TTVisual.ITTListBoxColumn;
    PathologyMaterials: TTVisual.ITTGrid;
    PhoneNumberResUser: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    RequestDoctor: TTVisual.ITTObjectListBox;
    RequestMaterialNumber: TTVisual.ITTTextBox;
    MaterialProcedureList: TTVisual.ITTObjectListBox;
    ResponsibleDoctorDiagnosisGrid: TTVisual.ITTListBoxColumn;
    YerlesimYeriPathologyMaterial: TTVisual.ITTListBoxColumn;
    public DiagnosisDiagnosisGridColumns = [];
    public PathologyMaterialsColumns = [];
    public pathologyRequestMainFormViewModel: PathologyRequestMainFormViewModel = new PathologyRequestMainFormViewModel();

    PathologyMaterialListColumns = [];
    m_yerlesimYeriArray: Array<any> = [];
    m_YerlesimYeriCache: any;
    m_alindigiDokununTemelOzelligiArray: Array<any> = [];
    m_AlindigiDokununTemelOzelligiCache: any;
    m_numuneAlinmaSekliArray: Array<any> = [];
    m_NumuneAlinmaSekliCache: any;
    pathologyTestDefinitionArray: Array<any> = [];
    pathologyTestDefinitionCache: any;

    public selectedPathologyMaterials: Array<PathologyMaterial> = [];
    public showReasonForRejectPopup = false;
    public rejectReason: Guid = new Guid();
    public showAddProcedureToMaterialPopup = false;

    PathologyListColumns = [];
    public PathologyList: Array<TempPathologyMaterialViewModel> = [];
    public groupCount: number = 1;
    public RejectedMaterialList: Array<RejectedMaterialsViewModel> = [];

    selectedMaterialForAddProcedure: PathologyMaterial = new PathologyMaterial();
    _RequestedProcedureArray: Array<vmRequestedPathologyProcedure> = new Array<vmRequestedPathologyProcedure>();

    public RequestedProcedureList: Array<vmRequestedPathologyProcedure> = []; //Eklenecek işlemler gridi için datasource

    public get _PathologyRequest(): PathologyRequest {
        return this._TTObject as PathologyRequest;
    }
    private PathologyRequestMainForm_DocumentUrl: string = '/api/PathologyRequestService/PathologyRequestMainForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        protected ngZone: NgZone,
        private barcodePrintService: IBarcodePrintService,
        private sideBarMenuService: ISidebarMenuService,
        private renderer: Renderer2
    ) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.PathologyRequestMainForm_DocumentUrl;
        this.showReasonForRejectPopup = false;
        this.showAddProcedureToMaterialPopup = false;
        this._RequestedProcedureArray = [];
        this.RequestedProcedureList = [];
        this.rejectReason = new Guid();
        this.groupCount = 1;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PathologyRequest();
        this.pathologyRequestMainFormViewModel = new PathologyRequestMainFormViewModel();
        this._ViewModel = this.pathologyRequestMainFormViewModel;
        this.pathologyRequestMainFormViewModel._PathologyRequest = this._TTObject as PathologyRequest;
        this.pathologyRequestMainFormViewModel._PathologyRequest.RequestDoctor = new ResUser();
        this.pathologyRequestMainFormViewModel._PathologyRequest.Episode = new Episode();
        this.pathologyRequestMainFormViewModel._PathologyRequest.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials = new Array<PathologyMaterial>();

        this.pathologyRequestMainFormViewModel.ReasonForRejectMaterialList = new Array<ReasonForPathologyRejection>();
    }

    protected loadViewModel() {
        let that = this;

        that.pathologyRequestMainFormViewModel = this._ViewModel as PathologyRequestMainFormViewModel;
        that._TTObject = this.pathologyRequestMainFormViewModel._PathologyRequest;
        if (this.pathologyRequestMainFormViewModel == null)
            this.pathologyRequestMainFormViewModel = new PathologyRequestMainFormViewModel();
        if (this.pathologyRequestMainFormViewModel._PathologyRequest == null)
            this.pathologyRequestMainFormViewModel._PathologyRequest = new PathologyRequest();
        let requestDoctorObjectID = that.pathologyRequestMainFormViewModel._PathologyRequest["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.pathologyRequestMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.pathologyRequestMainFormViewModel._PathologyRequest.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.pathologyRequestMainFormViewModel._PathologyRequest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.pathologyRequestMainFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.pathologyRequestMainFormViewModel._PathologyRequest.Episode = episode;
            }
            //if (episode != null) {
            //    episode.Diagnosis = that.pathologyRequestMainFormViewModel.DiagnosisDiagnosisGridGridList;
            //    for (let detailItem of that.pathologyRequestMainFormViewModel.DiagnosisDiagnosisGridGridList) {
            //        let diagnoseObjectID = detailItem["Diagnose"];
            //        if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
            //            let diagnose = that.pathologyRequestMainFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
            //            detailItem.Diagnose = diagnose;
            //        }
            //        let responsibleDoctorObjectID = detailItem["ResponsibleDoctor"];
            //        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === 'string')) {
            //            let responsibleDoctor = that.pathologyRequestMainFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
            //            detailItem.ResponsibleDoctor = responsibleDoctor;
            //        }
            //    }
            //}
        }
        that.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials = that.pathologyRequestMainFormViewModel.PathologyMaterialsGridList;
        for (let detailItem of that.pathologyRequestMainFormViewModel.PathologyMaterialsGridList) {
            let yerlesimYeriObjectID = detailItem["YerlesimYeri"];
            if (yerlesimYeriObjectID != null && (typeof yerlesimYeriObjectID === 'string')) {
                let yerlesimYeri = that.pathologyRequestMainFormViewModel.SKRSICDOYERLESIMYERIs.find(o => o.ObjectID.toString() === yerlesimYeriObjectID.toString());
                if (yerlesimYeri) {
                    detailItem.YerlesimYeri = yerlesimYeri;
                }
            }
            let alindigiDokununTemelOzelligiObjectID = detailItem["AlindigiDokununTemelOzelligi"];
            if (alindigiDokununTemelOzelligiObjectID != null && (typeof alindigiDokununTemelOzelligiObjectID === 'string')) {
                let alindigiDokununTemelOzelligi = that.pathologyRequestMainFormViewModel.SKRSNumuneAlindigiDokununTemelOzelligis.find(o => o.ObjectID.toString() === alindigiDokununTemelOzelligiObjectID.toString());
                if (alindigiDokununTemelOzelligi) {
                    detailItem.AlindigiDokununTemelOzelligi = alindigiDokununTemelOzelligi;
                }
            }
            let numuneAlinmaSekliObjectID = detailItem["NumuneAlinmaSekli"];
            if (numuneAlinmaSekliObjectID != null && (typeof numuneAlinmaSekliObjectID === 'string')) {
                let numuneAlinmaSekli = that.pathologyRequestMainFormViewModel.SKRSNumuneAlinmaSeklis.find(o => o.ObjectID.toString() === numuneAlinmaSekliObjectID.toString());
                if (numuneAlinmaSekli) {
                    detailItem.NumuneAlinmaSekli = numuneAlinmaSekli;
                }
            }
        }

    }


    async ngOnInit() {
        let that = this;
        that.m_yerlesimYeriArray = await this.M_YerlesimYeri();
        that.m_alindigiDokununTemelOzelligiArray = await this.M_AlindigiDokununTemelOzelligi();
        that.m_numuneAlinmaSekliArray = await this.M_NumuneAlinmaSekli();
        that.GenerateMaterialListColumns();
        that.GeneratePathologyListColumns();
        await this.load(PathologyRequestMainFormViewModel);
        this.AddHelpMenu();

    }


    public onAcceptionDateChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null && this._PathologyRequest.AcceptionDate != event) {
                this._PathologyRequest.AcceptionDate = event;
            }
        }
    }

    public onAcceptionNoteChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null && this._PathologyRequest.AcceptionNote != event) {
                this._PathologyRequest.AcceptionNote = event;
            }
        }
    }

    public onMaterialResponsibleChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null && this._PathologyRequest.MaterialResponsible != event) {
                this._PathologyRequest.MaterialResponsible = event;
            }
        }
    }

    public onPhoneNumberResUserChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null &&
                this._PathologyRequest.RequestDoctor != null && this._PathologyRequest.RequestDoctor.PhoneNumber != event) {
                this._PathologyRequest.RequestDoctor.PhoneNumber = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null && this._PathologyRequest.RequestDate != event) {
                this._PathologyRequest.RequestDate = event;
            }
        }
    }

    public onRequestDoctorChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null && this._PathologyRequest.RequestDoctor != event) {
                this._PathologyRequest.RequestDoctor = event;
            }
        }
    }

    public onRequestMaterialNumberChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null && this._PathologyRequest.RequestMaterialNumber != event) {
                this._PathologyRequest.RequestMaterialNumber = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.AcceptionNote, "Text", this.__ttObject, "AcceptionNote");
        redirectProperty(this.AcceptionDate, "Value", this.__ttObject, "AcceptionDate");
        redirectProperty(this.PhoneNumberResUser, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.RequestMaterialNumber, "Text", this.__ttObject, "RequestMaterialNumber");
        redirectProperty(this.MaterialResponsible, "Text", this.__ttObject, "MaterialResponsible");
    }

    public initFormControls(): void {
        this.labelMaterialResponsible = new TTVisual.TTLabel();
        this.labelMaterialResponsible.Text = i18n("M18653", "Malzemeyi Getiren Sorumlu");
        this.labelMaterialResponsible.Name = "labelMaterialResponsible";
        this.labelMaterialResponsible.TabIndex = 15;

        this.MaterialResponsible = new TTVisual.TTTextBox();
        this.MaterialResponsible.Required = true;
        this.MaterialResponsible.BackColor = "#FFE3C6";
        this.MaterialResponsible.Name = "MaterialResponsible";
        this.MaterialResponsible.TabIndex = 14;

        this.RequestMaterialNumber = new TTVisual.TTTextBox();
        this.RequestMaterialNumber.BackColor = "#F0F0F0";
        this.RequestMaterialNumber.ReadOnly = true;
        this.RequestMaterialNumber.Name = "RequestMaterialNumber";
        this.RequestMaterialNumber.TabIndex = 12;

        this.PhoneNumberResUser = new TTVisual.TTTextBox();
        this.PhoneNumberResUser.BackColor = "#F0F0F0";
        this.PhoneNumberResUser.ReadOnly = true;
        this.PhoneNumberResUser.Name = "PhoneNumberResUser";
        this.PhoneNumberResUser.TabIndex = 9;

        this.AcceptionNote = new TTVisual.TTTextBox();
        this.AcceptionNote.Required = true;
        this.AcceptionNote.Multiline = true;
        this.AcceptionNote.BackColor = "#FFE3C6";
        this.AcceptionNote.Name = "AcceptionNote";
        this.AcceptionNote.TabIndex = 2;
        this.AcceptionNote.Height = "70px";


        this.labelRequestMaterialNumber = new TTVisual.TTLabel();
        this.labelRequestMaterialNumber.Text = i18n("M16614", "İstek Arşiv Numarası");
        this.labelRequestMaterialNumber.Name = "labelRequestMaterialNumber";
        this.labelRequestMaterialNumber.TabIndex = 13;

        this.DiagnosisDiagnosisGrid = new TTVisual.TTGrid();
        this.DiagnosisDiagnosisGrid.AllowUserToDeleteRows = false;
        this.DiagnosisDiagnosisGrid.ReadOnly = true;
        this.DiagnosisDiagnosisGrid.Name = "DiagnosisDiagnosisGrid";
        this.DiagnosisDiagnosisGrid.TabIndex = 11;

        this.DiagnoseDiagnosisGrid = new TTVisual.TTListBoxColumn();
        this.DiagnoseDiagnosisGrid.ListDefName = "DiagnosisListDefinition";
        this.DiagnoseDiagnosisGrid.DataMember = "Diagnose";
        this.DiagnoseDiagnosisGrid.DisplayIndex = 0;
        this.DiagnoseDiagnosisGrid.HeaderText = i18n("M22736", "Tanı");
        this.DiagnoseDiagnosisGrid.Name = "DiagnoseDiagnosisGrid";
        this.DiagnoseDiagnosisGrid.Width = 250;

        this.DiagnosisTypeDiagnosisGrid = new TTVisual.TTEnumComboBoxColumn();
        this.DiagnosisTypeDiagnosisGrid.DataTypeName = "DiagnosisTypeEnum";
        this.DiagnosisTypeDiagnosisGrid.DataMember = "DiagnosisType";
        this.DiagnosisTypeDiagnosisGrid.DisplayIndex = 1;
        this.DiagnosisTypeDiagnosisGrid.HeaderText = i18n("M22781", "Tanı Tipi");
        this.DiagnosisTypeDiagnosisGrid.Name = "DiagnosisTypeDiagnosisGrid";
        this.DiagnosisTypeDiagnosisGrid.Width = 80;

        this.DiagnoseDateDiagnosisGrid = new TTVisual.TTDateTimePickerColumn();
        this.DiagnoseDateDiagnosisGrid.DataMember = "DiagnoseDate";
        this.DiagnoseDateDiagnosisGrid.DisplayIndex = 2;
        this.DiagnoseDateDiagnosisGrid.HeaderText = i18n("M22750", "Tanı Giriş Tarihi  ");
        this.DiagnoseDateDiagnosisGrid.Name = "DiagnoseDateDiagnosisGrid";
        this.DiagnoseDateDiagnosisGrid.Width = 180;

        this.ResponsibleDoctorDiagnosisGrid = new TTVisual.TTListBoxColumn();
        this.ResponsibleDoctorDiagnosisGrid.ListDefName = "DiagnosisListDefinition";
        this.ResponsibleDoctorDiagnosisGrid.DataMember = "ResponsibleDoctor";
        this.ResponsibleDoctorDiagnosisGrid.DisplayIndex = 3;
        this.ResponsibleDoctorDiagnosisGrid.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.ResponsibleDoctorDiagnosisGrid.Name = "ResponsibleDoctorDiagnosisGrid";
        this.ResponsibleDoctorDiagnosisGrid.Width = 170;

        this.labelPhoneNumberResUser = new TTVisual.TTLabel();
        this.labelPhoneNumberResUser.Text = i18n("M23135", "Telefon No");
        this.labelPhoneNumberResUser.Name = "labelPhoneNumberResUser";
        this.labelPhoneNumberResUser.TabIndex = 10;

        this.labelRequestDoctor = new TTVisual.TTLabel();
        this.labelRequestDoctor.Text = i18n("M16661", "İstek Yapan Doktor");
        this.labelRequestDoctor.Name = "labelRequestDoctor";
        this.labelRequestDoctor.TabIndex = 8;

        this.RequestDoctor = new TTVisual.TTObjectListBox();
        this.RequestDoctor.ReadOnly = true;
        this.RequestDoctor.ListDefName = "DoctorListDefinition";
        this.RequestDoctor.Name = "RequestDoctor";
        this.RequestDoctor.TabIndex = 7;

        this.PathologyMaterials = new TTVisual.TTGrid();
        this.PathologyMaterials.Name = "PathologyMaterials";
        this.PathologyMaterials.TabIndex = 6;

        this.DateOfSampleTaken = new TTVisual.TTDateTimePickerColumn();
        this.DateOfSampleTaken.CustomFormat = "dd/MM/yyyy HH:mm";
        this.DateOfSampleTaken.DataMember = "DateOfSampleTaken";
        this.DateOfSampleTaken.DisplayIndex = 0;
        this.DateOfSampleTaken.HeaderText = i18n("M19537", "Numune Alınma Tarihi");
        this.DateOfSampleTaken.Name = "DateOfSampleTaken";
        this.DateOfSampleTaken.ReadOnly = true;
        this.DateOfSampleTaken.Width = 155;

        this.MaterialNumber = new TTVisual.TTTextBoxColumn();
        this.MaterialNumber.DataMember = "MaterialNumber";
        this.MaterialNumber.DisplayIndex = 1;
        this.MaterialNumber.HeaderText = i18n("M18696", "Materyal Arşiv Numarası");
        this.MaterialNumber.Name = "MaterialNumber";
        this.MaterialNumber.ReadOnly = true;
        this.MaterialNumber.Width = 100;

        this.YerlesimYeriPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.YerlesimYeriPathologyMaterial.ListDefName = "SKRSICDOYERLESIMYERIList";
        this.YerlesimYeriPathologyMaterial.DataMember = "YerlesimYeri";
        this.YerlesimYeriPathologyMaterial.DisplayIndex = 2;
        this.YerlesimYeriPathologyMaterial.HeaderText = i18n("M10716", "Alındığı Organ");
        this.YerlesimYeriPathologyMaterial.Name = "YerlesimYeriPathologyMaterial";
        this.YerlesimYeriPathologyMaterial.ReadOnly = true;
        this.YerlesimYeriPathologyMaterial.Width = 150;

        this.AlindigiDokununTemelOzelligiPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.AlindigiDokununTemelOzelligiPathologyMaterial.ListDefName = "SKRSNumuneAlindigiDokununTemelOzelligiList";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.DataMember = "AlindigiDokununTemelOzelligi";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.DisplayIndex = 3;
        this.AlindigiDokununTemelOzelligiPathologyMaterial.HeaderText = i18n("M10715", "Alındığı Dokunun Temel Özelliği");
        this.AlindigiDokununTemelOzelligiPathologyMaterial.Name = "AlindigiDokununTemelOzelligiPathologyMaterial";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.ReadOnly = true;
        this.AlindigiDokununTemelOzelligiPathologyMaterial.Width = 150;

        this.NumuneAlinmaSekliPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.NumuneAlinmaSekliPathologyMaterial.ListDefName = "SKRSNumuneAlinmaSekliList";
        this.NumuneAlinmaSekliPathologyMaterial.DataMember = "NumuneAlinmaSekli";
        this.NumuneAlinmaSekliPathologyMaterial.DisplayIndex = 4;
        this.NumuneAlinmaSekliPathologyMaterial.HeaderText = i18n("M10718", "Alınma Şekli");
        this.NumuneAlinmaSekliPathologyMaterial.Name = "NumuneAlinmaSekliPathologyMaterial";
        this.NumuneAlinmaSekliPathologyMaterial.ReadOnly = true;
        this.NumuneAlinmaSekliPathologyMaterial.Width = 150;

        this.ClinicalFindingsPathologyMaterial = new TTVisual.TTTextBoxColumn();
        this.ClinicalFindingsPathologyMaterial.DataMember = "ClinicalFindings";
        this.ClinicalFindingsPathologyMaterial.Required = true;
        this.ClinicalFindingsPathologyMaterial.DisplayIndex = 5;
        this.ClinicalFindingsPathologyMaterial.HeaderText = i18n("M17626", "Klinik Bulgular");
        this.ClinicalFindingsPathologyMaterial.Name = "ClinicalFindingsPathologyMaterial";
        this.ClinicalFindingsPathologyMaterial.Width = 300;

        this.DescriptionPathologyMaterial = new TTVisual.TTTextBoxColumn();
        this.DescriptionPathologyMaterial.DataMember = "Description";
        this.DescriptionPathologyMaterial.Required = true;
        this.DescriptionPathologyMaterial.DisplayIndex = 6;
        this.DescriptionPathologyMaterial.HeaderText = i18n("M10469", "Açıklama");
        this.DescriptionPathologyMaterial.Name = "DescriptionPathologyMaterial";
        this.DescriptionPathologyMaterial.Width = 300;

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M16650", "İstek Tarihi");
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 5;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Enabled = false;
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 4;

        this.labelAcceptionNote = new TTVisual.TTLabel();
        this.labelAcceptionNote.Text = i18n("M17022", "Kabul Notu");
        this.labelAcceptionNote.Name = "labelAcceptionNote";
        this.labelAcceptionNote.TabIndex = 3;

        this.labelAcceptionDate = new TTVisual.TTLabel();
        this.labelAcceptionDate.Text = i18n("M17034", "Kabul Tarihi");
        this.labelAcceptionDate.Name = "labelAcceptionDate";
        this.labelAcceptionDate.TabIndex = 1;

        this.AcceptionDate = new TTVisual.TTDateTimePicker();
        this.AcceptionDate.Required = true;
        this.AcceptionDate.BackColor = "#FFE3C6";
        this.AcceptionDate.Format = DateTimePickerFormat.Long;
        this.AcceptionDate.Name = "AcceptionDate";
        this.AcceptionDate.TabIndex = 0;

        this.MaterialProcedureList = new TTVisual.TTObjectListBox();
        this.MaterialProcedureList.ListDefName = "PathologyTestListDefinition";
        this.MaterialProcedureList.Name = "PathologyTestList";

        this.DiagnosisDiagnosisGridColumns = [this.DiagnoseDiagnosisGrid, this.DiagnosisTypeDiagnosisGrid, this.DiagnoseDateDiagnosisGrid, this.ResponsibleDoctorDiagnosisGrid];
        this.PathologyMaterialsColumns = [this.DateOfSampleTaken, this.MaterialNumber, this.YerlesimYeriPathologyMaterial, this.AlindigiDokununTemelOzelligiPathologyMaterial, this.NumuneAlinmaSekliPathologyMaterial, this.ClinicalFindingsPathologyMaterial, this.DescriptionPathologyMaterial];
        this.Controls = [this.labelMaterialResponsible, this.MaterialResponsible, this.RequestMaterialNumber, this.PhoneNumberResUser, this.AcceptionNote, this.labelRequestMaterialNumber, this.DiagnosisDiagnosisGrid, this.DiagnoseDiagnosisGrid, this.DiagnosisTypeDiagnosisGrid, this.DiagnoseDateDiagnosisGrid, this.ResponsibleDoctorDiagnosisGrid, this.labelPhoneNumberResUser, this.labelRequestDoctor, this.RequestDoctor, this.PathologyMaterials, this.DateOfSampleTaken, this.MaterialNumber, this.YerlesimYeriPathologyMaterial, this.AlindigiDokununTemelOzelligiPathologyMaterial, this.NumuneAlinmaSekliPathologyMaterial, this.ClinicalFindingsPathologyMaterial, this.DescriptionPathologyMaterial, this.labelRequestDate, this.RequestDate, this.labelAcceptionNote, this.labelAcceptionDate, this.AcceptionDate];

    }
    GenerateMaterialListColumns() {
        let that = this;

        this.PathologyMaterialListColumns = [
            {
                caption: i18n("M19537", "Numune Alınma Tarihi"),
                dataField: 'DateOfSampleTaken',
                allowEditing: false,
                fixed: true,
                allowSorting: false,
                dataType: 'datetime',
                //format: 'dd/MM/yyyy',
                width: '10%'
            },
            {
                caption: i18n("M18694", "Materyal Arşiv Numarası"),
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
                    dataSource: that.m_yerlesimYeriArray, valueExpr: 'ObjectID', displayExpr: 'KODTANIMI'
                }
            },
            {
                caption: i18n("M10715", "Alındığı Dokunun Temel Özelliği"),
                dataField: 'AlindigiDokununTemelOzelligi.ObjectID',
                fixed: true, width: '10%',
                allowSorting: false,
                allowEditing: false,
                lookup: {
                    dataSource: that.m_alindigiDokununTemelOzelligiArray, valueExpr: 'ObjectID', displayExpr: 'ADI'
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
                    dataSource: that.m_numuneAlinmaSekliArray, valueExpr: 'ObjectID', displayExpr: 'ADI'
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
            }, {
                caption: i18n("M23309", "Tetkik Ekle"),
                //dataField: "ProcedureResultLink",
                width: 60,
                allowSorting: true,
                cellTemplate: "linkCellTemplateAddProcedure",
            },
        ];

    }
    public async M_YerlesimYeri(): Promise<any> {
        if (!this.m_YerlesimYeriCache) {
            this.m_YerlesimYeriCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSYerlesimYeri');
            return this.m_YerlesimYeriCache;
        }
        else {
            return this.m_YerlesimYeriCache;
        }
    }

    public async M_AlindigiDokununTemelOzelligi(): Promise<any> {
        if (!this.m_AlindigiDokununTemelOzelligiCache) {
            this.m_AlindigiDokununTemelOzelligiCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSAlindigiDokununTemelOzelligi');
            return this.m_AlindigiDokununTemelOzelligiCache;
        }
        else {
            return this.m_AlindigiDokununTemelOzelligiCache;
        }
    }
    public async M_NumuneAlinmaSekli(): Promise<any> {
        if (!this.m_NumuneAlinmaSekliCache) {
            this.m_NumuneAlinmaSekliCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSNumuneAlinmaSekli');
            return this.m_NumuneAlinmaSekliCache;
        }
        else {
            return this.m_NumuneAlinmaSekliCache;
        }

    }

    onAcceptMaterial(): void {
        if (this.selectedPathologyMaterials.length > 0) {

            if (!this.confirmAcceptMaterial()) {
                return;
            } for (let i = 0; i < this.selectedPathologyMaterials.length; i++) {
                let materialObj = new TempPathologyMaterialViewModel();
                materialObj.GroupCount = this.groupCount;
                materialObj.MaterialObjectID = this.selectedPathologyMaterials[i].ObjectID;
                materialObj.DateOfSampleTaken = this.selectedPathologyMaterials[i].DateOfSampleTaken;
                materialObj.MaterialNumber = this.selectedPathologyMaterials[i].MaterialNumber;
                materialObj.YerlesimYeri = this.selectedPathologyMaterials[i].YerlesimYeri.KODTANIMI;
                materialObj.AlindigiDokununTemelOzelligi = this.selectedPathologyMaterials[i].AlindigiDokununTemelOzelligi.ADI;
                materialObj.NumuneAlinmaSekli = this.selectedPathologyMaterials[i].NumuneAlinmaSekli.ADI;
                materialObj.ClinicalFindings = this.selectedPathologyMaterials[i].ClinicalFindings;
                materialObj.Description = this.selectedPathologyMaterials[i].Description;
                materialObj.CytologyCheck = false;
                materialObj.BiopsyCheck = false;
                materialObj.BiopsyDisabled = false;
                materialObj.CytologyDisabled = false;

                this.PathologyList.push(materialObj);

                for (let j = 0; j < this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials.length; j++) {
                    if (this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials[j].ObjectID == this.selectedPathologyMaterials[i].ObjectID) {
                        this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials[j].IsAccepted = true;
                        this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials[j].IsRejected = false;
                    }
                }

            }
            this.groupCount++;
            this.selectedPathologyMaterials.Clear();
            this.materialsGridInstance.instance.refresh();
        }
        else {
            this.messageService.showError(i18n("M18704", "Materyal Seçiniz."));
        }
    }

    onRejectMaterial(): void {
        if (this.selectedPathologyMaterials.length > 0) {
            this.showReasonForRejectPopup = true;
        } else {
            this.messageService.showError(i18n("M18704", "Materyal Seçiniz."));
        }
    }

    onSelectReasonForReject(): void {
        for (let i = 0; i < this.selectedPathologyMaterials.length; i++) {
            let rejectedObj = new RejectedMaterialsViewModel();
            rejectedObj.MaterialObjectID = this.selectedPathologyMaterials[i].ObjectID;
            rejectedObj.RejectReasonID = this.rejectReason;
            this.RejectedMaterialList.push(rejectedObj);

            for (let j = 0; j < this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials.length; j++) {
                if (this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials[j].ObjectID == this.selectedPathologyMaterials[i].ObjectID) {
                    this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials[j].IsAccepted = false;
                    this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials[j].IsRejected = true;
                }
            }
        }
        this.showReasonForRejectPopup = false;
        this.selectedPathologyMaterials.Clear();
        this.materialsGridInstance.instance.refresh();
    }

    onValueChangedReasonForRejectPopup(e: any): void {
        this.rejectReason = e.value as Guid; //Seçilenin guidi geliyor
    }

    GeneratePathologyListColumns() {
        let that = this;

        this.PathologyListColumns = [
            {
                caption: 'Grup',
                dataField: 'GroupCount',
                allowEditing: false,
                allowSorting: false,
                fixed: true,
                width: '10%', groupIndex: 0
            },
            {
                caption: i18n("M19537", "Numune Alınma Tarihi"),
                dataField: 'DateOfSampleTaken',
                allowEditing: true,
                fixed: true,
                allowSorting: false,
                dataType: 'datetime',
                //format: 'dd/MM/yyyy',
                width: '10%'
            },
            {
                caption: i18n("M18694", "Materyal Arşiv Numarası"),
                dataField: 'MaterialNumber',
                allowEditing: false,
                allowSorting: false,
                fixed: true,
                width: '10%'
            }
            , {
                caption: i18n("M10716", "Alındığı Organ"),
                dataField: 'YerlesimYeri',
                fixed: true, width: '10%',
                allowSorting: false,
                allowEditing: false
            },
            {
                caption: i18n("M10715", "Alındığı Dokunun Temel Özelliği"),
                dataField: 'AlindigiDokununTemelOzelligi',
                fixed: true, width: '10%',
                allowSorting: false,
                allowEditing: false
            },
            {
                caption: i18n("M10718", "Alınma Şekli"),
                dataField: 'NumuneAlinmaSekli',
                fixed: true,
                width: '10%',
                allowSorting: false,
                allowEditing: false
            },
            {
                caption: i18n("M17626", "Klinik Bulgular"),
                dataField: 'ClinicalFindings',
                fixed: true,
                width: '20%',
                allowSorting: false,
                allowEditing: true
            },
            {
                caption: i18n("M10469", "Açıklama"),
                dataField: 'Description',
                fixed: true,
                width: '20%',
                allowSorting: false,
                allowEditing: true
            },
            {
                caption: 'Biyopsi',
                dataField: 'BiopsyCheck',
                dataType: 'boolean',
                fixed: true,
                width: '80px',
                allowEditing: true,
                cellTemplate: "BiopsyChkTemplate"
            },
            {
                caption: 'Sitoloji',
                dataField: 'CytologyCheck',
                dataType: 'boolean',
                fixed: true,
                width: '80px',
                allowEditing: true,
                cellTemplate: "CytologyChkTemplate"
            }
        ];

    }

    onRowPathologyList(row: any): void {
        if (row.rowElement.firstItem() !== undefined && row.rowType !== 'header' && row.rowType !== 'group' && row.rowElement.firstItem().length === 1) {
            row.rowElement.firstItem().style.backgroundColor = '#FFFFFF';
        }
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        super.ClientSidePostScript(transDef);

        if (this.pathologyRequestMainFormViewModel._PathologyRequest.CurrentStateDefID == PathologyRequest.PathologyRequestStates.Procedure) {

                throw new Exception("İşlemde Adımında Değişiklik Yapamazsınız.");
        }

        if (this.pathologyRequestMainFormViewModel._PathologyRequest.CurrentStateDefID == PathologyRequest.PathologyRequestStates.Cancelled) {
            throw new Exception("İptal Edildi Adımında Değişiklik Yapamazsınız.");
        }
        //if (transDef != null && transDef.ToStateDefID.valueOf() == PathologyRequest.PathologyRequestStates.Procedure.id && transDef.FromStateDefID.valueOf() == PathologyRequest.PathologyRequestStates.Accept.id) {
            this.pathologyRequestMainFormViewModel.SelectedPathologyMaterialArray = this.PathologyList;
            this.pathologyRequestMainFormViewModel.RejectedMaterialArray = this.RejectedMaterialList;
            if (!this.confirmSave())
                throw new Exception("İşleme Devam Etmek için Materyallerin Türlerini Seçmelisiniz.(Biyopsi / Sitoloji)");

            if (this.PathologyList.length == 0 && this.RejectedMaterialList.length == 0)
                throw new Exception("Materyal Kabul ya da Red Etmeden İşleme Devam Edemezsiniz.");

            let materialsLength : number = this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials.length;
        let materialsAcceptedLength: number = this.PathologyList.length; 
        let materialsRejectedLength: number = this.RejectedMaterialList.length; 

        if ((materialsAcceptedLength + materialsRejectedLength) != materialsLength)
            throw new Exception("İşleme Devam Edebilmek İçin Materyallerin Tümünü Kabul/Red Etmelisiniz.");
        //}
        //if (transDef != null && transDef.ToStateDefID.valueOf() == PathologyRequest.PathologyRequestStates.Cancelled.id && transDef.FromStateDefID.valueOf() == PathologyRequest.PathologyRequestStates.Accept.id) {
        //    this.pathologyRequestMainFormViewModel.RejectedMaterialArray = this.RejectedMaterialList;
        //    if (this.RejectedMaterialList.length == 0)
        //        throw new Exception("Materyalleri Red Etmeden İşleme Devam Edemezsiniz.");

        //}
    }

    protected async ClientSidePreScript() {
       

        this.PathologyList = this.pathologyRequestMainFormViewModel.SelectedPathologyMaterialArray;
        for(var i=0; i< this.pathologyRequestMainFormViewModel._ProcedureArray.length;i++){
            if(!this.pathologyRequestMainFormViewModel._ProcedureArray[i].IsPaid){
                throw new Exception("Hastanın vezneye ödemesi gereken ücret bulunmaktadır.Lütfen vezneye yönlendiriniz.");
            }
        }

    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);


        if (transDef !== null && transDef.ToStateDefID === PathologyRequest.PathologyRequestStates.Procedure) {
            this.printPathologyBarcode();
        }

    }


    btnPathologyRequestSave_Click() {
        try {

            if (this.confirmSave())
                this.save();
            else
                this.messageService.showError("İşleme Devam Etmek için Materyallerin Türlerini Seçmelisiniz.(Biyopsi/Sitoloji)");
        }
        catch (err) {
            this.messageService.showError(err.message);
        }
    }

    onRowPreparedMaterialList(e: any): void {

        //if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' ) {
        if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowElement.firstItem() !== undefined) {
            if (e.data.IsAccepted) {
                this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "#B5E196");
            }
            else if (e.data.IsRejected) {
                this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "#e06b6b");
            }
            else {
                this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "transparent");
            }

        }
    }

    confirmAcceptMaterial(): boolean {
        let result = true;
        if (this.pathologyRequestMainFormViewModel._PathologyRequest.MaterialResponsible == null || this.pathologyRequestMainFormViewModel._PathologyRequest.MaterialResponsible == "") {
            this.messageService.showError(i18n("M18654", "Malzemeyi Getiren Sorumluyu Seçiniz."));
            result = false;
        }
        if (this.pathologyRequestMainFormViewModel._PathologyRequest.AcceptionDate == null) {
            this.messageService.showError(i18n("M17036", "Kabul Tarihini Seçiniz."));
            result = false;
        }
        if (this.pathologyRequestMainFormViewModel._PathologyRequest.AcceptionNote == null || this.pathologyRequestMainFormViewModel._PathologyRequest.AcceptionNote == "") {
            this.messageService.showError(i18n("M17023", "Kabul Notu Giriniz."));
            result = false;
        }

        //Eklenmiş bir materyal tekrar eklenemesin.

        return result;

    }

    onSelectionChangedMaterialList(event: any): void {

        for (let i = 0; i < event.selectedRowsData.length; i++) {
            if (event.selectedRowsData[i].IsAccepted) {
                this.messageService.showError(i18n("M17020", "Kabul Edilmiş Bir Materyali Tekrar Seçemezsiniz."));
                this.materialsGridInstance.instance.deselectRows(event.selectedRowsData[i]);
                return;
            }
            if (event.selectedRowsData[i].IsRejected) {
                this.messageService.showError(i18n("M20984", "Reddedilmiş Bir Materyali Tekrar Seçemezsiniz."));
                this.materialsGridInstance.instance.deselectRows(event.selectedRowsData[i]);
                return;
            }


        }
    }

    onClearSelectedMaterials(): void {
        this.selectedPathologyMaterials.Clear();
        for (let j = 0; j < this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials.length; j++) {
            this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials[j].IsAccepted = false;
            this.pathologyRequestMainFormViewModel._PathologyRequest.PathologyMaterials[j].IsRejected = false;
        }
        this.PathologyList = [];
        this.materialsGridInstance.instance.refresh();
    }


    //GeneratePathologyProcedureListColumns() {
    //    let that = this;

    //    this.PathologyProcedureListColumns = [
    //        {
    //            caption: 'İşlem',
    //            dataField: 'ProcedureObject.ObjectID',
    //            allowEditing: true,
    //            allowSorting: false,
    //            fixed: true,
    //            width: '70%',
    //            lookup: {
    //                dataSource: that.pathologyTestDefinitionArray, valueExpr: 'ObjectID', displayExpr: 'Name'
    //            }
    //        },
    //        {
    //            caption: 'Miktar',
    //            dataField: 'Amount',
    //            allowEditing: true,
    //            fixed: true,
    //            allowSorting: false,
    //            width: '30%'
    //        }
    //    ];

    //}


    addProcedureToMaterial(row): void {//Seçilen materyale işlem ekle
        let that = this;
        that._RequestedProcedureArray.Clear();
        this.selectedMaterialForAddProcedure = row.data as PathologyMaterial;
        this.loadRequestedProcedureToPathologyMaterial(row.data);
        this.showAddProcedureToMaterialPopup = true;
    }

    loadRequestedProcedureToPathologyMaterial(data: PathologyMaterial) { //Materyalde işlem varsa load et
        let that = this;

        for (let i = 0; i < this.pathologyRequestMainFormViewModel._ProcedureArray.length; i++) {
            if (data.ObjectID == this.pathologyRequestMainFormViewModel._ProcedureArray[i].MaterialObjectID) {
                that._RequestedProcedureArray.push(this.pathologyRequestMainFormViewModel._ProcedureArray[i]);
            }
        }

    }
    onAddProcedureToMaterial(): void { //İstek sırasında eklenen ve kabul aşamasında eklenen işlemleri kaybetmemek için
        let that = this;

        let tempArray: Array<vmRequestedPathologyProcedure> = [];
        for (let j = 0; j < this.pathologyRequestMainFormViewModel._ProcedureArray.length; j++) {
            if (that.pathologyRequestMainFormViewModel._ProcedureArray[j].MaterialObjectID != this.selectedMaterialForAddProcedure.ObjectID) {
                tempArray.push(that.pathologyRequestMainFormViewModel._ProcedureArray[j]);
            }
        }

        this.pathologyRequestMainFormViewModel._ProcedureArray.Clear();

        for (let i = 0; i < tempArray.length; i++) {
            that.pathologyRequestMainFormViewModel._ProcedureArray.push(tempArray[i]);
        }
        tempArray.Clear();
        for (let i = 0; i < this._RequestedProcedureArray.length; i++) {
            that.pathologyRequestMainFormViewModel._ProcedureArray.push(this._RequestedProcedureArray[i]);
        }
        that._RequestedProcedureArray.Clear();
        this.showAddProcedureToMaterialPopup = false;
    }

    procedureSelected(data: any) {
        this.pathologyRequestMainFormViewModel._selectedProcedureObject = data;
        let that = this;
        let apiUrl: string = '/api/PathologyMaterialService/AddNewPathologyProcedure?ProcedureDefObjectId=' + data.ObjectID + "&EpisodeActionObjectId=" + that.pathologyRequestMainFormViewModel._PathologyRequest.ObjectID;

        that.httpService.get<any>(apiUrl)
            .then(response => {
                let result = response;
                let vmRequest: vmRequestedPathologyProcedure = new vmRequestedPathologyProcedure();
                vmRequest.ProcedureCode = result.ProcedureCode;
                vmRequest.ProcedureName = result.ProcedureName;
                vmRequest.RequestDate = result.RequestDate;
                vmRequest.RequestBy = result.RequestBy;
                vmRequest.ProcedureUser = result.ProcedureUser;
                vmRequest.MasterResource = result.MasterResource;
                vmRequest.Amount = result.Amount;
                vmRequest.UnitPrice = result.UnitPrice;
                vmRequest.MaterialObjectID = this.selectedMaterialForAddProcedure.ObjectID;
                vmRequest.ProcedureDefObjectID = result.ProcedureDefObjectID;
                vmRequest.SubActionProcedureObjectId = result.SubActionProcedureObjectId;
                that._RequestedProcedureArray.unshift(vmRequest);

            })
            .catch(error => {
                console.log(error);
            });
    }

    public ProcedureListColumns = [
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "ProcedureCode",
            width: 90,
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "ProcedureName",
            width: '100%',
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M10505", "Adet"),
            dataField: "Amount",
            width: 50,
            allowSorting: false,
            allowEditing: true
        },
        {
            "caption": i18n("M23606", "Tutar"),
            dataField: "UnitPrice",
            width: 60,
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16696", "İstem Yapan"),
            dataField: "RequestBy",
            width: 100,
            allowSorting: false,
            allowEditing: false
        },
        //{
        //    "caption": "İstem Uygulayan",
        //    dataField: "ProcedureUser",
        //    width: 180,
        //    allowSorting: false,
        //    allowEditing: false
        //},
        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 100,
            dataType: 'datetime',
            //format: 'dd/MM/yyyy',
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16715", "İstenilen Birim"),
            dataField: "MasterResource",
            width: 100,
            allowSorting: false,
            allowEditing: false
        },
        //{
        //    "caption": "İşlem Durum",
        //    dataField: "ActionStatus",
        //    width: 100,
        //    allowSorting: true
        //},

    ];

    onRowClickPathologyList(row: any): void {

        let that = this;
        this.RequestedProcedureList.Clear();
        for (let j = 0; j < this.pathologyRequestMainFormViewModel._ProcedureArray.length; j++) {
            if (that.pathologyRequestMainFormViewModel._ProcedureArray[j].MaterialObjectID == row.data.MaterialObjectID) {
                this.RequestedProcedureList.push(that.pathologyRequestMainFormViewModel._ProcedureArray[j]);
            }
        }


    }

    onBiopsyValueChanged(data, event) {
        let that = this;
        //Biyopsi seçildiğinde aynı grup içerisindeki tüm materyaller biyopsi olmalı,sitoloji checkleri disabled olmalı.
        let groupCount = data.GroupCount;

        for (let i = 0; i < that.PathologyList.length; i++) {
            if (that.PathologyList[i].GroupCount == groupCount) {
                that.PathologyList[i].BiopsyCheck = event.value;
                that.PathologyList[i].CytologyDisabled = event.value;
            }

        }

    }
    onCytologyValueChanged(data, event) {
        let that = this;
        //Sitoloji seçildiğinde aynı grup içerisindeki tüm materyaller sitoloji olmalı,biyopsi checkleri disabled olmalı.
        let groupCount = data.GroupCount;

        for (let i = 0; i < that.PathologyList.length; i++) {
            if (that.PathologyList[i].GroupCount == groupCount) {
                that.PathologyList[i].CytologyCheck = event.value;
                that.PathologyList[i].BiopsyDisabled = event.value;
            }

        }
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let pathologyBarcode = new DynamicSidebarMenuItem();
        pathologyBarcode.key = 'pathologyBarcode';
        pathologyBarcode.icon = 'ai ai-barkod-bas';
        pathologyBarcode.label = 'Patoloji Barkodu';
        pathologyBarcode.componentInstance = this;
        pathologyBarcode.clickFunction = this.printPathologyBarcode;
        this.sideBarMenuService.addMenu('Barkod', pathologyBarcode);

        let patientAdmissionBarcode = new DynamicSidebarMenuItem();
        patientAdmissionBarcode.key = 'patientAdmissionBarcode';
        patientAdmissionBarcode.icon = 'ai ai-barkod-bas';
        patientAdmissionBarcode.label = 'Kabul Barkodu';
        patientAdmissionBarcode.componentInstance = this;
        patientAdmissionBarcode.clickFunction = this.printpatientAdmissionBarcode;
        this.sideBarMenuService.addMenu('Barkod', patientAdmissionBarcode);

        let pathologyRequestReport = new DynamicSidebarMenuItem();
        pathologyRequestReport.key = 'pathologyRequestReport';
        pathologyRequestReport.icon = 'fa fa-file-text-o';
        pathologyRequestReport.label = 'Patoloji İstem Formu';
        pathologyRequestReport.componentInstance = this;
        pathologyRequestReport.clickFunction = this.openPathologyRequestReport;
        this.sideBarMenuService.addMenu('YardimciMenu', pathologyRequestReport);

    }
    private RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('pathologyBarcode');
        this.sideBarMenuService.removeMenu('pathologyRequestReport');
        this.sideBarMenuService.removeMenu('patientAdmissionBarcode');
    }

    public openPathologyRequestReport() {
        let that = this;

        let reportData: DynamicReportParameters = {

            Code: 'PATOLOJIISTEM',
            ReportParams: { ObjectID: this.pathologyRequestMainFormViewModel._PathologyRequest.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "PATOLOJİ İSTEM FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();
    }

    printPathologyBarcode() {
        //Kabul edilmiş materyallere barkod basılacak
        if (this.pathologyRequestMainFormViewModel._PathologyRequest.CurrentStateDefID == PathologyRequest.PathologyRequestStates.Procedure) {
            let that = this;
            let apiUrl: string = '/api/PathologyRequestService/GetMaterialBarcodeInfo?PathologyRequestID=' + that._PathologyRequest.ObjectID;

            that.httpService.get<Array<MaterialBarcodeInfo>>(apiUrl)
                .then(response => {
                    let result = response  as Array<MaterialBarcodeInfo>;;
                    for(var i=0;i<result.length;i++)
                        this.printMaterialBarcode(result[i]);

                })
                .catch(error => {
                    console.log(error);
                });
        }else
        {
            this.messageService.showError("Barkod basabilmeniz için isteği kabul etmelisiniz.");
        }


    }

    printpatientAdmissionBarcode() {
        let that = this;
        let apiUrl: string = '/api/PathologyRequestService/GetPatientAdmissionBarcodeInfo?PathologyRequestID=' + that._PathologyRequest.ObjectID;

        that.httpService.get<PatientBarcodeInfo>(apiUrl)
            .then(response => {
                let result = response as PatientBarcodeInfo;
                this.barcodePrintService.printAllBarcode(result, "generatePatientBarcode", "printPatientBarcode");

            })
            .catch(error => {
                console.log(error);
            });
    }

    printMaterialBarcode(data: MaterialBarcodeInfo)
    {
        let info :PatologyBarcodeInfo = new PatologyBarcodeInfo();
        info.PatientIdentifier = data.PatientID;
        info.PatientName = data.PatientNameSurname;
        info.Protocol = data.ProtocolNo;
        info.DoctorName = data.RequestDoctorName;
        info.PoliclinicName = data.RequestUnit;
        info.SampleAcceptionDate = data.DateOfSampleTaken;
        info.MaterialAcceptionDate = data.MaterialAcceptionDate;
        info.Organ = data.Organ;
        info.MaterialArchiveNo = data.MaterialArchiveNo;
        info.Barcode = data.Barcode;
        this.barcodePrintService.printAllBarcode(info, "generatePatologyBarcode", "");

    }

    confirmSave():boolean {
        let that = this;
        let biopsyflag: boolean = false;
        let cytologyflag: boolean = false;
        for (var i = 0; i < that.pathologyRequestMainFormViewModel.SelectedPathologyMaterialArray.length; i++) {
            if(that.pathologyRequestMainFormViewModel.SelectedPathologyMaterialArray[i])

                if (that.pathologyRequestMainFormViewModel.SelectedPathologyMaterialArray[i].BiopsyCheck == true)
                    biopsyflag = true;
                else if (that.pathologyRequestMainFormViewModel.SelectedPathologyMaterialArray[i].CytologyCheck == true)
                    cytologyflag = true;
        }

        if (that.pathologyRequestMainFormViewModel.SelectedPathologyMaterialArray.length> 0 && !biopsyflag && !cytologyflag)
            return false;

        return true;

    }

    onValueChangedProcedureDoctorList(e) {
        this.pathologyRequestMainFormViewModel.ProcedureDoctorID = e.value as Guid; //Seçilenin guidi geliyor
    }
}
