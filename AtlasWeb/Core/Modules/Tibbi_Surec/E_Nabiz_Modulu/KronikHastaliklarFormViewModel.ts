//$DB94C753
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { KronikHastaliklarVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSpirometri } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class KronikHastaliklarFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.KronikHastaliklarFormViewModel, Core';
    @Type(() => KronikHastaliklarVeriSeti)
    public _KronikHastaliklarVeriSeti: KronikHastaliklarVeriSeti = new KronikHastaliklarVeriSeti();
    @Type(() => SKRSSpirometri)
    public SKRSSpirometris: Array<SKRSSpirometri> = new Array<SKRSSpirometri>();
}
