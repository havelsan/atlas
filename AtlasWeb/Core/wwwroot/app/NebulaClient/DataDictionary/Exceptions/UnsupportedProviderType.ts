import { DataDictionaryException } from "./DataDictionaryException";
import { DBProviderTypeEnum } from "../../Utils/Enums/DBProviderTypeEnum";
import { Exception } from "../../System/Exception";
/*[Serializable]*/
export class UnsupportedProviderType extends DataDictionaryException {
    constructor(providerType: DBProviderTypeEnum, innerException?: Exception) {
        let message: string = `Provider type '${providerType.toString()}' not supported.`;
        super(message);

    }
}