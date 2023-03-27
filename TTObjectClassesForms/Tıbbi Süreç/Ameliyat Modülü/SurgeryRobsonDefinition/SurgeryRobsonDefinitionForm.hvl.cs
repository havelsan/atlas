
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
    /// Robson Grubu Tanımlama Formu
    /// </summary>
    public partial class SurgeryRobsonDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Robson Grubu
    /// </summary>
        protected TTObjectClasses.SurgeryRobsonDefinition _SurgeryRobsonDefinition
        {
            get { return (TTObjectClasses.SurgeryRobsonDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("56564962-aab2-4ad0-9eb5-7660d4201ae5"));
            Name = (ITTTextBox)AddControl(new Guid("e6dd389f-6d08-4958-a6fa-14d789ea0d24"));
            Aktif = (ITTCheckBox)AddControl(new Guid("8e23e40d-b93a-47dd-9d0a-1ae30a2fecea"));
            base.InitializeControls();
        }

        public SurgeryRobsonDefinitionForm() : base("SURGERYROBSONDEFINITION", "SurgeryRobsonDefinitionForm")
        {
        }

        protected SurgeryRobsonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}