//$93665EC7
import { EvdeSaglikHizmetleri } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class EvdeSaglikBasvuruKaydetFormViewModel extends BaseViewModel {
    @Type(() => EvdeSaglikHizmetleri)
    public _EvdeSaglikHizmetleri: EvdeSaglikHizmetleri = new EvdeSaglikHizmetleri();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}

export class EvdeSaglikBasvuruSorgulaSilViewModel
{
    @Type(() => Date)
    public StartDate: Date = new Date();
    @Type(() => Date)
    public EndDate: Date = new Date();
}

export class HomeCarePatientsModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public PatientTC: string;
    public PatientName: string;
    public PatientSurname: string;
    @Type(() => Number)
    public ApplicationID: number;
    @Type(() => Boolean)
    public IsDeleted: boolean;
    @Type(() => Boolean)
    public IsSaved: boolean;
    @Type(() => Boolean)
    public IsNew: boolean;


}

export class EvdeSaglikHizmetEmirleriViewModel {
    @Type(() => Date)
    public Date: Date = new Date();
    @Type(() => Guid)
    public ResponsibleDoctor: Guid;
}