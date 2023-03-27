//$8CAE5181
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyRequestFormViewModel } from "./RadiologyRequestFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Dictionary } from "NebulaClient/System/Collections/Dictionaries/Dictionary";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { ToothNumberEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";

import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";



@Component({
    selector: 'RadiologyRequestForm',
    templateUrl: './RadiologyRequestForm.html',
    providers: [MessageService]
})
export class RadiologyRequestForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    btnCreateTemplate: TTVisual.ITTButton;
    btnEditTemplate: TTVisual.ITTButton;
    btnSelectTemplate: TTVisual.ITTButton;
    cmbToothNumber: TTVisual.ITTEnumComboBox;
    DisTaahhutNo: TTVisual.ITTTextBox;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    labelDisTaahhutNo: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    labelToothNumber: TTVisual.ITTLabel;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    //private radItemBackColor: Color = Color.FromArgb(191, 219, 255);
    //public CurrentTestObjID: Guid = new Guid();
    public deleteRow: boolean = false;
    //public grid: TTGrid = new TTGrid();
    public selectedTestList: Dictionary<Guid, Array<ToothNumberEnum>> = new Dictionary<Guid, Array<ToothNumberEnum>>();
    public tempTestGuidList: Array<Guid> = new Array<Guid>();
    public tempTestList: Array<RadiologyTest> = new Array<RadiologyTest>();
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    TabGridConrol: TTVisual.ITTTabControl;
    tabPageDescription: TTVisual.ITTTabPage;
    tabPagePreDiagnosis: TTVisual.ITTTabPage;
    ttbuttonToothSchema: TTVisual.ITTButton;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttextbox2: TTVisual.ITTTextBox;
    txtPreDiagnosis: TTVisual.ITTTextBox;
    public GridEpisodeDiagnosisColumns = [];
    public radiologyRequestFormViewModel: RadiologyRequestFormViewModel = new RadiologyRequestFormViewModel();
    public get _Radiology(): Radiology {
        return this._TTObject as Radiology;
    }
    private RadiologyRequestForm_DocumentUrl: string = '/api/RadiologyService/RadiologyRequestForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async AddCheckedItemToTempList(sender: Object, e: Object): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //RadiologyTestDefinition radReqTestDef = null;
        //TTListView lv = sender as TTListView;
        //TTListViewItem selectedTest = (TTListViewItem)lv.Items[e.Index];
        //Guid objId = (Guid)selectedTest.Tag;
        //TTObjectContext roContext = new TTObjectContext(true);
        //radReqTestDef = (RadiologyTestDefinition)roContext.GetObject(objId,"RADIOLOGYTESTDEFINITION");

        //if(e.NewValue == CheckState.Unchecked)
        //{
        //    if(tempTestGuidList.Contains(radReqTestDef.ObjectID))
        //        tempTestGuidList.Remove(radReqTestDef.ObjectID);
        //    selectedTest.BackColor = Color.White;
        //    return;
        //}
        //else
        //{
        //    //CheckRequest(radReqTestDef,selectedTest);
        //    /*
        //        if(labReqTestDef.IsPanel == true)
        //            CreateTestsFromSelectedPanel(labReqTestDef,labProcedure);
        //     */

        //    if(!tempTestGuidList.Contains(radReqTestDef.ObjectID))
        //        tempTestGuidList.Add(radReqTestDef.ObjectID);
        //    selectedTest.BackColor = radItemBackColor;
        //    //selectedTest.Font = radSelectedItemFont;
        //}
        let a = 1;
    }
    private async AddSelectedTestList(sender: Object, e: Object): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //RadiologyTestDefinition radReqTestDef = null;
        //TTListView lv = sender as TTListView;
        //TTListViewItem selectedTest = (TTListViewItem)lv.Items[e.Index];
        //Guid objId = (Guid)selectedTest.Tag;
        //TTObjectContext roContext = new TTObjectContext(true);
        //radReqTestDef = (RadiologyTestDefinition)roContext.GetObject(objId,"RADIOLOGYTESTDEFINITION");
        //if(radReqTestDef == null)
        //    return;

        //if (e.NewValue == CheckState.Unchecked)
        //{
        //    if (selectedTestList.ContainsKey(radReqTestDef.ObjectID))
        //        selectedTestList.Remove(radReqTestDef.ObjectID);
        //    selectedTest.BackColor = Color.White;
        //    return;
        //}
        //else
        //{
        //    List<ToothNumberEnum> toothNumberList = new List<ToothNumberEnum>();
        //    if (!selectedTestList.ContainsKey(radReqTestDef.ObjectID))
        //    {
        //        if (radReqTestDef.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
        //        {
        //            TTFormClasses.RadiologyRequestDentalToothSchema radiologyRequestDentalToothSchema = new TTFormClasses.RadiologyRequestDentalToothSchema();
        //            radiologyRequestDentalToothSchema.ShowEdit(this, _Radiology,true);
        //            if (radiologyRequestDentalToothSchema.DialogResult != DialogResult.OK || radiologyRequestDentalToothSchema.ToothNumbersList.Count <= 0)
        //            {
        //                e.NewValue = CheckState.Unchecked;
        //                InfoBox.Alert("'" + radReqTestDef.Name + "' tetkiği için diş seçimi zorunludur.", MessageIconEnum.WarningMessage );
        //                //throw new TTException("'" + radReqTestDef.Name + "' tetkiği için diş seçimi zorunludur." );
        //                return;
        //            }
        //            else
        //            {
        //                selectedTestList.Add(radReqTestDef.ObjectID, radiologyRequestDentalToothSchema.ToothNumbersList);
        //            }
        //        }
        //        else
        //            selectedTestList.Add(radReqTestDef.ObjectID, toothNumberList);
        //    }
        //    else
        //    {
        //        e.NewValue = CheckState.Unchecked;
        //        InfoBox.Alert("'" + radReqTestDef.Name + "' tetkiği istenen tetkikler arasında zaten bulunmaktadır.", MessageIconEnum.WarningMessage );
        //        //throw new TTException("'" + radReqTestDef.Name + "' tetkiği istenen tetkikler arasında zaten bulunmaktadır." );
        //        return;
        //    }
        //    selectedTest.BackColor = radItemBackColor;
        //}
        let a = 1;
    }
    private async btnCreateTemplate_Click(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TODO : InputForm methodu kapatıldı. Ilerıde baska bır cozum dusunulecek.
        /* if (this._Radiology.RadiologyRequestTemplate == null)
         {
             try
             {
                 string description = InputForm.GetText("Şablon Açıklaması");
                 if (!string.IsNullOrEmpty(description))
                 {
                     TTObjectContext objectContext = new TTObjectContext(false);

                     RadiologyAcceptTemplateDefinition template = new RadiologyAcceptTemplateDefinition(objectContext);
                     foreach(TabPage page in this.TabGridConrol.TabPages)
                     {
                         foreach(Control control in page.Controls)
                         {
                             if(control is TTListView)
                             {
                                 TTListView lv = (TTListView)control;
                                 template.ResUser = Common.CurrentResource;
                                 template.Name = description;

                                 foreach(TTListViewItem lvItem in lv.CheckedItems)
                                 {
                                     if(lvItem.Tag is Guid)
                                     {
                                         RadiologyTestDefinition radReqTestDef = (RadiologyTestDefinition)objectContext.GetObject(new Guid(lvItem.Tag.ToString()),"RadiologyTestDefinition");
                                         RadiologyAcceptTemplateDetail templateDetail = new RadiologyAcceptTemplateDetail(objectContext);
                                         templateDetail.RadiologyTestDefinition = radReqTestDef;
                                         template.RadiologyAcceptTemplateDetails.Add(templateDetail);
                                     }
                                 }
                             }
                         }
                     }
                     objectContext.Save();
                 }
             }
             catch (Exception ex)
             {
                 InfoBox.Show(ex);
             }
         } */
        let a = 1;
    }
    private async btnEditTemplate_Click(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TTObjectContext objectContext = new TTObjectContext(false);
        //         IList templates = objectContext.QueryObjects("RADIOLOGYACCEPTTEMPLATEDEFINITION");
        //         MultiSelectForm pForm = new MultiSelectForm();
        //         foreach(RadiologyAcceptTemplateDefinition template in templates)
        //         {
        //             pForm.AddMSItem(template.Name, template.ObjectID.ToString(),template);
        //         }

        //         string sKey = pForm.GetMSItem(this, "Radyoloji şablonu seçiniz.",false,false,false,false,true,false);
        //         if(!String.IsNullOrEmpty(sKey))
        //         {
        //             //TODO: DefinitionForm Conversion
        //             //RadiologyAcceptTemplateDefinition selectedTemplate = (RadiologyAcceptTemplateDefinition)pForm.MSSelectedItemObject;
        //             //TTDefinitionForm frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["RadiologyAcceptTemplateListForDefinitionForm"]);
        //             //frm.ShowEdit(this.FindForm(),TTObjectDefManager.Instance.ListDefs["RadiologyAcceptTemplateListForDefinitionForm"],selectedTemplate);
        //         }
        let a = 1;
    }
    private async btnSelectTemplate_Click(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TTObjectContext objectContext = new TTObjectContext(true);
        //         IList templates = objectContext.QueryObjects("RADIOLOGYACCEPTTEMPLATEDEFINITION");
        //         MultiSelectForm pForm = new MultiSelectForm();
        //         foreach(RadiologyAcceptTemplateDefinition template in templates)
        //             pForm.AddMSItem(template.Name, template.ObjectID.ToString(),template);

        //         string sKey = pForm.GetMSItem(this, "Radyoloji şablonu seçiniz.",false,false,false,false,true,false);
        //         if(!String.IsNullOrEmpty(sKey))
        //         {
        //             RadiologyAcceptTemplateDefinition selectedTemplate = (RadiologyAcceptTemplateDefinition)pForm.MSSelectedItemObject;
        //             foreach(RadiologyAcceptTemplateDetail detail in selectedTemplate.RadiologyAcceptTemplateDetails)
        //             {
        //                 foreach(TabPage page in this.TabGridConrol.TabPages)
        //                 {
        //                     foreach(Control control in page.Controls)
        //                     {
        //                         if(control is TTListView)
        //                         {
        //                            TTListView lv = (TTListView)control;
        //                             foreach(TTListViewItem otherTest in lv.Items){
        //                                 RadiologyTestDefinition radReqTestDef = (RadiologyTestDefinition)objectContext.GetObject(new Guid(otherTest.Tag.ToString()), "RadiologyTestDefinition");
        //                                 if(!otherTest.Checked && (detail.RadiologyTestDefinition.ObjectID == radReqTestDef.ObjectID)){
        //                                     otherTest.Checked = true;
        //                                     break;
        //                                 }
        //                             }
        //                         }
        //                     }
        //                 }
        //             }
        //         }
        let a = 1;
    }
    private async CheckTimeLimit(sender: Object, e: Object): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //if(e.NewValue == CheckState.Unchecked)
        //    return;
        //TTObjectContext roContext = new TTObjectContext(true);
        //long limitAsDay = -1;
        //RadiologyTestDefinition testDef = null;

        //TTListView lv = sender as TTListView;
        //TTListViewItem selectedTest = (TTListViewItem)lv.Items[e.Index];

        //if(selectedTest.Tag is Guid?)
        //{
        //    Guid objId = (Guid)selectedTest.Tag;
        //    testDef = (RadiologyTestDefinition)roContext.GetObject(objId,"RadiologyTestDefinition");
        //    limitAsDay = testDef.TimeLimit == null || testDef.TimeLimit == 0 ? -1 : Convert.ToInt64(testDef.TimeLimit.Value);
        //}

        //if(limitAsDay == -1)
        //    return;

        //string patientID = this._Radiology.Episode.Patient.ObjectID.ToString();
        //DateTime startDate = this._Radiology.ActionDate.Value;

        //startDate = startDate.AddDays(ToNegative(limitAsDay));
        //DateTime endDate = this._Radiology.ActionDate.Value;
        //string testID = testDef.ObjectID.ToString();

        //IList sameTestRequestList = RadiologyTest.GetRadTestByPatientByTestByDate(roContext, patientID, testID, startDate, endDate);

        //if(sameTestRequestList.Count == 0)
        //    return;

        //RadiologyTest test = (RadiologyTest)sameTestRequestList[0];
        //if(test.CurrentStateDefID == RadiologyTest.States.Cancelled)
        //    return;

        //InfoBox.Alert(testDef.Name + " testi " + test.WorkListDate.ToString() + " tarihinde zaten istenmiş.", MessageIconEnum.WarningMessage);
        //e.NewValue = CheckState.Unchecked;
        let a = 1;
    }
    private async CheckWorkingDays(sender: Object, e: Object): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //if(e.NewValue == CheckState.Unchecked)
        //    return;
        //TTObjectContext roContext = new TTObjectContext(true);
        //RadiologyTestDefinition testDef = null;
        //TTListView lv = sender as TTListView;
        //TTListViewItem selectedTest = (TTListViewItem)lv.Items[e.Index];

        //if(selectedTest.Tag is Guid?)
        //{
        //    Guid objId = (Guid)selectedTest.Tag;
        //    testDef = (RadiologyTestDefinition)roContext.GetObject(objId,"RadiologyTestDefinition");
        //    DateTime actionDate = this._Radiology.ActionDate.Value;
        //    string strDay = actionDate.DayOfWeek.ToString();

        //    if(testDef.IsPassiveNow == true){
        //        InfoBox.Alert(testDef.Name + " testi " + testDef.ReasonForPassive + " sebebiyle çalışılmamaktadır.", MessageIconEnum.InformationMessage);
        //        e.NewValue = CheckState.Unchecked;
        //        return;
        //    }

        //    switch (strDay)
        //    {
        //        case "Monday":
        //            {if(testDef.OnMonday == true) return;}
        //            break;
        //        case "Tuesday":
        //            {if(testDef.OnTuesday == true) return;}
        //            break;
        //        case "Wednesday":
        //            {if(testDef.OnWednesday == true) return;}
        //            break;
        //        case "Thursday":
        //            {if(testDef.OnThursday == true) return;}
        //            break;
        //        case "Friday":
        //            {if(testDef.OnFriday == true) return;}
        //            break;
        //        case "Saturday":
        //            {if(testDef.OnSaturday == true) return;}
        //            break;
        //        case "Sunday":
        //            {if(testDef.OnSunday == true) return;}
        //            break;
        //    }

        //    InfoBox.Alert(testDef.Name + " testi bugün çalışılmamaktadır.", MessageIconEnum.InformationMessage );
        //    e.NewValue = CheckState.Unchecked;
        //}
        let a = 1;
    }
   /* private async FillTab(oTabDef: Object, tabPage: TTTabPage): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //RadiologyTabDefinition tabDef = oTabDef as RadiologyTabDefinition;
        //if (tabDef != null)
        //{
        //    TTListView listView = new TTListView();
        //    TTListViewColumn listViewColumn = new TTListViewColumn();
        //    listViewColumn.Text = "Testler";
        //    listViewColumn.Width = -1;
        //    listView.Columns.Add(listViewColumn);

        //    listView.Name = "ListView";
        //    listView.View = View.List;
        //    listView.CheckBoxes = true;
        //    //listView.Dock = DockStyle.Fill;
        //    listView.Sorting = SortOrder.Ascending;
        //    listView.MultiSelect = false;

        //    listView.ItemCheck += new ItemCheckEventHandler(this.CheckTimeLimit);
        //    listView.ItemCheck += new ItemCheckEventHandler(this.CheckWorkingDays);
        //    listView.ItemCheck += new ItemCheckEventHandler(this.AddCheckedItemToTempList);
        //    listView.ItemCheck += new ItemCheckEventHandler(this.AddSelectedTestList);

        //    TTObjectContext roContext = new TTObjectContext(true);
        //    BindingList<RadiologyTabNamesGrid.GetByTabs_Class> grids = RadiologyTabNamesGrid.GetByTabs(roContext, tabDef.ObjectID.ToString());
        //    foreach (RadiologyTabNamesGrid.GetByTabs_Class tabGrid in grids)
        //    {
        //        if (tabGrid.Testdefid.HasValue)
        //        {
        //            TTListViewItem item2 = new TTListViewItem();
        //            item2.Name = tabGrid.Testname;
        //            item2.Text = tabGrid.Testname;
        //            item2.Tag = tabGrid.Testdefid;
        //            if (tabGrid.IsPassiveNow == true)
        //                item2.ForeColor = Color.FromArgb(255, 109, 109, 109);  //System.Drawing.SystemColors.GrayText;

        //            listView.Items.Add(item2);
        //        }
        //    }
        //    tabPage.Controls.Add(listView);
        //}
        let a = 1;
    } */
    /*
    private async GridControl_CellClick(sender: Object, e: DataGridViewCellEventArgs): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //CurrentTestObjID = Guid.Empty;
        //TTGrid grd = sender as TTGrid;
        //if(grd.CurrentCell != null && grd.CurrentCell.Value != null)
        //    CurrentTestObjID = (Guid)grd.CurrentCell.Value;
        let a = 1;
    } */
    private async GridControl_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //DataGridViewRow enteredRow = grid.Rows[rowIndex];

        //if(enteredRow != null)
        //{
        //    DataGridViewCell enteredCell = enteredRow.Cells[columnIndex];
        //    if(enteredCell != null && enteredCell.Value != null)
        //    {
        //        if(CurrentTestObjID != null && !CurrentTestObjID.Equals((Guid)enteredCell.Value) && !selectedTestList.ContainsKey((Guid)enteredCell.Value))
        //        {
        //            if(selectedTestList.ContainsKey(CurrentTestObjID))
        //                selectedTestList.Remove(CurrentTestObjID);
        //        }

        //        TTObjectContext roContext = new TTObjectContext(true);
        //        Guid objId = (Guid)enteredCell.Value;
        //        RadiologyTestDefinition radReqTestDef = (RadiologyTestDefinition)roContext.GetObject(objId,"RADIOLOGYTESTDEFINITION");
        //        if(radReqTestDef == null)
        //            return;
        //        List<ToothNumberEnum> toothNumberList = new List<ToothNumberEnum>();
        //        if (!selectedTestList.ContainsKey(radReqTestDef.ObjectID))
        //        {
        //            if (radReqTestDef.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
        //            {
        //                //TODO : ShowEdit kaldırılacagı ıcın kapatıldı. Baska bır cozum dusunulecek.

        //                //TTFormClasses.RadiologyRequestDentalToothSchema radiologyRequestDentalToothSchema = new TTFormClasses.RadiologyRequestDentalToothSchema();
        //                //radiologyRequestDentalToothSchema.ShowEdit(this, _Radiology,true);
        //                //if (radiologyRequestDentalToothSchema.DialogResult != DialogResult.OK || radiologyRequestDentalToothSchema.ToothNumbersList.Count <= 0)
        //                //{
        //                //    selectedTestList.Add(radReqTestDef.ObjectID, toothNumberList);
        //                //}
        //                //else
        //                //{
        //                //    selectedTestList.Add(radReqTestDef.ObjectID, radiologyRequestDentalToothSchema.ToothNumbersList);
        //                //}
        //            }
        //            else
        //                selectedTestList.Add(radReqTestDef.ObjectID, toothNumberList);
        //        }
        //        else
        //        {
        //            InfoBox.Alert("'" + radReqTestDef.Name + "' tetkiği istenen tetkikler arasında zaten bulunmaktadır.", MessageIconEnum.WarningMessage);
        //            grid.CellValueChanged -= GridControl_CellValueChanged;
        //            if(CurrentTestObjID.Equals(Guid.Empty))
        //            {
        //                deleteRow = true;
        //            }
        //            else
        //            {
        //                grid.Rows[rowIndex].Cells[columnIndex].Value = CurrentTestObjID;//(RadiologyTestDefinition)roContext.GetObject(CurrentTestObjID,"RADIOLOGYTESTDEFINITION");
        //            }
        //            grid.CellValueChanged += GridControl_CellValueChanged;
        //        }
        //    }
        //}
        let a = 1;
    }
   /*
    private async GridControl_RowsAdded(sender: Object, e: DataGridViewRowsAddedEventArgs): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TTGrid grd = sender as TTGrid;
        //if(!deleteRow)
        //    return;
        //if(grd.Rows[e.RowIndex]!= null && grd.Rows[e.RowIndex].Cells[0] != null && deleteRow)
        //    grd.Rows.RemoveAt(e.RowIndex);
        //deleteRow = false;

        let a = 1;
    } */
    /*
    private async GridControl_RowsRemoving(sender: Object, e: DataGridViewRowCancelEventArgs): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TTGrid grd = sender as TTGrid;
        //DataGridViewRow[] selRows = new DataGridViewRow[grd.SelectedRows.Count];
        //for (int i = 0; i < grd.SelectedRows.Count; i++)
        //    selRows[i] = grd.SelectedRows[i];
        //foreach (DataGridViewRow selRow in selRows)
        //{
        //    Guid objID = (Guid)selRow.Cells[0].Value;
        //    if(selectedTestList.ContainsKey(objID) && string.IsNullOrEmpty(selRow.ErrorText))
        //        selectedTestList.Remove(objID);
        //}
        let a = 1;
    }
    */
    /*
    private async GridControl_RowValidated(sender: Object, e: DataGridViewCellEventArgs): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TTGrid grd = sender as TTGrid;
        //if(grd.Rows[e.RowIndex]!= null && grd.Rows[e.RowIndex].Cells[e.ColumnIndex] != null && grd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
        //    grd.Rows.RemoveAt(e.RowIndex);
        let a = 1;
    }
    */
    /*
    private async GridControl_RowValidating(rowIndex: number, columnIndex: number, e: CancelEventArgs): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //if (deleteRow)
        //{
        //    grid.CurrentRow.ErrorText = "Hata";
        //}
        //deleteRow = false;
        let a = 1;
    } */
    private async OpenTestInfoForm(sender: Object, e: Object): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //if(sender is RadiologyRequestForm)
        //{
        //    RadiologyRequestForm radForm = (RadiologyRequestForm)sender;
        //    TabPage page = (TabPage)radForm.TabGridConrol.SelectedTab;
        //    foreach(Control control in page.Controls)
        //    {
        //        if(control is TTListView)
        //        {
        //            TTListView lv = (TTListView)control;
        //            foreach(TTListViewItem lvItem in lv.SelectedItems)
        //            {
        //                if(lvItem.Tag is Guid?)
        //                {
        //                    Guid objId = (Guid)lvItem.Tag;
        //                    TTObjectContext roContext = new TTObjectContext(true);
        //                    RadiologyTestDefinition testDef = (RadiologyTestDefinition)roContext.GetObject(objId,"RadiologyTestDefinition");
        //                    TTDefinitionForm frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["RadiologyTestDefinitionList"]);
        //                    frm.ShowReadOnly(this.FindForm(),TTObjectDefManager.Instance.ListDefs["RadiologyTestDefinitionList"],testDef,string.Empty);
        //                }
        //            }
        //        }
        //    }
        //}
        let a = 1;
    }
    /*
    private async SetCheckedItemsAsRequestedProcedures(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TTObjectContext roContext = new TTObjectContext(true);
        //foreach(Guid testID in tempTestGuidList)
        //{
        //    RadiologyTest newRadTest = new RadiologyTest(this._Radiology.ObjectContext);
        //    RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)roContext.GetObject(testID,"RADIOLOGYTESTDEFINITION");
        //    newRadTest.ProcedureObject = radTestDef;
        //    if(radTestDef.Departments.Count == 0)
        //        throw new Exception(SystemMessage.GetMessage(918));
        //    //newRadTest.MasterResource = radTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
        //    //newRadTest.FromResource = this._Radiology.FromResource;
        //    SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(this._Radiology,this._Radiology.MasterResource,this._Radiology.FromResource, newRadTest);
        //    newRadTest.EpisodeAction = this._EpisodeAction;
        //    //newRadTest.Amount = radTestDef.PriceCoefficient == null ? 1 : radTestDef.PriceCoefficient;
        //    //newRadTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
        //    if(radTestDef.Equipments.Count >0)
        //        newRadTest.Equipment = radTestDef.Equipments[0].Equipment; //ilk tanımlı cihazı alır
        //    if (radTestDef.Departments.Count > 0)
        //        newRadTest.Department = (ResRadiologyDepartment)this._Radiology.MasterResource; //ilk tanımlı bölümü alır
        //    //radTest.FromResource = this._Radiology.FromResource;
        //    newRadTest.RequestDate = this._Radiology.RequestDate;
        //    newRadTest.ActionDate = (DateTime)this._Radiology.ActionDate;
        //    newRadTest.RadiologyRequestNo.GetNextValue();
        //    if (this._Radiology.ToothNumber != null)
        //        newRadTest.ToothNumber = ((int)this._Radiology.ToothNumber).ToString();//this.txtToothNumber.Text;

        //    foreach(RadiologyGridMaterialDefinition defMaterialGrid in radTestDef.Materials)
        //    {
        //        RadiologyMaterial radMaterial = new RadiologyMaterial(this._Radiology.ObjectContext);
        //        radMaterial.Amount = defMaterialGrid.Amount;
        //        radMaterial.Material = defMaterialGrid.Material;
        //        radMaterial.EpisodeAction = this._EpisodeAction;
        //        newRadTest.RadiologyTestTreatmentMaterial.Add(radMaterial);
        //    }

        //    if(!this._Radiology.RadiologyTests.Contains(newRadTest))
        //        this._Radiology.RadiologyTests.Add(newRadTest);
        //}
        //foreach(TabPage page in this.TabGridConrol.TabPages)
        //{
        //    if(page.Name == "AllTests")
        //    {
        //        foreach(Control control in page.Controls)
        //        {
        //            if(control is TTGrid)
        //            {
        //                TTGrid grd = (TTGrid)control;
        //                foreach(DataGridViewRow row in grd.Rows)
        //                {
        //                    if(row.Cells[0].Value != null)
        //                    {
        //                        string objId = row.Cells[0].Value.ToString();

        //                        RadiologyTestDefinition testDef = (RadiologyTestDefinition)roContext.GetObject(new Guid(objId), "RadiologyTestDefinition");
        //                        if(testDef.Departments.Count == 0)
        //                            throw new Exception(SystemMessage.GetMessage(918));
        //                        RadiologyTest radGridTest = new RadiologyTest(this._Radiology.ObjectContext);
        //                        SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(this._Radiology,this._Radiology.MasterResource,this._Radiology.FromResource,radGridTest);
        //                        radGridTest.ProcedureObject = testDef;
        //                        //radGridTest.RadiologyRequestNo.GetNextValue();
        //                        radGridTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
        //                        if(testDef.Equipments.Count >0)
        //                            radGridTest.Equipment = testDef.Equipments[0].Equipment; //ilk tanımlı cihazı alır
        //                        if(testDef.Departments.Count > 0)
        //                            radGridTest.Department = (ResRadiologyDepartment)(this._Radiology.MasterResource); //ilk tanımlı bölümü alır
        //                        //radTest.FromResource = this._Radiology.FromResource;
        //                        radGridTest.RequestDate = this._Radiology.RequestDate;
        //                        radGridTest.ActionDate = (DateTime)this._Radiology.ActionDate;
        //                        //düzelt
        //                        //if (this._Radiology.ToothNumber != null)
        //                        //radGridTest.ToothNumber = ((int)this._Radiology.ToothNumber).ToString(); // this.txtToothNumber.Text;

        //                        foreach(RadiologyGridMaterialDefinition defMaterialGrid in testDef.Materials)
        //                        {
        //                            RadiologyMaterial radMaterial = new RadiologyMaterial(this._Radiology.ObjectContext);
        //                            radMaterial.Amount = defMaterialGrid.Amount;
        //                            radMaterial.Material = defMaterialGrid.Material;
        //                            radMaterial.EpisodeAction = this._EpisodeAction;
        //                            radGridTest.RadiologyTestTreatmentMaterial.Add(radMaterial);
        //                        }

        //                        this._Radiology.RadiologyTests.Add(radGridTest);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        let a = 1;
    } */
    private async SetSelectedItemsAsRequestedProcedures(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TTObjectContext roContext = new TTObjectContext(true);
        //foreach(KeyValuePair<Guid, List<ToothNumberEnum>> kp in selectedTestList)
        //{
        //    if(kp.Value.Count > 0)
        //    {
        //        foreach(ToothNumberEnum toothNumber in kp.Value)
        //        {
        //            RadiologyTest newToothRadTest = new RadiologyTest(this._Radiology.ObjectContext);
        //            RadiologyTestDefinition radToothTestDef = (RadiologyTestDefinition)roContext.GetObject(kp.Key,"RADIOLOGYTESTDEFINITION");
        //            newToothRadTest.ProcedureObject = radToothTestDef;
        //            if (radToothTestDef.Departments.Count == 0)
        //                throw new Exception(SystemMessage.GetMessage(918));
        //            //newRadTest.MasterResource = radTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
        //            //newRadTest.FromResource = this._Radiology.FromResource;
        //            SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(this._Radiology, this._Radiology.MasterResource, this._Radiology.FromResource,newToothRadTest);
        //            newToothRadTest.EpisodeAction = this._EpisodeAction;
        //            //newRadTest.Amount = radTestDef.PriceCoefficient == null ? 1 : radTestDef.PriceCoefficient;
        //            //newRadTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
        //            if (radToothTestDef.Equipments.Count > 0)
        //                newToothRadTest.Equipment = radToothTestDef.Equipments[0].Equipment; //ilk tanımlı cihazı alır
        //            if (radToothTestDef.Departments.Count > 0)
        //                newToothRadTest.Department = (ResRadiologyDepartment)this._Radiology.MasterResource; //ilk tanımlı bölümü alır
        //            //radTest.FromResource = this._Radiology.FromResource;
        //            newToothRadTest.RequestDate = this._Radiology.RequestDate;
        //            newToothRadTest.ActionDate = (DateTime)this._Radiology.ActionDate;
        //            newToothRadTest.RadiologyRequestNo.GetNextValue();
        //            newToothRadTest.TestToothNumber = toothNumber;//this.txtToothNumber.Text;

        //            foreach (RadiologyGridMaterialDefinition defMaterialGrid in radToothTestDef.Materials)
        //            {
        //                RadiologyMaterial radMaterial = new RadiologyMaterial(this._Radiology.ObjectContext);
        //                radMaterial.Amount = defMaterialGrid.Amount;
        //                radMaterial.Material = defMaterialGrid.Material;
        //                radMaterial.EpisodeAction = this._EpisodeAction;
        //                newToothRadTest.RadiologyTestTreatmentMaterial.Add(radMaterial);
        //            }

        //            if (!this._Radiology.RadiologyTests.Contains(newToothRadTest))
        //                this._Radiology.RadiologyTests.Add(newToothRadTest);
        //        }
        //    }
        //    else
        //    {
        //        RadiologyTest newRadTest = new RadiologyTest(this._Radiology.ObjectContext);
        //        RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)roContext.GetObject(kp.Key,"RADIOLOGYTESTDEFINITION");
        //        newRadTest.ProcedureObject = radTestDef;
        //        if(radTestDef.Departments.Count == 0)
        //            throw new Exception(SystemMessage.GetMessage(918));
        //        //newRadTest.MasterResource = radTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
        //        //newRadTest.FromResource = this._Radiology.FromResource;
        //        SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(this._Radiology,this._Radiology.MasterResource,this._Radiology.FromResource,newRadTest);
        //        newRadTest.EpisodeAction = this._EpisodeAction;
        //        //newRadTest.Amount = radTestDef.PriceCoefficient == null ? 1 : radTestDef.PriceCoefficient;
        //        //newRadTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
        //        if(radTestDef.Equipments.Count >0)
        //            newRadTest.Equipment = radTestDef.Equipments[0].Equipment; //ilk tanımlı cihazı alır
        //        if (radTestDef.Departments.Count > 0)
        //            newRadTest.Department = (ResRadiologyDepartment)this._Radiology.MasterResource; //ilk tanımlı bölümü alır
        //        //radTest.FromResource = this._Radiology.FromResource;
        //        newRadTest.RequestDate = this._Radiology.RequestDate;
        //        newRadTest.ActionDate = (DateTime)this._Radiology.ActionDate;
        //        newRadTest.RadiologyRequestNo.GetNextValue();
        //        if (this._Radiology.ToothNumber != null)
        //            newRadTest.ToothNumber = ((int)this._Radiology.ToothNumber).ToString();//this.txtToothNumber.Text;

        //        foreach(RadiologyGridMaterialDefinition defMaterialGrid in radTestDef.Materials)
        //        {
        //            RadiologyMaterial radMaterial = new RadiologyMaterial(this._Radiology.ObjectContext);
        //            radMaterial.Amount = defMaterialGrid.Amount;
        //            radMaterial.Material = defMaterialGrid.Material;
        //            radMaterial.EpisodeAction = this._EpisodeAction;
        //            newRadTest.RadiologyTestTreatmentMaterial.Add(radMaterial);
        //        }

        //        if(!this._Radiology.RadiologyTests.Contains(newRadTest))
        //            this._Radiology.RadiologyTests.Add(newRadTest);
        //    }
        //}
        ///*foreach(TabPage page in this.TabGridConrol.TabPages)
        //{
        //    if(page.Name == "AllTests")
        //    {
        //        foreach(Control control in page.Controls)
        //        {
        //            if(control is TTGrid)
        //            {
        //                TTGrid grd = (TTGrid)control;
        //                foreach(DataGridViewRow row in grd.Rows)
        //                {
        //                    if(row.Cells[0].Value != null)
        //                    {
        //                        string objId = row.Cells[0].Value.ToString();

        //                        RadiologyTestDefinition testDef = (RadiologyTestDefinition)roContext.GetObject(new Guid(objId), "RadiologyTestDefinition");
        //                        if(testDef.Departments.Count == 0)
        //                            throw new Exception(SystemMessage.GetMessage(918));
        //                        RadiologyTest radGridTest = new RadiologyTest(this._Radiology.ObjectContext);
        //                        radGridTest.SetMandatorySubactionProcedureFlowableProperties(this._Radiology,this._Radiology.MasterResource,this._Radiology.FromResource);
        //                        radGridTest.ProcedureObject = testDef;
        //                        //radGridTest.RadiologyRequestNo.GetNextValue();
        //                        radGridTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
        //                        if(testDef.Equipments.Count >0)
        //                            radGridTest.Equipment = testDef.Equipments[0].Equipment; //ilk tanımlı cihazı alır
        //                        if(testDef.Departments.Count > 0)
        //                            radGridTest.Department = (ResRadiologyDepartment)(this._Radiology.MasterResource); //ilk tanımlı bölümü alır
        //                        //radTest.FromResource = this._Radiology.FromResource;
        //                        radGridTest.RequestDate = this._Radiology.RequestDate;
        //                        radGridTest.ActionDate = (DateTime)this._Radiology.ActionDate;
        //                        //düzelt
        //                        //if (this._Radiology.ToothNumber != null)
        //                        //radGridTest.ToothNumber = ((int)this._Radiology.ToothNumber).ToString(); // this.txtToothNumber.Text;

        //                        foreach(RadiologyGridMaterialDefinition defMaterialGrid in testDef.Materials)
        //                        {
        //                            RadiologyMaterial radMaterial = new RadiologyMaterial(this._Radiology.ObjectContext);
        //                            radMaterial.Amount = defMaterialGrid.Amount;
        //                            radMaterial.Material = defMaterialGrid.Material;
        //                            radMaterial.EpisodeAction = this._EpisodeAction;
        //                            radGridTest.RadiologyTestTreatmentMaterial.Add(radMaterial);
        //                        }

        //                        this._Radiology.RadiologyTests.Add(radGridTest);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}*/
        let a = 1;
    }
    private async TabGridConrol_SelectedTabChanged(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //if(this.TabGridConrol.SelectedTab != null)
        //{
        //    TTTabPage selectedTabPage = this.TabGridConrol.SelectedTab as TTTabPage;
        //    if(selectedTabPage.HasChildren)
        //        return;
        //    RadiologyTabDefinition tabDef = selectedTabPage.Tag as RadiologyTabDefinition;
        //    if(tabDef != null)
        //    {
        //        this.FillTab(tabDef, selectedTabPage);
        //    }
        //}
        let a = 1;
    }
    private async ttbuttonToothSchema_Click(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TODO:ShowEdit kaldırıldı, daha sonra farklı bır sekılde degerlendırılecek.
        //RadiologyDentalToothSchema radiologyDentalForm = new RadiologyDentalToothSchema();
        //    if (radiologyDentalForm != null)
        //        radiologyDentalForm.ShowEdit(this.FindForm(),_Radiology,true);
        let a = 1;
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //base.AfterContextSavedScript(transDef);

        ////SITEID ye bagli kontrol yapiliyordu, kaldirildi. Istenirse baska sistem parametresine baglanabilir.
        //    this.PrintRadiologyRequestDescriptonReport();
        let a = 1;
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //base.ClientSidePostScript(transDef);

        //        if(String.IsNullOrEmpty(txtPreDiagnosis.Text))
        //        {
        //            throw new Exception("Kısa Anamnez ve Klinik Bulgular alanı boş geçilemez!");
        //        }


        // SetCheckedItemsAsRequestedProcedures();


        /*foreach(RadiologyTest radiologyTest in this._Radiology.RadiologyTests)
        {
            if(radiologyTest.CurrentStateDefID != RadiologyTest.States.Cancelled &&  radiologyTest.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri && radiologyTest.TestToothNumber == null)
            {
                InfoBox.S how("'" + radiologyTest.ProcedureObject.Name + " tetkiği için diş şemasından diş seçmelisiniz !");
                TTFormClasses.RadiologyRequestDentalToothSchema radiologyRequestDentalToothSchema = new TTFormClasses.RadiologyRequestDentalToothSchema();
                    radiologyRequestDentalToothSchema.S howEdit(this, _Radiology,true);
                    if (radiologyRequestDentalToothSchema.DialogResult != DialogResult.OK || radiologyRequestDentalToothSchema.ToothNumbersList.Count <= 0)
                    {
                        InfoBox.S how("'" + radiologyTest.ProcedureObject.Name + "' tetkiği için diş seçimi zorunludur." );
                        return;
                    }
                    else
                    {
                        if(selectedTestList.ContainsKey(radiologyTest.ProcedureObject.ObjectID))
                            selectedTestList[radiologyTest.ProcedureObject.ObjectID] = radiologyRequestDentalToothSchema.ToothNumbersList;
                    }
            }
        }*/


        //TODO : ShowEdit  kapatıldı, ılerıde farklı bır cozum dusunulecek. Asagıdakı blok dıs sectırmek ıcın yazıldıgı ıcın komple kapatıldı.
        /*Dictionary<Guid, List<ToothNumberEnum>> tempSelectedTestList = new Dictionary<Guid, List<ToothNumberEnum>>();

        foreach(KeyValuePair<Guid, List<ToothNumberEnum>> kp in selectedTestList)
        {
            tempSelectedTestList.Add(kp.Key, kp.Value);
        }

        foreach(KeyValuePair<Guid, List<ToothNumberEnum>> kp in tempSelectedTestList)
        {
            TTObjectContext roContext = new TTObjectContext(true);
            RadiologyTestDefinition radToothTestDef = (RadiologyTestDefinition)roContext.GetObject(kp.Key,"RADIOLOGYTESTDEFINITION");
            if(radToothTestDef.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri && kp.Value.Count <=0)
            {
                InfoBox.Alert("'" + radToothTestDef.Name + "' tetkiği için diş şemasından diş seçmelisiniz !", MessageIconEnum.WarningMessage);
                TTFormClasses.RadiologyRequestDentalToothSchema radiologyRequestDentalToothSchema = new TTFormClasses.RadiologyRequestDentalToothSchema();
                radiologyRequestDentalToothSchema.ShowEdit(this, _Radiology,true);
                if (radiologyRequestDentalToothSchema.DialogResult != DialogResult.OK || radiologyRequestDentalToothSchema.ToothNumbersList.Count <= 0)
                {
                    throw new TTUtils.TTException("'" + radToothTestDef.Name + "' tetkiği için diş seçimi zorunludur." );
                }
                else
                {
                    if(selectedTestList.ContainsKey(radToothTestDef.ObjectID))
                        selectedTestList[radToothTestDef.ObjectID] = radiologyRequestDentalToothSchema.ToothNumbersList;
                }
            }
        } */
        let a = 1;
    }
    protected async ClientSidePreScript(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //base.ClientSidePreScript();
        //        FillRadiologyTabs();
        let a = 1;
    }
    protected async OnKeyUp(e: any): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //base.OnKeyUp(e);
        //switch (e.KeyCode)
        //{
        //    case Keys.F2:
        //        OpenTestInfoForm(this, EventArgs.Empty);
        //        break;
        //}
        let a = 1;
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        //Tetkik İstem Panelinden yonetılecek!
        ////Kontrol ve uyarı kodları clıentsıde postscrıpte tasındı
        //       SetSelectedItemsAsRequestedProcedures();
        //        if(this._Radiology.RadiologyTests.Count == 0)
        //        {
        //            String message = SystemMessage.GetMessage(198);
        //            throw new TTUtils.TTException(message);
        //        }
        //        else
        //        {
        //            if(this._Radiology.PatientAdmission != null && this._Radiology.PatientAdmission.AdmissionAppointment != null)
        //            {
        //                foreach (Appointment app in this._Radiology.PatientAdmission.AdmissionAppointment.Appointments)
        //                {
        //                    if(app.CurrentStateDefID == Appointment.States.New || app.CurrentStateDefID == Appointment.States.NotApproved)
        //                    {
        //                        app.SubActionProcedure = this._Radiology.RadiologyTests[0];
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        base.PostScript(transDef);
        let a = 1;
    }
    protected async PreScript() {
        //Tetkik İstem Panelinden yonetılecek!
        //base.PreScript();

        //        if(!((ITTObject)this._Radiology).IsReadOnly)
        //        {
        //            this._Radiology.RequestDoctor = Common.CurrentResource;
        //        }

        //        this.cmdOK.Visible = false;
        let a = 1;
    }
    public async FillRadiologyTabs(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //TTObjectContext roContext = new TTObjectContext(true);

        //BindingList<RadiologyTabDefinition> liste = RadiologyTabDefinition.GetRadTabs(roContext," AND (RADIOLOGYDEPARTMENT = '" + this._Radiology.MasterResource.ObjectID.ToString() + "' OR RADIOLOGYDEPARTMENT IS NULL) ORDER BY TABORDER");

        //if(liste.Count > 0)
        //{
        //    // Fill Only First Tab, rest will be loaded on demand
        //    RadiologyTabDefinition tabDef = (RadiologyTabDefinition)liste[0];
        //    TTTabPage tabPage = new TTTabPage();
        //    tabPage.Name = tabDef.Name;
        //    tabPage.Text = tabDef.Name;
        //    tabPage.Tag = tabDef;
        //    this.FillTab(tabDef,tabPage);
        //    TabGridConrol.TabPages.Add(tabPage);

        //    for(int i = 0; i < liste.Count-1; i++)
        //    {
        //        tabDef = (RadiologyTabDefinition)liste[i+1];
        //        tabPage = new TTTabPage();
        //        tabPage.Name = tabDef.Name;
        //        tabPage.Text = tabDef.Name;
        //        tabPage.Tag = tabDef;
        //        TabGridConrol.SelectedTabChanged += new TTControlEventDelegate(TabGridConrol_SelectedTabChanged);
        //        TabGridConrol.TabPages.Add(tabPage);
        //    }
        //}

        ////Bütün Tetkikler Tabı
        //TTTabPage tabPageAll = new TTTabPage();
        //tabPageAll.Name = "AllTests";
        //tabPageAll.Text = "Tüm Tetkikler";

        //grid.DataMember = "RadiologyTests";

        //TTListBoxColumn testColumn = new TTListBoxColumn();
        //testColumn.Name = "ProcedureObject";
        //testColumn.HeaderText = "Tetkik";
        //testColumn.DataMember = "PROCEDUREOBJECT";
        //testColumn.ListDefName = "RadiologyTestListDefinition";
        //testColumn.Width = 300;

        //grid.Columns.Add(testColumn);
        ////grid.Dock = DockStyle.Fill;
        //grid.CellValueChanged += new TTGridCellEventDelegate(GridControl_CellValueChanged);
        //grid.UserDeletingRow += new DataGridViewRowCancelEventHandler(GridControl_RowsRemoving);
        //grid.CellEnter += new DataGridViewCellEventHandler(GridControl_CellClick);
        //grid.RowValidating += new TTGridCellCancelEventDelegate(GridControl_RowValidating);
        ////grid.RowValidated += new DataGridViewCellEventHandler(GridControl_RowValidated);
        //grid.RowsAdded += new DataGridViewRowsAddedEventHandler(GridControl_RowsAdded);

        //tabPageAll.Controls.Add(grid);
        //TabGridConrol.TabPages.Add(tabPageAll);

        let a = 1;
    }
    /*
    public async PrintRadiologyRequestDescriptonReport(): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

        //TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
        //objectID.Add("VALUE", this._Radiology.ObjectID.ToString());

        //TTReportTool.PropertyCache<object> episodeID = new TTReportTool.PropertyCache<object>();
        //episodeID.Add("VALUE", this._Radiology.Episode.ObjectID.ToString());

        //TTReportTool.PropertyCache<object> requestDate = new TTReportTool.PropertyCache<object>();
        //foreach(TTObjectState objectState in this._Radiology.GetStateHistory())
        //{
        //    if(objectState.StateDefID == Radiology.States.Procedure)
        //    {
        //        requestDate.Add("VALUE", objectState.BranchDate.ToString());
        //    }
        //}

        //TTReportTool.PropertyCache<object> physician = new TTReportTool.PropertyCache<object>();
        //physician.Add("VALUE", this._Radiology.RequestDoctor.Name.ToString());

        //TTReportTool.PropertyCache<object> patientName = new TTReportTool.PropertyCache<object>();
        //patientName.Add("VALUE", this._Radiology.Episode.Patient.FullName);

        //TTReportTool.PropertyCache<object> sex = new TTReportTool.PropertyCache<object>();
        //sex.Add("VALUE", this._Radiology.Episode.Patient.Sex.ToString());

        //TTReportTool.PropertyCache<object> fromResource = new TTReportTool.PropertyCache<object>();
        //fromResource.Add("VALUE", this._Radiology.FromResource.Name);

        //parameters.Add("TTOBJECTID",objectID);
        //parameters.Add("EPISODEID",episodeID);
        //parameters.Add("REQUESTDATE",requestDate);
        //parameters.Add("PHYSICIAN",physician);
        //parameters.Add("PATIENTNAME",patientName);
        //parameters.Add("SEX",sex);
        //parameters.Add("FROMRESOURCE",fromResource);

        //TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyRequestDescription),true, 1, parameters);
        let a = 1;
    } */
    public async PrintRadiologyRequestDescriptonReport(radTest: RadiologyTest): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //RadiologyTestDefinition radTestDef = (RadiologyTestDefinition)radTest.ProcedureObject;

        //Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

        //TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
        //objectID.Add("VALUE", radTest.EpisodeAction.ObjectID.ToString());

        //TTReportTool.PropertyCache<object> episodeID = new TTReportTool.PropertyCache<object>();
        //episodeID.Add("VALUE", this._Radiology.Episode.ObjectID.ToString());

        //TTReportTool.PropertyCache<object> requestDate = new TTReportTool.PropertyCache<object>();
        //requestDate.Add("VALUE", radTest.RequestDate.ToString());

        //TTReportTool.PropertyCache<object> physician = new TTReportTool.PropertyCache<object>();
        //physician.Add("VALUE", radTest.Radiology.RequestDoctor.Name.ToString());

        //TTReportTool.PropertyCache<object> patientName = new TTReportTool.PropertyCache<object>();
        //patientName.Add("VALUE", this._Radiology.Episode.Patient.FullName);

        //TTReportTool.PropertyCache<object> sex = new TTReportTool.PropertyCache<object>();
        //sex.Add("VALUE", this._Radiology.Episode.Patient.Sex.ToString());

        //TTReportTool.PropertyCache<object> fromResource = new TTReportTool.PropertyCache<object>();
        //fromResource.Add("VALUE", radTest.FromResource.Name);

        //parameters.Add("TTOBJECTID",objectID);
        //parameters.Add("EPISODEID",episodeID);
        //parameters.Add("REQUESTDATE",requestDate);
        //parameters.Add("PHYSICIAN",physician);
        //parameters.Add("PATIENTNAME",patientName);
        //parameters.Add("SEX",sex);
        //parameters.Add("FROMRESOURCE",fromResource);

        //TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyRequestDescription),true, 1, parameters);
        let a = 1;
    }
    public async SetCheckedItemsAsRequestedProcedures(transDef: TTObjectStateTransitionDef): Promise<void> {
        //Tetkik İstem Panelinden yonetılecek!
        //if(transDef != null && transDef.FromStateDefID == Radiology.States.Request && transDef.ToStateDefID == Radiology.States.Procedure)
        //{
        //    foreach(RadiologyTest test in tempTestList)
        //        this._Radiology.RadiologyTests.Add(test);

        //    foreach(TabPage page in this.TabGridConrol.TabPages)
        //    {
        //        if(page.Name == "AllTests")
        //        {
        //            foreach(Control control in page.Controls)
        //            {
        //                if(control is TTGrid)
        //                {
        //                    TTGrid grd = (TTGrid)control;
        //                    foreach(DataGridViewRow row in grd.Rows)
        //                    {
        //                        if(row.Cells[0].Value != null)
        //                        {
        //                            string objId = row.Cells[0].Value.ToString();
        //                            TTObjectContext roContext = new TTObjectContext(true);
        //                            RadiologyTestDefinition testDef = (RadiologyTestDefinition)roContext.GetObject(new Guid(objId), "RadiologyTestDefinition");
        //                            if(testDef.Departments.Count == 0)
        //                                throw new Exception(SystemMessage.GetMessage(918));
        //                            RadiologyTest radGridTest = new RadiologyTest(this._Radiology.ObjectContext);
        //                            SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(this._Radiology,this._Radiology.MasterResource,this._Radiology.FromResource,radGridTest);
        //                            //radGridTest.RadiologyRequestNo.GetNextValue();
        //                            radGridTest.ProcedureObject = testDef;

        //                            radGridTest.CurrentStateDefID = RadiologyTest.States.RequestAcception;
        //                            if(testDef.Equipments.Count >0)
        //                                radGridTest.Equipment = testDef.Equipments[0].Equipment; //ilk tanımlı cihazı alır
        //                            if(testDef.Departments.Count > 0)
        //                                radGridTest.Department = (ResRadiologyDepartment)(this._Radiology.MasterResource);
        //                            //radTest.FromResource = this._Radiology.FromResource;
        //                            radGridTest.RequestDate = this._Radiology.RequestDate;
        //                            radGridTest.ActionDate = (DateTime)this._Radiology.ActionDate;
        //                            if (this._Radiology.ToothNumber != null)
        //                                radGridTest.ToothNumber = ((int)this._Radiology.ToothNumber).ToString();//this.txtToothNumber.Text;

        //                            foreach(RadiologyGridMaterialDefinition defMaterialGrid in testDef.Materials)
        //                            {
        //                                RadiologyMaterial radMaterial = new RadiologyMaterial(this._Radiology.ObjectContext);
        //                                radMaterial.Amount = defMaterialGrid.Amount;
        //                                radMaterial.Material = defMaterialGrid.Material;
        //                                radMaterial.EpisodeAction = this._EpisodeAction;
        //                                radGridTest.RadiologyTestTreatmentMaterial.Add(radMaterial);
        //                            }

        //                            this._Radiology.RadiologyTests.Add(radGridTest);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        let a = 1;
    }
    public async ToNegative(Number: number): Promise<number> {
        return Math.Abs(Number) * -1;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Radiology();
        this.radiologyRequestFormViewModel = new RadiologyRequestFormViewModel();
        this._ViewModel = this.radiologyRequestFormViewModel;
        this.radiologyRequestFormViewModel._Radiology = this._TTObject as Radiology;
        this.radiologyRequestFormViewModel._Radiology.RequestDoctor = new ResUser();
        this.radiologyRequestFormViewModel._Radiology.Episode = new Episode();
        this.radiologyRequestFormViewModel._Radiology.Episode.Diagnosis = new Array<DiagnosisGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyRequestFormViewModel = this._ViewModel as RadiologyRequestFormViewModel;
        that._TTObject = this.radiologyRequestFormViewModel._Radiology;
        if (this.radiologyRequestFormViewModel == null)
            this.radiologyRequestFormViewModel = new RadiologyRequestFormViewModel();
        if (this.radiologyRequestFormViewModel._Radiology == null)
            this.radiologyRequestFormViewModel._Radiology = new Radiology();
        let requestDoctorObjectID = that.radiologyRequestFormViewModel._Radiology["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.radiologyRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.radiologyRequestFormViewModel._Radiology.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.radiologyRequestFormViewModel._Radiology["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyRequestFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.radiologyRequestFormViewModel._Radiology.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.radiologyRequestFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyRequestFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyRequestFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyRequestFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.ActionDate != event) {
                this._Radiology.ActionDate = event;
            }
        }
    }

    public oncmbToothNumberChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.ToothNumber != event) {
                this._Radiology.ToothNumber = event;
            }
        }
    }

    public onDisTaahhutNoChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.DisTaahhutNo != event) {
                this._Radiology.DisTaahhutNo = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.RequestDoctor != event) {
                this._Radiology.RequestDoctor = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.Description != event) {
                this._Radiology.Description = event;
            }
        }
    }

    public ontxtPreDiagnosisChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.PreDiagnosis != event) {
                this._Radiology.PreDiagnosis = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.txtPreDiagnosis, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Description");
        redirectProperty(this.cmbToothNumber, "Value", this.__ttObject, "ToothNumber");
        redirectProperty(this.DisTaahhutNo, "Text", this.__ttObject, "DisTaahhutNo");
    }

    public initFormControls(): void {
        this.labelDisTaahhutNo = new TTVisual.TTLabel();
        this.labelDisTaahhutNo.Text = i18n("M12945", "Diş Taahhüt Numarası");
        this.labelDisTaahhutNo.Name = "labelDisTaahhutNo";
        this.labelDisTaahhutNo.TabIndex = 38;
        this.labelDisTaahhutNo.Visible = false;

        this.DisTaahhutNo = new TTVisual.TTTextBox();
        this.DisTaahhutNo.Name = "DisTaahhutNo";
        this.DisTaahhutNo.TabIndex = 37;
        this.DisTaahhutNo.Visible = false;

        this.labelToothNumber = new TTVisual.TTLabel();
        this.labelToothNumber.Text = i18n("M12917", "Diş Numarası");
        this.labelToothNumber.Name = "labelToothNumber";
        this.labelToothNumber.TabIndex = 36;
        this.labelToothNumber.Visible = false;

        this.cmbToothNumber = new TTVisual.TTEnumComboBox();
        this.cmbToothNumber.DataTypeName = "ToothNumberEnum";
        this.cmbToothNumber.BackColor = "#F0F0F0";
        this.cmbToothNumber.Enabled = false;
        this.cmbToothNumber.Name = "cmbToothNumber";
        this.cmbToothNumber.TabIndex = 35;
        this.cmbToothNumber.Visible = false;

        this.ttbuttonToothSchema = new TTVisual.TTButton();
        this.ttbuttonToothSchema.Text = i18n("M12940", "Diş Şeması");
        this.ttbuttonToothSchema.Name = "ttbuttonToothSchema";
        this.ttbuttonToothSchema.TabIndex = 32;
        this.ttbuttonToothSchema.Visible = false;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 29;

        this.tabPagePreDiagnosis = new TTVisual.TTTabPage();
        this.tabPagePreDiagnosis.DisplayIndex = 0;
        this.tabPagePreDiagnosis.TabIndex = 0;
        this.tabPagePreDiagnosis.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.tabPagePreDiagnosis.Name = "tabPagePreDiagnosis";

        this.txtPreDiagnosis = new TTVisual.TTTextBox();
        this.txtPreDiagnosis.Multiline = true;
        this.txtPreDiagnosis.Name = "txtPreDiagnosis";
        this.txtPreDiagnosis.TabIndex = 5;

        this.tabPageDescription = new TTVisual.TTTabPage();
        this.tabPageDescription.DisplayIndex = 1;
        this.tabPageDescription.TabIndex = 1;
        this.tabPageDescription.Text = i18n("M10483", "Açıklamalar");
        this.tabPageDescription.Name = "tabPageDescription";

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 6;

        this.TabGridConrol = new TTVisual.TTTabControl();
        this.TabGridConrol.Name = "TabGridConrol";
        this.TabGridConrol.TabIndex = 7;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16902", "İşlem Zamanı");
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 22;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 28;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M17026", "Kabul Sebebi");
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 4;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 2;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 4;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = i18n("M20117", "Özgeçmiş");
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 60;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisListDefinition";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = i18n("M22736", "Tanı");
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 360;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnosisType.DataMember = "DiagnosisType";
        this.EpisodeDiagnosisType.DisplayIndex = 2;
        this.EpisodeDiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.EpisodeDiagnosisType.Name = "EpisodeDiagnosisType";
        this.EpisodeDiagnosisType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 60;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 150;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 150;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.btnCreateTemplate = new TTVisual.TTButton();
        this.btnCreateTemplate.Text = i18n("M22453", "Şablon Oluştur");
        this.btnCreateTemplate.Name = "btnCreateTemplate";
        this.btnCreateTemplate.TabIndex = 1;

        this.btnEditTemplate = new TTVisual.TTButton();
        this.btnEditTemplate.Text = i18n("M22439", "Şablon Düzenle/Sil");
        this.btnEditTemplate.Name = "btnEditTemplate";
        this.btnEditTemplate.TabIndex = 2;

        this.btnSelectTemplate = new TTVisual.TTButton();
        this.btnSelectTemplate.Text = i18n("M22454", "Şablon Seç");
        this.btnSelectTemplate.Name = "btnSelectTemplate";
        this.btnSelectTemplate.TabIndex = 0;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.tttabcontrol1.Controls = [this.tabPagePreDiagnosis, this.tabPageDescription];
        this.tabPagePreDiagnosis.Controls = [this.txtPreDiagnosis];
        this.tabPageDescription.Controls = [this.tttextbox2];
        this.Controls = [this.labelDisTaahhutNo, this.DisTaahhutNo, this.labelToothNumber, this.cmbToothNumber, this.ttbuttonToothSchema, this.tttabcontrol1, this.tabPagePreDiagnosis, this.txtPreDiagnosis, this.tabPageDescription, this.tttextbox2, this.TabGridConrol, this.ttobjectlistbox1, this.ActionDate, this.labelProcessTime, this.ttlabel2, this.ttlabel3, this.PATIENTGROUPENUM, this.ttlabel4, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ReasonForAdmission, this.btnCreateTemplate, this.btnEditTemplate, this.btnSelectTemplate];

    }


}
