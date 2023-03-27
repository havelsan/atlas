
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
    public partial class MedicalStuffDefinitionForm : TTUnboundForm
    {
        protected ITTButton btnUpdate;
        protected ITTCheckBox ttcheckbox1;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel1;
        protected ITTListView MedicalStuffListView;
        override protected void InitializeControls()
        {
            btnUpdate = (ITTButton)AddControl(new Guid("04c21ef0-f007-462e-b21c-42ed7f259557"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("6ddded00-7e1e-4910-866e-e46574469338"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("93004f93-9b18-4c37-8075-b240fdd3287f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1a330b5e-5333-4d8a-b2bc-eceefeff8326"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("a59b663f-858a-4788-b2e2-b2ff686ccf4b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("675d4e6e-3c3f-4b92-9290-011094b6a981"));
            MedicalStuffListView = (ITTListView)AddControl(new Guid("b159c242-d5ca-48be-907d-5614925fbed4"));
            base.InitializeControls();
        }

        public MedicalStuffDefinitionForm() : base("MedicalStuffDefinitionForm")
        {
        }

        protected MedicalStuffDefinitionForm(string formDefName) : base(formDefName)
        {
        }
    }
}