//$06EB9E2A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InfectionCommittee, DrugOrderTypeEnum, DrugUsageTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { InfectionCommitteeDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
export class InfectionCommitteeFormViewModel extends BaseViewModel {
    @Type(() => InfectionCommittee)
    public _InfectionCommittee: InfectionCommittee = new InfectionCommittee();
    @Type(() => InfectionCommitteeDetail)
    public InpatientDrugOrdersGridList: Array<InfectionCommitteeDetail> = new Array<InfectionCommitteeDetail>();
    public InfectionCommitteeDetailDTOList: Array<InFectionCommitteeDetailDTO> = new Array<InFectionCommitteeDetailDTO>();
    public OrderDTOList: Array<InFectionCommitteeDetailDTO> = new Array<InFectionCommitteeDetailDTO>();
    @Type(() => DrugOrder)
    public DrugOrders: Array<DrugOrder> = new Array<DrugOrder>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
}
export class InFectionCommitteeDetailDTO {
    @Type(() => InfectionCommitteeDetail)
    public InfectionCommitteeDetail: InfectionCommitteeDetail;
    public PlannedStartTime: Date;
    public PlannedEndTime: Date;
    public DrugName: string;
    public Frequency: string;
    public DoseAmount: number;
    public Day: number;
    public UsageNote: string;
    public IsImmediate: boolean;
    public PatientOwnDrug: boolean;
    public CaseOfNeed: boolean;
    public DrugOrderType: DrugOrderTypeEnum;
    public DoctorName: string;
    public UsageType: string;
    public Resource: string;
}

export class InpatientHasDrugListDTO {
    public OutStatus: string;
    public PlannedStartTime: Date;
    public PlannedEndTime: Date;
    public DrugName: string;
    public EhuStatus: string;
    public Dose: string;
    public DoseAmount: string;
    public Day: string;
    public Amount: string;
    public Desciption: string;
    public IsImmediately: boolean;
    public PatientOwnDrug: boolean;
    public CaseOfNeed: boolean;
    public TreatmentType: DrugUsageTypeEnum;
    public DoctorName: string;
    public ClinikName: string;

}

export class PatientInputDTO{
public SubepisodeObjectId:string;
public EpisodeObjectID: string;
public all: boolean;
}
