
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
    /// Giriş Mevcut Arttırma
    /// </summary>
    public partial class InheldIncreasingProcessForm : TTForm
    {
    /// <summary>
    /// Satınalma Mevcut Arttırma İşlemi
    /// </summary>
        protected TTObjectClasses.InheldIncreasingProcess _InheldIncreasingProcess
        {
            get { return (TTObjectClasses.InheldIncreasingProcess)_ttObject; }
        }

        protected ITTGrid InheldIncreasingProcessDets;
        protected ITTListBoxColumn MaterialInheldIncreasingProcessDet;
        protected ITTTextBoxColumn AmountInheldIncreasingProcessDet;
        protected ITTTextBoxColumn AddedAmountInheldIncreasingProcessDet;
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
            InheldIncreasingProcessDets = (ITTGrid)AddControl(new Guid("b340bebc-1ac2-43cf-b59a-52856d53021a"));
            MaterialInheldIncreasingProcessDet = (ITTListBoxColumn)AddControl(new Guid("59b3b9a1-5213-4f5f-bcce-c0a31b3e7274"));
            AmountInheldIncreasingProcessDet = (ITTTextBoxColumn)AddControl(new Guid("8e4d717b-03f8-483f-9571-ef7998369517"));
            AddedAmountInheldIncreasingProcessDet = (ITTTextBoxColumn)AddControl(new Guid("4bd295d2-1694-41fc-83bb-982573d670a0"));
            labelExaminationReportNo = (ITTLabel)AddControl(new Guid("18c6f4ea-f6e1-494c-8f1e-14ac36efca96"));
            ExaminationReportNo = (ITTTextBox)AddControl(new Guid("3d9b5bf2-b76c-40e3-9c44-4e56d0b560f8"));
            BaseNumber = (ITTTextBox)AddControl(new Guid("b12de3ac-a1e0-478d-8398-f9cb8ab43f7e"));
            labelExaminationReportDate = (ITTLabel)AddControl(new Guid("61212d2c-6cb0-4506-9c6e-e750da3e97a3"));
            ExaminationReportDate = (ITTDateTimePicker)AddControl(new Guid("c7a1d944-4255-4b3c-a6b6-c302ebd04f13"));
            labelBaseNumber = (ITTLabel)AddControl(new Guid("7e5178a2-97a3-46ef-a8b5-bcdfed3853fd"));
            labelBaseDateTime = (ITTLabel)AddControl(new Guid("90c31e50-4d95-4982-a565-926ddb0562f1"));
            BaseDateTime = (ITTDateTimePicker)AddControl(new Guid("6cf5b04c-4e82-4d54-9f1c-13776f39e969"));
            base.InitializeControls();
        }

        public InheldIncreasingProcessForm() : base("INHELDINCREASINGPROCESS", "InheldIncreasingProcessForm")
        {
        }

        protected InheldIncreasingProcessForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}