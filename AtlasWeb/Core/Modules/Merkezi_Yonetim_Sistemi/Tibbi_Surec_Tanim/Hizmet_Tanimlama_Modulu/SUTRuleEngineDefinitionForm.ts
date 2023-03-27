import { Component, OnInit, Input, AfterViewInit, ViewChild, ApplicationRef } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { SutRuleEngineDefinitionFormViewModel, Rule1DataSourceObject } from "./SutRuleEngineDefinitionFormViewModel";
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { EntityStateEnum } from "app/NebulaClient/Utils/Enums/EntityStateEnum";
import { listboxObject } from "app/Invoice/InvoiceHelperModel";
import { DxDataGridComponent } from "devextreme-angular";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";


@Component({
    selector: 'sut-engine-def-form',
    templateUrl: './SUTRuleEngineDefinitionForm.html',
    providers: [MessageService, SystemApiService]
})
export class SutRuleEngineDefinitionForm implements OnInit, AfterViewInit {

    @Input() set ProcedureDefInfo(propVal: any) {
        this._procedureDefInfo = propVal;
        if (this._procedureDefInfo != null)
            this.GetSUTRules();
        else {
            this._procedureDefInfo = null;
        }
    }
    get ProcedureDefInfo(): any {
        return this._procedureDefInfo;
    }

    @ViewChild('rule1Grid') rule1Grid: DxDataGridComponent;

    public _procedureDefInfo: any;
    public SpecialitySelection: TTVisual.ITTObjectListBox;
    public DiagnosisDefinition: TTVisual.ITTObjectListBox;
    public ProcedureDefinition: TTVisual.ITTObjectListBox;

    public selectedProcedureForRule1: any;
    public selectedSpecialityDefForRule2: any;
    public selectedDiagnosisDefForRule7: any;
    public selectedProcedureForRule16: any;

    public viewModel: SutRuleEngineDefinitionFormViewModel = new SutRuleEngineDefinitionFormViewModel();
    public genderDataSource = [
        {
            code: 'E',
            name: 'ERKEK'
        },
        {
            code: 'K',
            name: 'KADIN'
        }
    ];

    public rule1Columns = [
        {
            caption: 'Kod',
            dataType: 'string',
            dataField: 'ProcedureCode2',
            width: '75px'
        },
        {
            caption: 'Adı',
            dataType: 'string',
            dataField: 'ProcedureName2',
            minWidth: '150px'
        }
    ];

    public rule2Columns = [
        {
            caption: 'Kod',
            dataType: 'string',
            dataField: 'Code',
            width: '75px'
        },
        {
            caption: 'Adı',
            dataType: 'string',
            dataField: 'Name',
            minWidth: '150px'
        }
    ];

    public rule7Columns = [
        {
            caption: 'Kod',
            dataType: 'string',
            dataField: 'Code',
            width: '75px'
        },
        {
            caption: 'Adı',
            dataType: 'string',
            dataField: 'Name',
            minWidth: '150px'
        }
    ];

    public rule16Columns = [
        {
            caption: 'Kod',
            dataType: 'string',
            dataField: 'Code',
            width: '75px'
        },
        {
            caption: 'Adı',
            dataType: 'string',
            dataField: 'Name',
            minWidth: '150px'
        }
    ];

    constructor(private http: NeHttpService, private detector: ApplicationRef) {
        //this.viewModel = new SutRuleEngineDefinitionFormViewModel();
    }

    ngOnInit() {
        let that = this;
        this.http.get<SutRuleEngineDefinitionFormViewModel>('api/SUTRuleEngineApi/InitSUTRuleDefForm').then(res => {
            // that.SUTList = (<SutRuleEngineDefinitionFormViewModel>res).SUTList;
            // that.BranchList = (<SutRuleEngineDefinitionFormViewModel>res).BranchList;
            // that.ICD10List = (<SutRuleEngineDefinitionFormViewModel>res).ICD10List;
        });
    }

