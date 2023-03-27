
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Radyoloji Tetkik İstek Formu
    /// </summary>
    public partial class RadiologyRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            //Tetkik İstem Panelinden yonetılecek!
            //ttbuttonToothSchema.Click += new TTControlEventDelegate(ttbuttonToothSchema_Click);
            //btnCreateTemplate.Click += new TTControlEventDelegate(btnCreateTemplate_Click);
            //btnEditTemplate.Click += new TTControlEventDelegate(btnEditTemplate_Click);
            //btnSelectTemplate.Click += new TTControlEventDelegate(btnSelectTemplate_Click);
            //base.BindControlEvents();
            var a = 1;
        }

        override protected void UnBindControlEvents()
        {
            //Tetkik İstem Panelinden yonetılecek!
            //ttbuttonToothSchema.Click -= new TTControlEventDelegate(ttbuttonToothSchema_Click);
            //btnCreateTemplate.Click -= new TTControlEventDelegate(btnCreateTemplate_Click);
            //btnEditTemplate.Click -= new TTControlEventDelegate(btnEditTemplate_Click);
            //btnSelectTemplate.Click -= new TTControlEventDelegate(btnSelectTemplate_Click);
            //base.UnBindControlEvents();
            var a = 1;
        }

        private void ttbuttonToothSchema_Click()
        {
            #region RadiologyRequestForm_ttbuttonToothSchema_Click
            //Tetkik İstem Panelinden yonetılecek!
            //TODO:ShowEdit kaldırıldı, daha sonra farklı bır sekılde degerlendırılecek.
            //RadiologyDentalToothSchema radiologyDentalForm = new RadiologyDentalToothSchema();
            //    if (radiologyDentalForm != null)
            //        radiologyDentalForm.ShowEdit(this.FindForm(),_Radiology,true);
            var a = 1;
            #endregion RadiologyRequestForm_ttbuttonToothSchema_Click
        }

        private void btnCreateTemplate_Click()
        {
            #region RadiologyRequestForm_btnCreateTemplate_Click
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
            var a = 1;
            #endregion RadiologyRequestForm_btnCreateTemplate_Click
        }

        private void btnEditTemplate_Click()
        {
            #region RadiologyRequestForm_btnEditTemplate_Click
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
            var a = 1;
            #endregion RadiologyRequestForm_btnEditTemplate_Click
        }

        private void btnSelectTemplate_Click()
        {
            #region RadiologyRequestForm_btnSelectTemplate_Click
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
            var a = 1;
            #endregion RadiologyRequestForm_btnSelectTemplate_Click
        }

        protected override void PreScript()
        {
            #region RadiologyRequestForm_PreScript
            //Tetkik İstem Panelinden yonetılecek!
            //base.PreScript();

            //        if(!((ITTObject)this._Radiology).IsReadOnly)
            //        {
            //            this._Radiology.RequestDoctor = Common.CurrentResource;
            //        }

            //        this.cmdOK.Visible = false;
            var a = 1;
            #endregion RadiologyRequestForm_PreScript

        }

        protected override void ClientSidePreScript()
        {
            #region RadiologyRequestForm_ClientSidePreScript
            //Tetkik İstem Panelinden yonetılecek!
            //base.ClientSidePreScript();
            //        FillRadiologyTabs();
            var a = 1;
            #endregion RadiologyRequestForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region RadiologyRequestForm_PostScript
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
            var a = 1;
            #endregion RadiologyRequestForm_PostScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region RadiologyRequestForm_ClientSidePostScript
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
            var a = 1;
            #endregion RadiologyRequestForm_ClientSidePostScript

        }

