
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
    public partial class SendDetailDependentStoreComForm : TTForm
    {
    /// <summary>
    /// Bağlı Birlik Demirbaş Detayı Gönderme
    /// </summary>
        protected TTObjectClasses.SendDetailDependentStore _SendDetailDependentStore
        {
            get { return (TTObjectClasses.SendDetailDependentStore)_ttObject; }
        }

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
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("81477b87-bef3-4d97-a0b5-b601d6dbfba8"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("9016a3df-fa8a-42c8-976e-d8873ae0d646"));
            labelStore = (ITTLabel)AddControl(new Guid("06fa1f59-2ca0-4e4c-b1ca-f19147d90208"));
            Store = (ITTObjectListBox)AddControl(new Guid("2acb62f3-032d-4bee-83ef-f559af695f9f"));
            SendDetailFixedAssets = (ITTGrid)AddControl(new Guid("9161f32d-9c5a-41f1-85e4-f8933b00e6f6"));
            FixedAssetNo = (ITTTextBoxColumn)AddControl(new Guid("54510240-c719-4248-91e6-44d92b720f7e"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("813946e2-af8e-429c-9150-5cf428d9be7f"));
            Mark = (ITTTextBoxColumn)AddControl(new Guid("d3763eb8-91ab-499b-aaa1-d6fce04439c7"));
            Model = (ITTTextBoxColumn)AddControl(new Guid("81046689-6a16-4e03-a9d1-d8b4daa329c0"));
            labelID = (ITTLabel)AddControl(new Guid("2bed4bdd-c08b-4197-9b98-70232ba69e9e"));
            ID = (ITTTextBox)AddControl(new Guid("ba1d5e37-22c9-451c-9e0d-47a0b13b9763"));
            labelActionDate = (ITTLabel)AddControl(new Guid("0ff179ac-cce5-4c0d-a037-98a396947a7a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("82afd64e-bd3a-44ed-bdb9-3a7e166100d1"));
            base.InitializeControls();
        }

        public SendDetailDependentStoreComForm() : base("SENDDETAILDEPENDENTSTORE", "SendDetailDependentStoreComForm")
        {
        }

        protected SendDetailDependentStoreComForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}