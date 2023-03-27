
export class AtlasObjectSynchronizer {

    public static guidRegex = /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;

    public static sync(value: any, state: any): any {
        if (value === undefined) {
            return undefined;
        }
        const cloner = new AtlasObjectSynchronizer();
        const rootObject = { '': value };
        const stateObject = { '': state };
        let targetObject: any = Object.create(value.constructor.prototype);
        cloner.sync('', rootObject, targetObject, stateObject);
        return targetObject[''];
    }

    private toHashMap(array: Array<string>): any {
        let hashMap: any = {};
        array.forEach(item => hashMap[item] = item);
        return hashMap;
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

    private setProperty(targetObject: any, key: any, value: any, valueState: any) {
        targetObject[key] = value;
    }

    public sync(key: any, sourceObject: any, targetObject: any, stateObject: any) {
        const valueSource = sourceObject[key];
        let valueState = undefined;
        let value = valueSource;
        if (stateObject.hasOwnProperty(key)) {
            valueState = stateObject[key];
            if (valueState) {
                if (AtlasObjectSynchronizer.guidRegex.test(valueState) && value.hasOwnProperty('ObjectID')) {
                    value = valueState;
                }
            }
        }
        if (this.isPrimitiveType(value)) {
            this.setProperty(targetObject, key, value, valueState);
        } else if (value == null) {
            this.setProperty(targetObject, key, value, valueState);
        } else if (value instanceof Date) {
            targetObject[key] = value;
        } else if (Object.prototype.toString.apply(value) === '[object Array]') {
            const length = value.length;
            let targetArray: any = [];
            for (let index = 0; index < length; ++index) {
                this.sync(index, value, targetArray, valueState);
            }
            this.setProperty(targetObject, key, targetArray, valueState);
        } else {
            const keysArray = Object.keys(value);
            const stateKeysArray = valueState === undefined ? [] : Object.keys(valueState);
            const stateKeysMap = this.toHashMap(stateKeysArray);
            let innerObject: any = Object.create(value.constructor.prototype);
            for (let nextIndex = 0, len = keysArray.length; nextIndex < len; nextIndex++) {
                const nextKey = keysArray[nextIndex];
                if (stateKeysMap.hasOwnProperty(nextKey) === true) {
                    this.sync(nextKey, value, innerObject, valueState);
                }
            }
            this.setProperty(targetObject, key, innerObject, valueState);
        }
    }
}

