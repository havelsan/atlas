
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
    /// Karantina Dolap Tanımı
    /// </summary>
    public partial class CupboardDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Tıbbi Kayıt Dolap Tanımlama
    /// </summary>
        protected TTObjectClasses.CupboardDefinition _CupboardDefinition
        {
            get { return (TTObjectClasses.CupboardDefinition)_ttObject; }
        }

        protected ITTLabel labelCupboardName;
        protected ITTTextBox CupboardName;
        override protected void InitializeControls()
        {
            labelCupboardName = (ITTLabel)AddControl(new Guid("17cf5302-9be8-4dca-a283-791ab0c355a8"));
            CupboardName = (ITTTextBox)AddControl(new Guid("bb264494-3139-4df9-8f79-809b4d36f396"));
            base.InitializeControls();
        }

        public CupboardDefinitionForm() : base("CUPBOARDDEFINITION", "CupboardDefinitionForm")
        {
        }

        protected CupboardDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}