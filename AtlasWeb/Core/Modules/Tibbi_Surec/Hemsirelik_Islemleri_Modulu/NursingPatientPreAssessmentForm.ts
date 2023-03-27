//$24FAEEF9
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingPatientPreAssessmentFormViewModel } from './NursingPatientPreAssessmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingPatientPreAssessment, SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";
import { SystemParameterService } from 'NebulaClient/Services/ObjectService/SystemParameterService';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
@Component({
    selector: 'NursingPatientPreAssessmentForm',
    templateUrl: './NursingPatientPreAssessmentForm.html',
    providers: [MessageService]
})
export class NursingPatientPreAssessmentForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    AssistiveDevices: TTVisual.ITTTextBox;
    BloodTransfusionPracticed: TTVisual.ITTEnumComboBox;
    BloodTransfusionReaction: TTVisual.ITTTextBox;
    CauseOfInjury: TTVisual.ITTEnumComboBox;
    ChildCount: TTVisual.ITTTextBox;
    Height: TTVisual.ITTTextBox;
    HereditaryDiseases: TTVisual.ITTTextBox;
    labelApplicationDate: TTVisual.ITTLabel;
    labelAssistiveDevices: TTVisual.ITTLabel;
    labelBloodTransfusionPracticed: TTVisual.ITTLabel;
    labelBloodTransfusionReaction: TTVisual.ITTLabel;
    labelCauseOfInjury: TTVisual.ITTLabel;
    labelChildCount: TTVisual.ITTLabel;
    labelHeight: TTVisual.ITTLabel;
    labelHereditaryDiseases: TTVisual.ITTLabel;
    labelLastRehabDate: TTVisual.ITTLabel;
    labelPastIllnessesAndOperations: TTVisual.ITTLabel;
    labelPatientLanguage: TTVisual.ITTLabel;
    labelRehabHistory: TTVisual.ITTLabel;
    labelTheWayThePatientArrive: TTVisual.ITTLabel;
    labelWeight: TTVisual.ITTLabel;
    labelWhereThePatientCameFrom: TTVisual.ITTLabel;
    LastRehabDate: TTVisual.ITTDateTimePicker;
    PastIllnessesAndOperations: TTVisual.ITTTextBox;
    PatientLanguage: TTVisual.ITTTextBox;
    RehabHistory: TTVisual.ITTEnumComboBox;
    TheWayThePatientArrive: TTVisual.ITTEnumComboBox;
    Weight: TTVisual.ITTTextBox;
    WhereThePatientCameFrom: TTVisual.ITTTextBox;
    BloodGroup: TTVisual.ITTObjectListBox;


    InfantNutritionalStatus: TTVisual.ITTObjectListBox;
    printButtonVisible: boolean = false;
    enableBloodGroup: boolean = false;
    RelativeTC: string = "";

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public nursingPatientPreAssessmentFormViewModel: NursingPatientPreAssessmentFormViewModel = new NursingPatientPreAssessmentFormViewModel();
    public get _NursingPatientPreAssessment(): NursingPatientPreAssessment {
        return this._TTObject as NursingPatientPreAssessment;
    }
    private NursingPatientPreAssessmentForm_DocumentUrl: string = '/api/NursingPatientPreAssessmentService/NursingPatientPreAssessmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone, protected reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingPatientPreAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    Habits: boolean = false;
    // ***** Method declarations start *****


    // *****Method declarations end *****

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public initViewModel(): void {
        this._TTObject = new NursingPatientPreAssessment();
        this.nursingPatientPreAssessmentFormViewModel = new NursingPatientPreAssessmentFormViewModel();
        this._ViewModel = this.nursingPatientPreAssessmentFormViewModel;
        this.nursingPatientPreAssessmentFormViewModel._NursingPatientPreAssessment = this._TTObject as NursingPatientPreAssessment;
        this.nursingPatientPreAssessmentFormViewModel.AlcoholUsageFrequency = new SKRSAlkolKullanimi();
    }

    protected loadViewModel() {
        let that = this;
        that.nursingPatientPreAssessmentFormViewModel = this._ViewModel as NursingPatientPreAssessmentFormViewModel;
        that._TTObject = this.nursingPatientPreAssessmentFormViewModel._NursingPatientPreAssessment;
        if (this.nursingPatientPreAssessmentFormViewModel == null)
            this.nursingPatientPreAssessmentFormViewModel = new NursingPatientPreAssessmentFormViewModel();
        if (this.nursingPatientPreAssessmentFormViewModel._NursingPatientPreAssessment == null)
            this.nursingPatientPreAssessmentFormViewModel._NursingPatientPreAssessment = new NursingPatientPreAssessment();

        this.Habits = this.nursingPatientPreAssessmentFormViewModel.Cigarette || this.nursingPatientPreAssessmentFormViewModel.Drug || this.nursingPatientPreAssessmentFormViewModel.Alcohol;
        if (!this.nursingPatientPreAssessmentFormViewModel._NursingPatientPreAssessment.IsNew)
            this.printButtonVisible = true;

        if (this.nursingPatientPreAssessmentFormViewModel.BloodGroupType != null) {
            let bloodGroupObjectId = this.nursingPatientPreAssessmentFormViewModel.BloodGroupType.ObjectID.toString();
            if (bloodGroupObjectId != null && (typeof bloodGroupObjectId === 'string')) {
                let BloodGroup = that.nursingPatientPreAssessmentFormViewModel.SKRSKanGrubus.find(o => o.ObjectID.toString() === bloodGroupObjectId.toString());
                if (BloodGroup) {
                    this.nursingPatientPreAssessmentFormViewModel.BloodGroupType = BloodGroup;
                }
            }
        }
        
    }

    async ngOnInit() {
        
        this.loadPanelOperation(true, i18n("M14461", "Form hazırlanıyor, lütfen bekleyiniz."));
        await this.load();
        this.loadPanelOperation(false, '');
        let enableBloodGroupParameter: string = (await SystemParameterService.GetParameterValue('ENABLEBLOODGROUP', 'FALSE'));
        if (enableBloodGroupParameter === 'TRUE')
        {
            this.enableBloodGroup = true;
        }
        else
        {
        this.enableBloodGroup =  false;
        }
    }

    printReport() {
        const TTOBJECTID = new GuidParam(this.nursingPatientPreAssessmentFormViewModel._NursingPatientPreAssessment.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': TTOBJECTID };
        this.reportService.showReport('NursingPatientPreAssessmentForm', reportParameters);
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.ApplicationDate != event) {
                this._NursingPatientPreAssessment.ApplicationDate = event;
            }
        }
    }

    public onAssistiveDevicesChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.AssistiveDevices != event) {
                this._NursingPatientPreAssessment.AssistiveDevices = event;
            }
        }
    }
    public onBloodTransfusionPracticedChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.BloodTransfusionPracticed != event) {
                this._NursingPatientPreAssessment.BloodTransfusionPracticed = event;
            }
        }
    }

    public onBloodTransfusionReactionChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.BloodTransfusionReaction != event) {
                this._NursingPatientPreAssessment.BloodTransfusionReaction = event;
            }
        }
    }

    public onCauseOfInjuryChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.CauseOfInjury != event) {
                this._NursingPatientPreAssessment.CauseOfInjury = event;
            }
        }
    }

    public onChildCountChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.ChildCount != event) {
                this._NursingPatientPreAssessment.ChildCount = event;
            }
        }
    }

    public onHeightChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.Height != event) {
                this._NursingPatientPreAssessment.Height = event;
            }
        }
    }

    public onHereditaryDiseasesChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.HereditaryDiseases != event) {
                this._NursingPatientPreAssessment.HereditaryDiseases = event;
            }
        }
    }

    public onLastRehabDateChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.LastRehabDate != event) {
                this._NursingPatientPreAssessment.LastRehabDate = event;
            }
        }
    }

    public onPastIllnessesAndOperationsChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.PastIllnessesAndOperations != event) {
                this._NursingPatientPreAssessment.PastIllnessesAndOperations = event;
            }
        }
    }

    public onPatientLanguageChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.PatientLanguage != event) {
                this._NursingPatientPreAssessment.PatientLanguage = event;
            }
        }
    }

    public onRehabHistoryChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.RehabHistory != event) {
                this._NursingPatientPreAssessment.RehabHistory = event;
            }
        }
    }

    public onTheWayThePatientArriveChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.TheWayThePatientArrive != event) {
                this._NursingPatientPreAssessment.TheWayThePatientArrive = event;
            }
        }
    }

    public onWeightChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.Weight != event) {
                this._NursingPatientPreAssessment.Weight = event;
            }
        }
    }

    public onWhereThePatientCameFromChanged(event): void {
        if (event != null) {
            if (this._NursingPatientPreAssessment != null && this._NursingPatientPreAssessment.WhereThePatientCameFrom != event) {
                this._NursingPatientPreAssessment.WhereThePatientCameFrom = event;
            }
        }
    }

    getMernisInfo() {

        let apiUrl: string = '/api/NursingPatientPreAssessmentService/CheckMernisNumber';
        this.httpService.get<any>(apiUrl + "?TC=" + this.RelativeTC).
        then(x => {
                this.nursingPatientPreAssessmentFormViewModel.RelativeFullName = x[0];
                this.nursingPatientPreAssessmentFormViewModel.RelativeHomeAddress = x[1];
            })
            .catch(error => {
                this.messageService.showError(error);

            });

    }

    public onHasAllergyChanged(event)
    {

        if (!event.value)
        {
            this.nursingPatientPreAssessmentFormViewModel.FoodAllergies = null;
            this.nursingPatientPreAssessmentFormViewModel.DrugAllergies = null;
            this.nursingPatientPreAssessmentFormViewModel.OtherAllergies = null;

        }
    }

    public onAlcoholChanged(event)
    {
        if (!event.value)
        {
            this.nursingPatientPreAssessmentFormViewModel.AlcoholUsageFrequency = null;
        }
    }

    public onDrugChanged(event)
    {

        if (!event.value)
        {
            this.nursingPatientPreAssessmentFormViewModel.DrugUsageFrequency = null;

        }
    }

    public onCigaretteChanged(event)
    {

        if (!event.value)
        {
            this.nursingPatientPreAssessmentFormViewModel.CigaretteUsageFrequency = null;

        }
    }

    public onHasContagiousDiseaseChanged(event)
    {

        if (!event.value)
        {
            this.nursingPatientPreAssessmentFormViewModel.ContagiousDisease = null;
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.Height, "Text", this.__ttObject, "Height");
        redirectProperty(this.PatientLanguage, "Text", this.__ttObject, "PatientLanguage");
        redirectProperty(this.ChildCount, "Text", this.__ttObject, "ChildCount");
        redirectProperty(this.CauseOfInjury, "Value", this.__ttObject, "CauseOfInjury");
        redirectProperty(this.RehabHistory, "Value", this.__ttObject, "RehabHistory");
        redirectProperty(this.LastRehabDate, "Value", this.__ttObject, "LastRehabDate");
        redirectProperty(this.WhereThePatientCameFrom, "Text", this.__ttObject, "WhereThePatientCameFrom");
        redirectProperty(this.TheWayThePatientArrive, "Value", this.__ttObject, "TheWayThePatientArrive");
        redirectProperty(this.HereditaryDiseases, "Text", this.__ttObject, "HereditaryDiseases");
        redirectProperty(this.PastIllnessesAndOperations, "Text", this.__ttObject, "PastIllnessesAndOperations");
        redirectProperty(this.AssistiveDevices, "Text", this.__ttObject, "AssistiveDevices");
        redirectProperty(this.BloodTransfusionPracticed, "Value", this.__ttObject, "BloodTransfusionPracticed");
        redirectProperty(this.BloodTransfusionReaction, "Text", this.__ttObject, "BloodTransfusionReaction");
        redirectProperty(this.Weight, "Text", this.__ttObject, "Weight");
    }

    public initFormControls(): void {
        this.labelWeight = new TTVisual.TTLabel();
        this.labelWeight.Text = "Kilo";
        this.labelWeight.Name = "labelWeight";
        this.labelWeight.TabIndex = 29;

        this.Weight = new TTVisual.TTTextBox();
        this.Weight.Name = "Weight";
        this.Weight.TabIndex = 28;

        this.Height = new TTVisual.TTTextBox();
        this.Height.Name = "Height";
        this.Height.TabIndex = 26;

        this.BloodGroup = new TTVisual.TTObjectListBox();
        this.BloodGroup.ListDefName = "SKRSKanGrubuList";
        this.BloodGroup.Name = "BloodGroupType";
        this.BloodGroup.TabIndex = 22;


        this.InfantNutritionalStatus = new TTVisual.TTObjectListBox();
        this.InfantNutritionalStatus.ListDefName = "SKRSAlkolKullanimiList";
        this.InfantNutritionalStatus.Name = "InfantNutritionalStatus";
        this.InfantNutritionalStatus.TabIndex = 30;
        this.InfantNutritionalStatus.AutoCompleteDialogHeight = "50%";

        this.BloodTransfusionReaction = new TTVisual.TTTextBox();
        this.BloodTransfusionReaction.Name = "BloodTransfusionReaction";
        this.BloodTransfusionReaction.TabIndex = 22;

        this.AssistiveDevices = new TTVisual.TTTextBox();
        this.AssistiveDevices.Name = "AssistiveDevices";
        this.AssistiveDevices.TabIndex = 18;

        this.PastIllnessesAndOperations = new TTVisual.TTTextBox();
        this.PastIllnessesAndOperations.Name = "PastIllnessesAndOperations";
        this.PastIllnessesAndOperations.TabIndex = 16;

        this.HereditaryDiseases = new TTVisual.TTTextBox();
        this.HereditaryDiseases.Name = "HereditaryDiseases";
        this.HereditaryDiseases.TabIndex = 14;

        this.WhereThePatientCameFrom = new TTVisual.TTTextBox();
        this.WhereThePatientCameFrom.Name = "WhereThePatientCameFrom";
        this.WhereThePatientCameFrom.TabIndex = 10;

        this.ChildCount = new TTVisual.TTTextBox();
        this.ChildCount.Name = "ChildCount";
        this.ChildCount.TabIndex = 2;

        this.PatientLanguage = new TTVisual.TTTextBox();
        this.PatientLanguage.Name = "PatientLanguage";
        this.PatientLanguage.TabIndex = 0;

        this.labelHeight = new TTVisual.TTLabel();
        this.labelHeight.Text = "Boy";
        this.labelHeight.Name = "labelHeight";
        this.labelHeight.TabIndex = 27;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = "Uygulama Zamanı";
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 25;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 24;

        this.labelBloodTransfusionReaction = new TTVisual.TTLabel();
        this.labelBloodTransfusionReaction.Text = "Kan Transfüzyonu yapıldıysa Reaksiyon Gelişti mi?";
        this.labelBloodTransfusionReaction.Name = "labelBloodTransfusionReaction";
        this.labelBloodTransfusionReaction.TabIndex = 23;

        this.labelBloodTransfusionPracticed = new TTVisual.TTLabel();
        this.labelBloodTransfusionPracticed.Text = "Daha önce kan transfüzyonu uygulandı mı?";
        this.labelBloodTransfusionPracticed.Name = "labelBloodTransfusionPracticed";
        this.labelBloodTransfusionPracticed.TabIndex = 21;

        this.BloodTransfusionPracticed = new TTVisual.TTEnumComboBox();
        this.BloodTransfusionPracticed.DataTypeName = "YesNoEnum";
        this.BloodTransfusionPracticed.Name = "BloodTransfusionPracticed";
        this.BloodTransfusionPracticed.TabIndex = 20;

        this.labelAssistiveDevices = new TTVisual.TTLabel();
        this.labelAssistiveDevices.Text = "Sürekli Kullandığı Yardımcı Cihazlar";
        this.labelAssistiveDevices.Name = "labelAssistiveDevices";
        this.labelAssistiveDevices.TabIndex = 19;

        this.labelPastIllnessesAndOperations = new TTVisual.TTLabel();
        this.labelPastIllnessesAndOperations.Text = "Geçirilmiş Hastalıklar / Operasyonlar";
        this.labelPastIllnessesAndOperations.Name = "labelPastIllnessesAndOperations";
        this.labelPastIllnessesAndOperations.TabIndex = 17;

        this.labelHereditaryDiseases = new TTVisual.TTLabel();
        this.labelHereditaryDiseases.Text = "Ailesel Hastalıklar";
        this.labelHereditaryDiseases.Name = "labelHereditaryDiseases";
        this.labelHereditaryDiseases.TabIndex = 15;

        this.labelTheWayThePatientArrive = new TTVisual.TTLabel();
        this.labelTheWayThePatientArrive.Text = "Birime Geliş Şekli";
        this.labelTheWayThePatientArrive.Name = "labelTheWayThePatientArrive";
        this.labelTheWayThePatientArrive.TabIndex = 13;

        this.TheWayThePatientArrive = new TTVisual.TTEnumComboBox();
        this.TheWayThePatientArrive.DataTypeName = "TheWayThePatientArriveEnum";
        this.TheWayThePatientArrive.Name = "TheWayThePatientArrive";
        this.TheWayThePatientArrive.TabIndex = 12;

        this.labelWhereThePatientCameFrom = new TTVisual.TTLabel();
        this.labelWhereThePatientCameFrom.Text = "Geldği Yer";
        this.labelWhereThePatientCameFrom.Name = "labelWhereThePatientCameFrom";
        this.labelWhereThePatientCameFrom.TabIndex = 11;

        this.labelLastRehabDate = new TTVisual.TTLabel();
        this.labelLastRehabDate.Text = "Alınmı İse En Son XXXXXXye Kabul Tarihi";
        this.labelLastRehabDate.Name = "labelLastRehabDate";
        this.labelLastRehabDate.TabIndex = 9;

        this.LastRehabDate = new TTVisual.TTDateTimePicker();
        this.LastRehabDate.Format = DateTimePickerFormat.Long;
        this.LastRehabDate.Name = "LastRehabDate";
        this.LastRehabDate.TabIndex = 8;

        this.labelRehabHistory = new TTVisual.TTLabel();
        this.labelRehabHistory.Text = "Daha önce Rehabilitasyon Programına Alınmış mı?";
        this.labelRehabHistory.Name = "labelRehabHistory";
        this.labelRehabHistory.TabIndex = 7;

        this.RehabHistory = new TTVisual.TTEnumComboBox();
        this.RehabHistory.DataTypeName = "YesNoEnum";
        this.RehabHistory.Name = "RehabHistory";
        this.RehabHistory.TabIndex = 6;

        this.labelCauseOfInjury = new TTVisual.TTLabel();
        this.labelCauseOfInjury.Text = "Yaralanma Şekli";
        this.labelCauseOfInjury.Name = "labelCauseOfInjury";
        this.labelCauseOfInjury.TabIndex = 5;

        this.CauseOfInjury = new TTVisual.TTEnumComboBox();
        this.CauseOfInjury.DataTypeName = "CauseOfInjuryEnum";
        this.CauseOfInjury.Name = "CauseOfInjury";
        this.CauseOfInjury.TabIndex = 4;

        this.labelChildCount = new TTVisual.TTLabel();
        this.labelChildCount.Text = "Çocuk Sayısı";
        this.labelChildCount.Name = "labelChildCount";
        this.labelChildCount.TabIndex = 3;

        this.labelPatientLanguage = new TTVisual.TTLabel();
        this.labelPatientLanguage.Text = "Kullandığı Lisan";
        this.labelPatientLanguage.Name = "labelPatientLanguage";
        this.labelPatientLanguage.TabIndex = 1;

        this.Controls = [this.InfantNutritionalStatus, this.labelWeight, this.Weight, this.Height, this.BloodTransfusionReaction, this.AssistiveDevices, this.PastIllnessesAndOperations, this.HereditaryDiseases, this.WhereThePatientCameFrom, this.ChildCount, this.PatientLanguage, this.labelHeight, this.labelApplicationDate, this.ApplicationDate, this.labelBloodTransfusionReaction, this.labelBloodTransfusionPracticed, this.BloodTransfusionPracticed, this.labelAssistiveDevices, this.labelPastIllnessesAndOperations, this.labelHereditaryDiseases, this.labelTheWayThePatientArrive, this.TheWayThePatientArrive, this.labelWhereThePatientCameFrom, this.labelLastRehabDate, this.LastRehabDate, this.labelRehabHistory, this.RehabHistory, this.labelCauseOfInjury, this.CauseOfInjury, this.labelChildCount, this.labelPatientLanguage];

    }


}
