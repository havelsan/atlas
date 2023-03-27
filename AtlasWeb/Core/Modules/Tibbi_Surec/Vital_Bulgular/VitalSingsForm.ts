//$71C06751
import { Component, Input  } from '@angular/core';
import { VitalSingsFormViewModel } from "Modules/Tibbi_Surec/Vital_Bulgular/VitalSingsFormViewModel";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";



@Component({
    selector: 'VitalSingsForm',
    templateUrl: './VitalSingsForm.html',
    providers: [MessageService]
})
export class VitalSingsForm extends TTVisual.TTForm {


    //Vitaller
    BloodPressure_Diastolik: TTVisual.ITTMaskedTextBox;
    BloodPressure_Sistolik: TTVisual.ITTMaskedTextBox;
    Pulse_Value: TTVisual.ITTMaskedTextBox;
    Respiration_Value: TTVisual.ITTMaskedTextBox;
    Temperature_Value: TTVisual.ITTMaskedTextBox;
    SPO2_Value: TTVisual.ITTMaskedTextBox;
    Height_Value: TTVisual.TTTextBox;
    Weight_Value: TTVisual.TTTextBox;
    BMI_Value: TTVisual.TTTextBox;
     //

    @Input() heightVisible = false;
    @Input() weightVisible = false;
    @Input() bmiVisible = false;
    @Input() bloodPressure_DiastolikVisible = true;
    @Input() bloodPressure_SistolikVisible = true;
    @Input() pulseVisible = true;
    @Input() respirationVisible = true;
    @Input() temperatureVisible = true;
    @Input() spo2Visible = true;

    @Input() vitalSingsFormViewModel: VitalSingsFormViewModel;

    //private _isReadonly: Boolean;
    @Input() set IsReadOnly(value: boolean) {
        this.ReadOnly = value;
        this.ArranngeEnabled();
    }

