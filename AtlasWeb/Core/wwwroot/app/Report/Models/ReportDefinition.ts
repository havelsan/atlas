import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ReportParameters } from './ReportParameters';
import { Type } from 'NebulaClient/ClassTransformer';

export class ReportDefinition {
    public ReportDefID: Guid;
    public ModuleDefID: Guid;
    public ReportNO: string;
    public CodeName: string;
    public InterfaceName: string;
    public ModifiedName: string;
    public Name: string;
    public Caption: string;
    public Description: string;
    public ReportXML: string;
    @Type(() => ReportParameters)
    public Parameters: ReportParameters;
}