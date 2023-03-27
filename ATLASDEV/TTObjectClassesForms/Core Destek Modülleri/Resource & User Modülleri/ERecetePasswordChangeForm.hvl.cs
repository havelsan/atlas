
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
    /// E Reçete Şifresi Güncelleme
    /// </summary>
    public partial class ERecetePasswordChangeForm : TTUnboundForm
    {
        protected ITTButton cmdExit;
        protected ITTButton cmdChange;
        protected ITTTextBox newPassRepeatText;
        protected ITTTextBox newPassText;
        protected ITTTextBox oldPassText;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel userFullNameLabel;
        override protected void InitializeControls()
        {
            cmdExit = (ITTButton)AddControl(new Guid("64309630-5a54-4108-b9fb-8e20285829fd"));
            cmdChange = (ITTButton)AddControl(new Guid("a644a5b6-3836-44b0-8e4b-b3eade0d84a9"));
            newPassRepeatText = (ITTTextBox)AddControl(new Guid("6f56ccca-b6c5-45fd-97e9-9ee116194691"));
            newPassText = (ITTTextBox)AddControl(new Guid("d26efd5a-d742-4299-9bc3-2df598c98273"));
            oldPassText = (ITTTextBox)AddControl(new Guid("8242110d-21b3-433b-bcb4-907bb545a975"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8ec51e1d-be66-452d-9f3f-400c590e802d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3d004b54-25a5-402c-a79c-72cccf8ae8c2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a235b022-4ec9-416a-8f88-3ade13e523c1"));
            userFullNameLabel = (ITTLabel)AddControl(new Guid("408bbd66-e328-4d7d-8b11-48c4536834ec"));
            base.InitializeControls();
        }

        public ERecetePasswordChangeForm() : base("ERecetePasswordChangeForm")
        {
        }

        protected ERecetePasswordChangeForm(string formDefName) : base(formDefName)
        {
        }
    }
}