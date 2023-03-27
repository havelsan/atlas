import { BaseModel } from 'Fw/Models/BaseModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Resource, ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class UserResourceSelectionModel extends BaseModel {
    public OutPatientResourceList: Array<Resource>;
    public InPatientResourceList: Array<Resource>;
    public SecMasterResourceList: Array<Resource>;
    public QueueList: Array<ExaminationQueueDefinition>;
    public SelectedOutPatientResource: ResSection;
    public SelectedInPatientResource: ResSection;
    public SelectedSecMasterResource: ResSection;
    public SelectedQueue: ExaminationQueueDefinition;

    constructor() {
        super();
        this.DefaultButtonsVisible = false;
    }
}