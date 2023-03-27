//$D35DDEF5
import { Component,  OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { NuclearMedicineTestDefinitionFormViewModel } from './NuclearMedicineTestDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NuclearMedicineTestDefinition, PackageProcedureDefinition, GILDefinition, SubProcedureDefinition, RequiredDiagnoseProcedure  } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicineGridEquipmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicineGridMaterialDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicineGridPharmDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTabNamesGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTestGroupDef } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadioPharmaceuticalDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResNuclearMedicineEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSLOINC } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'NuclearMedicineTestDefinitionForm',
    templateUrl: './NuclearMedicineTestDefinitionForm.html',
    providers: [MessageService]
})
export class NuclearMedicineTestDefinitionForm extends TTVisual.TTForm implements OnInit {
    ChkChargable: TTVisual.ITTCheckBox;
    EquipmentList: TTVisual.ITTListBoxColumn;
    ID: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    labelID: TTVisual.ITTLabel;
    labelMedulaProcedureType: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    labelSUTAppendix: TTVisual.ITTLabel;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    Qref: TTVisual.ITTTextBox;
    RadioPharmaCeuticalMaterial: TTVisual.ITTListBoxColumn;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    TabNameGridCol: TTVisual.ITTListBoxColumn;
    TabPagePharmMaterials: TTVisual.ITTTabPage;
    TabPageTreatmentMaterials: TTVisual.ITTTabPage;
    ttgrid1: TTVisual.ITTGrid;
    ttgrid2: TTVisual.ITTGrid;
    ttgrid3: TTVisual.ITTGrid;
    ttgrid4: TTVisual.ITTGrid;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlistboxcolumn1: TTVisual.ITTListBoxColumn;
    ttobjectlistbox2: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    SKRSLoincKodu: TTVisual.ITTObjectListBox;
    public ttgrid1Columns = [];
    public ttgrid2Columns = [];
    public ttgrid3Columns = [];
    public ttgrid4Columns = [];
    public nuclearMedicineTestDefinitionFormViewModel: NuclearMedicineTestDefinitionFormViewModel = new NuclearMedicineTestDefinitionFormViewModel();
    public get _NuclearMedicineTestDefinition(): NuclearMedicineTestDefinition {
        return this._TTObject as NuclearMedicineTestDefinition;
    }
    private NuclearMedicineTestDefinitionForm_DocumentUrl: string = '/api/NuclearMedicineTestDefinitionService/NuclearMedicineTestDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("NUCLEARMEDICINETESTDEFINITION", "NuclearMedicineTestDefinitionForm");
        this._DocumentServiceUrl = this.NuclearMedicineTestDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        super.PostScript(transDef);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicineTestDefinition();
        this.nuclearMedicineTestDefinitionFormViewModel = new NuclearMedicineTestDefinitionFormViewModel();
        this._ViewModel = this.nuclearMedicineTestDefinitionFormViewModel;
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition = this._TTObject as NuclearMedicineTestDefinition;
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.TabsBelongTo = new Array<NucMedTabNamesGrid>();
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.Equipments = new Array<NuclearMedicineGridEquipmentDefinition>();
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.PharmMaterials = new Array<NuclearMedicineGridPharmDefinition>();
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.Materials = new Array<NuclearMedicineGridMaterialDefinition>();
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.SKRSLoincKodu = new SKRSLOINC();
        
        //ProcedureDefinitiondan Gelen Alanlar Bunlar Eklenmeli
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.GILDefinition = new GILDefinition();
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>(); 
        this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>(); 
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineTestDefinitionFormViewModel = this._ViewModel as NuclearMedicineTestDefinitionFormViewModel;
        that._TTObject = this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition;
        if (this.nuclearMedicineTestDefinitionFormViewModel == null)
            this.nuclearMedicineTestDefinitionFormViewModel = new NuclearMedicineTestDefinitionFormViewModel();
        if (this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition == null)
            this.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition = new NuclearMedicineTestDefinition();

