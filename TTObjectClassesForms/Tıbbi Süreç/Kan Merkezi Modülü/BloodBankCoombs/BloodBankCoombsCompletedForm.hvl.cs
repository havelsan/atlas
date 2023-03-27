
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
    /// Kan Bankası Coombs Testi Tamam Ekranı
    /// </summary>
    public partial class BloodBankCoombsCompletedForm : EpisodeActionForm
    {
    /// <summary>
    /// Coombs Testi
    /// </summary>
        protected TTObjectClasses.BloodBankCoombs _BloodBankCoombs
        {
            get { return (TTObjectClasses.BloodBankCoombs)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox4;
        protected ITTCheckBox ttcheckbox14;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox8;
        protected ITTLabel ttlabel5;
        protected ITTCheckBox ttcheckbox11;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel6;
        protected ITTCheckBox ttcheckbox6;
        protected ITTComboBox ttcombobox1;
        protected ITTCheckBox ttcheckbox9;
        protected ITTLabel ttlabel9;
        protected ITTCheckBox ttcheckbox7;
        protected ITTCheckBox ttcheckbox12;
        protected ITTCheckBox ttcheckbox3;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox ttcheckbox10;
        protected ITTComboBox ttcombobox4;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTComboBox ttcombobox2;
        protected ITTCheckBox ttcheckbox5;
        protected ITTLabel ttlabel4;
        protected ITTComboBox ttcombobox3;
        protected ITTComboBox ttcombobox5;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox ttcheckbox13;
        protected ITTLabel ttlabel10;
        protected ITTCheckBox ttcheckbox2;
        protected ITTGroupBox ttgroupbox2;
        override protected void InitializeControls()
        {
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("ccb3bb6d-3256-455a-a271-099feab6bb58"));
            ttcheckbox14 = (ITTCheckBox)AddControl(new Guid("1aaf68d6-4730-4c22-bec9-ffbd62036049"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("4a68ddbd-4c19-4b2b-9594-ed7712f82bdf"));
            ttcheckbox8 = (ITTCheckBox)AddControl(new Guid("41f4d0bc-992f-4124-8a5a-ef04db52cc56"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("20a6c417-ea0c-4c8d-a40d-f513c49c48ed"));
            ttcheckbox11 = (ITTCheckBox)AddControl(new Guid("50cdc5c2-8ce3-4c56-b048-c06b1224d144"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e1c4c775-4da9-4229-a3f3-cd6e0fef3c29"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("ea14e97a-4410-4c29-b8b8-afae108a3563"));
            ttcheckbox6 = (ITTCheckBox)AddControl(new Guid("db03a9ba-74ff-4316-8913-7e1c2dd7c31c"));
            ttcombobox1 = (ITTComboBox)AddControl(new Guid("dd6c9bf6-d0a5-4237-ab48-8ed82fff435b"));
            ttcheckbox9 = (ITTCheckBox)AddControl(new Guid("c9717aeb-bf1e-4164-aec7-7b30aa4f7e76"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("6ca92182-522c-4891-8889-97578efbad2c"));
            ttcheckbox7 = (ITTCheckBox)AddControl(new Guid("1f5a0d5e-ebe8-445b-a7f7-9e5285037a2b"));
            ttcheckbox12 = (ITTCheckBox)AddControl(new Guid("dbace3fd-9002-4233-a2fe-a1bb867ad4b9"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("70abb2ee-bf5d-4d6e-a6aa-89165fcc2d3f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3b2f58a4-905c-4a3c-8717-568caa7c29ec"));
            ttcheckbox10 = (ITTCheckBox)AddControl(new Guid("c3400414-5f98-4ac9-b11b-68e9f42e5090"));
            ttcombobox4 = (ITTComboBox)AddControl(new Guid("12c577b9-74c3-4bf9-94a0-81a9c591bebd"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("7e89d8a7-8a8e-4a8c-9a95-4d330f063f7d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6f8baad8-d4d5-4964-aacb-4d289e35db59"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3466aa08-2977-4173-937f-3ba304295b5a"));
            ttcombobox2 = (ITTComboBox)AddControl(new Guid("50220666-171b-44ee-b606-2d11df9d8c85"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("c9a62aea-a774-4b42-90f6-2af4c1a38016"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("827208bb-f310-442c-85df-235ca13127b0"));
            ttcombobox3 = (ITTComboBox)AddControl(new Guid("8cb433e2-443b-4c12-b427-1afa902f1751"));
            ttcombobox5 = (ITTComboBox)AddControl(new Guid("bd8151b2-15b9-4756-9c53-0870a933e22d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("615fa23a-07ea-42b8-b9fe-1f86fdeacb3d"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("b012e4f8-fd13-41aa-8639-1cab15f60f6d"));
            ttcheckbox13 = (ITTCheckBox)AddControl(new Guid("d1c7874d-e83c-4df9-a938-2c4962178e38"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("aa8c6144-9b11-421c-8759-0fcb9bc348a4"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("d40d763c-ab35-4023-a600-fb2adc888c73"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("44e6c835-95eb-4530-ac8e-ea00b06cf0d0"));
            base.InitializeControls();
        }

        public BloodBankCoombsCompletedForm() : base("BLOODBANKCOOMBS", "BloodBankCoombsCompletedForm")
        {
        }

        protected BloodBankCoombsCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}