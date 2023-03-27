//$2BBEFA11
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PathologyPanicAlert } from "NebulaClient/Model/AtlasClientModel";
import { PathologyPanicReasonDef } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class PanicAlertFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PanicAlertFormViewModel, Core';
    @Type(() => PathologyPanicAlert)
    public _PathologyPanicAlert: PathologyPanicAlert = new PathologyPanicAlert();
    @Type(() => PathologyPanicReasonDef)
    public PathologyPanicReasonDefs: Array<PathologyPanicReasonDef> = new Array<PathologyPanicReasonDef>();

    public UserName: string;
    public DoctorName: string;
    public NotifiedDoctorName: string;
}
