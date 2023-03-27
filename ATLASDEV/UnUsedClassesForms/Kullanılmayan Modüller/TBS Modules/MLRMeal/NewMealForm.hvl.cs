
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
    /// Yeni yemel Girişi
    /// </summary>
    public partial class NewMealForm : TTForm
    {
    /// <summary>
    /// DLR004_Yemek
    /// </summary>
        protected TTObjectClasses.MLRMeal _MLRMeal
        {
            get { return (TTObjectClasses.MLRMeal)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox TotalMealCalorie;
        protected ITTGrid SupplyGrid;
        protected ITTListBoxColumn SupplyColumn;
        protected ITTTextBoxColumn AmountColumn;
        protected ITTTextBoxColumn TotalCalorieColumn;
        protected ITTLabel labelName;
        protected ITTEnumComboBox IsMeal;
        protected ITTTextBox MealCode;
        protected ITTObjectListBox RegimeGroup;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelDescription;
        protected ITTTextBox Name;
        protected ITTLabel labelSıralamaYeri;
        protected ITTLabel labelMealGroup;
        protected ITTLabel labelRequestAmount;
        protected ITTObjectListBox MealUnit;
        protected ITTTextBox SıralamaYeri;
        protected ITTObjectListBox MealGroup;
        protected ITTTextBox RequestAmount;
        protected ITTLabel labelDate;
        protected ITTTextBox Description;
        protected ITTTextBox MonthAmount;
        protected ITTLabel labelMonthAmount;
        protected ITTLabel labelRegimeGroup;
        protected ITTLabel labelMealCode;
        protected ITTLabel labelMealUnit;
        protected ITTLabel labelIsMeal;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("5165fddc-ed4f-4582-9b57-1163d19ed7d8"));
            TotalMealCalorie = (ITTTextBox)AddControl(new Guid("d43eeffe-778e-4dea-990e-b8ae888d272a"));
            SupplyGrid = (ITTGrid)AddControl(new Guid("4661870e-7534-434c-9667-f636639aa2d8"));
            SupplyColumn = (ITTListBoxColumn)AddControl(new Guid("a955b226-2e28-4453-85a5-83b3a4cde515"));
            AmountColumn = (ITTTextBoxColumn)AddControl(new Guid("c749e880-78fe-4b3f-acd2-af3cdbab5740"));
            TotalCalorieColumn = (ITTTextBoxColumn)AddControl(new Guid("de0598cd-8e05-45a4-9292-0f62e9b92cc2"));
            labelName = (ITTLabel)AddControl(new Guid("8bc31954-20a0-4c70-853c-18776ab7fec7"));
            IsMeal = (ITTEnumComboBox)AddControl(new Guid("2c23ad52-9978-4ca8-ac35-1d0467d6b6da"));
            MealCode = (ITTTextBox)AddControl(new Guid("d4f1fee7-3886-4411-a877-1e5c1b8adbd7"));
            RegimeGroup = (ITTObjectListBox)AddControl(new Guid("d7313529-7e9d-46bb-a9f8-51bc457e9ac9"));
            Date = (ITTDateTimePicker)AddControl(new Guid("9f0c504a-b3c1-4571-9854-6c1f69fece45"));
            labelDescription = (ITTLabel)AddControl(new Guid("59c806ae-5b13-4324-a3d5-6feb74b34048"));
            Name = (ITTTextBox)AddControl(new Guid("c26706ad-17b2-4f8a-9a4c-7a9735919cbe"));
            labelSıralamaYeri = (ITTLabel)AddControl(new Guid("2d5b7db9-4d24-435a-8a14-7e09b5cea892"));
            labelMealGroup = (ITTLabel)AddControl(new Guid("1c59b0c9-b87a-4388-a76c-84d9217495bd"));
            labelRequestAmount = (ITTLabel)AddControl(new Guid("7ef967f5-1d6f-4d22-b8c5-90b2430cbefe"));
            MealUnit = (ITTObjectListBox)AddControl(new Guid("ad407cd5-b079-4f7f-a342-9c49fe1d58e4"));
            SıralamaYeri = (ITTTextBox)AddControl(new Guid("97de06cb-0337-4db8-ae61-a880313302a4"));
            MealGroup = (ITTObjectListBox)AddControl(new Guid("8f31ca07-346b-4f59-a159-bd7f5fbdb8ae"));
            RequestAmount = (ITTTextBox)AddControl(new Guid("b1b84afa-b5e0-4bbe-95fc-c31946629c08"));
            labelDate = (ITTLabel)AddControl(new Guid("2cc23ca8-34d1-41f2-b770-cedb3b4cf743"));
            Description = (ITTTextBox)AddControl(new Guid("5049e735-e54e-4175-92ab-d498d4ed63c4"));
            MonthAmount = (ITTTextBox)AddControl(new Guid("c2f6a0fc-2e50-451d-b4b3-db0e57801399"));
            labelMonthAmount = (ITTLabel)AddControl(new Guid("57f08ce4-a28a-4137-8a17-e6bfcd7bbccc"));
            labelRegimeGroup = (ITTLabel)AddControl(new Guid("0bf8ea45-b69c-40a0-808f-e86b215aa282"));
            labelMealCode = (ITTLabel)AddControl(new Guid("2d92d6ec-4495-4bf4-921d-ee7559a9aa46"));
            labelMealUnit = (ITTLabel)AddControl(new Guid("330b4b4b-221f-43df-9fa2-f109975edfd5"));
            labelIsMeal = (ITTLabel)AddControl(new Guid("b1753b48-4621-47c4-92ea-f67a1f5d2a74"));
            base.InitializeControls();
        }

        public NewMealForm() : base("MLRMEAL", "NewMealForm")
        {
        }

        protected NewMealForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}