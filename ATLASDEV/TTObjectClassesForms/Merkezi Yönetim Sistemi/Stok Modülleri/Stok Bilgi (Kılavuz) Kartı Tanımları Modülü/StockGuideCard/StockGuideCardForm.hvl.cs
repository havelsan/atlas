
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
    /// Stok Bilgi (Kılavuz) Kartı Tanımı
    /// </summary>
    public partial class StockGuideCardForm : TTDefinitionForm
    {
    /// <summary>
    /// Stok Bilgi (Kılavuz) Kartı Tanımları
    /// </summary>
        protected TTObjectClasses.StockGuideCard _StockGuideCard
        {
            get { return (TTObjectClasses.StockGuideCard)_ttObject; }
        }

        protected ITTLabel labelStockCard;
        protected ITTObjectListBox StockCard;
        protected ITTGrid StockGuideCardDetails;
        protected ITTListBoxColumn MaterialStockGuideCardDetail;
        protected ITTTextBoxColumn AmountStockGuideCardDetail;
        protected ITTTextBox Name;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        protected ITTLabel labelName;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            labelStockCard = (ITTLabel)AddControl(new Guid("60b5a019-1752-4482-a7f2-6b70d47c8dc3"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("9a42a374-fd39-4c97-b1c3-d578ddb7232b"));
            StockGuideCardDetails = (ITTGrid)AddControl(new Guid("8d7a3088-119e-4761-a55a-364d5248ab8b"));
            MaterialStockGuideCardDetail = (ITTListBoxColumn)AddControl(new Guid("8e71c7c4-270c-4aa5-a711-58d4fb4e4fa2"));
            AmountStockGuideCardDetail = (ITTTextBoxColumn)AddControl(new Guid("41974c6a-63a5-4983-9177-038740ad5f93"));
            Name = (ITTTextBox)AddControl(new Guid("97731098-ba60-47a8-bb53-8f9305f8511b"));
            Description = (ITTTextBox)AddControl(new Guid("60990914-a70f-4841-8b82-d9a6e7196acc"));
            labelDescription = (ITTLabel)AddControl(new Guid("53062a19-025b-496f-9fb1-b7dc4fa09c8e"));
            labelName = (ITTLabel)AddControl(new Guid("7bca4198-3e8a-45c4-830a-ba2718a3c0c9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("41d25a66-79c7-4661-b1dc-bc5e89492711"));
            base.InitializeControls();
        }

        public StockGuideCardForm() : base("STOCKGUIDECARD", "StockGuideCardForm")
        {
        }

        protected StockGuideCardForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}