import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { UserResource } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { TentativeStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { UnitStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';


export class UserHelper {

    private static async loadCurrentResource(): Promise<ResUser> {
        let url: string = "/api/UserHelper/CurrentResource";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<ResUser>(url, ResUser);
        return result as ResUser;
    }

    private static _currentResource: Promise<ResUser>;
    public static get CurrentResource(): Promise<ResUser> {
        if (this._currentResource == null) {
            this._currentResource = this.loadCurrentResource();
        }
        return this._currentResource;
    }

    private static async loadSelectedInPatientResource(): Promise<ResSection> {
        let url: string = "/api/UserHelper/SelectedInPatientResource";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<ResSection>(url, ResSection);
        return result as ResSection;
    }

    private static _selectedInPatientResource: Promise<ResSection>;
    public static get SelectedInPatientResource(): Promise<ResSection> {
        if (this._selectedInPatientResource == null) {
            this._selectedInPatientResource = this.loadSelectedInPatientResource();
        }
        return this._selectedInPatientResource;
    }

    private static async loadSelectedOutPatientResource(): Promise<ResSection> {
        let url: string = "/api/UserHelper/SelectedOutPatientResource";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<ResSection>(url, ResSection);
        return result as ResSection;
    }

    private static _selectedOutPatientResource: Promise<ResSection>;
    public static get SelectedOutPatientResource(): Promise<ResSection> {
        if (this._selectedOutPatientResource == null) {
            this._selectedOutPatientResource = this.loadSelectedOutPatientResource();
        }
        return this._selectedOutPatientResource;
    }

    private static async loadSelectedSecMasterResource(): Promise<ResSection> {
        let url: string = "/api/UserHelper/SelectedSecMasterResource";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<ResSection>(url, ResSection);
        return result as ResSection;
    }

    private static _selectedSecMasterResource: Promise<ResSection>;
    public static get SelectedSecMasterResource(): Promise<ResSection> {
        if (this._selectedSecMasterResource == null) {
            this._selectedSecMasterResource = this.loadSelectedSecMasterResource();
        }
        return this._selectedSecMasterResource;
    }

    private static async loadStore(): Promise<Store> {
        let url: string = "/api/UserHelper/Store";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<Store>(url, Store);
        return result as Store;
    }

    private static _store: Promise<Store>;
    public static get Store(): Promise<Store> {
        if (this._store == null) {
            this._store = this.loadStore();
        }
        return this._store;
    }
    private static async loadUserResources(): Promise<Array<UserResource>> {
        let url: string = "/api/UserHelper/UserResources";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<UserResource>(url, UserResource);
        return <any>result as Array<UserResource>;
    }

    private static _userResources: Promise<Array<UserResource>>;
    public static get UserResources(): Promise<Array<UserResource>> {
        if (this._userResources == null) {
            this._userResources = this.loadUserResources();
        }
        return this._userResources;
    }

    public static async loadUseTentativeStoreResources(): Promise<Array<TentativeStoreDefinition>> {
        let url: string = "/api/UserHelper/UseTentativeStoreResources";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, TentativeStoreDefinition);
        return <any>result as Array<TentativeStoreDefinition>;
    }

    private static _useTentativeStoreResources: Promise<Array<TentativeStoreDefinition>>;
    public static get UseTentativeStoreResources(): Promise<Array<TentativeStoreDefinition>> {
        if (this._useTentativeStoreResources == null) {
            this._useTentativeStoreResources = this.loadUseTentativeStoreResources();
        }
        return this._useTentativeStoreResources;
    }

    public static async loadUseMainStoreResources(): Promise<Array<MainStoreDefinition>> {
        let url: string = "/api/UserHelper/UseMainStoreResources";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, MainStoreDefinition);
        return <any>result as Array<MainStoreDefinition>;
    }

    private static _useMainStoreResources: Promise<Array<MainStoreDefinition>>;
    public static get UseMainStoreResources(): Promise<Array<MainStoreDefinition>> {
        if (this._useMainStoreResources == null) {
            this._useMainStoreResources = this.loadUseMainStoreResources();
        }
        return this._useMainStoreResources;
    }

    public static async loadUseUserResourcesStores(): Promise<Array<Store>> {
        let url: string = "/api/UserHelper/UseUserResourcesStores";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<Store>;
    }

    private static _useUserResourcesStores: Promise<Array<Store>>;
    public static get UseUserResourcesStores(): Promise<Array<Store>> {
        if (this._useUserResourcesStores == null) {
            this._useUserResourcesStores = this.loadUseUserResourcesStores();
        }
        return this._useUserResourcesStores;
    }

    private static _useFirstUserResourcesStores: Promise<Array<Store>>;
    public static get UseFirstUserResourcesStores(): Promise<Array<Store>> {
        this._useUserResourcesStores = this.loadUseUserResourcesStores();
        return this._useUserResourcesStores;
    }

    public static async loadUseInPatientUserResourceStores(): Promise<Array<Store>> {
        let url: string = "/api/UserHelper/UseInPatientUserResourceStores";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<Store>;
    }

    private static _useInPatientUserResourceStores: Promise<Array<Store>>;
    public static get UseInPatientUserResourceStores(): Promise<Array<Store>> {
        if (this._useInPatientUserResourceStores == null) {
            this._useInPatientUserResourceStores = this.loadUseInPatientUserResourceStores();
        }
        return this._useInPatientUserResourceStores;
    }

    public static async loadUseOutPatientUserResourceStores(): Promise<Array<Store>> {
        let url: string = "/api/UserHelper/UseOutPatientUserResourceStores";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<Store>;
    }

    private static _useOutPatientUserResourceStores: Promise<Array<Store>>;
    public static get UseOutPatientUserResourceStores(): Promise<Array<Store>> {
        if (this._useOutPatientUserResourceStores == null) {
            this._useOutPatientUserResourceStores = this.loadUseOutPatientUserResourceStores();
        }
        return this._useOutPatientUserResourceStores;
    }

    public static async loadUseSecMasterUserResourceStores(): Promise<Array<Store>> {
        let url: string = "/api/UserHelper/UseSecMasterUserResourceStores";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<Store>;
    }

    private static _useSecMasterUserResourceStores: Promise<Array<Store>>;
    public static get UseSecMasterUserResourceStores(): Promise<Array<Store>> {
        if (this._useSecMasterUserResourceStores == null) {
            this._useSecMasterUserResourceStores = this.loadUseSecMasterUserResourceStores();
        }
        return this._useSecMasterUserResourceStores;
    }

    public static async loadSelectedInPatientResourceStore(): Promise<Store> {
        let url: string = "/api/UserHelper/SelectedInPatientResourceStore";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return result as Store;
    }

    private static _selectedInPatientResourceStore: Promise<Store>;
    public static get SelectedInPatientResourceStore(): Promise<Store> {
        if (this._selectedInPatientResourceStore == null) {
            this._selectedInPatientResourceStore = this.loadSelectedInPatientResourceStore();
        }
        return this._selectedInPatientResourceStore;
    }

    public static async loadSelectedOutPatientResourceStore(): Promise<Store> {
        let url: string = "/api/UserHelper/SelectedOutPatientResourceStore";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return result as Store;
    }

    private static _selectedOutPatientResourceStore: Promise<Store>;
    public static get SelectedOutPatientResourceStore(): Promise<Store> {
        if (this._selectedOutPatientResourceStore == null) {
            this._selectedOutPatientResourceStore = this.loadSelectedOutPatientResourceStore();
        }
        return this._selectedOutPatientResourceStore;
    }

    public static async loadSelectedSecMasterResourceStore(): Promise<Store> {
        let url: string = "/api/UserHelper/SelectedSecMasterResourceStore";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get<Store>(url, Store);
        return result as Store;
    }

    private static _selectedSecMasterResourceStore: Promise<Store>;
    public static get SelectedSecMasterResourceStore(): Promise<Store> {
        if (this._selectedSecMasterResourceStore == null) {
            this._selectedSecMasterResourceStore = this.loadSelectedSecMasterResourceStore();
        }
        return this._selectedSecMasterResourceStore;
    }

    public static async loadUseRoomStores(): Promise<Array<Store>> {
        let url: string = "/api/UserHelper/UseRoomStores";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<Store>;
    }

    private static _useRoomStores: Promise<Array<Store>>;
    public static get UseRoomStores(): Promise<Array<Store>> {
        if (this._useRoomStores == null) {
            this._useRoomStores = this.loadUseRoomStores();
        }
        return this._useRoomStores;
    }

    public static async loadUseRoomStoreParentSubStore(): Promise<Array<Store>> {
        let url: string = "/api/UserHelper/UseRoomStoreParentSubStore";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<Store>;
    }

    private static _useRoomStoreParentSubStore: Promise<Array<Store>>;
    public static get UseRoomStoreParentSubStore(): Promise<Array<Store>> {
        if (this._useRoomStoreParentSubStore == null) {
            this._useRoomStoreParentSubStore = this.loadUseRoomStoreParentSubStore();
        }
        return this._useRoomStoreParentSubStore;
    }

    public static async loadUseUnitStoreResources(): Promise<Array<UnitStoreDefinition>> {
        let url: string = "/api/UserHelper/UseUnitStoreResources";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<UnitStoreDefinition>;
    }

    private static _useUnitStoreResources: Promise<Array<UnitStoreDefinition>>;
    public static get UseUnitStoreResources(): Promise<Array<UnitStoreDefinition>> {
        if (this._useUnitStoreResources == null) {
            this._useUnitStoreResources = this.loadUseUnitStoreResources();
        }
        return this._useUnitStoreResources;
    }

    public static async loadUserUsableStores(): Promise<Array<Store>> {
        let url: string = "/api/UserHelper/UserUsableStores";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<Store>;
    }

    private static _userUsableStores: Promise<Array<Store>>;
    public static get UserUsableStores(): Promise<Array<Store>> {
        if (this._userUsableStores == null) {
            this._userUsableStores = this.loadUserUsableStores();
        }
        return this._userUsableStores;
    }

    public static async loadUserUsableSubStores(): Promise<Array<Store>> {
        let url: string = "/api/UserHelper/UserUsableSubStores";
        let httpService = ServiceLocator.NeHttpService;
        let result = await httpService.get(url, Store);
        return <any>result as Array<Store>;
    }

    private static _userUsableSubStores: Promise<Array<Store>>;
    public static get UserUsableSubStores(): Promise<Array<Store>> {
        if (this._userUsableSubStores == null) {
            this._userUsableSubStores = this.loadUserUsableSubStores();
        }
        return this._userUsableSubStores;
    }

}