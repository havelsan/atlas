
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
    /// Konsültasyon İstek
    /// </summary>
    public partial class ConsultationRequestCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Konsültasyon İstek İşleminin Yapıldığı Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.ConsultationRequest _ConsultationRequest
        {
            get { return (TTObjectClasses.ConsultationRequest)_ttObject; }
        }

        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelReasonOfCancel;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox RequestDoctor;
        protected ITTRichTextBoxControl RequestDescription;
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox Emergency;
        protected ITTCheckBox InPatientBed;
        protected ITTGrid ConsultationProcedures;
        protected ITTListBoxColumn MasterResource;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelRequestDescription;
        override protected void InitializeControls()
        {
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("40d88d7c-b07c-4bbf-a1bb-c415fcf3f35a"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("3c641ef7-a663-48a7-9618-5c067581cd8c"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("8f0533b7-30fa-42c4-b32c-edfbcabbffcb"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("def36bed-5913-4c33-a59a-de6f161a33c7"));
            RequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("431c7806-abd2-4073-80d9-b47bf9df395b"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("c579061e-7626-48f5-90d2-3bb9b077a0b2"));
            Emergency = (ITTCheckBox)AddControl(new Guid("13c72766-a453-404a-aee0-d58616d594c0"));
            InPatientBed = (ITTCheckBox)AddControl(new Guid("f17ca372-819d-498c-918f-1578e1f7cd0f"));
            ConsultationProcedures = (ITTGrid)AddControl(new Guid("640068a2-d0dd-47a0-b12b-c03eef8e9dfe"));
            MasterResource = (ITTListBoxColumn)AddControl(new Guid("0d36756b-24f9-41cf-8ad1-438b896b6b35"));
            labelActionDate = (ITTLabel)AddControl(new Guid("aa60d28c-fb3b-4fe7-861f-3c41b6cd34d4"));
            labelRequestDescription = (ITTLabel)AddControl(new Guid("1cc09ac8-edf6-472e-b5df-a73ab11604f2"));
            base.InitializeControls();
        }

        public ConsultationRequestCancelledForm() : base("CONSULTATIONREQUEST", "ConsultationRequestCancelledForm")
        {
        }

        protected ConsultationRequestCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}