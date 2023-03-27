//$2E5EE566
import { Component, Input, EventEmitter, AfterViewInit } from '@angular/core';
import { RadiologyTestRequestInfoFormViewModel } from "./RadiologyTestRequestInfoFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';


import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { RadiologyTest, RadiologyTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';




@Component({
    selector: 'RadiologyTestRequestInfoForm',
    templateUrl: './RadiologyTestRequestInfoForm.html',
    inputs: ['textDescription'],
    outputs: ['textDescriptionChange'],
    providers: [MessageService]
})
export class RadiologyTestRequestInfoForm extends TTVisual.TTForm implements AfterViewInit{
    
    GeneralDescription: TTVisual.ITTTextBox;
    PreDiagnosis: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ContrastType: TTVisual.ITTEnumComboBox;
    Emergency: TTVisual.ITTCheckBox;
    textDescriptionChange: EventEmitter<string> = new EventEmitter<string>();
    public radiologyTestRequestInfoFormViewModel: RadiologyTestRequestInfoFormViewModel = new RadiologyTestRequestInfoFormViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    public showCOntrastType = false;    

    private RadiologyTestRequestInfoForm_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestRequestInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("RADIOLOGYTEST", "RadiologyTestRequestInfoForm");
        this._DocumentServiceUrl = this.RadiologyTestRequestInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    ngAfterViewInit(): void {
        if (this.radiologyTest != null)
        {
            this.radiologyTestRequestInfoFormViewModel._RadiologyTest = this.radiologyTest;
            this.radiologyTestRequestInfoFormViewModel._RadiologyTest.PreDiagnosis = this.clinicAnemnesis;

            let procedure = this.procedureObjectList.find(o => o.ObjectID.toString() === this.radiologyTest.ProcedureObject.toString());
            if (procedure != null) {
                this.radiologyTestRequestInfoFormViewModel.ProcedureCode = procedure.Code;
                this.radiologyTestRequestInfoFormViewModel.ProcedureName = procedure.Name;      
                
                let type = this.testdefinitionList.find(o => o.ObjectID.toString() === procedure["TestType"].toString());

                if(type != null && (type.Name == "MR" || type.Name == "BT"))
                    this.showCOntrastType = true;
                else
                    this.showCOntrastType = false;

            }
        }
    }

    //@Input() requestedProcedure: vmRequiredInfoFormProcedure;
    @Input() procedureObjectList: Array<ProcedureDefinition>;
    @Input() testdefinitionList: Array<RadiologyTestDefinition>;
    @Input() clinicAnemnesis: string;

    public get textDescription(): string {
        return this.radiologyTestRequestInfoFormViewModel.textDescription;
    }
    public set textDescription(s: string) {
            this.radiologyTestRequestInfoFormViewModel.textDescription = s;
            this.textDescriptionChange.emit(s);

    }

    private _radiologyTest: RadiologyTest;
    @Input() set radiologyTest(value: RadiologyTest) {
        this._radiologyTest = value;
    }
    get radiologyTest(): RadiologyTest {
        return this._radiologyTest;
    }




    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestRequestInfoFormViewModel = new RadiologyTestRequestInfoFormViewModel();
        this._ViewModel = this.radiologyTestRequestInfoFormViewModel;
        this.radiologyTestRequestInfoFormViewModel._RadiologyTest = this._TTObject as RadiologyTest;
    }


    //async ngOnInit() {
    //}

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

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.GeneralDescription != event) {
                this._RadiologyTest.GeneralDescription = event;
                this.radiologyTestRequestInfoFormViewModel._RadiologyTest.GeneralDescription = event;
            }
        }
    }

    public onContrastTypeChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ContrastType != event) {
                this._RadiologyTest.ContrastType = event;
                this.radiologyTestRequestInfoFormViewModel._RadiologyTest.ContrastType = event;
            }
        }
    }

    public onPreDiagnosisChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.PreDiagnosis != event) {
                this._RadiologyTest.PreDiagnosis = event;
                this.radiologyTestRequestInfoFormViewModel._RadiologyTest.PreDiagnosis = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PreDiagnosis, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.GeneralDescription, "Text", this.__ttObject, "GeneralDescription");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
    }

    public initFormControls(): void {
        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 17;

        this.PreDiagnosis = new TTVisual.TTTextBox();
        this.PreDiagnosis.Multiline = true;
        this.PreDiagnosis.Name = "PreDiagnosis";
        this.PreDiagnosis.TabIndex = 14;

        this.GeneralDescription = new TTVisual.TTTextBox();
        this.GeneralDescription.Multiline = true;
        this.GeneralDescription.Name = "Description";
        this.GeneralDescription.TabIndex = 14;
        this.GeneralDescription.Required = true;
        this.GeneralDescription.Height = "100px";


        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = "Acil";
        this.Emergency.Title = "Acil";
        this.Emergency.Name = "Acil";
        this.Emergency.TabIndex = 81;

        this.ContrastType = new TTVisual.TTEnumComboBox();
        this.ContrastType.DataTypeName = "RadiologyContrastTypeEnum";
        this.ContrastType.Name = "ContrastType";
        this.ContrastType.TabIndex = 81;

        this.Controls = [this.ttlabel2, this.PreDiagnosis, this.GeneralDescription, this.ttlabel1, this.Emergency,this.ContrastType];

    }


}
