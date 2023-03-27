//$338F6757
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { MedicalInformationFormViewModel } from './MedicalInformationFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MedicalInformation, VarYokGarantiEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIngredientDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DietMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDisabledGroup } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDrugAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoFoodAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoHabits } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { HvlDataGrid } from 'app/Fw/Components/HvlDataGrid';

import { ModalStateService } from '../../../wwwroot/app/Fw/Models/ModalInfo';

@Component({
    selector: 'MedicalInformationForm',
    templateUrl: './MedicalInformationForm.html',
    providers: [MessageService]
})
export class MedicalInformationForm extends TTVisual.TTForm implements OnInit {

    @ViewChild('gridMedicalInfoDrugAllergies') gridMedicalInfoDrugAllergies: HvlDataGrid;
    @ViewChild('gridMedicalInfoFoodAllergies') gridMedicalInfoFoodAllergies: HvlDataGrid;

    ContagiousDisease: TTVisual.ITTTextBox;
    HasContagiousDisease: TTVisual.ITTEnumComboBox;
    labelHasContagiousDisease: TTVisual.ITTLabel;
    HasAllergy: TTVisual.ITTEnumComboBox;
    labelHasAllergy: TTVisual.ITTLabel;
    ActiveIngredientMedicalInfoDrugAllergies: TTVisual.ITTListBoxColumn;
    Advers: TTVisual.ITTCheckBox;
    AlcoholMedicalInfoHabits: TTVisual.ITTCheckBox;
    AlcoholUsageFrequencyMedicalInfoHabits: TTVisual.ITTObjectListBox;
    Broken: TTVisual.ITTCheckBox;
    CardiacPacemaker: TTVisual.ITTCheckBox;
    ChronicDiseases: TTVisual.ITTTextBox;
    ChronicMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    CigaretteMedicalInfoHabits: TTVisual.ITTCheckBox;
    CigaretteUsageFrequencyMedicalInfoHabits: TTVisual.ITTObjectListBox;
    CoffeeMedicalInfoHabits: TTVisual.ITTCheckBox;
    DescriptionMedicalInfoHabits: TTVisual.ITTTextBox;
    Diabetes: TTVisual.ITTCheckBox;
    DietMaterialMedicalInfoFoodAllergies: TTVisual.ITTListBoxColumn;
    HearingMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    HeartFailure: TTVisual.ITTCheckBox;
    Hemodialysis: TTVisual.ITTTextBox;
    Implant: TTVisual.ITTTextBox;
    Infection: TTVisual.ITTCheckBox;
    labelAlcoholUsageFrequencyMedicalInfoHabits: TTVisual.ITTLabel;
    labelChronicDiseases: TTVisual.ITTLabel;
    labelCigaretteUsageFrequencyMedicalInfoHabits: TTVisual.ITTLabel;
    labelDescriptionMedicalInfoHabits: TTVisual.ITTLabel;
    labelHemodialysis: TTVisual.ITTLabel;
    labelImplant: TTVisual.ITTLabel;
    labelOncologicFollowUp: TTVisual.ITTLabel;
    labelOtherAllergiesMedicalInfoAllergies: TTVisual.ITTLabel;
    labelOtherInformation: TTVisual.ITTLabel;
    labelTransplantation: TTVisual.ITTLabel;

    MedicalInfoDrugAllergiesList: TTVisual.ITTObjectListBox;
    MedicalInfoFoodAllergiesList: TTVisual.ITTObjectListBox;

    Malignancy: TTVisual.ITTCheckBox;
    MedicalInfoDrugAllergiesMedicalInfoDrugAllergies: TTVisual.ITTGrid;
    MedicalInfoFoodAllergiesMedicalInfoFoodAllergies: TTVisual.ITTGrid;
    MentalMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    MetalImplant: TTVisual.ITTCheckBox;
    NonexistenceMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    OncologicFollowUp: TTVisual.ITTTextBox;
    OrthopedicMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    Other: TTVisual.ITTCheckBox;
    OtherAllergiesMedicalInfoAllergies: TTVisual.ITTTextBox;
    OtherInformation: TTVisual.ITTTextBox;
    OtherMedicalInfoHabits: TTVisual.ITTCheckBox;
    Pregnancy: TTVisual.ITTCheckBox;
    HighRiskPregnancy: TTVisual.ITTCheckBox;
    Pandemic: TTVisual.ITTCheckBox;
    PsychicAndEmotionalMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    SpeechAndLanguageMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    Stent: TTVisual.ITTCheckBox;
    TeaMedicalInfoHabits: TTVisual.ITTCheckBox;
    Transplantation: TTVisual.ITTTextBox;
    ttgroupboxAllergies: TTVisual.ITTGroupBox;
    ttgroupboxDisability: TTVisual.ITTGroupBox;
    ttgroupboxHabits: TTVisual.ITTGroupBox;
    UnclassifiedMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    VascularDisorder: TTVisual.ITTCheckBox;
    VisionMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    public MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesColumns = [];
    public MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesColumns = [];
    public medicalInformationFormViewModel: MedicalInformationFormViewModel = new MedicalInformationFormViewModel();


    public get _MedicalInformation(): MedicalInformation {
        return this._TTObject as MedicalInformation;
    }
    private MedicalInformationForm_DocumentUrl: string = '/api/MedicalInformationService/MedicalInformationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private modalStateService: ModalStateService) {
        super("MEDICALINFORMATION", "MedicalInformationForm");
        this._DocumentServiceUrl = this.MedicalInformationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    // ***** Method declarations start *****

