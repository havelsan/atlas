//$90DCFB62
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { IRequirements } from "Fw/Requirements/IRequirements";
import { PatientAdmissionFormViewModel } from "../PatientAdmissionFormViewModel";

export class PatientAddressRequirements implements IRequirements {

    public PA_Address: PatientAdmissionFormViewModel;

    public requiredColor: string = "#f3d7d7";
    public PatientAddressUIElements: Map<string, any>;

    constructor(patientAddressParam: PatientAdmissionFormViewModel, controls: Map<string, any>) {
        this.PA_Address = patientAddressParam;
        this.PatientAddressUIElements = controls;
    }
    ExecuteRequirementsWithApproval(): Promise<RequirementResultCode> {
        throw new Error("Method not implemented.");
    }
    public ExecuteRequirements(): RequirementResultCode {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";

        let UIComponent = null;

        if (this.PA_Address == null) {
            requirementResultCode.resultCode = 1;
            requirementResultCode.resultMessage = i18n("M15139", "Hasta adresi tanımlı değildir.");
            return requirementResultCode;
        }

        if (this.PA_Address.tempHomeAddress == null || this.PA_Address.tempHomeAddress == "") {
            requirementResultCode.resultCode = 1;
            requirementResultCode.resultMessage = i18n("M13974", "Ev adresi alanı boş bırakılamaz.");
            UIComponent = this.PatientAddressUIElements.get("HomeAddress");
            if (UIComponent != null)
                UIComponent.BackColor = this.requiredColor;
        }

        if (this.PA_Address.tempMobilePhone == null || this.PA_Address.tempMobilePhone.replace(/\s/g, "") == "") {
            requirementResultCode.resultCode = 1;
            requirementResultCode.resultMessage = i18n("M12199", "Cep telefonu alanı boş bırakılamaz.");
            UIComponent = this.PatientAddressUIElements.get("MobilePhone");
            if (UIComponent != null)
                UIComponent.BackColor = this.requiredColor;
        }
        else if (this.PA_Address.tempMobilePhone.replace(/\s/g, "").length < 10) {
            requirementResultCode.resultCode = 1;
            requirementResultCode.resultMessage = i18n("M12199", "Cep telefonu alanı uzaunluğu 10 karakter olmalıdır.");
            UIComponent = this.PatientAddressUIElements.get("MobilePhone");
            if (UIComponent != null)
                UIComponent.BackColor = this.requiredColor;
        }

        return requirementResultCode;
    }

}
