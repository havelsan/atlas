//$100D32F3
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyRejectFormViewModel } from "./RadiologyRejectFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';

import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyRejectReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";



@Component({
    selector: 'RadiologyRejectForm',
    templateUrl: './RadiologyRejectForm.html',
    providers: [MessageService]
})
export class RadiologyRejectForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    BodyPosition: TTVisual.ITTEnumComboBoxColumn;
    BodySite: TTVisual.ITTEnumComboBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    GridRadiologyTests: TTVisual.ITTGrid;
    labelPreInformation: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Notes: TTVisual.ITTTextBoxColumn;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ttgrid2: TTVisual.ITTGrid;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    ttvaluelistbox1: TTVisual.ITTValueListBox;
    public GridRadiologyTestsColumns = [];
    public ttgrid2Columns = [];
    public radiologyRejectFormViewModel: RadiologyRejectFormViewModel = new RadiologyRejectFormViewModel();
    public get _Radiology(): Radiology {
        return this._TTObject as Radiology;
    }
    private RadiologyRejectForm_DocumentUrl: string = '/api/RadiologyService/RadiologyRejectForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyRejectForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PreScript() {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Radiology();
        this.radiologyRejectFormViewModel = new RadiologyRejectFormViewModel();
        this._ViewModel = this.radiologyRejectFormViewModel;
        this.radiologyRejectFormViewModel._Radiology = this._TTObject as Radiology;
        this.radiologyRejectFormViewModel._Radiology.Materials = new Array<RadiologyMaterial>();
        this.radiologyRejectFormViewModel._Radiology.RadiologyTests = new Array<RadiologyTest>();
        this.radiologyRejectFormViewModel._Radiology.RequestDoctor = new ResUser();
        this.radiologyRejectFormViewModel._Radiology.RejectReason = new RadiologyRejectReasonDefinition();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyRejectFormViewModel = this._ViewModel as RadiologyRejectFormViewModel;
        that._TTObject = this.radiologyRejectFormViewModel._Radiology;
        if (this.radiologyRejectFormViewModel == null)
            this.radiologyRejectFormViewModel = new RadiologyRejectFormViewModel();
        if (this.radiologyRejectFormViewModel._Radiology == null)
            this.radiologyRejectFormViewModel._Radiology = new Radiology();
        that.radiologyRejectFormViewModel._Radiology.Materials = that.radiologyRejectFormViewModel.ttgrid2GridList;
        for (let detailItem of that.radiologyRejectFormViewModel.ttgrid2GridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.radiologyRejectFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.radiologyRejectFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.radiologyRejectFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.radiologyRejectFormViewModel._Radiology.RadiologyTests = that.radiologyRejectFormViewModel.GridRadiologyTestsGridList;
        for (let detailItem of that.radiologyRejectFormViewModel.GridRadiologyTestsGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.radiologyRejectFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
        let requestDoctorObjectID = that.radiologyRejectFormViewModel._Radiology["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.radiologyRejectFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.radiologyRejectFormViewModel._Radiology.RequestDoctor = requestDoctor;
            }
        }
        let rejectReasonObjectID = that.radiologyRejectFormViewModel._Radiology["RejectReason"];
        if (rejectReasonObjectID != null && (typeof rejectReasonObjectID === 'string')) {
            let rejectReason = that.radiologyRejectFormViewModel.RadiologyRejectReasonDefinitions.find(o => o.ObjectID.toString() === rejectReasonObjectID.toString());
             if (rejectReason) {
                that.radiologyRejectFormViewModel._Radiology.RejectReason = rejectReason;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyRejectFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.ActionDate != event) {
                this._Radiology.ActionDate = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.RequestDoctor != event) {
                this._Radiology.RequestDoctor = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.PreDiagnosis != event) {
                this._Radiology.PreDiagnosis = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.Description != event) {
                this._Radiology.Description = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.TechnicianNote != event) {
                this._Radiology.TechnicianNote = event;
            }
        }
    }

    public onttvaluelistbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.RejectReason != event) {
                this._Radiology.RejectReason = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Description");
        redirectProperty(this.ttvaluelistbox1, "SelectedValue", this.__ttObject, "RejectReason");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TechnicianNote");
    }

    public initFormControls(): void {
        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16902", "İşlem Zamanı");
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 56;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 67;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 0;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = i18n("M21309", "Sarf");
        this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage2.Name = "tttabpage2";

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.HideCancelledData = false;
        this.ttgrid2.AllowUserToDeleteRows = false;
        this.ttgrid2.Name = "ttgrid2";
        this.ttgrid2.TabIndex = 0;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M21314", "Sarf Edilen Malzeme");
        this.Material.Name = "Material";
        this.Material.ReadOnly = true;
        this.Material.Width = 400;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DisplayIndex = 1;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Notes = new TTVisual.TTTextBoxColumn();
        this.Notes.DisplayIndex = 3;
        this.Notes.HeaderText = i18n("M10469", "Açıklama");
        this.Notes.Name = "Notes";
        this.Notes.ReadOnly = true;
        this.Notes.Width = 100;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "Test";
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.GridRadiologyTests = new TTVisual.TTGrid();
        this.GridRadiologyTests.HideCancelledData = false;
        this.GridRadiologyTests.Name = "GridRadiologyTests";
        this.GridRadiologyTests.TabIndex = 0;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "RadiologyTestListDefinition";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 0;
        this.ProcedureObject.HeaderText = "Test";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.Width = 300;

        this.BodySite = new TTVisual.TTEnumComboBoxColumn();
        this.BodySite.DataTypeName = "RadiologyBodySiteEnum";
        this.BodySite.DataMember = "BodySite";
        this.BodySite.DisplayIndex = 1;
        this.BodySite.HeaderText = i18n("M22824", "Taraf");
        this.BodySite.Name = "BodySite";
        this.BodySite.ReadOnly = true;
        this.BodySite.Width = 50;

        this.BodyPosition = new TTVisual.TTEnumComboBoxColumn();
        this.BodyPosition.DataTypeName = "RadiologyBodyPositionEnum";
        this.BodyPosition.DataMember = "BodyPosition";
        this.BodyPosition.DisplayIndex = 2;
        this.BodyPosition.HeaderText = i18n("M20461", "Pozisyon");
        this.BodyPosition.Name = "BodyPosition";
        this.BodyPosition.ReadOnly = true;
        this.BodyPosition.Width = 100;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 3;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.ReadOnly = true;
        this.Description.Width = 100;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Multiline = true;
        this.tttextbox3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 3;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 1;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 2;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 61;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 4;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M20975", "Red Nedeni");
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 64;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.labelPreInformation.BackColor = "#DCDCDC";
        this.labelPreInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 57;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M23112", "Teknisyen Notu");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 65;

        this.ttvaluelistbox1 = new TTVisual.TTValueListBox();
        this.ttvaluelistbox1.ListDefName = "RadiologyRejectReasonListDefinition";
        this.ttvaluelistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttvaluelistbox1.Name = "ttvaluelistbox1";
        this.ttvaluelistbox1.TabIndex = 5;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10483", "Açıklamalar");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 60;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.ttgrid2Columns = [this.Material, this.Amount, this.DistributionType, this.Notes];
        this.GridRadiologyTestsColumns = [this.ProcedureObject, this.BodySite, this.BodyPosition, this.Description];
        this.tttabcontrol1.Controls = [this.tttabpage2, this.tttabpage1];
        this.tttabpage2.Controls = [this.ttgrid2];
        this.tttabpage1.Controls = [this.GridRadiologyTests];
        this.Controls = [this.labelProcessTime, this.tttabcontrol1, this.tttabpage2, this.ttgrid2, this.Material, this.Amount, this.DistributionType, this.Notes, this.tttabpage1, this.GridRadiologyTests, this.ProcedureObject, this.BodySite, this.BodyPosition, this.Description, this.tttextbox3, this.tttextbox1, this.tttextbox2, this.ttlabel2, this.ttobjectlistbox1, this.ttlabel3, this.labelPreInformation, this.ttlabel4, this.ttvaluelistbox1, this.ttlabel1, this.ActionDate];

    }


}
