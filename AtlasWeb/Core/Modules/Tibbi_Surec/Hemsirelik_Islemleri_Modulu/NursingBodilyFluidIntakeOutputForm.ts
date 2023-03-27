//$CF29F604
import { Component, OnInit } from '@angular/core';
import { NursingBodilyFluidIntakeOutputFormViewModel } from './NursingBodilyFluidIntakeOutputFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NursingBodilyFluidIntakeOutput } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";

@Component({
    selector: 'NursingBodilyFluidIntakeOutputForm',
    templateUrl: './NursingBodilyFluidIntakeOutputForm.html',
    providers: [MessageService]
})
export class NursingBodilyFluidIntakeOutputForm extends TTVisual.TTForm  implements OnInit, IModal {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    Aspiration: TTVisual.ITTTextBox;
    BloodLoss: TTVisual.ITTTextBox;
    Drainage1: TTVisual.ITTTextBox;
    Drainage2: TTVisual.ITTTextBox;
    Drainage3: TTVisual.ITTTextBox;
    Drainage4: TTVisual.ITTTextBox;
    FluidIntakeFurtherExplanation: TTVisual.ITTTextBox;
    FluidOutputFurtherExplanation: TTVisual.ITTTextBox;
    Irrigation: TTVisual.ITTTextBox;
    intakeLabel: TTVisual.ITTLabel;
    labelApplicationDate: TTVisual.ITTLabel;
    labelAspiration: TTVisual.ITTLabel;
    labelBloodLoss: TTVisual.ITTLabel;
    labelDrainage1: TTVisual.ITTLabel;
    labelDrainage2: TTVisual.ITTLabel;
    labelDrainage3: TTVisual.ITTLabel;
    labelDrainage4: TTVisual.ITTLabel;
    labelFluidIntakeFurtherExplanation: TTVisual.ITTLabel;
    labelFluidOutputFurtherExplanation: TTVisual.ITTLabel;
    labelIrrigation: TTVisual.ITTLabel;
    labelMedicine: TTVisual.ITTLabel;
    labelMilkAmount: TTVisual.ITTLabel;
    labelMilkType: TTVisual.ITTLabel;
    labelNasogastricTube: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    labelOralIntake: TTVisual.ITTLabel;
    labelOtherFluidIntake: TTVisual.ITTLabel;
    labelOtherFluidOutput: TTVisual.ITTLabel;
    labelPAC: TTVisual.ITTLabel;
    labelSludge: TTVisual.ITTLabel;
    labelStool: TTVisual.ITTLabel;
    labelSuppliedBlood: TTVisual.ITTLabel;
    labelUrine: TTVisual.ITTLabel;
    labelVenousFluid: TTVisual.ITTLabel;
    labelVomit: TTVisual.ITTLabel;
    Medicine: TTVisual.ITTTextBox;
    MilkAmount: TTVisual.ITTTextBox;
    MilkType: TTVisual.ITTTextBox;
    NasogastricTube: TTVisual.ITTTextBox;
    Note: TTVisual.ITTTextBox;
    OralIntake: TTVisual.ITTTextBox;
    OtherFluidIntake: TTVisual.ITTTextBox;
    OtherFluidOutput: TTVisual.ITTTextBox;
    outputLabel: TTVisual.ITTLabel;
    PAC: TTVisual.ITTTextBox;
    Sludge: TTVisual.ITTTextBox;
    Stool: TTVisual.ITTTextBox;
    SuppliedBlood: TTVisual.ITTTextBox;
    Urine: TTVisual.ITTTextBox;
    VenousFluid: TTVisual.ITTTextBox;
    Vomit: TTVisual.ITTTextBox;
    public nursingBodilyFluidIntakeOutputFormViewModel: NursingBodilyFluidIntakeOutputFormViewModel = new NursingBodilyFluidIntakeOutputFormViewModel();
    public get _NursingBodilyFluidIntakeOutput(): NursingBodilyFluidIntakeOutput {
        return this._TTObject as NursingBodilyFluidIntakeOutput;
    }
    private NursingBodilyFluidIntakeOutputForm_DocumentUrl: string = '/api/NursingBodilyFluidIntakeOutputService/NursingBodilyFluidIntakeOutputForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super('NURSINGBODYFLUIDANALYSIS', '');
        this._DocumentServiceUrl = this.NursingBodilyFluidIntakeOutputForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingBodilyFluidIntakeOutput();
        this.nursingBodilyFluidIntakeOutputFormViewModel = new NursingBodilyFluidIntakeOutputFormViewModel();
        this._ViewModel = this.nursingBodilyFluidIntakeOutputFormViewModel;
        this.nursingBodilyFluidIntakeOutputFormViewModel._NursingBodilyFluidIntakeOutput = this._TTObject as NursingBodilyFluidIntakeOutput;
    }

    protected loadViewModel() {
        let that = this;
        that.nursingBodilyFluidIntakeOutputFormViewModel = this._ViewModel as NursingBodilyFluidIntakeOutputFormViewModel;
        that._TTObject = this.nursingBodilyFluidIntakeOutputFormViewModel._NursingBodilyFluidIntakeOutput;
        if (this.nursingBodilyFluidIntakeOutputFormViewModel == null)
            this.nursingBodilyFluidIntakeOutputFormViewModel = new NursingBodilyFluidIntakeOutputFormViewModel();
        if (this.nursingBodilyFluidIntakeOutputFormViewModel._NursingBodilyFluidIntakeOutput == null)
            this.nursingBodilyFluidIntakeOutputFormViewModel._NursingBodilyFluidIntakeOutput = new NursingBodilyFluidIntakeOutput();

    }


    protected _modalInfo: ModalInfo;

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    public async setInputParam(value: any) {

    }

    async ngOnInit() {
        await this.load();
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.ApplicationDate != event) {
                this._NursingBodilyFluidIntakeOutput.ApplicationDate = event;
            }
        }
    }

    public onAspirationChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Aspiration != event) {
                this._NursingBodilyFluidIntakeOutput.Aspiration = event;
            }
        }
    }

    public onBloodLossChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.BloodLoss != event) {
                this._NursingBodilyFluidIntakeOutput.BloodLoss = event;
            }
        }
    }

    public onDrainage1Changed(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Drainage1 != event) {
                this._NursingBodilyFluidIntakeOutput.Drainage1 = event;
            }
        }
    }

    public onDrainage2Changed(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Drainage2 != event) {
                this._NursingBodilyFluidIntakeOutput.Drainage2 = event;
            }
        }
    }

    public onDrainage3Changed(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Drainage3 != event) {
                this._NursingBodilyFluidIntakeOutput.Drainage3 = event;
            }
        }
    }

    public onDrainage4Changed(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Drainage4 != event) {
                this._NursingBodilyFluidIntakeOutput.Drainage4 = event;
            }
        }
    }

    public onFluidIntakeFurtherExplanationChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.FluidIntakeFurtherExplanation != event) {
                this._NursingBodilyFluidIntakeOutput.FluidIntakeFurtherExplanation = event;
            }
        }
    }

    public onFluidOutputFurtherExplanationChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.FluidOutputFurtherExplanation != event) {
                this._NursingBodilyFluidIntakeOutput.FluidOutputFurtherExplanation = event;
            }
        }
    }

    public onIrrigationChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Irrigation != event) {
                this._NursingBodilyFluidIntakeOutput.Irrigation = event;
            }
        }
    }

    public onMedicineChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Medicine != event) {
                this._NursingBodilyFluidIntakeOutput.Medicine = event;
            }
        }
    }

    public onMilkAmountChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.MilkAmount != event) {
                this._NursingBodilyFluidIntakeOutput.MilkAmount = event;
            }
        }
    }

    public onMilkTypeChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.MilkType != event) {
                this._NursingBodilyFluidIntakeOutput.MilkType = event;
            }
        }
    }

    public onNasogastricTubeChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.NasogastricTube != event) {
                this._NursingBodilyFluidIntakeOutput.NasogastricTube = event;
            }
        }
    }

    public onNoteChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Note != event) {
                this._NursingBodilyFluidIntakeOutput.Note = event;
            }
        }
    }

    public onOralIntakeChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.OralIntake != event) {
                this._NursingBodilyFluidIntakeOutput.OralIntake = event;
            }
        }
    }

    public onOtherFluidIntakeChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.OtherFluidIntake != event) {
                this._NursingBodilyFluidIntakeOutput.OtherFluidIntake = event;
            }
        }
    }

    public onOtherFluidOutputChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.OtherFluidOutput != event) {
                this._NursingBodilyFluidIntakeOutput.OtherFluidOutput = event;
            }
        }
    }

    public onPACChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.PAC != event) {
                this._NursingBodilyFluidIntakeOutput.PAC = event;
            }
        }
    }

    public onSludgeChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Sludge != event) {
                this._NursingBodilyFluidIntakeOutput.Sludge = event;
            }
        }
    }

    public onStoolChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Stool != event) {
                this._NursingBodilyFluidIntakeOutput.Stool = event;
            }
        }
    }

    public onSuppliedBloodChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.SuppliedBlood != event) {
                this._NursingBodilyFluidIntakeOutput.SuppliedBlood = event;
            }
        }
    }

    public onUrineChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Urine != event) {
                this._NursingBodilyFluidIntakeOutput.Urine = event;
            }
        }
    }

    public onVenousFluidChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.VenousFluid != event) {
                this._NursingBodilyFluidIntakeOutput.VenousFluid = event;
            }
        }
    }

    public onVomitChanged(event): void {
        if (event != null) {
            if (this._NursingBodilyFluidIntakeOutput != null && this._NursingBodilyFluidIntakeOutput.Vomit != event) {
                this._NursingBodilyFluidIntakeOutput.Vomit = event;
            }
        }
    }


    protected async save() {
        /*if (this._TTObject.IsNew == true) // ilk kaydetme işlemi Hizmetin  kaydet metodu ile yapılacak
        {
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._ViewModel);
        }
        else // Daha sonra Kendi Obje savini Kullanılacak
            super.save();*/

        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._TTObject);
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.Note, "Text", this.__ttObject, "Note");
        redirectProperty(this.OralIntake, "Text", this.__ttObject, "OralIntake");
        redirectProperty(this.Urine, "Text", this.__ttObject, "Urine");
        redirectProperty(this.NasogastricTube, "Text", this.__ttObject, "NasogastricTube");
        redirectProperty(this.Aspiration, "Text", this.__ttObject, "Aspiration");
        redirectProperty(this.VenousFluid, "Text", this.__ttObject, "VenousFluid");
        redirectProperty(this.Vomit, "Text", this.__ttObject, "Vomit");
        redirectProperty(this.Medicine, "Text", this.__ttObject, "Medicine");
        redirectProperty(this.SuppliedBlood, "Text", this.__ttObject, "SuppliedBlood");
        redirectProperty(this.Drainage2, "Text", this.__ttObject, "Drainage2");
        redirectProperty(this.Irrigation, "Text", this.__ttObject, "Irrigation");
        redirectProperty(this.Drainage3, "Text", this.__ttObject, "Drainage3");
        redirectProperty(this.MilkType, "Text", this.__ttObject, "MilkType");
        redirectProperty(this.MilkAmount, "Text", this.__ttObject, "MilkAmount");
        redirectProperty(this.Sludge, "Text", this.__ttObject, "Sludge");
        redirectProperty(this.BloodLoss, "Text", this.__ttObject, "BloodLoss");
        redirectProperty(this.PAC, "Text", this.__ttObject, "PAC");
        redirectProperty(this.OtherFluidOutput, "Text", this.__ttObject, "OtherFluidOutput");
        redirectProperty(this.OtherFluidIntake, "Text", this.__ttObject, "OtherFluidIntake");
        redirectProperty(this.FluidIntakeFurtherExplanation, "Text", this.__ttObject, "FluidIntakeFurtherExplanation");
        redirectProperty(this.FluidOutputFurtherExplanation, "Text", this.__ttObject, "FluidOutputFurtherExplanation");
        redirectProperty(this.Stool, "Text", this.__ttObject, "Stool");
        redirectProperty(this.Drainage4, "Text", this.__ttObject, "Drainage4");
        redirectProperty(this.Drainage1, "Text", this.__ttObject, "Drainage1");
    }

    public initFormControls(): void {
        this.outputLabel = new TTVisual.TTLabel();
        this.outputLabel.Text = "Çıkan Sıvı Bilgileri";
        this.outputLabel.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.outputLabel.Name = "outputLabel";
        this.outputLabel.TabIndex = 51;

        this.intakeLabel = new TTVisual.TTLabel();
        this.intakeLabel.Text = "Alınan Sıvı Bilgileri";
        this.intakeLabel.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.intakeLabel.Name = "intakeLabel";
        this.intakeLabel.TabIndex = 50;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 49;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 48;

        this.labelOtherFluidOutput = new TTVisual.TTLabel();
        this.labelOtherFluidOutput.Text = i18n("M12780", "Diğer");
        this.labelOtherFluidOutput.Name = "labelOtherFluidOutput";
        this.labelOtherFluidOutput.TabIndex = 47;

        this.OtherFluidOutput = new TTVisual.TTTextBox();
        this.OtherFluidOutput.Name = "OtherFluidOutput";
        this.OtherFluidOutput.TabIndex = 46;

        this.BloodLoss = new TTVisual.TTTextBox();
        this.BloodLoss.Name = "BloodLoss";
        this.BloodLoss.TabIndex = 44;

        this.Stool = new TTVisual.TTTextBox();
        this.Stool.Name = "Stool";
        this.Stool.TabIndex = 42;

        this.Drainage4 = new TTVisual.TTTextBox();
        this.Drainage4.Name = "Drainage4";
        this.Drainage4.TabIndex = 40;

        this.Drainage3 = new TTVisual.TTTextBox();
        this.Drainage3.Name = "Drainage3";
        this.Drainage3.TabIndex = 38;

        this.Drainage2 = new TTVisual.TTTextBox();
        this.Drainage2.Name = "Drainage2";
        this.Drainage2.TabIndex = 36;

        this.Drainage1 = new TTVisual.TTTextBox();
        this.Drainage1.Name = "Drainage1";
        this.Drainage1.TabIndex = 34;

        this.Vomit = new TTVisual.TTTextBox();
        this.Vomit.Name = "Vomit";
        this.Vomit.TabIndex = 32;

        this.Aspiration = new TTVisual.TTTextBox();
        this.Aspiration.Name = "Aspiration";
        this.Aspiration.TabIndex = 30;

        this.Urine = new TTVisual.TTTextBox();
        this.Urine.Name = "Urine";
        this.Urine.TabIndex = 28;

        this.FluidOutputFurtherExplanation = new TTVisual.TTTextBox();
        this.FluidOutputFurtherExplanation.Name = "FluidOutputFurtherExplanation";
        this.FluidOutputFurtherExplanation.TabIndex = 26;

        this.FluidIntakeFurtherExplanation = new TTVisual.TTTextBox();
        this.FluidIntakeFurtherExplanation.Name = "FluidIntakeFurtherExplanation";
        this.FluidIntakeFurtherExplanation.TabIndex = 24;

        this.OtherFluidIntake = new TTVisual.TTTextBox();
        this.OtherFluidIntake.Name = "OtherFluidIntake";
        this.OtherFluidIntake.TabIndex = 22;

        this.PAC = new TTVisual.TTTextBox();
        this.PAC.Name = "PAC";
        this.PAC.TabIndex = 20;

        this.Sludge = new TTVisual.TTTextBox();
        this.Sludge.Name = "Sludge";
        this.Sludge.TabIndex = 18;

        this.MilkAmount = new TTVisual.TTTextBox();
        this.MilkAmount.Name = "MilkAmount";
        this.MilkAmount.TabIndex = 16;

        this.MilkType = new TTVisual.TTTextBox();
        this.MilkType.Name = "MilkType";
        this.MilkType.TabIndex = 14;

        this.Irrigation = new TTVisual.TTTextBox();
        this.Irrigation.Name = "Irrigation";
        this.Irrigation.TabIndex = 12;

        this.SuppliedBlood = new TTVisual.TTTextBox();
        this.SuppliedBlood.Name = "SuppliedBlood";
        this.SuppliedBlood.TabIndex = 10;

        this.Medicine = new TTVisual.TTTextBox();
        this.Medicine.Name = "Medicine";
        this.Medicine.TabIndex = 8;

        this.VenousFluid = new TTVisual.TTTextBox();
        this.VenousFluid.Name = "VenousFluid";
        this.VenousFluid.TabIndex = 6;

        this.NasogastricTube = new TTVisual.TTTextBox();
        this.NasogastricTube.Name = "NasogastricTube";
        this.NasogastricTube.TabIndex = 4;

        this.OralIntake = new TTVisual.TTTextBox();
        this.OralIntake.Name = "OralIntake";
        this.OralIntake.TabIndex = 2;

        this.Note = new TTVisual.TTTextBox();
        this.Note.Name = "Note";
        this.Note.TabIndex = 0;

        this.labelBloodLoss = new TTVisual.TTLabel();
        this.labelBloodLoss.Text = "Kaybedilen Kan";
        this.labelBloodLoss.Name = "labelBloodLoss";
        this.labelBloodLoss.TabIndex = 45;

        this.labelStool = new TTVisual.TTLabel();
        this.labelStool.Text = "Dışkı";
        this.labelStool.Name = "labelStool";
        this.labelStool.TabIndex = 43;

        this.labelDrainage4 = new TTVisual.TTLabel();
        this.labelDrainage4.Text = "Drenaj (4)";
        this.labelDrainage4.Name = "labelDrainage4";
        this.labelDrainage4.TabIndex = 41;

        this.labelDrainage3 = new TTVisual.TTLabel();
        this.labelDrainage3.Text = "Drenaj (3)";
        this.labelDrainage3.Name = "labelDrainage3";
        this.labelDrainage3.TabIndex = 39;

        this.labelDrainage2 = new TTVisual.TTLabel();
        this.labelDrainage2.Text = "Drenaj (2)";
        this.labelDrainage2.Name = "labelDrainage2";
        this.labelDrainage2.TabIndex = 37;

        this.labelDrainage1 = new TTVisual.TTLabel();
        this.labelDrainage1.Text = "Drenaj (1)";
        this.labelDrainage1.Name = "labelDrainage1";
        this.labelDrainage1.TabIndex = 35;

        this.labelVomit = new TTVisual.TTLabel();
        this.labelVomit.Text = i18n("M18118", "Kusma");
        this.labelVomit.Name = "labelVomit";
        this.labelVomit.TabIndex = 33;

        this.labelAspiration = new TTVisual.TTLabel();
        this.labelAspiration.Text = "Aspirasyon";
        this.labelAspiration.Name = "labelAspiration";
        this.labelAspiration.TabIndex = 31;

        this.labelUrine = new TTVisual.TTLabel();
        this.labelUrine.Text = i18n("M16190", "İdrar");
        this.labelUrine.Name = "labelUrine";
        this.labelUrine.TabIndex = 29;

        this.labelFluidOutputFurtherExplanation = new TTVisual.TTLabel();
        this.labelFluidOutputFurtherExplanation.Text = "Diğer Açıklamalar";
        this.labelFluidOutputFurtherExplanation.Name = "labelFluidOutputFurtherExplanation";
        this.labelFluidOutputFurtherExplanation.TabIndex = 27;

        this.labelFluidIntakeFurtherExplanation = new TTVisual.TTLabel();
        this.labelFluidIntakeFurtherExplanation.Text = "Diğer Açıklamalar";
        this.labelFluidIntakeFurtherExplanation.Name = "labelFluidIntakeFurtherExplanation";
        this.labelFluidIntakeFurtherExplanation.TabIndex = 25;

        this.labelOtherFluidIntake = new TTVisual.TTLabel();
        this.labelOtherFluidIntake.Text = i18n("M12780", "Diğer");
        this.labelOtherFluidIntake.Name = "labelOtherFluidIntake";
        this.labelOtherFluidIntake.TabIndex = 23;

        this.labelPAC = new TTVisual.TTLabel();
        this.labelPAC.Text = "PAC";
        this.labelPAC.Name = "labelPAC";
        this.labelPAC.TabIndex = 21;

        this.labelSludge = new TTVisual.TTLabel();
        this.labelSludge.Text = "Tortu";
        this.labelSludge.Name = "labelSludge";
        this.labelSludge.TabIndex = 19;

        this.labelMilkAmount = new TTVisual.TTLabel();
        this.labelMilkAmount.Text = "Süt Miktarı";
        this.labelMilkAmount.Name = "labelMilkAmount";
        this.labelMilkAmount.TabIndex = 17;

        this.labelMilkType = new TTVisual.TTLabel();
        this.labelMilkType.Text = "Süt Tipi";
        this.labelMilkType.Name = "labelMilkType";
        this.labelMilkType.TabIndex = 15;

        this.labelIrrigation = new TTVisual.TTLabel();
        this.labelIrrigation.Text = "İrigasyon";
        this.labelIrrigation.Name = "labelIrrigation";
        this.labelIrrigation.TabIndex = 13;

        this.labelSuppliedBlood = new TTVisual.TTLabel();
        this.labelSuppliedBlood.Text = "Verilen Kan";
        this.labelSuppliedBlood.Name = "labelSuppliedBlood";
        this.labelSuppliedBlood.TabIndex = 11;

        this.labelMedicine = new TTVisual.TTLabel();
        this.labelMedicine.Text = i18n("M16389", "İlaçlar");
        this.labelMedicine.Name = "labelMedicine";
        this.labelMedicine.TabIndex = 9;

        this.labelVenousFluid = new TTVisual.TTLabel();
        this.labelVenousFluid.Text = "Damar İçi Sıvılar";
        this.labelVenousFluid.Name = "labelVenousFluid";
        this.labelVenousFluid.TabIndex = 7;

        this.labelNasogastricTube = new TTVisual.TTLabel();
        this.labelNasogastricTube.Text = "Nasogastrik Sonda";
        this.labelNasogastricTube.Name = "labelNasogastricTube";
        this.labelNasogastricTube.TabIndex = 5;

        this.labelOralIntake = new TTVisual.TTLabel();
        this.labelOralIntake.Text = "Oral";
        this.labelOralIntake.Name = "labelOralIntake";
        this.labelOralIntake.TabIndex = 3;

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = i18n("M19476", "Not");
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 1;

        this.Controls = [this.outputLabel, this.intakeLabel, this.labelApplicationDate, this.ApplicationDate, this.labelOtherFluidOutput, this.OtherFluidOutput, this.BloodLoss, this.Stool, this.Drainage4, this.Drainage3, this.Drainage2, this.Drainage1, this.Vomit, this.Aspiration, this.Urine, this.FluidOutputFurtherExplanation, this.FluidIntakeFurtherExplanation, this.OtherFluidIntake, this.PAC, this.Sludge, this.MilkAmount, this.MilkType, this.Irrigation, this.SuppliedBlood, this.Medicine, this.VenousFluid, this.NasogastricTube, this.OralIntake, this.Note, this.labelBloodLoss, this.labelStool, this.labelDrainage4, this.labelDrainage3, this.labelDrainage2, this.labelDrainage1, this.labelVomit, this.labelAspiration, this.labelUrine, this.labelFluidOutputFurtherExplanation, this.labelFluidIntakeFurtherExplanation, this.labelOtherFluidIntake, this.labelPAC, this.labelSludge, this.labelMilkAmount, this.labelMilkType, this.labelIrrigation, this.labelSuppliedBlood, this.labelMedicine, this.labelVenousFluid, this.labelNasogastricTube, this.labelOralIntake, this.labelNote];

    }


}
