import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class DocumentDefinitionViewModel extends BaseModel {
    public tabs: Array<Tab>;
    public documentDefinitions: Array<DocumentDefinitionItem>;
}

export class DocumentDefinitionItem {
    @Type(() => Guid)
    id: Guid;
    name: string;
    caption: string;
    @Type(() => Guid)
    parentID: Guid;
    items?: DocumentDefinitionItem[];
}
export class Tab {
    @Type(() => Guid)
    id: Guid;
    text: string;
}