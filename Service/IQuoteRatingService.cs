using QuoteRatingApi.Service.DTOs;

namespace QuoteRatingApi.Service
{
    /// <summary>
    /// Represents service managing requests for quote ratings
    /// </summary>
    public interface IQuoteRatingService
    {
        /// <summary>
        /// Processes request to generate a premium quote
        /// </summary>
        PremiumQuoteDTO ProcessPremiumQuoteRequest(PremiumQuoteRequestDTO requestDTO);
    }
}
