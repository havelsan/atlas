import { Component, EventEmitter, Input, OnInit, Output, AfterViewInit, ViewChild } from '@angular/core';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { PrismService } from 'app/Formio/prism/Prism.service';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DynamicFormDesignerComponent } from './dynamic-form-designer.component';
import { ODataBuilder } from 'app/ODataEditor/Models/ODataObject';
import { environment } from 'app/environments/environment';
import { DxCheckBoxComponent } from 'devextreme-angular';

@Component({

    selector: 'hvl-dynamic-form',
    templateUrl: 'HvlDynamicForm.html',
})
export class HvlDynamicForm implements OnInit, AfterViewInit {


    constructor(private httpService: NeHttpService, public prism: PrismService) {

    }

    @Input() ReadOnly: boolean = false;
    @Input() Code: string;
    @Input() Mode: number;
    @Input() SubmissionID: string;
    @Input() ShowGrid: boolean = false;
    historySelected: string = "";

    @ViewChild('submissionAction')
    submissionAction: DxCheckBoxComponent;

    reload: boolean = true;

    readOnlyHistoryItem: boolean = false;

    submission: any = {};

    public _Parameters: any;
    @Input() set Parameters(value: any) {
        this._Parameters = value;

    }
    get Parameters(): any {
        return this._Parameters;
    }

    dynamicForm: DynamicFormDto;
    dynamicFormRevision: DynamicRevisionDto;
    dynamicFormRevisionParams: Array<DynamicParameterDto>;

    @Output() Ready: EventEmitter<any> = new EventEmitter();
    @Output() BeforeSubmit: EventEmitter<any> = new EventEmitter();
    @Output() OnSubmit: EventEmitter<any> = new EventEmitter();
    @Output() OnPostScriptCompleted: EventEmitter<any> = new EventEmitter<any>();
    @Output() OnCheckScriptCompleted: EventEmitter<any> = new EventEmitter<any>();

    ngOnInit() {
        this.readOnlyHistoryItem = this.ReadOnly;
        this.loadDynamicFormWithCode();
    }

    async injectDataSource() {
        let templateJson = JSON.parse(this.dynamicFormRevision.JsonTemplate);
        for(let i in templateJson.components) {
            let item = templateJson.components[i];
            if(item.type == 'Atlas-select' && item.customOptions.dataSourceId != '') {
                await this.httpService.get<any>('/api/DynamicForm/GetDataSource/' + item.customOptions.dataSourceId).then(p => {
                    let modelItems =JSON.parse(p.ApiConfig);
                    let modelItemStr: string = JSON.stringify({
                        url: environment.apiRoot + "/odata/" + modelItems[0].ModelName,
                        items: modelItems,
                        entityName: modelItems[0].ModelName
                    });
                    item.customOptions.selectConfig = modelItemStr;
                });
            } else if(item.type == 'select') {
                // let oDataBuilder: ODataBuilder = new ODataBuilder();
                // let url = oDataBuilder.prepareQuery(0, JSON.parse(p.apiConfig));
                // item.data.url = url;
            }
        }
        this.dynamicFormRevision.JsonTemplate = JSON.stringify(templateJson);
    }

    async loadDynamicFormWithCode() {
        this.reload = false;
        this.httpService.get<DynamicFormDetails>("/api/DynamicForm/ResolveMainRevision?code=" + this.Code).then(async x => {
            this.dynamicForm = x.DynamicForm;
            this.dynamicFormRevision = x.DynamicFormRevision;
            this.dynamicFormRevisionParams = x.DynamicFormRevisionParams;

            if (this.dynamicFormRevision.JsonTemplate) {
                this.injectParametersToTemplate();
                await this.injectDataSource();
            }

            if (this.Mode == 1) {
                this.ShowGrid = false;
                this.loadSubmission();
            }
            else {
                this.Ready.emit(this.dynamicForm);
                this.isReady = true;
                this.reload = true;
            }

        });
    }

    loadDynamicFormDetails(dynamicFormRevisionID: string, submissionID: string) {
        this.reload = false;
        this.httpService.get<DynamicFormDetails>("/api/DynamicForm/GetDynamicFormDetails?dynamicFormRevisionID=" + dynamicFormRevisionID).then(x => {
            this.dynamicForm = x.DynamicForm;
            this.dynamicFormRevision = x.DynamicFormRevision;
            this.dynamicFormRevisionParams = x.DynamicFormRevisionParams;
            if (this.dynamicFormRevision.JsonTemplate) {
                this.injectParametersToTemplate();
            }
            this.loadSubmission(submissionID);
        });
    }

    loadSubmission(submissionID?: string) {

        let formSubmissionDto: FormSubmissionDto =
        {
            FormParamsJson: JSON.stringify(this.Parameters),
            FormMode: this.Mode,
            DynamicReportRevisionID: this.dynamicFormRevision.ObjectID.toString()
        };

        if (submissionID != null && submissionID != "") {
            formSubmissionDto.SubmissionID = submissionID;
        }

        this.httpService.post<any>("/api/DynamicForm/GetSavedForm", formSubmissionDto).then(x => {
            if(this.submission) {
                this.submission.data = x != null ? JSON.parse(x.FormDataJson) : {};
            }
            if (this.ReadOnly == true) {
                this.readOnlyHistoryItem = true;
            }
            else {
                this.readOnlyHistoryItem = false;
            }
            this.form = JSON.parse(this.dynamicFormRevision.JsonTemplate);
            this.Ready.emit(this.dynamicForm);
            this.isReady = true;
            this.reload = true;
        });
    }

