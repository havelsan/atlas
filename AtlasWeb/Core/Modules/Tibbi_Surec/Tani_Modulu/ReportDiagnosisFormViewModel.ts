import { DiagnosisDefinition, DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class ReportDiagnosisFormViewModel extends BaseViewModel {
    @Type(() => DiagnosisDefinition)
    public _selectedDiagnosis: DiagnosisDefinition;
    @Type(() => Guid)
    public reportEpisodeAction: Guid;
    @Type(() => Guid)
    public episode: Guid;
    @Type(() => ReportDiagnosisGridListViewModel)
    public ReportDiagnosisGridList: ReportDiagnosisGridListViewModel[];

    constructor() {
        super();
        this.ReportDiagnosisGridList = new Array<ReportDiagnosisGridListViewModel>();
    }
}
export class ReportDiagnosisGridListViewModel {
    @Type(() => DiagnosisDefinition)
    public Diagnosis: DiagnosisDefinition;
    @Type(() => DiagnosisGrid)
    public DiagnosisGrid: DiagnosisGrid;
    public DiagnoseName: string;
    public DiagnoseCode: string;
}