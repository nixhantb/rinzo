using System.ComponentModel.DataAnnotations;

namespace Rinzo.Domain.Enums
{
    public enum OpportunityStatus
    {
        [Display(Name = "In Progress")]
        InProgress = 1,

        [Display(Name = "Qualification")]
        Qualification = 2,

        [Display(Name = "Demonstration")]
        Demonstration = 3,

        [Display(Name = "Proposal Sent")]
        ProposalSent = 4,

        [Display(Name = "Negotiation Phase")]
        NegotiationPhase = 5,

        [Display(Name = "Closing Preparation")]
        ClosingPreparation = 6,

        [Display(Name = "Closed - Won")]
        ClosedWon = 7,

        [Display(Name = "Closed - Lost")]
        ClosedLost = 8
    }
}
