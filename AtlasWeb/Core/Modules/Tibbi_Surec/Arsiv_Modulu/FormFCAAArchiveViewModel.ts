//$578CE5C6
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { FileCreationAndAnalysis, ResArchiveRoom, ResCabinet, ResShelf } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeFolderContent } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientFolder } from 'NebulaClient/Model/AtlasClientModel';
import { ResBuilding } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeFolder } from 'NebulaClient/Model/AtlasClientModel';
import { PatientFolderContentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class FormFCAAArchiveViewModel extends BaseViewModel {
    @Type(() => FileCreationAndAnalysis)
    public _FileCreationAndAnalysis: FileCreationAndAnalysis = new FileCreationAndAnalysis();
    @Type(() => Episode)
    public PatientEpisodeDetailsGridList: Array<Episode> = new Array<Episode>();

    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => PatientFolder)
    public PatientFolders: Array<PatientFolder> = new Array<PatientFolder>();
    @Type(() => ResBuilding)
    public ResBuildings: Array<ResBuilding> = new Array<ResBuilding>();
    @Type(() => EpisodeFolder)
    public EpisodeFolders: Array<EpisodeFolder> = new Array<EpisodeFolder>();

   @Type(() => EpisodeFolder)
   public StarterEpisodeFolder: EpisodeFolder = new EpisodeFolder();

   @Type(() => EpisodeFolderContent)
   public FolderContentsGridList: Array<EpisodeFolderContent> = new Array<EpisodeFolderContent>();

   @Type(() => PatientFolderContentDefinition)
   public PatientFolderContentDefinitions: Array<PatientFolderContentDefinition> = new Array<PatientFolderContentDefinition>();
   @Type(() => ResArchiveRoom)
    public ResArchiveRooms: Array<ResArchiveRoom> = new Array<ResArchiveRoom>();
    @Type(() => ResCabinet)
    public ResCabinet: Array<ResCabinet> = new Array<ResCabinet>();
    @Type(() => ResShelf)
    public ResShelves: Array<ResShelf> = new Array<ResShelf>();

    public isOldData: boolean;
}
