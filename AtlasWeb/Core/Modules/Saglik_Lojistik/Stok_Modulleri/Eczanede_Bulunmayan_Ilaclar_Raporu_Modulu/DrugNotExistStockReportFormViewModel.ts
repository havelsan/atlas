import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { ActiveIngredientDefinition } from "app/NebulaClient/Model/AtlasClientModel";

export class DrugNotExistStockReportFormViewModel extends BaseViewModel {
    public SelectedStore: Guid;
    public SelectedSpecificationList: Array<number> = new Array<number>();
    public SelectedShapeTypeList: Array<number> = new Array<number>();
    public SelectedActiveIngredients: Array<Guid> = new Array<Guid>();
    public SelectedMaterialList: Array<Guid> = new Array<Guid>()
}

export class GetNotExistDrug_Output {
    public DrugName: string;
    public Barcode: string;
    public IngredientName: string;
    public Amount: number;
}
