//$8E0F5263
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { HCNewFormViewModel, HCRequestReasonDetail, HCCommissionList } from './HCNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseHealthCommittee_HospitalsUnitsGrid, PatientExamination, MemberOfHealthCommitteeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { HealthCommittee } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeService } from "ObjectClassService/SubEpisodeService";
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { PatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { BaseHealthCommittee_ExtDoctorGrid } from 'NebulaClient/Model/AtlasClientModel';
import { MemberOfHealthCommiittee } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTUser } from "NebulaClient/StorageManager/Security/TTUser";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { DxDataGridComponent } from 'devextreme-angular';
import { HttpClient } from '@angular/common/http';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { GetHCRequestReasonDetailsResponse } from './HCNewFormViewModel';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { InputForm } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: 'HCNewForm',
    templateUrl: './HCNewForm.html',
    providers: [MessageService]
})
export class HCNewForm extends EpisodeActionForm  implements OnInit {
    DoctorBaseHealthCommittee_HospitalsUnitsGrid: TTVisual.ITTListBoxColumn;
    DoctorSpecialityRegNo: TTVisual.ITTTextBoxColumn;
    DoctorTescilNumber: TTVisual.ITTTextBoxColumn;
    DocumentDate: TTVisual.ITTDateTimePicker;
    DocumentNumber: TTVisual.ITTTextBox;
    EntryDate: TTVisual.ITTTextBoxColumn;
    ExaminationStateInfo: TTVisual.ITTTextBoxColumn;
    DisableRatioInfo: TTVisual.ITTTextBoxColumn;
    ExternalDoctorInfo: TTVisual.ITTLabel;
    ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTTextBoxColumn;
    ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTTextBoxColumn;
    ExternalDoctors: TTVisual.ITTGrid;
    ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTTextBoxColumn;
    HCRequestReason: TTVisual.ITTObjectListBox;
    Height: TTVisual.ITTTextBox;
    HospitalsUnits: TTVisual.ITTGrid;
    labelDocumentDate: TTVisual.ITTLabel;
    labelHCRequestReason: TTVisual.ITTLabel;
    LabelMasterResource: TTVisual.ITTLabel;
    labelNumberOfDocumnets: TTVisual.ITTLabel;
    labelNumberOfProcedure: TTVisual.ITTLabel;
    labelReasonForExaminationHCRequestReason: TTVisual.ITTLabel;
    labelReturnDescription: TTVisual.ITTLabel;
    LinkedActionState: TTVisual.ITTTextBoxColumn;
    MasterResource: TTVisual.ITTObjectListBox;
    MemberDoctorMemberOfHealthCommiittee: TTVisual.ITTListBoxColumn;
    Members: TTVisual.ITTGrid;
    NumberOfProcedure: TTVisual.ITTTextBox;
    HospitalProtocolNo: TTVisual.ITTTextBox;
    OwnerUser: TTVisual.ITTTextBoxColumn;
    ReasonForExaminationHCRequestReason: TTVisual.ITTObjectListBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    ReturnDescription: TTVisual.ITTTextBoxColumn;
    ReturnDescriptionGrid: TTVisual.ITTGrid;
    SpecialityBaseHealthCommittee_ExtDoctorGrid: TTVisual.ITTListBoxColumn;
    SpecialityBaseHealthCommittee_HospitalsUnitsGrid: TTVisual.ITTListBoxColumn;
    SpecialityMemberOfHealthCommiittee: TTVisual.ITTListBoxColumn;
    ttgroupbox1: TTVisual.ITTGroupBox;
    labelUnCompletedExaminationExists: string;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    tttabcontrolMain: TTVisual.ITTTabControl;
    tttabpageHC: TTVisual.ITTTabPage;
    UnitBaseHealthCommittee_HospitalsUnitsGrid: TTVisual.ITTListBoxColumn;
    Weight: TTVisual.ITTTextBox;
    WhoPays: TTVisual.ITTEnumComboBox;
    public ExternalDoctorsColumns = [];
    public HospitalsUnitsColumns = [];
    public MembersColumns = [];
    public ReturnDescriptionGridColumns = [];
    @ViewChild('externalDoctorsGrid') externalDoctorsGrid: DxDataGridComponent;
    @ViewChild('memberDoctorsGrid') memberDoctorsGrid: DxDataGridComponent;
    private _PatientAdmission: string;
    public setMemberspecialityValueFunc: Function;
    public setMemberDoctorValueFunc: Function;
    public tempDoctorandTechnicianList= [];
    public commissionList : Array <HCCommissionList>= new Array<HCCommissionList>();
    public ShowHcCommission: boolean = false;
    public _selectedCommission = null;
    public hCNewFormViewModel: HCNewFormViewModel = new HCNewFormViewModel();
    public get _HealthCommittee(): HealthCommittee {
        return this._TTObject as HealthCommittee;
    }
    private HCNewForm_DocumentUrl: string = '/api/HealthCommitteeService/HCNewForm';
    constructor(protected httpService: NeHttpService, protected httpService2: HttpClient,
         private objectContextService: ObjectContextService,
                protected messageService: MessageService,
                protected ngZone: NgZone,
                private sideBarMenuService: ISidebarMenuService,
                protected modalService: IModalService) {
        super(httpService , messageService, ngZone);
        this._DocumentServiceUrl = this.HCNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

        this.setMemberspecialityValueFunc = this.setMemberspecialityValue.bind(this);
        this.setMemberDoctorValueFunc = this.setMemberDoctorValue.bind(this);
    }


    // ***** Method declarations start *****

    private async ControlUserResourceExistsInGrid(): Promise<void> {
        let resourceExists: boolean;
        let apiUrlForResourceExists: string = '/api/HealthCommitteeService/IsResourceExists?HCObjectID=' + this._HealthCommittee.ObjectID;
        resourceExists = <boolean>await this.httpService.get(apiUrlForResourceExists);

        if (!resourceExists)
            throw new TTException(i18n("M21192", "Sağlık Kurulu işlemi başlatabilmek için bağlı olduğunuz birimlerden en az biri seçili olmalıdır."));
    }
    private async ReturnDescriptionInput(): Promise<void> {
        //TODO:ShowEdit!
        //StringEntryForm pReturnForm = new StringEntryForm();
        //DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
        //if (res == DialogResult.OK)
        //{
        //    HealthCommittee_ReturnDescriptionsGrid theGrid = null;
        //    theGrid = new HealthCommittee_ReturnDescriptionsGrid(this._HealthCommittee.ObjectContext);
        //    theGrid.Description = pReturnForm.StringContent;
        //    theGrid.EntryDate = DateTime.Now;
        //    theGrid.UserName = Common.CurrentResource == null ? "" : Common.CurrentResource.Name;

        //    this._HealthCommittee.ReturnDescriptions.Add(theGrid);
        //}
        let a = 1;
    }

