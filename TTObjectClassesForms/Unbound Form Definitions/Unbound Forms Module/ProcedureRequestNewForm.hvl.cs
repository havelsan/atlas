
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class ProcedureRequestNewForm : TTUnboundForm
    {
        protected ITTButton ttbutton1;
        protected ITTTabControl ProcedureTabControl;
        override protected void InitializeControls()
        {
            ttbutton1 = (ITTButton)AddControl(new Guid("74809bc8-41d7-41e3-a55a-539b8cccfd08"));
            ProcedureTabControl = (ITTTabControl)AddControl(new Guid("7bf5a2f3-068b-4e81-aba3-a67edf770744"));
            base.InitializeControls();
        }

        public ProcedureRequestNewForm() : base("ProcedureRequestNewForm")
        {
        }

        protected ProcedureRequestNewForm(string formDefName) : base(formDefName)
        {
        }

#region ProcedureRequestNewForm_Methods
        public void GenerateForms()
        {
            TTObjectContext thisContext = new TTObjectContext(true);
            BindingList<ProcedureRequestFormDefinition> formList = ProcedureRequestFormDefinition.GetForms(thisContext,"");
            for(int i = 0; i < formList.Count;i++) //From Tab
            {
                TTTabPage tabPage = new TTTabPage();
                tabPage.Name = formList[i].Name;
                tabPage.Text = formList[i].Name;
                tabPage.Tag = formList[i];

                TTTabControl tabControl = new TTTabControl();
                tabControl.Width = 700;
                tabControl.Height = 400;

                for (int j = 0; j < formList[i].FormCategory.Count; j++) //Category Tab
                {
                    TTTabPage categoryTab = new TTTabPage();
                    categoryTab.Name = formList[i].FormCategory[j].CategoryName;
                    categoryTab.Text = formList[i].FormCategory[j].CategoryName;
                    categoryTab.Tag = formList[i].FormCategory[j];

                    TTListView listView = new TTListView();
                    TTListViewColumn listViewColumn = new TTListViewColumn();
                    listViewColumn.Text = "Testler";
                    listViewColumn.Width = -1;
                    listView.Columns.Add(listViewColumn);

                    listView.Name = "ListView";
                    listView.View = View.List;
                    listView.CheckBoxes = true;
                    listView.FullRowSelect = true;
                    listView.Dock = DockStyle.Fill;
                    listView.BorderStyle = BorderStyle.None;
       
                    listView.ItemCheck += new ItemCheckEventHandler(BoundedTestController); //Patienta bağlı kontroller eklenmeli

                    for(int k = 0; k < formList[i].FormCategory[j].FormDetail.Count; k++) //Items
                    {
                        TTListViewItem item = new TTListViewItem();
                        item.Name = formList[i].FormCategory[j].FormDetail[k].ProcedureDefinition.Name;
                        item.Text = formList[i].FormCategory[j].FormDetail[k].ProcedureDefinition.Code + " - " + formList[i].FormCategory[j].FormDetail[k].ProcedureDefinition.Name;
                        item.Font = new Font("Tahoma", 8);
                        item.Tag = formList[i].FormCategory[j].FormDetail[k].ProcedureDefinition.ObjectID;

                        listView.Items.Add(item);
                    }
                    categoryTab.Controls.Add(listView);
                    tabControl.Controls.Add(categoryTab);

                }

                tabPage.Controls.Add(tabControl);
                //this.GenerateCategory(thisContext, formList[i]);

                ProcedureTabControl.TabPages.Add(tabPage);
            }



        }
        
#endregion ProcedureRequestNewForm_Methods
    }
}