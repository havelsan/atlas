import { Guid } from "../../Mscorlib/Guid";

export interface ITTObjectStateTransitionDefData {
    StateTransitionDefID: Guid;
    Name: string;
    Description: string;
    FromStateDefID: Guid;
    ToStateDefID: Guid;
    ShouldCallBasePreScript: boolean;
    ShouldCallBasePostScript: boolean;
    ShouldCallBaseUndoScript: boolean;
    ChildShouldCallPreScript: boolean;
    ChildShouldCallPostScript: boolean;
    ChildShouldCallUndoScript: boolean;
    PreScript: string;
    PostScript: string;
    UndoScript: string;
    OrderNo: number;
}