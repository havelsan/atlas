//$0808700A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { EmergencySpecialityObject } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldEmergencyFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldEmergencyFormViewModel, Core';

    @Type(() => EmergencySpecialityObject)
    public _EmergencySpecialityObject: EmergencySpecialityObject = new EmergencySpecialityObject();

    public GeneralValuation: string;
    public PsychologicalEvaluation: string;
    public General: string;
    public HeadNeckEye: string;
    public KVS: string;
    public Breath: string;
    public GIS: string;
    public Eye: string;
    public Woman: string;
    public Breast: string;
    public PsychologicalInfo: string;
    public Man: string;
    public Hormon: string;
    public Neural: string;
    public Musculoskeletal: string;
    public GlaskowEye: string;
    public GlaskowOralAnswer: string;
    public GlaskowMotorAnswer: string;
    public GlaskowTotal: string;
    public AgriYeri: string;
    public AgriSikligi: string;
    public AgriNiteligi: string;
    public YuzSkalasi: string;
}
