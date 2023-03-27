//$F51BF264
import { Component, OnInit, NgZone } from '@angular/core';
import { NuclearMedicineToDoctorFormViewModel, TestResultQueryInputDVO } from './NuclearMedicineToDoctorFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { RadyofarmasotikDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { CokluOzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedRadPharmMatGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTreatmentMat } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SagSol } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { NuclearMedicineTestInfo } from './NuclearMedicineReportedFormViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';

@Component({
    selector: 'NuclearMedicineToDoctorForm',
    templateUrl: './NuclearMedicineToDoctorForm.html',
    providers: [MessageService]
})
export class NuclearMedicineToDoctorForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    //cmdReport: TTVisual.ITTButton;
    Description: TTVisual.ITTTextBox;
    DirectPurchaseGrids: TTVisual.ITTGrid;
    AmountDirectPurchaseGrid: TTVisual.ITTTextBoxColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    DPADetailFirmPriceOffer: TTVisual.ITTListBoxColumn;
    DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridNuclearMedicineMaterial: TTVisual.ITTGrid;
    InjectionDate: TTVisual.ITTDateTimePicker;
    IsEmergency: TTVisual.ITTCheckBox;
    IsInjection: TTVisual.ITTCheckBoxColumn;
    kdv: TTVisual.ITTTextBoxColumn;
    kodsuzMalzemeFiyati: TTVisual.ITTTextBoxColumn;
    labelOzelDurum: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    malzemeBrans: TTVisual.ITTTextBoxColumn;
    malzemeOzelDurum: TTVisual.ITTListBoxColumn;
    malzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    malzemeTuru: TTVisual.ITTListBoxColumn;
    Material: TTVisual.ITTListBoxColumn;
    MaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    MaterialDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    Note: TTVisual.ITTTextBoxColumn;
    NuclearMedicine_RadyofarmasotikDirectPurchaseGrids: TTVisual.ITTGrid;
    NUCMEDDOCTORNOTE: TTVisual.ITTTextBox;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PATIENTPHONENUMBER: TTVisual.ITTTextBox;
    PATIENTWEIGHT: TTVisual.ITTTextBox;
    PatientBirthDate: TTVisual.ITTDateTimePicker;
    PatientBirthPlace: TTVisual.ITTTextBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureDate: TTVisual.ITTDateTimePicker;
    RADIOPHARMACYDESC: TTVisual.ITTTextBox;
    RadPharmMatTab: TTVisual.ITTTabPage;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    RESPONSIBLEACADEMICSTAFF: TTVisual.ITTObjectListBox;
    RESPONSIBLEDOCTOR: TTVisual.ITTObjectListBox;
    PROCEDUREDOCTOR: TTVisual.ITTObjectListBox;
    SurgeryDirectPurchaseGrids: TTVisual.ITTGrid;
    TabMedulaBilgileri: TTVisual.ITTTabPage;
    TABNuclearMedicine: TTVisual.ITTTabControl;
    TabPageMaterial: TTVisual.ITTTabPage;
    ttdatetimepickercolumn1: TTVisual.ITTDateTimePickerColumn;
    ttenumcomboboxCokluOzelDurum: TTVisual.ITTListBoxColumn;
    ttgrid2: TTVisual.ITTGrid;
    ttgridCokluOzelDurum: TTVisual.ITTGrid;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlabelBirim: TTVisual.ITTLabel;
    ttlabelDrAnesteziTescilNo: TTVisual.ITTLabel;
    ttlabelSagSol: TTVisual.ITTLabel;
    ttlistboxcolumn1: TTVisual.ITTListBoxColumn;
    TTListBoxDrAnesteziTescilNo: TTVisual.ITTObjectListBox;
    TTListBoxKesi: TTVisual.ITTObjectListBox;
    TTListBoxOzelDurum: TTVisual.ITTObjectListBox;
    TTListBoxSagSol: TTVisual.ITTObjectListBox;
    ttMasterResourceUserCheck: TTVisual.ITTCheckBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttabpage5: TTVisual.ITTTabPage;
    tttabpage6: TTVisual.ITTTabPage;
    tttabpage7: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextboxBirim: TTVisual.ITTTextBox;
    tttextboxcolumn1: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn2: TTVisual.ITTTextBoxColumn;
    txtBarcode: TTVisual.ITTTextBoxColumn;
    txtKesinlesenMiktar: TTVisual.ITTTextBoxColumn;
    Unit: TTVisual.ITTListBoxColumn;
    RTFREPORT: TTVisual.ITTRichTextBoxControl;
    RTFResultsAndComparisonInfo: TTVisual.ITTRichTextBoxControl;
    public DirectPurchaseGridsColumns = [];
    public TreatmentMaterialTypeName1: String;
    public TreatmentMaterialTypeName2: String;

    public ReadOnly1: boolean;
    public nuclearMedicineTestInfo: NuclearMedicineTestInfo;
    viewResultURL: string = "";

    public GridEpisodeDiagnosisColumns = [];
    public GridNuclearMedicineMaterialColumns = [];
    public NuclearMedicine_RadyofarmasotikDirectPurchaseGridsColumns = [];
    public SurgeryDirectPurchaseGridsColumns = [];
    public ttgrid2Columns = [];
    public ttgridCokluOzelDurumColumns = [];
    public nuclearMedicineToDoctorFormViewModel: NuclearMedicineToDoctorFormViewModel = new NuclearMedicineToDoctorFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineToDoctorForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineToDoctorForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService,protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineToDoctorForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdImage_Click(): Promise<void> {
        //TODO:Showedit!
        //            string accessionNoStr = this._RadiologyTest.AccessionNo.ToString();
        //            string patientIdStr = this._RadiologyTest.EpisodeAction.Episode.Patient.ID.ToString();
        //            TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
        let url: string = '/api/NuclearMedicineService/RetrieveNuclearMedicineTestInfo';
        let input = { 'NuclearMedicineObjectID': this._NuclearMedicine.ObjectID.toString() };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<NuclearMedicineTestInfo>(url, input);
        this.nuclearMedicineTestInfo = result;

        let accessionNoStr: string = this.nuclearMedicineTestInfo.AccessionNo; //this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.toString();
        let sysparam: string = (await SystemParameterService.GetParameterValue("PACSVIEWERURL", null));
        let URLLink: string = sysparam + "?an=" + accessionNoStr + "&usr=extreme"; //http://X.X.X.X:35005/?an=0000000&usr=extreme

        if (URLLink == null) {
            InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
        } else {
            let win = window.open(URLLink, '_blank');
            win.focus();
        }
    }

   public btnShowLISResultViewForAllEpisodes_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURLForAllEpisodes().then(() => {
            this.openInNewTab(this.viewResultURL);
        });
    }

    public async GetViewResultURLForAllEpisodes(): Promise<void> {

        let that = this;
        let inputDVO = new TestResultQueryInputDVO();


        inputDVO.PatientTCKN = this._NuclearMedicine.Episode.Patient.UniqueRefNo.toString();

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllEpisodeTestResults';
        let result = await this.httpService.post<string>(apiUrl, inputDVO);
        this.viewResultURL = result;
    }

    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Bu hizmetin sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }


    //private async cmdReport_Click(): Promise<void> {
    //    //this._NuclearMedicine.ShowViewer();

    //    let accessionNoStr: string = this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.toString();
    //    let patientIdStr: string = this._NuclearMedicine.Episode.Patient.ID.toString();
    //    //TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
    //}
    private async GridEpisodeDiagnosis_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //            if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
        //            {
        //
        //                NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
        //                nmcod.ShowEdit(this.FindForm(), this._NuclearMedicine);
        //            }

        // DialysisOrderDetail ->
        //TODO:ShowEdit
        //if ( (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn != null) && (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum") )
        //{
        //    NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
        //    NuclearMedicine inp = (NuclearMedicine)GridEpisodeDiagnosis.CurrentCell.OwningRow.TTObject;
        //    nmcod.ShowEdit(this.FindForm(), inp);
        //}

        //    public class _DialysisOrderForm : DialysisOrderForm
        //    {
        //        private void OrderDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        //        {
        //            // <-- Automatically generated part.
        //
        //            if ((((ITTGridCell)OrderDetails.CurrentCell).OwningColumn != null) && (((ITTGridCell)OrderDetails.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
        //            {
        //                DialysisOrderDetail_CokluOzelDurumForm codf = new DialysisOrderDetail_CokluOzelDurumForm();
        //                DialysisOrderDetail inp = (DialysisOrderDetail)OrderDetails.CurrentCell.OwningRow.TTObject;
        //                codf.ShowEdit(this.FindForm(), inp);
        //            }
        //
        //            // Automatically generated part. -->
        //        }
        //    }
        let a = 1;
    }
    private async GridNuclearMedicineMaterial_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {

    }
    private async ttMasterResourceUserCheck_CheckedChanged(): Promise<void> {
        if (this.ttMasterResourceUserCheck.Value === true) {
            this.RESPONSIBLEACADEMICSTAFF.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._NuclearMedicine.MasterResource.ObjectID.toString() + "'";
        }
        else {
            this.RESPONSIBLEACADEMICSTAFF.ListFilterExpression = null;
        }
    }
    protected async ClientSidePreScript(): Promise<void> {
        /*
        super.ClientSidePreScript();
        if (this.ttMasterResourceUserCheck.Value !== null && this.ttMasterResourceUserCheck.Value === true) {
            this.RESPONSIBLEACADEMICSTAFF.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._NuclearMedicine.MasterResource.ObjectID.toString()  + "'";
        }
        if (this._NuclearMedicine.CurrentStateDefID.Equals(NuclearMedicine.NuclearMedicineStates.Doctor)) {
            this.DropStateButton(NuclearMedicine.NuclearMedicineStates.Approve);
        }
        if (this._NuclearMedicine.NuclearMedicineTests.length > 0) {
            if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject !== null) {
                this.nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
            }
        }
        let directPurchaseDetailColumn: TTVisual.ITTGridColumn = <TTVisual.ITTGridColumn>this.SurgeryDirectPurchaseGrids.Columns['DPADetailFirmPriceOffer'];
        let filterString: string = '';
        if (this._NuclearMedicine.Episode.Patient !== null)
            filterString = "DIRECTPURCHASEACTIONDETAIL.DIRECTPURCHASEACTION.PATIENT = '" + this._NuclearMedicine.Episode.Patient.ObjectID.toString()  + "'";
        (<TTVisual.ITTListBoxColumn>directPurchaseDetailColumn).ListFilterExpression = filterString;
        let msItem: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        let dPADetailFirmPriceOffers: Array<DPADetailFirmPriceOffer> = <Array<DPADetailFirmPriceOffer>>(await DPADetailFirmPriceOfferService.GetUnsedAndApproved22FMaterialByPatient(this._NuclearMedicine.ObjectContext, this._NuclearMedicine.Episode.Patient.ObjectID));
        let radioPharmaceuticalMaterialList: Array<Guid> = new Array<Guid>();
        let radioPharmaceutical: boolean = false;
        if (this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.length === 0) {
            for (let nuclearMedicineTest of this._NuclearMedicine.NuclearMedicineTests) {
                if (nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials !== null && nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials.length > 0) {
                    for (let dPADetailFirmPriceOffer of dPADetailFirmPriceOffers) {
                        if (dPADetailFirmPriceOffer.DirectPurchaseActionDetail.DirectPurchaseAction.DirectPurchaseActionType === DirectPurchaseActionTypeEnum.RadioPharmaceutical) {
                            radioPharmaceuticalMaterialList.push(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.ObjectID);
                            radioPharmaceutical = true;
                        }
                    }
                    if (!radioPharmaceutical) {
                        if ((await SystemParameterService.GetParameterValue('ISRADYOFARMASOTIKMATERIALCONTROL', 'TRUE')) === 'TRUE')
                            throw new Exception('Bu Nükleer Tıp işlemi için doğrudan temin ile malzeme alınmalı ! ');
                    }
                }
                radioPharmaceutical = false;
            }
        }
        for (let dPADetailFirmPriceOffer of dPADetailFirmPriceOffers) {
            if (dPADetailFirmPriceOffer.DirectPurchaseActionDetail.DirectPurchaseAction.DirectPurchaseActionType === DirectPurchaseActionTypeEnum.RadioPharmaceutical) {
                for (let nuclearMedicineTest of this._NuclearMedicine.NuclearMedicineTests) {
                    if (nuclearMedicineTest.NuclearMedicineTestDef.ObjectID === dPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.ObjectID && this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.length === 0) {
                        for (let nM of nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials) {
                            if (radioPharmaceuticalMaterialList.Contains(nM.RadioPharmaCeuticalMaterial.ObjectID) === false) {
                                if ((await SystemParameterService.GetParameterValue('ISRADYOFARMASOTIKMATERIALCONTROL', 'TRUE')) === 'TRUE')
                                    throw new Exception('Bu Nükleer Tıp işlemi için doğrudan temin ile alınan malzemeler eksik, devam edemezsiniz ! ');
                            }
                        }
                    }
                }
                msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.SUTCode + ' ' + dPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.Name, dPADetailFirmPriceOffer.ObjectID.toString());
            }
            else {
                if (dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode !== null && String.isNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode) === false && String.isNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) === false)
                    msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode + ' ' + dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.toString());
                else if (String.isNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) === false)
                    msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.toString());
            }
        }
        let key: any = msItem.GetMSItem(null, 'Hastanın 22F Malzemesi Bulunmakta, Kullanmak İstediklerinizi Seçiniz', false, false, true);
        if (!String.isNullOrEmpty(key)) {
            for (let sp of msItem.MSSelectedItems.Keys) {
                //  createSubProcedure = true;

                let dpa: DPADetailFirmPriceOffer = <DPADetailFirmPriceOffer>this._NuclearMedicine.ObjectContext.GetObject(new Guid(sp), 'DPADetailFirmPriceOffer');
                if (dpa.OfferedUBB !== null) {
                    let sdp: SurgeryDirectPurchaseGrid = new SurgeryDirectPurchaseGrid(this._NuclearMedicine.ObjectContext);
                    sdp.DPADetailFirmPriceOffer = dpa;
                    this._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids.push(sdp);
                }
                else {
                    let rdp: RadyofarmasotikDirectPurchaseGrid = new RadyofarmasotikDirectPurchaseGrid(this._NuclearMedicine.ObjectContext);
                    rdp.DPADetailFirmPriceOffer = dpa;
                    this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.push(rdp);
                }
            }
        }
        */
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        //if (this._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids.length > 0) {
        //    let materials: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
        //    for (let sdg of this._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids) {
        //        if (materials.Contains(sdg.DPADetailFirmPriceOffer))
        //            throw new TTException('Aynı Malzemeyi Birden Fazla Giremezsiniz ! ');
        //        else materials.push(sdg.DPADetailFirmPriceOffer);
        //    }
        //}
        //let radioPharmaceuticalMaterialList: Array<Guid> = new Array<Guid>();
        //let radioPharmaceutical: boolean = false;
        //for (let radyofarmasotikDirectPurchaseGrid of this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids) {
        //    radioPharmaceuticalMaterialList.push(radyofarmasotikDirectPurchaseGrid.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.ObjectID);
        //}
        //for (let nuclearMedicineTest of this._NuclearMedicine.NuclearMedicineTests) {
        //    if (nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials !== null && nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials.length > 0) {
        //        for (let nuclearMedicineGridPharmDefinition of nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials) {
        //            if (nuclearMedicineGridPharmDefinition.RadioPharmaCeuticalMaterial !== null && !radioPharmaceuticalMaterialList.Contains(nuclearMedicineGridPharmDefinition.RadioPharmaCeuticalMaterial.ObjectID))
        //                radioPharmaceutical = true;
        //        }
        //    }
        //}
        //if (radioPharmaceutical) {
        //    if ((await SystemParameterService.GetParameterValue('ISRADYOFARMASOTIKMATERIALCONTROL', 'TRUE')) === 'TRUE')
        //        throw new Exception('Yapılacak Nükleer Tıp işlemi için doğrudan temin ile alınan malzemeler eksik seçildi ! ');
        //}
        //if (transDef !== null) {
        //    if (transDef.ToStateDefID === NuclearMedicine.NuclearMedicineStates.Reported) {
        //        for (let sdg of this._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids) {
        //            let titubbPrice: SubActionMatPricingDet = new SubActionMatPricingDet(this._NuclearMedicine.ObjectContext);
        //            titubbPrice.PatientPrice = 0;
        //            titubbPrice.SubActionMaterial = sdg;
        //            if (sdg.DPADetailFirmPriceOffer !== null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode !== null) {
        //                titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
        //                titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
        //                titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
        //            }
        //            //                else
        //            //                {
        //            //                    titubbPrice.ExternalCode = "KODSUZ";
        //            //                    titubbPrice.Description = productDefinition.Name;
        //            //                    titubbPrice.PayerPrice = 0;
        //            //                }
        //            titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
        //        }
        //        for (let rdg of this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids) {
        //            let titubbPrice: SubActionMatPricingDet = new SubActionMatPricingDet(this._NuclearMedicine.ObjectContext);
        //            titubbPrice.PatientPrice = 0;
        //            titubbPrice.SubActionMaterial = rdg;
        //            if (rdg.DPADetailFirmPriceOffer !== null && rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail !== null && rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode !== null && rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial !== null) {
        //                titubbPrice.ExternalCode = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.SUTCode;
        //                titubbPrice.Description = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.Name;
        //                titubbPrice.PayerPrice = 0;
        //            }
        //        }
        //    }
        //}
        //let malzemeObjectID: Guid = new Guid((await SystemParameterService.GetParameterValue('22F_MALZEMEOBJECTID', Guid.Empty.toString())));
        //for (let sdg of this._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids) {
        //    sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
        //    sdg.Material = <Material>this._NuclearMedicine.ObjectContext.GetObject(malzemeObjectID, 'MATERIAL');
        //    sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product !== null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
        //    sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
        //}
        //for (let rdg of this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids) {
        //    rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
        //    rdg.Material = <Material>this._NuclearMedicine.ObjectContext.GetObject(malzemeObjectID, 'MATERIAL');
        //    // rdg.UBBCode =  rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode != null ?  rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.ProductNumber : null;
        //    rdg.Amount = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
        //}
    }
    
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.AddHelpMenu();
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let radiologyHistory = new DynamicSidebarMenuItem();
        radiologyHistory.key = 'radiologyHistory';
        radiologyHistory.icon = 'glyphicon glyphicon-cd';
        radiologyHistory.label = 'Radyoloji Sonuçları';
        radiologyHistory.componentInstance = this.helpMenuService;
        radiologyHistory.clickFunction = this.helpMenuService.openRadiologyHistory;
        radiologyHistory.parameterFunctionInstance = this;
        radiologyHistory.getParamsFunction = this.getClickFunctionParams;
        radiologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', radiologyHistory);

        let pathologyHistory = new DynamicSidebarMenuItem();
        pathologyHistory.key = 'pathologyHistory';
        pathologyHistory.icon = 'fas fa-notes-medical';
        pathologyHistory.label = 'Patoloji Sonuçları';
        pathologyHistory.componentInstance = this.helpMenuService;
        pathologyHistory.clickFunction = this.helpMenuService.openPathologyHistory;
        pathologyHistory.parameterFunctionInstance = this;
        pathologyHistory.getParamsFunction = this.getClickFunctionParams;
        pathologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', pathologyHistory);

        let testHistory = new DynamicSidebarMenuItem();
        testHistory.key = 'testHistory';
        testHistory.icon = 'fa fa-flask';
        testHistory.label = 'Laboratuvar Sonuçları';
        testHistory.componentInstance = this.helpMenuService;
        testHistory.clickFunction = this.helpMenuService.openTestHistory;
        testHistory.parameterFunctionInstance = this;
        testHistory.getParamsFunction = this.getClickFunctionParams;
        testHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', testHistory);

        let nuclearMedicineHistory = new DynamicSidebarMenuItem();
        nuclearMedicineHistory.key = 'nuclearMedicineHistory';
        nuclearMedicineHistory.icon = 'fas fa-life-ring';
        nuclearMedicineHistory.label = 'Nükleer Tıp Sonuçları';
        nuclearMedicineHistory.componentInstance = this.helpMenuService;
        nuclearMedicineHistory.clickFunction = this.helpMenuService.openNuclearMedicineHistory;
        nuclearMedicineHistory.parameterFunctionInstance = this;
        nuclearMedicineHistory.getParamsFunction = this.getClickFunctionParams;
        nuclearMedicineHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', nuclearMedicineHistory);

    }

    public RemoveMenuFromHelpMenu(): void {

        this.sideBarMenuService.removeMenu('radiologyHistory');
        this.sideBarMenuService.removeMenu('pathologyHistory');
        this.sideBarMenuService.removeMenu('testHistory');
        this.sideBarMenuService.removeMenu('nuclearMedicineHistory');
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
        await this.load(NuclearMedicineToDoctorFormViewModel);
    }



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineToDoctorFormViewModel = new NuclearMedicineToDoctorFormViewModel();
        this._ViewModel = this.nuclearMedicineToDoctorFormViewModel;
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.ResponsibleDoctor = new ResUser();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.Episode.Patient = new Patient();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.ProcedureDoctor = new ResUser();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.NucMedTreatmentMats = new Array<NucMedTreatmentMat>();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.RadPharmMaterials = new Array<NucMedRadPharmMatGrid>();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.AnesteziDoktor = new ResUser();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.OzelDurum = new OzelDurum();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.CokluOzelDurum = new Array<CokluOzelDurum>();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.SagSol = new SagSol();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.AyniFarkliKesi = new AyniFarkliKesi();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids = new Array<SurgeryDirectPurchaseGrid>();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = new Array<RadyofarmasotikDirectPurchaseGrid>();
        this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.DirectPurchaseGrids = new Array<DirectPurchaseGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineToDoctorFormViewModel = this._ViewModel as NuclearMedicineToDoctorFormViewModel;
        that._TTObject = this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineToDoctorFormViewModel == null)
            this.nuclearMedicineToDoctorFormViewModel = new NuclearMedicineToDoctorFormViewModel();
        if (this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineToDoctorFormViewModel._NuclearMedicine = new NuclearMedicine();

        let masterResourceID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["MasterResource"];
        that.PROCEDUREDOCTOR.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResourceID.toString() + '\'';
        that.RESPONSIBLEDOCTOR.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResourceID.toString() + '\'';


        let responsibleDoctorObjectID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["ResponsibleDoctor"];
        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === "string")) {
            let responsibleDoctor = that.nuclearMedicineToDoctorFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
            if (responsibleDoctor) {
                that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.ResponsibleDoctor = responsibleDoctor;
            }
        }
        let episodeObjectID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineToDoctorFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineToDoctorFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineToDoctorFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineToDoctorFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineToDoctorFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === "string")) {
                    let patient = that.nuclearMedicineToDoctorFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }


  


        let requestDoctorObjectID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineToDoctorFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }
        let procedureDoctorObjectID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.nuclearMedicineToDoctorFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.ProcedureDoctor = procedureDoctor;
            }
        }
        that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.NucMedTreatmentMats = that.nuclearMedicineToDoctorFormViewModel.GridNuclearMedicineMaterialGridList;
        for (let detailItem of that.nuclearMedicineToDoctorFormViewModel.GridNuclearMedicineMaterialGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineToDoctorFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let malzemeTuruObjectID = detailItem["MalzemeTuru"];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === "string")) {
                let malzemeTuru = that.nuclearMedicineToDoctorFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.nuclearMedicineToDoctorFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.RadPharmMaterials = that.nuclearMedicineToDoctorFormViewModel.ttgrid2GridList;
        for (let detailItem of that.nuclearMedicineToDoctorFormViewModel.ttgrid2GridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineToDoctorFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.nuclearMedicineToDoctorFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.nuclearMedicineToDoctorFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.nuclearMedicineToDoctorFormViewModel.RadioPharmaceuticalUnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    detailItem.Unit = unit;
                }
            }
        }
        let anesteziDoktorObjectID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["AnesteziDoktor"];
        if (anesteziDoktorObjectID != null && (typeof anesteziDoktorObjectID === "string")) {
            let anesteziDoktor = that.nuclearMedicineToDoctorFormViewModel.ResUsers.find(o => o.ObjectID.toString() === anesteziDoktorObjectID.toString());
            if (anesteziDoktor) {
                that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.AnesteziDoktor = anesteziDoktor;
            }
        }
        let ozelDurumObjectID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["OzelDurum"];
        if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
            let ozelDurum = that.nuclearMedicineToDoctorFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
            if (ozelDurum) {
                that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.OzelDurum = ozelDurum;
            }
        }
        that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.CokluOzelDurum = that.nuclearMedicineToDoctorFormViewModel.ttgridCokluOzelDurumGridList;
        for (let detailItem of that.nuclearMedicineToDoctorFormViewModel.ttgridCokluOzelDurumGridList) {
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.nuclearMedicineToDoctorFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        let sagSolObjectID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["SagSol"];
        if (sagSolObjectID != null && (typeof sagSolObjectID === "string")) {
            let sagSol = that.nuclearMedicineToDoctorFormViewModel.SagSols.find(o => o.ObjectID.toString() === sagSolObjectID.toString());
            if (sagSol) {
                that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.SagSol = sagSol;
            }
        }
        let ayniFarkliKesiObjectID = that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine["AyniFarkliKesi"];
        if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === "string")) {
            let ayniFarkliKesi = that.nuclearMedicineToDoctorFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
            if (ayniFarkliKesi) {
                that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.AyniFarkliKesi = ayniFarkliKesi;
            }
        }
        that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids = that.nuclearMedicineToDoctorFormViewModel.SurgeryDirectPurchaseGridsGridList;
        for (let detailItem of that.nuclearMedicineToDoctorFormViewModel.SurgeryDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === "string")) {
                let dPADetailFirmPriceOffer = that.nuclearMedicineToDoctorFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
                if (dPADetailFirmPriceOffer != null) {
                    let offeredUBBObjectID = dPADetailFirmPriceOffer["OfferedUBB"];
                    if (offeredUBBObjectID != null && (typeof offeredUBBObjectID === "string")) {
                        let offeredUBB = that.nuclearMedicineToDoctorFormViewModel.ProductDefinitions.find(o => o.ObjectID.toString() === offeredUBBObjectID.toString());
                        if (offeredUBB) {
                            dPADetailFirmPriceOffer.OfferedUBB = offeredUBB;
                        }
                    }
                }
                if (dPADetailFirmPriceOffer != null) {
                    let directPurchaseActionDetailObjectID = dPADetailFirmPriceOffer["DirectPurchaseActionDetail"];
                    if (directPurchaseActionDetailObjectID != null && (typeof directPurchaseActionDetailObjectID === "string")) {
                        let directPurchaseActionDetail = that.nuclearMedicineToDoctorFormViewModel.DirectPurchaseActionDetails.find(o => o.ObjectID.toString() === directPurchaseActionDetailObjectID.toString());
                        if (directPurchaseActionDetail) {
                            dPADetailFirmPriceOffer.DirectPurchaseActionDetail = directPurchaseActionDetail;
                        }
                    }
                }
            }
        }
        that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = that.nuclearMedicineToDoctorFormViewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList;
        for (let detailItem of that.nuclearMedicineToDoctorFormViewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === "string")) {
                let dPADetailFirmPriceOffer = that.nuclearMedicineToDoctorFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
            }
        }
        that.nuclearMedicineToDoctorFormViewModel._NuclearMedicine.DirectPurchaseGrids = that.nuclearMedicineToDoctorFormViewModel.DirectPurchaseGridsGridList;
        for (let detailItem of that.nuclearMedicineToDoctorFormViewModel.DirectPurchaseGridsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineToDoctorFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }



    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineToDoctorFormViewModel);
  

        that.TreatmentMaterialTypeName1 = 'NUCMEDTREATMENTMAT';
        that.TreatmentMaterialTypeName2 = 'NUCMEDRADPHARMMATGRID';

        that.ReadOnly1 = true;
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ActionDate != event) {
                this._NuclearMedicine.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.MedulaAciklama != event) {
                this._NuclearMedicine.MedulaAciklama = event;
            }
        }
    }

    public onInjectionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.InjectionDate != event) {
                this._NuclearMedicine.InjectionDate = event;
            }
        }
    }

    public onIsEmergencyChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.IsEmergency != event) {
                this._NuclearMedicine.IsEmergency = event;
            }
        }
    }

    public onNUCMEDDOCTORNOTEChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.NucMedDoctorNote != event) {
                this._NuclearMedicine.NucMedDoctorNote = event;
            }
        }
    }

    public onPATIENTPHONENUMBERChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientPhoneNumber != event) {
                this._NuclearMedicine.PatientPhoneNumber = event;
            }
        }
    }

    public onPATIENTWEIGHTChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientWeight != event) {
                this._NuclearMedicine.PatientWeight = event;
            }
        }
    }

    public onPatientBirthDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null &&
                this._NuclearMedicine.Episode != null &&
                this._NuclearMedicine.Episode.Patient != null && this._NuclearMedicine.Episode.Patient.BirthDate != event) {
                this._NuclearMedicine.Episode.Patient.BirthDate = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PreDiagnosis != event) {
                this._NuclearMedicine.PreDiagnosis = event;
            }
        }
    }

    public onProcedureDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProcedureDate != event) {
                this._NuclearMedicine.ProcedureDate = event;
            }
        }
    }

    public onRADIOPHARMACYDESCChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RadioPharmacyDescription != event) {
                this._NuclearMedicine.RadioPharmacyDescription = event;
            }
        }
    }

    public onREQUESTDOCTORChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RequestDoctor != event) {
                this._NuclearMedicine.RequestDoctor = event;
            }
        }
    }

    public onREQUESTDOCTORPHONEChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null &&
                this._NuclearMedicine.RequestDoctor != null && this._NuclearMedicine.RequestDoctor.PhoneNumber != event) {
                this._NuclearMedicine.RequestDoctor.PhoneNumber = event;
            }
        }
    }

    public onRESPONSIBLEACADEMICSTAFFChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ResponsibleAcademicStaff != event) {
                this._NuclearMedicine.ResponsibleAcademicStaff = event;
            }
        }
    }

    public onRESPONSIBLEDOCTORChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ResponsibleDoctor != event) {
                this._NuclearMedicine.ResponsibleDoctor = event;
            }
        }
    }

    public onPROCEDUREDOCTORChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProcedureDoctor != event) {
                this._NuclearMedicine.ProcedureDoctor = event;
            }
        }
    }

    public onRTFREPORTChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.Report != event) {
                this._NuclearMedicine.Report = event;
            }
        }
    }

    public onRTFResultsAndComparisonInfoChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ResultsAndComparisonInfo != event) {
                this._NuclearMedicine.ResultsAndComparisonInfo = event;
            }
        }
    }

    public onTTListBoxDrAnesteziTescilNoChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.AnesteziDoktor != event) {
                this._NuclearMedicine.AnesteziDoktor = event;
            }
        }
    }

    public onTTListBoxKesiChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.AyniFarkliKesi != event) {
                this._NuclearMedicine.AyniFarkliKesi = event;
            }
        }
    }

    public onTTListBoxOzelDurumChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.OzelDurum != event) {
                this._NuclearMedicine.OzelDurum = event;
            }
        }
    }

    public onTTListBoxSagSolChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.SagSol != event) {
                this._NuclearMedicine.SagSol = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProtocolNo != event) {
                this._NuclearMedicine.ProtocolNo = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.TestSequenceNo != event) {
                this._NuclearMedicine.TestSequenceNo = event;
            }
        }
    }

    public ontttextboxBirimChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.birim != event) {
                this._NuclearMedicine.birim = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.InjectionDate, "Value", this.__ttObject, "InjectionDate");
        redirectProperty(this.ProcedureDate, "Value", this.__ttObject, "ProcedureDate");
        redirectProperty(this.PatientBirthDate, "Value", this.__ttObject, "Episode.Patient.BirthDate");
        redirectProperty(this.PATIENTWEIGHT, "Text", this.__ttObject, "PatientWeight");
        redirectProperty(this.PATIENTPHONENUMBER, "Text", this.__ttObject, "PatientPhoneNumber");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TestSequenceNo");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
        redirectProperty(this.RTFREPORT, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.RTFResultsAndComparisonInfo, "Rtf", this.__ttObject, "ResultsAndComparisonInfo");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.RADIOPHARMACYDESC, "Text", this.__ttObject, "RadioPharmacyDescription");
        redirectProperty(this.NUCMEDDOCTORNOTE, "Text", this.__ttObject, "NucMedDoctorNote");
        redirectProperty(this.Description, "Text", this.__ttObject, "MedulaAciklama");
        redirectProperty(this.tttextboxBirim, "Text", this.__ttObject, "birim");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#DCDCDC";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.ttMasterResourceUserCheck = new TTVisual.TTCheckBox();
        this.ttMasterResourceUserCheck.Value = true;
        this.ttMasterResourceUserCheck.Text = "Sadece Bölüme Bağlı Kullanıcıları Listele";
        this.ttMasterResourceUserCheck.Name = "ttMasterResourceUserCheck";
        this.ttMasterResourceUserCheck.TabIndex = 83;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Sorumlu Öğretim Üyesi";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 82;

        this.RESPONSIBLEACADEMICSTAFF = new TTVisual.TTObjectListBox();
        this.RESPONSIBLEACADEMICSTAFF.ListDefName = "DoctorListDefinition";
        this.RESPONSIBLEACADEMICSTAFF.Name = "RESPONSIBLEACADEMICSTAFF";
        this.RESPONSIBLEACADEMICSTAFF.TabIndex = 17;

        //this.cmdReport = new TTVisual.TTButton();
        //this.cmdReport.Text = "İmaj Görüntüle";
        //this.cmdReport.Name = "cmdReport";
        //this.cmdReport.TabIndex = 18;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Test Sıra No";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 15;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tetkik";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 13;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 15;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 0;
        this.tttabpage3.BackColor = "#FFFFFF";
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = "Rapor";
        this.tttabpage3.Name = "tttabpage3";

        this.RTFREPORT = new TTVisual.TTRichTextBoxControl();
        this.RTFREPORT.DisplayText = "Rapor";
        this.RTFREPORT.TemplateGroupName = "Nükleer Tıp Şablonları";
        this.RTFREPORT.BackColor = "#DCDCDC";
        this.RTFREPORT.Name = "RTFREPORT";
        this.RTFREPORT.TabIndex = 73;

        this.RTFResultsAndComparisonInfo = new TTVisual.TTRichTextBoxControl();
        this.RTFResultsAndComparisonInfo.DisplayText = "Bulgular ve Karşılaştırma Bilgisi";
        this.RTFResultsAndComparisonInfo.TemplateGroupName = "Nükleer Tıp Şablonları";
        this.RTFResultsAndComparisonInfo.BackColor = "#DCDCDC";
        this.RTFResultsAndComparisonInfo.Name = "RTFResultsAndComparisonInfo";
        this.RTFResultsAndComparisonInfo.TabIndex = 73;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 1;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.tttabpage1.Name = "tttabpage1";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 50;
        this.PREDIAGNOSIS.Height = "150px";

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 2;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = "N.T. Tabip Notu";
        this.tttabpage2.Name = "tttabpage2";

        this.RADIOPHARMACYDESC = new TTVisual.TTTextBox();
        this.RADIOPHARMACYDESC.Multiline = true;
        this.RADIOPHARMACYDESC.BackColor = "#F0F0F0";
        this.RADIOPHARMACYDESC.ReadOnly = true;
        this.RADIOPHARMACYDESC.Name = "RADIOPHARMACYDESC";
        this.RADIOPHARMACYDESC.TabIndex = 19;
        this.RADIOPHARMACYDESC.Height = "150px";

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 3;
        this.tttabpage4.BackColor = "#FFFFFF";
        this.tttabpage4.TabIndex = 3;
        this.tttabpage4.Text = "Teknisyen Notu";
        this.tttabpage4.Name = "tttabpage4";

        this.NUCMEDDOCTORNOTE = new TTVisual.TTTextBox();
        this.NUCMEDDOCTORNOTE.Multiline = true;
        this.NUCMEDDOCTORNOTE.Name = "NUCMEDDOCTORNOTE";
        this.NUCMEDDOCTORNOTE.TabIndex = 0;
        this.NUCMEDDOCTORNOTE.ReadOnly = true;
        this.NUCMEDDOCTORNOTE.Height = "150px";

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 10;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 14;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmişe Ekle";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.ReadOnly = true;
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisDefinitionList";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.ReadOnly = true;
        this.EpisodeDiagnose.Width = 250;

        this.EpisodeDiagnoseType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnoseType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnoseType.DataMember = "DiagnosisType";
        this.EpisodeDiagnoseType.DisplayIndex = 2;
        this.EpisodeDiagnoseType.HeaderText = "Tanı Tipi";
        this.EpisodeDiagnoseType.Name = "EpisodeDiagnoseType";
        this.EpisodeDiagnoseType.ReadOnly = true;
        this.EpisodeDiagnoseType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = "Ana Tanı";
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.ReadOnly = true;
        this.EpisodeIsMainDiagnose.Width = 75;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = "Tanı Koyan";
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.ReadOnly = true;
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = "Tanı Giriş Tarihi";
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.ReadOnly = true;
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = "Giriş Yapılan İşlem";
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.ReadOnly = true;
        this.EntryActionType.Width = 100;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 3;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Protokol No";
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 8;

        this.PatientBirthDate = new TTVisual.TTDateTimePicker();
        this.PatientBirthDate.BackColor = "#F0F0F0";
        this.PatientBirthDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.PatientBirthDate.Format = DateTimePickerFormat.Custom;
        this.PatientBirthDate.Enabled = false;
        this.PatientBirthDate.Name = "PatientBirthDate";
        this.PatientBirthDate.TabIndex = 7;

        this.PatientBirthPlace = new TTVisual.TTTextBox();
        this.PatientBirthPlace.BackColor = "#F0F0F0";
        this.PatientBirthPlace.ReadOnly = true;
        this.PatientBirthPlace.Name = "PatientBirthPlace";
        this.PatientBirthPlace.TabIndex = 4;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Enabled = false;
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 14;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = "Hastanın Doğum Tarihi";
        this.ttlabel14.BackColor = "#DCDCDC";
        this.ttlabel14.ForeColor = "#000000";
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 76;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = "Hastanın Doğum Yeri";
        this.ttlabel13.BackColor = "#DCDCDC";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 75;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 11;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "İstek Yapan Tabip";
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 10;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "İşlem Zamanı";
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 12;

        this.ProcedureDate = new TTVisual.TTDateTimePicker();
        this.ProcedureDate.BackColor = "#F0F0F0";
        this.ProcedureDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ProcedureDate.Format = DateTimePickerFormat.Custom;
        this.ProcedureDate.Enabled = false;
        this.ProcedureDate.Name = "ProcedureDate";
        this.ProcedureDate.TabIndex = 6;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "İstek Yapan Tabip Telefon";
        this.ttlabel10.BackColor = "#DCDCDC";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 12;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = "Hastanın Telefonu";
        this.ttlabel12.BackColor = "#DCDCDC";
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 8;

        this.PATIENTPHONENUMBER = new TTVisual.TTTextBox();
        this.PATIENTPHONENUMBER.BackColor = "#F0F0F0";
        this.PATIENTPHONENUMBER.ReadOnly = true;
        this.PATIENTPHONENUMBER.Name = "PATIENTPHONENUMBER";
        this.PATIENTPHONENUMBER.TabIndex = 9;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Hastanın Kilosu";
        this.ttlabel11.BackColor = "#DCDCDC";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 61;

        this.PATIENTWEIGHT = new TTVisual.TTTextBox();
        this.PATIENTWEIGHT.BackColor = "#F0F0F0";
        this.PATIENTWEIGHT.ReadOnly = true;
        this.PATIENTWEIGHT.Name = "PATIENTWEIGHT";
        this.PATIENTWEIGHT.TabIndex = 8;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İşlemi Yapan Doktor";
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 66;

        this.RESPONSIBLEDOCTOR = new TTVisual.TTObjectListBox();
        this.RESPONSIBLEDOCTOR.Required = true;
        this.RESPONSIBLEDOCTOR.ListDefName = "SpecialistDoctorListDefinition";
        this.RESPONSIBLEDOCTOR.Name = "RESPONSIBLEDOCTOR";
        this.RESPONSIBLEDOCTOR.TabIndex = 16;


        this.PROCEDUREDOCTOR = new TTVisual.TTObjectListBox();
        this.PROCEDUREDOCTOR.Required = true;
        this.PROCEDUREDOCTOR.ListDefName = "SpecialistDoctorListDefinition";
        this.PROCEDUREDOCTOR.Name = "PROCEDUREDOCTOR";
        this.PROCEDUREDOCTOR.TabIndex = 16;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Enjeksiyon Zamanı";
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 63;

        this.InjectionDate = new TTVisual.TTDateTimePicker();
        this.InjectionDate.BackColor = "#F0F0F0";
        this.InjectionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.InjectionDate.Format = DateTimePickerFormat.Custom;
        this.InjectionDate.Enabled = false;
        this.InjectionDate.Name = "InjectionDate";
        this.InjectionDate.TabIndex = 5;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Kabul Sebebi";
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 60;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Hasta Grubu";
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 59;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "Çekim Tarihi ve Saati";
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 48;

        this.TABNuclearMedicine = new TTVisual.TTTabControl();
        this.TABNuclearMedicine.Name = "TABNuclearMedicine";
        this.TABNuclearMedicine.TabIndex = 1;

        this.TabPageMaterial = new TTVisual.TTTabPage();
        this.TabPageMaterial.DisplayIndex = 0;
        this.TabPageMaterial.BackColor = "#FFFFFF";
        this.TabPageMaterial.TabIndex = 1;
        this.TabPageMaterial.Text = "Nükleer Tıp Sarf";
        this.TabPageMaterial.Name = "TabPageMaterial";

        this.GridNuclearMedicineMaterial = new TTVisual.TTGrid();
        this.GridNuclearMedicineMaterial.ReadOnly = true;
        this.GridNuclearMedicineMaterial.Name = "GridNuclearMedicineMaterial";
        this.GridNuclearMedicineMaterial.TabIndex = 1;

        this.MaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.MaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.MaterialActionDate.DataMember = "ActionDate";
        this.MaterialActionDate.Required = true;
        this.MaterialActionDate.DisplayIndex = 0;
        this.MaterialActionDate.HeaderText = "Tarih/Saat";
        this.MaterialActionDate.Name = "MaterialActionDate";
        this.MaterialActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = "Sarf Edilen Malzemeler";
        this.Material.Name = "Material";
        this.Material.Width = 320;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = "Note";
        this.Note.DisplayIndex = 2;
        this.Note.HeaderText = "Notlar";
        this.Note.Name = "Note";
        this.Note.Width = 220;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = "Miktar";
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.malzemeSatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.malzemeSatinAlisTarihi.CustomFormat = "dd/MM/yyyy";
        this.malzemeSatinAlisTarihi.DataMember = "MalzemeSatinAlisTarihi";
        this.malzemeSatinAlisTarihi.DisplayIndex = 4;
        this.malzemeSatinAlisTarihi.HeaderText = "Satın Alış Tarihi";
        this.malzemeSatinAlisTarihi.Name = "malzemeSatinAlisTarihi";
        this.malzemeSatinAlisTarihi.Visible = false;
        this.malzemeSatinAlisTarihi.Width = 100;

        this.kodsuzMalzemeFiyati = new TTVisual.TTTextBoxColumn();
        this.kodsuzMalzemeFiyati.DataMember = "KodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyati.DisplayIndex = 5;
        this.kodsuzMalzemeFiyati.HeaderText = "Kodsuz Malzeme Fiyatı";
        this.kodsuzMalzemeFiyati.Name = "kodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyati.Visible = false;
        this.kodsuzMalzemeFiyati.Width = 150;

        this.kdv = new TTVisual.TTTextBoxColumn();
        this.kdv.DataMember = "Kdv";
        this.kdv.DisplayIndex = 6;
        this.kdv.HeaderText = "KDV";
        this.kdv.Name = "kdv";
        this.kdv.Visible = false;
        this.kdv.Width = 100;

        this.malzemeTuru = new TTVisual.TTListBoxColumn();
        this.malzemeTuru.ListDefName = "MalzemeTuruListDefinition";
        this.malzemeTuru.DataMember = "MalzemeTuru";
        this.malzemeTuru.DisplayIndex = 7;
        this.malzemeTuru.HeaderText = "Malzemenin Türü";
        this.malzemeTuru.Name = "malzemeTuru";
        this.malzemeTuru.Visible = false;
        this.malzemeTuru.Width = 100;

        this.malzemeBrans = new TTVisual.TTTextBoxColumn();
        this.malzemeBrans.DataMember = "MalzemeBrans";
        this.malzemeBrans.DisplayIndex = 8;
        this.malzemeBrans.HeaderText = "Malzeme Branşı";
        this.malzemeBrans.Name = "malzemeBrans";
        this.malzemeBrans.Visible = false;
        this.malzemeBrans.Width = 100;

        this.malzemeOzelDurum = new TTVisual.TTListBoxColumn();
        this.malzemeOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.malzemeOzelDurum.DataMember = "OzelDurum";
        this.malzemeOzelDurum.DisplayIndex = 9;
        this.malzemeOzelDurum.HeaderText = "Özel Durum";
        this.malzemeOzelDurum.Name = "malzemeOzelDurum";
        this.malzemeOzelDurum.Visible = false;
        this.malzemeOzelDurum.Width = 100;

        this.RadPharmMatTab = new TTVisual.TTTabPage();
        this.RadPharmMatTab.DisplayIndex = 1;
        this.RadPharmMatTab.TabIndex = 2;
        this.RadPharmMatTab.Text = "Radyofarmasötik Madde Sarf";
        this.RadPharmMatTab.Name = "RadPharmMatTab";

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.Name = "ttgrid2";
        this.ttgrid2.TabIndex = 1;

        this.ttdatetimepickercolumn1 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn1.DataMember = "ActionDate";
        this.ttdatetimepickercolumn1.DisplayIndex = 0;
        this.ttdatetimepickercolumn1.HeaderText = "Tarih/Saat";
        this.ttdatetimepickercolumn1.Name = "ttdatetimepickercolumn1";
        this.ttdatetimepickercolumn1.ReadOnly = true;
        this.ttdatetimepickercolumn1.Width = 140;

        this.ttlistboxcolumn1 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn1.ListDefName = "NucMedPharmMatListDef";
        this.ttlistboxcolumn1.DataMember = "Material";
        this.ttlistboxcolumn1.DisplayIndex = 1;
        this.ttlistboxcolumn1.HeaderText = "Sarf Edilen Malzemeler";
        this.ttlistboxcolumn1.Name = "ttlistboxcolumn1";
        this.ttlistboxcolumn1.ReadOnly = true;
        this.ttlistboxcolumn1.Width = 320;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = "Ölçü Birimi";
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.IsInjection = new TTVisual.TTCheckBoxColumn();
        this.IsInjection.DataMember = "IsInjection";
        this.IsInjection.DisplayIndex = 3;
        this.IsInjection.HeaderText = "Enjeksiyon";
        this.IsInjection.Name = "IsInjection";
        this.IsInjection.ReadOnly = true;
        this.IsInjection.Width = 60;

        this.tttextboxcolumn1 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn1.DataMember = "Note";
        this.tttextboxcolumn1.DisplayIndex = 4;
        this.tttextboxcolumn1.HeaderText = "Erişkin Dozu";
        this.tttextboxcolumn1.Name = "tttextboxcolumn1";
        this.tttextboxcolumn1.ReadOnly = true;
        this.tttextboxcolumn1.Width = 100;

        this.tttextboxcolumn2 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn2.DataMember = "Amount";
        this.tttextboxcolumn2.DisplayIndex = 5;
        this.tttextboxcolumn2.HeaderText = "Verilen Doz";
        this.tttextboxcolumn2.Name = "tttextboxcolumn2";
        this.tttextboxcolumn2.ReadOnly = true;
        this.tttextboxcolumn2.Width = 100;

        this.Unit = new TTVisual.TTListBoxColumn();
        this.Unit.ListDefName = "RadioPharmaceuticalUnitListDefinition";
        this.Unit.DataMember = "Unit";
        this.Unit.DisplayIndex = 6;
        this.Unit.HeaderText = "Birim";
        this.Unit.Name = "Unit";
        this.Unit.ReadOnly = true;
        this.Unit.Width = 80;

        this.TabMedulaBilgileri = new TTVisual.TTTabPage();
        this.TabMedulaBilgileri.DisplayIndex = 2;
        this.TabMedulaBilgileri.TabIndex = 3;
        this.TabMedulaBilgileri.Text = "Medula Bilgileri";
        this.TabMedulaBilgileri.Name = "TabMedulaBilgileri";

        this.ttlabelDrAnesteziTescilNo = new TTVisual.TTLabel();
        this.ttlabelDrAnesteziTescilNo.Text = "Anestezi Dr. Tescil No.";
        this.ttlabelDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelDrAnesteziTescilNo.Name = "ttlabelDrAnesteziTescilNo";
        this.ttlabelDrAnesteziTescilNo.TabIndex = 81;

        this.TTListBoxDrAnesteziTescilNo = new TTVisual.TTObjectListBox();
        this.TTListBoxDrAnesteziTescilNo.ListDefName = "ResUserListDefinition";
        this.TTListBoxDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxDrAnesteziTescilNo.Name = "TTListBoxDrAnesteziTescilNo";
        this.TTListBoxDrAnesteziTescilNo.TabIndex = 85;

        this.TTListBoxOzelDurum = new TTVisual.TTObjectListBox();
        this.TTListBoxOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.TTListBoxOzelDurum.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxOzelDurum.ForeColor = "#000000";
        this.TTListBoxOzelDurum.Name = "TTListBoxOzelDurum";
        this.TTListBoxOzelDurum.TabIndex = 11;

        this.ttgridCokluOzelDurum = new TTVisual.TTGrid();
        this.ttgridCokluOzelDurum.OnRowMarkerDoubleClickShowTTObjectForm = false;
        this.ttgridCokluOzelDurum.Name = "ttgridCokluOzelDurum";
        this.ttgridCokluOzelDurum.TabIndex = 6;

        this.ttenumcomboboxCokluOzelDurum = new TTVisual.TTListBoxColumn();
        this.ttenumcomboboxCokluOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.ttenumcomboboxCokluOzelDurum.DataMember = "OzelDurum";
        this.ttenumcomboboxCokluOzelDurum.DisplayIndex = 0;
        this.ttenumcomboboxCokluOzelDurum.HeaderText = "Çoklu Özel Durum";
        this.ttenumcomboboxCokluOzelDurum.Name = "ttenumcomboboxCokluOzelDurum";
        this.ttenumcomboboxCokluOzelDurum.Width = 200;

        this.labelOzelDurum = new TTVisual.TTLabel();
        this.labelOzelDurum.Text = "Özel Durum";
        this.labelOzelDurum.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelOzelDurum.Name = "labelOzelDurum";
        this.labelOzelDurum.TabIndex = 0;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = "Aynı Kesi/ Farklı Seans";
        this.ttlabel18.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 75;

        this.ttlabelSagSol = new TTVisual.TTLabel();
        this.ttlabelSagSol.Text = "Sağ / Sol";
        this.ttlabelSagSol.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelSagSol.Name = "ttlabelSagSol";
        this.ttlabelSagSol.TabIndex = 77;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = "Açıklama";
        this.ttlabel16.ForeColor = "#000000";
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 65;

        this.TTListBoxSagSol = new TTVisual.TTObjectListBox();
        this.TTListBoxSagSol.ListDefName = "SagSolListDefinition";
        this.TTListBoxSagSol.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxSagSol.Name = "TTListBoxSagSol";
        this.TTListBoxSagSol.TabIndex = 84;

        this.tttextboxBirim = new TTVisual.TTTextBox();
        this.tttextboxBirim.Name = "tttextboxBirim";
        this.tttextboxBirim.TabIndex = 82;

        this.TTListBoxKesi = new TTVisual.TTObjectListBox();
        this.TTListBoxKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.TTListBoxKesi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxKesi.Name = "TTListBoxKesi";
        this.TTListBoxKesi.TabIndex = 83;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 4;

        this.ttlabelBirim = new TTVisual.TTLabel();
        this.ttlabelBirim.Text = "Birim";
        this.ttlabelBirim.Name = "ttlabelBirim";
        this.ttlabelBirim.TabIndex = 81;

        this.tttabpage5 = new TTVisual.TTTabPage();
        this.tttabpage5.DisplayIndex = 3;
        this.tttabpage5.TabIndex = 4;
        this.tttabpage5.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.tttabpage5.Visible = false;
        this.tttabpage5.Name = "tttabpage5";

        this.SurgeryDirectPurchaseGrids = new TTVisual.TTGrid();
        this.SurgeryDirectPurchaseGrids.Name = "SurgeryDirectPurchaseGrids";
        this.SurgeryDirectPurchaseGrids.TabIndex = 0;

        this.DPADetailFirmPriceOffer = new TTVisual.TTListBoxColumn();
        this.DPADetailFirmPriceOffer.ListDefName = "DirectPurchaseActionDetailList";
        this.DPADetailFirmPriceOffer.DataMember = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.DisplayIndex = 0;
        this.DPADetailFirmPriceOffer.HeaderText = "22F Malzeme";
        this.DPADetailFirmPriceOffer.Name = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.Width = 300;

        this.txtBarcode = new TTVisual.TTTextBoxColumn();
        this.txtBarcode.DataMember = "ProductNumber";
        this.txtBarcode.DisplayIndex = 1;
        this.txtBarcode.HeaderText = "Barcod";
        this.txtBarcode.Name = "txtBarcode";
        this.txtBarcode.ReadOnly = true;
        this.txtBarcode.Width = 100;

        this.txtKesinlesenMiktar = new TTVisual.TTTextBoxColumn();
        this.txtKesinlesenMiktar.DataMember = "CertainAmount";
        this.txtKesinlesenMiktar.DisplayIndex = 2;
        this.txtKesinlesenMiktar.HeaderText = "Kesinleşen Miktar";
        this.txtKesinlesenMiktar.Name = "txtKesinlesenMiktar";
        this.txtKesinlesenMiktar.ReadOnly = true;
        this.txtKesinlesenMiktar.Width = 100;

        this.tttabpage6 = new TTVisual.TTTabPage();
        this.tttabpage6.DisplayIndex = 4;
        this.tttabpage6.TabIndex = 5;
        this.tttabpage6.Text = "Doğrudan Teminle Alınan Radyofarmasötik Malzemeler";
        this.tttabpage6.Visible = false;
        this.tttabpage6.Name = "tttabpage6";

        this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = new TTVisual.TTGrid();
        this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.Name = "NuclearMedicine_RadyofarmasotikDirectPurchaseGrids";
        this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.TabIndex = 0;

        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.ListDefName = "RadyofarmasotikDPADetaillList";
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.DataMember = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.DisplayIndex = 0;
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.HeaderText = "22F Radyofarmasotik Malzeme";
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.Name = "DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid";
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.Width = 400;

        this.tttabpage7 = new TTVisual.TTTabPage();
        this.tttabpage7.DisplayIndex = 5;
        this.tttabpage7.TabIndex = 6;
        this.tttabpage7.Text = "Doğrudan Tedarik Edilen Malzemeler";
        this.tttabpage7.Name = "tttabpage7";

        this.DirectPurchaseGrids = new TTVisual.TTGrid();
        this.DirectPurchaseGrids.Name = "DirectPurchaseGrids";
        this.DirectPurchaseGrids.TabIndex = 0;
        this.DirectPurchaseGrids.ShowFilterCombo = true;
        this.DirectPurchaseGrids.FilterColumnName = "MaterialDirectPurchaseGrid";
        this.DirectPurchaseGrids.FilterLabel = i18n("M18545", "Malzeme");
        this.DirectPurchaseGrids.Filter = { ListDefName: "MaterialListDefinition" };
        this.DirectPurchaseGrids.AllowUserToAddRows = true;
        this.DirectPurchaseGrids.AllowUserToDeleteRows = true;
        this.DirectPurchaseGrids.DeleteButtonWidth = "5%";
        this.DirectPurchaseGrids.ShowTotalNumberOfRows = false;
        this.DirectPurchaseGrids.IsFilterLabelSingleLine = false;
        this.DirectPurchaseGrids.Height = "300";

        this.MaterialDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.MaterialDirectPurchaseGrid.ListDefName = "MaterialListDefinition";
        this.MaterialDirectPurchaseGrid.DataMember = "Material";
        this.MaterialDirectPurchaseGrid.DisplayIndex = 0;
        this.MaterialDirectPurchaseGrid.HeaderText = "Malzeme";
        this.MaterialDirectPurchaseGrid.Name = "MaterialDirectPurchaseGrid";
        this.MaterialDirectPurchaseGrid.Width = 300;
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogWidth = '75%';
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogHeight = '50%';

        this.AmountDirectPurchaseGrid = new TTVisual.TTTextBoxColumn();
        this.AmountDirectPurchaseGrid.DataMember = "Amount";
        this.AmountDirectPurchaseGrid.DisplayIndex = 1;
        this.AmountDirectPurchaseGrid.HeaderText = "Miktar";
        this.AmountDirectPurchaseGrid.Name = "AmountDirectPurchaseGrid";
        this.AmountDirectPurchaseGrid.Width = 80;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridNuclearMedicineMaterialColumns = [this.MaterialActionDate, this.Material, this.Note, this.Amount, this.malzemeSatinAlisTarihi, this.kodsuzMalzemeFiyati, this.kdv, this.malzemeTuru, this.malzemeBrans, this.malzemeOzelDurum];
        this.ttgrid2Columns = [this.ttdatetimepickercolumn1, this.ttlistboxcolumn1, this.DistributionType, this.IsInjection, this.tttextboxcolumn1, this.tttextboxcolumn2, this.Unit];
        this.ttgridCokluOzelDurumColumns = [this.ttenumcomboboxCokluOzelDurum];
        this.SurgeryDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar];
        this.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid];
        this.DirectPurchaseGridsColumns = [this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid];
        this.ttgroupbox1.Controls = [this.ttMasterResourceUserCheck, this.ttlabel7, this.RESPONSIBLEACADEMICSTAFF, this.ttlabel5, this.ttlabel1, this.tttextbox3, this.tttabcontrol1, this.nucMedSelectedTesttxt, this.ReasonForAdmission, this.GridEpisodeDiagnosis, this.tttextbox1, this.ttlabel15, this.PatientBirthDate, this.PatientBirthPlace, this.IsEmergency, this.ttlabel14, this.ttlabel13, this.PATIENTGROUPENUM, this.REQUESTDOCTOR, this.ttlabel9, this.ttlabel8, this.ActionDate, this.REQUESTDOCTORPHONE, this.ProcedureDate, this.ttlabel10, this.ttlabel12, this.PATIENTPHONENUMBER, this.ttlabel11, this.PATIENTWEIGHT, this.ttlabel2, this.RESPONSIBLEDOCTOR, this.PROCEDUREDOCTOR, this.ttlabel6, this.InjectionDate, this.ttlabel4, this.ttlabel3, this.labelProcessTime];
        this.tttabcontrol1.Controls = [this.tttabpage3, this.tttabpage1, this.tttabpage2, this.tttabpage4];
        this.tttabpage3.Controls = [this.RTFREPORT, this.RTFResultsAndComparisonInfo];
        this.tttabpage1.Controls = [this.PREDIAGNOSIS];
        this.tttabpage2.Controls = [this.RADIOPHARMACYDESC];
        this.tttabpage4.Controls = [this.NUCMEDDOCTORNOTE];
        this.TABNuclearMedicine.Controls = [this.TabPageMaterial, this.RadPharmMatTab, this.TabMedulaBilgileri, this.tttabpage5, this.tttabpage6, this.tttabpage7];
        this.TabPageMaterial.Controls = [this.GridNuclearMedicineMaterial];
        this.RadPharmMatTab.Controls = [this.ttgrid2];
        this.TabMedulaBilgileri.Controls = [this.ttlabelDrAnesteziTescilNo, this.TTListBoxDrAnesteziTescilNo, this.TTListBoxOzelDurum, this.ttgridCokluOzelDurum, this.labelOzelDurum, this.ttlabel18, this.ttlabelSagSol, this.ttlabel16, this.TTListBoxSagSol, this.tttextboxBirim, this.TTListBoxKesi, this.Description, this.ttlabelBirim];
        this.tttabpage5.Controls = [this.SurgeryDirectPurchaseGrids];
        this.tttabpage6.Controls = [this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids];
        this.tttabpage7.Controls = [this.DirectPurchaseGrids];
        this.Controls = [this.ttgroupbox1, this.ttMasterResourceUserCheck, this.ttlabel7, this.RESPONSIBLEACADEMICSTAFF, this.ttlabel5, this.ttlabel1, this.tttextbox3, this.tttabcontrol1, this.tttabpage3, this.RTFREPORT, this.tttabpage1, this.PREDIAGNOSIS, this.tttabpage2, this.RADIOPHARMACYDESC, this.tttabpage4, this.NUCMEDDOCTORNOTE, this.nucMedSelectedTesttxt, this.ReasonForAdmission, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.tttextbox1, this.ttlabel15, this.PatientBirthDate, this.PatientBirthPlace, this.IsEmergency, this.ttlabel14, this.ttlabel13, this.PATIENTGROUPENUM, this.REQUESTDOCTOR, this.ttlabel9, this.ttlabel8, this.ActionDate, this.REQUESTDOCTORPHONE, this.ProcedureDate, this.ttlabel10, this.ttlabel12, this.PATIENTPHONENUMBER, this.ttlabel11, this.PATIENTWEIGHT, this.ttlabel2, this.RESPONSIBLEDOCTOR, this.PROCEDUREDOCTOR, this.ttlabel6, this.InjectionDate, this.ttlabel4, this.ttlabel3, this.labelProcessTime, this.TABNuclearMedicine, this.TabPageMaterial, this.GridNuclearMedicineMaterial, this.MaterialActionDate, this.Material, this.Note, this.Amount, this.malzemeSatinAlisTarihi, this.kodsuzMalzemeFiyati, this.kdv, this.malzemeTuru, this.malzemeBrans, this.malzemeOzelDurum, this.RadPharmMatTab, this.ttgrid2, this.ttdatetimepickercolumn1, this.ttlistboxcolumn1, this.DistributionType, this.IsInjection, this.tttextboxcolumn1, this.tttextboxcolumn2, this.Unit, this.TabMedulaBilgileri, this.ttlabelDrAnesteziTescilNo, this.TTListBoxDrAnesteziTescilNo, this.TTListBoxOzelDurum, this.ttgridCokluOzelDurum, this.ttenumcomboboxCokluOzelDurum, this.labelOzelDurum, this.ttlabel18, this.ttlabelSagSol, this.ttlabel16, this.TTListBoxSagSol, this.tttextboxBirim, this.TTListBoxKesi, this.Description, this.ttlabelBirim, this.tttabpage5, this.SurgeryDirectPurchaseGrids, this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar, this.tttabpage6, this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids, this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid, this.tttabpage7, this.DirectPurchaseGrids, this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid];

    }


}
