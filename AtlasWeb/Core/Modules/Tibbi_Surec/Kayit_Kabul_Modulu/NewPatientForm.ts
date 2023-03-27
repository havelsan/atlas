//$7F700D2B
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { NewPatientFormViewModel } from './NewPatientFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientIdentityAndAddress } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKanGrubu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOzurlulukDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSUlkeKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYabanciHastaTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { InputFormat } from 'NebulaClient/Utils/Enums/InputFormat';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { RequirementExecutor } from "Fw/Requirements/RequirementExecutor";
import { ITTObject } from "NebulaClient/StorageManager/InstanceManagement/ITTObject";

import { PatientInfoRequirements } from "./Requirements/PatientInfoRequirements";
import { PatientAdmissionSearchForm } from "./PatientAdmissionSearch/PatientAdmissionSearchForm";
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'NewPatientForm',
    templateUrl: './NewPatientForm.html',
    outputs: ['OnClosing'],
    providers: [MessageService]
})



export class NewPatientForm extends TTVisual.TTForm implements OnInit, IModal {
    pBirthDate: TTVisual.ITTDateTimePicker;
    pBloodGroup: TTVisual.ITTObjectListBox;
    pCityOfBirth: TTVisual.ITTTextBox;
    pBusinessAddress: TTVisual.ITTTextBox;
    pImportantPatientInfo: TTVisual.ITTTextBox;
    pPrivacyEndDate: TTVisual.ITTDateTimePicker;


    pEducationStatus: TTVisual.ITTObjectListBox;
    pSKRSMaritalStatus: TTVisual.ITTObjectListBox;
    pFatherName: TTVisual.ITTTextBox;
    // pForeignUniqueNo: TTVisual.ITTTextBox;
    pHomeAddress: TTVisual.ITTTextBox;
    pImportantPAInfo: TTVisual.ITTTextBox;
    pMobilePhone: TTVisual.ITTMaskedTextBox;
    pBusinessPhone: TTVisual.ITTMaskedTextBox;
    pMotherName: TTVisual.ITTTextBox;
    pName: TTVisual.ITTTextBox;
    pNationality: TTVisual.ITTObjectListBox;
    pOccupation: TTVisual.ITTObjectListBox;
    pOtherBirthPlace: TTVisual.ITTTextBox;
    pPassportNo: TTVisual.ITTTextBox;
    pRelativeFullName: TTVisual.ITTTextBox;
    pRelativeHomeAddress: TTVisual.ITTTextBox;
    pRelativeMobilePhone: TTVisual.ITTTextBox;
    pSex: TTVisual.ITTObjectListBox;
    pSurname: TTVisual.ITTTextBox;
    pSKRSYabanciHasta: TTVisual.ITTObjectListBox;
    pSKRSOzurlulukDurumu: TTVisual.ITTObjectListBox;
    pEMail: TTVisual.ITTTextBox;
    pUniqueRefNo: TTVisual.ITTTextBox;
    pUnIdentified: TTVisual.ITTCheckBox;
    pPrivacy: TTVisual.ITTCheckBox;
    pWorkAddress: TTVisual.ITTTextBox;
    pWorkPhone: TTVisual.ITTTextBox;
    pPrivacyName: TTVisual.ITTTextBox;
    pPrivacySurname: TTVisual.ITTTextBox;
    pPrivacyReason: TTVisual.ITTTextBox;
    pBeneficiaryUniqueRefNo: TTVisual.ITTTextBox;
    pBeneficiaryName: TTVisual.ITTTextBox;
    pDonorUniqueRefNo: TTVisual.ITTTextBox;

    private PatientUIComponents: Map<string, any>;
    public controls = [];
    public PatientInfoUIComponents = [];
    @ViewChild(PatientAdmissionSearchForm) patientSearchAuto: PatientAdmissionSearchForm;
    public newPatientFormViewModel: NewPatientFormViewModel = new NewPatientFormViewModel();

