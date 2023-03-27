
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
    public partial class ConsultationCokluOzelDurum : TTForm
    {
        protected TTObjectClasses.Consultation _Consultation
        {
            get { return (TTObjectClasses.Consultation)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTEnumComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("a81a2586-5831-4383-b6a7-5f6b671a3d8b"));
            cokluOzelDurum = (ITTEnumComboBoxColumn)AddControl(new Guid("70c8039a-fdd7-4341-8e01-ff2c676a2a6b"));
            base.InitializeControls();
        }

        public ConsultationCokluOzelDurum() : base("CONSULTATION", "ConsultationCokluOzelDurum")
        {
        }

        protected ConsultationCokluOzelDurum(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}