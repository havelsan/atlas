//$BACC1184
import { AdvanceBack } from 'NebulaClient/Model/AtlasClientModel';
import { AdvanceBackAdvanceDetail } from 'NebulaClient/Model/AtlasClientModel';
import { AdvanceBackDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class AdvanceBackFormViewModel extends BaseViewModel {
    @Type(() => AdvanceBack)
    public _AdvanceBack: AdvanceBack = new AdvanceBack();
    @Type(() => AdvanceBackAdvanceDetail)
    public GRIDAdvanceDetailGridList: Array<AdvanceBackAdvanceDetail> = new Array<AdvanceBackAdvanceDetail>();
    @Type(() => AdvanceBackDocument)
    public AdvanceBackDocuments: Array<AdvanceBackDocument> = new Array<AdvanceBackDocument>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => EpisodeAction)
    public EpisodeActions: Array<EpisodeAction> = new Array<EpisodeAction>();
}
