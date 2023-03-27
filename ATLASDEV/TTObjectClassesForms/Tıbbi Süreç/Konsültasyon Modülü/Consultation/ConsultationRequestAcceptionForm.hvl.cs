
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
    public partial class ConsultationRequestAcception : EpisodeActionForm
    {
        protected TTObjectClasses.Consultation _Consultation
        {
            get { return (TTObjectClasses.Consultation)_ttObject; }
        }

        protected ITTLabel ttlabel8;
        protected ITTObjectListBox RequestedDoctor;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTObjectListBox RequesterDepatment;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelActionDate;
        protected ITTCheckBox InPatientBed;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequesterDepatment;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel lblProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttlabel8 = (ITTLabel)AddControl(new Guid("17eeff36-e378-4d85-a1e7-9e4a50d0f9b0"));
            RequestedDoctor = (ITTObjectListBox)AddControl(new Guid("aa350bcc-3f6e-4ca4-bcbb-5ba9d5f3501b"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("cf09ef0c-0491-41b9-acaf-c9efbca8c3d9"));
            RequesterDepatment = (ITTObjectListBox)AddControl(new Guid("e967fc0f-8b1d-4f73-9d83-2526e31bb215"));
            Emergency = (ITTCheckBox)AddControl(new Guid("7c0cf37c-5b6c-484e-8521-00b0c8821564"));
            labelActionDate = (ITTLabel)AddControl(new Guid("8c92feca-c888-44db-b85c-952b5f05a212"));
            InPatientBed = (ITTCheckBox)AddControl(new Guid("6db5ee2a-4ee7-4004-a468-aa0515ae6007"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8e28f0d6-0684-4222-80f2-9b10bc3fdd00"));
            labelRequesterDepatment = (ITTLabel)AddControl(new Guid("73ded559-b3d6-477d-98f1-503777c49855"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("7962f87c-5d93-4d84-baad-dcc08d9dcf1f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("a23404c5-580a-46ce-a68b-4d79c5aac440"));
            lblProcedureDoctor = (ITTLabel)AddControl(new Guid("b5c85e46-d0a9-4145-a2dc-1e80196a1865"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("2311fafe-6c59-4d37-a393-b42c96043ea6"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("ec29e714-4a33-4933-ad88-4cc5491d39a1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fc08a5b6-e177-4087-b3ef-2b2af1a4292a"));
            base.InitializeControls();
        }

        public ConsultationRequestAcception() : base("CONSULTATION", "ConsultationRequestAcception")
        {
        }

        protected ConsultationRequestAcception(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}