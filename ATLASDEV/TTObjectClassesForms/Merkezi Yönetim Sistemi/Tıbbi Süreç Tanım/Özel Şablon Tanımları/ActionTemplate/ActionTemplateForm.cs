
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Şablon Tanımı
    /// </summary>
    public partial class ActionTemplateForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            ContentButton.Click += new TTControlEventDelegate(ContentButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ContentButton.Click -= new TTControlEventDelegate(ContentButton_Click);
            base.UnBindControlEvents();
        }

        private void ContentButton_Click()
        {
#region ActionTemplateForm_ContentButton_Click
   TTForm pForm = TTForm.GetEditForm(this._ActionTemplate.Action);
            pForm.ShowReadOnly(this, this._ActionTemplate.Action);
#endregion ActionTemplateForm_ContentButton_Click
        }
    }
}