
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
    public partial class InpatientAdmissinDepositMaterialForm : TTForm
    {
        protected TTObjectClasses.InpatientAdmissionDepositMaterial _InpatientAdmissionDepositMaterial
        {
            get { return (TTObjectClasses.InpatientAdmissionDepositMaterial)_ttObject; }
        }

        protected ITTLabel labelProcessUser;
        protected ITTObjectListBox ProcessUser;
        protected ITTLabel labelProcessDate;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTLabel labelQuarantineProcessType;
        protected ITTEnumComboBox QuarantineProcessType;
        override protected void InitializeControls()
        {
            labelProcessUser = (ITTLabel)AddControl(new Guid("7ab85d4f-1ee3-45cd-bd31-a3629564599d"));
            ProcessUser = (ITTObjectListBox)AddControl(new Guid("5f0a149c-c18b-42a7-aabe-55146883b9f0"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("0c89ed41-07d5-4a80-b37d-0246f47783cc"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("c25167e6-ad9e-4ae5-b94f-4c7969b780a3"));
            labelDescription = (ITTLabel)AddControl(new Guid("0bf8af97-f40c-471a-96fe-48ba84c5765c"));
            Description = (ITTTextBox)AddControl(new Guid("22ba1856-70d0-4f9f-b74b-18fce281bd24"));
            labelQuarantineProcessType = (ITTLabel)AddControl(new Guid("2508fb00-e1df-4c5b-bae1-dcdd88a505d9"));
            QuarantineProcessType = (ITTEnumComboBox)AddControl(new Guid("14a5c9c3-ed2e-456e-b9ed-d8337e198693"));
            base.InitializeControls();
        }

        public InpatientAdmissinDepositMaterialForm() : base("INPATIENTADMISSIONDEPOSITMATERIAL", "InpatientAdmissinDepositMaterialForm")
        {
        }

        protected InpatientAdmissinDepositMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}