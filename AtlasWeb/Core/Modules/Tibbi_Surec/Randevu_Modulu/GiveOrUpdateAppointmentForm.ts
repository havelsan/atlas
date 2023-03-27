//$C43BBD73
import { Component, OnInit, NgZone } from '@angular/core';
import { AppointmentFormViewModel, AppointmentToSaveDVO } from './AppointmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { PhoneTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { MernisPatientModel } from "../Kayit_Kabul_Modulu/PatientAdmissionFormViewModel";
import { CommonHelper } from 'app/Helper/CommonHelper';

import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
@Component({
    selector: 'GiveOrUpdateAppointmentForm',
    templateUrl: './GiveOrUpdateAppointmentForm.html',
    providers: [MessageService]
})
export class GiveOrUpdateAppointmentForm extends TTVisual.TTForm implements OnInit, IModal {

    currentDate: Date = new Date(Date.now());
    patientSearchFormVisible: boolean = false;
    appointmentDefinitionDisabled: boolean = true;
    appointmentCarrierDisabled: boolean = true;
    appointmentTypeDisabled: boolean = true;
    masterResourceDisabled: boolean = true;
    subResourceDisabled: boolean = true;
    appDateDisabled: boolean = true;
    startTimeDisabled: boolean = true;
    endTimeDisabled: boolean = true;

    private _txtPatientIsDisabled: boolean;

    public get txtPatientIsDisabled(): boolean {
        if (this.appointmentFormViewModel.currentPatient != null || this.appointmentFormViewModel.currentPatient != undefined)
            this._txtPatientIsDisabled = true;
        else
            this._txtPatientIsDisabled = false;
            return this._txtPatientIsDisabled;
    }

    public set txtPatientIsDisabled(value: boolean) {
        this._txtPatientIsDisabled = value;
    }
    MobilePhone: TTVisual.ITTMaskedTextBox;

