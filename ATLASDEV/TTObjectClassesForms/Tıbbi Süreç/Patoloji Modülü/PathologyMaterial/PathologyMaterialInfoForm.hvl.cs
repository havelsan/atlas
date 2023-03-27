
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
    public partial class PathologyMaterialInfo : TTForm
    {
        protected TTObjectClasses.PathologyMaterial _PathologyMaterial
        {
            get { return (TTObjectClasses.PathologyMaterial)_ttObject; }
        }

        protected ITTCheckBox SuspiciousMalign;
        protected ITTCheckBox Benign;
        protected ITTCheckBox Malign;
        protected ITTCheckBox Frozen;
        protected ITTLabel labelPathologicDiagnosis;
        protected ITTRichTextBoxControl PathologicDiagnosis;
        protected ITTLabel labelYerlesimYeri;
        protected ITTObjectListBox YerlesimYeri;
        protected ITTLabel labelPatolojiPreparatiDurumu;
        protected ITTObjectListBox PatolojiPreparatiDurumu;
        protected ITTLabel labelNumuneAlinmaSekli;
        protected ITTObjectListBox NumuneAlinmaSekli;
        protected ITTLabel labelMorfolojiKodu;
        protected ITTObjectListBox MorfolojiKodu;
        protected ITTLabel labelAlindigiDokununTemelOzelligi;
        protected ITTObjectListBox AlindigiDokununTemelOzelligi;
        protected ITTGrid PathologyTestProcedure;
        protected ITTListBoxColumn Category;
        protected ITTListBoxColumn ProcedureObjectPathologyTestProcedure;
        protected ITTListBoxColumn ProcedureDoctorPathologyTestProcedure;
        protected ITTTextBoxColumn AmountPathologyTestProcedure;
        protected ITTDateTimePickerColumn ActionDatePathologyTestProcedure;
        protected ITTDateTimePickerColumn PerformedDatePathologyTestProcedure;
        protected ITTLabel labelNote;
        protected ITTRichTextBoxControl Note;
        protected ITTLabel labelMicroscopy;
        protected ITTRichTextBoxControl Microscopy;
        protected ITTLabel labelMacroscopy;
        protected ITTRichTextBoxControl Macroscopy;
        protected ITTLabel labelDateOfSampleTaken;
        protected ITTDateTimePicker DateOfSampleTaken;
        protected ITTLabel labelMaterialNumber;
        protected ITTTextBox MaterialNumber;
        protected ITTTextBox Description;
        protected ITTTextBox ClinicalFindings;
        protected ITTLabel labelDescription;
        protected ITTLabel labelClinicalFindings;
        override protected void InitializeControls()
        {
            SuspiciousMalign = (ITTCheckBox)AddControl(new Guid("75584052-20d3-4f5b-a2e5-be9ea4431de6"));
            Benign = (ITTCheckBox)AddControl(new Guid("629e6b94-4713-4c2e-a283-d6a4177ff83d"));
            Malign = (ITTCheckBox)AddControl(new Guid("1484cde8-4c65-475f-9686-27a2aed0b51e"));
            Frozen = (ITTCheckBox)AddControl(new Guid("2e79a9ea-25fb-4fa3-a2b2-ded8b5e4bd97"));
            labelPathologicDiagnosis = (ITTLabel)AddControl(new Guid("12debc2d-2e4f-4b40-9444-072e3cb5c36a"));
            PathologicDiagnosis = (ITTRichTextBoxControl)AddControl(new Guid("7ed1bb89-0e4b-4410-933f-bf7db2678a5d"));
            labelYerlesimYeri = (ITTLabel)AddControl(new Guid("3067be28-7db4-4e04-88ac-5553c6f4d183"));
            YerlesimYeri = (ITTObjectListBox)AddControl(new Guid("734b4c00-422a-410e-b085-be8bd7c287b6"));
            labelPatolojiPreparatiDurumu = (ITTLabel)AddControl(new Guid("4387b6a5-f759-4d6f-9665-b081dcb80f30"));
            PatolojiPreparatiDurumu = (ITTObjectListBox)AddControl(new Guid("4290af22-88f9-451b-bd35-455417b85d7a"));
            labelNumuneAlinmaSekli = (ITTLabel)AddControl(new Guid("f2748d5a-41a2-4dc5-ba57-7043bda734c0"));
            NumuneAlinmaSekli = (ITTObjectListBox)AddControl(new Guid("e65959d4-e625-44b0-a296-9775527d1624"));
            labelMorfolojiKodu = (ITTLabel)AddControl(new Guid("e9829e07-f40a-4812-900a-b2780b4e63cc"));
            MorfolojiKodu = (ITTObjectListBox)AddControl(new Guid("8594069b-df59-4636-b8dc-453738435e5c"));
            labelAlindigiDokununTemelOzelligi = (ITTLabel)AddControl(new Guid("cd3b2dc1-8953-4ce3-aabf-2fdea5bf7f71"));
            AlindigiDokununTemelOzelligi = (ITTObjectListBox)AddControl(new Guid("0e501c0b-b416-4bbe-bd81-6f39bc4871da"));
            PathologyTestProcedure = (ITTGrid)AddControl(new Guid("22f0f129-08a8-4b65-b321-4ef01b1ae83f"));
            Category = (ITTListBoxColumn)AddControl(new Guid("f738917f-cce0-45b0-91bb-9727f044ec41"));
            ProcedureObjectPathologyTestProcedure = (ITTListBoxColumn)AddControl(new Guid("3ed65c7b-ba48-4ce0-934b-f39ad10540a8"));
            ProcedureDoctorPathologyTestProcedure = (ITTListBoxColumn)AddControl(new Guid("bd116962-5ad4-4df4-8ec2-fb61e7f7b51d"));
            AmountPathologyTestProcedure = (ITTTextBoxColumn)AddControl(new Guid("393c43bc-776e-46ec-9395-d15b634f6366"));
            ActionDatePathologyTestProcedure = (ITTDateTimePickerColumn)AddControl(new Guid("0c96477d-e8d6-463a-8e26-2e2dd78c9e8f"));
            PerformedDatePathologyTestProcedure = (ITTDateTimePickerColumn)AddControl(new Guid("d67eb5ce-b117-423e-aefb-f29aecc1dafa"));
            labelNote = (ITTLabel)AddControl(new Guid("66018500-57c9-4676-8656-e062ebea19a7"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("07abbf04-6291-46e5-a2f4-12a719b79a04"));
            labelMicroscopy = (ITTLabel)AddControl(new Guid("c5baa546-a76f-4d81-a653-c962ee7e4041"));
            Microscopy = (ITTRichTextBoxControl)AddControl(new Guid("4db69ca2-622f-4f43-a0ef-ba82a760e808"));
            labelMacroscopy = (ITTLabel)AddControl(new Guid("76ac0a35-5efb-48f1-9553-fdd0d47ea4fc"));
            Macroscopy = (ITTRichTextBoxControl)AddControl(new Guid("b775497c-6a9d-42ea-b52b-662e272c1e33"));
            labelDateOfSampleTaken = (ITTLabel)AddControl(new Guid("836e4a54-e373-4894-b4a6-112ca10d0726"));
            DateOfSampleTaken = (ITTDateTimePicker)AddControl(new Guid("a91870ec-57af-44a2-8f67-2da7a1f417cf"));
            labelMaterialNumber = (ITTLabel)AddControl(new Guid("a69ee686-1e50-4830-afa7-92476d360134"));
            MaterialNumber = (ITTTextBox)AddControl(new Guid("a412eede-e4c0-416a-82b4-1c218629114d"));
            Description = (ITTTextBox)AddControl(new Guid("2886fdaa-0e76-4317-8a5b-c9aec8d86be6"));
            ClinicalFindings = (ITTTextBox)AddControl(new Guid("b068bc15-b2aa-439b-8bfd-e68d5b4ba23a"));
            labelDescription = (ITTLabel)AddControl(new Guid("0aa29b68-729b-4054-9d3e-4cd5d9d800b6"));
            labelClinicalFindings = (ITTLabel)AddControl(new Guid("45a316e1-4b17-43b6-a562-3f3f91f2031e"));
            base.InitializeControls();
        }

        public PathologyMaterialInfo() : base("PATHOLOGYMATERIAL", "PathologyMaterialInfo")
        {
        }

        protected PathologyMaterialInfo(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}