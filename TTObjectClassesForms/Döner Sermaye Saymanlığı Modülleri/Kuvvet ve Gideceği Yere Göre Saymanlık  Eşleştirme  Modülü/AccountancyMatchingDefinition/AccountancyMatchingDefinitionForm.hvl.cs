
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
    /// Kuvvet ve Gideceği Yere Göre Saymanlık  Eşleştirme  
    /// </summary>
    public partial class AccountancyMatchingDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.AccountancyMatchingDefinition _AccountancyMatchingDefinition
        {
            get { return (TTObjectClasses.AccountancyMatchingDefinition)_ttObject; }
        }

        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelSendToResource;
        protected ITTObjectListBox SendToResource;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox ForcesCommand;
        override protected void InitializeControls()
        {
            labelAccountancy = (ITTLabel)AddControl(new Guid("52e39f0b-47c9-480b-ac92-0e32696ec0ab"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("8bc4717b-16e7-43d6-b3ae-ddb93bb4c265"));
            labelSendToResource = (ITTLabel)AddControl(new Guid("3366697a-86e6-457b-8ac6-f19fc4175176"));
            SendToResource = (ITTObjectListBox)AddControl(new Guid("74f39a56-1fe4-46b0-ad7a-47bc855d55ae"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("3c6c059e-46f5-4cc3-8333-8728048e9f30"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("c4c1ad57-1467-4926-988f-c590cd717500"));
            base.InitializeControls();
        }

        public AccountancyMatchingDefinitionForm() : base("ACCOUNTANCYMATCHINGDEFINITION", "AccountancyMatchingDefinitionForm")
        {
        }

        protected AccountancyMatchingDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}