    async setReasonOfCancel(note: string, type: string) {
        let returnReason: string = await InputForm.GetText(note + i18n("M14794", " İptal Nedeni Giriniz."), "", true, true);
        if (returnReason != null && returnReason != "" && typeof returnReason === "string") {
            let recTime: Date = (await CommonService.RecTime());
            let recTimeString = recTime.getDate() + "."+ (recTime.getMonth() +1)+ "."+ recTime.getFullYear()+ " " +recTime.getHours()+ ":"+recTime.getMinutes();
            let iptalEden=<ResUser>TTUser.CurrentUser.UserObject;
            this.hCNewFormViewModel._HealthCommittee.ReasonOfCancel ="İptal Zamanı=" + recTimeString + " \r\n <br/> İptal Eden="+ iptalEden.Name +" \r\n <br/>  İptal Nedeni="+ type + returnReason;
        }
        else
            throw new Exception(i18n("M16563", "İptal sebebini girmeden işleme devam edemezsiniz."));

    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        if (this.hCNewFormViewModel.IsDisabled) {
           
            let disabledReportReSendButton = new DynamicSidebarMenuItem();
            disabledReportReSendButton.key = 'disabledReportReSendButton';
            disabledReportReSendButton.componentInstance = this;
            disabledReportReSendButton.label = 'Entegrasyon Verisini Tekrar Gönder';
            disabledReportReSendButton.icon = 'ai ai-recete';
            disabledReportReSendButton.clickFunction = this.reSendEntegrationForDisabledReport;
            this.sideBarMenuService.addMenu('YardimciMenu', disabledReportReSendButton);
        }

        let openHCMemberDef = new DynamicSidebarMenuItem();
        openHCMemberDef.key = 'openHCMemberDef';
        openHCMemberDef.componentInstance = this;
        openHCMemberDef.label = 'Heyet Tanım Ekranı';
        openHCMemberDef.icon = 'fas fa-users';
        openHCMemberDef.clickFunction = this.showMemberDefSelection;
        this.sideBarMenuService.addMenu('YardimciMenu', openHCMemberDef);

    }

    private RemoveMenuFromHelpMenu() {
        if (this.hCNewFormViewModel.IsDisabled) {           
            this.sideBarMenuService.removeMenu('disabledReportReSendButton');
        }

        this.sideBarMenuService.removeMenu('openHCMemberDef');
    }

    private showMemberDefSelection()
    {
        let that = this;
        this.httpService.get<Array<HCCommissionList>>("api/HealthCommitteeService/GetHcCommissionList/")
            .then(result => {
                this.commissionList = result as Array<HCCommissionList>;

                if (this.commissionList != null && this.commissionList.length > 0) {
                    this.ShowHcCommission = true;
                }

            })
            .catch(error => {
                that.messageService.showError(error);
            });

    }

    private openHCMemberDefinitionForm(isNew:boolean): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MemberOfHealthCommitteeDefinitionForm";
            componentInfo.ModuleName = "SaglikKuruluModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Saglik_Kurulu_Modulu/SaglikKuruluModule";
            componentInfo.InputParam = new DynamicComponentInputParam("", null);
            if(isNew)
                componentInfo.objectID = null;
            else
                componentInfo.objectID = this._selectedCommission;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Heyet Tanım Ekranı";
           
            modalInfo.Width = 960;
            modalInfo.Height = 700;
            // modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public reSendEntegrationForDisabledReport() {
        let fullApiUrl: string = 'api/EDisabledReportService/ReSendEReportApplication?healthCommitteeOjbectId=' + this.hCNewFormViewModel._HealthCommittee.ObjectID.toString();
        this.httpService.get(fullApiUrl).then((res: string) => {
            TTVisual.InfoBox.Alert(res);
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }
    private async SetEpisodeRelations(): Promise<void> {
        //            MilitaryClassDefinitions militaryClass= this._HealthCommittee.Episode.MyMilitaryClass();
        //            if (militaryClass!=null)
        //            {
        //                this.MilitaryClass.SelectedObjectID=militaryClass.ObjectID;
        //            }

        //            RankDefinitions rank= this._HealthCommittee.Episode.MyRank();
        //            if (rank!=null)
        //            {
        //                this.Rank.SelectedObjectID=rank.ObjectID;
        //            }

        //            MilitaryOffice militaryOffice = this._HealthCommittee.Episode.MyMilitaryOffice();
        //            if (militaryOffice!=null)
        //            {
        //                this._HealthCommittee.LocalBranch = militaryOffice;
        //                this.MilitaryOffice.SelectedObjectID=militaryOffice.ObjectID;
        //            }

        //if (this._HealthCommittee.CurrentStateDefID == HealthCommittee.States.New)
        //    this._HealthCommittee.LocalBranch = this._HealthCommittee.Episode.MilitaryOffice;

        //RelationshipDefinition relationship = this._HealthCommittee.Episode.MyRelationship();
        //if (relationship != null)
        //{
        //    this.Relationship.SelectedObjectID = relationship.ObjectID;
        //}

        //string headOfFamilyName = this._HealthCommittee.Episode.MyHeadOfFamilyName();
        //if (headOfFamilyName != null)
        //{
        //    this.HeadOfFamilyName.Text = headOfFamilyName;
        //}



        //this.EmploymentRecordID.Text = this._HealthCommittee.Episode.MyEmploymentRecordID();

        //            MilitaryUnit pMUnit = this._HealthCommittee.Episode.MyMilitaryUnit();
        //            if(pMUnit != null)
        //            {
        //                this.MilitaryUnit.SelectedObjectID = pMUnit.ObjectID;
        //            }

        //this.Adres.Text = this._HealthCommittee.Episode.MyAddress();


        let subEpisode: SubEpisode = await this.objectContextService.getObject<SubEpisode>(new Guid(this.hCNewFormViewModel._HealthCommittee.SubEpisode.toString()), SubEpisode.ObjectDefID, SubEpisode);
        //subEpisode["OrginalValues"] = {};
        //subEpisode.ObjectID = new Guid(<any>this._HealthCommittee["SubEpisode"] as string);
        //subEpisode.Episode = this._HealthCommittee.Episode;

        this.DocumentNumber.Text = (await SubEpisodeService.MyDocumentNumber(subEpisode));
        let pDocDate: Date = (await SubEpisodeService.MyDocumentDate(subEpisode));
        if (pDocDate !== null)
            this.DocumentDate.NullableValue = pDocDate;
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        await this.load(HCNewFormViewModel);
        //if (transDef !== null) {
        //    // "Yeni" veya "Tamamlanmamış SK Onay" adımlarından "SKM Fişi İstek" adımına geçerken HCUncompleted merkezde oluşturulur
        //    //if((transDef.FromStateDefID == HealthCommittee.States.New || transDef.FromStateDefID == HealthCommittee.States.ApproveOfHCUncompleted) &&
        //    //   transDef.ToStateDefID == HealthCommittee.States.HCESlipRequest)
        //    //    this._HealthCommittee.RunCreateHCUncompleted(HCUncompleted.States.Uncompleted);

        //    if (transDef.FromStateDefID.valueOf()  === HealthCommittee.HealthCommitteeStates.New.id) {
        //        // Laboratuvar isteklerinin LabAsistan'a düşmesi için eklendi
        //        //if (transDef.ToStateDefID.valueOf()  === HealthCommittee.HealthCommitteeStates.CommitteeAcceptance.id)
        //        //    (await HealthCommitteeService.SendToLab(this._HealthCommittee));

        //        /* NE
        //    if (transDef.ToStateDefID === HealthCommittee.HealthCommitteeStates.CommitteeAcceptance) {
        //        let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
        //        let cache: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
        //        cache.push("VALUE", this._HealthCommittee.ObjectID.toString());
        //        parameters.push("TTOBJECTID", cache);
        //        if (this._HealthCommittee.HCRequestReason.ReasonForExamination.Code === 36)
        //            TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_SpecialCareExaminationReport, true, 1, parameters);
        //        else {
        //            if (this._HealthCommittee.HCRequestReason.ReasonForExamination.HealthCommitteeType === HealthCommitteeTypeEnum.FlierCommittee) {
        //                if (this._HealthCommittee.HCRequestReason.ReasonForExamination.ExaminationType === ExaminationTypeEnum.FlierExaminationForFiveYear)
        //                    TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_HCEFlierSlipReportForFiveYears, true, 1, parameters);
        //                else TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_HealthCommitteeExaminationFlierSlipReport, true, 1, parameters);
        //            }
        //            else TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_HealthCommitteeExaminationSlipReport, true, 1, parameters);
        //        }
        //    }
        //    */
        //    }
        //}
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if(this._HealthCommittee.ClinicHeight < 0)
            throw new Exception("Boy bilgisi negatif olamaz");
        if(this._HealthCommittee.ClinicWeight < 0)
            throw new Exception("Kilo bilgisi negatif olamaz");            
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            //if (transDef.ToStateDefID.Equals(HealthCommittee.States.Rejected))
            //{
            //    StringEntryForm pDescForm = new StringEntryForm();
            //    DialogResult res = pDescForm.ShowStringDialog(this, "Red Açıklamasını Giriniz");
            //    if (res == DialogResult.OK)
            //        this._HealthCommittee.ReasonOfReject = pDescForm.StringContent;
            //}

            if (transDef.FromStateDefID.valueOf().Equals(HealthCommittee.HealthCommitteeStates.CommitteeAcceptance.id) && transDef.ToStateDefID.valueOf().Equals(HealthCommittee.HealthCommitteeStates.New.id)) {
                this.ReturnDescriptionInput();
            }
            if (transDef.ToStateDefID.valueOf() == HealthCommittee.HealthCommitteeStates.Cancelled.id)
                await this.setReasonOfCancel(i18n("M16561", "İptal Sebebi :"), i18n("M16527", "İptal - "));
        }

        this.tempDoctorandTechnicianList =this.hCNewFormViewModel.DoctorandTechnicianList ;
        this.hCNewFormViewModel.DoctorandTechnicianList = null;//null'lıyor cünkü servise dolu giderse serialize hatası alıyor
        // this.hCNewFormViewModel.DoctorandTechnicianList = x;

    }
    protected async ClientSidePreScript(): Promise<void> {
        await super.ClientSidePreScript();
        if (this._HealthCommittee.CurrentStateDefID.valueOf() == HealthCommittee.HealthCommitteeStates.New.id && this._HealthCommittee.Episode != null && this._HealthCommittee.Episode.HealthCommittees != null) {
            for (let healthCommittee of this._HealthCommittee.Episode.HealthCommittees) {
                if (!healthCommittee.IsCancelled && healthCommittee.ObjectID !== this._HealthCommittee.ObjectID) {
                    let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), "Vakada zaten aktif bir Sağlık Kurulu işlemi mevcuttur. Yeni bir Sağlık Kurulu işlemi başlatmak istediğinize emin misiniz ?", 1);
                    if (result === "H")
                        throw new Exception((await SystemMessageService.GetMessage(1201)));
                    break;
                }
            }
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        await super.PostScript(transDef);
        this._HealthCommittee.Requester = TTUser.CurrentUser.UserObject as ResUser; // İsteği yapan kullanıcı ataması
        if (transDef !== null) {
            if (transDef.FromStateDefID.valueOf().Equals(HealthCommittee.HealthCommitteeStates.New.id)) {
                if (this._HealthCommittee.HCRequestReason.ReasonForExamination === null)
                    throw new TTException((await SystemMessageService.GetMessage(494)));
                // this.ControlUserResourceExistsInGrid();
            }
        }

