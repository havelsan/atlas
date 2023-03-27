
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
    /// Bağlı Birlik Demirbaş Detayı Gönderme
    /// </summary>
    public partial class SendDetailDependentStoreForm : TTForm
    {
    /// <summary>
    /// Bağlı Birlik Demirbaş Detayı Gönderme
    /// </summary>
        protected TTObjectClasses.SendDetailDependentStore _SendDetailDependentStore
        {
            get { return (TTObjectClasses.SendDetailDependentStore)_ttObject; }
        }

        protected ITTButton cmdList;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTGrid SendDetailFixedAssets;
        protected ITTTextBoxColumn FixedAssetNo;
        protected ITTTextBoxColumn Description;
        protected ITTTextBoxColumn Mark;
        protected ITTTextBoxColumn Model;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            cmdList = (ITTButton)AddControl(new Guid("49fb64fa-ece7-4b28-b18c-ed387bfa00da"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("ac08b5d0-7233-4db6-a7df-f8d671453255"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("7caf2ee6-01b2-4d68-9841-bd76615b553d"));
            labelStore = (ITTLabel)AddControl(new Guid("3ecb383d-892b-443a-b530-2f35c802d9fc"));
            Store = (ITTObjectListBox)AddControl(new Guid("0942abcf-a8fb-47a1-a288-2ae97f0a0731"));
            SendDetailFixedAssets = (ITTGrid)AddControl(new Guid("30cf5cf9-b335-4d05-91c7-9cf241c575a1"));
            FixedAssetNo = (ITTTextBoxColumn)AddControl(new Guid("a5970c8f-b6f9-4745-9124-07208f6af6c2"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("6a9c1889-4b78-44f9-951d-a48b0ac2517c"));
            Mark = (ITTTextBoxColumn)AddControl(new Guid("350dc219-6e1f-41c2-a493-dce3c74ebdcb"));
            Model = (ITTTextBoxColumn)AddControl(new Guid("5668636f-e741-434d-8578-2ebccc21dd1a"));
            labelID = (ITTLabel)AddControl(new Guid("b148559f-48e1-4758-b668-84b1109bfabf"));
            ID = (ITTTextBox)AddControl(new Guid("ed973b98-f46d-4490-a844-916a01ef6b65"));
            labelActionDate = (ITTLabel)AddControl(new Guid("01b71262-d73b-4e9e-8b19-2f788eb1dfc2"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e12ad2f3-e137-4e47-be6c-8681fa6754b0"));
            base.InitializeControls();
        }

        public SendDetailDependentStoreForm() : base("SENDDETAILDEPENDENTSTORE", "SendDetailDependentStoreForm")
        {
        }

        protected SendDetailDependentStoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}