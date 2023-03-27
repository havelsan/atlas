//$CCEE3E5B
import { Component, OnInit, NgZone } from '@angular/core';
import { EmergencyTriageFormViewModel } from './EmergencyTriageFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EmergencyIntervention } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTRIAJKODU } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { PatientExamination } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTWebServiceUri } from 'NebulaClient/Utils/TTWebServiceUri';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { PatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';



@Component({
    selector: 'EmergencyTriageForm',
    templateUrl: './EmergencyTriageForm.html',
    providers: [MessageService]
})
export class EmergencyTriageForm extends EpisodeActionForm implements OnInit {
    AllergyVaccination: TTVisual.ITTTabPage;
    Aşı: TTVisual.ITTTextBoxColumn;
    TriageCodeList: TTVisual.ITTObjectListBox;
    cbxTetanoz: TTVisual.ITTCheckBox;
    cbxGebe: TTVisual.ITTCheckBox;
    Complaint: TTVisual.ITTObjectListBox;
    ComplaintDescription: TTVisual.ITTRichTextBoxControl;
    ComplaintDuration: TTVisual.ITTTextBox;
    ComplaintDurationType: TTVisual.ITTEnumComboBox;
    ContinuousDrugs: TTVisual.ITTRichTextBoxControl;
    DiagnosisTab: TTVisual.ITTTabControl;
    Geçerliliği: TTVisual.ITTTextBoxColumn;
    Habits: TTVisual.ITTRichTextBoxControl;
    InterventionEndTime: TTVisual.ITTDateTimePicker;
    InterventionStartTime: TTVisual.ITTDateTimePicker;
    labelAllergyInformation: TTVisual.ITTLabel;
    labelInterventionEndTime: TTVisual.ITTLabel;
    labelInterventionStartTime: TTVisual.ITTLabel;
    labelLastMenstrualPeriod: TTVisual.ITTLabel;
    LastEatingInfo: TTVisual.ITTTextBox;
    LastMenstrualPeriod: TTVisual.ITTDateTimePicker;
    lblAliskanliklar: TTVisual.ITTLabel;
    lblKullandigiIlaclar: TTVisual.ITTLabel;
    Name: TTVisual.ITTTextBoxColumn;
    PatientHistory: TTVisual.ITTObjectListBox;
    PatientHistoryDescription: TTVisual.ITTRichTextBoxControl;
    Reaction: TTVisual.ITTTextBoxColumn;
    Risk: TTVisual.ITTEnumComboBoxColumn;
    Risk2: TTVisual.ITTEnumComboBoxColumn;
    ttgrid1: TTVisual.ITTGrid;
    ttgrid2: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTTabPage;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;

    BloodPressure_Diastolik: TTVisual.ITTTextBox;
    BloodPressure_Sistolik: TTVisual.ITTTextBox;
    Pulse_Value: TTVisual.ITTTextBox;
    Respiration_Value: TTVisual.ITTTextBox;
    Temperature_Value: TTVisual.ITTTextBox;
    txtAlcoholPromile: TTVisual.ITTTextBox;
    SPO2_Value: TTVisual.ITTTextBox;
    public ttgrid1Columns = [];
    public ttgrid2Columns = [];


    public emergencyTriageFormViewModel: EmergencyTriageFormViewModel = new EmergencyTriageFormViewModel();
    public get _EmergencyIntervention(): EmergencyIntervention {
        return this._TTObject as EmergencyIntervention;
    }
    private EmergencyTriageForm_DocumentUrl: string = '/api/EmergencyInterventionService/EmergencyTriageForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.EmergencyTriageForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public isFemale: boolean = true;
    // ***** Method declarations start *****
    public PatientDemographicInfoLoaded(PatientDemographic: any): boolean {

        if (PatientDemographic != null && PatientDemographic.gender != null)
            this.isFemale = PatientDemographic.gender == "KADIN";

        return this.isFemale;
    }

