//$BE29139B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BloodProductRequest } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { BloodBankBloodProducts } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';

export class BloodProductRequestFormViewModel extends BaseViewModel {
    public _BloodProductRequest: BloodProductRequest = new BloodProductRequest();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public ttgrid1GridList: Array<BloodBankBloodProducts> = new Array<BloodBankBloodProducts>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
}
