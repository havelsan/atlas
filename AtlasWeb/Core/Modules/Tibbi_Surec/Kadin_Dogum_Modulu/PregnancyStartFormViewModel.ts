//$8627886A
import { Pregnancy } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyNotification } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebeBilgilendirmeveDanismanlik } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class PregnancyStartFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PregnancyStartFormViewModel, Core';

    @Type(() => Pregnancy)
    public _Pregnancy: Pregnancy = new Pregnancy();

    public PregnancyNotificationGridList: Array<PregnancyNotification> = new Array<PregnancyNotification>();
    public SKRSGebeBilgilendirmeveDanismanliks: Array<SKRSGebeBilgilendirmeveDanismanlik> = new Array<SKRSGebeBilgilendirmeveDanismanlik>();

    @Type(() => Patient)
    public _Patient: Patient = new Patient();
}
