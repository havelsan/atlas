//$97D84CA8
import { Component, Input, EventEmitter } from '@angular/core';
import { PsychologyTestRequestInfoFormViewModel } from './PsychologyTestRequestInfoFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PsychologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { EpisodeAction } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";



@Component({
    selector: 'PsychologyTestRequestInfoForm',
    templateUrl: './PsychologyTestRequestInfoForm.html',
    providers: [MessageService]
})
export class PsychologyTestRequestInfoForm extends TTVisual.TTForm /*implements OnInit*/ {
    Description: TTVisual.ITTRichTextBoxControl;
    ProcedureByUserEpisodeAction: TTVisual.ITTObjectListBox;
    labelDescription: TTVisual.ITTLabel;
    textDescriptionChange: EventEmitter<string> = new EventEmitter<string>();

    public psychologyTestRequestInfoFormViewModel: PsychologyTestRequestInfoFormViewModel = new PsychologyTestRequestInfoFormViewModel();
    public get _PsychologyTest(): PsychologyTest {
        return this._TTObject as PsychologyTest;
    }
    private PsychologyTestRequestInfoForm_DocumentUrl: string = '/api/PsychologyTestService/PsychologyTestRequestInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PSYCHOLOGYTEST', 'PsychologyTestRequestInfoForm');
        this._DocumentServiceUrl = this.PsychologyTestRequestInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    @Input() procedureObjectList: Array<ProcedureDefinition>;


    private _psychologyTest: PsychologyTest;
    @Input() set psychologyTest(value: PsychologyTest) {
        this._psychologyTest = value;
        if (this.psychologyTest != null) {
            this.psychologyTestRequestInfoFormViewModel._PsychologyTest = this.psychologyTest;
            if (this.procedureObjectList != null) {
                let procedure = this.procedureObjectList.find(o => o.ObjectID.toString() === this.psychologyTest.ProcedureObject.toString());
                if (procedure != null) {
                    this.psychologyTestRequestInfoFormViewModel.ProcedureName = procedure.Name;
                }
            }
        }
    }
    get psychologyTest(): PsychologyTest {
        return this._psychologyTest;
    }

    public async save() {
        try {


            let injector = ServiceLocator.Injector;
            let messageService: MessageService = injector.get(MessageService);
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let neResult = await httpService.postForNeResult(this._DocumentServiceUrl, this._ViewModel);
            //this.showSaveSuccessMessage();
            if (neResult != null) {
                if (neResult.InfoMessage != null) {
                    messageService.showInfo(neResult.InfoMessage);
                }
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }


    }

    public get textDescription(): string {
        return this.psychologyTestRequestInfoFormViewModel.textDescription;
    }
    public set textDescription(s: string) {
        this.psychologyTestRequestInfoFormViewModel.textDescription = s;
        this.textDescriptionChange.emit(s);

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PsychologyTest();
        this.psychologyTestRequestInfoFormViewModel = new PsychologyTestRequestInfoFormViewModel();
        this._ViewModel = this.psychologyTestRequestInfoFormViewModel;
        this.psychologyTestRequestInfoFormViewModel._PsychologyTest = this._TTObject as PsychologyTest;
        this.psychologyTestRequestInfoFormViewModel._PsychologyTest.EpisodeAction = new EpisodeAction();
        this.psychologyTestRequestInfoFormViewModel._PsychologyTest.EpisodeAction.ProcedureByUser = new ResUser();
    }

    //protected loadViewModel() {
    //    let that = this;
    //
    //    that.psychologyTestRequestInfoFormViewModel = this._ViewModel as PsychologyTestRequestInfoFormViewModel;
    //    that._TTObject = this.psychologyTestRequestInfoFormViewModel._PsychologyTest;
    //    if (this.psychologyTestRequestInfoFormViewModel == null)
    //        this.psychologyTestRequestInfoFormViewModel = new PsychologyTestRequestInfoFormViewModel();
    //    if (this.psychologyTestRequestInfoFormViewModel._PsychologyTest == null)
    //        this.psychologyTestRequestInfoFormViewModel._PsychologyTest = new PsychologyTest();

    //}

    //async ngOnInit() {
    //    await this.load();
    //}

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._PsychologyTest != null && this._PsychologyTest.Description != event) {
                this._PsychologyTest.Description = event;
                this.psychologyTestRequestInfoFormViewModel._PsychologyTest.Description = event;

            }
        }
    }

    public onProcedureByUserEpisodeActionChanged(event): void {
        if (event != null) {
            if (this._PsychologyTest != null &&
                this._PsychologyTest.EpisodeAction != null && this._PsychologyTest.EpisodeAction.ProcedureByUser != event) {
                this._PsychologyTest.EpisodeAction.ProcedureByUser = event;
                this._PsychologyTest.ProcedureByUser = event;
                this.psychologyTestRequestInfoFormViewModel._PsychologyTest.ProcedureByUser = event;
                // this.psychologyTestRequestInfoFormViewModel._PsychologyTest.EpisodeAction.ProcedureDoctor = event;

            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.Description, "Rtf", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 1;

        this.Description = new TTVisual.TTRichTextBoxControl();
        this.Description.Name = "Description";
        this.Description.Required = true;
        this.Description.TabIndex = 0;

        this.ProcedureByUserEpisodeAction = new TTVisual.TTObjectListBox();
        this.ProcedureByUserEpisodeAction.ListDefName = "PsychologistList";
        this.ProcedureByUserEpisodeAction.Name = "ProcedureByUserEpisodeAction";
        this.ProcedureByUserEpisodeAction.TabIndex = 2;
        this.ProcedureByUserEpisodeAction.Required = true;
        this.Controls = [this.labelDescription, this.Description, this.ProcedureByUserEpisodeAction];

    }


}
