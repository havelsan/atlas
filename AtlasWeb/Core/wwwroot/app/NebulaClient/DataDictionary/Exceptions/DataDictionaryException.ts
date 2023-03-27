import { Exception } from "../../System/Exception";
/*[Serializable]*/
export class DataDictionaryException extends Exception {
    constructor(message: string, innerException?: Exception) {
        super(message, innerException);

    }
}