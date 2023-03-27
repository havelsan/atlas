
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
    /// Oral Diagnoz ve Radyoloji
    /// </summary>
    public partial class DentalExaminationNewForm : EpisodeActionForm
    {
    /// <summary>
    /// Oral Diagnoz ve Radyoloji İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalExamination _DentalExamination
        {
            get { return (TTObjectClasses.DentalExamination)_ttObject; }
        }

        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox Urgent;
        protected ITTLabel labelProtocolNo;
        protected ITTTextBox ProtocolNo;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("ce60e010-85ef-487d-8bda-d11082be535e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8de47e0f-c2f6-4418-bf44-3d6e7419f5ae"));
            Urgent = (ITTCheckBox)AddControl(new Guid("6aaa4ad6-2fc6-44ee-9c3a-6bb3e7809ebd"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("5f8ed85d-2697-4a17-9c2f-8a2bb2b1bd42"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d29935ca-b2a9-40c0-9cc9-d5846ab73bc2"));
            base.InitializeControls();
        }

        public DentalExaminationNewForm() : base("DENTALEXAMINATION", "DentalExaminationNewForm")
        {
        }

        protected DentalExaminationNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}