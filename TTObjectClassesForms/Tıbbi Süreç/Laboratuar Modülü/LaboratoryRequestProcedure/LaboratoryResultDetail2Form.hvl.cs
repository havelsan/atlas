
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
    public partial class LaboratoryResultDetail2 : TTForm
    {
        protected TTObjectClasses.LaboratoryRequestProcedure _LaboratoryRequestProcedure
        {
            get { return (TTObjectClasses.LaboratoryRequestProcedure)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn objId;
        protected ITTListBoxColumn TestName;
        protected ITTTextBoxColumn result;
        protected ITTTextBoxColumn unit;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("918ccb9f-3b36-4efa-96bd-2b1e7c1183be"));
            objId = (ITTTextBoxColumn)AddControl(new Guid("6f1b6b79-46fa-4529-9974-699153ff4f53"));
            TestName = (ITTListBoxColumn)AddControl(new Guid("90593f66-4de9-4138-8ac4-4c36e9583279"));
            result = (ITTTextBoxColumn)AddControl(new Guid("c7308c66-d9c0-4524-98d9-53332ff679ff"));
            unit = (ITTTextBoxColumn)AddControl(new Guid("a80eb189-d341-4ea4-b5ce-d6b67be76812"));
            base.InitializeControls();
        }

        public LaboratoryResultDetail2() : base("LABORATORYREQUESTPROCEDURE", "LaboratoryResultDetail2")
        {
        }

        protected LaboratoryResultDetail2(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}