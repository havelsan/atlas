//$DB89F690
import { BaseModel } from 'Fw/Models/BaseModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class SosyalHizmetlerWorkListFormViewModel extends BaseModel {
    @Type(() => SosyalHizmetlerWorkListFormItemModel)
    SosyalHizmetlerActionList: Array<SosyalHizmetlerWorkListFormItemModel> = new Array<SosyalHizmetlerWorkListFormItemModel>();
    _sosyalHizmetlerWorkListFormSearchCriteria: SosyalHizmetlerWorkListFormSearchCriteria = new SosyalHizmetlerWorkListFormSearchCriteria();
}

export class SosyalHizmetlerWorkListFormItemModel {

    public ObjectID: string;
    public UniqueRefno: string;
    public PatientNameSurname: string;
    public FromResource: string;
    public RoomNo: string;
    public BedNo: string;
    public ProcedureByUser: string;
    @Type(() => Date)
    public RequestDate: Date;
    @Type(() => Date)
    public CompleteDate: Date;
    public ProtocolNo: string;
    public Payer: string;
    public WorkStatus: string;
    public AdmissionType: string;
    public PatientStatus: string;
    public ComingReason: string;
    public State: string;
    public PatientType: string;

}

export class SosyalHizmetlerWorkListFormSearchCriteria {
    public workListStartDate: Date;
    public workListEndDate: Date ;
    @Type(() => Number)
    public patienttype: number;
    @Type(() => ComboModel)
    public SosyalHizmetlerWorkListStateItem: Array<ComboModel> = new Array<ComboModel>();
    public uniqueRefno: string;
    public patientObjectID: string;
    public kabulNo: string;
    @Type(() => ComboModel)
    public RequesterDoctorList: Array<ComboModel> = new Array<ComboModel>();
    @Type(() => ComboModel)
    public FromResourceList: Array<ComboModel> = new Array<ComboModel>();
    @Type(() => ResUser)
    public ProcedureByUser: ResUser = null;


}

export class ComboModel {
    public Text: string;
    public value: Guid ;
}

