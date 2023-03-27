
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
    public partial class WeightForm : TTForm
    {
        protected TTObjectClasses.Weight _Weight
        {
            get { return (TTObjectClasses.Weight)_ttObject; }
        }

        protected ITTLabel labelValue;
        protected ITTTextBox Value;
        override protected void InitializeControls()
        {
            labelValue = (ITTLabel)AddControl(new Guid("0636ce9b-28a3-4653-ab4b-a4d90c43710c"));
            Value = (ITTTextBox)AddControl(new Guid("919b506e-1074-4f73-9ad2-07a329cc4952"));
            base.InitializeControls();
        }

        public WeightForm() : base("WEIGHT", "WeightForm")
        {
        }

        protected WeightForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}