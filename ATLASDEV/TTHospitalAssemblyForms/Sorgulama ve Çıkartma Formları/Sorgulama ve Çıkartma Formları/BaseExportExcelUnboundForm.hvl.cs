
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
    public partial class BaseExportExcelUnboundForm : TTUnboundForm
    {
        protected ITTTextBox fileNameTextBox;
        protected ITTLabel ttlabel1;
        protected ITTButton selectButton;
        protected ITTButton exportButton;
        protected ITTButton openButton;
        override protected void InitializeControls()
        {
            fileNameTextBox = (ITTTextBox)AddControl(new Guid("65b55a74-c63e-4706-ba48-6728157dc964"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fde733e4-04b1-46a3-a62b-f421cd608c72"));
            selectButton = (ITTButton)AddControl(new Guid("8ec67262-fd5b-40c1-a6a2-12ab2038c5e9"));
            exportButton = (ITTButton)AddControl(new Guid("76697b02-a513-4361-9c5f-0df20e9c1c55"));
            openButton = (ITTButton)AddControl(new Guid("ccdc770d-20f4-4e53-a381-073a459d6942"));
            base.InitializeControls();
        }

        public BaseExportExcelUnboundForm() : base("BaseExportExcelUnboundForm")
        {
        }

        protected BaseExportExcelUnboundForm(string formDefName) : base(formDefName)
        {
        }
    }
}