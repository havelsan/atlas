//$55E5BD3F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldSurgeryFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldSurgeryFormViewModel, Core';

    @Type(() => Surgery)
    public _Surgery: Surgery = new Surgery();

    public AdmissionNumber: string;

    @Type(() => Date)
    public SurgeryDate: Date;

    public ProtocoNo: string;
    public ProcedureDoctor: string;
    public SurgeryReport: string;

    @Type(() => OldSurgeryPersonnel)
    public SurgeryPersonnels: Array<OldSurgeryPersonnel>;

    @Type(() => OldSurgeryProcedure)
    public MainSurgeryProcedures: Array<OldSurgeryProcedure>;

    @Type(() => OldSubSurgery)
    public SubSurgeries: Array<OldSubSurgery>;

    public AnesthesiaNote: string;
    public AnesthesiaReport: string;
    public AnesthesiaTechnique: string;
    public AnesthesiaProtocolNo: string;
    public AnesthesiaProcedureDoctor: string;
}
export class OldSubSurgery {
    public SubSurgeryReport: string;

    @Type(() => OldSurgeryPersonnel)
    public SubSurgeryPersonnels: Array<OldSurgeryPersonnel>;

    @Type(() => OldSurgeryProcedure)
    public SubSurgeryProcedures: Array<OldSurgeryProcedure>;
}
export class OldSurgeryPersonnel {
    public Personnel: string;
    public Role: string;
}
export class OldSurgeryProcedure {
    public SurgeryName: string;
    public IncisionType: string;
    public Position: string;
    public ProcedureSpeciality: string;
}