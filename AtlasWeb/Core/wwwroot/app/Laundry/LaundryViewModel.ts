
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';
 
export class HasLaundryRolesModel
{
    public hasLaundryMainFormRole: boolean;
    public hasCleaningFormRole: boolean;
    public hasLaundryDefinitionFormRole: boolean;
    public hasLaundryStatusFormRole: boolean; 
    constructor() {
        this.hasLaundryMainFormRole = false;
        this.hasCleaningFormRole = false;
        this.hasLaundryDefinitionFormRole = false;
        this.hasLaundryStatusFormRole = false; 
    }
}


export class LaundryDefinitionFormViewModel {
    //public SelectedLinenGroup: LinenGroupModel;
    public LinenGroups: Array<LinenGroupModel>;
    public LinenLocations: Array<LinenLocationModel>;
    public LinenTypes: Array<LinenTypeModel>;
    constructor() {
        this.LinenGroups = new Array<LinenGroupModel>();
        this.LinenLocations = new Array<LinenLocationModel>();
        this.LinenTypes = new Array<LinenTypeModel>();
    }
}

export class LinenGroupModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public IntegrationCode: string;
}

export class LinenLocationModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Location: string;
    public MahalNo: string;
    public IntegrationCode: string;
}

export class LinenTypeModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Type: string;
    public MaxWashingCount: number;
    @Type(() => Guid)
    public LinenGroup: Guid;
    public IntegrationCode: string;
}

export class BedCleaningFormViewModel{
    public QueryBedStatus: number;
    public Result: Array<BedCleaningFormResultModel>;

    constructor() {
        this.QueryBedStatus = 0;
        this.Result = new Array<BedCleaningFormResultModel>();
    }
}

export class BedCleaningFormResultModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ResSection: string;
    public RoomGroup: string;
    public Room: string;
    public Bed: string;
    public IsClean: boolean;
}

export class LaundryStatusFormViewModel {
    public Query: LaundryStatusQueryModel;
    public Result: Array<LaundryStatusResultModel>;

    constructor() {
        this.Query = new LaundryStatusQueryModel();
        this.Result = new Array<LaundryStatusResultModel>();
    }
}
export class LaundryStatusQueryModel {
    @Type(() => Guid)
    public Type: Guid;
    @Type(() => Guid)
    public Group: Guid;
    @Type(() => Guid)
    public Location: Guid;
    public ExpiredLinens: boolean; 
}
export class LaundryStatusResultModel {
  @Type(() => Guid)
    public Type: Guid;
    @Type(() => Guid)
    public Group: Guid;
    @Type(() => Guid)
    public Location: Guid;
    public TotalCount: number;
    public UsedCount: number;
    public ExpiredCount: number;
    public ExceededMWC: number;
}