//$5AD6531D
import { Component, OnInit, NgZone } from '@angular/core';
import { LaboratoryFormViewModel } from "./LaboratoryFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';

import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";



@Component({
    selector: 'LaboratoryForm',
    templateUrl: './LaboratoryForm.html',
    providers: [MessageService]
})
export class LaboratoryForm extends EpisodeActionForm implements OnInit {
    Barcode: TTVisual.ITTTextBoxColumn;
    BarcodeAmount: TTVisual.ITTTextBoxColumn;
    BarcodeOrderNo: TTVisual.ITTTextBoxColumn;
    BarcodeSelect: TTVisual.ITTCheckBoxColumn;
    dtActionDate: TTVisual.ITTDateTimePicker;
    labelPreInformation: TTVisual.ITTLabel;
    ProcedureNotes: TTVisual.ITTTextBoxColumn;
    Procedureobjid: TTVisual.ITTTextBoxColumn;
    ProcedureReferenceVal: TTVisual.ITTTextBoxColumn;
    ProcedureResult: TTVisual.ITTTextBoxColumn;
    ProcedureSelect: TTVisual.ITTCheckBoxColumn;
    ProcedureTestName: TTVisual.ITTTextBoxColumn;
    ProcedureUnit: TTVisual.ITTTextBoxColumn;
    SampleAcceptDepartment: TTVisual.ITTTextBoxColumn;
    SampleAcceptobjId: TTVisual.ITTTextBoxColumn;
    SampleAcceptSampleEnvir: TTVisual.ITTTextBoxColumn;
    SampleAcceptSampleTube: TTVisual.ITTTextBoxColumn;
    SampleAcceptSelect: TTVisual.ITTCheckBoxColumn;
    SampleAcceptTestName: TTVisual.ITTTextBoxColumn;
    SampleControlDepartment: TTVisual.ITTTextBoxColumn;
    SampleControlobjId: TTVisual.ITTTextBoxColumn;
    SampleControlSampleEnv: TTVisual.ITTTextBoxColumn;
    SampleControlSampleTube: TTVisual.ITTTextBoxColumn;
    SampleControlSelect: TTVisual.ITTCheckBoxColumn;
    SampleControlTestName: TTVisual.ITTTextBoxColumn;
    ttbApprove: TTVisual.ITTButton;
    ttbGetListProcedure: TTVisual.ITTButton;
    ttbGetListSamCont: TTVisual.ITTButton;
    ttbProcedure: TTVisual.ITTButton;
    ttbSampleControl: TTVisual.ITTButton;
    ttbSaveProcedure: TTVisual.ITTButton;
    ttgProcedure: TTVisual.ITTGrid;
    ttgrid1: TTVisual.ITTGrid;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgSampleAccept: TTVisual.ITTGrid;
    ttgSampleControl: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlistview1: TTVisual.ITTListView;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttpApprove: TTVisual.ITTTabPage;
    tttpComplete: TTVisual.ITTTabPage;
    tttpProcedure: TTVisual.ITTTabPage;
    tttpSampleAccept: TTVisual.ITTTabPage;
    tttpSampleControl: TTVisual.ITTTabPage;
    public ttgProcedureColumns = [];
    public ttgrid1Columns = [];
    public ttgSampleAcceptColumns = [];
    public ttgSampleControlColumns = [];
    public laboratoryFormViewModel: LaboratoryFormViewModel = new LaboratoryFormViewModel();
    public get _LaboratoryRequest(): LaboratoryRequest {
        return this._TTObject as LaboratoryRequest;
    }
    private LaboratoryForm_DocumentUrl: string = '/api/LaboratoryRequestService/LaboratoryForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.LaboratoryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async ttbGetListProcedure_Click(): Promise<void> {

    }
    public async ttbGetListSamCont_Click(): Promise<void> {

    }
    public async ttbProcedure_Click(): Promise<void> {

    }
    public async ttbSampleControl_Click(): Promise<void> {

    }
    public async ttbSaveProcedure_Click(): Promise<void> {

    }
    public async ttgProcedure_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {

    }
    public async ttgSampleAccept_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {

    }
    public async tttabcontrol1_SelectedTabChanged(): Promise<void> {

    }
    protected async PreScript() {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryRequest();
        this.laboratoryFormViewModel = new LaboratoryFormViewModel();
        this._ViewModel = this.laboratoryFormViewModel;
        this.laboratoryFormViewModel._LaboratoryRequest = this._TTObject as LaboratoryRequest;
        this.laboratoryFormViewModel._LaboratoryRequest.RequestDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.laboratoryFormViewModel = this._ViewModel as LaboratoryFormViewModel;
        that._TTObject = this.laboratoryFormViewModel._LaboratoryRequest;
        if (this.laboratoryFormViewModel == null)
            this.laboratoryFormViewModel = new LaboratoryFormViewModel();
        if (this.laboratoryFormViewModel._LaboratoryRequest == null)
            this.laboratoryFormViewModel._LaboratoryRequest = new LaboratoryRequest();
        let requestDoctorObjectID = that.laboratoryFormViewModel._LaboratoryRequest["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.laboratoryFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.laboratoryFormViewModel._LaboratoryRequest.RequestDoctor = requestDoctor;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(LaboratoryFormViewModel);
  
    }


    public ondtActionDateChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.ActionDate != event) {
                this._LaboratoryRequest.ActionDate = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.RequestDoctor != event) {
                this._LaboratoryRequest.RequestDoctor = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Prediagnosis != event) {
                this._LaboratoryRequest.Prediagnosis = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Notes != event) {
                this._LaboratoryRequest.Notes = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Prediagnosis");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Notes");
        redirectProperty(this.dtActionDate, "Value", this.__ttObject, "ActionDate");
    }

    public initFormControls(): void {
        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M11544", "Barkodlar:");
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 8;

        this.ttgrid1 = new TTVisual.TTGrid();
        this.ttgrid1.BackColor = "#DCDCDC";
        this.ttgrid1.Name = "ttgrid1";
        this.ttgrid1.TabIndex = 7;

        this.BarcodeOrderNo = new TTVisual.TTTextBoxColumn();
        this.BarcodeOrderNo.DisplayIndex = 0;
        this.BarcodeOrderNo.HeaderText = i18n("M21815", "Sıra No");
        this.BarcodeOrderNo.Name = "BarcodeOrderNo";
        this.BarcodeOrderNo.ReadOnly = true;
        this.BarcodeOrderNo.Width = 100;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.BarcodeAmount = new TTVisual.TTTextBoxColumn();
        this.BarcodeAmount.DisplayIndex = 2;
        this.BarcodeAmount.HeaderText = "Barkod Sayısı";
        this.BarcodeAmount.Name = "BarcodeAmount";
        this.BarcodeAmount.Width = 100;

        this.BarcodeSelect = new TTVisual.TTCheckBoxColumn();
        this.BarcodeSelect.DisplayIndex = 3;
        this.BarcodeSelect.HeaderText = i18n("M21507", "Seç");
        this.BarcodeSelect.Name = "BarcodeSelect";
        this.BarcodeSelect.Width = 100;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 6;

        this.tttpSampleAccept = new TTVisual.TTTabPage();
        this.tttpSampleAccept.DisplayIndex = 0;
        this.tttpSampleAccept.BackColor = "#FFFFFF";
        this.tttpSampleAccept.TabIndex = 0;
        this.tttpSampleAccept.Text = i18n("M20045", "Örnek Kabul");
        this.tttpSampleAccept.Name = "tttpSampleAccept";

        this.ttbSampleControl = new TTVisual.TTButton();
        this.ttbSampleControl.BackColor = "#FFFFFF";
        this.ttbSampleControl.Text = i18n("M20047", "Örnek Kontrol");
        this.ttbSampleControl.Name = "ttbSampleControl";
        this.ttbSampleControl.TabIndex = 5;

        this.ttgSampleAccept = new TTVisual.TTGrid();
        this.ttgSampleAccept.Name = "ttgSampleAccept";
        this.ttgSampleAccept.TabIndex = 4;

        this.SampleAcceptTestName = new TTVisual.TTTextBoxColumn();
        this.SampleAcceptTestName.DisplayIndex = 0;
        this.SampleAcceptTestName.HeaderText = i18n("M23259", "Test Adı");
        this.SampleAcceptTestName.Name = "SampleAcceptTestName";
        this.SampleAcceptTestName.ReadOnly = true;
        this.SampleAcceptTestName.Width = 200;

        this.SampleAcceptDepartment = new TTVisual.TTTextBoxColumn();
        this.SampleAcceptDepartment.DisplayIndex = 1;
        this.SampleAcceptDepartment.HeaderText = i18n("M12046", "Bölümü");
        this.SampleAcceptDepartment.Name = "SampleAcceptDepartment";
        this.SampleAcceptDepartment.Width = 200;

        this.SampleAcceptSampleEnvir = new TTVisual.TTTextBoxColumn();
        this.SampleAcceptSampleEnvir.DisplayIndex = 2;
        this.SampleAcceptSampleEnvir.HeaderText = i18n("M20057", "Örnek Ortamı");
        this.SampleAcceptSampleEnvir.Name = "SampleAcceptSampleEnvir";
        this.SampleAcceptSampleEnvir.ReadOnly = true;
        this.SampleAcceptSampleEnvir.Width = 100;

        this.SampleAcceptSampleTube = new TTVisual.TTTextBoxColumn();
        this.SampleAcceptSampleTube.DisplayIndex = 3;
        this.SampleAcceptSampleTube.HeaderText = i18n("M20068", "Örnek Tüpü");
        this.SampleAcceptSampleTube.Name = "SampleAcceptSampleTube";
        this.SampleAcceptSampleTube.ReadOnly = true;
        this.SampleAcceptSampleTube.Width = 100;

        this.SampleAcceptSelect = new TTVisual.TTCheckBoxColumn();
        this.SampleAcceptSelect.DisplayIndex = 4;
        this.SampleAcceptSelect.HeaderText = i18n("M21507", "Seç");
        this.SampleAcceptSelect.Name = "SampleAcceptSelect";
        this.SampleAcceptSelect.Width = 100;

        this.SampleAcceptobjId = new TTVisual.TTTextBoxColumn();
        this.SampleAcceptobjId.DisplayIndex = 5;
        this.SampleAcceptobjId.HeaderText = "objId";
        this.SampleAcceptobjId.Name = "SampleAcceptobjId";
        this.SampleAcceptobjId.ReadOnly = true;
        this.SampleAcceptobjId.Width = 100;

        this.tttpSampleControl = new TTVisual.TTTabPage();
        this.tttpSampleControl.DisplayIndex = 0;
        this.tttpSampleControl.BackColor = "#FFFFFF";
        this.tttpSampleControl.TabIndex = 1;
        this.tttpSampleControl.Text = i18n("M20047", "Örnek Kontrol");
        this.tttpSampleControl.Name = "tttpSampleControl";

        this.ttbProcedure = new TTVisual.TTButton();
        this.ttbProcedure.BackColor = "#FFFFFF";
        this.ttbProcedure.Text = i18n("M20548", "Prosedür");
        this.ttbProcedure.Name = "ttbProcedure";
        this.ttbProcedure.TabIndex = 2;

        this.ttbGetListSamCont = new TTVisual.TTButton();
        this.ttbGetListSamCont.BackColor = "#FFFFFF";
        this.ttbGetListSamCont.Text = "Get List";
        this.ttbGetListSamCont.Name = "ttbGetListSamCont";
        this.ttbGetListSamCont.TabIndex = 1;

        this.ttgSampleControl = new TTVisual.TTGrid();
        this.ttgSampleControl.Name = "ttgSampleControl";
        this.ttgSampleControl.TabIndex = 0;

        this.SampleControlTestName = new TTVisual.TTTextBoxColumn();
        this.SampleControlTestName.DisplayIndex = 0;
        this.SampleControlTestName.HeaderText = i18n("M23259", "Test Adı");
        this.SampleControlTestName.Name = "SampleControlTestName";
        this.SampleControlTestName.ReadOnly = true;
        this.SampleControlTestName.Width = 200;

        this.SampleControlDepartment = new TTVisual.TTTextBoxColumn();
        this.SampleControlDepartment.DisplayIndex = 1;
        this.SampleControlDepartment.HeaderText = i18n("M12046", "Bölümü");
        this.SampleControlDepartment.Name = "SampleControlDepartment";
        this.SampleControlDepartment.Width = 200;

        this.SampleControlSampleEnv = new TTVisual.TTTextBoxColumn();
        this.SampleControlSampleEnv.DisplayIndex = 2;
        this.SampleControlSampleEnv.HeaderText = i18n("M20057", "Örnek Ortamı");
        this.SampleControlSampleEnv.Name = "SampleControlSampleEnv";
        this.SampleControlSampleEnv.ReadOnly = true;
        this.SampleControlSampleEnv.Width = 100;

        this.SampleControlSampleTube = new TTVisual.TTTextBoxColumn();
        this.SampleControlSampleTube.DisplayIndex = 3;
        this.SampleControlSampleTube.HeaderText = i18n("M20068", "Örnek Tüpü");
        this.SampleControlSampleTube.Name = "SampleControlSampleTube";
        this.SampleControlSampleTube.ReadOnly = true;
        this.SampleControlSampleTube.Width = 100;

        this.SampleControlSelect = new TTVisual.TTCheckBoxColumn();
        this.SampleControlSelect.DisplayIndex = 4;
        this.SampleControlSelect.HeaderText = i18n("M21507", "Seç");
        this.SampleControlSelect.Name = "SampleControlSelect";
        this.SampleControlSelect.Width = 100;

        this.SampleControlobjId = new TTVisual.TTTextBoxColumn();
        this.SampleControlobjId.DisplayIndex = 5;
        this.SampleControlobjId.HeaderText = "Object ID";
        this.SampleControlobjId.Name = "SampleControlobjId";
        this.SampleControlobjId.ReadOnly = true;
        this.SampleControlobjId.Width = 100;

        this.tttpProcedure = new TTVisual.TTTabPage();
        this.tttpProcedure.DisplayIndex = 0;
        this.tttpProcedure.BackColor = "#FFFFFF";
        this.tttpProcedure.TabIndex = 2;
        this.tttpProcedure.Text = i18n("M20548", "Prosedür");
        this.tttpProcedure.Name = "tttpProcedure";

        this.ttbApprove = new TTVisual.TTButton();
        this.ttbApprove.BackColor = "#FFFFFF";
        this.ttbApprove.Text = i18n("M19673", "Onay");
        this.ttbApprove.Name = "ttbApprove";
        this.ttbApprove.TabIndex = 4;

        this.ttbSaveProcedure = new TTVisual.TTButton();
        this.ttbSaveProcedure.BackColor = "#FFFFFF";
        this.ttbSaveProcedure.Text = i18n("M17386", "Kaydet");
        this.ttbSaveProcedure.Name = "ttbSaveProcedure";
        this.ttbSaveProcedure.TabIndex = 3;

        this.ttbGetListProcedure = new TTVisual.TTButton();
        this.ttbGetListProcedure.BackColor = "#FFFFFF";
        this.ttbGetListProcedure.Text = "Get List";
        this.ttbGetListProcedure.Name = "ttbGetListProcedure";
        this.ttbGetListProcedure.TabIndex = 2;

        this.ttgProcedure = new TTVisual.TTGrid();
        this.ttgProcedure.Name = "ttgProcedure";
        this.ttgProcedure.TabIndex = 1;

        this.ProcedureTestName = new TTVisual.TTTextBoxColumn();
        this.ProcedureTestName.DisplayIndex = 0;
        this.ProcedureTestName.HeaderText = i18n("M23259", "Test Adı");
        this.ProcedureTestName.Name = "ProcedureTestName";
        this.ProcedureTestName.ReadOnly = true;
        this.ProcedureTestName.Width = 200;

        this.ProcedureResult = new TTVisual.TTTextBoxColumn();
        this.ProcedureResult.DisplayIndex = 1;
        this.ProcedureResult.HeaderText = i18n("M22078", "Sonuç");
        this.ProcedureResult.Name = "ProcedureResult";
        this.ProcedureResult.Width = 100;

        this.ProcedureUnit = new TTVisual.TTTextBoxColumn();
        this.ProcedureUnit.DisplayIndex = 2;
        this.ProcedureUnit.HeaderText = "Birim";
        this.ProcedureUnit.Name = "ProcedureUnit";
        this.ProcedureUnit.Width = 100;

        this.ProcedureReferenceVal = new TTVisual.TTTextBoxColumn();
        this.ProcedureReferenceVal.DisplayIndex = 3;
        this.ProcedureReferenceVal.HeaderText = i18n("M21013", "Referans Değerler");
        this.ProcedureReferenceVal.Name = "ProcedureReferenceVal";
        this.ProcedureReferenceVal.Width = 150;

        this.ProcedureNotes = new TTVisual.TTTextBoxColumn();
        this.ProcedureNotes.DisplayIndex = 4;
        this.ProcedureNotes.HeaderText = i18n("M22105", "Sonuç Notu");
        this.ProcedureNotes.Name = "ProcedureNotes";
        this.ProcedureNotes.Width = 100;

        this.ProcedureSelect = new TTVisual.TTCheckBoxColumn();
        this.ProcedureSelect.DisplayIndex = 5;
        this.ProcedureSelect.HeaderText = i18n("M21507", "Seç");
        this.ProcedureSelect.Name = "ProcedureSelect";
        this.ProcedureSelect.Width = 100;

        this.Procedureobjid = new TTVisual.TTTextBoxColumn();
        this.Procedureobjid.DisplayIndex = 6;
        this.Procedureobjid.HeaderText = "objId";
        this.Procedureobjid.Name = "Procedureobjid";
        this.Procedureobjid.ReadOnly = true;
        this.Procedureobjid.Width = 100;

        this.tttpApprove = new TTVisual.TTTabPage();
        this.tttpApprove.DisplayIndex = 0;
        this.tttpApprove.BackColor = "#FFFFFF";
        this.tttpApprove.TabIndex = 3;
        this.tttpApprove.Text = i18n("M19673", "Onay");
        this.tttpApprove.Name = "tttpApprove";

        this.tttpComplete = new TTVisual.TTTabPage();
        this.tttpComplete.DisplayIndex = 0;
        this.tttpComplete.BackColor = "#FFFFFF";
        this.tttpComplete.TabIndex = 4;
        this.tttpComplete.Text = i18n("M22704", "Tamam");
        this.tttpComplete.Name = "tttpComplete";

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#FFFFFF";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.ttlistview1 = new TTVisual.TTListView();
        this.ttlistview1.Name = "ttlistview1";
        this.ttlistview1.TabIndex = 49;

        this.dtActionDate = new TTVisual.TTDateTimePicker();
        this.dtActionDate.CustomFormat = "";
        this.dtActionDate.Format = DateTimePickerFormat.Long;
        this.dtActionDate.Name = "dtActionDate";
        this.dtActionDate.TabIndex = 1;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 43;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 44;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 47;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M16650", "İstek Tarihi");
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 43;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 46;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.labelPreInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 45;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M19476", "Not");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 48;

        this.ttgrid1Columns = [this.BarcodeOrderNo, this.Barcode, this.BarcodeAmount, this.BarcodeSelect];
        this.ttgSampleAcceptColumns = [this.SampleAcceptTestName, this.SampleAcceptDepartment, this.SampleAcceptSampleEnvir, this.SampleAcceptSampleTube, this.SampleAcceptSelect, this.SampleAcceptobjId];
        this.ttgSampleControlColumns = [this.SampleControlTestName, this.SampleControlDepartment, this.SampleControlSampleEnv, this.SampleControlSampleTube, this.SampleControlSelect, this.SampleControlobjId];
        this.ttgProcedureColumns = [this.ProcedureTestName, this.ProcedureResult, this.ProcedureUnit, this.ProcedureReferenceVal, this.ProcedureNotes, this.ProcedureSelect, this.Procedureobjid];
        this.tttabcontrol1.Controls = [this.tttpSampleAccept, this.tttpSampleControl, this.tttpProcedure, this.tttpApprove, this.tttpComplete];
        this.tttpSampleAccept.Controls = [this.ttbSampleControl, this.ttgSampleAccept];
        this.tttpSampleControl.Controls = [this.ttbProcedure, this.ttbGetListSamCont, this.ttgSampleControl];
        this.tttpProcedure.Controls = [this.ttbApprove, this.ttbSaveProcedure, this.ttbGetListProcedure, this.ttgProcedure];
        this.ttgroupbox1.Controls = [this.ttlistview1, this.dtActionDate, this.ttlabel2, this.ttobjectlistbox1, this.tttextbox2, this.ttlabel4, this.tttextbox1, this.labelPreInformation, this.ttlabel1];
        this.Controls = [this.ttlabel3, this.ttgrid1, this.BarcodeOrderNo, this.Barcode, this.BarcodeAmount, this.BarcodeSelect, this.tttabcontrol1, this.tttpSampleAccept, this.ttbSampleControl, this.ttgSampleAccept, this.SampleAcceptTestName, this.SampleAcceptDepartment, this.SampleAcceptSampleEnvir, this.SampleAcceptSampleTube, this.SampleAcceptSelect, this.SampleAcceptobjId, this.tttpSampleControl, this.ttbProcedure, this.ttbGetListSamCont, this.ttgSampleControl, this.SampleControlTestName, this.SampleControlDepartment, this.SampleControlSampleEnv, this.SampleControlSampleTube, this.SampleControlSelect, this.SampleControlobjId, this.tttpProcedure, this.ttbApprove, this.ttbSaveProcedure, this.ttbGetListProcedure, this.ttgProcedure, this.ProcedureTestName, this.ProcedureResult, this.ProcedureUnit, this.ProcedureReferenceVal, this.ProcedureNotes, this.ProcedureSelect, this.Procedureobjid, this.tttpApprove, this.tttpComplete, this.ttgroupbox1, this.ttlistview1, this.dtActionDate, this.ttlabel2, this.ttobjectlistbox1, this.tttextbox2, this.ttlabel4, this.tttextbox1, this.labelPreInformation, this.ttlabel1];

    }


}