    ngAfterViewInit(): void {
        this.SpecialitySelection = new TTVisual.TTObjectListBox();
        this.SpecialitySelection.ListDefName = "SpecialityListDefinition";
        this.SpecialitySelection.Name = "SpecialitySelection";
        this.SpecialitySelection.AutoCompleteDialogWidth = "40%";

        this.ProcedureDefinition = new TTVisual.TTObjectListBox();
        this.ProcedureDefinition.ListDefName = "SUTListDefinitionForEngine";
        this.ProcedureDefinition.Name = "ProcedureDefinition";
        this.ProcedureDefinition.AutoCompleteDialogWidth = "40%";
        this.ProcedureDefinition.ListFilterExpression = "ISACTIVE = 1";

        this.DiagnosisDefinition = new TTVisual.TTObjectListBox();
        this.DiagnosisDefinition.ListDefName = "DiagnosisListDefinition";
        this.DiagnosisDefinition.Name = "DiagnosisDefinition";
        this.DiagnosisDefinition.ListFilterExpression = "ISLEAF=1";
        this.DiagnosisDefinition.AutoCompleteDialogWidth = "40%";
    }

    public GetSUTRules() {
        let that = this;
        this.http.post<SutRuleEngineDefinitionFormViewModel>('api/SUTRuleEngineApi/GetSUTRules?sutCode=' + this._procedureDefInfo.SUTCode, null, SutRuleEngineDefinitionFormViewModel).then(res => {
            that.viewModel = <SutRuleEngineDefinitionFormViewModel>res;
        });
    }

    public specialityDefintionSelectedChanged(event: any) {

        let that = this;
        if (event != null) {

            if (this.viewModel.RuleSetDTO.Rule2DTO.BranchCodesAndNames == null)
                this.viewModel.RuleSetDTO.Rule2DTO.BranchCodesAndNames = new Array<listboxObject>();

            if (this.viewModel.RuleSetDTO.Rule2DTO.BranchCodesAndNames.find(x => x.Code === event.Code))
                ServiceLocator.MessageService.showError("Bu Branş Kodu daha önce listeye eklenmiş.");
            else {
                let data = new listboxObject();
                data.Name = event.Name;
                data.Code = event.Code;
                data.ObjectID = event.ObjectID;
                this.viewModel.RuleSetDTO.Rule2DTO.BranchCodesAndNames.push(data);
                this.viewModel.RuleSetDTO.Rule2DTO.EntityState = EntityStateEnum.Added;

                window.setTimeout(t => {
                    if (that.selectedSpecialityDefForRule2 === null)
                        that.selectedSpecialityDefForRule2 = undefined;
                    else
                        that.selectedSpecialityDefForRule2 = null;
                    that.detector.tick();
                }, 0);
            }
        }
    }

    public diagnosisDefintionSelectedChanged(event: any) {

        let that = this;
        if (event != null) {

            if (this.viewModel.RuleSetDTO.Rule7DTO.Icd10ListAndNames == null)
                this.viewModel.RuleSetDTO.Rule7DTO.Icd10ListAndNames = new Array<listboxObject>();

            if (this.viewModel.RuleSetDTO.Rule7DTO.Icd10ListAndNames.find(x => x.Code === event.Code))
                ServiceLocator.MessageService.showError("Bu Tanı Kodu daha önce listeye eklenmiş.");
            else {
                let data = new listboxObject();
                data.Name = event.Name;
                data.Code = event.Code;
                data.ObjectID = event.ObjectID;
                this.viewModel.RuleSetDTO.Rule7DTO.Icd10ListAndNames.push(data);
                this.viewModel.RuleSetDTO.Rule7DTO.EntityState = EntityStateEnum.Added;

                window.setTimeout(t => {
                    if (that.selectedDiagnosisDefForRule7 === null)
                        that.selectedDiagnosisDefForRule7 = undefined;
                    else
                        that.selectedDiagnosisDefForRule7 = null;
                    that.detector.tick();
                }, 0);
            }
        }
    }

