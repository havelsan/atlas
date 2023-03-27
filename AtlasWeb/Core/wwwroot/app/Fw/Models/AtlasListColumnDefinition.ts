
import { AtlasListColumnLookupDefinition } from './AtlasListColumnLookupDefinition';

export class AtlasListColumnDefinition {
    public Name: string;
    public MemberName: string;
    public Caption: string;
    public ColumnOrder: number;
    public ColumnWidth: number;
    public Lookup: AtlasListColumnLookupDefinition;
}