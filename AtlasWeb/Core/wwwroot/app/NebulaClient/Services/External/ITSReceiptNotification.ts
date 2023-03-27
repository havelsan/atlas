//$E8CFC1FD
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace ITSReceiptNotification {
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
    }

    export class WebMethods {
        public static async sendReceiptNotificationSync(siteID: Guid, ReceiptRequest: ItsPlainRequest): Promise<ItsResponse> {
            let url: string = "/api/ITSReceiptNotificationController/sendReceiptNotificationSync";
            let inputDto = { "siteID": siteID, "ReceiptRequest": ReceiptRequest };
            let result = await ServiceLocator.post(url, inputDto) as ItsResponse;
            return result;
        }
    }
}
