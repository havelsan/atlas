//$475E9555
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { CigaretteExamination } from "NebulaClient/Model/AtlasClientModel";
import { SubEpisode } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMedeniHali } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOgrenimDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMeslekler } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class CigaretteAssessmentFormViewModel extends BaseViewModel {
    @Type(() => CigaretteExamination)
    public _CigaretteExamination: CigaretteExamination = new CigaretteExamination();
    @Type(() => SubEpisode)
    public SubEpisodes: Array<SubEpisode> = new Array<SubEpisode>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => SKRSMedeniHali)
    public SKRSMedeniHalis: Array<SKRSMedeniHali> = new Array<SKRSMedeniHali>();
    @Type(() => SKRSOgrenimDurumu)
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type(() => SKRSMeslekler)
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
}
