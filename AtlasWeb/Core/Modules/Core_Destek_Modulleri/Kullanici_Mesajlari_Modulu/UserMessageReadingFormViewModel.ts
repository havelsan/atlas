//$F69C563C
import { UserMessage } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { UserMessageGroupDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { UserMessageAttachment } from "NebulaClient/Model/AtlasClientModel";
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class UserMessageReadingFormViewModel extends BaseViewModel {
    @Type(() => UserMessage)
    public _UserMessage: UserMessage = new UserMessage();
    @Type(() => UserMessageAttachment)
    public UserMessageAttachments: Array<UserMessageAttachment> = new Array<UserMessageAttachment>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResUser.GetResUser_Class)
    public users: Array<ResUser.GetResUser_Class> = new Array<ResUser.GetResUser_Class>();
    @Type(() => UserMessageGroupDefinition.GetAllMessageGroupDef_Class)
    public groups: Array<UserMessageGroupDefinition.GetAllMessageGroupDef_Class> = new Array<UserMessageGroupDefinition.GetAllMessageGroupDef_Class>();
    @Type(() => UserMessageGroupDefinition)
    public messagegroups: Array<UserMessageGroupDefinition> = new Array<UserMessageGroupDefinition>();
    @Type(() => ResSection.PoliclinicClinicListNQL_Class)
    public units: Array<ResSection.PoliclinicClinicListNQL_Class> = new Array<ResSection.PoliclinicClinicListNQL_Class>();
    public BoxDataSource: Array<any> = new Array<any>();

}
