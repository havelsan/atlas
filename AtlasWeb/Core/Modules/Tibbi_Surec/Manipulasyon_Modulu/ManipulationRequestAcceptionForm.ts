//$B2108EAF
import { Component, OnInit, NgZone } from '@angular/core';
import { ManipulationRequestAcceptionFormViewModel } from './ManipulationRequestAcceptionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationReturnReasonsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ManipulationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaReportResult } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { ModalStateService, ModalInfo, IModal, ModalActionResult } from "Fw/Models/ModalInfo";
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: 'ManipulationRequestAcceptionForm',
    templateUrl: './ManipulationRequestAcceptionForm.html',
    providers: [MessageService]
})
export class ManipulationRequestAcceptionForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    ApprovalFormGiven: TTVisual.ITTCheckBox;
    bransKodu: TTVisual.ITTValueListBox;
    btnMeduladanSil: TTVisual.ITTButtonColumn;
    btnMedulayaKaydet: TTVisual.ITTButton;
    Department: TTVisual.ITTListBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    Emergency: TTVisual.ITTCheckBoxColumn;
    GridManipulations: TTVisual.ITTGrid;
    GridReturnReasons: TTVisual.ITTGrid;
    GunuBirlikTakip: TTVisual.ITTCheckBox;
    labelbransKodu: TTVisual.ITTLabel;
    labelProcedureDoctorEpisodeAction: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labeltakipTipi: TTVisual.ITTLabel;
    labeltedaviTipi: TTVisual.ITTLabel;
    lblSorumluDoktor: TTVisual.ITTLabel;
    ManipulationActionDate: TTVisual.ITTDateTimePickerColumn;
    ManipulationTabPage: TTVisual.ITTTabPage;
    MedulaRaporBilgileriTabPage: TTVisual.ITTTabPage;
    MedulaReportResults: TTVisual.ITTGrid;
    MedulaTakipBilgileriTabPage: TTVisual.ITTTabPage;
    PreInformation: TTVisual.ITTRichTextBoxControl;
    ProcedureDoctorEpisodeAction: TTVisual.ITTObjectListBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ProtocolNo: TTVisual.ITTTextBox;
    ReportChasingNoMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ReportNumberMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ReportRowNumberMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ResultCodeMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ResultExplanationMedulaReportResult: TTVisual.ITTTextBoxColumn;
    ReturnReason: TTVisual.ITTTextBoxColumn;
    SendReportDateMedulaReportResult: TTVisual.ITTDateTimePickerColumn;
    ReturnDate: TTVisual.ITTDateTimePickerColumn;
    TabSubaction: TTVisual.ITTTabControl;
    takipTipi: TTVisual.ITTListDefComboBox;
    tedaviTipi: TTVisual.ITTListDefComboBox;

    TTListBoxSorumluDoktor: TTVisual.ITTObjectListBox;
    ManipulationProcedureList: TTVisual.ITTObjectListBox;

    public GridManipulationsColumns = [];
    public GridReturnReasonsColumns = [];
    public MedulaReportResultsColumns = [];

    public manipulationRequestAcceptionFormViewModel: ManipulationRequestAcceptionFormViewModel = new ManipulationRequestAcceptionFormViewModel();
    public get _Manipulation(): Manipulation {
        return this._TTObject as Manipulation;
    }
    private ManipulationRequestAcceptionForm_DocumentUrl: string = '/api/ManipulationService/ManipulationRequestAcceptionForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
        protected ngZone: NgZone,
        protected modalService: IModalService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ManipulationRequestAcceptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async btnMedulayaKaydet_Click(): Promise<void> {

    }
    /*private async GunuBirlikTakip_CheckedChanged(): Promise<void> {
        if (this.GunuBirlikTakip.Value === true) {
            //this._Manipulation.CreateSubEpisode = true;
            this.TabSubaction.ShowTabPage(this.MedulaTakipBilgileriTabPage);
            this.tedaviTipi.Required = true;
            this.takipTipi.Required = true;
            this.bransKodu.Required = true;
        }
        else {
            //this._Manipulation.CreateSubEpisode = false;
            this.TabSubaction.HideTabPage(this.MedulaTakipBilgileriTabPage);
            this.tedaviTipi.Required = false;
            this.takipTipi.Required = false;
            this.bransKodu.Required = false;
        }
    }*/
    private async MedulaReportResults_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //            if (MedulaReportResults.Rows.Count > 0 && MedulaReportResults.CurrentCell != null)
        //            {
        //                if ((((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn != null) && (((ITTGridCell)MedulaReportResults.CurrentCell).OwningColumn.Name == "btnMeduladanSil"))
        //                {
        //                    ITTGridCell currentCell = MedulaReportResults.CurrentCell;
        //                    if (currentCell != null)
        //                    {
        //                        ITTGridRow currentRow = currentCell.OwningRow;
        //                        if (currentRow != null)
        //                        {
        //                            MedulaReportResult currentMedulaReportResult = currentRow.TTObject as MedulaReportResult;
        //                            if (currentMedulaReportResult != null)
        //                            {
        //
        //                                if (!string.IsNullOrEmpty(currentMedulaReportResult.ReportChasingNo))
        //                                {
        //                                    DialogResult dialogResult = MessageBox.Show("Seçili Rapor Meduladan Silinecektir!! .Devam Etmek İstiyor Musunuz ? ", "Onay", MessageBoxButtons.OKCancel);
        //                                    if (dialogResult == DialogResult.OK)
        //                                    {
        //                                        try
        //                                        {
        //                                            RaporIslemleri.raporSorguDVO raporSorguDVO = new RaporIslemleri.raporSorguDVO();
        //TODO : MEDULA20140501
        //                                            raporSorguDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
        //
        //                                            RaporIslemleri.raporOkuDVO _raporOkuDVO = new RaporIslemleri.raporOkuDVO();
        //                                            _raporOkuDVO.no = currentMedulaReportResult.ReportNumber;
        //                                            _raporOkuDVO.raporSiraNo = currentMedulaReportResult.ReportRowNumber.ToString();
        //                                            _raporOkuDVO.raporTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
        //                                            _raporOkuDVO.tarih = currentMedulaReportResult.SendReportDate.Value.ToString("dd.MM.yyyy");
        //                                            _raporOkuDVO.turu = "1";
        //                                            raporSorguDVO.raporBilgisi = _raporOkuDVO;
        //
        //                                            RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.raporBilgisiSilSync(Sites.SiteLocalHost, raporSorguDVO);
        //                                            if (response != null)
        //                                            {
        //                                                if (response.sonucKodu != null)
        //                                                {
        //                                                    if (response.sonucKodu.Equals(0))
        //                                                    {
        //
        //                                                        MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
        //                                                        //medulaReportResult.CurrentStateDefID = MedulaReportResult.States.Canceled;
        //                                                        medulaReportResult.ResultCode = response.sonucKodu.ToString();
        //                                                        medulaReportResult.ResultExplanation = response.sonucAciklamasi;
        //                                                        medulaReportResult.ReportChasingNo = "";
        //                                                        medulaReportResult.ReportNumber = "";
        //                                                        medulaReportResult.ReportRowNumber = null;
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        if (!string.IsNullOrEmpty(response.sonucAciklamasi))
        //                                                        {
        //                                                            MedulaReportResult medulaReportResult = (MedulaReportResult)currentCell.OwningRow.TTObject;
        //                                                            medulaReportResult.ResultCode = response.sonucKodu.ToString();
        //                                                            medulaReportResult.ResultExplanation = response.sonucAciklamasi;
        //                                                            InfoBox.Show("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
        //                                                        }
        //
        //                                                    }
        //                                                }
        //
        //                                            }
        //                                        }
        //                                        catch (Exception ex)
        //                                        {
        //
        //                                        }
        //
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    InfoBox.Show("Medulaya Kayıtdı Yapılmamış Bir Hiperbarik Oksijen Tedavi  Raporunu Meduladan Silemezsiniz!!!");
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        let a = 1;
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.ClientSidePostScript(transDef);

        if (transDef !== null) {
            if (transDef.ToStateDefID.valueOf() != Manipulation.ManipulationStates.TechnicianProcedure.id && transDef.ToStateDefID.valueOf() != Manipulation.ManipulationStates.NursingProcedure.id && transDef.ToStateDefID.valueOf() != Manipulation.ManipulationStates.RequestingDoctorFromAcception.id) {
                if (this.manipulationRequestAcceptionFormViewModel._Manipulation.ProcedureDoctor == null || this.manipulationRequestAcceptionFormViewModel._Manipulation.ProcedureDoctor == undefined) {
                    throw new Exception(i18n("M16937", "İşlemi Yapması Öngörülen Doktor bilgisini seçmediniz."));
                }
            }
        }
        /*if (transDef !== null) { TODO ASLI
            if (transDef.ToStateDef.StateDefID === Manipulation.ManipulationStates.RequestingDoctorFromDoctorProcedure) {
                let frm: StringEntryForm = new StringEntryForm();
                let mrg: ManipulationReturnReasonsGrid = new ManipulationReturnReasonsGrid(this._Manipulation.ObjectContext);
                mrg.ReturnReason = frm.ShowAndGetStringForm('İade Sebebi').toString();
                this._Manipulation.ManipulationReturnReasons.push(mrg);
            }
            if (transDef.ToStateDef.StateDefID === Manipulation.ManipulationStates.NursingProcedure || transDef.ToStateDef.StateDefID === Manipulation.ManipulationStates.DoctorProcedure || transDef.ToStateDef.StateDefID === Manipulation.ManipulationStates.Appointment || transDef.ToStateDef.StateDefID === Manipulation.ManipulationStates.TechnicianProcedure) {
                let askUser: boolean = false;
                for (let manProc of this._Manipulation.ManipulationProcedures) {
                    if (manProc.ProcedureObject !== null && manProc.ProcedureObject.OnamFormuIste !== null && (<SurgeryDefinition>manProc.ProcedureObject).OnamFormuIste === true) {
                        askUser = true;
                    }
                }
                if (askUser) {
                    this._Manipulation.IsPatientApprovalFormGiven = this.GetIfPatientApprovalFormIsGiven(this._Manipulation.IsPatientApprovalFormGiven);
                }
            }
            //TODO Medula!
            //if ((transDef.ToStateDef.StateDefID == Manipulation.States.DoctorProcedure || transDef.ToStateDef.StateDefID == Manipulation.States.TechnicianProcedure ||
            //     transDef.ToStateDef.StateDefID == Manipulation.States.NursingProcedure) && transDef.FromStateDefID == Manipulation.States.RequestAcception)
            //{
            //    // Medula Takip İşlemleri
            //    if (_Manipulation.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(_Manipulation.Episode) == true && this.IsMedulaProvisionNecessaryProcedureExists() == true)
            //    {
            //        if (_Manipulation.IsGunubirlikTakip == true)
            //        {

            //            if (_Manipulation.MedulaProvision == null)
            //            {
            //                MedulaProvision _medulaProvision = new MedulaProvision(_Manipulation.ObjectContext);
            //                _Manipulation.SetMedulaProvisionInitalProperties(_medulaProvision);
            //                _Manipulation.MedulaProvision = _medulaProvision;
            //            }
            //            _Manipulation.GetManipulationMedulaTakip();
            //        }
            //        else
            //        {
            //            string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uyarı", "Günübirlik Takip Al alanı işaretlenmediğinden takip alınmadan işleme devam edilecektir.Devam Etmek İstiyor Musunuz?");
            //            if (result == "V")
            //                throw new TTUtils.TTException("İşlemden vazgeçildi.");
            //            else
            //                _Manipulation.CreateSubEpisode = false;
            //        }
            //    }
            //}
            let a = 1;
        }*/
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.PostScript(transDef);
        if (transDef !== null) {
            //if (transDef.ToStateDefID.valueOf() != Manipulation.ManipulationStates.TechnicianProcedure.id && transDef.ToStateDefID.valueOf() != Manipulation.ManipulationStates.NursingProcedure.id && transDef.ToStateDefID.valueOf() != Manipulation.ManipulationStates.RequestingDoctorFromAcception.id) {
            //    if (this.manipulationRequestAcceptionFormViewModel._Manipulation.ProcedureDoctor == null || this.manipulationRequestAcceptionFormViewModel._Manipulation.ProcedureDoctor == undefined) {
            //      //  throw new Exception(i18n("M16937", "İşlemi Yapması Öngörülen Doktor bilgisini seçmediniz."));
            //    }
            //}

            if (transDef.ToStateDefID.valueOf() == Manipulation.ManipulationStates.RequestingDoctorFromAcception.id) {
                await this.takeReturnReasonFromUser(i18n("M13214", "Doktora İade Sebebi :"));
            }

        }
    }
    async takeReturnReasonFromUser(note: string) {
        let returnReason: string = await InputForm.GetText(note + i18n("M14794", " Giriniz."), "", true, true);
        if (returnReason != null && returnReason != "") {
            let mrg: ManipulationReturnReasonsGrid = new ManipulationReturnReasonsGrid(this._Manipulation.ObjectContext);
            mrg.ReturnReason = note + returnReason;
            this._Manipulation.ManipulationReturnReasons.push(mrg);
        }
    }


    //  State Buton Adı ve Başlık Düzenlemek için

    public stateButtonList: Array<TTObjectStateTransitionDef>;
    public onStateButtonsRendered(stateList: Array<TTObjectStateTransitionDef>) {
        this.stateButtonList = stateList;
        if (this.stateButtonList != null && this.stateButtonList.length > 0) {
            this.ArrangeButtons();
        }
    }
    public ArrangeButtons() {

        let doctorProcedureDroped: boolean = false;
        let technicianProcedureDroped: boolean = false;
        if (this.stateButtonList != null && this.stateButtonList.length > 0) {
            for (let state of this.stateButtonList) {
                if ((!(this.manipulationRequestAcceptionFormViewModel._isDoctor || this.manipulationRequestAcceptionFormViewModel._isTechnician)) || this.manipulationRequestAcceptionFormViewModel._isSuperUser) {
                    if (state.ToStateDefID == Manipulation.ManipulationStates.DoctorProcedure) {
                        state.DisplayText = i18n("M13212", "Doktora Gönder");
                    } else if (state.ToStateDefID == Manipulation.ManipulationStates.TechnicianProcedure) {
                        state.DisplayText = i18n("M23119", "Teknisyene Gönder");
                    }

                }
                else if (this.manipulationRequestAcceptionFormViewModel._isDoctor) {
                    if (!technicianProcedureDroped) {
                        this.DropStateButton(Manipulation.ManipulationStates.TechnicianProcedure);
                        technicianProcedureDroped = true;
                    }
                    if (state.ToStateDefID == Manipulation.ManipulationStates.DoctorProcedure) {
                        state.DisplayText = i18n("M16909", "İşleme Al");
                    }
                } else if (this.manipulationRequestAcceptionFormViewModel._isTechnician) {
                    if (!doctorProcedureDroped) {
                        this.DropStateButton(Manipulation.ManipulationStates.DoctorProcedure);
                        doctorProcedureDroped = true;
                    }
                    if (state.ToStateDefID == Manipulation.ManipulationStates.TechnicianProcedure) {
                        state.DisplayText = i18n("M16909", "İşleme Al");
                    }
                }
            }
        }
    }

    protected async PreScript(): Promise<void> {
        await super.PreScript();
        this.DropStateButton(Manipulation.ManipulationStates.Completed);

        //if (!this.manipulationRequestAcceptionFormViewModel._isDoctor || this.manipulationRequestAcceptionFormViewModel._isTechnician) {
        //    this.DropStateButton(Manipulation.ManipulationStates.RequestingDoctorFromAcception);
        //}

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Manipulation();
        this.manipulationRequestAcceptionFormViewModel = new ManipulationRequestAcceptionFormViewModel();
        this._ViewModel = this.manipulationRequestAcceptionFormViewModel;
        this.manipulationRequestAcceptionFormViewModel._Manipulation = this._TTObject as Manipulation;
        this.manipulationRequestAcceptionFormViewModel._Manipulation.Episode = new Episode();
        this.manipulationRequestAcceptionFormViewModel._Manipulation.ManipulationRequest = new ManipulationRequest();
        this.manipulationRequestAcceptionFormViewModel._Manipulation.ManipulationRequest.ProcedureDoctor = new ResUser();
        this.manipulationRequestAcceptionFormViewModel._Manipulation.ManipulationProcedures = new Array<ManipulationProcedure>();
        this.manipulationRequestAcceptionFormViewModel._Manipulation.MedulaReportResults = new Array<MedulaReportResult>();
        this.manipulationRequestAcceptionFormViewModel._Manipulation.ProcedureDoctor = new ResUser();
        this.manipulationRequestAcceptionFormViewModel._Manipulation.ManipulationReturnReasons = new Array<ManipulationReturnReasonsGrid>();
    }

    protected loadViewModel() {
        let that = this;

        that.manipulationRequestAcceptionFormViewModel = this._ViewModel as ManipulationRequestAcceptionFormViewModel;
        that._TTObject = this.manipulationRequestAcceptionFormViewModel._Manipulation;
        if (this.manipulationRequestAcceptionFormViewModel == null)
            this.manipulationRequestAcceptionFormViewModel = new ManipulationRequestAcceptionFormViewModel();
        if (this.manipulationRequestAcceptionFormViewModel._Manipulation == null)
            this.manipulationRequestAcceptionFormViewModel._Manipulation = new Manipulation();
        let episodeObjectID = that.manipulationRequestAcceptionFormViewModel._Manipulation["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.manipulationRequestAcceptionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.manipulationRequestAcceptionFormViewModel._Manipulation.Episode = episode;
            }
        }
        let manipulationRequestObjectID = that.manipulationRequestAcceptionFormViewModel._Manipulation["ManipulationRequest"];
        if (manipulationRequestObjectID != null && (typeof manipulationRequestObjectID === 'string')) {
            let manipulationRequest = that.manipulationRequestAcceptionFormViewModel.ManipulationRequests.find(o => o.ObjectID.toString() === manipulationRequestObjectID.toString());
             if (manipulationRequest) {
                that.manipulationRequestAcceptionFormViewModel._Manipulation.ManipulationRequest = manipulationRequest;
            }
            if (manipulationRequest != null) {
                let procedureDoctorObjectID = manipulationRequest["ProcedureDoctor"];
                if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                    let procedureDoctor = that.manipulationRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                     if (procedureDoctor) {
                        manipulationRequest.ProcedureDoctor = procedureDoctor;
                    }
                }
            }
        }
        that.manipulationRequestAcceptionFormViewModel._Manipulation.ManipulationProcedures = that.manipulationRequestAcceptionFormViewModel.GridManipulationsGridList;
        for (let detailItem of that.manipulationRequestAcceptionFormViewModel.GridManipulationsGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.manipulationRequestAcceptionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let procedureDepartmentObjectID = detailItem["ProcedureDepartment"];
            if (procedureDepartmentObjectID != null && (typeof procedureDepartmentObjectID === 'string')) {
                let procedureDepartment = that.manipulationRequestAcceptionFormViewModel.ResSections.find(o => o.ObjectID.toString() === procedureDepartmentObjectID.toString());
                 if (procedureDepartment) {
                    detailItem.ProcedureDepartment = procedureDepartment;
                }
            }
        }
        that.manipulationRequestAcceptionFormViewModel._Manipulation.MedulaReportResults = that.manipulationRequestAcceptionFormViewModel.MedulaReportResultsGridList;
        for (let detailItem of that.manipulationRequestAcceptionFormViewModel.MedulaReportResultsGridList) {
        }
        let procedureDoctorObjectID = that.manipulationRequestAcceptionFormViewModel._Manipulation["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.manipulationRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.manipulationRequestAcceptionFormViewModel._Manipulation.ProcedureDoctor = procedureDoctor;
            }
        }
        that.manipulationRequestAcceptionFormViewModel._Manipulation.ManipulationReturnReasons = that.manipulationRequestAcceptionFormViewModel.GridReturnReasonsGridList;
        for (let detailItem of that.manipulationRequestAcceptionFormViewModel.GridReturnReasonsGridList) {
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(ManipulationRequestAcceptionFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ActionDate != event) {
                this._Manipulation.ActionDate = event;
            }
        }
    }

    public onApprovalFormGivenChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.IsPatientApprovalFormGiven != event) {
                this._Manipulation.IsPatientApprovalFormGiven = event;
            }
        }
    }

    public onGunuBirlikTakipChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.IsGunubirlikTakip != event) {
                this._Manipulation.IsGunubirlikTakip = event;
            }
        }
       // this.GunuBirlikTakip_CheckedChanged();
    }

    public onPreInformationChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null &&
                this._Manipulation.ManipulationRequest != null && this._Manipulation.ManipulationRequest.PreInformation != event) {
                this._Manipulation.ManipulationRequest.PreInformation = event;
            }
        }
    }

    public onProcedureDoctorEpisodeActionChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null &&
                this._Manipulation.ManipulationRequest != null && this._Manipulation.ManipulationRequest.ProcedureDoctor != event) {
                this._Manipulation.ManipulationRequest.ProcedureDoctor = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ProtocolNo != event) {
                this._Manipulation.ProtocolNo = event;
            }
        }
    }

    public onTTListBoxSorumluDoktorChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ProcedureDoctor != event) {
                this._Manipulation.ProcedureDoctor = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.PreInformation, "Rtf", this.__ttObject, "ManipulationRequest.PreInformation");
        redirectProperty(this.ApprovalFormGiven, "Value", this.__ttObject, "IsPatientApprovalFormGiven");
        redirectProperty(this.GunuBirlikTakip, "Value", this.__ttObject, "IsGunubirlikTakip");
    }

    public initFormControls(): void {
        this.labelProcedureDoctorEpisodeAction = new TTVisual.TTLabel();
        this.labelProcedureDoctorEpisodeAction.Text = i18n("M16661", "İstek Yapan Doktor");
        this.labelProcedureDoctorEpisodeAction.Name = "labelProcedureDoctorEpisodeAction";
        this.labelProcedureDoctorEpisodeAction.TabIndex = 189;

        this.ProcedureDoctorEpisodeAction = new TTVisual.TTObjectListBox();
        this.ProcedureDoctorEpisodeAction.ListDefName = "DoctorListDefinition";
        this.ProcedureDoctorEpisodeAction.Name = "ProcedureDoctorEpisodeAction";
        this.ProcedureDoctorEpisodeAction.TabIndex = 188;

        this.GunuBirlikTakip = new TTVisual.TTCheckBox();
        this.GunuBirlikTakip.Value = false;
        this.GunuBirlikTakip.Required = true;
        this.GunuBirlikTakip.Text = i18n("M15048", "Günübirlik Takip Al");
        this.GunuBirlikTakip.Name = "GunuBirlikTakip";
        this.GunuBirlikTakip.TabIndex = 3;

        this.PreInformation = new TTVisual.TTRichTextBoxControl();
        this.PreInformation.DisplayText = i18n("M19965", "Ön Bilgi");
        this.PreInformation.TemplateGroupName = "Tıbbi/Cerrahi Uygulama Ön bilgi";
        this.PreInformation.BackColor = "#DCDCDC";
        this.PreInformation.Name = "PreInformation";
        this.PreInformation.TabIndex = 3;

        this.TabSubaction = new TTVisual.TTTabControl();
        this.TabSubaction.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabSubaction.Name = "TabSubaction";
        this.TabSubaction.TabIndex = 6;

        this.ManipulationTabPage = new TTVisual.TTTabPage();
        this.ManipulationTabPage.DisplayIndex = 0;
        this.ManipulationTabPage.BackColor = "#FFFFFF";
        this.ManipulationTabPage.TabIndex = 0;
        this.ManipulationTabPage.Text = "Tıbbi/Cerrahi Uygulama";
        this.ManipulationTabPage.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ManipulationTabPage.Name = "ManipulationTabPage";

        this.GridManipulations = new TTVisual.TTGrid();
        this.GridManipulations.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridManipulations.Name = "GridManipulations";
        this.GridManipulations.TabIndex = 0;

        this.ManipulationActionDate = new TTVisual.TTDateTimePickerColumn();
        this.ManipulationActionDate.Format = DateTimePickerFormat.Custom;
        this.ManipulationActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ManipulationActionDate.DataMember = "ActionDate";
        this.ManipulationActionDate.DisplayIndex = 0;
        this.ManipulationActionDate.HeaderText = "Tarih/Saat";
        this.ManipulationActionDate.Name = "ManipulationActionDate";
        this.ManipulationActionDate.ReadOnly = true;
        this.ManipulationActionDate.Width = 180;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "ManiplationListDefinition";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 1;
        this.ProcedureObject.HeaderText = "Tıbbi/Cerrahi Uygulama";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.Width = 500;

        this.Emergency = new TTVisual.TTCheckBoxColumn();
        this.Emergency.DataMember = "Emergency";
        this.Emergency.DisplayIndex = 2;
        this.Emergency.HeaderText = "Acil";
        this.Emergency.Name = "Emergency";
        this.Emergency.ReadOnly = true;
        this.Emergency.Width = 40;

        this.Department = new TTVisual.TTListBoxColumn();
        this.Department.ListDefName = "ResourceListDefinition";
        this.Department.DataMember = "ProcedureDepartment";
        this.Department.DisplayIndex = 3;
        this.Department.HeaderText = i18n("M23778", "Uygulanacak Birim");
        this.Department.Name = "Department";
        //this.Department.ReadOnly = true;
        this.Department.Width = 500;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 4;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.ReadOnly = true;
        this.Description.Width = 300;

        this.MedulaTakipBilgileriTabPage = new TTVisual.TTTabPage();
        this.MedulaTakipBilgileriTabPage.DisplayIndex = 1;
        this.MedulaTakipBilgileriTabPage.TabIndex = 1;
        this.MedulaTakipBilgileriTabPage.Text = i18n("M18817", "Medula Takip Bilgileri");
        this.MedulaTakipBilgileriTabPage.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MedulaTakipBilgileriTabPage.Name = "MedulaTakipBilgileriTabPage";

        this.labeltedaviTipi = new TTVisual.TTLabel();
        this.labeltedaviTipi.Text = i18n("M23033", "Tedavi Tipi");
        this.labeltedaviTipi.Name = "labeltedaviTipi";
        this.labeltedaviTipi.TabIndex = 21;

        this.tedaviTipi = new TTVisual.TTListDefComboBox();
        this.tedaviTipi.ListDefName = "TedaviTipiListDefinition";
        this.tedaviTipi.Required = true;
        this.tedaviTipi.BackColor = "#FFE3C6";
        this.tedaviTipi.Name = "tedaviTipi";
        this.tedaviTipi.TabIndex = 4;

        this.labeltakipTipi = new TTVisual.TTLabel();
        this.labeltakipTipi.Text = i18n("M22632", "Takibin Tipi");
        this.labeltakipTipi.Name = "labeltakipTipi";
        this.labeltakipTipi.TabIndex = 19;

        this.takipTipi = new TTVisual.TTListDefComboBox();
        this.takipTipi.ListDefName = "TakipTipiListDefinition";
        this.takipTipi.Required = true;
        this.takipTipi.BackColor = "#FFE3C6";
        this.takipTipi.Name = "takipTipi";
        this.takipTipi.TabIndex = 5;

        this.labelbransKodu = new TTVisual.TTLabel();
        this.labelbransKodu.Text = i18n("M12052", "Branş Kodu");
        this.labelbransKodu.Name = "labelbransKodu";
        this.labelbransKodu.TabIndex = 1;

        this.bransKodu = new TTVisual.TTValueListBox();
        this.bransKodu.Required = true;
        this.bransKodu.ListDefName = "SpecialityListDefinition";
        this.bransKodu.Name = "bransKodu";
        this.bransKodu.TabIndex = 3;

        this.MedulaRaporBilgileriTabPage = new TTVisual.TTTabPage();
        this.MedulaRaporBilgileriTabPage.DisplayIndex = 2;
        this.MedulaRaporBilgileriTabPage.TabIndex = 2;
        this.MedulaRaporBilgileriTabPage.Text = i18n("M18790", "Medula Rapor Bilgileri");
        this.MedulaRaporBilgileriTabPage.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MedulaRaporBilgileriTabPage.Name = "MedulaRaporBilgileriTabPage";

        this.btnMedulayaKaydet = new TTVisual.TTButton();
        this.btnMedulayaKaydet.Text = "Raporu  Medulaya Kaydet";
        this.btnMedulayaKaydet.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.btnMedulayaKaydet.Name = "btnMedulayaKaydet";
        this.btnMedulayaKaydet.TabIndex = 5;

        this.MedulaReportResults = new TTVisual.TTGrid();
        this.MedulaReportResults.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MedulaReportResults.Name = "MedulaReportResults";
        this.MedulaReportResults.TabIndex = 0;

        this.ReportChasingNoMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ReportChasingNoMedulaReportResult.DataMember = "ReportChasingNo";
        this.ReportChasingNoMedulaReportResult.DisplayIndex = 0;
        this.ReportChasingNoMedulaReportResult.HeaderText = i18n("M20858", "Rapor Takip Nu.");
        this.ReportChasingNoMedulaReportResult.Name = "ReportChasingNoMedulaReportResult";
        this.ReportChasingNoMedulaReportResult.Width = 117;

        this.ReportNumberMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ReportNumberMedulaReportResult.DataMember = "ReportNumber";
        this.ReportNumberMedulaReportResult.DisplayIndex = 1;
        this.ReportNumberMedulaReportResult.HeaderText = i18n("M20824", "Rapor Numarası");
        this.ReportNumberMedulaReportResult.Name = "ReportNumberMedulaReportResult";
        this.ReportNumberMedulaReportResult.Width = 80;

        this.ReportRowNumberMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ReportRowNumberMedulaReportResult.DataMember = "ReportRowNumber";
        this.ReportRowNumberMedulaReportResult.DisplayIndex = 2;
        this.ReportRowNumberMedulaReportResult.HeaderText = i18n("M20845", "Rapor Sıra Numarası");
        this.ReportRowNumberMedulaReportResult.Name = "ReportRowNumberMedulaReportResult";
        this.ReportRowNumberMedulaReportResult.Width = 80;

        this.ResultCodeMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ResultCodeMedulaReportResult.DataMember = "ResultCode";
        this.ResultCodeMedulaReportResult.DisplayIndex = 3;
        this.ResultCodeMedulaReportResult.HeaderText = i18n("M22075", "Sonuc Kodu");
        this.ResultCodeMedulaReportResult.Name = "ResultCodeMedulaReportResult";
        this.ResultCodeMedulaReportResult.Width = 80;

        this.ResultExplanationMedulaReportResult = new TTVisual.TTTextBoxColumn();
        this.ResultExplanationMedulaReportResult.DataMember = "ResultExplanation";
        this.ResultExplanationMedulaReportResult.DisplayIndex = 4;
        this.ResultExplanationMedulaReportResult.HeaderText = i18n("M22088", "Sonuç Açıklaması");
        this.ResultExplanationMedulaReportResult.Name = "ResultExplanationMedulaReportResult";
        this.ResultExplanationMedulaReportResult.Width = 300;

        this.SendReportDateMedulaReportResult = new TTVisual.TTDateTimePickerColumn();
        this.SendReportDateMedulaReportResult.DataMember = "SendReportDate";
        this.SendReportDateMedulaReportResult.DisplayIndex = 5;
        this.SendReportDateMedulaReportResult.HeaderText = i18n("M20809", "Rapor Gönderim Tarihi");
        this.SendReportDateMedulaReportResult.Name = "SendReportDateMedulaReportResult";
        this.SendReportDateMedulaReportResult.Width = 100;

        this.btnMeduladanSil = new TTVisual.TTButtonColumn();
        this.btnMeduladanSil.DisplayIndex = 6;
        this.btnMeduladanSil.HeaderText = "Medula'dan Raporu Sil";
        this.btnMeduladanSil.Name = "btnMeduladanSil";
        this.btnMeduladanSil.Visible = false;
        this.btnMeduladanSil.Width = 100;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 1;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16886", "İşlem Tarihi");
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 11;

        this.ApprovalFormGiven = new TTVisual.TTCheckBox();
        this.ApprovalFormGiven.Value = false;
        this.ApprovalFormGiven.Title = i18n("M11306", "Aydınlatılmış Onam Formu");
        this.ApprovalFormGiven.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ApprovalFormGiven.Name = "ApprovalFormGiven";
        this.ApprovalFormGiven.TabIndex = 2;

        this.TTListBoxSorumluDoktor = new TTVisual.TTObjectListBox();
        this.TTListBoxSorumluDoktor.ListDefName = "SpecialistDoctorListDefinition";
        this.TTListBoxSorumluDoktor.Name = "TTListBoxSorumluDoktor";
        this.TTListBoxSorumluDoktor.TabIndex = 2;

        this.lblSorumluDoktor = new TTVisual.TTLabel();
        this.lblSorumluDoktor.Text = i18n("M16936", "İşlemi Yapması Öngörülen Doktor");
        this.lblSorumluDoktor.Name = "lblSorumluDoktor";
        this.lblSorumluDoktor.TabIndex = 187;

        this.GridReturnReasons = new TTVisual.TTGrid();
        this.GridReturnReasons.Name = "GridReturnReasons";
        this.GridReturnReasons.TabIndex = 5;

        this.ReturnDate = new TTVisual.TTDateTimePickerColumn();
        this.ReturnDate.DataMember = "ReturnDate";
        this.ReturnDate.DisplayIndex = 0;
        this.ReturnDate.HeaderText = i18n("M16079", "İade Zamanı");
        this.ReturnDate.Name = "ReturnDate";
        this.ReturnDate.ReadOnly = true;
        this.ReturnDate.Width = 180;

        this.ReturnReason = new TTVisual.TTTextBoxColumn();
        this.ReturnReason.DataMember = "ReturnReason";
        this.ReturnReason.DisplayIndex = 1;
        this.ReturnReason.HeaderText = i18n("M16071", "İade Sebebi");
        this.ReturnReason.Name = "ReturnReason";
        this.ReturnReason.ReadOnly = true;
        this.ReturnReason.Width = 1035;

        this.ManipulationProcedureList = new TTVisual.TTObjectListBox();
        this.ManipulationProcedureList.ListDefName = "ManiplationListDefinition";
        this.ManipulationProcedureList.Name = "ManipulationProcedureList";
        this.ManipulationProcedureList.AutoCompleteDialogHeight = "200px";

        this.GridManipulationsColumns = [this.ManipulationActionDate, this.ProcedureObject, this.Emergency, this.Department];
        this.MedulaReportResultsColumns = [this.ReportChasingNoMedulaReportResult, this.ReportNumberMedulaReportResult, this.ReportRowNumberMedulaReportResult, this.ResultCodeMedulaReportResult, this.ResultExplanationMedulaReportResult, this.SendReportDateMedulaReportResult, this.btnMeduladanSil];
        this.GridReturnReasonsColumns = [this.ReturnDate, this.ReturnReason];
        this.TabSubaction.Controls = [this.ManipulationTabPage, this.MedulaTakipBilgileriTabPage, this.MedulaRaporBilgileriTabPage];
        this.ManipulationTabPage.Controls = [this.GridManipulations];
        this.MedulaTakipBilgileriTabPage.Controls = [this.labeltedaviTipi, this.tedaviTipi, this.labeltakipTipi, this.takipTipi, this.labelbransKodu, this.bransKodu];
        this.MedulaRaporBilgileriTabPage.Controls = [this.btnMedulayaKaydet, this.MedulaReportResults];
        this.Controls = [this.labelProcedureDoctorEpisodeAction, this.ProcedureDoctorEpisodeAction, this.GunuBirlikTakip, this.PreInformation, this.TabSubaction, this.ManipulationTabPage, this.GridManipulations, this.ManipulationActionDate, this.ProcedureObject, this.Emergency, this.Department, this.Description, this.MedulaTakipBilgileriTabPage, this.labeltedaviTipi, this.tedaviTipi, this.labeltakipTipi, this.takipTipi, this.labelbransKodu, this.bransKodu, this.MedulaRaporBilgileriTabPage, this.btnMedulayaKaydet, this.MedulaReportResults, this.ReportChasingNoMedulaReportResult, this.ReportNumberMedulaReportResult, this.ReportRowNumberMedulaReportResult, this.ResultCodeMedulaReportResult, this.ResultExplanationMedulaReportResult, this.SendReportDateMedulaReportResult, this.btnMeduladanSil, this.ProtocolNo, this.labelProtocolNo, this.ActionDate, this.labelProcessTime, this.ApprovalFormGiven, this.TTListBoxSorumluDoktor, this.lblSorumluDoktor, this.GridReturnReasons, this.ReturnDate, this.ReturnReason];

    }

    manipulationSelected(data: any) {
        if (data != null) {
            let manipulationProcedure: ManipulationProcedure = new ManipulationProcedure();
            manipulationProcedure.ActionDate = new Date();
            manipulationProcedure.ProcedureObject = data;
            manipulationProcedure.Emergency = false;

            manipulationProcedure.Description = "";

            this.manipulationRequestAcceptionFormViewModel.GridManipulationsGridList.unshift(manipulationProcedure);
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);

        if (transDef != null && transDef.ToStateDefID.valueOf()  == Manipulation.ManipulationStates.Appointment.valueOf() ) {
            this.openAppointmentReport();
        }
        
    }

    openAppointmentReport() {
        let reportData: DynamicReportParameters = {

            Code: 'MANIPULASYONRANDEVURAPORU',
            ReportParams: { ManipulationObjectID: this.manipulationRequestAcceptionFormViewModel._Manipulation.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "RANDEVU BİLGİ FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

}
