//$75EBD442
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingOrderDetailFormViewModel } from './NursingOrderDetailFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { NursingOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { SubactionProcedureFlowableForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SubactionProcedureFlowableForm";
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { VitalSignAndNursingValueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { VitalSignType } from 'NebulaClient/Model/AtlasClientModel';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ModalStateService, ModalInfo, IModal } from "Fw/Models/ModalInfo";
import { CommonService } from "ObjectClassService/CommonService";
import { NursingApplication } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionData } from "Modules/Tibbi_Surec/Hasta_Dosyasi/MainPatientFolderFormViewModel";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

import { Convert } from 'app/NebulaClient/Mscorlib/Convert';

@Component({
    selector: 'NursingOrderDetailForm',
    templateUrl: './NursingOrderDetailForm.html',
    providers: [MessageService]
})
export class NursingOrderDetailForm extends SubactionProcedureFlowableForm implements OnInit, IModal {
    ExecutionDate: TTVisual.ITTDateTimePicker;
    labelExacutionDate: TTVisual.ITTLabel;
    labelNabız: TTVisual.ITTLabel;
    labelNameResource: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    labelProcedure: TTVisual.ITTLabel;
    labelResult: TTVisual.ITTLabel;
    lableSonucCombo: TTVisual.ITTLabel;
    NameResource: TTVisual.ITTTextBox;
    Note: TTVisual.ITTTextBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    ResultBySelection: TTVisual.ITTObjectListBox;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabelBloodPressure: TTVisual.ITTLabel;
    ttmaskedBloodPressure: TTVisual.ITTMaskedTextBox;
    ttmaskedResult: TTVisual.ITTMaskedTextBox;
    ttmaskedResultPulse: TTVisual.ITTMaskedTextBox;
    ttmaskedResultSPO2: TTVisual.ITTMaskedTextBox;
    public _VitalSignValuesInfo: string = "";
    public nursingOrderDetailFormViewModel: NursingOrderDetailFormViewModel = new NursingOrderDetailFormViewModel();
    public get _NursingOrderDetail(): NursingOrderDetail {
        return this._TTObject as NursingOrderDetail;
    }
    private NursingOrderDetailForm_DocumentUrl: string = '/api/NursingOrderDetailService/NursingOrderDetailForm';

    public _scheduleWorkListDate: Date;
    public _resultMask: string = "";
    public _resultIsValid: boolean;
    public IsEntryState: boolean = true;
    public _worklistDateReadOnly = true;
    //@Input() set ScheduleWorkListDate(value: Date) {
    //    this._scheduleWorkListDate = value;
    //}
    //get ScheduleWorkListDate(): Date {
    //    return this._scheduleWorkListDate;
    //}
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private modalStateService: ModalStateService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingOrderDetailForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        this.ExecutionDate.Required = true;

