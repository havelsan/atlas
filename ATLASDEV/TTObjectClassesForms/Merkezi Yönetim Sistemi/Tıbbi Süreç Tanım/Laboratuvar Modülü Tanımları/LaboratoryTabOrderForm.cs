
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
    public partial class LaboratoryTabOrderForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnDown.Click += new TTControlEventDelegate(btnDown_Click);
            btnUp.Click += new TTControlEventDelegate(btnUp_Click);
            TabsListView.SelectedIndexChanged += new TTControlEventDelegate(TabsListView_SelectedIndexChanged);
            TabList.SelectedObjectChanged += new TTControlEventDelegate(TabList_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnDown.Click -= new TTControlEventDelegate(btnDown_Click);
            btnUp.Click -= new TTControlEventDelegate(btnUp_Click);
            TabsListView.SelectedIndexChanged -= new TTControlEventDelegate(TabsListView_SelectedIndexChanged);
            TabList.SelectedObjectChanged -= new TTControlEventDelegate(TabList_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void btnDown_Click()
        {
#region LaboratoryTabOrderForm_btnDown_Click
   ListViewItem itemToBeMoved = (ListViewItem)TabsListView.SelectedItems[0];
            MoveListViewItem(itemToBeMoved.Index, itemToBeMoved, MoveDirection.Down);
#endregion LaboratoryTabOrderForm_btnDown_Click
        }

        private void btnUp_Click()
        {
#region LaboratoryTabOrderForm_btnUp_Click
   ListViewItem itemToBeMoved = (ListViewItem)TabsListView.SelectedItems[0];
            MoveListViewItem(itemToBeMoved.Index, itemToBeMoved, MoveDirection.Up);
#endregion LaboratoryTabOrderForm_btnUp_Click
        }

        private void TabsListView_SelectedIndexChanged()
        {
#region LaboratoryTabOrderForm_TabsListView_SelectedIndexChanged
   if(TabsListView.SelectedItems.Count == 0)
                return;
            int numberOfItems = TabsListView.Items.Count;
            ListViewItem selectedItem = (ListViewItem)TabsListView.SelectedItems[0];
            
            btnUp.ReadOnly = btnDown.ReadOnly = false;
            if(selectedItem.Index < 1)
                btnUp.ReadOnly = true;
            else if(selectedItem.Index > numberOfItems - 2)
                btnDown.ReadOnly = true;
#endregion LaboratoryTabOrderForm_TabsListView_SelectedIndexChanged
        }

        private void TabList_SelectedObjectChanged()
        {
#region LaboratoryTabOrderForm_TabList_SelectedObjectChanged
   LaboratoryRequestFormTabDefinition selectedTabDefinition;
            TabsListView.Items.Clear();
            if (this.TabList.SelectedObject != null)
            {               
                selectedTabDefinition = (LaboratoryRequestFormTabDefinition)this.TabList.SelectedObject;
                
                ListLaboratoryTest(selectedTabDefinition);
                ReOrderListViewTestOrders((TTListView)TabsListView);
            }
#endregion LaboratoryTabOrderForm_TabList_SelectedObjectChanged
        }

#region LaboratoryTabOrderForm_Methods
        private BindingList<LaboratoryTabNamesGrid> grids;
        private TTObjectContext objectContext;
        
        public enum MoveDirection : int
        {
            Up = 0,
            Down = 1
        }
        
        private void MoveListViewItem(int itemIndex, ListViewItem itemToBeMoved, MoveDirection direction)
        {
            int newIndex = 0;
            TabsListView.Items.Remove(itemToBeMoved);
            switch(direction)
            {
                case MoveDirection.Up:
                    newIndex = itemIndex - 1;
                    break;
                case MoveDirection.Down:
                    newIndex = itemIndex + 1;
                    break;
            }
            TabsListView.Items.Insert(newIndex, itemToBeMoved);
            ReOrderListViewTestOrders((TTListView)TabsListView);
        }
        
        private void ListLaboratoryTest(LaboratoryRequestFormTabDefinition selectedTabDefinition)
        {
            objectContext = new TTObjectContext(false);
            grids = LaboratoryTabNamesGrid.GetByTabName(objectContext, selectedTabDefinition.ObjectID.ToString());
            
            foreach (LaboratoryTabNamesGrid tabGrid in grids)
            {
                TTListViewItem item = new TTListViewItem();
                item.Name = tabGrid.LaboratoryTestDefinition.Name;
                item.Text = tabGrid.LaboratoryTestDefinition.Name;;
                //item.Font = new Font("Tahoma", 8);
                item.ForeColor = Color.Black;
                item.Tag = tabGrid;
                
                TTListViewSubItem subitemName = new TTListViewSubItem();
                item.SubItems.Add(subitemName);
                TabsListView.Items.Add(item);
            }
        }
        
        private void ReOrderListViewTestOrders(TTListView tabsListView)
        {
            int order = 0;
            TTListViewSubItem subItem;
            
            foreach (TTListViewItem item in tabsListView.Items)
            {
                order++;
                subItem = (TTListViewSubItem)item.SubItems[1];
                subItem.Text = order.ToString();
                subItem.Tag = order;
                LaboratoryTabNamesGrid grid = (LaboratoryTabNamesGrid)item.Tag;
                grid.TabOrder = order;
            }
            objectContext.Save();
        }
        
        private void SaveOrders()
        {
            foreach(TTListViewItem item in TabsListView.Items)
            {
                
                
            }
            
        }
        
#endregion LaboratoryTabOrderForm_Methods
    }
}