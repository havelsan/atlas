//$B7A6A00D
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyCompletedFormViewModel } from "./RadiologyCompletedFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';

import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyRejectReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";



@Component({
    selector: 'RadiologyCompletedForm',
    templateUrl: './RadiologyCompletedForm.html',
    providers: [MessageService]
})
export class RadiologyCompletedForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    BodyPosition: TTVisual.ITTEnumComboBoxColumn;
    BodySite: TTVisual.ITTEnumComboBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridRadiologyTests: TTVisual.ITTGrid;
    labelProcessTime: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Notes: TTVisual.ITTTextBoxColumn;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    Report: TTVisual.ITTRichTextBoxControlColumn;
    ttgrid1: TTVisual.ITTGrid;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttabpage5: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    ttvaluelistbox1: TTVisual.ITTValueListBox;
    UBCODE: TTVisual.ITTTextBoxColumn;
    public GridEpisodeDiagnosisColumns = [];
    public GridRadiologyTestsColumns = [];
    public ttgrid1Columns = [];
    public radiologyCompletedFormViewModel: RadiologyCompletedFormViewModel = new RadiologyCompletedFormViewModel();
    public get _Radiology(): Radiology {
        return this._TTObject as Radiology;
    }
    private RadiologyCompletedForm_DocumentUrl: string = '/api/RadiologyService/RadiologyCompletedForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PreScript() {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Radiology();
        this.radiologyCompletedFormViewModel = new RadiologyCompletedFormViewModel();
        this._ViewModel = this.radiologyCompletedFormViewModel;
        this.radiologyCompletedFormViewModel._Radiology = this._TTObject as Radiology;
        this.radiologyCompletedFormViewModel._Radiology.RadiologyTests = new Array<RadiologyTest>();
        this.radiologyCompletedFormViewModel._Radiology.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
        this.radiologyCompletedFormViewModel._Radiology.RejectReason = new RadiologyRejectReasonDefinition();
        this.radiologyCompletedFormViewModel._Radiology.RequestDoctor = new ResUser();
        this.radiologyCompletedFormViewModel._Radiology.Episode = new Episode();
        this.radiologyCompletedFormViewModel._Radiology.Episode.Diagnosis = new Array<DiagnosisGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyCompletedFormViewModel = this._ViewModel as RadiologyCompletedFormViewModel;
        that._TTObject = this.radiologyCompletedFormViewModel._Radiology;
        if (this.radiologyCompletedFormViewModel == null)
            this.radiologyCompletedFormViewModel = new RadiologyCompletedFormViewModel();
        if (this.radiologyCompletedFormViewModel._Radiology == null)
            this.radiologyCompletedFormViewModel._Radiology = new Radiology();
        that.radiologyCompletedFormViewModel._Radiology.RadiologyTests = that.radiologyCompletedFormViewModel.ttgrid1GridList;
        for (let detailItem of that.radiologyCompletedFormViewModel.ttgrid1GridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.radiologyCompletedFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
        that.radiologyCompletedFormViewModel._Radiology.TreatmentMaterials = that.radiologyCompletedFormViewModel.GridRadiologyTestsGridList;
        for (let detailItem of that.radiologyCompletedFormViewModel.GridRadiologyTestsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.radiologyCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.radiologyCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.radiologyCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        let rejectReasonObjectID = that.radiologyCompletedFormViewModel._Radiology["RejectReason"];
        if (rejectReasonObjectID != null && (typeof rejectReasonObjectID === 'string')) {
            let rejectReason = that.radiologyCompletedFormViewModel.RadiologyRejectReasonDefinitions.find(o => o.ObjectID.toString() === rejectReasonObjectID.toString());
             if (rejectReason) {
                that.radiologyCompletedFormViewModel._Radiology.RejectReason = rejectReason;
            }
        }
        let requestDoctorObjectID = that.radiologyCompletedFormViewModel._Radiology["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.radiologyCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.radiologyCompletedFormViewModel._Radiology.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.radiologyCompletedFormViewModel._Radiology["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyCompletedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.radiologyCompletedFormViewModel._Radiology.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.radiologyCompletedFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyCompletedFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyCompletedFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
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
        await this.load(RadiologyCompletedFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.ActionDate != event) {
                this._Radiology.ActionDate = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.RequestDoctor != event) {
                this._Radiology.RequestDoctor = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.PreDiagnosis != event) {
                this._Radiology.PreDiagnosis = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.Description != event) {
                this._Radiology.Description = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.TechnicianNote != event) {
                this._Radiology.TechnicianNote = event;
            }
        }
    }

    public onttvaluelistbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.RejectReason != event) {
                this._Radiology.RejectReason = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ttvaluelistbox1, "SelectedValue", this.__ttObject, "RejectReason");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Description");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TechnicianNote");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 85;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 0;
        this.tttabpage4.BackColor = "#FFFFFF";
        this.tttabpage4.TabIndex = 0;
        this.tttabpage4.Text = i18n("M23295", "Tetkik");
        this.tttabpage4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage4.Name = "tttabpage4";

        this.ttgrid1 = new TTVisual.TTGrid();
        this.ttgrid1.Name = "ttgrid1";
        this.ttgrid1.TabIndex = 0;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "RadiologyTestListDefinition";
        this.ProcedureObject.ListFilterExpression = "o.Name";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 0;
        this.ProcedureObject.HeaderText = i18n("M23295", "Tetkik");
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.Width = 400;

        this.BodySite = new TTVisual.TTEnumComboBoxColumn();
        this.BodySite.DataTypeName = "RadiologyBodySiteEnum";
        this.BodySite.DataMember = "BodySite";
        this.BodySite.DisplayIndex = 1;
        this.BodySite.HeaderText = i18n("M22824", "Taraf");
        this.BodySite.Name = "BodySite";
        this.BodySite.ReadOnly = true;
        this.BodySite.Width = 80;

        this.BodyPosition = new TTVisual.TTEnumComboBoxColumn();
        this.BodyPosition.DataTypeName = "RadiologyBodyPositionEnum";
        this.BodyPosition.DataMember = "BodyPosition";
        this.BodyPosition.DisplayIndex = 2;
        this.BodyPosition.HeaderText = i18n("M20461", "Pozisyon");
        this.BodyPosition.Name = "BodyPosition";
        this.BodyPosition.ReadOnly = true;
        this.BodyPosition.Visible = false;
        this.BodyPosition.Width = 50;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 3;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.ReadOnly = true;
        this.Description.Visible = false;
        this.Description.Width = 150;

        this.Report = new TTVisual.TTRichTextBoxControlColumn();
        this.Report.DataMember = "Report";
        this.Report.DisplayIndex = 4;
        this.Report.HeaderText = "Rapor";
        this.Report.Name = "Report";
        this.Report.Width = 200;

        this.tttabpage5 = new TTVisual.TTTabPage();
        this.tttabpage5.DisplayIndex = 0;
        this.tttabpage5.BackColor = "#FFFFFF";
        this.tttabpage5.TabIndex = 0;
        this.tttabpage5.Text = i18n("M21309", "Sarf");
        this.tttabpage5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage5.Name = "tttabpage5";

        this.GridRadiologyTests = new TTVisual.TTGrid();
        this.GridRadiologyTests.Name = "GridRadiologyTests";
        this.GridRadiologyTests.TabIndex = 0;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M21314", "Sarf Edilen Malzeme");
        this.Material.Name = "Material";
        this.Material.ReadOnly = true;
        this.Material.Width = 450;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 1;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 100;

        this.UBCODE = new TTVisual.TTTextBoxColumn();
        this.UBCODE.DataMember = "UBBCode";
        this.UBCODE.DisplayIndex = 2;
        this.UBCODE.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBCODE.Name = "UBCODE";
        this.UBCODE.ReadOnly = true;
        this.UBCODE.Width = 100;

        this.Notes = new TTVisual.TTTextBoxColumn();
        this.Notes.DataMember = "Note";
        this.Notes.DisplayIndex = 3;
        this.Notes.HeaderText = i18n("M10469", "Açıklama");
        this.Notes.Name = "Notes";
        this.Notes.ReadOnly = true;
        this.Notes.Width = 230;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 4;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 6;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 0;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = i18n("M10483", "Açıklamalar");
        this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage2.Name = "tttabpage2";

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 0;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M17626", "Klinik Bulgular");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 58;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 0;
        this.tttabpage3.BackColor = "#FFFFFF";
        this.tttabpage3.TabIndex = 0;
        this.tttabpage3.Text = i18n("M23112", "Teknisyen Notu");
        this.tttabpage3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage3.Name = "tttabpage3";

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Multiline = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 67;

        this.ttvaluelistbox1 = new TTVisual.TTValueListBox();
        this.ttvaluelistbox1.ListDefName = "RadiologyRejectReasonListDefinition";
        this.ttvaluelistbox1.Name = "ttvaluelistbox1";
        this.ttvaluelistbox1.TabIndex = 4;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M20975", "Red Nedeni");
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 52;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 3;

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

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 28;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M17026", "Kabul Sebebi");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 4;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 2;

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
        this.EpisodeDiagnose.Width = 360;

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
        this.EntryActionType.Width = 150;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.ttgrid1Columns = [this.ProcedureObject, this.BodySite, this.BodyPosition, this.Description, this.Report];
        this.GridRadiologyTestsColumns = [this.Material, this.Amount, this.UBCODE, this.Notes, this.DistributionType];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.tttabcontrol1.Controls = [this.tttabpage4, this.tttabpage5];
        this.tttabpage4.Controls = [this.ttgrid1];
        this.tttabpage5.Controls = [this.GridRadiologyTests];
        this.tttabcontrol2.Controls = [this.tttabpage2, this.tttabpage1, this.tttabpage3];
        this.tttabpage2.Controls = [this.tttextbox2];
        this.tttabpage1.Controls = [this.tttextbox1];
        this.tttabpage3.Controls = [this.tttextbox3];
        this.Controls = [this.tttabcontrol1, this.tttabpage4, this.ttgrid1, this.ProcedureObject, this.BodySite, this.BodyPosition, this.Description, this.Report, this.tttabpage5, this.GridRadiologyTests, this.Material, this.Amount, this.UBCODE, this.Notes, this.DistributionType, this.tttabcontrol2, this.tttabpage2, this.tttextbox2, this.tttabpage1, this.tttextbox1, this.tttabpage3, this.tttextbox3, this.ttvaluelistbox1, this.ttlabel3, this.ttobjectlistbox1, this.ActionDate, this.labelProcessTime, this.ttlabel2, this.ttlabel8, this.PATIENTGROUPENUM, this.ttlabel9, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ReasonForAdmission];

    }


}
