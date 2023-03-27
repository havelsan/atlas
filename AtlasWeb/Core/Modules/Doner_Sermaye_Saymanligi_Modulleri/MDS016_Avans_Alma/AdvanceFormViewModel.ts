//$B83D8690
import { Advance } from 'NebulaClient/Model/AtlasClientModel';
import { AdvanceDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { CashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class AdvanceFormViewModel extends BaseViewModel {
    @Type(() => Advance)
    public _Advance: Advance = new Advance();
    @Type(() => AdvanceDocument)
    public AdvanceDocuments: Array<AdvanceDocument> = new Array<AdvanceDocument>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => CashierLog)
    public CashierLogs: Array<CashierLog> = new Array<CashierLog>();
    @Type(() => Patient)
    public Patient: Patient = new Patient();
}
