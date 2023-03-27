import { BaseModel } from 'Fw/Models/BaseModel';

export class ChangePasswordModel extends BaseModel {


    public UserName: string;
    public OldPassword: string;
    public NewPassword: string;
    public ApplyNewPassword: string;

    public KPSUserName: string;
    public KPSPassWord: string;
    constructor() {
        super();

        this.DefaultButtonsVisible = false;
    }
}