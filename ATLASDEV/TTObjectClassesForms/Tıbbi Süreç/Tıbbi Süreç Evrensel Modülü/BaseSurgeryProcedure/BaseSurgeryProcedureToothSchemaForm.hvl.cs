
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
    public partial class BaseSurgeryProcedureToothSchema : TTForm
    {
    /// <summary>
    /// Ameliyat Procedure Ana Objesi
    /// </summary>
        protected TTObjectClasses.BaseSurgeryProcedure _BaseSurgeryProcedure
        {
            get { return (TTObjectClasses.BaseSurgeryProcedure)_ttObject; }
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
            panelTooth = (ITTPanel)AddControl(new Guid("423a1039-d56f-4991-afb1-1104aa6b8095"));
            ttbutton2 = (ITTButton)AddControl(new Guid("bdb63671-3c42-45a2-a70e-ad9f0f6ef0b6"));
            ttbutton1 = (ITTButton)AddControl(new Guid("ec93456e-c8c7-4de9-841b-520d1516d386"));
            ch18 = (ITTCheckBox)AddControl(new Guid("a2c9937f-00b6-4270-89ec-42f3288a1deb"));
            ch17 = (ITTCheckBox)AddControl(new Guid("f5f53eb7-34dc-4f26-b9a7-08087648438a"));
            ch16 = (ITTCheckBox)AddControl(new Guid("94541a83-2a51-4cd9-afc4-38ffc547583f"));
            ch15 = (ITTCheckBox)AddControl(new Guid("c37a4426-49cb-4e4b-b386-fde087b005b5"));
            ch14 = (ITTCheckBox)AddControl(new Guid("98b1dffb-57ac-4cca-aaa3-695221bbb8a4"));
            ch13 = (ITTCheckBox)AddControl(new Guid("1d1db7b5-f3f5-4ba3-8184-7b84e0f5bd78"));
            ch12 = (ITTCheckBox)AddControl(new Guid("90d19206-556d-4989-b550-64ba70ed11e4"));
            ch31 = (ITTCheckBox)AddControl(new Guid("9a900615-580c-4e01-9ca5-5974cfc635e4"));
            ch32 = (ITTCheckBox)AddControl(new Guid("1b26a423-76ce-4d47-8f62-5bd51b9b3481"));
            ch75 = (ITTCheckBox)AddControl(new Guid("ff02d703-931d-4151-8cdd-ebedee7b5e47"));
            ch33 = (ITTCheckBox)AddControl(new Guid("b08c41db-a329-49a4-8607-32399109a016"));
            ch74 = (ITTCheckBox)AddControl(new Guid("6f0b4499-1317-4e2b-b064-1d8ba395ea1f"));
            ch34 = (ITTCheckBox)AddControl(new Guid("27fe8251-0304-4814-b018-e0ad182e2d97"));
            ch81 = (ITTCheckBox)AddControl(new Guid("534876f4-e78a-431b-86ff-0b2a28659177"));
            ch35 = (ITTCheckBox)AddControl(new Guid("ebe76550-8144-47af-8792-1c0ad51b47fb"));
            ch73 = (ITTCheckBox)AddControl(new Guid("7934f382-bc8c-4d39-b7b2-8f2cade19d54"));
            ch36 = (ITTCheckBox)AddControl(new Guid("23c2bd1e-55c4-4244-bc55-3ddb17418045"));
            ch82 = (ITTCheckBox)AddControl(new Guid("9215bb5b-72d1-4fe5-bc91-7a760a0496b7"));
            ch37 = (ITTCheckBox)AddControl(new Guid("8209dace-2258-429d-b7bf-5a3467456406"));
            ch72 = (ITTCheckBox)AddControl(new Guid("e4c6e898-f59d-4d73-be0c-e0f2e0b88072"));
            ch38 = (ITTCheckBox)AddControl(new Guid("1738788c-6029-4553-bbe9-112d431e18a7"));
            ch48 = (ITTCheckBox)AddControl(new Guid("a352c489-146b-4815-afe6-d60695814b11"));
            ch71 = (ITTCheckBox)AddControl(new Guid("0f4524c3-9748-4980-8c72-4f7549e1a261"));
            ch83 = (ITTCheckBox)AddControl(new Guid("6c358c39-9732-4465-b238-83e8fb7feab8"));
            ch65 = (ITTCheckBox)AddControl(new Guid("0caac709-f441-44cb-8e63-9881dc0166ca"));
            ch84 = (ITTCheckBox)AddControl(new Guid("5da5e878-43e8-4d59-a777-6b236ec4b3e0"));
            ch47 = (ITTCheckBox)AddControl(new Guid("50d02d71-510e-4553-9f1e-d76b604e10c0"));
            ch85 = (ITTCheckBox)AddControl(new Guid("97df49ec-f0bb-4f2b-8ada-cb84a273c3a5"));
            ch64 = (ITTCheckBox)AddControl(new Guid("4c8d257c-bb6e-4dfc-9b2f-d80e1b55ad37"));
            ch46 = (ITTCheckBox)AddControl(new Guid("06f56ed9-5d74-4d98-9010-9274ceb28077"));
            ch45 = (ITTCheckBox)AddControl(new Guid("804aec83-e4e4-4e7b-afcc-f0d5bb247bed"));
            ch63 = (ITTCheckBox)AddControl(new Guid("79cd5593-076e-4471-b933-1946603edad3"));
            ch44 = (ITTCheckBox)AddControl(new Guid("674e9561-0d1d-48c1-83bb-b42d08555a1f"));
            ch62 = (ITTCheckBox)AddControl(new Guid("16a543ae-0bea-4791-bcfa-b0217d12c085"));
            ch43 = (ITTCheckBox)AddControl(new Guid("c36e6f24-4edf-4264-9f42-3f3ab3eb8a44"));
            ch61 = (ITTCheckBox)AddControl(new Guid("48b69110-b9a2-42b5-b834-4dec88355a78"));
            ch42 = (ITTCheckBox)AddControl(new Guid("ed6d0a5c-87ce-4e2f-88e2-df3c3eda6a15"));
            ch51 = (ITTCheckBox)AddControl(new Guid("7b378524-d784-45c2-8b6d-0a15ce4d48d1"));
            ch41 = (ITTCheckBox)AddControl(new Guid("f5fe397f-bc62-4ccb-90bf-f6ce4492ebed"));
            ch52 = (ITTCheckBox)AddControl(new Guid("dcf9a429-6497-49f0-b85b-edc850fc7843"));
            ch53 = (ITTCheckBox)AddControl(new Guid("fdf5ca5e-5549-4e15-85c6-25f472c5f169"));
            ch54 = (ITTCheckBox)AddControl(new Guid("d93f9262-e78b-4732-95d5-0eb1de99b4dd"));
            ch55 = (ITTCheckBox)AddControl(new Guid("44ffaf21-161a-405e-8d4e-7e97f9d3be1a"));
            ch28 = (ITTCheckBox)AddControl(new Guid("f16e9bbe-3c53-4c1d-8772-783e0cfbe142"));
            ch11 = (ITTCheckBox)AddControl(new Guid("d62d336d-450f-4933-998e-f67d917d7e7b"));
            ch21 = (ITTCheckBox)AddControl(new Guid("d9703936-151d-463e-a4a9-5ab4bff3f3f7"));
            ch27 = (ITTCheckBox)AddControl(new Guid("938fa115-b963-4bcc-89f2-4db560cb7e98"));
            ch26 = (ITTCheckBox)AddControl(new Guid("dc408a40-1225-4489-b855-2ed66f63ec23"));
            ch25 = (ITTCheckBox)AddControl(new Guid("36d397cb-8444-4e0c-863e-55c7eb66998f"));
            ch24 = (ITTCheckBox)AddControl(new Guid("2bf86384-d3c1-4ae0-9e96-f8c90efbe738"));
            ch23 = (ITTCheckBox)AddControl(new Guid("c3f8c833-32c1-43e4-9dee-5c0a02355846"));
            ch22 = (ITTCheckBox)AddControl(new Guid("45559c4d-eb8e-4e2a-b8ae-fd479a0a4bfe"));
            ch3 = (ITTCheckBox)AddControl(new Guid("90a681a3-a5a4-4cc8-a618-615dee96d37a"));
            ch4 = (ITTCheckBox)AddControl(new Guid("3ffc7197-a9b2-4b7a-9b41-881d0546e838"));
            ch6 = (ITTCheckBox)AddControl(new Guid("0fcbc862-fde3-4b90-903d-4dc43c4cce05"));
            ch5 = (ITTCheckBox)AddControl(new Guid("f48834d6-d917-4b46-869c-7320bca194c3"));
            ch7 = (ITTCheckBox)AddControl(new Guid("e3966bbe-5745-43f7-a45e-4c91a8da4881"));
            ch2 = (ITTCheckBox)AddControl(new Guid("4b0ad448-b66d-4839-9f3a-54b067b41045"));
            ch1 = (ITTCheckBox)AddControl(new Guid("c0e507bf-b21a-4a14-ad15-de9f7489f092"));
            base.InitializeControls();
        }

        public BaseSurgeryProcedureToothSchema() : base("BASESURGERYPROCEDURE", "BaseSurgeryProcedureToothSchema")
        {
        }

        protected BaseSurgeryProcedureToothSchema(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}