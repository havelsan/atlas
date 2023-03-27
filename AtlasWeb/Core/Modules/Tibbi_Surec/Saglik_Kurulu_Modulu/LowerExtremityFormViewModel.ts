//$90F21BC1
import { LowerExtremity } from "NebulaClient/Model/AtlasClientModel";
import { BaseHCExaminationDynamicObjectFormViewModel } from "Modules/Tibbi_Surec/Saglik_Kurulu_Modulu/BaseHCExaminationDynamicObjectFormViewModel";

export class LowerExtremityFormViewModel extends BaseHCExaminationDynamicObjectFormViewModel {
    protected __type__: string = 'Core.Models.LowerExtremityFormViewModel, Core';
    public _LowerExtremity: LowerExtremity = new LowerExtremity();
    public IsReadOnly: boolean;
}
