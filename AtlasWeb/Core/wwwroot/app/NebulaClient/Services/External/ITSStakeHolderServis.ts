//$EAD1E7E7
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace ITSStakeHolderServis {
    export class stakeholderRequest {
        constructor() {
            this.getAll = false;
        }

        public stakeholderType: string;
        public getAll: boolean;
        public cityPlate: string;
    }


    export class company {
        public gln: string;
        public companyName: string;
        public authorized: string;
        public email: string;
        public phone: string;
        public city: string;
        public town: string;
        public address: string;
        public isActive: boolean;
    }

    export class stakeholderResponse {
        public companies: Array<company>;
    }

    export class WebMethods {
        public static async CallStakeholder(siteID: Guid, stakeholderRq: ITSStakeHolderServis.stakeholderRequest): Promise<ITSStakeHolderServis.stakeholderResponse> {
            let url: string = "/api/ITSStakeHolderServisController/CallStakeholder";
            let inputDto = { "siteID": siteID, "stakeholderRq": stakeholderRq };
            let result = await ServiceLocator.post(url, inputDto) as ITSStakeHolderServis.stakeholderResponse;
            return result;
        }
    }
}
