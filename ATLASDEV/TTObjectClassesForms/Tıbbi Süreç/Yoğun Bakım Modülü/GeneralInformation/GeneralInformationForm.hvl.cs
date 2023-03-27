
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
    public partial class GeneralInformationForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.GeneralInformation _GeneralInformation
        {
            get { return (TTObjectClasses.GeneralInformation)_ttObject; }
        }

        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelTreatmentPlan;
        protected ITTTextBox TreatmentPlan;
        protected ITTTextBox SuckingReflex;
        protected ITTTextBox Skin;
        protected ITTTextBox Prenatal;
        protected ITTTextBox Postnatal;
        protected ITTTextBox NavelCord;
        protected ITTTextBox Navel;
        protected ITTTextBox Natal;
        protected ITTTextBox Murmur;
        protected ITTTextBox AnalRegion;
        protected ITTLabel labelSuckingReflex;
        protected ITTLabel labelSkin;
        protected ITTLabel labelPrenatal;
        protected ITTLabel labelPostnatal;
        protected ITTLabel labelNavelCord;
        protected ITTLabel labelNavel;
        protected ITTLabel labelNatal;
        protected ITTLabel labelMurmur;
        protected ITTLabel labelAnalRegion;
        override protected void InitializeControls()
        {
            labelEntryDate = (ITTLabel)AddControl(new Guid("234f329f-61e1-4e5d-b5f1-4ceb720d6ea6"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("b6850044-d446-4bb7-ad8c-94fba4a27580"));
            labelTreatmentPlan = (ITTLabel)AddControl(new Guid("d50e5ef9-c940-4c84-8649-89b340b9860b"));
            TreatmentPlan = (ITTTextBox)AddControl(new Guid("cd99b09b-7875-484b-ad7e-84366268e310"));
            SuckingReflex = (ITTTextBox)AddControl(new Guid("8a2778a0-d58c-41dd-b2dc-a1e22b949565"));
            Skin = (ITTTextBox)AddControl(new Guid("fbb1d2e5-41a0-49bf-b667-951d4efdae8c"));
            Prenatal = (ITTTextBox)AddControl(new Guid("6b343db6-e54e-421e-b529-ab6a305e32b1"));
            Postnatal = (ITTTextBox)AddControl(new Guid("57860241-087a-4f4a-8cc9-ad5d0024dd35"));
            NavelCord = (ITTTextBox)AddControl(new Guid("df93f703-54e9-41dd-bbb4-99fe03ecf922"));
            Navel = (ITTTextBox)AddControl(new Guid("c0de16a9-2cac-4e84-8399-871ea36bd63b"));
            Natal = (ITTTextBox)AddControl(new Guid("ac155752-25bd-4a83-ae8e-b08d8c7783fe"));
            Murmur = (ITTTextBox)AddControl(new Guid("d6b055f6-3a51-46d5-a6b1-5305307e45cd"));
            AnalRegion = (ITTTextBox)AddControl(new Guid("52bb5ca3-f3eb-460b-8e8d-c6f7c885406d"));
            labelSuckingReflex = (ITTLabel)AddControl(new Guid("ceaa4fd6-7e36-4123-a5c2-00cc3e1abb9b"));
            labelSkin = (ITTLabel)AddControl(new Guid("8a37ac8e-d182-43c7-94ab-7c859924a36e"));
            labelPrenatal = (ITTLabel)AddControl(new Guid("cfb4b84a-36b3-428e-9cc5-bc347ae39e57"));
            labelPostnatal = (ITTLabel)AddControl(new Guid("d1ba1565-ae1b-4ce4-afb7-fd4ec6b5d13f"));
            labelNavelCord = (ITTLabel)AddControl(new Guid("29523fa2-ea18-46e0-8288-2d85003ede88"));
            labelNavel = (ITTLabel)AddControl(new Guid("9daaad15-90b9-4c3c-9906-2a16b07154cc"));
            labelNatal = (ITTLabel)AddControl(new Guid("7d1cb8c4-4c3d-443b-860d-f0a5d8e3a3c0"));
            labelMurmur = (ITTLabel)AddControl(new Guid("89ec9e8f-0f13-4808-8aa3-6f412387420b"));
            labelAnalRegion = (ITTLabel)AddControl(new Guid("58028448-0dff-4c1e-8314-1229a4828ea6"));
            base.InitializeControls();
        }

        public GeneralInformationForm() : base("GENERALINFORMATION", "GeneralInformationForm")
        {
        }

        protected GeneralInformationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}