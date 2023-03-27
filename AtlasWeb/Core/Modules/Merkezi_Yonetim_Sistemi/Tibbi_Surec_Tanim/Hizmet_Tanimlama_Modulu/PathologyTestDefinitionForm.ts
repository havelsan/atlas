//$15039ACE
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PathologyTestDefinitionFormViewModel } from './PathologyTestDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PathologyTestDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyGridDescriptionDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyGridMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyTestCategoryDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyTestDescriptionDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TahlilTipi } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'PathologyTestDefinitionForm',
    templateUrl: './PathologyTestDefinitionForm.html',
    providers: [MessageService]
})
export class PathologyTestDefinitionForm extends TTVisual.TTForm implements OnInit {
    Category: TTVisual.ITTObjectListBox;
    Code: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    EnglishName: TTVisual.ITTTextBox;
    ID: TTVisual.ITTTextBox;
    labelCode: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    labelTahlilTipi: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Materials: TTVisual.ITTGrid;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    OrderNo: TTVisual.ITTTextBoxColumn;
    ProcedureTree: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    RequestApprove: TTVisual.ITTCheckBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    TahlilTipi: TTVisual.ITTObjectListBox;
    TDescription: TTVisual.ITTListBoxColumn;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttgrid1: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    ResultTime: TTVisual.ITTTextBox;
    public MaterialsColumns = [];
    public ttgrid1Columns = [];
    public pathologyTestDefinitionFormViewModel: PathologyTestDefinitionFormViewModel = new PathologyTestDefinitionFormViewModel();
    public get _PathologyTestDefinition(): PathologyTestDefinition {
        return this._TTObject as PathologyTestDefinition;
    }
    private PathologyTestDefinitionForm_DocumentUrl: string = '/api/PathologyTestDefinitionService/PathologyTestDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("PATHOLOGYTESTDEFINITION", "PathologyTestDefinitionForm");
        this._DocumentServiceUrl = this.PathologyTestDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PathologyTestDefinition();
        this.pathologyTestDefinitionFormViewModel = new PathologyTestDefinitionFormViewModel();
        this._ViewModel = this.pathologyTestDefinitionFormViewModel;
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition = this._TTObject as PathologyTestDefinition;
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.Materials = new Array<PathologyGridMaterialDefinition>();
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.PathologyTestDescription = new Array<PathologyGridDescriptionDefinition>();
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.TahlilTipi = new TahlilTipi();
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.TestCategory = new PathologyTestCategoryDefinition();
        
        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.GILDefinition = new GILDefinition();
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();    
        this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.pathologyTestDefinitionFormViewModel = this._ViewModel as PathologyTestDefinitionFormViewModel;
        that._TTObject = this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition;
        if (this.pathologyTestDefinitionFormViewModel == null)
            this.pathologyTestDefinitionFormViewModel = new PathologyTestDefinitionFormViewModel();
        if (this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition == null)
            this.pathologyTestDefinitionFormViewModel._PathologyTestDefinition = new PathologyTestDefinition();
        let procedureTreeObjectID = that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.pathologyTestDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.ProcedureTree = procedureTree;
            }
        }

    
    that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.Materials = that.pathologyTestDefinitionFormViewModel.MaterialsGridList;
    for(let detailItem of that.pathologyTestDefinitionFormViewModel.MaterialsGridList) {
        let materialObjectID = detailItem["Material"];
        if (materialObjectID != null && (typeof materialObjectID === "string")) {
            let material = that.pathologyTestDefinitionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
            if (material) {
                detailItem.Material = material;
            }
        }

    }

that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.PathologyTestDescription = that.pathologyTestDefinitionFormViewModel.ttgrid1GridList;
for (let detailItem of that.pathologyTestDefinitionFormViewModel.ttgrid1GridList) {
    let testDescriptionObjectID = detailItem["TestDescription"];
    if (testDescriptionObjectID != null && (typeof testDescriptionObjectID === "string")) {
        let testDescription = that.pathologyTestDefinitionFormViewModel.PathologyTestDescriptionDefinitions.find(o => o.ObjectID.toString() === testDescriptionObjectID.toString());
        if (testDescription) {
            detailItem.TestDescription = testDescription;
        }
    }

}

