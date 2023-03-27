//$E0C01731
import { Component, OnInit, NgZone  } from '@angular/core';
import { NuclearMedicineRadioPharmacyFormViewModel } from './NuclearMedicineRadioPharmacyFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { ImportantMedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTreatmentMat } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedRadPharmMatGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';

@Component({
    selector: 'NuclearMedicineRadioPharmacyForm',
    templateUrl: './NuclearMedicineRadioPharmacyForm.html',
    providers: [MessageService]
})
export class NuclearMedicineRadioPharmacyForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridNuclearMedicineMaterial: TTVisual.ITTGrid;
    GridRadPharmMaterials: TTVisual.ITTGrid;
    InjectedBy: TTVisual.ITTObjectListBox;
    IsEmergency: TTVisual.ITTCheckBox;
    IsInjection: TTVisual.ITTCheckBoxColumn;
    IsPregnant: TTVisual.ITTCheckBox;
    labelProcessTime: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    MaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    Note: TTVisual.ITTTextBoxColumn;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PATIENTWEIGHT: TTVisual.ITTTextBox;
    PatientPhone: TTVisual.ITTTextBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    //PrintBarcodeButton: TTVisual.ITTButton;
    RADIOPHARMACYDESC: TTVisual.ITTTextBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    TABNuclearMedicine: TTVisual.ITTTabControl;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepickercolumn2: TTVisual.ITTDateTimePickerColumn;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlistboxcolumn2: TTVisual.ITTListBoxColumn;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextbox4: TTVisual.ITTTextBox;
    tttextboxcolumn3: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn4: TTVisual.ITTTextBoxColumn;
    Units: TTVisual.ITTListBoxColumn;

    public TreatmentMaterialTypeName1: String;
    public TreatmentMaterialTypeName2: String;

    public GridEpisodeDiagnosisColumns = [];
    public GridNuclearMedicineMaterialColumns = [];
    public GridRadPharmMaterialsColumns = [];
    public nuclearMedicineRadioPharmacyFormViewModel: NuclearMedicineRadioPharmacyFormViewModel = new NuclearMedicineRadioPharmacyFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineRadioPharmacyForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineRadioPharmacyForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService,protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineRadioPharmacyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdBarcode_Click(): Promise<void> {

    }

    //private async PrintBarcodeButton_Click(): Promise<void> {
    //    //const string asc01 = "\u0001";
    //    //const string asc02 = "\u0002";
    //    //const string crlf = "\r\n";

    //    //string name = this._NuclearMedicine.Episode.Patient.Name + " " + this._NuclearMedicine.Episode.Patient.Surname;
    //    //string age = this._NuclearMedicine.Episode.Patient.Age.ToString();
    //    //string sex = this._NuclearMedicine.Episode.Patient.Sex.ToString();
    //    //string uniquerefno = this._NuclearMedicine.Episode.Patient.UniqueRefNo.ToString();
    //    //string prepDate = this._NuclearMedicine.PharmaceuticalPrepDate.ToString();
    //    //string testno = this._NuclearMedicine.TestSequenceNo.ToString();
    //    //string etiket = "";

    //    //etiket += asc02 + "KI70x1" + crlf;
    //    //etiket += asc02 + "M3000" + crlf;
    //    //etiket += asc02 + "c0000" + crlf;
    //    //etiket += asc02 + "e" + crlf;
    //    //etiket += asc02 + "O0215" + crlf;
    //    //etiket += asc02 + "f255" + crlf;
    //    //etiket += asc01 + "D";
    //    //etiket += asc02 + "L" + crlf;
    //    //etiket += asc02 + "L" + crlf;
    //    //etiket += "D11" + crlf;
    //    //etiket += "PE" + crlf;
    //    //etiket += "SE" + crlf;
    //    //etiket += "H10" + crlf;
    //    //etiket += "1AA506900880056" + testno + crlf;
    //    //etiket += "141100002120042" + name + crlf;
    //    //etiket += "141100002110243" + uniquerefno + crlf;
    //    //etiket += "141100002110243" + age + crlf;
    //    //etiket += "121100000610047";
    //    //int i = 1;
    //    //foreach (NucMedRadPharmMatGrid radPharm in this._NuclearMedicine.RadPharmMaterials)
    //    //{
    //    //    etiket += "(" + i + ")" + radPharm.Material.Name + " " + radPharm.Amount + " doz ";
    //    //    i++;
    //    //}
    //    //etiket += crlf;
    //    //etiket += "121100000420046" + prepDate + crlf;
    //    //etiket += "Q0001" + crlf;
    //    //etiket += "E" + crlf;
    //    //System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\dene.prn");
    //    //sw.Write(etiket);
    //    //sw.Close();

    //    //try
    //    //{
    //    //    System.IO.Ports.SerialPort s = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8);
    //    //    s.Handshake = System.IO.Ports.Handshake.None;
    //    //    s.Open();
    //    //    s.WriteTimeout = 5000;
    //    //    s.Write(etiket);
    //    //    s.Close();
    //    //}

    //    //catch (Exception ex)
    //    //{
    //    //    string hatamesaji = "Etiket yazdırma sırasında hata oluştu. \r\n" + ex.ToString();
    //    //}
    //    let a = 1;
    //}
    //protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
    //    super.AfterContextSavedScript(transDef);
    //    let ttMessage: TTMessage = null;
    //    if (transDef.ToStateDefID === NuclearMedicine.NuclearMedicineStates.Procedure) {
    //        let sysparam: string = (await SystemParameterService.GetParameterValue('HL7ENGINEALIVE', null));
    //        if (sysparam === 'TRUE') {
    //            try {
    //                (await PatientService.SendPatientToPACS(this._NuclearMedicine.Episode.Patient));
    //            }
    //            catch (ex) {
    //                let message: string = (await SystemMessageService.GetMessage(200));
    //                throw new TTException(message);
    //            }

    //            let appIDs: Array<Guid> = new Array<Guid>();
    //            for (let test of this._NuclearMedicine.NuclearMedicineTests) {
    //                appIDs.push(test.ObjectID);
    //            }
    //            //if(this._NuclearMedicine.NuclearMedicineTests.Count > 0)
    //            //    appIDs.Add(this._NuclearMedicine.NuclearMedicineTests[0].ObjectID);
    //            try {

    //            }
    //            catch (ex) {
    //                let newContext: TTObjectContext = new TTObjectContext(false);
    //                let nuclearMedicineObject: TTObject = newContext.GetObject(this._NuclearMedicine.ObjectID, 'NuclearMedicine');
    //                let nuclearMedicine: NuclearMedicine = nuclearMedicineObject as NuclearMedicine;
    //                //nuclearMedicine.IsMessageInPACS = false;
    //                newContext.Save();
    //                let message: string = (await SystemMessageService.GetMessage(200));
    //                throw new TTException(message);
    //            }

    //        }
    //    }
    //}
    /*
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        if (transDef !== null)
            if (transDef.ToStateDefID === NuclearMedicine.NuclearMedicineStates.Rejected || transDef.ToStateDefID === NuclearMedicine.NuclearMedicineStates.Cancelled)
                return;
        if (!(this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.Value !== undefined))
            this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.GetNextValue();
    } */
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.AddHelpMenu();
        //if (this._NuclearMedicine.NuclearMedicineTests.length > 0) {
        //    if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject !== null) {
        //        this.nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
        //    }
        //}
        //this.InjectedBy.SelectedObject = Common.CurrentUser.UserObject;
        //if (this._NuclearMedicine.Episode.Patient.ImportantMedicalInformation === null) {
        //    this.IsPregnant.Value = false;
        //}
        //this.SetTreatmentMaterialListFilter(<TTObjectDef>TTObjectDefManager.Instance.ObjectDefs[typeof NucMedTreatmentMat], <TTVisual.ITTGridColumn>this.GridNuclearMedicineMaterial.Columns['Material']);
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

    }

    public RemoveMenuFromHelpMenu(): void {

        this.sideBarMenuService.removeMenu('radiologyHistory');
        this.sideBarMenuService.removeMenu('pathologyHistory');
        this.sideBarMenuService.removeMenu('testHistory');
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
        await this.load(NuclearMedicineRadioPharmacyFormViewModel);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineRadioPharmacyFormViewModel = new NuclearMedicineRadioPharmacyFormViewModel();
        this._ViewModel = this.nuclearMedicineRadioPharmacyFormViewModel;
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.NucMedTreatmentMats = new Array<NucMedTreatmentMat>();
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.RadPharmMaterials = new Array<NucMedRadPharmMatGrid>();
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.Episode.Patient = new Patient();
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.Episode.Patient.ImportantMedicalInformation = new ImportantMedicalInformation();
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.InjectedBy = new ResUser();
        this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineRadioPharmacyFormViewModel = this._ViewModel as NuclearMedicineRadioPharmacyFormViewModel;
        that._TTObject = this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineRadioPharmacyFormViewModel == null)
            this.nuclearMedicineRadioPharmacyFormViewModel = new NuclearMedicineRadioPharmacyFormViewModel();
        if (this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine = new NuclearMedicine();
        that.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.NucMedTreatmentMats = that.nuclearMedicineRadioPharmacyFormViewModel.GridNuclearMedicineMaterialGridList;
        for (let detailItem of that.nuclearMedicineRadioPharmacyFormViewModel.GridNuclearMedicineMaterialGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineRadioPharmacyFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }
        that.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.RadPharmMaterials = that.nuclearMedicineRadioPharmacyFormViewModel.GridRadPharmMaterialsGridList;
        for (let detailItem of that.nuclearMedicineRadioPharmacyFormViewModel.GridRadPharmMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineRadioPharmacyFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.nuclearMedicineRadioPharmacyFormViewModel.RadioPharmaceuticalUnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    detailItem.Unit = unit;
                }
            }
        }
        let episodeObjectID = that.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineRadioPharmacyFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === "string")) {
                    let patient = that.nuclearMedicineRadioPharmacyFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                    if (patient != null) {
                        let importantMedicalInformationObjectID = patient["ImportantMedicalInformation"];
                        if (importantMedicalInformationObjectID != null && (typeof importantMedicalInformationObjectID === "string")) {
                            let importantMedicalInformation = that.nuclearMedicineRadioPharmacyFormViewModel.ImportantMedicalInformations.find(o => o.ObjectID.toString() === importantMedicalInformationObjectID.toString());
                            if (importantMedicalInformation) {
                                patient.ImportantMedicalInformation = importantMedicalInformation;
                            }
                        }
                    }
                }
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineRadioPharmacyFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineRadioPharmacyFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineRadioPharmacyFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineRadioPharmacyFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let injectedByObjectID = that.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine["InjectedBy"];
        if (injectedByObjectID != null && (typeof injectedByObjectID === "string")) {
            let injectedBy = that.nuclearMedicineRadioPharmacyFormViewModel.ResUsers.find(o => o.ObjectID.toString() === injectedByObjectID.toString());
            if (injectedBy) {
                that.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.InjectedBy = injectedBy;
            }
        }
        let requestDoctorObjectID = that.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineRadioPharmacyFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineRadioPharmacyFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineRadioPharmacyFormViewModel);
  

        that.TreatmentMaterialTypeName1 = 'NUCMEDTREATMENTMAT';
        that.TreatmentMaterialTypeName2 = 'NUCMEDRADPHARMMATGRID';
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ActionDate != event) {
                this._NuclearMedicine.ActionDate = event;
            }
        }
    }

    public onInjectedByChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.InjectedBy != event) {
                this._NuclearMedicine.InjectedBy = event;
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

    public onIsPregnantChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null &&
                this._NuclearMedicine.Episode != null &&
                this._NuclearMedicine.Episode.Patient != null &&
                this._NuclearMedicine.Episode.Patient.ImportantMedicalInformation != null && this._NuclearMedicine.Episode.Patient.ImportantMedicalInformation.IsPregnant != event) {
                this._NuclearMedicine.Episode.Patient.ImportantMedicalInformation.IsPregnant = event;
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

    public onPatientPhoneChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientPhoneNumber != event) {
                this._NuclearMedicine.PatientPhoneNumber = event;
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

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PharmaceuticalPrepDate != event) {
                this._NuclearMedicine.PharmaceuticalPrepDate = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientAge != event) {
                this._NuclearMedicine.PatientAge = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.NuclearMaterialName != event) {
                this._NuclearMedicine.NuclearMaterialName = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProtocolNo != event) {
                this._NuclearMedicine.ProtocolNo = event;
            }
        }
    }

    public ontttextbox4Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.TestSequenceNo != event) {
                this._NuclearMedicine.TestSequenceNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.PATIENTWEIGHT, "Text", this.__ttObject, "PatientWeight");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PatientAge");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.PatientPhone, "Text", this.__ttObject, "PatientPhoneNumber");
        redirectProperty(this.tttextbox4, "Text", this.__ttObject, "TestSequenceNo");
        redirectProperty(this.IsPregnant, "Value", this.__ttObject, "Episode.Patient.ImportantMedicalInformation.IsPregnant");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "PharmaceuticalPrepDate");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.RADIOPHARMACYDESC, "Text", this.__ttObject, "RadioPharmacyDescription");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "NuclearMaterialName");
    }

    public initFormControls(): void {
        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 2;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Açıklama";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 2;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#DCDCDC";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = "Test Sıra No";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 15;

        //this.PrintBarcodeButton = new TTVisual.TTButton();
        //this.PrintBarcodeButton.Text = "Barkod Bas";
        //this.PrintBarcodeButton.Name = "PrintBarcodeButton";
        //this.PrintBarcodeButton.TabIndex = 16;

        this.tttextbox4 = new TTVisual.TTTextBox();
        this.tttextbox4.BackColor = "#F0F0F0";
        this.tttextbox4.ReadOnly = true;
        this.tttextbox4.Name = "tttextbox4";
        this.tttextbox4.TabIndex = 11;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 15;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "Farmasötik Hazırlama Tarihi";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 2;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tetkik";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.TABNuclearMedicine = new TTVisual.TTTabControl();
        this.TABNuclearMedicine.Name = "TABNuclearMedicine";
        this.TABNuclearMedicine.TabIndex = 17;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.tttabpage1.Name = "tttabpage1";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 17;
        this.PREDIAGNOSIS.Height = "150px";

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = "N.T. Tabip Notu";
        this.tttabpage2.Name = "tttabpage2";

        this.RADIOPHARMACYDESC = new TTVisual.TTTextBox();
        this.RADIOPHARMACYDESC.Multiline = true;
        this.RADIOPHARMACYDESC.Name = "RADIOPHARMACYDESC";
        this.RADIOPHARMACYDESC.TabIndex = 19;
        this.RADIOPHARMACYDESC.Height = "150px";

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.BackColor = "#FFFFFF";
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = "Sarf Malzeme";
        this.tttabpage3.Name = "tttabpage3";

        this.GridNuclearMedicineMaterial = new TTVisual.TTGrid();
        this.GridNuclearMedicineMaterial.Name = "GridNuclearMedicineMaterial";
        this.GridNuclearMedicineMaterial.TabIndex = 1;

        this.MaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.MaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.MaterialActionDate.DataMember = "ActionDate";
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

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = "Miktar";
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = "Note";
        this.Note.DisplayIndex = 3;
        this.Note.HeaderText = "Notlar";
        this.Note.Name = "Note";
        this.Note.Width = 220;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 3;
        this.tttabpage4.TabIndex = 3;
        this.tttabpage4.Text = "Radyofarmasötik  Madde Sarf ";
        this.tttabpage4.Name = "tttabpage4";

        this.GridRadPharmMaterials = new TTVisual.TTGrid();
        this.GridRadPharmMaterials.Name = "GridRadPharmMaterials";
        this.GridRadPharmMaterials.TabIndex = 1;

        this.ttdatetimepickercolumn2 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn2.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn2.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn2.DataMember = "ActionDate";
        this.ttdatetimepickercolumn2.DisplayIndex = 0;
        this.ttdatetimepickercolumn2.HeaderText = "Tarih/Saat";
        this.ttdatetimepickercolumn2.Name = "ttdatetimepickercolumn2";
        this.ttdatetimepickercolumn2.ReadOnly = true;
        this.ttdatetimepickercolumn2.Width = 140;

        this.ttlistboxcolumn2 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn2.ListDefName = "TreatmentMaterialListDefinition";
        this.ttlistboxcolumn2.DataMember = "Material";
        this.ttlistboxcolumn2.DisplayIndex = 1;
        this.ttlistboxcolumn2.HeaderText = "Sarf Edilen Malzemeler";
        this.ttlistboxcolumn2.Name = "ttlistboxcolumn2";
        this.ttlistboxcolumn2.Width = 320;

        this.IsInjection = new TTVisual.TTCheckBoxColumn();
        this.IsInjection.DisplayIndex = 2;
        this.IsInjection.HeaderText = "Enjeksiyon";
        this.IsInjection.Name = "IsInjection";
        this.IsInjection.Width = 60;

        this.tttextboxcolumn3 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn3.DataMember = "Note";
        this.tttextboxcolumn3.DisplayIndex = 3;
        this.tttextboxcolumn3.HeaderText = "Erişkin Dozu";
        this.tttextboxcolumn3.Name = "tttextboxcolumn3";
        this.tttextboxcolumn3.ReadOnly = true;
        this.tttextboxcolumn3.Width = 100;

        this.tttextboxcolumn4 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn4.DataMember = "Amount";
        this.tttextboxcolumn4.DisplayIndex = 4;
        this.tttextboxcolumn4.HeaderText = "Verilen Doz";
        this.tttextboxcolumn4.Name = "tttextboxcolumn4";
        this.tttextboxcolumn4.Width = 100;

        this.Units = new TTVisual.TTListBoxColumn();
        this.Units.ListDefName = "RadioPharmaceuticalUnitListDefinition";
        this.Units.DataMember = "Unit";
        this.Units.DisplayIndex = 5;
        this.Units.HeaderText = "Birim";
        this.Units.Name = "Units";
        this.Units.Width = 80;

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 6;

        this.IsPregnant = new TTVisual.TTCheckBox();
        this.IsPregnant.Value = false;
        this.IsPregnant.Text = "Hamile";
        this.IsPregnant.Enabled = false;
        this.IsPregnant.Name = "IsPregnant";
        this.IsPregnant.TabIndex = 12;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 5;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 1;

        this.InjectedBy = new TTVisual.TTObjectListBox();
        this.InjectedBy.ListDefName = "ResUserListDefinition";
        this.InjectedBy.Name = "InjectedBy";
        this.InjectedBy.TabIndex = 10;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Protokol No";
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 8;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "Hastanın Yaşı";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 15;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Enjeksiyonu Yapan";
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 10;

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 7;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Enabled = false;
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 13;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 3;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 14;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmiş";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 60;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisDefinitionList";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 330;

        this.EpisodeDiagnoseType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnoseType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnoseType.DataMember = "DiagnosisType";
        this.EpisodeDiagnoseType.DisplayIndex = 2;
        this.EpisodeDiagnoseType.HeaderText = "Tanı Tipi";
        this.EpisodeDiagnoseType.Name = "EpisodeDiagnoseType";
        this.EpisodeDiagnoseType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = "Ana Tanı";
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 60;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = "Tanı Koyan";
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = "Tanı Giriş Tarihi";
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = "Giriş Yapılan İşlem";
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "İstek Yapan Tabip Telefon";
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 12;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 8;

        this.PatientPhone = new TTVisual.TTTextBox();
        this.PatientPhone.BackColor = "#F0F0F0";
        this.PatientPhone.ReadOnly = true;
        this.PatientPhone.Name = "PatientPhone";
        this.PatientPhone.TabIndex = 9;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Hastanın Telefonu";
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 8;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Hastanın Kilosu";
        this.ttlabel5.BackColor = "#DCDCDC";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 6;

        this.PATIENTWEIGHT = new TTVisual.TTTextBox();
        this.PATIENTWEIGHT.BackColor = "#F0F0F0";
        this.PATIENTWEIGHT.ReadOnly = true;
        this.PATIENTWEIGHT.Name = "PATIENTWEIGHT";
        this.PATIENTWEIGHT.TabIndex = 4;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Kabul Sebebi";
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 4;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Hasta Grubu";
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 2;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "İşlem Zamanı";
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "İstek Yapan Tabip";
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 10;

        this.GridNuclearMedicineMaterialColumns = [this.MaterialActionDate, this.Material, this.Amount, this.Note];
        this.GridRadPharmMaterialsColumns = [this.ttdatetimepickercolumn2, this.ttlistboxcolumn2, this.IsInjection, this.tttextboxcolumn3, this.tttextboxcolumn4, this.Units];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.ttgroupbox1.Controls = [this.ttlabel12, this.tttextbox4, this.ttdatetimepicker1, this.ttlabel9, this.ttlabel1, this.TABNuclearMedicine, this.nucMedSelectedTesttxt, this.IsPregnant, this.ReasonForAdmission, this.tttextbox1, this.tttextbox3, this.InjectedBy, this.ttlabel15, this.ttlabel10, this.ttlabel8, this.REQUESTDOCTOR, this.IsEmergency, this.PATIENTGROUPENUM, this.GridEpisodeDiagnosis, this.ttlabel7, this.REQUESTDOCTORPHONE, this.PatientPhone, this.ttlabel6, this.ttlabel5, this.PATIENTWEIGHT, this.ttlabel4, this.ttlabel3, this.labelProcessTime, this.ActionDate, this.ttlabel2];
        this.TABNuclearMedicine.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3, this.tttabpage4];
        this.tttabpage1.Controls = [this.PREDIAGNOSIS];
        this.tttabpage2.Controls = [this.RADIOPHARMACYDESC];
        this.tttabpage3.Controls = [this.GridNuclearMedicineMaterial];
        this.tttabpage4.Controls = [this.GridRadPharmMaterials];
        this.Controls = [this.tttextbox2, this.ttlabel11, this.ttgroupbox1, this.ttlabel12, this.tttextbox4, this.ttdatetimepicker1, this.ttlabel9, this.ttlabel1, this.TABNuclearMedicine, this.tttabpage1, this.PREDIAGNOSIS, this.tttabpage2, this.RADIOPHARMACYDESC, this.tttabpage3, this.GridNuclearMedicineMaterial, this.MaterialActionDate, this.Material, this.Amount, this.Note, this.tttabpage4, this.GridRadPharmMaterials, this.ttdatetimepickercolumn2, this.ttlistboxcolumn2, this.IsInjection, this.tttextboxcolumn3, this.tttextboxcolumn4, this.Units, this.nucMedSelectedTesttxt, this.IsPregnant, this.ReasonForAdmission, this.tttextbox1, this.tttextbox3, this.InjectedBy, this.ttlabel15, this.ttlabel10, this.ttlabel8, this.REQUESTDOCTOR, this.IsEmergency, this.PATIENTGROUPENUM, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttlabel7, this.REQUESTDOCTORPHONE, this.PatientPhone, this.ttlabel6, this.ttlabel5, this.PATIENTWEIGHT, this.ttlabel4, this.ttlabel3, this.labelProcessTime, this.ActionDate, this.ttlabel2];

    }


}
