//$53DB6793
import { Component, OnInit, NgZone, ViewChild } from '@angular/core';
import { PathologyRequestFormViewModel, RequestedPathologyProcedures } from './PathologyRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { PathologyAcceptTemplateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DxDataGridComponent } from "devextreme-angular";

@Component({
    selector: 'PathologyRequestForm',
    templateUrl: './PathologyRequestForm.html',
    providers: [MessageService]
})
export class PathologyRequestForm extends EpisodeActionForm implements OnInit, IModal {
    @ViewChild('materialsGrid') materialsGrid: DxDataGridComponent;

    PathologyMaterialListColumns = [];

    public yerlesimYeriArray: Array<any> = [];
    public YerlesimYeriCache: any;
    public alindigiDokununTemelOzelligiArray: Array<any> = [];
    public AlindigiDokununTemelOzelligiCache: any;
    public numuneAlinmaSekliArray: Array<any> = [];
    public NumuneAlinmaSekliCache: any;
    public kavanozTipiArray: Array<any> = [];
    public KavanozTipiCache: any;

    RequestDate: TTVisual.ITTDateTimePicker;
    AlindigiDokununTemelOzelligiPathologyMaterial: TTVisual.ITTListBoxColumn;
    ClinicalFindingsPathologyMaterial: TTVisual.ITTTextBoxColumn;
    DateOfSampleTakenPathologyMaterial: TTVisual.ITTDateTimePickerColumn;
    DescriptionPathologyMaterial: TTVisual.ITTTextBoxColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    labelRequestDate: TTVisual.ITTLabel;
    labelRequestMaterialNumber: TTVisual.ITTLabel;
    MaterialNumberPathologyMaterial: TTVisual.ITTTextBoxColumn;
    NumuneAlinmaSekliPathologyMaterial: TTVisual.ITTListBoxColumn;
    PathologyMaterials: TTVisual.ITTGrid;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONENUMBER: TTVisual.ITTTextBox;
    RequestMaterialNumber: TTVisual.ITTTextBox;
    TabPageProcedure: TTVisual.ITTTabPage;
    TabPathologyProcedure: TTVisual.ITTTabControl;
    ttcheckboxcolumn1: TTVisual.ITTCheckBoxColumn;
    ttcheckboxcolumn2: TTVisual.ITTCheckBoxColumn;
    ttdatetimepickercolumn1: TTVisual.ITTDateTimePickerColumn;
    ttenumcomboboxcolumn2: TTVisual.ITTEnumComboBoxColumn;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlistboxcolumn1: TTVisual.ITTListBoxColumn;
    ttlistboxcolumn2: TTVisual.ITTListBoxColumn;
    YerlesimYeriPathologyMaterial: TTVisual.ITTListBoxColumn;
    MaterialProcedureList: TTVisual.ITTObjectListBox;
    public GridEpisodeDiagnosisColumns = [];
    public PathologyMaterialsColumns = [];
    public pathologyRequestFormViewModel: PathologyRequestFormViewModel = new PathologyRequestFormViewModel();
    _selectedMaterialForAddProcedure: PathologyMaterial = new PathologyMaterial();
    _showAddProcedureToMaterialPopup = false;
    _RequestedProcedureArray: Array<RequestedPathologyProcedures> = new Array<RequestedPathologyProcedures>();
    _materialNoCount: number = 0;
    _RequestedProcedureListArray: Array<RequestedPathologyProcedures> = new Array<RequestedPathologyProcedures>();

