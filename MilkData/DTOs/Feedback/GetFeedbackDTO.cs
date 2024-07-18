using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Feedback
{
    public class GetFeedbackDTO
    {
        public int FeedbackId { get; set; }

        public int AccountId { get; set; }

        public int ProductId { get; set; }

        public string? Description { get; set; }

        public string FeedbackContent { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int Rating { get; set; }

        public string Status { get; set; } = null!;

        public string Type { get; set; } = null!;
    }

    public class FeedbackDTO
    {
        public int AccountId { get; set; }

        public int ProductId { get; set; }

        public string? Description { get; set; }

        public string FeedbackContent { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int Rating { get; set; }

        public string Status { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}
