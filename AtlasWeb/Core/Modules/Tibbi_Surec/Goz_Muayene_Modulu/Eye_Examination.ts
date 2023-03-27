//$07AAF2B9
import { Component, OnInit, NgZone } from '@angular/core'; 
import { Eye_ExaminationViewModel } from "./Eye_ExaminationViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EyeExamination } from 'NebulaClient/Model/AtlasClientModel';
import { VisualSharpnessDefinitionNew } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityBasedObjectForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm";
///////
import { EpisodeActionHelper } from "app/Helper/EpisodeActionHelper";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { IModalService } from "Fw/Services/IModalService";
import { GlassesReport } from 'NebulaClient/Model/AtlasClientModel';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
///////

import { OldGlassesReport } from "Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/GlassesReportFormViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { HelpMenuService } from 'app/Fw/Services/HelpMenuService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'Eye_Examination',
    templateUrl: './Eye_Examination.html',
    providers: [MessageService, EpisodeActionHelper]
})
export class Eye_Examination extends SpecialityBasedObjectForm implements OnInit {
    AutorefLeftEyeMeasureAxis: TTVisual.ITTTextBox;
    AutorefLeftEyeMeasureCYL: TTVisual.ITTTextBox;
    AutorefLeftEyeMeasureSPH: TTVisual.ITTTextBox;
    AutorefRightEyeMeasureAxis: TTVisual.ITTTextBox;
    AutorefRightEyeMeasureCYL: TTVisual.ITTTextBox;
    AutorefRightEyeMeasureSPH: TTVisual.ITTTextBox;
    CyclAutorefLeftEyeMeasureAxis: TTVisual.ITTTextBox;
    CyclAutorefLeftEyeMeasureCYL: TTVisual.ITTTextBox;
    CyclAutorefLeftEyeMeasureSPH: TTVisual.ITTTextBox;
    CyclAutorefRightEyeMeasureAxis: TTVisual.ITTTextBox;
    CyclAutorefRightEyeMeasureCYL: TTVisual.ITTTextBox;
    CyclAutorefRightEyeMeasureSPH: TTVisual.ITTTextBox;
    GlassVisSharpLeftFarAxis: TTVisual.ITTTextBox;
    GlassVisSharpLeftFarCYL: TTVisual.ITTTextBox;
    GlassVisSharpLeftFarSPH: TTVisual.ITTTextBox;
    GlassVisSharpLeftNearAxis: TTVisual.ITTTextBox;
    GlassVisSharpLeftNearCYL: TTVisual.ITTTextBox;
    GlassVisSharpLeftNearSPH: TTVisual.ITTTextBox;
    GlassVisSharpRightFarAxis: TTVisual.ITTTextBox;
    GlassVisSharpRightFarCYL: TTVisual.ITTTextBox;
    GlassVisSharpRightFarSPH: TTVisual.ITTTextBox;
    GlassVisSharpRightNearAxis: TTVisual.ITTTextBox;
    GlassVisSharpRightNearCYL: TTVisual.ITTTextBox;
    GlassVisSharpRightNearSPH: TTVisual.ITTTextBox;
    LeftEyeBiomicroscopy: TTVisual.ITTRichTextBoxControl;
    LeftEyeFundus: TTVisual.ITTRichTextBoxControl;
    LeftEyeMovements: TTVisual.ITTRichTextBoxControl;
    LeftEyePressure: TTVisual.ITTTextBox;
    NoGlassVisSharpLeftFarAxis: TTVisual.ITTTextBox;
    NoGlassVisSharpLeftFarCYL: TTVisual.ITTTextBox;
    NoGlassVisSharpLeftFarSPH: TTVisual.ITTTextBox;
    NoGlassVisSharpLeftNearAxis: TTVisual.ITTTextBox;
    NoGlassVisSharpLeftNearCYL: TTVisual.ITTTextBox;
    NoGlassVisSharpLeftNearSPH: TTVisual.ITTTextBox;
    NoGlassVisSharpRightFarAxis: TTVisual.ITTTextBox;
    NoGlassVisSharpRightFarCYL: TTVisual.ITTTextBox;
    NoGlassVisSharpRightFarSPH: TTVisual.ITTTextBox;
    NoGlassVisSharpRightNearAxis: TTVisual.ITTTextBox;
    NoGlassVisSharpRightNearCYL: TTVisual.ITTTextBox;
    NoGlassVisSharpRightNearSPH: TTVisual.ITTTextBox;
    PatientGlassesLeftFarAxis: TTVisual.ITTTextBox;
    PatientGlassesLeftFarCYL: TTVisual.ITTTextBox;
    PatientGlassesLeftFarSPH: TTVisual.ITTTextBox;
    PatientGlassesLeftNearAxis: TTVisual.ITTTextBox;
    PatientGlassesLeftNearCYL: TTVisual.ITTTextBox;
    PatientGlassesLeftNearSPH: TTVisual.ITTTextBox;
    PatientGlassesRightFarAxis: TTVisual.ITTTextBox;
    PatientGlassesRightFarCYL: TTVisual.ITTTextBox;
    PatientGlassesRightFarSPH: TTVisual.ITTTextBox;
    PatientGlassesRightNearAxis: TTVisual.ITTTextBox;
    PatientGlassesRightNearCYL: TTVisual.ITTTextBox;
    PatientGlassesRightNearSPH: TTVisual.ITTTextBox;
    RightEyeBiomicroscopy: TTVisual.ITTRichTextBoxControl;
    RightEyeFundus: TTVisual.ITTRichTextBoxControl;
    RightEyeMovements: TTVisual.ITTRichTextBoxControl;
    RightEyePressure: TTVisual.ITTTextBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttgroupbox4: TTVisual.ITTGroupBox;
    ttgroupbox5: TTVisual.ITTGroupBox;
    ttgroupbox6: TTVisual.ITTGroupBox;
    ttgroupbox7: TTVisual.ITTGroupBox;
    ttgroupbox8: TTVisual.ITTGroupBox;
    ttgroupbox9: TTVisual.ITTGroupBox;
    showPopup: boolean = false;
    ////////
    LeftEyeBiomicroscopyTB: TTVisual.ITTTextBox;
    LeftEyeFundusTB: TTVisual.ITTTextBox;
    LeftEyeMovementsTB: TTVisual.ITTTextBox;
    RightEyeBiomicroscopyTB: TTVisual.ITTTextBox;
    RightEyeFundusTB: TTVisual.ITTTextBox;
    RightEyeMovementsTB: TTVisual.ITTTextBox;
    ////////

    public glassesReportObj: GlassesReport = null;
    public glassesreportvisible: boolean = false;
    public oldGlassesReports: Array<OldGlassesReport> = new Array<OldGlassesReport>();
    public OldGlassesReportsGridColumns = [];