    public procDefintionChangedForRule1(event: any): void {

        let that = this;
        if (event != null) {
            if (this.viewModel.RuleSetDTO.Rule1DTO === null)
                this.viewModel.RuleSetDTO.Rule1DTO.Rule1DataSource = new Array<Rule1DataSourceObject>();

            if (this.viewModel.RuleSetDTO.Rule1DTO.Rule1DataSource.find(x => x.ProcedureCode2 === event.Code))
                ServiceLocator.MessageService.showError("Bu Hizmet daha önce listeye eklenmiş.");
            else {
                let data = new Rule1DataSourceObject();
                data.ProcedureCode2 = event.Kod;
                data.ProcedureName2 = event.Ad;
                data.EntityState = EntityStateEnum.Added;
                this.viewModel.RuleSetDTO.Rule1DTO.EntityState = EntityStateEnum.Added;
                this.viewModel.RuleSetDTO.Rule1DTO.Rule1DataSource.push(data);

                window.setTimeout(t => {
                    if (that.selectedProcedureForRule1 === null)
                        that.selectedProcedureForRule1 = undefined;
                    else
                        that.selectedProcedureForRule1 = null;
                    that.detector.tick();
                }, 0);
            }
        }
    }

    public procDefintionChangedForRule16(event: any): void {

        let that = this;
        if (event != null) {
            if (this.viewModel.RuleSetDTO.Rule16DTO.ProcedureNameAndCodes == null)
                this.viewModel.RuleSetDTO.Rule16DTO.ProcedureNameAndCodes = new Array<listboxObject>();

            if (this.viewModel.RuleSetDTO.Rule16DTO.ProcedureNameAndCodes.find(x => x == event.Code))
                ServiceLocator.MessageService.showError("Bu Hizmet daha önce listeye eklenmiş.");
            else {
                let data = new listboxObject();
                data.Name = event.Ad;
                data.Code = event.Kod;
                data.ObjectID = event.ObjectID;
                this.viewModel.RuleSetDTO.Rule16DTO.ProcedureNameAndCodes.push(data);
                this.viewModel.RuleSetDTO.Rule16DTO.EntityState = EntityStateEnum.Added;

                window.setTimeout(t => {
                    if (that.selectedProcedureForRule16 === null)
                        that.selectedProcedureForRule16 = undefined;
                    else
                        that.selectedProcedureForRule16 = null;
                    this.detector.tick();
                }, 0);
            }
        }
    }

    public onRule1Removing(event: any) {
        if (event.data.ObjectId != null) {
            event.data.EntityState = EntityStateEnum.Deleted;
            this.rule1Grid.instance.filter(['EntityState', '<>', 1]);
            this.rule1Grid.instance.refresh();
            this.viewModel.RuleSetDTO.Rule1DTO.EntityState = EntityStateEnum.Added;
            event.cancel = true;
        }
    }

    public onRule2Removed(event: any) {
        if (this.viewModel.RuleSetDTO.Rule2DTO.ObjectId != null && this.viewModel.RuleSetDTO.Rule2DTO.ObjectId.toString() != Guid.Empty.id) {
            if (this.viewModel.RuleSetDTO.Rule2DTO.BranchCodesAndNames.length == 0)
                this.viewModel.RuleSetDTO.Rule2DTO.EntityState = EntityStateEnum.Deleted;
            else
                this.viewModel.RuleSetDTO.Rule2DTO.EntityState = EntityStateEnum.Added;
        }
        else {
            if (this.viewModel.RuleSetDTO.Rule2DTO.BranchCodesAndNames.length > 0)
                this.viewModel.RuleSetDTO.Rule2DTO.EntityState = EntityStateEnum.Added;
            else
                this.viewModel.RuleSetDTO.Rule2DTO.EntityState = EntityStateEnum.Unchanged;
        }
    }

    // public onRule3QuantityChanged(event: any) {
    //     if (this.viewModel.RuleSetDTO.Rule3DTO.ObjectId != null && this.viewModel.RuleSetDTO.Rule3DTO.ObjectId.toString() != Guid.Empty.id) {
    //         if (event.value == null && this.viewModel.RuleSetDTO.Rule3DTO.NumOfDays == null)
    //             this.viewModel.RuleSetDTO.Rule3DTO.EntityState = EntityStateEnum.Deleted;
    //         else
    //             this.viewModel.RuleSetDTO.Rule3DTO.EntityState = EntityStateEnum.Added;
    //     }
    //     else {
    //         if (event.value == null)
    //             this.viewModel.RuleSetDTO.Rule3DTO.EntityState = EntityStateEnum.Unchanged;
    //         else
    //             this.viewModel.RuleSetDTO.Rule3DTO.EntityState = EntityStateEnum.Added;
    //     }
    // }

