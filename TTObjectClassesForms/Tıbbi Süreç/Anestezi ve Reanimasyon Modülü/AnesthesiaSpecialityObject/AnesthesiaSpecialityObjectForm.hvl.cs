
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
    public partial class AnesthesiaSpecialityObjectForm : TTForm
    {
        protected TTObjectClasses.AnesthesiaSpecialityObject _AnesthesiaSpecialityObject
        {
            get { return (TTObjectClasses.AnesthesiaSpecialityObject)_ttObject; }
        }

        protected ITTGrid AnesthesiaTechniques;
        protected ITTEnumComboBoxColumn AnesthesiaTechniqueAnesthesiaConsultationAnesthesiaTechniqueGrid;
        protected ITTLabel labelASAType;
        protected ITTEnumComboBox ASAType;
        override protected void InitializeControls()
        {
            AnesthesiaTechniques = (ITTGrid)AddControl(new Guid("f78ccfb0-4cb5-4ce0-9a0b-3e8c9935b24e"));
            AnesthesiaTechniqueAnesthesiaConsultationAnesthesiaTechniqueGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("8f17129e-b41a-4dc6-8e87-b6d8e283636f"));
            labelASAType = (ITTLabel)AddControl(new Guid("1681ea33-e457-44c1-b242-ca4188ea541a"));
            ASAType = (ITTEnumComboBox)AddControl(new Guid("428fbd7e-e647-4dce-90de-bab119c7d848"));
            base.InitializeControls();
        }

        public AnesthesiaSpecialityObjectForm() : base("ANESTHESIASPECIALITYOBJECT", "AnesthesiaSpecialityObjectForm")
        {
        }

        protected AnesthesiaSpecialityObjectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}