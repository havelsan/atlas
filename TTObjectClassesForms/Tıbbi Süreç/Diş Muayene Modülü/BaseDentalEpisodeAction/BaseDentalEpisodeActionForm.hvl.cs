
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
    public partial class BaseDentalEpisodeActionForm : BaseNewDoctorExaminationForm
    {
        protected TTObjectClasses.BaseDentalEpisodeAction _BaseDentalEpisodeAction
        {
            get { return (TTObjectClasses.BaseDentalEpisodeAction)_ttObject; }
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
        override protected void InitializeControls()
        {
            panelTooth = (ITTPanel)AddControl(new Guid("4e99f58a-9885-41be-890b-047dbc5017f1"));
            ttbutton2 = (ITTButton)AddControl(new Guid("c6ef1e0a-65de-4518-a219-f737e66a4c7a"));
            ttbutton1 = (ITTButton)AddControl(new Guid("3f9b66ac-63a6-4ba2-a4f1-f0e84d7f51a1"));
            ch18 = (ITTCheckBox)AddControl(new Guid("0d11acee-7460-4c7f-9f42-d50b53977ae5"));
            ch17 = (ITTCheckBox)AddControl(new Guid("747d6f55-e9fe-4ab7-8c12-1a119fd72c36"));
            ch16 = (ITTCheckBox)AddControl(new Guid("7d476685-04cd-4f54-b8c0-b15873ae1613"));
            ch15 = (ITTCheckBox)AddControl(new Guid("8c2ea8ec-2a00-4fcd-9c1e-4a16a9dbc525"));
            ch14 = (ITTCheckBox)AddControl(new Guid("3f0cf3ec-bcd9-40db-9170-8e70b093f5f6"));
            ch13 = (ITTCheckBox)AddControl(new Guid("220f6edd-d380-4a10-a9dc-1478c1f15cf5"));
            ch12 = (ITTCheckBox)AddControl(new Guid("0160e297-8964-4ba9-b5ff-38561769b6ea"));
            ch31 = (ITTCheckBox)AddControl(new Guid("31998512-69f0-40c0-989f-0ccac14d07e8"));
            ch32 = (ITTCheckBox)AddControl(new Guid("54ad1139-e5cc-41ee-beca-3cf8939eb6a1"));
            ch75 = (ITTCheckBox)AddControl(new Guid("f80105a2-6bb4-4131-9a36-918c8abe08c5"));
            ch33 = (ITTCheckBox)AddControl(new Guid("51e2bdf9-da2b-4f53-8b6d-83a090bd0d01"));
            ch74 = (ITTCheckBox)AddControl(new Guid("72c0200c-a469-4762-9650-b9e9ac3df198"));
            ch34 = (ITTCheckBox)AddControl(new Guid("b7830469-da8c-471f-8d86-c46463039650"));
            ch81 = (ITTCheckBox)AddControl(new Guid("f413b193-5b41-46d9-975d-e586a791ad35"));
            ch35 = (ITTCheckBox)AddControl(new Guid("6515d4c2-65fb-4cd1-8fdb-4a2f2c56958a"));
            ch73 = (ITTCheckBox)AddControl(new Guid("747484d6-a95c-4f0d-a97a-477c4192e5b6"));
            ch36 = (ITTCheckBox)AddControl(new Guid("fcf0e3f6-396f-4466-a602-7509e1eeb573"));
            ch82 = (ITTCheckBox)AddControl(new Guid("5efb7221-b3c8-4a3d-95db-c73ab3513a73"));
            ch37 = (ITTCheckBox)AddControl(new Guid("e1360c1d-874a-4091-a045-bb5cc17bd269"));
            ch72 = (ITTCheckBox)AddControl(new Guid("ae15ac03-cd88-4c2a-b7f6-002af75a6900"));
            ch38 = (ITTCheckBox)AddControl(new Guid("9e82ab83-2fe1-47ee-87e6-79d5493bc29e"));
            ch48 = (ITTCheckBox)AddControl(new Guid("ea291a5f-976d-40f5-a21a-77f1f18d1746"));
            ch71 = (ITTCheckBox)AddControl(new Guid("7c4eb750-de37-4d9d-8c40-25a2d6c08773"));
            ch83 = (ITTCheckBox)AddControl(new Guid("2c2599c3-07d8-4ecc-a8d3-c8f7f7ecc8bb"));
            ch65 = (ITTCheckBox)AddControl(new Guid("fd9a54d9-9ad1-45fe-83d0-0cbd5dfe1060"));
            ch84 = (ITTCheckBox)AddControl(new Guid("11d4a863-ece7-4fc5-b442-4cc600f71ba0"));
            ch47 = (ITTCheckBox)AddControl(new Guid("775a0b48-5fba-4853-b192-3735443b615d"));
            ch85 = (ITTCheckBox)AddControl(new Guid("c06bc671-fb81-4e96-80ae-a1e02c5696f4"));
            ch64 = (ITTCheckBox)AddControl(new Guid("f42443fe-739f-4930-b112-7ac7dbb48e9e"));
            ch46 = (ITTCheckBox)AddControl(new Guid("6667586e-943d-4f0f-98f3-8d6d80d3c62d"));
            ch45 = (ITTCheckBox)AddControl(new Guid("1b1d4c33-e947-40a3-b3e4-8a5d80001f05"));
            ch63 = (ITTCheckBox)AddControl(new Guid("84adac41-0f93-4e9e-8923-0f549aa0b11f"));
            ch44 = (ITTCheckBox)AddControl(new Guid("2bc5843a-4271-404b-9cf0-e085be7d783e"));
            ch62 = (ITTCheckBox)AddControl(new Guid("46faaf1f-70ab-4165-974d-b007d8f77da6"));
            ch43 = (ITTCheckBox)AddControl(new Guid("4cb03a2b-1d18-4aca-8876-0f5c2315edde"));
            ch61 = (ITTCheckBox)AddControl(new Guid("db6cb3fb-2c40-447d-83c4-9a336c6ebfbb"));
            ch42 = (ITTCheckBox)AddControl(new Guid("4a91858b-b662-45be-bb76-486bb926074e"));
            ch51 = (ITTCheckBox)AddControl(new Guid("e3abb4ee-a812-4dda-a9cf-6e297294b435"));
            ch41 = (ITTCheckBox)AddControl(new Guid("7bb4e9df-a980-434e-b469-41a65d4522a5"));
            ch52 = (ITTCheckBox)AddControl(new Guid("84836d7b-7e5a-48c8-9f28-86d4f7cfd1d2"));
            ch53 = (ITTCheckBox)AddControl(new Guid("488a6e83-6c6f-4512-a63c-e8cda353b8e3"));
            ch54 = (ITTCheckBox)AddControl(new Guid("53d79bae-a24d-4425-a798-9363cb173582"));
            ch55 = (ITTCheckBox)AddControl(new Guid("2ad4d621-dc33-49ea-ba32-bd8a6f3bed99"));
            ch28 = (ITTCheckBox)AddControl(new Guid("92ac46ee-4dcc-43cb-b2b2-f76c8813294b"));
            ch11 = (ITTCheckBox)AddControl(new Guid("9d309a80-b9c6-4ac3-aada-0ad425513542"));
            ch21 = (ITTCheckBox)AddControl(new Guid("e2c252c6-867c-4da7-abd0-986c2609aee1"));
            ch27 = (ITTCheckBox)AddControl(new Guid("3418fba3-c3d8-4bbf-be0c-2d63b33e99d2"));
            ch26 = (ITTCheckBox)AddControl(new Guid("ef494253-be96-473f-814d-c13e0a84a20c"));
            ch25 = (ITTCheckBox)AddControl(new Guid("011e832c-f193-409a-9363-1525ab93367b"));
            ch24 = (ITTCheckBox)AddControl(new Guid("0e94bf24-bc5b-46ff-b06b-bc904cc11368"));
            ch23 = (ITTCheckBox)AddControl(new Guid("a36e329a-2b25-4ede-9b46-f80391378e20"));
            ch22 = (ITTCheckBox)AddControl(new Guid("c4cf1260-3122-4bbe-a20a-f0421e296f20"));
            base.InitializeControls();
        }

        public BaseDentalEpisodeActionForm() : base("BASEDENTALEPISODEACTION", "BaseDentalEpisodeActionForm")
        {
        }

        protected BaseDentalEpisodeActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}