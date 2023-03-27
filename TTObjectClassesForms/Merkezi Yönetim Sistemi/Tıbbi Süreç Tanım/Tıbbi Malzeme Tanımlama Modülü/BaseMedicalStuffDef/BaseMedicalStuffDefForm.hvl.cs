
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
    /// TIBBİ MALZEME TANIMLAMA
    /// </summary>
    public partial class BaseMedicalStuffDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.BaseMedicalStuffDef _BaseMedicalStuffDef
        {
            get { return (TTObjectClasses.BaseMedicalStuffDef)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox txtName;
        protected ITTTextBox txtCode;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("497b2c07-b37c-4ac9-b472-831c35f26f84"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8358b221-7da9-4915-a2d0-070012e985f6"));
            txtName = (ITTTextBox)AddControl(new Guid("892e8574-b328-4c78-9970-6db435b08e1d"));
            txtCode = (ITTTextBox)AddControl(new Guid("73beea17-0d3f-4722-8161-4e4559f74ada"));
            base.InitializeControls();
        }

        public BaseMedicalStuffDefForm() : base("BASEMEDICALSTUFFDEF", "BaseMedicalStuffDefForm")
        {
        }

        protected BaseMedicalStuffDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}