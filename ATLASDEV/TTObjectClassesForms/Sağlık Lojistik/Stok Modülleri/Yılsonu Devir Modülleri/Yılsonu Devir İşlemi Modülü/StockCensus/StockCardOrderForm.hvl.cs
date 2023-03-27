
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
    /// Stok Kartı Sıralama
    /// </summary>
    public partial class StockCardOrderForm : TTForm
    {
    /// <summary>
    /// Yılsonu Devir İşlemi
    /// </summary>
        protected TTObjectClasses.StockCensus _StockCensus
        {
            get { return (TTObjectClasses.StockCensus)_ttObject; }
        }

        protected ITTButton ttbutton1;
        protected ITTGrid StockCardOrders;
        protected ITTListBoxColumn StockCard;
        protected ITTTextBoxColumn OldCardOrderNo;
        protected ITTTextBoxColumn CardOrderNo;
        override protected void InitializeControls()
        {
            ttbutton1 = (ITTButton)AddControl(new Guid("db450652-81a7-474a-b8d5-25d4f87058a5"));
            StockCardOrders = (ITTGrid)AddControl(new Guid("7c7c6f01-dd7c-4121-ad40-8fd34fc884ce"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("dc3fad57-b798-41ef-bfde-156fb5869d69"));
            OldCardOrderNo = (ITTTextBoxColumn)AddControl(new Guid("5579b0b1-deeb-40ca-a13c-eddc08638095"));
            CardOrderNo = (ITTTextBoxColumn)AddControl(new Guid("422bdc7e-30cb-41e8-ad4f-bce92792decb"));
            base.InitializeControls();
        }

        public StockCardOrderForm() : base("STOCKCENSUS", "StockCardOrderForm")
        {
        }

        protected StockCardOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}