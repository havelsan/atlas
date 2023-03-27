import { RequirementResultCode } from "./RequirementResultCode";
import { IRequirements } from "./IRequirements";

export class RequirementExecutor{

    requirementList: Array<IRequirements> = new Array<IRequirements>();

    public addRequirement(requirement: IRequirements): void
    {
        this.requirementList.push(requirement);
    }

    public clearAllRequirements(): void {
        this.requirementList.Clear();
    }

    public Execute(): RequirementResultCode {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        for (let requirement of this.requirementList)
        {
            let requirementResultCodeTemp: RequirementResultCode = requirement.ExecuteRequirements();
            if (requirementResultCodeTemp.resultCode != 0) {
                  requirementResultCode = requirementResultCodeTemp;
            }
        }
        return requirementResultCode;
    }

    public async ExecuteWithApproval(): Promise<RequirementResultCode> {

        let requirementResultCode: RequirementResultCode = new RequirementResultCode();
        for (let requirement of this.requirementList)
        {
            let requirementResultCodeTemp: RequirementResultCode = await requirement.ExecuteRequirementsWithApproval();
            if (requirementResultCodeTemp.resultCode != 0) {
                  requirementResultCode = requirementResultCodeTemp;
            }
        }
        return requirementResultCode;
    }
}