    protected async PreScript(): Promise<void> {
        super.PreScript();

        if (this.medicalInformationFormViewModel._MedicalInformation.HasAllergy != null && this.medicalInformationFormViewModel._MedicalInformation.HasAllergy == VarYokGarantiEnum.V) {
            this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.ShowFilterCombo = true;
            this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.AllowUserToDeleteRows = true;

            this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.ShowFilterCombo = true;
            this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.AllowUserToDeleteRows = true;

            this.OtherAllergiesMedicalInfoAllergies.Enabled = true;
        } else if (this.medicalInformationFormViewModel._MedicalInformation.HasAllergy != null && this.medicalInformationFormViewModel._MedicalInformation.HasAllergy == VarYokGarantiEnum.Y) {
            this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.ShowFilterCombo = false;
            this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.AllowUserToDeleteRows = false;

            this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.ShowFilterCombo = false;
            this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.AllowUserToDeleteRows = false;

            this.OtherAllergiesMedicalInfoAllergies.Enabled = false;
        }

        if (this.medicalInformationFormViewModel._MedicalInformation.HasContagiousDisease != null && this.medicalInformationFormViewModel._MedicalInformation.HasContagiousDisease == VarYokGarantiEnum.V) {
            this.ContagiousDisease.Enabled = true;
        } else if (this.medicalInformationFormViewModel._MedicalInformation.HasContagiousDisease != null && this.medicalInformationFormViewModel._MedicalInformation.HasContagiousDisease == VarYokGarantiEnum.Y) {
            this.ContagiousDisease.Enabled = false;
        }

        if (this._MedicalInformation.MedicalInfoDisabledGroup != null && this._MedicalInformation.MedicalInfoDisabledGroup.Nonexistence != null) {

            if (this._MedicalInformation.MedicalInfoDisabledGroup.Nonexistence == true) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Orthopedic = false;
                this.OrthopedicMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Hearing = false;
                this.HearingMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Chronic = false;
                this.ChronicMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Mental = false;
                this.MentalMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional = false;
                this.PsychicAndEmotionalMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Vision = false;
                this.VisionMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage = false;
                this.SpeechAndLanguageMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Unclassified = false;
                this.UnclassifiedMedicalInfoDisabledGroup.ReadOnly = true;
            } else if (this._MedicalInformation.MedicalInfoDisabledGroup.Nonexistence == false) {
                this.OrthopedicMedicalInfoDisabledGroup.ReadOnly = false;
                this.HearingMedicalInfoDisabledGroup.ReadOnly = false;
                this.ChronicMedicalInfoDisabledGroup.ReadOnly = false;
                this.MentalMedicalInfoDisabledGroup.ReadOnly = false;
                this.PsychicAndEmotionalMedicalInfoDisabledGroup.ReadOnly = false;
                this.VisionMedicalInfoDisabledGroup.ReadOnly = false;
                this.SpeechAndLanguageMedicalInfoDisabledGroup.ReadOnly = false;
                this.UnclassifiedMedicalInfoDisabledGroup.ReadOnly = false;
            }
        }

