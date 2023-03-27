//$69F23FC6
import { Component, OnInit, NgZone } from '@angular/core';
import { SubactionProcedureFlowableFormViewModel } from "./SubactionProcedureFlowableFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { AuthorizedUser } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { SubactionProcedureFlowableService } from "ObjectClassService/SubactionProcedureFlowableService";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ImportantMedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { Pathology } from 'NebulaClient/Model/AtlasClientModel';
import { PathologySpecialProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { PathologySpecialProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SubActionProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SubactionProcedureFlowable } from 'NebulaClient/Model/AtlasClientModel';
import { SubactionProcedureWithDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { TTObject } from "NebulaClient/StorageManager/InstanceManagement/TTObject";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { TTObjectDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectDef";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { AppointmentFormViewModel } from "../Randevu_Modulu/AppointmentFormViewModel";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';


@Component({
    selector: 'SubactionProcedureFlowableForm',
    templateUrl: './SubactionProcedureFlowableForm.html',
    providers: [MessageService]
})
export class SubactionProcedureFlowableForm extends TTVisual.TTForm implements OnInit {
    public subactionProcedureFlowableFormViewModel: SubactionProcedureFlowableFormViewModel = new SubactionProcedureFlowableFormViewModel();
    public get _SubactionProcedureFlowable(): SubactionProcedureFlowable {
        return this._TTObject as SubactionProcedureFlowable;
    }
    private SubactionProcedureFlowableForm_DocumentUrl: string = '/api/SubactionProcedureFlowableService/SubactionProcedureFlowableForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("SUBACTIONPROCEDUREFLOWABLE", "SubactionProcedureFlowableForm");
        this._DocumentServiceUrl = this.SubactionProcedureFlowableForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    protected _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public isContextSaved: Boolean = false; //TANI için // Kaydetme  tamamlandığında  bu parametre trueya çekilir . Bu parametre Tanı paneline  gönderiliyor  Ana form kaydedildiğinde bu parametre trueya çekiliyor tanı paneli de  remove edilen tanıları view modelden temizliyor

    protected showAppointmentForm(transDef: TTObjectStateTransitionDef): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let data: AppointmentFormViewModel = new AppointmentFormViewModel();
            if (transDef) {
                data.CurrentObjectTransDefID = transDef.StateTransitionDefID;
                data.CurrentObject = this._TTObject;
            }
            else
                data.StarterObject = this._TTObject;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "AppointmentForm";
            componentInfo.ModuleName = "RandevuModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Randevu_Modulu/RandevuModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20714", "Randevu");
            modalInfo.Width = 1500;
            modalInfo.Height = 768;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        try {
            await super.PostScript(transDef);
            if (transDef != null)
            {
                let isAttExists: boolean = await CommonService.IsAppointmentTransitionAttributeExists(transDef.StateTransitionDefID, this._SubactionProcedureFlowable);
                if (isAttExists === true) {
                    let result = await this.showAppointmentForm(transDef);
                    if (result.Result === DialogResult.Cancel) {
                        ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
                        return;
                    }

                    /*if (result.Result === DialogResult.OK) {
                        await super.setState(transDef);
                        ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._SubactionProcedureFlowable);
                    }*/
                }
            }

        } catch (err) {
            ServiceLocator.MessageService.showError(err);
            return;
        }
    }

    protected isRefreshWorkList: boolean = true;
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        this.httpService.episodeActionWorkListSharedService.refreshWorklist(this.isRefreshWorkList);
        //TANI için
        let that = this;
        setTimeout(() => {
            that.isContextSaved = true; // Bu parametre Tanı paneline  gönderiliyor  Ana form kaydedildiğinde bu parametre trueya çekiliyor tanı paneli de bu parametre true ise  remove edilen tanıları view modelden temizliyor
        }, 100);

        setTimeout(() => {
            that.isContextSaved = false; // tekrar tekrar basınca hep çalışsın diye
        }, 100);
    }


    // ***** Method declarations start *****

    async btnSetAuthorizedUser_Click(sender: Object, e: Object): Promise<void> {
        //TODO:COMPILE
        /*
        try {
            if (this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes.containsKey("AddAuthorizedUserButton")) {
                let i: number = Convert.ToInt32(this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["UserType"].Value.toString());
                let userTypeEnum: UserTypeEnum = (await CommonService.GetUserTypeEnumByValue(i));
                this.SetAuthorizedUserBySelecting(this._SubactionProcedureFlowable.MasterResource, userTypeEnum, false);
                if (this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"] !== null) {
                    if (this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"].Value !== null) {
                        let stateDefID: Guid = new Guid(this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"].Value.toString());
                        let transDef: TTObjectStateTransitionDef = <TTObjectStateTransitionDef>this._SubactionProcedureFlowable.CurrentStateDef.FindOutoingTransitionDefFromStateDefID(stateDefID);
                        if (DoContextUpdate(transDef))
                            this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
        catch (Ex) {
            TTVisual.InfoBox.Alert(Ex);
        }
        */

    }
    //TODO:COMPILE
    /*
    protected async CheckObjectReportToPrint(objectReportDef: TTObjectReportDef): Promise<boolean> {
        if (Common.CurrentResource.IsPatientSecureAndHasNoRightOfUser(<IEpisodeActionPermission>this._SubactionProcedureFlowable)) {
            return false;
        }
        return true;
    }
    */

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.IfNullSelectProcedureSpeciality();
        this.ShowPatientPrivacyInformation(this._SubactionProcedureFlowable.Episode.Patient);
        //this.ShowImportantMedicalInformation(this._SubactionProcedureFlowable);
    }
    protected async CreateQueueItem(transDef: TTObjectStateTransitionDef): Promise<void> {
        //TODO:COMPILE
        /*
        if (this._SubactionProcedureFlowable.MasterResource instanceof ResPoliclinic && (<ResPoliclinic>this._SubactionProcedureFlowable.MasterResource).PatientCallSystemInUse === true) {
            if (transDef !== null && (await CommonService.IsTransitionAttributeExists(typeof CreateQueueItemAttribute, transDef))) {
                let queueDef: ExaminationQueueDefinition = null;
                queueDef = this.SelectQueue(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable.MasterResource, false);
                if (queueDef === null)
                    throw new Exception((await SystemMessageService.GetMessage(1015)));
                else {
                    let queueUser: ResUser = this.SelectQueueUser(this._SubactionProcedureFlowable.ObjectContext, queueDef, false);
                    if (queueUser !== null) {
                        this.SetAuthorizedUserByQueueUser(queueUser, <SubactionProcedureFlowable>this._SubactionProcedureFlowable);
                        if (this._SubactionProcedureFlowable.AuthorizedUsers.length > 0) {
                            let authorizedUser: AuthorizedUser = this._SubactionProcedureFlowable.AuthorizedUsers[this._SubactionProcedureFlowable.AuthorizedUsers.length - 1];
                            this._SubactionProcedureFlowable.ProcedureDoctor = authorizedUser.User;
                        }
                    }
                    else {
                        let uKey: string = TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Doktor Atama", "Doktor atama yapmadan devam etmek istediğinize emin misiniz?", 2);
                        if (String.isNullOrEmpty(uKey) === true || uKey === "H")
                            throw new Exception((await SystemMessageService.GetMessage(80)));
                    }
                    let isEmergency: boolean = false;
                    if (this._SubactionProcedureFlowable.FromResource !== null) {
                        for (let spg of this._SubactionProcedureFlowable.FromResource.ResourceSpecialities) {
                            if (spg.Speciality !== null)
                                if (spg.Speciality.Code === (await SystemParameterService.GetParameterValue("EMERGENCYSPECIALITYDEFINITIONCODE", "4400")).toString())
                                    isEmergency = true;
                        }
                    }
                    let queueItem: ExaminationQueueItem = null;
                    queueItem = this._SubactionProcedureFlowable.CreateExaminationQueueItem(this._SubactionProcedureFlowable.SubEpisode.PatientAdmission, queueDef, isEmergency);
                    if (queueItem === null)
                        throw new Exception((await SystemMessageService.GetMessageV3(1016, [queueDef.Name.toString()])));
                    else TTVisual.InfoBox.Show(this._SubactionProcedureFlowable.Episode.Patient.RefNo + " " + this._SubactionProcedureFlowable.Episode.Patient.FullName + " hastası," + queueDef.Name + " sırasına eklendi. Sıradaki Toplam Hasta Sayısı : " + queueDef.CurrentItemsCount.toString(), MessageIconEnum.InformationMessage);
                }
            }
        } */
    }
    protected async IfDiagnosisIsRequired(): Promise<void> {
        //TODO:COMPILE
        //this._SubactionProcedureFlowable.DiagnosisIsRequired();
    }
    protected async IfNullSelectProcedureSpeciality(): Promise<void> {
        //TODO:COMPILE
        /*
        if ((await CommonService.IsAttributeExists(typeof NotRequiredProcedureSpecialityAttribute, <TTObject>this._SubactionProcedureFlowable)) === false) {
            if (this._SubactionProcedureFlowable.ProcedureSpeciality === null) {
                if (this._SubactionProcedureFlowable.Episode !== null) {
                    let resource: ResSection = null;
                    let title: string = "";
                    if (this._SubactionProcedureFlowable.SetProcedureSpecialtyBy() === "MASTERRESOURCE") {
                        resource = this._SubactionProcedureFlowable.MasterResource;
                        title = "İşlemin Yapılacağı Uzmanlık Dalını";
                    }
                    else if (this._SubactionProcedureFlowable.SetProcedureSpecialtyBy() === "FROMRESOURCE") {
                        resource = this._SubactionProcedureFlowable.FromResource;
                        title = "İsteğin Yapıldığı Uzmanlık Dalını";
                    }
                    if (resource !== null) {
                        if (resource.ResourceSpecialities.length === 1) {
                            this._SubactionProcedureFlowable.ProcedureSpeciality = resource.ResourceSpecialities[0].Speciality;
                        }
                        else if (resource.ResourceSpecialities.length > 1) {
                            let MSItem: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                            for (let specialityGrid of resource.ResourceSpecialities) {
                                if (!MSItem.IsItemExists(specialityGrid.Speciality.ObjectID.toString())) {
                                    MSItem.AddMSItem(specialityGrid.Speciality.Name, specialityGrid.Speciality.ObjectID.toString(), specialityGrid.Speciality);
                                }
                            }
                            let getTime: boolean = false;
                            while (getTime === false) {
                                title = title + " seçiniz";
                                let key: string = MSItem.GetMSItem(this, title, false, true, false, false, false, true);
                                if (!String.isNullOrEmpty(key)) {
                                    this._SubactionProcedureFlowable.ProcedureSpeciality = <SpecialityDefinition>MSItem.MSSelectedItemObject;   // selectedspecialityList.Values[0];
                                    getTime = true;
                                }
                            }
                        }
                    }
                }
                else {
                    throw new Exception((await SystemMessageService.GetMessage(147)));
                }
            }
        } */
    }
    protected async OnShown(e: Object): Promise<void> {
        //TODO:COMPILE
        /*
        super.OnShown(e);
        if (this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes.containsKey("AddAuthorizedUserButton")) {
            let i: number = Convert.ToInt32(this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["UserType"].Value.toString());
            let userTypeEnumValueDef: TTDataDictionary.EnumValueDef = (await CommonService.GetUserTypeEnumValueDefByValue(i));
            this.DrawSetAuthorizedUserButton(userTypeEnumValueDef.DisplayText + " Ata");
        }
        */
    }
    //protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
    //    //TODO:COMPILE
    //    /*
    //    super.PostScript(transDef);
    //    if (transDef !== null) {
    //        if (transDef.AllAttributes.containsKey("ReasonOfRejectAttribute")) {
    //            let frm: StringEntryForm = new StringEntryForm();
    //            this._SubactionProcedureFlowable.ReasonOfReject = frm.ShowAndGetStringForm("Red Sebebi");
    //        }
    //        if (transDef.ToStateDef.Status === StateStatusEnum.Cancelled) {
    //            let frm: StringEntryForm = new StringEntryForm();
    //            this._SubactionProcedureFlowable.ReasonOfCancel = frm.ShowAndGetStringForm("İşlem İptal Sebebi");
    //        }
    //    } */
    //}
    protected async PrapareFormToShow(frm: TTVisual.TTForm): Promise<void> {
        //TODO:COMPILE
        /*
        frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
        frm.GetTemplates = this.GetTemplates;
        frm.SaveTemplate = this.SaveTemplate;
        frm.TemplateSelected = this.TemplateSelected;
        */
    }
    protected async PrepareFormTitle(): Promise<void> {
        //TODO:COMPILE
        /*
        let episode: Episode = this._SubactionProcedureFlowable.EpisodeAction.Episode;
        if (episode === null) {
            throw new TTException((await SystemMessageService.GetMessage(144)));
        }
        if (episode.Patient !== null)
            this.Text += " - " + episode.Patient.FullName.toLocaleUpperCase();
            */
    }
    protected async PreScript() {
        //TODO:COMPILE

        super.PreScript();
        //this.PrepareFormTitle();
        //TODO:asagıdakı commentlı 2 satır nereye konulacak karar verılecek
        //this.IfDiagnosisIsRequired();
        (await SubactionProcedureFlowableService.CheckPaid(this._SubactionProcedureFlowable));
        //this.DropReportsOfSecurePatient();
        await this.getWarningMessage();

    }

    async getWarningMessage(): Promise<void> {
        if (this._SubactionProcedureFlowable != null) {
            await this.httpService.get<string>("api/SubactionProcedureFlowableService/WarningMessage?subActionProcedureObjectId=" + this._SubactionProcedureFlowable.ObjectID.toString()).then(response => {
                let result: string = <string>(response);
                if (String.isNullOrEmpty(result)) {

                }
            }
            );
        }
    }
    protected async ShowAction_ObjectUpdated(ttObject: TTObject, contextSaved: boolean): Promise<void> {
        ttObject.ObjectContext.Save();
        contextSaved = true;
    }
    public async CreateNewTreatmentDischarge(): Promise<void> {

    }
    public async DrawSetAuthorizedUserButton(buttonTitle: string): Promise<void> {
        //TODO:COMPILE
        //this.AddManualStepButton(buttonTitle, new EventHandler(btnSetAuthorizedUser_Click));
    }
    public async DropReportsOfSecurePatient(): Promise<void> {
        //TODO:COMPILE
        /*
        if (Common.CurrentResource.IsPatientSecureAndHasNoRightOfUser(<IEpisodeActionPermission>this._SubactionProcedureFlowable)) {
            for (let stateReport of this._SubactionProcedureFlowable.CurrentStateDef.ReportDefs) {
                this.DropCurrentStateReport(stateReport.ReportDefID);
            }
        }
        */
    }
    public async GetFullAppointmentDescription(subactionProcedure: SubActionProcedure): Promise<string> {
        //TODO:COMPILE
        /*
        let builder: StringBuilder = new StringBuilder();
        for (let app of (await SubActionProcedureService.GetMyNewAppointments(subactionProcedure.ObjectID))) {
            builder.append("Açıklama : " + app.Notes + "\r\n");
            if (app.BreakAppointment === true)
                builder.append("Zaman  : Saatsiz Randevu \r\n");
            else builder.append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
            if (app.Resource.ObjectDef.Description === null) {
                builder.append(app.Resource.ObjectDef.Name.toString() + " : " + app.Resource.Name + "\r\n");
            }
            else {
                builder.append(app.Resource.ObjectDef.Description.toString() + " : " + app.Resource.Name + "\r\n");
            }
            builder.append(app.ObjectDef.Description + " : " + (app.MasterResource !== null ? app.MasterResource.Name : "") + "\r\n");
            builder.append("Durum  : " + app.CurrentStateDef.toString() + "\r\n");
            let dtDiff: TimeSpan = app.AppDate.Value.Subtract(Date.Now.Date);
            if (dtDiff.TotalDays > -1) {
                if (dtDiff.TotalDays === 0) {
                    dtDiff = app.StartTime.Value.TimeOfDay.Subtract(Date.Now.TimeOfDay);
                    if (dtDiff.TotalMinutes > -1) {
                        if (dtDiff.TotalMinutes < 60)
                            builder.append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalMinutes) + " dakika sonra.\r\n");
                        else builder.append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalHours) + " saat sonra.\r\n");
                    }
                    else {
                        //double nDuration = app.EndTime.Value.Subtract(app.StartTime.Value).TotalHours;
                        //if(nDuration < Math.Abs(dtDiff.TotalHours))
                        if (app.EndTime.Value.TimeOfDay.Subtract(Date.Now.TimeOfDay).TotalMinutes > 0)
                            builder.append("Zamanlama : süresi geçiyor\r\n");
                        else builder.append("Zamanlama : süresi geçmiş\r\n");
                    }
                }
                else builder.append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalDays) + " gün sonra.\r\n");
            }
            else {
                builder.append("Zamanlama : süresi geçmiş\r\n");
            }
            builder.append("Referans No :" + (app.AppointmentID === null ? "" : (app.AppointmentID.Value === null ? "" : app.AppointmentID.Value.toString())));
            builder.append("\r\n");
            builder.append("\r\n");
        }
        return builder.toString();
        */
        return null;
    }
    public async GetFullCompletedAppointmentDescription(subactionProcedure: SubActionProcedure): Promise<string> {
        //TODO:COMPILE
        /*
        let builder: StringBuilder = new StringBuilder();
        for (let app of (await SubActionProcedureService.GetMyCompletedAppointments(subactionProcedure.ObjectID))) {
            builder.append("Açıklama : " + app.Notes + "\r\n");
            if (app.BreakAppointment === true)
                builder.append("Zaman  : Saatsiz Randevu \r\n");
            else builder.append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
            if (app.Resource.ObjectDef.Description === null) {
                builder.append(app.Resource.ObjectDef.Name + " :" + app.Resource.Name + "\r\n");
            }
            else {
                builder.append(app.Resource.ObjectDef.Description + " :" + app.Resource.Name + "\r\n");
            }
            builder.append(app.ObjectDef.Description + " :" + (app.MasterResource !== null ? app.MasterResource.Name : "") + "\r\n");
            builder.append("Durum  :" + app.CurrentStateDef.toString() + "\r\n");
            builder.append("Referans No :" + (app.AppointmentID === null ? "" : (app.AppointmentID.Value === null ? "" : app.AppointmentID.Value.toString())));
            builder.append("\r\n");
            builder.append("\r\n");
        }
        for (let app of (await SubActionProcedureService.GetMyCancelledAppointments(subactionProcedure.ObjectID))) {
            builder.append("Açıklama : " + app.Notes + "\r\n");
            if (app.BreakAppointment === true)
                builder.append("Zaman  : Saatsiz Randevu \r\n");
            else builder.append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
            if (app.Resource.ObjectDef.Description === null) {
                builder.append(app.Resource.ObjectDef.Name + " :" + app.Resource.Name + "\r\n");
            }
            else {
                builder.append(app.Resource.ObjectDef.Description + " :" + app.Resource.Name + "\r\n");
            }
            builder.append(app.ObjectDef.Description + " :" + (app.MasterResource !== null ? app.MasterResource.Name : "") + "\r\n");
            builder.append("Durum  :" + app.CurrentStateDef.toString() + "\r\n");
            builder.append("Referans No :" + (app.AppointmentID === null ? "" : (app.AppointmentID.Value === null ? "" : app.AppointmentID.Value.toString())) + "\r\n");
            builder.append("İptal Sebebi :" + subactionProcedure.ReasonOfCancel);
            builder.append("\r\n");
            builder.append("\r\n");
        }
        return builder.toString();
        */
        return null;
    }
    //TODO:COMPILE
    /*
public async GetStore(treatmentMaterialDef: TTObjectDef): Promise<Store> {

    if (treatmentMaterialDef.AllAttributes.containsKey(typeof StoreUsageAttribute.toString()) === false) {
        return this._SubactionProcedureFlowable.MasterResource.Store;
    }
    else {
        let storeUsageEnum: string = treatmentMaterialDef.Attributes["STOREUSAGEATTRIBUTE"].Parameters["StoreUsage"].Value.toString();
        switch (storeUsageEnum) {
            case "0":
                return null;
            case "1":
                return this._SubactionProcedureFlowable.MasterResource.Store;
            //break;
            case "2":
                return this._SubactionProcedureFlowable.FromResource.Store;
            //break;
            case "3":
                return this._SubactionProcedureFlowable.SecondaryMasterResource.Store;
            // break;
            case "4":
                return Common.CurrentResource.Store;
            // break;
            case "5":
                return (await SubactionProcedureFlowableService.GetSpecialResourceForStore(this._SubactionProcedureFlowable)).Store;
            default:
                return this._SubactionProcedureFlowable.MasterResource.Store;
        }
    }

}*/
    public async RunCellContentClick(rowIndex: number, pathologyTest: Pathology, gridProtocolNumbers: TTVisual.ITTGrid): Promise<void> {
        if (gridProtocolNumbers.CurrentCell === null)
            return;
        switch (gridProtocolNumbers.CurrentCell.OwningColumn.Name) {
            case "AddSpecial":
                let row: TTVisual.ITTGridRow = gridProtocolNumbers.Rows.push() as TTVisual.ITTGridRow;
                {
                    let procedure: PathologySpecialProcedure = <PathologySpecialProcedure>(<TTVisual.ITTGridRow>gridProtocolNumbers.Rows[rowIndex]).TTObject;
                    let def: PathologySpecialProcedureDefinition = <PathologySpecialProcedureDefinition>procedure.ProcedureObject;
                    row.Cells["SubMatPrtNoSuffixNo"].Value = pathologyTest.SubMatPrtNoSuffixNo;
                    if (pathologyTest.SubMatPrtNoSuffixNo != null)
                        row.Cells["SubMatPrtNoString"].Value = pathologyTest.MatPrtNoString + "-" + (pathologyTest.SubMatPrtNoSuffixNo).toString(); // + "-" + def.Qref;
                }
                break;
            case "Print":
                break;
            default:
                break;
        }
    }
    public async RunGridProtocolNumbersCellValueChanged(rowIndex: number, pathologyTest: Pathology, gridProtocolNumbers: TTVisual.ITTGrid): Promise<void> {
        switch (gridProtocolNumbers.CurrentCell.OwningColumn.Name) {
            case "SpecialProcedureDefinition":
                //ITTGridRow row = this.GridProtocolNumbers.Rows.Add();
                {
                    let procedure: PathologySpecialProcedure = <PathologySpecialProcedure>(<TTVisual.ITTGridRow>gridProtocolNumbers.Rows[rowIndex]).TTObject;
                    let def: PathologySpecialProcedureDefinition = <PathologySpecialProcedureDefinition>procedure.ProcedureObject;
                    gridProtocolNumbers.Rows[rowIndex].Cells[0].Value = pathologyTest.MatPrtNoString + "-" + (gridProtocolNumbers.Rows[rowIndex].Cells["SubMatPrtNoSuffixNo"].Value).toString() + "-" + def.Qref;
                }
                break;
            default:
                break;
        }
    }
    public async RunMatPrtNoIncrement(pathologyTest: Pathology, gridProtocolNumbers: TTVisual.ITTGrid): Promise<void> {
        let row: TTVisual.ITTGridRow = gridProtocolNumbers.Rows.push() as TTVisual.ITTGridRow;
        if (pathologyTest.SubMatPrtNoSuffixNo === null)
            pathologyTest.SubMatPrtNoSuffixNo = 1;
        else pathologyTest.SubMatPrtNoSuffixNo++;
        row.Cells["SubMatPrtNoSuffixNo"].Value = pathologyTest.SubMatPrtNoSuffixNo;
        row.Cells[0].Value = pathologyTest.MatPrtNoString + "-" + (row.Cells["SubMatPrtNoSuffixNo"].Value).toString();
    }
    public async SaveContextForNewDiagnose(): Promise<void> {
        this._SubactionProcedureFlowable.ObjectContext.Save();
    }
    public async SelectAppointment(context: TTObjectContext, patient: Patient, multiSelect: boolean): Promise<Appointment> {
        //TODO:COMPILE
        /*
     let recDate: Date = (await CommonService.RecTime()).Date;
     let patientAppList: Array<Appointment> = (await AppointmentService.GetPatientAppointmentsByDate(context, patient.ObjectID, recDate, recDate.AddDays(1)));
     let pMSForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
     for (let app of patientAppList) {
         if (app.Resource !== null) {
             if (app.MasterResource !== null)
                 pMSForm.AddMSItem(app.MasterResource.Name + " - " + app.Resource.Name, app.ObjectID.toString(), app);
             else pMSForm.AddMSItem(app.Resource.Name, app.ObjectID.toString(), app);
         }
         else pMSForm.AddMSItem(app.MasterResource.Name, app.ObjectID.toString(), app);
     }
     let sKey: string;
     if ((await SystemParameterService.GetParameterValue("ForceToSelectAppointment", "FALSE")).toLocaleUpperCase() === "TRUE")
         sKey = pMSForm.GetMSItem(this, "Hastanın aşağıdaki kaynaklarda bugün randevusu var. Hasta, randevusuna geldiyse lütfen seçiniz.", false, true, multiSelect, false, true, true);
     else sKey = pMSForm.GetMSItem(this, "Hastanın aşağıdaki kaynaklarda bugün randevusu var. Hasta, randevusuna geldiyse lütfen seçiniz.", false, true, multiSelect);
     if (String.isNullOrEmpty(sKey)) {
         return null;
     }
     else {
         return <Appointment>pMSForm.MSSelectedItemObject;
     } */
        return null;
    }
    public async SelectQueue(context: TTObjectContext, resource: ResSection, multiSelect: boolean): Promise<ExaminationQueueDefinition> {
        //TODO:COMPILE
        /*
     let appQueueDefinitionList: Array<ExaminationQueueDefinition> = <Array<ExaminationQueueDefinition>>(await ExaminationQueueDefinitionService.GetQueueByResource(context, resource.ObjectID.toString()));
     let pMSForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
     for (let appQueueDefinition of appQueueDefinitionList) { pMSForm.AddMSItem(appQueueDefinition.Name, appQueueDefinition.ObjectID.toString(), appQueueDefinition); }
     let sKey: string;
     if ((await SystemParameterService.GetParameterValue("ForceToSelectQueue", "TRUE")).toLocaleUpperCase() === "TRUE")
         sKey = pMSForm.GetMSItem(this, resource.Name.toString() + " kaynağında hastanın çağırılacağı kuyruğu seçiniz.", false, true, multiSelect, false, true, true);
     else sKey = pMSForm.GetMSItem(this, resource.Name.toString() + " kaynağında hastanın çağırılacağı kuyruğu seçiniz.", false, true, multiSelect);
     if (String.isNullOrEmpty(sKey)) {
         return null;
     }
     else {
         return <ExaminationQueueDefinition>pMSForm.MSSelectedItemObject;
     }
     */
        return null;
    }
    public async SelectQueueUser(context: TTObjectContext, queueDef: ExaminationQueueDefinition, multiSelect: boolean): Promise<ResUser> {
        //TODO:COMPILE
        /*
     if (queueDef !== null) {
         let selectDoctor: boolean = true;
         if ((queueDef.NotAllowToSelectDoctor !== undefined) === true && queueDef.NotAllowToSelectDoctor.Value === true)
             selectDoctor = false;
         if (selectDoctor) {
             let resources: Array<Resource> = queueDef.GetWorkingResources(context);
             let pMSForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
             for (let resource of resources) {
                 if (resource instanceof ResUser) {
                     pMSForm.AddMSItem(resource.Name, resource.ObjectID.toString(), resource);
                 }
             }
             let sKey: string;
             if ((await SystemParameterService.GetParameterValue("ForceToSelectUser", "FALSE")).toLocaleUpperCase() === "TRUE")
                 sKey = pMSForm.GetMSItem(this, queueDef.Name.toString() + " kuyruğunda hastanın atanacağı doktoru seçiniz.", false, true, multiSelect, false, true, true);
             else sKey = pMSForm.GetMSItem(this, queueDef.Name.toString() + " kuyruğunda hastanın atanacağı doktoru seçiniz.", false, true, multiSelect);
             if (String.isNullOrEmpty(sKey)) {
                 return null;
             }
             else {
                 return <ResUser>pMSForm.MSSelectedItemObject;
             }
         }
     }
     return null;*/
        return null;
    }
    public async SelectUser(context: TTObjectContext, userResource: ResSection, userType: UserTypeEnum, multiSelect: boolean): Promise<ResUser> {
        //TODO:COMPILE
        /*
     let userList: Array<ResUser> = <Array<ResUser>>(await ResUserService.GetByUserResourceAndUserType(context, userType, userResource.ObjectID.toString()));
     let pMSForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
     for (let user of userList) { pMSForm.AddMSItem(user.Name, user.ObjectID.toString(), user); }
     let sKey: string = pMSForm.GetMSItem(this, userResource.Name.toString() + "kaynağında işlemi gerçekleştirecek kullanıcıyı seçiniz", false, true, multiSelect);
     if (String.isNullOrEmpty(sKey)) {
         return null;
     }
     else {
         return <ResUser>pMSForm.MSSelectedItemObject;
     }
     */
        return null;
    }
    public async SetAuthorizedUserByQueueUser(queueUser: ResUser, firedAction: SubactionProcedureFlowable): Promise<void> {
        if (queueUser !== null) {
            let authorizedUser: AuthorizedUser = new AuthorizedUser(firedAction.ObjectContext);
            authorizedUser.User = <ResUser>queueUser;
            firedAction.AuthorizedUsers.push(authorizedUser);
        }
    }
    public async SetAuthorizedUserBySelecting(userResource: ResSection, userType: UserTypeEnum, multiSelect: boolean): Promise<void> {
        //TODO:COMPILE
        /*
     let resUser: ResUser = SelectUser(this._SubactionProcedureFlowable.ObjectContext, userResource, userType, multiSelect);
     if (resUser === null) {
         throw new Exception((await SystemMessageService.GetMessage(1038)));
     }
     else {
         let authorizedUser: AuthorizedUser = new AuthorizedUser(this._SubactionProcedureFlowable.ObjectContext);
         authorizedUser.User = <ResUser>resUser;
         this._SubactionProcedureFlowable.AuthorizedUsers.push(authorizedUser);
     }
     */
    }
    //TODO:COMPILE
    /*
 public async SetDiagnosisListFilter(...diagnosisColumns: ITTGridColumn[]): Promise<void> {
     let uo: UserOption = Common.CurrentResource.GetUserOption(UserOptionType.ICDFilter);
     if (uo !== null && uo.Value !== null && uo.Value.toString() === "OPEN") {
         let specialityList: Array<any> = new Array<any>();
         let filterString: string = "";
         let parentGroupIDs: string = "";
         for (let uRes of Common.CurrentResource.UserResources) {
             for (let specGrid of uRes.Resource.ResourceSpecialities) {
                 if (specialityList.Contains(specGrid.Speciality) === false)
                     specialityList.push(specGrid.Speciality);
             }
         }
         for (let speciality of specialityList) {
             let matchingList: Array<any> = (await DiagnoseSpecialityMatchingService.GetBySpeciality(this._SubactionProcedureFlowable.ObjectContext, speciality.ObjectID.toString()));
             for (let dsm of matchingList) {
                 for (let dgm of dsm.Diagnosis) {
                     parentGroupIDs += "'" + dgm.DiagnosisDefinition.ObjectID + "',";
                 }
             }
         }
         if (parentGroupIDs !== "") {
             filterString = " (OBJECTID IN (" + parentGroupIDs.substring(0, parentGroupIDs.length - 1) + "))";
         }
         else filterString = " 1=0";
         for (let diagnosisColumn of diagnosisColumns) {
             (<TTVisual.ITTListBoxColumn>diagnosisColumn).ListFilterExpression = filterString;
         }
     }
 }
 */
    public async SetPreDiagnosisAsSecDiagnosis(subactionProcedureWithDiagnosis: SubactionProcedureWithDiagnosis): Promise<void> {
        //TODO:COMPILE
        /*
     let diagnoseName: string = string.Empty;
     let secDiagnosisNotExists = true;
     for (let preDiagnose of subactionProcedureWithDiagnosis.Diagnosis) {
         if (preDiagnose.DiagnosisType === DiagnosisTypeEnum.Primer)
             diagnoseName += preDiagnose.Diagnose.Code + " " + preDiagnose.Diagnose.Name + "\r\n";
         else {
             secDiagnosisNotExists = false;
             break;
         }
     }
     if (secDiagnosisNotExists) {
         if (!String.isNullOrEmpty(diagnoseName)) {
             if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Tanı Girişi", "Hiç kesin tanı girmediniz.\r\nGirdiğiniz ön tanıların kesinleştirilmesini ister misiniz? \r\nGirilen Ön Tanılar:\r\n" + diagnoseName) === "E") {
                 for (let preDiagnose of subactionProcedureWithDiagnosis.Diagnosis) {
                     if (preDiagnose.DiagnosisType === DiagnosisTypeEnum.Primer) {
                         let secDiagnose: DiagnosisGrid = new DiagnosisGrid(subactionProcedureWithDiagnosis.ObjectContext);
                         secDiagnose.AddToHistory = preDiagnose.AddToHistory;
                         secDiagnose.Diagnose = preDiagnose.Diagnose;
                         secDiagnose.DiagnoseDate = (await CommonService.RecTime());
                         secDiagnose.Episode = preDiagnose.Episode;
                         secDiagnose.EntryActionType = preDiagnose.EntryActionType;
                         secDiagnose.EpisodeAction = preDiagnose.EpisodeAction;
                         secDiagnose.FreeDiagnosis = preDiagnose.FreeDiagnosis;
                         secDiagnose.ImportantMedicalInformation = preDiagnose.ImportantMedicalInformation;
                         secDiagnose.IsMainDiagnose = preDiagnose.IsMainDiagnose;
                         secDiagnose.SubactionProcedure = preDiagnose.SubactionProcedure;
                         secDiagnose.DiagnosisType = DiagnosisTypeEnum.Seconder;
                     }
                 }
             }
             else {
                 throw new Exception((await SystemMessageService.GetMessage(153)));
             }
         }
     }
     */
    }
    public async SetProcedureDoctorAsCurrentResource(): Promise<void> {
        //TODO:COMPILE
        /*
     if (this._SubactionProcedureFlowable.ProcedureDoctor === null && Common.CurrentResource.TakesPerformanceScore === true) {
         this._SubactionProcedureFlowable.ProcedureDoctor = Common.CurrentResource;
     }
     */
    }
    public async SetTreatmentMaterialListFilter(treatmentMaterialDef: TTObjectDef, treatmentMaterialMaterialColumn: TTVisual.ITTGridColumn): Promise<void> {
        //TODO:COMPILE
        /*
     // set edilen depoya göre Malzeme listesinin filtrelenmesi
     let filterString: string = "\"\"";
     //            string filterString = " THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION') ";
     //            if (treatmentMaterialDef.AllAttributes.ContainsKey(typeof(TreatmentMaterialsInculdeDrugDefinitionAttribute).Name.ToString()))
     //            {
     //                filterString = "THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION','DRUGDEFINITION') ";
     //            }

     if (!((await SystemParameterService.GetParameterValue("WORKWITHOUTSTOCK", "FALSE")) === "TRUE")) {
         let store: Store = this.GetStore(treatmentMaterialDef);
         if (store === null)
             filterString = "OBJECTID is null";
         else filterString = " STOCKS.INHELD>0 AND STOCKS.STORE = '" + store.ObjectID.toString() + "'";
     }
     (<TTVisual.ITTListBoxColumn>treatmentMaterialMaterialColumn).ListFilterExpression = filterString;
     */
    }
    public async ShowImportantMedicalInformation(spf: SubactionProcedureFlowable): Promise<void> {
        let episode: Episode = null;
        if (spf.Episode !== null) {
            episode = spf.Episode;
        }
        else if (spf.EpisodeAction !== null) {
            episode = spf.EpisodeAction.Episode;
        }
        if (episode.Patient.ImportantMedicalInformation !== null) {
            if (episode.Patient.ImportantMedicalInformation.WarnAllMedicalPersonnel === true) {
                let importantMedicalInformation: ImportantMedicalInformation = episode.Patient.ImportantMedicalInformation;
                let frm: TTVisual.TTForm = TTVisual.TTForm.GetEditForm(importantMedicalInformation);
                if (frm === null) {
                    TTVisual.InfoBox.Show(i18n("M20023", "Önemli Tıbbi bilgilere form tanımı yapılmadığından işlem açılamamaktadır"));
                }
                else {
                    frm.ShowReadOnly(this.FindForm(), importantMedicalInformation);
                }
            }
        }
    }
    public async ShowPatientPrivacyInformation(patient: Patient): Promise<void> {
        //TODO:COMPILE
        /*
     if (patient.IsPatientPrivacy === true) {
         //Gönderilen hasta için bir daha gösterme check i işaretlendiyse uyarı ekranı gelmesin diye
         if (!Common.CurrentResource.PrivacyPatientNotShownList.Contains(patient.ObjectID)) {
             let frm: WarningMessageForm = new WarningMessageForm();
             frm.CurrentPatient = patient;
             frm.WarningMessage = patient.FullName + " hastası " + patient.PrivacyEndDate.Value.Date.toString() + " tarihine kadar gizli hastadır.\r\n\r\nGizlilik Sebebi :\r\n" + patient.PrivacyReason;
             TTVisual.InfoBox.Show("frm.ShowDialog(this);");
         }
     }
     */
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubactionProcedureFlowable();
        this.subactionProcedureFlowableFormViewModel = new SubactionProcedureFlowableFormViewModel();
        this._ViewModel = this.subactionProcedureFlowableFormViewModel;
        this.subactionProcedureFlowableFormViewModel._SubactionProcedureFlowable = this._TTObject as SubactionProcedureFlowable;
    }

    protected loadViewModel() {
        let that = this;
        that.subactionProcedureFlowableFormViewModel = this._ViewModel as SubactionProcedureFlowableFormViewModel;
        that._TTObject = this.subactionProcedureFlowableFormViewModel._SubactionProcedureFlowable;
        if (this.subactionProcedureFlowableFormViewModel == null)
            this.subactionProcedureFlowableFormViewModel = new SubactionProcedureFlowableFormViewModel();
        if (this.subactionProcedureFlowableFormViewModel._SubactionProcedureFlowable == null)
            this.subactionProcedureFlowableFormViewModel._SubactionProcedureFlowable = new SubactionProcedureFlowable();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(SubactionProcedureFlowableFormViewModel);
  
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
