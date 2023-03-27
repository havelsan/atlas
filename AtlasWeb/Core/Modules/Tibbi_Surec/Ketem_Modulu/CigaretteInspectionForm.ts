//$B2AB5284
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { CigaretteInspectionFormViewModel } from './CigaretteInspectionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CigaretteExamination } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: 'CigaretteInspectionForm',
    templateUrl: './CigaretteInspectionForm.html',
    providers: [MessageService]
})
export class CigaretteInspectionForm extends TTVisual.TTForm implements OnInit {
    AdditionalComplaint: TTVisual.ITTTextBox;
    Challenges: TTVisual.ITTTextBox;
    Constipation: TTVisual.ITTCheckBox;
    ControlCO: TTVisual.ITTTextBox;
    ControlCOHb: TTVisual.ITTTextBox;
    ControlNumber: TTVisual.ITTTextBox;
    ControlType: TTVisual.ITTEnumComboBox;
    DidSheHeSmoke: TTVisual.ITTEnumComboBox;
    ExcessiveSmoking: TTVisual.ITTCheckBox;
    gb1: TTVisual.ITTGroupBox;
    GetTraining: TTVisual.ITTEnumComboBox;
    HeadacheAndDizziness: TTVisual.ITTCheckBox;
    HeadAndFacialNumbness: TTVisual.ITTCheckBox;
    Imbalance: TTVisual.ITTCheckBox;
    IncreasedAppetite: TTVisual.ITTCheckBox;
    Irritability: TTVisual.ITTCheckBox;
    labelAdditionalComplaint: TTVisual.ITTLabel;
    labelControlCO: TTVisual.ITTLabel;
    labelControlCOHb: TTVisual.ITTLabel;
    labelControlNumber: TTVisual.ITTLabel;
    labelControlType: TTVisual.ITTLabel;
    labelDidSheHeSmoke: TTVisual.ITTLabel;
    labelGetTraining: TTVisual.ITTLabel;
    labelMedicationRange: TTVisual.ITTLabel;
    labelPhysicalExamination: TTVisual.ITTLabel;
    labelQuitDate: TTVisual.ITTLabel;
    labelQuitSmokingMethod: TTVisual.ITTLabel;
    labelSmokingAmount: TTVisual.ITTLabel;
    labelSmokingReason: TTVisual.ITTLabel;
    labelTreatment: TTVisual.ITTLabel;
    LossOfConcentration: TTVisual.ITTCheckBox;
    MedicationRange: TTVisual.ITTTextBox;
    MedicineRangeType: TTVisual.ITTEnumComboBox;
    MouthSore: TTVisual.ITTCheckBox;
    NoDifficulty: TTVisual.ITTCheckBox;
    Other: TTVisual.ITTCheckBox;
    PhysicalExamination: TTVisual.ITTEnumComboBox;
    QuitDate: TTVisual.ITTDateTimePicker;
    QuitSmokingMethod: TTVisual.ITTEnumComboBox;
    SleepingDisorder: TTVisual.ITTCheckBox;
    SmokingAmount: TTVisual.ITTTextBox;
    SmokingReason: TTVisual.ITTTextBox;
    Treatment: TTVisual.ITTEnumComboBox;
    public statesPanelClass: string = "col-lg-6";
    public _buttonCaption: string = "Yazdır";
    public _buttonIcon: string = "fa fa-print";
    public cigaretteInspectionFormViewModel: CigaretteInspectionFormViewModel = new CigaretteInspectionFormViewModel();
    public get _CigaretteExamination(): CigaretteExamination {
        return this._TTObject as CigaretteExamination;
    }
    private CigaretteInspectionForm_DocumentUrl: string = '/api/CigaretteExaminationService/CigaretteInspectionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('CIGARETTEEXAMINATION', 'CigaretteInspectionForm');
        this._DocumentServiceUrl = this.CigaretteInspectionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CigaretteExamination();
        this.cigaretteInspectionFormViewModel = new CigaretteInspectionFormViewModel();
        this._ViewModel = this.cigaretteInspectionFormViewModel;
        this.cigaretteInspectionFormViewModel._CigaretteExamination = this._TTObject as CigaretteExamination;
    }

    protected loadViewModel() {
        let that = this;
        that.cigaretteInspectionFormViewModel = this._ViewModel as CigaretteInspectionFormViewModel;
        that._TTObject = this.cigaretteInspectionFormViewModel._CigaretteExamination;
        if (this.cigaretteInspectionFormViewModel == null)
            this.cigaretteInspectionFormViewModel = new CigaretteInspectionFormViewModel();
        if (this.cigaretteInspectionFormViewModel._CigaretteExamination == null)
            this.cigaretteInspectionFormViewModel._CigaretteExamination = new CigaretteExamination();

    }

    async ngOnInit() {
        await this.load(CigaretteInspectionFormViewModel);
    }

    public onAdditionalComplaintChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.AdditionalComplaint != event) {
            this._CigaretteExamination.AdditionalComplaint = event;
        }
    }

    public onChallengesChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Challenges != event) {
            this._CigaretteExamination.Challenges = event;
        }
    }

    public onConstipationChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Constipation != event) {
            this._CigaretteExamination.Constipation = event;
        }
    }

    public onControlCOChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.ControlCO != event) {
            this._CigaretteExamination.ControlCO = event;
        }
    }

    public onControlCOHbChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.ControlCOHb != event) {
            this._CigaretteExamination.ControlCOHb = event;
        }
    }

    public onControlNumberChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.ControlNumber != event) {
            this._CigaretteExamination.ControlNumber = event;
        }
    }

    public onControlTypeChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.ControlType != event) {
            this._CigaretteExamination.ControlType = event;
        }
    }

    public onDidSheHeSmokeChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.DidSheHeSmoke != event) {
            this._CigaretteExamination.DidSheHeSmoke = event;
        }
    }

    public onExcessiveSmokingChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.ExcessiveSmoking != event) {
            this._CigaretteExamination.ExcessiveSmoking = event;
        }
    }

    public onGetTrainingChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.GetTraining != event) {
            this._CigaretteExamination.GetTraining = event;
        }
    }

    public onHeadacheAndDizzinessChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.HeadacheAndDizziness != event) {
            this._CigaretteExamination.HeadacheAndDizziness = event;
        }
    }

    public onHeadAndFacialNumbnessChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.HeadAndFacialNumbness != event) {
            this._CigaretteExamination.HeadAndFacialNumbness = event;
        }
    }

    public onImbalanceChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Imbalance != event) {
            this._CigaretteExamination.Imbalance = event;
        }
    }

    public onIncreasedAppetiteChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.IncreasedAppetite != event) {
            this._CigaretteExamination.IncreasedAppetite = event;
        }
    }

    public onIrritabilityChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Irritability != event) {
            this._CigaretteExamination.Irritability = event;
        }
    }

    public onLossOfConcentrationChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.LossOfConcentration != event) {
            this._CigaretteExamination.LossOfConcentration = event;
        }
    }

    public onMedicationRangeChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.MedicationRange != event) {
            this._CigaretteExamination.MedicationRange = event;
        }
    }

    public onMedicineRangeTypeChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.MedicineRangeType != event) {
            this._CigaretteExamination.MedicineRangeType = event;
        }
    }

    public onMouthSoreChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.MouthSore != event) {
            this._CigaretteExamination.MouthSore = event;
        }
    }

    public onNoDifficultyChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.NoDifficulty != event) {
            this._CigaretteExamination.NoDifficulty = event;
        }
    }

    public onOtherChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Other != event) {
            this._CigaretteExamination.Other = event;
        }
    }

    public onPhysicalExaminationChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.PhysicalExamination != event) {
            this._CigaretteExamination.PhysicalExamination = event;
        }
    }

    public onQuitDateChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.QuitDate != event) {
            this._CigaretteExamination.QuitDate = event;
        }
    }

    public onQuitSmokingMethodChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.QuitSmokingMethod != event) {
            this._CigaretteExamination.QuitSmokingMethod = event;
        }
    }

    public onSleepingDisorderChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.SleepingDisorder != event) {
            this._CigaretteExamination.SleepingDisorder = event;
        }
    }

    public onSmokingAmountChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.SmokingAmount != event) {
            this._CigaretteExamination.SmokingAmount = event;
        }
    }

    public onSmokingReasonChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.SmokingReason != event) {
            this._CigaretteExamination.SmokingReason = event;
        }
    }

    public onTreatmentChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Treatment != event) {
            this._CigaretteExamination.Treatment = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Irritability, "Value", this.__ttObject, "Irritability");
        redirectProperty(this.HeadAndFacialNumbness, "Value", this.__ttObject, "HeadAndFacialNumbness");
        redirectProperty(this.SleepingDisorder, "Value", this.__ttObject, "SleepingDisorder");
        redirectProperty(this.Imbalance, "Value", this.__ttObject, "Imbalance");
        redirectProperty(this.ExcessiveSmoking, "Value", this.__ttObject, "ExcessiveSmoking");
        redirectProperty(this.LossOfConcentration, "Value", this.__ttObject, "LossOfConcentration");
        redirectProperty(this.Constipation, "Value", this.__ttObject, "Constipation");
        redirectProperty(this.HeadacheAndDizziness, "Value", this.__ttObject, "HeadacheAndDizziness");
        redirectProperty(this.NoDifficulty, "Value", this.__ttObject, "NoDifficulty");
        redirectProperty(this.Other, "Value", this.__ttObject, "Other");
        redirectProperty(this.IncreasedAppetite, "Value", this.__ttObject, "IncreasedAppetite");
        redirectProperty(this.MouthSore, "Value", this.__ttObject, "MouthSore");
        redirectProperty(this.Challenges, "Text", this.__ttObject, "Challenges");
        redirectProperty(this.ControlType, "Value", this.__ttObject, "ControlType");
        redirectProperty(this.ControlCO, "Text", this.__ttObject, "ControlCO");
        redirectProperty(this.GetTraining, "Value", this.__ttObject, "GetTraining");
        redirectProperty(this.ControlCOHb, "Text", this.__ttObject, "ControlCOHb");
        redirectProperty(this.ControlNumber, "Text", this.__ttObject, "ControlNumber");
        redirectProperty(this.PhysicalExamination, "Value", this.__ttObject, "PhysicalExamination");
        redirectProperty(this.QuitDate, "Value", this.__ttObject, "QuitDate");
        redirectProperty(this.MedicationRange, "Text", this.__ttObject, "MedicationRange");
        redirectProperty(this.MedicineRangeType, "Value", this.__ttObject, "MedicineRangeType");
        redirectProperty(this.DidSheHeSmoke, "Value", this.__ttObject, "DidSheHeSmoke");
        redirectProperty(this.Treatment, "Value", this.__ttObject, "Treatment");
        redirectProperty(this.SmokingAmount, "Text", this.__ttObject, "SmokingAmount");
        redirectProperty(this.AdditionalComplaint, "Text", this.__ttObject, "AdditionalComplaint");
        redirectProperty(this.SmokingReason, "Text", this.__ttObject, "SmokingReason");
        redirectProperty(this.QuitSmokingMethod, "Value", this.__ttObject, "QuitSmokingMethod");
    }

    public initFormControls(): void {
        this.labelPhysicalExamination = new TTVisual.TTLabel();
        this.labelPhysicalExamination.Text = "Fiziki Muayene";
        this.labelPhysicalExamination.Name = "labelPhysicalExamination";
        this.labelPhysicalExamination.TabIndex = 30;

        this.PhysicalExamination = new TTVisual.TTEnumComboBox();
        this.PhysicalExamination.DataTypeName = "PhysicalExaminationEnum";
        this.PhysicalExamination.Name = "PhysicalExamination";
        this.PhysicalExamination.TabIndex = 29;

        this.MedicineRangeType = new TTVisual.TTEnumComboBox();
        this.MedicineRangeType.DataTypeName = "PeriodUnitTypeEnum";
        this.MedicineRangeType.Name = "MedicineRangeType";
        this.MedicineRangeType.TabIndex = 28;

        this.labelAdditionalComplaint = new TTVisual.TTLabel();
        this.labelAdditionalComplaint.Text = "Ek Şikayet";
        this.labelAdditionalComplaint.Name = "labelAdditionalComplaint";
        this.labelAdditionalComplaint.TabIndex = 27;

        this.AdditionalComplaint = new TTVisual.TTTextBox();
        this.AdditionalComplaint.Multiline = true;
        this.AdditionalComplaint.Name = "AdditionalComplaint";
        this.AdditionalComplaint.TabIndex = 26;

        this.MedicationRange = new TTVisual.TTTextBox();
        this.MedicationRange.Name = "MedicationRange";
        this.MedicationRange.TabIndex = 20;

        this.ControlCOHb = new TTVisual.TTTextBox();
        this.ControlCOHb.Name = "ControlCOHb";
        this.ControlCOHb.TabIndex = 18;

        this.ControlCO = new TTVisual.TTTextBox();
        this.ControlCO.Name = "ControlCO";
        this.ControlCO.TabIndex = 16;

        this.SmokingReason = new TTVisual.TTTextBox();
        this.SmokingReason.Name = "SmokingReason";
        this.SmokingReason.TabIndex = 14;

        this.SmokingAmount = new TTVisual.TTTextBox();
        this.SmokingAmount.Name = "SmokingAmount";
        this.SmokingAmount.TabIndex = 12;

        this.ControlNumber = new TTVisual.TTTextBox();
        this.ControlNumber.Name = "ControlNumber";
        this.ControlNumber.TabIndex = 6;

        this.labelTreatment = new TTVisual.TTLabel();
        this.labelTreatment.Text = "Tedavi Alıyor Mu?";
        this.labelTreatment.Name = "labelTreatment";
        this.labelTreatment.TabIndex = 25;

        this.Treatment = new TTVisual.TTEnumComboBox();
        this.Treatment.DataTypeName = "YesNoEnum";
        this.Treatment.Name = "Treatment";
        this.Treatment.TabIndex = 24;

        this.labelMedicationRange = new TTVisual.TTLabel();
        this.labelMedicationRange.Text = "İlaç Kullanım Süresi";
        this.labelMedicationRange.Name = "labelMedicationRange";
        this.labelMedicationRange.TabIndex = 21;

        this.labelControlCOHb = new TTVisual.TTLabel();
        this.labelControlCOHb.Text = "Kontrol COHb";
        this.labelControlCOHb.Name = "labelControlCOHb";
        this.labelControlCOHb.TabIndex = 19;

        this.labelControlCO = new TTVisual.TTLabel();
        this.labelControlCO.Text = "Kontrol CO";
        this.labelControlCO.Name = "labelControlCO";
        this.labelControlCO.TabIndex = 17;

        this.labelSmokingReason = new TTVisual.TTLabel();
        this.labelSmokingReason.Text = "Neden İçti?";
        this.labelSmokingReason.Name = "labelSmokingReason";
        this.labelSmokingReason.TabIndex = 15;

        this.labelSmokingAmount = new TTVisual.TTLabel();
        this.labelSmokingAmount.Text = "Kaç Tane İçti?";
        this.labelSmokingAmount.Name = "labelSmokingAmount";
        this.labelSmokingAmount.TabIndex = 13;

        this.labelDidSheHeSmoke = new TTVisual.TTLabel();
        this.labelDidSheHeSmoke.Text = "Sigara İçti Mi?";
        this.labelDidSheHeSmoke.Name = "labelDidSheHeSmoke";
        this.labelDidSheHeSmoke.TabIndex = 11;

        this.DidSheHeSmoke = new TTVisual.TTEnumComboBox();
        this.DidSheHeSmoke.DataTypeName = "YesNoEnum";
        this.DidSheHeSmoke.Name = "DidSheHeSmoke";
        this.DidSheHeSmoke.TabIndex = 10;

        this.labelQuitDate = new TTVisual.TTLabel();
        this.labelQuitDate.Text = "Bırakma Tarihi";
        this.labelQuitDate.Name = "labelQuitDate";
        this.labelQuitDate.TabIndex = 9;

        this.QuitDate = new TTVisual.TTDateTimePicker();
        this.QuitDate.Format = DateTimePickerFormat.Long;
        this.QuitDate.Name = "QuitDate";
        this.QuitDate.TabIndex = 8;

        this.labelControlNumber = new TTVisual.TTLabel();
        this.labelControlNumber.Text = "Kaçıncı Kontrol";
        this.labelControlNumber.Name = "labelControlNumber";
        this.labelControlNumber.TabIndex = 7;

        this.labelGetTraining = new TTVisual.TTLabel();
        this.labelGetTraining.Text = "Eğitim Aldı Mı?";
        this.labelGetTraining.Name = "labelGetTraining";
        this.labelGetTraining.TabIndex = 5;

        this.GetTraining = new TTVisual.TTEnumComboBox();
        this.GetTraining.DataTypeName = "YesNoEnum";
        this.GetTraining.Name = "GetTraining";
        this.GetTraining.TabIndex = 4;

        this.labelControlType = new TTVisual.TTLabel();
        this.labelControlType.Text = "Kontrol Şekli";
        this.labelControlType.Name = "labelControlType";
        this.labelControlType.TabIndex = 3;

        this.ControlType = new TTVisual.TTEnumComboBox();
        this.ControlType.DataTypeName = "ControlTypeEnum";
        this.ControlType.Name = "ControlType";
        this.ControlType.TabIndex = 2;

        this.labelQuitSmokingMethod = new TTVisual.TTLabel();
        this.labelQuitSmokingMethod.Text = "Sigarayı Bırakma Yöntemi";
        this.labelQuitSmokingMethod.Name = "labelQuitSmokingMethod";
        this.labelQuitSmokingMethod.TabIndex = 1;

        this.QuitSmokingMethod = new TTVisual.TTEnumComboBox();
        this.QuitSmokingMethod.DataTypeName = "QuitSmokingMethodEnum";
        this.QuitSmokingMethod.Name = "QuitSmokingMethod";
        this.QuitSmokingMethod.TabIndex = 0;

        this.gb1 = new TTVisual.TTGroupBox();
        this.gb1.Text = "Karşılaşılan Güçlükler";
        this.gb1.Name = "gb1";
        this.gb1.TabIndex = 47;

        this.Challenges = new TTVisual.TTTextBox();
        this.Challenges.Name = "Challenges";
        this.Challenges.TabIndex = 12;

        this.Other = new TTVisual.TTCheckBox();
        this.Other.Value = false;
        this.Other.Title = "Diğer";
        this.Other.Name = "Other";
        this.Other.TabIndex = 11;

        this.NoDifficulty = new TTVisual.TTCheckBox();
        this.NoDifficulty.Value = false;
        this.NoDifficulty.Title = "Zorluk Yok";
        this.NoDifficulty.Name = "NoDifficulty";
        this.NoDifficulty.TabIndex = 10;

        this.MouthSore = new TTVisual.TTCheckBox();
        this.MouthSore.Value = false;
        this.MouthSore.Title = "Ağız Yaraları";
        this.MouthSore.Name = "MouthSore";
        this.MouthSore.TabIndex = 9;

        this.IncreasedAppetite = new TTVisual.TTCheckBox();
        this.IncreasedAppetite.Value = false;
        this.IncreasedAppetite.Title = "İştah Artması";
        this.IncreasedAppetite.Name = "IncreasedAppetite";
        this.IncreasedAppetite.TabIndex = 8;

        this.ExcessiveSmoking = new TTVisual.TTCheckBox();
        this.ExcessiveSmoking.Value = false;
        this.ExcessiveSmoking.Title = "Aşırı Sigara İçme";
        this.ExcessiveSmoking.Name = "ExcessiveSmoking";
        this.ExcessiveSmoking.TabIndex = 7;

        this.Imbalance = new TTVisual.TTCheckBox();
        this.Imbalance.Value = false;
        this.Imbalance.Title = "Dengesizlik";
        this.Imbalance.Name = "Imbalance";
        this.Imbalance.TabIndex = 6;

        this.SleepingDisorder = new TTVisual.TTCheckBox();
        this.SleepingDisorder.Value = false;
        this.SleepingDisorder.Title = "Uyku Bozukluğu";
        this.SleepingDisorder.Name = "SleepingDisorder";
        this.SleepingDisorder.TabIndex = 5;

        this.HeadAndFacialNumbness = new TTVisual.TTCheckBox();
        this.HeadAndFacialNumbness.Value = false;
        this.HeadAndFacialNumbness.Title = "Yüz ve Başta Uyuşma";
        this.HeadAndFacialNumbness.Name = "HeadAndFacialNumbness";
        this.HeadAndFacialNumbness.TabIndex = 4;

        this.LossOfConcentration = new TTVisual.TTCheckBox();
        this.LossOfConcentration.Value = false;
        this.LossOfConcentration.Title = "KonsantrasyonBozukluğu";
        this.LossOfConcentration.Name = "LossOfConcentration";
        this.LossOfConcentration.TabIndex = 3;

        this.Irritability = new TTVisual.TTCheckBox();
        this.Irritability.Value = false;
        this.Irritability.Title = "Sinirlilik";
        this.Irritability.Name = "Irritability";
        this.Irritability.TabIndex = 2;

        this.HeadacheAndDizziness = new TTVisual.TTCheckBox();
        this.HeadacheAndDizziness.Value = false;
        this.HeadacheAndDizziness.Title = "Baş Ağrısı";
        this.HeadacheAndDizziness.Name = "HeadacheAndDizziness";
        this.HeadacheAndDizziness.TabIndex = 1;

        this.Constipation = new TTVisual.TTCheckBox();
        this.Constipation.Value = false;
        this.Constipation.Title = "Kabız";
        this.Constipation.Name = "Constipation";
        this.Constipation.TabIndex = 0;

        this.gb1.Controls = [this.Challenges, this.Other, this.NoDifficulty, this.MouthSore, this.IncreasedAppetite, this.ExcessiveSmoking, this.Imbalance, this.SleepingDisorder, this.HeadAndFacialNumbness, this.LossOfConcentration, this.Irritability, this.HeadacheAndDizziness, this.Constipation];
        this.Controls = [this.labelPhysicalExamination, this.PhysicalExamination, this.MedicineRangeType, this.labelAdditionalComplaint, this.AdditionalComplaint, this.MedicationRange, this.ControlCOHb, this.ControlCO, this.SmokingReason, this.SmokingAmount, this.ControlNumber, this.labelTreatment, this.Treatment, this.labelMedicationRange, this.labelControlCOHb, this.labelControlCO, this.labelSmokingReason, this.labelSmokingAmount, this.labelDidSheHeSmoke, this.DidSheHeSmoke, this.labelQuitDate, this.QuitDate, this.labelControlNumber, this.labelGetTraining, this.GetTraining, this.labelControlType, this.ControlType, this.labelQuitSmokingMethod, this.QuitSmokingMethod, this.gb1, this.Challenges, this.Other, this.NoDifficulty, this.MouthSore, this.IncreasedAppetite, this.ExcessiveSmoking, this.Imbalance, this.SleepingDisorder, this.HeadAndFacialNumbness, this.LossOfConcentration, this.Irritability, this.HeadacheAndDizziness, this.Constipation];

    }

    printCigaretteInspectionForm() {

        let reportData: DynamicReportParameters = {

            Code: 'SIGARAIZLEMFORMU',
            ReportParams: { ObjectID: this._CigaretteExamination.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "SİGARA İZLEM FORMU"

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
