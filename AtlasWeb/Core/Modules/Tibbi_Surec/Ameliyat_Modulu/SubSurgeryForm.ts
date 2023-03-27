//$373991B1
import { Component, OnInit, ApplicationRef, NgZone, ViewChild } from '@angular/core';
import { SubSurgeryFormViewModel } from './SubSurgeryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { SubSurgery } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryExpend } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { SurgeryProcedureFormViewModel, GetNewViewModelByProcedureObject } from './SurgeryProcedureFormViewModel';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { HvlDataGrid } from 'app/Fw/Components/HvlDataGrid';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { HelpMenuService } from 'app/Fw/Services/HelpMenuService';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { ClickFunctionParams, ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'SubSurgeryForm',
    templateUrl: './SubSurgeryForm.html',
    providers: [MessageService]
})
export class SubSurgeryForm extends EpisodeActionForm implements OnInit {
    Ameliyat: TTVisual.ITTTabControl;
    AmountDirectPurchaseGrid: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    CAAmount: TTVisual.ITTTextBoxColumn;
    CAMaterial: TTVisual.ITTListBoxColumn;
    CARole: TTVisual.ITTEnumComboBoxColumn;
    CMActionDate: TTVisual.ITTDateTimePickerColumn;
    DescriptionToPreOp: TTVisual.ITTRichTextBoxControl;
    DirectPurchase: TTVisual.ITTTabPage;
    DirectPurchaseGrids: TTVisual.ITTGrid;
    DistributionType: TTVisual.ITTTextBoxColumn;
    Emergency: TTVisual.ITTCheckBox;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridSurgeryExpends: TTVisual.ITTGrid;
    GridSurgeryPersonnels: TTVisual.ITTGrid;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelRequestDate: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    labelSurgeryDesk: TTVisual.ITTLabel;
    labelSurgeryShift: TTVisual.ITTLabel;
    labelSurgeryPointGroup: TTVisual.ITTLabel;
    labelSurgeryStartTime: TTVisual.ITTLabel;
    labelSurgeryStatus: TTVisual.ITTLabel;
    lebalReasonOfCancel: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    MaterialDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    PlannedSurgeryDate: TTVisual.ITTDateTimePicker;
    PreOpDescriptions: TTVisual.ITTRichTextBoxControl;
    PreOperativeInfo: TTVisual.ITTTabPage;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    ReasonOfCancel: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    SubSurgeryReport: TTVisual.ITTRichTextBoxControl;
    SurgeryDesk: TTVisual.ITTObjectListBox;
    SurgeryEndTime: TTVisual.ITTDateTimePicker;
    SurgeryExpend: TTVisual.ITTTabPage;
    SurgeryInfo: TTVisual.ITTTabPage;
    SurgeryPersonnel: TTVisual.ITTListBoxColumn;
    SurgeryReportDate: TTVisual.ITTDateTimePicker;
    SurgeryRoom: TTVisual.ITTObjectListBox;
    SurgeryShift: TTVisual.ITTEnumComboBox;
    SurgeryPointGroup: TTVisual.ITTEnumComboBox;
    SurgeryStartTime: TTVisual.ITTDateTimePicker;
    SurgeryStatus: TTVisual.ITTEnumComboBox;
    TabOperative: TTVisual.ITTTabControl;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    UBBCODE: TTVisual.ITTTextBoxColumn;
    SelectedSurgeryProcedure: TTVisual.ITTObjectListBox;
    PlannedSurgeryDescription: TTVisual.ITTTextBox;
    public DirectPurchaseGridsColumns = [];
    public GridEpisodeDiagnosisColumns = [];
    public GridSurgeryExpendsColumns = [];
    public GridSurgeryPersonnelsColumns = [];
    public subSurgeryFormViewModel: SubSurgeryFormViewModel = new SubSurgeryFormViewModel();
    @ViewChild('gridSurgeryPersonnels') gridSurgeryPersonnels: HvlDataGrid;
    public get _SubSurgery(): SubSurgery {
        return this._TTObject as SubSurgery;
    }
    public ComfirmAddRowByPersonelFilterSelectionFunc: Function;
    private SubSurgeryForm_DocumentUrl: string = '/api/SubSurgeryService/SubSurgeryForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        private detector: ApplicationRef,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this.ComfirmAddRowByPersonelFilterSelectionFunc = this.comfirmAddRowByPersonelFilterSelection.bind(this);
        this._DocumentServiceUrl = this.SubSurgeryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.hasRequestedProceduresForm = true;

