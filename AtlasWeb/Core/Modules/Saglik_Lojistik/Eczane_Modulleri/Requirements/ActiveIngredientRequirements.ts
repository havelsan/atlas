//$7F76CE1D
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { IRequirements } from "Fw/Requirements/IRequirements";
import { DrugOrderIntroductionDet, DrugOrderIntroduction } from 'NebulaClient/Model/AtlasClientModel';
import { ControlOfActiveIngredient_Output } from "app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService";
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { OrderRequirementsVariables } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Requirements/OrderRequirementsVariables";


export class DrugOrderIntroductionRequirements implements IRequirements {

    public DrugOrderIntroductionDetails: Array<DrugOrderIntroductionDet>;
    public newDrugOrderIntroductionDet: DrugOrderIntroductionDet;
    public DrugOrderIntroduction: DrugOrderIntroduction;
    public ControlOfActiveIngredient: Array<ControlOfActiveIngredient_Output>;

    constructor(DrugOrderIntroduction: DrugOrderIntroduction, DrugOrderIntroductionDetails: Array<DrugOrderIntroductionDet>, newDrugOrderIntroductionDet: DrugOrderIntroductionDet, ControlOfActiveIngredient_Output: Array<ControlOfActiveIngredient_Output>) {

        this.DrugOrderIntroductionDetails = DrugOrderIntroductionDetails;
        this.newDrugOrderIntroductionDet = newDrugOrderIntroductionDet;
        this.ControlOfActiveIngredient = ControlOfActiveIngredient_Output;
        this.DrugOrderIntroduction = DrugOrderIntroduction;

    }


    public async ExecuteRequirementsWithApproval(): Promise<RequirementResultCode> {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        requirementResultCode.resultCode = 0;
        requirementResultCode.resultMessage = "Success";

        for (let activeDrugIngredient of this.ControlOfActiveIngredient) {

            let message: string = activeDrugIngredient.activeIngredient + " etken maddeli " + activeDrugIngredient.drug + " isimli ilaç bugun içerisinde istenmiştir.";
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Etken Madde Etkileşimi',
                message + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));

            if (result === 'V') {
                requirementResultCode.resultMessage = "Etken Madde Kontrolü Sonrası Vazgeçildi";
                requirementResultCode.resultCode = OrderRequirementsVariables.ACTIVE_INGREDIENT_REQ;
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


        requirementResultCode.IsSuccess = true;
        return requirementResultCode;
    }

}
