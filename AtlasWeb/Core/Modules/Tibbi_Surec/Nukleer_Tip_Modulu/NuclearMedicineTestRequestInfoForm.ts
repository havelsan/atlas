//$2E5EE566
import { Component, Input, EventEmitter } from '@angular/core';
import { NuclearMedicineTestRequestInfoFormViewModel } from "./NuclearMedicineTestRequestInfoFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NuclearMedicineTest } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'NuclearMedicineTestRequestInfoForm',
    templateUrl: './NuclearMedicineTestRequestInfoForm.html',
    inputs: ['textDescription'],
    outputs: ['textDescriptionChange'],
    providers: [MessageService]
})
export class NuclearMedicineTestRequestInfoForm extends TTVisual.TTForm {
    GeneralDescription: TTVisual.ITTTextBox;
    PreDiagnosis: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    Emergency: TTVisual.ITTCheckBox;
    textDescriptionChange: EventEmitter<string> = new EventEmitter<string>();
    public nuclearMedicineTestRequestInfoFormViewModel: NuclearMedicineTestRequestInfoFormViewModel = new NuclearMedicineTestRequestInfoFormViewModel();
    public get _NuclearMedicineTest(): NuclearMedicineTest {
        return this._TTObject as NuclearMedicineTest;
    }
    private NuclearMedicineTestRequestInfoForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineTestRequestInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("NUCLEARMEDICINETEST", "NuclearMedicineTestRequestInfoForm");
        this._DocumentServiceUrl = this.NuclearMedicineTestRequestInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    @Input() procedureObjectList: Array<ProcedureDefinition>;
    @Input() clinicAnemnesis: string;

    public get textDescription(): string {
        return this.nuclearMedicineTestRequestInfoFormViewModel.textDescription;
    }
    public set textDescription(s: string) {
        this.nuclearMedicineTestRequestInfoFormViewModel.textDescription = s;
            this.textDescriptionChange.emit(s);

    }

    private _nuclearMedicineTest: NuclearMedicineTest;
    @Input() set nuclearMedicineTest(value: NuclearMedicineTest) {
        this._nuclearMedicineTest = value;
        if (this.nuclearMedicineTest != null)
        {
            this.nuclearMedicineTestRequestInfoFormViewModel._NuclearMedicineTest = this.nuclearMedicineTest;
            if(this.procedureObjectList != null){
                let procedure = this.procedureObjectList.find(o => o.ObjectID.toString() === this.nuclearMedicineTest.ProcedureObject.toString());
                if (procedure != null) {
                    this.nuclearMedicineTestRequestInfoFormViewModel.ProcedureCode = procedure.Code;
                    this.nuclearMedicineTestRequestInfoFormViewModel.ProcedureName = procedure.Name;
                }
            }            
        }

    }
    get nuclearMedicineTest(): NuclearMedicineTest {
        return this._nuclearMedicineTest;
    }




    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicineTest();
        this.nuclearMedicineTestRequestInfoFormViewModel = new NuclearMedicineTestRequestInfoFormViewModel();
        this._ViewModel = this.nuclearMedicineTestRequestInfoFormViewModel;
        this.nuclearMedicineTestRequestInfoFormViewModel._NuclearMedicineTest = this._TTObject as NuclearMedicineTest;
    }


    //async ngOnInit() {
    //}

    public async save() {

        try {
            let injector = ServiceLocator.Injector;
            let messageService: MessageService = injector.get(MessageService);
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let neResult = await httpService.postForNeResult(this._DocumentServiceUrl, this._ViewModel);
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

    public onGeneralDescriptionChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicineTest != null && this._NuclearMedicineTest.GeneralDescription != event) {
                this._NuclearMedicineTest.GeneralDescription = event;
                this.nuclearMedicineTestRequestInfoFormViewModel._NuclearMedicineTest.GeneralDescription = event;
            }
        }
    }

    public onPreDiagnosisChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicineTest.NuclearMedicine != null && this._NuclearMedicineTest.NuclearMedicine.PreDiagnosis != event) {
                this._NuclearMedicineTest.NuclearMedicine.PreDiagnosis = event;
                this.nuclearMedicineTestRequestInfoFormViewModel._NuclearMedicineTest.NuclearMedicine.PreDiagnosis = event;
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
        this.GeneralDescription.Name = "GeneralDescription";
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

        this.Controls = [this.ttlabel2, this.PreDiagnosis, this.GeneralDescription, this.ttlabel1, this.Emergency];

    }


}
