//$F22E844F
import { Component, OnInit, NgZone  } from '@angular/core';
import { DispatchToOtherHospitalFormViewModel, DispatchToOtherHospitalComponentInfoViewModel} from './DispatchToOtherHospitalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CommonService } from "ObjectClassService/CommonService";
import { DispatchToOtherHospital } from 'NebulaClient/Model/AtlasClientModel';
import { DoctorGrid } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { ExternalHospitalDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ReferableHospital } from 'NebulaClient/Model/AtlasClientModel';
import { SevkNedeni } from 'NebulaClient/Model/AtlasClientModel';
import { SevkTedaviTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SevkVasitasi } from 'NebulaClient/Model/AtlasClientModel';
import { Sites } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { ReferableResource } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';


@Component({
    selector: 'DispatchToOtherHospitalForm',
    templateUrl: './DispatchToOtherHospitalForm.html',
    providers: [MessageService]
})
export class DispatchToOtherHospitalForm extends EpisodeActionForm implements OnInit {
    CompanionReason: TTVisual.ITTTextBox;
    CompanionStatus: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    DispatchCity: TTVisual.ITTObjectListBox;
    DispatchedDoctorName: TTVisual.ITTTextBox;
    DispatchedSpeciality: TTVisual.ITTObjectListBox;
    DispatchResultTabPage: TTVisual.ITTTabPage;
    DispatchTabControl: TTVisual.ITTTabControl;
    DispatchTabPage: TTVisual.ITTTabPage;
    EpicrisisDelivered: TTVisual.ITTCheckBox;
    GSSOwnerName: TTVisual.ITTTextBox;
    GSSOwnerUniquerefNo: TTVisual.ITTTextBox;
    IlSinir: TTVisual.ITTEnumComboBox;
    labelCompanionReason: TTVisual.ITTLabel;
    labelCompanionStatus: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelDispatchCity: TTVisual.ITTLabel;
    labelDispatchedDoctor: TTVisual.ITTLabel;
    labelDispatchedSpeciality: TTVisual.ITTLabel;
    labelGSSOwnerName: TTVisual.ITTLabel;
    labelGSSOwnerUniquerefNo: TTVisual.ITTLabel;
    labelIlSinir: TTVisual.ITTLabel;
    labelMedulaSevkNedeni: TTVisual.ITTLabel;
    labelMedulaSevkVasitasi: TTVisual.ITTLabel;
    labelReasonOfDispatch: TTVisual.ITTLabel;
    labelRequestDate: TTVisual.ITTLabel;
    labelRequestedExternalDepartment: TTVisual.ITTLabel;
    labelRequestedExternalHospital: TTVisual.ITTLabel;
    labelRequestedReferableHospital: TTVisual.ITTLabel;
    labelRequestedReferableResource: TTVisual.ITTLabel;
    labelRequestedSite: TTVisual.ITTLabel;
    labelRestingEndDate: TTVisual.ITTLabel;
    labelRestingStartDate: TTVisual.ITTLabel;
    labelSiteCode: TTVisual.ITTLabel;
    lblSevkTedaviTipi: TTVisual.ITTLabel;
    medulaRefakatciDurumu: TTVisual.ITTCheckBox;
    MutatDisiGerekcesi: TTVisual.ITTTextBox;
    NeedSpecialEquipment: TTVisual.ITTCheckBox;
    RaporBaslangicTarihi: TTVisual.ITTDateTimePicker;
    RaporBitisTarihi: TTVisual.ITTDateTimePicker;
    RaporTarihi: TTVisual.ITTDateTimePicker;
    ReasonOfDispatch: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    RequestedExternalDepartment: TTVisual.ITTObjectListBox;
    RequestedExternalHospital: TTVisual.ITTObjectListBox;
    RequestedReferableHospital: TTVisual.ITTObjectListBox;
    RequestedReferableResource: TTVisual.ITTObjectListBox;
    RequestedSite: TTVisual.ITTObjectListBox;
    RestingEndDate: TTVisual.ITTDateTimePicker;
    RestingStartDate: TTVisual.ITTDateTimePicker;
    saglikTesisiAra: TTVisual.ITTButton;
    SevkEdenDoktor: TTVisual.ITTListBoxColumn;
    ttgridSevkEdenDoktorlar: TTVisual.ITTGrid;
    ttgroupboxMutatDisiAracRaporBilgileri: TTVisual.ITTGroupBox;
    ttlabelBaslangicTarihi: TTVisual.ITTLabel;
    ttlabelBitisTarihi: TTVisual.ITTLabel;
    ttlabelMutatDisiGerekcesi: TTVisual.ITTLabel;
    ttlabelRaporTarihi: TTVisual.ITTLabel;
    TTListBoxMedulaSevkNedeni: TTVisual.ITTObjectListBox;
    TTListBoxMedulaSevkVasitasi: TTVisual.ITTObjectListBox;
    TTListBoxSevkTedaviTipi: TTVisual.ITTObjectListBox;
    ttpanelMedulaSevkBilgileri: TTVisual.ITTPanel;
    txtMedulaSiteCode: TTVisual.ITTTextBox;
    public ttgridSevkEdenDoktorlarColumns = [];
    public dispatchToOtherHospitalFormViewModel: DispatchToOtherHospitalFormViewModel = new DispatchToOtherHospitalFormViewModel();
    public get _DispatchToOtherHospital(): DispatchToOtherHospital {
        return this._TTObject as DispatchToOtherHospital;
    }

    public openedByTreatmentDischargeForm = false;
    public openedByFormEditor = false;
    public openedFromInpatientPhysician = false;
    public hideMutatReportDiv = true;

    public setInputParam(value: Object) {
        //_inputParam['openedByFormEditor'] = true;
        //_inputParam['openedFromInpatientPhysician']
        if (value != null) {
            this.openedByFormEditor = value['openedByFormEditor'];
            this.openedFromInpatientPhysician = value['openedFromInpatientPhysician'];
        }
    }

