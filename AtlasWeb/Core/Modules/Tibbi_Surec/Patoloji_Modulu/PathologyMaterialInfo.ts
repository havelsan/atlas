//$9E5F0C42
import { Component, Input  } from '@angular/core';
import { PathologyMaterialInfoViewModel, MaterialDefinitionsViewModel, vmRequestedPathologyProcedure } from './PathologyMaterialInfoViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PathologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyTestProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { SKRSICDOMORFOLOJIKODU } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICDOYERLESIMYERI } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlindigiDokununTemelOzelligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSNumuneAlinmaSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPatolojiPreparatiDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from "devextreme/data/data_source";

@Component({
    selector: 'PathologyMaterialInfo',
    templateUrl: './PathologyMaterialInfo.html',
    providers: [MessageService]
})
export class PathologyMaterialInfo extends TTVisual.TTForm {
    ActionDatePathologyTestProcedure: TTVisual.ITTDateTimePickerColumn;
    AlindigiDokununTemelOzelligi: TTVisual.ITTObjectListBox;
    AmountPathologyTestProcedure: TTVisual.ITTTextBoxColumn;
    Category: TTVisual.ITTListBoxColumn;
    ClinicalFindings: TTVisual.ITTTextBox;
    DateOfSampleTaken: TTVisual.ITTDateTimePicker;
    Description: TTVisual.ITTTextBox;
    Frozen: TTVisual.ITTCheckBox;
    labelAlindigiDokununTemelOzelligi: TTVisual.ITTLabel;
    labelClinicalFindings: TTVisual.ITTLabel;
    labelDateOfSampleTaken: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelMacroscopy: TTVisual.ITTLabel;
    labelMaterialNumber: TTVisual.ITTLabel;
    labelMicroscopy: TTVisual.ITTLabel;
    labelMorfolojiKodu: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    labelNumuneAlinmaSekli: TTVisual.ITTLabel;
    labelPathologicDiagnosis: TTVisual.ITTLabel;
    labelPatolojiPreparatiDurumu: TTVisual.ITTLabel;
    labelYerlesimYeri: TTVisual.ITTLabel;
    Macroscopy: TTVisual.ITTRichTextBoxControl;
    Malign: TTVisual.ITTCheckBox;
    MaterialNumber: TTVisual.ITTTextBox;
    Microscopy: TTVisual.ITTRichTextBoxControl;
    MorfolojiKodu: TTVisual.ITTObjectListBox;
    Note: TTVisual.ITTRichTextBoxControl;
    NumuneAlinmaSekli: TTVisual.ITTObjectListBox;
    PathologicDiagnosis: TTVisual.ITTRichTextBoxControl;
    PathologyTestProcedure: TTVisual.ITTGrid;
    PatolojiPreparatiDurumu: TTVisual.ITTObjectListBox;
    PerformedDatePathologyTestProcedure: TTVisual.ITTDateTimePickerColumn;
    ProcedureDoctorPathologyTestProcedure: TTVisual.ITTListBoxColumn;
    ProcedureObjectPathologyTestProcedure: TTVisual.ITTListBoxColumn;
    Benign: TTVisual.ITTCheckBox;
    SuspiciousMalign: TTVisual.ITTCheckBox;
    YerlesimYeri: TTVisual.ITTObjectListBox;
    public PathologyTestProcedureColumns = [];
    public pathologyMaterialInfoViewModel: PathologyMaterialInfoViewModel = new PathologyMaterialInfoViewModel();
    PathologyTestListColumns = [];
    pathologyTestDefinitionArray: Array<any> = [];
    pathologyTestDefinitionCache: any;
    RequestedPathologyProcedures: Array<vmRequestedPathologyProcedure> = new Array<vmRequestedPathologyProcedure>();
    PathologyProcedureList: TTVisual.ITTObjectListBox;
    _RequestedPathologyProcedureArray: Array < vmRequestedPathologyProcedure > = new Array<vmRequestedPathologyProcedure>();
    public _isReadOnly: boolean = false;

    @Input() set pathologyMaterial(value: PathologyMaterial) {

        let that = this;

        that._TTObject = value;
        that.pathologyMaterialInfoViewModel = new PathologyMaterialInfoViewModel();
        that.pathologyMaterialInfoViewModel._PathologyMaterial = value as PathologyMaterial;
        that._ViewModel = this.pathologyMaterialInfoViewModel;


        this.getDefinitionsViewModel();
        this.loadPathologyProcedures();
        //this.LoadMorfolojiDefinitions();
        //this.ObjectID = value.ObjectID;
    }

