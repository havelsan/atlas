
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
    /// Kullanıcı Mesaj Grubu Tanımı
    /// </summary>
    public partial class UserMessageGroupDefNewForm : TTDefinitionForm
    {
    /// <summary>
    /// Kullanıcı Grupları
    /// </summary>
        protected TTObjectClasses.UserMessageGroupDefinition _UserMessageGroupDefinition
        {
            get { return (TTObjectClasses.UserMessageGroupDefinition)_ttObject; }
        }

        protected ITTGrid UserMessageGroupUsers;
        protected ITTListBoxColumn ResUserUserMessageGroupUsers;
        protected ITTLabel labelCaption;
        protected ITTTextBox Caption;
        override protected void InitializeControls()
        {
            UserMessageGroupUsers = (ITTGrid)AddControl(new Guid("62c020d5-db90-4bf7-92bc-1871144980bd"));
            ResUserUserMessageGroupUsers = (ITTListBoxColumn)AddControl(new Guid("f32d4503-cd96-43d5-91cd-631c9fd2ccab"));
            labelCaption = (ITTLabel)AddControl(new Guid("4f810371-ca08-457a-b240-6db6f9b12962"));
            Caption = (ITTTextBox)AddControl(new Guid("9c34e012-a525-4535-b1ad-ffe4339bba47"));
            base.InitializeControls();
        }

        public UserMessageGroupDefNewForm() : base("USERMESSAGEGROUPDEFINITION", "UserMessageGroupDefNewForm")
        {
        }

        protected UserMessageGroupDefNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}