    VisualSharpnessNoGlassRightValue: TTVisual.ITTObjectListBox;
    VisualSharpnessGlassLeftValue: TTVisual.ITTObjectListBox;
    VisualSharpnessGlassRightValue: TTVisual.ITTObjectListBox;
    VisualSharpnessNoGlassLeftValue: TTVisual.ITTObjectListBox;
    public eye_ExaminationViewModel: Eye_ExaminationViewModel = new Eye_ExaminationViewModel();
    public get _EyeExamination(): EyeExamination {
        return this._TTObject as EyeExamination;
    }
    private Eye_Examination_DocumentUrl: string = '/api/EyeExaminationService/Eye_Examination';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private objectContextService: ObjectContextService,
        protected episodeActionHelper: EpisodeActionHelper,
        protected ngZone: NgZone) {
        super(httpService, messageService); // super("EYEEXAMINATION", "Eye_Examination") /**/modalService, episodeActionHelper/**/
        this._DocumentServiceUrl = this.Eye_Examination_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    ///////////////////////////////////////////////////////////////////////
    private showGlassesReport(data: GlassesReport, newGlassesReportCheck: boolean): Promise<ModalActionResult> {
let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "GlassesReportForm";
            componentInfo.ModuleName = "HastaRaporlariModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(new Guid(that._EyeExamination.PhysicianApplication.toString()), null,null));
            if (!newGlassesReportCheck) {
                componentInfo.objectID = data.ObjectID.toString();
            }
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M14963", "Gözlük Reçetesi");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                this.httpService.get<Array<any>>(`api/EyeExaminationService/GetOldGlassesReports?eyeExamination=${this.eye_ExaminationViewModel._EyeExamination.ObjectID}`).then(result => {
                    this.oldGlassesReports = result;
                    if (inner.Result == DialogResult.Yes) {
                        let tempGlassesReport: GlassesReport = <GlassesReport>inner.Param;
                        if (tempGlassesReport.EReceteNo != null) {
                            TTVisual.InfoBox.Alert(i18n("M23738", "Uyarı!"), "Medula'dan alınan son cevap :<br>E-Reçete No : " + tempGlassesReport.EReceteNo + "<br>Sonuç Kodu : " + tempGlassesReport.SonucKodu + "<br>Sonuç Açıklaması : " + tempGlassesReport.SonucAciklamasi, 2, 350, 400);
                        } else {
                            let infoBox: TTVisual.InfoBox;
                            TTVisual.InfoBox.Alert( i18n("M23738", "Uyarı!"), "Medula'dan alınan son cevap :<br>Sonuç Kodu : " + tempGlassesReport.SonucKodu + "<br>Sonuç Açıklaması : " + tempGlassesReport.SonucAciklamasi, 2, 350, 400);
                        }
                    } else if (inner.Result == DialogResult.Abort) {
                        let tempGlassesReport: GlassesReport = <GlassesReport>inner.Param;
                        TTVisual.InfoBox.Alert(i18n("M23738", "Uyarı!"), "Medula'dan alınan son cevap :<br>Sonuç Kodu : " + tempGlassesReport.SonucKodu + "<br>Sonuç Açıklaması : " + tempGlassesReport.SonucAciklamasi, 2, 350, 400);
                    }
                });
            }).catch(err => {
                reject(err);
            });
        });
    }
    onGlassesReportOpen() {
        if(this.eye_ExaminationViewModel.hasDiagnosis != true){
            ServiceLocator.MessageService.showError("Hastaya tanı kaydetmeden reçete yazamazsınız");
            return;
        }
        this.episodeActionHelper.getNewEpisodeAction(GlassesReport.ObjectDefID, this.eye_ExaminationViewModel.PhysicianApplicationEpisodeID, GlassesReport.GlassesReportStates.New).then(result => {
            //this.glassesReportObj = result as GlassesReport;
            let glassesReport: GlassesReport = result as GlassesReport;
            //this.glassesreportvisible = true;
            this.showGlassesReport(glassesReport, true);
        }).catch(err => {
            this.messageService.showError(err);
        });

    }

    selectOldGlassesReport(value: any) {

        let objectID: Guid = value.data.ObjectId;
        this.objectContextService.getObject<GlassesReport>(objectID, GlassesReport.ObjectDefID).then(result => {
            //this.glassesReportObj = result as GlassesReport;
            //this.glassesreportvisible = true;
            this.showGlassesReport(result, false);

        });
    }
    //////////////////////////////////////////////////////////////////////

    private editorConfig: any = {
        removePlugins: 'toolbar,elementspath',
        height: '103px'
    };
    private editorConfig2: any = {
        removePlugins: 'toolbar,elementspath',
        height: '130px'
    };

    // ***** Method declarations start *****

    private AutorefLeftEyeMeasureAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.AutorefLeftEyeMeasureAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.AutorefLeftEyeMeasureAxis.Text = "";
        }
    }
    private AutorefLeftEyeMeasureCYL_TextChanged(): void {
        this.AutorefLeftEyeMeasureCYL.Text = this.changeCommaToDot(this.AutorefLeftEyeMeasureCYL.Text).toString();
    }
    private AutorefLeftEyeMeasureSPH_TextChanged(): void {
        this.AutorefLeftEyeMeasureSPH.Text = this.changeCommaToDot(this.AutorefLeftEyeMeasureSPH.Text).toString();
    }
    private AutorefRightEyeMeasureAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.AutorefRightEyeMeasureAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.AutorefRightEyeMeasureAxis.Text = "";
        }
    }
    private AutorefRightEyeMeasureCYL_TextChanged(): void {
        this.AutorefRightEyeMeasureCYL.Text = this.changeCommaToDot(this.AutorefRightEyeMeasureCYL.Text).toString();
    }
    private AutorefRightEyeMeasureSPH_TextChanged(): void {
        this.AutorefRightEyeMeasureSPH.Text = this.changeCommaToDot(this.AutorefRightEyeMeasureSPH.Text).toString();
    }
    private changeCommaToDot(enteredValue: string): string {
        if (typeof enteredValue === "string") {
            if (enteredValue.includes(",", 0)) {
                enteredValue = enteredValue.replace(",", ".");
            }
        }
        return enteredValue;
    }
    private checkAxisBoundary(enteredValue: string): boolean {
        let checkVal: number = +enteredValue;
        if (checkVal >= 0 && checkVal < 181) {
            return true;
        }
        else {
            return false;
        }
    }
    private checkMultiplicity(enteredValue: string): boolean {
        let checkVal: number = +enteredValue;
        if (checkVal % 0.25 === 0) {
            return true;
        }
        else {
            return false;
        }
    }
    private CyclAutorefLeftEyeMeasureAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.CyclAutorefLeftEyeMeasureAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.CyclAutorefLeftEyeMeasureAxis.Text = "";
        }
    }
    private CyclAutorefLeftEyeMeasureCYL_TextChanged(): void {
        this.CyclAutorefLeftEyeMeasureCYL.Text = this.changeCommaToDot(this.CyclAutorefLeftEyeMeasureCYL.Text).toString();
    }
    private CyclAutorefLeftEyeMeasureSPH_TextChanged(): void {
        this.CyclAutorefLeftEyeMeasureSPH.Text = this.changeCommaToDot(this.CyclAutorefLeftEyeMeasureSPH.Text).toString();
    }
    private CyclAutorefRightEyeMeasureAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.CyclAutorefRightEyeMeasureAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.CyclAutorefRightEyeMeasureAxis.Text = "";
        }
    }
    private CyclAutorefRightEyeMeasureCYL_TextChanged(): void {
        this.CyclAutorefRightEyeMeasureCYL.Text = this.changeCommaToDot(this.CyclAutorefRightEyeMeasureCYL.Text).toString();
    }
    private CyclAutorefRightEyeMeasureSPH_TextChanged(): void {
        this.CyclAutorefRightEyeMeasureSPH.Text = this.changeCommaToDot(this.CyclAutorefRightEyeMeasureSPH.Text).toString();
    }
    private GlassVisSharpLeftFarAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.GlassVisSharpLeftFarAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.GlassVisSharpLeftFarAxis.Text = "";
        }
    }
    private GlassVisSharpLeftFarCYL_TextChanged(): void {
        this.GlassVisSharpLeftFarCYL.Text = this.changeCommaToDot(this.GlassVisSharpLeftFarCYL.Text).toString();
    }
    private GlassVisSharpLeftFarSPH_TextChanged(): void {
        this.GlassVisSharpLeftFarSPH.Text = this.changeCommaToDot(this.GlassVisSharpLeftFarSPH.Text).toString();
    }
    private GlassVisSharpLeftNearAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.GlassVisSharpLeftNearAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.GlassVisSharpLeftNearAxis.Text = "";
        }
    }
    private GlassVisSharpLeftNearCYL_TextChanged(): void {
        this.GlassVisSharpLeftNearCYL.Text = this.changeCommaToDot(this.GlassVisSharpLeftNearCYL.Text).toString();
    }
    private GlassVisSharpLeftNearSPH_TextChanged(): void {
        this.GlassVisSharpLeftNearSPH.Text = this.changeCommaToDot(this.GlassVisSharpLeftNearSPH.Text).toString();
    }
    private GlassVisSharpRightFarAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.GlassVisSharpRightFarAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.GlassVisSharpRightFarAxis.Text = "";
        }
    }
    private GlassVisSharpRightFarCYL_TextChanged(): void {
        this.GlassVisSharpRightFarCYL.Text = this.changeCommaToDot(this.GlassVisSharpRightFarCYL.Text).toString();
    }
    private GlassVisSharpRightFarSPH_TextChanged(): void {
        this.GlassVisSharpRightFarSPH.Text = this.changeCommaToDot(this.GlassVisSharpRightFarSPH.Text).toString();
    }
    private GlassVisSharpRightNearAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.GlassVisSharpRightNearAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.GlassVisSharpRightNearAxis.Text = "";
        }
    }
    private GlassVisSharpRightNearCYL_TextChanged(): void {
        this.GlassVisSharpRightNearCYL.Text = this.changeCommaToDot(this.GlassVisSharpRightNearCYL.Text).toString();
    }
    private GlassVisSharpRightNearSPH_TextChanged(): void {
        this.GlassVisSharpRightNearSPH.Text = this.changeCommaToDot(this.GlassVisSharpRightNearSPH.Text).toString();
    }
    private LeftEyePressure_TextChanged(): void {
        this.LeftEyePressure.Text = this.changeCommaToDot(this.LeftEyePressure.Text).toString();
    }
    private NoGlassVisSharpLeftFarAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.NoGlassVisSharpLeftFarAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.NoGlassVisSharpLeftFarAxis.Text = "";
        }
    }
    private NoGlassVisSharpLeftFarCYL_TextChanged(): void {
        this.NoGlassVisSharpLeftFarCYL.Text = this.changeCommaToDot(this.NoGlassVisSharpLeftFarCYL.Text).toString();
    }
    private NoGlassVisSharpLeftFarSPH_TextChanged(): void {
        this.NoGlassVisSharpLeftFarSPH.Text = this.changeCommaToDot(this.NoGlassVisSharpLeftFarSPH.Text).toString();
    }
    private NoGlassVisSharpLeftNearAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.NoGlassVisSharpLeftNearAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.NoGlassVisSharpLeftNearAxis.Text = "";
        }
    }
    private NoGlassVisSharpLeftNearCYL_TextChanged(): void {
        this.NoGlassVisSharpLeftNearCYL.Text = this.changeCommaToDot(this.NoGlassVisSharpLeftNearCYL.Text).toString();
    }
    private NoGlassVisSharpLeftNearSPH_TextChanged(): void {
        this.NoGlassVisSharpLeftNearSPH.Text = this.changeCommaToDot(this.NoGlassVisSharpLeftNearSPH.Text).toString();
    }
    private NoGlassVisSharpRightFarAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.NoGlassVisSharpRightFarAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.NoGlassVisSharpRightFarAxis.Text = "";
        }
    }
    private NoGlassVisSharpRightFarCYL_TextChanged(): void {
        this.NoGlassVisSharpRightFarCYL.Text = this.changeCommaToDot(this.NoGlassVisSharpRightFarCYL.Text).toString();
    }
    private NoGlassVisSharpRightFarSPH_TextChanged(): void {
        this.NoGlassVisSharpRightFarSPH.Text = this.changeCommaToDot(this.NoGlassVisSharpRightFarSPH.Text).toString();
    }
    private NoGlassVisSharpRightNearAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.NoGlassVisSharpRightNearAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.NoGlassVisSharpRightNearAxis.Text = "";
        }
    }
    private NoGlassVisSharpRightNearCYL_TextChanged(): void {
        this.NoGlassVisSharpRightNearCYL.Text = this.changeCommaToDot(this.NoGlassVisSharpRightNearCYL.Text).toString();
    }
    private NoGlassVisSharpRightNearSPH_TextChanged(): void {
        this.NoGlassVisSharpRightNearSPH.Text = this.changeCommaToDot(this.NoGlassVisSharpRightNearSPH.Text).toString();
    }
    private PatientGlassesLeftFarAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.PatientGlassesLeftFarAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.PatientGlassesLeftFarAxis.Text = "";
        }
    }
    private PatientGlassesLeftFarCYL_TextChanged(): void {
        this.PatientGlassesLeftFarCYL.Text = this.changeCommaToDot(this.PatientGlassesLeftFarCYL.Text).toString();
    }
    private PatientGlassesLeftFarSPH_TextChanged(): void {
        this.PatientGlassesLeftFarSPH.Text = this.changeCommaToDot(this.PatientGlassesLeftFarSPH.Text).toString();
    }
    private PatientGlassesLeftNearAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.PatientGlassesLeftNearAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.PatientGlassesLeftNearAxis.Text = "";
        }
    }
    private PatientGlassesLeftNearCYL_TextChanged(): void {
        this.PatientGlassesLeftNearCYL.Text = this.changeCommaToDot(this.PatientGlassesLeftNearCYL.Text).toString();
    }
    private PatientGlassesLeftNearSPH_TextChanged(): void {
        this.PatientGlassesLeftNearSPH.Text = this.changeCommaToDot(this.PatientGlassesLeftNearSPH.Text).toString();
    }
    private PatientGlassesRightFarAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.PatientGlassesRightFarAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.PatientGlassesRightFarAxis.Text = "";
        }
    }
    private PatientGlassesRightFarCYL_TextChanged(): void {
        this.PatientGlassesRightFarCYL.Text = this.changeCommaToDot(this.PatientGlassesRightFarCYL.Text).toString();
    }
    private PatientGlassesRightFarSPH_TextChanged(): void {
        this.PatientGlassesRightFarSPH.Text = this.changeCommaToDot(this.PatientGlassesRightFarSPH.Text).toString();
    }
    private PatientGlassesRightNearAxis_TextChanged(): void {
        if (!this.checkAxisBoundary(this.PatientGlassesRightNearAxis.Text)) {
            TTVisual.InfoBox.Alert(i18n("M10639", "AKS değeri 0 ile 180 arasında olmalıdır!"));
            this.PatientGlassesRightNearAxis.Text = "";
        }
    }
    private PatientGlassesRightNearCYL_TextChanged(): void {
        this.PatientGlassesRightNearCYL.Text = this.changeCommaToDot(this.PatientGlassesRightNearCYL.Text).toString();
    }
    private PatientGlassesRightNearSPH_TextChanged(): void {
        this.PatientGlassesRightNearSPH.Text = this.changeCommaToDot(this.PatientGlassesRightNearSPH.Text).toString();
    }
    private RightEyePressure_TextChanged(): void {
        this.RightEyePressure.Text = this.changeCommaToDot(this.RightEyePressure.Text).toString();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        let that = this;
        this._TTObject = new EyeExamination();
        this.eye_ExaminationViewModel = new Eye_ExaminationViewModel();
        this._ViewModel = that.eye_ExaminationViewModel;
        this.eye_ExaminationViewModel._EyeExamination = this._TTObject as EyeExamination;
        this.eye_ExaminationViewModel._EyeExamination.NoGlassVisSharpLeftVal = new VisualSharpnessDefinitionNew();
        this.eye_ExaminationViewModel._EyeExamination.NoGlassVisSharpRightVal = new VisualSharpnessDefinitionNew();
        this.eye_ExaminationViewModel._EyeExamination.GlassVisSharpRightVal = new VisualSharpnessDefinitionNew();
        this.eye_ExaminationViewModel._EyeExamination.GlassVisSharpLeftVal = new VisualSharpnessDefinitionNew();
    }

    protected loadViewModel() {
        let that = this;
        that.eye_ExaminationViewModel = this._ViewModel as Eye_ExaminationViewModel;
        that._TTObject = this.eye_ExaminationViewModel._EyeExamination;
        if (this.eye_ExaminationViewModel == null)
            this.eye_ExaminationViewModel = new Eye_ExaminationViewModel();
        if (this.eye_ExaminationViewModel._EyeExamination == null)
            this.eye_ExaminationViewModel._EyeExamination = new EyeExamination();
        let noGlassVisSharpLeftValObjectID = that.eye_ExaminationViewModel._EyeExamination["NoGlassVisSharpLeftVal"];
        if (noGlassVisSharpLeftValObjectID != null && (typeof noGlassVisSharpLeftValObjectID === 'string')) {
            let noGlassVisSharpLeftVal = that.eye_ExaminationViewModel.VisualSharpnessDefinitionNews.find(o => o.ObjectID.toString() === noGlassVisSharpLeftValObjectID.toString());
             if (noGlassVisSharpLeftVal) {
                that.eye_ExaminationViewModel._EyeExamination.NoGlassVisSharpLeftVal = noGlassVisSharpLeftVal;
            }
        }
        let noGlassVisSharpRightValObjectID = that.eye_ExaminationViewModel._EyeExamination["NoGlassVisSharpRightVal"];
        if (noGlassVisSharpRightValObjectID != null && (typeof noGlassVisSharpRightValObjectID === 'string')) {
            let noGlassVisSharpRightVal = that.eye_ExaminationViewModel.VisualSharpnessDefinitionNews.find(o => o.ObjectID.toString() === noGlassVisSharpRightValObjectID.toString());
             if (noGlassVisSharpRightVal) {
                that.eye_ExaminationViewModel._EyeExamination.NoGlassVisSharpRightVal = noGlassVisSharpRightVal;
            }
        }
        let glassVisSharpRightValObjectID = that.eye_ExaminationViewModel._EyeExamination["GlassVisSharpRightVal"];
        if (glassVisSharpRightValObjectID != null && (typeof glassVisSharpRightValObjectID === 'string')) {
            let glassVisSharpRightVal = that.eye_ExaminationViewModel.VisualSharpnessDefinitionNews.find(o => o.ObjectID.toString() === glassVisSharpRightValObjectID.toString());
             if (glassVisSharpRightVal) {
                that.eye_ExaminationViewModel._EyeExamination.GlassVisSharpRightVal = glassVisSharpRightVal;
            }
        }
        let glassVisSharpLeftValObjectID = that.eye_ExaminationViewModel._EyeExamination["GlassVisSharpLeftVal"];
        if (glassVisSharpLeftValObjectID != null && (typeof glassVisSharpLeftValObjectID === 'string')) {
            let glassVisSharpLeftVal = that.eye_ExaminationViewModel.VisualSharpnessDefinitionNews.find(o => o.ObjectID.toString() === glassVisSharpLeftValObjectID.toString());
             if (glassVisSharpLeftVal) {
                that.eye_ExaminationViewModel._EyeExamination.GlassVisSharpLeftVal = glassVisSharpLeftVal;
            }
        }

        this.httpService.get<Array<any>>(`api/EyeExaminationService/GetOldGlassesReports?eyeExamination=${this.eye_ExaminationViewModel._EyeExamination.ObjectID}`).then(result => {
            this.oldGlassesReports = result;
        });

    }



    async ngOnInit()  {
        let that = this;
        await this.load(Eye_ExaminationViewModel);
  
    }

    public onAutorefLeftEyeMeasureAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.AutorefLeftEyeMeasureAxis != event) {
                this._EyeExamination.AutorefLeftEyeMeasureAxis = event;
            }
        }
        this.AutorefLeftEyeMeasureAxis_TextChanged();
    }

    public onAutorefLeftEyeMeasureCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.AutorefLeftEyeMeasureCYL != event) {
                this._EyeExamination.AutorefLeftEyeMeasureCYL = event;
            }
        }
        this.AutorefLeftEyeMeasureCYL_TextChanged();
    }

    public onAutorefLeftEyeMeasureSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.AutorefLeftEyeMeasureSPH != event) {
                this._EyeExamination.AutorefLeftEyeMeasureSPH = event;
            }
        }
        this.AutorefLeftEyeMeasureSPH_TextChanged();
    }

    public onAutorefRightEyeMeasureAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.AutorefRightEyeMeasureAxis != event) {
                this._EyeExamination.AutorefRightEyeMeasureAxis = event;
            }
        }
        this.AutorefRightEyeMeasureAxis_TextChanged();
    }

    public onAutorefRightEyeMeasureCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.AutorefRightEyeMeasureCYL != event) {
                this._EyeExamination.AutorefRightEyeMeasureCYL = event;
            }
        }
        this.AutorefRightEyeMeasureCYL_TextChanged();
    }

    public onAutorefRightEyeMeasureSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.AutorefRightEyeMeasureSPH != event) {
                this._EyeExamination.AutorefRightEyeMeasureSPH = event;
            }
        }
        this.AutorefRightEyeMeasureSPH_TextChanged();
    }

    public onCyclAutorefLeftEyeMeasureAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.CyclAutorefLeftMeasureAxis != event) {
                this._EyeExamination.CyclAutorefLeftMeasureAxis = event;
            }
        }
        this.CyclAutorefLeftEyeMeasureAxis_TextChanged();
    }

    public onCyclAutorefLeftEyeMeasureCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.CyclAutorefLeftMeasureCYL != event) {
                this._EyeExamination.CyclAutorefLeftMeasureCYL = event;
            }
        }
        this.CyclAutorefLeftEyeMeasureCYL_TextChanged();
    }

    public onCyclAutorefLeftEyeMeasureSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.CyclAutorefLeftMeasureSPH != event) {
                this._EyeExamination.CyclAutorefLeftMeasureSPH = event;
            }
        }
        this.CyclAutorefLeftEyeMeasureSPH_TextChanged();
    }

    public onCyclAutorefRightEyeMeasureAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.CyclAutorefRightMeasureAxis != event) {
                this._EyeExamination.CyclAutorefRightMeasureAxis = event;
            }
        }
        this.CyclAutorefRightEyeMeasureAxis_TextChanged();
    }

    public onCyclAutorefRightEyeMeasureCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.CyclAutorefRightMeasureCYL != event) {
                this._EyeExamination.CyclAutorefRightMeasureCYL = event;
            }
        }
        this.CyclAutorefRightEyeMeasureCYL_TextChanged();
    }

    public onCyclAutorefRightEyeMeasureSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.CyclAutorefRightMeasureSPH != event) {
                this._EyeExamination.CyclAutorefRightMeasureSPH = event;
            }
        }
        this.CyclAutorefRightEyeMeasureSPH_TextChanged();
    }

    public onGlassVisSharpLeftFarAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpLeftFarAxis != event) {
                this._EyeExamination.GlassVisSharpLeftFarAxis = event;
            }
        }
        this.GlassVisSharpLeftFarAxis_TextChanged();
    }

    public onGlassVisSharpLeftFarCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpLeftFarCYL != event) {
                this._EyeExamination.GlassVisSharpLeftFarCYL = event;
            }
        }
        this.GlassVisSharpLeftFarCYL_TextChanged();
    }

    public onGlassVisSharpLeftFarSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpLeftFarSPH != event) {
                this._EyeExamination.GlassVisSharpLeftFarSPH = event;
            }
        }
        this.GlassVisSharpLeftFarSPH_TextChanged();
    }

    public onGlassVisSharpLeftNearAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpLeftNearAxis != event) {
                this._EyeExamination.GlassVisSharpLeftNearAxis = event;
            }
        }
        this.GlassVisSharpLeftNearAxis_TextChanged();
    }

    public onGlassVisSharpLeftNearCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpLeftNearCYL != event) {
                this._EyeExamination.GlassVisSharpLeftNearCYL = event;
            }
        }
        this.GlassVisSharpLeftNearCYL_TextChanged();
    }

    public onGlassVisSharpLeftNearSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpLeftNearSPH != event) {
                this._EyeExamination.GlassVisSharpLeftNearSPH = event;
            }
        }
        this.GlassVisSharpLeftNearSPH_TextChanged();
    }

    public onGlassVisSharpRightFarAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpRightFarAxis != event) {
                this._EyeExamination.GlassVisSharpRightFarAxis = event;
            }
        }
        this.GlassVisSharpRightFarAxis_TextChanged();
    }

    public onGlassVisSharpRightFarCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpRightFarCYL != event) {
                this._EyeExamination.GlassVisSharpRightFarCYL = event;
            }
        }
        this.GlassVisSharpRightFarCYL_TextChanged();
    }

    public onGlassVisSharpRightFarSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpRightFarSPH != event) {
                this._EyeExamination.GlassVisSharpRightFarSPH = event;
            }
        }
        this.GlassVisSharpRightFarSPH_TextChanged();
    }

    public onGlassVisSharpRightNearAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpRightNearAxis != event) {
                this._EyeExamination.GlassVisSharpRightNearAxis = event;
            }
        }
        this.GlassVisSharpRightNearAxis_TextChanged();
    }

    public onGlassVisSharpRightNearCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpRightNearCYL != event) {
                this._EyeExamination.GlassVisSharpRightNearCYL = event;
            }
        }
        this.GlassVisSharpRightNearCYL_TextChanged();
    }

    public onGlassVisSharpRightNearSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpRightNearSPH != event) {
                this._EyeExamination.GlassVisSharpRightNearSPH = event;
            }
        }
        this.GlassVisSharpRightNearSPH_TextChanged();
    }

    public onLeftEyeBiomicroscopyChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.LeftEyeBiomicroscopy != event) {
                this._EyeExamination.LeftEyeBiomicroscopy = event;
            }
        }
    }

    public onLeftEyeFundusChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.LeftEyeFundus != event) {
                this._EyeExamination.LeftEyeFundus = event;
            }
        }
    }

    public onLeftEyeMovementsChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.LeftEyeMovements != event) {
                this._EyeExamination.LeftEyeMovements = event;
            }
        }
    }

    public onLeftEyePressureChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.LeftEyePressure != event) {
                this._EyeExamination.LeftEyePressure = event;
            }
        }
        this.LeftEyePressure_TextChanged();
    }

    public onNoGlassVisSharpLeftFarAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpLeftFarAxis != event) {
                this._EyeExamination.NoGlassVisSharpLeftFarAxis = event;
            }
        }
        this.NoGlassVisSharpLeftFarAxis_TextChanged();
    }

    public onNoGlassVisSharpLeftFarCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpLeftFarCYL != event) {
                this._EyeExamination.NoGlassVisSharpLeftFarCYL = event;
            }
        }
        this.NoGlassVisSharpLeftFarCYL_TextChanged();
    }

    public onNoGlassVisSharpLeftFarSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpLeftFarSPH != event) {
                this._EyeExamination.NoGlassVisSharpLeftFarSPH = event;
            }
        }
        this.NoGlassVisSharpLeftFarSPH_TextChanged();
    }

    public onNoGlassVisSharpLeftNearAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpLeftNearAxis != event) {
                this._EyeExamination.NoGlassVisSharpLeftNearAxis = event;
            }
        }
        this.NoGlassVisSharpLeftNearAxis_TextChanged();
    }

    public onNoGlassVisSharpLeftNearCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpLeftNearCYL != event) {
                this._EyeExamination.NoGlassVisSharpLeftNearCYL = event;
            }
        }
        this.NoGlassVisSharpLeftNearCYL_TextChanged();
    }

    public onNoGlassVisSharpLeftNearSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpLeftNearSPH != event) {
                this._EyeExamination.NoGlassVisSharpLeftNearSPH = event;
            }
        }
        this.NoGlassVisSharpLeftNearSPH_TextChanged();
    }

    public onNoGlassVisSharpRightFarAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpRightFarAxis != event) {
                this._EyeExamination.NoGlassVisSharpRightFarAxis = event;
            }
        }
        this.NoGlassVisSharpRightFarAxis_TextChanged();
    }

    public onNoGlassVisSharpRightFarCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpRightFarCYL != event) {
                this._EyeExamination.NoGlassVisSharpRightFarCYL = event;
            }
        }
        this.NoGlassVisSharpRightFarCYL_TextChanged();
    }

    public onNoGlassVisSharpRightFarSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpRightFarSPH != event) {
                this._EyeExamination.NoGlassVisSharpRightFarSPH = event;
            }
        }
        this.NoGlassVisSharpRightFarSPH_TextChanged();
    }

    public onNoGlassVisSharpRightNearAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpRightNearAxis != event) {
                this._EyeExamination.NoGlassVisSharpRightNearAxis = event;
            }
        }
        this.NoGlassVisSharpRightNearAxis_TextChanged();
    }

    public onNoGlassVisSharpRightNearCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpRightNearCYL != event) {
                this._EyeExamination.NoGlassVisSharpRightNearCYL = event;
            }
        }
        this.NoGlassVisSharpRightNearCYL_TextChanged();
    }

    public onNoGlassVisSharpRightNearSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpRightNearSPH != event) {
                this._EyeExamination.NoGlassVisSharpRightNearSPH = event;
            }
        }
        this.NoGlassVisSharpRightNearSPH_TextChanged();
    }

    public onPatientGlassesLeftFarAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesLeftFarAxis != event) {
                this._EyeExamination.PatientGlassesLeftFarAxis = event;
            }
        }
        this.PatientGlassesLeftFarAxis_TextChanged();
    }

    public onPatientGlassesLeftFarCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesLeftFarCYL != event) {
                this._EyeExamination.PatientGlassesLeftFarCYL = event;
            }
        }
        this.PatientGlassesLeftFarCYL_TextChanged();
    }

    public onPatientGlassesLeftFarSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesLeftFarSPH != event) {
                this._EyeExamination.PatientGlassesLeftFarSPH = event;
            }
        }
        this.PatientGlassesLeftFarSPH_TextChanged();
    }

    public onPatientGlassesLeftNearAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesLeftNearAxis != event) {
                this._EyeExamination.PatientGlassesLeftNearAxis = event;
            }
        }
        this.PatientGlassesLeftNearAxis_TextChanged();
    }

    public onPatientGlassesLeftNearCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesLeftNearCYL != event) {
                this._EyeExamination.PatientGlassesLeftNearCYL = event;
            }
        }
        this.PatientGlassesLeftNearCYL_TextChanged();
    }

    public onPatientGlassesLeftNearSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesLeftNearSPH != event) {
                this._EyeExamination.PatientGlassesLeftNearSPH = event;
            }
        }
        this.PatientGlassesLeftNearSPH_TextChanged();
    }

    public onPatientGlassesRightFarAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesRightFarAxis != event) {
                this._EyeExamination.PatientGlassesRightFarAxis = event;
            }
        }
        this.PatientGlassesRightFarAxis_TextChanged();
    }

    public onPatientGlassesRightFarCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesRightFarCYL != event) {
                this._EyeExamination.PatientGlassesRightFarCYL = event;
            }
        }
        this.PatientGlassesRightFarCYL_TextChanged();
    }

    public onPatientGlassesRightFarSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesRightFarSPH != event) {
                this._EyeExamination.PatientGlassesRightFarSPH = event;
            }
        }
        this.PatientGlassesRightFarSPH_TextChanged();
    }

    public onPatientGlassesRightNearAxisChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesRightNearAxis != event) {
                this._EyeExamination.PatientGlassesRightNearAxis = event;
            }
        }
        this.PatientGlassesRightNearAxis_TextChanged();
    }

    public popupShow(): void {
        this.showPopup = true;
    }

    public onPatientGlassesRightNearCYLChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesRightNearCYL != event) {
                this._EyeExamination.PatientGlassesRightNearCYL = event;
            }
        }
        this.PatientGlassesRightNearCYL_TextChanged();
    }

    public onPatientGlassesRightNearSPHChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.PatientGlassesRightNearSPH != event) {
                this._EyeExamination.PatientGlassesRightNearSPH = event;
            }
        }
        this.PatientGlassesRightNearSPH_TextChanged();
    }

    public onRightEyeBiomicroscopyChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.RightEyeBiomicroscopy != event) {
                this._EyeExamination.RightEyeBiomicroscopy = event;
            }
        }
    }

    public onRightEyeFundusChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.RightEyeFundus != event) {
                this._EyeExamination.RightEyeFundus = event;
            }
        }
    }

    public onRightEyeMovementsChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.RightEyeMovements != event) {
                this._EyeExamination.RightEyeMovements = event;
            }
        }
    }

    public onRightEyePressureChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.RightEyePressure != event) {
                this._EyeExamination.RightEyePressure = event;
            }
        }
        this.RightEyePressure_TextChanged();
    }

    public onVisualSharpnessNoGlassRightValueChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpRightVal != event) {
                this._EyeExamination.NoGlassVisSharpRightVal = event;
            }
        }
    }

    public onVisualSharpnessGlassLeftValueChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpLeftVal != event) {
                this._EyeExamination.GlassVisSharpLeftVal = event;
            }
        }
    }

    public onVisualSharpnessGlassRightValueChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.GlassVisSharpRightVal != event) {
                this._EyeExamination.GlassVisSharpRightVal = event;
            }
        }
    }

    public onVisualSharpnessNoGlassLeftValueChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.NoGlassVisSharpLeftVal != event) {
                this._EyeExamination.NoGlassVisSharpLeftVal = event;
            }
        }
    }

    //////////////////////////////////////////////////
    public onRightEyeBiomicroscopyTBChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.RightEyeBiomicroscopy != event) {
                this._EyeExamination.RightEyeBiomicroscopy = event;
            }
        }
    }

    public onRightEyeFundusTBChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.RightEyeFundus != event) {
                this._EyeExamination.RightEyeFundus = event;
            }
        }
    }

    public onRightEyeMovementsTBChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.RightEyeMovements != event) {
                this._EyeExamination.RightEyeMovements = event;
            }
        }
    }

    public onLeftEyeBiomicroscopyTBChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.LeftEyeBiomicroscopy != event) {
                this._EyeExamination.LeftEyeBiomicroscopy = event;
            }
        }
    }

    public onLeftEyeFundusTBChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.LeftEyeFundus != event) {
                this._EyeExamination.LeftEyeFundus = event;
            }
        }
    }

    public onLeftEyeMovementsTBChanged(event): void {
        if (event != null) {
            if (this._EyeExamination != null && this._EyeExamination.LeftEyeMovements != event) {
                this._EyeExamination.LeftEyeMovements = event;
            }
        }
    }

    /////////////////////////////////////////////////

    protected redirectProperties(): void {
        redirectProperty(this.AutorefLeftEyeMeasureSPH, "Text", this.__ttObject, "AutorefLeftEyeMeasureSPH");
        redirectProperty(this.AutorefLeftEyeMeasureCYL, "Text", this.__ttObject, "AutorefLeftEyeMeasureCYL");
        redirectProperty(this.AutorefLeftEyeMeasureAxis, "Text", this.__ttObject, "AutorefLeftEyeMeasureAxis");
        redirectProperty(this.AutorefRightEyeMeasureSPH, "Text", this.__ttObject, "AutorefRightEyeMeasureSPH");
        redirectProperty(this.AutorefRightEyeMeasureCYL, "Text", this.__ttObject, "AutorefRightEyeMeasureCYL");
        redirectProperty(this.AutorefRightEyeMeasureAxis, "Text", this.__ttObject, "AutorefRightEyeMeasureAxis");
        redirectProperty(this.CyclAutorefLeftEyeMeasureSPH, "Text", this.__ttObject, "CyclAutorefLeftMeasureSPH");
        redirectProperty(this.CyclAutorefLeftEyeMeasureCYL, "Text", this.__ttObject, "CyclAutorefLeftMeasureCYL");
        redirectProperty(this.CyclAutorefLeftEyeMeasureAxis, "Text", this.__ttObject, "CyclAutorefLeftMeasureAxis");
        redirectProperty(this.CyclAutorefRightEyeMeasureSPH, "Text", this.__ttObject, "CyclAutorefRightMeasureSPH");
        redirectProperty(this.CyclAutorefRightEyeMeasureCYL, "Text", this.__ttObject, "CyclAutorefRightMeasureCYL");
        redirectProperty(this.CyclAutorefRightEyeMeasureAxis, "Text", this.__ttObject, "CyclAutorefRightMeasureAxis");
        redirectProperty(this.NoGlassVisSharpLeftNearSPH, "Text", this.__ttObject, "NoGlassVisSharpLeftNearSPH");
        redirectProperty(this.NoGlassVisSharpLeftNearCYL, "Text", this.__ttObject, "NoGlassVisSharpLeftNearCYL");
        redirectProperty(this.NoGlassVisSharpLeftNearAxis, "Text", this.__ttObject, "NoGlassVisSharpLeftNearAxis");
        redirectProperty(this.NoGlassVisSharpRightNearSPH, "Text", this.__ttObject, "NoGlassVisSharpRightNearSPH");
        redirectProperty(this.NoGlassVisSharpRightNearCYL, "Text", this.__ttObject, "NoGlassVisSharpRightNearCYL");
        redirectProperty(this.NoGlassVisSharpRightNearAxis, "Text", this.__ttObject, "NoGlassVisSharpRightNearAxis");
        redirectProperty(this.NoGlassVisSharpLeftFarSPH, "Text", this.__ttObject, "NoGlassVisSharpLeftFarSPH");
        redirectProperty(this.NoGlassVisSharpLeftFarCYL, "Text", this.__ttObject, "NoGlassVisSharpLeftFarCYL");
        redirectProperty(this.NoGlassVisSharpLeftFarAxis, "Text", this.__ttObject, "NoGlassVisSharpLeftFarAxis");
        redirectProperty(this.NoGlassVisSharpRightFarSPH, "Text", this.__ttObject, "NoGlassVisSharpRightFarSPH");
        redirectProperty(this.NoGlassVisSharpRightFarCYL, "Text", this.__ttObject, "NoGlassVisSharpRightFarCYL");
        redirectProperty(this.NoGlassVisSharpRightFarAxis, "Text", this.__ttObject, "NoGlassVisSharpRightFarAxis");
        redirectProperty(this.GlassVisSharpLeftNearSPH, "Text", this.__ttObject, "GlassVisSharpLeftNearSPH");
        redirectProperty(this.GlassVisSharpLeftNearCYL, "Text", this.__ttObject, "GlassVisSharpLeftNearCYL");
        redirectProperty(this.GlassVisSharpLeftNearAxis, "Text", this.__ttObject, "GlassVisSharpLeftNearAxis");
        redirectProperty(this.GlassVisSharpRightNearSPH, "Text", this.__ttObject, "GlassVisSharpRightNearSPH");
        redirectProperty(this.GlassVisSharpRightNearCYL, "Text", this.__ttObject, "GlassVisSharpRightNearCYL");
        redirectProperty(this.GlassVisSharpRightNearAxis, "Text", this.__ttObject, "GlassVisSharpRightNearAxis");
        redirectProperty(this.GlassVisSharpLeftFarSPH, "Text", this.__ttObject, "GlassVisSharpLeftFarSPH");
        redirectProperty(this.GlassVisSharpLeftFarCYL, "Text", this.__ttObject, "GlassVisSharpLeftFarCYL");
        redirectProperty(this.GlassVisSharpLeftFarAxis, "Text", this.__ttObject, "GlassVisSharpLeftFarAxis");
        redirectProperty(this.GlassVisSharpRightFarSPH, "Text", this.__ttObject, "GlassVisSharpRightFarSPH");
        redirectProperty(this.GlassVisSharpRightFarCYL, "Text", this.__ttObject, "GlassVisSharpRightFarCYL");
        redirectProperty(this.GlassVisSharpRightFarAxis, "Text", this.__ttObject, "GlassVisSharpRightFarAxis");
        redirectProperty(this.LeftEyeMovements, "Rtf", this.__ttObject, "LeftEyeMovements");
        redirectProperty(this.RightEyeMovements, "Rtf", this.__ttObject, "RightEyeMovements");
        redirectProperty(this.LeftEyeBiomicroscopy, "Rtf", this.__ttObject, "LeftEyeBiomicroscopy");
        redirectProperty(this.RightEyeBiomicroscopy, "Rtf", this.__ttObject, "RightEyeBiomicroscopy");
        redirectProperty(this.LeftEyeFundus, "Rtf", this.__ttObject, "LeftEyeFundus");
        redirectProperty(this.RightEyeFundus, "Rtf", this.__ttObject, "RightEyeFundus");
        redirectProperty(this.PatientGlassesLeftNearSPH, "Text", this.__ttObject, "PatientGlassesLeftNearSPH");
        redirectProperty(this.PatientGlassesLeftNearCYL, "Text", this.__ttObject, "PatientGlassesLeftNearCYL");
        redirectProperty(this.PatientGlassesLeftNearAxis, "Text", this.__ttObject, "PatientGlassesLeftNearAxis");
        redirectProperty(this.PatientGlassesRightNearSPH, "Text", this.__ttObject, "PatientGlassesRightNearSPH");
        redirectProperty(this.PatientGlassesRightNearCYL, "Text", this.__ttObject, "PatientGlassesRightNearCYL");
        redirectProperty(this.PatientGlassesRightNearAxis, "Text", this.__ttObject, "PatientGlassesRightNearAxis");
        redirectProperty(this.PatientGlassesLeftFarSPH, "Text", this.__ttObject, "PatientGlassesLeftFarSPH");
        redirectProperty(this.PatientGlassesLeftFarCYL, "Text", this.__ttObject, "PatientGlassesLeftFarCYL");
        redirectProperty(this.PatientGlassesLeftFarAxis, "Text", this.__ttObject, "PatientGlassesLeftFarAxis");
        redirectProperty(this.PatientGlassesRightFarSPH, "Text", this.__ttObject, "PatientGlassesRightFarSPH");
        redirectProperty(this.PatientGlassesRightFarCYL, "Text", this.__ttObject, "PatientGlassesRightFarCYL");
        redirectProperty(this.PatientGlassesRightFarAxis, "Text", this.__ttObject, "PatientGlassesRightFarAxis");
        redirectProperty(this.LeftEyePressure, "Text", this.__ttObject, "LeftEyePressure");
        redirectProperty(this.RightEyePressure, "Text", this.__ttObject, "RightEyePressure");


        //////
        redirectProperty(this.LeftEyeFundusTB, "Text", this.__ttObject, "LeftEyeFundus");
        redirectProperty(this.RightEyeFundusTB, "Text", this.__ttObject, "RightEyeFundus");
        redirectProperty(this.LeftEyeMovementsTB, "Text", this.__ttObject, "LeftEyeMovements");
        redirectProperty(this.RightEyeMovementsTB, "Text", this.__ttObject, "RightEyeMovements");
        redirectProperty(this.LeftEyeBiomicroscopyTB, "Text", this.__ttObject, "LeftEyeBiomicroscopy");
        redirectProperty(this.RightEyeBiomicroscopyTB, "Text", this.__ttObject, "RightEyeBiomicroscopy");
        //////
    }

    public initFormControls(): void {
        //
        this.OldGlassesReportsGridColumns = [
            {
                caption: ' ',
                dataField: 'ObjectId',
                cellTemplate: 'buttonCellTemplate',
                width: 70
            },
            {
                'caption': i18n("M16886", "İşlem Tarihi"),
                dataField: 'ActionDate',
                allowSorting: true,
                dataType: 'date'
            },
            {
                'caption': i18n("M13824", 'E-Reçete No'),
                dataField: 'GlassesReportNo',
                allowSorting: true
            },
            {
                'caption': i18n("M16838", "İşlem Durumu"),
                dataField: 'currentState',
                allowSorting: true
            }
        ];

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Otoref";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M21864", "Sikloplejili Otoref");
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 0;

        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = i18n("M15221", "Hasta Gözlük Bilgisi");
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 0;

        this.ttgroupbox4 = new TTVisual.TTGroupBox();
        this.ttgroupbox4.Text = i18n("M12170", "Camsız Görme Keskinliği");
        this.ttgroupbox4.Name = "ttgroupbox4";
        this.ttgroupbox4.TabIndex = 0;

        this.ttgroupbox5 = new TTVisual.TTGroupBox();
        this.ttgroupbox5.Text = i18n("M12168", "Camlı Görme Keskinliği");
        this.ttgroupbox5.Name = "ttgroupbox5";
        this.ttgroupbox5.TabIndex = 0;

        this.ttgroupbox6 = new TTVisual.TTGroupBox();
        this.ttgroupbox6.Text = "Biyomikroskopi";
        this.ttgroupbox6.Name = "ttgroupbox6";
        this.ttgroupbox6.TabIndex = 0;

        this.ttgroupbox7 = new TTVisual.TTGroupBox();
        this.ttgroupbox7.Text = i18n("M14943", "Göz İçi Basınç(mmHG)");
        this.ttgroupbox7.Name = "ttgroupbox7";
        this.ttgroupbox7.TabIndex = 1;

        this.ttgroupbox8 = new TTVisual.TTGroupBox();
        this.ttgroupbox8.Text = i18n("M14941", "Göz Hareketleri");
        this.ttgroupbox8.Name = "ttgroupbox8";
        this.ttgroupbox8.TabIndex = 2;

        this.ttgroupbox9 = new TTVisual.TTGroupBox();
        this.ttgroupbox9.Text = "Fundus";
        this.ttgroupbox9.Name = "ttgroupbox9";
        this.ttgroupbox9.TabIndex = 0;

        /////////////////////////////////////////////////////////////////////////

        this.LeftEyeMovements = new TTVisual.TTRichTextBoxControl();
        this.LeftEyeMovements.Name = "LeftEyeMovements";
        this.LeftEyeMovements.TabIndex = 0;

        this.RightEyeMovements = new TTVisual.TTRichTextBoxControl();
        this.RightEyeMovements.Name = "RightEyeMovements";
        this.RightEyeMovements.TabIndex = 0;

        this.LeftEyeBiomicroscopy = new TTVisual.TTRichTextBoxControl();
        this.LeftEyeBiomicroscopy.Name = "LeftEyeBiomicroscopy";
        this.LeftEyeBiomicroscopy.TabIndex = 0;

        this.RightEyeBiomicroscopy = new TTVisual.TTRichTextBoxControl();
        this.RightEyeBiomicroscopy.Name = "RightEyeBiomicroscopy";
        this.RightEyeBiomicroscopy.TabIndex = 0;

        this.LeftEyeFundus = new TTVisual.TTRichTextBoxControl();
        this.LeftEyeFundus.Name = "LeftEyeFundus";
        this.LeftEyeFundus.TabIndex = 0;

        this.RightEyeFundus = new TTVisual.TTRichTextBoxControl();
        this.RightEyeFundus.Name = "RightEyeFundus";
        this.RightEyeFundus.TabIndex = 0;

        this.RightEyePressure = new TTVisual.TTTextBox();
        this.RightEyePressure.Name = "RightEyePressure";
        this.RightEyePressure.TabIndex = 2;

        this.LeftEyePressure = new TTVisual.TTTextBox();
        this.LeftEyePressure.Name = "LeftEyePressure";
        this.LeftEyePressure.TabIndex = 0;

        ////////////////////////////////////////////////////////////////////////


        //////////*******************/////////////////////

        this.LeftEyeMovementsTB = new TTVisual.TTTextBox();
        this.LeftEyeMovementsTB.Name = "LeftEyeMovements";
        this.LeftEyeMovementsTB.TabIndex = 0;
        this.LeftEyeMovementsTB.Multiline = true;
        this.LeftEyeMovementsTB.Height = '103px';

        this.RightEyeMovementsTB = new TTVisual.TTTextBox();
        this.RightEyeMovementsTB.Name = "RightEyeMovements";
        this.RightEyeMovementsTB.TabIndex = 0;
        this.RightEyeMovementsTB.Multiline = true;
        this.RightEyeMovementsTB.Height = '103px';

        this.LeftEyeBiomicroscopyTB = new TTVisual.TTTextBox();
        this.LeftEyeBiomicroscopyTB.Name = "LeftEyeBiomicroscopy";
        this.LeftEyeBiomicroscopyTB.TabIndex = 0;
        this.LeftEyeBiomicroscopyTB.Multiline = true;
        this.LeftEyeBiomicroscopyTB.Height = '103px';


        this.RightEyeBiomicroscopyTB = new TTVisual.TTTextBox();
        this.RightEyeBiomicroscopyTB.Name = "RightEyeBiomicroscopy";
        this.RightEyeBiomicroscopyTB.TabIndex = 0;
        this.RightEyeBiomicroscopyTB.Multiline = true;
        this.RightEyeBiomicroscopyTB.Height = '103px';

        this.LeftEyeFundusTB = new TTVisual.TTTextBox();
        this.LeftEyeFundusTB.Name = "LeftEyeFundus";
        this.LeftEyeFundusTB.TabIndex = 0;
        this.LeftEyeFundusTB.Multiline = true;
        this.LeftEyeFundusTB.Height = '130px';


        this.RightEyeFundusTB = new TTVisual.TTTextBox();
        this.RightEyeFundusTB.Name = "RightEyeFundus";
        this.RightEyeFundusTB.TabIndex = 0;
        this.RightEyeFundusTB.Multiline = true;
        this.RightEyeFundusTB.Height = '130px';


        ////////////******************///////////////////

        this.VisualSharpnessNoGlassLeftValue = new TTVisual.TTObjectListBox();
        this.VisualSharpnessNoGlassLeftValue.ListDefName = "VisualSharpnessList";
        this.VisualSharpnessNoGlassLeftValue.Name = "VisualSharpnessNoGlassLeftValue";
        this.VisualSharpnessNoGlassLeftValue.TabIndex = 0;
        this.VisualSharpnessNoGlassLeftValue.Width = "100%";

        this.VisualSharpnessNoGlassRightValue = new TTVisual.TTObjectListBox();
        this.VisualSharpnessNoGlassRightValue.ListDefName = "VisualSharpnessList";
        this.VisualSharpnessNoGlassRightValue.Name = "VisualSharpnessNoGlassRightValue";
        this.VisualSharpnessNoGlassRightValue.TabIndex = 0;
        this.VisualSharpnessNoGlassRightValue.Width = "100%";

        this.VisualSharpnessGlassRightValue = new TTVisual.TTObjectListBox();
        this.VisualSharpnessGlassRightValue.ListDefName = "VisualSharpnessList";
        this.VisualSharpnessGlassRightValue.Name = "VisualSharpnessGlassRightValue";
        this.VisualSharpnessGlassRightValue.TabIndex = 0;
        this.VisualSharpnessGlassRightValue.Width = "100%";

        this.VisualSharpnessGlassLeftValue = new TTVisual.TTObjectListBox();
        this.VisualSharpnessGlassLeftValue.ListDefName = "VisualSharpnessList";
        this.VisualSharpnessGlassLeftValue.Name = "VisualSharpnessGlassLeftValue";
        this.VisualSharpnessGlassLeftValue.TabIndex = 0;
        this.VisualSharpnessGlassLeftValue.Width = "100%";
        ///////////////////////////////////////////////////////////////////////

        this.AutorefLeftEyeMeasureSPH = new TTVisual.TTTextBox();
        this.AutorefLeftEyeMeasureSPH.Name = "AutorefLeftEyeMeasureSPH";
        this.AutorefLeftEyeMeasureSPH.TabIndex = 4;

        this.AutorefLeftEyeMeasureCYL = new TTVisual.TTTextBox();
        this.AutorefLeftEyeMeasureCYL.Name = "AutorefLeftEyeMeasureCYL";
        this.AutorefLeftEyeMeasureCYL.TabIndex = 2;

        this.AutorefLeftEyeMeasureAxis = new TTVisual.TTTextBox();
        this.AutorefLeftEyeMeasureAxis.Name = "AutorefLeftEyeMeasureAxis";
        this.AutorefLeftEyeMeasureAxis.TabIndex = 0;

        this.AutorefRightEyeMeasureSPH = new TTVisual.TTTextBox();
        this.AutorefRightEyeMeasureSPH.Name = "AutorefRightEyeMeasureSPH";
        this.AutorefRightEyeMeasureSPH.TabIndex = 4;

        this.AutorefRightEyeMeasureCYL = new TTVisual.TTTextBox();
        this.AutorefRightEyeMeasureCYL.Name = "AutorefRightEyeMeasureCYL";
        this.AutorefRightEyeMeasureCYL.TabIndex = 2;

        this.AutorefRightEyeMeasureAxis = new TTVisual.TTTextBox();
        this.AutorefRightEyeMeasureAxis.Name = "AutorefRightEyeMeasureAxis";
        this.AutorefRightEyeMeasureAxis.TabIndex = 0;

        this.CyclAutorefLeftEyeMeasureSPH = new TTVisual.TTTextBox();
        this.CyclAutorefLeftEyeMeasureSPH.Name = "CyclAutorefLeftEyeMeasureSPH";
        this.CyclAutorefLeftEyeMeasureSPH.TabIndex = 4;

        this.CyclAutorefLeftEyeMeasureCYL = new TTVisual.TTTextBox();
        this.CyclAutorefLeftEyeMeasureCYL.Name = "CyclAutorefLeftEyeMeasureCYL";
        this.CyclAutorefLeftEyeMeasureCYL.TabIndex = 2;

        this.CyclAutorefLeftEyeMeasureAxis = new TTVisual.TTTextBox();
        this.CyclAutorefLeftEyeMeasureAxis.Name = "CyclAutorefLeftEyeMeasureAxis";
        this.CyclAutorefLeftEyeMeasureAxis.TabIndex = 0;

        this.CyclAutorefRightEyeMeasureSPH = new TTVisual.TTTextBox();
        this.CyclAutorefRightEyeMeasureSPH.Name = "CyclAutorefRightEyeMeasureSPH";
        this.CyclAutorefRightEyeMeasureSPH.TabIndex = 4;

        this.CyclAutorefRightEyeMeasureCYL = new TTVisual.TTTextBox();
        this.CyclAutorefRightEyeMeasureCYL.Name = "CyclAutorefRightEyeMeasureCYL";
        this.CyclAutorefRightEyeMeasureCYL.TabIndex = 2;

        this.CyclAutorefRightEyeMeasureAxis = new TTVisual.TTTextBox();
        this.CyclAutorefRightEyeMeasureAxis.Name = "CyclAutorefRightEyeMeasureAxis";
        this.CyclAutorefRightEyeMeasureAxis.TabIndex = 0;

        this.PatientGlassesLeftNearSPH = new TTVisual.TTTextBox();
        this.PatientGlassesLeftNearSPH.Name = "PatientGlassesLeftNearSPH";
        this.PatientGlassesLeftNearSPH.TabIndex = 10;

        this.PatientGlassesLeftNearCYL = new TTVisual.TTTextBox();
        this.PatientGlassesLeftNearCYL.Name = "PatientGlassesLeftNearCYL";
        this.PatientGlassesLeftNearCYL.TabIndex = 8;

        this.PatientGlassesLeftNearAxis = new TTVisual.TTTextBox();
        this.PatientGlassesLeftNearAxis.Name = "PatientGlassesLeftNearAxis";
        this.PatientGlassesLeftNearAxis.TabIndex = 6;

        this.PatientGlassesRightNearSPH = new TTVisual.TTTextBox();
        this.PatientGlassesRightNearSPH.Name = "PatientGlassesRightNearSPH";
        this.PatientGlassesRightNearSPH.TabIndex = 22;

        this.PatientGlassesRightNearCYL = new TTVisual.TTTextBox();
        this.PatientGlassesRightNearCYL.Name = "PatientGlassesRightNearCYL";
        this.PatientGlassesRightNearCYL.TabIndex = 20;

        this.PatientGlassesRightNearAxis = new TTVisual.TTTextBox();
        this.PatientGlassesRightNearAxis.Name = "PatientGlassesRightNearAxis";
        this.PatientGlassesRightNearAxis.TabIndex = 18;


        this.PatientGlassesRightFarSPH = new TTVisual.TTTextBox();
        this.PatientGlassesRightFarSPH.Name = "PatientGlassesRightFarSPH";
        this.PatientGlassesRightFarSPH.TabIndex = 16;

        this.PatientGlassesRightFarCYL = new TTVisual.TTTextBox();
        this.PatientGlassesRightFarCYL.Name = "PatientGlassesRightFarCYL";
        this.PatientGlassesRightFarCYL.TabIndex = 14;

        this.PatientGlassesRightFarAxis = new TTVisual.TTTextBox();
        this.PatientGlassesRightFarAxis.Name = "PatientGlassesRightFarAxis";
        this.PatientGlassesRightFarAxis.TabIndex = 12;


        this.PatientGlassesLeftFarSPH = new TTVisual.TTTextBox();
        this.PatientGlassesLeftFarSPH.Name = "PatientGlassesLeftFarSPH";
        this.PatientGlassesLeftFarSPH.TabIndex = 4;

        this.PatientGlassesLeftFarCYL = new TTVisual.TTTextBox();
        this.PatientGlassesLeftFarCYL.Name = "PatientGlassesLeftFarCYL";
        this.PatientGlassesLeftFarCYL.TabIndex = 2;

        this.PatientGlassesLeftFarAxis = new TTVisual.TTTextBox();
        this.PatientGlassesLeftFarAxis.Name = "PatientGlassesLeftFarAxis";
        this.PatientGlassesLeftFarAxis.TabIndex = 0;


        this.NoGlassVisSharpLeftNearSPH = new TTVisual.TTTextBox();
        this.NoGlassVisSharpLeftNearSPH.Name = "NoGlassVisSharpLeftNearSPH";
        this.NoGlassVisSharpLeftNearSPH.TabIndex = 10;

        this.NoGlassVisSharpLeftNearCYL = new TTVisual.TTTextBox();
        this.NoGlassVisSharpLeftNearCYL.Name = "NoGlassVisSharpLeftNearCYL";
        this.NoGlassVisSharpLeftNearCYL.TabIndex = 8;

        this.NoGlassVisSharpLeftNearAxis = new TTVisual.TTTextBox();
        this.NoGlassVisSharpLeftNearAxis.Name = "NoGlassVisSharpLeftNearAxis";
        this.NoGlassVisSharpLeftNearAxis.TabIndex = 6;





        this.NoGlassVisSharpRightNearSPH = new TTVisual.TTTextBox();
        this.NoGlassVisSharpRightNearSPH.Name = "NoGlassVisSharpRightNearSPH";
        this.NoGlassVisSharpRightNearSPH.TabIndex = 22;

        this.NoGlassVisSharpRightNearCYL = new TTVisual.TTTextBox();
        this.NoGlassVisSharpRightNearCYL.Name = "NoGlassVisSharpRightNearCYL";
        this.NoGlassVisSharpRightNearCYL.TabIndex = 20;

        this.NoGlassVisSharpRightNearAxis = new TTVisual.TTTextBox();
        this.NoGlassVisSharpRightNearAxis.Name = "NoGlassVisSharpRightNearAxis";
        this.NoGlassVisSharpRightNearAxis.TabIndex = 18;

        this.NoGlassVisSharpLeftFarAxis = new TTVisual.TTTextBox();
        this.NoGlassVisSharpLeftFarAxis.Name = "NoGlassVisSharpLeftFarAxis";
        this.NoGlassVisSharpLeftFarAxis.TabIndex = 0;

        this.NoGlassVisSharpLeftFarCYL = new TTVisual.TTTextBox();
        this.NoGlassVisSharpLeftFarCYL.Name = "NoGlassVisSharpLeftFarCYL";
        this.NoGlassVisSharpLeftFarCYL.TabIndex = 2;

        this.NoGlassVisSharpLeftFarSPH = new TTVisual.TTTextBox();
        this.NoGlassVisSharpLeftFarSPH.Name = "NoGlassVisSharpLeftFarSPH";
        this.NoGlassVisSharpLeftFarSPH.TabIndex = 4;

        this.NoGlassVisSharpRightFarAxis = new TTVisual.TTTextBox();
        this.NoGlassVisSharpRightFarAxis.Name = "NoGlassVisSharpRightFarAxis";
        this.NoGlassVisSharpRightFarAxis.TabIndex = 12;

        this.NoGlassVisSharpRightFarCYL = new TTVisual.TTTextBox();
        this.NoGlassVisSharpRightFarCYL.Name = "NoGlassVisSharpRightFarCYL";
        this.NoGlassVisSharpRightFarCYL.TabIndex = 14;

        this.NoGlassVisSharpRightFarSPH = new TTVisual.TTTextBox();
        this.NoGlassVisSharpRightFarSPH.Name = "NoGlassVisSharpRightFarSPH";
        this.NoGlassVisSharpRightFarSPH.TabIndex = 16;

        this.GlassVisSharpLeftNearSPH = new TTVisual.TTTextBox();
        this.GlassVisSharpLeftNearSPH.Name = "GlassVisSharpLeftNearSPH";
        this.GlassVisSharpLeftNearSPH.TabIndex = 10;

        this.GlassVisSharpLeftNearCYL = new TTVisual.TTTextBox();
        this.GlassVisSharpLeftNearCYL.Name = "GlassVisSharpLeftNearCYL";
        this.GlassVisSharpLeftNearCYL.TabIndex = 8;

        this.GlassVisSharpLeftNearAxis = new TTVisual.TTTextBox();
        this.GlassVisSharpLeftNearAxis.Name = "GlassVisSharpLeftNearAxis";
        this.GlassVisSharpLeftNearAxis.TabIndex = 6;

        this.GlassVisSharpRightNearSPH = new TTVisual.TTTextBox();
        this.GlassVisSharpRightNearSPH.Name = "GlassVisSharpRightNearSPH";
        this.GlassVisSharpRightNearSPH.TabIndex = 22;

        this.GlassVisSharpRightNearCYL = new TTVisual.TTTextBox();
        this.GlassVisSharpRightNearCYL.Name = "GlassVisSharpRightNearCYL";
        this.GlassVisSharpRightNearCYL.TabIndex = 20;

        this.GlassVisSharpRightNearAxis = new TTVisual.TTTextBox();
        this.GlassVisSharpRightNearAxis.Name = "GlassVisSharpRightNearAxis";
        this.GlassVisSharpRightNearAxis.TabIndex = 18;

        this.GlassVisSharpLeftFarSPH = new TTVisual.TTTextBox();
        this.GlassVisSharpLeftFarSPH.Name = "GlassVisSharpLeftFarSPH";
        this.GlassVisSharpLeftFarSPH.TabIndex = 4;

        this.GlassVisSharpLeftFarCYL = new TTVisual.TTTextBox();
        this.GlassVisSharpLeftFarCYL.Name = "GlassVisSharpLeftFarCYL";
        this.GlassVisSharpLeftFarCYL.TabIndex = 2;

        this.GlassVisSharpLeftFarAxis = new TTVisual.TTTextBox();
        this.GlassVisSharpLeftFarAxis.Name = "GlassVisSharpLeftFarAxis";
        this.GlassVisSharpLeftFarAxis.TabIndex = 0;

        this.GlassVisSharpRightFarSPH = new TTVisual.TTTextBox();
        this.GlassVisSharpRightFarSPH.Name = "GlassVisSharpRightFarSPH";
        this.GlassVisSharpRightFarSPH.TabIndex = 16;

        this.GlassVisSharpRightFarCYL = new TTVisual.TTTextBox();
        this.GlassVisSharpRightFarCYL.Name = "GlassVisSharpRightFarCYL";
        this.GlassVisSharpRightFarCYL.TabIndex = 14;

        this.GlassVisSharpRightFarAxis = new TTVisual.TTTextBox();
        this.GlassVisSharpRightFarAxis.Name = "GlassVisSharpRightFarAxis";
        this.GlassVisSharpRightFarAxis.TabIndex = 12;


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        this.ttgroupbox1.Controls = [this.AutorefLeftEyeMeasureSPH, this.AutorefLeftEyeMeasureCYL, this.AutorefLeftEyeMeasureAxis, this.AutorefRightEyeMeasureSPH, this.AutorefRightEyeMeasureCYL, this.AutorefRightEyeMeasureAxis];
        this.ttgroupbox2.Controls = [this.CyclAutorefLeftEyeMeasureSPH, this.CyclAutorefLeftEyeMeasureCYL, this.CyclAutorefLeftEyeMeasureAxis, this.CyclAutorefRightEyeMeasureSPH, this.CyclAutorefRightEyeMeasureCYL, this.CyclAutorefRightEyeMeasureAxis];
        this.ttgroupbox3.Controls = [this.PatientGlassesLeftNearAxis, this.PatientGlassesLeftNearCYL, this.PatientGlassesLeftNearSPH, this.PatientGlassesRightNearSPH, this.PatientGlassesRightNearCYL, this.PatientGlassesRightNearAxis, this.PatientGlassesLeftFarAxis, this.PatientGlassesLeftFarCYL, this.PatientGlassesLeftFarSPH, this.PatientGlassesRightFarAxis, this.PatientGlassesRightFarCYL, this.PatientGlassesRightFarSPH];
        this.ttgroupbox4.Controls = [this.NoGlassVisSharpLeftNearAxis, this.NoGlassVisSharpLeftNearCYL, this.NoGlassVisSharpLeftNearSPH, this.NoGlassVisSharpLeftFarAxis, this.NoGlassVisSharpLeftFarCYL, this.NoGlassVisSharpLeftFarSPH, this.NoGlassVisSharpRightNearSPH, this.NoGlassVisSharpRightNearCYL, this.NoGlassVisSharpRightNearAxis, this.NoGlassVisSharpRightFarAxis, this.NoGlassVisSharpRightFarCYL, this.NoGlassVisSharpRightFarSPH];
        this.ttgroupbox5.Controls = [this.GlassVisSharpLeftNearSPH, this.GlassVisSharpLeftNearCYL, this.GlassVisSharpLeftNearAxis, this.GlassVisSharpRightNearSPH, this.GlassVisSharpRightNearCYL, this.GlassVisSharpRightNearAxis, this.GlassVisSharpLeftFarSPH, this.GlassVisSharpLeftFarCYL, this.GlassVisSharpLeftFarAxis, this.GlassVisSharpRightFarSPH, this.GlassVisSharpRightFarCYL, this.GlassVisSharpRightFarAxis];
        this.ttgroupbox6.Controls = [this.LeftEyeBiomicroscopy, this.RightEyeBiomicroscopy, this.LeftEyeBiomicroscopyTB, this.RightEyeBiomicroscopyTB];
        this.ttgroupbox7.Controls = [this.RightEyePressure, this.LeftEyePressure, ];
        this.ttgroupbox8.Controls = [this.LeftEyeMovements, this.RightEyeMovements, this.LeftEyeMovementsTB, this.RightEyeMovementsTB];
        this.ttgroupbox9.Controls = [this.LeftEyeFundus, this.RightEyeFundus, this.RightEyeFundusTB, this.LeftEyeFundusTB];
        this.Controls = [this.ttgroupbox1, this.ttgroupbox2, this.ttgroupbox3, this.ttgroupbox4, this.ttgroupbox5, this.ttgroupbox6, this.ttgroupbox7, this.ttgroupbox8, this.ttgroupbox9, this.AutorefLeftEyeMeasureSPH, this.AutorefLeftEyeMeasureCYL, this.AutorefLeftEyeMeasureAxis, this.AutorefRightEyeMeasureSPH, this.AutorefRightEyeMeasureCYL, this.AutorefRightEyeMeasureAxis, this.CyclAutorefLeftEyeMeasureSPH, this.CyclAutorefLeftEyeMeasureCYL, this.CyclAutorefLeftEyeMeasureAxis, this.CyclAutorefRightEyeMeasureSPH, this.CyclAutorefRightEyeMeasureCYL, this.CyclAutorefRightEyeMeasureAxis, this.PatientGlassesLeftNearAxis, this.PatientGlassesLeftNearCYL, this.PatientGlassesLeftNearSPH, this.PatientGlassesRightNearSPH, this.PatientGlassesRightNearCYL, this.PatientGlassesRightNearAxis, this.PatientGlassesLeftFarAxis, this.PatientGlassesLeftFarCYL, this.PatientGlassesLeftFarSPH, this.PatientGlassesRightFarAxis, this.PatientGlassesRightFarCYL, this.PatientGlassesRightFarSPH, this.NoGlassVisSharpLeftNearAxis, this.NoGlassVisSharpLeftNearCYL, this.NoGlassVisSharpLeftNearSPH, this.NoGlassVisSharpLeftFarAxis, this.NoGlassVisSharpLeftFarCYL, this.NoGlassVisSharpLeftFarSPH, this.NoGlassVisSharpRightNearSPH, this.NoGlassVisSharpRightNearCYL, this.NoGlassVisSharpRightNearAxis, this.NoGlassVisSharpRightFarAxis, this.NoGlassVisSharpRightFarCYL, this.NoGlassVisSharpRightFarSPH, this.GlassVisSharpLeftNearSPH, this.GlassVisSharpLeftNearCYL, this.GlassVisSharpLeftNearAxis, this.GlassVisSharpRightNearSPH, this.GlassVisSharpRightNearCYL, this.GlassVisSharpRightNearAxis, this.GlassVisSharpLeftFarSPH, this.GlassVisSharpLeftFarCYL, this.GlassVisSharpLeftFarAxis, this.GlassVisSharpRightFarSPH, this.GlassVisSharpRightFarCYL, this.GlassVisSharpRightFarAxis, this.LeftEyeBiomicroscopy, this.RightEyeBiomicroscopy, this.RightEyePressure, this.LeftEyePressure, this.LeftEyeMovements, this.RightEyeMovements, this.LeftEyeFundus, this.RightEyeFundus
            , this.LeftEyeBiomicroscopyTB, this.RightEyeBiomicroscopyTB, this.LeftEyeMovementsTB, this.RightEyeMovementsTB, this.RightEyeFundusTB, this.LeftEyeFundusTB, this.VisualSharpnessNoGlassLeftValue, this.VisualSharpnessNoGlassRightValue, this.VisualSharpnessGlassLeftValue, this.VisualSharpnessGlassRightValue];

    }


}