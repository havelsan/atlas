
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
    /// Laboratuvar Tekrar Neden Tanım Formu
    /// </summary>
    public partial class LaboratoryRepeatReasonDefinitionForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Tekrar Neden Tanımı
    /// </summary>
        protected TTObjectClasses.LaboratoryRepeatReasonDefinition _LaboratoryRepeatReasonDefinition
        {
            get { return (TTObjectClasses.LaboratoryRepeatReasonDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox2;
        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("ebfc2d63-55bc-441c-9d7c-237646879230"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("ad106c2c-ff46-46ae-a02f-4d638fa2cd6c"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("b710ad1a-3aed-4a7d-95ce-d9b2dbdfe4e8"));
            base.InitializeControls();
        }

        public LaboratoryRepeatReasonDefinitionForm() : base("LABORATORYREPEATREASONDEFINITION", "LaboratoryRepeatReasonDefinitionForm")
        {
        }

        protected LaboratoryRepeatReasonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}