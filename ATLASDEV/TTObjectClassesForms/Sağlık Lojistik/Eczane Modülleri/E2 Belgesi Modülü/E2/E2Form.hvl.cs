
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
    /// E2 Belgesi
    /// </summary>
    public partial class E2Form : StockActionBaseForm
    {
    /// <summary>
    /// E2 Belgesi
    /// </summary>
        protected TTObjectClasses.E2 _E2
        {
            get { return (TTObjectClasses.E2)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ConsumableMaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn StockLevelType;
        protected ITTTextBox RegistrationNumber;
        protected ITTTextBox SequenceNumber;
        protected ITTTextBox ProcessNO;
        protected ITTTextBox Description;
        protected ITTLabel labelRegistrationNumber;
        protected ITTObjectListBox Store;
        protected ITTLabel labelSequenceNumber;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelDescription;
        protected ITTDateTimePicker ProcessDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelProcessNO;
        protected ITTLabel labelProcessDate;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("af0b44dd-9b7f-4baf-a875-1604238cf227"));
            ConsumableMaterialTabPage = (ITTTabPage)AddControl(new Guid("bf0baa97-f41f-4beb-bf44-053111e50255"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("682b66fb-1663-494e-a159-8581315090e9"));
            Material = (ITTListBoxColumn)AddControl(new Guid("7fd43bc3-3a92-49bf-bff1-1fd9a0fdd094"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("5bab2efe-b4f8-4f64-9524-1fd751cffeab"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("6242ddd7-8d5c-4272-9b03-102a585a9646"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("63a9caba-8204-45aa-a5c4-16ea070f40ba"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("b401457b-e6e0-4464-afd9-39a25034998b"));
            ProcessNO = (ITTTextBox)AddControl(new Guid("da7d304f-6bbc-4a6f-b04d-110325096555"));
            Description = (ITTTextBox)AddControl(new Guid("c2684104-35bb-4305-9d0a-e2e6ea79ff13"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("f67dc232-2ec7-40a3-b456-61ca0afe5b9f"));
            Store = (ITTObjectListBox)AddControl(new Guid("7aa3f999-d759-4ac3-80ab-a751381da88d"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("771e610f-ce16-4159-a1c1-b678e2df36f0"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("6a4c38f6-3619-4a3c-9334-b22f46ccc8df"));
            labelEndDate = (ITTLabel)AddControl(new Guid("97968ded-93b8-4fcd-947f-e7a02cfa3571"));
            labelStartDate = (ITTLabel)AddControl(new Guid("be8f2f41-3b1f-4e61-bfea-78ca07fe872c"));
            labelDescription = (ITTLabel)AddControl(new Guid("422e7aab-bdf7-4910-a7a8-992013758abb"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("05a534c7-58c7-4200-adb0-db513e99bd5c"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("3184189e-c6cf-43a7-9614-d8ed9ca9ef9e"));
            labelProcessNO = (ITTLabel)AddControl(new Guid("f8ef4ebf-aee1-4a40-b21e-553aa8542a48"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("2c45d2eb-30fb-4eb7-8047-7cbd39b0d126"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a41dbddb-4a16-4bbd-abe8-bdc137a57c75"));
            base.InitializeControls();
        }

        public E2Form() : base("E2", "E2Form")
        {
        }

        protected E2Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}