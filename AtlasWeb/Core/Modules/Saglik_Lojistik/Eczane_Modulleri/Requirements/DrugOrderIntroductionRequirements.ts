//$7F76CE1D
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { IRequirements } from "Fw/Requirements/IRequirements";
import { DrugOrderIntroductionDet, DrugOrderIntroduction } from 'NebulaClient/Model/AtlasClientModel';
import { OrderRequirementsVariables } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Requirements/OrderRequirementsVariables";


export class DrugOrderIntroductionRequirements implements IRequirements {





    public DrugOrderIntroductionDetails: Array<DrugOrderIntroductionDet>;
    public newDrugOrderIntroductionDet: DrugOrderIntroductionDet;
    public DrugOrderIntroduction: DrugOrderIntroduction;

    constructor(DrugOrderIntroduction: DrugOrderIntroduction, DrugOrderIntroductionDetails: Array<DrugOrderIntroductionDet>, newDrugOrderIntroductionDet: DrugOrderIntroductionDet) {

        this.DrugOrderIntroductionDetails = DrugOrderIntroductionDetails;
        this.newDrugOrderIntroductionDet = newDrugOrderIntroductionDet;

    }
    async ExecuteRequirementsWithApproval(): Promise<RequirementResultCode> {
        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";
        requirementResultCode.IsSuccess = true;


        return requirementResultCode;
    }

    IsExistingDrugOrderValidate(): boolean {

        let isExist: boolean = false;

        this.DrugOrderIntroductionDetails.forEach(element => {
            let elementMaterialObjectID: string = element.Material.ObjectID.toString();
            if (elementMaterialObjectID == this.newDrugOrderIntroductionDet.Material.ObjectID.toString())
                isExist = true;
        });

        return isExist;
    }
    public ExecuteRequirements(): RequirementResultCode {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";
        let UIComponent = null;
        if (this.DrugOrderIntroduction.DrugUsageType == null) {
            requirementResultCode.resultCode = OrderRequirementsVariables.DRUG_USAGE_TYPE_NOT_NULL;
            requirementResultCode.resultMessage = i18n("M22203", "Kullanım Şekli Seçimi Yapınız!");
            return requirementResultCode;
        }
        if (this.DrugOrderIntroduction.OrderDay == null) {
            requirementResultCode.resultMessage = i18n("M12870", "Direktif günü boş olamaz. <br />");
            requirementResultCode.resultCode = OrderRequirementsVariables.ORDER_DAY_NOT_NULL;
        }
        if (this.DrugOrderIntroduction.PlannedStartTime == null) {
            requirementResultCode.resultMessage = i18n("M23753", "Uygulama Başlangıç Zamanı boş olamaz. <br />");
            requirementResultCode.resultCode = OrderRequirementsVariables.PLANNED_START_TIME_NOT_NULL;
        }
        if (this.DrugOrderIntroduction.OrderDose == null) {
            requirementResultCode.resultMessage = i18n("M12868", "Direktif dozu boş olamaz. <br />");
            requirementResultCode.resultCode = OrderRequirementsVariables.ORDER_DOSE_NOT_NULL;
        }
        if (this.DrugOrderIntroduction.OrderFrequency == null) {
            requirementResultCode.resultMessage = i18n("M12867", "Direktif doz aralığı boş olamaz. <br />");
            requirementResultCode.resultCode = OrderRequirementsVariables.ORDER_FREQUENCY_VALIDATE;
        }

        if (this.newDrugOrderIntroductionDet == null) {
            requirementResultCode.resultCode = OrderRequirementsVariables.ORDER_MATERIAL_NOT_NULL;
            requirementResultCode.resultMessage = i18n("M22203", "Öncelikle İlaç Seçimi Yapınız!");
            return requirementResultCode;
        }

        if (this.newDrugOrderIntroductionDet.Material == null) {
            requirementResultCode.resultCode = OrderRequirementsVariables.ORDER_MATERIAL_NOT_NULL;
            requirementResultCode.resultMessage = i18n("M22203", "Öncelikle İlaç Seçimi Yapınız!");
            return requirementResultCode;
        }

        if (this.DrugOrderIntroductionDetails != null && this.DrugOrderIntroductionDetails.length > 0) {
            if (this.IsExistingDrugOrderValidate()) {
                requirementResultCode.resultCode = OrderRequirementsVariables.ORDER_MATERIAL_NOT_NULL;
                requirementResultCode.resultMessage = i18n("M22203", "Bu İlaç Seçimi Daha Önce Yapılmış!");
                return requirementResultCode;
            }
        }

        requirementResultCode.IsSuccess = true;
        return requirementResultCode;
    }

}
