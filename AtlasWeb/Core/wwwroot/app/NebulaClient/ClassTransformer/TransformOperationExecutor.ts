import { ClassTransformOptions } from './ClassTransformOptions';
import { defaultMetadataStorage } from './storage';
import { TypeOptions } from './metadata/ExposeExcludeOptions';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTObjectHelper } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectHelper';

export type TransformationType = 'plainToClass' | 'classToPlain' | 'classToClass';

export class TransformOperationExecutor {

    // -------------------------------------------------------------------------
    // Private Properties
    // -------------------------------------------------------------------------

    private transformedTypes: { level: number, object: Object }[] = [];

    // -------------------------------------------------------------------------
    // Constructor
    // -------------------------------------------------------------------------

    constructor(private transformationType: TransformationType,
        private options: ClassTransformOptions) {
    }

    private findTTObjectType(targetValue: any) {
        if (targetValue) {
            if (targetValue.hasOwnProperty('ObjectID') && targetValue.hasOwnProperty('ObjectDefID')) {
                const objectDefID = targetValue['ObjectDefID'];
                if (objectDefID) {
                    const classTypeMetaData = defaultMetadataStorage.getClassTypeMetadaWithObjectDefID(objectDefID);
                    if (classTypeMetaData) {
                        return classTypeMetaData.target;
                    }
                }
            }
        }

        return undefined;
    }

    private parseISOLocal(s: any): Date {
        let b = s.split(/\D/);
        return new Date(b[0], b[1] - 1, b[2], b[3], b[4], b[5]);
    }

    // -------------------------------------------------------------------------
    // Public Methods
    // -------------------------------------------------------------------------

