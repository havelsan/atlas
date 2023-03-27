//$EB9DE1CF
import { Component, OnInit, NgZone } from '@angular/core';
import { MorgueProcedureFormViewModel,ObsInput } from './MorgueProcedureFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Morgue } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { CupboardDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DeathReasonDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { MernisDeathReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MorgueDeathType } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOlumNedeniTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOlumYeri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYaralanmaninYeri, Episode, Patient, SKRSILKodlari, SKRSIlceKodlari, MorgueTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { DatePipe } from '@angular/common';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'MorgueProcedureForm',
    templateUrl: './MorgueProcedureForm.html',
    providers: [MessageService,DatePipe]
})
export class MorgueProcedureForm extends EpisodeActionForm implements OnInit {
    AddressOfAdmittedFrom: TTVisual.ITTTextBox;
    CitizenshipNoOfAdmittedFrom: TTVisual.ITTTextBox;
    Cupboard: TTVisual.ITTObjectListBox;
    DateOfDeathReport: TTVisual.ITTDateTimePicker;
    DeathBodyAdmittedFrom: TTVisual.ITTTextBox;
    DeathBodyAdmittedTo: TTVisual.ITTTextBox;
    DeathReasonDiagnosis: TTVisual.ITTGrid;
    DeathReportNo: TTVisual.ITTTextBox;
    DiedClinic: TTVisual.ITTObjectListBox;
    EntryDate: TTVisual.ITTDateTimePickerColumn;
    ExAmount: TTVisual.ITTTextBoxColumn;
    ExMaterials: TTVisual.ITTListBoxColumn;
    ExNotes: TTVisual.ITTTextBoxColumn;
    ExternalDoctorFixed: TTVisual.ITTTextBox;
    ExternalDoctorFixedUniqueNo: TTVisual.ITTTextBox;
    ExternalSenderDoctorMorgueUnR: TTVisual.ITTTextBox;
    ExternalSenderDoctorToMorgue: TTVisual.ITTTextBox;
    FoundationToFixDeath: TTVisual.ITTTextBox;
    InjuryDate: TTVisual.ITTDateTimePicker;
    InjuryExisting: TTVisual.ITTCheckBox;
    labelDateOfDeathReport: TTVisual.ITTLabel;
    labelDateTimeOfDeath: TTVisual.ITTLabel;
    labelDeathReason: TTVisual.ITTLabel;
    labelDeathReasonEvaluation: TTVisual.ITTLabel;
    labelDiedClinic: TTVisual.ITTLabel;
    labelDoctorFixed: TTVisual.ITTLabel;
    labelExternalDoctorFixed: TTVisual.ITTLabel;
    labelExternalDoctorFixedUniqueNo: TTVisual.ITTLabel;
    labelExternalSenderDoctorMorgueUnR: TTVisual.ITTLabel;
    labelExternalSenderDoctorToMorgue: TTVisual.ITTLabel;
    labelInjuryDate: TTVisual.ITTLabel;
    labelMaterialsAdmittedFrom: TTVisual.ITTLabel;
    labelMaterialsAdmittedTo: TTVisual.ITTLabel;
    labelMernisDeathReasons: TTVisual.ITTLabel;
    labelMorgueCupboardNo: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    labelNurse: TTVisual.ITTLabel;
    labelQuarantineCupboardNo: TTVisual.ITTLabel;
    labelSenderDoctor: TTVisual.ITTLabel;
    labelSKRSDeathPlace: TTVisual.ITTLabel;
    labelSKRSDeathReason: TTVisual.ITTLabel;
    labelSKRSInjuryPlace: TTVisual.ITTLabel;
    Materials: TTVisual.ITTTabPage;
    MaterialsAdmittedFrom: TTVisual.ITTObjectListBox;
    MaterialsAdmittedTo: TTVisual.ITTTextBox;
    MaterialsGrid: TTVisual.ITTGrid;
    MernisDeathReasons: TTVisual.ITTObjectListBox;
    MorgueCupboardNo: TTVisual.ITTTextBox;
    MorgueDeathType: TTVisual.ITTGrid;
    Nurse: TTVisual.ITTObjectListBox;
    PhoneNumberOfAdmittedFrom: TTVisual.ITTTextBox;
    SKRSDeathPlace: TTVisual.ITTObjectListBox;
    SKRSDeathReason: TTVisual.ITTObjectListBox;
    SKRSICDDeathReasonDiagnosis: TTVisual.ITTListBoxColumn;
    SKRSInjuryPlace: TTVisual.ITTObjectListBox;
    SKRSOlumNedeniTuruDeathReasonDiagnosis: TTVisual.ITTListBoxColumn;
    SKRSOlumSekliMorgueDeathType: TTVisual.ITTListBoxColumn;
    TabSubaction: TTVisual.ITTTabControl;
    DateTimeOfDeath: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel29: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttobjectlistbox7: TTVisual.ITTObjectListBox;
    DoctorFixed: TTVisual.ITTObjectListBox;
    ttpanel1: TTVisual.ITTPanel;
    Report: TTVisual.ITTRichTextBoxControl;
    Note: TTVisual.ITTRichTextBoxControl;
    DeathReasonEvaluation: TTVisual.ITTRichTextBoxControl;
    ObjectsFromPatient: TTVisual.ITTTextBox;
    UBBCODE: TTVisual.ITTTextBoxColumn;

    BirthPlace: TTVisual.ITTTextBox;
    BirthDate: TTVisual.ITTDateTimePicker;


    /*MorgueDeliveryForm */
    DeliveredByList: TTVisual.ITTObjectListBox;
    CITIZENSHIPNOOFADMITTED: TTVisual.ITTTextBox;
    TombVillage: TTVisual.ITTTextBox;
    DateOfEntrance: TTVisual.ITTDateTimePicker;
    ADDRESSOFADMITTED: TTVisual.ITTTextBox;
    PHONENUMBEROFADMITTED: TTVisual.ITTTextBox;
    GraveyardPlotNo: TTVisual.ITTTextBox;
    DateOfSentToGrave: TTVisual.ITTDateTimePicker;
    SKRSTombCity: TTVisual.ITTObjectListBox;
    SKRSTombTown: TTVisual.ITTObjectListBox;
    /*MorgueDeliveryForm */

    public DeathReasonDiagnosisColumns = [];
    public MaterialsGridColumns = [];
    public MorgueDeathTypeColumns = [];
    public morgueProcedureFormViewModel: MorgueProcedureFormViewModel = new MorgueProcedureFormViewModel();

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    public showDeliveryForm: boolean = false;
    public IsDeliveryFormHasEmptyFields: boolean = true;
    public get _Morgue(): Morgue {
        return this._TTObject as Morgue;
    }
    private MorgueProcedureForm_DocumentUrl: string = '/api/MorgueService/MorgueProcedureForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService,private sideBarMenuService: ISidebarMenuService, 
        private datePipe: DatePipe,protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.MorgueProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        await super.AfterContextSavedScript(transDef);

        await this.load(MorgueProcedureFormViewModel);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Morgue();
        this.morgueProcedureFormViewModel = new MorgueProcedureFormViewModel();
        this._ViewModel = this.morgueProcedureFormViewModel;
        this.morgueProcedureFormViewModel._Morgue = this._TTObject as Morgue;
        this.morgueProcedureFormViewModel._Morgue.Cupboard = new CupboardDefinition();
        this.morgueProcedureFormViewModel._Morgue.MaterialsAdmittedFrom = new ResUser();
        this.morgueProcedureFormViewModel._Morgue.DeathReasonDiagnosis = new Array<DeathReasonDiagnosis>();
        this.morgueProcedureFormViewModel._Morgue.SKRSInjuryPlace = new SKRSYaralanmaninYeri();
        this.morgueProcedureFormViewModel._Morgue.SKRSDeathReason = new SKRSOlumNedeniTuru();
        this.morgueProcedureFormViewModel._Morgue.SKRSDeathPlace = new SKRSOlumYeri();
        this.morgueProcedureFormViewModel._Morgue.DiedClinic = new ResSection();
        this.morgueProcedureFormViewModel._Morgue.Nurse = new ResUser();
        this.morgueProcedureFormViewModel._Morgue.SenderDoctor = new ResUser();
        this.morgueProcedureFormViewModel._Morgue.DoctorFixed = new ResUser();
        this.morgueProcedureFormViewModel._Morgue.MernisDeathReasons = new MernisDeathReasonDefinition();
        this.morgueProcedureFormViewModel._Morgue.MorgueDeathType = new Array<MorgueDeathType>();
        this.morgueProcedureFormViewModel._Morgue.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
        this.morgueProcedureFormViewModel._Morgue.Episode = new Episode();
        this.morgueProcedureFormViewModel._Morgue.Episode.Patient = new Patient();
        this.morgueProcedureFormViewModel._Morgue.MorgueTreatmentMaterials = new Array<MorgueTreatmentMaterial>();