    // public onRule3NumOfDaysChanged(event: any) {
    //     if (this.viewModel.RuleSetDTO.Rule3DTO.ObjectId != null && this.viewModel.RuleSetDTO.Rule3DTO.ObjectId.toString() != Guid.Empty.id) {
    //         if (event.value == null && this.viewModel.RuleSetDTO.Rule3DTO.MaxQuantity == null)
    //             this.viewModel.RuleSetDTO.Rule3DTO.EntityState = EntityStateEnum.Deleted;
    //         else
    //             this.viewModel.RuleSetDTO.Rule3DTO.EntityState = EntityStateEnum.Added;
    //     }
    //     else {
    //         if (event.value == null)
    //             this.viewModel.RuleSetDTO.Rule3DTO.EntityState = EntityStateEnum.Unchanged;
    //         else
    //             this.viewModel.RuleSetDTO.Rule3DTO.EntityState = EntityStateEnum.Added;
    //     }
    // }

    // public onRule5MinAgeValueChanged(event: any) {
    //     if (event.value == null && this.viewModel.RuleSetDTO.Rule5DTO.MaxAge == null)
    //         this.viewModel.RuleSetDTO.Rule5DTO.EntityState = EntityStateEnum.Deleted;
    // }

    // public onRule5MaxAgeValueChanged(event: any) {
    //     if (event.value == null && this.viewModel.RuleSetDTO.Rule5DTO.MinAge == null)
    //         this.viewModel.RuleSetDTO.Rule5DTO.EntityState = EntityStateEnum.Deleted;
    //         else if (event.value == null && this.viewModel.RuleSetDTO.Rule5DTO.)

    // }

    public onRule7Removed(event: any) {
        if (this.viewModel.RuleSetDTO.Rule7DTO.ObjectId != null && this.viewModel.RuleSetDTO.Rule7DTO.ObjectId.toString() != Guid.Empty.id) {
            if (this.viewModel.RuleSetDTO.Rule7DTO.Icd10ListAndNames.length == 0)
                this.viewModel.RuleSetDTO.Rule7DTO.EntityState = EntityStateEnum.Deleted;
            else
                this.viewModel.RuleSetDTO.Rule7DTO.EntityState = EntityStateEnum.Added;
        }
        else {
            if (this.viewModel.RuleSetDTO.Rule7DTO.Icd10ListAndNames.length > 0)
                this.viewModel.RuleSetDTO.Rule7DTO.EntityState = EntityStateEnum.Added;
            else
                this.viewModel.RuleSetDTO.Rule7DTO.EntityState = EntityStateEnum.Unchanged;
        }
        // if (this.viewModel.RuleSetDTO.Rule7DTO.Icd10ListAndNames.length == 0)
        //     this.viewModel.RuleSetDTO.Rule7DTO.EntityState = EntityStateEnum.Deleted;
        // else
        //     this.viewModel.RuleSetDTO.Rule7DTO.EntityState = EntityStateEnum.Added;
    }

    public onRule16Removed(event: any) {
        if (this.viewModel.RuleSetDTO.Rule16DTO.ObjectId != null && this.viewModel.RuleSetDTO.Rule16DTO.ObjectId.toString() != Guid.Empty.id) {
            if (this.viewModel.RuleSetDTO.Rule16DTO.ProcedureNameAndCodes.length == 0)
                this.viewModel.RuleSetDTO.Rule16DTO.EntityState = EntityStateEnum.Deleted;
            else
                this.viewModel.RuleSetDTO.Rule16DTO.EntityState = EntityStateEnum.Added;
        }
        else {
            if (this.viewModel.RuleSetDTO.Rule16DTO.ProcedureNameAndCodes.length > 0)
                this.viewModel.RuleSetDTO.Rule16DTO.EntityState = EntityStateEnum.Added;
            else
                this.viewModel.RuleSetDTO.Rule16DTO.EntityState = EntityStateEnum.Unchanged;
        }
    }

