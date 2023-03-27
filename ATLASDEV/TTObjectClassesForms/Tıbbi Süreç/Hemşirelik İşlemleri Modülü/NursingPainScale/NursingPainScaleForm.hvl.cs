
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
    public partial class NursingPainScaleForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Ağrı Değerlendirme
    /// </summary>
        protected TTObjectClasses.NursingPainScale _NursingPainScale
        {
            get { return (TTObjectClasses.NursingPainScale)_ttObject; }
        }

        protected ITTLabel labelPostNursingInitiative;
        protected ITTEnumComboBox PostNursingInitiative;
        protected ITTLabel labelPainQuality;
        protected ITTObjectListBox PainQuality;
        protected ITTLabel labelPainFrequency;
        protected ITTObjectListBox PainFrequency;
        protected ITTLabel labelPainPlaces;
        protected ITTObjectListBox PainPlaces;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelPainFaceScale;
        protected ITTEnumComboBox PainFaceScale;
        protected ITTLabel labelPainQualityDescription;
        protected ITTTextBox PainQualityDescription;
        protected ITTTextBox AchingSide;
        protected ITTTextBox DurationofPain;
        protected ITTTextBox PainTime;
        protected ITTTextBox PainDetail;
        protected ITTLabel labelAchingSide;
        protected ITTLabel labelDurationofPain;
        protected ITTLabel labelPainTime;
        protected ITTLabel labelPainDetail;
        override protected void InitializeControls()
        {
            labelPostNursingInitiative = (ITTLabel)AddControl(new Guid("feabc78b-c7be-4d31-a25f-3b429be5679a"));
            PostNursingInitiative = (ITTEnumComboBox)AddControl(new Guid("9ee10d38-da52-4952-b7fa-c90eac5b04e0"));
            labelPainQuality = (ITTLabel)AddControl(new Guid("3886f905-d0e8-441d-aec4-0e48a791e969"));
            PainQuality = (ITTObjectListBox)AddControl(new Guid("2e645beb-823a-4645-bd8e-69ea9a1e37f9"));
            labelPainFrequency = (ITTLabel)AddControl(new Guid("6903737b-dde7-4bc2-a449-e2466ab3e6d0"));
            PainFrequency = (ITTObjectListBox)AddControl(new Guid("2739512f-3246-4874-ac7e-f158a94888f9"));
            labelPainPlaces = (ITTLabel)AddControl(new Guid("609256ce-bdca-4b94-bed7-c19b0560b488"));
            PainPlaces = (ITTObjectListBox)AddControl(new Guid("771b762b-ad63-4ad9-ab31-bd000b4a2240"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("d1694270-6bcd-4eac-a275-093cbaf985a5"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("fb4a540a-fb92-43a2-95a8-3f3fdcc413f7"));
            labelPainFaceScale = (ITTLabel)AddControl(new Guid("2e61c9af-46ac-4364-b922-8b81eb13ff2e"));
            PainFaceScale = (ITTEnumComboBox)AddControl(new Guid("5cc6460d-ce4e-45b4-97c1-ab44384bbb60"));
            labelPainQualityDescription = (ITTLabel)AddControl(new Guid("1f2fa61d-b89d-4a23-a0d4-f5fd8c3b64f2"));
            PainQualityDescription = (ITTTextBox)AddControl(new Guid("2f16938e-8aa2-402f-84a4-57b7cb6638de"));
            AchingSide = (ITTTextBox)AddControl(new Guid("fe9d5c2c-c3e4-4333-a500-5e492eea7059"));
            DurationofPain = (ITTTextBox)AddControl(new Guid("adeea048-a143-4f85-8297-57d1d0c76e68"));
            PainTime = (ITTTextBox)AddControl(new Guid("bcffce9a-a993-4204-9cfb-73a65d87a561"));
            PainDetail = (ITTTextBox)AddControl(new Guid("531d374b-0246-4680-a81c-ac476bfd48ac"));
            labelAchingSide = (ITTLabel)AddControl(new Guid("80a8c69e-1623-4ed0-aa3d-7a7665f1817d"));
            labelDurationofPain = (ITTLabel)AddControl(new Guid("8be00a29-8c5e-4050-bde6-6d623406ef84"));
            labelPainTime = (ITTLabel)AddControl(new Guid("9962c10a-352a-4796-ab81-13aba46d59a6"));
            labelPainDetail = (ITTLabel)AddControl(new Guid("6dad43f9-5d3c-4f1a-8f5f-671bc7a5fa79"));
            base.InitializeControls();
        }

        public NursingPainScaleForm() : base("NURSINGPAINSCALE", "NursingPainScaleForm")
        {
        }

        protected NursingPainScaleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}