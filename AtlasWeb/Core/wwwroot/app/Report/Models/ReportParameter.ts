import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { EnumLookupItem } from 'NebulaClient/Mscorlib/EnumLookupItem';
import { Type } from 'NebulaClient/ClassTransformer';

export class ReportParameter {
    public Order: number;
    public Name: string;
    public Caption: string;
    @Type(() => Guid)
    public DataTypeID: Guid;
    @Type(() => Boolean)
    public Required: boolean;
    @Type(() => Boolean)
    public Visible: boolean;
    public ListFilterExpression: string;
    @Type(() => Guid)
    public ListDefID: Guid;
    @Type(() => Guid)
    public LinkedParameterName: string;
    @Type(() => Guid)
    public LinkedRelationDefID: Guid;
    public DataTypeName: string;
    @Type(() => Boolean)
    public IsEnum: boolean;
    @Type(() => EnumLookupItem)
    public EnumList: Array<EnumLookupItem>;
}