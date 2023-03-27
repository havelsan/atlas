import { State } from './State';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class BaseModel extends BaseViewModel{

    public States: Array<State>;
    public CanSave: Boolean;
    public DefaultButtonsVisible: Boolean = true;

    constructor() {
        super();
        this.CanSave = true;
    }
}