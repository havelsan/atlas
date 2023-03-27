//$019E63F2
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace ITSCheckStatusNotification {
    export class ItsPlainRequest {
        public PRODUCTS: Array<ItsPlainRequestPRODUCT>;
    }

    export class ItsPlainRequestPRODUCT {
        public GTIN: string;
        public BN: string;
        public SN: string;
        public XD: Date;
    }

    export class ItsResponse {
        public NOTIFICATIONID: string;
        public PRODUCTS: Array<ItsResponsePRODUCT>;
    }

    export class ItsResponsePRODUCT {
        public GTIN: string;
        public SN: string;
        public UC: string;
        public GLN1: string;
        public GLN2: string;
    }

    export class WebMethods {
        public static async sendCheckStatusNotificationSync(siteID: Guid, QueryRequest: ItsPlainRequest): Promise<ItsResponse> {
            let url: string = "/api/ITSCheckStatusNotificationController/sendCheckStatusNotificationSync";
            let inputDto = { "siteID": siteID, "QueryRequest": QueryRequest };
            let result = await ServiceLocator.post(url, inputDto) as ItsResponse;
            return result;
        }
    }
}
