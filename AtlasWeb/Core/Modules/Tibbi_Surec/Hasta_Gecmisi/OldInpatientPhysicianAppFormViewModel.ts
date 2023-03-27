//$9DB12440
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InPatientPhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldInpatientPhysicianAppFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldInpatientPhysicianAppFormViewModel, Core';

    @Type(() => InPatientPhysicianApplication)
    public _InPatientPhysicianApplication: InPatientPhysicianApplication = new InPatientPhysicianApplication();
    public AdmissionNumber: string;

    @Type(() => Date)
    public InpatientDate: Date;

    @Type(() => Date)
    public DischargeDate: Date;

    public Clinic: string;
    public ResponsibleDoctor: string;
    public InpatientReason: string;
    public Diagnosis: string;
    public Complaint: string;
    public PhysicalExamination: string;
    public PatientHistory: string;
    public DrugOrders: string;
    public Prescription: string;
    public Vitals: string;
    public TreatmentResult: string;
    public PhysicianProgresses: string;
    public NursingApplication: string;
}
export class inPatientPhysicianProgresses {
    public Qref: string;
    public Doktor: string;
    public Date: string;
    public Note: string;
}
export class NursingApp {
    public Title: string;
    public Data: string;
}