        let sKRSLoincKoduObjectID = that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition["SKRSLoincKodu"];
        if (sKRSLoincKoduObjectID != null && (typeof sKRSLoincKoduObjectID === "string")) {
            let sKRSLoincKodu = that.nuclearMedicineTestDefinitionFormViewModel.SKRSLOINCs.find(o => o.ObjectID.toString() === sKRSLoincKoduObjectID.toString());
            if (sKRSLoincKodu) {
                that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.SKRSLoincKodu = sKRSLoincKodu;
            }
        }

        that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.TabsBelongTo = that.nuclearMedicineTestDefinitionFormViewModel.ttgrid1GridList;
        for (let detailItem of that.nuclearMedicineTestDefinitionFormViewModel.ttgrid1GridList) {
            let nuclearMedicineTestGroupObjectID = detailItem["NuclearMedicineTestGroup"];
            if (nuclearMedicineTestGroupObjectID != null && (typeof nuclearMedicineTestGroupObjectID === "string")) {
                let nuclearMedicineTestGroup = that.nuclearMedicineTestDefinitionFormViewModel.NucMedTestGroupDefs.find(o => o.ObjectID.toString() === nuclearMedicineTestGroupObjectID.toString());
                if (nuclearMedicineTestGroup) {
                    detailItem.NuclearMedicineTestGroup = nuclearMedicineTestGroup;
                }
            }

        }
    
    that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.Equipments = that.nuclearMedicineTestDefinitionFormViewModel.ttgrid4GridList;
    for(let detailItem of that.nuclearMedicineTestDefinitionFormViewModel.ttgrid4GridList) {
        let myEquipmentObjectID = detailItem["MyEquipment"];
        if (myEquipmentObjectID != null && (typeof myEquipmentObjectID === "string")) {
            let myEquipment = that.nuclearMedicineTestDefinitionFormViewModel.ResNuclearMedicineEquipments.find(o => o.ObjectID.toString() === myEquipmentObjectID.toString());
            if (myEquipment) {
                detailItem.MyEquipment = myEquipment;
            }
        }

    }

that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.PharmMaterials = that.nuclearMedicineTestDefinitionFormViewModel.ttgrid3GridList;
for (let detailItem of that.nuclearMedicineTestDefinitionFormViewModel.ttgrid3GridList) {
    let radioPharmaCeuticalMaterialObjectID = detailItem["RadioPharmaCeuticalMaterial"];
    if (radioPharmaCeuticalMaterialObjectID != null && (typeof radioPharmaCeuticalMaterialObjectID === "string")) {
        let radioPharmaCeuticalMaterial = that.nuclearMedicineTestDefinitionFormViewModel.RadioPharmaceuticalDefinitions.find(o => o.ObjectID.toString() === radioPharmaCeuticalMaterialObjectID.toString());
        if (radioPharmaCeuticalMaterial) {
            detailItem.RadioPharmaCeuticalMaterial = radioPharmaCeuticalMaterial;
        }
    }

}

that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.Materials = that.nuclearMedicineTestDefinitionFormViewModel.ttgrid2GridList;
for (let detailItem of that.nuclearMedicineTestDefinitionFormViewModel.ttgrid2GridList) {
    let materialObjectID = detailItem["Material"];
    if (materialObjectID != null && (typeof materialObjectID === "string")) {
        let material = that.nuclearMedicineTestDefinitionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
        if (material) {
            detailItem.Material = material;
        }
    }

}

let procedureTreeObjectID = that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition["ProcedureTree"];
if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
    let procedureTree = that.nuclearMedicineTestDefinitionFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
    if (procedureTree) {
        that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.ProcedureTree = procedureTree;
    }
}

        /**
         * Her Tanım Ekranına Eklenmeli Base için Başlangıç
         */
        let packageProcedureObjectID = that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.nuclearMedicineTestDefinitionFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.PackageProcedure = packageProcedure;
            }
        }

        let gILDefinitionObjectID = that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.nuclearMedicineTestDefinitionFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.GILDefinition = gILDefinition;
            }
        }

        that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.SubProcedureDefinitions = that.nuclearMedicineTestDefinitionFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.nuclearMedicineTestDefinitionFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.nuclearMedicineTestDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }
        that.nuclearMedicineTestDefinitionFormViewModel._NuclearMedicineTestDefinition.RequiredDiagnoseProcedures = that.nuclearMedicineTestDefinitionFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.nuclearMedicineTestDefinitionFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.nuclearMedicineTestDefinitionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
                if (diagnosisDefinition) {
                    detailItem.DiagnosisDefinition = diagnosisDefinition;
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

    public onSKRSLoincKoduChanged(event): void {
        if (this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.SKRSLoincKodu != event) {
            this._NuclearMedicineTestDefinition.SKRSLoincKodu = event;
        }
    }

public onChkChargableChanged(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.Chargable != event) { 
    this._NuclearMedicineTestDefinition.Chargable = event;
}
}

