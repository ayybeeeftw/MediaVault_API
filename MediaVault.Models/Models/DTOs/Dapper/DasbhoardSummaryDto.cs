using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaVault.Models.Models.DTOs.Dapper
{
   public class DashboardSummaryDto
    {
        public int TotalShows { get; set; }
        public int TotalEpisodes { get; set; }
        public int TotalActors { get; set; }
        public int TotalGenres { get; set; }
    }
}
