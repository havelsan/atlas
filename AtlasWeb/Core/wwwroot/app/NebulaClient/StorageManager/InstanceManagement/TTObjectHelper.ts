
export const ObjectIDPropertyName = 'ObjectID';
export const ObjectDefIDPropertyName = 'ObjectDefID';

export class TTObjectHelper {

    public static isTTObjectFromProperty(source: any): boolean {
        if (!source) {
            return false;
        }
        let results = /function (.{1,})\(/.exec(source.constructor.__proto__.toString());
        if (results && results.length > 1) {
            if (results[1] == "TTObject") {
                return true;
            }
        }
        if (source.hasOwnProperty(ObjectIDPropertyName) && source.hasOwnProperty(ObjectDefIDPropertyName)) {
            return true;
        }
        return false;
    }

    public static isTTObject(source: any): boolean {
        if (!source) {
            return false;
        }
        const prototype = Object.getPrototypeOf(source);
        if (!prototype) {
            return false;
        }

        if (prototype.constructor.name === 'TTObject') {
            return true;
        }
        return TTObjectHelper.isTTObject(prototype);
    }

}