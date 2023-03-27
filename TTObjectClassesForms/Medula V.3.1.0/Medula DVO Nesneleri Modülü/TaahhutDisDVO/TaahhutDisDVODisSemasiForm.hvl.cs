
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
    public partial class TaahhutDisDVODisSemasiForm : TTForm
    {
        protected TTObjectClasses.TaahhutDisDVO _TaahhutDisDVO
        {
            get { return (TTObjectClasses.TaahhutDisDVO)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTButton ttbutton65;
        protected ITTButton ttbutton69;
        protected ITTButton ttbutton70;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTButton ttbutton68;
        protected ITTButton ttbutton67;
        protected ITTButton ttbutton74;
        protected ITTButton ttbutton73;
        protected ITTButton ttbutton71;
        protected ITTButton ttbutton66;
        protected ITTButton ttbutton72;
        protected ITTButton buttonTumAgiz2;
        protected ITTButton buttonbos2;
        protected ITTButton button3;
        protected ITTButton button91;
        protected ITTButton button7;
        protected ITTButton buttonbos1;
        protected ITTButton button6;
        protected ITTButton button55;
        protected ITTButton button2;
        protected ITTButton button54;
        protected ITTButton buttonTumAgiz1;
        protected ITTButton button53;
        protected ITTButton button5;
        protected ITTButton button52;
        protected ITTButton button4;
        protected ITTButton button51;
        protected ITTButton button75;
        protected ITTButton ttbutton1;
        protected ITTButton button74;
        protected ITTButton button92;
        protected ITTButton button73;
        protected ITTButton ttbutton3;
        protected ITTButton button72;
        protected ITTButton button61;
        protected ITTButton button71;
        protected ITTButton button62;
        protected ITTButton ttbutton51;
        protected ITTButton button63;
        protected ITTButton button94;
        protected ITTButton button64;
        protected ITTButton ttbutton49;
        protected ITTButton button65;
        protected ITTButton button81;
        protected ITTButton button18;
        protected ITTButton button82;
        protected ITTButton button17;
        protected ITTButton button83;
        protected ITTButton button16;
        protected ITTButton button84;
        protected ITTButton button15;
        protected ITTButton button85;
        protected ITTButton button14;
        protected ITTButton ttbutton43;
        protected ITTButton button13;
        protected ITTButton button93;
        protected ITTButton button12;
        protected ITTButton ttbutton41;
        protected ITTButton button11;
        protected ITTButton button38;
        protected ITTButton button21;
        protected ITTButton button37;
        protected ITTButton button22;
        protected ITTButton button36;
        protected ITTButton button23;
        protected ITTButton button35;
        protected ITTButton button24;
        protected ITTButton button34;
        protected ITTButton button25;
        protected ITTButton button33;
        protected ITTButton button26;
        protected ITTButton button32;
        protected ITTButton button27;
        protected ITTButton button31;
        protected ITTButton button28;
        protected ITTButton button41;
        protected ITTButton button48;
        protected ITTButton button42;
        protected ITTButton button47;
        protected ITTButton button43;
        protected ITTButton button46;
        protected ITTButton button44;
        protected ITTButton button45;
        protected ITTLabel labelsutKodu;
        protected ITTValueListBox sutKodu;
        protected ITTLabel labeldisNo;
        protected ITTTextBox disNo;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("35abe07e-ccf5-46fc-a3aa-d98c7ad2750b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("71e68d2b-5d95-44e6-b374-0d5d3d825c86"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d92c51f6-d02e-4e1a-adac-a6b15c17266e"));
            ttbutton65 = (ITTButton)AddControl(new Guid("101197f8-cdb9-4b35-a0f3-dca5ee8e94f9"));
            ttbutton69 = (ITTButton)AddControl(new Guid("1868e6c8-a4d4-4851-b77f-2fa2c3bc11c9"));
            ttbutton70 = (ITTButton)AddControl(new Guid("a289d13f-4942-45e8-90d8-e2734e46ec08"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("1ae59671-1fc4-4279-a5fa-20f760fdd40e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cac275ef-fc0b-46f0-92ec-d6b49a54738b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ac543c96-5396-420c-a4d7-f53e359d8809"));
            ttbutton68 = (ITTButton)AddControl(new Guid("71e10e50-baca-4868-88f4-013b36091ce2"));
            ttbutton67 = (ITTButton)AddControl(new Guid("a209c350-e0f0-4ca0-8e22-2c256656536b"));
            ttbutton74 = (ITTButton)AddControl(new Guid("b98a2f59-f0c3-4769-9a62-c698f70e6f14"));
            ttbutton73 = (ITTButton)AddControl(new Guid("daf08d0a-c48d-4f16-9818-7683cdfac239"));
            ttbutton71 = (ITTButton)AddControl(new Guid("84be12cb-9f03-46f0-a613-1bfd31f7f9bd"));
            ttbutton66 = (ITTButton)AddControl(new Guid("a8039cb0-d914-4083-9dc3-80d19c6b7683"));
            ttbutton72 = (ITTButton)AddControl(new Guid("9bddaae6-888d-4247-abfb-fad20137477d"));
            buttonTumAgiz2 = (ITTButton)AddControl(new Guid("09636b2a-d4c4-4dbb-a347-ba0921ce9c7e"));
            buttonbos2 = (ITTButton)AddControl(new Guid("f13383fd-791d-466a-a9e1-7840558e1603"));
            button3 = (ITTButton)AddControl(new Guid("917b88f2-94ea-4abd-965d-65af463dafdf"));
            button91 = (ITTButton)AddControl(new Guid("0587569e-3110-4f22-ba3c-3e07623ad776"));
            button7 = (ITTButton)AddControl(new Guid("6bb6df95-2321-4733-8e5d-74f5683955d4"));
            buttonbos1 = (ITTButton)AddControl(new Guid("8015c31e-27ff-4520-afe4-0fb18b63383f"));
            button6 = (ITTButton)AddControl(new Guid("17968780-c000-423c-ad2c-42e100a357b0"));
            button55 = (ITTButton)AddControl(new Guid("65198319-e3fe-49f1-b815-023f05013608"));
            button2 = (ITTButton)AddControl(new Guid("e41bdc3b-e704-4a07-9809-01091601b295"));
            button54 = (ITTButton)AddControl(new Guid("5a81480f-d3ad-4ff9-a119-a44964edf862"));
            buttonTumAgiz1 = (ITTButton)AddControl(new Guid("a0982275-d053-43eb-87aa-548f0d0efb34"));
            button53 = (ITTButton)AddControl(new Guid("0c8fd979-f386-48e9-98aa-2c13cd7781df"));
            button5 = (ITTButton)AddControl(new Guid("c082ed7b-0df1-4bf8-8510-a433c3d830aa"));
            button52 = (ITTButton)AddControl(new Guid("0911d4bf-0925-409e-a2e9-73748f8f9bc4"));
            button4 = (ITTButton)AddControl(new Guid("c256298a-7352-4197-a3aa-755d54c13a32"));
            button51 = (ITTButton)AddControl(new Guid("37935d9f-238f-4704-bf8e-b3c71c26cc88"));
            button75 = (ITTButton)AddControl(new Guid("4a281c08-4ac3-499d-98a3-00743e839a1b"));
            ttbutton1 = (ITTButton)AddControl(new Guid("239bc819-fe51-4e9b-a3a8-a98e665d7a35"));
            button74 = (ITTButton)AddControl(new Guid("596b5212-5215-4945-a73e-d4ad950f935d"));
            button92 = (ITTButton)AddControl(new Guid("75dfaaf8-50ea-4ce0-8c18-382ec29d96cc"));
            button73 = (ITTButton)AddControl(new Guid("d5f851c9-0559-4dec-a96d-20ce8d8426b6"));
            ttbutton3 = (ITTButton)AddControl(new Guid("d9ca32d8-5c44-4999-85ae-8f7496e2b80b"));
            button72 = (ITTButton)AddControl(new Guid("0c36f66f-cd9d-4dcb-a30e-32439d037954"));
            button61 = (ITTButton)AddControl(new Guid("7b7978d7-06f1-4e37-be52-eb4a8304b856"));
            button71 = (ITTButton)AddControl(new Guid("2b0d40bc-4314-4682-abed-208871efb743"));
            button62 = (ITTButton)AddControl(new Guid("b95c7653-2994-433d-b5b9-4d4835d05f31"));
            ttbutton51 = (ITTButton)AddControl(new Guid("bde05129-dc81-40d1-9e02-c4f5bc3a2057"));
            button63 = (ITTButton)AddControl(new Guid("5fdae51c-11f3-4304-a444-55313b1b1ff7"));
            button94 = (ITTButton)AddControl(new Guid("9e51311c-fcef-43ab-98c6-be42c599bcf4"));
            button64 = (ITTButton)AddControl(new Guid("b88af4b3-2b13-4970-ae8c-752ed40abbe0"));
            ttbutton49 = (ITTButton)AddControl(new Guid("aeeda9d8-cba4-4c11-a647-508432647657"));
            button65 = (ITTButton)AddControl(new Guid("f43e4487-9fd8-4e25-a607-ccb99d79b445"));
            button81 = (ITTButton)AddControl(new Guid("1d91b1e5-67ee-4bc6-b3f5-8600436a6b25"));
            button18 = (ITTButton)AddControl(new Guid("991b1bcc-17ce-4228-8c81-3426b2e6108d"));
            button82 = (ITTButton)AddControl(new Guid("a1a3eb99-34f5-4636-b72a-d9b3d59ad021"));
            button17 = (ITTButton)AddControl(new Guid("7bde9753-0fa2-40a5-ad0f-efd43bec5aeb"));
            button83 = (ITTButton)AddControl(new Guid("0d593167-17c4-4ea0-bdd8-343dc674f9c6"));
            button16 = (ITTButton)AddControl(new Guid("91a0c54c-1996-497c-96e4-13da8c2f359f"));
            button84 = (ITTButton)AddControl(new Guid("863bfa34-fc5e-46a4-bc44-9d7b3be0abdf"));
            button15 = (ITTButton)AddControl(new Guid("10dca2a0-1849-437b-91ca-ad6428b22688"));
            button85 = (ITTButton)AddControl(new Guid("31b744da-0a8e-4b21-8a32-9e9555f0cc2d"));
            button14 = (ITTButton)AddControl(new Guid("b2a6a797-0134-4db9-b700-1c463805844a"));
            ttbutton43 = (ITTButton)AddControl(new Guid("8e6170ad-db92-4de3-b19d-3fd85ad9b2a5"));
            button13 = (ITTButton)AddControl(new Guid("8dbac7fa-9520-49d5-83d7-637bb8cf7aa7"));
            button93 = (ITTButton)AddControl(new Guid("1c203dbf-521d-4ba4-9038-bd8a94ecc1ac"));
            button12 = (ITTButton)AddControl(new Guid("59e70d2d-143b-4e88-945a-e2b3653798f3"));
            ttbutton41 = (ITTButton)AddControl(new Guid("0c8e5d62-a942-4b17-81e8-61ce53ebae02"));
            button11 = (ITTButton)AddControl(new Guid("0666ffc0-ea0e-47b0-a9ca-4f8d68cd4336"));
            button38 = (ITTButton)AddControl(new Guid("3ce0247a-d408-4a28-a874-20781c78d0ac"));
            button21 = (ITTButton)AddControl(new Guid("5eb0c697-facb-41b4-b8a1-f0af3828defe"));
            button37 = (ITTButton)AddControl(new Guid("6bb0f7eb-2625-4dd9-a2e4-641773b87ee7"));
            button22 = (ITTButton)AddControl(new Guid("309cdd1b-9dfd-4317-a977-638b12f084d4"));
            button36 = (ITTButton)AddControl(new Guid("28d81431-6b9e-492d-91ed-1b3f8e43a229"));
            button23 = (ITTButton)AddControl(new Guid("0ad5e6fa-f7d3-44d4-9c27-df529fcaf46f"));
            button35 = (ITTButton)AddControl(new Guid("6aed9af7-596e-4b88-9d39-dfaffd57e4bd"));
            button24 = (ITTButton)AddControl(new Guid("160d83a8-6ef5-49f5-a6bb-2b6e671b05d3"));
            button34 = (ITTButton)AddControl(new Guid("fc08e92c-64b5-429e-b8d9-1009e44a33ba"));
            button25 = (ITTButton)AddControl(new Guid("96bb7890-cd1e-4f05-ac9c-c98f015259cd"));
            button33 = (ITTButton)AddControl(new Guid("c8b134eb-b64e-48ea-ba8b-f4fc5d18a46b"));
            button26 = (ITTButton)AddControl(new Guid("ebeb205a-4ab2-4b84-a93f-bb7ab8057fb4"));
            button32 = (ITTButton)AddControl(new Guid("3a190b96-3b9c-40fb-b369-5d7d1508140b"));
            button27 = (ITTButton)AddControl(new Guid("589dc85c-8bb0-4401-9a34-6098b0a4c0fa"));
            button31 = (ITTButton)AddControl(new Guid("125333a4-8275-4d69-b3df-a83064c61827"));
            button28 = (ITTButton)AddControl(new Guid("44b40cac-d303-4c41-811b-742b8da8c9f4"));
            button41 = (ITTButton)AddControl(new Guid("e185cd9d-6273-4e0b-8cb2-e500acf6304d"));
            button48 = (ITTButton)AddControl(new Guid("ecf1a177-d68b-4928-b383-fc47d3dfecb4"));
            button42 = (ITTButton)AddControl(new Guid("6c232009-38b1-4fbf-8022-1709058989c0"));
            button47 = (ITTButton)AddControl(new Guid("8ce6ce55-83a7-496e-a7cd-4057f7190ed8"));
            button43 = (ITTButton)AddControl(new Guid("bbcba248-9560-4079-9c20-74d45ada86dd"));
            button46 = (ITTButton)AddControl(new Guid("419481b2-0c06-4ab6-8b6d-90051ff0236c"));
            button44 = (ITTButton)AddControl(new Guid("6665b7f3-a50c-433e-8c5a-26547cdc7443"));
            button45 = (ITTButton)AddControl(new Guid("4688d2ac-e489-43d5-8f8e-f1ec2da64f65"));
            labelsutKodu = (ITTLabel)AddControl(new Guid("bbb83551-ec56-41af-ada3-22e716e7833b"));
            sutKodu = (ITTValueListBox)AddControl(new Guid("6477036c-8ff5-430b-a7a1-1441a068dfd6"));
            labeldisNo = (ITTLabel)AddControl(new Guid("4e4cfd5d-dcde-4aa7-895f-ee5cdcddb99d"));
            disNo = (ITTTextBox)AddControl(new Guid("5ba352b1-24e4-4a34-8448-07d759cda274"));
            base.InitializeControls();
        }

        public TaahhutDisDVODisSemasiForm() : base("TAAHHUTDISDVO", "TaahhutDisDVODisSemasiForm")
        {
        }

        protected TaahhutDisDVODisSemasiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}