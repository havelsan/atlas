//$B40089F1
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using TTStorageManager;
using TTStorageManager.Security;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class MergePatientServiceController
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Dosyasi_Birlestirme)]
        public string CheckMergePatients(Patient[] patients)
        { //0 source 1 target
            string retValue = TTUtils.CultureService.GetText("M26177", "İşlem gerçekleştirilmedi.");
            if (TTUser.CurrentUser.HasRole(Common.MergePatientsRoleID) == true)
            {
                if (patients == null || patients.Length == 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26224", "İşlemi gerçekleştirebilmek için 'Kaynak ve Hedef arşivleri' seçmelisiniz."));
                if (patients[0] == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26223", "İşlemi gerçekleştirebilmek için 'Kaynak arşivi' seçmelisiniz."));
                if (patients[1] == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26222", "İşlemi gerçekleştirebilmek için 'Hedef arşivi' seçmelisiniz."));
                using (var objectContext = new TTObjectContext(false))
                {
                    try
                    {
                        Guid targetPatientObjectID = patients[1].ObjectID;
                        Patient targetPatient = (Patient)objectContext.GetObject(targetPatientObjectID, "Patient");
                        if (targetPatient.MergedToPatient != null)
                        {
                            Patient mp = (Patient)objectContext.GetObject(targetPatient.MergedToPatient.ObjectID, "Patient");
                            string[] hataParamList = new string[]{"'" + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + "'", "'" + mp.ID.ToString() + " " + mp.Name + " " + mp.Surname + "'"};
                            String message = SystemMessage.GetMessage(81);
                            throw new TTUtils.TTException(message);
                        //throw new Exception("'" + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname +
                        //                    "' hastasının kayıtları daha önceden " + "'" + mp.ID.ToString() + " " + mp.Name + " " + mp.Surname +
                        //                    "' hastasının dosyasına birleştirilmiş.");
                        }

                        Guid sourcePatientObjectID = patients[0].ObjectID;
                        Patient sourcePatient = (Patient)objectContext.GetObject(sourcePatientObjectID, "Patient");
                        if (sourcePatient.ObjectID != targetPatient.ObjectID)
                        {
                            if (sourcePatient.MergedToPatient != null)
                            {
                                Patient mp = (Patient)objectContext.GetObject(sourcePatient.MergedToPatient.ObjectID, "Patient");
                                string[] hataParamList = new string[]{"'" + sourcePatient.ID.ToString() + " " + sourcePatient.Name + " " + sourcePatient.Surname + "'", "'" + mp.ID.ToString() + " " + mp.Name + " " + mp.Surname + "'"};
                                String message = SystemMessage.GetMessage(81);
                                throw new TTUtils.TTException(message);
                            //throw new Exception("'" + sourcePatient.ID.ToString() + " " + sourcePatient.Name + " " + sourcePatient.Surname +
                            //                    "' hastasının kayıtları daha önceden " + "'" + mp.ID.ToString() + " " + mp.Name + " " + mp.Surname +
                            //                    "' hastasının dosyasına birleştirilmiş.");
                            }

                            //--
                            string differentProperties = "";
                            string ignoredPrpoerties = ",EHR,ImportantMedicalInformation,InpatientEpisode,MergedToPatient,PatientFolder,Service,";
                            foreach (TTObjectPropertyDef propDef in sourcePatient.ObjectDef.AllPropertyDefs)
                            {
                                if (!(ignoredPrpoerties.Contains("," + propDef.CodeName.ToString() + ",")))
                                {
                                    System.Reflection.PropertyInfo propInfo = sourcePatient.GetType().GetProperty(propDef.CodeName.ToString());
                                    if (propInfo != null)
                                    {
                                        object sourcePatientPropertyObject = propInfo.GetValue(sourcePatient, null);
                                        object targetPatientPropertyObject = propInfo.GetValue(targetPatient, null);
                                        string sourcePatientPropertyValue = sourcePatientPropertyObject == null ? "" : sourcePatientPropertyObject.ToString().Trim();
                                        string targetPatientPropertyValue = targetPatientPropertyObject == null ? "" : targetPatientPropertyObject.ToString().Trim();
                                        if (sourcePatientPropertyValue != targetPatientPropertyValue)
                                        {
                                            string caption = propDef.Caption == null ? propDef.Description : propDef.Caption;
                                            if (String.IsNullOrEmpty(caption))
                                                caption = propDef.CodeName;
                                            differentProperties += " , " + caption;
                                        }
                                    }
                                }
                            }

                            foreach (TTObjectRelationDef relDef in sourcePatient.ObjectDef.AllParentRelationDefs)
                            {
                                if (!(ignoredPrpoerties.Contains("," + relDef.CodeName.ToString() + ",")))
                                {
                                    System.Reflection.PropertyInfo propInfo = sourcePatient.GetType().GetProperty(relDef.CodeName.ToString());
                                    if (propInfo != null)
                                    {
                                        object sourcePatientPropertyObject = propInfo.GetValue(sourcePatient, null);
                                        object targetPatientPropertyObject = propInfo.GetValue(targetPatient, null);
                                        string sourcePatientPropertyValue = sourcePatientPropertyObject == null ? "" : sourcePatientPropertyObject.ToString().Trim();
                                        string targetPatientPropertyValue = targetPatientPropertyObject == null ? "" : targetPatientPropertyObject.ToString().Trim();
                                        if (sourcePatientPropertyValue != targetPatientPropertyValue)
                                        {
                                            string caption = relDef.ParentCaption == null ? relDef.ParentName : relDef.ParentCaption;
                                            differentProperties += " , " + caption;
                                        }
                                    }
                                }
                            }

                            if (!String.IsNullOrEmpty(differentProperties))
                                return "";
                        }
                        else
                        {
                            retValue = "Hedef ve Kaynak aynı olamaz";
                            return retValue;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }

                return retValue;
            }

            retValue = TTUtils.CultureService.GetText("M25313", "Bu işlem için yetkiniz bulunmamaktadır.");
            return retValue;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Dosyasi_Birlestirme)]
        public string MergePatients(Patient[] patients)
        { //0 source 1 target
            string returnVal = "";
            if (patients != null)
            {
                if (TTUser.CurrentUser.HasRole(Common.MergePatientsRoleID) == true)
                {
                    using (var objectContext = new TTObjectContext(false))
                    {
                        Guid sourcePatientObjectID = patients[0].ObjectID;
                        Patient sourcePatient = (Patient)objectContext.GetObject(sourcePatientObjectID, "Patient");
                        Guid targetPatientObjectID = patients[1].ObjectID;
                        Patient targetPatient = (Patient)objectContext.GetObject(targetPatientObjectID, "Patient");
                        ArrayList sourcePatientEpisodes = new ArrayList();
                        foreach (Episode e in sourcePatient.Episodes)
                        {
                            sourcePatientEpisodes.Add(e);
                        }

                        foreach (Episode e in sourcePatientEpisodes)
                        {
                            e.OldPatient = e.Patient; //To save old patient for dismerge.
                            e.Patient = targetPatient;
                        }

                        sourcePatient.MergedToPatient = targetPatient;
                        sourcePatient.UniqueRefNo = null;
                        sourcePatient.Note = "Hastanın dosyası, " + Common.RecTime().ToShortDateString() + " tarihinde " + targetPatient.ID.ToString() + " " + targetPatient.Name + " " + targetPatient.Surname + " hastası ile birleştirilmiştir.";
                        objectContext.Save();
                        returnVal = "01-Başarı ile hasta dosyaları birleştirildi.";
                    }
                }
                else
                    returnVal = "02-Bu işlem için yetkiniz yok";
            }

            return returnVal;
        }
    }
}

namespace Core.Models
{
    public partial class MergePatientFormViewModel
    {
        public TTObjectClasses.Patient[] Patients
        {
            get;
            set;
        }
    }
}