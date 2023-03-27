//$D0FF181B
import { Component, OnInit, NgZone  } from '@angular/core';
import { EkokardiografiFormViewModel } from './EkokardiografiFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EkokardiografiFormObject } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationFormBaseObjectForm } from "Modules/Tibbi_Surec/Manipulasyon_Modulu/ManipulationFormBaseObjectForm";
import { AortKapakBulgu } from 'NebulaClient/Model/AtlasClientModel';
import { EkokardiografiBulgu } from 'NebulaClient/Model/AtlasClientModel';
import { MitralKapakBulgu } from 'NebulaClient/Model/AtlasClientModel';
import { PulmonerKapakBulgu } from 'NebulaClient/Model/AtlasClientModel';
import { TrikuspitKapakBulgu } from 'NebulaClient/Model/AtlasClientModel';
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';
import { AortKapakEnum, EkokardiografiEnum, MitralKapakEnum, PulmonerKapakEnum, TrikuspitKapakEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ModalStateService, ModalInfo, IModal } from "Fw/Models/ModalInfo";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';

@Component({
    selector: 'EkokardiografiForm',
    templateUrl: './EkokardiografiForm.html',
    providers: [MessageService]
})
export class EkokardiografiForm extends ManipulationFormBaseObjectForm implements OnInit, IModal {
    //AortKapakBulgular: TTVisual.ITTGrid;
    //AortKapakTestAortKapakBulgu: TTVisual.ITTEnumComboBoxColumn;
    //AortKapakTestBulguAortKapakBulgu: TTVisual.ITTTextBoxColumn;
    //EkokardiografiBulgular: TTVisual.ITTGrid;
    //EkokardiografiTestBulguEkokardiografiBulgu: TTVisual.ITTTextBoxColumn;
    //EkokardiografiTestEkokardiografiBulgu: TTVisual.ITTEnumComboBoxColumn;
    EkoSonuc: TTVisual.ITTRichTextBoxControl;
    KalpHizi: TTVisual.ITTTextBox;
    labelEkoSonuc: TTVisual.ITTLabel;
    labelKalpHizi: TTVisual.ITTLabel;
    labelLVSegmentHareket: TTVisual.ITTLabel;
    labelPerikartOzellik: TTVisual.ITTLabel;
    labelRitim: TTVisual.ITTLabel;
    LVSegmentHareket: TTVisual.ITTRichTextBoxControl;
    //MitralKapakBulgular: TTVisual.ITTGrid;
    //MitralKapakTestBulguMitralKapakBulgu: TTVisual.ITTTextBoxColumn;
    //MitralKapakTestMitralKapakBulgu: TTVisual.ITTEnumComboBoxColumn;
    PerikartOzellik: TTVisual.ITTRichTextBoxControl;
    //PulmonerKapakBulgular: TTVisual.ITTGrid;
    //PulmonerKapakTestBulguPulmonerKapakBulgu: TTVisual.ITTTextBoxColumn;
    //PulmonerKapakTestPulmonerKapakBulgu: TTVisual.ITTEnumComboBoxColumn;
    Ritim: TTVisual.ITTTextBox;
    Boy: TTVisual.ITTTextBox;
    Kilo: TTVisual.ITTTextBox;
    //TrikuspitKapakBulgular: TTVisual.ITTGrid;
    //TrikuspitKapakTestBulguTrikuspitKapakBulgu: TTVisual.ITTTextBoxColumn;
    //TrikuspitKapakTestTrikuspitKapakBulgu: TTVisual.ITTEnumComboBoxColumn;
    selectedRows: number[];
    _showResult: boolean = false;



    public ekokardiografiFormViewModel: EkokardiografiFormViewModel = new EkokardiografiFormViewModel();
    public get _EkokardiografiFormObject(): EkokardiografiFormObject {
        return this._TTObject as EkokardiografiFormObject;
    }
    private EkokardiografiForm_DocumentUrl: string = '/api/EkokardiografiFormObjectService/EkokardiografiForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone, private sideBarMenuService: ISidebarMenuService, protected modalService: IModalService) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.EkokardiografiForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    setInputParam(value: any) { //Manipulation.CurrentStateDefID

