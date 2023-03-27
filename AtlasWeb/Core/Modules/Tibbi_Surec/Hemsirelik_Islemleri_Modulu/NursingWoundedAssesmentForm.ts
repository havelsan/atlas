//$9A35F57F
import { Component, ViewChild, OnInit, ApplicationRef,NgZone  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { NursingWoundedAssesmentFormViewModel } from './NursingWoundedAssesmentFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingWoundedAssesment, WoundTypeEnum ,WoundLocalizationDef,WoundSideInfo} from 'NebulaClient/Model/AtlasClientModel';
import { WoundPhoto } from 'NebulaClient/Model/AtlasClientModel';
import { WoundStageDef } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

@Component({
    selector: 'NursingWoundedAssesmentForm',
    templateUrl: './NursingWoundedAssesmentForm.html',
    providers: [MessageService]
})
export class NursingWoundedAssesmentForm extends BaseNursingDataEntryForm implements OnInit {
    Amount: TTVisual.ITTMaskedTextBox;
    ApplicationDate: TTVisual.ITTDateTimePicker;
    Depth: TTVisual.ITTMaskedTextBox;
    Height: TTVisual.ITTMaskedTextBox;
    labelApplicationDate: TTVisual.ITTLabel;
    labelDepth: TTVisual.ITTLabel;
    labelHeight: TTVisual.ITTLabel;
    labelNursingWoundTime: TTVisual.ITTLabel;
    labelOperationDate: TTVisual.ITTLabel;
    labelWidth: TTVisual.ITTLabel;
    labelWoundedType: TTVisual.ITTLabel;
    labelWoundLocalization: TTVisual.ITTLabel;
    labelWoundSide: TTVisual.ITTLabel;
    labelWoundStage: TTVisual.ITTLabel;
    NursingWoundTime: TTVisual.ITTEnumComboBox;
    OperationDate: TTVisual.ITTDateTimePicker;
    PhotoDateWoundPhoto: TTVisual.ITTDateTimePickerColumn;
    Width: TTVisual.ITTMaskedTextBox;
    WoundedType: TTVisual.ITTEnumComboBox;
    WoundLocalization: TTVisual.ITTObjectListBox;
    WoundPhotos: TTVisual.ITTGrid;
    WoundSide: TTVisual.ITTObjectListBox;
    WoundStage: TTVisual.ITTObjectListBox;
    public WoundPhotosColumns = [];
    @ViewChild('gridWoundPhoto') gridWoundPhoto: DxDataGridComponent;
    @ViewChild('ismail') ismail;
    public showBigPhoto = false;
    public nursingWoundedAssesmentFormViewModel: NursingWoundedAssesmentFormViewModel = new NursingWoundedAssesmentFormViewModel();
    public get _NursingWoundedAssesment(): NursingWoundedAssesment {
        return this._TTObject as NursingWoundedAssesment;
    }
    private NursingWoundedAssesmentForm_DocumentUrl: string = '/api/NursingWoundedAssesmentService/NursingWoundedAssesmentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingWoundedAssesmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingWoundedAssesment();
        this.nursingWoundedAssesmentFormViewModel = new NursingWoundedAssesmentFormViewModel();
        this._ViewModel = this.nursingWoundedAssesmentFormViewModel;
        this.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment = this._TTObject as NursingWoundedAssesment;
        this.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment.WoundSide = new WoundSideInfo();
        this.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment.WoundLocalization = new WoundLocalizationDef();
        this.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment.WoundStage = new WoundStageDef();
        this.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment.WoundPhotos = new Array<WoundPhoto>();
    }

    protected loadViewModel() {
        let that = this;
        that.nursingWoundedAssesmentFormViewModel = this._ViewModel as NursingWoundedAssesmentFormViewModel;
        that._TTObject = this.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment;
        if (this.nursingWoundedAssesmentFormViewModel == null)
            this.nursingWoundedAssesmentFormViewModel = new NursingWoundedAssesmentFormViewModel();
        if (this.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment == null)
            this.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment = new NursingWoundedAssesment();
        let woundSideObjectID = that.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment["WoundSide"];
        if (woundSideObjectID != null && (typeof woundSideObjectID === "string")) {
            let woundSide = that.nursingWoundedAssesmentFormViewModel.WoundSideInfos.find(o => o.ObjectID.toString() === woundSideObjectID.toString());
            if (woundSide) {
                that.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment.WoundSide = woundSide;
            }
        }
        let woundLocalizationObjectID = that.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment["WoundLocalization"];
        if (woundLocalizationObjectID != null && (typeof woundLocalizationObjectID === "string")) {
            let woundLocalization = that.nursingWoundedAssesmentFormViewModel.WoundLocalizationDefs.find(o => o.ObjectID.toString() === woundLocalizationObjectID.toString());
            if (woundLocalization) {
                that.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment.WoundLocalization = woundLocalization;
            }
        }        
        let woundStageObjectID = that.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment["WoundStage"];
        if (woundStageObjectID != null && (typeof woundStageObjectID === "string")) {
            let woundStage = that.nursingWoundedAssesmentFormViewModel.WoundStageDefs.find(o => o.ObjectID.toString() === woundStageObjectID.toString());
            if (woundStage) {
                that.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment.WoundStage = woundStage;
            }
        }
    
    that.nursingWoundedAssesmentFormViewModel._NursingWoundedAssesment.WoundPhotos = that.nursingWoundedAssesmentFormViewModel.WoundPhotosGridList;
    for(let detailItem of that.nursingWoundedAssesmentFormViewModel.WoundPhotosGridList) {
    }

}

async ngOnInit() {
    await this.load();
}

protected async ClientSidePreScript(): Promise<void> {
    //TODO:ismail isteğin detayına göre açılacak
    //this.ReadOnly = true;
    if (this["NursAppReadOnly"] != null)
        this.nursingWoundedAssesmentFormViewModel.ReadOnly = (this.nursingWoundedAssesmentFormViewModel.ReadOnly || this["NursAppReadOnly"]);

    if (this.nursingWoundedAssesmentFormViewModel.ReadOnly)
        this.DropStateButton(NursingWoundedAssesment.NursingWoundedAssesmentStates.Cancelled);

    super.ClientSidePreScript();
}

protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
    super.ClientSidePostScript(transDef);

    // if (transDef !== null) {

        if(this._NursingWoundedAssesment.WoundedType == null)
            throw new Exception("Yara türü seçimi yapmadan kaydetme işlemine devam edemezsiniz.");

        if(this._NursingWoundedAssesment.WoundPhotos == null || this._NursingWoundedAssesment.WoundPhotos.length == 0)
            throw new Exception("En az bir tane fotoğraf kaydı girmelisiniz.");

        if(this._NursingWoundedAssesment.WoundedType == WoundTypeEnum.Basinc || this._NursingWoundedAssesment.WoundedType == WoundTypeEnum.Inkontinans){
            if(this._NursingWoundedAssesment.Width == null || this._NursingWoundedAssesment.Height == null )
                throw new Exception("En ve boy bilgilerini girmeden kaydetme işlemine devam edemezsiniz.")  ;            
        }

        if(this._NursingWoundedAssesment.WoundedType == WoundTypeEnum.Basinc && this._NursingWoundedAssesment.OperationDate == null)
            throw new Exception("Operasyon Tarihini girmeden kaydetme işlemine devam edemezsiniz.")  ;

        if(this._NursingWoundedAssesment.WoundedType == WoundTypeEnum.Inkontinans && this._NursingWoundedAssesment.WoundedType == null)
            throw new Exception("Evre seçimi yapmadan kaydetme işlemine devam edemezsiniz.")  ;

        if(this._NursingWoundedAssesment.WoundedType == WoundTypeEnum.Inkontinans && this._NursingWoundedAssesment.WoundStage == null)
            throw new Exception("Evre bilgisi girmeden kaydetme işlemine devam edemezsiniz.")  ;             
        
        if(this._NursingWoundedAssesment.WoundedType == WoundTypeEnum.Inkontinans && this._NursingWoundedAssesment.WoundStage.IsDepthNeeded == true
            && this._NursingWoundedAssesment.Depth == null)
            throw new Exception("Derinlik bilgisi girmeden kaydetme işlemine devam edemezsiniz.")  ; 
        
        // throw new Exception("Bası Yaraso Oluşma Zamanı Seçilmeden işleme devan edemezsiniz.");
    // }       
}

public onApplicationDateChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.ApplicationDate != event) { 
    this._NursingWoundedAssesment.ApplicationDate = event;
}
}

public onDepthChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.Depth != event) { 
    this._NursingWoundedAssesment.Depth = event;
}
}

public onHeightChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.Height != event) { 
    this._NursingWoundedAssesment.Height = event;
}
}

public onNursingWoundTimeChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.NursingWoundTime != event) { 
    this._NursingWoundedAssesment.NursingWoundTime = event;
}
}

public onOperationDateChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.OperationDate != event) { 
    this._NursingWoundedAssesment.OperationDate = event;
}
}

public onWidthChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.Width != event) { 
    this._NursingWoundedAssesment.Width = event;
}
}

public onAmountChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.Amount != event) { 
    this._NursingWoundedAssesment.Amount = event;
}
}

public onWoundLocalizationChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.WoundLocalization != event) { 
    this._NursingWoundedAssesment.WoundLocalization = event;
    }
}

public onWoundedTypeChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.WoundedType != event) { 
    this._NursingWoundedAssesment.WoundedType = event;
    }

    // if(this._NursingWoundedAssesment.WoundedType == WoundTypeEnum.Inkontinans)
    //     this.WoundStage.ReadOnly = false;
    // else
    //     this.WoundStage.ReadOnly = true;
}

public onWoundSideChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.WoundSide != event) { 
    this._NursingWoundedAssesment.WoundSide = event;
}
}

public onWoundStageChanged(event): void {
    if(this._NursingWoundedAssesment != null && this._NursingWoundedAssesment.WoundStage != event) { 
    this._NursingWoundedAssesment.WoundStage = event;

    }

    // if(this._NursingWoundedAssesment.WoundStage.IsDepthNeeded == true)
    //     this.Depth.ReadOnly = false;
    // else
    //     this.Depth.ReadOnly = true;
}

public isCameraShowing = false;
onCapturePhotoChanged(event): void {
    this.isCameraShowing = false;
}


photoCaptured(data) {
    // this.nursingWoundedAssesmentFormViewModel.PhotoString = data;
    let _photo= new WoundPhoto();
    _photo.Photo = data;
    _photo.PhotoDate= new Date();
    this._NursingWoundedAssesment.WoundPhotos.push(_photo);
}

public onCameraShowingStarted() {
    this.isCameraShowing = true;
}

public onGridRowClick(event) {
    
    if(event != null && event.currentSelectedRowKeys != null && event.currentSelectedRowKeys.length > 0)
        this.nursingWoundedAssesmentFormViewModel.PhotoString = event.currentSelectedRowKeys[0].Photo;
    // this.loadProcedure($event.data)
    // this.TTObjectToModel();
}

public onPhotoRemoving(event) {
    if (event.row != null) {

        if (event.row.data != null) {
            if (event.row.data.IsNew != false) {//Combo değiştiğinde gelen veriler de yeni ama Isnew undefined geliyor

                // let index = this._NursingWoundedAssesment.WoundPhotos.findIndex(o => o.ObjectID.toString() === event.row.data.ObjectID.toString() );

                // if (index > -1)
                //     this.patientAdmissionFormViewModel.ResourcesToBeReferredList.splice(index, 1);

                this.gridWoundPhoto.instance.deleteRow(event.rowIndex);
            }
            else {
                event.data.EntityState = EntityStateEnum.Deleted;
                this.gridWoundPhoto.instance.filter(['EntityState', '<>', 1]);
                this.gridWoundPhoto.instance.refresh();
            }
        }
    }
}

public openBigPhoto()
{
    this.showBigPhoto = true;
}


protected redirectProperties() : void {
    redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
    redirectProperty(this.WoundedType, "Value", this.__ttObject, "WoundedType");
    redirectProperty(this.OperationDate, "Value", this.__ttObject, "OperationDate");
    redirectProperty(this.Width, "Text", this.__ttObject, "Width");
    redirectProperty(this.Amount, "Text", this.__ttObject, "Amount");
    redirectProperty(this.Height, "Text", this.__ttObject, "Height");
    redirectProperty(this.Depth, "Text", this.__ttObject, "Depth");
    redirectProperty(this.NursingWoundTime, "Value", this.__ttObject, "NursingWoundTime");
}

