
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
    /// Ayırtılmışları Görüntüleme
    /// </summary>
    public partial class StockReservationViewForm : BaseStockReservationForm
    {
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid StockReservations;
        protected ITTTextBoxColumn ReservationDescription;
        protected ITTTextBoxColumn ReservationAmount;
        protected ITTTextBoxColumn ReservationCurrentStateName;
        protected ITTButtonColumn CancelReservation;
        protected ITTTextBoxColumn StockReservationObjectID;
        protected ITTTextBoxColumn ReservationNewStateDefID;
        protected ITTTextBoxColumn OutDetailsCount;
        protected ITTButton CancelButton;
        protected ITTButton SaveButton;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("99f0597e-4e4e-4836-8282-4ba30093c616"));
            StockReservations = (ITTGrid)AddControl(new Guid("20cafafb-c1f8-4e6f-a731-e6870e5c758a"));
            ReservationDescription = (ITTTextBoxColumn)AddControl(new Guid("6196a464-e3b5-461c-916c-fe852d795d71"));
            ReservationAmount = (ITTTextBoxColumn)AddControl(new Guid("27fed891-a12b-487e-baf0-04cf0af9e520"));
            ReservationCurrentStateName = (ITTTextBoxColumn)AddControl(new Guid("21bc24dd-589b-4b18-86ef-f4e7d5020df7"));
            CancelReservation = (ITTButtonColumn)AddControl(new Guid("0570fc96-6869-4f88-8384-8f22c876010a"));
            StockReservationObjectID = (ITTTextBoxColumn)AddControl(new Guid("51a50d1c-4e1d-48ac-a58a-7aefa9bdd916"));
            ReservationNewStateDefID = (ITTTextBoxColumn)AddControl(new Guid("ed59ca15-538a-4530-a75a-dd8fc01f3ba3"));
            OutDetailsCount = (ITTTextBoxColumn)AddControl(new Guid("b56df12a-587b-45ea-a27b-a7eba0845bdc"));
            CancelButton = (ITTButton)AddControl(new Guid("38261ca9-2e56-4eaa-b62e-193c77ba1154"));
            SaveButton = (ITTButton)AddControl(new Guid("63072f6f-cdac-4914-b171-866bb8c29876"));
            base.InitializeControls();
        }

        public StockReservationViewForm() : base("StockReservationViewForm")
        {
        }

        protected StockReservationViewForm(string formDefName) : base(formDefName)
        {
        }
    }
}