    private DispatchToOtherHospitalForm_DocumentUrl: string = '/api/DispatchToOtherHospitalService/DispatchToOtherHospitalForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService,
        protected modalService: IModalService,
        protected helpMenuService: HelpMenuService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DispatchToOtherHospitalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);

        if(transDef != null)
            this.openDispatchReport();
    }

    public openDispatchReport() {
        let that = this;

        let reportData: DynamicReportParameters = {

            Code: 'SEVKRAPORU',
            ReportParams: { ObjectID: this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "HASTA SEVK FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    // ***** Method declarations start *****

    private async RequestedExternalDepartment_SelectedObjectChanged(): Promise<void> {
        this.SetInternalOrExternalFieldsEnabling(this.RequestedExternalDepartment.DataMember);
        if (this._DispatchToOtherHospital.RequestedExternalDepartment !== null)
            this._DispatchToOtherHospital.DispatchedSpeciality = this._DispatchToOtherHospital.RequestedExternalDepartment;
    }
    private async RequestedExternalHospital_SelectedObjectChanged(): Promise<void> {
        if (this._DispatchToOtherHospital.Episode !== null && this.dispatchToOtherHospitalFormViewModel.isSGK)
        {
            if (this._DispatchToOtherHospital.RequestedExternalHospital != null && this._DispatchToOtherHospital.RequestedExternalHospital.MedulaSiteCode !== null)
                this._DispatchToOtherHospital.MedulaSiteCode = this._DispatchToOtherHospital.RequestedExternalHospital.MedulaSiteCode;
            else this._DispatchToOtherHospital.MedulaSiteCode = null;
        }
    }
    private async RequestedReferableHospital_SelectedObjectChanged(): Promise<void> {
        //this.SetInternalOrExternalFieldsEnabling(this.RequestedReferableHospital.DataMember);
        //let refHospital: ReferableHospital = <ReferableHospital>this.RequestedReferableHospital.SelectedObject;
        //if (this._DispatchToOtherHospital.Episode !== null && (await SubEpisodeService.IsSGKSubEpisode(this._DispatchToOtherHospital.SubEpisode))) {
        //    if (refHospital.ResOtherHospital !== null && refHospital.ResOtherHospital.Site !== null && refHospital.ResOtherHospital.Site.MedulaSiteCode !== null)
        //        this._DispatchToOtherHospital.MedulaSiteCode = refHospital.ResOtherHospital.Site.MedulaSiteCode;
        //    else this._DispatchToOtherHospital.MedulaSiteCode = null;
        //}
    }
    private async RequestedReferableResource_SelectedObjectChanged(): Promise<void> {
        this.SetInternalOrExternalFieldsEnabling(this.RequestedReferableResource.DataMember);
    }
    public async saglikTesisiAra_Click(): Promise<void> {
        // let staf: DispatchToOtherHospital_SaglikTesisiAraForm = new DispatchToOtherHospital_SaglikTesisiAraForm();
        // staf.ShowEdit(this.FindForm(), this._DispatchToOtherHospital);
    }
    private async SetInternalOrExternalFieldsEnabling(dataMember: string): Promise<void> {
        //if (dataMember === this.RequestedReferableHospital.DataMember) {
        //    if (this.RequestedReferableHospital.SelectedObject !== null) {
        //        this.RequestedReferableResource.ReadOnly = false;
        //        this.RequestedExternalHospital.ReadOnly = true;
        //        this.RequestedExternalDepartment.ReadOnly = true;
        //        this.RequestedReferableResource.SelectedObject = null;
        //        this.RequestedExternalHospital.SelectedObject = null;
        //        this.RequestedExternalDepartment.SelectedObject = null;
        //    }
        //    else {
        //        if (this.RequestedReferableResource.SelectedObject === null) {
        //            this.RequestedExternalHospital.ReadOnly = false;
        //            this.RequestedExternalDepartment.ReadOnly = false;
        //        }
        //    }
        //}
        //else if (dataMember === this.RequestedReferableResource.DataMember) {
        //    if (this.RequestedReferableResource.SelectedObject !== null) {
        //        this.RequestedReferableHospital.ReadOnly = false;
        //        this.RequestedExternalHospital.ReadOnly = true;
        //        this.RequestedExternalDepartment.ReadOnly = true;
        //        this.RequestedExternalHospital.SelectedObject = null;
        //        this.RequestedExternalDepartment.SelectedObject = null;
        //    }
        //    else {
        //        if (this.RequestedReferableHospital.SelectedObject === null) {
        //            this.RequestedExternalHospital.ReadOnly = false;
        //            this.RequestedExternalDepartment.ReadOnly = false;
        //        }
        //    }
        //}
        //else if (dataMember === this.RequestedExternalHospital.DataMember) {
        //    if (this.RequestedExternalHospital.SelectedObject !== null) {
        //        this.RequestedReferableHospital.ReadOnly = true;
        //        this.RequestedReferableResource.ReadOnly = true;
        //        this.RequestedExternalDepartment.ReadOnly = false;
        //        this.RequestedReferableHospital.SelectedObject = null;
        //        this.RequestedReferableResource.SelectedObject = null;
        //    }
        //    else {
        //        if (this.RequestedExternalDepartment.SelectedObject === null) {
        //            this.RequestedReferableHospital.ReadOnly = false;
        //            this.RequestedReferableResource.ReadOnly = false;
        //        }
        //    }
        //}
        //else if (dataMember === this.RequestedExternalDepartment.DataMember) {
        //    if (this.RequestedExternalDepartment.SelectedObject !== null) {
        //        this.RequestedReferableHospital.ReadOnly = true;
        //        this.RequestedReferableResource.ReadOnly = true;
        //        this.RequestedExternalHospital.ReadOnly = false;
        //        this.RequestedReferableHospital.SelectedObject = null;
        //        this.RequestedReferableResource.SelectedObject = null;
        //    }
        //    else {
        //        if (this.RequestedExternalHospital.SelectedObject === null) {
        //            this.RequestedReferableHospital.ReadOnly = false;
        //            this.RequestedReferableResource.ReadOnly = false;
        //        }
        //    }
        //}
        //else {
        //    throw new TTException('Tanımsız DataMember.(' + dataMember + '). Lütfen Bilgi İşlemi arayınız.');
        //}
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            //if (transDef.FromStateDefID === DispatchToOtherHospital.DispatchToOtherHospitalStates.Dispatched && transDef.ToStateDefID === DispatchToOtherHospital.DispatchToOtherHospitalStates.SendMedula) {
            //    if (this._DispatchToOtherHospital.Episode !== null && (await SubEpisodeService.IsSGKSubEpisode(this._DispatchToOtherHospital.SubEpisode)) === true) {
            //        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', 'Uyarı', 'Uyarı', 'Medulaya bildirilen sevk ve mutat dışı araç rapor kayıtları iptal edilecektir. Devam etmek istediğinize emin misiniz?') === 'H')
            //            throw new TTException('İşlemden vazgeçildi');
            //    }
            //}
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        //if (this.RequestedReferableHospital.SelectedObject !== null && this.RequestedReferableResource.SelectedObject === null)
        //    throw new Exception((await SystemMessageService.GetMessage(1160)));
        //if (this.RequestedReferableHospital.SelectedObject === null && this.RequestedReferableResource.SelectedObject !== null)
        //    throw new Exception((await SystemMessageService.GetMessage(1161)));
        if (this.RequestedExternalHospital.SelectedObject !== null && this.RequestedExternalDepartment.SelectedObject === null)
            throw new Exception((await SystemMessageService.GetMessage(1162)));
        if (this.RequestedExternalHospital.SelectedObject === null && this.RequestedExternalDepartment.SelectedObject !== null)
            throw new Exception((await SystemMessageService.GetMessage(1163)));
        if (this.RequestedExternalHospital.SelectedObject === null && this.RequestedExternalDepartment.SelectedObject === null)
            throw new Exception((await SystemMessageService.GetMessage(1164)));
        if(this._DispatchToOtherHospital.IlSinir == undefined)            
            throw new Exception("Lütfen 'İl Sınır Bilgisi' ni seçiniz");
        if (transDef !== null && transDef.ToStateDefID === DispatchToOtherHospital.DispatchToOtherHospitalStates.Dispatched && transDef.FromStateDefID === DispatchToOtherHospital.DispatchToOtherHospitalStates.SendMedula) {
            //if (this._DispatchToOtherHospital.Episode !== null && (await SubEpisodeService.IsSGKSubEpisode(this._DispatchToOtherHospital.SubEpisode)) === true) {
            //    try {
            //        this.MedulaESevkBildirSync();
            //    }
            //    catch (e) {
            //        throw new Exception(e.Message);
            //    }

            //}
        }
        if (this._DispatchToOtherHospital.DoctorsGrid !== null && this._DispatchToOtherHospital.DoctorsGrid.length > 0) {
            this._DispatchToOtherHospital.DispatcherDoctor = this._DispatchToOtherHospital.DoctorsGrid[0].ResUser;
        }
    }

    protected async PreScript(): Promise<void> {
        super.PreScript();
        //if (this._DispatchToOtherHospital.CurrentStateDefID === DispatchToOtherHospital.DispatchToOtherHospitalStates.New) {
        //    this._DispatchToOtherHospital.RequesterSite = (await SystemParameterService.GetSite());
        //    if (this._DispatchToOtherHospital.RequesterSite !== null) {
        //        let requesterHospitalList: Array<ResOtherHospital> = (await ResOtherHospitalService.GetBySite(this._DispatchToOtherHospital.ObjectContext, this._DispatchToOtherHospital.RequesterSite.ObjectID));
        //        for (let requesterHospital of requesterHospitalList) {
        //            this._DispatchToOtherHospital.RequesterHospital = requesterHospital;
        //            break;
        //        }
        //    }
        //}
        //if (this.openedFromInpatientPhysician && this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.IsNew) {
        //    this._ViewModel = null;
        //    throw new Exception("yatan hastalara sevk girebilmek için \'kurum dışı sevk\' butonunu kullanabilirsiniz.");
        //}

        let _recTime = await CommonService.RecTime();
        if (this._DispatchToOtherHospital.MutatDisiAracBaslangicTarihi === null)
            this._DispatchToOtherHospital.MutatDisiAracBaslangicTarihi = _recTime;
        if (this._DispatchToOtherHospital.MutatDisiAracBitisTarihi === null)
            this._DispatchToOtherHospital.MutatDisiAracBitisTarihi = _recTime;
        if (this._DispatchToOtherHospital.MutatDisiAracRaporTarihi === null)
            this._DispatchToOtherHospital.MutatDisiAracRaporTarihi = _recTime;
        //   Sevk Eden Doktorlar eklendiğinden kaldırıldı.
        //            if (this.DispatcherDoctor.SelectedObject == null)
        //            {
        //                ResUser currentUser = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
        //                if (currentUser.UserType == UserTypeEnum.Doctor){
        //                    this.DispatcherDoctor.SelectedObject = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
        //                }
        //            }

        if (this._DispatchToOtherHospital.CurrentStateDefID === DispatchToOtherHospital.DispatchToOtherHospitalStates.New) {
            if (this.RequestedReferableHospital.SelectedObject !== null || this.RequestedReferableResource.SelectedObject !== null) {
                this.RequestedExternalHospital.ReadOnly = true;
                this.RequestedExternalDepartment.ReadOnly = true;
            }
            else if (this.RequestedExternalHospital.SelectedObject !== null || this.RequestedExternalDepartment.SelectedObject !== null) {
                this.RequestedReferableHospital.ReadOnly = true;
                this.RequestedReferableResource.ReadOnly = true;
            }
        }
        if (this._DispatchToOtherHospital.Episode !== null && this.dispatchToOtherHospitalFormViewModel.isSGK == false) {
            this.TTListBoxMedulaSevkNedeni.Required = false;
            this.TTListBoxMedulaSevkVasitasi.Required = false;
            this.TTListBoxSevkTedaviTipi.Required = false;
            this.medulaRefakatciDurumu.Required = false;
            // this.ttpanelMedulaSevkBilgileri.ReadOnly = true;
            this.txtMedulaSiteCode.ReadOnly = true;
            //this.TTListBoxMedulaSevkVasitasi.ReadOnly = true;
            //this.TTListBoxSevkTedaviTipi.ReadOnly = true;
            //this.medulaRefakatciDurumu.ReadOnly = true;
            this.RaporTarihi.ReadOnly = true;
            this.RaporBaslangicTarihi.ReadOnly = true;
            this.RaporBitisTarihi.ReadOnly = true;
            this.MutatDisiGerekcesi.ReadOnly = true;
            this.saglikTesisiAra.ReadOnly = true;
            //this.TTListBoxMedulaSevkNedeni.ReadOnly = true;
            this.DropStateButton(DispatchToOtherHospital.DispatchToOtherHospitalStates.SendMedula);
        }
        if (this._DispatchToOtherHospital.Episode !== null && this.dispatchToOtherHospitalFormViewModel.isSGK == true) {
            if (this._DispatchToOtherHospital.CurrentStateDefID !== null && this._DispatchToOtherHospital.CurrentStateDefID === DispatchToOtherHospital.DispatchToOtherHospitalStates.New)
                this.DropStateButton(DispatchToOtherHospital.DispatchToOtherHospitalStates.Dispatched);
            if (this._DispatchToOtherHospital.CurrentStateDefID !== null && this._DispatchToOtherHospital.CurrentStateDefID === DispatchToOtherHospital.DispatchToOtherHospitalStates.SendMedula)
                this.DropStateButton(DispatchToOtherHospital.DispatchToOtherHospitalStates.SendMedula);
        }

        this.RequestedExternalHospital.ListFilterExpression = " THIS.LinkedCity= '1'"; //boş gelsin
        this.CompanionReason.ReadOnly = !this._DispatchToOtherHospital.MedulaRefakatciDurumu;
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DispatchToOtherHospital();
        this.dispatchToOtherHospitalFormViewModel = new DispatchToOtherHospitalFormViewModel();
        this._ViewModel = this.dispatchToOtherHospitalFormViewModel;
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital = this._TTObject as DispatchToOtherHospital;
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.DoctorsGrid = new Array<DoctorGrid>();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.SevkTedaviTipi = new SevkTedaviTipi();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.SevkVasitasi = new SevkVasitasi();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.SevkNedeni = new SevkNedeni();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedExternalDepartment = new SpecialityDefinition();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedExternalHospital = new ExternalHospitalDefinition();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.DispatchedSpeciality = new SpecialityDefinition();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.DispatchCity = new SKRSILKodlari();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedReferableHospital = new ReferableHospital();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedSite = new Sites();
        this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedReferableResource = new ReferableResource();
    }

    protected loadViewModel() {
        let that = this;
        that.dispatchToOtherHospitalFormViewModel = this._ViewModel as DispatchToOtherHospitalFormViewModel;
        that._TTObject = this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital;
        if (this.dispatchToOtherHospitalFormViewModel == null)
            this.dispatchToOtherHospitalFormViewModel = new DispatchToOtherHospitalFormViewModel();
        if (this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital == null)
            this.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital = new DispatchToOtherHospital();
        that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.DoctorsGrid = that.dispatchToOtherHospitalFormViewModel.ttgridSevkEdenDoktorlarGridList;
        for (let detailItem of that.dispatchToOtherHospitalFormViewModel.ttgridSevkEdenDoktorlarGridList) {
            let resUserObjectID = detailItem["ResUser"];
            if (resUserObjectID != null && (typeof resUserObjectID === "string")) {
                let resUser = that.dispatchToOtherHospitalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                 if (resUser) {
                    detailItem.ResUser = resUser;
                }
            }
        }
        let sevkTedaviTipiObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["SevkTedaviTipi"];
        if (sevkTedaviTipiObjectID != null && (typeof sevkTedaviTipiObjectID === "string")) {
            let sevkTedaviTipi = that.dispatchToOtherHospitalFormViewModel.SevkTedaviTipis.find(o => o.ObjectID.toString() === sevkTedaviTipiObjectID.toString());
             if (sevkTedaviTipi) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.SevkTedaviTipi = sevkTedaviTipi;
            }
        }
        let sevkVasitasiObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["SevkVasitasi"];
        if (sevkVasitasiObjectID != null && (typeof sevkVasitasiObjectID === "string")) {
            let sevkVasitasi = that.dispatchToOtherHospitalFormViewModel.SevkVasitasis.find(o => o.ObjectID.toString() === sevkVasitasiObjectID.toString());
             if (sevkVasitasi) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.SevkVasitasi = sevkVasitasi;
            }
        }
        let sevkNedeniObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["SevkNedeni"];
        if (sevkNedeniObjectID != null && (typeof sevkNedeniObjectID === "string")) {
            let sevkNedeni = that.dispatchToOtherHospitalFormViewModel.SevkNedenis.find(o => o.ObjectID.toString() === sevkNedeniObjectID.toString());
             if (sevkNedeni) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.SevkNedeni = sevkNedeni;
            }
        }
        let requestedExternalDepartmentObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["RequestedExternalDepartment"];
        if (requestedExternalDepartmentObjectID != null && (typeof requestedExternalDepartmentObjectID === "string")) {
            let requestedExternalDepartment = that.dispatchToOtherHospitalFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === requestedExternalDepartmentObjectID.toString());
             if (requestedExternalDepartment) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedExternalDepartment = requestedExternalDepartment;
            }
        }
        let requestedExternalHospitalObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["RequestedExternalHospital"];
        if (requestedExternalHospitalObjectID != null && (typeof requestedExternalHospitalObjectID === "string")) {
            let requestedExternalHospital = that.dispatchToOtherHospitalFormViewModel.ExternalHospitalDefinitions.find(o => o.ObjectID.toString() === requestedExternalHospitalObjectID.toString());
             if (requestedExternalHospital) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedExternalHospital = requestedExternalHospital;
            }
        }
        let dispatchedSpecialityObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["DispatchedSpeciality"];
        if (dispatchedSpecialityObjectID != null && (typeof dispatchedSpecialityObjectID === "string")) {
            let dispatchedSpeciality = that.dispatchToOtherHospitalFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === dispatchedSpecialityObjectID.toString());
             if (dispatchedSpeciality) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.DispatchedSpeciality = dispatchedSpeciality;
            }
        }
        let dispatchCityObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["DispatchCity"];
        if (dispatchCityObjectID != null && (typeof dispatchCityObjectID === "string")) {
            let dispatchCity = that.dispatchToOtherHospitalFormViewModel.Citys.find(o => o.ObjectID.toString() === dispatchCityObjectID.toString());
             if (dispatchCity) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.DispatchCity = dispatchCity;
            }
        }
        let requestedReferableHospitalObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["RequestedReferableHospital"];
        if (requestedReferableHospitalObjectID != null && (typeof requestedReferableHospitalObjectID === "string")) {
            let requestedReferableHospital = that.dispatchToOtherHospitalFormViewModel.ReferableHospitals.find(o => o.ObjectID.toString() === requestedReferableHospitalObjectID.toString());
             if (requestedReferableHospital) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedReferableHospital = requestedReferableHospital;
            }
        }
        let requestedSiteObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["RequestedSite"];
        if (requestedSiteObjectID != null && (typeof requestedSiteObjectID === "string")) {
            let requestedSite = that.dispatchToOtherHospitalFormViewModel.Sitess.find(o => o.ObjectID.toString() === requestedSiteObjectID.toString());
             if (requestedSite) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedSite = requestedSite;
            }
        }
        let requestedReferableResourceObjectID = that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital["RequestedReferableResource"];
        if (requestedReferableResourceObjectID != null && (typeof requestedReferableResourceObjectID === "string")) {
            let requestedReferableResource = that.dispatchToOtherHospitalFormViewModel.ReferableResources.find(o => o.ObjectID.toString() === requestedReferableResourceObjectID.toString());
             if (requestedReferableResource) {
                that.dispatchToOtherHospitalFormViewModel._DispatchToOtherHospital.RequestedReferableResource = requestedReferableResource;
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(DispatchToOtherHospitalFormViewModel);
  
    }

    public onCompanionReasonChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.CompanionReason != event) {
                this._DispatchToOtherHospital.CompanionReason = event;
                //this.CompanionReason.ReadOnly = !this.medulaRefakatciDurumu.Checked;
            }
        }
    }

    public onCompanionStatusChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.CompanionStatus != event) {
                this._DispatchToOtherHospital.CompanionStatus = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.Description != event) {
                this._DispatchToOtherHospital.Description = event;
            }
        }
    }

    public onDispatchCityChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.DispatchCity != event) {
                this._DispatchToOtherHospital.DispatchCity = event;
                this._DispatchToOtherHospital.RequestedExternalHospital = null;
                this.RequestedExternalHospital.ListFilterExpression = " THIS.LinkedCity= '" + this._DispatchToOtherHospital.DispatchCity.ObjectID.toString() + "'";
            }
        }
    }

    public onDispatchedDoctorNameChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.DispatchedDoctorName != event) {
                this._DispatchToOtherHospital.DispatchedDoctorName = event;
            }
        }
    }

    public onDispatchedSpecialityChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.DispatchedSpeciality != event) {
                this._DispatchToOtherHospital.DispatchedSpeciality = event;
            }
        }
    }

    public onEpicrisisDeliveredChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.EpicrisisDelivered != event) {
                this._DispatchToOtherHospital.EpicrisisDelivered = event;
            }
        }
    }

    public onGSSOwnerNameChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.GSSOwnerName != event) {
                this._DispatchToOtherHospital.GSSOwnerName = event;
            }
        }
    }

    public onGSSOwnerUniquerefNoChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.GSSOwnerUniquerefNo != event) {
                this._DispatchToOtherHospital.GSSOwnerUniquerefNo = event;
            }
        }
    }

    public onIlSinirChanged(event): void {
        if(this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.IlSinir != event) { 
            this._DispatchToOtherHospital.IlSinir = event;
        }
    }

    public onmedulaRefakatciDurumuChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.MedulaRefakatciDurumu != event) {
                this._DispatchToOtherHospital.MedulaRefakatciDurumu = event;

                this.CompanionReason.ReadOnly = !this._DispatchToOtherHospital.MedulaRefakatciDurumu;
                if (!this._DispatchToOtherHospital.MedulaRefakatciDurumu)
                    this._DispatchToOtherHospital.CompanionReason = "";

            }
        }
    }

    public onMutatDisiGerekcesiChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.MutatDisiGerekcesi != event) {
                this._DispatchToOtherHospital.MutatDisiGerekcesi = event;
            }
        }
    }

    public onNeedSpecialEquipmentChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.NeedSpecialEquipment != event) {
                this._DispatchToOtherHospital.NeedSpecialEquipment = event;
            }
        }
    }

    public onRaporBaslangicTarihiChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.MutatDisiAracBaslangicTarihi != event) {
                this._DispatchToOtherHospital.MutatDisiAracBaslangicTarihi = event;
            }
        }
    }

    public onRaporBitisTarihiChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.MutatDisiAracBitisTarihi != event) {
                this._DispatchToOtherHospital.MutatDisiAracBitisTarihi = event;
            }
        }
    }

    public onRaporTarihiChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.MutatDisiAracRaporTarihi != event) {
                this._DispatchToOtherHospital.MutatDisiAracRaporTarihi = event;
            }
        }
    }

    public onReasonOfDispatchChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.ReasonOfDispatch != event) {
                this._DispatchToOtherHospital.ReasonOfDispatch = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.RequestDate != event) {
                this._DispatchToOtherHospital.RequestDate = event;
            }
        }
    }

    public onRequestedExternalDepartmentChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.RequestedExternalDepartment != event) {
                this._DispatchToOtherHospital.RequestedExternalDepartment = event;
            }
        }
        this.RequestedExternalDepartment_SelectedObjectChanged();
    }

    public onRequestedExternalHospitalChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.RequestedExternalHospital != event) {
                this._DispatchToOtherHospital.RequestedExternalHospital = event;
            }
        }
        this.RequestedExternalHospital_SelectedObjectChanged();
    }

    public onRequestedReferableHospitalChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.RequestedReferableHospital != event) {
                this._DispatchToOtherHospital.RequestedReferableHospital = event;
            }
        }
        this.RequestedReferableHospital_SelectedObjectChanged();
    }

    public onRequestedReferableResourceChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.RequestedReferableResource != event) {
                this._DispatchToOtherHospital.RequestedReferableResource = event;
            }
        }
        this.RequestedReferableResource_SelectedObjectChanged();
    }

    public onRequestedSiteChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.RequestedSite != event) {
                this._DispatchToOtherHospital.RequestedSite = event;
            }
        }
    }

    public onRestingEndDateChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.RestingEndDate != event) {
                this._DispatchToOtherHospital.RestingEndDate = event;
            }
        }
    }

    public onRestingStartDateChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.RestingStartDate != event) {
                this._DispatchToOtherHospital.RestingStartDate = event;
            }
        }
    }

    public onTTListBoxMedulaSevkNedeniChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.SevkNedeni != event) {
                this._DispatchToOtherHospital.SevkNedeni = event;
            }
        }
    }

    public onTTListBoxMedulaSevkVasitasiChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.SevkVasitasi != event) {
                this._DispatchToOtherHospital.SevkVasitasi = event;
            }
        }

        if (this._DispatchToOtherHospital.SevkVasitasi != null && this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu != "1" && this._DispatchToOtherHospital.SevkVasitasi.sevkVasitasiKodu != "12")
            this.hideMutatReportDiv = false;
        else
            this.hideMutatReportDiv = true;
    }

    public onTTListBoxSevkTedaviTipiChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.SevkTedaviTipi != event) {
                this._DispatchToOtherHospital.SevkTedaviTipi = event;
            }
        }
    }

    public ontxtMedulaSiteCodeChanged(event): void {
        if (event != null) {
            if (this._DispatchToOtherHospital != null && this._DispatchToOtherHospital.MedulaSiteCode != event) {
                this._DispatchToOtherHospital.MedulaSiteCode = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.GSSOwnerName, "Text", this.__ttObject, "GSSOwnerName");
        redirectProperty(this.GSSOwnerUniquerefNo, "Text", this.__ttObject, "GSSOwnerUniquerefNo");
        redirectProperty(this.ReasonOfDispatch, "Text", this.__ttObject, "ReasonOfDispatch");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.EpicrisisDelivered, "Value", this.__ttObject, "EpicrisisDelivered");
        redirectProperty(this.NeedSpecialEquipment, "Value", this.__ttObject, "NeedSpecialEquipment");
        redirectProperty(this.IlSinir, "Value", this.__ttObject, "IlSinir");
        redirectProperty(this.CompanionReason, "Text", this.__ttObject, "CompanionReason");
        redirectProperty(this.txtMedulaSiteCode, "Text", this.__ttObject, "MedulaSiteCode");
        redirectProperty(this.medulaRefakatciDurumu, "Value", this.__ttObject, "MedulaRefakatciDurumu");
        redirectProperty(this.RaporTarihi, "Value", this.__ttObject, "MutatDisiAracRaporTarihi");
        redirectProperty(this.MutatDisiGerekcesi, "Text", this.__ttObject, "MutatDisiGerekcesi");
        redirectProperty(this.RaporBaslangicTarihi, "Value", this.__ttObject, "MutatDisiAracBaslangicTarihi");
        redirectProperty(this.RaporBitisTarihi, "Value", this.__ttObject, "MutatDisiAracBitisTarihi");
        redirectProperty(this.RestingStartDate, "Value", this.__ttObject, "RestingStartDate");
        redirectProperty(this.RestingEndDate, "Value", this.__ttObject, "RestingEndDate");
        redirectProperty(this.DispatchedDoctorName, "Text", this.__ttObject, "DispatchedDoctorName");
        redirectProperty(this.CompanionStatus, "Text", this.__ttObject, "CompanionStatus");
    }

    public initFormControls(): void {
        this.DispatchTabControl = new TTVisual.TTTabControl();
        this.DispatchTabControl.Name = "DispatchTabControl";
        this.DispatchTabControl.TabIndex = 4;

        this.DispatchTabPage = new TTVisual.TTTabPage();
        this.DispatchTabPage.DisplayIndex = 0;
        this.DispatchTabPage.TabIndex = 0;
        this.DispatchTabPage.Text = "Sevk Bilgileri";
        this.DispatchTabPage.Name = "DispatchTabPage";

        this.labelIlSinir = new TTVisual.TTLabel();
        this.labelIlSinir.Text = "İl Sınır Bilgisi";
        this.labelIlSinir.Name = "labelIlSinir";
        this.labelIlSinir.TabIndex = 35;
    
        this.IlSinir = new TTVisual.TTEnumComboBox();
        this.IlSinir.DataTypeName = "IlSınırBilgisi";
        this.IlSinir.Name = "IlSinir";
        this.IlSinir.TabIndex = 34;        

        this.NeedSpecialEquipment = new TTVisual.TTCheckBox();
        this.NeedSpecialEquipment.Value = false;
        this.NeedSpecialEquipment.Title = "Özel Bir Ekip yada Donanım İhtiyacı Var mı? ";
        this.NeedSpecialEquipment.Name = "NeedSpecialEquipment";
        this.NeedSpecialEquipment.TabIndex = 33;

        this.EpicrisisDelivered = new TTVisual.TTCheckBox();
        this.EpicrisisDelivered.Value = false;
        this.EpicrisisDelivered.Title = "Hastanın Epikrizi Ambulansa Teslim Edildi mi?";
        this.EpicrisisDelivered.Name = "EpicrisisDelivered";
        this.EpicrisisDelivered.TabIndex = 32;

        this.ttpanelMedulaSevkBilgileri = new TTVisual.TTPanel();
        this.ttpanelMedulaSevkBilgileri.AutoSize = true;
        this.ttpanelMedulaSevkBilgileri.Text = "Medula Sevk Bilgileri";
        this.ttpanelMedulaSevkBilgileri.Name = "ttpanelMedulaSevkBilgileri";
        this.ttpanelMedulaSevkBilgileri.TabIndex = 9;

        this.txtMedulaSiteCode = new TTVisual.TTTextBox();
        this.txtMedulaSiteCode.Name = "txtMedulaSiteCode";
        this.txtMedulaSiteCode.TabIndex = 1;

        this.labelSiteCode = new TTVisual.TTLabel();
        this.labelSiteCode.Text = i18n("M23212", "Tesis Kodu");
        this.labelSiteCode.Name = "labelSiteCode";
        this.labelSiteCode.TabIndex = 53;

        this.ttgroupboxMutatDisiAracRaporBilgileri = new TTVisual.TTGroupBox();
        this.ttgroupboxMutatDisiAracRaporBilgileri.Text = "Mutat Dışı Araç Rapor Bilgileri";
        this.ttgroupboxMutatDisiAracRaporBilgileri.Name = "ttgroupboxMutatDisiAracRaporBilgileri";
        this.ttgroupboxMutatDisiAracRaporBilgileri.TabIndex = 6;

        this.ttlabelMutatDisiGerekcesi = new TTVisual.TTLabel();
        this.ttlabelMutatDisiGerekcesi.Text = i18n("M19317", "Mutat Dışı Gerekçesi");
        this.ttlabelMutatDisiGerekcesi.Name = "ttlabelMutatDisiGerekcesi";
        this.ttlabelMutatDisiGerekcesi.TabIndex = 7;

        this.MutatDisiGerekcesi = new TTVisual.TTTextBox();
        this.MutatDisiGerekcesi.Multiline = true;
        this.MutatDisiGerekcesi.Name = "MutatDisiGerekcesi";
        this.MutatDisiGerekcesi.TabIndex = 3;
        this.MutatDisiGerekcesi.Height = "100px";

        this.ttlabelBitisTarihi = new TTVisual.TTLabel();
        this.ttlabelBitisTarihi.Text = i18n("M11939", "Bitiş Tarihi");
        this.ttlabelBitisTarihi.Name = "ttlabelBitisTarihi";
        this.ttlabelBitisTarihi.TabIndex = 5;

        this.ttlabelBaslangicTarihi = new TTVisual.TTLabel();
        this.ttlabelBaslangicTarihi.Text = i18n("M11637", "Başlangıç Tarihi");
        this.ttlabelBaslangicTarihi.Name = "ttlabelBaslangicTarihi";
        this.ttlabelBaslangicTarihi.TabIndex = 4;

        this.ttlabelRaporTarihi = new TTVisual.TTLabel();
        this.ttlabelRaporTarihi.Text = i18n("M20864", "Rapor Tarihi");
        this.ttlabelRaporTarihi.Name = "ttlabelRaporTarihi";
        this.ttlabelRaporTarihi.TabIndex = 3;

        this.RaporBitisTarihi = new TTVisual.TTDateTimePicker();
        this.RaporBitisTarihi.Format = DateTimePickerFormat.Short;
        this.RaporBitisTarihi.Name = "RaporBitisTarihi";
        this.RaporBitisTarihi.TabIndex = 2;

        this.saglikTesisiAra = new TTVisual.TTButton();
        this.saglikTesisiAra.Text = "Sağlık Tesisi Ara";
        this.saglikTesisiAra.Name = "saglikTesisiAra";
        this.saglikTesisiAra.TabIndex = 4;

        this.RaporBaslangicTarihi = new TTVisual.TTDateTimePicker();
        this.RaporBaslangicTarihi.Format = DateTimePickerFormat.Short;
        this.RaporBaslangicTarihi.Name = "RaporBaslangicTarihi";
        this.RaporBaslangicTarihi.TabIndex = 1;

        this.RaporTarihi = new TTVisual.TTDateTimePicker();
        this.RaporTarihi.Format = DateTimePickerFormat.Short;
        this.RaporTarihi.Name = "RaporTarihi";
        this.RaporTarihi.TabIndex = 0;

        this.labelMedulaSevkNedeni = new TTVisual.TTLabel();
        this.labelMedulaSevkNedeni.Text = i18n("M21722", "Sevk Nedeni");
        this.labelMedulaSevkNedeni.Name = "labelMedulaSevkNedeni";
        this.labelMedulaSevkNedeni.TabIndex = 0;

        this.ttgridSevkEdenDoktorlar = new TTVisual.TTGrid();
        this.ttgridSevkEdenDoktorlar.HideCompletedUnsuccessfullyData = true;
        this.ttgridSevkEdenDoktorlar.Name = "ttgridSevkEdenDoktorlar";
        this.ttgridSevkEdenDoktorlar.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgridSevkEdenDoktorlar.TabIndex = 3;
        this.ttgridSevkEdenDoktorlar.Height = "150px";
        this.ttgridSevkEdenDoktorlar.ShowFilterCombo = true;
        this.ttgridSevkEdenDoktorlar.FilterColumnName = "SevkEdenDoktor";
        this.ttgridSevkEdenDoktorlar.FilterLabel = "Sevk Eden Doktorlar";
        this.ttgridSevkEdenDoktorlar.Filter = { ListDefName: "DoctorListDefinition" };
        this.ttgridSevkEdenDoktorlar.AllowUserToAddRows = false;
        this.ttgridSevkEdenDoktorlar.DeleteButtonWidth = "5%";
        this.ttgridSevkEdenDoktorlar.AllowUserToDeleteRows = true;
        this.ttgridSevkEdenDoktorlar.IsFilterLabelSingleLine = false;

        this.SevkEdenDoktor = new TTVisual.TTListBoxColumn();
        this.SevkEdenDoktor.ListDefName = "DoctorListDefinition";
        this.SevkEdenDoktor.DataMember = "ResUser";
        this.SevkEdenDoktor.DisplayIndex = 0;
        this.SevkEdenDoktor.HeaderText = "Sevk Eden Doktorlar";
        this.SevkEdenDoktor.Name = "SevkEdenDoktor";
        this.SevkEdenDoktor.Width = "85%";

        this.medulaRefakatciDurumu = new TTVisual.TTCheckBox();
        this.medulaRefakatciDurumu.Value = false;
        this.medulaRefakatciDurumu.Required = true;
        this.medulaRefakatciDurumu.Title = i18n("M20996", "Refakatçi Var");
        this.medulaRefakatciDurumu.Name = "medulaRefakatciDurumu";
        this.medulaRefakatciDurumu.TabIndex = 5;

        this.lblSevkTedaviTipi = new TTVisual.TTLabel();
        this.lblSevkTedaviTipi.Text = i18n("M21735", "Sevk Tedavi Tipi");
        this.lblSevkTedaviTipi.Name = "lblSevkTedaviTipi";
        this.lblSevkTedaviTipi.TabIndex = 52;

        this.TTListBoxSevkTedaviTipi = new TTVisual.TTObjectListBox();
        this.TTListBoxSevkTedaviTipi.Required = true;
        this.TTListBoxSevkTedaviTipi.ListDefName = "SevkTedaviTipiListDefinition";
        this.TTListBoxSevkTedaviTipi.Name = "TTListBoxSevkTedaviTipi";
        this.TTListBoxSevkTedaviTipi.TabIndex = 4;

        this.TTListBoxMedulaSevkVasitasi = new TTVisual.TTObjectListBox();
        this.TTListBoxMedulaSevkVasitasi.Required = true;
        this.TTListBoxMedulaSevkVasitasi.ListDefName = "SevkVasitasiListDefinition";
        this.TTListBoxMedulaSevkVasitasi.Name = "TTListBoxMedulaSevkVasitasi";
        this.TTListBoxMedulaSevkVasitasi.TabIndex = 2;
        this.TTListBoxMedulaSevkVasitasi.AutoCompleteDialogHeight = '100px';

        this.labelMedulaSevkVasitasi = new TTVisual.TTLabel();
        this.labelMedulaSevkVasitasi.Text = i18n("M18807", "Medula Sevk Vasıtası");
        this.labelMedulaSevkVasitasi.Name = "labelMedulaSevkVasitasi";
        this.labelMedulaSevkVasitasi.TabIndex = 43;

        this.TTListBoxMedulaSevkNedeni = new TTVisual.TTObjectListBox();
        this.TTListBoxMedulaSevkNedeni.Required = true;
        this.TTListBoxMedulaSevkNedeni.ListDefName = "SevkNedeniListDefinition";
        this.TTListBoxMedulaSevkNedeni.Name = "TTListBoxMedulaSevkNedeni";
        this.TTListBoxMedulaSevkNedeni.TabIndex = 0;

        this.labelRequestedExternalDepartment = new TTVisual.TTLabel();
        this.labelRequestedExternalDepartment.Text = i18n("M21711", "Sevk Edilen Dış XXXXXX Birimi");
        this.labelRequestedExternalDepartment.Name = "labelRequestedExternalDepartment";
        this.labelRequestedExternalDepartment.TabIndex = 21;
        this.labelRequestedExternalDepartment.Visible = false;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 1;

        this.RequestedExternalDepartment = new TTVisual.TTObjectListBox();
        this.RequestedExternalDepartment.ListDefName = "SpecialityListDefinition";
        this.RequestedExternalDepartment.Name = "RequestedExternalDepartment";
        this.RequestedExternalDepartment.TabIndex = 5;
        this.RequestedExternalDepartment.Visible = false;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 7;

        this.labelRequestedExternalHospital = new TTVisual.TTLabel();
        this.labelRequestedExternalHospital.Text = i18n("M21710", "Sevk Edilen Dış XXXXXX");
        this.labelRequestedExternalHospital.Name = "labelRequestedExternalHospital";
        this.labelRequestedExternalHospital.TabIndex = 19;

        this.RequestedExternalHospital = new TTVisual.TTObjectListBox();
        this.RequestedExternalHospital.ListDefName = "ExternalHospitalListDefinition";
        this.RequestedExternalHospital.Name = "RequestedExternalHospital";
        this.RequestedExternalHospital.TabIndex = 4;

        this.labelReasonOfDispatch = new TTVisual.TTLabel();
        this.labelReasonOfDispatch.Text = i18n("M21720", "Sevk Gerekçesi");
        this.labelReasonOfDispatch.Name = "labelReasonOfDispatch";
        this.labelReasonOfDispatch.TabIndex = 19;

        this.CompanionReason = new TTVisual.TTTextBox();
        this.CompanionReason.Multiline = true;
        this.CompanionReason.Name = "CompanionReason";
        this.CompanionReason.TabIndex = 7;
        this.CompanionReason.Height = "75px";
        this.CompanionReason.ReadOnly = true;

        this.labelCompanionReason = new TTVisual.TTLabel();
        this.labelCompanionReason.Text = i18n("M20998", "Refakatçi Gerekçesi");
        this.labelCompanionReason.Name = "labelCompanionReason";
        this.labelCompanionReason.TabIndex = 9;

        this.labelDispatchedSpeciality = new TTVisual.TTLabel();
        this.labelDispatchedSpeciality.Text = i18n("M21705", "Sevk Edildiği Branş");
        this.labelDispatchedSpeciality.Name = "labelDispatchedSpeciality";
        this.labelDispatchedSpeciality.TabIndex = 31;

        this.DispatchedSpeciality = new TTVisual.TTObjectListBox();
        this.DispatchedSpeciality.ListDefName = "SpecialityListDefinition";
        this.DispatchedSpeciality.Name = "DispatchedSpeciality";
        this.DispatchedSpeciality.TabIndex = 6;

        this.labelDispatchCity = new TTVisual.TTLabel();
        this.labelDispatchCity.Text = i18n("M14782", "Gideceği Şehir");
        this.labelDispatchCity.Name = "labelDispatchCity";
        this.labelDispatchCity.TabIndex = 29;

        this.ReasonOfDispatch = new TTVisual.TTTextBox();
        this.ReasonOfDispatch.Required = true;
        this.ReasonOfDispatch.Multiline = true;
        this.ReasonOfDispatch.BackColor = "#FFE3C6";
        this.ReasonOfDispatch.Name = "ReasonOfDispatch";
        this.ReasonOfDispatch.TabIndex = 0;

        this.DispatchCity = new TTVisual.TTObjectListBox();
        this.DispatchCity.ListDefName = "SKRSILKodlariList";
        this.DispatchCity.Name = "DispatchCity";
        this.DispatchCity.TabIndex = 8;
        this.DispatchCity.AutoCompleteDialogHeight = "100";

        this.DispatchResultTabPage = new TTVisual.TTTabPage();
        this.DispatchResultTabPage.DisplayIndex = 1;
        this.DispatchResultTabPage.TabIndex = 1;
        this.DispatchResultTabPage.Text = "Sevk Sonucu";
        this.DispatchResultTabPage.Name = "DispatchResultTabPage";

        this.DispatchedDoctorName = new TTVisual.TTTextBox();
        this.DispatchedDoctorName.BackColor = "#F0F0F0";
        this.DispatchedDoctorName.ReadOnly = true;
        this.DispatchedDoctorName.Name = "DispatchedDoctorName";
        this.DispatchedDoctorName.TabIndex = 35;

        this.labelRestingStartDate = new TTVisual.TTLabel();
        this.labelRestingStartDate.Text = i18n("M21255", "Sağlık Kurum Kuruluşuna Başvuru Tarihi");
        this.labelRestingStartDate.Name = "labelRestingStartDate";
        this.labelRestingStartDate.TabIndex = 23;

        this.labelDispatchedDoctor = new TTVisual.TTLabel();
        this.labelDispatchedDoctor.Text = "Düzenleyen Hekim";
        this.labelDispatchedDoctor.Name = "labelDispatchedDoctor";
        this.labelDispatchedDoctor.TabIndex = 33;

        this.RestingStartDate = new TTVisual.TTDateTimePicker();
        this.RestingStartDate.BackColor = "#F0F0F0";
        this.RestingStartDate.Format = DateTimePickerFormat.Short;
        this.RestingStartDate.Enabled = false;
        this.RestingStartDate.Name = "RestingStartDate";
        this.RestingStartDate.TabIndex = 22;

        this.labelRestingEndDate = new TTVisual.TTLabel();
        this.labelRestingEndDate.Text = i18n("M21256", "Sağlık Kurum Kuruluşundan Ayrılış Tarihi");
        this.labelRestingEndDate.Name = "labelRestingEndDate";
        this.labelRestingEndDate.TabIndex = 21;

        this.labelCompanionStatus = new TTVisual.TTLabel();
        this.labelCompanionStatus.Text = i18n("M20996", "Refakatçi Durumu");
        this.labelCompanionStatus.Name = "labelCompanionStatus";
        this.labelCompanionStatus.TabIndex = 11;

        this.CompanionStatus = new TTVisual.TTTextBox();
        this.CompanionStatus.Multiline = true;
        this.CompanionStatus.BackColor = "#F0F0F0";
        this.CompanionStatus.ReadOnly = true;
        this.CompanionStatus.Name = "CompanionStatus";
        this.CompanionStatus.TabIndex = 10;
        this.CompanionStatus.Height = "150px";

        this.RestingEndDate = new TTVisual.TTDateTimePicker();
        this.RestingEndDate.BackColor = "#F0F0F0";
        this.RestingEndDate.Format = DateTimePickerFormat.Short;
        this.RestingEndDate.Enabled = false;
        this.RestingEndDate.Name = "RestingEndDate";
        this.RestingEndDate.TabIndex = 20;

        this.GSSOwnerUniquerefNo = new TTVisual.TTTextBox();
        this.GSSOwnerUniquerefNo.Name = "GSSOwnerUniquerefNo";
        this.GSSOwnerUniquerefNo.TabIndex = 3;

        this.GSSOwnerName = new TTVisual.TTTextBox();
        this.GSSOwnerName.Name = "GSSOwnerName";
        this.GSSOwnerName.TabIndex = 2;
        this.GSSOwnerName.ReadOnly = true;
        this.GSSOwnerName.Enabled = false;

        this.RequestedReferableHospital = new TTVisual.TTObjectListBox();
        this.RequestedReferableHospital.ListDefName = "ReferableHospitalListDefinition";
        this.RequestedReferableHospital.Name = "RequestedReferableHospital";
        this.RequestedReferableHospital.TabIndex = 2;
        this.RequestedReferableHospital.Visible = false;

        this.labelGSSOwnerUniquerefNo = new TTVisual.TTLabel();
        this.labelGSSOwnerUniquerefNo.Text = i18n("M14699", "Genel Sağlık Sigortalısının TC Kimlik No");
        this.labelGSSOwnerUniquerefNo.Name = "labelGSSOwnerUniquerefNo";
        this.labelGSSOwnerUniquerefNo.TabIndex = 17;

        this.labelGSSOwnerName = new TTVisual.TTLabel();
        this.labelGSSOwnerName.Text = i18n("M14698", "Genel Sağlık Sigortalısının Adı");
        this.labelGSSOwnerName.Name = "labelGSSOwnerName";
        this.labelGSSOwnerName.TabIndex = 15;

        this.labelRequestedReferableHospital = new TTVisual.TTLabel();
        this.labelRequestedReferableHospital.Text = i18n("M21708", "Sevk Edilen XXXXXX XXXXXX");
        this.labelRequestedReferableHospital.Name = "labelRequestedReferableHospital";
        this.labelRequestedReferableHospital.TabIndex = 36;
        this.labelRequestedReferableHospital.Visible = false;

        this.labelRequestedSite = new TTVisual.TTLabel();
        this.labelRequestedSite.Text = i18n("M21713", "Sevk Edilen XXXXXX");
        this.labelRequestedSite.Name = "labelRequestedSite";
        this.labelRequestedSite.TabIndex = 5;
        this.labelRequestedSite.Visible = false;

        this.RequestedSite = new TTVisual.TTObjectListBox();
        this.RequestedSite.ListDefName = "SiteListDefinition";
        this.RequestedSite.Name = "RequestedSite";
        this.RequestedSite.TabIndex = 1;
        this.RequestedSite.Visible = false;

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M21721", "Sevk İstek Tarihi");
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 3;

        this.RequestedReferableResource = new TTVisual.TTObjectListBox();
        this.RequestedReferableResource.LinkedControlName = "RequestedReferableHospital";
        this.RequestedReferableResource.ListDefName = "ReferableResourceListDefinition";
        this.RequestedReferableResource.Name = "RequestedReferableResource";
        this.RequestedReferableResource.TabIndex = 3;
        this.RequestedReferableResource.Visible = false;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.Format = DateTimePickerFormat.Short;
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;

        this.labelRequestedReferableResource = new TTVisual.TTLabel();
        this.labelRequestedReferableResource.Text = i18n("M21709", "Sevk Edilen XXXXXX XXXXXX Birimi");
        this.labelRequestedReferableResource.Name = "labelRequestedReferableResource";
        this.labelRequestedReferableResource.TabIndex = 38;
        this.labelRequestedReferableResource.Visible = false;



        this.ttgridSevkEdenDoktorlarColumns = [this.SevkEdenDoktor];
        this.DispatchTabControl.Controls = [this.DispatchTabPage, this.DispatchResultTabPage];
        this.DispatchTabPage.Controls = [this.labelIlSinir, this.IlSinir,this.NeedSpecialEquipment, this.EpicrisisDelivered, this.ttpanelMedulaSevkBilgileri, this.labelRequestedExternalDepartment, this.Description, this.RequestedExternalDepartment, this.labelDescription, this.labelRequestedExternalHospital, this.RequestedExternalHospital, this.labelReasonOfDispatch, this.CompanionReason, this.labelCompanionReason, this.labelDispatchedSpeciality, this.DispatchedSpeciality, this.labelDispatchCity, this.ReasonOfDispatch, this.DispatchCity];
        this.ttpanelMedulaSevkBilgileri.Controls = [this.txtMedulaSiteCode, this.labelSiteCode, this.ttgroupboxMutatDisiAracRaporBilgileri, this.labelMedulaSevkNedeni, this.ttgridSevkEdenDoktorlar, this.medulaRefakatciDurumu, this.lblSevkTedaviTipi, this.TTListBoxSevkTedaviTipi, this.TTListBoxMedulaSevkVasitasi, this.labelMedulaSevkVasitasi, this.TTListBoxMedulaSevkNedeni];
        this.ttgroupboxMutatDisiAracRaporBilgileri.Controls = [this.ttlabelMutatDisiGerekcesi, this.MutatDisiGerekcesi, this.ttlabelBitisTarihi, this.ttlabelBaslangicTarihi, this.ttlabelRaporTarihi, this.RaporBitisTarihi, this.saglikTesisiAra, this.RaporBaslangicTarihi, this.RaporTarihi];
        this.DispatchResultTabPage.Controls = [this.DispatchedDoctorName, this.labelRestingStartDate, this.labelDispatchedDoctor, this.RestingStartDate, this.labelRestingEndDate, this.labelCompanionStatus, this.CompanionStatus, this.RestingEndDate];
        this.Controls = [this.DispatchTabControl, this.DispatchTabPage,this.labelIlSinir, this.IlSinir, this.NeedSpecialEquipment, this.EpicrisisDelivered, this.ttpanelMedulaSevkBilgileri, this.txtMedulaSiteCode, this.labelSiteCode, this.ttgroupboxMutatDisiAracRaporBilgileri, this.ttlabelMutatDisiGerekcesi, this.MutatDisiGerekcesi, this.ttlabelBitisTarihi, this.ttlabelBaslangicTarihi, this.ttlabelRaporTarihi, this.RaporBitisTarihi, this.saglikTesisiAra, this.RaporBaslangicTarihi, this.RaporTarihi, this.labelMedulaSevkNedeni, this.ttgridSevkEdenDoktorlar, this.SevkEdenDoktor, this.medulaRefakatciDurumu, this.lblSevkTedaviTipi, this.TTListBoxSevkTedaviTipi, this.TTListBoxMedulaSevkVasitasi, this.labelMedulaSevkVasitasi, this.TTListBoxMedulaSevkNedeni, this.labelRequestedExternalDepartment, this.Description, this.RequestedExternalDepartment, this.labelDescription, this.labelRequestedExternalHospital, this.RequestedExternalHospital, this.labelReasonOfDispatch, this.CompanionReason, this.labelCompanionReason, this.labelDispatchedSpeciality, this.DispatchedSpeciality, this.labelDispatchCity, this.ReasonOfDispatch, this.DispatchCity, this.DispatchResultTabPage, this.DispatchedDoctorName, this.labelRestingStartDate, this.labelDispatchedDoctor, this.RestingStartDate, this.labelRestingEndDate, this.labelCompanionStatus, this.CompanionStatus, this.RestingEndDate, this.GSSOwnerUniquerefNo, this.GSSOwnerName, this.RequestedReferableHospital, this.labelGSSOwnerUniquerefNo, this.labelGSSOwnerName, this.labelRequestedReferableHospital, this.labelRequestedSite, this.RequestedSite, this.labelRequestDate, this.RequestedReferableResource, this.RequestDate, this.labelRequestedReferableResource];

    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let manipulation = new DynamicSidebarMenuItem();
        manipulation.key = 'manipulation';
        manipulation.icon = 'ai ai-tibbi-uygulama-istek';
        manipulation.label = 'Tıbbi/Uygulama İstek';
        manipulation.componentInstance = this.helpMenuService;
        manipulation.clickFunction = this.helpMenuService.openManipulationRequest;
        manipulation.parameterFunctionInstance = this;
        manipulation.getParamsFunction = this.getClickFunctionParams;
        manipulation.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', manipulation);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('manipulation');
    }

    //TODO İSMAİL AÇ:begin
    public static getComponentInfoViewModel(episodeActionId :Guid, episodeId: Guid, patientId : Guid, fromWhere: string): DispatchToOtherHospitalComponentInfoViewModel {
        let _inputParam = {};
        _inputParam['openedByFormEditor'] = true;
        _inputParam['openedFromInpatientPhysician'] = fromWhere == "inpatient" ? true : false;

        let componentInfoViewModel = new DispatchToOtherHospitalComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('11e3d6ee-37f5-465d-9df1-db88c4d570b1');
        queryParameters.QueryDefID = new Guid('5d589a91-65f6-4e9d-a454-449a8e026dd5'); //GetDispatchesByPatient
        let parameters = {};
        parameters['PATIENT'] = new GuidParam(patientId);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.dispatchQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'DispatchToOtherHospitalForm';
        componentInfo.ModuleName = 'XXXXXXlerArasiSevkModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/XXXXXXler_Arasi_Sevk_Modulu/XXXXXXlerArasiSevkModule';
        //TODO: ActiveIDsModel içerisindeki bilgiler kontrol edilecek
        componentInfo.InputParam = new DynamicComponentInputParam(_inputParam, new ActiveIDsModel(episodeActionId, episodeId, patientId));
        componentInfoViewModel.dispatchComponentInfo = componentInfo;
        return componentInfoViewModel;
    }

    public static dispatchQueryResultLoaded(e: any) {

        //let gridColumnsHeaders = {};
        //gridColumnsHeaders["COMPANIONNAME"] = 'Refakatçi adı'

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "IL") {
                column.caption = 'Sevk Edilen İl';
            }
            if (column.dataField === "XXXXXX") {
                column.caption = i18n("M21713", "Sevk Edilen XXXXXX");
            }
            if (column.dataField === "SEVKADI") {
                column.caption = i18n("M21722", "Sevk Nedeni");
            }
            if (column.dataField === "SEVKTIPI") {
                column.caption = 'Sevk Tipi';
            }
            if (column.dataField === "SEVKVASITASI") {
                column.caption = i18n("M21739", "Sevk Vasıtası");
            }
            if (column.dataField === "MEDULASEVKTAKIPNO") {
                column.caption = 'Sevk Takip Numarası';
            }

        }
    }
 //TODO İSMAİL AÇ:end
}
