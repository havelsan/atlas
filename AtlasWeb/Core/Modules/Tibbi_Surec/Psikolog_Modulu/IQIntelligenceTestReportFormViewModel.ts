//$A96A4DF8
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { IQIntelligenceTestReport } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class IQIntelligenceTestReportFormViewModel extends BaseViewModel {
    @Type(() => IQIntelligenceTestReport)
    public _IQIntelligenceTestReport: IQIntelligenceTestReport = new IQIntelligenceTestReport();
    @Type(() => SKRSOgrenimDurumu)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSMeslekler)
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
    @Type(() => SKRSOgrenimDurumu)
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type(() => Boolean)
    public isUserAuthorized: Boolean;

}
