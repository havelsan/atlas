/*
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
    /// Sayman Mutemetliği / Vezne / Fatura Servisi Açma
    /// </summary>
    public partial class CashOfficeOpeningForm : TTForm
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
#region CashOfficeOpeningForm_PreScript
    if (_CashOfficeOpening.CurrentStateDefID == CashOfficeOpening.States.New)
            {
                
                CashierLog  _myCashierLog = null;
                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
                
                
                if (_myCashierLog != null)
                {
                    string type = "";
                    
                    if (_myCashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                        type = "Muhasebe Yetkilisi Mutemetliği";
                    else if (_myCashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                        type = "Vezne";
                    else if (_myCashierLog.CashOffice.Type == CashOfficeTypeEnum.InvoicingService)
                        type = "Fatura Servisi";
                    
                    throw new TTUtils.TTException(SystemMessage.GetMessage(107, new string[] {type}));
                }
                else
                {
                    this.cmdOK.Visible =  false;
                    if (_CashOfficeOpening.CashierLog == null)
                    {
                        _CashOfficeOpening.CashierLog = new CashierLog(_CashOfficeOpening.ObjectContext);
                        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
                        
                        string compName = System.Environment.MachineName.ToUpper(cultureInfo);
                        
                        IList myList = CashOfficeComputerUserDefinition.GetByUserNameCompName(_CashOfficeOpening.ObjectContext, _myResUser.ObjectID.ToString(), compName);
                        if (myList.Count == 0)
                            throw new TTUtils.TTException(SystemMessage.GetMessage(121));
                        else
                        {
                            CashOfficeComputerUserDefinition cuser = (CashOfficeComputerUserDefinition) myList[0];
                            _CashOfficeOpening.CashierLog.ResUser = cuser.ResUser;
                            _CashOfficeOpening.CashierLog.CashOffice = cuser.CashOffice;
                            _CashOfficeOpening.CashierLog.OpeningDate = DateTime.Now.Date;
                            _CashOfficeOpening.CashierLog.LogID.GetNextValue();
                            _CashOfficeOpening.COMPUTERNAME = cuser.ComputerName;
                            this.LOGID.Text = _CashOfficeOpening.CashierLog.LogID.Value.ToString();
                        }
                    }
                    
                }
            }
            else
                this.LOGID.Text = _CashOfficeOpening.CashierLog.LogID.Value.ToString();
            
            if(_CashOfficeOpening.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                this.Text = "Muhasebe Yetkilisi Mutemetliği Açma (" + this._CashOfficeOpening.CurrentStateDef.DisplayText + ")";
                this.AdLabel.Text = "Muh.Yetkilisi Mutemetliği Adı";
                this.LogLabel.Text = "Açılış İz Sürme No";
                this.TarihLabel.Text = "Açılış Tarihi";
            }
            else  if (_CashOfficeOpening.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                this.Text = "Vezne Açma (" + this._CashOfficeOpening.CurrentStateDef.DisplayText + ")";
                this.AdLabel.Text = "Vezne Adı";
                this.LogLabel.Text = "Açılış İz Sürme No";
                this.TarihLabel.Text = "Açılış Tarihi";
            }
            else if (_CashOfficeOpening.CashierLog.CashOffice.Type == CashOfficeTypeEnum.InvoicingService)
            {
                this.Text = "Fatura Servisi Açma (" + this._CashOfficeOpening.CurrentStateDef.DisplayText + ")";
                this.AdLabel.Text = "Fatura Servisi Adı";
                this.LogLabel.Text = "Açılış İz Sürme No";
                this.TarihLabel.Text = "Açılış Tarihi";
            }
#endregion CashOfficeOpeningForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CashOfficeOpeningForm_PostScript
    string[] parameters = new string[] { _CashOfficeOpening.CashierLog.CashOffice.Name.ToString() , Convert.ToDateTime(_CashOfficeOpening.CashierLog.OpeningDate).Date.ToShortDateString() };
            string message = SystemMessage.GetMessage(126,parameters);
            
            InfoBox.Alert(message, MessageIconEnum.InformationMessage);
#endregion CashOfficeOpeningForm_PostScript

            }
                }
}*/