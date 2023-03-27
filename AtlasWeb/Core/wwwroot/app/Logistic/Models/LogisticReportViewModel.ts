import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class LogisticReportViewModel extends BaseModel {
    public Reports: Array<Report>;

}

export class Report {
    @Type(() => Guid)
    id: Guid;
    name: string;
    caption: string;
    items?: Report[];
}

export class SubStoreModel {
    public Stores: SubStoreItem[];
}
export class SubStoreItem {
    public id: string;
    public name: string;
}