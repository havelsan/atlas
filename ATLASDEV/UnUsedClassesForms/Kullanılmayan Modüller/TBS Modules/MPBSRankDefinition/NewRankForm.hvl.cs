
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
    /// Rütbe Tanımlama
    /// </summary>
    public partial class NewRankForm : TTForm
    {
    /// <summary>
    /// Rütbe Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSRankDefinition _MPBSRankDefinition
        {
            get { return (TTObjectClasses.MPBSRankDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("c273440a-09ee-464a-996a-3709a87fca4a"));
            Name = (ITTTextBox)AddControl(new Guid("5d537b06-2c80-41d1-8ac4-95dbaef38119"));
            base.InitializeControls();
        }

        public NewRankForm() : base("MPBSRANKDEFINITION", "NewRankForm")
        {
        }

        protected NewRankForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}