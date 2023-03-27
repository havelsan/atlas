
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
    /// Hasta Nakil İşlemleri
    /// </summary>
    public partial class TransplantForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region TransplantForm_PostScript
    base.PostScript(transDef);
            
            if(transDef != null)
            {
                if(transDef.ToStateDefID == Transplant.States.Completed)
                {
                    Morgue theAction = new Morgue(_Transplant.ObjectContext);
                    theAction.ActionDate = Common.RecTime();
                    theAction.MasterResource = null;
                    theAction.FromResource = _Transplant.MasterResource;
                    theAction.Episode = _Transplant.Episode;
                    theAction.CurrentStateDefID = Morgue.States.Request;
                    theAction.MasterAction= _Transplant;
                    theAction.SenderDoctor = _Transplant.SenderDoctor;
                    theAction.DateTimeOfDeath = _Transplant.DateTimeOfDeath;
                    theAction.DoctorFixed = _Transplant.DoctorFixed;
                    theAction.Nurse = _Transplant.Nurse;
                    theAction.MernisDeathReasons = _Transplant.MernisDeathReasons;
                    theAction.StatisticalDeathReason = _Transplant.StatisticalDeathReason;
                    theAction.ObjectsFromPatient = _Transplant.ObjectsFromPatient;
                    theAction.MorgueTransplant.Add(_Transplant);
                    
                    //                            TTForm theForm = TTForm.GetEditForm(theAction);
                    //                            this.PrapareFormToShow(theForm);
                    //                            DialogResult dialogResult=theForm.Show Edit(this,theAction);
                    //                            if(dialogResult!= DialogResult.OK)
                    //                            {
                    //                                throw new Exception(SystemMessage.GetMessage(682));
                    //                            }
                    
                    
                    //   transplant.DateTimeOfDeath = this._Morgue.DateTimeOfDeath;
                    //                        transplant.DoctorFixed = this._Morgue.DoctorFixed;
                    //                        transplant.SenderDoctor = this._Morgue.SenderDoctor;
                    //                        transplant.Nurse = this._Morgue.Nurse;
                    //                        transplant.MernisDeathReasons = this._Morgue.MernisDeathReasons;
                    //                        transplant.StatisticalDeathReason = this._Morgue.StatisticalDeathReason;
                    //                        transplant.ObjectsFromPatient = this._Morgue.ObjectsFromPatient;
                    //                        transplant.CurrentStateDefID = Transplant.States.Request;
                    //                        this._Morgue.MorgueTransplant.Add(transplant);
                    //                        this._Morgue.ObjectContext.Save();
                }
            }
#endregion TransplantForm_PostScript

            }
                }
}