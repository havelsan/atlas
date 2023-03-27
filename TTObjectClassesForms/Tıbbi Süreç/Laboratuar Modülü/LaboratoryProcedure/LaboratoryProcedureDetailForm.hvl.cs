
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
    /// Laboratuvar Panel Detay Formu
    /// </summary>
    public partial class LaboratoryProcedureDetailForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Test
    /// </summary>
        protected TTObjectClasses.LaboratoryProcedure _LaboratoryProcedure
        {
            get { return (TTObjectClasses.LaboratoryProcedure)_ttObject; }
        }

        protected ITTGrid GridSubProcedures;
        protected ITTListBoxColumn TestName;
        protected ITTTextBoxColumn result;
        protected ITTEnumComboBoxColumn Warning;
        protected ITTTextBoxColumn Reference;
        protected ITTTextBoxColumn unit;
        protected ITTRichTextBoxControlColumn SpecialReference;
        protected ITTTextBoxColumn objId;
        override protected void InitializeControls()
        {
            GridSubProcedures = (ITTGrid)AddControl(new Guid("35516bd5-0822-40a5-9d55-1041b3401ff8"));
            TestName = (ITTListBoxColumn)AddControl(new Guid("64fe0833-4643-4f4f-b2a9-45c1b902d290"));
            result = (ITTTextBoxColumn)AddControl(new Guid("53e959eb-28e7-4bc4-b77f-9ffe1cb943c7"));
            Warning = (ITTEnumComboBoxColumn)AddControl(new Guid("70258d31-84b6-4caa-b157-1f5ac598734a"));
            Reference = (ITTTextBoxColumn)AddControl(new Guid("2fffea66-d1e4-4222-a6d4-7e6ce8b3d09a"));
            unit = (ITTTextBoxColumn)AddControl(new Guid("80258945-6603-4abe-b86b-bc39f674bdce"));
            SpecialReference = (ITTRichTextBoxControlColumn)AddControl(new Guid("6d823470-d4fa-4923-b253-590ef9cd2ea5"));
            objId = (ITTTextBoxColumn)AddControl(new Guid("b07054bf-28e5-4adc-b84f-78d417f1b5e2"));
            base.InitializeControls();
        }

        public LaboratoryProcedureDetailForm() : base("LABORATORYPROCEDURE", "LaboratoryProcedureDetailForm")
        {
        }

        protected LaboratoryProcedureDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}