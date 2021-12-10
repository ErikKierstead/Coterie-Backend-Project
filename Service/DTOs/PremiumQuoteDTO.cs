namespace QuoteRatingApi.Service.DTOs
{
    /// <summary>
    /// Results DTO for premium quote
    /// </summary>
    public sealed class PremiumQuoteDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PremiumQuoteDTO"/> class.
        /// </summary>
        public PremiumQuoteDTO(decimal premimum)
        {
            Premium = premimum;
        }

        /// <summary>
        /// Calculated premium for quote
        /// </summary>
        public decimal Premium { get; }
    }
}