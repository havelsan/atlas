
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
    /// Fiş Etiketi Tanımlama
    /// </summary>
    public partial class MhsSlipGroupDefinitionForm : TTForm
    {
    /// <summary>
    /// Fiş Grubu
    /// </summary>
        protected TTObjectClasses.MhSSlipGroup _MhSSlipGroup
        {
            get { return (TTObjectClasses.MhSSlipGroup)_ttObject; }
        }

        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTTextBox Code;
        protected ITTLabel labelValue;
        protected ITTLabel labelCode;
        protected ITTTextBox Value;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("1df0d64d-9e98-4dc5-9124-3d54c84e175a"));
            Code = (ITTTextBox)AddControl(new Guid("bca77e0d-e322-45f9-a349-36f82afb4cb3"));
            labelValue = (ITTLabel)AddControl(new Guid("04b2b55b-fc11-4143-a64f-5d0b485e9eb0"));
            labelCode = (ITTLabel)AddControl(new Guid("78433e11-98bb-47f6-bf0c-9ed1bba822ef"));
            Value = (ITTTextBox)AddControl(new Guid("0b4fbe94-ff9b-4d9d-a8f1-a958e9af77fd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("bc26babb-5062-48d4-be20-b085228ccb4a"));
            base.InitializeControls();
        }

        public MhsSlipGroupDefinitionForm() : base("MHSSLIPGROUP", "MhsSlipGroupDefinitionForm")
        {
        }

        protected MhsSlipGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}