    transform(source: Object | Object[] | any,
        value: Object | Object[] | any,
        targetType: Function,
        arrayType: Function,
        isMap: boolean,
        level: number = 0) {

        let targetTypeCheck = <any>targetType;
        let valueCheck = <any>value;
        let isTypeDate = false;
        if (targetTypeCheck != null && (typeof targetTypeCheck.getMonth === 'function')) {
            isTypeDate = true;
        }
        let isValueDate = false;
        if (valueCheck != null && (typeof value.getMonth === 'function')) {
            isValueDate = true;
        }

        if (targetType == null || targetType.constructor.name === 'Object') {
            targetType = this.findTTObjectType(value);
        }
        if (value instanceof Array || value instanceof Set) {
            const newValue = arrayType && this.transformationType === 'plainToClass' ? new (arrayType as any)() : [];
            (value as any[]).forEach((subValue, index) => {
                const subSource = source ? source[index] : undefined;
                if (!this.isCircular(subValue, level)) {
                    const transformedValue = this.transform(subSource, subValue, targetType, undefined, subValue instanceof Map, level + 1);
                    if (newValue instanceof Set) {
                        newValue.add(transformedValue);
                    } else {
                        newValue.push(transformedValue);
                    }
                } else if (this.transformationType === 'classToClass') {
                    if (newValue instanceof Set) {
                        newValue.add(subValue);
                    } else {
                        newValue.push(subValue);
                    }
                }
            });
            return newValue;

        } else if (targetType === String && !isMap) {
            if (value === null || value === undefined) {
                return value;
            }
            return String(value);
        } else if (targetType === Number && !isMap) {
            if (value === null || value === undefined) {
                return value;
            }
            if (value && typeof value === 'string') {
                const floatString = value.replace(',', '.');
                return Number(parseFloat(floatString));
            }
            return Number(value);
        } else if (targetType === Boolean && !isMap) {
            if (value === null || value === undefined) {
                return value;
            }
            return Boolean(value);
        } else if (targetType === Date && !isMap) {
            let convertedDate = null;
            if ((typeof value) === 'string') {
                let dateParseResult = this.parseISOLocal(<any>value);
                return dateParseResult;
            }
            if (value != null) {
                convertedDate = new Date(value);
            }
            return convertedDate;
        } else if (targetType === Guid && !isMap) {
            if (value === null || value === undefined) {
                return value;
            }
            return new Guid(value);
        } else if ((isTypeDate || isValueDate) && !isMap) {
            if (isValueDate) {
                return new Date(value.valueOf());
            }
            if (value === null || value === undefined) {
                return value;
            }
            return new Date(value);
        } else if (value instanceof Object) {
            // try to guess the type
            if (!targetType && value.constructor !== Object/* && operationType === "classToPlain"*/) {
                targetType = value.constructor;
            }
            if (!targetType && source) {
                targetType = source.constructor;
            }

            if (this.transformationType === 'classToPlain') {
                if (value.constructor.name === 'Guid') {
                    return value['id'];
                }
            }

            // add transformed type to prevent circular references
            this.transformedTypes.push({ level: level, object: value });

            const keys = this.getKeys(targetType, value);
            let newValue: any = source ? source : {};
            if (!source && (this.transformationType === 'plainToClass' || this.transformationType === 'classToClass')) {
                if (isMap) {
                    newValue = new Map();
                } else if (targetType) {
                    newValue = new (targetType as any)();
                } else {
                    newValue = {};
                }
            }

            if (this.transformationType === 'plainToClass' && TTObjectHelper.isTTObject(newValue)) {
                const newOriginalValues: any = Object.create(Object.prototype);
                Object.assign(newOriginalValues, value, value.OriginalValues);
                delete newOriginalValues.OriginalValues;
                newValue.OriginalValues = newOriginalValues;
                newValue.ServerValues = value;
            }

            // traverse over keys
            for (let key of keys) {
                if (this.transformationType === 'plainToClass') {
                    if (key === 'OriginalValues') {
                        continue;
                    }
                }

                let valueKey = key, newValueKey = key, propertyName = key;
                if (!this.options.ignoreDecorators && targetType) {
                    if (this.transformationType === 'plainToClass') {
                        const exposeMetadata = defaultMetadataStorage.findExposeMetadataByCustomName(targetType, key);
                        if (exposeMetadata) {
                            propertyName = exposeMetadata.propertyName;
                            newValueKey = exposeMetadata.propertyName;
                        }

                    } else if (this.transformationType === 'classToPlain' || this.transformationType === 'classToClass') {
                        const exposeMetadata = defaultMetadataStorage.findExposeMetadata(targetType, key);
                        if (exposeMetadata && exposeMetadata.options && exposeMetadata.options.name) {
                            newValueKey = exposeMetadata.options.name;
                        }
                    }
                }

                // get a subvalue
                let subValue: any = undefined;
                if (value instanceof Map) {
                    subValue = value.get(valueKey);
                } else if (value[valueKey] instanceof Function) {
                    subValue = value[valueKey]();
                } else {
                    subValue = value[valueKey];
                }

                // determine a type
                let newType: any = undefined, isSubValueMap = subValue instanceof Map;
                if (targetType && isMap) {
                    newType = targetType;
                } else if (targetType) {
                    const metadata = defaultMetadataStorage.findTypeMetadata(targetType, propertyName);
                    if (metadata) {
                        const options: TypeOptions = { newObject: newValue, object: value, property: propertyName };
                        // newType = metadata.typeFunction(options);
                        newType = defaultMetadataStorage.getTypeFunction(metadata, options);
                        isSubValueMap = isSubValueMap || metadata.reflectedType === Map;
                    } else if (this.options.targetMaps) { // try to find a type in target maps
                        this.options.targetMaps
                            .filter(map => map.target === targetType && !!map.properties[propertyName])
                            .forEach(map => newType = map.properties[propertyName]);
                    } else {
                        newType = this.findTTObjectType(subValue);
                    }
                } else {
                    newType = this.findTTObjectType(subValue);
                }

                // if value is an array try to get its custom array type
                let  targetArrayType = value[valueKey] instanceof Array ? this.getReflectedType(targetType, propertyName) : undefined;
                if (value[valueKey] instanceof Array && Array.isArray(targetArrayType) === false) {
                    targetArrayType = () => [];
                }

                // const subValueKey = operationType === "plainToClass" && newKeyName ? newKeyName : key;
                const subSource = source ? source[valueKey] : undefined;

                // if its deserialization then type if required
                // if we uncomment this types like string[] will not work
                // if (this.transformationType === "plainToClass" && !type && subValue instanceof Object && !(subValue instanceof Date))
                //     throw new Error(`Cannot determine type for ${(targetType as any).name }.${propertyName}, did you forget to specify a @Type?`);

                // if newValue is a source object that has method that match newKeyName then skip it
                if (newValue.constructor.prototype) {
                    const descriptor = Object.getOwnPropertyDescriptor(newValue.constructor.prototype, newValueKey);
                    if ((this.transformationType === 'plainToClass' || this.transformationType === 'classToClass')
                        && (newValue[newValueKey] instanceof Function || (descriptor && !descriptor.set))) {
                        //  || operationType === "classToClass"
                        continue;
                    }
                }

                if (!this.isCircular(subValue, level)) {
                    let transformKey = this.transformationType === 'plainToClass' ? newValueKey : key;
                    let finalValue = this.transform(subSource, subValue, newType, targetArrayType, isSubValueMap, level + 1);
                    if (newValue instanceof Map) {
                        newValue.set(newValueKey, finalValue);
                    } else {
                        newValue[newValueKey] = finalValue;
                    }
                } else if (this.transformationType === 'classToClass') {
                    let finalValue = subValue;
                    if (newValue instanceof Map) {
                        newValue.set(newValueKey, finalValue);
                    } else {
                        newValue[newValueKey] = finalValue;
                    }
                }

            }
            return newValue;

        } else {
            return value;
        }
    }

