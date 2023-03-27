import { Type } from 'NebulaClient/ClassTransformer';

export class UserPackageViewModel {
    @Type(() => PackageBasicObject)
    public PackageList: Array<PackageBasicObject>;
  
}

export class PackageBasicObject {
    public ObjectID: string;
    public Name: string;

}

export class DiagnosisModel {
    public ObjectID: string;
    public Code: string; 
    public Name: string; 
}

export class PackageInfoViewModel {
    @Type(() => DiagnosisModel)
    public DiagnosisList: Array<DiagnosisModel>;
}