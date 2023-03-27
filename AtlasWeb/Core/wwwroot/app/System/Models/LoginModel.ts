import { BaseModel } from 'Fw/Models/BaseModel';

export class LoginModel extends BaseModel {

    public UserName: string;
    public Password: string;

    constructor() {
        super();

        this.DefaultButtonsVisible = false;
    }
}