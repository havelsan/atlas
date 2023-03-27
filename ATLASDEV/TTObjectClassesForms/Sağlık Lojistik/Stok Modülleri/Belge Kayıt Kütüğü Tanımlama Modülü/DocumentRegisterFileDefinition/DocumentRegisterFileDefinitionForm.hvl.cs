
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
    /// Belge Kayıt Kütüğü Tanımları
    /// </summary>
    public partial class DocumentRegisterFileDefinitionForm : TTForm
    {
    /// <summary>
    /// Belge Kayıt Kütüğü Tanımları
    /// </summary>
        protected TTObjectClasses.DocumentRegisterFileDefinition _DocumentRegisterFileDefinition
        {
            get { return (TTObjectClasses.DocumentRegisterFileDefinition)_ttObject; }
        }

        protected ITTButton ttbutton5;
        protected ITTLabel labelSequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTButton ttbutton3;
        protected ITTLabel labelStore;
        protected ITTLabel labelRegistrationNumber;
        protected ITTButton ttbutton6;
        protected ITTObjectListBox DestinationStore;
        protected ITTButton ttbutton2;
        protected ITTTextBox StockActionID;
        protected ITTTextBox SequenceNumber;
        protected ITTButton ttbutton1;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTLabel labelStockActionID;
        protected ITTButton ttbutton4;
        override protected void InitializeControls()
        {
            ttbutton5 = (ITTButton)AddControl(new Guid("8716f561-6977-48aa-9881-0b7d9db4a462"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("83c80845-fb26-4278-b708-39518887d807"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("a953abad-5805-4cf9-be8e-42c99d794a22"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("c036b7c1-9222-4f03-a3bd-43bd5b55e5b5"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("f80ca949-08c0-4126-8b48-44ef1f5a8548"));
            ttbutton3 = (ITTButton)AddControl(new Guid("bf5ca1bd-cf91-4570-870d-483c27d87767"));
            labelStore = (ITTLabel)AddControl(new Guid("f305d305-29b8-4d91-a063-50041ee0c99c"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("5c0bf62a-0e51-488f-8aee-7ac274c79de9"));
            ttbutton6 = (ITTButton)AddControl(new Guid("50f0f833-20ba-4ca1-92e9-866e919f9c9f"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("e84a7f4d-98f3-4f0d-a96d-8758e9f9a6d8"));
            ttbutton2 = (ITTButton)AddControl(new Guid("1042c76b-10b4-4d45-af95-8c620063df2b"));
            StockActionID = (ITTTextBox)AddControl(new Guid("b50eeee0-78d1-491f-9f89-98b69396f78e"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("57f037e1-af4b-475e-964e-a626dea9c6fa"));
            ttbutton1 = (ITTButton)AddControl(new Guid("6a4e8585-99a6-4b84-a214-b40ea10b3624"));
            Store = (ITTObjectListBox)AddControl(new Guid("2ac95ca5-82e6-499a-92b8-c141a66ec1ed"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("f4e57bd8-79fe-44e3-82e1-d4b42f2632e5"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("32299aad-9630-4a91-93db-ed5700eae655"));
            ttbutton4 = (ITTButton)AddControl(new Guid("534294f7-ca61-4293-be91-f75c9ee1794d"));
            base.InitializeControls();
        }

        public DocumentRegisterFileDefinitionForm() : base("DOCUMENTREGISTERFILEDEFINITION", "DocumentRegisterFileDefinitionForm")
        {
        }

        protected DocumentRegisterFileDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}