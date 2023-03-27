
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
    /// Akibet Raporu
    /// </summary>
    public partial class SRConstitutionofSituationReportForm : EpisodeActionForm
    {
    /// <summary>
    /// Akıbet Raporu
    /// </summary>
        protected TTObjectClasses.SituationReport _SituationReport
        {
            get { return (TTObjectClasses.SituationReport)_ttObject; }
        }

        protected ITTRichTextBoxControl Report;
        protected ITTObjectListBox SentInfo;
        protected ITTLabel labelSentInfo;
        override protected void InitializeControls()
        {
            Report = (ITTRichTextBoxControl)AddControl(new Guid("5b84fc20-6c48-4381-bec3-1456100ff92a"));
            SentInfo = (ITTObjectListBox)AddControl(new Guid("3dfd51a2-fea8-4f4b-a9ab-04385476bb90"));
            labelSentInfo = (ITTLabel)AddControl(new Guid("e78b5926-29d6-4aa6-9f49-d2f430b1baad"));
            base.InitializeControls();
        }

        public SRConstitutionofSituationReportForm() : base("SITUATIONREPORT", "SRConstitutionofSituationReportForm")
        {
        }

        protected SRConstitutionofSituationReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}