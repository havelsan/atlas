import { ITTErrorChecker } from "../ITTErrorChecker";
import { TTObject } from "app/NebulaClient/StorageManager/InstanceManagement/TTObject";
import { ITTGridCell } from "./ITTGridCell";

export interface ITTGridRow extends ITTErrorChecker {
    Cells?: Array<ITTGridCell>;
    ErrorText?: string;
    Height?: number;
    Index?: number;
    MinimumHeight?: number;
    ReadOnly?: boolean;
    IsVisible?: boolean;
    Selected?: boolean;
    TTObject?: TTObject;
}