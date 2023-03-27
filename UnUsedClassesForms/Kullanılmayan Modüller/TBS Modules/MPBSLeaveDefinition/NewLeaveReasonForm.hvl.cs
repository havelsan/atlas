
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
    /// İzin Nedeni Tanımlama
    /// </summary>
    public partial class NewLeaveReasonForm : TTForm
    {
    /// <summary>
    /// İzin Nedeni Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSLeaveDefinition _MPBSLeaveDefinition
        {
            get { return (TTObjectClasses.MPBSLeaveDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("3b961941-e87c-4ee6-be14-330a0d5a5af9"));
            Name = (ITTTextBox)AddControl(new Guid("2098ab6f-c4f4-4f87-b455-db3262d9d6a5"));
            base.InitializeControls();
        }

        public NewLeaveReasonForm() : base("MPBSLEAVEDEFINITION", "NewLeaveReasonForm")
        {
        }

        protected NewLeaveReasonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}