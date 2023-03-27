
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
    public partial class CentralActionBaseForm : TTForm
    {
        protected TTObjectClasses.BaseCentralAction _BaseCentralAction
        {
            get { return (TTObjectClasses.BaseCentralAction)_ttObject; }
        }

        protected ITTLabel labelFromSite;
        protected ITTObjectListBox FromSite;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelFromSite = (ITTLabel)AddControl(new Guid("a3b4b33e-cea5-4df1-a041-6b3ff5ea06dd"));
            FromSite = (ITTObjectListBox)AddControl(new Guid("96008f8c-84b5-47d2-9aa8-1e301ac2e2b7"));
            labelActionDate = (ITTLabel)AddControl(new Guid("1226b267-1f47-4272-8812-21e85f88372f"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("a89df509-b486-4c01-8b11-4b4a7ba780bb"));
            base.InitializeControls();
        }

        public CentralActionBaseForm() : base("BASECENTRALACTION", "CentralActionBaseForm")
        {
        }

        protected CentralActionBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}