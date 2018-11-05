using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerHelper
{
    class LOHWindowViewModel : RearrangementWindowViewModel
    {
        public string Gene { get; set; }

        public LOHWindowViewModel()
        {
            SelectedCN = "×2hmz";
        }

        protected override void OnSaveCommandExecuted(object window)
        {
            var locations = LocationParse();
            Mediator.NotifyColleggues("GetLOH",
            new LOHRearrangement(
                Chromosome,
                long.Parse(locations[0]),
                long.Parse(locations[1]),
                SelectedCN,
                "LOH"));
            ((IClosable)window)?.Close();
        }
    }
}
