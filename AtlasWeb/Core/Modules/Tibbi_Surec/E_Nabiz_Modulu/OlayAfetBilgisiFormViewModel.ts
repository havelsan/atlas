//$A65CEA38
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OlayAfetBilgisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSHayatiTehlikeDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOlayAfetBilgisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAFETOLAYVATANDASTIPI } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class OlayAfetBilgisiFormViewModel extends BaseViewModel {
  @Type(() => OlayAfetBilgisi)
    public _OlayAfetBilgisi: OlayAfetBilgisi = new OlayAfetBilgisi();
  @Type(() => SKRSHayatiTehlikeDurumu)
    public SKRSHayatiTehlikeDurumus: Array<SKRSHayatiTehlikeDurumu> = new Array<SKRSHayatiTehlikeDurumu>();
 @Type(() => SKRSOlayAfetBilgisi)
    public SKRSOlayAfetBilgisis: Array<SKRSOlayAfetBilgisi> = new Array<SKRSOlayAfetBilgisi>();
 @Type(() => SKRSAFETOLAYVATANDASTIPI)
    public SKRSAFETOLAYVATANDASTIPIs: Array<SKRSAFETOLAYVATANDASTIPI> = new Array<SKRSAFETOLAYVATANDASTIPI>();
}
