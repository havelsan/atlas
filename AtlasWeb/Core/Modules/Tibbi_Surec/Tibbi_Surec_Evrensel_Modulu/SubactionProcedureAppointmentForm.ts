//$833EE16D
import { Component, OnInit, NgZone } from '@angular/core';
import { SubactionProcedureAppointmentFormViewModel } from './SubactionProcedureAppointmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { StringBuilder } from 'NebulaClient/System/Text/StringBuilder';
import { SubActionProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SubactionProcedureFlowable } from 'NebulaClient/Model/AtlasClientModel';
import { SubActionProcedureService } from "ObjectClassService/SubActionProcedureService";
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

import { ObjectContextService } from "Fw/Services/ObjectContextService";

@Component({
    selector: 'SubactionProcedureAppointmentForm',
    templateUrl: './SubactionProcedureAppointmentForm.html',
    providers: [MessageService]
})
export class SubactionProcedureAppointmentForm extends TTVisual.TTForm implements OnInit {
    tttextboxDescription: TTVisual.ITTTextBox;
    public subactionProcedureAppointmentFormViewModel: SubactionProcedureAppointmentFormViewModel = new SubactionProcedureAppointmentFormViewModel();
    public get _SubactionProcedureFlowable(): SubactionProcedureFlowable {
        return this._TTObject as SubactionProcedureFlowable;
    }
    private SubactionProcedureAppointmentForm_DocumentUrl: string = '/api/SubactionProcedureFlowableService/SubactionProcedureAppointmentForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected objectContextService: ObjectContextService,
                protected ngZone: NgZone) {
        super('SUBACTIONPROCEDUREFLOWABLE', 'SubactionProcedureAppointmentForm');
        this._DocumentServiceUrl = this.SubactionProcedureAppointmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null)
            this.CompleteMyNewAppoinments(this._SubactionProcedureFlowable);
    }
    protected async PreScript(): Promise<void> {
        let index: number = 0;
        this.tttextboxDescription.Text = '';
        //TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
        //pDescriptionBox.ScrollBars= ScrollBars.Vertical;

        if (this._SubactionProcedureFlowable.GetStateHistory().length > 1) {
            index = this._SubactionProcedureFlowable.GetStateHistory().length - 1;
            if (this._SubactionProcedureFlowable.GetStateHistory()[index].IsUndo === true) {
                this.tttextboxDescription.Text = await this.GetFullCompletedAppointmentDescription(this._SubactionProcedureFlowable);
            }
            else {
                this.tttextboxDescription.Text = await this.GetFullAppointmentDescription(this._SubactionProcedureFlowable);
            }
        }
        else {
            this.tttextboxDescription.Text = await this.GetFullAppointmentDescription(this._SubactionProcedureFlowable);
        }
    }
    public async CompleteMyNewAppoinments(subactionProcedure: SubActionProcedure): Promise<void> {

        let myNewAppointments: Array<Appointment> = new Array<Appointment>();
        myNewAppointments = await SubActionProcedureService.GetMyNewAppointments(subactionProcedure.ObjectID);


        for (let app of myNewAppointments) {
            app.CurrentStateDefID = Appointment.AppointmentStates.Completed;
        }
    }

    protected getResourceId(resource: any): Guid {

        if (resource != null) {
            if (typeof resource === "string") {
                return new Guid(resource);
            }
            else {
                return resource.ObjectID;
            }
        }
        return null;
    }

    public async GetFullAppointmentDescription(subactionProcedure: SubActionProcedure): Promise<string> {

        let builder: StringBuilder = new StringBuilder();

        let result = await SubActionProcedureService.GetMyNewAppointments(subactionProcedure.ObjectID);
        let appointmentList = result as Array<Appointment>;

        for (let app of appointmentList) {
            builder.append(i18n("M10470", "Açıklama : ") + app.Notes + '\r\n');
            if (app.BreakAppointment === true)
                builder.append('Zaman  : Saatsiz Randevu \r\n');
            else if (app.AppDate != null && app.StartTime != null && app.EndTime != null)
                builder.append(i18n("M24751", "Zaman  : ") + app.AppDate.toLocaleDateString() + ' ' + app.StartTime.toLocaleTimeString() + ' - ' + app.EndTime.toLocaleTimeString() + '\r\n');

            //let resource: Resource =
            //    await this.objectContextService.getObject<Resource>(this.getResourceId(app.Resource), Resource.ObjectDefID, Resource);
            if (app.Resource.Name !== null && app.Resource.ObjectDef) {
                builder.append(app.Resource.ObjectDef.Name.toString() + ' : ' + app.Resource.Name + '\r\n');
            }

            //let masterRes: Resource;
            //await this.objectContextService.getObject<Resource>(this.getResourceId(app.MasterResource), new Guid("a5f8f664-848c-431c-b33c-800364d31093"), Resource).then(result => {
            //    builder.append(resource.Name + ' : ' + (app.MasterResource !== null ? masterRes : '') + '\r\n');

            //}).catch(err => {
            //    this.messageService.showError(err);
            //});

            //builder.append(app.ObjectDef.Name + ' : ' + (app.MasterResource !== null ? app.MasterResource.Name : '') + '\r\n');



            //TODO: tekrar bakılacak sımdılık kapatıldı, tarıhler ıle ılgılı sorun var
            /*
            builder.append('Durum  : ' + app.CurrentStateDefID.toString() + '\r\n');
            //let appDate: Date = new Date(app.AppDate.Value);
            let appDate: Date = new Date(app.AppDate);
            let currentDate: Date = new Date(Date.now());
            //let appStartTime: Date = new Date(app.StartTime.Value);
            let appStartTime: Date = new Date(app.StartTime);
            //let dtDiff: any = appDate.Subtract(currentDate.getDate());
            let dtDiff: any = appDate.Subtract(currentDate.getDate());
            if (dtDiff.TotalDays > -1) {
                if (dtDiff.TotalDays === 0) {
                    dtDiff = appStartTime.Subtract(currentDate.getDate());
                    if (dtDiff.TotalMinutes > -1) {
                        if (dtDiff.TotalMinutes < 60)
                            builder.append('Zamanlama : Randevu ' + dtDiff.TotalMinutes + ' dakika sonra.\r\n');
                        else builder.append('Zamanlama : Randevu ' + dtDiff.TotalHours + ' saat sonra.\r\n');
                    }
                    else {
                        //double nDuration = app.EndTime.Value.Subtract(app.StartTime.Value).TotalHours;
                        //if(nDuration < Math.Abs(dtDiff.TotalHours))

                        let endDate: Date = new Date(app.EndTime.Value);
                        let dtDiff: any = endDate.Subtract(currentDate.getDate());
                        if (dtDiff.TotalMinutes > 0)
                            builder.append('Zamanlama : süresi geçiyor\r\n');
                        else builder.append('Zamanlama : süresi geçmiş\r\n');
                    }
                }
                else builder.append('Zamanlama : Randevu ' + dtDiff.TotalDays + ' gün sonra.\r\n');
            }
            else {
                builder.append('Zamanlama : süresi geçmiş\r\n');
            }

            //builder.append('Referans No :' + (app.AppointmentID === null ? '' : (app.AppointmentID.Value === null ? '' : app.AppointmentID.Value.toString())));
            */
            builder.append('\r\n');
            builder.append('\r\n');
        }
        return builder.toString();
    }
    public async GetFullCompletedAppointmentDescription(subactionProcedure: SubActionProcedure): Promise<string> {
        let builder: StringBuilder = new StringBuilder();
        for (let app of (await SubActionProcedureService.GetMyCompletedAppointments(subactionProcedure.ObjectID))) {
            builder.append(i18n("M10470", "Açıklama : ") + app.Notes + '\r\n');
            if (app.BreakAppointment === true)
                builder.append('Zaman  : Saatsiz Randevu \r\n');
            else if (app.AppDate != null && app.StartTime != null && app.EndTime != null)
                builder.append(i18n("M24751", "Zaman  : ") + app.AppDate.toLocaleDateString() + ' ' + app.StartTime.toLocaleTimeString() + ' - ' + app.EndTime.toLocaleTimeString() + '\r\n');
            if (app.Resource.ObjectDef.Name === null) {
                builder.append(app.Resource.ObjectDef.Name + ' :' + app.Resource.Name + '\r\n');
            }
            else {
                builder.append(app.Resource.ObjectDef.Name + ' :' + app.Resource.Name + '\r\n');
            }
            builder.append(app.ObjectDef.Name + ' :' + (app.MasterResource !== null ? app.MasterResource.Name : '') + '\r\n');
            builder.append(i18n("M13357", "Durum  :") + app.CurrentStateDef.toString() + '\r\n');
            builder.append('Referans No :' + (app.AppointmentID === null ? '' : (app.AppointmentID.Value === null ? '' : app.AppointmentID.Value.toString())));
            builder.append('\r\n');
            builder.append('\r\n');
        }
        for (let app of (await SubActionProcedureService.GetMyCancelledAppointments(subactionProcedure.ObjectID))) {
            builder.append(i18n("M10470", "Açıklama : ") + app.Notes + '\r\n');
            if (app.BreakAppointment === true)
                builder.append('Zaman  : Saatsiz Randevu \r\n');
            else if (app.AppDate != null && app.StartTime != null && app.EndTime != null)
                builder.append(i18n("M24751", "Zaman  : ") + app.AppDate.toLocaleDateString() + ' ' + app.StartTime.toLocaleTimeString() + ' - ' + app.EndTime.toLocaleTimeString() + '\r\n');
            if (app.Resource.ObjectDef.Name === null) {
                builder.append(app.Resource.ObjectDef.Name + ' :' + app.Resource.Name + '\r\n');
            }
            else {
                builder.append(app.Resource.ObjectDef.Name + ' :' + app.Resource.Name + '\r\n');
            }
            builder.append(app.ObjectDef.Name + ' :' + (app.MasterResource !== null ? app.MasterResource.Name : '') + '\r\n');
            builder.append(i18n("M13357", "Durum  :") + app.CurrentStateDef.toString() + '\r\n');
            builder.append('Referans No :' + (app.AppointmentID === null ? '' : (app.AppointmentID.Value === null ? '' : app.AppointmentID.Value.toString())) + '\r\n');
            builder.append(i18n("M16561", "İptal Sebebi :") + subactionProcedure.ReasonOfCancel);
            builder.append('\r\n');
            builder.append('\r\n');
        }
        return builder.toString();
    }
    public async MyNewAppointments(objectID: Guid): Promise<Array<Appointment>> {
        let objContext: TTObjectContext = new TTObjectContext(true);
        let retList: Array<Appointment> = <Array<Appointment>>objContext.QueryObjects('SUBACTIONPROCEDURE = ' + objectID.toString() + ' AND CURRENTSTATEDEFID = ' + Appointment.AppointmentStates.New.toString(), 'APPDATE');
        //for (let app of objContext.QueryObjects('APPOINTMENT', 'SUBACTIONPROCEDURE = ' + objectID.toString() + ' AND CURRENTSTATEDEFID = ' + Appointment.AppointmentStates.New.toString(), 'APPDATE')) {

        if (retList != null) {
            for (let app of retList) {
                if (retList.Contains(app) === false)
                    retList.push(app);
            }
        }
        return retList;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubactionProcedureFlowable();
        this.subactionProcedureAppointmentFormViewModel = new SubactionProcedureAppointmentFormViewModel();
        this._ViewModel = this.subactionProcedureAppointmentFormViewModel;
        this.subactionProcedureAppointmentFormViewModel._SubactionProcedureFlowable = this._TTObject as SubactionProcedureFlowable;
    }

    protected loadViewModel() {
        let that = this;

        that.subactionProcedureAppointmentFormViewModel = this._ViewModel as SubactionProcedureAppointmentFormViewModel;
        that._TTObject = this.subactionProcedureAppointmentFormViewModel._SubactionProcedureFlowable;
        if (this.subactionProcedureAppointmentFormViewModel == null)
            this.subactionProcedureAppointmentFormViewModel = new SubactionProcedureAppointmentFormViewModel();
        if (this.subactionProcedureAppointmentFormViewModel._SubactionProcedureFlowable == null)
            this.subactionProcedureAppointmentFormViewModel._SubactionProcedureFlowable = new SubactionProcedureFlowable();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(SubactionProcedureAppointmentFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.tttextboxDescription = new TTVisual.TTTextBox();
        this.tttextboxDescription.Multiline = true;
        this.tttextboxDescription.BackColor = "#F0F0F0";
        this.tttextboxDescription.Name = "tttextboxDescription";
        this.tttextboxDescription.TabIndex = 11;

        this.Controls = [this.tttextboxDescription];

    }


}