    public get _Patient(): Patient {
        return this._TTObject as Patient;
    }
    private NewPatientForm_DocumentUrl: string = '/api/PatientService/NewPatientForm';
    public _EmptyDocumentUrl: string = '/api/PatientService/PatientEmptyForm';
    private _modalInfo: ModalInfo;

    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalStateService: ModalStateService,
        protected ngZone: NgZone) {
        super('PATIENT', 'NewPatientForm');
        this._DocumentServiceUrl = this.NewPatientForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public setInputParam(value: Patient) {
        this.newPatientFormViewModel._Patient = value;
        this._ViewModel._Patient = value;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    // ***** Method declarations start *****

    public enablepUnicrefNo: boolean = true;
    public enablepUndefinedPatient: boolean = true;
    public showPopupCompareForm: boolean = false;
    public globalPatientObjectID: any;

    requirementExecutor: RequirementExecutor = new RequirementExecutor();
    requirementsResultCode: RequirementResultCode = new RequirementResultCode();

    async pChanged(patient: any) {
        let that = this;
        that.newPatientFormViewModel._Patient = patient;
        await this.updatepAvatarPhoto(patient);
        await this.LoadPatient(that.newPatientFormViewModel._Patient);
        await this.updatepRequiredColors();


        if (patient != null && patient.UniqueRefNo != null) {
            this.enablepUndefinedPatient = false;
            //  this.enablepUnicrefNo = true;
        }

    }
    private updatePatientInfoUIComponents(patient: Patient): void {
        this.PatientInfoUIComponents.forEach(element => {
            if (this.newPatientFormViewModel.ModifyPatientInfoRole == true) {
                element.Enabled = true;
                this.enablepUnicrefNo = true;
            }
            else if (patient != null && patient.IsTrusted == true) {
                element.Enabled = false;
                this.enablepUnicrefNo = false;
            }
            else {
                element.Enabled = (patient != null && (<ITTObject>this._Patient).IsNew);
                this.enablepUnicrefNo = element.Enabled;
            }
        });
    }

    public async LoadPatient(patient: Patient) {

        try {
            let that = this;
            this.initViewModel();
            if (patient != null) {
                let result = await this.httpService.post('/api/PatientService/NewPatientFormLoadClient', patient, NewPatientFormViewModel);
                that._ViewModel = result;
                this.loadViewModel();

                await this.updatePatientInfoUIComponents(patient);

            }
        }
        catch (err) {
            console.error(err);
            ServiceLocator.MessageService.showError(err);
        }
    }
    public async PatientSave_Click()//Arşiv + Kabul Kaydı: Promise<void>
    {

        let patientInfoRequirements: PatientInfoRequirements = new PatientInfoRequirements(this._Patient, this.newPatientFormViewModel.tempName, this.newPatientFormViewModel.tempSurname, this.PatientUIComponents);
        this.requirementExecutor.addRequirement(patientInfoRequirements);
        this.requirementsResultCode = this.requirementExecutor.Execute();
        this.requirementExecutor.clearAllRequirements();

        if (this.requirementsResultCode.resultCode > 0) {

            ServiceLocator.MessageService.showError(this.requirementsResultCode.resultMessage);
        }
        else if (this.requirementsResultCode.resultCode == 0) {
           
            if (this.newPatientFormViewModel != null)
            {
                if (this.newPatientFormViewModel.tempMobilePhone == null || this.newPatientFormViewModel.tempMobilePhone.replace(/\s/g, "") == "") {                
                    ServiceLocator.MessageService.showError("Cep telefonu alanı boş bırakılamaz.");
                }
                else if (this.newPatientFormViewModel.tempMobilePhone.replace(/\s/g, "").length < 10) {
                    ServiceLocator.MessageService.showError("Cep telefonu alanı uzaunluğu 10 karakter olmalıdır.");
                }            
                else{
                    try {
                        this.globalPatientObjectID = this._Patient.ObjectID;
        
                        if (this._Patient.UnIdentified === true || this._Patient.Foreign === true)
                            this._Patient.IsTrusted = true;
        
                        try {
                            await this.ClientSidePostScript(null);
                            await this.PostScript(null);
                            let injector = ServiceLocator.Injector;
                            let messageService: MessageService = injector.get(MessageService);
                            let httpService: NeHttpService = ServiceLocator.NeHttpService;
                            let result = await httpService.post(this._DocumentServiceUrl, this._ViewModel, NewPatientFormViewModel);
                            this.globalPatientObjectID = result;
                            await this.AfterContextSavedScript(null);
                            await this.LoadPatient(this.newPatientFormViewModel._Patient);
                            this.showSaveSuccessMessage();
                            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.newPatientFormViewModel._Patient);
        
                        }
                        catch (err) {
                            ServiceLocator.MessageService.showError(err);
                        }
                    }
                    catch (ex) {
                        ServiceLocator.MessageService.showError(ex);
                    }
                }
        }

        }

    }

    public async NewPatientSave_Click() {
        this.globalPatientObjectID = null;

        this.enablepUndefinedPatient = true;
        // this.enablepUnicrefNo = true;

        await this.initViewModel();
        await this.patientSearchAuto.Clear();
        await this.ngOnInit();

        await this.loadEmptyForm();
    }

    public imageSource: any;
    public ispCameraShowing = false;
    pIncludedPhotoList: Array<string> = ["10000000000"];

    onpCapturePhotoChanged(event): void {
        this.imageSource = event;
        this.ispCameraShowing = false;
    }

    public onpCameraShowingStarted() {
        this.ispCameraShowing = true;
    }
    private isIncludeValue(searchingValue: Number) {

        let compareValue: string = searchingValue + "";
        for (let value of this.pIncludedPhotoList) {
            if (value == compareValue)
                return true;
        }
        return false;
    }

    photoCaptured(data) {
        this.newPatientFormViewModel.PhotoString = data;
    }

    private updatepAvatarPhoto(Patient: any): void {

        if (Patient != null) {

            if (this.isIncludeValue(Patient.UniqueRefNo) == true) {
                this.imageSource = "../../Content/PatientAdmission/" + Patient.UniqueRefNo + ".jpg";
            }
            else if (Patient.Sex != null) {
                if (Patient.Sex.ADI === "ERKEK")
                    this.imageSource = "../../Content/PatientAdmission/avatar_men.png";
                else
                    this.imageSource = "../../Content/PatientAdmission/avatar_women.png";
            }
            else {
                this.imageSource = "../../Content/PatientAdmission/avatar_unknown.png";
            }
        }
        else {
            this.imageSource = "../../Content/PatientAdmission/avatar_unknown.png";
        }

    }

    // *****Method declarations end *****
    public initViewModel(): void {
        this._TTObject = new Patient();
        this.newPatientFormViewModel = new NewPatientFormViewModel();
        this._ViewModel = this.newPatientFormViewModel;
        this.newPatientFormViewModel._Patient = this._TTObject as Patient;
        this.newPatientFormViewModel._Patient.PatientAddress = new PatientIdentityAndAddress();
        this.newPatientFormViewModel._Patient.Sex = new SKRSCinsiyet();
        this.newPatientFormViewModel._Patient.SKRSYabanciHasta = new SKRSYabanciHastaTuru();
        // this.newPatientFormViewModel._Patient.CityOfBirth = new SKRSILKodlari();
        this.newPatientFormViewModel._Patient.Nationality = new SKRSUlkeKodlari();
        this.newPatientFormViewModel._Patient.Occupation = new SKRSMeslekler();
        this.newPatientFormViewModel._Patient.EducationStatus = new SKRSOgrenimDurumu();
        this.newPatientFormViewModel._Patient.BloodGroupType = new SKRSKanGrubu();
        this.newPatientFormViewModel._Patient.SKRSMaritalStatus = new SKRSMedeniHali();
        this.newPatientFormViewModel._Patient.SKRSOzurlulukDurumu = new SKRSOzurlulukDurumu();
    }

    protected isLoadViewModel(): boolean {
        if (this._ViewModel._Patient.ObjectID == null)
            return false;

    }


    protected async ClientSidePreScript() {
        if (this.newPatientFormViewModel != null)
            if (this.newPatientFormViewModel._Patient != null)
                if (this.newPatientFormViewModel._Patient.IsNew != null)
                    if (this.newPatientFormViewModel._Patient.IsNew == false)
                        this.LoadPatient(this.newPatientFormViewModel._Patient);
    }

    protected loadViewModel() {
        let that = this;

        that.newPatientFormViewModel = this._ViewModel as NewPatientFormViewModel;
        that._TTObject = this.newPatientFormViewModel._Patient;
        if (this.newPatientFormViewModel == null)
            this.newPatientFormViewModel = new NewPatientFormViewModel();
        if (this.newPatientFormViewModel._Patient == null)
            this.newPatientFormViewModel._Patient = new Patient();
        let patientAddressObjectID = that.newPatientFormViewModel._Patient["PatientAddress"];
        if (patientAddressObjectID != null && (typeof patientAddressObjectID === "string")) {
            let patientAddress = that.newPatientFormViewModel.PatientIdentityAndAddresss.find(o => o.ObjectID.toString() === patientAddressObjectID.toString());
            if (patientAddress) {
                that.newPatientFormViewModel._Patient.PatientAddress = patientAddress;
            }
        }
        let sexObjectID = that.newPatientFormViewModel._Patient["Sex"];
        if (sexObjectID != null && (typeof sexObjectID === "string")) {
            let sex = that.newPatientFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
            if (sex) {
                that.newPatientFormViewModel._Patient.Sex = sex;
            }
        }
        let sKRSYabanciHastaObjectID = that.newPatientFormViewModel._Patient["SKRSYabanciHasta"];
        if (sKRSYabanciHastaObjectID != null && (typeof sKRSYabanciHastaObjectID === 'string')) {
            let sKRSYabanciHasta = that.newPatientFormViewModel.SKRSYabanciHastaTurus.find(o => o.ObjectID.toString() === sKRSYabanciHastaObjectID.toString());
            if (sKRSYabanciHasta) {
                that.newPatientFormViewModel._Patient.SKRSYabanciHasta = sKRSYabanciHasta;
            }
        }

        let sKRSMedeniHaliObjectID = that.newPatientFormViewModel._Patient["SKRSMaritalStatus"];
        if (sKRSMedeniHaliObjectID != null && (typeof sKRSMedeniHaliObjectID === 'string')) {
            let sKRSMedeniHali = that.newPatientFormViewModel.SKRSMaritalStatuss.find(o => o.ObjectID.toString() === sKRSMedeniHaliObjectID.toString());
            if (sKRSMedeniHali) {
                that.newPatientFormViewModel._Patient.SKRSMaritalStatus = sKRSMedeniHali;
            }
        }

        let nationalityObjectID = that.newPatientFormViewModel._Patient["Nationality"];
        if (nationalityObjectID != null && (typeof nationalityObjectID === "string")) {
            let nationality = that.newPatientFormViewModel.SKRSUlkeKodlaris.find(o => o.ObjectID.toString() === nationalityObjectID.toString());
            if (nationality) {
                that.newPatientFormViewModel._Patient.Nationality = nationality;
            }
        }
        let occupationObjectID = that.newPatientFormViewModel._Patient["Occupation"];
        if (occupationObjectID != null && (typeof occupationObjectID === "string")) {
            let occupation = that.newPatientFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === occupationObjectID.toString());
            if (occupation) {
                that.newPatientFormViewModel._Patient.Occupation = occupation;
            }
        }
        let educationStatusObjectID = that.newPatientFormViewModel._Patient["EducationStatus"];
        if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
            let educationStatus = that.newPatientFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
            if (educationStatus) {
                that.newPatientFormViewModel._Patient.EducationStatus = educationStatus;
            }
        }

        let bloodGroupTypeObjectID = that.newPatientFormViewModel._Patient["BloodGroupType"];
        if (bloodGroupTypeObjectID != null && (typeof bloodGroupTypeObjectID === "string")) {
            let kanGrubu = that.newPatientFormViewModel.SKRSKanGrubus.find(o => o.ObjectID.toString() === bloodGroupTypeObjectID.toString());
            if (kanGrubu) {
                that.newPatientFormViewModel._Patient.BloodGroupType = kanGrubu;
            }
        }

        let sKRSOzurlulukDurumuObjectID = that.newPatientFormViewModel._Patient["SKRSOzurlulukDurumu"];
        if (sKRSOzurlulukDurumuObjectID != null && (typeof sKRSOzurlulukDurumuObjectID === 'string')) {
            let sKRSOzurlulukDurumu = that.newPatientFormViewModel.SKRSOzurlulukDurumus.find(o => o.ObjectID.toString() === sKRSOzurlulukDurumuObjectID.toString());
            if (sKRSOzurlulukDurumu) {
                that.newPatientFormViewModel._Patient.SKRSOzurlulukDurumu = sKRSOzurlulukDurumu;
            }
        }

        this.updatePatientInfoUIComponents(this.newPatientFormViewModel._Patient);

        this.updatepAvatarPhoto(this.newPatientFormViewModel._Patient);
    }
    protected async loadEmptyForm() {
        try {

            let fullApiUrl: string = "";

            fullApiUrl = `${this._EmptyDocumentUrl}`;


            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<NewPatientFormViewModel>(fullApiUrl, NewPatientFormViewModel);
            this._ViewModel = response;
            this.loadViewModel();


            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            this.loadErrorOccurred(err);
        }
    }

    async ngOnInit() {
        let that = this;
        if (this.newPatientFormViewModel != null)
            if (this.newPatientFormViewModel._Patient != null)
                if (this.newPatientFormViewModel._Patient.IsNew != null)
                    if (this.newPatientFormViewModel._Patient.IsNew == true)
                        await this.loadEmptyForm();
        await this.load(NewPatientFormViewModel);
  
    }

    keyDownForNumericControl(event: any) {

        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }
    public onpBirthDateChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.BirthDate != event) {
                this._Patient.BirthDate = event;
            }
        }
    }
    public onpPrivacyEndDateChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.PrivacyEndDate != event) {
                this._Patient.PrivacyEndDate = event;
            }
        }
    }

    public onpBloodGroupChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.BloodGroupType != event) {
                this._Patient.BloodGroupType = event;
            }
        }
    }

    public onpCityOfBirthChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.BirthPlace != event) {
                this._Patient.BirthPlace = event;
            }
        }
    }

    public onpEducationStatusChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.EducationStatus != event) {
                this._Patient.EducationStatus = event;
            }
        }
    }
    public onpSKRSMaritalStatusChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.SKRSMaritalStatus != event) {
                this._Patient.SKRSMaritalStatus = event;
            }
        }
    }

    public onpFatherNameChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.FatherName != event) {
                this._Patient.FatherName = event;
            }
        }
    }

    public onForeignUniqueNoChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.YUPASSNO != event) {
                this._Patient.YUPASSNO = event;
            }
        }
    }

    public onpHomeAddressChanged(event): void {
        if (event != null) {
            if (this.newPatientFormViewModel.tempHomeAddress != event) {
                this.newPatientFormViewModel.tempHomeAddress = event;
            }
        }
    }

    public onpMobilePhoneChanged(event): void {
        if (event != null) {
            if (this.newPatientFormViewModel.tempMobilePhone != event) {
                this.newPatientFormViewModel.tempMobilePhone = event;
            }
        }
    }
    public onpUnIdentifiedChanged(event): void {

        if (this._Patient != null && this._Patient.UnIdentified != event) {
            this._Patient.UnIdentified = event;
            // this.enablepUnicrefNo = (!event)
        }


    }
    public onpMotherNameChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.MotherName != event) {
                this._Patient.MotherName = event;
            }
        }
    }

    public onpNameChanged(event): void {
        if (event != null) {
            if (this.newPatientFormViewModel.tempName != event) {
                this.newPatientFormViewModel.tempName = Util.turkishToUpper(event.value);
                if (event != null)
                    this.pName.BackColor = "white";
            }
        }
    }

    public onpNationalityChanged(event): void {
        if (this._Patient != null && this._Patient.Nationality != event) {
            this._Patient.Nationality = event;
        }
        if (event != null)
            this.pNationality.BackColor = "white";
    }

    public onpOccupationChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.Occupation != event) {
                this._Patient.Occupation = event;
            }
        }
    }

    public onpOtherBirthPlaceChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.OtherBirthPlace != event) {
                this._Patient.OtherBirthPlace = event;
            }
        }
    }

    public onpPassportNoChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.PassportNo != event) {
                this._Patient.PassportNo = event;
            }
        }
    }
    public onpEMailChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.EMail != event) {
                this._Patient.EMail = event;
            }
        }
    }

    public onpRelativeFullNameChanged(event): void {
        if (event != null) {
            if (this._Patient != null &&
                this._Patient.PatientAddress != null && this._Patient.PatientAddress.RelativeFullName != event) {
                this._Patient.PatientAddress.RelativeFullName = event;
            }
        }
    }

    public onpRelativeHomeAddressChanged(event): void {
        if (event != null) {
            if (this._Patient != null &&
                this._Patient.PatientAddress != null && this._Patient.PatientAddress.RelativeHomeAddress != event) {
                this._Patient.PatientAddress.RelativeHomeAddress = event;
            }
        }
    }

    public onpRelativeMobilePhoneChanged(event): void {
        if (event != null) {
            if (this._Patient != null &&
                this._Patient.PatientAddress != null && this._Patient.PatientAddress.RelativeMobilePhone != event) {
                this._Patient.PatientAddress.RelativeMobilePhone = event;
            }
        }
    }
    public onpImportantPatientInfoChanged(event): void {

        if (this._Patient != null && this._Patient.ImportantPatientInfo != event) {
            this._Patient.ImportantPatientInfo = event;
        }

    }
    public onpSexChanged(event): void {
        if (this._Patient != null && this._Patient.Sex != event) {
            this._Patient.Sex = event;
            if (event == null)
                event = new SKRSCinsiyet();
            else
                this.pSex.BackColor = "White";
        }
    }

    public onpSurnameChanged(event): void {
        if (event != null) {
            if (this.newPatientFormViewModel.tempSurname != event) {
                this.newPatientFormViewModel.tempSurname = Util.turkishToUpper(event.value);
                if (event != null)
                    this.pSurname.BackColor = "white";
            }
        }
    }

    public onpUniqueRefNoChanged(event): void {

        if (this.newPatientFormViewModel.tempUniqueRefNo != event.value) {
            this.newPatientFormViewModel.tempUniqueRefNo = event.value;
        }

        if (event == null || event.value == null || event.value == "") {
            this.enablepUndefinedPatient = true;
        }
        else {
            this.enablepUndefinedPatient = false;
            this._Patient.UnIdentified = false;
        }
    }

    public onpBusinessAddressChanged(event): void {

        if (this._Patient != null &&
            this._Patient.PatientAddress != null && this._Patient.PatientAddress.BusinessAddress != event) {
            this._Patient.PatientAddress.BusinessAddress = event;
        }

    }

    public onpBusinessPhoneChanged(event): void {

        if (this._Patient != null &&
            this._Patient.PatientAddress != null && this._Patient.PatientAddress.BusinessPhone != event) {
            this._Patient.PatientAddress.BusinessPhone = event;
        }

    }

    public onpPrivacyChanged(event): void {

        if (this._Patient != null && this._Patient.Privacy != event) {
            this._Patient.Privacy = event;
        }

        if (event) {
            this.pPrivacyName.ReadOnly = false;
            this.pPrivacySurname.ReadOnly = false;
            this.pPrivacyReason.ReadOnly = false;
            this.pPrivacyEndDate.ReadOnly = false;
            this.pPrivacyEndDate.Enabled = true;

            if(this.newPatientFormViewModel.tempPrivacyName == null && this.newPatientFormViewModel.tempName != null)
            {
                this.newPatientFormViewModel.tempPrivacyName = this.newPatientFormViewModel.tempName.substr(0,2) + this.makeRamdomID(this.newPatientFormViewModel.tempName.length - 2);
            }

            if(this.newPatientFormViewModel.tempPrivacySurname == null && this.newPatientFormViewModel.tempSurname != null)
            {
                this.newPatientFormViewModel.tempPrivacySurname = this.newPatientFormViewModel.tempSurname.substr(0,2) + this.makeRamdomID(this.newPatientFormViewModel.tempSurname.length - 2);
            }
        }
        else {
            this.pPrivacyName.ReadOnly = true;
            this.pPrivacySurname.ReadOnly = true;
            this.pPrivacyReason.ReadOnly = true;
            this.pPrivacyEndDate.ReadOnly = true;
            this.pPrivacyEndDate.Enabled = false;

            this.newPatientFormViewModel.tempPrivacyName = null;
            this.newPatientFormViewModel.tempPrivacySurname = null;
            this._Patient.PrivacyReason = null;
            this._Patient.PrivacyEndDate = null;
        }
    }
    public onpSKRSYabanciHastaChanged(event): void {

        if (this._Patient != null && this._Patient.SKRSYabanciHasta != event) {
            this._Patient.SKRSYabanciHasta = event;
        }

    }
    public onpSKRSOzurlulukDurumuChanged(event): void {

        if (this._Patient != null && this._Patient.SKRSOzurlulukDurumu != event) {
            this._Patient.SKRSOzurlulukDurumu = event;
        }

    }

    public onpPrivacyNameChanged(event): void {

        if (this.newPatientFormViewModel.tempPrivacyName != event) {
            this.newPatientFormViewModel.tempPrivacyName = Util.turkishToUpper(event);
        }

    }
    public onpPrivacySurnameChanged(event): void {

        if (this.newPatientFormViewModel.tempPrivacySurname != event) {
            this.newPatientFormViewModel.tempPrivacySurname = Util.turkishToUpper(event);
        }

    }
    public onpBeneficiaryNameChanged(event): void {

        if (this._Patient != null &&
            this._Patient.BeneficiaryName != event) {
            this._Patient.BeneficiaryName = event;
        }

    }

    public onpDonorUniqueRefNoChanged(event): void {
        if (event != null) {
            if (this._Patient != null && this._Patient.DonorUniqueRefNo != event) {
                this._Patient.DonorUniqueRefNo = event;
            }
        }
    }

    public onpBeneficiaryUniqueRefNoChanged(event): void {

        if (this._Patient != null &&
            this._Patient.BeneficiaryUniqueRefNo != event) {
            this._Patient.BeneficiaryUniqueRefNo = event;
        }

    }
    public onpPrivacyReasonChanged(event): void {

        if (this._Patient != null && this._Patient.PrivacyReason != event) {
            this._Patient.PrivacyReason = event;
        }

    }
    public ispNationalityTR(): Number {
        if (this._Patient == null)
            return 0;
        if (this._Patient.Nationality == null)
            return 1;
        if (this._Patient.Nationality.Kodu == null)
            return 1;
        if (this._Patient.Nationality.Kodu.Equals("TR") == true)
            return 1;

        return 0;
    }

    public ispNationalityNotTR(): Number {
        if (this._Patient == null)
            return 0;
        if (this._Patient.Nationality == null)
            return 0;
        if (this._Patient.Nationality.Kodu == null)
            return 0;
        if (this._Patient.Nationality.Kodu.Equals("TR") == false)
            return 1;

        return 0;
    }

    public hasGizliHastaKabulRole(): Number {
        if (this.newPatientFormViewModel == null)
            return 0;
        if (this.newPatientFormViewModel.GizliHastaKabulRole == null)
            return 1;
        if (this.newPatientFormViewModel.GizliHastaKabulRole == false)
            return 1;
        if (this.newPatientFormViewModel.GizliHastaKabulRole == true)
            return 1;

        return 1;
    }

    public isPrivacy(): Number {
        if (this._Patient.Privacy == true) {
            this.pPrivacyName.ReadOnly = false;
            this.pPrivacySurname.ReadOnly = false;
            this.pPrivacyReason.ReadOnly = false;
            this.pPrivacyEndDate.ReadOnly = false;
            this.pPrivacyEndDate.Enabled = true;
        }
        else {
            this.pPrivacyName.ReadOnly = true;
            this.pPrivacySurname.ReadOnly = true;
            this.pPrivacyReason.ReadOnly = true;
            this.pPrivacyEndDate.ReadOnly = true;
            this.pPrivacyEndDate.Enabled = false;

            this.newPatientFormViewModel.tempPrivacyName = null;
            this.newPatientFormViewModel.tempPrivacySurname = null;
            this._Patient.PrivacyReason = null;
            this._Patient.PrivacyEndDate = null;
        }

        return 1;
    }


    protected redirectProperties(): void {
        redirectProperty(this.pName, "Text", this.__ttObject, "Name");
        redirectProperty(this.pUniqueRefNo, "Text", this.__ttObject, "UniqueRefNo");
        redirectProperty(this.pBloodGroup, "Value", this.__ttObject, "BloodGroupType");
        redirectProperty(this.pPassportNo, "Text", this.__ttObject, "PassportNo");
        redirectProperty(this.pOtherBirthPlace, "Text", this.__ttObject, "OtherBirthPlace");
        redirectProperty(this.pEMail, "Text", this.__ttObject, "EMail");
        redirectProperty(this.pSurname, "Text", this.__ttObject, "Surname");
        redirectProperty(this.pImportantPAInfo, "Text", this.__ttObject, "ImportantPatientInfo");
        redirectProperty(this.pFatherName, "Text", this.__ttObject, "FatherName");
        redirectProperty(this.pWorkPhone, "Text", this.__ttObject, "PatientAddress.BusinessPhone");
        redirectProperty(this.pRelativeFullName, "Text", this.__ttObject, "PatientAddress.RelativeFullName");
        redirectProperty(this.pRelativeMobilePhone, "Text", this.__ttObject, "PatientAddress.RelativeMobilePhone");
        redirectProperty(this.pMotherName, "Text", this.__ttObject, "MotherName");
        redirectProperty(this.pWorkAddress, "Text", this.__ttObject, "PatientAddress.BusinessAddress");
        redirectProperty(this.pRelativeHomeAddress, "Text", this.__ttObject, "PatientAddress.RelativeHomeAddress");
        //redirectProperty(this.pForeignUniqueNo, "Text", this.__ttObject, "YUPASSNO");
        redirectProperty(this.pBirthDate, "Value", this.__ttObject, "BirthDate");
        redirectProperty(this.pPrivacyEndDate, "Value", this.__ttObject, "PrivacyEndDate");
        redirectProperty(this.pMobilePhone, "Text", this.__ttObject, "PatientAddress.MobilePhone");
        redirectProperty(this.pHomeAddress, "Text", this.__ttObject, "PatientAddress.HomeAddress");
        redirectProperty(this.pUnIdentified, "Value", this.__ttObject, "UnIdentified");
        redirectProperty(this.pPrivacy, "Value", this.__ttObject, "Privacy");
        redirectProperty(this.pPrivacyName, "Text", this.__ttObject, "PrivacyName");
        redirectProperty(this.pPrivacySurname, "Text", this.__ttObject, "PrivacySurname");
        redirectProperty(this.pPrivacyReason, "Text", this.__ttObject, "PrivacyReason");
        redirectProperty(this.pBeneficiaryUniqueRefNo, "Text", this.__ttObject, "BeneficiaryUniqueRefNo");
        redirectProperty(this.pBeneficiaryName, "Text", this.__ttObject, "BeneficiaryName");
        redirectProperty(this.pSKRSYabanciHasta, "Value", this.__ttObject, "SKRSYabanciHasta");
        redirectProperty(this.pDonorUniqueRefNo, "Text", this.__ttObject, "DonorUniqueRefNo");
        redirectProperty(this.pSKRSOzurlulukDurumu, "Value", this.__ttObject, "SKRSOzurlulukDurumu");
    }

    public initFormControls(): void {

        this.pUniqueRefNo = new TTVisual.TTTextBox();
        this.pUniqueRefNo.InputFormat = InputFormat.AlphaOnly;
        this.pUniqueRefNo.CharacterCasing = CharacterCasing.Upper;
        this.pUniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pUniqueRefNo.Name = "UniqueRefNo";
        this.pUniqueRefNo.TabIndex = 0;

        this.pBeneficiaryUniqueRefNo = new TTVisual.TTTextBox();
        this.pBeneficiaryUniqueRefNo.InputFormat = InputFormat.AlphaOnly;
        this.pBeneficiaryUniqueRefNo.CharacterCasing = CharacterCasing.Upper;
        this.pBeneficiaryUniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pBeneficiaryUniqueRefNo.Name = "BeneficiaryUniqueRefNo";

        this.pBeneficiaryName = new TTVisual.TTTextBox();
        this.pBeneficiaryName.Multiline = false;
        this.pBeneficiaryName.Name = "BeneficiaryName";
        this.pBeneficiaryName.TabIndex = 76;

        this.pName = new TTVisual.TTTextBox();
        this.pName.InputFormat = InputFormat.AlphaOnly;
        this.pName.CharacterCasing = CharacterCasing.Upper;
        this.pName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pName.Name = "Name";
        this.pName.TabIndex = 4;

        this.pMobilePhone = new TTVisual.TTMaskedTextBox();
        this.pMobilePhone.Mask = "999 9999999";
        this.pMobilePhone.Name = "MobilePhone";
        this.pMobilePhone.TabIndex = 6;

        this.pBusinessPhone = new TTVisual.TTMaskedTextBox();
        this.pBusinessPhone.Mask = "999 9999999";
        this.pBusinessPhone.Name = "pBusinessPhone";
        this.pBusinessPhone.TabIndex = 6;

        this.pSurname = new TTVisual.TTTextBox();
        this.pSurname.InputFormat = InputFormat.AlphaOnly;
        this.pSurname.CharacterCasing = CharacterCasing.Upper;
        this.pSurname.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pSurname.Name = "Surname";
        this.pSurname.TabIndex = 5;

        this.pFatherName = new TTVisual.TTTextBox();
        this.pFatherName.InputFormat = InputFormat.AlphaOnly;
        this.pFatherName.CharacterCasing = CharacterCasing.Upper;
        this.pFatherName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pFatherName.Name = "FatherName";
        this.pFatherName.TabIndex = 7;

        this.pMotherName = new TTVisual.TTTextBox();
        this.pMotherName.IsNonNumeric = true;
        this.pMotherName.Name = "MotherName";
        this.pMotherName.CharacterCasing = CharacterCasing.Upper;
        this.pMotherName.TabIndex = 50;


        this.pDonorUniqueRefNo = new TTVisual.TTTextBox();
        this.pDonorUniqueRefNo.Name = "DonorUniqueRefNo";
        this.pDonorUniqueRefNo.TabIndex = 184;
        this.pDonorUniqueRefNo.InputFormat = InputFormat.AlphaOnly;
        this.pDonorUniqueRefNo.CharacterCasing = CharacterCasing.Upper;
        this.pDonorUniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";

        this.pHomeAddress = new TTVisual.TTTextBox();
        this.pHomeAddress.Multiline = false;
        this.pHomeAddress.Name = "HomeAddress";
        this.pHomeAddress.TabIndex = 52;

        this.pPassportNo = new TTVisual.TTTextBox();
        this.pPassportNo.Name = "PassportNo";
        this.pPassportNo.TabIndex = 44;

        this.pEMail = new TTVisual.TTTextBox();
        this.pEMail.Name = "tttextbox10";
        this.pEMail.TabIndex = 25;

        this.pRelativeHomeAddress = new TTVisual.TTTextBox();
        this.pRelativeHomeAddress.Multiline = false;
        this.pRelativeHomeAddress.Name = "RelativeHomeAddress";
        this.pRelativeHomeAddress.TabIndex = 85;

        this.pWorkAddress = new TTVisual.TTTextBox();
        this.pWorkAddress.Multiline = false;
        this.pWorkAddress.Name = "WorkAddress";
        this.pWorkAddress.TabIndex = 76;

        this.pWorkPhone = new TTVisual.TTTextBox();
        this.pWorkPhone.Name = "WorkPhone";
        this.pWorkPhone.TabIndex = 75;

        this.pRelativeFullName = new TTVisual.TTTextBox();
        this.pRelativeFullName.Name = "RelativeFullName";
        this.pRelativeFullName.TabIndex = 81;

        this.pRelativeMobilePhone = new TTVisual.TTTextBox();
        this.pRelativeMobilePhone.Name = "RelativeMobilePhone";
        this.pRelativeMobilePhone.TabIndex = 83;

        this.pImportantPAInfo = new TTVisual.TTTextBox();
        this.pImportantPAInfo.Multiline = false;
        this.pImportantPAInfo.Name = "ImportantPAInfo";
        this.pImportantPAInfo.TabIndex = 79;

        this.pOtherBirthPlace = new TTVisual.TTTextBox();
        this.pOtherBirthPlace.Name = "OtherBirthPlace";
        this.pOtherBirthPlace.TabIndex = 175;

        this.pBirthDate = new TTVisual.TTDateTimePicker();
        this.pBirthDate.Format = DateTimePickerFormat.Short;
        this.pBirthDate.Name = "BirthDate";
        this.pBirthDate.TabIndex = 165;

        this.pPrivacyEndDate = new TTVisual.TTDateTimePicker();
        this.pPrivacyEndDate.Format = DateTimePickerFormat.Short;
        this.pPrivacyEndDate.Name = "PrivacyEndDate";
        this.pPrivacyEndDate.TabIndex = 165;

        this.pSex = new TTVisual.TTObjectListBox();
        this.pSex.ListDefName = "SKRSCinsiyetList";
        this.pSex.Name = "Sex";
        this.pSex.TabIndex = 166;

        //this.pCityOfBirth = new TTVisual.TTObjectListBox();
        //this.pCityOfBirth.LinkedControlName = "CountryOfBirth";
        //this.pCityOfBirth.ListDefName = "SKRSILKodlariList";
        //this.pCityOfBirth.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.pCityOfBirth.Name = "CityOfBirth";
        //this.pCityOfBirth.TabIndex = 17;

        this.pCityOfBirth = new TTVisual.TTTextBox();
        this.pCityOfBirth.Name = "BirthPlace";
        this.pCityOfBirth.TabIndex = 17;

        this.pBusinessAddress = new TTVisual.TTTextBox();
        this.pBusinessAddress.Name = "pBusinessAddress";
        this.pBusinessAddress.TabIndex = 17;


        this.pImportantPatientInfo = new TTVisual.TTTextBox();
        this.pImportantPatientInfo.Name = "pImportantPatientInfo";
        this.pImportantPatientInfo.TabIndex = 17;

        this.pNationality = new TTVisual.TTObjectListBox();
        this.pNationality.ListDefName = "SKRSUlkeKodlariList";
        this.pNationality.Name = "Nationality";
        this.pNationality.TabIndex = 171;

        this.pOccupation = new TTVisual.TTObjectListBox();
        this.pOccupation.ListDefName = "SKRSMesleklerList";
        this.pOccupation.Name = "Occupation";
        this.pOccupation.TabIndex = 169;

        this.pBloodGroup = new TTVisual.TTObjectListBox();
        this.pBloodGroup.ListDefName = "SKRSKanGrubuList";
        this.pBloodGroup.Name = "BloodGroupType";
        this.pBloodGroup.TabIndex = 22;

        this.pSKRSMaritalStatus = new TTVisual.TTObjectListBox();
        this.pSKRSMaritalStatus.ListDefName = "SKRSMedeniHaliList";
        this.pSKRSMaritalStatus.Name = "SKRSMaritalStatus";
        this.pSKRSMaritalStatus.TabIndex = 170;

        this.pEducationStatus = new TTVisual.TTObjectListBox();
        this.pEducationStatus.ListDefName = "SKRSOgrenimDurumuList";
        this.pEducationStatus.Name = "EducationStatus";
        this.pEducationStatus.TabIndex = 170;

        this.pUnIdentified = new TTVisual.TTCheckBox();
        this.pUnIdentified.Value = false;
        this.pUnIdentified.Text = i18n("M17577", "Kimlik Bilinmiyor");
        this.pUnIdentified.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pUnIdentified.Name = "UnIdentified";

        this.pPrivacyName = new TTVisual.TTTextBox();
        this.pPrivacyName.Multiline = false;
        this.pPrivacyName.Name = "PrivacyName";
        this.pPrivacyName.ReadOnly = true;
        this.pPrivacyName.CharacterCasing = CharacterCasing.Upper;

        this.pPrivacySurname = new TTVisual.TTTextBox();
        this.pPrivacySurname.Multiline = false;
        this.pPrivacySurname.Name = "PrivacySurname";
        this.pPrivacySurname.ReadOnly = true;
        this.pPrivacySurname.CharacterCasing = CharacterCasing.Upper;

        this.pPrivacyReason = new TTVisual.TTTextBox();
        this.pPrivacyReason.Multiline = false;
        this.pPrivacyReason.Name = "PrivacyReason";
        this.pPrivacyReason.ReadOnly = true;

        this.pPrivacy = new TTVisual.TTCheckBox();
        this.pPrivacy.Value = false;
        this.pPrivacy.Text = i18n("M14814", "Gizli Hasta");
        this.pPrivacy.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pPrivacy.Name = "Privacy";

        this.pSKRSYabanciHasta = new TTVisual.TTObjectListBox();
        this.pSKRSYabanciHasta.ListDefName = "SKRSYabanciHastaTuruList";
        this.pSKRSYabanciHasta.Name = "SKRSYabanciHasta";
        this.pSKRSYabanciHasta.TabIndex = 22;

        this.pSKRSOzurlulukDurumu = new TTVisual.TTObjectListBox();
        this.pSKRSOzurlulukDurumu.ListDefName = "SKRSOzurlulukDurumuList";
        this.pSKRSOzurlulukDurumu.Name = "SKRSOzurlulukDurumu";


        this.controls = [this.pMotherName, this.pFatherName, this.pBirthDate, this.pPrivacyEndDate, this.pCityOfBirth, this.pBusinessPhone, this.pBusinessAddress, this.pImportantPatientInfo, this.pSex, this.pNationality, this.pName, this.pSurname, this.pUniqueRefNo, this.pPassportNo];

        this.PatientInfoUIComponents = [this.pMotherName, this.pFatherName, this.pBirthDate,this.pPrivacyEndDate, this.pCityOfBirth, this.pSex, this.pNationality, this.pName, this.pSurname, this.pUniqueRefNo,
        this.pPassportNo, this.pOtherBirthPlace, this.pSKRSMaritalStatus];

        this.PatientUIComponents = new Map<string, any>();
        this.PatientUIComponents.set("MotherName", this.pMotherName);

        this.loadpUIComponentsToMap();
    }
    private loadpUIComponentsToMap() {
        this.controls.forEach(element => {
            this.PatientUIComponents.set(element.Name.toString(), element);
        });
    }

    private updatepRequiredColors() {
        this.controls.forEach(element => {
            this.PatientUIComponents.set(element.Name.toString(), element
            );
            element.BackColor = "white";
        });
    }

    public makeRamdomID(length) {
        var result           = '';
        var characters       = 'ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghjklmnopqrstuvwxyz0123456789';//Ii sorun çıkarabilir
        var charactersLength = characters.length;
        for ( var i = 0; i < length; i++ ) {
           result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        return result;
     }


}
