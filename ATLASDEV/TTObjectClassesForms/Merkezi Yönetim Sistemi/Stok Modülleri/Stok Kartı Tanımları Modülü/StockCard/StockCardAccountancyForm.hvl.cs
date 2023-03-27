
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
    public partial class StockCardAccountancyForm : StockCardForm
    {
    /// <summary>
    /// Stok Kart Tanımları
    /// </summary>
        protected TTObjectClasses.StockCard _StockCard
        {
            get { return (TTObjectClasses.StockCard)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("c845f286-9ef0-4834-85f3-c81a0bad405b"));
            base.InitializeControls();
        }

        public StockCardAccountancyForm() : base("STOCKCARD", "StockCardAccountancyForm")
        {
        }

        protected StockCardAccountancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}