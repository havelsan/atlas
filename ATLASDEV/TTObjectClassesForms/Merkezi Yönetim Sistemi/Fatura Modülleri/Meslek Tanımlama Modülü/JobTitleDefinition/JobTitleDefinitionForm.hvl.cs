
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
    /// Meslek Tanımlama Formu
    /// </summary>
    public partial class JobTitleDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Meslek Tanımları
    /// </summary>
        protected TTObjectClasses.JobTitleDefinition _JobTitleDefinition
        {
            get { return (TTObjectClasses.JobTitleDefinition)_ttObject; }
        }

        protected ITTLabel labelUSERTYPE;
        protected ITTEnumComboBox USERTYPE;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelCODE;
        protected ITTTextBox CODE;
        override protected void InitializeControls()
        {
            labelUSERTYPE = (ITTLabel)AddControl(new Guid("7d072e9f-caa0-41bb-a2cb-02cb3a8518d8"));
            USERTYPE = (ITTEnumComboBox)AddControl(new Guid("a79c57c9-6ab9-4f67-8ddd-8ba45047f438"));
            labelName = (ITTLabel)AddControl(new Guid("d0145454-c75d-4c6e-8947-0eb973ba46b1"));
            Name = (ITTTextBox)AddControl(new Guid("b8213069-a889-4cb7-8d18-3641805a83bc"));
            labelID = (ITTLabel)AddControl(new Guid("9079ca01-b61a-4a53-ad75-0dbf20412aee"));
            ID = (ITTTextBox)AddControl(new Guid("bb088ad9-6f1d-41a7-9b83-772ab941c8c0"));
            labelCODE = (ITTLabel)AddControl(new Guid("4779a0d3-6407-4fb6-b9fe-4fc30ec1a191"));
            CODE = (ITTTextBox)AddControl(new Guid("166fb4d6-7f06-45ce-9d48-c629e04a8b56"));
            base.InitializeControls();
        }

        public JobTitleDefinitionForm() : base("JOBTITLEDEFINITION", "JobTitleDefinitionForm")
        {
        }

        protected JobTitleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}