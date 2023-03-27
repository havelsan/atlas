
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
    public partial class ReagentSpeciesTypeDefForm : BaseResDevDefForm
    {
        protected TTObjectClasses.ReagentSpeciesDef _ReagentSpeciesDef
        {
            get { return (TTObjectClasses.ReagentSpeciesDef)_ttObject; }
        }

        protected ITTLabel labelReagentTypes;
        protected ITTObjectListBox ReagentTypes;
        override protected void InitializeControls()
        {
            labelReagentTypes = (ITTLabel)AddControl(new Guid("bbb127e8-70bb-45ca-ba29-ab4b11a8b8bb"));
            ReagentTypes = (ITTObjectListBox)AddControl(new Guid("10b2ff70-ca00-4ab7-bed1-97b7ce81e6b2"));
            base.InitializeControls();
        }

        public ReagentSpeciesTypeDefForm() : base("REAGENTSPECIESDEF", "ReagentSpeciesTypeDefForm")
        {
        }

        protected ReagentSpeciesTypeDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}