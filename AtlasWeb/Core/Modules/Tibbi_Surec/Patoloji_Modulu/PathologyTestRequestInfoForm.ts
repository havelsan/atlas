//$2913899F
import { Component, Input, EventEmitter  } from '@angular/core';
import { PathologyTestRequestInfoFormViewModel } from './PathologyTestRequestInfoFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PathologyTestProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';


@Component({
    selector: 'PathologyTestRequestInfoForm',
    templateUrl: './PathologyTestRequestInfoForm.html',
    providers: [MessageService]
})
export class PathologyTestRequestInfoForm extends TTVisual.TTForm  {
    Description: TTVisual.ITTTextBox;
    labelDescription: TTVisual.ITTLabel;
    textDescriptionChange: EventEmitter<string> = new EventEmitter<string>();
    public pathologyTestRequestInfoFormViewModel: PathologyTestRequestInfoFormViewModel = new PathologyTestRequestInfoFormViewModel();
    public get _PathologyTestProcedure(): PathologyTestProcedure {
        return this._TTObject as PathologyTestProcedure;
    }
    private PathologyTestRequestInfoForm_DocumentUrl: string = '/api/PathologyTestProcedureService/PathologyTestRequestInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PATHOLOGYTESTPROCEDURE', 'PathologyTestRequestInfoForm');
        this._DocumentServiceUrl = this.PathologyTestRequestInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    @Input() procedureObjectList: Array<ProcedureDefinition>;


    private _pathologyTest: PathologyTestProcedure;
    @Input() set pathologyTest(value: PathologyTestProcedure) {
        this._pathologyTest = value;
        if (this.pathologyTest != null) {

            this.pathologyTestRequestInfoFormViewModel._PathologyTestProcedure = this.pathologyTest;

            let procedure = this.procedureObjectList.find(o => o.ObjectID.toString() === this.pathologyTest.ProcedureObject.toString());
            if (procedure != null) {
                this.pathologyTestRequestInfoFormViewModel.ProcedureName = procedure.Name;
            }
        }

    }
    get pathologyTest(): PathologyTestProcedure {
        return this._pathologyTest;
    }

    public get textDescription(): string {
        return this.pathologyTestRequestInfoFormViewModel.textDescription;
    }
    public set textDescription(s: string) {
        this.pathologyTestRequestInfoFormViewModel.textDescription = s;
        this.textDescriptionChange.emit(s);

    }

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PathologyTestProcedure();
        this.pathologyTestRequestInfoFormViewModel = new PathologyTestRequestInfoFormViewModel();
        this._ViewModel = this.pathologyTestRequestInfoFormViewModel;
        this.pathologyTestRequestInfoFormViewModel._PathologyTestProcedure = this._TTObject as PathologyTestProcedure;
    }

    //protected loadViewModel() {
    //    let that = this;
    //    that.pathologyTestRequestInfoFormViewModel = this._ViewModel as PathologyTestRequestInfoFormViewModel;
    //    that._TTObject = this.pathologyTestRequestInfoFormViewModel._PathologyTestProcedure;
    //    if (this.pathologyTestRequestInfoFormViewModel == null)
    //        this.pathologyTestRequestInfoFormViewModel = new PathologyTestRequestInfoFormViewModel();
    //    if (this.pathologyTestRequestInfoFormViewModel._PathologyTestProcedure == null)
    //        this.pathologyTestRequestInfoFormViewModel._PathologyTestProcedure = new PathologyTestProcedure();

    //}

    //async ngOnInit() {
    //    await this.load();
    //}

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._PathologyTestProcedure != null && this._PathologyTestProcedure.Description != event) {
                this._PathologyTestProcedure.Description = event;
                this.pathologyTestRequestInfoFormViewModel._PathologyTestProcedure.Description = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 1;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.Controls = [this.labelDescription, this.Description];

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



}