    @Input() set isReadOnly(value: boolean) {

        this.ReadOnly = value;
        this._isReadOnly = value;
    }

    public controlRoles : boolean;
    @Input() set hasRolePathologist(value: boolean) {
        this.controlRoles = value;
    }

    //@Output() sendPathologyProcedures: EventEmitter<vmRequestedPathologyProcedure> = new EventEmitter<vmRequestedPathologyProcedure>();

    private _requestedPathologyProcedureList: Array<vmRequestedPathologyProcedure>;
    @Input() set RequestedPathologyProcedureList(value: Array<vmRequestedPathologyProcedure>) {
        this._requestedPathologyProcedureList = value;

    }

    get RequestedPathologyProcedureList(): Array<vmRequestedPathologyProcedure> {
        return this._requestedPathologyProcedureList;
    }

    public get _PathologyMaterial(): PathologyMaterial {
        return this._TTObject as PathologyMaterial;
    }
    private PathologyMaterialInfo_DocumentUrl: string = '/api/PathologyMaterialService/PathologyMaterialInfo';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PATHOLOGYMATERIAL', 'PathologyMaterialInfo');
        this._DocumentServiceUrl = this.PathologyMaterialInfo_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        for (let i: number = 0; i < this._PathologyMaterial.PathologyTestProcedure.length; i++) {
            this._PathologyMaterial.PathologyTestProcedure[i].EpisodeAction = this._PathologyMaterial.Pathology;
        }
        this._PathologyMaterial.ObjectContext.Save();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PathologyMaterial();
        this.pathologyMaterialInfoViewModel = new PathologyMaterialInfoViewModel();
        this._ViewModel = this.pathologyMaterialInfoViewModel;
        this.pathologyMaterialInfoViewModel._PathologyMaterial = this._TTObject as PathologyMaterial;
        this.pathologyMaterialInfoViewModel._PathologyMaterial.YerlesimYeri = new SKRSICDOYERLESIMYERI();
        this.pathologyMaterialInfoViewModel._PathologyMaterial.PatolojiPreparatiDurumu = new SKRSPatolojiPreparatiDurumu();
        this.pathologyMaterialInfoViewModel._PathologyMaterial.NumuneAlinmaSekli = new SKRSNumuneAlinmaSekli();
        this.pathologyMaterialInfoViewModel._PathologyMaterial.MorfolojiKodu = new SKRSICDOMORFOLOJIKODU();
        this.pathologyMaterialInfoViewModel._PathologyMaterial.AlindigiDokununTemelOzelligi = new SKRSNumuneAlindigiDokununTemelOzelligi();
        this.pathologyMaterialInfoViewModel._PathologyMaterial.PathologyTestProcedure = new Array<PathologyTestProcedure>();
    }

    protected loadViewModel() {
        let that = this;

        that.pathologyMaterialInfoViewModel = this._ViewModel as PathologyMaterialInfoViewModel;
        that._TTObject = this.pathologyMaterialInfoViewModel._PathologyMaterial;
        if (this.pathologyMaterialInfoViewModel == null)
            this.pathologyMaterialInfoViewModel = new PathologyMaterialInfoViewModel();
        if (this.pathologyMaterialInfoViewModel._PathologyMaterial == null)
            this.pathologyMaterialInfoViewModel._PathologyMaterial = new PathologyMaterial();
        let yerlesimYeriObjectID = that.pathologyMaterialInfoViewModel._PathologyMaterial["YerlesimYeri"];
        if (yerlesimYeriObjectID != null && (typeof yerlesimYeriObjectID === 'string')) {
            let yerlesimYeri = that.pathologyMaterialInfoViewModel.SKRSICDOYERLESIMYERIs.find(o => o.ObjectID.toString() === yerlesimYeriObjectID.toString());
             if (yerlesimYeri) {
                that.pathologyMaterialInfoViewModel._PathologyMaterial.YerlesimYeri = yerlesimYeri;
            }
        }
        let patolojiPreparatiDurumuObjectID = that.pathologyMaterialInfoViewModel._PathologyMaterial["PatolojiPreparatiDurumu"];
        if (patolojiPreparatiDurumuObjectID != null && (typeof patolojiPreparatiDurumuObjectID === 'string')) {
            let patolojiPreparatiDurumu = that.pathologyMaterialInfoViewModel.SKRSPatolojiPreparatiDurumus.find(o => o.ObjectID.toString() === patolojiPreparatiDurumuObjectID.toString());
             if (patolojiPreparatiDurumu) {
                that.pathologyMaterialInfoViewModel._PathologyMaterial.PatolojiPreparatiDurumu = patolojiPreparatiDurumu;
            }
        }
        let numuneAlinmaSekliObjectID = that.pathologyMaterialInfoViewModel._PathologyMaterial["NumuneAlinmaSekli"];
        if (numuneAlinmaSekliObjectID != null && (typeof numuneAlinmaSekliObjectID === 'string')) {
            let numuneAlinmaSekli = that.pathologyMaterialInfoViewModel.SKRSNumuneAlinmaSeklis.find(o => o.ObjectID.toString() === numuneAlinmaSekliObjectID.toString());
             if (numuneAlinmaSekli) {
                that.pathologyMaterialInfoViewModel._PathologyMaterial.NumuneAlinmaSekli = numuneAlinmaSekli;
            }
        }
        let morfolojiKoduObjectID = that.pathologyMaterialInfoViewModel._PathologyMaterial["MorfolojiKodu"];
        if (morfolojiKoduObjectID != null && (typeof morfolojiKoduObjectID === 'string')) {
            let morfolojiKodu = that.pathologyMaterialInfoViewModel.SKRSICDOMORFOLOJIKODUs.find(o => o.ObjectID.toString() === morfolojiKoduObjectID.toString());
             if (morfolojiKodu) {
                that.pathologyMaterialInfoViewModel._PathologyMaterial.MorfolojiKodu = morfolojiKodu;
            }
        }
        let alindigiDokununTemelOzelligiObjectID = that.pathologyMaterialInfoViewModel._PathologyMaterial["AlindigiDokununTemelOzelligi"];
        if (alindigiDokununTemelOzelligiObjectID != null && (typeof alindigiDokununTemelOzelligiObjectID === 'string')) {
            let alindigiDokununTemelOzelligi = that.pathologyMaterialInfoViewModel.SKRSNumuneAlindigiDokununTemelOzelligis.find(o => o.ObjectID.toString() === alindigiDokununTemelOzelligiObjectID.toString());
             if (alindigiDokununTemelOzelligi) {
                that.pathologyMaterialInfoViewModel._PathologyMaterial.AlindigiDokununTemelOzelligi = alindigiDokununTemelOzelligi;
            }
        }
        that.pathologyMaterialInfoViewModel._PathologyMaterial.PathologyTestProcedure = that.pathologyMaterialInfoViewModel.PathologyTestProcedureGridList;
        for (let detailItem of that.pathologyMaterialInfoViewModel.PathologyTestProcedureGridList) {
            //let testCategoryObjectID = detailItem["TestCategory"];
            //if (testCategoryObjectID != null && (typeof testCategoryObjectID === 'string')) {
            //    let testCategory = that.pathologyMaterialInfoViewModel.PathologyTestCategoryDefinitions.find(o => o.ObjectID.toString() === testCategoryObjectID.toString());
            //    detailItem.TestCategory = testCategory;
            //}
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.pathologyMaterialInfoViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            //let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            //if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            //    let procedureDoctor = that.pathologyMaterialInfoViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            //    detailItem.ProcedureDoctor = procedureDoctor;
            //}
        }
    }
        

     //async ngOnInit() {
     //    alert();
     //}

    public onAlindigiDokununTemelOzelligiChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.AlindigiDokununTemelOzelligi != event) {
                this._PathologyMaterial.AlindigiDokununTemelOzelligi = event;
            }
        }
    }

    public onClinicalFindingsChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.ClinicalFindings != event) {
                this._PathologyMaterial.ClinicalFindings = event;
            }
        }
    }
    public onBenignChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.Benign != event) {
                this._PathologyMaterial.Benign = event;
            }
        }
    }
    public onSuspiciousMalignChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.SuspiciousMalign != event) {
                this._PathologyMaterial.SuspiciousMalign = event;
            }
        }
    }

    public onDateOfSampleTakenChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.DateOfSampleTaken != event) {
                this._PathologyMaterial.DateOfSampleTaken = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.Description != event) {
                this._PathologyMaterial.Description = event;
            }
        }
    }

    public onFrozenChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.Frozen != event) {
                this._PathologyMaterial.Frozen = event;
            }
        }
    }

    public onMacroscopyChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.Macroscopy != event) {
                this._PathologyMaterial.Macroscopy = event;
            }
        }
    }

    public onMalignChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.Malign != event) {
                this._PathologyMaterial.Malign = event;
            }
        }
    }

    public onMaterialNumberChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.MaterialNumber != event) {
                this._PathologyMaterial.MaterialNumber = event;
            }
        }
    }

    public onMicroscopyChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.Microscopy != event) {
                this._PathologyMaterial.Microscopy = event;
            }
        }
    }

    public onMorfolojiKoduChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.MorfolojiKodu != event) {
                this._PathologyMaterial.MorfolojiKodu = event;
            }
        }
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.Note != event) {
                this._PathologyMaterial.Note = event;
            }
        }
    }

    public onNumuneAlinmaSekliChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.NumuneAlinmaSekli != event) {
                this._PathologyMaterial.NumuneAlinmaSekli = event;
            }
        }
    }

    public onPathologicDiagnosisChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.PathologicDiagnosis != event) {
                this._PathologyMaterial.PathologicDiagnosis = event;
            }
        }
    }

    public onPatolojiPreparatiDurumuChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.PatolojiPreparatiDurumu != event) {
                this._PathologyMaterial.PatolojiPreparatiDurumu = event;
            }
        }
    }

    public onYerlesimYeriChanged(event): void {
        if (event != null) {
            if (this._PathologyMaterial != null && this._PathologyMaterial.YerlesimYeri != event) {
                this._PathologyMaterial.YerlesimYeri = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ClinicalFindings, "Text", this.__ttObject, "ClinicalFindings");
        redirectProperty(this.DateOfSampleTaken, "Value", this.__ttObject, "DateOfSampleTaken");
        redirectProperty(this.MaterialNumber, "Text", this.__ttObject, "MaterialNumber");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.Macroscopy, "Rtf", this.__ttObject, "Macroscopy");
        redirectProperty(this.Note, "Rtf", this.__ttObject, "Note");
        redirectProperty(this.Microscopy, "Rtf", this.__ttObject, "Microscopy");
        redirectProperty(this.PathologicDiagnosis, "Rtf", this.__ttObject, "PathologicDiagnosis");
        redirectProperty(this.Frozen, "Value", this.__ttObject, "Frozen");
        redirectProperty(this.Malign, "Value", this.__ttObject, "Malign");
        redirectProperty(this.Benign, "Value", this.__ttObject, "Benign");
        redirectProperty(this.SuspiciousMalign, "Value", this.__ttObject, "SuspiciousMalign");

    }

    public initFormControls(): void {
        this.Malign = new TTVisual.TTCheckBox();
        this.Malign.Value = false;
        this.Malign.Title = "Malign";
        this.Malign.Name = "Malign";
        this.Malign.TabIndex = 28;

        this.SuspiciousMalign = new TTVisual.TTCheckBox();
        this.SuspiciousMalign.Value = false;
        this.SuspiciousMalign.Title = "Şüpheli Malign";
        this.SuspiciousMalign.Name = "SuspiciousMalign";
        this.SuspiciousMalign.TabIndex = 30;

        this.Benign = new TTVisual.TTCheckBox();
        this.Benign.Value = false;
        this.Benign.Title = "Benign";
        this.Benign.Name = "Benign";
        this.Benign.TabIndex = 29;

        this.Frozen = new TTVisual.TTCheckBox();
        this.Frozen.Value = false;
        this.Frozen.Title = "Frozen";
        this.Frozen.Name = "Frozen";
        this.Frozen.TabIndex = 27;


        this.labelPathologicDiagnosis = new TTVisual.TTLabel();
        this.labelPathologicDiagnosis.Text = i18n("M22736", "Tanı");
        this.labelPathologicDiagnosis.Name = "labelPathologicDiagnosis";
        this.labelPathologicDiagnosis.TabIndex = 26;

        this.PathologicDiagnosis = new TTVisual.TTRichTextBoxControl();
        this.PathologicDiagnosis.Name = "PathologicDiagnosis";
        this.PathologicDiagnosis.TabIndex = 25;

        this.labelYerlesimYeri = new TTVisual.TTLabel();
        this.labelYerlesimYeri.Text = i18n("M10716", "Alındığı Organ");
        this.labelYerlesimYeri.Name = "labelYerlesimYeri";
        this.labelYerlesimYeri.TabIndex = 24;

        this.YerlesimYeri = new TTVisual.TTObjectListBox();
        this.YerlesimYeri.Enabled = false;
        this.YerlesimYeri.ListDefName = "SKRSICDOYERLESIMYERIList";
        this.YerlesimYeri.Name = "YerlesimYeri";
        this.YerlesimYeri.TabIndex = 23;

        this.labelPatolojiPreparatiDurumu = new TTVisual.TTLabel();
        this.labelPatolojiPreparatiDurumu.Text = i18n("M20472", "Preparatın Durumu");
        this.labelPatolojiPreparatiDurumu.Name = "labelPatolojiPreparatiDurumu";
        this.labelPatolojiPreparatiDurumu.TabIndex = 22;

        this.PatolojiPreparatiDurumu = new TTVisual.TTObjectListBox();
        this.PatolojiPreparatiDurumu.ListDefName = "SKRSPatolojiPreparatiDurumuList";
        this.PatolojiPreparatiDurumu.Name = "PatolojiPreparatiDurumu";
        this.PatolojiPreparatiDurumu.TabIndex = 21;
        this.PatolojiPreparatiDurumu.AutoCompleteDialogHeight = "200px";

        this.labelNumuneAlinmaSekli = new TTVisual.TTLabel();
        this.labelNumuneAlinmaSekli.Text = i18n("M19536", "Numune Alınma Şekli");
        this.labelNumuneAlinmaSekli.Name = "labelNumuneAlinmaSekli";
        this.labelNumuneAlinmaSekli.TabIndex = 20;

        this.NumuneAlinmaSekli = new TTVisual.TTObjectListBox();
        this.NumuneAlinmaSekli.Enabled = false;
        this.NumuneAlinmaSekli.ListDefName = "SKRSNumuneAlinmaSekliList";
        this.NumuneAlinmaSekli.Name = "NumuneAlinmaSekli";
        this.NumuneAlinmaSekli.TabIndex = 19;

        this.labelMorfolojiKodu = new TTVisual.TTLabel();
        this.labelMorfolojiKodu.Text = i18n("M19123", "Morfoloji Kodu");
        this.labelMorfolojiKodu.Name = "labelMorfolojiKodu";
        this.labelMorfolojiKodu.TabIndex = 18;

        this.MorfolojiKodu = new TTVisual.TTObjectListBox();
        this.MorfolojiKodu.ListDefName = "SKRSICDOMORFOLOJIKODUList";
        this.MorfolojiKodu.Name = "MorfolojiKodu";
        this.MorfolojiKodu.TabIndex = 17;
        this.MorfolojiKodu.AutoCompleteDialogHeight = "200px";

        this.labelAlindigiDokununTemelOzelligi = new TTVisual.TTLabel();
        this.labelAlindigiDokununTemelOzelligi.Text = i18n("M10715", "Alındığı Dokunun Temel Özelliği");
        this.labelAlindigiDokununTemelOzelligi.Name = "labelAlindigiDokununTemelOzelligi";
        this.labelAlindigiDokununTemelOzelligi.TabIndex = 16;

        this.AlindigiDokununTemelOzelligi = new TTVisual.TTObjectListBox();
        this.AlindigiDokununTemelOzelligi.Enabled = false;
        this.AlindigiDokununTemelOzelligi.ListDefName = "SKRSNumuneAlindigiDokununTemelOzelligiList";
        this.AlindigiDokununTemelOzelligi.Name = "AlindigiDokununTemelOzelligi";
        this.AlindigiDokununTemelOzelligi.TabIndex = 15;

        this.PathologyTestProcedure = new TTVisual.TTGrid();
        this.PathologyTestProcedure.Name = "PathologyTestProcedure";
        this.PathologyTestProcedure.TabIndex = 14;

        this.Category = new TTVisual.TTListBoxColumn();
        this.Category.ListDefName = "PathologyTestCategoryList";
        this.Category.DataMember = "TestCategory";
        this.Category.DisplayIndex = 0;
        this.Category.HeaderText = i18n("M17350", "Kategori");
        this.Category.Name = "Category";
        this.Category.Width = 100;

        this.ProcedureObjectPathologyTestProcedure = new TTVisual.TTListBoxColumn();
        this.ProcedureObjectPathologyTestProcedure.ListDefName = "PathologyTestListDefinition";
        this.ProcedureObjectPathologyTestProcedure.DataMember = "ProcedureObject";
        this.ProcedureObjectPathologyTestProcedure.DisplayIndex = 1;
        this.ProcedureObjectPathologyTestProcedure.HeaderText = i18n("M16818", "İşlem");
        this.ProcedureObjectPathologyTestProcedure.Name = "ProcedureObjectPathologyTestProcedure";
        this.ProcedureObjectPathologyTestProcedure.Width = "50%";
        this.ProcedureObjectPathologyTestProcedure.AutoCompleteDialogHeight = "200px";

        this.ProcedureDoctorPathologyTestProcedure = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorPathologyTestProcedure.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctorPathologyTestProcedure.DataMember = "ProcedureDoctor";
        this.ProcedureDoctorPathologyTestProcedure.DisplayIndex = 2;
        this.ProcedureDoctorPathologyTestProcedure.HeaderText = i18n("M16928", "İşlemi Yapan Doktor");
        this.ProcedureDoctorPathologyTestProcedure.Name = "ProcedureDoctorPathologyTestProcedure";
        this.ProcedureDoctorPathologyTestProcedure.Width = 150;

        this.AmountPathologyTestProcedure = new TTVisual.TTTextBoxColumn();
        this.AmountPathologyTestProcedure.DataMember = "Amount";
        this.AmountPathologyTestProcedure.DisplayIndex = 3;
        this.AmountPathologyTestProcedure.HeaderText = i18n("M19030", "Miktar");
        this.AmountPathologyTestProcedure.Name = "AmountPathologyTestProcedure";
        this.AmountPathologyTestProcedure.Width = "20%";

        this.ActionDatePathologyTestProcedure = new TTVisual.TTDateTimePickerColumn();
        this.ActionDatePathologyTestProcedure.DataMember = "ActionDate";
        this.ActionDatePathologyTestProcedure.DisplayIndex = 4;
        this.ActionDatePathologyTestProcedure.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.ActionDatePathologyTestProcedure.Name = "ActionDatePathologyTestProcedure";
        this.ActionDatePathologyTestProcedure.Width = 180;

        this.PerformedDatePathologyTestProcedure = new TTVisual.TTDateTimePickerColumn();
        this.PerformedDatePathologyTestProcedure.DataMember = "PerformedDate";
        this.PerformedDatePathologyTestProcedure.DisplayIndex = 5;
        this.PerformedDatePathologyTestProcedure.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.PerformedDatePathologyTestProcedure.Name = "PerformedDatePathologyTestProcedure";
        this.PerformedDatePathologyTestProcedure.Width = "20%";

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = "Not/Yorum";
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 13;

        this.Note = new TTVisual.TTRichTextBoxControl();
        this.Note.Name = "Note";
        this.Note.TabIndex = 12;

        this.labelMicroscopy = new TTVisual.TTLabel();
        this.labelMicroscopy.Text = i18n("M19027", "Mikroskopi");
        this.labelMicroscopy.Name = "labelMicroscopy";
        this.labelMicroscopy.TabIndex = 11;

        this.Microscopy = new TTVisual.TTRichTextBoxControl();
        this.Microscopy.Name = "Microscopy";
        this.Microscopy.TabIndex = 10;
        this.Microscopy.TemplateGroupName = "Mikroskopi Şablon";

        this.labelMacroscopy = new TTVisual.TTLabel();
        this.labelMacroscopy.Text = i18n("M18492", "Makroskopi");
        this.labelMacroscopy.Name = "labelMacroscopy";
        this.labelMacroscopy.TabIndex = 9;

        this.Macroscopy = new TTVisual.TTRichTextBoxControl();
        this.Macroscopy.Required = true;
        this.Macroscopy.BackColor = "#FFE3C6";
        this.Macroscopy.Name = "Macroscopy";
        this.Macroscopy.TabIndex = 8;
        this.Macroscopy.TemplateGroupName = "Makroskopi Şablon";


        this.labelDateOfSampleTaken = new TTVisual.TTLabel();
        this.labelDateOfSampleTaken.Text = i18n("M19537", "Numune Alınma Tarihi");
        this.labelDateOfSampleTaken.Name = "labelDateOfSampleTaken";
        this.labelDateOfSampleTaken.TabIndex = 7;

        this.DateOfSampleTaken = new TTVisual.TTDateTimePicker();
        this.DateOfSampleTaken.BackColor = "#F0F0F0";
        this.DateOfSampleTaken.CustomFormat = "dd/MM/yyyy HH:mm";
        this.DateOfSampleTaken.Format = DateTimePickerFormat.Long;
        this.DateOfSampleTaken.Enabled = false;
        this.DateOfSampleTaken.Name = "DateOfSampleTaken";
        this.DateOfSampleTaken.TabIndex = 6;

        this.labelMaterialNumber = new TTVisual.TTLabel();
        this.labelMaterialNumber.Text = i18n("M18700", "Materyal Numarası");
        this.labelMaterialNumber.Name = "labelMaterialNumber";
        this.labelMaterialNumber.TabIndex = 5;

        this.MaterialNumber = new TTVisual.TTTextBox();
        this.MaterialNumber.BackColor = "#F0F0F0";
        this.MaterialNumber.Enabled = false;
        this.MaterialNumber.Name = "MaterialNumber";
        this.MaterialNumber.TabIndex = 4;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.BackColor = "#F0F0F0";
        this.Description.Enabled = false;
        this.Description.Name = "Description";
        this.Description.TabIndex = 2;
        this.Description.Height = "105px";

        this.ClinicalFindings = new TTVisual.TTTextBox();
        this.ClinicalFindings.Multiline = true;
        this.ClinicalFindings.BackColor = "#F0F0F0";
        this.ClinicalFindings.Enabled = false;
        this.ClinicalFindings.Name = "ClinicalFindings";
        this.ClinicalFindings.TabIndex = 0;
        this.ClinicalFindings.Height = "105px";


        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 3;

        this.labelClinicalFindings = new TTVisual.TTLabel();
        this.labelClinicalFindings.Text = i18n("M17626", "Klinik Bulgular");
        this.labelClinicalFindings.Name = "labelClinicalFindings";
        this.labelClinicalFindings.TabIndex = 1;

        this.PathologyProcedureList = new TTVisual.TTObjectListBox();
        this.PathologyProcedureList.ListDefName = "PathologyTestListDefinition";
        this.PathologyProcedureList.Name = "PathologyTestList";
        this.PathologyProcedureList.AutoCompleteDialogHeight = "200px";
        this.PathologyProcedureList.ReadOnly = this.ReadOnly;


        this.PathologyTestProcedureColumns = [ this.ProcedureObjectPathologyTestProcedure, this.AmountPathologyTestProcedure,  this.PerformedDatePathologyTestProcedure];
        this.Controls = [this.SuspiciousMalign, this.Benign,this.Malign, this.Frozen, this.labelPathologicDiagnosis, this.PathologicDiagnosis, this.labelYerlesimYeri, this.YerlesimYeri, this.labelPatolojiPreparatiDurumu, this.PatolojiPreparatiDurumu, this.labelNumuneAlinmaSekli, this.NumuneAlinmaSekli, this.labelMorfolojiKodu, this.MorfolojiKodu, this.labelAlindigiDokununTemelOzelligi, this.AlindigiDokununTemelOzelligi, this.PathologyTestProcedure, this.Category, this.ProcedureObjectPathologyTestProcedure, this.ProcedureDoctorPathologyTestProcedure, this.AmountPathologyTestProcedure, this.ActionDatePathologyTestProcedure, this.PerformedDatePathologyTestProcedure, this.labelNote, this.Note, this.labelMicroscopy, this.Microscopy, this.labelMacroscopy, this.Macroscopy, this.labelDateOfSampleTaken, this.DateOfSampleTaken, this.labelMaterialNumber, this.MaterialNumber, this.Description, this.ClinicalFindings, this.labelDescription, this.labelClinicalFindings];

    }



    protected getDefinitionsViewModel() {

        let that = this;
        let apiUrl: string = '/api/PathologyMaterialService/GetDefinitions';

        that.httpService.get<any>(apiUrl)
            .then(response => {
                let result = response as MaterialDefinitionsViewModel;

                that.pathologyMaterialInfoViewModel.ProcedureDefinitions = result.ProcedureDefinitions;

                that.pathologyMaterialInfoViewModel._PathologyMaterial.PathologyTestProcedure = that.pathologyMaterialInfoViewModel.PathologyTestProcedureGridList;
                for (let detailItem of that.pathologyMaterialInfoViewModel.PathologyTestProcedureGridList) {

                    let procedureObjectObjectID = detailItem["ProcedureObject"];
                    if (procedureObjectObjectID != null) {
                        let procedureObject = that.pathologyMaterialInfoViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                        detailItem.ProcedureObject = procedureObject;
                    }

                }

            })
            .catch(error => {
                console.log(error);
            });

    }

    public PathologyProcedureListColumns = [
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "ProcedureCode",
            width: 100,
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "ProcedureName",
            width: '100%',
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M10505", "Adet"),
            dataField: "Amount",
            width: 60,
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M23606", "Tutar"),
            dataField: "UnitPrice",
            width: 80,
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16696", "İstem Yapan"),
            dataField: "RequestBy",
            width: 180,
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16695", "İstem Uygulayan"),
            dataField: "ProcedureUser",
            width: 180,
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 150,
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowSorting: false,
            allowEditing: false
        },
        {
            "caption": i18n("M16715", "İstenilen Birim"),
            dataField: "MasterResource",
            width: 180,
            allowSorting: false,
            allowEditing: false
        },
        //{
        //    "caption": "İşlem Durum",
        //    dataField: "ActionStatus",
        //    width: 100,
        //    allowSorting: true
        //},

    ];

    loadPathologyProcedures(): void {
        let that = this;
        let apiUrl: string = '/api/PathologyMaterialService/GetRequestedPathologyProcedures?materialObjectID=' + this.pathologyMaterialInfoViewModel._PathologyMaterial.ObjectID;

        that.httpService.get<any>(apiUrl)
            .then(response => {
                let result = response as Array<vmRequestedPathologyProcedure> ;
                //this.RequestedPathologyProcedureList = result;
                for (let i = 0; i < result.length; i++) {
                    this.RequestedPathologyProcedureList.push(result[i]);
                    this._RequestedPathologyProcedureArray.push(result[i]);
                }



            })
            .catch(error => {
                console.log(error);
            });
    }

    procedureSelected(data: any) {

        let that = this;
        let apiUrl: string = '/api/PathologyMaterialService/AddNewPathologyProcedure?ProcedureDefObjectId=' + data.ObjectID + "&EpisodeActionObjectId=" + that.pathologyMaterialInfoViewModel._PathologyMaterial.Pathology;

        that.httpService.get<any>(apiUrl)
            .then(response => {
                let result = response;
                let vmRequest: vmRequestedPathologyProcedure = new vmRequestedPathologyProcedure();
                vmRequest.ProcedureCode = result.ProcedureCode;
                vmRequest.ProcedureName = result.ProcedureName;
                vmRequest.RequestDate = result.RequestDate;
                vmRequest.RequestBy = result.RequestBy;
                vmRequest.ProcedureUser = result.ProcedureUser;
                vmRequest.MasterResource = result.MasterResource;
                vmRequest.Amount = result.Amount;
                vmRequest.UnitPrice = result.UnitPrice;
                vmRequest.MaterialObjectID = that.pathologyMaterialInfoViewModel._PathologyMaterial.ObjectID;
                vmRequest.ProcedureDefObjectID = result.ProcedureDefObjectID;
                that.RequestedPathologyProcedureList.push(vmRequest);
                that._RequestedPathologyProcedureArray.unshift(vmRequest);
                //this.sendPathologyProcedures.emit(vmRequest);

                this.pathologyMaterialInfoViewModel._selectedProcedureObject = null;

            })
            .catch(error => {
                console.log(error);
            });

    }


    onRowDeleted(data) {
        let that = this;
        if (data.data.SubActionProcedureObjectId != null && data.data.SubActionProcedureObjectId != undefined)  // kayıtlı istem
        {
            let apiUrl: string = '/api/PathologyMaterialService/DeletePathologyProcedure?SubActionProcedureObjectId=' + data.data.SubActionProcedureObjectId;

            that.httpService.get<any>(apiUrl)
                .then(response => {
                    let result = response;
                    if (result)
                        this.messageService.showInfo("İşlem Başarıyla Gerçekleştirildi.");
                    else
                        this.messageService.showError("Silme İşlemi Sırasında Hata Oluştu.");

                })
                .catch(error => {
                    console.log(error);
                });

        } else {

        }
    }
    public _MorfolojiArray: any;
    public async LoadMorfolojiDefinitions() {
        let filterString: string = '';

     
        this._MorfolojiArray = new DataSource({
            store: new CustomStore({
                key: "MORFOLOJIKOD",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SKRSICDOMORFOLOJIKODUList',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                },
                byKey: (key: any) => {
                    let loadOptions: any = new Object();
                    loadOptions.Params = {
                        searchText: key,
                        definitionName: 'SKRSICDOMORFOLOJIKODUList',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                }
            }),
            paginate: true,
            pageSize: 10
        });
    }
}