let tahlilTipiObjectID = that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition["TahlilTipi"];
if (tahlilTipiObjectID != null && (typeof tahlilTipiObjectID === "string")) {
    let tahlilTipi = that.pathologyTestDefinitionFormViewModel.TahlilTipis.find(o => o.ObjectID.toString() === tahlilTipiObjectID.toString());
    if (tahlilTipi) {
        that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.TahlilTipi = tahlilTipi;
    }
}


let testCategoryObjectID = that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition["TestCategory"];
if (testCategoryObjectID != null && (typeof testCategoryObjectID === "string")) {
    let testCategory = that.pathologyTestDefinitionFormViewModel.PathologyTestCategoryDefinitions.find(o => o.ObjectID.toString() === testCategoryObjectID.toString());
    if (testCategory) {
        that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.TestCategory = testCategory;
    }
}

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.pathologyTestDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.pathologyTestDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.GILDefinition = gILDefinition;
            }
        }

        that.pathologyTestDefinitionFormViewModel._PathologyTestDefinition.SubProcedureDefinitions = that.pathologyTestDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.pathologyTestDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.pathologyTestDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }
        /**
         * Her Tanım Ekranına Eklenmeli Base için Bitiş
         */


}

async ngOnInit() {
    await this.load();
}

public onCategoryChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.TestCategory != event) { 
    this._PathologyTestDefinition.TestCategory = event;
}
}

public onCodeChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.Code != event) { 
    this._PathologyTestDefinition.Code = event;
}
}

public onDescriptionChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.Description != event) { 
    this._PathologyTestDefinition.Description = event;
}
}

public onEnglishNameChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.EnglishName != event) { 
    this._PathologyTestDefinition.EnglishName = event;
}
}

public onIDChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.ID != event) { 
    this._PathologyTestDefinition.ID = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.MedulaProcedureType != event) { 
    this._PathologyTestDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.Name != event) { 
    this._PathologyTestDefinition.Name = event;
}
}

public onProcedureTreeChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.ProcedureTree != event) { 
    this._PathologyTestDefinition.ProcedureTree = event;
}
}

public onQrefChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.Qref != event) { 
    this._PathologyTestDefinition.Qref = event;
}
}

public onRequestApproveChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.RequestApprove != event) { 
    this._PathologyTestDefinition.RequestApprove = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.SUTAppendix != event) { 
    this._PathologyTestDefinition.SUTAppendix = event;
}
}

public onTahlilTipiChanged(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.TahlilTipi != event) { 
    this._PathologyTestDefinition.TahlilTipi = event;
}
}

public onttcheckbox1Changed(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.IsActive != event) { 
    this._PathologyTestDefinition.IsActive = event;
}
}

public ontttextbox1Changed(event): void {
    if(this._PathologyTestDefinition != null && this._PathologyTestDefinition.TestCount != event) { 
    this._PathologyTestDefinition.TestCount = event;
}
}

    public onResultTimeChanged(event): void {
        if (this._PathologyTestDefinition != null && this._PathologyTestDefinition.ResultTime != event) {
            this._PathologyTestDefinition.ResultTime = event;
        }
    }

