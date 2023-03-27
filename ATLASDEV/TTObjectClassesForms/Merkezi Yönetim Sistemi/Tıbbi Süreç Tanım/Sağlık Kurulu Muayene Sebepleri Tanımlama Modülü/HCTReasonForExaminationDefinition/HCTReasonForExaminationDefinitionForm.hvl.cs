
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
    /// Sağlık Kurulu Üç İmza Muayene Sebepleri Formu
    /// </summary>
    public partial class HCTReasonForExaminationDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sağlık Kurulu Üç İmza Muayene Sebepleri
    /// </summary>
        protected TTObjectClasses.HCTReasonForExaminationDefinition _HCTReasonForExaminationDefinition
        {
            get { return (TTObjectClasses.HCTReasonForExaminationDefinition)_ttObject; }
        }

        protected ITTEnumComboBox SpecialistCount;
        protected ITTLabel lblSpecialistCount;
        protected ITTEnumComboBox ReportType;
        protected ITTLabel lblReportType;
        protected ITTTextBox ExaminationReason;
        protected ITTLabel labelReasonForExamination;
        override protected void InitializeControls()
        {
            SpecialistCount = (ITTEnumComboBox)AddControl(new Guid("45d61225-b9fb-46c3-9268-dbece37fbff8"));
            lblSpecialistCount = (ITTLabel)AddControl(new Guid("9abf72a2-229b-4e71-bc03-c120e4e9db28"));
            ReportType = (ITTEnumComboBox)AddControl(new Guid("d1702371-fa64-491a-9768-3c32d33e7292"));
            lblReportType = (ITTLabel)AddControl(new Guid("c97e4f4f-cc85-4ea3-83a9-148e6cf06d06"));
            ExaminationReason = (ITTTextBox)AddControl(new Guid("834bc587-2286-47c0-9da9-f1f200a69b64"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("09d55988-3903-48d2-863c-1b4a44dcbd87"));
            base.InitializeControls();
        }

        public HCTReasonForExaminationDefinitionForm() : base("HCTREASONFOREXAMINATIONDEFINITION", "HCTReasonForExaminationDefinitionForm")
        {
        }

        protected HCTReasonForExaminationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}