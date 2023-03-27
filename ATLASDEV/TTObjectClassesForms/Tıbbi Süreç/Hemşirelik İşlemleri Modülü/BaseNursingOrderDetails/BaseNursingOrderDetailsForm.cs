
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
    public partial class BaseNursingOrderDetailsForm : TTForm
    {
        override protected void BindControlEvents()
        {
            
            base.BindControlEvents();
            ProcedureObject.SelectedObjectChanged += new TTControlEventDelegate(ProcedureObject_SelectedObjectChanged);
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
            ProcedureObject.SelectedObjectChanged -= new TTControlEventDelegate(ProcedureObject_SelectedObjectChanged);
        }


        private void ProcedureObject_SelectedObjectChanged()
        {
            #region BaseNursingOrderDetailsForm_ProcedureObject_SelectedObjectChanged

            ArrangeResultFieldsVisibility();
            #endregion BaseNursingOrderDetailsForm_ProcedureObject_SelectedObjectChanged
        }

        protected override void ClientSidePreScript()
        {
            #region ConsultationDoctorExaminationFormNew_PreScript
            base.ClientSidePreScript();
            ArrangeResultFieldsVisibility();
            #endregion ConsultationDoctorExaminationFormNew_PreScript
        }


        private void ArrangeResultFieldsVisibility()
        {
            if (this.ProcedureObject.SelectedObject != null)
            {
                VitalSignAndNursingDefinition vitalSignAndNursingDefinition = (VitalSignAndNursingDefinition)this.ProcedureObject.SelectedObject;

                if (vitalSignAndNursingDefinition.DontNeedDataDuringApplication == true)
                {
                    Result.Visible = false;
                    ResultBySelection.Visible = false;
                }
                else if (vitalSignAndNursingDefinition.Values.Count > 1)
                {
                    Result.Visible = false;
                    ResultBySelection.Visible = true;
                }
                else
                {
                    Result.Visible = true;
                    ResultBySelection.Visible = false;
                }
            }
        }


        private string GetResultMask()
        {
            if (this.ProcedureObject.SelectedObject != null)
            {
                VitalSignAndNursingDefinition vitalSignAndNursingDefinition = (VitalSignAndNursingDefinition)this.ProcedureObject.SelectedObject;

                if (vitalSignAndNursingDefinition.VitalSignType != null)
                {
                    switch (((VitalSignAndNursingDefinition)this.ProcedureObject).VitalSignType)
                    {
                        case VitalSignType.BloodPressure:
                            {
                                return "999-999".Replace("_", "");//console.log(data.component._textValue.replace(/_/g,""));
                                //console.log(data.value);
                                //console.log(data.component._textValue);
                                //console.log(data.component._textValue.replace(/ _ / g, ""));
                            }
                        case VitalSignType.Height:
                            {
                                return "999";
                            }
                        case VitalSignType.Weight:
                            {
                                return "999";
                            }
                        case VitalSignType.Temperature:
                            {
                                return "99.9";
                            }
                        case VitalSignType.Pulse:
                            {
                                return "";
                            }
                        case VitalSignType.Respiration:
                            {
                                return "";
                            }
                        case VitalSignType.SPO2:
                            {
                                return "";
                            }
                        default:
                            return "";

                    }

                }
            }
            return "";
        }

    }


}