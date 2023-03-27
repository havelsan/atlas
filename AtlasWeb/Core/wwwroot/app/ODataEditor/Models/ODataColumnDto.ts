import { ODataWhereDto } from "./ODataWehereDto";

export class ODataColumnDto {
    Name: string;
    Id: string;
    ModelName: string;
    Path: string;
    WhereCondition?: ODataWhereDto;
    Listed: boolean;
    Order: string = "None";
    Type: string;
}
export class ODataGridConfig{
    url : string;
    entityName : string;
    items : Array<ODataColumnDto>;
}