//$612E588E
import { Component, OnInit, NgZone } from '@angular/core';
import { InpatientPrescriptionBaseFormViewModel } from './InpatientPrescriptionBaseFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionBaseForm } from "Modules/Saglik_Lojistik/Eczane_Evrensel_Modulu/PrescriptionBaseForm";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'InpatientPrescriptionBaseForm',
    templateUrl: './InpatientPrescriptionBaseForm.html',
    providers: [MessageService]
})
export class InpatientPrescriptionBaseForm extends PrescriptionBaseForm implements OnInit {
    public inpatientPrescriptionBaseFormViewModel: InpatientPrescriptionBaseFormViewModel = new InpatientPrescriptionBaseFormViewModel();
    public get _InpatientPrescription(): InpatientPrescription {
        return this._TTObject as InpatientPrescription;
    }
    private InpatientPrescriptionBaseForm_DocumentUrl: string = '/api/InpatientPrescriptionService/InpatientPrescriptionBaseForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InpatientPrescriptionBaseForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async CancelERecete(ExistsEHUUOnay: boolean): Promise<void> {
      /*  if (!String.isNullOrEmpty(this._InpatientPrescription.EReceteNo)) {
            let callerObject: Prescription.InpatientPrescriptionWebCaller = new Prescription.InpatientPrescriptionWebCaller();
            callerObject.ObjectID = this._InpatientPrescription.ObjectID;
            if (String.isNullOrEmpty(this._InpatientPrescription.ERecetePassword))
                throw new TTException("Doktorun E reçete şifresi girilmemiş.");
            if (this._InpatientPrescription.IsSignedPrescription()) {

            }
            else {

            }
            if (ExistsEHUUOnay) {
                let resOnay: TTMessage = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this._InpatientPrescription.ProcedureDoctor.UniqueNo.toString(), this._InpatientPrescription.ERecetePassword.toString(), callerObject, (await PrescriptionService.GetEreceteApprovalCancelRequest(this._InpatientPrescription)));
                if (String.isNullOrEmpty(this._InpatientPrescription.EHURecetePassword) === false && String.isNullOrEmpty(this._InpatientPrescription.EHUUniqueNo) === false) {
                    let uniqueNo: number = <number>Convert.ToDouble(this._InpatientPrescription.EHUUniqueNo);
                    let ehuOnayIptal: TTMessage = EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this._InpatientPrescription.EHUUniqueNo, this._InpatientPrescription.EHURecetePassword, callerObject, (await PrescriptionService.GetEreceteEHUCancelRequest(this._InpatientPrescription, uniqueNo)));
                }
            }
            else {
                EReceteIslemleri.WebMethods.ereceteOnayIptal(Sites.SiteLocalHost, this._InpatientPrescription.ProcedureDoctor.Person.UniqueRefNo.toString(), this._InpatientPrescription.ERecetePassword.toString(), callerObject, (await PrescriptionService.GetEreceteApprovalCancelRequest(this._InpatientPrescription)));
            }
        }*/
    }
    public async SendSignedEreceteEHUApproval(currentUser: ResUser): Promise<void> {
        let uniqueNo: number = <number>Convert.ToDouble(currentUser.UniqueNo);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientPrescription();
        this.inpatientPrescriptionBaseFormViewModel = new InpatientPrescriptionBaseFormViewModel();
        this._ViewModel = this.inpatientPrescriptionBaseFormViewModel;
        this.inpatientPrescriptionBaseFormViewModel._InpatientPrescription = this._TTObject as InpatientPrescription;
    }

    protected loadViewModel() {
        let that = this;

        that.inpatientPrescriptionBaseFormViewModel = this._ViewModel as InpatientPrescriptionBaseFormViewModel;
        that._TTObject = this.inpatientPrescriptionBaseFormViewModel._InpatientPrescription;
        if (this.inpatientPrescriptionBaseFormViewModel == null)
            this.inpatientPrescriptionBaseFormViewModel = new InpatientPrescriptionBaseFormViewModel();
        if (this.inpatientPrescriptionBaseFormViewModel._InpatientPrescription == null)
            this.inpatientPrescriptionBaseFormViewModel._InpatientPrescription = new InpatientPrescription();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(InpatientPrescriptionBaseFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
