//$BF331E60
import { Component, ViewChild, OnInit, NgZone, ComponentRef } from '@angular/core';
import { BaseNewDoctorExaminationFormViewModel, DynamicComponentInfoDVO } from "./BaseNewDoctorExaminationFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { SpecialityBasedObjectForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { RequestedProceduresForm } from "../Tetkik_Istem_Modulu/RequestedProceduresForm";
import { ProcedureRequestForm } from "../Tetkik_Istem_Modulu/ProcedureRequestForm";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { IModalService } from "Fw/Services/IModalService";
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'BaseNewDoctorExaminationForm',
    templateUrl: './BaseNewDoctorExaminationForm.html',
    providers: [MessageService]
})
export class BaseNewDoctorExaminationForm extends EpisodeActionForm implements OnInit {
    public baseNewDoctorExaminationFormViewModel: BaseNewDoctorExaminationFormViewModel = new BaseNewDoctorExaminationFormViewModel();
    public get _EpisodeAction(): EpisodeAction {
        return this._TTObject as EpisodeAction;
    }
    private BaseNewDoctorExaminationForm_DocumentUrl: string = '/api/EpisodeActionService/BaseNewDoctorExaminationForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        protected objectContextService: ObjectContextService,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseNewDoctorExaminationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    //public procedureSpecialityName: string;// viewModele taşındı
    // public hasSpecialityBasedObject: boolean = false;// viewModele taşındı
    public hasEmergencySpecialityBasedObject: boolean = true;


    // Tetkik istem için
    @ViewChild(ProcedureRequestForm) requestForm: ProcedureRequestForm;
    @ViewChild(RequestedProceduresForm) requestFormDefinition: RequestedProceduresForm;

    // ***** Method declarations start *****

    // Uzmanlık Dalı kaydetmek için ViewModeldeki SpecialityBasedObjectViewModelsin set edlmesi için

    public componentSpecialityBasedObjectInfo: DynamicComponentInfo;

    public onSetSpecialityBasedObjectViewModel(componentRef: ComponentRef<any>): void {

        let specialityBasedObjectComponent = componentRef.instance as SpecialityBasedObjectForm;
        let boundedFunc = this.setSpecialityBasedObjectViewModel.bind(this);
        specialityBasedObjectComponent.sendMyViewModel.subscribe(boundedFunc);
    }

    protected async ClientSidePreScript(): Promise<void> {
        await super.ClientSidePreScript();
        await this.closeStatePanelIsInvoiced();
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
    }
    public setSpecialityBasedObjectViewModel(e: any) {

        let that = this;
        if (this._ViewModel.SpecialityBasedObjectViewModels == null) {
            this._ViewModel.SpecialityBasedObjectViewModels = new Array<any>();
            this._ViewModel.SpecialityBasedObjectViewModels.push(e); // e SpecialityBasedObjectViewModel tipinde bir ViewModel
        }
    }



    async setSpesialityBasedObjectInfo(): Promise<void> {
        let that = this;
        if (this._ViewModel.hasSpecialityBasedObject == true) {
            await this.httpService.get<DynamicComponentInfoDVO>("api/EpisodeActionService/GetDynamicComponentSpecialityBasedObjectInfo?EpisodeActionObjectId=" + this._EpisodeAction.ObjectID, DynamicComponentInfoDVO).then(response => {
                let result: DynamicComponentInfoDVO = <DynamicComponentInfoDVO>(response);
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                if (result.ComponentName != null) {
                    compInfo.ComponentName = result.ComponentName;
                    compInfo.ModuleName = result.ModuleName;
                    compInfo.ModulePath = result.ModulePath;
                    compInfo.objectID = result.objectID;
                    if (that.ActiveIDsModel == null) {
                        that.LoadActiveIDsModel();
                    }
                    compInfo.InputParam = that.ActiveIDsModel;
                    this.componentSpecialityBasedObjectInfo = compInfo;
                }
            }

            );
        }
    }



    //SelectedPackageChange(data: any) {
    //    //debugger;
    //    this.requestForm.select(data);
    //}

