//$B575DBAA
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyRejectReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class RadiologyRejectFormViewModel extends BaseViewModel {
    public _Radiology: Radiology = new Radiology();
    public ttgrid2GridList: Array<RadiologyMaterial> = new Array<RadiologyMaterial>();
    public GridRadiologyTestsGridList: Array<RadiologyTest> = new Array<RadiologyTest>();
    public Materials: Array<Material> = new Array<Material>();
    public StockCards: Array<StockCard> = new Array<StockCard>();
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public RadiologyRejectReasonDefinitions: Array<RadiologyRejectReasonDefinition> = new Array<RadiologyRejectReasonDefinition>();
}
