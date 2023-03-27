
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
    public partial class EkokardiografiForm : ManipulationFormBaseObjectForm
    {
    /// <summary>
    /// Ekokardiografi Türünde Manipulasyonların Ortak Objesi
    /// </summary>
        protected TTObjectClasses.EkokardiografiFormObject _EkokardiografiFormObject
        {
            get { return (TTObjectClasses.EkokardiografiFormObject)_ttObject; }
        }

        protected ITTLabel labelKilo;
        protected ITTTextBox Kilo;
        protected ITTTextBox Boy;
        protected ITTTextBox Ritim;
        protected ITTTextBox KalpHizi;
        protected ITTLabel labelBoy;
        protected ITTGrid EkokardiografiBulgular;
        protected ITTEnumComboBoxColumn EkokardiografiTestEkokardiografiBulgu;
        protected ITTTextBoxColumn EkokardiografiTestBulguEkokardiografiBulgu;
        protected ITTGrid PulmonerKapakBulgular;
        protected ITTEnumComboBoxColumn PulmonerKapakTestPulmonerKapakBulgu;
        protected ITTTextBoxColumn PulmonerKapakTestBulguPulmonerKapakBulgu;
        protected ITTGrid TrikuspitKapakBulgular;
        protected ITTEnumComboBoxColumn TrikuspitKapakTestTrikuspitKapakBulgu;
        protected ITTTextBoxColumn TrikuspitKapakTestBulguTrikuspitKapakBulgu;
        protected ITTGrid AortKapakBulgular;
        protected ITTEnumComboBoxColumn AortKapakTestAortKapakBulgu;
        protected ITTTextBoxColumn AortKapakTestBulguAortKapakBulgu;
        protected ITTGrid MitralKapakBulgular;
        protected ITTEnumComboBoxColumn MitralKapakTestMitralKapakBulgu;
        protected ITTTextBoxColumn MitralKapakTestBulguMitralKapakBulgu;
        protected ITTLabel labelEkoSonuc;
        protected ITTRichTextBoxControl EkoSonuc;
        protected ITTLabel labelPerikartOzellik;
        protected ITTRichTextBoxControl PerikartOzellik;
        protected ITTLabel labelLVSegmentHareket;
        protected ITTRichTextBoxControl LVSegmentHareket;
        protected ITTLabel labelRitim;
        protected ITTLabel labelKalpHizi;
        override protected void InitializeControls()
        {
            labelKilo = (ITTLabel)AddControl(new Guid("9d2a4a9a-03d2-4948-9b1b-f8547c1a52bd"));
            Kilo = (ITTTextBox)AddControl(new Guid("509fc23a-4164-4fa1-ab7f-5d3bd3809957"));
            Boy = (ITTTextBox)AddControl(new Guid("9cd9fe3c-7e38-4b12-8571-bd99c3e1e188"));
            Ritim = (ITTTextBox)AddControl(new Guid("ab53fb69-d388-474f-a3ca-48c90c37eab9"));
            KalpHizi = (ITTTextBox)AddControl(new Guid("27a06edf-a50c-4215-9cbe-4b2b72d15e65"));
            labelBoy = (ITTLabel)AddControl(new Guid("a0d855ac-eced-4ac4-a568-8e861b834818"));
            EkokardiografiBulgular = (ITTGrid)AddControl(new Guid("984d0a7f-d6f0-46c4-ad00-f76c09b8e3a1"));
            EkokardiografiTestEkokardiografiBulgu = (ITTEnumComboBoxColumn)AddControl(new Guid("488f7902-a5ff-499f-9234-06cdecf23df6"));
            EkokardiografiTestBulguEkokardiografiBulgu = (ITTTextBoxColumn)AddControl(new Guid("0decaa73-77b9-4366-9a7f-7a9dd795aec9"));
            PulmonerKapakBulgular = (ITTGrid)AddControl(new Guid("435f9816-84b9-4155-a8ce-49a5f218c344"));
            PulmonerKapakTestPulmonerKapakBulgu = (ITTEnumComboBoxColumn)AddControl(new Guid("c032d344-b3df-42de-8eb4-1780b5c3cc07"));
            PulmonerKapakTestBulguPulmonerKapakBulgu = (ITTTextBoxColumn)AddControl(new Guid("a73ec91a-21a4-46ab-bfe3-60a9871f46af"));
            TrikuspitKapakBulgular = (ITTGrid)AddControl(new Guid("cad00046-a75c-4f64-81ec-0ab2d2bb6e12"));
            TrikuspitKapakTestTrikuspitKapakBulgu = (ITTEnumComboBoxColumn)AddControl(new Guid("5ff88ddc-b693-4100-b7c3-4875da0bbebe"));
            TrikuspitKapakTestBulguTrikuspitKapakBulgu = (ITTTextBoxColumn)AddControl(new Guid("90d8aded-bb24-45d2-9263-c0afebb92b1e"));
            AortKapakBulgular = (ITTGrid)AddControl(new Guid("457520fa-6688-43ce-b901-c009e344184c"));
            AortKapakTestAortKapakBulgu = (ITTEnumComboBoxColumn)AddControl(new Guid("c7243d6d-2adc-42ad-a5b7-1050e69ed186"));
            AortKapakTestBulguAortKapakBulgu = (ITTTextBoxColumn)AddControl(new Guid("5bf608f8-e308-4378-8317-4c28215dca2f"));
            MitralKapakBulgular = (ITTGrid)AddControl(new Guid("8b0728aa-6d4b-448f-a274-cc7bc8da6e72"));
            MitralKapakTestMitralKapakBulgu = (ITTEnumComboBoxColumn)AddControl(new Guid("b6da6cc4-f196-48ec-a9f7-eaa51e01769d"));
            MitralKapakTestBulguMitralKapakBulgu = (ITTTextBoxColumn)AddControl(new Guid("dac7fd7e-47ea-4f46-94da-223c43144937"));
            labelEkoSonuc = (ITTLabel)AddControl(new Guid("1bf3b289-a434-460e-8001-a66415ce656d"));
            EkoSonuc = (ITTRichTextBoxControl)AddControl(new Guid("f4242b1c-066d-407e-b55a-96ea550b504f"));
            labelPerikartOzellik = (ITTLabel)AddControl(new Guid("f4540935-e74a-4597-af51-923342757e15"));
            PerikartOzellik = (ITTRichTextBoxControl)AddControl(new Guid("6597f768-8059-48c4-a067-132af79c6b68"));
            labelLVSegmentHareket = (ITTLabel)AddControl(new Guid("2a03ad4b-b1e6-4cc2-84b1-b912e9ea2a4f"));
            LVSegmentHareket = (ITTRichTextBoxControl)AddControl(new Guid("21d28dc4-ef60-4ccb-ae97-89c3e5cdc57b"));
            labelRitim = (ITTLabel)AddControl(new Guid("b1799ef0-e17a-4370-b287-ff2deb6480eb"));
            labelKalpHizi = (ITTLabel)AddControl(new Guid("47024e4f-7cfc-47bc-a8f4-3b6b78a1dd4e"));
            base.InitializeControls();
        }

        public EkokardiografiForm() : base("EKOKARDIOGRAFIFORMOBJECT", "EkokardiografiForm")
        {
        }

        protected EkokardiografiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}