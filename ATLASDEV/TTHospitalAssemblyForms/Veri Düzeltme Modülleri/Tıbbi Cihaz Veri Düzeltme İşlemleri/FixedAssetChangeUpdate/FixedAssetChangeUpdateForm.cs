
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
    /// Demirbaş Tipi Değiştirme İşlemi Güncelleme
    /// </summary>
    public partial class FixedAssetChangeUpdateForm : BaseDataCorrectionForm
    {
        override protected void BindControlEvents()
        {
            cmdGetChangeAction.Click += new TTControlEventDelegate(cmdGetChangeAction_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdGetChangeAction.Click -= new TTControlEventDelegate(cmdGetChangeAction_Click);
            base.UnBindControlEvents();
        }

        private void cmdGetChangeAction_Click()
        {
        }
    }
}