export class AtlasObjectCloner {

    public static clone(value: any): any {
        if (value === undefined) {
            return undefined;
        }
        const cloner = new AtlasObjectCloner();
        const rootObject = { '': value };
        let targetObject: any = Object.create(value.constructor.prototype);
        cloner.clone('', rootObject, targetObject);
        return targetObject[''];
    }

    private isPrimitiveType(value: any) {
        switch (typeof value) {
            case 'string':
            case 'number':
            case 'boolean':
                return true;
        }
        return false;
    }

    private setProperty(targetObject: any, key: any, value: any) {
        targetObject[key] = value;
    }

    public clone(key: any, sourceObject: any, targetObject: any) {
        const value = sourceObject[key];
        if (this.isPrimitiveType(value)) {
            this.setProperty(targetObject, key, value);
        } else if (value == null) {
            this.setProperty(targetObject, key, value);
        } else if (value instanceof Date) {
            targetObject[key] = value;
        } else if (Object.prototype.toString.apply(value) === '[object Array]') {
            const length = value.length;
            let targetArray: any = [];
            for (let index = 0; index < length; ++index) {
                this.clone(index, value, targetArray);
            }
            this.setProperty(targetObject, key, targetArray);
        } else {
            const keysArray = Object.keys(value);
            let innerObject: any = Object.create(value.constructor.prototype);
            for (let nextIndex = 0, len = keysArray.length; nextIndex < len; nextIndex++) {
                const nextKey = keysArray[nextIndex];
                this.clone(nextKey, value, innerObject);
            }
            this.setProperty(targetObject, key, innerObject);
        }
    }
}
