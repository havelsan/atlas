
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
    /// Stok Ayırtma Temel Form
    /// </summary>
    public partial class BaseStockReservationForm : TTUnboundForm
    {
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelStore;
        protected ITTLabel labelReservedAmount;
        protected ITTTextBox ReservedAmount;
        protected ITTTextBox StoreStock;
        protected ITTObjectListBox Store;
        protected ITTLabel lableStoreStock;
        protected ITTObjectListBox Material;
        protected ITTLabel labelMaterial;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("6a642050-31eb-47c5-90d5-285d3c5391f6"));
            labelStore = (ITTLabel)AddControl(new Guid("41e9af14-4006-4869-bd44-08ae275c9250"));
            labelReservedAmount = (ITTLabel)AddControl(new Guid("adae305f-988c-4c9f-9dca-0ed545a8c47a"));
            ReservedAmount = (ITTTextBox)AddControl(new Guid("2b776f59-ebeb-4234-a36f-9c8bc7cf489c"));
            StoreStock = (ITTTextBox)AddControl(new Guid("c574bbbb-72ad-4b1a-b77f-47d80074b1b3"));
            Store = (ITTObjectListBox)AddControl(new Guid("e8652c23-06b7-44ae-a529-4555296d24fd"));
            lableStoreStock = (ITTLabel)AddControl(new Guid("2a1fefdc-d154-448e-aa7c-c50ff7f3c52c"));
            Material = (ITTObjectListBox)AddControl(new Guid("dbb825c2-bba2-4b30-8d72-a63eb1b433e2"));
            labelMaterial = (ITTLabel)AddControl(new Guid("7553c6f5-00d6-4a82-8305-ffd9bf220231"));
            base.InitializeControls();
        }

        public BaseStockReservationForm() : base("BaseStockReservationForm")
        {
        }

        protected BaseStockReservationForm(string formDefName) : base(formDefName)
        {
        }
    }
}