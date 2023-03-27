//$650876CF
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DirectMaterialSupplyAction } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class DirectMaterialSupplyCancelledFormViewModel extends BaseViewModel  {
    @Type(() => DirectMaterialSupplyAction)
    public _DirectMaterialSupplyAction: DirectMaterialSupplyAction = new DirectMaterialSupplyAction();
     @Type(() => BaseTreatmentMaterial)
    public TreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();
     @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
     @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
     @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
     @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
}
