
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
    public partial class ConsultationRequestForm : EpisodeActionForm
    {
        protected TTObjectClasses.Consultation _Consultation
        {
            get { return (TTObjectClasses.Consultation)_ttObject; }
        }

        protected ITTLabel ttlabel8;
        protected ITTObjectListBox RequestedDoctor;
        protected ITTRichTextBoxControl rtfRequestDescription;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelActionDate;
        protected ITTCheckBox InPatientBed;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel lblProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox RequesterDepatment;
        protected ITTLabel labelRequesterDepatment;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox EPISODEID;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            ttlabel8 = (ITTLabel)AddControl(new Guid("e4c06a15-56cb-4fb7-9d17-74984a3b3ef1"));
            RequestedDoctor = (ITTObjectListBox)AddControl(new Guid("2d3d2971-56f4-44d7-acce-39a100e01f0a"));
            rtfRequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("99dae2e2-02de-4ca5-b98d-9c0e6c97abfb"));
            Emergency = (ITTCheckBox)AddControl(new Guid("86bad8e1-6b86-4c81-8654-d684ac882edf"));
            labelActionDate = (ITTLabel)AddControl(new Guid("177c80f8-a366-4a78-bba7-ef12942b7e38"));
            InPatientBed = (ITTCheckBox)AddControl(new Guid("b5bac2f6-62c5-46ab-a3de-8a0003d1e2c1"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("e690567c-0306-448f-8bca-b652ae18cf5d"));
            lblProcedureDoctor = (ITTLabel)AddControl(new Guid("e8d1314a-5e67-480c-8017-2ec2c7711088"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("711b7319-b84e-440b-8698-344b02dd88e3"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("a024a95e-33bf-4a26-a115-936228949eca"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("69a574f2-fa7d-460a-8897-41395557306a"));
            RequesterDepatment = (ITTObjectListBox)AddControl(new Guid("b305d6fe-b712-4ab3-bc7a-3c3380ad9f82"));
            labelRequesterDepatment = (ITTLabel)AddControl(new Guid("b1cc3dc5-2195-4ba8-885d-06677cf6aeb2"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("3f63fc4a-9936-4c4f-a0a6-432cca203fd4"));
            EPISODEID = (ITTTextBox)AddControl(new Guid("1458cab9-a3fc-4155-8c37-4b0804fc9787"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("6f338010-6b00-4f73-a7af-0a35c29b5333"));
            base.InitializeControls();
        }

        public ConsultationRequestForm() : base("CONSULTATION", "ConsultationRequestForm")
        {
        }

        protected ConsultationRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}