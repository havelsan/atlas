
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
    public partial class HeightForm : TTForm
    {
        protected TTObjectClasses.Height _Height
        {
            get { return (TTObjectClasses.Height)_ttObject; }
        }

        protected ITTLabel labelValue;
        protected ITTTextBox Value;
        override protected void InitializeControls()
        {
            labelValue = (ITTLabel)AddControl(new Guid("9f7c359e-d043-49ef-9735-24c112d3d293"));
            Value = (ITTTextBox)AddControl(new Guid("a8a05b11-d918-4a23-bafa-df5ba088d38f"));
            base.InitializeControls();
        }

        public HeightForm() : base("HEIGHT", "HeightForm")
        {
        }

        protected HeightForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}