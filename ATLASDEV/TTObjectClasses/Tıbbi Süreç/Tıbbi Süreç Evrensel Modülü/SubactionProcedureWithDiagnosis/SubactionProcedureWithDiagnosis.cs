
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


namespace TTObjectClasses
{
    public  partial class SubactionProcedureWithDiagnosis : SubactionProcedureFlowable
    {
#region Methods
        protected virtual List<List<EpisodeAction.OldActionPropertyObject>> OldActionPreDiagnosisList()
        {
            // Ön Tanı Gridi
            List<List<EpisodeAction.OldActionPropertyObject>> gridPreDiagnosisRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();
            foreach (DiagnosisGrid preDiagnose in Diagnosis)
            {
                if (preDiagnose.DiagnosisType == DiagnosisTypeEnum.Primer)
                {
                    // Öntanının her bir satırı için kolonları taşıyan Liste
                    List<EpisodeAction.OldActionPropertyObject> gridPreDiagnosisRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
                    gridPreDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25722", "Giriş Tarihi"), Common.ReturnObjectAsString(preDiagnose.DiagnoseDate)));
                    gridPreDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M19986", "Ön Tanı"), Common.ReturnObjectAsString(preDiagnose.Diagnose.Name)));
                    gridPreDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M10926", "Ana Tanı"), Common.ReturnObjectAsString(preDiagnose.IsMainDiagnose)));
                    if (preDiagnose.ResponsibleUser == null)
                        gridPreDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26669", "Ön Tanıyı Koyan"), ""));
                    else
                        gridPreDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26669", "Ön Tanıyı Koyan"), Common.ReturnObjectAsString(preDiagnose.ResponsibleUser)));
                    gridPreDiagnosisRowList.Add(gridPreDiagnosisRowColumnList);
                }
            }
            
            return gridPreDiagnosisRowList;
        }

        protected virtual List<List<EpisodeAction.OldActionPropertyObject>> OldActionSecDiagnosisList()
        {
            // Ön Tanı Gridi
            List<List<EpisodeAction.OldActionPropertyObject>> gridSecDiagnosisRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();
            foreach (DiagnosisGrid secDiagnose in Diagnosis)
            {
                if (secDiagnose.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    // Öntanının her bir satırı için kolonları taşıyan Liste
                    List<EpisodeAction.OldActionPropertyObject> gridSecDiagnosisRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
                    gridSecDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25722", "Giriş Tarihi"), Common.ReturnObjectAsString(secDiagnose.DiagnoseDate)));
                    gridSecDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M17498", "Kesin Tanı"), Common.ReturnObjectAsString(secDiagnose.Diagnose.Name)));
                    gridSecDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M10926", "Ana Tanı"), Common.ReturnObjectAsString(secDiagnose.IsMainDiagnose)));
                    if (secDiagnose.ResponsibleUser == null)
                        gridSecDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26298", "Kesin Tanıyı Koyan"), ""));
                    else
                        gridSecDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26298", "Kesin Tanıyı Koyan"), Common.ReturnObjectAsString(secDiagnose.ResponsibleUser)));
                    gridSecDiagnosisRowList.Add(gridSecDiagnosisRowColumnList);
                }
            }
            return gridSecDiagnosisRowList;
        }
        
        
        protected System.Collections.Generic.IList<DiagnosisGrid> _PreDiagnosis = null;
        public System.Collections.Generic.IList<DiagnosisGrid> PreDiagnosis
        {
            get
            {
                if (_PreDiagnosis == null)
                    _PreDiagnosis = Diagnosis.Where(r => r.DiagnosisType.Value == DiagnosisTypeEnum.Primer).ToList();
                return _PreDiagnosis;
            }
        }
        protected System.Collections.Generic.IList<DiagnosisGrid> _SecDiagnosis = null;
        public System.Collections.Generic.IList<DiagnosisGrid> SecDiagnosis
        {
            get
            {
                if (_SecDiagnosis == null)
                    _SecDiagnosis = Diagnosis.Where(r => r.DiagnosisType.Value == DiagnosisTypeEnum.Seconder).ToList();
                return _SecDiagnosis;
            }
        }
        
#endregion Methods

    }
}