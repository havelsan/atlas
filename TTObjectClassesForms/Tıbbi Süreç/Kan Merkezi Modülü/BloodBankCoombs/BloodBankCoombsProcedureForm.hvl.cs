
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
    /// Kan Bankası Coombs Testi Prosedür Ekranı
    /// </summary>
    public partial class BloodBankCoombsProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Coombs Testi
    /// </summary>
        protected TTObjectClasses.BloodBankCoombs _BloodBankCoombs
        {
            get { return (TTObjectClasses.BloodBankCoombs)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox9;
        protected ITTCheckBox ttcheckbox7;
        protected ITTComboBox ttcombobox3;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox4;
        protected ITTComboBox ttcombobox1;
        protected ITTCheckBox ttcheckbox1;
        protected ITTComboBox ttcombobox2;
        protected ITTLabel ttlabel10;
        protected ITTCheckBox ttcheckbox10;
        protected ITTLabel ttlabel6;
        protected ITTComboBox ttcombobox5;
        protected ITTLabel ttlabel8;
        protected ITTComboBox ttcombobox4;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel5;
        protected ITTCheckBox ttcheckbox3;
        protected ITTCheckBox ttcheckbox12;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox ttcheckbox2;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox ttcheckbox11;
        protected ITTCheckBox ttcheckbox6;
        protected ITTCheckBox ttcheckbox5;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox ttcheckbox8;
        protected ITTLabel ttlabel9;
        protected ITTCheckBox ttcheckbox13;
        protected ITTCheckBox ttcheckbox14;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("a4d15645-f7f7-4672-82ec-0376cd90ae7f"));
            ttcheckbox9 = (ITTCheckBox)AddControl(new Guid("ab99d4fa-3c62-484f-91bf-fc1a2ade558e"));
            ttcheckbox7 = (ITTCheckBox)AddControl(new Guid("050e64c0-816c-4ab3-86fe-ed73ef8954ef"));
            ttcombobox3 = (ITTComboBox)AddControl(new Guid("1f06a33b-c60d-49af-9c7e-e6794d4e8b0c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("41422ae9-d200-4683-b7c8-ca82198b0397"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("aba3f551-3338-49eb-a279-ce6fa0e7bebe"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("81af1980-ab79-4d39-bc42-ba2e7d4085d6"));
            ttcombobox1 = (ITTComboBox)AddControl(new Guid("82939b24-1dfc-4e37-bbd2-bc6cb63e7a5c"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("1a6055e5-01d5-4125-aef3-8b1b92764516"));
            ttcombobox2 = (ITTComboBox)AddControl(new Guid("6299e13b-bfaf-4c75-8f15-9a680ca9ee0d"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("49239156-c1e3-47b7-9ff4-a7e9b0c34152"));
            ttcheckbox10 = (ITTCheckBox)AddControl(new Guid("914e8b29-8c23-4463-9868-9923ea44a2a2"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("6e6bcf2e-6c6f-4e93-9f0b-9156169ecf9e"));
            ttcombobox5 = (ITTComboBox)AddControl(new Guid("c7ed3dfa-4413-450a-ac0d-97b87da9dd52"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("f88655f3-9e01-4684-b63a-55d25c52b987"));
            ttcombobox4 = (ITTComboBox)AddControl(new Guid("ac54b359-65e2-4764-9347-84b881ee1c08"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("534d753a-dcf3-4997-98f4-5645f22aaddf"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a379e138-97c6-4aaa-a402-552f80ffacc7"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("d59920ba-2870-4cd7-83f6-6d40a87d3806"));
            ttcheckbox12 = (ITTCheckBox)AddControl(new Guid("58ffa168-79bd-4529-9810-49c14843b6cc"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6b236c4f-5838-4d94-b3af-510891fb5a3f"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("0c37ba86-d078-4790-b59a-32f6010dc7ce"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("3f24364a-63a6-46d9-a8f6-2597cb0f60de"));
            ttcheckbox11 = (ITTCheckBox)AddControl(new Guid("8f7e127f-81bd-4005-aad4-3c5be2b9601a"));
            ttcheckbox6 = (ITTCheckBox)AddControl(new Guid("c0db04b2-636a-4e81-921c-15934e3c79f6"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("608ffae7-1521-4e86-8816-1f200499c79c"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("806278ad-4615-4975-96fe-14ba5d88857e"));
            ttcheckbox8 = (ITTCheckBox)AddControl(new Guid("b07dc50c-9e56-4c32-b02c-05b5df6c1d2d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("68d6690e-1ca5-4491-b81b-0b35f6d683d3"));
            ttcheckbox13 = (ITTCheckBox)AddControl(new Guid("d902b41e-8820-40cd-999e-07bbed5ab9c1"));
            ttcheckbox14 = (ITTCheckBox)AddControl(new Guid("afa6fbdf-5afe-4c6d-ba7c-f50748b60699"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("01c0207d-15fb-489d-a7ee-ef2662a208cb"));
            base.InitializeControls();
        }

        public BloodBankCoombsProcedureForm() : base("BLOODBANKCOOMBS", "BloodBankCoombsProcedureForm")
        {
        }

        protected BloodBankCoombsProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}