        let currentDate: Date = (await CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        // let _tempWorkListDate: Date = DateUtil.parseISOLocal(DateUtil.toLocalString(this._NursingOrderDetail.WorkListDate));
        let _tempWorkListDate: Date = Convert.ToDateTime(this._NursingOrderDetail.WorkListDate);


        //if (!this._resultIsValid)
        //    throw new Exception('ismail.');
        //throw new Exception((await SystemMessageService.GetMessage(1167)));
        if (transDef != null)
        {
            if (transDef.ToStateDefID.valueOf() == NursingOrderDetail.NursingOrderDetailStates.Completed.id)
            {
                this.ExecutionDate.Required = true;
                this.ProcedureObject.Required = true;

                if (this._NursingOrderDetail.ProcedureObject == null)
                    throw new Exception(i18n("M24166", "Vital Bulgu Seçilmeden işleme devan edemezsiniz."));

                if (this._NursingOrderDetail.ExecutionDate == null)
                    throw new Exception(i18n("M23774", "Uygulama Zamanını girmeden devan edemezsiniz."));

                if (this._NursingOrderDetail.ExecutionDate < this._NursingOrderDetail.WorkListDate )
                    throw new Exception(i18n("M23775", "Uygulama Zamanını Planlama Zamanından küçük olamaz."));

                if (currentDate.setHours(0, 0, 0,0) < _tempWorkListDate.setHours(0, 0, 0,0))
                    throw new Exception(i18n("M16407", "İleri tarihli orderları bugünden uygulayamazsınız."));

                if (this._NursingOrderDetail.ProcedureObject["VitalSignType"] == VitalSignType.ANT
                    && (this._NursingOrderDetail.Result == null || this._NursingOrderDetail.Result.trim().replace(/[\s,\.,\-,\,]/g, "") == "")
                    && (this._NursingOrderDetail.ResultBloodPressure == null || this._NursingOrderDetail.ResultBloodPressure.trim().replace(/[\s,\.,\-,\,]/g, "") == "")
                    && (this._NursingOrderDetail.Result_Pulse == null || this._NursingOrderDetail.Result_Pulse.trim().replace(/[\s,\.,\-,\,]/g, "") == "")
                    && (this._NursingOrderDetail.Result_SPO2 == null || this._NursingOrderDetail.Result_SPO2.trim().replace(/[\s,\.,\-,\,]/g, "") == ""))
                {
                    throw new Exception((await SystemMessageService.GetMessage(1167)));
                }
                else if ((this._NursingOrderDetail.ProcedureObject["VitalSignType"] != VitalSignType.ANT && this.ttmaskedResult.Visible == true && (this._NursingOrderDetail.Result == null || this._NursingOrderDetail.Result.trim().replace(/[\s,\.,\-,\,]/g, "") == ""))
                    || (this.ResultBySelection.Visible == true && this._NursingOrderDetail.ResultBySelection == null))
                {
                    throw new Exception((await SystemMessageService.GetMessage(1167)));
                }

                ////mask validliği şimdilik böyle kontrol etmek zorunda kaldık
                //if (this.ttmaskedResult.Visible == true && !this.ttmaskedResult.Mask.trim().Equals("") && this._NursingOrderDetail.ProcedureObject["VitalSignType"].toString() != VitalSignType.Respiration.toString() && (this.ttmaskedResult.Mask.trim().replace(/[0-9]/g, "X") != this._NursingOrderDetail.Result.trim().replace(/[0-9]/g, "X")))
                //    throw new Exception('Sonuç alanı istenen kriterlere uygun değil.');

                if (this._NursingOrderDetail.ProcedureObject["VitalSignType"] != null )
                {
                    let res: string[] = null;

                    if (this._NursingOrderDetail.ProcedureObject["VitalSignType"].toString() == VitalSignType.BloodPressure.toString())
                        res = this._NursingOrderDetail.Result.replace(/\s/g, "").split('-');
                    else if (this._NursingOrderDetail.ProcedureObject["VitalSignType"].toString() == VitalSignType.ANT.toString() && this._NursingOrderDetail.ResultBloodPressure != null)
                        res = this._NursingOrderDetail.ResultBloodPressure.replace(/\s/g, "").split('-');

                    if (res != null) {
                        if ((this._NursingOrderDetail.ProcedureObject["VitalSignType"].toString() == VitalSignType.BloodPressure.toString() && (res[0] == "" || res[1] == "")) //ikisi de dolu olmalı
                            || (this._NursingOrderDetail.ProcedureObject["VitalSignType"].toString() == VitalSignType.ANT.toString() && ((res[0] == "" && res[1] != "") || (res[0] != "" && res[1] == ""))))//ikisi de dolu verya ikisi de boş olmalı
                            throw new Exception(i18n("M18375", "Lütfen hem küçük hem büyük tansiyon bilgisi alanlarını doldurunuz."));
                        else if (res[0] != "" && +res[0] <= +res[1])//büyük tansiyon <= küçük tansiyon
                            throw new Exception(i18n("M12154", "Büyük tansiyon küçük tansiyondan küçük olamaz."));
                    }
                }

                //throw new Exception("ismail");
            }
            else if (transDef.ToStateDefID.valueOf() == NursingOrderDetail.NursingOrderDetailStates.Cancelled.id)
            {
                if (this._NursingOrderDetail.Notes == null || this._NursingOrderDetail.Notes.trim().replace(/[\s,\.,\-]/g, "") == "")
                    throw new Exception(i18n("M16562", "İptal sebebi olarak hemşire notunu doldurunuz."));
            }
        }
    }
    protected async PreScript() {
        if (this.nursingOrderDetailFormViewModel.NursingApplicationCurrentState == NursingApplication.NursingApplicationStates.Discharged)
            this.DropStateButton(NursingOrderDetail.NursingOrderDetailStates.Cancelled);
        super.PreScript();
        //this.SetTreatmentMaterialListFilter(<TTObjectDef>TTObjectDefManager.Instance.ObjectDefs["NursingOrderDetailTreatmentMaterial"], <TTVisual.ITTGridColumn>this.UsedMaterial.Columns["MMaterial"]);
    }

    // *****Method declarations end *****

    public setInputParam(value: Object) {        
        this._scheduleWorkListDate = Convert.ToDateTime(<any>value);

    }

