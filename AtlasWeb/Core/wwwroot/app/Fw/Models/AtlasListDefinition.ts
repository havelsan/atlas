import { AtlasListColumnDefinition } from "./AtlasListColumnDefinition";

export class AtlasListDefinition {
    public Name: string;
    public Caption: string;
    public Description: string;
    public DisplayExpression: string;
    public ValuePropertyName: string;
    public Columns: Array<AtlasListColumnDefinition>;
    public DataSource: any;
}