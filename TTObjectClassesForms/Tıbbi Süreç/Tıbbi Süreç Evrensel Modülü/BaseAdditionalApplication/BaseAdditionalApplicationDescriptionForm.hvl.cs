
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
    /// Açıklama Formu
    /// </summary>
    public partial class BaseAdditionalApplicationDescriptionForm : TTForm
    {
    /// <summary>
    /// Ek Uygulamalar
    /// </summary>
        protected TTObjectClasses.BaseAdditionalApplication _BaseAdditionalApplication
        {
            get { return (TTObjectClasses.BaseAdditionalApplication)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("5fa2aebf-04a8-4d50-859e-62b02e00959d"));
            Description = (ITTTextBox)AddControl(new Guid("ca37c722-09e8-4e2c-93ab-02b4a8cad209"));
            base.InitializeControls();
        }

        public BaseAdditionalApplicationDescriptionForm() : base("BASEADDITIONALAPPLICATION", "BaseAdditionalApplicationDescriptionForm")
        {
        }

        protected BaseAdditionalApplicationDescriptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}