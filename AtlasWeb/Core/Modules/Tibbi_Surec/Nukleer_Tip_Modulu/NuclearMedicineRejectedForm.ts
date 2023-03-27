//$690FD6E2
import { Component, OnInit, NgZone  } from '@angular/core';
import { NuclearMedicineRejectedFormViewModel } from './NuclearMedicineRejectedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedRadPharmMatGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTreatmentMat } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'NuclearMedicineRejectedForm',
    templateUrl: './NuclearMedicineRejectedForm.html',
    providers: [MessageService]
})
export class NuclearMedicineRejectedForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridNuclearMedicineMaterial: TTVisual.ITTGrid;
    IsInjection: TTVisual.ITTCheckBoxColumn;
    labelProcessTime: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    MaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    Note: TTVisual.ITTTextBoxColumn;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PATIENTWEIGHT: TTVisual.ITTTextBox;
    PatientPhone: TTVisual.ITTTextBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    RadPharmMatTab: TTVisual.ITTTabPage;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    REPEATATIONREASON: TTVisual.ITTTextBox;
    REQUESTDOCTOR: TTVisual.ITTTextBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    TABNuclearMedicine: TTVisual.ITTTabControl;
    TabPageMaterial: TTVisual.ITTTabPage;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepickercolumn1: TTVisual.ITTDateTimePickerColumn;
    ttgrid2: TTVisual.ITTGrid;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlistboxcolumn1: TTVisual.ITTListBoxColumn;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextboxcolumn1: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn2: TTVisual.ITTTextBoxColumn;
    Unit: TTVisual.ITTListBoxColumn;
    public GridEpisodeDiagnosisColumns = [];
    public GridNuclearMedicineMaterialColumns = [];
    public ttgrid2Columns = [];
    public nuclearMedicineRejectedFormViewModel: NuclearMedicineRejectedFormViewModel = new NuclearMedicineRejectedFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineRejectedForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineRejectedForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineRejectedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PreScript(): Promise<void> {
        super.PreScript();
        //if (this._NuclearMedicine.NuclearMedicineTests.length > 0) {
        //    if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject !== null) {
        //        this.nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
        //    }
        //}
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineRejectedFormViewModel = new NuclearMedicineRejectedFormViewModel();
        this._ViewModel = this.nuclearMedicineRejectedFormViewModel;
        this.nuclearMedicineRejectedFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineRejectedFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
        this.nuclearMedicineRejectedFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineRejectedFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nuclearMedicineRejectedFormViewModel._NuclearMedicine.NucMedTreatmentMats = new Array<NucMedTreatmentMat>();
        this.nuclearMedicineRejectedFormViewModel._NuclearMedicine.RadPharmMaterials = new Array<NucMedRadPharmMatGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineRejectedFormViewModel = this._ViewModel as NuclearMedicineRejectedFormViewModel;
        that._TTObject = this.nuclearMedicineRejectedFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineRejectedFormViewModel == null)
            this.nuclearMedicineRejectedFormViewModel = new NuclearMedicineRejectedFormViewModel();
        if (this.nuclearMedicineRejectedFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineRejectedFormViewModel._NuclearMedicine = new NuclearMedicine();
        let requestDoctorObjectID = that.nuclearMedicineRejectedFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineRejectedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineRejectedFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.nuclearMedicineRejectedFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineRejectedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineRejectedFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineRejectedFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineRejectedFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineRejectedFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineRejectedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        that.nuclearMedicineRejectedFormViewModel._NuclearMedicine.NucMedTreatmentMats = that.nuclearMedicineRejectedFormViewModel.GridNuclearMedicineMaterialGridList;
        for (let detailItem of that.nuclearMedicineRejectedFormViewModel.GridNuclearMedicineMaterialGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineRejectedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }
        that.nuclearMedicineRejectedFormViewModel._NuclearMedicine.RadPharmMaterials = that.nuclearMedicineRejectedFormViewModel.ttgrid2GridList;
        for (let detailItem of that.nuclearMedicineRejectedFormViewModel.ttgrid2GridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineRejectedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.nuclearMedicineRejectedFormViewModel.RadioPharmaceuticalUnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    detailItem.Unit = unit;
                }
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineRejectedFormViewModel);
  
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ActionDate != event) {
                this._NuclearMedicine.ActionDate = event;
            }
        }
    }

    public onPATIENTWEIGHTChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientWeight != event) {
                this._NuclearMedicine.PatientWeight = event;
            }
        }
    }

    public onPatientPhoneChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientPhoneNumber != event) {
                this._NuclearMedicine.PatientPhoneNumber = event;
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

    public onREPEATATIONREASONChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RepeatationReason != event) {
                this._NuclearMedicine.RepeatationReason = event;
            }
        }
    }

    public onREQUESTDOCTORChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RequestDoctor != event) {
                this._NuclearMedicine.RequestDoctor = event;
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

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PharmaceuticalPrepDate != event) {
                this._NuclearMedicine.PharmaceuticalPrepDate = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProtocolNo != event) {
                this._NuclearMedicine.ProtocolNo = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.TestSequenceNo != event) {
                this._NuclearMedicine.TestSequenceNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.PatientPhone, "Text", this.__ttObject, "PatientPhoneNumber");
        redirectProperty(this.PATIENTWEIGHT, "Text", this.__ttObject, "PatientWeight");
        redirectProperty(this.REQUESTDOCTOR, "Text", this.__ttObject, "RequestDoctor");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TestSequenceNo");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.REPEATATIONREASON, "Text", this.__ttObject, "RepeatationReason");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "PharmaceuticalPrepDate");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#DCDCDC";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 46;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Test Sıra No";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 15;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker1.Enabled = false;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 1;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 16;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "Farmasötik Hazırlama Tarihi";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 2;

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 1;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tetkik";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 63;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.tttabpage1.Name = "tttabpage1";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 42;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = "Tekrar Sebebi";
        this.tttabpage2.Name = "tttabpage2";

        this.REPEATATIONREASON = new TTVisual.TTTextBox();
        this.REPEATATIONREASON.Multiline = true;
        this.REPEATATIONREASON.BackColor = "#F0F0F0";
        this.REPEATATIONREASON.ReadOnly = true;
        this.REPEATATIONREASON.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.REPEATATIONREASON.Name = "REPEATATIONREASON";
        this.REPEATATIONREASON.TabIndex = 43;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 62;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 61;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 9;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Protokol No";
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 8;

        this.REQUESTDOCTOR = new TTVisual.TTTextBox();
        this.REQUESTDOCTOR.BackColor = "#F0F0F0";
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 58;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 57;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmişe Ekle";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisDefinitionList";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 250;

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
        this.EpisodeIsMainDiagnose.Width = 75;

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
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 56;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 55;

        this.PatientPhone = new TTVisual.TTTextBox();
        this.PatientPhone.BackColor = "#F0F0F0";
        this.PatientPhone.ReadOnly = true;
        this.PatientPhone.Name = "PatientPhone";
        this.PatientPhone.TabIndex = 54;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Hastanın Telefonu";
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 53;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Hastanın Kilosu";
        this.ttlabel5.BackColor = "#DCDCDC";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 52;

        this.PATIENTWEIGHT = new TTVisual.TTTextBox();
        this.PATIENTWEIGHT.BackColor = "#F0F0F0";
        this.PATIENTWEIGHT.ReadOnly = true;
        this.PATIENTWEIGHT.Name = "PATIENTWEIGHT";
        this.PATIENTWEIGHT.TabIndex = 51;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Kabul Sebebi";
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 49;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Hasta Grubu";
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 48;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "İşlem Zamanı";
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 40;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 39;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İstek Yapan Tabip";
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 45;

        this.TABNuclearMedicine = new TTVisual.TTTabControl();
        this.TABNuclearMedicine.Name = "TABNuclearMedicine";
        this.TABNuclearMedicine.TabIndex = 0;

        this.TabPageMaterial = new TTVisual.TTTabPage();
        this.TabPageMaterial.DisplayIndex = 0;
        this.TabPageMaterial.BackColor = "#FFFFFF";
        this.TabPageMaterial.TabIndex = 1;
        this.TabPageMaterial.Text = "Nükleer Tıp Sarf";
        this.TabPageMaterial.Name = "TabPageMaterial";

        this.GridNuclearMedicineMaterial = new TTVisual.TTGrid();
        this.GridNuclearMedicineMaterial.Name = "GridNuclearMedicineMaterial";
        this.GridNuclearMedicineMaterial.TabIndex = 1;

        this.MaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.MaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.MaterialActionDate.DataMember = "ActionDate";
        this.MaterialActionDate.DisplayIndex = 0;
        this.MaterialActionDate.HeaderText = "Tarih/Saat";
        this.MaterialActionDate.Name = "MaterialActionDate";
        this.MaterialActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = "Sarf Edilen Malzemeler";
        this.Material.Name = "Material";
        this.Material.Width = 320;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = "Miktar";
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = "Note";
        this.Note.DisplayIndex = 3;
        this.Note.HeaderText = "Notlar";
        this.Note.Name = "Note";
        this.Note.Width = 220;

        this.RadPharmMatTab = new TTVisual.TTTabPage();
        this.RadPharmMatTab.DisplayIndex = 1;
        this.RadPharmMatTab.TabIndex = 2;
        this.RadPharmMatTab.Text = "Radyofarmasötik Madde Sarf";
        this.RadPharmMatTab.Name = "RadPharmMatTab";

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.RowHeadersVisible = false;
        this.ttgrid2.Name = "ttgrid2";
        this.ttgrid2.TabIndex = 1;

        this.ttdatetimepickercolumn1 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn1.DataMember = "ActionDate";
        this.ttdatetimepickercolumn1.DisplayIndex = 0;
        this.ttdatetimepickercolumn1.HeaderText = "Tarih/Saat";
        this.ttdatetimepickercolumn1.Name = "ttdatetimepickercolumn1";
        this.ttdatetimepickercolumn1.ReadOnly = true;
        this.ttdatetimepickercolumn1.Width = 140;

        this.ttlistboxcolumn1 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn1.ListDefName = "TreatmentMaterialListDefinition";
        this.ttlistboxcolumn1.DataMember = "Material";
        this.ttlistboxcolumn1.DisplayIndex = 1;
        this.ttlistboxcolumn1.HeaderText = "Sarf Edilen Malzemeler";
        this.ttlistboxcolumn1.Name = "ttlistboxcolumn1";
        this.ttlistboxcolumn1.ReadOnly = true;
        this.ttlistboxcolumn1.Width = 320;

        this.IsInjection = new TTVisual.TTCheckBoxColumn();
        this.IsInjection.DataMember = "IsInjection";
        this.IsInjection.DisplayIndex = 2;
        this.IsInjection.HeaderText = "Enjeksiyon";
        this.IsInjection.Name = "IsInjection";
        this.IsInjection.ReadOnly = true;
        this.IsInjection.Width = 60;

        this.tttextboxcolumn1 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn1.DataMember = "Note";
        this.tttextboxcolumn1.DisplayIndex = 3;
        this.tttextboxcolumn1.HeaderText = "Erişkin Dozu";
        this.tttextboxcolumn1.Name = "tttextboxcolumn1";
        this.tttextboxcolumn1.ReadOnly = true;
        this.tttextboxcolumn1.Width = 100;

        this.tttextboxcolumn2 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn2.DataMember = "Amount";
        this.tttextboxcolumn2.DisplayIndex = 4;
        this.tttextboxcolumn2.HeaderText = "Verilen Doz";
        this.tttextboxcolumn2.Name = "tttextboxcolumn2";
        this.tttextboxcolumn2.ReadOnly = true;
        this.tttextboxcolumn2.Width = 140;

        this.Unit = new TTVisual.TTListBoxColumn();
        this.Unit.ListDefName = "RadioPharmaceuticalUnitListDefinition";
        this.Unit.DataMember = "Unit";
        this.Unit.DisplayIndex = 5;
        this.Unit.HeaderText = "Birim";
        this.Unit.Name = "Unit";
        this.Unit.ReadOnly = true;
        this.Unit.Width = 80;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridNuclearMedicineMaterialColumns = [this.MaterialActionDate, this.Material, this.Amount, this.Note];
        this.ttgrid2Columns = [this.ttdatetimepickercolumn1, this.ttlistboxcolumn1, this.IsInjection, this.tttextboxcolumn1, this.tttextboxcolumn2, this.Unit];
        this.ttgroupbox1.Controls = [this.ttlabel8, this.ttdatetimepicker1, this.tttextbox3, this.ttlabel9, this.nucMedSelectedTesttxt, this.ttlabel1, this.tttabcontrol1, this.ReasonForAdmission, this.PATIENTGROUPENUM, this.tttextbox1, this.ttlabel15, this.REQUESTDOCTOR, this.GridEpisodeDiagnosis, this.ttlabel7, this.REQUESTDOCTORPHONE, this.PatientPhone, this.ttlabel6, this.ttlabel5, this.PATIENTWEIGHT, this.ttlabel4, this.ttlabel3, this.labelProcessTime, this.ActionDate, this.ttlabel2];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2];
        this.tttabpage1.Controls = [this.PREDIAGNOSIS];
        this.tttabpage2.Controls = [this.REPEATATIONREASON];
        this.TABNuclearMedicine.Controls = [this.TabPageMaterial, this.RadPharmMatTab];
        this.TabPageMaterial.Controls = [this.GridNuclearMedicineMaterial];
        this.RadPharmMatTab.Controls = [this.ttgrid2];
        this.Controls = [this.ttgroupbox1, this.ttlabel8, this.ttdatetimepicker1, this.tttextbox3, this.ttlabel9, this.nucMedSelectedTesttxt, this.ttlabel1, this.tttabcontrol1, this.tttabpage1, this.PREDIAGNOSIS, this.tttabpage2, this.REPEATATIONREASON, this.ReasonForAdmission, this.PATIENTGROUPENUM, this.tttextbox1, this.ttlabel15, this.REQUESTDOCTOR, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttlabel7, this.REQUESTDOCTORPHONE, this.PatientPhone, this.ttlabel6, this.ttlabel5, this.PATIENTWEIGHT, this.ttlabel4, this.ttlabel3, this.labelProcessTime, this.ActionDate, this.ttlabel2, this.TABNuclearMedicine, this.TabPageMaterial, this.GridNuclearMedicineMaterial, this.MaterialActionDate, this.Material, this.Amount, this.Note, this.RadPharmMatTab, this.ttgrid2, this.ttdatetimepickercolumn1, this.ttlistboxcolumn1, this.IsInjection, this.tttextboxcolumn1, this.tttextboxcolumn2, this.Unit];

    }


}
