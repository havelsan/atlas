//$FA4FEEB4
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { DentalLaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DentalExaminationSuggestedProsthesis } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Technician } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MalzemeTuru } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Teshis } from 'NebulaClient/Model/AtlasClientModel';


export class DentalLaboratoryFormViewModel extends BaseViewModel {
    public _DentalLaboratoryProcedure: DentalLaboratoryProcedure = new DentalLaboratoryProcedure();
    public gridProceduresGridList: Array<DentalExaminationSuggestedProsthesis> = new Array<DentalExaminationSuggestedProsthesis>();
    public TreatmentMaterialsGridList: Array<DentalProsthesisMaterial> = new Array<DentalProsthesisMaterial>();
    public DentalProsthesisDefinitions: Array<DentalProsthesisDefinition> = new Array<DentalProsthesisDefinition>();
    public Technicians: Array<Technician> = new Array<Technician>();
    public Materials: Array<Material> = new Array<Material>();
    public MalzemeTurus: Array<MalzemeTuru> = new Array<MalzemeTuru>();
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public Teshiss: Array<Teshis> = new Array<Teshis>();
}
