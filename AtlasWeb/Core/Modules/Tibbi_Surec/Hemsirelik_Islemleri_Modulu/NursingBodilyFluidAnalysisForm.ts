//$D5B1EE96
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingBodilyFluidAnalysisFormViewModel } from './NursingBodilyFluidAnalysisFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingBodyFluidAnalysis } from 'NebulaClient/Model/AtlasClientModel';
import { NursingBodilyFluidIntakeOutput } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo } from "Fw/Models/ModalInfo";
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';

@Component({
    selector: 'NursingBodilyFluidAnalysisForm',
    templateUrl: './NursingBodilyFluidAnalysisForm.html',
    providers: [MessageService]
})
export class NursingBodilyFluidAnalysisForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    ApplicationDateNursingBodilyFluidIntakeOutput: TTVisual.ITTDateTimePickerColumn;
    ApplicationUserNursingBodilyFluidIntakeOutput: TTVisual.ITTListBoxColumn;
    AspirationNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    BloodLossNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    Drainage1NursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    Drainage2NursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    Drainage3NursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    Drainage4NursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    EntryDateNursingBodilyFluidIntakeOutput: TTVisual.ITTDateTimePickerColumn;
    FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    IrrigationNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    labelApplicationDate: TTVisual.ITTLabel;
    labelTotalAspiration: TTVisual.ITTLabel;
    labelTotalBloodLoss: TTVisual.ITTLabel;
    labelTotalDrainage: TTVisual.ITTLabel;
    labelTotalIrrigation: TTVisual.ITTLabel;
    labelTotalMed: TTVisual.ITTLabel;
    labelTotalMilkAmount: TTVisual.ITTLabel;
    labelTotalNGC: TTVisual.ITTLabel;
    labelTotalOralIntake: TTVisual.ITTLabel;
    labelTotalOtherBodilyFluidLoss: TTVisual.ITTLabel;
    labelTotalOtherBodilyFluidsTaken: TTVisual.ITTLabel;
    labelTotalPAC: TTVisual.ITTLabel;
    labelTotalSludge: TTVisual.ITTLabel;
    labelTotalStool: TTVisual.ITTLabel;
    labelTotalSuppliedBlood: TTVisual.ITTLabel;
    labelTotalUrine: TTVisual.ITTLabel;
    labelTotalVenousFluid: TTVisual.ITTLabel;
    labelTotalVomit: TTVisual.ITTLabel;
    MedicineNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    MilkAmountNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    MilkTypeNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    NasogastricTubeNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    NoteNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    NursingApplicationNursingBodilyFluidIntakeOutput: TTVisual.ITTListBoxColumn;
    NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput: TTVisual.ITTListBoxColumn;
    OralIntakeNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    OtherFluidIntakeNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    OtherFluidOutputNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    PACNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    SludgeNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    StoolNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    SuppliedBloodNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    TotalAspiration: TTVisual.ITTTextBox;
    TotalBloodLoss: TTVisual.ITTTextBox;
    TotalDrainage: TTVisual.ITTTextBox;
    TotalIrrigation: TTVisual.ITTTextBox;
    TotalMed: TTVisual.ITTTextBox;
    TotalMilkAmount: TTVisual.ITTTextBox;
    TotalNGC: TTVisual.ITTTextBox;
    TotalOralIntake: TTVisual.ITTTextBox;
    TotalOtherBodilyFluidLoss: TTVisual.ITTTextBox;
    TotalOtherBodilyFluidsTaken: TTVisual.ITTTextBox;
    TotalPAC: TTVisual.ITTTextBox;
    TotalSludge: TTVisual.ITTTextBox;
    TotalStool: TTVisual.ITTTextBox;
    TotalSuppliedBlood: TTVisual.ITTTextBox;
    TotalUrine: TTVisual.ITTTextBox;
    TotalVenousFluid: TTVisual.ITTTextBox;
    TotalVomit: TTVisual.ITTTextBox;
    UrineNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    VenousFluidNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    VomitNursingBodilyFluidIntakeOutput: TTVisual.ITTTextBoxColumn;
    public nursingBodilyFluidAnalysisFormViewModel: NursingBodilyFluidAnalysisFormViewModel = new NursingBodilyFluidAnalysisFormViewModel();
    public get _NursingBodyFluidAnalysis(): NursingBodyFluidAnalysis {
        return this._TTObject as NursingBodyFluidAnalysis;
    }
    private NursingBodilyFluidAnalysisForm_DocumentUrl: string = '/api/NursingBodyFluidAnalysisService/NursingBodilyFluidAnalysisForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingBodilyFluidAnalysisForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingBodyFluidAnalysis();
        this.nursingBodilyFluidAnalysisFormViewModel = new NursingBodilyFluidAnalysisFormViewModel();
        this._ViewModel = this.nursingBodilyFluidAnalysisFormViewModel;
        this.nursingBodilyFluidAnalysisFormViewModel._NursingBodyFluidAnalysis = this._TTObject as NursingBodyFluidAnalysis;
        this.nursingBodilyFluidAnalysisFormViewModel._NursingBodyFluidAnalysis.FluidIntakeOutputGrids = new Array<NursingBodilyFluidIntakeOutput>();
    }

    protected loadViewModel() {
        let that = this;
        that.nursingBodilyFluidAnalysisFormViewModel = this._ViewModel as NursingBodilyFluidAnalysisFormViewModel;
        that._TTObject = this.nursingBodilyFluidAnalysisFormViewModel._NursingBodyFluidAnalysis;
        if (this.nursingBodilyFluidAnalysisFormViewModel == null)
            this.nursingBodilyFluidAnalysisFormViewModel = new NursingBodilyFluidAnalysisFormViewModel();
        if (this.nursingBodilyFluidAnalysisFormViewModel._NursingBodyFluidAnalysis == null)
            this.nursingBodilyFluidAnalysisFormViewModel._NursingBodyFluidAnalysis = new NursingBodyFluidAnalysis();
    }

    async ngOnInit() {
        await this.load();
    }

    openFluidIntakeOutputForm(objectID?: string) {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = "NursingBodilyFluidIntakeOutputForm";
            componentInfo.ModuleName = "HemsirelikIslemleriModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/HemsirelikIslemleriModule';

            //componentInfo.InputParam = this;
            if (objectID != null)
                componentInfo.objectID = objectID;

            let modalInfo: ModalInfo = new ModalInfo();
            //modalInfo.Title = ;
            modalInfo.Width = 700;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let fluidIntakeOutput = inner.Param as NursingBodilyFluidIntakeOutput;
                if (inner.Result === 1) {
                    if (objectID == null)
                        that.nursingBodilyFluidAnalysisFormViewModel._NursingBodyFluidAnalysis.FluidIntakeOutputGrids.push(fluidIntakeOutput);
                }

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.ApplicationDate != event) {
                this._NursingBodyFluidAnalysis.ApplicationDate = event;
            }
        }
    }

    public onTotalAspirationChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalAspiration != event) {
                this._NursingBodyFluidAnalysis.TotalAspiration = event;
            }
        }
    }

    public onTotalBloodLossChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalBloodLoss != event) {
                this._NursingBodyFluidAnalysis.TotalBloodLoss = event;
            }
        }
    }

    public onTotalDrainageChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalDrainage != event) {
                this._NursingBodyFluidAnalysis.TotalDrainage = event;
            }
        }
    }

    public onTotalIrrigationChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalIrrigation != event) {
                this._NursingBodyFluidAnalysis.TotalIrrigation = event;
            }
        }
    }

    public onTotalMedChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalMed != event) {
                this._NursingBodyFluidAnalysis.TotalMed = event;
            }
        }
    }

    public onTotalMilkAmountChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalMilkAmount != event) {
                this._NursingBodyFluidAnalysis.TotalMilkAmount = event;
            }
        }
    }

    public onTotalNGCChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalNGC != event) {
                this._NursingBodyFluidAnalysis.TotalNGC = event;
            }
        }
    }

    public onTotalOralIntakeChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalOralIntake != event) {
                this._NursingBodyFluidAnalysis.TotalOralIntake = event;
            }
        }
    }

    public onTotalOtherBodilyFluidLossChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalOtherBodilyFluidLoss != event) {
                this._NursingBodyFluidAnalysis.TotalOtherBodilyFluidLoss = event;
            }
        }
    }

    public onTotalOtherBodilyFluidsTakenChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalOtherBodilyFluidsTaken != event) {
                this._NursingBodyFluidAnalysis.TotalOtherBodilyFluidsTaken = event;
            }
        }
    }

    public onTotalPACChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.Total_PAC != event) {
                this._NursingBodyFluidAnalysis.Total_PAC = event;
            }
        }
    }

    public onTotalSludgeChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalSludge != event) {
                this._NursingBodyFluidAnalysis.TotalSludge = event;
            }
        }
    }

    public onTotalStoolChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalStool != event) {
                this._NursingBodyFluidAnalysis.TotalStool = event;
            }
        }
    }

    public onTotalSuppliedBloodChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalSuppliedBlood != event) {
                this._NursingBodyFluidAnalysis.TotalSuppliedBlood = event;
            }
        }
    }

    public onTotalUrineChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalUrine != event) {
                this._NursingBodyFluidAnalysis.TotalUrine = event;
            }
        }
    }

    public onTotalVenousFluidChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalVenousFluid != event) {
                this._NursingBodyFluidAnalysis.TotalVenousFluid = event;
            }
        }
    }

    public onTotalVomitChanged(event): void {
        if (event != null) {
            if (this._NursingBodyFluidAnalysis != null && this._NursingBodyFluidAnalysis.TotalVomit != event) {
                this._NursingBodyFluidAnalysis.TotalVomit = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.TotalOralIntake, "Text", this.__ttObject, "TotalOralIntake");
        redirectProperty(this.TotalUrine, "Text", this.__ttObject, "TotalUrine");
        redirectProperty(this.TotalNGC, "Text", this.__ttObject, "TotalNGC");
        redirectProperty(this.TotalAspiration, "Text", this.__ttObject, "TotalAspiration");
        redirectProperty(this.TotalVenousFluid, "Text", this.__ttObject, "TotalVenousFluid");
        redirectProperty(this.TotalVomit, "Text", this.__ttObject, "TotalVomit");
        redirectProperty(this.TotalMed, "Text", this.__ttObject, "TotalMed");
        redirectProperty(this.TotalDrainage, "Text", this.__ttObject, "TotalDrainage");
        redirectProperty(this.TotalSuppliedBlood, "Text", this.__ttObject, "TotalSuppliedBlood");
        redirectProperty(this.TotalStool, "Text", this.__ttObject, "TotalStool");
        redirectProperty(this.TotalIrrigation, "Text", this.__ttObject, "TotalIrrigation");
        redirectProperty(this.TotalBloodLoss, "Text", this.__ttObject, "TotalBloodLoss");
        redirectProperty(this.TotalMilkAmount, "Text", this.__ttObject, "TotalMilkAmount");
        redirectProperty(this.TotalOtherBodilyFluidLoss, "Text", this.__ttObject, "TotalOtherBodilyFluidLoss");
        redirectProperty(this.TotalSludge, "Text", this.__ttObject, "TotalSludge");
        redirectProperty(this.TotalPAC, "Text", this.__ttObject, "Total_PAC");
        redirectProperty(this.TotalOtherBodilyFluidsTaken, "Text", this.__ttObject, "TotalOtherBodilyFluidsTaken");
    }

    public initFormControls(): void {

        this.NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput = new TTVisual.TTListBoxColumn();
        this.NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput.DataMember = "NursingBodyFluidAnalysis";
        this.NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput.DisplayIndex = 0;
        this.NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput.HeaderText = "";
        this.NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput.Name = "NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput";
        this.NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput.Width = 300;

        this.ApplicationUserNursingBodilyFluidIntakeOutput = new TTVisual.TTListBoxColumn();
        this.ApplicationUserNursingBodilyFluidIntakeOutput.DataMember = "ApplicationUser";
        this.ApplicationUserNursingBodilyFluidIntakeOutput.DisplayIndex = 1;
        this.ApplicationUserNursingBodilyFluidIntakeOutput.HeaderText = i18n("M23799", "Uygulayan Kişi");
        this.ApplicationUserNursingBodilyFluidIntakeOutput.Name = "ApplicationUserNursingBodilyFluidIntakeOutput";
        this.ApplicationUserNursingBodilyFluidIntakeOutput.Width = 300;

        this.NursingApplicationNursingBodilyFluidIntakeOutput = new TTVisual.TTListBoxColumn();
        this.NursingApplicationNursingBodilyFluidIntakeOutput.DataMember = "NursingApplication";
        this.NursingApplicationNursingBodilyFluidIntakeOutput.DisplayIndex = 2;
        this.NursingApplicationNursingBodilyFluidIntakeOutput.HeaderText = "";
        this.NursingApplicationNursingBodilyFluidIntakeOutput.Name = "NursingApplicationNursingBodilyFluidIntakeOutput";
        this.NursingApplicationNursingBodilyFluidIntakeOutput.Width = 300;

        this.NoteNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.NoteNursingBodilyFluidIntakeOutput.DataMember = "Note";
        this.NoteNursingBodilyFluidIntakeOutput.DisplayIndex = 3;
        this.NoteNursingBodilyFluidIntakeOutput.HeaderText = i18n("M19476", "Not");
        this.NoteNursingBodilyFluidIntakeOutput.Name = "NoteNursingBodilyFluidIntakeOutput";
        this.NoteNursingBodilyFluidIntakeOutput.Width = 80;

        this.OralIntakeNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.OralIntakeNursingBodilyFluidIntakeOutput.DataMember = "OralIntake";
        this.OralIntakeNursingBodilyFluidIntakeOutput.DisplayIndex = 4;
        this.OralIntakeNursingBodilyFluidIntakeOutput.HeaderText = "Oral";
        this.OralIntakeNursingBodilyFluidIntakeOutput.Name = "OralIntakeNursingBodilyFluidIntakeOutput";
        this.OralIntakeNursingBodilyFluidIntakeOutput.Width = 80;

        this.NasogastricTubeNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.NasogastricTubeNursingBodilyFluidIntakeOutput.DataMember = "NasogastricTube";
        this.NasogastricTubeNursingBodilyFluidIntakeOutput.DisplayIndex = 5;
        this.NasogastricTubeNursingBodilyFluidIntakeOutput.HeaderText = "Nasogastrik Sonda";
        this.NasogastricTubeNursingBodilyFluidIntakeOutput.Name = "NasogastricTubeNursingBodilyFluidIntakeOutput";
        this.NasogastricTubeNursingBodilyFluidIntakeOutput.Width = 80;

        this.VenousFluidNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.VenousFluidNursingBodilyFluidIntakeOutput.DataMember = "VenousFluid";
        this.VenousFluidNursingBodilyFluidIntakeOutput.DisplayIndex = 6;
        this.VenousFluidNursingBodilyFluidIntakeOutput.HeaderText = "Damar İçi Sıvılar";
        this.VenousFluidNursingBodilyFluidIntakeOutput.Name = "VenousFluidNursingBodilyFluidIntakeOutput";
        this.VenousFluidNursingBodilyFluidIntakeOutput.Width = 80;

        this.MedicineNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.MedicineNursingBodilyFluidIntakeOutput.DataMember = "Medicine";
        this.MedicineNursingBodilyFluidIntakeOutput.DisplayIndex = 7;
        this.MedicineNursingBodilyFluidIntakeOutput.HeaderText = i18n("M16389", "İlaçlar");
        this.MedicineNursingBodilyFluidIntakeOutput.Name = "MedicineNursingBodilyFluidIntakeOutput";
        this.MedicineNursingBodilyFluidIntakeOutput.Width = 80;

        this.SuppliedBloodNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.SuppliedBloodNursingBodilyFluidIntakeOutput.DataMember = "SuppliedBlood";
        this.SuppliedBloodNursingBodilyFluidIntakeOutput.DisplayIndex = 8;
        this.SuppliedBloodNursingBodilyFluidIntakeOutput.HeaderText = "Verilen Kan";
        this.SuppliedBloodNursingBodilyFluidIntakeOutput.Name = "SuppliedBloodNursingBodilyFluidIntakeOutput";
        this.SuppliedBloodNursingBodilyFluidIntakeOutput.Width = 80;

        this.IrrigationNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.IrrigationNursingBodilyFluidIntakeOutput.DataMember = "Irrigation";
        this.IrrigationNursingBodilyFluidIntakeOutput.DisplayIndex = 9;
        this.IrrigationNursingBodilyFluidIntakeOutput.HeaderText = "İrigasyon";
        this.IrrigationNursingBodilyFluidIntakeOutput.Name = "IrrigationNursingBodilyFluidIntakeOutput";
        this.IrrigationNursingBodilyFluidIntakeOutput.Width = 80;

        this.MilkTypeNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.MilkTypeNursingBodilyFluidIntakeOutput.DataMember = "MilkType";
        this.MilkTypeNursingBodilyFluidIntakeOutput.DisplayIndex = 10;
        this.MilkTypeNursingBodilyFluidIntakeOutput.HeaderText = "Süt Tipi";
        this.MilkTypeNursingBodilyFluidIntakeOutput.Name = "MilkTypeNursingBodilyFluidIntakeOutput";
        this.MilkTypeNursingBodilyFluidIntakeOutput.Width = 80;

        this.MilkAmountNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.MilkAmountNursingBodilyFluidIntakeOutput.DataMember = "MilkAmount";
        this.MilkAmountNursingBodilyFluidIntakeOutput.DisplayIndex = 11;
        this.MilkAmountNursingBodilyFluidIntakeOutput.HeaderText = "Süt Miktarı";
        this.MilkAmountNursingBodilyFluidIntakeOutput.Name = "MilkAmountNursingBodilyFluidIntakeOutput";
        this.MilkAmountNursingBodilyFluidIntakeOutput.Width = 80;

        this.SludgeNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.SludgeNursingBodilyFluidIntakeOutput.DataMember = "Sludge";
        this.SludgeNursingBodilyFluidIntakeOutput.DisplayIndex = 12;
        this.SludgeNursingBodilyFluidIntakeOutput.HeaderText = "Tortu";
        this.SludgeNursingBodilyFluidIntakeOutput.Name = "SludgeNursingBodilyFluidIntakeOutput";
        this.SludgeNursingBodilyFluidIntakeOutput.Width = 80;

        this.PACNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.PACNursingBodilyFluidIntakeOutput.DataMember = "PAC";
        this.PACNursingBodilyFluidIntakeOutput.DisplayIndex = 13;
        this.PACNursingBodilyFluidIntakeOutput.HeaderText = "PAC";
        this.PACNursingBodilyFluidIntakeOutput.Name = "PACNursingBodilyFluidIntakeOutput";
        this.PACNursingBodilyFluidIntakeOutput.Width = 80;

        this.OtherFluidIntakeNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.OtherFluidIntakeNursingBodilyFluidIntakeOutput.DataMember = "OtherFluidIntake";
        this.OtherFluidIntakeNursingBodilyFluidIntakeOutput.DisplayIndex = 14;
        this.OtherFluidIntakeNursingBodilyFluidIntakeOutput.HeaderText = i18n("M12780", "Diğer");
        this.OtherFluidIntakeNursingBodilyFluidIntakeOutput.Name = "OtherFluidIntakeNursingBodilyFluidIntakeOutput";
        this.OtherFluidIntakeNursingBodilyFluidIntakeOutput.Width = 80;

        this.FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput.DataMember = "FluidIntakeFurtherExplanation";
        this.FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput.DisplayIndex = 15;
        this.FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput.HeaderText = "Diğer Açıklamalar";
        this.FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput.Name = "FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput";
        this.FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput.Width = 80;

        this.FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput.DataMember = "FluidOutputFurtherExplanation";
        this.FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput.DisplayIndex = 16;
        this.FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput.HeaderText = "Diğer Açıklamalar";
        this.FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput.Name = "FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput";
        this.FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput.Width = 80;

        this.UrineNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.UrineNursingBodilyFluidIntakeOutput.DataMember = "Urine";
        this.UrineNursingBodilyFluidIntakeOutput.DisplayIndex = 17;
        this.UrineNursingBodilyFluidIntakeOutput.HeaderText = i18n("M16190", "İdrar");
        this.UrineNursingBodilyFluidIntakeOutput.Name = "UrineNursingBodilyFluidIntakeOutput";
        this.UrineNursingBodilyFluidIntakeOutput.Width = 80;

        this.AspirationNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.AspirationNursingBodilyFluidIntakeOutput.DataMember = "Aspiration";
        this.AspirationNursingBodilyFluidIntakeOutput.DisplayIndex = 18;
        this.AspirationNursingBodilyFluidIntakeOutput.HeaderText = "Aspirasyon";
        this.AspirationNursingBodilyFluidIntakeOutput.Name = "AspirationNursingBodilyFluidIntakeOutput";
        this.AspirationNursingBodilyFluidIntakeOutput.Width = 80;

        this.VomitNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.VomitNursingBodilyFluidIntakeOutput.DataMember = "Vomit";
        this.VomitNursingBodilyFluidIntakeOutput.DisplayIndex = 19;
        this.VomitNursingBodilyFluidIntakeOutput.HeaderText = i18n("M18118", "Kusma");
        this.VomitNursingBodilyFluidIntakeOutput.Name = "VomitNursingBodilyFluidIntakeOutput";
        this.VomitNursingBodilyFluidIntakeOutput.Width = 80;

        this.Drainage1NursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.Drainage1NursingBodilyFluidIntakeOutput.DataMember = "Drainage1";
        this.Drainage1NursingBodilyFluidIntakeOutput.DisplayIndex = 20;
        this.Drainage1NursingBodilyFluidIntakeOutput.HeaderText = "Drenaj (1)";
        this.Drainage1NursingBodilyFluidIntakeOutput.Name = "Drainage1NursingBodilyFluidIntakeOutput";
        this.Drainage1NursingBodilyFluidIntakeOutput.Width = 80;

        this.Drainage2NursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.Drainage2NursingBodilyFluidIntakeOutput.DataMember = "Drainage2";
        this.Drainage2NursingBodilyFluidIntakeOutput.DisplayIndex = 21;
        this.Drainage2NursingBodilyFluidIntakeOutput.HeaderText = "Drenaj (2)";
        this.Drainage2NursingBodilyFluidIntakeOutput.Name = "Drainage2NursingBodilyFluidIntakeOutput";
        this.Drainage2NursingBodilyFluidIntakeOutput.Width = 80;

        this.Drainage3NursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.Drainage3NursingBodilyFluidIntakeOutput.DataMember = "Drainage3";
        this.Drainage3NursingBodilyFluidIntakeOutput.DisplayIndex = 22;
        this.Drainage3NursingBodilyFluidIntakeOutput.HeaderText = "Drenaj (3)";
        this.Drainage3NursingBodilyFluidIntakeOutput.Name = "Drainage3NursingBodilyFluidIntakeOutput";
        this.Drainage3NursingBodilyFluidIntakeOutput.Width = 80;

        this.Drainage4NursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.Drainage4NursingBodilyFluidIntakeOutput.DataMember = "Drainage4";
        this.Drainage4NursingBodilyFluidIntakeOutput.DisplayIndex = 23;
        this.Drainage4NursingBodilyFluidIntakeOutput.HeaderText = "Drenaj (4)";
        this.Drainage4NursingBodilyFluidIntakeOutput.Name = "Drainage4NursingBodilyFluidIntakeOutput";
        this.Drainage4NursingBodilyFluidIntakeOutput.Width = 80;

        this.StoolNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.StoolNursingBodilyFluidIntakeOutput.DataMember = "Stool";
        this.StoolNursingBodilyFluidIntakeOutput.DisplayIndex = 24;
        this.StoolNursingBodilyFluidIntakeOutput.HeaderText = "Dışkı";
        this.StoolNursingBodilyFluidIntakeOutput.Name = "StoolNursingBodilyFluidIntakeOutput";
        this.StoolNursingBodilyFluidIntakeOutput.Width = 80;

        this.BloodLossNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.BloodLossNursingBodilyFluidIntakeOutput.DataMember = "BloodLoss";
        this.BloodLossNursingBodilyFluidIntakeOutput.DisplayIndex = 25;
        this.BloodLossNursingBodilyFluidIntakeOutput.HeaderText = "Kaybedilen Kan";
        this.BloodLossNursingBodilyFluidIntakeOutput.Name = "BloodLossNursingBodilyFluidIntakeOutput";
        this.BloodLossNursingBodilyFluidIntakeOutput.Width = 80;

        this.OtherFluidOutputNursingBodilyFluidIntakeOutput = new TTVisual.TTTextBoxColumn();
        this.OtherFluidOutputNursingBodilyFluidIntakeOutput.DataMember = "OtherFluidOutput";
        this.OtherFluidOutputNursingBodilyFluidIntakeOutput.DisplayIndex = 26;
        this.OtherFluidOutputNursingBodilyFluidIntakeOutput.HeaderText = i18n("M12780", "Diğer");
        this.OtherFluidOutputNursingBodilyFluidIntakeOutput.Name = "OtherFluidOutputNursingBodilyFluidIntakeOutput";
        this.OtherFluidOutputNursingBodilyFluidIntakeOutput.Width = 80;

        this.ApplicationDateNursingBodilyFluidIntakeOutput = new TTVisual.TTDateTimePickerColumn();
        this.ApplicationDateNursingBodilyFluidIntakeOutput.DataMember = "ApplicationDate";
        this.ApplicationDateNursingBodilyFluidIntakeOutput.DisplayIndex = 27;
        this.ApplicationDateNursingBodilyFluidIntakeOutput.HeaderText = i18n("M23772", "Uygulama Zamanı");
        this.ApplicationDateNursingBodilyFluidIntakeOutput.Name = "ApplicationDateNursingBodilyFluidIntakeOutput";
        this.ApplicationDateNursingBodilyFluidIntakeOutput.Width = 180;

        this.EntryDateNursingBodilyFluidIntakeOutput = new TTVisual.TTDateTimePickerColumn();
        this.EntryDateNursingBodilyFluidIntakeOutput.DataMember = "EntryDate";
        this.EntryDateNursingBodilyFluidIntakeOutput.DisplayIndex = 28;
        this.EntryDateNursingBodilyFluidIntakeOutput.HeaderText = i18n("M14809", "Giriş Yapılan Zaman");
        this.EntryDateNursingBodilyFluidIntakeOutput.Name = "EntryDateNursingBodilyFluidIntakeOutput";
        this.EntryDateNursingBodilyFluidIntakeOutput.Width = 180;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 35;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 34;

        this.labelTotalVomit = new TTVisual.TTLabel();
        this.labelTotalVomit.Text = "Toplam Kusma";
        this.labelTotalVomit.Name = "labelTotalVomit";
        this.labelTotalVomit.TabIndex = 33;

        this.TotalVomit = new TTVisual.TTTextBox();
        this.TotalVomit.Name = "TotalVomit";
        this.TotalVomit.TabIndex = 32;

        this.TotalVenousFluid = new TTVisual.TTTextBox();
        this.TotalVenousFluid.Name = "TotalVenousFluid";
        this.TotalVenousFluid.TabIndex = 30;

        this.TotalUrine = new TTVisual.TTTextBox();
        this.TotalUrine.Name = "TotalUrine";
        this.TotalUrine.TabIndex = 28;

        this.TotalSuppliedBlood = new TTVisual.TTTextBox();
        this.TotalSuppliedBlood.Name = "TotalSuppliedBlood";
        this.TotalSuppliedBlood.TabIndex = 26;

        this.TotalStool = new TTVisual.TTTextBox();
        this.TotalStool.Name = "TotalStool";
        this.TotalStool.TabIndex = 24;

        this.TotalSludge = new TTVisual.TTTextBox();
        this.TotalSludge.Name = "TotalSludge";
        this.TotalSludge.TabIndex = 22;

        this.TotalOtherBodilyFluidsTaken = new TTVisual.TTTextBox();
        this.TotalOtherBodilyFluidsTaken.Name = "TotalOtherBodilyFluidsTaken";
        this.TotalOtherBodilyFluidsTaken.TabIndex = 20;

        this.TotalOtherBodilyFluidLoss = new TTVisual.TTTextBox();
        this.TotalOtherBodilyFluidLoss.Name = "TotalOtherBodilyFluidLoss";
        this.TotalOtherBodilyFluidLoss.TabIndex = 18;

        this.TotalOralIntake = new TTVisual.TTTextBox();
        this.TotalOralIntake.Name = "TotalOralIntake";
        this.TotalOralIntake.TabIndex = 16;

        this.TotalNGC = new TTVisual.TTTextBox();
        this.TotalNGC.Name = "TotalNGC";
        this.TotalNGC.TabIndex = 14;

        this.TotalMilkAmount = new TTVisual.TTTextBox();
        this.TotalMilkAmount.Name = "TotalMilkAmount";
        this.TotalMilkAmount.TabIndex = 12;

        this.TotalMed = new TTVisual.TTTextBox();
        this.TotalMed.Name = "TotalMed";
        this.TotalMed.TabIndex = 10;

        this.TotalIrrigation = new TTVisual.TTTextBox();
        this.TotalIrrigation.Name = "TotalIrrigation";
        this.TotalIrrigation.TabIndex = 8;

        this.TotalDrainage = new TTVisual.TTTextBox();
        this.TotalDrainage.Name = "TotalDrainage";
        this.TotalDrainage.TabIndex = 6;

        this.TotalBloodLoss = new TTVisual.TTTextBox();
        this.TotalBloodLoss.Name = "TotalBloodLoss";
        this.TotalBloodLoss.TabIndex = 4;

        this.TotalAspiration = new TTVisual.TTTextBox();
        this.TotalAspiration.Name = "TotalAspiration";
        this.TotalAspiration.TabIndex = 2;

        this.TotalPAC = new TTVisual.TTTextBox();
        this.TotalPAC.Name = "TotalPAC";
        this.TotalPAC.TabIndex = 0;

        this.labelTotalVenousFluid = new TTVisual.TTLabel();
        this.labelTotalVenousFluid.Text = "Toplam Damar İçi Sıvılar";
        this.labelTotalVenousFluid.Name = "labelTotalVenousFluid";
        this.labelTotalVenousFluid.TabIndex = 31;

        this.labelTotalUrine = new TTVisual.TTLabel();
        this.labelTotalUrine.Text = "Toplam İdrar";
        this.labelTotalUrine.Name = "labelTotalUrine";
        this.labelTotalUrine.TabIndex = 29;

        this.labelTotalSuppliedBlood = new TTVisual.TTLabel();
        this.labelTotalSuppliedBlood.Text = "Toplam Verilen Kan";
        this.labelTotalSuppliedBlood.Name = "labelTotalSuppliedBlood";
        this.labelTotalSuppliedBlood.TabIndex = 27;

        this.labelTotalStool = new TTVisual.TTLabel();
        this.labelTotalStool.Text = "Toplam Dışkı";
        this.labelTotalStool.Name = "labelTotalStool";
        this.labelTotalStool.TabIndex = 25;

        this.labelTotalSludge = new TTVisual.TTLabel();
        this.labelTotalSludge.Text = "Tortu";
        this.labelTotalSludge.Name = "labelTotalSludge";
        this.labelTotalSludge.TabIndex = 23;

        this.labelTotalOtherBodilyFluidsTaken = new TTVisual.TTLabel();
        this.labelTotalOtherBodilyFluidsTaken.Text = "Toplam Alınan Diğer Sıvılar";
        this.labelTotalOtherBodilyFluidsTaken.Name = "labelTotalOtherBodilyFluidsTaken";
        this.labelTotalOtherBodilyFluidsTaken.TabIndex = 21;

        this.labelTotalOtherBodilyFluidLoss = new TTVisual.TTLabel();
        this.labelTotalOtherBodilyFluidLoss.Text = "Toplam Diğer Kaybedilen Sıvılar";
        this.labelTotalOtherBodilyFluidLoss.Name = "labelTotalOtherBodilyFluidLoss";
        this.labelTotalOtherBodilyFluidLoss.TabIndex = 19;

        this.labelTotalOralIntake = new TTVisual.TTLabel();
        this.labelTotalOralIntake.Text = "Toplam Oral";
        this.labelTotalOralIntake.Name = "labelTotalOralIntake";
        this.labelTotalOralIntake.TabIndex = 17;

        this.labelTotalNGC = new TTVisual.TTLabel();
        this.labelTotalNGC.Text = "Toplam NGC";
        this.labelTotalNGC.Name = "labelTotalNGC";
        this.labelTotalNGC.TabIndex = 15;

        this.labelTotalMilkAmount = new TTVisual.TTLabel();
        this.labelTotalMilkAmount.Text = "Toplam Süt Miktarı";
        this.labelTotalMilkAmount.Name = "labelTotalMilkAmount";
        this.labelTotalMilkAmount.TabIndex = 13;

        this.labelTotalMed = new TTVisual.TTLabel();
        this.labelTotalMed.Text = "Toplam İlaçlar";
        this.labelTotalMed.Name = "labelTotalMed";
        this.labelTotalMed.TabIndex = 11;

        this.labelTotalIrrigation = new TTVisual.TTLabel();
        this.labelTotalIrrigation.Text = "Toplam İrigasyon";
        this.labelTotalIrrigation.Name = "labelTotalIrrigation";
        this.labelTotalIrrigation.TabIndex = 9;

        this.labelTotalDrainage = new TTVisual.TTLabel();
        this.labelTotalDrainage.Text = "Toplam Drenaj";
        this.labelTotalDrainage.Name = "labelTotalDrainage";
        this.labelTotalDrainage.TabIndex = 7;

        this.labelTotalBloodLoss = new TTVisual.TTLabel();
        this.labelTotalBloodLoss.Text = "Toplam Kaybedilen Kan";
        this.labelTotalBloodLoss.Name = "labelTotalBloodLoss";
        this.labelTotalBloodLoss.TabIndex = 5;

        this.labelTotalAspiration = new TTVisual.TTLabel();
        this.labelTotalAspiration.Text = "Toplam Aspirasyon";
        this.labelTotalAspiration.Name = "labelTotalAspiration";
        this.labelTotalAspiration.TabIndex = 3;

        this.labelTotalPAC = new TTVisual.TTLabel();
        this.labelTotalPAC.Text = "Toplam PAC";
        this.labelTotalPAC.Name = "labelTotalPAC";
        this.labelTotalPAC.TabIndex = 1;

        this.Controls = [this.NursingBodyFluidAnalysisNursingBodilyFluidIntakeOutput, this.ApplicationUserNursingBodilyFluidIntakeOutput, this.NursingApplicationNursingBodilyFluidIntakeOutput, this.NoteNursingBodilyFluidIntakeOutput, this.OralIntakeNursingBodilyFluidIntakeOutput, this.NasogastricTubeNursingBodilyFluidIntakeOutput, this.VenousFluidNursingBodilyFluidIntakeOutput, this.MedicineNursingBodilyFluidIntakeOutput, this.SuppliedBloodNursingBodilyFluidIntakeOutput, this.IrrigationNursingBodilyFluidIntakeOutput, this.MilkTypeNursingBodilyFluidIntakeOutput, this.MilkAmountNursingBodilyFluidIntakeOutput, this.SludgeNursingBodilyFluidIntakeOutput, this.PACNursingBodilyFluidIntakeOutput, this.OtherFluidIntakeNursingBodilyFluidIntakeOutput, this.FluidIntakeFurtherExplanationNursingBodilyFluidIntakeOutput, this.FluidOutputFurtherExplanationNursingBodilyFluidIntakeOutput, this.UrineNursingBodilyFluidIntakeOutput, this.AspirationNursingBodilyFluidIntakeOutput, this.VomitNursingBodilyFluidIntakeOutput, this.Drainage1NursingBodilyFluidIntakeOutput, this.Drainage2NursingBodilyFluidIntakeOutput, this.Drainage3NursingBodilyFluidIntakeOutput, this.Drainage4NursingBodilyFluidIntakeOutput, this.StoolNursingBodilyFluidIntakeOutput, this.BloodLossNursingBodilyFluidIntakeOutput, this.OtherFluidOutputNursingBodilyFluidIntakeOutput, this.ApplicationDateNursingBodilyFluidIntakeOutput, this.EntryDateNursingBodilyFluidIntakeOutput, this.labelApplicationDate, this.ApplicationDate, this.labelTotalVomit, this.TotalVomit, this.TotalVenousFluid, this.TotalUrine, this.TotalSuppliedBlood, this.TotalStool, this.TotalSludge, this.TotalOtherBodilyFluidsTaken, this.TotalOtherBodilyFluidLoss, this.TotalOralIntake, this.TotalNGC, this.TotalMilkAmount, this.TotalMed, this.TotalIrrigation, this.TotalDrainage, this.TotalBloodLoss, this.TotalAspiration, this.TotalPAC, this.labelTotalVenousFluid, this.labelTotalUrine, this.labelTotalSuppliedBlood, this.labelTotalStool, this.labelTotalSludge, this.labelTotalOtherBodilyFluidsTaken, this.labelTotalOtherBodilyFluidLoss, this.labelTotalOralIntake, this.labelTotalNGC, this.labelTotalMilkAmount, this.labelTotalMed, this.labelTotalIrrigation, this.labelTotalDrainage, this.labelTotalBloodLoss, this.labelTotalAspiration, this.labelTotalPAC];

    }


}
