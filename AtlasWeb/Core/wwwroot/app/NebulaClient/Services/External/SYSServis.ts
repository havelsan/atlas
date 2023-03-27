//$B51D51C3
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace SYSServis {
    export class WebMethods {
        public static async SYSSendMessageSync(siteID: Guid, input: string): Promise<string> {
            let url: string = "/api/SYSServisController/SYSSendMessageSync";
            let inputDto = { "siteID": siteID, "input": input };
            let result = await ServiceLocator.post(url, inputDto) as string;
            return result;
        }
    }
}
