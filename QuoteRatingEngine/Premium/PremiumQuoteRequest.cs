using QuoteRatingApi.Common.Enums;

namespace QuoteRatingApi.QuoteRatingEngine.Premium
{
    /// <summary>
    /// Request for calculating a premium quote
    /// </summary>
    public sealed class PremiumQuoteRequest
    {
        /// <summary>
        /// Revenue used for premium quote
        /// </summary>
        public decimal Revenue { get; set; }

        /// <summary>
        /// State Code used for premium quote
        /// </summary>
        public StatePostalCode State { get; set; }

        /// <summary>
        /// Business Type used for premium quote
        /// </summary>
        public BusinessType Business { get; set; }
    }
}
