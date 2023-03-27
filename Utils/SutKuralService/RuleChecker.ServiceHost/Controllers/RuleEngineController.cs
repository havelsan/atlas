using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TTUtils;
using TTUtils.Entities;

namespace RuleChecker.ServiceHost.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class RuleEngineController : Controller
    {
        private readonly IRuleCheckEngine _ruleEngine;

        public RuleEngineController(IRuleCheckEngine ruleEngine)
        {
            _ruleEngine = ruleEngine;
        }

        public class EchoInput
        {
            public string Message { get; set; }
        }

        [HttpGet]
        public string IsAlive()
        {
            return "OK";
        }

        [HttpPost]
        public string Echo([FromBody]EchoInput input)
        {
            return input.Message;
        }

        [HttpPost]
        public string ExceptionTest([FromBody]EchoInput input)
        {
            throw new ApplicationException(input.Message);
        }

        public class ValidateRulesForInvoiceInput
        {
            public string patientId { get; set; }
            public string admissionId { get; set; }
        }

        [HttpPost]
        public ActionResult<RuleValidateResultDto> ValidateRulesForInvoice([FromBody]ValidateRulesForInvoiceInput input)
        {
            if (input == null)
                return BadRequest();

            var validationResult = _ruleEngine.ValidateRulesForInvoice(input.patientId, input.admissionId);

            return Ok(validationResult);
        }


        public class ValidateRulesInput
        {
            public string PatientId { get; set; }
            public string AdmissionId { get; set; }
            public IEnumerable<ProcedureEntryDto> ProcedureEntries { get; set; }
            public IEnumerable<string> Icd10CodesEntries { get; set; }
        }

        [HttpPost]
        public ActionResult<RuleValidateResultDto> ValidateRules([FromBody]ValidateRulesInput input)
        {
            if (input == null)
                return BadRequest();

            var validationResult = _ruleEngine.ValidateRules(input.PatientId, input.AdmissionId, input.ProcedureEntries, input.Icd10CodesEntries);

            return Ok(validationResult);
        }


    }
}
