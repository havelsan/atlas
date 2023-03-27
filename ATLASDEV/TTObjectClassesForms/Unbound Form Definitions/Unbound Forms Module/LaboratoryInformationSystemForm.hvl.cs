
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
    /// Laboratuvar İşlemleri
    /// </summary>
    public partial class LaboratoryInformationSystemForm : TTUnboundForm
    {
        protected ITTComboBox ttcombobox2;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel4;
        protected ITTToolStrip tlbLaboratory;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel2;
        protected ITTComboBox ttcombobox1;
        protected ITTListView lvwPatient;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTPanel ttpanel1;
        protected ITTLabel ttlabel3;
        protected ITTListView lvwLaboratory;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttcombobox2 = (ITTComboBox)AddControl(new Guid("c1728877-cb70-4abe-8d1d-403fd79b7a35"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("b1c428de-c8f0-4804-b393-208d491e47bf"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("00369b0b-a4ac-43de-9354-2192572d7b13"));
            tlbLaboratory = (ITTToolStrip)AddControl(new Guid("8142d786-266c-47f5-b823-3d2c34484578"));
            ttbutton1 = (ITTButton)AddControl(new Guid("9041fd1d-33f2-40f4-a066-2103fe2710e5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("051ddb35-4236-4f92-b177-50550b85594f"));
            ttcombobox1 = (ITTComboBox)AddControl(new Guid("e14815f0-1780-4087-8093-61c59cdb6527"));
            lvwPatient = (ITTListView)AddControl(new Guid("794cd6cd-917f-407c-a63d-4271ea55e022"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("aa162d3c-a7b9-43f1-96f8-488b1755e538"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("481c64ec-7695-47b7-9e96-5fe088983779"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("466de576-39e6-4510-bcd0-81586740eb37"));
            lvwLaboratory = (ITTListView)AddControl(new Guid("ca8522b9-39b0-46a3-bbf7-56d3afe05738"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("79fefc52-d11c-44ea-85fc-7d28d7a5d25d"));
            base.InitializeControls();
        }

        public LaboratoryInformationSystemForm() : base("LaboratoryInformationSystemForm")
        {
        }

        protected LaboratoryInformationSystemForm(string formDefName) : base(formDefName)
        {
        }
    }
}