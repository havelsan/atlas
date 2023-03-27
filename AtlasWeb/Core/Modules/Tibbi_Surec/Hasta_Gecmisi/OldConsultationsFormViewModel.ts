//$FA0D359A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldConsultationsFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldConsultationsFormViewModel, Core';

    @Type(() => Consultation)
    public _Consultation: Consultation = new Consultation();

    @Type(() => Date)
    public ProcessEndDate: Date;
    public AdmissionNumber: string;
    public RequesterResource: string;
    public RequesterDoctor: string;
    public MasterResource: string;
    public ProcedureSpeciality: string;
    public ProcedureDoctor: string;
    public RequestDescription: string;
    public ConsultationResultAndOffers: string;
}
