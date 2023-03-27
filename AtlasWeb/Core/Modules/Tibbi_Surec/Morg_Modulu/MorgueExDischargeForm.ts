//$E84DC79F
import { Component, OnInit, NgZone } from '@angular/core';
import { MorgueExDischargeFormViewModel } from './MorgueExDischargeFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Morgue } from 'NebulaClient/Model/AtlasClientModel';
import { DeathReasonDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { MernisDeathReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MorgueDeathType } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOlumNedeniTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOlumYeri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYaralanmaninYeri } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'MorgueExDischargeForm',
    templateUrl: './MorgueExDischargeForm.html',
    providers: [MessageService]
})
export class MorgueExDischargeForm extends TTVisual.TTForm implements OnInit {
    AutopsyToDo: TTVisual.ITTCheckBox;
    DateOfDeathReport: TTVisual.ITTDateTimePicker;
    DateTimeOfDeath: TTVisual.ITTDateTimePicker;
    DeathReasonDiagnosis: TTVisual.ITTGrid;
    DeathReasonEvaluation: TTVisual.ITTRichTextBoxControl;
    DiedClinic: TTVisual.ITTObjectListBox;
    DoctorFixed: TTVisual.ITTObjectListBox;
    ExternalDoctorFixed: TTVisual.ITTTextBox;
    ExternalDoctorFixedUniqueNo: TTVisual.ITTTextBox;
    ExternalSenderDoctorMorgueUnR: TTVisual.ITTTextBox;
    ExternalSenderDoctorToMorgue: TTVisual.ITTTextBox;
    InjuryDate: TTVisual.ITTDateTimePicker;
    InjuryExisting: TTVisual.ITTCheckBox;
    labelDateOfDeathReport: TTVisual.ITTLabel;
    labelDateTimeOfDeath: TTVisual.ITTLabel;
    labelDeathReason: TTVisual.ITTLabel;
    labelDeathReasonEvaluation: TTVisual.ITTLabel;
    labelDiedClinic: TTVisual.ITTLabel;
    labelDoctorFixed: TTVisual.ITTLabel;
    labelExternalDoctorFixed: TTVisual.ITTLabel;
    labelExternalDoctorFixedUniqueNo: TTVisual.ITTLabel;
    labelExternalSenderDoctorMorgueUnR: TTVisual.ITTLabel;
    labelExternalSenderDoctorToMorgue: TTVisual.ITTLabel;
    labelInjuryDate: TTVisual.ITTLabel;
    labelMernisDeathReasons: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    labelNurse: TTVisual.ITTLabel;
    labelSenderDoctor: TTVisual.ITTLabel;
    labelSKRSDeathPlace: TTVisual.ITTLabel;
    labelSKRSDeathReason: TTVisual.ITTLabel;
    labelSKRSInjuryPlace: TTVisual.ITTLabel;
    MernisDeathReasons: TTVisual.ITTObjectListBox;
    MorgueDeathType: TTVisual.ITTGrid;
    MorgueMorgueDeathType: TTVisual.ITTListBoxColumn;
    Note: TTVisual.ITTRichTextBoxControl;
    Nurse: TTVisual.ITTObjectListBox;
    PatientCameEx: TTVisual.ITTCheckBox;
    SenderDoctor: TTVisual.ITTObjectListBox;
    SendToMorgue: TTVisual.ITTCheckBox;
    SKRSDeathPlace: TTVisual.ITTObjectListBox;
    SKRSDeathReason: TTVisual.ITTObjectListBox;
    SKRSICDDeathReasonDiagnosis: TTVisual.ITTListBoxColumn;
    SKRSInjuryPlace: TTVisual.ITTObjectListBox;
    SKRSOlumNedeniTuruDeathReasonDiagnosis: TTVisual.ITTListBoxColumn;
    SKRSOlumSekliMorgueDeathType: TTVisual.ITTListBoxColumn;
    patientExComeVisibility: boolean = false;
    injuryExisting: boolean = false;
    ttlabel1: TTVisual.ITTLabel;
    DeathTypeList: TTVisual.ITTObjectListBox;
    DeathReasonList: TTVisual.ITTObjectListBox;
    _FromDischarge: boolean = false;

    DeathTypeListColumns = [
        {
            caption: i18n("M19942", "Ölüm Şekli"),
            dataField: 'ADI',
            allowEditing: false,
            allowSorting: false,
            allowDeleting: true,
            fixed: true,
            width: '90%'
        }];

    DeathReasonListColumns = [];
    olumSekliArray: Array<any> = [];
    olumSekliCache: any;
    taniArray: Array<any> = [];
    taniCache: any;
    olumNedeniArray: Array<any> = [];
    olumNedeniCache: any;

