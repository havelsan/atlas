import { Guid } from "../../Mscorlib/Guid";
import { AttributeParameterSubtypeEnum } from "../Enums/AttributeParameterSubtypeEnum";
import { AttributeParameterTargetEnum } from "../Enums/AttributeParameterTargetEnum";

export interface ITTAttributeParameterDefData {
    AttributeDefID: Guid;
    ParameterDefID: Guid;
    Name: string;
    Description: string;
    DataTypeID: Guid;
    IsRequired: boolean;
    ObjectDefID: Guid;
    SubType: AttributeParameterSubtypeEnum;
    Target: AttributeParameterTargetEnum;
}