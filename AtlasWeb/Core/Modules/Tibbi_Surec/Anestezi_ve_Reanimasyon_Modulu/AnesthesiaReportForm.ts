//$8714614E
import { Component, OnInit, NgZone, ViewChild } from '@angular/core';
import { AnesthesiaReportFormViewModel } from './AnesthesiaReportFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AnesthesiaAndReanimation } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { AnesthesiaAndReanimationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { AnesthesiaPersonnel } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { HvlDataGrid } from 'app/Fw/Components/HvlDataGrid';


@Component({
    selector: 'AnesthesiaReportForm',
    templateUrl: './AnesthesiaReportForm.html',
    providers: [MessageService]
})
export class AnesthesiaReportForm extends EpisodeActionForm implements OnInit {
    ACActionDate: TTVisual.ITTDateTimePickerColumn;
    ACNote: TTVisual.ITTTextBoxColumn;
    //ACProcedureDoctor: TTVisual.ITTListBoxColumn;
    ACProcedureObject: TTVisual.ITTListBoxColumn;
    AnesteziTeknigi: TTVisual.ITTEnumComboBox;
    AnesthesiaEndDateTime: TTVisual.ITTDateTimePicker;
    AnesthesiaPersonnel: TTVisual.ITTListBoxColumn;
    AnesthesiaProcedure: TTVisual.ITTTabPage;
    AnesthesiaReport: TTVisual.ITTRichTextBoxControl;
    AnesthesiaReportDate: TTVisual.ITTDateTimePicker;
    AnesthesiaStartDateTime: TTVisual.ITTDateTimePicker;
    AnesthesiaTeam: TTVisual.ITTTabPage;
    AnesthesiaTechniqueCol: TTVisual.ITTEnumComboBoxColumn;
    AnesthesiaTechniqueGrid: TTVisual.ITTGrid;
    ASAScore: TTVisual.ITTEnumComboBox;
    ASAType: TTVisual.ITTEnumComboBox;
    AyniFarkliKesi: TTVisual.ITTListBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    CAActionDate: TTVisual.ITTDateTimePickerColumn;
    CAProcedureObject: TTVisual.ITTListBoxColumn;
    //DescriptionOfObj: TTVisual.ITTRichTextBoxControlColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    EntryDepartment: TTVisual.ITTListBoxColumn;
    HasComplication: TTVisual.ITTCheckBox;
    ComplicationDescription: TTVisual.ITTTextBox;

    //Euroscore: TTVisual.ITTEnumComboBoxColumn;
    GridAnesthesiaExpends: TTVisual.ITTGrid;
    GridAnesthesiaPersonnels: TTVisual.ITTGrid;
    GridAnesthesiaProcedures: TTVisual.ITTGrid;
    GridSurgeryProcedures: TTVisual.ITTGrid;
    IsTreatmentMaterialEmpty: TTVisual.ITTCheckBox;
    kdv: TTVisual.ITTTextBoxColumn;
    kodsuzMalzemeFiyati: TTVisual.ITTTextBoxColumn;
    labelAnesthesiaEndDateTime: TTVisual.ITTLabel;
    labelAnesthesiaStartDateTime: TTVisual.ITTLabel;
    labelASAType: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProcedureDoctor2: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    LabelRequest: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    labelSurgeryDesk: TTVisual.ITTLabel;
    lableAnsteziReportNo: TTVisual.ITTLabel;
    Laparoscopy: TTVisual.ITTEnumComboBox;
    lebalReasonOfCancel: TTVisual.ITTLabel;
    malzemeBrans: TTVisual.ITTTextBoxColumn;
    malzemeOzelDurum: TTVisual.ITTListBoxColumn;
    malzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    malzemeTuru: TTVisual.ITTListBoxColumn;
    MasterResource: TTVisual.ITTObjectListBox;
    PlannedAnesthsiaDate: TTVisual.ITTDateTimePicker;
    Position: TTVisual.ITTEnumComboBoxColumn;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    //ProcedureDoctor2: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    ReasonOfCancel: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    //Role: TTVisual.ITTTextBoxColumn;
    ScarType: TTVisual.ITTEnumComboBox;
    SMActionDate: TTVisual.ITTDateTimePickerColumn;
    SMAmount: TTVisual.ITTTextBoxColumn;
    SMMaterial: TTVisual.ITTListBoxColumn;
    SMStore: TTVisual.ITTListBoxColumn;
    SurgeryDesk: TTVisual.ITTObjectListBox;
    SurgeryInfo: TTVisual.ITTTabPage;
    SurgeryRoom: TTVisual.ITTObjectListBox;
    TabSubaction: TTVisual.ITTTabControl;
    TreatmentMaterial: TTVisual.ITTTabPage;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepicker2: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabeldrAnesteziTescilNo: TTVisual.ITTLabel;
    TTListBoxDrAnesteziTescilNo: TTVisual.ITTObjectListBox;
    UBBCode: TTVisual.ITTTextBoxColumn;
    public GridAnesthesiaExpendsColumns = [];
    public GridAnesthesiaPersonnelsColumns = [];
    public GridAnesthesiaProceduresColumns = [];
    public GridSurgeryProceduresColumns = [];
    public anesthesiaReportFormViewModel: AnesthesiaReportFormViewModel = new AnesthesiaReportFormViewModel();
    public get _AnesthesiaAndReanimation(): AnesthesiaAndReanimation {
        return this._TTObject as AnesthesiaAndReanimation;
    }
    private AnesthesiaReportForm_DocumentUrl: string = '/api/AnesthesiaAndReanimationService/AnesthesiaReportForm';
    public ComfirmAddRowByPersonelFilterSelectionFunc: Function;
    @ViewChild('gridAnesthesiaPersonnels') gridAnesthesiaPersonnels: HvlDataGrid;

    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this.ComfirmAddRowByPersonelFilterSelectionFunc = this.comfirmAddRowByPersonelFilterSelection.bind(this);
        this._DocumentServiceUrl = this.AnesthesiaReportForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public isFiredBySurgery: Boolean;
    public showAnestesiaProcedure: Boolean;


