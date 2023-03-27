
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
    /// Ana Hasta Grup Tanımı
    /// </summary>
    public partial class MainPatientGroupDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.MainPatientGroupDefinition _MainPatientGroupDefinition
        {
            get { return (TTObjectClasses.MainPatientGroupDefinition)_ttObject; }
        }

        protected ITTLabel labelMainPatientGroupEnum;
        protected ITTEnumComboBox MainPatientGroupEnum;
        protected ITTLabel labelOrderNo;
        protected ITTTextBox OrderNo;
        protected ITTCheckBox AllowAdmissionFromSite;
        override protected void InitializeControls()
        {
            labelMainPatientGroupEnum = (ITTLabel)AddControl(new Guid("75daa5a0-99f7-477a-ad71-21d557077420"));
            MainPatientGroupEnum = (ITTEnumComboBox)AddControl(new Guid("7ebae605-9523-4023-a838-bb0cb8dad346"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("3ce9035c-1248-44b6-b5c4-63db0cf70eca"));
            OrderNo = (ITTTextBox)AddControl(new Guid("2c20a3f6-1934-4a02-ba3c-cf9d67c50ddf"));
            AllowAdmissionFromSite = (ITTCheckBox)AddControl(new Guid("02b33171-63e3-47b6-b7a2-2e33e7326f00"));
            base.InitializeControls();
        }

        public MainPatientGroupDefinitionForm() : base("MAINPATIENTGROUPDEFINITION", "MainPatientGroupDefinitionForm")
        {
        }

        protected MainPatientGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}