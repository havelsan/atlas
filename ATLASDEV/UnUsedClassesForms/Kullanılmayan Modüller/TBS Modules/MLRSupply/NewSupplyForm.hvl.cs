
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
    /// Yeni Malzeme
    /// </summary>
    public partial class NewSupplyForm : TTForm
    {
    /// <summary>
    /// DLR001_Malzeme
    /// </summary>
        protected TTObjectClasses.MLRSupply _MLRSupply
        {
            get { return (TTObjectClasses.MLRSupply)_ttObject; }
        }

        protected ITTLabel labelUnit1;
        protected ITTObjectListBox CalorieUnit;
        protected ITTTextBox HekCode;
        protected ITTTextBox Description;
        protected ITTLabel labelLastPrice;
        protected ITTLabel labelHekCode;
        protected ITTLabel labelSupplyUnit;
        protected ITTTextBox CaloriePerUnit;
        protected ITTLabel labelMinAmount;
        protected ITTTextBox SupplyCode;
        protected ITTLabel labelMaxAmount;
        protected ITTTextBox MaxAmount;
        protected ITTLabel labelUnit2Y;
        protected ITTLabel labelCoefficient23;
        protected ITTTextBox Coefficient23;
        protected ITTLabel labelCaloriePerUnit;
        protected ITTObjectListBox Unit3;
        protected ITTLabel labelCalorieUnit;
        protected ITTTextBox Coefficient12;
        protected ITTTextBox OtherCode;
        protected ITTLabel labelOtherCode;
        protected ITTObjectListBox Unit2;
        protected ITTLabel labelCoefficient12;
        protected ITTObjectListBox SupplyUnit;
        protected ITTLabel labelDescription;
        protected ITTLabel labelUnit3;
        protected ITTLabel labelSupplyCode;
        protected ITTTextBox LastPrice;
        protected ITTTextBox MinAmount;
        protected ITTObjectListBox Unit1;
        protected ITTLabel labelUnit2;
        override protected void InitializeControls()
        {
            labelUnit1 = (ITTLabel)AddControl(new Guid("c0af651a-2ac2-4e85-b129-0232e86efb68"));
            CalorieUnit = (ITTObjectListBox)AddControl(new Guid("4ed8503b-2034-471e-9445-d19663ad0462"));
            HekCode = (ITTTextBox)AddControl(new Guid("1d40df93-eb6b-4ef3-9f1e-c3d94aa081f3"));
            Description = (ITTTextBox)AddControl(new Guid("38caf54c-b035-478c-a2a6-ead3c9a3ef12"));
            labelLastPrice = (ITTLabel)AddControl(new Guid("0eeedb6b-5332-418c-b967-cbd277fdfb42"));
            labelHekCode = (ITTLabel)AddControl(new Guid("fa270ed3-1aa8-47bf-b0e1-c2906d91c14d"));
            labelSupplyUnit = (ITTLabel)AddControl(new Guid("5a8b8fdc-4c94-4bc1-9f9e-b090d069478f"));
            CaloriePerUnit = (ITTTextBox)AddControl(new Guid("cdc2b25b-cba8-416d-938a-ac6bedc2b87a"));
            labelMinAmount = (ITTLabel)AddControl(new Guid("0f91949c-4c49-450e-9619-9871ae40eff8"));
            SupplyCode = (ITTTextBox)AddControl(new Guid("cf411833-0ee6-401b-a59b-918fb88a5edf"));
            labelMaxAmount = (ITTLabel)AddControl(new Guid("d0244caa-fdb0-469d-bc80-a4bd887c8109"));
            MaxAmount = (ITTTextBox)AddControl(new Guid("4b8ce66b-c434-4af5-bb93-a3e606a1d0b7"));
            labelUnit2Y = (ITTLabel)AddControl(new Guid("e2f37b1d-3565-42bc-9b80-8a86334f83de"));
            labelCoefficient23 = (ITTLabel)AddControl(new Guid("0f2c1faf-1f2c-4fa7-9ae0-806604e14ebc"));
            Coefficient23 = (ITTTextBox)AddControl(new Guid("2df29766-eb95-407c-a9f1-e397f48f2e22"));
            labelCaloriePerUnit = (ITTLabel)AddControl(new Guid("e676f644-931a-49eb-a0e6-8e6efdac04f0"));
            Unit3 = (ITTObjectListBox)AddControl(new Guid("c361c7ef-b0c8-46a3-b9f0-8037bf5f207e"));
            labelCalorieUnit = (ITTLabel)AddControl(new Guid("b7812d62-7a44-42ab-ac9d-6e831ae31156"));
            Coefficient12 = (ITTTextBox)AddControl(new Guid("85971e43-0517-4542-a04b-500af2543a7d"));
            OtherCode = (ITTTextBox)AddControl(new Guid("1d2a6f87-fc9d-433c-8b26-5d8a78e4aebd"));
            labelOtherCode = (ITTLabel)AddControl(new Guid("99c3e9b5-032f-4b3d-8c17-7544ad35fd8a"));
            Unit2 = (ITTObjectListBox)AddControl(new Guid("54a8ca0b-34cc-41fe-a4ec-452f6fdc591f"));
            labelCoefficient12 = (ITTLabel)AddControl(new Guid("5d1beab9-fa92-474e-9a4d-21cdd11c5084"));
            SupplyUnit = (ITTObjectListBox)AddControl(new Guid("9d782db4-8ac3-4fce-ac98-4db5b80ba9f2"));
            labelDescription = (ITTLabel)AddControl(new Guid("dc679051-e134-42bc-b182-124a03f16971"));
            labelUnit3 = (ITTLabel)AddControl(new Guid("76ce0354-9f28-4f16-bdda-3e77ecc9b821"));
            labelSupplyCode = (ITTLabel)AddControl(new Guid("dc701d7b-6661-4eec-a13e-1d075a6360cd"));
            LastPrice = (ITTTextBox)AddControl(new Guid("b4cba363-d5af-454d-bda0-00a258e6729f"));
            MinAmount = (ITTTextBox)AddControl(new Guid("951de16f-bafc-4fc1-b520-00cad7cb4d7a"));
            Unit1 = (ITTObjectListBox)AddControl(new Guid("cd1928ae-5b12-41b9-af5b-7b9151a23b0e"));
            labelUnit2 = (ITTLabel)AddControl(new Guid("fbf81ba8-5bc8-4f2d-baae-fe98e4b0ade7"));
            base.InitializeControls();
        }

        public NewSupplyForm() : base("MLRSUPPLY", "NewSupplyForm")
        {
        }

        protected NewSupplyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}