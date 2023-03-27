
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
    /// Laboratuvar Şablonl Tanım Formu
    /// </summary>
    public partial class LaboratoryAcceptTemplateForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            GRIDUSERRESOURCES.CellValueChanged += new TTGridCellEventDelegate(GRIDUSERRESOURCES_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GRIDUSERRESOURCES.CellValueChanged -= new TTGridCellEventDelegate(GRIDUSERRESOURCES_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GRIDUSERRESOURCES_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region LaboratoryAcceptTemplateForm_GRIDUSERRESOURCES_CellValueChanged
   /* Yanlis Kod : yapmasi gereken satirdaki check isaretlendikce diger satirlardaki check in kaldirilmasi...
            if (columnIndex == 1)
            {
                if (GRIDUSERRESOURCES.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True")
                {
                    for(int i=0; i<GRIDUSERRESOURCES.Rows.Count; i++)
                    {
                        if (i != rowIndex)
                           GRIDUSERRESOURCES.Rows[rowIndex].Cells[columnIndex].Value = false;
                    }
                }
            } */
#endregion LaboratoryAcceptTemplateForm_GRIDUSERRESOURCES_CellValueChanged
        }

        protected override void PreScript()
        {
#region LaboratoryAcceptTemplateForm_PreScript
    base.PreScript();
            /*
            if (this._LaboratoryAcceptTemplateDefinition.CurrentStateDefID == LaboratoryAcceptTemplateDefinition.States.New)
            {
                if (this._LaboratoryAcceptTemplateDefinition.LaboratoryAcceptTemplateDetails.Count == 0)
                {
                    ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                    this._LaboratoryAcceptTemplateDefinition.ResUser = _myResUser;
                    
                    _myResUser.FillUserResources();
                    foreach (Resource outPatientRes in _myResUser.OutPatientUserResources)
                    {
                        //if (outPatientRes.ResType == ResourceTypeEnum.resObservationUnit)
                        //{
                        //gelen resource un tipi LaboratoryObservationUnit mi diye kontrol edilmeli...
                        LaboratoryAcceptTemplateDetail labAcceptTemplateDet = new LaboratoryAcceptTemplateDetail(this._LaboratoryAcceptTemplateDefinition.ObjectContext);
                        labAcceptTemplateDet.LaboratoryUnit =  (ResLaboratoryDepartment) outPatientRes;
                        labAcceptTemplateDet.SelectResource = false;
                        this._LaboratoryAcceptTemplateDefinition.LaboratoryAcceptTemplateDetails.Add(labAcceptTemplateDet);
                        //}
                    }
                }
            }
            */
#endregion LaboratoryAcceptTemplateForm_PreScript

            }
                }
}