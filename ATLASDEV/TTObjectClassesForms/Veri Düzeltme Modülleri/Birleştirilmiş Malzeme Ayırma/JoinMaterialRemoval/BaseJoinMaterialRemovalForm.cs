
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
    /// Birleştirilen Malzemeyi Ayırma
    /// </summary>
    public partial class BaseJoinMaterialRemovalForm : TTForm
    {
        override protected void BindControlEvents()
        {
            MaterialListBox.SelectedObjectChanged += new TTControlEventDelegate(MaterialListBox_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MaterialListBox.SelectedObjectChanged -= new TTControlEventDelegate(MaterialListBox_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void MaterialListBox_SelectedObjectChanged()
        {
#region BaseJoinMaterialRemovalForm_MaterialListBox_SelectedObjectChanged
   _JoinMaterialRemoval.JoinMaterial  = ((Material)this.MaterialListBox.SelectedObject).JoinedMaterial.ObjectID;
#endregion BaseJoinMaterialRemovalForm_MaterialListBox_SelectedObjectChanged
        }
    }
}