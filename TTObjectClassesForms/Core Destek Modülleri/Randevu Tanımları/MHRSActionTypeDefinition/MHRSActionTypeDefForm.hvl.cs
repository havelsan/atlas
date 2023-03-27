
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
    public partial class MHRSActionTypeDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// MHRS Aksiyon Tipi Tanımları
    /// </summary>
        protected TTObjectClasses.MHRSActionTypeDefinition _MHRSActionTypeDefinition
        {
            get { return (TTObjectClasses.MHRSActionTypeDefinition)_ttObject; }
        }

        protected ITTCheckBox IsIstisnaType;
        protected ITTCheckBox IsDocumentRequired;
        protected ITTLabel labelDay;
        protected ITTTextBox Day;
        protected ITTTextBox ActionName;
        protected ITTTextBox ActionCode;
        protected ITTCheckBox OpenMHRS;
        protected ITTCheckBox Mustesna;
        protected ITTCheckBox IsWorkingHour;
        protected ITTLabel labelActionName;
        protected ITTLabel labelActionCode;
        override protected void InitializeControls()
        {
            IsIstisnaType = (ITTCheckBox)AddControl(new Guid("54e4cfaa-7649-4fbe-9164-19ef9c8febf6"));
            IsDocumentRequired = (ITTCheckBox)AddControl(new Guid("9ddfb98a-c2b2-48cf-a5f4-9e38229a612d"));
            labelDay = (ITTLabel)AddControl(new Guid("1de669cb-13ef-45d0-8eb8-678218958ebd"));
            Day = (ITTTextBox)AddControl(new Guid("53ac568b-dd15-4f8f-bbda-49533b254149"));
            ActionName = (ITTTextBox)AddControl(new Guid("c357f6eb-86f9-4917-9db3-4545c0f1d094"));
            ActionCode = (ITTTextBox)AddControl(new Guid("b186cd32-9a75-48da-b7a5-7d8587521474"));
            OpenMHRS = (ITTCheckBox)AddControl(new Guid("184389b3-faed-4b59-99da-481b5287dff4"));
            Mustesna = (ITTCheckBox)AddControl(new Guid("8f8ea152-8627-4e7b-8ceb-cd41a9a54d46"));
            IsWorkingHour = (ITTCheckBox)AddControl(new Guid("53225b1e-3931-44cb-ab54-e4afba636f5f"));
            labelActionName = (ITTLabel)AddControl(new Guid("6ff75682-19c2-45a4-8cdc-d7761034985c"));
            labelActionCode = (ITTLabel)AddControl(new Guid("da1b1b3c-8f36-456b-8877-2a01541f9781"));
            base.InitializeControls();
        }

        public MHRSActionTypeDefForm() : base("MHRSACTIONTYPEDEFINITION", "MHRSActionTypeDefForm")
        {
        }

        protected MHRSActionTypeDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}