protected redirectProperties() : void {
    redirectProperty(this.Code, "Text", this.__ttObject, "Code");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.RequestApprove, "Value", this.__ttObject, "RequestApprove");
    redirectProperty(this.ID, "Text", this.__ttObject, "ID");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.tttextbox1, "Text", this.__ttObject, "TestCount");
    redirectProperty(this.EnglishName, "Text", this.__ttObject, "EnglishName");
    redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 59;

    this.ResultTime = new TTVisual.TTTextBox();
    this.ResultTime.Name = "ResultTime";
    this.ResultTime.TabIndex = 62;

    this.SUTAppendix = new TTVisual.TTEnumComboBox();
    this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
    this.SUTAppendix.Name = "SUTAppendix";
    this.SUTAppendix.TabIndex = 58;

    this.labelMedulaProcedureType = new TTVisual.TTLabel();
    this.labelMedulaProcedureType.Text = "Medula Hizmet Kayıt Grubu";
    this.labelMedulaProcedureType.Name = "labelMedulaProcedureType";
    this.labelMedulaProcedureType.TabIndex = 57;

    this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
    this.MedulaProcedureType.DataTypeName = "MedulaProcedureTypeEnum";
    this.MedulaProcedureType.Name = "MedulaProcedureType";
    this.MedulaProcedureType.TabIndex = 56;

    this.RequestApprove = new TTVisual.TTCheckBox();
    this.RequestApprove.Value = false;
    this.RequestApprove.Title = "Baştabip Onay";
    this.RequestApprove.Name = "RequestApprove";
    this.RequestApprove.TabIndex = 55;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Tetik Adı";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 10;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Kategori";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 14;

    this.tttabcontrol1 = new TTVisual.TTTabControl();
    this.tttabcontrol1.Name = "tttabcontrol1";
    this.tttabcontrol1.TabIndex = 15;

    this.tttabpage1 = new TTVisual.TTTabPage();
    this.tttabpage1.DisplayIndex = 0;
    this.tttabpage1.BackColor = "#FFFFFF";
    this.tttabpage1.TabIndex = 0;
    this.tttabpage1.Text = "Genel Tanımlar";
    this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage1.Name = "tttabpage1";

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Hizmet Sınıfı";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 15;

    this.labelDescription = new TTVisual.TTLabel();
    this.labelDescription.Text = "Açıklama";
    this.labelDescription.ForeColor = "#000000";
    this.labelDescription.Name = "labelDescription";
    this.labelDescription.TabIndex = 3;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Adı";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 12;

    this.Description = new TTVisual.TTTextBox();
    this.Description.Multiline = true;
    this.Description.Name = "Description";
    this.Description.TabIndex = 2;

    this.labelEnglishName = new TTVisual.TTLabel();
    this.labelEnglishName.Text = "İngilizce Adı";
    this.labelEnglishName.ForeColor = "#000000";
    this.labelEnglishName.Name = "labelEnglishName";
    this.labelEnglishName.TabIndex = 5;

    this.tttextbox1 = new TTVisual.TTTextBox();
    this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttextbox1.Name = "tttextbox1";
    this.tttextbox1.TabIndex = 128;

    this.ttlabel5 = new TTVisual.TTLabel();
    this.ttlabel5.Text = "Hizmet Sayısı";
    this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel5.Name = "ttlabel5";
    this.ttlabel5.TabIndex = 126;

    this.ProcedureTree = new TTVisual.TTObjectListBox();
    this.ProcedureTree.ListDefName = "ProcedureTreeListDefinition";
    this.ProcedureTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ProcedureTree.Name = "ProcedureTree";
    this.ProcedureTree.TabIndex = 120;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 11;

    this.labelID = new TTVisual.TTLabel();
    this.labelID.Text = "Tetkik Id";
    this.labelID.ForeColor = "#000000";
    this.labelID.Name = "labelID";
    this.labelID.TabIndex = 7;

    this.EnglishName = new TTVisual.TTTextBox();
    this.EnglishName.Name = "EnglishName";
    this.EnglishName.TabIndex = 4;

    this.ID = new TTVisual.TTTextBox();
    this.ID.Name = "ID";
    this.ID.TabIndex = 6;

    this.tttabpage2 = new TTVisual.TTTabPage();
    this.tttabpage2.DisplayIndex = 1;
    this.tttabpage2.BackColor = "#FFFFFF";
    this.tttabpage2.TabIndex = 0;
    this.tttabpage2.Text = "Malzeme Tanımları";
    this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage2.Name = "tttabpage2";

    this.Materials = new TTVisual.TTGrid();
    this.Materials.Name = "Materials";
    this.Materials.TabIndex = 0;

    this.Material = new TTVisual.TTListBoxColumn();
    this.Material.ListDefName = "TreatmentMaterialListDefinition";
    this.Material.DataMember = "Material";
    this.Material.DisplayIndex = 0;
    this.Material.HeaderText = "Malzeme";
    this.Material.Name = "Material";
    this.Material.Width = 350;

    this.tttabpage3 = new TTVisual.TTTabPage();
    this.tttabpage3.DisplayIndex = 2;
    this.tttabpage3.BackColor = "#FFFFFF";
    this.tttabpage3.TabIndex = 0;
    this.tttabpage3.Text = "Açıklama Tanımları";
    this.tttabpage3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage3.Name = "tttabpage3";

    this.ttgrid1 = new TTVisual.TTGrid();
    this.ttgrid1.Name = "ttgrid1";
    this.ttgrid1.TabIndex = 0;

    this.OrderNo = new TTVisual.TTTextBoxColumn();
    this.OrderNo.DataMember = "OrderNo";
    this.OrderNo.DisplayIndex = 0;
    this.OrderNo.HeaderText = "Sıra No";
    this.OrderNo.Name = "OrderNo";
    this.OrderNo.Width = 100;

    this.TDescription = new TTVisual.TTListBoxColumn();
    this.TDescription.ListDefName = "PathologyTestDescriptionListDefinition";
    this.TDescription.DataMember = "TestDescription";
    this.TDescription.DisplayIndex = 1;
    this.TDescription.HeaderText = "Açıklama";
    this.TDescription.Name = "TDescription";
    this.TDescription.Width = 250;

    this.tttabpage4 = new TTVisual.TTTabPage();
    this.tttabpage4.DisplayIndex = 3;
    this.tttabpage4.TabIndex = 1;
    this.tttabpage4.Text = "Medula";
    this.tttabpage4.Name = "tttabpage4";

    this.TahlilTipi = new TTVisual.TTObjectListBox();
    this.TahlilTipi.ListDefName = "TahlilTipiListDefinition";
    this.TahlilTipi.Name = "TahlilTipi";
    this.TahlilTipi.TabIndex = 1;

    this.labelTahlilTipi = new TTVisual.TTLabel();
    this.labelTahlilTipi.Text = "Tahlil Kodu";
    this.labelTahlilTipi.Name = "labelTahlilTipi";
    this.labelTahlilTipi.TabIndex = 0;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Name = "Name";
    this.Name.TabIndex = 9;

    this.Code = new TTVisual.TTTextBox();
    this.Code.Name = "Code";
    this.Code.TabIndex = 0;

    this.labelCode = new TTVisual.TTLabel();
    this.labelCode.Text = "Hizmet Kodu";
    this.labelCode.ForeColor = "#000000";
    this.labelCode.Name = "labelCode";
    this.labelCode.TabIndex = 1;

    this.Category = new TTVisual.TTObjectListBox();
    this.Category.ListDefName = "PatholohyTestCategoryListDefinition";
    this.Category.Name = "Category";
    this.Category.TabIndex = 13;

    this.ttcheckbox1 = new TTVisual.TTCheckBox();
    this.ttcheckbox1.Value = false;
    this.ttcheckbox1.Text = "Aktif";
    this.ttcheckbox1.Name = "ttcheckbox1";
    this.ttcheckbox1.TabIndex = 54;

    this.MaterialsColumns = [this.Material];
    this.ttgrid1Columns = [this.OrderNo, this.TDescription];
    this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3, this.tttabpage4];
    this.tttabpage1.Controls = [this.ttlabel2, this.labelDescription, this.labelQref, this.Description, this.labelEnglishName, this.tttextbox1, this.ttlabel5, this.ProcedureTree, this.Qref, this.labelID, this.EnglishName, this.ID];
    this.tttabpage2.Controls = [this.Materials];
    this.tttabpage3.Controls = [this.ttgrid1];
    this.tttabpage4.Controls = [this.TahlilTipi, this.labelTahlilTipi];
    this.Controls = [this.labelSUTAppendix, this.ResultTime, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.RequestApprove, this.labelName, this.ttlabel1, this.tttabcontrol1, this.tttabpage1, this.ttlabel2, this.labelDescription, this.labelQref, this.Description, this.labelEnglishName, this.tttextbox1, this.ttlabel5, this.ProcedureTree, this.Qref, this.labelID, this.EnglishName, this.ID, this.tttabpage2, this.Materials, this.Material, this.tttabpage3, this.ttgrid1, this.OrderNo, this.TDescription, this.tttabpage4, this.TahlilTipi, this.labelTahlilTipi, this.Name, this.Code, this.labelCode, this.Category, this.ttcheckbox1];

}


}
