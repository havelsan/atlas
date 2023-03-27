
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
    public partial class DentalExaminationStartForm : EpisodeActionForm
    {
    /// <summary>
    /// Oral Diagnoz ve Radyoloji İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalExamination _DentalExamination
        {
            get { return (TTObjectClasses.DentalExamination)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelDateTime;
        protected ITTLabel labelImportantInfo;
        protected ITTObjectListBox ProcedureDoctor;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("ee8ea559-d7a1-4821-8453-5b5edb2a5c3f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8dec6da5-c796-4bd9-8e9d-06b44c54612e"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("fc42e4e5-2579-4dce-b7f0-25c45d715808"));
            labelImportantInfo = (ITTLabel)AddControl(new Guid("0f7ee786-5b99-4c0c-849d-379745e7e8ce"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("d34d91b3-167e-4033-a471-91f1ac25abfc"));
            base.InitializeControls();
        }

        public DentalExaminationStartForm() : base("DENTALEXAMINATION", "DentalExaminationStartForm")
        {
        }

        protected DentalExaminationStartForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}