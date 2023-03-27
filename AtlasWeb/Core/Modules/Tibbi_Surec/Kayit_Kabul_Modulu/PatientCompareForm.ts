//$95317894
import { Component, EventEmitter, Input , Output} from '@angular/core';
import { PatientCompareFormViewModel } from "./PatientCompareFormViewModel";
import { CharacterCasing } from "NebulaClient/Utils/Enums/CharacterCasing";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { Util } from "Fw/Components/Util";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { MernisPatientModel } from "./PatientAdmissionFormViewModel";
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSUlkeKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

import { Convert } from 'NebulaClient/Mscorlib/Convert';

@Component({
    selector: 'PatientCompareForm',
    templateUrl: './PatientCompareForm.html',
    outputs: ['OnClosing'],
    providers: [MessageService]
})
export class PatientCompareForm extends TTVisual.TTForm {
    BirthDate: TTVisual.ITTDateTimePicker;
    CityOfBirth: TTVisual.ITTObjectListBox;
    ExDate: TTVisual.ITTDateTimePicker;
    FatherName: TTVisual.ITTTextBox;
    labelBirthDate: TTVisual.ITTLabel;
    labelCityOfBirth: TTVisual.ITTLabel;
    labelExDate: TTVisual.ITTLabel;
    labelFatherName: TTVisual.ITTLabel;
    labelMotherName: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelNationality: TTVisual.ITTLabel;
    labelSex: TTVisual.ITTLabel;
    labelSurname: TTVisual.ITTLabel;
    KPSNationality: TTVisual.ITTTextBox;
    KPSName: TTVisual.ITTTextBox;
    KPSSurname: TTVisual.ITTTextBox;
    KPSMotherName: TTVisual.ITTTextBox;
    KPSFatherName: TTVisual.ITTTextBox;
    KPSCityOfBirth: TTVisual.ITTTextBox;
    KPSSKRSMaritalStatus: TTVisual.ITTTextBox;
    KPSSex: TTVisual.ITTTextBox;
    MotherName: TTVisual.ITTTextBox;
    Name: TTVisual.ITTTextBox;
    Nationality: TTVisual.ITTObjectListBox;
    SKRSMaritalStatus: TTVisual.ITTObjectListBox;
    Sex: TTVisual.ITTObjectListBox;
    Surname: TTVisual.ITTTextBox;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepicker3: TTVisual.ITTDateTimePicker;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttobjectlistbox2: TTVisual.ITTObjectListBox;
    ttobjectlistbox4: TTVisual.ITTObjectListBox;
    tttextbox5: TTVisual.ITTTextBox;
    tttextbox6: TTVisual.ITTTextBox;
    tttextbox7: TTVisual.ITTTextBox;
    tttextbox8: TTVisual.ITTTextBox;
    public patientCompareFormViewModel: PatientCompareFormViewModel = new PatientCompareFormViewModel();
    public get _Patient(): Patient {
        return this._TTObject as Patient;
    }
    private PatientCompareForm_DocumentUrl: string = '/api/PatientService/PatientCompareForm';
    public _EmptyDocumentUrl: string = '/api/PatientService/PatientCompareFormPreLoad';
    public _KPSInfo: MernisPatientModel;
    public ha_Color:string="";

    @Input() set patientInfo(value: Patient) {

        this._TTObject = value;
        this.patientCompareFormViewModel = new PatientCompareFormViewModel();
        this._ViewModel = this.patientCompareFormViewModel;
        this.patientCompareFormViewModel._Patient = this._TTObject as Patient;
    }

