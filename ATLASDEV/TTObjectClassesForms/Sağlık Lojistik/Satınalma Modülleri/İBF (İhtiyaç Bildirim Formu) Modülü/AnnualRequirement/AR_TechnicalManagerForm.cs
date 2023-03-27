
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
    /// Teknik Müdür
    /// </summary>
    public partial class AR_TechnicalManagerForm : AR_BaseForm
    {
        override protected void BindControlEvents()
        {
            IBFYear.TextChanged += new TTControlEventDelegate(IBFYear_TextChanged);
            IBFType.SelectedIndexChanged += new TTControlEventDelegate(IBFType_SelectedIndexChanged);
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IBFYear.TextChanged -= new TTControlEventDelegate(IBFYear_TextChanged);
            IBFType.SelectedIndexChanged -= new TTControlEventDelegate(IBFType_SelectedIndexChanged);
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            base.UnBindControlEvents();
        }

        private void IBFYear_TextChanged()
        {
#region AR_TechnicalManagerForm_IBFYear_TextChanged
   _AnnualRequirement.ClearChildrenCollections();
#endregion AR_TechnicalManagerForm_IBFYear_TextChanged
        }

        private void IBFType_SelectedIndexChanged()
        {
#region AR_TechnicalManagerForm_IBFType_SelectedIndexChanged
   _AnnualRequirement.ClearChildrenCollections();
#endregion AR_TechnicalManagerForm_IBFType_SelectedIndexChanged
        }

        private void cmdList_Click()
        {
#region AR_TechnicalManagerForm_cmdList_Click
   if(_AnnualRequirement.IBFType == null || _AnnualRequirement.IBFYear == null)
                return;
            
            _AnnualRequirement.FillDemands(Convert.ToInt32(_AnnualRequirement.IBFType.Value), _AnnualRequirement.IBFYear.Value);
            
            ShowNeededGrids();
#endregion AR_TechnicalManagerForm_cmdList_Click
        }

        protected override void PreScript()
        {
#region AR_TechnicalManagerForm_PreScript
    base.PreScript();
            
            Guid hospGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hosp = (ResHospital)_AnnualRequirement.ObjectContext.GetObject(hospGuid, "RESHOSPITAL");
            
            Accountancy.ListFilterExpression = "ACCOUNTANCYMILITARYUNIT = '" + hosp.MilitaryUnit.ObjectID.ToString() + "'";
#endregion AR_TechnicalManagerForm_PreScript

            }
                }
}