import { TTControlBase } from './TTControlBase';
import { ITTControl } from '../ControlInterfaces/ITTControl';
import { ITTObject } from '../../StorageManager/InstanceManagement/ITTObject';
import { ITTBindableControl } from '../ControlInterfaces/ITTBindableControl';

export class TTControl extends TTControlBase implements ITTControl, ITTBindableControl {
    /*[Browsable(false)]*/
    // public ControlValue?: any;
    /*[Browsable(false)]*/
    public ErrorProvider?: Object;
    public Required?: boolean;
    public CaptionLabel?: string;
    public TTObject?: ITTObject;
    public InitializeAsUnbound?(): void {

    }
    public AddBindingEventHandlers?(): void {
       // throw new NotImplementedException();
    }
    public RemoveBindingEventHandlers?(): void {
        //throw new NotImplementedException();
    }
    public SetErrorText?(errorText: string): void {
        // throw new NotImplementedException();
    }
    public CheckErrors?(): string {
        // throw new NotImplementedException();
        return null;
    }
    public onLoadCompleted?() {
    }
}