//$EE4FD4F8
import { Component, OnInit, NgZone } from '@angular/core';
import { LaboratoryProcedureDetailFormViewModel } from './LaboratoryProcedureDetailFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratorySubProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';


@Component({
    selector: 'LaboratoryProcedureDetailForm',
    templateUrl: './LaboratoryProcedureDetailForm.html',
    providers: [MessageService]
})
export class LaboratoryProcedureDetailForm extends TTVisual.TTForm implements OnInit {
    GridSubProcedures: TTVisual.ITTGrid;
    objId: TTVisual.ITTTextBoxColumn;
    Reference: TTVisual.ITTTextBoxColumn;
    result: TTVisual.ITTTextBoxColumn;
    SpecialReference: TTVisual.ITTRichTextBoxControlColumn;
    TestName: TTVisual.ITTListBoxColumn;
    unit: TTVisual.ITTTextBoxColumn;
    Warning: TTVisual.ITTEnumComboBoxColumn;
    public GridSubProceduresColumns = [];
    public laboratoryProcedureDetailFormViewModel: LaboratoryProcedureDetailFormViewModel = new LaboratoryProcedureDetailFormViewModel();
    public get _LaboratoryProcedure(): LaboratoryProcedure {
        return this._TTObject as LaboratoryProcedure;
    }
    private LaboratoryProcedureDetailForm_DocumentUrl: string = '/api/LaboratoryProcedureService/LaboratoryProcedureDetailForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('LABORATORYPROCEDURE', 'LaboratoryProcedureDetailForm');
        this._DocumentServiceUrl = this.LaboratoryProcedureDetailForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    protected async PreScript() {
        super.PreScript();
        for (let subProcedure of this._LaboratoryProcedure.LaboratorySubProcedures) {
            let name: string = subProcedure.ProcedureObject.Name;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryProcedure();
        this.laboratoryProcedureDetailFormViewModel = new LaboratoryProcedureDetailFormViewModel();
        this._ViewModel = this.laboratoryProcedureDetailFormViewModel;
        this.laboratoryProcedureDetailFormViewModel._LaboratoryProcedure = this._TTObject as LaboratoryProcedure;
        this.laboratoryProcedureDetailFormViewModel._LaboratoryProcedure.LaboratorySubProcedures = new Array<LaboratorySubProcedure>();
    }

    protected loadViewModel() {
        let that = this;

        that.laboratoryProcedureDetailFormViewModel = this._ViewModel as LaboratoryProcedureDetailFormViewModel;
        that._TTObject = this.laboratoryProcedureDetailFormViewModel._LaboratoryProcedure;
        if (this.laboratoryProcedureDetailFormViewModel == null)
            this.laboratoryProcedureDetailFormViewModel = new LaboratoryProcedureDetailFormViewModel();
        if (this.laboratoryProcedureDetailFormViewModel._LaboratoryProcedure == null)
            this.laboratoryProcedureDetailFormViewModel._LaboratoryProcedure = new LaboratoryProcedure();
        that.laboratoryProcedureDetailFormViewModel._LaboratoryProcedure.LaboratorySubProcedures = that.laboratoryProcedureDetailFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.laboratoryProcedureDetailFormViewModel.GridSubProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.laboratoryProcedureDetailFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(LaboratoryProcedureDetailFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.GridSubProcedures = new TTVisual.TTGrid();
        this.GridSubProcedures.AllowUserToDeleteRows = false;
        this.GridSubProcedures.BackColor = "#DCDCDC";
        this.GridSubProcedures.ReadOnly = true;
        this.GridSubProcedures.Name = "GridSubProcedures";
        this.GridSubProcedures.TabIndex = 0;

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
        this.SpecialReference.DisplayText = i18n("M20079", "Özel Değerler");
        this.SpecialReference.DataMember = "SpecialReference";
        this.SpecialReference.DisplayIndex = 5;
        this.SpecialReference.HeaderText = i18n("M20079", "Özel Değerler");
        this.SpecialReference.Name = "SpecialReference";
        this.SpecialReference.Width = 100;

        this.objId = new TTVisual.TTTextBoxColumn();
        this.objId.DisplayIndex = 6;
        this.objId.HeaderText = "Object ID";
        this.objId.Name = "objId";
        this.objId.ReadOnly = true;
        this.objId.Visible = false;
        this.objId.Width = 5;

        this.GridSubProceduresColumns = [this.TestName, this.result, this.Warning, this.Reference, this.unit, this.SpecialReference, this.objId];
        this.Controls = [this.GridSubProcedures, this.TestName, this.result, this.Warning, this.Reference, this.unit, this.SpecialReference, this.objId];

    }


}
