//$7FA10E5A
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { FavoriteDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { ENabizDataSets } from '../E_Nabiz_Modulu/ENabizViewModel';
import { ActionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { DiagnosisTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

export class DiagnosisGridFormViewModel extends BaseViewModel {

    @Type(() => Object)
    _selectedDiagnosis: Object;
    public DiagnosisListFilterExpression: string;
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    //QuickSelection i�in
    @Type(() => FavoriteDiagnosis)
    public FavoriteDiagnosisList: Array<FavoriteDiagnosis> = new Array<FavoriteDiagnosis>();
    public Top10DiagnosisDefinitionOfUserList: Array<DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser_Class> = new Array<DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser_Class>();
    public Last10DiagnosisOfPatientList: Array<DiagnosisGrid.GetLast10DiagnosisOfPatient_Class> = new Array<DiagnosisGrid.GetLast10DiagnosisOfPatient_Class>();
    @Type(() => vmEpisodeDiagnosisGrid)
    public EpisodeDiagnosisGridList: Array<vmEpisodeDiagnosisGrid> = new Array<vmEpisodeDiagnosisGrid>();
    @Type(() => DiagnosisDefinition.GetDiagnosisDefinition_Class)
    public HighRiskyPregnantDefiniton: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();    

}

export class vmDiagnosisGridFormDefinitionsParameter {
    @Type(() => DiagnosisGrid)
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
}


export class vmNewDiagnosisGrid {
    @Type(() => DiagnosisGrid)
    public DiagnosisGrid: DiagnosisGrid;
    public StarterAction: string;
    @Type(() => ResUser)
    public ResponsibleDoctor: ResUser;
}

export class vmEpisodeDiagnosisGrid {
    @Type(() => DiagnosisGrid)
    public DiagnosisGrid: DiagnosisGrid;
    public DiagnoseName: string;
    public DiagnoseObjectID: string;
    //@Type(() => DiagnosisDefinition)
    //public Diagnose: DiagnosisDefinition;
}


export class DiagnoseObjectSelectionViewModel {
    @Type(() => ENabizDataSets)
    public ENabizDataSets: Array<ENabizDataSets> = new Array<ENabizDataSets>();
    @Type(() => DiagnosisActionSuggestionViewModel)
    public DiagnosisActionSuggestions: Array<DiagnosisActionSuggestionViewModel> = new Array<DiagnosisActionSuggestionViewModel>();
    public PhysicianSuggestionDefs: Array<PhysicianSuggestionDefViewModel> = new Array<PhysicianSuggestionDefViewModel>();
}


export class vmDiagnosisGridReadOnly {
    public Diagnosis: string;
    public DiagnosisType: DiagnosisTypeEnum;
    @Type(() => Boolean)
    public IsMainDiagnose: boolean;
    public ResponsibleDoctor: string;
    public EntryActionType: string;

}


export class DiagnosisActionSuggestionViewModel {
    @Type(() => Guid)
    DiagnosisObjectId: Guid;
    ProcedureName: string;
    @Type(() => Guid)
    ProcedureObjectId: Guid;
    @Type(() => Guid)
    ProcedureRequestFormDetailObjectId: Guid;
    ActionType: ActionTypeEnum;
    ChoosedByUser: Boolean;
    CreateProcedure: Boolean;
    IsAdditionalApplication: Boolean;
}


export class PhysicianSuggestionDefViewModel {

    @Type(() => Guid)
    DiagnosisObjectId: Guid;
    GrupName: string;
    @Type(() => Guid)
    PhysicianSuggestionDefObjectId: Guid;
    @Type(() => Guid)
    ParentPhysicianSuggestionDefObjectId: Guid;
    ReturnValueOfParent: string;
    Message: string;
    ButtonCaptions: string;
    ReturnValues: string;
      //Tetkik istem için
    @Type(() => DiagnosisActionSuggestionViewModel)
    diagnosisActionSuggestionViewModel: DiagnosisActionSuggestionViewModel;
}

