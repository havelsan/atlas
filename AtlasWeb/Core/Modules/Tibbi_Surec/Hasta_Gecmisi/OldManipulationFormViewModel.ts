//$7BA6C4E6
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Manipulation } from "NebulaClient/Model/AtlasClientModel";

import { Type } from 'NebulaClient/ClassTransformer';

export class OldManipulationFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldManipulationFormViewModel, Core';

    @Type(() => Manipulation)
    public _Manipulation: Manipulation = new Manipulation();

    @Type(() => Date)
    public RequestDate: Date;
    public RequestDoctor: string;
    public RequestClinic: string;
    public PreInformation: string;

    @Type(() => Date)
    public ActionDate: Date;
    public ProcedureName: string;
    public ProcedureDepartment: string;
    public ProcedureDoctor: string;
    public Description: string;
    public ProcedureReport: string;
    public ResultReport: string;
}
