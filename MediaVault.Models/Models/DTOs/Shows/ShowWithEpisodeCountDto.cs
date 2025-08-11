using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaVault.Models.Models.DTOs.Shows
{
    public class ShowWithEpisodeCountDto
    {
        public string Title { get; set; } = string.Empty;
        public int EpisodeCount { get; set; }
        public decimal Rating { get; set; }
    }
}