    public DeathReasonDiagnosisColumns = [];
    public MorgueDeathTypeColumns = [];
    public morgueExDischargeFormViewModel: MorgueExDischargeFormViewModel = new MorgueExDischargeFormViewModel();
    public get _Morgue(): Morgue {
        return this._TTObject as Morgue;
    }
    private MorgueExDischargeForm_DocumentUrl: string = '/api/MorgueService/MorgueExDischargeForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalStateService: ModalStateService,
        protected ngZone: NgZone) {
        super('MORGUE', 'MorgueExDischargeForm');
        this._DocumentServiceUrl = this.MorgueExDischargeForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    async save() {
        if (this.morgueExDischargeFormViewModel._Morgue.DeathReasonDiagnosis.length > 0) {
            if (this.morgueExDischargeFormViewModel._Morgue.MorgueDeathType.length > 0) {
                if (this.morgueExDischargeFormViewModel._Morgue.SKRSDeathPlace != null) {
                    if (this.morgueExDischargeFormViewModel._Morgue.SKRSDeathReason != null) {
                        super.save();
                    } else {
                        TTVisual.InfoBox.Alert("Ölüm Nedeni Türü Alanı Boş Olamaz.!");
                    }
                } else {
                    TTVisual.InfoBox.Alert("Ölüm Yeri Alanı Boş Olamaz.!");
                }
            } else {
                TTVisual.InfoBox.Alert("En Az 1 adet Ölüm Şekli Bilgisi Seçiniz.!");
            }
        } else {
            TTVisual.InfoBox.Alert("En Az 1 adet Ölüm Nedeni Tanı Bilgisi Seçiniz.!");
        }
    }


    public initViewModel(): void {
        this._TTObject = new Morgue();
        this.morgueExDischargeFormViewModel = new MorgueExDischargeFormViewModel();
        this._ViewModel = this.morgueExDischargeFormViewModel;
        this.morgueExDischargeFormViewModel._Morgue = this._TTObject as Morgue;
        this.morgueExDischargeFormViewModel._Morgue.MorgueDeathType = new Array<MorgueDeathType>();
        this.morgueExDischargeFormViewModel._Morgue.DeathReasonDiagnosis = new Array<DeathReasonDiagnosis>();
        this.morgueExDischargeFormViewModel._Morgue.SKRSInjuryPlace = new SKRSYaralanmaninYeri();
        this.morgueExDischargeFormViewModel._Morgue.SKRSDeathReason = new SKRSOlumNedeniTuru();
        this.morgueExDischargeFormViewModel._Morgue.SKRSDeathPlace = new SKRSOlumYeri();
        this.morgueExDischargeFormViewModel._Morgue.DiedClinic = new ResSection();
        this.morgueExDischargeFormViewModel._Morgue.Nurse = new ResUser();
        this.morgueExDischargeFormViewModel._Morgue.SenderDoctor = new ResUser();
        this.morgueExDischargeFormViewModel._Morgue.DoctorFixed = new ResUser();
        this.morgueExDischargeFormViewModel._Morgue.MernisDeathReasons = new MernisDeathReasonDefinition();
    }

    protected loadViewModel() {
        let that = this;
        that.morgueExDischargeFormViewModel = this._ViewModel as MorgueExDischargeFormViewModel;
        that._TTObject = this.morgueExDischargeFormViewModel._Morgue;
        if (this.morgueExDischargeFormViewModel == null)
            this.morgueExDischargeFormViewModel = new MorgueExDischargeFormViewModel();
        if (this.morgueExDischargeFormViewModel._Morgue == null)
            this.morgueExDischargeFormViewModel._Morgue = new Morgue();
        that.morgueExDischargeFormViewModel._Morgue.MorgueDeathType = that.morgueExDischargeFormViewModel.MorgueDeathTypeGridList;
        for (let detailItem of that.morgueExDischargeFormViewModel.MorgueDeathTypeGridList) {
            let sKRSOlumSekliObjectID = detailItem["SKRSOlumSekli"];
            if (sKRSOlumSekliObjectID != null && (typeof sKRSOlumSekliObjectID === "string")) {
                let sKRSOlumSekli = that.morgueExDischargeFormViewModel.SKRSOlumSeklis.find(o => o.ObjectID.toString() === sKRSOlumSekliObjectID.toString());
                 if (sKRSOlumSekli) {
                    detailItem.SKRSOlumSekli = sKRSOlumSekli;
                }
            }
            let morgueObjectID = detailItem["Morgue"];
            if (morgueObjectID != null && (typeof morgueObjectID === "string")) {
                let morgue = that.morgueExDischargeFormViewModel.Morgues.find(o => o.ObjectID.toString() === morgueObjectID.toString());
                 if (morgue) {
                    detailItem.Morgue = morgue;
                }
            }
        }
        that.morgueExDischargeFormViewModel._Morgue.DeathReasonDiagnosis = that.morgueExDischargeFormViewModel.DeathReasonDiagnosisGridList;
        for (let detailItem of that.morgueExDischargeFormViewModel.DeathReasonDiagnosisGridList) {
            let sKRSICDObjectID = detailItem["SKRSICD"];
            if (sKRSICDObjectID != null && (typeof sKRSICDObjectID === "string")) {
                let sKRSICD = that.morgueExDischargeFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSICDObjectID.toString());
                 if (sKRSICD) {
                    detailItem.SKRSICD = sKRSICD;
                }
            }
            let sKRSOlumNedeniTuruObjectID = detailItem["SKRSOlumNedeniTuru"];
            if (sKRSOlumNedeniTuruObjectID != null && (typeof sKRSOlumNedeniTuruObjectID === "string")) {
                let sKRSOlumNedeniTuru = that.morgueExDischargeFormViewModel.SKRSOlumNedeniTurus.find(o => o.ObjectID.toString() === sKRSOlumNedeniTuruObjectID.toString());
                 if (sKRSOlumNedeniTuru) {
                    detailItem.SKRSOlumNedeniTuru = sKRSOlumNedeniTuru;
                }
            }
        }
        let sKRSInjuryPlaceObjectID = that.morgueExDischargeFormViewModel._Morgue["SKRSInjuryPlace"];
        if (sKRSInjuryPlaceObjectID != null && (typeof sKRSInjuryPlaceObjectID === "string")) {
            let sKRSInjuryPlace = that.morgueExDischargeFormViewModel.SKRSYaralanmaninYeris.find(o => o.ObjectID.toString() === sKRSInjuryPlaceObjectID.toString());
             if (sKRSInjuryPlace) {
                that.morgueExDischargeFormViewModel._Morgue.SKRSInjuryPlace = sKRSInjuryPlace;
            }
        }
        let sKRSDeathReasonObjectID = that.morgueExDischargeFormViewModel._Morgue["SKRSDeathReason"];
        if (sKRSDeathReasonObjectID != null && (typeof sKRSDeathReasonObjectID === "string")) {
            let sKRSDeathReason = that.morgueExDischargeFormViewModel.SKRSOlumNedeniTurus.find(o => o.ObjectID.toString() === sKRSDeathReasonObjectID.toString());
             if (sKRSDeathReason) {
                that.morgueExDischargeFormViewModel._Morgue.SKRSDeathReason = sKRSDeathReason;
            }
        }
        let sKRSDeathPlaceObjectID = that.morgueExDischargeFormViewModel._Morgue["SKRSDeathPlace"];
        if (sKRSDeathPlaceObjectID != null && (typeof sKRSDeathPlaceObjectID === "string")) {
            let sKRSDeathPlace = that.morgueExDischargeFormViewModel.SKRSOlumYeris.find(o => o.ObjectID.toString() === sKRSDeathPlaceObjectID.toString());
             if (sKRSDeathPlace) {
                that.morgueExDischargeFormViewModel._Morgue.SKRSDeathPlace = sKRSDeathPlace;
            }
        }
        let diedClinicObjectID = that.morgueExDischargeFormViewModel._Morgue["DiedClinic"];
        if (diedClinicObjectID != null && (typeof diedClinicObjectID === "string")) {
            let diedClinic = that.morgueExDischargeFormViewModel.ResSections.find(o => o.ObjectID.toString() === diedClinicObjectID.toString());
             if (diedClinic) {
                that.morgueExDischargeFormViewModel._Morgue.DiedClinic = diedClinic;
            }
        }
        let nurseObjectID = that.morgueExDischargeFormViewModel._Morgue["Nurse"];
        if (nurseObjectID != null && (typeof nurseObjectID === "string")) {
            let nurse = that.morgueExDischargeFormViewModel.ResUsers.find(o => o.ObjectID.toString() === nurseObjectID.toString());
             if (nurse) {
                that.morgueExDischargeFormViewModel._Morgue.Nurse = nurse;
            }
        }
        let senderDoctorObjectID = that.morgueExDischargeFormViewModel._Morgue["SenderDoctor"];
        if (senderDoctorObjectID != null && (typeof senderDoctorObjectID === "string")) {
            let senderDoctor = that.morgueExDischargeFormViewModel.ResUsers.find(o => o.ObjectID.toString() === senderDoctorObjectID.toString());
             if (senderDoctor) {
                that.morgueExDischargeFormViewModel._Morgue.SenderDoctor = senderDoctor;
            }
        }
        let doctorFixedObjectID = that.morgueExDischargeFormViewModel._Morgue["DoctorFixed"];
        if (doctorFixedObjectID != null && (typeof doctorFixedObjectID === "string")) {
            let doctorFixed = that.morgueExDischargeFormViewModel.ResUsers.find(o => o.ObjectID.toString() === doctorFixedObjectID.toString());
             if (doctorFixed) {
                that.morgueExDischargeFormViewModel._Morgue.DoctorFixed = doctorFixed;
            }
        }
        let mernisDeathReasonsObjectID = that.morgueExDischargeFormViewModel._Morgue["MernisDeathReasons"];
        if (mernisDeathReasonsObjectID != null && (typeof mernisDeathReasonsObjectID === "string")) {
            let mernisDeathReasons = that.morgueExDischargeFormViewModel.MernisDeathReasonDefinitions.find(o => o.ObjectID.toString() === mernisDeathReasonsObjectID.toString());
             if (mernisDeathReasons) {
                that.morgueExDischargeFormViewModel._Morgue.MernisDeathReasons = mernisDeathReasons;
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(MorgueExDischargeFormViewModel);
  


    }


    public onAutopsyToDoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.AutopsyToDo != event) {
                this._Morgue.AutopsyToDo = event;
            }
        }
    }

    public onDateOfDeathReportChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DateOfDeathReport != event) {
                this._Morgue.DateOfDeathReport = event;
            }
        }
    }

    public onDateTimeOfDeathChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DateTimeOfDeath != event) {
                this._Morgue.DateTimeOfDeath = event;
            }
        }
    }

    public onDeathReasonEvaluationChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DeathReasonEvaluation != event) {
                this._Morgue.DeathReasonEvaluation = event;
            }
        }
    }

    public onDiedClinicChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DiedClinic != event) {
                this._Morgue.DiedClinic = event;
            }
        }
    }

    public onDoctorFixedChanged(event): void {
        if (this._Morgue != null && this._Morgue.DoctorFixed != event) {
            this._Morgue.DoctorFixed = event;
        }
    }

    public onExternalDoctorFixedChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalDoctorFixed != event) {
                this._Morgue.ExternalDoctorFixed = event;
            }
        }
    }

    public onExternalDoctorFixedUniqueNoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalDoctorFixedUniqueNo != event) {
                this._Morgue.ExternalDoctorFixedUniqueNo = event;
            }
        }
    }

    public onExternalSenderDoctorMorgueUnRChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalSenderDoctorMorgueUnR != event) {
                this._Morgue.ExternalSenderDoctorMorgueUnR = event;
            }
        }
    }

    public onExternalSenderDoctorToMorgueChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalSenderDoctorToMorgue != event) {
                this._Morgue.ExternalSenderDoctorToMorgue = event;
            }
        }
    }

    public onInjuryDateChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.InjuryDate != event) {
                this._Morgue.InjuryDate = event;
            }
        }
    }

    public onInjuryExistingChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.InjuryExisting != event) {
                this._Morgue.InjuryExisting = event;
            }
        }
        if (event == true) {
            this.injuryExisting = true;
        }
        else {
            this.injuryExisting = false;
        }
    }

    public onMernisDeathReasonsChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.MernisDeathReasons != event) {
                this._Morgue.MernisDeathReasons = event;
            }
        }
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.Note != event) {
                this._Morgue.Note = event;
            }
        }
    }

    public onNurseChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.Nurse != event) {
                this._Morgue.Nurse = event;
            }
        }
    }

    public onPatientCameExChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.PatientCameEx != event) {
                this._Morgue.PatientCameEx = event;
            }
        }
        if (event == true) {
            this.patientExComeVisibility = true;
        } else {
            this.patientExComeVisibility = false;
        }
    }

    public onSenderDoctorChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SenderDoctor != event) {
                this._Morgue.SenderDoctor = event;
            }
        }
    }

    public onSendToMorgueChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SendToMorgue != event) {
                this._Morgue.SendToMorgue = event;
            }
        }
    }

    public onSKRSDeathPlaceChanged(event): void {
        if (this._Morgue != null && this._Morgue.SKRSDeathPlace != event) {
            this._Morgue.SKRSDeathPlace = event;
        }
    }

    public onSKRSDeathReasonChanged(event): void {
        if (this._Morgue != null && this._Morgue.SKRSDeathReason != event) {
            this._Morgue.SKRSDeathReason = event;
        }
    }

    public onSKRSInjuryPlaceChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SKRSInjuryPlace != event) {
                this._Morgue.SKRSInjuryPlace = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.DateTimeOfDeath, "Value", this.__ttObject, "DateTimeOfDeath");
        redirectProperty(this.SendToMorgue, "Value", this.__ttObject, "SendToMorgue");
        redirectProperty(this.AutopsyToDo, "Value", this.__ttObject, "AutopsyToDo");
        redirectProperty(this.PatientCameEx, "Value", this.__ttObject, "PatientCameEx");
        redirectProperty(this.InjuryExisting, "Value", this.__ttObject, "InjuryExisting");
        redirectProperty(this.ExternalDoctorFixed, "Text", this.__ttObject, "ExternalDoctorFixed");
        redirectProperty(this.ExternalSenderDoctorToMorgue, "Text", this.__ttObject, "ExternalSenderDoctorToMorgue");
        redirectProperty(this.ExternalDoctorFixedUniqueNo, "Text", this.__ttObject, "ExternalDoctorFixedUniqueNo");
        redirectProperty(this.ExternalSenderDoctorMorgueUnR, "Text", this.__ttObject, "ExternalSenderDoctorMorgueUnR");
        redirectProperty(this.DateOfDeathReport, "Value", this.__ttObject, "DateOfDeathReport");
        redirectProperty(this.DeathReasonEvaluation, "Rtf", this.__ttObject, "DeathReasonEvaluation");
        redirectProperty(this.Note, "Rtf", this.__ttObject, "Note");
        redirectProperty(this.InjuryDate, "Value", this.__ttObject, "InjuryDate");
    }

    public initFormControls(): void {
        //this.MorgueDeathType = new TTVisual.TTGrid();
        //this.MorgueDeathType.Name = "MorgueDeathType";
        //this.MorgueDeathType.TabIndex = 42;

        this.MorgueDeathType = new TTVisual.TTGrid();
        this.MorgueDeathType.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MorgueDeathType.Name = "MorgueDeathType";
        this.MorgueDeathType.TabIndex = 0;
        this.MorgueDeathType.Height = "200px";
        this.MorgueDeathType.ShowFilterCombo = true;
        this.MorgueDeathType.FilterColumnName = "SKRSOlumSekliMorgueDeathType";
        this.MorgueDeathType.FilterLabel = i18n("M19942", "Ölüm Şekli");
        this.MorgueDeathType.Filter = { ListDefName: "SKRSOlumSekliList" };
        this.MorgueDeathType.AllowUserToAddRows = false;
        this.MorgueDeathType.DeleteButtonWidth = "5%";
        this.MorgueDeathType.AllowUserToDeleteRows = true;
        this.MorgueDeathType.IsFilterLabelSingleLine = false;
        this.MorgueDeathType.Required = true;


        this.SKRSOlumSekliMorgueDeathType = new TTVisual.TTListBoxColumn();
        this.SKRSOlumSekliMorgueDeathType.ListDefName = "SKRSOlumSekliList";
        this.SKRSOlumSekliMorgueDeathType.DataMember = "SKRSOlumSekli";
        this.SKRSOlumSekliMorgueDeathType.DisplayIndex = 0;
        this.SKRSOlumSekliMorgueDeathType.HeaderText = i18n("M19942", "Ölüm Şekli");
        this.SKRSOlumSekliMorgueDeathType.Name = "SKRSOlumSekliMorgueDeathType";
        this.SKRSOlumSekliMorgueDeathType.Width = "90%";

        this.MorgueMorgueDeathType = new TTVisual.TTListBoxColumn();
        this.MorgueMorgueDeathType.DataMember = "Morgue";
        this.MorgueMorgueDeathType.DisplayIndex = 1;
        this.MorgueMorgueDeathType.HeaderText = "";
        this.MorgueMorgueDeathType.Name = "MorgueMorgueDeathType";
        this.MorgueMorgueDeathType.Width = 300;

        this.labelDeathReason = new TTVisual.TTLabel();
        this.labelDeathReason.Text = i18n("M19927", "Ölüm Nedeni Bilgisi");
        this.labelDeathReason.Name = "labelDeathReason";
        this.labelDeathReason.TabIndex = 41;

        //this.DeathReasonDiagnosis = new TTVisual.TTGrid();
        //this.DeathReasonDiagnosis.Name = "DeathReasonDiagnosis";
        //this.DeathReasonDiagnosis.TabIndex = 40;

        this.DeathReasonDiagnosis = new TTVisual.TTGrid();
        this.DeathReasonDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DeathReasonDiagnosis.Name = "DeathReasonDiagnosis";
        this.DeathReasonDiagnosis.TabIndex = 0;
        this.DeathReasonDiagnosis.Height = "200px";
        this.DeathReasonDiagnosis.ShowFilterCombo = true;
        this.DeathReasonDiagnosis.FilterColumnName = "SKRSICDDeathReasonDiagnosis";
        this.DeathReasonDiagnosis.FilterLabel = "Ölüm Nedeni Tanı Bilgisi";
        this.DeathReasonDiagnosis.Filter = { ListDefName: "SKRSICDList" };
        this.DeathReasonDiagnosis.AllowUserToAddRows = false;
        this.DeathReasonDiagnosis.DeleteButtonWidth = "5%";
        this.DeathReasonDiagnosis.AllowUserToDeleteRows = true;
        this.DeathReasonDiagnosis.IsFilterLabelSingleLine = false;
        this.DeathReasonDiagnosis.Required = true;

        this.SKRSICDDeathReasonDiagnosis = new TTVisual.TTListBoxColumn();
        this.SKRSICDDeathReasonDiagnosis.ListDefName = "SKRSICDList";
        this.SKRSICDDeathReasonDiagnosis.DataMember = "SKRSICD";
        this.SKRSICDDeathReasonDiagnosis.DisplayIndex = 0;
        this.SKRSICDDeathReasonDiagnosis.HeaderText = "Ölüm Nedeni Tanı Bilgisi";
        this.SKRSICDDeathReasonDiagnosis.Name = "SKRSICDDeathReasonDiagnosis";
        this.SKRSICDDeathReasonDiagnosis.Width = "40%";

        this.SKRSOlumNedeniTuruDeathReasonDiagnosis = new TTVisual.TTListBoxColumn();
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.ListDefName = "SKRSOlumNedeniTuruList";
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.DataMember = "SKRSOlumNedeniTuru";
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.DisplayIndex = 1;
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.HeaderText = i18n("M19931", "Ölüm Nedeni Türü");
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.Name = "SKRSOlumNedeniTuruDeathReasonDiagnosis";
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.Width = "40%";

        this.PatientCameEx = new TTVisual.TTCheckBox();
        this.PatientCameEx.Value = false;
        this.PatientCameEx.Text = i18n("M15271", "Hasta Merkeze Ex Geldi");
        this.PatientCameEx.Title = i18n("M15271", "Hasta Merkeze Ex Geldi");
        this.PatientCameEx.Name = "PatientCameEx";
        this.PatientCameEx.TabIndex = 39;

        this.AutopsyToDo = new TTVisual.TTCheckBox();
        this.AutopsyToDo.Value = false;
        this.AutopsyToDo.Text = i18n("M19828", "Otopsi Yapılacak");
        this.AutopsyToDo.Title = i18n("M19828", "Otopsi Yapılacak");
        this.AutopsyToDo.Name = "AutopsyToDo";
        this.AutopsyToDo.TabIndex = 38;

        this.SendToMorgue = new TTVisual.TTCheckBox();
        this.SendToMorgue.Value = true;
        this.SendToMorgue.Text = i18n("M19134", "Morga Gönder");
        this.SendToMorgue.Title = i18n("M19134", "Morga Gönder");
        this.SendToMorgue.Name = "SendToMorgue";
        this.SendToMorgue.TabIndex = 37;

        this.labelDateOfDeathReport = new TTVisual.TTLabel();
        this.labelDateOfDeathReport.Text = i18n("M19936", "Ölüm Raporunun Tarihi");
        this.labelDateOfDeathReport.Name = "labelDateOfDeathReport";
        this.labelDateOfDeathReport.TabIndex = 36;

        this.DateOfDeathReport = new TTVisual.TTDateTimePicker();
        this.DateOfDeathReport.Format = DateTimePickerFormat.Long;
        this.DateOfDeathReport.Name = "DateOfDeathReport";
        this.DateOfDeathReport.TabIndex = 35;

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = i18n("M19476", "Not");
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 34;

        this.Note = new TTVisual.TTRichTextBoxControl();
        this.Note.Name = "Note";
        this.Note.TabIndex = 33;

        this.labelSKRSInjuryPlace = new TTVisual.TTLabel();
        this.labelSKRSInjuryPlace.Text = i18n("M24308", "Yaralanma Yeri");
        this.labelSKRSInjuryPlace.Name = "labelSKRSInjuryPlace";
        this.labelSKRSInjuryPlace.TabIndex = 32;

        this.SKRSInjuryPlace = new TTVisual.TTObjectListBox();
        this.SKRSInjuryPlace.ListDefName = "SKRSYaralanmaninYeriList";
        this.SKRSInjuryPlace.Name = "SKRSInjuryPlace";
        this.SKRSInjuryPlace.TabIndex = 31;

        this.labelInjuryDate = new TTVisual.TTLabel();
        this.labelInjuryDate.Text = i18n("M24306", "Yaralanma Tarihi");
        this.labelInjuryDate.Name = "labelInjuryDate";
        this.labelInjuryDate.TabIndex = 30;

        this.InjuryDate = new TTVisual.TTDateTimePicker();
        this.InjuryDate.Format = DateTimePickerFormat.Long;
        this.InjuryDate.Name = "InjuryDate";
        this.InjuryDate.TabIndex = 29;

        this.InjuryExisting = new TTVisual.TTCheckBox();
        this.InjuryExisting.Value = false;
        this.InjuryExisting.Text = i18n("M24302", "Yaralanma Mevcut");
        this.InjuryExisting.Title = i18n("M24302", "Yaralanma Mevcut");
        this.InjuryExisting.Name = "InjuryExisting";
        this.InjuryExisting.TabIndex = 28;

        this.labelSKRSDeathReason = new TTVisual.TTLabel();
        this.labelSKRSDeathReason.Text = i18n("M19931", "Ölüm Nedeni Türü");
        this.labelSKRSDeathReason.Name = "labelSKRSDeathReason";
        this.labelSKRSDeathReason.TabIndex = 27;

        this.SKRSDeathReason = new TTVisual.TTObjectListBox();
        this.SKRSDeathReason.ListDefName = "SKRSOlumNedeniTuruList";
        this.SKRSDeathReason.Name = "SKRSDeathReason";
        this.SKRSDeathReason.TabIndex = 26;
        this.SKRSDeathReason.Required = true;

        this.labelSKRSDeathPlace = new TTVisual.TTLabel();
        this.labelSKRSDeathPlace.Text = i18n("M19948", "Ölüm Yeri");
        this.labelSKRSDeathPlace.Name = "labelSKRSDeathPlace";
        this.labelSKRSDeathPlace.TabIndex = 25;

        this.SKRSDeathPlace = new TTVisual.TTObjectListBox();
        this.SKRSDeathPlace.ListDefName = "SKRSOlumYeriList";
        this.SKRSDeathPlace.Name = "SKRSDeathPlace";
        this.SKRSDeathPlace.TabIndex = 24;
        this.SKRSDeathPlace.Required = true;

        this.labelDeathReasonEvaluation = new TTVisual.TTLabel();
        this.labelDeathReasonEvaluation.Text = i18n("M19929", "Ölüm Nedeni Değerlendirme");
        this.labelDeathReasonEvaluation.Name = "labelDeathReasonEvaluation";
        this.labelDeathReasonEvaluation.TabIndex = 21;

        this.DeathReasonEvaluation = new TTVisual.TTRichTextBoxControl();
        this.DeathReasonEvaluation.Name = "DeathReasonEvaluation";
        this.DeathReasonEvaluation.TabIndex = 20;

        this.labelDiedClinic = new TTVisual.TTLabel();
        this.labelDiedClinic.Text = i18n("M24059", "Vefat Ettiği Klinik");
        this.labelDiedClinic.Name = "labelDiedClinic";
        this.labelDiedClinic.TabIndex = 19;

        this.DiedClinic = new TTVisual.TTObjectListBox();
        this.DiedClinic.ListDefName = "PoliclinicClinicResourceListDefinition";
        this.DiedClinic.Name = "DiedClinic";
        this.DiedClinic.TabIndex = 18;

        this.labelNurse = new TTVisual.TTLabel();
        this.labelNurse.Text = "Hemşire";
        this.labelNurse.Name = "labelNurse";
        this.labelNurse.TabIndex = 17;

        this.Nurse = new TTVisual.TTObjectListBox();
        this.Nurse.ListDefName = "ClinicNurseListDefinition";
        this.Nurse.Name = "Nurse";
        this.Nurse.TabIndex = 16;

        this.labelExternalSenderDoctorMorgueUnR = new TTVisual.TTLabel();
        this.labelExternalSenderDoctorMorgueUnR.Text = i18n("M19137", "Morga Gönderen Dış Doktor TC");
        this.labelExternalSenderDoctorMorgueUnR.Name = "labelExternalSenderDoctorMorgueUnR";
        this.labelExternalSenderDoctorMorgueUnR.TabIndex = 15;

        this.ExternalSenderDoctorMorgueUnR = new TTVisual.TTTextBox();
        this.ExternalSenderDoctorMorgueUnR.Name = "ExternalSenderDoctorMorgueUnR";
        this.ExternalSenderDoctorMorgueUnR.TabIndex = 14;

        this.ExternalSenderDoctorToMorgue = new TTVisual.TTTextBox();
        this.ExternalSenderDoctorToMorgue.Name = "ExternalSenderDoctorToMorgue";
        this.ExternalSenderDoctorToMorgue.TabIndex = 12;

        this.ExternalDoctorFixedUniqueNo = new TTVisual.TTTextBox();
        this.ExternalDoctorFixedUniqueNo.Name = "ExternalDoctorFixedUniqueNo";
        this.ExternalDoctorFixedUniqueNo.TabIndex = 8;

        this.ExternalDoctorFixed = new TTVisual.TTTextBox();
        this.ExternalDoctorFixed.Name = "ExternalDoctorFixed";
        this.ExternalDoctorFixed.TabIndex = 6;

        this.labelExternalSenderDoctorToMorgue = new TTVisual.TTLabel();
        this.labelExternalSenderDoctorToMorgue.Text = i18n("M19136", "Morga Gönderen Dış Doktor");
        this.labelExternalSenderDoctorToMorgue.Name = "labelExternalSenderDoctorToMorgue";
        this.labelExternalSenderDoctorToMorgue.TabIndex = 13;

        this.labelSenderDoctor = new TTVisual.TTLabel();
        this.labelSenderDoctor.Text = i18n("M19138", "Morga Gönderen Doktor");
        this.labelSenderDoctor.Name = "labelSenderDoctor";
        this.labelSenderDoctor.TabIndex = 11;

        this.SenderDoctor = new TTVisual.TTObjectListBox();
        this.SenderDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.SenderDoctor.Name = "SenderDoctor";
        this.SenderDoctor.TabIndex = 10;

        this.labelExternalDoctorFixedUniqueNo = new TTVisual.TTLabel();
        this.labelExternalDoctorFixedUniqueNo.Text = i18n("M19951", "Ölümü Tespit Eden Dış Doktor TC");
        this.labelExternalDoctorFixedUniqueNo.Name = "labelExternalDoctorFixedUniqueNo";
        this.labelExternalDoctorFixedUniqueNo.TabIndex = 9;

        this.labelExternalDoctorFixed = new TTVisual.TTLabel();
        this.labelExternalDoctorFixed.Text = i18n("M19952", "Ölümü Tespit Eden Dış Kurum Doktoru");
        this.labelExternalDoctorFixed.Name = "labelExternalDoctorFixed";
        this.labelExternalDoctorFixed.TabIndex = 7;

        this.labelDoctorFixed = new TTVisual.TTLabel();
        this.labelDoctorFixed.Text = i18n("M19954", "Ölümü Tespit Eden Doktor");
        this.labelDoctorFixed.Name = "labelDoctorFixed";
        this.labelDoctorFixed.TabIndex = 5;

        this.DoctorFixed = new TTVisual.TTObjectListBox();
        this.DoctorFixed.ListDefName = "SpecialistDoctorListDefinition";
        this.DoctorFixed.Name = "DoctorFixed";
        this.DoctorFixed.TabIndex = 4;

        this.labelMernisDeathReasons = new TTVisual.TTLabel();
        this.labelMernisDeathReasons.Text = "Mernis Ölüm Sebepleri";
        this.labelMernisDeathReasons.Name = "labelMernisDeathReasons";
        this.labelMernisDeathReasons.TabIndex = 3;

        this.MernisDeathReasons = new TTVisual.TTObjectListBox();
        this.MernisDeathReasons.ListDefName = "MernisDeathReasonDefinitionList";
        this.MernisDeathReasons.Name = "MernisDeathReasons";
        this.MernisDeathReasons.TabIndex = 2;

        this.labelDateTimeOfDeath = new TTVisual.TTLabel();
        this.labelDateTimeOfDeath.Text = i18n("M19945", "Ölüm Tarihi ve Saati");
        this.labelDateTimeOfDeath.Name = "labelDateTimeOfDeath";
        this.labelDateTimeOfDeath.TabIndex = 1;

        this.DateTimeOfDeath = new TTVisual.TTDateTimePicker();
        this.DateTimeOfDeath.Format = DateTimePickerFormat.Long;
        this.DateTimeOfDeath.Name = "DateTimeOfDeath";
        this.DateTimeOfDeath.TabIndex = 0;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M19942", "Ölüm Şekli");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 41;

        this.DeathTypeList = new TTVisual.TTObjectListBox();
        this.DeathTypeList.ListDefName = "SKRSOlumSekliList";
        this.DeathTypeList.Name = "DeathTypeList";

        this.DeathReasonList = new TTVisual.TTObjectListBox();
        this.DeathReasonList.ListDefName = "SKRSICDList";
        this.DeathReasonList.Name = "DeathReasonList";

        this.MorgueDeathTypeColumns = [this.SKRSOlumSekliMorgueDeathType];
        this.DeathReasonDiagnosisColumns = [this.SKRSICDDeathReasonDiagnosis, this.SKRSOlumNedeniTuruDeathReasonDiagnosis];
        this.Controls = [this.MorgueDeathType, this.SKRSOlumSekliMorgueDeathType, this.MorgueMorgueDeathType, this.labelDeathReason, this.DeathReasonDiagnosis, this.SKRSICDDeathReasonDiagnosis, this.SKRSOlumNedeniTuruDeathReasonDiagnosis, this.PatientCameEx, this.AutopsyToDo, this.SendToMorgue, this.labelDateOfDeathReport, this.DateOfDeathReport, this.labelNote, this.Note, this.labelSKRSInjuryPlace, this.SKRSInjuryPlace, this.labelInjuryDate, this.InjuryDate, this.InjuryExisting, this.labelSKRSDeathReason, this.SKRSDeathReason, this.labelSKRSDeathPlace, this.SKRSDeathPlace, this.labelDeathReasonEvaluation, this.DeathReasonEvaluation, this.labelDiedClinic, this.DiedClinic, this.labelNurse, this.Nurse, this.labelExternalSenderDoctorMorgueUnR, this.ExternalSenderDoctorMorgueUnR, this.ExternalSenderDoctorToMorgue, this.ExternalDoctorFixedUniqueNo, this.ExternalDoctorFixed, this.labelExternalSenderDoctorToMorgue, this.labelSenderDoctor, this.SenderDoctor, this.labelExternalDoctorFixedUniqueNo, this.labelExternalDoctorFixed, this.labelDoctorFixed, this.DoctorFixed, this.labelMernisDeathReasons, this.MernisDeathReasons, this.labelDateTimeOfDeath, this.DateTimeOfDeath, this.ttlabel1];

    }

    private _modalInfo: ModalInfo;

    public setInputParam(value: boolean) {
        if (value != null)
            this._FromDischarge = value;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;

    }
    public onDeathTypeListSelected(event): void {
        let that = this;
        if (event != null) {
            //Gride satır at
            this.morgueExDischargeFormViewModel.MorgueDeathTypeGridList.unshift(event);
        }
    }

    public onDeathReasonListSelected(event): void {
        let that = this;
        if (event != null) {


        }
    }

    GenerateDeathResonColums(): void {
        let that = this;
        this.DeathReasonListColumns = [
            {
                caption: i18n("M22736", "Tanı"),
                dataField: 'SKRSICD.ObjectID',
                fixed: true, width: '45%',
                allowSorting: false,
                allowEditing: false,
                lookup: {
                    dataSource: that.taniArray, valueExpr: 'ObjectID', displayExpr: 'KODTANIMI'
                }
            }, {
                caption: i18n("M23679", "Türü"),
                dataField: 'SKRSOlumNedeniTuru.ObjectID',
                fixed: true, width: '45%',
                allowSorting: false,
                allowEditing: false,
                lookup: {
                    dataSource: that.olumNedeniArray, valueExpr: 'ObjectID', displayExpr: 'ADI'
                }
            }
        ];
    }

    public async Tani(): Promise<any> {
        if (!this.taniCache) {
            this.taniCache = await this.httpService.get('/api/MorgueService/GetSKRSICDO');
            return this.taniCache;
        }
        else {
            return this.taniCache;
        }
    }

    public async OlumNedeni(): Promise<any> {
        if (!this.olumNedeniCache) {
            this.olumNedeniCache = await this.httpService.get('/api/MorgueService/GetSKRSOlumNedeni');
            return this.olumNedeniCache;
        }
        else {
            return this.olumNedeniCache;
        }
    }
    onSaveMorgue() {
        if (this._modalInfo != null) {
            if (this.morgueExDischargeFormViewModel._Morgue.DeathReasonDiagnosis.length > 0) {
                if (this.morgueExDischargeFormViewModel._Morgue.MorgueDeathType.length > 0) {
                    if (this.morgueExDischargeFormViewModel._Morgue.SKRSDeathPlace != null) {
                        if (this.morgueExDischargeFormViewModel._Morgue.SKRSDeathReason != null) {
                            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.morgueExDischargeFormViewModel);
                        } else {
                            TTVisual.InfoBox.Alert("Ölüm Nedeni Türü Alanı Boş Olamaz.!");
                            this.SKRSDeathReason.BackColor = '#cce6ff';
                        }
                    } else {
                        TTVisual.InfoBox.Alert("Ölüm Yeri Alanı Boş Olamaz.!");
                        this.SKRSDeathPlace.BackColor = '#cce6ff';
                    }
                } else {
                    TTVisual.InfoBox.Alert("En Az 1 adet Ölüm Şekli Bilgisi Seçiniz.!");
                    this.MorgueDeathType.BackColor = '#cce6ff';
                }
            } else {
                TTVisual.InfoBox.Alert("En Az 1 adet Ölüm Nedeni Bilgisi Seçiniz.!");
                this.DeathReasonDiagnosis.BackColor = '#cce6ff';
            }
        }
    }


}


