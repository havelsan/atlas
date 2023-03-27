//$98BDA226
import { BaseViewModel } from "../../../wwwroot/app/NebulaClient/Model/BaseViewModel";
import { HemodialysisInstruction } from "NebulaClient/Model/AtlasClientModel";
import { MultipleDataComponent_SummaryInfo } from "../Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryFormViewModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class InstructionListFormViewModel extends BaseViewModel {
    @Type(() => HemodialysisInstruction)
    public _HemodialysisInstruction: HemodialysisInstruction = new HemodialysisInstruction();

    @Type(() => MultipleDataComponent_SummaryInfo)
    public HemodialysisInstructionInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
}


