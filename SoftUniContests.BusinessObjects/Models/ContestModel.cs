using SoftUniContests.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniContests.BusinessObjects.Models
{
    public class ContestModel
    {
        public int ContestID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public RewardStrategy RewardStrategy { get; set; }
        public VotingStrategy VoteStrategy { get; set; }
        public ParticipationStrategy ParticipationStrategy { get; set; }
        [Required]
        public DeadlineStrategy DeadlineStrategy { get; set; }
        public List<PictureModel> Pictures { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public int? DeadlineParticipants { get; set; }
    }
}
