//$6C2E983F
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export namespace PTSPackageReceiverServis {
    export class receiveFileParametersType {
        public sourceGLN: string;
        public transferId: number;
    }

    export class WebMethods {
        public static async receiveFileStream(siteID: Guid, receiveFilePT: receiveFileParametersType): Promise<ArrayBuffer> {
            let url: string = "/api/PTSPackageReceiverServisController/receiveFileStream";
            let inputDto = { "siteID": siteID, "receiveFilePT": receiveFilePT };
            let result = await ServiceLocator.post(url, inputDto) as ArrayBuffer;
            return result;
        }
    }
}
