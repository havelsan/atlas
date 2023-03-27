//$DB89F690
import { BaseModel } from 'Fw/Models/BaseModel';
import { ResUser, ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { DietDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { listboxObject } from "app/Invoice/InvoiceHelperModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class DietWorkListViewModel extends BaseModel {
    @Type(() => DietWorkListItemModel)
    DietActionList: Array<DietWorkListItemModel> = new Array<DietWorkListItemModel>();
    _dietWorkListSearchCriteria: DietWorkListSearchCriteria = new DietWorkListSearchCriteria();
}

export class DietWorkListItemModel {

    public ObjectID: string;
    public ObjectDefID: string;
    public ObjectDefName: string;
    public DietType: string;
    public Breakfast: boolean;
    public Lunch: boolean;
    public Dinner: boolean;
    public NightBreakfast: boolean;
    public Snack1: boolean;
    public Snack2: boolean;
    public Snack3: boolean;
    public PatientNameSurname: string;
    public PatientStatus: string;
    public TreatmentClinic: string;
    public PhysicianClinic: string;
    public RoomGroupName: string;
    public Room: string;
    public Bed: string;
    public ResponsibleDoctor: string;
    public CurrentState: string;
    @Type(() => Date)
    public WorkListDate: Date;
    public CurrentSateDefID: string;
    public OrderDescription: string;

}

export class DietWorkListSearchCriteria {
    public workListStartDate: Date;
    public workListEndDate: Date;
    @Type(() => ResClinic)
    public physicalstateclinic: ResClinic;
    @Type(() => ResClinic)
    public treatmentclinic: ResClinic;
    @Type(() => ResUser)
    public responsibledoctor: ResUser;
    @Type(() => DietDefinition)
    public diettype: DietDefinition;
    public dietWorkListStateItem: string;
    public inpatientStatus: boolean;

    constructor() {
        //this.physicalstateclinic = new ResClinic();
        //this.treatmentclinic = new ResClinic();
        //this.responsibledoctor = new ResUser();
        //this.diettype = new DietDefinition();
        //this.workListStartDate = new Date();
        //this.workListEndDate = new Date();
    }

}

export class DietWorkListRaitonSearchCriteria {
    public workListStartDate: Date;
    public workListEndDate: Date;
    @Type(() => ResClinic)
    public physicalstateclinic: ResClinic;
    @Type(() => ResClinic)
    public treatmentclinic: ResClinic;
    public includeReported: boolean;
    public additionalReport: boolean;

    constructor() {
        // this.physicalstateclinic = new listboxObject();
        // this.treatmentclinic = new listboxObject();
    }
}

export class DietRationCountItem {
    public DietName: string;
    public BreakfastCount: number;
    public LunchCount: number;
    public DinnerCount: number;
    public NightBreakfastCount: number;
    public Snack1Count: number;
    public Snack2Count: number;
    public Snack3Count: number;
    public TotalCount: number;
}
