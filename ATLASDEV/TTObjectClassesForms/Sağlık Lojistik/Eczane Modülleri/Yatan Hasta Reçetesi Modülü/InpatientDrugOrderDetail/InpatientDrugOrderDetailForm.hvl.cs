
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
    /// Uygulama
    /// </summary>
    public partial class InpatientDrugOrderDetailForm : TTForm
    {
    /// <summary>
    /// İlaç Direktifi Uygulamaları
    /// </summary>
        protected TTObjectClasses.InpatientDrugOrderDetail _InpatientDrugOrderDetail
        {
            get { return (TTObjectClasses.InpatientDrugOrderDetail)_ttObject; }
        }

        protected ITTEnumComboBox Frequency;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelSDateTime;
        protected ITTLabel labelAmount;
        protected ITTObjectListBox Material;
        protected ITTTextBox DoseAmount;
        protected ITTLabel labelMaterial;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDoseAmount;
        protected ITTLabel labelUsageNote;
        protected ITTTextBox UsageNote;
        protected ITTTextBox ID;
        protected ITTTextBox Amount;
        protected ITTLabel labelActionDate;
        protected ITTTextBox Stage;
        protected ITTDateTimePicker SDateTime;
        protected ITTLabel labelID;
        protected ITTLabel labelFrequency;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            Frequency = (ITTEnumComboBox)AddControl(new Guid("f27de852-63b8-4929-9b01-1bb4b83e311c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("7a5484d1-310d-497a-8ce4-2d6d7a42bbb9"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("50e0ce9c-d10a-4ff3-90e5-3ae00524f797"));
            labelAmount = (ITTLabel)AddControl(new Guid("9f976d46-3182-449b-b682-4761076d31d9"));
            Material = (ITTObjectListBox)AddControl(new Guid("5cbbfd51-f65e-47e2-9a9f-5b7f613a814f"));
            DoseAmount = (ITTTextBox)AddControl(new Guid("03372d22-46c9-4f42-b5f0-5fee852a8451"));
            labelMaterial = (ITTLabel)AddControl(new Guid("bafb63f7-124d-4ff4-95f2-603b63bc9964"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d811a389-daa2-44c1-a219-703e923ba815"));
            labelDoseAmount = (ITTLabel)AddControl(new Guid("45b0ca6b-885f-4873-8da8-79a09206dd42"));
            labelUsageNote = (ITTLabel)AddControl(new Guid("0a50b92e-6d77-459e-afad-86aa8b698e11"));
            UsageNote = (ITTTextBox)AddControl(new Guid("7ef79f21-e8b5-4648-88a6-972ec90530e1"));
            ID = (ITTTextBox)AddControl(new Guid("4a080aac-c4ab-49e0-94a0-c5d1ea367063"));
            Amount = (ITTTextBox)AddControl(new Guid("1eee7e26-c982-43ee-b420-cd1899118efb"));
            labelActionDate = (ITTLabel)AddControl(new Guid("dc5fad56-52f9-4504-8b37-d65a98133305"));
            Stage = (ITTTextBox)AddControl(new Guid("ce019616-0617-47fb-b11f-e406401e425f"));
            SDateTime = (ITTDateTimePicker)AddControl(new Guid("5478c0ac-81d6-47b9-888f-ef95dfcd7bcd"));
            labelID = (ITTLabel)AddControl(new Guid("61694a44-1175-44d6-a49b-eff176565ed0"));
            labelFrequency = (ITTLabel)AddControl(new Guid("194fab1d-e115-415c-ae82-f38812e56ce2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("0255610b-bd2f-4f77-9ebb-6cbb0bd3825f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("08b23581-da1b-4970-992c-7694668794e4"));
            base.InitializeControls();
        }

        public InpatientDrugOrderDetailForm() : base("INPATIENTDRUGORDERDETAIL", "InpatientDrugOrderDetailForm")
        {
        }

        protected InpatientDrugOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}