
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
    public partial class KuduzRiskliTemasVeriSetiForm : TTForm
    {
        protected TTObjectClasses.KuduzRiskliTemasVeriSeti _KuduzRiskliTemasVeriSeti
        {
            get { return (TTObjectClasses.KuduzRiskliTemasVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSRiskliTemasSebepOlHayvan;
        protected ITTObjectListBox SKRSRiskliTemasSebepOlHayvan;
        protected ITTLabel labelSKRSKuduzRiskliTemasDegDurumu;
        protected ITTObjectListBox SKRSKuduzRiskliTemasDegDurumu;
        protected ITTLabel labelSKRSKategorizasyon;
        protected ITTObjectListBox SKRSKategorizasyon;
        protected ITTLabel labelSKRSImmunglobulinTuru;
        protected ITTObjectListBox SKRSImmunglobulinTuru;
        protected ITTLabel labelSKRSHayvaninSahiplikDurumu;
        protected ITTObjectListBox SKRSHayvaninSahiplikDurumu;
        protected ITTLabel labelSKRSHayvaninMevcutDurumu;
        protected ITTObjectListBox SKRSHayvaninMevcutDurumu;
        protected ITTGrid KuduzRiskliTemasTelefon;
        protected ITTListBoxColumn SKRSTelefonTipiKuduzRiskliTemasTelefon;
        protected ITTTextBoxColumn TelefonNumarasiKuduzRiskliTemasTelefon;
        protected ITTGrid KuduzRiskliTemasRiskTemTip;
        protected ITTListBoxColumn SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip;
        protected ITTGrid KuduzRiskliTemasPlanProfBi;
        protected ITTListBoxColumn SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi;
        protected ITTGrid KuduzRiskliTemasAdres;
        protected ITTListBoxColumn SKRSAdresTipiKuduzRiskliTemasAdres;
        protected ITTListBoxColumn SKRSBucakKodlariKuduzRiskliTemasAdres;
        protected ITTListBoxColumn SKRSCSBMTipiKuduzRiskliTemasAdres;
        protected ITTListBoxColumn SKRSIlceKodlariKuduzRiskliTemasAdres;
        protected ITTListBoxColumn SKRSILKodlariKuduzRiskliTemasAdres;
        protected ITTListBoxColumn SKRSKoyKodlariKuduzRiskliTemasAdres;
        protected ITTListBoxColumn SKRSMahalleKodlariKuduzRiskliTemasAdres;
        protected ITTTextBoxColumn DisKapiKuduzRiskliTemasAdres;
        protected ITTTextBoxColumn IcKapiKuduzRiskliTemasAdres;
        protected ITTLabel labelRiskliTemasTarihi;
        protected ITTDateTimePicker RiskliTemasTarihi;
        protected ITTLabel labelImmunglobulinMiktari;
        protected ITTTextBox ImmunglobulinMiktari;
        protected ITTTextBox Kilo;
        protected ITTLabel labelKilo;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        override protected void InitializeControls()
        {
            labelSKRSRiskliTemasSebepOlHayvan = (ITTLabel)AddControl(new Guid("325e18db-274c-40be-9d6f-71f31ad23956"));
            SKRSRiskliTemasSebepOlHayvan = (ITTObjectListBox)AddControl(new Guid("bd74772e-4c90-46de-a725-df52a12137bd"));
            labelSKRSKuduzRiskliTemasDegDurumu = (ITTLabel)AddControl(new Guid("2262f182-8c48-446c-98a3-624b1335ae1f"));
            SKRSKuduzRiskliTemasDegDurumu = (ITTObjectListBox)AddControl(new Guid("5d33f4d1-a667-46ae-ae8e-a3a80d6bd07e"));
            labelSKRSKategorizasyon = (ITTLabel)AddControl(new Guid("d64d5fda-0a6f-4a7f-b403-ba78a9ddddab"));
            SKRSKategorizasyon = (ITTObjectListBox)AddControl(new Guid("e134680c-bcb7-4b8b-b9a6-57dd0b9656fb"));
            labelSKRSImmunglobulinTuru = (ITTLabel)AddControl(new Guid("f34ea7dc-6270-4a4c-85dd-8fa14d91d683"));
            SKRSImmunglobulinTuru = (ITTObjectListBox)AddControl(new Guid("3b3931b1-49e1-4ae5-be01-451a34c61fe0"));
            labelSKRSHayvaninSahiplikDurumu = (ITTLabel)AddControl(new Guid("b74abea9-02e7-4be3-80b0-ff9292a5daa2"));
            SKRSHayvaninSahiplikDurumu = (ITTObjectListBox)AddControl(new Guid("0a4c9e69-827a-43c9-be6c-c11d9587fb56"));
            labelSKRSHayvaninMevcutDurumu = (ITTLabel)AddControl(new Guid("906c051c-e5be-4ada-ac04-ce6809f70578"));
            SKRSHayvaninMevcutDurumu = (ITTObjectListBox)AddControl(new Guid("34775002-9249-4f38-ab58-c7c400c26871"));
            KuduzRiskliTemasTelefon = (ITTGrid)AddControl(new Guid("4653dd57-2212-40ff-af30-4293e0695f60"));
            SKRSTelefonTipiKuduzRiskliTemasTelefon = (ITTListBoxColumn)AddControl(new Guid("35c70b89-a4a7-44ec-a255-41b6780a37ac"));
            TelefonNumarasiKuduzRiskliTemasTelefon = (ITTTextBoxColumn)AddControl(new Guid("a813f567-a20b-4242-9d25-f5d23064ba72"));
            KuduzRiskliTemasRiskTemTip = (ITTGrid)AddControl(new Guid("03329949-6916-411b-83ac-0a6c0a41459e"));
            SKRSRiskliTemasTipiKuduzRiskliTemasRiskTemTip = (ITTListBoxColumn)AddControl(new Guid("a9ce29d5-77b7-4071-9bad-f2a2ebcdbe33"));
            KuduzRiskliTemasPlanProfBi = (ITTGrid)AddControl(new Guid("a4a6f018-ee92-4dd0-a47b-7006e89591bc"));
            SKRSKisiyePlanKuduzProfilaksiKuduzRiskliTemasPlanProfBi = (ITTListBoxColumn)AddControl(new Guid("634d47af-49ff-4f87-ad96-18e62f7e17ff"));
            KuduzRiskliTemasAdres = (ITTGrid)AddControl(new Guid("e2d56426-e80e-4818-8014-a3d175c3ddb6"));
            SKRSAdresTipiKuduzRiskliTemasAdres = (ITTListBoxColumn)AddControl(new Guid("a115f007-7bb9-4ebe-9b64-5e7d296d6714"));
            SKRSBucakKodlariKuduzRiskliTemasAdres = (ITTListBoxColumn)AddControl(new Guid("87017342-9b8d-4cd4-b9fb-cdb5d3a5a0dd"));
            SKRSCSBMTipiKuduzRiskliTemasAdres = (ITTListBoxColumn)AddControl(new Guid("73becc3a-bb6b-4805-b407-75c8a8e9ab78"));
            SKRSIlceKodlariKuduzRiskliTemasAdres = (ITTListBoxColumn)AddControl(new Guid("2e16d777-29de-4827-a060-b4cc254936ce"));
            SKRSILKodlariKuduzRiskliTemasAdres = (ITTListBoxColumn)AddControl(new Guid("fb046e62-507e-414a-8ba0-1c29a82d04a0"));
            SKRSKoyKodlariKuduzRiskliTemasAdres = (ITTListBoxColumn)AddControl(new Guid("9e6cc0f4-3d16-410a-af91-d67acdbf401a"));
            SKRSMahalleKodlariKuduzRiskliTemasAdres = (ITTListBoxColumn)AddControl(new Guid("8e188555-07ff-461d-8393-c823b3041bac"));
            DisKapiKuduzRiskliTemasAdres = (ITTTextBoxColumn)AddControl(new Guid("44e1be6c-e2c2-4010-b8c8-7fb8e5c2349f"));
            IcKapiKuduzRiskliTemasAdres = (ITTTextBoxColumn)AddControl(new Guid("0d51c284-4316-4d31-854d-b3798562051d"));
            labelRiskliTemasTarihi = (ITTLabel)AddControl(new Guid("fb9bd9cf-1897-4f32-a662-db0e1060a503"));
            RiskliTemasTarihi = (ITTDateTimePicker)AddControl(new Guid("f07dcc93-4a5c-465c-b953-cca1e385c7a8"));
            labelImmunglobulinMiktari = (ITTLabel)AddControl(new Guid("0f62e795-c830-4cf0-815b-a623efaa6d0a"));
            ImmunglobulinMiktari = (ITTTextBox)AddControl(new Guid("49042db0-1484-44b0-b64a-063d246be26b"));
            Kilo = (ITTTextBox)AddControl(new Guid("b0ada008-0d9c-4541-a05e-ae7e321b491e"));
            labelKilo = (ITTLabel)AddControl(new Guid("1176fe56-1dbe-4457-abcf-4902eedf21ef"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("879eb994-d3fe-4a78-91ab-7d9ab85242b8"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("a3f8a806-f9a7-4859-83db-fafa063f5010"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("8e023c8f-56b1-41b1-8f30-8cfb75d20534"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("d29b3a95-6fab-41dc-b236-8ba9d998a9f6"));
            base.InitializeControls();
        }

        public KuduzRiskliTemasVeriSetiForm() : base("KUDUZRISKLITEMASVERISETI", "KuduzRiskliTemasVeriSetiForm")
        {
        }

        protected KuduzRiskliTemasVeriSetiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}