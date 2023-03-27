import { BaseModel } from 'Fw/Models/BaseModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class MaterialSelectViewModel extends BaseModel {

    public Materials: Array<MaterialTreeItem>;
}

export class MaterialMaxValue{
    public maxInheldValue:number;
    public ObjectID:string;

}

export class MaterialTreeItem {
    public ObjectID: Guid;
    public text: string;
    public ParentID: Guid;
    public expanded?: boolean;
    public items?: Array<MaterialTreeItem>;
    public Materials: Array<MaterialItem>;
}

export class MaterialItem {
    public ObjectID: string;
    @Type(() => Date)
    public TransactionDate: Date;
    public MaterialName: string;
    public Amount?: number;
    public DistributionType: string;
    public Barcode: string;
    public MaterialTreeName: string;
    public Inheld: number;
    public drugSpecification: string;
    public IsDivide:boolean;
    public DivideUnitAmount: number;
    public DivideTotalAmount: number;
    public CalculatedAmount:number;
}

export class MaterialListInputDVO {
    public StoreObjectId: string;
    public MaterialTreeItem: MaterialTreeItem;
}

export class MaterialSelectInputDVO {
    public store: Store;
    public includeDrugDefinition: boolean;
    @Type(() => Date)
    public TransactionDateMax: Date;
    @Type(() => Date)
    public TransactionDateMin: Date;
}

export class SumAmountMaterialItem {
    public ObjectID: string;
    public TotalAmount: number;
    public Inheld: number;
    public MaterialName: string;
}