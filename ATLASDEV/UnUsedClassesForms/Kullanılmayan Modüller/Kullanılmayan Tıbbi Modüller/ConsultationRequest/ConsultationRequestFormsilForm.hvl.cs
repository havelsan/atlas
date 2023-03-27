
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
    public partial class ConsultationRequestFormsil : EpisodeActionForm
    {
    /// <summary>
    /// Konsültasyon İstek İşleminin Yapıldığı Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.ConsultationRequest _ConsultationRequest
        {
            get { return (TTObjectClasses.ConsultationRequest)_ttObject; }
        }

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
            ttlabel8 = (ITTLabel)AddControl(new Guid("aabc3649-c6b2-45ab-8a9c-72062979e7db"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("abc20b5b-b073-4cdf-9d90-ae46e514f641"));
            RequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("8284dae8-b7fa-4cb2-b6bd-646a665e1ce9"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("c4bb1797-be26-450b-ac77-10d862f5248d"));
            Emergency = (ITTCheckBox)AddControl(new Guid("e4a9f06d-5aa9-4569-8469-37abeadb1276"));
            InPatientBed = (ITTCheckBox)AddControl(new Guid("74a69873-2682-4921-9abe-7aa0bf91e3cd"));
            ConsultationProcedures = (ITTGrid)AddControl(new Guid("fb1ba4c7-0302-4664-9953-c11d04612429"));
            MasterResource = (ITTListBoxColumn)AddControl(new Guid("84594bb8-060f-491a-bf62-84cd077e91a3"));
            labelActionDate = (ITTLabel)AddControl(new Guid("72eda444-a60b-448a-a357-fa05bd02786d"));
            labelRequestDescription = (ITTLabel)AddControl(new Guid("329175fa-4e6a-4ff1-8905-2a197202a585"));
            base.InitializeControls();
        }

        public ConsultationRequestFormsil() : base("CONSULTATIONREQUEST", "ConsultationRequestFormsil")
        {
        }

        protected ConsultationRequestFormsil(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}