
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
    public partial class RadiotherapyXRayTypeDefForm : TTDefinitionForm
    {
        protected TTObjectClasses.RadiotherapyXRayTypeDef _RadiotherapyXRayTypeDef
        {
            get { return (TTObjectClasses.RadiotherapyXRayTypeDef)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("9b7f088c-c821-459d-83fd-45ba9cca0faa"));
            labelName = (ITTLabel)AddControl(new Guid("18c614c1-c748-47f4-b8ce-1bef4beb18b3"));
            Name = (ITTTextBox)AddControl(new Guid("921e5a4c-6333-4998-b0d5-fa6dc634a6f3"));
            Code = (ITTTextBox)AddControl(new Guid("4adfb428-bb79-446b-a88d-27a8a7032b4e"));
            labelCode = (ITTLabel)AddControl(new Guid("b2dae198-3834-4dce-a57d-d93fc6649c30"));
            base.InitializeControls();
        }

        public RadiotherapyXRayTypeDefForm() : base("RADIOTHERAPYXRAYTYPEDEF", "RadiotherapyXRayTypeDefForm")
        {
        }

        protected RadiotherapyXRayTypeDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}