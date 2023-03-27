//$32BEC92A
import { Component, OnInit, NgZone } from '@angular/core';
import { LaboratoryProcedureFormViewModel } from './LaboratoryProcedureFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratorySubProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResLaboratoryDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResLaboratoryEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'LaboratoryProcedureForm',
    templateUrl: './LaboratoryProcedureForm.html',
    providers: [MessageService]
})
export class LaboratoryProcedureForm extends TTVisual.TTForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    Department: TTVisual.ITTValueListBox;
    Description: TTVisual.ITTTextBox;
    dtApproveDate: TTVisual.ITTDateTimePicker;
    dtRequestDate: TTVisual.ITTDateTimePicker;
    Equipment: TTVisual.ITTValueListBox;
    GridSubProcedures: TTVisual.ITTGrid;
    lblResult: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Materials: TTVisual.ITTGrid;
    objId: TTVisual.ITTTextBoxColumn;
    OwnerType: TTVisual.ITTTextBox;
    Reference: TTVisual.ITTTextBoxColumn;
    result: TTVisual.ITTTextBoxColumn;
    rtfReport: TTVisual.ITTRichTextBoxControl;
    SpecialReference: TTVisual.ITTRichTextBoxControlColumn;
    TestName: TTVisual.ITTListBoxColumn;
    TestTechnicianNote: TTVisual.ITTTextBox;
    tpGeneral: TTVisual.ITTTabPage;
    tpMaterial: TTVisual.ITTTabPage;
    tpTest: TTVisual.ITTTabPage;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextbox4: TTVisual.ITTTextBox;
    tttextbox5: TTVisual.ITTTextBox;
    txtProcessNote: TTVisual.ITTTextBox;
    unit: TTVisual.ITTTextBoxColumn;
    Warning: TTVisual.ITTEnumComboBoxColumn;
    public GridSubProceduresColumns = [];
    public MaterialsColumns = [];
    public laboratoryProcedureFormViewModel: LaboratoryProcedureFormViewModel = new LaboratoryProcedureFormViewModel();
    public get _LaboratoryProcedure(): LaboratoryProcedure {
        return this._TTObject as LaboratoryProcedure;
    }
    private LaboratoryProcedureForm_DocumentUrl: string = '/api/LaboratoryProcedureService/LaboratoryProcedureForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('LABORATORYPROCEDURE', 'LaboratoryProcedureForm');
        this._DocumentServiceUrl = this.LaboratoryProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryProcedure();
        this.laboratoryProcedureFormViewModel = new LaboratoryProcedureFormViewModel();
        this._ViewModel = this.laboratoryProcedureFormViewModel;
        this.laboratoryProcedureFormViewModel._LaboratoryProcedure = this._TTObject as LaboratoryProcedure;
        this.laboratoryProcedureFormViewModel._LaboratoryProcedure.LaboratorySubProcedures = new Array<LaboratorySubProcedure>();
        this.laboratoryProcedureFormViewModel._LaboratoryProcedure.ProcedureObject = new ProcedureDefinition();
        this.laboratoryProcedureFormViewModel._LaboratoryProcedure.Department = new ResLaboratoryDepartment();
        this.laboratoryProcedureFormViewModel._LaboratoryProcedure.Laboratory = new LaboratoryRequest();
        this.laboratoryProcedureFormViewModel._LaboratoryProcedure.Equipment = new ResLaboratoryEquipment();
        this.laboratoryProcedureFormViewModel._LaboratoryProcedure.Materials = new Array<LaboratoryMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.laboratoryProcedureFormViewModel = this._ViewModel as LaboratoryProcedureFormViewModel;
        that._TTObject = this.laboratoryProcedureFormViewModel._LaboratoryProcedure;
        if (this.laboratoryProcedureFormViewModel == null)
            this.laboratoryProcedureFormViewModel = new LaboratoryProcedureFormViewModel();
        if (this.laboratoryProcedureFormViewModel._LaboratoryProcedure == null)
            this.laboratoryProcedureFormViewModel._LaboratoryProcedure = new LaboratoryProcedure();
        that.laboratoryProcedureFormViewModel._LaboratoryProcedure.LaboratorySubProcedures = that.laboratoryProcedureFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.laboratoryProcedureFormViewModel.GridSubProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.laboratoryProcedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
        let procedureObjectObjectID = that.laboratoryProcedureFormViewModel._LaboratoryProcedure["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.laboratoryProcedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
             if (procedureObject) {
                that.laboratoryProcedureFormViewModel._LaboratoryProcedure.ProcedureObject = procedureObject;
            }
        }
        let departmentObjectID = that.laboratoryProcedureFormViewModel._LaboratoryProcedure["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
            let department = that.laboratoryProcedureFormViewModel.ResLaboratoryDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
             if (department) {
                that.laboratoryProcedureFormViewModel._LaboratoryProcedure.Department = department;
            }
        }
        let laboratoryObjectID = that.laboratoryProcedureFormViewModel._LaboratoryProcedure["Laboratory"];
        if (laboratoryObjectID != null && (typeof laboratoryObjectID === 'string')) {
            let laboratory = that.laboratoryProcedureFormViewModel.LaboratoryRequests.find(o => o.ObjectID.toString() === laboratoryObjectID.toString());
             if (laboratory) {
                that.laboratoryProcedureFormViewModel._LaboratoryProcedure.Laboratory = laboratory;
            }
        }
        let equipmentObjectID = that.laboratoryProcedureFormViewModel._LaboratoryProcedure["Equipment"];
        if (equipmentObjectID != null && (typeof equipmentObjectID === 'string')) {
            let equipment = that.laboratoryProcedureFormViewModel.ResLaboratoryEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
             if (equipment) {
                that.laboratoryProcedureFormViewModel._LaboratoryProcedure.Equipment = equipment;
            }
        }
        that.laboratoryProcedureFormViewModel._LaboratoryProcedure.Materials = that.laboratoryProcedureFormViewModel.MaterialsGridList;
        for (let detailItem of that.laboratoryProcedureFormViewModel.MaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.laboratoryProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(LaboratoryProcedureFormViewModel);
  
    }


    public onDepartmentChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.Department != event) {
                this._LaboratoryProcedure.Department = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.Description != event) {
                this._LaboratoryProcedure.Description = event;
            }
        }
    }

    public ondtApproveDateChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.ApproveDate != event) {
                this._LaboratoryProcedure.ApproveDate = event;
            }
        }
    }

    public ondtRequestDateChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.RequestDate != event) {
                this._LaboratoryProcedure.RequestDate = event;
            }
        }
    }

    public onEquipmentChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.Equipment != event) {
                this._LaboratoryProcedure.Equipment = event;
            }
        }
    }

    public onOwnerTypeChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.OwnerType != event) {
                this._LaboratoryProcedure.OwnerType = event;
            }
        }
    }

    public onrtfReportChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.LongReport != event) {
                this._LaboratoryProcedure.LongReport = event;
            }
        }
    }

    public onTestTechnicianNoteChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.Techniciannote != event) {
                this._LaboratoryProcedure.Techniciannote = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.ProcedureObject != event) {
                this._LaboratoryProcedure.ProcedureObject = event;
            }
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.SpecialReference != event) {
                this._LaboratoryProcedure.SpecialReference = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null &&
                this._LaboratoryProcedure.Laboratory != null && this._LaboratoryProcedure.Laboratory.Prediagnosis != event) {
                this._LaboratoryProcedure.Laboratory.Prediagnosis = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null &&
                this._LaboratoryProcedure.Laboratory != null && this._LaboratoryProcedure.Laboratory.Notes != event) {
                this._LaboratoryProcedure.Laboratory.Notes = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.Result != event) {
                this._LaboratoryProcedure.Result = event;
            }
        }
    }

    public ontttextbox4Changed(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.Unit != event) {
                this._LaboratoryProcedure.Unit = event;
            }
        }
    }

    public ontttextbox5Changed(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.Reference != event) {
                this._LaboratoryProcedure.Reference = event;
            }
        }
    }

    public ontxtProcessNoteChanged(event): void {
        if (event != null) {
            if (this._LaboratoryProcedure != null && this._LaboratoryProcedure.ProcessNote != event) {
                this._LaboratoryProcedure.ProcessNote = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "Result");
        redirectProperty(this.tttextbox4, "Text", this.__ttObject, "Unit");
        redirectProperty(this.tttextbox5, "Text", this.__ttObject, "Reference");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.rtfReport, "Rtf", this.__ttObject, "LongReport");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "SpecialReference");
        redirectProperty(this.TestTechnicianNote, "Text", this.__ttObject, "Techniciannote");
        redirectProperty(this.dtRequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.dtApproveDate, "Value", this.__ttObject, "ApproveDate");
        redirectProperty(this.txtProcessNote, "Text", this.__ttObject, "ProcessNote");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Laboratory.Prediagnosis");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Laboratory.Notes");
        redirectProperty(this.Department, "SelectedValue", this.__ttObject, "Department");
        redirectProperty(this.Equipment, "SelectedValue", this.__ttObject, "Equipment");
        redirectProperty(this.OwnerType, "Text", this.__ttObject, "OwnerType");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 0;

        this.tpTest = new TTVisual.TTTabPage();
        this.tpTest.DisplayIndex = 0;
        this.tpTest.BackColor = "#FFFFFF";
        this.tpTest.TabIndex = 0;
        this.tpTest.Text = i18n("M23303", "Tetkik Bilgileri");
        this.tpTest.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tpTest.Name = "tpTest";

        this.lblResult = new TTVisual.TTLabel();
        this.lblResult.Text = i18n("M22078", "Sonuç");
        this.lblResult.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblResult.Name = "lblResult";
        this.lblResult.TabIndex = 74;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 1;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M20103", "Özel Referans");
        this.ttlabel13.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 74;

        this.tttextbox5 = new TTVisual.TTTextBox();
        this.tttextbox5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox5.Name = "tttextbox5";
        this.tttextbox5.TabIndex = 3;

        this.tttextbox4 = new TTVisual.TTTextBox();
        this.tttextbox4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox4.Name = "tttextbox4";
        this.tttextbox4.TabIndex = 2;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M21008", "Referans");
        this.ttlabel11.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 74;

        this.dtApproveDate = new TTVisual.TTDateTimePicker();
        this.dtApproveDate.CustomFormat = "";
        this.dtApproveDate.Format = DateTimePickerFormat.Long;
        this.dtApproveDate.Name = "dtApproveDate";
        this.dtApproveDate.TabIndex = 10;

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 6;

        this.GridSubProcedures = new TTVisual.TTGrid();
        this.GridSubProcedures.AllowUserToDeleteRows = false;
        this.GridSubProcedures.BackColor = "#DCDCDC";
        this.GridSubProcedures.Name = "GridSubProcedures";
        this.GridSubProcedures.TabIndex = 12;

        this.TestName = new TTVisual.TTListBoxColumn();
        this.TestName.ListDefName = "LaboratoryTestListDefinition";
        this.TestName.ListFilterExpression = "o.Name";
        this.TestName.DataMember = "ProcedureObject";
        this.TestName.DisplayIndex = 0;
        this.TestName.HeaderText = i18n("M23259", "Test Adı");
        this.TestName.Name = "TestName";
        this.TestName.Width = 240;

        this.result = new TTVisual.TTTextBoxColumn();
        this.result.DataMember = "Result";
        this.result.DisplayIndex = 1;
        this.result.HeaderText = i18n("M22078", "Sonuç");
        this.result.Name = "result";
        this.result.Width = 80;

        this.Warning = new TTVisual.TTEnumComboBoxColumn();
        this.Warning.DataTypeName = "HighLowEnum";
        this.Warning.DataMember = "Warning";
        this.Warning.DisplayIndex = 2;
        this.Warning.HeaderText = i18n("M21289", "Sapma");
        this.Warning.Name = "Warning";
        this.Warning.Width = 80;

        this.Reference = new TTVisual.TTTextBoxColumn();
        this.Reference.DataMember = "Reference";
        this.Reference.DisplayIndex = 3;
        this.Reference.HeaderText = i18n("M21008", "Referans");
        this.Reference.Name = "Reference";
        this.Reference.Width = 100;

        this.unit = new TTVisual.TTTextBoxColumn();
        this.unit.DataMember = "Unit";
        this.unit.DisplayIndex = 4;
        this.unit.HeaderText = "Birimi";
        this.unit.Name = "unit";
        this.unit.Width = 80;

        this.SpecialReference = new TTVisual.TTRichTextBoxControlColumn();
        this.SpecialReference.DataMember = "SpecialReference";
        this.SpecialReference.DisplayIndex = 5;
        this.SpecialReference.HeaderText = i18n("M20103", "Özel Referans");
        this.SpecialReference.Name = "SpecialReference";
        this.SpecialReference.Width = 100;

        this.objId = new TTVisual.TTTextBoxColumn();
        this.objId.DisplayIndex = 6;
        this.objId.HeaderText = "Object ID";
        this.objId.Name = "objId";
        this.objId.ReadOnly = true;
        this.objId.Visible = false;
        this.objId.Width = 5;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Birim";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 74;

        this.txtProcessNote = new TTVisual.TTTextBox();
        this.txtProcessNote.Name = "txtProcessNote";
        this.txtProcessNote.TabIndex = 11;

        this.rtfReport = new TTVisual.TTRichTextBoxControl();
        this.rtfReport.BackColor = "#FFFFFF";
        this.rtfReport.Name = "rtfReport";
        this.rtfReport.TabIndex = 5;

        this.dtRequestDate = new TTVisual.TTDateTimePicker();
        this.dtRequestDate.CustomFormat = "";
        this.dtRequestDate.Format = DateTimePickerFormat.Long;
        this.dtRequestDate.Name = "dtRequestDate";
        this.dtRequestDate.TabIndex = 9;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Rapor";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 6;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "LaboratoryTestListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 0;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Test";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 8;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.BackColor = "#F0F0F0";
        this.Description.Name = "Description";
        this.Description.TabIndex = 4;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M23112", "Teknisyen Notu");
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 7;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M10469", "Açıklama");
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 69;

        this.TestTechnicianNote = new TTVisual.TTTextBox();
        this.TestTechnicianNote.Multiline = true;
        this.TestTechnicianNote.BackColor = "#F0F0F0";
        this.TestTechnicianNote.Name = "TestTechnicianNote";
        this.TestTechnicianNote.TabIndex = 8;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M16650", "İstek Tarihi");
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 72;

        this.tpGeneral = new TTVisual.TTTabPage();
        this.tpGeneral.DisplayIndex = 1;
        this.tpGeneral.BackColor = "#FFFFFF";
        this.tpGeneral.TabIndex = 0;
        this.tpGeneral.Text = i18n("M14681", "Genel Bilgiler");
        this.tpGeneral.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tpGeneral.Name = "tpGeneral";

        this.Department = new TTVisual.TTValueListBox();
        this.Department.ListDefName = "ResLaboratoryDepartmentListDefinition";
        this.Department.Name = "Department";
        this.Department.TabIndex = 2;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M12031", "Bölüm");
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 4;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M12222", "Cihaz");
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 5;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M17530", "Kısa Ananez ve Klinik Bulgular");
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 6;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M19485", "Notlar");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 7;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 8;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 9;

        this.Equipment = new TTVisual.TTValueListBox();
        this.Equipment.ListDefName = "ResLaboratoryEquipmentListDefinition";
        this.Equipment.Name = "Equipment";
        this.Equipment.TabIndex = 3;

        this.tpMaterial = new TTVisual.TTTabPage();
        this.tpMaterial.DisplayIndex = 2;
        this.tpMaterial.BackColor = "#FFFFFF";
        this.tpMaterial.TabIndex = 0;
        this.tpMaterial.Text = i18n("M18553", "Malzeme Bilgileri");
        this.tpMaterial.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tpMaterial.Name = "tpMaterial";

        this.Materials = new TTVisual.TTGrid();
        this.Materials.Name = "Materials";
        this.Materials.TabIndex = 0;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 300;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DisplayIndex = 1;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 100;

        this.OwnerType = new TTVisual.TTTextBox();
        this.OwnerType.Name = "OwnerType";
        this.OwnerType.TabIndex = 1;
        this.OwnerType.Visible = false;

        this.GridSubProceduresColumns = [this.TestName, this.result, this.Warning, this.Reference, this.unit, this.SpecialReference, this.objId];
        this.MaterialsColumns = [this.Material, this.Amount];
        this.tttabcontrol1.Controls = [this.tpTest, this.tpGeneral, this.tpMaterial];
        this.tpTest.Controls = [this.lblResult, this.tttextbox3, this.ttlabel13, this.tttextbox5, this.tttextbox4, this.ttlabel11, this.dtApproveDate, this.ttrichtextboxcontrol1, this.GridSubProcedures, this.ttlabel8, this.txtProcessNote, this.rtfReport, this.dtRequestDate, this.ttlabel5, this.ttobjectlistbox1, this.ttlabel6, this.Description, this.ttlabel10, this.ttlabel9, this.TestTechnicianNote, this.ttlabel7];
        this.tpGeneral.Controls = [this.Department, this.ttlabel1, this.ttlabel2, this.ttlabel3, this.ttlabel4, this.tttextbox1, this.tttextbox2, this.Equipment];
        this.tpMaterial.Controls = [this.Materials];
        this.Controls = [this.tttabcontrol1, this.tpTest, this.lblResult, this.tttextbox3, this.ttlabel13, this.tttextbox5, this.tttextbox4, this.ttlabel11, this.dtApproveDate, this.ttrichtextboxcontrol1, this.GridSubProcedures, this.TestName, this.result, this.Warning, this.Reference, this.unit, this.SpecialReference, this.objId, this.ttlabel8, this.txtProcessNote, this.rtfReport, this.dtRequestDate, this.ttlabel5, this.ttobjectlistbox1, this.ttlabel6, this.Description, this.ttlabel10, this.ttlabel9, this.TestTechnicianNote, this.ttlabel7, this.tpGeneral, this.Department, this.ttlabel1, this.ttlabel2, this.ttlabel3, this.ttlabel4, this.tttextbox1, this.tttextbox2, this.Equipment, this.tpMaterial, this.Materials, this.Material, this.Amount, this.OwnerType];

    }


}
