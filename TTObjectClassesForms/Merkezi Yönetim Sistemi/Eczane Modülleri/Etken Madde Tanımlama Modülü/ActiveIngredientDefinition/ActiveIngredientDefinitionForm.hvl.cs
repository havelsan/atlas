
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
    /// Etken Madde Tanımı
    /// </summary>
    public partial class ActiveIngredientDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ActiveIngredientDefinition _ActiveIngredientDefinition
        {
            get { return (TTObjectClasses.ActiveIngredientDefinition)_ttObject; }
        }

        protected ITTObjectListBox MaxDoseUnit;
        protected ITTLabel labelMaxDose;
        protected ITTTextBox MaxDose;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage IngredientsTabPage;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ActiveIngredient;
        protected ITTTextBoxColumn Rate;
        protected ITTTextBoxColumn Value;
        protected ITTTextBoxColumn IngredientDescription;
        protected ITTTabPage IngredientsDets;
        protected ITTGrid ActiveIngredientDetails;
        protected ITTTextBoxColumn MaxDoseActiveIngredientDetail;
        protected ITTListBoxColumn MaxDoseUnitActiveIngredientDetail;
        protected ITTTextBoxColumn StartingAgeActiveIngredientDetail;
        protected ITTTextBoxColumn EndAgeActiveIngredientDetail;
        protected ITTEnumComboBoxColumn SexActiveIngredientDetail;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            MaxDoseUnit = (ITTObjectListBox)AddControl(new Guid("9982c3c0-b6f0-44f9-8a54-dc73ecc1b32f"));
            labelMaxDose = (ITTLabel)AddControl(new Guid("b7788a16-a462-440c-acfb-bf71f022d22e"));
            MaxDose = (ITTTextBox)AddControl(new Guid("53d1475c-bc9d-43b9-b9cc-a370ec43f5cf"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("39c9b6fc-0cae-4779-8380-7c1884210589"));
            IngredientsTabPage = (ITTTabPage)AddControl(new Guid("a2bffb47-77ec-410a-b0db-f0d473996571"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("d15ad874-0174-4930-8159-83bf46b23f16"));
            ActiveIngredient = (ITTListBoxColumn)AddControl(new Guid("ff980f70-ffc7-4fe8-a7dd-0ecde0b62798"));
            Rate = (ITTTextBoxColumn)AddControl(new Guid("cd677d59-0c5a-4b2b-a1c1-6820efc46ee6"));
            Value = (ITTTextBoxColumn)AddControl(new Guid("c16a1aaa-509c-42ff-866c-ee339ba778e7"));
            IngredientDescription = (ITTTextBoxColumn)AddControl(new Guid("1f0a010f-48dc-4000-97e2-974770b6cd2a"));
            IngredientsDets = (ITTTabPage)AddControl(new Guid("d5241f35-09b3-4b3a-883a-ff1c0b19a97c"));
            ActiveIngredientDetails = (ITTGrid)AddControl(new Guid("d857a1d7-cd37-4f22-91fe-cb98a1c0df0e"));
            MaxDoseActiveIngredientDetail = (ITTTextBoxColumn)AddControl(new Guid("f98c5886-414e-4ff9-9c99-891c73a87aff"));
            MaxDoseUnitActiveIngredientDetail = (ITTListBoxColumn)AddControl(new Guid("b71ad003-d9bf-4273-a870-ddc00d73d084"));
            StartingAgeActiveIngredientDetail = (ITTTextBoxColumn)AddControl(new Guid("d42085a2-1529-4d5e-94fc-8ecf223386f0"));
            EndAgeActiveIngredientDetail = (ITTTextBoxColumn)AddControl(new Guid("7e4db96e-1e71-4764-ab90-970c739f8cb6"));
            SexActiveIngredientDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("acb04b4c-20f8-4567-86c7-e2c90e9743b0"));
            Description = (ITTTextBox)AddControl(new Guid("5e8dc569-a0d4-450a-8612-55182f4f7fbe"));
            Code = (ITTTextBox)AddControl(new Guid("318e8cc4-6919-4622-85b8-5af3dcb99f5c"));
            Name = (ITTTextBox)AddControl(new Guid("7b232d58-6676-40cc-9429-ab425b39cfc4"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("fe2c5ebb-f1e7-4faf-b766-c63e9797efa2"));
            labelDescription = (ITTLabel)AddControl(new Guid("0af5601d-8eb5-4f60-ad43-7b60244b25a0"));
            labelCode = (ITTLabel)AddControl(new Guid("6ad70024-f635-4534-8a69-9b6792639af4"));
            labelName = (ITTLabel)AddControl(new Guid("5bb5e9f2-0a90-4d0c-a565-ca0f3a1a21a9"));
            IsActive = (ITTCheckBox)AddControl(new Guid("4978c62f-fd6d-41b5-9546-e0d0c07d69a6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1b2fcc44-0024-462a-abfa-2af6d835fd21"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("18df1951-8f82-4430-97f1-ced7eb8efdf0"));
            base.InitializeControls();
        }

        public ActiveIngredientDefinitionForm() : base("ACTIVEINGREDIENTDEFINITION", "ActiveIngredientDefinitionForm")
        {
        }

        protected ActiveIngredientDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}