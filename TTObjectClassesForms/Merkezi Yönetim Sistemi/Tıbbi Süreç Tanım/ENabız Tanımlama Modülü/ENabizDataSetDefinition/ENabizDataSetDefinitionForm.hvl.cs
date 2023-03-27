
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
    /// E-Nabız Veri Seti Tanım Formu
    /// </summary>
    public partial class ENabizDataSetDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// ENabız Veri Seti Tanımları
    /// </summary>
        protected TTObjectClasses.ENabizDataSetDefinition _ENabizDataSetDefinition
        {
            get { return (TTObjectClasses.ENabizDataSetDefinition)_ttObject; }
        }

        protected ITTLabel labelMSVSCode;
        protected ITTTextBox MSVSCode;
        protected ITTTextBox PackageName;
        protected ITTTextBox PackageID;
        protected ITTLabel labelPackageName;
        protected ITTLabel labelPackageID;
        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            labelMSVSCode = (ITTLabel)AddControl(new Guid("cfc4d154-f961-468e-b638-7658515dde79"));
            MSVSCode = (ITTTextBox)AddControl(new Guid("00bed2f5-5d16-4b5a-bd9d-0496774c3406"));
            PackageName = (ITTTextBox)AddControl(new Guid("cc2efc57-2959-4fbc-af08-be4acc21bdb6"));
            PackageID = (ITTTextBox)AddControl(new Guid("67939046-ec6d-4ecd-ab24-71f6aa5fb16a"));
            labelPackageName = (ITTLabel)AddControl(new Guid("b8cdc5cc-0255-4bef-b77c-485ddbb55d7c"));
            labelPackageID = (ITTLabel)AddControl(new Guid("f6ecb6b7-3ec4-4644-82f7-4996e34ce13d"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("227555c8-e02d-4f33-b376-e28f227d3435"));
            base.InitializeControls();
        }

        public ENabizDataSetDefinitionForm() : base("ENABIZDATASETDEFINITION", "ENabizDataSetDefinitionForm")
        {
        }

        protected ENabizDataSetDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}