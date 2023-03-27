//$3CFCD8CC
import { Component, OnInit } from '@angular/core';
import { MergePatientFormViewModel } from './MergePatientFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ShowBox } from 'NebulaClient/Visual/ShowBox';



@Component({
    selector: 'MergePatientForm',
    templateUrl: './MergePatientForm.html',
    providers: [MessageService]
})
export class MergePatientForm extends TTVisual.TTForm implements OnInit {
    btnMergePatient: TTVisual.ITTButton;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    txtHedef: TTVisual.ITTTextBox;
    txtKaynak: TTVisual.ITTTextBox;
    public mergePatientFormViewModel: MergePatientFormViewModel = new MergePatientFormViewModel();
  /*  public get _MergePatient(): MergePatient {
        return this._TTObject as MergePatient;
    } */
    //private MergePatientForm_DocumentUrl: string = '/api/MergePatientService/MergePatientForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('MERGEPATIENT', 'MergePatientForm');
        //this._DocumentServiceUrl = this.MergePatientForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    async sourcePatientChanged(sourcepatient: any) {
        let that = this;
        if (!that.mergePatientFormViewModel.Patients) {
            that.mergePatientFormViewModel.Patients = new Array<Patient>();
        }
        that.mergePatientFormViewModel.Patients[0] = sourcepatient;
    }
    async targetPatientChanged(targetPatient: any) {
        let that = this;
        if (!that.mergePatientFormViewModel.Patients) {
            that.mergePatientFormViewModel.Patients = new Array<Patient>();
        }
        that.mergePatientFormViewModel.Patients[1] = targetPatient;
    }
    public async mergePatients() {

        try {

            let resultStr = await this.httpService.post<string>('/api/MergePatientService/CheckMergePatients', this.mergePatientFormViewModel.Patients);
            if (resultStr == "") {
                let message: string;
                message = i18n("M11898", "Birleştirilmek istenen hastalar farklıdır. Devam etmek istiyor musunuz?");
                let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), message, '1');
                if (result === "OK") {
                    let res = await this.httpService.post<string>('/api/MergePatientService/MergePatients', this.mergePatientFormViewModel.Patients);
                    if(res != "")
                    {
                        ServiceLocator.MessageService.showInfo(res);
                    }
                   /* let mergePatientsUrl: string = '/api/MergePatientService/MergePatients=' + this.mergePatientFormViewModel.Patients;
                    let body = JSON.stringify(this.mergePatientFormViewModel.Patients);
                    let responseObject = null;
                    await this.httpService.post(mergePatientsUrl, body)
                        .then(response => {
                            responseObject = response;
                            ServiceLocator.MessageService.showInfo("responseObject");
                        })
                        .catch(error => {
                            console.log(error);
                        });*/

                }
            }
            else
                ServiceLocator.MessageService.showInfo(resultStr);

        }
        catch (err) {
            console.error(err);
            ServiceLocator.MessageService.showError(err);
        }
    }

    private async mergePatients_(): Promise<void> {

        //try {

        //    let body = JSON.stringify(this.mergePatientFormViewModel.Patients);

        //    let checkMergePatientsUrl: string = '/api/MergePatientService/CheckMergePatients=' + this.mergePatientFormViewModel.Patients;

        //    let response = await this.httpService.post(checkMergePatientsUrl, body).toPromise();

        //    let result = response.json().Result;
        //    if (result == "") {
        //        let message: string;
        //        message = "Birleştirilmek istenen hastalar farklıdır. Devam etmek istiyor musunuz?";
        //        let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', 'Uyarı', message, '1');
        //        if (result === "OK") {
        //            let mergePatientsUrl: string = '/api/MergePatientService/CheckMergePatients=' + this.mergePatientFormViewModel.Patients;

        //            await this.httpService.post(mergePatientsUrl, body)
        //                .toPromise()
        //                .then(response => {
        //                    result = response.json().Result;
        //                    ServiceLocator.MessageService.showInfo(result);
        //                })
        //                .catch(error => {
        //                    console.log(error);
        //                });

        //        }
        //    }
        //    else
        //        ServiceLocator.MessageService.showInfo(result);
        //}
        //catch (ex) {
        //    TTVisual.InfoBox.Show(ex);
        //}
    }

    // *****Method declarations end *****

    public initViewModel(): void {
       /* this._TTObject = new MergePatient();
        this.mergePatientFormViewModel = new MergePatientFormViewModel();
        this._ViewModel = this.mergePatientFormViewModel;
        this.mergePatientFormViewModel._MergePatient = this._TTObject as MergePatient; */
    }

    protected loadViewModel() {
      /*  let that = this;

        that.mergePatientFormViewModel = this._ViewModel as MergePatientFormViewModel;
        that._TTObject = this.mergePatientFormViewModel._MergePatient;
        if (this.mergePatientFormViewModel == null)
            this.mergePatientFormViewModel = new MergePatientFormViewModel();
        if (this.mergePatientFormViewModel._MergePatient == null)
            this.mergePatientFormViewModel._MergePatient = new MergePatient();
*/
    }

    async ngOnInit() {
        //await this.load();
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.btnMergePatient = new TTVisual.TTButton();
        this.btnMergePatient.Text = i18n("M11894", "Birleştir");
        this.btnMergePatient.Name = "btnMergePatient";
        this.btnMergePatient.TabIndex = 4;


        this.Controls = [this.btnMergePatient];

    }


}
