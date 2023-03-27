//$F0A598CB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { CigaretteExamination } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class CigaretteExaminationFormViewModel extends BaseViewModel {
    @Type(() => CigaretteExamination)
    public _CigaretteExamination: CigaretteExamination = new CigaretteExamination();
}
