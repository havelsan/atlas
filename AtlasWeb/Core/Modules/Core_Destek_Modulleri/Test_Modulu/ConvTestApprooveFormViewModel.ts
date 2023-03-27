//$F4CC6984
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ConvTest } from 'NebulaClient/Model/AtlasClientModel';
import { City } from 'NebulaClient/Model/AtlasClientModel';

export class ConvTestApprooveFormViewModel extends BaseViewModel {
    public _ConvTest: ConvTest = new ConvTest();
    public Citys: Array<City> = new Array<City>();
}
