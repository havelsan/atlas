
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
    public partial class DentalConsultationRequestForm : TTForm
    {
    /// <summary>
    /// Diş Konsültasyon İstek
    /// </summary>
        protected TTObjectClasses.DentalConsultationRequest _DentalConsultationRequest
        {
            get { return (TTObjectClasses.DentalConsultationRequest)_ttObject; }
        }

        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel8;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelRequestDescription;
        protected ITTGrid DentalConsultationProcedures;
        protected ITTListBoxColumn MasterResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox RequestDoctor;
        override protected void InitializeControls()
        {
            labelActionDate = (ITTLabel)AddControl(new Guid("8d7dd557-3ee8-4cbb-a681-663afdcb74b1"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("9adfb47e-3c29-4aed-866f-0d9b024716f5"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("e3792cdf-d5ef-4a05-93e8-bf442925b175"));
            labelRequestDescription = (ITTLabel)AddControl(new Guid("bf04e3f5-af21-4a30-be62-38460c95a9d1"));
            DentalConsultationProcedures = (ITTGrid)AddControl(new Guid("794fe509-8b62-4d08-ad1d-c3c20fc457dd"));
            MasterResource = (ITTListBoxColumn)AddControl(new Guid("ebf268a6-2b1a-4e39-838d-87b945377a0c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3e865de5-01a0-4a4e-a8f7-2df800560f02"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("9de0803f-ea63-4a5d-97f8-4a47185c72f2"));
            base.InitializeControls();
        }

        public DentalConsultationRequestForm() : base("DENTALCONSULTATIONREQUEST", "DentalConsultationRequestForm")
        {
        }

        protected DentalConsultationRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}