public initFormControls() : void {
    this.labelWoundSide = new TTVisual.TTLabel();
    this.labelWoundSide.Text = "Taraf Seçimi";
    this.labelWoundSide.Name = "labelWoundSide";
    this.labelWoundSide.TabIndex = 20;

    this.WoundSide = new TTVisual.TTObjectListBox();
    this.WoundSide.ListDefName = "WoundSideInfoList";
    this.WoundSide.Name = "WoundSide";
    this.WoundSide.TabIndex = 19;

    this.labelNursingWoundTime = new TTVisual.TTLabel();
    this.labelNursingWoundTime.Text = "Bası Yarası Oluşma Zamanı";
    this.labelNursingWoundTime.Name = "labelNursingWoundTime";
    this.labelNursingWoundTime.TabIndex = 18;

    this.NursingWoundTime = new TTVisual.TTEnumComboBox();
    this.NursingWoundTime.DataTypeName = "PressureWoundTimeEnum";
    this.NursingWoundTime.Name = "NursingWoundTime";
    this.NursingWoundTime.TabIndex = 17;

    this.labelWoundLocalization = new TTVisual.TTLabel();
    this.labelWoundLocalization.Text = "Lokalizasyon Bilgisi";
    this.labelWoundLocalization.Name = "labelWoundLocalization";
    this.labelWoundLocalization.TabIndex = 16;

    this.WoundLocalization = new TTVisual.TTObjectListBox();
    this.WoundLocalization.ListDefName = "WoundLocalizationDefList";
    this.WoundLocalization.Name = "WoundLocalization";
    this.WoundLocalization.TabIndex = 15;

    this.labelWoundStage = new TTVisual.TTLabel();
    this.labelWoundStage.Text = "Evre";
    this.labelWoundStage.Name = "labelWoundStage";
    this.labelWoundStage.TabIndex = 14;

    this.WoundStage = new TTVisual.TTObjectListBox();
    this.WoundStage.ListDefName = "WoundStageDefList";
    this.WoundStage.Name = "WoundStage";
    this.WoundStage.TabIndex = 13;
    
    this.WoundPhotos = new TTVisual.TTGrid();
    this.WoundPhotos.Name = "WoundPhotos";
    this.WoundPhotos.TabIndex = 12;

    this.PhotoDateWoundPhoto = new TTVisual.TTDateTimePickerColumn();
    this.PhotoDateWoundPhoto.DataMember = "PhotoDate";
    this.PhotoDateWoundPhoto.DisplayIndex = 0;
    this.PhotoDateWoundPhoto.HeaderText = "Kayıt Tarihi";
    this.PhotoDateWoundPhoto.Name = "PhotoDateWoundPhoto";
    this.PhotoDateWoundPhoto.Width = 180;

    this.labelDepth = new TTVisual.TTLabel();
    this.labelDepth.Text = "Derinlik";
    this.labelDepth.Name = "labelDepth";
    this.labelDepth.TabIndex = 11;

    this.Depth = new TTVisual.TTMaskedTextBox();
    this.Depth.Name = "Depth";
    this.Depth.TabIndex = 10;
    this.Depth.Mask = "99.9".replace(/\s/g, "");

    this.Height = new TTVisual.TTMaskedTextBox();
    this.Height.Name = "Height";
    this.Height.TabIndex = 8;
    this.Height.Mask = "99.9".replace(/\s/g, "");

    this.Width = new TTVisual.TTMaskedTextBox();
    this.Width.Name = "Width";
    this.Width.TabIndex = 4;
    this.Width.Mask = "99.9".replace(/\s/g, "");

    this.Amount = new TTVisual.TTMaskedTextBox();
    this.Amount.Name = "Amount";
    this.Amount.TabIndex = 4;
    this.Amount.Mask = "99.9".replace(/\s/g, "");

    this.labelHeight = new TTVisual.TTLabel();
    this.labelHeight.Text = "Boy";
    this.labelHeight.Name = "labelHeight";
    this.labelHeight.TabIndex = 9;

    this.labelOperationDate = new TTVisual.TTLabel();
    this.labelOperationDate.Text = "Operasyon Tarihi";
    this.labelOperationDate.Name = "labelOperationDate";
    this.labelOperationDate.TabIndex = 7;

    this.OperationDate = new TTVisual.TTDateTimePicker();
    this.OperationDate.Format = DateTimePickerFormat.Long;
    this.OperationDate.Name = "OperationDate";
    this.OperationDate.TabIndex = 6;

    this.labelWidth = new TTVisual.TTLabel();
    this.labelWidth.Text = "En";
    this.labelWidth.Name = "labelWidth";
    this.labelWidth.TabIndex = 5;

    this.labelWoundedType = new TTVisual.TTLabel();
    this.labelWoundedType.Text = "Yara Türü";
    this.labelWoundedType.Name = "labelWoundedType";
    this.labelWoundedType.TabIndex = 3;

    this.WoundedType = new TTVisual.TTEnumComboBox();
    this.WoundedType.DataTypeName = "WoundTypeEnum";
    this.WoundedType.Name = "WoundedType";
    this.WoundedType.TabIndex = 2;

    this.labelApplicationDate = new TTVisual.TTLabel();
    this.labelApplicationDate.Text = "Uygulama Zamanı";
    this.labelApplicationDate.Name = "labelApplicationDate";
    this.labelApplicationDate.TabIndex = 1;

    this.ApplicationDate = new TTVisual.TTDateTimePicker();
    this.ApplicationDate.Format = DateTimePickerFormat.Long;
    this.ApplicationDate.Name = "ApplicationDate";
    this.ApplicationDate.TabIndex = 0;

    this.WoundPhotosColumns = [this.PhotoDateWoundPhoto];
    this.Controls = [this.labelWoundSide, this.WoundSide, this.labelNursingWoundTime, this.NursingWoundTime, this.labelWoundLocalization, this.WoundLocalization, this.labelWoundStage, this.WoundStage, this.WoundPhotos, this.PhotoDateWoundPhoto, this.labelDepth, this.Depth, this.Height, this.Width,this.Amount, this.labelHeight, this.labelOperationDate, this.OperationDate, this.labelWidth, this.labelWoundedType, this.WoundedType, this.labelApplicationDate, this.ApplicationDate];

}


}