    public appointmentFormViewModel: AppointmentFormViewModel = new AppointmentFormViewModel();
    public get _Appointment(): Appointment {
        return this._TTObject as Appointment;
    }
    private GiveOrUpdateAppointmentForm_DocumentUrl: string = '/api/AppointmentService/AppointmentForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private modalStateService: ModalStateService,
                protected ngZone: NgZone) {
        super('APPOINTMENT', 'GiveOrUpdateAppointmentForm');
        this._DocumentServiceUrl = this.GiveOrUpdateAppointmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    protected isLoadViewModel(): boolean {
        return false;
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public setInputParam(value: AppointmentFormViewModel) {
        this.appointmentFormViewModel = value;
        if (this.appointmentFormViewModel._myOldAppointment) {
            this.appointmentFormViewModel._Appointment.Notes = this.appointmentFormViewModel._myOldAppointment.notes;
            this.patientSearchFormVisible = false;
            this.appointmentDefinitionDisabled = true;
            this.appointmentCarrierDisabled = true;
            this.appointmentTypeDisabled = true;
            this.masterResourceDisabled = true;
            this.subResourceDisabled = true;
            this.appDateDisabled = false;
            this.startTimeDisabled = false;
            this.endTimeDisabled = false;
        }
        else if (this.appointmentFormViewModel.selectedAppointmentSchedule) {
            if (this.appointmentFormViewModel.currentPatient)
                this.patientSearchFormVisible = false;
            else
                this.patientSearchFormVisible = true;
            this.appointmentDefinitionDisabled = true;
            this.appointmentCarrierDisabled = true;
            this.appointmentTypeDisabled = true;
            this.masterResourceDisabled = true;
            this.subResourceDisabled = true;
            this.appDateDisabled = true;
            this.startTimeDisabled = true;
            this.endTimeDisabled = true;
        }
        else if (this.appointmentFormViewModel.selectedAppointmentListItem) {
            this.appointmentFormViewModel._Appointment.Notes = this.appointmentFormViewModel.selectedAppointmentListItem.notes;
            this.patientSearchFormVisible = false;
            this.appointmentDefinitionDisabled = true;
            this.appointmentCarrierDisabled = true;
            this.appointmentTypeDisabled = true;
            this.masterResourceDisabled = true;
            this.subResourceDisabled = true;
            this.appDateDisabled = false;
            this.startTimeDisabled = false;
            this.endTimeDisabled = false;
        }
        else
        {
            this.patientSearchFormVisible = true;
            this.appointmentDefinitionDisabled = true;
            this.appointmentCarrierDisabled = true;
            this.appointmentTypeDisabled = true;
            this.masterResourceDisabled = true;
            this.subResourceDisabled = true;
            this.appDateDisabled = true;
            this.startTimeDisabled = true;
            this.endTimeDisabled = true;
        }
        if (value.currentPatient)
            this.txtPatientIsDisabled = true;
        else
            this.txtPatientIsDisabled = false;
    }
    public async save() {
        await super.save();
        //this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DrugOrderDetail);
    }

    public cancel() {
        ServiceLocator.MessageService.showError(i18n("M26217", "İşlemden vazgeçildi."));
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = this.appointmentFormViewModel._Appointment;
        this._ViewModel = this.appointmentFormViewModel;
        this.txtPatientIsDisabled = true;
    }
    protected loadViewModelForGiveOrUpdateAppointment() {
        let that = this;
        that.appointmentFormViewModel = this._ViewModel as AppointmentFormViewModel;

        that._TTObject = this.appointmentFormViewModel._Appointment;
        if (that.appointmentFormViewModel == null)
            that.appointmentFormViewModel = new AppointmentFormViewModel();

        if (that.appointmentFormViewModel._Appointment == null)
            that.appointmentFormViewModel._Appointment = new Appointment();

        let appointmentDefinitionObjectID = that.appointmentFormViewModel._Appointment["AppointmentDefinition"];
        if (appointmentDefinitionObjectID && that.appointmentFormViewModel.AppointmentDefinitionList) {
            let appointmentDefinition = that.appointmentFormViewModel.AppointmentDefinitionList.find(o => o.ObjectID.toString() === appointmentDefinitionObjectID.toString());
            that.appointmentFormViewModel._Appointment.AppointmentDefinition = appointmentDefinition;
        }

        let appointmentCarrierObjectID = that.appointmentFormViewModel._Appointment["AppointmentCarrier"];
        if (appointmentCarrierObjectID && that.appointmentFormViewModel.AppointmentCarrierList) {
            let appointmentCarrier = that.appointmentFormViewModel.AppointmentCarrierList.find(o => o.ObjectID.toString() === appointmentCarrierObjectID.toString());
            that.appointmentFormViewModel._Appointment.AppointmentCarrier = appointmentCarrier;
        }
        if (that.appointmentFormViewModel.AppointmentType) {
            let appointmentTypeObjectID = that.appointmentFormViewModel.AppointmentType.AppointmentType["ObjectID"];
            if (appointmentTypeObjectID && that.appointmentFormViewModel.AppointmentTypeList) {
                let appointmentType = that.appointmentFormViewModel.AppointmentTypeList.find(o => o.AppointmentType.ObjectID.toString() === appointmentTypeObjectID.toString());
                that.appointmentFormViewModel._Appointment.AppointmentType = appointmentType.AppointmentType.Type;
                that.appointmentFormViewModel.AppointmentType = appointmentType;
            }
        }

        let masterResourceObjectID = that.appointmentFormViewModel._Appointment["MasterResource"];
        if (masterResourceObjectID && that.appointmentFormViewModel.MasterResourceList) {
            let masterResource = that.appointmentFormViewModel.MasterResourceList.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            that.appointmentFormViewModel._Appointment.MasterResource = masterResource;
        }

        let resourceObjectID = that.appointmentFormViewModel._Appointment["Resource"];
        if (resourceObjectID && that.appointmentFormViewModel.SubResourceList) {
            let resource = that.appointmentFormViewModel.SubResourceList.find(o => o.ObjectID.toString() === resourceObjectID.toString());
            that.appointmentFormViewModel._Appointment.Resource = resource;
        }

        let startTime: Date = (Convert.ToDateTime(that.appointmentFormViewModel._Appointment.StartTime));
        let endTime: Date = (Convert.ToDateTime(that.appointmentFormViewModel._Appointment.EndTime));

        that.appointmentFormViewModel._Appointment.StartTime = new Date(startTime.getFullYear(), startTime.getMonth(), startTime.getDate(), startTime.getHours(), startTime.getMinutes(), 0);
        that.appointmentFormViewModel._Appointment.EndTime = new Date(endTime.getFullYear(), endTime.getMonth(), endTime.getDate(), endTime.getHours(), endTime.getMinutes(), 0);

    }
    //protected loadViewModelForAppointmentListForm() {
    //    let that = this;
    //    that.appointmentFormViewModel = this._ViewModel as AppointmentFormViewModel;

    //    that._TTObject = this.appointmentFormViewModel.selectedAppointmentListItem.appointment;

    //    //if (that.appointmentFormViewModel._Appointment == null)
    //        that.appointmentFormViewModel._Appointment = that.appointmentFormViewModel.selectedAppointmentListItem.appointment;

    //    let appointmentDefinitionObjectID = that.appointmentFormViewModel._Appointment["AppointmentDefinition"];
    //    if (appointmentDefinitionObjectID && that.appointmentFormViewModel.AppointmentDefinitionList) {
    //        let appointmentDefinition = that.appointmentFormViewModel.AppointmentDefinitionList.find(o => o.ObjectID.toString() === appointmentDefinitionObjectID.toString());
    //        that.appointmentFormViewModel._Appointment.AppointmentDefinition = appointmentDefinition;
    //    }

    //    let appointmentCarrierObjectID = that.appointmentFormViewModel._Appointment["AppointmentCarrier"];
    //    if (appointmentCarrierObjectID && that.appointmentFormViewModel.AppointmentCarrierList) {
    //        let appointmentCarrier = that.appointmentFormViewModel.AppointmentCarrierList.find(o => o.ObjectID.toString() === appointmentCarrierObjectID.toString());
    //        that.appointmentFormViewModel._Appointment.AppointmentCarrier = appointmentCarrier;
    //    }
    //    if (that.appointmentFormViewModel.AppointmentType) {
    //        let appointmentTypeObjectID = that.appointmentFormViewModel.AppointmentType.AppointmentType["ObjectID"];
    //        if (appointmentTypeObjectID && that.appointmentFormViewModel.AppointmentTypeList) {
    //            let appointmentType = that.appointmentFormViewModel.AppointmentTypeList.find(o => o.AppointmentType.ObjectID.toString() === appointmentTypeObjectID.toString());
    //            that.appointmentFormViewModel._Appointment.AppointmentType = appointmentType.AppointmentType.Type;
    //            that.appointmentFormViewModel.AppointmentType = appointmentType;
    //        }
    //    }

    //    let masterResourceObjectID = that.appointmentFormViewModel._Appointment["MasterResource"];
    //    if (masterResourceObjectID && that.appointmentFormViewModel.MasterResourceList) {
    //        let masterResource = that.appointmentFormViewModel.MasterResourceList.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
    //        that.appointmentFormViewModel._Appointment.MasterResource = masterResource;
    //    }

    //    let resourceObjectID = that.appointmentFormViewModel._Appointment["Resource"];
    //    if (resourceObjectID && that.appointmentFormViewModel.SubResourceList) {
    //        let resource = that.appointmentFormViewModel.SubResourceList.find(o => o.ObjectID.toString() === resourceObjectID.toString());
    //        that.appointmentFormViewModel._Appointment.Resource = resource;
    //    }

    //    that.appointmentFormViewModel._Appointment.Patient = <Patient>that.appointmentFormViewModel.selectedAppointmentListItem.Patient;
    //    that.appointmentFormViewModel._Appointment.AppDate = that.appointmentFormViewModel.selectedAppointmentListItem.AppDate;
    //    that.appointmentFormViewModel._Appointment.StartTime = that.appointmentFormViewModel.selectedAppointmentListItem.StartTime;
    //    that.appointmentFormViewModel._Appointment.EndTime = that.appointmentFormViewModel.selectedAppointmentListItem.EndTime;
    //    that.appointmentFormViewModel._Appointment.Notes = that.appointmentFormViewModel.selectedAppointmentListItem.Notes;
    //    that.appointmentFormViewModel._Appointment.Resource = that.appointmentFormViewModel.selectedAppointmentListItem.Resource;

    //    let startTime: Date = (Convert.ToDateTime(that.appointmentFormViewModel._Appointment.StartTime));
    //    let endTime: Date = (Convert.ToDateTime(that.appointmentFormViewModel._Appointment.EndTime));

    //    that.appointmentFormViewModel._Appointment.StartTime = new Date(startTime.getFullYear(), startTime.getMonth(), startTime.getDate(), startTime.getHours(), startTime.getMinutes(), 0);
    //    that.appointmentFormViewModel._Appointment.EndTime = new Date(endTime.getFullYear(), endTime.getMonth(), endTime.getDate(), endTime.getHours(), endTime.getMinutes(), 0);
    //}
    protected loadViewModel() {
        //if (this.appointmentFormViewModel && this.appointmentFormViewModel.selectedAppointmentListItem)
        //    this.loadViewModelForAppointmentListForm();
        //else
            this.loadViewModelForGiveOrUpdateAppointment();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(AppointmentFormViewModel);
  
    }


    keyDownForNumericControl(event: any) {
        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }

    public onMobilePhoneChanged(event): void {
        if (event != null) {
            if (this.appointmentFormViewModel != null && this.appointmentFormViewModel.PhoneNumber != event) {
                this.appointmentFormViewModel.PhoneNumber = event;
            }
        }
    }

    public async onAppDateChanged(event) {
        if (event) {
            if (event.previousValue) {
                let currDate: Date = new Date(event.value);
                this.currentDate = currDate;
                this.appointmentFormViewModel._Appointment.StartTime = new Date(currDate.getFullYear(), currDate.getMonth(), currDate.getDate(), this.appointmentFormViewModel._Appointment.StartTime.getHours(), this.appointmentFormViewModel._Appointment.StartTime.getMinutes(), 0);
            }
        }
    }

    public async onAppStartTimeChanged(event) {
        let that = this;
        if (event) {
            if (event.previousValue) {
                let currTime: Date = new Date(event.value);
                let previousTime: Date = new Date(event.previousValue);

                if (currTime != previousTime) {
                    //this.appointmentFormViewModel._Appointment.AppDate = currTime;
                    if (this.appointmentFormViewModel.selectedAppointmentSchedule)
                        this.appointmentFormViewModel._Appointment.EndTime = this.appointmentFormViewModel.selectedAppointmentSchedule.endDate;
                    //else if (this.appointmentFormViewModel._myOldAppointment)
                    //    this.appointmentFormViewModel._Appointment.EndTime = this.appointmentFormViewModel._myOldAppointment.endDate;
                    else {
                        setTimeout(function() {
                            that.appointmentFormViewModel._Appointment.EndTime = currTime.AddMinutes(15); //15dk ekleme
                        }, 100);
                    }
                }
            }
        }
    }

    async patientChanged(patient: any) {
        if (patient) {
            this.appointmentFormViewModel.txtPatient = patient.PatientIDandFullName;
            this.appointmentFormViewModel.currentPatient = <Patient>patient;
            this.appointmentFormViewModel._Appointment.Patient = <Patient>patient;
            this.appointmentFormViewModel.TCKNo = (<Patient>patient).UniqueRefNo;
            this.appointmentFormViewModel.PhoneNumber = patient.MobilePhone;
            this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.GSM;
        }
        else {
            this.appointmentFormViewModel.currentPatient = null;
            this.appointmentFormViewModel._Appointment.Patient = null;
            this.appointmentFormViewModel.PhoneNumber = null;
            this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.Home;
            if (CommonHelper.IsNumeric(this.appointmentFormViewModel.txtPatient)) {
                let apiUrlKPS: string = 'api/AppointmentService/GetPatientInfoFromKPS?kimlikNo=' + this.appointmentFormViewModel.txtPatient;
                let res = await this.httpService.get<MernisPatientModel>(apiUrlKPS, MernisPatientModel);
                if (res) {
                    let result = res;
                    let output = <MernisPatientModel>result;
                    if (output.KPSName) {
                        if (output.KPSForeign)
                            this.appointmentFormViewModel.TCKNo = output.KPsForeignUniqueRefNo;
                        else
                            this.appointmentFormViewModel.TCKNo = output.KPSUniqueRefNo;
                        this.appointmentFormViewModel.txtPatient = output.KPSName + " " + output.KPSSurname;
                    }
                    else {
                        this.appointmentFormViewModel.TCKNo = null;
                        this.appointmentFormViewModel.txtPatient = "";
                    }
                }
                else {
                    this.appointmentFormViewModel.TCKNo = null;
                    this.appointmentFormViewModel.txtPatient = "";
                }
            }
        }
    }

    SearchTextChanged(text: string) {
        this.appointmentFormViewModel.txtPatient = text;
        this.appointmentFormViewModel.currentPatient = null;
        this.appointmentFormViewModel._Appointment.Patient = null;
        this.appointmentFormViewModel.TCKNo = null;
        this.appointmentFormViewModel.PhoneNumber = null;
        this.appointmentFormViewModel.osPhoneType = PhoneTypeEnum.GSM;
    }

    async CancelAppointment() {
        let givenAppointment = this.appointmentFormViewModel._myOldAppointment;
        if (givenAppointment) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20724", "Randevu İptali"), await SystemMessageService.GetMessage(292));
            if (result === "H")
                return;
            if (givenAppointment.objectDefName == 'APPOINTMENT') {
                let checkAppForCancelAppUrl: string = 'api/AppointmentService/CheckAppointmentForCancel';
                let body = givenAppointment.objectID;
                this.httpService.post(checkAppForCancelAppUrl, body).then(response => {
                    ServiceLocator.MessageService.showSuccess(i18n("M20725", "Randevu iptali başarı ile tamamlandı."));
                    ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }
            else
                ServiceLocator.MessageService.showError(i18n("M20748", "Randevu türünde olmayan öğeler iptal edilemez."));
        }
        else {
            ServiceLocator.MessageService.showError(i18n("M20748", "Randevu türünde olmayan öğeler iptal edilemez."));
        }
    }

    async SaveAppointment(isBreak: boolean): Promise<void> {
        try {
            let appDate: Date = (Convert.ToDateTime(this.appointmentFormViewModel._Appointment.AppDate));
            this.appointmentFormViewModel._Appointment.StartTime = new Date(appDate.getFullYear(), appDate.getMonth(), appDate.getDate(), this.appointmentFormViewModel._Appointment.StartTime.getHours(), this.appointmentFormViewModel._Appointment.StartTime.getMinutes(), 0);
            this.appointmentFormViewModel._Appointment.EndTime = new Date(appDate.getFullYear(), appDate.getMonth(), appDate.getDate(), this.appointmentFormViewModel._Appointment.EndTime.getHours(), this.appointmentFormViewModel._Appointment.EndTime.getMinutes(), 0);

            let app: Appointment = this.appointmentFormViewModel._Appointment;
            let appStartTime: Date = (Convert.ToDateTime(app.StartTime));
            appStartTime = new Date(appStartTime.getFullYear(), appStartTime.getMonth(), appStartTime.getDate(), appStartTime.getHours(), appStartTime.getMinutes(), 0);
            let appEndTime: Date = (Convert.ToDateTime(app.EndTime));
            appEndTime = new Date(appEndTime.getFullYear(), appEndTime.getMonth(), appEndTime.getDate(), appEndTime.getHours(), appEndTime.getMinutes(), 0);
            let sysDate: Date = new Date(Date.now());
            let currDate: Date = new Date(sysDate.getFullYear(), sysDate.getMonth(), sysDate.getDate(), sysDate.getHours(), sysDate.getMinutes(), 0);

            if (appEndTime < currDate) {
                //TTVisual.InfoBox.Alert("Verilen randevu bugünkü tarihten önce olamaz", MessageIconEnum.ErrorMessage);
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M20741", "Randevu tarihi bugünün tarihinden önce olamaz."), MessageIconEnum.WarningMessage);
                return;
            }

            if (appEndTime < appStartTime) {
                //TTVisual.InfoBox.Alert("Randevunun Bitiş Saati, Başlangıç Saatinden büyük veya ona eşit olmalıdır.", MessageIconEnum.ErrorMessage);
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M30307", "Randevunun Bitiş Saati, Başlangıç Saatinden büyük veya ona eşit olmalıdır."), MessageIconEnum.WarningMessage);
                return;
            }

            if (app.AppointmentDefinition.IsDescReqForNonScheduledApps == true) {
                if (!this.appointmentFormViewModel.selectedAppointmentSchedule && String.isNullOrEmpty(app.Notes)) {
                    //TTVisual.InfoBox.Alert("Plan dışı bir saate randevu veriyorsunuz. Lütfen açıklama giriniz.", MessageIconEnum.ErrorMessage);
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M30308", "Plan dışı bir saate randevu veriyorsunuz. Lütfen açıklama giriniz."), MessageIconEnum.WarningMessage);
                    return;
                }
            }

            if (this.appointmentFormViewModel._Appointment.MasterResource == null) {
                //TTVisual.InfoBox.Alert(this.appointmentFormViewModel._Appointment.AppointmentCarrier.MasterResourceCaption.toString() + " boş olamaz.", MessageIconEnum.ErrorMessage);
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), this.appointmentFormViewModel._Appointment.AppointmentCarrier.MasterResourceCaption.toString() + " " + i18n("M30309", "boş olamaz"), MessageIconEnum.WarningMessage);
                return;
            }

            if (this.appointmentFormViewModel._Appointment.Resource == null) {
                //TTVisual.InfoBox.Alert(this.appointmentFormViewModel._Appointment.AppointmentCarrier.SubResourceCaption.toString() + " boş olamaz.", MessageIconEnum.ErrorMessage);
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), this.appointmentFormViewModel._Appointment.AppointmentCarrier.SubResourceCaption.toString() + " " + i18n("M30309", "boş olamaz"), MessageIconEnum.WarningMessage);
                return;
            }

            if (this.appointmentFormViewModel._Appointment.Patient == null) {
                //Hasta kayıtlı değilse herzaman TC, Telefon ve Telefon tipi istenmeli bence.
                //let mhrsyeBildir: string = (await SystemParameterService.GetParameterValue('MHRSYEBILDIR', 'FALSE'));

                //let appResource = this.appointmentFormViewModel._Appointment.Resource;
                //if (mhrsyeBildir.toUpperCase() == "TRUE" && appResource && (<Resource>appResource) instanceof ResUser) {
                //    let appUniqueRefNoRequired: string = (await SystemParameterService.GetParameterValue('APPOINTMENTUNIQUEREFNOREQUIRED', 'FALSE'));
                //    if ((<ResUser>appResource).SentToMHRS == true || ((<ResUser>appResource).SentToMHRS != true && appUniqueRefNoRequired.toUpperCase() == "TRUE")) {
                if ((!this.appointmentFormViewModel.TCKNo) || (this.appointmentFormViewModel.TCKNo && String.isNullOrEmpty(this.appointmentFormViewModel.TCKNo.toString()) && this.appointmentFormViewModel.TCKNo.toString().length != 11)) {
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M22516", "T.C. numarasını girmediniz!"), MessageIconEnum.ErrorMessage);
                    return;
                }
                if (!this.appointmentFormViewModel.PhoneNumber || (this.appointmentFormViewModel.PhoneNumber && String.isNullOrEmpty(this.appointmentFormViewModel.PhoneNumber.toString()) && this.appointmentFormViewModel.PhoneNumber.toString().Length != 12)) {
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M23141", "Telefon numarasını girmediniz!"), MessageIconEnum.ErrorMessage);
                    return;
                }
                if (this.appointmentFormViewModel.osPhoneType == null) {
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M23143", "Telefon tipi seçmediniz!"), MessageIconEnum.ErrorMessage);
                    return;
                }
                //    }
                //}
            }

            let url: string = "/api/AppointmentService/SaveAppointment";
            let appointmentToSaveDVO: AppointmentToSaveDVO = new AppointmentToSaveDVO();
            appointmentToSaveDVO.appointmentToSave = this.appointmentFormViewModel._Appointment;
            appointmentToSaveDVO.CurrentObject = this.appointmentFormViewModel.CurrentObject;
            appointmentToSaveDVO.isBreak = false;
            appointmentToSaveDVO.nextAvailableAppointmentOrder = 1;
            //TODO
            if (this.appointmentFormViewModel.selectedAppointmentSchedule)
                appointmentToSaveDVO.selectedCalendarItems.push(this.appointmentFormViewModel.selectedAppointmentSchedule);
            appointmentToSaveDVO.txtPatient = this.appointmentFormViewModel.txtPatient;
            appointmentToSaveDVO.TCKNo = this.appointmentFormViewModel.TCKNo;
            appointmentToSaveDVO.PhoneNumber = this.appointmentFormViewModel.PhoneNumber;
            appointmentToSaveDVO.osPhoneType = this.appointmentFormViewModel.osPhoneType;
            appointmentToSaveDVO._carrierList = this.appointmentFormViewModel.AppointmentCarrierList;
            appointmentToSaveDVO._myOldAppointment = this.appointmentFormViewModel._myOldAppointment;
            //TODO
            appointmentToSaveDVO._retAppointment = null;
            appointmentToSaveDVO.AppointmentDef = this.appointmentFormViewModel.AppointmentDef;
            let body = appointmentToSaveDVO;
            this.httpService.post(url, appointmentToSaveDVO).then(response => {
                let result = response;
                ServiceLocator.MessageService.showSuccess(i18n("M16825", "İşlem başarı ile tamamlandı."));
                this.SearchTextChanged("");
                this.appointmentFormViewModel.selectedAppointmentSchedule = null;
                ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
            }).catch(error => {
                TTVisual.InfoBox.Alert("Hata !", error, MessageIconEnum.ErrorMessage);
            });
        } catch (e) {
            TTVisual.InfoBox.Alert("Hata !", e, MessageIconEnum.ErrorMessage);
        }
    }
    public initFormControls(): void {
        this.MobilePhone = new TTVisual.TTMaskedTextBox();
        this.MobilePhone.Name = "MobilePhone";
        this.MobilePhone.TabIndex = 28;
        this.MobilePhone.Mask = "(999)9999999"; //.replace(/\s/g, "");
        this.MobilePhone.Visible = true;
    }
}
