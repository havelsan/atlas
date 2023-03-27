
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
    public partial class ArgeProjectPreClaimAppealForm : ArgeProjectNewForm
    {
    /// <summary>
    /// Proje Başvuru Formu
    /// </summary>
        protected TTObjectClasses.ArgeProject _ArgeProject
        {
            get { return (TTObjectClasses.ArgeProject)_ttObject; }
        }

        protected ITTTabPage tttabpage11;
        protected ITTLabel labelPreAssementResultProjectPreAssement;
        protected ITTTextBox PreAssementResultProjectPreAssement;
        override protected void InitializeControls()
        {
            tttabpage11 = (ITTTabPage)AddControl(new Guid("d13d9d8a-c3bb-46f0-ba58-3d29bf2dd837"));
            labelPreAssementResultProjectPreAssement = (ITTLabel)AddControl(new Guid("0913a56f-0d2e-4338-b6a7-22c1a749d785"));
            PreAssementResultProjectPreAssement = (ITTTextBox)AddControl(new Guid("8fecb6eb-6f1f-46cd-b0a5-8d0c58e2a4ff"));
            base.InitializeControls();
        }

        public ArgeProjectPreClaimAppealForm() : base("ARGEPROJECT", "ArgeProjectPreClaimAppealForm")
        {
        }

        protected ArgeProjectPreClaimAppealForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}