    isReady: boolean = false;

    form: any;
    ngAfterViewInit() {
        this.prism.init();
    }
    public setInputParam(value: DynamicFormParameters) {
        this.Code = value.Code;
        this.Mode = value.Mode;
        this.ShowGrid = value.ShowGrid;
        this.ReadOnly = value.ReadOnly;        
        this.Parameters = value.Parameters;
    }

    injectParametersToTemplate() {

        for (let index = 0; index < this.dynamicFormRevisionParams.length; index++) {
            let item = this.dynamicFormRevisionParams[index];
            let data = this.Parameters[item.Key];
            if (data == null && item.IsRequired) {
                let message = "Can't open dynamic form Error:" + item.Key + " is required";
                ServiceLocator.MessageService.showError(message);
                return;
            }
            this.dynamicFormRevision.JsonTemplate = this.dynamicFormRevision.JsonTemplate.replace(new RegExp("{{" + item.Key + "}}", 'g'), data);
        };
        this.dynamicFormRevision.JsonTemplate = DynamicFormDesignerComponent.injectDomainToJSONTemplate(this.dynamicFormRevision.JsonTemplate);
        this.form = JSON.parse(this.dynamicFormRevision.JsonTemplate);
    }


    async onSubmit(e) {
        //TODO:Create Submission
        let formSubmissionDto: FormSubmissionDto =
        {
            FormDataJson: JSON.stringify(e.data),
            FormParamsJson: JSON.stringify(this.Parameters),
            FormMode: this.Mode,
            DynamicReportRevisionID: this.dynamicFormRevision.ObjectID.toString(),
            Action: this.submissionAction ? this.submissionAction.value : undefined,
            SubmissionID: this.historySelected
        };
        this.submission.data = e.data;
        this.reload = false;
        let originalShowGrid = this.ShowGrid;
        if (originalShowGrid == true) {
            this.ShowGrid = false;
        }
        let data = {
            ClassName: this.dynamicForm.CheckClassName,
            ReportParams: this._Parameters,
        }
        let checkResult: any;
        if (this.dynamicForm.CheckClassName) {
            checkResult = await this.httpService.post('/api/DynamicForm/ExecuteCheckScript', data);
            this.OnCheckScriptCompleted.emit(checkResult);
            if (checkResult && !checkResult.Result) {
                ServiceLocator.MessageService.showError(checkResult.Message);
                this.ShowGrid = originalShowGrid;
                this.reload = true;
                return;
            }
        }
        if (this.dynamicForm.CheckClassName && !checkResult) {
            return;
        }
        let result: any = await this.httpService.post("/api/DynamicForm/SaveFormSubmission", formSubmissionDto);
        this.historySelected = "";
        if (result.success == true) {
            ServiceLocator.MessageService.showSuccess("Başarı ile kaydedildi...");
        }
        else {
            ServiceLocator.MessageService.showError("Form kaydedilirken bir hata oluştu.");
        }

        this.ShowGrid = originalShowGrid;
        this.reload = true;

        if (this.dynamicForm.ClassName && this.dynamicForm.ClassName != "") {
            let data = {
                ClassName: this.dynamicForm.ClassName,
                ReportParams: this._Parameters,
            }

            this.httpService.post('/api/DynamicForm/ExecutePostScript', data).then(p => {
                this.OnPostScriptCompleted.emit(p);
            });
        }
        this.OnSubmit.emit(e);
    }
    beforeSubmit(e) {
        this.BeforeSubmit.emit(e);
    }

    SubmissionChanged(e) {
        if (e.selectedRowsData && e.selectedRowsData.length > 0) {
            let selectedSubmission = e.selectedRowsData[0];
            this.historySelected = e.selectedRowsData[0].dynamicFormSubmissionId;
            this.loadDynamicFormDetails(selectedSubmission.dynamicFormRevisionId, selectedSubmission.dynamicFormSubmissionId);
        }else {
            this.historySelected = "";
        }
    }

    newForm() {

        this.submission.data = {};
        this.loadDynamicFormWithCode();

    }

}
export class DynamicFormParameters {

    Parameters : any;
    Code : string;
    Mode : number;
    ReadOnly: boolean = false;
    ShowGrid: boolean = false;

}

export class DynamicFormDto {
    Name: string;
    Code: string;
    ObjectID: Guid;
    IsEnable: boolean;
    ClassName: string;
    CheckClassName: string;
}
export class DynamicRevisionDto {
    DynamicFormId: string;
    Comment: string;
    JsonTemplate: string;
    ObjectID: Guid;
    RevisionNumber: number;
}
export class DynamicFormDetails {
    DynamicForm: DynamicFormDto;
    DynamicFormRevision: DynamicRevisionDto;
    DynamicFormRevisionParams: Array<DynamicParameterDto>;
}
export class DynamicParameterDto {
    Key: string;
    IsRequired?: boolean;
    IsFilter?: boolean;
}



export class FormSubmissionDto {
    FormDataJson?: string;
    FormParamsJson?: string;
    FormMode: number
    SubmissionID?: string;
    DynamicReportRevisionID: string;
    Action?: boolean;
}

export class DynamicFormGridResultDto {

    Columns: Array<any>;
    ResultSet: Array<any>;
}


