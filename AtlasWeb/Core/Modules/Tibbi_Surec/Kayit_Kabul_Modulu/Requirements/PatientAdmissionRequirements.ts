//$26DD4E2F
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { IRequirements } from "Fw/Requirements/IRequirements";
import { PatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { PatientAdmissionFormViewModel } from "../PatientAdmissionFormViewModel";


export class PatientAdmissionRequirements implements IRequirements {

    public patientAdmission: PatientAdmission;
    public patientAdmissionViewModel: PatientAdmissionFormViewModel;
    public requiredColor: string = "#f3d7d7";
    public PatientAdmissionUIElements: Map<string, any>;
    public UniqueRefNo: number;
    constructor(patientAdmissionParam: PatientAdmission, patientAdmissionViewModelParam: PatientAdmissionFormViewModel, UniqueRefNoPram: number, controls: Map<string, any>) {
        this.patientAdmission = patientAdmissionParam;
        this.patientAdmissionViewModel = patientAdmissionViewModelParam;
        this.UniqueRefNo = UniqueRefNoPram;
        this.PatientAdmissionUIElements = controls;

    }

    ExecuteRequirementsWithApproval(): Promise<RequirementResultCode> {
        throw new Error("Method not implemented.");
    }

    public ExecuteRequirements(): RequirementResultCode {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";

        let UIComponent = null;

        if (this.patientAdmission == null || this.patientAdmissionViewModel == null) {
            requirementResultCode.resultCode = 1;
            requirementResultCode.resultMessage = i18n("M17397", "Kayıt için gerekli alanları doldurunuz.");
            return requirementResultCode;

        }

        if (this.patientAdmission.Episode.Patient.UnIdentified == true && this.patientAdmission.IsNewBorn == true) {
            requirementResultCode.resultMessage = "Bir hasta için hem 'yenidoğan' hem 'Kimliği Belirsiz' seçilemez.";
            requirementResultCode.resultCode = 1;
        }

        if (this.patientAdmission.Episode.Patient.UnIdentified == false && this.patientAdmission.IsNewBorn == false && this.patientAdmission.Episode.Patient.Death == false && (this.patientAdmissionViewModel.HCRequestReasons == null || this.patientAdmissionViewModel.HCRequestReasons.length == 0)) {

            //if (this.patientAdmission.Payer == null) {
            //    requirementResultCode.resultCode = 1;
            //    requirementResultCode.resultMessage = i18n("M18012", "Kurum alanı boş bırakılamaz.");
            //    UIComponent = this.PatientAdmissionUIElements.get("PayerList");
            //    if (UIComponent != null)
            //        UIComponent.BackColor = this.requiredColor;
            //}

            if (this.patientAdmission.Episode.Patient.Privacy != true) {
                if (this.UniqueRefNo == null && this.patientAdmission.Episode.Patient.Nationality.Kodu == "TR" && this.patientAdmission.Episode.Patient.PassportNo != null) {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = i18n("M22937", "TC Kimlik No alanı boş bırakılamaz.");
                    UIComponent = this.PatientAdmissionUIElements.get("UniqueRefNo");
                    if (UIComponent != null)
                        UIComponent.BackColor = this.requiredColor;
                }
                if (this.patientAdmission.Episode.Patient.PassportNo == null && this.patientAdmission.Episode.Patient.Nationality.Kodu != "TR" && this.patientAdmission.Episode.Patient.ForeignUniqueRefNo == null) {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = i18n("M20215", "Pasaport No alanı boş bırakılamaz.");
                    UIComponent = this.PatientAdmissionUIElements.get("PassportNo");
                    if (UIComponent != null)
                        UIComponent.BackColor = this.requiredColor;
                }
            }
        }

        if (this.patientAdmission.AdmissionType == null) {
            requirementResultCode.resultCode = 1;
            requirementResultCode.resultMessage = i18n("M14665", "Geliş sebebi alanı boş bırakılamaz.");
            UIComponent = this.PatientAdmissionUIElements.get("AdmissionType");
            if (UIComponent != null)
                UIComponent.BackColor = this.requiredColor;
        }
        else {

            if (this.patientAdmission.Episode.Patient.UnIdentified == false && this.patientAdmission.IsNewBorn == false && this.patientAdmission.Episode.Patient.Death == false) {
                if (this.patientAdmission.MedulaSigortaliTuru == null) {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = i18n("M12324", "Çalışma durumu alanı boş bırakılamaz.");
                    UIComponent = this.PatientAdmissionUIElements.get("SigortaliTuru");
                    if (UIComponent != null)
                        UIComponent.BackColor = this.requiredColor;
                }
            }
            if (this.patientAdmission.AdmissionType.provizyonTipiKodu == 'T' && this.patientAdmissionViewModel.SubEpisodeProtocol.MedulaPlakaNo == null) {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = i18n("M14669", "Geliş sebebi 'Trafik Kazası' olan kabullerin Plaka No alanı boş bırakılamaz.");
                UIComponent = this.PatientAdmissionUIElements.get("plakaNo");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }
            if (this.patientAdmission.AdmissionType.provizyonTipiKodu == 'K' && this.patientAdmissionViewModel.KurumSevkTalepNoZorla 
                && (this.patientAdmissionViewModel.KurumSevkTalepNo == null || this.patientAdmissionViewModel.KurumSevkTalepNo.trim() == "") ) {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = i18n("M14669", "Geliş sebebi 'Kurum Sevki' olan kabullerin Sevk Talep No alanı boş bırakılamaz.");
                // UIComponent = this.PatientAdmissionUIElements.get("plakaNo");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }            
            else if (this.patientAdmission.AdmissionType.provizyonTipiKodu == 'S' && this.patientAdmission.MedulaIstisnaiHal == null) {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = i18n("M14666", "Geliş sebebi 'İstisnai Hal' olan kabullerin İstisnai Hal alanı boş bırakılamaz.");
                UIComponent = this.PatientAdmissionUIElements.get("MedulaIstisnaiHalComboBox");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }
        }

        if (this.patientAdmission.EmergencyIntervention != null) {
            if (this.patientAdmission.Sevkli112 == true && this.patientAdmission.Emergency112RefNo == null) {
                requirementResultCode.resultMessage = i18n("M10133", "112 Sağlık Hizmetleri ile getirilen hastaların 112 Protokol numaraları dolu olmalıdır.");
                requirementResultCode.resultCode = 1;
                UIComponent = this.PatientAdmissionUIElements.get("Emergency112RefNoTextbox");
                if (UIComponent != null)
                    UIComponent.BackColor = this.requiredColor;
            }
        }

        if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport != null && this.patientAdmissionViewModel.activeTab == 3) {
            if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.ApplicationReason == null) {
                requirementResultCode.resultMessage = "Engelli Kurul Kabullerine Müraacaat Nedeni Seçilmeden Devam Edilemez!";
                requirementResultCode.resultCode = 1;
            } else {
                if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.ApplicationReason == 0) {
                    if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.ApplicationType == null) {
                        requirementResultCode.resultMessage = "Engelli Kurul Kabullerine Müraacaat Şekli Seçilmeden Devam Edilemez!";
                        requirementResultCode.resultCode = 1;
                        
                    }
                    if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.ApplicationType == 1) {
                        if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.PersonalApplicationType == null) {
                            requirementResultCode.resultMessage = "Engelli Kurul Kabullerine Müraacaat Türü Seçilmeden Devam Edilemez!";
                            requirementResultCode.resultCode = 1;
                        }
                    } else if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.ApplicationType == 0) {
                        if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.CorporateApplicationType == null) {
                            requirementResultCode.resultMessage = "Engelli Kurul Kabullerine Müraacaat Türü Seçilmeden Devam Edilemez!";
                            requirementResultCode.resultCode = 1;
                        }
                    }
                } else if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.ApplicationReason == 1) {
                    if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.TerrorAccidentInjuryAppType == null) {
                        requirementResultCode.resultMessage = "Engelli Kurul Kabullerine Müraacaat Şekli Seçilmeden Devam Edilemez!";
                        requirementResultCode.resultCode = 1;
                    }
                    if (this.patientAdmissionViewModel._PatientAdmission.EDisabledReport.TerrorAccidentInjuryAppReason == null) {
                        requirementResultCode.resultMessage = "Engelli Kurul Kabullerine Kaza Yaralanma Nedeni Seçilmeden Devam Edilemez!";
                        requirementResultCode.resultCode = 1;
                    }
                }
            }
        }

        return requirementResultCode;
    }

}
