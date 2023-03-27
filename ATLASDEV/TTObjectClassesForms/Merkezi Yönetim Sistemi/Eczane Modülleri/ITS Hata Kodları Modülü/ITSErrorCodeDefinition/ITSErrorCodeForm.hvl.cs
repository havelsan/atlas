
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
    /// ITS Hata Kodları Tanımı
    /// </summary>
    public partial class ITSErrorCodeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// İts Hata Kodları
    /// </summary>
        protected TTObjectClasses.ITSErrorCodeDefinition _ITSErrorCodeDefinition
        {
            get { return (TTObjectClasses.ITSErrorCodeDefinition)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("a81ed122-14a0-4470-aaac-f88dda92e2a2"));
            Description = (ITTTextBox)AddControl(new Guid("af48a988-c3ee-4745-973e-9d1beac9635d"));
            Code = (ITTTextBox)AddControl(new Guid("88ad9b69-fb31-42f5-9292-c21e4d735ccd"));
            labelCode = (ITTLabel)AddControl(new Guid("28059737-d02c-4e0b-8bf9-bab125dbb32c"));
            IsActive = (ITTCheckBox)AddControl(new Guid("c01f8854-5782-492e-a24c-f32dbed1feb6"));
            base.InitializeControls();
        }

        public ITSErrorCodeForm() : base("ITSERRORCODEDEFINITION", "ITSErrorCodeForm")
        {
        }

        protected ITSErrorCodeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}