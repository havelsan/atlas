
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
    public partial class PathologyTestRequestInfoForm : TTForm
    {
        protected TTObjectClasses.PathologyTestProcedure _PathologyTestProcedure
        {
            get { return (TTObjectClasses.PathologyTestProcedure)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("e428a51a-abec-4181-9ca3-4491eca2a63e"));
            Description = (ITTTextBox)AddControl(new Guid("a1d27556-9c71-45fe-b817-71c161fe40be"));
            base.InitializeControls();
        }

        public PathologyTestRequestInfoForm() : base("PATHOLOGYTESTPROCEDURE", "PathologyTestRequestInfoForm")
        {
        }

        protected PathologyTestRequestInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}