
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
    /// Laboratuvar Alt Test Detay Formu
    /// </summary>
    public partial class LaboratorySubProcedureDetail : TTForm
    {
    /// <summary>
    /// Laboratuvar Alt Test
    /// </summary>
        protected TTObjectClasses.LaboratorySubProcedure _LaboratorySubProcedure
        {
            get { return (TTObjectClasses.LaboratorySubProcedure)_ttObject; }
        }

        protected ITTGrid GridSubProcedures;
        protected ITTListBoxColumn TestName;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn Unit;
        protected ITTTextBoxColumn ObjectID;
        override protected void InitializeControls()
        {
            GridSubProcedures = (ITTGrid)AddControl(new Guid("13fcc80c-89eb-4ce2-87b1-634c80cbdb70"));
            TestName = (ITTListBoxColumn)AddControl(new Guid("4c7161cd-f328-404b-b19b-c277262d5e6c"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("ec4ade43-c0c7-4987-b358-0848bd96adfc"));
            Unit = (ITTTextBoxColumn)AddControl(new Guid("29a0ca9f-3a2f-4939-970d-6a25e0c8aff8"));
            ObjectID = (ITTTextBoxColumn)AddControl(new Guid("beb34357-1a94-4087-971f-56275c396e74"));
            base.InitializeControls();
        }

        public LaboratorySubProcedureDetail() : base("LABORATORYSUBPROCEDURE", "LaboratorySubProcedureDetail")
        {
        }

        protected LaboratorySubProcedureDetail(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}