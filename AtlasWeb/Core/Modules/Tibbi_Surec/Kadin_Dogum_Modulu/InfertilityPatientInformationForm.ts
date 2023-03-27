//$CE63328F
import { Component, OnInit, Output, EventEmitter, Input, NgZone } from '@angular/core';
import { InfertilityPatientInformationFormViewModel } from './InfertilityPatientInformationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InfertilityPatientInformation } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';



import { Patient } from 'NebulaClient/Model/AtlasClientModel';
@Component({
    selector: 'InfertilityPatientInformationForm',
    templateUrl: './InfertilityPatientInformationForm.html',
    providers: [MessageService]
})
export class InfertilityPatientInformationForm extends TTVisual.TTForm implements OnInit {
    AbdominalDistribution: TTVisual.ITTTextBox;
    HistoryOfTreatment: TTVisual.ITTTextBox;
    HusbandsSurgeries: TTVisual.ITTTextBox;
    HysterosalpingographyDate: TTVisual.ITTDateTimePicker;
    HysteroscopyDate: TTVisual.ITTDateTimePicker;
    HysteroscopyInformation: TTVisual.ITTTextBox;
    labelAbdominalDistribution: TTVisual.ITTLabel;
    labelHistoryOfTreatment: TTVisual.ITTLabel;
    labelHusbandsSurgeries: TTVisual.ITTLabel;
    labelHysterosalpingographyDate: TTVisual.ITTLabel;
    labelHysteroscopyDate: TTVisual.ITTLabel;
    labelHysteroscopyInformation: TTVisual.ITTLabel;
    labelLaparoscopyDate: TTVisual.ITTLabel;
    labelLaparoscopyInformation: TTVisual.ITTLabel;
    labelLipiodolography: TTVisual.ITTLabel;
    labelOFISHSDate: TTVisual.ITTLabel;
    labelOFISHSInformation: TTVisual.ITTLabel;
    labelPatientsSurgeries: TTVisual.ITTLabel;
    labelSuSoluble: TTVisual.ITTLabel;
    labelTubalLeft: TTVisual.ITTLabel;
    labelTubalRight: TTVisual.ITTLabel;
    labelUterineCavity: TTVisual.ITTLabel;
    LaparoscopyDate: TTVisual.ITTDateTimePicker;
    LaparoscopyInformation: TTVisual.ITTTextBox;
    Lipiodolography: TTVisual.ITTTextBox;
    OFISHSDate: TTVisual.ITTDateTimePicker;
    OFISHSInformation: TTVisual.ITTTextBox;
    PatientsSurgeries: TTVisual.ITTTextBox;
    SuSoluble: TTVisual.ITTTextBox;
    ttpanel1: TTVisual.ITTPanel;
    TubalLeft: TTVisual.ITTTextBox;
    TubalRight: TTVisual.ITTTextBox;
    UterineCavity: TTVisual.ITTTextBox;
    public infertilityPatientInformationFormViewModel: InfertilityPatientInformationFormViewModel = new InfertilityPatientInformationFormViewModel();
    public get _InfertilityPatientInformation(): InfertilityPatientInformation {
        return this._TTObject as InfertilityPatientInformation;
    }
    private InfertilityPatientInformationForm_DocumentUrl: string = '/api/InfertilityPatientInformationService/InfertilityPatientInformationForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super('INFERTILITYPATIENTINFORMATION', 'InfertilityPatientInformationForm');
        this._DocumentServiceUrl = this.InfertilityPatientInformationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    @Output() sendViewModelToParent: EventEmitter<InfertilityPatientInformationFormViewModel> = new EventEmitter<InfertilityPatientInformationFormViewModel>();
    @Input() set patientId(value: Patient) {
        if (value.InfertilityPatientInformation != null) {
            if (typeof value.InfertilityPatientInformation == "string") {
                this.ObjectID = value.InfertilityPatientInformation;
            } else {
                this.ObjectID = value.InfertilityPatientInformation.ObjectID;
            }
        }
    }
    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InfertilityPatientInformation();
        this.infertilityPatientInformationFormViewModel = new InfertilityPatientInformationFormViewModel();
        this._ViewModel = this.infertilityPatientInformationFormViewModel;
        this.infertilityPatientInformationFormViewModel._InfertilityPatientInformation = this._TTObject as InfertilityPatientInformation;
    }

    protected loadViewModel() {
        let that = this;

        that.infertilityPatientInformationFormViewModel = this._ViewModel as InfertilityPatientInformationFormViewModel;
        that._TTObject = this.infertilityPatientInformationFormViewModel._InfertilityPatientInformation;
        if (this.infertilityPatientInformationFormViewModel == null)
            this.infertilityPatientInformationFormViewModel = new InfertilityPatientInformationFormViewModel();
        if (this.infertilityPatientInformationFormViewModel._InfertilityPatientInformation == null)
            this.infertilityPatientInformationFormViewModel._InfertilityPatientInformation = new InfertilityPatientInformation();

        this.sendViewModelToParent.emit(that.infertilityPatientInformationFormViewModel);
    }

    async ngOnInit()  {
        let that = this;
        await this.load(InfertilityPatientInformationFormViewModel);
  
    }


    public onAbdominalDistributionChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.AbdominalDistribution != event) {
                this._InfertilityPatientInformation.AbdominalDistribution = event;
            }
        }
    }

    public onHistoryOfTreatmentChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.HistoryOfTreatment != event) {
                this._InfertilityPatientInformation.HistoryOfTreatment = event;
            }
        }
    }

    public onHusbandsSurgeriesChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.HusbandsSurgeries != event) {
                this._InfertilityPatientInformation.HusbandsSurgeries = event;
            }
        }
    }

    public onHysterosalpingographyDateChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.HysterosalpingographyDate != event) {
                this._InfertilityPatientInformation.HysterosalpingographyDate = event;
            }
        }
    }

    public onHysteroscopyDateChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.HysteroscopyDate != event) {
                this._InfertilityPatientInformation.HysteroscopyDate = event;
            }
        }
    }

    public onHysteroscopyInformationChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.HysteroscopyInformation != event) {
                this._InfertilityPatientInformation.HysteroscopyInformation = event;
            }
        }
    }

    public onLaparoscopyDateChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.LaparoscopyDate != event) {
                this._InfertilityPatientInformation.LaparoscopyDate = event;
            }
        }
    }

    public onLaparoscopyInformationChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.LaparoscopyInformation != event) {
                this._InfertilityPatientInformation.LaparoscopyInformation = event;
            }
        }
    }

    public onLipiodolographyChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.Lipiodolography != event) {
                this._InfertilityPatientInformation.Lipiodolography = event;
            }
        }
    }

    public onOFISHSDateChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.OFISHSDate != event) {
                this._InfertilityPatientInformation.OFISHSDate = event;
            }
        }
    }

    public onOFISHSInformationChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.OFISHSInformation != event) {
                this._InfertilityPatientInformation.OFISHSInformation = event;
            }
        }
    }

    public onPatientsSurgeriesChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.PatientsSurgeries != event) {
                this._InfertilityPatientInformation.PatientsSurgeries = event;
            }
        }
    }

    public onSuSolubleChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.SuSoluble != event) {
                this._InfertilityPatientInformation.SuSoluble = event;
            }
        }
    }

    public onTubalLeftChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.TubalLeft != event) {
                this._InfertilityPatientInformation.TubalLeft = event;
            }
        }
    }

    public onTubalRightChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.TubalRight != event) {
                this._InfertilityPatientInformation.TubalRight = event;
            }
        }
    }

    public onUterineCavityChanged(event): void {
        if (event != null) {
            if (this._InfertilityPatientInformation != null && this._InfertilityPatientInformation.UterineCavity != event) {
                this._InfertilityPatientInformation.UterineCavity = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.HistoryOfTreatment, "Text", this.__ttObject, "HistoryOfTreatment");
        redirectProperty(this.PatientsSurgeries, "Text", this.__ttObject, "PatientsSurgeries");
        redirectProperty(this.HusbandsSurgeries, "Text", this.__ttObject, "HusbandsSurgeries");
        redirectProperty(this.LaparoscopyDate, "Value", this.__ttObject, "LaparoscopyDate");
        redirectProperty(this.LaparoscopyInformation, "Text", this.__ttObject, "LaparoscopyInformation");
        redirectProperty(this.HysteroscopyDate, "Value", this.__ttObject, "HysteroscopyDate");
        redirectProperty(this.HysteroscopyInformation, "Text", this.__ttObject, "HysteroscopyInformation");
        redirectProperty(this.OFISHSDate, "Value", this.__ttObject, "OFISHSDate");
        redirectProperty(this.OFISHSInformation, "Text", this.__ttObject, "OFISHSInformation");
        redirectProperty(this.HysterosalpingographyDate, "Value", this.__ttObject, "HysterosalpingographyDate");
        redirectProperty(this.Lipiodolography, "Text", this.__ttObject, "Lipiodolography");
        redirectProperty(this.SuSoluble, "Text", this.__ttObject, "SuSoluble");
        redirectProperty(this.UterineCavity, "Text", this.__ttObject, "UterineCavity");
        redirectProperty(this.TubalLeft, "Text", this.__ttObject, "TubalLeft");
        redirectProperty(this.TubalRight, "Text", this.__ttObject, "TubalRight");
        redirectProperty(this.AbdominalDistribution, "Text", this.__ttObject, "AbdominalDistribution");
    }

    public initFormControls(): void {
        this.PatientsSurgeries = new TTVisual.TTTextBox();
        this.PatientsSurgeries.Name = "PatientsSurgeries";
        this.PatientsSurgeries.TabIndex = 1;

        this.OFISHSInformation = new TTVisual.TTTextBox();
        this.OFISHSInformation.Name = "OFISHSInformation";
        this.OFISHSInformation.TabIndex = 9;

        this.LaparoscopyInformation = new TTVisual.TTTextBox();
        this.LaparoscopyInformation.Name = "LaparoscopyInformation";
        this.LaparoscopyInformation.TabIndex = 5;

        this.HysteroscopyInformation = new TTVisual.TTTextBox();
        this.HysteroscopyInformation.Name = "HysteroscopyInformation";
        this.HysteroscopyInformation.TabIndex = 7;

        this.HusbandsSurgeries = new TTVisual.TTTextBox();
        this.HusbandsSurgeries.Name = "HusbandsSurgeries";
        this.HusbandsSurgeries.TabIndex = 2;

        this.HistoryOfTreatment = new TTVisual.TTTextBox();
        this.HistoryOfTreatment.Name = "HistoryOfTreatment";
        this.HistoryOfTreatment.TabIndex = 0;

        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 10;

        this.labelHysterosalpingographyDate = new TTVisual.TTLabel();
        this.labelHysterosalpingographyDate.Text = i18n("M15813", "Histerosalpingografi Tarihi");
        this.labelHysterosalpingographyDate.Name = "labelHysterosalpingographyDate";
        this.labelHysterosalpingographyDate.TabIndex = 7;

        this.labelTubalRight = new TTVisual.TTLabel();
        this.labelTubalRight.Text = i18n("M23597", "Tubal Dolum Sağ");
        this.labelTubalRight.Name = "labelTubalRight";
        this.labelTubalRight.TabIndex = 29;

        this.labelUterineCavity = new TTVisual.TTLabel();
        this.labelUterineCavity.Text = "Uterin Kavite";
        this.labelUterineCavity.Name = "labelUterineCavity";
        this.labelUterineCavity.TabIndex = 31;

        this.TubalRight = new TTVisual.TTTextBox();
        this.TubalRight.Name = "TubalRight";
        this.TubalRight.TabIndex = 5;

        this.UterineCavity = new TTVisual.TTTextBox();
        this.UterineCavity.Name = "UterineCavity";
        this.UterineCavity.TabIndex = 3;

        this.labelTubalLeft = new TTVisual.TTLabel();
        this.labelTubalLeft.Text = i18n("M23598", "Tubal Dolum Sol");
        this.labelTubalLeft.Name = "labelTubalLeft";
        this.labelTubalLeft.TabIndex = 27;

        this.TubalLeft = new TTVisual.TTTextBox();
        this.TubalLeft.Name = "TubalLeft";
        this.TubalLeft.TabIndex = 4;

        this.HysterosalpingographyDate = new TTVisual.TTDateTimePicker();
        this.HysterosalpingographyDate.CustomFormat = "dd.MM.yyyy";
        this.HysterosalpingographyDate.Format = DateTimePickerFormat.Custom;
        this.HysterosalpingographyDate.Name = "HysterosalpingographyDate";
        this.HysterosalpingographyDate.TabIndex = 0;

        this.Lipiodolography = new TTVisual.TTTextBox();
        this.Lipiodolography.Name = "Lipiodolography";
        this.Lipiodolography.TabIndex = 1;

        this.labelLipiodolography = new TTVisual.TTLabel();
        this.labelLipiodolography.Text = i18n("M18270", "Lipiodolografi");
        this.labelLipiodolography.Name = "labelLipiodolography";
        this.labelLipiodolography.TabIndex = 17;

        this.SuSoluble = new TTVisual.TTTextBox();
        this.SuSoluble.Name = "SuSoluble";
        this.SuSoluble.TabIndex = 2;

        this.labelSuSoluble = new TTVisual.TTLabel();
        this.labelSuSoluble.Text = i18n("M22372", "Su Soluble");
        this.labelSuSoluble.Name = "labelSuSoluble";
        this.labelSuSoluble.TabIndex = 25;

        this.AbdominalDistribution = new TTVisual.TTTextBox();
        this.AbdominalDistribution.Name = "AbdominalDistribution";
        this.AbdominalDistribution.TabIndex = 6;

        this.labelAbdominalDistribution = new TTVisual.TTLabel();
        this.labelAbdominalDistribution.Text = "Batına Dağılım";
        this.labelAbdominalDistribution.Name = "labelAbdominalDistribution";
        this.labelAbdominalDistribution.TabIndex = 13;

        this.labelPatientsSurgeries = new TTVisual.TTLabel();
        this.labelPatientsSurgeries.Text = i18n("M15452", "Hastanın Geçirdiği Ameliyatlar");
        this.labelPatientsSurgeries.Name = "labelPatientsSurgeries";
        this.labelPatientsSurgeries.TabIndex = 23;

        this.labelOFISHSInformation = new TTVisual.TTLabel();
        this.labelOFISHSInformation.Text = "OFIS HS Açıklama";
        this.labelOFISHSInformation.Name = "labelOFISHSInformation";
        this.labelOFISHSInformation.TabIndex = 21;

        this.labelOFISHSDate = new TTVisual.TTLabel();
        this.labelOFISHSDate.Text = "OFIS HS Tarih";
        this.labelOFISHSDate.Name = "labelOFISHSDate";
        this.labelOFISHSDate.TabIndex = 19;

        this.OFISHSDate = new TTVisual.TTDateTimePicker();
        this.OFISHSDate.CustomFormat = "dd.MM.yyyy";
        this.OFISHSDate.Format = DateTimePickerFormat.Custom;
        this.OFISHSDate.Name = "OFISHSDate";
        this.OFISHSDate.TabIndex = 8;

        this.labelLaparoscopyInformation = new TTVisual.TTLabel();
        this.labelLaparoscopyInformation.Text = i18n("M18259", "Laparoskopi Açıklama");
        this.labelLaparoscopyInformation.Name = "labelLaparoscopyInformation";
        this.labelLaparoscopyInformation.TabIndex = 15;

        this.labelLaparoscopyDate = new TTVisual.TTLabel();
        this.labelLaparoscopyDate.Text = i18n("M18260", "Laparoskopi Tarihi");
        this.labelLaparoscopyDate.Name = "labelLaparoscopyDate";
        this.labelLaparoscopyDate.TabIndex = 13;

        this.LaparoscopyDate = new TTVisual.TTDateTimePicker();
        this.LaparoscopyDate.CustomFormat = "dd.MM.yyyy";
        this.LaparoscopyDate.Format = DateTimePickerFormat.Custom;
        this.LaparoscopyDate.Name = "LaparoscopyDate";
        this.LaparoscopyDate.TabIndex = 4;

        this.labelHysteroscopyInformation = new TTVisual.TTLabel();
        this.labelHysteroscopyInformation.Text = i18n("M15814", "Histeroskopi Açıklama");
        this.labelHysteroscopyInformation.Name = "labelHysteroscopyInformation";
        this.labelHysteroscopyInformation.TabIndex = 11;

        this.labelHysteroscopyDate = new TTVisual.TTLabel();
        this.labelHysteroscopyDate.Text = i18n("M15815", "Histeroskopi Tarihi");
        this.labelHysteroscopyDate.Name = "labelHysteroscopyDate";
        this.labelHysteroscopyDate.TabIndex = 9;

        this.HysteroscopyDate = new TTVisual.TTDateTimePicker();
        this.HysteroscopyDate.CustomFormat = "dd.MM.yyyy";
        this.HysteroscopyDate.Format = DateTimePickerFormat.Custom;
        this.HysteroscopyDate.Name = "HysteroscopyDate";
        this.HysteroscopyDate.TabIndex = 6;

        this.labelHusbandsSurgeries = new TTVisual.TTLabel();
        this.labelHusbandsSurgeries.Text = i18n("M13915", "Eşinin Geçirdiği Ameliyatlar");
        this.labelHusbandsSurgeries.Name = "labelHusbandsSurgeries";
        this.labelHusbandsSurgeries.TabIndex = 5;

        this.labelHistoryOfTreatment = new TTVisual.TTLabel();
        this.labelHistoryOfTreatment.Text = i18n("M14637", "Geçmiş Tedavi Bilgileri");
        this.labelHistoryOfTreatment.Name = "labelHistoryOfTreatment";
        this.labelHistoryOfTreatment.TabIndex = 3;

        this.ttpanel1.Controls = [this.labelHysterosalpingographyDate, this.labelTubalRight, this.labelUterineCavity, this.TubalRight, this.UterineCavity, this.labelTubalLeft, this.TubalLeft, this.HysterosalpingographyDate, this.Lipiodolography, this.labelLipiodolography, this.SuSoluble, this.labelSuSoluble, this.AbdominalDistribution, this.labelAbdominalDistribution];
        this.Controls = [this.PatientsSurgeries, this.OFISHSInformation, this.LaparoscopyInformation, this.HysteroscopyInformation, this.HusbandsSurgeries, this.HistoryOfTreatment, this.ttpanel1, this.labelHysterosalpingographyDate, this.labelTubalRight, this.labelUterineCavity, this.TubalRight, this.UterineCavity, this.labelTubalLeft, this.TubalLeft, this.HysterosalpingographyDate, this.Lipiodolography, this.labelLipiodolography, this.SuSoluble, this.labelSuSoluble, this.AbdominalDistribution, this.labelAbdominalDistribution, this.labelPatientsSurgeries, this.labelOFISHSInformation, this.labelOFISHSDate, this.OFISHSDate, this.labelLaparoscopyInformation, this.labelLaparoscopyDate, this.LaparoscopyDate, this.labelHysteroscopyInformation, this.labelHysteroscopyDate, this.HysteroscopyDate, this.labelHusbandsSurgeries, this.labelHistoryOfTreatment];

    }


}
