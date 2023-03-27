import { Guid } from "NebulaClient/Mscorlib/Guid";

import { ActiveIngredientDefinition } from "app/NebulaClient/Model/AtlasClientModel";

//Form için oluşturulan viewmodel
export class EquivalentMaterialReportFormViewModel {
    public MaterialList: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public SearchModel: EquivalentMaterialSearchModel = new EquivalentMaterialSearchModel();
    public ActiveIngredientDefinitions: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public GridViewModel = new Array<EquivalentMaterialReportFormGridViewModel>();
}
//Listeleme için sunucuya gönderilecek olan arama kriterleri
export class EquivalentMaterialSearchModel {
    public BarcodeNo: string;
    public SelectedMaterialList: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public SelectedDrugActiveIngredients: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> = new Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>();
    public StoreObjectID: Guid;
}
//Filtreleme için dx-list (Malzeme listesi) doldurmak için oluşturulan obje
export class ListMaterialsObject {
    public ObjectID: Guid;
    public Name: string;
    public Inheldamount: number;
}

export class EquivalentMaterialReportFormGridViewModel {
    public Name: string;
    public BarcodeNo: string;
    public NatoStockNo: string;
    public ActiveIngredientName: string;
    public StockInheld: string;
    public EquivalentMaterials: Array<EquivalentMaterialReportFormGridViewModel> = new Array<EquivalentMaterialReportFormGridViewModel>();
}