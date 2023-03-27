
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
    /// Stok Kontrolü
    /// </summary>
    public partial class StokControForm : TTForm
    {
    /// <summary>
    /// Stok Kontrol
    /// </summary>
        protected TTObjectClasses.StockControl _StockControl
        {
            get { return (TTObjectClasses.StockControl)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid Inheldgrid;
        protected ITTTextBoxColumn Material;
        protected ITTTextBoxColumn Inheld;
        protected ITTObjectListBox storelistbox;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d3517ac6-ac8b-4e42-92b4-8992adc7a8dd"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("02807b64-7097-44f1-a3fb-62e84864a6ad"));
            Inheldgrid = (ITTGrid)AddControl(new Guid("06386711-4970-4703-be75-5b6d48d29bd3"));
            Material = (ITTTextBoxColumn)AddControl(new Guid("689b657c-2fbe-4f52-b669-0b3458b55f55"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("eca2cd18-f205-4fe5-9ca8-c256284281f5"));
            storelistbox = (ITTObjectListBox)AddControl(new Guid("d40bfe22-6e21-40cd-b30d-e9f477998a09"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a9ed0789-7425-475c-b04e-94bd8088efa1"));
            base.InitializeControls();
        }

        public StokControForm() : base("STOCKCONTROL", "StokControForm")
        {
        }

        protected StokControForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}