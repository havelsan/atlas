import { Guid } from '../Mscorlib/Guid';
import { TTBoundFormBase } from './TTBoundFormBase';
import { TTObject } from '../StorageManager/InstanceManagement/TTObject';
import { DialogResult } from '../Utils/Enums/DialogResult';
import { TTObjectStateTransitionDef } from '../StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

export class TTForm extends TTBoundFormBase {

    private _dropStateList: Array<Guid> = new Array<Guid>();
    public DropStateList: Array<Guid> = new Array<Guid>();
    private _addStateList: Array<Guid> = new Array<Guid>();
    public AddStateList: Array<Guid> = new Array<Guid>();

    public static GetEditForm(ttObject: TTObject): TTForm {
        return null;
    }
    public ShowReadOnly(parent: Object, ttObject: TTObject): DialogResult {
        return null;
    }
    public ShowEdit(parent: Object, ttObject: TTObject, NotDrawStateButtons?: boolean): DialogResult {
        return null;
    }
    protected PrapareFormToShow(frm: TTForm): void {
    }

    protected AfterContextSavedScript(transDef: TTObjectStateTransitionDef): void {
    }

    protected OnKeyDown(e: any): void {
    }

    public AddStateButton(stateDefID: Guid): void {
        // State buttonu eklenmeden önce dropstatelist içerisinde var mı, kontrol edilecek
        // Dropstatelist içerisinde varsa öncelikle oradan çıkarılacak. A.Ş. 31.05.2018
        let checkItemForDropStateList = this._dropStateList.find(s => s.id.valueOf() === stateDefID.valueOf());
        if (checkItemForDropStateList != null) {
            const index = this._dropStateList.indexOf(checkItemForDropStateList);
            if (index > -1) {
                this._dropStateList.splice(index, 1);
            }
        }

        let checkItem = this._addStateList.find(s => s.id.valueOf() === stateDefID.valueOf());
        if (checkItem == null) {
            this._addStateList.push(stateDefID);
        }

        let tempAddStateList = new Array<Guid>();
        let addStateList = tempAddStateList.concat(this._addStateList);
        this.AddStateList = addStateList;
    }

    public DropStateButton(stateDefID: Guid): void {
        // State buttonu çıkarılmadan önce addstatelist içerisinde var mı, kontrol edilecek
        // Addstatelist içerisinde varsa öncelikle oradan çıkarılacak. A.Ş. 31.05.2018
        let checkItemForAddStateList = this._addStateList.find(s => s.id.valueOf() === stateDefID.valueOf());
        if (checkItemForAddStateList != null) {
            const index = this._addStateList.indexOf(checkItemForAddStateList);
            if (index > -1) {
                this._addStateList.splice(index, 1);
            }
        }

        let checkItem = this._dropStateList.find(s => s.id.valueOf() === stateDefID.valueOf());
        if (checkItem == null) {
            this._dropStateList.push(stateDefID);
        }

        let tempDropStateList = new Array<Guid>();
        let dropStateList = tempDropStateList.concat(this._dropStateList);
        this.DropStateList = dropStateList;
    }

    public DropCurrentStateReport(reportName: string): void {
    }

    public isModal(): boolean {
        if (typeof this['setModalInfo'] === 'function') {
            return true;
        }
        return false;
    }

}