    public get _PathologyRequest(): PathologyRequest {
        return this._TTObject as PathologyRequest;
    }
    private PathologyRequestForm_DocumentUrl: string = '/api/PathologyRequestService/PathologyRequestForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone,
                protected modalService: IModalService,
                private reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);

        this._DocumentServiceUrl = this.PathologyRequestForm_DocumentUrl;
        this._showAddProcedureToMaterialPopup = false;
        this._materialNoCount = 0;
        this._RequestedProcedureListArray = new Array<RequestedPathologyProcedures>();
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    async setInputParam(value: Object) {

        if (value != null) {
            this._TTObject = value as PathologyRequest;
            this.pathologyRequestFormViewModel = new PathologyRequestFormViewModel();
            this._ViewModel = this.pathologyRequestFormViewModel;
            this.pathologyRequestFormViewModel._PathologyRequest = value as PathologyRequest;
            this.pathologyRequestFormViewModel._PathologyRequest.PathologyMaterials = new Array<PathologyMaterial>();


        }

    }
  /*  private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }*/
    private async btnSelectTemplate_Click(): Promise<void> {
        /*let objectContext: TTObjectContext = new TTObjectContext(true);
        let templates: Array<any> = objectContext.QueryObjects("PATHOLOGYACCEPTTEMPLATEDEFINITION");
        let pForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let template of templates) { pForm.AddMSItem(template.Name, template.ObjectID.toString(), template); }
        let sKey: string = pForm.GetMSItem(this, "Patoloji paketi seçiniz.", false, false, false, false, true, false);
        if (!String.isNullOrEmpty(sKey)) {
            let selectedTemplate: PathologyAcceptTemplateDefinition = <PathologyAcceptTemplateDefinition>pForm.MSSelectedItemObject;
            for (let detail of selectedTemplate.PathologyAcceptTemplateDetails) {
                this.AddTestsFromSelectedTemplate(detail, this._PathologyRequest);
            }
        }*/
    }
    private async GridPathologyTests_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {

    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //this.openPathologyRequestReport();
    }
    protected async ClientSidePreScript(): Promise<void> {

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {

        for (let i = 0; i < this.pathologyRequestFormViewModel.PathologyMaterialsGridList.length; i++)
        {
            this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].CurrentStateDefID = PathologyMaterial.PathologyMaterialStates.New;
        }


        //super.PostScript(transDef);
        //if (this.REQUESTDOCTOR === null || this.REQUESTDOCTOR.SelectedObject === null)
        //    throw new TTException("İstek yapan tabip bilgisini giriniz!");
        //let requestDate: Date = Date.Parse(this.RequestDate.Text);
        //for (let material of this._PathologyRequest.PathologyMaterials) {
        //    let materialDate: Date = Convert.ToDateTime(material.DateOfSampleTaken);
        //    let comparisonResult: number = Date.Compare(materialDate, requestDate);
        //    if (comparisonResult > 0 || comparisonResult === 0)
        //        throw new TTException("'Numunenin Alındığı Tarih' 'İstek Tarihi''nden önceki bir tarih olmalıdır!");
        //}
        //if (this._PathologyRequest.RequestMaterialNumber.Value === null) {
        //    this._PathologyRequest.RequestMaterialNumber.GetNextValue();
        //}
    }
    protected async PreScript() {
        await super.PreScript();
    }
    public async AddTestsFromSelectedTemplate(detail: PathologyAcceptTemplateDetail, pathology: PathologyRequest): Promise<void> {

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PathologyRequest();
        this.pathologyRequestFormViewModel = new PathologyRequestFormViewModel();
        this._ViewModel = this.pathologyRequestFormViewModel;
        this.pathologyRequestFormViewModel._PathologyRequest = this._TTObject as PathologyRequest;
        this.pathologyRequestFormViewModel._PathologyRequest.RequestDoctor = new ResUser();
        this.pathologyRequestFormViewModel._PathologyRequest.PathologyMaterials = new Array<PathologyMaterial>();
        this.pathologyRequestFormViewModel._PathologyRequest.Episode = new Episode();
        this.pathologyRequestFormViewModel._PathologyRequest.Episode.Diagnosis = new Array<DiagnosisGrid>();
    }

    protected loadViewModel() {
        let that = this;

        that.pathologyRequestFormViewModel = this._ViewModel as PathologyRequestFormViewModel;
        that._TTObject = this.pathologyRequestFormViewModel._PathologyRequest;
        if (this.pathologyRequestFormViewModel == null)
            this.pathologyRequestFormViewModel = new PathologyRequestFormViewModel();
        if (this.pathologyRequestFormViewModel._PathologyRequest == null)
            this.pathologyRequestFormViewModel._PathologyRequest = new PathologyRequest();
        let requestDoctorObjectID = that.pathologyRequestFormViewModel._PathologyRequest["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.pathologyRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.pathologyRequestFormViewModel._PathologyRequest.RequestDoctor = requestDoctor;
            }
        }
        that.pathologyRequestFormViewModel._PathologyRequest.PathologyMaterials = that.pathologyRequestFormViewModel.PathologyMaterialsGridList;
        //for (let detailItem of that.pathologyRequestFormViewModel.PathologyMaterialsGridList) {
        //    let yerlesimYeriObjectID = detailItem["YerlesimYeri"];
        //    if (yerlesimYeriObjectID != null && (typeof yerlesimYeriObjectID === 'string')) {
        //        let yerlesimYeri = that.pathologyRequestFormViewModel.SKRSICDOYERLESIMYERIs.find(o => o.ObjectID.toString() === yerlesimYeriObjectID.toString());
        //        detailItem.YerlesimYeri = yerlesimYeri;
        //    }
        //    let alindigiDokununTemelOzelligiObjectID = detailItem["AlindigiDokununTemelOzelligi"];
        //    if (alindigiDokununTemelOzelligiObjectID != null && (typeof alindigiDokununTemelOzelligiObjectID === 'string')) {
        //        let alindigiDokununTemelOzelligi = that.pathologyRequestFormViewModel.SKRSNumuneAlindigiDokununTemelOzelligis.find(o => o.ObjectID.toString() === alindigiDokununTemelOzelligiObjectID.toString());
        //        detailItem.AlindigiDokununTemelOzelligi = alindigiDokununTemelOzelligi;
        //    }
        //    let numuneAlinmaSekliObjectID = detailItem["NumuneAlinmaSekli"];
        //    if (numuneAlinmaSekliObjectID != null && (typeof numuneAlinmaSekliObjectID === 'string')) {
        //        let numuneAlinmaSekli = that.pathologyRequestFormViewModel.SKRSNumuneAlinmaSeklis.find(o => o.ObjectID.toString() === numuneAlinmaSekliObjectID.toString());
        //        detailItem.NumuneAlinmaSekli = numuneAlinmaSekli;
        //    }
        //}
        this.pathologyRequestFormViewModel._ProcedureArray = new Array<RequestedPathologyProcedures>();
    }


    async ngOnInit()   {
        let that = this;
        that.yerlesimYeriArray = await this.YerlesimYeri();
        that.alindigiDokununTemelOzelligiArray = await this.AlindigiDokununTemelOzelligi();
        that.numuneAlinmaSekliArray = await this.NumuneAlinmaSekli();
        that.kavanozTipiArray = await this.KavanozTipi();
        that.GenerateMaterialListColumns();
        await this.load(PathologyRequestFormViewModel);
  
    }


    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null && this._PathologyRequest.RequestDate != event) {
                this._PathologyRequest.RequestDate = event;
            }
        }
    }

    public onREQUESTDOCTORChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null && this._PathologyRequest.RequestDoctor != event) {
                this._PathologyRequest.RequestDoctor = event;
            }
        }
    }

    public onREQUESTDOCTORPHONENUMBERChanged(event): void {
        if (event != null) {
            if (this._PathologyRequest != null &&
                this._PathologyRequest.RequestDoctor != null && this._PathologyRequest.RequestDoctor.PhoneNumber != event) {
                this._PathologyRequest.RequestDoctor.PhoneNumber = event;
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
        redirectProperty(this.REQUESTDOCTORPHONENUMBER, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.RequestMaterialNumber, "Text", this.__ttObject, "RequestMaterialNumber");
    }

    public initFormControls(): void {
        this.labelRequestMaterialNumber = new TTVisual.TTLabel();
        this.labelRequestMaterialNumber.Text = i18n("M16614", "İstek Arşiv Numarası");
        this.labelRequestMaterialNumber.Name = "labelRequestMaterialNumber";
        this.labelRequestMaterialNumber.TabIndex = 17;

        this.RequestMaterialNumber = new TTVisual.TTTextBox();
        this.RequestMaterialNumber.BackColor = "#F0F0F0";
        this.RequestMaterialNumber.ReadOnly = true;
        this.RequestMaterialNumber.Name = "RequestMaterialNumber";
        this.RequestMaterialNumber.TabIndex = 16;

        this.REQUESTDOCTORPHONENUMBER = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONENUMBER.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONENUMBER.ReadOnly = true;
        this.REQUESTDOCTORPHONENUMBER.Name = "REQUESTDOCTORPHONENUMBER";
        this.REQUESTDOCTORPHONENUMBER.TabIndex = 9;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M16672", "İstek Yapan Tabip Telefon No");
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 8;

        this.TabPathologyProcedure = new TTVisual.TTTabControl();
        this.TabPathologyProcedure.Name = "TabPathologyProcedure";
        this.TabPathologyProcedure.TabIndex = 15;

        this.TabPageProcedure = new TTVisual.TTTabPage();
        this.TabPageProcedure.DisplayIndex = 0;
        this.TabPageProcedure.BackColor = "#FFFFFF";
        this.TabPageProcedure.TabIndex = 0;
        this.TabPageProcedure.Text = i18n("M18695", "Materyal");
        this.TabPageProcedure.Name = "TabPageProcedure";

        this.PathologyMaterials = new TTVisual.TTGrid();
        this.PathologyMaterials.Name = "PathologyMaterials";
        this.PathologyMaterials.TabIndex = 0;

        this.DateOfSampleTakenPathologyMaterial = new TTVisual.TTDateTimePickerColumn();
        this.DateOfSampleTakenPathologyMaterial.CustomFormat = "dd/MM/yyyy HH:mm";
        this.DateOfSampleTakenPathologyMaterial.DataMember = "DateOfSampleTaken";
        this.DateOfSampleTakenPathologyMaterial.Required = true;
        this.DateOfSampleTakenPathologyMaterial.DisplayIndex = 0;
        this.DateOfSampleTakenPathologyMaterial.HeaderText = i18n("M19537", "Numune Alınma Tarihi");
        this.DateOfSampleTakenPathologyMaterial.Name = "DateOfSampleTakenPathologyMaterial";
        this.DateOfSampleTakenPathologyMaterial.Width = 155;

        this.MaterialNumberPathologyMaterial = new TTVisual.TTTextBoxColumn();
        this.MaterialNumberPathologyMaterial.DataMember = "MaterialNumber";
        this.MaterialNumberPathologyMaterial.DisplayIndex = 1;
        this.MaterialNumberPathologyMaterial.HeaderText = i18n("M18696", "Materyal Arşiv Numarası");
        this.MaterialNumberPathologyMaterial.Name = "MaterialNumberPathologyMaterial";
        this.MaterialNumberPathologyMaterial.ReadOnly = true;
        this.MaterialNumberPathologyMaterial.Width = 100;

        this.YerlesimYeriPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.YerlesimYeriPathologyMaterial.ListDefName = "SKRSICDOYERLESIMYERIList";
        this.YerlesimYeriPathologyMaterial.DataMember = "YerlesimYeri";
        this.YerlesimYeriPathologyMaterial.Required = true;
        this.YerlesimYeriPathologyMaterial.DisplayIndex = 2;
        this.YerlesimYeriPathologyMaterial.HeaderText = i18n("M10716", "Alındığı Organ");
        this.YerlesimYeriPathologyMaterial.Name = "YerlesimYeriPathologyMaterial";
        this.YerlesimYeriPathologyMaterial.Width = 150;

        this.AlindigiDokununTemelOzelligiPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.AlindigiDokununTemelOzelligiPathologyMaterial.ListDefName = "SKRSNumuneAlindigiDokununTemelOzelligiList";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.DataMember = "AlindigiDokununTemelOzelligi";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.Required = true;
        this.AlindigiDokununTemelOzelligiPathologyMaterial.DisplayIndex = 3;
        this.AlindigiDokununTemelOzelligiPathologyMaterial.HeaderText = i18n("M10715", "Alındığı Dokunun Temel Özelliği");
        this.AlindigiDokununTemelOzelligiPathologyMaterial.Name = "AlindigiDokununTemelOzelligiPathologyMaterial";
        this.AlindigiDokununTemelOzelligiPathologyMaterial.Width = 150;

        this.NumuneAlinmaSekliPathologyMaterial = new TTVisual.TTListBoxColumn();
        this.NumuneAlinmaSekliPathologyMaterial.ListDefName = "SKRSNumuneAlinmaSekliList";
        this.NumuneAlinmaSekliPathologyMaterial.DataMember = "NumuneAlinmaSekli";
        this.NumuneAlinmaSekliPathologyMaterial.Required = true;
        this.NumuneAlinmaSekliPathologyMaterial.DisplayIndex = 4;
        this.NumuneAlinmaSekliPathologyMaterial.HeaderText = i18n("M10718", "Alınma Şekli");
        this.NumuneAlinmaSekliPathologyMaterial.Name = "NumuneAlinmaSekliPathologyMaterial";
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

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 6;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.RequestDate.Format = DateTimePickerFormat.Custom;
        this.RequestDate.Enabled = false;
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 1;

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M16650", "İstek Tarihi");
        this.labelRequestDate.ForeColor = "#000000";
        this.labelRequestDate.Name = "labelRequestDatee";
        this.labelRequestDate.TabIndex = 0;

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 7;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.AllowUserToDeleteRows = false;
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 6;

        this.ttcheckboxcolumn1 = new TTVisual.TTCheckBoxColumn();
        this.ttcheckboxcolumn1.DataMember = "AddToHistory";
        this.ttcheckboxcolumn1.DisplayIndex = 0;
        this.ttcheckboxcolumn1.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.ttcheckboxcolumn1.Name = "ttcheckboxcolumn1";
        this.ttcheckboxcolumn1.Width = 90;

        this.ttlistboxcolumn1 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn1.ListDefName = "DiagnosisListDefinition";
        this.ttlistboxcolumn1.DataMember = "Diagnose";
        this.ttlistboxcolumn1.DisplayIndex = 1;
        this.ttlistboxcolumn1.HeaderText = i18n("M24028", "Vaka Tanıları");
        this.ttlistboxcolumn1.Name = "ttlistboxcolumn1";
        this.ttlistboxcolumn1.Width = 300;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnosisType.DataMember = "DiagnosisType";
        this.EpisodeDiagnosisType.DisplayIndex = 2;
        this.EpisodeDiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.EpisodeDiagnosisType.Name = "EpisodeDiagnosisType";
        this.EpisodeDiagnosisType.Width = 80;

        this.ttcheckboxcolumn2 = new TTVisual.TTCheckBoxColumn();
        this.ttcheckboxcolumn2.DataMember = "IsMainDiagnose";
        this.ttcheckboxcolumn2.DisplayIndex = 3;
        this.ttcheckboxcolumn2.HeaderText = i18n("M10926", "Ana Tanı");
        this.ttcheckboxcolumn2.Name = "ttcheckboxcolumn2";
        this.ttcheckboxcolumn2.Width = 60;

        this.ttlistboxcolumn2 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn2.ListDefName = "UserListDefinition";
        this.ttlistboxcolumn2.DataMember = "ResponsibleUser";
        this.ttlistboxcolumn2.DisplayIndex = 4;
        this.ttlistboxcolumn2.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.ttlistboxcolumn2.Name = "ttlistboxcolumn2";
        this.ttlistboxcolumn2.Width = 115;

        this.ttdatetimepickercolumn1 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn1.DataMember = "DiagnoseDate";
        this.ttdatetimepickercolumn1.DisplayIndex = 5;
        this.ttdatetimepickercolumn1.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.ttdatetimepickercolumn1.Name = "ttdatetimepickercolumn1";
        this.ttdatetimepickercolumn1.Width = 100;

        this.ttenumcomboboxcolumn2 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn2.DataTypeName = "ActionTypeEnum";
        this.ttenumcomboboxcolumn2.DataMember = "EntryActionType";
        this.ttenumcomboboxcolumn2.DisplayIndex = 6;
        this.ttenumcomboboxcolumn2.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.ttenumcomboboxcolumn2.Name = "ttenumcomboboxcolumn2";
        this.ttenumcomboboxcolumn2.Width = 100;

        this.MaterialProcedureList = new TTVisual.TTObjectListBox();
        this.MaterialProcedureList.ListDefName = "PathologyTestListDefinition";
        this.MaterialProcedureList.Name = "PathologyTestList";

        this.PathologyMaterialsColumns = [this.DateOfSampleTakenPathologyMaterial, this.MaterialNumberPathologyMaterial, this.YerlesimYeriPathologyMaterial, this.AlindigiDokununTemelOzelligiPathologyMaterial, this.NumuneAlinmaSekliPathologyMaterial, this.ClinicalFindingsPathologyMaterial, this.DescriptionPathologyMaterial];
        this.GridEpisodeDiagnosisColumns = [this.ttcheckboxcolumn1, this.ttlistboxcolumn1, this.EpisodeDiagnosisType, this.ttcheckboxcolumn2, this.ttlistboxcolumn2, this.ttdatetimepickercolumn1, this.ttenumcomboboxcolumn2];
        this.TabPathologyProcedure.Controls = [this.TabPageProcedure];
        this.TabPageProcedure.Controls = [this.PathologyMaterials];
        this.Controls = [this.labelRequestMaterialNumber, this.RequestMaterialNumber, this.REQUESTDOCTORPHONENUMBER, this.ttlabel3, this.TabPathologyProcedure, this.TabPageProcedure, this.PathologyMaterials, this.DateOfSampleTakenPathologyMaterial, this.MaterialNumberPathologyMaterial, this.YerlesimYeriPathologyMaterial, this.AlindigiDokununTemelOzelligiPathologyMaterial, this.NumuneAlinmaSekliPathologyMaterial, this.ClinicalFindingsPathologyMaterial, this.DescriptionPathologyMaterial, this.ttlabel4, this.RequestDate, this.labelRequestDate, this.REQUESTDOCTOR, this.GridEpisodeDiagnosis, this.ttcheckboxcolumn1, this.ttlistboxcolumn1, this.EpisodeDiagnosisType, this.ttcheckboxcolumn2, this.ttlistboxcolumn2, this.ttdatetimepickercolumn1, this.ttenumcomboboxcolumn2];

    }

    GenerateMaterialListColumns() {
        let that = this;

        this.PathologyMaterialListColumns = [
            {
                caption: i18n("M19537", "Numune Alınma Tarihi"),
                dataField: 'DateOfSampleTaken',
                allowEditing: true,
                fixed: true,
                allowSorting: false,
                dataType: 'date',
                format: 'dd/MM/yyyy',
                width: '15%'

            }, {
                caption: i18n("M10716", "Alındığı Organ"),
                dataField: 'YerlesimYeri.ObjectID',
                fixed: true, width: '15%',
                allowSorting: false,
                allowEditing: true,
                lookup: {
                    dataSource: that.yerlesimYeriArray, valueExpr: 'ObjectID', displayExpr: 'KODTANIMI'
                }
            },
            {
                caption: i18n("M10715", "Alındığı Dokunun Temel Özelliği"),
                dataField: 'AlindigiDokununTemelOzelligi.ObjectID',
                fixed: true, width: '10%',
                allowSorting: false,
                allowEditing: true,
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
                allowEditing: true,
                lookup: {
                    dataSource: that.numuneAlinmaSekliArray, valueExpr: 'ObjectID', displayExpr: 'ADI'
                }
            },
            {
                caption: "Kavanoz Tipi",
                dataField: "KavanozTipi.ObjectID",
                fixed: true,
                width: '10%',
                allowSorting: false,
                allowEditing: true,
                lookup: {
                    dataSource: that.kavanozTipiArray, valueExpr: 'ObjectID', displayExpr: 'JarType'
                }
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
            }, {
                caption: "Tetkik Ekle",
                width: 75,
                fixed: true,
                allowSorting: false,
                cellTemplate: "linkCellTemplateAddProcedure",
            }
        ];

    }
    public async YerlesimYeri(): Promise<any> {
        if (!this.YerlesimYeriCache) {
            this.YerlesimYeriCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSYerlesimYeri');
            return this.YerlesimYeriCache;
        }
        else {
            return this.YerlesimYeriCache;
        }
    }

    public async AlindigiDokununTemelOzelligi(): Promise<any> {
        if (!this.AlindigiDokununTemelOzelligiCache) {
            this.AlindigiDokununTemelOzelligiCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSAlindigiDokununTemelOzelligi');
            return this.AlindigiDokununTemelOzelligiCache;
        }
        else {
            return this.AlindigiDokununTemelOzelligiCache;
        }
    }
    public async NumuneAlinmaSekli(): Promise<any> {
        if (!this.NumuneAlinmaSekliCache) {
            this.NumuneAlinmaSekliCache = await this.httpService.get('/api/PathologyRequestService/GetSKRSNumuneAlinmaSekli');
            return this.NumuneAlinmaSekliCache;
        }
        else {
            
            return this.NumuneAlinmaSekliCache;
        }

    }
    public async KavanozTipi(): Promise<any> {
        if (!this.KavanozTipiCache) {
            this.KavanozTipiCache = await this.httpService.get('/api/PathologyRequestService/GetKavanozTipi');
            return this.KavanozTipiCache;
        }
        else {

            return this.KavanozTipiCache;
        }

    }

    addProcedureToMaterial(row): void {//Seçilen materyale işlem ekle

        this._selectedMaterialForAddProcedure = row.data as PathologyMaterial;
  
        this._showAddProcedureToMaterialPopup = true;
    }

    ProcedureListColumns = [
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

    RequestedProcedureListColumns = [

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
            "caption": i18n("M16696", "İstem Yapan"),
            dataField: "RequestBy",
            width: 100,
            allowSorting: false,
            allowEditing: false
        },

        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 150,
            dataType: 'datetime',
            //format: 'dd/MM/yyyy',
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16715", "İstenilen Birim"),
            dataField: "MasterResource",
            width: 200,
            allowSorting: false,
            allowEditing: false
        }


    ];

    onAddProcedureToMaterial(): void {
        let that = this;
        for (let i = 0; i < this._RequestedProcedureArray.length; i++) {
            this.pathologyRequestFormViewModel._ProcedureArray.push(this._RequestedProcedureArray[i]);
            that._RequestedProcedureListArray.push(this._RequestedProcedureArray[i]);
        }
        that._RequestedProcedureArray.Clear();
        this._showAddProcedureToMaterialPopup = false;
    }

    procedureSelected(data: any) {
        this.pathologyRequestFormViewModel._selectedProcedureObject = data;
        let that = this;
        let apiUrl: string = '/api/PathologyRequestService/AddNewPathologyProcedure?ProcedureDefObjectId=' + data.ObjectID + "&EpisodeActionObjectId=" + that.pathologyRequestFormViewModel._PathologyRequest.ObjectID;

        that.httpService.get<any>(apiUrl)
            .then(response => {
                let result = response;
                let vmRequest: RequestedPathologyProcedures = new RequestedPathologyProcedures();
                vmRequest.ProcedureCode = result.ProcedureCode;
                vmRequest.ProcedureName = result.ProcedureName;
                vmRequest.RequestDate = result.RequestDate;
                vmRequest.RequestBy = result.RequestBy;
                vmRequest.ProcedureUser = result.ProcedureUser;
                vmRequest.MasterResource = result.MasterResource;
                vmRequest.Amount = result.Amount;
                vmRequest.UnitPrice = result.UnitPrice;
                vmRequest.MaterialNo = this._materialNoCount;
                vmRequest.ProcedureDefObjectID = result.ProcedureDefObjectID;

                that._RequestedProcedureArray.unshift(vmRequest);

            })
            .catch(error => {
                console.log(error);
            });
    }



    public openPathologyRequestReport() {
        let that = this;

        let reportData: DynamicReportParameters = {

            Code: 'PATOLOJIISTEM',
            ReportParams: { ObjectID: this.pathologyRequestFormViewModel._PathologyRequest.ObjectID },
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

    btnPathologyRequestSave_Click()
    {
        if (this.confirmSave()) {
            try {
                this.save();
           
            }
            catch (err) {
                this.messageService.showError(err.message);
            }
        }
    }

    confirmSave(): boolean {
        let result = true;

        if (this._PathologyRequest.RequestDoctor == null || this._PathologyRequest.RequestDoctor == undefined) {
            this.messageService.showError("İstek Yapan Doktoru Seçiniz.");
            result = false;
            return result;
        }

        if (this.pathologyRequestFormViewModel.PathologyMaterialsGridList.length == 0) {
            this.messageService.showError("Lütfen Materyal Ekleyiniz.");
            result = false;
            return result;
        }

        for (let i = 0; i < this.pathologyRequestFormViewModel.PathologyMaterialsGridList.length; i++) {
            if (this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].DateOfSampleTaken == null || this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].DateOfSampleTaken == undefined) {
                this.messageService.showError(i18n("M18386", "Lütfen Numune Alınma Tarihini Giriniz."));
                result = false;
            }

            if (this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].YerlesimYeri == null || this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].YerlesimYeri == undefined) {
                this.messageService.showError(i18n("M18363", "Lütfen Alındığı Organ Bilgisini Seçiniz."));
                result = false;
            }

            if (this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].AlindigiDokununTemelOzelligi == null || this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].AlindigiDokununTemelOzelligi == undefined) {
                this.messageService.showError("Lütfen Alındığı Dokunun Temel Özelliği Bilgisini Seçiniz.");
                result = false;
            }

            if (this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].NumuneAlinmaSekli == null || this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].NumuneAlinmaSekli == undefined) {
                this.messageService.showError(i18n("M18385", "Lütfen Numune Alınma Şekli Bilgisini Seçiniz."));
                result = false;
            }

            if (this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].ClinicalFindings == null || this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].ClinicalFindings == undefined) {
                this.messageService.showError("Lütfen Klinik Bulgular Bilgisini Giriniz.");
                result = false;
            }

            if (this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].Description == null || this.pathologyRequestFormViewModel.PathologyMaterialsGridList[i].Description == undefined) {
                this.messageService.showError(i18n("M18359", "Lütfen Açıklama Bilgisini Giriniz."));
                result = false;
            }

            if(this.pathologyRequestFormViewModel._ForceSelectPathologyProcedure && this.pathologyRequestFormViewModel._ProcedureArray.length == 0) 
            {
                this.messageService.showError("Tetkik Eklemeden İşleme Devam Edemezsiniz.");
                result = false;
            }

        }
        return result;
    }

    onInitNewRow(e) {
    
        //let p: PathologyMaterial = new PathologyMaterial();
        e.data.DateOfSampleTaken = new Date();
        this._materialNoCount++;
        e.data.No = this._materialNoCount;
        //this.pathologyRequestFormViewModel.PathologyMaterialsGridList.push(p);

    }

    SaveGridData() {
      
        this.materialsGrid.instance.saveEditData();

        this.materialsGrid.instance.closeEditCell();
    }

  


}
