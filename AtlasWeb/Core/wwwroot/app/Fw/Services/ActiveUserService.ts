import { Injectable, EventEmitter } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { IActiveUserService } from './IActiveUserService';
import { deserialize } from 'NebulaClient/ClassTransformer';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
@Injectable()
export class ActiveUserService implements IActiveUserService {
    private _activeUser: TTUser;
    private _selectedOutPatientResource: ResSection;
    private _selectedInPatientResource: ResSection;
    private _selectedSecMasterResource: ResSection;
    private _selectedQueue: ExaminationQueueDefinition;
    private _selectedUserStore: Store;
    private _isPoolQueue: boolean;

    public onStoreChangeEvent: EventEmitter<any> = new EventEmitter<any>();

    public clearState(): void {
        this._activeUser = undefined;
        this._selectedInPatientResource = undefined;
        this._selectedOutPatientResource = undefined;
        this._selectedSecMasterResource = undefined;
        this._selectedSecMasterResource = undefined;
        this._selectedQueue = undefined;
        this._selectedUserStore = undefined;
        this._isPoolQueue = undefined;
    }

    public get ActiveUserID(): Guid {
        return this.ActiveUser.UserObject.ObjectID;
    }

    public get ActiveUser(): TTUser {

        if (this._activeUser == null) {
            let activeUserString = window.sessionStorage.getItem('ActiveUser');
            let ttUser = deserialize(TTUser, activeUserString);
            this._activeUser = ttUser as TTUser;
        }

        return this._activeUser;
    }

    public set ActiveUser(value: TTUser) {
        this._activeUser = value;
    }

    public get SelectedQueue(): ExaminationQueueDefinition {

        return this._selectedQueue;
    }

    public set SelectedQueue(value: ExaminationQueueDefinition) {
        if (value) {
            localStorage.setItem("SelectedQueueObjectID", value.ObjectID.toString());
            this._selectedQueue = value;
        }
    }

    public get isPoolQueue(): boolean {
        return this._isPoolQueue;
    }

    public set isPoolQueue(value: boolean) {
        this._isPoolQueue = value;
    }

    public get SelectedOutPatientResource(): ResSection {
        return this._selectedOutPatientResource;
    }

    public set SelectedOutPatientResource(value: ResSection) {
        this._selectedOutPatientResource = value;
    }

    public get SelectedInPatientResource(): ResSection {
        return this._selectedInPatientResource;
    }

    public set SelectedInPatientResource(value: ResSection) {
        this._selectedInPatientResource = value;
    }

    public get SelectedSecMasterResource(): ResSection {
        return this._selectedSecMasterResource;
    }

    public set SelectedSecMasterResource(value: ResSection) {
        this._selectedSecMasterResource = value;
    }

    public set SelectedUserStore(value: Store) {
        this._selectedUserStore = value;
    }
    public get SelectedUserStore(): Store {
        return this._selectedUserStore;
    }
}