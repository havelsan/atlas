
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
    public partial class ChemotherapyApplyMethodDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Kemoterapi Uygulama Şekli
    /// </summary>
        protected TTObjectClasses.ChemotherapyApplyMethod _ChemotherapyApplyMethod
        {
            get { return (TTObjectClasses.ChemotherapyApplyMethod)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("c3040d74-3c10-47eb-9cec-c58f45326ce3"));
            labelName = (ITTLabel)AddControl(new Guid("bc7f452e-e086-4978-a8e0-40f60ca3b1ee"));
            Name = (ITTTextBox)AddControl(new Guid("4abfedb8-1910-4605-af3b-67c9262602d8"));
            Code = (ITTTextBox)AddControl(new Guid("1ec65fce-77be-437c-a19a-5b1e51a6e83a"));
            labelCode = (ITTLabel)AddControl(new Guid("2d1e01a9-0c43-4237-81da-1714cdb0c56f"));
            base.InitializeControls();
        }

        public ChemotherapyApplyMethodDefForm() : base("CHEMOTHERAPYAPPLYMETHOD", "ChemotherapyApplyMethodDefForm")
        {
        }

        protected ChemotherapyApplyMethodDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}