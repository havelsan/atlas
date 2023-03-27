//$368A2ADF
import { Component, OnInit, NgZone } from '@angular/core';
import { HemodialysisRequestFormViewModel } from './HemodialysisRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { HemodialysisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicSidebarMenuItem } from '../../../wwwroot/app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { EpisodeActionForm } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm';
import { ISidebarMenuService } from '../../../wwwroot/app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from '../../../wwwroot/app/Fw/Services/HelpMenuService';


@Component({
    selector: 'HemodialysisRequestForm',
    templateUrl: './HemodialysisRequestForm.html',
    providers: [MessageService]
})
export class HemodialysisRequestForm extends EpisodeActionForm implements OnInit {
    public hemodialysisRequestFormViewModel: HemodialysisRequestFormViewModel = new HemodialysisRequestFormViewModel();
    public get _HemodialysisRequest(): HemodialysisRequest {
        return this._TTObject as HemodialysisRequest;
    }
    private HemodialysisRequestForm_DocumentUrl: string = '/api/HemodialysisRequestService/HemodialysisRequestForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone,
        private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.HemodialysisRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        super.PreScript();
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let openObstetric = new DynamicSidebarMenuItem();
        openObstetric.key = 'openHemodialysisInstruction';
        openObstetric.icon = 'fa fa-list';
        openObstetric.label = "Eðitim Bilgileri";
        openObstetric.componentInstance = this.helpMenuService;
        openObstetric.clickFunction = this.helpMenuService.openHemodialysisInstruction;
        openObstetric.parameterFunctionInstance = this;
        openObstetric.getParamsFunction = this.getClickFunctionParams;
        openObstetric.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', openObstetric);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('openHemodialysisInstruction');
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HemodialysisRequest();
        this.hemodialysisRequestFormViewModel = new HemodialysisRequestFormViewModel();
        this._ViewModel = this.hemodialysisRequestFormViewModel;
        this.hemodialysisRequestFormViewModel._HemodialysisRequest = this._TTObject as HemodialysisRequest;
    }

    protected loadViewModel() {
        let that = this;
        that.hemodialysisRequestFormViewModel = this._ViewModel as HemodialysisRequestFormViewModel;
        that._TTObject = this.hemodialysisRequestFormViewModel._HemodialysisRequest;
        if (this.hemodialysisRequestFormViewModel == null)
            this.hemodialysisRequestFormViewModel = new HemodialysisRequestFormViewModel();
        if (this.hemodialysisRequestFormViewModel._HemodialysisRequest == null)
            this.hemodialysisRequestFormViewModel._HemodialysisRequest = new HemodialysisRequest();

    }

    async ngOnInit() {
        await this.load();
        this.AddHelpMenu();
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