    private async ResponsibleDoctor_SelectedObjectChanged(): Promise<void> {

    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        if (transDef !== null && transDef.ToStateDefID === EmergencyIntervention.EmergencyInterventionStates.Observation) {
            for (let patientExamination of this._EmergencyIntervention.PatientExaminations) {
                patientExamination.CurrentStateDefID = PatientExamination.PatientExaminationStates.Examination;
            }
            this._EmergencyIntervention.ObjectContext.Save();
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        if(this._EmergencyIntervention.InterventionEndTime == null)
            this._EmergencyIntervention.InterventionEndTime=await CommonService.RecTime();
        //if (transDef !== null) {
        //    if (this._EmergencyIntervention.ResponsibleDoctor === null)
        //        throw new Exception("'Sorumlu Doktor' seçilmesi zorunludur.");
        //}
    }
    protected async PrepareFormTitle(): Promise<void> {
        /*if (this._EmergencyIntervention.MasterResource !== null)
            this.Text += " - " + this._EmergencyIntervention.MasterResource.Name.toLocaleUpperCase();
        if (this._EpisodeAction.Episode.Patient !== null)
            this.Text += " - " + this._EpisodeAction.Episode.Patient.FullName.toLocaleUpperCase();*/
    }
    protected async PreScript() {

        //this.Complaint.ListFilterExpression = "SPECIALITYDEFINITION ='" + this._EmergencyIntervention.SubEpisodeSpeciality.ObjectID.toString() + "' OR SPECIALITYDEFINITION is NULL";
        let ipAddr: string = (await SystemParameterService.GetParameterValue("ACIL112IP", null));
        let uri: TTWebServiceUri = new TTWebServiceUri(ipAddr);
        let userName112: string = (await SystemParameterService.GetParameterValue("ACIL112USERNAME", null));
        let password112: string = (await SystemParameterService.GetParameterValue("ACIL112PASSWORD", null));

        if (this._EmergencyIntervention.CurrentStateDefID === EmergencyIntervention.EmergencyInterventionStates.Completed)
            this.DropStateButton(EmergencyIntervention.EmergencyInterventionStates.Observation);
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EmergencyIntervention();
        this.emergencyTriageFormViewModel = new EmergencyTriageFormViewModel();
        this._ViewModel = this.emergencyTriageFormViewModel;
        this.emergencyTriageFormViewModel._EmergencyIntervention = this._TTObject as EmergencyIntervention;
        this.emergencyTriageFormViewModel._EmergencyIntervention.Triage = new SKRSTRIAJKODU();
        this.emergencyTriageFormViewModel.PatientAdmission = new PatientAdmission();
    }

    protected loadViewModel() {
        let that = this;

        that.emergencyTriageFormViewModel = this._ViewModel as EmergencyTriageFormViewModel;
        that._TTObject = this.emergencyTriageFormViewModel._EmergencyIntervention;
        if (this.emergencyTriageFormViewModel == null)
            this.emergencyTriageFormViewModel = new EmergencyTriageFormViewModel();
        if (this.emergencyTriageFormViewModel._EmergencyIntervention == null)
            this.emergencyTriageFormViewModel._EmergencyIntervention = new EmergencyIntervention();
        let triageObjectID = that.emergencyTriageFormViewModel._EmergencyIntervention["Triage"];
        if (triageObjectID != null && (typeof triageObjectID === 'string')) {
            let triage = that.emergencyTriageFormViewModel.SKRSTRIAJKODUs.find(o => o.ObjectID.toString() === triageObjectID.toString());
             if (triage) {
                that.emergencyTriageFormViewModel._EmergencyIntervention.Triage = triage;
            }
        }
    }




    public btnEmergencyInterventionSave_Click() {
        try {
            this.save();
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            //   TTVisual.InfoBox.Alert("Hata");
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(EmergencyTriageFormViewModel);
  
    }


    public oncbxGebeChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.IsPregnant != event) {
                this._EmergencyIntervention.IsPregnant = event;
            }
        }
    }

    public oncbxTetanozChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null &&
                this._EmergencyIntervention.TetanusVaccine != event) {
                this._EmergencyIntervention.TetanusVaccine = event;
            }
        }
    }


    public onComplaintChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.Complaint != event) {
                this._EmergencyIntervention.Complaint = event;
            }
        }
    }

    public onComplaintDescriptionChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.ComplaintDescription != event) {
                this._EmergencyIntervention.ComplaintDescription = event;
            }
        }
    }

    public onComplaintDurationChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.ComplaintDuration != event) {
                this._EmergencyIntervention.ComplaintDuration = event.value;
            }
        }
    }

    public onContinuousDrugsChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.ContinuousDrugs != event) {
                this._EmergencyIntervention.ContinuousDrugs = event;
            }
        }
    }

    public onHabitsChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.Habits != event) {
                this._EmergencyIntervention.Habits = event;
            }
        }
    }