    /*   protected async PreScript() {
           super.PreScript();
       }
       public async CreateNewAnesthesiaConsultation(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////SaveContextForNewDiagnose();
           //TTObjectClasses.AnesthesiaConsultation consultation;
           ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           ////TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    consultation = new TTObjectClasses.AnesthesiaConsultation(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(consultation);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), consultation) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewConsultationFromOtherHospRequest(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////SaveContextForNewDiagnose();
           //ConsultationFromOtherHospital consultationFromOtherHospital;
           ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           ////TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();

           //try
           //{
           //    consultationFromOtherHospital = new ConsultationFromOtherHospital(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(consultationFromOtherHospital);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), consultationFromOtherHospital) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewConsultationRequest(): Promise<void> {
           //            MultiSelectForm pForm = new MultiSelectForm();
           //            pForm.AddMSItem("Normal Konsültasyon", "ConsultationRequest");
           //            pForm.AddMSItem("Diş Konsültasyonu", "DentalConsultationRequest");
           //            string consultationType = pForm.GetMSItem(this, "Konsültasyon Tipini Seçiniz");
           //            pForm.ClearMSItems();
           //            if(consultationType == "ConsultationRequest")
           this.CreateNewNormalConsultationRequest();
           //            else if (consultationType == "DentalConsultationRequest")
           //                CreateNewDentalConsultationRequest();
           //            else
           //            {
           //                InfoBox.Show("Konsültasyon isteğinden vazgeçildi.");
           //                return;
           //            }
           let a = 1;
       }
       public async CreateNewDentalConsultationRequest(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////SaveContextForNewDiagnose();
           //DentalConsultationRequest dentalConsultationRequest;
           ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           ////TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    dentalConsultationRequest = new DentalConsultationRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(dentalConsultationRequest);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), dentalConsultationRequest) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           let a = 1;
       }
       public async CreateNewEpicrisisReport(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //CreatingEpicrisis epicrisisReport;
           //CreatingEpicrisis tempEpicrisisReport;
           //TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = objectContext.BeginSavePoint();
           //try
           //{
           //    InPatientPhysicianApplication inPatientPhysicianApplication = null;
           //    if (this._EpisodeAction is InPatientPhysicianApplication)
           //        inPatientPhysicianApplication = (InPatientPhysicianApplication)this._EpisodeAction;
           //    else
           //    {
           //        foreach (EpisodeAction ea in _EpisodeAction.Episode.EpisodeActions)
           //        {
           //            if (ea is InPatientPhysicianApplication && ea.CurrentStateDefID == CreatingEpicrisis.States.Completed)
           //                inPatientPhysicianApplication = (InPatientPhysicianApplication)ea;
           //        }
           //    }

           //    // if (this._EpisodeAction.Episode.MainSpeciality.Code == "4400")

           //    if (inPatientPhysicianApplication != null || this._EpisodeAction.Episode.MainSpeciality.Code == "4400")
           //    {
           //        if (this._EpisodeAction.Episode.MainSpeciality.Code != null && this._EpisodeAction.Episode.MainSpeciality.Code == "4400")
           //        {
           //            if (inPatientPhysicianApplication == null)
           //            {
           //                epicrisisReport = new CreatingEpicrisis(objectContext, this._EpisodeAction);
           //                TTForm frm = TTForm.GetEditForm(epicrisisReport);
           //                this.PrapareFormToShow(frm);

           //                if (frm.ShowEdit(this.FindForm(), epicrisisReport) == DialogResult.OK)
           //                {
           //                    objectContext.Save();
           //                }

           //            }
           //        }
           //        else
           //        {
           //            if (inPatientPhysicianApplication.MyEpicrisisReport() == null)
           //            {
           //                epicrisisReport = new CreatingEpicrisis(objectContext, this._EpisodeAction);
           //            }
           //            else
           //            {
           //                tempEpicrisisReport = inPatientPhysicianApplication.MyEpicrisisReport();
           //                epicrisisReport = (CreatingEpicrisis)objectContext.GetObject(tempEpicrisisReport.ObjectID, "CreatingEpicrisis");
           //            }


           //            TTForm frm = TTForm.GetEditForm(epicrisisReport);
           //            this.PrapareFormToShow(frm);
           //            if (frm.ShowEdit(this.FindForm(), epicrisisReport) == DialogResult.OK)
           //                objectContext.Save();
           //        }
           //    }
           //    else
           //    {
           //        InfoBox.Show("Hastanın Klinik Doktor İşlemlerine Bulunmamakta.");
           //    }
           //}
           //catch (Exception ex)
           //{
           //    objectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewForensicMedicalReport(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //ForensicMedicalReport forensicMedicalReport;
           //TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = objectContext.BeginSavePoint();
           //try
           //{
           //    forensicMedicalReport = new ForensicMedicalReport(objectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(forensicMedicalReport);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), forensicMedicalReport) == DialogResult.OK)
           //        objectContext.Save();
           //    else
           //        objectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    objectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewHCExaminationFromOtherDepartments(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //HealthCommitteeExaminationFromOtherDepartments hcefod;
           //TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = objectContext.BeginSavePoint();
           //try
           //{
           //    hcefod = new HealthCommitteeExaminationFromOtherDepartments(objectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(hcefod);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), hcefod) == DialogResult.OK)
           //        objectContext.Save();
           //}
           //catch (Exception ex)
           //{
           //    objectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewHealthCommittee(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //HealthCommittee healthCommittee;
           //TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = objectContext.BeginSavePoint();
           //try
           //{
           //    healthCommittee = new HealthCommittee(objectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(healthCommittee);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), healthCommittee) == DialogResult.OK)
           //        objectContext.Save();
           //}
           //catch (Exception ex)
           //{
           //    objectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewHealthCommitteeOfProfessors(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //HealthCommitteeOfProfessors profHC;
           //TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = objectContext.BeginSavePoint();
           //try
           //{
           //    profHC = new HealthCommitteeOfProfessors(objectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(profHC);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), profHC) == DialogResult.OK)
           //        objectContext.Save();
           //}
           //catch (Exception ex)
           //{
           //    objectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewHealthCommitteeWithThreeSpecialist(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //HealthCommitteeWithThreeSpecialist hcw3s;
           ////            TTObjectContext objectContext = new TTObjectContext(false);
           ////            Guid savePointGuid = objectContext.BeginSavePoint();
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    hcw3s = new HealthCommitteeWithThreeSpecialist(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(hcw3s);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), hcw3s) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewLaboratoryRequest(objDef: TTObjectDef, resSectionGuid: Guid): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////SaveContextForNewDiagnose();
           ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           ////TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    EpisodeAction testRequest = null;
           //    if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(Genetic)).ID)
           //        testRequest = new Genetic(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)).ID)
           //    {
           //        if (resSectionGuid != null)
           //        {
           //            ResSection resSection = (ResSection)_EpisodeAction.ObjectContext.GetObject((Guid)resSectionGuid, typeof(ResSection).Name);
           //            testRequest = new LaboratoryRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction, resSection);
           //        }
           //        else
           //            testRequest = new LaboratoryRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    }
           //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(NuclearMedicine)).ID)
           //        testRequest = new NuclearMedicine(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyRequest)).ID)
           //        testRequest = new PathologyRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(Radiology)).ID)
           //        testRequest = new Radiology(this._EpisodeAction.ObjectContext, this._EpisodeAction);

           //    TTForm frm = TTForm.GetEditForm(testRequest);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), testRequest) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewManipulationRequest(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////SaveContextForNewDiagnose();
           //ManipulationRequest manipulationRequest;
           ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           ////TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    manipulationRequest = new ManipulationRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(manipulationRequest);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), manipulationRequest) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewNormalConsultationRequest(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////SaveContextForNewDiagnose();
           //Consultation consultationRequest;
           ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           ////TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    consultationRequest = new Consultation(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(consultationRequest);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), consultationRequest) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewOutPatientPrescription(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////SaveContextForNewDiagnose();
           //if (this._EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
           //{
           //    string presccriptionType;
           //    //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           //    //TTObjectContext objectContext = new TTObjectContext(false);

           //    string bransKodu = _EpisodeAction.ProcedureDoctor.GetSpeciality() != null ?  _EpisodeAction.ProcedureDoctor.GetSpeciality().Code : "0" ;

           //    if(bransKodu == "2900")
           //    {
           //        MultiSelectForm pForm = new MultiSelectForm();
           //        pForm.AddMSItem("Ayaktan Hasta Reçetesi", "Ayaktan Hasta Reçetesi");
           //        pForm.AddMSItem("Gözlük Reçetesi", "Gözlük Reçetesi");
           //        presccriptionType = pForm.GetMSItem(this, "Reçete Seçiniz");
           //        pForm.ClearMSItems();
           //        if(presccriptionType == "Ayaktan Hasta Reçetesi")
           //        {
           //            this.CreateOutPatientPrescription(this._EpisodeAction.ObjectContext);
           //        }
           //        else if(presccriptionType == "Gözlük Reçetesi")
           //        {
           //            GlassesReport glassesReport;
           //            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //            try
           //            {
           //                glassesReport = new GlassesReport(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //                TTForm frm = TTForm.GetEditForm(glassesReport);
           //                this.PrapareFormToShow(frm);
           //                if (frm.ShowEdit(this.FindForm(), glassesReport) != DialogResult.OK)
           //                    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //                else
           //                    this._EpisodeAction.ObjectContext.Save();
           //            }
           //            catch (Exception ex)
           //            {
           //                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //                InfoBox.Show(ex);
           //            }
           //            finally
           //            {
           //                // objectContext.Dispose();
           //            }
           //        }
           //        else
           //        {
           //            return;
           //        }
           //    }
           //    else
           //    {
           //        CreateOutPatientPrescription(this._EpisodeAction.ObjectContext);
           //    }
           //}
           //else
           //{
           //    InfoBox.Show("Ayaktan Hasta Reçetesi sadece ayaktan hastaya başlatılır.");
           //    return;
           //}
           let a = 1;
       }
       public async CreateNewParticipatnFreeDrugReport(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //ParticipatnFreeDrugReport participatnFreeDrugReport;
           ////            TTObjectContext objectContext = new TTObjectContext(false);
           ////            Guid savePointGuid = objectContext.BeginSavePoint();
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    participatnFreeDrugReport = new ParticipatnFreeDrugReport(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(participatnFreeDrugReport);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), participatnFreeDrugReport) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    // objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateNewUnavailableToWorkReport(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //UnavailableToWorkReport unavailableToWorkReport;
           ////            TTObjectContext objectContext = new TTObjectContext(false);
           ////            Guid savePointGuid = objectContext.BeginSavePoint();
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    unavailableToWorkReport = new UnavailableToWorkReport(this._EpisodeAction.ObjectContext, this._EpisodeAction);
           //    TTForm frm = TTForm.GetEditForm(unavailableToWorkReport);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), unavailableToWorkReport) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async CreateOutPatientPrescription(objectContext: TTObjectContext): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           //OutPatientPrescription outPatientPrescription;
           //Guid savePointGuid = objectContext.BeginSavePoint();
           //try
           //{
           //    outPatientPrescription = new OutPatientPrescription(objectContext, this._EpisodeAction);
           //    //glassesReport = new GlassesReport(objectContext);
           //    TTForm frm = TTForm.GetEditForm(outPatientPrescription);
           //    this.PrapareFormToShow(frm);
           //    if (frm.ShowEdit(this.FindForm(), outPatientPrescription) == DialogResult.OK)
           //        objectContext.Save();
           //    else
           //        objectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    objectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //episodeAction ın context i gönderildiği zaman dispose etmek doğru değil.
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async FillHealthCommiteeActionsGrid(HealthCommiteeActions: TTVisual.ITTGrid): Promise<void> {
           let hospID: Guid = new Guid((await SystemParameterService.GetParameterValue("HOSPITAL", Guid.Empty.toString())));
           let hospital: ResHospital = <ResHospital>this._EpisodeAction.ObjectContext.GetObject(hospID, typeof ResHospital);
           let healthCommiteeList: Array<HealthCommittee>;
           //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
           //    healthCommiteeList = HealthCommittee.GetAllHealthCommiteesOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
           //else
           healthCommiteeList = (await HealthCommitteeService.GetHealthCommiteesOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.toString()));
           for (let healthCommittee of healthCommiteeList) {
               let gridRow: TTVisual.ITTGridRow = HealthCommiteeActions.Rows.push();
               gridRow.Cells["Hospital"].Value = hospital.Name; //şimdilik şu anki XXXXXXnin ismini getiriyor.
               gridRow.Cells["HealthCommiteeActionID"].Value = (healthCommittee.ID !== null ? healthCommittee.ID.toString() : "");
               gridRow.Cells["HealthCommiteeActionDate"].Value = healthCommittee.ActionDate;
               gridRow.Cells["HCObjectID"].Value = healthCommittee.ObjectID.toString();
           }
       }
       public async FillLaboratoryResultsGrid(LaboratoryResultsGrid: TTVisual.ITTGrid): Promise<void> {
           let startDate: Date = Date.MinValue;
           let endDate: Date = Date.MaxValue;
           LaboratoryResultsGrid.Rows.Clear();
           let testProcedureList: Array<SubActionProcedure>;
           // akıllı kart devreye girdiğinde commentler açılacaktır
           // if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
           testProcedureList = (await SubActionProcedureService.GetTestsByPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.toString(), Common.RecTime().AddMonths(-3)));
           //            else
           //            {
           //                InfoBox.Show("Hastanın Akıllı Kartı Takılı olmadığı için yalnızca bu vakaya ait Tetkikler Listelenecektir");
           //                testProcedureList = SubActionProcedure.GetTestsByEpisode(this._EpisodeAction.ObjectContext, subactionObjectDefName, testProcedureObjectID, this._EpisodeAction.Episode.ObjectID.ToString());
           //            }
           for (let testProcedure of testProcedureList) {
               // rapor için parametre
               if (testProcedure.CurrentStateDef.Status !== StateStatusEnum.Cancelled) {
                   let gridRow: TTVisual.ITTGridRow = LaboratoryResultsGrid.Rows.push();
                   gridRow.Cells["ProcedureDate"].Value = testProcedure.WorkListDate;
                   gridRow.Cells["Procedure"].Value = (testProcedure.ProcedureObject !== null ? testProcedure.ProcedureObject.Name : "");
                   if (testProcedure instanceof GeneticTest)
                       gridRow.Cells["ProcedureResult"].Value = (<GeneticTest>testProcedure).Genetic.Report;
                   else if (testProcedure instanceof NuclearMedicineTest)
                       gridRow.Cells["ProcedureResult"].Value = (<NuclearMedicineTest>testProcedure).NuclearMedicine.Report;
                   else if (testProcedure instanceof LaboratoryProcedure)
                       gridRow.Cells["ProcedureResult"].Value = (await CommonService.GetRTFOfTextString((<LaboratoryProcedure>testProcedure).Result));
                   else if (testProcedure instanceof PathologyTestProcedure) {
                       let patReports: string = "Makroskopi Raporu\r\n" + (await CommonService.GetTextOfRTFString((<PathologyTestProcedure>testProcedure).Pathology.ReportMacroscopi.toString())) + "\r\n";
                       patReports += "Mikroskopi Raporu\r\n" + (await CommonService.GetTextOfRTFString((<PathologyTestProcedure>testProcedure).Pathology.ReportMicroscopi.toString())) + "\r\n";
                       patReports += "Doku İşlemi\r\n" + (await CommonService.GetTextOfRTFString((<PathologyTestProcedure>testProcedure).Pathology.ReportTissueProcedure.toString())) + "\r\n";
                       gridRow.Cells["ProcedureResult"].Value = (await CommonService.GetRTFOfTextString(patReports));
                   }
                   else if (testProcedure instanceof RadiologyTest)
                       gridRow.Cells["ProcedureResult"].Value = (<RadiologyTest>testProcedure).Report;
                   gridRow.Cells["ObjectID"].Value = testProcedure.ObjectID;
               }
           }
       }
       public async FillOldConsultationsGrid(ConsultationGrid: TTVisual.ITTGrid): Promise<void> {
           let consFromOtherHospList: Array<EpisodeAction>;
           //if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
           //    consFromOtherHospList = EpisodeAction.GetAllConsFromOtherHospOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
           //else
           consFromOtherHospList = (await EpisodeActionService.GetConsFromOtherHospOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.toString()));
           for (let ea of consFromOtherHospList) {
               let gridRow: TTVisual.ITTGridRow = ConsultationGrid.Rows.push();
               gridRow.Cells["ConsultationDate"].Value = ea.ActionDate;
               if (ea instanceof ConsultationFromOtherHospital) {
                   let consFromOtherHosp: ConsultationFromOtherHospital = <ConsultationFromOtherHospital>ea;
                   if (consFromOtherHosp.RequesterHospital !== null)
                       gridRow.Cells["RequesterHospital"].Value = consFromOtherHosp.RequesterHospital.Name;
                   gridRow.Cells["RequesterDepartment"].Value = consFromOtherHosp.RequesterResourceName;
                   if (consFromOtherHosp.RequestedReferableHospital !== null && consFromOtherHosp.RequestedReferableHospital.ResOtherHospital !== null)
                       gridRow.Cells["RequestedHospital"].Value = consFromOtherHosp.RequestedReferableHospital.ResOtherHospital.Name;
                   else if (consFromOtherHosp.RequestedExternalHospital !== null)
                       gridRow.Cells["RequestedHospital"].Value = consFromOtherHosp.RequestedExternalHospital.Name;
                   if (consFromOtherHosp.RequestedReferableResource !== null)
                       gridRow.Cells["RequestedDepartment"].Value = consFromOtherHosp.RequestedReferableResource.ResourceName;
                   else if (consFromOtherHosp.RequestedExternalDepartment !== null)
                       gridRow.Cells["RequestedDepartment"].Value = consFromOtherHosp.RequestedExternalDepartment.Name;
                   gridRow.Cells["RequestReason"].Value = (await CommonService.GetRTFOfTextString(consFromOtherHosp.RequestDescription));
                   if (consFromOtherHosp.ConsultationResultAndOffers !== null)
                       gridRow.Cells["ConsultationResultAndOffer"].Value = (await CommonService.GetRTFOfTextString(consFromOtherHosp.ConsultationResultAndOffers.toString()));
               }
           }
           let hospID: Guid = new Guid((await SystemParameterService.GetParameterValue("HOSPITAL", Guid.Empty.toString())));
           let hospital: ResHospital = <ResHospital>this._EpisodeAction.ObjectContext.GetObject(hospID, typeof ResHospital);
           let consList: Array<Consultation> = (await ConsultationService.GetAllConsultationsOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.toString()));
           for (let cons of consList) {
               let gridRow: TTVisual.ITTGridRow = ConsultationGrid.Rows.push();
               gridRow.Cells["ConsultationDate"].Value = cons.ActionDate;
               if (hospital !== null) {
                   gridRow.Cells["RequesterHospital"].Value = hospital.Name;
                   gridRow.Cells["RequestedHospital"].Value = hospital.Name;
               }
               gridRow.Cells["RequesterDepartment"].Value = (cons.RequesterResource !== null ? cons.RequesterResource.Name : "");
               gridRow.Cells["RequestedDepartment"].Value = (cons.MasterResource !== null ? cons.MasterResource.Name : "");
               gridRow.Cells["RequestReason"].Value = cons.RequestDescription;
               gridRow.Cells["ConsultationResultAndOffer"].Value = cons.ConsultationResultAndOffers;
           }
           //BindingList<EpisodeAction> anesthesiaConsList = EpisodeAction.GetAllAnesthesiaConsultationOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
           //foreach (EpisodeAction ea in anesthesiaConsList)
           //{
           //    ITTGridRow gridRow = ConsultationGrid.Rows.Add();
           //    gridRow.Cells["ConsultationDate"].Value = ea.ActionDate;
           //    if (ea is AnesthesiaConsultation)
           //    {
           //        AnesthesiaConsultation anesthesiaConsultation = (AnesthesiaConsultation)ea;
           //        if (hospital != null)
           //        {
           //            gridRow.Cells["RequesterHospital"].Value = hospital.Name;
           //            gridRow.Cells["RequestedHospital"].Value = hospital.Name;
           //        }
           //        gridRow.Cells["RequesterDepartment"].Value = (anesthesiaConsultation.FromResource != null ? anesthesiaConsultation.FromResource.Name : "");
           //        gridRow.Cells["RequestedDepartment"].Value = (anesthesiaConsultation.MasterResource != null ? anesthesiaConsultation.MasterResource.Name : "");
           //        gridRow.Cells["RequestReason"].Value = anesthesiaConsultation.ConsultationRequestNote;
           //        gridRow.Cells["ConsultationResultAndOffer"].Value = anesthesiaConsultation.ConsultationResult;
           //    }
           //}
           let a = 1;
       }
       public async FillOldManipulationsGrid(ManipulationGrid: TTVisual.ITTGrid): Promise<void> {
           let manipulationProcedureList: Array<ManipulationProcedure>;
           //            if (this._EpisodeAction.Episode.Patient.IsSmartCardActive == true)
           //                manipulationProcedureList = ManipulationProcedure.GetAllManipulationProceduresOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.ToString());
           //            else
           manipulationProcedureList = (await ManipulationProcedureService.GetManipulationProceduresOfEpisode(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.ObjectID.toString()));
           for (let mp of manipulationProcedureList) {
               let gridRow: TTVisual.ITTGridRow = ManipulationGrid.Rows.push();
               gridRow.Cells["ManipulationActionDate"].Value = mp.ActionDate;
               if (mp.ProcedureObject !== null)
                   gridRow.Cells["ProcedureObject"].Value = mp.ProcedureObject.ObjectID;
               gridRow.Cells["Emergency"].Value = mp.Emergency;
               if (mp.ProcedureDepartment !== null)
                   gridRow.Cells["Department"].Value = mp.ProcedureDepartment.ObjectID;//emin değilim
               if (mp.ProcedureDoctor !== null)
                   gridRow.Cells["ManipulationDoctor"].Value = mp.ProcedureDoctor.ObjectID;
               gridRow.Cells["Description"].Value = mp.Description;
           }
       }
       public async FillOldPhysicianExaminationsGrid(PhysicianExaminationsGrid: TTVisual.ITTGrid): Promise<void> {
           let examList: Array<EpisodeAction> = (await EpisodeActionService.GetAllExaminationsOfPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID.toString()));
           let examinationIndication: Object = null;
           for (let ea of examList) {
               if (ea instanceof PatientExamination) {
                   let pa: PatientExamination = <PatientExamination>ea;
                   examinationIndication = pa.PhysicalExamination;
               }
               else if (ea instanceof FollowUpExamination) {
                   let fe: FollowUpExamination = <FollowUpExamination>ea;
                   examinationIndication = fe.PhysicalExamination;
               }
               else if (ea instanceof InPatientPhysicianApplication) {
                   let ippa: InPatientPhysicianApplication = <InPatientPhysicianApplication>ea;
                   examinationIndication = ippa.PhysicalExamination;
               }
               if (examinationIndication !== null) {
                   let gridRow: TTVisual.ITTGridRow = PhysicianExaminationsGrid.Rows.push();
                   gridRow.Cells["ExaminationDateTime"].Value = ea.ActionDate.Value;
                   gridRow.Cells["ExaminationIndication"].Value = examinationIndication;
               }
           }
       }
       public async FireNewDrugOrderIntroduction(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////SaveContextForNewDiagnose();
           //DrugOrderIntroduction drugOrderIntroduction;
           ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           ////TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    drugOrderIntroduction = new DrugOrderIntroduction(this._EpisodeAction.ObjectContext);
           //    drugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.States.New;
           //    drugOrderIntroduction.Episode = _EpisodeAction.Episode;
           //    TTForm frm = TTForm.GetEditForm(drugOrderIntroduction);
           //    this.PrapareFormToShow(frm);
           //    if(frm.ShowEdit(this.FindForm(), drugOrderIntroduction) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }
       public async FireNewImportantMedicalInfo(): Promise<void> {
           //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
           ////            TTObject ttObject = this._EpisodeAction.Episode.Patient.ImportantMedicalInformation;
           ////            if (ttObject != null)
           ////            {
           ////                TTForm frm = TTForm.GetEditForm(ttObject);
           ////                if (frm != null)
           ////                {
           ////                    DialogResult dialog = frm.ShowReadOnly(this.FindForm(), ttObject);
           ////                }
           ////            }
           ////            else
           ////                InfoBox.Show("Hastaya ait Önemli Tıbbi Bilgi işlemi kaydedilmemiştir.", MessageIconEnum.InformationMessage);

           ////SaveContextForNewDiagnose();
           //ImportantMedicalInformation importantMedicalInformation;
           ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
           ////TTObjectContext objectContext = new TTObjectContext(false);
           //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
           //try
           //{
           //    importantMedicalInformation = new ImportantMedicalInformation(this._EpisodeAction.ObjectContext);
           //    importantMedicalInformation.CurrentStateDefID = ImportantMedicalInformation.States.New;
           //    importantMedicalInformation.Episode = _EpisodeAction.Episode;
           //    TTForm frm = TTForm.GetEditForm(importantMedicalInformation);
           //    this.PrapareFormToShow(frm);
           //    if(frm.ShowEdit(this.FindForm(), importantMedicalInformation) == DialogResult.OK)
           //        this._EpisodeAction.ObjectContext.Save();
           //    else
           //        this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //}
           //catch (Exception ex)
           //{
           //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
           //    InfoBox.Show(ex);
           //}
           //finally
           //{
           //    //objectContext.Dispose();
           //}
           let a = 1;
       }*/

