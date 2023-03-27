
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
    /// Mernis Ölüm Sebebi Tanımı
    /// </summary>
    public partial class MernisDeathReasonDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Mernis Ölüm Sebepleri
    /// </summary>
        protected TTObjectClasses.MernisDeathReasonDefinition _MernisDeathReasonDefinition
        {
            get { return (TTObjectClasses.MernisDeathReasonDefinition)_ttObject; }
        }

        protected ITTLabel labelReasonName;
        protected ITTTextBox ReasonName;
        override protected void InitializeControls()
        {
            labelReasonName = (ITTLabel)AddControl(new Guid("8a09a420-00cb-4ac6-8cad-bf09342a1cd0"));
            ReasonName = (ITTTextBox)AddControl(new Guid("ff0f4976-23d5-4672-ab38-2c5431275b2c"));
            base.InitializeControls();
        }

        public MernisDeathReasonDefinitionForm() : base("MERNISDEATHREASONDEFINITION", "MernisDeathReasonDefinitionForm")
        {
        }

        protected MernisDeathReasonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}