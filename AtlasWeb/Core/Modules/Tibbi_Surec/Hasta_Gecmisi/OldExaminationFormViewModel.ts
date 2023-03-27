//$30E8D33F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PatientExamination } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldExaminationFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldExaminationFormViewModel, Core';

    @Type(() => PatientExamination)
    public _PatientExamination: PatientExamination = new PatientExamination();

    @Type(() => Date)
    public AdmissionDate: Date;
    public AdmissionClinic: string;
    public ProcedureDoctor: string;
    public AdmissionNumber: string;
    public Diagnosis: string;
    public Complaint: string;
    public PatientStory: string;
    public PhysicalExamination: string;
    public PatientHistory: string;
    public PatientFamilyHistory: string;
    public Prescription: string;
    public MedicalInformation: string;
    public TreatmentResult: string;

    @Type(() => Date)
    public ProcessStartDate: Date;

    @Type(() => Date)
    public ProcessEndDate: Date;
}
