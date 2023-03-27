//$684D40DD
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MainStoreDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Accountancy } from "NebulaClient/Model/AtlasClientModel";

export class MainStoreDefinitionFormViewModel extends BaseViewModel {
    public _MainStoreDefinition: MainStoreDefinition = new MainStoreDefinition();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public Accountancys: Array<Accountancy> = new Array<Accountancy>();
}
