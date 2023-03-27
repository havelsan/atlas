//$51D98FCB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MedicalWaste } from "NebulaClient/Model/AtlasClientModel";
import { MedicalWasteProduceDefinition } from "NebulaClient/Model/AtlasClientModel";
import { MedicalWasteTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";

export class MeicalWasteFormViewModel extends BaseViewModel {
    public _MedicalWaste: MedicalWaste = new MedicalWaste();
    public MedicalWasteProduceDefinitions: Array<MedicalWasteProduceDefinition> = new Array<MedicalWasteProduceDefinition>();
    public MedicalWasteTypeDefinitions: Array<MedicalWasteTypeDefinition> = new Array<MedicalWasteTypeDefinition>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
   // public Containers: Array<MedicalWasteContainerDefinition> = new Array<MedicalWasteContainerDefinition>();
    public Container: any;
}
