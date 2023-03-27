//$485F091B
import { Component, OnInit, NgZone } from '@angular/core';
import { OutPatientPrescriptionBaseFormViewModel } from './OutPatientPrescriptionBaseFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionBaseForm } from "Modules/Saglik_Lojistik/Eczane_Evrensel_Modulu/PrescriptionBaseForm";


@Component({
    selector: 'OutPatientPrescriptionBaseForm',
    templateUrl: './OutPatientPrescriptionBaseForm.html',
    providers: [MessageService]
})
export class OutPatientPrescriptionBaseForm extends PrescriptionBaseForm implements OnInit {
    DigitalSignatureButton: TTVisual.ITTButton;
    public outPatientPrescriptionBaseFormViewModel: OutPatientPrescriptionBaseFormViewModel = new OutPatientPrescriptionBaseFormViewModel();
    public get _OutPatientPrescription(): OutPatientPrescription {
        return this._TTObject as OutPatientPrescription;
    }
    private OutPatientPrescriptionBaseForm_DocumentUrl: string = '/api/OutPatientPrescriptionService/OutPatientPrescriptionBaseForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.OutPatientPrescriptionBaseForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async DigitalSignatureButton_Click(): Promise<void> {
      /*  if (TTObjectClasses.SystemParameter.IsDigitalSignatureIntegration) {
            if (this._OutPatientPrescription.SignedData !== null) {
                let digitalPrescriptionForm: DigitalPrescriptionForm = new DigitalPrescriptionForm();
                TTVisual.InfoBox.Show("digitalPrescriptionForm.ShowDialog(this);");
            }
        }*/
    }
    protected async PreScript() {
        super.PreScript();
      /*  if (TTObjectClasses.SystemParameter.IsDigitalSignatureIntegration) {
            if (this._OutPatientPrescription.SignedData !== null) {
                this.DigitalSignatureButton.Visible = true;
                let resUser: ResUser = TTUser.CurrentUser.UserObject as ResUser;
                if (resUser === null)
                    throw new TTException((await SystemMessageService.GetMessage(1208)));
                let digitalSignedPrescription: Prescription.DigitalSignedPrescription = TTUtils.SerializationHelper.DeserializeObject(<number[]>this._OutPatientPrescription.SignedData) as Prescription.DigitalSignedPrescription;
                if (digitalSignedPrescription !== null && resUser.VerifySignedData(new Prescription.DigitalPrescription(this._OutPatientPrescription), digitalSignedPrescription.SignedData)) {
                    this.Icon = TTVisual.Properties.Resources.validsignature;
                    this.DigitalSignatureButton.Text = "e-imza doğrulandı";
                    this.DigitalSignatureButton.BackColor = Color.Green;
                }
                else {
                    this.Icon = TTVisual.Properties.Resources.invalidsignature;
                    this.DigitalSignatureButton.Text = "e-imza doğrulanamadı";
                    this.DigitalSignatureButton.BackColor = Color.Red;
                }
            }
        }*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OutPatientPrescription();
        this.outPatientPrescriptionBaseFormViewModel = new OutPatientPrescriptionBaseFormViewModel();
        this._ViewModel = this.outPatientPrescriptionBaseFormViewModel;
        this.outPatientPrescriptionBaseFormViewModel._OutPatientPrescription = this._TTObject as OutPatientPrescription;
    }

    protected loadViewModel() {
        let that = this;

        that.outPatientPrescriptionBaseFormViewModel = this._ViewModel as OutPatientPrescriptionBaseFormViewModel;
        that._TTObject = this.outPatientPrescriptionBaseFormViewModel._OutPatientPrescription;
        if (this.outPatientPrescriptionBaseFormViewModel == null)
            this.outPatientPrescriptionBaseFormViewModel = new OutPatientPrescriptionBaseFormViewModel();
        if (this.outPatientPrescriptionBaseFormViewModel._OutPatientPrescription == null)
            this.outPatientPrescriptionBaseFormViewModel._OutPatientPrescription = new OutPatientPrescription();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OutPatientPrescriptionBaseFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.DigitalSignatureButton = new TTVisual.TTButton();
        this.DigitalSignatureButton.Text = i18n("M13510", "e-imza doğrulanamadı");
        this.DigitalSignatureButton.Name = "DigitalSignatureButton";
        this.DigitalSignatureButton.TabIndex = 95;
        this.DigitalSignatureButton.Visible = false;

        this.Controls = [this.DigitalSignatureButton];

    }


}
