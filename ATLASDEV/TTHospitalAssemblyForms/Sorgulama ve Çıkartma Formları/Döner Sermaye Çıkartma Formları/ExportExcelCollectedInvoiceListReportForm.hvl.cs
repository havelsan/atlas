
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
    public partial class ExportExcelCollectedInvoiceListReport : BaseExportExcelUnboundForm
    {
        protected ITTTextBox baseActionIDTextBox;
        protected ITTButton applyButton;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            baseActionIDTextBox = (ITTTextBox)AddControl(new Guid("b617cca1-1bf4-47c9-b353-0d944871b1ca"));
            applyButton = (ITTButton)AddControl(new Guid("fd9c4a13-09cb-42fe-b7d5-29899204cb80"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("575a83c8-99e0-4ca7-83b9-922a9de21cb4"));
            base.InitializeControls();
        }

        public ExportExcelCollectedInvoiceListReport() : base("ExportExcelCollectedInvoiceListReport")
        {
        }

        protected ExportExcelCollectedInvoiceListReport(string formDefName) : base(formDefName)
        {
        }
    }
}