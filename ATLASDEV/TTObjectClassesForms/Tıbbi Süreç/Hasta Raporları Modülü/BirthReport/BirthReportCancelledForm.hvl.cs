
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
    /// Doğum Raporu İptal
    /// </summary>
    public partial class BirthReportCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Doğum Raporunu Yazıldığı Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.BirthReport _BirthReport
        {
            get { return (TTObjectClasses.BirthReport)_ttObject; }
        }

        protected ITTTextBox Report;
        protected ITTLabel labelReport;
        override protected void InitializeControls()
        {
            Report = (ITTTextBox)AddControl(new Guid("35d607e3-3121-4fa9-a4a8-634495380684"));
            labelReport = (ITTLabel)AddControl(new Guid("4c1668d5-74f4-4d54-b79c-abae301c9559"));
            base.InitializeControls();
        }

        public BirthReportCancelledForm() : base("BIRTHREPORT", "BirthReportCancelledForm")
        {
        }

        protected BirthReportCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}