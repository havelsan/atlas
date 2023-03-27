
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
    /// Anestezi Konsültasyonu
    /// </summary>
    public partial class AnesthesiaConsultationRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Anestezi Konsültasyonu  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaConsultation _AnesthesiaConsultation
        {
            get { return (TTObjectClasses.AnesthesiaConsultation)_ttObject; }
        }

        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTRichTextBoxControl ConsultationRequestNote;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            LabelDateTime = (ITTLabel)AddControl(new Guid("05ed9d94-0c86-4c62-afab-21d167789e5c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("e8dc5a70-353c-4593-8182-0d09e47157e2"));
            ConsultationRequestNote = (ITTRichTextBoxControl)AddControl(new Guid("9ad0328d-b14e-4d1c-98c0-2f1fd18c2925"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("8647c34c-6e97-4fcc-8c53-ee8b179f79d9"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("e17e7cba-8659-44a2-82c2-5bdb176d4136"));
            base.InitializeControls();
        }

        public AnesthesiaConsultationRequestForm() : base("ANESTHESIACONSULTATION", "AnesthesiaConsultationRequestForm")
        {
        }

        protected AnesthesiaConsultationRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}