
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
    public abstract partial class EpisodeActionWithDiagnosis : EpisodeAction
    {
        public partial class OLAP_GetLastDiagnosis_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetEpisodeDiagnosis_Class : TTReportNqlObject
        {
        }

        #region Methods
        /// <summary>
        /// MasterActioID'si ça?yran actionun ActionID'si ile ayny olan bütün action collectionunu ArrayList veritipi için doldurur.
        /// </summary>

        //protected ArrayList GetLinkedActions(){
        //    ArrayList actionList = new ArrayList();
        //    foreach(EpisodeAction episodeaction in Episode.EpisodeActions)
        //        actionList.Add(episodeaction);
        //    return actionList;
        //}


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



        public override void Cancel()
        {
            base.Cancel();

            foreach (DiagnosisGrid diagnosisGrid in Diagnosis)
            {
                diagnosisGrid.Episode = null;
                diagnosisGrid.ImportantMedicalInformation = null;
            }
        }




        public string GetMyOrEpisodeDiagnosis()
        {
            int nCount = 1;
            string diagnosis = String.Empty;
            IList diagnosisCodeList = new List<string>();
            IList diagnosisList = new List<DiagnosisGrid>();
            if (Diagnosis.Count > 0)
            {
                diagnosisList = Diagnosis;
            }
            else
            {
                diagnosisList = (IList)Episode.SecDiagnosis;
            }

            if (diagnosisList.Count > 0)
                diagnosis += TTUtils.CultureService.GetText("M27037", "TANI: \r\n");

            foreach (DiagnosisGrid dg in diagnosisList)
            {
                if (diagnosisCodeList.Contains(dg.Diagnose.Code) == false)
                {
                    diagnosisCodeList.Add(dg.Diagnose.Code);
                    diagnosis += nCount.ToString() + "- " + dg.Diagnose.Code + " " + dg.Diagnose.Name;
                    if (dg.FreeDiagnosis != null)
                        diagnosis += " (" + dg.FreeDiagnosis + ")";
                    diagnosis += "\r\n";
                    nCount++;
                }
            }
            return diagnosis;
        }

        public void CheckIfSubEpisodeDiagnosisExists()
        {
            if (TransDef != null && Common.IsTransitionAttributeExists(typeof(AccountOperationAttribute), TransDef))
            {
                if (TransDef.Attributes["ACCOUNTOPERATIONATTRIBUTE"].Parameters["PreAccounting"].Value.ToString() == "2")
                {
                    if (Episode.PatientStatus == PatientStatusEnum.Outpatient && SubEpisode.IsSGK == true && IsMedulaProvisionNecessaryProcedureExists() == true)
                    {
                        if (Episode.Diagnosis.Count <= 0)
                            throw new Exception(SystemMessage.GetMessage(635));

                        if ((SubEpisode != null && SubEpisode.HasDiagnosis == false) && (Diagnosis == null || Diagnosis.Count <= 0))
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25147", "Alt vakaya ait tanı bulunamadı. Ana vaka tanıları, alt vaka tanısı olarak kullanılacaktır."));
                            //                            string result = TTVis ual.ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Uyarı","Alt vakaya ait tanı bulunamadı. Ana vaka tanılarının, alt vaka tanısı olarak kullanılmasını ister misiniz?");
                            //                            if(result == "E")
                            //                            {
                            List<DiagnosisGrid> dgList = new List<DiagnosisGrid>();
                            foreach (DiagnosisGrid pdgl in Episode.Diagnosis)
                            {
                                dgList.Add(pdgl);
                            }

                            foreach (DiagnosisGrid dg in dgList)
                            {
                                DiagnosisGrid diagnose = (DiagnosisGrid)dg.Clone();
                                diagnose.DiagnoseDate = Common.RecTime();
                                diagnose.EpisodeAction = this;
                                diagnose.SubactionProcedure = null;
                            }
                            //                            }
                            //                            else
                            //                                throw new Exception(SystemMessage.GetMessage(635));
                        }
                    }
                }
            }
        }




        public BindingList<DiagnosisGrid.GetLast10DiagnosisOfPatient_Class> Last10DiagnosisOfPatient  //GridLast10DiagnosisOfPatientBySpeciality
        {
            get { return DiagnosisGrid.GetLast10DiagnosisOfPatient(Episode.Patient.ObjectID.ToString(), ProcedureSpeciality.ObjectID.ToString(), string.Empty); }
        }


        public BindingList<DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser_Class> Top10DiagnosisDefinitionOfUser  // GridTop10DiagnosisOfUser
        {
            get
            {
                int dayPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("LIMITDAYOFTOP10DIAGNOSISOFUSER", "30"));
                return DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser(Common.CurrentResource.ObjectID.ToString(), Common.RecTime().AddDays(-1 * dayPeriod));
            }
        }


        public void AddMyPackageTemplateICDsToDiagnosisGrid(List<PackageTemplateICDDetailDefinition> packTempICDs)
        {
            foreach (PackageTemplateICDDetailDefinition myICD in packTempICDs)
            {
                DiagnosisGrid myDiagnosisGrid = new DiagnosisGrid(myICD);
                Diagnosis.Add(myDiagnosisGrid);
            }
        }

        public PackageTemplateDefinition CreateMyPackageTemplate(string pCode, string pName, List<PackageTemplateICDDetailDefinition> icdList, List<ProcedureRequestFormDetailDefinition> procedureList)
        {
            PackageTemplateDefinition packTemplate = new PackageTemplateDefinition(ObjectContext);
            packTemplate.Code = pCode;
            packTemplate.Name = pName;

            foreach (PackageTemplateICDDetailDefinition icdDetail in icdList)
            {
                packTemplate.PackageTemplateICDs.Add(icdDetail);
            }


            PackageTemplateProcReqFormDetailDefinition packProcReqFormDet = new PackageTemplateProcReqFormDetailDefinition(ObjectContext);

            foreach (ProcedureRequestFormDetailDefinition procedureDetail in procedureList)
            {
                packProcReqFormDet.ProcedureReqFormDetailDef = procedureDetail;
                packTemplate.ProcedureRequestFormDetailDefinitions.Add(packProcReqFormDet);
            }

            return packTemplate;
        }

        // TANI için .cs Prede çağırılmalı
        public DiagnosisGrid[] DiagnosisGrid_PreScript()
        {
            var diagnosisList = DiagnosisGrid.GetBySubEpisode(ObjectContext, SubEpisode.ObjectID.ToString());
            return diagnosisList.OrderByDescending(dr => dr.DiagnoseDate).ToArray();
        }

        // TANI için .cs Post'da çağırılmalı
        public void DiagnosisGrid_PostScript(DiagnosisGrid[] diagnosisList)
        {
            // Tanı Kontrolü
            if (diagnosisList == null || diagnosisList.Where(dr => dr.RemoveSubEpisodeRelation != true).Count() < 1)
            {
                throw new TTException(SystemMessage.GetMessage(635));
            }

            foreach (var viewModeldiagnosisGrid in diagnosisList)
            {
                var diagnosisGrid = (DiagnosisGrid)ObjectContext.GetLoadedObject(viewModeldiagnosisGrid.ObjectID);
                //var serializeCachelesin = diagnosisGrid.IsReportDiagnose; // IsReportDiagnose , okuyup cache lesin, serialize da hata vermesin diye;
                if (diagnosisGrid.EpisodeAction == null)
                    diagnosisGrid.EpisodeAction = this;

                var mevcutDiagnosisSubEpisode = diagnosisGrid.DiagnosisSubEpisodes.FirstOrDefault(dr => dr.SubEpisode == SubEpisode);
                if (diagnosisGrid.RemoveSubEpisodeRelation == true)/// Silinip kaydedilip tekrar refresh etmeden tekrar kaydedilirse silinen obje clienttan tekrar gelir o durumda tekar silinmesi için 
                {
                    List<Guid> diagnoseObjectIDList = null;
                    // <Tetkik Tanı Kontrolü
                    if (diagnosisGrid.Diagnose != null)
                    {
                        var requiredDiagnoseProcedures = diagnosisGrid.Diagnose.RequiredDiagnoseProcedures.Select("");

                        foreach (var rdp in requiredDiagnoseProcedures)
                        {
                            var a = SubEpisode.SubActionProcedures.FirstOrDefault(dr => dr.IsCancelled != true && dr.ProcedureObject.ObjectID == rdp.ProcedureDefinition.ObjectID);
                            if (a != null)
                            {
                                if (diagnoseObjectIDList == null)
                                    diagnoseObjectIDList = SubEpisode.Diagnosis.Where(dr => dr.RemoveSubEpisodeRelation != true && dr.Diagnose!= null).Select(dr => dr.Diagnose.ObjectID).ToList();
                                var zorunlutanilar = from dr in rdp.ProcedureDefinition.RequiredDiagnoseProcedures
                                                     join dg in diagnoseObjectIDList on dr.DiagnosisDefinition.ObjectID/// diagnosisList Contexte eklenmemiş hali olduğu için Diagnose Değeri boş . Dolayısı ile Contexdeki SubEpisodeDiagnosisleri alındı
                                                     equals dg
                                                     select dg;

                                if (zorunlutanilar.Count() == 0)
                                {
                                    throw new TTException(rdp.ProcedureDefinition.Code + " Hizmeti silinmeden " + diagnosisGrid.Diagnose.Code + "tanısı silinemez");
                                }
                            }
                        }
                    }


                    // Tetkik Tanı Kontrolü>

                    if (mevcutDiagnosisSubEpisode != null) // bu subepisodeda varsa silinir 
                        ((ITTObject)mevcutDiagnosisSubEpisode).Delete();
                    if (diagnosisGrid.DiagnosisSubEpisodes.Count() == 0)//tanının  bağlı olduğu subepisode kalmadı ise tanı silinir 
                        ((ITTObject)diagnosisGrid).Delete();
                    else
                        diagnosisGrid.RemoveSubEpisodeRelation = null; // bu değer her zaman işi bitince null'anmalı çünkü bu değer silsinen tanıları  Client-Server arasında taşımayı sağlar
                }
                else if (mevcutDiagnosisSubEpisode == null) // bu subepisodeda yoksa yeni eklenmiştir Sub episodela bağlantısı kurulur
                {
                    var diagnosisSubEpisode = new DiagnosisSubEpisode(ObjectContext);
                    diagnosisSubEpisode.SubEpisode = SubEpisode;
                    diagnosisSubEpisode.DiagnosisGrid = diagnosisGrid;
                }
        }
    }

    //protected virtual List<List<OldActionPropertyObject>> OldActionPreDiagnosisList()
    //{
    //    // Ön Tanı Gridi
    //    List<List<OldActionPropertyObject>> gridPreDiagnosisRowList = new List<List<OldActionPropertyObject>>();
    //    foreach (DiagnosisGrid preDiagnose in this.PreDiagnosis)
    //    {
    //        // Öntanının her bir satırı için kolonları taşıyan Liste
    //        List<OldActionPropertyObject> gridPreDiagnosisRowColumnList = new List<OldActionPropertyObject>();
    //        gridPreDiagnosisRowColumnList.Add(new OldActionPropertyObject("Giriş Tarihi", Common.ReturnObjectAsString(preDiagnose.DiagnoseDate)));
    //        gridPreDiagnosisRowColumnList.Add(new OldActionPropertyObject("Ön Tanı", Common.ReturnObjectAsString(preDiagnose.Diagnose.Name)));
    //        gridPreDiagnosisRowColumnList.Add(new OldActionPropertyObject("Ana Tanı", Common.ReturnObjectAsString(preDiagnose.IsMainDiagnose)));
    //        if (preDiagnose.ResponsibleUser == null)
    //            gridPreDiagnosisRowColumnList.Add(new OldActionPropertyObject("Ön Tanıyı Koyan", ""));
    //        else
    //            gridPreDiagnosisRowColumnList.Add(new OldActionPropertyObject("Ön Tanıyı Koyan", Common.ReturnObjectAsString(preDiagnose.ResponsibleUser)));
    //        gridPreDiagnosisRowList.Add(gridPreDiagnosisRowColumnList);
    //    }
    //    return gridPreDiagnosisRowList;
    //}
    //protected virtual List<List<OldActionPropertyObject>> OldActionSecDiagnosisList()
    //{
    //    // Ön Tanı Gridi
    //    List<List<OldActionPropertyObject>> gridSecDiagnosisRowList = new List<List<OldActionPropertyObject>>();
    //    foreach (DiagnosisGrid secDiagnose in this.SecDiagnosis)
    //    {
    //        // Öntanının her bir satırı için kolonları taşıyan Liste
    //        List<OldActionPropertyObject> gridSecDiagnosisRowColumnList = new List<OldActionPropertyObject>();
    //        gridSecDiagnosisRowColumnList.Add(new OldActionPropertyObject("Giriş Tarihi", Common.ReturnObjectAsString(secDiagnose.DiagnoseDate)));
    //        gridSecDiagnosisRowColumnList.Add(new OldActionPropertyObject("Kesin Tanı", Common.ReturnObjectAsString(secDiagnose.Diagnose.Name)));
    //        gridSecDiagnosisRowColumnList.Add(new OldActionPropertyObject("Ana Tanı", Common.ReturnObjectAsString(secDiagnose.IsMainDiagnose)));
    //        if (secDiagnose.ResponsibleUser == null)
    //            gridSecDiagnosisRowColumnList.Add(new OldActionPropertyObject("Kesin Tanıyı Koyan", ""));
    //        else
    //            gridSecDiagnosisRowColumnList.Add(new OldActionPropertyObject("Kesin Tanıyı Koyan", Common.ReturnObjectAsString(secDiagnose.ResponsibleUser)));
    //        gridSecDiagnosisRowList.Add(gridSecDiagnosisRowColumnList);
    //    }
    //    return gridSecDiagnosisRowList;
    //}
    //public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
    //{
    //    return base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);
    //}

    #endregion Methods

}
}