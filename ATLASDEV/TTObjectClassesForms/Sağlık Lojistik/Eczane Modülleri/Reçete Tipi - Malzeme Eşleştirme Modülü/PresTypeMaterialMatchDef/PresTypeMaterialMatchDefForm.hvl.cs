
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
    /// Reçete Tipi / Malzeme Eşleştirme
    /// </summary>
    public partial class PresTypeMaterialMatchDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Reçete Tipi / Malzeme Eşleştirme
    /// </summary>
        protected TTObjectClasses.PresTypeMaterialMatchDef _PresTypeMaterialMatchDef
        {
            get { return (TTObjectClasses.PresTypeMaterialMatchDef)_ttObject; }
        }

        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelPrescriptionType;
        protected ITTEnumComboBox PrescriptionType;
        override protected void InitializeControls()
        {
            labelMaterial = (ITTLabel)AddControl(new Guid("5f858c00-93bf-459e-bb6d-81daf2645eab"));
            Material = (ITTObjectListBox)AddControl(new Guid("240fafc7-c4f5-41c1-90ff-94e55d35a60f"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("be25c76a-d40e-4d9b-a6f2-10e83f6026a6"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("84fbda8d-7ef6-4d04-b907-30ab0dff51db"));
            base.InitializeControls();
        }

        public PresTypeMaterialMatchDefForm() : base("PRESTYPEMATERIALMATCHDEF", "PresTypeMaterialMatchDefForm")
        {
        }

        protected PresTypeMaterialMatchDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}