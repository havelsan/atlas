
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
    /// New Form
    /// </summary>
    public partial class SutForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// SUT Tanımlama
    /// </summary>
        protected TTObjectClasses.SUTDefinition _SUTDefinition
        {
            get { return (TTObjectClasses.SUTDefinition)_ttObject; }
        }

        protected ITTObjectListBox SutList;
        override protected void InitializeControls()
        {
            SutList = (ITTObjectListBox)AddControl(new Guid("5d591508-30a4-4eb8-8d5c-9bc8d0d0b8d0"));
            base.InitializeControls();
        }

        public SutForm() : base("SUTDEFINITION", "SutForm")
        {
        }

        protected SutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}