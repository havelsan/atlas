
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
    /// İstisnai Durum Tanımlama
    /// </summary>
    public partial class IstisnaiHalDefForm : TTDefinitionForm
    {
    /// <summary>
    /// İstisnai Hal Tanımları
    /// </summary>
        protected TTObjectClasses.IstisnaiHal _IstisnaiHal
        {
            get { return (TTObjectClasses.IstisnaiHal)_ttObject; }
        }

        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTLabel labelDesc;
        override protected void InitializeControls()
        {
            labelCode = (ITTLabel)AddControl(new Guid("e75e7e58-6b5f-4a58-8c5b-e9422a8026b1"));
            Code = (ITTTextBox)AddControl(new Guid("24bda02e-8c9b-455c-910a-6ea23cdeb424"));
            Name = (ITTTextBox)AddControl(new Guid("d2440221-12fb-47e2-808b-87de716aad8d"));
            labelDesc = (ITTLabel)AddControl(new Guid("10601293-0380-47b3-bc78-1fbc38d14e88"));
            base.InitializeControls();
        }

        public IstisnaiHalDefForm() : base("ISTISNAIHAL", "IstisnaiHalDefForm")
        {
        }

        protected IstisnaiHalDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}