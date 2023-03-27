//$780445FA
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyTestAppointmentFormViewModel } from './RadiologyTestAppointmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentService } from "ObjectClassService/AppointmentService";
import { BaseActionService } from "ObjectClassService/BaseActionService";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { StringBuilder } from 'NebulaClient/System/Text/StringBuilder';
import { SubactionProcedureAppointmentForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SubactionProcedureAppointmentForm";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { SubActionProcedureService } from "ObjectClassService/SubActionProcedureService";
import { RadiologyTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { RadiologyBarcodeInfo } from '../../../wwwroot/app/Barcode/Models/RadiologyBarcodeInfo';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { GuidParam } from '../../../wwwroot/app/NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

@Component({
    selector: 'RadiologyTestAppointmentForm',
    templateUrl: './RadiologyTestAppointmentForm.html',
    providers: [MessageService, AtlasReportService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }]
})
export class RadiologyTestAppointmentForm extends SubactionProcedureAppointmentForm implements OnInit {
    AppointmentInformation: TTVisual.ITTTextBox;
    labelAppointmentInformation: TTVisual.ITTLabel;
    public radiologyTestAppointmentFormViewModel: RadiologyTestAppointmentFormViewModel = new RadiologyTestAppointmentFormViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    private RadiologyTestAppointmentForm_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestAppointmentForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
        protected objectContextService: ObjectContextService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone,
        private barcodePrintService: IBarcodePrintService,
        private reportService: AtlasReportService,) {
        super(httpService, messageService, objectContextService, ngZone);
        this._DocumentServiceUrl = this.RadiologyTestAppointmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        //Asagıdakı kod server tarafındakı aftercontextsave e tasındı
        /*
        if (transDef !== null) {
            if (transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Procedure) {
                let siteID: Guid = new Guid((await SystemParameterService.GetParameterValue('SITEID', Guid.Empty.toString())));
                //if(Sites.SiteXXXXXX06XXXXXX == siteID )
                //{
                let sysparam: string = (await SystemParameterService.GetParameterValue('HL7ENGINEALIVE', null));
                if (sysparam === 'TRUE') {
                    super.AfterContextSavedScript(transDef);
                    let appIDs: Array<Guid> = new Array<Guid>();
                    appIDs.push(this._RadiologyTest.ObjectID);
                    let objectContext: TTObjectContext = new TTObjectContext(false);
                    let radTest: RadiologyTest = <RadiologyTest>objectContext.GetObject(this._RadiologyTest.ObjectID, 'RADIOLOGYTEST');
                    if (radTest.IsMessageInPACS === true) {
                        try {
                            let message: TTMessage = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, 'InternalTcpClient', 'HL7Remoting', 'SendHospitalMessageToEngine', null, appIDs, 'O01XO', 'PACS');
                            radTest.IsMessageInPACS = true;
                        }
                        catch (err) {
                            radTest.IsMessageInPACS = false;
                            throw err;
                        }
                        finally {
                            objectContext.Save();
                        }
                    }
                    else {
                        try {
                            let message: TTMessage = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, 'InternalTcpClient', 'HL7Remoting', 'SendHospitalMessageToEngine', null, appIDs, 'O01', 'PACS');
                            radTest.IsMessageInPACS = true;
                        }
                        catch (err) {
                            radTest.IsMessageInPACS = false;
                            throw err;
                        }
                        finally {
                            objectContext.Save();
                        }
                    }
                }
            }

        }*/

        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("RADIOLOGYTEST", this.radiologyTestAppointmentFormViewModel._RadiologyTest.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        //TODO:  acıalcak
        //let myNewAppointments: Array<Appointment> = new Array<Appointment>();
        //myNewAppointments = await this.MyNewAppointments(this._RadiologyTest.ObjectID);


        let myNewAppointments: Array<Appointment> = new Array<Appointment>();
        myNewAppointments = await SubActionProcedureService.GetMyNewAppointments(this._RadiologyTest.ObjectID);

        if (myNewAppointments != null) {
            if (myNewAppointments.length > 0) {
                let equipment: ResRadiologyEquipment = myNewAppointments[0].Resource as ResRadiologyEquipment;
                if (equipment !== null) {
                    this._RadiologyTest.Equipment = equipment;
                }
            }
        }
        if (transDef !== null) {
            if (transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Procedure) {
                /*
                for (let app of myNewAppointments) {
                    if (Convert.ToDateTime(this._RadiologyTest.Episode.OpeningDate).AddDays(10) < TTObjectDefManager.ServerTime && this._RadiologyTest.SubEpisode.PatientAdmission.AdmissionStatus !== AdmissionStatusEnum.SaglikKurulu && this._RadiologyTest.Episode.PatientStatus.Value !== PatientStatusEnum.Inpatient && (await SubEpisodeService.IsSGKSubEpisode(this._RadiologyTest.SubEpisode)))
                    ///yatan hasta ve sağlık kurulunda kabul randevusu oluşmayacak

                    {
                        let savePointGuid: Guid = this._RadiologyTest.ObjectContext.BeginSavePoint();
                        let episodeWithSameSpeciality: Episode = (await PatientAdmissionService.ReturnEpisodeWithSameSpecialityInTenDays(this._RadiologyTest.SubEpisode.PatientAdmission, this._RadiologyTest.Episode.Patient));
                        if (episodeWithSameSpeciality !== null) {
                            let msg: string = 'Hastanın 10 gün içerisinde ' + episodeWithSameSpeciality.MainSpeciality.Code + ' branşından ' + episodeWithSameSpeciality.HospitalProtocolNo.toString() + ' protokol numarasına sahip vakası bulunmaktadır. Radyoloji işlemine bu vaka üzerinden devam edilecektir.';
                            TTVisual.InfoBox.Alert(msg, MessageIconEnum.InformationMessage);
                            let boolCloneRadiology: boolean = false;
                            try {
                                let subEpisode: SubEpisode = null;
                                if (episodeWithSameSpeciality.SubEpisodes.length === 1)
                                    subEpisode = episodeWithSameSpeciality.SubEpisodes[0];
                                else {
                                    for (let pe of episodeWithSameSpeciality.PatientExaminations) {
                                        if (pe.CurrentStateDef.Status !== StateStatusEnum.Cancelled && pe.CurrentStateDef.Status !== StateStatusEnum.CompletedUnsuccessfully) {
                                            if (pe.SubEpisode !== null)
                                                subEpisode = pe.SubEpisode;
                                        }
                                    }
                                }
                                let originalRadiologyTest: RadiologyTest = this._RadiologyTest;
                                let originalRadiology: Radiology = this._RadiologyTest.Radiology;
                                let cloneRadiologyTest: RadiologyTest = <RadiologyTest>originalRadiologyTest.Clone();
                                let cloneRadiology: Radiology = null;
                                let radList: Array<any> = (await RadiologyService.GetByEpisodeAndClonedObjectID(this._RadiologyTest.ObjectContext, episodeWithSameSpeciality.ObjectID, originalRadiology.ObjectID, null));
                                if (radList.length === 0) {
                                    boolCloneRadiology = true;
                                    cloneRadiology = <Radiology>originalRadiology.Clone();
                                    cloneRadiology.ClonedObjectID = <Guid>originalRadiology.ObjectID;
                                }
                                else {
                                    boolCloneRadiology = false;
                                    cloneRadiology = <Radiology>radList[0];
                                }
                                TTSequence.allowSetSequenceValue = true;
                                cloneRadiologyTest.ID.SetSequenceValue(0);
                                cloneRadiologyTest.ID.GetNextValue();
                                cloneRadiologyTest.CurrentStateDefID = RadiologyTest.RadiologyTestStates.RequestAcception;
                                if (subEpisode !== null)
                                    cloneRadiologyTest.SubEpisode = subEpisode;
                                cloneRadiologyTest.Episode = episodeWithSameSpeciality;
                                cloneRadiologyTest.Radiology = cloneRadiology;
                                if (boolCloneRadiology) {
                                    TTSequence.allowSetSequenceValue = true;
                                    cloneRadiology.ID.SetSequenceValue(0);
                                    cloneRadiology.ID.GetNextValue();
                                    cloneRadiology.Episode = episodeWithSameSpeciality;
                                    if (subEpisode !== null) {
                                        cloneRadiology.SubEpisode = subEpisode;
                                        cloneRadiology.PatientAdmission = subEpisode.PatientAdmission;
                                    }
                                }
                                this._RadiologyTest.Description += '\r\n' + msg;
                                this._RadiologyTest.CurrentStateDefID = RadiologyTest.RadiologyTestStates.AdmissionAppointment;
                                this._RadiologyTest.ObjectContext.Update();
                            }
                            catch (ex) {
                                if (this._RadiologyTest.ObjectContext.HasSavePoint(savePointGuid))
                                    this._RadiologyTest.ObjectContext.RollbackSavePoint(savePointGuid);
                                throw ex;
                            }

                        }
                        else {
                            try {
                                TTVisual.InfoBox.Alert('Hastanın kabul tarihi üzerinden 10 gün geçtiği için, yeni hasta kabul işlemleri üzerinden devam edilecektir.', MessageIconEnum.InformationMessage);
                                let selectedPatient: Patient = this._RadiologyTest.Episode.Patient;
                                let admissionAppointment: AdmissionAppointment = <AdmissionAppointment>this._RadiologyTest.ObjectContext.CreateObject('AdmissionAppointment');
                                admissionAppointment.CurrentStateDefID = AdmissionAppointment.AdmissionAppointmentStates.New;
                                admissionAppointment.SelectedPatient = selectedPatient;
                                admissionAppointment.PatientName = this._RadiologyTest.Episode.Patient.Name;
                                admissionAppointment.PatientSurname = this._RadiologyTest.Episode.Patient.Surname;
                                admissionAppointment.SelectedPatientFiltered = this._RadiologyTest.Episode.Patient.FullName;
                                admissionAppointment.AppointmentDefinition = app.AppointmentDefinition;
                                if (app.AppointmentDefinition.GiveToMaster === true)
                                    app.MasterResource = null;
                                else app.MasterResource = this._RadiologyTest.EpisodeAction.MasterResource;
                                app.Action = <BaseAction>admissionAppointment;
                                app.InitialObjectID = this._RadiologyTest.ObjectID.toString();
                                admissionAppointment.MasterResource = app.MasterResource;
                                admissionAppointment.WorkListDate = Convert.ToDateTime(app.StartTime);
                                this._RadiologyTest.ObjectContext.Update();
                                admissionAppointment.CurrentStateDefID = AdmissionAppointment.AdmissionAppointmentStates.Appointment;
                                this._RadiologyTest.ObjectContext.Update();
                                this._RadiologyTest.CurrentStateDefID = RadiologyTest.RadiologyTestStates.AdmissionAppointment;
                                //TODO : GetEditForm cagrıldıgı ıcın asagıdakı bolum kapatıldı. Daha sonra baska bır yontemle cozumlenebılır.
                                //if (!selectedPatient.IsAllRequiredPropertiesExists(false))//true ise eksik bilgi yoktur kullanıcının seçimine bırakılabilir değilse
                                //{
                                //    TTVisual.TTForm frm = TTVisual.TTForm.GetEditForm(selectedPatient);
                                //    TTFormDef frmDef = TTObjectDefManager.Instance.ObjectDefs["Patient"].FormDefs["PatientForm"];
                                //    bool updatePatient = false;
                                //    if(TTUser.CurrentUser.HasRight(frmDef, selectedPatient, (int)TTSecurityAuthority.RightsEnum.UpdateForm))
                                //    {
                                //        updatePatient=ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hasta Kayıt Düzeltme", "Hastanın kimlik bilgileri eksik.\r\n\r\nHastanın eksik kimlik bilgilerini düzeltmek ister misiniz?") == "E";
                                //        if(updatePatient)
                                //        {
                                //            PatientForm frmPatient = new PatientForm();
                                //            if (frmPatient.ShowEdit(this, selectedPatient) == DialogResult.Cancel)
                                //                throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabul yapılamaz.");
                                //        }
                                //        else
                                //            throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabul yapılamaz.");
                                //    }
                                //    else
                                //        throw new Exception("Hastanın eksik kimlik bilgileri tamamlanmadan hasta kabul yapılamaz.");
                                //}


                                let pa: PatientAdmission = null;
                                //AdmissionApp nin null gönderilmesi kontrol edilip test edilecek
                                pa = PatientAdmissionForm.FireNewPatientAdmission(selectedPatient, null, null, admissionAppointment);
                                if (pa === null)
                                    throw new Exception('Hasta kabul yapmadan işleme devam edemezsiniz.');
                                admissionAppointment.CurrentStateDefID = AdmissionAppointment.AdmissionAppointmentStates.Completed;
                                app.CurrentStateDefID = Appointment.AppointmentStates.Cancelled;
                                this._RadiologyTest.ObjectContext.Update();
                            }
                            catch (ex) {
                                if (this._RadiologyTest.ObjectContext.HasSavePoint(savePointGuid))
                                    this._RadiologyTest.ObjectContext.RollbackSavePoint(savePointGuid);
                                throw ex;
                            }

                        }
                    }
                } */
            }
        }
    }

    protected async ClientSidePreScript(): Promise<void> {

        super.ClientSidePreScript();

        let radTestDef: RadiologyTestDefinition = await this.objectContextService.getObject<RadiologyTestDefinition>(this._RadiologyTest.ProcedureObject.ObjectID, RadiologyTestDefinition.ObjectDefID);
        if (radTestDef.IsRISEntegratedTest == true)
            this.DropStateButton(RadiologyTest.RadiologyTestStates.ResultEntry);
        else if (radTestDef.IsRISEntegratedTest == false)
            this.DropStateButton(RadiologyTest.RadiologyTestStates.Procedure);

        this.DropStateButton(RadiologyTest.RadiologyTestStates.AdmissionAppointment);
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //TODO: CompleteMy Appointments yapılacak acılmalı
        super.PostScript(transDef);
    }

    protected getObjectId(pObject: any): Guid {

        if (pObject != null) {
            if (typeof pObject === "string") {
                return new Guid(pObject);
            }
            else {
                return pObject.ObjectID;
            }
        }
        return null;
    }

    protected async PreScript(): Promise<void> {
        //base.PreScript();

        this.DropStateButton(RadiologyTest.RadiologyTestStates.AdmissionAppointment);
        this.AppointmentInformation.Text = '';
        //ITTTextBox pDescriptionBox = AppointmentInformation;
        //pDescriptionBox.ScrollBars = ScrollBars.Vertical;

        let appDesc: string = '';
        let _patient: Patient = this._RadiologyTest.Episode.Patient;

        if (this._RadiologyTest.CurrentStateDefID != null && RadiologyTest.RadiologyTestStates.Appointment != null && this._RadiologyTest.CurrentStateDefID.toString() == RadiologyTest.RadiologyTestStates.Appointment.toString()) {
            appDesc = await this.GetFullAppointmentDescription(this._RadiologyTest);
        }
        else if (this._RadiologyTest.CurrentStateDefID == RadiologyTest.RadiologyTestStates.AdmissionAppointment) {
            let injectionStr: string = 'WHERE INITIALOBJECTID = ' + this._RadiologyTest.ObjectID.toString();
            let appList: Array<any> = (await AppointmentService.GetByInjection(injectionStr));
            if (appList.length > 0) {
                appDesc = (await BaseActionService.GetFullAppointmentDescription((<Appointment>appList[0]).Action));
            }
        }
        else {
            appDesc = await this.GetFullCompletedAppointmentDescription(this._RadiologyTest);
        }

        let builderDesc: StringBuilder = new StringBuilder();
        builderDesc.append(appDesc);

        let patient: Patient;
        let episode: Episode = await this.objectContextService.getObject<Episode>(this.getObjectId(this._RadiologyTest.Episode), Episode.ObjectDefID, Episode);
        if (episode !== null) {
            patient = episode.Patient;
        }

        if (patient != null) {
            patient = await this.objectContextService.getObject<Patient>(this.getObjectId(patient), Patient.ObjectDefID, Patient);
            if (patient !== null) {
                let currentDate: Date = new Date(Date.now());
                let birthDate: Date = (Convert.ToDateTime(patient.BirthDate));
                let age: any = currentDate.getFullYear() - birthDate.getFullYear();
                //let dtDiff: any = DateUtil.totalDays(currentDate, patient.BirthDate);

                if (age != null) {
                    builderDesc.append('\r\nYaşı : ');
                    builderDesc.append(age.toString());
                }
            }

        }

        //if (_patient.Age.Value != null)
        //   builderDesc.append(_patient.Age.Value.toString());
        //builderDesc.append('\r\nAçıklama : ');
        builderDesc.append(this._RadiologyTest.GeneralDescription);
        this.AppointmentInformation.Text = builderDesc.toString();
        this.radiologyTestAppointmentFormViewModel.AppointmentDescription = builderDesc.toString();


    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestAppointmentFormViewModel = new RadiologyTestAppointmentFormViewModel();
        this._ViewModel = this.radiologyTestAppointmentFormViewModel;
        this.radiologyTestAppointmentFormViewModel._RadiologyTest = this._TTObject as RadiologyTest;
        this.radiologyTestAppointmentFormViewModel._RadiologyTest.ProcedureObject = new ProcedureDefinition();
        this.radiologyTestAppointmentFormViewModel._RadiologyTest.Equipment = new ResRadiologyEquipment();
        this.radiologyTestAppointmentFormViewModel._RadiologyTest.Department = new ResRadiologyDepartment();
        this.radiologyTestAppointmentFormViewModel._RadiologyTest.Episode = new Episode();
        this.radiologyTestAppointmentFormViewModel._RadiologyTest.Episode.Patient = new Patient();
        this.radiologyTestAppointmentFormViewModel._RadiologyTest.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.radiologyTestAppointmentFormViewModel._RadiologyTest.Radiology = new Radiology();
        this.radiologyTestAppointmentFormViewModel._RadiologyTest.Radiology.RequestDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.radiologyTestAppointmentFormViewModel = this._ViewModel as RadiologyTestAppointmentFormViewModel;
        that._TTObject = this.radiologyTestAppointmentFormViewModel._RadiologyTest;
        if (this.radiologyTestAppointmentFormViewModel == null)
            this.radiologyTestAppointmentFormViewModel = new RadiologyTestAppointmentFormViewModel();
        if (this.radiologyTestAppointmentFormViewModel._RadiologyTest == null)
            this.radiologyTestAppointmentFormViewModel._RadiologyTest = new RadiologyTest();
        if (this.radiologyTestAppointmentFormViewModel._RadiologyTest == null)
            this.radiologyTestAppointmentFormViewModel._RadiologyTest = new RadiologyTest();
        let equipmentObjectID = that.radiologyTestAppointmentFormViewModel._RadiologyTest["Equipment"];
        if (equipmentObjectID != null && (typeof equipmentObjectID === 'string')) {
            let equipment = that.radiologyTestAppointmentFormViewModel.ResRadiologyEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
             if (equipment) {
                that.radiologyTestAppointmentFormViewModel._RadiologyTest.Equipment = equipment;
            }
        }
        let procedureObjectObjectID = that.radiologyTestAppointmentFormViewModel._RadiologyTest["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.radiologyTestAppointmentFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
             if (procedureObject) {
                that.radiologyTestAppointmentFormViewModel._RadiologyTest.ProcedureObject = procedureObject;
            }
        }
        let departmentObjectID = that.radiologyTestAppointmentFormViewModel._RadiologyTest["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
            let department = that.radiologyTestAppointmentFormViewModel.ResRadiologyDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
             if (department) {
                that.radiologyTestAppointmentFormViewModel._RadiologyTest.Department = department;
            }
        }

        let episodeObjectID = that.radiologyTestAppointmentFormViewModel._RadiologyTest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyTestAppointmentFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.radiologyTestAppointmentFormViewModel._RadiologyTest.Episode = episode;
            }

            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.radiologyTestAppointmentFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
            if (episode != null) {
                episode.Diagnosis = that.radiologyTestAppointmentFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyTestAppointmentFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyTestAppointmentFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyTestAppointmentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let radiologyObjectID = that.radiologyTestAppointmentFormViewModel._RadiologyTest["EpisodeAction"];
        if (radiologyObjectID != null && (typeof radiologyObjectID === 'string')) {
            let radiology = that.radiologyTestAppointmentFormViewModel.Radiologys.find(o => o.ObjectID.toString() === radiologyObjectID.toString());
             if (radiology) {
                that.radiologyTestAppointmentFormViewModel._RadiologyTest.Radiology = radiology;
            }
            that.radiologyTestAppointmentFormViewModel._RadiologyTest.Radiology.Episode = that.radiologyTestAppointmentFormViewModel._RadiologyTest.Episode;
            if (radiology != null) {
                let requestDoctorObjectID = radiology["RequestDoctor"];
                if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
                    let requestDoctor = that.radiologyTestAppointmentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                     if (requestDoctor) {
                        radiology.RequestDoctor = requestDoctor;
                    }
                }
            }
        }
    }

    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyTestAppointmentFormViewModel);
        this.AddHelpMenu();
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        let pathologyRequest = new DynamicSidebarMenuItem();
        pathologyRequest.key = 'pathologyRequest';
        pathologyRequest.icon = 'ai ai-chemical';
        pathologyRequest.label = i18n("M20230", "Patoloji İstek");
        pathologyRequest.componentInstance = this.helpMenuService;
        pathologyRequest.clickFunction = this.helpMenuService.onPathologyRequest;
        pathologyRequest.parameterFunctionInstance = this;
        pathologyRequest.getParamsFunction = this.getParamsFunctionForRadiology;
        pathologyRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', pathologyRequest);

        let appointmentBarcode = new DynamicSidebarMenuItem();
        appointmentBarcode.key = 'appointmentBarcode';
        appointmentBarcode.icon = 'ai ai-barkod-bas';
        appointmentBarcode.label = "Randevu Barkodu";
        appointmentBarcode.componentInstance = this;
        appointmentBarcode.clickFunction = this.printAppointmentBarcode;
        appointmentBarcode.parameterFunctionInstance = this;
        appointmentBarcode.getParamsFunction = this.getParamsFunctionForRadiology;
        appointmentBarcode.ParentInstance = this;
        this.sideBarMenuService.addMenu('Barkod', appointmentBarcode);

        let appointmentReport = new DynamicSidebarMenuItem();
        appointmentReport.key = 'appointmentReport';
        appointmentReport.icon = 'fa fa-file-text-o';
        appointmentReport.label = "Randevu Bilgi Formu";
        appointmentReport.componentInstance = this;
        appointmentReport.clickFunction = this.printAppointmentReport;
        appointmentReport.parameterFunctionInstance = this;
        appointmentReport.getParamsFunction = this.getParamsFunctionForRadiology;
        appointmentReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', appointmentReport);
    }

    private getParamsFunctionForRadiology(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(new Guid(this._RadiologyTest.EpisodeAction.toString()), this._RadiologyTest.Episode.ObjectID, null));
        return clickFunctionParams;
    }

    private RemoveMenuFromHelpMenu(): void {

        this.sideBarMenuService.removeMenu('pathologyRequest');
        this.sideBarMenuService.removeMenu('appointmentBarcode');
        this.sideBarMenuService.removeMenu('appointmentReport');
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.AppointmentInformation = new TTVisual.TTTextBox();
        this.AppointmentInformation.Multiline = true;
        this.AppointmentInformation.BackColor = "#F0F0F0";
        this.AppointmentInformation.ReadOnly = true;
        this.AppointmentInformation.Name = "AppointmentInformation";
        this.AppointmentInformation.TabIndex = 5;
        this.AppointmentInformation.Height = "200px";

        //this.tttextboxDescription = new TTVisual.TTTextBox();
        //this.tttextboxDescription.Multiline = true;
        //this.tttextboxDescription.BackColor = "#F0F0F0";
        //this.tttextboxDescription.Name = "tttextboxDescription";
        //this.tttextboxDescription.TabIndex = 11;

        this.labelAppointmentInformation = new TTVisual.TTLabel();
        this.labelAppointmentInformation.Text = i18n("M20719", "Randevu Bilgileri");
        this.labelAppointmentInformation.BackColor = "#DCDCDC";
        this.labelAppointmentInformation.ForeColor = "#000000";
        this.labelAppointmentInformation.Name = "labelAppointmentInformation";
        this.labelAppointmentInformation.TabIndex = 8;

        this.Controls = [this.AppointmentInformation, this.labelAppointmentInformation];

    }

    private async printAppointmentBarcode(): Promise<void> {
        let apiUrl: string = 'api/RadiologyTestService/PrepareRadiologyAppointmentBarcode?RadiologyTestObjectID=' + this._RadiologyTest.ObjectID.toString();
        let result: RadiologyBarcodeInfo = await this.httpService.get<RadiologyBarcodeInfo>(apiUrl);
        await this.barcodePrintService.printAllBarcode(result, "generateRadiologyAppointmentBarcode", "printRadiologyAppointmentBarcode");
    }

    private printAppointmentReport() {
        const objectIdParam = new GuidParam(this._RadiologyTest.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('RadiologyAppointmentInfoForm', reportParameters);    
    }
}
