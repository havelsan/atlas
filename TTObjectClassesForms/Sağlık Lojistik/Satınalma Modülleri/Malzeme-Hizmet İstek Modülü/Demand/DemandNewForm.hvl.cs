
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
    /// Belge Kayıt (Malzeme İsteği)
    /// </summary>
    public partial class DemandNewForm : TTForm
    {
    /// <summary>
    /// Malzeme/Hizmet İstek modülü için ana sınıftır
    /// </summary>
        protected TTObjectClasses.Demand _Demand
        {
            get { return (TTObjectClasses.Demand)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid DemandDetails;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NatoStockNo;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn StoreStocks;
        protected ITTTextBoxColumn Description2;
        protected ITTRichTextBoxControlColumn SpRefToAdMatters;
        protected ITTRichTextBoxControlColumn FeasibilityEtude;
        protected ITTTextBoxColumn Patient;
        protected ITTButtonColumn SelectPatient;
        protected ITTTextBoxColumn TechnicalSpecificationNo;
        protected ITTTabPage tttabpage2;
        protected ITTGrid Member;
        protected ITTTextBoxColumn CommisionOrderNoTechnicalMember;
        protected ITTListBoxColumn ResUserTechnicalMember;
        protected ITTEnumComboBoxColumn MemberDutyTechnicalMember;
        protected ITTCheckBoxColumn PrimeBackupTechnicalMember;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelID;
        protected ITTTextBox Description;
        protected ITTLabel labelDemandType;
        protected ITTDateTimePicker ActionDate;
        protected ITTEnumComboBox DemandType;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a76af808-434b-4a88-9db7-918f6f12aa0d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("792501b2-82bf-4c6a-8c0a-6228d9d2f9b3"));
            DemandDetails = (ITTGrid)AddControl(new Guid("03d1cae0-9f18-4e41-a54e-535143ea6ab5"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("160c85a0-742e-49aa-96c0-e83ef6e813fe"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("685d1b7d-bc87-4a52-81f6-55c9890f1edf"));
            NatoStockNo = (ITTTextBoxColumn)AddControl(new Guid("aae6be2a-1cab-4f80-a88e-2382d150c4fe"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("55f081e7-2f80-4dc7-a7b9-330f14701cb4"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("bf41d095-2331-4f73-83af-a75005a40ba4"));
            StoreStocks = (ITTTextBoxColumn)AddControl(new Guid("3df3d14f-8fd3-4171-8d01-591bf6b3ae03"));
            Description2 = (ITTTextBoxColumn)AddControl(new Guid("3840def2-2bfb-4081-a3cf-74841110b767"));
            SpRefToAdMatters = (ITTRichTextBoxControlColumn)AddControl(new Guid("2a90df0b-1521-4caf-9af1-e7bb2bebad2f"));
            FeasibilityEtude = (ITTRichTextBoxControlColumn)AddControl(new Guid("dfc01622-994b-4ab0-b225-bfa068c26040"));
            Patient = (ITTTextBoxColumn)AddControl(new Guid("0ef0c373-4c43-44b5-91e9-3549e59e707c"));
            SelectPatient = (ITTButtonColumn)AddControl(new Guid("d2eeece5-9a0b-4f53-8a9d-12acbae9b533"));
            TechnicalSpecificationNo = (ITTTextBoxColumn)AddControl(new Guid("9f47f41f-9430-47ee-9f04-0b6804e5ee4a"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("431ac77d-e56c-4833-9dc5-c9c2d4a1f5cd"));
            Member = (ITTGrid)AddControl(new Guid("e62adc70-2b5b-4885-89f5-111eba4ce1bc"));
            CommisionOrderNoTechnicalMember = (ITTTextBoxColumn)AddControl(new Guid("ee960249-0580-4321-abc4-deb409022822"));
            ResUserTechnicalMember = (ITTListBoxColumn)AddControl(new Guid("dc3e4e4c-957b-417d-949d-3ca6efe2d6e4"));
            MemberDutyTechnicalMember = (ITTEnumComboBoxColumn)AddControl(new Guid("39522898-bb14-46fb-b59b-5cfb1035ea54"));
            PrimeBackupTechnicalMember = (ITTCheckBoxColumn)AddControl(new Guid("b5e11acc-5b39-4b69-848b-ddd5cc29d483"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("15f96ff0-127d-4a89-b58f-3ebca4eeb732"));
            labelDescription = (ITTLabel)AddControl(new Guid("9cced467-e696-442a-b363-823abc4735aa"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f0f9b145-57b2-4918-b192-8b841d059c02"));
            labelActionDate = (ITTLabel)AddControl(new Guid("58ebe52d-1b9d-44c5-820f-a3d927ce9f41"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("4161e188-00a5-496f-8b3d-aa09d81473d8"));
            RequestNO = (ITTTextBox)AddControl(new Guid("78f264e3-04a0-40a7-b639-ccc281ed1d22"));
            labelID = (ITTLabel)AddControl(new Guid("5805fa04-437b-4881-8b25-db3cd7e0edb8"));
            Description = (ITTTextBox)AddControl(new Guid("df1944a3-595a-42dd-8463-f081e0e6b195"));
            labelDemandType = (ITTLabel)AddControl(new Guid("83c579ab-bae4-45d1-ad44-212ec92f69f3"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("b3313d67-96d0-4a6a-a15d-2f68a7e0643f"));
            DemandType = (ITTEnumComboBox)AddControl(new Guid("1a97ed2b-9591-4e74-b31c-2fe01ef3ef7c"));
            base.InitializeControls();
        }

        public DemandNewForm() : base("DEMAND", "DemandNewForm")
        {
        }

        protected DemandNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}