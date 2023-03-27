//$DB48AF11
import { Component, OnInit, NgZone } from '@angular/core';
import { OutPatientPrescriptionFormViewModel } from './OutPatientPrescriptionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { OutPatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescriptionBaseForm } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Ayaktan_Hasta_Recetesi_Modulu/OutPatientPrescriptionBaseForm";
import { PeriodUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionPaper } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { SortByEnum } from 'NebulaClient/Utils/Enums/SortByEnum';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';


@Component({
    selector: 'OutPatientPrescriptionForm',
    templateUrl: './OutPatientPrescriptionForm.html',
    providers: [MessageService]
})
export class OutPatientPrescriptionForm extends OutPatientPrescriptionBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    CheckDiagnosisForPresc: TTVisual.ITTCheckBoxColumn;
    cmdAddDiagnosis: TTVisual.ITTButton;
    cmdAddTemplate: TTVisual.ITTButton;
    cmdChangeSpeciality: TTVisual.ITTButton;
    cmdGetFavoriteDrugs: TTVisual.ITTButton;
    cmdGetTemplate: TTVisual.ITTButton;
    cmdSelectBarcodeLevel: TTVisual.ITTButtonColumn;
    CodeDiagnosisForPresc: TTVisual.ITTTextBoxColumn;
    Day: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    DescriptionType: TTVisual.ITTEnumComboBoxColumn;
    DiscriptionOfPharmacist: TTVisual.ITTTextBox;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    Drug: TTVisual.ITTListBoxColumn;
    DrugListview: TTVisual.ITTListView;
    DrugTabPage: TTVisual.ITTTabPage;
    DrugUsageType: TTVisual.ITTEnumComboBoxColumn;
    Emergency: TTVisual.ITTCheckBox;
    EReceteDescription: TTVisual.ITTTextBox;
    EReceteNo: TTVisual.ITTTextBox;
    FavoriteDrugListview: TTVisual.ITTListView;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    ID: TTVisual.ITTTextBox;
    IlacEtkinMadde: TTVisual.ITTButtonColumn;
    labelActionDate: TTVisual.ITTLabel;
    labelEReceteNo: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelPrescriptionPaper: TTVisual.ITTLabel;
    labelPrescriptionType: TTVisual.ITTLabel;
    labelSpecialityDefinition: TTVisual.ITTLabel;
    NameDiagnosisForPresc: TTVisual.ITTTextBoxColumn;
    OutPatientDrugOrders: TTVisual.ITTGrid;
    PackageAmount: TTVisual.ITTTextBoxColumn;
    PatientFullName: TTVisual.ITTTextBox;
    PeriodUnitType: TTVisual.ITTEnumComboBoxColumn;
    PhysicianDrug: TTVisual.ITTListBoxColumn;
    PrescriptionPaper: TTVisual.ITTObjectListBox;
    PrescriptionType: TTVisual.ITTEnumComboBox;
    Price: TTVisual.ITTTextBoxColumn;
    ReceivedPrice: TTVisual.ITTTextBoxColumn;
    RequiredAmount: TTVisual.ITTTextBoxColumn;
    SearchTextbox: TTVisual.ITTTextBox;
    SendESignedPrescription: TTVisual.ITTButton;
    SpecialityDefinition: TTVisual.ITTObjectListBox;
    SPTSDiagnosises: TTVisual.ITTGrid;
    SUTRules: TTVisual.ITTButtonColumn;
    TreatmentTime: TTVisual.ITTTextBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    UnitPrice: TTVisual.ITTTextBoxColumn;
    UsageNote: TTVisual.ITTTextBoxColumn;
    public OutPatientDrugOrdersColumns = [];
    public SPTSDiagnosisesColumns = [];
    public outPatientPrescriptionFormViewModel: OutPatientPrescriptionFormViewModel = new OutPatientPrescriptionFormViewModel();
    public get _OutPatientPrescription(): OutPatientPrescription {
        return this._TTObject as OutPatientPrescription;
    }
    private OutPatientPrescriptionForm_DocumentUrl: string = '/api/OutPatientPrescriptionService/OutPatientPrescriptionForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.OutPatientPrescriptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async cmdAddDiagnosis_Click(): Promise<void> {

    }
    private async cmdAddTemplate_Click(): Promise<void> {
      /*  let description: string = TTVisual.InputForm.GetText("Şablon Açıklaması");
        if (String.isNullOrEmpty(description) === false) {
            let userTemplates: Array<any> = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(this._OutPatientPrescription.ObjectDef.ID) + " AND DESCRIPTION = '" + description + "'");
            if (userTemplates.length === 0) {
                let userTemplate: UserTemplate = new UserTemplate(this._OutPatientPrescription.ObjectContext);
                userTemplate.ResUser = <ResUser>Common.CurrentResource;
                userTemplate.Description = description;
                userTemplate.TAObjectID = this._OutPatientPrescription.ObjectID;
                userTemplate.TAObjectDefID = this._OutPatientPrescription.ObjectDef.ID;
                switch (this._OutPatientPrescription.PrescriptionType) {
                    case PrescriptionTypeEnum.NormalPrescription:
                        userTemplate.FiliterData = "NormalPrescription";
                        break;
                    case PrescriptionTypeEnum.RedPrescription:
                        userTemplate.FiliterData = "RedPrescription";
                        break;
                    case PrescriptionTypeEnum.GreenPrescription:
                        userTemplate.FiliterData = "GreenPrescription";
                        break;
                    case PrescriptionTypeEnum.OrangePrescription:
                        userTemplate.FiliterData = "OrangePrescription";
                        break;
                    case PrescriptionTypeEnum.PurplePrescription:
                        userTemplate.FiliterData = "PurplePrescription";
                        break;
                    case PrescriptionTypeEnum.ControlledPrescription:
                        userTemplate.FiliterData = "ControlledPrescription";
                        break;
                    default:
                        throw new TTException("Hatalı Reçete Tipi");
                }
                this.cmdAddTemplate.Enabled = false;
            }
            else {
                TTVisual.InfoBox.Show(description + " isimli şablonunuz bulunduğu için şablon kayıt edilemedi", MessageIconEnum.ErrorMessage);
            }
        }
        else TTVisual.InfoBox.Show("Şablona isim vermeden kaydedemezsiniz.", MessageIconEnum.ErrorMessage);*/
    }
    onttdatetimepicker1Changed(data: any){}
    onReceiptNOChanged(data: any){}
    GridDiagnosisGridList;
    ttdatetimepicker1;
    ReceiptNO;


    private async cmdChangeSpeciality_Click(): Promise<void> {
      /*  let currentUser: ResUser = Common.CurrentResource;
        let specialityies: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
        for (let sGrid of currentUser.ResourceSpecialities) {
            if (sGrid.Speciality.ObjectID.Equals(this._OutPatientPrescription.SpecialityDefinition.ObjectID) === false) {
                if (specialityies.Contains(sGrid.Speciality) === false)
                    specialityies.push(sGrid.Speciality);
            }
        }
        if (specialityies.length > 0) {
            let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let speciality of specialityies) { multiSelectForm.AddMSItem(speciality.Code + " - " + speciality.Name, speciality.Name, speciality); }
            let key: string = multiSelectForm.GetMSItem(ParentForm, "Uzmanlık dalı seçiniz", false, false, false, false, true, false);
            if (!String.isNullOrEmpty(key))
                this._OutPatientPrescription.SpecialityDefinition = <SpecialityDefinition>multiSelectForm.MSSelectedItemObject;
        }
        else TTVisual.InfoBox.Show("Başka uzmanlık dalı tanımlı değil", MessageIconEnum.InformationMessage);*/
    }
    private async cmdGetFavoriteDrugs_Click(): Promise<void> {

    }
    private async cmdGetTemplate_Click(): Promise<void> {
      /*  let prescriptionTypeFiliter: string = "\"\"";
        switch (this._OutPatientPrescription.PrescriptionType) {
            case PrescriptionTypeEnum.NormalPrescription:
                prescriptionTypeFiliter = "NormalPrescription";
                break;
            case PrescriptionTypeEnum.RedPrescription:
                prescriptionTypeFiliter = "RedPrescription";
                break;
            case PrescriptionTypeEnum.GreenPrescription:
                prescriptionTypeFiliter = "GreenPrescription";
                break;
            case PrescriptionTypeEnum.OrangePrescription:
                prescriptionTypeFiliter = "OrangePrescription";
                break;
            case PrescriptionTypeEnum.PurplePrescription:
                prescriptionTypeFiliter = "PurplePrescription";
                break;
            case PrescriptionTypeEnum.ControlledPrescription:
                prescriptionTypeFiliter = "ControlledPrescription";
                break;
            default:
                throw new TTException("Hatalı Reçete Tipi");
        }
        let userTemplates: Array<any> = this._OutPatientPrescription.ObjectContext.QueryObjects("USERTEMPLATE", "RESUSER =" + ConnectionManager.GuidToString(Common.CurrentResource.ObjectID) + "AND TAOBJECTDEFID = " + ConnectionManager.GuidToString(this._OutPatientPrescription.ObjectDef.ID) + " AND FILITERDATA ='" + prescriptionTypeFiliter + "'");
        //IList userTepmlates = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(_OutPatientPrescription.ObjectDef.ID)+ " AND FILITERDATA ='"+ prescriptionTypeFiliter+"'" );
        if (userTemplates.length > 0) {
            let pForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let userTemplate of userTemplates) {
                pForm.AddMSItem(userTemplate.Description, userTemplate.ObjectID.toString(), userTemplate);
            }
            let sKey: string = pForm.GetMSItem(this, "Şablon seçiniz.", false, false, false, false, true, false);
            if (!String.isNullOrEmpty(sKey)) {
                let selectedTemplate: UserTemplate = <UserTemplate>pForm.MSSelectedItemObject;
                let outPatientPrescription: OutPatientPrescription = <OutPatientPrescription>this._OutPatientPrescription.ObjectContext.GetObject(<Guid>selectedTemplate.TAObjectID, <Guid>selectedTemplate.TAObjectDefID);
                for (let drugOrder of outPatientPrescription.OutPatientDrugOrders) {
                    let newDrugOrder: OutPatientDrugOrder = new OutPatientDrugOrder(this._OutPatientPrescription.ObjectContext);
                    newDrugOrder.OutPatientPrescription = this._OutPatientPrescription;
                    newDrugOrder.Amount = drugOrder.Amount;
                    newDrugOrder.Day = drugOrder.Day;
                    newDrugOrder.Description = drugOrder.Description;
                    newDrugOrder.DescriptionType = drugOrder.DescriptionType;
                    newDrugOrder.DoseAmount = drugOrder.DoseAmount;
                    newDrugOrder.DrugUsageType = drugOrder.DrugUsageType;
                    newDrugOrder.Frequency = drugOrder.Frequency;
                    newDrugOrder.Material = drugOrder.Material;
                    newDrugOrder.PackageAmount = drugOrder.PackageAmount;
                    newDrugOrder.PeriodUnitType = drugOrder.PeriodUnitType;
                    newDrugOrder.PhysicianDrug = drugOrder.PhysicianDrug;
                    newDrugOrder.Price = drugOrder.Price;
                    newDrugOrder.RequiredAmount = drugOrder.RequiredAmount;
                    newDrugOrder.SelectedMaterial = drugOrder.SelectedMaterial;
                    newDrugOrder.StoreInheld = drugOrder.StoreInheld;
                    newDrugOrder.Store = drugOrder.Store;
                    newDrugOrder.UsageNote = drugOrder.UsageNote;
                    newDrugOrder.UseAmount = drugOrder.UseAmount;
                    newDrugOrder.TreatmentTime = drugOrder.TreatmentTime;
                }
            }
        }
        else TTVisual.InfoBox.Show("Herhangibir reçete şablonunuz bulunmamaktadır", MessageIconEnum.InformationMessage);*/
    }
    private async DrugListview_DoubleClick(): Promise<void> {
        let drugGuid: Guid = new Guid(this.DrugListview.SelectedItems[0].SubItems[2].Text);
      //  this._OutPatientPrescription.AddDrug(drugGuid);
    }
    private async FavoriteDrugListview_DoubleClick(): Promise<void> {
        let drugGuid: Guid = new Guid(this.FavoriteDrugListview.SelectedItems[0].SubItems[1].Text);
      //  this._OutPatientPrescription.AddDrug(drugGuid);
    }
    private async OutPatientDrugOrders_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
      /*  if (this.OutPatientDrugOrders.CurrentCell !== null) {
            if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === this.OutPatientDrugOrders.Columns[this.cmdSelectBarcodeLevel.Name].Name) {
                if (this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value !== null) {
                    let levels: Dictionary<Guid, MaterialBarcodeLevel> = new Dictionary<Guid, MaterialBarcodeLevel>();
                    let drugDefinition: DrugDefinition = <DrugDefinition>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value.toString()), "DRUGDEFINITION");
                    let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                    for (let barcodeLevel of drugDefinition.MaterialBarcodeLevels) {
                        if (levels.containsKey(barcodeLevel.ObjectID) === false)
                            levels.push(barcodeLevel.ObjectID, barcodeLevel);
                    }
                    for (let level of levels) {
                        multiSelectForm.AddMSItem(level.Value.Name.toString(), level.Value.Name.toString(), level.Value);
                    }
                    let key: string = multiSelectForm.GetMSItem(ParentForm, "İlaç Formunu Seçiniz");
                    if (!String.isNullOrEmpty(key)) {
                        this.OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = (<MaterialBarcodeLevel>multiSelectForm.MSSelectedItemObject).Name.toString();
                    }
                }
            }
            else if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === this.OutPatientDrugOrders.Columns[this.IlacEtkinMadde.Name].Name) {
                if (this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value !== null) {
                    let drug: DrugDefinition = <DrugDefinition>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value.toString()), "DRUGDEFINITION");
                    let drugOrderIntroductionNewUnbound: DrugOrderIntroductionNewUnbound = new DrugOrderIntroductionNewUnbound(<OutPatientDrugOrder>this.OutPatientDrugOrders.CurrentCell.OwningRow.TTObject, <PrescriptionTypeEnum>this._OutPatientPrescription.PrescriptionType);
                    TTVisual.InfoBox.Show("drugOrderIntroductionNewUnbound.ShowDialog(this);");
                    if (<DrugDefinition>drugOrderIntroductionNewUnbound.Tag !== null) {
                        drug = <DrugDefinition>drugOrderIntroductionNewUnbound.Tag;
                        this.OutPatientDrugOrders.CurrentCell.OwningRow.Cells["Drug"].Value = drug.ObjectID;
                        this.OutPatientDrugOrders.CurrentCell.OwningRow.Cells["PhysicianDrug"].Value = drug.ObjectID;
                    }
                }
            }
            else if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === this.OutPatientDrugOrders.Columns[this.SUTRules.Name].Name) {
                if (this.OutPatientDrugOrders.CurrentCell.OwningRow.TTObject === null)
                    return;
                let odo: OutPatientDrugOrder = <OutPatientDrugOrder>this.OutPatientDrugOrders.CurrentCell.OwningRow.TTObject;
                if (odo.PhysicianDrug.EtkinMadde === null) {
                    TTVisual.InfoBox.Show("Bu ilaç herhangi bir medula etkin madde tanımı ile eşleştirilmemiştir.");
                    return;
                }
                let filter: string = "ETKINMADDE = '" + odo.PhysicianDrug.EtkinMadde.ObjectID.toString() + "'";
                let acts: Array<any> = this._OutPatientPrescription.ObjectContext.QueryObjects(typeof ActiveIngredientPrescriptionSUTRuleDef, filter);
                if (acts.length === 0) {
                    TTVisual.InfoBox.Show("Bu etken maddeye ait kural tanımı bulunamadı!");
                    return;
                }
                else {
                    let act: ActiveIngredientPrescriptionSUTRuleDef = <ActiveIngredientPrescriptionSUTRuleDef>acts[0];
                    let frm: TTDefinitionForm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["ActiveIngredientPrescriptionSUTRuleDefinitionList"], filter);
                    frm.ShowReadOnly(this.FindForm(), TTObjectDefManager.Instance.ListDefs["ActiveIngredientPrescriptionSUTRuleDefinitionList"], act, filter);
                }
            }
        }*/
    }
    private async OutPatientDrugOrders_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === "PhysicianDrug") {
            if (this.OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value !== null) {
                let drugDefinition: DrugDefinition = <DrugDefinition>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(this.OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value.toString()), "DRUGDEFINITION");
                let outPatientDrugOrderRow: TTVisual.ITTGridRow = this.OutPatientDrugOrders.Rows[this.OutPatientDrugOrders.CurrentCell.RowIndex];
                let drugOrder: OutPatientDrugOrder = (<OutPatientDrugOrder>outPatientDrugOrderRow.TTObject);
                drugOrder.Material = drugDefinition;
                if (drugDefinition.RouteOfAdmin !== null && drugDefinition.RouteOfAdmin.DrugUsageType !== null)
                    drugOrder.DrugUsageType = drugDefinition.RouteOfAdmin.DrugUsageType;
                drugOrder.PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
                drugOrder.Day = 1;
                if (drugDefinition.Frequency !== null)
                    drugOrder.Frequency = drugDefinition.Frequency;
                if (drugDefinition.RoutineDose !== null)
                    drugOrder.DoseAmount = drugDefinition.RoutineDose;
            }
        }
    }
    private async OutPatientDrugOrders_RowLeave(rowIndex: number, columnIndex: number): Promise<void> {
       /* let outPatientDrugOrderRow: TTVisual.ITTGridRow = this.OutPatientDrugOrders.Rows[this.OutPatientDrugOrders.CurrentCell.RowIndex];
        let drugOrder: OutPatientDrugOrder = (<OutPatientDrugOrder>outPatientDrugOrderRow.TTObject);
        drugOrder.Store = this._OutPatientPrescription.MasterResource.Store;
        let drugValue: string = "\"\"";
        if (drugOrder.Material === null)
            drugOrder.Material = (<Material>drugOrder.PhysicianDrug);
        drugValue = drugOrder.Material.ObjectID.toString();
        if (drugValue !== null) {
            let drugDefinition: DrugDefinition = <DrugDefinition>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(drugValue), "DRUGDEFINITION");
            if (outPatientDrugOrderRow.Cells["Frequency"].Value !== null && outPatientDrugOrderRow.Cells["DoseAmount"].Value !== null && outPatientDrugOrderRow.Cells["Day"].Value !== null && outPatientDrugOrderRow.Cells["TreatmentTime"].Value !== null) {
                let detailCount: number = (await DrugOrderService.GetDetailCount(<FrequencyEnum>outPatientDrugOrderRow.Cells["Frequency"].Value));
                let detailTimePeriod: number = (await DrugOrderService.GetDetailTimePeriod(<FrequencyEnum>outPatientDrugOrderRow.Cells["Frequency"].Value));
                let unitAmount: number = 0;
                let amount: number = 0;
                let material: Material = <Material>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(drugValue), "MATERIAL");
                if (material instanceof MagistralPreparationDefinition) {
                    outPatientDrugOrderRow.Cells["RequiredAmount"].Value = 1;
                    unitAmount = <number>outPatientDrugOrderRow.Cells["DoseAmount"].Value;
                    amount = 1;
                }
                else {
                    let drugType: boolean = (await DrugOrderService.GetDrugUsedType(drugDefinition));
                    if (drugType) {
                        unitAmount = <number>outPatientDrugOrderRow.Cells["DoseAmount"].Value;
                    }
                    else {
                        unitAmount = Math.Round(<number>outPatientDrugOrderRow.Cells["DoseAmount"].Value * <number>drugDefinition.Dose / <number>drugDefinition.Volume, 2, MidpointRounding.AwayFromZero);
                    }
                    let periodUnit: PeriodUnitTypeEnum = <PeriodUnitTypeEnum>drugOrder.PeriodUnitType;
                    let day: number = 0;
                    day = Math.Round(<number>drugOrder.TreatmentTime / <number>drugOrder.Day);
                    detailCount = detailCount * day;
                    amount = Math.Ceiling(unitAmount * (<number>detailCount));
                    let inheld: boolean = false;
                    if (drugDefinition.StockInheld(this._OutPatientPrescription.MasterResource.Store) > amount) {
                        inheld = true;
                    }
                    else {
                        inheld = false;
                    }
                    if (drugDefinition.PackageAmount !== null) {
                        if (amount > (<number>drugDefinition.PackageAmount.Value)) {
                            let pAmount: number = Math.Ceiling(amount / (<number>drugDefinition.PackageAmount.Value));
                            outPatientDrugOrderRow.Cells["PackageAmount"].Value = pAmount;
                            outPatientDrugOrderRow.Cells["Amount"].Value = (<number>outPatientDrugOrderRow.Cells["PackageAmount"].Value) * (<number>drugDefinition.PackageAmount.Value);
                        }
                        else {
                            outPatientDrugOrderRow.Cells["Amount"].Value = (<number>drugDefinition.PackageAmount.Value);
                            outPatientDrugOrderRow.Cells["PackageAmount"].Value = 1;
                        }
                    }
                    outPatientDrugOrderRow.Cells["Amount"].Value = amount;
                    outPatientDrugOrderRow.Cells["RequiredAmount"].Value = amount;
                }
            }
            if (outPatientDrugOrderRow.Cells["Amount"].Value === null && drugDefinition.PackageAmount !== null && outPatientDrugOrderRow.Cells["PackageAmount"].Value !== null) {
                let drugType: boolean = (await DrugOrderService.GetDrugUsedType(drugDefinition));
                if (drugType)
                    outPatientDrugOrderRow.Cells["Amount"].Value = drugDefinition.PackageAmount * <number>outPatientDrugOrderRow.Cells["PackageAmount"].Value;
                else outPatientDrugOrderRow.Cells["Amount"].Value = 1;
            }
        }*/
    }
   /* private async OutPatientDrugOrders_RowValidating(rowIndex: number, columnIndex: number, e: CancelEventArgs): Promise<void> {

    }*/
    private async PrescriptionType_SelectedIndexChanged(): Promise<void> {
       /* this.PrescriptionType.Enabled = false;
        let a: number = <number>this._OutPatientPrescription.PrescriptionType.Value;
        let filiterExpration: string = "PRESCRIPTIONTYPE=" + a.toString();
        if ((await SubEpisodeService.IsSGKSubEpisode(this._OutPatientPrescription.SubEpisode))) {
            filiterExpration = filiterExpration + " AND ISOLDMATERIAL = 0";
        }
        (<TTListBoxColumn>(this.OutPatientDrugOrders.Columns["PhysicianDrug"])).ListFilterExpression = filiterExpration;*/
    }
    private async SearchTextbox_TextChanged(): Promise<void> {
     /*   this.DrugListview.Items.Clear();
        if (this.SearchTextbox.Text.Length > 2) {
            let a: number = <number>this._OutPatientPrescription.PrescriptionType.Value;
            let filiterExpration: string = "AND PRESCRIPTIONTYPE=" + a.toString();
            if ((await SubEpisodeService.IsSGKSubEpisode(this._OutPatientPrescription.SubEpisode))) {
                filiterExpration = filiterExpration + " AND ISOLDMATERIAL = 0";
            }
            let context: TTObjectContext = new TTObjectContext(true);
            let drugs: Array<any> = context.QueryObjects("DRUGDEFINITION", "NAME_SHADOW like '" + this.SearchTextbox.Text + "%'" + filiterExpration);
            for (let drug of drugs) {
                let item: TTVisual.ITTListViewItem = this.DrugListview.Items.push(drug.Name);
                item.SubItems.push(drug.PharmacyInheldStatus);
                item.SubItems.push(drug.ObjectID.toString());
            }
        }*/
    }
    private async SendESignedPrescription_Click(): Promise<void> {

    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
      /*  if (transDef !== null) {
            if (transDef.FromStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.Request && transDef.ToStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.CompletedWithSign) {
                if ((await SubEpisodeService.IsSGKSubEpisode(this._OutPatientPrescription.SubEpisode)) && this.EReceteNo === null) {
                    if (this._OutPatientPrescription.SubEpisode.SGKSEP !== null && !String.isNullOrEmpty(this._OutPatientPrescription.SubEpisode.SGKSEP.MedulaTakipNo)) {
                        if (String.isNullOrEmpty(_Prescription.ERecetePassword))
                            throw new TTException("E Reçete şifrenizi giriniz");
                    }
                    else throw new TTException("Hastaya Medula Provizyon Alınmadığında Dolayı e-Reçete Kaydı Yapılamamıştır.");
                }
            }
        }*/
    }
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
      /*  if (this._OutPatientPrescription.Episode.PatientStatus === PatientStatusEnum.Discharge)
            this._OutPatientPrescription.IsDischargePrescripiton = true;
        else if (this._OutPatientPrescription.Episode.PatientStatus === PatientStatusEnum.Inpatient) {
            let isDıschargeApp: boolean = false;
            for (let app of this._OutPatientPrescription.Episode.InPatientTreatmentClinicApplications) {
                if (app.CurrentStateDefID === InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Discharged)
                    isDıschargeApp = true;
            }
            if (isDıschargeApp)
                this._OutPatientPrescription.IsDischargePrescripiton = true;
            else {
                if ((this._OutPatientPrescription.IsDischargePrescripiton !== undefined)) {
                    if (this._OutPatientPrescription.IsDischargePrescripiton === false)
                        throw new Exception("Klinik işlemleri Taburcu durumunda olmadığı için taburcu reçetesi yazamazsınız. Klinik Taburcu işlemlerini tamamlayarak hasta çıkış bilgisini MEDULA'ya bildiriniz.");
                }
                else throw new Exception("Klinik işlemleri Taburcu durumunda olmadığı için taburcu reçetesi yazamazsınız. Klinik Taburcu işlemlerini tamamlayarak hasta çıkış bilgisini MEDULA'ya bildiriniz.");
            }
        }
        if ((await SubEpisodeService.IsSGKSubEpisode(this._OutPatientPrescription.SubEpisode))) {
            let currentUser: ResUser = Common.CurrentResource;
            (<ITTObject>currentUser).Refresh();
            if (String.isNullOrEmpty(currentUser.ErecetePassword)) {

            }
            else this._OutPatientPrescription.ERecetePassword = currentUser.ErecetePassword;
            if (currentUser.ResourceSpecialities.length > 0) {
                //ResourceSpecialities içerisinde MainSpeciality'i true olan Speciality'i SpecialityDefinition'a set ediyor. Eğer MainSpeciality hiçbir Speciality için true değil ise ResourceSpecialities
                //içerisinde ilk sırada olan Speciality, SpecialityDefinition'a set ediliyor. /CKE
                for (let sGrid of currentUser.ResourceSpecialities) {
                    if (sGrid.MainSpeciality !== null && sGrid.MainSpeciality === true) {
                        this._OutPatientPrescription.SpecialityDefinition = sGrid.Speciality;
                    }
                }
            }
            else throw new Exception("Uzmanlık dalınız tanımlı olmadığı için e reçete yazamazsınız.");
        }
        else {
            this.SpecialityDefinition.Required = false;
            this.cmdChangeSpeciality.Enabled = false;
        }
        if (this._OutPatientPrescription.PrescriptionType === null) {
            let pValues: Array = Enum.GetValues(typeof PrescriptionTypeEnum);
            let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let pType of pValues) {
                if (pType.Equals(PrescriptionTypeEnum.NormalPrescription))
                    multiSelectForm.AddMSItem("1 Normal Reçete", "Normal Reçete", pType);
                else if (pType.Equals(PrescriptionTypeEnum.RedPrescription))
                    multiSelectForm.AddMSItem("2 Kırmızı Reçete", "Kırmızı Reçete", pType);
                else if (pType.Equals(PrescriptionTypeEnum.GreenPrescription))
                    multiSelectForm.AddMSItem("3 Yeşil Reçete", "Yeşil Reçete", pType);
                else if (pType.Equals(PrescriptionTypeEnum.PurplePrescription))
                    multiSelectForm.AddMSItem("4 Mor Reçete", "Mor Reçete", pType);
                else if (pType.Equals(PrescriptionTypeEnum.OrangePrescription))
                    multiSelectForm.AddMSItem("5 Turuncu Reçete", "Turuncu Reçete", pType);
                else if (pType.Equals(PrescriptionTypeEnum.ControlledPrescription))
                    multiSelectForm.AddMSItem("6 Kontrollü Reçete", "Kontrollü Reçete", pType);
            }
            let key: string = multiSelectForm.GetMSItem(ParentForm, "Reçete Tipi seçiniz", false, false, false, false, true);
            if (!String.isNullOrEmpty(key))
                this._OutPatientPrescription.PrescriptionType = <PrescriptionTypeEnum>multiSelectForm.MSSelectedItemObject;
            else throw new TTException("Reçete işleminden vazgeçildi.");
        }
        let presTypeMaterialMatch: Array<any> = this._OutPatientPrescription.ObjectContext.QueryObjects("PRESTYPEMATERIALMATCHDEF", "PRESCRIPTIONTYPE =" + (<number>this._OutPatientPrescription.PrescriptionType).toString());
        if (presTypeMaterialMatch.length > 0) {
            if (this._OutPatientPrescription.MasterResource.Store === null)
                throw new TTException(this._OutPatientPrescription.MasterResource.Name + " bölümünün deposu bulunmamaktadır. Bilgi işleme haber veriniz.");
            this.PrescriptionPaper.Required = true;
            this.PrescriptionPaper.ListFilterExpression = "STOCK.STORE=" + ConnectionManager.GuidToString(this._OutPatientPrescription.MasterResource.Store.ObjectID) + " AND STOCK.MATERIAL =" + ConnectionManager.GuidToString((<PresTypeMaterialMatchDef>presTypeMaterialMatch[0]).Material.ObjectID);
        }
        else this.PrescriptionPaper.ReadOnly = true;
        let drugs: Array<any> = (await FavoriteDrugService.GetFavoriteDrugs((<ResUser>Common.CurrentUser.UserObject).ObjectID));
        for (let d of drugs) {
            let item: TTVisual.ITTListViewItem = this.FavoriteDrugListview.Items.push(d.Name);
            item.SubItems.push(d.DrugDefinition.toString());
        }
        //IBindingList drugs = _OutPatientPrescription.ObjectContext.QueryObjects("FAVORITEDRUG", "RESUSER =" + ConnectionManager.GuidToString(((ResUser)Common.CurrentUser.UserObject).ObjectID));
        //Hashtable unSortedFavoriteDrugList = new Hashtable();
        //foreach (FavoriteDrug favoriteDrug in drugs)
        //{
        //    if (unSortedFavoriteDrugList.ContainsKey(favoriteDrug.DrugDefinition) == false)
        //    {
        //        Common.TTDoubleSortableList favoriteDrugListItem = new Common.TTDoubleSortableList();
        //        favoriteDrugListItem.ID = favoriteDrug.DrugDefinition;
        //        favoriteDrugListItem.Value = (double)favoriteDrug.Count;
        //        unSortedFavoriteDrugList.Add(favoriteDrugListItem.ID, favoriteDrugListItem);
        //    }

        //}

        //List<Common.TTDoubleSortableList> favoriteDrugList = Common.SortedDoubleItems(unSortedFavoriteDrugList);
        //favoriteDrugList.Reverse();
        //foreach (Common.TTDoubleSortableList sortList in favoriteDrugList)
        //{
        //    ITTListViewItem item = FavoriteDrugListview.Items.Add(((DrugDefinition)sortList.ID).Name);
        //    item.SubItems.Add(((DrugDefinition)sortList.ID).ObjectID.ToString());
        //}



        /*if (_OutPatientPrescription.Episode.Patient.PatientGroup == PatientGroupEnum.PrivateNonCom)
        {

            this.DropStateButton(OutPatientPrescription.States.Completed);
            this.DropStateButton(OutPatientPrescription.States.CompletedWithSign);
        }
        else
        {
            this.DropStateButton(OutPatientPrescription.States.DrugControl);
        }

        //            if (_OutPatientPrescription.Episode.Patient.PatientGroup == PatientGroupEnum.CivilCadetCandidate || _OutPatientPrescription.Episode.Patient.PatientGroup == PatientGroupEnum.CivilianConsignment)
        //            {
        //                this.DropStateButton(OutPatientPrescription.States.DrugControl);
        //            }
        //            else
        //            {
        //                this.DropStateButton(OutPatientPrescription.States.Completed);
        //            }

        if (this._OutPatientPrescription.Episode.Diagnosis.length === 0) {
            throw new TTException((await SystemMessageService.GetMessage(1213)));
        }
        else {
            let diagnosises: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
            //                foreach (EpisodeAction episodeAction in _OutPatientPrescription.Episode.EpisodeActions)
            //                {
            //                    if(episodeAction is PatientExamination)
            //                    {
            //                        foreach (DiagnosisGrid diag in ((PatientExamination)episodeAction).Diagnosis)
            //                        {
            //                            if (diagnosises.Contains(diag.Diagnose) == false)
            //                                diagnosises.Add(diag.Diagnose);
            //                        }
            //                    }
            //                }

            for (let diag of this._OutPatientPrescription.Episode.Diagnosis) {
                if (diagnosises.Contains(diag.Diagnose) === false)
                    diagnosises.push(diag.Diagnose);
            }
            if (diagnosises.length > 0) {
                for (let dia of diagnosises) {
                    let diagnosisForPresc: DiagnosisForPresc = new DiagnosisForPresc(this._OutPatientPrescription.ObjectContext);
                    diagnosisForPresc.Check = true;
                    diagnosisForPresc.Code = dia.Code;
                    diagnosisForPresc.Name = dia.Name;
                    diagnosisForPresc.Prescription = this._OutPatientPrescription;
                }
            }
        }
        let pharmacyStore: Array<any> = (await PharmacyStoreDefinitionService.GetInpatientPharmacyStore(this._OutPatientPrescription.ObjectContext));
        if (pharmacyStore.length === 1) {
            let store: PharmacyStoreDefinition = <PharmacyStoreDefinition>pharmacyStore[0];
            let pharmacyResource: Array<any> = (await ResourceService.GetResourceByStore(this._OutPatientPrescription.ObjectContext, store.ObjectID));
            if (pharmacyResource.length === 1) {
                this._OutPatientPrescription.MasterResource = <ResSection>pharmacyResource[0];
            }
            else if (pharmacyResource.length > 1) {
                throw new Exception((await SystemMessageService.GetMessage(1008)));
            }
        }*/
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
      /*  let outPatientPrescription: OutPatientPrescription = <OutPatientPrescription>this._ttObject;
        for (let outPatientDrugOrder of outPatientPrescription.OutPatientDrugOrders) {
            outPatientDrugOrder.CurrentStateDefID = OutPatientDrugOrder.OutPatientDrugOrderStates.New;
            outPatientDrugOrder.Episode = this._OutPatientPrescription.Episode;
            if (outPatientDrugOrder.Amount === null)
                outPatientDrugOrder.Amount = outPatientDrugOrder.RequiredAmount;
        }*/
    }
    protected async PreScript() {
        super.PreScript();
    }
    public async SendEreceteSignedDailyPresApproval(currentUser: ResUser): Promise<void> {
        let uniqueNo: number = <number>Convert.ToDouble(currentUser.UniqueNo);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OutPatientPrescription();
        this.outPatientPrescriptionFormViewModel = new OutPatientPrescriptionFormViewModel();
        this._ViewModel = this.outPatientPrescriptionFormViewModel;
        this.outPatientPrescriptionFormViewModel._OutPatientPrescription = this._TTObject as OutPatientPrescription;
        this.outPatientPrescriptionFormViewModel._OutPatientPrescription.OutPatientDrugOrders = new Array<OutPatientDrugOrder>();
        this.outPatientPrescriptionFormViewModel._OutPatientPrescription.SPTSDiagnosises = new Array<DiagnosisForPresc>();
        this.outPatientPrescriptionFormViewModel._OutPatientPrescription.PrescriptionPaper = new PrescriptionPaper();
        this.outPatientPrescriptionFormViewModel._OutPatientPrescription.SpecialityDefinition = new SpecialityDefinition();
        this.outPatientPrescriptionFormViewModel._OutPatientPrescription.Episode = new Episode();
        this.outPatientPrescriptionFormViewModel._OutPatientPrescription.Episode.Patient = new Patient();
    }

    protected loadViewModel() {
        let that = this;

        that.outPatientPrescriptionFormViewModel = this._ViewModel as OutPatientPrescriptionFormViewModel;
        that._TTObject = this.outPatientPrescriptionFormViewModel._OutPatientPrescription;
        if (this.outPatientPrescriptionFormViewModel == null)
            this.outPatientPrescriptionFormViewModel = new OutPatientPrescriptionFormViewModel();
        if (this.outPatientPrescriptionFormViewModel._OutPatientPrescription == null)
            this.outPatientPrescriptionFormViewModel._OutPatientPrescription = new OutPatientPrescription();
        that.outPatientPrescriptionFormViewModel._OutPatientPrescription.OutPatientDrugOrders = that.outPatientPrescriptionFormViewModel.OutPatientDrugOrdersGridList;
        for (let detailItem of that.outPatientPrescriptionFormViewModel.OutPatientDrugOrdersGridList) {
            let physicianDrugObjectID = detailItem["PhysicianDrug"];
            if (physicianDrugObjectID != null && (typeof physicianDrugObjectID === 'string')) {
                let physicianDrug = that.outPatientPrescriptionFormViewModel.DrugDefinitions.find(o => o.ObjectID.toString() === physicianDrugObjectID.toString());
                 if (physicianDrug) {
                    detailItem.PhysicianDrug = physicianDrug;
                }
            }
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.outPatientPrescriptionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
        that.outPatientPrescriptionFormViewModel._OutPatientPrescription.SPTSDiagnosises = that.outPatientPrescriptionFormViewModel.SPTSDiagnosisesGridList;
        for (let detailItem of that.outPatientPrescriptionFormViewModel.SPTSDiagnosisesGridList) {
        }
        let prescriptionPaperObjectID = that.outPatientPrescriptionFormViewModel._OutPatientPrescription["PrescriptionPaper"];
        if (prescriptionPaperObjectID != null && (typeof prescriptionPaperObjectID === 'string')) {
            let prescriptionPaper = that.outPatientPrescriptionFormViewModel.PrescriptionPapers.find(o => o.ObjectID.toString() === prescriptionPaperObjectID.toString());
             if (prescriptionPaper) {
                that.outPatientPrescriptionFormViewModel._OutPatientPrescription.PrescriptionPaper = prescriptionPaper;
            }
        }
        let specialityDefinitionObjectID = that.outPatientPrescriptionFormViewModel._OutPatientPrescription["SpecialityDefinition"];
        if (specialityDefinitionObjectID != null && (typeof specialityDefinitionObjectID === 'string')) {
            let specialityDefinition = that.outPatientPrescriptionFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityDefinitionObjectID.toString());
             if (specialityDefinition) {
                that.outPatientPrescriptionFormViewModel._OutPatientPrescription.SpecialityDefinition = specialityDefinition;
            }
        }
        let episodeObjectID = that.outPatientPrescriptionFormViewModel._OutPatientPrescription["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.outPatientPrescriptionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.outPatientPrescriptionFormViewModel._OutPatientPrescription.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.outPatientPrescriptionFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(OutPatientPrescriptionFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.ActionDate != event) {
                this._OutPatientPrescription.ActionDate = event;
            }
        }
    }

    public onDiscriptionOfPharmacistChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.DiscriptionOfPharmacist != event) {
                this._OutPatientPrescription.DiscriptionOfPharmacist = event;
            }
        }
    }

    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.Emergency != event) {
                this._OutPatientPrescription.Emergency = event;
            }
        }
    }

    public onEReceteDescriptionChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.EReceteDescription != event) {
                this._OutPatientPrescription.EReceteDescription = event;
            }
        }
    }

    public onEReceteNoChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.EReceteNo != event) {
                this._OutPatientPrescription.EReceteNo = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.ID != event) {
                this._OutPatientPrescription.ID = event;
            }
        }
    }

    public onPatientFullNameChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null &&
                this._OutPatientPrescription.Episode != null &&
                this._OutPatientPrescription.Episode.Patient != null && this._OutPatientPrescription.Episode.Patient.FullName != event) {
                this._OutPatientPrescription.Episode.Patient.FullName = event;
            }
        }
    }

    public onPrescriptionPaperChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.PrescriptionPaper != event) {
                this._OutPatientPrescription.PrescriptionPaper = event;
            }
        }
    }

    public onPrescriptionTypeChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.PrescriptionType != event) {
                this._OutPatientPrescription.PrescriptionType = event;
            }
        }
    }

    public onSpecialityDefinitionChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.SpecialityDefinition != event) {
                this._OutPatientPrescription.SpecialityDefinition = event;
            }
        }
    }



    OutPatientDrugOrders_CellValueChangedEmitted(data: any) {
        if (data && this.OutPatientDrugOrders_CellValueChanged && data.Row && data.Column) {
            this.OutPatientDrugOrders.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.OutPatientDrugOrders_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.ID, "Text", this.__ttObject, "ID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.PrescriptionType, "Value", this.__ttObject, "PrescriptionType");
        redirectProperty(this.PatientFullName, "Text", this.__ttObject, "Episode.Patient.FullName");
        redirectProperty(this.EReceteNo, "Text", this.__ttObject, "EReceteNo");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.EReceteDescription, "Text", this.__ttObject, "EReceteDescription");
        redirectProperty(this.DiscriptionOfPharmacist, "Text", this.__ttObject, "DiscriptionOfPharmacist");
    }

    public initFormControls(): void {
        this.SendESignedPrescription = new TTVisual.TTButton();
        this.SendESignedPrescription.Text = i18n("M13512", "E-İmzalı Reçete Gönder");
        this.SendESignedPrescription.Name = "SendESignedPrescription";
        this.SendESignedPrescription.TabIndex = 36;
        this.SendESignedPrescription.Visible = false;

        this.DigitalSignatureButton = new TTVisual.TTButton();
        this.DigitalSignatureButton.Text = i18n("M13510", "e-imza doğrulanamadı");
        this.DigitalSignatureButton.Name = "DigitalSignatureButton";
        this.DigitalSignatureButton.TabIndex = 95;
        this.DigitalSignatureButton.Visible = false;

        this.cmdAddTemplate = new TTVisual.TTButton();
        this.cmdAddTemplate.Text = i18n("M20971", "Reçeteyi Şablon Olarak Kaydet");
        this.cmdAddTemplate.Name = "cmdAddTemplate";
        this.cmdAddTemplate.TabIndex = 5;

        this.cmdGetTemplate = new TTVisual.TTButton();
        this.cmdGetTemplate.Text = i18n("M22461", "Şablonları Getir");
        this.cmdGetTemplate.Name = "cmdGetTemplate";
        this.cmdGetTemplate.TabIndex = 6;

        this.cmdGetFavoriteDrugs = new TTVisual.TTButton();
        this.cmdGetFavoriteDrugs.Text = i18n("M21798", "Sık Kullanılan İlaçlar");
        this.cmdGetFavoriteDrugs.Name = "cmdGetFavoriteDrugs";
        this.cmdGetFavoriteDrugs.TabIndex = 4;
        this.cmdGetFavoriteDrugs.Visible = false;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 7;

        this.DrugTabPage = new TTVisual.TTTabPage();
        this.DrugTabPage.DisplayIndex = 0;
        this.DrugTabPage.BackColor = "#FFFFFF";
        this.DrugTabPage.TabIndex = 0;
        this.DrugTabPage.Text = i18n("M16389", "İlaçlar");
        this.DrugTabPage.Name = "DrugTabPage";

        this.OutPatientDrugOrders = new TTVisual.TTGrid();
        this.OutPatientDrugOrders.Required = true;
        this.OutPatientDrugOrders.BackColor = "#FFE3C6";
        this.OutPatientDrugOrders.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.OutPatientDrugOrders.Name = "OutPatientDrugOrders";
        this.OutPatientDrugOrders.TabIndex = 0;

        this.PhysicianDrug = new TTVisual.TTListBoxColumn();
        this.PhysicianDrug.AllowMultiSelect = true;
        this.PhysicianDrug.ListDefName = "DrugOutPharInheldStatusList";
        this.PhysicianDrug.ListFilterExpression = "PRESCRIPTIONTYPE = 1";
        this.PhysicianDrug.DataMember = "PhysicianDrug";
        this.PhysicianDrug.Required = true;
        this.PhysicianDrug.DisplayIndex = 0;
        this.PhysicianDrug.HeaderText = i18n("M16287", "İlaç");
        this.PhysicianDrug.Name = "PhysicianDrug";
        this.PhysicianDrug.Width = 300;

        this.cmdSelectBarcodeLevel = new TTVisual.TTButtonColumn();
        this.cmdSelectBarcodeLevel.Text = i18n("M10768", "Ambalaj Tipi Seç");
        this.cmdSelectBarcodeLevel.UseColumnTextForButtonValue = true;
        this.cmdSelectBarcodeLevel.DisplayIndex = 1;
        this.cmdSelectBarcodeLevel.HeaderText = i18n("M21507", "Seç");
        this.cmdSelectBarcodeLevel.Name = "cmdSelectBarcodeLevel";
        this.cmdSelectBarcodeLevel.ToolTipText = i18n("M10768", "Ambalaj Tipi Seç");
        this.cmdSelectBarcodeLevel.Visible = false;
        this.cmdSelectBarcodeLevel.Width = 100;

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = "FrequencyEnum";
        this.Frequency.DataMember = "Frequency";
        this.Frequency.Required = true;
        this.Frequency.DisplayIndex = 2;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = "Frequency";
        this.Frequency.Width = 80;

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DataMember = "DoseAmount";
        this.DoseAmount.Required = true;
        this.DoseAmount.DisplayIndex = 3;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = "DoseAmount";
        this.DoseAmount.Width = 80;

        this.PeriodUnitType = new TTVisual.TTEnumComboBoxColumn();
        this.PeriodUnitType.DataTypeName = "PeriodUnitTypeEnum";
        this.PeriodUnitType.DataMember = "PeriodUnitType";
        this.PeriodUnitType.Required = true;
        this.PeriodUnitType.DisplayIndex = 4;
        this.PeriodUnitType.HeaderText = i18n("M17000", "K. Periyot Birimi");
        this.PeriodUnitType.Name = "PeriodUnitType";
        this.PeriodUnitType.Width = 100;

        this.Day = new TTVisual.TTTextBoxColumn();
        this.Day.DataMember = "Day";
        this.Day.Required = true;
        this.Day.DisplayIndex = 5;
        this.Day.HeaderText = "K. Peryodu";
        this.Day.Name = "Day";
        this.Day.Width = 80;

        this.PackageAmount = new TTVisual.TTTextBoxColumn();
        this.PackageAmount.DataMember = "PackageAmount";
        this.PackageAmount.Required = true;
        this.PackageAmount.DisplayIndex = 6;
        this.PackageAmount.HeaderText = i18n("M20130", "Paket Adedi");
        this.PackageAmount.Name = "PackageAmount";
        this.PackageAmount.Width = 80;

        this.DrugUsageType = new TTVisual.TTEnumComboBoxColumn();
        this.DrugUsageType.DataTypeName = "DrugUsageTypeEnum";
        this.DrugUsageType.SortBy = SortByEnum.DisplayText;
        this.DrugUsageType.DataMember = "DrugUsageType";
        this.DrugUsageType.Required = true;
        this.DrugUsageType.DisplayIndex = 7;
        this.DrugUsageType.HeaderText = i18n("M16348", "İlaç Kullanım Şekli");
        this.DrugUsageType.Name = "DrugUsageType";
        this.DrugUsageType.Width = 100;

        this.DescriptionType = new TTVisual.TTEnumComboBoxColumn();
        this.DescriptionType.DataTypeName = "DescriptionTypeEnum";
        this.DescriptionType.DataMember = "DescriptionType";
        this.DescriptionType.DisplayIndex = 8;
        this.DescriptionType.HeaderText = i18n("M10479", "Açıklama Türü");
        this.DescriptionType.Name = "DescriptionType";
        this.DescriptionType.Width = 100;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 9;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.Width = 100;

        this.TreatmentTime = new TTVisual.TTTextBoxColumn();
        this.TreatmentTime.DataMember = "TreatmentTime";
        this.TreatmentTime.DisplayIndex = 10;
        this.TreatmentTime.HeaderText = i18n("M23027", "Tedavi Süresi");
        this.TreatmentTime.Name = "TreatmentTime";
        this.TreatmentTime.Width = 80;

        this.RequiredAmount = new TTVisual.TTTextBoxColumn();
        this.RequiredAmount.DataMember = "RequiredAmount";
        this.RequiredAmount.DisplayIndex = 11;
        this.RequiredAmount.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequiredAmount.Name = "RequiredAmount";
        this.RequiredAmount.ReadOnly = true;
        this.RequiredAmount.Width = 80;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 12;
        this.Amount.HeaderText = i18n("M17315", "Karşılanan Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Visible = false;
        this.Amount.Width = 120;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.DisplayIndex = 13;
        this.UnitPrice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.Visible = false;
        this.UnitPrice.Width = 80;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.DisplayIndex = 14;
        this.Price.HeaderText = i18n("M23606", "Tutar");
        this.Price.Name = "Price";
        this.Price.Visible = false;
        this.Price.Width = 80;

        this.ReceivedPrice = new TTVisual.TTTextBoxColumn();
        this.ReceivedPrice.DataMember = "ReceivedPrice";
        this.ReceivedPrice.DisplayIndex = 15;
        this.ReceivedPrice.HeaderText = i18n("M16341", "İlaç Katılım Payı");
        this.ReceivedPrice.Name = "ReceivedPrice";
        this.ReceivedPrice.Visible = false;
        this.ReceivedPrice.Width = 80;

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = "UsageNote";
        this.UsageNote.DisplayIndex = 16;
        this.UsageNote.HeaderText = i18n("M17992", "Kullanma Tarifi");
        this.UsageNote.Name = "UsageNote";
        this.UsageNote.Width = 200;

        this.Drug = new TTVisual.TTListBoxColumn();
        this.Drug.ListDefName = "DrugOutPharInheldStatusList";
        this.Drug.ListFilterExpression = "PRESCRIPTIONTYPE = 1";
        this.Drug.DataMember = "Material";
        this.Drug.DisplayIndex = 17;
        this.Drug.HeaderText = i18n("M16287", "İlaç");
        this.Drug.Name = "Drug";
        this.Drug.Visible = false;
        this.Drug.Width = 300;

        this.IlacEtkinMadde = new TTVisual.TTButtonColumn();
        this.IlacEtkinMadde.Text = i18n("M16306", "İlaç Bilgileri");
        this.IlacEtkinMadde.UseColumnTextForButtonValue = true;
        this.IlacEtkinMadde.DisplayIndex = 18;
        this.IlacEtkinMadde.HeaderText = "";
        this.IlacEtkinMadde.Name = "IlacEtkinMadde";
        this.IlacEtkinMadde.Width = 75;

        this.SUTRules = new TTVisual.TTButtonColumn();
        this.SUTRules.Text = i18n("M22399", "SUT Kuralları");
        this.SUTRules.UseColumnTextForButtonValue = true;
        this.SUTRules.DisplayIndex = 19;
        this.SUTRules.HeaderText = "";
        this.SUTRules.Name = "SUTRules";
        this.SUTRules.Width = 75;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "EpisodeAction";
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 35;
        this.ttlabel3.Visible = false;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 3;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M15158", "Hasta Bilgileri");
        this.tttabpage1.Name = "tttabpage1";

        this.cmdAddDiagnosis = new TTVisual.TTButton();
        this.cmdAddDiagnosis.Text = i18n("M22744", "Tanı Ekle");
        this.cmdAddDiagnosis.Name = "cmdAddDiagnosis";
        this.cmdAddDiagnosis.TabIndex = 10;

        this.labelPrescriptionPaper = new TTVisual.TTLabel();
        this.labelPrescriptionPaper.Text = i18n("M20953", "Reçete No");
        this.labelPrescriptionPaper.Name = "labelPrescriptionPaper";
        this.labelPrescriptionPaper.TabIndex = 106;

        this.SPTSDiagnosises = new TTVisual.TTGrid();
        this.SPTSDiagnosises.Name = "SPTSDiagnosises";
        this.SPTSDiagnosises.TabIndex = 9;

        this.CheckDiagnosisForPresc = new TTVisual.TTCheckBoxColumn();
        this.CheckDiagnosisForPresc.DataMember = "Check";
        this.CheckDiagnosisForPresc.DisplayIndex = 0;
        this.CheckDiagnosisForPresc.HeaderText = i18n("M21507", "Seç");
        this.CheckDiagnosisForPresc.Name = "CheckDiagnosisForPresc";
        this.CheckDiagnosisForPresc.Width = 80;

        this.CodeDiagnosisForPresc = new TTVisual.TTTextBoxColumn();
        this.CodeDiagnosisForPresc.DataMember = "Code";
        this.CodeDiagnosisForPresc.DisplayIndex = 1;
        this.CodeDiagnosisForPresc.HeaderText = "Kodu";
        this.CodeDiagnosisForPresc.Name = "CodeDiagnosisForPresc";
        this.CodeDiagnosisForPresc.ReadOnly = true;
        this.CodeDiagnosisForPresc.Width = 80;

        this.NameDiagnosisForPresc = new TTVisual.TTTextBoxColumn();
        this.NameDiagnosisForPresc.DataMember = "Name";
        this.NameDiagnosisForPresc.DisplayIndex = 2;
        this.NameDiagnosisForPresc.HeaderText = i18n("M10514", "Adı");
        this.NameDiagnosisForPresc.Name = "NameDiagnosisForPresc";
        this.NameDiagnosisForPresc.ReadOnly = true;
        this.NameDiagnosisForPresc.Width = 250;

        this.PrescriptionPaper = new TTVisual.TTObjectListBox();
        this.PrescriptionPaper.ListDefName = "PrescriptionPaperListDefinition";
        this.PrescriptionPaper.Name = "PrescriptionPaper";
        this.PrescriptionPaper.TabIndex = 4;

        this.cmdChangeSpeciality = new TTVisual.TTButton();
        this.cmdChangeSpeciality.Text = i18n("M23875", "Uzmanlık Dalını Değiştir");
        this.cmdChangeSpeciality.Name = "cmdChangeSpeciality";
        this.cmdChangeSpeciality.TabIndex = 12;

        this.labelSpecialityDefinition = new TTVisual.TTLabel();
        this.labelSpecialityDefinition.Text = i18n("M23870", "Uzmanlık Dalı");
        this.labelSpecialityDefinition.Name = "labelSpecialityDefinition";
        this.labelSpecialityDefinition.TabIndex = 106;

        this.SpecialityDefinition = new TTVisual.TTObjectListBox();
        this.SpecialityDefinition.Required = true;
        this.SpecialityDefinition.ReadOnly = true;
        this.SpecialityDefinition.ListDefName = "SpecialityDefinitionList";
        this.SpecialityDefinition.Name = "SpecialityDefinition";
        this.SpecialityDefinition.TabIndex = 11;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ID.Name = "ID";
        this.ID.TabIndex = 2;

        this.labelEReceteNo = new TTVisual.TTLabel();
        this.labelEReceteNo.Text = i18n("M13425", "E Reçete No");
        this.labelEReceteNo.Name = "labelEReceteNo";
        this.labelEReceteNo.TabIndex = 101;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 86;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = i18n("M10422", "Acil Durum");
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 8;

        this.EReceteNo = new TTVisual.TTTextBox();
        this.EReceteNo.BackColor = "#F0F0F0";
        this.EReceteNo.ForeColor = "#FF0000";
        this.EReceteNo.ReadOnly = true;
        this.EReceteNo.Name = "EReceteNo";
        this.EReceteNo.TabIndex = 7;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 3;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.BackColor = "#DCDCDC";
        this.labelID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelID.ForeColor = "#000000";
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 1;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.BackColor = "#DCDCDC";
        this.labelActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelActionDate.ForeColor = "#000000";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 14;

        this.PatientFullName = new TTVisual.TTTextBox();
        this.PatientFullName.BackColor = "#F0F0F0";
        this.PatientFullName.ForeColor = "#FF0000";
        this.PatientFullName.ReadOnly = true;
        this.PatientFullName.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientFullName.Name = "PatientFullName";
        this.PatientFullName.TabIndex = 6;

        this.PrescriptionType = new TTVisual.TTEnumComboBox();
        this.PrescriptionType.DataTypeName = "PrescriptionTypeEnum";
        this.PrescriptionType.Name = "PrescriptionType";
        this.PrescriptionType.TabIndex = 5;

        this.labelPrescriptionType = new TTVisual.TTLabel();
        this.labelPrescriptionType.Text = i18n("M20964", "Reçete Türü");
        this.labelPrescriptionType.BackColor = "#DCDCDC";
        this.labelPrescriptionType.ForeColor = "#000000";
        this.labelPrescriptionType.Name = "labelPrescriptionType";
        this.labelPrescriptionType.TabIndex = 7;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = i18n("M21796", "Sık Kull. İlaçlar");
        this.tttabpage2.Name = "tttabpage2";

        this.FavoriteDrugListview = new TTVisual.TTListView();
        this.FavoriteDrugListview.Name = "FavoriteDrugListview";
        this.FavoriteDrugListview.TabIndex = 3;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = i18n("M13812", "E-Reçete Açıklaması");
        this.tttabpage3.Name = "tttabpage3";

        this.EReceteDescription = new TTVisual.TTTextBox();
        this.EReceteDescription.Multiline = true;
        this.EReceteDescription.BackColor = "#F0F0F0";
        this.EReceteDescription.ReadOnly = true;
        this.EReceteDescription.Name = "EReceteDescription";
        this.EReceteDescription.TabIndex = 100;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 3;
        this.tttabpage4.TabIndex = 3;
        this.tttabpage4.Text = i18n("M13441", "Ecz. Açıklaması");
        this.tttabpage4.Name = "tttabpage4";

        this.DiscriptionOfPharmacist = new TTVisual.TTTextBox();
        this.DiscriptionOfPharmacist.Multiline = true;
        this.DiscriptionOfPharmacist.BackColor = "#F0F0F0";
        this.DiscriptionOfPharmacist.ReadOnly = true;
        this.DiscriptionOfPharmacist.Name = "DiscriptionOfPharmacist";
        this.DiscriptionOfPharmacist.TabIndex = 98;

        this.DrugListview = new TTVisual.TTListView();
        this.DrugListview.MultiSelect = false;
        this.DrugListview.Name = "DrugListview";
        this.DrugListview.TabIndex = 1;

        this.SearchTextbox = new TTVisual.TTTextBox();
        this.SearchTextbox.CharacterCasing = CharacterCasing.Upper;
        this.SearchTextbox.Name = "SearchTextbox";
        this.SearchTextbox.TabIndex = 0;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M16287", "İlaç");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 2;

        this.OutPatientDrugOrdersColumns = [this.PhysicianDrug, this.cmdSelectBarcodeLevel, this.Frequency, this.DoseAmount, this.PeriodUnitType, this.Day, this.PackageAmount, this.DrugUsageType, this.DescriptionType, this.Description, this.TreatmentTime, this.RequiredAmount, this.Amount, this.UnitPrice, this.Price, this.ReceivedPrice, this.UsageNote, this.Drug, this.IlacEtkinMadde, this.SUTRules];
        this.SPTSDiagnosisesColumns = [this.CheckDiagnosisForPresc, this.CodeDiagnosisForPresc, this.NameDiagnosisForPresc];
        this.tttabcontrol1.Controls = [this.DrugTabPage];
        this.DrugTabPage.Controls = [this.OutPatientDrugOrders];
        this.tttabcontrol2.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3, this.tttabpage4];
        this.tttabpage1.Controls = [this.cmdAddDiagnosis, this.labelPrescriptionPaper, this.SPTSDiagnosises, this.PrescriptionPaper, this.cmdChangeSpeciality, this.labelSpecialityDefinition, this.SpecialityDefinition, this.ID, this.labelEReceteNo, this.ttlabel2, this.Emergency, this.EReceteNo, this.ActionDate, this.labelID, this.labelActionDate, this.PatientFullName, this.PrescriptionType, this.labelPrescriptionType];
        this.tttabpage2.Controls = [this.FavoriteDrugListview];
        this.tttabpage3.Controls = [this.EReceteDescription];
        this.tttabpage4.Controls = [this.DiscriptionOfPharmacist];
        this.Controls = [this.SendESignedPrescription, this.DigitalSignatureButton, this.cmdAddTemplate, this.cmdGetTemplate, this.cmdGetFavoriteDrugs, this.tttabcontrol1, this.DrugTabPage, this.OutPatientDrugOrders, this.PhysicianDrug, this.cmdSelectBarcodeLevel, this.Frequency, this.DoseAmount, this.PeriodUnitType, this.Day, this.PackageAmount, this.DrugUsageType, this.DescriptionType, this.Description, this.TreatmentTime, this.RequiredAmount, this.Amount, this.UnitPrice, this.Price, this.ReceivedPrice, this.UsageNote, this.Drug, this.IlacEtkinMadde, this.SUTRules, this.ttlabel3, this.tttabcontrol2, this.tttabpage1, this.cmdAddDiagnosis, this.labelPrescriptionPaper, this.SPTSDiagnosises, this.CheckDiagnosisForPresc, this.CodeDiagnosisForPresc, this.NameDiagnosisForPresc, this.PrescriptionPaper, this.cmdChangeSpeciality, this.labelSpecialityDefinition, this.SpecialityDefinition, this.ID, this.labelEReceteNo, this.ttlabel2, this.Emergency, this.EReceteNo, this.ActionDate, this.labelID, this.labelActionDate, this.PatientFullName, this.PrescriptionType, this.labelPrescriptionType, this.tttabpage2, this.FavoriteDrugListview, this.tttabpage3, this.EReceteDescription, this.tttabpage4, this.DiscriptionOfPharmacist, this.DrugListview, this.SearchTextbox, this.ttlabel1];

    }


}
