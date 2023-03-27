
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
    /// Taburculuk İşlemleri
    /// </summary>
    public partial class TreatmentDischargeForm : EpisodeActionForm
    {
    /// <summary>
    /// Taburcu İşlemleri Sisteme Girildiği  Nesnedir
    /// </summary>
        protected TTObjectClasses.TreatmentDischarge _TreatmentDischarge
        {
            get { return (TTObjectClasses.TreatmentDischarge)_ttObject; }
        }

        protected ITTLabel labelTransferTreatmentClinic;
        protected ITTObjectListBox TransferTreatmentClinic;
        protected ITTLabel labelDischargeType;
        protected ITTObjectListBox DischargeType;
        protected ITTLabel labelConclusion;
        protected ITTRichTextBoxControl Conclusion;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker DisChargeDate;
        protected ITTLabel ttlabelDisChargeDate;
        override protected void InitializeControls()
        {
            labelTransferTreatmentClinic = (ITTLabel)AddControl(new Guid("062d0f28-b6db-491b-a13f-82f6c69db2b5"));
            TransferTreatmentClinic = (ITTObjectListBox)AddControl(new Guid("7b125fb2-7323-4f49-aa12-a4c1bf6f50fb"));
            labelDischargeType = (ITTLabel)AddControl(new Guid("d8da0d7a-0f6a-41c0-9517-632b6e9e1d5b"));
            DischargeType = (ITTObjectListBox)AddControl(new Guid("e875fa13-3ea2-4df8-a40c-1cf4335078ef"));
            labelConclusion = (ITTLabel)AddControl(new Guid("cfba9fe8-099b-4f10-896a-54951c098e69"));
            Conclusion = (ITTRichTextBoxControl)AddControl(new Guid("65ab8c58-fca2-4ea2-a43f-ef7d747c9de8"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("90c0f20c-a39d-4273-8e79-3bb8f5e7ea69"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("d44bd70c-760b-470c-b00c-1a025c6dd9ce"));
            DisChargeDate = (ITTDateTimePicker)AddControl(new Guid("1df94264-19df-4cc0-81a9-0d51972701e7"));
            ttlabelDisChargeDate = (ITTLabel)AddControl(new Guid("80f407c9-0c87-4959-9714-ff8929bf54b6"));
            base.InitializeControls();
        }

        public TreatmentDischargeForm() : base("TREATMENTDISCHARGE", "TreatmentDischargeForm")
        {
        }

        protected TreatmentDischargeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}