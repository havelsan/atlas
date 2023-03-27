//$5ED747AD
import { Component, OnInit, Output, EventEmitter, Input, NgZone } from '@angular/core';
import { InfertilityFormViewModel } from './InfertilityFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Infertility } from 'NebulaClient/Model/AtlasClientModel';

import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


import { WomanSpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { WomanSpecialityObjectInfo } from './WomanSpecialityFormViewModel';

@Component({
    selector: 'InfertilityForm',
    templateUrl: './InfertilityForm.html',
    providers: [MessageService]
})
export class InfertilityForm extends TTVisual.TTForm implements OnInit {
    BasalUltrasoundDate: TTVisual.ITTDateTimePicker;
    Candida: TTVisual.ITTTextBox;
    Cervix: TTVisual.ITTTextBox;
    Chlamdydia: TTVisual.ITTTextBox;
    Decision: TTVisual.ITTTextBox;
    Endometrium: TTVisual.ITTTextBox;
    Hirsutism: TTVisual.ITTTextBox;
    labelBasalUltrasoundDate: TTVisual.ITTLabel;
    labelCandida: TTVisual.ITTLabel;
    labelCervix: TTVisual.ITTLabel;
    labelChlamdydia: TTVisual.ITTLabel;
    labelDecision: TTVisual.ITTLabel;
    labelEndometrium: TTVisual.ITTLabel;
    labelHirsutism: TTVisual.ITTLabel;
    labelLeftOvaryVolume: TTVisual.ITTLabel;
    labelRightOvaryVolume: TTVisual.ITTLabel;
    labelSecondarySexCharacter: TTVisual.ITTLabel;
    labelThyroid: TTVisual.ITTLabel;
    labelUterus: TTVisual.ITTLabel;
    labelVagina: TTVisual.ITTLabel;
    labelVulva: TTVisual.ITTLabel;
    labelWeightPatient: TTVisual.ITTLabel;
    LeftOvaryVolume: TTVisual.ITTTextBox;
    RightOvaryVolume: TTVisual.ITTTextBox;
    SecondarySexCharacter: TTVisual.ITTTextBox;
    Thyroid: TTVisual.ITTTextBox;
    Uterus: TTVisual.ITTTextBox;
    Vagina: TTVisual.ITTTextBox;
    Vulva: TTVisual.ITTTextBox;
    WeightPatient: TTVisual.ITTTextBox;
    public infertilityFormViewModel: InfertilityFormViewModel = new InfertilityFormViewModel();
    public get _Infertility(): Infertility {
        return this._TTObject as Infertility;
    }
    private InfertilityForm_DocumentUrl: string = '/api/InfertilityService/InfertilityForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super('INFERTILITY', 'InfertilityForm');
        this._DocumentServiceUrl = this.InfertilityForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    @Output() sendViewModelToParent: EventEmitter<InfertilityFormViewModel> = new EventEmitter<InfertilityFormViewModel>();
    @Input() set womanSpecialityObjectInfo(value: WomanSpecialityObjectInfo) {
        if (value != null) {
            if (value.WomanSpecialityObject != null && value.WomanSpecialityObject.Infertility != null) {
                if (typeof value.WomanSpecialityObject.Infertility == "string") {
                    this.ObjectID = value.WomanSpecialityObject.Infertility;
                } else {
                    this.ObjectID = value.WomanSpecialityObject.Infertility.ObjectID;
                }
            }
            if (value.ActiveIDsModel != null) {
                this.ActiveIDsModel = value.ActiveIDsModel;
            }
        }
    }
    // ***** Method declarations start *****
    //protected async PreScript() {
    //    super.PreScript();
    //    if (this.infertilityFormViewModel._Patient.Weight) {
    //        this.
    //        //this._Infertility.Patient != null && this._Infertility.Patient.Weight != event
    //        this.infertilityFormViewModel._Patient.Weight = 56;
    //    }
    //}

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Infertility();
        this.infertilityFormViewModel = new InfertilityFormViewModel();
        this._ViewModel = this.infertilityFormViewModel;
        this.infertilityFormViewModel._Infertility = this._TTObject as Infertility;
        this.infertilityFormViewModel._Infertility.Patient = new Patient();
    }

    protected loadViewModel() {
        let that = this;

        that.infertilityFormViewModel = this._ViewModel as InfertilityFormViewModel;
        that._TTObject = this.infertilityFormViewModel._Infertility;
        if (this.infertilityFormViewModel == null)
            this.infertilityFormViewModel = new InfertilityFormViewModel();
        if (this.infertilityFormViewModel._Infertility == null)
            this.infertilityFormViewModel._Infertility = new Infertility();
        let patientObjectID = that.infertilityFormViewModel._Infertility["Patient"];
        if (patientObjectID != null && (typeof patientObjectID === "string")) {
            let patient = that.infertilityFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
            if (patient) {
                that.infertilityFormViewModel._Infertility.Patient = patient;
            }
        }
        this.sendViewModelToParent.emit(that.infertilityFormViewModel);
    }


    async ngOnInit()  {
        let that = this;
        await this.load(InfertilityFormViewModel);

    }


    public onBasalUltrasoundDateChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.BasalUltrasoundDate != event) {
                this._Infertility.BasalUltrasoundDate = event;
            }
        }
    }

    public onCandidaChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Candida != event) {
                this._Infertility.Candida = event;
            }
        }
    }

    public onCervixChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Cervix != event) {
                this._Infertility.Cervix = event;
            }
        }
    }

    public onChlamdydiaChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Chlamdydia != event) {
                this._Infertility.Chlamdydia = event;
            }
        }
    }

    public onDecisionChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Decision != event) {
                this._Infertility.Decision = event;
            }
        }
    }

    public onEndometriumChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Endometrium != event) {
                this._Infertility.Endometrium = event;
            }
        }
    }

    public onHirsutismChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Hirsutism != event) {
                this._Infertility.Hirsutism = event;
            }
        }
    }

    public onLeftOvaryVolumeChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.LeftOvaryVolume != event) {
                this._Infertility.LeftOvaryVolume = event;
            }
        }
    }

    public onRightOvaryVolumeChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.RightOvaryVolume != event) {
                this._Infertility.RightOvaryVolume = event;
            }
        }
    }

    public onSecondarySexCharacterChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.SecondarySexCharacter != event) {
                this._Infertility.SecondarySexCharacter = event;
            }
        }
    }

    public onThyroidChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Thyroid != event) {
                this._Infertility.Thyroid = event;
            }
        }
    }

    public onUterusChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Uterus != event) {
                this._Infertility.Uterus = event;
            }
        }
    }

    public onVaginaChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Vagina != event) {
                this._Infertility.Vagina = event;
            }
        }
    }

    public onVulvaChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this._Infertility.Vulva != event) {
                this._Infertility.Vulva = event;
            }
        }
    }

    public onWeightPatientChanged(event): void {
        if (event != null) {
            if (this._Infertility != null && this.infertilityFormViewModel._Patient != null && this.infertilityFormViewModel._Patient.Weight != event) {
                //this._Infertility.Patient != null && this._Infertility.Patient.Weight != event
                this.infertilityFormViewModel._Patient.Weight = event;
            }

            //if (this._Infertility != null &&
            //    this._Infertility.Patient != null && this._Infertility.Patient.Weight != event) {
            //    this._Infertility.Patient.Weight = event;
            //}
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.BasalUltrasoundDate, "Value", this.__ttObject, "BasalUltrasoundDate");
        redirectProperty(this.WeightPatient, "Text", this.__ttObject, "Patient.Weight");
        redirectProperty(this.SecondarySexCharacter, "Text", this.__ttObject, "SecondarySexCharacter");
        redirectProperty(this.Thyroid, "Text", this.__ttObject, "Thyroid");
        redirectProperty(this.Hirsutism, "Text", this.__ttObject, "Hirsutism");
        redirectProperty(this.Vulva, "Text", this.__ttObject, "Vulva");
        redirectProperty(this.Vagina, "Text", this.__ttObject, "Vagina");
        redirectProperty(this.Uterus, "Text", this.__ttObject, "Uterus");
        redirectProperty(this.Cervix, "Text", this.__ttObject, "Cervix");
        redirectProperty(this.Candida, "Text", this.__ttObject, "Candida");
        redirectProperty(this.Chlamdydia, "Text", this.__ttObject, "Chlamdydia");
        redirectProperty(this.Endometrium, "Text", this.__ttObject, "Endometrium");
        redirectProperty(this.LeftOvaryVolume, "Text", this.__ttObject, "LeftOvaryVolume");
        redirectProperty(this.RightOvaryVolume, "Text", this.__ttObject, "RightOvaryVolume");
        redirectProperty(this.Decision, "Text", this.__ttObject, "Decision");
    }

    public initFormControls(): void {
        this.labelSecondarySexCharacter = new TTVisual.TTLabel();
        this.labelSecondarySexCharacter.Text = i18n("M21588", "Sekonder Sex Karakteri");
        this.labelSecondarySexCharacter.Name = "labelSecondarySexCharacter";
        this.labelSecondarySexCharacter.TabIndex = 29;

        this.SecondarySexCharacter = new TTVisual.TTTextBox();
        this.SecondarySexCharacter.Name = "SecondarySexCharacter";
        this.SecondarySexCharacter.TabIndex = 2;

        this.WeightPatient = new TTVisual.TTTextBox();
        this.WeightPatient.Required = false;
        this.WeightPatient.Name = "WeightPatient";
        this.WeightPatient.TabIndex = 1;

        this.Vulva = new TTVisual.TTTextBox();
        this.Vulva.Name = "Vulva";
        this.Vulva.TabIndex = 5;

        this.Vagina = new TTVisual.TTTextBox();
        this.Vagina.Name = "Vagina";
        this.Vagina.TabIndex = 6;

        this.Uterus = new TTVisual.TTTextBox();
        this.Uterus.Name = "Uterus";
        this.Uterus.TabIndex = 7;

        this.Thyroid = new TTVisual.TTTextBox();
        this.Thyroid.Name = "Thyroid";
        this.Thyroid.TabIndex = 3;

        this.RightOvaryVolume = new TTVisual.TTTextBox();
        this.RightOvaryVolume.Name = "RightOvaryVolume";
        this.RightOvaryVolume.TabIndex = 13;

        this.LeftOvaryVolume = new TTVisual.TTTextBox();
        this.LeftOvaryVolume.Name = "LeftOvaryVolume";
        this.LeftOvaryVolume.TabIndex = 12;

        this.Hirsutism = new TTVisual.TTTextBox();
        this.Hirsutism.Name = "Hirsutism";
        this.Hirsutism.TabIndex = 4;

        this.Endometrium = new TTVisual.TTTextBox();
        this.Endometrium.Name = "Endometrium";
        this.Endometrium.TabIndex = 11;

        this.Decision = new TTVisual.TTTextBox();
        this.Decision.Name = "Decision";
        this.Decision.TabIndex = 14;

        this.Chlamdydia = new TTVisual.TTTextBox();
        this.Chlamdydia.Name = "Chlamdydia";
        this.Chlamdydia.TabIndex = 10;

        this.Cervix = new TTVisual.TTTextBox();
        this.Cervix.Name = "Cervix";
        this.Cervix.TabIndex = 8;

        this.Candida = new TTVisual.TTTextBox();
        this.Candida.Name = "Candida";
        this.Candida.TabIndex = 9;

        this.labelWeightPatient = new TTVisual.TTLabel();
        this.labelWeightPatient.Text = "Kilo";
        this.labelWeightPatient.Name = "labelWeightPatient";
        this.labelWeightPatient.TabIndex = 27;

        this.labelVulva = new TTVisual.TTLabel();
        this.labelVulva.Text = "Vulva";
        this.labelVulva.Name = "labelVulva";
        this.labelVulva.TabIndex = 25;

        this.labelVagina = new TTVisual.TTLabel();
        this.labelVagina.Text = i18n("M24011", "Vajina");
        this.labelVagina.Name = "labelVagina";
        this.labelVagina.TabIndex = 23;

        this.labelUterus = new TTVisual.TTLabel();
        this.labelUterus.Text = "Uterus";
        this.labelUterus.Name = "labelUterus";
        this.labelUterus.TabIndex = 21;

        this.labelThyroid = new TTVisual.TTLabel();
        this.labelThyroid.Text = i18n("M23463", "Tiroid");
        this.labelThyroid.Name = "labelThyroid";
        this.labelThyroid.TabIndex = 19;

        this.labelRightOvaryVolume = new TTVisual.TTLabel();
        this.labelRightOvaryVolume.Text = i18n("M21136", "Sağ Over Hacmi");
        this.labelRightOvaryVolume.Name = "labelRightOvaryVolume";
        this.labelRightOvaryVolume.TabIndex = 17;

        this.labelLeftOvaryVolume = new TTVisual.TTLabel();
        this.labelLeftOvaryVolume.Text = i18n("M22010", "Sol Over Hacmi");
        this.labelLeftOvaryVolume.Name = "labelLeftOvaryVolume";
        this.labelLeftOvaryVolume.TabIndex = 15;

        this.labelHirsutism = new TTVisual.TTLabel();
        this.labelHirsutism.Text = i18n("M15812", "Hirsutismus");
        this.labelHirsutism.Name = "labelHirsutism";
        this.labelHirsutism.TabIndex = 13;

        this.labelEndometrium = new TTVisual.TTLabel();
        this.labelEndometrium.Text = "Endometrium";
        this.labelEndometrium.Name = "labelEndometrium";
        this.labelEndometrium.TabIndex = 11;

        this.labelDecision = new TTVisual.TTLabel();
        this.labelDecision.Text = i18n("M17270", "Karar");
        this.labelDecision.Name = "labelDecision";
        this.labelDecision.TabIndex = 9;

        this.labelChlamdydia = new TTVisual.TTLabel();
        this.labelChlamdydia.Text = "Chlamdydia";
        this.labelChlamdydia.Name = "labelChlamdydia";
        this.labelChlamdydia.TabIndex = 7;

        this.labelCervix = new TTVisual.TTLabel();
        this.labelCervix.Text = i18n("M21661", "Serviks");
        this.labelCervix.Name = "labelCervix";
        this.labelCervix.TabIndex = 5;

        this.labelCandida = new TTVisual.TTLabel();
        this.labelCandida.Text = "Candida";
        this.labelCandida.Name = "labelCandida";
        this.labelCandida.TabIndex = 3;

        this.labelBasalUltrasoundDate = new TTVisual.TTLabel();
        this.labelBasalUltrasoundDate.Text = i18n("M11675", "Bazal Ultrason Tarihi");
        this.labelBasalUltrasoundDate.Name = "labelBasalUltrasoundDate";
        this.labelBasalUltrasoundDate.TabIndex = 1;

        this.BasalUltrasoundDate = new TTVisual.TTDateTimePicker();
        this.BasalUltrasoundDate.CustomFormat = "dd.MM.yyyy";
        this.BasalUltrasoundDate.Format = DateTimePickerFormat.Custom;
        this.BasalUltrasoundDate.Name = "BasalUltrasoundDate";
        this.BasalUltrasoundDate.TabIndex = 0;

        this.Controls = [this.labelSecondarySexCharacter, this.SecondarySexCharacter, this.WeightPatient, this.Vulva, this.Vagina, this.Uterus, this.Thyroid, this.RightOvaryVolume, this.LeftOvaryVolume, this.Hirsutism, this.Endometrium, this.Decision, this.Chlamdydia, this.Cervix, this.Candida, this.labelWeightPatient, this.labelVulva, this.labelVagina, this.labelUterus, this.labelThyroid, this.labelRightOvaryVolume, this.labelLeftOvaryVolume, this.labelHirsutism, this.labelEndometrium, this.labelDecision, this.labelChlamdydia, this.labelCervix, this.labelCandida, this.labelBasalUltrasoundDate, this.BasalUltrasoundDate];

    }


}
