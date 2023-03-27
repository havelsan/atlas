
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
    public partial class PainChangingSituationsForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Ağrı Değerlendirme Tanımlama
    /// </summary>
        protected TTObjectClasses.PainChangingSituationDefinition _PainChangingSituationDefinition
        {
            get { return (TTObjectClasses.PainChangingSituationDefinition)_ttObject; }
        }

        protected ITTCheckBox Decreasing;
        protected ITTCheckBox Increasing;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            Decreasing = (ITTCheckBox)AddControl(new Guid("a1d6748c-05a8-4b28-ab8e-4810a5941a71"));
            Increasing = (ITTCheckBox)AddControl(new Guid("7b13048b-ab39-499b-8276-dbbf582aad71"));
            labelName = (ITTLabel)AddControl(new Guid("02b00699-feaf-4b0f-9e9b-a7392dff584d"));
            Name = (ITTTextBox)AddControl(new Guid("7da50128-9801-4a0c-abf6-2042506cb06c"));
            base.InitializeControls();
        }

        public PainChangingSituationsForm() : base("PAINCHANGINGSITUATIONDEFINITION", "PainChangingSituationsForm")
        {
        }

        protected PainChangingSituationsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}