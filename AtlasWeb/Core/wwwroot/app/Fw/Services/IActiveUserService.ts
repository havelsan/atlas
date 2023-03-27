import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { EventEmitter } from '@angular/core';
export abstract class IActiveUserService {
    ActiveUserID: Guid;
    ActiveUser: TTUser;
    SelectedOutPatientResource: ResSection;
    SelectedInPatientResource: ResSection;
    SelectedSecMasterResource: ResSection;
    SelectedQueue: any;
    isPoolQueue: boolean;
    SelectedUserStore: Store;
    abstract clearState(): void;
    abstract onStoreChangeEvent : EventEmitter<any>;
}