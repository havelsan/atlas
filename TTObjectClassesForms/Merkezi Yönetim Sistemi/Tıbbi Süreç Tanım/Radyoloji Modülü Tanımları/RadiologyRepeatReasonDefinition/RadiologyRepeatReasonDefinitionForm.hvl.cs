
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
    /// Radyoloji Tekrar Neden Tanımları
    /// </summary>
    public partial class RadiologyRepeatReasonDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Radyoloji Tekrar Neden Tanımları
    /// </summary>
        protected TTObjectClasses.RadiologyRepeatReasonDefinition _RadiologyRepeatReasonDefinition
        {
            get { return (TTObjectClasses.RadiologyRepeatReasonDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        protected ITTLabel labelName;
        protected ITTCheckBox ISACTIVE;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("257b0595-90f8-488d-aaad-2409de1cb34e"));
            Code = (ITTTextBox)AddControl(new Guid("254b1927-fb8f-49dd-b457-14a77a1fc1c6"));
            labelCode = (ITTLabel)AddControl(new Guid("5e631276-2f03-4a18-84b2-af1492aac0de"));
            labelName = (ITTLabel)AddControl(new Guid("85b2aa46-dca5-483d-9d9a-411166295246"));
            ISACTIVE = (ITTCheckBox)AddControl(new Guid("e467ee21-e201-4f57-a5f0-9fc2427b1bf7"));
            base.InitializeControls();
        }

        public RadiologyRepeatReasonDefinitionForm() : base("RADIOLOGYREPEATREASONDEFINITION", "RadiologyRepeatReasonDefinitionForm")
        {
        }

        protected RadiologyRepeatReasonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}