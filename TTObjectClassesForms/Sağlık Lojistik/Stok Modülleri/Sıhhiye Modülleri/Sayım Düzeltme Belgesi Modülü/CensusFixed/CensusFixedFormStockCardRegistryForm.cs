
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
    /// Sayım Düzeltme Belgesi
    /// </summary>
    public partial class CensusFixedFormStockCardRegistryForm : BaseCensusFixedForm
    {
        protected override void PreScript()
        {
            #region CensusFixedFormStockCardRegistryForm_PreScript
            base.PreScript();
            int countIn = 1;
            foreach (ITTGridRow row in StockActionInDetails.Rows)
            {
                ((StockActionDetail)row.TTObject).ChattelDocDetailOrderNo = countIn;
                countIn++;
            }
            int countOut = 1;
            foreach (ITTGridRow row in StockActionOutDetails.Rows)
            {
                ((StockActionDetail)row.TTObject).ChattelDocDetailOrderNo = countOut;
                countOut++;
            }
            #endregion CensusFixedFormStockCardRegistryForm_PreScript

        }

        #region CensusFixedFormStockCardRegistryForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == CensusFixed.States.Completed)
                {

                    if ((_CensusFixed.OutMkysControl == null || _CensusFixed.OutMkysControl == false) && _CensusFixed.StockActionOutDetails.Count > 0)
                    {
                        _CensusFixed.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);

                        if ((_CensusFixed.InMkysControl == null || _CensusFixed.InMkysControl == false) && _CensusFixed.StockActionInDetails.Count > 0)
                        {
                            _CensusFixed.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                    else if ((_CensusFixed.InMkysControl == null || _CensusFixed.InMkysControl == false) && _CensusFixed.StockActionInDetails.Count > 0)
                    {
                        _CensusFixed.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    }
                }
            }
        }

        #endregion CensusFixedFormStockCardRegistryForm_Methods

    }
}