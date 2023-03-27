
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
    /// SKRS Enum Eşleştirmeleri
    /// </summary>
    public partial class SKRSEnumMatchForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SKRSEnumMatchDefinition _SKRSEnumMatchDefinition
        {
            get { return (TTObjectClasses.SKRSEnumMatchDefinition)_ttObject; }
        }

        protected ITTLabel labelSKRSDefinition;
        protected ITTObjectListBox SKRSDefinition;
        protected ITTLabel labelSKRSDefinitionObjectId;
        protected ITTTextBox SKRSDefinitionObjectId;
        protected ITTTextBox EnumValue;
        protected ITTLabel labelEnumValue;
        override protected void InitializeControls()
        {
            labelSKRSDefinition = (ITTLabel)AddControl(new Guid("c56bc68c-d181-443a-abd3-414c8dfc1688"));
            SKRSDefinition = (ITTObjectListBox)AddControl(new Guid("0482f88c-1f49-4fd2-9c6b-49058a565057"));
            labelSKRSDefinitionObjectId = (ITTLabel)AddControl(new Guid("413d77e8-91d0-4d26-8242-34adb3bbe355"));
            SKRSDefinitionObjectId = (ITTTextBox)AddControl(new Guid("b0a9b168-fee1-4614-9c5b-e6907b20d049"));
            EnumValue = (ITTTextBox)AddControl(new Guid("e89d054d-c0f9-429c-8fee-f5b06d93e44f"));
            labelEnumValue = (ITTLabel)AddControl(new Guid("17a013f7-c3b0-4d26-8fa4-d44de9fc00cf"));
            base.InitializeControls();
        }

        public SKRSEnumMatchForm() : base("SKRSENUMMATCHDEFINITION", "SKRSEnumMatchForm")
        {
        }

        protected SKRSEnumMatchForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}