    // private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        if (value) {
            value.Title = i18n("M15638", "Hemşirelik Uygulamaları Ekranı");
            value.Width = 800;
            value.Height = 350;
        }
        this._modalInfo = value;
    }

    public initViewModel(): void {
        this._TTObject = new NursingOrderDetail();
        this.nursingOrderDetailFormViewModel = new NursingOrderDetailFormViewModel();
        this._ViewModel = this.nursingOrderDetailFormViewModel;
        this.nursingOrderDetailFormViewModel._NursingOrderDetail = this._TTObject as NursingOrderDetail;
        this.nursingOrderDetailFormViewModel._NursingOrderDetail.ProcedureByUser = new ResUser();
        this.nursingOrderDetailFormViewModel._NursingOrderDetail.ProcedureObject = new ProcedureDefinition();
        this.nursingOrderDetailFormViewModel._NursingOrderDetail.ResultBySelection = new VitalSignAndNursingValueDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.nursingOrderDetailFormViewModel = this._ViewModel as NursingOrderDetailFormViewModel;
        that._TTObject = this.nursingOrderDetailFormViewModel._NursingOrderDetail;
        if (this.nursingOrderDetailFormViewModel == null)
            this.nursingOrderDetailFormViewModel = new NursingOrderDetailFormViewModel();
        if (this.nursingOrderDetailFormViewModel._NursingOrderDetail == null)
            this.nursingOrderDetailFormViewModel._NursingOrderDetail = new NursingOrderDetail();
        let procedureByUserObjectID = that.nursingOrderDetailFormViewModel._NursingOrderDetail["ProcedureByUser"];
        if (procedureByUserObjectID != null && (typeof procedureByUserObjectID === "string")) {
            let procedureByUser = that.nursingOrderDetailFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureByUserObjectID.toString());
            if (procedureByUser) {
                that.nursingOrderDetailFormViewModel._NursingOrderDetail.ProcedureByUser = procedureByUser;
            }
        }
        let procedureObjectObjectID = that.nursingOrderDetailFormViewModel._NursingOrderDetail["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.nursingOrderDetailFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
             if (procedureObject) {
                that.nursingOrderDetailFormViewModel._NursingOrderDetail.ProcedureObject = procedureObject;
            }
        }
        let resultBySelectionObjectID = that.nursingOrderDetailFormViewModel._NursingOrderDetail["ResultBySelection"];
        if (resultBySelectionObjectID != null && (typeof resultBySelectionObjectID === 'string')) {
            let resultBySelection = that.nursingOrderDetailFormViewModel.VitalSignAndNursingValueDefinitions.find(o => o.ObjectID.toString() === resultBySelectionObjectID.toString());
             if (resultBySelection) {
                that.nursingOrderDetailFormViewModel._NursingOrderDetail.ResultBySelection = resultBySelection;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(NursingOrderDetailFormViewModel);
  
    }


    public onExecutionDateChanged(event): void {
        if (event != null) {
            if (this._NursingOrderDetail != null && this._NursingOrderDetail.ExecutionDate != event.value) {
                this._NursingOrderDetail.ExecutionDate = event.value;
            }
        }
    }
public onNameResourceChanged(event): void {
    if (this._NursingOrderDetail != null &&
    this._NursingOrderDetail.ProcedureByUser != null && this._NursingOrderDetail.ProcedureByUser.Name != event) {
    this._NursingOrderDetail.ProcedureByUser.Name = event;
}
}
    public onNoteChanged(event): void {
        if (event != null) {
            if (this._NursingOrderDetail != null && this._NursingOrderDetail.Notes != event) {
                this._NursingOrderDetail.Notes = event;
            }
        }
    }

    public onProcedureObjectChanged(event): void {
        if (event != null) {
            if (this._NursingOrderDetail != null && this._NursingOrderDetail.ProcedureObject != event) {
                this._NursingOrderDetail.ProcedureObject = event;
                this._NursingOrderDetail.Result = null; // combo değişince sonucu nullasın
                this.getVitalSignAndNursingValueDefinitionListCount();
            }
        }
    }

    public onResultBySelectionChanged(event): void {
        if (event != null) {
            if (this._NursingOrderDetail != null && this._NursingOrderDetail.ResultBySelection != event) {
                this._NursingOrderDetail.ResultBySelection = event;
            }
        }

    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._NursingOrderDetail != null && this._NursingOrderDetail.WorkListDate != event.value) {
                this._NursingOrderDetail.WorkListDate = event.value;
            }
        }
    }

    public onttmaskedBloodPressureChanged(event): void {
        if (event != null) {
            if (this._NursingOrderDetail != null && this._NursingOrderDetail.ResultBloodPressure != event) {
                this._NursingOrderDetail.ResultBloodPressure = event;
            }
        }
    }

    public onttmaskedResultSPO2Changed(event): void {
        if (event != null) {
            if (this._NursingOrderDetail != null && this._NursingOrderDetail.Result_SPO2 != event) {
                this._NursingOrderDetail.Result_SPO2 = event;
            }
        }
    }

    public onttmaskedResultChanged(event): void {
        if (event != null) {
            if (this._NursingOrderDetail.ProcedureObject["VitalSignType"] != null )
            {
                let flag: boolean = false;
                let value = parseFloat(event.replace(",", "."));
                let vitalSign: string = this._NursingOrderDetail.ProcedureObject["VitalSignType"].toString();
                if (vitalSign == VitalSignType.BloodPressure_Systolic.toString() && this.nursingOrderDetailFormViewModel.VitalSignsValues != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Systolic_MaxValue != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Systolic_MinValue != null)
                {
                    if (value > this.nursingOrderDetailFormViewModel.VitalSignsValues.Systolic_MaxValue)
                    {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Systolic_MaxWarning;
                    } else if (value < this.nursingOrderDetailFormViewModel.VitalSignsValues.Systolic_MinValue)
                    {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Systolic_MinWarning;
                    }

                    //this.messageService.showError("Sistolik Tansiyon; normal değer aralığı olan [" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Systolic_MinValue + "-" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Systolic_MaxValue + "] değerlerinin dışındadır.");

                } else if (vitalSign == VitalSignType.BloodPressure_Diastolic.toString() && this.nursingOrderDetailFormViewModel.VitalSignsValues != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Diastolic_MaxValue != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Diastolic_MinValue != null)
                {
                    if (value > this.nursingOrderDetailFormViewModel.VitalSignsValues.Diastolic_MaxValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Diastolic_MaxWarning;
                    } else if (value < this.nursingOrderDetailFormViewModel.VitalSignsValues.Diastolic_MinValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Diastolic_MinWarning;
                    }


                    //this.messageService.showError("Diastolik Tansiyon; normal değer aralığı olan [" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Diastolic_MinValue + "-" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Diastolic_MaxValue + "] değerlerinin dışındadır.");

                } else if (vitalSign == VitalSignType.Pulse.toString() && this.nursingOrderDetailFormViewModel.VitalSignsValues != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Pulse_MaxValue != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Pulse_MinValue != null)
                {
                    if (value > this.nursingOrderDetailFormViewModel.VitalSignsValues.Pulse_MaxValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Pulse_MaxWarning;
                    } else if (value < this.nursingOrderDetailFormViewModel.VitalSignsValues.Pulse_MinValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Pulse_MinWarning;
                    }

                    //this.messageService.showError("Nabız; normal değer aralığı olan [" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Pulse_MinValue + "-" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Pulse_MaxValue + "] değerlerinin dışındadır.");

                }
                else if (vitalSign == VitalSignType.Respiration.toString() && this.nursingOrderDetailFormViewModel.VitalSignsValues != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Respiration_MaxValue != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Respiration_MinValue != null)
                    {

                    if (value > this.nursingOrderDetailFormViewModel.VitalSignsValues.Respiration_MaxValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Respiration_MaxWarning;
                    } else if (value < this.nursingOrderDetailFormViewModel.VitalSignsValues.Respiration_MinValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Respiration_MinWarning;
                    }
                    //this.messageService.showError("Solunum Sayısı; normal değer aralığı olan [" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Respiration_MinValue + "-" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Respiration_MaxValue + "] değerlerinin dışındadır.");

                } else if (vitalSign == VitalSignType.Temperature.toString() && this.nursingOrderDetailFormViewModel.VitalSignsValues != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Temperature_MaxValue != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Temperature_MinValue != null)
                {
                    if (value > this.nursingOrderDetailFormViewModel.VitalSignsValues.Temperature_MaxValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Temperature_MaxWarning;
                    } else if (value < this.nursingOrderDetailFormViewModel.VitalSignsValues.Temperature_MinValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Temperature_MinWarning;
                    }

                    //this._VitalSignValuesInfo = "[" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Temperature_MinValue + "-" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Temperature_MaxValue + "] ";

                } else if (vitalSign == VitalSignType.SPO2.toString() && this.nursingOrderDetailFormViewModel.VitalSignsValues != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.SPO2_MaxValue != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.SPO2_MinValue != null)
                {
                    if (value > this.nursingOrderDetailFormViewModel.VitalSignsValues.SPO2_MaxValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.SPO2_MaxWarning;
                    } else if (value < this.nursingOrderDetailFormViewModel.VitalSignsValues.SPO2_MinValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.SPO2_MinWarning;
                    }

                    //this.messageService.showError("O2 Saturasyonu; normal değer aralığı olan [" + this.nursingOrderDetailFormViewModel.VitalSignsValues.SPO2_MinValue + "-" + this.nursingOrderDetailFormViewModel.VitalSignsValues.SPO2_MaxValue + "] değerlerinin dışındadır.");

                } else if (vitalSign == VitalSignType.Weight.toString() && this.nursingOrderDetailFormViewModel.VitalSignsValues != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Weight_MaxValue != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Weight_MinValue != null)
                {
                    if (value > this.nursingOrderDetailFormViewModel.VitalSignsValues.Weight_MaxValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Weight_MaxWarning;
                    } else if (value < this.nursingOrderDetailFormViewModel.VitalSignsValues.Weight_MinValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Weight_MinWarning;
                    }

                    //this.messageService.showError("Kilo; normal değer aralığı olan [" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Weight_MinValue + "-" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Weight_MaxValue + "] değerlerinin dışındadır.");

                } else if (vitalSign == VitalSignType.Height.toString() && this.nursingOrderDetailFormViewModel.VitalSignsValues != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Height_MaxValue != null && this.nursingOrderDetailFormViewModel.VitalSignsValues.Height_MinValue != null)
                {
                    if (value > this.nursingOrderDetailFormViewModel.VitalSignsValues.Height_MaxValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Height_MaxWarning;
                    } else if (value < this.nursingOrderDetailFormViewModel.VitalSignsValues.Height_MinValue) {
                        flag = true;
                        this._VitalSignValuesInfo = this.nursingOrderDetailFormViewModel.VitalSignsValues.Height_MinWarning;
                    }

                    //this.messageService.showError("Boy; normal değer aralığı olan [" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Height_MinValue + "-" + this.nursingOrderDetailFormViewModel.VitalSignsValues.Height_MaxValue + "] değerlerinin dışındadır.");

                }


                if (flag)
                    this.ttmaskedResult.BackColor = "#ed8e8e";
                else {
                    this.ttmaskedResult.BackColor = "#ffffff";
                    this._VitalSignValuesInfo = "";
                }
            }



            if (this._NursingOrderDetail != null && this._NursingOrderDetail.Result != event) {
                this._NursingOrderDetail.Result = event;
            }
        }
        else
            this._NursingOrderDetail.Result = null;

    }

    public onttmaskedResultPulseChanged(event): void {
        if (event != null) {
            if (this._NursingOrderDetail != null && this._NursingOrderDetail.Result_Pulse != event) {
                this._NursingOrderDetail.Result_Pulse = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "WorkListDate");
        redirectProperty(this.ExecutionDate, "Value", this.__ttObject, "ExecutionDate");
        redirectProperty(this.ttmaskedResult, "Text", this.__ttObject, "Result");
        redirectProperty(this.Note, "Text", this.__ttObject, "Notes");
	    redirectProperty(this.NameResource, "Text", this.__ttObject, "ProcedureByUser.Name");
        redirectProperty(this.ttmaskedResultPulse, "Text", this.__ttObject, "Result_Pulse");
        redirectProperty(this.ttmaskedBloodPressure, "Text", this.__ttObject, "ResultBloodPressure");
        redirectProperty(this.ttmaskedResultSPO2, "Text", this.__ttObject, "Result_SPO2");
    }

    public initFormControls(): void {

        this.labelNameResource = new TTVisual.TTLabel();
        this.labelNameResource.Text = "Uygulayan";
        this.labelNameResource.Enabled = false;
        this.labelNameResource.Name = "labelNameResource";
        this.labelNameResource.TabIndex = 30;

        this.NameResource = new TTVisual.TTTextBox();
        this.NameResource.BackColor = "#F0F0F0";
        this.NameResource.ReadOnly = true;
        this.NameResource.Name = "NameResource";
        this.NameResource.TabIndex = 29;
        this.NameResource.DataMember = "PROCEDUREBYUSER.NAME";

        this.ttmaskedResult = new TTVisual.TTMaskedTextBox();
        this.ttmaskedResult.Name = "ttmaskedResult";
        this.ttmaskedResult.TabIndex = 28;
        this.ttmaskedResult.Mask = "";
        this.ttmaskedResult.Visible = true;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M20389", "Planlama Zamanı");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 27;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.Enabled = false;
        this.ttdatetimepicker1.ReadOnly = true;
        this.ttdatetimepicker1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 26;

        this.Note = new TTVisual.TTTextBox();
        this.Note.Multiline = true;
        this.Note.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Note.Name = "Note";
        this.Note.TabIndex = 0;

        this.labelExacutionDate = new TTVisual.TTLabel();
        this.labelExacutionDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelExacutionDate.BackColor = "#DCDCDC";
        this.labelExacutionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelExacutionDate.ForeColor = "#000000";
        this.labelExacutionDate.Name = "labelExacutionDate";
        this.labelExacutionDate.TabIndex = 7;

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = i18n("M15653", "Hemşire Notu");
        this.labelNote.BackColor = "#DCDCDC";
        this.labelNote.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelNote.ForeColor = "#000000";
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 1;

        this.ExecutionDate = new TTVisual.TTDateTimePicker();
        this.ExecutionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ExecutionDate.Format = DateTimePickerFormat.Custom;
        this.ExecutionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ExecutionDate.Name = "ExecutionDate";
        this.ExecutionDate.TabIndex = 6;

        this.labelProcedure = new TTVisual.TTLabel();
        this.labelProcedure.Text = i18n("M24168", "Vital Bulgu Ve Hemşirelik İşlemi");
        this.labelProcedure.BackColor = "#DCDCDC";
        this.labelProcedure.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedure.ForeColor = "#000000";
        this.labelProcedure.Name = "labelProcedure";
        this.labelProcedure.TabIndex = 15;

        this.labelResult = new TTVisual.TTLabel();
        this.labelResult.Text = i18n("M22078", "Sonuç");
        this.labelResult.BackColor = "#DCDCDC";
        this.labelResult.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelResult.ForeColor = "#000000";
        this.labelResult.Name = "labelResult";
        this.labelResult.TabIndex = 3;

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.Enabled = false;
        this.ProcedureObject.ListDefName = "VitalSignAndNursingListDefinition";
        this.ProcedureObject.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 14;

        this.ResultBySelection = new TTVisual.TTObjectListBox();
        this.ResultBySelection.LinkedControlName = "ProcedureObject";
        this.ResultBySelection.ListDefName = "VitalSignAndNursingListValueDefinition";
        this.ResultBySelection.Name = "ResultBySelection";
        this.ResultBySelection.TabIndex = 4;
        this.ResultBySelection.Visible = false;
        this.ResultBySelection.AutoCompleteDialogHeight = "100px";

        this.lableSonucCombo = new TTVisual.TTLabel();
        this.lableSonucCombo.Text = i18n("M22078", "Sonuç");
        this.lableSonucCombo.Name = "lableSonucCombo";
        this.lableSonucCombo.TabIndex = 5;
        this.lableSonucCombo.Visible = false;

        this.labelNabız = new TTVisual.TTLabel();
        this.labelNabız.Text = "Nabız";
        this.labelNabız.BackColor = "#DCDCDC";
        this.labelNabız.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelNabız.ForeColor = "#000000";
        this.labelNabız.Name = "labelNabız";
        this.labelNabız.TabIndex = 3;
        this.labelNabız.Visible = false;

        this.ttmaskedResultPulse = new TTVisual.TTMaskedTextBox();
        this.ttmaskedResultPulse.Name = "ttmaskedResultPulse";
        this.ttmaskedResultPulse.TabIndex = 28;
        this.ttmaskedResultPulse.Visible = false;
        this.ttmaskedResultPulse.Mask = "";

        this.ttlabelBloodPressure = new TTVisual.TTLabel();
        this.ttlabelBloodPressure.Text = "Tansiyon";
        this.ttlabelBloodPressure.BackColor = "#DCDCDC";
        this.ttlabelBloodPressure.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelBloodPressure.ForeColor = "#000000";
        this.ttlabelBloodPressure.Name = "ttlabelBloodPressure";
        this.ttlabelBloodPressure.TabIndex = 3;
        this.ttlabelBloodPressure.Visible = false;

        this.ttmaskedBloodPressure = new TTVisual.TTMaskedTextBox();
        this.ttmaskedBloodPressure.Name = "ttmaskedBloodPressure";
        this.ttmaskedBloodPressure.TabIndex = 28;
        this.ttmaskedBloodPressure.Visible = false;
        this.ttmaskedBloodPressure.Mask = "999-999".replace(/\s/g, "");

        this.ttmaskedResultSPO2 = new TTVisual.TTMaskedTextBox();
        this.ttmaskedResultSPO2.Name = "ttmaskedResultSPO2";
        this.ttmaskedResultSPO2.TabIndex = 28;
        this.ttmaskedResultSPO2.Visible = false;
        this.ttmaskedResultSPO2.Mask = "";

        this.Controls = [this.labelNameResource, this.NameResource, this.ttmaskedResult, this.ttlabel1, this.ttdatetimepicker1, this.Note, this.labelExacutionDate, this.labelNote, this.ExecutionDate, this.labelProcedure, this.labelResult, this.ProcedureObject, this.ResultBySelection, this.lableSonucCombo, this.labelNabız, this.ttmaskedResultPulse, this.ttlabelBloodPressure, this.ttmaskedBloodPressure,this.ttmaskedResultSPO2];


    }

    protected async ClientSidePreScript(): Promise<void> {

        super.ClientSidePreScript();

        if (this["NursAppReadOnly"] != null)
            this.nursingOrderDetailFormViewModel.ReadOnly = (this.nursingOrderDetailFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        this.SetResultMask();
        this.ArrangeResultFieldsVisibility();

        let currentDate: Date = (await CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        this.SetExecutionDate(currentDate); //hemşirenin kendi eklediği direktifler için planlama ve uygulama tarih i set edilir

        //tamamlananı silmek isterse not girebilsin diye
        if (this.nursingOrderDetailFormViewModel._NursingOrderDetail.CurrentStateDefID == NursingOrderDetail.NursingOrderDetailStates.Completed) {
            this.Note.ReadOnly = false;
            this.Note.Enabled = true;
            this.IsEntryState = false;
        }
        else if (this.nursingOrderDetailFormViewModel._NursingOrderDetail.CurrentStateDefID == NursingOrderDetail.NursingOrderDetailStates.Execution) {
            this.IsEntryState = true;
        }
        else
            this.IsEntryState = false;
    }

    private async SetExecutionDate(currentDate) {
        if (this.nursingOrderDetailFormViewModel._NursingOrderDetail.IsNew) {
            

            if(this._scheduleWorkListDate == null)//yeni ekranda null yolluyorum çünkü tarih seçeceği bir yetr yok
            {
                this._scheduleWorkListDate= currentDate;
                this._worklistDateReadOnly = false;                
            }
            else    
                this._worklistDateReadOnly = true;                

            this.nursingOrderDetailFormViewModel._NursingOrderDetail.WorkListDate = this._scheduleWorkListDate; //TODO ismail Parametre olarak al tarihi
            this.nursingOrderDetailFormViewModel._NursingOrderDetail.ExecutionDate = this._scheduleWorkListDate; //TODO ismail Parametre olarak al tarihi
            this.ProcedureObject.Enabled = true;
            this.ProcedureObject.ReadOnly = false;
        }
        else if (this.nursingOrderDetailFormViewModel._NursingOrderDetail.ExecutionDate == undefined && this.nursingOrderDetailFormViewModel._NursingOrderDetail.CurrentStateDefID == NursingOrderDetail.NursingOrderDetailStates.Execution)// doktor girdi ve işlem yapılmadı henüz
        {
            this.nursingOrderDetailFormViewModel._NursingOrderDetail.ExecutionDate = currentDate;
        }
    }

    private SetResultMask() {
        if (this.nursingOrderDetailFormViewModel._NursingOrderDetail.ProcedureObject != null) {
            let _procedureObj = <any>this.nursingOrderDetailFormViewModel._NursingOrderDetail.ProcedureObject;
            switch (_procedureObj.VitalSignType) {
                case VitalSignType.BloodPressure:
                    {
                        this.ttmaskedResult.Mask = "999-999".replace(/\s/g, "");
                        //this._resultMask = "00.9-00.9".replace(/\s/g, "");
                        this.labelResult.Text = i18n("M22084", "Sonuç (Büyük Tansiyon-Küçük Tansiyon)");
                        break;
                        //console.log(data.component._textValue.replace(/_/g,""));
                        //console.log(data.value);
                        //console.log(data.component._textValue);
                        //console.log(data.component._textValue.replace(/ _ / g, ""));
                    }
                case VitalSignType.Height:
                    {
                        this.ttmaskedResult.Mask = "999".replace(/\s/g, "");
                        //this._resultMask = "999".replace(/\s/g, "");
                        this.labelResult.Text = i18n("M22080", "Sonuç - Boy");
                        break;
                    }
                case VitalSignType.Weight:
                    {
                        this.ttmaskedResult.Mask = "999".replace(/\s/g, "");
                        //this._resultMask = "999".replace(/\s/g, "");
                        this.labelResult.Text = i18n("M22081", "Sonuç - Kilo");
                        break;
                    }
                case VitalSignType.Temperature:
                case VitalSignType.ANT:
                    {
                        this.ttmaskedResult.Mask = "00,0".replace(/\s/g, "");
                        //this._resultMask = "00,0".replace(/\s/g, "");
                        this.labelResult.Text = i18n("M22079", "Sonuç - Ateş(00,0)");
                        break;
                    }
                case VitalSignType.Pulse:
                    {
                        this.ttmaskedResult.Mask = "";
                        //this._resultMask = "";
                        this.labelResult.Text = i18n("M22082", "Sonuç - Nabız");
                        break;
                    }
                case VitalSignType.Respiration:
                    {
                        this.ttmaskedResult.Mask = "99999999";
                        //this._resultMask = "99999999";
                        this.labelResult.Text = i18n("M22083", "Sonuç - Solunum");
                        break;
                    }
                case VitalSignType.SPO2:
                    {
                        this.ttmaskedResult.Mask = "";
                        //this._resultMask = "";
                        break;
                    }
                default:
                    this.ttmaskedResult.Mask = "";
                    //this._resultMask = "";
                    break;

            }

        }
    }

    private ArrangeResultFieldsVisibility() {
        let _tempProc = <any>this._NursingOrderDetail.ProcedureObject;

        if (_tempProc != null) {
            //VitalSignAndNursingDefinition vitalSignAndNursingDefinition = (VitalSignAndNursingDefinition)this.ProcedureObject.SelectedObject;

            if (_tempProc.DontNeedDataDuringApplication == true) {
                this.labelResult.Visible = false;
                this.ttmaskedResult.Visible = false;
                this._NursingOrderDetail.Result = null; //daha önce girilen değer varsa nullasın

                this.ResultBySelection.Visible = false;
                this._NursingOrderDetail.ResultBySelection = null; //daha önce girilen değer varsa nullasın
                this.lableSonucCombo.Visible = false;

                this.labelNabız.Visible = false;
                this.ttmaskedResultPulse.Visible = false;
                this._NursingOrderDetail.Result_Pulse = null; //daha önce girilen değer varsa nullasın

                this.ttlabelBloodPressure.Visible = false;
                this.ttmaskedBloodPressure.Visible = false;
                this._NursingOrderDetail.ResultBloodPressure = null; //daha önce girilen değer varsa nullasın

                this.ttmaskedResultSPO2.Visible = false;
                this._NursingOrderDetail.Result_SPO2 = null; //daha önce girilen değer varsa nullasın
            }
            else if (this.nursingOrderDetailFormViewModel.VitalSignAndNursingValueDefinitionListCount > 0) {
                this.ttmaskedResult.Visible = false;
                this._NursingOrderDetail.Result = null; //daha önce girilen değer varsa nullasın
                this.labelResult.Visible = false;

                this.labelNabız.Visible = false;
                this.ttmaskedResultPulse.Visible = false;
                this._NursingOrderDetail.Result_Pulse = null; //daha önce girilen değer varsa nullasın

                this.ttlabelBloodPressure.Visible = false;
                this.ttmaskedBloodPressure.Visible = false;
                this._NursingOrderDetail.ResultBloodPressure = null; //daha önce girilen değer varsa nullasın

                this.ttmaskedResultSPO2.Visible = false;
                this._NursingOrderDetail.Result_SPO2 = null; //daha önce girilen değer varsa nullasın

                this.ResultBySelection.Visible = true;
                this.lableSonucCombo.Visible = true;
            }
            else {
                if (_tempProc.VitalSignType == VitalSignType.ANT)
                {
                    this.labelNabız.Visible = true;
                    this.ttmaskedResultPulse.Visible = true;

                    this.ttlabelBloodPressure.Visible = true;
                    this.ttmaskedBloodPressure.Visible = true;

                    this.ttmaskedResultSPO2.Visible = true;
                }
                else {
                    this.labelNabız.Visible = false;
                    this.ttmaskedResultPulse.Visible = false;
                    this._NursingOrderDetail.Result_Pulse = null; //daha önce girilen değer varsa nullasın

                    this.ttlabelBloodPressure.Visible = false;
                    this.ttmaskedBloodPressure.Visible = false;
                    this._NursingOrderDetail.ResultBloodPressure = null; //daha önce girilen değer varsa nullasın

                    this.ttmaskedResultSPO2.Visible = false;
                    this._NursingOrderDetail.Result_SPO2 = null; //daha önce girilen değer varsa nullasın
                }

                this.ttmaskedResult.Visible = true;
                this.labelResult.Visible = true;
                this.ResultBySelection.Visible = false;
                this.lableSonucCombo.Visible = false;
                this._NursingOrderDetail.ResultBySelection = null; //daha önce girilen değer varsa nullasın
            }
        }

    }

    public getVitalSignAndNursingValueDefinitionListCount() {
        let that = this;

        that.httpService.get<any>("/api/NursingOrderDetailService/GetVitalSignAndNursingValueDefListCount?ObjectID=" + this._NursingOrderDetail.ProcedureObject.ObjectID)
            .then(response => {
                that.nursingOrderDetailFormViewModel.VitalSignAndNursingValueDefinitionListCount =  response;
                this.ArrangeResultFieldsVisibility();
                this.SetResultMask();
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

   async  undoNursingOrderDetail() {
        let massage: string = this.nursingOrderDetailFormViewModel._NursingOrderDetail.WorkListDate.toLocaleDateString() + " " + this.nursingOrderDetailFormViewModel._NursingOrderDetail.WorkListDate.toLocaleTimeString() + i18n("M22853", " tarihli ") + i18n("M16911", " işlemi ");
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İşlem Geri Alma',
            massage + i18n("M14750", "geri alınacaktır.Devam etmek istediğinize emin misiniz? "));
        if (result === 'V') {
            ServiceLocator.MessageService.showSuccess(i18n("M14753", "Geri Alma İşleminden Vazgeçildi"));
        }
        else {

            let _DocumentServiceUrl: string = "/api/NursingOrderDetailService/UndoNursingOrderDetail?ObjectId=" + this.nursingOrderDetailFormViewModel._NursingOrderDetail.ObjectID.toString();
            this.httpService.get<Array<EpisodeActionData>>(_DocumentServiceUrl).then(result => {
                ServiceLocator.MessageService.showSuccess("İşlem geri alınmıştır");
                //this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PATIENTINTERVIEWFORM", this.nursingOrderDetailFormViewModel._NursingOrderDetail.ObjectID, null);
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
                this.httpService.episodeActionWorkListSharedService.refreshWorklist(this.isRefreshWorkList);
            }).catch(err => {
                ServiceLocator.MessageService.showError(i18n("M16843", "İşlem geri alınamamıştır.") + err);
            });
        }
    }

}
