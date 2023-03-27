
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
    public partial class RegularObstetricCokluOzelDurumForm : TTForm
    {
    /// <summary>
    /// Normal Doğum
    /// </summary>
        protected TTObjectClasses.RegularObstetric _RegularObstetric
        {
            get { return (TTObjectClasses.RegularObstetric)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListDefComboBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("960dd742-d174-4c64-a07c-7116b1f69ed1"));
            CokluOzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("63d110ce-01aa-4758-bab2-ef6325367916"));
            base.InitializeControls();
        }

        public RegularObstetricCokluOzelDurumForm() : base("REGULAROBSTETRIC", "RegularObstetricCokluOzelDurumForm")
        {
        }

        protected RegularObstetricCokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}