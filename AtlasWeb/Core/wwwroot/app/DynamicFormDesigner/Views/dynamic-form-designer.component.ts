import { Component, OnInit, Input, AfterViewInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { environment } from 'app/environments/environment';
import { DxTextBoxComponent, DxTreeViewComponent, DxSelectBoxComponent, DxCheckBoxComponent } from 'devextreme-angular';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { HttpClient } from '@angular/common/http';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DynamicParameterDto } from './HvlDynamicForm';

@Component({
    selector: 'dynamic-form-designer-component',
    templateUrl: 'dynamic-form-designer-component.html',
})
export class DynamicFormDesignerComponent implements AfterViewInit {


    public forms: Array<DynamicFormDto> = [];
    public revisions: Array<DynamicFormRevisionDto> = [];
    public dataSourceClasses: Array<string> = [];
    public showCreateForm: boolean = false;
    public showDesigner: boolean = false;
    public showPreview: boolean = false;
    public showoDataEditor: boolean = false;
    public showBase64Popup: boolean = false;
    public showParameter: boolean = false;
    public uploadUrl: string = environment.apiRoot + "/api/DynamicForm/UploadForm";
    public uploadValue: any;
    public uploadHeaders: any;
    public parameters: Array<DynamicParameterDto> = [];
    public dynamicParameters: Array<string> = [];
    public DynamicFormParameters: DynamicFormParameters = {};


    @ViewChild('txtFormName') txtFormName: DxTextBoxComponent;
    @ViewChild('txtFormCode') txtFormCode: DxTextBoxComponent;
    @ViewChild('txtFormComment') txtFormComment: DxTextBoxComponent;
    @ViewChild('txtParameter') txtParameter: DxTextBoxComponent;
    @ViewChild('checkRequeired') checkRequeired: DxCheckBoxComponent;
    @ViewChild('txtPostScriptClass') txtPostScriptClass: DxTextBoxComponent;
    @ViewChild('txtCheckScriptClass') txtCheckScriptClass: DxTextBoxComponent;
    @ViewChild('checkFilter') checkFilter: DxCheckBoxComponent;

    @Input() InputParams: any;

    public async setInputParam(value: any) {
        this.InputParams = value;
    }

    ngAfterViewInit(): void {
        this.loadForms();
        let token = sessionStorage.getItem('token');
        this.uploadHeaders = { Authorization: `Bearer ${token}` };

        jQuery(document).on('change', "[name='data[dataSrc]']", () => {

            let option = jQuery("[name='data[dataSrc]']").val();

            if (option == 'url') {
                this.openODataEditor();

            }

        });

        
        jQuery(document).on('focus', "[name='data[customOptions.gridConfig]']", () => {
            this.openODataEditor();
        });
        jQuery(document).on('focus', "[name='data[customOptions.selectConfig]']", () => {
            this.openODataEditor();
        });
        jQuery(document).on('focus', "[name='data[data.url]']", () => {
            this.openODataEditor();
        });
        jQuery(document).on('focus', "[name='data[customOptions.image]']", () => {
            this.openBase64Popup();
        });

    }

    onChange(event: any) {
        console.log(event);
        this.changeDetector.detectChanges();
        this.DynamicFormParameters.JsonTemplate = JSON.stringify(event);
    }

    constructor(private httpService: NeHttpService, private changeDetector: ChangeDetectorRef, http: HttpClient) {
        this.emptyForms();
    }

    onUploaded(event: any) {
        this.loadForms();
        console.log(event);
    }
    onUploadError(event: any) {
        console.log(event);
    }

    onShowPreview() {
        this.showPreview = !this.showPreview;
    }

    emptyForms() {
        this.forms.Clear();
        this.forms.push({ ObjectID: '-1', LongName: 'Lütfen Form Seçiniz' });
        this.forms.push({ ObjectID: '0', LongName: 'Yeni Form' });
    }

