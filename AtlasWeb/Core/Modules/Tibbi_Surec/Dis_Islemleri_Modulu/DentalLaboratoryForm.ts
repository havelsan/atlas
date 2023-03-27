//$E609596C
import { Component, OnInit, NgZone } from '@angular/core';
import { DentalLaboratoryFormViewModel } from './DentalLaboratoryFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DentalExaminationSuggestedProsthesis } from 'NebulaClient/Model/AtlasClientModel';
import { DentalLaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DentalProsthesisRequestSuggestedProsthesis } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Technician } from 'NebulaClient/Model/AtlasClientModel';
import { ToothProthesisLabDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DentalLaboratoryProcedureService, FillTechnicians_Output } from 'ObjectClassService/DentalLaboratoryProcedureService';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DentalProsthesisMaterial } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'DentalLaboratoryForm',
    templateUrl: './DentalLaboratoryForm.html',
    providers: [MessageService]
})
export class DentalLaboratoryForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePickerColumn;
    Ad: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    chose: TTVisual.ITTCheckBoxColumn;
    color: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    TechnicianNote: TTVisual.ITTTextBoxColumn;
    CurrentWorksNum: TTVisual.ITTTextBoxColumn;
    date: TTVisual.ITTDateTimePickerColumn;
    DisNo: TTVisual.ITTEnumComboBoxColumn;
    Doctor: TTVisual.ITTObjectListBox;
    Durum: TTVisual.ITTEnumComboBoxColumn;
    enumTechType: TTVisual.ITTEnumComboBox;
    ExternalLab: TTVisual.ITTTextBoxColumn;
    gridProcedures: TTVisual.ITTGrid;
    gridTechnician: TTVisual.ITTGrid;
    Kdv: TTVisual.ITTTextBoxColumn;
    KodsuzMalzemeFiyati: TTVisual.ITTTextBoxColumn;
    labelDoctor: TTVisual.ITTLabel;
    LabelRequestDate: TTVisual.ITTLabel;
    MalzemeBilgisi_OzelDurum: TTVisual.ITTListBoxColumn;
    MalzemeBrans: TTVisual.ITTTextBoxColumn;
    MalzemeSAtinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    MalzemeTuru: TTVisual.ITTListBoxColumn;
    Material: TTVisual.ITTListBoxColumn;
    MaterialAmount: TTVisual.ITTTextBoxColumn;
    Note: TTVisual.ITTTextBoxColumn;
    ProsProc: TTVisual.ITTListBoxColumn;
    RequestDate: TTVisual.ITTDateTimePicker;
    SubactionTab: TTVisual.ITTTabControl;
    TECHNICIAN: TTVisual.ITTListBoxColumn;
    TECHNICIANTYPE: TTVisual.ITTEnumComboBoxColumn;
    TechnicianObjectId: TTVisual.ITTTextBoxColumn;
    TotalWorksNum: TTVisual.ITTTextBoxColumn;
    TreatmentMaterial: TTVisual.ITTTabPage;
    TreatmentMaterials: TTVisual.ITTGrid;
    ttbutton1: TTVisual.ITTButton;
    ttbutton2: TTVisual.ITTButton;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttcheckboxcolumn1: TTVisual.ITTCheckBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    TTListBoxExternalLab: TTVisual.ITTObjectListBox;
    tttabpage1: TTVisual.ITTTabPage;
    UBBCODE: TTVisual.ITTTextBoxColumn;
    tecnicans: Array<FillTechnicians_Output>;
    allTecnicans: Array<FillTechnicians_Output>;
    seletedTecnicans: Array<FillTechnicians_Output>;
    seletedProcedures: Array<DentalExaminationSuggestedProsthesis>;
    selectedToothProthesisLab: ToothProthesisLabDefinition;
    statuses: string[];
    public gridProceduresColumns = [];
    public gridTechnicianColumns = [];
    public TreatmentMaterialsColumns = [];
    public dentalLaboratoryFormViewModel: DentalLaboratoryFormViewModel = new DentalLaboratoryFormViewModel();
    public get _DentalLaboratoryProcedure(): DentalLaboratoryProcedure {
        return this._TTObject as DentalLaboratoryProcedure;
    }
    private DentalLaboratoryForm_DocumentUrl: string = '/api/DentalLaboratoryProcedureService/DentalLaboratoryForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private objectContextService: ObjectContextService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DentalLaboratoryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.statuses = [i18n("M15724", "Hepsi"), i18n("M15116", "Hareketli"), i18n("M21096", "Sabit"), i18n("M15117", "Hareketli ve Sabit")];
    }

    public includeDrugDefinition(): Boolean {
        return false;
    }

    selectStatus(data) {
        if (data.value === i18n("M15724", "Hepsi")) {
            this.tecnicans = this.allTecnicans;
        } else {
            this.tecnicans = new Array<FillTechnicians_Output>();
            for (let tech of this.allTecnicans) {
                if (tech.technicianTypeName === data.value) {
                    this.tecnicans.push(tech);
                }
            }
        }
    }

    // ***** Method declarations start *****

    GridProcedures_CellContentClickEmitted(data: any) {
        if (data && data.Row && data.Column) {
            this.gridProcedures.CurrentCell = {
                OwningRow: data.Row,
                OwningColumn: data.Column
            };
            if (this.gridProcedures.CurrentCell.OwningColumn.Name === 'ttcheckboxcolumn1') {
                if (data.Value.Selected === true) {
                    if (this.seletedProcedures.length === 0) {
                        this.seletedProcedures = new Array<DentalExaminationSuggestedProsthesis>();
                    }
                    let obj: DentalExaminationSuggestedProsthesis = (<DentalExaminationSuggestedProsthesis>(this.gridProcedures.CurrentCell.OwningRow.TTObject));
                    let foundItem = this.seletedProcedures.find(x => x === obj);
                    if (!foundItem) {
                        this.seletedProcedures.push((<DentalExaminationSuggestedProsthesis>(this.gridProcedures.CurrentCell.OwningRow.TTObject)));
                    }
                } else {
                    let obj: DentalExaminationSuggestedProsthesis = (<DentalExaminationSuggestedProsthesis>(this.gridProcedures.CurrentCell.OwningRow.TTObject));
                    let foundItem = this.seletedProcedures.find(x => x === obj);
                    if (foundItem) {
                        let index = this.seletedProcedures.indexOf(obj);
                        this.seletedProcedures.splice(index, 1);
                    }
                }
            }
        }
    }

    public async ttbutton1_Click(): Promise<void> {
        let teknisyen: Technician = null;
        let i: number = 0;
        if (this.seletedTecnicans.length > 0) {
            let tecOutput: FillTechnicians_Output = this.seletedTecnicans[0];
            teknisyen = await this.objectContextService.getObject<Technician>(tecOutput.TecnicanObjectID, Technician.ObjectDefID);
        } else {
            ServiceLocator.MessageService.showError(i18n("M23106", "Teknisyen ataması için teknisyen seçiniz!"));
        }
        if (this.seletedProcedures.length > 0) {
            for (let row of this.seletedProcedures) {
                (<DentalProsthesisRequestSuggestedProsthesis>row).Technician = teknisyen;
            }
        } else {
            ServiceLocator.MessageService.showError(i18n("M23105", "Teknisyen ataması için en az bir işlem seçmelisiniz!"));
        }
    }
    public async ttbutton2_Click(): Promise<void> {
        let outerLab: string = '';

        if (this.TTListBoxExternalLab.SelectedObject !== null) {
            this.selectedToothProthesisLab = (<ToothProthesisLabDefinition>this.TTListBoxExternalLab.SelectedObject) ;
            outerLab = this.selectedToothProthesisLab.Name;
        }
        let procedureFound: boolean = false;
        if (!''.Equals(outerLab)) {
            for (let row of this.seletedProcedures) {
                (<DentalProsthesisRequestSuggestedProsthesis>row).ExternalLab = outerLab;
                procedureFound = true;
            }
            if (!procedureFound) {
                ServiceLocator.MessageService.showError(i18n("M12752", "Dış Lab İsteği için en az bir işlem seçmelisiniz!"));
            }
        } else {
            ServiceLocator.MessageService.showError(i18n("M12751", "Dış Lab İsteği için dış laboratuar seçmelisiniz!"));
        }
    }
    private async ttcheckbox1_CheckedChanged(): Promise<void> {
        this.tecnicans = new Array<FillTechnicians_Output>();
        this.tecnicans = await DentalLaboratoryProcedureService.FillTechnicians();
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        /*let context: TTObjectContext = new TTObjectContext(false);
        for (let row of this.gridTechnician.Rows) {
            let techTemp: Array<Technician> = Technician.GetTechnicianById(context, <Guid>row.Cells[5].Value);
            if (row.Cells[2].Value !== null) {
                techTemp[0].TechnicianType = <DentalTechnicianTypeEnum>row.Cells[2].Value;
            }
        }
        context.Save();
        if (transDef === null || (transDef !== null && transDef.ToStateDefID === DentalLaboratoryProcedure.DentalLaboratoryProcedureStates.Completed)) {
            // Kaydet ve Tamamla yapıldığında Sarf Malzemelerin ücretlenmesi için
            for (let treatmentMaterial of this._DentalLaboratoryProcedure.TreatmentMaterials) { treatmentMaterial.AccountOperation(AccountOperationTimeEnum.PREPOST); }
        }*/
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.tecnicans = new Array<FillTechnicians_Output>();
        this.allTecnicans = await DentalLaboratoryProcedureService.FillTechnicians();
        this.tecnicans = this.allTecnicans;
        this.seletedProcedures = new Array<DentalExaminationSuggestedProsthesis>();
        //this.SetTreatmentMaterialListFilter(this._DentalLaboratoryProcedure.ObjectDef, <TTVisual.ITTGridColumn>this.TreatmentMaterials.Columns['Material']);
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        await super.AfterContextSavedScript(transDef);

        await this.load(DentalLaboratoryFormViewModel);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DentalLaboratoryProcedure();
        this.dentalLaboratoryFormViewModel = new DentalLaboratoryFormViewModel();
        this._ViewModel = this.dentalLaboratoryFormViewModel;
        this.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure = this._TTObject as DentalLaboratoryProcedure;
        this.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure.SuggestedProsthesis = new Array<DentalExaminationSuggestedProsthesis>();
        this.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure.DentalProsthesisMaterials = new Array<DentalProsthesisMaterial>();
        this.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.dentalLaboratoryFormViewModel = this._ViewModel as DentalLaboratoryFormViewModel;
        that._TTObject = this.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure;
        if (this.dentalLaboratoryFormViewModel == null) {
            this.dentalLaboratoryFormViewModel = new DentalLaboratoryFormViewModel();
        }
        if (this.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure == null) {
            this.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure = new DentalLaboratoryProcedure();
        }
        that.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure.SuggestedProsthesis = that.dentalLaboratoryFormViewModel.gridProceduresGridList;
        for (let detailItem of that.dentalLaboratoryFormViewModel.gridProceduresGridList) {
            let suggestedProsthesisProcedureObjectID = detailItem['SuggestedProsthesisProcedure'];
            if (suggestedProsthesisProcedureObjectID != null && (typeof suggestedProsthesisProcedureObjectID === 'string')) {
                let suggestedProsthesisProcedure = that.dentalLaboratoryFormViewModel.DentalProsthesisDefinitions.find(o => o.ObjectID.toString() === suggestedProsthesisProcedureObjectID.toString());
                 if (suggestedProsthesisProcedure) {
                    detailItem.SuggestedProsthesisProcedure = suggestedProsthesisProcedure;
                }
            }
            let technicianObjectID = detailItem['Technician'];
            if (technicianObjectID != null && (typeof technicianObjectID === 'string')) {
                let technician = that.dentalLaboratoryFormViewModel.Technicians.find(o => o.ObjectID.toString() === technicianObjectID.toString());
                 if (technician) {
                    detailItem.Technician = technician;
                }
            }
        }
        that.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure.DentalProsthesisMaterials = that.dentalLaboratoryFormViewModel.TreatmentMaterialsGridList;
        for (let detailItem of that.dentalLaboratoryFormViewModel.TreatmentMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.dentalLaboratoryFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let malzemeTuruObjectID = detailItem['MalzemeTuru'];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === 'string')) {
                let malzemeTuru = that.dentalLaboratoryFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                 if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem['OzelDurum'];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.dentalLaboratoryFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        that.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure.Diagnosis = that.dentalLaboratoryFormViewModel.GridDiagnosisGridList;
        for (let detailItem of that.dentalLaboratoryFormViewModel.GridDiagnosisGridList) {
            let diagnoseObjectID = detailItem['Diagnose'];
            if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                let diagnose = that.dentalLaboratoryFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                 if (diagnose) {
                    detailItem.Diagnose = diagnose;
                }
            }
            //let teshisObjectID = detailItem['Teshis'];
            //if (teshisObjectID != null && (typeof teshisObjectID === 'string')) {
            //    let teshis = that.dentalLaboratoryFormViewModel.Teshiss.find(o => o.ObjectID.toString() === teshisObjectID.toString());
            //    detailItem.Teshis = teshis;
            //}
            let responsibleUserObjectID = detailItem['ResponsibleUser'];
            if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                let responsibleUser = that.dentalLaboratoryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                 if (responsibleUser) {
                    detailItem.ResponsibleUser = responsibleUser;
                }
            }
        }
        let procedureDoctorObjectID = that.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure['ProcedureDoctor'];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.dentalLaboratoryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.dentalLaboratoryFormViewModel._DentalLaboratoryProcedure.ProcedureDoctor = procedureDoctor;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(DentalLaboratoryFormViewModel);
  
    }


    public onDoctorChanged(event): void {
        if (event != null) {
            if (this._DentalLaboratoryProcedure != null && this._DentalLaboratoryProcedure.ProcedureDoctor !== event) {
                this._DentalLaboratoryProcedure.ProcedureDoctor = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._DentalLaboratoryProcedure != null && this._DentalLaboratoryProcedure.RequestDate !== event) {
                this._DentalLaboratoryProcedure.RequestDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, 'Value', this.__ttObject, 'RequestDate');
    }

    public initFormControls(): void {
        this.ttcheckbox1 = new TTVisual.TTCheckBox();
        this.ttcheckbox1.Value = false;
        this.ttcheckbox1.Title = i18n("M21569", "Seçimi Kaldır");
        this.ttcheckbox1.Name = 'ttcheckbox1';
        this.ttcheckbox1.TabIndex = 74;

        this.enumTechType = new TTVisual.TTEnumComboBox();
        this.enumTechType.DataTypeName = 'DentalTechnicianTypeEnum';
        this.enumTechType.Name = 'enumTechType';
        this.enumTechType.TabIndex = 73;

        this.gridTechnician = new TTVisual.TTGrid();
        this.gridTechnician.Name = 'gridTechnician';
        this.gridTechnician.TabIndex = 71;
        this.gridTechnician.Height = '150';
        this.gridTechnician.AllowUserToAddRows = false;
        this.gridTechnician.AllowUserToDeleteRows = false;

        this.chose = new TTVisual.TTCheckBoxColumn();
        this.chose.DisplayIndex = 0;
        this.chose.HeaderText = i18n("M21507", "Seç");
        this.chose.Name = 'chose';
        this.chose.Width = 50;

        this.Ad = new TTVisual.TTTextBoxColumn();
        this.Ad.DisplayIndex = 1;
        this.Ad.HeaderText = 'Ad';
        this.Ad.Name = 'Ad';
        this.Ad.Width = 300;

        this.TECHNICIANTYPE = new TTVisual.TTEnumComboBoxColumn();
        this.TECHNICIANTYPE.DataTypeName = 'DentalTechnicianTypeEnum';
        this.TECHNICIANTYPE.DisplayIndex = 2;
        this.TECHNICIANTYPE.HeaderText = i18n("M23117", "Teknisyen Tipi");
        this.TECHNICIANTYPE.Name = 'TECHNICIANTYPE';
        this.TECHNICIANTYPE.Width = 100;

        this.TotalWorksNum = new TTVisual.TTTextBoxColumn();
        this.TotalWorksNum.DisplayIndex = 3;
        this.TotalWorksNum.HeaderText = i18n("M23508", "Toplam İş Sayısı");
        this.TotalWorksNum.Name = 'TotalWorksNum';
        this.TotalWorksNum.ReadOnly = true;
        this.TotalWorksNum.Width = 50;

        this.CurrentWorksNum = new TTVisual.TTTextBoxColumn();
        this.CurrentWorksNum.DisplayIndex = 4;
        this.CurrentWorksNum.HeaderText = i18n("M12313", "Çalışılan İş Sayısı");
        this.CurrentWorksNum.Name = 'CurrentWorksNum';
        this.CurrentWorksNum.ReadOnly = true;
        this.CurrentWorksNum.Width = 50;

        this.TechnicianObjectId = new TTVisual.TTTextBoxColumn();
        this.TechnicianObjectId.DisplayIndex = 5;
        this.TechnicianObjectId.HeaderText = 'Hidden';
        this.TechnicianObjectId.Name = 'TechnicianObjectId';
        this.TechnicianObjectId.Visible = false;
        this.TechnicianObjectId.Width = 100;

        this.ttbutton1 = new TTVisual.TTButton();
        this.ttbutton1.Text = i18n("M21558", "Seçili İşlemlere Teknisyen Ata");
        this.ttbutton1.Name = 'ttbutton1';
        this.ttbutton1.TabIndex = 70;

        this.gridProcedures = new TTVisual.TTGrid();
        this.gridProcedures.Name = 'gridProcedures';
        this.gridProcedures.TabIndex = 69;
        this.gridProcedures.Height = '250';
        this.gridProcedures.AllowUserToAddRows = false;
        this.gridProcedures.AllowUserToDeleteRows = false;

        this.ttcheckboxcolumn1 = new TTVisual.TTCheckBoxColumn();
        this.ttcheckboxcolumn1.DisplayIndex = 0;
        this.ttcheckboxcolumn1.HeaderText = i18n("M21507", "Seç");
        this.ttcheckboxcolumn1.Name = 'ttcheckboxcolumn1';
        this.ttcheckboxcolumn1.Width = 50;
        this.ttcheckboxcolumn1.DataMember = 'Selected';

        this.date = new TTVisual.TTDateTimePickerColumn();
        this.date.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.date.DataMember = 'ActionDate';
        this.date.DisplayIndex = 1;
        this.date.HeaderText = 'Tarih';
        this.date.Name = 'date';
        this.date.Width = 150;

        this.ProsProc = new TTVisual.TTListBoxColumn();
        this.ProsProc.ListDefName = 'DentalProsthesisListDefinition';
        this.ProsProc.DataMember = 'SuggestedProsthesisProcedure';
        this.ProsProc.DisplayIndex = 2;
        this.ProsProc.HeaderText = i18n("M16818", "İşlem");
        this.ProsProc.Name = 'ProsProc';
        this.ProsProc.Width = 300;

        this.DisNo = new TTVisual.TTEnumComboBoxColumn();
        this.DisNo.DataTypeName = 'ToothNumberEnum';
        this.DisNo.DataMember = 'ToothNumber';
        this.DisNo.DisplayIndex = 3;
        this.DisNo.HeaderText = i18n("M12916", "Diş Nu./Ağız Bölgesi");
        this.DisNo.Name = 'DisNo';
        this.DisNo.Width = 150;

        this.TECHNICIAN = new TTVisual.TTListBoxColumn();
        this.TECHNICIAN.ListDefName = 'DentalTechnicianList';
        this.TECHNICIAN.DataMember = 'Technician';
        this.TECHNICIAN.DisplayIndex = 4;
        this.TECHNICIAN.HeaderText = 'Teknisyen';
        this.TECHNICIAN.Name = 'TECHNICIAN';
        this.TECHNICIAN.ReadOnly = false;
        this.TECHNICIAN.Width = 150;

        this.Durum = new TTVisual.TTEnumComboBoxColumn();
        this.Durum.DataTypeName = 'DisDurumEnum';
        this.Durum.DataMember = 'CurrentState';
        this.Durum.DisplayIndex = 5;
        this.Durum.HeaderText = 'Durum';
        this.Durum.Name = 'Durum';
        this.Durum.ToolTipText = i18n("M12889", "Diş Durum");
        this.Durum.Width = 150;

        this.color = new TTVisual.TTTextBoxColumn();
        this.color.DataMember = 'Color';
        this.color.DisplayIndex = 6;
        this.color.HeaderText = i18n("M21020", "Renk");
        this.color.Name = 'color';
        this.color.Width = 75;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = 'Definition';
        this.Description.DisplayIndex = 6;
        this.Description.HeaderText = "Doktor Açıklaması";
        this.Description.Name = 'Definition';
        this.Description.Width = 75;

        this.TechnicianNote = new TTVisual.TTTextBoxColumn();
        this.TechnicianNote.DataMember = 'TechnicianNote';
        this.TechnicianNote.DisplayIndex = 6;
        this.TechnicianNote.HeaderText = "Teknisyen Notu";
        this.TechnicianNote.Name = 'TechnicianNote';
        this.TechnicianNote.Width = 75;

        this.ExternalLab = new TTVisual.TTTextBoxColumn();
        this.ExternalLab.DataMember = 'ExternalLab';
        this.ExternalLab.DisplayIndex = 7;
        this.ExternalLab.HeaderText = i18n("M12750", "Dış Lab");
        this.ExternalLab.Name = 'ExternalLab';
        this.ExternalLab.ReadOnly = true;
        this.ExternalLab.Width = 150;

        this.LabelRequestDate = new TTVisual.TTLabel();
        this.LabelRequestDate.Text = i18n("M16688", "İstekler");
        this.LabelRequestDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.LabelRequestDate.ForeColor = '#000000';
        this.LabelRequestDate.Name = 'LabelRequestDate';
        this.LabelRequestDate.TabIndex = 62;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = '#F0F0F0';
        this.RequestDate.CustomFormat = '';
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.RequestDate.Name = 'RequestDate';
        this.RequestDate.TabIndex = 63;

        this.SubactionTab = new TTVisual.TTTabControl();
        this.SubactionTab.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.SubactionTab.Name = 'SubactionTab';
        this.SubactionTab.TabIndex = 57;

        this.TreatmentMaterial = new TTVisual.TTTabPage();
        this.TreatmentMaterial.DisplayIndex = 0;
        this.TreatmentMaterial.BackColor = '#FFFFFF';
        this.TreatmentMaterial.TabIndex = 0;
        this.TreatmentMaterial.Text = i18n("M21320", "Sarf Giriş");
        this.TreatmentMaterial.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.TreatmentMaterial.Name = 'TreatmentMaterial';

        this.TreatmentMaterials = new TTVisual.TTGrid();
        this.TreatmentMaterials.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.TreatmentMaterials.Name = 'TreatmentMaterials';
        this.TreatmentMaterials.TabIndex = 46;

        this.ActionDate = new TTVisual.TTDateTimePickerColumn();
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.ActionDate.DataMember = 'ActionDate';
        this.ActionDate.DisplayIndex = 0;
        this.ActionDate.HeaderText = 'Tarih/Saat';
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = 'ConsumableMaterialAndDrugList';
        this.Material.DataMember = 'Material';
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = 'Material';
        this.Material.Width = 325;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Barcode';
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkodu';
        this.Barcode.Name = 'Barcode';
        this.Barcode.Width = 100;

        this.MaterialAmount = new TTVisual.TTTextBoxColumn();
        this.MaterialAmount.DataMember = 'Amount';
        this.MaterialAmount.DisplayIndex = 3;
        this.MaterialAmount.HeaderText = i18n("M19030", "Miktar");
        this.MaterialAmount.Name = 'MaterialAmount';
        this.MaterialAmount.Width = 75;

        this.UBBCODE = new TTVisual.TTTextBoxColumn();
        this.UBBCODE.DataMember = 'UBBCode';
        this.UBBCODE.DisplayIndex = 4;
        this.UBBCODE.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCODE.Name = 'UBBCODE';
        this.UBBCODE.Width = 100;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = 'Note';
        this.Note.DisplayIndex = 5;
        this.Note.HeaderText = i18n("M19485", "Notlar");
        this.Note.Name = 'Note';
        this.Note.Width = 210;

        this.KodsuzMalzemeFiyati = new TTVisual.TTTextBoxColumn();
        this.KodsuzMalzemeFiyati.DataMember = 'KodsuzMalzemeFiyati';
        this.KodsuzMalzemeFiyati.DisplayIndex = 6;
        this.KodsuzMalzemeFiyati.HeaderText = i18n("M17688", "Kodsuz Malzeme Fiyatı");
        this.KodsuzMalzemeFiyati.Name = 'KodsuzMalzemeFiyati';
        this.KodsuzMalzemeFiyati.ReadOnly = true;
        this.KodsuzMalzemeFiyati.Visible = false;
        this.KodsuzMalzemeFiyati.Width = 100;

        this.Kdv = new TTVisual.TTTextBoxColumn();
        this.Kdv.DataMember = 'Kdv';
        this.Kdv.DisplayIndex = 7;
        this.Kdv.HeaderText = 'Kdv';
        this.Kdv.Name = 'Kdv';
        this.Kdv.ReadOnly = true;
        this.Kdv.Visible = false;
        this.Kdv.Width = 100;

        this.MalzemeBrans = new TTVisual.TTTextBoxColumn();
        this.MalzemeBrans.DataMember = 'MalzemeBrans';
        this.MalzemeBrans.DisplayIndex = 8;
        this.MalzemeBrans.HeaderText = i18n("M18556", "Malzeme Branş");
        this.MalzemeBrans.Name = 'MalzemeBrans';
        this.MalzemeBrans.ReadOnly = true;
        this.MalzemeBrans.Visible = false;
        this.MalzemeBrans.Width = 100;

        this.MalzemeSAtinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MalzemeSAtinAlisTarihi.DataMember = 'MalzemeSatinAlisTarihi';
        this.MalzemeSAtinAlisTarihi.DisplayIndex = 9;
        this.MalzemeSAtinAlisTarihi.HeaderText = i18n("M18604", "Malzeme Satın Alış Tarihi ");
        this.MalzemeSAtinAlisTarihi.Name = 'MalzemeSAtinAlisTarihi';
        this.MalzemeSAtinAlisTarihi.ReadOnly = true;
        this.MalzemeSAtinAlisTarihi.Visible = false;
        this.MalzemeSAtinAlisTarihi.Width = 100;

        this.MalzemeTuru = new TTVisual.TTListBoxColumn();
        this.MalzemeTuru.ListDefName = 'MalzemeTuruListDefinition';
        this.MalzemeTuru.DataMember = 'MalzemeTuru';
        this.MalzemeTuru.DisplayIndex = 10;
        this.MalzemeTuru.HeaderText = i18n("M18614", "Malzeme Türü");
        this.MalzemeTuru.Name = 'MalzemeTuru';
        this.MalzemeTuru.Visible = false;
        this.MalzemeTuru.Width = 100;

        this.MalzemeBilgisi_OzelDurum = new TTVisual.TTListBoxColumn();
        this.MalzemeBilgisi_OzelDurum.ListDefName = 'OzelDurumListDefinition';
        this.MalzemeBilgisi_OzelDurum.DataMember = 'OzelDurum';
        this.MalzemeBilgisi_OzelDurum.DisplayIndex = 11;
        this.MalzemeBilgisi_OzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.MalzemeBilgisi_OzelDurum.Name = 'MalzemeBilgisi_OzelDurum';
        this.MalzemeBilgisi_OzelDurum.Visible = false;
        this.MalzemeBilgisi_OzelDurum.Width = 100;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 1;
        this.tttabpage1.TabIndex = 1;
        this.tttabpage1.Text = i18n("M12758", "Dış Labarotuar");
        this.tttabpage1.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.tttabpage1.Name = 'tttabpage1';

        this.TTListBoxExternalLab = new TTVisual.TTObjectListBox();
        this.TTListBoxExternalLab.ListDefName = 'ToothProthesisLabListDefinition';
        this.TTListBoxExternalLab.Name = 'TTListBoxExternalLab';
        this.TTListBoxExternalLab.TabIndex = 73;
        this.TTListBoxExternalLab.DataMember = 'selectedToothProthesisLab';

        this.ttbutton2 = new TTVisual.TTButton();
        this.ttbutton2.Text = i18n("M21557", "Seçili İşlemlere Dış Lab. İsteği Yap");
        this.ttbutton2.Name = 'ttbutton2';
        this.ttbutton2.TabIndex = 74;

        this.labelDoctor = new TTVisual.TTLabel();
        this.labelDoctor.Text = i18n("M22534", "Tabip Adı");
        this.labelDoctor.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelDoctor.ForeColor = '#000000';
        this.labelDoctor.Name = 'labelDoctor';
        this.labelDoctor.TabIndex = 32;

        this.Doctor = new TTVisual.TTObjectListBox();
        this.Doctor.ListDefName = 'DoctorListDefinition';
        this.Doctor.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Doctor.Name = 'Doctor';
        this.Doctor.TabIndex = 31;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = 'Tarih';
        this.ttlabel1.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel1.ForeColor = '#000000';
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 1;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M23123", "Teknisyenler");
        this.ttlabel2.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel2.ForeColor = '#000000';
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 62;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M23118", "Teknisyen tipine göre filtrele");
        this.ttlabel3.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel3.ForeColor = '#000000';
        this.ttlabel3.Name = 'ttlabel3';
        this.ttlabel3.TabIndex = 62;

        this.gridTechnicianColumns = [this.chose, this.Ad, this.TECHNICIANTYPE, this.TotalWorksNum, this.CurrentWorksNum, this.TechnicianObjectId];
        this.gridProceduresColumns = [this.ttcheckboxcolumn1, this.date, this.ProsProc, this.DisNo, this.TECHNICIAN, this.Durum, this.color, this.Description, this.TechnicianNote, this.ExternalLab];
        this.TreatmentMaterialsColumns = [this.ActionDate, this.Material, this.Barcode, this.MaterialAmount, this.UBBCODE, this.Note,
        this.KodsuzMalzemeFiyati, this.Kdv, this.MalzemeBrans, this.MalzemeSAtinAlisTarihi, this.MalzemeTuru, this.MalzemeBilgisi_OzelDurum];
        this.SubactionTab.Controls = [this.TreatmentMaterial, this.tttabpage1];
        this.TreatmentMaterial.Controls = [this.TreatmentMaterials];
        this.tttabpage1.Controls = [this.TTListBoxExternalLab, this.ttbutton2];
        this.Controls = [this.ttcheckbox1, this.enumTechType, this.gridTechnician, this.chose, this.Ad, this.TECHNICIANTYPE, this.TotalWorksNum,
        this.CurrentWorksNum, this.TechnicianObjectId, this.ttbutton1, this.gridProcedures, this.ttcheckboxcolumn1, this.date, this.ProsProc,
        this.DisNo, this.TECHNICIAN, this.Durum, this.color, this.Description, this.TechnicianNote, this.ExternalLab, this.LabelRequestDate, this.RequestDate, this.SubactionTab,
        this.TreatmentMaterial, this.TreatmentMaterials, this.ActionDate, this.Material, this.Barcode, this.MaterialAmount, this.UBBCODE,
        this.Note, this.KodsuzMalzemeFiyati, this.Kdv, this.MalzemeBrans, this.MalzemeSAtinAlisTarihi, this.MalzemeTuru, this.MalzemeBilgisi_OzelDurum,
        this.tttabpage1, this.TTListBoxExternalLab, this.ttbutton2, this.labelDoctor, this.Doctor, this.ttlabel1, this.ttlabel2, this.ttlabel3];

    }


}
