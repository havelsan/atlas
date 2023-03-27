import { RequirementResultCode } from "./RequirementResultCode";

export interface IRequirements {

    ExecuteRequirements(): RequirementResultCode;
    ExecuteRequirementsWithApproval(): Promise<RequirementResultCode>;
}
