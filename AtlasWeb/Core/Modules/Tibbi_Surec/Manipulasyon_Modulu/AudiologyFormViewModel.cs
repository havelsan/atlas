//$6F9B2294
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class AudiologyObjectServiceController
    {
        partial void PreScript_AudiologyForm(AudiologyFormViewModel viewModel, AudiologyObject audiologyObject, TTObjectContext objectContext)
        {
            viewModel.DiagnosisArray = new AudiologyDiagnosisObject[0];

            List<AudiologyDiagnosisObject> diagnosisList = new List<AudiologyDiagnosisObject>();

            foreach(AudiologyDiagnosis diagnosis in audiologyObject.AudiologyDiagnosis)
            {
                AudiologyDiagnosisObject d = new AudiologyDiagnosisObject();
                d.DiagnosisDefObjectID = diagnosis.AudiologyDiagnosisDef.ObjectID;
                d.DiagnosisObjectID = diagnosis.ObjectID;
                d.Name = diagnosis.AudiologyDiagnosisDef.DiagnosisName;
                diagnosisList.Add(d);
            }

            viewModel.DiagnosisArray = diagnosisList.ToArray();
        }

    }
}

namespace Core.Models
{
    public partial class AudiologyFormViewModel: BaseViewModel, IManipulationFormBaseObjectViewModel
    {

        public AudiologyDiagnosisObject[] DiagnosisArray;
       

        public void AddManipulationFormBaseObjectViewModelToContext(TTObjectContext objectContext)
        {
            foreach (AudiologyDiagnosisObject diagnosis in this.DiagnosisArray)
            {
                if (diagnosis.DiagnosisObjectID == Guid.Empty)
                {
                    var audiologyDiagnosis = new AudiologyDiagnosis(objectContext);
                    var audiologyDiagnosisDef = (AudiologyDiagnosisDef)objectContext.GetObject(diagnosis.DiagnosisDefObjectID, "AudiologyDiagnosisDef");
                    audiologyDiagnosis.AudiologyDiagnosisDef = audiologyDiagnosisDef;
                    audiologyDiagnosis.AudiologyObject = this._AudiologyObject;

                }
            }

            objectContext.AddToRawObjectList(this._AudiologyObject);
            objectContext.ProcessRawObjects();
        }

        public void SetManipulationReport(Manipulation manipulation)
        {
            manipulation.Report = this._AudiologyObject.AudiologyReport;
        }
    }

    public class AudiologyDiagnosisObject
    {
        public Guid DiagnosisObjectID;
        public Guid DiagnosisDefObjectID;
        public string Name;
    }
}
