
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
    public partial class MedicalWasteTypeForm : TTDefinitionForm
    {
    /// <summary>
    /// Tıbbi Atık Tehlikeli Atık İşlem Türü tanımı
    /// </summary>
        protected TTObjectClasses.MedicalWasteTypeDefinition _MedicalWasteTypeDefinition
        {
            get { return (TTObjectClasses.MedicalWasteTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("b57ded26-b928-4f31-8036-6a19258fab34"));
            Name = (ITTTextBox)AddControl(new Guid("35cc074d-91c8-45a8-b7c7-6c2964ba8739"));
            Code = (ITTTextBox)AddControl(new Guid("84f0eee9-ca40-4d90-83da-9018e3666eff"));
            labelCode = (ITTLabel)AddControl(new Guid("6063d251-eaec-442d-9ff5-0676ea4009a5"));
            base.InitializeControls();
        }

        public MedicalWasteTypeForm() : base("MEDICALWASTETYPEDEFINITION", "MedicalWasteTypeForm")
        {
        }

        protected MedicalWasteTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}