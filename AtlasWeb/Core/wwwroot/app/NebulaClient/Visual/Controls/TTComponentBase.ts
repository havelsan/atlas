import { ITTComponentBase } from '../ControlInterfaces/ITTComponentBase';

export class TTComponentBase implements ITTComponentBase {
    public Name?: string;
    public Text?: string;
    public ReadOnly?: boolean;
    /*[Browsable(false)]*/
    public Tag?: Object;
    public Site?: Object;
    /*public event EventHandler Disposed;*/
    public WriteDifferenceXml?(writer: Object, inheritedComponent: ITTComponentBase): void {

    }
    public IsDifferentFrom?(component: ITTComponentBase): boolean {
        return false;
    }
    public SetSecurityInvisible?(): void {

    }
    public GetSchema?(): Object {
        return null;
    }
    public ReadXml?(reader: Object): void {
        //throw new NotImplementedException();
    }
    public WriteXml?(writer: Object): void {
        //throw new NotImplementedException();
    }
    public Dispose?(): void {
        //throw new NotImplementedException();
    }
}