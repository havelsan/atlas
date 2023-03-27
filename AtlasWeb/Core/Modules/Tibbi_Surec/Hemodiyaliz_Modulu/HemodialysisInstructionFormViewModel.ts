//$7138B709
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HemodialysisInstruction } from "NebulaClient/Model/AtlasClientModel";

export class HemodialysisInstructionFormViewModel extends BaseViewModel {
    public _HemodialysisInstruction: HemodialysisInstruction = new HemodialysisInstruction();
}