    loadForms() {
        this.httpService.get<Array<DynamicFormDto>>("/api/DynamicForm/GetForms?getAll=false").then(x => {
            if (x && x.length > 0) {
                this.emptyForms();
                this.forms = this.forms.concat(x);
            }
        });
    }

    loadParams(dynamicFormID: string) {
        this.httpService.get<Array<DynamicParameterDto>>("/api/DynamicForm/GetParamsForRevision?dynamicFormID=" + dynamicFormID).then(x => {
            this.parameters = x;
            this.dynamicParameters = this.parameters.map(p => '{{' + p.Key + '}}');
        });
    }

    loadRevisions(dynamicFormID: string) {
        this.httpService.get<Array<DynamicFormRevisionDto>>("/api/DynamicForm/GetRevisionForms?dynamicFormID=" + dynamicFormID).then(x => {
            this.revisions = x;

            if (this.revisions.length == 0) {
                this.DynamicFormParameters.JsonTemplate = null;
                this.showDesigner = true;
            }
            
            
            if(this.revisions.length > 0){
                for (let index = 0; index < this.revisions.length; index++) {
                    let revision = this.revisions[index];
                    revision.JsonTemplate = DynamicFormDesignerComponent.injectDomainToJSONTemplate(revision.JsonTemplate);
                }
            }
        });
    }
    saveForm() {
        let formName = this.txtFormName.value;

        if (formName.length < 1) {
            console.warn("formName must be filled.");
            return;
        }
        let dto: DynamicFormDto = {
            Name: this.txtFormName.value,
            Code: this.txtFormCode.value,
            ClassName: this.txtPostScriptClass.value,
            CheckClassName: this.txtCheckScriptClass.value
        };

        this.httpService.post<Boolean>("/api/DynamicForm/SaveForm", dto).then(x => {

            this.loadForms();
        });
    }

    static injectDomainToJSONTemplate(value){

        value = DynamicFormDesignerComponent.removeDomainFromJSONTemplate(value);

        let key = "/odata/";
        let result = value.replace(new RegExp(key, 'g'), environment.apiRoot + key);
        return result;
    }
    static removeDomainFromJSONTemplate(value){
        let result = value.replace(new RegExp(environment.apiRoot, 'g'), '');
        return result;
    }

    saveRevision() {
        let dto = this.DynamicFormParameters;

        if (dto.DynamicFormID.length < 1) {
            console.warn("Missing parameter.");
            return;
        }

        dto.JsonTemplate = DynamicFormDesignerComponent.removeDomainFromJSONTemplate(dto.JsonTemplate);
        dto.Comment = this.txtFormComment.value;
        dto.Parameters = this.parameters;

        return this.httpService.post<any>("/api/DynamicForm/SaveFormRevision", dto).then(x => {
            this.loadRevisions(dto.DynamicFormID);
        });
    }

    downloadRevision() {
        this.httpService.get<any>("/api/DynamicForm/DownloadFormRevision?revisionID=" + this.DynamicFormParameters.DynamicFormRevisionID).then(x => {

            this.saveJSON(x, "Form.json");

        });
    }

    setAsMainRevision() {

        this.httpService.get<Boolean>("/api/DynamicForm/SetAsMainRevision?objectID=" + this.DynamicFormParameters.DynamicFormRevisionID).then(x => {

            this.DynamicFormParameters.DynamicFormRevisionID = null;
            this.loadRevisions(this.DynamicFormParameters.DynamicFormID);

        });
    }

    clearFormObject() {
        this.DynamicFormParameters.DynamicFormID = null;
        this.DynamicFormParameters.DynamicFormRevisionID = null;


        if (this.revisions && this.revisions.length > 0) {
            this.revisions.Clear();
        }

    }
    enableDisableButtonClicked() {

        this.setEnableDisable(this.selectedItem.ObjectID, !this.selectedItem.IsEnable);
    }
    setEnableDisable(objectID: string, enabled: boolean) {
        this.httpService.get<Boolean>("/api/DynamicForm/SetEnableDisable?objectID=" + objectID + "&enable=" + enabled).then(x => {
            this.loadForms();
        });
    }