    // preventing circular references
    private isCircular(object: Object, level: number) {
        return !!this.transformedTypes.find(transformed => transformed.object === object && transformed.level < level);
    }

    private getReflectedType(target: Function, propertyName: string) {
        if (!target) {
            return undefined;
        }
        const meta = defaultMetadataStorage.findTypeMetadata(target, propertyName);
        return meta ? meta.reflectedType : undefined;
    }

    private getKeys(target: Function, object: Object): string[] {

        // determine exclusion strategy
        let strategy = defaultMetadataStorage.getStrategy(target);
        if (strategy === 'none') {
            strategy = this.options.strategy || 'exposeAll'; // exposeAll is default strategy
        }

        // get all keys that need to expose
        let keys: any[] = [];
        if (strategy === 'exposeAll') {
            if (object instanceof Map) {
                keys = Array.from(object.keys());
            } else {
                keys = Object.keys(object);
            }
        }

        if (!this.options.ignoreDecorators && target) {

            // exclude excluded properties
            const excludedProperties = defaultMetadataStorage.getExcludedProperties(target, this.transformationType);
            if (excludedProperties.length > 0) {
                keys = keys.filter(key => {
                    return excludedProperties.indexOf(key) === -1;
                });
            }

            // add all exposed to list of keys
            let exposedProperties = defaultMetadataStorage.getExposedProperties(target, this.transformationType);
            if (this.transformationType === 'plainToClass') {
                exposedProperties = exposedProperties.map(key => {
                    const exposeMetadata = defaultMetadataStorage.findExposeMetadata(target, key);
                    if (exposeMetadata && exposeMetadata.options && exposeMetadata.options.name) {
                        return exposeMetadata.options.name;
                    }

                    return key;
                });
            }
            keys = keys.concat(exposedProperties);

            // apply versioning options
            if (this.options.version !== undefined) {
                keys = keys.filter(key => {
                    const exposeMetadata = defaultMetadataStorage.findExposeMetadata(target, key);
                    if (!exposeMetadata || !exposeMetadata.options) {
                        return true;
                    }

                    return this.checkVersion(exposeMetadata.options.since, exposeMetadata.options.until);
                });
            }

            // apply grouping options
            if (this.options.groups && this.options.groups.length) {
                keys = keys.filter(key => {
                    const exposeMetadata = defaultMetadataStorage.findExposeMetadata(target, key);
                    if (!exposeMetadata || !exposeMetadata.options) {
                        return true;
                    }

                    return this.checkGroups(exposeMetadata.options.groups);
                });
            } else {
                keys = keys.filter(key => {
                    const exposeMetadata = defaultMetadataStorage.findExposeMetadata(target, key);
                    return !exposeMetadata ||
                        !exposeMetadata.options ||
                        !exposeMetadata.options.groups ||
                        !exposeMetadata.options.groups.length;
                });
            }
        }

        // exclude prefixed properties
        if (this.options.excludePrefixes && this.options.excludePrefixes.length) {
            keys = keys.filter(key => this.options.excludePrefixes.every(prefix => {
                return key.substr(0, prefix.length) !== prefix;
            }));
        }

        // make sure we have unique keys
        keys = keys.filter((key, index, self) => {
            return self.indexOf(key) === index;
        });

        return keys;
    }

    private checkVersion(since: number, until: number) {
        let decision = true;
        if (decision && since) {
            decision = this.options.version >= since;
        }
        if (decision && until) {
            decision = this.options.version < until;
        }

        return decision;
    }

    private checkGroups(groups: string[]) {
        if (!groups) {
            return true;
        }

        return this.options.groups.some(optionGroup => groups.indexOf(optionGroup) !== -1);
    }

}