        /*MorgueDeliveryForm */
        this.morgueProcedureFormViewModel._Morgue.DeliveredBy = new ResUser();
        this.morgueProcedureFormViewModel._Morgue.SKRSTombCity = new SKRSILKodlari();
        this.morgueProcedureFormViewModel._Morgue.SKRSTombTown = new SKRSIlceKodlari();

        /*MorgueDeliveryForm */
    }

    protected loadViewModel() {
        let that = this;
        that.morgueProcedureFormViewModel = this._ViewModel as MorgueProcedureFormViewModel;
        that._TTObject = this.morgueProcedureFormViewModel._Morgue;
        if (this.morgueProcedureFormViewModel == null)
            this.morgueProcedureFormViewModel = new MorgueProcedureFormViewModel();
        if (this.morgueProcedureFormViewModel._Morgue == null)
            this.morgueProcedureFormViewModel._Morgue = new Morgue();
        let cupboardObjectID = that.morgueProcedureFormViewModel._Morgue["Cupboard"];
        if (cupboardObjectID != null && (typeof cupboardObjectID === "string")) {
            let cupboard = that.morgueProcedureFormViewModel.CupboardDefinitions.find(o => o.ObjectID.toString() === cupboardObjectID.toString());
            if (cupboard) {
                that.morgueProcedureFormViewModel._Morgue.Cupboard = cupboard;
            }
        }
        let deliveredByObjectID = that.morgueProcedureFormViewModel._Morgue["DeliveredBy"];
        if (deliveredByObjectID != null && (typeof deliveredByObjectID === "string")) {
            let deliveredBy = that.morgueProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === deliveredByObjectID.toString());
            if (deliveredBy) {
                that.morgueProcedureFormViewModel._Morgue.DeliveredBy = deliveredBy;
            }
        }
        let materialsAdmittedFromObjectID = that.morgueProcedureFormViewModel._Morgue["MaterialsAdmittedFrom"];
        if (materialsAdmittedFromObjectID != null && (typeof materialsAdmittedFromObjectID === "string")) {
            let materialsAdmittedFrom = that.morgueProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === materialsAdmittedFromObjectID.toString());
            if (materialsAdmittedFrom) {
                that.morgueProcedureFormViewModel._Morgue.MaterialsAdmittedFrom = materialsAdmittedFrom;
            }
        }
        that.morgueProcedureFormViewModel._Morgue.DeathReasonDiagnosis = that.morgueProcedureFormViewModel.DeathReasonDiagnosisGridList;
        for (let detailItem of that.morgueProcedureFormViewModel.DeathReasonDiagnosisGridList) {
            let sKRSICDObjectID = detailItem["SKRSICD"];
            if (sKRSICDObjectID != null && (typeof sKRSICDObjectID === "string")) {
                let sKRSICD = that.morgueProcedureFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSICDObjectID.toString());
                if (sKRSICD) {
                    detailItem.SKRSICD = sKRSICD;
                }
            }
            let sKRSOlumNedeniTuruObjectID = detailItem["SKRSOlumNedeniTuru"];
            if (sKRSOlumNedeniTuruObjectID != null && (typeof sKRSOlumNedeniTuruObjectID === "string")) {
                let sKRSOlumNedeniTuru = that.morgueProcedureFormViewModel.SKRSOlumNedeniTurus.find(o => o.ObjectID.toString() === sKRSOlumNedeniTuruObjectID.toString());
                if (sKRSOlumNedeniTuru) {
                    detailItem.SKRSOlumNedeniTuru = sKRSOlumNedeniTuru;
                }
            }
        }

        let episodeObjectID = that.morgueProcedureFormViewModel._Morgue["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.morgueProcedureFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.morgueProcedureFormViewModel._Morgue.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === "string")) {
                    let patient = that.morgueProcedureFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                    /*if (patient != null) {
                        let sexObjectID = patient["Sex"];
                        if (sexObjectID != null && (typeof sexObjectID === "string")) {
                            let sex = that.morgueProcedureFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
                            patient.Sex = sex;
                        }
                    }*/
                    /*if (patient != null) {
                        let cityOfBirthObjectID = patient["CityOfBirth"];
                        if (cityOfBirthObjectID != null && (typeof cityOfBirthObjectID === "string")) {
                            let cityOfBirth = that.morgueProcedureFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfBirthObjectID.toString());
                            patient.CityOfBirth = cityOfBirth;
                        }
                    }*/
                }
            }
        }

        let sKRSInjuryPlaceObjectID = that.morgueProcedureFormViewModel._Morgue["SKRSInjuryPlace"];
        if (sKRSInjuryPlaceObjectID != null && (typeof sKRSInjuryPlaceObjectID === "string")) {
            let sKRSInjuryPlace = that.morgueProcedureFormViewModel.SKRSYaralanmaninYeris.find(o => o.ObjectID.toString() === sKRSInjuryPlaceObjectID.toString());
            if (sKRSInjuryPlace) {
                that.morgueProcedureFormViewModel._Morgue.SKRSInjuryPlace = sKRSInjuryPlace;
            }
        }
        let sKRSDeathReasonObjectID = that.morgueProcedureFormViewModel._Morgue["SKRSDeathReason"];
        if (sKRSDeathReasonObjectID != null && (typeof sKRSDeathReasonObjectID === "string")) {
            let sKRSDeathReason = that.morgueProcedureFormViewModel.SKRSOlumNedeniTurus.find(o => o.ObjectID.toString() === sKRSDeathReasonObjectID.toString());
            if (sKRSDeathReason) {
                that.morgueProcedureFormViewModel._Morgue.SKRSDeathReason = sKRSDeathReason;
            }
        }
        let sKRSDeathPlaceObjectID = that.morgueProcedureFormViewModel._Morgue["SKRSDeathPlace"];
        if (sKRSDeathPlaceObjectID != null && (typeof sKRSDeathPlaceObjectID === "string")) {
            let sKRSDeathPlace = that.morgueProcedureFormViewModel.SKRSOlumYeris.find(o => o.ObjectID.toString() === sKRSDeathPlaceObjectID.toString());
            if (sKRSDeathPlace) {
                that.morgueProcedureFormViewModel._Morgue.SKRSDeathPlace = sKRSDeathPlace;
            }
        }
        let diedClinicObjectID = that.morgueProcedureFormViewModel._Morgue["DiedClinic"];
        if (diedClinicObjectID != null && (typeof diedClinicObjectID === "string")) {
            let diedClinic = that.morgueProcedureFormViewModel.ResSections.find(o => o.ObjectID.toString() === diedClinicObjectID.toString());
            if (diedClinic) {
                that.morgueProcedureFormViewModel._Morgue.DiedClinic = diedClinic;
            }
        }
        let nurseObjectID = that.morgueProcedureFormViewModel._Morgue["Nurse"];
        if (nurseObjectID != null && (typeof nurseObjectID === "string")) {
            let nurse = that.morgueProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === nurseObjectID.toString());
            if (nurse) {
                that.morgueProcedureFormViewModel._Morgue.Nurse = nurse;
            }
        }
        let senderDoctorObjectID = that.morgueProcedureFormViewModel._Morgue["SenderDoctor"];
        if (senderDoctorObjectID != null && (typeof senderDoctorObjectID === "string")) {
            let senderDoctor = that.morgueProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === senderDoctorObjectID.toString());
            if (senderDoctor) {
                that.morgueProcedureFormViewModel._Morgue.SenderDoctor = senderDoctor;
            }
        }
        let doctorFixedObjectID = that.morgueProcedureFormViewModel._Morgue["DoctorFixed"];
        if (doctorFixedObjectID != null && (typeof doctorFixedObjectID === "string")) {
            let doctorFixed = that.morgueProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === doctorFixedObjectID.toString());
            if (doctorFixed) {
                that.morgueProcedureFormViewModel._Morgue.DoctorFixed = doctorFixed;
            }
        }
        let mernisDeathReasonsObjectID = that.morgueProcedureFormViewModel._Morgue["MernisDeathReasons"];
        if (mernisDeathReasonsObjectID != null && (typeof mernisDeathReasonsObjectID === "string")) {
            let mernisDeathReasons = that.morgueProcedureFormViewModel.MernisDeathReasonDefinitions.find(o => o.ObjectID.toString() === mernisDeathReasonsObjectID.toString());
            if (mernisDeathReasons) {
                that.morgueProcedureFormViewModel._Morgue.MernisDeathReasons = mernisDeathReasons;
            }
        }
        that.morgueProcedureFormViewModel._Morgue.MorgueDeathType = that.morgueProcedureFormViewModel.MorgueDeathTypeGridList;
        for (let detailItem of that.morgueProcedureFormViewModel.MorgueDeathTypeGridList) {
            let sKRSOlumSekliObjectID = detailItem["SKRSOlumSekli"];
            if (sKRSOlumSekliObjectID != null && (typeof sKRSOlumSekliObjectID === "string")) {
                let sKRSOlumSekli = that.morgueProcedureFormViewModel.SKRSOlumSeklis.find(o => o.ObjectID.toString() === sKRSOlumSekliObjectID.toString());
                if (sKRSOlumSekli) {
                    detailItem.SKRSOlumSekli = sKRSOlumSekli;
                }
            }
            let morgueObjectID = detailItem["Morgue"];
            if (morgueObjectID != null && (typeof morgueObjectID === "string")) {
                let morgue = that.morgueProcedureFormViewModel.Morgues.find(o => o.ObjectID.toString() === morgueObjectID.toString());
                if (morgue) {
                    detailItem.Morgue = morgue;
                }
            }
        }
        that.morgueProcedureFormViewModel._Morgue.TreatmentMaterials = that.morgueProcedureFormViewModel.MaterialsGridGridList;
        for (let detailItem of that.morgueProcedureFormViewModel.MaterialsGridGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.morgueProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }
        let sKRSTombCityObjectID = that.morgueProcedureFormViewModel._Morgue["SKRSTombCity"];
        if (sKRSTombCityObjectID != null && (typeof sKRSTombCityObjectID === "string")) {
            let sKRSTombCity = that.morgueProcedureFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === sKRSTombCityObjectID.toString());
            if (sKRSTombCity) {
                that.morgueProcedureFormViewModel._Morgue.SKRSTombCity = sKRSTombCity;
            }
        }
        let sKRSTombTownObjectID = that.morgueProcedureFormViewModel._Morgue["SKRSTombTown"];
        if (sKRSTombTownObjectID != null && (typeof sKRSTombTownObjectID === "string")) {
            let sKRSTombTown = that.morgueProcedureFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === sKRSTombTownObjectID.toString());
            if (sKRSTombTown) {
                that.morgueProcedureFormViewModel._Morgue.SKRSTombTown = sKRSTombTown;
            }
        }

        that.morgueProcedureFormViewModel._Morgue.MorgueTreatmentMaterials = that.morgueProcedureFormViewModel.GridTreatmentMaterialsGridList;
        for (let detailItem of that.morgueProcedureFormViewModel.GridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.morgueProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.morgueProcedureFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.morgueProcedureFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.morgueProcedureFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }

        this.checkDeliveryFormFields();
    }

    public openDeliveryForm(): void {
        this.showDeliveryForm = true;
    }

    async ngOnInit() {
        await this.load();
        this.AddHelpMenu();
      }

    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo): Promise<void> {
        if (transDef.ToStateDefID.toString() == Morgue.MorgueStates.Completed.toString()) {
            if (!this.IsDeliveryFormHasEmptyFields) {
                await super.setState(transDef, saveInfo);
            } else {
                TTVisual.InfoBox.Alert("Teslim Formunu Doldurmadan İşlemi Tamamlayamazsınız.!");
            }
        } else {
            await super.setState(transDef, saveInfo);
        }


    }

    public checkDeliveryFormFields(): void {
        if (this.morgueProcedureFormViewModel._Morgue.DeliveredBy == null) {
            this.IsDeliveryFormHasEmptyFields = true;
        } else if (this.morgueProcedureFormViewModel._Morgue.DeathBodyAdmittedTo == null || this.morgueProcedureFormViewModel._Morgue.DeathBodyAdmittedTo == "") {
            this.IsDeliveryFormHasEmptyFields = true;
        } else if (this.morgueProcedureFormViewModel._Morgue.PhoneNumberOfAdmitted == null || this.morgueProcedureFormViewModel._Morgue.PhoneNumberOfAdmitted == "") {
            this.IsDeliveryFormHasEmptyFields = true;
        } else if (this.morgueProcedureFormViewModel._Morgue.CitizenshipNoOfAdmitted == null || this.morgueProcedureFormViewModel._Morgue.CitizenshipNoOfAdmitted == "") {
            this.IsDeliveryFormHasEmptyFields = true;
        } else if (this.morgueProcedureFormViewModel._Morgue.AddresOfAdmitted == null || this.morgueProcedureFormViewModel._Morgue.CitizenshipNoOfAdmitted == "") {
            this.IsDeliveryFormHasEmptyFields = true;
        } else {
            this.IsDeliveryFormHasEmptyFields = false;
        }
    }
    /* MorgueDeliveryForm */
    public onDeliveredByListChanged(event): void {
        if (this._Morgue != null && this._Morgue.DeliveredBy != event) {
            this._Morgue.DeliveredBy = event;
        }

    }

    public onADDRESSOFADMITTEDChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.AddresOfAdmitted != event) {
                this._Morgue.AddresOfAdmitted = event;
            }
        }
    }


    public onCITIZENSHIPNOOFADMITTEDChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.CitizenshipNoOfAdmitted != event) {
                this._Morgue.CitizenshipNoOfAdmitted = event;
            }
        }
    }

    public onDateOfEntranceChanged(event): void {
        if (event != null) {
            if (this._Morgue != null &&
                this._Morgue.Episode != null && this._Morgue.Episode.OpeningDate != event) {
                this._Morgue.Episode.OpeningDate = event;
            }
        }
    }

    public onDateOfSentToGraveChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DateOfSentToGrave != event) {
                this._Morgue.DateOfSentToGrave = event;
            }
        }
    }

    public onGraveyardPlotNoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.GraveyardPlotNo != event) {
                this._Morgue.GraveyardPlotNo = event;
            }
        }
    }


    public onPHONENUMBEROFADMITTEDChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.PhoneNumberOfAdmitted != event) {
                this._Morgue.PhoneNumberOfAdmitted = event;
            }
        }
    }


    public onSKRSTombCityChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SKRSTombCity != event) {
                this._Morgue.SKRSTombCity = event;
            }
        }
    }

    public onSKRSTombTownChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SKRSTombTown != event) {
                this._Morgue.SKRSTombTown = event;
            }
        }
    }

    public onTombVillageChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.TombVillage != event) {
                this._Morgue.TombVillage = event;
            }
        }
    }





    /* MorgueDeliveryForm */






    public onBirthPlaceChanged(event): void {
        /*if (event != null) {
            if (this._Morgue != null &&
                this._Morgue.Episode != null &&
                this._Morgue.Episode.Patient != null && this._Morgue.Episode.Patient.CityOfBirth != event) {
                this._Morgue.Episode.Patient.CityOfBirth = event;
            }
        }*/
    }

    public onBirthDateChanged(event): void {
        /*if (event != null) {
            if (this._Morgue != null &&
                this._Morgue.Episode != null &&
                this._Morgue.Episode.Patient != null && this._Morgue.Episode.Patient.BirthDate != event) {
                this._Morgue.Episode.Patient.BirthDate = event;
            }
        }*/
    }

    public onAddressOfAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.AddressOfAdmittedFrom != event) {
                this._Morgue.AddressOfAdmittedFrom = event;
            }
        }
    }

    public onCitizenshipNoOfAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.CitizenshipNoOfAdmittedFrom != event) {
                this._Morgue.CitizenshipNoOfAdmittedFrom = event;
            }
        }
    }

    public onCupboardChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.Cupboard != event) {
                this._Morgue.Cupboard = event;
            }
        }
    }

    public onDateOfDeathReportChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DateOfDeathReport != event) {
                this._Morgue.DateOfDeathReport = event;
            }
        }
    }

    public onDeathBodyAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DeathBodyAdmittedFrom != event) {
                this._Morgue.DeathBodyAdmittedFrom = event;
            }
        }
    }

    public onDeathBodyAdmittedToChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DeathBodyAdmittedTo != event) {
                this._Morgue.DeathBodyAdmittedTo = event;
            }
        }
    }

    public onDeathReportNoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DeathReportNo != event) {
                this._Morgue.DeathReportNo = event;
            }
        }
    }

    public onDiedClinicChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DiedClinic != event) {
                this._Morgue.DiedClinic = event;
            }
        }
    }

    public onExternalDoctorFixedChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalDoctorFixed != event) {
                this._Morgue.ExternalDoctorFixed = event;
            }
        }
    }

    public onExternalDoctorFixedUniqueNoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalDoctorFixedUniqueNo != event) {
                this._Morgue.ExternalDoctorFixedUniqueNo = event;
            }
        }
    }

    public onExternalSenderDoctorMorgueUnRChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalSenderDoctorMorgueUnR != event) {
                this._Morgue.ExternalSenderDoctorMorgueUnR = event;
            }
        }
    }

    public onExternalSenderDoctorToMorgueChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalSenderDoctorToMorgue != event) {
                this._Morgue.ExternalSenderDoctorToMorgue = event;
            }
        }
    }

    public onFoundationToFixDeathChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.FoundationToFixDeath != event) {
                this._Morgue.FoundationToFixDeath = event;
            }
        }
    }

    public onInjuryDateChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.InjuryDate != event) {
                this._Morgue.InjuryDate = event;
            }
        }
    }

    public onInjuryExistingChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.InjuryExisting != event) {
                this._Morgue.InjuryExisting = event;
            }
        }
    }

    public onMaterialsAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.MaterialsAdmittedFrom != event) {
                this._Morgue.MaterialsAdmittedFrom = event;
            }
        }
    }

    public onMaterialsAdmittedToChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.MaterialsAdmittedTo != event) {
                this._Morgue.MaterialsAdmittedTo = event;
            }
        }
    }

    public onMernisDeathReasonsChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.MernisDeathReasons != event) {
                this._Morgue.MernisDeathReasons = event;
            }
        }
    }

    public onMorgueCupboardNoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.MorgueCupboardNo != event) {
                this._Morgue.MorgueCupboardNo = event;
            }
        }
    }

    public onNurseChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.Nurse != event) {
                this._Morgue.Nurse = event;
            }
        }
    }

    public onPhoneNumberOfAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.PhoneNumberOfAdmittedFrom != event) {
                this._Morgue.PhoneNumberOfAdmittedFrom = event;
            }
        }
    }

    public onSKRSDeathPlaceChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SKRSDeathPlace != event) {
                this._Morgue.SKRSDeathPlace = event;
            }
        }
    }

    public onSKRSDeathReasonChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SKRSDeathReason != event) {
                this._Morgue.SKRSDeathReason = event;
            }
        }
    }

    public onSKRSInjuryPlaceChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SKRSInjuryPlace != event) {
                this._Morgue.SKRSInjuryPlace = event;
            }
        }
    }

    public onDateTimeOfDeathChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DateTimeOfDeath != event) {
                this._Morgue.DateTimeOfDeath = event;
            }
        }
    }

    public onttobjectlistbox7Changed(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SenderDoctor != event) {
                this._Morgue.SenderDoctor = event;
            }
        }
    }

    public onDoctorFixedChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DoctorFixed != event) {
                this._Morgue.DoctorFixed = event;
            }
        }
    }

    public onReportChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.Report != event) {
                this._Morgue.Report = event;
            }
        }
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.Note != event) {
                this._Morgue.Note = event;
            }
        }
    }

    public onDeathReasonEvaluationChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DeathReasonEvaluation != event) {
                this._Morgue.DeathReasonEvaluation = event;
            }
        }
    }

    public onObjectsFromPatientChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ObjectsFromPatient != event) {
                this._Morgue.ObjectsFromPatient = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Report, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.DeathBodyAdmittedTo, "Text", this.__ttObject, "DeathBodyAdmittedTo");
        redirectProperty(this.MorgueCupboardNo, "Text", this.__ttObject, "MorgueCupboardNo");
        redirectProperty(this.DateTimeOfDeath, "Value", this.__ttObject, "DateTimeOfDeath");
        redirectProperty(this.MaterialsAdmittedTo, "Text", this.__ttObject, "MaterialsAdmittedTo");
        redirectProperty(this.ExternalDoctorFixed, "Text", this.__ttObject, "ExternalDoctorFixed");
        redirectProperty(this.ExternalDoctorFixedUniqueNo, "Text", this.__ttObject, "ExternalDoctorFixedUniqueNo");
        redirectProperty(this.ObjectsFromPatient, "Text", this.__ttObject, "ObjectsFromPatient");
        redirectProperty(this.ExternalSenderDoctorToMorgue, "Text", this.__ttObject, "ExternalSenderDoctorToMorgue");
        redirectProperty(this.DateOfDeathReport, "Value", this.__ttObject, "DateOfDeathReport");
        redirectProperty(this.ExternalSenderDoctorMorgueUnR, "Text", this.__ttObject, "ExternalSenderDoctorMorgueUnR");
        redirectProperty(this.InjuryDate, "Value", this.__ttObject, "InjuryDate");
        redirectProperty(this.DeathBodyAdmittedFrom, "Text", this.__ttObject, "DeathBodyAdmittedFrom");
        redirectProperty(this.CitizenshipNoOfAdmittedFrom, "Text", this.__ttObject, "CitizenshipNoOfAdmittedFrom");
        redirectProperty(this.PhoneNumberOfAdmittedFrom, "Text", this.__ttObject, "PhoneNumberOfAdmittedFrom");
        redirectProperty(this.AddressOfAdmittedFrom, "Text", this.__ttObject, "AddressOfAdmittedFrom");
        redirectProperty(this.DeathReasonEvaluation, "Rtf", this.__ttObject, "DeathReasonEvaluation");
        redirectProperty(this.Note, "Rtf", this.__ttObject, "Note");
        redirectProperty(this.FoundationToFixDeath, "Text", this.__ttObject, "FoundationToFixDeath");
        redirectProperty(this.DeathReportNo, "Text", this.__ttObject, "DeathReportNo");
        redirectProperty(this.InjuryExisting, "Value", this.__ttObject, "InjuryExisting");
        redirectProperty(this.BirthPlace, "Text", this.__ttObject, "Episode.Patient.BirthPlace");
        redirectProperty(this.BirthDate, "Value", this.__ttObject, "Episode.Patient.BirthDate");
        redirectProperty(this.PHONENUMBEROFADMITTED, "Text", this.__ttObject, "PhoneNumberOfAdmitted");
        redirectProperty(this.CITIZENSHIPNOOFADMITTED, "Text", this.__ttObject, "CitizenshipNoOfAdmitted");
        redirectProperty(this.ADDRESSOFADMITTED, "Text", this.__ttObject, "AddresOfAdmitted");
        redirectProperty(this.DateOfEntrance, "Value", this.__ttObject, "Episode.OpeningDate");
        redirectProperty(this.ExternalDoctorFixed, "Text", this.__ttObject, "ExternalDoctorFixed");
        redirectProperty(this.DateOfSentToGrave, "Value", this.__ttObject, "DateOfSentToGrave");
        redirectProperty(this.GraveyardPlotNo, "Text", this.__ttObject, "GraveyardPlotNo");
        redirectProperty(this.TombVillage, "Text", this.__ttObject, "TombVillage");
    }

    public initFormControls(): void {

        /* MorgueDeliveryForm */
        this.DeliveredByList = new TTVisual.TTObjectListBox();
        this.DeliveredByList.ListDefName = "ResUserListDefinition";
        this.DeliveredByList.Name = "DeliveredByList";
        this.DeliveredByList.TabIndex = 1;
        this.DeliveredByList.Required = true;

        this.CITIZENSHIPNOOFADMITTED = new TTVisual.TTTextBox();
        this.CITIZENSHIPNOOFADMITTED.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CITIZENSHIPNOOFADMITTED.Name = "CITIZENSHIPNOOFADMITTED";
        this.CITIZENSHIPNOOFADMITTED.TabIndex = 4;
        this.CITIZENSHIPNOOFADMITTED.Required = true;

        this.TombVillage = new TTVisual.TTTextBox();
        this.TombVillage.Name = "TombVillage";
        this.TombVillage.TabIndex = 114;

        this.ADDRESSOFADMITTED = new TTVisual.TTTextBox();
        this.ADDRESSOFADMITTED.Multiline = true;
        this.ADDRESSOFADMITTED.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ADDRESSOFADMITTED.Name = "ADDRESSOFADMITTED";
        this.ADDRESSOFADMITTED.TabIndex = 5;
        this.ADDRESSOFADMITTED.Height = '60px';
        this.ADDRESSOFADMITTED.Required = true;


        this.PHONENUMBEROFADMITTED = new TTVisual.TTTextBox();
        this.PHONENUMBEROFADMITTED.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PHONENUMBEROFADMITTED.Name = "PHONENUMBEROFADMITTED";
        this.PHONENUMBEROFADMITTED.TabIndex = 3;
        this.PHONENUMBEROFADMITTED.Required = true;

        this.GraveyardPlotNo = new TTVisual.TTTextBox();
        this.GraveyardPlotNo.Name = "GraveyardPlotNo";
        this.GraveyardPlotNo.TabIndex = 9;

        this.DateOfEntrance = new TTVisual.TTDateTimePicker();
        this.DateOfEntrance.BackColor = "#F0F0F0";
        this.DateOfEntrance.CustomFormat = "";
        this.DateOfEntrance.Format = DateTimePickerFormat.Long;
        this.DateOfEntrance.Enabled = false;
        this.DateOfEntrance.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DateOfEntrance.Name = "DateOfEntrance";
        this.DateOfEntrance.TabIndex = 6;

        this.DateOfSentToGrave = new TTVisual.TTDateTimePicker();
        this.DateOfSentToGrave.CustomFormat = "";
        this.DateOfSentToGrave.Format = DateTimePickerFormat.Long;
        this.DateOfSentToGrave.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DateOfSentToGrave.Name = "DateOfSentToGrave";
        this.DateOfSentToGrave.TabIndex = 7;

        this.SKRSTombCity = new TTVisual.TTObjectListBox();
        this.SKRSTombCity.ListDefName = "SKRSILKodlariList";
        this.SKRSTombCity.Name = "SKRSTombCity";
        this.SKRSTombCity.TabIndex = 118;

        this.SKRSTombTown = new TTVisual.TTObjectListBox();
        this.SKRSTombTown.ListDefName = "SKRSIlceKodlariList";
        this.SKRSTombTown.Name = "SKRSTombTown";
        this.SKRSTombTown.TabIndex = 120;


        /* MorgueDeliveryForm */
        this.BirthPlace = new TTVisual.TTTextBox();
        this.BirthPlace.ReadOnly = true;
        this.BirthPlace.Name = "BirthPlace";
        this.BirthPlace.TabIndex = 2;

        this.BirthDate = new TTVisual.TTDateTimePicker();
        this.BirthDate.BackColor = "#F0F0F0";
        this.BirthDate.CustomFormat = "";
        this.BirthDate.Format = DateTimePickerFormat.Short;
        this.BirthDate.Enabled = false;
        this.BirthDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BirthDate.Name = "BirthDate";
        this.BirthDate.TabIndex = 3;

        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 122;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M10517", "Adı Soyadı");
        this.ttlabel4.BackColor = "#000000";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 50;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M12186", "Cenazeyi Getirenin");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 119;

        this.CitizenshipNoOfAdmittedFrom = new TTVisual.TTTextBox();
        this.CitizenshipNoOfAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CitizenshipNoOfAdmittedFrom.Name = "CitizenshipNoOfAdmittedFrom";
        this.CitizenshipNoOfAdmittedFrom.TabIndex = 1;

        this.AddressOfAdmittedFrom = new TTVisual.TTTextBox();
        this.AddressOfAdmittedFrom.Multiline = true;
        this.AddressOfAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AddressOfAdmittedFrom.Name = "AddressOfAdmittedFrom";
        this.AddressOfAdmittedFrom.TabIndex = 3;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M22941", "TC Kimlik Numarası");
        this.ttlabel1.BackColor = "#000000";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 52;

        this.PhoneNumberOfAdmittedFrom = new TTVisual.TTTextBox();
        this.PhoneNumberOfAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PhoneNumberOfAdmittedFrom.Name = "PhoneNumberOfAdmittedFrom";
        this.PhoneNumberOfAdmittedFrom.TabIndex = 2;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M10553", "Adresi");
        this.ttlabel6.BackColor = "#000000";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 54;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M23138", "Telefon Numarası");
        this.ttlabel7.BackColor = "#000000";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 56;

        this.DeathBodyAdmittedFrom = new TTVisual.TTTextBox();
        this.DeathBodyAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DeathBodyAdmittedFrom.Name = "DeathBodyAdmittedFrom";
        this.DeathBodyAdmittedFrom.TabIndex = 0;

        this.DeathBodyAdmittedTo = new TTVisual.TTTextBox();
        this.DeathBodyAdmittedTo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DeathBodyAdmittedTo.Name = "DeathBodyAdmittedTo";
        this.DeathBodyAdmittedTo.TabIndex = 3;
        this.DeathBodyAdmittedTo.Required = true;

        this.MorgueCupboardNo = new TTVisual.TTTextBox();
        this.MorgueCupboardNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MorgueCupboardNo.Name = "MorgueCupboardNo";
        this.MorgueCupboardNo.TabIndex = 7;

        this.MaterialsAdmittedTo = new TTVisual.TTTextBox();
        this.MaterialsAdmittedTo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaterialsAdmittedTo.Name = "MaterialsAdmittedTo";
        this.MaterialsAdmittedTo.TabIndex = 10;

        this.ExternalSenderDoctorMorgueUnR = new TTVisual.TTTextBox();
        this.ExternalSenderDoctorMorgueUnR.Name = "ExternalSenderDoctorMorgueUnR";
        this.ExternalSenderDoctorMorgueUnR.TabIndex = 14;

        this.ExternalSenderDoctorToMorgue = new TTVisual.TTTextBox();
        this.ExternalSenderDoctorToMorgue.Name = "ExternalSenderDoctorToMorgue";
        this.ExternalSenderDoctorToMorgue.TabIndex = 12;

        this.ExternalDoctorFixedUniqueNo = new TTVisual.TTTextBox();
        this.ExternalDoctorFixedUniqueNo.Name = "ExternalDoctorFixedUniqueNo";
        this.ExternalDoctorFixedUniqueNo.TabIndex = 8;

        this.ExternalDoctorFixed = new TTVisual.TTTextBox();
        this.ExternalDoctorFixed.Name = "ExternalDoctorFixed";
        this.ExternalDoctorFixed.TabIndex = 6;

        this.ObjectsFromPatient = new TTVisual.TTTextBox();
        this.ObjectsFromPatient.Multiline = true;
        this.ObjectsFromPatient.Name = "ObjectsFromPatient";
        this.ObjectsFromPatient.TabIndex = 121;
        this.ObjectsFromPatient.Height = '60px';

        this.DeathReportNo = new TTVisual.TTTextBox();
        this.DeathReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DeathReportNo.Name = "DeathReportNo";
        this.DeathReportNo.TabIndex = 10;

        this.FoundationToFixDeath = new TTVisual.TTTextBox();
        this.FoundationToFixDeath.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FoundationToFixDeath.Name = "FoundationToFixDeath";
        this.FoundationToFixDeath.TabIndex = 9;

        this.Report = new TTVisual.TTRichTextBoxControl();
        this.Report.DisplayText = "Rapor";
        this.Report.TemplateGroupName = "MORGUEREPORT";
        this.Report.BackColor = "#FFFFFF";
        this.Report.Name = "Report";
        this.Report.TabIndex = 50;

        this.labelMaterialsAdmittedFrom = new TTVisual.TTLabel();
        this.labelMaterialsAdmittedFrom.Text = i18n("M13927", "Eşyaları Teslim Eden");
        this.labelMaterialsAdmittedFrom.BackColor = "#000000";
        this.labelMaterialsAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMaterialsAdmittedFrom.ForeColor = "#000000";
        this.labelMaterialsAdmittedFrom.Name = "labelMaterialsAdmittedFrom";
        this.labelMaterialsAdmittedFrom.TabIndex = 3;

        this.labelMaterialsAdmittedTo = new TTVisual.TTLabel();
        this.labelMaterialsAdmittedTo.Text = i18n("M13926", "Eşyaları Teslim Alan");
        this.labelMaterialsAdmittedTo.BackColor = "#000000";
        this.labelMaterialsAdmittedTo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMaterialsAdmittedTo.ForeColor = "#000000";
        this.labelMaterialsAdmittedTo.Name = "labelMaterialsAdmittedTo";
        this.labelMaterialsAdmittedTo.TabIndex = 11;

        this.Cupboard = new TTVisual.TTObjectListBox();
        this.Cupboard.ListFilterExpression = "USEDBYACTION IS NULL";
        this.Cupboard.ListDefName = "CupboardListDefinition";
        this.Cupboard.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Cupboard.Name = "Cupboard";
        this.Cupboard.TabIndex = 8;

        this.labelMorgueCupboardNo = new TTVisual.TTLabel();
        this.labelMorgueCupboardNo.Text = i18n("M19126", "Morg Dolap No");
        this.labelMorgueCupboardNo.BackColor = "#000000";
        this.labelMorgueCupboardNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMorgueCupboardNo.ForeColor = "#000000";
        this.labelMorgueCupboardNo.Name = "labelMorgueCupboardNo";
        this.labelMorgueCupboardNo.TabIndex = 31;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M12190", "Cenazeyi Teslim Alan");
        this.ttlabel8.BackColor = "#000000";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 1;

        this.labelQuarantineCupboardNo = new TTVisual.TTLabel();
        this.labelQuarantineCupboardNo.Text = i18n("M23392", "Tıbbi Kayıt Dolap No");
        this.labelQuarantineCupboardNo.BackColor = "#000000";
        this.labelQuarantineCupboardNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelQuarantineCupboardNo.ForeColor = "#000000";
        this.labelQuarantineCupboardNo.Name = "labelQuarantineCupboardNo";
        this.labelQuarantineCupboardNo.TabIndex = 29;

        this.MaterialsAdmittedFrom = new TTVisual.TTObjectListBox();
        this.MaterialsAdmittedFrom.ListDefName = "UserListDefinition";
        this.MaterialsAdmittedFrom.Name = "MaterialsAdmittedFrom";
        this.MaterialsAdmittedFrom.TabIndex = 9;

        this.labelDateTimeOfDeath = new TTVisual.TTLabel();
        this.labelDateTimeOfDeath.Text = i18n("M19945", "Ölüm Tarihi ve Saati");
        this.labelDateTimeOfDeath.Name = "labelDateTimeOfDeath";
        this.labelDateTimeOfDeath.TabIndex = 1;

        this.labelDeathReason = new TTVisual.TTLabel();
        this.labelDeathReason.Text = i18n("M19927", "Ölüm Nedeni Bilgisi");
        this.labelDeathReason.Name = "labelDeathReason";
        this.labelDeathReason.TabIndex = 41;

        this.DeathReasonDiagnosis = new TTVisual.TTGrid();
        this.DeathReasonDiagnosis.Name = "DeathReasonDiagnosis";
        this.DeathReasonDiagnosis.TabIndex = 40;

        this.SKRSICDDeathReasonDiagnosis = new TTVisual.TTListBoxColumn();
        this.SKRSICDDeathReasonDiagnosis.ListDefName = "SKRSICDList";
        this.SKRSICDDeathReasonDiagnosis.DataMember = "SKRSICD";
        this.SKRSICDDeathReasonDiagnosis.DisplayIndex = 0;
        this.SKRSICDDeathReasonDiagnosis.HeaderText = i18n("M19930", "Ölüm Nedeni Tanı");
        this.SKRSICDDeathReasonDiagnosis.Name = "SKRSICDDeathReasonDiagnosis";
        this.SKRSICDDeathReasonDiagnosis.Width = 300;

        this.SKRSOlumNedeniTuruDeathReasonDiagnosis = new TTVisual.TTListBoxColumn();
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.ListDefName = "SKRSOlumNedeniTuruList";
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.DataMember = "SKRSOlumNedeniTuru";
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.DisplayIndex = 1;
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.HeaderText = i18n("M19931", "Ölüm Nedeni Türü");
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.Name = "SKRSOlumNedeniTuruDeathReasonDiagnosis";
        this.SKRSOlumNedeniTuruDeathReasonDiagnosis.Width = 300;

        this.labelDateOfDeathReport = new TTVisual.TTLabel();
        this.labelDateOfDeathReport.Text = i18n("M19936", "Ölüm Raporunun Tarihi");
        this.labelDateOfDeathReport.Name = "labelDateOfDeathReport";
        this.labelDateOfDeathReport.TabIndex = 36;

        this.DateOfDeathReport = new TTVisual.TTDateTimePicker();
        this.DateOfDeathReport.Format = DateTimePickerFormat.Long;
        this.DateOfDeathReport.Name = "DateOfDeathReport";
        this.DateOfDeathReport.TabIndex = 35;

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = i18n("M19476", "Not");
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 34;

        this.Note = new TTVisual.TTRichTextBoxControl();
        this.Note.Name = "Note";
        this.Note.TabIndex = 33;

        this.labelSKRSInjuryPlace = new TTVisual.TTLabel();
        this.labelSKRSInjuryPlace.Text = i18n("M24308", "Yaralanma Yeri");
        this.labelSKRSInjuryPlace.Name = "labelSKRSInjuryPlace";
        this.labelSKRSInjuryPlace.TabIndex = 32;

        this.SKRSInjuryPlace = new TTVisual.TTObjectListBox();
        this.SKRSInjuryPlace.ListDefName = "SKRSYaralanmaninYeriList";
        this.SKRSInjuryPlace.Name = "SKRSInjuryPlace";
        this.SKRSInjuryPlace.TabIndex = 31;

        this.labelInjuryDate = new TTVisual.TTLabel();
        this.labelInjuryDate.Text = i18n("M24306", "Yaralanma Tarihi");
        this.labelInjuryDate.Name = "labelInjuryDate";
        this.labelInjuryDate.TabIndex = 30;

        this.InjuryDate = new TTVisual.TTDateTimePicker();
        this.InjuryDate.Format = DateTimePickerFormat.Long;
        this.InjuryDate.Name = "InjuryDate";
        this.InjuryDate.TabIndex = 29;

        this.labelSKRSDeathReason = new TTVisual.TTLabel();
        this.labelSKRSDeathReason.Text = i18n("M19931", "Ölüm Nedeni Türü");
        this.labelSKRSDeathReason.Name = "labelSKRSDeathReason";
        this.labelSKRSDeathReason.TabIndex = 27;

        this.SKRSDeathReason = new TTVisual.TTObjectListBox();
        this.SKRSDeathReason.ListDefName = "SKRSOlumNedeniTuruList";
        this.SKRSDeathReason.Name = "SKRSDeathReason";
        this.SKRSDeathReason.TabIndex = 26;

        this.labelSKRSDeathPlace = new TTVisual.TTLabel();
        this.labelSKRSDeathPlace.Text = i18n("M19948", "Ölüm Yeri");
        this.labelSKRSDeathPlace.Name = "labelSKRSDeathPlace";
        this.labelSKRSDeathPlace.TabIndex = 25;

        this.SKRSDeathPlace = new TTVisual.TTObjectListBox();
        this.SKRSDeathPlace.ListDefName = "SKRSOlumYeriList";
        this.SKRSDeathPlace.Name = "SKRSDeathPlace";
        this.SKRSDeathPlace.TabIndex = 24;

        this.labelDeathReasonEvaluation = new TTVisual.TTLabel();
        this.labelDeathReasonEvaluation.Text = i18n("M19929", "Ölüm Nedeni Değerlendirme");
        this.labelDeathReasonEvaluation.Name = "labelDeathReasonEvaluation";
        this.labelDeathReasonEvaluation.TabIndex = 21;

        this.DeathReasonEvaluation = new TTVisual.TTRichTextBoxControl();
        this.DeathReasonEvaluation.Name = "DeathReasonEvaluation";
        this.DeathReasonEvaluation.TabIndex = 20;

        this.labelDiedClinic = new TTVisual.TTLabel();
        this.labelDiedClinic.Text = i18n("M24059", "Vefat Ettiği Klinik");
        this.labelDiedClinic.Name = "labelDiedClinic";
        this.labelDiedClinic.TabIndex = 19;

        this.DiedClinic = new TTVisual.TTObjectListBox();
        this.DiedClinic.ListDefName = "ClinicListDefinition";
        this.DiedClinic.Name = "DiedClinic";
        this.DiedClinic.TabIndex = 18;

        this.labelNurse = new TTVisual.TTLabel();
        this.labelNurse.Text = "Hemşire";
        this.labelNurse.Name = "labelNurse";
        this.labelNurse.TabIndex = 17;

        this.Nurse = new TTVisual.TTObjectListBox();
        this.Nurse.ListDefName = "ClinicNurseListDefinition";
        this.Nurse.Name = "Nurse";
        this.Nurse.TabIndex = 16;

        this.labelExternalSenderDoctorMorgueUnR = new TTVisual.TTLabel();
        this.labelExternalSenderDoctorMorgueUnR.Text = i18n("M19137", "Morga Gönderen Dış Doktor TC");
        this.labelExternalSenderDoctorMorgueUnR.Name = "labelExternalSenderDoctorMorgueUnR";
        this.labelExternalSenderDoctorMorgueUnR.TabIndex = 15;

        this.labelExternalSenderDoctorToMorgue = new TTVisual.TTLabel();
        this.labelExternalSenderDoctorToMorgue.Text = i18n("M19136", "Morga Gönderen Dış Doktor");
        this.labelExternalSenderDoctorToMorgue.Name = "labelExternalSenderDoctorToMorgue";
        this.labelExternalSenderDoctorToMorgue.TabIndex = 13;

        this.labelSenderDoctor = new TTVisual.TTLabel();
        this.labelSenderDoctor.Text = i18n("M19138", "Morga Gönderen Doktor");
        this.labelSenderDoctor.Name = "labelSenderDoctor";
        this.labelSenderDoctor.TabIndex = 11;

        this.ttobjectlistbox7 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox7.ListDefName = "SpecialistDoctorListDefinition";
        this.ttobjectlistbox7.Name = "ttobjectlistbox7";
        this.ttobjectlistbox7.TabIndex = 10;

        this.labelExternalDoctorFixedUniqueNo = new TTVisual.TTLabel();
        this.labelExternalDoctorFixedUniqueNo.Text = i18n("M19951", "Ölümü Tespit Eden Dış Doktor TC");
        this.labelExternalDoctorFixedUniqueNo.Name = "labelExternalDoctorFixedUniqueNo";
        this.labelExternalDoctorFixedUniqueNo.TabIndex = 9;

        this.labelExternalDoctorFixed = new TTVisual.TTLabel();
        this.labelExternalDoctorFixed.Text = i18n("M19952", "Ölümü Tespit Eden Dış Kurum Doktoru");
        this.labelExternalDoctorFixed.Name = "labelExternalDoctorFixed";
        this.labelExternalDoctorFixed.TabIndex = 7;

        this.labelDoctorFixed = new TTVisual.TTLabel();
        this.labelDoctorFixed.Text = i18n("M19954", "Ölümü Tespit Eden Doktor");
        this.labelDoctorFixed.Name = "labelDoctorFixed";
        this.labelDoctorFixed.TabIndex = 5;

        this.DoctorFixed = new TTVisual.TTObjectListBox();
        this.DoctorFixed.ListDefName = "SpecialistDoctorListDefinition";
        this.DoctorFixed.Name = "DoctorFixed";
        this.DoctorFixed.TabIndex = 4;

        this.labelMernisDeathReasons = new TTVisual.TTLabel();
        this.labelMernisDeathReasons.Text = "Mernis Ölüm Sebepleri";
        this.labelMernisDeathReasons.Name = "labelMernisDeathReasons";
        this.labelMernisDeathReasons.TabIndex = 3;

        this.MernisDeathReasons = new TTVisual.TTObjectListBox();
        this.MernisDeathReasons.ListDefName = "MernisDeathReasonDefinitionList";
        this.MernisDeathReasons.Name = "MernisDeathReasons";
        this.MernisDeathReasons.TabIndex = 2;

        this.MorgueDeathType = new TTVisual.TTGrid();
        this.MorgueDeathType.Name = "MorgueDeathType";
        this.MorgueDeathType.TabIndex = 42;

        this.SKRSOlumSekliMorgueDeathType = new TTVisual.TTListBoxColumn();
        this.SKRSOlumSekliMorgueDeathType.ListDefName = "SKRSOlumSekliList";
        this.SKRSOlumSekliMorgueDeathType.DataMember = "SKRSOlumSekli";
        this.SKRSOlumSekliMorgueDeathType.DisplayIndex = 0;
        this.SKRSOlumSekliMorgueDeathType.HeaderText = i18n("M19942", "Ölüm Şekli");
        this.SKRSOlumSekliMorgueDeathType.Name = "SKRSOlumSekliMorgueDeathType";
        this.SKRSOlumSekliMorgueDeathType.Width = 300;


        this.DateTimeOfDeath = new TTVisual.TTDateTimePicker();
        this.DateTimeOfDeath.Format = DateTimePickerFormat.Long;
        this.DateTimeOfDeath.Name = "DateTimeOfDeath";
        this.DateTimeOfDeath.TabIndex = 0;

        this.ttlabel29 = new TTVisual.TTLabel();
        this.ttlabel29.Text = i18n("M19942", "Ölüm Şekli");
        this.ttlabel29.Name = "ttlabel29";
        this.ttlabel29.TabIndex = 41;

        this.InjuryExisting = new TTVisual.TTCheckBox();
        this.InjuryExisting.Value = false;
        this.InjuryExisting.Text = i18n("M24302", "Yaralanma Mevcut");
        this.InjuryExisting.Title = i18n("M24302", "Yaralanma Mevcut");
        this.InjuryExisting.Name = "InjuryExisting";
        this.InjuryExisting.TabIndex = 28;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = i18n("M15500", "Hastanın Üzerinden Çıkanlar");
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 119;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M19955", "Ölümü Tespit Eden Kurum");
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 95;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M19935", "Ölüm Raporunun Numarası");
        this.ttlabel3.BackColor = "#000000";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 48;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M19932", "Ölüm Nedenini");
        this.ttlabel10.BackColor = "#000000";
        this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 43;

        this.TabSubaction = new TTVisual.TTTabControl();
        this.TabSubaction.ForeColor = "#000000";
        this.TabSubaction.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabSubaction.Name = "TabSubaction";
        this.TabSubaction.TabIndex = 12;

        this.Materials = new TTVisual.TTTabPage();
        this.Materials.DisplayIndex = 0;
        this.Materials.BackColor = "#FFFFFF";
        this.Materials.TabIndex = 1;
        this.Materials.Text = i18n("M21309", "Sarf");
        this.Materials.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Materials.ForeColor = "#000000";
        this.Materials.Name = "Materials";

        this.MaterialsGrid = new TTVisual.TTGrid();
        this.MaterialsGrid.ForeColor = "#000000";
        this.MaterialsGrid.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaterialsGrid.Name = "MaterialsGrid";
        this.MaterialsGrid.TabIndex = 0;

        this.EntryDate = new TTVisual.TTDateTimePickerColumn();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.DataMember = "ActionDate";
        this.EntryDate.DisplayIndex = 0;
        this.EntryDate.HeaderText = "Tarih/Saat";
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.Width = 100;

        this.ExMaterials = new TTVisual.TTListBoxColumn();
        this.ExMaterials.ListDefName = "MaterialListDefinition";
        this.ExMaterials.DataMember = "Material";
        this.ExMaterials.DisplayIndex = 1;
        this.ExMaterials.HeaderText = i18n("M18631", "Malzemeler");
        this.ExMaterials.Name = "ExMaterials";
        this.ExMaterials.Width = 250;

        this.ExAmount = new TTVisual.TTTextBoxColumn();
        this.ExAmount.DataMember = "Amount";
        this.ExAmount.DisplayIndex = 2;
        this.ExAmount.HeaderText = i18n("M19030", "Miktar");
        this.ExAmount.Name = "ExAmount";
        this.ExAmount.Width = 80;

        this.UBBCODE = new TTVisual.TTTextBoxColumn();
        this.UBBCODE.DataMember = "UBBCode";
        this.UBBCODE.DisplayIndex = 3;
        this.UBBCODE.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCODE.Name = "UBBCODE";
        this.UBBCODE.Width = 100;

        this.ExNotes = new TTVisual.TTTextBoxColumn();
        this.ExNotes.DataMember = "Note";
        this.ExNotes.DisplayIndex = 4;
        this.ExNotes.HeaderText = i18n("M19485", "Notlar");
        this.ExNotes.Name = "ExNotes";
        this.ExNotes.Width = 200;

        this.DeathReasonDiagnosisColumns = [this.SKRSICDDeathReasonDiagnosis, this.SKRSOlumNedeniTuruDeathReasonDiagnosis];
        this.MorgueDeathTypeColumns = [this.SKRSOlumSekliMorgueDeathType];
        this.MaterialsGridColumns = [this.EntryDate, this.ExMaterials, this.ExAmount, this.UBBCODE, this.ExNotes];
        this.ttpanel1.Controls = [this.ttlabel4, this.ttlabel5, this.CitizenshipNoOfAdmittedFrom, this.AddressOfAdmittedFrom, this.ttlabel1, this.PhoneNumberOfAdmittedFrom, this.ttlabel6, this.ttlabel7, this.DeathBodyAdmittedFrom];
        this.TabSubaction.Controls = [this.Materials];
        this.Materials.Controls = [this.MaterialsGrid];
        this.Controls = [this.SKRSTombCity, this.SKRSTombTown, this.DateOfSentToGrave, this.GraveyardPlotNo, this.PHONENUMBEROFADMITTED, this.ADDRESSOFADMITTED, this.DateOfEntrance, this.TombVillage, this.CITIZENSHIPNOOFADMITTED, this.DeliveredByList, this.BirthDate, this.BirthPlace, this.ttpanel1, this.ttlabel4, this.ttlabel5, this.CitizenshipNoOfAdmittedFrom, this.AddressOfAdmittedFrom, this.ttlabel1, this.PhoneNumberOfAdmittedFrom, this.ttlabel6, this.ttlabel7, this.DeathBodyAdmittedFrom, this.DeathBodyAdmittedTo, this.MorgueCupboardNo, this.MaterialsAdmittedTo, this.ExternalSenderDoctorMorgueUnR, this.ExternalSenderDoctorToMorgue, this.ExternalDoctorFixedUniqueNo, this.ExternalDoctorFixed, this.ObjectsFromPatient, this.DeathReportNo, this.FoundationToFixDeath, this.Report, this.labelMaterialsAdmittedFrom, this.labelMaterialsAdmittedTo, this.Cupboard, this.labelMorgueCupboardNo, this.ttlabel8, this.labelQuarantineCupboardNo, this.MaterialsAdmittedFrom, this.labelDateTimeOfDeath, this.labelDeathReason, this.DeathReasonDiagnosis, this.SKRSICDDeathReasonDiagnosis, this.SKRSOlumNedeniTuruDeathReasonDiagnosis, this.labelDateOfDeathReport, this.DateOfDeathReport, this.labelNote, this.Note, this.labelSKRSInjuryPlace, this.SKRSInjuryPlace, this.labelInjuryDate, this.InjuryDate, this.labelSKRSDeathReason, this.SKRSDeathReason, this.labelSKRSDeathPlace, this.SKRSDeathPlace, this.labelDeathReasonEvaluation, this.DeathReasonEvaluation, this.labelDiedClinic, this.DiedClinic, this.labelNurse, this.Nurse, this.labelExternalSenderDoctorMorgueUnR, this.labelExternalSenderDoctorToMorgue, this.labelSenderDoctor, this.ttobjectlistbox7, this.labelExternalDoctorFixedUniqueNo, this.labelExternalDoctorFixed, this.labelDoctorFixed, this.DoctorFixed, this.labelMernisDeathReasons, this.MernisDeathReasons, this.MorgueDeathType, this.SKRSOlumSekliMorgueDeathType, this.DateTimeOfDeath, this.ttlabel29, this.InjuryExisting, this.ttlabel17, this.ttlabel12, this.ttlabel3, this.ttlabel10, this.TabSubaction, this.Materials, this.MaterialsGrid, this.EntryDate, this.ExMaterials, this.ExAmount, this.UBBCODE, this.ExNotes];

    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let obs = new DynamicSidebarMenuItem();
        obs.key = 'obs';
        obs.componentInstance = this;
        obs.label = 'Ölüm Bildirim';
        obs.icon = 'ai ai-obs';
        obs.clickFunction = this.insertOBS;
        this.sideBarMenuService.addMenu('YardimciMenu', obs);
    }
    
    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('obs');
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
    
        let result: string;
        if(transDef != null && transDef.FromStateDefID.valueOf() == Morgue.MorgueStates.MorgueProcedure.id && transDef.ToStateDefID.valueOf() == Morgue.MorgueStates.Completed.id)
        {
            result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Ölüm Bildirim',
            "Ölüm bildirimini şimdi yapmak istiyor musunuz? ");
            if (result === 'T') {
                this.insertOBS();
            }else{
                if(this.morgueProcedureFormViewModel.OBSZorla)
                    throw new Exception("Ölüm bildirimi yapmadan işlemi tamamlayamazsınız");
            }
        }
    }

    public insertOBS()
    {
        // let fullApiUrl: string = 'api/MorgueService/OpenOBSWebPage?ID='+this.morgueProcedureFormViewModel._Morgue.Episode.Patient.ID;

        if(this.morgueProcedureFormViewModel._Morgue.DoctorFixed == null && this.morgueProcedureFormViewModel._Morgue.ExternalDoctorFixedUniqueNo == null)
        {
            ServiceLocator.MessageService.showError("'Ölümü Tespit Eden Doktor' veya 'Ölümü Tespit Eden Dış Doktor TC' alanlarından bir tanesi doldurulmadan Ölüm bildirimi Yapılamaz.");
            throw new Exception("");
        }
        this.loadPanelOperation(true, 'ölüm bildirim ekranı açılıyor, lütfen bekleyiniz.');
        let fullApiUrl: string = 'api/MorgueService/OpenOBSWebPage';
        let input: ObsInput = new ObsInput();
        input.SaglikKurulusuReferansNo = this.morgueProcedureFormViewModel._Morgue.Episode.Patient.ID.toString();
        input.TcKimlikNo = this.morgueProcedureFormViewModel._Morgue.Episode.Patient.UniqueRefNo;
        input.Adi = this.morgueProcedureFormViewModel._Morgue.Episode.Patient.Name;
        input.Soyadi = this.morgueProcedureFormViewModel._Morgue.Episode.Patient.Surname;
        input.BabaAdi = this.morgueProcedureFormViewModel._Morgue.Episode.Patient.FatherName;
        input.AnaAdi = this.morgueProcedureFormViewModel._Morgue.Episode.Patient.MotherName;
        input.DogumTarihi = this.morgueProcedureFormViewModel._Morgue.Episode.Patient.BirthDate != null ? this.morgueProcedureFormViewModel._Morgue.Episode.Patient.BirthDate.ToShortDateString() :null;

        // this.morgueProcedureFormViewModel._Morgue.Episode.Patient.PatientAddress.SKRSILKodlari.KODU;
        input.OlumZamani =this.datePipe.transform(this.morgueProcedureFormViewModel._Morgue.DateTimeOfDeath, 'dd.MM.yyyy HH:mm');
        input.OlumYeri = this.morgueProcedureFormViewModel._Morgue.SKRSDeathPlace != null ? +this.morgueProcedureFormViewModel._Morgue.SKRSDeathPlace.KODU :0;
        input.OlumSekli = this.morgueProcedureFormViewModel._Morgue.MorgueDeathType != null && this.morgueProcedureFormViewModel._Morgue.MorgueDeathType[0] != null ? +this.morgueProcedureFormViewModel._Morgue.MorgueDeathType[0].SKRSOlumSekli.KODU:0;

        input.OlumNedenleri="";
        for(let diagnos of this.morgueProcedureFormViewModel._Morgue.DeathReasonDiagnosis)
        {
            input.OlumNedenleri += diagnos.SKRSICD.KODU + ',';
        }

        if( input.OlumNedenleri != null && input.OlumNedenleri != "")
            input.OlumNedenleri = input.OlumNedenleri.substring(0, input.OlumNedenleri.length - 1)

        input.SysTakipNo =this.morgueProcedureFormViewModel._Morgue.SubEpisode.SYSTakipNo;

        input.FixedDoctorUniqueID = this.morgueProcedureFormViewModel._Morgue.DoctorFixed != null ? this.morgueProcedureFormViewModel._Morgue.DoctorFixed.UniqueNo : this.morgueProcedureFormViewModel._Morgue.ExternalDoctorFixedUniqueNo;
        input.FixedDoctorObjectID = this.morgueProcedureFormViewModel._Morgue.DoctorFixed != null ? this.morgueProcedureFormViewModel._Morgue.DoctorFixed.ObjectID :new Guid();
        this.httpService.post(fullApiUrl,input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
            this.loadPanelOperation(false, '');
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
            this.loadPanelOperation(false, '');
        });
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

}
