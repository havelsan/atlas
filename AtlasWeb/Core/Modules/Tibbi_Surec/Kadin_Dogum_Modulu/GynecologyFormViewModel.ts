//$F1F2FB76
import { Gynecology } from 'NebulaClient/Model/AtlasClientModel';
import { ReproductiveAbnormalityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class GynecologyFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.GynecologyFormViewModel, Core';
    public _Gynecology: Gynecology = new Gynecology();
    public ReproductiveAbnormalityDefinitions: Array<ReproductiveAbnormalityDefinition> = new Array<ReproductiveAbnormalityDefinition>();
}
