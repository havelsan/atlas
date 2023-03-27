//$E4767B31
import { Component, OnInit  } from '@angular/core';
import { UpperExtremityFormViewModel } from './UpperExtremityFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseHCExaminationDynamicObjectForm } from "Modules/Tibbi_Surec/Saglik_Kurulu_Modulu/BaseHCExaminationDynamicObjectForm";
import { UpperExtremity } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'UpperExtremityForm',
    templateUrl: './UpperExtremityForm.html',
    providers: [MessageService]
})
export class UpperExtremityForm extends BaseHCExaminationDynamicObjectForm implements OnInit {
    FTRExpertApprove: TTVisual.ITTCheckBox;
    HeadDoctorApprove: TTVisual.ITTCheckBox;
    MedicalReason: TTVisual.ITTCheckBox;
    OrthopedicExpertApprove: TTVisual.ITTCheckBox;
    PsychiatricExpertApprove: TTVisual.ITTCheckBox;
    sEMG: TTVisual.ITTCheckBox;
    ThirdStepHealthInst: TTVisual.ITTCheckBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    public upperExtremityFormViewModel: UpperExtremityFormViewModel = new UpperExtremityFormViewModel();
    public get _UpperExtremity(): UpperExtremity {
        return this._TTObject as UpperExtremity;
    }
    private UpperExtremityForm_DocumentUrl: string = '/api/UpperExtremityService/UpperExtremityForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.UpperExtremityForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new UpperExtremity();
        this.upperExtremityFormViewModel = new UpperExtremityFormViewModel();
        this._ViewModel = this.upperExtremityFormViewModel;
        this.upperExtremityFormViewModel._UpperExtremity = this._TTObject as UpperExtremity;
    }

    protected loadViewModel() {
        let that = this;
        that.upperExtremityFormViewModel = this._ViewModel as UpperExtremityFormViewModel;
        that._TTObject = this.upperExtremityFormViewModel._UpperExtremity;
        if (this.upperExtremityFormViewModel == null)
            this.upperExtremityFormViewModel = new UpperExtremityFormViewModel();
        if (this.upperExtremityFormViewModel._UpperExtremity == null)
            this.upperExtremityFormViewModel._UpperExtremity = new UpperExtremity();

    }

    async ngOnInit() {
        await this.load();
    }

    public onFTRExpertApproveChanged(event): void {
        if (this._UpperExtremity != null && this._UpperExtremity.FTRExpertApprove != event) {
            this._UpperExtremity.FTRExpertApprove = event;
        }
    }

    public onHeadDoctorApproveChanged(event): void {
        if (this._UpperExtremity != null && this._UpperExtremity.HeadDoctorApprove != event) {
            this._UpperExtremity.HeadDoctorApprove = event;
        }
    }

    public onMedicalReasonChanged(event): void {
        if (this._UpperExtremity != null && this._UpperExtremity.MedicalReason != event) {
            this._UpperExtremity.MedicalReason = event;
        }
    }

    public onOrthopedicExpertApproveChanged(event): void {
        if (this._UpperExtremity != null && this._UpperExtremity.OrthopedicExpertApprove != event) {
            this._UpperExtremity.OrthopedicExpertApprove = event;
        }
    }

    public onPsychiatricExpertApproveChanged(event): void {
        if (this._UpperExtremity != null && this._UpperExtremity.PsychiatricExpertApprove != event) {
            this._UpperExtremity.PsychiatricExpertApprove = event;
        }
    }

    public onsEMGChanged(event): void {
        if (this._UpperExtremity != null && this._UpperExtremity.sEMG != event) {
            this._UpperExtremity.sEMG = event;
        }
    }

    public onThirdStepHealthInstChanged(event): void {
        if (this._UpperExtremity != null && this._UpperExtremity.ThirdStepHealthInst != event) {
            this._UpperExtremity.ThirdStepHealthInst = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.MedicalReason, "Value", this.__ttObject, "MedicalReason");
        redirectProperty(this.sEMG, "Value", this.__ttObject, "sEMG");
        redirectProperty(this.ThirdStepHealthInst, "Value", this.__ttObject, "ThirdStepHealthInst");
        redirectProperty(this.FTRExpertApprove, "Value", this.__ttObject, "FTRExpertApprove");
        redirectProperty(this.OrthopedicExpertApprove, "Value", this.__ttObject, "OrthopedicExpertApprove");
        redirectProperty(this.PsychiatricExpertApprove, "Value", this.__ttObject, "PsychiatricExpertApprove");
        redirectProperty(this.HeadDoctorApprove, "Value", this.__ttObject, "HeadDoctorApprove");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Sağlık Kurulu";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.HeadDoctorApprove = new TTVisual.TTCheckBox();
        this.HeadDoctorApprove.Value = false;
        this.HeadDoctorApprove.Title = "Başhekim Onayı";
        this.HeadDoctorApprove.Name = "HeadDoctorApprove";
        this.HeadDoctorApprove.TabIndex = 6;

        this.PsychiatricExpertApprove = new TTVisual.TTCheckBox();
        this.PsychiatricExpertApprove.Value = false;
        this.PsychiatricExpertApprove.Title = "Psikiyatri Uzman Onayı";
        this.PsychiatricExpertApprove.Name = "PsychiatricExpertApprove";
        this.PsychiatricExpertApprove.TabIndex = 5;

        this.OrthopedicExpertApprove = new TTVisual.TTCheckBox();
        this.OrthopedicExpertApprove.Value = false;
        this.OrthopedicExpertApprove.Title = "Ortopedi Uzman Onayı";
        this.OrthopedicExpertApprove.Name = "OrthopedicExpertApprove";
        this.OrthopedicExpertApprove.TabIndex = 4;

        this.FTRExpertApprove = new TTVisual.TTCheckBox();
        this.FTRExpertApprove.Value = false;
        this.FTRExpertApprove.Title = "FTR Uzman Onayı";
        this.FTRExpertApprove.Name = "FTRExpertApprove";
        this.FTRExpertApprove.TabIndex = 3;

        this.ThirdStepHealthInst = new TTVisual.TTCheckBox();
        this.ThirdStepHealthInst.Value = false;
        this.ThirdStepHealthInst.Title = "3. basamak sağlık kurumu";
        this.ThirdStepHealthInst.Name = "ThirdStepHealthInst";
        this.ThirdStepHealthInst.TabIndex = 2;

        this.sEMG = new TTVisual.TTCheckBox();
        this.sEMG.Value = false;
        this.sEMG.Title = "sEMG Belgelendirilmiş mi?";
        this.sEMG.Name = "sEMG";
        this.sEMG.TabIndex = 1;

        this.MedicalReason = new TTVisual.TTCheckBox();
        this.MedicalReason.Value = false;
        this.MedicalReason.Title = "Tıbbi Gerekçe Yazılmış mı?";
        this.MedicalReason.Name = "MedicalReason";
        this.MedicalReason.TabIndex = 0;

        this.ttgroupbox1.Controls = [this.HeadDoctorApprove, this.PsychiatricExpertApprove, this.OrthopedicExpertApprove, this.FTRExpertApprove, this.ThirdStepHealthInst, this.sEMG, this.MedicalReason];
        this.Controls = [this.ttgroupbox1, this.HeadDoctorApprove, this.PsychiatricExpertApprove, this.OrthopedicExpertApprove, this.FTRExpertApprove, this.ThirdStepHealthInst, this.sEMG, this.MedicalReason];

    }


}
