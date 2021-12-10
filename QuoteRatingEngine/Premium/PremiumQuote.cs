namespace QuoteRatingApi.QuoteRatingEngine.Premium
{
    /// <summary>
    /// Results for calculated premium quote
    /// </summary>
    public sealed class PremiumQuote
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PremiumQuote"/> class.
        /// </summary>
        public PremiumQuote(decimal premium)
        {
            Premium = premium;
        }

        /// <summary>
        /// Calculated premium for quote
        /// </summary>
        public decimal Premium { get; }
    }
}
