
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
    /// Transfer Detayları
    /// </summary>
    public partial class FirstInStockActionForm : TTForm
    {
        protected TTObjectClasses.FirstInStockAction _FirstInStockAction
        {
            get { return (TTObjectClasses.FirstInStockAction)_ttObject; }
        }

        protected ITTGrid InStockActions;
        protected ITTTextBoxColumn StockActionID;
        protected ITTTextBoxColumn StockActionDescriptionInStockAction;
        override protected void InitializeControls()
        {
            InStockActions = (ITTGrid)AddControl(new Guid("00f0ff19-8ade-4e71-9907-29bd82b83695"));
            StockActionID = (ITTTextBoxColumn)AddControl(new Guid("a22354a6-8261-4cc1-b272-cebdfc0e6756"));
            StockActionDescriptionInStockAction = (ITTTextBoxColumn)AddControl(new Guid("eb364619-8466-4d31-9271-2402386c6c60"));
            base.InitializeControls();
        }

        public FirstInStockActionForm() : base("FIRSTINSTOCKACTION", "FirstInStockActionForm")
        {
        }

        protected FirstInStockActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}