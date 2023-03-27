//$FC8D1CD3
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysiotherapyTreatmentNote } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class PhysiotherapyTreatmentNoteFormViewModel extends BaseViewModel {
    @Type(() => PhysiotherapyTreatmentNote)
    public _PhysiotherapyTreatmentNote: PhysiotherapyTreatmentNote = new PhysiotherapyTreatmentNote();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();

    public isNewTreatmentNote: boolean;

    @Type(() => PhysiotherapyTreatmentNote)
    public PhyTreatmentNoteList: Array<PhysiotherapyTreatmentNote>;
    @Type(() => PhysiotherapyTreatmentNote)
    public PhyRequestTreatmentNoteList: Array<PhysiotherapyTreatmentNote>;
    @Type(() => PhysiotherapyTreatmentNote)
    public PhyOrderTreatmentNoteList: Array<PhysiotherapyTreatmentNote>;
}
