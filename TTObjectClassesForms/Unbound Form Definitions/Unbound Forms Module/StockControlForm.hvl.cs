
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
    public partial class StockControlForm : TTUnboundForm
    {
        protected ITTObjectListBox storelistbox;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTGrid Inheldgrid;
        protected ITTTextBoxColumn Material;
        protected ITTTextBoxColumn Inheld;
        override protected void InitializeControls()
        {
            storelistbox = (ITTObjectListBox)AddControl(new Guid("c13e534b-c30a-456b-b575-23a7b0d55427"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0a5d1d0d-46dd-44aa-8459-8160b259edfb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b5d11851-d135-4cd4-af7c-d6678122aa3d"));
            Inheldgrid = (ITTGrid)AddControl(new Guid("6e3689d9-8514-4c94-abf7-f2c36adbab93"));
            Material = (ITTTextBoxColumn)AddControl(new Guid("fb7a6da6-f15f-49ac-8f11-832d7fc25f78"));
            Inheld = (ITTTextBoxColumn)AddControl(new Guid("46d0b6a6-4b44-40cf-8fe0-8acf36faf3bc"));
            base.InitializeControls();
        }

        public StockControlForm() : base("StockControlForm")
        {
        }

        protected StockControlForm(string formDefName) : base(formDefName)
        {
        }
    }
}