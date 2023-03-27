
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
    public partial class CourseDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Yemek Tanımları
    /// </summary>
        protected TTObjectClasses.CourseDefinition _CourseDefinition
        {
            get { return (TTObjectClasses.CourseDefinition)_ttObject; }
        }

        protected ITTGrid DietMaterialGrid;
        protected ITTListBoxColumn DietMaterialDefinitionDietMaterialGrid;
        protected ITTEnumComboBox AmountType;
        protected ITTLabel labelTotalProteinRate;
        protected ITTTextBox TotalProteinRate;
        protected ITTTextBox TotalCarbohydrateRate;
        protected ITTTextBox TotalFatRate;
        protected ITTTextBox TotalCalories;
        protected ITTTextBox Amount;
        protected ITTTextBox Name;
        protected ITTLabel labelTotalCarbohydrateRate;
        protected ITTLabel labelTotalFatRate;
        protected ITTLabel labelTotalCalories;
        protected ITTLabel labelAmount;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            DietMaterialGrid = (ITTGrid)AddControl(new Guid("db5e51d9-2122-4274-aa01-a4632e0e632d"));
            DietMaterialDefinitionDietMaterialGrid = (ITTListBoxColumn)AddControl(new Guid("6c85fd18-95d6-4db8-af31-d87a3f60d87f"));
            AmountType = (ITTEnumComboBox)AddControl(new Guid("095ff6cc-d043-4f7c-9550-e09cfc22f8b7"));
            labelTotalProteinRate = (ITTLabel)AddControl(new Guid("67d2e438-1211-4ed6-bb92-c89f2fc69bed"));
            TotalProteinRate = (ITTTextBox)AddControl(new Guid("42f40fcb-f45f-4c6b-83a2-2a29f81126c2"));
            TotalCarbohydrateRate = (ITTTextBox)AddControl(new Guid("c556bd7b-7ba5-48db-908b-ddf6c2ea75c6"));
            TotalFatRate = (ITTTextBox)AddControl(new Guid("14f28cf0-d681-4f6a-9696-18a983387d44"));
            TotalCalories = (ITTTextBox)AddControl(new Guid("fba21840-5d13-45ff-a30b-fd0a22ef8ce1"));
            Amount = (ITTTextBox)AddControl(new Guid("3f8f054f-4896-4f65-bed8-adc266132c93"));
            Name = (ITTTextBox)AddControl(new Guid("33d54dfe-6446-472a-b4ab-9146744c7958"));
            labelTotalCarbohydrateRate = (ITTLabel)AddControl(new Guid("78a24591-8911-4c4a-9920-5ce577ea0469"));
            labelTotalFatRate = (ITTLabel)AddControl(new Guid("71a7e2ff-b3bf-495a-a184-e733230966a3"));
            labelTotalCalories = (ITTLabel)AddControl(new Guid("e83f83fe-0987-4760-b0c2-ae612c9f98a1"));
            labelAmount = (ITTLabel)AddControl(new Guid("0c8d0e8b-ee52-48c7-beaa-1d4d6159e859"));
            labelName = (ITTLabel)AddControl(new Guid("36370bb9-576b-4978-912d-363efa19d14d"));
            base.InitializeControls();
        }

        public CourseDefinitionForm() : base("COURSEDEFINITION", "CourseDefinitionForm")
        {
        }

        protected CourseDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}