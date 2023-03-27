//$7F76CE1D
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { IRequirements } from "Fw/Requirements/IRequirements";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';

export class PatientInfoRequirements implements IRequirements {


    public patient: Patient;
    public PatientInfoUIElements: Map<string, any>;
    public requiredColor: string = "#f3d7d7";
    public normalColor: string = "white";
    public name: String;
    public surname: String;
    constructor(patientParam: Patient, nameParam: String, surnameParam: String, controls: Map<string, any>) {
        this.patient = patientParam;
        this.name = nameParam;
        this.surname =  surnameParam;
        this.PatientInfoUIElements = controls;
    }

    ExecuteRequirementsWithApproval(): Promise<RequirementResultCode> {
        throw new Error("Method not implemented.");
    }
    public ExecuteRequirements(): RequirementResultCode {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";
        let UIComponent = null;

        if (this.patient == null) {
            requirementResultCode.resultCode = 1;
            requirementResultCode.resultMessage = i18n("M21923", "Sistemde hasta tanımlı değildir.");
            return requirementResultCode;
        }

        if (this.patient.UnIdentified == false) {

            if (this.patient.MotherName == null || this.patient.MotherName == "") {
                requirementResultCode.resultCode = 4;
                requirementResultCode.resultMessage = i18n("M11038", "Anne adı alanı boş bırakılamaz.");
                UIComponent = this.PatientInfoUIElements.get("MotherName");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }

            if (this.patient.FatherName == null || this.patient.FatherName == "") {
                requirementResultCode.resultCode = 5;
                requirementResultCode.resultMessage = i18n("M11392", "Baba adı alanı boş bırakılamaz.");
                UIComponent = this.PatientInfoUIElements.get("FatherName");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }

            if (this.patient.BirthDate == null) {
                requirementResultCode.resultCode = 6;
                requirementResultCode.resultMessage = i18n("M13134", "Doğum tarihi alanı boş bırakılamaz.");
                UIComponent = this.PatientInfoUIElements.get("BirthDate");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }


            if (this.patient.BirthPlace == null && this.patient.Nationality != null && this.patient.Nationality.Kodu  == "TR" ) {
                requirementResultCode.resultCode = 7;
                requirementResultCode.resultMessage = i18n("M13143", "Doğum yeri alanı boş bırakılamaz.");
                UIComponent = this.PatientInfoUIElements.get("CityOfBirth");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }

            if (this.patient.OtherBirthPlace == null && ( this.patient.Nationality == null || this.patient.Nationality.Kodu != "TR")) {
                requirementResultCode.resultCode = 7;
                requirementResultCode.resultMessage = i18n("M13143", "Doğum yeri alanı boş bırakılamaz.");
                UIComponent = this.PatientInfoUIElements.get("OtherBirthPlace");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }

            if (this.patient.Sex == null || this.patient.Sex.ADI == null) {
                requirementResultCode.resultCode = 8;
                requirementResultCode.resultMessage = i18n("M12268", "Cinsiyet alanı boş bırakılamaz.");
                UIComponent = this.PatientInfoUIElements.get("Sex");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }

            if (this.patient.Nationality == null) {
                requirementResultCode.resultCode = 9;
                requirementResultCode.resultMessage = i18n("M23816", "Uyruk alanı boş bırakılamaz.");
                UIComponent = this.PatientInfoUIElements.get("Nationality");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }

            if(this.patient.UniqueRefNo != null && this.patient.UniqueRefNo.toString().startsWith("99") && this.patient.Nationality.Kodu == "TR"){
                requirementResultCode.resultCode = 10;
                requirementResultCode.resultMessage = ("Kimlik numarası 99 ile başlayan hastalar için uyruk 'Türkiye Cumhuriyeti' Seçilemez. ");
                UIComponent = this.PatientInfoUIElements.get("Nationality");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }
        }
        else if (this.patient.UnIdentified == true)
        {
            if (this.patient.ImportantPatientInfo == null) {
                requirementResultCode.resultCode = 11;
                requirementResultCode.resultMessage = i18n("M23816", "Lütfen Hasta Detay Bilgileri Tabındaki 'Arşiv Açıklaması' alanını doldurunuz.");
                UIComponent = this.PatientInfoUIElements.get("ImportantPatientInfo");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }
        }

        if (this.name == null) {
            requirementResultCode.resultCode = 2;
            requirementResultCode.resultMessage = i18n("M10497", "Ad alanı boş bırakılamaz.");
            UIComponent = this.PatientInfoUIElements.get("Name");
            if (UIComponent != null)
                UIComponent.BackColor = this.requiredColor;

        }

        if (this.surname == null) {
            requirementResultCode.resultCode = 3;
            requirementResultCode.resultMessage = i18n("M22203", "Soyad alanı boş bırakılamaz.");

            UIComponent = this.PatientInfoUIElements.get("Surname");
            if (UIComponent != null)
                UIComponent.BackColor = this.requiredColor;
        }

        return requirementResultCode;

    }

}
