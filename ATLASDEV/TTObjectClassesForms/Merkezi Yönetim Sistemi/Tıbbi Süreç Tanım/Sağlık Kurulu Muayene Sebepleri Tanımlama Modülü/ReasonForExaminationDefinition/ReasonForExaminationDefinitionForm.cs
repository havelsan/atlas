
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
    /// Sağlık Kurulu Muayene Edecek Birim(ler) / XXXXXX(ler) Tanımlama
    /// </summary>
    public partial class ReasonForExaminationDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            ExaminationDepartmentsHospitals.CellValueChanged += new TTGridCellEventDelegate(ExaminationDepartmentsHospitals_CellValueChanged);
            HCReportTypeDefinition.SelectedObjectChanged += new TTControlEventDelegate(HCReportTypeDefinition_SelectedObjectChanged);            
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ExaminationDepartmentsHospitals.CellValueChanged -= new TTGridCellEventDelegate(ExaminationDepartmentsHospitals_CellValueChanged);
            HCReportTypeDefinition.SelectedObjectChanged -= new TTControlEventDelegate(HCReportTypeDefinition_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void HCReportTypeDefinition_SelectedObjectChanged()
        {
            #region ReasonForExaminationDefinitionForm_HCReportTypeDefinition_SelectedObjectChanged
            if (HCReportTypeDefinition != null && HCReportTypeDefinition.SelectedObjectID != null)
            {
                Guid guid = new Guid(HCReportTypeDefinition.SelectedObjectID.ToString());
                HCReportTypeDefinition hcr = (HCReportTypeDefinition)this._ReasonForExaminationDefinition.ObjectContext.GetObject(guid, "HCReportTypeDefinition");
                if (hcr.IsDisabled == true)
                {
                   
                    SystemForDisabledReportGrid.Visible = true;
                    lblSystems.Visible = true;
                    IList<SystemForDisabledReportDefinition> sdrList = SystemForDisabledReportDefinition.GetAllSystemForDisabledReportDef(this._ReasonForExaminationDefinition.ObjectContext);
                    foreach (SystemForDisabledReportDefinition sdr in sdrList)
                    {
                        SystemForDisabledReportGrid systemForDisabledReportGrid = new SystemForDisabledReportGrid(this._ReasonForExaminationDefinition.ObjectContext);
                        systemForDisabledReportGrid.SystemForDisabledReport = sdr;
                        this._ReasonForExaminationDefinition.SystemForDisabledReportGrid.Add(systemForDisabledReportGrid);
                        foreach (DisabledReportSpecialGrid dRSpeciality in systemForDisabledReportGrid.SystemForDisabledReport.DisabledReport)
                        {
                            HospitalsUnitsDefinitionGrid hospitalUnit = new HospitalsUnitsDefinitionGrid(_ReasonForExaminationDefinition.ObjectContext);
                            hospitalUnit.Speciality = dRSpeciality.Speciality;
                            this._ReasonForExaminationDefinition.HospitalsUnits.Add(hospitalUnit);
                        }

                    }
                }
                else
                {
                    SystemForDisabledReportGrid.Visible = false;
                    lblSystems.Visible = false;
                    this._ReasonForExaminationDefinition.SystemForDisabledReportGrid.Clear();
                    this._ReasonForExaminationDefinition.HospitalsUnits.Clear();
                }
            }

            #endregion ReasonForExaminationDefinitionForm_HCReportTypeDefinition_SelectedObjectChanged
        }    

        private void ExaminationDepartmentsHospitals_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReasonForExaminationDefinitionForm_ExaminationDepartmentsHospitals_CellValueChanged
            /*
                     if (columnIndex == 0)
                     {
                         Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID",Guid.Empty.ToString()));
                         if(this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].ExamHospital != null)
                         {
                             if(this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].ExamHospital is ResOtherHospital)
                             {
                                 if (((ResOtherHospital)this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].ExamHospital).Site.ObjectID == siteID)
                                 {
                                     ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[Birim.Name].ReadOnly = false;
                                     ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[TemplateNo.Name].ReadOnly = false;
                                     ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[TemplateDesc.Name].ReadOnly = false;
                                 }
                                 else
                                 {
                                     this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].ExaminationDepartment = null;
                                     this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].Template = null;
                                     this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].TemplateDescription = null;
                                     ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[Birim.Name].ReadOnly = true;
                                     ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[TemplateNo.Name].ReadOnly = true;
                                     ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[TemplateDesc.Name].ReadOnly = true;
                                 }
                             }
                             else
                             {
                                 this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].ExaminationDepartment = null;
                                 this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].Template = null;
                                 this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].TemplateDescription = null;
                                 ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[Birim.Name].ReadOnly = true;
                                 ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[TemplateNo.Name].ReadOnly = true;
                                 ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[TemplateDesc.Name].ReadOnly = true;
                             }
                         }
                     }
                      */

            if (columnIndex == 0)
            {
                // ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[Speciality.Name].ReadOnly = false;
                //this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].Speciality = null;
                //  ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[Birim.Name].ReadOnly = true;
                this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].Policklinic = null;
                this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].ProcedureDoctor = null;
                //  ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[ReferableResource.Name].ReadOnly = true;
                this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].EpisodeActionTemplate = null;
                // ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[EpisodeActionTemplate.Name].ReadOnly = true;
                this._ReasonForExaminationDefinition.HospitalsUnits[rowIndex].TemplateDescription = null;
                // ExaminationDepartmentsHospitals.Rows[rowIndex].Cells[TemplateDesc.Name].ReadOnly = true;
            }
