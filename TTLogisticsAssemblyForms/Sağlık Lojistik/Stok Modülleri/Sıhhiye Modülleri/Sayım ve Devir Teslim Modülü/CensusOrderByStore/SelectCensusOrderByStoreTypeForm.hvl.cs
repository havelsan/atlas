
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
    /// Depoya Göre Sayım Emri Tipi ve Masa Seçimi
    /// </summary>
    public partial class SelectCensusOrderByStoreTypeForm : TTForm
    {
    /// <summary>
    /// Sayım işlemi depo seçilerek
    /// </summary>
        protected TTObjectClasses.CensusOrderByStore _CensusOrderByStore
        {
            get { return (TTObjectClasses.CensusOrderByStore)_ttObject; }
        }

        protected ITTValueListBox Store;
        protected ITTEnumComboBox CensusOrderType;
        protected ITTLabel labelCensusOrderByStore;
        protected ITTLabel labelCensusOrderType;
        override protected void InitializeControls()
        {
            Store = (ITTValueListBox)AddControl(new Guid("bb748807-6556-445e-9fda-003663d5597d"));
            CensusOrderType = (ITTEnumComboBox)AddControl(new Guid("c8d2b15f-02d9-447b-a215-28901fa72c91"));
            labelCensusOrderByStore = (ITTLabel)AddControl(new Guid("e5da8aa6-e6c4-4e31-b405-2db0fa7101cc"));
            labelCensusOrderType = (ITTLabel)AddControl(new Guid("632fee2d-eee4-40a5-be80-e65f24b6a1fc"));
            base.InitializeControls();
        }

        public SelectCensusOrderByStoreTypeForm() : base("CENSUSORDERBYSTORE", "SelectCensusOrderByStoreTypeForm")
        {
        }

        protected SelectCensusOrderByStoreTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}