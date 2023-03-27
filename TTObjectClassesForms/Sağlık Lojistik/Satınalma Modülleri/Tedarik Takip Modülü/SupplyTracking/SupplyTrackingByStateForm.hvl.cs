
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
    /// Sözleşme Arama
    /// </summary>
    public partial class SupplyTrackingByStateForm : TTForm
    {
    /// <summary>
    /// Tedarik Takip Modülü temel sınıfıdır
    /// </summary>
        protected TTObjectClasses.SupplyTracking _SupplyTracking
        {
            get { return (TTObjectClasses.SupplyTracking)_ttObject; }
        }

        protected ITTButton cmdList;
        protected ITTGrid ItemsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn OrderDate;
        protected ITTTextBoxColumn DueDate;
        protected ITTButtonColumn ShowOrder;
        protected ITTTextBoxColumn OrderGUID;
        protected ITTEnumComboBox txt2DetailStatus;
        protected ITTLabel ttlabel12;
        override protected void InitializeControls()
        {
            cmdList = (ITTButton)AddControl(new Guid("5f1ee40d-8e2c-4bf4-a370-fb77ec00d735"));
            ItemsGrid = (ITTGrid)AddControl(new Guid("adc3ab5a-5f87-49c7-a0b9-c7925246abc2"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("5e245334-f3f6-4973-9cba-3d5acbc67d6a"));
            Material = (ITTListBoxColumn)AddControl(new Guid("3a5b6e9d-9c4f-4e93-9e68-5319b69d700f"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("886969d1-9c1e-4527-8af0-6af2de5b0581"));
            OrderDate = (ITTTextBoxColumn)AddControl(new Guid("aac19a90-8ff5-4257-b960-d2f501217d5f"));
            DueDate = (ITTTextBoxColumn)AddControl(new Guid("dda29e03-09c9-429f-ae1f-97b89f321660"));
            ShowOrder = (ITTButtonColumn)AddControl(new Guid("64b4147f-0a56-4dc8-b4be-3f8ca9f3d91c"));
            OrderGUID = (ITTTextBoxColumn)AddControl(new Guid("c7e6e479-98fc-4b77-b424-e5e133ba69b7"));
            txt2DetailStatus = (ITTEnumComboBox)AddControl(new Guid("0163d735-4a5d-4840-9bef-444d1f052af2"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("bdec27ab-a701-48c9-9e54-169fa2f67421"));
            base.InitializeControls();
        }

        public SupplyTrackingByStateForm() : base("SUPPLYTRACKING", "SupplyTrackingByStateForm")
        {
        }

        protected SupplyTrackingByStateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}