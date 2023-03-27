//$EBCDBE2D
import { Component, OnInit, NgZone  } from '@angular/core';
import { NuclearMedicineAppointmentInfoFormViewModel } from './NuclearMedicineAppointmentInfoFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Appointment } from 'NebulaClient/Model/AtlasClientModel';
import { AppointmentFormBase } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AppointmentFormBase";
import { AppointmentService } from "ObjectClassService/AppointmentService";
import { BaseActionService } from "ObjectClassService/BaseActionService";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedRadPharmMatGrid } from 'NebulaClient/Model/AtlasClientModel';
import { StringBuilder } from 'NebulaClient/System/Text/StringBuilder';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'NuclearMedicineAppointmentInfoForm',
    templateUrl: './NuclearMedicineAppointmentInfoForm.html',
    providers: [MessageService]
})
export class NuclearMedicineAppointmentInfoForm extends AppointmentFormBase implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridRadPharmMaterials: TTVisual.ITTGrid;
    IsEmergency: TTVisual.ITTCheckBox;
    IsInjection: TTVisual.ITTCheckBoxColumn;
    labelPreInformation: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    pDescriptionBox: TTVisual.ITTTextBox;
    PharmMaterial: TTVisual.ITTListBoxColumn;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    RadPharmMatTab: TTVisual.ITTTabPage;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    TABNuclearMedicine: TTVisual.ITTTabControl;
    TabPageAppointmentInfo: TTVisual.ITTTabPage;
    ttdatetimepickercolumn2: TTVisual.ITTDateTimePickerColumn;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextboxcolumn3: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn4: TTVisual.ITTTextBoxColumn;
    public GridEpisodeDiagnosisColumns = [];
    public GridRadPharmMaterialsColumns = [];
    public nuclearMedicineAppointmentInfoFormViewModel: NuclearMedicineAppointmentInfoFormViewModel = new NuclearMedicineAppointmentInfoFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineAppointmentInfoForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineAppointmentInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineAppointmentInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        /*
        super.ClientSidePostScript(transDef);
        let myCompletedAppointments: Array<Appointment> = new Array<Appointment>();
        myCompletedAppointments = (await EpisodeActionService.MyCompletedAppointments(this._NuclearMedicine.ObjectID));
        if (myCompletedAppointments.length > 0) {
            let equipment: ResNuclearMedicineEquipment = myCompletedAppointments[0].Resource as ResNuclearMedicineEquipment;
            if (equipment !== null) {
                this._NuclearMedicine.NuclearMedicineTests[0].Equipment = equipment;
            }
        }
        if (transDef !== null) {
            if (transDef.ToStateDefID === NuclearMedicine.NuclearMedicineStates.Preparation) {
                for (let app of (await EpisodeActionService.GetMyNewAppointments(this._NuclearMedicine.ObjectID))) {
                    if (Convert.ToDateTime(this._NuclearMedicine.Episode.OpeningDate).AddDays(10) < TTObjectDefManager.ServerTime && this._NuclearMedicine.SubEpisode.PatientAdmission.AdmissionStatus !== AdmissionStatusEnum.SaglikKurulu && this._NuclearMedicine.Episode.PatientStatus.Value !== PatientStatusEnum.Inpatient && this._NuclearMedicine.SubEpisode.PatientAdmission.IsSGKPatientAdmission)
                    ///yatan hasta ve sağlık kurulunda kabul randevusu oluşmayacak
                    {
                        let savePointGuid: Guid = this._NuclearMedicine.ObjectContext.BeginSavePoint();
                        let episodeWithSameSpeciality: Episode = (await PatientAdmissionService.ReturnEpisodeWithSameSpecialityInTenDays(this._NuclearMedicine.SubEpisode.PatientAdmission));
                        if (episodeWithSameSpeciality !== null) {
                            let msg: string = 'Hastanın 10 gün içerisinde ' + episodeWithSameSpeciality.MainSpeciality.Code + ' branşından ' + episodeWithSameSpeciality.HospitalProtocolNo.toString() + ' protokol numarasına sahip vakası bulunmaktadır. Nükleer Tıp işlemine bu vaka üzerinden devam edilecektir.';
                            TTVisual.InfoBox.Alert(msg);
                            let boolCloneNucleerMedicine: boolean = false;
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
                                //Şu anda nükleer tıp da istekler tek tek giriliyor. Çoklu girilmeye başlandığında bu kısım radyolojide olduğu gibi düzenlenmeli.
                                let originalNuclearMedicine: NuclearMedicine = this._NuclearMedicine;
                                let originalNuclearMedicineTest: NuclearMedicineTest = this._NuclearMedicine.NuclearMedicineTests[0];
                                let cloneNuclearMedicine: NuclearMedicine = <NuclearMedicine>originalNuclearMedicine.Clone();
                                let cloneNuclearMedicineTest: NuclearMedicineTest = <NuclearMedicineTest>originalNuclearMedicineTest.Clone();
                                TTSequence.allowSetSequenceValue = true;
                                cloneNuclearMedicine.ID.SetSequenceValue(0);
                                cloneNuclearMedicine.ID.GetNextValue();
                                TTSequence.allowSetSequenceValue = true;
                                cloneNuclearMedicineTest.ID.SetSequenceValue(0);
                                cloneNuclearMedicineTest.ID.GetNextValue();
                                cloneNuclearMedicine.Episode = episodeWithSameSpeciality;
                                if (subEpisode !== null) {
                                    cloneNuclearMedicine.SubEpisode = subEpisode;
                                    cloneNuclearMedicine.PatientAdmission = subEpisode.PatientAdmission;
                                }
                                cloneNuclearMedicine.ClonedObjectID = <Guid>originalNuclearMedicine.ObjectID;
                                cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.NuclearMedicineStates.Request;
                                cloneNuclearMedicineTest.NuclearMedicine = cloneNuclearMedicine;
                                cloneNuclearMedicineTest.Episode = episodeWithSameSpeciality;
                                if (subEpisode !== null)
                                    cloneNuclearMedicineTest.SubEpisode = subEpisode;
                                originalNuclearMedicineTest.Eligible = false;
                                this._NuclearMedicine.ObjectContext.Update();
                                cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.NuclearMedicineStates.RequestAcception;
                                this._NuclearMedicine.ObjectContext.Update();
                                cloneNuclearMedicine.CurrentStateDefID = NuclearMedicine.NuclearMedicineStates.Preparation;
                                this._NuclearMedicine.ObjectContext.Update();
                                this._NuclearMedicine.DescriptionForWorkList += '\r\n' + msg;
                                this._NuclearMedicine.CurrentStateDefID = NuclearMedicine.NuclearMedicineStates.AdmissionAppointment;
                                this._NuclearMedicine.ObjectContext.Update();
                            }
                            catch (ex) {
                                if (this._NuclearMedicine.ObjectContext.HasSavePoint(savePointGuid))
                                    this._NuclearMedicine.ObjectContext.RollbackSavePoint(savePointGuid);
                                throw ex;
                            }

                        }
                        else {
                            try {
                                TTVisual.InfoBox.Alert('Hastanın kabul tarihi üzerinden 10 gün geçtiği için, yeni hasta kabul işlemleri üzerinden devam edilecektir. ');
                                let selectedPatient: Patient = this._NuclearMedicine.Episode.Patient;
                                let admissionAppointment: AdmissionAppointment = <AdmissionAppointment>this._NuclearMedicine.ObjectContext.CreateObject('AdmissionAppointment');
                                admissionAppointment.CurrentStateDefID = AdmissionAppointment.AdmissionAppointmentStates.New;
                                admissionAppointment.SelectedPatient = selectedPatient;
                                admissionAppointment.PatientName = this._NuclearMedicine.Episode.Patient.Name;
                                admissionAppointment.PatientSurname = this._NuclearMedicine.Episode.Patient.Surname;
                                admissionAppointment.SelectedPatientFiltered = this._NuclearMedicine.Episode.Patient.FullName;
                                admissionAppointment.AppointmentDefinition = app.AppointmentDefinition;
                                if (app.AppointmentDefinition.GiveToMaster === true)
                                    app.MasterResource = null;
                                else app.MasterResource = this._NuclearMedicine.MasterResource;
                                app.Action = <BaseAction>admissionAppointment;
                                app.InitialObjectID = this._NuclearMedicine.ObjectID.toString();
                                admissionAppointment.MasterResource = app.MasterResource;
                                admissionAppointment.WorkListDate = Convert.ToDateTime(app.StartTime);
                                this._NuclearMedicine.ObjectContext.Update();
                                admissionAppointment.CurrentStateDefID = AdmissionAppointment.AdmissionAppointmentStates.Appointment;
                                this._NuclearMedicine.ObjectContext.Update();
                                this._NuclearMedicine.CurrentStateDefID = NuclearMedicine.NuclearMedicineStates.AdmissionAppointment;
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
                                this._NuclearMedicine.ObjectContext.Update();
                            }
                            catch (ex) {
                                if (this._NuclearMedicine.ObjectContext.HasSavePoint(savePointGuid))
                                    this._NuclearMedicine.ObjectContext.RollbackSavePoint(savePointGuid);
                                throw ex;
                            }

                        }
                    }
                }
            }
        }
        */
    }

    /*
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
    }
    */

    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.DropStateButton(NuclearMedicine.NuclearMedicineStates.AdmissionAppointment);
        let appDesc: string = '';
        if (this._NuclearMedicine.CurrentStateDefID.toString() == NuclearMedicine.NuclearMedicineStates.AppointmentInfo.toString()) {
            appDesc = (await BaseActionService.GetFullAppointmentDescription(this._NuclearMedicine));
        }
        else if (this._NuclearMedicine.CurrentStateDefID === NuclearMedicine.NuclearMedicineStates.AdmissionAppointment) {
            let injectionStr: string = 'WHERE INITIALOBJECTID = ' + this._NuclearMedicine.ObjectID.toString();
            let appList: Array<any> = (await AppointmentService.GetByInjection( injectionStr));
            if (appList.length > 0) {
                appDesc = (await BaseActionService.GetFullAppointmentDescription((<Appointment>appList[0]).Action));
            }
        }
        else {
            appDesc = (await BaseActionService.GetFullCompletedAppointmentDescription(this._NuclearMedicine));
        }
        let builderDesc: StringBuilder = new StringBuilder();
        builderDesc.append(appDesc);
        builderDesc.append('\r\nAçıklama : ');
        builderDesc.append(this._NuclearMedicine.DescriptionForWorkList);
        this.nuclearMedicineAppointmentInfoFormViewModel.AppointmentDescription = builderDesc.toString();

    }


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineAppointmentInfoFormViewModel = new NuclearMedicineAppointmentInfoFormViewModel();
        this._ViewModel = this.nuclearMedicineAppointmentInfoFormViewModel;
        this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
        this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine.RadPharmMaterials = new Array<NucMedRadPharmMatGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineAppointmentInfoFormViewModel = this._ViewModel as NuclearMedicineAppointmentInfoFormViewModel;
        that._TTObject = this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineAppointmentInfoFormViewModel == null)
            this.nuclearMedicineAppointmentInfoFormViewModel = new NuclearMedicineAppointmentInfoFormViewModel();
        if (this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine = new NuclearMedicine();
        let requestDoctorObjectID = that.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineAppointmentInfoFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineAppointmentInfoFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineAppointmentInfoFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineAppointmentInfoFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineAppointmentInfoFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineAppointmentInfoFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        that.nuclearMedicineAppointmentInfoFormViewModel._NuclearMedicine.RadPharmMaterials = that.nuclearMedicineAppointmentInfoFormViewModel.GridRadPharmMaterialsGridList;
        for (let detailItem of that.nuclearMedicineAppointmentInfoFormViewModel.GridRadPharmMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineAppointmentInfoFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineAppointmentInfoFormViewModel);
  
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ActionDate != event) {
                this._NuclearMedicine.ActionDate = event;
            }
        }
    }

    public onIsEmergencyChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.IsEmergency != event) {
                this._NuclearMedicine.IsEmergency = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PreDiagnosis != event) {
                this._NuclearMedicine.PreDiagnosis = event;
            }
        }
    }

    public onREQUESTDOCTORChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RequestDoctor != event) {
                this._NuclearMedicine.RequestDoctor = event;
            }
        }
    }

    public onREQUESTDOCTORPHONEChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null &&
                this._NuclearMedicine.RequestDoctor != null && this._NuclearMedicine.RequestDoctor.PhoneNumber != event) {
                this._NuclearMedicine.RequestDoctor.PhoneNumber = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProtocolNo != event) {
                this._NuclearMedicine.ProtocolNo = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.TestSequenceNo != event) {
                this._NuclearMedicine.TestSequenceNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TestSequenceNo");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#FFFFFF";
        this.ttgroupbox1.Enabled = false;
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.tttextboxDescription = new TTVisual.TTTextBox();
        this.tttextboxDescription.Multiline = true;
        this.tttextboxDescription.Name = "tttextboxDescription";
        this.tttextboxDescription.TabIndex = 11;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Test Sıra No";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 15;

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 1;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 16;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tetkik";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "AdmissionTypeListDef";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 14;

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 7;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Enabled = false;
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 10;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 3;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 9;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Protokol No";
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 8;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 11;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmişe Ekle";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisDefinitionList";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 250;

        this.EpisodeDiagnoseType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnoseType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnoseType.DataMember = "DiagnosisType";
        this.EpisodeDiagnoseType.DisplayIndex = 2;
        this.EpisodeDiagnoseType.HeaderText = "Tanı Tipi";
        this.EpisodeDiagnoseType.Name = "EpisodeDiagnoseType";
        this.EpisodeDiagnoseType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = "Ana Tanı";
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 75;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = "Tanı Koyan";
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = "Tanı Giriş Tarihi";
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = "Giriş Yapılan İşlem";
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "İstek Yapan Tabip Telefon";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 8;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 9;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Kabul Sebebi";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 4;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Hasta Grubu";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 2;

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 13;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "İşlem Zamanı";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 1;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.labelPreInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 12;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İstek Yapan Tabip";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 6;

        this.TABNuclearMedicine = new TTVisual.TTTabControl();
        this.TABNuclearMedicine.Name = "TABNuclearMedicine";
        this.TABNuclearMedicine.TabIndex = 0;

        this.TabPageAppointmentInfo = new TTVisual.TTTabPage();
        this.TabPageAppointmentInfo.DisplayIndex = 0;
        this.TabPageAppointmentInfo.BackColor = "#FFFFFF";
        this.TabPageAppointmentInfo.TabIndex = 1;
        this.TabPageAppointmentInfo.Text = "Randevu Bilgileri";
        this.TabPageAppointmentInfo.Name = "TabPageAppointmentInfo";

        this.pDescriptionBox = new TTVisual.TTTextBox();
        this.pDescriptionBox.Multiline = true;
        this.pDescriptionBox.BackColor = "#F0F0F0";
        this.pDescriptionBox.ReadOnly = true;
        this.pDescriptionBox.Font = "Name=Tahoma, Size=9,75, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pDescriptionBox.Name = "pDescriptionBox";
        this.pDescriptionBox.TabIndex = 1;


        this.RadPharmMatTab = new TTVisual.TTTabPage();
        this.RadPharmMatTab.DisplayIndex = 1;
        this.RadPharmMatTab.TabIndex = 2;
        this.RadPharmMatTab.Text = "Radyofarmasötik Madde Sarf";
        this.RadPharmMatTab.Visible = false;
        this.RadPharmMatTab.Name = "RadPharmMatTab";

        this.GridRadPharmMaterials = new TTVisual.TTGrid();
        this.GridRadPharmMaterials.Name = "GridRadPharmMaterials";
        this.GridRadPharmMaterials.TabIndex = 1;

        this.ttdatetimepickercolumn2 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn2.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn2.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn2.DataMember = "ActionDate";
        this.ttdatetimepickercolumn2.DisplayIndex = 0;
        this.ttdatetimepickercolumn2.HeaderText = "Tarih/Saat";
        this.ttdatetimepickercolumn2.Name = "ttdatetimepickercolumn2";
        this.ttdatetimepickercolumn2.ReadOnly = true;
        this.ttdatetimepickercolumn2.Width = 140;

        this.PharmMaterial = new TTVisual.TTListBoxColumn();
        this.PharmMaterial.ListDefName = "NucMedPharmMatListDef";
        this.PharmMaterial.DataMember = "Material";
        this.PharmMaterial.DisplayIndex = 1;
        this.PharmMaterial.HeaderText = "Sarf Edilen Malzemeler";
        this.PharmMaterial.Name = "PharmMaterial";
        this.PharmMaterial.ReadOnly = true;
        this.PharmMaterial.Width = 320;

        this.IsInjection = new TTVisual.TTCheckBoxColumn();
        this.IsInjection.DisplayIndex = 2;
        this.IsInjection.HeaderText = "Enjeksiyon";
        this.IsInjection.Name = "IsInjection";
        this.IsInjection.ReadOnly = true;
        this.IsInjection.Width = 60;

        this.tttextboxcolumn3 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn3.DataMember = "Note";
        this.tttextboxcolumn3.DisplayIndex = 3;
        this.tttextboxcolumn3.HeaderText = "Planlanan Aktivite(mCi)";
        this.tttextboxcolumn3.Name = "tttextboxcolumn3";
        this.tttextboxcolumn3.ReadOnly = true;
        this.tttextboxcolumn3.Width = 140;

        this.tttextboxcolumn4 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn4.DataMember = "Amount";
        this.tttextboxcolumn4.DisplayIndex = 4;
        this.tttextboxcolumn4.HeaderText = "Verilen Aktivite(mCi)";
        this.tttextboxcolumn4.Name = "tttextboxcolumn4";
        this.tttextboxcolumn4.ReadOnly = true;
        this.tttextboxcolumn4.Width = 140;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridRadPharmMaterialsColumns = [this.ttdatetimepickercolumn2, this.PharmMaterial, this.IsInjection, this.tttextboxcolumn3, this.tttextboxcolumn4];
        this.ttgroupbox1.Controls = [this.ttlabel5, this.nucMedSelectedTesttxt, this.tttextbox3, this.ttlabel1, this.ReasonForAdmission, this.REQUESTDOCTOR, this.IsEmergency, this.PATIENTGROUPENUM, this.tttextbox1, this.ttlabel15, this.GridEpisodeDiagnosis, this.ttlabel7, this.REQUESTDOCTORPHONE, this.ttlabel4, this.ttlabel3, this.PREDIAGNOSIS, this.labelProcessTime, this.ActionDate, this.labelPreInformation, this.ttlabel2];
        this.TABNuclearMedicine.Controls = [this.TabPageAppointmentInfo, this.RadPharmMatTab];
        this.TabPageAppointmentInfo.Controls = [this.pDescriptionBox];
        this.RadPharmMatTab.Controls = [this.GridRadPharmMaterials];
        this.Controls = [this.ttgroupbox1, this.tttextboxDescription, this.ttlabel5, this.nucMedSelectedTesttxt, this.tttextbox3, this.ttlabel1, this.ReasonForAdmission, this.REQUESTDOCTOR, this.IsEmergency, this.PATIENTGROUPENUM, this.tttextbox1, this.ttlabel15, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttlabel7, this.REQUESTDOCTORPHONE, this.ttlabel4, this.ttlabel3, this.PREDIAGNOSIS, this.labelProcessTime, this.ActionDate, this.labelPreInformation, this.ttlabel2, this.TABNuclearMedicine, this.TabPageAppointmentInfo, this.pDescriptionBox, this.RadPharmMatTab, this.GridRadPharmMaterials, this.ttdatetimepickercolumn2, this.PharmMaterial, this.IsInjection, this.tttextboxcolumn3, this.tttextboxcolumn4];

    }


}
