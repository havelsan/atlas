//$1CF7727D
import { Component, OnInit, NgZone } from '@angular/core';
import { LaboratoryRequestResultFormViewModel } from "./LaboratoryRequestResultFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTReportTool from "NebulaClient/Visual/ReportTool/TTReport";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Dictionary } from "NebulaClient/System/Collections/Dictionaries/Dictionary";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { HighLowEnum } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratorySubProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from "NebulaClient/Utils/Enums/MessageIconEnum";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";

@Component({
    selector: 'LaboratoryRequestResultForm',
    templateUrl: './LaboratoryRequestResultForm.html',
    providers: [MessageService]
})
export class LaboratoryRequestResultForm extends EpisodeActionForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    Detail: TTVisual.ITTButtonColumn;
    Gebelik: TTVisual.ITTEnumComboBox;
    GridLabProcedures: TTVisual.ITTGrid;
    labelBarcode: TTVisual.ITTLabel;
    labelGebelik: TTVisual.ITTLabel;
    labelPreInformation: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    labelSonAdetTarihi: TTVisual.ITTLabel;
    LabProcedure: TTVisual.ITTTextBoxColumn;
    LongReport: TTVisual.ITTRichTextBoxControlColumn;
    lstApprovedBy: TTVisual.ITTObjectListBox;
    PatientAge: TTVisual.ITTTextBox;
    PatientGroup: TTVisual.ITTEnumComboBox;
    PatientSex: TTVisual.ITTEnumComboBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ReasonForAdmisson: TTVisual.ITTTextBox;
    Reference: TTVisual.ITTTextBoxColumn;
    requestDoctor: TTVisual.ITTObjectListBox;
    Result: TTVisual.ITTTextBoxColumn;
    ResultNote: TTVisual.ITTTextBoxColumn;
    SonAdetTarihi: TTVisual.ITTDateTimePicker;
    SpecialReference: TTVisual.ITTRichTextBoxControlColumn;
    TabControlLabProcedures: TTVisual.ITTTabControl;
    TabForInformations: TTVisual.ITTTabControl;
    TabPageFutureRequest: TTVisual.ITTTabPage;
    TabPageLabProcedures: TTVisual.ITTTabPage;
    tabResults: TTVisual.ITTTabControl;
    textBarcode: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel3drawgradient: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttobjectlistbox2: TTVisual.ITTObjectListBox;
    ttobjectlistbox3: TTVisual.ITTObjectListBox;
    ttPrintResultReport: TTVisual.ITTButton;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    Unit: TTVisual.ITTTextBoxColumn;
    Urgent: TTVisual.ITTCheckBox;
    Warning: TTVisual.ITTEnumComboBoxColumn;
    WorkListDate: TTVisual.ITTDateTimePicker;
    public GridLabProceduresColumns = [];
    public laboratoryRequestResultFormViewModel: LaboratoryRequestResultFormViewModel = new LaboratoryRequestResultFormViewModel();
    public get _LaboratoryRequest(): LaboratoryRequest {
        return this._TTObject as LaboratoryRequest;
    }
    private LaboratoryRequestResultForm_DocumentUrl: string = '/api/LaboratoryRequestService/LaboratoryRequestResultForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.LaboratoryRequestResultForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

   /*private async FillLabProcedure(labProcedure: LaboratoryProcedure, listView: TTVisual.ITTListView): Promise<void> {
        let hasWarning: boolean = false;
        if ((labProcedure.Warning !== undefined) && labProcedure.Warning.Value !== HighLowEnum.Normal)
            hasWarning = true;
       /*let item: TTListViewItem = new TTListViewItem();
        if (labProcedure.LongReport !== null) {
            if ((await CommonService.GetTextOfRTFString(labProcedure.LongReport.toString())).trim() !== "\"\"") {
                item.Text = "> Aç <";
                item.Tag = labProcedure.ObjectID.toString();
                //item.Font = new Font("Tahoma", 8);
                item.BackColor = Color.DeepSkyBlue;
            }
        }
        let labTestDef: LaboratoryTestDefinition = labProcedure.ProcedureObject as LaboratoryTestDefinition;
        if (labTestDef !== null && labTestDef.IsPanel === true) {
            item.BackColor = Color.FromArgb(240, 247, 255);
        }
        if (hasWarning) {
            if (labProcedure.Warning.Value === HighLowEnum.High) {
                item.ForeColor = Color.OrangeRed;
            }
            if (labProcedure.Warning.Value === HighLowEnum.Low) {
                item.ForeColor = Color.DodgerBlue;
            }
            if (labProcedure.Warning.Value === HighLowEnum.Panic) {
                //item.Font = new Font("Tahoma", 8, FontStyle.Bold);
                item.ForeColor = Color.Red;
            }
        }
        if (labProcedure.Panic !== null) {
            if (labProcedure.Panic.Value === HighLowEnum.High || labProcedure.Panic.Value === HighLowEnum.Low) {
                //item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                item.ForeColor = Color.FloralWhite;
                item.BackColor = Color.Crimson;
            }
        }
        if (labProcedure.MicrobiologyPanicNotification !== null) {
            if (labProcedure.MicrobiologyPanicNotification === true) {
                //item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                item.ForeColor = Color.FloralWhite;
                item.BackColor = Color.Crimson;
            }
        }
        let subitemName: TTListViewSubItem = new TTListViewSubItem(); //Adı
        subitemName.Text = labProcedure.ProcedureObject.Name;
        item.SubItems.push(subitemName);
        let subitemStar: TTListViewSubItem = new TTListViewSubItem(); //Flag
        if (hasWarning) {
            if (labProcedure.Warning.Value === HighLowEnum.High) {
                subitemStar.Text = "*";
            }
            if (labProcedure.Warning.Value === HighLowEnum.Low) {
                subitemStar.Text = "*";
            }
            if (labProcedure.Warning.Value === HighLowEnum.Panic) {
                subitemStar.Text = "!";
            }
        }
        item.SubItems.push(subitemStar);
        let subitem: TTListViewSubItem = new TTListViewSubItem(); //Sonuç
        subitem.Text = labProcedure.Result;
        item.SubItems.push(subitem);
        let subitem2: TTListViewSubItem = new TTListViewSubItem(); //Sapma
        subitem2.Text = (labProcedure.Warning !== undefined) === true ? (await CommonService.GetDisplayTextOfDataTypeEnum(labProcedure.Warning.Value)) : "";
        item.SubItems.push(subitem2);
        let subitem3: TTListViewSubItem = new TTListViewSubItem(); //Referans
        subitem3.Text = labProcedure.Reference;
        item.SubItems.push(subitem3);
        let subitem4: TTListViewSubItem = new TTListViewSubItem(); //Özel Değerler
        subitem4.Text = labProcedure.SpecialReference !== null ? (await CommonService.GetTextOfRTFString(labProcedure.SpecialReference.toString())) : "";
        item.SubItems.push(subitem4);
        let subitem5: TTListViewSubItem = new TTListViewSubItem(); //Birim
        subitem5.Text = labProcedure.Unit;
        item.SubItems.push(subitem5);
        let subitem6: TTListViewSubItem = new TTListViewSubItem(); //Açıklama
        subitem6.Text = labProcedure.ResultDescription;
        item.SubItems.push(subitem6);
        let subitem7: TTListViewSubItem = new TTListViewSubItem(); //Panik
        if (labProcedure.Panic !== null) {
            if (labProcedure.Panic.Value === HighLowEnum.High) {
                subitem7.Text = "Çok Yüksek Değer";
            }
            if (labProcedure.Panic.Value === HighLowEnum.Low) {
                subitem7.Text = "Çok Düşük Değer";
            }
            if (labProcedure.Panic.Value === HighLowEnum.None) {
                subitem7.Text = "Bildirim Yok";
            }
        }
        if (labProcedure.MicrobiologyPanicNotification !== null) {
            if (labProcedure.MicrobiologyPanicNotification === true) {
                subitem7.Text = "Mikrobiyoloji Panik Sonuç Bildirimi!";
            }
        }
        item.SubItems.push(subitem7);
        let subitem8: TTListViewSubItem = new TTListViewSubItem(); //Numune Red Sebebi
        if (labProcedure.CurrentStateDefID === LaboratoryProcedure.LaboratoryProcedureStates.SampleReject) {
            if (labProcedure.SampleRejectionReason !== null) {
                subitem8.Text = labProcedure.SampleRejectionReason.Reason.trim();
                item.BackColor = Color.DimGray;
                item.ForeColor = Color.White;
                subitem.Text = "Laboratuvar Red";
            }
            else {
                subitem8.Text = string.Empty;
            }
        }
        item.SubItems.push(subitem8);
        listView.Items.push(item);

    }*/
    private async FillLabProcedure(labProcedure: LaboratorySubProcedure, listView: TTVisual.ITTListView): Promise<void> {
        let hasWarning: boolean = false;
        if ((labProcedure.Warning !== undefined) && labProcedure.Warning.Value !== HighLowEnum.Normal)
            hasWarning = true;
       /* let item: TTListViewItem = new TTListViewItem();
        item.BackColor = Color.FromArgb(244, 250, 255);
        if (labProcedure.LongReport !== null) {
            if ((await CommonService.GetTextOfRTFString(labProcedure.LongReport.toString())).trim() !== "\"\"") {
                item.Text = "> Aç <";
                item.Tag = labProcedure.ObjectID.toString();
                //item.Font = new Font("Tahoma", 8);
                item.BackColor = Color.DeepSkyBlue;
            }
        }
        if (hasWarning) {
            if (labProcedure.Warning.Value === HighLowEnum.High) {
                item.ForeColor = Color.OrangeRed;
            }
            if (labProcedure.Warning.Value === HighLowEnum.Low) {
                item.ForeColor = Color.RoyalBlue;
            }
            if (labProcedure.Warning.Value === HighLowEnum.Panic) {
                //item.Font = new Font("Tahoma", 8, FontStyle.Bold);
                item.ForeColor = Color.Red;
            }
        }
        if (labProcedure.Panic !== null) {
            if (labProcedure.Panic.Value === HighLowEnum.High || labProcedure.Panic.Value === HighLowEnum.Low) {
                //item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                item.ForeColor = Color.FloralWhite;
                item.BackColor = Color.Crimson;
            }
        }
        if (labProcedure.MicrobiologyPanicNotification !== null) {
            if (labProcedure.MicrobiologyPanicNotification === true) {
                //item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                item.ForeColor = Color.FloralWhite;
                item.BackColor = Color.Crimson;
            }
        }
        let subitemName: TTListViewSubItem = new TTListViewSubItem(); //Adı
        subitemName.Text = labProcedure.ProcedureObject.Name;
        item.SubItems.push(subitemName);
        let subitemStar: TTListViewSubItem = new TTListViewSubItem(); //Flag
        if (hasWarning) {
            if (labProcedure.Warning.Value === HighLowEnum.High) {
                subitemStar.Text = "*";
            }
            if (labProcedure.Warning.Value === HighLowEnum.Low) {
                subitemStar.Text = "*";
            }
            if (labProcedure.Warning.Value === HighLowEnum.Panic) {
                subitemStar.Text = "!";
            }
        }
        item.SubItems.push(subitemStar);
        let subitem: TTListViewSubItem = new TTListViewSubItem(); //Sonuç
        subitem.Text = labProcedure.Result;
        item.SubItems.push(subitem);
        let subitem2: TTListViewSubItem = new TTListViewSubItem(); //Sapma
        subitem2.Text = (labProcedure.Warning !== undefined) === true ? (await CommonService.GetDisplayTextOfDataTypeEnum(labProcedure.Warning.Value)) : "";
        item.SubItems.push(subitem2);
        let subitem3: TTListViewSubItem = new TTListViewSubItem(); //Referans
        subitem3.Text = labProcedure.Reference;
        item.SubItems.push(subitem3);
        let subitem4: TTListViewSubItem = new TTListViewSubItem(); //Özel Değerler
        subitem4.Text = labProcedure.SpecialReference !== null ? (await CommonService.GetTextOfRTFString(labProcedure.SpecialReference.toString())) : "";
        item.SubItems.push(subitem4);
        let subitem5: TTListViewSubItem = new TTListViewSubItem(); //Birim
        subitem5.Text = labProcedure.Unit;
        item.SubItems.push(subitem5);
        let subitem6: TTListViewSubItem = new TTListViewSubItem(); //Açıklama
        subitem6.Text = labProcedure.ResultDescription;
        item.SubItems.push(subitem6);
        let subitem7: TTListViewSubItem = new TTListViewSubItem(); //Panik
        if (labProcedure.Panic !== null) {
            if (labProcedure.Panic.Value === HighLowEnum.High) {
                subitem7.Text = "Çok Yüksek Değer";
            }
            if (labProcedure.Panic.Value === HighLowEnum.Low) {
                subitem7.Text = "Çok Düşük Değer";
            }
            if (labProcedure.Panic.Value === HighLowEnum.None) {
                subitem7.Text = "Bildirim Yok";
            }
        }
        if (labProcedure.MicrobiologyPanicNotification !== null) {
            if (labProcedure.MicrobiologyPanicNotification === true) {
                subitem7.Text = "Mikrobiyoloji Panik Sonuç Bildirimi!";
            }
        }
        item.SubItems.push(subitem7);
        listView.Items.push(item);
    }
    private async FillLabResults(): Promise<void> {
        let allProcedureList: Array<LaboratoryProcedure> = LaboratoryProcedure.GetLabResults(this._LaboratoryRequest.ObjectContext, " WHERE CURRENTSTATE <> '" + LaboratoryProcedure.LaboratoryProcedureStates.Cancelled + "' AND CURRENTSTATE <> '" + LaboratoryProcedure.LaboratoryProcedureStates.PendingCancel + "' AND EPISODEACTION = '" + this._LaboratoryRequest.ObjectID.toString() + "' ORDER BY REQUESTEDTAB");
        if (allProcedureList.length > 0) {
            let listView: TTListView = this.GenerateLabRequestedTab("Tüm Tetkikler");
            for (let labProcedure of allProcedureList) {
                this.FillLabProcedure(labProcedure, listView);
                for (let labSubProcedure of labProcedure.LaboratorySubProcedures) { this.FillLabProcedure(labSubProcedure, listView); }
            }
        }
        let liste: Array<LaboratoryRequestFormTabDefinition> = (await LaboratoryRequestFormTabDefinitionService.GetLabTabs(this._LaboratoryRequest.ObjectContext, " AND (LABORATORYDEPARTMENT = '" + this._LaboratoryRequest.MasterResource.ObjectID.toString() + "' OR LABORATORYDEPARTMENT IS NULL) ORDER BY TABORDER"));
        if (liste.length > 0) {
            for (let tabDef of liste) {
                let procedureList: Array<LaboratoryProcedure> = LaboratoryProcedure.GetLabResults(this._LaboratoryRequest.ObjectContext, " WHERE CURRENTSTATE <> '" + LaboratoryProcedure.LaboratoryProcedureStates.Cancelled + "' AND CURRENTSTATE <> '" + LaboratoryProcedure.LaboratoryProcedureStates.PendingCancel + "' AND EPISODEACTION = '" + this._LaboratoryRequest.ObjectID.toString() + "' AND REQUESTEDTAB = '" + tabDef.ObjectID.toString() + "'");
                if (procedureList.length > 0) {
                    let listView: TTListView = GenerateLabRequestedTab(tabDef.Name);
                    let tabNamesGridList: Array<LaboratoryTabNamesGrid.GetLabTabNamesGridByInjection_Class> = (await LaboratoryTabNamesGridService.GetLabTabNamesGridByInjection(this._LaboratoryRequest.ObjectContext, " WHERE REQUESTFORMTAB = '" + tabDef.ObjectID.toString() + "' ORDER BY TABORDER"));
                    {
                        for (let tabNameGrid of tabNamesGridList) {
                            for (let labProcedure of procedureList) {
                                if (tabNameGrid.Testdefid === (<LaboratoryTestDefinition>labProcedure.ProcedureObject).ObjectID) {
                                    this.FillLabProcedure(labProcedure, listView);
                                    let panelTests: Array<LaboratoryGridPanelTestDefinition> = (await LaboratoryGridPanelTestDefinitionService.GetLabGridPanels(this._LaboratoryRequest.ObjectContext, labProcedure.ProcedureObject.ObjectID));
                                    for (let testInPanel of panelTests) {
                                        for (let labSubProcedure of labProcedure.LaboratorySubProcedures) {
                                            if (testInPanel.LaboratoryTest.ObjectID === labSubProcedure.ProcedureObject.ObjectID) {
                                                this.FillLabProcedure(labSubProcedure, listView);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        } */
    }
   /* private async GenerateLabRequestedTab(tabName: string): Promise<TTListView> {
        let tabPage: TTTabPage = new TTTabPage();
        tabPage.Name = tabName;
        tabPage.Text = tabName;
        //tabPage.Tag = tabDef;
        let listView: TTListView = new TTListView();
        let listViewColumnDetail: TTListViewColumn = new TTListViewColumn();
        listViewColumnDetail.Text = "Rapor";
        listViewColumnDetail.Width = 50;
        listView.Columns.push(listViewColumnDetail);
        let listViewColumn1: TTListViewColumn = new TTListViewColumn();
        listViewColumn1.Text = "Adı";
        listViewColumn1.Width = 200;
        listView.Columns.push(listViewColumn1);
        let listViewColumn: TTListViewColumn = new TTListViewColumn();
        listViewColumn.Text = "*";
        listViewColumn.Width = 20;
        listView.Columns.push(listViewColumn);
        let listViewColumn2: TTListViewColumn = new TTListViewColumn();
        listViewColumn2.Text = "Sonuç";
        listViewColumn2.Width = 100;
        listView.Columns.push(listViewColumn2);
        let listViewColumn3: TTListViewColumn = new TTListViewColumn();
        listViewColumn3.Text = "Sapma";
        listViewColumn3.Width = 80;
        listView.Columns.push(listViewColumn3);
        let listViewColumn4: TTListViewColumn = new TTListViewColumn();
        listViewColumn4.Text = "Referans";
        listViewColumn4.Width = 100;
        listView.Columns.push(listViewColumn4);
        let listViewColumn5: TTListViewColumn = new TTListViewColumn();
        listViewColumn5.Text = "Özel Değerler";
        listViewColumn5.Width = 80;
        listView.Columns.push(listViewColumn5);
        let listViewColumn6: TTListViewColumn = new TTListViewColumn();
        listViewColumn6.Text = "Birim";
        listViewColumn6.Width = 80;
        listView.Columns.push(listViewColumn6);
        let listViewColumn7: TTListViewColumn = new TTListViewColumn();
        listViewColumn7.Text = "Açıklama";
        listViewColumn7.Width = 100;
        listView.Columns.push(listViewColumn7);
        let listViewColumn8: TTListViewColumn = new TTListViewColumn();
        listViewColumn8.Text = "Panik Bildirim";
        listViewColumn8.Width = 170;
        listView.Columns.push(listViewColumn8);
        let listViewColumn9: TTListViewColumn = new TTListViewColumn();
        listViewColumn9.Text = "Numune Red Sebebi";
        listViewColumn9.Width = 170;
        listView.Columns.push(listViewColumn9);
        listView.Name = "ListView";
        listView.View = View.Details;
        listView.FullRowSelect = true;
        //listView.Dock = DockStyle.Fill;
        //listView.BorderStyle = BorderStyle.None;
        listView.GridLines = true;
        listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.OpenLongReportForm);
        tabPage.Controls.push(listView);
        this.tabResults.TabPages.push(tabPage);
        return listView;
    } */
    private async GridLabProcedures_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:ShowEdit!
        //if (GridLabProcedures.CurrentCell != null)
        //{
        //    switch (GridLabProcedures.CurrentCell.OwningColumn.Name)
        //    {
        //        case "Detail":
        //            LaboratoryProcedure procedure = (LaboratoryProcedure)GridLabProcedures.CurrentCell.OwningRow.TTObject;
        //            LaboratoryProcedureDetailForm detailForm = new LaboratoryProcedureDetailForm();
        //            detailForm.ShowEdit(this.FindForm(), procedure, true);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        let a = 1;
    }
    private async OpenLongReportForm(sender: Object, e: Object): Promise<void> {
       /* if (e.Item.Tag === null || !e.IsSelected)
            return;
        if (e.Item.Tag.toString() !== string.Empty) {
            let baseProc: SubactionProcedureFlowable = null;
            baseProc = <SubactionProcedureFlowable>this._LaboratoryRequest.ObjectContext.GetObject(new Guid(e.Item.Tag.toString()), TTObjectDefManager.Instance.ObjectDefs[typeof SubactionProcedureFlowable], false);
            if (baseProc instanceof LaboratoryProcedure) {

            }
            else if (baseProc instanceof LaboratorySubProcedure) {

            }
        } */
    }
    public async ttPrintResultReport_Click(): Promise<void> {
        let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
        let cache1: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
        cache1.push("VALUE", this._LaboratoryRequest.ObjectID.toString());
        //parameters.push("TTOBJECTID", cache1);
        if ((this._LaboratoryRequest.BarcodeID !== undefined)) {
            let cache: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
            cache.push("VALUE", this._LaboratoryRequest.BarcodeID.Value.toString());
            //parameters.push("BARCODEID", cache);
        }
        try {
            //TODO:Cursor!
            //this.Cursor = Cursors.WaitCursor;

            //TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_LaboratoryBarcodeResultReport, true, 1, parameters);
        }
        catch (ex) {
            //TODO:Cursor!
            //this.Cursor = Cursors.Default;
            TTVisual.InfoBox.Show(ex.toString(), MessageIconEnum.ErrorMessage);
        }
        finally {

        }
    }
    protected async ClientSidePreScript() {
        await super.ClientSidePreScript();
        //this.FillLabResults();
    }
    protected async PreScript() {
        await super.PreScript();
        if (this._LaboratoryRequest.BarcodeID !== null) {
            this.labelBarcode.Visible = true;
            this.textBarcode.Visible = true;
            this.textBarcode.Text = this._LaboratoryRequest.BarcodeID.toString();
        }
        //            if(this._EpisodeAction.CurrentStateDefID == LaboratoryRequest.States.Completed && !(TTUser.CurrentUser.IsSuperUser || TTUser.CurrentUser.IsPowerUser))
        //            {
        //                bool hcFound  = false;
        //                foreach (TTUserRole role in TTUser.CurrentUser.Roles)
        //                {
        //                    if (role.Name == "Sağlık Kurulu Başkanı" || role.Name == "Sağlık Kurulu Yazıcısı")
        //                    {
        //                        foreach(EpisodeAction ea in this._LaboratoryRequest.Episode.EpisodeActions)
        //                        {
        //                            if(ea is HealthCommittee)
        //                            {
        //                                hcFound = true;
        //                                break;
        //                            }
        //                        }
        //                        if(!hcFound)
        //                            throw new Exception("Sağlık Kurulu işlemi olmayan bir vakada \"Laboratuvar Sonuç Formu\"na erişim yetkiniz bulunmamaktadır.");
        //                        break;
        //                    }
        //                }
        //            }

        //this.TabForInformations.HideTabPage(this.TabPageFutureRequest);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryRequest();
        this.laboratoryRequestResultFormViewModel = new LaboratoryRequestResultFormViewModel();
        this._ViewModel = this.laboratoryRequestResultFormViewModel;
        this.laboratoryRequestResultFormViewModel._LaboratoryRequest = this._TTObject as LaboratoryRequest;
        this.laboratoryRequestResultFormViewModel._LaboratoryRequest.LaboratoryProcedures = new Array<LaboratoryProcedure>();
        this.laboratoryRequestResultFormViewModel._LaboratoryRequest.ApprovedBy = new ResUser();
        this.laboratoryRequestResultFormViewModel._LaboratoryRequest.RequestDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.laboratoryRequestResultFormViewModel = this._ViewModel as LaboratoryRequestResultFormViewModel;
        that._TTObject = this.laboratoryRequestResultFormViewModel._LaboratoryRequest;
        if (this.laboratoryRequestResultFormViewModel == null)
            this.laboratoryRequestResultFormViewModel = new LaboratoryRequestResultFormViewModel();
        if (this.laboratoryRequestResultFormViewModel._LaboratoryRequest == null)
            this.laboratoryRequestResultFormViewModel._LaboratoryRequest = new LaboratoryRequest();
        that.laboratoryRequestResultFormViewModel._LaboratoryRequest.LaboratoryProcedures = that.laboratoryRequestResultFormViewModel.GridLabProceduresGridList;
        for (let detailItem of that.laboratoryRequestResultFormViewModel.GridLabProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.laboratoryRequestResultFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
        let approvedByObjectID = that.laboratoryRequestResultFormViewModel._LaboratoryRequest["ApprovedBy"];
        if (approvedByObjectID != null && (typeof approvedByObjectID === 'string')) {
            let approvedBy = that.laboratoryRequestResultFormViewModel.ResUsers.find(o => o.ObjectID.toString() === approvedByObjectID.toString());
             if (approvedBy) {
                that.laboratoryRequestResultFormViewModel._LaboratoryRequest.ApprovedBy = approvedBy;
            }
        }
        let requestDoctorObjectID = that.laboratoryRequestResultFormViewModel._LaboratoryRequest["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.laboratoryRequestResultFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.laboratoryRequestResultFormViewModel._LaboratoryRequest.RequestDoctor = requestDoctor;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(LaboratoryRequestResultFormViewModel);
  
    }


    public onGebelikChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Pregnancy != event) {
                this._LaboratoryRequest.Pregnancy = event;
            }
        }
    }

    public onlstApprovedByChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.ApprovedBy != event) {
                this._LaboratoryRequest.ApprovedBy = event;
            }
        }
    }

    public onPatientAgeChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.PatientAge != event) {
                this._LaboratoryRequest.PatientAge = event;
            }
        }
    }

    public onPatientSexChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.PatientSex != event) {
                this._LaboratoryRequest.PatientSex = event;
            }
        }
    }

    public onrequestDoctorChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.RequestDoctor != event) {
                this._LaboratoryRequest.RequestDoctor = event;
            }
        }
    }

    public onSonAdetTarihiChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.LastMensturationDate != event) {
                this._LaboratoryRequest.LastMensturationDate = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.RequestDoctor != event) {
                this._LaboratoryRequest.RequestDoctor = event;
            }
        }
    }

    public onttobjectlistbox2Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.RequestDoctor != event) {
                this._LaboratoryRequest.RequestDoctor = event;
            }
        }
    }

    public onttobjectlistbox3Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.RequestDoctor != event) {
                this._LaboratoryRequest.RequestDoctor = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Prediagnosis != event) {
                this._LaboratoryRequest.Prediagnosis = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Notes != event) {
                this._LaboratoryRequest.Notes = event;
            }
        }
    }

    public onUrgentChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Urgent != event) {
                this._LaboratoryRequest.Urgent = event;
            }
        }
    }

    public onWorkListDateChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.WorkListDate != event) {
                this._LaboratoryRequest.WorkListDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PatientAge, "Text", this.__ttObject, "PatientAge");
        redirectProperty(this.PatientSex, "Value", this.__ttObject, "PatientSex");
        redirectProperty(this.Urgent, "Value", this.__ttObject, "Urgent");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Prediagnosis");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Notes");
        redirectProperty(this.Gebelik, "Value", this.__ttObject, "Pregnancy");
        redirectProperty(this.SonAdetTarihi, "Value", this.__ttObject, "LastMensturationDate");
        redirectProperty(this.WorkListDate, "Value", this.__ttObject, "WorkListDate");
    }

    public initFormControls(): void {
        this.ttPrintResultReport = new TTVisual.TTButton();
        this.ttPrintResultReport.BackColor = "#FFFAF0";
        this.ttPrintResultReport.Text = i18n("M18228", "Laboratuvar Sonuç Raporu");
        this.ttPrintResultReport.Name = "ttPrintResultReport";
        this.ttPrintResultReport.TabIndex = 53;

        this.tabResults = new TTVisual.TTTabControl();
        this.tabResults.Name = "tabResults";
        this.tabResults.TabIndex = 46;

        this.TabControlLabProcedures = new TTVisual.TTTabControl();
        this.TabControlLabProcedures.Name = "TabControlLabProcedures";
        this.TabControlLabProcedures.TabIndex = 0;
        this.TabControlLabProcedures.Visible = false;

        this.TabPageLabProcedures = new TTVisual.TTTabPage();
        this.TabPageLabProcedures.DisplayIndex = 0;
        this.TabPageLabProcedures.BackColor = "#FFFFFF";
        this.TabPageLabProcedures.TabIndex = 0;
        this.TabPageLabProcedures.Text = i18n("M23341", "Tetkikler");
        this.TabPageLabProcedures.Name = "TabPageLabProcedures";

        this.GridLabProcedures = new TTVisual.TTGrid();
        this.GridLabProcedures.OnRowMarkerDoubleClickShowTTObjectForm = false;
        this.GridLabProcedures.AllowUserToDeleteRows = false;
        this.GridLabProcedures.Name = "GridLabProcedures";
        this.GridLabProcedures.TabIndex = 0;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 0;
        this.ProcedureObject.HeaderText = "Obje";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.Visible = false;
        this.ProcedureObject.Width = 100;

        this.LabProcedure = new TTVisual.TTTextBoxColumn();
        this.LabProcedure.DataMember = "Name";
        this.LabProcedure.DisplayIndex = 1;
        this.LabProcedure.HeaderText = "Test adı";
        this.LabProcedure.Name = "LabProcedure";
        this.LabProcedure.ReadOnly = true;
        this.LabProcedure.Width = 200;

        this.Result = new TTVisual.TTTextBoxColumn();
        this.Result.DataMember = "Result";
        this.Result.DisplayIndex = 2;
        this.Result.HeaderText = i18n("M22078", "Sonuç");
        this.Result.Name = "Result";
        this.Result.Width = 100;

        this.Warning = new TTVisual.TTEnumComboBoxColumn();
        this.Warning.DataTypeName = "HighLowEnum";
        this.Warning.DataMember = "Warning";
        this.Warning.DisplayIndex = 3;
        this.Warning.HeaderText = i18n("M21289", "Sapma");
        this.Warning.Name = "Warning";
        this.Warning.Width = 80;

        this.Reference = new TTVisual.TTTextBoxColumn();
        this.Reference.DataMember = "Reference";
        this.Reference.DisplayIndex = 4;
        this.Reference.HeaderText = i18n("M21008", "Referans");
        this.Reference.Name = "Reference";
        this.Reference.Width = 100;

        this.SpecialReference = new TTVisual.TTRichTextBoxControlColumn();
        this.SpecialReference.DisplayText = i18n("M20079", "Özel Değerler");
        this.SpecialReference.DataMember = "SpecialReference";
        this.SpecialReference.DisplayIndex = 5;
        this.SpecialReference.HeaderText = i18n("M20079", "Özel Değerler");
        this.SpecialReference.Name = "SpecialReference";
        this.SpecialReference.Width = 100;

        this.Unit = new TTVisual.TTTextBoxColumn();
        this.Unit.DataMember = "Unit";
        this.Unit.DisplayIndex = 6;
        this.Unit.HeaderText = "Birim";
        this.Unit.Name = "Unit";
        this.Unit.Width = 80;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12672", "Detay Gir");
        this.Detail.DisplayIndex = 7;
        this.Detail.HeaderText = i18n("M12671", "Detay");
        this.Detail.Name = "Detail";
        this.Detail.Width = 50;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DisplayIndex = 8;
        this.Amount.HeaderText = i18n("M12341", "Çarpan");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Visible = false;
        this.Amount.Width = 100;

        this.ResultNote = new TTVisual.TTTextBoxColumn();
        this.ResultNote.DataMember = "ResultDescription";
        this.ResultNote.DisplayIndex = 9;
        this.ResultNote.HeaderText = i18n("M10469", "Açıklama");
        this.ResultNote.Name = "ResultNote";
        this.ResultNote.Width = 160;

        this.LongReport = new TTVisual.TTRichTextBoxControlColumn();
        this.LongReport.DisplayText = "Rapor";
        this.LongReport.DataMember = "LongReport";
        this.LongReport.DisplayIndex = 10;
        this.LongReport.HeaderText = "Rapor";
        this.LongReport.Name = "LongReport";
        this.LongReport.Width = 60;

        this.TabForInformations = new TTVisual.TTTabControl();
        this.TabForInformations.Name = "TabForInformations";
        this.TabForInformations.TabIndex = 44;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M14681", "Genel Bilgiler");
        this.tttabpage1.Name = "tttabpage1";

        this.PatientGroup = new TTVisual.TTEnumComboBox();
        this.PatientGroup.DataTypeName = "PatientGroupEnum";
        this.PatientGroup.BackColor = "#F0F0F0";
        this.PatientGroup.Enabled = false;
        this.PatientGroup.Name = "PatientGroup";
        this.PatientGroup.TabIndex = 0;

        this.PatientSex = new TTVisual.TTEnumComboBox();
        this.PatientSex.DataTypeName = "SexEnum";
        this.PatientSex.BackColor = "#F0F0F0";
        this.PatientSex.Enabled = false;
        this.PatientSex.Name = "PatientSex";
        this.PatientSex.TabIndex = 3;

        this.PatientAge = new TTVisual.TTTextBox();
        this.PatientAge.BackColor = "#F0F0F0";
        this.PatientAge.ReadOnly = true;
        this.PatientAge.Name = "PatientAge";
        this.PatientAge.TabIndex = 2;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M12265", "Cinsiyet");
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 46;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M24340", "Yaş (Yıl-Ay-Gün)");
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 45;

        this.ReasonForAdmisson = new TTVisual.TTTextBox();
        this.ReasonForAdmisson.BackColor = "#F0F0F0";
        this.ReasonForAdmisson.ReadOnly = true;
        this.ReasonForAdmisson.Name = "ReasonForAdmisson";
        this.ReasonForAdmisson.TabIndex = 1;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M17026", "Kabul Sebebi");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 43;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 42;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.labelPreInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 37;

        this.Urgent = new TTVisual.TTCheckBox();
        this.Urgent.Value = false;
        this.Urgent.Text = "Acil";
        this.Urgent.Name = "Urgent";
        this.Urgent.TabIndex = 8;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M19476", "Not");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 40;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 5;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 4;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 3;
        this.tttabpage2.Text = i18n("M13517", "Ek Bilgiler");
        this.tttabpage2.Name = "tttabpage2";

        this.lstApprovedBy = new TTVisual.TTObjectListBox();
        this.lstApprovedBy.ListDefName = "UserListDefinition";
        this.lstApprovedBy.Name = "lstApprovedBy";
        this.lstApprovedBy.TabIndex = 43;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 41;

        this.requestDoctor = new TTVisual.TTObjectListBox();
        this.requestDoctor.ListDefName = "UserListDefinition";
        this.requestDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.requestDoctor.Name = "requestDoctor";
        this.requestDoctor.TabIndex = 42;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M19713", "Onaylayan Uzman");
        this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 41;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.BackColor = "#FFFFFF";
        this.tttabpage3.TabIndex = 1;
        this.tttabpage3.Text = "Gebelik - S.A.T";
        this.tttabpage3.Name = "tttabpage3";

        this.Gebelik = new TTVisual.TTEnumComboBox();
        this.Gebelik.DataTypeName = "LaboratoryPregnancyEnum";
        this.Gebelik.Name = "Gebelik";
        this.Gebelik.TabIndex = 52;

        this.SonAdetTarihi = new TTVisual.TTDateTimePicker();
        this.SonAdetTarihi.Format = DateTimePickerFormat.Long;
        this.SonAdetTarihi.Name = "SonAdetTarihi";
        this.SonAdetTarihi.TabIndex = 54;

        this.labelSonAdetTarihi = new TTVisual.TTLabel();
        this.labelSonAdetTarihi.Text = i18n("M22037", "Son Adet Tarihi");
        this.labelSonAdetTarihi.ForeColor = "#000080";
        this.labelSonAdetTarihi.Name = "labelSonAdetTarihi";
        this.labelSonAdetTarihi.TabIndex = 55;

        this.labelGebelik = new TTVisual.TTLabel();
        this.labelGebelik.Text = "Gebelik";
        this.labelGebelik.ForeColor = "#000080";
        this.labelGebelik.Name = "labelGebelik";
        this.labelGebelik.TabIndex = 53;

        this.TabPageFutureRequest = new TTVisual.TTTabPage();
        this.TabPageFutureRequest.DisplayIndex = 3;
        this.TabPageFutureRequest.BackColor = "#FFFFFF";
        this.TabPageFutureRequest.TabIndex = 2;
        this.TabPageFutureRequest.Text = i18n("M16404", "İleri Tarihli İstek");
        this.TabPageFutureRequest.Visible = false;
        this.TabPageFutureRequest.Name = "TabPageFutureRequest";

        this.WorkListDate = new TTVisual.TTDateTimePicker();
        this.WorkListDate.CustomFormat = "DD.MM.YYYY hh:mi";
        this.WorkListDate.Format = DateTimePickerFormat.Long;
        this.WorkListDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.WorkListDate.Name = "WorkListDate";
        this.WorkListDate.TabIndex = 32;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16773", "İş Listesine Gelme Tarihi");
        this.labelProcessTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 33;

        this.textBarcode = new TTVisual.TTTextBox();
        this.textBarcode.BackColor = "#F0F0F0";
        this.textBarcode.ReadOnly = true;
        this.textBarcode.Name = "textBarcode";
        this.textBarcode.TabIndex = 52;
        this.textBarcode.Visible = false;

        this.ttlabel3drawgradient = new TTVisual.TTLabel();
        this.ttlabel3drawgradient.Name = "ttlabel3drawgradient";
        this.ttlabel3drawgradient.TabIndex = 45;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 41;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 42;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 41;

        this.ttobjectlistbox2 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox2.ListDefName = "UserListDefinition";
        this.ttobjectlistbox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox2.Name = "ttobjectlistbox2";
        this.ttobjectlistbox2.TabIndex = 42;

        this.ttobjectlistbox3 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox3.ListDefName = "UserListDefinition";
        this.ttobjectlistbox3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox3.Name = "ttobjectlistbox3";
        this.ttobjectlistbox3.TabIndex = 42;

        this.labelBarcode = new TTVisual.TTLabel();
        this.labelBarcode.Text = "BarkodNo:";
        this.labelBarcode.Name = "labelBarcode";
        this.labelBarcode.TabIndex = 51;
        this.labelBarcode.Visible = false;

        this.GridLabProceduresColumns = [this.ProcedureObject, this.LabProcedure, this.Result, this.Warning, this.Reference, this.SpecialReference, this.Unit, this.Detail, this.Amount, this.ResultNote, this.LongReport];
        this.TabControlLabProcedures.Controls = [this.TabPageLabProcedures];
        this.TabPageLabProcedures.Controls = [this.GridLabProcedures];
        this.TabForInformations.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3, this.TabPageFutureRequest];
        this.tttabpage1.Controls = [this.PatientGroup, this.PatientSex, this.PatientAge, this.ttlabel6, this.ttlabel5, this.ReasonForAdmisson, this.ttlabel4, this.ttlabel3, this.labelPreInformation, this.Urgent, this.ttlabel1, this.tttextbox2, this.tttextbox1];
        this.tttabpage2.Controls = [this.lstApprovedBy, this.ttlabel2, this.requestDoctor, this.ttlabel9];
        this.tttabpage3.Controls = [this.Gebelik, this.SonAdetTarihi, this.labelSonAdetTarihi, this.labelGebelik];
        this.TabPageFutureRequest.Controls = [this.WorkListDate, this.labelProcessTime];
        this.Controls = [this.ttPrintResultReport, this.tabResults, this.TabControlLabProcedures, this.TabPageLabProcedures, this.GridLabProcedures, this.ProcedureObject, this.LabProcedure, this.Result, this.Warning, this.Reference, this.SpecialReference, this.Unit, this.Detail, this.Amount, this.ResultNote, this.LongReport, this.TabForInformations, this.tttabpage1, this.PatientGroup, this.PatientSex, this.PatientAge, this.ttlabel6, this.ttlabel5, this.ReasonForAdmisson, this.ttlabel4, this.ttlabel3, this.labelPreInformation, this.Urgent, this.ttlabel1, this.tttextbox2, this.tttextbox1, this.tttabpage2, this.lstApprovedBy, this.ttlabel2, this.requestDoctor, this.ttlabel9, this.tttabpage3, this.Gebelik, this.SonAdetTarihi, this.labelSonAdetTarihi, this.labelGebelik, this.TabPageFutureRequest, this.WorkListDate, this.labelProcessTime, this.textBarcode, this.ttlabel3drawgradient, this.ttlabel7, this.ttobjectlistbox1, this.ttlabel8, this.ttobjectlistbox2, this.ttobjectlistbox3, this.labelBarcode];

    }


}
