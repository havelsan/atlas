import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { OpenCloseEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Type, Exclude, Expose, classToPlainFromExist } from 'NebulaClient/ClassTransformer';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export namespace SerializeTest {

    export class DateTimeTestInput {
        @Type(() => Date)
        public dateValue: Date;
    }

    export class DateSerializationSampleDto extends DateTimeTestInput {
        public Name: string;
        @Type(() => Number)
        public ID: number;
        @Type(() => Date)
        public BirthDate: Date;
    }

    export class ResourceBasic {
        public Qref: string;
        public Name: string;
        public ID: number;
        public Name_Shadow: string;

        public toString = (): string => {
            return `${this.ID}-${this.Name}`;
        }
    }

    export class TTObject {
        @Type(() => Guid)
        public ObjectID: Guid;

        @Type(() => Guid)
        public ObjectDefID: Guid;

        protected getType(): string {
            return 'TTStorageManager.TTObject, TTStorageManager';
        }

        toJSON() {
            let obj: any = {};
            obj['$type'] = this.getType();
            let resultObj = classToPlainFromExist(this, obj);
            return resultObj;
        }
    }

    export class ResourceDerived extends TTObject {
        public Qref: string;
        public Name: string;
        public ID: number;
        public Name_Shadow: string;

        protected getType(): string {
            return 'TTObjectClasses.Resource, TTObjectClasses';
        }

        public toString = (): string => {
            return `${this.ID}-${this.Name}`;
        }
    }

    export class Store extends TTObject {

        public static ObjectDefName: string = 'Store';
        public Name: string;
        public Description: string;
        public ID: number;
        public Status: OpenCloseEnum;
        public QREF: string;
        public Name_Shadow: string;
        public AutoReturningDocumentCreat: boolean;
        public MkysStore: boolean;

        protected getType(): string {
            return 'TTObjectClasses.Store, TTObjectClasses';
        }

    }

    export class ResourceWithExpose extends TTObject {
        public Qref: string;
        public Name: string;
        public ID: number;
        public Name_Shadow: string;

        @Type(() => Store)
        @Expose({ name: 'Store' })
        public _store: Store | string;

        public set StoreObject(value: Store | string) {
            this._store = value;
        }
        public get StoreObject(): Store | string {
            return this._store;
        }
        protected getType(): string {
            return 'TTObjectClasses.Resource, TTObjectClasses';
        }
    }

    export class SpecialityDefinition extends TTObject {
        public Name: string;
        public Code: string;
        public ExternalCode: number;
        public Name_Shadow: string;
        public IsToBeConsultation: boolean;
        public IsMHRSClinic: boolean;
        public IsMinorSpeciality: boolean;
    }

    export class ResourceSpecialityGrid extends TTObject {
        public static ObjectDefName: string = 'ResourceSpecialityGrid';
        public static ObjectDefID: Guid = new Guid('8ab1a766-42c3-4710-844f-cc6ce3b66b73');
        public MainSpeciality: boolean;
        public SpecialityDefinition: SpecialityDefinition;
    }

    export class Resource extends TTObject {

        public static ObjectDefName: string = 'Resource';
        public static ObjectDefID: Guid = new Guid('55df754b-9d32-4df9-a983-4d18b38bf044');

        @Exclude()
        private _storePromise: Promise<Store>;
        @Exclude()
        private _resourceSpecialitiesPromise: Promise<Array<ResourceSpecialityGrid>>;

        @Type(() => Store)
        @Expose({ name: 'Store' })
        public _store: Store;

        @Type(() => ResourceSpecialityGrid)
        @Expose({ name: 'ResourceSpecialities' })
        public _resourceSpecialities: Array<ResourceSpecialityGrid>;

        public Qref: string;
        public Name: string;
        public ID: number;
        public Name_Shadow: string;

        @Exclude()
        public get Store(): Store {
            if (this._store === undefined) {
                throw new Exception('Please call loadStore() method first.');
            }
            return this._store;
        }

        public set Store(value: Store) {
            this._store = value;
        }

        @Exclude()
        public loadStore(): Promise<Store> {
            if (this._storePromise != null) {
                return this._storePromise;
            }
            let that = this;
            if (this._store != null || (typeof this._store === 'string')) {
                this._storePromise = new Promise<Store>((resolve, reject) => {
                    let objectID: string = (<any>that._store) as string;
                    ServiceLocator.getObjectWithDefName<Store>(new Guid(objectID), Store.ObjectDefName).then(res => {
                        let store = res as Store;
                        that._store = store;
                        resolve(store);
                    })
                        .catch(err => {
                            reject(err);
                        });
                });
                return this._storePromise;
            }
            return Promise.resolve(this._store);
        }

        @Exclude()
        public get ResourceSpecialities(): Array<ResourceSpecialityGrid> {
            if (this._resourceSpecialities === undefined) {
                throw new Exception('Please call loadResourceSpecialities() method first.');
            }
            return this._resourceSpecialities;
        }
        public set ResourceSpecialities(value: Array<ResourceSpecialityGrid>) {
            this._resourceSpecialities = value;
        }

        @Exclude()
        public loadResourceSpecialities(): Promise<Array<ResourceSpecialityGrid>> {
            if (this._resourceSpecialitiesPromise != null) {
                return this._resourceSpecialitiesPromise;
            }
            let that = this;
            if (this.ObjectID != null && (this.ObjectID instanceof Guid) || (typeof this.ObjectID === 'string')) {
                this._resourceSpecialitiesPromise = new Promise<Array<ResourceSpecialityGrid>>((resolve, reject) => {
                    let objectID: Guid = this.ObjectID;
                    if (typeof this.ObjectID === 'string') {
                        objectID = new Guid(this.ObjectID as string);
                    }
                    ServiceLocator.getObjectChildren<Array<ResourceSpecialityGrid>>(this.ObjectID
                        , new Guid('55df754b-9d32-4df9-a983-4d18b38bf044')
                        , new Guid('108acc10-8f55-4596-a0ab-7f15ead4d447')).then(res => {
                            let resourceSpecialities = res as Array<ResourceSpecialityGrid>;
                            that._resourceSpecialities = resourceSpecialities;
                            resolve(resourceSpecialities);
                        })
                        .catch(err => {
                            reject(err);
                        });
                });
                return this._resourceSpecialitiesPromise;
            }
            return Promise.resolve(this._resourceSpecialities);
        }

        @Exclude()
        public toString = (): string => {
            return `${this.ID}-${this.Name}`;
        }

        @Exclude()
        protected getType(): string {
            return 'TTObjectClasses.Resource, TTObjectClasses';
        }
    }
}