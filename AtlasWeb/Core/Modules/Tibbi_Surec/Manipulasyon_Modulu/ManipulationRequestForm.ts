//$6F0F9060

//$9C0AF240
import { Component, OnInit, NgZone } from '@angular/core';
import { ManipulationRequestFormViewModel } from './ManipulationRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { ManipulationProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';


@Component({
    selector: 'ManipulationRequestForm',
    templateUrl: './ManipulationRequestForm.html',
    providers: [MessageService]
})
export class ManipulationRequestForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    ApprovalFormGiven: TTVisual.ITTCheckBox;
    chkDisXXXXXXRaporu: TTVisual.ITTCheckBox;
    cmdHistory: TTVisual.ITTButton;
    Department: TTVisual.ITTListBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    Emergency: TTVisual.ITTCheckBoxColumn;

    GridManipulationProcedures: TTVisual.ITTGrid;
    labelMedulaRaporTakipNo: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    lblRaporBilgileri: TTVisual.ITTLabel;
    Manipulation: TTVisual.ITTTabPage;
    ManipulationActionDate: TTVisual.ITTDateTimePickerColumn;
    ManipulationGrid: TTVisual.ITTGrid;
    MedulaRaporBilgileri: TTVisual.ITTTextBox;
    MedulaRaporTakipNo: TTVisual.ITTTextBox;
    OldDepartment: TTVisual.ITTListBoxColumn;
    OldDescription: TTVisual.ITTTextBoxColumn;
    OldEmergency: TTVisual.ITTCheckBoxColumn;
    OldManipulationActionDate: TTVisual.ITTDateTimePickerColumn;
    OldManipulationDoctor: TTVisual.ITTListBoxColumn;
    OldProcedureObject: TTVisual.ITTListBoxColumn;
    PreInformation: TTVisual.ITTRichTextBoxControl;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    TabSubaction: TTVisual.ITTTabControl;
    ManipulationProcedureList: TTVisual.ITTObjectListBox;

    public GridManipulationProceduresColumns = [];
    public ManipulationGridColumns = [];
    public manipulationRequestFormViewModel: ManipulationRequestFormViewModel = new ManipulationRequestFormViewModel();
    public get _ManipulationRequest(): ManipulationRequest {
        return this._TTObject as ManipulationRequest;
    }
    private ManipulationRequestForm_DocumentUrl: string = '/api/ManipulationRequestService/ManipulationRequestForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ManipulationRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    // ***** Method declarations start *****

    //TODO ASLI - Medula kısımları ne olacak? Neden requestin butckoduna son eklenen işlemin kodu set ediliyor?
    /* private async GridManipulationProcedures_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
         let enteredRow: TTVisual.ITTGridRow = this.GridManipulationProcedures.Rows[rowIndex];
         if (enteredRow !== null) {
             let manipulationProcedure: ManipulationProcedure = enteredRow.TTObject as ManipulationProcedure;
             if (manipulationProcedure !== null && manipulationProcedure.ProcedureObject !== null && manipulationProcedure.ProcedureObject.Code !== null) {
                 if (((<SurgeryDefinition>manipulationProcedure.ProcedureObject).InVitroFertilizationProcess !== undefined)) {
                     //labelReportStartDate.Visible=true;
                     //ReportStartDate.Visible=true;
                     //labelReportEndDate.Visible=true;
                     //ReportEndDate.Visible=true;
                     //lblTupBebekTuru.Visible=true;
                     //cmbTupBebekTuru.Visible=true;
                     this.chkDisXXXXXXRaporu.Visible = true;
                     this._ManipulationRequest.ButKodu = manipulationProcedure.ProcedureObject.Code;
                 }
             }
         }
         else {
             //labelReportStartDate.Visible=false;
             //ReportStartDate.Visible=false;
             //labelReportEndDate.Visible=false;
             //ReportEndDate.Visible=false;
             //lblTupBebekTuru.Visible=false;
             //cmbTupBebekTuru.Visible=false;
             this.chkDisXXXXXXRaporu.Visible = false;
             this.labelMedulaRaporTakipNo.Visible = false;
             this.MedulaRaporTakipNo.Visible = false;
             this.MedulaRaporTakipNo.Text = '';
         }
     }
     */

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        this.printReport();
        /* TODO ASLI - medula?
        if (transDef !== null) {
            // if(!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
            //                {
            //                    TTObjectContext context = new TTObjectContext(false);
            //                    MedulaReportResult medulaReportResult = new MedulaReportResult(context);
            //                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
            //                    medulaReportResult.ReportNumber =  "";
            //                    medulaReportResult.ReportRowNumber = 0;
            //                    medulaReportResult.ReportChasingNo = MedulaRaporTakipNo.Text;
            //                    medulaReportResult.SendReportDate = DateTime.Now;
            //                    medulaReportResult.ResultCode="0";
            //                    medulaReportResult.ResultExplanation = "Rapor Takip Numaras? D?? XXXXXX Taraf?ndan Verilmi?tir!!!";
            //                    medulaReportResult.Manipulation = this._ManipulationRequest.Manipulations[0];
            //                    context.Save();

            // if(this._ManipulationRequest.ButKodu!=null)
            //  {
            //TODO Medula!
            //if (this._ManipulationRequest.SubEpisode != null && this._ManipulationRequest.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(this._ManipulationRequest.SubEpisode.SGKSEP.MedulaTakipNo))
            //{
            //    try
            //    {
            //        if (!string.IsNullOrEmpty(MedulaRaporTakipNo.Text))
            //        {
            //            RaporIslemleri.raporOkuTCKimlikNodanDVO _raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
            //            //TODO : MEDULA20140501
            //            _raporOkuTCKimlikNodanDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            //            _raporOkuTCKimlikNodanDVO.raporTuru = "1";
            //            _raporOkuTCKimlikNodanDVO.tckimlikNo = this._ManipulationRequest.Episode.Patient.UniqueRefNo.Value.ToString();
            //            RaporIslemleri.raporCevapTCKimlikNodanDVO response = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(Sites.SiteLocalHost, _raporOkuTCKimlikNodanDVO);
            //            if (response != null)
            //            {
            //                    if (response.sonucKodu.Equals(0))
            //                    {
            //                        if(response.raporlar!=null && response.raporlar.Length>0)
            //                        {
            //                            foreach (RaporIslemleri.raporCevapDVO raporCevapDVO in response.raporlar)
            //                            {
            //                                if (raporCevapDVO.tedaviRapor != null && raporCevapDVO.raporTuru == "1" && raporCevapDVO.tedaviRapor.tedaviRaporTuru == 4 )
            //                                {
            //                                            if (raporCevapDVO.raporTakipNo.ToString() == MedulaRaporTakipNo.Text)
            //                                            {

            //                                                TTObjectContext context = new TTObjectContext(false);
            //                                                MedulaReportResult medulaReportResult = new MedulaReportResult(context);
            //                                                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
            //                                                medulaReportResult.ReportNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.no.ToString();
            //                                                medulaReportResult.ReportRowNumber = raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
            //                                                medulaReportResult.ReportChasingNo =  raporCevapDVO.raporTakipNo.ToString();
            //                                                medulaReportResult.SendReportDate = Convert.ToDateTime(raporCevapDVO.tedaviRapor.raporDVO.raporBilgisi.tarih);
            //                                                medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                                medulaReportResult.Manipulation = this._ManipulationRequest.Manipulations[0];
            //                                                context.Save();
            //                                            }
            //                                }
            //                            }
            //                        }
            //                    }
            //            }
            //        }
            //    }
            //    catch (Exception)
            //   {
            //           throw;
            //   }
            //}
            let a = 1;

        }*/
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);

        if (this.manipulationRequestFormViewModel._ManipulationRequest.ProcedureDoctor == null || this.manipulationRequestFormViewModel._ManipulationRequest.ProcedureDoctor == undefined) {
            throw new Exception(i18n("M16662", "İstek Yapan Doktor Bilgisini Seçiniz."));
        }

        if (this.manipulationRequestFormViewModel.GridManipulationProceduresGridList.length == 0) {
            throw new Exception("Tıbbi/Cerrahi Uygulama Bilgisini Seçiniz.");
        }

        for (let i = 0; i < this.manipulationRequestFormViewModel.GridManipulationProceduresGridList.length; i++) {
            if (this.manipulationRequestFormViewModel.GridManipulationProceduresGridList[i].ProcedureDepartment == null || this.manipulationRequestFormViewModel.GridManipulationProceduresGridList[i].ProcedureDepartment == undefined) {
                throw new Exception(i18n("M23779", "Uygulanacak Birim Bilgisini Seçiniz."));

            }
        }



    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        //TODO ASLI
        //this.SetProcedureDoctorAsCurrentResource();
        //this.SetProcedureDoctorListFilter();
    }
    //TODO ASLI
    /* protected async SetProcedureDoctorListFilter(): Promise<void> {
         if (((await SystemParameterService.GetParameterValue('MANIPULATIONREQUESTDOCTORFILTER', 'FALSE')) === 'TRUE')) {
             let context: TTObjectContext = new TTObjectContext(true);
             let filterString: string = 'OBJECTID IN (''';
             let userList: Array<any> = ResUser.GetResUserByUserTypeAndResource(context, UserTypeEnum.Doctor, this._EpisodeAction.MasterResource.ObjectID);
             for (let user of userList) {
                 filterString += ' ,'' + user.ObjectID.toString()  + ''';
             }
             filterString += ')';
             (<TTVisual.ITTObjectListBox>this.ProcedureDoctor).ListFilterExpression = filterString;
         }
     }*/

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ManipulationRequest();
        this.manipulationRequestFormViewModel = new ManipulationRequestFormViewModel();
        this._ViewModel = this.manipulationRequestFormViewModel;
        this.manipulationRequestFormViewModel._ManipulationRequest = this._TTObject as ManipulationRequest;
        this.manipulationRequestFormViewModel._ManipulationRequest.Episode = new Episode();
        this.manipulationRequestFormViewModel._ManipulationRequest.ProcedureDoctor = new ResUser();
        this.manipulationRequestFormViewModel._ManipulationRequest.ManipulationProcedures = new Array<ManipulationProcedure>();

    }

    protected loadViewModel() {
        let that = this;

        that.manipulationRequestFormViewModel = this._ViewModel as ManipulationRequestFormViewModel;
        that._TTObject = this.manipulationRequestFormViewModel._ManipulationRequest;
        if (this.manipulationRequestFormViewModel == null)
            this.manipulationRequestFormViewModel = new ManipulationRequestFormViewModel();
        if (this.manipulationRequestFormViewModel._ManipulationRequest == null)
            this.manipulationRequestFormViewModel._ManipulationRequest = new ManipulationRequest();
        let episodeObjectID = that.manipulationRequestFormViewModel._ManipulationRequest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.manipulationRequestFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.manipulationRequestFormViewModel._ManipulationRequest.Episode = episode;
            }
        }
        let procedureDoctorObjectID = that.manipulationRequestFormViewModel._ManipulationRequest["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.manipulationRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.manipulationRequestFormViewModel._ManipulationRequest.ProcedureDoctor = procedureDoctor;
            }
        }
        that.manipulationRequestFormViewModel._ManipulationRequest.ManipulationProcedures = that.manipulationRequestFormViewModel.GridManipulationProceduresGridList;
        for (let detailItem of that.manipulationRequestFormViewModel.GridManipulationProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.manipulationRequestFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let procedureDepartmentObjectID = detailItem["ProcedureDepartment"];
            if (procedureDepartmentObjectID != null && (typeof procedureDepartmentObjectID === 'string')) {
                let procedureDepartment = that.manipulationRequestFormViewModel.ResSections.find(o => o.ObjectID.toString() === procedureDepartmentObjectID.toString());
                if (procedureDepartment) {
                    detailItem.ProcedureDepartment = procedureDepartment;
                }
            }
        }
        this.setActionIdForDemografic();
    }


    async ngOnInit() {
        let that = this;
        await this.load(ManipulationRequestFormViewModel);

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._ManipulationRequest != null && this._ManipulationRequest.ActionDate != event) {
                this._ManipulationRequest.ActionDate = event;
            }
        }
    }

    public onApprovalFormGivenChanged(event): void {
        if (event != null) {
            if (this._ManipulationRequest != null && this._ManipulationRequest.IsPatientApprovalFormGiven != event) {
                this._ManipulationRequest.IsPatientApprovalFormGiven = event;
            }
        }
    }

    public onMedulaRaporTakipNoChanged(event): void {
        if (event != null) {
            if (this._ManipulationRequest != null && this._ManipulationRequest.MedulaRaporTakipNo != event) {
                this._ManipulationRequest.MedulaRaporTakipNo = event;
            }
        }
    }

    public onPreInformationChanged(event): void {
        if (event != null) {
            if (this._ManipulationRequest != null && this._ManipulationRequest.PreInformation != event) {
                this._ManipulationRequest.PreInformation = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._ManipulationRequest != null && this._ManipulationRequest.ProcedureDoctor != event) {
                this._ManipulationRequest.ProcedureDoctor = event;
            }
        }
    }





    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ApprovalFormGiven, "Value", this.__ttObject, "IsPatientApprovalFormGiven");
        redirectProperty(this.PreInformation, "Rtf", this.__ttObject, "PreInformation");
        redirectProperty(this.MedulaRaporTakipNo, "Text", this.__ttObject, "MedulaRaporTakipNo");
    }

    public initFormControls(): void {
        this.lblRaporBilgileri = new TTVisual.TTLabel();
        this.lblRaporBilgileri.Text = i18n("M20777", "Rapor Bilgileri");
        this.lblRaporBilgileri.Name = "lblRaporBilgileri";
        this.lblRaporBilgileri.TabIndex = 100;
        this.lblRaporBilgileri.Visible = false;

        this.MedulaRaporBilgileri = new TTVisual.TTTextBox();
        this.MedulaRaporBilgileri.BackColor = "#F0F0F0";
        this.MedulaRaporBilgileri.ReadOnly = true;
        this.MedulaRaporBilgileri.Name = "MedulaRaporBilgileri";
        this.MedulaRaporBilgileri.TabIndex = 7;
        this.MedulaRaporBilgileri.Visible = false;

        this.MedulaRaporTakipNo = new TTVisual.TTTextBox();
        this.MedulaRaporTakipNo.BackColor = "#F0F0F0";
        this.MedulaRaporTakipNo.ReadOnly = true;
        this.MedulaRaporTakipNo.Name = "MedulaRaporTakipNo";
        this.MedulaRaporTakipNo.TabIndex = 6;
        this.MedulaRaporTakipNo.Visible = false;

        this.labelMedulaRaporTakipNo = new TTVisual.TTLabel();
        this.labelMedulaRaporTakipNo.Text = "Medula Rapor Takip Numarası";
        this.labelMedulaRaporTakipNo.Name = "labelMedulaRaporTakipNo";
        this.labelMedulaRaporTakipNo.TabIndex = 98;
        this.labelMedulaRaporTakipNo.Visible = false;

        this.chkDisXXXXXXRaporu = new TTVisual.TTCheckBox();
        this.chkDisXXXXXXRaporu.Value = false;
        this.chkDisXXXXXXRaporu.Text = i18n("M20901", "Raporu Var");
        this.chkDisXXXXXXRaporu.Name = "chkDisXXXXXXRaporu";
        this.chkDisXXXXXXRaporu.TabIndex = 5;
        this.chkDisXXXXXXRaporu.Visible = false;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16661", "İstek Yapan Doktor");
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 91;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.ListDefName = "DoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 1;

        this.PreInformation = new TTVisual.TTRichTextBoxControl();
        this.PreInformation.DisplayText = i18n("M19965", "Ön Bilgi");
        this.PreInformation.TemplateGroupName = "Tıbbi/Cerrahi Uygulama Ön bilgi";
        this.PreInformation.BackColor = "#DCDCDC";
        this.PreInformation.Name = "PreInformation";
        this.PreInformation.TabIndex = 3;

        this.TabSubaction = new TTVisual.TTTabControl();
        this.TabSubaction.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabSubaction.Name = "TabSubaction";
        this.TabSubaction.TabIndex = 8;

        this.Manipulation = new TTVisual.TTTabPage();
        this.Manipulation.DisplayIndex = 0;
        this.Manipulation.BackColor = "#FFFFFF";
        this.Manipulation.TabIndex = 0;
        this.Manipulation.Text = "Tıbbi/Cerrahi Uygulama";
        this.Manipulation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Manipulation.Name = "Manipulation";

        this.GridManipulationProcedures = new TTVisual.TTGrid();
        this.GridManipulationProcedures.OnRowMarkerDoubleClickShowTTObjectForm = false;
        this.GridManipulationProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridManipulationProcedures.Name = "GridManipulationProcedures";
        this.GridManipulationProcedures.TabIndex = 0;

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
        this.ProcedureObject.Width = 500;

        this.Emergency = new TTVisual.TTCheckBoxColumn();
        this.Emergency.DataMember = "Emergency";
        this.Emergency.DisplayIndex = 2;
        this.Emergency.HeaderText = "Acil";
        this.Emergency.Name = "Emergency";
        this.Emergency.Width = 40;

        this.Department = new TTVisual.TTListBoxColumn();
        this.Department.ListDefName = "ResourceListDefinition";
        this.Department.ListFilterExpression = "OBJECTDEFNAME IN ('RESPOLICLINIC','RESCLINIC', 'RESTREATMENTDIAGNOSISUNIT','RESOBSERVATIONUNIT','RESRADIOLOGYDEPARTMENT')";
        this.Department.DataMember = "ProcedureDepartment";
        this.Department.DisplayIndex = 3;
        this.Department.HeaderText = i18n("M23778", "Uygulanacak Birim");
        this.Department.Name = "Department";
        this.Department.Width = 400;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 4;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.Width = 300;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16958", "İşlemTarihi");
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
        this.ApprovalFormGiven.Visible = false;

        this.cmdHistory = new TTVisual.TTButton();
        this.cmdHistory.Text = i18n("M23754", "Uygulama Geçmişini Listele");
        this.cmdHistory.Name = "cmdHistory";
        this.cmdHistory.TabIndex = 9;

        this.ManipulationGrid = new TTVisual.TTGrid();
        this.ManipulationGrid.ReadOnly = true;
        this.ManipulationGrid.Name = "ManipulationGrid";
        this.ManipulationGrid.TabIndex = 10;

        this.OldManipulationActionDate = new TTVisual.TTDateTimePickerColumn();
        this.OldManipulationActionDate.Format = DateTimePickerFormat.Custom;
        this.OldManipulationActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.OldManipulationActionDate.DisplayIndex = 0;
        this.OldManipulationActionDate.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.OldManipulationActionDate.Name = "OldManipulationActionDate";
        this.OldManipulationActionDate.ReadOnly = true;
        this.OldManipulationActionDate.Width = 120;

        this.OldProcedureObject = new TTVisual.TTListBoxColumn();
        this.OldProcedureObject.ListDefName = "ManiplationListDefinition";
        this.OldProcedureObject.DisplayIndex = 1;
        this.OldProcedureObject.HeaderText = "Tıbbi/Cerrahi Uygulama";
        this.OldProcedureObject.Name = "OldProcedureObject";
        this.OldProcedureObject.ReadOnly = true;
        this.OldProcedureObject.Width = 300;

        this.OldEmergency = new TTVisual.TTCheckBoxColumn();
        this.OldEmergency.DisplayIndex = 2;
        this.OldEmergency.HeaderText = "Acil";
        this.OldEmergency.Name = "OldEmergency";
        this.OldEmergency.ReadOnly = true;
        this.OldEmergency.Width = 35;

        this.OldDepartment = new TTVisual.TTListBoxColumn();
        this.OldDepartment.ListDefName = "ResourceListDefinition";
        this.OldDepartment.DisplayIndex = 3;
        this.OldDepartment.HeaderText = i18n("M23784", "Uygulanan Birim");
        this.OldDepartment.Name = "OldDepartment";
        this.OldDepartment.ReadOnly = true;
        this.OldDepartment.Width = 150;

        this.OldManipulationDoctor = new TTVisual.TTListBoxColumn();
        this.OldManipulationDoctor.ListDefName = "DoctorListDefinition";
        this.OldManipulationDoctor.DisplayIndex = 4;
        this.OldManipulationDoctor.HeaderText = i18n("M16938", "İşlemi Yapması Öngörülen Tabip");
        this.OldManipulationDoctor.Name = "OldManipulationDoctor";
        this.OldManipulationDoctor.ReadOnly = true;
        this.OldManipulationDoctor.Width = 180;

        this.OldDescription = new TTVisual.TTTextBoxColumn();
        this.OldDescription.DisplayIndex = 5;
        this.OldDescription.HeaderText = i18n("M10469", "Açıklama");
        this.OldDescription.Name = "OldDescription";
        this.OldDescription.ReadOnly = true;
        this.OldDescription.Width = 100;

        this.ManipulationProcedureList = new TTVisual.TTObjectListBox();
        this.ManipulationProcedureList.ListDefName = "ManiplationListDefinition";
        this.ManipulationProcedureList.Name = "ManipulationProcedureList";
        this.ManipulationProcedureList.AutoCompleteDialogHeight = "200px";

        this.GridManipulationProceduresColumns = [this.ManipulationActionDate, this.ProcedureObject, this.Emergency, this.Department];

        this.ManipulationGridColumns = [this.OldManipulationActionDate, this.OldProcedureObject, this.OldEmergency, this.OldDepartment, this.OldManipulationDoctor, this.OldDescription];
        this.TabSubaction.Controls = [this.Manipulation];
        this.Manipulation.Controls = [this.GridManipulationProcedures];
        this.Controls = [this.lblRaporBilgileri, this.MedulaRaporBilgileri, this.MedulaRaporTakipNo, this.labelMedulaRaporTakipNo, this.chkDisXXXXXXRaporu, this.labelProcedureDoctor, this.ProcedureDoctor, this.PreInformation, this.TabSubaction, this.Manipulation, this.GridManipulationProcedures, this.ManipulationActionDate, this.ProcedureObject, this.Emergency, this.Department, this.Description, this.ActionDate, this.labelProcessTime, this.ApprovalFormGiven, this.cmdHistory, this.ManipulationGrid, this.OldManipulationActionDate, this.OldProcedureObject, this.OldEmergency, this.OldDepartment, this.OldManipulationDoctor, this.OldDescription];

    }

    public actionIdForDemografic: Guid

    setActionIdForDemografic() {
        if (this._ManipulationRequest.MasterAction != null) {
            if (typeof this._ManipulationRequest.MasterAction === "string") {
                this.actionIdForDemografic = this._ManipulationRequest.MasterAction;
            }
            else {
                this.actionIdForDemografic = this._ManipulationRequest.MasterAction.ObjectID;
            }
        }else
            this.actionIdForDemografic = this._ManipulationRequest.ObjectID;
    }

    manipulationSelected(data: any) {
        let that = this;
        if (data != null) {
            let manipulationProcedure: ManipulationProcedure = new ManipulationProcedure();
            manipulationProcedure.ActionDate = new Date();
            manipulationProcedure.ProcedureObject = data;
            manipulationProcedure.Emergency = false;
            if (data.Resource != null && (typeof data.Resource === 'string')) {

                let procedureDepartment = that.manipulationRequestFormViewModel.ResSections.find(o => o.ObjectID.toString() === data.Resource.toString());
                manipulationProcedure.ProcedureDepartment = procedureDepartment;
            }
            manipulationProcedure.Description = "";

            this.manipulationRequestFormViewModel.GridManipulationProceduresGridList.unshift(manipulationProcedure);
        }
    }

    btnManipulationRequestSave_Click() {
        this.save();

    }


    public printReport() {
        const objectIdParam = new GuidParam(this.manipulationRequestFormViewModel._ManipulationRequest.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('ManipulationRequestReport', reportParameters);
    }



}
