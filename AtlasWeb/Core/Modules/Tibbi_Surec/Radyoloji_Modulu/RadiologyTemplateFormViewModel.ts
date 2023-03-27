import { Type } from 'NebulaClient/ClassTransformer';

export class RadiologyTemplateFormViewModel {

    @Type(() => RadiologyProcedureInfo)
    public RadiologyProcedureList: Array<RadiologyProcedureInfo>;

    @Type(() => RadiologyTemplateInfo)
    public TemplateList: Array<RadiologyTemplateInfo>;

    @Type(() => RadiologyDoctorInfo)
    public RadiologyDoctorList: Array<RadiologyDoctorInfo>;
}

export class RadiologyProcedureInfo {
    public ObjectID: string;
    public Code: string;
    public Name: string;
}
export class RadiologyTemplateInfo {
    public ObjectID: string;
    public Name: string;
}

export class RadiologyTemplateInput {
    public Report: Object;
    public RadiographyTechnique: Object;
    public ComparisonInfo: Object;
    public Results: Object;
    public TemplateName: string;
    public ObjectID: string;
    @Type(() => Boolean)
    public IsActive: boolean;
    @Type(() => Boolean)
    public IsNew: boolean = true;
    @Type(() => RadiologyProcedureInfo)
    public SelectedRadiologyProcedures: Array<RadiologyProcedureInfo> = new Array<RadiologyProcedureInfo>();
    @Type(() => RadiologyDoctorInfo)
    public SelectedRadiologyDoctors: Array<RadiologyDoctorInfo>;
}

export class RadiologyDoctorInfo {
    public ObjectID: string;
    public Name: string;
}