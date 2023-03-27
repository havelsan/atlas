
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
    /// Sarf Giriş
    /// </summary>
    public partial class NursingApplicationTreatmentMaterialForm : TTForm
    {
    /// <summary>
    /// Sarf Giriş
    /// </summary>
        protected TTObjectClasses.NursingApplicationTreatmentMaterial _NursingApplicationTreatmentMaterial
        {
            get { return (TTObjectClasses.NursingApplicationTreatmentMaterial)_ttObject; }
        }

        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        override protected void InitializeControls()
        {
            labelMaterial = (ITTLabel)AddControl(new Guid("d5660421-a507-4491-a013-3b926b4f8a88"));
            Material = (ITTObjectListBox)AddControl(new Guid("03e70762-88ca-4677-992e-bfe564862098"));
            labelAmount = (ITTLabel)AddControl(new Guid("0e2af8dd-7f63-49f0-89fe-958f36724397"));
            Amount = (ITTTextBox)AddControl(new Guid("c30a3067-e524-4934-9298-9d73423bd5c3"));
            labelActionDate = (ITTLabel)AddControl(new Guid("83140377-2d16-4acf-82ee-c1cbef40fd31"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0706175c-70e9-48d4-9188-0e4823686939"));
            labelNote = (ITTLabel)AddControl(new Guid("7b274b09-8626-4e18-8911-4587ad61a79c"));
            Note = (ITTTextBox)AddControl(new Guid("74658958-0653-4751-ba00-3db06e5f26ec"));
            base.InitializeControls();
        }

        public NursingApplicationTreatmentMaterialForm() : base("NURSINGAPPLICATIONTREATMENTMATERIAL", "NursingApplicationTreatmentMaterialForm")
        {
        }

        protected NursingApplicationTreatmentMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}