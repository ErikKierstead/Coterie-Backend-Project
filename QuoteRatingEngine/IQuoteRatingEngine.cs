using QuoteRatingApi.QuoteRatingEngine.Premium;

namespace QuoteRatingApi.QuoteRatingEngine
{
    /// <summary>
    /// Responsible for managing calculations used in generating quotes
    /// </summary>
    public interface IQuoteRatingEngine
    {
        /// <summary>
        /// Processes request to generate a premium quote
        /// </summary>
        PremiumQuote CalculatePremiumQuote(PremiumQuoteRequest ratingRequest);
    }
}