import { ReportParameter } from './ReportParameter';
import { Type } from 'NebulaClient/ClassTransformer';

export class ReportParameters {
    @Type(() => ReportParameter)
    public List: Array<ReportParameter>;
}