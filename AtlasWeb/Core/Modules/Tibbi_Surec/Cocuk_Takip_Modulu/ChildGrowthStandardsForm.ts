//$F0FEDB23
import { Component, OnInit } from '@angular/core';
import { ChildGrowthStandardsFormViewModel } from './ChildGrowthStandardsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ChildGrowthStandards } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityBasedObjectForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm";

import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { VisitDetailsComponentInfoViewModel } from './VisitDetailsFormViewModel';
import { VisitDetailsForm } from './VisitDetailsForm';
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';

@Component({
    selector: 'ChildGrowthStandardsForm',
    templateUrl: './ChildGrowthStandardsForm.html',
    providers: [MessageService, NqlQueryService]
})
export class ChildGrowthStandardsForm extends SpecialityBasedObjectForm implements OnInit {
    public childGrowthStandardsFormViewModel: ChildGrowthStandardsFormViewModel = new ChildGrowthStandardsFormViewModel();
    public get _ChildGrowthStandards(): ChildGrowthStandards {
        return this._TTObject as ChildGrowthStandards;
    }
    private ChildGrowthStandardsForm_DocumentUrl: string = '/api/ChildGrowthStandardsService/ChildGrowthStandardsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.ChildGrowthStandardsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChildGrowthStandards();
        this.childGrowthStandardsFormViewModel = new ChildGrowthStandardsFormViewModel();
        this._ViewModel = this.childGrowthStandardsFormViewModel;
        this.childGrowthStandardsFormViewModel._ChildGrowthStandards = this._TTObject as ChildGrowthStandards;
    }

    protected loadViewModel() {
        let that = this;
        that.childGrowthStandardsFormViewModel = this._ViewModel as ChildGrowthStandardsFormViewModel;
        that._TTObject = this.childGrowthStandardsFormViewModel._ChildGrowthStandards;
        if (this.childGrowthStandardsFormViewModel == null)
            this.childGrowthStandardsFormViewModel = new ChildGrowthStandardsFormViewModel();
        if (this.childGrowthStandardsFormViewModel._ChildGrowthStandards == null)
            this.childGrowthStandardsFormViewModel._ChildGrowthStandards = new ChildGrowthStandards();

    }

    async ngOnInit() {
        await this.load(ChildGrowthStandardsFormViewModel);
    }

    protected AddAuditObjectID() {
        super.AddAuditObjectID(false);
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }

    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.getComponentInfo();
    }

    public savevisitComponent: boolean = true;
    public visitsComponentInfo: DynamicComponentInfo;
    public visitsQueryParameters: QueryParams;

    protected getComponentInfo() {
        let componentInfoViewModel: VisitDetailsComponentInfoViewModel = VisitDetailsForm.getComponentInfoViewModel(this.childGrowthStandardsFormViewModel._PatientID);
        this.visitsQueryParameters = componentInfoViewModel.visitQueryParameters;
        this.visitsComponentInfo = componentInfoViewModel.visitComponentInfo;

    }

    componentQueryResultLoaded(e: any) {
        VisitDetailsForm.queryResultLoaded(e);
    }

}
