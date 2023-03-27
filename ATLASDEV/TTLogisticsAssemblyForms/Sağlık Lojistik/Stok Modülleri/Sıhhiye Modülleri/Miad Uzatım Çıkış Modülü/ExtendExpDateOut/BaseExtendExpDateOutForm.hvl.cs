
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
    /// Miad Uzatım (Çıkış)
    /// </summary>
    public partial class BaseExtendExpDateOutForm : BaseChattelDocumentForm
    {
    /// <summary>
    /// Miad Güncelleme İşlemi (Çıkış)
    /// </summary>
        protected TTObjectClasses.ExtendExpDateOut _ExtendExpDateOut
        {
            get { return (TTObjectClasses.ExtendExpDateOut)_ttObject; }
        }

        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelSupplier;
        protected ITTObjectListBox Supplier;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ExtendExpDateOutDetails;
        protected ITTListBoxColumn MaterialExtendExpDateOutDetail;
        protected ITTDateTimePickerColumn OutExpirationDateExtendExpDateOutDetail;
        protected ITTTextBoxColumn AmountExtendExpDateOutDetail;
        protected ITTEnumComboBoxColumn StatusExtendExpDateOutDetail;
        override protected void InitializeControls()
        {
            labelStore = (ITTLabel)AddControl(new Guid("497af15b-d709-4cff-83ca-eff9aef8c9e7"));
            Store = (ITTObjectListBox)AddControl(new Guid("66a04846-455c-47d2-93ce-8d0b782be6ed"));
            labelSupplier = (ITTLabel)AddControl(new Guid("21e3750b-db12-4bd2-91c5-90a67e970a9b"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("a66e1629-04af-4407-beb7-508bf014e745"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("451f64a4-2c2b-4766-8966-f2a68e43494d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("b9c1719a-c5e7-44d1-a854-3f1d5adf7a2f"));
            ExtendExpDateOutDetails = (ITTGrid)AddControl(new Guid("8fb8f977-7a0f-4574-9c22-001ba84e5d01"));
            MaterialExtendExpDateOutDetail = (ITTListBoxColumn)AddControl(new Guid("bfb2d159-6ab6-4522-9694-814e1906472f"));
            OutExpirationDateExtendExpDateOutDetail = (ITTDateTimePickerColumn)AddControl(new Guid("dcb626b3-85db-4cb2-994d-c047dff14aa4"));
            AmountExtendExpDateOutDetail = (ITTTextBoxColumn)AddControl(new Guid("dd0159c6-6a33-481a-b8d3-88965c3f98cd"));
            StatusExtendExpDateOutDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("bbd636b3-7461-475a-a0f6-54ca3ae79aac"));
            base.InitializeControls();
        }

        public BaseExtendExpDateOutForm() : base("EXTENDEXPDATEOUT", "BaseExtendExpDateOutForm")
        {
        }

        protected BaseExtendExpDateOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}