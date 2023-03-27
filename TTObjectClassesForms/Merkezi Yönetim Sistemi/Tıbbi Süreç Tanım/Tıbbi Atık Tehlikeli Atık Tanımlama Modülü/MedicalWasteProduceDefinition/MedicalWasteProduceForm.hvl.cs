
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
    public partial class MedicalWasteProduceForm : TTDefinitionForm
    {
    /// <summary>
    /// Tıbbi Atık Tehlikeli Atık Ürün Tanımlama
    /// </summary>
        protected TTObjectClasses.MedicalWasteProduceDefinition _MedicalWasteProduceDefinition
        {
            get { return (TTObjectClasses.MedicalWasteProduceDefinition)_ttObject; }
        }

        protected ITTLabel labelMedicalWasteType;
        protected ITTObjectListBox MedicalWasteType;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelMedicalWasteType = (ITTLabel)AddControl(new Guid("c0839812-0671-4221-89f1-f7e8c5ec3049"));
            MedicalWasteType = (ITTObjectListBox)AddControl(new Guid("f4c2a21b-0f21-4648-8f9c-fea5a75e1d25"));
            labelName = (ITTLabel)AddControl(new Guid("7b038ee8-d5b3-4d20-b463-4a0947f8a050"));
            Name = (ITTTextBox)AddControl(new Guid("507045bc-084c-43c3-b168-09d777bef2ed"));
            Code = (ITTTextBox)AddControl(new Guid("85e2474d-834e-4dd4-a83f-b09054f3f1f6"));
            labelCode = (ITTLabel)AddControl(new Guid("75703416-2601-42ef-aa85-382dcca03274"));
            base.InitializeControls();
        }

        public MedicalWasteProduceForm() : base("MEDICALWASTEPRODUCEDEFINITION", "MedicalWasteProduceForm")
        {
        }

        protected MedicalWasteProduceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}