        if (this._MedicalInformation.MedicalInfoHabits != null && this._MedicalInformation.MedicalInfoHabits.Alcohol != null) {

            if (this._MedicalInformation.MedicalInfoHabits.Alcohol == true) {
                this.AlcoholUsageFrequencyMedicalInfoHabits.ReadOnly = false;
            } else if (this._MedicalInformation.MedicalInfoHabits.Alcohol == false) {
                this.AlcoholUsageFrequencyMedicalInfoHabits.ReadOnly = true;
            }

        }
    }
    private _PatientID: string;
    //public setInputParam(value: any) {
    //    i
    //    this._PatientID = value.toString();
    //    this.medicalInformationFormViewModel._PatientID = value;
    //}

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MedicalInformation();
        this.medicalInformationFormViewModel = new MedicalInformationFormViewModel();
        this._ViewModel = this.medicalInformationFormViewModel;

        this.medicalInformationFormViewModel._MedicalInformation = this._TTObject as MedicalInformation;
        this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
        this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
        this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency = new SKRSSigaraKullanimi();
        this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency = new SKRSAlkolKullanimi();
        this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoAllergies = new MedicalInfoAllergies();
        this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies = new Array<MedicalInfoFoodAllergies>();
        this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies = new Array<MedicalInfoDrugAllergies>();
    }

    protected loadViewModel() {
        let that = this;
        that.medicalInformationFormViewModel = this._ViewModel as MedicalInformationFormViewModel;
        that._TTObject = this.medicalInformationFormViewModel._MedicalInformation;
        if (this.medicalInformationFormViewModel == null)
            this.medicalInformationFormViewModel = new MedicalInformationFormViewModel();
        if (this.medicalInformationFormViewModel._MedicalInformation == null)
            this.medicalInformationFormViewModel._MedicalInformation = new MedicalInformation();
        let medicalInfoDisabledGroupObjectID = that.medicalInformationFormViewModel._MedicalInformation["MedicalInfoDisabledGroup"];
        if (medicalInfoDisabledGroupObjectID != null && (typeof medicalInfoDisabledGroupObjectID === "string")) {
            let medicalInfoDisabledGroup = that.medicalInformationFormViewModel.MedicalInfoDisabledGroups.find(o => o.ObjectID.toString() === medicalInfoDisabledGroupObjectID.toString());
            if (medicalInfoDisabledGroup) {
                that.medicalInformationFormViewModel._MedicalInformation.MedicalInfoDisabledGroup = medicalInfoDisabledGroup;
            }
        }
        let medicalInfoHabitsObjectID = that.medicalInformationFormViewModel._MedicalInformation["MedicalInfoHabits"];
        if (medicalInfoHabitsObjectID != null && (typeof medicalInfoHabitsObjectID === "string")) {
            let medicalInfoHabits = that.medicalInformationFormViewModel.MedicalInfoHabitss.find(o => o.ObjectID.toString() === medicalInfoHabitsObjectID.toString());
            if (medicalInfoHabits) {
                that.medicalInformationFormViewModel._MedicalInformation.MedicalInfoHabits = medicalInfoHabits;
            }

            if (medicalInfoHabits != null) {
                let cigaretteUsageFrequencyObjectID = medicalInfoHabits["CigaretteUsageFrequency"];
                if (cigaretteUsageFrequencyObjectID != null && (typeof cigaretteUsageFrequencyObjectID === "string")) {
                    let cigaretteUsageFrequency = that.medicalInformationFormViewModel.SKRSSigaraKullanimis.find(o => o.ObjectID.toString() === cigaretteUsageFrequencyObjectID.toString());
                    if (cigaretteUsageFrequency) {
                        medicalInfoHabits.CigaretteUsageFrequency = cigaretteUsageFrequency;
                    }
                }

            }
            if (medicalInfoHabits != null) {
                let alcoholUsageFrequencyObjectID = medicalInfoHabits["AlcoholUsageFrequency"];
                if (alcoholUsageFrequencyObjectID != null && (typeof alcoholUsageFrequencyObjectID === "string")) {
                    let alcoholUsageFrequency = that.medicalInformationFormViewModel.SKRSAlkolKullanimis.find(o => o.ObjectID.toString() === alcoholUsageFrequencyObjectID.toString());
                    if (alcoholUsageFrequency) {
                        medicalInfoHabits.AlcoholUsageFrequency = alcoholUsageFrequency;
                    }
                }

            }
        }
        let medicalInfoAllergiesObjectID = that.medicalInformationFormViewModel._MedicalInformation["MedicalInfoAllergies"];
        if (medicalInfoAllergiesObjectID != null && (typeof medicalInfoAllergiesObjectID === "string")) {
            let medicalInfoAllergies = that.medicalInformationFormViewModel.MedicalInfoAllergiess.find(o => o.ObjectID.toString() === medicalInfoAllergiesObjectID.toString());
            if (medicalInfoAllergies) {
                that.medicalInformationFormViewModel._MedicalInformation.MedicalInfoAllergies = medicalInfoAllergies;
            }

            if (medicalInfoAllergies != null) {
                medicalInfoAllergies.MedicalInfoFoodAllergies = that.medicalInformationFormViewModel.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList;
                for (let detailItem of that.medicalInformationFormViewModel.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList) {
                    let dietMaterialObjectID = detailItem["DietMaterial"];
                    if (dietMaterialObjectID != null && (typeof dietMaterialObjectID === "string")) {
                        let dietMaterial = that.medicalInformationFormViewModel.DietMaterialDefinitions.find(o => o.ObjectID.toString() === dietMaterialObjectID.toString());
                        if (dietMaterial) {
                            detailItem.DietMaterial = dietMaterial;
                        }
                    }

                }
            }
            if (medicalInfoAllergies != null) {
                medicalInfoAllergies.MedicalInfoDrugAllergies = that.medicalInformationFormViewModel.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList;
                for (let detailItem of that.medicalInformationFormViewModel.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList) {
                    let activeIngredientObjectID = detailItem["ActiveIngredient"];
                    if (activeIngredientObjectID != null && (typeof activeIngredientObjectID === "string")) {
                        let activeIngredient = that.medicalInformationFormViewModel.ActiveIngredientDefinitions.find(o => o.ObjectID.toString() === activeIngredientObjectID.toString());
                        if (activeIngredient) {
                            detailItem.ActiveIngredient = activeIngredient;
                        }
                    }

                }
            }
        }
    }

    async ngOnInit() {
        await this.load();
    }

    public onAdversChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Advers != event) {
            this._MedicalInformation.Advers = event;
        }
    }

    public onAlcoholMedicalInfoHabitsChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoHabits == null) {
                this._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
            }
            if (this._MedicalInformation.MedicalInfoHabits.Alcohol != event) {
                this._MedicalInformation.MedicalInfoHabits.Alcohol = event;
            }

            if (event == true)
                this.AlcoholUsageFrequencyMedicalInfoHabits.ReadOnly = false;
            else
                this.AlcoholUsageFrequencyMedicalInfoHabits.ReadOnly = true;
        }
    }

    public onAlcoholUsageFrequencyMedicalInfoHabitsChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoHabits == null) {
                this._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
            }
            if (this._MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency != event) {
                this._MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency = event;
            }
        }
    }

    public onBrokenChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Broken != event) {
            this._MedicalInformation.Broken = event;
        }
    }

    public onCardiacPacemakerChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.CardiacPacemaker != event) {
            this._MedicalInformation.CardiacPacemaker = event;
        }
    }

    public onChronicDiseasesChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.ChronicDiseases != event) {
            this._MedicalInformation.ChronicDiseases = event;
        }
    }

    public onChronicMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.Chronic != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Chronic = event;
            }
        }
    }

    public onCigaretteMedicalInfoHabitsChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoHabits == null) {
                this._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
            }
            if (this._MedicalInformation.MedicalInfoHabits.Cigarette != event) {
                this._MedicalInformation.MedicalInfoHabits.Cigarette = event;
            }

            if (event == true)
                this.CigaretteUsageFrequencyMedicalInfoHabits.ReadOnly = false;
            else
                this.CigaretteUsageFrequencyMedicalInfoHabits.ReadOnly = true;
        }
    }

    public onCigaretteUsageFrequencyMedicalInfoHabitsChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoHabits == null) {
                this._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
            }
            if (this._MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency != event) {
                this._MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency = event;
            }
        }
    }

    public onCoffeeMedicalInfoHabitsChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoHabits == null) {
                this._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
            }
            if (this._MedicalInformation.MedicalInfoHabits.Coffee != event) {
                this._MedicalInformation.MedicalInfoHabits.Coffee = event;
            }
        }
    }

    public onContagiousDiseaseChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.ContagiousDisease != event) {
            this._MedicalInformation.ContagiousDisease = event;
        }
    }

    public onDescriptionMedicalInfoHabitsChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoHabits == null) {
                this._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
            }
            if (this._MedicalInformation.MedicalInfoHabits.Description != event) {
                this._MedicalInformation.MedicalInfoHabits.Description = event;
            }
        }
    }

    public onDiabetesChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Diabetes != event) {
            this._MedicalInformation.Diabetes = event;
        }
    }

    public onHasAllergyChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.HasAllergy != event) {
            this._MedicalInformation.HasAllergy = event;

        } if (event == 1) {
            this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.ShowFilterCombo = true;
            this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.AllowUserToDeleteRows = true;

            this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.ShowFilterCombo = true;
            this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.AllowUserToDeleteRows = true;
            this.OtherAllergiesMedicalInfoAllergies.Enabled = true;
        } else if (event == 2) {
            this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.ShowFilterCombo = false;
            this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.AllowUserToDeleteRows = false;

            this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.ShowFilterCombo = false;
            this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.AllowUserToDeleteRows = false;
            this.OtherAllergiesMedicalInfoAllergies.Enabled = false;
            this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies = new Array<MedicalInfoDrugAllergies>();
            this.medicalInformationFormViewModel._MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies = new Array<MedicalInfoFoodAllergies>();
        }
    }

    public onHearingMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.Hearing != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Hearing = event;
            }
        }
    }

    public onHasContagiousDiseaseChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.HasContagiousDisease != event) {
            this._MedicalInformation.HasContagiousDisease = event;

        }
        if (event == 1) {
            this.ContagiousDisease.Enabled = true;
        }
        if (event == 2) {
            this.ContagiousDisease.Enabled = false;
            this._MedicalInformation.ContagiousDisease = "";
        }
    }


    public onHeartFailureChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.HeartFailure != event) {
            this._MedicalInformation.HeartFailure = event;
        }
    }

    public onHemodialysisChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Hemodialysis != event) {
            this._MedicalInformation.Hemodialysis = event;
        }
    }

    public onHighRiskPregnancyChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.HighRiskPregnancy != event) {
            this._MedicalInformation.HighRiskPregnancy = event;

            if(this._MedicalInformation.HighRiskPregnancy == true){
            this.medicalInformationFormViewModel.changeHighRiskPregnancy = true;
            }
        }
    }

    public onPandemicChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Pandemic != event) {
            this._MedicalInformation.Pandemic = event;
        }
    }

    public onImplantChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Implant != event) {
            this._MedicalInformation.Implant = event;
        }
    }

    public onInfectionChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Infection != event) {
            this._MedicalInformation.Infection = event;
        }
    }

    public onMalignancyChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Malignancy != event) {
            this._MedicalInformation.Malignancy = event;
        }
    }

    public onMentalMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.Mental != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Mental = event;
            }
        }
    }

    public onMetalImplantChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.MetalImplant != event) {
            this._MedicalInformation.MetalImplant = event;
        }
    }

    public onNonexistenceMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.Nonexistence != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Nonexistence = event;

            }
            if (event === true) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Orthopedic = false;
                this.OrthopedicMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Hearing = false;
                this.HearingMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Chronic = false;
                this.ChronicMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Mental = false;
                this.MentalMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional = false;
                this.PsychicAndEmotionalMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Vision = false;
                this.VisionMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage = false;
                this.SpeechAndLanguageMedicalInfoDisabledGroup.ReadOnly = true;

                this._MedicalInformation.MedicalInfoDisabledGroup.Unclassified = false;
                this.UnclassifiedMedicalInfoDisabledGroup.ReadOnly = true;
            } else {
                this.OrthopedicMedicalInfoDisabledGroup.ReadOnly = false;
                this.HearingMedicalInfoDisabledGroup.ReadOnly = false;
                this.ChronicMedicalInfoDisabledGroup.ReadOnly = false;
                this.MentalMedicalInfoDisabledGroup.ReadOnly = false;
                this.PsychicAndEmotionalMedicalInfoDisabledGroup.ReadOnly = false;
                this.VisionMedicalInfoDisabledGroup.ReadOnly = false;
                this.SpeechAndLanguageMedicalInfoDisabledGroup.ReadOnly = false;
                this.UnclassifiedMedicalInfoDisabledGroup.ReadOnly = false;
            }
        }
    }

    public onOncologicFollowUpChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.OncologicFollowUp != event) {
            this._MedicalInformation.OncologicFollowUp = event;
        }
    }

    public onOrthopedicMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.Orthopedic != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Orthopedic = event;
            }
        }
    }

    public onOtherAllergiesMedicalInfoAllergiesChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoAllergies == null) {
                this._MedicalInformation.MedicalInfoAllergies = new MedicalInfoAllergies();
            }
            if (this._MedicalInformation.MedicalInfoAllergies.OtherAllergies != event) {
                this._MedicalInformation.MedicalInfoAllergies.OtherAllergies = event;
            }
        }
    }

    public onOtherChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Other != event) {
            this._MedicalInformation.Other = event;
        }
    }

    public onOtherInformationChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.OtherInformation != event) {
            this._MedicalInformation.OtherInformation = event;
        }
    }

    public onOtherMedicalInfoHabitsChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoHabits == null) {
                this._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
            }
            if (this._MedicalInformation.MedicalInfoHabits.Other != event) {
                this._MedicalInformation.MedicalInfoHabits.Other = event;
            }
        }
    }

    public onPregnancyChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Pregnancy != event) {
            this._MedicalInformation.Pregnancy = event;
        }
    }

    public onPsychicAndEmotionalMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional = event;
            }
        }
    }

    public onSpeechAndLanguageMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage = event;
            }
        }
    }

    public onStentChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Stent != event) {
            this._MedicalInformation.Stent = event;
        }
    }

    public onTeaMedicalInfoHabitsChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoHabits == null) {
                this._MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
            }
            if (this._MedicalInformation.MedicalInfoHabits.Tea != event) {
                this._MedicalInformation.MedicalInfoHabits.Tea = event;
            }
        }
    }

    public onTransplantationChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.Transplantation != event) {
            this._MedicalInformation.Transplantation = event;
        }
    }

    public onUnclassifiedMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.Unclassified != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Unclassified = event;
            }
        }
    }

    public onVascularDisorderChanged(event): void {
        if (this._MedicalInformation != null && this._MedicalInformation.VascularDisorder != event) {
            this._MedicalInformation.VascularDisorder = event;
        }
    }

    public onVisionMedicalInfoDisabledGroupChanged(event): void {
        if (this._MedicalInformation != null) {
            if (this._MedicalInformation.MedicalInfoDisabledGroup == null) {
                this._MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
            }
            if (this._MedicalInformation.MedicalInfoDisabledGroup.Vision != event) {
                this._MedicalInformation.MedicalInfoDisabledGroup.Vision = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ChronicDiseases, "Text", this.__ttObject, "ChronicDiseases");
        redirectProperty(this.Transplantation, "Text", this.__ttObject, "Transplantation");
        redirectProperty(this.Hemodialysis, "Text", this.__ttObject, "Hemodialysis");
        redirectProperty(this.OncologicFollowUp, "Text", this.__ttObject, "OncologicFollowUp");
        redirectProperty(this.Implant, "Text", this.__ttObject, "Implant");
        redirectProperty(this.OtherInformation, "Text", this.__ttObject, "OtherInformation");
        redirectProperty(this.HeartFailure, "Value", this.__ttObject, "HeartFailure");
        redirectProperty(this.Broken, "Value", this.__ttObject, "Broken");
        redirectProperty(this.Pregnancy, "Value", this.__ttObject, "Pregnancy");
        redirectProperty(this.HighRiskPregnancy, "Value", this.__ttObject, "HighRiskPregnancy");
        redirectProperty(this.Pandemic, "Value", this.__ttObject, "Pandemic");
        redirectProperty(this.Diabetes, "Value", this.__ttObject, "Diabetes");
        redirectProperty(this.Malignancy, "Value", this.__ttObject, "Malignancy");
        redirectProperty(this.MetalImplant, "Value", this.__ttObject, "MetalImplant");
        redirectProperty(this.VascularDisorder, "Value", this.__ttObject, "VascularDisorder");
        redirectProperty(this.Infection, "Value", this.__ttObject, "Infection");
        redirectProperty(this.Stent, "Value", this.__ttObject, "Stent");
        redirectProperty(this.Advers, "Value", this.__ttObject, "Advers");
        redirectProperty(this.CardiacPacemaker, "Value", this.__ttObject, "CardiacPacemaker");
        redirectProperty(this.Other, "Value", this.__ttObject, "Other");
        redirectProperty(this.OtherAllergiesMedicalInfoAllergies, "Text", this.__ttObject, "MedicalInfoAllergies.OtherAllergies");
        redirectProperty(this.DescriptionMedicalInfoHabits, "Text", this.__ttObject, "MedicalInfoHabits.Description");
        redirectProperty(this.CigaretteMedicalInfoHabits, "Value", this.__ttObject, "MedicalInfoHabits.Cigarette");
        redirectProperty(this.TeaMedicalInfoHabits, "Value", this.__ttObject, "MedicalInfoHabits.Tea");
        redirectProperty(this.CoffeeMedicalInfoHabits, "Value", this.__ttObject, "MedicalInfoHabits.Coffee");
        redirectProperty(this.OtherMedicalInfoHabits, "Value", this.__ttObject, "MedicalInfoHabits.Other");
        redirectProperty(this.AlcoholMedicalInfoHabits, "Value", this.__ttObject, "MedicalInfoHabits.Alcohol");
        redirectProperty(this.NonexistenceMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.Nonexistence");
        redirectProperty(this.ChronicMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.Chronic");
        redirectProperty(this.VisionMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.Vision");
        redirectProperty(this.HearingMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.Hearing");
        redirectProperty(this.MentalMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.Mental");
        redirectProperty(this.SpeechAndLanguageMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.SpeechAndLanguage");
        redirectProperty(this.OrthopedicMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.Orthopedic");
        redirectProperty(this.PsychicAndEmotionalMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.PsychicAndEmotional");
        redirectProperty(this.UnclassifiedMedicalInfoDisabledGroup, "Value", this.__ttObject, "MedicalInfoDisabledGroup.Unclassified");
        redirectProperty(this.HasAllergy, "Value", this.__ttObject, "HasAllergy");
        redirectProperty(this.HasContagiousDisease, "Value", this.__ttObject, "HasContagiousDisease");
        redirectProperty(this.ContagiousDisease, "Text", this.__ttObject, "ContagiousDisease");
    }

    public initFormControls(): void {

        this.Advers = new TTVisual.TTCheckBox();
        this.Advers.Value = false;
        this.Advers.Title = "Advers Etkisi Görülmüştür";
        this.Advers.Name = "Advers";
        this.Advers.TabIndex = 55;

        this.ContagiousDisease = new TTVisual.TTTextBox();
        this.ContagiousDisease.Multiline = true;
        this.ContagiousDisease.Name = "ContagiousDisease";
        this.ContagiousDisease.TabIndex = 54;

        this.labelHasContagiousDisease = new TTVisual.TTLabel();
        this.labelHasContagiousDisease.Text = i18n("M12105", "Bulaşıcı Hastalık ");
        this.labelHasContagiousDisease.Name = "labelHasContagiousDisease";
        this.labelHasContagiousDisease.TabIndex = 53;

        this.HasContagiousDisease = new TTVisual.TTEnumComboBox();
        this.HasContagiousDisease.DataTypeName = "VarYokGarantiEnum";
        this.HasContagiousDisease.Name = "HasContagiousDisease";
        this.HasContagiousDisease.TabIndex = 52;

        this.labelHasAllergy = new TTVisual.TTLabel();
        this.labelHasAllergy.Text = "Var/Yok";
        this.labelHasAllergy.Name = "labelHasAllergy";
        this.labelHasAllergy.TabIndex = 51;

        this.HasAllergy = new TTVisual.TTEnumComboBox();
        this.HasAllergy.DataTypeName = "VarYokGarantiEnum";
        this.HasAllergy.Name = "HasAllergy";
        this.HasAllergy.TabIndex = 50;

        this.CardiacPacemaker = new TTVisual.TTCheckBox();
        this.CardiacPacemaker.Value = false;
        this.CardiacPacemaker.Title = i18n("M17134", "Kalp Pili");
        this.CardiacPacemaker.Name = "CardiacPacemaker";
        this.CardiacPacemaker.TabIndex = 49;

        this.VascularDisorder = new TTVisual.TTCheckBox();
        this.VascularDisorder.Value = false;
        this.VascularDisorder.Title = i18n("M13232", "Dolaşım Bozukluğu");
        this.VascularDisorder.Name = "VascularDisorder";
        this.VascularDisorder.TabIndex = 48;

        this.Stent = new TTVisual.TTCheckBox();
        this.Stent.Value = false;
        this.Stent.Title = i18n("M22277", "Stend");
        this.Stent.Name = "Stent";
        this.Stent.TabIndex = 47;

        this.Other = new TTVisual.TTCheckBox();
        this.Other.Value = false;
        this.Other.Title = i18n("M12780", "Diğer");
        this.Other.Name = "Other";
        this.Other.TabIndex = 46;

        this.MetalImplant = new TTVisual.TTCheckBox();
        this.MetalImplant.Value = false;
        this.MetalImplant.Title = i18n("M18943", "Metal İmplant");
        this.MetalImplant.Name = "MetalImplant";
        this.MetalImplant.TabIndex = 45;

        this.Malignancy = new TTVisual.TTCheckBox();
        this.Malignancy.Value = false;
        this.Malignancy.Title = "Malignite";
        this.Malignancy.Name = "Malignancy";
        this.Malignancy.TabIndex = 44;

        this.Infection = new TTVisual.TTCheckBox();
        this.Infection.Value = false;
        this.Infection.Title = i18n("M13720", "Enfeksiyon");
        this.Infection.Name = "Infection";
        this.Infection.TabIndex = 43;

        this.HeartFailure = new TTVisual.TTCheckBox();
        this.HeartFailure.Value = false;
        this.HeartFailure.Title = i18n("M17136", "Kalp Yetmezliği");
        this.HeartFailure.Name = "HeartFailure";
        this.HeartFailure.TabIndex = 42;

        this.Diabetes = new TTVisual.TTCheckBox();
        this.Diabetes.Value = false;
        this.Diabetes.Title = i18n("M12978", "Diyabet");
        this.Diabetes.Name = "Diabetes";
        this.Diabetes.TabIndex = 41;

        this.Broken = new TTVisual.TTCheckBox();
        this.Broken.Value = false;
        this.Broken.Title = i18n("M17520", "Kırık");
        this.Broken.Name = "Broken";
        this.Broken.TabIndex = 40;

        this.ttgroupboxDisability = new TTVisual.TTGroupBox();
        this.ttgroupboxDisability.Text = i18n("M13727", "Engel Durumu");
        this.ttgroupboxDisability.Name = "ttgroupboxDisability";
        this.ttgroupboxDisability.TabIndex = 39;

        this.ChronicMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.ChronicMedicalInfoDisabledGroup.Value = false;
        this.ChronicMedicalInfoDisabledGroup.Title = i18n("M22422", "Süreğen(Kronik)");
        this.ChronicMedicalInfoDisabledGroup.Name = "ChronicMedicalInfoDisabledGroup";
        this.ChronicMedicalInfoDisabledGroup.TabIndex = 13;

        this.NonexistenceMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.NonexistenceMedicalInfoDisabledGroup.Value = false;
        this.NonexistenceMedicalInfoDisabledGroup.Title = i18n("M24703", "Yok");
        this.NonexistenceMedicalInfoDisabledGroup.Name = "NonexistenceMedicalInfoDisabledGroup";
        this.NonexistenceMedicalInfoDisabledGroup.TabIndex = 16;

        this.HearingMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.HearingMedicalInfoDisabledGroup.Value = false;
        this.HearingMedicalInfoDisabledGroup.Title = i18n("M16816", "İşitme");
        this.HearingMedicalInfoDisabledGroup.Name = "HearingMedicalInfoDisabledGroup";
        this.HearingMedicalInfoDisabledGroup.TabIndex = 14;

        this.MentalMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.MentalMedicalInfoDisabledGroup.Value = false;
        this.MentalMedicalInfoDisabledGroup.Title = i18n("M24771", "Zihinsel");
        this.MentalMedicalInfoDisabledGroup.Name = "MentalMedicalInfoDisabledGroup";
        this.MentalMedicalInfoDisabledGroup.TabIndex = 15;

        this.OrthopedicMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.OrthopedicMedicalInfoDisabledGroup.Value = false;
        this.OrthopedicMedicalInfoDisabledGroup.Title = i18n("M19803", "Ortopedik");
        this.OrthopedicMedicalInfoDisabledGroup.Name = "OrthopedicMedicalInfoDisabledGroup";
        this.OrthopedicMedicalInfoDisabledGroup.TabIndex = 17;

        this.PsychicAndEmotionalMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Value = false;
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Title = i18n("M21065", "Ruhsal ve Duygusal");
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Name = "PsychicAndEmotionalMedicalInfoDisabledGroup";
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.TabIndex = 18;

        this.SpeechAndLanguageMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Value = false;
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Title = i18n("M12854", "Dil ve Konuşma");
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Name = "SpeechAndLanguageMedicalInfoDisabledGroup";
        this.SpeechAndLanguageMedicalInfoDisabledGroup.TabIndex = 19;

        this.VisionMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.VisionMedicalInfoDisabledGroup.Value = false;
        this.VisionMedicalInfoDisabledGroup.Title = i18n("M14922", "Görme");
        this.VisionMedicalInfoDisabledGroup.Name = "VisionMedicalInfoDisabledGroup";
        this.VisionMedicalInfoDisabledGroup.TabIndex = 21;

        this.UnclassifiedMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.UnclassifiedMedicalInfoDisabledGroup.Value = false;
        this.UnclassifiedMedicalInfoDisabledGroup.Title = i18n("M21813", "Sınıflanmayan");
        this.UnclassifiedMedicalInfoDisabledGroup.Name = "UnclassifiedMedicalInfoDisabledGroup";
        this.UnclassifiedMedicalInfoDisabledGroup.TabIndex = 20;

        this.ttgroupboxHabits = new TTVisual.TTGroupBox();
        this.ttgroupboxHabits.Text = i18n("M10722", "Alışkanlıklar");
        this.ttgroupboxHabits.Name = "ttgroupboxHabits";
        this.ttgroupboxHabits.TabIndex = 38;

        this.CigaretteMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.CigaretteMedicalInfoHabits.Value = false;
        this.CigaretteMedicalInfoHabits.Title = i18n("M21832", "Sigara");
        this.CigaretteMedicalInfoHabits.Name = "CigaretteMedicalInfoHabits";
        this.CigaretteMedicalInfoHabits.TabIndex = 27;

        this.CigaretteUsageFrequencyMedicalInfoHabits = new TTVisual.TTObjectListBox();
        this.CigaretteUsageFrequencyMedicalInfoHabits.ListDefName = "SKRSSigaraKullanimiList";
        this.CigaretteUsageFrequencyMedicalInfoHabits.Name = "CigaretteUsageFrequencyMedicalInfoHabits";
        this.CigaretteUsageFrequencyMedicalInfoHabits.TabIndex = 33;
        //this.CigaretteUsageFrequencyMedicalInfoHabits.ReadOnly = true;

        this.labelDescriptionMedicalInfoHabits = new TTVisual.TTLabel();
        this.labelDescriptionMedicalInfoHabits.Text = i18n("M10469", "Açıklama");
        this.labelDescriptionMedicalInfoHabits.Name = "labelDescriptionMedicalInfoHabits";
        this.labelDescriptionMedicalInfoHabits.TabIndex = 30;

        this.OtherMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.OtherMedicalInfoHabits.Value = false;
        this.OtherMedicalInfoHabits.Title = i18n("M12780", "Diğer");
        this.OtherMedicalInfoHabits.Name = "OtherMedicalInfoHabits";
        this.OtherMedicalInfoHabits.TabIndex = 31;

        this.DescriptionMedicalInfoHabits = new TTVisual.TTTextBox();
        this.DescriptionMedicalInfoHabits.Multiline = true;
        this.DescriptionMedicalInfoHabits.Name = "DescriptionMedicalInfoHabits";
        this.DescriptionMedicalInfoHabits.TabIndex = 29;

        this.TeaMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.TeaMedicalInfoHabits.Value = false;
        this.TeaMedicalInfoHabits.Title = i18n("M12346", "Çay");
        this.TeaMedicalInfoHabits.Name = "TeaMedicalInfoHabits";
        this.TeaMedicalInfoHabits.TabIndex = 32;

        this.labelAlcoholUsageFrequencyMedicalInfoHabits = new TTVisual.TTLabel();
        this.labelAlcoholUsageFrequencyMedicalInfoHabits.Text = i18n("M10727", "Alkol Kullanım Sıklığı");
        this.labelAlcoholUsageFrequencyMedicalInfoHabits.Name = "labelAlcoholUsageFrequencyMedicalInfoHabits";
        this.labelAlcoholUsageFrequencyMedicalInfoHabits.TabIndex = 36;

        this.AlcoholMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.AlcoholMedicalInfoHabits.Value = false;
        this.AlcoholMedicalInfoHabits.Title = i18n("M10725", "Alkol");
        this.AlcoholMedicalInfoHabits.Name = "AlcoholMedicalInfoHabits";
        this.AlcoholMedicalInfoHabits.TabIndex = 26;

        this.AlcoholUsageFrequencyMedicalInfoHabits = new TTVisual.TTObjectListBox();
        this.AlcoholUsageFrequencyMedicalInfoHabits.ListDefName = "SKRSAlkolKullanimiList";
        this.AlcoholUsageFrequencyMedicalInfoHabits.Name = "AlcoholUsageFrequencyMedicalInfoHabits";
        this.AlcoholUsageFrequencyMedicalInfoHabits.TabIndex = 35;
        //this.AlcoholUsageFrequencyMedicalInfoHabits.ReadOnly = true;

        this.labelCigaretteUsageFrequencyMedicalInfoHabits = new TTVisual.TTLabel();
        this.labelCigaretteUsageFrequencyMedicalInfoHabits.Text = i18n("M21840", "Sigara Kullanım Sıklığı");
        this.labelCigaretteUsageFrequencyMedicalInfoHabits.Name = "labelCigaretteUsageFrequencyMedicalInfoHabits";
        this.labelCigaretteUsageFrequencyMedicalInfoHabits.TabIndex = 34;

        this.CoffeeMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.CoffeeMedicalInfoHabits.Value = false;
        this.CoffeeMedicalInfoHabits.Title = i18n("M17076", "Kahve");
        this.CoffeeMedicalInfoHabits.Name = "CoffeeMedicalInfoHabits";
        this.CoffeeMedicalInfoHabits.TabIndex = 28;

        this.ttgroupboxAllergies = new TTVisual.TTGroupBox();
        this.ttgroupboxAllergies.Text = i18n("M10688", "Alerjiler");
        this.ttgroupboxAllergies.Name = "ttgroupboxAllergies";
        this.ttgroupboxAllergies.TabIndex = 37;

        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies = new TTVisual.TTGrid();
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.Name = "MedicalInfoFoodAllergiesMedicalInfoFoodAllergies";
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.TabIndex = 25;
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.Height = "100px";
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.ShowFilterCombo = !this.ReadOnly;
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.FilterColumnName = "DietMaterialMedicalInfoFoodAllergies";
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.FilterLabel = "Gıda Maddesi";
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.Filter = { ListDefName: "DietMaterialListDefinition" };
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.AllowUserToAddRows = false;
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.AllowUserToDeleteRows = !this.ReadOnly;
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.DeleteButtonWidth = "15%";
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.ShowTotalNumberOfRows = false;
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.IsFilterLabelSingleLine = false;

        this.DietMaterialMedicalInfoFoodAllergies = new TTVisual.TTListBoxColumn();
        this.DietMaterialMedicalInfoFoodAllergies.ListDefName = "DietMaterialListDefinition";
        this.DietMaterialMedicalInfoFoodAllergies.DataMember = "DietMaterial";
        this.DietMaterialMedicalInfoFoodAllergies.DisplayIndex = 0;
        this.DietMaterialMedicalInfoFoodAllergies.HeaderText = i18n("M14780", "Gıda Maddesi");
        this.DietMaterialMedicalInfoFoodAllergies.Name = "DietMaterialMedicalInfoFoodAllergies";
        this.DietMaterialMedicalInfoFoodAllergies.Width = 300;
        //this.DietMaterialMedicalInfoFoodAllergies.ReadOnly = true;
        //this.DietMaterialMedicalInfoFoodAllergies.Enabled = false;

        //this.MedicalInfoDrugAllergiesList = new TTVisual.TTObjectListBox();
        //this.MedicalInfoDrugAllergiesList.ListDefName = "ActiveIngredientList";
        //this.MedicalInfoDrugAllergiesList.Name = "MedicalInfoDrugAllergy";

        //this.MedicalInfoFoodAllergiesList = new TTVisual.TTObjectListBox();
        //this.MedicalInfoFoodAllergiesList.ListDefName = "DietMaterialListDefinition";
        //this.MedicalInfoFoodAllergiesList.Name = "MedicalInfoFoodAllergy";

        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies = new TTVisual.TTGrid();
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.Name = "MedicalInfoDrugAllergiesMedicalInfoDrugAllergies";
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.TabIndex = 25;
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.Height = "100px";
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.ShowFilterCombo = !this.ReadOnly;
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.FilterColumnName = "ActiveIngredientMedicalInfoDrugAllergies";
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.FilterLabel = "İlaç Etken Maddesi";
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.Filter = { ListDefName: "ActiveIngredientList" };
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.AllowUserToAddRows = false;
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.AllowUserToDeleteRows = !this.ReadOnly;
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.DeleteButtonWidth = "15%";
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.ShowTotalNumberOfRows = false;
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.IsFilterLabelSingleLine = false;


        this.ActiveIngredientMedicalInfoDrugAllergies = new TTVisual.TTListBoxColumn();
        this.ActiveIngredientMedicalInfoDrugAllergies.ListDefName = "ActiveIngredientList";
        this.ActiveIngredientMedicalInfoDrugAllergies.DataMember = "ActiveIngredient";
        this.ActiveIngredientMedicalInfoDrugAllergies.DisplayIndex = 0;
        this.ActiveIngredientMedicalInfoDrugAllergies.HeaderText = i18n("M16321", "İlaç Etken Maddesi");
        this.ActiveIngredientMedicalInfoDrugAllergies.Name = "ActiveIngredientMedicalInfoDrugAllergies";
        this.ActiveIngredientMedicalInfoDrugAllergies.Width = 300;
        //this.ActiveIngredientMedicalInfoDrugAllergies.ReadOnly = true;
        //this.ActiveIngredientMedicalInfoDrugAllergies.Enabled = false;

        this.OtherAllergiesMedicalInfoAllergies = new TTVisual.TTTextBox();
        this.OtherAllergiesMedicalInfoAllergies.Multiline = true;
        this.OtherAllergiesMedicalInfoAllergies.Name = "OtherAllergiesMedicalInfoAllergies";
        this.OtherAllergiesMedicalInfoAllergies.TabIndex = 22;

        this.labelOtherAllergiesMedicalInfoAllergies = new TTVisual.TTLabel();
        this.labelOtherAllergiesMedicalInfoAllergies.Text = i18n("M12782", "Diğer Alerjiler");
        this.labelOtherAllergiesMedicalInfoAllergies.Name = "labelOtherAllergiesMedicalInfoAllergies";
        this.labelOtherAllergiesMedicalInfoAllergies.TabIndex = 23;

        this.Transplantation = new TTVisual.TTTextBox();
        this.Transplantation.Multiline = true;
        this.Transplantation.Name = "Transplantation";
        this.Transplantation.TabIndex = 11;

        this.OtherInformation = new TTVisual.TTTextBox();
        this.OtherInformation.Multiline = true;
        this.OtherInformation.Name = "OtherInformation";
        this.OtherInformation.TabIndex = 8;

        this.OncologicFollowUp = new TTVisual.TTTextBox();
        this.OncologicFollowUp.Multiline = true;
        this.OncologicFollowUp.Name = "OncologicFollowUp";
        this.OncologicFollowUp.TabIndex = 6;

        this.Implant = new TTVisual.TTTextBox();
        this.Implant.Multiline = true;
        this.Implant.Name = "Implant";
        this.Implant.TabIndex = 4;

        this.Hemodialysis = new TTVisual.TTTextBox();
        this.Hemodialysis.Multiline = true;
        this.Hemodialysis.Name = "Hemodialysis";
        this.Hemodialysis.TabIndex = 2;

        this.ChronicDiseases = new TTVisual.TTTextBox();
        this.ChronicDiseases.Multiline = true;
        this.ChronicDiseases.Name = "ChronicDiseases";
        this.ChronicDiseases.TabIndex = 0;

        this.labelTransplantation = new TTVisual.TTLabel();
        this.labelTransplantation.Text = i18n("M23579", "Transplantasyon");
        this.labelTransplantation.Name = "labelTransplantation";
        this.labelTransplantation.TabIndex = 12;

        this.Pregnancy = new TTVisual.TTCheckBox();
        this.Pregnancy.Value = false;
        this.Pregnancy.Title = "Gebelik";
        this.Pregnancy.Name = "Pregnancy";
        this.Pregnancy.TabIndex = 10;

        this.HighRiskPregnancy = new TTVisual.TTCheckBox();
        this.HighRiskPregnancy.Value = false;
        this.HighRiskPregnancy.Title = "Yüksek Riskli Gebelik";
        this.HighRiskPregnancy.Name = "HighRiskPregnancy";
        this.HighRiskPregnancy.TabIndex = 10;

        this.Pandemic = new TTVisual.TTCheckBox();
        this.Pandemic.Value = false;
        this.Pandemic.Title = "Pandemic Şüphesi";
        this.Pandemic.Name = "Pandemic";
        this.Pandemic.TabIndex = 45;

        this.labelOtherInformation = new TTVisual.TTLabel();
        this.labelOtherInformation.Text = i18n("M12780", "Diğer");
        this.labelOtherInformation.Name = "labelOtherInformation";
        this.labelOtherInformation.TabIndex = 9;

        this.labelOncologicFollowUp = new TTVisual.TTLabel();
        this.labelOncologicFollowUp.Text = i18n("M19719", "Onkolojik İzlem");
        this.labelOncologicFollowUp.Name = "labelOncologicFollowUp";
        this.labelOncologicFollowUp.TabIndex = 7;

        this.labelImplant = new TTVisual.TTLabel();
        this.labelImplant.Text = i18n("M16472", "İmplant");
        this.labelImplant.Name = "labelImplant";
        this.labelImplant.TabIndex = 5;

        this.labelHemodialysis = new TTVisual.TTLabel();
        this.labelHemodialysis.Text = i18n("M15629", "Hemodiyaliz");
        this.labelHemodialysis.Name = "labelHemodialysis";
        this.labelHemodialysis.TabIndex = 3;

        this.labelChronicDiseases = new TTVisual.TTLabel();
        this.labelChronicDiseases.Text = i18n("M17876", "Kronik Hastalıklar");
        this.labelChronicDiseases.Name = "labelChronicDiseases";
        this.labelChronicDiseases.TabIndex = 1;

        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesColumns = [this.DietMaterialMedicalInfoFoodAllergies];
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesColumns = [this.ActiveIngredientMedicalInfoDrugAllergies];
        this.ttgroupboxDisability.Controls = [this.ChronicMedicalInfoDisabledGroup, this.NonexistenceMedicalInfoDisabledGroup, this.HearingMedicalInfoDisabledGroup, this.MentalMedicalInfoDisabledGroup, this.OrthopedicMedicalInfoDisabledGroup, this.PsychicAndEmotionalMedicalInfoDisabledGroup, this.SpeechAndLanguageMedicalInfoDisabledGroup, this.VisionMedicalInfoDisabledGroup, this.UnclassifiedMedicalInfoDisabledGroup];
        this.ttgroupboxHabits.Controls = [this.CigaretteMedicalInfoHabits, this.CigaretteUsageFrequencyMedicalInfoHabits, this.labelDescriptionMedicalInfoHabits, this.OtherMedicalInfoHabits, this.DescriptionMedicalInfoHabits, this.TeaMedicalInfoHabits, this.labelAlcoholUsageFrequencyMedicalInfoHabits, this.AlcoholMedicalInfoHabits, this.AlcoholUsageFrequencyMedicalInfoHabits, this.labelCigaretteUsageFrequencyMedicalInfoHabits, this.CoffeeMedicalInfoHabits];
        this.ttgroupboxAllergies.Controls = [this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies, this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies, this.OtherAllergiesMedicalInfoAllergies, this.labelOtherAllergiesMedicalInfoAllergies, this.labelHasAllergy, this.HasAllergy];
        this.Controls = [this.Advers, this.HighRiskPregnancy,this.Pandemic, this.ContagiousDisease, this.Transplantation, this.OtherInformation, this.OncologicFollowUp, this.Implant, this.Hemodialysis, this.ChronicDiseases, this.labelHasContagiousDisease, this.HasContagiousDisease, this.CardiacPacemaker, this.VascularDisorder, this.Stent, this.Other, this.MetalImplant, this.Malignancy, this.Infection, this.HeartFailure, this.Diabetes, this.Broken, this.ttgroupboxDisability, this.ChronicMedicalInfoDisabledGroup, this.NonexistenceMedicalInfoDisabledGroup, this.HearingMedicalInfoDisabledGroup, this.MentalMedicalInfoDisabledGroup, this.OrthopedicMedicalInfoDisabledGroup, this.PsychicAndEmotionalMedicalInfoDisabledGroup, this.SpeechAndLanguageMedicalInfoDisabledGroup, this.VisionMedicalInfoDisabledGroup, this.UnclassifiedMedicalInfoDisabledGroup, this.ttgroupboxHabits, this.CigaretteMedicalInfoHabits, this.CigaretteUsageFrequencyMedicalInfoHabits, this.labelDescriptionMedicalInfoHabits, this.OtherMedicalInfoHabits, this.DescriptionMedicalInfoHabits, this.TeaMedicalInfoHabits, this.labelAlcoholUsageFrequencyMedicalInfoHabits, this.AlcoholMedicalInfoHabits, this.AlcoholUsageFrequencyMedicalInfoHabits, this.labelCigaretteUsageFrequencyMedicalInfoHabits, this.CoffeeMedicalInfoHabits, this.ttgroupboxAllergies, this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies, this.DietMaterialMedicalInfoFoodAllergies, this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies, this.ActiveIngredientMedicalInfoDrugAllergies, this.OtherAllergiesMedicalInfoAllergies, this.labelOtherAllergiesMedicalInfoAllergies, this.labelHasAllergy, this.HasAllergy, this.labelTransplantation, this.Pregnancy, this.labelOtherInformation, this.labelOncologicFollowUp, this.labelImplant, this.labelHemodialysis, this.labelChronicDiseases];

    }
}
