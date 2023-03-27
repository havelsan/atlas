
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
    /// Sayım Emri Tipi ve Masa Seçimi
    /// </summary>
    public partial class SelectCensusOrderTypeForm : TTForm
    {
    /// <summary>
    /// Sayım Emri için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.CensusOrder _CensusOrder
        {
            get { return (TTObjectClasses.CensusOrder)_ttObject; }
        }

        protected ITTEnumComboBox CensusOrderType;
        protected ITTLabel labelCensusOrderType;
        protected ITTLabel labelCardDrawer;
        protected ITTObjectListBox CardDrawer;
        override protected void InitializeControls()
        {
            CensusOrderType = (ITTEnumComboBox)AddControl(new Guid("7912bc85-354a-414b-821d-8511c3be16ae"));
            labelCensusOrderType = (ITTLabel)AddControl(new Guid("924d55c0-ab13-4c7f-acf3-80c0cbd9e77a"));
            labelCardDrawer = (ITTLabel)AddControl(new Guid("1d1036ad-cfef-464a-84f1-c11cb3ddd46e"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("9eaf82db-854c-468d-ae8b-e548f9ce25a6"));
            base.InitializeControls();
        }

        public SelectCensusOrderTypeForm() : base("CENSUSORDER", "SelectCensusOrderTypeForm")
        {
        }

        protected SelectCensusOrderTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}