        if(this.hCNewFormViewModel._HealthCommittee.ExternalDoctors != null){
            this.hCNewFormViewModel._HealthCommittee.ExternalDoctors.forEach(item => {
                if(String.isNullOrEmpty(item.ExternalDoctorName) || String.isNullOrEmpty(item.ExternalDoctorRegNumber) || item.Speciality == null)
                    throw new TTException("Eklenmiş olan dış doktorun bilgileri boş olamaz!");
            })
        }
    }

    protected async onSetState(saveInfo: FormSaveInfo): Promise<void> {
        
        try {
            this.reThrowSetStateException = true;//state geçişinde hata alırsa hatayı fırlatması için
            await super.setStateToTransition(saveInfo);
        }
        catch (ex) {
            this.hCNewFormViewModel.DoctorandTechnicianList = this.tempDoctorandTechnicianList;//hata aldı ise yukarda null'lanan listeyi yeniden yüklemesi için
        }
    }

    protected async PreScript() {
        await super.PreScript();
        this.SetEpisodeRelations();
        if (this._HealthCommittee.CurrentStateDefID.valueOf()  == HealthCommittee.HealthCommitteeStates.New.id) {

            //TODO: NE: yeni süreç oladığı için kapatıldı
            /*
                        // BLOCKHCFROMNEWPROCESS sistem parametresi TRUE ise Ayaktan hastalar için yeni süreçten Sağlık Kurulu işlemi başlatılamaması kontrolü
                        if ((await SystemParameterService.GetParameterValue("BLOCKHCFROMNEWPROCESS", "FALSE")).toLocaleUpperCase() === "TRUE" && this._HealthCommittee.Episode.PatientStatus === PatientStatusEnum.Outpatient) {
                            let iTTobject: ITTObject = <ITTObject>this._HealthCommittee;
                            if (iTTobject.IsNew)
                                throw new Exception("Ayaktan hastalar için Sağlık Kurulu işlemi yeni süreçten başlatılamaz. Sadece kabul sebebi 'Sağlık Kurulu Muayenesi' olan yeni hasta kabul yaparak başlatılabilir.");
                        }
                        */

            // İşlemi başlatan doktor set edilir
            //  this.SetProcedureDoctorAsCurrentResource();
            /*
            if(TTObjectClasses.SystemParameter.GetParameterValue("GETCOMPLETEDHCSUMMARIES","FALSE").ToUpper() == "TRUE")
            {
                // Önceki Sağlık Kurulu İşlemleri getirilir
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(HealthCommittee.RunGetHCSummariesThead));
                t.Start(this._HealthCommittee);
            }
            */

            // Butonlar drop edilir
            //  this.Text = "Sağlık Kurulu İstek(" + this._HealthCommittee.CurrentStateDef.DisplayText + ")";
            this.DropStateButton(HealthCommittee.HealthCommitteeStates.Cancelled);
            //this.cmdOK.Visible = false;


            // Kabul türüne göre, Yeni adımında "Periyodik Muayene" veya "Özel Bakım Muayenesi" set edilir
            //todo bg
            /*
            if (this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.PeriodicExamination)
            {
                ReasonForExaminationDefinition perExamdef = Common.ReasonForExaminationByCode(this._EpisodeAction.ObjectContext, 19);
                if (perExamdef != null)
                    this._HealthCommittee.HCRequestReason.ReasonForExamination = perExamdef;
                else
                    InfoBox.Alert(SystemMessage.GetMessage(490));
            }
            else if (this._EpisodeAction.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.SpacialCareExamReport)
            {
                ReasonForExaminationDefinition speExamdef = Common.ReasonForExaminationByCode(this._EpisodeAction.ObjectContext, 36);
                if (speExamdef != null)
                    this._HealthCommittee.HCRequestReason.ReasonForExamination = speExamdef;
                else
                    InfoBox.Alert(SystemMessage.GetMessage(492));
            }*/
            // İlgili klasörde fotoğraf bulunursa eklenir



        }
        else {

        }
        if (this._HealthCommittee.ReturnDescriptions != null && this._HealthCommittee.ReturnDescriptions.length > 0) {
            this.ReturnDescriptionGrid.Visible = true;
            this.labelReturnDescription.Visible = true;
            this.ReturnDescriptionGrid.Rows.Clear();
            for (let pGrid of this._HealthCommittee.ReturnDescriptions) {
                if (pGrid.RelatedStateID !== null && pGrid.RelatedStateID === this._HealthCommittee.CurrentStateDefID.toString()) {
                    let newRow: TTVisual.ITTGridRow = this.ReturnDescriptionGrid.Rows.push() as TTVisual.ITTGridRow;
                    newRow.Cells["EntryDate"].Value = pGrid.EntryDate.Value.toString();
                    newRow.Cells["ReturnDescription"].Value = pGrid.Description;
                    newRow.Cells["OwnerUser"].Value = pGrid.UserName;
                }
            }
        }
        if (this.hCNewFormViewModel.IsUnCompletedExaminationExists)
            this.labelUnCompletedExaminationExists = i18n("M22112", "Sonuçlanmamış Sağlık Kurulu Muayene İşlemleri Mevcut !");
        else
            this.labelUnCompletedExaminationExists = i18n("M21209", "Sağlık Kurulu Muayene İşlemleri Sonuçlanmıştır");
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HealthCommittee();
        this.hCNewFormViewModel = new HCNewFormViewModel();
        this._ViewModel = this.hCNewFormViewModel;
        this.hCNewFormViewModel._HealthCommittee = this._TTObject as HealthCommittee;
        this.hCNewFormViewModel._HealthCommittee.Members = new Array<MemberOfHealthCommiittee>();
        this.hCNewFormViewModel._HealthCommittee.Episode = new Episode();
        this.hCNewFormViewModel._HealthCommittee.HCRequestReason = new HCRequestReason();
        this.hCNewFormViewModel._HealthCommittee.HCRequestReason.ReasonForExamination = new ReasonForExaminationDefinition();
        this.hCNewFormViewModel._HealthCommittee.HospitalsUnits = new Array<BaseHealthCommittee_HospitalsUnitsGrid>();
	    this.hCNewFormViewModel._HealthCommittee.ExternalDoctors = new Array<BaseHealthCommittee_ExtDoctorGrid>();
        this.hCNewFormViewModel._HealthCommittee.MasterResource = new ResSection();
    }

    protected loadViewModel() {
        let that = this;
        let gridSortID = 0;
        that.hCNewFormViewModel = this._ViewModel;
        that._TTObject = this.hCNewFormViewModel._HealthCommittee;
        if (this.hCNewFormViewModel == null)
            this.hCNewFormViewModel = new HCNewFormViewModel();
        if (this.hCNewFormViewModel._HealthCommittee == null)
            this.hCNewFormViewModel._HealthCommittee = new HealthCommittee();

        that.hCNewFormViewModel._HealthCommittee.Members = that.hCNewFormViewModel.MembersGridList;
        for (let detailItem of that.hCNewFormViewModel.MembersGridList) {
            let memberDoctorObjectID = detailItem["MemberDoctor"];
            if (memberDoctorObjectID != null && (typeof memberDoctorObjectID === "string")) {
                let memberDoctor = that.hCNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === memberDoctorObjectID.toString());
                if (memberDoctor) {
                    detailItem.MemberDoctor = memberDoctor;
                }
            }

            let specialityObjectID = detailItem["Speciality"];
            if (specialityObjectID != null && (typeof specialityObjectID === "string")) {
                let speciality = that.hCNewFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityObjectID.toString());
                if (speciality) {
                    detailItem.Speciality = speciality;
                }
            }

            detailItem["sortID"] = gridSortID;
            gridSortID = gridSortID + 1;

        }

        gridSortID = 0;

        that.hCNewFormViewModel._HealthCommittee.ExternalDoctors = that.hCNewFormViewModel.ExternalDoctorsGridList;
        for (let detailItem of that.hCNewFormViewModel.ExternalDoctorsGridList) {
            let specialityObjectID = detailItem["Speciality"];
            if (specialityObjectID != null && (typeof specialityObjectID === "string")) {
                let speciality = that.hCNewFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityObjectID.toString());
                if (speciality) {
                    detailItem.Speciality = speciality;
                }
            }

            detailItem["sortID"] = gridSortID;
            gridSortID = gridSortID + 1;

        }

        gridSortID = 0;

        let episodeObjectID = that.hCNewFormViewModel._HealthCommittee["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.hCNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.hCNewFormViewModel._HealthCommittee.Episode = episode;
            }
            let hCRequestReasonObjectID = that.hCNewFormViewModel._HealthCommittee["HCRequestReason"];
            if (hCRequestReasonObjectID != null && (typeof hCRequestReasonObjectID === 'string')) {
                let hCRequestReason = that.hCNewFormViewModel.HCRequestReasons.find(o => o.ObjectID.toString() === hCRequestReasonObjectID.toString());
                 if (hCRequestReason) {
                    that.hCNewFormViewModel._HealthCommittee.HCRequestReason = hCRequestReason;
                }
                if (hCRequestReason != null) {
                    let reasonForExaminationObjectID = hCRequestReason["ReasonForExamination"];
                    if (reasonForExaminationObjectID != null && (typeof reasonForExaminationObjectID === 'string')) {
                        let reasonForExamination = that.hCNewFormViewModel.ReasonForExaminationDefinitions.find(o => o.ObjectID.toString() === reasonForExaminationObjectID.toString());
                         if (reasonForExamination) {
                            hCRequestReason.ReasonForExamination = reasonForExamination;
                        }
                    }
                }
            }
            that.hCNewFormViewModel._HealthCommittee.HospitalsUnits = that.hCNewFormViewModel.HospitalsUnitsGridList;
            for (let detailItem of that.hCNewFormViewModel.HospitalsUnitsGridList) {
                let doctorObjectID = detailItem["Doctor"];
                if (doctorObjectID != null && (typeof doctorObjectID === 'string')) {
                    let doctor = that.hCNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === doctorObjectID.toString());
                     if (doctor) {
                        detailItem.Doctor = doctor;
                    }
                }
                let unitObjectID = detailItem["Unit"];
                if (unitObjectID != null && (typeof unitObjectID === 'string')) {
                    let unit = that.hCNewFormViewModel.ResSections.find(o => o.ObjectID.toString() === unitObjectID.toString());
                     if (unit) {
                        detailItem.Unit = unit;
                    }
                }
                let specialityObjectID = detailItem["Speciality"];
                if (specialityObjectID != null && (typeof specialityObjectID === 'string')) {
                    let speciality = that.hCNewFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityObjectID.toString());
                     if (speciality) {
                        detailItem.Speciality = speciality;
                    }
                }


                if (doctorObjectID != null && (typeof doctorObjectID === 'string') && unitObjectID != null && (typeof unitObjectID === 'string')) {
                    let linkedAction = that.hCNewFormViewModel.LinkedActions.find(o => o.ProcedureDoctor.toString() === doctorObjectID.toString() && o.MasterResource.toString() === unitObjectID.toString());
                        if (linkedAction) {
                            if (linkedAction.CurrentStateDefID == PatientExamination.PatientExaminationStates.Examination)
                                detailItem.ExaminationState = "Muayene";
                            else if (linkedAction.CurrentStateDefID == PatientExamination.PatientExaminationStates.ExaminationCompleted)
                                detailItem.ExaminationState = "Muayene Edildi";
                            else if (linkedAction.CurrentStateDefID == PatientExamination.PatientExaminationStates.ProcedureRequested)
                                detailItem.ExaminationState = "Tetkik İstendi";
                            else if (linkedAction.CurrentStateDefID == PatientExamination.PatientExaminationStates.Completed)
                                detailItem.ExaminationState = "Tamamlandı";

                            let hCExaminationComponent = that.hCNewFormViewModel.HCExaminationComponents.find(o => o.ObjectID.toString() === linkedAction["HCExaminationComponent"].toString());

                            if (hCExaminationComponent)
                                detailItem.DisableRatio = hCExaminationComponent.DisabledRatio != null ? hCExaminationComponent.DisabledRatio.Value.toString() : "";

                           
                    }
                }

            }
            let masterResourceObjectID = that.hCNewFormViewModel._HealthCommittee["MasterResource"];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.hCNewFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                 if (masterResource) {
                    that.hCNewFormViewModel._HealthCommittee.MasterResource = masterResource;
                }
            }
        }
        this.AddHelpMenu();
    }

    public avatarProfilPhotoPath(): string {

        if (this._HealthCommittee.MasterAction != null && this._HealthCommittee.MasterAction instanceof PatientAdmission == true) {
            //TODO : NE demografik bilgilerdeki kullanılacak
            /*
                let patientAdmission = <PatientAdmission>this._HealthCommittee.MasterAction;
                if (patientAdmission.Episode.Patient != null) {
                    if (this.isIncludeValue(patientAdmission.Episode.Patient.UniqueRefNo) == true) {
                        return "../../Content/PatientAdmission/" + patientAdmission.Episode.Patient.UniqueRefNo + ".jpg"
                    }
                    else if (patientAdmission.Episode.Patient.Sex != null) {
                        if (patientAdmission.Episode.Patient.Sex.ADI === "ERKEK")
                            return "../../Content/PatientAdmission/avatar_men.png"
                        else
                            return "../../Content/PatientAdmission/avatar_women.png"
                    }
                }
    */
            return "../../Content/PatientAdmission/avatar_unknown.png";
        }
    }
    private async HCRequestReason_SelectedObjectChanged(): Promise<void> {
        //   this._PatientAdmission.ResourcesToBeReferred.Clear();
        if (this.hCNewFormViewModel._HealthCommittee.HospitalsUnits != null)
            this.hCNewFormViewModel._HealthCommittee.HospitalsUnits.Clear();
        if (this._HealthCommittee.HCRequestReason != null) {
            let apiUrlForReasonForExamination: string = '/api/PatientAdmissionService/GetHCRequestReasonDetails?requestReasonObjectID=' + this._HealthCommittee.HCRequestReason.ObjectID;
            let response = <GetHCRequestReasonDetailsResponse>await this.httpService.get(apiUrlForReasonForExamination, GetHCRequestReasonDetailsResponse);
            this.hCNewFormViewModel.HCRequestReasonDetail = response.requestReasonDetail;
            //this.hCNewFormViewModel.HCRequestReasonDetail = <HCRequestReasonDetail>await this.httpService.get(apiUrlForReasonForExamination);
            let List: Array<any> = new Array<any>();
            //if (result.IsSuccess == false)
            //    ServiceLocator.MessageService.showError(result.Message);
            //else {
            //    this.patientAdmissionFormViewModel.HCRequestReasonDetail =  result.Result;
            if (this.hCNewFormViewModel.HCRequestReasonDetail != null && this.hCNewFormViewModel.HCRequestReasonDetail.ReasonForExaminationDefinition != null) {
                this.hCNewFormViewModel._HealthCommittee.HCRequestReason.ReasonForExamination = this.hCNewFormViewModel.HCRequestReasonDetail.ReasonForExaminationDefinition;
                if (this.hCNewFormViewModel.HCRequestReasonDetail.HospitalsUnits != null && this.hCNewFormViewModel.HCRequestReasonDetail.HospitalsUnits.length > 0) {
                    for (let hospitalsUnitsDef of this.hCNewFormViewModel.HCRequestReasonDetail.HospitalsUnits) {
                        let hospitalsUnitsGrid: BaseHealthCommittee_HospitalsUnitsGrid = new BaseHealthCommittee_HospitalsUnitsGrid(this._HealthCommittee.ObjectContext);
                        hospitalsUnitsGrid.Doctor = hospitalsUnitsDef.ProcedureDoctor;
                        hospitalsUnitsGrid.Unit = hospitalsUnitsDef.Policklinic;
                        hospitalsUnitsGrid.Speciality = (hospitalsUnitsDef.Policklinic.ResourceSpecialities != null && hospitalsUnitsDef.Policklinic.ResourceSpecialities.length > 0) ? hospitalsUnitsDef.Policklinic.ResourceSpecialities[0].Speciality : null;
                        //todo bg patientAdmissionResourcesToBeReferred.Speciality = hospitalsUnitsDef.Speciality;

                        List.push(hospitalsUnitsGrid);

                        //this.patientAdmissionFormViewModel._PatientAdmission.ResourcesToBeReferred.push(patientAdmissionResourcesToBeReferred);
                    }
                }
                this.hCNewFormViewModel._HealthCommittee.HospitalsUnits = List;
            }
            //}
        }
    }
    
    public MemberDoctors_CellValueChangedEmitted(data: any) {
        let that = this;
        if (data && data.newData != null && data.newData.MemberDoctor != undefined && data.newData.MemberDoctor.ObjectID != undefined)
        {
            let apiUrl: string = "api/HealthCommitteeService/GetDoctorBrans?ResUserID=" + data.newData.MemberDoctor.ObjectID.toString() ;

            that.httpService.get<SpecialityDefinition>(apiUrl)
                .then(response => {
                    // that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].Price = response;
                    data.oldData["Speciality"] = response as SpecialityDefinition;

                    const _resuser = this.hCNewFormViewModel.DoctorandTechnicianList.find(x => x.ObjectID.toString() == data.newData.MemberDoctor.ObjectID.toString());
                    if (_resuser) {
                         data.oldData.MemberDoctor.DiplomaRegisterNo = _resuser.DiplomaRegisterNo;
                         data.oldData.MemberDoctor.SpecialityRegistryNo = _resuser.SpecialityRegistryNo;
                    }
                })
                .catch(error => {
                    that.messageService.showError(error);

                });
        }
    }

    public MemberDoctors_RowInserted(data: any) {
        let that = this;
        if (data && data.data != null && data.data.MemberDoctor != undefined && data.data.MemberDoctor.ObjectID != undefined) {
            let apiUrl: string = "api/HealthCommitteeService/GetDoctorBrans?ResUserID=" + data.data.MemberDoctor.ObjectID.toString();

            that.httpService.get<any>(apiUrl)
                .then(response => {
                    // that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].Price = response;
                    const memberOfHealthComittee = this.hCNewFormViewModel._HealthCommittee.Members.find(x => x.ObjectID.toString() == data.key.toString());
                    if (memberOfHealthComittee) {
                        memberOfHealthComittee.Speciality =  response;
                    }

                    const _resuser = this.hCNewFormViewModel.DoctorandTechnicianList.find(x => x.ObjectID.toString() == data.data.MemberDoctor.ObjectID.toString());
                    if (_resuser) {
                        memberOfHealthComittee.MemberDoctor.DiplomaRegisterNo = _resuser.DiplomaRegisterNo;
                        memberOfHealthComittee.MemberDoctor.SpecialityRegistryNo = _resuser.SpecialityRegistryNo;
                    }
                })
                .catch(error => {
                    that.messageService.showError(error);

                });
        }
    }

    public MemberDoctors_RowInit(data: any)
    {
        data.data.sortID = this.hCNewFormViewModel._HealthCommittee.Members.length + 1;
    }

    public ExternalDoctors_RowInit(data: any)
    {
        data.data.sortID = this.hCNewFormViewModel._HealthCommittee.ExternalDoctors.length + 1;
    }

    public setMemberspecialityValue(rowData: any, value: any, currentRowData: any) {
        const targetSpecialityDef = this.hCNewFormViewModel.SpecialityDefinitionsList.find(d => d.ObjectID.toString() === value);
        if (targetSpecialityDef) {
            const memberOfHealthComittee = this.hCNewFormViewModel._HealthCommittee.Members.find(x => x.ObjectID.toString() == currentRowData.ObjectID.toString());
            if (memberOfHealthComittee) {
                memberOfHealthComittee.Speciality = targetSpecialityDef;
            }
        }
    }


    public setMemberDoctorValue(rowData: any, value: any, currentRowData: any) {
        let that = this;
        let apiUrl: string = "api/HealthCommitteeService/GetDoctorBrans?ResUserID=" + value;

            that.httpService.get<any>(apiUrl)
                .then(response => {
                    // that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].Price = response;
                    const memberOfHealthComittee = this.hCNewFormViewModel._HealthCommittee.Members.find(x => x.ObjectID.toString() == currentRowData.ObjectID.toString());
                    if (memberOfHealthComittee) {
                        memberOfHealthComittee.Speciality =  response;
                    }
                })
                .catch(error => {
                    that.messageService.showError(error);

                });


    }


    public HospitalsUnits_CellValueChangedEmitted(data: any) {
        let that = this;
        if (data && data.Row && data.Column && data.Column.DataMember == "Doctor")
        {
            let apiUrl: string = "api/HealthCommitteeService/GetDoctorBrans?ResUserID=" + data.Value.ObjectID.toString() ;

            that.httpService.get<SpecialityDefinition>(apiUrl)
                .then(response => {
                    data.Row.TTObject["Speciality"] = response as  SpecialityDefinition ;
                })
                .catch(error => {
                    that.messageService.showError(error);

                });
        }
    }
    async ngOnInit()  {
        let that = this;
        await this.load(HCNewFormViewModel);

    }

    async ngOnDestroy() {
        this.RemoveMenuFromHelpMenu();
    }
    
    public onHCRequestReasonChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.HCRequestReason != event) {
                this._HealthCommittee.HCRequestReason = event;
            }
        }
        this.HCRequestReason_SelectedObjectChanged();
    }

    public onHeightChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.ClinicHeight != event) {
                this._HealthCommittee.ClinicHeight = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.MasterResource != event) {
                this._HealthCommittee.MasterResource = event;
            }
        }
    }

    public onNumberOfProcedureChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.NumberOfProcedure != event) {
                this._HealthCommittee.NumberOfProcedure = event;
            }
        }
    }

    public onReasonForExaminationHCRequestReasonChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null &&
                this._HealthCommittee.HCRequestReason != null && this._HealthCommittee.HCRequestReason.ReasonForExamination != event) {
                this._HealthCommittee.HCRequestReason.ReasonForExamination = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.RequestDate != event) {
                this._HealthCommittee.RequestDate = event;
            }
        }
    }

    public onWeightChanged(event): void {
        if (event != null && event != undefined) {
            if (this._HealthCommittee != null && this._HealthCommittee.ClinicWeight != event) {
                this._HealthCommittee.ClinicWeight = event;
            }
        }
    }

    public onWhoPaysChanged(event): void {
        if (event != null) {
            if (this._HealthCommittee != null && this._HealthCommittee.WhoPays != event) {
                this._HealthCommittee.WhoPays = event;
            }
        }
    }

    public onExternalDoctorRemoving(event)
    {
        if (event.row != null) {

            if (event.row.data != null) {
                if (event.row.data.IsNew != false) {
                    this.externalDoctorsGrid.instance.deleteRow(event.rowIndex);
                }
                else
                event.data.EntityState = EntityStateEnum.Deleted;
                this.externalDoctorsGrid.instance.filter(['EntityState', '<>', 1]);
                this.externalDoctorsGrid.instance.refresh();
            }
        }
    }

    public onMemberDoctorRemoving(event)
    {
        if (event.row != null) {

            if (event.row.data != null) {
                if (event.row.data.IsNew != false) {
                    this.memberDoctorsGrid.instance.deleteRow(event.rowIndex);
                }
                else
                event.data.EntityState = EntityStateEnum.Deleted;
                this.memberDoctorsGrid.instance.filter(['EntityState', '<>', 1]);
                this.memberDoctorsGrid.instance.refresh();
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.WhoPays, "Value", this.__ttObject, "WhoPays");
        redirectProperty(this.NumberOfProcedure, "Text", this.__ttObject, "NumberOfProcedure");
        redirectProperty(this.Weight, "Text", this.__ttObject, "ClinicWeight");
        redirectProperty(this.Height, "Text", this.__ttObject, "ClinicHeight");
    }

    public initFormControls(): void {
    this.tttabcontrolMain = new TTVisual.TTTabControl();
    this.tttabcontrolMain.Name = "tttabcontrolMain";
    this.tttabcontrolMain.TabIndex = 0;

    this.tttabpageHC = new TTVisual.TTTabPage();
    this.tttabpageHC.DisplayIndex = 0;
    this.tttabpageHC.BackColor = "#FFFFFF";
    this.tttabpageHC.TabIndex = 0;
    this.tttabpageHC.Text = i18n("M21178", "Sağlık Kurulu Bilgileri");
    this.tttabpageHC.Name = "tttabpageHC";

    this.Members = new TTVisual.TTGrid();
    this.Members.Name = "Members";
    this.Members.TabIndex = 17491;

    this.MemberDoctorMemberOfHealthCommiittee = new TTVisual.TTListBoxColumn();
    this.MemberDoctorMemberOfHealthCommiittee.ListDefName = "DoctorAndTechnicianList";
    this.MemberDoctorMemberOfHealthCommiittee.DataMember = "MemberDoctor";
    this.MemberDoctorMemberOfHealthCommiittee.DisplayIndex = 0;
    this.MemberDoctorMemberOfHealthCommiittee.HeaderText = "Doktor";
    this.MemberDoctorMemberOfHealthCommiittee.Name = "MemberDoctorMemberOfHealthCommiittee";
    this.MemberDoctorMemberOfHealthCommiittee.Width = 300;

    this.SpecialityMemberOfHealthCommiittee = new TTVisual.TTListBoxColumn();
    this.SpecialityMemberOfHealthCommiittee.ListDefName = "SpecialityListDefinition";
    this.SpecialityMemberOfHealthCommiittee.DataMember = "Speciality";
    this.SpecialityMemberOfHealthCommiittee.DisplayIndex = 1;
    this.SpecialityMemberOfHealthCommiittee.HeaderText = "Branş";
    this.SpecialityMemberOfHealthCommiittee.Name = "SpecialityMemberOfHealthCommiittee";
    this.SpecialityMemberOfHealthCommiittee.Width = 300;

    this.DoctorTescilNumber = new TTVisual.TTTextBoxColumn();
    this.DoctorTescilNumber.DataMember = "MemberDoctor.DiplomaRegisterNo";
    this.DoctorTescilNumber.DisplayIndex = 2;
    this.DoctorTescilNumber.HeaderText = "Dip. Tescil Numarası";
    this.DoctorTescilNumber.Name = "DoctorTescilNumber";
    this.DoctorTescilNumber.Width = 100;

    this.DoctorSpecialityRegNo = new TTVisual.TTTextBoxColumn();
    this.DoctorSpecialityRegNo.DataMember = "MemberDoctor.SpecialityRegistryNo";
    this.DoctorSpecialityRegNo.DisplayIndex = 3;
    this.DoctorSpecialityRegNo.HeaderText = "Uzm. Tes. No:";
    this.DoctorSpecialityRegNo.Name = "DoctorSpecialityRegNo";
    this.DoctorSpecialityRegNo.Width = 100;

	this.ExternalDoctors = new TTVisual.TTGrid();
    this.ExternalDoctors.Name = "ExternalDoctors";
    this.ExternalDoctors.TabIndex = 17490;

    this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTTextBoxColumn();
    this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.DataMember = "ExternalDoctorName";
    this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 0;
    this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Doktor Adı";
    this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.Name = "ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid";
    this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid.Width = 200;

    this.SpecialityBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTListBoxColumn();
    this.SpecialityBaseHealthCommittee_ExtDoctorGrid.ListDefName = "SpecialityListDefinition";
    this.SpecialityBaseHealthCommittee_ExtDoctorGrid.DataMember = "Speciality";
    this.SpecialityBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 1;
    this.SpecialityBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Branş";
    this.SpecialityBaseHealthCommittee_ExtDoctorGrid.Name = "SpecialityBaseHealthCommittee_ExtDoctorGrid";
    this.SpecialityBaseHealthCommittee_ExtDoctorGrid.Width = 200;

    this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTTextBoxColumn();
    this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.DataMember = "ExternalDoctorRegNumber";
    this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 2;
    this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Tescil Numarası";
    this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.Name = "ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid";
    this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid.Width = 200;

    this.ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid = new TTVisual.TTTextBoxColumn();
    this.ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid.DataMember = "ExternalDoctorSpecialityRegNo";
    this.ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid.DisplayIndex = 3;
    this.ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid.HeaderText = "Uzm. Tes. Numarası";
    this.ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid.Name = "ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid";
    this.ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid.Width = 100;

    this.ExternalDoctorInfo = new TTVisual.TTLabel();
    this.ExternalDoctorInfo.Text = "Dış XXXXXX Doktor Bilgileri";
    this.ExternalDoctorInfo.ForeColor = "#000000";
    this.ExternalDoctorInfo.Name = "ExternalDoctorInfo";
    this.ExternalDoctorInfo.TabIndex = 20;

        this.labelNumberOfDocumnets = new TTVisual.TTLabel();
        this.labelNumberOfDocumnets.Text = "Sevk/Evrak No";
        this.labelNumberOfDocumnets.Name = "labelNumberOfDocumnets";
        this.labelNumberOfDocumnets.TabIndex = 17489;

        this.DocumentNumber = new TTVisual.TTTextBox();
        this.DocumentNumber.BackColor = "#F0F0F0";
        this.DocumentNumber.ReadOnly = true;
        this.DocumentNumber.Name = "DocumentNumber";
        this.DocumentNumber.TabIndex = 17488;

        this.labelReasonForExaminationHCRequestReason = new TTVisual.TTLabel();
        this.labelReasonForExaminationHCRequestReason.Text = i18n("M20869", "Rapor Türü");
        this.labelReasonForExaminationHCRequestReason.Name = "labelReasonForExaminationHCRequestReason";
        this.labelReasonForExaminationHCRequestReason.TabIndex = 17487;

        this.ReasonForExaminationHCRequestReason = new TTVisual.TTObjectListBox();
        this.ReasonForExaminationHCRequestReason.ReadOnly = true;
        this.ReasonForExaminationHCRequestReason.ListDefName = "HealthCommitteeExaminationReasonListDefinition";
        this.ReasonForExaminationHCRequestReason.Name = "ReasonForExaminationHCRequestReason";
        this.ReasonForExaminationHCRequestReason.TabIndex = 17486;

        this.labelHCRequestReason = new TTVisual.TTLabel();
        this.labelHCRequestReason.Text = i18n("M16646", "İstek Sebebi");
        this.labelHCRequestReason.Name = "labelHCRequestReason";
        this.labelHCRequestReason.TabIndex = 17485;



        this.HCRequestReason = new TTVisual.TTObjectListBox();
        this.HCRequestReason.ReadOnly = true;
        this.HCRequestReason.ListDefName = "HCRequestReasonListDefinition";
        this.HCRequestReason.Name = "HCRequestReason";
        this.HCRequestReason.TabIndex = 17484;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M19181", "Muayene Edileceği Birimler");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17483;

        this.HospitalsUnits = new TTVisual.TTGrid();
        this.HospitalsUnits.Name = "HospitalsUnits";
        this.HospitalsUnits.TabIndex = 17482;

        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid = new TTVisual.TTListBoxColumn();
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.ListDefName = "SpecialistDoctorListDefinition";
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.DataMember = "Doctor";
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.DisplayIndex = 0;
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.HeaderText = "Doktor";
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.ReadOnly = true;
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.Enabled = false;
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.Name = "DoctorBaseHealthCommittee_HospitalsUnitsGrid";
        this.DoctorBaseHealthCommittee_HospitalsUnitsGrid.Width = '25%';

        this.UnitBaseHealthCommittee_HospitalsUnitsGrid = new TTVisual.TTListBoxColumn();
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.ListDefName = "PoliclinicAndEmergencyListDefinition";
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.DataMember = "Unit";
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.DisplayIndex = 1;
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.HeaderText = "Birim";
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.ReadOnly = true;
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.Enabled = false;
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.Name = "UnitBaseHealthCommittee_HospitalsUnitsGrid";
        this.UnitBaseHealthCommittee_HospitalsUnitsGrid.Width = '25%';

        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid = new TTVisual.TTListBoxColumn();
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.ListDefName = "SpecialityListDefinition";
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.DataMember = "Speciality";
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.DisplayIndex = 2;
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.HeaderText = i18n("M12048", "Branş");
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.ReadOnly = true;
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.Enabled = false;
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.Name = "SpecialityBaseHealthCommittee_HospitalsUnitsGrid";
        this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid.Width = '25%';

        this.ExaminationStateInfo = new TTVisual.TTTextBoxColumn();
        this.ExaminationStateInfo.DataMember = "ExaminationState";
        this.ExaminationStateInfo.DisplayIndex = 3;
        this.ExaminationStateInfo.HeaderText = "Muayene Durumu ";
        this.ExaminationStateInfo.Name = "ExaminationStateInfo";
        this.ExaminationStateInfo.ReadOnly = true;
        this.ExaminationStateInfo.Width = '15%';

        this.DisableRatioInfo = new TTVisual.TTTextBoxColumn();
        this.DisableRatioInfo.DataMember = "DisableRatio";
        this.DisableRatioInfo.DisplayIndex = 3;
        this.DisableRatioInfo.HeaderText = "Engel Oranı";
        this.DisableRatioInfo.Name = "DisableRatio";
        this.DisableRatioInfo.ReadOnly = true;
        this.DisableRatioInfo.Width = '10%';

        this.WhoPays = new TTVisual.TTEnumComboBox();
        this.WhoPays.DataTypeName = "WhoPaysEnum";
        this.WhoPays.Required = true;
        this.WhoPays.BackColor = "#F0F0F0";
        this.WhoPays.Enabled = true;
        this.WhoPays.Name = "WhoPays";
        this.WhoPays.TabIndex = 17481;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M23892", "Ücreti Ödeyecek");
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 17480;

        this.labelReturnDescription = new TTVisual.TTLabel();
        this.labelReturnDescription.Text = i18n("M16046", "İade Açıklamaları");
        this.labelReturnDescription.ForeColor = "#000000";
        this.labelReturnDescription.Name = "labelReturnDescription";
        this.labelReturnDescription.TabIndex = 20;
        this.labelReturnDescription.Visible = false;

        this.ReturnDescriptionGrid = new TTVisual.TTGrid();
        this.ReturnDescriptionGrid.ReadOnly = true;
        this.ReturnDescriptionGrid.Name = "ReturnDescriptionGrid";
        this.ReturnDescriptionGrid.TabIndex = 21;
        this.ReturnDescriptionGrid.Visible = false;

        this.EntryDate = new TTVisual.TTTextBoxColumn();
        this.EntryDate.DisplayIndex = 0;
        this.EntryDate.HeaderText = "Tarih/Saat";
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.Width = 100;

        this.ReturnDescription = new TTVisual.TTTextBoxColumn();
        this.ReturnDescription.DisplayIndex = 1;
        this.ReturnDescription.HeaderText = i18n("M16047", "İade Açıklaması");
        this.ReturnDescription.Name = "ReturnDescription";
        this.ReturnDescription.Width = 400;

        this.LinkedActionState = new TTVisual.TTTextBoxColumn();
        this.LinkedActionState.DisplayIndex = 1;
        this.LinkedActionState.HeaderText = i18n("M16047", "Muayene Durumu");
        this.LinkedActionState.Name = "LinkedActionState";
        this.LinkedActionState.Width = 400;

        this.OwnerUser = new TTVisual.TTTextBoxColumn();
        this.OwnerUser.DisplayIndex = 2;
        this.OwnerUser.HeaderText = i18n("M17894", "Kullanıcı Adı");
        this.OwnerUser.Name = "OwnerUser";
        this.OwnerUser.Width = 200;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M14474", "Fotoğrafı");
        this.ttgroupbox1.BackColor = "#FFFFFF";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 17465;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M21148", " sağ tıklayınız");
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 1;

        this.Height = new TTVisual.TTTextBox();
        this.Height.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Height.Name = "Height";
        this.Height.TabIndex = 5;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M11988", "Boy (cm.)");
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 17454;

        this.Weight = new TTVisual.TTTextBox();
        this.Weight.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Weight.Name = "Weight";
        this.Weight.TabIndex = 4;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M10565", "Ağırlık (kg.)");
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 17453;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;

        this.LabelMasterResource = new TTVisual.TTLabel();
        this.LabelMasterResource.Text = "Birimi";
        this.LabelMasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelMasterResource.ForeColor = "#000000";
        this.LabelMasterResource.Name = "LabelMasterResource";
        this.LabelMasterResource.TabIndex = 17345;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.ListDefName = "ResourceListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 15;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M16650", "İstek Tarihi");
        this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 17463;

        this.labelDocumentDate = new TTVisual.TTLabel();
        this.labelDocumentDate.Text = "Sevk/Evrak Tarihi";
        this.labelDocumentDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDocumentDate.ForeColor = "#000000";
        this.labelDocumentDate.Name = "labelDocumentDate";
        this.labelDocumentDate.TabIndex = 17340;

        this.DocumentDate = new TTVisual.TTDateTimePicker();
        this.DocumentDate.BackColor = "#F0F0F0";
        this.DocumentDate.CustomFormat = "";
        this.DocumentDate.Format = DateTimePickerFormat.Long;
        this.DocumentDate.Enabled = false;
        this.DocumentDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DocumentDate.Name = "DocumentDate";
        this.DocumentDate.TabIndex = 1;

        this.labelNumberOfProcedure = new TTVisual.TTLabel();
        this.labelNumberOfProcedure.Text = i18n("M17048", "Kaçıncı İşlemi");
        this.labelNumberOfProcedure.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelNumberOfProcedure.ForeColor = "#000000";
        this.labelNumberOfProcedure.Name = "labelNumberOfProcedure";
        this.labelNumberOfProcedure.TabIndex = 17457;

        this.NumberOfProcedure = new TTVisual.TTTextBox();
        this.NumberOfProcedure.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.NumberOfProcedure.Name = "NumberOfProcedure";
        this.NumberOfProcedure.TabIndex = 3;

        this.HospitalProtocolNo = new TTVisual.TTTextBox();
        this.HospitalProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.HospitalProtocolNo.Name = "HospitalProtocolNo";
        this.HospitalProtocolNo.TabIndex = 3;

        this.MembersColumns = [this.MemberDoctorMemberOfHealthCommiittee, this.SpecialityMemberOfHealthCommiittee, this.DoctorTescilNumber, this.DoctorSpecialityRegNo];
        this.ExternalDoctorsColumns = [this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid, this.SpecialityBaseHealthCommittee_ExtDoctorGrid, this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid, this.ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid];
        this.HospitalsUnitsColumns = [this.DoctorBaseHealthCommittee_HospitalsUnitsGrid, this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid, this.UnitBaseHealthCommittee_HospitalsUnitsGrid, this.ExaminationStateInfo, this.DisableRatioInfo];
        this.ReturnDescriptionGridColumns = [this.EntryDate, this.ReturnDescription, this.OwnerUser];
        this.tttabcontrolMain.Controls = [this.labelReturnDescription];
        this.labelReturnDescription.Controls = [this.Members, this.ExternalDoctors, this.ExternalDoctorInfo, this.labelNumberOfDocumnets, this.DocumentNumber, this.labelReasonForExaminationHCRequestReason, this.ReasonForExaminationHCRequestReason, this.labelHCRequestReason, this.HCRequestReason, this.ttlabel1, this.HospitalsUnits, this.WhoPays, this.ttlabel10, this.ttlabel2, this.ReturnDescriptionGrid, this.ttgroupbox1, this.Height, this.ttlabel8, this.Weight, this.ttlabel7, this.RequestDate, this.LabelMasterResource, this.MasterResource, this.ttlabel9, this.labelDocumentDate, this.DocumentDate, this.labelNumberOfProcedure, this.NumberOfProcedure];
        this.ttgroupbox1.Controls = [this.ttlabel14];
        this.Controls = [this.tttabcontrolMain, this.labelReturnDescription, this.Members, this.MemberDoctorMemberOfHealthCommiittee, this.SpecialityMemberOfHealthCommiittee, this.DoctorTescilNumber, this.DoctorSpecialityRegNo, this.ExternalDoctors, this.ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid, this.SpecialityBaseHealthCommittee_ExtDoctorGrid, this.ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid, this.ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid, this.ExternalDoctorInfo, this.labelNumberOfDocumnets, this.DocumentNumber, this.labelReasonForExaminationHCRequestReason, this.ReasonForExaminationHCRequestReason, this.labelHCRequestReason, this.HCRequestReason, this.ttlabel1, this.HospitalsUnits, this.DoctorBaseHealthCommittee_HospitalsUnitsGrid, this.UnitBaseHealthCommittee_HospitalsUnitsGrid, this.SpecialityBaseHealthCommittee_HospitalsUnitsGrid, this.ExaminationStateInfo, this.DisableRatioInfo, this.WhoPays, this.ttlabel10, this.ttlabel2, this.ReturnDescriptionGrid, this.EntryDate, this.ReturnDescription, this.OwnerUser, this.ttgroupbox1, this.ttlabel14, this.Height, this.ttlabel8, this.Weight, this.ttlabel7, this.RequestDate, this.LabelMasterResource, this.MasterResource, this.ttlabel9, this.labelDocumentDate, this.DocumentDate, this.labelNumberOfProcedure, this.NumberOfProcedure];

    }


}
