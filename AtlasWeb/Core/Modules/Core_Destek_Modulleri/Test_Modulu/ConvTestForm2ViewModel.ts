//$187141F0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ConvTest } from 'NebulaClient/Model/AtlasClientModel';
import { City } from 'NebulaClient/Model/AtlasClientModel';

export class ConvTestForm2ViewModel extends BaseViewModel {
    public _ConvTest: ConvTest = new ConvTest();
    public Citys: Array<City> = new Array<City>();
}
