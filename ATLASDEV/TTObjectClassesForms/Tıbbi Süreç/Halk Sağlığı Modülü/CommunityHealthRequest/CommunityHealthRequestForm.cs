
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
    /// Halk Sağlığı İstek Formu
    /// </summary>
    public partial class CommunityHealthRequestForm : ActionForm
    {
        override protected void BindControlEvents()
        {
            btnCreateTemplate.Click += new TTControlEventDelegate(btnCreateTemplate_Click);
            btnEditTemplate.Click += new TTControlEventDelegate(btnEditTemplate_Click);
            btnSelectTemplate.Click += new TTControlEventDelegate(btnSelectTemplate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnCreateTemplate.Click -= new TTControlEventDelegate(btnCreateTemplate_Click);
            btnEditTemplate.Click -= new TTControlEventDelegate(btnEditTemplate_Click);
            btnSelectTemplate.Click -= new TTControlEventDelegate(btnSelectTemplate_Click);
            base.UnBindControlEvents();
        }

        private void btnCreateTemplate_Click()
        {
#region CommunityHealthRequestForm_btnCreateTemplate_Click
   // if (this._CommunityHealthRequest.CommunityHealthRequestTemplate == null)
            //            {
            try
            {
                string description = InputForm.GetText("Şablon Adı");
                if (!string.IsNullOrEmpty(description))
                {
                    TTObjectContext objectContext = new TTObjectContext(false);

                    CommunityHealthTemplate template = new CommunityHealthTemplate(objectContext);
                    foreach (TabPage page in this.tabTetkik.TabPages)
                    {
                        foreach (Control control in page.Controls)
                        {
                            if (control is ListView)
                            {
                                ListView lv = (ListView)control;
                                template.Name = description;

                                foreach (ListViewItem lvItem in lv.CheckedItems)
                                {
                                    if (lvItem.Tag is Guid)
                                    {
                                        CommunityHealthTestDefinition testDef = (CommunityHealthTestDefinition)objectContext.GetObject(new Guid(lvItem.Tag.ToString()), "CommunityHealthTestDefinition");
                                        CommunityHealthTemlateDetail templateDetail = new CommunityHealthTemlateDetail(objectContext);
                                        templateDetail.ProcedureObject = testDef;
                                        template.Details.Add(templateDetail);
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
            //            }
#endregion CommunityHealthRequestForm_btnCreateTemplate_Click
        }

        private void btnEditTemplate_Click()
        {
#region CommunityHealthRequestForm_btnEditTemplate_Click
   TTObjectContext objectContext = new TTObjectContext(false);
            IList templates = objectContext.QueryObjects("COMMUNITYHEALTHTEMPLATE");
            MultiSelectForm pForm = new MultiSelectForm();
            foreach (CommunityHealthTemplate template in templates)
                pForm.AddMSItem(template.Name, template.ObjectID.ToString(), template);

            string sKey = pForm.GetMSItem(this, "Şablon Seçiniz.", false, false, false, false, true, false);
            if (!String.IsNullOrEmpty(sKey))
            {
                CommunityHealthTemplate selectedTemplate = (CommunityHealthTemplate)pForm.MSSelectedItemObject;
                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["CommunityHealthTemplateDefinitionList"]);
                frm.ShowEdit(this.FindForm(), TTObjectDefManager.Instance.ListDefs["CommunityHealthTemplateDefinitionList"], selectedTemplate);
            }
#endregion CommunityHealthRequestForm_btnEditTemplate_Click
        }

        private void btnSelectTemplate_Click()
        {
#region CommunityHealthRequestForm_btnSelectTemplate_Click
   TTObjectContext objectContext = new TTObjectContext(true);
            IList templates = objectContext.QueryObjects("COMMUNITYHEALTHTEMPLATE");
            
            MultiSelectForm pForm = new MultiSelectForm();
            foreach (CommunityHealthTemplate template in templates)
            {
                pForm.AddMSItem(template.Name, template.ObjectID.ToString(), template);
            }
            string sKey = pForm.GetMSItem(this, "Şablon Seçiniz.", false, false, false, false, true, false);
            if (!String.IsNullOrEmpty(sKey))
            {
                CommunityHealthTemplate selectedTemplate = (CommunityHealthTemplate)pForm.MSSelectedItemObject;

                foreach (CommunityHealthTemlateDetail detail in selectedTemplate.Details)
                {
                    foreach (TabPage page in this.tabTetkik.TabPages)
                    {
                        foreach (Control control in page.Controls)
                        {
                            if (control is ListView)
                            {
                                ListView lv = (ListView)control;
                                foreach (ListViewItem test in lv.Items)
                                {
                                    //LaboratoryTestDefinition labReqTestDef = (LaboratoryTestDefinition)objectContext.GetObject(new Guid(test.Tag.ToString()), "LaboratoryTestDefinition");
                                    //if (!otherTest.Checked && (detail.LaboratoryTestDefinition.ObjectID == labReqTestDef.ObjectID))
                                    //                                        {
                                    if (test.Tag.ToString() == detail.ProcedureObject.ObjectID.ToString())
                                    {
                                        test.Checked = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
#endregion CommunityHealthRequestForm_btnSelectTemplate_Click
        }

        protected override void PreScript()
        {
#region CommunityHealthRequestForm_PreScript
    base.PreScript();
            this.GenerateTabs();
            if(this._CommunityHealthRequest.CurrentStateDefID != CommunityHealthRequest.States.New)
            {
                btnSelectTemplate.Visible = false;
                btnCreateTemplate.Visible = false;
                btnEditTemplate.Visible = false;   
                this.NoCharge.Enabled = false; 
            }
#endregion CommunityHealthRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CommunityHealthRequestForm_PostScript
    base.PostScript(transDef);
            SetCheckedItemsAsRequestedProcedures();
            this._CommunityHealthRequest.WorkListDescription = this._CommunityHealthRequest.CommunityHealthPayer.Name;
#endregion CommunityHealthRequestForm_PostScript

            }
            
#region CommunityHealthRequestForm_Methods
        /// <summary>
        /// Tanımlardan alarak  Testleri kısmının düzenli olarak (ilgili sekmeler halinde) oluşturulmasını sağlar.
        /// </summary>
        /// 
        private Font selectedItemFont = new Font("Tahoma", 8);
        private Color itemBackColor = Color.FromArgb(191, 219, 255);
        
        public List<Guid> tempTestDefGuidList = new List<Guid>();
        private  List<Guid> _oldTestDefGuidList ;
        public  List<Guid> oldTestDefGuidList
        {
            get{
                _oldTestDefGuidList = new List<Guid>();
                foreach (CommunityHealthProcedure  procedure in this._CommunityHealthRequest.Procedures)
                {
                    if(!_oldTestDefGuidList.Contains(procedure.ProcedureObject.ObjectID))
                        _oldTestDefGuidList.Add(procedure.ProcedureObject.ObjectID);
                }
                return _oldTestDefGuidList;
            }
            set{}
        }
        
        public void GenerateTabs()
        {
            //bool isAlternatingItem = false;
            TTObjectContext thisContext = this._CommunityHealthRequest.ObjectContext;

            BindingList<CommunityHealthTestCategoryDefinition> liste = CommunityHealthTestCategoryDefinition.GetCommunityHealthTestCategory(thisContext, "  ORDER BY TABORDER");

            if (liste.Count > 0)
            {
                foreach (CommunityHealthTestCategoryDefinition tabDef in liste)
                {
                    TTTabPage tabPage = new TTTabPage();
                    tabPage.Name = tabDef.Name;
                    tabPage.Text = tabDef.Name;
                    tabPage.Tag = tabDef.ObjectID;

                    TTListView listView = new TTListView();
                    TTListViewColumn listViewColumn = new TTListViewColumn();
                    listViewColumn.Text = "Testler";
                    listViewColumn.Width = -1;
                    listView.Columns.Add(listViewColumn);

                    listView.Name = "ListView";
                    listView.View = View.List;
                    listView.CheckBoxes = true;
                    listView.FullRowSelect = true;
                    //listView.Dock = DockStyle.Fill;
                    //listView.BorderStyle = BorderStyle.None;
                    listView.ItemCheck += new ItemCheckEventHandler(AddCheckedItemToTempList);
                   

                    BindingList<CommunityHealthTestDefinition> tests = CommunityHealthTestDefinition.GetByTestCategory(thisContext, tabDef.ObjectID);
                    foreach (CommunityHealthTestDefinition test in tests)
                    {
                        
                        // isAlternatingItem = !isAlternatingItem;
                        TTListViewItem item = new TTListViewItem();
                        item.Name = test.Name;
                        item.Text = test.Name;
                        item.Font = new Font("Tahoma", 8);
                        item.Tag = test.ObjectID;
                        if (this._CommunityHealthRequest.Procedures.Count > 0) //already has Procedures
                        {
                            foreach (CommunityHealthProcedure Proc in this._CommunityHealthRequest.Procedures)
                            {
                                if (test.ObjectID.ToString() == ((CommunityHealthTestDefinition)Proc.ProcedureObject).ObjectID.ToString())
                                {
                                    item.Checked = true;

                                }
                            }

                        }

                        listView.Items.Add(item);
                    }
                    tabPage.Controls.Add(listView);
                    tabPage.Enabled = this._CommunityHealthRequest.CurrentStateDefID == CommunityHealthRequest.States.New;
                    tabTetkik.TabPages.Add(tabPage);
                }
            }
            
        }
        
        
        private void AddCheckedItemToTempList(object sender, ItemCheckEventArgs e)
        {
            CommunityHealthTestDefinition reqTestDef = null;
            ListView lv = sender as ListView;
            ListViewItem selectedTest = (ListViewItem)lv.Items[e.Index];
            Guid objId = (Guid)selectedTest.Tag;
            TTObjectContext thisContext = this._CommunityHealthRequest.ObjectContext;
            reqTestDef = (CommunityHealthTestDefinition)thisContext.GetObject(objId, "CommunityHealthTestDefinition");

            if (e.NewValue == CheckState.Unchecked)
            {
                if (tempTestDefGuidList.Contains(reqTestDef.ObjectID))
                    tempTestDefGuidList.Remove(reqTestDef.ObjectID);
            }
            else
            {
                if (!tempTestDefGuidList.Contains(reqTestDef.ObjectID) && e.NewValue == CheckState.Checked)
                {
                    tempTestDefGuidList.Add(reqTestDef.ObjectID);
                    selectedTest.BackColor = itemBackColor;
                    selectedTest.Font = selectedItemFont;
                }
            }
        }
        
        /// <summary>
        /// İşaretlenmiş testlerin Halk Sağlığı tetkik istek olarak eklenmesini sağlar.
        /// </summary>
        private void SetCheckedItemsAsRequestedProcedures()
        {
            TTObjectContext thisContext = this._CommunityHealthRequest.ObjectContext;
            //            List<Guid> oldTestDefGuidList = new List<Guid>();
            //            foreach (CommunityHealthProcedure  procedure in this._CommunityHealthRequest.Procedures)
            //            {
            //                if(!oldTestDefGuidList.Contains(procedure.ProcedureObject.ObjectID))
            //                    oldTestDefGuidList.Add(procedure.ProcedureObject.ObjectID);
            //            }
            
            foreach (Guid testDefGuid in tempTestDefGuidList)
            {
                if(!oldTestDefGuidList.Contains(testDefGuid))
                {
                    CommunityHealthProcedure newProcedure = new CommunityHealthProcedure(thisContext);
                    BindingList<CommunityHealthTestDefinition> testDefList = CommunityHealthTestDefinition.GetByObjectID(thisContext, testDefGuid, "");
                    if (testDefList.Count > 0)
                    {
                        newProcedure.ProcedureObject = testDefList[0];
                        newProcedure.Amount = 1;
                        newProcedure.ActionDate = DateTime.Now;

                        if (!this._CommunityHealthRequest.Procedures.Contains(newProcedure))
                            this._CommunityHealthRequest.Procedures.Add(newProcedure);
                    }
                }
            }
        }
        
#endregion CommunityHealthRequestForm_Methods
    }
}