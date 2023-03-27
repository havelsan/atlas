//$A6A4A856
import { Component, OnInit, NgZone } from '@angular/core';
import { SapScoreFormViewModel } from './SapScoreFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { SapsScore } from 'NebulaClient/Model/AtlasClientModel';
import { SapsBilirubinEnum, SapsBodyTemperatureEnum, SapsChronicIllnessEnum, SapsGlasgowEnum, SapsHCO3Enum, SapsHeartRateEnum, SapsInpatientTypeEnum, SapsPaO2_FIO2Enum, SapsPotassiumEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SapsSerumUreEnum, SapsSistolikEnum, SapsSodiumEnum, SapsUrineEnum, SapsWBC, SapsDurationOfStayBeforeIntensiveCare, SapsInpatientResourceBeforeIntensiveCare, SapsClinicCategoryEnum, SexEnum, YesNoEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SortByEnum } from 'NebulaClient/Utils/Enums/SortByEnum';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'SapScoreForm',
    templateUrl: './SapScoreForm.html',
    providers: [MessageService]
})
export class SapScoreForm extends BaseMultipleDataEntryForm implements OnInit {
    Age: TTVisual.ITTTextBox;
    Bilirubin: TTVisual.ITTEnumComboBox;
    BodyTemperature: TTVisual.ITTEnumComboBox;
    ChronicIllness: TTVisual.ITTEnumComboBox;
    ClinicCategory: TTVisual.ITTEnumComboBox;
    DurationOfStayBeforeIC: TTVisual.ITTEnumComboBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    Glasgow: TTVisual.ITTEnumComboBox;
    HCO3: TTVisual.ITTEnumComboBox;
    HeartRate: TTVisual.ITTEnumComboBox;
    InpatientResourceBeforeIC: TTVisual.ITTEnumComboBox;
    InpatientType: TTVisual.ITTEnumComboBox;
    labelBilirubin: TTVisual.ITTLabel;
    labelBodyTemperature: TTVisual.ITTLabel;
    labelChronicIllness: TTVisual.ITTLabel;
    labelClinicCategory: TTVisual.ITTLabel;
    labelDurationOfStayBeforeIC: TTVisual.ITTLabel;
    labelEntryDate: TTVisual.ITTLabel;
    labelGlasgow: TTVisual.ITTLabel;
    labelHCO3: TTVisual.ITTLabel;
    labelHeartRate: TTVisual.ITTLabel;
    labelInpatientResourceBeforeIC: TTVisual.ITTLabel;
    labelInpatientType: TTVisual.ITTLabel;
    labelPaO2_FIO2: TTVisual.ITTLabel;
    labelPatientAge: TTVisual.ITTLabel;
    labelPatientSex: TTVisual.ITTLabel;
    labelPoising: TTVisual.ITTLabel;
    labelPotassium: TTVisual.ITTLabel;
    labelSapsIIPoint: TTVisual.ITTLabel;
    labelSapsIIPointDetail: TTVisual.ITTLabel;
    labelSerumUre: TTVisual.ITTLabel;
    labelSistolikBloodPressure: TTVisual.ITTLabel;
    labelSodium: TTVisual.ITTLabel;
    labelUrine: TTVisual.ITTLabel;
    labelWaitingMortalite: TTVisual.ITTLabel;
    labelWBC: TTVisual.ITTLabel;
    P_AgeForSap: TTVisual.ITTTextBox;
    P_AgeForSapDetail: TTVisual.ITTTextBox;
    P_Bilirubin: TTVisual.ITTTextBox;
    P_BodyTemperature: TTVisual.ITTTextBox;
    P_ChronicIllness: TTVisual.ITTTextBox;
    P_ClinicCategory: TTVisual.ITTTextBox;
    P_DurationOfStayBeforeIC: TTVisual.ITTTextBox;
    P_Glasgow: TTVisual.ITTTextBox;
    P_HCO3: TTVisual.ITTTextBox;
    P_HeartRate: TTVisual.ITTTextBox;
    P_InpatientResourceBeforeIC: TTVisual.ITTTextBox;
    P_InpatientType: TTVisual.ITTTextBox;
    P_PaO2_FIO2: TTVisual.ITTTextBox;
    P_Poising: TTVisual.ITTTextBox;
    P_Potassium: TTVisual.ITTTextBox;
    P_SerumUre: TTVisual.ITTTextBox;
    P_Sex: TTVisual.ITTTextBox;
    P_SistolikBloodPressure: TTVisual.ITTTextBox;
    P_Sodium: TTVisual.ITTTextBox;
    P_Urine: TTVisual.ITTTextBox;
    P_WBC: TTVisual.ITTTextBox;
    PaO2_FIO2: TTVisual.ITTEnumComboBox;
    PatientAge: TTVisual.ITTTextBox;
    PatientSex: TTVisual.ITTEnumComboBox;
    Poising: TTVisual.ITTEnumComboBox;
    Potassium: TTVisual.ITTEnumComboBox;
    SapsIIPoint: TTVisual.ITTTextBox;
    SapsIIPointDetail: TTVisual.ITTTextBox;
    SerumUre: TTVisual.ITTEnumComboBox;
    SistolikBloodPressure: TTVisual.ITTEnumComboBox;
    Sodium: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    Urine: TTVisual.ITTEnumComboBox;
    WaitingMortalite: TTVisual.ITTTextBox;
    WBC: TTVisual.ITTEnumComboBox;
    public sapScoreFormViewModel: SapScoreFormViewModel = new SapScoreFormViewModel();
    public get _SapsScore(): SapsScore {
        return this._TTObject as SapsScore;
    }
    private SapScoreForm_DocumentUrl: string = '/api/SapsScoreService/SapScoreForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SapScoreForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SapsScore();
        this.sapScoreFormViewModel = new SapScoreFormViewModel();
        this._ViewModel = this.sapScoreFormViewModel;
        this.sapScoreFormViewModel._SapsScore = this._TTObject as SapsScore;
    }

    protected loadViewModel() {
        let that = this;
        that.sapScoreFormViewModel = this._ViewModel as SapScoreFormViewModel;
        that._TTObject = this.sapScoreFormViewModel._SapsScore;
        if (this.sapScoreFormViewModel == null)
            this.sapScoreFormViewModel = new SapScoreFormViewModel();
        if (this.sapScoreFormViewModel._SapsScore == null)
            this.sapScoreFormViewModel._SapsScore = new SapsScore();

    }

    async ngOnInit() {
        let that = this;
        await this.load(SapScoreFormViewModel);

    }
    protected async PreScript() {
        this.SetAllSAPPoints();
        this.SetAllSAPDetailPoints();
        this.CalculateSAPPoint();
        this.CalculateSAPDetailPoint();
        this.CalculateWaitingMortalite();
    }
    // SAP için Puan
    //Yatış Şekli
    protected SetP_InpatientTypeForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsInpatientTypeEnum.UnPlannedSurgery)
                point = 8;
            else if (value == SapsInpatientTypeEnum.Medical)
                point = 6;
            else if (value == SapsInpatientTypeEnum.PlannedSurgery)
                point = 0;

        }
        this.P_InpatientType.Text = point.toString();
    }

    //Kronik Hastalık
    protected SetP_ChronicIllnessForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsChronicIllnessEnum.No)
                point = 0;
            else if (value == SapsChronicIllnessEnum.MetastatikCanser)
                point = 9;
            else if (value == SapsChronicIllnessEnum.HematolojikMalignite)
                point = 10;
            else if (value == SapsChronicIllnessEnum.AIDS)
                point = 17;

        }
        this.P_ChronicIllness.Text = point.toString();
    }

    // Yaş
    protected SetP_AgeForSap(value: string) {
        let point = 0;
        if (value != null) {
            let age = parseFloat(value);
            if (age < 40)
                point = 0;
            else if (age < 60)
                point = 7;
            else if (age < 70)
                point = 12;
            else if (age < 75)
                point = 15;
            else if (age < 80)
                point = 16;
            else if (age >= 80)
                point = 18;
        }
        this.P_AgeForSap.Text = point.toString();
    }
    //Glaskow
    protected SetP_GlasgowForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsGlasgowEnum.Glasgow6)
                point = 26;
            else if (value == SapsGlasgowEnum.Glasgow6_8)
                point = 13;
            else if (value == SapsGlasgowEnum.Glasgow9_10)
                point = 7;
            else if (value == SapsGlasgowEnum.Glasgow11_13)
                point = 5;
            else if (value == SapsGlasgowEnum.Glasgow14_15)
                point = 0;
        }
        this.P_Glasgow.Text = point.toString();
    }

    //Sistolik Kan Basıncı
    protected SetP_SistolikBloodPressureForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsSistolikEnum.SistolikUnder70mmHg)
                point = 13;
            else if (value == SapsSistolikEnum.Sistolik70_99mmHg)
                point = 5;
            else if (value == SapsSistolikEnum.Sistolik100_199mmHg)
                point = 0;
            else if (value == SapsSistolikEnum.Sistolik200mmHg)
                point = 2;
        }
        this.P_SistolikBloodPressure.Text = point.toString();
    }

    //Kalp Hızı
    protected SetP_HeartRateForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsHeartRateEnum.HeartRateUnder40)
                point = 11;
            else if (value == SapsHeartRateEnum.HeartRate40_69)
                point = 2;
            else if (value == SapsHeartRateEnum.HeartRate70_119)
                point = 0;
            else if (value == SapsHeartRateEnum.HeartRate120_159)
                point = 4;
            else if (value == SapsHeartRateEnum.HeartRate160)
                point = 7;
        }
        this.P_HeartRate.Text = point.toString();
    }

    //Vücut Isısı
    protected SetP_BodyTemperatureForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsBodyTemperatureEnum.BodyTempUnder39C)
                point = 0;
            else if (value == SapsBodyTemperatureEnum.BodyTempOver39C)
                point = 3;
            else if (value == SapsBodyTemperatureEnum.BodyTempUnder102F)
                point = 0;
            else if (value == SapsBodyTemperatureEnum.BodyTempOver102F)
                point = 3;
        }
        this.P_BodyTemperature.Text = point.toString();
    }

    //MV veya CPAP var ise PaO2/FIO2(mmHg)
    protected SetP_PaO2_FIO2ForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsPaO2_FIO2Enum.PaO2_FIO2Under100)
                point = 11;
            else if (value == SapsPaO2_FIO2Enum.PaO2_FIO2100_199)
                point = 9;
            else if (value == SapsPaO2_FIO2Enum.PaO2_FIO2Over199)
                point = 6;

        }
        this.P_PaO2_FIO2.Text = point.toString();
    }

    //İdrar Çıkışı
    protected SetP_UrineForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsUrineEnum.UrineUnder05LIn24h)
                point = 11;
            else if (value == SapsUrineEnum.Urine05_0999LIn24h)
                point = 4;
            else if (value == SapsUrineEnum.UrineOver1LIn24h)
                point = 0;
        }
        this.P_Urine.Text = point.toString();
    }

    //Serum Ure veya BUN
    protected SetP_SerumUreForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsSerumUreEnum.Under10mmol_L)
                point = 0;
            else if (value == SapsSerumUreEnum.Between10_299mmol_L)
                point = 6;
            else if (value == SapsSerumUreEnum.Over30mmol_L)
                point = 10;
            else if (value == SapsSerumUreEnum.BUNUnder28mg_dL)
                point = 0;
            else if (value == SapsSerumUreEnum.BUN28_83mg_dL)
                point = 6;
            else if (value == SapsSerumUreEnum.BUNOver84mg_dL)
                point = 10;
            else if (value == SapsSerumUreEnum.SerumUreUnder06g_L)
                point = 0;
            else if (value == SapsSerumUreEnum.SerumUre06_179g_L)
                point = 6;
            else if (value == SapsSerumUreEnum.SerumUreOver180g_L)
                point = 10;

        }
        this.P_SerumUre.Text = point.toString();
    }

    //WBC
    protected SetP_WBCForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsWBC.WBCUnder1000mm3)
                point = 12;
            else if (value == SapsWBC.WBC1000_19000mm3)
                point = 0;
            else if (value == SapsWBC.WBCOver20000mm3)
                point = 3;
        }
        this.P_WBC.Text = point.toString();
    }

    //Sodyum
    protected SetP_SodiumForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsSodiumEnum.SodiumOver145mEq_l)
                point = 1;
            else if (value == SapsSodiumEnum.Sodium125_144mEq_l)
                point = 0;
            else if (value == SapsSodiumEnum.SodiumUnder125mEq_l)
                point = 5;
        }
        this.P_Sodium.Text = point.toString();
    }

    //Potasyum
    protected SetP_PotassiumForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsPotassiumEnum.PotassiumUnder3mEq_l)
                point = 3;
            else if (value == SapsPotassiumEnum.Potassium3_49mEq_l)
                point = 0;
            else if (value == SapsPotassiumEnum.PotassiumOver5mEq_l)
                point = 3;
        }
        this.P_Potassium.Text = point.toString();
    }

    //HCO3
    protected SetP_HCO3ForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsHCO3Enum.HCO3Under15mEq_l)
                point = 3;
            else if (value == SapsHCO3Enum.HCO3_15_19mEq_l)
                point = 0;
            else if (value == SapsHCO3Enum.HCO3Over20mEq_l)
                point = 3;
        }
        this.P_HCO3.Text = point.toString();
    }

    //Bilirubin
    protected SetP_BilirubinForSap(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsBilirubinEnum.BilirubinUnder684micromol_l)
                point = 0;
            else if (value == SapsBilirubinEnum.Bilirubin684_1025micromol_l)
                point = 4;
            else if (value == SapsBilirubinEnum.BilirubinOver1026micromol_l)
                point = 9;
            else if (value == SapsBilirubinEnum.BilirubinUnder4mg_dL)
                point = 0;
            else if (value == SapsBilirubinEnum.Bilirubin4_59mg_dL)
                point = 4;
            else if (value == SapsBilirubinEnum.BilirubinOver6mg_dL)
                point = 9;
        }
        this.P_Bilirubin.Text = point.toString();
    }

    //------
    // SAPDetail için Puan
    // Yaş
    protected SetP_AgeForSapDetail(value: string) {
        let point = 0;
        if (value != null) {
            let age = parseFloat(value);
            if (age <= 40)
                point = 0;
            else if (age < 60)
                point = 0.1639;
            else if (age < 70)
                point = 0.2739;
            else if (age < 80)
                point = 0.3690;
            else if (age >= 80)
                point = 0.6645;
        }
        this.P_AgeForSapDetail.Text = point.toString();
    }

    // Cinsiyet
    protected SetP_SexForSapDetail(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SexEnum.Male)
                point = 0.2083;
        }
        this.P_Sex.Text = point.toString();
    }

    //Yoğun Bakım Öncesi XXXXXXde Kalış Süresi
    protected SetP_DurationOfStayBeforeICForSapDetail(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsDurationOfStayBeforeIntensiveCare.Under24hour)
                point = 0;
            else if (value == SapsDurationOfStayBeforeIntensiveCare.OneDay)
                point = 0.0986;
            else if (value == SapsDurationOfStayBeforeIntensiveCare.TwoDay)
                point = 0.1944;
            else if (value == SapsDurationOfStayBeforeIntensiveCare.ThreeNinedaye)
                point = 0.5284;
            else if (value == SapsDurationOfStayBeforeIntensiveCare.MoreThanNineDay)
                point = 0.9323;

        }
        this.P_DurationOfStayBeforeIC.Text = point.toString();
    }

    //Yoğun bakım öncesi hastanın yattığı bölüm
    protected SetP_InpatientResourceBeforeICForSapDetail(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsInpatientResourceBeforeIntensiveCare.Emergency)
                point = 0;
            else if (value == SapsInpatientResourceBeforeIntensiveCare.InHospital)
                point = 0.2606;
            else if (value == SapsInpatientResourceBeforeIntensiveCare.OtherHospital)
                point = 0.3381;

        }
        this.P_InpatientResourceBeforeIC.Text = point.toString();
    }

    //Klinik Kategori
    protected SetP_ClinicCategoryForSapDetail(value: number) {
        let point = 0;
        if (value != null) {
            if (value == SapsClinicCategoryEnum.Inpatient)
                point = 0.6555;
            else if (value == SapsClinicCategoryEnum.Other)
                point = 0;

        }
        this.P_ClinicCategory.Text = point.toString();
    }

    //Zehirlenme
    protected SetP_PoisingForSapDetail(value: number) {
        let point = 0;
        if (value != null) {
            if (value == YesNoEnum.Yes)
                point = 0;
            else if (value == YesNoEnum.No)
                point = 1.6693;

        }
        this.P_Poising.Text = point.toString();
    }


    protected SetAllSAPPoints() {
        // SAP için Puan
        //Yatış Şekli
        this.SetP_InpatientTypeForSap(this.InpatientType["Value"]);

        //Kronik Hastalık
        this.SetP_ChronicIllnessForSap(this.ChronicIllness["Value"]);

        // Yaş
        this.SetP_AgeForSap(this.PatientAge.Text);
        //Glaskow
        this.SetP_GlasgowForSap(this.Glasgow["Value"]);

        //Sistolik Kan Basıncı
        this.SetP_SistolikBloodPressureForSap(this.SistolikBloodPressure["Value"]);

        //Kalp Hızı
        this.SetP_HeartRateForSap(this.HeartRate["Value"]);

        //Vücut Isısı
        this.SetP_BodyTemperatureForSap(this.BodyTemperature["Value"]);

        //MV veya CPAP var ise PaO2/FIO2(mmHg)
        this.SetP_PaO2_FIO2ForSap(this.PaO2_FIO2["Value"]);
        //İdrar Çıkışı
        this.SetP_UrineForSap(this.Urine["Value"]);

        //Serum Ure veya BUN
        this.SetP_SerumUreForSap(this.SerumUre["Value"]);

        //WBC
        this.SetP_WBCForSap(this.WBC["Value"]);

        //Sodyum
        this.SetP_SodiumForSap(this.Sodium["Value"]);

        //Potasyum
        this.SetP_PotassiumForSap(this.Potassium["Value"]);

        //HCO3
        this.SetP_HCO3ForSap(this.HCO3["Value"]);

        //Bilirubin
        this.SetP_BilirubinForSap(this.Bilirubin["Value"]);
    }

    protected SetAllSAPDetailPoints() {
        // SAPDetail için Puan
        // Yaş
        this.SetP_AgeForSapDetail(this.Age.Text);

        // Cinsiyet
        this.SetP_SexForSapDetail(this.PatientSex["Value"]);

        //Yoğun Bakım Öncesi XXXXXXde Kalış Süresi
        this.SetP_DurationOfStayBeforeICForSapDetail(this.DurationOfStayBeforeIC["Value"]);

        //Yoğun bakım öncesi hastanın yattığı bölüm
        this.SetP_InpatientResourceBeforeICForSapDetail(this.InpatientResourceBeforeIC["Value"]);

        //Klinik Kategori
        this.SetP_ClinicCategoryForSapDetail(this.ClinicCategory["Value"]);

        //Zehirlenme
        this.SetP_PoisingForSapDetail(this.Poising["Value"]);
    }


    protected CalculateSAPPoint() {
        // SAP için Puan
        let SapPoint = 0;
        //Yatış Şekli
        if (this.P_InpatientType.Text == null)
            this.P_InpatientType.Text = "0";
        SapPoint += parseFloat(this.P_InpatientType.Text);

        //Kronik Hastalık
        if (this.P_ChronicIllness.Text == null)
            this.P_ChronicIllness.Text = "0";
        SapPoint += parseFloat(this.P_ChronicIllness.Text);
        // Yaş
        if (this.P_AgeForSap.Text == null)
            this.P_AgeForSap.Text = "0";
        SapPoint += parseFloat(this.P_AgeForSap.Text);
        //Glaskow
        if (this.P_Glasgow.Text == null)
            this.P_Glasgow.Text = "0";
        SapPoint += parseFloat(this.P_Glasgow.Text);

        //Sistolik Kan Basıncı
        if (this.P_SistolikBloodPressure.Text == null)
            this.P_SistolikBloodPressure.Text = "0";
        SapPoint += parseFloat(this.P_SistolikBloodPressure.Text);

        //Kalp Hızı
        if (this.P_HeartRate.Text == null)
            this.P_HeartRate.Text = "0";
        SapPoint += parseFloat(this.P_HeartRate.Text);

        //Vücut Isısı
        if (this.P_BodyTemperature.Text == null)
            this.P_BodyTemperature.Text = "0";
        SapPoint += parseFloat(this.P_BodyTemperature.Text);

        //MV veya CPAP var ise PaO2/FIO2(mmHg)
        if (this.P_PaO2_FIO2.Text == null)
            this.P_PaO2_FIO2.Text = "0";
        SapPoint += parseFloat(this.P_PaO2_FIO2.Text);
        //İdrar Çıkışı
        if (this.P_Urine.Text == null)
            this.P_Urine.Text = "0";
        SapPoint += parseFloat(this.P_Urine.Text);

        //Serum Ure veya BUN
        if (this.P_SerumUre.Text == null)
            this.P_SerumUre.Text = "0";
        SapPoint += parseFloat(this.P_SerumUre.Text);

        //WBC
        if (this.P_WBC.Text == null)
            this.P_WBC.Text = "0";
        SapPoint += parseFloat(this.P_WBC.Text);

        //Sodyum
        if (this.P_Sodium.Text == null)
            this.P_Sodium.Text = "0";
        SapPoint += parseFloat(this.P_Sodium.Text);

        //Potasyum
        if (this.P_Potassium.Text == null)
            this.P_Potassium.Text = "0";
        SapPoint += parseFloat(this.P_Potassium.Text);

        //HCO3
        if (this.P_HCO3.Text == null)
            this.P_HCO3.Text = "0";
        SapPoint += parseFloat(this.P_HCO3.Text);

        //Bilirubin
        if (this.P_Bilirubin.Text == null)
            this.P_Bilirubin.Text = "0";
        SapPoint += parseFloat(this.P_Bilirubin.Text);
        this._SapsScore.SapsIIPoint = SapPoint;
    }

    protected CalculateSAPDetailPoint() {
        // SAPDetail için Puan
        let SapPointDetail = 0;
        // Yaş
        if (this.P_AgeForSapDetail.Text == null)
            this.P_AgeForSapDetail.Text = "0";
        SapPointDetail += parseFloat(this.P_AgeForSapDetail.Text);

        // Cinsiyet
        if (this.P_Sex.Text == null)
            this.P_Sex.Text = "0";
        SapPointDetail += parseFloat(this.P_Sex.Text);

        //Yoğun Bakım Öncesi XXXXXXde Kalış Süresi
        if (this.P_DurationOfStayBeforeIC.Text == null)
            this.P_DurationOfStayBeforeIC.Text = "0";
        SapPointDetail += parseFloat(this.P_DurationOfStayBeforeIC.Text);

        //Yoğun bakım öncesi hastanın yattığı bölüm

        if (this.P_InpatientResourceBeforeIC.Text == null)
            this.P_InpatientResourceBeforeIC.Text = "0";
        SapPointDetail += parseFloat(this.P_InpatientResourceBeforeIC.Text);

        //Klinik Kategori
        if (this.P_ClinicCategory.Text == null)
            this.P_ClinicCategory.Text = "0";
        SapPointDetail += parseFloat(this.P_ClinicCategory.Text);

        //Zehirlenme
        if (this.P_Poising.Text == null)
            this.P_Poising.Text = "0";
        SapPointDetail += parseFloat(this.P_Poising.Text);

        let SapPoint = this._SapsScore.SapsIIPoint != null ? this._SapsScore.SapsIIPoint : 0;
        this._SapsScore.SapsIIPointDetail = Math.Round((0.0742 * SapPoint + SapPointDetail), 3);
    }

    protected CalculateWaitingMortalite() {
        let SapPointDetail = this._SapsScore.SapsIIPointDetail != null ? this._SapsScore.SapsIIPointDetail : 0;
        let Logit: number = -14.4761 + 0.0844 * SapPointDetail + 6.6158 * Math.log(SapPointDetail + 1);
        let eLogit = Math.exp(Logit);
        let mortalite = (eLogit / (1 + eLogit));
        this._SapsScore.WaitingMortalite = Math.Round((100 * mortalite), 2); //parseFloat(this.Fmt(100 * mortalite));
        //;
    }

    protected Fmt(x) { // http://xxxxxx.com  sitesinden çalındı
        let v;
        if (x >= 0) { v = '' + (x + 0.05); } else { v = '' + (x - 0.05); }
        return v.substring(0, v.indexOf('.') + 2);
    }


    public onAgeChanged(event): void {
        if (event != null) {
            if (this._SapsScore != null && this._SapsScore.PatientAge != event) {
                this._SapsScore.PatientAge = event;
            }
        }
    }

    public onBilirubinChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.Bilirubin != event) {
            this._SapsScore.Bilirubin = event;
            this.SetP_BilirubinForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onBodyTemperatureChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.BodyTemperature != event) {
            this._SapsScore.BodyTemperature = event;
            this.SetP_BodyTemperatureForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onChronicIllnessChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.ChronicIllness != event) {
            this._SapsScore.ChronicIllness = event;
            this.SetP_ChronicIllnessForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onClinicCategoryChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.ClinicCategory != event) {
            this._SapsScore.ClinicCategory = event;
            this.SetP_ClinicCategoryForSapDetail(event);
            this.CalculateSAPDetailPoint();
        }
    }

    public onDurationOfStayBeforeICChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.DurationOfStayBeforeIC != event) {
            this._SapsScore.DurationOfStayBeforeIC = event;
            this.SetP_DurationOfStayBeforeICForSapDetail(event);
            this.CalculateSAPDetailPoint();
        }
    }

    public onEntryDateChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.EntryDate != event) {
            this._SapsScore.EntryDate = event;
        }
    }

    public onGlasgowChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.Glasgow != event) {
            this._SapsScore.Glasgow = event;
            this.SetP_GlasgowForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onHCO3Changed(event): void {
        if (this._SapsScore != null && this._SapsScore.HCO3 != event) {
            this._SapsScore.HCO3 = event;
            this.SetP_HCO3ForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onHeartRateChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.HeartRate != event) {
            this._SapsScore.HeartRate = event;
            this.SetP_HeartRateForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onInpatientResourceBeforeICChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.InpatientResourceBeforeIC != event) {
            this._SapsScore.InpatientResourceBeforeIC = event;
            this.SetP_InpatientResourceBeforeICForSapDetail(event);
            this.CalculateSAPDetailPoint();
        }
    }

    public onInpatientTypeChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.InpatientType != event) {
            this._SapsScore.InpatientType = event;
            this.SetP_InpatientTypeForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onPaO2_FIO2Changed(event): void {
        if (this._SapsScore != null && this._SapsScore.PaO2_FIO2 != event) {
            this._SapsScore.PaO2_FIO2 = event;
            this.SetP_PaO2_FIO2ForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onPatientAgeChanged(event): void {
        if (event != null) {
            if (this._SapsScore != null && this._SapsScore.PatientAge != event) {
                this._SapsScore.PatientAge = event;
                this.SetP_AgeForSap(event);
                this.CalculateSAPPoint();
            }
        }
    }

    public onPatientSexChanged(event): void {
        if (event != null) {
            if (this._SapsScore != null && this._SapsScore.PatientSex != event) {
                this._SapsScore.PatientSex = event;
                this.SetP_AgeForSapDetail(event);
                this.CalculateSAPDetailPoint();
            }
        }
    }

    public onPoisingChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.Poising != event) {
            this._SapsScore.Poising = event;
            this.SetP_PoisingForSapDetail(event);
            this.CalculateSAPDetailPoint();
        }
    }

    public onPotassiumChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.Potassium != event) {
            this._SapsScore.Potassium = event;
            this.SetP_PotassiumForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onSapsIIPointChanged(event): void {
        if (event != null) {
            if (this._SapsScore != null && this._SapsScore.SapsIIPoint != event) {
                this._SapsScore.SapsIIPoint = event;
            }
            this.CalculateSAPDetailPoint();
        }
    }

    public onSapsIIPointDetailChanged(event): void {
        if (event != null) {
            if (this._SapsScore != null && this._SapsScore.SapsIIPointDetail != event) {
                this._SapsScore.SapsIIPointDetail = event;
            }
            this.CalculateWaitingMortalite();
        }
    }

    public onSerumUreChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.SerumUre != event) {
            this._SapsScore.SerumUre = event;
            this.SetP_SerumUreForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onSistolikBloodPressureChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.SistolikBloodPressure != event) {
            this._SapsScore.SistolikBloodPressure = event;
            this.SetP_SistolikBloodPressureForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onSodiumChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.Sodium != event) {
            this._SapsScore.Sodium = event;
            this.SetP_SodiumForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onUrineChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.Urine != event) {
            this._SapsScore.Urine = event;
            this.SetP_UrineForSap(event);
            this.CalculateSAPPoint();
        }
    }

    public onWaitingMortaliteChanged(event): void {
        if (event != null) {
            if (this._SapsScore != null && this._SapsScore.WaitingMortalite != event) {
                this._SapsScore.WaitingMortalite = event;
            }
        }
    }

    public onWBCChanged(event): void {
        if (this._SapsScore != null && this._SapsScore.WBC != event) {
            this._SapsScore.WBC = event;
            this.SetP_WBCForSap(event);
            this.CalculateSAPPoint();
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.SapsIIPoint, "Text", this.__ttObject, "SapsIIPoint");
        redirectProperty(this.SapsIIPointDetail, "Text", this.__ttObject, "SapsIIPointDetail");
        redirectProperty(this.WaitingMortalite, "Text", this.__ttObject, "WaitingMortalite");
        redirectProperty(this.InpatientType, "Value", this.__ttObject, "InpatientType");
        redirectProperty(this.ChronicIllness, "Value", this.__ttObject, "ChronicIllness");
        redirectProperty(this.Glasgow, "Value", this.__ttObject, "Glasgow");
        redirectProperty(this.PatientAge, "Text", this.__ttObject, "PatientAge");
        redirectProperty(this.SistolikBloodPressure, "Value", this.__ttObject, "SistolikBloodPressure");
        redirectProperty(this.HeartRate, "Value", this.__ttObject, "HeartRate");
        redirectProperty(this.BodyTemperature, "Value", this.__ttObject, "BodyTemperature");
        redirectProperty(this.PaO2_FIO2, "Value", this.__ttObject, "PaO2_FIO2");
        redirectProperty(this.Urine, "Value", this.__ttObject, "Urine");
        redirectProperty(this.SerumUre, "Value", this.__ttObject, "SerumUre");
        redirectProperty(this.WBC, "Value", this.__ttObject, "WBC");
        redirectProperty(this.Potassium, "Value", this.__ttObject, "Potassium");
        redirectProperty(this.Sodium, "Value", this.__ttObject, "Sodium");
        redirectProperty(this.HCO3, "Value", this.__ttObject, "HCO3");
        redirectProperty(this.Bilirubin, "Value", this.__ttObject, "Bilirubin");
        redirectProperty(this.Age, "Text", this.__ttObject, "PatientAge");
        redirectProperty(this.PatientSex, "Value", this.__ttObject, "PatientSex");
        redirectProperty(this.DurationOfStayBeforeIC, "Value", this.__ttObject, "DurationOfStayBeforeIC");
        redirectProperty(this.InpatientResourceBeforeIC, "Value", this.__ttObject, "InpatientResourceBeforeIC");
        redirectProperty(this.ClinicCategory, "Value", this.__ttObject, "ClinicCategory");
        redirectProperty(this.Poising, "Value", this.__ttObject, "Poising");
    }

    public initFormControls(): void {
        this.labelPatientSex = new TTVisual.TTLabel();
        this.labelPatientSex.Text = i18n("M12265", "Cinsiyet");
        this.labelPatientSex.Name = "labelPatientSex";
        this.labelPatientSex.TabIndex = 176;

        this.PatientSex = new TTVisual.TTEnumComboBox();
        this.PatientSex.DataTypeName = "SexEnum";
        this.PatientSex.BackColor = "#F0F0F0";
        this.PatientSex.Enabled = false;
        this.PatientSex.Name = "PatientSex";
        this.PatientSex.TabIndex = 175;

        this.labelPatientAge = new TTVisual.TTLabel();
        this.labelPatientAge.Text = i18n("M24339", "Yaş");
        this.labelPatientAge.Name = "labelPatientAge";
        this.labelPatientAge.TabIndex = 174;

        this.PatientAge = new TTVisual.TTTextBox();
        this.PatientAge.BackColor = "#F0F0F0";
        this.PatientAge.ReadOnly = true;
        this.PatientAge.Name = "PatientAge";
        this.PatientAge.TabIndex = 173;

        this.WaitingMortalite = new TTVisual.TTTextBox();
        this.WaitingMortalite.BackColor = "#F0F0F0";
        this.WaitingMortalite.ReadOnly = true;
        this.WaitingMortalite.Name = "WaitingMortalite";
        this.WaitingMortalite.TabIndex = 171;

        this.SapsIIPointDetail = new TTVisual.TTTextBox();
        this.SapsIIPointDetail.BackColor = "#F0F0F0";
        this.SapsIIPointDetail.ReadOnly = true;
        this.SapsIIPointDetail.Name = "SapsIIPointDetail";
        this.SapsIIPointDetail.TabIndex = 169;

        this.SapsIIPoint = new TTVisual.TTTextBox();
        this.SapsIIPoint.BackColor = "#F0F0F0";
        this.SapsIIPoint.ReadOnly = true;
        this.SapsIIPoint.Name = "SapsIIPoint";
        this.SapsIIPoint.TabIndex = 167;

        this.P_InpatientType = new TTVisual.TTTextBox();
        this.P_InpatientType.BackColor = "#F0F0F0";
        this.P_InpatientType.ReadOnly = true;
        this.P_InpatientType.Name = "P_InpatientType";
        this.P_InpatientType.TabIndex = 39;

        this.Age = new TTVisual.TTTextBox();
        this.Age.BackColor = "#F0F0F0";
        this.Age.ReadOnly = true;
        this.Age.Name = "Age";
        this.Age.TabIndex = 38;

        this.P_AgeForSap = new TTVisual.TTTextBox();
        this.P_AgeForSap.BackColor = "#F0F0F0";
        this.P_AgeForSap.ReadOnly = true;
        this.P_AgeForSap.Name = "P_AgeForSap";
        this.P_AgeForSap.TabIndex = 39;

        this.P_BodyTemperature = new TTVisual.TTTextBox();
        this.P_BodyTemperature.BackColor = "#F0F0F0";
        this.P_BodyTemperature.ReadOnly = true;
        this.P_BodyTemperature.Name = "P_BodyTemperature";
        this.P_BodyTemperature.TabIndex = 39;

        this.P_HCO3 = new TTVisual.TTTextBox();
        this.P_HCO3.BackColor = "#F0F0F0";
        this.P_HCO3.ReadOnly = true;
        this.P_HCO3.Name = "P_HCO3";
        this.P_HCO3.TabIndex = 39;

        this.P_WBC = new TTVisual.TTTextBox();
        this.P_WBC.BackColor = "#F0F0F0";
        this.P_WBC.ReadOnly = true;
        this.P_WBC.Name = "P_WBC";
        this.P_WBC.TabIndex = 39;

        this.P_PaO2_FIO2 = new TTVisual.TTTextBox();
        this.P_PaO2_FIO2.BackColor = "#F0F0F0";
        this.P_PaO2_FIO2.ReadOnly = true;
        this.P_PaO2_FIO2.Name = "P_PaO2_FIO2";
        this.P_PaO2_FIO2.TabIndex = 39;

        this.P_SistolikBloodPressure = new TTVisual.TTTextBox();
        this.P_SistolikBloodPressure.BackColor = "#F0F0F0";
        this.P_SistolikBloodPressure.ReadOnly = true;
        this.P_SistolikBloodPressure.Name = "P_SistolikBloodPressure";
        this.P_SistolikBloodPressure.TabIndex = 39;

        this.P_SerumUre = new TTVisual.TTTextBox();
        this.P_SerumUre.BackColor = "#F0F0F0";
        this.P_SerumUre.ReadOnly = true;
        this.P_SerumUre.Name = "P_SerumUre";
        this.P_SerumUre.TabIndex = 39;

        this.P_Sodium = new TTVisual.TTTextBox();
        this.P_Sodium.BackColor = "#F0F0F0";
        this.P_Sodium.ReadOnly = true;
        this.P_Sodium.Name = "P_Sodium";
        this.P_Sodium.TabIndex = 39;

        this.P_ChronicIllness = new TTVisual.TTTextBox();
        this.P_ChronicIllness.BackColor = "#F0F0F0";
        this.P_ChronicIllness.ReadOnly = true;
        this.P_ChronicIllness.Name = "P_ChronicIllness";
        this.P_ChronicIllness.TabIndex = 39;

        this.P_Glasgow = new TTVisual.TTTextBox();
        this.P_Glasgow.BackColor = "#F0F0F0";
        this.P_Glasgow.ReadOnly = true;
        this.P_Glasgow.Name = "P_Glasgow";
        this.P_Glasgow.TabIndex = 39;

        this.P_HeartRate = new TTVisual.TTTextBox();
        this.P_HeartRate.BackColor = "#F0F0F0";
        this.P_HeartRate.ReadOnly = true;
        this.P_HeartRate.Name = "P_HeartRate";
        this.P_HeartRate.TabIndex = 39;

        this.P_Urine = new TTVisual.TTTextBox();
        this.P_Urine.BackColor = "#F0F0F0";
        this.P_Urine.ReadOnly = true;
        this.P_Urine.Name = "P_Urine";
        this.P_Urine.TabIndex = 39;

        this.P_Potassium = new TTVisual.TTTextBox();
        this.P_Potassium.BackColor = "#F0F0F0";
        this.P_Potassium.ReadOnly = true;
        this.P_Potassium.Name = "P_Potassium";
        this.P_Potassium.TabIndex = 39;

        this.P_Bilirubin = new TTVisual.TTTextBox();
        this.P_Bilirubin.BackColor = "#F0F0F0";
        this.P_Bilirubin.ReadOnly = true;
        this.P_Bilirubin.Name = "P_Bilirubin";
        this.P_Bilirubin.TabIndex = 39;

        this.P_AgeForSapDetail = new TTVisual.TTTextBox();
        this.P_AgeForSapDetail.BackColor = "#F0F0F0";
        this.P_AgeForSapDetail.ReadOnly = true;
        this.P_AgeForSapDetail.Name = "P_AgeForSapDetail";
        this.P_AgeForSapDetail.TabIndex = 39;

        this.P_Sex = new TTVisual.TTTextBox();
        this.P_Sex.BackColor = "#F0F0F0";
        this.P_Sex.ReadOnly = true;
        this.P_Sex.Name = "P_Sex";
        this.P_Sex.TabIndex = 39;

        this.P_DurationOfStayBeforeIC = new TTVisual.TTTextBox();
        this.P_DurationOfStayBeforeIC.BackColor = "#F0F0F0";
        this.P_DurationOfStayBeforeIC.ReadOnly = true;
        this.P_DurationOfStayBeforeIC.Name = "P_DurationOfStayBeforeIC";
        this.P_DurationOfStayBeforeIC.TabIndex = 39;

        this.P_InpatientResourceBeforeIC = new TTVisual.TTTextBox();
        this.P_InpatientResourceBeforeIC.BackColor = "#F0F0F0";
        this.P_InpatientResourceBeforeIC.ReadOnly = true;
        this.P_InpatientResourceBeforeIC.Name = "P_InpatientResourceBeforeIC";
        this.P_InpatientResourceBeforeIC.TabIndex = 39;

        this.P_ClinicCategory = new TTVisual.TTTextBox();
        this.P_ClinicCategory.BackColor = "#F0F0F0";
        this.P_ClinicCategory.ReadOnly = true;
        this.P_ClinicCategory.Name = "P_ClinicCategory";
        this.P_ClinicCategory.TabIndex = 39;

        this.P_Poising = new TTVisual.TTTextBox();
        this.P_Poising.BackColor = "#F0F0F0";
        this.P_Poising.ReadOnly = true;
        this.P_Poising.Name = "P_Poising";
        this.P_Poising.TabIndex = 39;

        this.labelWaitingMortalite = new TTVisual.TTLabel();
        this.labelWaitingMortalite.Text = i18n("M11728", "Bekleyen Mortalite");
        this.labelWaitingMortalite.Name = "labelWaitingMortalite";
        this.labelWaitingMortalite.TabIndex = 172;

        this.labelSapsIIPointDetail = new TTVisual.TTLabel();
        this.labelSapsIIPointDetail.Text = i18n("M21294", "SAPS II (Genişletilmiş)");
        this.labelSapsIIPointDetail.Name = "labelSapsIIPointDetail";
        this.labelSapsIIPointDetail.TabIndex = 170;

        this.labelSapsIIPoint = new TTVisual.TTLabel();
        this.labelSapsIIPoint.Text = "SAPS II";
        this.labelSapsIIPoint.Name = "labelSapsIIPoint";
        this.labelSapsIIPoint.TabIndex = 168;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = i18n("M14809", "Giriş Yapılan Zaman");
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 37;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 36;

        this.labelPoising = new TTVisual.TTLabel();
        this.labelPoising.Text = i18n("M24760", "Zehirlenme");
        this.labelPoising.Name = "labelPoising";
        this.labelPoising.TabIndex = 35;

        this.Poising = new TTVisual.TTEnumComboBox();
        this.Poising.DataTypeName = "YesNoEnum";
        this.Poising.SortBy = SortByEnum.Value;
        this.Poising.Name = "Poising";
        this.Poising.TabIndex = 34;

        this.labelWBC = new TTVisual.TTLabel();
        this.labelWBC.Text = "WBC";
        this.labelWBC.Name = "labelWBC";
        this.labelWBC.TabIndex = 33;

        this.WBC = new TTVisual.TTEnumComboBox();
        this.WBC.DataTypeName = "SapsWBC";
        this.WBC.SortBy = SortByEnum.Value;
        this.WBC.Name = "WBC";
        this.WBC.TabIndex = 32;

        this.labelUrine = new TTVisual.TTLabel();
        this.labelUrine.Text = i18n("M16192", "İdrar Çıkışı");
        this.labelUrine.Name = "labelUrine";
        this.labelUrine.TabIndex = 31;

        this.Urine = new TTVisual.TTEnumComboBox();
        this.Urine.DataTypeName = "SapsUrineEnum";
        this.Urine.SortBy = SortByEnum.Value;
        this.Urine.Name = "Urine";
        this.Urine.TabIndex = 30;

        this.labelSodium = new TTVisual.TTLabel();
        this.labelSodium.Text = i18n("M21996", "Sodyum");
        this.labelSodium.Name = "labelSodium";
        this.labelSodium.TabIndex = 29;

        this.Sodium = new TTVisual.TTEnumComboBox();
        this.Sodium.DataTypeName = "SapsSodiumEnum";
        this.Sodium.SortBy = SortByEnum.Value;
        this.Sodium.Name = "Sodium";
        this.Sodium.TabIndex = 28;

        this.labelSistolikBloodPressure = new TTVisual.TTLabel();
        this.labelSistolikBloodPressure.Text = i18n("M21925", "Sistolik  Kan Basıncı");
        this.labelSistolikBloodPressure.Name = "labelSistolikBloodPressure";
        this.labelSistolikBloodPressure.TabIndex = 27;

        this.SistolikBloodPressure = new TTVisual.TTEnumComboBox();
        this.SistolikBloodPressure.DataTypeName = "SapsSistolikEnum";
        this.SistolikBloodPressure.SortBy = SortByEnum.Value;
        this.SistolikBloodPressure.Name = "SistolikBloodPressure";
        this.SistolikBloodPressure.TabIndex = 26;

        this.labelSerumUre = new TTVisual.TTLabel();
        this.labelSerumUre.Text = i18n("M21657", "Serum Ure veya BUN");
        this.labelSerumUre.Name = "labelSerumUre";
        this.labelSerumUre.TabIndex = 25;

        this.SerumUre = new TTVisual.TTEnumComboBox();
        this.SerumUre.DataTypeName = "SapsSerumUreEnum";
        this.SerumUre.SortBy = SortByEnum.Value;
        this.SerumUre.Name = "SerumUre";
        this.SerumUre.TabIndex = 24;

        this.labelPotassium = new TTVisual.TTLabel();
        this.labelPotassium.Text = i18n("M20460", "Potasyum");
        this.labelPotassium.Name = "labelPotassium";
        this.labelPotassium.TabIndex = 23;

        this.Potassium = new TTVisual.TTEnumComboBox();
        this.Potassium.DataTypeName = "SapsPotassiumEnum";
        this.Potassium.SortBy = SortByEnum.Value;
        this.Potassium.Name = "Potassium";
        this.Potassium.TabIndex = 22;

        this.labelPaO2_FIO2 = new TTVisual.TTLabel();
        this.labelPaO2_FIO2.Text = i18n("M19372", "MV veya CPAP var ise PaO2/FIO2(mmHg)");
        this.labelPaO2_FIO2.Name = "labelPaO2_FIO2";
        this.labelPaO2_FIO2.TabIndex = 21;

        this.PaO2_FIO2 = new TTVisual.TTEnumComboBox();
        this.PaO2_FIO2.DataTypeName = "SapsPaO2_FIO2Enum";
        this.PaO2_FIO2.SortBy = SortByEnum.Value;
        this.PaO2_FIO2.Name = "PaO2_FIO2";
        this.PaO2_FIO2.TabIndex = 20;

        this.labelInpatientType = new TTVisual.TTLabel();
        this.labelInpatientType.Text = i18n("M24445", "Yatış Şekli");
        this.labelInpatientType.Name = "labelInpatientType";
        this.labelInpatientType.TabIndex = 19;

        this.InpatientType = new TTVisual.TTEnumComboBox();
        this.InpatientType.DataTypeName = "SapsInpatientTypeEnum";
        this.InpatientType.SortBy = SortByEnum.Value;
        this.InpatientType.Name = "InpatientType";
        this.InpatientType.TabIndex = 18;

        this.labelInpatientResourceBeforeIC = new TTVisual.TTLabel();
        this.labelInpatientResourceBeforeIC.Text = i18n("M24696", "Yoğun bakım öncesi hastanın yattığı bölüm");
        this.labelInpatientResourceBeforeIC.Name = "labelInpatientResourceBeforeIC";
        this.labelInpatientResourceBeforeIC.TabIndex = 17;

        this.InpatientResourceBeforeIC = new TTVisual.TTEnumComboBox();
        this.InpatientResourceBeforeIC.DataTypeName = "SapsInpatientResourceBeforeIntensiveCare";
        this.InpatientResourceBeforeIC.SortBy = SortByEnum.Value;
        this.InpatientResourceBeforeIC.Name = "InpatientResourceBeforeIC";
        this.InpatientResourceBeforeIC.TabIndex = 16;

        this.labelHeartRate = new TTVisual.TTLabel();
        this.labelHeartRate.Text = i18n("M17133", "Kalp Hızı");
        this.labelHeartRate.Name = "labelHeartRate";
        this.labelHeartRate.TabIndex = 15;

        this.HeartRate = new TTVisual.TTEnumComboBox();
        this.HeartRate.DataTypeName = "SapsHeartRateEnum";
        this.HeartRate.SortBy = SortByEnum.Value;
        this.HeartRate.Name = "HeartRate";
        this.HeartRate.TabIndex = 14;

        this.labelHCO3 = new TTVisual.TTLabel();
        this.labelHCO3.Text = "HCO3";
        this.labelHCO3.Name = "labelHCO3";
        this.labelHCO3.TabIndex = 13;

        this.HCO3 = new TTVisual.TTEnumComboBox();
        this.HCO3.DataTypeName = "SapsHCO3Enum";
        this.HCO3.SortBy = SortByEnum.Value;
        this.HCO3.Name = "HCO3";
        this.HCO3.TabIndex = 12;

        this.labelGlasgow = new TTVisual.TTLabel();
        this.labelGlasgow.Text = "Glasgow";
        this.labelGlasgow.Name = "labelGlasgow";
        this.labelGlasgow.TabIndex = 11;

        this.Glasgow = new TTVisual.TTEnumComboBox();
        this.Glasgow.DataTypeName = "SapsGlasgowEnum";
        this.Glasgow.SortBy = SortByEnum.Value;
        this.Glasgow.Name = "Glasgow";
        this.Glasgow.TabIndex = 10;

        this.labelDurationOfStayBeforeIC = new TTVisual.TTLabel();
        this.labelDurationOfStayBeforeIC.Text = i18n("M24695", "Yoğun Bakım Öncesi XXXXXXde Kalış Süresi");
        this.labelDurationOfStayBeforeIC.Name = "labelDurationOfStayBeforeIC";
        this.labelDurationOfStayBeforeIC.TabIndex = 9;

        this.DurationOfStayBeforeIC = new TTVisual.TTEnumComboBox();
        this.DurationOfStayBeforeIC.DataTypeName = "SapsDurationOfStayBeforeIntensiveCare";
        this.DurationOfStayBeforeIC.SortBy = SortByEnum.Value;
        this.DurationOfStayBeforeIC.Name = "DurationOfStayBeforeIC";
        this.DurationOfStayBeforeIC.TabIndex = 8;

        this.labelClinicCategory = new TTVisual.TTLabel();
        this.labelClinicCategory.Text = i18n("M17639", "Klinik Kategori");
        this.labelClinicCategory.Name = "labelClinicCategory";
        this.labelClinicCategory.TabIndex = 7;

        this.ClinicCategory = new TTVisual.TTEnumComboBox();
        this.ClinicCategory.DataTypeName = "SapsClinicCategoryEnum";
        this.ClinicCategory.SortBy = SortByEnum.Value;
        this.ClinicCategory.Name = "ClinicCategory";
        this.ClinicCategory.TabIndex = 6;

        this.labelChronicIllness = new TTVisual.TTLabel();
        this.labelChronicIllness.Text = i18n("M17875", "Kronik Hastalık");
        this.labelChronicIllness.Name = "labelChronicIllness";
        this.labelChronicIllness.TabIndex = 5;

        this.ChronicIllness = new TTVisual.TTEnumComboBox();
        this.ChronicIllness.DataTypeName = "SapsChronicIllnessEnum";
        this.ChronicIllness.SortBy = SortByEnum.Value;
        this.ChronicIllness.Name = "ChronicIllness";
        this.ChronicIllness.TabIndex = 4;

        this.labelBodyTemperature = new TTVisual.TTLabel();
        this.labelBodyTemperature.Text = i18n("M24195", "Vücut Isısı");
        this.labelBodyTemperature.Name = "labelBodyTemperature";
        this.labelBodyTemperature.TabIndex = 3;

        this.BodyTemperature = new TTVisual.TTEnumComboBox();
        this.BodyTemperature.DataTypeName = "SapsBodyTemperatureEnum";
        this.BodyTemperature.SortBy = SortByEnum.Value;
        this.BodyTemperature.Name = "BodyTemperature";
        this.BodyTemperature.TabIndex = 2;

        this.labelBilirubin = new TTVisual.TTLabel();
        this.labelBilirubin.Text = "Bilirubin";
        this.labelBilirubin.Name = "labelBilirubin";
        this.labelBilirubin.TabIndex = 1;

        this.Bilirubin = new TTVisual.TTEnumComboBox();
        this.Bilirubin.DataTypeName = "SapsBilirubinEnum";
        this.Bilirubin.SortBy = SortByEnum.Value;
        this.Bilirubin.Name = "Bilirubin";
        this.Bilirubin.TabIndex = 0;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M24339", "Yaş");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 19;

        this.Controls = [this.labelPatientSex, this.PatientSex, this.labelPatientAge, this.PatientAge, this.WaitingMortalite, this.SapsIIPointDetail, this.SapsIIPoint, this.P_InpatientType, this.Age, this.P_AgeForSap, this.P_BodyTemperature, this.P_HCO3, this.P_WBC, this.P_PaO2_FIO2, this.P_SistolikBloodPressure, this.P_SerumUre, this.P_Sodium, this.P_ChronicIllness, this.P_Glasgow, this.P_HeartRate, this.P_Urine, this.P_Potassium, this.P_Bilirubin, this.P_AgeForSapDetail, this.P_Sex, this.P_DurationOfStayBeforeIC, this.P_InpatientResourceBeforeIC, this.P_ClinicCategory, this.P_Poising, this.labelWaitingMortalite, this.labelSapsIIPointDetail, this.labelSapsIIPoint, this.labelEntryDate, this.EntryDate, this.labelPoising, this.Poising, this.labelWBC, this.WBC, this.labelUrine, this.Urine, this.labelSodium, this.Sodium, this.labelSistolikBloodPressure, this.SistolikBloodPressure, this.labelSerumUre, this.SerumUre, this.labelPotassium, this.Potassium, this.labelPaO2_FIO2, this.PaO2_FIO2, this.labelInpatientType, this.InpatientType, this.labelInpatientResourceBeforeIC, this.InpatientResourceBeforeIC, this.labelHeartRate, this.HeartRate, this.labelHCO3, this.HCO3, this.labelGlasgow, this.Glasgow, this.labelDurationOfStayBeforeIC, this.DurationOfStayBeforeIC, this.labelClinicCategory, this.ClinicCategory, this.labelChronicIllness, this.ChronicIllness, this.labelBodyTemperature, this.BodyTemperature, this.labelBilirubin, this.Bilirubin, this.ttlabel1];

    }


}




