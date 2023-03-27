
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
    /// Kan Bankası Alt Grup Test Tamam Ekranı
    /// </summary>
    public partial class BloodBankSubGroupCompletedForm : EpisodeActionForm
    {
    /// <summary>
    /// Alt Grup
    /// </summary>
        protected TTObjectClasses.BloodBankSubGroup _BloodBankSubGroup
        {
            get { return (TTObjectClasses.BloodBankSubGroup)_ttObject; }
        }

        protected ITTTextBox tttextbox3;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistbox1;
        protected ITTTextBoxColumn tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTTextBox texbox1289;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            tttextbox3 = (ITTTextBox)AddControl(new Guid("8f4d909a-3d7a-4469-98ac-0155562843c3"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("49de1871-b96c-46f4-9edb-11c18669dd9d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("8be4b3ab-62da-4bc8-8706-ab9e7c31d9ee"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("4a6e7da2-c252-4ae1-88b2-3d2cf41a6b76"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("115809e9-457b-4136-bac5-c51f0e8fb483"));
            tttextbox1 = (ITTTextBoxColumn)AddControl(new Guid("0a179f61-e654-447d-bcf7-59ad99c2a08c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c91d0ffa-49f0-4c44-8ef7-19b05a5d2da7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("52da39e2-d5a5-4c30-9eab-347a5785a488"));
            texbox1289 = (ITTTextBox)AddControl(new Guid("21ce899a-cb0f-426d-9948-3b8ce5f81a76"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("2c441b98-fe10-4f55-ab5a-9120909ddcfa"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1161945c-a7a0-4998-8268-da9fe810502c"));
            base.InitializeControls();
        }

        public BloodBankSubGroupCompletedForm() : base("BLOODBANKSUBGROUP", "BloodBankSubGroupCompletedForm")
        {
        }

        protected BloodBankSubGroupCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}