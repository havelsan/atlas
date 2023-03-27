//$C49546FC
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyTestBaseFormViewModel } from "./RadiologyTestBaseFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { RadiologyRejectReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyRejectReasonDefinitionService } from "ObjectClassService/RadiologyRejectReasonDefinitionService";
import { RadiologyRepeatReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyRepeatReasonDefinitionService } from "ObjectClassService/RadiologyRepeatReasonDefinitionService";
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { SubactionProcedureFlowableForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SubactionProcedureFlowableForm";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { TestResultQueryInputDVO } from "Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { InfoBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';



@Component({
    selector: 'RadiologyTestBaseForm',
    templateUrl: './RadiologyTestBaseForm.html',
    providers: [MessageService]
})
export class RadiologyTestBaseForm extends SubactionProcedureFlowableForm implements OnInit {
    public radiologyTestBaseFormViewModel: RadiologyTestBaseFormViewModel = new RadiologyTestBaseFormViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    private RadiologyTestBaseForm_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestBaseForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyTestBaseForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    viewResultURL: string = "";



    public async GetViewResultURLForAllEpisodes(EpisodeID:string ,PatientTCKN :string ): Promise<void> {

        let that = this;
        let inputDVO = new TestResultQueryInputDVO();

        inputDVO.PatientTCKN = PatientTCKN;
        inputDVO.EpisodeID = EpisodeID;

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllEpisodeTestResults';
        let result = await this.httpService.post<string>(apiUrl, inputDVO);
        this.viewResultURL = result;
    }

    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Bu hizmetin sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }

    // ***** Method declarations start *****

    protected async PreScript() {
        super.PreScript();
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.ClientSidePostScript(transDef);
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.PostScript(transDef);
    }

    public async DisplayRadiologyRejectReason(): Promise<void> {
        let rejectionList: Array<any> = (await RadiologyRejectReasonDefinitionService.GetAll());
        let rejectionFrm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        let i: number = 1;
        for (let reason of rejectionList) {
            rejectionFrm.AddMSItem(reason.Name.toString(), "K-" + i.toString(), reason);
            i = i + 1;
        }
        let key: string = await rejectionFrm.GetMSItem(null, i18n("M20976", "Red Nedeni Seçiniz"), false, false, false, false, false, true);
        this._RadiologyTest.RejectReason = <RadiologyRejectReasonDefinition>rejectionFrm.MSSelectedItemObject;
    }
    public async DisplayRadiologyRepeatReason(): Promise<void> {

        let repeatList: Array<any> = (await RadiologyRepeatReasonDefinitionService.GetAll());
        let repeatFrm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        let i: number = 1;
        for (let reason of repeatList) {
            repeatFrm.AddMSItem(reason.Name.toString(), "K-" + i.toString(), reason);
            i = i + 1;
        }
        let key: string = await repeatFrm.GetMSItem(null, i18n("M23126", "Tekrar Nedeni Seçiniz"), false, false, false, false, false, true);
        this._RadiologyTest.RepeatReason = <RadiologyRepeatReasonDefinition>repeatFrm.MSSelectedItemObject;

    }
    public async LinkRadiologyTestToCopyReportInfo(transDef: TTObjectStateTransitionDef): Promise<void> {
        /*
        if (!String.isNullOrEmpty(this._RadiologyTest.ReportTxt)) {
            let testFrm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            if (transDef.FromStateDefID === RadiologyTest.RadiologyTestStates.ResultEntry || transDef.FromStateDefID === RadiologyTest.RadiologyTestStates.Approve) {
                for (let tetkik of this._RadiologyTest.Radiology.RadiologyTests) {
                    if (this._RadiologyTest !== tetkik && tetkik.CurrentStateDefID === transDef.FromStateDefID) {
                        testFrm.AddMSItem(tetkik.ProcedureObject.Code.toString() + "-" + tetkik.ProcedureObject.Name.toString(), tetkik.ObjectID.toString(), <Object>tetkik);
                    }
                }
            }
            let key: string = testFrm.GetMSItem(null, "Sonuç Raporunu kopyalamak istediğiniz tetkikleri seçiniz.", false, false, true, false, false, false);
            if (!String.isNullOrEmpty(key)) {
                //coklu secım yapilabiliyor

                for (let rt of this._RadiologyTest.Radiology.RadiologyTests) {
                    if (testFrm.MSSelectedItems.containsKey(rt.ObjectID.toString())) {
                        //RadiologyTest rt = (RadiologyTest)this._RadiologyTest.ObjectContext.GetObject(new Guid(selectedItem.Key), "RadiologyTest");
                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", rt.ID + " no'lu işlem için de aynı rapor kopyalanacak ve bu işlem de Tamam aşamasına alınacaktır.\nDevam etmek istediğinize emin misiniz?") === "E") {
                            rt.Report = this._RadiologyTest.Report;
                            rt.ReportDate = this._RadiologyTest.ReportDate;
                            rt.ReportedBy = this._RadiologyTest.ReportedBy;
                            rt.ReportTxt = this._RadiologyTest.ReportTxt;
                            rt.CurrentStateDefID = RadiologyTest.RadiologyTestStates.Completed;
                        }
                        else TTVisual.InfoBox.Alert("Sonuç raporu kopyalama işleminden vazgeçildi. Sadece bu tetkik için süreç tamamlanacaktır.", MessageIconEnum.InformationMessage);
                    }
                }
            }
            else TTVisual.InfoBox.Alert("Sonuç raporu kopyalanacak tetkik seçilmedi. Sadece bu tetkik için süreç tamamlanacaktır.", MessageIconEnum.InformationMessage);
        }
        */
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestBaseFormViewModel = new RadiologyTestBaseFormViewModel();
        this._ViewModel = this.radiologyTestBaseFormViewModel;
        this.radiologyTestBaseFormViewModel._RadiologyTest = this._TTObject as RadiologyTest;
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestBaseFormViewModel = this._ViewModel as RadiologyTestBaseFormViewModel;
        that._TTObject = this.radiologyTestBaseFormViewModel._RadiologyTest;
        if (this.radiologyTestBaseFormViewModel == null)
            this.radiologyTestBaseFormViewModel = new RadiologyTestBaseFormViewModel();
        if (this.radiologyTestBaseFormViewModel._RadiologyTest == null)
            this.radiologyTestBaseFormViewModel._RadiologyTest = new RadiologyTest();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyTestBaseFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }

    public getParamsFunctionForRadiology(): ClickFunctionParams {
        let patient = this._RadiologyTest.Episode["Patient"];
        let patientObjectID: Guid;
        if (patient != null && (typeof patient === 'string')) {
            patientObjectID = new Guid(patient);
        } else if (patient != null)
            patientObjectID = patient.ObjectID;
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(new Guid(this._RadiologyTest.EpisodeAction.toString()), this._RadiologyTest.Episode.ObjectID, patientObjectID));
        return clickFunctionParams;
    }


}
