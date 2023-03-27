
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
    /// Temel Parametre Tanımı
    /// </summary>
    public partial class BaseParameterForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SystemParameter _SystemParameter
        {
            get { return (TTObjectClasses.SystemParameter)_ttObject; }
        }

        protected ITTLabel labelCacheDurationInMinutes;
        protected ITTTextBox CacheDurationInMinutes;
        protected ITTTextBox Value;
        protected ITTTextBox Name;
        protected ITTTextBox Description;
        protected ITTLabel labelValue;
        protected ITTLabel labelName;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            labelCacheDurationInMinutes = (ITTLabel)AddControl(new Guid("95059a99-1fd4-47f0-84bc-df1b2b08a9b6"));
            CacheDurationInMinutes = (ITTTextBox)AddControl(new Guid("319ee03b-8ee9-40ed-9870-ef4d8f881acd"));
            Value = (ITTTextBox)AddControl(new Guid("67fdd9b6-2a02-4047-89be-35c4adfe3007"));
            Name = (ITTTextBox)AddControl(new Guid("b4a771bf-8cc0-4db7-a65a-67fa1434257d"));
            Description = (ITTTextBox)AddControl(new Guid("77aedb1b-fd97-47e6-8a1d-5c0ff4f185e1"));
            labelValue = (ITTLabel)AddControl(new Guid("5a25444c-ebfb-4c21-902d-95ddfe2f7f58"));
            labelName = (ITTLabel)AddControl(new Guid("4b7e6e6b-1723-42cc-9b10-3a56cb7acc49"));
            labelDescription = (ITTLabel)AddControl(new Guid("02f92364-aed8-4c21-af46-72d809d41d04"));
            base.InitializeControls();
        }

        public BaseParameterForm() : base("SYSTEMPARAMETER", "BaseParameterForm")
        {
        }

        protected BaseParameterForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}