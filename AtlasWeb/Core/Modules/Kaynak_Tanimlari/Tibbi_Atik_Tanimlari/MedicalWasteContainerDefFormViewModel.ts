import { BaseViewModel } from "app/NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { Type } from "app/NebulaClient/ClassTransformer";

export class MedicalWasteContainerDefFormViewModel extends BaseViewModel {
 @Type(() => MedicalWasteContainer)
 public ContainerList: Array<MedicalWasteContainer>;
 @Type(() => MedicalWasteType)
 public WasteTypeList: Array<MedicalWasteType>;
 @Type(() => MedicalWasteProduct)
 public ProductList: Array<MedicalWasteProduct>;
 @Type(() => MedicalWasteType)
 public ActiveWasteTypeList: Array<MedicalWasteType>;
}

export class MedicalWasteContainer {
    public ObjectID: Guid;
    public Capacity: number;
    public Name: string;
    public Active: boolean;
    public ObjectDefName: string;
}

export class MedicalWasteType {
    public ObjectID: Guid;
    public Code: string;
    public Name: string;
    public Active: boolean;
    public ObjectDefName: string;
    
} 

export class MedicalWasteProduct {
    public ObjectID: Guid;
    public Code: string;
    public Name: string;
    public Active: boolean;
    public ObjectDefName: string;
    public WasteTypeName: string;
    public WasteTypeID: Guid;

    
} 