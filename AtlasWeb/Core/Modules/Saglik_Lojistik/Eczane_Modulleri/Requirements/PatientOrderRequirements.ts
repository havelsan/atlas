//$7F76CE1D
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { IRequirements } from "Fw/Requirements/IRequirements";
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { OrderRequirementsVariables } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Requirements/OrderRequirementsVariables";

export class PatientOrderReqModel {

    public Age: number;
    public IsFamale: boolean;
    public IsMale: boolean;
    public IsPragnant: boolean;
    public PatientObjectID: string;
    constructor() {

    }

}
export class DrugReqModel {

    public MaxAge: number;
    public MinAge: number;
    public IsPragnantCanNotBeUse: boolean;
    public ForOnlyMale: boolean;
    public ForOnlyFamale: boolean;
    public Material: Material;
    constructor() {

    }

}
export class PatientOrderRequirements implements IRequirements {


    public patient: PatientOrderReqModel;
    public drug: DrugReqModel;

    constructor(private http: NeHttpService, patientParam: PatientOrderReqModel, drugModel: DrugReqModel) {
        this.patient = patientParam;
        this.drug = drugModel;
    }

    async ExecuteRequirementsWithApproval(): Promise<RequirementResultCode> {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";

        if (this.patient.Age > this.drug.MaxAge || this.patient.Age < this.drug.MinAge) {

            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20924", "Reçete"),
                i18n("M24475", "Yazdığınız ilaç hastanın yaş aralığı için uygun değildir. Hastanız " +
                    this.patient.Age + " yaşında, ilaç için tavsiye edilen yaş aralığı (" + this.drug.MinAge + ")-(" + this.drug.MaxAge + ") <br />") +
                i18n("M12687", "Devam Etmek İstiyor Musunuz?"));

            if (result === 'V') {
                requirementResultCode.resultCode = OrderRequirementsVariables.MAX_MIN_AGE_CRITERIA;
                requirementResultCode.resultMessage = i18n("M22203", "Hastanın yaş aralığı ilaç için uygun değildir. Uygun yaş aralığı "
                    + this.drug.MinAge + " - " + this.drug.MaxAge);
                return requirementResultCode;
            }
        }

        let url = '/api/DrugOrderIntroductionService/ControlOfDrugSpecificationNewDrugIntroduction?drugObjectID=' + this.drug.Material.ObjectID + '&patientObjectID=' + this.patient.PatientObjectID;
        let message = await this.http.get<string>(url);
        if (!String.isNullOrEmpty(message)) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Özellikli İlaç', message + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
            if (result === 'V') {
                requirementResultCode.resultCode = OrderRequirementsVariables.SPECIFICATION_DRUG;
                requirementResultCode.resultMessage = i18n("M21923", "Özellikli İlaç!");
                return requirementResultCode;
            }
        }

        requirementResultCode.IsSuccess = true;


        return requirementResultCode;
    }
    public ExecuteRequirements(): RequirementResultCode {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";
        let UIComponent = null;

        if (this.patient == null) {
            requirementResultCode.resultCode = OrderRequirementsVariables.PLANNED_START_TIME_NOT_NULL;
            requirementResultCode.resultMessage = i18n("M21923", "Sistemde hasta tanımlı değildir!");
            return requirementResultCode;
        }

        if (this.patient.IsFamale && this.drug.ForOnlyMale) {
            requirementResultCode.resultCode = OrderRequirementsVariables.DRUG_FOR_ONLY_MALE;
            requirementResultCode.resultMessage = i18n("M22203", "Kadın hasta için kullanılamaz!");
            return requirementResultCode;
        }

        if (this.patient.IsMale && this.drug.ForOnlyFamale) {
            requirementResultCode.resultCode = OrderRequirementsVariables.DRUG_FOR_ONLY_FAMALE;
            requirementResultCode.resultMessage = i18n("M22203", "Erkek hasta için kullanılamaz!");
            return requirementResultCode;
        }

        if (this.patient.IsPragnant && this.drug.IsPragnantCanNotBeUse) {
            requirementResultCode.resultCode = OrderRequirementsVariables.PRAGNANT_CAN_NOT_USE;
            requirementResultCode.resultMessage = i18n("M22203", "Gebelik Durumunda olan hasta için kullanılamaz!");
            return requirementResultCode;
        }


        requirementResultCode.IsSuccess = true;
        return requirementResultCode;
    }

}
