import { defaultMetadataStorage } from './storage';
import { TypeMetadata } from './metadata/TypeMetadata';
import { ExposeMetadata } from './metadata/ExposeMetadata';
import { ExposeOptions, ExcludeOptions, TypeOptions, TransformOptions } from './metadata/ExposeExcludeOptions';
import { ExcludeMetadata } from './metadata/ExcludeMetadata';
import { TransformMetadata } from './metadata/TransformMetadata';
import { ClassTypeMetadata } from './metadata/ClassTypeMetadata';
import { EnumListTypeMetadata } from './metadata/EnumListTypeMetadata';

/**
 * Defines a custom logic for value transformation.
 */
export function Transform(transformFn: (value: any) => any, options?: TransformOptions) {
    return function (target: any, key: string) {
        const metadata = new TransformMetadata(target.constructor, key, transformFn, options);
        defaultMetadataStorage.addTransformMetadata(metadata);
    };
}

/**
 * Specifies a type of the property.
 */
export function Type(typeFunction?: ((type?: TypeOptions) => Function) | string) {
    return function (target: any, key: string) {
        const type = (Reflect as any).getMetadata('design:type', target, key);
        const targetTypeFunction: any = (typeof typeFunction) === 'string' ? null : typeFunction;
        const targetTypeName: string = (typeof typeFunction) === 'string' ? <string><any>typeFunction : null;
        const metadata = new TypeMetadata(target.constructor, key, type, targetTypeFunction, targetTypeName);
        defaultMetadataStorage.addTypeMetadata(metadata);
    };
}

/**
 * Marks property as included in the process of transformation. By default it includes the property for both
 * constructorToPlain and plainToConstructor transformations, however you can specify on which of transformation types
 * you want to skip this property.
 */
export function Expose(options?: ExposeOptions) {
    return function (object: Object | Function, propertyName?: string) {
        const metadata = new ExposeMetadata(object instanceof Function ? object : object.constructor, propertyName, options || {});
        defaultMetadataStorage.addExposeMetadata(metadata);
    };
}

/**
 * Marks property as excluded from the process of transformation. By default it excludes the property for both
 * constructorToPlain and plainToConstructor transformations, however you can specify on which of transformation types
 * you want to skip this property.
 */
export function Exclude(options?: ExcludeOptions) {
    return function (object: Object | Function, propertyName?: string) {
        const metadata = new ExcludeMetadata(object instanceof Function ? object : object.constructor, propertyName, options || {});
        defaultMetadataStorage.addExcludeMetadata(metadata);
    };
}

export function ClassType(objectDefID?: string) {
    return function (target: any) {
        const metadata = new ClassTypeMetadata(target, target.name, objectDefID);
        defaultMetadataStorage.addClassTypeMetadata(metadata);
        return target;
    };
}

export function EnumListType(enumType: string) {
    return function (target: any) {
        const metadata = new EnumListTypeMetadata(target, enumType);
        defaultMetadataStorage.addEnumListTypeMetadata(metadata);
        return target;
    };
}
