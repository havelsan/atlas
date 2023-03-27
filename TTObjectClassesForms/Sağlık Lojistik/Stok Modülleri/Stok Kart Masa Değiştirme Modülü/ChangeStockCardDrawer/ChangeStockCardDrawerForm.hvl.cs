
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
    /// <summary>
    /// Stok Kartı Masa Değiştirme
    /// </summary>
    public partial class ChangeStockCardDrawerForm : TTForm
    {
    /// <summary>
    /// Stok Kart Masa Değiştirme
    /// </summary>
        protected TTObjectClasses.ChangeStockCardDrawer _ChangeStockCardDrawer
        {
            get { return (TTObjectClasses.ChangeStockCardDrawer)_ttObject; }
        }

        protected ITTLabel labelAccountingTerm;
        protected ITTObjectListBox AccountingTerm;
        protected ITTLabel labelOldResCardDrawer;
        protected ITTObjectListBox OldResCardDrawer;
        protected ITTLabel labelNewResCardDrawer;
        protected ITTObjectListBox NewResCardDrawer;
        protected ITTLabel labelStockCard;
        protected ITTObjectListBox StockCard;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelAccountingTerm = (ITTLabel)AddControl(new Guid("35dd45a8-5ddc-4508-86e7-5093af57f632"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("86aa2ebf-3edc-40ce-89e5-bf804dca6948"));
            labelOldResCardDrawer = (ITTLabel)AddControl(new Guid("dfd25906-ee84-46db-a483-de23f8257dce"));
            OldResCardDrawer = (ITTObjectListBox)AddControl(new Guid("e714f335-5519-4efd-81de-4efe9c5fda6b"));
            labelNewResCardDrawer = (ITTLabel)AddControl(new Guid("f68c600e-021f-4e6d-b3ce-414d298deef5"));
            NewResCardDrawer = (ITTObjectListBox)AddControl(new Guid("4dc40fbe-8f53-4174-8def-29bc58e1295f"));
            labelStockCard = (ITTLabel)AddControl(new Guid("1ff3f557-4769-40eb-9698-ea908670fe8f"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("21716faf-4057-46df-b5b9-4f9999013f3f"));
            labelID = (ITTLabel)AddControl(new Guid("cc94ce41-e355-4089-a189-d2e7c61da8cf"));
            ID = (ITTTextBox)AddControl(new Guid("24951c2b-c932-4074-aeb1-664d4f55c843"));
            labelActionDate = (ITTLabel)AddControl(new Guid("7ca0a749-164b-4c23-9e23-b86b1c54e414"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("2b2d271e-b3ec-4767-ba2b-fae3db3c77dd"));
            base.InitializeControls();
        }

        public ChangeStockCardDrawerForm() : base("CHANGESTOCKCARDDRAWER", "ChangeStockCardDrawerForm")
        {
        }

        protected ChangeStockCardDrawerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}