        //if (value.toString() == Manipulation.ManipulationStates.DoctorProcedure.toString())
            this._showResult = true;
       
    }

    protected async PreScript()  {
        super.PreScript();
        this.AddHelpMenu();
    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let ekoFormu = new DynamicSidebarMenuItem();
        ekoFormu.key = 'ekoFormu';
        ekoFormu.icon = 'far fa-file-alt';
        ekoFormu.label = "Ekokardiyografi Formu";
        ekoFormu.componentInstance = this;
        ekoFormu.clickFunction = this.openEkokardiografiForm;
        ekoFormu.parameterFunctionInstance = this;
        //ekoFormu.getParamsFunction = this.getParamsFunctionForRadiology;
        ekoFormu.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', ekoFormu);

    }
    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('ekoFormu');
    
    }
    public openEkokardiografiForm() {
        let reportData: DynamicReportParameters = {

            Code: 'EKOKARDIOGRAFIFORMU',
            ReportParams: { ObjectID: this._EkokardiografiFormObject.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "EKOKARDİOGRAFİ FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    protected _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    // ***** Method declarations start *****
    public AortKapakBulgularColumns = [
        {
            caption: "Aort Kapak",
            dataField: 'AortKapakTest',
            lookup: { dataSource: AortKapakEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "Bulgu",
            dataField: 'AortKapakTestBulgu',
            allowEditing: true,
            width: 'auto'
        }];
        public EkokardiografiBulgularColumns = [
        {
            caption: "Ekokardiografi",
            dataField: 'EkokardiografiTest',
            lookup: { dataSource: EkokardiografiEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "Bulgu",
            dataField: 'EkokardiografiTestBulgu',
            allowEditing: true,
            width: 'auto'
        }];

    public MitralKapakBulgularColumns = [
        {
            caption: "Mitral Kapak",
            dataField: 'MitralKapakTest',
            lookup: { dataSource: MitralKapakEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "Bulgu",
            dataField: 'MitralKapakTestBulgu',
            allowEditing: true,
            width: 'auto'
        }];


    public PulmonerKapakBulgularColumns = [
        {
            caption: "Pulmoner Kapak",
            dataField: 'PulmonerKapakTest',
            lookup: { dataSource: PulmonerKapakEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "Bulgu",
            dataField: 'PulmonerKapakTestBulgu',
            allowEditing: true,
            width: 'auto'
        }];

    public TrikuspitKapakBulgularColumns = [
        {
            caption: "Triküspit Kapak",
            dataField: 'TrikuspitKapakTest',
            lookup: { dataSource: TrikuspitKapakEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: "Bulgu",
            dataField: 'TrikuspitKapakTestBulgu',
            allowEditing: true,
            width: 'auto'
        }];

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EkokardiografiFormObject();
        this.ekokardiografiFormViewModel = new EkokardiografiFormViewModel();
        this._ViewModel = this.ekokardiografiFormViewModel;
        this.ekokardiografiFormViewModel._EkokardiografiFormObject = this._TTObject as EkokardiografiFormObject;
        this.ekokardiografiFormViewModel._EkokardiografiFormObject.EkokardiografiBulgular = new Array<EkokardiografiBulgu>();
        this.ekokardiografiFormViewModel._EkokardiografiFormObject.PulmonerKapakBulgular = new Array<PulmonerKapakBulgu>();
        this.ekokardiografiFormViewModel._EkokardiografiFormObject.TrikuspitKapakBulgular = new Array<TrikuspitKapakBulgu>();
        this.ekokardiografiFormViewModel._EkokardiografiFormObject.AortKapakBulgular = new Array<AortKapakBulgu>();
        this.ekokardiografiFormViewModel._EkokardiografiFormObject.MitralKapakBulgular = new Array<MitralKapakBulgu>();
    }

    protected loadViewModel() {
        let that = this;
        that.ekokardiografiFormViewModel = this._ViewModel as EkokardiografiFormViewModel;
        that._TTObject = this.ekokardiografiFormViewModel._EkokardiografiFormObject;
        if (this.ekokardiografiFormViewModel == null)
            this.ekokardiografiFormViewModel = new EkokardiografiFormViewModel();
        if (this.ekokardiografiFormViewModel._EkokardiografiFormObject == null)
            this.ekokardiografiFormViewModel._EkokardiografiFormObject = new EkokardiografiFormObject();
        that.ekokardiografiFormViewModel._EkokardiografiFormObject.EkokardiografiBulgular = that.ekokardiografiFormViewModel.EkokardiografiBulgularGridList;
        for (let detailItem of that.ekokardiografiFormViewModel.EkokardiografiBulgularGridList) {
        }
        that.ekokardiografiFormViewModel._EkokardiografiFormObject.PulmonerKapakBulgular = that.ekokardiografiFormViewModel.PulmonerKapakBulgularGridList;
        for (let detailItem of that.ekokardiografiFormViewModel.PulmonerKapakBulgularGridList) {
        }
        that.ekokardiografiFormViewModel._EkokardiografiFormObject.TrikuspitKapakBulgular = that.ekokardiografiFormViewModel.TrikuspitKapakBulgularGridList;
        for (let detailItem of that.ekokardiografiFormViewModel.TrikuspitKapakBulgularGridList) {
        }
        that.ekokardiografiFormViewModel._EkokardiografiFormObject.AortKapakBulgular = that.ekokardiografiFormViewModel.AortKapakBulgularGridList;
        for (let detailItem of that.ekokardiografiFormViewModel.AortKapakBulgularGridList) {
        }
        that.ekokardiografiFormViewModel._EkokardiografiFormObject.MitralKapakBulgular = that.ekokardiografiFormViewModel.MitralKapakBulgularGridList;
        for (let detailItem of that.ekokardiografiFormViewModel.MitralKapakBulgularGridList) {
        }

    }

    async ngOnInit() {
        //await this.load();
        let that = this;
        await this.load(EkokardiografiFormViewModel);
  
    }

    public onRowPrepared(e){
        //if ( e.rowElement.firstItem() != undefined && e.rowType == 'data' && e.data != undefined )
        //{
        //    if (e.data.Status == StockActionDetailStatusEnum._Cancelled.ordinal) {
        //        this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "red");
        //    }
        //    else
        //    {
        //        this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "#fff");
        //    }
        //}
    }

   // @ViewChild('aortKapakBulgularGrid') aortKapakBulgularGrid: DxDataGridComponent;
    onRowClickAort(event: any): void {
        //if (event.parentType == 'dataRow') {
        //    event.editorOptions.onValueChanged = function (args) {
        //        if (event.component.hasEditData()) {
        //            event.component.saveEditData();
        //        }
        //    }
        //}
    }

    public onEkoSonucChanged(event): void {
        if (this._EkokardiografiFormObject != null && this._EkokardiografiFormObject.EkoSonuc != event) {
            this._EkokardiografiFormObject.EkoSonuc = event;
        }
    }

    public onKalpHiziChanged(event): void {
        if (this._EkokardiografiFormObject != null && this._EkokardiografiFormObject.KalpHizi != event) {
            this._EkokardiografiFormObject.KalpHizi = event;
        }
    }

    public onLVSegmentHareketChanged(event): void {
        if (this._EkokardiografiFormObject != null && this._EkokardiografiFormObject.LVSegmentHareket != event) {
            this._EkokardiografiFormObject.LVSegmentHareket = event;
        }
    }

    public onPerikartOzellikChanged(event): void {
        if (this._EkokardiografiFormObject != null && this._EkokardiografiFormObject.PerikartOzellik != event) {
            this._EkokardiografiFormObject.PerikartOzellik = event;
        }
    }

    public onRitimChanged(event): void {
        if (this._EkokardiografiFormObject != null && this._EkokardiografiFormObject.Ritim != event) {
            this._EkokardiografiFormObject.Ritim = event;
        }
    }
    public onBoyChanged(event): void {
        if (this._EkokardiografiFormObject != null && this._EkokardiografiFormObject.Boy != event) {
            this._EkokardiografiFormObject.Boy = event;
        }
    }

    public onKiloChanged(event): void {
        if (this._EkokardiografiFormObject != null && this._EkokardiografiFormObject.Kilo != event) {
            this._EkokardiografiFormObject.Kilo = event;
        }
    }


    public selectionChangedHandler(event): void { }

    protected redirectProperties(): void {
        redirectProperty(this.KalpHizi, "Text", this.__ttObject, "KalpHizi");
        redirectProperty(this.Ritim, "Text", this.__ttObject, "Ritim");
        redirectProperty(this.Boy, "Text", this.__ttObject, "Boy");
        redirectProperty(this.Kilo, "Text", this.__ttObject, "Kilo");
        redirectProperty(this.LVSegmentHareket, "Rtf", this.__ttObject, "LVSegmentHareket");
        redirectProperty(this.PerikartOzellik, "Rtf", this.__ttObject, "PerikartOzellik");
        redirectProperty(this.EkoSonuc, "Rtf", this.__ttObject, "EkoSonuc");
    }

    public initFormControls(): void {
        //this.EkokardiografiBulgular = new TTVisual.TTGrid();
        //this.EkokardiografiBulgular.Name = "EkokardiografiBulgular";
        //this.EkokardiografiBulgular.TabIndex = 14;

        //this.EkokardiografiTestEkokardiografiBulgu = new TTVisual.TTEnumComboBoxColumn();
        //this.EkokardiografiTestEkokardiografiBulgu.DataMember = "EkokardiografiTest";
        //this.EkokardiografiTestEkokardiografiBulgu.DisplayIndex = 0;
        //this.EkokardiografiTestEkokardiografiBulgu.HeaderText = "Ekokardiografi";
        //this.EkokardiografiTestEkokardiografiBulgu.Name = "EkokardiografiTestEkokardiografiBulgu";
        //this.EkokardiografiTestEkokardiografiBulgu.Width = 150;

        //this.EkokardiografiTestBulguEkokardiografiBulgu = new TTVisual.TTTextBoxColumn();
        //this.EkokardiografiTestBulguEkokardiografiBulgu.DataMember = "EkokardiografiTestBulgu";
        //this.EkokardiografiTestBulguEkokardiografiBulgu.DisplayIndex = 1;
        //this.EkokardiografiTestBulguEkokardiografiBulgu.HeaderText = "Bulgu";
        //this.EkokardiografiTestBulguEkokardiografiBulgu.Name = "EkokardiografiTestBulguEkokardiografiBulgu";
        //this.EkokardiografiTestBulguEkokardiografiBulgu.Width = 80;

        //this.PulmonerKapakBulgular = new TTVisual.TTGrid();
        //this.PulmonerKapakBulgular.Name = "PulmonerKapakBulgular";
        //this.PulmonerKapakBulgular.TabIndex = 13;

        //this.PulmonerKapakTestPulmonerKapakBulgu = new TTVisual.TTEnumComboBoxColumn();
        //this.PulmonerKapakTestPulmonerKapakBulgu.DataMember = "PulmonerKapakTest";
        //this.PulmonerKapakTestPulmonerKapakBulgu.DisplayIndex = 0;
        //this.PulmonerKapakTestPulmonerKapakBulgu.HeaderText = "Pulmoner Kapak";
        //this.PulmonerKapakTestPulmonerKapakBulgu.Name = "PulmonerKapakTestPulmonerKapakBulgu";
        //this.PulmonerKapakTestPulmonerKapakBulgu.Width = 150;

        //this.PulmonerKapakTestBulguPulmonerKapakBulgu = new TTVisual.TTTextBoxColumn();
        //this.PulmonerKapakTestBulguPulmonerKapakBulgu.DataMember = "PulmonerKapakTestBulgu";
        //this.PulmonerKapakTestBulguPulmonerKapakBulgu.DisplayIndex = 1;
        //this.PulmonerKapakTestBulguPulmonerKapakBulgu.HeaderText = "Bulgu";
        //this.PulmonerKapakTestBulguPulmonerKapakBulgu.Name = "PulmonerKapakTestBulguPulmonerKapakBulgu";
        //this.PulmonerKapakTestBulguPulmonerKapakBulgu.Width = 80;

        //this.TrikuspitKapakBulgular = new TTVisual.TTGrid();
        //this.TrikuspitKapakBulgular.Name = "TrikuspitKapakBulgular";
        //this.TrikuspitKapakBulgular.TabIndex = 12;

        //this.TrikuspitKapakTestTrikuspitKapakBulgu = new TTVisual.TTEnumComboBoxColumn();
        //this.TrikuspitKapakTestTrikuspitKapakBulgu.DataMember = "TrikuspitKapakTest";
        //this.TrikuspitKapakTestTrikuspitKapakBulgu.DisplayIndex = 0;
        //this.TrikuspitKapakTestTrikuspitKapakBulgu.HeaderText = "Triküspit Kapak";
        //this.TrikuspitKapakTestTrikuspitKapakBulgu.Name = "TrikuspitKapakTestTrikuspitKapakBulgu";
        //this.TrikuspitKapakTestTrikuspitKapakBulgu.Width = 150;

        //this.TrikuspitKapakTestBulguTrikuspitKapakBulgu = new TTVisual.TTTextBoxColumn();
        //this.TrikuspitKapakTestBulguTrikuspitKapakBulgu.DataMember = "TrikuspitKapakTestBulgu";
        //this.TrikuspitKapakTestBulguTrikuspitKapakBulgu.DisplayIndex = 1;
        //this.TrikuspitKapakTestBulguTrikuspitKapakBulgu.HeaderText = "Bulgu";
        //this.TrikuspitKapakTestBulguTrikuspitKapakBulgu.Name = "TrikuspitKapakTestBulguTrikuspitKapakBulgu";
        //this.TrikuspitKapakTestBulguTrikuspitKapakBulgu.Width = 80;

        //this.AortKapakBulgular = new TTVisual.TTGrid();
        //this.AortKapakBulgular.Name = "AortKapakBulgular";
        //this.AortKapakBulgular.TabIndex = 11;

        //this.AortKapakTestAortKapakBulgu = new TTVisual.TTEnumComboBoxColumn();
        //this.AortKapakTestAortKapakBulgu.DataMember = "AortKapakTest";
        //this.AortKapakTestAortKapakBulgu.DisplayIndex = 0;
        //this.AortKapakTestAortKapakBulgu.HeaderText = "Aort Kapak";
        //this.AortKapakTestAortKapakBulgu.Name = "AortKapakTestAortKapakBulgu";
        //this.AortKapakTestAortKapakBulgu.Width = 150;

        //this.AortKapakTestBulguAortKapakBulgu = new TTVisual.TTTextBoxColumn();
        //this.AortKapakTestBulguAortKapakBulgu.DataMember = "AortKapakTestBulgu";
        //this.AortKapakTestBulguAortKapakBulgu.DisplayIndex = 1;
        //this.AortKapakTestBulguAortKapakBulgu.HeaderText = "Bulgu";
        //this.AortKapakTestBulguAortKapakBulgu.Name = "AortKapakTestBulguAortKapakBulgu";
        //this.AortKapakTestBulguAortKapakBulgu.Width = 80;

        //this.MitralKapakBulgular = new TTVisual.TTGrid();
        //this.MitralKapakBulgular.Name = "MitralKapakBulgular";
        //this.MitralKapakBulgular.TabIndex = 10;

        //this.MitralKapakTestMitralKapakBulgu = new TTVisual.TTEnumComboBoxColumn();
        //this.MitralKapakTestMitralKapakBulgu.DataMember = "MitralKapakTest";
        //this.MitralKapakTestMitralKapakBulgu.DisplayIndex = 0;
        //this.MitralKapakTestMitralKapakBulgu.HeaderText = "Mitral Kapak";
        //this.MitralKapakTestMitralKapakBulgu.Name = "MitralKapakTestMitralKapakBulgu";
        //this.MitralKapakTestMitralKapakBulgu.Width = 150;

        //this.MitralKapakTestBulguMitralKapakBulgu = new TTVisual.TTTextBoxColumn();
        //this.MitralKapakTestBulguMitralKapakBulgu.DataMember = "MitralKapakTestBulgu";
        //this.MitralKapakTestBulguMitralKapakBulgu.DisplayIndex = 1;
        //this.MitralKapakTestBulguMitralKapakBulgu.HeaderText = "Bulgu";
        //this.MitralKapakTestBulguMitralKapakBulgu.Name = "MitralKapakTestBulguMitralKapakBulgu";
        //this.MitralKapakTestBulguMitralKapakBulgu.Width = 80;

        this.labelEkoSonuc = new TTVisual.TTLabel();
        this.labelEkoSonuc.Text = "Ekokardiografi Sonucu";
        this.labelEkoSonuc.Name = "labelEkoSonuc";
        this.labelEkoSonuc.TabIndex = 9;

        this.EkoSonuc = new TTVisual.TTRichTextBoxControl();
        this.EkoSonuc.Name = "EkoSonuc";
        this.EkoSonuc.TabIndex = 8;

        this.labelPerikartOzellik = new TTVisual.TTLabel();
        this.labelPerikartOzellik.Text = "Perikart Özellikleri";
        this.labelPerikartOzellik.Name = "labelPerikartOzellik";
        this.labelPerikartOzellik.TabIndex = 7;

        this.PerikartOzellik = new TTVisual.TTRichTextBoxControl();
        this.PerikartOzellik.Name = "PerikartOzellik";
        this.PerikartOzellik.TabIndex = 6;

        this.labelLVSegmentHareket = new TTVisual.TTLabel();
        this.labelLVSegmentHareket.Text = "LV Segment Hareketleri";
        this.labelLVSegmentHareket.Name = "labelLVSegmentHareket";
        this.labelLVSegmentHareket.TabIndex = 5;

        this.LVSegmentHareket = new TTVisual.TTRichTextBoxControl();
        this.LVSegmentHareket.Name = "LVSegmentHareket";
        this.LVSegmentHareket.TabIndex = 4;

        this.labelRitim = new TTVisual.TTLabel();
        this.labelRitim.Text = "Ritim";
        this.labelRitim.Name = "labelRitim";
        this.labelRitim.TabIndex = 3;

        this.Ritim = new TTVisual.TTTextBox();
        this.Ritim.Name = "Ritim";
        this.Ritim.TabIndex = 2;

        this.Boy = new TTVisual.TTTextBox();
        this.Boy.Name = "Boy";
        this.Boy.TabIndex = 2;

        this.Kilo = new TTVisual.TTTextBox();
        this.Kilo.Name = "Kilo";
        this.Kilo.TabIndex = 2;

        this.KalpHizi = new TTVisual.TTTextBox();
        this.KalpHizi.Name = "KalpHizi";
        this.KalpHizi.TabIndex = 0;

        this.labelKalpHizi = new TTVisual.TTLabel();
        this.labelKalpHizi.Text = "Kalp Hızı";
        this.labelKalpHizi.Name = "labelKalpHizi";
        this.labelKalpHizi.TabIndex = 1;

        //this.EkokardiografiBulgularColumns = [this.EkokardiografiTestEkokardiografiBulgu, this.EkokardiografiTestBulguEkokardiografiBulgu];
        //this.PulmonerKapakBulgularColumns = [this.PulmonerKapakTestPulmonerKapakBulgu, this.PulmonerKapakTestBulguPulmonerKapakBulgu];
        //this.TrikuspitKapakBulgularColumns = [this.TrikuspitKapakTestTrikuspitKapakBulgu, this.TrikuspitKapakTestBulguTrikuspitKapakBulgu];
        //this.AortKapakBulgularColumns = [this.AortKapakTestAortKapakBulgu, this.AortKapakTestBulguAortKapakBulgu];
        //this.MitralKapakBulgularColumns = [this.MitralKapakTestMitralKapakBulgu, this.MitralKapakTestBulguMitralKapakBulgu];
        //this.Controls = [this.EkokardiografiBulgular, this.EkokardiografiTestEkokardiografiBulgu, this.EkokardiografiTestBulguEkokardiografiBulgu, this.PulmonerKapakBulgular, this.PulmonerKapakTestPulmonerKapakBulgu, this.PulmonerKapakTestBulguPulmonerKapakBulgu, this.TrikuspitKapakBulgular, this.TrikuspitKapakTestTrikuspitKapakBulgu, this.TrikuspitKapakTestBulguTrikuspitKapakBulgu, this.AortKapakBulgular, this.AortKapakTestAortKapakBulgu, this.AortKapakTestBulguAortKapakBulgu, this.MitralKapakBulgular, this.MitralKapakTestMitralKapakBulgu, this.MitralKapakTestBulguMitralKapakBulgu, this.labelEkoSonuc, this.EkoSonuc, this.labelPerikartOzellik, this.PerikartOzellik, this.labelLVSegmentHareket, this.LVSegmentHareket, this.labelRitim, this.Ritim, this.KalpHizi, this.labelKalpHizi];
        this.Controls = [this.labelEkoSonuc, this.EkoSonuc, this.labelPerikartOzellik, this.PerikartOzellik, this.labelLVSegmentHareket, this.LVSegmentHareket, this.labelRitim, this.Ritim, this.Boy,this.Kilo, this.KalpHizi, this.labelKalpHizi];

    }


}
