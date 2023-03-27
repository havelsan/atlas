//$CB3D5809
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { GaitAnalysisComputerBasedForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class GaitAnalysisComputerBasedFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.GaitAnalysisComputerBasedFormViewModel, Core';
    @Type(() => GaitAnalysisComputerBasedForm)
    public _GaitAnalysisComputerBasedForm: GaitAnalysisComputerBasedForm = new GaitAnalysisComputerBasedForm();
}
