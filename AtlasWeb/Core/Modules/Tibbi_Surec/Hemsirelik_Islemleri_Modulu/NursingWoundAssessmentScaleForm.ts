//$54F942F9
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingWoundAssessmentScaleFormViewModel } from './NursingWoundAssessmentScaleFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingWoundAssessmentScale, BodyTypeEnum, MobilityEnum, NeurologicalDisordersEnum, ContinenceEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { EnumItem } from 'NebulaClient/Mscorlib/EnumItem';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

@Component({
    selector: 'NursingWoundAssessmentScaleForm',
    templateUrl: './NursingWoundAssessmentScaleForm.html',
    providers: [MessageService]
})
export class NursingWoundAssessmentScaleForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    AppetiteAnorexia: TTVisual.ITTCheckBox;
    AppetiteAverage: TTVisual.ITTCheckBox;
    AppetiteNg: TTVisual.ITTCheckBox;
    AppetiteOnlyLiquid: TTVisual.ITTCheckBox;
    AppetitePoor: TTVisual.ITTCheckBox;
    BodyType: TTVisual.ITTEnumComboBox;
    Continence: TTVisual.ITTEnumComboBox;
    DMAnemia: TTVisual.ITTCheckBox;
    DMCigaretteUsage: TTVisual.ITTCheckBox;
    DMHeartFailure: TTVisual.ITTCheckBox;
    DMPeripheralVascularDisease: TTVisual.ITTCheckBox;
    DMTerminalCachexia: TTVisual.ITTCheckBox;
    GradeDistribution: TTVisual.ITTEnumComboBox;
    NursingWoundTime: TTVisual.ITTEnumComboBox;
    labelApplicationDate: TTVisual.ITTLabel;
    labelAppetite: TTVisual.ITTLabel;
    labelBodyType: TTVisual.ITTLabel;
    labelContinence: TTVisual.ITTLabel;
    labelDM: TTVisual.ITTLabel;
    labelGradeDistribution: TTVisual.ITTLabel;
    labelMedicineUsage: TTVisual.ITTLabel;
    labelMobility: TTVisual.ITTLabel;
    labelNeurologicalDisorders: TTVisual.ITTLabel;
    labelSkinType: TTVisual.ITTLabel;
    labelSurgery: TTVisual.ITTLabel;
    MedicineUsage: TTVisual.ITTCheckBox;
    Mobility: TTVisual.ITTEnumComboBox;
    NeurologicalDisorders: TTVisual.ITTEnumComboBox;
    SkinColdAndMoist: TTVisual.ITTCheckBox;
    SkinDiscolored: TTVisual.ITTCheckBox;
    SkinDropsy: TTVisual.ITTCheckBox;
    SkinDry: TTVisual.ITTCheckBox;
    SkinHealthy: TTVisual.ITTCheckBox;
    SkinIntegrityBroken: TTVisual.ITTCheckBox;
    SkinThin: TTVisual.ITTCheckBox;
    SurgeryLongerThan2Hours: TTVisual.ITTCheckBox;
    SurgeryOrthopedic: TTVisual.ITTCheckBox;
    public nursingWoundAssessmentScaleFormViewModel: NursingWoundAssessmentScaleFormViewModel = new NursingWoundAssessmentScaleFormViewModel();
    public get _NursingWoundAssessmentScale(): NursingWoundAssessmentScale {
        return this._TTObject as NursingWoundAssessmentScale;
    }
    private NursingWoundAssessmentScaleForm_DocumentUrl: string = '/api/NursingWoundAssessmentScaleService/NursingWoundAssessmentScaleForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingWoundAssessmentScaleForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public get bodyTypes(): Array<EnumItem> {
        return BodyTypeEnum.Items;
    }

    public initViewModel(): void {
        this._TTObject = new NursingWoundAssessmentScale();
        this.nursingWoundAssessmentScaleFormViewModel = new NursingWoundAssessmentScaleFormViewModel();
        this._ViewModel = this.nursingWoundAssessmentScaleFormViewModel;
        this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale = this._TTObject as NursingWoundAssessmentScale;
    }

    protected loadViewModel() {
        let that = this;
        that.nursingWoundAssessmentScaleFormViewModel = this._ViewModel as NursingWoundAssessmentScaleFormViewModel;
        that._TTObject = this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale;
        if (this.nursingWoundAssessmentScaleFormViewModel == null)
            this.nursingWoundAssessmentScaleFormViewModel = new NursingWoundAssessmentScaleFormViewModel();
        if (this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale == null)
            this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale = new NursingWoundAssessmentScale();
        if (this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk == undefined) {
            this.initRisk();
        }
    }

    async ngOnInit() {
        await this.load();
    }

    private initRisk() {
        this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk = 0;
        if (this.nursingWoundAssessmentScaleFormViewModel.PatientSex == "KADIN")
            this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk += 2;
        else if (this.nursingWoundAssessmentScaleFormViewModel.PatientSex == "ERKEK")
            this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk += 1;

        if (this.nursingWoundAssessmentScaleFormViewModel.PatientAge >= 14 && this.nursingWoundAssessmentScaleFormViewModel.PatientAge <= 49)
            this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk += 1;
        else if (this.nursingWoundAssessmentScaleFormViewModel.PatientAge >= 50 && this.nursingWoundAssessmentScaleFormViewModel.PatientAge <= 64)
            this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk += 2;
        else if (this.nursingWoundAssessmentScaleFormViewModel.PatientAge >= 65 && this.nursingWoundAssessmentScaleFormViewModel.PatientAge <= 75)
            this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk += 3;
        else if (this.nursingWoundAssessmentScaleFormViewModel.PatientAge >= 75 && this.nursingWoundAssessmentScaleFormViewModel.PatientAge <= 80)
            this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk += 4;
        else if (this.nursingWoundAssessmentScaleFormViewModel.PatientAge >= 81)
            this.nursingWoundAssessmentScaleFormViewModel._NursingWoundAssessmentScale.TotalRisk += 5;
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.ApplicationDate != event) {
                this._NursingWoundAssessmentScale.ApplicationDate = event;
            }
        }
    }
    public onAppetiteAnorexiaChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.AppetiteAnorexia != event) {
                this._NursingWoundAssessmentScale.AppetiteAnorexia = event;
                if (this._NursingWoundAssessmentScale.AppetiteAnorexia)
                    this._NursingWoundAssessmentScale.TotalRisk += 3;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 3;
            }
        }
    }

    public onAppetiteAverageChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.AppetiteAverage != event) {
                this._NursingWoundAssessmentScale.AppetiteAverage = event;

                if (this._NursingWoundAssessmentScale.AppetiteAverage)
                    this._NursingWoundAssessmentScale.TotalRisk += 0;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 0;
            }
        }
    }

    public onAppetiteNgChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.AppetiteNg != event) {
                this._NursingWoundAssessmentScale.AppetiteNg = event;
                if (this._NursingWoundAssessmentScale.AppetiteNg)
                    this._NursingWoundAssessmentScale.TotalRisk += 2;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 2;
            }
        }
    }

    public onAppetiteOnlyLiquidChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.AppetiteOnlyLiquid != event) {
                this._NursingWoundAssessmentScale.AppetiteOnlyLiquid = event;
                if (this._NursingWoundAssessmentScale.AppetiteOnlyLiquid)
                    this._NursingWoundAssessmentScale.TotalRisk += 2;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 2;
            }
        }
    }

    public onAppetitePoorChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.AppetitePoor != event) {
                this._NursingWoundAssessmentScale.AppetitePoor = event;
                if (this._NursingWoundAssessmentScale.AppetitePoor)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
            }
        }
    }

    public onBodyTypeChanged(event): void {
        if (event != null) {
            let oldValue = this._NursingWoundAssessmentScale.BodyType;
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.BodyType != event) {
                this._NursingWoundAssessmentScale.BodyType = event;

                if (oldValue == BodyTypeEnum._Average.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 0;
                else if (oldValue == BodyTypeEnum._AboveAverage.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
                else if (oldValue == BodyTypeEnum._OverWeight.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 2;
                else if (oldValue == BodyTypeEnum._BelowAverage.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 3;

                if (event == BodyTypeEnum._Average.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 0;
                else if (event == BodyTypeEnum._AboveAverage.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else if (event == BodyTypeEnum._OverWeight.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 2;
                else if (event == BodyTypeEnum._BelowAverage.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 3;
            }
        }
    }

    public onContinenceChanged(event): void {
        if (event != null) {
            let oldValue = this._NursingWoundAssessmentScale.Continence;
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.Continence != event) {
                this._NursingWoundAssessmentScale.Continence = event;

                if (oldValue == ContinenceEnum._FullContinence.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 0;
                else if (oldValue == ContinenceEnum._ContinenceInCatheterAndStool.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 0;
                else if (oldValue == ContinenceEnum._OccasionalIncontinence.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
                else if (oldValue == ContinenceEnum._StoolIncontinence.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 2;
                else if (oldValue == ContinenceEnum._FullIncontinence.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 3;

                if (event == ContinenceEnum._FullContinence.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 0;
                else if (event == ContinenceEnum._ContinenceInCatheterAndStool.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 0;
                else if (event == ContinenceEnum._OccasionalIncontinence.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else if (event == ContinenceEnum._StoolIncontinence.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 2;
                else if (event == ContinenceEnum._FullIncontinence.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 3;
            }
        }
    }

    public onDMAnemiaChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.DMAnemia != event) {
                this._NursingWoundAssessmentScale.DMAnemia = event;
                if (this._NursingWoundAssessmentScale.DMAnemia)
                    this._NursingWoundAssessmentScale.TotalRisk += 2;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 2;
            }
        }
    }

    public onDMCigaretteUsageChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.DMCigaretteUsage != event) {
                this._NursingWoundAssessmentScale.DMCigaretteUsage = event;
                if (this._NursingWoundAssessmentScale.DMCigaretteUsage)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
            }
        }
    }

    public onDMHeartFailureChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.DMHeartFailure != event) {
                this._NursingWoundAssessmentScale.DMHeartFailure = event;
                if (this._NursingWoundAssessmentScale.DMHeartFailure)
                    this._NursingWoundAssessmentScale.TotalRisk += 5;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 5;
            }
        }
    }

    public onDMPeripheralVascularDiseaseChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.DMPeripheralVascularDisease != event) {
                this._NursingWoundAssessmentScale.DMPeripheralVascularDisease = event;
                if (this._NursingWoundAssessmentScale.DMPeripheralVascularDisease)
                    this._NursingWoundAssessmentScale.TotalRisk += 5;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 5;
            }
        }
    }

    public onDMTerminalCachexiaChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.DMTerminalCachexia != event) {
                this._NursingWoundAssessmentScale.DMTerminalCachexia = event;
                if (this._NursingWoundAssessmentScale.DMTerminalCachexia)
                    this._NursingWoundAssessmentScale.TotalRisk += 8;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 8;
            }
        }
    }

	public onGradeDistributionChanged(event): void {
        if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.GradeDistribution != event) {
            this._NursingWoundAssessmentScale.GradeDistribution = event;
        }
    }

    public onNursingWoundTimeChanged(event): void {
        if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.NursingWoundTime != event) {
            this._NursingWoundAssessmentScale.NursingWoundTime = event;
        }
    }

    public onMedicineUsageChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.MedicineUsage != event) {
                this._NursingWoundAssessmentScale.MedicineUsage = event;

                if (this._NursingWoundAssessmentScale.MedicineUsage)
                    this._NursingWoundAssessmentScale.TotalRisk += 4;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 4;
            }
        }
    }

    public onMobilityChanged(event): void {
        if (event != null) {
            let oldValue = this._NursingWoundAssessmentScale.Mobility;
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.Mobility != event) {
                this._NursingWoundAssessmentScale.Mobility = event;

                if (oldValue == MobilityEnum._FullMobility.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 0;
                else if (oldValue == MobilityEnum._Uneasy.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
                else if (oldValue == MobilityEnum._Apathic.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 2;
                else if (oldValue == MobilityEnum._LimitedMobility.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 3;
                else if (oldValue == MobilityEnum._InTraction.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 4;
                else if (oldValue == MobilityEnum._WheelchairBound.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 5;

                if (event == MobilityEnum._FullMobility.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 0;
                else if (event == MobilityEnum._Uneasy.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else if (event == MobilityEnum._Apathic.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 2;
                else if (event == MobilityEnum._LimitedMobility.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 3;
                else if (event == MobilityEnum._InTraction.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 4;
                else if (event == MobilityEnum._WheelchairBound.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 5;
            }
        }
    }

    public onNeurologicalDisordersChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.NeurologicalDisorders != event) {
                let oldValue = this._NursingWoundAssessmentScale.NeurologicalDisorders;
                this._NursingWoundAssessmentScale.NeurologicalDisorders = event;

                if (oldValue == NeurologicalDisordersEnum._Medium.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 4;
                else if (oldValue == NeurologicalDisordersEnum._MediumHeavy.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 5;
                else if (oldValue == NeurologicalDisordersEnum._Heavy.code)
                    this._NursingWoundAssessmentScale.TotalRisk -= 6;

                if (event == NeurologicalDisordersEnum._Medium.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 4;
                else if (event == NeurologicalDisordersEnum._MediumHeavy.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 5;
                else if (event == NeurologicalDisordersEnum._Heavy.code)
                    this._NursingWoundAssessmentScale.TotalRisk += 6;
            }
        }
    }

    public onSkinColdAndMoistChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SkinColdAndMoist != event) {
                this._NursingWoundAssessmentScale.SkinColdAndMoist = event;
                if (this._NursingWoundAssessmentScale.SkinColdAndMoist)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
            }
        }
    }

    public onSkinDiscoloredChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SkinDiscolored != event) {
                this._NursingWoundAssessmentScale.SkinDiscolored = event;
                if (this._NursingWoundAssessmentScale.SkinDiscolored)
                    this._NursingWoundAssessmentScale.TotalRisk += 2;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 2;
            }
        }
    }

    public onSkinDropsyChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SkinDropsy != event) {
                this._NursingWoundAssessmentScale.SkinDropsy = event;
                if (this._NursingWoundAssessmentScale.SkinDropsy)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
            }
        }
    }

    public onSkinDryChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SkinDry != event) {
                this._NursingWoundAssessmentScale.SkinDry = event;
                if (this._NursingWoundAssessmentScale.SkinDry)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
            }
        }
    }

    public onSkinHealthyChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SkinHealthy != event) {
                this._NursingWoundAssessmentScale.SkinHealthy = event;
            }
        }
    }

    public onSkinIntegrityBrokenChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SkinIntegrityBroken != event) {
                this._NursingWoundAssessmentScale.SkinIntegrityBroken = event;
                if (this._NursingWoundAssessmentScale.SkinIntegrityBroken)
                    this._NursingWoundAssessmentScale.TotalRisk += 3;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 3;
            }
        }
    }

    public onSkinThinChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SkinThin != event) {
                this._NursingWoundAssessmentScale.SkinThin = event;
                if (this._NursingWoundAssessmentScale.SkinThin)
                    this._NursingWoundAssessmentScale.TotalRisk += 1;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 1;
            }
        }
    }

    public onSurgeryLongerThan2HoursChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SurgeryLongerThan2Hours != event) {
                this._NursingWoundAssessmentScale.SurgeryLongerThan2Hours = event;
                if (this._NursingWoundAssessmentScale.SurgeryLongerThan2Hours)
                    this._NursingWoundAssessmentScale.TotalRisk += 5;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 5;
            }
        }
    }

    public onSurgeryOrthopedicChanged(event): void {
        if (event != null) {
            if (this._NursingWoundAssessmentScale != null && this._NursingWoundAssessmentScale.SurgeryOrthopedic != event) {
                this._NursingWoundAssessmentScale.SurgeryOrthopedic = event;
                if (this._NursingWoundAssessmentScale.SurgeryOrthopedic)
                    this._NursingWoundAssessmentScale.TotalRisk += 5;
                else
                    this._NursingWoundAssessmentScale.TotalRisk -= 5;
            }
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingWoundAssessmentScaleFormViewModel.ReadOnly = (this.nursingWoundAssessmentScaleFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingWoundAssessmentScaleFormViewModel.ReadOnly)
            this.DropStateButton(NursingWoundAssessmentScale.NursingWoundAssessmentScaleStates.Cancelled);

        this.ArrangeFormControl();
        super.ClientSidePreScript();
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);

        if(this._NursingWoundAssessmentScale.NursingWoundTime == null)
            throw new Exception("Bası Yaraso Oluşma Zamanı Seçilmeden işleme devan edemezsiniz.");
    }

    ArrangeFormControl() {
        this.ApplicationDate.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.ApplicationDate.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SkinHealthy.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SkinHealthy.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SkinThin.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SkinThin.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SkinDry.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SkinDry.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SkinDropsy.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SkinDropsy.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SkinColdAndMoist.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SkinColdAndMoist.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SkinDiscolored.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SkinDiscolored.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SkinIntegrityBroken.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SkinIntegrityBroken.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.AppetiteAverage.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.AppetiteAverage.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.AppetitePoor.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.AppetitePoor.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.AppetiteNg.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.AppetiteNg.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.AppetiteOnlyLiquid.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.AppetiteOnlyLiquid.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.AppetiteAnorexia.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.AppetiteAnorexia.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.MedicineUsage.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.MedicineUsage.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SurgeryOrthopedic.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SurgeryOrthopedic.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.SurgeryLongerThan2Hours.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.SurgeryLongerThan2Hours.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.DMTerminalCachexia.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.DMTerminalCachexia.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.DMHeartFailure.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.DMHeartFailure.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.DMPeripheralVascularDisease.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.DMPeripheralVascularDisease.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.DMAnemia.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.DMAnemia.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;

        this.DMCigaretteUsage.ReadOnly = this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
        this.DMCigaretteUsage.Enabled = !this.nursingWoundAssessmentScaleFormViewModel.ReadOnly;
    }

    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.SkinHealthy, "Value", this.__ttObject, "SkinHealthy");
        redirectProperty(this.SkinThin, "Value", this.__ttObject, "SkinThin");
        redirectProperty(this.SkinDry, "Value", this.__ttObject, "SkinDry");
        redirectProperty(this.SkinDropsy, "Value", this.__ttObject, "SkinDropsy");
        redirectProperty(this.SkinColdAndMoist, "Value", this.__ttObject, "SkinColdAndMoist");
        redirectProperty(this.SkinDiscolored, "Value", this.__ttObject, "SkinDiscolored");
        redirectProperty(this.SkinIntegrityBroken, "Value", this.__ttObject, "SkinIntegrityBroken");
        redirectProperty(this.AppetiteAverage, "Value", this.__ttObject, "AppetiteAverage");
        redirectProperty(this.AppetitePoor, "Value", this.__ttObject, "AppetitePoor");
        redirectProperty(this.AppetiteNg, "Value", this.__ttObject, "AppetiteNg");
        redirectProperty(this.AppetiteOnlyLiquid, "Value", this.__ttObject, "AppetiteOnlyLiquid");
        redirectProperty(this.AppetiteAnorexia, "Value", this.__ttObject, "AppetiteAnorexia");
        redirectProperty(this.DMHeartFailure, "Value", this.__ttObject, "DMHeartFailure");
        redirectProperty(this.DMPeripheralVascularDisease, "Value", this.__ttObject, "DMPeripheralVascularDisease");
        redirectProperty(this.DMAnemia, "Value", this.__ttObject, "DMAnemia");
        redirectProperty(this.DMCigaretteUsage, "Value", this.__ttObject, "DMCigaretteUsage");
        redirectProperty(this.SurgeryLongerThan2Hours, "Value", this.__ttObject, "SurgeryLongerThan2Hours");
        redirectProperty(this.BodyType, "Value", this.__ttObject, "BodyType");
        redirectProperty(this.Continence, "Value", this.__ttObject, "Continence");
        redirectProperty(this.Mobility, "Value", this.__ttObject, "Mobility");
        redirectProperty(this.DMTerminalCachexia, "Value", this.__ttObject, "DMTerminalCachexia");
        redirectProperty(this.NeurologicalDisorders, "Value", this.__ttObject, "NeurologicalDisorders");
        redirectProperty(this.MedicineUsage, "Value", this.__ttObject, "MedicineUsage");
        redirectProperty(this.SurgeryOrthopedic, "Value", this.__ttObject, "SurgeryOrthopedic");
        redirectProperty(this.GradeDistribution, "Value", this.__ttObject, "GradeDistribution");
        redirectProperty(this.NursingWoundTime, "Value", this.__ttObject, "NursingWoundTime");
    }

    public initFormControls(): void {
        this.labelGradeDistribution = new TTVisual.TTLabel();
        this.labelGradeDistribution.Text = "Yaranın Evresine Göre Grade Dağılımı";
        this.labelGradeDistribution.Name = "labelGradeDistribution";
        this.labelGradeDistribution.TabIndex = 38;

        this.GradeDistribution = new TTVisual.TTEnumComboBox();
        this.GradeDistribution.DataTypeName = "GradeDistributionEnum";
        this.GradeDistribution.Name = "GradeDistribution";
        this.GradeDistribution.TabIndex = 37;

        this.NursingWoundTime = new TTVisual.TTEnumComboBox();
        this.NursingWoundTime.DataTypeName = "PressureWoundTimeEnum";
        this.NursingWoundTime.Name = "NursingWoundTime";
        this.NursingWoundTime.TabIndex = 37;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = "Uygulama Zamanı";
        this.labelApplicationDate.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 36;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 35;

        this.labelSurgery = new TTVisual.TTLabel();
        this.labelSurgery.Text = i18n("M12151", "Büyük ameliyat / travma");
        this.labelSurgery.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurgery.Name = "labelSurgery";
        this.labelSurgery.TabIndex = 34;

        this.labelDM = new TTVisual.TTLabel();
        this.labelDM.Text = i18n("M13225", "Doku malnütrisyonu");
        this.labelDM.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDM.Name = "labelDM";
        this.labelDM.TabIndex = 33;

        this.labelAppetite = new TTVisual.TTLabel();
        this.labelAppetite.Text = i18n("M16960", "İştah");
        this.labelAppetite.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelAppetite.Name = "labelAppetite";
        this.labelAppetite.TabIndex = 32;

        this.labelMedicineUsage = new TTVisual.TTLabel();
        this.labelMedicineUsage.Text = i18n("M16389", "İlaçlar");
        this.labelMedicineUsage.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMedicineUsage.Name = "labelMedicineUsage";
        this.labelMedicineUsage.TabIndex = 31;

        this.labelSkinType = new TTVisual.TTLabel();
        this.labelSkinType.Text = i18n("M12257", "Cilt tipi görünen riskli");
        this.labelSkinType.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSkinType.Name = "labelSkinType";
        this.labelSkinType.TabIndex = 30;

        this.SurgeryLongerThan2Hours = new TTVisual.TTCheckBox();
        this.SurgeryLongerThan2Hours.Value = false;
        this.SurgeryLongerThan2Hours.Title = i18n("M10829", "Ameliyat masasında 2 saatten fazla kalma");
        this.SurgeryLongerThan2Hours.Name = "SurgeryLongerThan2Hours";
        this.SurgeryLongerThan2Hours.TabIndex = 29;

        this.SurgeryOrthopedic = new TTVisual.TTCheckBox();
        this.SurgeryOrthopedic.Value = false;
        this.SurgeryOrthopedic.Title = i18n("M19805", "Ortopedik, belden aşağı veya spina");
        this.SurgeryOrthopedic.Name = "SurgeryOrthopedic";
        this.SurgeryOrthopedic.TabIndex = 28;

        this.DMCigaretteUsage = new TTVisual.TTCheckBox();
        this.DMCigaretteUsage.Value = false;
        this.DMCigaretteUsage.Title = i18n("M21832", "Sigara");
        this.DMCigaretteUsage.Name = "DMCigaretteUsage";
        this.DMCigaretteUsage.TabIndex = 27;

        this.DMAnemia = new TTVisual.TTCheckBox();
        this.DMAnemia.Value = false;
        this.DMAnemia.Title = i18n("M10957", "Anemi");
        this.DMAnemia.Name = "DMAnemia";
        this.DMAnemia.TabIndex = 26;

        this.DMPeripheralVascularDisease = new TTVisual.TTCheckBox();
        this.DMPeripheralVascularDisease.Value = false;
        this.DMPeripheralVascularDisease.Title = i18n("M20301", "Periferik vasküler rahatsızlık");
        this.DMPeripheralVascularDisease.Name = "DMPeripheralVascularDisease";
        this.DMPeripheralVascularDisease.TabIndex = 25;

        this.DMHeartFailure = new TTVisual.TTCheckBox();
        this.DMHeartFailure.Value = false;
        this.DMHeartFailure.Title = i18n("M30905", "Kalp yetmezliği");
        this.DMHeartFailure.Name = "DMHeartFailure";
        this.DMHeartFailure.TabIndex = 24;

        this.DMTerminalCachexia = new TTVisual.TTCheckBox();
        this.DMTerminalCachexia.Value = false;
        this.DMTerminalCachexia.Title = i18n("M30904", "Terminal kaşeksi");
        this.DMTerminalCachexia.Name = "DMTerminalCachexia";
        this.DMTerminalCachexia.TabIndex = 23;

        this.AppetiteAnorexia = new TTVisual.TTCheckBox();
        this.AppetiteAnorexia.Value = false;
        this.AppetiteAnorexia.Title = i18n("M11052", "Anoraksi, oral alım yok");
        this.AppetiteAnorexia.Name = "AppetiteAnorexia";
        this.AppetiteAnorexia.TabIndex = 22;

        this.AppetiteOnlyLiquid = new TTVisual.TTCheckBox();
        this.AppetiteOnlyLiquid.Value = false;
        this.AppetiteOnlyLiquid.Title = i18n("M21109", "Sadece sıvı");
        this.AppetiteOnlyLiquid.Name = "AppetiteOnlyLiquid";
        this.AppetiteOnlyLiquid.TabIndex = 21;

        this.AppetiteNg = new TTVisual.TTCheckBox();
        this.AppetiteNg.Value = false;
        this.AppetiteNg.Title = i18n("M19453", "Ng");
        this.AppetiteNg.Name = "AppetiteNg";
        this.AppetiteNg.TabIndex = 20;

        this.AppetitePoor = new TTVisual.TTCheckBox();
        this.AppetitePoor.Value = false;
        this.AppetitePoor.Title = i18n("M24757", "Zayıf");
        this.AppetitePoor.Name = "AppetitePoor";
        this.AppetitePoor.TabIndex = 19;

        this.AppetiteAverage = new TTVisual.TTCheckBox();
        this.AppetiteAverage.Value = false;
        this.AppetiteAverage.Title = i18n("M19754", "Orta");
        this.AppetiteAverage.Name = "AppetiteAverage";
        this.AppetiteAverage.TabIndex = 18;

        this.MedicineUsage = new TTVisual.TTCheckBox();
        this.MedicineUsage.Value = false;
        this.MedicineUsage.Title = i18n("M21929", "Sitotoksik, yüksek doz steroid, antiinflamatuar");
        this.MedicineUsage.Name = "MedicineUsage";
        this.MedicineUsage.TabIndex = 17;

        this.SkinIntegrityBroken = new TTVisual.TTCheckBox();
        this.SkinIntegrityBroken.Value = false;
        this.SkinIntegrityBroken.Title = i18n("M12249", "Cilt bütünlüğü bozuk");
        this.SkinIntegrityBroken.Name = "SkinIntegrityBroken";
        this.SkinIntegrityBroken.TabIndex = 16;

        this.SkinDiscolored = new TTVisual.TTCheckBox();
        this.SkinDiscolored.Value = false;
        this.SkinDiscolored.Title = i18n("M21021", "Renk bozukluğu");
        this.SkinDiscolored.Name = "SkinDiscolored";
        this.SkinDiscolored.TabIndex = 15;

        this.SkinColdAndMoist = new TTVisual.TTCheckBox();
        this.SkinColdAndMoist.Value = false;
        this.SkinColdAndMoist.Title = i18n("M21998", "Soğuk ve nemli");
        this.SkinColdAndMoist.Name = "SkinColdAndMoist";
        this.SkinColdAndMoist.TabIndex = 14;

        this.SkinDropsy = new TTVisual.TTCheckBox();
        this.SkinDropsy.Value = false;
        this.SkinDropsy.Title = i18n("M19879", "Ödemli");
        this.SkinDropsy.Name = "SkinDropsy";
        this.SkinDropsy.TabIndex = 13;

        this.SkinDry = new TTVisual.TTCheckBox();
        this.SkinDry.Value = false;
        this.SkinDry.Title = i18n("M30903", "Kuru");
        this.SkinDry.Name = "SkinDry";
        this.SkinDry.TabIndex = 12;

        this.SkinThin = new TTVisual.TTCheckBox();
        this.SkinThin.Value = false;
        this.SkinThin.Title = i18n("M16481", "İnce çizilmeye yatkın");
        this.SkinThin.Name = "SkinThin";
        this.SkinThin.TabIndex = 11;

        this.SkinHealthy = new TTVisual.TTCheckBox();
        this.SkinHealthy.Value = false;
        this.SkinHealthy.Title = i18n("M21270", "Sağlıklı");
        this.SkinHealthy.Name = "SkinHealthy";
        this.SkinHealthy.TabIndex = 10;

        this.labelMobility = new TTVisual.TTLabel();
        this.labelMobility.Text = "Mobilite";
        this.labelMobility.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMobility.Name = "labelMobility";
        this.labelMobility.TabIndex = 9;

        this.Mobility = new TTVisual.TTEnumComboBox();
        this.Mobility.DataTypeName = "MobilityEnum";
        this.Mobility.Name = "Mobility";
        this.Mobility.TabIndex = 8;

        this.labelNeurologicalDisorders = new TTVisual.TTLabel();
        this.labelNeurologicalDisorders.Text = i18n("M19506", "Nörolojik bozukluklar");
        this.labelNeurologicalDisorders.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelNeurologicalDisorders.Name = "labelNeurologicalDisorders";
        this.labelNeurologicalDisorders.TabIndex = 7;

        this.NeurologicalDisorders = new TTVisual.TTEnumComboBox();
        this.NeurologicalDisorders.DataTypeName = "NeurologicalDisordersEnum";
        this.NeurologicalDisorders.Name = "NeurologicalDisorders";
        this.NeurologicalDisorders.TabIndex = 6;

        this.labelContinence = new TTVisual.TTLabel();
        this.labelContinence.Text = "Kontinans";
        this.labelContinence.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelContinence.Name = "labelContinence";
        this.labelContinence.TabIndex = 5;

        this.Continence = new TTVisual.TTEnumComboBox();
        this.Continence.DataTypeName = "ContinenceEnum";
        this.Continence.Name = "Continence";
        this.Continence.TabIndex = 4;

        this.labelBodyType = new TTVisual.TTLabel();
        this.labelBodyType.Text = i18n("M11998", "Boyuna oranla vücut yapısı / kilosu");
        this.labelBodyType.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBodyType.Name = "labelBodyType";
        this.labelBodyType.TabIndex = 3;

        this.BodyType = new TTVisual.TTEnumComboBox();
        this.BodyType.DataTypeName = "BodyTypeEnum";
        this.BodyType.Name = "BodyType";
        this.BodyType.TabIndex = 2;

        this.Controls = [this.labelGradeDistribution, this.labelApplicationDate, this.ApplicationDate, this.labelSurgery, this.labelDM, this.labelAppetite, this.labelMedicineUsage, this.labelSkinType, this.SurgeryLongerThan2Hours, this.SurgeryOrthopedic, this.DMCigaretteUsage, this.DMAnemia, this.DMPeripheralVascularDisease, this.DMHeartFailure, this.DMTerminalCachexia, this.AppetiteAnorexia, this.AppetiteOnlyLiquid, this.AppetiteNg, this.AppetitePoor, this.AppetiteAverage, this.MedicineUsage, this.SkinIntegrityBroken, this.SkinDiscolored, this.SkinColdAndMoist, this.SkinDropsy, this.SkinDry, this.SkinThin, this.SkinHealthy, this.labelMobility, this.Mobility, this.labelNeurologicalDisorders, this.NeurologicalDisorders, this.labelContinence, this.Continence, this.labelBodyType, this.BodyType];

    }


}


