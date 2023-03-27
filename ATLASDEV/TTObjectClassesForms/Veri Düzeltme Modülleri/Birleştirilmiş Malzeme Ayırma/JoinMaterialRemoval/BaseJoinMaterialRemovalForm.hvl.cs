
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
    /// Birleştirilen Malzemeyi Ayırma
    /// </summary>
    public partial class BaseJoinMaterialRemovalForm : TTForm
    {
    /// <summary>
    /// Birleştirilen Malzemeyi Düzeltme
    /// </summary>
        protected TTObjectClasses.JoinMaterialRemoval _JoinMaterialRemoval
        {
            get { return (TTObjectClasses.JoinMaterialRemoval)_ttObject; }
        }

        protected ITTLabel labelJoinedMaterialMaterial;
        protected ITTObjectListBox JoinedMaterial;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MaterialListBox;
        override protected void InitializeControls()
        {
            labelJoinedMaterialMaterial = (ITTLabel)AddControl(new Guid("0afbdb00-89b5-40c9-aa0a-763a5e540941"));
            JoinedMaterial = (ITTObjectListBox)AddControl(new Guid("1f03f7ab-ea62-4034-b527-565e52df9e91"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0c2446f0-e59e-4b19-988a-dda0b9e568dd"));
            MaterialListBox = (ITTObjectListBox)AddControl(new Guid("6b7b0b43-02eb-4b24-bb06-1dbd901f4078"));
            base.InitializeControls();
        }

        public BaseJoinMaterialRemovalForm() : base("JOINMATERIALREMOVAL", "BaseJoinMaterialRemovalForm")
        {
        }

        protected BaseJoinMaterialRemovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}