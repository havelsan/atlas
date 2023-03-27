
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
    public partial class RadiologyRequestDentalToothSchema : TTForm
    {
    /// <summary>
    /// Radyoloji
    /// </summary>
        protected TTObjectClasses.Radiology _Radiology
        {
            get { return (TTObjectClasses.Radiology)_ttObject; }
        }

        protected ITTPanel panelTooth;
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton1;
        protected ITTCheckBox ch18;
        protected ITTCheckBox ch17;
        protected ITTCheckBox ch16;
        protected ITTCheckBox ch15;
        protected ITTCheckBox ch14;
        protected ITTCheckBox ch13;
        protected ITTCheckBox ch12;
        protected ITTCheckBox ch31;
        protected ITTCheckBox ch32;
        protected ITTCheckBox ch75;
        protected ITTCheckBox ch33;
        protected ITTCheckBox ch74;
        protected ITTCheckBox ch34;
        protected ITTCheckBox ch81;
        protected ITTCheckBox ch35;
        protected ITTCheckBox ch73;
        protected ITTCheckBox ch36;
        protected ITTCheckBox ch82;
        protected ITTCheckBox ch37;
        protected ITTCheckBox ch72;
        protected ITTCheckBox ch38;
        protected ITTCheckBox ch48;
        protected ITTCheckBox ch71;
        protected ITTCheckBox ch83;
        protected ITTCheckBox ch65;
        protected ITTCheckBox ch84;
        protected ITTCheckBox ch47;
        protected ITTCheckBox ch85;
        protected ITTCheckBox ch64;
        protected ITTCheckBox ch46;
        protected ITTCheckBox ch45;
        protected ITTCheckBox ch63;
        protected ITTCheckBox ch44;
        protected ITTCheckBox ch62;
        protected ITTCheckBox ch43;
        protected ITTCheckBox ch61;
        protected ITTCheckBox ch42;
        protected ITTCheckBox ch51;
        protected ITTCheckBox ch41;
        protected ITTCheckBox ch52;
        protected ITTCheckBox ch53;
        protected ITTCheckBox ch54;
        protected ITTCheckBox ch55;
        protected ITTCheckBox ch28;
        protected ITTCheckBox ch11;
        protected ITTCheckBox ch21;
        protected ITTCheckBox ch27;
        protected ITTCheckBox ch26;
        protected ITTCheckBox ch25;
        protected ITTCheckBox ch24;
        protected ITTCheckBox ch23;
        protected ITTCheckBox ch22;
        protected ITTCheckBox ch3;
        protected ITTCheckBox ch4;
        protected ITTCheckBox ch6;
        protected ITTCheckBox ch5;
        protected ITTCheckBox ch7;
        protected ITTCheckBox ch2;
        protected ITTCheckBox ch1;
        override protected void InitializeControls()
        {
            panelTooth = (ITTPanel)AddControl(new Guid("4c3d49e9-d9f7-48de-85a7-e4f2c3b8ff76"));
            ttbutton2 = (ITTButton)AddControl(new Guid("6f11eda5-8750-4468-af27-c9cd458c62b6"));
            ttbutton1 = (ITTButton)AddControl(new Guid("32be6c6d-fc2c-4a8e-9d8e-ce183f069d6d"));
            ch18 = (ITTCheckBox)AddControl(new Guid("d8e492dd-8a95-4b8b-9ff0-4725d0862ccf"));
            ch17 = (ITTCheckBox)AddControl(new Guid("d804f8fe-c5dd-4969-9569-77b87922cc33"));
            ch16 = (ITTCheckBox)AddControl(new Guid("2d495caa-463d-4f17-b102-6fd2107179ae"));
            ch15 = (ITTCheckBox)AddControl(new Guid("1c2a8784-a6fb-4b3c-b5a3-eaf9c2a6ebc8"));
            ch14 = (ITTCheckBox)AddControl(new Guid("44f4e65f-b8f3-4e22-8d97-87c434af3270"));
            ch13 = (ITTCheckBox)AddControl(new Guid("e3778781-fbe3-4000-9716-51fa93189e4e"));
            ch12 = (ITTCheckBox)AddControl(new Guid("bbdbafa0-a33d-4659-9eeb-c8de8a9bd2f1"));
            ch31 = (ITTCheckBox)AddControl(new Guid("6e661a80-0dcc-480f-b114-d4c735ea52cf"));
            ch32 = (ITTCheckBox)AddControl(new Guid("ba724bed-5d10-492c-aa47-acab7efbabaa"));
            ch75 = (ITTCheckBox)AddControl(new Guid("3902ba17-0961-4d6e-94c6-780b8d1dc524"));
            ch33 = (ITTCheckBox)AddControl(new Guid("dc069047-d14e-47b9-a22c-cb22c0d8af7f"));
            ch74 = (ITTCheckBox)AddControl(new Guid("3aa2d35c-1d52-436e-a20b-acd92abcb7b7"));
            ch34 = (ITTCheckBox)AddControl(new Guid("31beec3f-7312-4093-b457-142a76069270"));
            ch81 = (ITTCheckBox)AddControl(new Guid("f45272d6-d268-4e7a-835d-800c74611995"));
            ch35 = (ITTCheckBox)AddControl(new Guid("164403c1-a617-4bfc-8ce4-237ab4ceba77"));
            ch73 = (ITTCheckBox)AddControl(new Guid("2ceeffa3-018c-4d63-8fb1-22669f4282f5"));
            ch36 = (ITTCheckBox)AddControl(new Guid("2cc8885d-9229-4590-bccd-77ccc5be4ad3"));
            ch82 = (ITTCheckBox)AddControl(new Guid("4c7625de-b643-4304-b121-dda3d3e20443"));
            ch37 = (ITTCheckBox)AddControl(new Guid("f914837d-3996-40a1-9141-3d3760871ed1"));
            ch72 = (ITTCheckBox)AddControl(new Guid("3228330f-1ac8-4eb7-afbb-fced0a9f92a7"));
            ch38 = (ITTCheckBox)AddControl(new Guid("f658bc1d-0fc0-4c64-9d0e-3cbd9f468abd"));
            ch48 = (ITTCheckBox)AddControl(new Guid("fa427ed4-7cc7-4864-8db7-3326b0c9f367"));
            ch71 = (ITTCheckBox)AddControl(new Guid("52864a2e-0351-4043-98f2-47a869a435e6"));
            ch83 = (ITTCheckBox)AddControl(new Guid("f0b6cbf0-dd46-4f08-b4a7-fd3b6bc008d6"));
            ch65 = (ITTCheckBox)AddControl(new Guid("11a469eb-c210-4b30-817a-c5014b0f369b"));
            ch84 = (ITTCheckBox)AddControl(new Guid("600af316-0b55-4699-8b25-6cb8307c72db"));
            ch47 = (ITTCheckBox)AddControl(new Guid("1632af38-e037-4cbf-bacb-78d2c4b7d6ab"));
            ch85 = (ITTCheckBox)AddControl(new Guid("13756e45-4189-405d-8c4d-5766e92cbca4"));
            ch64 = (ITTCheckBox)AddControl(new Guid("b63a1a01-c31f-4b8c-975f-0de3311146d4"));
            ch46 = (ITTCheckBox)AddControl(new Guid("5b9e9b53-1ec7-44e0-aa2f-1c2b8e7a5e8c"));
            ch45 = (ITTCheckBox)AddControl(new Guid("4e9a6f7b-de04-4ef4-acf3-270ebd3d0577"));
            ch63 = (ITTCheckBox)AddControl(new Guid("45cf5330-e85f-4625-9835-863893cda049"));
            ch44 = (ITTCheckBox)AddControl(new Guid("bf6ebfb3-133a-440c-9445-d746abcc5b9f"));
            ch62 = (ITTCheckBox)AddControl(new Guid("6302bd46-66cc-4bf3-a0cc-7d631a24caf8"));
            ch43 = (ITTCheckBox)AddControl(new Guid("86c43fb9-8a29-49e3-8d88-da5c3ad952e2"));
            ch61 = (ITTCheckBox)AddControl(new Guid("11d3af2b-3e30-4ea0-9528-e82fca6686a9"));
            ch42 = (ITTCheckBox)AddControl(new Guid("4782a723-a2ba-405a-9472-495474a0f898"));
            ch51 = (ITTCheckBox)AddControl(new Guid("764cd46f-95d4-47f6-8587-0533bcf7ae1e"));
            ch41 = (ITTCheckBox)AddControl(new Guid("33f10396-4cad-4bc8-beec-aef0eeda34f0"));
            ch52 = (ITTCheckBox)AddControl(new Guid("377af3c1-b32a-4841-b5f1-a3171982d7db"));
            ch53 = (ITTCheckBox)AddControl(new Guid("7dc25b6a-dcd2-479b-86d2-5a92d5cff83d"));
            ch54 = (ITTCheckBox)AddControl(new Guid("321db796-5682-4fa4-a6ed-85a181e95c9b"));
            ch55 = (ITTCheckBox)AddControl(new Guid("658061aa-30f2-4253-a0da-b89f9ca6a398"));
            ch28 = (ITTCheckBox)AddControl(new Guid("b7ebc824-1a39-4548-add5-42f24143c683"));
            ch11 = (ITTCheckBox)AddControl(new Guid("c69eea74-cbb5-4839-94fc-5e6fc8f8f08f"));
            ch21 = (ITTCheckBox)AddControl(new Guid("1fee6b2c-df8b-4453-aceb-dc97cc23d3e5"));
            ch27 = (ITTCheckBox)AddControl(new Guid("0fb46f2f-d8f9-45b3-8dcd-0c327eabd8c8"));
            ch26 = (ITTCheckBox)AddControl(new Guid("b3015f39-95f3-4be1-b469-1ab34a0e053b"));
            ch25 = (ITTCheckBox)AddControl(new Guid("1132be26-5da6-4f1a-a9c4-1f3314523b58"));
            ch24 = (ITTCheckBox)AddControl(new Guid("64b852bc-3a54-4fea-89d7-66ddfc642b65"));
            ch23 = (ITTCheckBox)AddControl(new Guid("62b8c537-1217-494d-84c0-95dbe7e500db"));
            ch22 = (ITTCheckBox)AddControl(new Guid("cf677300-ee60-4091-8c9a-3f88f0147d75"));
            ch3 = (ITTCheckBox)AddControl(new Guid("2bcd1912-18e4-4d49-909f-44dd626475dc"));
            ch4 = (ITTCheckBox)AddControl(new Guid("d426deb8-5573-4ebe-8641-3deb423c0d46"));
            ch6 = (ITTCheckBox)AddControl(new Guid("e964dc32-3d82-4f12-ba9a-8529e3f3ebaf"));
            ch5 = (ITTCheckBox)AddControl(new Guid("47cc4c75-b48a-4cf9-83a4-16b177aba129"));
            ch7 = (ITTCheckBox)AddControl(new Guid("cfcb76ea-4327-4c9f-9ae4-f49ea8df6e7f"));
            ch2 = (ITTCheckBox)AddControl(new Guid("84116a4e-f561-4696-9ebc-f78138db40ca"));
            ch1 = (ITTCheckBox)AddControl(new Guid("cee92354-0021-4bae-ac85-6cb4cc42dae1"));
            base.InitializeControls();
        }

        public RadiologyRequestDentalToothSchema() : base("RADIOLOGY", "RadiologyRequestDentalToothSchema")
        {
        }

        protected RadiologyRequestDentalToothSchema(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}