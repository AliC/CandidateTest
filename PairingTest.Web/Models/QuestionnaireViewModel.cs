using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PairingTest.Web.Models
{
    public class QuestionnaireViewModel
    {
        public string QuestionnaireTitle { get; set; }

        public IList<QuestionViewModel> Questions { get; set; }

        public class QuestionViewModel
        {
            public string Question { get; set; }

            public string Answer { get; set; }
        }
    }
}