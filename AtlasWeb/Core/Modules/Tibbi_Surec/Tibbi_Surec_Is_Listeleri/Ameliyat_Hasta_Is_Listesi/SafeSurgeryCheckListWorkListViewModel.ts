//$DB89F690
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { LCDNotificationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { BaseEpisodeActionWorkListForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListForm";
import { SimpleTimer } from 'ng2-simple-timer';
import { BaseEpisodeActionWorkListFormViewModel } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';
import { IModalService } from 'Fw/Services/IModalService';
import { ResSection } from 'app/NebulaClient/Model/AtlasClientModel';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

export class SafeSurgeryChecklistWorkListViewModel {
    @Type(() => SafeSurgeryChecklistItem)
    WorkList: Array<SafeSurgeryChecklistItem> = new Array<SafeSurgeryChecklistItem>();
    _SearchCriteria: SafeSurgeryChecklistSearchCriteria = new SafeSurgeryChecklistSearchCriteria();
    // _SearchCriteria  dx-tag-box 'ı doldurmak için
}

export class SafeSurgeryChecklistSearchCriteria{
    @Type(() => Date)
    public WorkListStartDate: Date;
    @Type(() => Date)
    public WorkListEndDate: Date;
    public PatientObjectID: string;
    @Type(() => CheckListObject)
    public ActionStatus: Array<CheckListObject>;
}

export class SafeSurgeryChecklistItem {

    @Type(() => Date)
    public RequestDate: Date;
    public PatientNameSurname: string;
    public UniqueRefno: string;
 /*   @Type(() => CompletionStatusModel)
    public StatesCompletionStatus: Array<CompletionStatusModel>; */
    public IsCompleted: boolean;
    public ObjectDefID: string;
    public ObjectDefName: string;
    public ObjectID: Guid;
    public CompletedStatus: string;

}

export class CheckListObject {
    public TypeName: string;
    @Type(() => Number)
    public TypeID: number;
}

export class CompletionStatusModel{
    public Action: CheckListObject;
    public IsCompleted: boolean;
}