//$1A45F629
import { SpecialityBasedObject } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class SpecialityBasedObjectFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.SpecialityBasedObjectFormViewModel, Core';

    @Type(() => SpecialityBasedObject)
    public _SpecialityBasedObject: SpecialityBasedObject = new SpecialityBasedObject();
}
