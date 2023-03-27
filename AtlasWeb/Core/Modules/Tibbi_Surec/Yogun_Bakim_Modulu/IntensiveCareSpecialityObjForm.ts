//$A1B13C75
import { Component, OnInit, Output, EventEmitter, ViewChild, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { IntensiveCareSpecialityObjFormViewModel } from './IntensiveCareSpecialityObjFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { IntensiveCareSpecialityObj, EpisodeAction, IntensiveCareTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityBasedObjectForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm";
import { SKRSDurum } from 'NebulaClient/Model/AtlasClientModel';

import { Guid } from "NebulaClient/Mscorlib/Guid";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

//<atlas-form-editor  için
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { NewBornIntensiveCareComponentInfoViewModel } from './NewBornIntensiveCareFormViewModel';
import { NewBornIntensiveCareForm } from './NewBornIntensiveCareForm';
//

@Component({
    selector: 'IntensiveCareSpecialityObjForm',
    templateUrl: './IntensiveCareSpecialityObjForm.html',
    providers: [MessageService]
})
export class IntensiveCareSpecialityObjForm extends SpecialityBasedObjectForm implements OnInit {//Uzmanlık için uzmanlıktan kalıtım alındı
    ttpanel1: TTVisual.ITTPanel;
    IntensiveCareStep: TTVisual.ITTEnumComboBox;
    labelIntensiveCareStep: TTVisual.ITTLabel;
    labelSepsisStatus: TTVisual.ITTLabel;
    labelSepticShock: TTVisual.ITTLabel;
    SepsisStatus: TTVisual.ITTObjectListBox;
    SepticShock: TTVisual.ITTObjectListBox;
    public intensiveCareSpecialityObjFormViewModel: IntensiveCareSpecialityObjFormViewModel = new IntensiveCareSpecialityObjFormViewModel();
    public get _IntensiveCareSpecialityObj(): IntensiveCareSpecialityObj {
        return this._TTObject as IntensiveCareSpecialityObj;
    }
    private IntensiveCareSpecialityObjForm_DocumentUrl: string = '/api/IntensiveCareSpecialityObjService/IntensiveCareSpecialityObjForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected systemApiService: SystemApiService) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.IntensiveCareSpecialityObjForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    protected async PreScript(): Promise<void> {
        super.PreScript();

        let componentInfoViewModel: NewBornIntensiveCareComponentInfoViewModel;
        componentInfoViewModel = NewBornIntensiveCareForm.getComponentInfoViewModel(this.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj, this.intensiveCareSpecialityObjFormViewModel.newbornIntensiveObjectId);
        this.NewBornIntensiveCareQueryParameters = componentInfoViewModel.NewBornIntensiveCareQueryParameters;
        this.NewBornIntensiveCareComponentInfo = componentInfoViewModel.NewBornIntensiveCareComponentInfo;
    }

    isIntensiveCareStepChanged: boolean = false;//IntensiveCareStep objesi dış bir modülden değiştirildi mi?false ise onIntensiveCareStepChanged içerisinde klinik işlemleri açılacak; true ise açılmayacak.
    showInPatientTreatmentClinic: boolean = false;

    openDynamicComponent(objectDefName: any, objectID?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, null, new DynamicComponentInputParam(inputparam, new ActiveIDsModel(this.intensiveCareSpecialityObjFormViewModel.episodeActionId, this.intensiveCareSpecialityObjFormViewModel.episodeId, this.intensiveCareSpecialityObjFormViewModel.patientId))).then(x => {
            });
        } else {
            this.systemApiService.new(objectDefName, null, null, new DynamicComponentInputParam(inputparam, new ActiveIDsModel(this.intensiveCareSpecialityObjFormViewModel.episodeActionId, this.intensiveCareSpecialityObjFormViewModel.episodeId, this.intensiveCareSpecialityObjFormViewModel.patientId))).then(c => {
            });
        }
    }

    InPatientTreatmentClinicActionExecuted(value: any) {
        let that = this;
        let urlString: string = '/api/IntensiveCareSpecialityObjService/GetIntensiveCareStep?InPatientTreatmentClinicObjectId=' + this.intensiveCareSpecialityObjFormViewModel.InPatientTreatmentClinicObjectId + '&InPatientTreatmentClinicObjectDef=' + this.intensiveCareSpecialityObjFormViewModel.InPatientTreatmentClinicObjectDef;
        that.httpService.get<any>(urlString)
            .then(response => {
                let result = response;
                if (result != 4) {//4 ise yanlış işlem yapılmış
                    this.isIntensiveCareStepChanged = true;
                    this.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj.IntensiveCareStep = result;
                    this._IntensiveCareSpecialityObj.IntensiveCareStep = result;
                    this.isIntensiveCareStepChanged = false;
                    this.showInPatientTreatmentClinic = false;
                }
            })
            .catch(error => {
                console.log(error);
            });
    }


    public NewBornIntensiveCareComponentInfo: DynamicComponentInfo;
    public NewBornIntensiveCareQueryParameters: QueryParams;
    newBornIntensiveCareQueryResultLoaded(e: any) {
        NewBornIntensiveCareForm.newBornIntensiveCareQueryResultLoaded(e);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new IntensiveCareSpecialityObj();
        this.intensiveCareSpecialityObjFormViewModel = new IntensiveCareSpecialityObjFormViewModel();
        this._ViewModel = this.intensiveCareSpecialityObjFormViewModel;
        this.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj = this._TTObject as IntensiveCareSpecialityObj;
        this.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj.SepticShock = new SKRSDurum();
        this.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj.SepsisStatus = new SKRSDurum();
    }

    protected loadViewModel() {
        let that = this;
        that.intensiveCareSpecialityObjFormViewModel = this._ViewModel as IntensiveCareSpecialityObjFormViewModel;
        that._TTObject = this.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj;
        if (this.intensiveCareSpecialityObjFormViewModel == null)
            this.intensiveCareSpecialityObjFormViewModel = new IntensiveCareSpecialityObjFormViewModel();
        if (this.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj == null)
            this.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj = new IntensiveCareSpecialityObj();
        let septicShockObjectID = that.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj["SepticShock"];
        if (septicShockObjectID != null && (typeof septicShockObjectID === "string")) {
            let septicShock = that.intensiveCareSpecialityObjFormViewModel.SKRSDurums.find(o => o.ObjectID.toString() === septicShockObjectID.toString());
            if (septicShock) {
                that.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj.SepticShock = septicShock;
            }
        }

        let sepsisStatusObjectID = that.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj["SepsisStatus"];
        if (sepsisStatusObjectID != null && (typeof sepsisStatusObjectID === "string")) {
            let sepsisStatus = that.intensiveCareSpecialityObjFormViewModel.SKRSDurums.find(o => o.ObjectID.toString() === sepsisStatusObjectID.toString());
            if (sepsisStatus) {
                that.intensiveCareSpecialityObjFormViewModel._IntensiveCareSpecialityObj.SepsisStatus = sepsisStatus;
            }
        }

    }

    async ngOnInit() {
        await this.load(IntensiveCareSpecialityObjFormViewModel);
    }

    public onIntensiveCareStepChanged(event): void {
        if (this._IntensiveCareSpecialityObj != null && this._IntensiveCareSpecialityObj.IntensiveCareStep != event) {

            this._IntensiveCareSpecialityObj.IntensiveCareStep = event;

            if (this.isIntensiveCareStepChanged == false) {
                this.showInPatientTreatmentClinic = true;
                this.openDynamicComponent(this.intensiveCareSpecialityObjFormViewModel.InPatientTreatmentClinicObjectDef, this.intensiveCareSpecialityObjFormViewModel.InPatientTreatmentClinicObjectId)
            }
        }
    }

    public onSepsisStatusChanged(event): void {
        if (this._IntensiveCareSpecialityObj != null && this._IntensiveCareSpecialityObj.SepsisStatus != event) {
            this._IntensiveCareSpecialityObj.SepsisStatus = event;
        }
    }

    public onSepticShockChanged(event): void {
        if (this._IntensiveCareSpecialityObj != null && this._IntensiveCareSpecialityObj.SepticShock != event) {
            this._IntensiveCareSpecialityObj.SepticShock = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.IntensiveCareStep, "Value", this.__ttObject, "IntensiveCareStep");
    }

    public initFormControls(): void {
        this.labelSepticShock = new TTVisual.TTLabel();
        this.labelSepticShock.Text = "Septik Şok";
        this.labelSepticShock.Name = "labelSepticShock";
        this.labelSepticShock.TabIndex = 5;

        this.SepticShock = new TTVisual.TTObjectListBox();
        this.SepticShock.ListDefName = "SKRSDurumList";
        this.SepticShock.Name = "SepticShock";
        this.SepticShock.TabIndex = 4;
        this.SepticShock.Required = true;

        this.labelSepsisStatus = new TTVisual.TTLabel();
        this.labelSepsisStatus.Text = "Sepsis Durumu";
        this.labelSepsisStatus.Name = "labelSepsisStatus";
        this.labelSepsisStatus.TabIndex = 3;

        this.SepsisStatus = new TTVisual.TTObjectListBox();
        this.SepsisStatus.ListDefName = "SKRSDurumList";
        this.SepsisStatus.Name = "SepsisStatus";
        this.SepsisStatus.TabIndex = 2;
        this.SepsisStatus.Required = true;

        this.labelIntensiveCareStep = new TTVisual.TTLabel();
        this.labelIntensiveCareStep.Text = "Basamak Bilgisi";
        this.labelIntensiveCareStep.Name = "labelIntensiveCareStep";
        this.labelIntensiveCareStep.TabIndex = 1;

        this.IntensiveCareStep = new TTVisual.TTEnumComboBox();
        this.IntensiveCareStep.DataTypeName = "IntensiveCareStepEnum";
        this.IntensiveCareStep.Name = "IntensiveCareStep";
        this.IntensiveCareStep.TabIndex = 0;

        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 0;

        this.Controls = [this.ttpanel1, this.labelSepticShock, this.SepticShock, this.labelSepsisStatus, this.SepsisStatus, this.labelIntensiveCareStep, this.IntensiveCareStep];

    }

    //
    @Output() multipleDataComponentSavedEventEmitter: EventEmitter<Guid> = new EventEmitter<Guid>();

    public multipleDataComponentSaved(event: any) {
        //this.multipleDataComponentSavedEventEmitter.emit(event); NIDA BAK �ALI�ACAK MI
    }



}
