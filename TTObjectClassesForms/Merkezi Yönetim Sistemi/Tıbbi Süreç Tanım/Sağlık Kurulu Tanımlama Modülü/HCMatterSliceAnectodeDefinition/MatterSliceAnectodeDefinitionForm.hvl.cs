
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
    /// Madde/Dilim/Fıkra Tanımları
    /// </summary>
    public partial class MatterSliceAnectodeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.HCMatterSliceAnectodeDefinition _HCMatterSliceAnectodeDefinition
        {
            get { return (TTObjectClasses.HCMatterSliceAnectodeDefinition)_ttObject; }
        }

        protected ITTLabel labelClass;
        protected ITTObjectListBox Class;
        protected ITTLabel labelRank;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelForce;
        protected ITTObjectListBox Force;
        protected ITTRichTextBoxControl OfferOfDecision;
        protected ITTLabel labelAnectode;
        protected ITTTextBox Anectode;
        protected ITTLabel labelSlice;
        protected ITTEnumComboBox Slice;
        protected ITTLabel labelMatter;
        protected ITTTextBox Matter;
        protected ITTCheckBox MindWeightedEmployee;
        protected ITTCheckBox BodyWeightedEmployee;
        override protected void InitializeControls()
        {
            labelClass = (ITTLabel)AddControl(new Guid("9b4c532e-2b5a-437a-b32c-93e5d6285972"));
            Class = (ITTObjectListBox)AddControl(new Guid("896a1513-10c1-4696-a671-e620ce64962d"));
            labelRank = (ITTLabel)AddControl(new Guid("2589c0cd-b118-44a0-889c-ca555d44f3bf"));
            Rank = (ITTObjectListBox)AddControl(new Guid("a9e4366d-13e1-476a-8312-2535b79a3ee3"));
            labelForce = (ITTLabel)AddControl(new Guid("d5e4cbcb-0099-45e9-955c-8af498e1fc25"));
            Force = (ITTObjectListBox)AddControl(new Guid("a6f7b4ba-a3a8-4ffb-8c8a-80b5bd3de20a"));
            OfferOfDecision = (ITTRichTextBoxControl)AddControl(new Guid("b82f0fe6-1a19-4208-82bc-1e48c296877e"));
            labelAnectode = (ITTLabel)AddControl(new Guid("09d76d2e-f643-452d-9577-5d844d008071"));
            Anectode = (ITTTextBox)AddControl(new Guid("8d0a3a09-f3cf-41b3-8a76-50f7974b9f36"));
            labelSlice = (ITTLabel)AddControl(new Guid("230acc28-fbaf-4ec3-a2f6-bb517f949fa4"));
            Slice = (ITTEnumComboBox)AddControl(new Guid("18444ba8-937c-4eab-91e2-70bdbc0dd83d"));
            labelMatter = (ITTLabel)AddControl(new Guid("215ebbc0-7b6e-4390-ad29-7a77010c7834"));
            Matter = (ITTTextBox)AddControl(new Guid("c4a704af-7020-40b0-84a4-6881a503889f"));
            MindWeightedEmployee = (ITTCheckBox)AddControl(new Guid("90f7208d-8544-4b4f-8b25-2aeb55e2e7e1"));
            BodyWeightedEmployee = (ITTCheckBox)AddControl(new Guid("57dd077a-a5c1-4fd7-9979-8573908dd174"));
            base.InitializeControls();
        }

        public MatterSliceAnectodeDefinitionForm() : base("HCMATTERSLICEANECTODEDEFINITION", "MatterSliceAnectodeDefinitionForm")
        {
        }

        protected MatterSliceAnectodeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}