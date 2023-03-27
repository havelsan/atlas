import { DataDictionaryException } from "./DataDictionaryException";
import { Exception } from "../../System/Exception";
/*[Serializable]*/
export class IncompatibleValueException extends DataDictionaryException {

    constructor(dataTypeName: string, value?: Object, innerException?: Exception) {
        let calcValue = (value === null ? "" : value.toString());
        let message: string = `Type of the value '${calcValue}' is not compatible with data type '${dataTypeName}'.`;
        super(message, innerException);

    }
}