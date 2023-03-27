import { Type } from "app/NebulaClient/ClassTransformer";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { EntityStateEnum } from "app/NebulaClient/Utils/Enums/EntityStateEnum";
import { listboxObject } from "app/Invoice/InvoiceHelperModel";

export class SutRuleEngineDefinitionFormViewModel {
    public SUTCode: string;
    @Type(() => RuleSetDTO)
    public RuleSetDTO: RuleSetDTO = new RuleSetDTO();
    public ErrorMessage: string;
}

export class RuleSetDTO {
    @Type(() => Rule1DTO)
    public Rule1DTO: Rule1DTO = new Rule1DTO();
    @Type(() => Rule2DTO)
    public Rule2DTO: Rule2DTO = new Rule2DTO();
    @Type(() => Rule3DTO)
    public Rule3DTO: Rule3DTO = new Rule3DTO();
    @Type(() => Rule5DTO)
    public Rule5DTO: Rule5DTO = new Rule5DTO();
    @Type(() => Rule18DTO)
    public Rule18DTO: Rule18DTO = new Rule18DTO();
    @Type(() => Rule7DTO)
    public Rule7DTO: Rule7DTO = new Rule7DTO();
    @Type(() => Rule16DTO)
    public Rule16DTO: Rule16DTO = new Rule16DTO();
    @Type(() => Rule17DTO)
    public Rule17DTO: Rule17DTO = new Rule17DTO();
    @Type(() => Rule20DTO)
    public Rule20DTO: Rule20DTO = new Rule20DTO();
}

export interface IRule {
    ObjectId: Guid;
    GroupId: Guid;
    ProcedureCode: string
    BlockRequest: boolean;
    Active: boolean;
}

export class Rule1DTO {

    @Type(() => Rule1DataSourceObject)
    public Rule1DataSource: Array<Rule1DataSourceObject> = new Array<Rule1DataSourceObject>();
    public EntityState: EntityStateEnum = EntityStateEnum.Unchanged;

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined)
                this.EntityState = EntityStateEnum.Added;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined)
                this.EntityState = EntityStateEnum.Added;
            this._active = v;
        }
    }
}

//Yasaklı İşlemler
export class Rule1DataSourceObject {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public ProcedureCode2: string;
    //Yasaklı işlemin adı
    public ProcedureName2: string;
    public EntityState: EntityStateEnum = EntityStateEnum.Unchanged;
}

//Branş Sınırlaması
export class Rule2DTO implements IRule {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public BranchCodes: Array<string> = new Array<string>();
    public BranchCodesAndNames: Array<listboxObject> = new Array<listboxObject>();
    public EntityState?: EntityStateEnum = EntityStateEnum.Unchanged;

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._active = v;
        }
    }
}

export class Rule3DTO implements IRule {
    // @Type(() => Number)
    // public NumOfDays?: number;
    // @Type(() => Number)
    // public MaxQuantity?: number;
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public EntityState?: EntityStateEnum = EntityStateEnum.Unchanged;

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._active = v;
        }
    }

    @Type(() => Number)
    private _numofdays?: number;
    public get NumOfDays(): number {
        return this._numofdays;
    }
    public set NumOfDays(v: number) {
        if (this._numofdays != v) {
            if (this.ObjectId != null && this.ObjectId.toString() != Guid.Empty.id) {
                if (v == null && this._maxquantity == null)
                    this.EntityState = EntityStateEnum.Deleted;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            else {
                if (v == null && this._maxquantity == null)
                    this.EntityState = EntityStateEnum.Unchanged;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            this._numofdays = v;
        }
    }

    @Type(() => Number)
    private _maxquantity?: number;
    public get MaxQuantity(): number {
        return this._maxquantity;
    }
    public set MaxQuantity(v: number) {
        if (this._maxquantity != v) {
            if (this.ObjectId != null && this.ObjectId.toString() != Guid.Empty.id) {
                if (v == null && this._numofdays == null)
                    this.EntityState = EntityStateEnum.Deleted;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            else {
                if (v == null && this._numofdays == null)
                    this.EntityState = EntityStateEnum.Unchanged;
                else
                    this.EntityState = EntityStateEnum.Added;
            }

            this._maxquantity = v;
        }
    }
}

//Yaş Kontrolü
export class Rule5DTO implements IRule {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public EntityState?: EntityStateEnum = EntityStateEnum.Unchanged;

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._active = v;
        }
    }

    @Type(() => Number)
    private _minAge?: number;
    public get MinAge(): number {
        return this._minAge;
    }
    public set MinAge(v: number) {
        if (this._minAge != v) {
            if (this.ObjectId != null && this.ObjectId.toString() != Guid.Empty.id) {
                if (v == null && this._maxAge == null || (v == 0 && this._maxAge == 0))
                    this.EntityState = EntityStateEnum.Deleted;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            else {
                if (v == null && this._maxAge == null || (v == 0 && this._maxAge == 0))
                    this.EntityState = EntityStateEnum.Unchanged;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            this._minAge = v;
        }
    }

    @Type(() => Number)
    private _maxAge?: number;
    public get MaxAge(): number {
        return this._maxAge;
    }
    public set MaxAge(v: number) {
        if (this._maxAge != v) {
            if (this.ObjectId != null && this.ObjectId.toString() != Guid.Empty.id) {
                if (v == null && this._minAge == null || (v == 0 && this._minAge == 0))
                    this.EntityState = EntityStateEnum.Deleted;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            else {
                if (v == null && this._minAge == null || (v == 0 && this._minAge == 0))
                    this.EntityState = EntityStateEnum.Unchanged;
                else
                    this.EntityState = EntityStateEnum.Added;
            }

            this._maxAge = v;
        }
    }
}

//Tanı kontrolü
export class Rule7DTO implements IRule {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public Icd10List: Array<string> = new Array<string>();
    public Icd10ListAndNames: Array<listboxObject> = new Array<listboxObject>();
    public EntityState?: EntityStateEnum = EntityStateEnum.Unchanged;

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._active = v;
        }
    }
}

//Tek başına fatura edilemez.
export class Rule16DTO implements IRule {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public ProcedureList: Array<string> = new Array<string>();
    public ProcedureNameAndCodes: Array<listboxObject> = new Array<listboxObject>();
    public EntityState?: EntityStateEnum = EntityStateEnum.Unchanged;

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._active = v;
        }
    }
}

