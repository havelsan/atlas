//$28BC7CBC
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { AnesthesiaAndReanimation } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaAndReanimationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MalzemeTuru } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class AnesthesiaReportFormViewModel extends BaseViewModel {
    @Type(() => AnesthesiaAndReanimation)
    public _AnesthesiaAndReanimation: AnesthesiaAndReanimation = new AnesthesiaAndReanimation();
    @Type(() => SurgeryProcedure)
    public GridSurgeryProceduresGridList: Array<SurgeryProcedure> = new Array<SurgeryProcedure>();
    @Type(() => AnesthesiaPersonnel)
    public GridAnesthesiaPersonnelsGridList: Array<AnesthesiaPersonnel> = new Array<AnesthesiaPersonnel>();
    @Type(() => AnesthesiaProcedure)
    public GridAnesthesiaProceduresGridList: Array<AnesthesiaProcedure> = new Array<AnesthesiaProcedure>();
    @Type(() => AnesthesiaAndReanimationTreatmentMaterial)
    public GridAnesthesiaExpendsGridList: Array<AnesthesiaAndReanimationTreatmentMaterial> = new Array<AnesthesiaAndReanimationTreatmentMaterial>();
    @Type(() => Surgery)
    public Surgerys: Array<Surgery> = new Array<Surgery>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResSurgeryRoom)
    public ResSurgeryRooms: Array<ResSurgeryRoom> = new Array<ResSurgeryRoom>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => AyniFarkliKesi)
    public AyniFarkliKesis: Array<AyniFarkliKesi> = new Array<AyniFarkliKesi>();
    @Type(() => ResSurgeryDesk)
    public ResSurgeryDesks: Array<ResSurgeryDesk> = new Array<ResSurgeryDesk>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => MalzemeTuru)
     public MalzemeTurus: Array<MalzemeTuru> = new Array<MalzemeTuru>();
    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => ResUser)
    public ResponsibleDoctor_DataSource: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResUser)
    public SelectedResponsibleDoctorList: Array<ResUser> = new Array<ResUser>();
    @Type(() => Boolean)
    public OnlyOneProcedureDoctor: Boolean;
}
