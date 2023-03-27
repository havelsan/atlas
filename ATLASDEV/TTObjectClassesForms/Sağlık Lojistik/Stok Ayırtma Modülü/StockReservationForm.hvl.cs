
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
    /// Stok Ayırt
    /// </summary>
    public partial class StockReservationForm : BaseStockReservationForm
    {
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTButton SaveButton;
        protected ITTButton CancelButton;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("4f4749c2-0fe2-471b-8bca-c723c3cb8b78"));
            labelAmount = (ITTLabel)AddControl(new Guid("3a1cd670-2388-4ab2-8fd4-d88b565ac9a5"));
            Amount = (ITTTextBox)AddControl(new Guid("008b0229-d625-4ed1-afbc-0266b279924d"));
            labelDescription = (ITTLabel)AddControl(new Guid("38079b36-f154-4fe0-8099-decad345ae2f"));
            Description = (ITTTextBox)AddControl(new Guid("79339f72-6521-425f-b22f-fdc1a367049e"));
            SaveButton = (ITTButton)AddControl(new Guid("a413b135-fc29-45b5-96d2-ff1877ff7b0d"));
            CancelButton = (ITTButton)AddControl(new Guid("409fe986-9ace-465b-ae97-b28b9442cbc4"));
            base.InitializeControls();
        }

        public StockReservationForm() : base("StockReservationForm")
        {
        }

        protected StockReservationForm(string formDefName) : base(formDefName)
        {
        }
    }
}