
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
    public partial class OrthesisProsthesisProcedure_CokluOzelDurumForm : TTForm
    {
        protected TTObjectClasses.OrthesisProsthesisProcedure _OrthesisProsthesisProcedure
        {
            get { return (TTObjectClasses.OrthesisProsthesisProcedure)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("d4839faf-937d-46d8-b6c7-3ffbda43ce9a"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("f6dae910-6323-4132-85de-97013a184578"));
            base.InitializeControls();
        }

        public OrthesisProsthesisProcedure_CokluOzelDurumForm() : base("ORTHESISPROSTHESISPROCEDURE", "OrthesisProsthesisProcedure_CokluOzelDurumForm")
        {
        }

        protected OrthesisProsthesisProcedure_CokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}