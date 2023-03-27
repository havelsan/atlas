
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
    public partial class RadiologyRequestInfoForm : TTForm
    {
    /// <summary>
    /// Radyoloji
    /// </summary>
        protected TTObjectClasses.Radiology _Radiology
        {
            get { return (TTObjectClasses.Radiology)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("ab496f67-b4c3-4906-b117-d61d9155a55c"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8b3f80d1-4373-4900-897c-fcc9f229f04f"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("3606a68f-aa98-4c76-a438-40e8ad3971b3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3881a613-277c-4218-b368-babfe4dd26ca"));
            base.InitializeControls();
        }

        public RadiologyRequestInfoForm() : base("RADIOLOGY", "RadiologyRequestInfoForm")
        {
        }

        protected RadiologyRequestInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}