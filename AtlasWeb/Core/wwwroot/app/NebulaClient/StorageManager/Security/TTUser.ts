import { Guid } from '../../Mscorlib/Guid';
import { TTObject } from '../InstanceManagement/TTObject';
import { UserStatusEnum } from '../../Utils/Enums/UserStatusEnum';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type, Exclude, Expose } from 'NebulaClient/ClassTransformer';

export class TTUser {

    public static get CurrentUser(): TTUser {
        const activeUserService: IActiveUserService = ServiceLocator.ActiveUserService;
        return activeUserService.ActiveUser;
    }

    @Type(() => ResUser)
    @Expose({ name: 'UserObject'})
    private _userObject: TTObject = null;

    @Exclude()
    public get UserObject(): TTObject {
        if (this._userObject != null) {
            return this._userObject as TTObject;
        }
        return null; 
    }

    @Expose({ name: 'Name'})
    private _name: string;
    public get Name(): string {
        return this._name;
    }
    @Exclude()
    public set Name(value: string) {
        this._name = value;
    }

    @Expose({ name: 'UserID' })
    private _userID: string;
    public get UserID(): string {
        return this._userID;
    }
    @Exclude()
    public set UserID(value: string) {
        this._userID = value;
    } 


    @Expose({ name: 'Status'})
    private _status: UserStatusEnum;
    public get Status(): UserStatusEnum {
        return this._status;
    }
    @Exclude()
    public set Status(value: UserStatusEnum) {
        this._status = value;
    }

    @Exclude()
    public get IsSuperUser(): boolean {
        return (this._status.HasValue && (this._status.Value === UserStatusEnum.SuperUser || this._status.Value === UserStatusEnum.SystemAccount));
    }

    @Exclude()
    public HasRole(roleID: Guid): boolean {
        if (this.IsSuperUser) {
            return true;
        }
        return true;
    }
    @Expose({ name: 'Name' })
    private _privacyPatientNotShownList: Array<Guid>;
    public get PrivacyPatientNotShownList(): Array<Guid> {
        if (this._privacyPatientNotShownList == null) {
            this._privacyPatientNotShownList = new Array<Guid>();
        }
        return this._privacyPatientNotShownList;
    }
    @Exclude()
    public set PrivacyPatientNotShownList(value: Array<Guid>) {
        this._privacyPatientNotShownList = value;
    }

    @Exclude()
    public ResponsibleSpecialist: ResUser;
}