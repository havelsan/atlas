
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
    /// Sağlık Kurulu Rapor Çıkış Gönderilecek Yer Tanımlama
    /// </summary>
    public partial class HCReportToBeSentItemsDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sağlık Kurulu Rapor Çıkış Gönderilecek Yer Tanımlama
    /// </summary>
        protected TTObjectClasses.HCReportToBeSentItemsDefinition _HCReportToBeSentItemsDefinition
        {
            get { return (TTObjectClasses.HCReportToBeSentItemsDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("812f63a5-09c5-49b2-b72b-12ef0390688e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ca3e186c-7678-46eb-8b6f-8bb92a10e03c"));
            base.InitializeControls();
        }

        public HCReportToBeSentItemsDefinitionForm() : base("HCREPORTTOBESENTITEMSDEFINITION", "HCReportToBeSentItemsDefinitionForm")
        {
        }

        protected HCReportToBeSentItemsDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}