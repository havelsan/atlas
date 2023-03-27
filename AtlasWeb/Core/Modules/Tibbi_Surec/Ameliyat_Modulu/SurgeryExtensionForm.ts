//$6B393D67
import { Component, OnInit, NgZone, OnDestroy, ViewChild, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { SurgeryExtensionFormViewModel, SurgeryPersonneSpeciality } from './SurgeryExtensionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SurgeryExtension } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MainSurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryExpend } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { TTObjectStateTransitionDef } from "app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { HvlDataGrid } from 'app/Fw/Components/HvlDataGrid';
import { SurgeryPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';

import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { StringParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

@Component({
    selector: 'SurgeryExtensionForm',
    templateUrl: './SurgeryExtensionForm.html',
    providers: [MessageService]
})
export class SurgeryExtensionForm extends EpisodeActionForm implements OnInit, OnDestroy {
    @ViewChild('gridSurgeryPersonnelsMain') gridSurgeryPersonnelsMain: HvlDataGrid;
    GridSurgeryPersonnels: TTVisual.ITTGrid;
    SurgeryPersonnel: TTVisual.ITTListBoxColumn;
    SurgeryPersonnelSpeciality: TTVisual.ITTTextBoxColumn;
    CARole: TTVisual.ITTEnumComboBoxColumn;

    Ameliyat: TTVisual.ITTTabControl;
    AmountDirectPurchaseGrid: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    CAAmount: TTVisual.ITTTextBoxColumn;
    CAMaterial: TTVisual.ITTListBoxColumn;
    CAProcedureObject: TTVisual.ITTListBoxColumn;
    CAStore: TTVisual.ITTListBoxColumn;
    CMActionDate: TTVisual.ITTDateTimePickerColumn;
    DirectPurchaseGrids: TTVisual.ITTGrid;
    DirectPurchaseTab: TTVisual.ITTTabPage;
    DistributionType: TTVisual.ITTTextBoxColumn;
    DonorID: TTVisual.ITTTextBoxColumn;
    GridMainSurgeryProcedures: TTVisual.ITTGrid;
    GridSurgeryExpends: TTVisual.ITTGrid;
    labelPlannedSurgeryDescription: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    labelSurgeryDesk: TTVisual.ITTLabel;
    labelSurgeryEndTime: TTVisual.ITTLabel;
    labelSurgeryStartTime: TTVisual.ITTLabel;
    MainSrgryActionDate: TTVisual.ITTDateTimePickerColumn;
    MainSrgryAmount: TTVisual.ITTTextBoxColumn;
    MainSrgryBarcode: TTVisual.ITTTextBoxColumn;
    MainSrgryDistributionType: TTVisual.ITTTextBoxColumn;
    MainSrgryDonorID: TTVisual.ITTTextBoxColumn;
    MainSrgryMaterial: TTVisual.ITTListBoxColumn;
    MainSrgryStore: TTVisual.ITTListBoxColumn;
    MasterResource: TTVisual.ITTObjectListBox;
    MaterialDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    PersonnelSurgeryPersonnel: TTVisual.ITTListBoxColumn;
    PlannedSurgeryDate: TTVisual.ITTDateTimePicker;
    PlannedSurgeryDescription: TTVisual.ITTTextBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    RoleSurgeryPersonnel: TTVisual.ITTEnumComboBoxColumn;
    SurgeryDesk: TTVisual.ITTObjectListBox;
    SurgeryEndTime: TTVisual.ITTDateTimePicker;
    SurgeryExpend: TTVisual.ITTTabPage;
    SurgeryExpendsSurgeryExpend: TTVisual.ITTGrid;
    SurgeryRoom: TTVisual.ITTObjectListBox;
    SurgeryStartTime: TTVisual.ITTDateTimePicker;
    SurgerySurgeryPersonnel: TTVisual.ITTListBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    ttrichtextboxcontrol2: TTVisual.ITTRichTextBoxControl;
    tttextboxcolumn1: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn2: TTVisual.ITTTextBoxColumn;

    public ComfirmAddRowByPersonelFilterSelectionFunc: Function;

    public DirectPurchaseGridsColumns = [];
    public GridMainSurgeryProceduresColumns = [];
    public GridSurgeryExpendsColumns = [];
    public SurgeryExpendsSurgeryExpendColumns = [];
    public GridSurgeryPersonnelsColumns = [];
    public surgeryExtensionFormViewModel: SurgeryExtensionFormViewModel = new SurgeryExtensionFormViewModel();
    public get _SurgeryExtension(): SurgeryExtension {
        return this._TTObject as SurgeryExtension;
    }
    private SurgeryExtensionForm_DocumentUrl: string = '/api/SurgeryExtensionService/SurgeryExtensionForm';
    constructor(private sideBarMenuService: ISidebarMenuService, protected httpService: NeHttpService, protected helpMenuService: HelpMenuService, protected objectContextService: ObjectContextService,
        protected messageService: MessageService, private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SurgeryExtensionForm_DocumentUrl;
        this.ComfirmAddRowByPersonelFilterSelectionFunc = this.comfirmAddRowByPersonelFilterSelection.bind(this);
        this.initViewModel();
        this.initFormControls();
    }

    private AddHelpMenu() {
        let printInpatientTreatmentBarcode = new DynamicSidebarMenuItem();
        printInpatientTreatmentBarcode.key = 'printInpatientTreatmentBarcode';
        printInpatientTreatmentBarcode.icon = 'ai ai-barkod-bas';
        printInpatientTreatmentBarcode.label = 'Yatan Hasta Barkodu Bas';
        printInpatientTreatmentBarcode.componentInstance = this.helpMenuService;
        printInpatientTreatmentBarcode.clickFunction = this.helpMenuService.printInpatientTreatmentBarcode;
        printInpatientTreatmentBarcode.parameterFunctionInstance = this;
        printInpatientTreatmentBarcode.ParentInstance = this;
        printInpatientTreatmentBarcode.getParamsFunction = this.getClickFunctionParams;
        this.sideBarMenuService.addMenu('Barkod', printInpatientTreatmentBarcode);

        let printEpicrisisForm = new DynamicSidebarMenuItem();
        printEpicrisisForm.key = 'printEpicrisisForm';
        printEpicrisisForm.icon = 'fa fa-file-text-o';
        printEpicrisisForm.label = 'Epikriz Formu';
        printEpicrisisForm.componentInstance = this;
        printEpicrisisForm.clickFunction = this.printEpicrisisReport;
        printEpicrisisForm.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        printEpicrisisForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printEpicrisisForm);
    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

    }
    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('printInpatientTreatmentBarcode');
        this.sideBarMenuService.removeMenu('printEpicrisisForm');
    }

    // ***** Method declarations start *****


    public printEpicrisisReport() {
        let selectedInpatientPhysicianApplication;
        let selectedDoctorParam;
        if (this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.ProcedureDoctor != null) {
            if (this.surgeryExtensionFormViewModel.InpatientPhyAppObjectId != null) {
                selectedDoctorParam = new StringParam(this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.ProcedureDoctor.ObjectID.toString());
                selectedInpatientPhysicianApplication = new StringParam(this.surgeryExtensionFormViewModel.InpatientPhyAppObjectId.toString());
                let reportParameters: any = { 'TTOBJECTID': selectedInpatientPhysicianApplication, 'Doctor': selectedDoctorParam };
                this.reportService.showReport("EpicrisisReportForPatient", reportParameters);
            } else {
                TTVisual.InfoBox.Alert("Epikriz Yazılacak Yatan Hasta İşlemi Bulunamadı!");
            }
        } else {
            TTVisual.InfoBox.Alert("Sorumlu Cerrah(1.Cerrah) Seçmeden Bu Raporu Yazdıramazsınız!");
        }

    }

    //AMELİYATHANE  MASA YATAK

    private getObjectID(ttObject): string {
        if (ttObject == null)
            return null;
        if (typeof ttObject == "string") {
            return ttObject;
        }
        else
            return ttObject.ObjectID.toString();
    }

    private triggerLoadChildComboBoxBySurgeryDepartment(surgeryDepartment): void {

        if (surgeryDepartment != null) {
            this.SurgeryRoom.ListFilterExpression = " THIS.SURGERYDEPARTMENT= '" + surgeryDepartment.ObjectID.toString() + "'";
            if (this._SurgeryExtension.MainSurgery.SurgeryRoom != null && (this._SurgeryExtension.MainSurgery.SurgeryRoom.SurgeryDepartment == null || this.getObjectID(this._SurgeryExtension.MainSurgery.SurgeryRoom.SurgeryDepartment) != surgeryDepartment.ObjectID))
                this._SurgeryExtension.MainSurgery.SurgeryRoom = null;
        }
        else {
            this.SurgeryRoom.ListFilterExpression = " ";
            this._SurgeryExtension.MainSurgery.SurgeryRoom = null;
        }


    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);

        await this.load(SurgeryExtensionFormViewModel);
    }

    private triggerLoadChildComboBoxBySurgeryRoom(surgeryRoom): void {

        if (surgeryRoom != null) {
            this.SurgeryDesk.ListFilterExpression = " THIS.SURGERYROOM= '" + surgeryRoom.ObjectID.toString() + "'";
            if (this._SurgeryExtension.MainSurgery.SurgeryDesk != null && (this._SurgeryExtension.MainSurgery.SurgeryDesk.SurgeryRoom == null || this.getObjectID(this._SurgeryExtension.MainSurgery.SurgeryDesk.SurgeryRoom) != surgeryRoom.ObjectID))
                this._SurgeryExtension.MainSurgery.SurgeryDesk = null;
        }
        else {
            this.SurgeryDesk.ListFilterExpression = " ";
            this._SurgeryExtension.MainSurgery.SurgeryDesk = null;
        }
        if (this._SurgeryExtension.MainSurgery.MasterResource == null || this._SurgeryExtension.MainSurgery.MasterResource.ObjectID != surgeryRoom.SurgeryDepartment)
            this._SurgeryExtension.MainSurgery.MasterResource = surgeryRoom.SurgeryDepartment;
    }


    private triggerLoadChildComboBoxBySurgeryDesk(surgeryDesk): void {

        if (this._SurgeryExtension.MainSurgery.SurgeryRoom == null || this._SurgeryExtension.MainSurgery.SurgeryRoom.ObjectID != surgeryDesk.SurgeryRoom)
            this._SurgeryExtension.MainSurgery.SurgeryRoom = surgeryDesk.SurgeryRoom;
    }

    protected ArrangeTriggers() {
        if (this._SurgeryExtension.MainSurgery.MasterResource != null)
            this.triggerLoadChildComboBoxBySurgeryDepartment(this._SurgeryExtension.MainSurgery.MasterResource);
        if (this._SurgeryExtension.MainSurgery.SurgeryRoom != null)
            this.triggerLoadChildComboBoxBySurgeryRoom(this._SurgeryExtension.MainSurgery.SurgeryRoom);

    }

    public comfirmAddRowByPersonelFilterSelection(event) {
        if (event != null) {
            if (event.ObjectID) {
                if (this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.AllSurgeryPersonnels.findIndex(dr => dr.Personnel != null && dr.Personnel.ObjectID == event.ObjectID && dr.EntityState != EntityStateEnum.Deleted) != -1) {
                    this.messageService.showError("Bu personel zaten ekli");
                    return false;
                }

                let that = this;
                let tempData = event;
                if (that.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.SurgeryStartTime == null) {
                    this.messageService.showInfo("Lütfen personel eklemeden önce ameliyat başlangıç tarihini seçiniz.");
                    return false;
                }

                CommonService.PersonelIzinKontrol(event.ObjectID, that.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.SurgeryStartTime).then(a => {
                    if (a) {
                        this.messageService.showInfo(event.Name + " isimli personel izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            // alert("iso")
                        }, 500);
                    }
                    else {
                        that.gridSurgeryPersonnelsMain.gridInstance.instance.addRow()
                        that.gridSurgeryPersonnelsMain.gridInstance.instance.saveEditData();
                    }

                });

                return false;
            }
        }
        else
            return true;
    }

    public personnelSelectedFilterChanged(event) {
        if (event != null) {
            if (event.Personnel && event.Personnel.ObjectID) {
                let that = this;
                let personelindex = that.surgeryExtensionFormViewModel.SurgeryPersonneSpecilaityList.findIndex(dr => dr.userObjectId == event.Personnel.ObjectID);
                if (personelindex != -1) {
                    event["PersonnelSpeciality"] = that.surgeryExtensionFormViewModel.SurgeryPersonneSpecilaityList[personelindex].specilaityName;
                }
                else {
                    this.httpService.get<string>("/api/SurgeryService/GetSpecialityOfUser?UserObjectID=" + event.Personnel.ObjectID)
                        .then(result => {
                            let surgeryPersonel = that._SurgeryExtension.MainSurgery.AllSurgeryPersonnels.find(dr => dr.Personnel.ObjectID == event.Personnel.ObjectID);
                            surgeryPersonel["PersonnelSpeciality"] = result;
                            let surgeryPersonneSpecilaity = new SurgeryPersonneSpeciality();
                            surgeryPersonneSpecilaity.userObjectId = event.Personnel.ObjectID;
                            surgeryPersonneSpecilaity.specilaityName = result;
                            this.surgeryExtensionFormViewModel.SurgeryPersonneSpecilaityList.unshift(surgeryPersonneSpecilaity);
                        })
                        .catch(error => {
                            console.log(error);
                        });
                }
            }
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SurgeryExtension();
        this.surgeryExtensionFormViewModel = new SurgeryExtensionFormViewModel();
        this._ViewModel = this.surgeryExtensionFormViewModel;
        this.surgeryExtensionFormViewModel._SurgeryExtension = this._TTObject as SurgeryExtension;
        this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery = new Surgery();
        this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.SurgeryExpends = new Array<SurgeryExpend>();
        this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.AllSurgeryPersonnels = new Array<SurgeryPersonnel>();
        this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.ProcedureDoctor = new ResUser();
        this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.SurgeryRoom = new ResSurgeryRoom();
        this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.MasterResource = new ResSection();
        this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.SurgeryDesk = new ResSurgeryDesk();
        this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.MainSurgeryProcedures = new Array<MainSurgeryProcedure>();
        this.surgeryExtensionFormViewModel._SurgeryExtension.SurgeryExtensionExpends = new Array<SurgeryExpend>();
        this.surgeryExtensionFormViewModel._SurgeryExtension.DirectPurchaseGrids = new Array<DirectPurchaseGrid>();
    }

    protected async PreScript(): Promise<void> {
        super.PreScript();

        //if (this.surgeryExtensionFormViewModel.SurgeryExpendsSurgeryExpendGridList != null) {
        //    for (let materialItem of this.surgeryExtensionFormViewModel.SurgeryExpendsSurgeryExpendGridList) {
        //        if (materialItem.Material != null && typeof (materialItem.Material) == "string") {
        //            let materailId = materialItem.Material;
        //            let materialObj = await this.objectContextService.getObjectWithDefName<Material>(new Guid(materailId as string), 'Material') as Material;
        //            materialItem.Material = materialObj;
        //        }
        //    }
        //}

        this.DropStateButton(SurgeryExtension.SurgeryExtensionStates.Cancelled);
        this.DropStateButton(SurgeryExtension.SurgeryExtensionStates.Rejected);
        this.ArrangeTriggers();
        this.hasRequestedProceduresForm = true;

        this.DirectPurchaseGrids.ShowFilterCombo = !this.ReadOnly;
        this.DirectPurchaseGrids.AllowUserToDeleteRows = !this.ReadOnly;

        this.GridSurgeryPersonnels.ShowFilterCombo = !this.ReadOnly;
        this.GridSurgeryPersonnels.AllowUserToDeleteRows = !this.ReadOnly;

        for (let detailItem of this.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery.AllSurgeryPersonnels) {

            let personelindex = this.surgeryExtensionFormViewModel.SurgeryPersonneSpecilaityList.findIndex(dr => dr.userObjectId == detailItem.Personnel.ObjectID.toString());
            if (personelindex != -1) {
                detailItem["PersonnelSpeciality"] = this.surgeryExtensionFormViewModel.SurgeryPersonneSpecilaityList[personelindex].specilaityName;
            }
        }
    }

    protected loadViewModel() {
        let that = this;

        that.surgeryExtensionFormViewModel = this._ViewModel as SurgeryExtensionFormViewModel;
        that._TTObject = this.surgeryExtensionFormViewModel._SurgeryExtension;
        if (this.surgeryExtensionFormViewModel == null)
            this.surgeryExtensionFormViewModel = new SurgeryExtensionFormViewModel();
        if (this.surgeryExtensionFormViewModel._SurgeryExtension == null)
            this.surgeryExtensionFormViewModel._SurgeryExtension = new SurgeryExtension();
        let mainSurgeryObjectID = that.surgeryExtensionFormViewModel._SurgeryExtension["MainSurgery"];
        if (mainSurgeryObjectID != null && (typeof mainSurgeryObjectID === "string")) {
            let mainSurgery = that.surgeryExtensionFormViewModel.Surgerys.find(o => o.ObjectID.toString() === mainSurgeryObjectID.toString());
            if (mainSurgery) {
                that.surgeryExtensionFormViewModel._SurgeryExtension.MainSurgery = mainSurgery;
            }
            if (that.surgeryExtensionFormViewModel.MainSurgeryTreatmentMaterialList.length > 0) {
                for (let materialItemObj of that.surgeryExtensionFormViewModel.MainSurgeryTreatmentMaterialList) {
                    that.surgeryExtensionFormViewModel.Materials.push(materialItemObj);//surgeryExtension.MainSurgery.TreatmentMaterials
                }
            }


            if (mainSurgery != null) {
                mainSurgery.SurgeryExpends = that.surgeryExtensionFormViewModel.SurgeryExpendsSurgeryExpendGridList;
                for (let detailItem of that.surgeryExtensionFormViewModel.SurgeryExpendsSurgeryExpendGridList) {
                    let storeObjectID = detailItem["Store"];
                    if (storeObjectID != null && (typeof storeObjectID === "string")) {
                        let store = that.surgeryExtensionFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                        if (store) {
                            detailItem.Store = store;
                        }
                    }
                    let materialObjectID = detailItem["Material"];
                    if (materialObjectID != null && (typeof materialObjectID === "string")) {
                        let material = that.surgeryExtensionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                        if (material) {
                            detailItem.Material = material;
                        }

                        if (material != null) {
                            let stockCardObjectID = material["StockCard"];
                            if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                                let stockCard = that.surgeryExtensionFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                                if (stockCard) {
                                    material.StockCard = stockCard;
                                }

                                if (stockCard != null) {
                                    let distributionTypeObjectID = stockCard["DistributionType"];
                                    if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                        let distributionType = that.surgeryExtensionFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                        if (distributionType) {
                                            stockCard.DistributionType = distributionType;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }

            if (mainSurgery != null) {
                mainSurgery.AllSurgeryPersonnels = that.surgeryExtensionFormViewModel.GridSurgeryPersonnelsGridList;
                for (let detailItem of that.surgeryExtensionFormViewModel.GridSurgeryPersonnelsGridList) {
                    let surgeryObjectID = detailItem["Surgery"];
                    if (surgeryObjectID != null && (typeof surgeryObjectID === "string")) {
                        let surgery = that.surgeryExtensionFormViewModel.Surgerys.find(o => o.ObjectID.toString() === surgeryObjectID.toString());
                        if (surgery) {
                            detailItem.Surgery = surgery;
                        }
                    }

                    let personnelObjectID = detailItem["Personnel"];
                    if (personnelObjectID != null && (typeof personnelObjectID === "string")) {
                        let personnel = that.surgeryExtensionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === personnelObjectID.toString());
                        if (personnel) {
                            detailItem.Personnel = personnel;
                        }
                    }

                }
            }

            if (mainSurgery != null) {
                let procedureDoctorObjectID = mainSurgery["ProcedureDoctor"];
                if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                    let procedureDoctor = that.surgeryExtensionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                    if (procedureDoctor) {
                        mainSurgery.ProcedureDoctor = procedureDoctor;
                    }
                }
            }
            if (mainSurgery != null) {
                let surgeryRoomObjectID = mainSurgery["SurgeryRoom"];
                if (surgeryRoomObjectID != null && (typeof surgeryRoomObjectID === "string")) {
                    let surgeryRoom = that.surgeryExtensionFormViewModel.ResSurgeryRooms.find(o => o.ObjectID.toString() === surgeryRoomObjectID.toString());
                    if (surgeryRoom) {
                        mainSurgery.SurgeryRoom = surgeryRoom;
                    }
                }
            }
            if (mainSurgery != null) {
                let masterResourceObjectID = mainSurgery["MasterResource"];
                if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
                    let masterResource = that.surgeryExtensionFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                    if (masterResource) {
                        mainSurgery.MasterResource = masterResource;
                    }
                }
            }
            if (mainSurgery != null) {
                let surgeryDeskObjectID = mainSurgery["SurgeryDesk"];
                if (surgeryDeskObjectID != null && (typeof surgeryDeskObjectID === "string")) {
                    let surgeryDesk = that.surgeryExtensionFormViewModel.ResSurgeryDesks.find(o => o.ObjectID.toString() === surgeryDeskObjectID.toString());
                    if (surgeryDesk) {
                        mainSurgery.SurgeryDesk = surgeryDesk;
                    }
                }
            }
            if (mainSurgery != null) {
                mainSurgery.MainSurgeryProcedures = that.surgeryExtensionFormViewModel.GridMainSurgeryProceduresGridList;
                for (let detailItem of that.surgeryExtensionFormViewModel.GridMainSurgeryProceduresGridList) {
                    let procedureObjectObjectID = detailItem["ProcedureObject"];
                    if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                        let procedureObject = that.surgeryExtensionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                        if (procedureObject) {
                            detailItem.ProcedureObject = procedureObject;
                        }
                    }
                }
            }
        }

        that.surgeryExtensionFormViewModel._SurgeryExtension.SurgeryExtensionExpends = that.surgeryExtensionFormViewModel.GridSurgeryExpendsGridList;
        for (let detailItem of that.surgeryExtensionFormViewModel.GridSurgeryExpendsGridList) {
            let storeObjectID = detailItem["Store"];
            if (storeObjectID != null && (typeof storeObjectID === "string")) {
                let store = that.surgeryExtensionFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                if (store) {
                    detailItem.Store = store;
                }
            }
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.surgeryExtensionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.surgeryExtensionFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.surgeryExtensionFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.surgeryExtensionFormViewModel._SurgeryExtension.DirectPurchaseGrids = that.surgeryExtensionFormViewModel.DirectPurchaseGridsGridList;
        for (let detailItem of that.surgeryExtensionFormViewModel.DirectPurchaseGridsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.surgeryExtensionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(SurgeryExtensionFormViewModel);
        this.AddHelpMenu();

    }


    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.MasterResource != event) {
                this._SurgeryExtension.MainSurgery.MasterResource = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryDepartment(event);
    }
    public onSurgeryDeskChanged(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.SurgeryDesk != event) {
                this._SurgeryExtension.MainSurgery.SurgeryDesk = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryRoom(event);
    }
    public onSurgeryRoomChanged(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.SurgeryRoom != event) {
                this._SurgeryExtension.MainSurgery.SurgeryRoom = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryDesk(event);
    }

    public onPlannedSurgeryDateChanged(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.PlannedSurgeryDate != event) {
                this._SurgeryExtension.MainSurgery.PlannedSurgeryDate = event;
            }
        }
    }

    public onPlannedSurgeryDescriptionChanged(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.PlannedSurgeryDescription != event) {
                this._SurgeryExtension.MainSurgery.PlannedSurgeryDescription = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.ProcedureDoctor != event) {
                this._SurgeryExtension.MainSurgery.ProcedureDoctor = event;

                if (this._SurgeryExtension.MainSurgery.SurgeryStartTime != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._SurgeryExtension.MainSurgery.ProcedureDoctor.ObjectID, this._SurgeryExtension.MainSurgery.SurgeryStartTime);
                    if (a) {
                        this.messageService.showInfo(this._SurgeryExtension.MainSurgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._SurgeryExtension.MainSurgery.ProcedureDoctor = null;
                        }, 500);
                    }
                }
            }
        }
    }

    public onSurgeryEndTimeChanged(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.SurgeryEndTime != event) {
                this._SurgeryExtension.MainSurgery.SurgeryEndTime = event;

            }
        }
    }



    public async onSurgeryStartTimeChanged(event) {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.SurgeryStartTime != event) {
                this._SurgeryExtension.MainSurgery.SurgeryStartTime = event;


                if (this._SurgeryExtension.MainSurgery.ProcedureDoctor != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._SurgeryExtension.MainSurgery.ProcedureDoctor.ObjectID, this._SurgeryExtension.MainSurgery.SurgeryStartTime);
                    if (a) {
                        this.messageService.showInfo(this._SurgeryExtension.MainSurgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._SurgeryExtension.MainSurgery.ProcedureDoctor = null;
                        }, 500);

                    }
                }
            }
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.PreOpDescriptions != event) {
                this._SurgeryExtension.MainSurgery.PreOpDescriptions = event;
            }
        }
    }

    public onttrichtextboxcontrol2Changed(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.DescriptionToPreOp != event) {
                this._SurgeryExtension.MainSurgery.DescriptionToPreOp = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._SurgeryExtension != null &&
                this._SurgeryExtension.MainSurgery != null && this._SurgeryExtension.MainSurgery.ProtocolNo != event) {
                this._SurgeryExtension.MainSurgery.ProtocolNo = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.PlannedSurgeryDate, "Value", this.__ttObject, "MainSurgery.PlannedSurgeryDate");
        redirectProperty(this.SurgeryStartTime, "Value", this.__ttObject, "MainSurgery.SurgeryStartTime");
        redirectProperty(this.SurgeryEndTime, "Value", this.__ttObject, "MainSurgery.SurgeryEndTime");
        redirectProperty(this.PlannedSurgeryDescription, "Text", this.__ttObject, "MainSurgery.PlannedSurgeryDescription");
        redirectProperty(this.ttrichtextboxcontrol2, "Rtf", this.__ttObject, "MainSurgery.DescriptionToPreOp");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "MainSurgery.PreOpDescriptions");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "MainSurgery.ProtocolNo");
    }

    public initFormControls(): void {
        this.SurgeryExpendsSurgeryExpend = new TTVisual.TTGrid();
        this.SurgeryExpendsSurgeryExpend.Name = "SurgeryExpendsSurgeryExpend";
        this.SurgeryExpendsSurgeryExpend.TabIndex = 1;

        this.MainSrgryActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MainSrgryActionDate.Format = DateTimePickerFormat.Custom;
        this.MainSrgryActionDate.CustomFormat = "dd/MM/yyy HH:mm";
        this.MainSrgryActionDate.DataMember = "ActionDate";
        this.MainSrgryActionDate.DisplayIndex = 0;
        this.MainSrgryActionDate.HeaderText = "Tarih/Saat";
        this.MainSrgryActionDate.Name = "MainSrgryActionDate";
        this.MainSrgryActionDate.Width = 180;

        this.MainSrgryStore = new TTVisual.TTListBoxColumn();
        this.MainSrgryStore.AllowMultiSelect = true;
        this.MainSrgryStore.ListDefName = "StoreListDefinition";
        this.MainSrgryStore.DataMember = "Store";
        this.MainSrgryStore.ForceLinkedParentSelection = true;
        this.MainSrgryStore.DisplayIndex = 1;
        this.MainSrgryStore.HeaderText = "Depo";
        this.MainSrgryStore.Name = "MainSrgryStore";
        this.MainSrgryStore.Width = 300;

        this.MainSrgryMaterial = new TTVisual.TTListBoxColumn();
        this.MainSrgryMaterial.AllowMultiSelect = true;
        this.MainSrgryMaterial.ListDefName = "ConsumableMaterialAndDrugList";
        this.MainSrgryMaterial.DataMember = "Material";
        this.MainSrgryMaterial.ForceLinkedParentSelection = true;
        this.MainSrgryMaterial.DisplayIndex = 2;
        this.MainSrgryMaterial.HeaderText = "Cerrahi Sarf";
        this.MainSrgryMaterial.Name = "MainSrgryMaterial";
        this.MainSrgryMaterial.Width = 300;

        this.MainSrgryBarcode = new TTVisual.TTTextBoxColumn();
        this.MainSrgryBarcode.DataMember = "Barcode";
        this.MainSrgryBarcode.DisplayIndex = 3;
        this.MainSrgryBarcode.HeaderText = "Barkodu";
        this.MainSrgryBarcode.Name = "MainSrgryBarcode";
        this.MainSrgryBarcode.ReadOnly = true;
        this.MainSrgryBarcode.Width = 100;

        this.MainSrgryAmount = new TTVisual.TTTextBoxColumn();
        this.MainSrgryAmount.DataMember = "Amount";
        this.MainSrgryAmount.DisplayIndex = 4;
        this.MainSrgryAmount.HeaderText = "Miktar";
        this.MainSrgryAmount.Name = "MainSrgryAmount";
        this.MainSrgryAmount.Width = 80;

        this.MainSrgryDonorID = new TTVisual.TTTextBoxColumn();
        this.MainSrgryDonorID.DataMember = "DonorID";
        this.MainSrgryDonorID.DisplayIndex = 5;
        this.MainSrgryDonorID.HeaderText = "Dönor ID";
        this.MainSrgryDonorID.Name = "MainSrgryDonorID";
        this.MainSrgryDonorID.Width = 80;

        this.MainSrgryDistributionType = new TTVisual.TTTextBoxColumn();
        this.MainSrgryDistributionType.DataMember = "DistributionType";
        this.MainSrgryDistributionType.DisplayIndex = 6;
        this.MainSrgryDistributionType.HeaderText = "Ölçü Miktarı";
        this.MainSrgryDistributionType.Name = "MainSrgryDistributionType";
        this.MainSrgryDistributionType.ReadOnly = true;
        this.MainSrgryDistributionType.Width = 100;

        this.GridSurgeryPersonnels = new TTVisual.TTGrid();
        this.GridSurgeryPersonnels.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridSurgeryPersonnels.Name = "GridSurgeryPersonnels";
        this.GridSurgeryPersonnels.TabIndex = 0;
        this.GridSurgeryPersonnels.Height = 140;
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
        this.SurgeryPersonnel.HeaderText = i18n("M12206", "Cerrahi Ekip");
        this.SurgeryPersonnel.Name = "SurgeryPersonnel";
        this.SurgeryPersonnel.Width = "60%";

        this.SurgeryPersonnelSpeciality = new TTVisual.TTTextBoxColumn();
        this.SurgeryPersonnelSpeciality.DataMember = "PersonnelSpeciality";
        this.SurgeryPersonnelSpeciality.DisplayIndex = 0;
        this.SurgeryPersonnelSpeciality.HeaderText = i18n("M27149", "Uzmanlık Dalı");
        this.SurgeryPersonnelSpeciality.Name = "PersonnelSpeciality";
        this.SurgeryPersonnelSpeciality.Width = "40%";
        this.SurgeryPersonnelSpeciality.ReadOnly = true;


        this.CARole = new TTVisual.TTEnumComboBoxColumn();
        this.CARole.DataTypeName = "SurgeryRoleEnum";
        this.CARole.DataMember = "Role";
        this.CARole.DisplayIndex = 1;
        this.CARole.HeaderText = i18n("M27329", "Görevi");
        this.CARole.Name = "CARole";
        this.CARole.Width = "25%";

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 88;

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.DisplayText = i18n("M19972", "Ön Hazırlık Açıklamaları");
        this.ttrichtextboxcontrol1.TemplateGroupName = "SURGERYPREOPDESCRIPTIONS";
        this.ttrichtextboxcontrol1.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 117;

        this.ttrichtextboxcontrol2 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol2.DisplayText = i18n("M19974", "Ön Hazırlık İçin Direktifler");
        this.ttrichtextboxcontrol2.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol2.Name = "ttrichtextboxcontrol2";
        this.ttrichtextboxcontrol2.TabIndex = 116;

        this.Ameliyat = new TTVisual.TTTabControl();
        this.Ameliyat.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Ameliyat.Name = i18n("M27385", "Ameliyat");
        this.Ameliyat.TabIndex = 10;

        this.SurgeryExpend = new TTVisual.TTTabPage();
        this.SurgeryExpend.DisplayIndex = 0;
        this.SurgeryExpend.BackColor = "#FFFFFF";
        this.SurgeryExpend.TabIndex = 0;
        this.SurgeryExpend.Text = i18n("M12207", "Cerrahi Sarf");
        this.SurgeryExpend.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryExpend.Name = "SurgeryExpend";

        this.GridSurgeryExpends = new TTVisual.TTGrid();
        this.GridSurgeryExpends.AllowUserToDeleteRows = false;
        this.GridSurgeryExpends.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridSurgeryExpends.Name = "GridSurgeryExpends";
        this.GridSurgeryExpends.TabIndex = 0;

        this.CMActionDate = new TTVisual.TTDateTimePickerColumn();
        this.CMActionDate.Format = DateTimePickerFormat.Custom;
        this.CMActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.CMActionDate.DataMember = "ActionDate";
        this.CMActionDate.DisplayIndex = 0;
        this.CMActionDate.HeaderText = "Tarih/Saat";
        this.CMActionDate.Name = "CMActionDate";
        this.CMActionDate.Width = 150;

        this.CAStore = new TTVisual.TTListBoxColumn();
        this.CAStore.AllowMultiSelect = true;
        this.CAStore.ListDefName = "StoreListDefinition";
        this.CAStore.DataMember = "Store";
        this.CAStore.ForceLinkedParentSelection = true;
        this.CAStore.DisplayIndex = 1;
        this.CAStore.HeaderText = i18n("M12615", "Depo");
        this.CAStore.Name = "CAStore";
        this.CAStore.Width = 200;

        this.CAMaterial = new TTVisual.TTListBoxColumn();
        this.CAMaterial.AllowMultiSelect = true;
        this.CAMaterial.ListDefName = "ConsumableMaterialAndDrugList";
        this.CAMaterial.DataMember = "Material";
        this.CAMaterial.ForceLinkedParentSelection = true;
        this.CAMaterial.DisplayIndex = 2;
        this.CAMaterial.HeaderText = i18n("M12207", "Cerrahi Sarf");
        this.CAMaterial.Name = "CAMaterial";
        this.CAMaterial.Width = 380;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 3;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.CAAmount = new TTVisual.TTTextBoxColumn();
        this.CAAmount.DataMember = "Amount";
        this.CAAmount.DisplayIndex = 4;
        this.CAAmount.HeaderText = i18n("M19030", "Miktar");
        this.CAAmount.Name = "CAAmount";
        this.CAAmount.Width = 100;

        this.DonorID = new TTVisual.TTTextBoxColumn();
        this.DonorID.DataMember = "DonorID";
        this.DonorID.DisplayIndex = 5;
        this.DonorID.HeaderText = i18n("M13332", "Dönor ID");
        this.DonorID.Name = "DonorID";
        this.DonorID.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 6;
        this.DistributionType.HeaderText = i18n("M19910", "Ölçü Miktarı");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.DirectPurchaseTab = new TTVisual.TTTabPage();
        this.DirectPurchaseTab.DisplayIndex = 1;
        this.DirectPurchaseTab.TabIndex = 1;
        this.DirectPurchaseTab.Text = "Doğrudan Temin Edilen Malzemeler";
        this.DirectPurchaseTab.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DirectPurchaseTab.Name = "DirectPurchaseTab";

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

        this.MaterialDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.MaterialDirectPurchaseGrid.ListDefName = "MaterialListDefinition";
        this.MaterialDirectPurchaseGrid.DataMember = "Material";
        this.MaterialDirectPurchaseGrid.DisplayIndex = 0;
        this.MaterialDirectPurchaseGrid.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialDirectPurchaseGrid.Name = "MaterialDirectPurchaseGrid";
        this.MaterialDirectPurchaseGrid.ReadOnly = true;
        this.MaterialDirectPurchaseGrid.Width = "70%";

        this.AmountDirectPurchaseGrid = new TTVisual.TTTextBoxColumn();
        this.AmountDirectPurchaseGrid.DataMember = "Amount";
        this.AmountDirectPurchaseGrid.DisplayIndex = 1;
        this.AmountDirectPurchaseGrid.HeaderText = i18n("M19030", "Miktar");
        this.AmountDirectPurchaseGrid.Name = "AmountDirectPurchaseGrid";
        this.AmountDirectPurchaseGrid.Width = "20%";

        this.PlannedSurgeryDescription = new TTVisual.TTTextBox();
        this.PlannedSurgeryDescription.Multiline = true;
        this.PlannedSurgeryDescription.BackColor = "#F0F0F0";
        this.PlannedSurgeryDescription.ReadOnly = true;
        this.PlannedSurgeryDescription.Name = "PlannedSurgeryDescription";
        this.PlannedSurgeryDescription.TabIndex = 103;
        this.PlannedSurgeryDescription.Height = "100px";

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 88;

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

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M20395", "Planlanan Ameliyat Tarihi");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 117;

        this.PlannedSurgeryDate = new TTVisual.TTDateTimePicker();
        this.PlannedSurgeryDate.CustomFormat = "";
        this.PlannedSurgeryDate.Format = DateTimePickerFormat.Long;
        this.PlannedSurgeryDate.Name = "PlannedSurgeryDate";
        this.PlannedSurgeryDate.TabIndex = 1;

        this.labelSurgeryEndTime = new TTVisual.TTLabel();
        this.labelSurgeryEndTime.Text = i18n("M10861", "Ameliyatı Bitirme Tarih/Saat");
        this.labelSurgeryEndTime.BackColor = "#DCDCDC";
        this.labelSurgeryEndTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurgeryEndTime.ForeColor = "#000000";
        this.labelSurgeryEndTime.Name = "labelSurgeryEndTime";
        this.labelSurgeryEndTime.TabIndex = 100;

        this.SurgeryEndTime = new TTVisual.TTDateTimePicker();
        this.SurgeryEndTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SurgeryEndTime.Format = DateTimePickerFormat.Long;
        this.SurgeryEndTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryEndTime.Name = "SurgeryEndTime";
        this.SurgeryEndTime.TabIndex = 8;

        this.SurgeryRoom = new TTVisual.TTObjectListBox();
        this.SurgeryRoom.LinkedControlName = "MasterResource";
        this.SurgeryRoom.ListDefName = "SurgeryRoomListDefinition";
        this.SurgeryRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryRoom.Name = "SurgeryRoom";
        this.SurgeryRoom.TabIndex = 5;

        this.labelSurgeryStartTime = new TTVisual.TTLabel();
        this.labelSurgeryStartTime.Text = i18n("M10859", "Ameliyatı Başlatma Tarih/Saat");
        this.labelSurgeryStartTime.BackColor = "#DCDCDC";
        this.labelSurgeryStartTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurgeryStartTime.ForeColor = "#000000";
        this.labelSurgeryStartTime.Name = "labelSurgeryStartTime";
        this.labelSurgeryStartTime.TabIndex = 92;

        this.SurgeryStartTime = new TTVisual.TTDateTimePicker();
        this.SurgeryStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SurgeryStartTime.Format = DateTimePickerFormat.Long;
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

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "SurgreyDepartmentListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 3;

        this.labelPlannedSurgeryDescription = new TTVisual.TTLabel();
        this.labelPlannedSurgeryDescription.Text = i18n("M20394", "Planlanan Ameliyat Açıklaması");
        this.labelPlannedSurgeryDescription.Name = "labelPlannedSurgeryDescription";
        this.labelPlannedSurgeryDescription.TabIndex = 104;

        this.SurgeryDesk = new TTVisual.TTObjectListBox();
        this.SurgeryDesk.LinkedControlName = "SurgeryRoom";
        this.SurgeryDesk.ListDefName = "SurgeryDeskListDefinition";
        this.SurgeryDesk.Name = "SurgeryDesk";
        this.SurgeryDesk.TabIndex = 105;

        this.labelSurgeryDesk = new TTVisual.TTLabel();
        this.labelSurgeryDesk.Text = i18n("M18680", "Masa");
        this.labelSurgeryDesk.Name = "labelSurgeryDesk";
        this.labelSurgeryDesk.TabIndex = 106;

        this.GridMainSurgeryProcedures = new TTVisual.TTGrid();
        this.GridMainSurgeryProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridMainSurgeryProcedures.ReadOnly = true;
        this.GridMainSurgeryProcedures.Name = "GridMainSurgeryProcedures";
        this.GridMainSurgeryProcedures.TabIndex = 0;
        this.GridMainSurgeryProcedures.AllowUserToAddRows = false;
        this.GridMainSurgeryProcedures.AllowUserToDeleteRows = false;
        this.GridMainSurgeryProcedures.DeleteButtonWidth = "5%";
        this.GridMainSurgeryProcedures.ShowTotalNumberOfRows = false;


        this.CAProcedureObject = new TTVisual.TTListBoxColumn();
        this.CAProcedureObject.ListDefName = "SurgeryListDefinition";
        this.CAProcedureObject.DataMember = "ProcedureObject";
        this.CAProcedureObject.DisplayIndex = 0;
        this.CAProcedureObject.HeaderText = "Ameliyat ";
        this.CAProcedureObject.Name = "CAProcedureObject";
        this.CAProcedureObject.Width = "85%";
        this.CAProcedureObject.ReadOnly = true;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = "Protokol No";
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 91;

        this.SurgeryExpendsSurgeryExpendColumns = [this.MainSrgryActionDate, this.MainSrgryStore, this.MainSrgryMaterial, this.MainSrgryBarcode, this.MainSrgryAmount, this.MainSrgryDonorID, this.MainSrgryDistributionType];
        this.GridSurgeryPersonnelsColumns = [this.SurgeryPersonnel, this.SurgeryPersonnelSpeciality, this.CARole];
        this.GridSurgeryExpendsColumns = [this.CMActionDate, this.CAStore, this.CAMaterial, this.Barcode, this.CAAmount, this.DonorID, this.DistributionType];
        this.DirectPurchaseGridsColumns = [this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid];
        this.GridMainSurgeryProceduresColumns = [this.CAProcedureObject];
        this.Ameliyat.Controls = [this.SurgeryExpend, this.DirectPurchaseTab];
        this.SurgeryExpend.Controls = [this.GridSurgeryExpends];
        this.DirectPurchaseTab.Controls = [this.DirectPurchaseGrids];
        this.Controls = [this.GridSurgeryPersonnels, this.SurgeryPersonnel, this.CARole, this.ProtocolNo, this.ttrichtextboxcontrol1, this.ttrichtextboxcontrol2, this.Ameliyat, this.SurgeryExpend, this.GridSurgeryExpends, this.CMActionDate, this.CAStore, this.CAMaterial, this.Barcode, this.CAAmount, this.DonorID, this.DistributionType, this.DirectPurchaseTab, this.DirectPurchaseGrids, this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid, this.PlannedSurgeryDescription, this.labelProcedureDoctor, this.ProcedureDoctor, this.ttlabel9, this.PlannedSurgeryDate, this.labelSurgeryEndTime, this.SurgeryEndTime, this.SurgeryRoom, this.labelSurgeryStartTime, this.SurgeryStartTime, this.ttlabel1, this.labelRoom, this.MasterResource, this.labelPlannedSurgeryDescription, this.SurgeryDesk, this.labelSurgeryDesk, this.GridMainSurgeryProcedures, this.CAProcedureObject,
        this.SurgeryExpendsSurgeryExpend, this.MainSrgryActionDate, this.MainSrgryStore, this.MainSrgryMaterial, this.MainSrgryBarcode, this.MainSrgryAmount, this.MainSrgryDonorID, this.MainSrgryDistributionType, this.labelProtocolNo];

    }


}
