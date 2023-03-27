//$FE248A1D
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PathologyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICDOYERLESIMYERI } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlindigiDokununTemelOzelligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlinmaSekli } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForPathologyRejection } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { vmRequestedPathologyProcedure } from './PathologyMaterialInfoViewModel';
import { Type } from 'NebulaClient/ClassTransformer';


export class PathologyRequestMainFormViewModel extends BaseViewModel {
    @Type(() => PathologyRequest)
    public _PathologyRequest: PathologyRequest = new PathologyRequest();
    @Type(() => DiagnosisGrid)
    public DiagnosisDiagnosisGridGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => PathologyMaterial)
    public PathologyMaterialsGridList: Array<PathologyMaterial> = new Array<PathologyMaterial>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => SKRSICDOYERLESIMYERI)
    public SKRSICDOYERLESIMYERIs: Array<SKRSICDOYERLESIMYERI> = new Array<SKRSICDOYERLESIMYERI>();
    @Type(() => SKRSNumuneAlindigiDokununTemelOzelligi)
    public SKRSNumuneAlindigiDokununTemelOzelligis: Array<SKRSNumuneAlindigiDokununTemelOzelligi> = new Array<SKRSNumuneAlindigiDokununTemelOzelligi>();
    @Type(() => SKRSNumuneAlinmaSekli)
    public SKRSNumuneAlinmaSeklis: Array<SKRSNumuneAlinmaSekli> = new Array<SKRSNumuneAlinmaSekli>();
    @Type(() => ReasonForPathologyRejection)
    public ReasonForRejectMaterialList: Array<ReasonForPathologyRejection> = new Array<ReasonForPathologyRejection>();
    @Type(() => TempPathologyMaterialViewModel)
    public SelectedPathologyMaterialArray: Array<TempPathologyMaterialViewModel> = new Array<TempPathologyMaterialViewModel>();
    @Type(() => RejectedMaterialsViewModel)
    public RejectedMaterialArray: Array<RejectedMaterialsViewModel> = new Array<RejectedMaterialsViewModel>();
    @Type(() => Object)
    public _selectedProcedureObject: Object;
    @Type(() => vmRequestedPathologyProcedure)
    public _ProcedureArray: Array<vmRequestedPathologyProcedure> = new Array<vmRequestedPathologyProcedure>();
    @Type(() => Boolean)
    public _HasDept: boolean;
    @Type(() => PathologyTest)
    public ProcedureDoctorList:Array< PathologyTest> = new Array<PathologyTest>();
    @Type(() => Guid)
    public ProcedureDoctorID: Guid;
}

export class PathologyTest {
    public ObjectID: Guid;
    public Name: string;
}
export class TempPathologyMaterialViewModel { //Seçilen materyallerden patoloji oluşturmak için kullanılan model
    @Type(() => Number)
    public GroupCount: number = 0;
    @Type(() => Guid)
    public MaterialObjectID: Guid;
    @Type(() => Date)
    public DateOfSampleTaken: Date;
    public MaterialNumber: string;
    public YerlesimYeri: string;
    public AlindigiDokununTemelOzelligi: string;
    public NumuneAlinmaSekli: string;
    public ClinicalFindings: string;
    public Description: string;
    @Type(() => Boolean)
    public BiopsyCheck: boolean;
    @Type(() => Boolean)
    public CytologyCheck: boolean;
    @Type(() => Boolean)
    public BiopsyDisabled: boolean;
    @Type(() => Boolean)
    public CytologyDisabled: boolean;



}
export class RejectedMaterialsViewModel
{
    @Type(() => Guid)
    public MaterialObjectID: Guid;
    @Type(() => Guid)
    public RejectReasonID: Guid;
}

export class MaterialBarcodeInfo {
    public PatientID: string;
    public PatientNameSurname: string;
    public ProtocolNo: string;
    public RequestDoctorName: string;
    public RequestUnit: string;
    public MaterialAcceptionDate: string;
    public DateOfSampleTaken: string;
    public Organ: string;
    public MaterialArchiveNo: string;
    public Barcode: string;
}