
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
    public partial class SearchDocumentRegistryForm : TTListForm
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
#region SearchDocumentRegistryForm_PreScript
    base.PreScript();
#endregion SearchDocumentRegistryForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region SearchDocumentRegistryForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            Dictionary<Guid, Accountancy> selectableAccountancies = new Dictionary<Guid, Accountancy>();
            if (TTUser.CurrentUser.IsSuperUser)
            {
                TTObjectContext ctx = new TTObjectContext(true);
                IList mainStores = ctx.QueryObjects(typeof(MainStoreDefinition).Name);
                foreach (MainStoreDefinition mainStoreDefinition in mainStores)
                    if (mainStoreDefinition.Accountancy != null)
                    if (selectableAccountancies.ContainsKey(mainStoreDefinition.Accountancy.ObjectID) == false)
                    selectableAccountancies.Add(mainStoreDefinition.Accountancy.ObjectID, mainStoreDefinition.Accountancy);
            }
            else
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                if (resUser != null)
                {
                    foreach (Store store in resUser.SelectedStores)
                    {
                        if (store is MainStoreDefinition)
                        {
                            MainStoreDefinition mainStoreDefinition = (MainStoreDefinition)store;
                            if (mainStoreDefinition.Accountancy != null)
                                if (selectableAccountancies.ContainsKey(mainStoreDefinition.Accountancy.ObjectID) == false)
                                selectableAccountancies.Add(mainStoreDefinition.Accountancy.ObjectID, mainStoreDefinition.Accountancy);
                        }
                    }
                }
            }

            if (selectableAccountancies.Count == 0)
                throw new Exception(SystemMessage.GetMessage(1238));

            Accountancy selectedAccountancy = null;
            if (selectableAccountancies.Count == 1)
            {
                foreach (Accountancy accountancy in selectableAccountancies.Values)
                    selectedAccountancy = accountancy;
            }
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();

                foreach (Accountancy accountancy in selectableAccountancies.Values)
                    multiSelectForm.AddMSItem(accountancy.Name, accountancy.ObjectID.ToString(), accountancy);
                multiSelectForm.GetMSItem(this, "Saymanlık seçiniz.", false, true, false, false, true, true);
                selectedAccountancy = (Accountancy)multiSelectForm.MSSelectedItemObject;
            }

            this.Accountancy.SelectedObject = selectedAccountancy;
            this.AccountingTerm.SelectedObject = selectedAccountancy.GetOpenAccountingTerm();

            this._ttList.GetListExpression("ACCOUNTINGTERM.ACCOUNTANCY = " + ConnectionManager.GuidToString(selectedAccountancy.ObjectID) + " AND ACCOUNTINGTERM = " + ConnectionManager.GuidToString(this.AccountingTerm.SelectedObject.ObjectID));
#endregion SearchDocumentRegistryForm_ClientSidePreScript

        }

#region SearchDocumentRegistryForm_Methods
        public SearchDocumentRegistryForm()
            : this(TTList.NewList("SearchDocumentRegistryListDefinition", null))
        {
        }

        protected override void OnDrawForm()
        {
            base.OnDrawForm();

            this.cmdSearch.Text = "Ara[F11]";
            this.cmdOK.Text = "Seç";
            this.Refresh();
        }

        protected override void OnClear()
        {
            FromStore.SelectedObject = null;
            RegistrationNumber.Text = string.Empty;
            SequenceNumber.Text = string.Empty;
            StartDate.NullableValue = null;
            EndDate.NullableValue = null;
        }

        protected override void OnSearch()
        {
           // Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (Common.CurrentUser.IsSuperUser == false)
                    if (Common.CurrentUser.HasRole(Common.SearchDocumentRegistryRoleID) == false)
                        throw new Exception(SystemMessage.GetMessage(1239));
                IList list = _ttList.GetObjectListByExpression(GetFilterExpression());

                if (this.SubjectComboBox.Items.Count < 0)
                {
                    this.SubjectComboBox.Items.Clear();
                }
                TTComboBoxItem comboFirstItem = new TTComboBoxItem(string.Empty, string.Empty);
                if (this.SubjectComboBox.Items.Count <= 0)
                {
                    this.SubjectComboBox.Items.Add(comboFirstItem);
                }
                List<string> l = new List<string>();

                if (this.SubjectComboBox.Items.Count <= 1)
                {
                    foreach (StockAction.SearchDocumentRegistryReportQuery_Class item in list)
                    {
                        if (item.TTObject != null)
                        {
                            if (l.Contains(item.TTObject.ObjectDef.DisplayText) == false)
                            {
                                TTComboBoxItem comboItem = new TTComboBoxItem(item.TTObject.ObjectDef.DisplayText, item.TTObject.ObjectDef.ID);
                                this.SubjectComboBox.Items.Add(comboItem);
                                l.Add(item.TTObject.ObjectDef.DisplayText);
                            }
                        }

                    }
                }

                dataGrid.DataSource = list;
                if (list.Count > 0)
                    dataGrid.Focus();
            }
            catch (Exception ex)
            {
                InfoBox.Alert(ex);
            }
            finally
            {
              //  Cursor.Current = Cursors.Default;
            }
        }

        protected override string GetFilterExpression()
        {
            List<string> filters = new List<string>();

            Accountancy fromAccountancy = Accountancy.SelectedObject as Accountancy;
            if (fromAccountancy != null)
                filters.Add("ACCOUNTINGTERM.ACCOUNTANCY = " + ConnectionManager.GuidToString(fromAccountancy.ObjectID));

            AccountingTerm accountingTerm = AccountingTerm.SelectedObject as AccountingTerm;
            if (accountingTerm != null)
                filters.Add("ACCOUNTINGTERM = " + ConnectionManager.GuidToString(accountingTerm.ObjectID));

            if (string.IsNullOrEmpty(RegistrationNumber.Text) == false)
                filters.Add("REGISTRATIONNUMBER = '" + RegistrationNumber.Text + "'");

            if (string.IsNullOrEmpty(SequenceNumber.Text) == false)
                filters.Add("SEQUENCENUMBER = '" + SequenceNumber.Text + "'");

            Store fromStore = FromStore.SelectedObject as Store;
            if (fromStore != null)
                filters.Add("(STORE = " + ConnectionManager.GuidToString(fromStore.ObjectID) + " OR DESTINATIONSTORE = " + ConnectionManager.GuidToString(fromStore.ObjectID) + ")");

            if (StartDate.NullableValue != null && EndDate.NullableValue != null)
            {
                DateTime startDate = (DateTime)StartDate.NullableValue;
                DateTime endDate = (DateTime)EndDate.NullableValue;
                filters.Add("TRANSACTIONDATE BETWEEN TODATE('" + startDate.Year + "/" + startDate.Month + "/" + startDate.Day + " 00:00:00') AND TODATE('" + endDate.Year + "/" + endDate.Month + "/" + endDate.Day + " 23:59:59')");
            }
            if (SubjectComboBox.SelectedItem != null)
            {
                if (string.IsNullOrEmpty(SubjectComboBox.SelectedItem.Value.ToString()) == false)
                    filters.Add("OBJECTDEFID = " + ConnectionManager.GuidToString(new Guid(SubjectComboBox.SelectedItem.Value.ToString())));
            }

            string filterExpression = null;
            if (filters.Count > 0)
            {
                int i = 0;
                foreach (string filter in filters)
                {
                    i++;
                    filterExpression += " " + filter;
                    if (filters.Count != i)
                        filterExpression += " AND ";
                }
            }

            return filterExpression;
        }
        
#endregion SearchDocumentRegistryForm_Methods
    }
}