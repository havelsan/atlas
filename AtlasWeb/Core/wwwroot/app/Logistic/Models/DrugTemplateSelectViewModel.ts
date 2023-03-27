import { BaseModel } from 'Fw/Models/BaseModel';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';

export class DrugTemplateSelectViewModel extends BaseModel {

}

export class TemplateItem {
    public templateName: string;
    public drugs: Array<DrugOrderIntroductionDet>;
    public gridDetails: Array<GridDetailItem>;
}

export class TempInputDVO {
    public details: Array<DrugOrderIntroductionDet>;
}

export class GridDetailItem {
    public Name: string;
    public Frequency: string;
    public DoseAmount: number;
    public Day: number;
}