//Ömür boyu adet kontrolu
export class Rule17DTO implements IRule {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public EntityState?: EntityStateEnum = EntityStateEnum.Unchanged;

    @Type(() => Number)
    private _lifeTimeMaxQuantity?: number;
    public get LifeTimeMaxQuantity(): number {
        return this._lifeTimeMaxQuantity;
    }
    public set LifeTimeMaxQuantity(v: number) {
        if (this._lifeTimeMaxQuantity != v) {
            if (this.ObjectId != null && this.ObjectId.toString() != Guid.Empty.id) {
                if (v == null)
                    this.EntityState = EntityStateEnum.Deleted;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            else {
                if (v == null)
                    this.EntityState = EntityStateEnum.Unchanged;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            this._lifeTimeMaxQuantity = v;
        }
    }

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._active = v;
        }
    }
}

export class Rule18DTO implements IRule {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public EntityState?: EntityStateEnum = EntityStateEnum.Unchanged;

    private _gender?: string;
    public get Gender(): string {
        return this._gender;
    }
    public set Gender(v: string) {
        if (this._gender != v) {
            if (this.ObjectId != null && this.ObjectId.toString() != Guid.Empty.id) {
                if (v == null)
                    this.EntityState = EntityStateEnum.Deleted;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            else {
                if (v == null)
                    this.EntityState = EntityStateEnum.Unchanged;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            this._gender = v;
        }
    }

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._active = v;
        }
    }
}

export class Rule20DTO implements IRule {
    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Guid)
    public GroupId: Guid;
    public ProcedureCode: string;
    public EntityState?: EntityStateEnum = EntityStateEnum.Unchanged;

    @Type(() => Number)
    private _treatmentMaxQuantity?: number;
    public get TreatmentMaxQuantity(): number {
        return this._treatmentMaxQuantity;
    }
    public set TreatmentMaxQuantity(v: number) {
        if (this._treatmentMaxQuantity != v) {
            if (this.ObjectId != null && this.ObjectId.toString() != Guid.Empty.id) {
                if (v == null)
                    this.EntityState = EntityStateEnum.Deleted;
                else
                    this.EntityState = EntityStateEnum.Added;
            }
            else {
                if (v == null)
                    this.EntityState = EntityStateEnum.Unchanged;
                else
                    this.EntityState = EntityStateEnum.Added;
            }

            this._treatmentMaxQuantity = v;
        }
    }

    private _blockRequest?: boolean;
    public get BlockRequest(): boolean {
        return this._blockRequest;
    }
    public set BlockRequest(v: boolean) {
        if (this._blockRequest != v) {
            if (this._blockRequest !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._blockRequest = v;
        }
    }

    private _active?: boolean;
    public get Active(): boolean {
        return this._active;
    }
    public set Active(v: boolean) {
        if (this._active != v) {
            if (this._active !== undefined && this.EntityState != EntityStateEnum.Added && this.EntityState != EntityStateEnum.Deleted)
                this.EntityState = EntityStateEnum.Modified;
            this._active = v;
        }
    }
}
