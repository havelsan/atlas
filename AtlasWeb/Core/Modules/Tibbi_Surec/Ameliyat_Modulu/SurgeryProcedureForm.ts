//$3B817FF1
import { Component, OnInit, Input } from '@angular/core';
import { SurgeryProcedureFormViewModel } from './SurgeryProcedureFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SurgeryProcedure, Common } from 'NebulaClient/Model/AtlasClientModel';

import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';

@Component({
    selector: 'SurgeryProcedureForm',
    templateUrl: './SurgeryProcedureForm.html',
    providers: [MessageService]
})
export class SurgeryProcedureForm extends TTVisual.TTForm implements OnInit {
    AyniFarkliKesi: TTVisual.ITTObjectListBox;
    Department: TTVisual.ITTObjectListBox;
    DescriptionOfProcedureObject: TTVisual.ITTRichTextBoxControl;
    EuroScoreButton: TTVisual.ITTButton;
    GilPoint: TTVisual.ITTTextBox;
    labelAyniFarkliKesi: TTVisual.ITTLabel;
    labelDepartment: TTVisual.ITTLabel;
    labelDescriptionOfProcedureObject: TTVisual.ITTLabel;
    labelPosition: TTVisual.ITTLabel;
    labelProcedureObject: TTVisual.ITTLabel;
    labelRabsonGroup: TTVisual.ITTLabel;
    labelSutPoint: TTVisual.ITTLabel;
    lableGilPoint: TTVisual.ITTLabel;
    lableResponsibleDoctor: TTVisual.ITTLabel;
    Position: TTVisual.ITTEnumComboBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    RabsonGroup: TTVisual.ITTEnumComboBox;
    ResponsibleDoctorSurgeryResponsibleDoctor: TTVisual.ITTListBoxColumn;
    SurgeryResponsibleDoctors: TTVisual.ITTGrid;
    SutPoint: TTVisual.ITTTextBox;
    IsComplicationSurgery: TTVisual.ITTCheckBox;
    labelComplicationDescription: TTVisual.ITTLabel;
    ComplicationDescription: TTVisual.ITTTextBox;
    IsScoliosisSurgery: TTVisual.ITTCheckBox;
    public SurgeryResponsibleDoctorsColumns = [];

