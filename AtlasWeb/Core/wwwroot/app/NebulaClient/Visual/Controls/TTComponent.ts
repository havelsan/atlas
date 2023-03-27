import { TTComponentBase } from './TTComponentBase';
import { ITTComponent } from '../ControlInterfaces/ITTComponent';
import { ITTBindableComponent } from '../ControlInterfaces/ITTBindableComponent';
import { TTObjectDef } from '../../StorageManager/DefinitionManagement/TTObjectDef';
import { TTObject } from '../../StorageManager/InstanceManagement/TTObject';

export class TTComponent extends TTComponentBase implements ITTComponent, ITTBindableComponent {
    public DataMember?: string;
    public ObjectDef?: TTObjectDef;
    public PropertyName?: string;
    public ApplySecurity?(): void {

    }
    public Initialize?(ttObject: TTObject, ttObjectDef: TTObjectDef, propertyName: string): void {
        //throw new NotImplementedException();
    }
    public ReadValueFromObject?(ttObject: TTObject): void {
        //throw new NotImplementedException();
    }
    public WriteValueToObject?(): void {

    }
}