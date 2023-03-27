import { Guid } from "NebulaClient/Mscorlib/Guid";

import { ActiveIngredientDefinition } from "app/NebulaClient/Model/AtlasClientModel";

//Form için oluşturulan viewmodel
export class CovidDrugReportFormViewModel {

}
//Listeleme için sunucuya gönderilecek olan arama kriterleri
export class CovidDrugReportSearchModel {
    public StartDate: Date;
    public EndDate: Date;
}


export class CovidDrugReportFormGridViewModel {
    public HidOutpatient: number;
    public FavOutpatient: number;
    public HidFavOutpatient: number;
    public AntiOutpatient: number;
    public SteOutpatient: number;
    public HidInpatient: number;
    public FavInpatient: number;
    public HidFavInpatient: number;
    public AntiInpatient: number;
    public SteInpatient: number;
}