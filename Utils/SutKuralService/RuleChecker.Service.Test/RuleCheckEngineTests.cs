using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TTUtils;
using TTUtils.Entities;
using Xunit;

namespace RuleChecker.Service.Test
{
    public class RuleCheckEngineTests : UnitTestBase
    {
        private readonly IRuleCheckEngine _ruleCheckEngine;

        public RuleCheckEngineTests()
        {
            _ruleCheckEngine = ServiceProvider.GetRequiredService<IRuleCheckEngine>();
        }

        [Fact]
        public void Test_Rule_Engine_Instance()
        {
            Assert.NotNull(_ruleCheckEngine);
        }


        [Fact]
        public void Test_Rule1()
        {
            var patientId = "eb6e9c24-b9cd-4932-9c54-85f96d847f28";
            var episodeId = "8479b57d-5372-44e4-8ad9-72d89802b854";
            var procedureEntries = new ProcedureEntryDto[] {
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "615270",
                },
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "615280",
                },
            };

            var result = _ruleCheckEngine.ValidateRules(patientId, episodeId, procedureEntries, null);
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Rule2()
        {
            var patientId = "bfa8a2a8-34b7-4f23-8a7e-5dd944acdf00";
            var episodeId = "52311bc5-2fba-46b4-a641-10b194536c66";
            var procedureEntries = new ProcedureEntryDto[] {
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "701610",
                },
            };

            var result = _ruleCheckEngine.ValidateRules(patientId, episodeId, procedureEntries, null);
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Rule3()
        {
            var patientId = "8a775df6-c471-4838-b272-94a9e82d3ad0";
            var episodeId = "fe90e557-c53c-463f-86d4-043144be0a38";

            var procedureEntries = new ProcedureEntryDto[] {
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "530560",
                },
            };

            var result = _ruleCheckEngine.ValidateRules(patientId, episodeId, procedureEntries, null);
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Rule5()
        {
            var patientId = "2905e6f4-fc5e-460a-8b70-98daa5061801";
            var episodeId = "f74ecf4a-a537-4a6d-9d0f-9c4a237b39dc";

            var procedureEntries = new ProcedureEntryDto[] {
                new ProcedureEntryDto() {
                     EntryDate = DateTime.Now,
                     EntryQuantity = 1,
                     ProcedureCode = "530880",
                },
            };

            var result = _ruleCheckEngine.ValidateRules(patientId, episodeId, procedureEntries, null);
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Rule_01()
        {
            //P600050 ve P600060 Birlikte faturalanamaz.
            List<ProcedureEntryDto> procedureEntryList = new List<ProcedureEntryDto>() {
                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "618660"},
                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "618660"},
                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "800620"},
                //new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "800620"},
                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =2 ,ProcedureCode = "405260"},
                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =3 ,ProcedureCode = "405260"},

                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "600740"},
                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "621360"},
                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "621360"},
                
                //new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "702170"},
                //new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "908800"},
                //                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "908800"},
                //                new ProcedureEntryDto { EntryDate = DateTime.Now, EntryQuantity =1 ,ProcedureCode = "701670"}
            };

            var result = _ruleCheckEngine.ValidateRules("dc777741-6f61-4860-b7da-19d4fb2b90af", "2a05ccfd-bbfd-47e5-9306-965c01f0c59e", procedureEntryList, null);
            Assert.NotNull(result.Messages);
        }
        [Fact]
        public void Test_Rule19()
        {
            var patientId = "eb6e9c24-b9cd-4932-9c54-85f96d847f28";
            var episodeId = "8479b57d-5372-44e4-8ad9-72d89802b854";

            var procedureEntries = new ProcedureEntryDto[] {
                new ProcedureEntryDto() {
                     EntryDate = new DateTime(2013,10,1),
                     EntryQuantity = 1,
                     ProcedureCode = "P407350",
                },
                new ProcedureEntryDto() {
                     EntryDate = new DateTime(2013,6,1),
                     EntryQuantity = 1,
                     ProcedureCode = "P407350",
                },
                new ProcedureEntryDto() {
                     EntryDate = new DateTime(2013,1,1),
                     EntryQuantity = 1,
                     ProcedureCode = "P407350",
                },
            };

            var result = _ruleCheckEngine.ValidateRules(patientId, episodeId, procedureEntries, null);
            Assert.NotNull(result);
        }

    }
}
