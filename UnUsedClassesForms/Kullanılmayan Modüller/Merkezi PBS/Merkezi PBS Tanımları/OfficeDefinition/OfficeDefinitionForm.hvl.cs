
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
    public partial class OfficeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.OfficeDefinition _OfficeDefinition
        {
            get { return (TTObjectClasses.OfficeDefinition)_ttObject; }
        }

        protected ITTLabel labelSEQUENCE;
        protected ITTTextBox SEQUENCE;
        protected ITTTextBox SHORT_NAME;
        protected ITTTextBox PCODE;
        protected ITTTextBox NAME;
        protected ITTCheckBox ttcheckboxActive;
        protected ITTLabel Birimi;
        protected ITTObjectListBox UnitId;
        protected ITTLabel labelSHORT_NAME;
        protected ITTLabel labelPCODE;
        protected ITTLabel labelNAME;
        override protected void InitializeControls()
        {
            labelSEQUENCE = (ITTLabel)AddControl(new Guid("c28c6388-b591-42d3-96da-39283c15f1ce"));
            SEQUENCE = (ITTTextBox)AddControl(new Guid("eb48f894-a6ce-4341-87e5-7b3b21fe012f"));
            SHORT_NAME = (ITTTextBox)AddControl(new Guid("7bb30612-3d3e-4971-bf92-0dd4f081de2c"));
            PCODE = (ITTTextBox)AddControl(new Guid("e2f4f6fd-063b-442c-a899-89a808a35317"));
            NAME = (ITTTextBox)AddControl(new Guid("750c254f-f9f6-44ba-ae4a-de5e94bf827e"));
            ttcheckboxActive = (ITTCheckBox)AddControl(new Guid("32f64819-189d-49ec-97a9-b5c6a6cb68eb"));
            Birimi = (ITTLabel)AddControl(new Guid("6453824b-adfa-41a1-b8bb-2892d9e2c019"));
            UnitId = (ITTObjectListBox)AddControl(new Guid("403ca56f-8206-4088-8c36-2eab7bd2b73d"));
            labelSHORT_NAME = (ITTLabel)AddControl(new Guid("b7f1b90e-94f5-4a8c-93b0-5008e3ec8753"));
            labelPCODE = (ITTLabel)AddControl(new Guid("23cb2528-8d9e-4831-9da0-7fb240f57536"));
            labelNAME = (ITTLabel)AddControl(new Guid("d1a8d14a-0549-46c6-b1d0-42d68316ce20"));
            base.InitializeControls();
        }

        public OfficeDefinitionForm() : base("OFFICEDEFINITION", "OfficeDefinitionForm")
        {
        }

        protected OfficeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}