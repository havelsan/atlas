
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
    /// Sağlık Kurulu Muayene Onay
    /// </summary>
    public partial class ExaminationApprovalNewForm : EpisodeActionForm
    {
    /// <summary>
    /// Muayene Onay Modülü
    /// </summary>
        protected TTObjectClasses.ExaminationApproval _ExaminationApproval
        {
            get { return (TTObjectClasses.ExaminationApproval)_ttObject; }
        }

        protected ITTLabel labelExplanationOfRequest;
        protected ITTLabel labelReportNo;
        protected ITTTextBox ReportNo;
        protected ITTTextBox ExplanationOfRequest;
        override protected void InitializeControls()
        {
            labelExplanationOfRequest = (ITTLabel)AddControl(new Guid("b6b123fe-b5c2-4132-8bfe-2dbd6ec5b48e"));
            labelReportNo = (ITTLabel)AddControl(new Guid("c3aa7bbc-532b-4892-a719-90ff395d22b8"));
            ReportNo = (ITTTextBox)AddControl(new Guid("5ee6efbc-21b4-4b63-8ec3-b65cca9191dc"));
            ExplanationOfRequest = (ITTTextBox)AddControl(new Guid("f4286d03-e356-4124-8169-e160cfa04341"));
            base.InitializeControls();
        }

        public ExaminationApprovalNewForm() : base("EXAMINATIONAPPROVAL", "ExaminationApprovalNewForm")
        {
        }

        protected ExaminationApprovalNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}