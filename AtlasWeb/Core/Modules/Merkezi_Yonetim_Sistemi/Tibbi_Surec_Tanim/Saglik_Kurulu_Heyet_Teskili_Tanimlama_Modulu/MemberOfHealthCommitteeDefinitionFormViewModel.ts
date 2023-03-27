//$DCC7DFF6
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MemberOfHealthCommitteeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { HealthCommitteMemberGrid } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "app/NebulaClient/ClassTransformer";

export class MemberOfHealthCommitteeDefinitionFormViewModel extends BaseViewModel {
    public _MemberOfHealthCommitteeDefinition: MemberOfHealthCommitteeDefinition = new MemberOfHealthCommitteeDefinition();
    public MembersGridList: Array<HealthCommitteMemberGrid> = new Array<HealthCommitteMemberGrid>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public ResSections: Array<ResSection> = new Array<ResSection>();

    @Type(() => ResSection)
    public ResSectionList: Array<ResSection> = new Array<ResSection>();

    @Type(() => ResUser)
    public DoctorList: Array<ResUser> = new Array<ResUser>();
}
