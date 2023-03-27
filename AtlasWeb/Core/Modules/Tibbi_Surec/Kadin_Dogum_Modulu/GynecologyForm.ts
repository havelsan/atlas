//$E24A3F6A
import { Component, OnInit, Output, EventEmitter, NgZone } from '@angular/core';
import { GynecologyFormViewModel } from "./GynecologyFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Gynecology } from 'NebulaClient/Model/AtlasClientModel';

import { ReproductiveAbnormalityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";



@Component({
    selector: 'GynecologyForm',
    templateUrl: './GynecologyForm.html',
    providers: [MessageService]
})
export class GynecologyForm extends TTVisual.TTForm implements OnInit {
    BasalUltrasound: TTVisual.ITTTextBox;
    Cervix: TTVisual.ITTTextBox;
    CurrentBirthControlMethod: TTVisual.ITTEnumComboBox;
    Dyspareunia: TTVisual.ITTCheckBox;
    DyspareuniaInformation: TTVisual.ITTTextBox;
    Dysuria: TTVisual.ITTCheckBox;
    DysuriaInformation: TTVisual.ITTTextBox;
    GenitalAbnormalities: TTVisual.ITTEnumComboBox;
    GenitalAbnormalitiesInfo: TTVisual.ITTTextBox;
    GenitalExamination: TTVisual.ITTTextBox;
    GynecologicalHistory: TTVisual.ITTTextBox;
    Hirsutism: TTVisual.ITTCheckBox;
    HirsutismInformation: TTVisual.ITTTextBox;
    labelBasalUltrasound: TTVisual.ITTLabel;
    labelCervix: TTVisual.ITTLabel;
    labelCurrentBirthControlMethod: TTVisual.ITTLabel;
    labelDyspareuniaInformation: TTVisual.ITTLabel;
    labelDysuriaInformation: TTVisual.ITTLabel;
    labelGenitalAbnormalities: TTVisual.ITTLabel;
    labelGenitalAbnormalitiesInfo: TTVisual.ITTLabel;
    labelGenitalExamination: TTVisual.ITTLabel;
    labelGynecologicalHistory: TTVisual.ITTLabel;
    labelHirsutismInformation: TTVisual.ITTLabel;
    labelLastExaminationDate: TTVisual.ITTLabel;
    labelLastSmearDate: TTVisual.ITTLabel;
    labelMenstrualCycleAbnormalities: TTVisual.ITTLabel;
    labelMenstrualCycleInformation: TTVisual.ITTLabel;
    labelPelvicExamination: TTVisual.ITTLabel;
    labelPreviousBirthControlMethod: TTVisual.ITTLabel;
    labelReproductiveAbnormalitiesInfo: TTVisual.ITTLabel;
    labelReproductiveAbnormality: TTVisual.ITTLabel;
    labelTumorMarkers: TTVisual.ITTLabel;
    labelUterus: TTVisual.ITTLabel;
    labelVaginalDischargeInformation: TTVisual.ITTLabel;
    labelVulvaVagen: TTVisual.ITTLabel;
    LastExaminationDate: TTVisual.ITTDateTimePicker;
    LastSmearDate: TTVisual.ITTDateTimePicker;
    MenstrualCycleAbnormalities: TTVisual.ITTEnumComboBox;
    MenstrualCycleInformation: TTVisual.ITTTextBox;
    PelvicExamination: TTVisual.ITTTextBox;
    PreviousBirthControlMethod: TTVisual.ITTEnumComboBox;
    ReproductiveAbnormalitiesInfo: TTVisual.ITTTextBox;
    ReproductiveAbnormality: TTVisual.ITTObjectListBox;
    TumorMarkers: TTVisual.ITTTextBox;
    Uterus: TTVisual.ITTTextBox;
    VaginalDischarge: TTVisual.ITTCheckBox;
    VaginalDischargeInformation: TTVisual.ITTTextBox;
    VulvaVagen: TTVisual.ITTTextBox;
    public gynecologyFormViewModel: GynecologyFormViewModel = new GynecologyFormViewModel();
    public get _Gynecology(): Gynecology {
        return this._TTObject as Gynecology;
    }
    private GynecologyForm_DocumentUrl: string = '/api/GynecologyService/GynecologyForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("GYNECOLOGY", "GynecologyForm");
        this._DocumentServiceUrl = this.GynecologyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    @Output() sendViewModelToParent: EventEmitter<GynecologyFormViewModel> = new EventEmitter<GynecologyFormViewModel>();


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Gynecology();
        this.gynecologyFormViewModel = new GynecologyFormViewModel();
        this._ViewModel = this.gynecologyFormViewModel;
        this.gynecologyFormViewModel._Gynecology = this._TTObject as Gynecology;
        this.gynecologyFormViewModel._Gynecology.ReproductiveAbnormality = new ReproductiveAbnormalityDefinition();
    }

    protected loadViewModel() {
        let that = this;
        that.gynecologyFormViewModel = this._ViewModel as GynecologyFormViewModel;
        that._TTObject = this.gynecologyFormViewModel._Gynecology;
        if (this.gynecologyFormViewModel == null)
            this.gynecologyFormViewModel = new GynecologyFormViewModel();
        if (this.gynecologyFormViewModel._Gynecology == null)
            this.gynecologyFormViewModel._Gynecology = new Gynecology();
        let reproductiveAbnormalityObjectID = that.gynecologyFormViewModel._Gynecology["ReproductiveAbnormality"];
        if (reproductiveAbnormalityObjectID != null && (typeof reproductiveAbnormalityObjectID === 'string')) {
            let reproductiveAbnormality = that.gynecologyFormViewModel.ReproductiveAbnormalityDefinitions.find(o => o.ObjectID.toString() === reproductiveAbnormalityObjectID.toString());
             if (reproductiveAbnormality) {
                that.gynecologyFormViewModel._Gynecology.ReproductiveAbnormality = reproductiveAbnormality;
            }
        }
        this.sendViewModelToParent.emit(that.gynecologyFormViewModel);
    }


    async ngOnInit()  {
        let that = this;
        await this.load(GynecologyFormViewModel);
  
    }


    public onBasalUltrasoundChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.BasalUltrasound != event) {
                this._Gynecology.BasalUltrasound = event;
            }
        }
    }

    public onCervixChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.Cervix != event) {
                this._Gynecology.Cervix = event;
            }
        }
    }

    public onCurrentBirthControlMethodChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.CurrentBirthControlMethod != event) {
                this._Gynecology.CurrentBirthControlMethod = event;
            }
        }
    }

    public onDyspareuniaChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.Dyspareunia != event) {
                this._Gynecology.Dyspareunia = event;
            }
        }
    }

    public onDyspareuniaInformationChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.DyspareuniaInformation != event) {
                this._Gynecology.DyspareuniaInformation = event;
            }
        }
    }

    public onDysuriaChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.Dysuria != event) {
                this._Gynecology.Dysuria = event;
            }
        }
    }

    public onDysuriaInformationChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.DysuriaInformation != event) {
                this._Gynecology.DysuriaInformation = event;
            }
        }
    }

    public onGenitalAbnormalitiesChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.GenitalAbnormalities != event) {
                this._Gynecology.GenitalAbnormalities = event;
            }
        }
    }

    public onGenitalAbnormalitiesInfoChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.GenitalAbnormalitiesInfo != event) {
                this._Gynecology.GenitalAbnormalitiesInfo = event;
            }
        }
    }

    public onGenitalExaminationChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.GenitalExamination != event) {
                this._Gynecology.GenitalExamination = event;
            }
        }
    }

    public onGynecologicalHistoryChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.GynecologicalHistory != event) {
                this._Gynecology.GynecologicalHistory = event;
            }
        }
    }

    public onHirsutismChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.Hirsutism != event) {
                this._Gynecology.Hirsutism = event;
            }
        }
    }

    public onHirsutismInformationChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.HirsutismInformation != event) {
                this._Gynecology.HirsutismInformation = event;
            }
        }
    }

    public onLastExaminationDateChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.LastExaminationDate != event) {
                this._Gynecology.LastExaminationDate = event;
            }
        }
    }

    public onLastSmearDateChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.LastSmearDate != event) {
                this._Gynecology.LastSmearDate = event;
            }
        }
    }

    public onMenstrualCycleAbnormalitiesChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.MenstrualCycleAbnormalities != event) {
                this._Gynecology.MenstrualCycleAbnormalities = event;
            }
        }
    }

    public onMenstrualCycleInformationChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.MenstrualCycleInformation != event) {
                this._Gynecology.MenstrualCycleInformation = event;
            }
        }
    }

    public onPelvicExaminationChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.PelvicExamination != event) {
                this._Gynecology.PelvicExamination = event;
            }
        }
    }

    public onPreviousBirthControlMethodChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.PreviousBirthControlMethod != event) {
                this._Gynecology.PreviousBirthControlMethod = event;
            }
        }
    }

    public onReproductiveAbnormalitiesInfoChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.ReproductiveAbnormalitiesInfo != event) {
                this._Gynecology.ReproductiveAbnormalitiesInfo = event;
            }
        }
    }

    public onReproductiveAbnormalityChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.ReproductiveAbnormality != event) {
                this._Gynecology.ReproductiveAbnormality = event;
            }
        }
    }

    public onTumorMarkersChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.TumorMarkers != event) {
                this._Gynecology.TumorMarkers = event;
            }
        }
    }

    public onUterusChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.Uterus != event) {
                this._Gynecology.Uterus = event;
            }
        }
    }

    public onVaginalDischargeChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.VaginalDischarge != event) {
                this._Gynecology.VaginalDischarge = event;
            }
        }
    }

    public onVaginalDischargeInformationChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.VaginalDischargeInformation != event) {
                this._Gynecology.VaginalDischargeInformation = event;
            }
        }
    }

    public onVulvaVagenChanged(event): void {
        if (event != null) {
            if (this._Gynecology != null && this._Gynecology.VulvaVagen != event) {
                this._Gynecology.VulvaVagen = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.LastExaminationDate, "Value", this.__ttObject, "LastExaminationDate");
        redirectProperty(this.LastSmearDate, "Value", this.__ttObject, "LastSmearDate");
        redirectProperty(this.PreviousBirthControlMethod, "Value", this.__ttObject, "PreviousBirthControlMethod");
        redirectProperty(this.CurrentBirthControlMethod, "Value", this.__ttObject, "CurrentBirthControlMethod");
        redirectProperty(this.GenitalAbnormalities, "Value", this.__ttObject, "GenitalAbnormalities");
        redirectProperty(this.GenitalAbnormalitiesInfo, "Text", this.__ttObject, "GenitalAbnormalitiesInfo");
        redirectProperty(this.MenstrualCycleAbnormalities, "Value", this.__ttObject, "MenstrualCycleAbnormalities");
        redirectProperty(this.MenstrualCycleInformation, "Text", this.__ttObject, "MenstrualCycleInformation");
        redirectProperty(this.ReproductiveAbnormalitiesInfo, "Text", this.__ttObject, "ReproductiveAbnormalitiesInfo");
        redirectProperty(this.GynecologicalHistory, "Text", this.__ttObject, "GynecologicalHistory");
        redirectProperty(this.GenitalExamination, "Text", this.__ttObject, "GenitalExamination");
        redirectProperty(this.PelvicExamination, "Text", this.__ttObject, "PelvicExamination");
        redirectProperty(this.VulvaVagen, "Text", this.__ttObject, "VulvaVagen");
        redirectProperty(this.Cervix, "Text", this.__ttObject, "Cervix");
        redirectProperty(this.Uterus, "Text", this.__ttObject, "Uterus");
        redirectProperty(this.BasalUltrasound, "Text", this.__ttObject, "BasalUltrasound");
        redirectProperty(this.TumorMarkers, "Text", this.__ttObject, "TumorMarkers");
        redirectProperty(this.Dysuria, "Value", this.__ttObject, "Dysuria");
        redirectProperty(this.DysuriaInformation, "Text", this.__ttObject, "DysuriaInformation");
        redirectProperty(this.Dyspareunia, "Value", this.__ttObject, "Dyspareunia");
        redirectProperty(this.DyspareuniaInformation, "Text", this.__ttObject, "DyspareuniaInformation");
        redirectProperty(this.Hirsutism, "Value", this.__ttObject, "Hirsutism");
        redirectProperty(this.HirsutismInformation, "Text", this.__ttObject, "HirsutismInformation");
        redirectProperty(this.VaginalDischarge, "Value", this.__ttObject, "VaginalDischarge");
        redirectProperty(this.VaginalDischargeInformation, "Text", this.__ttObject, "VaginalDischargeInformation");
    }

    public initFormControls(): void {
        this.labelReproductiveAbnormality = new TTVisual.TTLabel();
        this.labelReproductiveAbnormality.Text = i18n("M23942", "Üreme Organı Anomalisi");
        this.labelReproductiveAbnormality.Name = "labelReproductiveAbnormality";
        this.labelReproductiveAbnormality.TabIndex = 50;

        this.ReproductiveAbnormality = new TTVisual.TTObjectListBox();
        this.ReproductiveAbnormality.ListDefName = "ReproductiveAbnormalityList";
        this.ReproductiveAbnormality.Name = "ReproductiveAbnormality";
        this.ReproductiveAbnormality.TabIndex = 8;

        this.labelVulvaVagen = new TTVisual.TTLabel();
        this.labelVulvaVagen.Text = i18n("M24186", "Vulva Vagen");
        this.labelVulvaVagen.Name = "labelVulvaVagen";
        this.labelVulvaVagen.TabIndex = 45;

        this.VulvaVagen = new TTVisual.TTTextBox();
        this.VulvaVagen.Name = "VulvaVagen";
        this.VulvaVagen.TabIndex = 13;

        this.VaginalDischargeInformation = new TTVisual.TTTextBox();
        this.VaginalDischargeInformation.Name = "VaginalDischargeInformation";
        this.VaginalDischargeInformation.TabIndex = 25;

        this.Uterus = new TTVisual.TTTextBox();
        this.Uterus.Name = "Uterus";
        this.Uterus.TabIndex = 15;

        this.TumorMarkers = new TTVisual.TTTextBox();
        this.TumorMarkers.Name = "TumorMarkers";
        this.TumorMarkers.TabIndex = 17;

        this.ReproductiveAbnormalitiesInfo = new TTVisual.TTTextBox();
        this.ReproductiveAbnormalitiesInfo.Name = "ReproductiveAbnormalitiesInfo";
        this.ReproductiveAbnormalitiesInfo.TabIndex = 9;

        this.PelvicExamination = new TTVisual.TTTextBox();
        this.PelvicExamination.Name = "PelvicExamination";
        this.PelvicExamination.TabIndex = 12;

        this.MenstrualCycleInformation = new TTVisual.TTTextBox();
        this.MenstrualCycleInformation.Name = "MenstrualCycleInformation";
        this.MenstrualCycleInformation.TabIndex = 7;

        this.HirsutismInformation = new TTVisual.TTTextBox();
        this.HirsutismInformation.Name = "HirsutismInformation";
        this.HirsutismInformation.TabIndex = 23;

        this.GynecologicalHistory = new TTVisual.TTTextBox();
        this.GynecologicalHistory.Name = "GynecologicalHistory";
        this.GynecologicalHistory.TabIndex = 10;

        this.GenitalExamination = new TTVisual.TTTextBox();
        this.GenitalExamination.Name = "GenitalExamination";
        this.GenitalExamination.TabIndex = 11;

        this.GenitalAbnormalitiesInfo = new TTVisual.TTTextBox();
        this.GenitalAbnormalitiesInfo.Name = "GenitalAbnormalitiesInfo";
        this.GenitalAbnormalitiesInfo.TabIndex = 5;

        this.DysuriaInformation = new TTVisual.TTTextBox();
        this.DysuriaInformation.Name = "DysuriaInformation";
        this.DysuriaInformation.TabIndex = 19;

        this.DyspareuniaInformation = new TTVisual.TTTextBox();
        this.DyspareuniaInformation.Name = "DyspareuniaInformation";
        this.DyspareuniaInformation.TabIndex = 21;

        this.Cervix = new TTVisual.TTTextBox();
        this.Cervix.Name = "Cervix";
        this.Cervix.TabIndex = 14;

        this.BasalUltrasound = new TTVisual.TTTextBox();
        this.BasalUltrasound.Name = "BasalUltrasound";
        this.BasalUltrasound.TabIndex = 16;

        this.labelVaginalDischargeInformation = new TTVisual.TTLabel();
        this.labelVaginalDischargeInformation.Text = i18n("M24013", "Vajinal Akıntı Açıklama");
        this.labelVaginalDischargeInformation.Name = "labelVaginalDischargeInformation";
        this.labelVaginalDischargeInformation.TabIndex = 43;

        this.VaginalDischarge = new TTVisual.TTCheckBox();
        this.VaginalDischarge.Value = false;
        this.VaginalDischarge.Text = i18n("M24012", "Vajinal Akıntı");
        this.VaginalDischarge.Title = i18n("M24012", "Vajinal Akıntı");
        this.VaginalDischarge.Name = "VaginalDischarge";
        this.VaginalDischarge.TabIndex = 24;

        this.labelUterus = new TTVisual.TTLabel();
        this.labelUterus.Text = "Uterus";
        this.labelUterus.Name = "labelUterus";
        this.labelUterus.TabIndex = 40;

        this.labelTumorMarkers = new TTVisual.TTLabel();
        this.labelTumorMarkers.Text = i18n("M23652", "Tümör Belirleyiciler");
        this.labelTumorMarkers.Name = "labelTumorMarkers";
        this.labelTumorMarkers.TabIndex = 38;

        this.labelReproductiveAbnormalitiesInfo = new TTVisual.TTLabel();
        this.labelReproductiveAbnormalitiesInfo.Text = i18n("M23939", "Üreme Organı Anomalileri Açıklama");
        this.labelReproductiveAbnormalitiesInfo.Name = "labelReproductiveAbnormalitiesInfo";
        this.labelReproductiveAbnormalitiesInfo.TabIndex = 36;

        this.labelPreviousBirthControlMethod = new TTVisual.TTLabel();
        this.labelPreviousBirthControlMethod.Text = i18n("M20005", "Önceki Doğum Kontrol Yöntemi");
        this.labelPreviousBirthControlMethod.Name = "labelPreviousBirthControlMethod";
        this.labelPreviousBirthControlMethod.TabIndex = 34;

        this.PreviousBirthControlMethod = new TTVisual.TTEnumComboBox();
        this.PreviousBirthControlMethod.DataTypeName = "BirthControlMethodEnum";
        this.PreviousBirthControlMethod.Name = "PreviousBirthControlMethod";
        this.PreviousBirthControlMethod.TabIndex = 2;

        this.labelPelvicExamination = new TTVisual.TTLabel();
        this.labelPelvicExamination.Text = i18n("M20292", "Pelvik Muayene");
        this.labelPelvicExamination.Name = "labelPelvicExamination";
        this.labelPelvicExamination.TabIndex = 32;

        this.labelMenstrualCycleInformation = new TTVisual.TTLabel();
        this.labelMenstrualCycleInformation.Text = i18n("M18880", "Menstural Siklus Açıklama");
        this.labelMenstrualCycleInformation.Name = "labelMenstrualCycleInformation";
        this.labelMenstrualCycleInformation.TabIndex = 30;

        this.labelMenstrualCycleAbnormalities = new TTVisual.TTLabel();
        this.labelMenstrualCycleAbnormalities.Text = i18n("M18881", "Menstural Siklus Anomalisi");
        this.labelMenstrualCycleAbnormalities.Name = "labelMenstrualCycleAbnormalities";
        this.labelMenstrualCycleAbnormalities.TabIndex = 28;

        this.MenstrualCycleAbnormalities = new TTVisual.TTEnumComboBox();
        this.MenstrualCycleAbnormalities.DataTypeName = "MenstrualCycleAbnormalitiesEnum";
        this.MenstrualCycleAbnormalities.Name = "MenstrualCycleAbnormalities";
        this.MenstrualCycleAbnormalities.TabIndex = 6;

        this.labelLastSmearDate = new TTVisual.TTLabel();
        this.labelLastSmearDate.Text = i18n("M22065", "Son Smear Tarihi");
        this.labelLastSmearDate.Name = "labelLastSmearDate";
        this.labelLastSmearDate.TabIndex = 26;

        this.LastSmearDate = new TTVisual.TTDateTimePicker();
        this.LastSmearDate.CustomFormat = "dd.MM.yyyy";
        this.LastSmearDate.Format = DateTimePickerFormat.Custom;
        this.LastSmearDate.Name = "LastSmearDate";
        this.LastSmearDate.TabIndex = 1;

        this.labelLastExaminationDate = new TTVisual.TTLabel();
        this.labelLastExaminationDate.Text = i18n("M22051", "Son Jinekolojik Muayene Tarihi");
        this.labelLastExaminationDate.Name = "labelLastExaminationDate";
        this.labelLastExaminationDate.TabIndex = 24;

        this.LastExaminationDate = new TTVisual.TTDateTimePicker();
        this.LastExaminationDate.CustomFormat = "dd.MM.yyyy";
        this.LastExaminationDate.Format = DateTimePickerFormat.Custom;
        this.LastExaminationDate.Name = "LastExaminationDate";
        this.LastExaminationDate.TabIndex = 0;

        this.labelHirsutismInformation = new TTVisual.TTLabel();
        this.labelHirsutismInformation.Text = i18n("M23683", "Tüylenme Açıklama");
        this.labelHirsutismInformation.Name = "labelHirsutismInformation";
        this.labelHirsutismInformation.TabIndex = 22;

        this.Hirsutism = new TTVisual.TTCheckBox();
        this.Hirsutism.Value = false;
        this.Hirsutism.Text = i18n("M23682", "Tüylenme");
        this.Hirsutism.Title = i18n("M23682", "Tüylenme");
        this.Hirsutism.Name = "Hirsutism";
        this.Hirsutism.TabIndex = 22;

        this.labelGynecologicalHistory = new TTVisual.TTLabel();
        this.labelGynecologicalHistory.Text = i18n("M16994", "Jinekolojik Anamnez");
        this.labelGynecologicalHistory.Name = "labelGynecologicalHistory";
        this.labelGynecologicalHistory.TabIndex = 19;

        this.labelGenitalExamination = new TTVisual.TTLabel();
        this.labelGenitalExamination.Text = i18n("M14735", "Genital Bölge Muayene");
        this.labelGenitalExamination.Name = "labelGenitalExamination";
        this.labelGenitalExamination.TabIndex = 17;

        this.labelGenitalAbnormalitiesInfo = new TTVisual.TTLabel();
        this.labelGenitalAbnormalitiesInfo.Text = i18n("M14734", "Genital Bölge Anomalisi Açıklama");
        this.labelGenitalAbnormalitiesInfo.Name = "labelGenitalAbnormalitiesInfo";
        this.labelGenitalAbnormalitiesInfo.TabIndex = 15;

        this.labelGenitalAbnormalities = new TTVisual.TTLabel();
        this.labelGenitalAbnormalities.Text = i18n("M14733", "Genital Bölge Anomalisi");
        this.labelGenitalAbnormalities.Name = "labelGenitalAbnormalities";
        this.labelGenitalAbnormalities.TabIndex = 13;

        this.GenitalAbnormalities = new TTVisual.TTEnumComboBox();
        this.GenitalAbnormalities.DataTypeName = "GenitalAbnormalitiesEnum";
        this.GenitalAbnormalities.Name = "GenitalAbnormalities";
        this.GenitalAbnormalities.TabIndex = 4;

        this.labelDysuriaInformation = new TTVisual.TTLabel();
        this.labelDysuriaInformation.Text = i18n("M16194", "İdrar Yaparken Ağrı/Yanma Açıklama");
        this.labelDysuriaInformation.Name = "labelDysuriaInformation";
        this.labelDysuriaInformation.TabIndex = 11;

        this.Dysuria = new TTVisual.TTCheckBox();
        this.Dysuria.Value = false;
        this.Dysuria.Text = i18n("M16193", "İdrar Yaparken Ağrı/Yanma");
        this.Dysuria.Title = i18n("M16193", "İdrar Yaparken Ağrı/Yanma");
        this.Dysuria.Name = "Dysuria";
        this.Dysuria.TabIndex = 18;

        this.labelDyspareuniaInformation = new TTVisual.TTLabel();
        this.labelDyspareuniaInformation.Text = i18n("M12261", "Cinsel İlişki Sırasında Ağrı,Kanama Açıklama");
        this.labelDyspareuniaInformation.Name = "labelDyspareuniaInformation";
        this.labelDyspareuniaInformation.TabIndex = 8;

        this.Dyspareunia = new TTVisual.TTCheckBox();
        this.Dyspareunia.Value = false;
        this.Dyspareunia.Text = i18n("M12260", "Cinsel İlişki Sırasında Ağrı,Kanama");
        this.Dyspareunia.Title = i18n("M12260", "Cinsel İlişki Sırasında Ağrı,Kanama");
        this.Dyspareunia.Name = "Dyspareunia";
        this.Dyspareunia.TabIndex = 20;

        this.labelCurrentBirthControlMethod = new TTVisual.TTLabel();
        this.labelCurrentBirthControlMethod.Text = i18n("M15004", "Güncel Doğum Kontrol Yöntemi");
        this.labelCurrentBirthControlMethod.Name = "labelCurrentBirthControlMethod";
        this.labelCurrentBirthControlMethod.TabIndex = 5;

        this.CurrentBirthControlMethod = new TTVisual.TTEnumComboBox();
        this.CurrentBirthControlMethod.DataTypeName = "BirthControlMethodEnum";
        this.CurrentBirthControlMethod.Name = "CurrentBirthControlMethod";
        this.CurrentBirthControlMethod.TabIndex = 3;

        this.labelCervix = new TTVisual.TTLabel();
        this.labelCervix.Text = i18n("M21661", "Serviks");
        this.labelCervix.Name = "labelCervix";
        this.labelCervix.TabIndex = 3;

        this.labelBasalUltrasound = new TTVisual.TTLabel();
        this.labelBasalUltrasound.Text = i18n("M11674", "Bazal Ultrason");
        this.labelBasalUltrasound.Name = "labelBasalUltrasound";
        this.labelBasalUltrasound.TabIndex = 1;

        this.Controls = [this.labelReproductiveAbnormality, this.ReproductiveAbnormality, this.labelVulvaVagen, this.VulvaVagen, this.VaginalDischargeInformation, this.Uterus, this.TumorMarkers, this.ReproductiveAbnormalitiesInfo, this.PelvicExamination, this.MenstrualCycleInformation, this.HirsutismInformation, this.GynecologicalHistory, this.GenitalExamination, this.GenitalAbnormalitiesInfo, this.DysuriaInformation, this.DyspareuniaInformation, this.Cervix, this.BasalUltrasound, this.labelVaginalDischargeInformation, this.VaginalDischarge, this.labelUterus, this.labelTumorMarkers, this.labelReproductiveAbnormalitiesInfo, this.labelPreviousBirthControlMethod, this.PreviousBirthControlMethod, this.labelPelvicExamination, this.labelMenstrualCycleInformation, this.labelMenstrualCycleAbnormalities, this.MenstrualCycleAbnormalities, this.labelLastSmearDate, this.LastSmearDate, this.labelLastExaminationDate, this.LastExaminationDate, this.labelHirsutismInformation, this.Hirsutism, this.labelGynecologicalHistory, this.labelGenitalExamination, this.labelGenitalAbnormalitiesInfo, this.labelGenitalAbnormalities, this.GenitalAbnormalities, this.labelDysuriaInformation, this.Dysuria, this.labelDyspareuniaInformation, this.Dyspareunia, this.labelCurrentBirthControlMethod, this.CurrentBirthControlMethod, this.labelCervix, this.labelBasalUltrasound];

    }


}
