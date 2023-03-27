//$D41F3FF0
import { Component, OnInit, NgZone  } from '@angular/core';
import { NuclearMedicineRequestFormViewModel } from './NuclearMedicineRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicineTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'NuclearMedicineRequestForm',
    templateUrl: './NuclearMedicineRequestForm.html',
    providers: [MessageService]
})
export class NuclearMedicineRequestForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    IsEmergency: TTVisual.ITTCheckBox;
    labelPreInformation: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    lblRequestCorrectionReason: TTVisual.ITTLabel;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    RequestedDoctor: TTVisual.ITTObjectListBox;
    tabTetkik: TTVisual.ITTTabControl;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    txtRequestCorrectionReason: TTVisual.ITTTextBox;
    public GridEpisodeDiagnosisColumns = [];
    public nuclearMedicineRequestFormViewModel: NuclearMedicineRequestFormViewModel = new NuclearMedicineRequestFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineRequestForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineRequestForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async CheckRequestOnItemCheck(sender: Object, e: Object): Promise<void> {
        //Tetkik İstem tarafından yonetılecek!
        //if (e.NewValue == CheckState.Unchecked)
        //    return;

        //foreach (TabPage page in this.tabTetkik.TabPages)
        //{
        //    foreach (Control control in page.Controls)
        //    {
        //        if (control is TTListView)
        //        {
        //            TTListView lv = (TTListView)control;
        //            foreach (TTListViewItem lvItem in lv.CheckedItems)
        //            {
        //                lvItem.Checked = false;
        //            }
        //        }
        //    }
        //}

        let a = 1;
    }
    private async CheckTestAlreadyRequested(nucMedTestDef: NuclearMedicineTestDefinition): Promise<boolean> {
        //Tetkik İstem tarafından yonetılecek!
        //foreach (NuclearMedicineTest test in this._NuclearMedicine.NuclearMedicineTests)
        //    if (test.NuclearMedicineTestDef.ObjectID == nucMedTestDef.ObjectID)
        //        return true;
        return false;
    }
    protected async ClientSidePreScript(): Promise<void> {

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //Tetkik İstem tarafından yonetılecek!
        //base.PostScript(transDef);
        //        this.SetCheckedItemsAsRequestedProcedures(transDef);

        //        if (this._NuclearMedicine.NuclearMedicineTests.Count == 0)
        //        {
        //            String message = SystemMessage.GetMessage(198);
        //            throw new TTUtils.TTException(message);
        //        }
        let a = 1;
    }
    protected async PreScript(): Promise<void> {
        //Tetkik İstem tarafından yonetılecek!
        //base.PreScript();

        //        for (int i = 0; i < (this.pnlButtons.Controls.Count); i++)
        //        {
        //            if (this.pnlButtons.Controls[i].Name.ToString() == "cmdOK")
        //            {
        //                this.pnlButtons.Controls[i].Visible = false;
        //            }
        //        }

        //        RequestedDoctor.SelectedObject = Common.CurrentUser.UserObject;
        //        this._NuclearMedicine.IsEmergency = false;
        //        if (!String.IsNullOrEmpty(this._NuclearMedicine.RequestCorrectionReason))
        //        {
        //            txtRequestCorrectionReason.Visible = true;
        //            lblRequestCorrectionReason.Visible = true;
        //        }
        //        this.GenerateNuclearMedicineTabs();
        let a = 1;
    }
    public async GenerateNuclearMedicineTabs(): Promise<void> {
        //Tetkik İstem tarafından yonetılecek!
        //bool isAlternatingItem = false;
        //BindingList<NucMedTestGroupDef> liste = NucMedTestGroupDef.GetTestGroups(this._NuclearMedicine.ObjectContext);
        //foreach (NucMedTestGroupDef tabDef in liste)
        //{
        //    TTTabPage tabPage = new TTTabPage();
        //    tabPage.Name = tabDef.Name;
        //    tabPage.Text = tabDef.Name;
        //    TTListView listView = new TTListView();
        //    TTListViewColumn listViewColumn = new TTListViewColumn();
        //    listViewColumn.Text = "Testler";
        //    listViewColumn.Width = -1;
        //    listView.Columns.Add(listViewColumn);
        //    listView.Name = "ListView";
        //    listView.View = View.List;
        //    listView.CheckBoxes = true;
        //    listView.FullRowSelect = true;
        //    //listView.Dock = DockStyle.Fill;
        //    //listView.BorderStyle = BorderStyle.None;
        //    listView.ItemCheck += new ItemCheckEventHandler(this.CheckRequestOnItemCheck);
        //    BindingList<NucMedTabNamesGrid> grids = NucMedTabNamesGrid.GetByTabNames(this._NuclearMedicine.ObjectContext, tabDef.ObjectID.ToString());

        //    foreach (NucMedTabNamesGrid tabGrid in grids)
        //    {
        //        isAlternatingItem = !isAlternatingItem;
        //        TTListViewItem item2 = new TTListViewItem();
        //        item2.Name = tabGrid.NuclearMedicineTest.Name;
        //        item2.Text = tabGrid.NuclearMedicineTest.Name;
        //        item2.Tag = tabGrid.NuclearMedicineTest;
        //        item2.Checked = this.CheckTestAlreadyRequested(tabGrid.NuclearMedicineTest);
        //        listView.Items.Add(item2);
        //    }
        //    tabPage.Controls.Add(listView);
        //    tabTetkik.TabPages.Add(tabPage);
        //}
        //this._NuclearMedicine.NuclearMedicineTests.DeleteChildren();
        //this._NuclearMedicine.NucMedTreatmentMats.DeleteChildren();
        let a = 1;
    }
    public async SetCheckedItemsAsRequestedProcedures(transDef: TTObjectStateTransitionDef): Promise<void> {
        //Tetkik İstem tarafından yonetılecek!
        //if (transDef != null && (transDef.FromStateDefID == NuclearMedicine.States.Request || transDef.FromStateDefID == NuclearMedicine.States.RequestAcception))
        //{
        //    foreach (TabPage page in this.tabTetkik.TabPages)
        //    {
        //        foreach (Control control in page.Controls)
        //        {
        //            if (control is TTListView)
        //            {
        //                TTListView lv = (TTListView)control;
        //                foreach (TTListViewItem lvItem in lv.CheckedItems)
        //                {
        //                    if (lvItem.Tag is NuclearMedicineTestDefinition)
        //                    {
        //                        NuclearMedicineTest nucMedTest = new NuclearMedicineTest(this._NuclearMedicine.ObjectContext); ;
        //                        if (this._NuclearMedicine.NuclearMedicineTests.Count <= 0)
        //                        {
        //                            nucMedTest.NuclearMedicine = this._NuclearMedicine;
        //                        }

        //                        NuclearMedicineTestDefinition testDef = (NuclearMedicineTestDefinition)lvItem.Tag;
        //                        this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject = testDef;

        //                        foreach (NuclearMedicineGridMaterialDefinition defMaterialGrid in testDef.Materials)
        //                        {
        //                            NucMedTreatmentMat nucMaterial = new NucMedTreatmentMat(this._NuclearMedicine.ObjectContext);
        //                            nucMaterial.Amount = 1;
        //                            nucMaterial.Material = defMaterialGrid.Material;
        //                            nucMaterial.EpisodeAction = this._EpisodeAction;
        //                            nucMedTest.NuclearMedicine.NucMedTreatmentMats.Add(nucMaterial);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        let a = 1;
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicineRequestFormViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineRequestFormViewModel = new NuclearMedicineRequestFormViewModel();
        this._ViewModel = this.nuclearMedicineRequestFormViewModel;
        this.nuclearMedicineRequestFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineRequestFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
        this.nuclearMedicineRequestFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineRequestFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineRequestFormViewModel = this._ViewModel as NuclearMedicineRequestFormViewModel;
        that._TTObject = this.nuclearMedicineRequestFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineRequestFormViewModel == null)
            this.nuclearMedicineRequestFormViewModel = new NuclearMedicineRequestFormViewModel();
        if (this.nuclearMedicineRequestFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineRequestFormViewModel._NuclearMedicine = new NuclearMedicine();
        let requestDoctorObjectID = that.nuclearMedicineRequestFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineRequestFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.nuclearMedicineRequestFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineRequestFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineRequestFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineRequestFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineRequestFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineRequestFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineRequestFormViewModel);
  
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ActionDate != event) {
                this._NuclearMedicine.ActionDate = event;
            }
        }
    }

    public onIsEmergencyChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.IsEmergency != event) {
                this._NuclearMedicine.IsEmergency = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PreDiagnosis != event) {
                this._NuclearMedicine.PreDiagnosis = event;
            }
        }
    }

    public onREQUESTDOCTORPHONEChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null &&
                this._NuclearMedicine.RequestDoctor != null && this._NuclearMedicine.RequestDoctor.PhoneNumber != event) {
                this._NuclearMedicine.RequestDoctor.PhoneNumber = event;
            }
        }
    }

    public onRequestedDoctorChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RequestDoctor != event) {
                this._NuclearMedicine.RequestDoctor = event;
            }
        }
    }

    public ontxtRequestCorrectionReasonChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RequestCorrectionReason != event) {
                this._NuclearMedicine.RequestCorrectionReason = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.txtRequestCorrectionReason, "Text", this.__ttObject, "RequestCorrectionReason");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#FFFFFF";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.lblRequestCorrectionReason = new TTVisual.TTLabel();
        this.lblRequestCorrectionReason.Text = "İstek Düzeltme Nedeni";
        this.lblRequestCorrectionReason.Name = "lblRequestCorrectionReason";
        this.lblRequestCorrectionReason.TabIndex = 3;
        this.lblRequestCorrectionReason.Visible = false;

        this.txtRequestCorrectionReason = new TTVisual.TTTextBox();
        this.txtRequestCorrectionReason.Multiline = true;
        this.txtRequestCorrectionReason.BackColor = "#F0F0F0";
        this.txtRequestCorrectionReason.ReadOnly = true;
        this.txtRequestCorrectionReason.Name = "txtRequestCorrectionReason";
        this.txtRequestCorrectionReason.TabIndex = 4;
        this.txtRequestCorrectionReason.Visible = false;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "AdmissionTypeListDef";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.RequestedDoctor = new TTVisual.TTObjectListBox();
        this.RequestedDoctor.ReadOnly = true;
        this.RequestedDoctor.ListDefName = "DoctorListDefinition";
        this.RequestedDoctor.Name = "RequestedDoctor";
        this.RequestedDoctor.TabIndex = 5;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 7;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 8;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmiş";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 60;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisDefinitionList";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 330;

        this.EpisodeDiagnoseType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnoseType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnoseType.DataMember = "DiagnosisType";
        this.EpisodeDiagnoseType.DisplayIndex = 2;
        this.EpisodeDiagnoseType.HeaderText = "Tanı Tipi";
        this.EpisodeDiagnoseType.Name = "EpisodeDiagnoseType";
        this.EpisodeDiagnoseType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = "Ana Tanı";
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 60;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = "Tanı Koyan";
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = "Tanı Giriş Tarihi";
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = "Giriş Yapılan İşlem";
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "İstek Yapan Tabip Telefon";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 8;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 6;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Kabul Sebebi";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 4;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Hasta Grubu";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 2;

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Required = true;
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#FFE3C6";
        this.PREDIAGNOSIS.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 9;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "İşlem Zamanı";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 12;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İstek Yapan Tabip";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 6;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "ttlabel1";
        this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 0;

        this.tabTetkik = new TTVisual.TTTabControl();
        this.tabTetkik.Name = "tabTetkik";
        this.tabTetkik.TabIndex = 1;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.ttgroupbox1.Controls = [this.lblRequestCorrectionReason, this.txtRequestCorrectionReason, this.ReasonForAdmission, this.RequestedDoctor, this.IsEmergency, this.PATIENTGROUPENUM, this.GridEpisodeDiagnosis, this.ttlabel7, this.REQUESTDOCTORPHONE, this.ttlabel4, this.ttlabel3, this.PREDIAGNOSIS, this.labelProcessTime, this.ActionDate, this.labelPreInformation, this.ttlabel2];
        this.Controls = [this.ttgroupbox1, this.lblRequestCorrectionReason, this.txtRequestCorrectionReason, this.ReasonForAdmission, this.RequestedDoctor, this.IsEmergency, this.PATIENTGROUPENUM, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttlabel7, this.REQUESTDOCTORPHONE, this.ttlabel4, this.ttlabel3, this.PREDIAGNOSIS, this.labelProcessTime, this.ActionDate, this.labelPreInformation, this.ttlabel2, this.ttlabel5, this.tabTetkik];

    }


}
