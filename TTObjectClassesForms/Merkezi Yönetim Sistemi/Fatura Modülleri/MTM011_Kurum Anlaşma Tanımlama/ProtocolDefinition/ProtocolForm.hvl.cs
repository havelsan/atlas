
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
    /// Anlaşma Tanımı
    /// </summary>
    public partial class ProtocolForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kurum Anlaşma Tanımlama
    /// </summary>
        protected TTObjectClasses.ProtocolDefinition _ProtocolDefinition
        {
            get { return (TTObjectClasses.ProtocolDefinition)_ttObject; }
        }

        protected ITTEnumComboBox Type;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel3;
        protected ITTTextBox ID;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GRIDPROTOCOLDETAILPROCEDURES;
        protected ITTListBoxColumn PROCEDURETREE;
        protected ITTListDefComboBoxColumn PPRICINGLIST;
        protected ITTListDefComboBoxColumn PPRICINGLISTMULTIPLIER;
        protected ITTListDefComboBoxColumn PSECONDPRICINGLIST;
        protected ITTListDefComboBoxColumn PSECONDPRICINGLISTMULTIPLIER;
        protected ITTTextBoxColumn POUTPATIENTDISCOUNTPERCENT;
        protected ITTTextBoxColumn POUTPATIENTPATIENTPERCENT;
        protected ITTTextBoxColumn POUTPATIENTPAYERPERCENT;
        protected ITTTextBoxColumn PINPATIENTDISCOUNTPERCENT;
        protected ITTTextBoxColumn PINPATIENTPATIENTPERCENT;
        protected ITTTextBoxColumn PINPATIENTPAYERPERCENT;
        protected ITTTextBoxColumn PSTARTAGE;
        protected ITTTextBoxColumn PENDAGE;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GRIDPROTOCOLDETAILMATERIALS;
        protected ITTListBoxColumn MATERIALTREE;
        protected ITTListDefComboBoxColumn MPRICINGLIST;
        protected ITTTextBoxColumn MOUTPATIENTDISCOUNTPERCENT;
        protected ITTTextBoxColumn MOUTPATIENTPATIENTPERCENT;
        protected ITTTextBoxColumn MOUTPATIENTPAYERPERCENT;
        protected ITTTextBoxColumn MINPATIENTDISCOUNTPERCENT;
        protected ITTTextBoxColumn MINPATIENTPATIENTPERCENT;
        protected ITTTextBoxColumn MINPATIENTPAYERPERCENT;
        protected ITTTabPage tttabpage5;
        protected ITTGrid GRIDEXCEPTIONPROCEDURES;
        protected ITTListBoxColumn PROCEDUREOBJECT;
        protected ITTTextBoxColumn PATIENTPRICE;
        protected ITTTextBoxColumn PAYERPRICE;
        protected ITTListDefComboBoxColumn PEXCPRICINGLIST;
        protected ITTListDefComboBoxColumn PEXCPRICINGLISTMULTIPLIER;
        protected ITTListDefComboBoxColumn PEXCSECONDPRICINGLIST;
        protected ITTListDefComboBoxColumn PEXCSECONDPRICINGLISTMULTIPLIER;
        protected ITTTextBoxColumn PEXCOUTPATIENTDISCOUNTPERCENT;
        protected ITTTextBoxColumn PEXCOUTPATIENTPATIENTPERCENT;
        protected ITTTextBoxColumn PEXCOUTPATIENTPAYERPERCENT;
        protected ITTTextBoxColumn PEXCINPATIENTDISCOUNTPERCENT;
        protected ITTTextBoxColumn PEXCINPATIENTPATIENTPERCENT;
        protected ITTTextBoxColumn PEXCINPATIENTPAYERPERCENT;
        protected ITTTextBoxColumn PEXCSTARTAGE;
        protected ITTTextBoxColumn PEXCENDAGE;
        protected ITTObjectListBox SearchProcedure;
        protected ITTButton btnSearchInProcExceptions;
        protected ITTLabel ttlabel4;
        protected ITTTabPage tttabpage6;
        protected ITTGrid GRIDEXCEPTIONMATERIALS;
        protected ITTListBoxColumn MATERIAL;
        protected ITTTextBoxColumn MEXCPATIENTPRICE;
        protected ITTTextBoxColumn MEXCPAYERPRICE;
        protected ITTListDefComboBoxColumn MEXCPRICINGLIST;
        protected ITTTextBoxColumn MEXCOUTPATIENTDISCOUNTPERCENT;
        protected ITTTextBoxColumn MEXCOUTPATIENTPATIENTPERCENT;
        protected ITTTextBoxColumn MEXCOUTPATIENTPAYERPERCENT;
        protected ITTTextBoxColumn MEXCINPATIENTDISCOUNTPERCENT;
        protected ITTTextBoxColumn MEXCINPATIENTPATIENTPERCENT;
        protected ITTTextBoxColumn MEXCINPATIENTPAYERPERCENT;
        protected ITTTextBox CODE;
        protected ITTTextBox NAME;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox InPatientPaymentType;
        protected ITTLabel lblOutPatientPaymentType;
        protected ITTLabel lblInPatientPaymentType;
        protected ITTEnumComboBox OutPatientPaymentType;
        protected ITTCheckBox RequiresFinancialControl;
        protected ITTCheckBox RequiresAdvance;
        protected ITTCheckBox SpecialExamination;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            Type = (ITTEnumComboBox)AddControl(new Guid("876a48b6-d882-483b-bd66-a9659ea6fabe"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e7f29984-b786-478a-8fe9-454a89cf0aa5"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a3e04174-4e5b-44e0-87d8-6df6f3a0833a"));
            ID = (ITTTextBox)AddControl(new Guid("6a6ff38b-52eb-4753-8c08-014f52ab2339"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("0bf975bd-36e6-4e05-9364-1ebfe4ef2751"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("0cf95205-0c6f-405a-8111-3fd185883fbe"));
            GRIDPROTOCOLDETAILPROCEDURES = (ITTGrid)AddControl(new Guid("0b49bf29-d02c-4892-ac98-832629ba52a6"));
            PROCEDURETREE = (ITTListBoxColumn)AddControl(new Guid("264d9380-04e7-4c9b-99a6-d96412b061c3"));
            PPRICINGLIST = (ITTListDefComboBoxColumn)AddControl(new Guid("4cec433f-bced-495e-9fdf-b17deb74eeae"));
            PPRICINGLISTMULTIPLIER = (ITTListDefComboBoxColumn)AddControl(new Guid("0bf2676b-ad6d-457e-85fc-5e8ac9253e3b"));
            PSECONDPRICINGLIST = (ITTListDefComboBoxColumn)AddControl(new Guid("d3d061ab-86d8-4832-8402-f08210b5610d"));
            PSECONDPRICINGLISTMULTIPLIER = (ITTListDefComboBoxColumn)AddControl(new Guid("f1caee67-91d5-4afc-8cbc-aece9cd5e228"));
            POUTPATIENTDISCOUNTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("677b81f8-75d8-48f9-a7dc-837535314cc2"));
            POUTPATIENTPATIENTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("929fe400-894c-45da-b307-87c1b94464eb"));
            POUTPATIENTPAYERPERCENT = (ITTTextBoxColumn)AddControl(new Guid("9e871184-e084-4f85-ac45-e1fc7dd7ae13"));
            PINPATIENTDISCOUNTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("10618c90-8c0d-4661-b692-5d72a8dad3f2"));
            PINPATIENTPATIENTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("42ce9d30-82e2-41ee-ac26-f3861dc01d95"));
            PINPATIENTPAYERPERCENT = (ITTTextBoxColumn)AddControl(new Guid("0a266f42-4ca5-4b95-b2f0-294708abe8c8"));
            PSTARTAGE = (ITTTextBoxColumn)AddControl(new Guid("5bae27da-b6b5-44c1-ac00-384cadf22702"));
            PENDAGE = (ITTTextBoxColumn)AddControl(new Guid("9130dead-1921-4676-a8af-0a322226e7ad"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("57dc2a0a-3954-4d7f-9b68-f0df0329427f"));
            GRIDPROTOCOLDETAILMATERIALS = (ITTGrid)AddControl(new Guid("c2c70edb-80c3-4628-82b6-7108b2426864"));
            MATERIALTREE = (ITTListBoxColumn)AddControl(new Guid("06331084-e03a-4a90-9166-5b581ad81f72"));
            MPRICINGLIST = (ITTListDefComboBoxColumn)AddControl(new Guid("5492d9ad-b848-4a4d-8b31-bc95fbbe5e43"));
            MOUTPATIENTDISCOUNTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("6aa9ddd2-e117-4548-ab33-279021cc10ce"));
            MOUTPATIENTPATIENTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("0aa8f3ae-b1af-4403-bec5-a4f5e7c77d57"));
            MOUTPATIENTPAYERPERCENT = (ITTTextBoxColumn)AddControl(new Guid("b666a012-28ea-4d26-9d3e-a1c942d9a09a"));
            MINPATIENTDISCOUNTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("68409a59-f368-4d14-91dc-fffc7f2241ea"));
            MINPATIENTPATIENTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("537e6dd2-b68e-4748-86a9-909dc2af2e9e"));
            MINPATIENTPAYERPERCENT = (ITTTextBoxColumn)AddControl(new Guid("28ce948c-7c28-4190-b8f6-dcb0db465823"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("f44481aa-f13b-4b82-b210-ee38803768e3"));
            GRIDEXCEPTIONPROCEDURES = (ITTGrid)AddControl(new Guid("5aa3a53a-160c-471b-a1fb-d5c960eabff7"));
            PROCEDUREOBJECT = (ITTListBoxColumn)AddControl(new Guid("48091947-e82d-4732-997c-1efd5bae2097"));
            PATIENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("1b1c481e-a587-4fd4-b5d3-5598bb06a6be"));
            PAYERPRICE = (ITTTextBoxColumn)AddControl(new Guid("92122297-7ba2-4f36-b8a2-5a2a19d62cd2"));
            PEXCPRICINGLIST = (ITTListDefComboBoxColumn)AddControl(new Guid("c79aca5e-5cd8-447e-8c76-c449ff710681"));
            PEXCPRICINGLISTMULTIPLIER = (ITTListDefComboBoxColumn)AddControl(new Guid("3e4c628d-f497-4fad-9ae1-391132b635b1"));
            PEXCSECONDPRICINGLIST = (ITTListDefComboBoxColumn)AddControl(new Guid("a13c468b-acda-4fa1-a519-0e6f9ffce01f"));
            PEXCSECONDPRICINGLISTMULTIPLIER = (ITTListDefComboBoxColumn)AddControl(new Guid("6c00d56f-1391-48f5-8d7b-d6aa44a74124"));
            PEXCOUTPATIENTDISCOUNTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("16d6b92b-8318-4a0a-8128-1ffe13e4b6c2"));
            PEXCOUTPATIENTPATIENTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("67c26e7d-95b2-4f7a-bfe5-fd22a90dd7a0"));
            PEXCOUTPATIENTPAYERPERCENT = (ITTTextBoxColumn)AddControl(new Guid("688123cd-2fbb-428f-b8b4-3760306426e5"));
            PEXCINPATIENTDISCOUNTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("1529deb2-deec-4511-8795-be046808bc00"));
            PEXCINPATIENTPATIENTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("eaa9c8c9-e4ec-4c78-8df7-07c6de050dab"));
            PEXCINPATIENTPAYERPERCENT = (ITTTextBoxColumn)AddControl(new Guid("aa3b3559-18b8-4754-a799-171b4a6f12f8"));
            PEXCSTARTAGE = (ITTTextBoxColumn)AddControl(new Guid("546a08fc-ebed-4e6a-a608-be5fe2ff9a64"));
            PEXCENDAGE = (ITTTextBoxColumn)AddControl(new Guid("6ab9b381-4414-44b6-9ec9-9c41d847b193"));
            SearchProcedure = (ITTObjectListBox)AddControl(new Guid("ec1bdf07-84a3-4e32-beeb-ddd0c8ea9031"));
            btnSearchInProcExceptions = (ITTButton)AddControl(new Guid("0d02413c-33a4-441e-a77e-13b2aede6201"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("dab331d9-a7fe-4602-a302-29ab64de372b"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("4ac68c35-9c19-4676-8d00-7f78b13f114c"));
            GRIDEXCEPTIONMATERIALS = (ITTGrid)AddControl(new Guid("996ad5d9-61f3-48fd-805f-3e26fdc8e401"));
            MATERIAL = (ITTListBoxColumn)AddControl(new Guid("56b7b60c-84eb-4815-a3de-f73554050318"));
            MEXCPATIENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("9c94f7cb-ef45-43e0-90aa-63a66ba912f9"));
            MEXCPAYERPRICE = (ITTTextBoxColumn)AddControl(new Guid("90c55675-9811-4000-98ec-20ce0a84952d"));
            MEXCPRICINGLIST = (ITTListDefComboBoxColumn)AddControl(new Guid("ce42be72-28f2-42dd-b713-8849da6a7988"));
            MEXCOUTPATIENTDISCOUNTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("2a3c6418-1a27-4161-9db2-7c5293c3f7d5"));
            MEXCOUTPATIENTPATIENTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("28cc1368-e37d-4518-aa93-d830146ef8e5"));
            MEXCOUTPATIENTPAYERPERCENT = (ITTTextBoxColumn)AddControl(new Guid("359016ee-28ce-4e96-8d0d-466dfbebff61"));
            MEXCINPATIENTDISCOUNTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("a265ce7c-6e95-4155-ae32-3c79d2ab96b1"));
            MEXCINPATIENTPATIENTPERCENT = (ITTTextBoxColumn)AddControl(new Guid("e27c1d34-0059-40c5-a1c5-aca9968da093"));
            MEXCINPATIENTPAYERPERCENT = (ITTTextBoxColumn)AddControl(new Guid("0ed0674d-a66a-4015-8f26-334aa9465d7f"));
            CODE = (ITTTextBox)AddControl(new Guid("b6c58396-b7df-45fe-aedf-a8e6d8fa7cb6"));
            NAME = (ITTTextBox)AddControl(new Guid("dc1864cf-3af2-4de4-8608-d8c5aa4640db"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c935b15a-aead-48f0-a046-2646b763945c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("eff32823-c70f-42b4-812c-7f293234c6c7"));
            InPatientPaymentType = (ITTEnumComboBox)AddControl(new Guid("4b7af286-f05c-4402-b290-2f8027d8adee"));
            lblOutPatientPaymentType = (ITTLabel)AddControl(new Guid("e00b0bbd-27ea-4e56-86d0-46377ee87d32"));
            lblInPatientPaymentType = (ITTLabel)AddControl(new Guid("0863ddaa-2448-4be6-849b-12a8de471f48"));
            OutPatientPaymentType = (ITTEnumComboBox)AddControl(new Guid("2b7882b7-8759-4edd-adc5-87b91db06c45"));
            RequiresFinancialControl = (ITTCheckBox)AddControl(new Guid("23e6ad39-6ddd-473a-b682-087f5a3c8001"));
            RequiresAdvance = (ITTCheckBox)AddControl(new Guid("05759aa1-fae7-420e-a1e8-746710d1a685"));
            SpecialExamination = (ITTCheckBox)AddControl(new Guid("1cdcab0d-266e-4325-952b-f88d522e4314"));
            IsActive = (ITTCheckBox)AddControl(new Guid("3caff38a-9780-471a-a036-0febcf7300fe"));
            base.InitializeControls();
        }

        public ProtocolForm() : base("PROTOCOLDEFINITION", "ProtocolForm")
        {
        }

        protected ProtocolForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}