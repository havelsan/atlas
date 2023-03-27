//$7348E08B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SendMessageToPatient } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSHastaMesajlari } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';


export class SendMessageToPatientFormViewModel extends BaseViewModel {
    @Type(() => SendMessageToPatient)
    public _SendMessageToPatient: SendMessageToPatient = new SendMessageToPatient();
    @Type(() => SKRSHastaMesajlari)
    public SKRSHastaMesajlaris: Array<SKRSHastaMesajlari> = new Array<SKRSHastaMesajlari>();
    @Type(() => SKRSHastaMesajlari)
    public HastaMesajlari: SKRSHastaMesajlari = new SKRSHastaMesajlari();

}

