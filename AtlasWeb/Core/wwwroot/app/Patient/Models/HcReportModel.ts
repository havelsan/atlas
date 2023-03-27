import { BaseModel } from 'Fw/Models/BaseModel';

export class HcReportModel extends BaseModel {
    TekMetin: String;
    CokSatirliMetin: String;
    SeciliNesne: string;
    enable: boolean;
    constructor() {
        super();
        this.TekMetin = '12133123';
    }
}