#region RadiologyRequestForm_Methods
        public List<RadiologyTest> tempTestList = new List<RadiologyTest>();
        public List<Guid> tempTestGuidList = new List<Guid>();
        public TTGrid grid = new TTGrid();
        public Dictionary<Guid,List<ToothNumberEnum>> selectedTestList = new Dictionary<Guid,List<ToothNumberEnum>>();
        public Guid CurrentTestObjID = new Guid();
        public bool deleteRow = false;
        
        //private Font radSelectedItemFont = new Font("Segeo UI", 8);
        private Color radItemBackColor = Color.FromArgb(191, 219, 255);
        
        public void FillRadiologyTabs()
        {
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

            var a = 1;
            
        }
        
        private void GridControl_RowValidating(int rowIndex, int columnIndex, CancelEventArgs e)
        {
            //Tetkik İstem Panelinden yonetılecek!
            //if (deleteRow)
            //{
            //    grid.CurrentRow.ErrorText = "Hata";
            //}
            //deleteRow = false;
            var a = 1;
        }

        private void GridControl_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Tetkik İstem Panelinden yonetılecek!
            //TTGrid grd = sender as TTGrid;
            //if(!deleteRow)
            //    return;
            //if(grd.Rows[e.RowIndex]!= null && grd.Rows[e.RowIndex].Cells[0] != null && deleteRow)
            //    grd.Rows.RemoveAt(e.RowIndex);
            //deleteRow = false;

            var a = 1;
        }

        private void GridControl_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //Tetkik İstem Panelinden yonetılecek!
            //TTGrid grd = sender as TTGrid;
            //if(grd.Rows[e.RowIndex]!= null && grd.Rows[e.RowIndex].Cells[e.ColumnIndex] != null && grd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            //    grd.Rows.RemoveAt(e.RowIndex);
            var a = 1;
        }

        private void GridControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Tetkik İstem Panelinden yonetılecek!
            //CurrentTestObjID = Guid.Empty;
            //TTGrid grd = sender as TTGrid;
            //if(grd.CurrentCell != null && grd.CurrentCell.Value != null)
            //    CurrentTestObjID = (Guid)grd.CurrentCell.Value;
            var a = 1;
        }



        private void GridControl_RowsRemoving(object sender, DataGridViewRowCancelEventArgs e)
        {
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
            var a = 1;
        }

        private void TabGridConrol_SelectedTabChanged()
        {
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
            var a = 1;
        }

        private void FillTab(Object oTabDef, TTTabPage tabPage)
        {
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
            var a = 1;
        }
        
        private void AddCheckedItemToTempList(object sender, ItemCheckEventArgs e)
        {
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
            var a = 1;
        }




        private void SetCheckedItemsAsRequestedProcedures()
        {
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
            var a = 1;
        }

        private void SetSelectedItemsAsRequestedProcedures()
        {
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
            var a = 1;
        }

        public void SetCheckedItemsAsRequestedProcedures(TTObjectStateTransitionDef transDef)
        {
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
            var a = 1;
        }
        /// <summary>
        /// Tanımlarda yer alan TimeLimit dolmadan aynı test için istek yapıldığında uyarı verir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckTimeLimit(object sender, ItemCheckEventArgs e)
        {
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
            var a = 1;
        }

        private void CheckWorkingDays(object sender, ItemCheckEventArgs e)
        {
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
            var a = 1;
        }



        /// <summary>
        /// Converts a positive number into negative
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public long ToNegative(long Number)
        {
            return Math.Abs(Number) * -1;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnKeyUp(KeyEventArgs e)
        {
            //Tetkik İstem Panelinden yonetılecek!
            //base.OnKeyUp(e);
            //switch (e.KeyCode)
            //{
            //    case Keys.F2:
            //        OpenTestInfoForm(this, EventArgs.Empty);
            //        break;
            //}
            var a = 1;
        }

        #endregion RadiologyRequestForm_Methods

        #region RadiologyRequestForm_ClientSideMethods
        private void GridControl_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
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
            var a = 1;
        }

        private void AddSelectedTestList(object sender, ItemCheckEventArgs e)
        {
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
            var a = 1;
        }

        private void OpenTestInfoForm(object sender, EventArgs e)
        {
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
            var a = 1;
        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            //Tetkik İstem Panelinden yonetılecek!
            //base.AfterContextSavedScript(transDef);

            ////SITEID ye bagli kontrol yapiliyordu, kaldirildi. Istenirse baska sistem parametresine baglanabilir.
            //    this.PrintRadiologyRequestDescriptonReport();
            var a = 1;
        }


        public void PrintRadiologyRequestDescriptonReport()
        {
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
            var a = 1;
        }

        public void PrintRadiologyRequestDescriptonReport(RadiologyTest radTest)
        {
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
            var a = 1;
        }

        #endregion RadiologyRequestForm_ClientSideMethods
    }
}