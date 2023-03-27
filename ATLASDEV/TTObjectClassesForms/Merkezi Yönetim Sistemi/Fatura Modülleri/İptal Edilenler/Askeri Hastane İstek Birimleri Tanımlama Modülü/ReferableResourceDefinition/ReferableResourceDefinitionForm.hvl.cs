
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
    /// XXXXXX  XXXXXX İstek Bölümleri Tanımlama 
    /// </summary>
    public partial class ReferableResourceDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ReferableResourceDefinition _ReferableResourceDefinition
        {
            get { return (TTObjectClasses.ReferableResourceDefinition)_ttObject; }
        }

        protected ITTGrid ReferableHospitals;
        protected ITTListBoxColumn ResOtherHospital;
        protected ITTLabel labelReferableAction;
        protected ITTEnumComboBox ReferableAction;
        override protected void InitializeControls()
        {
            ReferableHospitals = (ITTGrid)AddControl(new Guid("1ca2cb0d-461b-4b9e-adf3-94e8a43e8d2d"));
            ResOtherHospital = (ITTListBoxColumn)AddControl(new Guid("22e49c49-fb10-4a71-bbef-fff1f5a58eee"));
            labelReferableAction = (ITTLabel)AddControl(new Guid("aa5506d3-25fb-4dc8-ae3d-f040c4634d91"));
            ReferableAction = (ITTEnumComboBox)AddControl(new Guid("dab78e9a-8686-4a03-9d07-e42a0b7c2f73"));
            base.InitializeControls();
        }

        public ReferableResourceDefinitionForm() : base("REFERABLERESOURCEDEFINITION", "ReferableResourceDefinitionForm")
        {
        }

        protected ReferableResourceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}