
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
    public partial class HCDutyTypeForm : TTDefinitionForm
    {
    /// <summary>
    /// Sağlık Kurulu Görev Tanımları
    /// </summary>
        protected TTObjectClasses.HCDutyTypeDef _HCDutyTypeDef
        {
            get { return (TTObjectClasses.HCDutyTypeDef)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("2a697b5d-4c12-4ae6-b1c6-26f3bd6a80df"));
            Name = (ITTTextBox)AddControl(new Guid("b4dca693-f431-4576-bca2-56e3975636df"));
            Code = (ITTTextBox)AddControl(new Guid("5f94a415-0473-49c1-83c0-171f336c8df6"));
            labelCode = (ITTLabel)AddControl(new Guid("4ff2f287-4ea7-4f71-ba93-2669d271e55f"));
            base.InitializeControls();
        }

        public HCDutyTypeForm() : base("HCDUTYTYPEDEF", "HCDutyTypeForm")
        {
        }

        protected HCDutyTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}