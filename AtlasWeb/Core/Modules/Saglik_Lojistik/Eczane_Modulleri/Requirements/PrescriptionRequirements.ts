//$7F76CE1D
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { IRequirements } from "Fw/Requirements/IRequirements";
import { DrugOrderIntroductionDet, PrescriptionTypeEnum, DrugOrderIntroduction, Material } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { OrderRequirementsVariables } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Requirements/OrderRequirementsVariables";


export class PatientStateModel {

    public isInpatient: boolean;
    public isOutpatient: boolean;
    public IsPragnant: boolean;
    constructor() {

    }
}

export class DrugPrescriptionModel {
    public PrescriptionType: PrescriptionTypeEnum;
    public PatientSafetyFrom: boolean;
    public Material: Material;
    public StockInheld: number;
    public IsPatientOwnDrug: boolean;
    public PatientOwnDrugAmount: number;
    public ReqAmount: number;

    constructor() {

    }
}

export class DrugOrderIntroductionRequirements implements IRequirements {

    public DrugOrderIntroduction: DrugOrderIntroduction;
    public DrugPrescriptionModel: DrugPrescriptionModel;
    public PatientStateModel: PatientStateModel;
    public newDrugOrderIntroductionDet: DrugOrderIntroductionDet;

    constructor(DrugOrderIntroduction: DrugOrderIntroduction, DrugPrescriptionModel: DrugPrescriptionModel, PatientStateModel: PatientStateModel, newDrugOrderIntroductionDet: DrugOrderIntroductionDet) {
        this.DrugOrderIntroduction = DrugOrderIntroduction;
        this.DrugPrescriptionModel = DrugPrescriptionModel;
        this.PatientStateModel = PatientStateModel;
        this.newDrugOrderIntroductionDet = newDrugOrderIntroductionDet;

    }

    async ExecuteRequirementsWithApproval(): Promise<RequirementResultCode> {
        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";

        if (this.PatientStateModel.isInpatient && this.DrugPrescriptionModel.StockInheld < this.DrugPrescriptionModel.ReqAmount) {//?
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20924", "Reçete"),
                i18n("M24475", "Yazdığınız ilacın Eczanede yeterli mevcudu bulunmamaktadır. Bu nedenle Yatan Hasta Reçetesine çıkacaktır.<br />") + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
            if (result === 'V') {
                requirementResultCode.resultMessage = "Yazdığınız ilacın Eczanede yeterli mevcudu bulunmamaktadır.";
                requirementResultCode.resultCode = OrderRequirementsVariables.NOT_ENOUGH_AMOUNT_AT_PHARMACY;
                return requirementResultCode;
            }
        }

        requirementResultCode.IsSuccess = true;
        return requirementResultCode;
    }

    public ExecuteRequirements() {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";
        let UIComponent = null;

        if (this.DrugOrderIntroduction == null) {
            requirementResultCode.resultCode = OrderRequirementsVariables.DRUG_ORDER_INTRODUCTION_IS_NULL;
            requirementResultCode.resultMessage = i18n("M22203", "DrugOrderIntroduction == null!");
            return requirementResultCode;
        }

        if (this.DrugPrescriptionModel.PatientSafetyFrom) {
            if (String.isNullOrEmpty(this.DrugOrderIntroduction.DrugDescription)) {
                requirementResultCode.resultMessage = this.DrugPrescriptionModel.Material.Name + i18n("M16281", " ilacı için Hasta Güvenlik ve İzleme Formu seri numarası girmelisiniz. \r\n");
                requirementResultCode.resultCode = OrderRequirementsVariables.PATIENT_SAFETY_FORM_REQUIRED;
                return requirementResultCode;
            }
        }

        if (this.DrugPrescriptionModel.PrescriptionType === PrescriptionTypeEnum.GreenPrescription && this.PatientStateModel.isOutpatient === true) {
            requirementResultCode.resultMessage = i18n("M24640", " Yeşil Reçete için Renkli Reçete Uygulamasını kullanmalısınız. \r\n");
            requirementResultCode.resultCode = OrderRequirementsVariables.USE_PRESCRIPTION_FOR_GREEN;
        }

        if (this.DrugPrescriptionModel.PrescriptionType === PrescriptionTypeEnum.RedPrescription && this.PatientStateModel.isOutpatient === true) {
            requirementResultCode.resultMessage = i18n("M17524", " Kırmızı Reçete için Renkli Reçete Uygulamasını kullanmalısınız. \r\n");
            requirementResultCode.resultCode = OrderRequirementsVariables.USE_PRESCRIPTION_FOR_RED;
            return requirementResultCode;
        }

        if (this.PatientStateModel.isInpatient == true && this.DrugPrescriptionModel.StockInheld < 1) {
            if (this.DrugPrescriptionModel.PrescriptionType === PrescriptionTypeEnum.RedPrescription && this.DrugOrderIntroduction.PatientOwnDrug === false) {
                requirementResultCode.resultMessage = i18n("M17524", " Kırmızı Reçete için Renkli Reçete Uygulamasını kullanmalısınız. \r\n");
                requirementResultCode.resultCode = OrderRequirementsVariables.USE_PRESCRIPTION_FOR_RED;
                return requirementResultCode;
            }
            if (this.DrugPrescriptionModel.PrescriptionType === PrescriptionTypeEnum.GreenPrescription && this.DrugOrderIntroduction.PatientOwnDrug === false) {
                requirementResultCode.resultMessage = i18n("M24640", " Yeşil Reçete için Renkli Reçete Uygulamasını kullanmalısınız. \r\n");
                requirementResultCode.resultCode = OrderRequirementsVariables.USE_PRESCRIPTION_FOR_GREEN;
                return requirementResultCode;
            }
        }

        if (this.PatientStateModel.isInpatient == true && this.newDrugOrderIntroductionDet.Day > 5) {
            requirementResultCode.resultCode = OrderRequirementsVariables.CAN_NOT_OVER_5_DAYS;
            requirementResultCode.resultMessage = i18n("M20966", "Reçete yazılırken İlaç 5 günden fazla yazılamaz.");
            return requirementResultCode;
        }

        if (this.DrugPrescriptionModel.IsPatientOwnDrug === true) {
            if (this.DrugPrescriptionModel.PatientOwnDrugAmount < this.DrugPrescriptionModel.ReqAmount) {
                requirementResultCode.resultCode = OrderRequirementsVariables.NOT_ENOUGH_AMOUNT_AT_PATIENTOWNDRUG;
                requirementResultCode.resultMessage = i18n("M12081", "Bu ilacı Hasta Yanında Getirdi olarak yazamazsınız. ") +
                    i18n("M15463", "Hastanın kalan miktarı:") + this.DrugPrescriptionModel.PatientOwnDrugAmount.toString() + i18n("M19740", " Order Toplam Miktarı: ") + this.DrugPrescriptionModel.ReqAmount.toString();
                return requirementResultCode;
            }
        }

        requirementResultCode.IsSuccess = true;
        return requirementResultCode;
    }

}
