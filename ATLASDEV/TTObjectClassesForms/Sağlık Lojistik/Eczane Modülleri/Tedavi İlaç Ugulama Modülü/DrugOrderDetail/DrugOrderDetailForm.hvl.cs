
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
    public partial class DrugOrderDetailForm : TTForm
    {
    /// <summary>
    /// İlaç Uygulama
    /// </summary>
        protected TTObjectClasses.DrugOrderDetail _DrugOrderDetail
        {
            get { return (TTObjectClasses.DrugOrderDetail)_ttObject; }
        }

        protected ITTLabel labelDoseAmount;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox Material;
        protected ITTLabel labelFrequency;
        protected ITTTextBox ID;
        protected ITTTextBox DoseAmount;
        protected ITTTextBox UsageNote;
        protected ITTTextBox Stage;
        protected ITTTextBox RestDose;
        protected ITTTextBox Amount;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelID;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelMaterial;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelUsageNote;
        protected ITTLabel labelActionDate;
        protected ITTEnumComboBox Frequency;
        protected ITTLabel labelSDateTime;
        protected ITTLabel labelAmount;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            labelDoseAmount = (ITTLabel)AddControl(new Guid("6fd71de5-d7e5-4a5d-ba3f-00c70a73c7fe"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("865460bb-b536-4c65-9c3c-04f709aeb6f0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("034950f5-a81c-4367-a7de-0ad627296a8e"));
            Material = (ITTObjectListBox)AddControl(new Guid("daf7ed8f-7fb2-494f-96b6-13c8a2f43fd6"));
            labelFrequency = (ITTLabel)AddControl(new Guid("527e28b2-c9fd-477e-aad5-28e15e38ddfc"));
            ID = (ITTTextBox)AddControl(new Guid("5f5d2500-1af6-48fa-bdc0-2b27d2281f26"));
            DoseAmount = (ITTTextBox)AddControl(new Guid("7b1a53f7-55ec-4c62-8e2e-64a24bfb5e4e"));
            UsageNote = (ITTTextBox)AddControl(new Guid("29f0e899-4e83-4aab-9806-66f811df6fb3"));
            Stage = (ITTTextBox)AddControl(new Guid("434183c3-8c8b-437c-8253-863ceb4e773a"));
            RestDose = (ITTTextBox)AddControl(new Guid("60c10632-a385-42a7-9915-97ab2f17b831"));
            Amount = (ITTTextBox)AddControl(new Guid("dc786215-b448-44ee-81e0-ab2f725014c6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f9ed8a9e-fbeb-4007-b907-8a7d1e023ea0"));
            labelID = (ITTLabel)AddControl(new Guid("2e9f094a-9c5b-4e48-879f-48c1fa2c6614"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("afa1a3c8-05dc-486e-aaee-4ab246854fef"));
            labelMaterial = (ITTLabel)AddControl(new Guid("9b782c7a-122f-4dae-b221-4f55eb4c228f"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("52afcecf-0c61-4900-826a-6690b83087d9"));
            labelUsageNote = (ITTLabel)AddControl(new Guid("695f8d63-b640-40ab-84cb-7114f30e36ac"));
            labelActionDate = (ITTLabel)AddControl(new Guid("d9dfa59f-6681-41ef-a42b-73006ac0dfcd"));
            Frequency = (ITTEnumComboBox)AddControl(new Guid("6d852456-a47e-4388-8456-7bafb100ca8c"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("f7674dca-02bd-4337-a3f5-92b75e8d4237"));
            labelAmount = (ITTLabel)AddControl(new Guid("22e4dd33-0086-4043-884c-baf4fe947989"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("863b98b2-0f24-4e7c-b615-bb80eea10b0f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("af17529f-3b1f-4d84-9000-fffe981c36df"));
            base.InitializeControls();
        }

        public DrugOrderDetailForm() : base("DRUGORDERDETAIL", "DrugOrderDetailForm")
        {
        }

        protected DrugOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}