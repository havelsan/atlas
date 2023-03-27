
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
    /// Radyoloji Red Neden Tanımları
    /// </summary>
    public partial class RadiologyRejectReasonDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Radyoloji Red Neden Tanımları
    /// </summary>
        protected TTObjectClasses.RadiologyRejectReasonDefinition _RadiologyRejectReasonDefinition
        {
            get { return (TTObjectClasses.RadiologyRejectReasonDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("20a32b3d-1d46-4dbd-8b3f-3c2adcf41c55"));
            Code = (ITTTextBox)AddControl(new Guid("0679466b-406b-42e5-928c-92b8d6cec3de"));
            labelCode = (ITTLabel)AddControl(new Guid("02446fa3-24e1-4a4f-8b4d-d19713f3f2da"));
            labelName = (ITTLabel)AddControl(new Guid("c9ad2d0b-37a7-4677-86e0-df9fb70d540d"));
            Active = (ITTCheckBox)AddControl(new Guid("fa50a492-5fe0-437a-a051-e1ee2de555cc"));
            base.InitializeControls();
        }

        public RadiologyRejectReasonDefinitionForm() : base("RADIOLOGYREJECTREASONDEFINITION", "RadiologyRejectReasonDefinitionForm")
        {
        }

        protected RadiologyRejectReasonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}