#endregion ReasonForExaminationDefinitionForm_ExaminationDepartmentsHospitals_CellValueChanged
        }

        protected override void PreScript()
        {
#region ReasonForExaminationDefinitionForm_PreScript
    base.PreScript();            
           
#endregion ReasonForExaminationDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ReasonForExaminationDefinitionForm_PostScript
    bool bFoundDublicate = false;
            ITTObject theObject = this._ReasonForExaminationDefinition as ITTObject;
            /*
            if(theObject.IsNew)
            {
                bFoundDublicate = this.CheckDublicateReason(this.tttextbox1.Text);
            }
            */
            //bFoundDublicate = this.CheckDublicateReasonType(this._ReasonForExaminationDefinition.ReasonForExaminationType.Value);
            bFoundDublicate = this.CheckDublicateCode(this._ReasonForExaminationDefinition.Code.ToString());
            if(bFoundDublicate)
                throw new Exception(SystemMessage.GetMessageV3(1266, new string[] {this._ReasonForExaminationDefinition.Code.ToString()}));
            
            //            this._ReasonForExaminationDefinition.Reason = this.ExaminationReasonType.Text;
#endregion ReasonForExaminationDefinitionForm_PostScript

            }
            
#region ReasonForExaminationDefinitionForm_Methods
        private bool CheckDublicateReasonType(ReasonForExaminationTypeEnum theEnum)
        {
            bool bFound = false;
            IList<ReasonForExaminationDefinition> listInstance = ReasonForExaminationDefinition.GetReasonForExaminationDefinitions(this._ReasonForExaminationDefinition.ObjectContext);
            if(listInstance != null)
            {
                foreach(ReasonForExaminationDefinition pDef in listInstance)
                {
                    if(!this._ReasonForExaminationDefinition.ObjectID.Equals(pDef.ObjectID) &&  pDef.ReasonForExaminationType.Value == theEnum)
                    {
                        bFound=true;
                        break;
                    }
                }
            }
            
            return bFound;
        }
        
        private bool CheckDublicateReason(string reason)
        {
            bool bFound = false;
            IList<ReasonForExaminationDefinition> listInstance = ReasonForExaminationDefinition.GetReasonForExaminationDefinitions(this._ReasonForExaminationDefinition.ObjectContext);
            if(listInstance != null)
            {
                foreach(ReasonForExaminationDefinition pDef in listInstance)
                {
                    if(!this._ReasonForExaminationDefinition.ObjectID.Equals(pDef.ObjectID) &&  pDef.Reason == reason)
                    {
                        bFound=true;
                        break;
                    }
                }
            }
            
            return bFound;
        }
        
        private bool CheckDublicateCode(string Code)
        {
            bool bFound = false;
            IList<ReasonForExaminationDefinition> listInstance = ReasonForExaminationDefinition.GetReasonForExaminationDefinitions(this._ReasonForExaminationDefinition.ObjectContext);
            if(listInstance != null)
            {
                foreach(ReasonForExaminationDefinition pDef in listInstance)
                {
                    if(!this._ReasonForExaminationDefinition.ObjectID.Equals(pDef.ObjectID) &&  pDef.Code.ToString() == Code)
                    {
                        bFound=true;
                        break;
                    }
                }
            }
            
            return bFound;
        }
        
#endregion ReasonForExaminationDefinitionForm_Methods
    }
}