    public get _SurgeryProcedure(): SurgeryProcedure {
        return this._TTObject as SurgeryProcedure;
    }
    private SurgeryProcedureForm_DocumentUrl: string = '/api/SurgeryProcedureService/SurgeryProcedureForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('SURGERYPROCEDURE', 'SurgeryProcedureForm');
        this._DocumentServiceUrl = this.SurgeryProcedureForm_DocumentUrl;
        //this.initViewModel();
        this.initFormControls();
    }

    public isComplicationSurgery: boolean;
    // ***** Method declarations start *****
    private _surgeryProcedureFormViewModel: SurgeryProcedureFormViewModel;
    @Input() set surgeryProcedureFormViewModel(value: SurgeryProcedureFormViewModel) {
        this._surgeryProcedureFormViewModel = value;
        this._ViewModel = this.surgeryProcedureFormViewModel;
        this.loadViewModel();
        this.PreScript();
    }
    get surgeryProcedureFormViewModel(): SurgeryProcedureFormViewModel {
        return this._surgeryProcedureFormViewModel;
    }

    private _isReadonly: Boolean;
    @Input() set IsReadOnly(value: Boolean) {
        this._isReadonly = value;
        if (this.IsReadOnly == true)
            this.ReadOnly = true;
        else
            this.ReadOnly = false;
    }
    get IsReadOnly(): Boolean {
        return this._isReadonly == true ? true : false;
    }




    // *****Method declarations end *****


    //public initViewModel(): void {
    //    this._TTObject = new SurgeryProcedure();
    //    this.surgeryProcedureFormViewModel = new SurgeryProcedureFormViewModel();
    //    this._ViewModel = this.surgeryProcedureFormViewModel;
    //    this.surgeryProcedureFormViewModel._SurgeryProcedure = this._TTObject as SurgeryProcedure;
    //this.surgeryProcedureFormViewModel._SurgeryProcedure.ProcedureDoctor = new ResUser();
    //    this.surgeryProcedureFormViewModel._SurgeryProcedure.Department = new ResSection();
    //    this.surgeryProcedureFormViewModel._SurgeryProcedure.SurgeryResponsibleDoctors = new Array<SurgeryResponsibleDoctor>();
    //    this.surgeryProcedureFormViewModel._SurgeryProcedure.ProcedureObject = new ProcedureDefinition();
    //    this.surgeryProcedureFormViewModel._SurgeryProcedure.AyniFarkliKesi = new AyniFarkliKesi();
    //}

    protected loadViewModel() {
        let that = this;

        //that.surgeryProcedureFormViewModel = this._ViewModel as SurgeryProcedureFormViewModel;
        that._TTObject = this.surgeryProcedureFormViewModel._SurgeryProcedure;
        //if (this.surgeryProcedureFormViewModel == null) // input olarak geliyor
        //    this.surgeryProcedureFormViewModel = new SurgeryProcedureFormViewModel();
        if (this.surgeryProcedureFormViewModel._SurgeryProcedure == null)
            this.surgeryProcedureFormViewModel._SurgeryProcedure = new SurgeryProcedure();
        let procedureDoctorObjectID = that.surgeryProcedureFormViewModel._SurgeryProcedure["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.surgeryProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.surgeryProcedureFormViewModel._SurgeryProcedure.ProcedureDoctor = procedureDoctor;
            }
        }
        let departmentObjectID = that.surgeryProcedureFormViewModel._SurgeryProcedure["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === "string")) {
            let department = that.surgeryProcedureFormViewModel.ResSections.find(o => o.ObjectID.toString() === departmentObjectID.toString());
            if (department) {
                that.surgeryProcedureFormViewModel._SurgeryProcedure.Department = department;
            }
        }
        that.surgeryProcedureFormViewModel._SurgeryProcedure.SurgeryResponsibleDoctors = that.surgeryProcedureFormViewModel.SurgeryResponsibleDoctorsGridList;
        for (let detailItem of that.surgeryProcedureFormViewModel.SurgeryResponsibleDoctorsGridList) {
            let responsibleDoctorObjectID = detailItem["ResponsibleDoctor"];
            if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === "string")) {
                let responsibleDoctor = that.surgeryProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
                if (responsibleDoctor) {
                    detailItem.ResponsibleDoctor = responsibleDoctor;
                }
            }
        }
        let procedureObjectObjectID = that.surgeryProcedureFormViewModel._SurgeryProcedure["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
            let procedureObject = that.surgeryProcedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
            if (procedureObject) {
                that.surgeryProcedureFormViewModel._SurgeryProcedure.ProcedureObject = procedureObject;
            }
        }
        let ayniFarkliKesiObjectID = that.surgeryProcedureFormViewModel._SurgeryProcedure["AyniFarkliKesi"];
        if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === "string")) {
            let ayniFarkliKesi = that.surgeryProcedureFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
            if (ayniFarkliKesi) {
                that.surgeryProcedureFormViewModel._SurgeryProcedure.AyniFarkliKesi = ayniFarkliKesi;
            }
        }



    }

    async ngOnInit() {
        //await this.load();
    }

    protected async setState(transDef: TTObjectStateTransitionDef) {
        try {
            this._TTObject.CurrentStateDefID = transDef.ToStateDefID;
            // await this._internalSaveForm(transDef);
            // this.ActionExecuted.emit(transDef);
        } catch (err) {
            this._TTObject.CurrentStateDefID = this._TTObject.PreviousStateDefID;
            // ServiceLocator.MessageService.showError(err);
            // this.ActionFailed.emit(err);
            // if (this.reThrowSetStateException) {
            //    throw err;
            //}
        }
    }

    public onAyniFarkliKesiChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.AyniFarkliKesi != event) {
                this._SurgeryProcedure.AyniFarkliKesi = event;
            }
        }
    }

    public onDepartmentChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.Department != event) {
                this._SurgeryProcedure.Department = event;
            }
        }
    }

    public onDescriptionOfProcedureObjectChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.DescriptionOfProcedureObject != event) {
                this._SurgeryProcedure.DescriptionOfProcedureObject = event;
            }
        }
    }

    public onIsScoliosisSurgeryChanged(event): void {
        if (this._SurgeryProcedure != null && this._SurgeryProcedure.IsScoliosisSurgery != event) {
            this._SurgeryProcedure.IsScoliosisSurgery = event;
        }
    }

    public onPositionChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.Position != event) {
                this._SurgeryProcedure.Position = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.ProcedureDoctor != event) {
                this._SurgeryProcedure.ProcedureDoctor = event;

                let recTime: Date = (await CommonService.RecTime());
                let a = await CommonService.PersonelIzinKontrol(this._SurgeryProcedure.ProcedureDoctor.ObjectID, recTime);
                if (a) {
                    this.messageService.showInfo(this._SurgeryProcedure.ProcedureDoctor.Name + " isimli doktor " + recTime + " tarihinde izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._SurgeryProcedure.ProcedureDoctor = null;
                    }, 500);

                }
            }
        }
    }

    public onSelectionChanged2() {
        // alert("selection");
        let a = 0;
    }

    public onProcedureObjectChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.ProcedureObject != event) {
                this._SurgeryProcedure.ProcedureObject = event;
            }
        }
    }

    public onRabsonGroupChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.RabsonGroup != event) {
                this._SurgeryProcedure.RabsonGroup = event;
            }
        }
    }

    public onSutPointChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.SutPoint != event) {
                this._SurgeryProcedure.SutPoint = event;
            }
        }
    }

    public onGilPointChanged(event): void {

    }

    public onIsComplicationSurgeryChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.IsComplicationSurgery != event) {
                this._SurgeryProcedure.IsComplicationSurgery = event;
                this.isComplicationSurgery = event;
            }
        }
    }

    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.isComplicationSurgery = this._SurgeryProcedure.IsComplicationSurgery;
        this.DropStateButton(SurgeryProcedure.SurgeryProcedureStates.Completed);
        if (this._surgeryProcedureFormViewModel.OnlyOneProcedureDoctor)
            this.ProcedureDoctor.ListFilterExpression = "USERRESOURCES(RESOURCE='" + this._SurgeryProcedure.Department.ObjectID + "').EXISTS";
    }

    public onComplicationDescriptionChanged(event): void {
        if (event != null) {
            if (this._SurgeryProcedure != null && this._SurgeryProcedure.ComplicationDescription != event) {
                this._SurgeryProcedure.ComplicationDescription = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.Position, "Value", this.__ttObject, "Position");
        redirectProperty(this.SutPoint, "Text", this.__ttObject, "SutPoint");
        redirectProperty(this.DescriptionOfProcedureObject, "Rtf", this.__ttObject, "DescriptionOfProcedureObject");
        redirectProperty(this.RabsonGroup, "Value", this.__ttObject, "RabsonGroup");
        redirectProperty(this.IsComplicationSurgery, "Value", this.__ttObject, "IsComplicationSurgery");
        redirectProperty(this.ComplicationDescription, "Text", this.__ttObject, "ComplicationDescription");
        redirectProperty(this.IsScoliosisSurgery, "Value", this.__ttObject, "IsScoliosisSurgery");
    }

    public initFormControls(): void {

        this.IsScoliosisSurgery = new TTVisual.TTCheckBox();
        this.IsScoliosisSurgery.Value = false;
        this.IsScoliosisSurgery.Text = "Skolyoz Ameliyatı";
        this.IsScoliosisSurgery.Title = "Skolyoz Ameliyatı";
        this.IsScoliosisSurgery.Name = "IsScoliosisSurgery";
        this.IsScoliosisSurgery.TabIndex = 19;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 17;

        this.labelRabsonGroup = new TTVisual.TTLabel();
        this.labelRabsonGroup.Text = i18n("M20639", "Rabson Grubu");
        this.labelRabsonGroup.Name = "labelRabsonGroup";
        this.labelRabsonGroup.TabIndex = 16;

        this.RabsonGroup = new TTVisual.TTEnumComboBox();
        this.RabsonGroup.DataTypeName = "RabsonEnum";
        this.RabsonGroup.Name = "RabsonGroup";
        this.RabsonGroup.TabIndex = 15;

        this.labelDepartment = new TTVisual.TTLabel();
        this.labelDepartment.Text = i18n("M10866", "Ameliyatı Yapan Bölüm");
        this.labelDepartment.Name = "labelDepartment";
        this.labelDepartment.TabIndex = 14;

        this.Department = new TTVisual.TTObjectListBox();
        this.Department.ReadOnly = true;
        this.Department.ListDefName = "ResourceListDefinition";
        this.Department.Name = "Department";
        this.Department.TabIndex = 13;

        this.EuroScoreButton = new TTVisual.TTButton();
        this.EuroScoreButton.Text = "Kardiak Risk Skoru";
        this.EuroScoreButton.Name = "EuroScoreButton";
        this.EuroScoreButton.TabIndex = 12;

        this.SurgeryResponsibleDoctors = new TTVisual.TTGrid();
        this.SurgeryResponsibleDoctors.Name = "SurgeryResponsibleDoctors";
        this.SurgeryResponsibleDoctors.TabIndex = 11;
        //this.SurgeryResponsibleDoctors.Height = 120;
        this.SurgeryResponsibleDoctors.ShowFilterCombo = true;
        this.SurgeryResponsibleDoctors.FilterColumnName = "ResponsibleDoctorSurgeryResponsibleDoctor";
        this.SurgeryResponsibleDoctors.FilterLabel = i18n("M22139", "Sorumlu Cerrah Ekle");
        this.SurgeryResponsibleDoctors.Filter = { ListDefName: "SpecialistDoctorListDefinition" };
        this.SurgeryResponsibleDoctors.AllowUserToAddRows = false;
        this.SurgeryResponsibleDoctors.DeleteButtonWidth = "5%";
        this.SurgeryResponsibleDoctors.ShowTotalNumberOfRows = false;
        this.SurgeryResponsibleDoctors.IsFilterLabelSingleLine = false;

        this.ResponsibleDoctorSurgeryResponsibleDoctor = new TTVisual.TTListBoxColumn();
        this.ResponsibleDoctorSurgeryResponsibleDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ResponsibleDoctorSurgeryResponsibleDoctor.DataMember = "ResponsibleDoctor";
        this.ResponsibleDoctorSurgeryResponsibleDoctor.DisplayIndex = 0;
        this.ResponsibleDoctorSurgeryResponsibleDoctor.HeaderText = i18n("M22137", "Sorumlu Cerrah");
        this.ResponsibleDoctorSurgeryResponsibleDoctor.Name = "ResponsibleDoctorSurgeryResponsibleDoctor";
        this.ResponsibleDoctorSurgeryResponsibleDoctor.Width = "80%";

        this.labelProcedureObject = new TTVisual.TTLabel();
        this.labelProcedureObject.Text = i18n("M16818", "İşlem");
        this.labelProcedureObject.Name = "labelProcedureObject";
        this.labelProcedureObject.TabIndex = 10;

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.ListDefName = "SurgeryListDefinition";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 9;
        this.ProcedureObject.Enabled = false;

        this.labelAyniFarkliKesi = new TTVisual.TTLabel();
        this.labelAyniFarkliKesi.Text = "Kesi Bilgisi";
        this.labelAyniFarkliKesi.Name = "labelAyniFarkliKesi";
        this.labelAyniFarkliKesi.TabIndex = 8;

        this.AyniFarkliKesi = new TTVisual.TTObjectListBox();
        this.AyniFarkliKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.AyniFarkliKesi.Name = "AyniFarkliKesi";
        this.AyniFarkliKesi.TabIndex = 7;
        this.AyniFarkliKesi.AutoCompleteDialogWidth = "50%";

        this.labelSutPoint = new TTVisual.TTLabel();
        this.labelSutPoint.Text = i18n("M22402", "Sut Puanı");
        this.labelSutPoint.Name = "labelSutPoint";
        this.labelSutPoint.TabIndex = 5;

        this.SutPoint = new TTVisual.TTTextBox();
        this.SutPoint.Name = "SutPoint";
        this.SutPoint.TabIndex = 4;
        this.SutPoint.ReadOnly = true;
        this.SutPoint.Enabled = false;


        this.GilPoint = new TTVisual.TTTextBox();
        this.GilPoint.Name = "GilPoint";
        this.GilPoint.TabIndex = 4;
        this.GilPoint.ReadOnly = true;
        this.GilPoint.Enabled = false;

        this.labelPosition = new TTVisual.TTLabel();
        this.labelPosition.Text = i18n("M22824", "Taraf");
        this.labelPosition.Name = "labelPosition";
        this.labelPosition.TabIndex = 3;

        this.Position = new TTVisual.TTEnumComboBox();
        this.Position.DataTypeName = "SurgeryLeftRight";
        this.Position.Name = "Position";
        this.Position.TabIndex = 2;

        this.labelDescriptionOfProcedureObject = new TTVisual.TTLabel();
        this.labelDescriptionOfProcedureObject.Text = i18n("M12678", "Detaylı Tanım");
        this.labelDescriptionOfProcedureObject.Name = "labelDescriptionOfProcedureObject";
        this.labelDescriptionOfProcedureObject.TabIndex = 1;

        this.DescriptionOfProcedureObject = new TTVisual.TTRichTextBoxControl();
        this.DescriptionOfProcedureObject.Name = "DescriptionOfProcedureObject";
        this.DescriptionOfProcedureObject.TabIndex = 0;

        this.lableGilPoint = new TTVisual.TTLabel();
        this.lableGilPoint.Text = i18n("M14789", "Gil Puanı");
        this.lableGilPoint.Name = "lableGilPoint";
        this.lableGilPoint.TabIndex = 5;

        this.lableResponsibleDoctor = new TTVisual.TTLabel();
        this.lableResponsibleDoctor.Text = i18n("M22141", "Sorumlu Cerrahlar");
        this.lableResponsibleDoctor.Name = "lableResponsibleDoctor";
        this.lableResponsibleDoctor.TabIndex = 1;

        this.IsComplicationSurgery = new TTVisual.TTCheckBox();
        this.IsComplicationSurgery.Value = false;
        this.IsComplicationSurgery.Title = i18n("M17723", "Komplikasyon Ameliyatı");
        this.IsComplicationSurgery.Name = "IsComplicationSurgery";
        this.IsComplicationSurgery.TabIndex = 122;

        this.labelComplicationDescription = new TTVisual.TTLabel();
        this.labelComplicationDescription.Text = i18n("M17722", "Komplikasyon Açıklaması");
        this.labelComplicationDescription.Name = "labelComplicationDescription";
        this.labelComplicationDescription.TabIndex = 124;

        this.ComplicationDescription = new TTVisual.TTTextBox();
        this.ComplicationDescription.Multiline = true;
        this.ComplicationDescription.Name = "ComplicationDescription";
        this.ComplicationDescription.TabIndex = 123;
        this.SurgeryResponsibleDoctorsColumns = [this.ResponsibleDoctorSurgeryResponsibleDoctor];
        this.Controls = [this.IsScoliosisSurgery, this.ProcedureDoctor, this.labelRabsonGroup, this.RabsonGroup, this.IsComplicationSurgery, this.labelComplicationDescription, this.ComplicationDescription, this.labelDepartment, this.Department, this.EuroScoreButton, this.SurgeryResponsibleDoctors, this.ResponsibleDoctorSurgeryResponsibleDoctor, this.labelProcedureObject, this.ProcedureObject, this.labelAyniFarkliKesi, this.AyniFarkliKesi, this.labelSutPoint, this.SutPoint, this.GilPoint, this.labelPosition, this.Position, this.labelDescriptionOfProcedureObject, this.DescriptionOfProcedureObject, this.lableGilPoint, this.lableResponsibleDoctor];

    }


}
