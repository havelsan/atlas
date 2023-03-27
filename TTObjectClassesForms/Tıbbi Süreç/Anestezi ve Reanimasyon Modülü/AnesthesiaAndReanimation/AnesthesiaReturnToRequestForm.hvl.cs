
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
    /// SİL
    /// </summary>
    public partial class AnesthesiaReturnToRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Anestezi ve Reanimasyon İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaAndReanimation _AnesthesiaAndReanimation
        {
            get { return (TTObjectClasses.AnesthesiaAndReanimation)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker PlannedAnesthsiaDate;
        protected ITTLabel ttlabel1;
        protected ITTRichTextBoxControl ttrichtextboxcontrolConsultationNote;
        protected ITTGrid RequestedProcedure;
        protected ITTListBoxColumn Procedure;
        protected ITTLabel LabelRequest;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox RequestNote;
        protected ITTTextBox ProtocolNo;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelRequestNote;
        protected ITTLabel labelProtocolNo;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("a2865418-c823-463a-a3a2-10b29974710f"));
            PlannedAnesthsiaDate = (ITTDateTimePicker)AddControl(new Guid("3351348a-3ae0-4188-904f-6c8260abcb13"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("afc11f4e-f616-4a1e-92ba-9a1b4c3d2cf4"));
            ttrichtextboxcontrolConsultationNote = (ITTRichTextBoxControl)AddControl(new Guid("6d64d1e4-85a4-4fbf-881a-a75642a1b02e"));
            RequestedProcedure = (ITTGrid)AddControl(new Guid("b1cab147-d385-4b56-8650-2d3a78da49fc"));
            Procedure = (ITTListBoxColumn)AddControl(new Guid("f8aae1a7-3605-45e8-9494-d19779b31faa"));
            LabelRequest = (ITTLabel)AddControl(new Guid("96c25002-9c6b-42d0-b172-f9de0d3e26c1"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("86847ad1-0f2d-41f1-a2ad-fb6a3586c28f"));
            RequestNote = (ITTTextBox)AddControl(new Guid("132605e2-323d-4c03-aa96-996e1970ed57"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("ae8d4ec2-2be3-46c7-b4fd-147013646dcb"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("8f59d645-8ebe-4a8c-9a90-17e15c952522"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("6bd230ec-a37c-48e4-8870-cd275161d86f"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("5cff16f6-6096-423b-aa30-3c80a63d92cd"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("eb1c5343-f4c4-4f51-9c6e-129b59df52e6"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9fc590f7-079d-4394-a0e8-2b8798c73125"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0d93df05-b1bf-4bf0-bfb5-0d95591f5802"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("9246c6a3-35ed-419e-a9e0-4135a6c94fdd"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("624fb378-127c-4b51-90e0-af843f3eb4fe"));
            labelRequestNote = (ITTLabel)AddControl(new Guid("3f8c3c77-7861-406c-a47d-77f4d0d5629b"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("ea98f732-6e29-4ec8-8af6-1517592af8c8"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("51e08ce3-91bb-4691-835e-de6924e3c390"));
            base.InitializeControls();
        }

        public AnesthesiaReturnToRequestForm() : base("ANESTHESIAANDREANIMATION", "AnesthesiaReturnToRequestForm")
        {
        }

        protected AnesthesiaReturnToRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}