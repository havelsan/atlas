
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
    /// Fatura Bilgileri Düzeltme
    /// </summary>
    public partial class ActionInfoCorrectionForm : TTForm
    {
    /// <summary>
    /// Fatura İşlem Düzeltme Belgesi
    /// </summary>
        protected TTObjectClasses.ActionInfoCorrection _ActionInfoCorrection
        {
            get { return (TTObjectClasses.ActionInfoCorrection)_ttObject; }
        }

        protected ITTGrid ActionInfoCorrectionDets;
        protected ITTListBoxColumn MaterialActionInfoCorrectionDet;
        protected ITTTextBoxColumn AmountActionInfoCorrectionDet;
        protected ITTLabel labelExaminationReportNo;
        protected ITTTextBox ExaminationReportNo;
        protected ITTTextBox BaseNumber;
        protected ITTLabel labelExaminationReportDate;
        protected ITTDateTimePicker ExaminationReportDate;
        protected ITTLabel labelBaseNumber;
        protected ITTLabel labelBaseDateTime;
        protected ITTDateTimePicker BaseDateTime;
        override protected void InitializeControls()
        {
            ActionInfoCorrectionDets = (ITTGrid)AddControl(new Guid("0cee7c59-5a34-4091-b94d-4d212e897d12"));
            MaterialActionInfoCorrectionDet = (ITTListBoxColumn)AddControl(new Guid("bf3015e9-7a55-4658-9858-745a5c9845f6"));
            AmountActionInfoCorrectionDet = (ITTTextBoxColumn)AddControl(new Guid("39b9e5b4-94d4-4482-88f9-5cf50a3de7a8"));
            labelExaminationReportNo = (ITTLabel)AddControl(new Guid("47b86504-f920-46f4-b4fc-3c20396ade1d"));
            ExaminationReportNo = (ITTTextBox)AddControl(new Guid("f2758f16-b923-48af-af1f-8e5a4ad43cb0"));
            BaseNumber = (ITTTextBox)AddControl(new Guid("6d1616f5-8e3e-4298-a7c5-62aef7d83d07"));
            labelExaminationReportDate = (ITTLabel)AddControl(new Guid("b271b3c6-aae8-42db-af13-7447d5c5310d"));
            ExaminationReportDate = (ITTDateTimePicker)AddControl(new Guid("e5f76b9d-05e7-451a-bd38-1f5d3614b8f6"));
            labelBaseNumber = (ITTLabel)AddControl(new Guid("bdf60385-204b-41e0-a53d-4d11a0a1b3e5"));
            labelBaseDateTime = (ITTLabel)AddControl(new Guid("55e04b5d-d12c-4ee3-8d73-a9b4f1fc89a3"));
            BaseDateTime = (ITTDateTimePicker)AddControl(new Guid("6c728214-ef29-4062-84b5-bc70741ccea9"));
            base.InitializeControls();
        }

        public ActionInfoCorrectionForm() : base("ACTIONINFOCORRECTION", "ActionInfoCorrectionForm")
        {
        }

        protected ActionInfoCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}