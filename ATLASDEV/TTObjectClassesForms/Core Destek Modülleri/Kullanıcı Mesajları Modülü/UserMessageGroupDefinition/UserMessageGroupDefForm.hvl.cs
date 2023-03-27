
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
    /// Kullanıcı Grup Tanımı
    /// </summary>
    public partial class UserMessageGroupDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Kullanıcı Grupları
    /// </summary>
        protected TTObjectClasses.UserMessageGroupDefinition _UserMessageGroupDefinition
        {
            get { return (TTObjectClasses.UserMessageGroupDefinition)_ttObject; }
        }

        protected ITTLabel labelGroupType;
        protected ITTEnumComboBox GroupType;
        protected ITTLabel labelCondition;
        protected ITTTextBox Condition;
        protected ITTTextBox Caption;
        protected ITTLabel labelCaption;
        override protected void InitializeControls()
        {
            labelGroupType = (ITTLabel)AddControl(new Guid("062615d4-3e07-4065-b0ef-81b7a1e3f666"));
            GroupType = (ITTEnumComboBox)AddControl(new Guid("41c895d1-c387-454e-a03a-397a74e8b4c2"));
            labelCondition = (ITTLabel)AddControl(new Guid("137d349f-ffd3-4180-ad98-ffcbb5b71ef9"));
            Condition = (ITTTextBox)AddControl(new Guid("2446fe1d-44ba-4d42-9d2d-ff8e94a6c138"));
            Caption = (ITTTextBox)AddControl(new Guid("410bc338-d6f4-4ae3-b8dd-873cb3a15699"));
            labelCaption = (ITTLabel)AddControl(new Guid("a2723504-d7a9-4682-8f65-507b815e2be5"));
            base.InitializeControls();
        }

        public UserMessageGroupDefForm() : base("USERMESSAGEGROUPDEFINITION", "UserMessageGroupDefForm")
        {
        }

        protected UserMessageGroupDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}