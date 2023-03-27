
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
    public partial class ENabizPackageDefinitionsForm : TTDefinitionForm
    {
        protected TTObjectClasses.ENabizPackageDefinition _ENabizPackageDefinition
        {
            get { return (TTObjectClasses.ENabizPackageDefinition)_ttObject; }
        }

        protected ITTLabel labelPackageName;
        protected ITTTextBox PackageName;
        protected ITTTextBox PackageID;
        protected ITTLabel labelPackageID;
        override protected void InitializeControls()
        {
            labelPackageName = (ITTLabel)AddControl(new Guid("8696278b-f8fa-4a2e-a9e7-a45f96193a99"));
            PackageName = (ITTTextBox)AddControl(new Guid("3641501f-5ace-40f5-ace1-d8dbaf02de1c"));
            PackageID = (ITTTextBox)AddControl(new Guid("8da0d0a7-6686-4bba-8abe-51c255969098"));
            labelPackageID = (ITTLabel)AddControl(new Guid("2e804cf2-ba24-420b-ac86-c460bb106b74"));
            base.InitializeControls();
        }

        public ENabizPackageDefinitionsForm() : base("ENABIZPACKAGEDEFINITION", "ENabizPackageDefinitionsForm")
        {
        }

        protected ENabizPackageDefinitionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}