public onIDChanged(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.TestID != event) { 
    this._NuclearMedicineTestDefinition.TestID = event;
}
}

public onIsActiveChanged(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.IsActive != event) { 
    this._NuclearMedicineTestDefinition.IsActive = event;
}
}

public onMedulaProcedureTypeChanged(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.MedulaProcedureType != event) { 
    this._NuclearMedicineTestDefinition.MedulaProcedureType = event;
}
}

public onNameChanged(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.Name != event) { 
    this._NuclearMedicineTestDefinition.Name = event;
}
}

public onQrefChanged(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.Qref != event) { 
    this._NuclearMedicineTestDefinition.Qref = event;
}
}

public onSUTAppendixChanged(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.SUTAppendix != event) { 
    this._NuclearMedicineTestDefinition.SUTAppendix = event;
}
}

public onttobjectlistbox2Changed(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.ProcedureTree != event) { 
    this._NuclearMedicineTestDefinition.ProcedureTree = event;
}
}

public ontttextbox1Changed(event): void {
    if(this._NuclearMedicineTestDefinition != null && this._NuclearMedicineTestDefinition.Code != event) { 
    this._NuclearMedicineTestDefinition.Code = event;
}
}



protected redirectProperties() : void {
    redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
    redirectProperty(this.ChkChargable, "Value", this.__ttObject, "Chargable");
    redirectProperty(this.ID, "Text", this.__ttObject, "TestID");
    redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Code");
    redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
    redirectProperty(this.Name, "Text", this.__ttObject, "Name");
    redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
    redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
}

