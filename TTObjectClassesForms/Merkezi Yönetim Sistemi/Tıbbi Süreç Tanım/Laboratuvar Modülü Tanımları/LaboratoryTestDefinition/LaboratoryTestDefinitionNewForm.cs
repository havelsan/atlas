
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Laboratuvar Tetkik Tanımları
    /// </summary>
    public partial class LaboratoryTestDefinitionNewForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region LaboratoryTestDefinitionNewForm_PreScript
    base.PreScript();
            if(this._LaboratoryTestDefinition.IsPassiveNow == null)
                this.chkPassiveNow.Value = false;
            if(this._LaboratoryTestDefinition.IsPanel == null)
                this.IsPanel.Value = false;
            if(this._LaboratoryTestDefinition.IsSubTest == null)
                this.IsSubTest.Value = false;
            if(this._LaboratoryTestDefinition.IsSat == null)
                this.IsSAT.Value = false;
            if(this._LaboratoryTestDefinition.IsDurationControl == null)
                this.IsDurationControl.Value = false;
            if(this._LaboratoryTestDefinition.IsBoundedTest == null)
                this.IsBoundedTest.Value = false;
            if(this._LaboratoryTestDefinition.IsRestrictedTest == null)
                this.IsRestrictedTest.Value = false;
            if(this._LaboratoryTestDefinition.IsSexControl == null)
                this.IsSexControl.Value = false;
            if(this._LaboratoryTestDefinition.IsPrintEveryPage == null)
                this.IsPrintEveryPage.Value = false;
            if(this._LaboratoryTestDefinition.IsPrintEveryPage == null)
                this.chkPrintInOneReport.Value = false;
            if(this._LaboratoryTestDefinition.NotLISTest == null)
                this.chkNotLISTest.Value = false;
            if(this._LaboratoryTestDefinition.RequiresBinaryScanForm == null)
                this.ttRequiresBinaryScanForm.Value = false;
            if(this._LaboratoryTestDefinition.RequiresTripleTestForm == null)
                this.ttReqiresTripleTestForm.Value = false;

            ((IEditableObject)this._LaboratoryTestDefinition).EndEdit();
#endregion LaboratoryTestDefinitionNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region LaboratoryTestDefinitionNewForm_PostScript
    base.PostScript(transDef);
            CheckLaboratoryTestDefinitionConsistency();
            CheckCollectionElementDuplication();
            SetSubTestDefAsNotChargable();
#endregion LaboratoryTestDefinitionNewForm_PostScript

            }
            
#region LaboratoryTestDefinitionNewForm_Methods
        private bool isGridHasZeroRows(ITTGrid ttGrid)
        {
            if(ttGrid.Rows.Count == 0)
                return true;
            return false;
        }
        
        public void CheckLaboratoryTestDefinitionConsistency()
        {
            bool isPanel = IsPanel.Value.Value;
            bool isSubTest = IsSubTest.Value.Value;
            bool isSAT = IsSAT.Value.Value;
            bool isDurationControl = IsDurationControl.Value.Value;
            bool isBoundedTest = IsBoundedTest.Value.Value;
            bool isRestrictedTest = IsRestrictedTest.Value.Value;
            bool isSexControl = IsSexControl.Value.Value;
            //bool isHeader = IsHeader.Value.Value;
            bool isPrintEveryPage = IsPrintEveryPage.Value.Value;
            
            if(isPanel)
            {
                if(isGridHasZeroRows(GridPanelTests))
                    throw new Exception(SystemMessage.GetMessage(1256));
                if(isSubTest)
                    throw new Exception(SystemMessage.GetMessage(1257));
            }
            
            if(isSubTest && !isGridHasZeroRows(TabNameGrid))
                throw new Exception(SystemMessage.GetMessage(1258));
            
            if(isSubTest && isBoundedTest)
                throw new Exception(SystemMessage.GetMessage(1259));
            
            if(isBoundedTest && isGridHasZeroRows(GridBoundedTests))
                throw new Exception(SystemMessage.GetMessage(1260));
            
            if(isRestrictedTest && isGridHasZeroRows(GridRestrictedTests))
                throw new Exception(SystemMessage.GetMessage(1261));
            
            if(isSexControl && sexListBox.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(1262));
            
            if(isDurationControl && DurationValue.Text == null)
                throw new Exception(SystemMessage.GetMessage(1263));
        }

        public void CheckCollectionElementDuplication()
        {
            Dictionary<String,Object> dictionary = new Dictionary<String,Object>();

            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteMerkezSagKom != siteIDGuid)
            {
                if(_LaboratoryTestDefinition.Departments.Count == 0)
                    throw new Exception(SystemMessage.GetMessage(1264));
            }
            // Aynı Bölüm Kontrolü
            for (int i = 0; i < _LaboratoryTestDefinition.Departments.Count; i++)
            {
                string Code = _LaboratoryTestDefinition.Departments[i].Department.ObjectID.ToString();
                CheckAndAddToDictionary(dictionary, Code, _ttObject, "Bölüm");
            }
            dictionary.Clear();
            
            // Aynı Cihaz Kontrolü
            
            for (int i = 0; i < _LaboratoryTestDefinition.Equipments.Count; i++)
            {
                string Code = _LaboratoryTestDefinition.Equipments[i].Equipment.ObjectID.ToString();
                CheckAndAddToDictionary(dictionary, Code, _ttObject, "Cihaz");
            }
            dictionary.Clear();
            
            // Aynı Malzeme Kontrolü
            for (int i = 0; i < _LaboratoryTestDefinition.Materials.Count; i++)
            {
                string Code = _LaboratoryTestDefinition.Materials[i].Material.ObjectID.ToString();
                CheckAndAddToDictionary(dictionary, Code, _ttObject, "Malzeme");
            }
            dictionary.Clear();
            
            // Aynı PanelTests Kontrolü
            for (int i = 0; i < _LaboratoryTestDefinition.PanelTests.Count; i++)
            {
                string Code = _LaboratoryTestDefinition.PanelTests[i].LaboratoryTest.ObjectID.ToString();
                CheckAndAddToDictionary(dictionary, Code, _ttObject, "Malzeme");
            }
            dictionary.Clear();
            
        }
        
        private void CheckAndAddToDictionary(Dictionary<String,Object> dictionary, string Code, object ttObject, string description)
        {
            if(dictionary.ContainsKey(Code))
            {
                throw new Exception(SystemMessage.GetMessage(1265));
            }
            else
            {
                dictionary.Add(Code,_ttObject);
            }
        }
        
        private void SetSubTestDefAsNotChargable()
        {
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteMerkezSagKom == siteIDGuid)
            {
                bool isSubTest = IsSubTest.Value.Value;
                if(isSubTest)
                    this._LaboratoryTestDefinition.Chargable = false;
            }
            
        }
        
#endregion LaboratoryTestDefinitionNewForm_Methods
    }
}