    selectedItem: DynamicFormDto;
    formChanged(e) {

        let value = e.value as DynamicFormDto;

        this.selectedItem = value;

        this.showDesigner = false;
        if (value.ObjectID == '0') {
            //New Form
            this.showCreateForm = true;
            this.clearFormObject();
        }
        else if (value.ObjectID == '-1') {
            //Please Select
            this.showCreateForm = false;
            this.clearFormObject();
        }
        else {
            //A Form
            this.showCreateForm = false;

            this.DynamicFormParameters.DynamicFormID = value.ObjectID;
            this.DynamicFormParameters.DynamicFormRevisionID = null;

            this.loadRevisions(value.ObjectID);
        }
        console.log(e);
    }
    revisionChanged(e) {
        console.log(e);
        let value = e.value as DynamicFormRevisionDto;
        this.showDesigner = false;
        this.changeDetector.detectChanges();
        this.DynamicFormParameters.DynamicFormRevisionID = value.ObjectID;
        this.DynamicFormParameters.JsonTemplate = value.JsonTemplate;
        this.showDesigner = true;
        this.changeDetector.detectChanges();
        this.loadParams(value.ObjectID);
    }


    public onSave(e: any) {
        this.loadRevisions(this.DynamicFormParameters.DynamicFormID);
    }


    saveJSON(data, filename) {

        if (!data) {
            console.error('No data')
            return;
        }

        if (!filename) filename = 'console.json'

        if (typeof data === "object") {
            data = JSON.stringify(data, undefined, 4)
        }

        var blob = new Blob([data], { type: 'text/json' }),
            e = document.createEvent('MouseEvents'),
            a = document.createElement('a')

        a.download = filename
        a.href = window.URL.createObjectURL(blob)
        a.dataset.downloadurl = ['text/json', a.download, a.href].join(':')
        e.initMouseEvent('click', true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null)
        a.dispatchEvent(e)
    }


    openODataEditor() {
        this.showoDataEditor = true;
    }

    closePopup(e) {
        this.showoDataEditor = false;
    }
    
    openBase64Popup() {
        this.showBase64Popup = true;
    }

    closePopupBase64(e) {
        this.showBase64Popup = false;
    }

    addNewParameter() {
        let paramKey = this.txtParameter.value;
        let isRequired = this.checkRequeired.value;
        let isFilter = this.checkFilter.value;
        if(this.parameters.filter(p => p.Key == paramKey).length > 0) {
            ServiceLocator.MessageService.showError("Aynı parametreyi birden fazla ekleyemezsiniz.");
            return;
        }
        this.parameters.push({
            Key: paramKey,
            IsRequired: isRequired,
            IsFilter: isFilter
        });
        this.dynamicParameters = this.parameters.map(p => '{{' + p.Key + '}}');
        this.showParameter = false;
        this.checkFilter.value = false;
        this.txtParameter.value = "";
        this.checkRequeired.value = false;
    }

    onTagChanged(e) {
        this.parameters = e.value;
        this.dynamicParameters = this.parameters.map(p => '{{' + p.Key + '}}');
    }

    openParameterPopup() {
        this.showParameter = true;
    }
}

export class DynamicFormParameters {
    DynamicFormRevisionID?: string;
    DynamicFormID?: string;
    JsonTemplate?: string;
    Comment?: string;
    Parameters?: Array<DynamicParameterDto>;
}

export class DynamicFormDto {
    ObjectID?: string;
    Code?: string;
    IsEnable?: string;
    Name?: string;
    ClassName?: string;
    LongName?: string;
    CheckClassName?: string;
}

export class DynamicFormRevisionDto {
    ObjectID?: string;
    IsMain?: boolean;
    JsonTemplate?: string;
    RevisionNumber?: number;
    DynamicFormId?: string;
    Comment?: string;
}



