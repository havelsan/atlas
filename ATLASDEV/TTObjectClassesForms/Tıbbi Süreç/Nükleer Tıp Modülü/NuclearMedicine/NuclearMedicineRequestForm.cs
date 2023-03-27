
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
    /// Tetkik İstek
    /// </summary>
    public partial class NuclearMedicineRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
            #region NuclearMedicineRequestForm_PreScript
            //Tetkik İstem tarafından yonetılecek!
            //base.PreScript();

            //        for (int i = 0; i < (this.pnlButtons.Controls.Count); i++)
            //        {
            //            if (this.pnlButtons.Controls[i].Name.ToString() == "cmdOK")
            //            {
            //                this.pnlButtons.Controls[i].Visible = false;
            //            }
            //        }

            //        RequestedDoctor.SelectedObject = Common.CurrentUser.UserObject;
            //        this._NuclearMedicine.IsEmergency = false;
            //        if (!String.IsNullOrEmpty(this._NuclearMedicine.RequestCorrectionReason))
            //        {
            //            txtRequestCorrectionReason.Visible = true;
            //            lblRequestCorrectionReason.Visible = true;
            //        }
            //        this.GenerateNuclearMedicineTabs();
            var a = 1;
            #endregion NuclearMedicineRequestForm_PreScript

        }

        protected override void ClientSidePreScript()
        {
#region NuclearMedicineRequestForm_ClientSidePreScript
    //base.ClientSidePreScript();
#endregion NuclearMedicineRequestForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region NuclearMedicineRequestForm_PostScript
            //Tetkik İstem tarafından yonetılecek!
            //base.PostScript(transDef);
            //        this.SetCheckedItemsAsRequestedProcedures(transDef);

            //        if (this._NuclearMedicine.NuclearMedicineTests.Count == 0)
            //        {
            //            String message = SystemMessage.GetMessage(198);
            //            throw new TTUtils.TTException(message);
            //        }
            var a = 1;
            #endregion NuclearMedicineRequestForm_PostScript

        }

        #region NuclearMedicineRequestForm_Methods
        public void GenerateNuclearMedicineTabs()
        {
            //Tetkik İstem tarafından yonetılecek!
            //bool isAlternatingItem = false;
            //BindingList<NucMedTestGroupDef> liste = NucMedTestGroupDef.GetTestGroups(this._NuclearMedicine.ObjectContext);
            //foreach (NucMedTestGroupDef tabDef in liste)
            //{
            //    TTTabPage tabPage = new TTTabPage();
            //    tabPage.Name = tabDef.Name;
            //    tabPage.Text = tabDef.Name;
            //    TTListView listView = new TTListView();
            //    TTListViewColumn listViewColumn = new TTListViewColumn();
            //    listViewColumn.Text = "Testler";
            //    listViewColumn.Width = -1;
            //    listView.Columns.Add(listViewColumn);
            //    listView.Name = "ListView";
            //    listView.View = View.List;
            //    listView.CheckBoxes = true;
            //    listView.FullRowSelect = true;
            //    //listView.Dock = DockStyle.Fill;
            //    //listView.BorderStyle = BorderStyle.None;
            //    listView.ItemCheck += new ItemCheckEventHandler(this.CheckRequestOnItemCheck);
            //    BindingList<NucMedTabNamesGrid> grids = NucMedTabNamesGrid.GetByTabNames(this._NuclearMedicine.ObjectContext, tabDef.ObjectID.ToString());

            //    foreach (NucMedTabNamesGrid tabGrid in grids)
            //    {
            //        isAlternatingItem = !isAlternatingItem;
            //        TTListViewItem item2 = new TTListViewItem();
            //        item2.Name = tabGrid.NuclearMedicineTest.Name;
            //        item2.Text = tabGrid.NuclearMedicineTest.Name;
            //        item2.Tag = tabGrid.NuclearMedicineTest;
            //        item2.Checked = this.CheckTestAlreadyRequested(tabGrid.NuclearMedicineTest);
            //        listView.Items.Add(item2);
            //    }
            //    tabPage.Controls.Add(listView);
            //    tabTetkik.TabPages.Add(tabPage);
            //}
            //this._NuclearMedicine.NuclearMedicineTests.DeleteChildren();
            //this._NuclearMedicine.NucMedTreatmentMats.DeleteChildren();
            var a = 1;
        }

        private bool CheckTestAlreadyRequested(NuclearMedicineTestDefinition nucMedTestDef)
        {
            //Tetkik İstem tarafından yonetılecek!
            //foreach (NuclearMedicineTest test in this._NuclearMedicine.NuclearMedicineTests)
            //    if (test.NuclearMedicineTestDef.ObjectID == nucMedTestDef.ObjectID)
            //        return true;
            return false;
        }

        private void CheckRequestOnItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Tetkik İstem tarafından yonetılecek!
            //if (e.NewValue == CheckState.Unchecked)
            //    return;

            //foreach (TabPage page in this.tabTetkik.TabPages)
            //{
            //    foreach (Control control in page.Controls)
            //    {
            //        if (control is TTListView)
            //        {
            //            TTListView lv = (TTListView)control;
            //            foreach (TTListViewItem lvItem in lv.CheckedItems)
            //            {
            //                lvItem.Checked = false;
            //            }
            //        }
            //    }
            //}

            var a = 1;
        }


        public void SetCheckedItemsAsRequestedProcedures(TTObjectStateTransitionDef transDef)
        {
            //Tetkik İstem tarafından yonetılecek!
            //if (transDef != null && (transDef.FromStateDefID == NuclearMedicine.States.Request || transDef.FromStateDefID == NuclearMedicine.States.RequestAcception))
            //{
            //    foreach (TabPage page in this.tabTetkik.TabPages)
            //    {
            //        foreach (Control control in page.Controls)
            //        {
            //            if (control is TTListView)
            //            {
            //                TTListView lv = (TTListView)control;
            //                foreach (TTListViewItem lvItem in lv.CheckedItems)
            //                {
            //                    if (lvItem.Tag is NuclearMedicineTestDefinition)
            //                    {
            //                        NuclearMedicineTest nucMedTest = new NuclearMedicineTest(this._NuclearMedicine.ObjectContext); ;
            //                        if (this._NuclearMedicine.NuclearMedicineTests.Count <= 0)
            //                        {
            //                            nucMedTest.NuclearMedicine = this._NuclearMedicine;
            //                        }

            //                        NuclearMedicineTestDefinition testDef = (NuclearMedicineTestDefinition)lvItem.Tag;
            //                        this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject = testDef;

            //                        foreach (NuclearMedicineGridMaterialDefinition defMaterialGrid in testDef.Materials)
            //                        {
            //                            NucMedTreatmentMat nucMaterial = new NucMedTreatmentMat(this._NuclearMedicine.ObjectContext);
            //                            nucMaterial.Amount = 1;
            //                            nucMaterial.Material = defMaterialGrid.Material;
            //                            nucMaterial.EpisodeAction = this._EpisodeAction;
            //                            nucMedTest.NuclearMedicine.NucMedTreatmentMats.Add(nucMaterial);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            var a= 1;
        }

        #endregion NuclearMedicineRequestForm_Methods
    }
}