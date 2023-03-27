
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
    /// Radyoloji İşlemleri
    /// </summary>
    public partial class RadiologyInformationSystemForm : TTUnboundForm
    {
        protected ITTLabel ttlabel1;
        protected ITTGrid TestGrid;
        protected ITTCheckBox ttcheckbox1;
        protected ITTListView ttlistview1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton2;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tgSelectedRow;
        protected ITTGroupBox ttgroupbox3;
        protected ITTGrid PatientGrid;
        protected ITTButton ttbutton1;
        protected ITTDateTimePicker Edate;
        protected ITTGroupBox ttgroupbox1;
        protected ITTDateTimePicker Sdate;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("d55b1f04-37e6-4022-b244-046755ec46b1"));
            TestGrid = (ITTGrid)AddControl(new Guid("8276974c-f45f-4273-8952-2aacbe2942d1"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("56513dc7-484b-4793-bcea-3b268e5f09f0"));
            ttlistview1 = (ITTListView)AddControl(new Guid("723dc183-7db6-4d83-a0d0-4156d83d451a"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("587941f2-23a3-47ac-82f7-605206c388e6"));
            ttbutton3 = (ITTButton)AddControl(new Guid("450bd0fc-63c2-4754-9ad7-32a0b130fefd"));
            ttbutton2 = (ITTButton)AddControl(new Guid("eb5db05e-ecec-4511-b5bd-71b760d0b17d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3fb73ca9-514d-41d4-8013-ac91cc9fbee1"));
            tgSelectedRow = (ITTTextBox)AddControl(new Guid("ed24b9a5-430f-40ba-b92d-8ac8705a467e"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("9c6916ab-eada-485f-b722-a15967645653"));
            PatientGrid = (ITTGrid)AddControl(new Guid("8c22069d-4bb6-44c5-a1d8-bfc8afd1d540"));
            ttbutton1 = (ITTButton)AddControl(new Guid("7ba035bd-fd37-4ff3-81af-cda72843b652"));
            Edate = (ITTDateTimePicker)AddControl(new Guid("058930aa-2895-44bb-a6f9-c7a7b137368a"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("4cdde590-2768-4b8c-97d2-f6999d72693c"));
            Sdate = (ITTDateTimePicker)AddControl(new Guid("c4fd9788-9b88-411b-8455-ec0fd186135d"));
            base.InitializeControls();
        }

        public RadiologyInformationSystemForm() : base("RadiologyInformationSystemForm")
        {
        }

        protected RadiologyInformationSystemForm(string formDefName) : base(formDefName)
        {
        }
    }
}