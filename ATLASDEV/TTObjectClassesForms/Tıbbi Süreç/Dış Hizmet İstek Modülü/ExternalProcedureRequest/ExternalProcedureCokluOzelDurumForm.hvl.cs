
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
    /// Özel Durumun çoklu seçimi
    /// </summary>
    public partial class ExternalProcedureCokluOzelDurum : TTForm
    {
    /// <summary>
    /// Dış Hizmet İstek
    /// </summary>
        protected TTObjectClasses.ExternalProcedureRequest _ExternalProcedureRequest
        {
            get { return (TTObjectClasses.ExternalProcedureRequest)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTEnumComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("38671145-ae0f-43cd-a452-e2c37e129d6c"));
            cokluOzelDurum = (ITTEnumComboBoxColumn)AddControl(new Guid("f1cb35bc-aac0-4d89-9c29-5f66a807033a"));
            base.InitializeControls();
        }

        public ExternalProcedureCokluOzelDurum() : base("EXTERNALPROCEDUREREQUEST", "ExternalProcedureCokluOzelDurum")
        {
        }

        protected ExternalProcedureCokluOzelDurum(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}