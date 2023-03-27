//$C3E6631C
import { Component, OnInit, NgZone } from '@angular/core';
import { ActionFormViewModel } from "./ActionFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { AuthorizedUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseAction } from 'NebulaClient/Model/AtlasClientModel';
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';




@Component({
    selector: 'ActionForm',
    templateUrl: './ActionForm.html',
    providers: [MessageService]
})
export class
ActionForm extends TTVisual.TTForm implements OnInit {
    public actionFormViewModel: ActionFormViewModel = new ActionFormViewModel();
    public get _BaseAction(): BaseAction {
        return this._TTObject as BaseAction;
    }
    private ActionForm_DocumentUrl: string = '/api/BaseActionService/ActionForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("BASEACTION", "ActionForm");
        this._DocumentServiceUrl = this.ActionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
       /* if (transDef !== null) {
            if (transDef.AllAttributes.containsKey("ReasonOfRejectAttribute")) {
                let frm: StringEntryForm = new StringEntryForm();
                this._BaseAction.ReasonOfReject = frm.ShowAndGetStringForm("Red Sebebi");
            }
            if (transDef.ToStateDef.Status === StateStatusEnum.Cancelled) {
                let frm: StringEntryForm = new StringEntryForm();
                this._BaseAction.ReasonOfCancel = frm.ShowAndGetStringForm("İşlem İptal Sebebi");
            }
        }*/
    }
    protected async PreScript() {
        super.PreScript();
    }
    public async SelectAppointment(context: TTObjectContext, patient: Patient, multiSelect: boolean): Promise<Appointment> {
        /* let recDate: Date = (await CommonService.RecTime()).Date;
        let patientAppList: Array<Appointment> = (await AppointmentService.GetPatientAdmissionAppointmentsByDate(context, patient.ObjectID, recDate, recDate.AddDays(1)));
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
        }*/return null;
    }
    public async SelectQueue(context: TTObjectContext, resource: ResSection, multiSelect: boolean): Promise<ExaminationQueueDefinition> {
      /* let appQueueDefinitionList: Array<ExaminationQueueDefinition> = <Array<ExaminationQueueDefinition>>(await ExaminationQueueDefinitionService.GetQueueByResource(context, resource.ObjectID.toString()));
        let completedItems: Array<ExaminationQueueItem>;
        let pMSForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let appQueueDefinition of appQueueDefinitionList) {
            completedItems = (await ExaminationQueueItemService.GetCompletedItemsByQueueAndDate(context, appQueueDefinition.ObjectID, Common.RecTime().Date, Common.RecTime().Date.AddDays(1)));
            pMSForm.AddMSItem(appQueueDefinition.Name + " (Sırada " + appQueueDefinition.CurrentItemsCount.toString() + " Hasta, Toplam " + (appQueueDefinition.CurrentItemsCount + completedItems.length).toString() + " Hasta)", appQueueDefinition.ObjectID.toString(), appQueueDefinition);
        }
        let sKey: string;
        if ((await SystemParameterService.GetParameterValue("ForceToSelectQueue", "TRUE")).toLocaleUpperCase() === "TRUE" && !(this instanceof PatientAdmissionForm))
            sKey = pMSForm.GetMSItem(this, resource.Name.toString() + " kaynağında hastanın çağırılacağı kuyruğu seçiniz.", false, true, multiSelect, false, true, true);
        else sKey = pMSForm.GetMSItem(this, resource.Name.toString() + " kaynağında hastanın çağırılacağı kuyruğu seçiniz.", false, true, multiSelect);
        if (String.isNullOrEmpty(sKey)) {
            return null;
        }
        else {
            return <ExaminationQueueDefinition>pMSForm.MSSelectedItemObject;
        }*/return null;
    }
    public async SelectQueueUser(context: TTObjectContext, queueDef: ExaminationQueueDefinition, multiSelect: boolean): Promise<ResUser> {
       /* if (queueDef !== null) {
            let selectDoctor: boolean = true;
            if ((queueDef.NotAllowToSelectDoctor !== undefined) === true && queueDef.NotAllowToSelectDoctor === true)
                selectDoctor = false;
            if (selectDoctor) {
                let resources: Array<Resource> = (await ExaminationQueueDefinitionService.GetWorkingResources(queueDef));
                let pMSForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                for (let resource of resources) {
                    if (resource instanceof ResUser) {
                        pMSForm.AddMSItem(resource.Name, resource.ObjectID.toString(), resource);
                    }
                }
                let sKey: string;
                if ((await SystemParameterService.GetParameterValue("ForceToSelectQueueUser", "FALSE")).toLocaleUpperCase() === "TRUE")
                    sKey = pMSForm.GetMSItem(this, queueDef.Name.toString() + " kuyruğunda hastanın atanacağı doktoru seçiniz.", false, true, multiSelect, false, true, true);
                else sKey = pMSForm.GetMSItem(this, queueDef.Name.toString() + " kuyruğunda hastanın atanacağı doktoru seçiniz.", false, true, multiSelect);
                if (String.isNullOrEmpty(sKey)) {
                    return null;
                }
                else {
                    return <ResUser>pMSForm.MSSelectedItemObject;
                }
            }
        }*/
        return null;
    }
    public async SelectUser(context: TTObjectContext, userResource: ResSection, userType: UserTypeEnum, multiSelect: boolean): Promise<ResUser> {
      /*  let userTypeList: Array<UserTypeEnum> = new Array<UserTypeEnum>();
        userTypeList.push(userType);
        if (userType === UserTypeEnum.Doctor)
            userTypeList.push(UserTypeEnum.Dentist);
        let userList: Array<ResUser> = <Array<ResUser>>ResUser.GetByUserResourceAndUserTypes(context, userResource.ObjectID.toString(), userTypeList);
        let pMSForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of userList) { pMSForm.AddMSItem(user.Name, user.ObjectID.toString(), user); }
        let sKey: string;
        if ((await SystemParameterService.GetParameterValue("ForceToSelectUser", "FALSE")).toLocaleUpperCase() === "TRUE")
            sKey = pMSForm.GetMSItem(this, userResource.Name.toString() + " kaynağında işlemi gerçekleştirecek kullanıcıyı seçiniz", false, true, multiSelect, false, true, true);
        else sKey = pMSForm.GetMSItem(this, userResource.Name.toString() + " kaynağında işlemi gerçekleştirecek kullanıcıyı seçiniz", false, true, multiSelect);
        if (String.isNullOrEmpty(sKey)) {
            return null;
        }
        else {
            return <ResUser>pMSForm.MSSelectedItemObject;
        } */
        return null;
    }
    public async SetAuthorizedUserByQueueUser(queueUser: ResUser, firedAction: BaseAction): Promise<void> {
        if (queueUser !== null) {
            let authorizedUser: AuthorizedUser = new AuthorizedUser(firedAction.ObjectContext);
            authorizedUser.User = <ResUser>queueUser;
            firedAction.AuthorizedUsers.push(authorizedUser);
        }
    }
    public async SetAuthorizedUserBySelecting(userResource: ResSection, userType: UserTypeEnum, multiSelect: boolean): Promise<void> {
        /*let resUser: ResUser = this.SelectUser(this._BaseAction.ObjectContext, userResource, userType, multiSelect);
        if (resUser === null) {
            throw new Exception((await SystemMessageService.GetMessage(1038)));
        }
        else {
            let authorizedUser: AuthorizedUser = new AuthorizedUser(this._BaseAction.ObjectContext);
            authorizedUser.User = <ResUser>resUser;
            this._BaseAction.AuthorizedUsers.push(authorizedUser);
        }*/
    }
    public static async SelectAllMainStoreDefinition(parent: Object): Promise<MainStoreDefinition> {
       /* let mainStoreDefinition: MainStoreDefinition = null;
        let readOnlyObjectContext: TTObjectContext = new TTObjectContext(true);
        let mainStores: Array<MainStoreDefinition> = (await MainStoreDefinitionService.GetAllMainStores(readOnlyObjectContext));
        if (mainStores.length === 1) {
            mainStoreDefinition = mainStores[0];
        }
        else {
            let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let mainStore of mainStores) { mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore); }
            let mkey: Promise<string> = mSelectForm.GetMSItem(parent, "İlgili Ana Depoyu Seçiniz", true);
            if ( mkey== null )
                throw new Exception((await SystemMessageService.GetMessage(371)));
            mainStoreDefinition = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
        } */
        return null;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseAction();
        this.actionFormViewModel = new ActionFormViewModel();
        this._ViewModel = this.actionFormViewModel;
        this.actionFormViewModel._BaseAction = this._TTObject as BaseAction;
    }

    protected loadViewModel() {
        let that = this;
        that.actionFormViewModel = this._ViewModel as ActionFormViewModel;
        that._TTObject = this.actionFormViewModel._BaseAction;
        if (this.actionFormViewModel == null)
            this.actionFormViewModel = new ActionFormViewModel();
        if (this.actionFormViewModel._BaseAction == null)
            this.actionFormViewModel._BaseAction = new BaseAction();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(ActionFormViewModel);
  
    }


    protected redirectProperties(): void {

    }

    public initFormControls(): void {

    }


}
