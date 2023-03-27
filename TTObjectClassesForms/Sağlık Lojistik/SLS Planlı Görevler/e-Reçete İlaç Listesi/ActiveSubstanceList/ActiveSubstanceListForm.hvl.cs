
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
    public partial class ActiveSubstanceListForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Etkin Madde Listesi
    /// </summary>
        protected TTObjectClasses.ActiveSubstanceList _ActiveSubstanceList
        {
            get { return (TTObjectClasses.ActiveSubstanceList)_ttObject; }
        }

        protected ITTTextBox FilePath;
        protected ITTButton btnChoose;
        protected ITTLabel labelFilePath;
        override protected void InitializeControls()
        {
            FilePath = (ITTTextBox)AddControl(new Guid("00214688-f462-4190-8c3f-afab2e8cb722"));
            btnChoose = (ITTButton)AddControl(new Guid("ae778fc1-7aa0-49be-863f-afa735fd718a"));
            labelFilePath = (ITTLabel)AddControl(new Guid("df489c0a-1a15-4a6f-a5c5-1e2ef3a6d661"));
            base.InitializeControls();
        }

        public ActiveSubstanceListForm() : base("ACTIVESUBSTANCELIST", "ActiveSubstanceListForm")
        {
        }

        protected ActiveSubstanceListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}