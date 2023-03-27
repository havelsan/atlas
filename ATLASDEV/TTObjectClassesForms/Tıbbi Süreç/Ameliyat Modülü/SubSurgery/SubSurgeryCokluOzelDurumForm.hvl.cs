
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
    public partial class SubSurgeryCokluOzelDurumForm : TTForm
    {
    /// <summary>
    /// Aynı Seansda Birden Fazla Bölüm Ameliyat Gerçekleştirdiğinde Diğer Bölümler İçin Kullanılan Nesnedir 
    /// </summary>
        protected TTObjectClasses.SubSurgery _SubSurgery
        {
            get { return (TTObjectClasses.SubSurgery)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListDefComboBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("ee91b858-7f62-4ad8-b1b9-038804ee7667"));
            CokluOzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("2a760c80-c684-4304-acc8-ea6c4455cb06"));
            base.InitializeControls();
        }

        public SubSurgeryCokluOzelDurumForm() : base("SUBSURGERY", "SubSurgeryCokluOzelDurumForm")
        {
        }

        protected SubSurgeryCokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}