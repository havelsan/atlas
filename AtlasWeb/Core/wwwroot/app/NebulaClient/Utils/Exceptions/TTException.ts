import { Exception } from "../../System/Exception";
/*[Serializable]*/
export class TTException extends Exception {
    constructor(message: string, innerException?: Exception) {
        super(message, innerException);
    }
}