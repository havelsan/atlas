import { Guid } from "../../Mscorlib/Guid";
import { QueryDefSubTypeEnum } from "../Enums/QueryDefSubTypeEnum";
import { ITTObjectDefData } from "./ITTObjectDefData";
import { ITTQueryParameterDefData } from "./ITTQueryParameterDefData";
import { IDictionary } from "../../System/Collections/Dictionaries/IDictionary";

export interface ITTQueryDefData {
    QueryDefID: Guid;
    ObjectDefID: Guid;
    Name: string;
    Nql: string;
    Description: string;
    Methods: string;
    Subtype: QueryDefSubTypeEnum;
    GetParameterDefs(): IDictionary<string, ITTQueryParameterDefData>;
    GetObjectDef(): ITTObjectDefData;
    ParseNQL(injectionNQL: string): string;
    ParseNQL(nql: string, injectionNQL: string): string;
}