public onInterventionEndTimeChanged(event): void {
    if(this._EmergencyIntervention != null && this._EmergencyIntervention.InterventionEndTime != event) { 
    this._EmergencyIntervention.InterventionEndTime = event;
}
}

public onInterventionStartTimeChanged(event): void {
    if(this._EmergencyIntervention != null && this._EmergencyIntervention.InterventionStartTime != event) { 
    this._EmergencyIntervention.InterventionStartTime = event;
}
}
    public onLastEatingInfoChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.LastEatingInfo != event) {
                this._EmergencyIntervention.LastEatingInfo = event;
            }
        }
    }

    public onLastMenstrualPeriodChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.LastMenstrualPeriod != event) {
                this._EmergencyIntervention.LastMenstrualPeriod = event;
            }
        }
    }

    public onPatientHistoryChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.PatientHistory != event) {
                this._EmergencyIntervention.PatientHistory = event;
            }
        }
    }

    public onPatientHistoryDescriptionChanged(event): void {
        if (event != null) {
            if (this._EmergencyIntervention != null && this._EmergencyIntervention.PatientHistoryDescription != event) {
                this._EmergencyIntervention.PatientHistoryDescription = event;
            }
        }
    }

    public onBloodPressure_SistolikChanged(event): void {
        if (event != null) {
            if (this.emergencyTriageFormViewModel.BloodPressure_Sistolik != event) {
                this.emergencyTriageFormViewModel.BloodPressure_Sistolik = event.value;
            }
        }
    }

    public onBloodPressure_DiastolikChanged(event): void {
        if (event != null) {
            if (this.emergencyTriageFormViewModel.BloodPressure_Diastolik != event) {
                this.emergencyTriageFormViewModel.BloodPressure_Diastolik = event.value;
            }
        }
    }

    public onPulse_ValueChanged(event): void {
        if (event != null) {
            if (this.emergencyTriageFormViewModel.Pulse_Value != event) {
                this.emergencyTriageFormViewModel.Pulse_Value = event;
            }
        }
    }

    public onRespiration_ValueChanged(event): void {
        if (event != null) {
            if (this.emergencyTriageFormViewModel.Respiration_Value != event) {
                this.emergencyTriageFormViewModel.Respiration_Value = event;
            }
        }
    }

    public onTemperature_ValueChanged(event): void {
        if (event != null) {
            if (this.emergencyTriageFormViewModel.Temperature_Value != event) {
                this.emergencyTriageFormViewModel.Temperature_Value = event;
            }
        }
    }
    public onAlcoholPromileChanged(event): void {
        // if (event != null) {
            if (this.emergencyTriageFormViewModel._EmergencyIntervention.AlcoholPromile != event) {
                this.emergencyTriageFormViewModel._EmergencyIntervention.AlcoholPromile = event;
            }
        // }
    }
    public onSPO2_ValueChanged(event): void {
        if (event != null) {
            if (this.emergencyTriageFormViewModel.SPO2_Value != event) {
                this.emergencyTriageFormViewModel.SPO2_Value = event;
            }
        }
    }

    public async onTriageCodeListChanged(event) {

        if (this._EmergencyIntervention.Triage != event) {
            this._EmergencyIntervention.Triage = event;

            if (event == null)
                event = new SKRSTRIAJKODU();
        }

        await this.SetTriageColor(event);
    }

    public async SetTriageColor(event) {
        if (event != null) {
            if (event.KODU == "1") {
                this.TriageCodeList.BackColor = "#84e684";
                this.TriageCodeList.ForeColor = "#000000";
            }
            else if (event.KODU == "2") {
                this.TriageCodeList.BackColor = "#f1f10b";
                this.TriageCodeList.ForeColor = "#000000";
            }
            else if (event.KODU == "3") {
                this.TriageCodeList.BackColor = "#ff5d5d";
                this.TriageCodeList.ForeColor = "#000000";
            }
            else if (event.KODU == "4") {
                this.TriageCodeList.BackColor = "#423939";
                this.TriageCodeList.ForeColor = "#ffffff";
            }
            else {
                this.TriageCodeList.BackColor = "#ffffff";
                this.TriageCodeList.ForeColor = "#000000";
            }
        }
        else {
            this.TriageCodeList.BackColor = "#ffffff";
            this.TriageCodeList.ForeColor = "#000000";
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.ComplaintDuration, "Text", this.__ttObject, "ComplaintDuration");
        redirectProperty(this.ComplaintDescription, "Rtf", this.__ttObject, "ComplaintDescription");
        redirectProperty(this.PatientHistoryDescription, "Rtf", this.__ttObject, "PatientHistoryDescription");
        redirectProperty(this.ContinuousDrugs, "Rtf", this.__ttObject, "ContinuousDrugs");
        redirectProperty(this.Habits, "Rtf", this.__ttObject, "Habits");
        redirectProperty(this.LastEatingInfo, "Text", this.__ttObject, "LastEatingInfo");
    	redirectProperty(this.InterventionStartTime, "Value", this.__ttObject, "InterventionStartTime");
    	redirectProperty(this.InterventionEndTime, "Value", this.__ttObject, "InterventionEndTime");
        redirectProperty(this.cbxGebe, "Value", this.__ttObject, "IsPregnant");
        redirectProperty(this.cbxTetanoz, "Value", this.__ttObject, "TetanusVaccine.");
        redirectProperty(this.LastMenstrualPeriod, "Value", this.__ttObject, "LastMenstrualPeriod");
        redirectProperty(this.TriageCodeList, "SelectedObject", this.__ttObject, "Triage");
    }

    public initFormControls(): void {
    this.labelInterventionEndTime = new TTVisual.TTLabel();
    this.labelInterventionEndTime.Text = "Triaj Bitiş Zamanı";
    this.labelInterventionEndTime.Name = "labelInterventionEndTime";
    this.labelInterventionEndTime.TabIndex = 218;

    this.InterventionEndTime = new TTVisual.TTDateTimePicker();
    this.InterventionEndTime.Format = DateTimePickerFormat.Long;
    this.InterventionEndTime.Name = "InterventionEndTime";
    this.InterventionEndTime.TabIndex = 217;

    this.labelInterventionStartTime = new TTVisual.TTLabel();
    this.labelInterventionStartTime.Text = "Triaj Başalama Zamanı";
    this.labelInterventionStartTime.Name = "labelInterventionStartTime";
    this.labelInterventionStartTime.TabIndex = 216;

    this.InterventionStartTime = new TTVisual.TTDateTimePicker();
    this.InterventionStartTime.Format = DateTimePickerFormat.Long;
    this.InterventionStartTime.Name = "InterventionStartTime";
    this.InterventionStartTime.TabIndex = 215;
        this.cbxGebe = new TTVisual.TTCheckBox();
        this.cbxGebe.Value = false;
        this.cbxGebe.Text = i18n("M14557", "Gebelik Durumu");
        this.cbxGebe.Name = "cbxGebe";
        this.cbxGebe.TabIndex = 206;

        this.cbxTetanoz = new TTVisual.TTCheckBox();
        this.cbxTetanoz.Value = false;
        this.cbxTetanoz.Text = i18n("M23293", "Tetanoz Aşısı");
        this.cbxTetanoz.Name = "cbxTetanoz";
        this.cbxTetanoz.TabIndex = 207;

        this.Habits = new TTVisual.TTRichTextBoxControl();
        this.Habits.Name = "Habits";
        this.Habits.TabIndex = 205;

        this.lblAliskanliklar = new TTVisual.TTLabel();
        this.lblAliskanliklar.Text = i18n("M10722", "Alışkanlıklar");
        this.lblAliskanliklar.Name = "lblAliskanliklar";
        this.lblAliskanliklar.TabIndex = 204;

        this.ContinuousDrugs = new TTVisual.TTRichTextBoxControl();
        this.ContinuousDrugs.Name = "ContinuousDrugs";
        this.ContinuousDrugs.TabIndex = 203;

        this.lblKullandigiIlaclar = new TTVisual.TTLabel();
        this.lblKullandigiIlaclar.Text = i18n("M17890", "Kullandığı İlaçlar");
        this.lblKullandigiIlaclar.Name = "lblKullandigiIlaclar";
        this.lblKullandigiIlaclar.TabIndex = 202;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M22070", "Son Yemek Bilgisi");
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 201;

        this.LastEatingInfo = new TTVisual.TTTextBox();
        this.LastEatingInfo.Multiline = true;
        this.LastEatingInfo.Name = "LastEatingInfo";
        this.LastEatingInfo.TabIndex = 200;

        this.DiagnosisTab = new TTVisual.TTTabControl();
        this.DiagnosisTab.Name = "DiagnosisTab";
        this.DiagnosisTab.TabIndex = 0;

        this.ttlabel3 = new TTVisual.TTTabPage();
        this.ttlabel3.DisplayIndex = 0;
        this.ttlabel3.BackColor = "#FFFFFF";
        this.ttlabel3.TabIndex = 2;
        this.ttlabel3.Text = i18n("M15275", "Hasta Muayene Bilgileri ");
        this.ttlabel3.Name = "ttlabel3";

        this.ComplaintDurationType = new TTVisual.TTEnumComboBox();
        this.ComplaintDurationType.DataTypeName = "UnitOfTimeEnum";
        this.ComplaintDurationType.Name = "ComplaintDurationType";
        this.ComplaintDurationType.TabIndex = 31;

        this.ComplaintDuration = new TTVisual.TTTextBox();
        this.ComplaintDuration.Name = "ComplaintDuration";
        this.ComplaintDuration.TabIndex = 30;

        this.Complaint = new TTVisual.TTObjectListBox();
        this.Complaint.ListDefName = "ComplaintListDefinition";
        this.Complaint.Name = "Complaint";
        this.Complaint.TabIndex = 3;

        this.TriageCodeList = new TTVisual.TTObjectListBox();
        this.TriageCodeList.ListDefName = "SKRSTRIAJKODUList";
        this.TriageCodeList.Name = "TriageCodeList";
        this.TriageCodeList.TabIndex = 166;

        this.ComplaintDescription = new TTVisual.TTRichTextBoxControl();
        this.ComplaintDescription.DisplayText = i18n("M22483", "Şikayet");
        this.ComplaintDescription.TemplateGroupName = "EMERGENCYCOMPLAINT";
        this.ComplaintDescription.BackColor = "#FFFFFF";
        this.ComplaintDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ComplaintDescription.Name = "ComplaintDescription";
        this.ComplaintDescription.TabIndex = 2;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M22483", "Şikayet");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 29;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M22490", "Şikayet Süresi");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 29;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M20117", "Özgeçmiş");
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 29;

        this.PatientHistory = new TTVisual.TTObjectListBox();
        this.PatientHistory.ListDefName = "PatientHistoryListDefinition";
        this.PatientHistory.Name = "PatientHistory";
        this.PatientHistory.TabIndex = 3;

        this.PatientHistoryDescription = new TTVisual.TTRichTextBoxControl();
        this.PatientHistoryDescription.DisplayText = i18n("M20117", "Özgeçmiş");
        this.PatientHistoryDescription.TemplateGroupName = "EMERGENCYCOMPLAINT";
        this.PatientHistoryDescription.BackColor = "#FFFFFF";
        this.PatientHistoryDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientHistoryDescription.Name = "PatientHistoryDescription";
        this.PatientHistoryDescription.TabIndex = 2;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M23584", "Triaj Kodu");
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 29;

        this.LastMenstrualPeriod = new TTVisual.TTDateTimePicker();
        this.LastMenstrualPeriod.Format = DateTimePickerFormat.Long;
        this.LastMenstrualPeriod.Name = "LastMenstrualPeriod";
        this.LastMenstrualPeriod.TabIndex = 42;

        this.labelLastMenstrualPeriod = new TTVisual.TTLabel();
        this.labelLastMenstrualPeriod.Text = i18n("M22037", "Son Adet Tarihi");
        this.labelLastMenstrualPeriod.Name = "labelLastMenstrualPeriod";
        this.labelLastMenstrualPeriod.TabIndex = 43;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 3;

        this.AllergyVaccination = new TTVisual.TTTabPage();
        this.AllergyVaccination.DisplayIndex = 0;
        this.AllergyVaccination.BackColor = "#FFFFFF";
        this.AllergyVaccination.TabIndex = 0;
        this.AllergyVaccination.Text = i18n("M10687", "Alerji-Aşı Bilgileri Detayı");
        this.AllergyVaccination.Name = "AllergyVaccination";

        this.ttgrid1 = new TTVisual.TTGrid();
        this.ttgrid1.Name = "ttgrid1";
        this.ttgrid1.TabIndex = 15;

        this.Name = new TTVisual.TTTextBoxColumn();
        this.Name.DataMember = "Name";
        this.Name.DisplayIndex = 0;
        this.Name.HeaderText = i18n("M10683", "Alerji");
        this.Name.Name = "Name";
        this.Name.Width = 150;

        this.Reaction = new TTVisual.TTTextBoxColumn();
        this.Reaction.DataMember = "Reaction";
        this.Reaction.DisplayIndex = 1;
        this.Reaction.HeaderText = i18n("M20923", "Reaksiyon");
        this.Reaction.Name = "Reaction";
        this.Reaction.Width = 150;

        this.Risk2 = new TTVisual.TTEnumComboBoxColumn();
        this.Risk2.DataTypeName = "RiskEnum";
        this.Risk2.DataMember = "Risk";
        this.Risk2.DisplayIndex = 2;
        this.Risk2.HeaderText = "Risk";
        this.Risk2.Name = "Risk2";
        this.Risk2.Width = 90;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M11198", "Aşı Bilgileri");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 20;

        this.labelAllergyInformation = new TTVisual.TTLabel();
        this.labelAllergyInformation.Text = i18n("M10685", "Alerji Bilgileri");
        this.labelAllergyInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelAllergyInformation.ForeColor = "#000000";
        this.labelAllergyInformation.Name = "labelAllergyInformation";
        this.labelAllergyInformation.TabIndex = 1;

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.Name = "ttgrid2";
        this.ttgrid2.TabIndex = 19;

        this.Aşı = new TTVisual.TTTextBoxColumn();
        this.Aşı.DataMember = "Name";
        this.Aşı.DisplayIndex = 0;
        this.Aşı.HeaderText = "Aşı";
        this.Aşı.Name = "Aşı";
        this.Aşı.Width = 100;

        this.Geçerliliği = new TTVisual.TTTextBoxColumn();
        this.Geçerliliği.DataMember = "Effectiveness";
        this.Geçerliliği.DisplayIndex = 1;
        this.Geçerliliği.HeaderText = "Geçerliliği";
        this.Geçerliliği.Name = "Geçerliliği";
        this.Geçerliliği.Width = 185;

        this.Risk = new TTVisual.TTEnumComboBoxColumn();
        this.Risk.DataTypeName = "RiskEnum";
        this.Risk.DataMember = "Risk";
        this.Risk.DisplayIndex = 2;
        this.Risk.HeaderText = "Risk";
        this.Risk.Name = "Risk";
        this.Risk.Width = 100;

        this.ttgrid1Columns = [this.Name, this.Reaction, this.Risk2];
        this.ttgrid2Columns = [this.Aşı, this.Geçerliliği, this.Risk];
        this.DiagnosisTab.Controls = [this.ttlabel3];
        this.ttlabel3.Controls = [this.ComplaintDurationType, this.ComplaintDuration, this.Complaint, this.ComplaintDescription, this.ttlabel2, this.ttlabel4, this.ttlabel7, this.PatientHistory, this.PatientHistoryDescription];
        this.tttabcontrol1.Controls = [this.AllergyVaccination];
        this.AllergyVaccination.Controls = [this.ttgrid1, this.ttlabel1, this.labelAllergyInformation, this.ttgrid2];
        this.Controls = [this.labelInterventionEndTime, this.InterventionEndTime, this.labelInterventionStartTime, this.InterventionStartTime,this.cbxGebe, this.cbxTetanoz, this.Habits, this.lblAliskanliklar, this.ContinuousDrugs, this.lblKullandigiIlaclar, this.ttlabel8, this.LastEatingInfo, this.DiagnosisTab, this.ttlabel3, this.ComplaintDurationType, this.ComplaintDuration, this.Complaint, this.ComplaintDescription, this.ttlabel2, this.ttlabel4, this.ttlabel7, this.PatientHistory, this.PatientHistoryDescription, this.ttlabel6, this.LastMenstrualPeriod, this.labelLastMenstrualPeriod, this.tttabcontrol1, this.AllergyVaccination, this.ttgrid1, this.Name, this.Reaction, this.Risk2, this.ttlabel1, this.labelAllergyInformation, this.ttgrid2, this.Aşı, this.Geçerliliği, this.Risk];

    }


}
