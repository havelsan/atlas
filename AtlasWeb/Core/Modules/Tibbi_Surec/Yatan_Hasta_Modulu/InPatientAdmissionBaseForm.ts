//$CC61969C
import { Component, OnInit, NgZone } from '@angular/core';
import { InPatientAdmissionBaseFormViewModel } from './InPatientAdmissionBaseFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';


@Component({
    selector: 'InPatientAdmissionBaseForm',
    templateUrl: './InPatientAdmissionBaseForm.html',
    providers: [MessageService]
})
export class InPatientAdmissionBaseForm extends EpisodeActionForm implements OnInit {
    BaseNumberOfEmptyBeds: TTVisual.ITTTextBox;
    public inPatientAdmissionBaseFormViewModel: InPatientAdmissionBaseFormViewModel = new InPatientAdmissionBaseFormViewModel();
    public get _InpatientAdmission(): InpatientAdmission {
        return this._TTObject as InpatientAdmission;
    }
    private InPatientAdmissionBaseForm_DocumentUrl: string = '/api/InpatientAdmissionService/InPatientAdmissionBaseForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InPatientAdmissionBaseForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //super.ClientSidePostScript(transDef);
        //this.ToReturnToClinic(transDef);
    }
    protected async ClientSidePreScript(): Promise<void> {
        //super.ClientSidePreScript();
        //this.SetNumberOfEmptyBedsByPhysicalStateClinic();
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        //super.PostScript(transDef);
        //if (transDef !== null) {
        //    if (transDef.ToStateDef.Status === StateStatusEnum.Cancelled) {
        //        let givenMsg: string = (await EpisodeService.GivenValuableMaterialsMsg(this._InpatientAdmission.Episode));
        //        let takenMsg: string = (await EpisodeService.TakenValuableMaterialsMsg(this._InpatientAdmission.Episode));
        //        if (givenMsg !== "" || takenMsg !== "") {
        //            if (transDef.ToStateDef.Status === StateStatusEnum.Cancelled)
        //                throw new Exception((await SystemMessageService.GetMessageV3(1175, [givenMsg.toString(), takenMsg.toString()])));
        //        }
        //    }
        //}
    }
    protected async PreScript() {
       // super.PreScript();
        //if (this._InpatientAdmission.CurrentStateDef.FindOutoingTransitionDefFromStateDefID(InpatientAdmission.InpatientAdmissionStates.FinancialDepartmentControl) !== null) {
        //    if ((await SystemParameterService.GetParameterValue("SKIPINPATIENTADMISSIONDOSEAPPROVESTATE", "FALSE")) === "FALSE") {
        //        if ((await EpisodeActionService.RequiresFinancialDepartmentControl(this._InpatientAdmission)))
        //            this.DropStateButton(InpatientAdmission.InpatientAdmissionStates.FinancialDepartmentControl);
        //    }
        //    else this.DropStateButton(InpatientAdmission.InpatientAdmissionStates.FinancialDepartmentControl);
        //}
    }
    //protected async SetNumberOfEmptyBedsByPhysicalStateClinic(): Promise<void> {
    //    if (this.BaseNumberOfEmptyBeds.Visible === true) {
    //        if (this._InpatientAdmission.PhysicalStateClinic === null) {
    //            this.BaseNumberOfEmptyBeds.Text = "";
    //        }
    //        else {
    //            this.BaseNumberOfEmptyBeds.Text = Convert.toString((await CommonService.GetNumberOfEmptyBeds(<Guid>this._InpatientAdmission.PhysicalStateClinic.ObjectID)));
    //        }
    //    }
    //}
    //TODO Servera taşınılmalı
    //public async ControlBedProcedureCount(): Promise<void> {
    //    let yatisGunuFazlaligi: number = (await InpatientAdmissionService.GetExcessOfRealBedDayToBedProcedure(this._InpatientAdmission));//bedDay - bedProcedureCount;
    //    if (yatisGunuFazlaligi !== 0) {
    //        let message: string = "\"\"";
    //        if (yatisGunuFazlaligi > 0)
    //            message = "Hastanın yattığı gün sayısı " + yatisGunuFazlaligi.toString() + " gün fazla.";
    //        else message = "Yatak hizmeti sayısı  " + ((-1) * yatisGunuFazlaligi).toString() + " gün fazla.";
    //        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Hastanın yattığı gün sayısı ile oluşan yatak hizmeti sayısı arasında uyumsuzluk vardır!\r\n " + message + "\r\nDevam etmek istiyor musunuz?", 1);
    //        if (result === "H")
    //            throw new Exception((await SystemMessageService.GetMessage(80)));
    //    }
    //}
    public async ToReturnToClinic(transDef: TTObjectStateTransitionDef): Promise<void> {
        //if (transDef !== null) {
        //    if (transDef.ToStateDefID === InpatientAdmission.InpatientAdmissionStates.ReturnToClinic) {
        //        let frm: StringEntryForm = new StringEntryForm();
        //        this._InpatientAdmission.ReturnToClinicReason = this._InpatientAdmission.ReturnToClinicReason + "\r\n" + (await CommonService.RecTime()).toString() + " " + frm.ShowAndGetStringForm("Kliniğe İade Sebebi");
        //        let mSItem: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        //        for (let iPTCA of this._InpatientAdmission.InPatientTreatmentClinicApplications) {
        //            mSItem.AddMSItem(iPTCA.MasterResource.toString(), iPTCA.ObjectID.toString(), iPTCA);
        //        }
        //        let key: string = mSItem.GetMSItem(this, "İade ediceğiniz Kliniği seçiniz", true, true, false, false, true, true);
        //        if (!String.isNullOrEmpty(key)) {
        //            //Seçilen Klinik işlemlerinin masterresourceü secmastera atanır ReturnToClinic stepi secmastera göre iş listesine düşer.
        //            this._InpatientAdmission.SecondaryMasterResource = (<InPatientTreatmentClinicApplication>mSItem.MSSelectedItemObject).MasterResource;
        //        }
        //        else {
        //            throw new Exception((await SystemMessageService.GetMessage(1176)));
        //        }
        //    }
        //}
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientAdmission();
        this.inPatientAdmissionBaseFormViewModel = new InPatientAdmissionBaseFormViewModel();
        this._ViewModel = this.inPatientAdmissionBaseFormViewModel;
        this.inPatientAdmissionBaseFormViewModel._InpatientAdmission = this._TTObject as InpatientAdmission;
    }

    protected loadViewModel() {
        let that = this;
        //
        that.inPatientAdmissionBaseFormViewModel = this._ViewModel as InPatientAdmissionBaseFormViewModel;
        that._TTObject = this.inPatientAdmissionBaseFormViewModel._InpatientAdmission;
        if (this.inPatientAdmissionBaseFormViewModel == null)
            this.inPatientAdmissionBaseFormViewModel = new InPatientAdmissionBaseFormViewModel();
        if (this.inPatientAdmissionBaseFormViewModel._InpatientAdmission == null)
            this.inPatientAdmissionBaseFormViewModel._InpatientAdmission = new InpatientAdmission();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(InPatientAdmissionBaseFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.BaseNumberOfEmptyBeds = new TTVisual.TTTextBox();
        this.BaseNumberOfEmptyBeds.BackColor = "#F0F0F0";
        this.BaseNumberOfEmptyBeds.ReadOnly = true;
        this.BaseNumberOfEmptyBeds.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BaseNumberOfEmptyBeds.Name = "BaseNumberOfEmptyBeds";
        this.BaseNumberOfEmptyBeds.TabIndex = 2;

        this.Controls = [this.BaseNumberOfEmptyBeds];

    }


}