    // public onRule17QuantityChanged(event: any) {
    //     if (this.viewModel.RuleSetDTO.Rule17DTO.LifeTimeMaxQuantity !== event.value) {
    //         if (this.viewModel.RuleSetDTO.Rule17DTO.ObjectId != null && this.viewModel.RuleSetDTO.Rule17DTO.ObjectId.toString() != Guid.Empty.id) {
    //             if (event.value == null)
    //                 this.viewModel.RuleSetDTO.Rule17DTO.EntityState = EntityStateEnum.Deleted;
    //             else
    //                 this.viewModel.RuleSetDTO.Rule17DTO.EntityState = EntityStateEnum.Added;
    //         }
    //         else {
    //             if (event.value == null)
    //                 this.viewModel.RuleSetDTO.Rule17DTO.EntityState = EntityStateEnum.Unchanged;
    //             else
    //                 this.viewModel.RuleSetDTO.Rule17DTO.EntityState = EntityStateEnum.Added;
    //         }
    //     }
    // }

    // public onRule18GenderValueChanged(event: any) {
    //     if (this.viewModel.RuleSetDTO.Rule18DTO.Gender !== event.value) {
    //         if (this.viewModel.RuleSetDTO.Rule18DTO.ObjectId != null && this.viewModel.RuleSetDTO.Rule18DTO.ObjectId.toString() != Guid.Empty.id) {
    //             if (event.value == null)
    //                 this.viewModel.RuleSetDTO.Rule18DTO.EntityState = EntityStateEnum.Deleted;
    //             else
    //                 this.viewModel.RuleSetDTO.Rule18DTO.EntityState = EntityStateEnum.Added;
    //         }
    //         else {
    //             if (event.value == null)
    //                 this.viewModel.RuleSetDTO.Rule18DTO.EntityState = EntityStateEnum.Unchanged;
    //             else
    //                 this.viewModel.RuleSetDTO.Rule18DTO.EntityState = EntityStateEnum.Added;
    //         }
    //     }
    // }

    // public onRule20QuantityChanged(event: any) {
    //     if (this.viewModel.RuleSetDTO.Rule20DTO.TreatmentMaxQuantity !== event.value) {
    //         if (this.viewModel.RuleSetDTO.Rule20DTO.ObjectId != null && this.viewModel.RuleSetDTO.Rule20DTO.ObjectId.toString() != Guid.Empty.id) {
    //             if (event.value == null)
    //                 this.viewModel.RuleSetDTO.Rule20DTO.EntityState = EntityStateEnum.Deleted;
    //             else
    //                 this.viewModel.RuleSetDTO.Rule20DTO.EntityState = EntityStateEnum.Added;
    //         }
    //         else {
    //             if (event.value == null)
    //                 this.viewModel.RuleSetDTO.Rule20DTO.EntityState = EntityStateEnum.Unchanged;
    //             else
    //                 this.viewModel.RuleSetDTO.Rule20DTO.EntityState = EntityStateEnum.Added;
    //         }
    //     }

    // }

    public saveSUTRules() {
        let that = this;
        if (!String.isNullOrEmpty(that.viewModel.SUTCode))
            this.http.post<SutRuleEngineDefinitionFormViewModel>('api/SUTRuleEngineApi/SaveSUTRules', that.viewModel, SutRuleEngineDefinitionFormViewModel).then(res => {
                this.viewModel = res;
                if (String.isNullOrEmpty(res.ErrorMessage))
                    ServiceLocator.MessageService.showSuccess('Değişiklikler başarılı bir şekilde kayıt edilmiştir.');
                else
                    ServiceLocator.MessageService.showError(res.ErrorMessage);
            }).catch(err => {
                ServiceLocator.MessageService.showError(err);
            });
        else
            ServiceLocator.MessageService.showError('Lütfen önce sol taraftan bir hizmet seçimi yapınız.');
    }
}