    private ArranngeEnabled()
    {
        if (this.ReadOnly)
        {
            this.Controls.forEach(element => {
             element.Enabled =false;//from readonly ise controllerre silinik bir görüntü kazandırması için eklendi
            });
            // this.Height_Value.Enabled=true;
        }
    }
    //private VitalSingsForm_DocumentUrl: string = '/api/VitalSingsService/VitalSingsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("", "VitalSingsForm");
        //this._DocumentServiceUrl = this.VitalSingsForm_DocumentUrl;
       // this.initViewModel();
        this.initFormControls();

    }


    public initViewModel(): void {
       // this.vitalSingsViewModel = new VitalSingsFormViewModel();
    }


    //Vitaller
    public onBloodPressure_SistolikChanged(event): void {
        if (event != null) {
            //var value = parseFloat(event.replace(",", "."));
            let value;
            if (typeof event === "string")
                value = parseFloat(event.replace(",", "."));
            else
                value = event;

            if (this.vitalSingsFormViewModel.VitalSignsValues != null && this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MaxValue != null && this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MinValue != null )
            {
                if (value > this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MaxValue)
                {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MaxWarning);

                } else if (value < this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MinValue)
                {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MinWarning);
                }
                //&& (event > this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MaxValue || event < this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MinValue)

                //this.messageService.showError("Sistolik Tansiyon; normal değer aralığı olan [" + this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MinValue + "-" + this.vitalSingsFormViewModel.VitalSignsValues.Systolic_MaxValue +"] değerlerinin dışındadır.");
            }

            if (this.BloodPressure_Sistolik != event) {
                this.vitalSingsFormViewModel.BloodPressure_Sistolik = event;
            }
        }
    }

    public onBloodPressure_DiastolikChanged(event): void {
        if (event != null) {
            //var value = parseFloat(event.replace(",", "."));
            let value;
            if (typeof event === "string")
                value = parseFloat(event.replace(",", "."));
            else
                value = event;

            if (this.vitalSingsFormViewModel.VitalSignsValues != null && this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MaxValue != null && this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MinValue != null) {


                if (value > this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MaxValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MaxWarning);

                } else if (value < this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MinValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MinWarning);
                }

                //&& (event > this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MaxValue || event < this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MinValue)
                //this.messageService.showError("Diastolik Tansiyon; normal değer aralığı olan [" + this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MinValue + "-" + this.vitalSingsFormViewModel.VitalSignsValues.Diastolic_MaxValue + "] değerlerinin dışındadır.");
            }

            if (this.BloodPressure_Diastolik != event) {
                this.vitalSingsFormViewModel.BloodPressure_Diastolik = event;
            }
        }
    }

    public onPulse_ValueChanged(event): void {
        if (event != null) {
            //var value = parseFloat(event.replace(",", "."));
            let value;
            if (typeof event === "string")
                value = parseFloat(event.replace(",", "."));
            else
                value = event;

            if (this.vitalSingsFormViewModel.VitalSignsValues != null && this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MaxValue != null && this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MinValue != null) {

                if (value > this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MaxValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MaxWarning);
                } else if (value < this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MinValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MinWarning);
                }

                //&& (event > this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MaxValue || event < this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MinValue)
                //this.messageService.showError("Nabız; normal değer aralığı olan [" + this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MinValue + "-" + this.vitalSingsFormViewModel.VitalSignsValues.Pulse_MaxValue + "] değerlerinin dışındadır.");
            }

            if (this.Pulse_Value != event) {
                this.vitalSingsFormViewModel.Pulse_Value = event;
            }
        }
    }

    public onRespiration_ValueChanged(event): void {
        if (event != null) {
            //var value = parseFloat(event.replace(",", "."));
            let value;
            if (typeof event === "string")
                value = parseFloat(event.replace(",", "."));
            else
                value = event;

            if (this.vitalSingsFormViewModel.VitalSignsValues != null && this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MaxValue != null && this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MinValue != null) {

                if (value > this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MaxValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MaxWarning);
                } else if (value < this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MinValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MinWarning);
                }

                //&& (event > this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MaxValue || event < this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MinValue)
                //this.messageService.showError("Solunum Sayısı; normal değer aralığı olan [" + this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MinValue + "-" + this.vitalSingsFormViewModel.VitalSignsValues.Respiration_MaxValue + "] değerlerinin dışındadır.");
            }

            if (this.Respiration_Value != event) {
                this.vitalSingsFormViewModel.Respiration_Value = event;
            }
        }
    }

    public onTemperature_ValueChanged(event): void {
        if (event != null) {
            //var value = parseFloat(event.replace(",", "."));
            let value;
            if (typeof event === "string")
                value = parseFloat(event.replace(",", "."));
            else
                value = event;

            if (this.vitalSingsFormViewModel.VitalSignsValues != null && this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MaxValue != null && this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MinValue != null) {

                if (value > this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MaxValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MaxWarning);
                } else if (value < this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MinValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MinWarning);
                }

                //&& (event > this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MaxValue || event < this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MinValue)
                //this.messageService.showError("Ateş; normal değer aralığı olan [" + this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MinValue + "-" + this.vitalSingsFormViewModel.VitalSignsValues.Temperature_MaxValue + "] değerlerinin dışındadır.");
            }
            if (this.Temperature_Value != event) {
                this.vitalSingsFormViewModel.Temperature_Value = event;
            }
        }
    }

    public onSPO2_ValueChanged(event): void {
        if (event != null) {
            //var value = parseFloat(event.replace(",", "."));
            let value;
            if (typeof event === "string")
                value = parseFloat(event.replace(",", "."));
            else
                value = event;

            if (this.vitalSingsFormViewModel.VitalSignsValues != null && this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MaxValue != null && this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MinValue) {

                if (value > this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MaxValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MaxWarning);
                } else if (value < this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MinValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MinWarning);
                }

                //&& (event > this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MaxValue || event < this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MinValue)
                //this.messageService.showError("O2 Saturasyonu; normal değer aralığı olan [" + this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MinValue + "-" + this.vitalSingsFormViewModel.VitalSignsValues.SPO2_MaxValue + "] değerlerinin dışındadır.");
            }
            if (this.SPO2_Value != event) {
                this.vitalSingsFormViewModel.SPO2_Value = event;
            }
        }
    }

    public onWeight_ValueChanged(event): void {
        if (event != null) {
            //var value = parseFloat(event.replace(",", "."));
            let value;
            if (typeof event === "string")
                value = parseFloat(event.replace(",", "."));
            else
                value = event;

            if (value < 0) {
                this.messageService.showError("Kilo değeri 0 dan küçük olamaz");
                this.vitalSingsFormViewModel.Weight_Value = null;
                return;
            }                  

            if (this.vitalSingsFormViewModel.VitalSignsValues != null && this.vitalSingsFormViewModel.VitalSignsValues.Weight_MinValue != null && this.vitalSingsFormViewModel.VitalSignsValues.Weight_MaxValue != null) {

                if (value > this.vitalSingsFormViewModel.VitalSignsValues.Weight_MaxValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Weight_MaxWarning);
                } else if (value < this.vitalSingsFormViewModel.VitalSignsValues.Weight_MinValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Weight_MinWarning);
                }

                //&& (event > this.vitalSingsFormViewModel.VitalSignsValues.Weight_MaxValue || event < this.vitalSingsFormViewModel.VitalSignsValues.Weight_MinValue)
                //this.messageService.showError("Kilo; normal değer aralığı olan [" + this.vitalSingsFormViewModel.VitalSignsValues.Weight_MinValue + "-" + this.vitalSingsFormViewModel.VitalSignsValues.Weight_MaxValue + "] değerlerinin dışındadır.");
            }

            if (this.Weight_Value != event) {
                this.vitalSingsFormViewModel.Weight_Value = event;
                this.CalculateBMI();
            }
        }
    }

    public onHeight_ValueChanged(event): void {
        if (event != null) {
            //var value = parseFloat(event.replace(",", "."));
            let value;
            if (typeof event === "string")
                value = parseFloat(event.replace(",", "."));
            else
                value = event;

            if (value < 0) {
                this.messageService.showError("Boy değeri 0 dan küçük olamaz");
                this.vitalSingsFormViewModel.Height_Value = null;
                return;
            }                

            if (this.vitalSingsFormViewModel.VitalSignsValues != null && this.vitalSingsFormViewModel.VitalSignsValues.Height_MaxValue != null && this.vitalSingsFormViewModel.VitalSignsValues.Height_MinValue != null) {

                if (value > this.vitalSingsFormViewModel.VitalSignsValues.Height_MaxValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Height_MaxWarning);
                } else if (value < this.vitalSingsFormViewModel.VitalSignsValues.Height_MinValue) {
                    this.messageService.showError(this.vitalSingsFormViewModel.VitalSignsValues.Height_MinWarning);
                }

                //&& (event > this.vitalSingsFormViewModel.VitalSignsValues.Height_MaxValue || event < this.vitalSingsFormViewModel.VitalSignsValues.Height_MinValue)
                //this.messageService.showError("Boy; normal değer aralığı olan [" + this.vitalSingsFormViewModel.VitalSignsValues.Height_MinValue + "-" + this.vitalSingsFormViewModel.VitalSignsValues.Height_MaxValue + "] değerlerinin dışındadır.");
            }
            if (this.Height_Value != event) {
                this.vitalSingsFormViewModel.Height_Value = event;//buraya value konulabilir
                this.CalculateBMI();
            }
        }
    }

    public onBMI_ValueChanged(event): void {
        if (event != null) {
            if (this.BMI_Value != event) {
                this.vitalSingsFormViewModel.BMI_Value = event;

            }
        }
    }
    //

    CalculateBMI()
    {
        if (this.vitalSingsFormViewModel.Weight_Value != undefined && this.vitalSingsFormViewModel.Height_Value != undefined && this.vitalSingsFormViewModel.Weight_Value != null && this.vitalSingsFormViewModel.Height_Value != null) {
            if (this.vitalSingsFormViewModel.Weight_Value.toString() != "" && this.vitalSingsFormViewModel.Height_Value.toString() != "") {
                let weight: number = this.vitalSingsFormViewModel.Weight_Value;
                let height: number = this.vitalSingsFormViewModel.Height_Value / 100;
                let bmi = weight / (height * height);
                this.vitalSingsFormViewModel.BMI_Value = +bmi.toFixed(2);
            }

            if (this.vitalSingsFormViewModel.Weight_Value.toString() == "" && this.vitalSingsFormViewModel.Height_Value.toString() == "") {
                this.vitalSingsFormViewModel.BMI_Value = 0;
            }
        }
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {


        // Vitaller
        this.BloodPressure_Sistolik = new TTVisual.TTMaskedTextBox();
        this.BloodPressure_Sistolik.Name = "BloodPressure_Sistolik";
        this.BloodPressure_Sistolik.TabIndex = 28;
        this.BloodPressure_Sistolik.Mask = "999";
        this.BloodPressure_Sistolik.Visible = true;

        this.BloodPressure_Diastolik = new TTVisual.TTMaskedTextBox();
        this.BloodPressure_Diastolik.Name = "BloodPressure_Diastolik";
        this.BloodPressure_Diastolik.TabIndex = 28;
        this.BloodPressure_Diastolik.Mask = "999";
        this.BloodPressure_Diastolik.Visible = true;

        this.Pulse_Value = new TTVisual.TTMaskedTextBox();
        this.Pulse_Value.Name = "Pulse_Value";
        this.Pulse_Value.TabIndex = 28;
        this.Pulse_Value.Mask = "999";
        this.Pulse_Value.Visible = true;

        this.Respiration_Value = new TTVisual.TTMaskedTextBox();
        this.Respiration_Value.Name = "Respiration_Value";
        this.Respiration_Value.TabIndex = 28;
        this.Respiration_Value.Mask = "99999999";
        this.Respiration_Value.Visible = true;

        this.Temperature_Value = new TTVisual.TTMaskedTextBox();
        this.Temperature_Value.Name = "Temperature_Value";
        this.Temperature_Value.TabIndex = 28;
        this.Temperature_Value.Mask = "99,9".replace(/\s/g, "");
        this.Temperature_Value.Visible = true;


        this.SPO2_Value = new TTVisual.TTMaskedTextBox();
        this.SPO2_Value.Name = "SPO2_Value";
        this.SPO2_Value.TabIndex = 28;
        this.SPO2_Value.Mask = "999";
        this.SPO2_Value.Visible = true;

        this.Height_Value = new TTVisual.TTTextBox();
        this.Height_Value.Name = "Height_Value";
        this.Height_Value.TabIndex = 28;

        this.Weight_Value = new TTVisual.TTTextBox();
        this.Weight_Value.Name = "Weight_Value";
        this.Weight_Value.TabIndex = 28;

        this.BMI_Value = new TTVisual.TTTextBox();
        this.BMI_Value.Name = "BMI_Value";
        this.BMI_Value.TabIndex = 28;
        this.BMI_Value.Enabled = false;

        this.Controls = [this.BloodPressure_Diastolik, this.BloodPressure_Sistolik, this.Pulse_Value, this.Respiration_Value, this.Temperature_Value, this.SPO2_Value, this.Height_Value, this.Weight_Value, this.BMI_Value];

    }


}