    // *****Method declarations end *****


    public initViewModel(): void {

        this._TTObject = new EpisodeAction();
        this.baseNewDoctorExaminationFormViewModel = new BaseNewDoctorExaminationFormViewModel();
        this._ViewModel = this.baseNewDoctorExaminationFormViewModel;
        this.baseNewDoctorExaminationFormViewModel._EpisodeAction = this._TTObject as EpisodeAction;
    }

    protected loadViewModel() {

        //let that = this;

        //that.baseNewDoctorExaminationFormViewModel = this._ViewModel as BaseNewDoctorExaminationFormViewModel;
        //that._TTObject = this.baseNewDoctorExaminationFormViewModel._EpisodeAction;
        //if (this.baseNewDoctorExaminationFormViewModel == null)
        //    this.baseNewDoctorExaminationFormViewModel = new BaseNewDoctorExaminationFormViewModel();
        //if (this.baseNewDoctorExaminationFormViewModel._EpisodeAction == null)
        //    this.baseNewDoctorExaminationFormViewModel._EpisodeAction = new EpisodeAction();
        //if (this._EpisodeAction != null && this._EpisodeAction.ProcedureSpeciality != null) {
        //    if (typeof this._EpisodeAction.ProcedureSpeciality != "string") {
        //        this.procedureSpecialityName = this._EpisodeAction.ProcedureSpeciality.Name;

        //    if (this._EpisodeAction.ProcedureSpeciality.SpecialityBasedObjectType != null) {
        //        this.hasSpecialityBasedObject = true;

        if (this._ViewModel.procedureSpecialityName == i18n("M10452", "Acil Tıp"))
            this.hasEmergencySpecialityBasedObject = false;
        //    }
        //}

    }




    async ngOnInit() {
        let that = this;
        await this.load(BaseNewDoctorExaminationFormViewModel);

    }


    protected redirectProperties(): void {

    }

    public initFormControls(): void {

    }

}