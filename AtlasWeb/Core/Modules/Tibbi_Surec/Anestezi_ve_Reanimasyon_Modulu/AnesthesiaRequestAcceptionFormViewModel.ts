//$589CC764
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { AnesthesiaAndReanimation } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaAndReanimationRequestedProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class AnesthesiaRequestAcceptionFormViewModel extends BaseViewModel {
    @Type(() => AnesthesiaAndReanimation)
    public _AnesthesiaAndReanimation: AnesthesiaAndReanimation = new AnesthesiaAndReanimation();
    @Type(() => AnesthesiaAndReanimationRequestedProcedure)
    public RequestedProcedureGridList: Array<AnesthesiaAndReanimationRequestedProcedure> = new Array<AnesthesiaAndReanimationRequestedProcedure>();
    @Type(() => SurgeryProcedure)
    public GridSurgeryProceduresGridList: Array<SurgeryProcedure> = new Array<SurgeryProcedure>();
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => Surgery)
    public Surgerys: Array<Surgery> = new Array<Surgery>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();

    @Type(() => Boolean)
    public isSurgeryDelay: Boolean;
}
