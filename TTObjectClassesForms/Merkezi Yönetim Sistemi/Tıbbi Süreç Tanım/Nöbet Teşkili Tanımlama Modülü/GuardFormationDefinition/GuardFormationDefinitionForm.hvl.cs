
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
    /// Nöbet Teşkili Tanımları Formu
    /// </summary>
    public partial class GuardFormationDefinitionForm : TTForm
    {
    /// <summary>
    /// Nöbet Teşkili Tanımları
    /// </summary>
        protected TTObjectClasses.GuardFormationDefinition _GuardFormationDefinition
        {
            get { return (TTObjectClasses.GuardFormationDefinition)_ttObject; }
        }

        public GuardFormationDefinitionForm() : base("GUARDFORMATIONDEFINITION", "GuardFormationDefinitionForm")
        {
        }

        protected GuardFormationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}