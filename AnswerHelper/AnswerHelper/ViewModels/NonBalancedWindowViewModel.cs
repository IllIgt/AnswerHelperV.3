using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class NonBalancedWindowViewModel : RearrangementWindowViewModel
    {
        public string Gene { get; set; }
        public override List<string> CopiesNumbers { get; } = new List<string>() { "×1", "×2", "×1~2", "×2~3"};

        public NonBalancedWindowViewModel()
        {
            SelectedCN = "×1~2";
        }

        protected override void OnSaveCommandExecuted(object window)
        {
            var locations = LocationParse();
            Mediator.NotifyColleggues("GetNonBalanced",
            new NonBalancedRearrangement(
                Chromosome,
                long.Parse(locations[0]),
                long.Parse(locations[1]),
                SelectedCN,
                "Несбалансированная"));
            ((IClosable)window)?.Close();
        }
    }
}
