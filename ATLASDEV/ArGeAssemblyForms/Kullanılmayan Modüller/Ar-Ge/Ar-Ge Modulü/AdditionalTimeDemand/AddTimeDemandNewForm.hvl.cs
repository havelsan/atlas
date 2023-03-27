
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
    public partial class AddTimeDemandNewForm : TTForm
    {
        protected TTObjectClasses.AdditionalTimeDemand _AdditionalTimeDemand
        {
            get { return (TTObjectClasses.AdditionalTimeDemand)_ttObject; }
        }

        protected ITTLabel labelComment;
        protected ITTTextBox Comment;
        protected ITTTextBox ExtraDuration;
        protected ITTEnumComboBox DurationType;
        protected ITTLabel labelExtraDuration;
        override protected void InitializeControls()
        {
            labelComment = (ITTLabel)AddControl(new Guid("bf8752dd-eb31-4d4e-be7b-7fd58364ba9a"));
            Comment = (ITTTextBox)AddControl(new Guid("70a98910-b3d8-4ea6-8234-ca5151917670"));
            ExtraDuration = (ITTTextBox)AddControl(new Guid("88dee5a1-9af0-4db3-a31d-bc7dff8ba94e"));
            DurationType = (ITTEnumComboBox)AddControl(new Guid("002d6040-8d40-45b6-a2d6-44ab96864bdc"));
            labelExtraDuration = (ITTLabel)AddControl(new Guid("d28db79b-9153-492b-a204-338e9dce6b03"));
            base.InitializeControls();
        }

        public AddTimeDemandNewForm() : base("ADDITIONALTIMEDEMAND", "AddTimeDemandNewForm")
        {
        }

        protected AddTimeDemandNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}