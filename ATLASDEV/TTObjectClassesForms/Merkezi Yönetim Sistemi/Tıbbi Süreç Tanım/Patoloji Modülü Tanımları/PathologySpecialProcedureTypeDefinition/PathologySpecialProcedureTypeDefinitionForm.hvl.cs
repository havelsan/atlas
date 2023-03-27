
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
    /// Patoloji Özel İşlem Türü Tanım Formu
    /// </summary>
    public partial class PathologySpecialProcedureTypeDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Patoloji Özel İşlem Tür Tanımı
    /// </summary>
        protected TTObjectClasses.PathologySpecialProcedureTypeDefinition _PathologySpecialProcedureTypeDefinition
        {
            get { return (TTObjectClasses.PathologySpecialProcedureTypeDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("cd3d3f1b-786a-491a-afd8-d6f72624e772"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("9125e7c0-a4c8-431c-8e7c-36ed9548b6de"));
            IsActive = (ITTCheckBox)AddControl(new Guid("c0bab14c-b64e-4708-8ebb-7d207c59b973"));
            base.InitializeControls();
        }

        public PathologySpecialProcedureTypeDefinitionForm() : base("PATHOLOGYSPECIALPROCEDURETYPEDEFINITION", "PathologySpecialProcedureTypeDefinitionForm")
        {
        }

        protected PathologySpecialProcedureTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}