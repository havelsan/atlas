import { TypeMetadata } from './TypeMetadata';
import { ExposeMetadata } from './ExposeMetadata';
import { ExcludeMetadata } from './ExcludeMetadata';
import { TransformationType } from '../TransformOperationExecutor';
import { TransformMetadata } from './TransformMetadata';
import { ClassTypeMetadata } from './ClassTypeMetadata';
import { EnumListTypeMetadata } from './EnumListTypeMetadata';
import { TypeOptions } from './ExposeExcludeOptions';
/**
 * Storage all library metadata.
 */
export class MetadataStorage {

    // -------------------------------------------------------------------------
    // Properties
    // -------------------------------------------------------------------------

    private _transformMetadatas: TransformMetadata[] = [];
    private _exposeMetadatas: ExposeMetadata[] = [];
    private _excludeMetadatas: ExcludeMetadata[] = [];
    private _classTypeMetadatas: Map<string, ClassTypeMetadata> = new Map<string, ClassTypeMetadata>();
    private _classTypeObjectDefIDMetadatas: Map<string, ClassTypeMetadata> = new Map<string, ClassTypeMetadata>();
    private _enumListTypeMetadatas: Map<string, EnumListTypeMetadata> = new Map<string, EnumListTypeMetadata>();
    private _typeMetadataCache: Map<string, TypeMetadata> = new Map<string, TypeMetadata>();

    // -------------------------------------------------------------------------
    // Adder Methods
    // -------------------------------------------------------------------------
    addEnumListTypeMetadata(metadata: EnumListTypeMetadata) {
        this._enumListTypeMetadatas.set(metadata.typeName, metadata);
    }

    addClassTypeMetadata(metadata: ClassTypeMetadata) {
        this._classTypeMetadatas.set(metadata.typeName, metadata);
        this._classTypeObjectDefIDMetadatas.set(metadata.objectDefID, metadata);
    }

    addTypeMetadata(metadata: TypeMetadata) {
        const key = `${metadata.target.prototype.constructor.name}~${metadata.propertyName}`;
        this._typeMetadataCache.set(key, metadata);
    }

    addTransformMetadata(metadata: TransformMetadata) {
        this._transformMetadatas.push(metadata);
    }

    addExposeMetadata(metadata: ExposeMetadata) {
        this._exposeMetadatas.push(metadata);
    }

    addExcludeMetadata(metadata: ExcludeMetadata) {
        this._excludeMetadatas.push(metadata);
    }

    // -------------------------------------------------------------------------
    // Public Methods
    // -------------------------------------------------------------------------

    getClassTypeMetadaWithObjectDefID(objectDefID: string): ClassTypeMetadata {
        return this._classTypeObjectDefIDMetadatas.get(objectDefID);
    }

    getClassTypeMetada(typeName: string): ClassTypeMetadata {
        return this._classTypeMetadatas.get(typeName);
    }

    getEnumListTypeMetada(typeName: string): EnumListTypeMetadata {
        return this._enumListTypeMetadatas.get(typeName);
    }

    findExcludeMetadata(target: Function, propertyName: string): ExcludeMetadata {
        return this.findMetadata(this._excludeMetadatas, target, propertyName);
    }

    findExposeMetadata(target: Function, propertyName: string): ExposeMetadata {
        return this.findMetadata(this._exposeMetadatas, target, propertyName);
    }

    findExposeMetadataByCustomName(target: Function, name: string): ExposeMetadata {
        return this._exposeMetadatas.find(metadata => {
            return metadata.target === target && metadata.options && metadata.options.name === name;
        });
    }

    findTypeMetadata(target: Function, propertyName: string) {
        let targetObj = target;
        while (targetObj.prototype) {
            const key = `${targetObj.prototype.constructor.name}~${propertyName}`;
            const metadataFromTarget = this._typeMetadataCache.get(key);
            if (metadataFromTarget) {
                return metadataFromTarget;
            }
            targetObj = Object.getPrototypeOf(targetObj);
        }
        return undefined;
    }

    getStrategy(target: Function): 'excludeAll' | 'exposeAll' | 'none' {
        const exclude = this._excludeMetadatas.find(metadata => metadata.target === target && metadata.propertyName === undefined);
        const expose = this._exposeMetadatas.find(metadata => metadata.target === target && metadata.propertyName === undefined);
        if ((exclude && expose) || (!exclude && !expose)) return 'none';
        return exclude ? 'excludeAll' : 'exposeAll';
    }

    getExposedMetadatas(target: Function): ExposeMetadata[] {
        return this.getMetadata(this._exposeMetadatas, target);
    }

    getExcludedMetadatas(target: Function): ExcludeMetadata[] {
        return this.getMetadata(this._excludeMetadatas, target);
    }

    getExposedProperties(target: Function, transformationType: TransformationType): string[] {
        return this.getExposedMetadatas(target)
            .filter(metadata => {
                if (!metadata.options)
                    return true;
                if (metadata.options.toClassOnly === true && metadata.options.toPlainOnly === true)
                    return true;

                if (metadata.options.toClassOnly === true) {
                    return transformationType === 'classToClass' || transformationType === 'plainToClass';
                }
                if (metadata.options.toPlainOnly === true) {
                    return transformationType === 'classToPlain';
                }

                return true;
            })
            .map(metadata => metadata.propertyName);
    }

    getExcludedProperties(target: Function, transformationType: TransformationType): string[] {
        return this.getExcludedMetadatas(target)
            .filter(metadata => {
                if (!metadata.options)
                    return true;
                if (metadata.options.toClassOnly === true && metadata.options.toPlainOnly === true)
                    return true;

                if (metadata.options.toClassOnly === true) {
                    return transformationType === 'classToClass' || transformationType === 'plainToClass';
                }
                if (metadata.options.toPlainOnly === true) {
                    return transformationType === 'classToPlain';
                }

                return true;
            })
            .map(metadata => metadata.propertyName);
    }

    clear() {
        this._exposeMetadatas = [];
        this._excludeMetadatas = [];
        this._classTypeMetadatas = new Map<string, ClassTypeMetadata>();
        this._typeMetadataCache = new Map<string, TypeMetadata>();
    }

    getTypeFunction(metadata: TypeMetadata, options: TypeOptions) {
        if (metadata.typeFunction != null)
            return metadata.typeFunction(options);
        if (metadata.targetTypeName != null) {
            const classTypemetadata = this.getClassTypeMetada(metadata.targetTypeName);
            if (classTypemetadata != null) {
                return classTypemetadata.target;
            }
        }
        return Object.prototype;
    }

    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    private getMetadata<T extends { target: Function, propertyName: string }>(metadatas: T[], target: Function): T[] {
        const metadataFromTarget = metadatas.filter(meta => meta.target === target && meta.propertyName !== undefined);
        const metadataFromChildren = metadatas.filter(meta => target.prototype instanceof meta.target && meta.propertyName !== undefined);
        return metadataFromChildren.concat(metadataFromTarget);
    }

    private findMetadata<T extends { target: Function, propertyName: string }>(metadatas: T[], target: Function, propertyName: string): T {
        const metadataFromTarget = metadatas.find(meta => meta.target === target && meta.propertyName === propertyName);
        const metadataFromChildren = metadatas.find(meta => target.prototype instanceof meta.target && meta.propertyName === propertyName);
        return metadataFromTarget || metadataFromChildren;
    }

}