public initFormControls() : void {
    this.labelSUTAppendix = new TTVisual.TTLabel();
    this.labelSUTAppendix.Text = "SUT Eki";
    this.labelSUTAppendix.Name = "labelSUTAppendix";
    this.labelSUTAppendix.TabIndex = 59;

    this.SKRSLoincKodu = new TTVisual.TTObjectListBox();
    this.SKRSLoincKodu.ListDefName = "SKRSLOINCList";
    this.SKRSLoincKodu.Name = "SKRSLoincKodu";
    this.SKRSLoincKodu.TabIndex = 60;

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

    this.ChkChargable = new TTVisual.TTCheckBox();
    this.ChkChargable.Value = false;
    this.ChkChargable.Title = "Ücretlenir";
    this.ChkChargable.Name = "ChkChargable";
    this.ChkChargable.TabIndex = 42;

    this.Name = new TTVisual.TTTextBox();
    this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Name.Name = "Name";
    this.Name.TabIndex = 39;

    this.labelName = new TTVisual.TTLabel();
    this.labelName.Text = "Tetkik Adı";
    this.labelName.BackColor = "#DCDCDC";
    this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelName.ForeColor = "#000000";
    this.labelName.Name = "labelName";
    this.labelName.TabIndex = 40;

    this.tttabcontrol1 = new TTVisual.TTTabControl();
    this.tttabcontrol1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabcontrol1.Name = "tttabcontrol1";
    this.tttabcontrol1.TabIndex = 41;

    this.tttabpage1 = new TTVisual.TTTabPage();
    this.tttabpage1.DisplayIndex = 0;
    this.tttabpage1.TabIndex = 1;
    this.tttabpage1.Text = "Tab Bilgileri";
    this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage1.Name = "tttabpage1";

    this.ttgrid1 = new TTVisual.TTGrid();
    this.ttgrid1.Name = "ttgrid1";
    this.ttgrid1.TabIndex = 56;

    this.TabNameGridCol = new TTVisual.TTListBoxColumn();
    this.TabNameGridCol.ListDefName = "NucMedTestGroupListDefinition";
    this.TabNameGridCol.DataMember = "NuclearMedicineTestGroup";
    this.TabNameGridCol.Required = true;
    this.TabNameGridCol.DisplayIndex = 0;
    this.TabNameGridCol.HeaderText = "Tab Adı";
    this.TabNameGridCol.Name = "TabNameGridCol";
    this.TabNameGridCol.Width = 300;

    this.tttabpage2 = new TTVisual.TTTabPage();
    this.tttabpage2.DisplayIndex = 1;
    this.tttabpage2.BackColor = "#FFFFFF";
    this.tttabpage2.TabIndex = 0;
    this.tttabpage2.Text = "Çalışacak Cihazlar";
    this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttabpage2.Name = "tttabpage2";

    this.ttgrid4 = new TTVisual.TTGrid();
    this.ttgrid4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttgrid4.Name = "ttgrid4";
    this.ttgrid4.TabIndex = 0;

    this.EquipmentList = new TTVisual.TTListBoxColumn();
    this.EquipmentList.ListDefName = "NucMedEquipmntListDefinition";
    this.EquipmentList.DataMember = "MyEquipment";
    this.EquipmentList.DisplayIndex = 0;
    this.EquipmentList.HeaderText = "Cihaz";
    this.EquipmentList.Name = "EquipmentList";
    this.EquipmentList.Width = 300;

    this.TabPagePharmMaterials = new TTVisual.TTTabPage();
    this.TabPagePharmMaterials.DisplayIndex = 2;
    this.TabPagePharmMaterials.BackColor = "#FFFFFF";
    this.TabPagePharmMaterials.TabIndex = 0;
    this.TabPagePharmMaterials.Text = "Radyofarmasötik Malzemeler";
    this.TabPagePharmMaterials.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabPagePharmMaterials.Name = "TabPagePharmMaterials";

    this.ttgrid3 = new TTVisual.TTGrid();
    this.ttgrid3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttgrid3.Name = "ttgrid3";
    this.ttgrid3.TabIndex = 0;

    this.RadioPharmaCeuticalMaterial = new TTVisual.TTListBoxColumn();
    this.RadioPharmaCeuticalMaterial.ListDefName = "RadioPharmaceuticalListDef";
    this.RadioPharmaCeuticalMaterial.DataMember = "RadioPharmaCeuticalMaterial";
    this.RadioPharmaCeuticalMaterial.DisplayIndex = 0;
    this.RadioPharmaCeuticalMaterial.HeaderText = "Radyofarmasötik Malzeme";
    this.RadioPharmaCeuticalMaterial.Name = "RadioPharmaCeuticalMaterial";
    this.RadioPharmaCeuticalMaterial.Width = 400;

    this.TabPageTreatmentMaterials = new TTVisual.TTTabPage();
    this.TabPageTreatmentMaterials.DisplayIndex = 3;
    this.TabPageTreatmentMaterials.TabIndex = 2;
    this.TabPageTreatmentMaterials.Text = "Sarf  Malzemeler";
    this.TabPageTreatmentMaterials.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.TabPageTreatmentMaterials.Name = "TabPageTreatmentMaterials";

    this.ttgrid2 = new TTVisual.TTGrid();
    this.ttgrid2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttgrid2.Name = "ttgrid2";
    this.ttgrid2.TabIndex = 0;

    this.ttlistboxcolumn1 = new TTVisual.TTListBoxColumn();
    this.ttlistboxcolumn1.ListDefName = "TreatmentMaterialListDefinition";
    this.ttlistboxcolumn1.DataMember = "Material";
    this.ttlistboxcolumn1.DisplayIndex = 0;
    this.ttlistboxcolumn1.HeaderText = "Malzeme";
    this.ttlistboxcolumn1.Name = "ttlistboxcolumn1";
    this.ttlistboxcolumn1.Width = 400;

    this.tttextbox1 = new TTVisual.TTTextBox();
    this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.tttextbox1.Name = "tttextbox1";
    this.tttextbox1.TabIndex = 39;

    this.Qref = new TTVisual.TTTextBox();
    this.Qref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Qref.Name = "Qref";
    this.Qref.TabIndex = 2;

    this.ID = new TTVisual.TTTextBox();
    this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ID.Name = "ID";
    this.ID.TabIndex = 0;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Tetkik Kodu";
    this.ttlabel2.BackColor = "#DCDCDC";
    this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 40;

    this.ttobjectlistbox2 = new TTVisual.TTObjectListBox();
    this.ttobjectlistbox2.ListDefName = "ProcedureTreeListDefinition";
    this.ttobjectlistbox2.Name = "ttobjectlistbox2";
    this.ttobjectlistbox2.TabIndex = 55;

    this.ttlabel3 = new TTVisual.TTLabel();
    this.ttlabel3.Text = "Hizmet Grubu";
    this.ttlabel3.BackColor = "#DCDCDC";
    this.ttlabel3.ForeColor = "#000000";
    this.ttlabel3.Name = "ttlabel3";
    this.ttlabel3.TabIndex = 54;

    this.labelQref = new TTVisual.TTLabel();
    this.labelQref.Text = "Kısa Adı";
    this.labelQref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelQref.ForeColor = "#000000";
    this.labelQref.Name = "labelQref";
    this.labelQref.TabIndex = 31;

    this.labelID = new TTVisual.TTLabel();
    this.labelID.Text = "Tetkik Id";
    this.labelID.BackColor = "#DCDCDC";
    this.labelID.ForeColor = "#000000";
    this.labelID.Name = "labelID";
    this.labelID.TabIndex = 27;

    this.IsActive = new TTVisual.TTCheckBox();
    this.IsActive.Value = false;
    this.IsActive.Text = "Aktif";
    this.IsActive.Name = "IsActive";
    this.IsActive.TabIndex = 2;

    this.ttgrid1Columns = [this.TabNameGridCol];
    this.ttgrid4Columns = [this.EquipmentList];
    this.ttgrid3Columns = [this.RadioPharmaCeuticalMaterial];
    this.ttgrid2Columns = [this.ttlistboxcolumn1];
    this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2, this.TabPagePharmMaterials, this.TabPageTreatmentMaterials];
    this.tttabpage1.Controls = [this.ttgrid1];
    this.tttabpage2.Controls = [this.ttgrid4];
    this.TabPagePharmMaterials.Controls = [this.ttgrid3];
    this.TabPageTreatmentMaterials.Controls = [this.ttgrid2];
    this.Controls = [this.labelSUTAppendix, this.SKRSLoincKodu, this.SUTAppendix, this.labelMedulaProcedureType, this.MedulaProcedureType, this.ChkChargable, this.Name, this.labelName, this.tttabcontrol1, this.tttabpage1, this.ttgrid1, this.TabNameGridCol, this.tttabpage2, this.ttgrid4, this.EquipmentList, this.TabPagePharmMaterials, this.ttgrid3, this.RadioPharmaCeuticalMaterial, this.TabPageTreatmentMaterials, this.ttgrid2, this.ttlistboxcolumn1, this.tttextbox1, this.Qref, this.ID, this.ttlabel2, this.ttobjectlistbox2, this.ttlabel3, this.labelQref, this.labelID, this.IsActive];

}


}
