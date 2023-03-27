//$954F55CA
import { Component, OnInit, NgZone, ComponentRef } from '@angular/core';
import { ManipulationProcedureFormViewModel } from './ManipulationProcedureFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationAdditionalApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationReturnReasonsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ManipulationFormBaseObjectForm } from "Modules/Tibbi_Surec/Manipulasyon_Modulu/ManipulationFormBaseObjectForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';

import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInfoDVO } from 'Fw/Models/DynamicComponentInfoDVO';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { ModalInfo } from '../../../wwwroot/app/Fw/Models/ModalInfo';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';

@Component({
    selector: 'ManipulationProcedureForm',
    templateUrl: './ManipulationProcedureForm.html',
    providers: [MessageService]
})
export class ManipulationProcedureForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AdditionalApplicationTab: TTVisual.ITTTabPage;
    Amount: TTVisual.ITTTextBoxColumn;
    AmountDirectPurchaseGrid: TTVisual.ITTTextBoxColumn;
    AProcedureObject: TTVisual.ITTListBoxColumn;
    AyniFarkliKesi: TTVisual.ITTListBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    Birim: TTVisual.ITTTextBoxColumn;
    CokluOzelDurum: TTVisual.ITTButtonColumn;
    Department: TTVisual.ITTListBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    DirectPurchase: TTVisual.ITTTabPage;
    DirectPurchaseGrids: TTVisual.ITTGrid;
    DistributionType: TTVisual.ITTTextBoxColumn;
    DoctorRapor: TTVisual.ITTRichTextBoxControl;
    DrAnesteziTescilNo: TTVisual.ITTListBoxColumn;
    Emergency: TTVisual.ITTCheckBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    EuroScore: TTVisual.ITTEnumComboBoxColumn;
    GridAdditionalApplications: TTVisual.ITTGrid;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridManipulations: TTVisual.ITTGrid;
    GridPersonnel: TTVisual.ITTGrid;
    GridReturnReasons: TTVisual.ITTGrid;
    GridTreatmentMaterials: TTVisual.ITTGrid;
    IDEpisode: TTVisual.ITTTextBox;
    IDResource: TTVisual.ITTTextBox;
    labelProcessTime: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelResponsiblePersonnel: TTVisual.ITTLabel;
    lblSorumluDoktor: TTVisual.ITTLabel;
    ManiplasyonTab: TTVisual.ITTTabPage;
    ManipulationActionDate: TTVisual.ITTDateTimePickerColumn;
    Material: TTVisual.ITTListBoxColumn;
    MaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    MaterialDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    Notes: TTVisual.ITTTextBoxColumn;
    NurseNotes: TTVisual.ITTTextBoxColumn;
    OzelDurum: TTVisual.ITTListBoxColumn;
    Personnel: TTVisual.ITTListBoxColumn;
    PersonnelTab: TTVisual.ITTTabPage;
    PreInFormation: TTVisual.ITTRichTextBoxControl;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ProcedureRapor: TTVisual.ITTRichTextBoxControl;
    ProtocolNo: TTVisual.ITTTextBox;
    RaporTakipNo: TTVisual.ITTTextBoxColumn;
    ResponsiblePersonnel: TTVisual.ITTObjectListBox;
    ResponsibleUserLabel: TTVisual.ITTLabel;
    Result: TTVisual.ITTTextBoxColumn;
    SagSol: TTVisual.ITTListBoxColumn;
    SDateTime: TTVisual.ITTDateTimePickerColumn;
    Sonuc: TTVisual.ITTTextBoxColumn;
    SorumluDoktor: TTVisual.ITTObjectListBox;
    TabSubaction: TTVisual.ITTTabControl;
    Technician: TTVisual.ITTObjectListBox;
    TreatmentMaterial: TTVisual.ITTTabPage;
    ReturnDate: TTVisual.ITTDateTimePickerColumn;
    ReturnReason: TTVisual.ITTTextBoxColumn;
    ReasonOfCancel: TTVisual.ITTTextBox;

    ActivePage: string;
    ActiveAcc: string;
 RecentAcc: string;

    public DirectPurchaseGridsColumns = [];
    public GridAdditionalApplicationsColumns = [];
    public GridEpisodeDiagnosisColumns = [];
    public GridManipulationsColumns = [];
    public GridPersonnelColumns = [];
    public GridReturnReasonsColumns = [];
    public GridTreatmentMaterialsColumns = [];
    public manipulationProcedureFormViewModel: ManipulationProcedureFormViewModel = new ManipulationProcedureFormViewModel();
    public get _Manipulation(): Manipulation {
        return this._TTObject as Manipulation;
    }
    private ManipulationProcedureForm_DocumentUrl: string = '/api/ManipulationService/ManipulationProcedureForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected tabService: IActiveTabService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
                protected ngZone: NgZone) {
        super('MANIPULATION', 'ManipulationProcedureForm');
        this._DocumentServiceUrl = this.ManipulationProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    AccPinClick(acc) {
        if (this.RecentAcc == acc) {
            this.RecentAcc = undefined;
            this.tabService.setActiveTab(this.RecentAcc, 'pedfnacc');
        }
        else {
            this.RecentAcc = acc;
            this.tabService.setActiveTab(this.RecentAcc, 'pedfnacc');
        }
    }
 
public componentManipulationFormBaseObjectInfo: DynamicComponentInfo;

    public onSetManipulationFormBaseObjectViewModel(componentRef: ComponentRef<any>): void {

        let manipulationFormBaseObjectComponent = componentRef.instance as ManipulationFormBaseObjectForm;
        let boundedFunc = this.setManipulationFormBaseObjectViewModel.bind(this);
        manipulationFormBaseObjectComponent.sendMyViewModel.subscribe(boundedFunc);
    }

 public setManipulationFormBaseObjectViewModel(e: any) {

        let that = this;
        if (this._ViewModel.ManipulationFormBaseObjectViewModels == null) {
            this._ViewModel.ManipulationFormBaseObjectViewModels = new Array<any>();
            this._ViewModel.ManipulationFormBaseObjectViewModels.push(e); // e SpecialityBasedObjectViewModel tipinde bir ViewModel
        }
    }



    async setManipulationFormBaseObjectInfo(): Promise<void> {
        if (this._ViewModel.hasManipulationFormBaseObject == true) {
            await this.httpService.get<DynamicComponentInfoDVO>("api/EpisodeActionService/GetDynamicComponentManipulationFormBaseObjectInfo?EpisodeActionObjectId=" + this._Manipulation.ObjectID, DynamicComponentInfoDVO).then(response => {
                let result: DynamicComponentInfoDVO = <DynamicComponentInfoDVO>(response);
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                if (result.ComponentName != null) {
                    compInfo.ComponentName = result.ComponentName;
                    compInfo.ModuleName = result.ModuleName;
                    compInfo.ModulePath = result.ModulePath;
                    compInfo.objectID = result.objectID;
                    compInfo.InputParam = new DynamicComponentInputParam(this.manipulationProcedureFormViewModel._Manipulation.CurrentStateDefID, new ActiveIDsModel(this._Manipulation.ObjectID, null, null));
                    this.componentManipulationFormBaseObjectInfo = compInfo;
                }
            }

            );
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.setManipulationFormBaseObjectInfo();
        //buton eklendiğindexede açılmalı
        //if (this._Manipulation.CurrentStateDefID === Manipulation.ManipulationStates.Completed)
        //    this.btnOpenFromPdf.Visible = true;
        //else this.btnOpenFromPdf.Visible = false;


      this.arrangeFieldsVisibility();

    }


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        if (transDef !== null) {
            if (transDef.ToStateDefID.valueOf() == Manipulation.ManipulationStates.Completed.id) {
                if (this.manipulationProcedureFormViewModel.hasManipulationFormBaseObject == true && this.manipulationProcedureFormViewModel.ManipulationFormBaseObjectViewModels.length > 0 && this.manipulationProcedureFormViewModel.ManipulationFormBaseObjectViewModels[0].constructor.name === "EkokardiografiFormViewModel") {
                    this.openEkokardiografiForm();
                } else {
                    const objectIdParam = new GuidParam(this._Manipulation.ObjectID);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                    this.reportService.showReportModal('ManipulationProcedureReport', reportParameters);
                }
            }
        }




    }

    public openEkokardiografiForm() {


        let reportData: DynamicReportParameters = {

            Code: 'EKOKARDIOGRAFIFORMU',
            ReportParams: { ObjectID: this.manipulationProcedureFormViewModel.ManipulationFormBaseObjectViewModels[0]._EkokardiografiFormObject.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "EKOKARDİOGRAFİ FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            if (transDef.FromStateDefID.valueOf() == Manipulation.ManipulationStates.TechnicianProcedure.id) { // Teknisyenden tamam dire geçiş yok
                if (this._Manipulation.Technician == null)
                    throw new Exception(i18n("M23107", "Teknisyen bilgisini giriniz!"));
            }
            if (transDef.ToStateDefID.valueOf() == Manipulation.ManipulationStates.Completed.id) {
                if (this._Manipulation.ProcedureDoctor == null)
                    throw new Exception(i18n("M22144", "Sorumlu doktor bilgisini giriniz!"));
            }

            if (transDef.ToStateDefID.valueOf() == Manipulation.ManipulationStates.RequestingDoctorFromTechnicianProcedure.id) {
               await this.takeReturnReasonFromUser(i18n("M13214", "Doktora İade Sebebi :"));
            }

            if (transDef.ToStateDefID.valueOf() == Manipulation.ManipulationStates.RequestingDoctorFromDoctorProcedure.id) {
                await this.takeReturnReasonFromUser(i18n("M16602", "İsteği Yapan Doktora İade Sebebi :"));
            }
            if (transDef.ToStateDefID.valueOf() == Manipulation.ManipulationStates.TechnicianProcedure.id) {
                await this.takeReturnReasonFromUser(i18n("M23120", "Teknisyene İade Sebebi :"));
            }
            if (transDef.ToStateDefID.valueOf() == Manipulation.ManipulationStates.Cancelled.id) {
                await this.takeReasonOfCancelFromUser();
            }
        }
    }


    isReportVisible = false;
    isProcedureReportVisible = false;
    isManipulationOzelDurumVisible = false;
    isResponsiblePersonnelVisible = false;
    isTechnicianVisible = false;
    isReturnReasonsVisible = false;
    isTreatmentMaterialVisible = false;
    isReasonOfCancelVisible = false;

    arrangeFieldsVisibility()
    {
        if (this._Manipulation.ManipulationReturnReasons.length > 0)
            this.isReturnReasonsVisible = true;

        if (this._Manipulation.CurrentStateDefID == Manipulation.ManipulationStates.DoctorProcedure){
            this.isReportVisible = true;
            this.isManipulationOzelDurumVisible = true;
            this.isTreatmentMaterialVisible = true;
        }
        else if (this._Manipulation.CurrentStateDefID == Manipulation.ManipulationStates.TechnicianProcedure) {
            this.isProcedureReportVisible = true;
            this.isTechnicianVisible = true;
            this.isTreatmentMaterialVisible = true;
        }
        else if (this._Manipulation.CurrentStateDefID == Manipulation.ManipulationStates.NursingProcedure) {
            this.isProcedureReportVisible = true;
            if (this._Manipulation.ResponsiblePersonnel != null)
                this.isResponsiblePersonnelVisible = true;
            this.isTreatmentMaterialVisible = true;
        }
        else if (this._Manipulation.CurrentStateDefID == Manipulation.ManipulationStates.ResultEntry) {
            this.isReportVisible = true;
            this.isProcedureReportVisible = true;
            if (this._Manipulation.ResponsiblePersonnel != null)
                this.isResponsiblePersonnelVisible = true;
            if (this._Manipulation.Technician != null)
                this.isTechnicianVisible = true;
            this.isTreatmentMaterialVisible = true;
        }
        else if (this._Manipulation.CurrentStateDefID == Manipulation.ManipulationStates.RequestingDoctorFromTechnicianProcedure) {
            this.isProcedureReportVisible = true;
            if (this._Manipulation.ResponsiblePersonnel != null)
                this.isResponsiblePersonnelVisible = true;
            if (this._Manipulation.Technician != null)
                this.isTechnicianVisible = true;
            this.isTreatmentMaterialVisible = true;
            this.ProcedureRapor.ReadOnly = true;
        }
        else if (this._Manipulation.CurrentStateDefID == Manipulation.ManipulationStates.Cancelled) {
            this.isReportVisible = true;
            this.isProcedureReportVisible = true;
            if (this._Manipulation.ResponsiblePersonnel != null)
                this.isResponsiblePersonnelVisible = true;
            if (this._Manipulation.Technician != null)
                this.isTechnicianVisible = true;
            this.isTreatmentMaterialVisible = true;
            this.isReasonOfCancelVisible = true;
        }
        else if (this._Manipulation.CurrentStateDefID == Manipulation.ManipulationStates.Completed) {
            this.isReportVisible = true;
            this.isProcedureReportVisible = true;
            if (this._Manipulation.ResponsiblePersonnel != null)
                this.isResponsiblePersonnelVisible = true;
            if (this._Manipulation.Technician != null)
                this.isTechnicianVisible = true;
            this.isTreatmentMaterialVisible = true;
        }

        if (this.manipulationProcedureFormViewModel.hasManipulationFormBaseObject == true) {
            this.isProcedureReportVisible = false;
            this.isReportVisible = false;

        }
    }

   async takeReturnReasonFromUser( note: string )
    {
       let returnReason: string = await InputForm.GetText(note + i18n("M14794", " Giriniz."), "", true, true);
       if (returnReason != null && returnReason != "") {
           let mrg: ManipulationReturnReasonsGrid = new ManipulationReturnReasonsGrid(this._Manipulation.ObjectContext);
           mrg.ReturnReason = note + returnReason;
           this._Manipulation.ManipulationReturnReasons.push(mrg);
       }
    }

   async takeReasonOfCancelFromUser() {
       this._Manipulation.ReasonOfCancel = await InputForm.GetText(i18n("M16853", "İşlem İptal Sebebi."), "", true, true);

   }

    private async btnOpenFromPdf_Click(): Promise<void> {
        //TODO PdfOpen!
        //   string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //            string filePath = appPath + @"\ManipulationReport";
        //            filePath += "(" + System.DateTime.Now.ToShortDateString() + ")" + ".pdf";
        //            Byte[] memoryStream = (byte[])_Manipulation.ReportPDF;
        //            const int myBufferSize = 1024;
        //            System.IO.Stream myInputStream = new System.IO.MemoryStream(memoryStream);
        //            System.IO.Stream myOutputStream = System.IO.File.OpenWrite(filePath);
        //            byte[] buffer = new Byte[myBufferSize];
        //            int numbytes;
        //            while ((numbytes = myInputStream.Read(buffer, 0, myBufferSize)) > 0)
        //            {
        //                myOutputStream.Write(buffer, 0, numbytes);
        //            }
        //            myInputStream.Close();
        //            myOutputStream.Close();
        //            System.Diagnostics.Process proc = new System.Diagnostics.Process();
        //            proc.EnableRaisingEvents = false;
        //            proc.StartInfo.FileName = filePath ;
        //            proc.StartInfo.Arguments = "WINWORD.EXE";
        //            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
        //            proc.Start();
        ////            proc.WaitForExit();
        let a = 1;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Manipulation();
        this.manipulationProcedureFormViewModel = new ManipulationProcedureFormViewModel();
        this._ViewModel = this.manipulationProcedureFormViewModel;
        this.manipulationProcedureFormViewModel._Manipulation = this._TTObject as Manipulation;
        this.manipulationProcedureFormViewModel._Manipulation.ManipulationProcedures = new Array<ManipulationProcedure>();
        this.manipulationProcedureFormViewModel._Manipulation.ManipulationPersonnel = new Array<ManipulationPersonnel>();
        this.manipulationProcedureFormViewModel._Manipulation.ManipulationTreatmentMaterials = new Array<ManipulationTreatmentMaterial>();
        this.manipulationProcedureFormViewModel._Manipulation.ManipulationAdditionalApplications = new Array<ManipulationAdditionalApplication>();
        this.manipulationProcedureFormViewModel._Manipulation.DirectPurchaseGrids = new Array<DirectPurchaseGrid>();
        this.manipulationProcedureFormViewModel._Manipulation.Episode = new Episode();
        this.manipulationProcedureFormViewModel._Manipulation.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.manipulationProcedureFormViewModel._Manipulation.MasterResource = new ResSection();
        this.manipulationProcedureFormViewModel._Manipulation.ManipulationRequest = new ManipulationRequest();
        this.manipulationProcedureFormViewModel._Manipulation.Technician = new ResUser();
        this.manipulationProcedureFormViewModel._Manipulation.ProcedureDoctor = new ResUser();
        this.manipulationProcedureFormViewModel._Manipulation.ResponsiblePersonnel = new ResUser();
        this.manipulationProcedureFormViewModel._Manipulation.ManipulationReturnReasons = new Array<ManipulationReturnReasonsGrid>();
    }

    protected loadViewModel() {
        let that = this;

        that.manipulationProcedureFormViewModel = this._ViewModel as ManipulationProcedureFormViewModel;
        that._TTObject = this.manipulationProcedureFormViewModel._Manipulation;
        if (this.manipulationProcedureFormViewModel == null)
            this.manipulationProcedureFormViewModel = new ManipulationProcedureFormViewModel();
        if (this.manipulationProcedureFormViewModel._Manipulation == null)
            this.manipulationProcedureFormViewModel._Manipulation = new Manipulation();
        that.manipulationProcedureFormViewModel._Manipulation.ManipulationProcedures = that.manipulationProcedureFormViewModel.GridManipulationsGridList;
        for (let detailItem of that.manipulationProcedureFormViewModel.GridManipulationsGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.manipulationProcedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let procedureDepartmentObjectID = detailItem["ProcedureDepartment"];
            if (procedureDepartmentObjectID != null && (typeof procedureDepartmentObjectID === 'string')) {
                let procedureDepartment = that.manipulationProcedureFormViewModel.ResSections.find(o => o.ObjectID.toString() === procedureDepartmentObjectID.toString());
                 if (procedureDepartment) {
                    detailItem.ProcedureDepartment = procedureDepartment;
                }
            }
            let ayniFarkliKesiObjectID = detailItem["AyniFarkliKesi"];
            if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === 'string')) {
                let ayniFarkliKesi = that.manipulationProcedureFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
                 if (ayniFarkliKesi) {
                    detailItem.AyniFarkliKesi = ayniFarkliKesi;
                }
            }
            let anesteziDoktorObjectID = detailItem["AnesteziDoktor"];
            if (anesteziDoktorObjectID != null && (typeof anesteziDoktorObjectID === 'string')) {
                let anesteziDoktor = that.manipulationProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === anesteziDoktorObjectID.toString());
                 if (anesteziDoktor) {
                    detailItem.AnesteziDoktor = anesteziDoktor;
                }
            }
            let sagSolObjectID = detailItem["SagSol"];
            if (sagSolObjectID != null && (typeof sagSolObjectID === 'string')) {
                let sagSol = that.manipulationProcedureFormViewModel.SagSols.find(o => o.ObjectID.toString() === sagSolObjectID.toString());
                 if (sagSol) {
                    detailItem.SagSol = sagSol;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.manipulationProcedureFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        that.manipulationProcedureFormViewModel._Manipulation.ManipulationPersonnel = that.manipulationProcedureFormViewModel.GridPersonnelGridList;
        for (let detailItem of that.manipulationProcedureFormViewModel.GridPersonnelGridList) {
            let personnelObjectID = detailItem["Personnel"];
            if (personnelObjectID != null && (typeof personnelObjectID === 'string')) {
                let personnel = that.manipulationProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === personnelObjectID.toString());
                 if (personnel) {
                    detailItem.Personnel = personnel;
                }
            }
        }
        that.manipulationProcedureFormViewModel._Manipulation.ManipulationTreatmentMaterials = that.manipulationProcedureFormViewModel.GridTreatmentMaterialsGridList;
        for (let detailItem of that.manipulationProcedureFormViewModel.GridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.manipulationProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.manipulationProcedureFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.manipulationProcedureFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.manipulationProcedureFormViewModel._Manipulation.ManipulationAdditionalApplications = that.manipulationProcedureFormViewModel.GridAdditionalApplicationsGridList;
        for (let detailItem of that.manipulationProcedureFormViewModel.GridAdditionalApplicationsGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.manipulationProcedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
        that.manipulationProcedureFormViewModel._Manipulation.DirectPurchaseGrids = that.manipulationProcedureFormViewModel.DirectPurchaseGridsGridList;
        for (let detailItem of that.manipulationProcedureFormViewModel.DirectPurchaseGridsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.manipulationProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
        let episodeObjectID = that.manipulationProcedureFormViewModel._Manipulation["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.manipulationProcedureFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.manipulationProcedureFormViewModel._Manipulation.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.manipulationProcedureFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.manipulationProcedureFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.manipulationProcedureFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.manipulationProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let masterResourceObjectID = that.manipulationProcedureFormViewModel._Manipulation["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.manipulationProcedureFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
             if (masterResource) {
                that.manipulationProcedureFormViewModel._Manipulation.MasterResource = masterResource;
            }
        }
        let manipulationRequestObjectID = that.manipulationProcedureFormViewModel._Manipulation["ManipulationRequest"];
        if (manipulationRequestObjectID != null && (typeof manipulationRequestObjectID === 'string')) {
            let manipulationRequest = that.manipulationProcedureFormViewModel.ManipulationRequests.find(o => o.ObjectID.toString() === manipulationRequestObjectID.toString());
             if (manipulationRequest) {
                that.manipulationProcedureFormViewModel._Manipulation.ManipulationRequest = manipulationRequest;
            }
        }
        let technicianObjectID = that.manipulationProcedureFormViewModel._Manipulation["Technician"];
        if (technicianObjectID != null && (typeof technicianObjectID === 'string')) {
            let technician = that.manipulationProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === technicianObjectID.toString());
             if (technician) {
                that.manipulationProcedureFormViewModel._Manipulation.Technician = technician;
            }
        }
        let procedureDoctorObjectID = that.manipulationProcedureFormViewModel._Manipulation["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.manipulationProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.manipulationProcedureFormViewModel._Manipulation.ProcedureDoctor = procedureDoctor;
            }
        }
        let responsiblePersonnelObjectID = that.manipulationProcedureFormViewModel._Manipulation["ResponsiblePersonnel"];
        if (responsiblePersonnelObjectID != null && (typeof responsiblePersonnelObjectID === 'string')) {
            let responsiblePersonnel = that.manipulationProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsiblePersonnelObjectID.toString());
             if (responsiblePersonnel) {
                that.manipulationProcedureFormViewModel._Manipulation.ResponsiblePersonnel = responsiblePersonnel;
            }
        }
        that.manipulationProcedureFormViewModel._Manipulation.ManipulationReturnReasons = that.manipulationProcedureFormViewModel.GridReturnReasonsGridList;
        for (let detailItem of that.manipulationProcedureFormViewModel.GridReturnReasonsGridList) {
        }

        //this.ActivePage = this.tabService.getActiveTab('pedfn');
        //if (this.ActivePage === undefined) {
        //    if (this.manipulationProcedureFormViewModel.hasManipulationFormBaseObject === true) {
        //        this.ActivePage = '#hizmetformu';
        //    }
        //} else if (this.ActivePage !== undefined) {
        //    if (this.manipulationProcedureFormViewModel.hasManipulationFormBaseObject === false && this.ActivePage === '#hizmetformu') {
        //        this.ActivePage = '#muayene';
        //    }
        //}
    }


    async ngOnInit()  {
        let that = this;
        await this.load(ManipulationProcedureFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ActionDate != event) {
                this._Manipulation.ActionDate = event;
            }
        }
    }

    public onDoctorRaporChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.Report != event) {
                this._Manipulation.Report = event;
            }
        }
    }

    public onIDEpisodeChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null &&
                this._Manipulation.Episode != null && this._Manipulation.Episode.ID != event) {
                this._Manipulation.Episode.ID = event;
            }
        }
    }

    public onIDResourceChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null &&
                this._Manipulation.MasterResource != null && this._Manipulation.MasterResource.Name != event) {
                this._Manipulation.MasterResource.Name = event;
            }
        }
    }

    public onPreInFormationChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null &&
                this._Manipulation.ManipulationRequest != null && this._Manipulation.ManipulationRequest.PreInformation != event) {
                this._Manipulation.ManipulationRequest.PreInformation = event;
            }
        }
    }

    public onProcedureRaporChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ProcedureReport != event) {
                this._Manipulation.ProcedureReport = event;
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

    public onResponsiblePersonnelChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ResponsiblePersonnel != event) {
                this._Manipulation.ResponsiblePersonnel = event;
            }
        }
    }

    public onSorumluDoktorChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ProcedureDoctor != event) {
                this._Manipulation.ProcedureDoctor = event;
            }
        }
    }

    public onTechnicianChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.Technician != event) {
                this._Manipulation.Technician = event;
            }
        }
    }
    public onReasonOfCancelChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ReasonOfCancel != event) {
                this._Manipulation.ReasonOfCancel = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.IDResource, "Text", this.__ttObject, "MasterResource.Name");
        redirectProperty(this.IDEpisode, "Text", this.__ttObject, "Episode.ID");
        redirectProperty(this.PreInFormation, "Rtf", this.__ttObject, "ManipulationRequest.PreInformation");
        redirectProperty(this.ProcedureRapor, "Rtf", this.__ttObject, "ProcedureReport");
        redirectProperty(this.DoctorRapor, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.ReasonOfCancel, "Text", this.__ttObject, "ReasonOfCancel");
    }

    public initFormControls(): void {
        this.ResponsibleUserLabel = new TTVisual.TTLabel();
        this.ResponsibleUserLabel.Text = i18n("M22161", "Sorumlu Teknisyen");
        this.ResponsibleUserLabel.Name = "ResponsibleUserLabel";
        this.ResponsibleUserLabel.TabIndex = 187;

        this.TabSubaction = new TTVisual.TTTabControl();
        this.TabSubaction.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabSubaction.Name = "TabSubaction";
        this.TabSubaction.TabIndex = 7;

        this.ManiplasyonTab = new TTVisual.TTTabPage();
        this.ManiplasyonTab.DisplayIndex = 0;
        this.ManiplasyonTab.BackColor = "#FFFFFF";
        this.ManiplasyonTab.TabIndex = 0;
        this.ManiplasyonTab.Text = "Tıbbi/Cerrahi Uygulama";
        this.ManiplasyonTab.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ManiplasyonTab.Name = "ManiplasyonTab";

        this.GridManipulations = new TTVisual.TTGrid();
        this.GridManipulations.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridManipulations.Name = "GridManipulations";
        this.GridManipulations.TabIndex = 0;
        this.GridManipulations.AllowUserToAddRows = false;
        this.GridManipulations.AllowUserToDeleteRows = false;
        //this.GridManipulations.Height = 80;

        this.ManipulationActionDate = new TTVisual.TTDateTimePickerColumn();
        this.ManipulationActionDate.Format = DateTimePickerFormat.Custom;
        this.ManipulationActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ManipulationActionDate.DataMember = "ActionDate";
        this.ManipulationActionDate.DisplayIndex = 0;
        this.ManipulationActionDate.HeaderText = "Tarih/Saat";
        this.ManipulationActionDate.Name = "ManipulationActionDate";
        this.ManipulationActionDate.ReadOnly = true;
        this.ManipulationActionDate.Width = 110;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "ManiplationListDefinition";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 1;
        this.ProcedureObject.HeaderText = "Tıbbi/Cerrahi Uygulama";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.Width = 250;

        this.Emergency = new TTVisual.TTCheckBoxColumn();
        this.Emergency.DataMember = "Emergency";
        this.Emergency.DisplayIndex = 2;
        this.Emergency.HeaderText = "Acil";
        this.Emergency.Name = "Emergency";
        this.Emergency.ReadOnly = true;
        this.Emergency.Width = 36;

        this.Department = new TTVisual.TTListBoxColumn();
        this.Department.ListDefName = "ResourceListDefinition";
        this.Department.DataMember = "ProcedureDepartment";
        this.Department.DisplayIndex = 3;
        this.Department.HeaderText = i18n("M23778", "Uygulanacak Birim");
        this.Department.Name = "Department";
        this.Department.ReadOnly = true;
        this.Department.Width = 150;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 4;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.ReadOnly = true;
        this.Description.Width = 100;

        this.AyniFarkliKesi = new TTVisual.TTListBoxColumn();
        this.AyniFarkliKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.AyniFarkliKesi.DataMember = "AyniFarkliKesi";
        this.AyniFarkliKesi.DisplayIndex = 5;
        this.AyniFarkliKesi.HeaderText = i18n("M11343", "Aynı Farklı Kesi");
        this.AyniFarkliKesi.Name = "AyniFarkliKesi";
        this.AyniFarkliKesi.Width = 110;


        this.SagSol = new TTVisual.TTListBoxColumn();
        this.SagSol.ListDefName = "SagSolListDefinition";
        this.SagSol.DataMember = "SagSol";
        this.SagSol.DisplayIndex = 6;
        this.SagSol.HeaderText = i18n("M21141", "Sağ Sol");
        this.SagSol.Name = "SagSol";
        this.SagSol.Width = 100;

        this.DrAnesteziTescilNo = new TTVisual.TTListBoxColumn();
        this.DrAnesteziTescilNo.ListDefName = "ResUserListDefinition";
        this.DrAnesteziTescilNo.DataMember = "AnesteziDoktor";
        this.DrAnesteziTescilNo.DisplayIndex = 7;
        this.DrAnesteziTescilNo.HeaderText = i18n("M10969", "Anestezi Dr.Tescil No");
        this.DrAnesteziTescilNo.Name = "DrAnesteziTescilNo";
        this.DrAnesteziTescilNo.Width = 100;

        this.EuroScore = new TTVisual.TTEnumComboBoxColumn();
        this.EuroScore.DataTypeName = "MedulaEuroScoreEnum";
        this.EuroScore.DataMember = "MEDULAEUROSCORE";
        this.EuroScore.DisplayIndex = 8;
        this.EuroScore.HeaderText = i18n("M13967", "Euro Score");
        this.EuroScore.Name = "EuroScore";
        this.EuroScore.ReadOnly = true;
        this.EuroScore.Width = 80;

        this.Birim = new TTVisual.TTTextBoxColumn();
        this.Birim.DataMember = "Birim";
        this.Birim.DisplayIndex = 9;
        this.Birim.HeaderText = "Birim";
        this.Birim.Name = "Birim";
        this.Birim.Width = 80;

        this.Sonuc = new TTVisual.TTTextBoxColumn();
        this.Sonuc.DataMember = "Sonuc";
        this.Sonuc.DisplayIndex = 10;
        this.Sonuc.HeaderText = i18n("M22078", "Sonuç");
        this.Sonuc.Name = "Sonuc";
        this.Sonuc.Width = 100;

        this.RaporTakipNo = new TTVisual.TTTextBoxColumn();
        this.RaporTakipNo.DataMember = "RaporTakipNo";
        this.RaporTakipNo.DisplayIndex = 11;
        this.RaporTakipNo.HeaderText = i18n("M20855", "Rapor Takip No");
        this.RaporTakipNo.Name = "RaporTakipNo";
        this.RaporTakipNo.Width = 100;

        this.OzelDurum = new TTVisual.TTListBoxColumn();
        this.OzelDurum.ListDefName = "OzelDurumListDefinition";
        this.OzelDurum.DataMember = "OzelDurum";
        this.OzelDurum.DisplayIndex = 12;
        this.OzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.OzelDurum.Name = "OzelDurum";
        this.OzelDurum.Width = 100;

        this.CokluOzelDurum = new TTVisual.TTButtonColumn();
        this.CokluOzelDurum.DisplayIndex = 13;
        this.CokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.CokluOzelDurum.Name = "CokluOzelDurum";
        this.CokluOzelDurum.Width = 100;

        this.PersonnelTab = new TTVisual.TTTabPage();
        this.PersonnelTab.DisplayIndex = 1;
        this.PersonnelTab.BackColor = "#FFFFFF";
        this.PersonnelTab.TabIndex = 1;
        this.PersonnelTab.Text = i18n("M16904", "İşlemde Görev Alan Personel");
        this.PersonnelTab.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PersonnelTab.Name = "PersonnelTab";

        this.GridPersonnel = new TTVisual.TTGrid();
        this.GridPersonnel.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridPersonnel.Name = "GridPersonnel";
        this.GridPersonnel.TabIndex = 0;
        //this.GridPersonnel.Height = 80;

        this.Personnel = new TTVisual.TTListBoxColumn();
        this.Personnel.ListDefName = "UserListDefinition";
        this.Personnel.DataMember = "Personnel";
        this.Personnel.DisplayIndex = 0;
        this.Personnel.HeaderText = "Personel";
        this.Personnel.Name = "Personnel";
        this.Personnel.Width = 1100;

        this.TreatmentMaterial = new TTVisual.TTTabPage();
        this.TreatmentMaterial.DisplayIndex = 2;
        this.TreatmentMaterial.BackColor = "#FFFFFF";
        this.TreatmentMaterial.TabIndex = 0;
        this.TreatmentMaterial.Text = i18n("M21320", "Sarf Giriş");
        this.TreatmentMaterial.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TreatmentMaterial.Name = "TreatmentMaterial";

        this.GridTreatmentMaterials = new TTVisual.TTGrid();
        this.GridTreatmentMaterials.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridTreatmentMaterials.Name = "GridTreatmentMaterials";
        this.GridTreatmentMaterials.TabIndex = 0;
        //this.GridTreatmentMaterials.Height = 80;

        this.MaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.MaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.MaterialActionDate.DataMember = "ActionDate";
        this.MaterialActionDate.DisplayIndex = 0;
        this.MaterialActionDate.HeaderText = "Tarih/Saat";
        this.MaterialActionDate.Name = "MaterialActionDate";
        this.MaterialActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "ConsumableMaterialAndDrugList";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M21314", "Sarf Edilen Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 340;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 4;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 100;

        this.Notes = new TTVisual.TTTextBoxColumn();
        this.Notes.DataMember = "Note";
        this.Notes.DisplayIndex = 5;
        this.Notes.HeaderText = i18n("M19485", "Notlar");
        this.Notes.Name = "Notes";
        this.Notes.Width = 245;

        this.AdditionalApplicationTab = new TTVisual.TTTabPage();
        this.AdditionalApplicationTab.DisplayIndex = 3;
        this.AdditionalApplicationTab.TabIndex = 2;
        this.AdditionalApplicationTab.Text = i18n("M13536", "Ek Uygulamalar");
        this.AdditionalApplicationTab.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AdditionalApplicationTab.Name = "AdditionalApplicationTab";

        this.GridAdditionalApplications = new TTVisual.TTGrid();
        this.GridAdditionalApplications.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridAdditionalApplications.Name = "GridAdditionalApplications";
        this.GridAdditionalApplications.TabIndex = 0;
       // this.GridAdditionalApplications.Height = 80;

        this.SDateTime = new TTVisual.TTDateTimePickerColumn();
        this.SDateTime.Format = DateTimePickerFormat.Custom;
        this.SDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SDateTime.DataMember = "ActionDate";
        this.SDateTime.DisplayIndex = 0;
        this.SDateTime.HeaderText = "Tarih/Saat";
        this.SDateTime.Name = "SDateTime";
        this.SDateTime.ReadOnly = true;
        this.SDateTime.Width = 150;

        this.AProcedureObject = new TTVisual.TTListBoxColumn();
        this.AProcedureObject.ListDefName = "AdditionalApplicationListDefinition";
        this.AProcedureObject.DataMember = "ProcedureObject";
        this.AProcedureObject.DisplayIndex = 1;
        this.AProcedureObject.HeaderText = i18n("M24283", "Yapılan İşlem");
        this.AProcedureObject.Name = "AProcedureObject";
        this.AProcedureObject.Width = 500;

        this.Result = new TTVisual.TTTextBoxColumn();
        this.Result.DataMember = "Result";
        this.Result.DisplayIndex = 2;
        this.Result.HeaderText = i18n("M22078", "Sonuç");
        this.Result.Name = "Result";
        this.Result.Width = 350;

        this.NurseNotes = new TTVisual.TTTextBoxColumn();
        this.NurseNotes.DataMember = "NurseNotes";
        this.NurseNotes.DisplayIndex = 3;
        this.NurseNotes.HeaderText = i18n("M13186", "Doktor Notu");
        this.NurseNotes.Name = "NurseNotes";
        this.NurseNotes.Width = 250;

        this.DirectPurchase = new TTVisual.TTTabPage();
        this.DirectPurchase.DisplayIndex = 4;
        this.DirectPurchase.TabIndex = 3;
        this.DirectPurchase.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.DirectPurchase.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DirectPurchase.Name = "DirectPurchase";

        this.DirectPurchaseGrids = new TTVisual.TTGrid();
        this.DirectPurchaseGrids.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DirectPurchaseGrids.Name = "DirectPurchaseGrids";
        this.DirectPurchaseGrids.TabIndex = 124;

        this.MaterialDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.MaterialDirectPurchaseGrid.ListDefName = "MaterialListDefinition";
        this.MaterialDirectPurchaseGrid.DataMember = "Material";
        this.MaterialDirectPurchaseGrid.DisplayIndex = 0;
        this.MaterialDirectPurchaseGrid.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialDirectPurchaseGrid.Name = "MaterialDirectPurchaseGrid";
        this.MaterialDirectPurchaseGrid.Width = 900;

        this.AmountDirectPurchaseGrid = new TTVisual.TTTextBoxColumn();
        this.AmountDirectPurchaseGrid.DataMember = "Amount";
        this.AmountDirectPurchaseGrid.DisplayIndex = 1;
        this.AmountDirectPurchaseGrid.HeaderText = i18n("M19030", "Miktar");
        this.AmountDirectPurchaseGrid.Name = "AmountDirectPurchaseGrid";
        this.AmountDirectPurchaseGrid.Width = 100;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 1;

        this.IDEpisode = new TTVisual.TTTextBox();
        this.IDEpisode.Name = "IDEpisode";
        this.IDEpisode.TabIndex = 196;

        this.IDResource = new TTVisual.TTTextBox();
        this.IDResource.Name = "IDResource";
        this.IDResource.TabIndex = 194;

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

        this.PreInFormation = new TTVisual.TTRichTextBoxControl();
        this.PreInFormation.DisplayText = i18n("M19965", "Ön Bilgi");
        this.PreInFormation.TemplateGroupName = "Tıbbi/Cerrahi Uygulama Ön bilgi";
        this.PreInFormation.BackColor = "#F4F7FC";
        this.PreInFormation.Name = "PreInFormation";
        this.PreInFormation.TabIndex = 3;
        this.PreInFormation.ReadOnly = true;

        this.ProcedureRapor = new TTVisual.TTRichTextBoxControl();
        this.ProcedureRapor.DisplayText = i18n("M20550", "Prosedür Raporu");
        this.ProcedureRapor.TemplateGroupName = "Tıbbi/Cerrahi Uygulama Teknisyen Raporu";
        this.ProcedureRapor.BackColor = "#DCDCDC";
        this.ProcedureRapor.Name = "ProcedureRapor";
        this.ProcedureRapor.TabIndex = 4;

        this.Technician = new TTVisual.TTObjectListBox();
        this.Technician.ListFilterExpression = "USERTYPE= 3";
        this.Technician.ListDefName = "UserListDefinition";
        this.Technician.Name = "Technician";
        this.Technician.TabIndex = 2;

        this.lblSorumluDoktor = new TTVisual.TTLabel();
        this.lblSorumluDoktor.Text = i18n("M22142", "Sorumlu Doktor");
        this.lblSorumluDoktor.Name = "lblSorumluDoktor";
        this.lblSorumluDoktor.TabIndex = 187;

        this.SorumluDoktor = new TTVisual.TTObjectListBox();
        this.SorumluDoktor.Required = true;
        this.SorumluDoktor.ListDefName = "SpecialistDoctorListDefinition";
        this.SorumluDoktor.Name = "SorumluDoktor";
        this.SorumluDoktor.TabIndex = 2;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 6;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisListDefinition";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = i18n("M22736", "Tanı");
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 275;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnosisType.DataMember = "DiagnosisType";
        this.EpisodeDiagnosisType.DisplayIndex = 2;
        this.EpisodeDiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.EpisodeDiagnosisType.Name = "EpisodeDiagnosisType";
        this.EpisodeDiagnosisType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 75;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.labelResponsiblePersonnel = new TTVisual.TTLabel();
        this.labelResponsiblePersonnel.Text = i18n("M22157", "Sorumlu Personel");
        this.labelResponsiblePersonnel.Name = "labelResponsiblePersonnel";
        this.labelResponsiblePersonnel.TabIndex = 191;

        this.ResponsiblePersonnel = new TTVisual.TTObjectListBox();
        this.ResponsiblePersonnel.ListDefName = "UserListDefinition";
        this.ResponsiblePersonnel.Name = "ResponsiblePersonnel";
        this.ResponsiblePersonnel.TabIndex = 190;

        this.DoctorRapor = new TTVisual.TTRichTextBoxControl();
        this.DoctorRapor.DisplayText = "Rapor";
        this.DoctorRapor.TemplateGroupName = "Tıbbi/Cerrahi Uygulama Raporu";
        this.DoctorRapor.BackColor = "#DCDCDC";
        this.DoctorRapor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DoctorRapor.Name = "DoctorRapor";
        this.DoctorRapor.TabIndex = 4;

        this.GridReturnReasons = new TTVisual.TTGrid();
        this.GridReturnReasons.Name = "GridReturnReasons";
        this.GridReturnReasons.TabIndex = 5;
        this.GridReturnReasons.AllowUserToAddRows = false;
        this.GridReturnReasons.AllowUserToDeleteRows = false;

        this.ReturnDate = new TTVisual.TTDateTimePickerColumn();
        this.ReturnDate.DataMember = "ReturnDate";
        this.ReturnDate.DisplayIndex = 0;
        this.ReturnDate.HeaderText = i18n("M16079", "İade Zamanı");
        this.ReturnDate.Name = "ReturnDate";
        this.ReturnDate.ReadOnly = true;
        this.ReturnDate.Width = 150;

        this.ReturnReason = new TTVisual.TTTextBoxColumn();
        this.ReturnReason.DataMember = "ReturnReason";
        this.ReturnReason.DisplayIndex = 1;
        this.ReturnReason.HeaderText = i18n("M16071", "İade Sebebi");
        this.ReturnReason.Name = "ReturnReason";
        this.ReturnReason.ReadOnly = true;
        this.ReturnReason.Width = 900;

        this.ReasonOfCancel = new TTVisual.TTTextBox();
        this.ReasonOfCancel.Multiline = true;
        this.ReasonOfCancel.BackColor = "#F0F0F0";
        this.ReasonOfCancel.ReadOnly = true;
        this.ReasonOfCancel.Name = "ReasonOfCancel";
        this.ReasonOfCancel.TabIndex = 22;

        this.GridManipulationsColumns = [this.ManipulationActionDate, this.ProcedureObject, this.Emergency, this.Department, this.Description, this.AyniFarkliKesi, this.SagSol, this.Birim, this.DrAnesteziTescilNo, this.EuroScore, this.Sonuc, this.RaporTakipNo, this.OzelDurum, this.CokluOzelDurum];
        this.GridPersonnelColumns = [this.Personnel];
        this.GridTreatmentMaterialsColumns = [this.MaterialActionDate, this.Material, this.Barcode, this.DistributionType, this.Amount, this.Notes];
        this.GridAdditionalApplicationsColumns = [this.SDateTime, this.AProcedureObject, this.Result, this.NurseNotes];
        this.DirectPurchaseGridsColumns = [this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridReturnReasonsColumns = [this.ReturnDate, this.ReturnReason];
        this.TabSubaction.Controls = [this.ManiplasyonTab, this.PersonnelTab, this.TreatmentMaterial, this.AdditionalApplicationTab, this.DirectPurchase];
        this.ManiplasyonTab.Controls = [this.GridManipulations];
        this.PersonnelTab.Controls = [this.GridPersonnel];
        this.TreatmentMaterial.Controls = [this.GridTreatmentMaterials];
        this.AdditionalApplicationTab.Controls = [this.GridAdditionalApplications];
        this.DirectPurchase.Controls = [this.DirectPurchaseGrids];
        this.Controls = [this.ResponsibleUserLabel, this.TabSubaction, this.ManiplasyonTab, this.GridManipulations, this.ManipulationActionDate, this.ProcedureObject, this.Emergency, this.Department, this.Description, this.AyniFarkliKesi, this.DrAnesteziTescilNo, this.EuroScore, this.SagSol, this.Birim, this.Sonuc, this.RaporTakipNo, this.OzelDurum, this.CokluOzelDurum, this.PersonnelTab, this.GridPersonnel, this.Personnel, this.TreatmentMaterial, this.GridTreatmentMaterials, this.MaterialActionDate, this.Material, this.Barcode, this.DistributionType, this.Amount, this.Notes, this.AdditionalApplicationTab, this.GridAdditionalApplications, this.SDateTime, this.AProcedureObject, this.Result, this.NurseNotes, this.DirectPurchase, this.DirectPurchaseGrids, this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid, this.ProtocolNo, this.IDEpisode, this.IDResource, this.labelProtocolNo, this.ActionDate, this.labelProcessTime, this.PreInFormation, this.ProcedureRapor, this.Technician, this.lblSorumluDoktor, this.SorumluDoktor, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.labelResponsiblePersonnel, this.ResponsiblePersonnel, this.DoctorRapor, this.GridReturnReasons, this.ReturnDate, this.ReturnReason, this.ReasonOfCancel];

    }


}
