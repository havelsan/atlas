//$B790700A
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PatientOnVacationFormViewModel, PatientVacationComponentInfoViewModel, OrderStatus_Input } from './PatientOnVacationFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PatientOnVacation } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { OrdersToCancelParameterViewModel } from './InPatientPhysicianApplicationFormViewModel';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { DatePipe } from '@angular/common';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: 'PatientOnVacationForm',
    templateUrl: './PatientOnVacationForm.html',
    providers: [MessageService,DatePipe]
})
export class PatientOnVacationForm extends TTVisual.TTForm implements OnInit {
    ApproveDoctor: TTVisual.ITTObjectListBox;
    DayCount: TTVisual.ITTTextBox;
    EndDate: TTVisual.ITTDateTimePicker;
    labelApproveDoctor: TTVisual.ITTLabel;
    labelDayCount: TTVisual.ITTLabel;
    labelEndDate: TTVisual.ITTLabel;
    labelRelativesName: TTVisual.ITTLabel;
    labelRelativesPhoneNumber: TTVisual.ITTLabel;
    labelStartDate: TTVisual.ITTLabel;
    labelVacationAdress: TTVisual.ITTLabel;
    RelativesName: TTVisual.ITTTextBox;
    RelativesPhoneNumber: TTVisual.ITTMaskedTextBox;
    StartDate: TTVisual.ITTDateTimePicker;
    VacationAdress: TTVisual.ITTTextBox;
    public statesPanelClass: string = "col-lg-6";
    public _buttonCaption: string = "Yazdır";
    public _buttonIcon: string = "fa fa-print";
    public patientOnVacationFormViewModel: PatientOnVacationFormViewModel = new PatientOnVacationFormViewModel();
    public get _PatientOnVacation(): PatientOnVacation {
        return this._TTObject as PatientOnVacation;
    }
    private PatientOnVacationForm_DocumentUrl: string = '/api/PatientOnVacationService/PatientOnVacationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService,private datePipe: DatePipe, protected modalService: IModalService) {
        super('PATIENTONVACATION', 'PatientOnVacationForm');
        this._DocumentServiceUrl = this.PatientOnVacationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PatientOnVacation();
        this.patientOnVacationFormViewModel = new PatientOnVacationFormViewModel();
        this._ViewModel = this.patientOnVacationFormViewModel;
        this.patientOnVacationFormViewModel._PatientOnVacation = this._TTObject as PatientOnVacation;
        this.patientOnVacationFormViewModel._PatientOnVacation.ApproveDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.patientOnVacationFormViewModel = this._ViewModel as PatientOnVacationFormViewModel;
        that._TTObject = this.patientOnVacationFormViewModel._PatientOnVacation;
        if (this.patientOnVacationFormViewModel == null)
            this.patientOnVacationFormViewModel = new PatientOnVacationFormViewModel();
        if (this.patientOnVacationFormViewModel._PatientOnVacation == null)
            this.patientOnVacationFormViewModel._PatientOnVacation = new PatientOnVacation();
        let approveDoctorObjectID = that.patientOnVacationFormViewModel._PatientOnVacation["ApproveDoctor"];
        if (approveDoctorObjectID != null && (typeof approveDoctorObjectID === "string")) {
            let approveDoctor = that.patientOnVacationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === approveDoctorObjectID.toString());
            if (approveDoctor) {
                that.patientOnVacationFormViewModel._PatientOnVacation.ApproveDoctor = approveDoctor;
            }
        }

    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);

        if(this._PatientOnVacation.StartDate == null || this._PatientOnVacation.EndDate == null)
            throw new Exception("İzin başlangıç ve bitiş zamanlarını doldurmalısınız");

        if(this._PatientOnVacation.VacationAdress == null || this._PatientOnVacation.VacationAdress == "")
            throw new Exception("Lütfen Adres bilgisini doldurunuz");

        if(this._PatientOnVacation.ApproveDoctor == null)
            throw new Exception("Lütfen Doktor bilgisini giriniz");

        if(this._PatientOnVacation.StartDate >= this._PatientOnVacation.EndDate)
            throw new Exception("İzin başlangıç zamanı bitiş zamanından büyük / eşit olamaz");            
        
        if (transDef !== null)
        {
            if (transDef.ToStateDefID.valueOf() !== PatientOnVacation.PatientOnVacationStates.Cancelled.id) {
                let result: string = await ShowBox.Show(1, '&Evet,&Hayır', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", "Hastanın izinden döndüğü kayıt edilecektir. Emin misiniz?" , 1);

                if(result ==="CANCEL")
                    throw new Exception("İşlemden Vazgeçildi");                  
            }
        }  
        else if(this._PatientOnVacation.CurrentStateDefID == PatientOnVacation.PatientOnVacationStates.OnVacation){//kaydet butonu
            let _count =this._PatientOnVacation.DayCount != undefined ?this._PatientOnVacation.DayCount:this._PatientOnVacation.EndDate.getDate()-this._PatientOnVacation.StartDate.getDate();
            let result: string = await ShowBox.Show(1, '&Evet,&Hayır', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", "Hasta "+this.datePipe.transform(this._PatientOnVacation.StartDate, 'dd.MM.yyyy HH:mm')+" tarihinden itibaren "+_count+" gün izinli olarak çıkışı yapılacak ve işlem girişi engellenecektir. Emin misiniz?", 1);

            if(result ==="CANCEL")
                throw new Exception("İşlemden Vazgeçildi");
            else
            {
                //  this.CheckOrdersToCancel().then(result => {
                //     let modalActionResult = result as OrderStatus_Input
                //     if (modalActionResult != null && modalActionResult.returnMessage != "") {

                //         modalActionResult.returnMessage = modalActionResult.returnMessage.replace ("Hastaya Uygulanmayan  Orderlar İptal Edilecektir",'Hasta üzerinde ileri tarihli orderlar mevcuttur.')
                //         TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Order iptali', modalActionResult.returnMessage, 1).then(result2 =>{
                //             if (result2 === 'V') {
                //                 // this.loadPanelOperation(false, '');
                //                 throw new Exception(i18n("M22555", "İzin İşleminden Vazgeçildi"));
                //             }
                //         });
                //         //let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M19737", "Order iptali"),getOrdersToCancelMsg);
                        
                //     }
                // }).catch(err2 => {
                //     this.messageService.showError(err2);
                // });

                let modalActionResult=  await  this.CheckOrdersToCancel();
                    
                if (modalActionResult != null && modalActionResult.returnMessage != "") {

                    modalActionResult.returnMessage = modalActionResult.returnMessage.replace ("Hastaya Uygulanmayan  Orderlar İptal Edilecektir",'Hasta üzerinde ileri tarihli orderlar mevcuttur.').replace("Hastaya Uygulanmayan İleri Tarihli Orderlar İptal Edilecektir.",'Hasta üzerinde ileri tarihli orderlar mevcuttur.');
                    let result2 = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Order iptali', modalActionResult.returnMessage, 1);
                    if (result2 === 'V') {
                        throw new Exception(i18n("M22555", "İzin İşleminden Vazgeçildi"));
                    }
                    
                    //let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M19737", "Order iptali"),getOrdersToCancelMsg);
                    
                }
                
            }

            this.printVacationForm();
                
        }          
            
    }    

    protected async CheckOrdersToCancel():Promise<OrderStatus_Input> {
      
            let that = this;
            let checkOrdersToCancel_DocumentUrl: string = '/api/InPatientPhysicianApplicationService/GetOrdersToCancel';
            let _ordersToCancelParameterViewModel: OrdersToCancelParameterViewModel = new OrdersToCancelParameterViewModel();

            _ordersToCancelParameterViewModel.IsPreDischarge = true;//sadece ileri tarihlileri kontrol etsin
            _ordersToCancelParameterViewModel.DischargeDate = this._PatientOnVacation.StartDate;
            // _ordersToCancelParameterViewModel.InPatientTreatmentClinicAppObjectID = this._PatientOnVacation.InpatientPhysician.ObjectID.toString();

            if (typeof this._PatientOnVacation.InpatientPhysician == "string")
                _ordersToCancelParameterViewModel.InPatientPhysicianAppObjectID = this._PatientOnVacation.InpatientPhysician;
            else
                _ordersToCancelParameterViewModel.InPatientPhysicianAppObjectID = this._PatientOnVacation.InpatientPhysician.ObjectID.toString();
            
            let getOrdersToCancelMsg: string = <string>await this.httpService.post<string>(checkOrdersToCancel_DocumentUrl, _ordersToCancelParameterViewModel);
           
            let rerunObject :OrderStatus_Input =new OrderStatus_Input();
            rerunObject.returnMessage = getOrdersToCancelMsg;
            return rerunObject;    
        

    }

    public static getComponentInfoViewModel(masterActionId: Guid): PatientVacationComponentInfoViewModel {
        let componentInfoViewModel = new PatientVacationComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('cc78827c-768e-4bcd-b5b0-17cda23e7726');
        queryParameters.QueryDefID = new Guid('b6ef8074-258f-45ab-b848-6b0ab7b68d2d'); //CompanionApplicationFormListByMasterAction
        let parameters = {};
        parameters['INPATIENTPHYSICIANAPPLICATION'] = new GuidParam(masterActionId);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.vacationQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PatientOnVacationForm';
        componentInfo.ModuleName = 'YatanHastaModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Yatan_Hasta_Modulu/YatanHastaModule';
        componentInfo.InputParam = new DynamicComponentInputParam(null,new ActiveIDsModel(masterActionId,null,null));
        componentInfoViewModel.vacationComponentInfo = componentInfo;
        
        return componentInfoViewModel;
    }



    public static queryResultLoaded(e: any) {

        //let gridColumnsHeaders = {};
        //gridColumnsHeaders["COMPANIONNAME"] = 'Refakatçi adı'

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "STARTDATE") {
                column.caption = 'İzin Başlangıç';
            }
            if (column.dataField === "ENDDATE") {
                column.caption = "İzin Bitiş";
            }
            if (column.dataField === "RELATIVESNAME") {
                column.caption = "Yakınının Adı";
            }
            if (column.dataField === "RELATIVESPHONENUMBER") {
                column.caption = 'Yakının Telefon Numarası';
            }
            if (column.dataField === "STATENAME") {
                column.caption = 'İzin Durumu';
            }

        }
    }

    printVacationForm() {

        let reportData: DynamicReportParameters = {

            Code: 'VACATIONFORM',
            ReportParams: { ObjectID: this._PatientOnVacation.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "HASTA İZİN FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }


async ngOnInit() {
    await this.load();
}

public onApproveDoctorChanged(event): void {
    if(this._PatientOnVacation != null && this._PatientOnVacation.ApproveDoctor != event) { 
    this._PatientOnVacation.ApproveDoctor = event;
}
}

public onDayCountChanged(event): void {
    if(this._PatientOnVacation != null && this._PatientOnVacation.DayCount != event) { 
    this._PatientOnVacation.DayCount = event;
    
    if((event != null && event != "") &&  parseInt(event.toString(),10) == event && event > 0)
        this._PatientOnVacation.EndDate =this._PatientOnVacation.StartDate.AddDays(parseInt(event.toString(),10));    
}
}

public onEndDateChanged(event): void {
    if(this._PatientOnVacation != null && this._PatientOnVacation.EndDate != event) { 
    this._PatientOnVacation.EndDate = event;
}
}

public onRelativesNameChanged(event): void {
    if(this._PatientOnVacation != null && this._PatientOnVacation.RelativesName != event) { 
    this._PatientOnVacation.RelativesName = event;
}
}

public onRelativesPhoneNumberChanged(event): void {
    if(this._PatientOnVacation != null && this._PatientOnVacation.RelativesPhoneNumber != event) { 
    this._PatientOnVacation.RelativesPhoneNumber = event;
}
}

public onStartDateChanged(event): void {
    if(this._PatientOnVacation != null && this._PatientOnVacation.StartDate != event) { 
    this._PatientOnVacation.StartDate = event;
}
}

public onVacationAdressChanged(event): void {
    if(this._PatientOnVacation != null && this._PatientOnVacation.VacationAdress != event) { 
    this._PatientOnVacation.VacationAdress = event;
}
}

protected redirectProperties() : void {
    redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
    redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
    redirectProperty(this.DayCount, "Text", this.__ttObject, "DayCount");
    redirectProperty(this.VacationAdress, "Text", this.__ttObject, "VacationAdress");
    redirectProperty(this.RelativesName, "Text", this.__ttObject, "RelativesName");
    redirectProperty(this.RelativesPhoneNumber, "Text", this.__ttObject, "RelativesPhoneNumber");
}

public initFormControls() : void {
    this.labelApproveDoctor = new TTVisual.TTLabel();
    this.labelApproveDoctor.Text = "Onaylayan Doktor";
    this.labelApproveDoctor.Name = "labelApproveDoctor";
    this.labelApproveDoctor.TabIndex = 13;

    this.ApproveDoctor = new TTVisual.TTObjectListBox();
    this.ApproveDoctor.ListDefName = "SpecialistDoctorListDefinition";
    this.ApproveDoctor.Name = "ApproveDoctor";
    this.ApproveDoctor.TabIndex = 12;

    this.labelRelativesPhoneNumber = new TTVisual.TTLabel();
    this.labelRelativesPhoneNumber.Text = "Telefon Numarası";
    this.labelRelativesPhoneNumber.Name = "labelRelativesPhoneNumber";
    this.labelRelativesPhoneNumber.TabIndex = 11;

    this.RelativesPhoneNumber = new TTVisual.TTMaskedTextBox();
    this.RelativesPhoneNumber.Mask = "000 0000000";
    this.RelativesPhoneNumber.Name = "RelativesPhoneNumber";
    this.RelativesPhoneNumber.TabIndex = 10;

    this.RelativesName = new TTVisual.TTTextBox();
    this.RelativesName.Name = "RelativesName";
    this.RelativesName.TabIndex = 8;

    this.VacationAdress = new TTVisual.TTTextBox();
    this.VacationAdress.Multiline = true;
    this.VacationAdress.Name = "VacationAdress";
    this.VacationAdress.TabIndex = 6;

    this.DayCount = new TTVisual.TTTextBox();
    this.DayCount.Name = "DayCount";
    this.DayCount.IsNonNumeric=false;
    this.DayCount.TabIndex = 4;

    this.labelRelativesName = new TTVisual.TTLabel();
    this.labelRelativesName.Text = "Yakınının Adı";
    this.labelRelativesName.Name = "labelRelativesName";
    this.labelRelativesName.TabIndex = 9;

    this.labelVacationAdress = new TTVisual.TTLabel();
    this.labelVacationAdress.Text = "İzni Geçireceği Adres";
    this.labelVacationAdress.Name = "labelVacationAdress";
    this.labelVacationAdress.TabIndex = 7;

    this.labelDayCount = new TTVisual.TTLabel();
    this.labelDayCount.Text = "Gün Sayısı";
    this.labelDayCount.Name = "labelDayCount";
    this.labelDayCount.TabIndex = 5;

    this.labelEndDate = new TTVisual.TTLabel();
    this.labelEndDate.Text = "İzin Bitiş Tarihi";
    this.labelEndDate.Name = "labelEndDate";
    this.labelEndDate.TabIndex = 3;

    this.EndDate = new TTVisual.TTDateTimePicker();
    this.EndDate.Format = DateTimePickerFormat.Custom;
    this.EndDate.Name = "EndDate";
    this.EndDate.TabIndex = 2;
    this.EndDate.CustomFormat = "dd.MM.yyyy HH:mm";

    this.labelStartDate = new TTVisual.TTLabel();
    this.labelStartDate.Text = "İzin Başlangıç Tarihi";
    this.labelStartDate.Name = "labelStartDate";
    this.labelStartDate.TabIndex = 1;

    this.StartDate = new TTVisual.TTDateTimePicker();
    this.StartDate.Format = DateTimePickerFormat.Long;
    this.StartDate.Name = "StartDate";
    this.StartDate.TabIndex = 0;
    // this.StartDate.CustomFormat = "dd.MM.yyyy HH:mm";

    this.Controls = [this.labelApproveDoctor, this.ApproveDoctor, this.labelRelativesPhoneNumber, this.RelativesPhoneNumber, this.RelativesName, this.VacationAdress, this.DayCount, this.labelRelativesName, this.labelVacationAdress, this.labelDayCount, this.labelEndDate, this.EndDate, this.labelStartDate, this.StartDate];

}


}
