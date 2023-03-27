//$55EAA026
import { Component, OnInit, NgZone } from '@angular/core';
import { OldVisitDetailsFormViewModel } from './OldVisitDetailsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ChildGrowthVisits } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldVisitDetailsForm',
    templateUrl: './OldVisitDetailsForm.html',
    providers: [MessageService]
})
export class OldVisitDetailsForm extends TTVisual.TTForm implements OnInit {
    SittingWoSupportCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    IsSystemMessage: TTVisual.ITTCheckBox;
    SittingWoSupport1MotorDevelopment: TTVisual.ITTCheckBox;
    SittingWoSupport2MotorDevelopment: TTVisual.ITTCheckBox;
    StandingWAssistanceCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    StandingWAssistance2MotorDevelopment: TTVisual.ITTCheckBox;
    StandingWAssistance3MotorDevelopment: TTVisual.ITTCheckBox;
    StandingWAssistance1MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistanceCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistance1MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistance3MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistance4MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingWAssistance2MotorDevelopment: TTVisual.ITTCheckBox;
    StandingAloneCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    StandingAlone2MotorDevelopment: TTVisual.ITTCheckBox;
    StandingAlone3MotorDevelopment: TTVisual.ITTCheckBox;
    StandingAlone4MotorDevelopment: TTVisual.ITTCheckBox;
    StandingAlone1MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingAloneCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    WalkingAlone1MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingAlone3MotorDevelopment: TTVisual.ITTCheckBox;
    WalkingAlone2MotorDevelopment: TTVisual.ITTCheckBox;
    CrawlingCheckAllMotorDevelopment: TTVisual.ITTCheckBox;
    Crawling2MotorDevelopment: TTVisual.ITTCheckBox;
    Crawling3MotorDevelopment: TTVisual.ITTCheckBox;
    Crawling1MotorDevelopment: TTVisual.ITTCheckBox;

    public oldVisitDetailsFormViewModel: OldVisitDetailsFormViewModel = new OldVisitDetailsFormViewModel();
    public get _ChildGrowthVisits(): ChildGrowthVisits {
        return this._TTObject as ChildGrowthVisits;
    }
    private OldVisitDetailsForm_DocumentUrl: string = '/api/ChildGrowthVisitsService/OldVisitDetailsForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('CHILDGROWTHVISITS', 'OldVisitDetailsForm');
        this._DocumentServiceUrl = this.OldVisitDetailsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChildGrowthVisits();
        this.oldVisitDetailsFormViewModel = new OldVisitDetailsFormViewModel();
        this._ViewModel = this.oldVisitDetailsFormViewModel;
        this.oldVisitDetailsFormViewModel._ChildGrowthVisits = this._TTObject as ChildGrowthVisits;
    }

    protected loadViewModel() {
        let that = this;

        that.oldVisitDetailsFormViewModel = this._ViewModel as OldVisitDetailsFormViewModel;
        that._TTObject = this.oldVisitDetailsFormViewModel._ChildGrowthVisits;
        if (this.oldVisitDetailsFormViewModel == null)
            this.oldVisitDetailsFormViewModel = new OldVisitDetailsFormViewModel();
        if (this.oldVisitDetailsFormViewModel._ChildGrowthVisits == null)
            this.oldVisitDetailsFormViewModel._ChildGrowthVisits = new ChildGrowthVisits();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldVisitDetailsFormViewModel);
  
    }

    onSittingWoSupportCheckAllChange(e: any) {

    }
    onWalkingAloneCheckAllChange(e: any) {

    }
    onCrawlingCheckAllChange(e: any) {

    }

    onSittingWoSupport1MotorDevelopmentChanged(e: any) {

    }
    onSittingWoSupport2MotorDevelopmentChanged(e: any) {

    }
    onStandingWAssistanceCheckAllChange(e: any) {

    }
    onStandingWAssistance2MotorDevelopmentChanged(e: any) {

    }
    onStandingWAssistance3MotorDevelopmentChanged(e: any) {

    }
    onStandingWAssistance1MotorDevelopmentChanged(e: any) {

    }
    onWalkingWAssistanceCheckAllChange(e: any) {

    }
    onWalkingWAssistance1MotorDevelopmentChanged(e: any) {

    }
    onWalkingWAssistance3MotorDevelopmentChanged(e: any) {

    }
    onWalkingWAssistance4MotorDevelopmentChanged(e: any) {

    }
    onWalkingWAssistance2MotorDevelopmentChanged(e: any) {

    }
    onStandingAloneCheckAllChange(e: any) {

    }
    onStandingAlone2MotorDevelopmentChanged(e: any) {

    }
    onStandingAlone3MotorDevelopmentChanged(e: any) {

    }
    onStandingAlone4MotorDevelopmentChanged(e: any) {

    }
    onStandingAlone1MotorDevelopmentChanged(e: any) {

    }
    onWalkingAlone1MotorDevelopmentChanged(e: any) {

    }
    onWalkingAlone3MotorDevelopmentChanged(e: any) {

    }
    onWalkingAlone2MotorDevelopmentChanged(e: any) {

    }
    onCrawling2MotorDevelopmentChanged(e: any) {

    }
    onCrawling3MotorDevelopmentChanged(e: any) {

    }
    onCrawling1MotorDevelopmentChanged(e: any) {

    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