    private async GridAnesthesiaExpends_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        //if (this.GridAnesthesiaExpends.CurrentCell.OwningColumn.Name === 'SMStore') {
        //    let treatmentMaterial: BaseTreatmentMaterial = <BaseTreatmentMaterial><TTVisual.ITTGridRow>this.GridAnesthesiaExpends.CurrentCell.OwningRow.TTObject;
        //    if (treatmentMaterial !== null) {
        //        this.SMMaterial.ListFilterExpression = ' STOCKS.INHELD > 0 AND STOCKS.STORE = ' + treatmentMaterial.Store.ObjectID.toString();
        //    }
        //}
    }

    private async GridSurgeryProcedures_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);

        //if (transDef !== null) {
        //    if (transDef.ToStateDefID != AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.Cancelled) {
        //        if (this.ProcedureDoctor == null )
        //            throw new TTException('Sorumlu cerrah bilgisini giriniz!');
        ////    }
        //}
        // servera taşındı
        //if (transDef !== null) {
        //    if (transDef.FromStateDef.StateDefID === AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.AnesthesiaReport) {
        //        this._AnesthesiaAndReanimation.CheckAnesthesiaTime();
        //        if (this._AnesthesiaAndReanimation.AnesthesiaTechnique === null) {
        //            let hataParamList: string[] = [''Gerçekleşen Anestezi Tekniği''  ];
        //            throw new TTException((await SystemMessageService.GetMessageV3(95, hataParamList)));
        //        }
        //        if (this._AnesthesiaAndReanimation.AnesthesiaPersonnels.length < 1) {
        //            let hataParamList: string[] = [''Anestezi Ekibi''  ];
        //            throw new TTException((await SystemMessageService.GetMessageV3(95, hataParamList)));
        //        }
        //    }
        //    if (transDef.ToStateDef.StateDefID === AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.Completed) {
        //        this._AnesthesiaAndReanimation.CheckAnesthesiaTime();
        //        if (this._AnesthesiaAndReanimation.IsTreatmentMaterialEmpty !== true) {
        //            if (this._AnesthesiaAndReanimation.TreatmentMaterials.length < 1) {
        //                throw new TTException((await SystemMessageService.GetMessage(207)));
        //            }
        //        }
        //    }
        //}


    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        //if (this.Owner instanceof SurgeryPricingForm)
        //    this.SetFormReadOnly();
        this.hasRequestedProceduresForm = true;

        if (this.anesthesiaReportFormViewModel.OnlyOneProcedureDoctor)
            this.ProcedureDoctor.ListFilterExpression = "USERRESOURCES(RESOURCE='" + this.getMasterResourceObjectId() + "').EXISTS";

        if (this._AnesthesiaAndReanimation.CurrentStateDefID !== AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.Completed) {
            this.DropStateButton(AnesthesiaAndReanimation.AnesthesiaAndReanimationStates.Cancelled);
        }

        if (this._AnesthesiaAndReanimation.MainSurgery == null) { // Anestezi isteği direk başlatıldı ise
            this.GridAnesthesiaProcedures.ReadOnly = false;

            this.isFiredBySurgery = false;
            this.showAnestesiaProcedure = true;

        }
        else {// Anestezi isteği Ameliyattan başlatıldı ise
            this.GridAnesthesiaProcedures.ReadOnly = true;
            this.GridAnesthesiaProcedures.AllowUserToAddRows = false;
            this.GridAnesthesiaProcedures.AllowUserToDeleteRows = false;
            this.ACActionDate.ReadOnly = true;
            this.ACProcedureObject.ReadOnly = true;
           // this.ACProcedureDoctor.ReadOnly = true;

            this.isFiredBySurgery = true;
            if (this._AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures.length > 0)
                this.showAnestesiaProcedure = true;
            else
                this.showAnestesiaProcedure = false;

            //if (this._AnesthesiaAndReanimation.MainSurgery.CurrentStateDefID === Surgery.SurgeryStates.Rejected) {
            //    let hataParamList: string[] = [this._AnesthesiaAndReanimation.MainSurgery.ReasonOfReject.toString()];
            //    let message: string = (await SystemMessageService.GetMessageV3(209, hataParamList));
            //    TTVisual.InfoBox.Show(message);
            //}
        }

        this.GridAnesthesiaPersonnels.ShowFilterCombo = !this.ReadOnly;
	    this.GridAnesthesiaPersonnels.AllowUserToDeleteRows = !this.ReadOnly;
        //this.SMMaterial.ListFilterExpression = this.anesthesiaReportFormViewModel.TreatmentMaterialListFilter;
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef); // Tanı için Süperin Çağırılması zorunlu
        await this.load(AnesthesiaReportFormViewModel);
    }

    protected getMasterResourceObjectId(): string {

        if (this._AnesthesiaAndReanimation.MasterResource != null) {
            if (typeof this._AnesthesiaAndReanimation.MasterResource === "string") {
                return this._AnesthesiaAndReanimation.MasterResource;
            }
            else {
                return this._AnesthesiaAndReanimation.MasterResource.ObjectID.toString();
            }
        }
        return null;
    }

    public comfirmAddRowByPersonelFilterSelection(event) {
        if (event != null) {
            if (event.ObjectID) {
                if (this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnesthesiaPersonnels.findIndex(dr => dr.AnesthesiaPersonnel != null && dr.AnesthesiaPersonnel.ObjectID == event.ObjectID) != -1) {
                    this.messageService.showError("Bu personel zaten ekli");
                    return false;
                }
                
                if(this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnesthesiaStartDateTime == null)
                {
                    this.messageService.showInfo("Lütfen Anestezi Başlama Tarihini Seçiniz.");
                    return false;
                }

                let that =this;
                let tempData=event;
                CommonService.PersonelIzinKontrol(event.ObjectID, that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnesthesiaStartDateTime).then(a => {
                    if (a) {
                        this.messageService.showInfo(event.Name + " isimli personel izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            // alert("iso")
                        }, 500);
                    }
                    else
                    {
                        that.gridAnesthesiaPersonnels.gridInstance.instance.addRow()
                        that.gridAnesthesiaPersonnels.gridInstance.instance.saveEditData();
                    }


                });
                return false;
            }
        }
        else
            return true;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AnesthesiaAndReanimation();
        this.anesthesiaReportFormViewModel = new AnesthesiaReportFormViewModel();
        this._ViewModel = this.anesthesiaReportFormViewModel;
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation = this._TTObject as AnesthesiaAndReanimation;
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.MainSurgery = new Surgery();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.MainSurgery.MasterResource = new ResSection();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.MainSurgery.SurgeryRoom = new ResSurgeryRoom();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.MainSurgery.SurgeryProcedures = new Array<SurgeryProcedure>();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.MainSurgery.SurgeryDesk = new ResSurgeryDesk();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.ResUser = new ResUser();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnesthesiaPersonnels = new Array<AnesthesiaPersonnel>();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures = new Array<AnesthesiaProcedure>();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnestheAndReaniTreatMatrials = new Array<AnesthesiaAndReanimationTreatmentMaterial>();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.Episode = new Episode();
        this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.ProcedureDoctor = new ResUser();
       // this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.ProcedureDoctor2 = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.anesthesiaReportFormViewModel = this._ViewModel as AnesthesiaReportFormViewModel;
        that._TTObject = this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation;
        if (this.anesthesiaReportFormViewModel == null)
            this.anesthesiaReportFormViewModel = new AnesthesiaReportFormViewModel();
        if (this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation == null)
            this.anesthesiaReportFormViewModel._AnesthesiaAndReanimation = new AnesthesiaAndReanimation();
        let mainSurgeryObjectID = that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation["MainSurgery"];
        if (mainSurgeryObjectID != null && (typeof mainSurgeryObjectID === "string")) {
            let mainSurgery = that.anesthesiaReportFormViewModel.Surgerys.find(o => o.ObjectID.toString() === mainSurgeryObjectID.toString());
             if (mainSurgery) {
                that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.MainSurgery = mainSurgery;
            }
            if (mainSurgery != null) {
                let masterResourceObjectID = mainSurgery["MasterResource"];
                if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
                    let masterResource = that.anesthesiaReportFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                     if (masterResource) {
                        mainSurgery.MasterResource = masterResource;
                    }
                }
            }
            if (mainSurgery != null) {
                let surgeryRoomObjectID = mainSurgery["SurgeryRoom"];
                if (surgeryRoomObjectID != null && (typeof surgeryRoomObjectID === "string")) {
                    let surgeryRoom = that.anesthesiaReportFormViewModel.ResSurgeryRooms.find(o => o.ObjectID.toString() === surgeryRoomObjectID.toString());
                     if (surgeryRoom) {
                        mainSurgery.SurgeryRoom = surgeryRoom;
                    }
                }
            }
            if (mainSurgery != null) {
                mainSurgery.SurgeryProcedures = that.anesthesiaReportFormViewModel.GridSurgeryProceduresGridList;
                for (let detailItem of that.anesthesiaReportFormViewModel.GridSurgeryProceduresGridList) {
                    let procedureObjectObjectID = detailItem["ProcedureObject"];
                    if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                        let procedureObject = that.anesthesiaReportFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                         if (procedureObject) {
                            detailItem.ProcedureObject = procedureObject;
                        }
                    }
                    let ayniFarkliKesiObjectID = detailItem["AyniFarkliKesi"];
                    if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === "string")) {
                        let ayniFarkliKesi = that.anesthesiaReportFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
                         if (ayniFarkliKesi) {
                            detailItem.AyniFarkliKesi = ayniFarkliKesi;
                        }
                    }
                    let departmentObjectID = detailItem["Department"];
                    if (departmentObjectID != null && (typeof departmentObjectID === "string")) {
                        let department = that.anesthesiaReportFormViewModel.ResSections.find(o => o.ObjectID.toString() === departmentObjectID.toString());
                         if (department) {
                            detailItem.Department = department;
                        }
                    }
                }
            }
            if (mainSurgery != null) {
                let surgeryDeskObjectID = mainSurgery["SurgeryDesk"];
                if (surgeryDeskObjectID != null && (typeof surgeryDeskObjectID === "string")) {
                    let surgeryDesk = that.anesthesiaReportFormViewModel.ResSurgeryDesks.find(o => o.ObjectID.toString() === surgeryDeskObjectID.toString());
                     if (surgeryDesk) {
                        mainSurgery.SurgeryDesk = surgeryDesk;
                    }
                }
            }
        }
        let resUserObjectID = that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation["ResUser"];
        if (resUserObjectID != null && (typeof resUserObjectID === "string")) {
            let resUser = that.anesthesiaReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
             if (resUser) {
                that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.ResUser = resUser;
            }
        }
        that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnesthesiaPersonnels = that.anesthesiaReportFormViewModel.GridAnesthesiaPersonnelsGridList;
        for (let detailItem of that.anesthesiaReportFormViewModel.GridAnesthesiaPersonnelsGridList) {
            let anesthesiaPersonnelObjectID = detailItem["AnesthesiaPersonnel"];
            if (anesthesiaPersonnelObjectID != null && (typeof anesthesiaPersonnelObjectID === "string")) {
                let anesthesiaPersonnel = that.anesthesiaReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === anesthesiaPersonnelObjectID.toString());
                 if (anesthesiaPersonnel) {
                    detailItem.AnesthesiaPersonnel = anesthesiaPersonnel;
                }
            }
        }

        that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures = that.anesthesiaReportFormViewModel.GridAnesthesiaProceduresGridList;
        for (let detailItem of that.anesthesiaReportFormViewModel.GridAnesthesiaProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                let procedureObject = that.anesthesiaReportFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                let procedureDoctor = that.anesthesiaReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                 if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.AnestheAndReaniTreatMatrials = that.anesthesiaReportFormViewModel.GridAnesthesiaExpendsGridList;
        for (let detailItem of that.anesthesiaReportFormViewModel.GridAnesthesiaExpendsGridList) {
            let storeObjectID = detailItem["Store"];
            if (storeObjectID != null && (typeof storeObjectID === "string")) {
                let store = that.anesthesiaReportFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                 if (store) {
                    detailItem.Store = store;
                }
            }
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.anesthesiaReportFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.anesthesiaReportFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.anesthesiaReportFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let malzemeTuruObjectID = detailItem["MalzemeTuru"];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === "string")) {
                let malzemeTuru = that.anesthesiaReportFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                 if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.anesthesiaReportFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        let episodeObjectID = that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.anesthesiaReportFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.Episode = episode;
            }
        }
        let procedureDoctorObjectID = that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.anesthesiaReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.ProcedureDoctor = procedureDoctor;
            }
        }
        //let procedureDoctor2ObjectID = that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation["ProcedureDoctor2"];
        //if (procedureDoctor2ObjectID != null && (typeof procedureDoctor2ObjectID === "string")) {
        //    let procedureDoctor2 = that.anesthesiaReportFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctor2ObjectID.toString());
        //    that.anesthesiaReportFormViewModel._AnesthesiaAndReanimation.ProcedureDoctor2 = procedureDoctor2;
        //}

    }

    async ngOnInit()  {
        let that = this;
        await this.load(AnesthesiaReportFormViewModel);
  
    }


    public onAnesteziTeknigiChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.AnesthesiaTechnique != event) {
                this._AnesthesiaAndReanimation.AnesthesiaTechnique = event;
            }
        }
    }

    public onAnesthesiaEndDateTimeChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.AnesthesiaEndDateTime != event) {
                this._AnesthesiaAndReanimation.AnesthesiaEndDateTime = event;
            }
        }
    }

    public onAnesthesiaReportChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.AnesthesiaReport != event) {
                this._AnesthesiaAndReanimation.AnesthesiaReport = event;
            }
        }
    }

    public onAnesthesiaReportDateChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.AnesthesiaReportDate != event) {
                this._AnesthesiaAndReanimation.AnesthesiaReportDate = event;
            }
        }
    }

    public async onAnesthesiaStartDateTimeChanged(event) {
        if (event != null) {
            if (this._AnesthesiaAndReanimation.ProcedureDoctor != null) {
                let a = await CommonService.PersonelIzinKontrol(this._AnesthesiaAndReanimation.ProcedureDoctor.ObjectID, event.value);
                if (a) {
                    this.messageService.showInfo(this._AnesthesiaAndReanimation.ProcedureDoctor.Name + " isimli anestezi uzmanı izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._AnesthesiaAndReanimation.ProcedureDoctor = null;
                    }, 500);

                }
            }
        }
    }

    public onASAScoreChanged(event): void {
        if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ASAScore != event) {
            this._AnesthesiaAndReanimation.ASAScore = event;
        }
    }

    public onASATypeChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ASAType != event) {
                this._AnesthesiaAndReanimation.ASAType = event;
            }
        }
    }

    public onHasComplicationChanged(event): void {
        if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.HasComplication != event) {
            this._AnesthesiaAndReanimation.HasComplication = event;
        }
    }

    public onComplicationDescriptionChanged(event): void {
        if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ComplicationDescription != event) {
            this._AnesthesiaAndReanimation.ComplicationDescription = event;
        }
    }


    public onIsTreatmentMaterialEmptyChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.IsTreatmentMaterialEmpty != event) {
                this._AnesthesiaAndReanimation.IsTreatmentMaterialEmpty = event;
            }
        }
    }

    public onLaparoscopyChanged(event): void {
        if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.Laparoscopy != event) {
            this._AnesthesiaAndReanimation.Laparoscopy = event;
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null &&
                this._AnesthesiaAndReanimation.MainSurgery != null && this._AnesthesiaAndReanimation.MainSurgery.MasterResource != event) {
                this._AnesthesiaAndReanimation.MainSurgery.MasterResource = event;
            }
        }
    }

    public onPlannedAnesthsiaDateChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.PlannedAnesthesiaDate != event) {
                this._AnesthesiaAndReanimation.PlannedAnesthesiaDate = event;
            }
        }
    }

    //public onProcedureDoctor2Changed(event): void {
    //    if (event != null) {
    //        if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ProcedureDoctor2 != event) {
    //            this._AnesthesiaAndReanimation.ProcedureDoctor2 = event;
    //        }
    //    }
    //}

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ProcedureDoctor != event) {
                this._AnesthesiaAndReanimation.ProcedureDoctor = event;

                if (this._AnesthesiaAndReanimation.AnesthesiaStartDateTime != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._AnesthesiaAndReanimation.ProcedureDoctor.ObjectID, this._AnesthesiaAndReanimation.AnesthesiaStartDateTime);
                    if (a) {
                        this.messageService.showInfo(this._AnesthesiaAndReanimation.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._AnesthesiaAndReanimation.ProcedureDoctor = null;
                        }, 500);

                    }
                }
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ProtocolNo != event) {
                this._AnesthesiaAndReanimation.ProtocolNo = event;
            }
        }
    }

    public onReasonOfCancelChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ReasonOfCancel != event) {
                this._AnesthesiaAndReanimation.ReasonOfCancel = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.RequestDate != event) {
                this._AnesthesiaAndReanimation.RequestDate = event;
            }
        }
    }

    public onSurgeryDeskChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null &&
                this._AnesthesiaAndReanimation.MainSurgery != null && this._AnesthesiaAndReanimation.MainSurgery.SurgeryDesk != event) {
                this._AnesthesiaAndReanimation.MainSurgery.SurgeryDesk = event;
            }
        }
    }

    public onScarTypeChanged(event): void {
        if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ScarType != event) {
            this._AnesthesiaAndReanimation.ScarType = event;
        }
    }

    public onSurgeryRoomChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null &&
                this._AnesthesiaAndReanimation.MainSurgery != null && this._AnesthesiaAndReanimation.MainSurgery.SurgeryRoom != event) {
                this._AnesthesiaAndReanimation.MainSurgery.SurgeryRoom = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null &&
                this._AnesthesiaAndReanimation.MainSurgery != null && this._AnesthesiaAndReanimation.MainSurgery.SurgeryStartTime != event) {
                this._AnesthesiaAndReanimation.MainSurgery.SurgeryStartTime = event;
            }
        }
    }

    public onttdatetimepicker2Changed(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null &&
                this._AnesthesiaAndReanimation.MainSurgery != null && this._AnesthesiaAndReanimation.MainSurgery.SurgeryEndTime != event) {
                this._AnesthesiaAndReanimation.MainSurgery.SurgeryEndTime = event;
            }
        }
    }

    public onTTListBoxDrAnesteziTescilNoChanged(event): void {
        if (event != null) {
            if (this._AnesthesiaAndReanimation != null && this._AnesthesiaAndReanimation.ResUser != event) {
                this._AnesthesiaAndReanimation.ResUser = event;
            }
        }
    }



    GridAnesthesiaExpends_CellValueChangedEmitted(data: any) {
        if (data && this.GridAnesthesiaExpends_CellValueChanged && data.Row && data.Column) {
            this.GridAnesthesiaExpends.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.GridAnesthesiaExpends_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.PlannedAnesthsiaDate, "Value", this.__ttObject, "PlannedAnesthesiaDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.IsTreatmentMaterialEmpty, "Value", this.__ttObject, "IsTreatmentMaterialEmpty");
        redirectProperty(this.HasComplication, "Value", this.__ttObject, "HasComplication");
      redirectProperty(this.ComplicationDescription, "Text", this.__ttObject, "ComplicationDescription");
        redirectProperty(this.AnesthesiaStartDateTime, "Value", this.__ttObject, "AnesthesiaStartDateTime");
        redirectProperty(this.AnesthesiaEndDateTime, "Value", this.__ttObject, "AnesthesiaEndDateTime");
        redirectProperty(this.AnesthesiaReportDate, "Value", this.__ttObject, "AnesthesiaReportDate");
        redirectProperty(this.AnesthesiaReport, "Rtf", this.__ttObject, "AnesthesiaReport");
        redirectProperty(this.AnesteziTeknigi, "Value", this.__ttObject, "AnesthesiaTechnique");
        redirectProperty(this.ASAType, "Value", this.__ttObject, "ASAType");
        redirectProperty(this.ASAScore, "Value", this.__ttObject, "ASAScore");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "MainSurgery.SurgeryStartTime");
        redirectProperty(this.ttdatetimepicker2, "Value", this.__ttObject, "MainSurgery.SurgeryEndTime");
        redirectProperty(this.ReasonOfCancel, "Text", this.__ttObject, "ReasonOfCancel");
        redirectProperty(this.Laparoscopy, "Value", this.__ttObject, "Laparoscopy");
        redirectProperty(this.ScarType, "Value", this.__ttObject, "ScarType");
    }

    public initFormControls(): void {
        
        this.Laparoscopy = new TTVisual.TTEnumComboBox();
        this.Laparoscopy.DataTypeName = "AnesthesiaLaparoscopyEnum";
        this.Laparoscopy.Name = "Laparoscopy";
        this.Laparoscopy.TabIndex = 129;

        this.ScarType = new TTVisual.TTEnumComboBox();
        this.ScarType.DataTypeName = "AnesthesiaScarEnum";
        this.ScarType.Name = "ScarType";
        this.ScarType.TabIndex = 127;

        this.ASAScore = new TTVisual.TTEnumComboBox();
        this.ASAScore.DataTypeName = "AnesthesiaASAScoreEnum";
        this.ASAScore.Name = "ASAScore";
        this.ASAScore.TabIndex = 125;

        this.HasComplication = new TTVisual.TTCheckBox();
        this.HasComplication.Value = false;
        this.HasComplication.Title = i18n("M17725", "Anestezi Komplikasyonu Var");
        this.HasComplication.Name = "HasComplication";
        this.HasComplication.TabIndex = 122;

        this.ComplicationDescription = new TTVisual.TTTextBox();
        this.ComplicationDescription.Multiline = true;
        this.ComplicationDescription.Name = "ComplicationDescription";
        this.ComplicationDescription.TabIndex = 123;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M11006", "Anestezi Tekniği");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 104;

        this.AnesteziTeknigi = new TTVisual.TTEnumComboBox();
        this.AnesteziTeknigi.DataTypeName = "AnesthesiaTechniqueEnum";
        this.AnesteziTeknigi.Required = true;
        this.AnesteziTeknigi.BackColor = "#FFE3C6";
        this.AnesteziTeknigi.Name = "AnesteziTeknigi";
        this.AnesteziTeknigi.TabIndex = 6;

        this.AnesthesiaReport = new TTVisual.TTRichTextBoxControl();
        this.AnesthesiaReport.DisplayText = i18n("M10997", "Anestezi Raporu");
        this.AnesthesiaReport.TemplateGroupName = "ANESTHESIAREPORT";
        this.AnesthesiaReport.BackColor = "#FFFFFF";
        this.AnesthesiaReport.Name = "AnesthesiaReport";
        this.AnesthesiaReport.TabIndex = 8;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M20401", "Planlanan Uygulama Tarihi");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 101;

        this.PlannedAnesthsiaDate = new TTVisual.TTDateTimePicker();
        this.PlannedAnesthsiaDate.BackColor = "#F0F0F0";
        this.PlannedAnesthsiaDate.CustomFormat = "";
        this.PlannedAnesthsiaDate.Format = DateTimePickerFormat.Long;
        this.PlannedAnesthsiaDate.Enabled = false;
        this.PlannedAnesthsiaDate.Name = "PlannedAnesthsiaDate";
        this.PlannedAnesthsiaDate.TabIndex = 100;

        this.LabelRequest = new TTVisual.TTLabel();
        this.LabelRequest.Text = i18n("M10979", "Anestezi İstek Tarihi");
        this.LabelRequest.BackColor = "#DCDCDC";
        this.LabelRequest.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelRequest.ForeColor = "#000000";
        this.LabelRequest.Name = "LabelRequest";
        this.LabelRequest.TabIndex = 98;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 99;
        this.RequestDate.ReadOnly = true;

        this.labelAnesthesiaStartDateTime = new TTVisual.TTLabel();
        this.labelAnesthesiaStartDateTime.Text = i18n("M10961", "Anestezi Başlama Tarihi");
        this.labelAnesthesiaStartDateTime.BackColor = "#DCDCDC";
        this.labelAnesthesiaStartDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelAnesthesiaStartDateTime.ForeColor = "#000000";
        this.labelAnesthesiaStartDateTime.Name = "labelAnesthesiaStartDateTime";
        this.labelAnesthesiaStartDateTime.TabIndex = 25;

        this.AnesthesiaStartDateTime = new TTVisual.TTDateTimePicker();
        this.AnesthesiaStartDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.AnesthesiaStartDateTime.Format = DateTimePickerFormat.Custom;
        this.AnesthesiaStartDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaStartDateTime.Name = "AnesthesiaStartDateTime";
        this.AnesthesiaStartDateTime.TabIndex = 0;

        this.labelAnesthesiaEndDateTime = new TTVisual.TTLabel();
        this.labelAnesthesiaEndDateTime.Text = i18n("M10962", "Anestezi Bitiş Tarihi");
        this.labelAnesthesiaEndDateTime.BackColor = "#DCDCDC";
        this.labelAnesthesiaEndDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelAnesthesiaEndDateTime.ForeColor = "#000000";
        this.labelAnesthesiaEndDateTime.Name = "labelAnesthesiaEndDateTime";
        this.labelAnesthesiaEndDateTime.TabIndex = 31;

        this.TabSubaction = new TTVisual.TTTabControl();
        this.TabSubaction.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabSubaction.Name = "TabSubaction";
        this.TabSubaction.TabIndex = 8;

        this.SurgeryInfo = new TTVisual.TTTabPage();
        this.SurgeryInfo.DisplayIndex = 0;
        this.SurgeryInfo.TabIndex = 1;
        this.SurgeryInfo.Text = i18n("M10802", "Ameliyat Bilgileri");
        this.SurgeryInfo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryInfo.Name = "SurgeryInfo";

        this.ttlabeldrAnesteziTescilNo = new TTVisual.TTLabel();
        this.ttlabeldrAnesteziTescilNo.Text = i18n("M10968", "Anestezi Dr. Tescil No.");
        this.ttlabeldrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabeldrAnesteziTescilNo.Name = "ttlabeldrAnesteziTescilNo";
        this.ttlabeldrAnesteziTescilNo.TabIndex = 101;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M10854", "Ameliyathane");
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 95;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.ListDefName = "SurgreyDepartmentListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 96;

        this.ttdatetimepicker2 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker2.BackColor = "#F0F0F0";
        this.ttdatetimepicker2.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker2.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttdatetimepicker2.Name = "ttdatetimepicker2";
        this.ttdatetimepicker2.TabIndex = 99;

        this.SurgeryRoom = new TTVisual.TTObjectListBox();
        this.SurgeryRoom.LinkedControlName = "MasterResource";
        this.SurgeryRoom.ListDefName = "SurgeryRoomListDefinition";
        this.SurgeryRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryRoom.Name = "SurgeryRoom";
        this.SurgeryRoom.TabIndex = 80;
        this.SurgeryRoom.ReadOnly = true;
        this.SurgeryRoom.Enabled = false;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M10859", "Ameliyatı Başlatma Tarih/Saat");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 92;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 90;

        this.labelRoom = new TTVisual.TTLabel();
        this.labelRoom.Text = i18n("M21284", "Salon");
        this.labelRoom.BackColor = "#DCDCDC";
        this.labelRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoom.ForeColor = "#000000";
        this.labelRoom.Name = "labelRoom";
        this.labelRoom.TabIndex = 84;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M10861", "Ameliyatı Bitirme Tarih/Saat");
        this.ttlabel5.BackColor = "#DCDCDC";
        this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 100;

        this.GridSurgeryProcedures = new TTVisual.TTGrid();
        this.GridSurgeryProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridSurgeryProcedures.Name = "GridSurgeryProcedures";
        this.GridSurgeryProcedures.TabIndex = 0;
        this.GridSurgeryProcedures.AllowUserToAddRows = false;
        this.GridSurgeryProcedures.AllowUserToDeleteRows = false;
        this.GridSurgeryProcedures.ShowTotalNumberOfRows = false;

        this.CAActionDate = new TTVisual.TTDateTimePickerColumn();
        this.CAActionDate.Format = DateTimePickerFormat.Custom;
        this.CAActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.CAActionDate.DataMember = "ActionDate";
        this.CAActionDate.DisplayIndex = 0;
        this.CAActionDate.HeaderText = i18n("M27047", "Tarih/Saat");
        this.CAActionDate.Name = "CAActionDate";
        this.CAActionDate.ReadOnly = true;
        this.CAActionDate.Width = "10%";

        this.CAProcedureObject = new TTVisual.TTListBoxColumn();
        this.CAProcedureObject.ListDefName = "SurgeryListDefinition";
        this.CAProcedureObject.DataMember = "ProcedureObject";
        this.CAProcedureObject.DisplayIndex = 1;
        this.CAProcedureObject.HeaderText = i18n("M27385", "Ameliyat");
        this.CAProcedureObject.Name = "CAProcedureObject";
        this.CAProcedureObject.ReadOnly = true;
        this.CAProcedureObject.Width = "30%";

        this.AyniFarkliKesi = new TTVisual.TTListBoxColumn();
        this.AyniFarkliKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.AyniFarkliKesi.DataMember = "AyniFarkliKesi";
        this.AyniFarkliKesi.DisplayIndex = 2;
        this.AyniFarkliKesi.HeaderText = i18n("M22824", "Kesi Bilgisi");
        this.AyniFarkliKesi.Name = "AyniFarkliKesi";
        this.AyniFarkliKesi.ReadOnly = true;
        this.AyniFarkliKesi.Width = "15%";

        this.Position = new TTVisual.TTEnumComboBoxColumn();
        this.Position.DataTypeName = "SurgeryLeftRight";
        this.Position.DataMember = "Position";
        this.Position.DisplayIndex = 3;
        this.Position.HeaderText = i18n("M22824", "Taraf");
        this.Position.Name = "Position";
        this.Position.ReadOnly = true;
        this.Position.ToolTipText = i18n("M21146", "Sağ taraf, sol taraf");
        this.Position.Width = "15%";

        this.EntryDepartment = new TTVisual.TTListBoxColumn();
        this.EntryDepartment.ListDefName = "ResourceListDefinition";
        this.EntryDepartment.DataMember = "Department";
        this.EntryDepartment.DisplayIndex = 4;
        this.EntryDepartment.HeaderText = i18n("M10862", "Ameliyatı Gerçekleştiren Birim");
        this.EntryDepartment.Name = "EntryDepartment";
        this.EntryDepartment.ReadOnly = true;
        this.EntryDepartment.Width = "20%";

        //this.Euroscore = new TTVisual.TTEnumComboBoxColumn();
        //this.Euroscore.DataTypeName = "MedulaEuroScoreEnum";
        //this.Euroscore.DataMember = "MEDULAEUROSCORE";
        //this.Euroscore.DisplayIndex = 5;
        //this.Euroscore.HeaderText = "Euroscore";
        //this.Euroscore.Name = "Euroscore";
        //this.Euroscore.ReadOnly = true;
        //this.Euroscore.Width = 100;

        this.TTListBoxDrAnesteziTescilNo = new TTVisual.TTObjectListBox();
        this.TTListBoxDrAnesteziTescilNo.ListDefName = "ResUserListDefinition";
        this.TTListBoxDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxDrAnesteziTescilNo.ForeColor = "#000000";
        this.TTListBoxDrAnesteziTescilNo.Name = "TTListBoxDrAnesteziTescilNo";
        this.TTListBoxDrAnesteziTescilNo.TabIndex = 13;

        this.labelSurgeryDesk = new TTVisual.TTLabel();
        this.labelSurgeryDesk.Text = i18n("M18680", "Masa");
        this.labelSurgeryDesk.Name = "labelSurgeryDesk";
        this.labelSurgeryDesk.TabIndex = 106;

        this.SurgeryDesk = new TTVisual.TTObjectListBox();
        this.SurgeryDesk.LinkedControlName = "SurgeryDesk";
        this.SurgeryDesk.ReadOnly = true;
        this.SurgeryDesk.ListDefName = "SurgeryDeskListDefinition";
        this.SurgeryDesk.Name = "SurgeryDesk";
        this.SurgeryDesk.TabIndex = 105;
        this.SurgeryDesk.Enabled = false;

        this.AnesthesiaTeam = new TTVisual.TTTabPage();
        this.AnesthesiaTeam.DisplayIndex = 1;
        this.AnesthesiaTeam.TabIndex = 0;
        this.AnesthesiaTeam.Text = i18n("M10970", "Anestezi Ekibi");
        this.AnesthesiaTeam.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaTeam.Name = "AnesthesiaTeam";

        this.GridAnesthesiaPersonnels = new TTVisual.TTGrid();
        this.GridAnesthesiaPersonnels.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridAnesthesiaPersonnels.Name = "GridAnesthesiaPersonnels";
        this.GridAnesthesiaPersonnels.TabIndex = 0;
        this.GridAnesthesiaPersonnels.Height = 120;
        this.GridAnesthesiaPersonnels.ShowFilterCombo = !this.ReadOnly;
        this.GridAnesthesiaPersonnels.FilterColumnName = "AnesthesiaPersonnel";
        this.GridAnesthesiaPersonnels.FilterLabel = i18n("M10970", "Anestezi Ekibi"); //
        this.GridAnesthesiaPersonnels.Filter = { ListDefName: "AnaesthesiaTeamListDefinition" };
        this.GridAnesthesiaPersonnels.AllowUserToAddRows = false;
        this.GridAnesthesiaPersonnels.AllowUserToDeleteRows = !this.ReadOnly;
        this.GridAnesthesiaPersonnels.DeleteButtonWidth = "5%";
        this.GridAnesthesiaPersonnels.ShowTotalNumberOfRows = false;
        this.GridAnesthesiaPersonnels.IsFilterLabelSingleLine = false;
        this.GridAnesthesiaPersonnels.ReadOnly = this.ReadOnly;
        this.GridAnesthesiaPersonnels.DeleteButtonWidth = !this.ReadOnly;


        this.AnesthesiaPersonnel = new TTVisual.TTListBoxColumn();
        this.AnesthesiaPersonnel.ListDefName = "AnaesthesiaTeamListDefinition";
        this.AnesthesiaPersonnel.DataMember = "AnesthesiaPersonnel";
        this.AnesthesiaPersonnel.DisplayIndex = 0;
        this.AnesthesiaPersonnel.HeaderText = "Personel";
        this.AnesthesiaPersonnel.Name = "AnesthesiaPersonnel";
        this.AnesthesiaPersonnel.Width = "90%";


        //this.Role = new TTVisual.TTTextBoxColumn();
        //this.Role.DataMember = "Role";
        //this.Role.DisplayIndex = 1;
        //this.Role.HeaderText = "Görevi";
        //this.Role.Name = "Role";
        //this.Role.Width = "20%";


        this.AnesthesiaProcedure = new TTVisual.TTTabPage();
        this.AnesthesiaProcedure.DisplayIndex = 3;
        this.AnesthesiaProcedure.TabIndex = 0;
        this.AnesthesiaProcedure.Text = i18n("M10980", "Anestezi İşlemi");
        this.AnesthesiaProcedure.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaProcedure.Name = "AnesthesiaProcedure";

        this.GridAnesthesiaProcedures = new TTVisual.TTGrid();
        this.GridAnesthesiaProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridAnesthesiaProcedures.ReadOnly = false;
        this.GridAnesthesiaProcedures.Name = "GridAnesthesiaProcedures";
        this.GridAnesthesiaProcedures.TabIndex = 0;
        this.GridAnesthesiaProcedures.ShowTotalNumberOfRows = false;

        this.ACActionDate = new TTVisual.TTDateTimePickerColumn();
        this.ACActionDate.Format = DateTimePickerFormat.Long;
        this.ACActionDate.DataMember = "ActionDate";
        this.ACActionDate.DisplayIndex = 0;
        this.ACActionDate.HeaderText = "Tarih/Saat";
        this.ACActionDate.Name = "ACActionDate";
        this.ACActionDate.Width = "20%";

        this.ACProcedureObject = new TTVisual.TTListBoxColumn();
        this.ACProcedureObject.ListDefName = "AnesthesiaListDefinition";
        this.ACProcedureObject.DataMember = "ProcedureObject";
        this.ACProcedureObject.DisplayIndex = 1;
        this.ACProcedureObject.HeaderText = i18n("M10980", "Anestezi İşlemi");
        this.ACProcedureObject.Name = "ACProcedureObject";
        this.ACProcedureObject.Width = "50%";

        //this.ACProcedureDoctor = new TTVisual.TTListBoxColumn();
        //this.ACProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";SW
        //this.ACProcedureDoctor.DataMember = "ProcedureDoctor";
        //this.ACProcedureDoctor.DisplayIndex = 2;
        //this.ACProcedureDoctor.HeaderText = "Sorumlu Anestezi Uzmanı";
        //this.ACProcedureDoctor.Name = "ACProcedureDoctor";
        //this.ACProcedureDoctor.Width = 140;

        this.ACNote = new TTVisual.TTTextBoxColumn();
        this.ACNote.DataMember = "Note";
        this.ACNote.DisplayIndex = 3;
        this.ACNote.HeaderText = i18n("M10469", "Açıklama");
        this.ACNote.Name = "ACNote";
        this.ACNote.Width = "30%";

        this.TreatmentMaterial = new TTVisual.TTTabPage();
        this.TreatmentMaterial.DisplayIndex = 4;
        this.TreatmentMaterial.TabIndex = 0;
        this.TreatmentMaterial.Text = i18n("M21320", "Sarf Giriş");
        this.TreatmentMaterial.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TreatmentMaterial.Name = "TreatmentMaterial";

        this.GridAnesthesiaExpends = new TTVisual.TTGrid();
        this.GridAnesthesiaExpends.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridAnesthesiaExpends.Name = "GridAnesthesiaExpends";
        this.GridAnesthesiaExpends.TabIndex = 0;

        this.SMActionDate = new TTVisual.TTDateTimePickerColumn();
        this.SMActionDate.Format = DateTimePickerFormat.Long;
        this.SMActionDate.DataMember = "ActionDate";
        this.SMActionDate.DisplayIndex = 0;
        this.SMActionDate.HeaderText = "Tarih/Saat";
        this.SMActionDate.Name = "SMActionDate";
        this.SMActionDate.Width = 180;

        this.SMStore = new TTVisual.TTListBoxColumn();
        this.SMStore.ListDefName = "StoreListDefinition";
        this.SMStore.DataMember = "Store";
        this.SMStore.DisplayIndex = 1;
        this.SMStore.HeaderText = i18n("M12615", "Depo");
        this.SMStore.Name = "SMStore";
        this.SMStore.Width = 200;

        this.SMMaterial = new TTVisual.TTListBoxColumn();
        this.SMMaterial.AllowMultiSelect = true;
        this.SMMaterial.ListDefName = "ConsumableMaterialAndDrugList";
        this.SMMaterial.DataMember = "Material";
        this.SMMaterial.DisplayIndex = 2;
        this.SMMaterial.HeaderText = i18n("M21314", "Sarf Edilen Malzeme");
        this.SMMaterial.Name = "SMMaterial";
        this.SMMaterial.Width = 325;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 3;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 4;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.SMAmount = new TTVisual.TTTextBoxColumn();
        this.SMAmount.DataMember = "Amount";
        this.SMAmount.DisplayIndex = 5;
        this.SMAmount.HeaderText = i18n("M19030", "Miktar");
        this.SMAmount.Name = "SMAmount";
        this.SMAmount.Width = 75;

        this.UBBCode = new TTVisual.TTTextBoxColumn();
        this.UBBCode.DataMember = "UBBCode";
        this.UBBCode.DisplayIndex = 6;
        this.UBBCode.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCode.Name = "UBBCode";
        this.UBBCode.Width = 100;

        this.malzemeSatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.malzemeSatinAlisTarihi.DataMember = "MalzemeSatinAlisTarihi";
        this.malzemeSatinAlisTarihi.DisplayIndex = 7;
        this.malzemeSatinAlisTarihi.HeaderText = i18n("M18604", "Malzeme Satın Alış Tarihi");
        this.malzemeSatinAlisTarihi.Name = "malzemeSatinAlisTarihi";
        this.malzemeSatinAlisTarihi.Visible = false;
        this.malzemeSatinAlisTarihi.Width = 100;

        this.kodsuzMalzemeFiyati = new TTVisual.TTTextBoxColumn();
        this.kodsuzMalzemeFiyati.DataMember = "KodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyati.DisplayIndex = 8;
        this.kodsuzMalzemeFiyati.HeaderText = i18n("M17688", "Kodsuz Malzeme Fiyatı");
        this.kodsuzMalzemeFiyati.Name = "kodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyati.Visible = false;
        this.kodsuzMalzemeFiyati.Width = 100;

        this.kdv = new TTVisual.TTTextBoxColumn();
        this.kdv.DataMember = "Kdv";
        this.kdv.DisplayIndex = 9;
        this.kdv.HeaderText = "KDV";
        this.kdv.Name = "kdv";
        this.kdv.Visible = false;
        this.kdv.Width = 100;

        this.malzemeTuru = new TTVisual.TTListBoxColumn();
        this.malzemeTuru.ListDefName = "MalzemeTuruListDefinition";
        this.malzemeTuru.DataMember = "MalzemeTuru";
        this.malzemeTuru.DisplayIndex = 10;
        this.malzemeTuru.HeaderText = i18n("M18614", "Malzeme Türü");
        this.malzemeTuru.Name = "malzemeTuru";
        this.malzemeTuru.Visible = false;
        this.malzemeTuru.Width = 100;

        this.malzemeBrans = new TTVisual.TTTextBoxColumn();
        this.malzemeBrans.DataMember = "MalzemeBrans";
        this.malzemeBrans.DisplayIndex = 11;
        this.malzemeBrans.HeaderText = i18n("M18636", "Malzemenin Branşı");
        this.malzemeBrans.Name = "malzemeBrans";
        this.malzemeBrans.Visible = false;
        this.malzemeBrans.Width = 100;

        this.malzemeOzelDurum = new TTVisual.TTListBoxColumn();
        this.malzemeOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.malzemeOzelDurum.DataMember = "OzelDurum";
        this.malzemeOzelDurum.DisplayIndex = 12;
        this.malzemeOzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.malzemeOzelDurum.Name = "malzemeOzelDurum";
        this.malzemeOzelDurum.Visible = false;
        this.malzemeOzelDurum.Width = 100;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 88;

        this.ReasonOfCancel = new TTVisual.TTTextBox();
        this.ReasonOfCancel.Multiline = true;
        this.ReasonOfCancel.BackColor = "#F0F0F0";
        this.ReasonOfCancel.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReasonOfCancel.Name = "ReasonOfCancel";
        this.ReasonOfCancel.TabIndex = 6;



        this.AnesthesiaEndDateTime = new TTVisual.TTDateTimePicker();
        this.AnesthesiaEndDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.AnesthesiaEndDateTime.Format = DateTimePickerFormat.Custom;
        this.AnesthesiaEndDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaEndDateTime.Name = "AnesthesiaEndDateTime";
        this.AnesthesiaEndDateTime.TabIndex = 1;

        this.lableAnsteziReportNo = new TTVisual.TTLabel();
        this.lableAnsteziReportNo.Text = i18n("M10996", "Anestezi Rapor Tarihi");
        this.lableAnsteziReportNo.BackColor = "#DCDCDC";
        this.lableAnsteziReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lableAnsteziReportNo.ForeColor = "#000000";
        this.lableAnsteziReportNo.Name = "lableAnsteziReportNo";
        this.lableAnsteziReportNo.TabIndex = 25;

        this.AnesthesiaReportDate = new TTVisual.TTDateTimePicker();
        this.AnesthesiaReportDate.CustomFormat = "";
        this.AnesthesiaReportDate.Format = DateTimePickerFormat.Long;
        this.AnesthesiaReportDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AnesthesiaReportDate.Name = "AnesthesiaReportDate";
        this.AnesthesiaReportDate.TabIndex = 2;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 91;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M22134", "Sorumlu Anestezi Uzmanı");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 121;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 3;

        this.labelASAType = new TTVisual.TTLabel();
        this.labelASAType.Text = i18n("M11119", "ASA Kriteri");
        this.labelASAType.Name = "labelASAType";
        this.labelASAType.TabIndex = 22;

        this.ASAType = new TTVisual.TTEnumComboBox();
        this.ASAType.DataTypeName = "AnesthesiaASATypeEnum";
        this.ASAType.Name = "ASAType";
        this.ASAType.TabIndex = 7;

        this.IsTreatmentMaterialEmpty = new TTVisual.TTCheckBox();
        this.IsTreatmentMaterialEmpty.Value = false;
        this.IsTreatmentMaterialEmpty.Text = i18n("M23022", "Tedavi Sarfı Yok");
        this.IsTreatmentMaterialEmpty.Name = "IsTreatmentMaterialEmpty";
        this.IsTreatmentMaterialEmpty.TabIndex = 3;

        //this.labelProcedureDoctor2 = new TTVisual.TTLabel();
        //this.labelProcedureDoctor2.Text = "2.Sorumlu Anestezi Uzmanı";
        //this.labelProcedureDoctor2.BackColor = "#DCDCDC";
        //this.labelProcedureDoctor2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.labelProcedureDoctor2.ForeColor = "#000000";
        //this.labelProcedureDoctor2.Name = "labelProcedureDoctor2";
        //this.labelProcedureDoctor2.TabIndex = 121;

        //this.ProcedureDoctor2 = new TTVisual.TTObjectListBox();
        //this.ProcedureDoctor2.ListDefName = "SpecialistDoctorListDefinition";
        //this.ProcedureDoctor2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.ProcedureDoctor2.Name = "ProcedureDoctor2";
        //this.ProcedureDoctor2.TabIndex = 3;

        this.lebalReasonOfCancel = new TTVisual.TTLabel();
        this.lebalReasonOfCancel.Text = i18n("M16560", "İptal Sebebi");
        this.lebalReasonOfCancel.BackColor = "#DCDCDC";
        this.lebalReasonOfCancel.ForeColor = "#000000";
        this.lebalReasonOfCancel.Name = "lebalReasonOfCancel";
        this.lebalReasonOfCancel.TabIndex = 117;

        this.GridSurgeryProceduresColumns = [this.CAActionDate, this.CAProcedureObject, this.AyniFarkliKesi, this.Position, this.EntryDepartment]; // this.DescriptionOfObj, this.Euroscore
        this.GridAnesthesiaPersonnelsColumns = [this.AnesthesiaPersonnel]; //, this.Role

        this.GridAnesthesiaProceduresColumns = [this.ACActionDate, this.ACProcedureObject, this.ACNote]; // this.ACProcedureDoctor
        this.GridAnesthesiaExpendsColumns = [this.SMActionDate, this.SMStore, this.SMMaterial, this.Barcode, this.DistributionType, this.SMAmount, this.UBBCode, this.malzemeSatinAlisTarihi, this.kodsuzMalzemeFiyati, this.kdv, this.malzemeTuru, this.malzemeBrans, this.malzemeOzelDurum];
        this.TabSubaction.Controls = [this.SurgeryInfo, this.AnesthesiaTeam, this.AnesthesiaProcedure, this.TreatmentMaterial];
        this.SurgeryInfo.Controls = [this.ttlabeldrAnesteziTescilNo, this.ttlabel3, this.MasterResource, this.ttdatetimepicker2, this.SurgeryRoom, this.ttlabel8, this.ttdatetimepicker1, this.labelRoom, this.ttlabel5, this.GridSurgeryProcedures, this.TTListBoxDrAnesteziTescilNo, this.labelSurgeryDesk, this.SurgeryDesk];
        this.AnesthesiaTeam.Controls = [this.GridAnesthesiaPersonnels];
        this.AnesthesiaProcedure.Controls = [this.GridAnesthesiaProcedures];
        this.TreatmentMaterial.Controls = [this.GridAnesthesiaExpends];
        this.Controls = [this.ScarType, this.Laparoscopy, this.ComplicationDescription, this.HasComplication, this.ttlabel1, this.AnesteziTeknigi, this.AnesthesiaReport, this.ttlabel4, this.PlannedAnesthsiaDate, this.LabelRequest, this.RequestDate, this.labelAnesthesiaStartDateTime, this.AnesthesiaStartDateTime, this.labelAnesthesiaEndDateTime, this.TabSubaction, this.SurgeryInfo, this.ttlabeldrAnesteziTescilNo, this.ttlabel3, this.MasterResource, this.ttdatetimepicker2, this.SurgeryRoom, this.ttlabel8, this.ttdatetimepicker1, this.labelRoom, this.ttlabel5, this.GridSurgeryProcedures, this.CAActionDate, this.CAProcedureObject, this.AyniFarkliKesi, this.Position, this.EntryDepartment, this.TTListBoxDrAnesteziTescilNo, this.labelSurgeryDesk, this.SurgeryDesk, this.AnesthesiaTeam, this.GridAnesthesiaPersonnels, this.AnesthesiaPersonnel, this.AnesthesiaProcedure, this.GridAnesthesiaProcedures, this.ACActionDate, this.ACProcedureObject, this.ACNote, this.TreatmentMaterial, this.GridAnesthesiaExpends, this.SMActionDate, this.SMStore, this.SMMaterial, this.Barcode, this.DistributionType, this.SMAmount, this.UBBCode, this.malzemeSatinAlisTarihi, this.kodsuzMalzemeFiyati, this.kdv, this.malzemeTuru, this.malzemeBrans, this.malzemeOzelDurum, this.ProtocolNo, this.ReasonOfCancel, this.AnesthesiaEndDateTime, this.lableAnsteziReportNo, this.AnesthesiaReportDate, this.labelProtocolNo, this.labelProcedureDoctor, this.ProcedureDoctor, this.ASAScore,  this.labelASAType, this.ASAType, this.IsTreatmentMaterialEmpty, this.lebalReasonOfCancel]; //, this.DescriptionOfObj,this.Role,, this.Euroscore,this.labelProcedureDoctor2, this.ACProcedureDoctor,this.ProcedureDoctor2,

    }


}
