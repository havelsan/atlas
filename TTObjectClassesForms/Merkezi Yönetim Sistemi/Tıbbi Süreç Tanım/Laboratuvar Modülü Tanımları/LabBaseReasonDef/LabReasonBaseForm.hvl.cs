
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
    public partial class LabReasonBaseForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.LabBaseReasonDef _LabBaseReasonDef
        {
            get { return (TTObjectClasses.LabBaseReasonDef)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTCheckBox Active;
        protected ITTLabel labelReason;
        protected ITTTextBox Reason;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("36cb660d-f412-4b46-9552-6c26d05edfee"));
            Description = (ITTTextBox)AddControl(new Guid("abdc18c9-929d-480c-82a7-942e6db9031c"));
            Active = (ITTCheckBox)AddControl(new Guid("cca89e76-24b8-4b44-904a-052fab5c1262"));
            labelReason = (ITTLabel)AddControl(new Guid("836e4fbb-039c-4eae-a752-1f6a9eb5c4e9"));
            Reason = (ITTTextBox)AddControl(new Guid("51527bce-58ff-437b-beac-b51017e6d44c"));
            labelCode = (ITTLabel)AddControl(new Guid("820a18cf-3f6b-41d1-9007-f143f3f1d1ed"));
            Code = (ITTTextBox)AddControl(new Guid("e87dbc6a-de45-4bff-91f5-a44e8df490e9"));
            base.InitializeControls();
        }

        public LabReasonBaseForm() : base("LABBASEREASONDEF", "LabReasonBaseForm")
        {
        }

        protected LabReasonBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}