    OnClosing: EventEmitter<Boolean> = new EventEmitter<any>(); /*üstteki controle parametre göndermek için*/
    @Output() SubmitPatientViewModel: EventEmitter<PatientCompareFormViewModel> = new EventEmitter<PatientCompareFormViewModel>();


    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("PATIENT", "PatientCompareForm");
        this._DocumentServiceUrl = this.PatientCompareForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Patient();
        this.patientCompareFormViewModel = new PatientCompareFormViewModel();
        this._ViewModel = this.patientCompareFormViewModel;
        this.patientCompareFormViewModel._Patient = this._TTObject as Patient;
        this.patientCompareFormViewModel._Patient.Nationality = new SKRSUlkeKodlari();
        this.patientCompareFormViewModel._Patient.Sex = new SKRSCinsiyet();
        this.patientCompareFormViewModel._Patient.SKRSMaritalStatus = new SKRSMedeniHali();
        // this.patientCompareFormViewModel._Patient.CityOfBirth = new SKRSILKodlari();
    }

    protected loadViewModel() {
        let that = this;
        that.patientCompareFormViewModel = this._ViewModel as PatientCompareFormViewModel;
        that._TTObject = this.patientCompareFormViewModel._Patient;
        if (this.patientCompareFormViewModel == null)
            this.patientCompareFormViewModel = new PatientCompareFormViewModel();
        if (this.patientCompareFormViewModel._Patient == null)
            this.patientCompareFormViewModel._Patient = new Patient();
        let nationalityObjectID = that.patientCompareFormViewModel._Patient["Nationality"];
        if (nationalityObjectID != null && (typeof nationalityObjectID === 'string')) {
            let nationality = that.patientCompareFormViewModel.SKRSUlkeKodlaris.find(o => o.ObjectID.toString() === nationalityObjectID.toString());
             if (nationality) {
                that.patientCompareFormViewModel._Patient.Nationality = nationality;
            }
        }
        let sexObjectID = that.patientCompareFormViewModel._Patient["Sex"];
        if (sexObjectID != null && (typeof sexObjectID === 'string')) {
            let sex = that.patientCompareFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
             if (sex) {
                that.patientCompareFormViewModel._Patient.Sex = sex;
            }
        }
        let sKRSMaritalStatusObjectID = that.patientCompareFormViewModel._Patient["SKRSMaritalStatus"];
        if (sKRSMaritalStatusObjectID != null && (typeof sKRSMaritalStatusObjectID === 'string')) {
            let maritalStatus = that.patientCompareFormViewModel.SKRSMaritalStatuss.find(o => o.ObjectID.toString() === sKRSMaritalStatusObjectID.toString());
             if (maritalStatus) {
                that.patientCompareFormViewModel._Patient.SKRSMaritalStatus = maritalStatus;
            }
        }

        this.CompareData();
        this.PatientFieldsReadOnly();
    }


    async ngOnInit() {

        await this.loadEmptyForm();
    }
    protected async loadEmptyForm() {
        try {
            let fullApiUrl: string = "";

            fullApiUrl = this._EmptyDocumentUrl + '/?id=' + this.patientCompareFormViewModel._Patient.ObjectID;

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<PatientCompareFormViewModel>(fullApiUrl, PatientCompareFormViewModel);
            this._ViewModel = response;
            this.loadViewModel();

            this.redirectProperties();
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            this.loadErrorOccurred(err);
        }
    }

    public PatientFieldsReadOnly()
    {
        if (this.patientCompareFormViewModel.KimlikBilgileriDuzeltme == true)//Editable permission
        {
            this.Name.ReadOnly = false;
            this.Surname.ReadOnly = false;
            this.Nationality.ReadOnly = false;
            this.MotherName.ReadOnly = false;
            this.FatherName.ReadOnly = false;
            this.BirthDate.ReadOnly = false;
            this.CityOfBirth.ReadOnly = false;
            this.Sex.ReadOnly = false;
            this.SKRSMaritalStatus.ReadOnly = false;
            this.ExDate.ReadOnly = false;

        }
        else
        {
            this.Name.ReadOnly = true;
            this.Surname.ReadOnly = true;
            this.Nationality.ReadOnly = true;
            this.MotherName.ReadOnly = true;
            this.FatherName.ReadOnly = true;
            this.BirthDate.ReadOnly = true;
            this.CityOfBirth.ReadOnly = true;
            this.Sex.ReadOnly = true;
            this.SKRSMaritalStatus.ReadOnly = true;
            this.ExDate.ReadOnly = true;
        }
    }
    public CompareData() {
        if (this.patientCompareFormViewModel._KPSInfo != null) {
            if (this.patientCompareFormViewModel._KPSInfo.KPSName != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._Patient.Name) == Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSName))
                    this.Name.BackColor = "#ffffff";
                else
                    this.Name.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.KPSSurname != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._Patient.Surname) == Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSSurname))
                    this.Surname.BackColor = "#ffffff";
                else
                    this.Surname.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.KPSMotherName != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._Patient.MotherName) == Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSMotherName))
                    this.MotherName.BackColor = "#ffffff";
                else
                    this.MotherName.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.KPSNationality != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._Patient.Nationality.Adi) == Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSNationality.Adi))
                    this.Nationality.BackColor = "#ffffff";
                else
                    this.Nationality.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.KPSFatherName != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._Patient.FatherName) == Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSFatherName))
                    this.FatherName.BackColor = "#ffffff";
                else
                    this.FatherName.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.KPSBirthDate != null) {
                let KPSBirthDate = (Convert.ToDateTime(this.patientCompareFormViewModel._KPSInfo.KPSBirthDate));
                let BirthDate = (Convert.ToDateTime(this.patientCompareFormViewModel._Patient.BirthDate));

                if (BirthDate.toDateString() == KPSBirthDate.toDateString())
                    this.BirthDate.BackColor = "#ffffff";
                else
                    this.BirthDate.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.KPSBirthPlace != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._Patient.BirthPlace) == Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSBirthPlace))
                    this.CityOfBirth.BackColor = "#ffffff";
                else
                    this.CityOfBirth.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.KPSSex != null && this.patientCompareFormViewModel._Patient.Sex != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._Patient.Sex.ADI) == Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSSex.ADI))
                    this.Sex.BackColor = "#ffffff";
                else
                    this.Sex.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.SKRSMaritalStatus != null && this.patientCompareFormViewModel._Patient.SKRSMaritalStatus != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._Patient.SKRSMaritalStatus.ADI) == Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.SKRSMaritalStatus.ADI))
                    this.SKRSMaritalStatus.BackColor = "#ffffff";
                else
                    this.SKRSMaritalStatus.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.KPSExDate != null && this.patientCompareFormViewModel._Patient.ExDate != null) {
                let KPSExDate = (Convert.ToDateTime(this.patientCompareFormViewModel._KPSInfo.KPSExDate));
                let ExDate = (Convert.ToDateTime(this.patientCompareFormViewModel._Patient.ExDate));
                if (KPSExDate.toDateString() == ExDate.toDateString())
                    this.ExDate.BackColor = "#ffffff";
                else
                    this.ExDate.BackColor = "#fdcdcd";
            }
            if (this.patientCompareFormViewModel._KPSInfo.HomeAddress != null && this.patientCompareFormViewModel.HomeAddress != null) {
                if (Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.HomeAddress) == Util.turkishToUpper(this.patientCompareFormViewModel.HomeAddress))
                    this.ha_Color = "#ffffff";
                else
                    this.ha_Color = "#fdcdcd";
            }
        }
    }

    public onBirthDateChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.BirthDate != event) {
                this.patientCompareFormViewModel._Patient.BirthDate = event;
            }
        }
    }

    public onCityOfBirthChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.BirthPlace != event) {
                this.patientCompareFormViewModel._Patient.BirthPlace = event;
            }
        }
    }

    public onExDateChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.ExDate != event) {
                this.patientCompareFormViewModel._Patient.ExDate = event;
            }
        }
    }

    public onFatherNameChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.FatherName != event) {
                this.patientCompareFormViewModel._Patient.FatherName = event;
            }
        }
    }

    public onMotherNameChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.MotherName != event) {
                this.patientCompareFormViewModel._Patient.MotherName = event;
            }
        }
    }

    public onNameChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.Name != event) {
                this.patientCompareFormViewModel._Patient.Name = event;
            }
        }
    }

    public onNationalityChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.Nationality != event) {
                this.patientCompareFormViewModel._Patient.Nationality = event;
            }
        }
    }

    public onSexChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.Sex != event) {
                this.patientCompareFormViewModel._Patient.Sex = event;
            }
        }
    }

    public onSurnameChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.Surname != event) {
                this.patientCompareFormViewModel._Patient.Surname = event;
            }
        }
    }

    public onMaritalStatusChanged(event): void {
        if (event != null) {
            if (this.patientCompareFormViewModel._Patient != null && this.patientCompareFormViewModel._Patient.SKRSMaritalStatus != event) {
                this.patientCompareFormViewModel._Patient.SKRSMaritalStatus = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.Name, "Text", this.__ttObject, "Name");
        redirectProperty(this.Surname, "Text", this.__ttObject, "Surname");
        redirectProperty(this.MotherName, "Text", this.__ttObject, "MotherName");
        redirectProperty(this.FatherName, "Text", this.__ttObject, "FatherName");
        redirectProperty(this.BirthDate, "Value", this.__ttObject, "BirthDate");
        redirectProperty(this.ExDate, "Value", this.__ttObject, "ExDate");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M17422", "Kayıtlı Bilgiler");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.labelNationality = new TTVisual.TTLabel();
        this.labelNationality.Text = i18n("M23815", "Uyruk");
        this.labelNationality.Name = "labelNationality";
        this.labelNationality.TabIndex = 21;

        this.Nationality = new TTVisual.TTObjectListBox();
        this.Nationality.ListDefName = "SKRSUlkeKodlariList";
        this.Nationality.Name = "Nationality";
        this.Nationality.TabIndex = 20;
        this.Nationality.ReadOnly = true;

        this.KPSNationality = new TTVisual.TTTextBox();
        this.KPSNationality.Name = "KPSNationality";
        this.KPSNationality.CharacterCasing = CharacterCasing.Upper;
        this.KPSNationality.InputTurkishCharacter = true;
        this.KPSNationality.ReadOnly = true;

        this.KPSName = new TTVisual.TTTextBox();
        this.KPSName.Name = "KPSName";
        this.KPSName.CharacterCasing = CharacterCasing.Upper;
        this.KPSName.InputTurkishCharacter = true;
        this.KPSName.ReadOnly = true;

        this.KPSSurname = new TTVisual.TTTextBox();
        this.KPSSurname.Name = "KPSSurname";
        this.KPSSurname.CharacterCasing = CharacterCasing.Upper;
        this.KPSSurname.InputTurkishCharacter = true;
        this.KPSSurname.ReadOnly = true;

        this.KPSMotherName = new TTVisual.TTTextBox();
        this.KPSMotherName.Name = "KPSMotherName";
        this.KPSMotherName.CharacterCasing = CharacterCasing.Upper;
        this.KPSMotherName.InputTurkishCharacter = true;
        this.KPSMotherName.ReadOnly = true;

        this.KPSCityOfBirth = new TTVisual.TTTextBox();
        this.KPSCityOfBirth.Name = "KPSCityOfBirth";
        this.KPSCityOfBirth.CharacterCasing = CharacterCasing.Upper;
        this.KPSCityOfBirth.InputTurkishCharacter = true;
        this.KPSCityOfBirth.ReadOnly = true;

        this.KPSSKRSMaritalStatus = new TTVisual.TTTextBox();
        this.KPSSKRSMaritalStatus.Name = "KPSSKRSMaritalStatus";
        this.KPSSKRSMaritalStatus.CharacterCasing = CharacterCasing.Upper;
        this.KPSSKRSMaritalStatus.InputTurkishCharacter = true;
        this.KPSSKRSMaritalStatus.ReadOnly = true;

        this.KPSSex = new TTVisual.TTTextBox();
        this.KPSSex.Name = "KPSSex";
        this.KPSSex.CharacterCasing = CharacterCasing.Upper;
        this.KPSSex.InputTurkishCharacter = true;
        this.KPSSex.ReadOnly = true;

        this.SKRSMaritalStatus = new TTVisual.TTObjectListBox();
        this.SKRSMaritalStatus.ListDefName = "SKRSMedeniHaliList";
        this.SKRSMaritalStatus.Name = "SKRSMaritalStatus";
        this.SKRSMaritalStatus.ReadOnly = true;

        this.KPSFatherName = new TTVisual.TTTextBox();
        this.KPSFatherName.Name = "KPSFatherName";
        this.KPSFatherName.CharacterCasing = CharacterCasing.Upper;
        this.KPSFatherName.InputTurkishCharacter = true;
        this.KPSFatherName.ReadOnly = true;

        this.labelExDate = new TTVisual.TTLabel();
        this.labelExDate.Text = i18n("M19944", "Ölüm Tarihi");
        this.labelExDate.Name = "labelExDate";
        this.labelExDate.TabIndex = 19;

        this.ExDate = new TTVisual.TTDateTimePicker();
        this.ExDate.Format = DateTimePickerFormat.Long;
        this.ExDate.Name = "ExDate";
        this.ExDate.TabIndex = 18;
        this.ExDate.ReadOnly = true;

        this.labelSex = new TTVisual.TTLabel();
        this.labelSex.Text = i18n("M12265", "Cinsiyet");
        this.labelSex.Name = "labelSex";
        this.labelSex.TabIndex = 17;

        this.Sex = new TTVisual.TTObjectListBox();
        this.Sex.ListDefName = "SKRSCinsiyetList";
        this.Sex.Name = "Sex";
        this.Sex.TabIndex = 16;
        this.Sex.ReadOnly = true;

        this.labelCityOfBirth = new TTVisual.TTLabel();
        this.labelCityOfBirth.Text = i18n("M13139", "Doğum Yeri");
        this.labelCityOfBirth.Name = "labelCityOfBirth";
        this.labelCityOfBirth.TabIndex = 11;

        this.CityOfBirth = new TTVisual.TTObjectListBox();
        this.CityOfBirth.ListDefName = "SKRSILKodlariList";
        this.CityOfBirth.Name = "CityOfBirth";
        this.CityOfBirth.TabIndex = 10;
        this.CityOfBirth.ReadOnly = true;

        this.labelSurname = new TTVisual.TTLabel();
        this.labelSurname.Text = i18n("M22205", "Soyadı");
        this.labelSurname.Name = "labelSurname";
        this.labelSurname.TabIndex = 9;

        this.Surname = new TTVisual.TTTextBox();
        this.Surname.Name = "Surname";
        this.Surname.TabIndex = 8;
        this.Surname.InputTurkishCharacter = true;
        this.Surname.ReadOnly = true;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = i18n("M10514", "Adı");
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 7;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Name = "Name";
        this.Name.TabIndex = 6;
        this.Name.CharacterCasing = CharacterCasing.Upper;
        this.Name.InputTurkishCharacter = true;
        this.Name.ReadOnly = true;

        this.labelMotherName = new TTVisual.TTLabel();
        this.labelMotherName.Text = i18n("M11037", "Anne Adı");
        this.labelMotherName.Name = "labelMotherName";
        this.labelMotherName.TabIndex = 5;

        this.MotherName = new TTVisual.TTTextBox();
        this.MotherName.Name = "MotherName";
        this.MotherName.TabIndex = 4;
        this.MotherName.CharacterCasing = CharacterCasing.Upper;
        this.MotherName.InputTurkishCharacter = true;
        this.MotherName.ReadOnly = true;

        this.labelFatherName = new TTVisual.TTLabel();
        this.labelFatherName.Text = i18n("M11390", "Baba Adı");
        this.labelFatherName.Name = "labelFatherName";
        this.labelFatherName.TabIndex = 3;

        this.FatherName = new TTVisual.TTTextBox();
        this.FatherName.Name = "FatherName";
        this.FatherName.TabIndex = 2;
        this.FatherName.ReadOnly = true;

        this.labelBirthDate = new TTVisual.TTLabel();
        this.labelBirthDate.Text = i18n("M13132", "Doğum Tarihi");
        this.labelBirthDate.Name = "labelBirthDate";
        this.labelBirthDate.TabIndex = 1;

        this.BirthDate = new TTVisual.TTDateTimePicker();
        this.BirthDate.Format = DateTimePickerFormat.Long;
        this.BirthDate.Name = "BirthDate";
        this.BirthDate.TabIndex = 0;
        this.BirthDate.ReadOnly = true;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M17850", "KPS Bilgileri");
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 0;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.ReadOnly = true;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 0;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M13132", "Doğum Tarihi");
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 1;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M23815", "Uyruk");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 21;

        this.ttdatetimepicker3 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker3.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker3.ReadOnly = true;
        this.ttdatetimepicker3.Name = "ttdatetimepicker3";
        this.ttdatetimepicker3.TabIndex = 18;

        this.ttobjectlistbox4 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox4.ReadOnly = true;
        this.ttobjectlistbox4.ListDefName = "SKRSUlkeKodlariList";
        this.ttobjectlistbox4.Name = "ttobjectlistbox4";
        this.ttobjectlistbox4.TabIndex = 20;

        this.tttextbox8 = new TTVisual.TTTextBox();
        this.tttextbox8.ReadOnly = true;
        this.tttextbox8.Name = "tttextbox8";
        this.tttextbox8.TabIndex = 2;
        this.tttextbox8.InputTurkishCharacter = true;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M19944", "Ölüm Tarihi");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 19;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M11390", "Baba Adı");
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 3;

        this.tttextbox7 = new TTVisual.TTTextBox();
        this.tttextbox7.ReadOnly = true;
        this.tttextbox7.Name = "tttextbox7";
        this.tttextbox7.TabIndex = 4;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M12265", "Cinsiyet");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 17;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M11037", "Anne Adı");
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 5;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ReadOnly = true;
        this.ttobjectlistbox1.ListDefName = "SKRSCinsiyetList";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 16;

        this.tttextbox6 = new TTVisual.TTTextBox();
        this.tttextbox6.ReadOnly = true;
        this.tttextbox6.Name = "tttextbox6";
        this.tttextbox6.TabIndex = 6;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M10514", "Adı");
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 7;

        this.tttextbox5 = new TTVisual.TTTextBox();
        this.tttextbox5.ReadOnly = true;
        this.tttextbox5.Name = "tttextbox5";
        this.tttextbox5.TabIndex = 8;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M22205", "Soyadı");
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 9;

        this.ttobjectlistbox2 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox2.ReadOnly = true;
        this.ttobjectlistbox2.ListDefName = "SKRSILKodlariList";
        this.ttobjectlistbox2.Name = "ttobjectlistbox2";
        this.ttobjectlistbox2.TabIndex = 10;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M13139", "Doğum Yeri");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 11;

        this.ttgroupbox1.Controls = [this.labelNationality, this.Nationality, this.labelExDate, this.ExDate, this.labelSex, this.Sex, this.labelCityOfBirth, this.CityOfBirth, this.labelSurname, this.Surname, this.labelName, this.Name, this.labelMotherName, this.MotherName, this.labelFatherName, this.FatherName, this.labelBirthDate, this.BirthDate];
        this.ttgroupbox2.Controls = [this.ttdatetimepicker1, this.ttlabel11, this.ttlabel5, this.ttdatetimepicker3, this.ttobjectlistbox4, this.tttextbox8, this.ttlabel2, this.ttlabel10, this.tttextbox7, this.ttlabel3, this.ttlabel9, this.ttobjectlistbox1, this.tttextbox6, this.ttlabel8, this.tttextbox5, this.ttlabel7, this.ttobjectlistbox2, this.ttlabel6];
        this.Controls = [this.ttgroupbox1, this.labelNationality, this.Nationality, this.labelExDate, this.ExDate, this.labelSex, this.Sex, this.labelCityOfBirth, this.CityOfBirth, this.labelSurname, this.Surname, this.labelName, this.Name, this.labelMotherName, this.MotherName, this.labelFatherName, this.FatherName, this.labelBirthDate, this.BirthDate, this.ttgroupbox2, this.ttdatetimepicker1, this.ttlabel11, this.ttlabel5, this.ttdatetimepicker3, this.ttobjectlistbox4, this.tttextbox8, this.ttlabel2, this.ttlabel10, this.tttextbox7, this.ttlabel3, this.ttlabel9, this.ttobjectlistbox1, this.tttextbox6, this.ttlabel8, this.tttextbox5, this.ttlabel7, this.ttobjectlistbox2, this.ttlabel6];

    }
    public btnClose_Clicked() {
        this.OnClosing.emit(true);
    }
    public async btnUseKPSPatientDetailInfo_Clicked() {

        let message: string;
        message = i18n("M15435", "Hastanın Mernis bilgilerinde eksiklik var. Devam etmek istiyor musunuz?");
        let result: string ;

        if (this.patientCompareFormViewModel._KPSInfo == null || 
            this.patientCompareFormViewModel._KPSInfo.KPSName == "" || this.patientCompareFormViewModel._KPSInfo.KPSSurname == "" ||
            this.patientCompareFormViewModel._KPSInfo.KPSName == null || this.patientCompareFormViewModel._KPSInfo.KPSSurname == null ||
            (this.patientCompareFormViewModel._KPSInfo.KPSUniqueRefNo == null && this.patientCompareFormViewModel._KPSInfo.KPsForeignUniqueRefNo == null))
        {
            // result = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), message, 1);
            ServiceLocator.MessageService.showError("Gelen Mernis Bilgilerinde isim,soyisim ve/veya kimlik numarasında eksiklik olduğu için KPS bilgileri kullanılamaz.");
            result = "CANCEL";
        }
        else
            result = "OK";

        if (result === "OK") {

            this.patientCompareFormViewModel._Patient.Name = Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSName);
            this.patientCompareFormViewModel._Patient.Surname = Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSSurname);
            this.patientCompareFormViewModel._Patient.Nationality = this.patientCompareFormViewModel._KPSInfo.KPSNationality;
            this.patientCompareFormViewModel._Patient.MotherName = Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSMotherName);
            this.patientCompareFormViewModel._Patient.FatherName = Util.turkishToUpper(this.patientCompareFormViewModel._KPSInfo.KPSFatherName);
            this.patientCompareFormViewModel._Patient.BirthPlace = this.patientCompareFormViewModel._KPSInfo.KPSBirthPlace;
            this.patientCompareFormViewModel._Patient.BirthDate = this.patientCompareFormViewModel._KPSInfo.KPSBirthDate;
            this.patientCompareFormViewModel._Patient.Sex = this.patientCompareFormViewModel._KPSInfo.KPSSex;
            this.patientCompareFormViewModel._Patient.ExDate = this.patientCompareFormViewModel._KPSInfo.KPSExDate;
            this.patientCompareFormViewModel._Patient.SKRSMaritalStatus = this.patientCompareFormViewModel._KPSInfo.SKRSMaritalStatus;

            this.patientCompareFormViewModel._Patient.Alive = this.patientCompareFormViewModel._KPSInfo.KPSAlive;
            this.patientCompareFormViewModel._Patient.Death = !this.patientCompareFormViewModel._Patient.Alive;
            this.patientCompareFormViewModel._Patient.Foreign = this.patientCompareFormViewModel._KPSInfo.KPSForeign;
            this.patientCompareFormViewModel._Patient.ForeignUniqueRefNo = this.patientCompareFormViewModel._KPSInfo.KPsForeignUniqueRefNo;
            this.patientCompareFormViewModel._Patient.UniqueRefNo = this.patientCompareFormViewModel._KPSInfo.KPSUniqueRefNo;
            this.patientCompareFormViewModel.HomeAddress = this.patientCompareFormViewModel._KPSInfo.HomeAddress;
            this.patientCompareFormViewModel._Patient.IsTrusted = true;

            if(this.patientCompareFormViewModel._Patient.Foreign)
                this.patientCompareFormViewModel._Patient.OtherBirthPlace = this.patientCompareFormViewModel._KPSInfo.KPSBirthPlace;

            let _tempDate = null;
            if (this.patientCompareFormViewModel._Patient.KPSUpdateDate != null)
                _tempDate = new Date(this.patientCompareFormViewModel._Patient.KPSUpdateDate.toString().substring(0, 10));
            if (_tempDate != null)
                this.patientCompareFormViewModel._Patient.KPSUpdateDate = new Date(_tempDate.getFullYear(), _tempDate.getMonth() + 1, _tempDate.getDate());

            try {
                await this.ClientSidePostScript(null);
                await this.PostScript(null);

                let injector = ServiceLocator.Injector;
                let messageService: MessageService = injector.get(MessageService);
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                await httpService.post(this._DocumentServiceUrl, this._ViewModel, PatientCompareFormViewModel);
                await this.loadEmptyForm();

                this.OnClosing.emit(true); //üst controle erişmek için
                this.SubmitPatientViewModel.emit(this.patientCompareFormViewModel);

            }
            catch (err) {
                ServiceLocator.MessageService.showError(err);
            }
    }

    }

    public async btnUseExistingPatientDetailInfo_Clicked() {
        //TODO:trusted değilse uodate tarihini ne yapıcaz incele
        //if (!this.patientCompareFormViewModel._Patient.IsTrusted)// daha sonra butondan da çağırılırsa ve daha önce mernis bilgisi çekildi ise nullama
        //    this.patientCompareFormViewModel._Patient.KPSUpdateDate = null;//server saatini attık ama varolan veriyi kullan derse update etmeyecek

        this.patientCompareFormViewModel._Patient.IsTrusted = false; //adam ben bunu kullanıcam derse güvenilir mi dicez
        let _tempDate = null;
        if (this.patientCompareFormViewModel._Patient.KPSUpdateDate != null)
            _tempDate = new Date(this.patientCompareFormViewModel._Patient.KPSUpdateDate.toString().substring(0, 10));
        if (_tempDate != null)
            this.patientCompareFormViewModel._Patient.KPSUpdateDate = new Date(_tempDate.getFullYear(), _tempDate.getMonth() + 1, _tempDate.getDate());

        try {
            await this.ClientSidePostScript(null);
            await this.PostScript(null);

            // let injector = ServiceLocator.Injector;
            // let messageService: MessageService = injector.get(MessageService);
            // let httpService: NeHttpService = ServiceLocator.NeHttpService;
            // await httpService.post(this._DocumentServiceUrl, this._ViewModel, PatientCompareFormViewModel);
            // await this.loadEmptyForm();

            this.OnClosing.emit(true); //üst controle erişmek için

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    ///
    ///#region
    ///

    async patientKPSChanged(patient: any) {
        this.patientCompareFormViewModel._Patient = patient;
        await this.LoadPatient(this.patientCompareFormViewModel._Patient);
    }
    public async LoadPatient(patient: Patient) {

        try {
            let that = this;
            this.initViewModel();
            if (patient != null) {
                let result = await this.httpService.post('/api/PatientService/NewPatientCompareForm', patient, PatientCompareFormViewModel);
                that._ViewModel = result;
                that._KPSInfo = result._KPSInfo;
                this.loadViewModel();

            }
        }
        catch (err) {
            console.error(err);
            ServiceLocator.MessageService.showError(err);
        }
    }
    //#endregion
}
