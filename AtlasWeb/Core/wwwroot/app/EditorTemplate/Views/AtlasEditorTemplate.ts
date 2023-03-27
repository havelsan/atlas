//$B1D625C5
import { Component, Input, OnInit, SimpleChange, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { AtlasFormFieldConfig } from '../../DynamicForm/Models/AtlasFormFieldConfig';
import { Validators } from '@angular/forms';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { AtlasDynamicFormComponent } from '../../DynamicForm/Views/AtlasDynamicFormComponent';
import { AtlasEditorTemplateModel } from '../AtlasEditorTemplateModel';

@Component({
    selector: 'atlas-editor-template',
    template: `
    <div class="form">
        <div class="row" style="margin-top:15px;">
            <div class="col-md-12">   <div><strong>Aşağıdaki bilgileri girdikten sonra  şablon kaydını oluşturabilir veya güncelleyebilirsiniz</strong></div> </div>
        </div>
        <div class="row" style="margin-top:15px;">
            <div class="col-md-12">
                <div class="dx-field">
                    <div class="dx-field-label">Şablon Grup Adı</div>  <div class="dx-field-value">    <dx-text-box [value]="TemplateGroupName" [readOnly]="true" placeholder="Şablon Group Adı Giriniz"></dx-text-box> </div> </div>
            </div>
        </div>
        <div class="row" style="margin-top:15px;">
            <div class="col-md-12">
                <div class="dx-field">
                <div class="dx-field-label">Şablon Adı</div>
                <div class="dx-field-value">
                        <dx-select-box *ngIf="_isUpdate" [items]="EditorTemplateList" placeholder="Şablon Seçiniz"
                            displayExpr="MenuCaption" showClearButton="true" searchEnabled="true" (showSelectionControls)="false"
                             (onSelectionChanged)="selectionChanged($event)" valueExpr="ObjectID" id="A26313"></dx-select-box>
               
                         <dx-text-box *ngIf="_isUpdate == false" placeholder="Şablon  Adı Giriniz" [(value)]="_templateName"></dx-text-box>
                   </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top:15px;">
            <div class="col-md-12">
                <div class="dx-field">
                    <div class="dx-field-label">Şablon Açıklama</div>  <div class="dx-field-value">   <dx-text-box [(value)]="_templateDescription" placeholder="Şablon  Açıklama"></dx-text-box>  </div>  </div>
            </div>
        </div>
        <div class="row" style="margin-top:50px; float:right;">
            
            <div class="col-md-6">
                <dx-button stylingMode="contained" text="İptal" type="danger" [width]="120" (onClick)="cancelClick()"></dx-button>
            </div>
            <div *ngIf="_isUpdate" class="col-md-6">
                <dx-button stylingMode="contained" text="Şablon Güncelle" type="success" [width]="120" (onClick)="updateClick()"></dx-button>
            </div>
            <div *ngIf="_isUpdate ==false" class="col-md-6">
                <dx-button stylingMode="contained" text="Şablon Oluştur" type="success" [width]="120" (onClick)="okClick()"></dx-button>
            </div>
        </div>
    </div>
`
})
export class AtlasEditorTemplate implements OnInit, IModal {

    @ViewChild('dynForm') dynamicForm: AtlasDynamicFormComponent;

    private _templateGroupName: string;
    @Input() set TemplateGroupName(value: string) {
        this._templateGroupName = value;
    }
    get TemplateGroupName(): string {
        return this._templateGroupName;
    }

    public _templateName : string = "";
    public _templateUpdateObj : any;
    public _templateDescription : string = "";

    constructor(private http: NeHttpService
        , private modalStateService: ModalStateService
        , private messageService: MessageService) {
    }



    private _isUpdate: boolean = false;
    private _inputParam: AtlasEditorTemplateModel;
    public setInputParam(value: AtlasEditorTemplateModel) {
        this._inputParam = value;
        if (value != null) {
            this.TemplateGroupName = value.templateGroupName;
            this._isUpdate = value.isUpdate;
        }
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }
    public EditorTemplateList: Array<any>;
    private loadTemplateList(templateGroupName: string): void {
        let that = this;
        const templateUrl = `/api/EditorTemplate/GetEditorTemplates`;
        const input = { TemplateGroupName: templateGroupName };
        this.http.post(templateUrl, input).then(result => {
            that.EditorTemplateList = result as Array<any>;
        }).catch(err => {
            that.messageService.showError(err);
        });
    }

    ngOnInit() {
        this.loadTemplateList(this._templateGroupName);
    }

    ngOnChanges(changes: { [propName: string]: SimpleChange }) {
    }
    
    selectionChanged(event){
        this._templateUpdateObj = event.selectedItem;
    }   

    okClick() {

        if(this._templateName != null && this._templateName != "" && this._templateGroupName){
            const formValue = this._templateName;
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, formValue);
        }else {
            this.messageService.showError("Şablon adı veya Şablon Grup Adı girdiğinizden emin olun. ");
        }
    }

    updateClick() {
        if(this._templateUpdateObj != null && this._templateGroupName){
            const formValue = this._templateUpdateObj;
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, formValue);
        }else {
            this.messageService.showError("Şablon adı veya Şablon Grup Adı girdiğinizden emin olun. ");
        }
    }

    cancelClick() {
        if (this._modalInfo != null) {
            this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, null);
        }
    }

}