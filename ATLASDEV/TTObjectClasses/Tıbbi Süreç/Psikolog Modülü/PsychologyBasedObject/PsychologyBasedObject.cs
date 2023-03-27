
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
    public partial class PsychologyBasedObject : SpecialityBasedObject
    {
        public Boolean isUserAuthorized(BasePsychologyForm basePsychologyForm)
        {
            var CurrentUser = Common.CurrentResource;
            if (VisibleForProcedureDoctor != null)
            {
                if (VisibleForProcedureDoctor == true)
                {
                    if (PsychologicExamination.ProcedureByUser == null)
                        throw new TTException(TTUtils.CultureService.GetText("M26157", "İstem Yapılırken Psikolog Seçil(e)mediği için bu ekran açılamamaktadır."), new Exception("ObjectId = " + ObjectID));
                    if (basePsychologyForm.ProcedureDoctor.ObjectID == CurrentUser.ObjectID)
                        return true;
                }
            }
            if (VisibleForProcAndRequestDoc != null)
            {
                if (VisibleForProcAndRequestDoc == true)
                {
                    if (basePsychologyForm.ProcedureDoctor.ObjectID == CurrentUser.ObjectID || basePsychologyForm.PsychologyBasedObject.RequestDoctor.ObjectID == CurrentUser.ObjectID)
                        return true;
                }
            }
            if (VisibleForPsychologyUnit != null)
            {
                if (VisibleForPsychologyUnit == true)
                {
                    if (CurrentUser.UserType == UserTypeEnum.Psychologist)
                        return true;
                }
            }
            if (VisibleForSelectedUsers != null)
            {
                if (VisibleForSelectedUsers == true)
                {
                    var authorizedUsers = PsychologyAuthorizedUsers;
                    foreach (PsychologyAuthorizedUser user in authorizedUsers)
                    {
                        if (user.ResUser.ObjectID == CurrentUser.ObjectID)
                            return true;
                    }
                }
            }
            return false;
        }

        public Boolean isUserAuthorizedForPsychologyBasedObject(PsychologyBasedObject psychologyBasedObjectForm)
        {
            var CurrentUser = Common.CurrentResource;
            if (psychologyBasedObjectForm.VisibleForProcedureDoctor != null)
            {
                if (psychologyBasedObjectForm.VisibleForProcedureDoctor == true)
                {
                    if (psychologyBasedObjectForm.PsychologicExamination.ProcedureByUser == null)
                        throw new TTException(TTUtils.CultureService.GetText("M26157", "İstem Yapılırken Psikolog Seçil(e)mediği için bu ekran açılamamaktadır."), new Exception("ObjectId = " + ObjectID));
                    if (psychologyBasedObjectForm.PsychologicExamination.ProcedureByUser.ObjectID == CurrentUser.ObjectID)
                        return true;
                }
            }
            if (VisibleForProcAndRequestDoc != null)
            {
                if (VisibleForProcAndRequestDoc == true)
                {
                    if (psychologyBasedObjectForm.PsychologicExamination.ProcedureByUser.ObjectID == CurrentUser.ObjectID || psychologyBasedObjectForm.RequestDoctor.ObjectID == CurrentUser.ObjectID)
                        return true;
                }
            }
            if (VisibleForPsychologyUnit != null)
            {
                if (VisibleForPsychologyUnit == true)
                {
                    if (CurrentUser.UserType == UserTypeEnum.Psychologist)
                        return true;
                }
            }
            if (VisibleForSelectedUsers != null)
            {
                if (VisibleForSelectedUsers == true)
                {
                    var authorizedUsers = psychologyBasedObjectForm.PsychologyAuthorizedUsers;
                    foreach (PsychologyAuthorizedUser user in authorizedUsers)
                    {
                        if (user.ResUser.ObjectID == CurrentUser.ObjectID)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
