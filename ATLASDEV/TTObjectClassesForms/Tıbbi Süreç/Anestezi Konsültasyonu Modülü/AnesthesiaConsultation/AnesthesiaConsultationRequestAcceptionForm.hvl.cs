
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
    /// Anestezi Konsültasyon
    /// </summary>
    public partial class AnesthesiaConsultationRequestAcceptionForm : EpisodeActionForm
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
        protected ITTObjectListBox RequesterDepatment;
        protected ITTLabel labelRequesterDepatment;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            LabelDateTime = (ITTLabel)AddControl(new Guid("edf978ce-72a1-4da0-93ef-7c537036bc94"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("d73e4436-1ea4-4dec-9393-9816303026d3"));
            RequesterDepatment = (ITTObjectListBox)AddControl(new Guid("bcb8528c-b555-4c74-9d2f-3e5816d016bd"));
            labelRequesterDepatment = (ITTLabel)AddControl(new Guid("a8f01ac5-9dbe-4af9-87a5-bfc84244b10c"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("2c6e5572-95ad-4b16-83e8-91a507e34f1e"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("9808072a-65f4-4c28-ba70-1c08292211d4"));
            base.InitializeControls();
        }

        public AnesthesiaConsultationRequestAcceptionForm() : base("ANESTHESIACONSULTATION", "AnesthesiaConsultationRequestAcceptionForm")
        {
        }

        protected AnesthesiaConsultationRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}