        this.SelectedSurgeryProcedure.ReadOnly = this.ReadOnly;
        this.GridSurgeryPersonnels.ShowFilterCombo = !this.ReadOnly;
        this.GridSurgeryPersonnels.AllowUserToDeleteRows = !this.ReadOnly;
        this.DirectPurchaseGrids.ShowFilterCombo = !this.ReadOnly;
        this.DirectPurchaseGrids.AllowUserToDeleteRows = !this.ReadOnly;
        if (this._SubSurgery.SurgeryShift == null && this._SubSurgery.Surgery.SurgeryShift != null)
            this._SubSurgery.SurgeryShift = this._SubSurgery.Surgery.SurgeryShift;
        if (this._SubSurgery.SurgeryPointGroup == null && this._SubSurgery.Surgery.SurgeryPointGroup != null)
            this._SubSurgery.SurgeryPointGroup = this._SubSurgery.Surgery.SurgeryPointGroup;
        if (this._SubSurgery.SurgeryStatus == null && this._SubSurgery.Surgery.SurgeryStatus != null)
            this._SubSurgery.SurgeryStatus = this._SubSurgery.Surgery.SurgeryStatus;

        
        if (this.subSurgeryFormViewModel.IsRequiredPathology == true) {
            TTVisual.InfoBox.Alert("Patoloji isteği gerektiren ameliyat hizmetiniz mevcut! Ameliyatın tamamlanması için lütfen ekranı önce 'Patoloji isteği' yapınız!");
        }
    }

    private AddHelpMenu() {

        let pathologyRequest = new DynamicSidebarMenuItem();
        pathologyRequest.key = 'pathologyRequest';
        pathologyRequest.icon = 'ai ai-chemical';
        pathologyRequest.label = i18n("M20230", "Patoloji İstek");
        pathologyRequest.componentInstance = this.helpMenuService;
        pathologyRequest.clickFunction = this.helpMenuService.onPathologyRequest;
        pathologyRequest.parameterFunctionInstance = this;
        pathologyRequest.getParamsFunction = this.getClickFunctionParams;
        pathologyRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', pathologyRequest);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('pathologyRequest');
    }

    // *****Method declarations end *****

    onSelectedSurgeryProcedureChanged(surgeryDefinition: any) {
        let that = this;
        let surgeryProcedureForm_DocumentUrl: string = '/api/SurgeryProcedureService/GetNewViewModelByProcedureObject';
        if (surgeryDefinition != null) {
            let getNewViewModelByProcedureObjectParameter: GetNewViewModelByProcedureObject = new GetNewViewModelByProcedureObject();
            getNewViewModelByProcedureObjectParameter.episodeAction = this._SubSurgery;
            getNewViewModelByProcedureObjectParameter.surgeryDefinition = surgeryDefinition.ObjectID;

            that.httpService.post<SurgeryProcedureFormViewModel>(surgeryProcedureForm_DocumentUrl, getNewViewModelByProcedureObjectParameter).then(newSurgeryProcedureFormViewModel => {
                if (newSurgeryProcedureFormViewModel != null) {
                    if (newSurgeryProcedureFormViewModel._SurgeryProcedure != null && newSurgeryProcedureFormViewModel._SurgeryProcedure.ProcedureObject != null)
                        that.subSurgeryFormViewModel.SurgeryProcedureFormViewModelList.unshift(newSurgeryProcedureFormViewModel);

                    if (newSurgeryProcedureFormViewModel.IsRequiredPathology == true) {
                        if (typeof that._SubSurgery.Episode === "string") {
                            that.helpMenuService.onPathologyRequest(new ClickFunctionParams(that, new ActiveIDsModel(that._EpisodeAction.ObjectID, that._SubSurgery.Episode, null)));
                        } else {
                            that.helpMenuService.onPathologyRequest(new ClickFunctionParams(that, new ActiveIDsModel(that._EpisodeAction.ObjectID, that._SubSurgery.Episode.ObjectID, null)));
                        }
                        that.subSurgeryFormViewModel.IsRequiredPathology = true;
                    }
                }
            });
        }
        window.setTimeout(t => {
            if (this.subSurgeryFormViewModel._selectedSurgeryProcedure === null)
                this.subSurgeryFormViewModel._selectedSurgeryProcedure = undefined;
            else
                this.subSurgeryFormViewModel._selectedSurgeryProcedure = null;
            that.detector.tick();
        }, 0);
    }

    public comfirmAddRowByPersonelFilterSelection(event) {
        if (event != null) {
            if (event.ObjectID) {
                if (this.subSurgeryFormViewModel._SubSurgery.Surgery.AllSurgeryPersonnels.findIndex(dr => dr.Personnel != null && dr.Personnel.ObjectID == event.ObjectID) != -1) {
                    this.messageService.showError("Bu personel zaten ekli");
                    return false;
                }
                let that = this;
                let tempData = event;
                CommonService.PersonelIzinKontrol(event.ObjectID, that._SubSurgery.Surgery.SurgeryStartTime).then(a => {
                    if (a) {
                        this.messageService.showInfo(event.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            // alert("iso")
                        }, 500);
                    }
                    else {
                        that.gridSurgeryPersonnels.gridInstance.instance.addRow()
                        that.gridSurgeryPersonnels.gridInstance.instance.saveEditData();
                    }


                });
                return false;
                // let a = await CommonService.PersonelIzinKontrol(this._SubSurgery.ProcedureDoctor.ObjectID, this._SubSurgery.Surgery.SurgeryStartTime);
                // if (a) {
                //     this.messageService.showInfo(this._SubSurgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                //     setTimeout(() => {
                //         this._SubSurgery.ProcedureDoctor = null;
                //     }, 500);

                // }
            }
        }
        else
            return true;
    }

    public initViewModel(): void {
        this._TTObject = new SubSurgery();
        this.subSurgeryFormViewModel = new SubSurgeryFormViewModel();
        this._ViewModel = this.subSurgeryFormViewModel;
        this.subSurgeryFormViewModel._SubSurgery = this._TTObject as SubSurgery;

        this.subSurgeryFormViewModel._SubSurgery.Surgery = new Surgery();
        this.subSurgeryFormViewModel._SubSurgery.Surgery.AllSurgeryPersonnels = new Array<SurgeryPersonnel>();
        this.subSurgeryFormViewModel._SubSurgery.Surgery.SurgeryRoom = new ResSurgeryRoom();
        this.subSurgeryFormViewModel._SubSurgery.Surgery.MasterResource = new ResSection();
        this.subSurgeryFormViewModel._SubSurgery.Surgery.SurgeryDesk = new ResSurgeryDesk();
        this.subSurgeryFormViewModel._SubSurgery.SubSurgeryExpends = new Array<SurgeryExpend>();
        this.subSurgeryFormViewModel._SubSurgery.DirectPurchaseGrids = new Array<DirectPurchaseGrid>();
        this.subSurgeryFormViewModel._SubSurgery.Episode = new Episode();
        this.subSurgeryFormViewModel._SubSurgery.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.subSurgeryFormViewModel._SubSurgery.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.subSurgeryFormViewModel = this._ViewModel as SubSurgeryFormViewModel;
        that._TTObject = this.subSurgeryFormViewModel._SubSurgery;
        if (this.subSurgeryFormViewModel == null)
            this.subSurgeryFormViewModel = new SubSurgeryFormViewModel();
        if (this.subSurgeryFormViewModel._SubSurgery == null)
            this.subSurgeryFormViewModel._SubSurgery = new SubSurgery();
        let surgeryObjectID = that.subSurgeryFormViewModel._SubSurgery["Surgery"];
        if (surgeryObjectID != null && (typeof surgeryObjectID === "string")) {
            let surgery = that.subSurgeryFormViewModel.Surgerys.find(o => o.ObjectID.toString() === surgeryObjectID.toString());
            if (surgery) {
                that.subSurgeryFormViewModel._SubSurgery.Surgery = surgery;
            }
            if (surgery != null) {
                surgery.AllSurgeryPersonnels = that.subSurgeryFormViewModel.GridSurgeryPersonnelsGridList;
                for (let detailItem of that.subSurgeryFormViewModel.GridSurgeryPersonnelsGridList) {
                    let personnelObjectID = detailItem["Personnel"];
                    if (personnelObjectID != null && (typeof personnelObjectID === "string")) {
                        let personnel = that.subSurgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === personnelObjectID.toString());
                        if (personnel) {
                            detailItem.Personnel = personnel;
                        }
                    }
                }
            }
            if (surgery != null) {
                let surgeryRoomObjectID = surgery["SurgeryRoom"];
                if (surgeryRoomObjectID != null && (typeof surgeryRoomObjectID === "string")) {
                    let surgeryRoom = that.subSurgeryFormViewModel.ResSurgeryRooms.find(o => o.ObjectID.toString() === surgeryRoomObjectID.toString());
                    if (surgeryRoom) {
                        surgery.SurgeryRoom = surgeryRoom;
                    }
                }
            }
            if (surgery != null) {
                let masterResourceObjectID = surgery["MasterResource"];
                if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
                    let masterResource = that.subSurgeryFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                    if (masterResource) {
                        surgery.MasterResource = masterResource;
                    }
                }
            }
            if (surgery != null) {
                let surgeryDeskObjectID = surgery["SurgeryDesk"];
                if (surgeryDeskObjectID != null && (typeof surgeryDeskObjectID === "string")) {
                    let surgeryDesk = that.subSurgeryFormViewModel.ResSurgeryDesks.find(o => o.ObjectID.toString() === surgeryDeskObjectID.toString());
                    if (surgeryDesk) {
                        surgery.SurgeryDesk = surgeryDesk;
                    }
                }
            }
        }
        that.subSurgeryFormViewModel._SubSurgery.SubSurgeryExpends = that.subSurgeryFormViewModel.GridSurgeryExpendsGridList;
        for (let detailItem of that.subSurgeryFormViewModel.GridSurgeryExpendsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.subSurgeryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.subSurgeryFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.subSurgeryFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.subSurgeryFormViewModel._SubSurgery.DirectPurchaseGrids = that.subSurgeryFormViewModel.DirectPurchaseGridsGridList;
        for (let detailItem of that.subSurgeryFormViewModel.DirectPurchaseGridsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.subSurgeryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }
        let episodeObjectID = that.subSurgeryFormViewModel._SubSurgery["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.subSurgeryFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.subSurgeryFormViewModel._SubSurgery.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.subSurgeryFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.subSurgeryFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.subSurgeryFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.subSurgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let procedureDoctorObjectID = that.subSurgeryFormViewModel._SubSurgery["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.subSurgeryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.subSurgeryFormViewModel._SubSurgery.ProcedureDoctor = procedureDoctor;
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(SubSurgeryFormViewModel);
        this.AddHelpMenu();
    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);

        await this.load(SubSurgeryFormViewModel);
    }

    public onDescriptionToPreOpChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.DescriptionToPreOp != event) {
                this._SubSurgery.Surgery.DescriptionToPreOp = event;
            }
        }
    }

    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.Emergency != event) {
                this._SubSurgery.Surgery.Emergency = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.MasterResource != event) {
                this._SubSurgery.Surgery.MasterResource = event;
            }
        }
    }

    public onPlannedSurgeryDateChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.PlannedSurgeryDate != event) {
                this._SubSurgery.Surgery.PlannedSurgeryDate = event;
            }
        }
    }

    public onPreOpDescriptionsChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.PreOpDescriptions != event) {
                this._SubSurgery.Surgery.PreOpDescriptions = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._SubSurgery != null && this._SubSurgery.ProcedureDoctor != event) {
                this._SubSurgery.ProcedureDoctor = event;

                let a = await CommonService.PersonelIzinKontrol(this._SubSurgery.ProcedureDoctor.ObjectID, this._SubSurgery.Surgery.SurgeryStartTime);
                if (a) {
                    this.messageService.showInfo(this._SubSurgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._SubSurgery.ProcedureDoctor = null;
                    }, 500);

                }

            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.ProtocolNo != event) {
                this._SubSurgery.Surgery.ProtocolNo = event;
            }
        }
    }

    public onReasonOfCancelChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null && this._SubSurgery.ReasonOfCancel != event) {
                this._SubSurgery.ReasonOfCancel = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.RequestDate != event) {
                this._SubSurgery.Surgery.RequestDate = event;
            }
        }
    }

    public onSubSurgeryReportChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null && this._SubSurgery.SurgeryReport != event) {
                this._SubSurgery.SurgeryReport = event;
            }
        }
    }

    public onSurgeryDeskChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.SurgeryDesk != event) {
                this._SubSurgery.Surgery.SurgeryDesk = event;
            }
        }
    }

    public onSurgeryEndTimeChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.SurgeryEndTime != event) {
                this._SubSurgery.Surgery.SurgeryEndTime = event;
            }
        }
    }

    public onSurgeryReportDateChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null && this._SubSurgery.SurgeryReportDate != event) {
                this._SubSurgery.SurgeryReportDate = event;
            }
        }
    }

    public onSurgeryRoomChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.SurgeryRoom != event) {
                this._SubSurgery.Surgery.SurgeryRoom = event;
            }
        }
    }
    public onSurgeryShiftChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null && this._SubSurgery.SurgeryShift != event) {
                this._SubSurgery.SurgeryShift = event;
            }
        }
    }
    public onSurgeryPointGroupChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null && this._SubSurgery.SurgeryPointGroup != event) {
                this._SubSurgery.SurgeryPointGroup = event;
            }
        }
    }
    public async onSurgeryStartTimeChanged(event) {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.SurgeryStartTime != event) {
                this._SubSurgery.Surgery.SurgeryStartTime = event;

                if (this._SubSurgery.ProcedureDoctor != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._SubSurgery.ProcedureDoctor.ObjectID, this._SubSurgery.Surgery.SurgeryStartTime);
                    if (a) {
                        this.messageService.showInfo(this._SubSurgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._SubSurgery.ProcedureDoctor = null;
                        }, 500);

                    }
                }
            }
        }
    }

    public onSurgeryStatusChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null && this._SubSurgery.SurgeryStatus != event) {
                this._SubSurgery.SurgeryStatus = event;
            }
        }
    }

    public onPlannedSurgeryDescriptionChanged(event): void {
        if (event != null) {
            if (this._SubSurgery != null &&
                this._SubSurgery.Surgery != null && this._SubSurgery.Surgery.PlannedSurgeryDescription != event) {
                this._SubSurgery.Surgery.PlannedSurgeryDescription = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "Surgery.RequestDate");
        redirectProperty(this.PlannedSurgeryDate, "Value", this.__ttObject, "Surgery.PlannedSurgeryDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "Surgery.ProtocolNo");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Surgery.Emergency");
        redirectProperty(this.SurgeryStartTime, "Value", this.__ttObject, "Surgery.SurgeryStartTime");
        redirectProperty(this.SurgeryEndTime, "Value", this.__ttObject, "Surgery.SurgeryEndTime");
        redirectProperty(this.PlannedSurgeryDescription, "Text", this.__ttObject, "PlannedSurgeryDescription");
        redirectProperty(this.SurgeryReportDate, "Value", this.__ttObject, "SurgeryReportDate");
        redirectProperty(this.SubSurgeryReport, "Rtf", this.__ttObject, "SurgeryReport");
        redirectProperty(this.DescriptionToPreOp, "Rtf", this.__ttObject, "Surgery.DescriptionToPreOp");
        redirectProperty(this.PreOpDescriptions, "Rtf", this.__ttObject, "Surgery.PreOpDescriptions");
        redirectProperty(this.ReasonOfCancel, "Text", this.__ttObject, "ReasonOfCancel");
        redirectProperty(this.SurgeryShift, "Value", this.__ttObject, "SurgeryShift");
        redirectProperty(this.SurgeryPointGroup, "Value", this.__ttObject, "SurgeryPointGroup");
        redirectProperty(this.SurgeryStatus, "Value", this.__ttObject, "SurgeryStatus");
    }

    public initFormControls(): void {

        this.labelSurgeryStatus = new TTVisual.TTLabel();
        this.labelSurgeryStatus.Text = "Ameliyat Durumu";
        this.labelSurgeryStatus.Name = "labelSurgeryStatus";
        this.labelSurgeryStatus.TabIndex = 125;

        this.SurgeryStatus = new TTVisual.TTEnumComboBox();
        this.SurgeryStatus.DataTypeName = "SurgeryStatusEnum";
        this.SurgeryStatus.Name = "SurgeryStatus";
        this.SurgeryStatus.TabIndex = 124;

        this.labelSurgeryShift = new TTVisual.TTLabel();
        this.labelSurgeryShift.Text = "Mesai Durumu";
        this.labelSurgeryShift.Name = "labelSurgeryShift";
        this.labelSurgeryShift.TabIndex = 123;

        this.SurgeryShift = new TTVisual.TTEnumComboBox();
        this.SurgeryShift.DataTypeName = "SurgeryShiftEnum";
        this.SurgeryShift.Name = "SurgeryShift";
        this.SurgeryShift.TabIndex = 122;

        this.labelSurgeryPointGroup = new TTVisual.TTLabel();
        this.labelSurgeryPointGroup.Text = "Ameliyat Tipi";
        this.labelSurgeryPointGroup.Name = "labelSurgeryPointGroup";
        this.labelSurgeryPointGroup.TabIndex = 123;

        this.SurgeryPointGroup = new TTVisual.TTEnumComboBox();
        this.SurgeryPointGroup.DataTypeName = "SurgeryPointGroupEnum";
        this.SurgeryPointGroup.Name = "SurgeryPointGroup";
        this.SurgeryPointGroup.TabIndex = 122;

        this.SelectedSurgeryProcedure = new TTVisual.TTObjectListBox();
        this.SelectedSurgeryProcedure.ListDefName = "SurgeryListDefinition";
        this.SelectedSurgeryProcedure.Name = "SelectedSurgeryProcedure";
        this.SelectedSurgeryProcedure.AutoCompleteDialogWidth = "40%";
        this.SelectedSurgeryProcedure.AutoCompleteDialogHeight = "50%";
        this.SelectedSurgeryProcedure.ReadOnly = this.ReadOnly;

        this.GridSurgeryPersonnels = new TTVisual.TTGrid();
        this.GridSurgeryPersonnels.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridSurgeryPersonnels.Name = "GridSurgeryPersonnels";
        this.GridSurgeryPersonnels.TabIndex = 0;
        this.GridSurgeryPersonnels.Height = 120;
        this.GridSurgeryPersonnels.ShowFilterCombo = !this.ReadOnly;
        this.GridSurgeryPersonnels.FilterColumnName = "SurgeryPersonnel";
        this.GridSurgeryPersonnels.FilterLabel = i18n("M12206", "Cerrahi Ekip");
        this.GridSurgeryPersonnels.Filter = { ListDefName: "SurgeryTeamListDefinition" };
        this.GridSurgeryPersonnels.AllowUserToAddRows = false;
        this.GridSurgeryPersonnels.AllowUserToDeleteRows = !this.ReadOnly;
        this.GridSurgeryPersonnels.DeleteButtonWidth = "5%";
        this.GridSurgeryPersonnels.ShowTotalNumberOfRows = false;
        this.GridSurgeryPersonnels.IsFilterLabelSingleLine = false;

        this.SurgeryPersonnel = new TTVisual.TTListBoxColumn();
        this.SurgeryPersonnel.ListDefName = "SurgeryTeamListDefinition";
        this.SurgeryPersonnel.DataMember = "Personnel";
        this.SurgeryPersonnel.DisplayIndex = 0;
        this.SurgeryPersonnel.HeaderText = "Personel";
        this.SurgeryPersonnel.Name = "SurgeryPersonnel";
        this.SurgeryPersonnel.Width = "65%";

        this.CARole = new TTVisual.TTEnumComboBoxColumn();
        this.CARole.DataTypeName = "SurgeryRoleEnum";
        this.CARole.DataMember = "Role";
        this.CARole.DisplayIndex = 1;
        this.CARole.HeaderText = "Görevi";
        this.CARole.Name = "CARole";
        this.CARole.Width = "25%";

        this.Ameliyat = new TTVisual.TTTabControl();
        this.Ameliyat.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Ameliyat.Name = "Ameliyat";
        this.Ameliyat.TabIndex = 10;

        this.SurgeryExpend = new TTVisual.TTTabPage();
        this.SurgeryExpend.DisplayIndex = 0;
        this.SurgeryExpend.BackColor = "#FFFFFF";
        this.SurgeryExpend.TabIndex = 0;
        this.SurgeryExpend.Text = i18n("M12207", "Cerrahi Sarf");
        this.SurgeryExpend.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryExpend.Name = "SurgeryExpend";

        this.GridSurgeryExpends = new TTVisual.TTGrid();
        this.GridSurgeryExpends.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridSurgeryExpends.ReadOnly = true;
        this.GridSurgeryExpends.Name = "GridSurgeryExpends";
        this.GridSurgeryExpends.TabIndex = 0;

        this.CMActionDate = new TTVisual.TTDateTimePickerColumn();
        this.CMActionDate.Format = DateTimePickerFormat.Custom;
        this.CMActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.CMActionDate.DataMember = "ActionDate";
        this.CMActionDate.DisplayIndex = 0;
        this.CMActionDate.HeaderText = "Tarih/Saat";
        this.CMActionDate.Name = "CMActionDate";
        this.CMActionDate.Width = 180;

        this.CAMaterial = new TTVisual.TTListBoxColumn();
        this.CAMaterial.ListDefName = "TreatmentMaterialListDefinition";
        this.CAMaterial.DataMember = "Material";
        this.CAMaterial.DisplayIndex = 1;
        this.CAMaterial.HeaderText = i18n("M12207", "Cerrahi Sarf");
        this.CAMaterial.Name = "CAMaterial";
        this.CAMaterial.Width = 450;

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

        this.CAAmount = new TTVisual.TTTextBoxColumn();
        this.CAAmount.DataMember = "Amount";
        this.CAAmount.DisplayIndex = 4;
        this.CAAmount.HeaderText = i18n("M19030", "Miktar");
        this.CAAmount.Name = "CAAmount";
        this.CAAmount.Width = 75;

        this.UBBCODE = new TTVisual.TTTextBoxColumn();
        this.UBBCODE.DataMember = "UBBCode";
        this.UBBCODE.DisplayIndex = 5;
        this.UBBCODE.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCODE.Name = "UBBCODE";
        this.UBBCODE.Width = 100;

        this.DirectPurchase = new TTVisual.TTTabPage();
        this.DirectPurchase.DisplayIndex = 1;
        this.DirectPurchase.TabIndex = 2;
        this.DirectPurchase.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.DirectPurchase.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DirectPurchase.Name = "DirectPurchase";

        this.DirectPurchaseGrids = new TTVisual.TTGrid();
        this.DirectPurchaseGrids.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DirectPurchaseGrids.Name = "DirectPurchaseGrids";
        this.DirectPurchaseGrids.TabIndex = 124;
        this.DirectPurchaseGrids.ShowFilterCombo = !this.ReadOnly;
        this.DirectPurchaseGrids.FilterColumnName = "MaterialDirectPurchaseGrid";
        this.DirectPurchaseGrids.FilterLabel = i18n("M18545", "Malzeme");
        this.DirectPurchaseGrids.Filter = { ListDefName: "MaterialListDefinition" };
        this.DirectPurchaseGrids.AllowUserToAddRows = false;
        this.DirectPurchaseGrids.AllowUserToDeleteRows = !this.ReadOnly;
        this.DirectPurchaseGrids.DeleteButtonWidth = "5%";
        this.DirectPurchaseGrids.ShowTotalNumberOfRows = false;
        this.DirectPurchaseGrids.IsFilterLabelSingleLine = false;
        this.DirectPurchaseGrids.ReadOnly = this.ReadOnly;



        this.MaterialDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.MaterialDirectPurchaseGrid.ListDefName = "MaterialListDefinition";
        this.MaterialDirectPurchaseGrid.DataMember = "Material";
        this.MaterialDirectPurchaseGrid.DisplayIndex = 0;
        this.MaterialDirectPurchaseGrid.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialDirectPurchaseGrid.Name = "MaterialDirectPurchaseGrid";
        this.MaterialDirectPurchaseGrid.Width = "75%";
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogWidth = '75%x';


        this.AmountDirectPurchaseGrid = new TTVisual.TTTextBoxColumn();
        this.AmountDirectPurchaseGrid.DataMember = "Amount";
        this.AmountDirectPurchaseGrid.DisplayIndex = 1;
        this.AmountDirectPurchaseGrid.HeaderText = i18n("M19030", "Miktar");
        this.AmountDirectPurchaseGrid.Name = "AmountDirectPurchaseGrid";
        this.AmountDirectPurchaseGrid.Width = "10%";

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 3;

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
        this.EpisodeDiagnose.HeaderText = i18n("M24028", "Vaka Tanıları");
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

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M22140", "Sorumlu Cerrah(1.Cerrah)");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 121;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 2;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M10816", "Ameliyat İstek Tarihi");
        this.labelRequestDate.BackColor = "#DCDCDC";
        this.labelRequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRequestDate.ForeColor = "#000000";
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 119;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M20395", "Planlanan Ameliyat Tarihi");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 117;

        this.PlannedSurgeryDate = new TTVisual.TTDateTimePicker();
        this.PlannedSurgeryDate.BackColor = "#F0F0F0";
        this.PlannedSurgeryDate.CustomFormat = "";
        this.PlannedSurgeryDate.Format = DateTimePickerFormat.Long;
        this.PlannedSurgeryDate.Enabled = false;
        this.PlannedSurgeryDate.Name = "PlannedSurgeryDate";
        this.PlannedSurgeryDate.TabIndex = 1;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M10861", "Ameliyatı Bitirme Tarih/Saat");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 100;

        this.SurgeryEndTime = new TTVisual.TTDateTimePicker();
        this.SurgeryEndTime.BackColor = "#F0F0F0";
        this.SurgeryEndTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SurgeryEndTime.Format = DateTimePickerFormat.Long;
        this.SurgeryEndTime.Enabled = false;
        this.SurgeryEndTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryEndTime.Name = "SurgeryEndTime";
        this.SurgeryEndTime.TabIndex = 8;

        this.SurgeryRoom = new TTVisual.TTObjectListBox();
        this.SurgeryRoom.LinkedControlName = "MasterResource";
        this.SurgeryRoom.ReadOnly = true;
        this.SurgeryRoom.ListDefName = "SurgeryRoomListDefinition";
        this.SurgeryRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryRoom.Name = "SurgeryRoom";
        this.SurgeryRoom.TabIndex = 5;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = "Acil";
        this.Emergency.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 89;

        this.labelSurgeryStartTime = new TTVisual.TTLabel();
        this.labelSurgeryStartTime.Text = i18n("M10859", "Ameliyatı Başlatma Tarih/Saat");
        this.labelSurgeryStartTime.BackColor = "#DCDCDC";
        this.labelSurgeryStartTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurgeryStartTime.ForeColor = "#000000";
        this.labelSurgeryStartTime.Name = "labelSurgeryStartTime";
        this.labelSurgeryStartTime.TabIndex = 92;

        this.SurgeryStartTime = new TTVisual.TTDateTimePicker();
        this.SurgeryStartTime.BackColor = "#F0F0F0";
        this.SurgeryStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SurgeryStartTime.Format = DateTimePickerFormat.Long;
        this.SurgeryStartTime.Enabled = false;
        this.SurgeryStartTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryStartTime.Name = "SurgeryStartTime";
        this.SurgeryStartTime.TabIndex = 7;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10854", "Ameliyathane");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 95;

        this.labelRoom = new TTVisual.TTLabel();
        this.labelRoom.Text = i18n("M21284", "Salon");
        this.labelRoom.BackColor = "#DCDCDC";
        this.labelRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoom.ForeColor = "#000000";
        this.labelRoom.Name = "labelRoom";
        this.labelRoom.TabIndex = 84;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 91;

        this.TabOperative = new TTVisual.TTTabControl();
        this.TabOperative.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabOperative.Name = "TabOperative";
        this.TabOperative.TabIndex = 9;

        this.SurgeryInfo = new TTVisual.TTTabPage();
        this.SurgeryInfo.DisplayIndex = 0;
        this.SurgeryInfo.BackColor = "#FFFFFF";
        this.SurgeryInfo.TabIndex = 0;
        this.SurgeryInfo.Text = i18n("M10802", "Ameliyat Bilgileri");
        this.SurgeryInfo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryInfo.Name = "SurgeryInfo";

        this.SubSurgeryReport = new TTVisual.TTRichTextBoxControl();
        this.SubSurgeryReport.DisplayText = i18n("M10837", "Ameliyat Raporu");
        this.SubSurgeryReport.TemplateGroupName = "SURGERYREPORT";
        this.SubSurgeryReport.BackColor = "#FFFFFF";
        this.SubSurgeryReport.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SubSurgeryReport.Name = "SubSurgeryReport";
        this.SubSurgeryReport.TabIndex = 94;


        this.SurgeryReportDate = new TTVisual.TTDateTimePicker();
        this.SurgeryReportDate.BackColor = "#F0F0F0";
        this.SurgeryReportDate.CustomFormat = "";
        this.SurgeryReportDate.Format = DateTimePickerFormat.Long;
        this.SurgeryReportDate.Enabled = false;
        this.SurgeryReportDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryReportDate.Name = "SurgeryReportDate";
        this.SurgeryReportDate.TabIndex = 0;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M10836", "Ameliyat Rapor Tarihi");
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 119;

        this.PreOperativeInfo = new TTVisual.TTTabPage();
        this.PreOperativeInfo.DisplayIndex = 1;
        this.PreOperativeInfo.BackColor = "#FFFFFF";
        this.PreOperativeInfo.TabIndex = 0;
        this.PreOperativeInfo.Text = i18n("M19973", "Ön Hazırlık Bilgileri");
        this.PreOperativeInfo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PreOperativeInfo.Name = "PreOperativeInfo";

        this.DescriptionToPreOp = new TTVisual.TTRichTextBoxControl();
        this.DescriptionToPreOp.DisplayText = i18n("M19974", "Ön Hazırlık İçin Direktifler");
        this.DescriptionToPreOp.BackColor = "#FFFFFF";
        this.DescriptionToPreOp.Name = "DescriptionToPreOp";
        this.DescriptionToPreOp.TabIndex = 120;

        this.PreOpDescriptions = new TTVisual.TTRichTextBoxControl();
        this.PreOpDescriptions.DisplayText = i18n("M19972", "Ön Hazırlık Açıklamaları");
        this.PreOpDescriptions.BackColor = "#FFFFFF";
        this.PreOpDescriptions.Name = "PreOpDescriptions";
        this.PreOpDescriptions.TabIndex = 118;

        this.ReasonOfCancel = new TTVisual.TTTextBox();
        this.ReasonOfCancel.Multiline = true;
        this.ReasonOfCancel.BackColor = "#F0F0F0";
        this.ReasonOfCancel.ReadOnly = true;
        this.ReasonOfCancel.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReasonOfCancel.Name = "ReasonOfCancel";
        this.ReasonOfCancel.TabIndex = 6;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.ListDefName = "SurgreyDepartmentListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 4;

        this.SurgeryDesk = new TTVisual.TTObjectListBox();
        this.SurgeryDesk.LinkedControlName = "SurgeryRoom";
        this.SurgeryDesk.ReadOnly = true;
        this.SurgeryDesk.ListDefName = "SurgeryDeskListDefinition";
        this.SurgeryDesk.Name = "SurgeryDesk";
        this.SurgeryDesk.TabIndex = 105;

        this.labelSurgeryDesk = new TTVisual.TTLabel();
        this.labelSurgeryDesk.Text = i18n("M18680", "Masa");
        this.labelSurgeryDesk.Name = "labelSurgeryDesk";
        this.labelSurgeryDesk.TabIndex = 106;

        this.lebalReasonOfCancel = new TTVisual.TTLabel();
        this.lebalReasonOfCancel.Text = i18n("M16560", "İptal Sebebi");
        this.lebalReasonOfCancel.BackColor = "#DCDCDC";
        this.lebalReasonOfCancel.ForeColor = "#000000";
        this.lebalReasonOfCancel.Name = "lebalReasonOfCancel";
        this.lebalReasonOfCancel.TabIndex = 117;

        this.PlannedSurgeryDescription = new TTVisual.TTTextBox();
        this.PlannedSurgeryDescription.Multiline = true;
        this.PlannedSurgeryDescription.BackColor = "#F0F0F0";
        this.PlannedSurgeryDescription.ReadOnly = true;
        this.PlannedSurgeryDescription.Name = "PlannedSurgeryDescription";
        this.PlannedSurgeryDescription.TabIndex = 103;

        this.GridSurgeryPersonnelsColumns = [this.SurgeryPersonnel, this.CARole];
        this.GridSurgeryExpendsColumns = [this.CMActionDate, this.CAMaterial, this.Barcode, this.DistributionType, this.CAAmount, this.UBBCODE];
        this.DirectPurchaseGridsColumns = [this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.Ameliyat.Controls = [this.SurgeryExpend, this.DirectPurchase];
        this.SurgeryExpend.Controls = [this.GridSurgeryExpends];
        this.DirectPurchase.Controls = [this.DirectPurchaseGrids];
        this.TabOperative.Controls = [this.SurgeryInfo, this.PreOperativeInfo];
        this.SurgeryInfo.Controls = [this.SubSurgeryReport, this.SurgeryReportDate, this.ttlabel3];
        this.PreOperativeInfo.Controls = [this.DescriptionToPreOp, this.PreOpDescriptions];
        this.Controls = [this.labelSurgeryStatus, this.SurgeryStatus, this.labelSurgeryShift, this.SurgeryShift, this.labelSurgeryPointGroup, this.SurgeryPointGroup, this.GridSurgeryPersonnels, this.SurgeryPersonnel, this.CARole, this.Ameliyat, this.SurgeryExpend, this.GridSurgeryExpends, this.CMActionDate, this.CAMaterial, this.Barcode, this.DistributionType, this.CAAmount, this.UBBCODE, this.DirectPurchase, this.DirectPurchaseGrids, this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid, this.ProtocolNo, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.labelProcedureDoctor, this.ProcedureDoctor, this.RequestDate, this.labelRequestDate, this.ttlabel9, this.PlannedSurgeryDate, this.ttlabel2, this.SurgeryEndTime, this.SurgeryRoom, this.Emergency, this.labelSurgeryStartTime, this.SurgeryStartTime, this.ttlabel1, this.labelRoom, this.labelProtocolNo, this.TabOperative, this.SurgeryInfo, this.SubSurgeryReport, this.SurgeryReportDate, this.ttlabel3, this.PreOperativeInfo, this.DescriptionToPreOp, this.PreOpDescriptions, this.ReasonOfCancel, this.MasterResource, this.SurgeryDesk, this.labelSurgeryDesk, this.lebalReasonOfCancel, this.PlannedSurgeryDescription, this.MasterResource, this.PlannedSurgeryDescription];

    }


}
