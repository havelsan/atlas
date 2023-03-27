
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
    /// Malzemenin Bulunduğu Yer Tanımları
    /// </summary>
    public partial class StockLocationForm : TTDefinitionForm
    {
    /// <summary>
    /// Malzemenin Bulunduğu Yer Tanımları
    /// </summary>
        protected TTObjectClasses.StockLocation _StockLocation
        {
            get { return (TTObjectClasses.StockLocation)_ttObject; }
        }

        protected ITTLabel labelParentStockLocation;
        protected ITTObjectListBox ParentStockLocation;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox IsGroup;
        override protected void InitializeControls()
        {
            labelParentStockLocation = (ITTLabel)AddControl(new Guid("f4fb00a6-48f6-49a6-a560-2bd882f4d7cf"));
            ParentStockLocation = (ITTObjectListBox)AddControl(new Guid("c904e630-f164-405a-8bce-15ebe9209403"));
            labelName = (ITTLabel)AddControl(new Guid("10ef1844-8b94-46a6-aff8-fda634721ca7"));
            Name = (ITTTextBox)AddControl(new Guid("0aa162dc-32c1-439e-80f0-7db86fd1e60a"));
            IsGroup = (ITTCheckBox)AddControl(new Guid("231ef99b-09b1-43eb-8cc9-b99975cf1fce"));
            base.InitializeControls();
        }

        public StockLocationForm() : base("STOCKLOCATION", "StockLocationForm")
        {
        }

        protected StockLocationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}