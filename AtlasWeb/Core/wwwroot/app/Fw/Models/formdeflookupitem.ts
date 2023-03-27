import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class FormDefLookupItem {
    @Type(() => Guid)
    public FormDefID: Guid;
    public FormName: string;
    public ModuleName: string;
    public ModulePath: string;
}

FormDefLookupItem.prototype.toString = function() {
    return this.FormName;
};