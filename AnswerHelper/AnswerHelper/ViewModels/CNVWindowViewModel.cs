using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class CNVWindowViewModel : RearrangementWindowViewModel
    {
        public string Gene { get; set; }
        public override List<string> CopiesNumbers { get; } = new List<string>() { "×1", "×3", "×4" };

        public CNVWindowViewModel()
        {
            SelectedCN = "×1";
        }

        protected override void OnSaveCommandExecuted(object window)
        {
            var locations = LocationParse();
            Mediator.NotifyColleggues("GetCNV",
            new CNVRearrangement(
                Chromosome,
                long.Parse(locations[0]),
                long.Parse(locations[1]),
                SelectedCN,
                "CNV"));
            ((IClosable)window)?.Close();
        }
    }
}
