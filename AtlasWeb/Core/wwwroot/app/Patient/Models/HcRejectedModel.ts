import { BaseModel } from 'Fw/Models/BaseModel';

export class HcRejectedModel extends BaseModel {
    TekMetin: String;
    CokSatirliMetin: String;
    SeciliNesne: string;
    RedecisionPreDiagnosis: any;
    SutGridDataSource: any[];
    SutGridDataSourceCombo: any[];

    constructor() {
        super();
        this.TekMetin = '12133123';
        this.SutGridDataSource = [];
        this.SutGridDataSourceCombo = [];
    }
}